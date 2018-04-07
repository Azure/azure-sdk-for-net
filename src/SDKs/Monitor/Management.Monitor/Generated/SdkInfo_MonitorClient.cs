
using System;
using System.Collections.Generic;
using System.Linq;

internal static partial class SdkInfo
{
    public static IEnumerable<Tuple<string, string, string>> ApiInfo_MonitorClient
    {
        get
        {
            return new Tuple<string, string, string>[]
            {
                new Tuple<string, string, string>("insights", "ActionGroups", "2017-04-01"),
                new Tuple<string, string, string>("insights", "ActivityLogAlerts", "2017-04-01"),
                new Tuple<string, string, string>("insights", "ActivityLogs", "2015-04-01"),
                new Tuple<string, string, string>("insights", "AlertRuleIncidents", "2016-03-01"),
                new Tuple<string, string, string>("insights", "AlertRules", "2016-03-01"),
                new Tuple<string, string, string>("insights", "AutoscaleSettings", "2015-04-01"),
                new Tuple<string, string, string>("insights", "DiagnosticSettings", "2017-05-01-preview"),
                new Tuple<string, string, string>("insights", "DiagnosticSettingsCategory", "2017-05-01-preview"),
                new Tuple<string, string, string>("insights", "EventCategories", "2015-04-01"),
                new Tuple<string, string, string>("insights", "LogProfiles", "2016-03-01"),
                new Tuple<string, string, string>("insights", "MetricBaseline", "2017-11-01-preview"),
                new Tuple<string, string, string>("insights", "MetricDefinitions", "2018-01-01"),
                new Tuple<string, string, string>("insights", "Metrics", "2018-01-01"),
                new Tuple<string, string, string>("insights", "Operations", "2015-04-01"),
                new Tuple<string, string, string>("insights", "TenantActivityLogs", "2015-04-01"),
            }.AsEnumerable();
        }
    }
}
