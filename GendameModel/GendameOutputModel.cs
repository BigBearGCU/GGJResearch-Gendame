using System;
using System.Collections.Generic;

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
	}


}

