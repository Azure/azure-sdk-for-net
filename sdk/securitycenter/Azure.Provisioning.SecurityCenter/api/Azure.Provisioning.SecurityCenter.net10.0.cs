namespace Azure.Provisioning.SecurityCenter
{
    public partial class AccessTokenAuthentication : Azure.Provisioning.SecurityCenter.SecurityConnectorAuthentication
    {
        public AccessTokenAuthentication() { }
        public Azure.Provisioning.BicepValue<string> AccessToken { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Username { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
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
    public enum AdditionalWorkspaceDataType
    {
        Alerts = 0,
        RawEvents = 1,
    }
    public partial class AdditionalWorkspacesProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AdditionalWorkspacesProperties() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SecurityCenter.AdditionalWorkspaceDataType> DataTypes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.AdditionalWorkspaceType> Type { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Workspace { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum AdditionalWorkspaceType
    {
        Sentinel = 0,
    }
    public partial class AdvancedThreatProtectionSetting : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public AdvancedThreatProtectionSetting(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.Primitives.ProvisionableResource Scope { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SecurityCenter.AdvancedThreatProtectionSetting FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2019_01_01;
        }
    }
    public partial class AgentlessConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AgentlessConfiguration() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.AutoDiscovery> AgentlessAutoDiscovery { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.AgentlessEnablement> AgentlessEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SecurityCenter.InventoryList> InventoryList { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.IotSecurityInventoryListKind> InventoryListType { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Scanners { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum AgentlessEnablement
    {
        Disabled = 0,
        Enabled = 1,
        NotApplicable = 2,
    }
    public partial class AlertSyncSettings : Azure.Provisioning.SecurityCenter.SecuritySetting
    {
        public AlertSyncSettings(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(string)) { }
        public Azure.Provisioning.BicepValue<bool> Enabled { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AllowlistCustomAlertRule : Azure.Provisioning.SecurityCenter.ListCustomAlertRule
    {
        public AllowlistCustomAlertRule() { }
        public Azure.Provisioning.BicepList<string> AllowlistValues { get { throw null; } set { } }
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
    public partial class ApiCollection : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ApiCollection(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<System.Uri> BaseUri { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> DiscoveredVia { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> NumberOfApiEndpoints { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> NumberOfApiEndpointsWithSensitiveDataExposed { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> NumberOfExternalApiEndpoints { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> NumberOfInactiveApiEndpoints { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> NumberOfUnauthenticatedApiEndpoints { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.SecurityCenterProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Primitives.ProvisionableResource Scope { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SensitivityLabel { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SecurityCenter.ApiCollection FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2023_11_15;
        }
    }
    public enum ApplicationSourceResourceType
    {
        Assessments = 0,
    }
    public partial class ArcAutoProvisioning : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ArcAutoProvisioning() { }
        public Azure.Provisioning.SecurityCenter.DefenderForDatabasesAwsOfferingArcAutoProvisioningConfiguration Configuration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> Enabled { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ArcAutoProvisioningAws : Azure.Provisioning.SecurityCenter.ArcAutoProvisioning
    {
        public ArcAutoProvisioningAws() { }
        public Azure.Provisioning.BicepValue<string> CloudRoleArn { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ArcAutoProvisioningGcp : Azure.Provisioning.SecurityCenter.ArcAutoProvisioning
    {
        public ArcAutoProvisioningGcp() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AttestationEvidence : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AttestationEvidence() { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SourceUri { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum AutoDiscovery
    {
        Disabled = 0,
        Enabled = 1,
        NotApplicable = 2,
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
        public AutoProvisioningSetting(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.AutoProvisionState> AutoProvision { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SecurityCenter.AutoProvisioningSetting FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2017_08_01_PREVIEW;
        }
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
    public partial class AwsCloudTrailConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AwsCloudTrailConfiguration() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SecurityCenter.AwsCloudTrailResourceSet> CloudTrailResourceSets { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DeploymentRegion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.AwsCloudTrailProvisioningType> ProvisioningType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ResourceNamePrefix { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum AwsCloudTrailProvisioningType
    {
        BringYourOwn = 0,
        ManualProvisioning = 1,
        AutoProvisioning = 2,
    }
    public partial class AwsCloudTrailResourceSet : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AwsCloudTrailResourceSet() { }
        public Azure.Provisioning.BicepValue<string> KmsKeyArn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ResourceRegion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> S3BucketArn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SqsQueueArn { get { throw null; } set { } }
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
    public partial class AzureDevOpsOrg : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public AzureDevOpsOrg(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.DevOpsConfiguration Parent { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.AzureDevOpsOrgProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SecurityCenter.AzureDevOpsOrg FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2025_11_01_PREVIEW;
        }
    }
    public partial class AzureDevOpsOrgProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AzureDevOpsOrgProperties() { }
        public Azure.Provisioning.SecurityCenter.ActionableRemediation ActionableRemediation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.OnboardingState> OnboardingState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.DevOpsProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ProvisioningStatusMessage { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ProvisioningStatusUpdatedOn { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AzureDevOpsProject : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public AzureDevOpsProject(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.AzureDevOpsOrg Parent { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.AzureDevOpsProjectProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SecurityCenter.AzureDevOpsProject FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2025_11_01_PREVIEW;
        }
    }
    public partial class AzureDevOpsProjectProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AzureDevOpsProjectProperties() { }
        public Azure.Provisioning.SecurityCenter.ActionableRemediation ActionableRemediation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.OnboardingState> OnboardingState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ParentOrgName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProjectId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.DevOpsProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ProvisioningStatusMessage { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ProvisioningStatusUpdatedOn { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AzureDevOpsRepository : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public AzureDevOpsRepository(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.AzureDevOpsProject Parent { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.AzureDevOpsRepositoryProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SecurityCenter.AzureDevOpsRepository FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2025_11_01_PREVIEW;
        }
    }
    public partial class AzureDevOpsRepositoryProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AzureDevOpsRepositoryProperties() { }
        public Azure.Provisioning.SecurityCenter.ActionableRemediation ActionableRemediation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.OnboardingState> OnboardingState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ParentOrgName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ParentProjectName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.DevOpsProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ProvisioningStatusMessage { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ProvisioningStatusUpdatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> RepoId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> RepoUri { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Visibility { get { throw null; } }
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
    public partial class AzureResourceIdentifier : Azure.Provisioning.SecurityCenter.SecurityAlertResourceIdentifier
    {
        public AzureResourceIdentifier() { }
        public Azure.Provisioning.BicepValue<string> AzureResourceId { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AzureServersSetting : Azure.Provisioning.SecurityCenter.ServerVulnerabilityAssessmentsSetting
    {
        public AzureServersSetting(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.ServerVulnerabilityAssessmentsAzureSettingSelectedProvider> SelectedProvider { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BaselineAdjustedResult : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BaselineAdjustedResult() { }
        public Azure.Provisioning.SecurityCenter.SqlVulnerabilityAssessmentBaseline Baseline { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.BicepList<string>> ResultsNotInBaseline { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.BicepList<string>> ResultsOnlyInBaseline { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.SqlVulnerabilityAssessmentScanResultRuleStatus> Status { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BenchmarkReference : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BenchmarkReference() { }
        public Azure.Provisioning.BicepValue<string> Benchmark { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Reference { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum BlobScanResultsConfig
    {
        BlobIndexTags = 0,
        None = 1,
    }
    public partial class BuiltInInfoType : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BuiltInInfoType() { }
        public Azure.Provisioning.BicepValue<string> Dns { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CategoryConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CategoryConfiguration() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.RuleCategory> Category { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MinimumSeverityLevel { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ComplianceResult : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal ComplianceResult() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.SecurityAssessmentResourceStatus> ResourceStatus { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SecurityCenter.ComplianceResult FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2017_08_01;
        }
    }
    public partial class ComplianceSegment : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ComplianceSegment() { }
        public Azure.Provisioning.BicepValue<double> Percentage { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SegmentType { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ConnectableResourceInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ConnectableResourceInfo() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SecurityCenter.ConnectedResourceInfo> InboundConnectedResources { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SecurityCenter.ConnectedResourceInfo> OutboundConnectedResources { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ConnectedResourceInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ConnectedResourceInfo() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ConnectedResourceId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> TcpPorts { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> UdpPorts { get { throw null; } }
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
    public partial class ContainerRegistryVulnerabilityProperties : Azure.Provisioning.SecurityCenter.SecuritySubAssessmentAdditionalInfo
    {
        public ContainerRegistryVulnerabilityProperties() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SecurityCenter.SecurityCve> Cve { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.SecurityCenter.SecurityCvss> Cvss { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ImageDigest { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsPatchable { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> PublishedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> RepositoryName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Type { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SecurityCenter.VendorReference> VendorReferences { get { throw null; } }
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
    public partial class CspmMonitorDockerHubOffering : Azure.Provisioning.SecurityCenter.SecurityCenterCloudOffering
    {
        public CspmMonitorDockerHubOffering() { }
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
    public partial class CspmMonitorJFrogOffering : Azure.Provisioning.SecurityCenter.SecurityCenterCloudOffering
    {
        public CspmMonitorJFrogOffering() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CustomAlertRule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CustomAlertRule() { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CustomRecommendation : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public CustomRecommendation(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> AssessmentKey { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SecurityCenter.RecommendationSupportedClouds> CloudProviders { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Query { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RemediationDescription { get { throw null; } set { } }
        public Azure.Provisioning.Primitives.ProvisionableResource Scope { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.CustomRecommendationSecurityIssue> SecurityIssue { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.CustomRecommendationSeverity> Severity { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SecurityCenter.CustomRecommendation FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_08_01;
        }
    }
    public enum CustomRecommendationSecurityIssue
    {
        Vulnerability = 0,
        ExcessivePermissions = 1,
        AnonymousAccess = 2,
        NetworkExposure = 3,
        TrafficEncryption = 4,
        BestPractices = 5,
    }
    public enum CustomRecommendationSeverity
    {
        High = 0,
        Medium = 1,
        Low = 2,
    }
    public partial class DataExportSettings : Azure.Provisioning.SecurityCenter.SecuritySetting
    {
        public DataExportSettings(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(string)) { }
        public Azure.Provisioning.BicepValue<bool> Enabled { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DefenderCspmAwsOffering : Azure.Provisioning.SecurityCenter.SecurityCenterCloudOffering
    {
        public DefenderCspmAwsOffering() { }
        public Azure.Provisioning.SecurityCenter.DefenderCspmAwsOfferingAgentlessServerlessPosture AgentlessServerlessPosture { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.DefenderCspmAwsOfferingCiem Ciem { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.DefenderCspmAwsOfferingDatabasesDspm DatabasesDspm { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.DefenderCspmAwsOfferingDataSensitivityDiscovery DataSensitivityDiscovery { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.DefenderCspmAwsOfferingMdcContainersAgentlessDiscoveryK8S MdcContainersAgentlessDiscoveryK8S { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.DefenderCspmAwsOfferingMdcContainersImageAssessment MdcContainersImageAssessment { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> ServerlessContainersEnabled { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.DefenderCspmAwsOfferingVmScanners VmScanners { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DefenderCspmAwsOfferingAgentlessServerlessPosture : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DefenderCspmAwsOfferingAgentlessServerlessPosture() { }
        public Azure.Provisioning.BicepValue<string> CloudRoleArn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> Enabled { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DefenderCspmAwsOfferingCiem : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DefenderCspmAwsOfferingCiem() { }
        public Azure.Provisioning.SecurityCenter.DefenderCspmAwsOfferingCiemCiemOidc CiemOidc { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.AwsCloudTrailConfiguration CloudTrailAuditLogIngestion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> LogCollectionOidcCloudRoleArn { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DefenderCspmAwsOfferingCiemCiemOidc : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DefenderCspmAwsOfferingCiemCiemOidc() { }
        public Azure.Provisioning.BicepValue<string> AzureActiveDirectoryAppName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CloudRoleArn { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DefenderCspmAwsOfferingDatabasesDspm : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DefenderCspmAwsOfferingDatabasesDspm() { }
        public Azure.Provisioning.BicepValue<string> CloudRoleArn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> Enabled { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DefenderCspmAwsOfferingDataSensitivityDiscovery : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DefenderCspmAwsOfferingDataSensitivityDiscovery() { }
        public Azure.Provisioning.BicepValue<string> CloudRoleArn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> Enabled { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DefenderCspmAwsOfferingMdcContainersAgentlessDiscoveryK8S : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DefenderCspmAwsOfferingMdcContainersAgentlessDiscoveryK8S() { }
        public Azure.Provisioning.BicepValue<string> CloudRoleArn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> Enabled { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DefenderCspmAwsOfferingMdcContainersImageAssessment : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DefenderCspmAwsOfferingMdcContainersImageAssessment() { }
        public Azure.Provisioning.BicepValue<string> CloudRoleArn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> Enabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> SecurityFindingsEnabled { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DefenderCspmAwsOfferingVmScanners : Azure.Provisioning.SecurityCenter.VmScannersAws
    {
        public DefenderCspmAwsOfferingVmScanners() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DefenderCspmDockerHubOffering : Azure.Provisioning.SecurityCenter.SecurityCenterCloudOffering
    {
        public DefenderCspmDockerHubOffering() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DefenderCspmGcpOffering : Azure.Provisioning.SecurityCenter.SecurityCenterCloudOffering
    {
        public DefenderCspmGcpOffering() { }
        public Azure.Provisioning.SecurityCenter.DefenderCspmGcpOfferingCiem Ciem { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.DefenderCspmGcpOfferingCiemDiscovery CiemDiscovery { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.DefenderCspmGcpOfferingDataSensitivityDiscovery DataSensitivityDiscovery { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.DefenderCspmGcpOfferingMdcContainersAgentlessDiscoveryK8S MdcContainersAgentlessDiscoveryK8S { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.DefenderCspmGcpOfferingMdcContainersImageAssessment MdcContainersImageAssessment { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.DefenderCspmGcpOfferingVmScanners VmScanners { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DefenderCspmGcpOfferingCiem : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DefenderCspmGcpOfferingCiem() { }
        public Azure.Provisioning.SecurityCenter.DefenderCspmGcpOfferingCiemOidc CiemOidc { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.GcpAuditLogConfiguration GcpAuditLogIngestion { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.DefenderCspmGcpOfferingCiemOidc LogCollectionOidc { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DefenderCspmGcpOfferingCiemDiscovery : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DefenderCspmGcpOfferingCiemDiscovery() { }
        public Azure.Provisioning.BicepValue<string> AzureActiveDirectoryAppName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableAuditLogIngestion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServiceAccountEmailAddress { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WorkloadIdentityProviderId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DefenderCspmGcpOfferingCiemOidc : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DefenderCspmGcpOfferingCiemOidc() { }
        public Azure.Provisioning.BicepValue<string> ServiceAccountEmailAddress { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WorkloadIdentityProviderId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DefenderCspmGcpOfferingDataSensitivityDiscovery : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DefenderCspmGcpOfferingDataSensitivityDiscovery() { }
        public Azure.Provisioning.BicepValue<bool> Enabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServiceAccountEmailAddress { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WorkloadIdentityProviderId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DefenderCspmGcpOfferingMdcContainersAgentlessDiscoveryK8S : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DefenderCspmGcpOfferingMdcContainersAgentlessDiscoveryK8S() { }
        public Azure.Provisioning.BicepValue<bool> Enabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServiceAccountEmailAddress { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WorkloadIdentityProviderId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DefenderCspmGcpOfferingMdcContainersImageAssessment : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DefenderCspmGcpOfferingMdcContainersImageAssessment() { }
        public Azure.Provisioning.BicepValue<bool> Enabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> SecurityFindingsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServiceAccountEmailAddress { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WorkloadIdentityProviderId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DefenderCspmGcpOfferingVmScanners : Azure.Provisioning.SecurityCenter.VmScannersGcp
    {
        public DefenderCspmGcpOfferingVmScanners() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DefenderCspmJFrogOffering : Azure.Provisioning.SecurityCenter.SecurityCenterCloudOffering
    {
        public DefenderCspmJFrogOffering() { }
        public Azure.Provisioning.BicepValue<bool> IsMdcContainersImageAssessmentEnabled { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DefenderForContainersAwsOffering : Azure.Provisioning.SecurityCenter.SecurityCenterCloudOffering
    {
        public DefenderForContainersAwsOffering() { }
        public Azure.Provisioning.BicepValue<string> CloudRoleArn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> ContainerAntiMalwareEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DataCollectionExternalId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableAuditLogsAutoProvisioning { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableDefenderAgentAutoProvisioning { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnablePolicyAgentAutoProvisioning { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.InstallationMethod> InstallationMethod { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> KinesisToS3CloudRoleArn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> KubeAuditRetentionTime { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> KubernetesDataCollectionCloudRoleArn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> KubernetesServiceCloudRoleArn { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.DefenderForContainersAwsOfferingMdcContainersAgentlessDiscoveryK8S MdcContainersAgentlessDiscoveryK8S { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.DefenderForContainersAwsOfferingMdcContainersImageAssessment MdcContainersImageAssessment { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> SecurityGatingEnabled { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.DefenderForContainersAwsOfferingVmScanners VmScanners { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DefenderForContainersAwsOfferingMdcContainersAgentlessDiscoveryK8S : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DefenderForContainersAwsOfferingMdcContainersAgentlessDiscoveryK8S() { }
        public Azure.Provisioning.BicepValue<string> CloudRoleArn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> Enabled { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DefenderForContainersAwsOfferingMdcContainersImageAssessment : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DefenderForContainersAwsOfferingMdcContainersImageAssessment() { }
        public Azure.Provisioning.BicepValue<string> CloudRoleArn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> Enabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> SecurityFindingsEnabled { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DefenderForContainersAwsOfferingVmScanners : Azure.Provisioning.SecurityCenter.VmScannersAws
    {
        public DefenderForContainersAwsOfferingVmScanners() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DefenderForContainersDockerHubOffering : Azure.Provisioning.SecurityCenter.SecurityCenterCloudOffering
    {
        public DefenderForContainersDockerHubOffering() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DefenderForContainersGcpOffering : Azure.Provisioning.SecurityCenter.SecurityCenterCloudOffering
    {
        public DefenderForContainersGcpOffering() { }
        public Azure.Provisioning.BicepValue<bool> ContainerAntiMalwareEnabled { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.DefenderForContainersGcpOfferingDataPipelineNativeCloudConnection DataPipelineNativeCloudConnection { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableAuditLogsAutoProvisioning { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableDefenderAgentAutoProvisioning { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnablePolicyAgentAutoProvisioning { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.InstallationMethod> InstallationMethod { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.DefenderForContainersGcpOfferingMdcContainersAgentlessDiscoveryK8S MdcContainersAgentlessDiscoveryK8S { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.DefenderForContainersGcpOfferingMdcContainersImageAssessment MdcContainersImageAssessment { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.DefenderForContainersGcpOfferingNativeCloudConnection NativeCloudConnection { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> SecurityGatingEnabled { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.DefenderForContainersGcpOfferingVmScanners VmScanners { get { throw null; } set { } }
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
        public Azure.Provisioning.BicepValue<bool> Enabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServiceAccountEmailAddress { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WorkloadIdentityProviderId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DefenderForContainersGcpOfferingMdcContainersImageAssessment : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DefenderForContainersGcpOfferingMdcContainersImageAssessment() { }
        public Azure.Provisioning.BicepValue<bool> Enabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> SecurityFindingsEnabled { get { throw null; } set { } }
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
    public partial class DefenderForContainersGcpOfferingVmScanners : Azure.Provisioning.SecurityCenter.VmScannersGcp
    {
        public DefenderForContainersGcpOfferingVmScanners() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DefenderForContainersJFrogOffering : Azure.Provisioning.SecurityCenter.SecurityCenterCloudOffering
    {
        public DefenderForContainersJFrogOffering() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DefenderForDatabasesAwsOffering : Azure.Provisioning.SecurityCenter.SecurityCenterCloudOffering
    {
        public DefenderForDatabasesAwsOffering() { }
        public Azure.Provisioning.SecurityCenter.DefenderForDatabasesAwsOfferingArcAutoProvisioning ArcAutoProvisioning { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.DefenderForDatabasesAwsOfferingDatabasesDspm DatabasesDspm { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.DefenderForDatabasesAwsOfferingRds Rds { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DefenderForDatabasesAwsOfferingArcAutoProvisioning : Azure.Provisioning.SecurityCenter.ArcAutoProvisioningAws
    {
        public DefenderForDatabasesAwsOfferingArcAutoProvisioning() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DefenderForDatabasesAwsOfferingArcAutoProvisioningConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DefenderForDatabasesAwsOfferingArcAutoProvisioningConfiguration() { }
        public Azure.Provisioning.BicepValue<string> PrivateLinkScope { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Proxy { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DefenderForDatabasesAwsOfferingDatabasesDspm : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DefenderForDatabasesAwsOfferingDatabasesDspm() { }
        public Azure.Provisioning.BicepValue<string> CloudRoleArn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> Enabled { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DefenderForDatabasesAwsOfferingRds : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DefenderForDatabasesAwsOfferingRds() { }
        public Azure.Provisioning.BicepValue<string> CloudRoleArn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> Enabled { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DefenderForDatabasesGcpOffering : Azure.Provisioning.SecurityCenter.SecurityCenterCloudOffering
    {
        public DefenderForDatabasesGcpOffering() { }
        public Azure.Provisioning.SecurityCenter.DefenderForDatabasesGcpOfferingArcAutoProvisioning ArcAutoProvisioning { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.GcpDefenderForDatabasesArcAutoProvisioning DefenderForDatabasesArcAutoProvisioning { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DefenderForDatabasesGcpOfferingArcAutoProvisioning : Azure.Provisioning.SecurityCenter.ArcAutoProvisioningGcp
    {
        public DefenderForDatabasesGcpOfferingArcAutoProvisioning() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DefenderForServersAwsOffering : Azure.Provisioning.SecurityCenter.SecurityCenterCloudOffering
    {
        public DefenderForServersAwsOffering() { }
        public Azure.Provisioning.SecurityCenter.DefenderForServersAwsOfferingArcAutoProvisioning ArcAutoProvisioning { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DefenderForServersCloudRoleArn { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.DefenderForServersAwsOfferingMdeAutoProvisioning MdeAutoProvisioning { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.AvailableSubPlanType> SubPlanType { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.DefenderForServersAwsOfferingVulnerabilityAssessmentAutoProvisioning VaAutoProvisioning { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.DefenderForServersAwsOfferingVmScanners VmScanners { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DefenderForServersAwsOfferingArcAutoProvisioning : Azure.Provisioning.SecurityCenter.ArcAutoProvisioningAws
    {
        public DefenderForServersAwsOfferingArcAutoProvisioning() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DefenderForServersAwsOfferingMdeAutoProvisioning : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DefenderForServersAwsOfferingMdeAutoProvisioning() { }
        public Azure.Provisioning.BicepValue<System.BinaryData> Configuration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> Enabled { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DefenderForServersAwsOfferingVmScanners : Azure.Provisioning.SecurityCenter.VmScannersAws
    {
        public DefenderForServersAwsOfferingVmScanners() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DefenderForServersAwsOfferingVulnerabilityAssessmentAutoProvisioning : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DefenderForServersAwsOfferingVulnerabilityAssessmentAutoProvisioning() { }
        public Azure.Provisioning.BicepValue<bool> Enabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.VulnerabilityAssessmentAutoProvisioningType> Type { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DefenderForServersGcpOffering : Azure.Provisioning.SecurityCenter.SecurityCenterCloudOffering
    {
        public DefenderForServersGcpOffering() { }
        public Azure.Provisioning.SecurityCenter.DefenderForServersGcpOfferingArcAutoProvisioning ArcAutoProvisioning { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.GcpDefenderForServersInfo DefenderForServers { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.DefenderForServersGcpOfferingMdeAutoProvisioning MdeAutoProvisioning { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.AvailableSubPlanType> SubPlanType { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.DefenderForServersGcpOfferingVaAutoProvisioning VaAutoProvisioning { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.DefenderForServersGcpOfferingVmScanners VmScanners { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DefenderForServersGcpOfferingArcAutoProvisioning : Azure.Provisioning.SecurityCenter.ArcAutoProvisioningGcp
    {
        public DefenderForServersGcpOfferingArcAutoProvisioning() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DefenderForServersGcpOfferingMdeAutoProvisioning : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DefenderForServersGcpOfferingMdeAutoProvisioning() { }
        public Azure.Provisioning.BicepValue<System.BinaryData> Configuration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> Enabled { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DefenderForServersGcpOfferingVaAutoProvisioning : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DefenderForServersGcpOfferingVaAutoProvisioning() { }
        public Azure.Provisioning.BicepValue<bool> Enabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.VulnerabilityAssessmentAutoProvisioningType> Type { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DefenderForServersGcpOfferingVmScanners : Azure.Provisioning.SecurityCenter.VmScannersGcp
    {
        public DefenderForServersGcpOfferingVmScanners() { }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DefenderForServersScanningMode
    {
        Default = 0,
    }
    public partial class DefenderForStorageSetting : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DefenderForStorageSetting(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.DefenderForStorageSettingProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Primitives.ProvisionableResource Scope { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SecurityCenter.DefenderForStorageSetting FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2025_09_01_PREVIEW;
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2026_01_01_PREVIEW;
        }
    }
    public partial class DefenderForStorageSettingProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DefenderForStorageSettingProperties() { }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsOverrideSubscriptionLevelSettings { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.MalwareScanningProperties MalwareScanning { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.SensitiveDataDiscoveryProperties SensitiveDataDiscovery { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DenylistCustomAlertRule : Azure.Provisioning.SecurityCenter.ListCustomAlertRule
    {
        public DenylistCustomAlertRule() { }
        public Azure.Provisioning.BicepList<string> DenylistValues { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DeviceSecurityGroup : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DeviceSecurityGroup(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SecurityCenter.AllowlistCustomAlertRule> AllowlistRules { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SecurityCenter.DenylistCustomAlertRule> DenylistRules { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Primitives.ProvisionableResource Scope { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SecurityCenter.ThresholdCustomAlertRule> ThresholdRules { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SecurityCenter.TimeWindowCustomAlertRule> TimeWindowRules { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SecurityCenter.DeviceSecurityGroup FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2019_08_01;
        }
    }
    public partial class DevOpsCapability : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DevOpsCapability() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DevOpsConfiguration : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DevOpsConfiguration(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.SecurityCenter.SecurityConnector Parent { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.DevOpsConfigurationProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SecurityCenter.DevOpsConfiguration FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2025_11_01_PREVIEW;
        }
    }
    public partial class DevOpsConfigurationProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DevOpsConfigurationProperties() { }
        public Azure.Provisioning.SecurityCenter.AgentlessConfiguration AgentlessConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AuthorizationCode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.AutoDiscovery> AutoDiscovery { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SecurityCenter.DevOpsCapability> Capabilities { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.DevOpsProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ProvisioningStatusMessage { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ProvisioningStatusUpdatedOn { get { throw null; } }
        public Azure.Provisioning.BicepList<string> TopLevelInventoryList { get { throw null; } set { } }
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
    public partial class DirectMethodInvokesNotInAllowedRange : Azure.Provisioning.SecurityCenter.TimeWindowCustomAlertRule
    {
        public DirectMethodInvokesNotInAllowedRange() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DiscoveredSecuritySolution : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal DiscoveredSecuritySolution() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Offer { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Publisher { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.SecurityFamily> SecurityFamily { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Sku { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SecurityCenter.DiscoveredSecuritySolution FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2020_01_01;
        }
    }
    public partial class DockerHubEnvironmentInfo : Azure.Provisioning.SecurityCenter.SecurityConnectorEnvironment
    {
        public DockerHubEnvironmentInfo() { }
        public Azure.Provisioning.SecurityCenter.SecurityConnectorAuthentication Authentication { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> ScanInterval { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
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
    public partial class GcpAuditLogConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public GcpAuditLogConfiguration() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.GcpLoggingProvisioningType> ProvisioningType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ResourceNamePrefix { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SecurityCenter.GcpLoggingResourceSet> ResourceSets { get { throw null; } set { } }
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
    public enum GcpLoggingProvisioningType
    {
        BringYourOwn = 0,
        ManualProvisioning = 1,
        AutoProvisioning = 2,
    }
    public partial class GcpLoggingResourceSet : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public GcpLoggingResourceSet() { }
        public Azure.Provisioning.BicepValue<string> PubSubSubscriptionName { get { throw null; } set { } }
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
    public partial class GitHubOwner : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal GitHubOwner() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.DevOpsConfiguration Parent { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.GitHubOwnerProperties Properties { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SecurityCenter.GitHubOwner FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2025_11_01_PREVIEW;
        }
    }
    public partial class GitHubOwnerProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public GitHubOwnerProperties() { }
        public Azure.Provisioning.BicepValue<string> GitHubInternalId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.OnboardingState> OnboardingState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> OwnerUri { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.DevOpsProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ProvisioningStatusMessage { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ProvisioningStatusUpdatedOn { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class GitHubRepository : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal GitHubRepository() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.GitHubOwner Parent { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.GitHubRepositoryProperties Properties { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SecurityCenter.GitHubRepository FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2025_11_01_PREVIEW;
        }
    }
    public partial class GitHubRepositoryProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public GitHubRepositoryProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.OnboardingState> OnboardingState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ParentOwnerName { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.DevOpsProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ProvisioningStatusMessage { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ProvisioningStatusUpdatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> RepoFullName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> RepoId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> RepoName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> RepoUri { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class GithubScopeEnvironment : Azure.Provisioning.SecurityCenter.SecurityConnectorEnvironment
    {
        public GithubScopeEnvironment() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class GitLabGroup : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal GitLabGroup() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.DevOpsConfiguration Parent { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.GitLabGroupProperties Properties { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SecurityCenter.GitLabGroup FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2025_11_01_PREVIEW;
        }
    }
    public partial class GitLabGroupProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public GitLabGroupProperties() { }
        public Azure.Provisioning.BicepValue<string> FullyQualifiedFriendlyName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> FullyQualifiedName { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.OnboardingState> OnboardingState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.DevOpsProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ProvisioningStatusMessage { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ProvisioningStatusUpdatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Uri { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class GitLabProject : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal GitLabProject() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.GitLabGroup Parent { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.GitLabProjectProperties Properties { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SecurityCenter.GitLabProject FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2025_11_01_PREVIEW;
        }
    }
    public partial class GitLabProjectProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public GitLabProjectProperties() { }
        public Azure.Provisioning.BicepValue<string> FullyQualifiedFriendlyName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> FullyQualifiedName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> FullyQualifiedParentGroupName { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.OnboardingState> OnboardingState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.DevOpsProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ProvisioningStatusMessage { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ProvisioningStatusUpdatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Uri { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class GitLabScopeEnvironmentInfo : Azure.Provisioning.SecurityCenter.SecurityConnectorEnvironment
    {
        public GitLabScopeEnvironmentInfo() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class GovernanceAssignment : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public GovernanceAssignment(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.SecurityCenter.GovernanceAssignmentAdditionalInfo AdditionalData { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.GovernanceEmailNotification GovernanceEmailNotification { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsGracePeriod { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Owner { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> RemediationDueOn { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.RemediationEta RemediationEta { get { throw null; } set { } }
        public Azure.Provisioning.Primitives.ProvisionableResource Scope { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SecurityCenter.GovernanceAssignment FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2022_01_01_PREVIEW;
        }
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
        public Azure.Provisioning.BicepValue<bool> DisableManagerEmailNotification { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> DisableOwnerEmailNotification { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class GovernanceRule : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public GovernanceRule(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<System.BinaryData> ConditionSets { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> ExcludedScopes { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.GovernanceRuleEmailNotification GovernanceEmailNotification { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsDisabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsGracePeriod { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsIncludeMemberScopes { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.GovernanceRuleMetadata Metadata { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.GovernanceRuleOwnerSource OwnerSource { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RemediationTimeframe { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> RulePriority { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.GovernanceRuleType> RuleType { get { throw null; } set { } }
        public Azure.Provisioning.Primitives.ProvisionableResource Scope { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.GovernanceRuleSourceResourceType> SourceResourceType { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> TenantId { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SecurityCenter.GovernanceRule FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2022_01_01_PREVIEW;
        }
    }
    public partial class GovernanceRuleEmailNotification : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public GovernanceRuleEmailNotification() { }
        public Azure.Provisioning.BicepValue<bool> DisableManagerEmailNotification { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> DisableOwnerEmailNotification { get { throw null; } set { } }
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
    public partial class HealthDataClassification : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public HealthDataClassification() { }
        public Azure.Provisioning.BicepValue<string> Component { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Scenario { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Scope { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class HealthReport : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal HealthReport() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<string> AffectedDefendersPlans { get { throw null; } }
        public Azure.Provisioning.BicepList<string> AffectedDefendersSubPlans { get { throw null; } }
        public Azure.Provisioning.SecurityCenter.SecurityConnectorEnvironmentDetails EnvironmentDetails { get { throw null; } }
        public Azure.Provisioning.SecurityCenter.HealthDataClassification HealthDataClassification { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SecurityCenter.SecurityHealthIssue> Issues { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> ReportAdditionalData { get { throw null; } }
        public Azure.Provisioning.SecurityCenter.SecurityCloudResourceDetails ResourceDetails { get { throw null; } }
        public Azure.Provisioning.SecurityCenter.HealthReportStatus Status { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SecurityCenter.HealthReport FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2023_05_01_PREVIEW;
        }
    }
    public partial class HealthReportStatus : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public HealthReportStatus() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.SecurityCenterHealthStatus> Code { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> FirstEvaluationOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastScannedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Reason { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> StatusChangedOn { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
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
    public enum ImplementationEffort
    {
        Low = 0,
        Moderate = 1,
        High = 2,
    }
    public partial class InformationProtectionKeyword : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public InformationProtectionKeyword() { }
        public Azure.Provisioning.BicepValue<bool> CanBeNumeric { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsCustom { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsExcluded { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Pattern { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class InformationProtectionPolicy : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public InformationProtectionPolicy(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.SecurityCenter.SecurityInformationTypeInfo> InformationTypes { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.SecurityCenter.SensitivityLabel> Labels { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastModifiedUtc { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Primitives.ProvisionableResource Scope { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Version { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SecurityCenter.InformationProtectionPolicy FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2017_08_01_PREVIEW;
        }
    }
    public partial class InformationProtectionSensitivityLabel : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public InformationProtectionSensitivityLabel() { }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<float> Order { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class InfoType : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public InfoType() { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum InheritFromParentState
    {
        Disabled = 0,
        Enabled = 1,
    }
    public enum InstallationMethod
    {
        Arc = 0,
        Helm = 1,
    }
    public partial class InventoryList : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public InventoryList() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.IotSecurityInventoryKind> InventoryKind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class IotSecurityAggregatedAlert : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal IotSecurityAggregatedAlert() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> ActionTaken { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> AggregatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> AlertDisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> AlertType { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> Count { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> EffectedResourceType { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> LogAnalyticsQuery { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.IotSecuritySolutionAnalyticsModel Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RemediationSteps { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.ReportedSeverity> ReportedSeverity { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SystemSource { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SecurityCenter.IotSecurityAggregatedAlertTopDevice> TopDevicesList { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> VendorName { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SecurityCenter.IotSecurityAggregatedAlert FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2019_08_01;
        }
    }
    public partial class IotSecurityAggregatedAlertTopDevice : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public IotSecurityAggregatedAlertTopDevice() { }
        public Azure.Provisioning.BicepValue<long> AlertsCount { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DeviceId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> LastOccurrence { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class IotSecurityAggregatedRecommendation : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal IotSecurityAggregatedRecommendation() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DetectedBy { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> HealthyDevices { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> LogAnalyticsQuery { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.IotSecuritySolutionAnalyticsModel Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RecommendationDisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> RecommendationName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> RecommendationTypeId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> RemediationSteps { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.ReportedSeverity> ReportedSeverity { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> UnhealthyDeviceCount { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SecurityCenter.IotSecurityAggregatedRecommendation FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2019_08_01;
        }
    }
    public partial class IotSecurityAlertedDevice : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public IotSecurityAlertedDevice() { }
        public Azure.Provisioning.BicepValue<long> AlertsCount { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DeviceId { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class IotSecurityDeviceAlert : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public IotSecurityDeviceAlert() { }
        public Azure.Provisioning.BicepValue<string> AlertDisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> AlertsCount { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.ReportedSeverity> ReportedSeverity { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class IotSecurityDeviceRecommendation : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public IotSecurityDeviceRecommendation() { }
        public Azure.Provisioning.BicepValue<long> DevicesCount { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> RecommendationDisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.ReportedSeverity> ReportedSeverity { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum IotSecurityInventoryKind
    {
        AzureDevOpsOrganization = 0,
        AzureDevOpsProject = 1,
        AzureDevOpsRepository = 2,
        GitHubOwner = 3,
        GitHubRepository = 4,
    }
    public enum IotSecurityInventoryListKind
    {
        Inclusion = 0,
        Exclusion = 1,
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
        public IotSecuritySolution(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
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
        public static Azure.Provisioning.SecurityCenter.IotSecuritySolution FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2019_08_01;
        }
    }
    public partial class IotSecuritySolutionAnalyticsModel : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal IotSecuritySolutionAnalyticsModel() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SecurityCenter.IotSecuritySolutionAnalyticsModelDevicesMetrics> DevicesMetrics { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.SecurityCenter.IotSeverityMetrics Metrics { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SecurityCenter.IotSecurityDeviceAlert> MostPrevalentDeviceAlerts { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SecurityCenter.IotSecurityDeviceRecommendation> MostPrevalentDeviceRecommendations { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.SecurityCenter.IotSecuritySolution Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SecurityCenter.IotSecurityAlertedDevice> TopAlertedDevices { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> UnhealthyDeviceCount { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SecurityCenter.IotSecuritySolutionAnalyticsModel FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2019_08_01;
        }
    }
    public partial class IotSecuritySolutionAnalyticsModelDevicesMetrics : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public IotSecuritySolutionAnalyticsModelDevicesMetrics() { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> Date { get { throw null; } }
        public Azure.Provisioning.SecurityCenter.IotSeverityMetrics DevicesMetrics { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum IotSecuritySolutionDataSource
    {
        TwinData = 0,
    }
    public enum IotSecuritySolutionExportOption
    {
        RawEvents = 0,
    }
    public partial class IotSeverityMetrics : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public IotSeverityMetrics() { }
        public Azure.Provisioning.BicepValue<long> High { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> Low { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> Medium { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class JFrogEnvironmentInfo : Azure.Provisioning.SecurityCenter.SecurityConnectorEnvironment
    {
        public JFrogEnvironmentInfo() { }
        public Azure.Provisioning.BicepValue<int> ScanInterval { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class JitNetworkAccessPolicy : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public JitNetworkAccessPolicy(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SecurityCenter.JitNetworkAccessRequestInfo> Requests { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SecurityCenter.JitNetworkAccessPolicyVirtualMachine> VirtualMachines { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SecurityCenter.JitNetworkAccessPolicy FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2020_01_01;
        }
    }
    public partial class JitNetworkAccessPolicyVirtualMachine : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public JitNetworkAccessPolicyVirtualMachine() { }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } set { } }
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
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> StartsOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SecurityCenter.JitNetworkAccessRequestVirtualMachine> VirtualMachines { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class JitNetworkAccessRequestPort : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public JitNetworkAccessRequestPort() { }
        public Azure.Provisioning.BicepValue<string> AllowedSourceAddressPrefix { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> AllowedSourceAddressPrefixes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> EndsOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MappedPort { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Number { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.JitNetworkAccessPortStatus> Status { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.JitNetworkAccessPortStatusReason> StatusReason { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class JitNetworkAccessRequestVirtualMachine : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public JitNetworkAccessRequestVirtualMachine() { }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SecurityCenter.JitNetworkAccessRequestPort> Ports { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum KillChainIntent
    {
        Unknown = 0,
        PreAttack = 1,
        InitialAccess = 2,
        Persistence = 3,
        PrivilegeEscalation = 4,
        DefenseEvasion = 5,
        CredentialAccess = 6,
        Discovery = 7,
        LateralMovement = 8,
        Execution = 9,
        Collection = 10,
        Exfiltration = 11,
        CommandAndControl = 12,
        Impact = 13,
        Probing = 14,
        Exploitation = 15,
    }
    public partial class ListCustomAlertRule : Azure.Provisioning.SecurityCenter.CustomAlertRule
    {
        public ListCustomAlertRule() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.SecurityValueType> ValueType { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class LocalUserNotAllowed : Azure.Provisioning.SecurityCenter.AllowlistCustomAlertRule
    {
        public LocalUserNotAllowed() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class LogAnalyticsIdentifier : Azure.Provisioning.SecurityCenter.SecurityAlertResourceIdentifier
    {
        public LogAnalyticsIdentifier() { }
        public Azure.Provisioning.BicepValue<string> AgentId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> WorkspaceId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> WorkspaceResourceGroup { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> WorkspaceSubscriptionId { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum MalwareScanningAutomatedResponseType
    {
        None = 0,
        BlobSoftDelete = 1,
    }
    public partial class MalwareScanningProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MalwareScanningProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.MalwareScanningAutomatedResponseType> AutomatedResponse { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.BlobScanResultsConfig> BlobScanResultsOptions { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.OnUploadProperties OnUpload { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.SecurityCenterOperationStatus OperationStatus { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ScanResultsEventGridTopicResourceId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MdeOnboarding : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal MdeOnboarding() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.BinaryData> OnboardingPackageLinux { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.BinaryData> OnboardingPackageWindows { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SecurityCenter.MdeOnboarding FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2021_10_01_PREVIEW;
        }
    }
    public enum MinimalRiskLevel
    {
        Critical = 0,
        High = 1,
        Medium = 2,
        Low = 3,
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
    public partial class NotificationsSource : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public NotificationsSource() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class NotificationsSourceAlert : Azure.Provisioning.SecurityCenter.NotificationsSource
    {
        public NotificationsSourceAlert() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.SecurityAlertMinimalSeverity> MinimalSeverity { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class NotificationsSourceAttackPath : Azure.Provisioning.SecurityCenter.NotificationsSource
    {
        public NotificationsSourceAttackPath() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.MinimalRiskLevel> MinimalRiskLevel { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum OnboardingState
    {
        NotApplicable = 0,
        OnboardedByOtherConnector = 1,
        Onboarded = 2,
        NotOnboarded = 3,
    }
    public partial class OnPremiseResourceDetails : Azure.Provisioning.SecurityCenter.SecurityCenterResourceDetails
    {
        public OnPremiseResourceDetails() { }
        public Azure.Provisioning.BicepValue<string> MachineName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SourceComputerId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> VmUuid { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WorkspaceId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class OnPremiseSqlResourceDetails : Azure.Provisioning.SecurityCenter.OnPremiseResourceDetails
    {
        public OnPremiseSqlResourceDetails() { }
        public Azure.Provisioning.BicepValue<string> DatabaseName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServerName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class OnUploadFilters : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public OnUploadFilters() { }
        public Azure.Provisioning.BicepValue<System.BinaryData> ExcludeBlobsLargerThan { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> ExcludeBlobsWithPrefix { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> ExcludeBlobsWithSuffix { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class OnUploadProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public OnUploadProperties() { }
        public Azure.Provisioning.BicepValue<int> CapGBPerMonth { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.OnUploadFilters Filters { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class PartialAssessmentProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PartialAssessmentProperties() { }
        public Azure.Provisioning.BicepValue<string> AssessmentKey { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class PrivateLinkGroup : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal PrivateLinkGroup() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> GroupId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.SecurityCenterPrivateLinkResource Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> RequiredMembers { get { throw null; } }
        public Azure.Provisioning.BicepList<string> RequiredZoneNames { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SecurityCenter.PrivateLinkGroup FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2026_01_01;
        }
    }
    public partial class ProcessNotAllowed : Azure.Provisioning.SecurityCenter.AllowlistCustomAlertRule
    {
        public ProcessNotAllowed() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class QueuePurgesNotInAllowedRange : Azure.Provisioning.SecurityCenter.TimeWindowCustomAlertRule
    {
        public QueuePurgesNotInAllowedRange() { }
        protected override void DefineProvisionableProperties() { }
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
    public enum RecommendationSupportedClouds
    {
        Azure = 0,
        AWS = 1,
        GCP = 2,
    }
    public partial class RegulatoryComplianceAssessment : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal RegulatoryComplianceAssessment() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> AssessmentDetailsLink { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> AssessmentType { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> FailedResources { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.RegulatoryComplianceControl Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> PassedResources { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> SkippedResources { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.SecurityAlertNotificationByRoleState> State { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> UnsupportedResources { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SecurityCenter.RegulatoryComplianceAssessment FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2019_01_01_PREVIEW;
        }
    }
    public partial class RegulatoryComplianceControl : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal RegulatoryComplianceControl() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> FailedAssessments { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.RegulatoryComplianceStandard Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> PassedAssessments { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> SkippedAssessments { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.SecurityAlertNotificationByRoleState> State { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SecurityCenter.RegulatoryComplianceControl FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2019_01_01_PREVIEW;
        }
    }
    public partial class RegulatoryComplianceStandard : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal RegulatoryComplianceStandard() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<int> FailedControls { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> PassedControls { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> SkippedControls { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.SecurityAlertNotificationByRoleState> State { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> UnsupportedControls { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SecurityCenter.RegulatoryComplianceStandard FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2019_01_01_PREVIEW;
        }
    }
    public partial class RemediationEta : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RemediationEta() { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> Eta { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Justification { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ReportedSeverity
    {
        Informational = 0,
        Low = 1,
        Medium = 2,
        High = 3,
    }
    public enum RiskLevel
    {
        None = 0,
        Low = 1,
        Medium = 2,
        High = 3,
        Critical = 4,
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
    public partial class RuleResultsProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RuleResultsProperties() { }
        public Azure.Provisioning.BicepValue<bool> IsLatestScan { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.BicepList<string>> Results { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum RuleSeverity
    {
        High = 0,
        Medium = 1,
        Low = 2,
        Informational = 3,
        Obsolete = 4,
    }
    public partial class SecureScore : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal SecureScore() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<double> Current { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> Max { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<double> Percentage { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> Weight { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SecurityCenter.SecureScore FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2020_01_01;
        }
    }
    public partial class SecurityAlert : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal SecurityAlert() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> AlertDisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> AlertType { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Uri> AlertUri { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> CompromisedEntity { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> CorrelationKey { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> EndsOn { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SecurityCenter.SecurityAlertEntity> Entities { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.BicepDictionary<string>> ExtendedLinks { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> ExtendedProperties { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> GeneratedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.KillChainIntent> Intent { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsIncident { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ProcessingEndsOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ProductComponentName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ProductName { get { throw null; } }
        public Azure.Provisioning.BicepList<string> RemediationSteps { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SecurityCenter.SecurityAlertResourceIdentifier> ResourceIdentifiers { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SecurityAlertSupportingEvidenceType { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.SecurityAlertSeverity> Severity { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> StartsOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.SecurityAlertStatus> Status { get { throw null; } }
        public Azure.Provisioning.BicepList<string> SubTechniques { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SystemAlertId { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepList<string> Techniques { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> VendorName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Version { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SecurityCenter.SecurityAlert FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2022_01_01;
        }
    }
    public partial class SecurityAlertEntity : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SecurityAlertEntity() { }
        public Azure.Provisioning.BicepValue<string> AlertEntityType { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum SecurityAlertMinimalSeverity
    {
        High = 0,
        Medium = 1,
        Low = 2,
    }
    public enum SecurityAlertNotificationByRoleState
    {
        Passed = 0,
        Failed = 1,
        Skipped = 2,
        Unsupported = 3,
        On = 4,
        Off = 5,
    }
    public enum SecurityAlertReceivingRole
    {
        AccountAdmin = 0,
        ServiceAdmin = 1,
        Owner = 2,
        Contributor = 3,
    }
    public partial class SecurityAlertResourceIdentifier : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SecurityAlertResourceIdentifier() { }
        protected override void DefineProvisionableProperties() { }
    }
    public enum SecurityAlertSeverity
    {
        Informational = 0,
        Low = 1,
        Medium = 2,
        High = 3,
    }
    public partial class SecurityAlertsSuppressionRule : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SecurityAlertsSuppressionRule(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> AlertType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Comment { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ExpiresOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastModifiedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Reason { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.SecurityAlertsSuppressionRuleState> State { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SecurityCenter.SuppressionAlertsScopeElement> SuppressionAlertsScopeAllOf { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SecurityCenter.SecurityAlertsSuppressionRule FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2019_01_01_PREVIEW;
        }
    }
    public enum SecurityAlertsSuppressionRuleState
    {
        Enabled = 0,
        Disabled = 1,
        Expired = 2,
    }
    public enum SecurityAlertStatus
    {
        Active = 0,
        InProgress = 1,
        Resolved = 2,
        Dismissed = 3,
    }
    public partial class SecurityApplication : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SecurityApplication(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<System.BinaryData> ConditionSets { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Primitives.ProvisionableResource Scope { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.ApplicationSourceResourceType> SourceResourceType { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SecurityCenter.SecurityApplication FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2022_07_01_PREVIEW;
        }
    }
    public partial class SecurityAssessment : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SecurityAssessment(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepDictionary<string> AdditionalData { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> LinksAzurePortalUri { get { throw null; } }
        public Azure.Provisioning.SecurityCenter.SecurityAssessmentMetadataProperties Metadata { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.SecurityAssessmentPartner PartnersData { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.SecurityCenterResourceDetails ResourceDetails { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.SecurityAssessmentPropertiesBaseRisk Risk { get { throw null; } set { } }
        public Azure.Provisioning.Primitives.ProvisionableResource Scope { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.SecurityAssessmentStatusResult Status { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SecurityCenter.SecurityAssessment FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_04;
        }
    }
    public partial class SecurityAssessmentMetadata : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SecurityAssessmentMetadata(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
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
        public Azure.Provisioning.BicepValue<string> PolicyDefinitionId { get { throw null; } }
        public Azure.Provisioning.SecurityCenter.SecurityAssessmentPublishDates PublishDates { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RemediationDescription { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.SecurityAssessmentSeverity> Severity { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SecurityCenter.SecurityAssessmentTactic> Tactics { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SecurityCenter.SecurityAssessmentTechnique> Techniques { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SecurityCenter.SecurityThreat> Threats { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.SecurityAssessmentUserImpact> UserImpact { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SecurityCenter.SecurityAssessmentMetadata FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_04;
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
        public Azure.Provisioning.BicepValue<string> PolicyDefinitionId { get { throw null; } }
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
    public partial class SecurityAssessmentPropertiesBaseRisk : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SecurityAssessmentPropertiesBaseRisk() { }
        public Azure.Provisioning.BicepList<string> AttackPathsReferences { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsContextualRisk { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.RiskLevel> Level { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SecurityCenter.SecurityAssessmentPropertiesBaseRiskPathsItem> Paths { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> RiskFactors { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SecurityAssessmentPropertiesBaseRiskPathsItem : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SecurityAssessmentPropertiesBaseRiskPathsItem() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SecurityCenter.SecurityAssessmentPropertiesBaseRiskPathsItemEdgeItem> Edges { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SecurityCenter.SecurityAssessmentPropertiesBaseRiskPathsItemNodesItem> Nodes { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SecurityAssessmentPropertiesBaseRiskPathsItemEdgeItem : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SecurityAssessmentPropertiesBaseRiskPathsItemEdgeItem() { }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TargetId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SecurityAssessmentPropertiesBaseRiskPathsItemNodesItem : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SecurityAssessmentPropertiesBaseRiskPathsItemNodesItem() { }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> NodePropertiesLabel { get { throw null; } set { } }
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
        Compute = 0,
        Networking = 1,
        Data = 2,
        IdentityAndAccess = 3,
        IoT = 4,
        Container = 5,
        AppServices = 6,
    }
    public enum SecurityAssessmentResourceStatus
    {
        Healthy = 0,
        NotApplicable = 1,
        OffByPolicy = 2,
        NotHealthy = 3,
    }
    public enum SecurityAssessmentSeverity
    {
        Low = 0,
        Medium = 1,
        High = 2,
        Critical = 3,
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
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> StatusChangedOn { get { throw null; } }
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
        Unknown = 0,
        BuiltIn = 1,
        Custom = 2,
        CustomPolicy = 3,
        CustomerManaged = 4,
        BuiltInPolicy = 5,
        VerifiedPartner = 6,
        ManualBuiltInPolicy = 7,
        ManualBuiltIn = 8,
        ManualCustomPolicy = 9,
        DynamicBuiltIn = 10,
    }
    public enum SecurityAssessmentUserImpact
    {
        Low = 0,
        Moderate = 1,
        High = 2,
    }
    public partial class SecurityAutomation : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SecurityAutomation(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
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
        public static Azure.Provisioning.SecurityCenter.SecurityAutomation FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2023_12_01_PREVIEW;
        }
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
        public Azure.Provisioning.BicepValue<string> EventHubResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsTrustedServiceEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SasPolicyName { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SecurityAutomationActionLogicApp : Azure.Provisioning.SecurityCenter.SecurityAutomationAction
    {
        public SecurityAutomationActionLogicApp() { }
        public Azure.Provisioning.BicepValue<string> LogicAppResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> Uri { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SecurityAutomationActionWorkspace : Azure.Provisioning.SecurityCenter.SecurityAutomationAction
    {
        public SecurityAutomationActionWorkspace() { }
        public Azure.Provisioning.BicepValue<string> WorkspaceResourceId { get { throw null; } set { } }
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
    public partial class SecurityCenterAllowedConnection : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal SecurityCenterAllowedConnection() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CalculatedOn { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SecurityCenter.ConnectableResourceInfo> ConnectableResources { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SecurityCenter.SecurityCenterAllowedConnection FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2020_01_01;
        }
    }
    public partial class SecurityCenterAssignment : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SecurityCenterAssignment(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> AdditionalDataExemptionCategory { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AssignedComponentKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AssignedStandardId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Effect { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ExpiresOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> Metadata { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Scope { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SecurityCenter.SecurityCenterAssignment FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2021_08_01_PREVIEW;
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
        DockerHub = 6,
        JFrog = 7,
    }
    public partial class SecurityCenterCloudOffering : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SecurityCenterCloudOffering() { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum SecurityCenterEffect
    {
        Audit = 0,
        Exempt = 1,
        Attest = 2,
    }
    public enum SecurityCenterExtensionIsEnabled
    {
        True = 0,
        False = 1,
    }
    public enum SecurityCenterHealthStatus
    {
        Healthy = 0,
        NotHealthy = 1,
        NotApplicable = 2,
    }
    public partial class SecurityCenterLocation : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal SecurityCenterLocation() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> Properties { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SecurityCenter.SecurityCenterLocation FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2015_06_01_PREVIEW;
        }
    }
    public partial class SecurityCenterOperationStatus : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SecurityCenterOperationStatus() { }
        public Azure.Provisioning.BicepValue<string> Code { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Message { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SecurityCenterPricing : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SecurityCenterPricing(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> EnablementOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.SecurityPolicyEnforce> Enforce { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SecurityCenter.SecurityConnectorExtension> Extensions { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> FreeTrialRemainingTime { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.SecurityCenterPricingInheritance> Inherited { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> InheritedFrom { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsDeprecated { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.SecurityCenterPricingTier> PricingTier { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> ReplacedBy { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.SecurityCenterResourcesCoverageStatus> ResourcesCoverageStatus { get { throw null; } }
        public Azure.Provisioning.Primitives.ProvisionableResource Scope { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SubPlan { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SecurityCenter.SecurityCenterPricing FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_01_01;
        }
    }
    public enum SecurityCenterPricingInheritance
    {
        True = 0,
        False = 1,
    }
    public enum SecurityCenterPricingTier
    {
        Free = 0,
        Standard = 1,
    }
    public partial class SecurityCenterPrivateEndpointConnection : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SecurityCenterPrivateEndpointConnection(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<string> GroupIds { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.SecurityCenterPrivateLinkResource Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateEndpointId { get { throw null; } }
        public Azure.Provisioning.SecurityCenter.SecurityCenterPrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.SecurityCenterPrivateEndpointConnectionProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SecurityCenter.SecurityCenterPrivateEndpointConnection FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2026_01_01;
        }
    }
    public enum SecurityCenterPrivateEndpointConnectionProvisioningState
    {
        Succeeded = 0,
        Creating = 1,
        Deleting = 2,
        Failed = 3,
    }
    public enum SecurityCenterPrivateEndpointServiceConnectionStatus
    {
        Pending = 0,
        Approved = 1,
        Rejected = 2,
    }
    public partial class SecurityCenterPrivateLinkResource : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SecurityCenterPrivateLinkResource(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SecurityCenter.SecurityCenterPrivateEndpointConnection> PrivateEndpointConnections { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SecurityCenter.PrivateLinkGroup> PrivateLinkResources { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.SecurityCenterProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.SecurityCenterPublicNetworkAccess> PublicNetworkAccess { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SecurityCenter.SecurityCenterPrivateLinkResource FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2026_01_01;
        }
    }
    public partial class SecurityCenterPrivateLinkServiceConnectionState : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SecurityCenterPrivateLinkServiceConnectionState() { }
        public Azure.Provisioning.BicepValue<string> ActionsRequired { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.SecurityCenterPrivateEndpointServiceConnectionStatus> Status { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum SecurityCenterProvisioningState
    {
        Succeeded = 0,
        Creating = 1,
        Updating = 2,
        Deleting = 3,
        Failed = 4,
        Canceled = 5,
        InProgress = 6,
    }
    public enum SecurityCenterPublicNetworkAccess
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class SecurityCenterResourceDetails : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SecurityCenterResourceDetails() { }
        protected override void DefineProvisionableProperties() { }
    }
    public enum SecurityCenterResourcesCoverageStatus
    {
        FullyCovered = 0,
        PartiallyCovered = 1,
        NotCovered = 2,
    }
    public enum SecurityCenterResourceSource
    {
        Azure = 0,
        OnPremise = 1,
        OnPremiseSql = 2,
        Aws = 3,
        Gcp = 4,
        OnPremiseResourceDetails = 5,
    }
    public partial class SecurityCenterStandard : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SecurityCenterStandard(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Category { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SecurityCenter.StandardComponentProperties> Components { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StandardType { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SecurityCenter.StandardSupportedClouds> SupportedClouds { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SecurityCenter.SecurityCenterStandard FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2021_08_01_PREVIEW;
        }
    }
    public partial class SecurityCloudResourceDetails : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SecurityCloudResourceDetails() { }
        public Azure.Provisioning.BicepValue<string> ConnectorId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.SecurityCenterResourceSource> Source { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SecurityCompliance : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal SecurityCompliance() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SecurityCenter.ComplianceSegment> AssessmentResult { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> AssessmentTimestampUtcOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> ResourceCount { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SecurityCenter.SecurityCompliance FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2017_08_01_PREVIEW;
        }
    }
    public partial class SecurityConnector : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SecurityConnector(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.SecurityCenter.SecurityConnectorEnvironment EnvironmentData { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.SecurityCenterCloudName> EnvironmentName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> HierarchyIdentifier { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> HierarchyIdentifierTrialEndsOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SecurityCenter.SecurityCenterCloudOffering> Offerings { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SecurityCenter.SecurityConnector FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2024_08_01_PREVIEW;
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2026_08_01_PREVIEW;
        }
    }
    public partial class SecurityConnectorAuthentication : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SecurityConnectorAuthentication() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SecurityConnectorEnvironment : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SecurityConnectorEnvironment() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SecurityConnectorEnvironmentDetails : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SecurityConnectorEnvironmentDetails() { }
        public Azure.Provisioning.BicepValue<string> EnvironmentHierarchyId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> NativeResourceId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> OrganizationalHierarchyId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SubscriptionId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> TenantId { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SecurityConnectorExtension : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SecurityConnectorExtension() { }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> AdditionalExtensionProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.SecurityCenterExtensionIsEnabled> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.SecurityCenterOperationStatus OperationStatus { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SecurityConnectorIdentity : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SecurityConnectorIdentity() { }
        public Azure.Provisioning.BicepValue<System.Guid> PrincipalId { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> TenantId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.SecurityConnectorIdentityType> Type { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum SecurityConnectorIdentityType
    {
        SystemAssigned = 0,
    }
    public partial class SecurityContact : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SecurityContact(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Emails { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.SecurityContactPropertiesNotificationsByRole NotificationsByRole { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SecurityCenter.NotificationsSource> NotificationsSources { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Phone { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SecurityCenter.SecurityContact FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2023_12_01_PREVIEW;
        }
    }
    public partial class SecurityContactPropertiesNotificationsByRole : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SecurityContactPropertiesNotificationsByRole() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SecurityCenter.SecurityAlertReceivingRole> Roles { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.SecurityAlertNotificationByRoleState> State { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SecurityCve : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SecurityCve() { }
        public Azure.Provisioning.BicepValue<string> Link { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Title { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SecurityCvss : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SecurityCvss() { }
        public Azure.Provisioning.BicepValue<float> Base { get { throw null; } }
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
        AttackPaths = 11,
        AttackPathsSnapshot = 12,
    }
    public enum SecurityExemptionCategory
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="waiver")]
        Waiver = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="mitigated")]
        Mitigated = 1,
    }
    public enum SecurityFamily
    {
        Waf = 0,
        Ngfw = 1,
        SaasWaf = 2,
        Va = 3,
    }
    public partial class SecurityHealthIssue : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SecurityHealthIssue() { }
        public Azure.Provisioning.BicepDictionary<string> IssueAdditionalData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> IssueDescription { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> IssueKey { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> IssueName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> RemediationScript { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> RemediationSteps { get { throw null; } }
        public Azure.Provisioning.BicepList<string> SecurityValues { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SecurityInformationTypeInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SecurityInformationTypeInfo() { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsCustom { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SecurityCenter.InformationProtectionKeyword> Keywords { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Order { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> RecommendedLabelId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SecurityOperator : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SecurityOperator(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.SecurityCenter.SecurityConnectorIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SecurityCenter.SecurityOperator FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2023_01_01_PREVIEW;
        }
    }
    public enum SecurityPolicyEnforce
    {
        False = 0,
        True = 1,
    }
    public partial class SecuritySetting : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SecuritySetting(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SecurityCenter.SecuritySetting FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2022_05_01;
        }
    }
    public partial class SecuritySolution : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal SecuritySolution() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProtectionStatus { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.SecurityCenterProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.SecurityFamily> SecurityFamily { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Template { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SecurityCenter.SecuritySolution FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2020_01_01;
        }
    }
    public enum SecuritySolutionStatus
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class SecurityStandard : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SecurityStandard(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SecurityCenter.PartialAssessmentProperties> Assessments { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SecurityCenter.StandardSupportedCloud> CloudProviders { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.SecurityCenter.StandardMetadata Metadata { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PolicySetDefinitionId { get { throw null; } set { } }
        public Azure.Provisioning.Primitives.ProvisionableResource Scope { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.SecurityStandardType> StandardType { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SecurityCenter.SecurityStandard FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_08_01;
        }
    }
    public enum SecurityStandardType
    {
        Custom = 0,
        Default = 1,
        Compliance = 2,
    }
    public partial class SecuritySubAssessment : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal SecuritySubAssessment() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.SecurityCenter.SecuritySubAssessmentAdditionalInfo AdditionalData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Category { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> GeneratedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Impact { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.SecurityAssessment Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Remediation { get { throw null; } }
        public Azure.Provisioning.SecurityCenter.SecurityCenterResourceDetails ResourceDetails { get { throw null; } }
        public Azure.Provisioning.SecurityCenter.SubAssessmentStatus Status { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> VulnerabilityId { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SecurityCenter.SecuritySubAssessment FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2019_01_01_PREVIEW;
        }
    }
    public partial class SecuritySubAssessmentAdditionalInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SecuritySubAssessmentAdditionalInfo() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SecurityTask : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal SecurityTask() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastStateChangedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SecurityTaskName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> State { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SubState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SecurityCenter.SecurityTask FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2015_06_01_PREVIEW;
        }
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
    public partial class SecurityTopology : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal SecurityTopology() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CalculatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SecurityCenter.TopologySingleResource> TopologyResources { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SecurityCenter.SecurityTopology FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2020_01_01;
        }
    }
    public enum SecurityValueType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="IpCidr")]
        IPCidr = 0,
        String = 1,
    }
    public partial class SecurityWorkspaceSetting : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SecurityWorkspaceSetting(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Scope { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> WorkspaceId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SecurityCenter.SecurityWorkspaceSetting FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2017_08_01_PREVIEW;
        }
    }
    public partial class SensitiveDataDiscoveryProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SensitiveDataDiscoveryProperties() { }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.SecurityCenterOperationStatus OperationStatus { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SensitivityLabel : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SensitivityLabel() { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> Enabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Order { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.SensitivityLabelRank> Rank { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum SensitivityLabelRank
    {
        None = 0,
        Low = 1,
        Medium = 2,
        High = 3,
        Critical = 4,
    }
    public partial class SensitivitySetting : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SensitivitySetting(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.SecurityCenter.SensitivitySettingsProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SecurityCenter.SensitivitySetting FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2023_02_15_PREVIEW;
        }
    }
    public partial class SensitivitySettingsMipInformation : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SensitivitySettingsMipInformation() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SecurityCenter.BuiltInInfoType> BuiltInInfoTypes { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SecurityCenter.InfoType> CustomInfoTypes { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SecurityCenter.InformationProtectionSensitivityLabel> Labels { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.MipIntegrationStatus> MipIntegrationStatus { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SensitivitySettingsProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SensitivitySettingsProperties() { }
        public Azure.Provisioning.SecurityCenter.SensitivitySettingsMipInformation MipInformation { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<System.Guid> SensitiveInfoTypesIds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SensitivityThresholdLabelId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<float> SensitivityThresholdLabelOrder { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ServerVulnerabilityAssessment : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ServerVulnerabilityAssessment(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.ServerVulnerabilityAssessmentPropertiesProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Primitives.ProvisionableResource Scope { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SecurityCenter.ServerVulnerabilityAssessment FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
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
        public ServerVulnerabilityAssessmentsSetting(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SecurityCenter.ServerVulnerabilityAssessmentsSetting FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2023_05_01;
        }
    }
    public partial class ServerVulnerabilityProperties : Azure.Provisioning.SecurityCenter.SecuritySubAssessmentAdditionalInfo
    {
        public ServerVulnerabilityProperties() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SecurityCenter.SecurityCve> Cve { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.SecurityCenter.SecurityCvss> Cvss { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsPatchable { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> PublishedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Threat { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Type { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SecurityCenter.VendorReference> VendorReferences { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SqlServerVulnerabilityProperties : Azure.Provisioning.SecurityCenter.SecuritySubAssessmentAdditionalInfo
    {
        public SqlServerVulnerabilityProperties() { }
        public Azure.Provisioning.BicepValue<string> Query { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Type { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SqlVulnerabilityAssessmentBaseline : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SqlVulnerabilityAssessmentBaseline() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.BicepList<string>> ExpectedResults { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> UpdatedOn { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SqlVulnerabilityAssessmentBaselineRule : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SqlVulnerabilityAssessmentBaselineRule(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.RuleResultsProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Primitives.ProvisionableResource Scope { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SecurityCenter.SqlVulnerabilityAssessmentBaselineRule FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2026_04_01_PREVIEW;
        }
    }
    public partial class SqlVulnerabilityAssessmentRemediation : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SqlVulnerabilityAssessmentRemediation() { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsAutomated { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> PortalLink { get { throw null; } }
        public Azure.Provisioning.BicepList<string> Scripts { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SqlVulnerabilityAssessmentScan : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal SqlVulnerabilityAssessmentScan() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.SqlVulnerabilityAssessmentSettings Parent { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.SqlVulnerabilityAssessmentScanProperties Properties { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SecurityCenter.SqlVulnerabilityAssessmentScan FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2026_04_01_PREVIEW;
        }
    }
    public partial class SqlVulnerabilityAssessmentScanProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SqlVulnerabilityAssessmentScanProperties() { }
        public Azure.Provisioning.BicepValue<string> Database { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> EndsOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> HighSeverityFailedRulesCount { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsBaselineApplied { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastScanOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> LowSeverityFailedRulesCount { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> MediumSeverityFailedRulesCount { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Server { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SqlVersion { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> StartsOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.SqlVulnerabilityAssessmentScanState> State { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> TotalFailedRulesCount { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> TotalPassedRulesCount { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> TotalRulesCount { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.SqlVulnerabilityAssessmentScanTriggerType> TriggerType { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SqlVulnerabilityAssessmentScanResult : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal SqlVulnerabilityAssessmentScanResult() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.SqlVulnerabilityAssessmentScan Parent { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.SqlVulnerabilityAssessmentScanResultProperties Properties { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SecurityCenter.SqlVulnerabilityAssessmentScanResult FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2026_04_01_PREVIEW;
        }
    }
    public partial class SqlVulnerabilityAssessmentScanResultProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SqlVulnerabilityAssessmentScanResultProperties() { }
        public Azure.Provisioning.SecurityCenter.BaselineAdjustedResult BaselineAdjustedResult { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsTrimmed { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.BicepList<string>> QueryResults { get { throw null; } }
        public Azure.Provisioning.SecurityCenter.SqlVulnerabilityAssessmentRemediation Remediation { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> RuleId { get { throw null; } }
        public Azure.Provisioning.SecurityCenter.VulnerabilityAssessmentRule RuleMetadata { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.SqlVulnerabilityAssessmentScanResultRuleStatus> Status { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum SqlVulnerabilityAssessmentScanResultRuleStatus
    {
        NonFinding = 0,
        Finding = 1,
        InternalError = 2,
        NotApplicable = 3,
    }
    public enum SqlVulnerabilityAssessmentScanState
    {
        Failed = 0,
        FailedToRun = 1,
        InProgress = 2,
        Passed = 3,
    }
    public enum SqlVulnerabilityAssessmentScanTriggerType
    {
        OnDemand = 0,
        Recurring = 1,
    }
    public partial class SqlVulnerabilityAssessmentSettings : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SqlVulnerabilityAssessmentSettings(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.SecurityCenter.SqlVulnerabilityAssessmentSettingsProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Primitives.ProvisionableResource Scope { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SecurityCenter.SqlVulnerabilityAssessmentSettings FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2026_04_01_PREVIEW;
        }
    }
    public partial class SqlVulnerabilityAssessmentSettingsProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SqlVulnerabilityAssessmentSettingsProperties() { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.SqlVulnerabilityAssessmentState> State { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum SqlVulnerabilityAssessmentState
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class StandardAssignment : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public StandardAssignment(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> AssignedStandardId { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.StandardAssignmentAttestationInfo AttestationData { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.SecurityCenterEffect> Effect { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> ExcludedScopes { get { throw null; } set { } }
        public Azure.Provisioning.SecurityCenter.StandardAssignmentExemptionInfo ExemptionData { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ExpiresOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.SecurityCenter.StandardAssignmentMetadata Metadata { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Primitives.ProvisionableResource Scope { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SecurityCenter.StandardAssignment FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_08_01;
        }
    }
    public enum StandardAssignmentAttestationComplianceState
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="unknown")]
        Unknown = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="compliant")]
        Compliant = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="nonCompliant")]
        NonCompliant = 2,
    }
    public partial class StandardAssignmentAttestationInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public StandardAssignmentAttestationInfo() { }
        public Azure.Provisioning.BicepValue<string> AssessmentKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ComplianceOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.StandardAssignmentAttestationComplianceState> ComplianceState { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SecurityCenter.AttestationEvidence> Evidence { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class StandardAssignmentExemptionInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public StandardAssignmentExemptionInfo() { }
        public Azure.Provisioning.BicepValue<string> AssessmentKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.SecurityExemptionCategory> ExemptionCategory { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class StandardAssignmentMetadata : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public StandardAssignmentMetadata() { }
        public Azure.Provisioning.BicepValue<string> CreatedBy { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> LastUpdatedBy { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastUpdatedOn { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class StandardComponentProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public StandardComponentProperties() { }
        public Azure.Provisioning.BicepValue<string> Key { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class StandardMetadata : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public StandardMetadata() { }
        public Azure.Provisioning.BicepValue<string> CreatedBy { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> LastUpdatedBy { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastUpdatedOn { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum StandardSupportedCloud
    {
        Azure = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="AWS")]
        Aws = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="GCP")]
        Gcp = 2,
    }
    public enum StandardSupportedClouds
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="AWS")]
        Aws = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="GCP")]
        Gcp = 1,
    }
    public partial class SubAssessmentStatus : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SubAssessmentStatus() { }
        public Azure.Provisioning.BicepValue<string> Cause { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.SubAssessmentStatusCode> Code { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.SecurityAssessmentSeverity> Severity { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum SubAssessmentStatusCode
    {
        Healthy = 0,
        Unhealthy = 1,
        NotApplicable = 2,
    }
    public partial class SuppressionAlertsScopeElement : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SuppressionAlertsScopeElement() { }
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
    public partial class ThresholdCustomAlertRule : Azure.Provisioning.SecurityCenter.CustomAlertRule
    {
        public ThresholdCustomAlertRule() { }
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
    public partial class TopologySingleResource : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public TopologySingleResource() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SecurityCenter.TopologySingleResourceChild> Children { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Location { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> NetworkZones { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SecurityCenter.TopologySingleResourceParent> Parents { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> RecommendationsExist { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ResourceId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Severity { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> TopologyScore { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class TopologySingleResourceChild : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public TopologySingleResourceChild() { }
        public Azure.Provisioning.BicepValue<string> ResourceId { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class TopologySingleResourceParent : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public TopologySingleResourceParent() { }
        public Azure.Provisioning.BicepValue<string> ResourceId { get { throw null; } }
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
    public partial class UserDefinedResourcesProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public UserDefinedResourcesProperties() { }
        public Azure.Provisioning.BicepValue<string> Query { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> QuerySubscriptions { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VendorReference : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VendorReference() { }
        public Azure.Provisioning.BicepValue<string> Link { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Title { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VmScannersAws : Azure.Provisioning.SecurityCenter.VmScannersBase
    {
        public VmScannersAws() { }
        public Azure.Provisioning.BicepValue<string> CloudRoleArn { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VmScannersBase : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VmScannersBase() { }
        public Azure.Provisioning.SecurityCenter.VmScannersBaseConfiguration Configuration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> Enabled { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VmScannersBaseConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VmScannersBaseConfiguration() { }
        public Azure.Provisioning.BicepDictionary<string> ExclusionTags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.DefenderForServersScanningMode> ScanningMode { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VmScannersGcp : Azure.Provisioning.SecurityCenter.VmScannersBase
    {
        public VmScannersGcp() { }
        protected override void DefineProvisionableProperties() { }
    }
    public enum VulnerabilityAssessmentAutoProvisioningType
    {
        Qualys = 0,
        TVM = 1,
    }
    public partial class VulnerabilityAssessmentRule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VulnerabilityAssessmentRule() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SecurityCenter.BenchmarkReference> BenchmarkReferences { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Category { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } }
        public Azure.Provisioning.SecurityCenter.VulnerabilityAssessmentRuleQueryCheck QueryCheck { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Rationale { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> RuleId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.VulnerabilityAssessmentRuleType> RuleType { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecurityCenter.RuleSeverity> Severity { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Title { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VulnerabilityAssessmentRuleQueryCheck : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VulnerabilityAssessmentRuleQueryCheck() { }
        public Azure.Provisioning.BicepList<string> ColumnNames { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.BicepList<string>> ExpectedResult { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Query { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum VulnerabilityAssessmentRuleType
    {
        Binary = 0,
        BaselineExpected = 1,
        PositiveList = 2,
        NegativeList = 3,
    }
}
