// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CA1822 // Compatibility instance members intentionally preserve previous signatures.
#pragma warning disable CS1591 // Hidden obsolete compatibility shims do not need public docs.

using System;
using System.ClientModel.Primitives;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.SecurityCenter;
using Azure.ResourceManager.SecurityCenter.Mocking;
using Azure.ResourceManager.SecurityCenter.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.SecurityCenter
{
    public static partial class SecurityCenterExtensions
    {
        // Backward compatibility for legacy provider-action list methods that are now generated as resource-returning APIs.
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<JitNetworkAccessPolicyResource> GetJitNetworkAccessPoliciesAsync(this ResourceGroupResource resourceGroupResource, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<DiscoveredSecuritySolution> GetDiscoveredSecuritySolutionsAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<SecurityCenterAllowedConnection> GetAllowedConnectionsAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<SecuritySolution> GetSecuritySolutionsAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<SecurityTopologyResource> GetTopologiesAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<JitNetworkAccessPolicyResource> GetJitNetworkAccessPolicies(this ResourceGroupResource resourceGroupResource, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<DiscoveredSecuritySolution> GetDiscoveredSecuritySolutions(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<SecurityCenterAllowedConnection> GetAllowedConnections(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<SecuritySolution> GetSecuritySolutions(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<SecurityTopologyResource> GetTopologies(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static JitNetworkAccessPolicyCollection GetJitNetworkAccessPolicies(this ResourceGroupResource resourceGroupResource, AzureLocation ascLocation)
            => GetMockableSecurityCenterResourceGroupResource(resourceGroupResource).GetJitNetworkAccessPolicies(ascLocation);
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<MdeOnboarding> GetMdeOnboardingsAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<Models.SecuritySolutionsReferenceData> GetAllSecuritySolutionsReferenceDataAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<SecurityAlertData> GetAlertsAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<SecurityAlertData> GetAlertsByResourceGroupAsync(this ResourceGroupResource resourceGroupResource, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<MdeOnboarding> GetMdeOnboardings(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<Models.SecuritySolutionsReferenceData> GetAllSecuritySolutionsReferenceData(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<SecurityAlertData> GetAlerts(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<SecurityAlertData> GetAlertsByResourceGroup(this ResourceGroupResource resourceGroupResource, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ResourceGroupSecurityAlertCollection GetResourceGroupSecurityAlerts(this ResourceGroupResource resourceGroupResource, AzureLocation ascLocation) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ResourceGroupSecurityTaskCollection GetResourceGroupSecurityTasks(this ResourceGroupResource resourceGroupResource, AzureLocation ascLocation) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [ForwardsClientCalls]
        public static JitNetworkAccessPolicyCollection GetJitNetworkAccessPolicies(this ResourceGroupResource resourceGroupResource, string ascLocation)
            => GetMockableSecurityCenterResourceGroupResource(resourceGroupResource).GetJitNetworkAccessPolicies(ascLocation);
        [ForwardsClientCalls]
        public static ResourceGroupSecurityAlertCollection GetResourceGroupSecurityAlerts(this ResourceGroupResource resourceGroupResource, string ascLocation)
            => GetMockableSecurityCenterResourceGroupResource(resourceGroupResource).GetResourceGroupSecurityAlerts(ascLocation);
        [ForwardsClientCalls]
        public static Response<ResourceGroupSecurityAlertResource> GetResourceGroupSecurityAlert(this ResourceGroupResource resourceGroupResource, string ascLocation, string alertName, CancellationToken cancellationToken = default(CancellationToken))
            => GetMockableSecurityCenterResourceGroupResource(resourceGroupResource).GetResourceGroupSecurityAlert(ascLocation, alertName, cancellationToken);
        [ForwardsClientCalls]
        public static Task<Response<ResourceGroupSecurityAlertResource>> GetResourceGroupSecurityAlertAsync(this ResourceGroupResource resourceGroupResource, string ascLocation, string alertName, CancellationToken cancellationToken = default(CancellationToken))
            => GetMockableSecurityCenterResourceGroupResource(resourceGroupResource).GetResourceGroupSecurityAlertAsync(ascLocation, alertName, cancellationToken);
        [ForwardsClientCalls]
        public static ResourceGroupSecurityTaskCollection GetResourceGroupSecurityTasks(this ResourceGroupResource resourceGroupResource, string ascLocation)
            => GetMockableSecurityCenterResourceGroupResource(resourceGroupResource).GetResourceGroupSecurityTasks(ascLocation);
        [ForwardsClientCalls]
        public static Response<ResourceGroupSecurityTaskResource> GetResourceGroupSecurityTask(this ResourceGroupResource resourceGroupResource, string ascLocation, string taskName, CancellationToken cancellationToken = default(CancellationToken))
            => GetMockableSecurityCenterResourceGroupResource(resourceGroupResource).GetResourceGroupSecurityTask(ascLocation, taskName, cancellationToken);
        [ForwardsClientCalls]
        public static Task<Response<ResourceGroupSecurityTaskResource>> GetResourceGroupSecurityTaskAsync(this ResourceGroupResource resourceGroupResource, string ascLocation, string taskName, CancellationToken cancellationToken = default(CancellationToken))
            => GetMockableSecurityCenterResourceGroupResource(resourceGroupResource).GetResourceGroupSecurityTaskAsync(ascLocation, taskName, cancellationToken);
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<SecureScoreControlDetails> GetSecureScoreControlsAsync(this SubscriptionResource subscriptionResource, SecurityScoreODataExpand? expand = default(SecurityScoreODataExpand?), CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<SecureScoreControlDetails> GetSecureScoreControls(this SubscriptionResource subscriptionResource, SecurityScoreODataExpand? expand = default(SecurityScoreODataExpand?), CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SecurityCenterPricingCollection GetSecurityCenterPricings(this SubscriptionResource subscriptionResource) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SubscriptionGovernanceRuleCollection GetSubscriptionGovernanceRules(this SubscriptionResource subscriptionResource) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SubscriptionGovernanceRuleResource GetSubscriptionGovernanceRuleResource(this ArmClient client, ResourceIdentifier id) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SubscriptionSecurityApplicationCollection GetSubscriptionSecurityApplications(this SubscriptionResource subscriptionResource) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SubscriptionSecurityApplicationResource GetSubscriptionSecurityApplicationResource(this ArmClient client, ResourceIdentifier id) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [ForwardsClientCalls]
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Response<SecurityAssessmentResource> GetSecurityAssessment(this ArmClient client, ResourceIdentifier scope, string assessmentName, SecurityAssessmentODataExpand? expand = default(SecurityAssessmentODataExpand?), CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [ForwardsClientCalls]
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Task<Response<SecurityAssessmentResource>> GetSecurityAssessmentAsync(this ArmClient client, ResourceIdentifier scope, string assessmentName, SecurityAssessmentODataExpand? expand = default(SecurityAssessmentODataExpand?), CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Response<MdeOnboarding> GetMdeOnboarding(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Response<SecurityCenterAllowedConnection> GetAllowedConnection(this ResourceGroupResource resourceGroupResource, AzureLocation ascLocation, SecurityCenterConnectionType connectionType, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [ForwardsClientCalls]
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Response<SecurityCenterLocationResource> GetSecurityCenterLocation(this SubscriptionResource subscriptionResource, AzureLocation ascLocation, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [ForwardsClientCalls]
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Response<SecuritySettingResource> GetSecuritySetting(this SubscriptionResource subscriptionResource, SecuritySettingName settingName, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Task<Response<MdeOnboarding>> GetMdeOnboardingAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Task<Response<SecurityCenterAllowedConnection>> GetAllowedConnectionAsync(this ResourceGroupResource resourceGroupResource, AzureLocation ascLocation, SecurityCenterConnectionType connectionType, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [ForwardsClientCalls]
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Task<Response<SecurityCenterLocationResource>> GetSecurityCenterLocationAsync(this SubscriptionResource subscriptionResource, AzureLocation ascLocation, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [ForwardsClientCalls]
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Task<Response<SecuritySettingResource>> GetSecuritySettingAsync(this SubscriptionResource subscriptionResource, SecuritySettingName settingName, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
    }
}
