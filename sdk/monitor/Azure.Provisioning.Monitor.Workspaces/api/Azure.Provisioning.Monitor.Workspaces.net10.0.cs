namespace Azure.Provisioning.Monitor.Workspaces
{
    public partial class IssueCreationNotificationType : Azure.Provisioning.Monitor.Workspaces.IssueNotificationType
    {
        public IssueCreationNotificationType() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class IssueInvestigationMetadata : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public IssueInvestigationMetadata() { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> Id { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class IssueNotifications : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public IssueNotifications() { }
        public Azure.Provisioning.BicepList<Azure.Core.ResourceIdentifier> ActionGroupIds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> ShouldExcludeDefaultActionGroups { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.Workspaces.IssueNotificationType> UpdateTypes { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class IssueNotificationType : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public IssueNotificationType() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MonitorIssue : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public MonitorIssue(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Monitor.Workspaces.MonitorWorkspace Parent { get { throw null; } set { } }
        public Azure.Provisioning.Monitor.Workspaces.MonitorIssueProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Monitor.Workspaces.MonitorIssue FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_10_03;
        }
    }
    public partial class MonitorIssueBackground : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MonitorIssueBackground() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.Workspaces.MonitorIssueBackgroundDetails> Details { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Text { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Type { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MonitorIssueBackgroundDetails : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MonitorIssueBackgroundDetails() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MonitorIssueProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MonitorIssueProperties() { }
        public Azure.Provisioning.Monitor.Workspaces.MonitorIssueBackground Background { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ImpactOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.Workspaces.IssueInvestigationMetadata> Investigations { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> InvestigationsCount { get { throw null; } }
        public Azure.Provisioning.Monitor.Workspaces.IssueNotifications Notifications { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Monitor.Workspaces.MonitorWorkspaceProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Severity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Monitor.Workspaces.MonitorIssueStatus> Status { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Title { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum MonitorIssueStatus
    {
        New = 0,
        InProgress = 1,
        Mitigated = 2,
        Closed = 3,
        Canceled = 4,
    }
    public partial class MonitorMetricsContainer : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public MonitorMetricsContainer(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Monitor.Workspaces.MonitorWorkspace Parent { get { throw null; } set { } }
        public Azure.Provisioning.Monitor.Workspaces.MonitorMetricsContainerProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Monitor.Workspaces.MonitorMetricsContainer FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_10_03;
        }
    }
    public partial class MonitorMetricsContainerProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MonitorMetricsContainerProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Monitor.Workspaces.MonitorWorkspaceProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Version { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MonitorWorkspace : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public MonitorWorkspace(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Monitor.Workspaces.MonitorWorkspaceProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Monitor.Workspaces.MonitorWorkspace FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_10_03;
        }
    }
    public partial class MonitorWorkspaceDefaultIngestionSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MonitorWorkspaceDefaultIngestionSettings() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> DataCollectionEndpointResourceId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DataCollectionRuleImmutableId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> DataCollectionRuleResourceId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> IngestionEndpointsMetrics { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MonitorWorkspaceMetrics : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MonitorWorkspaceMetrics() { }
        public Azure.Provisioning.BicepValue<bool> EnableAccessUsingResourcePermissions { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> InternalId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> PrometheusQueryEndpoint { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MonitorWorkspacePrivateEndpointConnection : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MonitorWorkspacePrivateEndpointConnection() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.Monitor.Workspaces.MonitorWorkspacePrivateEndpointConnectionProperties Properties { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> Type { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MonitorWorkspacePrivateEndpointConnectionProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MonitorWorkspacePrivateEndpointConnectionProperties() { }
        public Azure.Provisioning.BicepList<string> GroupIds { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateEndpointId { get { throw null; } }
        public Azure.Provisioning.Monitor.Workspaces.MonitorWorkspacePrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Monitor.Workspaces.MonitorWorkspacePrivateEndpointConnectionProvisioningState> ProvisioningState { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum MonitorWorkspacePrivateEndpointConnectionProvisioningState
    {
        Succeeded = 0,
        Creating = 1,
        Deleting = 2,
        Failed = 3,
    }
    public enum MonitorWorkspacePrivateEndpointServiceConnectionStatus
    {
        Pending = 0,
        Approved = 1,
        Rejected = 2,
    }
    public partial class MonitorWorkspacePrivateLinkServiceConnectionState : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MonitorWorkspacePrivateLinkServiceConnectionState() { }
        public Azure.Provisioning.BicepValue<string> ActionsRequired { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Monitor.Workspaces.MonitorWorkspacePrivateEndpointServiceConnectionStatus> Status { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MonitorWorkspaceProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MonitorWorkspaceProperties() { }
        public Azure.Provisioning.BicepValue<string> AccountId { get { throw null; } }
        public Azure.Provisioning.Monitor.Workspaces.MonitorWorkspaceDefaultIngestionSettings DefaultIngestionSettings { get { throw null; } }
        public Azure.Provisioning.Monitor.Workspaces.MonitorWorkspaceMetrics Metrics { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.Workspaces.MonitorWorkspacePrivateEndpointConnection> PrivateEndpointConnections { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Monitor.Workspaces.MonitorWorkspaceProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Monitor.Workspaces.MonitorWorkspacePublicNetworkAccess> PublicNetworkAccess { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum MonitorWorkspaceProvisioningState
    {
        Succeeded = 0,
        Failed = 1,
        Canceled = 2,
    }
    public enum MonitorWorkspacePublicNetworkAccess
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class OnChangeNotificationType : Azure.Provisioning.Monitor.Workspaces.IssueNotificationType
    {
        public OnChangeNotificationType() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class TimeBasedUpdatesNotificationType : Azure.Provisioning.Monitor.Workspaces.IssueNotificationType
    {
        public TimeBasedUpdatesNotificationType() { }
        public Azure.Provisioning.BicepValue<string> UpdateInterval { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
}
