
using System;
using System.Collections.Generic;
using System.Linq;

internal static partial class SdkInfo
{
    public static IEnumerable<Tuple<string, string, string>> ApiInfo_AzureAnalysisServices
    {
        get
        {
            return new Tuple<string, string, string>[]
            {
                new Tuple<string, string, string>("AnalysisServices", "Operations", "2017-08-01"),
                new Tuple<string, string, string>("AnalysisServices", "Servers", "2017-08-01"),
            }.AsEnumerable();
        }
    }
}
