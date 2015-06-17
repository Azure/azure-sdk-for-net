namespace Microsoft.Azure.Management.Network
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest;
    using Microsoft.Azure;
    using Models;

    /// <summary>
    /// </summary>
    public partial interface INetworkResourceProviderClient : IDisposable
    {
        /// <summary>
        /// The base URI of the service.
        /// </summary>
        Uri BaseUri { get; set; }

        ILoadBalancersOperations LoadBalancers { get; }

        ILocalNetworkGatewaysOperations LocalNetworkGateways { get; }

        INetworkInterfacesOperations NetworkInterfaces { get; }

        INetworkSecurityGroupsOperations NetworkSecurityGroups { get; }

        IPublicIpAddressesOperations PublicIpAddresses { get; }

        ISecurityRulesOperations SecurityRules { get; }

        ISubnetsOperations Subnets { get; }

        IUsagesOperations Usages { get; }

        IVirtualNetworkGatewayConnectionsOperations VirtualNetworkGatewayConnections { get; }

        IVirtualNetworkGatewaysOperations VirtualNetworkGateways { get; }

        IVirtualNetworksOperations VirtualNetworks { get; }

        /// <summary>
        /// Checks whether a domain name in the cloudapp.net zone is available
        /// for use.
        /// </summary>
        /// <param name='location'>
        /// The location of the domain name
        /// </param>
        /// <param name='domainNameLabel'>
        /// The domain name to be verified. It must conform to the following
        /// regular expression: ^[a-z][a-z0-9-]{1,61}[a-z0-9]$.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<bool?>> CheckDnsNameAvailabilityWithOperationResponseAsync(string location, string domainNameLabel = default(string), CancellationToken cancellationToken = default(CancellationToken));

    }
}
