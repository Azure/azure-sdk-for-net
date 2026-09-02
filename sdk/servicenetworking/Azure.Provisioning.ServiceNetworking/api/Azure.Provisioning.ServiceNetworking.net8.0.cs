namespace Azure.Provisioning.ServiceNetworking
{
    public partial class ApplicationGatewayForContainersSecurityPolicy : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ApplicationGatewayForContainersSecurityPolicy(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ServiceNetworking.TrafficController Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ServiceNetworking.ApplicationGatewayForContainersSecurityPolicyType> PolicyType { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ServiceNetworking.ServiceNetworkingProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> WafPolicyId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ServiceNetworking.ApplicationGatewayForContainersSecurityPolicy FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_01_01;
        }
    }
    public enum ApplicationGatewayForContainersSecurityPolicyType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="waf")]
        WAF = 0,
    }
    public enum ServiceNetworkingProvisioningState
    {
        Provisioning = 0,
        Updating = 1,
        Deleting = 2,
        Accepted = 3,
        Succeeded = 4,
        Failed = 5,
        Canceled = 6,
    }
    public partial class TrafficController : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public TrafficController(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.SubResource> Associations { get { throw null; } }
        public Azure.Provisioning.BicepList<string> ConfigurationEndpoints { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.SubResource> Frontends { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.SubResource> SecurityPolicies { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ServiceNetworking.ServiceNetworkingProvisioningState> TrafficControllerProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> WafSecurityPolicyId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ServiceNetworking.TrafficController FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2023_11_01;
            public static readonly string V2025_01_01;
        }
    }
    public partial class TrafficControllerAssociation : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public TrafficControllerAssociation(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ServiceNetworking.TrafficControllerAssociationType> AssociationType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ServiceNetworking.TrafficController Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ServiceNetworking.ServiceNetworkingProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SubnetId { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ServiceNetworking.TrafficControllerAssociation FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2023_11_01;
            public static readonly string V2025_01_01;
        }
    }
    public enum TrafficControllerAssociationType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="subnets")]
        Subnets = 0,
    }
    public partial class TrafficControllerFrontend : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public TrafficControllerFrontend(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Fqdn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ServiceNetworking.TrafficController Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ServiceNetworking.ServiceNetworkingProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ServiceNetworking.TrafficControllerFrontend FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2023_11_01;
            public static readonly string V2025_01_01;
        }
    }
}
