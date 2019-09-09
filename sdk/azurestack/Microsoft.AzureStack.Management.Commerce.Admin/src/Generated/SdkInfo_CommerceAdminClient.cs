
using System;
using System.Collections.Generic;
using System.Linq;

internal static partial class SdkInfo
{
    public static IEnumerable<Tuple<string, string, string>> ApiInfo_CommerceAdminClient
    {
        get
        {
            return new Tuple<string, string, string>[]
            {
                new Tuple<string, string, string>("Commerce.Admin", "Operations", "2015-06-01-preview"),
                new Tuple<string, string, string>("Commerce.Admin", "SubscriberUsageAggregates", "2015-06-01-preview"),
                new Tuple<string, string, string>("Commerce.Admin", "UpdateEncryption", "2015-06-01-preview"),
            }.AsEnumerable();
        }
    }
}
