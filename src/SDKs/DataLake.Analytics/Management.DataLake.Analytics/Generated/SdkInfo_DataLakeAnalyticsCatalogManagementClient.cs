
using System;
using System.Collections.Generic;
using System.Linq;

internal static partial class SdkInfo
{
    public static IEnumerable<Tuple<string, string, string>> ApiInfo_DataLakeAnalyticsCatalogManagementClient
    {
        get
        {
            return new Tuple<string, string, string>[]
            {
                new Tuple<string, string, string>("DataLakeAnalyticsCatalogManagementClient", "Catalog", "2016-11-01"),
            }.AsEnumerable();
        }
    }
}
