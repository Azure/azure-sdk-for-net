namespace Azure.Provisioning.Redis
{
    public enum AccessPolicyAssignmentProvisioningState
    {
        Updating = 0,
        Succeeded = 1,
        Deleting = 2,
        Deleted = 3,
        Canceled = 4,
        Failed = 5,
    }
    public enum AccessPolicyProvisioningState
    {
        Updating = 0,
        Succeeded = 1,
        Deleting = 2,
        Deleted = 3,
        Canceled = 4,
        Failed = 5,
    }
    public enum AccessPolicyType
    {
        Custom = 0,
        BuiltIn = 1,
    }
    public partial class RedisAccessKeys : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RedisAccessKeys() { }
        public Azure.Provisioning.BicepValue<string> PrimaryKey { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SecondaryKey { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RedisBuiltInRole : System.IEquatable<Azure.Provisioning.Redis.RedisBuiltInRole>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RedisBuiltInRole(string value) { throw null; }
        public static Azure.Provisioning.Redis.RedisBuiltInRole RedisCacheContributor { get { throw null; } }
        public bool Equals(Azure.Provisioning.Redis.RedisBuiltInRole other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object? obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static string GetBuiltInRoleName(Azure.Provisioning.Redis.RedisBuiltInRole value) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Provisioning.Redis.RedisBuiltInRole left, Azure.Provisioning.Redis.RedisBuiltInRole right) { throw null; }
        public static implicit operator Azure.Provisioning.Redis.RedisBuiltInRole (string value) { throw null; }
        public static bool operator !=(Azure.Provisioning.Redis.RedisBuiltInRole left, Azure.Provisioning.Redis.RedisBuiltInRole right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RedisCacheAccessPolicy : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public RedisCacheAccessPolicy(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Redis.RedisResource? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Permissions { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Redis.AccessPolicyProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Redis.AccessPolicyType> TypePropertiesType { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Redis.RedisCacheAccessPolicy FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2014_04_01;
            public static readonly string V2015_03_01;
            public static readonly string V2015_08_01;
            public static readonly string V2016_04_01;
            public static readonly string V2017_02_01;
            public static readonly string V2017_10_01;
            public static readonly string V2018_03_01;
            public static readonly string V2019_07_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_12_01;
            public static readonly string V2021_06_01;
            public static readonly string V2022_05_01;
            public static readonly string V2022_06_01;
            public static readonly string V2023_04_01;
            public static readonly string V2023_08_01;
            public static readonly string V2024_03_01;
            public static readonly string V2024_11_01;
        }
    }
    public partial class RedisCacheAccessPolicyAssignment : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public RedisCacheAccessPolicyAssignment(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> AccessPolicyName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> ObjectId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ObjectIdAlias { get { throw null; } set { } }
        public Azure.Provisioning.Redis.RedisResource? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Redis.AccessPolicyAssignmentProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Redis.RedisCacheAccessPolicyAssignment FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2014_04_01;
            public static readonly string V2015_03_01;
            public static readonly string V2015_08_01;
            public static readonly string V2016_04_01;
            public static readonly string V2017_02_01;
            public static readonly string V2017_10_01;
            public static readonly string V2018_03_01;
            public static readonly string V2019_07_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_12_01;
            public static readonly string V2021_06_01;
            public static readonly string V2022_05_01;
            public static readonly string V2022_06_01;
            public static readonly string V2023_04_01;
            public static readonly string V2023_08_01;
            public static readonly string V2024_03_01;
            public static readonly string V2024_11_01;
        }
    }
    public partial class RedisCommonConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RedisCommonConfiguration() { }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> AdditionalProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AofStorageConnectionString0 { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AofStorageConnectionString1 { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AuthNotRequired { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> IsAadEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsAofBackupEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsRdbBackupEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MaxClients { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> MaxFragmentationMemoryReserved { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MaxMemoryDelta { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MaxMemoryPolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MaxMemoryReserved { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> NotifyKeyspaceEvents { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PreferredDataArchiveAuthMethod { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> PreferredDataPersistenceAuthMethod { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RdbBackupFrequency { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> RdbBackupMaxSnapshotCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RdbStorageConnectionString { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StorageSubscriptionId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ZonalConfiguration { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum RedisDayOfWeek
    {
        Monday = 0,
        Tuesday = 1,
        Wednesday = 2,
        Thursday = 3,
        Friday = 4,
        Saturday = 5,
        Sunday = 6,
        Everyday = 7,
        Weekend = 8,
    }
    public partial class RedisFirewallRule : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public RedisFirewallRule(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<System.Net.IPAddress> EndIP { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Redis.RedisResource? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Net.IPAddress> StartIP { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Redis.RedisFirewallRule FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2014_04_01;
            public static readonly string V2015_03_01;
            public static readonly string V2015_08_01;
            public static readonly string V2016_04_01;
            public static readonly string V2017_02_01;
            public static readonly string V2017_10_01;
            public static readonly string V2018_03_01;
            public static readonly string V2019_07_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_12_01;
            public static readonly string V2021_06_01;
            public static readonly string V2022_05_01;
            public static readonly string V2022_06_01;
            public static readonly string V2023_04_01;
            public static readonly string V2023_08_01;
            public static readonly string V2024_03_01;
            public static readonly string V2024_11_01;
        }
    }
    public partial class RedisInstanceDetails : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RedisInstanceDetails() { }
        public Azure.Provisioning.BicepValue<bool> IsMaster { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsPrimary { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> NonSslPort { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> ShardId { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> SslPort { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Zone { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum RedisLinkedServerRole
    {
        Primary = 0,
        Secondary = 1,
    }
    public partial class RedisLinkedServerWithProperty : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public RedisLinkedServerWithProperty(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> GeoReplicatedPrimaryHostName { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> LinkedRedisCacheId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> LinkedRedisCacheLocation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Redis.RedisResource? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PrimaryHostName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Redis.RedisLinkedServerRole> ServerRole { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Redis.RedisLinkedServerWithProperty FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2014_04_01;
            public static readonly string V2015_03_01;
            public static readonly string V2015_08_01;
            public static readonly string V2016_04_01;
            public static readonly string V2017_02_01;
            public static readonly string V2017_10_01;
            public static readonly string V2018_03_01;
            public static readonly string V2019_07_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_12_01;
            public static readonly string V2021_06_01;
            public static readonly string V2022_05_01;
            public static readonly string V2022_06_01;
            public static readonly string V2023_04_01;
            public static readonly string V2023_08_01;
            public static readonly string V2024_03_01;
            public static readonly string V2024_11_01;
        }
    }
    public partial class RedisPatchSchedule : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public RedisPatchSchedule(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.Redis.RedisResource? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Redis.RedisPatchScheduleSetting> ScheduleEntries { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Redis.RedisPatchSchedule FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2014_04_01;
            public static readonly string V2015_03_01;
            public static readonly string V2015_08_01;
            public static readonly string V2016_04_01;
            public static readonly string V2017_02_01;
            public static readonly string V2017_10_01;
            public static readonly string V2018_03_01;
            public static readonly string V2019_07_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_12_01;
            public static readonly string V2021_06_01;
            public static readonly string V2022_05_01;
            public static readonly string V2022_06_01;
            public static readonly string V2023_04_01;
            public static readonly string V2023_08_01;
            public static readonly string V2024_03_01;
            public static readonly string V2024_11_01;
        }
    }
    public enum RedisPatchScheduleDefaultName
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="default")]
        Default = 0,
    }
    public partial class RedisPatchScheduleSetting : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RedisPatchScheduleSetting() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Redis.RedisDayOfWeek> DayOfWeek { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> MaintenanceWindow { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> StartHourUtc { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RedisPrivateEndpointConnection : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public RedisPrivateEndpointConnection(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Redis.RedisResource? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateEndpointId { get { throw null; } }
        public Azure.Provisioning.Redis.RedisPrivateLinkServiceConnectionState RedisPrivateLinkServiceConnectionState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Redis.RedisPrivateEndpointConnectionProvisioningState> RedisProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Redis.RedisPrivateEndpointConnection FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2019_07_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_12_01;
            public static readonly string V2021_06_01;
            public static readonly string V2022_05_01;
            public static readonly string V2022_06_01;
            public static readonly string V2023_04_01;
            public static readonly string V2023_08_01;
            public static readonly string V2024_03_01;
            public static readonly string V2024_11_01;
        }
    }
    public partial class RedisPrivateEndpointConnectionData : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RedisPrivateEndpointConnectionData() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateEndpointId { get { throw null; } }
        public Azure.Provisioning.Redis.RedisPrivateLinkServiceConnectionState RedisPrivateLinkServiceConnectionState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Redis.RedisPrivateEndpointConnectionProvisioningState> RedisProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum RedisPrivateEndpointConnectionProvisioningState
    {
        Succeeded = 0,
        Creating = 1,
        Deleting = 2,
        Failed = 3,
    }
    public enum RedisPrivateEndpointServiceConnectionStatus
    {
        Pending = 0,
        Approved = 1,
        Rejected = 2,
    }
    public partial class RedisPrivateLinkServiceConnectionState : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RedisPrivateLinkServiceConnectionState() { }
        public Azure.Provisioning.BicepValue<string> ActionsRequired { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Redis.RedisPrivateEndpointServiceConnectionStatus> Status { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum RedisProvisioningState
    {
        Creating = 0,
        Deleting = 1,
        Disabled = 2,
        Failed = 3,
        Linking = 4,
        Provisioning = 5,
        RecoveringScaleFailure = 6,
        Scaling = 7,
        Succeeded = 8,
        Unlinking = 9,
        Unprovisioning = 10,
        Updating = 11,
        ConfiguringAAD = 12,
    }
    public enum RedisPublicNetworkAccess
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class RedisResource : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public RedisResource(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.Redis.RedisAccessKeys AccessKeys { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> EnableNonSslPort { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> HostName { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Redis.RedisInstanceDetails> Instances { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsAccessKeyAuthenticationDisabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.SubResource> LinkedServers { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Redis.RedisTlsVersion> MinimumTlsVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Port { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Redis.RedisPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Redis.RedisProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Redis.RedisPublicNetworkAccess> PublicNetworkAccess { get { throw null; } set { } }
        public Azure.Provisioning.Redis.RedisCommonConfiguration RedisConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RedisVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> ReplicasPerMaster { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> ReplicasPerPrimary { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> ShardCount { get { throw null; } set { } }
        public Azure.Provisioning.Redis.RedisSku Sku { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> SslPort { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Net.IPAddress> StaticIP { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SubnetId { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> TenantSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Redis.UpdateChannel> UpdateChannel { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Redis.ZonalAllocationPolicy> ZonalAllocationPolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Zones { get { throw null; } set { } }
        public Azure.Provisioning.Authorization.RoleAssignment CreateRoleAssignment(Azure.Provisioning.Redis.RedisBuiltInRole role, Azure.Provisioning.BicepValue<Azure.Provisioning.Authorization.RoleManagementPrincipalType> principalType, Azure.Provisioning.BicepValue<System.Guid> principalId, string? bicepIdentifierSuffix = null) { throw null; }
        public Azure.Provisioning.Authorization.RoleAssignment CreateRoleAssignment(Azure.Provisioning.Redis.RedisBuiltInRole role, Azure.Provisioning.Roles.UserAssignedIdentity identity) { throw null; }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Redis.RedisResource FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public Azure.Provisioning.Redis.RedisAccessKeys GetKeys() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2014_04_01;
            public static readonly string V2015_03_01;
            public static readonly string V2015_08_01;
            public static readonly string V2016_04_01;
            public static readonly string V2017_02_01;
            public static readonly string V2017_10_01;
            public static readonly string V2018_03_01;
            public static readonly string V2019_07_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_12_01;
            public static readonly string V2021_06_01;
            public static readonly string V2022_05_01;
            public static readonly string V2022_06_01;
            public static readonly string V2023_04_01;
            public static readonly string V2023_08_01;
            public static readonly string V2024_03_01;
            public static readonly string V2024_11_01;
        }
    }
    public partial class RedisSku : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RedisSku() { }
        public Azure.Provisioning.BicepValue<int> Capacity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Redis.RedisSkuFamily> Family { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Redis.RedisSkuName> Name { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum RedisSkuFamily
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="C")]
        BasicOrStandard = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="P")]
        Premium = 1,
    }
    public enum RedisSkuName
    {
        Basic = 0,
        Standard = 1,
        Premium = 2,
    }
    public enum RedisTlsVersion
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="1.0")]
        Tls1_0 = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="1.1")]
        Tls1_1 = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="1.2")]
        Tls1_2 = 2,
    }
    public enum UpdateChannel
    {
        Stable = 0,
        Preview = 1,
    }
    public enum ZonalAllocationPolicy
    {
        Automatic = 0,
        UserDefined = 1,
        NoZones = 2,
    }
}
