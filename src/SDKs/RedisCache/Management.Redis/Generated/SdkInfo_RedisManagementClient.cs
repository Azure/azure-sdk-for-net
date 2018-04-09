
using System;
using System.Collections.Generic;
using System.Linq;

internal static partial class SdkInfo
{
    public static IEnumerable<Tuple<string, string, string>> ApiInfo_RedisManagementClient
    {
        get
        {
            return new Tuple<string, string, string>[]
            {
                new Tuple<string, string, string>("Cache", "FirewallRules", "2017-10-01"),
                new Tuple<string, string, string>("Cache", "LinkedServer", "2017-10-01"),
                new Tuple<string, string, string>("Cache", "Operations", "2017-10-01"),
                new Tuple<string, string, string>("Cache", "PatchSchedules", "2017-10-01"),
                new Tuple<string, string, string>("Cache", "Redis", "2017-10-01"),
            }.AsEnumerable();
        }
    }
}
