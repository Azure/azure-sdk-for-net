
using System;
using System.Collections.Generic;
using System.Linq;

internal static partial class SdkInfo
{
    public static IEnumerable<Tuple<string, string, string>> ApiInfo_DataLakeAnalyticsAccountManagementClient
    {
        get
        {
            return new Tuple<string, string, string>[]
            {
                new Tuple<string, string, string>("DataLakeAnalytics", "Account", "2016-11-01"),
                new Tuple<string, string, string>("DataLakeAnalytics", "ComputePolicies", "2016-11-01"),
                new Tuple<string, string, string>("DataLakeAnalytics", "DataLakeStoreAccounts", "2016-11-01"),
                new Tuple<string, string, string>("DataLakeAnalytics", "FirewallRules", "2016-11-01"),
                new Tuple<string, string, string>("DataLakeAnalytics", "Locations", "2016-11-01"),
                new Tuple<string, string, string>("DataLakeAnalytics", "Operations", "2016-11-01"),
                new Tuple<string, string, string>("DataLakeAnalytics", "StorageAccounts", "2016-11-01"),
            }.AsEnumerable();
        }
    }
}
