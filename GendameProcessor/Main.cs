using System;
using System.Collections.Generic;

using GendameXMLParser;
using GendameModel;

namespace GendameProcessor
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			//TODO: 1) Add filters
			//TODO: 2) Add Export to CSV file
			Parser parser = new Parser ();
			List<GendameRule> rules = parser.LoadFromXML (args [0]);
			foreach (GendameRule rule in rules) {
				Console.WriteLine (rule.ToString ());
			}

			Console.ReadLine ();
		}
	}
}
