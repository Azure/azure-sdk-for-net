using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSites.Tests.Helpers
{
    public static class WebSitesHelper
    {
        public static string BuildMetricFilter(DateTimeOffset startTime, DateTimeOffset endTime, string timeGrain, List<string> metricNames)
        {
            var dateTimeFormat = "yyyy-MM-ddTHH:mm:ssZ";
            var filter = "";
            if (metricNames != null && metricNames.Count > 0)
            {
                if (metricNames.Count == 1)
                {
                    filter = "name.value eq '" + metricNames[0] + "' and ";
                }
                else
                {
                    filter = "(name.value eq '" + string.Join("' or name.value eq '", metricNames) + "') and ";
                }
            }

            filter += string.Format("startTime eq {0} and endTime eq {1} and timeGrain eq duration'{2}'", startTime.ToString(dateTimeFormat), endTime.ToString(dateTimeFormat), timeGrain);

            return filter;
        }
    }
}
