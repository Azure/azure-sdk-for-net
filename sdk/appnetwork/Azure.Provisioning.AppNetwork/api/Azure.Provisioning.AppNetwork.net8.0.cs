namespace Azure.Provisioning.AppNetwork
{
    public partial class AppLink : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public AppLink(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppNetwork.AppLinkProvisioningState> AppLinkProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AppNetwork.AppLink FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2025_08_01_PREVIEW;
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2026_08_01_PREVIEW;
        }
    }
    public enum AppLinkClusterType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="AKS")]
        Aks = 0,
    }
    public partial class AppLinkConnectivityProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AppLinkConnectivityProfile() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppNetwork.AppLinkEastWestGatewayVisibility> EastWestGatewayVisibility { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Network { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateConnectSubnetResourceId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum AppLinkEastWestGatewayVisibility
    {
        Internal = 0,
        External = 1,
    }
    public partial class AppLinkMember : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public AppLinkMember(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.AppNetwork.AppLink Parent { get { throw null; } set { } }
        public Azure.Provisioning.AppNetwork.AppLinkMemberProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AppNetwork.AppLinkMember FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2025_08_01_PREVIEW;
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2026_08_01_PREVIEW;
        }
    }
    public partial class AppLinkMemberProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AppLinkMemberProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppNetwork.AppLinkClusterType> ClusterType { get { throw null; } set { } }
        public Azure.Provisioning.AppNetwork.AppLinkConnectivityProfile ConnectivityProfile { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> MetadataResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ObservabilityMetricsEndpoint { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppNetwork.AppLinkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.AppNetwork.AppLinkUpgradeProfile UpgradeProfile { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum AppLinkProvisioningState
    {
        Succeeded = 0,
        Failed = 1,
        Canceled = 2,
        Provisioning = 3,
        Updating = 4,
        Deleting = 5,
        Accepted = 6,
    }
    public enum AppLinkUpgradeMode
    {
        FullyManaged = 0,
        SelfManaged = 1,
    }
    public partial class AppLinkUpgradeProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AppLinkUpgradeProfile() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppNetwork.AppLinkUpgradeReleaseChannel> FullyManagedUpgradeReleaseChannel { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppNetwork.AppLinkUpgradeMode> Mode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SelfManagedUpgradeVersion { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum AppLinkUpgradeReleaseChannel
    {
        Rapid = 0,
        Stable = 1,
    }
}
