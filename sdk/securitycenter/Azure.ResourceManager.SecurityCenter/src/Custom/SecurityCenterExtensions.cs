// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using Azure;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.SecurityCenter.Models;

namespace Azure.ResourceManager.SecurityCenter
{
    // Generated code only emits operations whose resource scope and request path still exist in TypeSpec; this previous GA method used an old operation path, scope, or overload that no longer maps to a generated request. Keep a hidden ApiCompat shim and fail the unsupported operation explicitly.
    // Compatibility customization: GA exposed this resource-id overload without the generated Resource suffix.
    /// <summary>
    /// Provides a compatibility shim for the SecurityCenterExtensions class.
    /// </summary>
    public static partial class SecurityCenterExtensions
    {
        /// <summary>
        /// Provides a compatibility shim for the GetAdvancedThreatProtectionSetting operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="client">The value preserved for API compatibility.</param>
        /// <param name="id">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        public static AdvancedThreatProtectionSettingResource GetAdvancedThreatProtectionSetting(this ArmClient client, ResourceIdentifier id)
        {
            Argument.AssertNotNull(client, nameof(client));

            return GetMockableSecurityCenterArmClient(client).GetAdvancedThreatProtectionSetting(id);
        }
        /// <summary>
        /// Provides a compatibility shim for the GetJitNetworkAccessPolicies operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="resourceGroupResource">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("This API is no longer supported by the service. Use ResourceGroupResource.GetJitNetworkAccessPoliciesByResourceGroup() instead.")]
        public static Pageable<JitNetworkAccessPolicyResource> GetJitNetworkAccessPolicies(this ResourceGroupResource resourceGroupResource, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This API is no longer supported by the service. Use ResourceGroupResource.GetJitNetworkAccessPoliciesByResourceGroup() instead.");
        /// <summary>
        /// Provides a compatibility shim for the GetJitNetworkAccessPoliciesAsync operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="resourceGroupResource">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("This API is no longer supported by the service. Use ResourceGroupResource.GetJitNetworkAccessPoliciesByResourceGroupAsync() instead.")]
        public static AsyncPageable<JitNetworkAccessPolicyResource> GetJitNetworkAccessPoliciesAsync(this ResourceGroupResource resourceGroupResource, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This API is no longer supported by the service. Use ResourceGroupResource.GetJitNetworkAccessPoliciesByResourceGroupAsync() instead.");
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
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("This API is no longer supported by the service. Use ArmClient.GetGovernanceRuleResource(ResourceIdentifier id) instead.")]
        public static SecurityConnectorGovernanceRuleResource GetSecurityConnectorGovernanceRuleResource(this ArmClient client, ResourceIdentifier id)
            => throw new NotSupportedException("This API is no longer supported by the service. Use ArmClient.GetGovernanceRuleResource(ResourceIdentifier id) instead.");
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
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("This API is no longer supported by the service. Use SecurityCenterLocationResource.GetDiscoveredSecuritySolutionsByHomeRegion() or SubscriptionResource.GetDiscoveredSecuritySolutions() instead.")]
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.Models.DiscoveredSecuritySolution> GetDiscoveredSecuritySolution(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation ascLocation, string discoveredSecuritySolutionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. Use SecurityCenterLocationResource.GetDiscoveredSecuritySolutionsByHomeRegion() or SubscriptionResource.GetDiscoveredSecuritySolutions() instead."); }
        /// <summary>
        /// Provides a compatibility shim for the GetDiscoveredSecuritySolutionAsync operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="resourceGroupResource">The value preserved for API compatibility.</param>
        /// <param name="ascLocation">The value preserved for API compatibility.</param>
        /// <param name="discoveredSecuritySolutionName">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("This API is no longer supported by the service. Use SecurityCenterLocationResource.GetDiscoveredSecuritySolutionsByHomeRegionAsync() or SubscriptionResource.GetDiscoveredSecuritySolutionsAsync() instead.")]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.Models.DiscoveredSecuritySolution>> GetDiscoveredSecuritySolutionAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation ascLocation, string discoveredSecuritySolutionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. Use SecurityCenterLocationResource.GetDiscoveredSecuritySolutionsByHomeRegionAsync() or SubscriptionResource.GetDiscoveredSecuritySolutionsAsync() instead."); }
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
        [System.Obsolete("This API is no longer supported by the service. Use ResourceGroupResource.Get(AzureLocation ascLocation, string externalSecuritySolutionsName) or SubscriptionResource.GetExternalSecuritySolutions() instead.")]
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.Models.ExternalSecuritySolution> GetExternalSecuritySolution(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation ascLocation, string externalSecuritySolutionsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. Use ResourceGroupResource.Get(AzureLocation ascLocation, string externalSecuritySolutionsName) or SubscriptionResource.GetExternalSecuritySolutions() instead."); }
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
        [System.Obsolete("This API is no longer supported by the service. Use ResourceGroupResource.GetAsync(AzureLocation ascLocation, string externalSecuritySolutionsName) or SubscriptionResource.GetExternalSecuritySolutionsAsync() instead.")]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.Models.ExternalSecuritySolution>> GetExternalSecuritySolutionAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation ascLocation, string externalSecuritySolutionsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. Use ResourceGroupResource.GetAsync(AzureLocation ascLocation, string externalSecuritySolutionsName) or SubscriptionResource.GetExternalSecuritySolutionsAsync() instead."); }
        /// <summary>
        /// Provides a compatibility shim for the GetSecurityCenterPricing operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="subscriptionResource">The value preserved for API compatibility.</param>
        /// <param name="pricingName">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("This API is no longer supported by the service. Use ArmClient.GetSecurityCenterPricing(ResourceIdentifier scope, string pricingName) instead.")]
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityCenterPricingResource> GetSecurityCenterPricing(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string pricingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. Use ArmClient.GetSecurityCenterPricing(ResourceIdentifier scope, string pricingName) instead."); }
        /// <summary>
        /// Provides a compatibility shim for the GetSecurityCenterPricingAsync operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="subscriptionResource">The value preserved for API compatibility.</param>
        /// <param name="pricingName">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("This API is no longer supported by the service. Use ArmClient.GetSecurityCenterPricingAsync(ResourceIdentifier scope, string pricingName) instead.")]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityCenterPricingResource>> GetSecurityCenterPricingAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string pricingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. Use ArmClient.GetSecurityCenterPricingAsync(ResourceIdentifier scope, string pricingName) instead."); }
        /// <summary>
        /// Provides a compatibility shim for the GetSecurityContact operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="subscriptionResource">The value preserved for API compatibility.</param>
        /// <param name="securityContactName">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("This API is no longer supported by the service. Use SubscriptionResource.GetSecurityContacts().Get(securityContactName) instead.")]
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityContactResource> GetSecurityContact(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string securityContactName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. Use SubscriptionResource.GetSecurityContacts().Get(securityContactName) instead."); }
        /// <summary>
        /// Provides a compatibility shim for the GetSecurityContactAsync operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="subscriptionResource">The value preserved for API compatibility.</param>
        /// <param name="securityContactName">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("This API is no longer supported by the service. Use SubscriptionResource.GetSecurityContacts().GetAsync(securityContactName) instead.")]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityContactResource>> GetSecurityContactAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string securityContactName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. Use SubscriptionResource.GetSecurityContacts().GetAsync(securityContactName) instead."); }
        /// <summary>
        /// Provides a compatibility shim for the GetSecuritySolution operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="resourceGroupResource">The value preserved for API compatibility.</param>
        /// <param name="ascLocation">The value preserved for API compatibility.</param>
        /// <param name="securitySolutionName">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("This API is no longer supported by the service. Use ResourceGroupResource.GetSecuritySolution(AzureLocation ascLocation, string securitySolutionName) or SubscriptionResource.GetSecuritySolutions() instead.")]
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.Models.SecuritySolution> GetSecuritySolution(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation ascLocation, string securitySolutionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. Use ResourceGroupResource.GetSecuritySolution(AzureLocation ascLocation, string securitySolutionName) or SubscriptionResource.GetSecuritySolutions() instead."); }
        /// <summary>
        /// Provides a compatibility shim for the GetSecuritySolutionAsync operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="resourceGroupResource">The value preserved for API compatibility.</param>
        /// <param name="ascLocation">The value preserved for API compatibility.</param>
        /// <param name="securitySolutionName">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("This API is no longer supported by the service. Use ResourceGroupResource.GetSecuritySolutionAsync(AzureLocation ascLocation, string securitySolutionName) or SubscriptionResource.GetSecuritySolutionsAsync() instead.")]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.Models.SecuritySolution>> GetSecuritySolutionAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation ascLocation, string securitySolutionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. Use ResourceGroupResource.GetSecuritySolutionAsync(AzureLocation ascLocation, string securitySolutionName) or SubscriptionResource.GetSecuritySolutionsAsync() instead."); }
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
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("This API is no longer supported by the service. Use ArmClient.GetServerVulnerabilityAssessment(ResourceIdentifier scope) instead.")]
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.ServerVulnerabilityAssessmentResource> GetServerVulnerabilityAssessment(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceNamespace, string resourceType, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. Use ArmClient.GetServerVulnerabilityAssessment(ResourceIdentifier scope) instead."); }
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
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("This API is no longer supported by the service. Use ArmClient.GetServerVulnerabilityAssessment(ResourceIdentifier scope) instead.")]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.ServerVulnerabilityAssessmentResource>> GetServerVulnerabilityAssessmentAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceNamespace, string resourceType, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. Use ArmClient.GetServerVulnerabilityAssessment(ResourceIdentifier scope) instead."); }
        /// <summary>
        /// Provides a compatibility shim for the GetServerVulnerabilityAssessments operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="resourceGroupResource">The value preserved for API compatibility.</param>
        /// <param name="resourceNamespace">The value preserved for API compatibility.</param>
        /// <param name="resourceType">The value preserved for API compatibility.</param>
        /// <param name="resourceName">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("This API is no longer supported by the service. Use ArmClient.GetServerVulnerabilityAssessment(ResourceIdentifier scope) instead.")]
        public static Azure.ResourceManager.SecurityCenter.ServerVulnerabilityAssessmentCollection GetServerVulnerabilityAssessments(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceNamespace, string resourceType, string resourceName) { throw new System.NotSupportedException("This API is no longer supported by the service. Use ArmClient.GetServerVulnerabilityAssessment(ResourceIdentifier scope) instead."); }
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
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("This API is no longer supported by the service. Use ArmClient.GetSqlVulnerabilityAssessmentBaselineRules(ResourceIdentifier scope) instead.")]
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.SqlVulnerabilityAssessmentBaselineRuleResource> GetSqlVulnerabilityAssessmentBaselineRule(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string ruleId, System.Guid workspaceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. Use ArmClient.GetSqlVulnerabilityAssessmentBaselineRules(ResourceIdentifier scope) instead."); }
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
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("This API is no longer supported by the service. Use ArmClient.GetSqlVulnerabilityAssessmentBaselineRules(ResourceIdentifier scope) instead.")]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SqlVulnerabilityAssessmentBaselineRuleResource>> GetSqlVulnerabilityAssessmentBaselineRuleAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string ruleId, System.Guid workspaceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. Use ArmClient.GetSqlVulnerabilityAssessmentBaselineRules(ResourceIdentifier scope) instead."); }
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
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("This API is no longer supported by the service. Use ArmClient.GetSqlVulnerabilityAssessmentScans(ResourceIdentifier scope) instead.")]
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.SqlVulnerabilityAssessmentScanResource> GetSqlVulnerabilityAssessmentScan(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string scanId, System.Guid workspaceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. Use ArmClient.GetSqlVulnerabilityAssessmentScans(ResourceIdentifier scope) instead."); }
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
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("This API is no longer supported by the service. Use ArmClient.GetSqlVulnerabilityAssessmentScans(ResourceIdentifier scope) instead.")]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SqlVulnerabilityAssessmentScanResource>> GetSqlVulnerabilityAssessmentScanAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string scanId, System.Guid workspaceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. Use ArmClient.GetSqlVulnerabilityAssessmentScans(ResourceIdentifier scope) instead."); }
        /// <summary>
        /// Provides a compatibility shim for the GetSubscriptionGovernanceRule operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="subscriptionResource">The value preserved for API compatibility.</param>
        /// <param name="ruleId">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("This API is no longer supported by the service. Use ArmClient.GetGovernanceRules(ResourceIdentifier scope) instead.")]
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.SubscriptionGovernanceRuleResource> GetSubscriptionGovernanceRule(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string ruleId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. Use ArmClient.GetGovernanceRules(ResourceIdentifier scope) instead."); }
        /// <summary>
        /// Provides a compatibility shim for the GetSubscriptionGovernanceRuleAsync operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="subscriptionResource">The value preserved for API compatibility.</param>
        /// <param name="ruleId">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("This API is no longer supported by the service. Use ArmClient.GetGovernanceRules(ResourceIdentifier scope) instead.")]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SubscriptionGovernanceRuleResource>> GetSubscriptionGovernanceRuleAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string ruleId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. Use ArmClient.GetGovernanceRules(ResourceIdentifier scope) instead."); }
        /// <summary>
        /// Provides a compatibility shim for the GetTopology operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="resourceGroupResource">The value preserved for API compatibility.</param>
        /// <param name="ascLocation">The value preserved for API compatibility.</param>
        /// <param name="topologyResourceName">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("This API is no longer supported by the service. Use ResourceGroupResource.GetTopology(AzureLocation ascLocation, string topologyResourceName) or SubscriptionResource.GetTopologies() instead.")]
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.Models.SecurityTopologyResource> GetTopology(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation ascLocation, string topologyResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. Use ResourceGroupResource.GetTopology(AzureLocation ascLocation, string topologyResourceName) or SubscriptionResource.GetTopologies() instead."); }
        /// <summary>
        /// Provides a compatibility shim for the GetTopologyAsync operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="resourceGroupResource">The value preserved for API compatibility.</param>
        /// <param name="ascLocation">The value preserved for API compatibility.</param>
        /// <param name="topologyResourceName">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("This API is no longer supported by the service. Use ResourceGroupResource.GetTopologyAsync(AzureLocation ascLocation, string topologyResourceName) or SubscriptionResource.GetTopologiesAsync() instead.")]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.Models.SecurityTopologyResource>> GetTopologyAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation ascLocation, string topologyResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. Use ResourceGroupResource.GetTopologyAsync(AzureLocation ascLocation, string topologyResourceName) or SubscriptionResource.GetTopologiesAsync() instead."); }
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
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("This API is no longer supported by the service. Use SecurityCenterLocationResource.GetSubscriptionSecurityAlerts().GetAllAsync() instead.")]
        public static Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.SecurityAlertData> GetAlertsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. Use SecurityCenterLocationResource.GetSubscriptionSecurityAlerts().GetAllAsync() instead."); }
        /// <summary>
        /// Provides a compatibility shim for the GetAlertsByResourceGroupAsync operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="resourceGroupResource">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("This API is no longer supported by the service. Use ResourceGroupResource.GetResourceGroupSecurityAlerts(AzureLocation ascLocation).GetAllAsync() instead.")]
        public static Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.SecurityAlertData> GetAlertsByResourceGroupAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. Use ResourceGroupResource.GetResourceGroupSecurityAlerts(AzureLocation ascLocation).GetAllAsync() instead."); }
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
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("This API is no longer supported by the service. Use SecurityCenterLocationResource.GetSubscriptionSecurityAlerts().GetAll() instead.")]
        public static Azure.Pageable<Azure.ResourceManager.SecurityCenter.SecurityAlertData> GetAlerts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. Use SecurityCenterLocationResource.GetSubscriptionSecurityAlerts().GetAll() instead."); }
        /// <summary>
        /// Provides a compatibility shim for the GetAlertsByResourceGroup operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="resourceGroupResource">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("This API is no longer supported by the service. Use ResourceGroupResource.GetResourceGroupSecurityAlerts(AzureLocation ascLocation).GetAll() instead.")]
        public static Azure.Pageable<Azure.ResourceManager.SecurityCenter.SecurityAlertData> GetAlertsByResourceGroup(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. Use ResourceGroupResource.GetResourceGroupSecurityAlerts(AzureLocation ascLocation).GetAll() instead."); }
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
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("This API is no longer supported by the service. Use ArmClient.GetSecurityCenterPricings(ResourceIdentifier scope) instead.")]
        public static Azure.ResourceManager.SecurityCenter.SecurityCenterPricingCollection GetSecurityCenterPricings(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw new System.NotSupportedException("This API is no longer supported by the service. Use ArmClient.GetSecurityCenterPricings(ResourceIdentifier scope) instead."); }
        /// <summary>
        /// Provides a compatibility shim for the GetSubscriptionGovernanceRules operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="subscriptionResource">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("This API is no longer supported by the service. Use ArmClient.GetGovernanceRules(ResourceIdentifier scope) instead.")]
        public static Azure.ResourceManager.SecurityCenter.SubscriptionGovernanceRuleCollection GetSubscriptionGovernanceRules(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw new System.NotSupportedException("This API is no longer supported by the service. Use ArmClient.GetGovernanceRules(ResourceIdentifier scope) instead."); }
        /// <summary>
        /// Provides a compatibility shim for the GetSubscriptionGovernanceRuleResource operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="client">The value preserved for API compatibility.</param>
        /// <param name="id">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("This API is no longer supported by the service. Use ArmClient.GetGovernanceRuleResource(ResourceIdentifier id) instead.")]
        public static Azure.ResourceManager.SecurityCenter.SubscriptionGovernanceRuleResource GetSubscriptionGovernanceRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw new System.NotSupportedException("This API is no longer supported by the service. Use ArmClient.GetGovernanceRuleResource(ResourceIdentifier id) instead."); }
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
        [System.Obsolete("This API is no longer supported by the service. Use SubscriptionResource.GetMdeOnboardingData() instead.")]
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.Models.MdeOnboarding> GetMdeOnboarding(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. Use SubscriptionResource.GetMdeOnboardingData() instead."); }
        /// <summary>
        /// Provides a compatibility shim for the GetAllowedConnection operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="resourceGroupResource">The value preserved for API compatibility.</param>
        /// <param name="ascLocation">The value preserved for API compatibility.</param>
        /// <param name="connectionType">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("This API is no longer supported by the service. No direct replacement is available.")]
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.Models.SecurityCenterAllowedConnection> GetAllowedConnection(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation ascLocation, Azure.ResourceManager.SecurityCenter.Models.SecurityCenterConnectionType connectionType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. No direct replacement is available."); }
        /// <summary>
        /// Provides a compatibility shim for the GetSecurityCenterLocation operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="subscriptionResource">The value preserved for API compatibility.</param>
        /// <param name="ascLocation">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("This API is no longer supported by the service. Use SubscriptionResource.GetSecurityCenterLocations().Get(ascLocation) instead.")]
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityCenterLocationResource> GetSecurityCenterLocation(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation ascLocation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. Use SubscriptionResource.GetSecurityCenterLocations().Get(ascLocation) instead."); }
        /// <summary>
        /// Provides a compatibility shim for the GetSecuritySetting operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="subscriptionResource">The value preserved for API compatibility.</param>
        /// <param name="settingName">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("This API is no longer supported by the service. Use SubscriptionResource.GetSecuritySettings().Get(settingName) instead.")]
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.SecuritySettingResource> GetSecuritySetting(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.SecurityCenter.Models.SecuritySettingName settingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. Use SubscriptionResource.GetSecuritySettings().Get(settingName) instead."); }
        /// <summary>
        /// Provides a compatibility shim for the GetMdeOnboardingAsync operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="subscriptionResource">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("This API is no longer supported by the service. Use SubscriptionResource.GetMdeOnboardingData() instead.")]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.Models.MdeOnboarding>> GetMdeOnboardingAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. Use SubscriptionResource.GetMdeOnboardingData() instead."); }
        /// <summary>
        /// Provides a compatibility shim for the GetAllowedConnectionAsync operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="resourceGroupResource">The value preserved for API compatibility.</param>
        /// <param name="ascLocation">The value preserved for API compatibility.</param>
        /// <param name="connectionType">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("This API is no longer supported by the service. No direct replacement is available.")]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.Models.SecurityCenterAllowedConnection>> GetAllowedConnectionAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation ascLocation, Azure.ResourceManager.SecurityCenter.Models.SecurityCenterConnectionType connectionType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. No direct replacement is available."); }
        /// <summary>
        /// Provides a compatibility shim for the GetSecurityCenterLocationAsync operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="subscriptionResource">The value preserved for API compatibility.</param>
        /// <param name="ascLocation">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("This API is no longer supported by the service. Use SubscriptionResource.GetSecurityCenterLocations().GetAsync(ascLocation) instead.")]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityCenterLocationResource>> GetSecurityCenterLocationAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation ascLocation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. Use SubscriptionResource.GetSecurityCenterLocations().GetAsync(ascLocation) instead."); }
        /// <summary>
        /// Provides a compatibility shim for the GetSecuritySettingAsync operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="subscriptionResource">The value preserved for API compatibility.</param>
        /// <param name="settingName">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("This API is no longer supported by the service. Use SubscriptionResource.GetSecuritySettings().GetAsync(settingName) instead.")]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecuritySettingResource>> GetSecuritySettingAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.SecurityCenter.Models.SecuritySettingName settingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. Use SubscriptionResource.GetSecuritySettings().GetAsync(settingName) instead."); }
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
