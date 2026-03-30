namespace Azure.Provisioning.SecurityCenter
{
    public partial class ActionableRemediation : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ActionableRemediation() { }
        public Azure.Provisioning.SecurityCenter.TargetBranchConfiguration BranchConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SecurityCenter.CategoryConfiguration> CategoryConfigurations { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.InheritFromParentState> InheritFromParentState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.ActionableRemediationState> State { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ActionableRemediationState
    {
        None = 0,
        Disabled = 1,
        Enabled = 2,
    }
    public partial class ActiveConnectionsNotInAllowedRange : Azure.Provisioning.SecurityCenter.TimeWindowCustomAlertRule
    {
        public ActiveConnectionsNotInAllowedRange() { }
        protected override void DefineProvisionableProperties() { }
    }
    public enum AdaptiveApplicationControlEnforcementMode
    {
        Audit = 0,
        Enforce = 1,
        None = 2,
    }
    public partial class AdaptiveApplicationControlGroup : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public AdaptiveApplicationControlGroup(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.SecurityCenterConfigurationStatus> ConfigurationStatus { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.AdaptiveApplicationControlEnforcementMode> EnforcementMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SecurityCenter.AdaptiveApplicationControlIssueSummary> Issues { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SecurityCenter.PathRecommendation> PathRecommendations { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.SecurityCenterFileProtectionMode ProtectionMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.RecommendationStatus> RecommendationStatus { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.AdaptiveApplicationControlGroupSourceSystem> SourceSystem { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SecurityCenter.VmRecommendation> VmRecommendations { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SecurityCenter.AdaptiveApplicationControlGroup FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2020_01_01;
        }
    }
    public enum AdaptiveApplicationControlGroupSourceSystem
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="Azure_AppLocker")]
        AzureAppLocker = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Azure_AuditD")]
        AzureAuditD = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="NonAzure_AppLocker")]
        NonAzureAppLocker = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="NonAzure_AuditD")]
        NonAzureAuditD = 3,
        None = 4,
    }
    public enum AdaptiveApplicationControlIssue
    {
        ViolationsAudited = 0,
        ViolationsBlocked = 1,
        MsiAndScriptViolationsAudited = 2,
        MsiAndScriptViolationsBlocked = 3,
        ExecutableViolationsAudited = 4,
        RulesViolatedManually = 5,
    }
    public partial class AdaptiveApplicationControlIssueSummary : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AdaptiveApplicationControlIssueSummary() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.AdaptiveApplicationControlIssue> Issue { get { throw null; } }
        public Azure.Provisioning.BicepValue<float> NumberOfVms { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum AdditionalWorkspaceDataType
    {
        Alerts = 0,
        RawEvents = 1,
    }
    public partial class AdditionalWorkspacesProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AdditionalWorkspacesProperties() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SecurityCenter.AdditionalWorkspaceDataType> DataTypes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Workspace { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.AdditionalWorkspaceType> WorkspaceType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum AdditionalWorkspaceType
    {
        Sentinel = 0,
    }
    public partial class AdvancedThreatProtectionSetting : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public AdvancedThreatProtectionSetting(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SecurityCenter.AdvancedThreatProtectionSetting FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2019_01_01;
        }
    }
    public partial class AllowlistCustomAlertRule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AllowlistCustomAlertRule() { }
        public Azure.Provisioning.BicepList<string> AllowlistValues { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.SecurityValueType> ValueType { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AmqpC2DMessagesNotInAllowedRange : Azure.Provisioning.SecurityCenter.TimeWindowCustomAlertRule
    {
        public AmqpC2DMessagesNotInAllowedRange() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AmqpC2DRejectedMessagesNotInAllowedRange : Azure.Provisioning.SecurityCenter.TimeWindowCustomAlertRule
    {
        public AmqpC2DRejectedMessagesNotInAllowedRange() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AmqpD2CMessagesNotInAllowedRange : Azure.Provisioning.SecurityCenter.TimeWindowCustomAlertRule
    {
        public AmqpD2CMessagesNotInAllowedRange() { }
        protected override void DefineProvisionableProperties() { }
    }
    public enum AnnotateDefaultBranchState
    {
        Disabled = 0,
        Enabled = 1,
    }
    public enum ApplicationSourceResourceType
    {
        Assessments = 0,
    }
    public partial class AuthenticationDetailsProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AuthenticationDetailsProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.AuthenticationProvisioningState> AuthenticationProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SecurityCenter.SecurityCenterCloudPermission> GrantedPermissions { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum AuthenticationProvisioningState
    {
        Valid = 0,
        Invalid = 1,
        Expired = 2,
        IncorrectPolicy = 3,
    }
    public enum AutomationTriggeringRuleOperator
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="Equals")]
        EqualsValue = 0,
        GreaterThan = 1,
        GreaterThanOrEqualTo = 2,
        LesserThan = 3,
        LesserThanOrEqualTo = 4,
        NotEquals = 5,
        Contains = 6,
        StartsWith = 7,
        EndsWith = 8,
    }
    public enum AutomationTriggeringRulePropertyType
    {
        String = 0,
        Integer = 1,
        Number = 2,
        Boolean = 3,
    }
    public partial class AutoProvisioningSetting : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public AutoProvisioningSetting(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.AutoProvisionState> AutoProvision { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SecurityCenter.AutoProvisioningSetting FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
    }
    public enum AutoProvisionState
    {
        On = 0,
        Off = 1,
    }
    public enum AvailableSubPlanType
    {
        P1 = 0,
        P2 = 1,
    }
    public partial class AwsAssumeRoleAuthenticationDetailsProperties : Azure.Provisioning.SecurityCenter.AuthenticationDetailsProperties
    {
        public AwsAssumeRoleAuthenticationDetailsProperties() { }
        public Azure.Provisioning.BicepValue<string> AccountId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> AwsAssumeRoleArn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> AwsExternalId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AwsCredsAuthenticationDetailsProperties : Azure.Provisioning.SecurityCenter.AuthenticationDetailsProperties
    {
        public AwsCredsAuthenticationDetailsProperties() { }
        public Azure.Provisioning.BicepValue<string> AccountId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> AwsAccessKeyId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AwsSecretAccessKey { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AwsEnvironment : Azure.Provisioning.SecurityCenter.SecurityConnectorEnvironment
    {
        public AwsEnvironment() { }
        public Azure.Provisioning.BicepValue<string> AccountName { get { throw null; } }
        public Azure.Provisioning.SecurityCenter.AwsOrganizationalInfo OrganizationalData { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Regions { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> ScanInterval { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AwsOrganizationalDataMaster : Azure.Provisioning.SecurityCenter.AwsOrganizationalInfo
    {
        public AwsOrganizationalDataMaster() { }
        public Azure.Provisioning.BicepList<string> ExcludedAccountIds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StacksetName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AwsOrganizationalDataMember : Azure.Provisioning.SecurityCenter.AwsOrganizationalInfo
    {
        public AwsOrganizationalDataMember() { }
        public Azure.Provisioning.BicepValue<string> ParentHierarchyId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AwsOrganizationalInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AwsOrganizationalInfo() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AzureDevOpsScopeEnvironment : Azure.Provisioning.SecurityCenter.SecurityConnectorEnvironment
    {
        public AzureDevOpsScopeEnvironment() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AzureResourceDetails : Azure.Provisioning.SecurityCenter.SecurityCenterResourceDetails
    {
        public AzureResourceDetails() { }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AzureServersSetting : Azure.Provisioning.SecurityCenter.ServerVulnerabilityAssessmentsSetting
    {
        public AzureServersSetting(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.ServerVulnerabilityAssessmentsAzureSettingSelectedProvider> SelectedProvider { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BuiltInInfoType : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BuiltInInfoType() { }
        public Azure.Provisioning.BicepValue<string> BuiltInInfoTypeValue { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CategoryConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CategoryConfiguration() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.RuleCategory> Category { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MinimumSeverityLevel { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ConnectionFromIPNotAllowed : Azure.Provisioning.SecurityCenter.AllowlistCustomAlertRule
    {
        public ConnectionFromIPNotAllowed() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ConnectionToIPNotAllowed : Azure.Provisioning.SecurityCenter.AllowlistCustomAlertRule
    {
        public ConnectionToIPNotAllowed() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CspmMonitorAwsOffering : Azure.Provisioning.SecurityCenter.SecurityCenterCloudOffering
    {
        public CspmMonitorAwsOffering() { }
        public Azure.Provisioning.BicepValue<string> CloudRoleArn { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CspmMonitorAzureDevOpsOffering : Azure.Provisioning.SecurityCenter.SecurityCenterCloudOffering
    {
        public CspmMonitorAzureDevOpsOffering() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CspmMonitorGcpOffering : Azure.Provisioning.SecurityCenter.SecurityCenterCloudOffering
    {
        public CspmMonitorGcpOffering() { }
        public Azure.Provisioning.SecurityCenter.CspmMonitorGcpOfferingNativeCloudConnection NativeCloudConnection { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CspmMonitorGcpOfferingNativeCloudConnection : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CspmMonitorGcpOfferingNativeCloudConnection() { }
        public Azure.Provisioning.BicepValue<string> ServiceAccountEmailAddress { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WorkloadIdentityProviderId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CspmMonitorGithubOffering : Azure.Provisioning.SecurityCenter.SecurityCenterCloudOffering
    {
        public CspmMonitorGithubOffering() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CspmMonitorGitLabOffering : Azure.Provisioning.SecurityCenter.SecurityCenterCloudOffering
    {
        public CspmMonitorGitLabOffering() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CustomAssessmentAutomation : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public CustomAssessmentAutomation(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> AssessmentKey { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> CompressedQuery { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RemediationDescription { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.CustomAssessmentSeverity> Severity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.CustomAssessmentAutomationSupportedCloud> SupportedCloud { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SecurityCenter.CustomAssessmentAutomation FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
    }
    public enum CustomAssessmentAutomationSupportedCloud
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="AWS")]
        Aws = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="GCP")]
        Gcp = 1,
    }
    public enum CustomAssessmentSeverity
    {
        High = 0,
        Medium = 1,
        Low = 2,
    }
    public partial class CustomEntityStoreAssignment : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public CustomEntityStoreAssignment(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> EntityStoreDatabaseLink { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Principal { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SecurityCenter.CustomEntityStoreAssignment FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
    }
    public partial class DataExportSettings : Azure.Provisioning.SecurityCenter.SecuritySetting
    {
        public DataExportSettings(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(string)) { }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DefenderCspmAwsOffering : Azure.Provisioning.SecurityCenter.SecurityCenterCloudOffering
    {
        public DefenderCspmAwsOffering() { }
        public Azure.Provisioning.SecurityCenter.DefenderCspmAwsOfferingCiem Ciem { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.DefenderCspmAwsOfferingDatabasesDspm DatabasesDspm { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.DefenderCspmAwsOfferingDataSensitivityDiscovery DataSensitivityDiscovery { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.DefenderCspmAwsOfferingMdcContainersAgentlessDiscoveryK8S MdcContainersAgentlessDiscoveryK8S { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.DefenderCspmAwsOfferingMdcContainersImageAssessment MdcContainersImageAssessment { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.DefenderCspmAwsOfferingVmScanners VmScanners { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DefenderCspmAwsOfferingCiem : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DefenderCspmAwsOfferingCiem() { }
        public Azure.Provisioning.BicepValue<string> CiemDiscoveryCloudRoleArn { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.DefenderCspmAwsOfferingCiemOidc CiemOidc { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DefenderCspmAwsOfferingCiemOidc : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DefenderCspmAwsOfferingCiemOidc() { }
        public Azure.Provisioning.BicepValue<string> AzureActiveDirectoryAppName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CloudRoleArn { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DefenderCspmAwsOfferingDatabasesDspm : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DefenderCspmAwsOfferingDatabasesDspm() { }
        public Azure.Provisioning.BicepValue<string> CloudRoleArn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DefenderCspmAwsOfferingDataSensitivityDiscovery : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DefenderCspmAwsOfferingDataSensitivityDiscovery() { }
        public Azure.Provisioning.BicepValue<string> CloudRoleArn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DefenderCspmAwsOfferingMdcContainersAgentlessDiscoveryK8S : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DefenderCspmAwsOfferingMdcContainersAgentlessDiscoveryK8S() { }
        public Azure.Provisioning.BicepValue<string> CloudRoleArn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DefenderCspmAwsOfferingMdcContainersImageAssessment : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DefenderCspmAwsOfferingMdcContainersImageAssessment() { }
        public Azure.Provisioning.BicepValue<string> CloudRoleArn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DefenderCspmAwsOfferingVmScanners : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DefenderCspmAwsOfferingVmScanners() { }
        public Azure.Provisioning.SecurityCenter.DefenderCspmAwsOfferingVmScannersConfiguration Configuration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> Enabled { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DefenderCspmAwsOfferingVmScannersConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DefenderCspmAwsOfferingVmScannersConfiguration() { }
        public Azure.Provisioning.BicepValue<string> CloudRoleArn { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> ExclusionTags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.DefenderForServersScanningMode> ScanningMode { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DefenderCspmGcpOffering : Azure.Provisioning.SecurityCenter.SecurityCenterCloudOffering
    {
        public DefenderCspmGcpOffering() { }
        public Azure.Provisioning.SecurityCenter.DefenderCspmGcpOfferingCiemDiscovery CiemDiscovery { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.DefenderCspmGcpOfferingDataSensitivityDiscovery DataSensitivityDiscovery { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.DefenderCspmGcpOfferingMdcContainersAgentlessDiscoveryK8S MdcContainersAgentlessDiscoveryK8S { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.DefenderCspmGcpOfferingMdcContainersImageAssessment MdcContainersImageAssessment { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.DefenderCspmGcpOfferingVmScanners VmScanners { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DefenderCspmGcpOfferingCiemDiscovery : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DefenderCspmGcpOfferingCiemDiscovery() { }
        public Azure.Provisioning.BicepValue<string> AzureActiveDirectoryAppName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServiceAccountEmailAddress { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WorkloadIdentityProviderId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DefenderCspmGcpOfferingDataSensitivityDiscovery : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DefenderCspmGcpOfferingDataSensitivityDiscovery() { }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServiceAccountEmailAddress { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WorkloadIdentityProviderId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DefenderCspmGcpOfferingMdcContainersAgentlessDiscoveryK8S : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DefenderCspmGcpOfferingMdcContainersAgentlessDiscoveryK8S() { }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServiceAccountEmailAddress { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WorkloadIdentityProviderId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DefenderCspmGcpOfferingMdcContainersImageAssessment : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DefenderCspmGcpOfferingMdcContainersImageAssessment() { }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServiceAccountEmailAddress { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WorkloadIdentityProviderId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DefenderCspmGcpOfferingVmScanners : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DefenderCspmGcpOfferingVmScanners() { }
        public Azure.Provisioning.SecurityCenter.DefenderCspmGcpOfferingVmScannersConfiguration Configuration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DefenderCspmGcpOfferingVmScannersConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DefenderCspmGcpOfferingVmScannersConfiguration() { }
        public Azure.Provisioning.BicepDictionary<string> ExclusionTags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.DefenderForServersScanningMode> ScanningMode { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DefenderFoDatabasesAwsOfferingArcAutoProvisioningConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DefenderFoDatabasesAwsOfferingArcAutoProvisioningConfiguration() { }
        public Azure.Provisioning.BicepValue<string> PrivateLinkScope { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Proxy { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DefenderFoDatabasesAwsOfferingDatabasesDspm : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DefenderFoDatabasesAwsOfferingDatabasesDspm() { }
        public Azure.Provisioning.BicepValue<string> CloudRoleArn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DefenderForContainersAwsOffering : Azure.Provisioning.SecurityCenter.SecurityCenterCloudOffering
    {
        public DefenderForContainersAwsOffering() { }
        public Azure.Provisioning.BicepValue<string> CloudRoleArn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ContainerVulnerabilityAssessmentCloudRoleArn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ContainerVulnerabilityAssessmentTaskCloudRoleArn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsAutoProvisioningEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsContainerVulnerabilityAssessmentEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> KinesisToS3CloudRoleArn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> KubeAuditRetentionTime { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> KubernetesScubaReaderCloudRoleArn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> KubernetesServiceCloudRoleArn { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.DefenderForContainersAwsOfferingMdcContainersAgentlessDiscoveryK8S MdcContainersAgentlessDiscoveryK8S { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.DefenderForContainersAwsOfferingMdcContainersImageAssessment MdcContainersImageAssessment { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ScubaExternalId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DefenderForContainersAwsOfferingMdcContainersAgentlessDiscoveryK8S : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DefenderForContainersAwsOfferingMdcContainersAgentlessDiscoveryK8S() { }
        public Azure.Provisioning.BicepValue<string> CloudRoleArn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DefenderForContainersAwsOfferingMdcContainersImageAssessment : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DefenderForContainersAwsOfferingMdcContainersImageAssessment() { }
        public Azure.Provisioning.BicepValue<string> CloudRoleArn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DefenderForContainersGcpOffering : Azure.Provisioning.SecurityCenter.SecurityCenterCloudOffering
    {
        public DefenderForContainersGcpOffering() { }
        public Azure.Provisioning.SecurityCenter.DefenderForContainersGcpOfferingDataPipelineNativeCloudConnection DataPipelineNativeCloudConnection { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsAuditLogsAutoProvisioningEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsDefenderAgentAutoProvisioningEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsPolicyAgentAutoProvisioningEnabled { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.DefenderForContainersGcpOfferingMdcContainersAgentlessDiscoveryK8S MdcContainersAgentlessDiscoveryK8S { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.DefenderForContainersGcpOfferingMdcContainersImageAssessment MdcContainersImageAssessment { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.DefenderForContainersGcpOfferingNativeCloudConnection NativeCloudConnection { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DefenderForContainersGcpOfferingDataPipelineNativeCloudConnection : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DefenderForContainersGcpOfferingDataPipelineNativeCloudConnection() { }
        public Azure.Provisioning.BicepValue<string> ServiceAccountEmailAddress { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WorkloadIdentityProviderId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DefenderForContainersGcpOfferingMdcContainersAgentlessDiscoveryK8S : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DefenderForContainersGcpOfferingMdcContainersAgentlessDiscoveryK8S() { }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServiceAccountEmailAddress { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WorkloadIdentityProviderId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DefenderForContainersGcpOfferingMdcContainersImageAssessment : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DefenderForContainersGcpOfferingMdcContainersImageAssessment() { }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServiceAccountEmailAddress { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WorkloadIdentityProviderId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DefenderForContainersGcpOfferingNativeCloudConnection : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DefenderForContainersGcpOfferingNativeCloudConnection() { }
        public Azure.Provisioning.BicepValue<string> ServiceAccountEmailAddress { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WorkloadIdentityProviderId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DefenderForDatabasesAwsOffering : Azure.Provisioning.SecurityCenter.SecurityCenterCloudOffering
    {
        public DefenderForDatabasesAwsOffering() { }
        public Azure.Provisioning.SecurityCenter.DefenderForDatabasesAwsOfferingArcAutoProvisioning ArcAutoProvisioning { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.DefenderFoDatabasesAwsOfferingDatabasesDspm DatabasesDspm { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.DefenderForDatabasesAwsOfferingRds Rds { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DefenderForDatabasesAwsOfferingArcAutoProvisioning : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DefenderForDatabasesAwsOfferingArcAutoProvisioning() { }
        public Azure.Provisioning.BicepValue<string> CloudRoleArn { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.DefenderFoDatabasesAwsOfferingArcAutoProvisioningConfiguration Configuration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DefenderForDatabasesAwsOfferingRds : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DefenderForDatabasesAwsOfferingRds() { }
        public Azure.Provisioning.BicepValue<string> CloudRoleArn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DefenderForDatabasesGcpOffering : Azure.Provisioning.SecurityCenter.SecurityCenterCloudOffering
    {
        public DefenderForDatabasesGcpOffering() { }
        public Azure.Provisioning.SecurityCenter.DefenderForDatabasesGcpOfferingArcAutoProvisioning ArcAutoProvisioning { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.GcpDefenderForDatabasesArcAutoProvisioning DefenderForDatabasesArcAutoProvisioning { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DefenderForDatabasesGcpOfferingArcAutoProvisioning : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DefenderForDatabasesGcpOfferingArcAutoProvisioning() { }
        public Azure.Provisioning.SecurityCenter.DefenderForDatabasesGcpOfferingArcAutoProvisioningConfiguration Configuration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DefenderForDatabasesGcpOfferingArcAutoProvisioningConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DefenderForDatabasesGcpOfferingArcAutoProvisioningConfiguration() { }
        public Azure.Provisioning.BicepValue<string> PrivateLinkScope { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Proxy { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DefenderForDevOpsAzureDevOpsOffering : Azure.Provisioning.SecurityCenter.SecurityCenterCloudOffering
    {
        public DefenderForDevOpsAzureDevOpsOffering() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DefenderForDevOpsGithubOffering : Azure.Provisioning.SecurityCenter.SecurityCenterCloudOffering
    {
        public DefenderForDevOpsGithubOffering() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DefenderForDevOpsGitLabOffering : Azure.Provisioning.SecurityCenter.SecurityCenterCloudOffering
    {
        public DefenderForDevOpsGitLabOffering() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DefenderForServersAwsOffering : Azure.Provisioning.SecurityCenter.SecurityCenterCloudOffering
    {
        public DefenderForServersAwsOffering() { }
        public Azure.Provisioning.SecurityCenter.DefenderForServersAwsOfferingArcAutoProvisioning ArcAutoProvisioning { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.AvailableSubPlanType> AvailableSubPlanType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DefenderForServersCloudRoleArn { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.DefenderForServersAwsOfferingMdeAutoProvisioning MdeAutoProvisioning { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.DefenderForServersAwsOfferingVulnerabilityAssessmentAutoProvisioning VaAutoProvisioning { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.DefenderForServersAwsOfferingVmScanners VmScanners { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DefenderForServersAwsOfferingArcAutoProvisioning : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DefenderForServersAwsOfferingArcAutoProvisioning() { }
        public Azure.Provisioning.BicepValue<string> CloudRoleArn { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.DefenderForServersAwsOfferingArcAutoProvisioningConfiguration Configuration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DefenderForServersAwsOfferingArcAutoProvisioningConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DefenderForServersAwsOfferingArcAutoProvisioningConfiguration() { }
        public Azure.Provisioning.BicepValue<string> PrivateLinkScope { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Proxy { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DefenderForServersAwsOfferingMdeAutoProvisioning : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DefenderForServersAwsOfferingMdeAutoProvisioning() { }
        public Azure.Provisioning.BicepValue<System.BinaryData> Configuration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DefenderForServersAwsOfferingVmScanners : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DefenderForServersAwsOfferingVmScanners() { }
        public Azure.Provisioning.SecurityCenter.DefenderForServersAwsOfferingVmScannersConfiguration Configuration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DefenderForServersAwsOfferingVmScannersConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DefenderForServersAwsOfferingVmScannersConfiguration() { }
        public Azure.Provisioning.BicepValue<string> CloudRoleArn { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> ExclusionTags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.DefenderForServersScanningMode> ScanningMode { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DefenderForServersAwsOfferingVulnerabilityAssessmentAutoProvisioning : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DefenderForServersAwsOfferingVulnerabilityAssessmentAutoProvisioning() { }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.VulnerabilityAssessmentAutoProvisioningType> VulnerabilityAssessmentAutoProvisioningType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DefenderForServersGcpOffering : Azure.Provisioning.SecurityCenter.SecurityCenterCloudOffering
    {
        public DefenderForServersGcpOffering() { }
        public Azure.Provisioning.SecurityCenter.DefenderForServersGcpOfferingArcAutoProvisioning ArcAutoProvisioning { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.AvailableSubPlanType> AvailableSubPlanType { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.GcpDefenderForServersInfo DefenderForServers { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.DefenderForServersGcpOfferingMdeAutoProvisioning MdeAutoProvisioning { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.DefenderForServersGcpOfferingVmScanners VmScanners { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.DefenderForServersGcpOfferingVulnerabilityAssessmentAutoProvisioning VulnerabilityAssessmentAutoProvisioning { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DefenderForServersGcpOfferingArcAutoProvisioning : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DefenderForServersGcpOfferingArcAutoProvisioning() { }
        public Azure.Provisioning.SecurityCenter.DefenderForServersGcpOfferingArcAutoProvisioningConfiguration Configuration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DefenderForServersGcpOfferingArcAutoProvisioningConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DefenderForServersGcpOfferingArcAutoProvisioningConfiguration() { }
        public Azure.Provisioning.BicepValue<string> PrivateLinkScope { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Proxy { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DefenderForServersGcpOfferingMdeAutoProvisioning : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DefenderForServersGcpOfferingMdeAutoProvisioning() { }
        public Azure.Provisioning.BicepValue<System.BinaryData> Configuration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DefenderForServersGcpOfferingVmScanners : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DefenderForServersGcpOfferingVmScanners() { }
        public Azure.Provisioning.SecurityCenter.DefenderForServersGcpOfferingVmScannersConfiguration Configuration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DefenderForServersGcpOfferingVmScannersConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DefenderForServersGcpOfferingVmScannersConfiguration() { }
        public Azure.Provisioning.BicepDictionary<string> ExclusionTags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.DefenderForServersScanningMode> ScanningMode { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DefenderForServersGcpOfferingVulnerabilityAssessmentAutoProvisioning : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DefenderForServersGcpOfferingVulnerabilityAssessmentAutoProvisioning() { }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.VulnerabilityAssessmentAutoProvisioningType> VulnerabilityAssessmentAutoProvisioningType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DefenderForServersScanningMode
    {
        Default = 0,
    }
    public partial class DefenderForStorageSetting : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DefenderForStorageSetting(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<int> CapGBPerMonth { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsMalwareScanningOnUploadEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsOverrideSubscriptionLevelSettingsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsSensitiveDataDiscoveryEnabled { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.ExtensionOperationStatus MalwareScanningOperationStatus { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ScanResultsEventGridTopicResourceId { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.ExtensionOperationStatus SensitiveDataDiscoveryOperationStatus { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SecurityCenter.DefenderForStorageSetting FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
    }
    public partial class DenylistCustomAlertRule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DenylistCustomAlertRule() { }
        public Azure.Provisioning.BicepList<string> DenylistValues { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.SecurityValueType> ValueType { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DeviceSecurityGroup : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DeviceSecurityGroup(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SecurityCenter.AllowlistCustomAlertRule> AllowlistRules { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SecurityCenter.DenylistCustomAlertRule> DenylistRules { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SecurityCenter.ThresholdCustomAlertRule> ThresholdRules { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SecurityCenter.TimeWindowCustomAlertRule> TimeWindowRules { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SecurityCenter.DeviceSecurityGroup FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2019_08_01;
        }
    }
    public enum DevOpsAutoDiscovery
    {
        Disabled = 0,
        Enabled = 1,
        NotApplicable = 2,
    }
    public partial class DevOpsConfiguration : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DevOpsConfiguration(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.SecurityCenter.SecurityConnector? Parent { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.DevOpsConfigurationProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SecurityCenter.DevOpsConfiguration FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
    }
    public partial class DevOpsConfigurationProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DevOpsConfigurationProperties() { }
        public Azure.Provisioning.BicepValue<string> AuthorizationCode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.DevOpsAutoDiscovery> AutoDiscovery { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.DevOpsProvisioningState> ProvisioningState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProvisioningStatusMessage { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ProvisioningStatusUpdateTimeUtc { get { throw null; } }
        public Azure.Provisioning.BicepList<string> TopLevelInventoryList { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DevOpsOrg : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DevOpsOrg(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.DevOpsConfiguration? Parent { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.DevOpsOrgProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SecurityCenter.DevOpsOrg FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
    }
    public partial class DevOpsOrgProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DevOpsOrgProperties() { }
        public Azure.Provisioning.SecurityCenter.ActionableRemediation ActionableRemediation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.ResourceOnboardingState> OnboardingState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.DevOpsProvisioningState> ProvisioningState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProvisioningStatusMessage { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ProvisioningStatusUpdatedOn { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DevOpsProject : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DevOpsProject(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.DevOpsOrg? Parent { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.DevOpsProjectProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SecurityCenter.DevOpsProject FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
    }
    public partial class DevOpsProjectProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DevOpsProjectProperties() { }
        public Azure.Provisioning.SecurityCenter.ActionableRemediation ActionableRemediation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.ResourceOnboardingState> OnboardingState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ParentOrgName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProjectId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.DevOpsProvisioningState> ProvisioningState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProvisioningStatusMessage { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ProvisioningStatusUpdatedOn { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DevOpsProvisioningState
    {
        Succeeded = 0,
        Failed = 1,
        Canceled = 2,
        Pending = 3,
        PendingDeletion = 4,
        DeletionSuccess = 5,
        DeletionFailure = 6,
    }
    public partial class DevOpsRepository : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DevOpsRepository(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.DevOpsProject? Parent { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.DevOpsRepositoryProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SecurityCenter.DevOpsRepository FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
    }
    public partial class DevOpsRepositoryProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DevOpsRepositoryProperties() { }
        public Azure.Provisioning.SecurityCenter.ActionableRemediation ActionableRemediation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.ResourceOnboardingState> OnboardingState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ParentOrgName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ParentProjectName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.DevOpsProvisioningState> ProvisioningState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProvisioningStatusMessage { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ProvisioningStatusUpdatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> RepoId { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Uri> RepoUri { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Visibility { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DirectMethodInvokesNotInAllowedRange : Azure.Provisioning.SecurityCenter.TimeWindowCustomAlertRule
    {
        public DirectMethodInvokesNotInAllowedRange() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ExtensionOperationStatus : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ExtensionOperationStatus() { }
        public Azure.Provisioning.BicepValue<string> Code { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Message { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ExtensionOperationStatusCode
    {
        Succeeded = 0,
        Failed = 1,
    }
    public partial class FailedLocalLoginsNotInAllowedRange : Azure.Provisioning.SecurityCenter.TimeWindowCustomAlertRule
    {
        public FailedLocalLoginsNotInAllowedRange() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class FileUploadsNotInAllowedRange : Azure.Provisioning.SecurityCenter.TimeWindowCustomAlertRule
    {
        public FileUploadsNotInAllowedRange() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class GcpCredentialsDetailsProperties : Azure.Provisioning.SecurityCenter.AuthenticationDetailsProperties
    {
        public GcpCredentialsDetailsProperties() { }
        public Azure.Provisioning.BicepValue<System.Uri> AuthProviderX509CertUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> AuthUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ClientEmail { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ClientId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> ClientX509CertUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> GcpCredentialType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> OrganizationId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PrivateKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PrivateKeyId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProjectId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> TokenUri { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class GcpDefenderForDatabasesArcAutoProvisioning : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public GcpDefenderForDatabasesArcAutoProvisioning() { }
        public Azure.Provisioning.BicepValue<string> ServiceAccountEmailAddress { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WorkloadIdentityProviderId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class GcpDefenderForServersInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public GcpDefenderForServersInfo() { }
        public Azure.Provisioning.BicepValue<string> ServiceAccountEmailAddress { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WorkloadIdentityProviderId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class GcpMemberOrganizationalInfo : Azure.Provisioning.SecurityCenter.GcpOrganizationalInfo
    {
        public GcpMemberOrganizationalInfo() { }
        public Azure.Provisioning.BicepValue<string> ManagementProjectNumber { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ParentHierarchyId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class GcpOrganizationalInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public GcpOrganizationalInfo() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class GcpParentOrganizationalInfo : Azure.Provisioning.SecurityCenter.GcpOrganizationalInfo
    {
        public GcpParentOrganizationalInfo() { }
        public Azure.Provisioning.BicepList<string> ExcludedProjectNumbers { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> OrganizationName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ServiceAccountEmailAddress { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WorkloadIdentityProviderId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class GcpProjectDetails : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public GcpProjectDetails() { }
        public Azure.Provisioning.BicepValue<string> ProjectId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProjectName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ProjectNumber { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WorkloadIdentityPoolId { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class GcpProjectEnvironment : Azure.Provisioning.SecurityCenter.SecurityConnectorEnvironment
    {
        public GcpProjectEnvironment() { }
        public Azure.Provisioning.SecurityCenter.GcpOrganizationalInfo OrganizationalData { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.GcpProjectDetails ProjectDetails { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> ScanInterval { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class GetSensitivitySettingsResponsePropertiesMipInformation : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public GetSensitivitySettingsResponsePropertiesMipInformation() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SecurityCenter.BuiltInInfoType> BuiltInInfoTypes { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SecurityCenter.UserDefinedInformationType> CustomInfoTypes { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SecurityCenter.MipSensitivityLabel> Labels { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.MipIntegrationStatus> MipIntegrationStatus { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class GithubScopeEnvironment : Azure.Provisioning.SecurityCenter.SecurityConnectorEnvironment
    {
        public GithubScopeEnvironment() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class GitlabScopeEnvironment : Azure.Provisioning.SecurityCenter.SecurityConnectorEnvironment
    {
        public GitlabScopeEnvironment() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class GovernanceAssignment : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public GovernanceAssignment(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.SecurityCenter.GovernanceAssignmentAdditionalInfo AdditionalData { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.GovernanceEmailNotification GovernanceEmailNotification { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsGracePeriod { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Owner { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.SecurityAssessment? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> RemediationDueOn { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.RemediationEta RemediationEta { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SecurityCenter.GovernanceAssignment FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
    }
    public partial class GovernanceAssignmentAdditionalInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public GovernanceAssignmentAdditionalInfo() { }
        public Azure.Provisioning.BicepValue<string> TicketLink { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> TicketNumber { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TicketStatus { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class GovernanceEmailNotification : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public GovernanceEmailNotification() { }
        public Azure.Provisioning.BicepValue<bool> IsManagerEmailNotificationDisabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsOwnerEmailNotificationDisabled { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class GovernanceRule : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public GovernanceRule(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<System.BinaryData> ConditionSets { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> ExcludedScopes { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.GovernanceRuleEmailNotification GovernanceEmailNotification { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IncludeMemberScopes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsDisabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsGracePeriod { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.GovernanceRuleMetadata Metadata { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.SecurityCenter.GovernanceRuleOwnerSource OwnerSource { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RemediationTimeframe { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> RulePriority { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.GovernanceRuleType> RuleType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.GovernanceRuleSourceResourceType> SourceResourceType { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> TenantId { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SecurityCenter.GovernanceRule FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
    }
    public partial class GovernanceRuleEmailNotification : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public GovernanceRuleEmailNotification() { }
        public Azure.Provisioning.BicepValue<bool> IsManagerEmailNotificationDisabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsOwnerEmailNotificationDisabled { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class GovernanceRuleMetadata : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public GovernanceRuleMetadata() { }
        public Azure.Provisioning.BicepValue<string> CreatedBy { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> UpdatedBy { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> UpdatedOn { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class GovernanceRuleOwnerSource : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public GovernanceRuleOwnerSource() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.GovernanceRuleOwnerSourceType> SourceType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum GovernanceRuleOwnerSourceType
    {
        ByTag = 0,
        Manually = 1,
    }
    public enum GovernanceRuleSourceResourceType
    {
        Assessments = 0,
    }
    public enum GovernanceRuleType
    {
        Integrated = 0,
        ServiceNow = 1,
    }
    public partial class HttpC2DMessagesNotInAllowedRange : Azure.Provisioning.SecurityCenter.TimeWindowCustomAlertRule
    {
        public HttpC2DMessagesNotInAllowedRange() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class HttpC2DRejectedMessagesNotInAllowedRange : Azure.Provisioning.SecurityCenter.TimeWindowCustomAlertRule
    {
        public HttpC2DRejectedMessagesNotInAllowedRange() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class HttpD2CMessagesNotInAllowedRange : Azure.Provisioning.SecurityCenter.TimeWindowCustomAlertRule
    {
        public HttpD2CMessagesNotInAllowedRange() { }
        protected override void DefineProvisionableProperties() { }
    }
    public enum HybridComputeProvisioningState
    {
        Valid = 0,
        Invalid = 1,
        Expired = 2,
    }
    public partial class HybridComputeSettingsProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public HybridComputeSettingsProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.AutoProvisionState> AutoProvision { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.HybridComputeProvisioningState> HybridComputeProvisioningState { get { throw null; } }
        public Azure.Provisioning.SecurityCenter.ProxyServerProperties ProxyServer { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Region { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ResourceGroupName { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.ServicePrincipalProperties ServicePrincipal { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ImplementationEffort
    {
        Low = 0,
        Moderate = 1,
        High = 2,
    }
    public partial class InformationProtectionAwsOffering : Azure.Provisioning.SecurityCenter.SecurityCenterCloudOffering
    {
        public InformationProtectionAwsOffering() { }
        public Azure.Provisioning.BicepValue<string> InformationProtectionCloudRoleArn { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum InheritFromParentState
    {
        Disabled = 0,
        Enabled = 1,
    }
    public enum IotSecurityRecommendationType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="IoT_ACRAuthentication")]
        IotAcrAuthentication = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="IoT_AgentSendsUnutilizedMessages")]
        IotAgentSendsUnutilizedMessages = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="IoT_Baseline")]
        IotBaseline = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="IoT_EdgeHubMemOptimize")]
        IotEdgeHubMemOptimize = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="IoT_EdgeLoggingOptions")]
        IotEdgeLoggingOptions = 4,
        [System.Runtime.Serialization.DataMemberAttribute(Name="IoT_InconsistentModuleSettings")]
        IotInconsistentModuleSettings = 5,
        [System.Runtime.Serialization.DataMemberAttribute(Name="IoT_InstallAgent")]
        IotInstallAgent = 6,
        [System.Runtime.Serialization.DataMemberAttribute(Name="IoT_IPFilter_DenyAll")]
        IotIPFilterDenyAll = 7,
        [System.Runtime.Serialization.DataMemberAttribute(Name="IoT_IPFilter_PermissiveRule")]
        IotIPFilterPermissiveRule = 8,
        [System.Runtime.Serialization.DataMemberAttribute(Name="IoT_OpenPorts")]
        IotOpenPorts = 9,
        [System.Runtime.Serialization.DataMemberAttribute(Name="IoT_PermissiveFirewallPolicy")]
        IotPermissiveFirewallPolicy = 10,
        [System.Runtime.Serialization.DataMemberAttribute(Name="IoT_PermissiveInputFirewallRules")]
        IotPermissiveInputFirewallRules = 11,
        [System.Runtime.Serialization.DataMemberAttribute(Name="IoT_PermissiveOutputFirewallRules")]
        IotPermissiveOutputFirewallRules = 12,
        [System.Runtime.Serialization.DataMemberAttribute(Name="IoT_PrivilegedDockerOptions")]
        IotPrivilegedDockerOptions = 13,
        [System.Runtime.Serialization.DataMemberAttribute(Name="IoT_SharedCredentials")]
        IotSharedCredentials = 14,
        [System.Runtime.Serialization.DataMemberAttribute(Name="IoT_VulnerableTLSCipherSuite")]
        IotVulnerableTlsCipherSuite = 15,
    }
    public partial class IotSecuritySolution : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public IotSecuritySolution(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SecurityCenter.AdditionalWorkspacesProperties> AdditionalWorkspaces { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> AutoDiscoveredResources { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SecurityCenter.IotSecuritySolutionDataSource> DisabledDataSources { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SecurityCenter.IotSecuritySolutionExportOption> Export { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepList<string> IotHubs { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SecurityCenter.RecommendationConfigurationProperties> RecommendationsConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.SecuritySolutionStatus> Status { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.UnmaskedIPLoggingStatus> UnmaskedIPLoggingStatus { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.UserDefinedResourcesProperties UserDefinedResources { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Workspace { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SecurityCenter.IotSecuritySolution FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2019_08_01;
        }
    }
    public enum IotSecuritySolutionDataSource
    {
        TwinData = 0,
    }
    public enum IotSecuritySolutionExportOption
    {
        RawEvents = 0,
    }
    public enum IsExtensionEnabled
    {
        True = 0,
        False = 1,
    }
    public partial class JitNetworkAccessPolicy : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public JitNetworkAccessPolicy(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SecurityCenter.JitNetworkAccessRequestInfo> Requests { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SecurityCenter.JitNetworkAccessPolicyVirtualMachine> VirtualMachines { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SecurityCenter.JitNetworkAccessPolicy FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2020_01_01;
        }
    }
    public partial class JitNetworkAccessPolicyVirtualMachine : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public JitNetworkAccessPolicyVirtualMachine() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SecurityCenter.JitNetworkAccessPortRule> Ports { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PublicIPAddress { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum JitNetworkAccessPortProtocol
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="TCP")]
        Tcp = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="UDP")]
        Udp = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="*")]
        All = 2,
    }
    public partial class JitNetworkAccessPortRule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public JitNetworkAccessPortRule() { }
        public Azure.Provisioning.BicepValue<string> AllowedSourceAddressPrefix { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> AllowedSourceAddressPrefixes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> MaxRequestAccessDuration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Number { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.JitNetworkAccessPortProtocol> Protocol { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum JitNetworkAccessPortStatus
    {
        Revoked = 0,
        Initiated = 1,
    }
    public enum JitNetworkAccessPortStatusReason
    {
        Expired = 0,
        UserRequested = 1,
        NewerRequestInitiated = 2,
    }
    public partial class JitNetworkAccessRequestInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public JitNetworkAccessRequestInfo() { }
        public Azure.Provisioning.BicepValue<string> Justification { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Requestor { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> StartOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SecurityCenter.JitNetworkAccessRequestVirtualMachine> VirtualMachines { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class JitNetworkAccessRequestPort : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public JitNetworkAccessRequestPort() { }
        public Azure.Provisioning.BicepValue<string> AllowedSourceAddressPrefix { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> AllowedSourceAddressPrefixes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> EndOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MappedPort { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Number { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.JitNetworkAccessPortStatus> Status { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.JitNetworkAccessPortStatusReason> StatusReason { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class JitNetworkAccessRequestVirtualMachine : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public JitNetworkAccessRequestVirtualMachine() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SecurityCenter.JitNetworkAccessRequestPort> Ports { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class LocalUserNotAllowed : Azure.Provisioning.SecurityCenter.AllowlistCustomAlertRule
    {
        public LocalUserNotAllowed() { }
        protected override void DefineProvisionableProperties() { }
    }
    public enum MipIntegrationStatus
    {
        Ok = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="noConsent")]
        NoConsent = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="noAutoLabelingRules")]
        NoAutoLabelingRules = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="noMipLabels")]
        NoMipLabels = 3,
    }
    public partial class MipSensitivityLabel : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MipSensitivityLabel() { }
        public Azure.Provisioning.BicepValue<System.Guid> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<float> Order { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MqttC2DMessagesNotInAllowedRange : Azure.Provisioning.SecurityCenter.TimeWindowCustomAlertRule
    {
        public MqttC2DMessagesNotInAllowedRange() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MqttC2DRejectedMessagesNotInAllowedRange : Azure.Provisioning.SecurityCenter.TimeWindowCustomAlertRule
    {
        public MqttC2DRejectedMessagesNotInAllowedRange() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MqttD2CMessagesNotInAllowedRange : Azure.Provisioning.SecurityCenter.TimeWindowCustomAlertRule
    {
        public MqttD2CMessagesNotInAllowedRange() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class OnPremiseResourceDetails : Azure.Provisioning.SecurityCenter.SecurityCenterResourceDetails
    {
        public OnPremiseResourceDetails() { }
        public Azure.Provisioning.BicepValue<string> MachineName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SourceComputerId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> VmUuid { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> WorkspaceId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class OnPremiseSqlResourceDetails : Azure.Provisioning.SecurityCenter.OnPremiseResourceDetails
    {
        public OnPremiseSqlResourceDetails() { }
        public Azure.Provisioning.BicepValue<string> DatabaseName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServerName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class OperationStatusAutoGenerated : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public OperationStatusAutoGenerated() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.ExtensionOperationStatusCode> Code { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Message { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class PathRecommendation : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PathRecommendation() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.RecommendationAction> Action { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.SecurityCenterConfigurationStatus> ConfigurationStatus { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.PathRecommendationFileType> FileType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.IotSecurityRecommendationType> IotSecurityRecommendationType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsCommon { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Path { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.SecurityCenterPublisherInfo PublisherInfo { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SecurityCenter.UserRecommendation> Usernames { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> UserSids { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum PathRecommendationFileType
    {
        Exe = 0,
        Dll = 1,
        Msi = 2,
        Script = 3,
        Executable = 4,
        Unknown = 5,
    }
    public partial class PlanExtension : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PlanExtension() { }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> AdditionalExtensionProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.IsExtensionEnabled> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.OperationStatusAutoGenerated OperationStatus { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ProcessNotAllowed : Azure.Provisioning.SecurityCenter.AllowlistCustomAlertRule
    {
        public ProcessNotAllowed() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ProxyServerProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ProxyServerProperties() { }
        public Azure.Provisioning.BicepValue<string> IP { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Port { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class QueuePurgesNotInAllowedRange : Azure.Provisioning.SecurityCenter.TimeWindowCustomAlertRule
    {
        public QueuePurgesNotInAllowedRange() { }
        protected override void DefineProvisionableProperties() { }
    }
    public enum RecommendationAction
    {
        Recommended = 0,
        Add = 1,
        Remove = 2,
    }
    public enum RecommendationConfigStatus
    {
        Disabled = 0,
        Enabled = 1,
    }
    public partial class RecommendationConfigurationProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RecommendationConfigurationProperties() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.IotSecurityRecommendationType> RecommendationType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.RecommendationConfigStatus> Status { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum RecommendationStatus
    {
        Recommended = 0,
        NotRecommended = 1,
        NotAvailable = 2,
        NoStatus = 3,
    }
    public partial class RemediationEta : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RemediationEta() { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> Eta { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Justification { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ResourceOnboardingState
    {
        NotApplicable = 0,
        OnboardedByOtherConnector = 1,
        Onboarded = 2,
        NotOnboarded = 3,
    }
    public enum RuleCategory
    {
        Code = 0,
        Artifacts = 1,
        Dependencies = 2,
        Secrets = 3,
        IaC = 4,
        Containers = 5,
    }
    public enum SecurityAlertMinimalSeverity
    {
        High = 0,
        Medium = 1,
        Low = 2,
    }
    public enum SecurityAlertNotificationByRoleState
    {
        On = 0,
        Off = 1,
    }
    public enum SecurityAlertNotificationState
    {
        On = 0,
        Off = 1,
    }
    public enum SecurityAlertReceivingRole
    {
        AccountAdmin = 0,
        ServiceAdmin = 1,
        Owner = 2,
        Contributor = 3,
    }
    public partial class SecurityAlertsSuppressionRule : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SecurityAlertsSuppressionRule(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> AlertType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Comment { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ExpireOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastModifiedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Reason { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.SecurityAlertsSuppressionRuleState> State { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SecurityCenter.SuppressionAlertsScopeElement> SuppressionAlertsScopeAllOf { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SecurityCenter.SecurityAlertsSuppressionRule FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
    }
    public enum SecurityAlertsSuppressionRuleState
    {
        Enabled = 0,
        Disabled = 1,
        Expired = 2,
    }
    public partial class SecurityAlertSyncSettings : Azure.Provisioning.SecurityCenter.SecuritySetting
    {
        public SecurityAlertSyncSettings(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(string)) { }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SecurityAssessment : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SecurityAssessment(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepDictionary<string> AdditionalData { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Uri> LinksAzurePortalUri { get { throw null; } }
        public Azure.Provisioning.SecurityCenter.SecurityAssessmentMetadataProperties Metadata { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.SecurityAssessmentPartner PartnersData { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.SecurityCenterResourceDetails ResourceDetails { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.SecurityAssessmentStatus Status { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SecurityCenter.SecurityAssessment FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2021_06_01;
        }
    }
    public partial class SecurityAssessmentMetadataPartner : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SecurityAssessmentMetadataPartner() { }
        public Azure.Provisioning.BicepValue<string> PartnerName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProductName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Secret { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SecurityAssessmentMetadataProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SecurityAssessmentMetadataProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.SecurityAssessmentType> AssessmentType { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SecurityCenter.SecurityAssessmentResourceCategory> Categories { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.ImplementationEffort> ImplementationEffort { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsPreview { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.SecurityAssessmentMetadataPartner PartnerData { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PolicyDefinitionId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> RemediationDescription { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.SecurityAssessmentSeverity> Severity { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SecurityCenter.SecurityThreat> Threats { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.SecurityAssessmentUserImpact> UserImpact { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SecurityAssessmentPartner : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SecurityAssessmentPartner() { }
        public Azure.Provisioning.BicepValue<string> PartnerName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Secret { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SecurityAssessmentPublishDates : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SecurityAssessmentPublishDates() { }
        public Azure.Provisioning.BicepValue<string> GA { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Public { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum SecurityAssessmentResourceCategory
    {
        IoT = 0,
        Compute = 1,
        Networking = 2,
        Data = 3,
        IdentityAndAccess = 4,
    }
    public enum SecurityAssessmentSeverity
    {
        Low = 0,
        Medium = 1,
        High = 2,
    }
    public partial class SecurityAssessmentStatus : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SecurityAssessmentStatus() { }
        public Azure.Provisioning.BicepValue<string> Cause { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.SecurityAssessmentStatusCode> Code { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum SecurityAssessmentStatusCode
    {
        Healthy = 0,
        Unhealthy = 1,
        NotApplicable = 2,
    }
    public partial class SecurityAssessmentStatusResult : Azure.Provisioning.SecurityCenter.SecurityAssessmentStatus
    {
        public SecurityAssessmentStatusResult() { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> FirstEvaluatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> StatusChangeOn { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum SecurityAssessmentTactic
    {
        Reconnaissance = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Resource Development")]
        ResourceDevelopment = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Initial Access")]
        InitialAccess = 2,
        Execution = 3,
        Persistence = 4,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Privilege Escalation")]
        PrivilegeEscalation = 5,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Defense Evasion")]
        DefenseEvasion = 6,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Credential Access")]
        CredentialAccess = 7,
        Discovery = 8,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Lateral Movement")]
        LateralMovement = 9,
        Collection = 10,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Command and Control")]
        CommandAndControl = 11,
        Exfiltration = 12,
        Impact = 13,
    }
    public enum SecurityAssessmentTechnique
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="Abuse Elevation Control Mechanism")]
        AbuseElevationControlMechanism = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Access Token Manipulation")]
        AccessTokenManipulation = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Account Discovery")]
        AccountDiscovery = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Account Manipulation")]
        AccountManipulation = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Active Scanning")]
        ActiveScanning = 4,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Application Layer Protocol")]
        ApplicationLayerProtocol = 5,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Audio Capture")]
        AudioCapture = 6,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Boot or Logon Autostart Execution")]
        BootOrLogonAutostartExecution = 7,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Boot or Logon Initialization Scripts")]
        BootOrLogonInitializationScripts = 8,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Brute Force")]
        BruteForce = 9,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Cloud Infrastructure Discovery")]
        CloudInfrastructureDiscovery = 10,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Cloud Service Dashboard")]
        CloudServiceDashboard = 11,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Cloud Service Discovery")]
        CloudServiceDiscovery = 12,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Command and Scripting Interpreter")]
        CommandAndScriptingInterpreter = 13,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Compromise Client Software Binary")]
        CompromiseClientSoftwareBinary = 14,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Compromise Infrastructure")]
        CompromiseInfrastructure = 15,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Container and Resource Discovery")]
        ContainerAndResourceDiscovery = 16,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Create Account")]
        CreateAccount = 17,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Create or Modify System Process")]
        CreateOrModifySystemProcess = 18,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Credentials from Password Stores")]
        CredentialsFromPasswordStores = 19,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Data Destruction")]
        DataDestruction = 20,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Data Encrypted for Impact")]
        DataEncryptedForImpact = 21,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Data from Cloud Storage Object")]
        DataFromCloudStorageObject = 22,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Data from Configuration Repository")]
        DataFromConfigurationRepository = 23,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Data from Information Repositories")]
        DataFromInformationRepositories = 24,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Data from Local System")]
        DataFromLocalSystem = 25,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Data Manipulation")]
        DataManipulation = 26,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Data Staged")]
        DataStaged = 27,
        Defacement = 28,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Deobfuscate/Decode Files or Information")]
        DeobfuscateDecodeFilesOrInformation = 29,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Disk Wipe")]
        DiskWipe = 30,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Domain Trust Discovery")]
        DomainTrustDiscovery = 31,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Drive-by Compromise")]
        DriveByCompromise = 32,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Dynamic Resolution")]
        DynamicResolution = 33,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Endpoint Denial of Service")]
        EndpointDenialOfService = 34,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Event Triggered Execution")]
        EventTriggeredExecution = 35,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Exfiltration Over Alternative Protocol")]
        ExfiltrationOverAlternativeProtocol = 36,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Exploit Public-Facing Application")]
        ExploitPublicFacingApplication = 37,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Exploitation for Client Execution")]
        ExploitationForClientExecution = 38,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Exploitation for Credential Access")]
        ExploitationForCredentialAccess = 39,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Exploitation for Defense Evasion")]
        ExploitationForDefenseEvasion = 40,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Exploitation for Privilege Escalation")]
        ExploitationForPrivilegeEscalation = 41,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Exploitation of Remote Services")]
        ExploitationOfRemoteServices = 42,
        [System.Runtime.Serialization.DataMemberAttribute(Name="External Remote Services")]
        ExternalRemoteServices = 43,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Fallback Channels")]
        FallbackChannels = 44,
        [System.Runtime.Serialization.DataMemberAttribute(Name="File and Directory Discovery")]
        FileAndDirectoryDiscovery = 45,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Gather Victim Network Information")]
        GatherVictimNetworkInformation = 46,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Hide Artifacts")]
        HideArtifacts = 47,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Hijack Execution Flow")]
        HijackExecutionFlow = 48,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Impair Defenses")]
        ImpairDefenses = 49,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Implant Container Image")]
        ImplantContainerImage = 50,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Indicator Removal on Host")]
        IndicatorRemovalOnHost = 51,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Indirect Command Execution")]
        IndirectCommandExecution = 52,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Ingress Tool Transfer")]
        IngressToolTransfer = 53,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Input Capture")]
        InputCapture = 54,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Inter-Process Communication")]
        InterProcessCommunication = 55,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Lateral Tool Transfer")]
        LateralToolTransfer = 56,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Man-in-the-Middle")]
        ManInTheMiddle = 57,
        Masquerading = 58,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Modify Authentication Process")]
        ModifyAuthenticationProcess = 59,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Modify Registry")]
        ModifyRegistry = 60,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Network Denial of Service")]
        NetworkDenialOfService = 61,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Network Service Scanning")]
        NetworkServiceScanning = 62,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Network Sniffing")]
        NetworkSniffing = 63,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Non-Application Layer Protocol")]
        NonApplicationLayerProtocol = 64,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Non-Standard Port")]
        NonStandardPort = 65,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Obtain Capabilities")]
        ObtainCapabilities = 66,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Obfuscated Files or Information")]
        ObfuscatedFilesOrInformation = 67,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Office Application Startup")]
        OfficeApplicationStartup = 68,
        [System.Runtime.Serialization.DataMemberAttribute(Name="OS Credential Dumping")]
        OSCredentialDumping = 69,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Permission Groups Discovery")]
        PermissionGroupsDiscovery = 70,
        Phishing = 71,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Pre-OS Boot")]
        PreOSBoot = 72,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Process Discovery")]
        ProcessDiscovery = 73,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Process Injection")]
        ProcessInjection = 74,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Protocol Tunneling")]
        ProtocolTunneling = 75,
        Proxy = 76,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Query Registry")]
        QueryRegistry = 77,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Remote Access Software")]
        RemoteAccessSoftware = 78,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Remote Service Session Hijacking")]
        RemoteServiceSessionHijacking = 79,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Remote Services")]
        RemoteServices = 80,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Remote System Discovery")]
        RemoteSystemDiscovery = 81,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Resource Hijacking")]
        ResourceHijacking = 82,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Scheduled Task/Job")]
        ScheduledTaskJob = 83,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Screen Capture")]
        ScreenCapture = 84,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Search Victim-Owned Websites")]
        SearchVictimOwnedWebsites = 85,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Server Software Component")]
        ServerSoftwareComponent = 86,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Service Stop")]
        ServiceStop = 87,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Signed Binary Proxy Execution")]
        SignedBinaryProxyExecution = 88,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Software Deployment Tools")]
        SoftwareDeploymentTools = 89,
        [System.Runtime.Serialization.DataMemberAttribute(Name="SQL Stored Procedures")]
        SQLStoredProcedures = 90,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Steal or Forge Kerberos Tickets")]
        StealOrForgeKerberosTickets = 91,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Subvert Trust Controls")]
        SubvertTrustControls = 92,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Supply Chain Compromise")]
        SupplyChainCompromise = 93,
        [System.Runtime.Serialization.DataMemberAttribute(Name="System Information Discovery")]
        SystemInformationDiscovery = 94,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Taint Shared Content")]
        TaintSharedContent = 95,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Traffic Signaling")]
        TrafficSignaling = 96,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Transfer Data to Cloud Account")]
        TransferDataToCloudAccount = 97,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Trusted Relationship")]
        TrustedRelationship = 98,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Unsecured Credentials")]
        UnsecuredCredentials = 99,
        [System.Runtime.Serialization.DataMemberAttribute(Name="User Execution")]
        UserExecution = 100,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Valid Accounts")]
        ValidAccounts = 101,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Windows Management Instrumentation")]
        WindowsManagementInstrumentation = 102,
        [System.Runtime.Serialization.DataMemberAttribute(Name="File and Directory Permissions Modification")]
        FileAndDirectoryPermissionsModification = 103,
    }
    public enum SecurityAssessmentType
    {
        BuiltIn = 0,
        CustomPolicy = 1,
        CustomerManaged = 2,
        VerifiedPartner = 3,
    }
    public enum SecurityAssessmentUserImpact
    {
        Low = 0,
        Moderate = 1,
        High = 2,
    }
    public partial class SecurityAutomation : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SecurityAutomation(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SecurityCenter.SecurityAutomationAction> Actions { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SecurityCenter.SecurityAutomationScope> Scopes { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SecurityCenter.SecurityAutomationSource> Sources { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SecurityCenter.SecurityAutomation FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
    }
    public partial class SecurityAutomationAction : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SecurityAutomationAction() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SecurityAutomationActionEventHub : Azure.Provisioning.SecurityCenter.SecurityAutomationAction
    {
        public SecurityAutomationActionEventHub() { }
        public Azure.Provisioning.BicepValue<string> ConnectionString { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> EventHubResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SasPolicyName { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SecurityAutomationActionLogicApp : Azure.Provisioning.SecurityCenter.SecurityAutomationAction
    {
        public SecurityAutomationActionLogicApp() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> LogicAppResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> Uri { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SecurityAutomationActionWorkspace : Azure.Provisioning.SecurityCenter.SecurityAutomationAction
    {
        public SecurityAutomationActionWorkspace() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> WorkspaceResourceId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SecurityAutomationRuleSet : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SecurityAutomationRuleSet() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SecurityCenter.SecurityAutomationTriggeringRule> Rules { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SecurityAutomationScope : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SecurityAutomationScope() { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ScopePath { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SecurityAutomationSource : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SecurityAutomationSource() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.SecurityEventSource> EventSource { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SecurityCenter.SecurityAutomationRuleSet> RuleSets { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SecurityAutomationTriggeringRule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SecurityAutomationTriggeringRule() { }
        public Azure.Provisioning.BicepValue<string> ExpectedValue { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.AutomationTriggeringRuleOperator> Operator { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PropertyJPath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.AutomationTriggeringRulePropertyType> PropertyType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SecurityCenterApiCollection : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SecurityCenterApiCollection(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<System.Uri> BaseUri { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> DiscoveredVia { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> NumberOfApiEndpoints { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> NumberOfApiEndpointsWithSensitiveDataExposed { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> NumberOfExternalApiEndpoints { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> NumberOfInactiveApiEndpoints { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> NumberOfUnauthenticatedApiEndpoints { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.SecurityFamilyProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SensitivityLabel { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SecurityCenter.SecurityCenterApiCollection FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2023_11_15;
        }
    }
    public enum SecurityCenterCloudName
    {
        Azure = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="AWS")]
        Aws = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="GCP")]
        Gcp = 2,
        Github = 3,
        AzureDevOps = 4,
        GitLab = 5,
    }
    public partial class SecurityCenterCloudOffering : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SecurityCenterCloudOffering() { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum SecurityCenterCloudPermission
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="AWS::AWSSecurityHubReadOnlyAccess")]
        AwsAwsSecurityHubReadOnlyAccess = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="AWS::SecurityAudit")]
        AwsSecurityAudit = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="AWS::AmazonSSMAutomationRole")]
        AwsAmazonSsmAutomationRole = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="GCP::Security Center Admin Viewer")]
        GcpSecurityCenterAdminViewer = 3,
    }
    public enum SecurityCenterConfigurationStatus
    {
        Configured = 0,
        NotConfigured = 1,
        InProgress = 2,
        Failed = 3,
        NoStatus = 4,
    }
    public partial class SecurityCenterFileProtectionMode : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SecurityCenterFileProtectionMode() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.AdaptiveApplicationControlEnforcementMode> Exe { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.AdaptiveApplicationControlEnforcementMode> Executable { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.AdaptiveApplicationControlEnforcementMode> Msi { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.AdaptiveApplicationControlEnforcementMode> Script { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SecurityCenterPricing : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SecurityCenterPricing(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> EnabledOn { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SecurityCenter.PlanExtension> Extensions { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> FreeTrialRemainingTime { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsDeprecated { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.SecurityCenterPricingTier> PricingTier { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> ReplacedBy { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SubPlan { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SecurityCenter.SecurityCenterPricing FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2023_01_01;
        }
    }
    public enum SecurityCenterPricingTier
    {
        Free = 0,
        Standard = 1,
    }
    public partial class SecurityCenterPublisherInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SecurityCenterPublisherInfo() { }
        public Azure.Provisioning.BicepValue<string> BinaryName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProductName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PublisherName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Version { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SecurityCenterResourceDetails : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SecurityCenterResourceDetails() { }
        protected override void DefineProvisionableProperties() { }
    }
    public enum SecurityCenterVmEnforcementSupportState
    {
        Supported = 0,
        NotSupported = 1,
        Unknown = 2,
    }
    public partial class SecurityCloudConnector : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SecurityCloudConnector(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.SecurityCenter.AuthenticationDetailsProperties AuthenticationDetails { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.HybridComputeSettingsProperties HybridComputeSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SecurityCenter.SecurityCloudConnector FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
    }
    public partial class SecurityConnector : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SecurityConnector(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.SecurityCenter.SecurityConnectorEnvironment EnvironmentData { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.SecurityCenterCloudName> EnvironmentName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> HierarchyIdentifier { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> HierarchyIdentifierTrialEndOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SecurityCenter.SecurityCenterCloudOffering> Offerings { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SecurityCenter.SecurityConnector FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
    }
    public partial class SecurityConnectorApplication : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SecurityConnectorApplication(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<System.BinaryData> ConditionSets { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.ApplicationSourceResourceType> SourceResourceType { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SecurityCenter.SecurityConnectorApplication FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
    }
    public partial class SecurityConnectorEnvironment : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SecurityConnectorEnvironment() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SecurityConnectorGovernanceRule : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SecurityConnectorGovernanceRule(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<System.BinaryData> ConditionSets { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> ExcludedScopes { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.GovernanceRuleEmailNotification GovernanceEmailNotification { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IncludeMemberScopes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsDisabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsGracePeriod { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.GovernanceRuleMetadata Metadata { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.SecurityCenter.GovernanceRuleOwnerSource OwnerSource { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RemediationTimeframe { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> RulePriority { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.GovernanceRuleType> RuleType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.GovernanceRuleSourceResourceType> SourceResourceType { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> TenantId { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SecurityCenter.SecurityConnectorGovernanceRule FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
    }
    public partial class SecurityContact : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SecurityContact(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.SecurityCenter.SecurityContactPropertiesAlertNotifications AlertNotifications { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Emails { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.SecurityContactPropertiesNotificationsByRole NotificationsByRole { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Phone { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SecurityCenter.SecurityContact FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
    }
    public partial class SecurityContactPropertiesAlertNotifications : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SecurityContactPropertiesAlertNotifications() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.SecurityAlertMinimalSeverity> MinimalSeverity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.SecurityAlertNotificationState> State { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SecurityContactPropertiesNotificationsByRole : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SecurityContactPropertiesNotificationsByRole() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SecurityCenter.SecurityAlertReceivingRole> Roles { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.SecurityAlertNotificationByRoleState> State { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum SecurityEventSource
    {
        Assessments = 0,
        AssessmentsSnapshot = 1,
        SubAssessments = 2,
        SubAssessmentsSnapshot = 3,
        Alerts = 4,
        SecureScores = 5,
        SecureScoresSnapshot = 6,
        SecureScoreControls = 7,
        SecureScoreControlsSnapshot = 8,
        RegulatoryComplianceAssessment = 9,
        RegulatoryComplianceAssessmentSnapshot = 10,
    }
    public enum SecurityFamilyProvisioningState
    {
        Succeeded = 0,
        Failed = 1,
        Updating = 2,
    }
    public partial class SecurityOperator : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SecurityOperator(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.SecurityCenterPricing? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SecurityCenter.SecurityOperator FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
    }
    public partial class SecuritySetting : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SecuritySetting(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SecurityCenter.SecuritySetting FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2022_05_01;
        }
    }
    public enum SecuritySolutionStatus
    {
        Enabled = 0,
        Disabled = 1,
    }
    public enum SecurityThreat
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="accountBreach")]
        AccountBreach = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="dataExfiltration")]
        DataExfiltration = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="dataSpillage")]
        DataSpillage = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="maliciousInsider")]
        MaliciousInsider = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="elevationOfPrivilege")]
        ElevationOfPrivilege = 4,
        [System.Runtime.Serialization.DataMemberAttribute(Name="threatResistance")]
        ThreatResistance = 5,
        [System.Runtime.Serialization.DataMemberAttribute(Name="missingCoverage")]
        MissingCoverage = 6,
        [System.Runtime.Serialization.DataMemberAttribute(Name="denialOfService")]
        DenialOfService = 7,
    }
    public enum SecurityValueType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="IpCidr")]
        IPCidr = 0,
        String = 1,
    }
    public partial class SecurityWorkspaceSetting : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SecurityWorkspaceSetting(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Scope { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> WorkspaceId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SecurityCenter.SecurityWorkspaceSetting FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
    }
    public partial class SensitivitySetting : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SensitivitySetting(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.SecurityCenter.SensitivitySettingsProperties Properties { get { throw null; } }
        public Azure.Provisioning.BicepList<System.Guid> SensitiveInfoTypesIds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> SensitivityThresholdLabelId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<float> SensitivityThresholdLabelOrder { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SecurityCenter.SensitivitySetting FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
    }
    public partial class SensitivitySettingsProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SensitivitySettingsProperties() { }
        public Azure.Provisioning.SecurityCenter.GetSensitivitySettingsResponsePropertiesMipInformation MipInformation { get { throw null; } }
        public Azure.Provisioning.BicepList<System.Guid> SensitiveInfoTypesIds { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> SensitivityThresholdLabelId { get { throw null; } }
        public Azure.Provisioning.BicepValue<float> SensitivityThresholdLabelOrder { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ServerVulnerabilityAssessment : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ServerVulnerabilityAssessment(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.ServerVulnerabilityAssessmentPropertiesProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SecurityCenter.ServerVulnerabilityAssessment FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2020_01_01;
        }
    }
    public enum ServerVulnerabilityAssessmentPropertiesProvisioningState
    {
        Succeeded = 0,
        Failed = 1,
        Canceled = 2,
        Provisioning = 3,
        Deprovisioning = 4,
    }
    public enum ServerVulnerabilityAssessmentsAzureSettingSelectedProvider
    {
        MdeTvm = 0,
    }
    public partial class ServerVulnerabilityAssessmentsSetting : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ServerVulnerabilityAssessmentsSetting(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SecurityCenter.ServerVulnerabilityAssessmentsSetting FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2023_05_01;
        }
    }
    public partial class ServicePrincipalProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ServicePrincipalProperties() { }
        public Azure.Provisioning.BicepValue<System.Guid> ApplicationId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Secret { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SqlVulnerabilityAssessmentBaselineRule : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SqlVulnerabilityAssessmentBaselineRule(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> LatestScan { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.BicepList<string>> Results { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.BicepList<string>> RuleResults { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SecurityCenter.SqlVulnerabilityAssessmentBaselineRule FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
    }
    public partial class SubscriptionAssessmentMetadata : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SubscriptionAssessmentMetadata(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.SecurityAssessmentType> AssessmentType { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SecurityCenter.SecurityAssessmentResourceCategory> Categories { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.ImplementationEffort> ImplementationEffort { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsPreview { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.SecurityAssessmentMetadataPartner PartnerData { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PlannedDeprecationDate { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PolicyDefinitionId { get { throw null; } }
        public Azure.Provisioning.SecurityCenter.SecurityAssessmentPublishDates PublishDates { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RemediationDescription { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.SecurityAssessmentSeverity> Severity { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SecurityCenter.SecurityAssessmentTactic> Tactics { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SecurityCenter.SecurityAssessmentTechnique> Techniques { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SecurityCenter.SecurityThreat> Threats { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.SecurityAssessmentUserImpact> UserImpact { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SecurityCenter.SubscriptionAssessmentMetadata FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2021_06_01;
        }
    }
    public partial class SubscriptionGovernanceRule : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SubscriptionGovernanceRule(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<System.BinaryData> ConditionSets { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> ExcludedScopes { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.GovernanceRuleEmailNotification GovernanceEmailNotification { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IncludeMemberScopes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsDisabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsGracePeriod { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.GovernanceRuleMetadata Metadata { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.SecurityCenter.GovernanceRuleOwnerSource OwnerSource { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RemediationTimeframe { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> RulePriority { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.GovernanceRuleType> RuleType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.GovernanceRuleSourceResourceType> SourceResourceType { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> TenantId { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SecurityCenter.SubscriptionGovernanceRule FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
    }
    public partial class SubscriptionSecurityApplication : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SubscriptionSecurityApplication(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<System.BinaryData> ConditionSets { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.ApplicationSourceResourceType> SourceResourceType { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SecurityCenter.SubscriptionSecurityApplication FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
    }
    public partial class SuppressionAlertsScopeElement : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SuppressionAlertsScopeElement() { }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> AdditionalProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Field { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class TargetBranchConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public TargetBranchConfiguration() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.AnnotateDefaultBranchState> AnnotateDefaultBranch { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> BranchNames { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ThresholdCustomAlertRule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ThresholdCustomAlertRule() { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxThreshold { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MinThreshold { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class TimeWindowCustomAlertRule : Azure.Provisioning.SecurityCenter.ThresholdCustomAlertRule
    {
        public TimeWindowCustomAlertRule() { }
        public Azure.Provisioning.BicepValue<System.TimeSpan> TimeWindowSize { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class TwinUpdatesNotInAllowedRange : Azure.Provisioning.SecurityCenter.TimeWindowCustomAlertRule
    {
        public TwinUpdatesNotInAllowedRange() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class UnauthorizedOperationsNotInAllowedRange : Azure.Provisioning.SecurityCenter.TimeWindowCustomAlertRule
    {
        public UnauthorizedOperationsNotInAllowedRange() { }
        protected override void DefineProvisionableProperties() { }
    }
    public enum UnmaskedIPLoggingStatus
    {
        Disabled = 0,
        Enabled = 1,
    }
    public partial class UserDefinedInformationType : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public UserDefinedInformationType() { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class UserDefinedResourcesProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public UserDefinedResourcesProperties() { }
        public Azure.Provisioning.BicepValue<string> Query { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> QuerySubscriptions { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class UserRecommendation : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public UserRecommendation() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.RecommendationAction> RecommendationAction { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Username { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VmRecommendation : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VmRecommendation() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.SecurityCenterConfigurationStatus> ConfigurationStatus { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.SecurityCenterVmEnforcementSupportState> EnforcementSupport { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.RecommendationAction> RecommendationAction { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ResourceId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum VulnerabilityAssessmentAutoProvisioningType
    {
        Qualys = 0,
        TVM = 1,
    }
}
