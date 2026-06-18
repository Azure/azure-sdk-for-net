// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591 // Hidden compatibility shims do not need public docs.

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
    // Compatibility customization: GA exposed this resource-id overload without the generated Resource suffix.
    public static partial class SecurityCenterExtensions
    {
        /// <summary> Gets an object representing a <see cref="AdvancedThreatProtectionSettingResource"/> along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="client"> The <see cref="ArmClient"/> the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="client"/> is null. </exception>
        /// <returns> Returns a <see cref="AdvancedThreatProtectionSettingResource"/> object. </returns>
        public static AdvancedThreatProtectionSettingResource GetAdvancedThreatProtectionSetting(this ArmClient client, ResourceIdentifier id)
        {
            Argument.AssertNotNull(client, nameof(client));

            return GetMockableSecurityCenterArmClient(client).GetAdvancedThreatProtectionSetting(id);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<JitNetworkAccessPolicyResource> GetJitNetworkAccessPolicies(this ResourceGroupResource resourceGroupResource, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This API is no longer supported by the service.");

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<JitNetworkAccessPolicyResource> GetJitNetworkAccessPoliciesAsync(this ResourceGroupResource resourceGroupResource, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This API is no longer supported by the service.");

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<SecureScoreControlDetails> GetSecureScoreControlsAsync(this SubscriptionResource subscriptionResource, SecurityScoreODataExpand? expand = default, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This API is no longer supported by the service.");

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SecurityConnectorGovernanceRuleResource GetSecurityConnectorGovernanceRuleResource(this ArmClient client, ResourceIdentifier id)
            => throw new NotSupportedException("This API is no longer supported by the service.");
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS0618
#pragma warning disable CS1591
#pragma warning disable CS0169
#pragma warning disable SA1508
#pragma warning disable SA1516
#pragma warning disable CA1822

namespace Azure.ResourceManager.SecurityCenter
{
    public static partial class SecurityCenterExtensions
    {
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.Models.DiscoveredSecuritySolution> GetDiscoveredSecuritySolution(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation ascLocation, string discoveredSecuritySolutionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.Models.DiscoveredSecuritySolution>> GetDiscoveredSecuritySolutionAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation ascLocation, string discoveredSecuritySolutionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.Models.ExternalSecuritySolution> GetExternalSecuritySolution(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation ascLocation, string externalSecuritySolutionsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.Models.ExternalSecuritySolution>> GetExternalSecuritySolutionAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation ascLocation, string externalSecuritySolutionsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
[Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityCenterPricingResource> GetSecurityCenterPricing(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string pricingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityCenterPricingResource>> GetSecurityCenterPricingAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string pricingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityContactResource> GetSecurityContact(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string securityContactName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityContactResource>> GetSecurityContactAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string securityContactName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.Models.SecuritySolution> GetSecuritySolution(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation ascLocation, string securitySolutionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.Models.SecuritySolution>> GetSecuritySolutionAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation ascLocation, string securitySolutionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.ServerVulnerabilityAssessmentResource> GetServerVulnerabilityAssessment(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceNamespace, string resourceType, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.ServerVulnerabilityAssessmentResource>> GetServerVulnerabilityAssessmentAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceNamespace, string resourceType, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.SecurityCenter.ServerVulnerabilityAssessmentCollection GetServerVulnerabilityAssessments(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceNamespace, string resourceType, string resourceName) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.SqlVulnerabilityAssessmentBaselineRuleResource> GetSqlVulnerabilityAssessmentBaselineRule(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string ruleId, System.Guid workspaceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SqlVulnerabilityAssessmentBaselineRuleResource>> GetSqlVulnerabilityAssessmentBaselineRuleAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string ruleId, System.Guid workspaceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.SqlVulnerabilityAssessmentScanResource> GetSqlVulnerabilityAssessmentScan(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string scanId, System.Guid workspaceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SqlVulnerabilityAssessmentScanResource>> GetSqlVulnerabilityAssessmentScanAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string scanId, System.Guid workspaceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.SubscriptionGovernanceRuleResource> GetSubscriptionGovernanceRule(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string ruleId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SubscriptionGovernanceRuleResource>> GetSubscriptionGovernanceRuleAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string ruleId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
[Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.Models.SecurityTopologyResource> GetTopology(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation ascLocation, string topologyResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.Models.SecurityTopologyResource>> GetTopologyAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation ascLocation, string topologyResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS0618
#pragma warning disable CS1591
#pragma warning disable CS0169
#pragma warning disable SA1508
#pragma warning disable SA1516
#pragma warning disable CA1822

namespace Azure.ResourceManager.SecurityCenter
{
    public static partial class SecurityCenterExtensions
    {
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.Models.MdeOnboarding> GetMdeOnboardingsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.Models.SecuritySolutionsReferenceData> GetAllSecuritySolutionsReferenceDataAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.SecurityAlertData> GetAlertsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.SecurityAlertData> GetAlertsByResourceGroupAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Pageable<Azure.ResourceManager.SecurityCenter.Models.MdeOnboarding> GetMdeOnboardings(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Pageable<Azure.ResourceManager.SecurityCenter.Models.SecuritySolutionsReferenceData> GetAllSecuritySolutionsReferenceData(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Pageable<Azure.ResourceManager.SecurityCenter.SecurityAlertData> GetAlerts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Pageable<Azure.ResourceManager.SecurityCenter.SecurityAlertData> GetAlertsByResourceGroup(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static Azure.Pageable<Azure.ResourceManager.SecurityCenter.Models.SecureScoreControlDetails> GetSecureScoreControls(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.SecurityCenter.Models.SecurityScoreODataExpand? expand = default(Azure.ResourceManager.SecurityCenter.Models.SecurityScoreODataExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.SecurityCenter.SecurityCenterPricingCollection GetSecurityCenterPricings(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.SecurityCenter.SubscriptionGovernanceRuleCollection GetSubscriptionGovernanceRules(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.SecurityCenter.SubscriptionGovernanceRuleResource GetSubscriptionGovernanceRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw new System.NotSupportedException("This API is no longer supported by the service."); }

        [Azure.Core.ForwardsClientCalls]
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityAssessmentResource> GetSecurityAssessment(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string assessmentName, Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentODataExpand? expand = default(Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentODataExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityAssessmentResource>> GetSecurityAssessmentAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string assessmentName, Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentODataExpand? expand = default(Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentODataExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.Models.MdeOnboarding> GetMdeOnboarding(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.Models.SecurityCenterAllowedConnection> GetAllowedConnection(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation ascLocation, Azure.ResourceManager.SecurityCenter.Models.SecurityCenterConnectionType connectionType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityCenterLocationResource> GetSecurityCenterLocation(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation ascLocation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.SecuritySettingResource> GetSecuritySetting(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.SecurityCenter.Models.SecuritySettingName settingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.Models.MdeOnboarding>> GetMdeOnboardingAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.Models.SecurityCenterAllowedConnection>> GetAllowedConnectionAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation ascLocation, Azure.ResourceManager.SecurityCenter.Models.SecurityCenterConnectionType connectionType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityCenterLocationResource>> GetSecurityCenterLocationAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation ascLocation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecuritySettingResource>> GetSecuritySettingAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.SecurityCenter.Models.SecuritySettingName settingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS0618
#pragma warning disable CS1591
#pragma warning disable CS0169
#pragma warning disable SA1508
#pragma warning disable SA1516
#pragma warning disable CA1822

namespace Azure.ResourceManager.SecurityCenter
{
public static partial class SecurityCenterExtensions
    {
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupResource GetAdaptiveApplicationControlGroupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Pageable<Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupResource> GetAdaptiveApplicationControlGroups(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, bool? includePathRecommendations = default(bool?), bool? summary = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupResource> GetAdaptiveApplicationControlGroupsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, bool? includePathRecommendations = default(bool?), bool? summary = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningResource> GetAdaptiveNetworkHardening(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceNamespace, string resourceType, string resourceName, string adaptiveNetworkHardeningResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningResource>> GetAdaptiveNetworkHardeningAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceNamespace, string resourceType, string resourceName, string adaptiveNetworkHardeningResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningResource GetAdaptiveNetworkHardeningResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningCollection GetAdaptiveNetworkHardenings(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceNamespace, string resourceType, string resourceName) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.CustomAssessmentAutomationResource> GetCustomAssessmentAutomation(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string customAssessmentAutomationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.CustomAssessmentAutomationResource>> GetCustomAssessmentAutomationAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string customAssessmentAutomationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.SecurityCenter.CustomAssessmentAutomationResource GetCustomAssessmentAutomationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.SecurityCenter.CustomAssessmentAutomationCollection GetCustomAssessmentAutomations(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Pageable<Azure.ResourceManager.SecurityCenter.CustomAssessmentAutomationResource> GetCustomAssessmentAutomations(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.CustomAssessmentAutomationResource> GetCustomAssessmentAutomationsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentResource> GetCustomEntityStoreAssignment(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string customEntityStoreAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentResource>> GetCustomEntityStoreAssignmentAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string customEntityStoreAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentResource GetCustomEntityStoreAssignmentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentCollection GetCustomEntityStoreAssignments(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Pageable<Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentResource> GetCustomEntityStoreAssignments(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentResource> GetCustomEntityStoreAssignmentsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorResource> GetSecurityCloudConnector(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorResource>> GetSecurityCloudConnectorAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorResource GetSecurityCloudConnectorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorCollection GetSecurityCloudConnectors(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.SecurityCenter.SoftwareInventoryCollection GetSoftwareInventories(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceNamespace, string resourceType, string resourceName) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Pageable<Azure.ResourceManager.SecurityCenter.SoftwareInventoryResource> GetSoftwareInventories(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.SoftwareInventoryResource> GetSoftwareInventoriesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.SoftwareInventoryResource> GetSoftwareInventory(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceNamespace, string resourceType, string resourceName, string softwareName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SoftwareInventoryResource>> GetSoftwareInventoryAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceNamespace, string resourceType, string resourceName, string softwareName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.SecurityCenter.SoftwareInventoryResource GetSoftwareInventoryResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }
}
