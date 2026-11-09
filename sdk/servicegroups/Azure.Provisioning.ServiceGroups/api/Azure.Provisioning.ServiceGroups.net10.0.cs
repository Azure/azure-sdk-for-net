namespace Azure.Provisioning.ServiceGroups
{
    public partial class ServiceGroup : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ServiceGroup(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ServiceGroups.ServiceGroupProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ServiceGroups.ServiceGroup FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2026_08_01;
        }
    }
    public partial class ServiceGroupProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ServiceGroupProperties() { }
        public Azure.Provisioning.BicepValue<int> AttributesCriticality { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ParentResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ServiceGroups.ServiceGroupProvisioningState> ProvisioningState { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ServiceGroupProvisioningState
    {
        NotStarted = 0,
        Running = 1,
        Succeeded = 2,
        Failed = 3,
        Canceled = 4,
    }
}
