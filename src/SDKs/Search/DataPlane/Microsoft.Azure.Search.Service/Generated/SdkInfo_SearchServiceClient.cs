
using System;
using System.Collections.Generic;
using System.Linq;

internal static partial class SdkInfo
{
    public static IEnumerable<Tuple<string, string, string>> ApiInfo_SearchServiceClient
    {
        get
        {
            return new Tuple<string, string, string>[]
            {
                new Tuple<string, string, string>("SearchServiceClient", "DataSources", "2016-09-01-Preview"),
                new Tuple<string, string, string>("SearchServiceClient", "Indexers", "2016-09-01-Preview"),
                new Tuple<string, string, string>("SearchServiceClient", "Indexes", "2016-09-01-Preview"),
                new Tuple<string, string, string>("SearchServiceClient", "SynonymMaps", "2016-09-01-Preview"),
            }.AsEnumerable();
        }
    }
}
