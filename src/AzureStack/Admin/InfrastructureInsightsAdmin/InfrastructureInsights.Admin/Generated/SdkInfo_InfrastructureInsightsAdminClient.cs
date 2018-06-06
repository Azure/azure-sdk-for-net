
using System;
using System.Collections.Generic;
using System.Linq;

internal static partial class SdkInfo
{
    public static IEnumerable<Tuple<string, string, string>> ApiInfo_InfrastructureInsightsAdminClient
    {
        get
        {
            return new Tuple<string, string, string>[]
            {
                new Tuple<string, string, string>("InfrastructureInsights.Admin", "Alerts", "2016-05-01"),
                new Tuple<string, string, string>("InfrastructureInsights.Admin", "Operations", "2016-05-01"),
                new Tuple<string, string, string>("InfrastructureInsights.Admin", "RegionHealths", "2016-05-01"),
                new Tuple<string, string, string>("InfrastructureInsights.Admin", "ResourceHealths", "2016-05-01"),
                new Tuple<string, string, string>("InfrastructureInsights.Admin", "ServiceHealths", "2016-05-01"),
            }.AsEnumerable();
        }
    }
}
