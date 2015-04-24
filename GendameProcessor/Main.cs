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
				Console.WriteLine ("Rule Name {0}", rule.Name);
				Console.WriteLine ("Rule URI {0}", rule.URL);
				Console.WriteLine ("Rule Problem {0}", rule.Description);
				foreach (GendameTarget target in rule.Targets) {
					Console.WriteLine ("Tagert Name {0}", target.TargetName);
					Console.WriteLine ("Tagert Severity {0}", target.ProblemSeverity.ToString ());
				}
			}

			Console.ReadLine ();
		}
	}
}
