// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using Azure.Core.Pipeline;
using Azure.ResourceManager.SecurityCenter.Models;

namespace Azure.ResourceManager.SecurityCenter
{
    // Generated code only emits operations whose resource scope and request path still exist in TypeSpec; this previous GA method used an old operation path, scope, or overload that no longer maps to a generated request. Keep a hidden ApiCompat shim and fail the unsupported operation explicitly.
    /// <summary>
    /// Provides a compatibility shim for the SecurityCenterLocationResource class.
    /// </summary>
    public partial class SecurityCenterLocationResource
    {
        private static System.Collections.Generic.IReadOnlyList<SecurityCenterAllowedConnection> ToLegacyList(System.Collections.Generic.IEnumerable<SecurityCenterAllowedConnectionData> values)
        {
            var legacyValues = new System.Collections.Generic.List<SecurityCenterAllowedConnection>();
            foreach (SecurityCenterAllowedConnectionData value in values)
            {
                legacyValues.Add(new SecurityCenterAllowedConnection(value));
            }
            return legacyValues;
        }

        private static System.Collections.Generic.IReadOnlyList<DiscoveredSecuritySolution> ToLegacyList(System.Collections.Generic.IEnumerable<DiscoveredSecuritySolutionData> values)
        {
            var legacyValues = new System.Collections.Generic.List<DiscoveredSecuritySolution>();
            foreach (DiscoveredSecuritySolutionData value in values)
            {
                legacyValues.Add(new DiscoveredSecuritySolution(value));
            }
            return legacyValues;
        }

        private static System.Collections.Generic.IReadOnlyList<Models.SecurityTopologyResource> ToLegacyList(System.Collections.Generic.IEnumerable<SecurityTopologyResourceData> values)
        {
            var legacyValues = new System.Collections.Generic.List<Models.SecurityTopologyResource>();
            foreach (SecurityTopologyResourceData value in values)
            {
                legacyValues.Add(new Models.SecurityTopologyResource(value));
            }
            return legacyValues;
        }

        private ClientDiagnostics _allowedConnectionsClientDiagnostics;
        private AllowedConnections _allowedConnectionsRestClient;
        private ClientDiagnostics _discoveredSecuritySolutionsClientDiagnostics;
        private DiscoveredSecuritySolutions _discoveredSecuritySolutionsRestClient;
        private ClientDiagnostics _topologyClientDiagnostics;
        private Topology _topologyRestClient;

        private ClientDiagnostics AllowedConnectionsClientDiagnostics => _allowedConnectionsClientDiagnostics ??= new ClientDiagnostics("Azure.ResourceManager.SecurityCenter", ResourceType.Namespace, Diagnostics);
        private AllowedConnections AllowedConnectionsRestClient => _allowedConnectionsRestClient ??= new AllowedConnections(AllowedConnectionsClientDiagnostics, Pipeline, Endpoint, "2020-01-01");
        private ClientDiagnostics DiscoveredSecuritySolutionsClientDiagnostics => _discoveredSecuritySolutionsClientDiagnostics ??= new ClientDiagnostics("Azure.ResourceManager.SecurityCenter", ResourceType.Namespace, Diagnostics);
        private DiscoveredSecuritySolutions DiscoveredSecuritySolutionsRestClient => _discoveredSecuritySolutionsRestClient ??= new DiscoveredSecuritySolutions(DiscoveredSecuritySolutionsClientDiagnostics, Pipeline, Endpoint, "2020-01-01");
        private ClientDiagnostics TopologyClientDiagnostics => _topologyClientDiagnostics ??= new ClientDiagnostics("Azure.ResourceManager.SecurityCenter", ResourceType.Namespace, Diagnostics);
        private Topology TopologyRestClient => _topologyRestClient ??= new Topology(TopologyClientDiagnostics, Pipeline, Endpoint, "2020-01-01");

        /// <summary>
        /// Provides a compatibility shim for the CreateResourceIdentifier operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="subscriptionId">The value preserved for API compatibility.</param>
        /// <param name="ascLocation">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("This API is no longer supported by the service. Use SecurityCenterLocationResource.CreateResourceIdentifier(string subscriptionId, string ascLocation) instead.")]
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation ascLocation) { throw new System.NotSupportedException("This API is no longer supported by the service. Use SecurityCenterLocationResource.CreateResourceIdentifier(string subscriptionId, string ascLocation) instead."); }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.SecurityCenter
{
    // Generated code only emits operations whose resource scope and request path still exist in TypeSpec; this previous GA method used an old operation path, scope, or overload that no longer maps to a generated request. Keep a hidden ApiCompat shim and fail the unsupported operation explicitly.
    /// <summary>
    /// Provides a compatibility shim for the SecurityCenterLocationResource class.
    /// </summary>
    public partial class SecurityCenterLocationResource
    {
        /// <summary>
        /// Provides a compatibility shim for the GetJitNetworkAccessPoliciesByRegionAsync operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("This API is no longer supported by the service. Use ResourceGroupResource.GetJitNetworkAccessPoliciesByResourceGroup() or ResourceGroupResource.GetJitNetworkAccessPoliciesByResourceGroupAsync() instead.")]
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.JitNetworkAccessPolicyResource> GetJitNetworkAccessPoliciesByRegionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. Use ResourceGroupResource.GetJitNetworkAccessPoliciesByResourceGroup() or ResourceGroupResource.GetJitNetworkAccessPoliciesByResourceGroupAsync() instead."); }
        /// <summary>
        /// Provides a compatibility shim for the GetDiscoveredSecuritySolutionsByHomeRegionAsync operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.Models.DiscoveredSecuritySolution> GetDiscoveredSecuritySolutionsByHomeRegionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Azure.RequestContext context = new Azure.RequestContext { CancellationToken = cancellationToken };
            return new SecurityCenterCompatibilityAsyncPageable<DiscoveredSecuritySolution>(
                Pipeline,
                DiscoveredSecuritySolutionsClientDiagnostics,
                context,
                "SecurityCenterLocationResource.GetDiscoveredSecuritySolutionsByHomeRegion",
                (nextLink, requestContext) => nextLink is null
                    ? DiscoveredSecuritySolutionsRestClient.CreateGetByHomeRegionRequest(System.Guid.Parse(Id.SubscriptionId), Id.Name, requestContext)
                    : DiscoveredSecuritySolutionsRestClient.CreateNextGetByHomeRegionRequest(nextLink, System.Guid.Parse(Id.SubscriptionId), Id.Name, requestContext),
                response =>
                {
                    DiscoveredSecuritySolutionList result = DiscoveredSecuritySolutionList.FromResponse(response);
                    return (ToLegacyList(result.Value), result.NextLink);
                });
        }
        /// <summary>
        /// Provides a compatibility shim for the GetAllowedConnectionsByHomeRegionAsync operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.Models.SecurityCenterAllowedConnection> GetAllowedConnectionsByHomeRegionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Azure.RequestContext context = new Azure.RequestContext { CancellationToken = cancellationToken };
            return new SecurityCenterCompatibilityAsyncPageable<SecurityCenterAllowedConnection>(
                Pipeline,
                AllowedConnectionsClientDiagnostics,
                context,
                "SecurityCenterLocationResource.GetAllowedConnectionsByHomeRegion",
                (nextLink, requestContext) => nextLink is null
                    ? AllowedConnectionsRestClient.CreateGetByHomeRegionRequest(System.Guid.Parse(Id.SubscriptionId), Id.Name, requestContext)
                    : AllowedConnectionsRestClient.CreateNextGetByHomeRegionRequest(nextLink, System.Guid.Parse(Id.SubscriptionId), Id.Name, requestContext),
                response =>
                {
                    AllowedConnectionsList result = AllowedConnectionsList.FromResponse(response);
                    return (ToLegacyList(result.Value), result.NextLink);
                });
        }
        /// <summary>
        /// Provides a compatibility shim for the GetAllSecuritySolutionsReferenceDataByHomeRegionAsync operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("This API is no longer supported by the service. Use SubscriptionResource.GetSecuritySolutionsReferenceData() instead.")]
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.Models.SecuritySolutionsReferenceData> GetAllSecuritySolutionsReferenceDataByHomeRegionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. Use SubscriptionResource.GetSecuritySolutionsReferenceData() instead."); }
        /// <summary>
        /// Provides a compatibility shim for the GetTopologiesByHomeRegionAsync operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.Models.SecurityTopologyResource> GetTopologiesByHomeRegionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Azure.RequestContext context = new Azure.RequestContext { CancellationToken = cancellationToken };
            return new SecurityCenterCompatibilityAsyncPageable<Models.SecurityTopologyResource>(
                Pipeline,
                TopologyClientDiagnostics,
                context,
                "SecurityCenterLocationResource.GetTopologiesByHomeRegion",
                (nextLink, requestContext) => nextLink is null
                    ? TopologyRestClient.CreateGetByHomeRegionRequest(System.Guid.Parse(Id.SubscriptionId), Id.Name, requestContext)
                    : TopologyRestClient.CreateNextGetByHomeRegionRequest(nextLink, System.Guid.Parse(Id.SubscriptionId), Id.Name, requestContext),
                response =>
                {
                    TopologyList result = TopologyList.FromResponse(response);
                    return (ToLegacyList(result.Value), result.NextLink);
                });
        }
        /// <summary>
        /// Provides a compatibility shim for the GetJitNetworkAccessPoliciesByRegion operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("This API is no longer supported by the service. Use ResourceGroupResource.GetJitNetworkAccessPoliciesByResourceGroup() or ResourceGroupResource.GetJitNetworkAccessPoliciesByResourceGroupAsync() instead.")]
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.JitNetworkAccessPolicyResource> GetJitNetworkAccessPoliciesByRegion(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. Use ResourceGroupResource.GetJitNetworkAccessPoliciesByResourceGroup() or ResourceGroupResource.GetJitNetworkAccessPoliciesByResourceGroupAsync() instead."); }
        /// <summary>
        /// Provides a compatibility shim for the GetDiscoveredSecuritySolutionsByHomeRegion operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.Models.DiscoveredSecuritySolution> GetDiscoveredSecuritySolutionsByHomeRegion(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Azure.RequestContext context = new Azure.RequestContext { CancellationToken = cancellationToken };
            return new SecurityCenterCompatibilityPageable<DiscoveredSecuritySolution>(
                Pipeline,
                DiscoveredSecuritySolutionsClientDiagnostics,
                context,
                "SecurityCenterLocationResource.GetDiscoveredSecuritySolutionsByHomeRegion",
                (nextLink, requestContext) => nextLink is null
                    ? DiscoveredSecuritySolutionsRestClient.CreateGetByHomeRegionRequest(System.Guid.Parse(Id.SubscriptionId), Id.Name, requestContext)
                    : DiscoveredSecuritySolutionsRestClient.CreateNextGetByHomeRegionRequest(nextLink, System.Guid.Parse(Id.SubscriptionId), Id.Name, requestContext),
                response =>
                {
                    DiscoveredSecuritySolutionList result = DiscoveredSecuritySolutionList.FromResponse(response);
                    return (ToLegacyList(result.Value), result.NextLink);
                });
        }
        /// <summary>
        /// Provides a compatibility shim for the GetAllowedConnectionsByHomeRegion operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.Models.SecurityCenterAllowedConnection> GetAllowedConnectionsByHomeRegion(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Azure.RequestContext context = new Azure.RequestContext { CancellationToken = cancellationToken };
            return new SecurityCenterCompatibilityPageable<SecurityCenterAllowedConnection>(
                Pipeline,
                AllowedConnectionsClientDiagnostics,
                context,
                "SecurityCenterLocationResource.GetAllowedConnectionsByHomeRegion",
                (nextLink, requestContext) => nextLink is null
                    ? AllowedConnectionsRestClient.CreateGetByHomeRegionRequest(System.Guid.Parse(Id.SubscriptionId), Id.Name, requestContext)
                    : AllowedConnectionsRestClient.CreateNextGetByHomeRegionRequest(nextLink, System.Guid.Parse(Id.SubscriptionId), Id.Name, requestContext),
                response =>
                {
                    AllowedConnectionsList result = AllowedConnectionsList.FromResponse(response);
                    return (ToLegacyList(result.Value), result.NextLink);
                });
        }
        /// <summary>
        /// Provides a compatibility shim for the GetAllSecuritySolutionsReferenceDataByHomeRegion operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("This API is no longer supported by the service. Use SubscriptionResource.GetSecuritySolutionsReferenceData() instead.")]
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.Models.SecuritySolutionsReferenceData> GetAllSecuritySolutionsReferenceDataByHomeRegion(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. Use SubscriptionResource.GetSecuritySolutionsReferenceData() instead."); }
        /// <summary>
        /// Provides a compatibility shim for the GetTopologiesByHomeRegion operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.Models.SecurityTopologyResource> GetTopologiesByHomeRegion(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Azure.RequestContext context = new Azure.RequestContext { CancellationToken = cancellationToken };
            return new SecurityCenterCompatibilityPageable<Models.SecurityTopologyResource>(
                Pipeline,
                TopologyClientDiagnostics,
                context,
                "SecurityCenterLocationResource.GetTopologiesByHomeRegion",
                (nextLink, requestContext) => nextLink is null
                    ? TopologyRestClient.CreateGetByHomeRegionRequest(System.Guid.Parse(Id.SubscriptionId), Id.Name, requestContext)
                    : TopologyRestClient.CreateNextGetByHomeRegionRequest(nextLink, System.Guid.Parse(Id.SubscriptionId), Id.Name, requestContext),
                response =>
                {
                    TopologyList result = TopologyList.FromResponse(response);
                    return (ToLegacyList(result.Value), result.NextLink);
                });
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.SecurityCenter
{
    // Generated code only emits operations whose resource scope and request path still exist in TypeSpec; this previous GA method used an old operation path, scope, or overload that no longer maps to a generated request. Keep a hidden ApiCompat shim and fail the unsupported operation explicitly.
    /// <summary>
    /// Provides a compatibility shim for the SecurityCenterLocationResource class.
    /// </summary>
    public partial class SecurityCenterLocationResource
    {
        /// <summary>
        /// Provides a compatibility shim for the GetAdaptiveApplicationControlGroup operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="groupName">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("This API is no longer supported by the service. Use ArmClient.GetAdaptiveApplicationControlGroupResource(ResourceIdentifier id) instead.")]
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupResource> GetAdaptiveApplicationControlGroup(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. Use ArmClient.GetAdaptiveApplicationControlGroupResource(ResourceIdentifier id) instead."); }
        /// <summary>
        /// Provides a compatibility shim for the GetAdaptiveApplicationControlGroupAsync operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="groupName">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("This API is no longer supported by the service. Use ArmClient.GetAdaptiveApplicationControlGroupResource(ResourceIdentifier id) instead.")]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupResource>> GetAdaptiveApplicationControlGroupAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. Use ArmClient.GetAdaptiveApplicationControlGroupResource(ResourceIdentifier id) instead."); }
        /// <summary>
        /// Provides a compatibility shim for the GetAdaptiveApplicationControlGroups operation preserved from the previous public API surface.
        /// </summary>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("This API is no longer supported by the service. Use ArmClient.GetAdaptiveApplicationControlGroupResource(ResourceIdentifier id) instead.")]
        public virtual Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupCollection GetAdaptiveApplicationControlGroups() { throw new System.NotSupportedException("This API is no longer supported by the service. Use ArmClient.GetAdaptiveApplicationControlGroupResource(ResourceIdentifier id) instead."); }
    }
}
