
using System;
using System.Collections.Generic;
using System.Linq;

internal static partial class SdkInfo
{
    public static IEnumerable<Tuple<string, string, string>> ApiInfo_SubscriptionClient
    {
        get
        {
            return new Tuple<string, string, string>[]
            {
                new Tuple<string, string, string>("Billing", "SubscriptionFactory", "2018-03-01-preview"),
                new Tuple<string, string, string>("Subscription", "Operations", "2018-03-01-preview"),
                new Tuple<string, string, string>("Subscription", "SubscriptionOperations", "2018-03-01-preview"),
                new Tuple<string, string, string>("SubscriptionClient", "Subscriptions", "2016-06-01"),
                new Tuple<string, string, string>("SubscriptionClient", "Tenants", "2016-06-01"),
            }.AsEnumerable();
        }
    }
}
