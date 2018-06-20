
using System;
using System.Collections.Generic;
using System.Linq;

internal static partial class SdkInfo
{
    public static IEnumerable<Tuple<string, string, string>> ApiInfo_SearchIndexClient
    {
        get
        {
            return new Tuple<string, string, string>[]
            {
                new Tuple<string, string, string>("SearchIndexClient", "DocumentsProxy", "2017-11-11"),
            }.AsEnumerable();
        }
    }
}
