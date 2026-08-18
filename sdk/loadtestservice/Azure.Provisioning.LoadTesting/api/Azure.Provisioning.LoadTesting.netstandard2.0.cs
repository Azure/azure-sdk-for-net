namespace Azure.Provisioning.LoadTesting
{
    public partial class LoadTestingCmkEncryptionProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public LoadTestingCmkEncryptionProperties() { }
        public Azure.Provisioning.LoadTesting.LoadTestingCmkIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> KeyUri { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class LoadTestingCmkIdentity : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public LoadTestingCmkIdentity() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.LoadTesting.LoadTestingCmkIdentityType> IdentityType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ResourceId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum LoadTestingCmkIdentityType
    {
        SystemAssigned = 0,
        UserAssigned = 1,
    }
    public enum LoadTestingProvisioningState
    {
        Succeeded = 0,
        Failed = 1,
        Canceled = 2,
        Deleted = 3,
    }
    public partial class LoadTestingQuota : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal LoadTestingQuota() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> Limit { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.LoadTesting.LoadTestingProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> Usage { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.LoadTesting.LoadTestingQuota FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2022_12_01;
        }
    }
    public partial class LoadTestingResource : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public LoadTestingResource(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> DataPlaneUri { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.LoadTesting.LoadTestingCmkEncryptionProperties Encryption { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.LoadTesting.LoadTestingProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.LoadTesting.LoadTestingResource FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2022_12_01;
        }
    }
}
