namespace Azure.Provisioning.DurableTask
{
    public partial class DurableTaskHub : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DurableTaskHub(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.DurableTask.DurableTaskScheduler Parent { get { throw null; } set { } }
        public Azure.Provisioning.DurableTask.DurableTaskHubProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.DurableTask.DurableTaskHub FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_11_01;
            public static readonly string V2026_02_01;
        }
    }
    public partial class DurableTaskHubProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DurableTaskHubProperties() { }
        public Azure.Provisioning.BicepValue<System.Uri> DashboardUri { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DurableTask.DurableTaskProvisioningState> ProvisioningState { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DurableTaskPrivateEndpointConnection : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DurableTaskPrivateEndpointConnection(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.DurableTask.DurableTaskScheduler Parent { get { throw null; } set { } }
        public Azure.Provisioning.DurableTask.DurableTaskPrivateEndpointConnectionProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.DurableTask.DurableTaskPrivateEndpointConnection FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2026_02_01;
        }
    }
    public partial class DurableTaskPrivateEndpointConnectionProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DurableTaskPrivateEndpointConnectionProperties() { }
        public Azure.Provisioning.BicepList<string> GroupIds { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateEndpointId { get { throw null; } }
        public Azure.Provisioning.DurableTask.DurableTaskPrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DurableTask.DurableTaskPrivateEndpointConnectionProvisioningState> ProvisioningState { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DurableTaskPrivateEndpointConnectionProvisioningState
    {
        Succeeded = 0,
        Creating = 1,
        Deleting = 2,
        Failed = 3,
    }
    public enum DurableTaskPrivateEndpointServiceConnectionStatus
    {
        Pending = 0,
        Approved = 1,
        Rejected = 2,
    }
    public partial class DurableTaskPrivateLinkResourceProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DurableTaskPrivateLinkResourceProperties() { }
        public Azure.Provisioning.BicepValue<string> GroupId { get { throw null; } }
        public Azure.Provisioning.BicepList<string> RequiredMembers { get { throw null; } }
        public Azure.Provisioning.BicepList<string> RequiredZoneNames { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DurableTaskPrivateLinkServiceConnectionState : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DurableTaskPrivateLinkServiceConnectionState() { }
        public Azure.Provisioning.BicepValue<string> ActionsRequired { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DurableTask.DurableTaskPrivateEndpointServiceConnectionStatus> Status { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DurableTaskProvisioningState
    {
        Succeeded = 0,
        Failed = 1,
        Canceled = 2,
        Provisioning = 3,
        Updating = 4,
        Deleting = 5,
        Accepted = 6,
    }
    public enum DurableTaskPublicNetworkAccess
    {
        Enabled = 0,
        Disabled = 1,
    }
    public enum DurableTaskPurgeableOrchestrationState
    {
        Completed = 0,
        Failed = 1,
        Terminated = 2,
        Canceled = 3,
    }
    public enum DurableTaskResourceRedundancyState
    {
        None = 0,
        Zone = 1,
    }
    public partial class DurableTaskRetentionPolicy : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DurableTaskRetentionPolicy(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.DurableTask.DurableTaskScheduler Parent { get { throw null; } set { } }
        public Azure.Provisioning.DurableTask.DurableTaskRetentionPolicyProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.DurableTask.DurableTaskRetentionPolicy FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_11_01;
            public static readonly string V2026_02_01;
        }
    }
    public partial class DurableTaskRetentionPolicyDetails : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DurableTaskRetentionPolicyDetails() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DurableTask.DurableTaskPurgeableOrchestrationState> OrchestrationState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> RetentionPeriodInDays { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DurableTaskRetentionPolicyProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DurableTaskRetentionPolicyProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DurableTask.DurableTaskProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DurableTask.DurableTaskRetentionPolicyDetails> RetentionPolicies { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DurableTaskScheduler : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DurableTaskScheduler(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.DurableTask.DurableTaskSchedulerProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.DurableTask.DurableTaskScheduler FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_11_01;
            public static readonly string V2026_02_01;
        }
    }
    public partial class DurableTaskSchedulerPrivateLinkResource : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DurableTaskSchedulerPrivateLinkResource(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.DurableTask.DurableTaskScheduler Parent { get { throw null; } set { } }
        public Azure.Provisioning.DurableTask.DurableTaskPrivateLinkResourceProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.DurableTask.DurableTaskSchedulerPrivateLinkResource FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2026_02_01;
        }
    }
    public partial class DurableTaskSchedulerProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DurableTaskSchedulerProperties() { }
        public Azure.Provisioning.BicepValue<string> Endpoint { get { throw null; } }
        public Azure.Provisioning.BicepList<string> IPAllowlist { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DurableTask.DurableTaskPrivateEndpointConnection> PrivateEndpointConnections { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DurableTask.DurableTaskProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DurableTask.DurableTaskPublicNetworkAccess> PublicNetworkAccess { get { throw null; } set { } }
        public Azure.Provisioning.DurableTask.DurableTaskSchedulerSku Sku { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DurableTaskSchedulerSku : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DurableTaskSchedulerSku() { }
        public Azure.Provisioning.BicepValue<int> Capacity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DurableTask.DurableTaskSchedulerSkuName> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DurableTask.DurableTaskResourceRedundancyState> RedundancyState { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DurableTaskSchedulerSkuName
    {
        Dedicated = 0,
        Consumption = 1,
    }
}
