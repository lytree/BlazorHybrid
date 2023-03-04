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
		public static byte[] GetWaveByFloat(float[] floats, float speed, float freq, int cycles, int samples)
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
		public static float[] ToFloat(byte[] bytes)
		{
			float[] floats = new float[bytes.Length / 4];
			for (int i = 0; i < bytes.Length; i += 4)
			{	
				 floats[i / 4] = BitConverter.ToSingle(bytes.AsSpan()[i..(i+4)]);
			}
			return floats;
		}
	}
}
