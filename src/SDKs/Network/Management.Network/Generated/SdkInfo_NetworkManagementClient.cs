
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
                new Tuple<string, string, string>("Network", "ApplicationGateways", "2018-04-01"),
                new Tuple<string, string, string>("Network", "ApplicationSecurityGroups", "2018-04-01"),
                new Tuple<string, string, string>("Network", "AvailableEndpointServices", "2018-04-01"),
                new Tuple<string, string, string>("Network", "BgpServiceCommunities", "2018-04-01"),
                new Tuple<string, string, string>("Network", "CheckDnsNameAvailability", "2018-04-01"),
                new Tuple<string, string, string>("Network", "ConnectionMonitors", "2018-04-01"),
                new Tuple<string, string, string>("Network", "DdosProtectionPlans", "2018-04-01"),
                new Tuple<string, string, string>("Network", "DefaultSecurityRules", "2018-04-01"),
                new Tuple<string, string, string>("Network", "ExpressRouteCircuitAuthorizations", "2018-04-01"),
                new Tuple<string, string, string>("Network", "ExpressRouteCircuitConnections", "2018-04-01"),
                new Tuple<string, string, string>("Network", "ExpressRouteCircuitPeerings", "2018-04-01"),
                new Tuple<string, string, string>("Network", "ExpressRouteCircuits", "2018-04-01"),
                new Tuple<string, string, string>("Network", "ExpressRouteCrossConnectionPeerings", "2018-04-01"),
                new Tuple<string, string, string>("Network", "ExpressRouteCrossConnections", "2018-04-01"),
                new Tuple<string, string, string>("Network", "ExpressRouteServiceProviders", "2018-04-01"),
                new Tuple<string, string, string>("Network", "InboundNatRules", "2018-04-01"),
                new Tuple<string, string, string>("Network", "LoadBalancerBackendAddressPools", "2018-04-01"),
                new Tuple<string, string, string>("Network", "LoadBalancerFrontendIPConfigurations", "2018-04-01"),
                new Tuple<string, string, string>("Network", "LoadBalancerLoadBalancingRules", "2018-04-01"),
                new Tuple<string, string, string>("Network", "LoadBalancerNetworkInterfaces", "2018-04-01"),
                new Tuple<string, string, string>("Network", "LoadBalancerProbes", "2018-04-01"),
                new Tuple<string, string, string>("Network", "LoadBalancers", "2018-04-01"),
                new Tuple<string, string, string>("Network", "LocalNetworkGateways", "2018-04-01"),
                new Tuple<string, string, string>("Network", "NetworkInterfaceIPConfigurations", "2018-04-01"),
                new Tuple<string, string, string>("Network", "NetworkInterfaceLoadBalancers", "2018-04-01"),
                new Tuple<string, string, string>("Network", "NetworkInterfaces", "2018-04-01"),
                new Tuple<string, string, string>("Network", "NetworkSecurityGroups", "2018-04-01"),
                new Tuple<string, string, string>("Network", "NetworkWatchers", "2018-04-01"),
                new Tuple<string, string, string>("Network", "Operations", "2018-04-01"),
                new Tuple<string, string, string>("Network", "PacketCaptures", "2018-04-01"),
                new Tuple<string, string, string>("Network", "PublicIPAddresses", "2018-04-01"),
                new Tuple<string, string, string>("Network", "RouteFilterRules", "2018-04-01"),
                new Tuple<string, string, string>("Network", "RouteFilters", "2018-04-01"),
                new Tuple<string, string, string>("Network", "RouteTables", "2018-04-01"),
                new Tuple<string, string, string>("Network", "Routes", "2018-04-01"),
                new Tuple<string, string, string>("Network", "SecurityRules", "2018-04-01"),
                new Tuple<string, string, string>("Network", "Subnets", "2018-04-01"),
                new Tuple<string, string, string>("Network", "Usages", "2018-04-01"),
                new Tuple<string, string, string>("Network", "VirtualNetworkGatewayConnections", "2018-04-01"),
                new Tuple<string, string, string>("Network", "VirtualNetworkGateways", "2018-04-01"),
                new Tuple<string, string, string>("Network", "VirtualNetworkPeerings", "2018-04-01"),
                new Tuple<string, string, string>("Network", "VirtualNetworks", "2018-04-01"),
            }.AsEnumerable();
        }
    }
}
