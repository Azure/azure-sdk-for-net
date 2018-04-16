
using System;
using System.Collections.Generic;
using System.Linq;

internal static partial class SdkInfo
{
    public static IEnumerable<Tuple<string, string, string>> ApiInfo_BatchAI
    {
        get
        {
            return new Tuple<string, string, string>[]
            {
                new Tuple<string, string, string>("BatchAI", "Clusters", "2018-03-01"),
                new Tuple<string, string, string>("BatchAI", "FileServers", "2018-03-01"),
                new Tuple<string, string, string>("BatchAI", "Jobs", "2018-03-01"),
                new Tuple<string, string, string>("BatchAI", "Operations", "2018-03-01"),
                new Tuple<string, string, string>("BatchAI", "Usage", "2018-03-01"),
            }.AsEnumerable();
        }
    }
}
