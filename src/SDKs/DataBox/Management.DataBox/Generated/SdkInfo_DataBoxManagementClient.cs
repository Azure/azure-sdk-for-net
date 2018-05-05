
using System;
using System.Collections.Generic;
using System.Linq;

internal static partial class SdkInfo
{
    public static IEnumerable<Tuple<string, string, string>> ApiInfo_DataBoxManagementClient
    {
        get
        {
            return new Tuple<string, string, string>[]
            {
                new Tuple<string, string, string>("DataBox", "Jobs", "2018-01-01"),
                new Tuple<string, string, string>("DataBox", "Operations", "2018-01-01"),
                new Tuple<string, string, string>("DataBox", "Service", "2018-01-01"),
            }.AsEnumerable();
        }
    }
}
