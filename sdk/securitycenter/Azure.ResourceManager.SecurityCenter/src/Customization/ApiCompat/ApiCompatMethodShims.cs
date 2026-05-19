// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS0618, CS1591, SA1402

using System;

namespace Azure.ResourceManager.SecurityCenter
{
    public partial class AdvancedThreatProtectionSettingResource
    {
        [Azure.Core.ForwardsClientCalls]
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(System.String p0) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
    }
    public partial class IotSecuritySolutionResource
    {
        [Azure.Core.ForwardsClientCalls]
        public virtual Azure.ResourceManager.SecurityCenter.IotSecuritySolutionAnalyticsModelResource GetIotSecuritySolutionAnalyticsModel() => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
    }
    public partial class JitNetworkAccessPolicyResource
    {
        [Azure.Core.ForwardsClientCalls]
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(System.String p0, System.String p1, Azure.Core.AzureLocation p2, System.String p3) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.Models.JitNetworkAccessRequestInfo> Initiate(Azure.ResourceManager.SecurityCenter.Models.JitNetworkAccessPolicyInitiateContent p0, System.Threading.CancellationToken p1 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.Models.JitNetworkAccessRequestInfo>> InitiateAsync(Azure.ResourceManager.SecurityCenter.Models.JitNetworkAccessPolicyInitiateContent p0, System.Threading.CancellationToken p1 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
    }
    public partial class SecureScoreResource
    {
        [Azure.Core.ForwardsClientCalls]
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.Models.SecureScoreControlDetails> GetSecureScoreControlsAsync(System.Nullable<Azure.ResourceManager.SecurityCenter.Models.SecurityScoreODataExpand> p0, System.Threading.CancellationToken p1 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.Models.SecureScoreControlDetails> GetSecureScoreControls(System.Nullable<Azure.ResourceManager.SecurityCenter.Models.SecurityScoreODataExpand> p0, System.Threading.CancellationToken p1 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
    }
    public partial class SecurityAssessmentCollection
    {
        [Azure.Core.ForwardsClientCalls]
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SecurityAssessmentResource> CreateOrUpdate(Azure.WaitUntil p0, System.String p1, Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentCreateOrUpdateContent p2, System.Threading.CancellationToken p3 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityAssessmentResource> Get(System.String p0, System.Nullable<Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentODataExpand> p1, System.Threading.CancellationToken p2 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public virtual Azure.Response<System.Boolean> Exists(System.String p0, System.Nullable<Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentODataExpand> p1, System.Threading.CancellationToken p2 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SecurityAssessmentResource>> CreateOrUpdateAsync(Azure.WaitUntil p0, System.String p1, Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentCreateOrUpdateContent p2, System.Threading.CancellationToken p3 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityAssessmentResource>> GetAsync(System.String p0, System.Nullable<Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentODataExpand> p1, System.Threading.CancellationToken p2 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Boolean>> ExistsAsync(System.String p0, System.Nullable<Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentODataExpand> p1, System.Threading.CancellationToken p2 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
    }
    public partial class SecurityAssessmentResource
    {
        [Azure.Core.ForwardsClientCalls]
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SecurityAssessmentResource> Update(Azure.WaitUntil p0, Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentCreateOrUpdateContent p1, System.Threading.CancellationToken p2 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityAssessmentResource> Get(System.Nullable<Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentODataExpand> p0, System.Threading.CancellationToken p1 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SecurityAssessmentResource>> UpdateAsync(Azure.WaitUntil p0, Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentCreateOrUpdateContent p1, System.Threading.CancellationToken p2 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityAssessmentResource>> GetAsync(System.Nullable<Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentODataExpand> p0, System.Threading.CancellationToken p1 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
    }
    public partial class SecurityAutomationResource
    {
        [Azure.Core.ForwardsClientCalls]
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SecurityAutomationResource> Update(Azure.WaitUntil p0, Azure.ResourceManager.SecurityCenter.SecurityAutomationData p1, System.Threading.CancellationToken p2 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SecurityAutomationResource>> UpdateAsync(Azure.WaitUntil p0, Azure.ResourceManager.SecurityCenter.SecurityAutomationData p1, System.Threading.CancellationToken p2 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
    }
    public static partial class SecurityCenterExtensions
    {
        [Azure.Core.ForwardsClientCalls]
        public static Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupResource> GetAdaptiveApplicationControlGroupsAsync(this Azure.ResourceManager.Resources.SubscriptionResource p0, System.Nullable<System.Boolean> p1, System.Nullable<System.Boolean> p2, System.Threading.CancellationToken p3 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.CustomAssessmentAutomationResource> GetCustomAssessmentAutomationsAsync(this Azure.ResourceManager.Resources.SubscriptionResource p0, System.Threading.CancellationToken p1 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentResource> GetCustomEntityStoreAssignmentsAsync(this Azure.ResourceManager.Resources.SubscriptionResource p0, System.Threading.CancellationToken p1 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.JitNetworkAccessPolicyResource> GetJitNetworkAccessPoliciesAsync(this Azure.ResourceManager.Resources.SubscriptionResource p0, System.Threading.CancellationToken p1 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.Models.SecureScoreControlDetails> GetSecureScoreControlsAsync(this Azure.ResourceManager.Resources.SubscriptionResource p0, System.Nullable<Azure.ResourceManager.SecurityCenter.Models.SecurityScoreODataExpand> p1, System.Threading.CancellationToken p2 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.Models.SecuritySolutionsReferenceData> GetAllSecuritySolutionsReferenceDataAsync(this Azure.ResourceManager.Resources.SubscriptionResource p0, System.Threading.CancellationToken p1 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.SecurityAlertData> GetAlertsAsync(this Azure.ResourceManager.Resources.SubscriptionResource p0, System.Threading.CancellationToken p1 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.SecurityAlertData> GetAlertsByResourceGroupAsync(this Azure.ResourceManager.Resources.ResourceGroupResource p0, System.Threading.CancellationToken p1 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.SecurityTaskData> GetTasksAsync(this Azure.ResourceManager.Resources.SubscriptionResource p0, System.String p1, System.Threading.CancellationToken p2 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.SoftwareInventoryResource> GetSoftwareInventoriesAsync(this Azure.ResourceManager.Resources.SubscriptionResource p0, System.Threading.CancellationToken p1 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static Azure.Pageable<Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupResource> GetAdaptiveApplicationControlGroups(this Azure.ResourceManager.Resources.SubscriptionResource p0, System.Nullable<System.Boolean> p1, System.Nullable<System.Boolean> p2, System.Threading.CancellationToken p3 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static Azure.Pageable<Azure.ResourceManager.SecurityCenter.CustomAssessmentAutomationResource> GetCustomAssessmentAutomations(this Azure.ResourceManager.Resources.SubscriptionResource p0, System.Threading.CancellationToken p1 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static Azure.Pageable<Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentResource> GetCustomEntityStoreAssignments(this Azure.ResourceManager.Resources.SubscriptionResource p0, System.Threading.CancellationToken p1 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static Azure.Pageable<Azure.ResourceManager.SecurityCenter.JitNetworkAccessPolicyResource> GetJitNetworkAccessPolicies(this Azure.ResourceManager.Resources.SubscriptionResource p0, System.Threading.CancellationToken p1 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static Azure.Pageable<Azure.ResourceManager.SecurityCenter.Models.SecureScoreControlDetails> GetSecureScoreControls(this Azure.ResourceManager.Resources.SubscriptionResource p0, System.Nullable<Azure.ResourceManager.SecurityCenter.Models.SecurityScoreODataExpand> p1, System.Threading.CancellationToken p2 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static Azure.Pageable<Azure.ResourceManager.SecurityCenter.Models.SecuritySolutionsReferenceData> GetAllSecuritySolutionsReferenceData(this Azure.ResourceManager.Resources.SubscriptionResource p0, System.Threading.CancellationToken p1 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static Azure.Pageable<Azure.ResourceManager.SecurityCenter.SecurityAlertData> GetAlerts(this Azure.ResourceManager.Resources.SubscriptionResource p0, System.Threading.CancellationToken p1 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static Azure.Pageable<Azure.ResourceManager.SecurityCenter.SecurityAlertData> GetAlertsByResourceGroup(this Azure.ResourceManager.Resources.ResourceGroupResource p0, System.Threading.CancellationToken p1 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static Azure.Pageable<Azure.ResourceManager.SecurityCenter.SecurityTaskData> GetTasks(this Azure.ResourceManager.Resources.SubscriptionResource p0, System.String p1, System.Threading.CancellationToken p2 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static Azure.Pageable<Azure.ResourceManager.SecurityCenter.SoftwareInventoryResource> GetSoftwareInventories(this Azure.ResourceManager.Resources.SubscriptionResource p0, System.Threading.CancellationToken p1 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupResource GetAdaptiveApplicationControlGroupResource(this Azure.ResourceManager.ArmClient p0, Azure.Core.ResourceIdentifier p1) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningCollection GetAdaptiveNetworkHardenings(this Azure.ResourceManager.Resources.ResourceGroupResource p0, System.String p1, System.String p2, System.String p3) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningResource GetAdaptiveNetworkHardeningResource(this Azure.ResourceManager.ArmClient p0, Azure.Core.ResourceIdentifier p1) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static Azure.ResourceManager.SecurityCenter.CustomAssessmentAutomationCollection GetCustomAssessmentAutomations(this Azure.ResourceManager.Resources.ResourceGroupResource p0) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static Azure.ResourceManager.SecurityCenter.CustomAssessmentAutomationResource GetCustomAssessmentAutomationResource(this Azure.ResourceManager.ArmClient p0, Azure.Core.ResourceIdentifier p1) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentCollection GetCustomEntityStoreAssignments(this Azure.ResourceManager.Resources.ResourceGroupResource p0) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentResource GetCustomEntityStoreAssignmentResource(this Azure.ResourceManager.ArmClient p0, Azure.Core.ResourceIdentifier p1) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static Azure.ResourceManager.SecurityCenter.IotSecuritySolutionAnalyticsModelResource GetIotSecuritySolutionAnalyticsModelResource(this Azure.ResourceManager.ArmClient p0, Azure.Core.ResourceIdentifier p1) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static Azure.ResourceManager.SecurityCenter.JitNetworkAccessPolicyCollection GetJitNetworkAccessPolicies(this Azure.ResourceManager.Resources.ResourceGroupResource p0, Azure.Core.AzureLocation p1) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static Azure.ResourceManager.SecurityCenter.ResourceGroupSecurityAlertCollection GetResourceGroupSecurityAlerts(this Azure.ResourceManager.Resources.ResourceGroupResource p0, Azure.Core.AzureLocation p1) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static Azure.ResourceManager.SecurityCenter.ResourceGroupSecurityAlertResource GetResourceGroupSecurityAlertResource(this Azure.ResourceManager.ArmClient p0, Azure.Core.ResourceIdentifier p1) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static Azure.ResourceManager.SecurityCenter.ResourceGroupSecurityTaskCollection GetResourceGroupSecurityTasks(this Azure.ResourceManager.Resources.ResourceGroupResource p0, Azure.Core.AzureLocation p1) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static Azure.ResourceManager.SecurityCenter.ResourceGroupSecurityTaskResource GetResourceGroupSecurityTaskResource(this Azure.ResourceManager.ArmClient p0, Azure.Core.ResourceIdentifier p1) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static Azure.ResourceManager.SecurityCenter.SecurityCenterPricingCollection GetSecurityCenterPricings(this Azure.ResourceManager.Resources.SubscriptionResource p0) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorCollection GetSecurityCloudConnectors(this Azure.ResourceManager.Resources.SubscriptionResource p0) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorResource GetSecurityCloudConnectorResource(this Azure.ResourceManager.ArmClient p0, Azure.Core.ResourceIdentifier p1) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static Azure.ResourceManager.SecurityCenter.ServerVulnerabilityAssessmentCollection GetServerVulnerabilityAssessments(this Azure.ResourceManager.Resources.ResourceGroupResource p0, System.String p1, System.String p2, System.String p3) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static Azure.ResourceManager.SecurityCenter.SoftwareInventoryCollection GetSoftwareInventories(this Azure.ResourceManager.Resources.ResourceGroupResource p0, System.String p1, System.String p2, System.String p3) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static Azure.ResourceManager.SecurityCenter.SoftwareInventoryResource GetSoftwareInventoryResource(this Azure.ResourceManager.ArmClient p0, Azure.Core.ResourceIdentifier p1) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static Azure.ResourceManager.SecurityCenter.SqlVulnerabilityAssessmentScanResource GetSqlVulnerabilityAssessmentScanResource(this Azure.ResourceManager.ArmClient p0, Azure.Core.ResourceIdentifier p1) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static Azure.ResourceManager.SecurityCenter.SubscriptionAssessmentMetadataCollection GetAllSubscriptionAssessmentMetadata(this Azure.ResourceManager.Resources.SubscriptionResource p0) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static Azure.ResourceManager.SecurityCenter.SubscriptionAssessmentMetadataResource GetSubscriptionAssessmentMetadataResource(this Azure.ResourceManager.ArmClient p0, Azure.Core.ResourceIdentifier p1) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static Azure.ResourceManager.SecurityCenter.SubscriptionGovernanceRuleCollection GetSubscriptionGovernanceRules(this Azure.ResourceManager.Resources.SubscriptionResource p0) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static Azure.ResourceManager.SecurityCenter.SubscriptionGovernanceRuleResource GetSubscriptionGovernanceRuleResource(this Azure.ResourceManager.ArmClient p0, Azure.Core.ResourceIdentifier p1) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static Azure.ResourceManager.SecurityCenter.SubscriptionSecurityAlertResource GetSubscriptionSecurityAlertResource(this Azure.ResourceManager.ArmClient p0, Azure.Core.ResourceIdentifier p1) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static Azure.ResourceManager.SecurityCenter.SubscriptionSecurityApplicationCollection GetSubscriptionSecurityApplications(this Azure.ResourceManager.Resources.SubscriptionResource p0) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static Azure.ResourceManager.SecurityCenter.SubscriptionSecurityApplicationResource GetSubscriptionSecurityApplicationResource(this Azure.ResourceManager.ArmClient p0, Azure.Core.ResourceIdentifier p1) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static Azure.ResourceManager.SecurityCenter.SubscriptionSecurityTaskResource GetSubscriptionSecurityTaskResource(this Azure.ResourceManager.ArmClient p0, Azure.Core.ResourceIdentifier p1) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static Azure.ResourceManager.SecurityCenter.TenantAssessmentMetadataCollection GetAllTenantAssessmentMetadata(this Azure.ResourceManager.Resources.TenantResource p0) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static Azure.ResourceManager.SecurityCenter.TenantAssessmentMetadataResource GetTenantAssessmentMetadataResource(this Azure.ResourceManager.ArmClient p0, Azure.Core.ResourceIdentifier p1) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningResource> GetAdaptiveNetworkHardening(this Azure.ResourceManager.Resources.ResourceGroupResource p0, System.String p1, System.String p2, System.String p3, System.String p4, System.Threading.CancellationToken p5 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.CustomAssessmentAutomationResource> GetCustomAssessmentAutomation(this Azure.ResourceManager.Resources.ResourceGroupResource p0, System.String p1, System.Threading.CancellationToken p2 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentResource> GetCustomEntityStoreAssignment(this Azure.ResourceManager.Resources.ResourceGroupResource p0, System.String p1, System.Threading.CancellationToken p2 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.JitNetworkAccessPolicyResource> GetJitNetworkAccessPolicy(this Azure.ResourceManager.Resources.ResourceGroupResource p0, Azure.Core.AzureLocation p1, System.String p2, System.Threading.CancellationToken p3 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.Models.DiscoveredSecuritySolution> GetDiscoveredSecuritySolution(this Azure.ResourceManager.Resources.ResourceGroupResource p0, Azure.Core.AzureLocation p1, System.String p2, System.Threading.CancellationToken p3 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.Models.ExternalSecuritySolution> GetExternalSecuritySolution(this Azure.ResourceManager.Resources.ResourceGroupResource p0, Azure.Core.AzureLocation p1, System.String p2, System.Threading.CancellationToken p3 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.Models.MdeOnboarding> GetMdeOnboarding(this Azure.ResourceManager.Resources.SubscriptionResource p0, System.Threading.CancellationToken p1 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.Models.SecurityCenterAllowedConnection> GetAllowedConnection(this Azure.ResourceManager.Resources.ResourceGroupResource p0, Azure.Core.AzureLocation p1, Azure.ResourceManager.SecurityCenter.Models.SecurityCenterConnectionType p2, System.Threading.CancellationToken p3 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.Models.SecuritySolution> GetSecuritySolution(this Azure.ResourceManager.Resources.ResourceGroupResource p0, Azure.Core.AzureLocation p1, System.String p2, System.Threading.CancellationToken p3 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.Models.SecurityTopologyResource> GetTopology(this Azure.ResourceManager.Resources.ResourceGroupResource p0, Azure.Core.AzureLocation p1, System.String p2, System.Threading.CancellationToken p3 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.ResourceGroupSecurityAlertResource> GetResourceGroupSecurityAlert(this Azure.ResourceManager.Resources.ResourceGroupResource p0, Azure.Core.AzureLocation p1, System.String p2, System.Threading.CancellationToken p3 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.ResourceGroupSecurityTaskResource> GetResourceGroupSecurityTask(this Azure.ResourceManager.Resources.ResourceGroupResource p0, Azure.Core.AzureLocation p1, System.String p2, System.Threading.CancellationToken p3 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityAssessmentResource> GetSecurityAssessment(this Azure.ResourceManager.ArmClient p0, Azure.Core.ResourceIdentifier p1, System.String p2, System.Nullable<Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentODataExpand> p3, System.Threading.CancellationToken p4 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityCenterLocationResource> GetSecurityCenterLocation(this Azure.ResourceManager.Resources.SubscriptionResource p0, Azure.Core.AzureLocation p1, System.Threading.CancellationToken p2 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityCenterPricingResource> GetSecurityCenterPricing(this Azure.ResourceManager.Resources.SubscriptionResource p0, System.String p1, System.Threading.CancellationToken p2 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorResource> GetSecurityCloudConnector(this Azure.ResourceManager.Resources.SubscriptionResource p0, System.String p1, System.Threading.CancellationToken p2 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityContactResource> GetSecurityContact(this Azure.ResourceManager.Resources.SubscriptionResource p0, System.String p1, System.Threading.CancellationToken p2 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.SecuritySettingResource> GetSecuritySetting(this Azure.ResourceManager.Resources.SubscriptionResource p0, Azure.ResourceManager.SecurityCenter.Models.SecuritySettingName p1, System.Threading.CancellationToken p2 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.ServerVulnerabilityAssessmentResource> GetServerVulnerabilityAssessment(this Azure.ResourceManager.Resources.ResourceGroupResource p0, System.String p1, System.String p2, System.String p3, System.Threading.CancellationToken p4 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.SoftwareInventoryResource> GetSoftwareInventory(this Azure.ResourceManager.Resources.ResourceGroupResource p0, System.String p1, System.String p2, System.String p3, System.String p4, System.Threading.CancellationToken p5 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.SqlVulnerabilityAssessmentBaselineRuleResource> GetSqlVulnerabilityAssessmentBaselineRule(this Azure.ResourceManager.ArmClient p0, Azure.Core.ResourceIdentifier p1, System.String p2, System.Guid p3, System.Threading.CancellationToken p4 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.SqlVulnerabilityAssessmentScanResource> GetSqlVulnerabilityAssessmentScan(this Azure.ResourceManager.ArmClient p0, Azure.Core.ResourceIdentifier p1, System.String p2, System.Guid p3, System.Threading.CancellationToken p4 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.SubscriptionAssessmentMetadataResource> GetSubscriptionAssessmentMetadata(this Azure.ResourceManager.Resources.SubscriptionResource p0, System.String p1, System.Threading.CancellationToken p2 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.SubscriptionGovernanceRuleResource> GetSubscriptionGovernanceRule(this Azure.ResourceManager.Resources.SubscriptionResource p0, System.String p1, System.Threading.CancellationToken p2 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.SubscriptionSecurityApplicationResource> GetSubscriptionSecurityApplication(this Azure.ResourceManager.Resources.SubscriptionResource p0, System.String p1, System.Threading.CancellationToken p2 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.TenantAssessmentMetadataResource> GetTenantAssessmentMetadata(this Azure.ResourceManager.Resources.TenantResource p0, System.String p1, System.Threading.CancellationToken p2 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningResource>> GetAdaptiveNetworkHardeningAsync(this Azure.ResourceManager.Resources.ResourceGroupResource p0, System.String p1, System.String p2, System.String p3, System.String p4, System.Threading.CancellationToken p5 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.CustomAssessmentAutomationResource>> GetCustomAssessmentAutomationAsync(this Azure.ResourceManager.Resources.ResourceGroupResource p0, System.String p1, System.Threading.CancellationToken p2 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentResource>> GetCustomEntityStoreAssignmentAsync(this Azure.ResourceManager.Resources.ResourceGroupResource p0, System.String p1, System.Threading.CancellationToken p2 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.JitNetworkAccessPolicyResource>> GetJitNetworkAccessPolicyAsync(this Azure.ResourceManager.Resources.ResourceGroupResource p0, Azure.Core.AzureLocation p1, System.String p2, System.Threading.CancellationToken p3 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.Models.DiscoveredSecuritySolution>> GetDiscoveredSecuritySolutionAsync(this Azure.ResourceManager.Resources.ResourceGroupResource p0, Azure.Core.AzureLocation p1, System.String p2, System.Threading.CancellationToken p3 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.Models.ExternalSecuritySolution>> GetExternalSecuritySolutionAsync(this Azure.ResourceManager.Resources.ResourceGroupResource p0, Azure.Core.AzureLocation p1, System.String p2, System.Threading.CancellationToken p3 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.Models.MdeOnboarding>> GetMdeOnboardingAsync(this Azure.ResourceManager.Resources.SubscriptionResource p0, System.Threading.CancellationToken p1 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.Models.SecurityCenterAllowedConnection>> GetAllowedConnectionAsync(this Azure.ResourceManager.Resources.ResourceGroupResource p0, Azure.Core.AzureLocation p1, Azure.ResourceManager.SecurityCenter.Models.SecurityCenterConnectionType p2, System.Threading.CancellationToken p3 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.Models.SecuritySolution>> GetSecuritySolutionAsync(this Azure.ResourceManager.Resources.ResourceGroupResource p0, Azure.Core.AzureLocation p1, System.String p2, System.Threading.CancellationToken p3 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.Models.SecurityTopologyResource>> GetTopologyAsync(this Azure.ResourceManager.Resources.ResourceGroupResource p0, Azure.Core.AzureLocation p1, System.String p2, System.Threading.CancellationToken p3 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.ResourceGroupSecurityAlertResource>> GetResourceGroupSecurityAlertAsync(this Azure.ResourceManager.Resources.ResourceGroupResource p0, Azure.Core.AzureLocation p1, System.String p2, System.Threading.CancellationToken p3 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.ResourceGroupSecurityTaskResource>> GetResourceGroupSecurityTaskAsync(this Azure.ResourceManager.Resources.ResourceGroupResource p0, Azure.Core.AzureLocation p1, System.String p2, System.Threading.CancellationToken p3 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityAssessmentResource>> GetSecurityAssessmentAsync(this Azure.ResourceManager.ArmClient p0, Azure.Core.ResourceIdentifier p1, System.String p2, System.Nullable<Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentODataExpand> p3, System.Threading.CancellationToken p4 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityCenterLocationResource>> GetSecurityCenterLocationAsync(this Azure.ResourceManager.Resources.SubscriptionResource p0, Azure.Core.AzureLocation p1, System.Threading.CancellationToken p2 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityCenterPricingResource>> GetSecurityCenterPricingAsync(this Azure.ResourceManager.Resources.SubscriptionResource p0, System.String p1, System.Threading.CancellationToken p2 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorResource>> GetSecurityCloudConnectorAsync(this Azure.ResourceManager.Resources.SubscriptionResource p0, System.String p1, System.Threading.CancellationToken p2 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityContactResource>> GetSecurityContactAsync(this Azure.ResourceManager.Resources.SubscriptionResource p0, System.String p1, System.Threading.CancellationToken p2 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecuritySettingResource>> GetSecuritySettingAsync(this Azure.ResourceManager.Resources.SubscriptionResource p0, Azure.ResourceManager.SecurityCenter.Models.SecuritySettingName p1, System.Threading.CancellationToken p2 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.ServerVulnerabilityAssessmentResource>> GetServerVulnerabilityAssessmentAsync(this Azure.ResourceManager.Resources.ResourceGroupResource p0, System.String p1, System.String p2, System.String p3, System.Threading.CancellationToken p4 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SoftwareInventoryResource>> GetSoftwareInventoryAsync(this Azure.ResourceManager.Resources.ResourceGroupResource p0, System.String p1, System.String p2, System.String p3, System.String p4, System.Threading.CancellationToken p5 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SqlVulnerabilityAssessmentBaselineRuleResource>> GetSqlVulnerabilityAssessmentBaselineRuleAsync(this Azure.ResourceManager.ArmClient p0, Azure.Core.ResourceIdentifier p1, System.String p2, System.Guid p3, System.Threading.CancellationToken p4 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SqlVulnerabilityAssessmentScanResource>> GetSqlVulnerabilityAssessmentScanAsync(this Azure.ResourceManager.ArmClient p0, Azure.Core.ResourceIdentifier p1, System.String p2, System.Guid p3, System.Threading.CancellationToken p4 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SubscriptionAssessmentMetadataResource>> GetSubscriptionAssessmentMetadataAsync(this Azure.ResourceManager.Resources.SubscriptionResource p0, System.String p1, System.Threading.CancellationToken p2 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SubscriptionGovernanceRuleResource>> GetSubscriptionGovernanceRuleAsync(this Azure.ResourceManager.Resources.SubscriptionResource p0, System.String p1, System.Threading.CancellationToken p2 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SubscriptionSecurityApplicationResource>> GetSubscriptionSecurityApplicationAsync(this Azure.ResourceManager.Resources.SubscriptionResource p0, System.String p1, System.Threading.CancellationToken p2 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.TenantAssessmentMetadataResource>> GetTenantAssessmentMetadataAsync(this Azure.ResourceManager.Resources.TenantResource p0, System.String p1, System.Threading.CancellationToken p2 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
    }
    public partial class SecurityCenterLocationCollection
    {
        [Azure.Core.ForwardsClientCalls]
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityCenterLocationResource> Get(Azure.Core.AzureLocation p0, System.Threading.CancellationToken p1 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public virtual Azure.Response<System.Boolean> Exists(Azure.Core.AzureLocation p0, System.Threading.CancellationToken p1 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityCenterLocationResource>> GetAsync(Azure.Core.AzureLocation p0, System.Threading.CancellationToken p1 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Boolean>> ExistsAsync(Azure.Core.AzureLocation p0, System.Threading.CancellationToken p1 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
    }
    public partial class SecurityCenterLocationResource
    {
        [Azure.Core.ForwardsClientCalls]
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.JitNetworkAccessPolicyResource> GetJitNetworkAccessPoliciesByRegionAsync(System.Threading.CancellationToken p0 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.Models.DiscoveredSecuritySolution> GetDiscoveredSecuritySolutionsByHomeRegionAsync(System.Threading.CancellationToken p0 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.Models.ExternalSecuritySolution> GetExternalSecuritySolutionsByHomeRegionAsync(System.Threading.CancellationToken p0 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.Models.SecurityCenterAllowedConnection> GetAllowedConnectionsByHomeRegionAsync(System.Threading.CancellationToken p0 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.Models.SecuritySolutionsReferenceData> GetAllSecuritySolutionsReferenceDataByHomeRegionAsync(System.Threading.CancellationToken p0 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.Models.SecurityTopologyResource> GetTopologiesByHomeRegionAsync(System.Threading.CancellationToken p0 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(System.String p0, Azure.Core.AzureLocation p1) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.JitNetworkAccessPolicyResource> GetJitNetworkAccessPoliciesByRegion(System.Threading.CancellationToken p0 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.Models.DiscoveredSecuritySolution> GetDiscoveredSecuritySolutionsByHomeRegion(System.Threading.CancellationToken p0 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.Models.ExternalSecuritySolution> GetExternalSecuritySolutionsByHomeRegion(System.Threading.CancellationToken p0 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.Models.SecurityCenterAllowedConnection> GetAllowedConnectionsByHomeRegion(System.Threading.CancellationToken p0 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.Models.SecuritySolutionsReferenceData> GetAllSecuritySolutionsReferenceDataByHomeRegion(System.Threading.CancellationToken p0 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.Models.SecurityTopologyResource> GetTopologiesByHomeRegion(System.Threading.CancellationToken p0 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public virtual Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupCollection GetAdaptiveApplicationControlGroups() => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public virtual Azure.ResourceManager.SecurityCenter.SubscriptionSecurityAlertCollection GetSubscriptionSecurityAlerts() => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public virtual Azure.ResourceManager.SecurityCenter.SubscriptionSecurityTaskCollection GetSubscriptionSecurityTasks() => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupResource> GetAdaptiveApplicationControlGroup(System.String p0, System.Threading.CancellationToken p1 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SubscriptionSecurityAlertResource> GetSubscriptionSecurityAlert(System.String p0, System.Threading.CancellationToken p1 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SubscriptionSecurityTaskResource> GetSubscriptionSecurityTask(System.String p0, System.Threading.CancellationToken p1 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupResource>> GetAdaptiveApplicationControlGroupAsync(System.String p0, System.Threading.CancellationToken p1 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SubscriptionSecurityAlertResource>> GetSubscriptionSecurityAlertAsync(System.String p0, System.Threading.CancellationToken p1 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SubscriptionSecurityTaskResource>> GetSubscriptionSecurityTaskAsync(System.String p0, System.Threading.CancellationToken p1 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
    }
    public partial class SecurityCenterPricingCollection
    {
        [Azure.Core.ForwardsClientCalls]
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.SecurityCenterPricingResource> GetAllAsync(System.Threading.CancellationToken p0 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.SecurityCenterPricingResource> GetAll(System.Threading.CancellationToken p0 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
    }
    public partial class SecurityConnectorApplicationCollection
    {
        [Azure.Core.ForwardsClientCalls]
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SecurityConnectorApplicationResource> CreateOrUpdate(Azure.WaitUntil p0, System.String p1, Azure.ResourceManager.SecurityCenter.SecurityApplicationData p2, System.Threading.CancellationToken p3 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SecurityConnectorApplicationResource>> CreateOrUpdateAsync(Azure.WaitUntil p0, System.String p1, Azure.ResourceManager.SecurityCenter.SecurityApplicationData p2, System.Threading.CancellationToken p3 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
    }
    public partial class SecurityConnectorApplicationResource
    {
        [Azure.Core.ForwardsClientCalls]
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SecurityConnectorApplicationResource> Update(Azure.WaitUntil p0, Azure.ResourceManager.SecurityCenter.SecurityApplicationData p1, System.Threading.CancellationToken p2 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SecurityConnectorApplicationResource>> UpdateAsync(Azure.WaitUntil p0, Azure.ResourceManager.SecurityCenter.SecurityApplicationData p1, System.Threading.CancellationToken p2 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
    }
    public partial class SecurityConnectorGovernanceRuleCollection
    {
        [Azure.Core.ForwardsClientCalls]
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SecurityConnectorGovernanceRuleResource> CreateOrUpdate(Azure.WaitUntil p0, System.String p1, Azure.ResourceManager.SecurityCenter.GovernanceRuleData p2, System.Threading.CancellationToken p3 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SecurityConnectorGovernanceRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil p0, System.String p1, Azure.ResourceManager.SecurityCenter.GovernanceRuleData p2, System.Threading.CancellationToken p3 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
    }
    public partial class SecurityConnectorGovernanceRuleResource
    {
        [Azure.Core.ForwardsClientCalls]
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(System.String p0, System.String p1, System.String p2, System.String p3) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public virtual Azure.ResourceManager.ArmOperation ExecuteRule(Azure.WaitUntil p0, Azure.ResourceManager.SecurityCenter.Models.ExecuteGovernanceRuleParams p1, System.Threading.CancellationToken p2 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.Models.ExecuteRuleStatus> GetRuleExecutionStatus(Azure.WaitUntil p0, System.String p1, System.Threading.CancellationToken p2 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SecurityConnectorGovernanceRuleResource> Update(Azure.WaitUntil p0, Azure.ResourceManager.SecurityCenter.GovernanceRuleData p1, System.Threading.CancellationToken p2 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.Models.ExecuteRuleStatus>> GetRuleExecutionStatusAsync(Azure.WaitUntil p0, System.String p1, System.Threading.CancellationToken p2 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SecurityConnectorGovernanceRuleResource>> UpdateAsync(Azure.WaitUntil p0, Azure.ResourceManager.SecurityCenter.GovernanceRuleData p1, System.Threading.CancellationToken p2 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ExecuteRuleAsync(Azure.WaitUntil p0, Azure.ResourceManager.SecurityCenter.Models.ExecuteGovernanceRuleParams p1, System.Threading.CancellationToken p2 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
    }
    public partial class SecurityConnectorResource
    {
        [Azure.Core.ForwardsClientCalls]
        public virtual Azure.ResourceManager.SecurityCenter.SecurityConnectorGovernanceRuleCollection GetSecurityConnectorGovernanceRules() => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityConnectorGovernanceRuleResource> GetSecurityConnectorGovernanceRule(System.String p0, System.Threading.CancellationToken p1 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityConnectorGovernanceRuleResource>> GetSecurityConnectorGovernanceRuleAsync(System.String p0, System.Threading.CancellationToken p1 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
    }
    public partial class SecurityContactCollection
    {
        [Azure.Core.ForwardsClientCalls]
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SecurityContactResource> CreateOrUpdate(Azure.WaitUntil p0, System.String p1, Azure.ResourceManager.SecurityCenter.SecurityContactData p2, System.Threading.CancellationToken p3 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityContactResource> Get(System.String p0, System.Threading.CancellationToken p1 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public virtual Azure.Response<System.Boolean> Exists(System.String p0, System.Threading.CancellationToken p1 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SecurityContactResource>> CreateOrUpdateAsync(Azure.WaitUntil p0, System.String p1, Azure.ResourceManager.SecurityCenter.SecurityContactData p2, System.Threading.CancellationToken p3 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityContactResource>> GetAsync(System.String p0, System.Threading.CancellationToken p1 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Boolean>> ExistsAsync(System.String p0, System.Threading.CancellationToken p1 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
    }
    public partial class SecurityContactResource
    {
        [Azure.Core.ForwardsClientCalls]
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(System.String p0, System.String p1) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
    }
    public partial class SecuritySettingCollection
    {
        [Azure.Core.ForwardsClientCalls]
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SecuritySettingResource> CreateOrUpdate(Azure.WaitUntil p0, Azure.ResourceManager.SecurityCenter.Models.SecuritySettingName p1, Azure.ResourceManager.SecurityCenter.SecuritySettingData p2, System.Threading.CancellationToken p3 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SecuritySettingResource> Get(Azure.ResourceManager.SecurityCenter.Models.SecuritySettingName p0, System.Threading.CancellationToken p1 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public virtual Azure.Response<System.Boolean> Exists(Azure.ResourceManager.SecurityCenter.Models.SecuritySettingName p0, System.Threading.CancellationToken p1 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SecuritySettingResource>> CreateOrUpdateAsync(Azure.WaitUntil p0, Azure.ResourceManager.SecurityCenter.Models.SecuritySettingName p1, Azure.ResourceManager.SecurityCenter.SecuritySettingData p2, System.Threading.CancellationToken p3 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecuritySettingResource>> GetAsync(Azure.ResourceManager.SecurityCenter.Models.SecuritySettingName p0, System.Threading.CancellationToken p1 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Boolean>> ExistsAsync(Azure.ResourceManager.SecurityCenter.Models.SecuritySettingName p0, System.Threading.CancellationToken p1 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
    }
    public partial class SecuritySettingResource
    {
        [Azure.Core.ForwardsClientCalls]
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(System.String p0, Azure.ResourceManager.SecurityCenter.Models.SecuritySettingName p1) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
    }
    public partial class ServerVulnerabilityAssessmentResource
    {
        [Azure.Core.ForwardsClientCalls]
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(System.String p0, System.String p1, System.String p2, System.String p3, System.String p4) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.ServerVulnerabilityAssessmentResource> Update(Azure.WaitUntil p0, System.Threading.CancellationToken p1 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.ServerVulnerabilityAssessmentResource>> UpdateAsync(Azure.WaitUntil p0, System.Threading.CancellationToken p1 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
    }
    public partial class SqlVulnerabilityAssessmentBaselineRuleCollection
    {
        [Azure.Core.ForwardsClientCalls]
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.SqlVulnerabilityAssessmentBaselineRuleResource> AddRulesAsync(System.Guid p0, Azure.ResourceManager.SecurityCenter.Models.RulesResultsContent p1, System.Threading.CancellationToken p2 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release. Please use AddRulesAsync().", false)]
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.SqlVulnerabilityAssessmentBaselineRuleResource> GetAllAsync(System.Guid p0, Azure.ResourceManager.SecurityCenter.Models.RulesResultsContent p1, System.Threading.CancellationToken p2 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.SqlVulnerabilityAssessmentBaselineRuleResource> GetAllAsync(System.Guid p0, System.Threading.CancellationToken p1 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.SqlVulnerabilityAssessmentBaselineRuleResource> AddRules(System.Guid p0, Azure.ResourceManager.SecurityCenter.Models.RulesResultsContent p1, System.Threading.CancellationToken p2 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release. Please use AddRules().", false)]
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.SqlVulnerabilityAssessmentBaselineRuleResource> GetAll(System.Guid p0, Azure.ResourceManager.SecurityCenter.Models.RulesResultsContent p1, System.Threading.CancellationToken p2 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.SqlVulnerabilityAssessmentBaselineRuleResource> GetAll(System.Guid p0, System.Threading.CancellationToken p1 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SqlVulnerabilityAssessmentBaselineRuleResource> CreateOrUpdate(Azure.WaitUntil p0, System.String p1, System.Guid p2, Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentBaselineRuleCreateOrUpdateContent p3, System.Threading.CancellationToken p4 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SqlVulnerabilityAssessmentBaselineRuleResource> Get(System.String p0, System.Guid p1, System.Threading.CancellationToken p2 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public virtual Azure.Response<System.Boolean> Exists(System.String p0, System.Guid p1, System.Threading.CancellationToken p2 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SqlVulnerabilityAssessmentBaselineRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil p0, System.String p1, System.Guid p2, Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentBaselineRuleCreateOrUpdateContent p3, System.Threading.CancellationToken p4 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SqlVulnerabilityAssessmentBaselineRuleResource>> GetAsync(System.String p0, System.Guid p1, System.Threading.CancellationToken p2 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Boolean>> ExistsAsync(System.String p0, System.Guid p1, System.Threading.CancellationToken p2 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
    }
    public partial class SqlVulnerabilityAssessmentBaselineRuleResource
    {
        [Azure.Core.ForwardsClientCalls]
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil p0, System.Guid p1, System.Threading.CancellationToken p2 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SqlVulnerabilityAssessmentBaselineRuleResource> Update(Azure.WaitUntil p0, System.Guid p1, Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentBaselineRuleCreateOrUpdateContent p2, System.Threading.CancellationToken p3 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SqlVulnerabilityAssessmentBaselineRuleResource> Get(System.Guid p0, System.Threading.CancellationToken p1 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SqlVulnerabilityAssessmentBaselineRuleResource>> UpdateAsync(Azure.WaitUntil p0, System.Guid p1, Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentBaselineRuleCreateOrUpdateContent p2, System.Threading.CancellationToken p3 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil p0, System.Guid p1, System.Threading.CancellationToken p2 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SqlVulnerabilityAssessmentBaselineRuleResource>> GetAsync(System.Guid p0, System.Threading.CancellationToken p1 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
    }
    public partial class SqlVulnerabilityAssessmentScanCollection
    {
        [Azure.Core.ForwardsClientCalls]
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.SqlVulnerabilityAssessmentScanResource> GetAllAsync(System.Guid p0, System.Threading.CancellationToken p1 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.SqlVulnerabilityAssessmentScanResource> GetAll(System.Guid p0, System.Threading.CancellationToken p1 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SqlVulnerabilityAssessmentScanResource> Get(System.String p0, System.Guid p1, System.Threading.CancellationToken p2 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public virtual Azure.Response<System.Boolean> Exists(System.String p0, System.Guid p1, System.Threading.CancellationToken p2 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SqlVulnerabilityAssessmentScanResource>> GetAsync(System.String p0, System.Guid p1, System.Threading.CancellationToken p2 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Boolean>> ExistsAsync(System.String p0, System.Guid p1, System.Threading.CancellationToken p2 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
    }
    public partial class SqlVulnerabilityAssessmentScanResource
    {
        [Azure.Core.ForwardsClientCalls]
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentScanResult> GetSqlVulnerabilityAssessmentScanResultsAsync(System.Guid p0, System.Threading.CancellationToken p1 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentScanResult> GetSqlVulnerabilityAssessmentScanResults(System.Guid p0, System.Threading.CancellationToken p1 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentScanResult> GetSqlVulnerabilityAssessmentScanResult(System.String p0, System.Guid p1, System.Threading.CancellationToken p2 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SqlVulnerabilityAssessmentScanResource> Get(System.Guid p0, System.Threading.CancellationToken p1 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentScanResult>> GetSqlVulnerabilityAssessmentScanResultAsync(System.String p0, System.Guid p1, System.Threading.CancellationToken p2 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        [Azure.Core.ForwardsClientCalls]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SqlVulnerabilityAssessmentScanResource>> GetAsync(System.Guid p0, System.Threading.CancellationToken p1 = default) => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
    }
}
