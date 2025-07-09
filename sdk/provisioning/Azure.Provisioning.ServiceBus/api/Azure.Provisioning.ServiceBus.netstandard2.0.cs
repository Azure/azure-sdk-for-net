namespace Azure.Provisioning.ServiceBus
{
    public partial class MessageCountDetails : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MessageCountDetails() { }
        public Azure.Provisioning.BicepValue<long> ActiveMessageCount { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> DeadLetterMessageCount { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> ScheduledMessageCount { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> TransferDeadLetterMessageCount { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> TransferMessageCount { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MigrationConfiguration : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public MigrationConfiguration(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> MigrationState { get { throw null; } }
        public Azure.Provisioning.ServiceBus.ServiceBusNamespace? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> PendingReplicationOperationsCount { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> PostMigrationName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> TargetServiceBusNamespace { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ServiceBus.MigrationConfiguration FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2017_04_01;
            public static readonly string V2021_11_01;
            public static readonly string V2024_01_01;
        }
    }
    public enum MigrationConfigurationName
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="$default")]
        Default = 0,
    }
    public partial class ServiceBusAccessKeys : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ServiceBusAccessKeys() { }
        public Azure.Provisioning.BicepValue<string> AliasPrimaryConnectionString { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> AliasSecondaryConnectionString { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> KeyName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> PrimaryConnectionString { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> PrimaryKey { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SecondaryConnectionString { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SecondaryKey { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ServiceBusAccessRight
    {
        Manage = 0,
        Send = 1,
        Listen = 2,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServiceBusBuiltInRole : System.IEquatable<Azure.Provisioning.ServiceBus.ServiceBusBuiltInRole>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServiceBusBuiltInRole(string value) { throw null; }
        public static Azure.Provisioning.ServiceBus.ServiceBusBuiltInRole AzureServiceBusDataOwner { get { throw null; } }
        public static Azure.Provisioning.ServiceBus.ServiceBusBuiltInRole AzureServiceBusDataReceiver { get { throw null; } }
        public static Azure.Provisioning.ServiceBus.ServiceBusBuiltInRole AzureServiceBusDataSender { get { throw null; } }
        public bool Equals(Azure.Provisioning.ServiceBus.ServiceBusBuiltInRole other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object? obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static string GetBuiltInRoleName(Azure.Provisioning.ServiceBus.ServiceBusBuiltInRole value) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Provisioning.ServiceBus.ServiceBusBuiltInRole left, Azure.Provisioning.ServiceBus.ServiceBusBuiltInRole right) { throw null; }
        public static implicit operator Azure.Provisioning.ServiceBus.ServiceBusBuiltInRole (string value) { throw null; }
        public static bool operator !=(Azure.Provisioning.ServiceBus.ServiceBusBuiltInRole left, Azure.Provisioning.ServiceBus.ServiceBusBuiltInRole right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ServiceBusClientAffineProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ServiceBusClientAffineProperties() { }
        public Azure.Provisioning.BicepValue<string> ClientId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsDurable { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsShared { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ServiceBusCorrelationFilter : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ServiceBusCorrelationFilter() { }
        public Azure.Provisioning.BicepDictionary<object> ApplicationProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ContentType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CorrelationId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MessageId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ReplyTo { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ReplyToSessionId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> RequiresPreprocessing { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SendTo { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SessionId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Subject { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ServiceBusDisasterRecovery : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ServiceBusDisasterRecovery(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> AlternateName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.ServiceBus.ServiceBusNamespace? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PartnerNamespace { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> PendingReplicationOperationsCount { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ServiceBus.ServiceBusDisasterRecoveryProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ServiceBus.ServiceBusDisasterRecoveryRole> Role { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ServiceBus.ServiceBusDisasterRecovery FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2017_04_01;
            public static readonly string V2021_11_01;
            public static readonly string V2024_01_01;
        }
    }
    public enum ServiceBusDisasterRecoveryProvisioningState
    {
        Accepted = 0,
        Succeeded = 1,
        Failed = 2,
    }
    public enum ServiceBusDisasterRecoveryRole
    {
        Primary = 0,
        PrimaryNotReplicating = 1,
        Secondary = 2,
    }
    public partial class ServiceBusEncryption : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ServiceBusEncryption() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ServiceBus.ServiceBusEncryptionKeySource> KeySource { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ServiceBus.ServiceBusKeyVaultProperties> KeyVaultProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> RequireInfrastructureEncryption { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ServiceBusEncryptionKeySource
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="Microsoft.KeyVault")]
        MicrosoftKeyVault = 0,
    }
    public partial class ServiceBusFilterAction : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ServiceBusFilterAction() { }
        public Azure.Provisioning.BicepValue<int> CompatibilityLevel { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> RequiresPreprocessing { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SqlExpression { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ServiceBusFilterType
    {
        SqlFilter = 0,
        CorrelationFilter = 1,
    }
    public partial class ServiceBusKeyVaultProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ServiceBusKeyVaultProperties() { }
        public Azure.Provisioning.BicepValue<string> KeyName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> KeyVaultUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> KeyVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> UserAssignedIdentity { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ServiceBusMessagingEntityStatus
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
    public enum ServiceBusMinimumTlsVersion
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="1.0")]
        Tls1_0 = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="1.1")]
        Tls1_1 = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="1.2")]
        Tls1_2 = 2,
    }
    public partial class ServiceBusNamespace : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ServiceBusNamespace(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> AlternateName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> DisableLocalAuth { get { throw null; } set { } }
        public Azure.Provisioning.ServiceBus.ServiceBusEncryption Encryption { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsZoneRedundant { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MetricId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ServiceBus.ServiceBusMinimumTlsVersion> MinimumTlsVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> PremiumMessagingPartitions { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ServiceBus.ServiceBusPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ServiceBus.ServiceBusPublicNetworkAccess> PublicNetworkAccess { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServiceBusEndpoint { get { throw null; } }
        public Azure.Provisioning.ServiceBus.ServiceBusSku Sku { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Status { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> UpdatedOn { get { throw null; } }
        public Azure.Provisioning.Authorization.RoleAssignment CreateRoleAssignment(Azure.Provisioning.ServiceBus.ServiceBusBuiltInRole role, Azure.Provisioning.BicepValue<Azure.Provisioning.Authorization.RoleManagementPrincipalType> principalType, Azure.Provisioning.BicepValue<System.Guid> principalId, string? bicepIdentifierSuffix = null) { throw null; }
        public Azure.Provisioning.Authorization.RoleAssignment CreateRoleAssignment(Azure.Provisioning.ServiceBus.ServiceBusBuiltInRole role, Azure.Provisioning.Roles.UserAssignedIdentity identity) { throw null; }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ServiceBus.ServiceBusNamespace FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
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
    public partial class ServiceBusNamespaceAuthorizationRule : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ServiceBusNamespaceAuthorizationRule(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ServiceBus.ServiceBusNamespace? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ServiceBus.ServiceBusAccessRight> Rights { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ServiceBus.ServiceBusNamespaceAuthorizationRule FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public Azure.Provisioning.ServiceBus.ServiceBusAccessKeys GetKeys() { throw null; }
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
    public enum ServiceBusNetworkRuleIPAction
    {
        Allow = 0,
    }
    public partial class ServiceBusNetworkRuleSet : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ServiceBusNetworkRuleSet(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ServiceBus.ServiceBusNetworkRuleSetDefaultAction> DefaultAction { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ServiceBus.ServiceBusNetworkRuleSetIPRules> IPRules { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsTrustedServiceAccessEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.ServiceBus.ServiceBusNamespace? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ServiceBus.ServiceBusPublicNetworkAccessFlag> PublicNetworkAccess { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ServiceBus.ServiceBusNetworkRuleSetVirtualNetworkRules> VirtualNetworkRules { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ServiceBus.ServiceBusNetworkRuleSet FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2017_04_01;
            public static readonly string V2021_11_01;
            public static readonly string V2024_01_01;
        }
    }
    public enum ServiceBusNetworkRuleSetDefaultAction
    {
        Allow = 0,
        Deny = 1,
    }
    public partial class ServiceBusNetworkRuleSetIPRules : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ServiceBusNetworkRuleSetIPRules() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ServiceBus.ServiceBusNetworkRuleIPAction> Action { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> IPMask { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ServiceBusNetworkRuleSetVirtualNetworkRules : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ServiceBusNetworkRuleSetVirtualNetworkRules() { }
        public Azure.Provisioning.BicepValue<bool> IgnoreMissingVnetServiceEndpoint { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SubnetId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ServiceBusPrivateEndpointConnection : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ServiceBusPrivateEndpointConnection(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.ServiceBus.ServiceBusPrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ServiceBus.ServiceBusNamespace? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateEndpointId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ServiceBus.ServiceBusPrivateEndpointConnectionProvisioningState> ProvisioningState { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ServiceBus.ServiceBusPrivateEndpointConnection FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2021_11_01;
            public static readonly string V2024_01_01;
        }
    }
    public partial class ServiceBusPrivateEndpointConnectionData : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ServiceBusPrivateEndpointConnectionData() { }
        public Azure.Provisioning.ServiceBus.ServiceBusPrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateEndpointId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ServiceBus.ServiceBusPrivateEndpointConnectionProvisioningState> ProvisioningState { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ServiceBusPrivateEndpointConnectionProvisioningState
    {
        Creating = 0,
        Updating = 1,
        Deleting = 2,
        Succeeded = 3,
        Canceled = 4,
        Failed = 5,
    }
    public enum ServiceBusPrivateLinkConnectionStatus
    {
        Pending = 0,
        Approved = 1,
        Rejected = 2,
        Disconnected = 3,
    }
    public partial class ServiceBusPrivateLinkServiceConnectionState : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ServiceBusPrivateLinkServiceConnectionState() { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ServiceBus.ServiceBusPrivateLinkConnectionStatus> Status { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ServiceBusPublicNetworkAccess
    {
        Enabled = 0,
        Disabled = 1,
        SecuredByPerimeter = 2,
    }
    public enum ServiceBusPublicNetworkAccessFlag
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class ServiceBusQueue : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ServiceBusQueue(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> AccessedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> AutoDeleteOnIdle { get { throw null; } set { } }
        public Azure.Provisioning.ServiceBus.MessageCountDetails CountDetails { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> DeadLetteringOnMessageExpiration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> DefaultMessageTimeToLive { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> DuplicateDetectionHistoryTimeWindow { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableBatchedOperations { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableExpress { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnablePartitioning { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ForwardDeadLetteredMessagesTo { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ForwardTo { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> LockDuration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxDeliveryCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> MaxMessageSizeInKilobytes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxSizeInMegabytes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> MessageCount { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ServiceBus.ServiceBusNamespace? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> RequiresDuplicateDetection { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> RequiresSession { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> SizeInBytes { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ServiceBus.ServiceBusMessagingEntityStatus> Status { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> UpdatedOn { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ServiceBus.ServiceBusQueue FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
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
    public partial class ServiceBusQueueAuthorizationRule : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ServiceBusQueueAuthorizationRule(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ServiceBus.ServiceBusQueue? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ServiceBus.ServiceBusAccessRight> Rights { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ServiceBus.ServiceBusQueueAuthorizationRule FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public Azure.Provisioning.ServiceBus.ServiceBusAccessKeys GetKeys() { throw null; }
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
    public partial class ServiceBusRule : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ServiceBusRule(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.ServiceBus.ServiceBusFilterAction Action { get { throw null; } set { } }
        public Azure.Provisioning.ServiceBus.ServiceBusCorrelationFilter CorrelationFilter { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ServiceBus.ServiceBusFilterType> FilterType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ServiceBus.ServiceBusSubscription? Parent { get { throw null; } set { } }
        public Azure.Provisioning.ServiceBus.ServiceBusSqlFilter SqlFilter { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ServiceBus.ServiceBusRule FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2014_09_01;
            public static readonly string V2015_08_01;
            public static readonly string V2017_04_01;
            public static readonly string V2021_11_01;
            public static readonly string V2024_01_01;
        }
    }
    public partial class ServiceBusSku : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ServiceBusSku() { }
        public Azure.Provisioning.BicepValue<int> Capacity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ServiceBus.ServiceBusSkuName> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ServiceBus.ServiceBusSkuTier> Tier { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ServiceBusSkuName
    {
        Basic = 0,
        Standard = 1,
        Premium = 2,
    }
    public enum ServiceBusSkuTier
    {
        Basic = 0,
        Standard = 1,
        Premium = 2,
    }
    public partial class ServiceBusSqlFilter : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ServiceBusSqlFilter() { }
        public Azure.Provisioning.BicepValue<int> CompatibilityLevel { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> RequiresPreprocessing { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SqlExpression { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ServiceBusSubscription : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ServiceBusSubscription(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> AccessedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> AutoDeleteOnIdle { get { throw null; } set { } }
        public Azure.Provisioning.ServiceBus.ServiceBusClientAffineProperties ClientAffineProperties { get { throw null; } set { } }
        public Azure.Provisioning.ServiceBus.MessageCountDetails CountDetails { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> DeadLetteringOnFilterEvaluationExceptions { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> DeadLetteringOnMessageExpiration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> DefaultMessageTimeToLive { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> DuplicateDetectionHistoryTimeWindow { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableBatchedOperations { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ForwardDeadLetteredMessagesTo { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ForwardTo { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsClientAffine { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> LockDuration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxDeliveryCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> MessageCount { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ServiceBus.ServiceBusTopic? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> RequiresSession { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ServiceBus.ServiceBusMessagingEntityStatus> Status { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> UpdatedOn { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ServiceBus.ServiceBusSubscription FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
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
    public partial class ServiceBusTopic : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ServiceBusTopic(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> AccessedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> AutoDeleteOnIdle { get { throw null; } set { } }
        public Azure.Provisioning.ServiceBus.MessageCountDetails CountDetails { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> DefaultMessageTimeToLive { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> DuplicateDetectionHistoryTimeWindow { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableBatchedOperations { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableExpress { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnablePartitioning { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> MaxMessageSizeInKilobytes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxSizeInMegabytes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ServiceBus.ServiceBusNamespace? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> RequiresDuplicateDetection { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> SizeInBytes { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ServiceBus.ServiceBusMessagingEntityStatus> Status { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> SubscriptionCount { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> SupportOrdering { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> UpdatedOn { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ServiceBus.ServiceBusTopic FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
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
    public partial class ServiceBusTopicAuthorizationRule : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ServiceBusTopicAuthorizationRule(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ServiceBus.ServiceBusTopic? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ServiceBus.ServiceBusAccessRight> Rights { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ServiceBus.ServiceBusTopicAuthorizationRule FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public Azure.Provisioning.ServiceBus.ServiceBusAccessKeys GetKeys() { throw null; }
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
}
