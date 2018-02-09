
using System;
using System.Collections.Generic;
using System.Linq;

internal static partial class SdkInfo
{
    public static IEnumerable<Tuple<string, string, string>> ApiInfo_PolicyClient
    {
        get
        {
            return new Tuple<string, string, string>[]
            {
                new Tuple<string, string, string>("Authorization", "PolicyAssignments", "2017-06-01-preview"),
                new Tuple<string, string, string>("Authorization", "PolicyDefinitions", "2016-12-01"),
                new Tuple<string, string, string>("Authorization", "PolicySetDefinitions", "2017-06-01-preview"),
                new Tuple<string, string, string>("Management", "PolicyDefinitions", "2016-12-01"),
                new Tuple<string, string, string>("Management", "PolicySetDefinitions", "2017-06-01-preview"),
                new Tuple<string, string, string>("PolicyClient", "PolicyAssignments", "2017-06-01-preview"),
            }.AsEnumerable();
        }
    }
}
