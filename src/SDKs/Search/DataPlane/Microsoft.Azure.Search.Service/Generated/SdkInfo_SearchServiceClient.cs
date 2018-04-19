
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
                new Tuple<string, string, string>("SearchServiceClient", "DataSources", "2017-11-11"),
                new Tuple<string, string, string>("SearchServiceClient", "GetServiceStatistics", "2017-11-11"),
                new Tuple<string, string, string>("SearchServiceClient", "Indexers", "2017-11-11"),
                new Tuple<string, string, string>("SearchServiceClient", "Indexes", "2017-11-11"),
                new Tuple<string, string, string>("SearchServiceClient", "SynonymMaps", "2017-11-11"),
            }.AsEnumerable();
        }
    }
}
