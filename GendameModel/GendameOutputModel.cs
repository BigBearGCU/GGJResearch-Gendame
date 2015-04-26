using System;
using System.Collections.Generic;
using System.Text;

namespace GendameModel
{

	public class GendameTarget
	{
		public enum Severity
		{
			Critical,
			High,
			Medium,
			Low,
			Audit,
		}

		public enum Confidence
		{
			Total,
			High,
			Normal,
			Low,
		}
		public string TargetName{get;set;}
		public string AssemblyName{ get; set;}
		public Severity ProblemSeverity{ get; set;}
		public Confidence ProblemConfidence{ get; set;}
		public string Location{get;set;}
		public string Source{ get; set;}
		public string Description{ get; set; }

		public override string ToString ()
		{
			return string.Format ("[GendameTarget: TargetName={0}, AssemblyName={1}, ProblemSeverity={2}, ProblemConfidence={3}, Location={4}, Source={5}, Description={6}]", TargetName, AssemblyName, ProblemSeverity, ProblemConfidence, Location, Source, Description);
		}

	}

	public class GendameRule
	{
		public string Name{ get; set;}
		public string Description{ get; set;}
		public string URL{get;set;}
		public string Solution{ get; set;}
		public List<GendameTarget> Targets{ get; set; }

		public GendameRule()
		{
			Targets = new List<GendameTarget> ();
		}

        public GendameRule(GendameRule rule)
        {
            Name = rule.Name;
            Description = rule.Description;
            URL = rule.URL;
            Solution = rule.Solution;
            Targets = new List<GendameTarget>(rule.Targets);
        }

		public override string ToString ()
		{
			StringBuilder sb = new StringBuilder ();
			sb.AppendLine(string.Format ("[GendameRule: Name={0}, Description={1}, URL={2}, Solution={3}]", Name, Description, URL, Solution));
			foreach (GendameTarget t in Targets) {
				sb.AppendLine (string.Format (t.ToString ()));
			}

			return sb.ToString ();
		}
	}


}

