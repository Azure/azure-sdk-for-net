namespace Azure.Provisioning.KubernetesConfiguration.PrivateLinkScopes
{
    public partial class KubernetesConfigurationPrivateLinkScope : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public KubernetesConfigurationPrivateLinkScope(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.KubernetesConfiguration.PrivateLinkScopes.KubernetesConfigurationPrivateLinkScopeProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.KubernetesConfiguration.PrivateLinkScopes.KubernetesConfigurationPrivateLinkScope FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2024_11_01_PREVIEW;
        }
    }
    public partial class KubernetesConfigurationPrivateLinkScopeProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public KubernetesConfigurationPrivateLinkScopeProperties() { }
        public Azure.Provisioning.BicepValue<string> ClusterResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.KubernetesConfiguration.PrivateLinkScopes.KubernetesConfigurationPrivateLinkScopesPrivateEndpointConnection> PrivateEndpointConnections { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> PrivateLinkScopeId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.KubernetesConfiguration.PrivateLinkScopes.ProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.KubernetesConfiguration.PrivateLinkScopes.PublicNetworkAccessType> PublicNetworkAccess { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class KubernetesConfigurationPrivateLinkScopesPrivateEndpointConnection : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public KubernetesConfigurationPrivateLinkScopesPrivateEndpointConnection(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.KubernetesConfiguration.PrivateLinkScopes.KubernetesConfigurationPrivateLinkScope Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PrivateEndpointId { get { throw null; } }
        public Azure.Provisioning.KubernetesConfiguration.PrivateLinkScopes.KubernetesConfigurationPrivateLinkScopesPrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.KubernetesConfiguration.PrivateLinkScopes.KubernetesConfigurationPrivateLinkScopesPrivateEndpointConnectionProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.KubernetesConfiguration.PrivateLinkScopes.KubernetesConfigurationPrivateLinkScopesPrivateEndpointConnection FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2024_11_01_PREVIEW;
        }
    }
    public enum KubernetesConfigurationPrivateLinkScopesPrivateEndpointConnectionProvisioningState
    {
        Succeeded = 0,
        Creating = 1,
        Deleting = 2,
        Failed = 3,
    }
    public enum KubernetesConfigurationPrivateLinkScopesPrivateEndpointServiceConnectionStatus
    {
        Pending = 0,
        Approved = 1,
        Rejected = 2,
    }
    public partial class KubernetesConfigurationPrivateLinkScopesPrivateLinkResource : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal KubernetesConfigurationPrivateLinkScopesPrivateLinkResource() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> GroupId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.KubernetesConfiguration.PrivateLinkScopes.KubernetesConfigurationPrivateLinkScope Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> RequiredMembers { get { throw null; } }
        public Azure.Provisioning.BicepList<string> RequiredZoneNames { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.KubernetesConfiguration.PrivateLinkScopes.KubernetesConfigurationPrivateLinkScopesPrivateLinkResource FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2024_11_01_PREVIEW;
        }
    }
    public partial class KubernetesConfigurationPrivateLinkScopesPrivateLinkServiceConnectionState : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public KubernetesConfigurationPrivateLinkScopesPrivateLinkServiceConnectionState() { }
        public Azure.Provisioning.BicepValue<string> ActionsRequired { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.KubernetesConfiguration.PrivateLinkScopes.KubernetesConfigurationPrivateLinkScopesPrivateEndpointServiceConnectionStatus> Status { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ProvisioningState
    {
        Succeeded = 0,
        Failed = 1,
        Canceled = 2,
        Creating = 3,
        Updating = 4,
        Deleting = 5,
    }
    public enum PublicNetworkAccessType
    {
        Enabled = 0,
        Disabled = 1,
    }
}
