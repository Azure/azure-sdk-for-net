namespace Azure.Provisioning.WebPubSub
{
    public enum AclAction
    {
        Allow = 0,
        Deny = 1,
    }
    public partial class BillingInfoSku : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public BillingInfoSku() { }
        public Azure.Provisioning.BicepValue<int> Capacity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Family { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Size { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.WebPubSub.WebPubSubSkuTier> Tier { get { throw null; } set { } }
    }
    public partial class LiveTraceCategory : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public LiveTraceCategory() { }
        public Azure.Provisioning.BicepValue<string> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
    }
    public partial class LiveTraceConfiguration : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public LiveTraceConfiguration() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.WebPubSub.LiveTraceCategory> Categories { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> IsEnabled { get { throw null; } set { } }
    }
    public partial class PrivateEndpointAcl : Azure.Provisioning.WebPubSub.PublicNetworkAcls
    {
        public PrivateEndpointAcl() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
    }
    public partial class PublicNetworkAcls : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public PublicNetworkAcls() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.WebPubSub.WebPubSubRequestType> Allow { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.WebPubSub.WebPubSubRequestType> Deny { get { throw null; } set { } }
    }
    public partial class ResourceLogCategory : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public ResourceLogCategory() { }
        public Azure.Provisioning.BicepValue<string> Enabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
    }
    public partial class UpstreamAuthSettings : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public UpstreamAuthSettings() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.WebPubSub.UpstreamAuthType> AuthType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ManagedIdentityResource { get { throw null; } set { } }
    }
    public enum UpstreamAuthType
    {
        None = 0,
        ManagedIdentity = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WebPubSubBuiltInRole : System.IEquatable<Azure.Provisioning.WebPubSub.WebPubSubBuiltInRole>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WebPubSubBuiltInRole(string value) { throw null; }
        public static Azure.Provisioning.WebPubSub.WebPubSubBuiltInRole WebPubSubContributor { get { throw null; } }
        public static Azure.Provisioning.WebPubSub.WebPubSubBuiltInRole WebPubSubServiceOwner { get { throw null; } }
        public static Azure.Provisioning.WebPubSub.WebPubSubBuiltInRole WebPubSubServiceReader { get { throw null; } }
        public bool Equals(Azure.Provisioning.WebPubSub.WebPubSubBuiltInRole other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object? obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static string GetBuiltInRoleName(Azure.Provisioning.WebPubSub.WebPubSubBuiltInRole value) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Provisioning.WebPubSub.WebPubSubBuiltInRole left, Azure.Provisioning.WebPubSub.WebPubSubBuiltInRole right) { throw null; }
        public static implicit operator Azure.Provisioning.WebPubSub.WebPubSubBuiltInRole (string value) { throw null; }
        public static bool operator !=(Azure.Provisioning.WebPubSub.WebPubSubBuiltInRole left, Azure.Provisioning.WebPubSub.WebPubSubBuiltInRole right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WebPubSubEventHandler : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public WebPubSubEventHandler() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.WebPubSub.UpstreamAuthSettings> Auth { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> SystemEvents { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> UrlTemplate { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> UserEventPattern { get { throw null; } set { } }
    }
    public partial class WebPubSubHub : Azure.Provisioning.Primitives.Resource
    {
        public WebPubSubHub(string identifierName, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.WebPubSub.WebPubSubService? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.WebPubSub.WebPubSubHubProperties> Properties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public static Azure.Provisioning.WebPubSub.WebPubSubHub FromExisting(string identifierName, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2020_05_01;
            public static readonly string V2021_10_01;
            public static readonly string V2023_02_01;
            public static readonly string V2024_03_01;
            public static readonly string V2024_04_01_preview;
        }
    }
    public partial class WebPubSubHubProperties : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public WebPubSubHubProperties() { }
        public Azure.Provisioning.BicepValue<string> AnonymousConnectPolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.WebPubSub.WebPubSubEventHandler> EventHandlers { get { throw null; } set { } }
    }
    public partial class WebPubSubKeys : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public WebPubSubKeys() { }
        public Azure.Provisioning.BicepValue<string> PrimaryConnectionString { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> PrimaryKey { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SecondaryConnectionString { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SecondaryKey { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Provisioning.WebPubSub.WebPubSubKeys FromExpression(Azure.Provisioning.Expressions.Expression expression) { throw null; }
    }
    public partial class WebPubSubNetworkAcls : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public WebPubSubNetworkAcls() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.WebPubSub.AclAction> DefaultAction { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.WebPubSub.PrivateEndpointAcl> PrivateEndpoints { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.WebPubSub.PublicNetworkAcls> PublicNetwork { get { throw null; } set { } }
    }
    public partial class WebPubSubPrivateEndpointConnection : Azure.Provisioning.Primitives.Resource
    {
        public WebPubSubPrivateEndpointConnection(string identifierName, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.WebPubSub.WebPubSubPrivateLinkServiceConnectionState> ConnectionState { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> GroupIds { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.WebPubSub.WebPubSubService? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateEndpointId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.WebPubSub.WebPubSubProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public static Azure.Provisioning.WebPubSub.WebPubSubPrivateEndpointConnection FromExisting(string identifierName, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2020_05_01;
            public static readonly string V2021_10_01;
            public static readonly string V2023_02_01;
            public static readonly string V2024_03_01;
            public static readonly string V2024_04_01_preview;
        }
    }
    public partial class WebPubSubPrivateEndpointConnectionData : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public WebPubSubPrivateEndpointConnectionData() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.WebPubSub.WebPubSubPrivateLinkServiceConnectionState> ConnectionState { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> GroupIds { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateEndpointId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.WebPubSub.WebPubSubProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
    }
    public partial class WebPubSubPrivateLinkServiceConnectionState : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public WebPubSubPrivateLinkServiceConnectionState() { }
        public Azure.Provisioning.BicepValue<string> ActionsRequired { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.WebPubSub.WebPubSubPrivateLinkServiceConnectionStatus> Status { get { throw null; } set { } }
    }
    public enum WebPubSubPrivateLinkServiceConnectionStatus
    {
        Pending = 0,
        Approved = 1,
        Rejected = 2,
        Disconnected = 3,
    }
    public enum WebPubSubProvisioningState
    {
        Unknown = 0,
        Succeeded = 1,
        Failed = 2,
        Canceled = 3,
        Running = 4,
        Creating = 5,
        Updating = 6,
        Deleting = 7,
        Moving = 8,
    }
    public enum WebPubSubRequestType
    {
        ClientConnection = 0,
        ServerConnection = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="RESTAPI")]
        RestApi = 2,
        Trace = 3,
    }
    public partial class WebPubSubService : Azure.Provisioning.Primitives.Resource
    {
        public WebPubSubService(string identifierName, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> ExternalIP { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> HostName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> HostNamePrefix { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ManagedServiceIdentity> Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsAadAuthDisabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsClientCertEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsLocalAuthDisabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.WebPubSub.LiveTraceConfiguration> LiveTraceConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.WebPubSub.WebPubSubNetworkAcls> NetworkAcls { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.WebPubSub.WebPubSubPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.WebPubSub.WebPubSubProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> PublicNetworkAccess { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> PublicPort { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.WebPubSub.ResourceLogCategory> ResourceLogCategories { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> ServerPort { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.WebPubSub.WebPubSubSharedPrivateLinkData> SharedPrivateLinkResources { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.WebPubSub.BillingInfoSku> Sku { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Version { get { throw null; } }
        public Azure.Provisioning.Authorization.RoleAssignment CreateRoleAssignment(Azure.Provisioning.WebPubSub.WebPubSubBuiltInRole role, Azure.Provisioning.BicepValue<Azure.Provisioning.Authorization.RoleManagementPrincipalType> principalType, Azure.Provisioning.BicepValue<System.Guid> principalId, string? identifierNameSuffix = null) { throw null; }
        public Azure.Provisioning.Authorization.RoleAssignment CreateRoleAssignment(Azure.Provisioning.WebPubSub.WebPubSubBuiltInRole role, Azure.Provisioning.Roles.UserAssignedIdentity identity) { throw null; }
        public static Azure.Provisioning.WebPubSub.WebPubSubService FromExisting(string identifierName, string? resourceVersion = null) { throw null; }
        public Azure.Provisioning.WebPubSub.WebPubSubKeys GetKeys() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2020_05_01;
            public static readonly string V2021_10_01;
            public static readonly string V2023_02_01;
            public static readonly string V2024_03_01;
            public static readonly string V2024_04_01_preview;
        }
    }
    public partial class WebPubSubSharedPrivateLink : Azure.Provisioning.Primitives.Resource
    {
        public WebPubSubSharedPrivateLink(string identifierName, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> GroupId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.WebPubSub.WebPubSubService? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateLinkResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.WebPubSub.WebPubSubProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> RequestMessage { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.WebPubSub.WebPubSubSharedPrivateLinkStatus> Status { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public static Azure.Provisioning.WebPubSub.WebPubSubSharedPrivateLink FromExisting(string identifierName, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2020_05_01;
            public static readonly string V2021_10_01;
            public static readonly string V2023_02_01;
            public static readonly string V2024_03_01;
            public static readonly string V2024_04_01_preview;
        }
    }
    public partial class WebPubSubSharedPrivateLinkData : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public WebPubSubSharedPrivateLinkData() { }
        public Azure.Provisioning.BicepValue<string> GroupId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateLinkResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.WebPubSub.WebPubSubProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> RequestMessage { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.WebPubSub.WebPubSubSharedPrivateLinkStatus> Status { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
    }
    public enum WebPubSubSharedPrivateLinkStatus
    {
        Pending = 0,
        Approved = 1,
        Rejected = 2,
        Disconnected = 3,
        Timeout = 4,
    }
    public enum WebPubSubSkuTier
    {
        Free = 0,
        Basic = 1,
        Standard = 2,
        Premium = 3,
    }
}
