using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;

public class EmbeddedAssembly
{
	private static Dictionary<string, Assembly> dic;

	public static void Load(string embeddedResource, string fileName)
	{
		if (dic == null)
		{
			dic = new Dictionary<string, Assembly>();
		}
		byte[] array = null;
		using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(embeddedResource))
		{
			if (stream == null)
			{
				throw new Exception(embeddedResource + " is not found in Embedded Resources.");
			}
			array = new byte[(int)stream.Length];
			stream.Read(array, 0, (int)stream.Length);
			try
			{
				Assembly assembly = Assembly.Load(array);
				dic.Add(assembly.FullName, assembly);
				return;
			}
			catch
			{
			}
		}
		bool flag = false;
		string path = "";
		using (SHA1CryptoServiceProvider sHA1CryptoServiceProvider = new SHA1CryptoServiceProvider())
		{
			string text = BitConverter.ToString(sHA1CryptoServiceProvider.ComputeHash(array)).Replace("-", string.Empty);
			path = Path.GetTempPath() + fileName;
			if (File.Exists(path))
			{
				byte[] buffer = File.ReadAllBytes(path);
				string text2 = BitConverter.ToString(sHA1CryptoServiceProvider.ComputeHash(buffer)).Replace("-", string.Empty);
				flag = text == text2;
			}
			else
			{
				flag = false;
			}
		}
		if (!flag)
		{
			File.WriteAllBytes(path, array);
		}
		Assembly assembly2 = Assembly.LoadFile(path);
		dic.Add(assembly2.FullName, assembly2);
	}

	public static Assembly Get(string assemblyFullName)
	{
		if (dic == null || dic.Count == 0)
		{
			return null;
		}
		if (!dic.ContainsKey(assemblyFullName))
		{
			return null;
		}
		return dic[assemblyFullName];
	}
}
