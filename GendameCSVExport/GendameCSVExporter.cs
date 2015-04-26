using GendameModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GendameCSVExport
{
    public class GendameCSVExporter
    {
        public static string Header = "Rule,Count";

        public void export(string filename,IEnumerable<GendameRule> rules)
        {
            using(TextWriter tw = File.CreateText(filename))
            {
                tw.WriteLine(GendameCSVExporter.Header);
                foreach(GendameRule rule in rules)
                {
                    tw.WriteLine(string.Format("{0},{1}", rule.Name, rule.Targets.Count));
                }
            }

        }
    }
}
