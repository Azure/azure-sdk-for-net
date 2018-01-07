
using System;
using System.Collections.Generic;
using System.Linq;

internal static partial class SdkInfo
{
    public static IEnumerable<Tuple<string, string, string>> ApiInfo_ManagementGroupsAPI
    {
        get
        {
            return new Tuple<string, string, string>[]
            {
                new Tuple<string, string, string>("Management", "ManagementGroups", "2017-08-31-preview"),
                new Tuple<string, string, string>("Management", "Operations", "2017-08-31-preview"),
            }.AsEnumerable();
        }
    }
}
