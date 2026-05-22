// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS0108, CS0618, CS1591, SA1402

using System;
using CodeGenSuppressAttribute = Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppressAttribute;

namespace Azure.ResourceManager.SecurityCenter
{
    // Compatibility shims for members reported only when building the source project with ApiCompat enabled.
    [CodeGenSuppress("AutoProvision")]
    public partial class AutoProvisioningSettingData
    {
        public Azure.ResourceManager.SecurityCenter.Models.AutoProvisionState? AutoProvision { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
    }

    [CodeGenSuppress("ComplianceResultData")]
    [CodeGenSuppress("ResourceStatus")]
    public partial class ComplianceResultData
    {
        public ComplianceResultData() { }
        public Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentResourceStatus? ResourceStatus { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
    }

    [CodeGenSuppress("AdditionalData")]
    public partial class GovernanceAssignmentData
    {
        public Azure.ResourceManager.SecurityCenter.Models.GovernanceAssignmentAdditionalInfo AdditionalData { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
    }

    [CodeGenSuppress("IotSecurityAggregatedAlertData")]
    [CodeGenSuppress("TopDevicesList")]
    public partial class IotSecurityAggregatedAlertData
    {
        public IotSecurityAggregatedAlertData() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SecurityCenter.Models.IotSecurityAggregatedAlertTopDevice> TopDevicesList { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
    }

    [CodeGenSuppress("IotSecurityAggregatedRecommendationData")]
    [CodeGenSuppress("RecommendationName")]
    public partial class IotSecurityAggregatedRecommendationData
    {
        public IotSecurityAggregatedRecommendationData() { }
        public string RecommendationName { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
    }

    [CodeGenSuppress("DisabledDataSources")]
    [CodeGenSuppress("Export")]
    public partial class IotSecuritySolutionData
    {
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityCenter.Models.IotSecuritySolutionDataSource> DisabledDataSources { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityCenter.Models.IotSecuritySolutionExportOption> Export { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
    }

    [CodeGenSuppress("Requests")]
    public partial class JitNetworkAccessPolicyData
    {
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityCenter.Models.JitNetworkAccessRequestInfo> Requests { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
    }

    [CodeGenSuppress("RegulatoryComplianceAssessmentData")]
    [CodeGenSuppress("State")]
    public partial class RegulatoryComplianceAssessmentData
    {
        public RegulatoryComplianceAssessmentData() { }
        public Azure.ResourceManager.SecurityCenter.Models.RegulatoryComplianceState? State { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
    }

    [CodeGenSuppress("RegulatoryComplianceControlData")]
    [CodeGenSuppress("State")]
    public partial class RegulatoryComplianceControlData
    {
        public RegulatoryComplianceControlData() { }
        public Azure.ResourceManager.SecurityCenter.Models.RegulatoryComplianceState? State { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
    }

    [CodeGenSuppress("RegulatoryComplianceStandardData")]
    [CodeGenSuppress("State")]
    public partial class RegulatoryComplianceStandardData
    {
        public RegulatoryComplianceStandardData() { }
        public Azure.ResourceManager.SecurityCenter.Models.RegulatoryComplianceState? State { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
    }

    [CodeGenSuppress("SecureScoreData")]
    public partial class SecureScoreData
    {
        public SecureScoreData() { }
    }

    [CodeGenSuppress("State")]
    [CodeGenSuppress("SuppressionAlertsScopeAllOf")]
    public partial class SecurityAlertsSuppressionRuleData
    {
        public Azure.ResourceManager.SecurityCenter.Models.SecurityAlertsSuppressionRuleState? State { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityCenter.Models.SuppressionAlertsScopeElement> SuppressionAlertsScopeAllOf { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
    }

    [CodeGenSuppress("SecurityAssessmentData")]
    [CodeGenSuppress("Metadata")]
    [CodeGenSuppress("PartnersData")]
    [CodeGenSuppress("ResourceDetails")]
    [CodeGenSuppress("Status")]
    public partial class SecurityAssessmentData
    {
        public SecurityAssessmentData() { }
        public Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentMetadataProperties Metadata { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
        public Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentPartner PartnersData { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
        public Azure.ResourceManager.SecurityCenter.Models.SecurityCenterResourceDetails ResourceDetails { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
        public Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentStatusResult Status { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
    }

    [CodeGenSuppress("Actions")]
    [CodeGenSuppress("Scopes")]
    [CodeGenSuppress("Sources")]
    public partial class SecurityAutomationData
    {
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityCenter.Models.SecurityAutomationAction> Actions { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityCenter.Models.SecurityAutomationScope> Scopes { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityCenter.Models.SecurityAutomationSource> Sources { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
    }

    [CodeGenSuppress("SecurityCenterLocationData")]
    [CodeGenSuppress("Properties")]
    public partial class SecurityCenterLocationData
    {
        private BinaryData _properties;

        public SecurityCenterLocationData() { }
        public BinaryData Properties { get => _properties; set => _properties = value; }
    }

    [CodeGenSuppress("PricingTier")]
    public partial class SecurityCenterPricingData
    {
        public Azure.ResourceManager.SecurityCenter.Models.SecurityCenterPricingTier? PricingTier { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
    }

    [CodeGenSuppress("SecurityComplianceData")]
    public partial class SecurityComplianceData
    {
        public SecurityComplianceData() { }
    }

    [CodeGenSuppress("Data")]
    public partial class SecurityConnectorApplicationResource
    {
        public virtual Azure.ResourceManager.SecurityCenter.SecurityApplicationData Data { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
    }

    [CodeGenSuppress("EnvironmentData")]
    [CodeGenSuppress("EnvironmentName")]
    public partial class SecurityConnectorData
    {
        public Azure.ResourceManager.SecurityCenter.Models.SecurityConnectorEnvironment EnvironmentData { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
        public Azure.ResourceManager.SecurityCenter.Models.SecurityCenterCloudName? EnvironmentName { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
    }

    [CodeGenSuppress("Data")]
    public partial class SecurityConnectorGovernanceRuleResource
    {
        public virtual Azure.ResourceManager.SecurityCenter.GovernanceRuleData Data { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
    }

    [CodeGenSuppress("SecuritySettingData")]
    public partial class SecuritySettingData
    {
        public SecuritySettingData() { }
    }

    [CodeGenSuppress("SecuritySubAssessmentData")]
    [CodeGenSuppress("AdditionalData")]
    [CodeGenSuppress("ResourceDetails")]
    [CodeGenSuppress("Status")]
    public partial class SecuritySubAssessmentData
    {
        public SecuritySubAssessmentData() { }
        public Azure.ResourceManager.SecurityCenter.Models.SecuritySubAssessmentAdditionalInfo AdditionalData { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
        public Azure.ResourceManager.SecurityCenter.Models.SecurityCenterResourceDetails ResourceDetails { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
        public Azure.ResourceManager.SecurityCenter.Models.SubAssessmentStatus Status { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
    }

    [CodeGenSuppress("WorkspaceId")]
    public partial class SecurityWorkspaceSettingData
    {
        public Azure.Core.ResourceIdentifier WorkspaceId { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
    }

    [CodeGenSuppress("ServerVulnerabilityAssessmentData")]
    public partial class ServerVulnerabilityAssessmentData
    {
        public ServerVulnerabilityAssessmentData() { }
    }

    [CodeGenSuppress("SqlVulnerabilityAssessmentBaselineRuleData")]
    public partial class SqlVulnerabilityAssessmentBaselineRuleData
    {
        public SqlVulnerabilityAssessmentBaselineRuleData() { }
    }

    [CodeGenSuppress("SqlVulnerabilityAssessmentScanData")]
    [CodeGenSuppress("Properties")]
    public partial class SqlVulnerabilityAssessmentScanData
    {
        public SqlVulnerabilityAssessmentScanData() { }
        public Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentScanProperties Properties { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
    }
}

namespace Azure.ResourceManager.SecurityCenter.Models
{
    [CodeGenSuppress("AadExternalSecuritySolution")]
    public partial class AadExternalSecuritySolution : ExternalSecuritySolution
    {
        public AadExternalSecuritySolution() { }
    }

    [CodeGenSuppress("AadSolutionProperties")]
    [CodeGenSuppress("ConnectivityState")]
    public partial class AadSolutionProperties : ExternalSecuritySolutionProperties
    {
        public AadSolutionProperties() { }
        public Azure.ResourceManager.SecurityCenter.Models.AadConnectivityStateType? ConnectivityState { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
    }

    [CodeGenSuppress("AtaExternalSecuritySolution")]
    public partial class AtaExternalSecuritySolution : ExternalSecuritySolution
    {
        public AtaExternalSecuritySolution() { }
    }

    [CodeGenSuppress("AtaSolutionProperties")]
    [CodeGenSuppress("LastEventReceived")]
    public partial class AtaSolutionProperties : ExternalSecuritySolutionProperties
    {
        public AtaSolutionProperties() { }
        public string LastEventReceived { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
    }

    [CodeGenSuppress("BaselineAdjustedResult")]
    [CodeGenSuppress("Baseline")]
    [CodeGenSuppress("Status")]
    public partial class BaselineAdjustedResult
    {
        public BaselineAdjustedResult() { }
        public Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentBaseline Baseline { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
        public Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentScanResultRuleStatus? Status { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
    }

    [CodeGenSuppress("BenchmarkReference")]
    [CodeGenSuppress("Benchmark")]
    [CodeGenSuppress("Reference")]
    public partial class BenchmarkReference
    {
        public BenchmarkReference() { }
        public string Benchmark { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
        public string Reference { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
    }

    [CodeGenSuppress("CefExternalSecuritySolution")]
    public partial class CefExternalSecuritySolution : ExternalSecuritySolution
    {
        public CefExternalSecuritySolution() { }
    }

    [CodeGenSuppress("CefSolutionProperties")]
    [CodeGenSuppress("Agent")]
    [CodeGenSuppress("Hostname")]
    [CodeGenSuppress("LastEventReceived")]
    public partial class CefSolutionProperties : ExternalSecuritySolutionProperties
    {
        public CefSolutionProperties() { }
        public string Agent { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
        public string Hostname { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
        public string LastEventReceived { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
    }

    [CodeGenSuppress("ContainerRegistryVulnerabilityProperties")]
    public partial class ContainerRegistryVulnerabilityProperties
    {
        public ContainerRegistryVulnerabilityProperties() { }
    }

    [CodeGenSuppress("ExternalSecuritySolutionProperties")]
    [CodeGenSuppress("DeviceType")]
    [CodeGenSuppress("DeviceVendor")]
    [CodeGenSuppress("WorkspaceId")]
    public partial class ExternalSecuritySolutionProperties
    {
        public ExternalSecuritySolutionProperties() { }
        public System.Collections.Generic.IDictionary<string, BinaryData> AdditionalProperties { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
        public string DeviceType { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
        public string DeviceVendor { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
        public Azure.Core.ResourceIdentifier WorkspaceId { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
    }

    [CodeGenSuppress("SecureScoreControlDefinitionItem")]
    [CodeGenSuppress("AssessmentDefinitions")]
    [CodeGenSuppress("SourceType")]
    public partial class SecureScoreControlDefinitionItem
    {
        public SecureScoreControlDefinitionItem() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> AssessmentDefinitions { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
        public Azure.ResourceManager.SecurityCenter.Models.SecurityControlType? SourceType { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
    }

    [CodeGenSuppress("SecureScoreControlDetails")]
    [CodeGenSuppress("Definition")]
    public partial class SecureScoreControlDetails
    {
        public SecureScoreControlDetails() { }
        public Azure.ResourceManager.SecurityCenter.Models.SecureScoreControlDefinitionItem Definition { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
    }

    [CodeGenSuppress("AlertVendorName")]
    [CodeGenSuppress("PackageInfoUri")]
    [CodeGenSuppress("ProductName")]
    [CodeGenSuppress("Publisher")]
    [CodeGenSuppress("PublisherDisplayName")]
    [CodeGenSuppress("SecurityFamily")]
    [CodeGenSuppress("Template")]
    public partial class SecuritySolutionsReferenceData
    {
        public string AlertVendorName { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
        public System.Uri PackageInfoUri { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
        public string ProductName { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
        public string Publisher { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
        public string PublisherDisplayName { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
        public Azure.ResourceManager.SecurityCenter.Models.SecurityFamily SecurityFamily { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
        public string Template { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
    }

    [CodeGenSuppress("SecurityTaskProperties")]
    public partial class SecurityTaskProperties
    {
        public SecurityTaskProperties() { }
    }

    [CodeGenSuppress("ServerVulnerabilityProperties")]
    public partial class ServerVulnerabilityProperties
    {
        public ServerVulnerabilityProperties() { }
    }

    [CodeGenSuppress("SqlServerVulnerabilityProperties")]
    public partial class SqlServerVulnerabilityProperties
    {
        public SqlServerVulnerabilityProperties() { }
    }

    [CodeGenSuppress("SqlVulnerabilityAssessmentBaseline")]
    [CodeGenSuppress("UpdatedOn")]
    public partial class SqlVulnerabilityAssessmentBaseline
    {
        public SqlVulnerabilityAssessmentBaseline() { }
        public System.DateTimeOffset? UpdatedOn { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
    }

    [CodeGenSuppress("SqlVulnerabilityAssessmentScanProperties")]
    [CodeGenSuppress("Database")]
    [CodeGenSuppress("EndOn")]
    [CodeGenSuppress("HighSeverityFailedRulesCount")]
    [CodeGenSuppress("IsBaselineApplied")]
    [CodeGenSuppress("LowSeverityFailedRulesCount")]
    [CodeGenSuppress("MediumSeverityFailedRulesCount")]
    [CodeGenSuppress("Server")]
    [CodeGenSuppress("SqlVersion")]
    [CodeGenSuppress("StartOn")]
    [CodeGenSuppress("State")]
    [CodeGenSuppress("TotalFailedRulesCount")]
    [CodeGenSuppress("TotalPassedRulesCount")]
    [CodeGenSuppress("TotalRulesCount")]
    [CodeGenSuppress("TriggerType")]
    public partial class SqlVulnerabilityAssessmentScanProperties
    {
        public SqlVulnerabilityAssessmentScanProperties() { }
        public string Database { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
        public System.DateTimeOffset? EndOn { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
        public int? HighSeverityFailedRulesCount { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
        public bool? IsBaselineApplied { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
        public int? LowSeverityFailedRulesCount { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
        public int? MediumSeverityFailedRulesCount { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
        public string Server { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
        public string SqlVersion { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
        public System.DateTimeOffset? StartOn { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
        public Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentScanState? State { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
        public int? TotalFailedRulesCount { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
        public int? TotalPassedRulesCount { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
        public int? TotalRulesCount { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
        public Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentScanTriggerType? TriggerType { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
    }

    [CodeGenSuppress("SubAssessmentStatus")]
    public partial class SubAssessmentStatus
    {
        public SubAssessmentStatus() { }
    }
}
