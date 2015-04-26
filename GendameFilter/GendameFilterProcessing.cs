using GendameModel;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GendameFilter
{
    public class GendameFilterProcessing
    {
        private List<GendameFilter> filters;

        public GendameFilterProcessing()
        {
            filters = new List<GendameFilter>();
        }

        public void AddFilter(GendameFilter filter)
        {
            filters.Add(filter);
        }

        public IEnumerable<GendameRule> processFilters(List<GendameRule> rules)
        {
            ConcurrentBag<GendameRule> processingList = new ConcurrentBag<GendameRule>(rules);
            ConcurrentBag<GendameRule> results = new ConcurrentBag<GendameRule>();
            foreach(GendameFilter filter in filters)
            {
                Parallel.ForEach(processingList, result =>
                    {
                        GendameRule currentRule = new GendameRule(result);
                        currentRule.Targets.Clear();
                        

                        foreach (GendameTarget target in result.Targets)
                        {
                            PropertyInfo property = target.GetType().GetProperty(filter.FilterField);
                            string fieldValue = ((string)(property.GetValue(target))).ToLower();
                            if (!fieldValue.Contains(filter.FilterValue.ToLower()))
                            {
                                currentRule.Targets.Add(target);
                            }
                        }

                        results.Add(currentRule);
                    });
            }
            return results;
        }
    }
}
