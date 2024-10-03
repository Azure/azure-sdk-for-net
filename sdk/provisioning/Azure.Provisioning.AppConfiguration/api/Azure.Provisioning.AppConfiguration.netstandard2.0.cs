namespace Azure.Provisioning.AppConfiguration
{
    public enum AppConfigurationActionsRequired
    {
        None = 0,
        Recreate = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AppConfigurationBuiltInRole : System.IEquatable<Azure.Provisioning.AppConfiguration.AppConfigurationBuiltInRole>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AppConfigurationBuiltInRole(string value) { throw null; }
        public static Azure.Provisioning.AppConfiguration.AppConfigurationBuiltInRole AppConfigurationDataOwner { get { throw null; } }
        public static Azure.Provisioning.AppConfiguration.AppConfigurationBuiltInRole AppConfigurationDataReader { get { throw null; } }
        public bool Equals(Azure.Provisioning.AppConfiguration.AppConfigurationBuiltInRole other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object? obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static string GetBuiltInRoleName(Azure.Provisioning.AppConfiguration.AppConfigurationBuiltInRole value) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Provisioning.AppConfiguration.AppConfigurationBuiltInRole left, Azure.Provisioning.AppConfiguration.AppConfigurationBuiltInRole right) { throw null; }
        public static implicit operator Azure.Provisioning.AppConfiguration.AppConfigurationBuiltInRole (string value) { throw null; }
        public static bool operator !=(Azure.Provisioning.AppConfiguration.AppConfigurationBuiltInRole left, Azure.Provisioning.AppConfiguration.AppConfigurationBuiltInRole right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum AppConfigurationCreateMode
    {
        Recover = 0,
        Default = 1,
    }
    public partial class AppConfigurationKeyValue : Azure.Provisioning.Primitives.Resource
    {
        public AppConfigurationKeyValue(string resourceName, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> ContentType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsLocked { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Key { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Label { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastModifiedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.AppConfiguration.AppConfigurationStore? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        public static Azure.Provisioning.AppConfiguration.AppConfigurationKeyValue FromExisting(string resourceName, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2022_05_01;
            public static readonly string V2023_03_01;
            public static readonly string V2024_05_01;
        }
    }
    public partial class AppConfigurationKeyVaultProperties : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public AppConfigurationKeyVaultProperties() { }
        public Azure.Provisioning.BicepValue<string> IdentityClientId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> KeyIdentifier { get { throw null; } set { } }
    }
    public partial class AppConfigurationPrivateEndpointConnection : Azure.Provisioning.Primitives.Resource
    {
        public AppConfigurationPrivateEndpointConnection(string resourceName, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppConfiguration.AppConfigurationPrivateLinkServiceConnectionState> ConnectionState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.AppConfiguration.AppConfigurationStore? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateEndpointId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppConfiguration.AppConfigurationProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public static Azure.Provisioning.AppConfiguration.AppConfigurationPrivateEndpointConnection FromExisting(string resourceName, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2019_10_01;
            public static readonly string V2020_06_01;
            public static readonly string V2022_05_01;
            public static readonly string V2023_03_01;
            public static readonly string V2024_05_01;
        }
    }
    public partial class AppConfigurationPrivateEndpointConnectionReference : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public AppConfigurationPrivateEndpointConnectionReference() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppConfiguration.AppConfigurationPrivateLinkServiceConnectionState> ConnectionState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateEndpointId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppConfiguration.AppConfigurationProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
    }
    public partial class AppConfigurationPrivateLinkServiceConnectionState : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public AppConfigurationPrivateLinkServiceConnectionState() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppConfiguration.AppConfigurationActionsRequired> ActionsRequired { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppConfiguration.AppConfigurationPrivateLinkServiceConnectionStatus> Status { get { throw null; } set { } }
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
    public partial class AppConfigurationReplica : Azure.Provisioning.Primitives.Resource
    {
        public AppConfigurationReplica(string resourceName, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Endpoint { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.AppConfiguration.AppConfigurationStore? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppConfiguration.AppConfigurationReplicaProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public static Azure.Provisioning.AppConfiguration.AppConfigurationReplica FromExisting(string resourceName, string? resourceVersion = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2023_03_01;
            public static readonly string V2024_05_01;
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
    public partial class AppConfigurationStore : Azure.Provisioning.Primitives.Resource
    {
        public AppConfigurationStore(string resourceName, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppConfiguration.AppConfigurationCreateMode> CreateMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> DisableLocalAuth { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnablePurgeProtection { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppConfiguration.AppConfigurationKeyVaultProperties> EncryptionKeyVaultProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Endpoint { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ManagedServiceIdentity> Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AppConfiguration.AppConfigurationPrivateEndpointConnectionReference> PrivateEndpointConnections { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppConfiguration.AppConfigurationProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppConfiguration.AppConfigurationPublicNetworkAccess> PublicNetworkAccess { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SkuName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> SoftDeleteRetentionInDays { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.Authorization.RoleAssignment CreateRoleAssignment(Azure.Provisioning.AppConfiguration.AppConfigurationBuiltInRole role, Azure.Provisioning.BicepValue<Azure.Provisioning.Authorization.RoleManagementPrincipalType> principalType, Azure.Provisioning.BicepValue<System.Guid> principalId, string? resourceNameSuffix = null) { throw null; }
        public Azure.Provisioning.Authorization.RoleAssignment CreateRoleAssignment(Azure.Provisioning.AppConfiguration.AppConfigurationBuiltInRole role, Azure.Provisioning.Roles.UserAssignedIdentity identity) { throw null; }
        public static Azure.Provisioning.AppConfiguration.AppConfigurationStore FromExisting(string resourceName, string? resourceVersion = null) { throw null; }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AppConfiguration.AppConfigurationStoreApiKey> GetKeys() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2019_10_01;
            public static readonly string V2020_06_01;
            public static readonly string V2022_05_01;
            public static readonly string V2023_03_01;
            public static readonly string V2024_05_01;
        }
    }
    public partial class AppConfigurationStoreApiKey : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public AppConfigurationStoreApiKey() { }
        public Azure.Provisioning.BicepValue<string> ConnectionString { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsReadOnly { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastModifiedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Provisioning.AppConfiguration.AppConfigurationStoreApiKey FromExpression(Azure.Provisioning.Expressions.Expression expression) { throw null; }
    }
}
