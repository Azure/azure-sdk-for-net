namespace Azure.Provisioning.RedisEnterprise
{
    public enum AccessKeysAuthentication
    {
        Disabled = 0,
        Enabled = 1,
    }
    public partial class AccessPolicyAssignment : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public AccessPolicyAssignment(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> AccessPolicyName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.RedisEnterprise.RedisEnterpriseDatabase? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RedisEnterprise.RedisEnterpriseProvisioningStatus> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> UserObjectId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.RedisEnterprise.AccessPolicyAssignment FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2021_03_01;
            public static readonly string V2021_08_01;
            public static readonly string V2022_01_01;
            public static readonly string V2023_07_01;
            public static readonly string V2023_11_01;
            public static readonly string V2024_02_01;
            public static readonly string V2024_10_01;
            public static readonly string V2025_04_01;
        }
    }
    public enum DeferUpgradeSetting
    {
        Deferred = 0,
        NotDeferred = 1,
    }
    public enum PersistenceSettingAofFrequency
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="1s")]
        OneSecond = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="always")]
        Always = 1,
    }
    public enum PersistenceSettingRdbFrequency
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="1h")]
        OneHour = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="6h")]
        SixHours = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="12h")]
        TwelveHours = 2,
    }
    public enum RedisEnterpriseClientProtocol
    {
        Encrypted = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Plaintext")]
        PlainText = 1,
    }
    public partial class RedisEnterpriseCluster : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public RedisEnterpriseCluster(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.RedisEnterprise.RedisEnterpriseCustomerManagedKeyEncryption CustomerManagedKeyEncryption { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RedisEnterprise.RedisEnterpriseHighAvailability> HighAvailability { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> HostName { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RedisEnterprise.RedisEnterpriseKind> Kind { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RedisEnterprise.RedisEnterpriseTlsVersion> MinimumTlsVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.RedisEnterprise.RedisEnterprisePrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RedisEnterprise.RedisEnterpriseProvisioningStatus> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> RedisVersion { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RedisEnterprise.RedisEnterpriseRedundancyMode> RedundancyMode { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RedisEnterprise.RedisEnterpriseClusterResourceState> ResourceState { get { throw null; } }
        public Azure.Provisioning.RedisEnterprise.RedisEnterpriseSku Sku { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Zones { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.RedisEnterprise.RedisEnterpriseCluster FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2021_03_01;
            public static readonly string V2021_08_01;
            public static readonly string V2022_01_01;
            public static readonly string V2023_07_01;
            public static readonly string V2023_11_01;
            public static readonly string V2024_02_01;
            public static readonly string V2024_10_01;
            public static readonly string V2025_04_01;
        }
    }
    public enum RedisEnterpriseClusteringPolicy
    {
        EnterpriseCluster = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="OSSCluster")]
        OssCluster = 1,
    }
    public enum RedisEnterpriseClusterResourceState
    {
        Running = 0,
        Creating = 1,
        CreateFailed = 2,
        Updating = 3,
        UpdateFailed = 4,
        Deleting = 5,
        DeleteFailed = 6,
        Enabling = 7,
        EnableFailed = 8,
        Disabling = 9,
        DisableFailed = 10,
        Disabled = 11,
        Scaling = 12,
        ScalingFailed = 13,
        Moving = 14,
    }
    public partial class RedisEnterpriseCustomerManagedKeyEncryption : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RedisEnterpriseCustomerManagedKeyEncryption() { }
        public Azure.Provisioning.RedisEnterprise.RedisEnterpriseCustomerManagedKeyEncryptionKeyIdentity KeyEncryptionKeyIdentity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> KeyEncryptionKeyUri { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RedisEnterpriseCustomerManagedKeyEncryptionKeyIdentity : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RedisEnterpriseCustomerManagedKeyEncryptionKeyIdentity() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RedisEnterprise.RedisEnterpriseCustomerManagedKeyIdentityType> IdentityType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> UserAssignedIdentityResourceId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum RedisEnterpriseCustomerManagedKeyIdentityType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="systemAssignedIdentity")]
        SystemAssignedIdentity = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="userAssignedIdentity")]
        UserAssignedIdentity = 1,
    }
    public partial class RedisEnterpriseDataAccessKeys : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RedisEnterpriseDataAccessKeys() { }
        public Azure.Provisioning.BicepValue<string> PrimaryKey { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SecondaryKey { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RedisEnterpriseDatabase : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public RedisEnterpriseDatabase(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RedisEnterprise.AccessKeysAuthentication> AccessKeysAuthentication { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RedisEnterprise.RedisEnterpriseClientProtocol> ClientProtocol { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RedisEnterprise.RedisEnterpriseClusteringPolicy> ClusteringPolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RedisEnterprise.DeferUpgradeSetting> DeferUpgrade { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RedisEnterprise.RedisEnterpriseEvictionPolicy> EvictionPolicy { get { throw null; } set { } }
        public Azure.Provisioning.RedisEnterprise.RedisEnterpriseDatabaseGeoReplication GeoReplication { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.RedisEnterprise.RedisEnterpriseModule> Modules { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.RedisEnterprise.RedisEnterpriseCluster? Parent { get { throw null; } set { } }
        public Azure.Provisioning.RedisEnterprise.RedisPersistenceSettings Persistence { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Port { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RedisEnterprise.RedisEnterpriseProvisioningStatus> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> RedisVersion { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RedisEnterprise.RedisEnterpriseClusterResourceState> ResourceState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.RedisEnterprise.RedisEnterpriseDatabase FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public Azure.Provisioning.RedisEnterprise.RedisEnterpriseDataAccessKeys GetKeys() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2021_03_01;
            public static readonly string V2021_08_01;
            public static readonly string V2022_01_01;
            public static readonly string V2023_07_01;
            public static readonly string V2023_11_01;
            public static readonly string V2024_02_01;
            public static readonly string V2024_10_01;
            public static readonly string V2025_04_01;
        }
    }
    public partial class RedisEnterpriseDatabaseGeoReplication : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RedisEnterpriseDatabaseGeoReplication() { }
        public Azure.Provisioning.BicepValue<string> GroupNickname { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.RedisEnterprise.RedisEnterpriseLinkedDatabase> LinkedDatabases { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum RedisEnterpriseDatabaseLinkState
    {
        Linked = 0,
        Linking = 1,
        Unlinking = 2,
        LinkFailed = 3,
        UnlinkFailed = 4,
    }
    public enum RedisEnterpriseEvictionPolicy
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="AllKeysLFU")]
        AllKeysLfu = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="AllKeysLRU")]
        AllKeysLru = 1,
        AllKeysRandom = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="VolatileLRU")]
        VolatileLru = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="VolatileLFU")]
        VolatileLfu = 4,
        [System.Runtime.Serialization.DataMemberAttribute(Name="VolatileTTL")]
        VolatileTtl = 5,
        VolatileRandom = 6,
        NoEviction = 7,
    }
    public enum RedisEnterpriseHighAvailability
    {
        Enabled = 0,
        Disabled = 1,
    }
    public enum RedisEnterpriseKind
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="v1")]
        V1 = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="v2")]
        V2 = 1,
    }
    public partial class RedisEnterpriseLinkedDatabase : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RedisEnterpriseLinkedDatabase() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RedisEnterprise.RedisEnterpriseDatabaseLinkState> State { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RedisEnterpriseModule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RedisEnterpriseModule() { }
        public Azure.Provisioning.BicepValue<string> Args { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Version { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RedisEnterprisePrivateEndpointConnection : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public RedisEnterprisePrivateEndpointConnection(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.RedisEnterprise.RedisEnterprisePrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.RedisEnterprise.RedisEnterpriseCluster? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateEndpointId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RedisEnterprise.RedisEnterprisePrivateEndpointConnectionProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.RedisEnterprise.RedisEnterprisePrivateEndpointConnection FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2021_03_01;
            public static readonly string V2021_08_01;
            public static readonly string V2022_01_01;
            public static readonly string V2023_07_01;
            public static readonly string V2023_11_01;
            public static readonly string V2024_02_01;
            public static readonly string V2024_10_01;
            public static readonly string V2025_04_01;
        }
    }
    public partial class RedisEnterprisePrivateEndpointConnectionData : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RedisEnterprisePrivateEndpointConnectionData() { }
        public Azure.Provisioning.RedisEnterprise.RedisEnterprisePrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateEndpointId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RedisEnterprise.RedisEnterprisePrivateEndpointConnectionProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum RedisEnterprisePrivateEndpointConnectionProvisioningState
    {
        Succeeded = 0,
        Creating = 1,
        Deleting = 2,
        Failed = 3,
    }
    public enum RedisEnterprisePrivateEndpointServiceConnectionStatus
    {
        Pending = 0,
        Approved = 1,
        Rejected = 2,
    }
    public partial class RedisEnterprisePrivateLinkServiceConnectionState : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RedisEnterprisePrivateLinkServiceConnectionState() { }
        public Azure.Provisioning.BicepValue<string> ActionsRequired { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RedisEnterprise.RedisEnterprisePrivateEndpointServiceConnectionStatus> Status { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum RedisEnterpriseProvisioningStatus
    {
        Succeeded = 0,
        Failed = 1,
        Canceled = 2,
        Creating = 3,
        Updating = 4,
        Deleting = 5,
    }
    public enum RedisEnterpriseRedundancyMode
    {
        None = 0,
        LR = 1,
        ZR = 2,
    }
    public partial class RedisEnterpriseSku : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RedisEnterpriseSku() { }
        public Azure.Provisioning.BicepValue<int> Capacity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RedisEnterprise.RedisEnterpriseSkuName> Name { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum RedisEnterpriseSkuName
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="Enterprise_E1")]
        EnterpriseE1 = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Enterprise_E5")]
        EnterpriseE5 = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Enterprise_E10")]
        EnterpriseE10 = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Enterprise_E20")]
        EnterpriseE20 = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Enterprise_E50")]
        EnterpriseE50 = 4,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Enterprise_E100")]
        EnterpriseE100 = 5,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Enterprise_E200")]
        EnterpriseE200 = 6,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Enterprise_E400")]
        EnterpriseE400 = 7,
        [System.Runtime.Serialization.DataMemberAttribute(Name="EnterpriseFlash_F300")]
        EnterpriseFlashF300 = 8,
        [System.Runtime.Serialization.DataMemberAttribute(Name="EnterpriseFlash_F700")]
        EnterpriseFlashF700 = 9,
        [System.Runtime.Serialization.DataMemberAttribute(Name="EnterpriseFlash_F1500")]
        EnterpriseFlashF1500 = 10,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Balanced_B0")]
        BalancedB0 = 11,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Balanced_B1")]
        BalancedB1 = 12,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Balanced_B3")]
        BalancedB3 = 13,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Balanced_B5")]
        BalancedB5 = 14,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Balanced_B10")]
        BalancedB10 = 15,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Balanced_B20")]
        BalancedB20 = 16,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Balanced_B50")]
        BalancedB50 = 17,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Balanced_B100")]
        BalancedB100 = 18,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Balanced_B150")]
        BalancedB150 = 19,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Balanced_B250")]
        BalancedB250 = 20,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Balanced_B350")]
        BalancedB350 = 21,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Balanced_B500")]
        BalancedB500 = 22,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Balanced_B700")]
        BalancedB700 = 23,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Balanced_B1000")]
        BalancedB1000 = 24,
        [System.Runtime.Serialization.DataMemberAttribute(Name="MemoryOptimized_M10")]
        MemoryOptimizedM10 = 25,
        [System.Runtime.Serialization.DataMemberAttribute(Name="MemoryOptimized_M20")]
        MemoryOptimizedM20 = 26,
        [System.Runtime.Serialization.DataMemberAttribute(Name="MemoryOptimized_M50")]
        MemoryOptimizedM50 = 27,
        [System.Runtime.Serialization.DataMemberAttribute(Name="MemoryOptimized_M100")]
        MemoryOptimizedM100 = 28,
        [System.Runtime.Serialization.DataMemberAttribute(Name="MemoryOptimized_M150")]
        MemoryOptimizedM150 = 29,
        [System.Runtime.Serialization.DataMemberAttribute(Name="MemoryOptimized_M250")]
        MemoryOptimizedM250 = 30,
        [System.Runtime.Serialization.DataMemberAttribute(Name="MemoryOptimized_M350")]
        MemoryOptimizedM350 = 31,
        [System.Runtime.Serialization.DataMemberAttribute(Name="MemoryOptimized_M500")]
        MemoryOptimizedM500 = 32,
        [System.Runtime.Serialization.DataMemberAttribute(Name="MemoryOptimized_M700")]
        MemoryOptimizedM700 = 33,
        [System.Runtime.Serialization.DataMemberAttribute(Name="MemoryOptimized_M1000")]
        MemoryOptimizedM1000 = 34,
        [System.Runtime.Serialization.DataMemberAttribute(Name="MemoryOptimized_M1500")]
        MemoryOptimizedM1500 = 35,
        [System.Runtime.Serialization.DataMemberAttribute(Name="MemoryOptimized_M2000")]
        MemoryOptimizedM2000 = 36,
        [System.Runtime.Serialization.DataMemberAttribute(Name="ComputeOptimized_X3")]
        ComputeOptimizedX3 = 37,
        [System.Runtime.Serialization.DataMemberAttribute(Name="ComputeOptimized_X5")]
        ComputeOptimizedX5 = 38,
        [System.Runtime.Serialization.DataMemberAttribute(Name="ComputeOptimized_X10")]
        ComputeOptimizedX10 = 39,
        [System.Runtime.Serialization.DataMemberAttribute(Name="ComputeOptimized_X20")]
        ComputeOptimizedX20 = 40,
        [System.Runtime.Serialization.DataMemberAttribute(Name="ComputeOptimized_X50")]
        ComputeOptimizedX50 = 41,
        [System.Runtime.Serialization.DataMemberAttribute(Name="ComputeOptimized_X100")]
        ComputeOptimizedX100 = 42,
        [System.Runtime.Serialization.DataMemberAttribute(Name="ComputeOptimized_X150")]
        ComputeOptimizedX150 = 43,
        [System.Runtime.Serialization.DataMemberAttribute(Name="ComputeOptimized_X250")]
        ComputeOptimizedX250 = 44,
        [System.Runtime.Serialization.DataMemberAttribute(Name="ComputeOptimized_X350")]
        ComputeOptimizedX350 = 45,
        [System.Runtime.Serialization.DataMemberAttribute(Name="ComputeOptimized_X500")]
        ComputeOptimizedX500 = 46,
        [System.Runtime.Serialization.DataMemberAttribute(Name="ComputeOptimized_X700")]
        ComputeOptimizedX700 = 47,
        [System.Runtime.Serialization.DataMemberAttribute(Name="FlashOptimized_A250")]
        FlashOptimizedA250 = 48,
        [System.Runtime.Serialization.DataMemberAttribute(Name="FlashOptimized_A500")]
        FlashOptimizedA500 = 49,
        [System.Runtime.Serialization.DataMemberAttribute(Name="FlashOptimized_A700")]
        FlashOptimizedA700 = 50,
        [System.Runtime.Serialization.DataMemberAttribute(Name="FlashOptimized_A1000")]
        FlashOptimizedA1000 = 51,
        [System.Runtime.Serialization.DataMemberAttribute(Name="FlashOptimized_A1500")]
        FlashOptimizedA1500 = 52,
        [System.Runtime.Serialization.DataMemberAttribute(Name="FlashOptimized_A2000")]
        FlashOptimizedA2000 = 53,
        [System.Runtime.Serialization.DataMemberAttribute(Name="FlashOptimized_A4500")]
        FlashOptimizedA4500 = 54,
    }
    public enum RedisEnterpriseTlsVersion
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="1.0")]
        Tls1_0 = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="1.1")]
        Tls1_1 = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="1.2")]
        Tls1_2 = 2,
    }
    public partial class RedisPersistenceSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RedisPersistenceSettings() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RedisEnterprise.PersistenceSettingAofFrequency> AofFrequency { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsAofEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsRdbEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RedisEnterprise.PersistenceSettingRdbFrequency> RdbFrequency { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
}
