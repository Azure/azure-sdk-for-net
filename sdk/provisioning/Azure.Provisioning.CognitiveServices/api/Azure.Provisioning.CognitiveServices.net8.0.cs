namespace Azure.Provisioning.CognitiveServices
{
    public partial class AbusePenalty : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AbusePenalty() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.AbusePenaltyAction> Action { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> Expiration { get { throw null; } }
        public Azure.Provisioning.BicepValue<float> RateLimitPercentage { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum AbusePenaltyAction
    {
        Throttle = 0,
        Block = 1,
    }
    public partial class BillingMeterInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BillingMeterInfo() { }
        public Azure.Provisioning.BicepValue<string> MeterId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Unit { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CognitiveServicesAccount : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public CognitiveServicesAccount(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.CognitiveServices.CognitiveServicesAccountProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.CognitiveServices.CognitiveServicesSku Sku { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.Authorization.RoleAssignment CreateRoleAssignment(Azure.Provisioning.CognitiveServices.CognitiveServicesBuiltInRole role, Azure.Provisioning.BicepValue<Azure.Provisioning.Authorization.RoleManagementPrincipalType> principalType, Azure.Provisioning.BicepValue<System.Guid> principalId, string? bicepIdentifierSuffix = null) { throw null; }
        public Azure.Provisioning.Authorization.RoleAssignment CreateRoleAssignment(Azure.Provisioning.CognitiveServices.CognitiveServicesBuiltInRole role, Azure.Provisioning.Roles.UserAssignedIdentity identity) { throw null; }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.CognitiveServices.CognitiveServicesAccount FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public Azure.Provisioning.CognitiveServices.ServiceAccountApiKeys GetKeys() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2017_04_18;
            public static readonly string V2021_04_30;
            public static readonly string V2021_10_01;
            public static readonly string V2022_03_01;
            public static readonly string V2022_10_01;
            public static readonly string V2022_12_01;
            public static readonly string V2023_05_01;
            public static readonly string V2024_10_01;
        }
    }
    public partial class CognitiveServicesAccountDeployment : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public CognitiveServicesAccountDeployment(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.CognitiveServices.CognitiveServicesAccount? Parent { get { throw null; } set { } }
        public Azure.Provisioning.CognitiveServices.CognitiveServicesAccountDeploymentProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.CognitiveServices.CognitiveServicesSku Sku { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.CognitiveServices.CognitiveServicesAccountDeployment FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2017_04_18;
            public static readonly string V2021_04_30;
            public static readonly string V2021_10_01;
            public static readonly string V2022_03_01;
            public static readonly string V2022_10_01;
            public static readonly string V2022_12_01;
            public static readonly string V2023_05_01;
            public static readonly string V2024_10_01;
        }
    }
    public partial class CognitiveServicesAccountDeploymentModel : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CognitiveServicesAccountDeploymentModel() { }
        public Azure.Provisioning.CognitiveServices.ServiceAccountCallRateLimit CallRateLimit { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Format { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Publisher { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Source { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SourceAccount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Version { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CognitiveServicesAccountDeploymentProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CognitiveServicesAccountDeploymentProperties() { }
        public Azure.Provisioning.CognitiveServices.ServiceAccountCallRateLimit CallRateLimit { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Capabilities { get { throw null; } }
        public Azure.Provisioning.CognitiveServices.DeploymentCapacitySettings CapacitySettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> CurrentCapacity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsDynamicThrottlingEnabled { get { throw null; } }
        public Azure.Provisioning.CognitiveServices.CognitiveServicesAccountDeploymentModel Model { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ParentDeploymentName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.CognitiveServicesAccountDeploymentProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> RaiPolicyName { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CognitiveServices.ServiceAccountThrottlingRule> RateLimits { get { throw null; } }
        public Azure.Provisioning.CognitiveServices.CognitiveServicesAccountDeploymentScaleSettings ScaleSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.DeploymentModelVersionUpgradeOption> VersionUpgradeOption { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum CognitiveServicesAccountDeploymentProvisioningState
    {
        Accepted = 0,
        Creating = 1,
        Deleting = 2,
        Moving = 3,
        Failed = 4,
        Succeeded = 5,
        Disabled = 6,
        Canceled = 7,
    }
    public partial class CognitiveServicesAccountDeploymentScaleSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CognitiveServicesAccountDeploymentScaleSettings() { }
        public Azure.Provisioning.BicepValue<int> ActiveCapacity { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> Capacity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.CognitiveServicesAccountDeploymentScaleType> ScaleType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum CognitiveServicesAccountDeploymentScaleType
    {
        Standard = 0,
        Manual = 1,
    }
    public partial class CognitiveServicesAccountModel : Azure.Provisioning.CognitiveServices.CognitiveServicesAccountDeploymentModel
    {
        public CognitiveServicesAccountModel() { }
        public Azure.Provisioning.CognitiveServices.CognitiveServicesAccountDeploymentModel BaseModel { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Capabilities { get { throw null; } set { } }
        public Azure.Provisioning.CognitiveServices.ServiceAccountModelDeprecationInfo Deprecation { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> FinetuneCapabilities { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsDefaultVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.ModelLifecycleStatus> LifecycleStatus { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxCapacity { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CognitiveServices.CognitiveServicesModelSku> Skus { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CognitiveServicesAccountProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CognitiveServicesAccountProperties() { }
        public Azure.Provisioning.CognitiveServices.AbusePenalty AbusePenalty { get { throw null; } }
        public Azure.Provisioning.BicepList<string> AllowedFqdnList { get { throw null; } set { } }
        public Azure.Provisioning.CognitiveServices.UserOwnedAmlWorkspace AmlWorkspace { get { throw null; } set { } }
        public Azure.Provisioning.CognitiveServices.ServiceAccountApiProperties ApiProperties { get { throw null; } set { } }
        public Azure.Provisioning.CognitiveServices.ServiceAccountCallRateLimit CallRateLimit { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CognitiveServices.CognitiveServicesSkuCapability> Capabilities { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CognitiveServices.CommitmentPlanAssociation> CommitmentPlanAssociations { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> CustomSubDomainName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> DeletedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> DisableLocalAuth { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableDynamicThrottling { get { throw null; } set { } }
        public Azure.Provisioning.CognitiveServices.ServiceAccountEncryptionProperties Encryption { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Endpoint { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Endpoints { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsMigrated { get { throw null; } }
        public Azure.Provisioning.CognitiveServices.CognitiveServicesMultiRegionSettings Locations { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MigrationToken { get { throw null; } set { } }
        public Azure.Provisioning.CognitiveServices.CognitiveServicesNetworkRuleSet NetworkAcls { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CognitiveServices.CognitiveServicesPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.ServiceAccountProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.ServiceAccountPublicNetworkAccess> PublicNetworkAccess { get { throw null; } set { } }
        public Azure.Provisioning.CognitiveServices.ServiceAccountQuotaLimit QuotaLimit { get { throw null; } }
        public Azure.Provisioning.CognitiveServices.RaiMonitorConfig RaiMonitorConfig { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> Restore { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> RestrictOutboundNetworkAccess { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ScheduledPurgeDate { get { throw null; } }
        public Azure.Provisioning.CognitiveServices.CognitiveServicesSkuChangeInfo SkuChangeInfo { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CognitiveServices.ServiceAccountUserOwnedStorage> UserOwnedStorage { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CognitiveServicesBuiltInRole : System.IEquatable<Azure.Provisioning.CognitiveServices.CognitiveServicesBuiltInRole>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CognitiveServicesBuiltInRole(string value) { throw null; }
        public static Azure.Provisioning.CognitiveServices.CognitiveServicesBuiltInRole AzureAIDeveloper { get { throw null; } }
        public static Azure.Provisioning.CognitiveServices.CognitiveServicesBuiltInRole AzureAIEnterpriseNetworkConnectionApprover { get { throw null; } }
        public static Azure.Provisioning.CognitiveServices.CognitiveServicesBuiltInRole AzureAIInferenceDeploymentOperator { get { throw null; } }
        public static Azure.Provisioning.CognitiveServices.CognitiveServicesBuiltInRole CognitiveServicesContributor { get { throw null; } }
        public static Azure.Provisioning.CognitiveServices.CognitiveServicesBuiltInRole CognitiveServicesCustomVisionContributor { get { throw null; } }
        public static Azure.Provisioning.CognitiveServices.CognitiveServicesBuiltInRole CognitiveServicesCustomVisionDeployment { get { throw null; } }
        public static Azure.Provisioning.CognitiveServices.CognitiveServicesBuiltInRole CognitiveServicesCustomVisionLabeler { get { throw null; } }
        public static Azure.Provisioning.CognitiveServices.CognitiveServicesBuiltInRole CognitiveServicesCustomVisionReader { get { throw null; } }
        public static Azure.Provisioning.CognitiveServices.CognitiveServicesBuiltInRole CognitiveServicesCustomVisionTrainer { get { throw null; } }
        public static Azure.Provisioning.CognitiveServices.CognitiveServicesBuiltInRole CognitiveServicesDataReader { get { throw null; } }
        public static Azure.Provisioning.CognitiveServices.CognitiveServicesBuiltInRole CognitiveServicesFaceRecognizer { get { throw null; } }
        public static Azure.Provisioning.CognitiveServices.CognitiveServicesBuiltInRole CognitiveServicesMetricsAdvisorAdministrator { get { throw null; } }
        public static Azure.Provisioning.CognitiveServices.CognitiveServicesBuiltInRole CognitiveServicesOpenAIContributor { get { throw null; } }
        public static Azure.Provisioning.CognitiveServices.CognitiveServicesBuiltInRole CognitiveServicesOpenAIUser { get { throw null; } }
        public static Azure.Provisioning.CognitiveServices.CognitiveServicesBuiltInRole CognitiveServicesQnAMakerEditor { get { throw null; } }
        public static Azure.Provisioning.CognitiveServices.CognitiveServicesBuiltInRole CognitiveServicesQnAMakerReader { get { throw null; } }
        public static Azure.Provisioning.CognitiveServices.CognitiveServicesBuiltInRole CognitiveServicesUsagesReader { get { throw null; } }
        public static Azure.Provisioning.CognitiveServices.CognitiveServicesBuiltInRole CognitiveServicesUser { get { throw null; } }
        public bool Equals(Azure.Provisioning.CognitiveServices.CognitiveServicesBuiltInRole other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object? obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static string GetBuiltInRoleName(Azure.Provisioning.CognitiveServices.CognitiveServicesBuiltInRole value) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Provisioning.CognitiveServices.CognitiveServicesBuiltInRole left, Azure.Provisioning.CognitiveServices.CognitiveServicesBuiltInRole right) { throw null; }
        public static implicit operator Azure.Provisioning.CognitiveServices.CognitiveServicesBuiltInRole (string value) { throw null; }
        public static bool operator !=(Azure.Provisioning.CognitiveServices.CognitiveServicesBuiltInRole left, Azure.Provisioning.CognitiveServices.CognitiveServicesBuiltInRole right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CognitiveServicesCapacityConfig : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CognitiveServicesCapacityConfig() { }
        public Azure.Provisioning.BicepList<int> AllowedValues { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Default { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Maximum { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Minimum { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Step { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CognitiveServicesCommitmentPlan : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public CognitiveServicesCommitmentPlan(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.CognitiveServices.CommitmentPlanProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.CognitiveServices.CognitiveServicesSku Sku { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.CognitiveServices.CognitiveServicesCommitmentPlan FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2022_12_01;
            public static readonly string V2023_05_01;
            public static readonly string V2024_10_01;
        }
    }
    public partial class CognitiveServicesEncryptionScope : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public CognitiveServicesEncryptionScope(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.CognitiveServices.CognitiveServicesAccount? Parent { get { throw null; } set { } }
        public Azure.Provisioning.CognitiveServices.CognitiveServicesEncryptionScopeProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.CognitiveServices.CognitiveServicesEncryptionScope FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2022_03_01;
            public static readonly string V2022_10_01;
            public static readonly string V2022_12_01;
            public static readonly string V2023_05_01;
            public static readonly string V2024_10_01;
        }
    }
    public partial class CognitiveServicesEncryptionScopeProperties : Azure.Provisioning.CognitiveServices.ServiceAccountEncryptionProperties
    {
        public CognitiveServicesEncryptionScopeProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.EncryptionScopeProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.EncryptionScopeState> State { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CognitiveServicesIPRule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CognitiveServicesIPRule() { }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CognitiveServicesKeyVaultProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CognitiveServicesKeyVaultProperties() { }
        public Azure.Provisioning.BicepValue<System.Guid> IdentityClientId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> KeyName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> KeyVaultUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> KeyVersion { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CognitiveServicesModelSku : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CognitiveServicesModelSku() { }
        public Azure.Provisioning.CognitiveServices.CognitiveServicesCapacityConfig Capacity { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CognitiveServices.BillingMeterInfo> Cost { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> DeprecationOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CognitiveServices.ServiceAccountCallRateLimit> RateLimits { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> UsageName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CognitiveServicesMultiRegionSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CognitiveServicesMultiRegionSettings() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CognitiveServices.CognitiveServicesRegionSetting> Regions { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.CognitiveServicesRoutingMethod> RoutingMethod { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum CognitiveServicesNetworkRuleAction
    {
        Allow = 0,
        Deny = 1,
    }
    public partial class CognitiveServicesNetworkRuleSet : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CognitiveServicesNetworkRuleSet() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.TrustedServicesByPassSelection> Bypass { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.CognitiveServicesNetworkRuleAction> DefaultAction { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CognitiveServices.CognitiveServicesIPRule> IPRules { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CognitiveServices.CognitiveServicesVirtualNetworkRule> VirtualNetworkRules { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CognitiveServicesPrivateEndpointConnectionData : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CognitiveServicesPrivateEndpointConnectionData() { }
        public Azure.Provisioning.CognitiveServices.CognitiveServicesPrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepList<string> GroupIds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateEndpointId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.CognitiveServicesPrivateEndpointConnectionProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum CognitiveServicesPrivateEndpointConnectionProvisioningState
    {
        Succeeded = 0,
        Creating = 1,
        Deleting = 2,
        Failed = 3,
    }
    public enum CognitiveServicesPrivateEndpointServiceConnectionStatus
    {
        Pending = 0,
        Approved = 1,
        Rejected = 2,
    }
    public partial class CognitiveServicesPrivateLinkServiceConnectionState : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CognitiveServicesPrivateLinkServiceConnectionState() { }
        public Azure.Provisioning.BicepValue<string> ActionsRequired { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.CognitiveServicesPrivateEndpointServiceConnectionStatus> Status { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CognitiveServicesRegionSetting : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CognitiveServicesRegionSetting() { }
        public Azure.Provisioning.BicepValue<string> Customsubdomain { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<float> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum CognitiveServicesRoutingMethod
    {
        Priority = 0,
        Weighted = 1,
        Performance = 2,
    }
    public partial class CognitiveServicesSku : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CognitiveServicesSku() { }
        public Azure.Provisioning.BicepValue<int> Capacity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Family { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Size { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.CognitiveServicesSkuTier> Tier { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CognitiveServicesSkuCapability : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CognitiveServicesSkuCapability() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CognitiveServicesSkuChangeInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CognitiveServicesSkuChangeInfo() { }
        public Azure.Provisioning.BicepValue<float> CountOfDowngrades { get { throw null; } }
        public Azure.Provisioning.BicepValue<float> CountOfUpgradesAfterDowngrades { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastChangedOn { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum CognitiveServicesSkuTier
    {
        Free = 0,
        Basic = 1,
        Standard = 2,
        Premium = 3,
        Enterprise = 4,
    }
    public partial class CognitiveServicesVirtualNetworkRule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CognitiveServicesVirtualNetworkRule() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IgnoreMissingVnetServiceEndpoint { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> State { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CommitmentPeriod : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CommitmentPeriod() { }
        public Azure.Provisioning.BicepValue<int> Count { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> EndOn { get { throw null; } }
        public Azure.Provisioning.CognitiveServices.CommitmentQuota Quota { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> StartOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Tier { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CommitmentPlan : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public CommitmentPlan(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.CognitiveServices.CognitiveServicesAccount? Parent { get { throw null; } set { } }
        public Azure.Provisioning.CognitiveServices.CommitmentPlanProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.CognitiveServices.CognitiveServicesSku Sku { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.CognitiveServices.CommitmentPlan FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2017_04_18;
            public static readonly string V2021_04_30;
            public static readonly string V2021_10_01;
            public static readonly string V2022_03_01;
            public static readonly string V2022_10_01;
            public static readonly string V2022_12_01;
            public static readonly string V2023_05_01;
            public static readonly string V2024_10_01;
        }
    }
    public partial class CommitmentPlanAccountAssociation : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public CommitmentPlanAccountAssociation(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> AccountId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.CognitiveServices.CognitiveServicesCommitmentPlan? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.CognitiveServices.CommitmentPlanAccountAssociation FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2022_12_01;
            public static readonly string V2023_05_01;
            public static readonly string V2024_10_01;
        }
    }
    public partial class CommitmentPlanAssociation : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CommitmentPlanAssociation() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> CommitmentPlanId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> CommitmentPlanLocation { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CommitmentPlanProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CommitmentPlanProperties() { }
        public Azure.Provisioning.BicepValue<bool> AutoRenew { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> CommitmentPlanGuid { get { throw null; } set { } }
        public Azure.Provisioning.CognitiveServices.CommitmentPeriod Current { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.ServiceAccountHostingModel> HostingModel { get { throw null; } set { } }
        public Azure.Provisioning.CognitiveServices.CommitmentPeriod Last { get { throw null; } }
        public Azure.Provisioning.CognitiveServices.CommitmentPeriod Next { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PlanType { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> ProvisioningIssues { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.CommitmentPlanProvisioningState> ProvisioningState { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum CommitmentPlanProvisioningState
    {
        Accepted = 0,
        Creating = 1,
        Deleting = 2,
        Moving = 3,
        Failed = 4,
        Succeeded = 5,
        Canceled = 6,
    }
    public partial class CommitmentQuota : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CommitmentQuota() { }
        public Azure.Provisioning.BicepValue<long> Quantity { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Unit { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CustomBlocklistConfig : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CustomBlocklistConfig() { }
        public Azure.Provisioning.BicepValue<bool> Blocking { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> BlocklistName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.RaiPolicyContentSource> Source { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DefenderForAISetting : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DefenderForAISetting(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.CognitiveServices.CognitiveServicesAccount? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.DefenderForAISettingState> State { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.CognitiveServices.DefenderForAISetting FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2017_04_18;
            public static readonly string V2021_04_30;
            public static readonly string V2021_10_01;
            public static readonly string V2022_03_01;
            public static readonly string V2022_10_01;
            public static readonly string V2022_12_01;
            public static readonly string V2023_05_01;
            public static readonly string V2024_10_01;
        }
    }
    public enum DefenderForAISettingState
    {
        Disabled = 0,
        Enabled = 1,
    }
    public partial class DeploymentCapacitySettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DeploymentCapacitySettings() { }
        public Azure.Provisioning.BicepValue<int> DesignatedCapacity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Priority { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DeploymentModelVersionUpgradeOption
    {
        OnceNewDefaultVersionAvailable = 0,
        OnceCurrentVersionExpired = 1,
        NoAutoUpgrade = 2,
    }
    public enum EncryptionScopeProvisioningState
    {
        Accepted = 0,
        Creating = 1,
        Deleting = 2,
        Moving = 3,
        Failed = 4,
        Succeeded = 5,
        Canceled = 6,
    }
    public enum EncryptionScopeState
    {
        Disabled = 0,
        Enabled = 1,
    }
    public enum ModelLifecycleStatus
    {
        GenerallyAvailable = 0,
        Preview = 1,
        Stable = 2,
        Deprecating = 3,
        Deprecated = 4,
    }
    public partial class RaiBlocklist : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public RaiBlocklist(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.CognitiveServices.CognitiveServicesAccount? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RaiBlocklistDescription { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.CognitiveServices.RaiBlocklist FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2017_04_18;
            public static readonly string V2021_04_30;
            public static readonly string V2021_10_01;
            public static readonly string V2022_03_01;
            public static readonly string V2022_10_01;
            public static readonly string V2022_12_01;
            public static readonly string V2023_05_01;
            public static readonly string V2024_10_01;
        }
    }
    public partial class RaiBlocklistItem : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public RaiBlocklistItem(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.CognitiveServices.RaiBlocklist? Parent { get { throw null; } set { } }
        public Azure.Provisioning.CognitiveServices.RaiBlocklistItemProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.CognitiveServices.RaiBlocklistItem FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2017_04_18;
            public static readonly string V2021_04_30;
            public static readonly string V2021_10_01;
            public static readonly string V2022_03_01;
            public static readonly string V2022_10_01;
            public static readonly string V2022_12_01;
            public static readonly string V2023_05_01;
            public static readonly string V2024_10_01;
        }
    }
    public partial class RaiBlocklistItemProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RaiBlocklistItemProperties() { }
        public Azure.Provisioning.BicepValue<bool> IsRegex { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Pattern { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RaiMonitorConfig : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RaiMonitorConfig() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> AdxStorageResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> IdentityClientId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RaiPolicy : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public RaiPolicy(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.CognitiveServices.CognitiveServicesAccount? Parent { get { throw null; } set { } }
        public Azure.Provisioning.CognitiveServices.RaiPolicyProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.CognitiveServices.RaiPolicy FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2017_04_18;
            public static readonly string V2021_04_30;
            public static readonly string V2021_10_01;
            public static readonly string V2022_03_01;
            public static readonly string V2022_10_01;
            public static readonly string V2022_12_01;
            public static readonly string V2023_05_01;
            public static readonly string V2024_10_01;
        }
    }
    public partial class RaiPolicyContentFilter : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RaiPolicyContentFilter() { }
        public Azure.Provisioning.BicepValue<bool> Blocking { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> Enabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.RaiPolicyContentLevel> SeverityThreshold { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.RaiPolicyContentSource> Source { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum RaiPolicyContentLevel
    {
        Low = 0,
        Medium = 1,
        High = 2,
    }
    public enum RaiPolicyContentSource
    {
        Prompt = 0,
        Completion = 1,
    }
    public enum RaiPolicyMode
    {
        Default = 0,
        Deferred = 1,
        Blocking = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Asynchronous_filter")]
        AsynchronousFilter = 3,
    }
    public partial class RaiPolicyProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RaiPolicyProperties() { }
        public Azure.Provisioning.BicepValue<string> BasePolicyName { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CognitiveServices.RaiPolicyContentFilter> ContentFilters { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CognitiveServices.CustomBlocklistConfig> CustomBlocklists { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.RaiPolicyMode> Mode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.RaiPolicyType> PolicyType { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum RaiPolicyType
    {
        UserManaged = 0,
        SystemManaged = 1,
    }
    public partial class ServiceAccountApiKeys : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ServiceAccountApiKeys() { }
        public Azure.Provisioning.BicepValue<string> Key1 { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Key2 { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ServiceAccountApiProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ServiceAccountApiProperties() { }
        public Azure.Provisioning.BicepValue<System.Guid> AadClientId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> AadTenantId { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> AdditionalProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableStatistics { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EventHubConnectionString { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> QnaAzureSearchEndpointId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> QnaAzureSearchEndpointKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> QnaRuntimeEndpoint { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StorageAccountConnectionString { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SuperUser { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WebsiteName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ServiceAccountCallRateLimit : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ServiceAccountCallRateLimit() { }
        public Azure.Provisioning.BicepValue<float> Count { get { throw null; } }
        public Azure.Provisioning.BicepValue<float> RenewalPeriod { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CognitiveServices.ServiceAccountThrottlingRule> Rules { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ServiceAccountEncryptionKeySource
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="Microsoft.CognitiveServices")]
        MicrosoftCognitiveServices = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Microsoft.KeyVault")]
        MicrosoftKeyVault = 1,
    }
    public partial class ServiceAccountEncryptionProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ServiceAccountEncryptionProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.ServiceAccountEncryptionKeySource> KeySource { get { throw null; } set { } }
        public Azure.Provisioning.CognitiveServices.CognitiveServicesKeyVaultProperties KeyVaultProperties { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ServiceAccountHostingModel
    {
        Web = 0,
        ConnectedContainer = 1,
        DisconnectedContainer = 2,
        ProvisionedWeb = 3,
    }
    public partial class ServiceAccountModelDeprecationInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ServiceAccountModelDeprecationInfo() { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> FineTuneOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> InferenceOn { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ServiceAccountProvisioningState
    {
        Accepted = 0,
        Creating = 1,
        Deleting = 2,
        Moving = 3,
        Failed = 4,
        Succeeded = 5,
        [System.Runtime.Serialization.DataMemberAttribute(Name="ResolvingDNS")]
        ResolvingDns = 6,
    }
    public enum ServiceAccountPublicNetworkAccess
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class ServiceAccountQuotaLimit : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ServiceAccountQuotaLimit() { }
        public Azure.Provisioning.BicepValue<float> Count { get { throw null; } }
        public Azure.Provisioning.BicepValue<float> RenewalPeriod { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CognitiveServices.ServiceAccountThrottlingRule> Rules { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ServiceAccountThrottlingMatchPattern : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ServiceAccountThrottlingMatchPattern() { }
        public Azure.Provisioning.BicepValue<string> Method { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Path { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ServiceAccountThrottlingRule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ServiceAccountThrottlingRule() { }
        public Azure.Provisioning.BicepValue<float> Count { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsDynamicThrottlingEnabled { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Key { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CognitiveServices.ServiceAccountThrottlingMatchPattern> MatchPatterns { get { throw null; } }
        public Azure.Provisioning.BicepValue<float> MinCount { get { throw null; } }
        public Azure.Provisioning.BicepValue<float> RenewalPeriod { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ServiceAccountUserOwnedStorage : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ServiceAccountUserOwnedStorage() { }
        public Azure.Provisioning.BicepValue<System.Guid> IdentityClientId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ResourceId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum TrustedServicesByPassSelection
    {
        None = 0,
        AzureServices = 1,
    }
    public partial class UserOwnedAmlWorkspace : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public UserOwnedAmlWorkspace() { }
        public Azure.Provisioning.BicepValue<System.Guid> IdentityClientId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ResourceId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
}
