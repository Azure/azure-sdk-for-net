
using System;
using System.Collections.Generic;
using System.Linq;

internal static partial class SdkInfo
{
    public static IEnumerable<Tuple<string, string, string>> ApiInfo_EventHubManagementClient
    {
        get
        {
            return new Tuple<string, string, string>[]
            {
                new Tuple<string, string, string>("EventHub", "ConsumerGroups", "2017-04-01"),
                new Tuple<string, string, string>("EventHub", "DisasterRecoveryConfigs", "2017-04-01"),
                new Tuple<string, string, string>("EventHub", "EventHubs", "2017-04-01"),
                new Tuple<string, string, string>("EventHub", "Namespaces", "2017-04-01"),
                new Tuple<string, string, string>("EventHub", "Operations", "2017-04-01"),
            }.AsEnumerable();
        }
    }
}
