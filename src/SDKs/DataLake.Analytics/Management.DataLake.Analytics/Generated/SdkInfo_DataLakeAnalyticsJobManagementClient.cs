
using System;
using System.Collections.Generic;
using System.Linq;

internal static partial class SdkInfo
{
    public static IEnumerable<Tuple<string, string, string>> ApiInfo_DataLakeAnalyticsJobManagementClient
    {
        get
        {
            return new Tuple<string, string, string>[]
            {
                new Tuple<string, string, string>("DataLakeAnalyticsJobManagementClient", "Job", "2017-09-01-preview"),
                new Tuple<string, string, string>("DataLakeAnalyticsJobManagementClient", "Pipeline", "2017-09-01-preview"),
                new Tuple<string, string, string>("DataLakeAnalyticsJobManagementClient", "Recurrence", "2017-09-01-preview"),
            }.AsEnumerable();
        }
    }
}
