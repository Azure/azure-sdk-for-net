namespace Azure.Provisioning.AppConfiguration
{
    public enum AppConfigurationActionsRequired
    {
        None = 0,
        Recreate = 1,
    }
    public enum AppConfigurationCreateMode
    {
        Recover = 0,
        Default = 1,
    }
    public partial class AppConfigurationDataPlaneProxyProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AppConfigurationDataPlaneProxyProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppConfiguration.DataPlaneProxyAuthenticationMode> AuthenticationMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppConfiguration.DataPlaneProxyPrivateLinkDelegation> PrivateLinkDelegation { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AppConfigurationKeyValue : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public AppConfigurationKeyValue(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> ContentType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsLocked { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Key { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Label { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastModifiedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.AppConfiguration.AppConfigurationStore Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AppConfiguration.AppConfigurationKeyValue FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_02_01_preview;
            public static readonly string V2025_06_01_preview;
        }
    }
    public partial class AppConfigurationKeyVaultProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AppConfigurationKeyVaultProperties() { }
        public Azure.Provisioning.BicepValue<string> IdentityClientId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> KeyIdentifier { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AppConfigurationMoboBrokerResourceInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AppConfigurationMoboBrokerResourceInfo() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AppConfigurationPrivateEndpointConnection : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public AppConfigurationPrivateEndpointConnection(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.AppConfiguration.AzureProvisioningAppConfigurationPrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.AppConfiguration.AppConfigurationStore Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateEndpointId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppConfiguration.AppConfigurationProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AppConfiguration.AppConfigurationPrivateEndpointConnection FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_02_01_preview;
            public static readonly string V2025_06_01_preview;
        }
    }
    public partial class AppConfigurationPrivateEndpointConnectionReference : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AppConfigurationPrivateEndpointConnectionReference() { }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.AppConfiguration.PrivateEndpointConnectionProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Type { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AppConfigurationPrivateLinkResource : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public AppConfigurationPrivateLinkResource(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> GroupId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.AppConfiguration.AppConfigurationStore Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> RequiredMembers { get { throw null; } }
        public Azure.Provisioning.BicepList<string> RequiredZoneNames { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AppConfiguration.AppConfigurationPrivateLinkResource FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_02_01_preview;
            public static readonly string V2025_06_01_preview;
        }
    }
    public enum AppConfigurationPrivateLinkServiceConnectionStatus
    {
        Pending = 0,
        Approved = 1,
        Rejected = 2,
        Disconnected = 3,
    }
    public enum AppConfigurationProvisioningState
    {
        Creating = 0,
        Updating = 1,
        Deleting = 2,
        Succeeded = 3,
        Failed = 4,
        Canceled = 5,
    }
    public enum AppConfigurationPublicNetworkAccess
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class AppConfigurationReplica : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public AppConfigurationReplica(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Endpoint { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.AppConfiguration.AppConfigurationStore Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppConfiguration.AppConfigurationReplicaProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AppConfiguration.AppConfigurationReplica FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_02_01_preview;
            public static readonly string V2025_06_01_preview;
        }
    }
    public enum AppConfigurationReplicaProvisioningState
    {
        Creating = 0,
        Succeeded = 1,
        Deleting = 2,
        Failed = 3,
        Canceled = 4,
    }
    public partial class AppConfigurationSnapshot : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public AppConfigurationSnapshot(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppConfiguration.SnapshotCompositionType> CompositionType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.ETag> Etag { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ExpireOn { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AppConfiguration.SnapshotKeyValueFilter> Filters { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> ItemsCount { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.AppConfiguration.AppConfigurationStore Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppConfiguration.AppConfigurationProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> RetentionPeriod { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> Size { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppConfiguration.AppConfigurationSnapshotStatus> Status { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AppConfiguration.AppConfigurationSnapshot FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_02_01_preview;
            public static readonly string V2025_06_01_preview;
        }
    }
    public enum AppConfigurationSnapshotStatus
    {
        Provisioning = 0,
        Ready = 1,
        Archived = 2,
        Failed = 3,
    }
    public partial class AppConfigurationStore : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public AppConfigurationStore(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> AzureFrontDoorResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppConfiguration.AppConfigurationCreateMode> CreateMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreationDate { get { throw null; } }
        public Azure.Provisioning.AppConfiguration.AppConfigurationDataPlaneProxyProperties DataPlaneProxy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> DefaultKeyValueRevisionRetentionPeriodInSeconds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> DisableLocalAuth { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnablePurgeProtection { get { throw null; } set { } }
        public Azure.Provisioning.AppConfiguration.AppConfigurationKeyVaultProperties EncryptionKeyVaultProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Endpoint { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AppConfiguration.AppConfigurationMoboBrokerResourceInfo> ManagedOnBehalfOfMoboBrokerResources { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AppConfiguration.AppConfigurationPrivateEndpointConnectionReference> PrivateEndpointConnections { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppConfiguration.AppConfigurationProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppConfiguration.AppConfigurationPublicNetworkAccess> PublicNetworkAccess { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SkuName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> SoftDeleteRetentionInDays { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> TelemetryResourceId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AppConfiguration.AppConfigurationStore FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_02_01_preview;
            public static readonly string V2025_06_01_preview;
        }
    }
    public partial class AzureProvisioningAppConfigurationPrivateLinkServiceConnectionState : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AzureProvisioningAppConfigurationPrivateLinkServiceConnectionState() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppConfiguration.AppConfigurationActionsRequired> ActionsRequired { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppConfiguration.AppConfigurationPrivateLinkServiceConnectionStatus> Status { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DataPlaneProxyAuthenticationMode
    {
        Local = 0,
        PassThrough = 1,
    }
    public enum DataPlaneProxyPrivateLinkDelegation
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class DeletedAppConfigurationStore : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DeletedAppConfigurationStore(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ConfigurationStoreId { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> DeletionDate { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsPurgeProtectionEnabled { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ScheduledPurgeDate { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AppConfiguration.DeletedAppConfigurationStore FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_02_01_preview;
            public static readonly string V2025_06_01_preview;
        }
    }
    public partial class PrivateEndpointConnectionProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PrivateEndpointConnectionProperties() { }
        public Azure.Provisioning.AppConfiguration.AzureProvisioningAppConfigurationPrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateEndpointId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppConfiguration.AppConfigurationProvisioningState> ProvisioningState { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum SnapshotCompositionType
    {
        Key = 0,
        KeyLabel = 1,
    }
    public partial class SnapshotKeyValueFilter : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SnapshotKeyValueFilter() { }
        public Azure.Provisioning.BicepValue<string> Key { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Label { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
}
