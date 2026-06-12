// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CA1822 // Compatibility instance members intentionally preserve previous signatures.
#pragma warning disable CS0618 // Compatibility shims intentionally reference obsolete API.
#pragma warning disable CS1591 // Hidden obsolete compatibility shims do not need public docs.

using System;
using System.ClientModel.Primitives;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
    [CodeGenSuppress("GetDiscoveredSecuritySolution", typeof(ResourceGroupResource), typeof(AzureLocation), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetDiscoveredSecuritySolutionAsync", typeof(ResourceGroupResource), typeof(AzureLocation), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetSecuritySolution", typeof(ResourceGroupResource), typeof(AzureLocation), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetSecuritySolutionAsync", typeof(ResourceGroupResource), typeof(AzureLocation), typeof(string), typeof(CancellationToken))]
    public static partial class SecurityCenterExtensions
    {
        // Backward compatibility for legacy provider-action list methods that are now generated as resource-returning APIs.
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<JitNetworkAccessPolicyResource> GetJitNetworkAccessPoliciesAsync(this ResourceGroupResource resourceGroupResource, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<SecurityCenterAllowedConnection> GetAllowedConnectionsAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<SecurityTopologyResource> GetTopologiesAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<JitNetworkAccessPolicyResource> GetJitNetworkAccessPolicies(this ResourceGroupResource resourceGroupResource, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<SecurityCenterAllowedConnection> GetAllowedConnections(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
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
        [ForwardsClientCalls]
        public static ResourceGroupSecurityAlertCollection GetResourceGroupSecurityAlerts(this ResourceGroupResource resourceGroupResource, AzureLocation ascLocation)
            => GetMockableSecurityCenterResourceGroupResource(resourceGroupResource).GetResourceGroupSecurityAlerts(ascLocation);
        [ForwardsClientCalls]
        [Obsolete("This method is obsolete and will be removed in a future release. Please use GetDiscoveredSecuritySolutions.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Response<DiscoveredSecuritySolution> GetDiscoveredSecuritySolution(this ResourceGroupResource resourceGroupResource, AzureLocation ascLocation, string discoveredSecuritySolutionName, CancellationToken cancellationToken = default(CancellationToken))
        {
            Response<DiscoveredSecuritySolutionResource> response = GetMockableSecurityCenterResourceGroupResource(resourceGroupResource).GetDiscoveredSecuritySolution(ascLocation, discoveredSecuritySolutionName, cancellationToken);
            return Response.FromValue(new DiscoveredSecuritySolution(response.Value.Data), response.GetRawResponse());
        }
        [ForwardsClientCalls]
        [Obsolete("This method is obsolete and will be removed in a future release. Please use GetDiscoveredSecuritySolutions.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static async Task<Response<DiscoveredSecuritySolution>> GetDiscoveredSecuritySolutionAsync(this ResourceGroupResource resourceGroupResource, AzureLocation ascLocation, string discoveredSecuritySolutionName, CancellationToken cancellationToken = default(CancellationToken))
        {
            Response<DiscoveredSecuritySolutionResource> response = await GetMockableSecurityCenterResourceGroupResource(resourceGroupResource).GetDiscoveredSecuritySolutionAsync(ascLocation, discoveredSecuritySolutionName, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(new DiscoveredSecuritySolution(response.Value.Data), response.GetRawResponse());
        }
        [ForwardsClientCalls]
        [Obsolete("This method is obsolete and will be removed in a future release. Please use GetSecuritySolutions.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Response<SecuritySolution> GetSecuritySolution(this ResourceGroupResource resourceGroupResource, AzureLocation ascLocation, string securitySolutionName, CancellationToken cancellationToken = default(CancellationToken))
        {
            Response<SecuritySolutionResource> response = GetMockableSecurityCenterResourceGroupResource(resourceGroupResource).GetSecuritySolution(ascLocation, securitySolutionName, cancellationToken);
            return Response.FromValue(new SecuritySolution(response.Value.Data), response.GetRawResponse());
        }
        [ForwardsClientCalls]
        [Obsolete("This method is obsolete and will be removed in a future release. Please use GetSecuritySolutions.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static async Task<Response<SecuritySolution>> GetSecuritySolutionAsync(this ResourceGroupResource resourceGroupResource, AzureLocation ascLocation, string securitySolutionName, CancellationToken cancellationToken = default(CancellationToken))
        {
            Response<SecuritySolutionResource> response = await GetMockableSecurityCenterResourceGroupResource(resourceGroupResource).GetSecuritySolutionAsync(ascLocation, securitySolutionName, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(new SecuritySolution(response.Value.Data), response.GetRawResponse());
        }
        [ForwardsClientCalls]
        public static ResourceGroupSecurityTaskCollection GetResourceGroupSecurityTasks(this ResourceGroupResource resourceGroupResource, AzureLocation ascLocation)
            => GetMockableSecurityCenterResourceGroupResource(resourceGroupResource).GetResourceGroupSecurityTasks(ascLocation);
        [ForwardsClientCalls]
        public static JitNetworkAccessPolicyCollection GetJitNetworkAccessPolicies(this ResourceGroupResource resourceGroupResource, string ascLocation)
            => GetMockableSecurityCenterResourceGroupResource(resourceGroupResource).GetJitNetworkAccessPolicies(ascLocation);
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<SecureScoreControlDetails> GetSecureScoreControlsAsync(this SubscriptionResource subscriptionResource, SecurityScoreODataExpand? expand = default(SecurityScoreODataExpand?), CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<SecureScoreControlDetails> GetSecureScoreControls(this SubscriptionResource subscriptionResource, SecurityScoreODataExpand? expand = default(SecurityScoreODataExpand?), CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SecurityCenterPricingCollection GetSecurityCenterPricings(this SubscriptionResource subscriptionResource) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [ForwardsClientCalls]
        [Obsolete("This method is obsolete and will be removed in a future release. Please use GetDiscoveredSecuritySolutions.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<DiscoveredSecuritySolution> GetDiscoveredSecuritySolutionsAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default(CancellationToken))
            => new LegacyDiscoveredSecuritySolutionAsyncPageable(GetMockableSecurityCenterSubscriptionResource(subscriptionResource).GetDiscoveredSecuritySolutionsAsync(default, cancellationToken));
        [ForwardsClientCalls]
        [Obsolete("This method is obsolete and will be removed in a future release. Please use GetDiscoveredSecuritySolutions.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<DiscoveredSecuritySolution> GetDiscoveredSecuritySolutions(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default(CancellationToken))
            => new LegacyDiscoveredSecuritySolutionPageable(GetMockableSecurityCenterSubscriptionResource(subscriptionResource).GetDiscoveredSecuritySolutions(default, cancellationToken));
        [ForwardsClientCalls]
        [Obsolete("This method is obsolete and will be removed in a future release. Please use GetSecurityContacts.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Response<SecurityContactResource> GetSecurityContact(this SubscriptionResource subscriptionResource, string securityContactName, CancellationToken cancellationToken = default(CancellationToken))
            => GetMockableSecurityCenterSubscriptionResource(subscriptionResource).GetSecurityContact(securityContactName, cancellationToken);
        [ForwardsClientCalls]
        [Obsolete("This method is obsolete and will be removed in a future release. Please use GetSecurityContacts.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Task<Response<SecurityContactResource>> GetSecurityContactAsync(this SubscriptionResource subscriptionResource, string securityContactName, CancellationToken cancellationToken = default(CancellationToken))
            => GetMockableSecurityCenterSubscriptionResource(subscriptionResource).GetSecurityContactAsync(securityContactName, cancellationToken);
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<SecuritySolution> GetSecuritySolutionsAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<SecuritySolution> GetSecuritySolutions(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [Obsolete("This method is obsolete and will be removed in a future release. Please use GetGovernanceRules.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SubscriptionGovernanceRuleCollection GetSubscriptionGovernanceRules(this SubscriptionResource subscriptionResource)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return GetMockableSecurityCenterSubscriptionResource(subscriptionResource).GetSubscriptionGovernanceRules();
        }
        [Obsolete("This method is obsolete and will be removed in a future release. Please use GetGovernanceRuleResource.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SubscriptionGovernanceRuleResource GetSubscriptionGovernanceRuleResource(this ArmClient client, ResourceIdentifier id) { throw new NotSupportedException("This API is no longer supported by the service."); }
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

        private sealed class LegacyDiscoveredSecuritySolutionPageable : Pageable<DiscoveredSecuritySolution>
        {
            private readonly Pageable<DiscoveredSecuritySolutionResource> _inner;

            public LegacyDiscoveredSecuritySolutionPageable(Pageable<DiscoveredSecuritySolutionResource> inner)
            {
                _inner = inner;
            }

            public override IEnumerable<Page<DiscoveredSecuritySolution>> AsPages(string continuationToken = null, int? pageSizeHint = null)
            {
                foreach (Page<DiscoveredSecuritySolutionResource> page in _inner.AsPages(continuationToken, pageSizeHint))
                {
                    yield return Page<DiscoveredSecuritySolution>.FromValues(page.Values.Select(resource => new DiscoveredSecuritySolution(resource.Data)).ToArray(), page.ContinuationToken, page.GetRawResponse());
                }
            }
        }

        private sealed class LegacyDiscoveredSecuritySolutionAsyncPageable : AsyncPageable<DiscoveredSecuritySolution>
        {
            private readonly AsyncPageable<DiscoveredSecuritySolutionResource> _inner;

            public LegacyDiscoveredSecuritySolutionAsyncPageable(AsyncPageable<DiscoveredSecuritySolutionResource> inner)
            {
                _inner = inner;
            }

            public override async IAsyncEnumerable<Page<DiscoveredSecuritySolution>> AsPages(string continuationToken = null, int? pageSizeHint = null)
            {
                await foreach (Page<DiscoveredSecuritySolutionResource> page in _inner.AsPages(continuationToken, pageSizeHint).ConfigureAwait(false))
                {
                    yield return Page<DiscoveredSecuritySolution>.FromValues(page.Values.Select(resource => new DiscoveredSecuritySolution(resource.Data)).ToArray(), page.ContinuationToken, page.GetRawResponse());
                }
            }
        }
    }
}
