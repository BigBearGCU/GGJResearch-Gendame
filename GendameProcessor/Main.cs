using System;
using System.Collections.Generic;

using GendameXMLParser;
using GendameModel;
using GendameFilter;
using GendameCSVExport;

namespace GendameProcessor
{
	class MainClass
	{
		public static void Main (string[] args)
		{

			//get no args
			int argCount=args.Length;
            string outputFilename = args[0].Split('.')[0]+".csv";
			if (argCount < 1) {
				Console.WriteLine ("No arguments, use GendameProcessor - h to for help");
			}
			//TODO: 1) Add filters
            GendameFilterProcessing filters = new GendameFilterProcessing();
            filters.AddFilter(new GendameFilter.GendameFilter { FilterField = "Location", FilterValue = "iTween" });
			Parser parser = new Parser ();
			List<GendameRule> rules = parser.LoadFromXML (args [0]);
            List<GendameRule> filterRules=new List<GendameRule>(filters.processFilters(rules));
			foreach (GendameRule rule in filterRules) {
				Console.WriteLine (rule.ToString ());
			}

            GendameCSVExporter export = new GendameCSVExporter();
            export.export(outputFilename, filterRules);
			Console.ReadLine ();
		}

		void ProcessCommands(string[] args)
		{
			if (args [0].Equals ("-h")) {
				DisplayHelp ();
			}
		}

		void DisplayHelp()
		{
			string helpMsg = "";
			Console.WriteLine (helpMsg);
		}
	}
}
