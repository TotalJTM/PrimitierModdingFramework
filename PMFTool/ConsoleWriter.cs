﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMFTool
{
	public static class ConsoleWriter
	{

		public static void WriteLineStatus(string value)
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("STATUS: " + value);
			Console.ForegroundColor = ConsoleColor.White;
		}

		public static void WriteLineError(string value, Exception? e=null)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("ERROR: "+value);
			
			if (e != null)
			{
				Console.WriteLine();
				Console.WriteLine("INTERNAL_ERROR: " + e.ToString());
			}
			Console.ForegroundColor = ConsoleColor.White;
		}
	}
}
