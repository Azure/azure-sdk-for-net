namespace Azure.Provisioning.EventHubs
{
    public partial class CaptureDescription : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CaptureDescription() { }
        public Azure.Provisioning.EventHubs.EventHubDestination Destination { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> Enabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventHubs.EncodingCaptureDescription> Encoding { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> IntervalInSeconds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> SizeLimitInBytes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> SkipEmptyArchives { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum CleanupPolicyRetentionDescription
    {
        Delete = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Compact")]
        Compaction = 1,
    }
    public enum EncodingCaptureDescription
    {
        Avro = 0,
        AvroDeflate = 1,
    }
    public partial class EventHub : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public EventHub(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.EventHubs.CaptureDescription CaptureDescription { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.EventHubs.EventHubsNamespace? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> PartitionCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> PartitionIds { get { throw null; } }
        public Azure.Provisioning.EventHubs.RetentionDescription RetentionDescription { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventHubs.EventHubEntityStatus> Status { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> UpdatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> UserMetadata { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.EventHubs.EventHub FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2014_09_01;
            public static readonly string V2015_08_01;
            public static readonly string V2017_04_01;
            public static readonly string V2021_11_01;
            public static readonly string V2024_01_01;
        }
    }
    public partial class EventHubAuthorizationRule : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public EventHubAuthorizationRule(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.EventHubs.EventHub? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.EventHubs.EventHubsAccessRight> Rights { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.EventHubs.EventHubAuthorizationRule FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public Azure.Provisioning.EventHubs.EventHubsAccessKeys GetKeys() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2014_09_01;
            public static readonly string V2015_08_01;
            public static readonly string V2017_04_01;
            public static readonly string V2021_11_01;
            public static readonly string V2024_01_01;
        }
    }
    public partial class EventHubDestination : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public EventHubDestination() { }
        public Azure.Provisioning.BicepValue<string> ArchiveNameFormat { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> BlobContainer { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DataLakeAccountName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DataLakeFolderPath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> DataLakeSubscriptionId { get { throw null; } set { } }
        public Azure.Provisioning.EventHubs.EventHubsCaptureIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> StorageAccountResourceId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum EventHubEntityStatus
    {
        Unknown = 0,
        Active = 1,
        Disabled = 2,
        Restoring = 3,
        SendDisabled = 4,
        ReceiveDisabled = 5,
        Creating = 6,
        Deleting = 7,
        Renaming = 8,
    }
    public partial class EventHubsAccessKeys : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public EventHubsAccessKeys() { }
        public Azure.Provisioning.BicepValue<string> AliasPrimaryConnectionString { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> AliasSecondaryConnectionString { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> KeyName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> PrimaryConnectionString { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> PrimaryKey { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SecondaryConnectionString { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SecondaryKey { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum EventHubsAccessRight
    {
        Manage = 0,
        Send = 1,
        Listen = 2,
    }
    public partial class EventHubsApplicationGroup : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public EventHubsApplicationGroup(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> ClientAppGroupIdentifier { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.EventHubs.EventHubsNamespace? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.EventHubs.EventHubsApplicationGroupPolicy> Policies { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.EventHubs.EventHubsApplicationGroup FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_01_01;
        }
    }
    public partial class EventHubsApplicationGroupPolicy : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public EventHubsApplicationGroupPolicy() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EventHubsBuiltInRole : System.IEquatable<Azure.Provisioning.EventHubs.EventHubsBuiltInRole>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EventHubsBuiltInRole(string value) { throw null; }
        public static Azure.Provisioning.EventHubs.EventHubsBuiltInRole AzureEventHubsDataOwner { get { throw null; } }
        public static Azure.Provisioning.EventHubs.EventHubsBuiltInRole AzureEventHubsDataReceiver { get { throw null; } }
        public static Azure.Provisioning.EventHubs.EventHubsBuiltInRole AzureEventHubsDataSender { get { throw null; } }
        public static Azure.Provisioning.EventHubs.EventHubsBuiltInRole SchemaRegistryContributor { get { throw null; } }
        public static Azure.Provisioning.EventHubs.EventHubsBuiltInRole SchemaRegistryReader { get { throw null; } }
        public bool Equals(Azure.Provisioning.EventHubs.EventHubsBuiltInRole other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object? obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static string GetBuiltInRoleName(Azure.Provisioning.EventHubs.EventHubsBuiltInRole value) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Provisioning.EventHubs.EventHubsBuiltInRole left, Azure.Provisioning.EventHubs.EventHubsBuiltInRole right) { throw null; }
        public static implicit operator Azure.Provisioning.EventHubs.EventHubsBuiltInRole (string value) { throw null; }
        public static bool operator !=(Azure.Provisioning.EventHubs.EventHubsBuiltInRole left, Azure.Provisioning.EventHubs.EventHubsBuiltInRole right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EventHubsCaptureIdentity : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public EventHubsCaptureIdentity() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventHubs.EventHubsCaptureIdentityType> IdentityType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> UserAssignedIdentity { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum EventHubsCaptureIdentityType
    {
        SystemAssigned = 0,
        UserAssigned = 1,
    }
    public partial class EventHubsCluster : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public EventHubsCluster(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MetricId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventHubs.EventHubsClusterProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.EventHubs.EventHubsClusterSku Sku { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Status { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> SupportsScaling { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> UpdatedOn { get { throw null; } }
        public Azure.Provisioning.Authorization.RoleAssignment CreateRoleAssignment(Azure.Provisioning.EventHubs.EventHubsBuiltInRole role, Azure.Provisioning.BicepValue<Azure.Provisioning.Authorization.RoleManagementPrincipalType> principalType, Azure.Provisioning.BicepValue<System.Guid> principalId, string? bicepIdentifierSuffix = null) { throw null; }
        public Azure.Provisioning.Authorization.RoleAssignment CreateRoleAssignment(Azure.Provisioning.EventHubs.EventHubsBuiltInRole role, Azure.Provisioning.Roles.UserAssignedIdentity identity) { throw null; }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.EventHubs.EventHubsCluster FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2021_11_01;
            public static readonly string V2024_01_01;
        }
    }
    public enum EventHubsClusterProvisioningState
    {
        Unknown = 0,
        Creating = 1,
        Deleting = 2,
        Scaling = 3,
        Active = 4,
        Failed = 5,
        Succeeded = 6,
        Canceled = 7,
    }
    public partial class EventHubsClusterSku : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public EventHubsClusterSku() { }
        public Azure.Provisioning.BicepValue<int> Capacity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventHubs.EventHubsClusterSkuName> Name { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum EventHubsClusterSkuName
    {
        Dedicated = 0,
    }
    public partial class EventHubsConsumerGroup : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public EventHubsConsumerGroup(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.EventHubs.EventHub? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> UpdatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> UserMetadata { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.EventHubs.EventHubsConsumerGroup FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2014_09_01;
            public static readonly string V2015_08_01;
            public static readonly string V2017_04_01;
            public static readonly string V2021_11_01;
            public static readonly string V2024_01_01;
        }
    }
    public partial class EventHubsDisasterRecovery : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public EventHubsDisasterRecovery(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> AlternateName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.EventHubs.EventHubsNamespace? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PartnerNamespace { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> PendingReplicationOperationsCount { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventHubs.EventHubsDisasterRecoveryProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventHubs.EventHubsDisasterRecoveryRole> Role { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.EventHubs.EventHubsDisasterRecovery FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2017_04_01;
            public static readonly string V2021_11_01;
            public static readonly string V2024_01_01;
        }
    }
    public enum EventHubsDisasterRecoveryProvisioningState
    {
        Accepted = 0,
        Succeeded = 1,
        Failed = 2,
    }
    public enum EventHubsDisasterRecoveryRole
    {
        Primary = 0,
        PrimaryNotReplicating = 1,
        Secondary = 2,
    }
    public partial class EventHubsEncryption : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public EventHubsEncryption() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventHubs.EventHubsKeySource> KeySource { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.EventHubs.EventHubsKeyVaultProperties> KeyVaultProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> RequireInfrastructureEncryption { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum EventHubsKeySource
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="Microsoft.KeyVault")]
        MicrosoftKeyVault = 0,
    }
    public partial class EventHubsKeyVaultProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public EventHubsKeyVaultProperties() { }
        public Azure.Provisioning.BicepValue<string> KeyName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> KeyVaultUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> KeyVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> UserAssignedIdentity { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum EventHubsMetricId
    {
        IncomingBytes = 0,
        OutgoingBytes = 1,
        IncomingMessages = 2,
        OutgoingMessages = 3,
    }
    public partial class EventHubsNamespace : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public EventHubsNamespace(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> AlternateName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ClusterArmId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> DisableLocalAuth { get { throw null; } set { } }
        public Azure.Provisioning.EventHubs.EventHubsEncryption Encryption { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.Provisioning.EventHubs.NamespaceGeoDataReplicationProperties GeoDataReplication { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsAutoInflateEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> KafkaEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaximumThroughputUnits { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MetricId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventHubs.EventHubsTlsVersion> MinimumTlsVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.EventHubs.EventHubsPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventHubs.EventHubsPublicNetworkAccess> PublicNetworkAccess { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServiceBusEndpoint { get { throw null; } }
        public Azure.Provisioning.EventHubs.EventHubsSku Sku { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Status { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> UpdatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> ZoneRedundant { get { throw null; } set { } }
        public Azure.Provisioning.Authorization.RoleAssignment CreateRoleAssignment(Azure.Provisioning.EventHubs.EventHubsBuiltInRole role, Azure.Provisioning.BicepValue<Azure.Provisioning.Authorization.RoleManagementPrincipalType> principalType, Azure.Provisioning.BicepValue<System.Guid> principalId, string? bicepIdentifierSuffix = null) { throw null; }
        public Azure.Provisioning.Authorization.RoleAssignment CreateRoleAssignment(Azure.Provisioning.EventHubs.EventHubsBuiltInRole role, Azure.Provisioning.Roles.UserAssignedIdentity identity) { throw null; }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.EventHubs.EventHubsNamespace FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2014_09_01;
            public static readonly string V2015_08_01;
            public static readonly string V2017_04_01;
            public static readonly string V2021_11_01;
            public static readonly string V2024_01_01;
        }
    }
    public partial class EventHubsNamespaceAuthorizationRule : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public EventHubsNamespaceAuthorizationRule(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.EventHubs.EventHubsNamespace? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.EventHubs.EventHubsAccessRight> Rights { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.EventHubs.EventHubsNamespaceAuthorizationRule FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public Azure.Provisioning.EventHubs.EventHubsAccessKeys GetKeys() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2014_09_01;
            public static readonly string V2015_08_01;
            public static readonly string V2017_04_01;
            public static readonly string V2021_11_01;
            public static readonly string V2024_01_01;
        }
    }
    public enum EventHubsNetworkRuleIPAction
    {
        Allow = 0,
    }
    public partial class EventHubsNetworkRuleSet : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public EventHubsNetworkRuleSet(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventHubs.EventHubsNetworkRuleSetDefaultAction> DefaultAction { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.EventHubs.EventHubsNetworkRuleSetIPRules> IPRules { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.EventHubs.EventHubsNamespace? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventHubs.EventHubsPublicNetworkAccessFlag> PublicNetworkAccess { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> TrustedServiceAccessEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.EventHubs.EventHubsNetworkRuleSetVirtualNetworkRules> VirtualNetworkRules { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.EventHubs.EventHubsNetworkRuleSet FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2017_04_01;
            public static readonly string V2021_11_01;
            public static readonly string V2024_01_01;
        }
    }
    public enum EventHubsNetworkRuleSetDefaultAction
    {
        Allow = 0,
        Deny = 1,
    }
    public partial class EventHubsNetworkRuleSetIPRules : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public EventHubsNetworkRuleSetIPRules() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventHubs.EventHubsNetworkRuleIPAction> Action { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> IPMask { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class EventHubsNetworkRuleSetVirtualNetworkRules : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public EventHubsNetworkRuleSetVirtualNetworkRules() { }
        public Azure.Provisioning.BicepValue<bool> IgnoreMissingVnetServiceEndpoint { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SubnetId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class EventHubsPrivateEndpointConnection : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public EventHubsPrivateEndpointConnection(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.EventHubs.EventHubsPrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.EventHubs.EventHubsNamespace? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateEndpointId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventHubs.EventHubsPrivateEndpointConnectionProvisioningState> ProvisioningState { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.EventHubs.EventHubsPrivateEndpointConnection FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2021_11_01;
            public static readonly string V2024_01_01;
        }
    }
    public partial class EventHubsPrivateEndpointConnectionData : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public EventHubsPrivateEndpointConnectionData() { }
        public Azure.Provisioning.EventHubs.EventHubsPrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateEndpointId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventHubs.EventHubsPrivateEndpointConnectionProvisioningState> ProvisioningState { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum EventHubsPrivateEndpointConnectionProvisioningState
    {
        Creating = 0,
        Updating = 1,
        Deleting = 2,
        Succeeded = 3,
        Canceled = 4,
        Failed = 5,
    }
    public enum EventHubsPrivateLinkConnectionStatus
    {
        Pending = 0,
        Approved = 1,
        Rejected = 2,
        Disconnected = 3,
    }
    public partial class EventHubsPrivateLinkServiceConnectionState : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public EventHubsPrivateLinkServiceConnectionState() { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventHubs.EventHubsPrivateLinkConnectionStatus> Status { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum EventHubsPublicNetworkAccess
    {
        Enabled = 0,
        Disabled = 1,
        SecuredByPerimeter = 2,
    }
    public enum EventHubsPublicNetworkAccessFlag
    {
        Enabled = 0,
        Disabled = 1,
        SecuredByPerimeter = 2,
    }
    public enum EventHubsSchemaCompatibility
    {
        None = 0,
        Backward = 1,
        Forward = 2,
    }
    public partial class EventHubsSchemaGroup : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public EventHubsSchemaGroup(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedAtUtc { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> GroupProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.EventHubs.EventHubsNamespace? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventHubs.EventHubsSchemaCompatibility> SchemaCompatibility { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventHubs.EventHubsSchemaType> SchemaType { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> UpdatedAtUtc { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.EventHubs.EventHubsSchemaGroup FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2014_09_01;
            public static readonly string V2015_08_01;
            public static readonly string V2017_04_01;
            public static readonly string V2021_11_01;
            public static readonly string V2024_01_01;
        }
    }
    public enum EventHubsSchemaType
    {
        Unknown = 0,
        Avro = 1,
    }
    public partial class EventHubsSku : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public EventHubsSku() { }
        public Azure.Provisioning.BicepValue<int> Capacity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventHubs.EventHubsSkuName> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventHubs.EventHubsSkuTier> Tier { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum EventHubsSkuName
    {
        Basic = 0,
        Standard = 1,
        Premium = 2,
    }
    public enum EventHubsSkuTier
    {
        Basic = 0,
        Standard = 1,
        Premium = 2,
    }
    public partial class EventHubsThrottlingPolicy : Azure.Provisioning.EventHubs.EventHubsApplicationGroupPolicy
    {
        public EventHubsThrottlingPolicy() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventHubs.EventHubsMetricId> MetricId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> RateLimitThreshold { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum EventHubsTlsVersion
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="1.0")]
        Tls1_0 = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="1.1")]
        Tls1_1 = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="1.2")]
        Tls1_2 = 2,
    }
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class NamespaceGeoDataReplicationProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public NamespaceGeoDataReplicationProperties() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.EventHubs.NamespaceReplicaLocation> Locations { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxReplicationLagDurationInSeconds { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    public enum NamespaceGeoDRRoleType
    {
        Primary = 0,
        Secondary = 1,
    }
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class NamespaceReplicaLocation : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public NamespaceReplicaLocation() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ClusterArmId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> LocationName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventHubs.NamespaceGeoDRRoleType> RoleType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RetentionDescription : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RetentionDescription() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventHubs.CleanupPolicyRetentionDescription> CleanupPolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> RetentionTimeInHours { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> TombstoneRetentionTimeInHours { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
}
