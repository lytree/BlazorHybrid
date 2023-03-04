namespace Wave.Tool.Test
{
	public class UnitTest1
	{
		[Fact]
		public void Test1()
		{
			var data = SQLite.ReadTMSSQLite(@"D:\��������������������Ʒ�糡\CMSDATA\TOWERDATA\��������������������Ʒ�糡\2023-01\10000001\2023-01-01\��������������������Ʒ�糡_10000001_2023-01-01-00-00-01-554.tms");

			foreach (var item in data)
			{
				var floats = WaveUtils.ToFloat(item.wave);
				Console.WriteLine(floats);
			}
			Console.WriteLine(data);
		}
	}
}