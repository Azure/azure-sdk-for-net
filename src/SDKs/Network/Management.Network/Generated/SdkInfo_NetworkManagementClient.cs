
using System;
using System.Collections.Generic;
using System.Linq;

internal static partial class SdkInfo
{
    public static IEnumerable<Tuple<string, string, string>> ApiInfo_NetworkManagementClient
    {
        get
        {
            return new Tuple<string, string, string>[]
            {
                new Tuple<string, string, string>("Compute", "NetworkInterfaces", "2017-03-30"),
                new Tuple<string, string, string>("Compute", "PublicIPAddresses", "2017-03-30"),
                new Tuple<string, string, string>("Network", "ApplicationGateways", "2017-11-01"),
                new Tuple<string, string, string>("Network", "ApplicationSecurityGroups", "2017-11-01"),
                new Tuple<string, string, string>("Network", "AvailableEndpointServices", "2017-11-01"),
                new Tuple<string, string, string>("Network", "BgpServiceCommunities", "2017-11-01"),
                new Tuple<string, string, string>("Network", "CheckDnsNameAvailability", "2017-11-01"),
                new Tuple<string, string, string>("Network", "ConnectionMonitors", "2017-11-01"),
                new Tuple<string, string, string>("Network", "DefaultSecurityRules", "2017-11-01"),
                new Tuple<string, string, string>("Network", "ExpressRouteCircuitAuthorizations", "2017-11-01"),
                new Tuple<string, string, string>("Network", "ExpressRouteCircuitPeerings", "2017-11-01"),
                new Tuple<string, string, string>("Network", "ExpressRouteCircuits", "2017-11-01"),
                new Tuple<string, string, string>("Network", "ExpressRouteServiceProviders", "2017-11-01"),
                new Tuple<string, string, string>("Network", "InboundNatRules", "2017-11-01"),
                new Tuple<string, string, string>("Network", "LoadBalancerBackendAddressPools", "2017-11-01"),
                new Tuple<string, string, string>("Network", "LoadBalancerFrontendIPConfigurations", "2017-11-01"),
                new Tuple<string, string, string>("Network", "LoadBalancerLoadBalancingRules", "2017-11-01"),
                new Tuple<string, string, string>("Network", "LoadBalancerNetworkInterfaces", "2017-11-01"),
                new Tuple<string, string, string>("Network", "LoadBalancerProbes", "2017-11-01"),
                new Tuple<string, string, string>("Network", "LoadBalancers", "2017-11-01"),
                new Tuple<string, string, string>("Network", "LocalNetworkGateways", "2017-11-01"),
                new Tuple<string, string, string>("Network", "NetworkInterfaceIPConfigurations", "2017-11-01"),
                new Tuple<string, string, string>("Network", "NetworkInterfaceLoadBalancers", "2017-11-01"),
                new Tuple<string, string, string>("Network", "NetworkInterfaces", "2017-11-01"),
                new Tuple<string, string, string>("Network", "NetworkSecurityGroups", "2017-11-01"),
                new Tuple<string, string, string>("Network", "NetworkWatchers", "2017-11-01"),
                new Tuple<string, string, string>("Network", "Operations", "2017-11-01"),
                new Tuple<string, string, string>("Network", "PacketCaptures", "2017-11-01"),
                new Tuple<string, string, string>("Network", "PublicIPAddresses", "2017-11-01"),
                new Tuple<string, string, string>("Network", "RouteFilterRules", "2017-11-01"),
                new Tuple<string, string, string>("Network", "RouteFilters", "2017-11-01"),
                new Tuple<string, string, string>("Network", "RouteTables", "2017-11-01"),
                new Tuple<string, string, string>("Network", "Routes", "2017-11-01"),
                new Tuple<string, string, string>("Network", "SecurityRules", "2017-11-01"),
                new Tuple<string, string, string>("Network", "Subnets", "2017-11-01"),
                new Tuple<string, string, string>("Network", "Usages", "2017-11-01"),
                new Tuple<string, string, string>("Network", "VirtualNetworkGatewayConnections", "2017-11-01"),
                new Tuple<string, string, string>("Network", "VirtualNetworkGateways", "2017-11-01"),
                new Tuple<string, string, string>("Network", "VirtualNetworkPeerings", "2017-11-01"),
                new Tuple<string, string, string>("Network", "VirtualNetworks", "2017-11-01"),
            }.AsEnumerable();
        }
    }
}
