
using System;
using System.Collections.Generic;
using System.Linq;

internal static partial class SdkInfo
{
    public static IEnumerable<Tuple<string, string, string>> ApiInfo_ManagementLinkClient
    {
        get
        {
            return new Tuple<string, string, string>[]
            {
                new Tuple<string, string, string>("ManagementLinkClient", "ResourceLinks", "2016-09-01"),
                new Tuple<string, string, string>("Resources", "ResourceLinks", "2016-09-01"),
            }.AsEnumerable();
        }
    }
}
