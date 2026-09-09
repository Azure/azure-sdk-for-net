// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using Microsoft.TypeSpec.Generator.Customizations;

#pragma warning disable CS1591 // Compatibility enums preserve the released beta.1 API.

namespace Azure.Provisioning.SecurityCenter;

/// <summary> BuiltIn if the assessment based on built-in Azure Policy definition, Custom if the assessment based on custom Azure Policy definition. </summary>
[CodeGenType("SecurityAssessmentType")]
public enum SecurityAssessmentType
{
    /// <summary> Microsoft Defender for Cloud managed assessments. </summary>
    BuiltIn = 0,
    /// <summary> User defined policies that are automatically ingested from Azure Policy to Microsoft Defender for Cloud. </summary>
    CustomPolicy = 1,
    /// <summary> User assessments pushed directly by the user or other third party to Microsoft Defender for Cloud. </summary>
    CustomerManaged = 2,
    /// <summary> Third party assessments that are verified by Microsoft Defender for Cloud. </summary>
    VerifiedPartner = 3,
    /// <summary> Unknown assessment type. </summary>
    Unknown = 4,
    /// <summary> User defined custom assessments. </summary>
    Custom = 5,
    /// <summary> Microsoft Defender for Cloud managed policies. </summary>
    BuiltInPolicy = 6,
    /// <summary> Microsoft Defender for Cloud managed policies that are manually created by the user. </summary>
    ManualBuiltInPolicy = 7,
    /// <summary> Microsoft Defender for Cloud managed assessments that are manually created by the user. </summary>
    ManualBuiltIn = 8,
    /// <summary> User defined policies that are manually created by the user. </summary>
    ManualCustomPolicy = 9,
    /// <summary> Microsoft Defender for Cloud managed assessments that are dynamically created by the system. </summary>
    DynamicBuiltIn = 10,
}

/// <summary> The categories of resource that is at risk when the assessment is unhealthy. </summary>
[CodeGenType("SecurityAssessmentResourceCategory")]
public enum SecurityAssessmentResourceCategory
{
    /// <summary> IoT. </summary>
    IoT = 0,
    /// <summary> Compute. </summary>
    Compute = 1,
    /// <summary> Networking. </summary>
    Networking = 2,
    /// <summary> Data. </summary>
    Data = 3,
    /// <summary> IdentityAndAccess. </summary>
    IdentityAndAccess = 4,
    /// <summary> Container. </summary>
    Container = 5,
    /// <summary> AppServices. </summary>
    AppServices = 6,
}

/// <summary> Defines whether to send email notifications from Microsoft Defender for Cloud to persons with specific RBAC roles on the subscription. </summary>
[CodeGenType("SecurityAlertNotificationByRoleState")]
[Experimental("AZPROVISION001")]
public enum SecurityAlertNotificationByRoleState
{
    /// <summary> Send notification on new alerts to the subscription&apos;s admins. </summary>
    On = 0,
    /// <summary> Don&apos;t send notification on new alerts to the subscription&apos;s admins. </summary>
    Off = 1,
    /// <summary> All supported regulatory compliance controls in the given standard have a passed state. </summary>
    Passed = 2,
    /// <summary> At least one supported regulatory compliance control in the given standard has a state of failed. </summary>
    Failed = 3,
    /// <summary> All supported regulatory compliance controls in the given standard have a state of skipped. </summary>
    Skipped = 4,
    /// <summary> No supported regulatory compliance data for the given standard. </summary>
    Unsupported = 5,
}

/// <summary> Indicates whether the extension is enabled. </summary>
[CodeGenType("SecurityCenterExtensionIsEnabled")]
public enum IsExtensionEnabled
{
    /// <summary> The extension is enabled. </summary>
    True = 0,
    /// <summary> The extension is disabled. </summary>
    False = 1,
}

/// <summary> The status code of an extension operation. </summary>
public enum ExtensionOperationStatusCode
{
    /// <summary> The operation succeeded. </summary>
    Succeeded = 0,
    /// <summary> The operation failed. </summary>
    Failed = 1,
}

/// <summary> The DevOps auto-discovery state. </summary>
public enum DevOpsAutoDiscovery
{
    /// <summary> Auto-discovery is disabled. </summary>
    Disabled = 0,
    /// <summary> Auto-discovery is enabled. </summary>
    Enabled = 1,
    /// <summary> Auto-discovery is not applicable. </summary>
    NotApplicable = 2,
}

/// <summary> The onboarding state of a DevOps resource. </summary>
public enum ResourceOnboardingState
{
    /// <summary> Onboarding is not applicable. </summary>
    NotApplicable = 0,
    /// <summary> The resource was onboarded by another connector. </summary>
    OnboardedByOtherConnector = 1,
    /// <summary> The resource is onboarded. </summary>
    Onboarded = 2,
    /// <summary> The resource is not onboarded. </summary>
    NotOnboarded = 3,
}

/// <summary> The provisioning state of a Security family resource. </summary>
public enum SecurityFamilyProvisioningState
{
    /// <summary> Provisioning succeeded. </summary>
    Succeeded = 0,
    /// <summary> Provisioning failed. </summary>
    Failed = 1,
    /// <summary> Provisioning is updating. </summary>
    Updating = 2,
}

/// <summary> The security alert notification state. </summary>
public enum SecurityAlertNotificationState
{
    /// <summary> Notifications are enabled. </summary>
    On = 0,
    /// <summary> Notifications are disabled. </summary>
    Off = 1,
}

/// <summary> Adaptive application control enforcement mode. </summary>
public enum AdaptiveApplicationControlEnforcementMode
{
    Audit = 0,
    Enforce = 1,
    None = 2,
}

/// <summary> Adaptive application control source system. </summary>
public enum AdaptiveApplicationControlGroupSourceSystem
{
    [DataMember(Name = "Azure_AppLocker")]
    AzureAppLocker = 0,
    [DataMember(Name = "Azure_AuditD")]
    AzureAuditD = 1,
    [DataMember(Name = "NonAzure_AppLocker")]
    NonAzureAppLocker = 2,
    [DataMember(Name = "NonAzure_AuditD")]
    NonAzureAuditD = 3,
    None = 4,
}

/// <summary> Adaptive application control issue. </summary>
public enum AdaptiveApplicationControlIssue
{
    ViolationsAudited = 0,
    ViolationsBlocked = 1,
    MsiAndScriptViolationsAudited = 2,
    MsiAndScriptViolationsBlocked = 3,
    ExecutableViolationsAudited = 4,
    RulesViolatedManually = 5,
}

/// <summary> Authentication provisioning state. </summary>
public enum AuthenticationProvisioningState
{
    Valid = 0,
    Invalid = 1,
    Expired = 2,
    IncorrectPolicy = 3,
}

/// <summary> Supported cloud for a custom assessment automation. </summary>
public enum CustomAssessmentAutomationSupportedCloud
{
    [DataMember(Name = "AWS")]
    Aws = 0,
    [DataMember(Name = "GCP")]
    Gcp = 1,
}

/// <summary> Custom assessment severity. </summary>
public enum CustomAssessmentSeverity
{
    High = 0,
    Medium = 1,
    Low = 2,
}

/// <summary> Hybrid compute provisioning state. </summary>
public enum HybridComputeProvisioningState
{
    Valid = 0,
    Invalid = 1,
    Expired = 2,
}

/// <summary> File type for an adaptive application control path recommendation. </summary>
public enum PathRecommendationFileType
{
    Exe = 0,
    Dll = 1,
    Msi = 2,
    Script = 3,
    Executable = 4,
    Unknown = 5,
}

/// <summary> Recommendation action. </summary>
public enum RecommendationAction
{
    Recommended = 0,
    Add = 1,
    Remove = 2,
}

/// <summary> Recommendation status. </summary>
public enum RecommendationStatus
{
    Recommended = 0,
    NotRecommended = 1,
    NotAvailable = 2,
    NoStatus = 3,
}

/// <summary> Cloud permission granted to a security connector. </summary>
public enum SecurityCenterCloudPermission
{
    [DataMember(Name = "AWS::AWSSecurityHubReadOnlyAccess")]
    AwsAwsSecurityHubReadOnlyAccess = 0,
    [DataMember(Name = "AWS::SecurityAudit")]
    AwsSecurityAudit = 1,
    [DataMember(Name = "AWS::AmazonSSMAutomationRole")]
    AwsAmazonSsmAutomationRole = 2,
    [DataMember(Name = "GCP::Security Center Admin Viewer")]
    GcpSecurityCenterAdminViewer = 3,
}

/// <summary> Security Center configuration status. </summary>
public enum SecurityCenterConfigurationStatus
{
    Configured = 0,
    NotConfigured = 1,
    InProgress = 2,
    Failed = 3,
    NoStatus = 4,
}

/// <summary> VM enforcement support state. </summary>
public enum SecurityCenterVmEnforcementSupportState
{
    Supported = 0,
    NotSupported = 1,
    Unknown = 2,
}
