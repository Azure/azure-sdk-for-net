
using System;
using System.Collections.Generic;
using System.Linq;

internal static partial class SdkInfo
{
    public static IEnumerable<Tuple<string, string, string>> ApiInfo_ApplicationInsightsDataClient
    {
        get
        {
            return new Tuple<string, string, string>[]
            {
                new Tuple<string, string, string>("ApplicationInsightsDataClient", "GetEvent", "v1"),
                new Tuple<string, string, string>("ApplicationInsightsDataClient", "GetEvents", "v1"),
                new Tuple<string, string, string>("ApplicationInsightsDataClient", "GetEventsMetadataOData", "v1"),
                new Tuple<string, string, string>("ApplicationInsightsDataClient", "GetMetric", "v1"),
                new Tuple<string, string, string>("ApplicationInsightsDataClient", "GetMetrics", "v1"),
                new Tuple<string, string, string>("ApplicationInsightsDataClient", "GetMetricsMetadata", "v1"),
                new Tuple<string, string, string>("ApplicationInsightsDataClient", "GetQuerySchema", "v1"),
                new Tuple<string, string, string>("ApplicationInsightsDataClient", "Query", "v1"),
            }.AsEnumerable();
        }
    }
}
