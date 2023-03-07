using DotNetty.Buffers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Wave.Tool
{
	public class WaveUtils
	{
		public static byte[] GetWaveByfloat(float[] floats, float speed, float freq, int cycles, int samples)
		{
			byte comtype = 0; // 压缩方式：0：不压缩；1：zip
			byte endianness = 1; // 字节序：0：主机字节序；1：网络字节序

			float[] b = { 0, 1, 0 }; // 校正参数
			float[] p = { 0, 1, 0 }; // 率定参数

			IByteBuffer buffer = Unpooled.Buffer();

			buffer.WriteByte(0);
			buffer.WriteByte(comtype);
			buffer.WriteByte(endianness);
			foreach (float f in b)
			{
				buffer.WriteFloat(f);
			}
			foreach (float pp in p)
			{
				buffer.WriteFloat(pp);
			}
			buffer.WriteFloat(speed);
			buffer.WriteFloat(freq);
			buffer.WriteInt(cycles);
			buffer.WriteInt(samples);
			buffer.WriteInt(6);
			buffer.WriteInt(samples * 4);
			foreach (float f in floats)
			{
				buffer.WriteFloat(f);
			}

			return buffer.Array;
		}

		public static byte[] ReverseByte(float value)
		{
			var temp = BitConverter.GetBytes(value);
			Array.Reverse(temp);
			return temp;
		}



		public static float getP(float[] wave)
		{
			float max = 0;
			for (int i = 0; i < wave.Length; i++)
			{
				if (Math.Abs(wave[i]) > max)
				{
					max = Math.Abs(wave[i]);
				}
			}
			return max;
		}

		public static float getPP(float[] wave)
		{
			float max = 0;
			float min = 0;
			for (int i = 0; i < wave.Length; i++)
			{
				if (wave[i] > max)
				{
					max = wave[i];
				}
				if (wave[i] < min)
				{
					min = wave[i];
				}
			}
			return max - min;
		}

		public static float getRMS(float[] wave)
		{
			float rms = 0;
			for (int i = 0; i < wave.Length; i++)
			{
				rms += wave[i] * wave[i];
			}
			rms = (float)Math.Sqrt(rms / wave.Length);
			return float.IsNaN(rms) ? 0 : rms;
		}

		public static float getAvg(float[] wave)
		{
			float avg = 0;
			for (int i = 0; i < wave.Length; i++)
			{
				avg += wave[i];
			}
			avg = avg / wave.Length;
			return float.IsNaN(avg) ? 0 : avg;
		}

		public static float getS(float tower_high, float avg)
		{
			return tower_high * 1000 * 0.75f * (float)Math.Tan(avg * Math.PI / 180);
		}

		public static float getPhaseP(float[] xwave, float[] ywave, float[] dipwave)
		{
			float max = 0;
			int imax = 0;
			for (int i = 0; i < dipwave.Length; i++)
			{
				if (Math.Abs(dipwave[i]) > max)
				{
					max = Math.Abs(dipwave[i]);
					imax = i;
				}
			}
			return (float)(Math.Atan2(xwave[imax], ywave[imax]) * 180 / Math.PI);
		}



		public static float getPhaseAvg(float avg_x, float avg_y)
		{
			return (float)(Math.Atan2(avg_y, avg_x) * 180 / Math.PI);
		}

		public static float getSettle(float diameter, float dip_avg)
		{
			return (float)(diameter * Math.Sin(dip_avg * Math.PI / 180));
		}
		public static float getK(float[] wave)
		{
			float k = 0;

			float avg = 0;
			for (int i = 0; i < wave.Length; i++)
			{
				avg += wave[i];
			}
			avg /= wave.Length;

			float m4 = 0;
			for (int i = 0; i < wave.Length; i++)
			{
				m4 += (float)Math.Pow(wave[i] - avg, 4);
			}
			m4 /= wave.Length;

			float m2 = 0;
			for (int i = 0; i < wave.Length; i++)
			{
				m2 += (float)Math.Pow(wave[i] - avg, 2);
			}
			m2 /= wave.Length;

			k = m4 / (float)Math.Pow(m2, 2);
			return float.IsNaN(k) ? 0 : k;
		}

		public static float getCF(float[] wave)
		{
			float cf = 0;
			float max = 0;
			float xr = 0;
			for (int i = 0; i < wave.Length; i++)
			{
				if (Math.Abs(wave[i]) > max)
				{
					max = Math.Abs(wave[i]);
				}
				xr += (float)Math.Sqrt(Math.Abs(wave[i]));

			}
			xr = (float)Math.Pow(xr / wave.Length, 2);
			cf = max / xr;
			return float.IsNaN(cf) ? 0 : cf;
		}

		public static float getSF(float[] wave)
		{
			float sf = 0;
			float total_sf = 0;
			for (int i = 0; i < wave.Length; i++)
			{
				total_sf += wave[i] * wave[i] * wave[i];
			}
			if (total_sf == 0)
			{
				return 0;
			}
			sf = total_sf / wave.Length;
			return float.IsNaN(sf) ? 0 : sf;
		}


		public static float[] ToFloat(byte[] bytes)
		{
			float[] floats = new float[bytes.Length / 4];
			for (int i = 0; i < bytes.Length; i += 4)
			{
				floats[i / 4] = BitConverter.ToSingle(bytes.AsSpan()[i..(i + 4)]);
			}
			return floats;
		}
	}
}
