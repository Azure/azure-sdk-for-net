// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.DnsResolver.Models;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.DnsResolver
{
    /// <summary>
    /// A class extending from the VirtualNetworkResource in Azure.ResourceManager.DnsResolver along with the instance operations that can be performed on it.
    /// You can only construct a <see cref="VirtualNetworkDnsResolverResource" /> from a <see cref="ResourceIdentifier" /> with a resource type of Microsoft.Network/virtualNetworks.
    /// </summary>
    public partial class VirtualNetworkDnsResolverResource : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="VirtualNetworkDnsResolverResource"/> instance. </summary>
        internal static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string virtualNetworkName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/virtualNetworks/{virtualNetworkName}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _dnsResolverClientDiagnostics;
        private readonly DnsResolversRestOperations _dnsResolverRestClient;
        private readonly ClientDiagnostics _dnsForwardingRulesetClientDiagnostics;
        private readonly DnsForwardingRulesetsRestOperations _dnsForwardingRulesetRestClient;

        /// <summary> Initializes a new instance of the <see cref="VirtualNetworkDnsResolverResource"/> class for mocking. </summary>
        protected VirtualNetworkDnsResolverResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="VirtualNetworkDnsResolverResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal VirtualNetworkDnsResolverResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _dnsResolverClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.DnsResolver", DnsResolverResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(DnsResolverResource.ResourceType, out string dnsResolverApiVersion);
            _dnsResolverRestClient = new DnsResolversRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, dnsResolverApiVersion);
            _dnsForwardingRulesetClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.DnsResolver", DnsForwardingRulesetResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(DnsForwardingRulesetResource.ResourceType, out string dnsForwardingRulesetApiVersion);
            _dnsForwardingRulesetRestClient = new DnsForwardingRulesetsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, dnsForwardingRulesetApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Network/virtualNetworks";

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceType), nameof(id));
        }

        /// <summary>
        /// Lists DNS resolver resource IDs linked to a virtual network.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/virtualNetworks/{virtualNetworkName}/listDnsResolvers</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DnsResolvers_ListByVirtualNetwork</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="top"> The maximum number of results to return. If not specified, returns up to 100 results. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="WritableSubResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<WritableSubResource> GetDnsResolversAsync(int? top = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<WritableSubResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _dnsResolverClientDiagnostics.CreateScope("VirtualNetworkDnsResolverResource.GetDnsResolvers");
                scope.Start();
                try
                {
                    var response = await _dnsResolverRestClient.ListByVirtualNetworkAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, top, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<WritableSubResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _dnsResolverClientDiagnostics.CreateScope("VirtualNetworkDnsResolverResource.GetDnsResolvers");
                scope.Start();
                try
                {
                    var response = await _dnsResolverRestClient.ListByVirtualNetworkNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, top, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Lists DNS resolver resource IDs linked to a virtual network.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/virtualNetworks/{virtualNetworkName}/listDnsResolvers</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DnsResolvers_ListByVirtualNetwork</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="top"> The maximum number of results to return. If not specified, returns up to 100 results. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="WritableSubResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<WritableSubResource> GetDnsResolvers(int? top = null, CancellationToken cancellationToken = default)
        {
            Page<WritableSubResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _dnsResolverClientDiagnostics.CreateScope("VirtualNetworkDnsResolverResource.GetDnsResolvers");
                scope.Start();
                try
                {
                    var response = _dnsResolverRestClient.ListByVirtualNetwork(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, top, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<WritableSubResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _dnsResolverClientDiagnostics.CreateScope("VirtualNetworkDnsResolverResource.GetDnsResolvers");
                scope.Start();
                try
                {
                    var response = _dnsResolverRestClient.ListByVirtualNetworkNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, top, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Lists DNS forwarding ruleset resource IDs attached to a virtual network.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/virtualNetworks/{virtualNetworkName}/listDnsForwardingRulesets</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DnsForwardingRulesets_ListByVirtualNetwork</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="top"> The maximum number of results to return. If not specified, returns up to 100 results. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="VirtualNetworkDnsForwardingRuleset" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<VirtualNetworkDnsForwardingRuleset> GetDnsForwardingRulesetsAsync(int? top = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<VirtualNetworkDnsForwardingRuleset>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _dnsForwardingRulesetClientDiagnostics.CreateScope("VirtualNetworkDnsResolverResource.GetDnsForwardingRulesets");
                scope.Start();
                try
                {
                    var response = await _dnsForwardingRulesetRestClient.ListByVirtualNetworkAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, top, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<VirtualNetworkDnsForwardingRuleset>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _dnsForwardingRulesetClientDiagnostics.CreateScope("VirtualNetworkDnsResolverResource.GetDnsForwardingRulesets");
                scope.Start();
                try
                {
                    var response = await _dnsForwardingRulesetRestClient.ListByVirtualNetworkNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, top, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Lists DNS forwarding ruleset resource IDs attached to a virtual network.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/virtualNetworks/{virtualNetworkName}/listDnsForwardingRulesets</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DnsForwardingRulesets_ListByVirtualNetwork</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="top"> The maximum number of results to return. If not specified, returns up to 100 results. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="VirtualNetworkDnsForwardingRuleset" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<VirtualNetworkDnsForwardingRuleset> GetDnsForwardingRulesets(int? top = null, CancellationToken cancellationToken = default)
        {
            Page<VirtualNetworkDnsForwardingRuleset> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _dnsForwardingRulesetClientDiagnostics.CreateScope("VirtualNetworkDnsResolverResource.GetDnsForwardingRulesets");
                scope.Start();
                try
                {
                    var response = _dnsForwardingRulesetRestClient.ListByVirtualNetwork(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, top, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<VirtualNetworkDnsForwardingRuleset> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _dnsForwardingRulesetClientDiagnostics.CreateScope("VirtualNetworkDnsResolverResource.GetDnsForwardingRulesets");
                scope.Start();
                try
                {
                    var response = _dnsForwardingRulesetRestClient.ListByVirtualNetworkNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, top, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }
    }
}
