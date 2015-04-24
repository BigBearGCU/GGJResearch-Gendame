using System;
using System.Collections.Generic;
using GendameModel;
using System.Xml;
using System.Xml.Linq;
using System.Linq;

namespace GendameXMLParser
{
	public class Parser
	{
		
		public Parser ()
		{
		}

		public List<GendameRule> LoadFromXML(string filename)
		{
			List<GendameRule> models = new List<GendameRule> ();

			XDocument doc = XDocument.Load (new XmlTextReader (filename));

			models = (from e in doc.Root.Element("results").Descendants("rule")
				select new GendameRule {
					Name = (string)e.Attribute ("Name"),
					URL=(string)e.Attribute("Uri"),
					Description=(string)e.Element("problem").Value,
					Solution=(string)e.Element("solution").Value,
					Targets=e.Elements("target")
						.Select(r => new GendameTarget{
							TargetName=(string)r.Attribute("Name"),
							AssemblyName=(string)r.Attribute("Assembly"),
							ProblemSeverity=(GendameTarget.Severity)Enum.Parse(typeof(GendameTarget.Severity),(string)r.Element("defect").Attribute("Severity")),
							ProblemConfidence=(GendameTarget.Confidence)Enum.Parse(typeof(GendameTarget.Confidence),(string)r.Element("defect").Attribute("Confidence")),
							Location=(string)r.Element("defect").Attribute("Location"),
							Source=(string)r.Element("defect").Attribute("Source"),
							Description=(string)r.Element("defect").Value
						}).ToList()
				}).ToList();


			return models;
		}
	}
}

