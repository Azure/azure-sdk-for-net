
using System;
using System.Collections.Generic;
using System.Linq;

internal static partial class SdkInfo
{
    public static IEnumerable<Tuple<string, string, string>> ApiInfo_PostgreSQLManagementClient
    {
        get
        {
            return new Tuple<string, string, string>[]
            {
                new Tuple<string, string, string>("DBforPostgreSQL", "CheckNameAvailability", "2017-12-01"),
                new Tuple<string, string, string>("DBforPostgreSQL", "Configurations", "2017-12-01"),
                new Tuple<string, string, string>("DBforPostgreSQL", "Databases", "2017-12-01"),
                new Tuple<string, string, string>("DBforPostgreSQL", "FirewallRules", "2017-12-01"),
                new Tuple<string, string, string>("DBforPostgreSQL", "LocationBasedPerformanceTier", "2017-12-01"),
                new Tuple<string, string, string>("DBforPostgreSQL", "LogFiles", "2017-12-01"),
                new Tuple<string, string, string>("DBforPostgreSQL", "Operations", "2017-12-01"),
                new Tuple<string, string, string>("DBforPostgreSQL", "Servers", "2017-12-01"),
            }.AsEnumerable();
        }
    }
}
