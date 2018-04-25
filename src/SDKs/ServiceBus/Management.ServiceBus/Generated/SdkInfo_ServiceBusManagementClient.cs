
using System;
using System.Collections.Generic;
using System.Linq;

internal static partial class SdkInfo
{
    public static IEnumerable<Tuple<string, string, string>> ApiInfo_ServiceBusManagementClient
    {
        get
        {
            return new Tuple<string, string, string>[]
            {
                new Tuple<string, string, string>("ServiceBus", "DisasterRecoveryConfigs", "2017-04-01"),
                new Tuple<string, string, string>("ServiceBus", "EventHubs", "2017-04-01"),
                new Tuple<string, string, string>("ServiceBus", "Namespaces", "2017-04-01"),
                new Tuple<string, string, string>("ServiceBus", "Operations", "2017-04-01"),
                new Tuple<string, string, string>("ServiceBus", "PremiumMessagingRegions", "2017-04-01"),
                new Tuple<string, string, string>("ServiceBus", "Queues", "2017-04-01"),
                new Tuple<string, string, string>("ServiceBus", "Regions", "2017-04-01"),
                new Tuple<string, string, string>("ServiceBus", "Rules", "2017-04-01"),
                new Tuple<string, string, string>("ServiceBus", "Subscriptions", "2017-04-01"),
                new Tuple<string, string, string>("ServiceBus", "Topics", "2017-04-01"),
            }.AsEnumerable();
        }
    }
}
