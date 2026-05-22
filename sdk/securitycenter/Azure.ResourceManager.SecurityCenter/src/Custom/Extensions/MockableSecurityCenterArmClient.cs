// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using Azure.Core;
using CodeGenSuppressAttribute = Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppressAttribute;

namespace Azure.ResourceManager.SecurityCenter.Mocking
{
    // Suppress duplicate generated factory helpers for resource types that appear through multiple Security APIs.
    [CodeGenSuppress("GetAlertResource", typeof(ResourceIdentifier))]
    [CodeGenSuppress("GetAssessmentsMetadatumResource", typeof(ResourceIdentifier))]
    [CodeGenSuppress("GetTaskResource", typeof(ResourceIdentifier))]
    [CodeGenSuppress("GetSqlVulnerabilityAssessmentScanResource", typeof(ResourceIdentifier))]
    public partial class MockableSecurityCenterArmClient
    {
        public virtual AdaptiveApplicationControlGroupResource GetAdaptiveApplicationControlGroupResource(ResourceIdentifier id) => throw new System.NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        public virtual AdaptiveNetworkHardeningResource GetAdaptiveNetworkHardeningResource(ResourceIdentifier id) => throw new System.NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        public virtual CustomAssessmentAutomationResource GetCustomAssessmentAutomationResource(ResourceIdentifier id) => throw new System.NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        public virtual CustomEntityStoreAssignmentResource GetCustomEntityStoreAssignmentResource(ResourceIdentifier id) => throw new System.NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        public virtual IotSecuritySolutionAnalyticsModelResource GetIotSecuritySolutionAnalyticsModelResource(ResourceIdentifier id) => throw new System.NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        public virtual ResourceGroupSecurityAlertResource GetResourceGroupSecurityAlertResource(ResourceIdentifier id) => throw new System.NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        public virtual ResourceGroupSecurityTaskResource GetResourceGroupSecurityTaskResource(ResourceIdentifier id) => throw new System.NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        public virtual SecurityCloudConnectorResource GetSecurityCloudConnectorResource(ResourceIdentifier id) => throw new System.NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        public virtual SoftwareInventoryResource GetSoftwareInventoryResource(ResourceIdentifier id) => throw new System.NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        public virtual SqlVulnerabilityAssessmentScanResource GetSqlVulnerabilityAssessmentScanResource(ResourceIdentifier id) => throw new System.NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        public virtual SubscriptionAssessmentMetadataResource GetSubscriptionAssessmentMetadataResource(ResourceIdentifier id) => throw new System.NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        public virtual SubscriptionGovernanceRuleResource GetSubscriptionGovernanceRuleResource(ResourceIdentifier id) => throw new System.NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        public virtual SubscriptionSecurityAlertResource GetSubscriptionSecurityAlertResource(ResourceIdentifier id) => throw new System.NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        public virtual SubscriptionSecurityApplicationResource GetSubscriptionSecurityApplicationResource(ResourceIdentifier id) => throw new System.NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        public virtual SubscriptionSecurityTaskResource GetSubscriptionSecurityTaskResource(ResourceIdentifier id) => throw new System.NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        public virtual TenantAssessmentMetadataResource GetTenantAssessmentMetadataResource(ResourceIdentifier id) => throw new System.NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        public virtual Azure.Response<SecurityAssessmentResource> GetSecurityAssessment(ResourceIdentifier scope, string assessmentName, Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentODataExpand? expand, System.Threading.CancellationToken cancellationToken = default) => throw new System.NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        public virtual Azure.Response<SqlVulnerabilityAssessmentBaselineRuleResource> GetSqlVulnerabilityAssessmentBaselineRule(ResourceIdentifier scope, string ruleId, System.Guid scanId, System.Threading.CancellationToken cancellationToken = default) => throw new System.NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        public virtual Azure.Response<SqlVulnerabilityAssessmentScanResource> GetSqlVulnerabilityAssessmentScan(ResourceIdentifier scope, string scanId, System.Guid workspaceId, System.Threading.CancellationToken cancellationToken = default) => throw new System.NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        public virtual System.Threading.Tasks.Task<Azure.Response<SecurityAssessmentResource>> GetSecurityAssessmentAsync(ResourceIdentifier scope, string assessmentName, Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentODataExpand? expand, System.Threading.CancellationToken cancellationToken = default) => throw new System.NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        public virtual System.Threading.Tasks.Task<Azure.Response<SqlVulnerabilityAssessmentBaselineRuleResource>> GetSqlVulnerabilityAssessmentBaselineRuleAsync(ResourceIdentifier scope, string ruleId, System.Guid scanId, System.Threading.CancellationToken cancellationToken = default) => throw new System.NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        public virtual System.Threading.Tasks.Task<Azure.Response<SqlVulnerabilityAssessmentScanResource>> GetSqlVulnerabilityAssessmentScanAsync(ResourceIdentifier scope, string scanId, System.Guid workspaceId, System.Threading.CancellationToken cancellationToken = default) => throw new System.NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
    }
}
