
using System;
using System.Collections.Generic;
using System.Linq;

internal static partial class SdkInfo
{
    public static IEnumerable<Tuple<string, string, string>> ApiInfo_UpdateAdminClient
    {
        get
        {
            return new Tuple<string, string, string>[]
            {
                new Tuple<string, string, string>("Update.Admin", "UpdateLocations", "2016-05-01"),
                new Tuple<string, string, string>("Update.Admin", "UpdateRuns", "2016-05-01"),
                new Tuple<string, string, string>("Update.Admin", "Updates", "2016-05-01"),
            }.AsEnumerable();
        }
    }
}
