using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorUtils;

public class SQLiteFile
{
	public static List<string> GetFiles(string directory, string pattern = "*.*")
	{
		List<string> files = new List<string>();
		foreach (var item in Directory.GetFiles(directory, pattern))
		{
			files.Add(item);
		}
		foreach (var item in Directory.GetDirectories(directory))
		{
			files.AddRange(GetFiles(item, pattern));
		}
		return files;
	}
}

