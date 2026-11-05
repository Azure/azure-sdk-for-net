namespace Azure.Provisioning.Fabric
{
    public partial class CapacityOverageProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CapacityOverageProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Fabric.CapacityOverageState> State { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> ThresholdCapacityUnitHours { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum CapacityOverageState
    {
        Disabled = 0,
        Enabled = 1,
    }
    public partial class FabricCapacity : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public FabricCapacity(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Fabric.FabricCapacityProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Fabric.FabricSku Sku { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Fabric.FabricCapacity FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2023_11_01;
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2025_01_15_PREVIEW;
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2026_09_01_PREVIEW;
        }
    }
    public partial class FabricCapacityProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public FabricCapacityProperties() { }
        public Azure.Provisioning.BicepList<string> AdministrationMembers { get { throw null; } set { } }
        public Azure.Provisioning.Fabric.CapacityOverageProperties Overage { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Fabric.FabricProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Fabric.FabricResourceState> State { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum FabricProvisioningState
    {
        Succeeded = 0,
        Failed = 1,
        Canceled = 2,
        Deleting = 3,
        Provisioning = 4,
        Updating = 5,
    }
    public enum FabricResourceState
    {
        Active = 0,
        Provisioning = 1,
        Failed = 2,
        Updating = 3,
        Deleting = 4,
        Suspending = 5,
        Suspended = 6,
        Pausing = 7,
        Paused = 8,
        Resuming = 9,
        Scaling = 10,
        Preparing = 11,
    }
    public partial class FabricSku : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public FabricSku() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Fabric.FabricSkuTier> Tier { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum FabricSkuTier
    {
        Fabric = 0,
    }
}
