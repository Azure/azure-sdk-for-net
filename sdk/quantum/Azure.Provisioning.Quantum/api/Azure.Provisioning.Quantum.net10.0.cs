namespace Azure.Provisioning.Quantum
{
    public partial class MoboBrokerInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MoboBrokerInfo() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ProviderProvisioningStatus
    {
        Succeeded = 0,
        Failed = 1,
        Canceled = 2,
        ProviderLaunching = 3,
        ProviderUpdating = 4,
        ProviderDeleting = 5,
        ProviderProvisioning = 6,
    }
    public partial class QuantumProvider : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public QuantumProvider() { }
        public Azure.Provisioning.BicepValue<string> ApplicationName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> InstanceUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProviderId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProviderSku { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Quantum.QuantumProvisioningStatus> ProvisioningState { get { throw null; } set { } }
        public Azure.Provisioning.Quantum.QuantumQuotaAllocations Quotas { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ResourceUsageId { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Quantum.TargetQuotaAllocations> TargetQuotas { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum QuantumProvisioningStatus
    {
        Succeeded = 0,
        Launching = 1,
        Updating = 2,
        Deleting = 3,
        Deleted = 4,
        Failed = 5,
    }
    public partial class QuantumQuotaAllocations : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public QuantumQuotaAllocations() { }
        public Azure.Provisioning.BicepValue<int> HighMinutesLifetime { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> StandardMinutesLifetime { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class QuantumWorkspace : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public QuantumWorkspace(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Quantum.QuantumWorkspaceProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Quantum.QuantumWorkspace FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2025_12_15_PREVIEW;
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2026_06_15_PREVIEW;
        }
    }
    public enum QuantumWorkspaceKind
    {
        V1 = 0,
        V2 = 1,
    }
    public partial class QuantumWorkspaceProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public QuantumWorkspaceProperties() { }
        public Azure.Provisioning.BicepValue<System.Uri> EndpointUri { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsApiKeyEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Quantum.MoboBrokerInfo> ManagedOnBehalfOfMoboBrokerResources { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ManagedStorageAccount { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Quantum.QuantumProvider> Providers { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Quantum.ProviderProvisioningStatus> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> StorageAccount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Quantum.WorkspaceUsableStatus> Usable { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Quantum.QuantumWorkspaceKind> WorkspaceKind { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class TargetQuotaAllocations : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public TargetQuotaAllocations() { }
        public Azure.Provisioning.BicepValue<int> HighMinutesLifetime { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> StandardMinutesLifetime { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TargetId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum WorkspaceUsableStatus
    {
        Yes = 0,
        No = 1,
        Partial = 2,
    }
}
