
using System;
using System.Collections.Generic;
using System.Linq;

internal static partial class SdkInfo
{
    public static IEnumerable<Tuple<string, string, string>> ApiInfo_SubscriptionsManagementClient
    {
        get
        {
            return new Tuple<string, string, string>[]
            {
                new Tuple<string, string, string>("Subscriptions", "Operations", "2015-11-01"),
                new Tuple<string, string, string>("SubscriptionsManagementClient", "DelegatedProviderOffers", "2015-11-01"),
                new Tuple<string, string, string>("SubscriptionsManagementClient", "Offers", "2015-11-01"),
                new Tuple<string, string, string>("SubscriptionsManagementClient", "Subscriptions", "2015-11-01"),
            }.AsEnumerable();
        }
    }
}
