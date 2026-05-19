// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS0108, CS0618, CS1591, SA1402

using System;

namespace Azure.ResourceManager.SecurityCenter
{
    public partial class IotSecurityAggregatedAlertData
    {
        public System.Nullable<System.DateTimeOffset> AggregatedOn { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
    }
    public partial class IotSecuritySolutionData
    {
        public System.Nullable<Azure.ResourceManager.SecurityCenter.Models.UnmaskedIPLoggingStatus> UnmaskedIPLoggingStatus { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
    }
    public partial class SecurityAlertsSuppressionRuleData
    {
        public System.Nullable<System.DateTimeOffset> ExpireOn { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
        public System.Nullable<System.DateTimeOffset> LastModifiedOn { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
    }
    public partial class SecurityAssessmentData
    {
        public System.Uri AzurePortalUri { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
    }
    public partial class SecurityCenterPricingData
    {
        public System.Nullable<System.Boolean> IsDeprecated { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
    }
    public partial class SecurityComplianceData
    {
        public System.Nullable<System.DateTimeOffset> AssessedOn { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
    }
    public partial class SecurityContactData
    {
        public Azure.ResourceManager.SecurityCenter.Models.SecurityContactPropertiesAlertNotifications AlertNotifications { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
    }
    public partial class SecuritySubAssessmentData
    {
        public System.Nullable<System.DateTimeOffset> GeneratedOn { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
    }
    public partial class SqlVulnerabilityAssessmentBaselineRuleData
    {
        public System.Collections.Generic.IList<System.Collections.Generic.IList<System.String>> RuleResults { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
    }
}
namespace Azure.ResourceManager.SecurityCenter.Models
{
    public partial class AadExternalSecuritySolution
    {
        public Azure.ResourceManager.SecurityCenter.Models.AadSolutionProperties Properties { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
    }
    public partial class AdditionalWorkspacesProperties
    {
        public System.Nullable<Azure.ResourceManager.SecurityCenter.Models.AdditionalWorkspaceType> WorkspaceType { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
    }
    public partial class AtaExternalSecuritySolution
    {
        public Azure.ResourceManager.SecurityCenter.Models.AtaSolutionProperties Properties { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
    }
    public partial class CefExternalSecuritySolution
    {
        public Azure.ResourceManager.SecurityCenter.Models.CefSolutionProperties Properties { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
    }
    public partial class ContainerRegistryVulnerabilityProperties
    {
        public System.Nullable<System.Boolean> IsPatchable { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
        public System.String ContainerRegistryVulnerabilityPropertiesType { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
    }
    public partial class DataExportSettings
    {
        public System.Nullable<System.Boolean> IsEnabled { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
    }
    public partial class DefenderCspmAwsOfferingVmScanners
    {
        public Azure.ResourceManager.SecurityCenter.Models.DefenderCspmAwsOfferingVmScannersConfiguration Configuration { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
    }
    public partial class DefenderForContainersAwsOffering
    {
        public System.Nullable<System.Boolean> IsAutoProvisioningEnabled { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
        public System.Nullable<System.Boolean> IsContainerVulnerabilityAssessmentEnabled { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
        public System.String ContainerVulnerabilityAssessmentCloudRoleArn { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
        public System.String ContainerVulnerabilityAssessmentTaskCloudRoleArn { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
        public System.String KubernetesScubaReaderCloudRoleArn { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
        public System.String ScubaExternalId { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
    }
    public partial class DefenderForContainersGcpOffering
    {
        public System.Nullable<System.Boolean> IsAuditLogsAutoProvisioningEnabled { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
        public System.Nullable<System.Boolean> IsDefenderAgentAutoProvisioningEnabled { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
        public System.Nullable<System.Boolean> IsPolicyAgentAutoProvisioningEnabled { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
    }
    public partial class DefenderForServersAwsOffering
    {
        public System.Nullable<Azure.ResourceManager.SecurityCenter.Models.AvailableSubPlanType> AvailableSubPlanType { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
    }
    public partial class DefenderForServersAwsOfferingArcAutoProvisioning
    {
        public System.Nullable<System.Boolean> IsEnabled { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
    }
    public partial class DefenderForServersAwsOfferingMdeAutoProvisioning
    {
        public System.Nullable<System.Boolean> IsEnabled { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
    }
    public partial class DefenderForServersAwsOfferingVmScanners
    {
        public Azure.ResourceManager.SecurityCenter.Models.DefenderForServersAwsOfferingVmScannersConfiguration Configuration { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
        public System.Nullable<System.Boolean> IsEnabled { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
    }
    public partial class DefenderForServersAwsOfferingVulnerabilityAssessmentAutoProvisioning
    {
        public System.Nullable<Azure.ResourceManager.SecurityCenter.Models.VulnerabilityAssessmentAutoProvisioningType> VulnerabilityAssessmentAutoProvisioningType { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
        public System.Nullable<System.Boolean> IsEnabled { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
    }
    public partial class DefenderForServersGcpOffering
    {
        public Azure.ResourceManager.SecurityCenter.Models.DefenderForServersGcpOfferingVulnerabilityAssessmentAutoProvisioning VulnerabilityAssessmentAutoProvisioning { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
        public System.Nullable<Azure.ResourceManager.SecurityCenter.Models.AvailableSubPlanType> AvailableSubPlanType { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
        public System.Nullable<System.Boolean> IsArcAutoProvisioningEnabled { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
    }
    public partial class DefenderForServersGcpOfferingMdeAutoProvisioning
    {
        public System.Nullable<System.Boolean> IsEnabled { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
    }
    public readonly partial struct ExternalSecuritySolutionKind
    {
        public static Azure.ResourceManager.SecurityCenter.Models.ExternalSecuritySolutionKind Aad => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        public static Azure.ResourceManager.SecurityCenter.Models.ExternalSecuritySolutionKind Ata => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        public static Azure.ResourceManager.SecurityCenter.Models.ExternalSecuritySolutionKind Cef => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
    }
    public partial class GovernanceEmailNotification
    {
        public System.Nullable<System.Boolean> IsManagerEmailNotificationDisabled { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
        public System.Nullable<System.Boolean> IsOwnerEmailNotificationDisabled { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
    }
    public partial class GovernanceRuleEmailNotification
    {
        public System.Nullable<System.Boolean> IsManagerEmailNotificationDisabled { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
        public System.Nullable<System.Boolean> IsOwnerEmailNotificationDisabled { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
    }
    public partial class GovernanceRuleOwnerSource
    {
        public System.Nullable<Azure.ResourceManager.SecurityCenter.Models.GovernanceRuleOwnerSourceType> SourceType { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
    }
    public readonly partial struct IotSecurityRecommendationType
    {
        public static Azure.ResourceManager.SecurityCenter.Models.IotSecurityRecommendationType IotAcrAuthentication => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        public static Azure.ResourceManager.SecurityCenter.Models.IotSecurityRecommendationType IotAgentSendsUnutilizedMessages => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        public static Azure.ResourceManager.SecurityCenter.Models.IotSecurityRecommendationType IotBaseline => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        public static Azure.ResourceManager.SecurityCenter.Models.IotSecurityRecommendationType IotEdgeHubMemOptimize => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        public static Azure.ResourceManager.SecurityCenter.Models.IotSecurityRecommendationType IotEdgeLoggingOptions => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        public static Azure.ResourceManager.SecurityCenter.Models.IotSecurityRecommendationType IotIPFilterDenyAll => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        public static Azure.ResourceManager.SecurityCenter.Models.IotSecurityRecommendationType IotIPFilterPermissiveRule => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        public static Azure.ResourceManager.SecurityCenter.Models.IotSecurityRecommendationType IotInconsistentModuleSettings => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        public static Azure.ResourceManager.SecurityCenter.Models.IotSecurityRecommendationType IotInstallAgent => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        public static Azure.ResourceManager.SecurityCenter.Models.IotSecurityRecommendationType IotOpenPorts => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        public static Azure.ResourceManager.SecurityCenter.Models.IotSecurityRecommendationType IotPermissiveFirewallPolicy => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        public static Azure.ResourceManager.SecurityCenter.Models.IotSecurityRecommendationType IotPermissiveInputFirewallRules => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        public static Azure.ResourceManager.SecurityCenter.Models.IotSecurityRecommendationType IotPermissiveOutputFirewallRules => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        public static Azure.ResourceManager.SecurityCenter.Models.IotSecurityRecommendationType IotPrivilegedDockerOptions => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        public static Azure.ResourceManager.SecurityCenter.Models.IotSecurityRecommendationType IotSharedCredentials => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        public static Azure.ResourceManager.SecurityCenter.Models.IotSecurityRecommendationType IotVulnerableTlsCipherSuite => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
    }
    public partial class JitNetworkAccessPolicyInitiatePort
    {
        public System.DateTimeOffset EndOn { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
    }
    public partial class JitNetworkAccessPolicyVirtualMachine
    {
        public System.String PublicIPAddress { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
    }
    public readonly partial struct JitNetworkAccessPortProtocol
    {
        public static Azure.ResourceManager.SecurityCenter.Models.JitNetworkAccessPortProtocol Tcp => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        public static Azure.ResourceManager.SecurityCenter.Models.JitNetworkAccessPortProtocol Udp => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
    }
    public partial class JitNetworkAccessRequestPort
    {
        public System.DateTimeOffset EndOn { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
    }
    public partial class OnPremiseResourceDetails
    {
        public System.Guid VmUuid { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
    }
    public partial class SecurityAssessmentMetadataProperties
    {
        public System.Nullable<System.Boolean> IsPreview { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
    }
    public readonly partial struct SecurityFamily
    {
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityFamily VulnerabilityAssessment => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
    }
    public partial class SecurityTaskProperties
    {
        public System.Collections.Generic.IDictionary<System.String, System.BinaryData> AdditionalProperties { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
        public System.String Name { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
    }
    public readonly partial struct SecurityValueType
    {
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityValueType IPCidr => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
    }
    public partial class ServerVulnerabilityProperties
    {
        public System.Nullable<System.Boolean> IsPatchable { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
        public System.String ServerVulnerabilityType { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
    }
    public partial class SqlServerVulnerabilityProperties
    {
        public System.String SqlServerVulnerabilityType { get => throw new NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
    }
}
