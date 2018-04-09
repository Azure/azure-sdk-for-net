
using System;
using System.Collections.Generic;
using System.Linq;

internal static partial class SdkInfo
{
    public static IEnumerable<Tuple<string, string, string>> ApiInfo_PolicyInsightsClient
    {
        get
        {
            return new Tuple<string, string, string>[]
            {
                new Tuple<string, string, string>("PolicyInsights", "Operations", "2017-12-12-preview"),
                new Tuple<string, string, string>("PolicyInsights", "PolicyEvents", "2017-12-12-preview"),
                new Tuple<string, string, string>("PolicyInsights", "PolicyStates", "2017-12-12-preview"),
            }.AsEnumerable();
        }
    }
}
