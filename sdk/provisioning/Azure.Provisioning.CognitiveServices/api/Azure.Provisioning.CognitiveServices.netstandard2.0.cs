namespace Azure.Provisioning.CognitiveServices
{
    public partial class AbusePenalty : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public AbusePenalty() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.AbusePenaltyAction> Action { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> Expiration { get { throw null; } }
        public Azure.Provisioning.BicepValue<float> RateLimitPercentage { get { throw null; } }
    }
    public enum AbusePenaltyAction
    {
        Throttle = 0,
        Block = 1,
    }
    public partial class CognitiveServicesAccount : Azure.Provisioning.Primitives.Resource
    {
        public CognitiveServicesAccount(string resourceName, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ManagedServiceIdentity> Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.CognitiveServicesAccountProperties> Properties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.CognitiveServicesSku> Sku { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.Authorization.RoleAssignment CreateRoleAssignment(Azure.Provisioning.CognitiveServices.CognitiveServicesBuiltInRole role, Azure.Provisioning.BicepValue<Azure.Provisioning.Authorization.RoleManagementPrincipalType> principalType, Azure.Provisioning.BicepValue<System.Guid> principalId, string? resourceNameSuffix = null) { throw null; }
        public Azure.Provisioning.Authorization.RoleAssignment CreateRoleAssignment(Azure.Provisioning.CognitiveServices.CognitiveServicesBuiltInRole role, Azure.Provisioning.Roles.UserAssignedIdentity identity) { throw null; }
        public static Azure.Provisioning.CognitiveServices.CognitiveServicesAccount FromExisting(string resourceName, string? resourceVersion = null) { throw null; }
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
    public partial class CognitiveServicesAccountDeployment : Azure.Provisioning.Primitives.Resource
    {
        public CognitiveServicesAccountDeployment(string resourceName, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.CognitiveServices.CognitiveServicesAccount? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.CognitiveServicesAccountDeploymentProperties> Properties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.CognitiveServicesSku> Sku { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public static Azure.Provisioning.CognitiveServices.CognitiveServicesAccountDeployment FromExisting(string resourceName, string? resourceVersion = null) { throw null; }
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
    public partial class CognitiveServicesAccountDeploymentModel : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public CognitiveServicesAccountDeploymentModel() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.ServiceAccountCallRateLimit> CallRateLimit { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Format { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Source { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Version { get { throw null; } set { } }
    }
    public partial class CognitiveServicesAccountDeploymentProperties : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public CognitiveServicesAccountDeploymentProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.ServiceAccountCallRateLimit> CallRateLimit { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Capabilities { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.CognitiveServicesAccountDeploymentModel> Model { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.CognitiveServicesAccountDeploymentProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> RaiPolicyName { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CognitiveServices.ServiceAccountThrottlingRule> RateLimits { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.CognitiveServicesAccountDeploymentScaleSettings> ScaleSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.DeploymentModelVersionUpgradeOption> VersionUpgradeOption { get { throw null; } set { } }
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
    public partial class CognitiveServicesAccountDeploymentScaleSettings : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public CognitiveServicesAccountDeploymentScaleSettings() { }
        public Azure.Provisioning.BicepValue<int> ActiveCapacity { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> Capacity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.CognitiveServicesAccountDeploymentScaleType> ScaleType { get { throw null; } set { } }
    }
    public enum CognitiveServicesAccountDeploymentScaleType
    {
        Standard = 0,
        Manual = 1,
    }
    public partial class CognitiveServicesAccountModel : Azure.Provisioning.CognitiveServices.CognitiveServicesAccountDeploymentModel
    {
        public CognitiveServicesAccountModel() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.CognitiveServicesAccountDeploymentModel> BaseModel { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Capabilities { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.ServiceAccountModelDeprecationInfo> Deprecation { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> FinetuneCapabilities { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsDefaultVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.ModelLifecycleStatus> LifecycleStatus { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxCapacity { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CognitiveServices.CognitiveServicesModelSku> Skus { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
    }
    public partial class CognitiveServicesAccountProperties : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public CognitiveServicesAccountProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.AbusePenalty> AbusePenalty { get { throw null; } }
        public Azure.Provisioning.BicepList<string> AllowedFqdnList { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.ServiceAccountApiProperties> ApiProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.ServiceAccountCallRateLimit> CallRateLimit { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CognitiveServices.CognitiveServicesSkuCapability> Capabilities { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CognitiveServices.CommitmentPlanAssociation> CommitmentPlanAssociations { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> CustomSubDomainName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> DeletedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> DisableLocalAuth { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableDynamicThrottling { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.ServiceAccountEncryptionProperties> Encryption { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Endpoint { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Endpoints { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsMigrated { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.CognitiveServicesMultiRegionSettings> Locations { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MigrationToken { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.CognitiveServicesNetworkRuleSet> NetworkAcls { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CognitiveServices.CognitiveServicesPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.ServiceAccountProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.ServiceAccountPublicNetworkAccess> PublicNetworkAccess { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.ServiceAccountQuotaLimit> QuotaLimit { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> Restore { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> RestrictOutboundNetworkAccess { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ScheduledPurgeDate { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.CognitiveServicesSkuChangeInfo> SkuChangeInfo { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CognitiveServices.ServiceAccountUserOwnedStorage> UserOwnedStorage { get { throw null; } set { } }
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
    public partial class CognitiveServicesCapacityConfig : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public CognitiveServicesCapacityConfig() { }
        public Azure.Provisioning.BicepValue<int> Default { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Maximum { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Minimum { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Step { get { throw null; } set { } }
    }
    public partial class CognitiveServicesCommitmentPlan : Azure.Provisioning.Primitives.Resource
    {
        public CognitiveServicesCommitmentPlan(string resourceName, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.CommitmentPlanProperties> Properties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.CognitiveServicesSku> Sku { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public static Azure.Provisioning.CognitiveServices.CognitiveServicesCommitmentPlan FromExisting(string resourceName, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2022_12_01;
            public static readonly string V2023_05_01;
            public static readonly string V2024_10_01;
        }
    }
    public partial class CognitiveServicesIPRule : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public CognitiveServicesIPRule() { }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
    }
    public partial class CognitiveServicesKeyVaultProperties : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public CognitiveServicesKeyVaultProperties() { }
        public Azure.Provisioning.BicepValue<System.Guid> IdentityClientId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> KeyName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> KeyVaultUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> KeyVersion { get { throw null; } set { } }
    }
    public partial class CognitiveServicesModelSku : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public CognitiveServicesModelSku() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.CognitiveServicesCapacityConfig> Capacity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> DeprecationOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CognitiveServices.ServiceAccountCallRateLimit> RateLimits { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> UsageName { get { throw null; } set { } }
    }
    public partial class CognitiveServicesMultiRegionSettings : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public CognitiveServicesMultiRegionSettings() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CognitiveServices.CognitiveServicesRegionSetting> Regions { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.CognitiveServicesRoutingMethod> RoutingMethod { get { throw null; } set { } }
    }
    public enum CognitiveServicesNetworkRuleAction
    {
        Allow = 0,
        Deny = 1,
    }
    public partial class CognitiveServicesNetworkRuleSet : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public CognitiveServicesNetworkRuleSet() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.CognitiveServicesNetworkRuleAction> DefaultAction { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CognitiveServices.CognitiveServicesIPRule> IPRules { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CognitiveServices.CognitiveServicesVirtualNetworkRule> VirtualNetworkRules { get { throw null; } set { } }
    }
    public partial class CognitiveServicesPrivateEndpointConnectionData : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public CognitiveServicesPrivateEndpointConnectionData() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.CognitiveServicesPrivateLinkServiceConnectionState> ConnectionState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepList<string> GroupIds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateEndpointId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.CognitiveServicesPrivateEndpointConnectionProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
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
    public partial class CognitiveServicesPrivateLinkServiceConnectionState : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public CognitiveServicesPrivateLinkServiceConnectionState() { }
        public Azure.Provisioning.BicepValue<string> ActionsRequired { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.CognitiveServicesPrivateEndpointServiceConnectionStatus> Status { get { throw null; } set { } }
    }
    public partial class CognitiveServicesRegionSetting : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public CognitiveServicesRegionSetting() { }
        public Azure.Provisioning.BicepValue<string> Customsubdomain { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<float> Value { get { throw null; } set { } }
    }
    public enum CognitiveServicesRoutingMethod
    {
        Priority = 0,
        Weighted = 1,
        Performance = 2,
    }
    public partial class CognitiveServicesSku : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public CognitiveServicesSku() { }
        public Azure.Provisioning.BicepValue<int> Capacity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Family { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Size { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.CognitiveServicesSkuTier> Tier { get { throw null; } set { } }
    }
    public partial class CognitiveServicesSkuCapability : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public CognitiveServicesSkuCapability() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } }
    }
    public partial class CognitiveServicesSkuChangeInfo : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public CognitiveServicesSkuChangeInfo() { }
        public Azure.Provisioning.BicepValue<float> CountOfDowngrades { get { throw null; } }
        public Azure.Provisioning.BicepValue<float> CountOfUpgradesAfterDowngrades { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastChangedOn { get { throw null; } }
    }
    public enum CognitiveServicesSkuTier
    {
        Free = 0,
        Basic = 1,
        Standard = 2,
        Premium = 3,
        Enterprise = 4,
    }
    public partial class CognitiveServicesVirtualNetworkRule : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public CognitiveServicesVirtualNetworkRule() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IgnoreMissingVnetServiceEndpoint { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> State { get { throw null; } set { } }
    }
    public partial class CommitmentPeriod : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public CommitmentPeriod() { }
        public Azure.Provisioning.BicepValue<int> Count { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> EndOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.CommitmentQuota> Quota { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> StartOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Tier { get { throw null; } set { } }
    }
    public partial class CommitmentPlan : Azure.Provisioning.Primitives.Resource
    {
        public CommitmentPlan(string resourceName, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.CognitiveServices.CognitiveServicesAccount? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.CommitmentPlanProperties> Properties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.CognitiveServicesSku> Sku { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public static Azure.Provisioning.CognitiveServices.CommitmentPlan FromExisting(string resourceName, string? resourceVersion = null) { throw null; }
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
    public partial class CommitmentPlanAccountAssociation : Azure.Provisioning.Primitives.Resource
    {
        public CommitmentPlanAccountAssociation(string resourceName, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> AccountId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.CognitiveServices.CognitiveServicesCommitmentPlan? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public static Azure.Provisioning.CognitiveServices.CommitmentPlanAccountAssociation FromExisting(string resourceName, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2022_12_01;
            public static readonly string V2023_05_01;
            public static readonly string V2024_10_01;
        }
    }
    public partial class CommitmentPlanAssociation : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public CommitmentPlanAssociation() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> CommitmentPlanId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> CommitmentPlanLocation { get { throw null; } }
    }
    public partial class CommitmentPlanProperties : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public CommitmentPlanProperties() { }
        public Azure.Provisioning.BicepValue<bool> AutoRenew { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> CommitmentPlanGuid { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.CommitmentPeriod> Current { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.ServiceAccountHostingModel> HostingModel { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.CommitmentPeriod> Last { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.CommitmentPeriod> Next { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PlanType { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> ProvisioningIssues { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.CommitmentPlanProvisioningState> ProvisioningState { get { throw null; } }
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
    public partial class CommitmentQuota : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public CommitmentQuota() { }
        public Azure.Provisioning.BicepValue<long> Quantity { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Unit { get { throw null; } }
    }
    public enum DeploymentModelVersionUpgradeOption
    {
        OnceNewDefaultVersionAvailable = 0,
        OnceCurrentVersionExpired = 1,
        NoAutoUpgrade = 2,
    }
    public enum ModelLifecycleStatus
    {
        GenerallyAvailable = 0,
        Preview = 1,
    }
    public partial class ServiceAccountApiKeys : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public ServiceAccountApiKeys() { }
        public Azure.Provisioning.BicepValue<string> Key1 { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Key2 { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Provisioning.CognitiveServices.ServiceAccountApiKeys FromExpression(Azure.Provisioning.Expressions.Expression expression) { throw null; }
    }
    public partial class ServiceAccountApiProperties : Azure.Provisioning.Primitives.ProvisioningConstruct
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
    }
    public partial class ServiceAccountCallRateLimit : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public ServiceAccountCallRateLimit() { }
        public Azure.Provisioning.BicepValue<float> Count { get { throw null; } }
        public Azure.Provisioning.BicepValue<float> RenewalPeriod { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CognitiveServices.ServiceAccountThrottlingRule> Rules { get { throw null; } }
    }
    public enum ServiceAccountEncryptionKeySource
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="Microsoft.CognitiveServices")]
        MicrosoftCognitiveServices = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Microsoft.KeyVault")]
        MicrosoftKeyVault = 1,
    }
    public partial class ServiceAccountEncryptionProperties : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public ServiceAccountEncryptionProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.ServiceAccountEncryptionKeySource> KeySource { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.CognitiveServicesKeyVaultProperties> KeyVaultProperties { get { throw null; } set { } }
    }
    public enum ServiceAccountHostingModel
    {
        Web = 0,
        ConnectedContainer = 1,
        DisconnectedContainer = 2,
        ProvisionedWeb = 3,
    }
    public partial class ServiceAccountModelDeprecationInfo : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public ServiceAccountModelDeprecationInfo() { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> FineTuneOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> InferenceOn { get { throw null; } set { } }
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
    public partial class ServiceAccountQuotaLimit : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public ServiceAccountQuotaLimit() { }
        public Azure.Provisioning.BicepValue<float> Count { get { throw null; } }
        public Azure.Provisioning.BicepValue<float> RenewalPeriod { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CognitiveServices.ServiceAccountThrottlingRule> Rules { get { throw null; } }
    }
    public partial class ServiceAccountThrottlingMatchPattern : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public ServiceAccountThrottlingMatchPattern() { }
        public Azure.Provisioning.BicepValue<string> Method { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Path { get { throw null; } }
    }
    public partial class ServiceAccountThrottlingRule : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public ServiceAccountThrottlingRule() { }
        public Azure.Provisioning.BicepValue<float> Count { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsDynamicThrottlingEnabled { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Key { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CognitiveServices.ServiceAccountThrottlingMatchPattern> MatchPatterns { get { throw null; } }
        public Azure.Provisioning.BicepValue<float> MinCount { get { throw null; } }
        public Azure.Provisioning.BicepValue<float> RenewalPeriod { get { throw null; } }
    }
    public partial class ServiceAccountUserOwnedStorage : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public ServiceAccountUserOwnedStorage() { }
        public Azure.Provisioning.BicepValue<System.Guid> IdentityClientId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ResourceId { get { throw null; } set { } }
    }
}
