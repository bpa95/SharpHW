using System;
using System.Text.RegularExpressions;
using System.IO;
using System.Collections.Generic;

namespace LineCounting
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			if (!checkArgs (args)) {
				printUsage ();
				return;
			}

			string path = args [0];

			Queue<string> dirs = new Queue<string> ();
			dirs.Enqueue (path);

			int lines = 0;
			string curDir;
			while (dirs.Count > 0) {
				curDir = dirs.Dequeue ();
				foreach (string dir in Directory.GetDirectories(curDir)) {
					dirs.Enqueue (dir);
				}
				Regex isCs = new Regex (@".*.cs$");
				foreach (string file in Directory.GetFiles(curDir)) {
					if (isCs.IsMatch (file)) {
						lines += countLines (file);
						Console.WriteLine (file + " " + lines);
					}
				}
			}

			Console.WriteLine ("Total amount of lines: " + lines);
		}

		static int countLines(string file) {
			FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read);
			StreamReader sr = new StreamReader(fs);
			Regex isComment = new Regex (@"^\s*\/\/.*$");
			Regex isEmpty = new Regex (@"^\s*$");
			int lines = 0;
			while (!sr.EndOfStream) {                
				string line = sr.ReadLine ();
				if (isComment.IsMatch (line) || isEmpty.IsMatch (line)) {
					continue;
				}
				lines++;
			}
			return lines;
		}

		static bool checkArgs(string[] args) {
			return !(args == null || args.Length != 1 || args[0] == null || !Directory.Exists(args[0]));
		}

		static void printUsage() {
			Console.WriteLine ("usage: LineCounting dir");
		}

	}
}
