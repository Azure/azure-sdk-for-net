namespace Azure.Provisioning.KubernetesConfiguration.ExtensionTypes
{
    public partial class ClusterExtensionType : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal ClusterExtensionType() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.KubernetesConfiguration.ExtensionTypes.ExtensionTypeProperties Properties { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.KubernetesConfiguration.ExtensionTypes.ClusterExtensionType FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_11_01_PREVIEW;
        }
    }
    public partial class ClusterExtensionTypeVersion : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal ClusterExtensionTypeVersion() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.KubernetesConfiguration.ExtensionTypes.ClusterExtensionType Parent { get { throw null; } set { } }
        public Azure.Provisioning.KubernetesConfiguration.ExtensionTypes.ExtensionTypeVersionForReleaseTrainProperties Properties { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.KubernetesConfiguration.ExtensionTypes.ClusterExtensionTypeVersion FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_11_01_PREVIEW;
        }
    }
    public partial class ExtensionTypeClusterScopeSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ExtensionTypeClusterScopeSettings() { }
        public Azure.Provisioning.BicepValue<string> DefaultReleaseNamespace { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsMultipleInstancesAllowed { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> Type { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ExtensionTypePlanInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ExtensionTypePlanInfo() { }
        public Azure.Provisioning.BicepValue<string> OfferId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> PlanId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> PublisherId { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ExtensionTypeProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ExtensionTypeProperties() { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsManagedIdentityRequired { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsSystemExtension { get { throw null; } }
        public Azure.Provisioning.KubernetesConfiguration.ExtensionTypes.ExtensionTypePlanInfo PlanInfo { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Publisher { get { throw null; } }
        public Azure.Provisioning.BicepList<string> SupportedClusterTypes { get { throw null; } }
        public Azure.Provisioning.KubernetesConfiguration.ExtensionTypes.ExtensionTypeSupportedScopes SupportedScopes { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ExtensionTypeSupportedScopes : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ExtensionTypeSupportedScopes() { }
        public Azure.Provisioning.KubernetesConfiguration.ExtensionTypes.ExtensionTypeClusterScopeSettings ClusterScopeSettings { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DefaultScope { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ExtensionTypeUnsupportedKubernetesVersions : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ExtensionTypeUnsupportedKubernetesVersions() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.KubernetesConfiguration.ExtensionTypes.ExtensionTypeVersionUnsupportedKubernetesMatrixItem> Appliances { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.KubernetesConfiguration.ExtensionTypes.ExtensionTypeVersionUnsupportedKubernetesMatrixItem> ConnectedCluster { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.KubernetesConfiguration.ExtensionTypes.ExtensionTypeVersionUnsupportedKubernetesMatrixItem> ManagedCluster { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.KubernetesConfiguration.ExtensionTypes.ExtensionTypeVersionUnsupportedKubernetesMatrixItem> ProvisionedCluster { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ExtensionTypeVersionForReleaseTrainProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ExtensionTypeVersionForReleaseTrainProperties() { }
        public Azure.Provisioning.BicepList<string> SupportedClusterTypes { get { throw null; } }
        public Azure.Provisioning.KubernetesConfiguration.ExtensionTypes.ExtensionTypeUnsupportedKubernetesVersions UnsupportedKubernetesVersions { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Version { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ExtensionTypeVersionUnsupportedKubernetesMatrixItem : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ExtensionTypeVersionUnsupportedKubernetesMatrixItem() { }
        public Azure.Provisioning.BicepList<string> Distributions { get { throw null; } }
        public Azure.Provisioning.BicepList<string> UnsupportedVersions { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class LocationExtensionType : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal LocationExtensionType() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.KubernetesConfiguration.ExtensionTypes.ExtensionTypeProperties Properties { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.KubernetesConfiguration.ExtensionTypes.LocationExtensionType FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_11_01_PREVIEW;
        }
    }
    public partial class LocationExtensionTypeVersion : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal LocationExtensionTypeVersion() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.KubernetesConfiguration.ExtensionTypes.LocationExtensionType Parent { get { throw null; } set { } }
        public Azure.Provisioning.KubernetesConfiguration.ExtensionTypes.ExtensionTypeVersionForReleaseTrainProperties Properties { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.KubernetesConfiguration.ExtensionTypes.LocationExtensionTypeVersion FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_11_01_PREVIEW;
        }
    }
}
