// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.SecurityCenter.Models;

namespace Azure.ResourceManager.SecurityCenter.Mocking
{
    public partial class MockableSecurityCenterSubscriptionResource
    {
        private ClientDiagnostics _mdeOnboardingsClientDiagnostics;
        private MdeOnboardings _mdeOnboardingsRestClient;

        private ClientDiagnostics MdeOnboardingsClientDiagnostics => _mdeOnboardingsClientDiagnostics ??= new ClientDiagnostics("Azure.ResourceManager.SecurityCenter.Mocking", ProviderConstants.DefaultProviderNamespace, Diagnostics);
        private MdeOnboardings MdeOnboardingsRestClient => _mdeOnboardingsRestClient ??= new MdeOnboardings(MdeOnboardingsClientDiagnostics, Pipeline, Endpoint, "2021-10-01-preview");

        /// <summary> Gets security center pricings for this subscription. </summary>
        public virtual SecurityCenterPricingCollection GetSecurityCenterPricings()
            => Client.GetSecurityCenterPricings(Id);

        /// <summary> Gets a security center pricing for this subscription. </summary>
        public virtual Response<SecurityCenterPricingResource> GetSecurityCenterPricing(string pricingName, CancellationToken cancellationToken = default)
            => Client.GetSecurityCenterPricing(Id, pricingName, cancellationToken);

        /// <summary> Gets a security center pricing for this subscription. </summary>
        public virtual Task<Response<SecurityCenterPricingResource>> GetSecurityCenterPricingAsync(string pricingName, CancellationToken cancellationToken = default)
            => Client.GetSecurityCenterPricingAsync(Id, pricingName, cancellationToken);

        /// <summary> Gets a security contact for this subscription. </summary>
        public virtual Response<SecurityContactResource> GetSecurityContact(string securityContactName, CancellationToken cancellationToken = default)
            => GetSecurityContact(new SecurityContactName(securityContactName), cancellationToken);

        /// <summary> Gets a security contact for this subscription. </summary>
        public virtual Task<Response<SecurityContactResource>> GetSecurityContactAsync(string securityContactName, CancellationToken cancellationToken = default)
            => GetSecurityContactAsync(new SecurityContactName(securityContactName), cancellationToken);

        /// <summary> Gets subscription governance rules for this subscription. </summary>
        [System.Obsolete("This method is obsolete and will be removed in a future release.", false)]
        public virtual SubscriptionGovernanceRuleCollection GetSubscriptionGovernanceRules()
            => new SubscriptionGovernanceRuleCollection(Client, Id);

        /// <summary> Gets a subscription governance rule for this subscription. </summary>
        [System.Obsolete("This method is obsolete and will be removed in a future release.", false)]
        public virtual Response<SubscriptionGovernanceRuleResource> GetSubscriptionGovernanceRule(string ruleId, CancellationToken cancellationToken = default)
            => GetSubscriptionGovernanceRules().Get(ruleId, cancellationToken);

        /// <summary> Gets a subscription governance rule for this subscription. </summary>
        [System.Obsolete("This method is obsolete and will be removed in a future release.", false)]
        public virtual Task<Response<SubscriptionGovernanceRuleResource>> GetSubscriptionGovernanceRuleAsync(string ruleId, CancellationToken cancellationToken = default)
            => GetSubscriptionGovernanceRules().GetAsync(ruleId, cancellationToken);

        /// <summary> Gets alerts for this subscription. </summary>
        public virtual AsyncPageable<SecurityAlertData> GetAlertsAsync(CancellationToken cancellationToken = default)
            => new SubscriptionAlertsAsyncPageable(this, cancellationToken);

        /// <summary> Gets alerts for this subscription. </summary>
        public virtual Pageable<SecurityAlertData> GetAlerts(CancellationToken cancellationToken = default)
            => new SubscriptionAlertsPageable(this, cancellationToken);

        /// <summary> Gets adaptive application control groups for this subscription. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<AdaptiveApplicationControlGroupResource> GetAdaptiveApplicationControlGroups(bool? includePathRecommendations = default, bool? summary = default, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This API is no longer supported by the service. Use SubscriptionResource.GetAdaptiveApplicationControlGroups() instead.");

        /// <summary> Gets adaptive application control groups for this subscription. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<AdaptiveApplicationControlGroupResource> GetAdaptiveApplicationControlGroupsAsync(bool? includePathRecommendations = default, bool? summary = default, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This API is no longer supported by the service. Use SubscriptionResource.GetAdaptiveApplicationControlGroupsAsync() instead.");

        /// <summary> Gets custom assessment automations for this subscription. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<CustomAssessmentAutomationResource> GetCustomAssessmentAutomations(CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This API is no longer supported by the service. Use ArmClient.GetCustomAssessmentAutomations(ResourceIdentifier scope) instead.");

        /// <summary> Gets custom assessment automations for this subscription. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<CustomAssessmentAutomationResource> GetCustomAssessmentAutomationsAsync(CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This API is no longer supported by the service. Use ArmClient.GetCustomAssessmentAutomations(ResourceIdentifier scope) instead.");

        /// <summary> Gets custom entity store assignments for this subscription. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<CustomEntityStoreAssignmentResource> GetCustomEntityStoreAssignments(CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This API is no longer supported by the service. Use ArmClient.GetCustomEntityStoreAssignments(ResourceIdentifier scope) instead.");

        /// <summary> Gets custom entity store assignments for this subscription. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<CustomEntityStoreAssignmentResource> GetCustomEntityStoreAssignmentsAsync(CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This API is no longer supported by the service. Use ArmClient.GetCustomEntityStoreAssignments(ResourceIdentifier scope) instead.");

        /// <summary> Gets a security cloud connector for this subscription. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<SecurityCloudConnectorResource> GetSecurityCloudConnector(string connectorName, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This API is no longer supported by the service. Use ArmClient.GetSecurityCloudConnectorResource(ResourceIdentifier id) instead.");

        /// <summary> Gets a security cloud connector for this subscription. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<SecurityCloudConnectorResource>> GetSecurityCloudConnectorAsync(string connectorName, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This API is no longer supported by the service. Use ArmClient.GetSecurityCloudConnectorResource(ResourceIdentifier id) instead.");

        /// <summary> Gets security cloud connectors for this subscription. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual SecurityCloudConnectorCollection GetSecurityCloudConnectors()
            => throw new NotSupportedException("This API is no longer supported by the service. No direct collection replacement is available.");

        /// <summary> Gets software inventories for this subscription. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<SoftwareInventoryResource> GetSoftwareInventories(CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This API is no longer supported by the service. No direct replacement is available.");

        /// <summary> Gets software inventories for this subscription. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<SoftwareInventoryResource> GetSoftwareInventoriesAsync(CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This API is no longer supported by the service. No direct replacement is available.");

        /// <summary> Gets a Security Center location for this subscription. </summary>
        public virtual Response<SecurityCenterLocationResource> GetSecurityCenterLocation(AzureLocation ascLocation, CancellationToken cancellationToken = default)
            => GetSecurityCenterLocation(ascLocation.ToString(), cancellationToken);

        /// <summary> Gets a Security Center location for this subscription. </summary>
        public virtual Task<Response<SecurityCenterLocationResource>> GetSecurityCenterLocationAsync(AzureLocation ascLocation, CancellationToken cancellationToken = default)
            => GetSecurityCenterLocationAsync(ascLocation.ToString(), cancellationToken);

        /// <summary> Gets a security setting for this subscription. </summary>
        public virtual Response<SecuritySettingResource> GetSecuritySetting(SecuritySettingName settingName, CancellationToken cancellationToken = default)
            => GetSecuritySetting(new SettingName(settingName.ToString()), cancellationToken);

        /// <summary> Gets a security setting for this subscription. </summary>
        public virtual Task<Response<SecuritySettingResource>> GetSecuritySettingAsync(SecuritySettingName settingName, CancellationToken cancellationToken = default)
            => GetSecuritySettingAsync(new SettingName(settingName.ToString()), cancellationToken);

        /// <summary> Gets the default configuration or data needed to onboard machines to MDE. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<MdeOnboarding>> GetMdeOnboardingAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = MdeOnboardingsClientDiagnostics.CreateScope("SubscriptionResource.GetMdeOnboarding");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = MdeOnboardingsRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                return Response.FromValue(ToMdeOnboarding(MdeOnboardingData.FromResponse(response)), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets the default configuration or data needed to onboard machines to MDE. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<MdeOnboarding> GetMdeOnboarding(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = MdeOnboardingsClientDiagnostics.CreateScope("SubscriptionResource.GetMdeOnboarding");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = MdeOnboardingsRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), context);
                Response response = Pipeline.ProcessMessage(message, context);
                return Response.FromValue(ToMdeOnboarding(MdeOnboardingData.FromResponse(response)), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private static MdeOnboarding ToMdeOnboarding(MdeOnboardingData data)
        {
            return new MdeOnboarding
            {
                OnboardingPackageLinux = data?.OnboardingPackageLinux?.ToArray(),
                OnboardingPackageWindows = data?.OnboardingPackageWindows?.ToArray()
            };
        }
    }
}
