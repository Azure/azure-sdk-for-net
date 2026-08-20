namespace Azure.Provisioning.KubernetesConfiguration.ExtensionTypes
{
    public partial class ClusterExtensionType : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal ClusterExtensionType() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.KubernetesConfiguration.ExtensionTypes.KubernetesConfigurationExtensionTypeProperties Properties { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.KubernetesConfiguration.ExtensionTypes.ClusterExtensionType FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2024_11_01_PREVIEW;
        }
    }
    public partial class ClusterExtensionTypeVersion : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal ClusterExtensionTypeVersion() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.KubernetesConfiguration.ExtensionTypes.ClusterExtensionType Parent { get { throw null; } set { } }
        public Azure.Provisioning.KubernetesConfiguration.ExtensionTypes.KubernetesConfigurationExtensionTypeVersionForReleaseTrainProperties Properties { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.KubernetesConfiguration.ExtensionTypes.ClusterExtensionTypeVersion FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2024_11_01_PREVIEW;
        }
    }
    public partial class KubernetesConfigurationExtensionTypeClusterScopeSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public KubernetesConfigurationExtensionTypeClusterScopeSettings() { }
        public Azure.Provisioning.BicepValue<string> DefaultReleaseNamespace { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsMultipleInstancesAllowed { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> Type { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class KubernetesConfigurationExtensionTypePlanInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public KubernetesConfigurationExtensionTypePlanInfo() { }
        public Azure.Provisioning.BicepValue<string> OfferId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> PlanId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> PublisherId { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class KubernetesConfigurationExtensionTypeProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public KubernetesConfigurationExtensionTypeProperties() { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsManagedIdentityRequired { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsSystemExtension { get { throw null; } }
        public Azure.Provisioning.KubernetesConfiguration.ExtensionTypes.KubernetesConfigurationExtensionTypePlanInfo PlanInfo { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Publisher { get { throw null; } }
        public Azure.Provisioning.BicepList<string> SupportedClusterTypes { get { throw null; } }
        public Azure.Provisioning.KubernetesConfiguration.ExtensionTypes.KubernetesConfigurationExtensionTypeSupportedScopes SupportedScopes { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class KubernetesConfigurationExtensionTypeSupportedScopes : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public KubernetesConfigurationExtensionTypeSupportedScopes() { }
        public Azure.Provisioning.KubernetesConfiguration.ExtensionTypes.KubernetesConfigurationExtensionTypeClusterScopeSettings ClusterScopeSettings { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DefaultScope { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class KubernetesConfigurationExtensionTypeUnsupportedKubernetesVersions : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public KubernetesConfigurationExtensionTypeUnsupportedKubernetesVersions() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.KubernetesConfiguration.ExtensionTypes.KubernetesConfigurationExtensionTypeVersionUnsupportedKubernetesMatrixItem> Appliances { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.KubernetesConfiguration.ExtensionTypes.KubernetesConfigurationExtensionTypeVersionUnsupportedKubernetesMatrixItem> ConnectedCluster { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.KubernetesConfiguration.ExtensionTypes.KubernetesConfigurationExtensionTypeVersionUnsupportedKubernetesMatrixItem> ManagedCluster { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.KubernetesConfiguration.ExtensionTypes.KubernetesConfigurationExtensionTypeVersionUnsupportedKubernetesMatrixItem> ProvisionedCluster { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class KubernetesConfigurationExtensionTypeVersionForReleaseTrainProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public KubernetesConfigurationExtensionTypeVersionForReleaseTrainProperties() { }
        public Azure.Provisioning.BicepList<string> SupportedClusterTypes { get { throw null; } }
        public Azure.Provisioning.KubernetesConfiguration.ExtensionTypes.KubernetesConfigurationExtensionTypeUnsupportedKubernetesVersions UnsupportedKubernetesVersions { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Version { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class KubernetesConfigurationExtensionTypeVersionUnsupportedKubernetesMatrixItem : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public KubernetesConfigurationExtensionTypeVersionUnsupportedKubernetesMatrixItem() { }
        public Azure.Provisioning.BicepList<string> Distributions { get { throw null; } }
        public Azure.Provisioning.BicepList<string> UnsupportedVersions { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class LocationExtensionType : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal LocationExtensionType() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.KubernetesConfiguration.ExtensionTypes.KubernetesConfigurationExtensionTypeProperties Properties { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.KubernetesConfiguration.ExtensionTypes.LocationExtensionType FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2024_11_01_PREVIEW;
        }
    }
    public partial class LocationExtensionTypeVersion : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal LocationExtensionTypeVersion() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.KubernetesConfiguration.ExtensionTypes.LocationExtensionType Parent { get { throw null; } set { } }
        public Azure.Provisioning.KubernetesConfiguration.ExtensionTypes.KubernetesConfigurationExtensionTypeVersionForReleaseTrainProperties Properties { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.KubernetesConfiguration.ExtensionTypes.LocationExtensionTypeVersion FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2024_11_01_PREVIEW;
        }
    }
}
