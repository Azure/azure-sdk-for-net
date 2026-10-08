namespace Azure.Provisioning.SignalR
{
    public enum PrivateLinkServiceConnectionStatus
    {
        Pending = 0,
        Approved = 1,
        Rejected = 2,
        Disconnected = 3,
    }
    public partial class SignalRApplicationFirewallSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SignalRApplicationFirewallSettings() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SignalR.SignalRClientConnectionCountRule> ClientConnectionCountRules { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SignalR.SignalRClientTrafficControlRule> ClientTrafficControlRules { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> MaxClientConnectionLifetimeInSeconds { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SignalRBuiltInRole : System.IEquatable<Azure.Provisioning.SignalR.SignalRBuiltInRole>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SignalRBuiltInRole(string value) { throw null; }
        public static Azure.Provisioning.SignalR.SignalRBuiltInRole SignalRAccessKeyReader { get { throw null; } }
        public static Azure.Provisioning.SignalR.SignalRBuiltInRole SignalRAppServer { get { throw null; } }
        public static Azure.Provisioning.SignalR.SignalRBuiltInRole SignalRContributor { get { throw null; } }
        public static Azure.Provisioning.SignalR.SignalRBuiltInRole SignalRRestApiOwner { get { throw null; } }
        public static Azure.Provisioning.SignalR.SignalRBuiltInRole SignalRRestApiReader { get { throw null; } }
        public static Azure.Provisioning.SignalR.SignalRBuiltInRole SignalRServiceOwner { get { throw null; } }
        public bool Equals(Azure.Provisioning.SignalR.SignalRBuiltInRole other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public static string GetBuiltInRoleName(Azure.Provisioning.SignalR.SignalRBuiltInRole value) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Provisioning.SignalR.SignalRBuiltInRole left, Azure.Provisioning.SignalR.SignalRBuiltInRole right) { throw null; }
        public static implicit operator Azure.Provisioning.SignalR.SignalRBuiltInRole (string value) { throw null; }
        public static bool operator !=(Azure.Provisioning.SignalR.SignalRBuiltInRole left, Azure.Provisioning.SignalR.SignalRBuiltInRole right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SignalRClientConnectionCountRule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SignalRClientConnectionCountRule() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SignalRClientTrafficControlRule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SignalRClientTrafficControlRule() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SignalRCustomCertificate : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SignalRCustomCertificate(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Uri> KeyVaultBaseUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> KeyVaultSecretName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> KeyVaultSecretVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.SignalR.SignalRService Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SignalR.SignalRProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SignalR.SignalRCustomCertificate FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2018_10_01;
            public static readonly string V2020_05_01;
            public static readonly string V2021_10_01;
            public static readonly string V2022_02_01;
            public static readonly string V2023_02_01;
            public static readonly string V2024_03_01;
            public static readonly string V2025_01_01_PREVIEW;
        }
    }
    public partial class SignalRCustomDomain : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SignalRCustomDomain(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> CustomCertificateId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DomainName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.SignalR.SignalRService Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SignalR.SignalRProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SignalR.SignalRCustomDomain FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2020_05_01;
            public static readonly string V2021_10_01;
            public static readonly string V2022_02_01;
            public static readonly string V2023_02_01;
            public static readonly string V2024_03_01;
            public static readonly string V2025_01_01_PREVIEW;
        }
    }
    public partial class SignalRFeature : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SignalRFeature() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SignalR.SignalRFeatureFlag> Flag { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Properties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum SignalRFeatureFlag
    {
        ServiceMode = 0,
        EnableConnectivityLogs = 1,
        EnableMessagingLogs = 2,
        EnableLiveTrace = 3,
    }
    public partial class SignalRIPRule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SignalRIPRule() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SignalR.SignalRNetworkAclAction> Action { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SignalRKeys : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SignalRKeys() { }
        public Azure.Provisioning.BicepValue<string> PrimaryConnectionString { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> PrimaryKey { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SecondaryConnectionString { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SecondaryKey { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SignalRLiveTraceCategory : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SignalRLiveTraceCategory() { }
        public Azure.Provisioning.BicepValue<string> Enabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SignalRLiveTraceConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SignalRLiveTraceConfiguration() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SignalR.SignalRLiveTraceCategory> Categories { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Enabled { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SignalRNetworkAcl : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SignalRNetworkAcl() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SignalR.SignalRRequestType> Allow { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SignalR.SignalRRequestType> Deny { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum SignalRNetworkAclAction
    {
        Allow = 0,
        Deny = 1,
    }
    public partial class SignalRNetworkAcls : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SignalRNetworkAcls() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SignalR.SignalRNetworkAclAction> DefaultAction { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SignalR.SignalRIPRule> IPRules { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SignalR.SignalRPrivateEndpointAcl> PrivateEndpoints { get { throw null; } set { } }
        public Azure.Provisioning.SignalR.SignalRNetworkAcl PublicNetwork { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SignalRPrivateEndpointAcl : Azure.Provisioning.SignalR.SignalRNetworkAcl
    {
        public SignalRPrivateEndpointAcl() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SignalRPrivateEndpointConnection : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SignalRPrivateEndpointConnection(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.SignalR.SignalRPrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> GroupIds { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.SignalR.SignalRService Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateEndpointId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SignalR.SignalRProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SignalR.SignalRPrivateEndpointConnection FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2018_10_01;
            public static readonly string V2020_05_01;
            public static readonly string V2021_10_01;
            public static readonly string V2022_02_01;
            public static readonly string V2023_02_01;
            public static readonly string V2024_03_01;
            public static readonly string V2025_01_01_PREVIEW;
        }
    }
    [System.ObsoleteAttribute("This class is deprecated and it will be removed in a future version. Please use SignalRPrivateEndpointConnection instead.")]
    public partial class SignalRPrivateEndpointConnectionData : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SignalRPrivateEndpointConnectionData() { }
        public Azure.Provisioning.SignalR.SignalRPrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> GroupIds { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateEndpointId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SignalR.SignalRProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SignalRPrivateLinkServiceConnectionState : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SignalRPrivateLinkServiceConnectionState() { }
        public Azure.Provisioning.BicepValue<string> ActionsRequired { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SignalR.PrivateLinkServiceConnectionStatus> Status { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum SignalRProvisioningState
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
    public partial class SignalRReplica : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SignalRReplica(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.SignalR.SignalRService Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SignalR.SignalRProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> RegionEndpointEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ResourceStopped { get { throw null; } set { } }
        public Azure.Provisioning.SignalR.SignalRResourceSku Sku { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SignalR.SignalRReplica FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_01_01_PREVIEW;
        }
    }
    public partial class SignalRReplicaSharedPrivateLinkResource : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SignalRReplicaSharedPrivateLinkResource(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<string> Fqdns { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> GroupId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.SignalR.SignalRReplica Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateLinkResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SignalR.SignalRProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> RequestMessage { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SignalR.SignalRSharedPrivateLinkResourceStatus> Status { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SignalR.SignalRReplicaSharedPrivateLinkResource FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_01_01_PREVIEW;
        }
    }
    public enum SignalRRequestType
    {
        ClientConnection = 0,
        ServerConnection = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="RESTAPI")]
        RestApi = 2,
        Trace = 3,
    }
    public partial class SignalRResourceLogCategory : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SignalRResourceLogCategory() { }
        public Azure.Provisioning.BicepValue<string> Enabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SignalRResourceSku : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SignalRResourceSku() { }
        public Azure.Provisioning.BicepValue<int> Capacity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Family { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Size { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SignalR.SignalRSkuTier> Tier { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SignalRRouteSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SignalRRouteSettings() { }
        public Azure.Provisioning.BicepValue<int> ConnectionBalanceWeight { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> LatencyWeight { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> ServerBalanceWeight { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SignalRServerlessSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SignalRServerlessSettings() { }
        public Azure.Provisioning.BicepValue<int> ConnectionTimeoutInSeconds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> KeepAliveIntervalInSeconds { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SignalRService : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SignalRService(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.SignalR.SignalRApplicationFirewallSettings ApplicationFirewall { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> CorsAllowedOrigins { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> DisableAadAuth { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> DisableLocalAuth { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ExternalIP { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SignalR.SignalRFeature> Features { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> HostName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> HostNamePrefix { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsClientCertEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SignalR.SignalRServiceKind> Kind { get { throw null; } set { } }
        public Azure.Provisioning.SignalR.SignalRLiveTraceConfiguration LiveTraceConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.SignalR.SignalRNetworkAcls NetworkACLs { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SignalR.SignalRPrivateEndpointConnection> PrivateEndpointConnectionResources { get { throw null; } }
        [System.ObsoleteAttribute("This property is deprecated and it will be removed in a future version. Please use PrivateEndpointConnectionResources instead.")]
        public Azure.Provisioning.BicepList<Azure.Provisioning.SignalR.SignalRPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SignalR.SignalRProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> PublicNetworkAccess { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> PublicPort { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> RegionEndpointEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SignalR.SignalRResourceLogCategory> ResourceLogCategories { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ResourceStopped { get { throw null; } set { } }
        public Azure.Provisioning.SignalR.SignalRRouteSettings RouteSettings { get { throw null; } set { } }
        public Azure.Provisioning.SignalR.SignalRServerlessSettings Serverless { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> ServerPort { get { throw null; } }
        [System.ObsoleteAttribute("This property is deprecated and it will be removed in a future version. Please use SharedPrivateLinks instead.")]
        public Azure.Provisioning.BicepList<Azure.Provisioning.SignalR.SignalRSharedPrivateLinkResourceData> SharedPrivateLinkResources { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SignalR.SignalRSharedPrivateLink> SharedPrivateLinks { get { throw null; } }
        public Azure.Provisioning.SignalR.SignalRResourceSku Sku { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SignalR.SignalRUpstreamTemplate> UpstreamTemplates { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Version { get { throw null; } }
        public Azure.Provisioning.Authorization.RoleAssignment CreateRoleAssignment(Azure.Provisioning.SignalR.SignalRBuiltInRole role, Azure.Provisioning.BicepValue<Azure.Provisioning.Authorization.RoleManagementPrincipalType> principalType, Azure.Provisioning.BicepValue<System.Guid> principalId, string bicepIdentifierSuffix = null) { throw null; }
        public Azure.Provisioning.Authorization.RoleAssignment CreateRoleAssignment(Azure.Provisioning.SignalR.SignalRBuiltInRole role, Azure.Provisioning.Roles.UserAssignedIdentity identity) { throw null; }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SignalR.SignalRService FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public Azure.Provisioning.SignalR.SignalRKeys GetKeys() { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2018_10_01;
            public static readonly string V2020_05_01;
            public static readonly string V2021_10_01;
            public static readonly string V2022_02_01;
            public static readonly string V2023_02_01;
            public static readonly string V2024_03_01;
            public static readonly string V2025_01_01_PREVIEW;
        }
    }
    public enum SignalRServiceKind
    {
        SignalR = 0,
        RawWebSockets = 1,
    }
    public partial class SignalRSharedPrivateLink : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SignalRSharedPrivateLink(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<string> Fqdns { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> GroupId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.SignalR.SignalRService Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateLinkResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SignalR.SignalRProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> RequestMessage { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SignalR.SignalRSharedPrivateLinkResourceStatus> Status { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SignalR.SignalRSharedPrivateLink FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2018_10_01;
            public static readonly string V2020_05_01;
            public static readonly string V2021_10_01;
            public static readonly string V2022_02_01;
            public static readonly string V2023_02_01;
            public static readonly string V2024_03_01;
            public static readonly string V2025_01_01_PREVIEW;
        }
    }
    [System.ObsoleteAttribute("This class is deprecated and it will be removed in a future version. Please use SignalRSharedPrivateLink instead.")]
    public partial class SignalRSharedPrivateLinkResourceData : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SignalRSharedPrivateLinkResourceData() { }
        public Azure.Provisioning.BicepValue<string> GroupId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateLinkResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SignalR.SignalRProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> RequestMessage { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SignalR.SignalRSharedPrivateLinkResourceStatus> Status { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum SignalRSharedPrivateLinkResourceStatus
    {
        Pending = 0,
        Approved = 1,
        Rejected = 2,
        Disconnected = 3,
        Timeout = 4,
    }
    public enum SignalRSkuTier
    {
        Free = 0,
        Basic = 1,
        Standard = 2,
        Premium = 3,
    }
    public partial class SignalRThrottleByJwtCustomClaimRule : Azure.Provisioning.SignalR.SignalRClientConnectionCountRule
    {
        public SignalRThrottleByJwtCustomClaimRule() { }
        public Azure.Provisioning.BicepValue<string> ClaimName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxCount { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SignalRThrottleByJwtSignatureRule : Azure.Provisioning.SignalR.SignalRClientConnectionCountRule
    {
        public SignalRThrottleByJwtSignatureRule() { }
        public Azure.Provisioning.BicepValue<int> MaxCount { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SignalRThrottleByUserIdRule : Azure.Provisioning.SignalR.SignalRClientConnectionCountRule
    {
        public SignalRThrottleByUserIdRule() { }
        public Azure.Provisioning.BicepValue<int> MaxCount { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SignalRTrafficThrottleByJwtCustomClaimRule : Azure.Provisioning.SignalR.SignalRClientTrafficControlRule
    {
        public SignalRTrafficThrottleByJwtCustomClaimRule() { }
        public Azure.Provisioning.BicepValue<int> AggregationWindowInSeconds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ClaimName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> MaxInboundMessageBytes { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SignalRTrafficThrottleByJwtSignatureRule : Azure.Provisioning.SignalR.SignalRClientTrafficControlRule
    {
        public SignalRTrafficThrottleByJwtSignatureRule() { }
        public Azure.Provisioning.BicepValue<int> AggregationWindowInSeconds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> MaxInboundMessageBytes { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SignalRTrafficThrottleByUserIdRule : Azure.Provisioning.SignalR.SignalRClientTrafficControlRule
    {
        public SignalRTrafficThrottleByUserIdRule() { }
        public Azure.Provisioning.BicepValue<int> AggregationWindowInSeconds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> MaxInboundMessageBytes { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SignalRUpstreamAuthSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SignalRUpstreamAuthSettings() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SignalR.SignalRUpstreamAuthType> AuthType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ManagedIdentityResource { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum SignalRUpstreamAuthType
    {
        None = 0,
        ManagedIdentity = 1,
    }
    public partial class SignalRUpstreamTemplate : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SignalRUpstreamTemplate() { }
        public Azure.Provisioning.SignalR.SignalRUpstreamAuthSettings Auth { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CategoryPattern { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EventPattern { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> HubPattern { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> UrlTemplate { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
}
