
using System;
using System.Collections.Generic;
using System.Linq;

internal static partial class SdkInfo
{
    public static IEnumerable<Tuple<string, string, string>> ApiInfo_NetworkAdminClient
    {
        get
        {
            return new Tuple<string, string, string>[]
            {
                new Tuple<string, string, string>("Network.Admin", "LoadBalancers", "2015-06-15"),
                new Tuple<string, string, string>("Network.Admin", "PublicIPAddresses", "2015-06-15"),
                new Tuple<string, string, string>("Network.Admin", "Quotas", "2015-06-15"),
                new Tuple<string, string, string>("Network.Admin", "ResourceProviderState", "2015-06-15"),
                new Tuple<string, string, string>("Network.Admin", "VirtualNetworks", "2015-06-15"),
            }.AsEnumerable();
        }
    }
}
