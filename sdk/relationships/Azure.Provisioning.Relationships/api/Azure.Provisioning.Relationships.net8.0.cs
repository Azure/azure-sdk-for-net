namespace Azure.Provisioning.Relationships
{
    public partial class DependencyOfRelationship : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DependencyOfRelationship(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Relationships.DependencyOfRelationshipProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Primitives.ProvisionableResource Scope { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Relationships.DependencyOfRelationship FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2026_08_01;
        }
    }
    public partial class DependencyOfRelationshipProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DependencyOfRelationshipProperties() { }
        public Azure.Provisioning.Relationships.RelationshipMetadata Metadata { get { throw null; } }
        public Azure.Provisioning.Relationships.RelationshipOriginInformation OriginInformation { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Relationships.RelationshipProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SourceId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> TargetId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TargetTenant { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RelationshipMetadata : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RelationshipMetadata() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> SourceType { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> TargetType { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RelationshipOriginInformation : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RelationshipOriginInformation() { }
        public Azure.Provisioning.BicepValue<string> DiscoveryEngine { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Relationships.RelationshipOriginType> RelationshipOriginType { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum RelationshipOriginType
    {
        ServiceExplicitlyCreated = 0,
        SystemDiscoveredByRule = 1,
        UserExplicitlyCreated = 2,
        UserDiscoveredByRule = 3,
    }
    public enum RelationshipProvisioningState
    {
        Succeeded = 0,
        Failed = 1,
        Canceled = 2,
        Provisioning = 3,
        Updating = 4,
        Deleting = 5,
        Accepted = 6,
    }
    public partial class ServiceGroupMemberRelationship : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ServiceGroupMemberRelationship(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Relationships.ServiceGroupMemberRelationshipProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Primitives.ProvisionableResource Scope { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Relationships.ServiceGroupMemberRelationship FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2026_08_01;
        }
    }
    public partial class ServiceGroupMemberRelationshipProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ServiceGroupMemberRelationshipProperties() { }
        public Azure.Provisioning.Relationships.RelationshipMetadata Metadata { get { throw null; } }
        public Azure.Provisioning.Relationships.RelationshipOriginInformation OriginInformation { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Relationships.RelationshipProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SourceTenant { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> TargetId { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
}
