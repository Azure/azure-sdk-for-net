// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.SecurityCenter.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.SecurityCenter
{
    // Generated code only emits operations whose resource scope and request path still exist in TypeSpec; this previous GA method used an old operation path, scope, or overload that no longer maps to a generated request. Keep a hidden ApiCompat shim and fail the unsupported operation explicitly.
    // Compatibility customization: GA exposed this resource-id overload without the generated Resource suffix.
    /// <summary>
    /// Provides a compatibility shim for the SecurityCenterExtensions class.
    /// </summary>
    [CodeGenSuppress("GetAllowedConnectionsAsync", typeof(SubscriptionResource), typeof(CancellationToken))]
    [CodeGenSuppress("GetAllowedConnections", typeof(SubscriptionResource), typeof(CancellationToken))]
    [CodeGenSuppress("GetDiscoveredSecuritySolutionsAsync", typeof(SubscriptionResource), typeof(CancellationToken))]
    [CodeGenSuppress("GetDiscoveredSecuritySolutions", typeof(SubscriptionResource), typeof(CancellationToken))]
    [CodeGenSuppress("GetSecuritySolutionsAsync", typeof(SubscriptionResource), typeof(CancellationToken))]
    [CodeGenSuppress("GetSecuritySolutions", typeof(SubscriptionResource), typeof(CancellationToken))]
    [CodeGenSuppress("GetTopologiesAsync", typeof(SubscriptionResource), typeof(CancellationToken))]
    [CodeGenSuppress("GetTopologies", typeof(SubscriptionResource), typeof(CancellationToken))]
    public static partial class SecurityCenterExtensions
    {
        private static Response<Models.DiscoveredSecuritySolution> ToLegacyResponse(Response<DiscoveredSecuritySolutionResource> response)
            => Response.FromValue(new Models.DiscoveredSecuritySolution(response.Value?.Data), response.GetRawResponse());

        private static async System.Threading.Tasks.Task<Response<Models.DiscoveredSecuritySolution>> ToLegacyResponseAsync(System.Threading.Tasks.Task<Response<DiscoveredSecuritySolutionResource>> responseTask)
            => ToLegacyResponse(await responseTask.ConfigureAwait(false));

        private static Response<Models.SecuritySolution> ToLegacyResponse(Response<SecuritySolutionResource> response)
            => Response.FromValue(new Models.SecuritySolution(response.Value?.Data), response.GetRawResponse());

        private static async System.Threading.Tasks.Task<Response<Models.SecuritySolution>> ToLegacyResponseAsync(System.Threading.Tasks.Task<Response<SecuritySolutionResource>> responseTask)
            => ToLegacyResponse(await responseTask.ConfigureAwait(false));

        private static Response<Models.SecurityTopologyResource> ToLegacyResponse(Response<SecurityTopologyResource> response)
            => Response.FromValue(new Models.SecurityTopologyResource(response.Value?.Data), response.GetRawResponse());

        private static async System.Threading.Tasks.Task<Response<Models.SecurityTopologyResource>> ToLegacyResponseAsync(System.Threading.Tasks.Task<Response<SecurityTopologyResource>> responseTask)
            => ToLegacyResponse(await responseTask.ConfigureAwait(false));

        private static Response<Models.SecurityCenterAllowedConnection> ToLegacyResponse(Response<SecurityCenterAllowedConnectionResource> response)
            => Response.FromValue(new Models.SecurityCenterAllowedConnection(response.Value?.Data), response.GetRawResponse());

        private static async System.Threading.Tasks.Task<Response<Models.SecurityCenterAllowedConnection>> ToLegacyResponseAsync(System.Threading.Tasks.Task<Response<SecurityCenterAllowedConnectionResource>> responseTask)
            => ToLegacyResponse(await responseTask.ConfigureAwait(false));

        /// <summary> Gets allowed connections compatibility models. </summary>
        /// <param name="subscriptionResource"> The subscription resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public static AsyncPageable<Models.SecurityCenterAllowedConnection> GetAllowedConnectionsAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
            => new AsyncPageableWrapper<SecurityCenterAllowedConnectionResource, Models.SecurityCenterAllowedConnection>(
                GetMockableSecurityCenterSubscriptionResource(subscriptionResource).GetAllowedConnectionsAsync(cancellationToken),
                resource => new Models.SecurityCenterAllowedConnection(resource.Data));

        /// <summary> Gets allowed connections compatibility models. </summary>
        /// <param name="subscriptionResource"> The subscription resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public static Pageable<Models.SecurityCenterAllowedConnection> GetAllowedConnections(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
            => new PageableWrapper<SecurityCenterAllowedConnectionResource, Models.SecurityCenterAllowedConnection>(
                GetMockableSecurityCenterSubscriptionResource(subscriptionResource).GetAllowedConnections(cancellationToken),
                resource => new Models.SecurityCenterAllowedConnection(resource.Data));

        /// <summary> Gets discovered security solution compatibility models. </summary>
        /// <param name="subscriptionResource"> The subscription resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public static AsyncPageable<Models.DiscoveredSecuritySolution> GetDiscoveredSecuritySolutionsAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
            => new AsyncPageableWrapper<DiscoveredSecuritySolutionResource, Models.DiscoveredSecuritySolution>(
                GetMockableSecurityCenterSubscriptionResource(subscriptionResource).GetDiscoveredSecuritySolutionsAsync(cancellationToken),
                resource => new Models.DiscoveredSecuritySolution(resource.Data));

        /// <summary> Gets discovered security solution compatibility models. </summary>
        /// <param name="subscriptionResource"> The subscription resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public static Pageable<Models.DiscoveredSecuritySolution> GetDiscoveredSecuritySolutions(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
            => new PageableWrapper<DiscoveredSecuritySolutionResource, Models.DiscoveredSecuritySolution>(
                GetMockableSecurityCenterSubscriptionResource(subscriptionResource).GetDiscoveredSecuritySolutions(cancellationToken),
                resource => new Models.DiscoveredSecuritySolution(resource.Data));

        /// <summary> Gets security solution compatibility models. </summary>
        /// <param name="subscriptionResource"> The subscription resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public static AsyncPageable<Models.SecuritySolution> GetSecuritySolutionsAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
            => new AsyncPageableWrapper<SecuritySolutionResource, Models.SecuritySolution>(
                GetMockableSecurityCenterSubscriptionResource(subscriptionResource).GetSecuritySolutionsAsync(cancellationToken),
                resource => new Models.SecuritySolution(resource.Data));

        /// <summary> Gets security solution compatibility models. </summary>
        /// <param name="subscriptionResource"> The subscription resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public static Pageable<Models.SecuritySolution> GetSecuritySolutions(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
            => new PageableWrapper<SecuritySolutionResource, Models.SecuritySolution>(
                GetMockableSecurityCenterSubscriptionResource(subscriptionResource).GetSecuritySolutions(cancellationToken),
                resource => new Models.SecuritySolution(resource.Data));

        /// <summary> Gets topology compatibility models. </summary>
        /// <param name="subscriptionResource"> The subscription resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public static AsyncPageable<Models.SecurityTopologyResource> GetTopologiesAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
            => new AsyncPageableWrapper<SecurityTopologyResource, Models.SecurityTopologyResource>(
                GetMockableSecurityCenterSubscriptionResource(subscriptionResource).GetTopologiesAsync(cancellationToken),
                resource => new Models.SecurityTopologyResource(resource.Data));

        /// <summary> Gets topology compatibility models. </summary>
        /// <param name="subscriptionResource"> The subscription resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public static Pageable<Models.SecurityTopologyResource> GetTopologies(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
            => new PageableWrapper<SecurityTopologyResource, Models.SecurityTopologyResource>(
                GetMockableSecurityCenterSubscriptionResource(subscriptionResource).GetTopologies(cancellationToken),
                resource => new Models.SecurityTopologyResource(resource.Data));

        /// <summary>
        /// Provides a compatibility shim for the GetJitNetworkAccessPolicies operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="resourceGroupResource">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        public static Pageable<JitNetworkAccessPolicyResource> GetJitNetworkAccessPolicies(this ResourceGroupResource resourceGroupResource, CancellationToken cancellationToken = default)
            => GetMockableSecurityCenterResourceGroupResource(resourceGroupResource).GetJitNetworkAccessPolicies(cancellationToken);
        /// <summary>
        /// Provides a compatibility shim for the GetJitNetworkAccessPoliciesAsync operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="resourceGroupResource">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        public static AsyncPageable<JitNetworkAccessPolicyResource> GetJitNetworkAccessPoliciesAsync(this ResourceGroupResource resourceGroupResource, CancellationToken cancellationToken = default)
            => GetMockableSecurityCenterResourceGroupResource(resourceGroupResource).GetJitNetworkAccessPoliciesAsync(cancellationToken);
        /// <summary>
        /// Provides a compatibility shim for the GetSecureScoreControlsAsync operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="subscriptionResource">The value preserved for API compatibility.</param>
        /// <param name="expand">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("This API is no longer supported by the service. No direct replacement is available.")]
        public static AsyncPageable<SecureScoreControlDetails> GetSecureScoreControlsAsync(this SubscriptionResource subscriptionResource, SecurityScoreODataExpand? expand = default, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This API is no longer supported by the service. No direct replacement is available.");
        /// <summary>
        /// Provides a compatibility shim for the GetSecurityConnectorGovernanceRuleResource operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="client">The value preserved for API compatibility.</param>
        /// <param name="id">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [System.Obsolete("This class is obsolete and will be removed in a future release.", false)]
        public static SecurityConnectorGovernanceRuleResource GetSecurityConnectorGovernanceRuleResource(this ArmClient client, ResourceIdentifier id)
            => GetMockableSecurityCenterArmClient(client).GetSecurityConnectorGovernanceRuleResource(id);
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.SecurityCenter
{
    // Generated code only emits operations whose resource scope and request path still exist in TypeSpec; this previous GA method used an old operation path, scope, or overload that no longer maps to a generated request. Keep a hidden ApiCompat shim and fail the unsupported operation explicitly.
    /// <summary>
    /// Provides a compatibility shim for the SecurityCenterExtensions class.
    /// </summary>
    public static partial class SecurityCenterExtensions
    {
        /// <summary>
        /// Provides a compatibility shim for the GetDiscoveredSecuritySolution operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="resourceGroupResource">The value preserved for API compatibility.</param>
        /// <param name="ascLocation">The value preserved for API compatibility.</param>
        /// <param name="discoveredSecuritySolutionName">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.Models.DiscoveredSecuritySolution> GetDiscoveredSecuritySolution(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation ascLocation, string discoveredSecuritySolutionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => ToLegacyResponse(GetMockableSecurityCenterResourceGroupResource(resourceGroupResource).GetDiscoveredSecuritySolution(ascLocation, discoveredSecuritySolutionName, cancellationToken));
        /// <summary>
        /// Provides a compatibility shim for the GetDiscoveredSecuritySolutionAsync operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="resourceGroupResource">The value preserved for API compatibility.</param>
        /// <param name="ascLocation">The value preserved for API compatibility.</param>
        /// <param name="discoveredSecuritySolutionName">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.Models.DiscoveredSecuritySolution>> GetDiscoveredSecuritySolutionAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation ascLocation, string discoveredSecuritySolutionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => ToLegacyResponseAsync(GetMockableSecurityCenterResourceGroupResource(resourceGroupResource).GetDiscoveredSecuritySolutionAsync(ascLocation, discoveredSecuritySolutionName, cancellationToken));
        /// <summary>
        /// Provides a compatibility shim for the GetExternalSecuritySolution operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="resourceGroupResource">The value preserved for API compatibility.</param>
        /// <param name="ascLocation">The value preserved for API compatibility.</param>
        /// <param name="externalSecuritySolutionsName">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("This API is no longer supported by the service. Use SubscriptionResource.GetExternalSecuritySolutions() and filter by name instead.")]
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.Models.ExternalSecuritySolution> GetExternalSecuritySolution(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation ascLocation, string externalSecuritySolutionsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => throw new System.NotSupportedException("This API is no longer supported by the service. Use SubscriptionResource.GetExternalSecuritySolutions() and filter by name instead.");
        /// <summary>
        /// Provides a compatibility shim for the GetExternalSecuritySolutionAsync operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="resourceGroupResource">The value preserved for API compatibility.</param>
        /// <param name="ascLocation">The value preserved for API compatibility.</param>
        /// <param name="externalSecuritySolutionsName">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("This API is no longer supported by the service. Use SubscriptionResource.GetExternalSecuritySolutionsAsync() and filter by name instead.")]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.Models.ExternalSecuritySolution>> GetExternalSecuritySolutionAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation ascLocation, string externalSecuritySolutionsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => throw new System.NotSupportedException("This API is no longer supported by the service. Use SubscriptionResource.GetExternalSecuritySolutionsAsync() and filter by name instead.");
        /// <summary>
        /// Provides a compatibility shim for the GetSecurityCenterPricing operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="subscriptionResource">The value preserved for API compatibility.</param>
        /// <param name="pricingName">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityCenterPricingResource> GetSecurityCenterPricing(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string pricingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => GetMockableSecurityCenterSubscriptionResource(subscriptionResource).GetSecurityCenterPricing(pricingName, cancellationToken);
        /// <summary>
        /// Provides a compatibility shim for the GetSecurityCenterPricingAsync operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="subscriptionResource">The value preserved for API compatibility.</param>
        /// <param name="pricingName">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityCenterPricingResource>> GetSecurityCenterPricingAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string pricingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => GetMockableSecurityCenterSubscriptionResource(subscriptionResource).GetSecurityCenterPricingAsync(pricingName, cancellationToken);
        /// <summary>
        /// Provides a compatibility shim for the GetSecurityContact operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="subscriptionResource">The value preserved for API compatibility.</param>
        /// <param name="securityContactName">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityContactResource> GetSecurityContact(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string securityContactName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => GetMockableSecurityCenterSubscriptionResource(subscriptionResource).GetSecurityContact(securityContactName, cancellationToken);
        /// <summary>
        /// Provides a compatibility shim for the GetSecurityContactAsync operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="subscriptionResource">The value preserved for API compatibility.</param>
        /// <param name="securityContactName">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityContactResource>> GetSecurityContactAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string securityContactName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => GetMockableSecurityCenterSubscriptionResource(subscriptionResource).GetSecurityContactAsync(securityContactName, cancellationToken);
        /// <summary>
        /// Provides a compatibility shim for the GetSecuritySolution operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="resourceGroupResource">The value preserved for API compatibility.</param>
        /// <param name="ascLocation">The value preserved for API compatibility.</param>
        /// <param name="securitySolutionName">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.Models.SecuritySolution> GetSecuritySolution(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation ascLocation, string securitySolutionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => ToLegacyResponse(GetMockableSecurityCenterResourceGroupResource(resourceGroupResource).GetSecuritySolution(ascLocation, securitySolutionName, cancellationToken));
        /// <summary>
        /// Provides a compatibility shim for the GetSecuritySolutionAsync operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="resourceGroupResource">The value preserved for API compatibility.</param>
        /// <param name="ascLocation">The value preserved for API compatibility.</param>
        /// <param name="securitySolutionName">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.Models.SecuritySolution>> GetSecuritySolutionAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation ascLocation, string securitySolutionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => ToLegacyResponseAsync(GetMockableSecurityCenterResourceGroupResource(resourceGroupResource).GetSecuritySolutionAsync(ascLocation, securitySolutionName, cancellationToken));
        /// <summary>
        /// Provides a compatibility shim for the GetServerVulnerabilityAssessment operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="resourceGroupResource">The value preserved for API compatibility.</param>
        /// <param name="resourceNamespace">The value preserved for API compatibility.</param>
        /// <param name="resourceType">The value preserved for API compatibility.</param>
        /// <param name="resourceName">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.ServerVulnerabilityAssessmentResource> GetServerVulnerabilityAssessment(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceNamespace, string resourceType, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => GetMockableSecurityCenterResourceGroupResource(resourceGroupResource).GetServerVulnerabilityAssessment(resourceNamespace, resourceType, resourceName, cancellationToken);
        /// <summary>
        /// Provides a compatibility shim for the GetServerVulnerabilityAssessmentAsync operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="resourceGroupResource">The value preserved for API compatibility.</param>
        /// <param name="resourceNamespace">The value preserved for API compatibility.</param>
        /// <param name="resourceType">The value preserved for API compatibility.</param>
        /// <param name="resourceName">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.ServerVulnerabilityAssessmentResource>> GetServerVulnerabilityAssessmentAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceNamespace, string resourceType, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => GetMockableSecurityCenterResourceGroupResource(resourceGroupResource).GetServerVulnerabilityAssessmentAsync(resourceNamespace, resourceType, resourceName, cancellationToken);
        /// <summary>
        /// Provides a compatibility shim for the GetServerVulnerabilityAssessments operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="resourceGroupResource">The value preserved for API compatibility.</param>
        /// <param name="resourceNamespace">The value preserved for API compatibility.</param>
        /// <param name="resourceType">The value preserved for API compatibility.</param>
        /// <param name="resourceName">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        public static Azure.ResourceManager.SecurityCenter.ServerVulnerabilityAssessmentCollection GetServerVulnerabilityAssessments(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceNamespace, string resourceType, string resourceName)
            => GetMockableSecurityCenterResourceGroupResource(resourceGroupResource).GetServerVulnerabilityAssessments(resourceNamespace, resourceType, resourceName);
        /// <summary>
        /// Provides a compatibility shim for the GetSqlVulnerabilityAssessmentBaselineRule operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="client">The value preserved for API compatibility.</param>
        /// <param name="scope">The value preserved for API compatibility.</param>
        /// <param name="ruleId">The value preserved for API compatibility.</param>
        /// <param name="workspaceId">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.SqlVulnerabilityAssessmentBaselineRuleResource> GetSqlVulnerabilityAssessmentBaselineRule(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string ruleId, System.Guid workspaceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => GetMockableSecurityCenterArmClient(client).GetSqlVulnerabilityAssessmentBaselineRule(scope, ruleId, workspaceId, cancellationToken);
        /// <summary>
        /// Provides a compatibility shim for the GetSqlVulnerabilityAssessmentBaselineRuleAsync operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="client">The value preserved for API compatibility.</param>
        /// <param name="scope">The value preserved for API compatibility.</param>
        /// <param name="ruleId">The value preserved for API compatibility.</param>
        /// <param name="workspaceId">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SqlVulnerabilityAssessmentBaselineRuleResource>> GetSqlVulnerabilityAssessmentBaselineRuleAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string ruleId, System.Guid workspaceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => GetMockableSecurityCenterArmClient(client).GetSqlVulnerabilityAssessmentBaselineRuleAsync(scope, ruleId, workspaceId, cancellationToken);
        /// <summary>
        /// Provides a compatibility shim for the GetSqlVulnerabilityAssessmentScan operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="client">The value preserved for API compatibility.</param>
        /// <param name="scope">The value preserved for API compatibility.</param>
        /// <param name="scanId">The value preserved for API compatibility.</param>
        /// <param name="workspaceId">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.SqlVulnerabilityAssessmentScanResource> GetSqlVulnerabilityAssessmentScan(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string scanId, System.Guid workspaceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => GetMockableSecurityCenterArmClient(client).GetSqlVulnerabilityAssessmentScan(scope, scanId, workspaceId, cancellationToken);
        /// <summary>
        /// Provides a compatibility shim for the GetSqlVulnerabilityAssessmentScanAsync operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="client">The value preserved for API compatibility.</param>
        /// <param name="scope">The value preserved for API compatibility.</param>
        /// <param name="scanId">The value preserved for API compatibility.</param>
        /// <param name="workspaceId">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SqlVulnerabilityAssessmentScanResource>> GetSqlVulnerabilityAssessmentScanAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string scanId, System.Guid workspaceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => GetMockableSecurityCenterArmClient(client).GetSqlVulnerabilityAssessmentScanAsync(scope, scanId, workspaceId, cancellationToken);
        /// <summary>
        /// Provides a compatibility shim for the GetSubscriptionGovernanceRule operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="subscriptionResource">The value preserved for API compatibility.</param>
        /// <param name="ruleId">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.SubscriptionGovernanceRuleResource> GetSubscriptionGovernanceRule(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string ruleId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => GetMockableSecurityCenterSubscriptionResource(subscriptionResource).GetSubscriptionGovernanceRule(ruleId, cancellationToken);
        /// <summary>
        /// Provides a compatibility shim for the GetSubscriptionGovernanceRuleAsync operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="subscriptionResource">The value preserved for API compatibility.</param>
        /// <param name="ruleId">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SubscriptionGovernanceRuleResource>> GetSubscriptionGovernanceRuleAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string ruleId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => GetMockableSecurityCenterSubscriptionResource(subscriptionResource).GetSubscriptionGovernanceRuleAsync(ruleId, cancellationToken);
        /// <summary>
        /// Provides a compatibility shim for the GetTopology operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="resourceGroupResource">The value preserved for API compatibility.</param>
        /// <param name="ascLocation">The value preserved for API compatibility.</param>
        /// <param name="topologyResourceName">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.Models.SecurityTopologyResource> GetTopology(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation ascLocation, string topologyResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => GetMockableSecurityCenterResourceGroupResource(resourceGroupResource).GetTopology(ascLocation, topologyResourceName, cancellationToken);
        /// <summary>
        /// Provides a compatibility shim for the GetTopologyAsync operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="resourceGroupResource">The value preserved for API compatibility.</param>
        /// <param name="ascLocation">The value preserved for API compatibility.</param>
        /// <param name="topologyResourceName">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.Models.SecurityTopologyResource>> GetTopologyAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation ascLocation, string topologyResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => GetMockableSecurityCenterResourceGroupResource(resourceGroupResource).GetTopologyAsync(ascLocation, topologyResourceName, cancellationToken);
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.SecurityCenter
{
    // Generated code only emits operations whose resource scope and request path still exist in TypeSpec; this previous GA method used an old operation path, scope, or overload that no longer maps to a generated request. Keep a hidden ApiCompat shim and fail the unsupported operation explicitly.
    /// <summary>
    /// Provides a compatibility shim for the SecurityCenterExtensions class.
    /// </summary>
    public static partial class SecurityCenterExtensions
    {
        /// <summary>
        /// Provides a compatibility shim for the GetMdeOnboardingsAsync operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="subscriptionResource">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("This API is no longer supported by the service. Use SubscriptionResource.GetMdeOnboardingData() instead.")]
        public static Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.Models.MdeOnboarding> GetMdeOnboardingsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. Use SubscriptionResource.GetMdeOnboardingData() instead."); }
        /// <summary>
        /// Provides a compatibility shim for the GetAllSecuritySolutionsReferenceDataAsync operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="subscriptionResource">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("This API is no longer supported by the service. Use SubscriptionResource.GetSecuritySolutionsReferenceDataAsync() instead.")]
        public static Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.Models.SecuritySolutionsReferenceData> GetAllSecuritySolutionsReferenceDataAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. Use SubscriptionResource.GetSecuritySolutionsReferenceDataAsync() instead."); }
        /// <summary>
        /// Provides a compatibility shim for the GetAlertsAsync operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="subscriptionResource">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        public static Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.SecurityAlertData> GetAlertsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => GetMockableSecurityCenterSubscriptionResource(subscriptionResource).GetAlertsAsync(cancellationToken);
        /// <summary>
        /// Provides a compatibility shim for the GetAlertsByResourceGroupAsync operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="resourceGroupResource">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        public static Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.SecurityAlertData> GetAlertsByResourceGroupAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => GetMockableSecurityCenterResourceGroupResource(resourceGroupResource).GetAlertsByResourceGroupAsync(cancellationToken);
        /// <summary>
        /// Provides a compatibility shim for the GetMdeOnboardings operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="subscriptionResource">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("This API is no longer supported by the service. Use SubscriptionResource.GetMdeOnboardingData() instead.")]
        public static Azure.Pageable<Azure.ResourceManager.SecurityCenter.Models.MdeOnboarding> GetMdeOnboardings(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. Use SubscriptionResource.GetMdeOnboardingData() instead."); }
        /// <summary>
        /// Provides a compatibility shim for the GetAllSecuritySolutionsReferenceData operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="subscriptionResource">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("This API is no longer supported by the service. Use SubscriptionResource.GetSecuritySolutionsReferenceData() instead.")]
        public static Azure.Pageable<Azure.ResourceManager.SecurityCenter.Models.SecuritySolutionsReferenceData> GetAllSecuritySolutionsReferenceData(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. Use SubscriptionResource.GetSecuritySolutionsReferenceData() instead."); }
        /// <summary>
        /// Provides a compatibility shim for the GetAlerts operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="subscriptionResource">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        public static Azure.Pageable<Azure.ResourceManager.SecurityCenter.SecurityAlertData> GetAlerts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => GetMockableSecurityCenterSubscriptionResource(subscriptionResource).GetAlerts(cancellationToken);
        /// <summary>
        /// Provides a compatibility shim for the GetAlertsByResourceGroup operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="resourceGroupResource">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        public static Azure.Pageable<Azure.ResourceManager.SecurityCenter.SecurityAlertData> GetAlertsByResourceGroup(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => GetMockableSecurityCenterResourceGroupResource(resourceGroupResource).GetAlertsByResourceGroup(cancellationToken);
        /// <summary>
        /// Provides a compatibility shim for the GetSecureScoreControls operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="subscriptionResource">The value preserved for API compatibility.</param>
        /// <param name="expand">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        public static Azure.Pageable<Azure.ResourceManager.SecurityCenter.Models.SecureScoreControlDetails> GetSecureScoreControls(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.SecurityCenter.Models.SecurityScoreODataExpand? expand = default(Azure.ResourceManager.SecurityCenter.Models.SecurityScoreODataExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => GetMockableSecurityCenterSubscriptionResource(subscriptionResource).GetSecureScoreControls(expand, cancellationToken);
        /// <summary>
        /// Provides a compatibility shim for the GetSecurityCenterPricings operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="subscriptionResource">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        public static Azure.ResourceManager.SecurityCenter.SecurityCenterPricingCollection GetSecurityCenterPricings(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource)
            => GetMockableSecurityCenterSubscriptionResource(subscriptionResource).GetSecurityCenterPricings();
        /// <summary>
        /// Provides a compatibility shim for the GetSubscriptionGovernanceRules operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="subscriptionResource">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        public static Azure.ResourceManager.SecurityCenter.SubscriptionGovernanceRuleCollection GetSubscriptionGovernanceRules(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource)
            => GetMockableSecurityCenterSubscriptionResource(subscriptionResource).GetSubscriptionGovernanceRules();
        /// <summary>
        /// Provides a compatibility shim for the GetSubscriptionGovernanceRuleResource operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="client">The value preserved for API compatibility.</param>
        /// <param name="id">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        public static Azure.ResourceManager.SecurityCenter.SubscriptionGovernanceRuleResource GetSubscriptionGovernanceRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id)
            => GetMockableSecurityCenterArmClient(client).GetSubscriptionGovernanceRuleResource(id);
        /// <summary>
        /// Provides a compatibility shim for the GetSecurityAssessment operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="client">The value preserved for API compatibility.</param>
        /// <param name="scope">The value preserved for API compatibility.</param>
        /// <param name="assessmentName">The value preserved for API compatibility.</param>
        /// <param name="expand">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityAssessmentResource> GetSecurityAssessment(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string assessmentName, Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentODataExpand? expand = default(Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentODataExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => GetMockableSecurityCenterArmClient(client).GetSecurityAssessment(scope, assessmentName, expand, cancellationToken);
        /// <summary>
        /// Provides a compatibility shim for the GetSecurityAssessmentAsync operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="client">The value preserved for API compatibility.</param>
        /// <param name="scope">The value preserved for API compatibility.</param>
        /// <param name="assessmentName">The value preserved for API compatibility.</param>
        /// <param name="expand">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityAssessmentResource>> GetSecurityAssessmentAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string assessmentName, Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentODataExpand? expand = default(Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentODataExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => GetMockableSecurityCenterArmClient(client).GetSecurityAssessmentAsync(scope, assessmentName, expand, cancellationToken);
        /// <summary>
        /// Provides a compatibility shim for the GetMdeOnboarding operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="subscriptionResource">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.Models.MdeOnboarding> GetMdeOnboarding(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => GetMockableSecurityCenterSubscriptionResource(subscriptionResource).GetMdeOnboarding(cancellationToken);
        /// <summary>
        /// Provides a compatibility shim for the GetAllowedConnection operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="resourceGroupResource">The value preserved for API compatibility.</param>
        /// <param name="ascLocation">The value preserved for API compatibility.</param>
        /// <param name="connectionType">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.Models.SecurityCenterAllowedConnection> GetAllowedConnection(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation ascLocation, Azure.ResourceManager.SecurityCenter.Models.SecurityCenterConnectionType connectionType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => GetMockableSecurityCenterResourceGroupResource(resourceGroupResource).GetAllowedConnection(ascLocation, connectionType, cancellationToken);
        /// <summary>
        /// Provides a compatibility shim for the GetSecurityCenterLocation operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="subscriptionResource">The value preserved for API compatibility.</param>
        /// <param name="ascLocation">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityCenterLocationResource> GetSecurityCenterLocation(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation ascLocation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => GetMockableSecurityCenterSubscriptionResource(subscriptionResource).GetSecurityCenterLocation(ascLocation, cancellationToken);
        /// <summary>
        /// Provides a compatibility shim for the GetSecuritySetting operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="subscriptionResource">The value preserved for API compatibility.</param>
        /// <param name="settingName">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.SecuritySettingResource> GetSecuritySetting(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.SecurityCenter.Models.SecuritySettingName settingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => GetMockableSecurityCenterSubscriptionResource(subscriptionResource).GetSecuritySetting(settingName, cancellationToken);
        /// <summary>
        /// Provides a compatibility shim for the GetMdeOnboardingAsync operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="subscriptionResource">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.Models.MdeOnboarding>> GetMdeOnboardingAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => GetMockableSecurityCenterSubscriptionResource(subscriptionResource).GetMdeOnboardingAsync(cancellationToken);
        /// <summary>
        /// Provides a compatibility shim for the GetAllowedConnectionAsync operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="resourceGroupResource">The value preserved for API compatibility.</param>
        /// <param name="ascLocation">The value preserved for API compatibility.</param>
        /// <param name="connectionType">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.Models.SecurityCenterAllowedConnection>> GetAllowedConnectionAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation ascLocation, Azure.ResourceManager.SecurityCenter.Models.SecurityCenterConnectionType connectionType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => GetMockableSecurityCenterResourceGroupResource(resourceGroupResource).GetAllowedConnectionAsync(ascLocation, connectionType, cancellationToken);
        /// <summary>
        /// Provides a compatibility shim for the GetSecurityCenterLocationAsync operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="subscriptionResource">The value preserved for API compatibility.</param>
        /// <param name="ascLocation">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityCenterLocationResource>> GetSecurityCenterLocationAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation ascLocation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => GetMockableSecurityCenterSubscriptionResource(subscriptionResource).GetSecurityCenterLocationAsync(ascLocation, cancellationToken);
        /// <summary>
        /// Provides a compatibility shim for the GetSecuritySettingAsync operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="subscriptionResource">The value preserved for API compatibility.</param>
        /// <param name="settingName">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecuritySettingResource>> GetSecuritySettingAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.SecurityCenter.Models.SecuritySettingName settingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => GetMockableSecurityCenterSubscriptionResource(subscriptionResource).GetSecuritySettingAsync(settingName, cancellationToken);
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.SecurityCenter
{
    // Generated code only emits operations whose resource scope and request path still exist in TypeSpec; this previous GA method used an old operation path, scope, or overload that no longer maps to a generated request. Keep a hidden ApiCompat shim and fail the unsupported operation explicitly.
    /// <summary>
    /// Provides a compatibility shim for the SecurityCenterExtensions class.
    /// </summary>
    public static partial class SecurityCenterExtensions
    {
        /// <summary>
        /// Provides a compatibility shim for the GetAdaptiveApplicationControlGroupResource operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="client">The value preserved for API compatibility.</param>
        /// <param name="id">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("This API is no longer supported by the service. Use ArmClient.GetAdaptiveApplicationControlGroupResource(ResourceIdentifier id) instead.")]
        public static Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupResource GetAdaptiveApplicationControlGroupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw new System.NotSupportedException("This API is no longer supported by the service. Use ArmClient.GetAdaptiveApplicationControlGroupResource(ResourceIdentifier id) instead."); }
        /// <summary>
        /// Provides a compatibility shim for the GetAdaptiveApplicationControlGroups operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="subscriptionResource">The value preserved for API compatibility.</param>
        /// <param name="includePathRecommendations">The value preserved for API compatibility.</param>
        /// <param name="summary">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("This API is no longer supported by the service. Use SubscriptionResource.GetAdaptiveApplicationControlGroups() instead.")]
        public static Azure.Pageable<Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupResource> GetAdaptiveApplicationControlGroups(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, bool? includePathRecommendations = default(bool?), bool? summary = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. Use SubscriptionResource.GetAdaptiveApplicationControlGroups() instead."); }
        /// <summary>
        /// Provides a compatibility shim for the GetAdaptiveApplicationControlGroupsAsync operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="subscriptionResource">The value preserved for API compatibility.</param>
        /// <param name="includePathRecommendations">The value preserved for API compatibility.</param>
        /// <param name="summary">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("This API is no longer supported by the service. Use SubscriptionResource.GetAdaptiveApplicationControlGroupsAsync() instead.")]
        public static Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupResource> GetAdaptiveApplicationControlGroupsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, bool? includePathRecommendations = default(bool?), bool? summary = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. Use SubscriptionResource.GetAdaptiveApplicationControlGroupsAsync() instead."); }
        /// <summary>
        /// Provides a compatibility shim for the GetAdaptiveNetworkHardening operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="resourceGroupResource">The value preserved for API compatibility.</param>
        /// <param name="resourceNamespace">The value preserved for API compatibility.</param>
        /// <param name="resourceType">The value preserved for API compatibility.</param>
        /// <param name="resourceName">The value preserved for API compatibility.</param>
        /// <param name="adaptiveNetworkHardeningResourceName">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("This API is no longer supported by the service. Use ArmClient.GetAdaptiveNetworkHardeningResource(ResourceIdentifier id) instead.")]
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningResource> GetAdaptiveNetworkHardening(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceNamespace, string resourceType, string resourceName, string adaptiveNetworkHardeningResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. Use ArmClient.GetAdaptiveNetworkHardeningResource(ResourceIdentifier id) instead."); }
        /// <summary>
        /// Provides a compatibility shim for the GetAdaptiveNetworkHardeningAsync operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="resourceGroupResource">The value preserved for API compatibility.</param>
        /// <param name="resourceNamespace">The value preserved for API compatibility.</param>
        /// <param name="resourceType">The value preserved for API compatibility.</param>
        /// <param name="resourceName">The value preserved for API compatibility.</param>
        /// <param name="adaptiveNetworkHardeningResourceName">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("This API is no longer supported by the service. Use ArmClient.GetAdaptiveNetworkHardeningResource(ResourceIdentifier id) instead.")]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningResource>> GetAdaptiveNetworkHardeningAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceNamespace, string resourceType, string resourceName, string adaptiveNetworkHardeningResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. Use ArmClient.GetAdaptiveNetworkHardeningResource(ResourceIdentifier id) instead."); }
        /// <summary>
        /// Provides a compatibility shim for the GetAdaptiveNetworkHardeningResource operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="client">The value preserved for API compatibility.</param>
        /// <param name="id">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("This API is no longer supported by the service. Use ArmClient.GetAdaptiveNetworkHardeningResource(ResourceIdentifier id) instead.")]
        public static Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningResource GetAdaptiveNetworkHardeningResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw new System.NotSupportedException("This API is no longer supported by the service. Use ArmClient.GetAdaptiveNetworkHardeningResource(ResourceIdentifier id) instead."); }
        /// <summary>
        /// Provides a compatibility shim for the GetAdaptiveNetworkHardenings operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="resourceGroupResource">The value preserved for API compatibility.</param>
        /// <param name="resourceNamespace">The value preserved for API compatibility.</param>
        /// <param name="resourceType">The value preserved for API compatibility.</param>
        /// <param name="resourceName">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("This API is no longer supported by the service. No direct collection replacement is available.")]
        public static Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningCollection GetAdaptiveNetworkHardenings(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceNamespace, string resourceType, string resourceName) { throw new System.NotSupportedException("This API is no longer supported by the service. No direct collection replacement is available."); }
        /// <summary>
        /// Provides a compatibility shim for the GetCustomAssessmentAutomation operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="resourceGroupResource">The value preserved for API compatibility.</param>
        /// <param name="customAssessmentAutomationName">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("This API is no longer supported by the service. Use ArmClient.GetCustomAssessmentAutomations(ResourceIdentifier scope) instead.")]
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.CustomAssessmentAutomationResource> GetCustomAssessmentAutomation(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string customAssessmentAutomationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. Use ArmClient.GetCustomAssessmentAutomations(ResourceIdentifier scope) instead."); }
        /// <summary>
        /// Provides a compatibility shim for the GetCustomAssessmentAutomationAsync operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="resourceGroupResource">The value preserved for API compatibility.</param>
        /// <param name="customAssessmentAutomationName">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("This API is no longer supported by the service. Use ArmClient.GetCustomAssessmentAutomations(ResourceIdentifier scope) instead.")]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.CustomAssessmentAutomationResource>> GetCustomAssessmentAutomationAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string customAssessmentAutomationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. Use ArmClient.GetCustomAssessmentAutomations(ResourceIdentifier scope) instead."); }
        /// <summary>
        /// Provides a compatibility shim for the GetCustomAssessmentAutomationResource operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="client">The value preserved for API compatibility.</param>
        /// <param name="id">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("This API is no longer supported by the service. Use ArmClient.GetCustomAssessmentAutomationResource(ResourceIdentifier id) instead.")]
        public static Azure.ResourceManager.SecurityCenter.CustomAssessmentAutomationResource GetCustomAssessmentAutomationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw new System.NotSupportedException("This API is no longer supported by the service. Use ArmClient.GetCustomAssessmentAutomationResource(ResourceIdentifier id) instead."); }
        /// <summary>
        /// Provides a compatibility shim for the GetCustomAssessmentAutomations operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="resourceGroupResource">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("This API is no longer supported by the service. Use ArmClient.GetCustomAssessmentAutomations(ResourceIdentifier scope) instead.")]
        public static Azure.ResourceManager.SecurityCenter.CustomAssessmentAutomationCollection GetCustomAssessmentAutomations(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw new System.NotSupportedException("This API is no longer supported by the service. Use ArmClient.GetCustomAssessmentAutomations(ResourceIdentifier scope) instead."); }
        /// <summary>
        /// Provides a compatibility shim for the GetCustomAssessmentAutomations operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="subscriptionResource">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("This API is no longer supported by the service. Use ArmClient.GetCustomAssessmentAutomations(ResourceIdentifier scope) instead.")]
        public static Azure.Pageable<Azure.ResourceManager.SecurityCenter.CustomAssessmentAutomationResource> GetCustomAssessmentAutomations(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. Use ArmClient.GetCustomAssessmentAutomations(ResourceIdentifier scope) instead."); }
        /// <summary>
        /// Provides a compatibility shim for the GetCustomAssessmentAutomationsAsync operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="subscriptionResource">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("This API is no longer supported by the service. Use ArmClient.GetCustomAssessmentAutomations(ResourceIdentifier scope) instead.")]
        public static Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.CustomAssessmentAutomationResource> GetCustomAssessmentAutomationsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. Use ArmClient.GetCustomAssessmentAutomations(ResourceIdentifier scope) instead."); }
        /// <summary>
        /// Provides a compatibility shim for the GetCustomEntityStoreAssignment operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="resourceGroupResource">The value preserved for API compatibility.</param>
        /// <param name="customEntityStoreAssignmentName">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("This API is no longer supported by the service. Use ArmClient.GetCustomEntityStoreAssignments(ResourceIdentifier scope) instead.")]
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentResource> GetCustomEntityStoreAssignment(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string customEntityStoreAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. Use ArmClient.GetCustomEntityStoreAssignments(ResourceIdentifier scope) instead."); }
        /// <summary>
        /// Provides a compatibility shim for the GetCustomEntityStoreAssignmentAsync operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="resourceGroupResource">The value preserved for API compatibility.</param>
        /// <param name="customEntityStoreAssignmentName">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("This API is no longer supported by the service. Use ArmClient.GetCustomEntityStoreAssignments(ResourceIdentifier scope) instead.")]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentResource>> GetCustomEntityStoreAssignmentAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string customEntityStoreAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. Use ArmClient.GetCustomEntityStoreAssignments(ResourceIdentifier scope) instead."); }
        /// <summary>
        /// Provides a compatibility shim for the GetCustomEntityStoreAssignmentResource operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="client">The value preserved for API compatibility.</param>
        /// <param name="id">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("This API is no longer supported by the service. Use ArmClient.GetCustomEntityStoreAssignmentResource(ResourceIdentifier id) instead.")]
        public static Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentResource GetCustomEntityStoreAssignmentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw new System.NotSupportedException("This API is no longer supported by the service. Use ArmClient.GetCustomEntityStoreAssignmentResource(ResourceIdentifier id) instead."); }
        /// <summary>
        /// Provides a compatibility shim for the GetCustomEntityStoreAssignments operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="resourceGroupResource">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("This API is no longer supported by the service. Use ArmClient.GetCustomEntityStoreAssignments(ResourceIdentifier scope) instead.")]
        public static Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentCollection GetCustomEntityStoreAssignments(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw new System.NotSupportedException("This API is no longer supported by the service. Use ArmClient.GetCustomEntityStoreAssignments(ResourceIdentifier scope) instead."); }
        /// <summary>
        /// Provides a compatibility shim for the GetCustomEntityStoreAssignments operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="subscriptionResource">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("This API is no longer supported by the service. Use ArmClient.GetCustomEntityStoreAssignments(ResourceIdentifier scope) instead.")]
        public static Azure.Pageable<Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentResource> GetCustomEntityStoreAssignments(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. Use ArmClient.GetCustomEntityStoreAssignments(ResourceIdentifier scope) instead."); }
        /// <summary>
        /// Provides a compatibility shim for the GetCustomEntityStoreAssignmentsAsync operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="subscriptionResource">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("This API is no longer supported by the service. Use ArmClient.GetCustomEntityStoreAssignments(ResourceIdentifier scope) instead.")]
        public static Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentResource> GetCustomEntityStoreAssignmentsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. Use ArmClient.GetCustomEntityStoreAssignments(ResourceIdentifier scope) instead."); }
        /// <summary>
        /// Provides a compatibility shim for the GetSecurityCloudConnector operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="subscriptionResource">The value preserved for API compatibility.</param>
        /// <param name="connectorName">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("This API is no longer supported by the service. Use ArmClient.GetSecurityCloudConnectorResource(ResourceIdentifier id) instead.")]
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorResource> GetSecurityCloudConnector(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. Use ArmClient.GetSecurityCloudConnectorResource(ResourceIdentifier id) instead."); }
        /// <summary>
        /// Provides a compatibility shim for the GetSecurityCloudConnectorAsync operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="subscriptionResource">The value preserved for API compatibility.</param>
        /// <param name="connectorName">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("This API is no longer supported by the service. Use ArmClient.GetSecurityCloudConnectorResource(ResourceIdentifier id) instead.")]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorResource>> GetSecurityCloudConnectorAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. Use ArmClient.GetSecurityCloudConnectorResource(ResourceIdentifier id) instead."); }
        /// <summary>
        /// Provides a compatibility shim for the GetSecurityCloudConnectorResource operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="client">The value preserved for API compatibility.</param>
        /// <param name="id">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("This API is no longer supported by the service. Use ArmClient.GetSecurityCloudConnectorResource(ResourceIdentifier id) instead.")]
        public static Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorResource GetSecurityCloudConnectorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw new System.NotSupportedException("This API is no longer supported by the service. Use ArmClient.GetSecurityCloudConnectorResource(ResourceIdentifier id) instead."); }
        /// <summary>
        /// Provides a compatibility shim for the GetSecurityCloudConnectors operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="subscriptionResource">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("This API is no longer supported by the service. No direct collection replacement is available.")]
        public static Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorCollection GetSecurityCloudConnectors(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw new System.NotSupportedException("This API is no longer supported by the service. No direct collection replacement is available."); }
        /// <summary>
        /// Provides a compatibility shim for the GetSoftwareInventories operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="resourceGroupResource">The value preserved for API compatibility.</param>
        /// <param name="resourceNamespace">The value preserved for API compatibility.</param>
        /// <param name="resourceType">The value preserved for API compatibility.</param>
        /// <param name="resourceName">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("This API is no longer supported by the service. No direct replacement is available.")]
        public static Azure.ResourceManager.SecurityCenter.SoftwareInventoryCollection GetSoftwareInventories(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceNamespace, string resourceType, string resourceName) { throw new System.NotSupportedException("This API is no longer supported by the service. No direct replacement is available."); }
        /// <summary>
        /// Provides a compatibility shim for the GetSoftwareInventories operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="subscriptionResource">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("This API is no longer supported by the service. No direct replacement is available.")]
        public static Azure.Pageable<Azure.ResourceManager.SecurityCenter.SoftwareInventoryResource> GetSoftwareInventories(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. No direct replacement is available."); }
        /// <summary>
        /// Provides a compatibility shim for the GetSoftwareInventoriesAsync operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="subscriptionResource">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("This API is no longer supported by the service. No direct replacement is available.")]
        public static Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.SoftwareInventoryResource> GetSoftwareInventoriesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. No direct replacement is available."); }
        /// <summary>
        /// Provides a compatibility shim for the GetSoftwareInventory operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="resourceGroupResource">The value preserved for API compatibility.</param>
        /// <param name="resourceNamespace">The value preserved for API compatibility.</param>
        /// <param name="resourceType">The value preserved for API compatibility.</param>
        /// <param name="resourceName">The value preserved for API compatibility.</param>
        /// <param name="softwareName">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("This API is no longer supported by the service. No direct replacement is available.")]
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.SoftwareInventoryResource> GetSoftwareInventory(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceNamespace, string resourceType, string resourceName, string softwareName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. No direct replacement is available."); }
        /// <summary>
        /// Provides a compatibility shim for the GetSoftwareInventoryAsync operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="resourceGroupResource">The value preserved for API compatibility.</param>
        /// <param name="resourceNamespace">The value preserved for API compatibility.</param>
        /// <param name="resourceType">The value preserved for API compatibility.</param>
        /// <param name="resourceName">The value preserved for API compatibility.</param>
        /// <param name="softwareName">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("This API is no longer supported by the service. No direct replacement is available.")]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SoftwareInventoryResource>> GetSoftwareInventoryAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceNamespace, string resourceType, string resourceName, string softwareName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. No direct replacement is available."); }
        /// <summary>
        /// Provides a compatibility shim for the GetSoftwareInventoryResource operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="client">The value preserved for API compatibility.</param>
        /// <param name="id">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("This API is no longer supported by the service. No direct replacement is available.")]
        public static Azure.ResourceManager.SecurityCenter.SoftwareInventoryResource GetSoftwareInventoryResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw new System.NotSupportedException("This API is no longer supported by the service. No direct replacement is available."); }
    }
}
