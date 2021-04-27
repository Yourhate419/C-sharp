using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace RGZ
{
	static class Fileprocessing
	{
		private static ArrayList list = new ArrayList();

		public static void Create_Input_File(int c, string path)
		{
			ArrayList data = new ArrayList();

			if (c == 1)
			{
				return;
			}

			else if (c == 2)
			{
				Random rnd = new Random();
				for (int i = 0; i < 20; i++)
				{
					float value = (float)rnd.NextDouble();
					data.Add(value);
				}
			}
			else if (c == 3)
			{
				string[] s = Console.ReadLine().Split(' ');
				foreach (var i in s)
					data.Add(i);
			}

			try
			{
				StreamWriter f = new StreamWriter(@path);
				foreach (var i in data)
					f.WriteLine(i);

				f.Close();
				data.Clear();
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}


		public static void Read_File(int c)
		{

			string path = "input" + Convert.ToString(c) + ".txt";

			Create_Input_File(c, path);

			try
			{
				{
					StreamReader f = new StreamReader(@path);


					for (int i = 0; i < 20; i++)
					{
						list.Add((float)Convert.ToDouble(f.ReadLine()));
					}
					f.Close();
				}
			}
			catch (Exception e)
			{
				Console.WriteLine("check the file path");
				Console.WriteLine(e.Message);
			}

			Sort_and_write_Data_To_File(c);
		}

		public static void Sort_and_write_Data_To_File(int c)
		{
			list.Sort();

			try
			{
				string path = "output" + Convert.ToString(c) + ".txt";
				StreamWriter f = new StreamWriter(@path);

				for (int i = 0; i < 20; i++)
				{
					f.WriteLine(list[i]);
				}
				list.Clear();
				f.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}

		}
	}
	class Program
	{
		static void Main(string[] args)
		{
			for (int i = 1; i <= 3; i++)
			{
				Fileprocessing.Read_File(i);
			}
		}
	}
}
