namespace Azure.Provisioning.IotHub
{
    public partial class CloudToDeviceFeedbackQueueProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CloudToDeviceFeedbackQueueProperties() { }
        public Azure.Provisioning.BicepValue<System.TimeSpan> LockDurationAsIso8601 { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxDeliveryCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> TtlAsIso8601 { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CloudToDeviceProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CloudToDeviceProperties() { }
        public Azure.Provisioning.BicepValue<System.TimeSpan> DefaultTtlAsIso8601 { get { throw null; } set { } }
        public Azure.Provisioning.IotHub.CloudToDeviceFeedbackQueueProperties Feedback { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxDeliveryCount { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class EventHubCompatibleEndpointProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public EventHubCompatibleEndpointProperties() { }
        public Azure.Provisioning.BicepValue<string> Endpoint { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> EventHubCompatibleName { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> PartitionCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> PartitionIds { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> RetentionTimeInDays { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class EventHubConsumerGroupInfo : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public EventHubConsumerGroupInfo(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.IotHub.EventHubConsumerGroupInfo FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2026_03_01_PREVIEW;
        }
    }
    public enum IotHubAuthenticationType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="keyBased")]
        KeyBased = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="identityBased")]
        IdentityBased = 1,
    }
    public enum IotHubCapability
    {
        None = 0,
        DeviceManagement = 1,
    }
    public partial class IotHubCertificateDescription : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public IotHubCertificateDescription(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.IotHub.IotHubDescription Parent { get { throw null; } set { } }
        public Azure.Provisioning.IotHub.IotHubCertificateProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.IotHub.IotHubCertificateDescription FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2026_03_01_PREVIEW;
        }
    }
    public partial class IotHubCertificateProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public IotHubCertificateProperties() { }
        public Azure.Provisioning.BicepValue<string> Certificate { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ExpireOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsVerified { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PolicyResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Subject { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ThumbprintString { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> UpdatedOn { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class IotHubDescription : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public IotHubDescription(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.IotHub.IotHubProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.IotHub.IotHubSkuInfo Sku { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.IotHub.IotHubDescription FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2026_03_01_PREVIEW;
        }
    }
    public partial class IotHubDeviceRegistry : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public IotHubDeviceRegistry() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> IdentityResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> NamespaceResourceId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class IotHubEncryptionProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public IotHubEncryptionProperties() { }
        public Azure.Provisioning.BicepValue<string> KeySource { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.IotHub.IotHubKeyVaultKeyProperties> KeyVaultProperties { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class IotHubEnrichmentProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public IotHubEnrichmentProperties() { }
        public Azure.Provisioning.BicepList<string> EndpointNames { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Key { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class IotHubFallbackRouteProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public IotHubFallbackRouteProperties() { }
        public Azure.Provisioning.BicepValue<string> Condition { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> EndpointNames { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.IotHub.IotHubRoutingSource> Source { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum IotHubGatewayVersion
    {
        V1 = 0,
        V2 = 1,
    }
    public enum IotHubIPFilterActionType
    {
        Accept = 0,
        Reject = 1,
    }
    public partial class IotHubIPFilterRule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public IotHubIPFilterRule() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.IotHub.IotHubIPFilterActionType> Action { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FilterName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> IPMask { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum IotHubIPVersion
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="ipv4")]
        IPv4 = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="ipv6")]
        IPv6 = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="ipv4ipv6")]
        IPv4IPv6 = 2,
    }
    public partial class IotHubKeyVaultKeyProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public IotHubKeyVaultKeyProperties() { }
        public Azure.Provisioning.BicepValue<string> KeyIdentifier { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> UserAssignedIdentity { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class IotHubLocationDescription : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public IotHubLocationDescription() { }
        public Azure.Provisioning.BicepValue<string> Location { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.IotHub.IotHubReplicaRoleType> Role { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum IotHubNetworkRuleIPAction
    {
        Allow = 0,
    }
    public enum IotHubNetworkRuleSetDefaultAction
    {
        Deny = 0,
        Allow = 1,
    }
    public partial class IotHubNetworkRuleSetIPRule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public IotHubNetworkRuleSetIPRule() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.IotHub.IotHubNetworkRuleIPAction> Action { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FilterName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> IPMask { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class IotHubNetworkRuleSetProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public IotHubNetworkRuleSetProperties() { }
        public Azure.Provisioning.BicepValue<bool> ApplyToBuiltInEventHubEndpoint { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.IotHub.IotHubNetworkRuleSetDefaultAction> DefaultAction { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.IotHub.IotHubNetworkRuleSetIPRule> IPRules { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class IotHubPrivateEndpointConnection : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public IotHubPrivateEndpointConnection(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.IotHub.IotHubDescription Parent { get { throw null; } set { } }
        public Azure.Provisioning.IotHub.IotHubPrivateEndpointConnectionProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.IotHub.IotHubPrivateEndpointConnection FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2026_03_01_PREVIEW;
        }
    }
    public partial class IotHubPrivateEndpointConnectionProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public IotHubPrivateEndpointConnectionProperties() { }
        public Azure.Provisioning.IotHub.IotHubPrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateEndpointId { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class IotHubPrivateLinkServiceConnectionState : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public IotHubPrivateLinkServiceConnectionState() { }
        public Azure.Provisioning.BicepValue<string> ActionsRequired { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.IotHub.IotHubPrivateLinkServiceConnectionStatus> Status { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum IotHubPrivateLinkServiceConnectionStatus
    {
        Pending = 0,
        Approved = 1,
        Rejected = 2,
        Disconnected = 3,
    }
    public partial class IotHubProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public IotHubProperties() { }
        public Azure.Provisioning.BicepList<string> AllowedFqdns { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.IotHub.SharedAccessSignatureAuthorizationRule> AuthorizationPolicies { get { throw null; } set { } }
        public Azure.Provisioning.IotHub.CloudToDeviceProperties CloudToDevice { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Comments { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DeviceHostName { get { throw null; } }
        public Azure.Provisioning.IotHub.IotHubDeviceRegistry DeviceRegistry { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> DeviceStreamsStreamingEndpoints { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> DisableDeviceSas { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> DisableLocalAuth { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> DisableModuleSas { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableDataResidency { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableFileUploadNotifications { get { throw null; } set { } }
        public Azure.Provisioning.IotHub.IotHubEncryptionProperties Encryption { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.IotHub.EventHubCompatibleEndpointProperties> EventHubEndpoints { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.IotHub.IotHubCapability> Features { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> HostName { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.IotHub.IotHubGatewayVersion> IotHubDetailsGatewayVersion { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.IotHub.IotHubIPFilterRule> IPFilterRules { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.IotHub.IotHubIPVersion> IPVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.IotHub.IotHubLocationDescription> Locations { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.IotHub.MessagingEndpointProperties> MessagingEndpoints { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MinTlsVersion { get { throw null; } set { } }
        public Azure.Provisioning.IotHub.IotHubNetworkRuleSetProperties NetworkRuleSets { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.IotHub.IotHubPrivateEndpointConnection> PrivateEndpointConnections { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.IotHub.IotHubPublicNetworkAccess> PublicNetworkAccess { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> RestrictOutboundNetworkAccess { get { throw null; } set { } }
        public Azure.Provisioning.IotHub.IotHubRootCertificateProperties RootCertificate { get { throw null; } set { } }
        public Azure.Provisioning.IotHub.IotHubRoutingProperties Routing { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServiceHostName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> State { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.IotHub.IotHubStorageEndpointProperties> StorageEndpoints { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum IotHubPublicNetworkAccess
    {
        Enabled = 0,
        Disabled = 1,
    }
    public enum IotHubReplicaRoleType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="primary")]
        Primary = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="secondary")]
        Secondary = 1,
    }
    public partial class IotHubRootCertificateProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public IotHubRootCertificateProperties() { }
        public Azure.Provisioning.BicepValue<bool> IsRootCertificateV2Enabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastUpdatedOn { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class IotHubRoutingProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public IotHubRoutingProperties() { }
        public Azure.Provisioning.IotHub.RoutingEndpoints Endpoints { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.IotHub.IotHubEnrichmentProperties> Enrichments { get { throw null; } set { } }
        public Azure.Provisioning.IotHub.IotHubFallbackRouteProperties FallbackRoute { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.IotHub.RoutingRuleProperties> Routes { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum IotHubRoutingSource
    {
        Invalid = 0,
        DeviceMessages = 1,
        TwinChangeEvents = 2,
        DeviceLifecycleEvents = 3,
        DeviceJobLifecycleEvents = 4,
        DigitalTwinChangeEvents = 5,
        DeviceConnectionStateEvents = 6,
        MqttBrokerMessages = 7,
    }
    public enum IotHubSharedAccessRight
    {
        RegistryRead = 0,
        RegistryWrite = 1,
        ServiceConnect = 2,
        DeviceConnect = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="RegistryRead, RegistryWrite")]
        RegistryReadRegistryWrite = 4,
        [System.Runtime.Serialization.DataMemberAttribute(Name="RegistryRead, ServiceConnect")]
        RegistryReadServiceConnect = 5,
        [System.Runtime.Serialization.DataMemberAttribute(Name="RegistryRead, DeviceConnect")]
        RegistryReadDeviceConnect = 6,
        [System.Runtime.Serialization.DataMemberAttribute(Name="RegistryWrite, ServiceConnect")]
        RegistryWriteServiceConnect = 7,
        [System.Runtime.Serialization.DataMemberAttribute(Name="RegistryWrite, DeviceConnect")]
        RegistryWriteDeviceConnect = 8,
        [System.Runtime.Serialization.DataMemberAttribute(Name="ServiceConnect, DeviceConnect")]
        ServiceConnectDeviceConnect = 9,
        [System.Runtime.Serialization.DataMemberAttribute(Name="RegistryRead, RegistryWrite, ServiceConnect")]
        RegistryReadRegistryWriteServiceConnect = 10,
        [System.Runtime.Serialization.DataMemberAttribute(Name="RegistryRead, RegistryWrite, DeviceConnect")]
        RegistryReadRegistryWriteDeviceConnect = 11,
        [System.Runtime.Serialization.DataMemberAttribute(Name="RegistryRead, ServiceConnect, DeviceConnect")]
        RegistryReadServiceConnectDeviceConnect = 12,
        [System.Runtime.Serialization.DataMemberAttribute(Name="RegistryWrite, ServiceConnect, DeviceConnect")]
        RegistryWriteServiceConnectDeviceConnect = 13,
        [System.Runtime.Serialization.DataMemberAttribute(Name="RegistryRead, RegistryWrite, ServiceConnect, DeviceConnect")]
        RegistryReadRegistryWriteServiceConnectDeviceConnect = 14,
    }
    public enum IotHubSku
    {
        F1 = 0,
        S1 = 1,
        S2 = 2,
        S3 = 3,
        B1 = 4,
        B2 = 5,
        B3 = 6,
        [System.Runtime.Serialization.DataMemberAttribute(Name="GEN2")]
        Gen2 = 7,
    }
    public partial class IotHubSkuInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public IotHubSkuInfo() { }
        public Azure.Provisioning.BicepValue<long> Capacity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.IotHub.IotHubSku> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.IotHub.IotHubSkuTier> Tier { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum IotHubSkuTier
    {
        Free = 0,
        Standard = 1,
        Basic = 2,
        Generation2 = 3,
    }
    public partial class IotHubStorageEndpointProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public IotHubStorageEndpointProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.IotHub.IotHubAuthenticationType> AuthenticationType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ConnectionString { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ContainerName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> SasTtlAsIso8601 { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> UserAssignedIdentity { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MessagingEndpointProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MessagingEndpointProperties() { }
        public Azure.Provisioning.BicepValue<System.TimeSpan> LockDurationAsIso8601 { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxDeliveryCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> TtlAsIso8601 { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RoutingCosmosDBSqlApiProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RoutingCosmosDBSqlApiProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.IotHub.IotHubAuthenticationType> AuthenticationType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ContainerName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DatabaseName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> EndpointUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PartitionKeyName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PartitionKeyTemplate { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PrimaryKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ResourceGroup { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SecondaryKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SubscriptionId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> UserAssignedIdentity { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RoutingEndpoints : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RoutingEndpoints() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.IotHub.RoutingCosmosDBSqlApiProperties> CosmosDBSqlContainers { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.IotHub.RoutingEventHubProperties> EventHubs { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.IotHub.RoutingServiceBusQueueEndpointProperties> ServiceBusQueues { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.IotHub.RoutingServiceBusTopicEndpointProperties> ServiceBusTopics { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.IotHub.RoutingStorageContainerProperties> StorageContainers { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RoutingEventHubProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RoutingEventHubProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.IotHub.IotHubAuthenticationType> AuthenticationType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ConnectionString { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Endpoint { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EntityPath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ResourceGroup { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SubscriptionId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> UserAssignedIdentity { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RoutingRuleProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RoutingRuleProperties() { }
        public Azure.Provisioning.BicepValue<string> Condition { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> EndpointNames { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.IotHub.IotHubRoutingSource> Source { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RoutingServiceBusQueueEndpointProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RoutingServiceBusQueueEndpointProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.IotHub.IotHubAuthenticationType> AuthenticationType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ConnectionString { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Endpoint { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EntityPath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ResourceGroup { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SubscriptionId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> UserAssignedIdentity { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RoutingServiceBusTopicEndpointProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RoutingServiceBusTopicEndpointProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.IotHub.IotHubAuthenticationType> AuthenticationType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ConnectionString { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Endpoint { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EntityPath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ResourceGroup { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SubscriptionId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> UserAssignedIdentity { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RoutingStorageContainerProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RoutingStorageContainerProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.IotHub.IotHubAuthenticationType> AuthenticationType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> BatchFrequencyInSeconds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ConnectionString { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ContainerName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.IotHub.RoutingStorageContainerPropertiesEncoding> Encoding { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Endpoint { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FileNameFormat { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxChunkSizeInBytes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ResourceGroup { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SubscriptionId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> UserAssignedIdentity { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum RoutingStorageContainerPropertiesEncoding
    {
        Avro = 0,
        AvroDeflate = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="JSON")]
        Json = 2,
    }
    public partial class SharedAccessSignatureAuthorizationRule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SharedAccessSignatureAuthorizationRule() { }
        public Azure.Provisioning.BicepValue<string> KeyName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PrimaryKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.IotHub.IotHubSharedAccessRight> Rights { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SecondaryKey { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
}
