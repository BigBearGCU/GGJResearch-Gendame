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
            export.export("text.csv", filterRules);
			Console.ReadLine ();
		}
	}
}
