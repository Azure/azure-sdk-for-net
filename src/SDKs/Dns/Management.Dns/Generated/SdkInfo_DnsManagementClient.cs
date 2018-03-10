
using System;
using System.Collections.Generic;
using System.Linq;

internal static partial class SdkInfo
{
    public static IEnumerable<Tuple<string, string, string>> ApiInfo_DnsManagementClient
    {
        get
        {
            return new Tuple<string, string, string>[]
            {
                new Tuple<string, string, string>("Network", "RecordSets", "2017-10-01"),
                new Tuple<string, string, string>("Network", "Zones", "2017-10-01"),
            }.AsEnumerable();
        }
    }
}
