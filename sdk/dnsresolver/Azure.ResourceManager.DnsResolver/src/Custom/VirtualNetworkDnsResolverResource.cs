// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.Threading;
using Azure;
using Azure.Core;
using Azure.ResourceManager.DnsResolver.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
namespace Azure.ResourceManager.DnsResolver
{
    // Justification: this synthetic wrapper type existed in the shipped AutoRest SDK for the
    // "list by virtual network" operations. The TypeSpec generator still produces those operations,
    // but surfaces them as extension methods on ResourceGroupResource instead of generating this
    // resource type, so this delegating facade preserves backward compatibility.
    /// <summary>
    /// Represents a virtual network resource together with DNS Resolver operations that are scoped
    /// to that virtual network.
    /// </summary>
    public partial class VirtualNetworkDnsResolverResource : ArmResource
    {
        /// <summary>
        /// Gets the resource type represented by this class.
        /// </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Network/virtualNetworks";

        /// <summary>
        /// Initializes a new instance of the <see cref="VirtualNetworkDnsResolverResource"/> class for mocking.
        /// </summary>
        protected VirtualNetworkDnsResolverResource()
        {
        }

        internal VirtualNetworkDnsResolverResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
#if DEBUG
            ValidateResourceId(id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceType)
            {
                throw new ArgumentException(
                    string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceType),
                    nameof(id));
            }
        }

        /// <summary>
        /// Asynchronously gets the DNS forwarding rulesets attached to this virtual network.
        /// </summary>
        public virtual AsyncPageable<VirtualNetworkDnsForwardingRuleset> GetDnsForwardingRulesetsAsync(int? top = default, CancellationToken cancellationToken = default)
        {
            return GetResourceGroupResource().GetDnsForwardingRulesetsByVirtualNetworkAsync(Id.Name, top, cancellationToken);
        }

        /// <summary>
        /// Gets the DNS forwarding rulesets attached to this virtual network.
        /// </summary>
        public virtual Pageable<VirtualNetworkDnsForwardingRuleset> GetDnsForwardingRulesets(int? top = default, CancellationToken cancellationToken = default)
        {
            return GetResourceGroupResource().GetDnsForwardingRulesetsByVirtualNetwork(Id.Name, top, cancellationToken);
        }

        /// <summary>
        /// Asynchronously gets the DNS resolver policies linked to this virtual network.
        /// </summary>
        public virtual AsyncPageable<WritableSubResource> GetDnsResolverPoliciesByVirtualNetworkAsync(CancellationToken cancellationToken = default)
        {
            return GetResourceGroupResource().GetDnsResolverPoliciesByVirtualNetworkAsync(Id.Name, cancellationToken);
        }

        /// <summary>
        /// Gets the DNS resolver policies linked to this virtual network.
        /// </summary>
        public virtual Pageable<WritableSubResource> GetDnsResolverPoliciesByVirtualNetwork(CancellationToken cancellationToken = default)
        {
            return GetResourceGroupResource().GetDnsResolverPoliciesByVirtualNetwork(Id.Name, cancellationToken);
        }

        /// <summary>
        /// Asynchronously gets the DNS resolvers linked to this virtual network.
        /// </summary>
        public virtual AsyncPageable<WritableSubResource> GetDnsResolversAsync(int? top = default, CancellationToken cancellationToken = default)
        {
            return GetResourceGroupResource().GetDnsResolversByVirtualNetworkAsync(Id.Name, top, cancellationToken);
        }

        /// <summary>
        /// Gets the DNS resolvers linked to this virtual network.
        /// </summary>
        public virtual Pageable<WritableSubResource> GetDnsResolvers(int? top = default, CancellationToken cancellationToken = default)
        {
            return GetResourceGroupResource().GetDnsResolversByVirtualNetwork(Id.Name, top, cancellationToken);
        }

        private ResourceGroupResource GetResourceGroupResource()
        {
            ResourceIdentifier resourceGroupId = ResourceGroupResource.CreateResourceIdentifier(Id.SubscriptionId, Id.ResourceGroupName);
            return Client.GetResourceGroupResource(resourceGroupId);
        }
    }
}
