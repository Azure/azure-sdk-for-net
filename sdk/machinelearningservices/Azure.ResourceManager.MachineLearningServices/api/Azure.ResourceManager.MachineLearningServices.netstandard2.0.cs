namespace Azure.ResourceManager.MachineLearningServices
{
    public partial class AccountKeyDatastoreCredentials : Azure.ResourceManager.MachineLearningServices.DatastoreCredentials
    {
        public AccountKeyDatastoreCredentials() { }
        public Azure.ResourceManager.MachineLearningServices.AccountKeyDatastoreSecrets Secrets { get { throw null; } set { } }
    }
    public partial class AccountKeyDatastoreSecrets : Azure.ResourceManager.MachineLearningServices.DatastoreSecrets
    {
        public AccountKeyDatastoreSecrets() { }
        public string Key { get { throw null; } set { } }
    }
    public partial class AKS : Azure.ResourceManager.MachineLearningServices.Compute
    {
        public AKS() { }
        public Azure.ResourceManager.MachineLearningServices.AKSProperties Properties { get { throw null; } set { } }
    }
    public partial class AksComputeSecrets : Azure.ResourceManager.MachineLearningServices.ComputeSecrets
    {
        internal AksComputeSecrets() { }
        public string AdminKubeConfig { get { throw null; } }
        public string ImagePullSecretName { get { throw null; } }
        public string UserKubeConfig { get { throw null; } }
    }
    public partial class AksNetworkingConfiguration
    {
        public AksNetworkingConfiguration() { }
        public string DnsServiceIP { get { throw null; } set { } }
        public string DockerBridgeCidr { get { throw null; } set { } }
        public string ServiceCidr { get { throw null; } set { } }
        public string SubnetId { get { throw null; } set { } }
    }
    public partial class AKSProperties
    {
        public AKSProperties() { }
        public int? AgentCount { get { throw null; } set { } }
        public string AgentVmSize { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.AksNetworkingConfiguration AksNetworkingConfiguration { get { throw null; } set { } }
        public string ClusterFqdn { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.ClusterPurpose? ClusterPurpose { get { throw null; } set { } }
        public string LoadBalancerSubnet { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.LoadBalancerType? LoadBalancerType { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.SslConfiguration SslConfiguration { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearningServices.SystemService> SystemServices { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AllocationState : System.IEquatable<Azure.ResourceManager.MachineLearningServices.AllocationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AllocationState(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.AllocationState Resizing { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.AllocationState Steady { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.AllocationState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.AllocationState left, Azure.ResourceManager.MachineLearningServices.AllocationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.AllocationState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.AllocationState left, Azure.ResourceManager.MachineLearningServices.AllocationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AmlCompute : Azure.ResourceManager.MachineLearningServices.Compute
    {
        public AmlCompute() { }
        public Azure.ResourceManager.MachineLearningServices.AmlComputeProperties Properties { get { throw null; } set { } }
    }
    public partial class AmlComputeNodeInformation
    {
        internal AmlComputeNodeInformation() { }
        public string NodeId { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.NodeState? NodeState { get { throw null; } }
        public int? Port { get { throw null; } }
        public string PrivateIpAddress { get { throw null; } }
        public string PublicIpAddress { get { throw null; } }
        public string RunId { get { throw null; } }
    }
    public partial class AmlComputeProperties
    {
        public AmlComputeProperties() { }
        public Azure.ResourceManager.MachineLearningServices.AllocationState? AllocationState { get { throw null; } }
        public System.DateTimeOffset? AllocationStateTransitionTime { get { throw null; } }
        public int? CurrentNodeCount { get { throw null; } }
        public bool? EnableNodePublicIp { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearningServices.ErrorResponse> Errors { get { throw null; } }
        public bool? IsolatedNetwork { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.NodeStateCounts NodeStateCounts { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.OsType? OsType { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.RemoteLoginPortPublicAccess? RemoteLoginPortPublicAccess { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.ScaleSettings ScaleSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.ResourceId Subnet { get { throw null; } set { } }
        public int? TargetNodeCount { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.UserAccountCredentials UserAccountCredentials { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.VirtualMachineImage VirtualMachineImage { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.VmPriority? VmPriority { get { throw null; } set { } }
        public string VmSize { get { throw null; } set { } }
    }
    public partial class AmlToken : Azure.ResourceManager.MachineLearningServices.IdentityConfiguration
    {
        public AmlToken() { }
    }
    public partial class AmlUserFeature : Azure.ResourceManager.Core.SubResource<Azure.ResourceManager.Core.ResourceIdentifier>
    {
        internal AmlUserFeature() { }
        public string Description { get { throw null; } }
        public string DisplayName { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ApplicationSharingPolicy : System.IEquatable<Azure.ResourceManager.MachineLearningServices.ApplicationSharingPolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ApplicationSharingPolicy(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.ApplicationSharingPolicy Personal { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.ApplicationSharingPolicy Shared { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.ApplicationSharingPolicy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.ApplicationSharingPolicy left, Azure.ResourceManager.MachineLearningServices.ApplicationSharingPolicy right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.ApplicationSharingPolicy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.ApplicationSharingPolicy left, Azure.ResourceManager.MachineLearningServices.ApplicationSharingPolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public static partial class ArmClientExtensions
    {
        public static Azure.ResourceManager.MachineLearningServices.RestApiContainer GetMachineLearningServicesRestApis(this Azure.ResourceManager.Core.ArmClient armClient) { throw null; }
    }
    public partial class AssetReferenceBase
    {
        public AssetReferenceBase() { }
    }
    public partial class AssignedUser
    {
        public AssignedUser(string objectId, string tenantId) { }
        public string ObjectId { get { throw null; } set { } }
        public string TenantId { get { throw null; } set { } }
    }
    public partial class AutoPauseProperties
    {
        public AutoPauseProperties() { }
        public int? DelayInMinutes { get { throw null; } set { } }
        public bool? Enabled { get { throw null; } set { } }
    }
    public partial class AutoScaleProperties
    {
        public AutoScaleProperties() { }
        public bool? Enabled { get { throw null; } set { } }
        public int? MaxNodeCount { get { throw null; } set { } }
        public int? MinNodeCount { get { throw null; } set { } }
    }
    public partial class AutoScaleSettings : Azure.ResourceManager.MachineLearningServices.OnlineScaleSettings
    {
        public AutoScaleSettings() { }
        public System.TimeSpan? PollingInterval { get { throw null; } set { } }
        public int? TargetUtilizationPercentage { get { throw null; } set { } }
    }
    public partial class AzureBlobContents : Azure.ResourceManager.MachineLearningServices.DatastoreContents
    {
        public AzureBlobContents(string accountName, string containerName, Azure.ResourceManager.MachineLearningServices.DatastoreCredentials credentials, string endpoint, string protocol) { }
        public string AccountName { get { throw null; } set { } }
        public string ContainerName { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.DatastoreCredentials Credentials { get { throw null; } set { } }
        public string Endpoint { get { throw null; } set { } }
        public string Protocol { get { throw null; } set { } }
    }
    public partial class AzureDataLakeGen1Contents : Azure.ResourceManager.MachineLearningServices.DatastoreContents
    {
        public AzureDataLakeGen1Contents(Azure.ResourceManager.MachineLearningServices.DatastoreCredentials credentials, string storeName) { }
        public Azure.ResourceManager.MachineLearningServices.DatastoreCredentials Credentials { get { throw null; } set { } }
        public string StoreName { get { throw null; } set { } }
    }
    public partial class AzureDataLakeGen2Contents : Azure.ResourceManager.MachineLearningServices.DatastoreContents
    {
        public AzureDataLakeGen2Contents(string accountName, string containerName, Azure.ResourceManager.MachineLearningServices.DatastoreCredentials credentials, string endpoint, string protocol) { }
        public string AccountName { get { throw null; } set { } }
        public string ContainerName { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.DatastoreCredentials Credentials { get { throw null; } set { } }
        public string Endpoint { get { throw null; } set { } }
        public string Protocol { get { throw null; } set { } }
    }
    public partial class AzureFileContents : Azure.ResourceManager.MachineLearningServices.DatastoreContents
    {
        public AzureFileContents(string accountName, string containerName, Azure.ResourceManager.MachineLearningServices.DatastoreCredentials credentials, string endpoint, string protocol) { }
        public string AccountName { get { throw null; } set { } }
        public string ContainerName { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.DatastoreCredentials Credentials { get { throw null; } set { } }
        public string Endpoint { get { throw null; } set { } }
        public string Protocol { get { throw null; } set { } }
    }
    public partial class AzurePostgreSqlContents : Azure.ResourceManager.MachineLearningServices.DatastoreContents
    {
        public AzurePostgreSqlContents(Azure.ResourceManager.MachineLearningServices.DatastoreCredentials credentials, string databaseName, string endpoint, int portNumber, string serverName) { }
        public Azure.ResourceManager.MachineLearningServices.DatastoreCredentials Credentials { get { throw null; } set { } }
        public string DatabaseName { get { throw null; } set { } }
        public bool? EnableSSL { get { throw null; } set { } }
        public string Endpoint { get { throw null; } set { } }
        public int PortNumber { get { throw null; } set { } }
        public string ServerName { get { throw null; } set { } }
    }
    public partial class AzureSqlDatabaseContents : Azure.ResourceManager.MachineLearningServices.DatastoreContents
    {
        public AzureSqlDatabaseContents(Azure.ResourceManager.MachineLearningServices.DatastoreCredentials credentials, string databaseName, string endpoint, int portNumber, string serverName) { }
        public Azure.ResourceManager.MachineLearningServices.DatastoreCredentials Credentials { get { throw null; } set { } }
        public string DatabaseName { get { throw null; } set { } }
        public string Endpoint { get { throw null; } set { } }
        public int PortNumber { get { throw null; } set { } }
        public string ServerName { get { throw null; } set { } }
    }
    public partial class BanditPolicy : Azure.ResourceManager.MachineLearningServices.EarlyTerminationPolicy
    {
        public BanditPolicy() { }
        public float? SlackAmount { get { throw null; } set { } }
        public float? SlackFactor { get { throw null; } set { } }
    }
    public partial class BatchDeployment
    {
        public BatchDeployment() { }
        public Azure.ResourceManager.MachineLearningServices.CodeConfiguration CodeConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.ComputeConfiguration Compute { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string EnvironmentId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> EnvironmentVariables { get { throw null; } }
        public int? ErrorThreshold { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.BatchLoggingLevel? LoggingLevel { get { throw null; } set { } }
        public long? MiniBatchSize { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.AssetReferenceBase Model { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.BatchOutputConfiguration OutputConfiguration { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> PartitionKeys { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Properties { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.BatchRetrySettings RetrySettings { get { throw null; } set { } }
    }
    public partial class BatchDeploymentsCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.MachineLearningServices.BatchDeploymentTrackedResource>
    {
        protected BatchDeploymentsCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.MachineLearningServices.BatchDeploymentTrackedResource Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.BatchDeploymentTrackedResource>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.BatchDeploymentTrackedResource>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BatchDeploymentsDeleteOperation : Azure.Operation
    {
        protected BatchDeploymentsDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BatchDeploymentsUpdateOperation : Azure.Operation<Azure.ResourceManager.MachineLearningServices.BatchDeploymentTrackedResource>
    {
        protected BatchDeploymentsUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.MachineLearningServices.BatchDeploymentTrackedResource Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.BatchDeploymentTrackedResource>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.BatchDeploymentTrackedResource>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BatchDeploymentTrackedResource : Azure.ResourceManager.MachineLearningServices.BatchDeploymentTrackedResourceOperations
    {
        internal BatchDeploymentTrackedResource() { }
        public Azure.ResourceManager.MachineLearningServices.BatchDeploymentTrackedResourceData Data { get { throw null; } }
        protected override Azure.ResourceManager.MachineLearningServices.BatchDeploymentTrackedResource GetResource(System.Threading.CancellationToken cancellation = default(System.Threading.CancellationToken)) { throw null; }
        protected override System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.BatchDeploymentTrackedResource> GetResourceAsync(System.Threading.CancellationToken cancellation = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BatchDeploymentTrackedResourceContainer : Azure.ResourceManager.Core.ResourceContainerBase<Azure.ResourceManager.Core.ResourceGroupResourceIdentifier, Azure.ResourceManager.MachineLearningServices.BatchDeploymentTrackedResource, Azure.ResourceManager.MachineLearningServices.BatchDeploymentTrackedResourceData>
    {
        protected BatchDeploymentTrackedResourceContainer() { }
        public new Azure.ResourceManager.Core.ResourceGroupResourceIdentifier Id { get { throw null; } }
        protected override Azure.ResourceManager.Core.ResourceType ValidResourceType { get { throw null; } }
        public Azure.Response<Azure.ResourceManager.MachineLearningServices.BatchDeploymentTrackedResource> CreateOrUpdate(string workspaceName, Azure.ResourceManager.MachineLearningServices.BatchDeploymentTrackedResourceData body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.BatchDeploymentTrackedResource>> CreateOrUpdateAsync(string workspaceName, Azure.ResourceManager.MachineLearningServices.BatchDeploymentTrackedResourceData body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Response<Azure.ResourceManager.MachineLearningServices.BatchDeploymentTrackedResource> Get(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.BatchDeploymentTrackedResource>> GetAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Pageable<Azure.ResourceManager.MachineLearningServices.BatchDeploymentTrackedResource> List(string orderBy = null, int? top = default(int?), string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Pageable<Azure.ResourceManager.Core.GenericResourceExpanded> ListAsGenericResource(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.AsyncPageable<Azure.ResourceManager.Core.GenericResourceExpanded> ListAsGenericResourceAsync(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.BatchDeploymentTrackedResource> ListAsync(string orderBy = null, int? top = default(int?), string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.ResourceManager.MachineLearningServices.BatchDeploymentsCreateOrUpdateOperation StartCreateOrUpdate(string workspaceName, Azure.ResourceManager.MachineLearningServices.BatchDeploymentTrackedResourceData body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.BatchDeploymentsCreateOrUpdateOperation> StartCreateOrUpdateAsync(string workspaceName, Azure.ResourceManager.MachineLearningServices.BatchDeploymentTrackedResourceData body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BatchDeploymentTrackedResourceData : Azure.ResourceManager.Core.TrackedResource<Azure.ResourceManager.Core.ResourceGroupResourceIdentifier>
    {
        public BatchDeploymentTrackedResourceData(Azure.ResourceManager.Core.LocationData location, Azure.ResourceManager.MachineLearningServices.BatchDeployment properties) { }
        public Azure.ResourceManager.MachineLearningServices.ResourceIdentity Identity { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.BatchDeployment Properties { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.SystemData SystemData { get { throw null; } }
    }
    public partial class BatchDeploymentTrackedResourceOperations : Azure.ResourceManager.Core.ResourceOperationsBase<Azure.ResourceManager.Core.ResourceGroupResourceIdentifier, Azure.ResourceManager.MachineLearningServices.BatchDeploymentTrackedResource>
    {
        public static readonly Azure.ResourceManager.Core.ResourceType ResourceType;
        protected BatchDeploymentTrackedResourceOperations() { }
        protected internal BatchDeploymentTrackedResourceOperations(Azure.ResourceManager.Core.ResourceOperationsBase options, Azure.ResourceManager.Core.ResourceGroupResourceIdentifier id) { }
        protected override Azure.ResourceManager.Core.ResourceType ValidResourceType { get { throw null; } }
        public Azure.Response<Azure.ResourceManager.MachineLearningServices.BatchDeploymentTrackedResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.BatchDeploymentTrackedResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Response Delete(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Response> DeleteAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response<Azure.ResourceManager.MachineLearningServices.BatchDeploymentTrackedResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.BatchDeploymentTrackedResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Collections.Generic.IEnumerable<Azure.ResourceManager.Core.LocationData> ListAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Core.LocationData>> ListAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Response<Azure.ResourceManager.MachineLearningServices.BatchDeploymentTrackedResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.BatchDeploymentTrackedResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Response<Azure.ResourceManager.MachineLearningServices.BatchDeploymentTrackedResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.BatchDeploymentTrackedResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.ResourceManager.MachineLearningServices.BatchDeploymentsUpdateOperation StartAddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.BatchDeploymentsUpdateOperation> StartAddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Operation StartDelete(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Operation> StartDeleteAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.ResourceManager.MachineLearningServices.BatchDeploymentsUpdateOperation StartRemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.BatchDeploymentsUpdateOperation> StartRemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.ResourceManager.MachineLearningServices.BatchDeploymentsUpdateOperation StartSetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.BatchDeploymentsUpdateOperation> StartSetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BatchEndpoint
    {
        public BatchEndpoint() { }
        public Azure.ResourceManager.MachineLearningServices.EndpointAuthMode? AuthMode { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.EndpointAuthKeys Keys { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Properties { get { throw null; } }
        public string ScoringUri { get { throw null; } }
        public string SwaggerUri { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, int> Traffic { get { throw null; } }
    }
    public partial class BatchEndpointsCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.MachineLearningServices.BatchEndpointTrackedResource>
    {
        protected BatchEndpointsCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.MachineLearningServices.BatchEndpointTrackedResource Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.BatchEndpointTrackedResource>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.BatchEndpointTrackedResource>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BatchEndpointsDeleteOperation : Azure.Operation
    {
        protected BatchEndpointsDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BatchEndpointsUpdateOperation : Azure.Operation<Azure.ResourceManager.MachineLearningServices.BatchEndpointTrackedResource>
    {
        protected BatchEndpointsUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.MachineLearningServices.BatchEndpointTrackedResource Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.BatchEndpointTrackedResource>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.BatchEndpointTrackedResource>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BatchEndpointTrackedResource : Azure.ResourceManager.MachineLearningServices.BatchEndpointTrackedResourceOperations
    {
        internal BatchEndpointTrackedResource() { }
        public Azure.ResourceManager.MachineLearningServices.BatchEndpointTrackedResourceData Data { get { throw null; } }
        protected override Azure.ResourceManager.MachineLearningServices.BatchEndpointTrackedResource GetResource(System.Threading.CancellationToken cancellation = default(System.Threading.CancellationToken)) { throw null; }
        protected override System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.BatchEndpointTrackedResource> GetResourceAsync(System.Threading.CancellationToken cancellation = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BatchEndpointTrackedResourceContainer : Azure.ResourceManager.Core.ResourceContainerBase<Azure.ResourceManager.Core.ResourceGroupResourceIdentifier, Azure.ResourceManager.MachineLearningServices.BatchEndpointTrackedResource, Azure.ResourceManager.MachineLearningServices.BatchEndpointTrackedResourceData>
    {
        protected BatchEndpointTrackedResourceContainer() { }
        public new Azure.ResourceManager.Core.ResourceGroupResourceIdentifier Id { get { throw null; } }
        protected override Azure.ResourceManager.Core.ResourceType ValidResourceType { get { throw null; } }
        public Azure.Response<Azure.ResourceManager.MachineLearningServices.BatchEndpointTrackedResource> CreateOrUpdate(string workspaceName, Azure.ResourceManager.MachineLearningServices.BatchEndpointTrackedResourceData body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.BatchEndpointTrackedResource>> CreateOrUpdateAsync(string workspaceName, Azure.ResourceManager.MachineLearningServices.BatchEndpointTrackedResourceData body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Response<Azure.ResourceManager.MachineLearningServices.BatchEndpointTrackedResource> Get(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.BatchEndpointTrackedResource>> GetAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Pageable<Azure.ResourceManager.MachineLearningServices.BatchEndpointTrackedResource> List(int? count = default(int?), string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Pageable<Azure.ResourceManager.Core.GenericResourceExpanded> ListAsGenericResource(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.AsyncPageable<Azure.ResourceManager.Core.GenericResourceExpanded> ListAsGenericResourceAsync(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.BatchEndpointTrackedResource> ListAsync(int? count = default(int?), string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.EndpointAuthKeys> ListKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.EndpointAuthKeys>> ListKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.ResourceManager.MachineLearningServices.BatchEndpointsCreateOrUpdateOperation StartCreateOrUpdate(string workspaceName, Azure.ResourceManager.MachineLearningServices.BatchEndpointTrackedResourceData body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.BatchEndpointsCreateOrUpdateOperation> StartCreateOrUpdateAsync(string workspaceName, Azure.ResourceManager.MachineLearningServices.BatchEndpointTrackedResourceData body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BatchEndpointTrackedResourceData : Azure.ResourceManager.Core.TrackedResource<Azure.ResourceManager.Core.ResourceGroupResourceIdentifier>
    {
        public BatchEndpointTrackedResourceData(Azure.ResourceManager.Core.LocationData location, Azure.ResourceManager.MachineLearningServices.BatchEndpoint properties) { }
        public Azure.ResourceManager.MachineLearningServices.ResourceIdentity Identity { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.BatchEndpoint Properties { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.SystemData SystemData { get { throw null; } }
    }
    public partial class BatchEndpointTrackedResourceOperations : Azure.ResourceManager.Core.ResourceOperationsBase<Azure.ResourceManager.Core.ResourceGroupResourceIdentifier, Azure.ResourceManager.MachineLearningServices.BatchEndpointTrackedResource>
    {
        public static readonly Azure.ResourceManager.Core.ResourceType ResourceType;
        protected BatchEndpointTrackedResourceOperations() { }
        protected internal BatchEndpointTrackedResourceOperations(Azure.ResourceManager.Core.ResourceOperationsBase options, Azure.ResourceManager.Core.ResourceGroupResourceIdentifier id) { }
        protected override Azure.ResourceManager.Core.ResourceType ValidResourceType { get { throw null; } }
        public Azure.Response<Azure.ResourceManager.MachineLearningServices.BatchEndpointTrackedResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.BatchEndpointTrackedResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Response Delete(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Response> DeleteAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response<Azure.ResourceManager.MachineLearningServices.BatchEndpointTrackedResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.BatchEndpointTrackedResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.ResourceManager.MachineLearningServices.BatchDeploymentTrackedResourceContainer GetBatchDeploymentTrackedResources() { throw null; }
        public System.Collections.Generic.IEnumerable<Azure.ResourceManager.Core.LocationData> ListAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Core.LocationData>> ListAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Response<Azure.ResourceManager.MachineLearningServices.BatchEndpointTrackedResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.BatchEndpointTrackedResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Response<Azure.ResourceManager.MachineLearningServices.BatchEndpointTrackedResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.BatchEndpointTrackedResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.ResourceManager.MachineLearningServices.BatchEndpointsUpdateOperation StartAddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.BatchEndpointsUpdateOperation> StartAddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Operation StartDelete(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Operation> StartDeleteAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.ResourceManager.MachineLearningServices.BatchEndpointsUpdateOperation StartRemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.BatchEndpointsUpdateOperation> StartRemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.ResourceManager.MachineLearningServices.BatchEndpointsUpdateOperation StartSetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.BatchEndpointsUpdateOperation> StartSetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BatchLoggingLevel : System.IEquatable<Azure.ResourceManager.MachineLearningServices.BatchLoggingLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BatchLoggingLevel(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.BatchLoggingLevel Debug { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.BatchLoggingLevel Info { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.BatchLoggingLevel Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.BatchLoggingLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.BatchLoggingLevel left, Azure.ResourceManager.MachineLearningServices.BatchLoggingLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.BatchLoggingLevel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.BatchLoggingLevel left, Azure.ResourceManager.MachineLearningServices.BatchLoggingLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BatchOutputAction : System.IEquatable<Azure.ResourceManager.MachineLearningServices.BatchOutputAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BatchOutputAction(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.BatchOutputAction AppendRow { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.BatchOutputAction SummaryOnly { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.BatchOutputAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.BatchOutputAction left, Azure.ResourceManager.MachineLearningServices.BatchOutputAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.BatchOutputAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.BatchOutputAction left, Azure.ResourceManager.MachineLearningServices.BatchOutputAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BatchOutputConfiguration
    {
        public BatchOutputConfiguration() { }
        public string AppendRowFileName { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.BatchOutputAction? OutputAction { get { throw null; } set { } }
    }
    public partial class BatchRetrySettings
    {
        public BatchRetrySettings() { }
        public int? MaxRetries { get { throw null; } set { } }
        public System.TimeSpan? Timeout { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BillingCurrency : System.IEquatable<Azure.ResourceManager.MachineLearningServices.BillingCurrency>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BillingCurrency(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.BillingCurrency USD { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.BillingCurrency other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.BillingCurrency left, Azure.ResourceManager.MachineLearningServices.BillingCurrency right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.BillingCurrency (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.BillingCurrency left, Azure.ResourceManager.MachineLearningServices.BillingCurrency right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CertificateDatastoreCredentials : Azure.ResourceManager.MachineLearningServices.DatastoreCredentials
    {
        public CertificateDatastoreCredentials(System.Guid clientId, System.Guid tenantId, string thumbprint) { }
        public string AuthorityUrl { get { throw null; } set { } }
        public System.Guid ClientId { get { throw null; } set { } }
        public string ResourceUri { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.CertificateDatastoreSecrets Secrets { get { throw null; } set { } }
        public System.Guid TenantId { get { throw null; } set { } }
        public string Thumbprint { get { throw null; } set { } }
    }
    public partial class CertificateDatastoreSecrets : Azure.ResourceManager.MachineLearningServices.DatastoreSecrets
    {
        public CertificateDatastoreSecrets() { }
        public string Certificate { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClusterPurpose : System.IEquatable<Azure.ResourceManager.MachineLearningServices.ClusterPurpose>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClusterPurpose(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.ClusterPurpose DenseProd { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.ClusterPurpose DevTest { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.ClusterPurpose FastProd { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.ClusterPurpose other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.ClusterPurpose left, Azure.ResourceManager.MachineLearningServices.ClusterPurpose right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.ClusterPurpose (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.ClusterPurpose left, Azure.ResourceManager.MachineLearningServices.ClusterPurpose right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CocoExportSummary : Azure.ResourceManager.MachineLearningServices.ExportSummary
    {
        public CocoExportSummary() { }
        public string ContainerName { get { throw null; } }
        public string SnapshotPath { get { throw null; } }
    }
    public partial class CodeConfiguration
    {
        public CodeConfiguration(string scoringScript) { }
        public string CodeId { get { throw null; } set { } }
        public string ScoringScript { get { throw null; } set { } }
    }
    public partial class CodeContainer
    {
        public CodeContainer() { }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Properties { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class CodeContainerResource : Azure.ResourceManager.MachineLearningServices.CodeContainerResourceOperations
    {
        internal CodeContainerResource() { }
        public Azure.ResourceManager.MachineLearningServices.CodeContainerResourceData Data { get { throw null; } }
        protected override Azure.ResourceManager.MachineLearningServices.CodeContainerResource GetResource(System.Threading.CancellationToken cancellation = default(System.Threading.CancellationToken)) { throw null; }
        protected override System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.CodeContainerResource> GetResourceAsync(System.Threading.CancellationToken cancellation = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CodeContainerResourceContainer : Azure.ResourceManager.Core.ResourceContainerBase<Azure.ResourceManager.Core.ResourceGroupResourceIdentifier, Azure.ResourceManager.MachineLearningServices.CodeContainerResource, Azure.ResourceManager.MachineLearningServices.CodeContainerResourceData>
    {
        protected CodeContainerResourceContainer() { }
        public new Azure.ResourceManager.Core.ResourceGroupResourceIdentifier Id { get { throw null; } }
        protected override Azure.ResourceManager.Core.ResourceType ValidResourceType { get { throw null; } }
        public Azure.Response<Azure.ResourceManager.MachineLearningServices.CodeContainerResource> CreateOrUpdate(string workspaceName, Azure.ResourceManager.MachineLearningServices.CodeContainer properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.CodeContainerResource>> CreateOrUpdateAsync(string workspaceName, Azure.ResourceManager.MachineLearningServices.CodeContainer properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Response<Azure.ResourceManager.MachineLearningServices.CodeContainerResource> Get(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.CodeContainerResource>> GetAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Pageable<Azure.ResourceManager.MachineLearningServices.CodeContainerResource> List(string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Pageable<Azure.ResourceManager.Core.GenericResourceExpanded> ListAsGenericResource(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.AsyncPageable<Azure.ResourceManager.Core.GenericResourceExpanded> ListAsGenericResourceAsync(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.CodeContainerResource> ListAsync(string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.ResourceManager.MachineLearningServices.CodeContainersCreateOrUpdateOperation StartCreateOrUpdate(string workspaceName, Azure.ResourceManager.MachineLearningServices.CodeContainer properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.CodeContainersCreateOrUpdateOperation> StartCreateOrUpdateAsync(string workspaceName, Azure.ResourceManager.MachineLearningServices.CodeContainer properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CodeContainerResourceData : Azure.ResourceManager.Core.Resource<Azure.ResourceManager.Core.ResourceGroupResourceIdentifier>
    {
        public CodeContainerResourceData(Azure.ResourceManager.MachineLearningServices.CodeContainer properties) { }
        public Azure.ResourceManager.MachineLearningServices.CodeContainer Properties { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.SystemData SystemData { get { throw null; } }
    }
    public partial class CodeContainerResourceOperations : Azure.ResourceManager.Core.ResourceOperationsBase<Azure.ResourceManager.Core.ResourceGroupResourceIdentifier, Azure.ResourceManager.MachineLearningServices.CodeContainerResource>
    {
        public static readonly Azure.ResourceManager.Core.ResourceType ResourceType;
        protected CodeContainerResourceOperations() { }
        protected internal CodeContainerResourceOperations(Azure.ResourceManager.Core.ResourceOperationsBase options, Azure.ResourceManager.Core.ResourceGroupResourceIdentifier id) { }
        protected override Azure.ResourceManager.Core.ResourceType ValidResourceType { get { throw null; } }
        public Azure.Response Delete(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Response> DeleteAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response<Azure.ResourceManager.MachineLearningServices.CodeContainerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.CodeContainerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.ResourceManager.MachineLearningServices.CodeVersionResourceContainer GetCodeVersionResources() { throw null; }
        public System.Collections.Generic.IEnumerable<Azure.ResourceManager.Core.LocationData> ListAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Core.LocationData>> ListAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Operation StartDelete(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Operation> StartDeleteAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CodeContainersCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.MachineLearningServices.CodeContainerResource>
    {
        protected CodeContainersCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.MachineLearningServices.CodeContainerResource Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.CodeContainerResource>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.CodeContainerResource>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CodeContainersDeleteOperation : Azure.Operation
    {
        protected CodeContainersDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CodeVersion
    {
        public CodeVersion(string path) { }
        public string DatastoreId { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public bool? IsAnonymous { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Properties { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class CodeVersionResource : Azure.ResourceManager.MachineLearningServices.CodeVersionResourceOperations
    {
        internal CodeVersionResource() { }
        public Azure.ResourceManager.MachineLearningServices.CodeVersionResourceData Data { get { throw null; } }
        protected override Azure.ResourceManager.MachineLearningServices.CodeVersionResource GetResource(System.Threading.CancellationToken cancellation = default(System.Threading.CancellationToken)) { throw null; }
        protected override System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.CodeVersionResource> GetResourceAsync(System.Threading.CancellationToken cancellation = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CodeVersionResourceContainer : Azure.ResourceManager.Core.ResourceContainerBase<Azure.ResourceManager.Core.ResourceGroupResourceIdentifier, Azure.ResourceManager.MachineLearningServices.CodeVersionResource, Azure.ResourceManager.MachineLearningServices.CodeVersionResourceData>
    {
        protected CodeVersionResourceContainer() { }
        public new Azure.ResourceManager.Core.ResourceGroupResourceIdentifier Id { get { throw null; } }
        protected override Azure.ResourceManager.Core.ResourceType ValidResourceType { get { throw null; } }
        public Azure.Response<Azure.ResourceManager.MachineLearningServices.CodeVersionResource> CreateOrUpdate(string workspaceName, Azure.ResourceManager.MachineLearningServices.CodeVersion properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.CodeVersionResource>> CreateOrUpdateAsync(string workspaceName, Azure.ResourceManager.MachineLearningServices.CodeVersion properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Response<Azure.ResourceManager.MachineLearningServices.CodeVersionResource> Get(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.CodeVersionResource>> GetAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Pageable<Azure.ResourceManager.MachineLearningServices.CodeVersionResource> List(string orderBy = null, int? top = default(int?), string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Pageable<Azure.ResourceManager.Core.GenericResourceExpanded> ListAsGenericResource(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.AsyncPageable<Azure.ResourceManager.Core.GenericResourceExpanded> ListAsGenericResourceAsync(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.CodeVersionResource> ListAsync(string orderBy = null, int? top = default(int?), string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.ResourceManager.MachineLearningServices.CodeVersionsCreateOrUpdateOperation StartCreateOrUpdate(string workspaceName, Azure.ResourceManager.MachineLearningServices.CodeVersion properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.CodeVersionsCreateOrUpdateOperation> StartCreateOrUpdateAsync(string workspaceName, Azure.ResourceManager.MachineLearningServices.CodeVersion properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CodeVersionResourceData : Azure.ResourceManager.Core.Resource<Azure.ResourceManager.Core.ResourceGroupResourceIdentifier>
    {
        public CodeVersionResourceData(Azure.ResourceManager.MachineLearningServices.CodeVersion properties) { }
        public Azure.ResourceManager.MachineLearningServices.CodeVersion Properties { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.SystemData SystemData { get { throw null; } }
    }
    public partial class CodeVersionResourceOperations : Azure.ResourceManager.Core.ResourceOperationsBase<Azure.ResourceManager.Core.ResourceGroupResourceIdentifier, Azure.ResourceManager.MachineLearningServices.CodeVersionResource>
    {
        public static readonly Azure.ResourceManager.Core.ResourceType ResourceType;
        protected CodeVersionResourceOperations() { }
        protected internal CodeVersionResourceOperations(Azure.ResourceManager.Core.ResourceOperationsBase options, Azure.ResourceManager.Core.ResourceGroupResourceIdentifier id) { }
        protected override Azure.ResourceManager.Core.ResourceType ValidResourceType { get { throw null; } }
        public Azure.Response Delete(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Response> DeleteAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response<Azure.ResourceManager.MachineLearningServices.CodeVersionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.CodeVersionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Collections.Generic.IEnumerable<Azure.ResourceManager.Core.LocationData> ListAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Core.LocationData>> ListAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Operation StartDelete(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Operation> StartDeleteAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CodeVersionsCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.MachineLearningServices.CodeVersionResource>
    {
        protected CodeVersionsCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.MachineLearningServices.CodeVersionResource Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.CodeVersionResource>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.CodeVersionResource>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CodeVersionsDeleteOperation : Azure.Operation
    {
        protected CodeVersionsDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CommandJob : Azure.ResourceManager.MachineLearningServices.JobBase
    {
        public CommandJob(string command, Azure.ResourceManager.MachineLearningServices.ComputeConfiguration compute) { }
        public string CodeId { get { throw null; } set { } }
        public string Command { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.ComputeConfiguration Compute { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.DistributionConfiguration Distribution { get { throw null; } set { } }
        public string EnvironmentId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> EnvironmentVariables { get { throw null; } }
        public string ExperimentName { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.IdentityConfiguration Identity { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.MachineLearningServices.InputDataBinding> InputDataBindings { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.JobOutput Output { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.MachineLearningServices.OutputDataBinding> OutputDataBindings { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, object> Parameters { get { throw null; } }
        public int? Priority { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.JobStatus? Status { get { throw null; } }
        public System.TimeSpan? Timeout { get { throw null; } set { } }
    }
    public partial class Components1D3SwueSchemasComputeresourceAllof1
    {
        public Components1D3SwueSchemasComputeresourceAllof1() { }
        public Azure.ResourceManager.MachineLearningServices.Compute Properties { get { throw null; } set { } }
    }
    public partial class Compute
    {
        public Compute() { }
        public string ComputeLocation { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public bool? DisableLocalAuth { get { throw null; } set { } }
        public bool? IsAttachedCompute { get { throw null; } }
        public System.DateTimeOffset? ModifiedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearningServices.ErrorResponse> ProvisioningErrors { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.ProvisioningState? ProvisioningState { get { throw null; } }
        public string ResourceId { get { throw null; } set { } }
    }
    public partial class ComputeConfiguration
    {
        public ComputeConfiguration() { }
        public int? InstanceCount { get { throw null; } set { } }
        public string InstanceType { get { throw null; } set { } }
        public bool? IsLocal { get { throw null; } set { } }
        public string Location { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Properties { get { throw null; } }
        public string Target { get { throw null; } set { } }
    }
    public partial class ComputeCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.MachineLearningServices.ComputeResource>
    {
        protected ComputeCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.MachineLearningServices.ComputeResource Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.ComputeResource>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.ComputeResource>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ComputeDeleteOperation : Azure.Operation
    {
        protected ComputeDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ComputeInstance : Azure.ResourceManager.MachineLearningServices.Compute
    {
        public ComputeInstance() { }
        public Azure.ResourceManager.MachineLearningServices.ComputeInstanceProperties Properties { get { throw null; } set { } }
    }
    public partial class ComputeInstanceApplication
    {
        internal ComputeInstanceApplication() { }
        public string DisplayName { get { throw null; } }
        public string EndpointUri { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeInstanceAuthorizationType : System.IEquatable<Azure.ResourceManager.MachineLearningServices.ComputeInstanceAuthorizationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeInstanceAuthorizationType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.ComputeInstanceAuthorizationType Personal { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.ComputeInstanceAuthorizationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.ComputeInstanceAuthorizationType left, Azure.ResourceManager.MachineLearningServices.ComputeInstanceAuthorizationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.ComputeInstanceAuthorizationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.ComputeInstanceAuthorizationType left, Azure.ResourceManager.MachineLearningServices.ComputeInstanceAuthorizationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ComputeInstanceConnectivityEndpoints
    {
        internal ComputeInstanceConnectivityEndpoints() { }
        public string PrivateIpAddress { get { throw null; } }
        public string PublicIpAddress { get { throw null; } }
    }
    public partial class ComputeInstanceCreatedBy
    {
        internal ComputeInstanceCreatedBy() { }
        public string UserId { get { throw null; } }
        public string UserName { get { throw null; } }
        public string UserOrgId { get { throw null; } }
    }
    public partial class ComputeInstanceLastOperation
    {
        internal ComputeInstanceLastOperation() { }
        public Azure.ResourceManager.MachineLearningServices.OperationName? OperationName { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.OperationStatus? OperationStatus { get { throw null; } }
        public System.DateTimeOffset? OperationTime { get { throw null; } }
    }
    public partial class ComputeInstanceProperties
    {
        public ComputeInstanceProperties() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearningServices.ComputeInstanceApplication> Applications { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.ApplicationSharingPolicy? ApplicationSharingPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.ComputeInstanceAuthorizationType? ComputeInstanceAuthorizationType { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.ComputeInstanceConnectivityEndpoints ConnectivityEndpoints { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.ComputeInstanceCreatedBy CreatedBy { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearningServices.ErrorResponse> Errors { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.ComputeInstanceLastOperation LastOperation { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.PersonalComputeInstanceSettings PersonalComputeInstanceSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.ComputeSchedules Schedules { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.SetupScripts SetupScripts { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.ComputeInstanceSshSettings SshSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.ComputeInstanceState? State { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.ResourceId Subnet { get { throw null; } set { } }
        public string VmSize { get { throw null; } set { } }
    }
    public partial class ComputeInstanceSshSettings
    {
        public ComputeInstanceSshSettings() { }
        public string AdminPublicKey { get { throw null; } set { } }
        public string AdminUserName { get { throw null; } }
        public int? SshPort { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.SshPublicAccess? SshPublicAccess { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeInstanceState : System.IEquatable<Azure.ResourceManager.MachineLearningServices.ComputeInstanceState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeInstanceState(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.ComputeInstanceState CreateFailed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.ComputeInstanceState Creating { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.ComputeInstanceState Deleting { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.ComputeInstanceState JobRunning { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.ComputeInstanceState Restarting { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.ComputeInstanceState Running { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.ComputeInstanceState SettingUp { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.ComputeInstanceState SetupFailed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.ComputeInstanceState Starting { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.ComputeInstanceState Stopped { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.ComputeInstanceState Stopping { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.ComputeInstanceState Unknown { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.ComputeInstanceState Unusable { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.ComputeInstanceState UserSettingUp { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.ComputeInstanceState UserSetupFailed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.ComputeInstanceState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.ComputeInstanceState left, Azure.ResourceManager.MachineLearningServices.ComputeInstanceState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.ComputeInstanceState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.ComputeInstanceState left, Azure.ResourceManager.MachineLearningServices.ComputeInstanceState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputePowerAction : System.IEquatable<Azure.ResourceManager.MachineLearningServices.ComputePowerAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputePowerAction(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.ComputePowerAction Start { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.ComputePowerAction Stop { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.ComputePowerAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.ComputePowerAction left, Azure.ResourceManager.MachineLearningServices.ComputePowerAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.ComputePowerAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.ComputePowerAction left, Azure.ResourceManager.MachineLearningServices.ComputePowerAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ComputeResource : Azure.ResourceManager.MachineLearningServices.ComputeResourceOperations
    {
        internal ComputeResource() { }
        public Azure.ResourceManager.MachineLearningServices.ComputeResourceData Data { get { throw null; } }
        protected override Azure.ResourceManager.MachineLearningServices.ComputeResource GetResource(System.Threading.CancellationToken cancellation = default(System.Threading.CancellationToken)) { throw null; }
        protected override System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.ComputeResource> GetResourceAsync(System.Threading.CancellationToken cancellation = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ComputeResourceContainer : Azure.ResourceManager.Core.ResourceContainerBase<Azure.ResourceManager.Core.ResourceGroupResourceIdentifier, Azure.ResourceManager.MachineLearningServices.ComputeResource, Azure.ResourceManager.MachineLearningServices.ComputeResourceData>
    {
        protected ComputeResourceContainer() { }
        public new Azure.ResourceManager.Core.ResourceGroupResourceIdentifier Id { get { throw null; } }
        protected override Azure.ResourceManager.Core.ResourceType ValidResourceType { get { throw null; } }
        public Azure.Response<Azure.ResourceManager.MachineLearningServices.ComputeResource> CreateOrUpdate(string computeName, Azure.ResourceManager.MachineLearningServices.ComputeResourceData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.ComputeResource>> CreateOrUpdateAsync(string computeName, Azure.ResourceManager.MachineLearningServices.ComputeResourceData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Response<Azure.ResourceManager.MachineLearningServices.ComputeResource> Get(string computeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.ComputeResource>> GetAsync(string computeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Pageable<Azure.ResourceManager.MachineLearningServices.ComputeResource> List(string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Pageable<Azure.ResourceManager.Core.GenericResourceExpanded> ListAsGenericResource(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.AsyncPageable<Azure.ResourceManager.Core.GenericResourceExpanded> ListAsGenericResourceAsync(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.ComputeResource> ListAsync(string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.ComputeSecrets> ListKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.ComputeSecrets>> ListKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.ResourceManager.MachineLearningServices.ComputeCreateOrUpdateOperation StartCreateOrUpdate(string computeName, Azure.ResourceManager.MachineLearningServices.ComputeResourceData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.ComputeCreateOrUpdateOperation> StartCreateOrUpdateAsync(string computeName, Azure.ResourceManager.MachineLearningServices.ComputeResourceData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ComputeResourceData : Azure.ResourceManager.Core.Resource<Azure.ResourceManager.Core.ResourceGroupResourceIdentifier>
    {
        public ComputeResourceData() { }
        public Azure.ResourceManager.MachineLearningServices.Identity Identity { get { throw null; } set { } }
        public string Location { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Compute Properties { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Sku Sku { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.SystemData SystemData { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class ComputeResourceOperations : Azure.ResourceManager.Core.ResourceOperationsBase<Azure.ResourceManager.Core.ResourceGroupResourceIdentifier, Azure.ResourceManager.MachineLearningServices.ComputeResource>
    {
        public static readonly Azure.ResourceManager.Core.ResourceType ResourceType;
        protected ComputeResourceOperations() { }
        protected internal ComputeResourceOperations(Azure.ResourceManager.Core.ResourceOperationsBase options, Azure.ResourceManager.Core.ResourceGroupResourceIdentifier id) { }
        protected override Azure.ResourceManager.Core.ResourceType ValidResourceType { get { throw null; } }
        public Azure.Response Delete(Azure.ResourceManager.MachineLearningServices.UnderlyingResourceAction underlyingResourceAction, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Response> DeleteAsync(Azure.ResourceManager.MachineLearningServices.UnderlyingResourceAction underlyingResourceAction, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response<Azure.ResourceManager.MachineLearningServices.ComputeResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.ComputeResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Collections.Generic.IEnumerable<Azure.ResourceManager.Core.LocationData> ListAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Core.LocationData>> ListAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Restart(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RestartAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Response Start(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Response> StartAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Operation StartDelete(Azure.ResourceManager.MachineLearningServices.UnderlyingResourceAction underlyingResourceAction, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Operation> StartDeleteAsync(Azure.ResourceManager.MachineLearningServices.UnderlyingResourceAction underlyingResourceAction, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Operation StartStart(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Operation> StartStartAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Operation StartStop(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Operation> StartStopAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.ResourceManager.MachineLearningServices.ComputeUpdateOperation StartUpdate(Azure.ResourceManager.MachineLearningServices.ScaleSettings scaleSettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.ComputeUpdateOperation> StartUpdateAsync(Azure.ResourceManager.MachineLearningServices.ScaleSettings scaleSettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Response Stop(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Response> StopAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Response<Azure.ResourceManager.MachineLearningServices.ComputeResource> Update(Azure.ResourceManager.MachineLearningServices.ScaleSettings scaleSettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.ComputeResource>> UpdateAsync(Azure.ResourceManager.MachineLearningServices.ScaleSettings scaleSettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateSchedules(System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearningServices.ComputeStartStopSchedule> computeStartStop = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateSchedulesAsync(System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearningServices.ComputeStartStopSchedule> computeStartStop = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ComputeSchedules
    {
        public ComputeSchedules() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.MachineLearningServices.ComputeStartStopSchedule> ComputeStartStop { get { throw null; } }
    }
    public partial class ComputeSecrets
    {
        internal ComputeSecrets() { }
    }
    public partial class ComputeStartOperation : Azure.Operation
    {
        protected ComputeStartOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ComputeStartStopSchedule : Azure.ResourceManager.Core.SubResource<Azure.ResourceManager.Core.ResourceIdentifier>
    {
        public ComputeStartStopSchedule() { }
        public Azure.ResourceManager.MachineLearningServices.ComputePowerAction? Action { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Cron Cron { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.ProvisioningStatus? ProvisioningStatus { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Recurrence Recurrence { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.ScheduleStatus? Status { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.TriggerType? TriggerType { get { throw null; } set { } }
    }
    public partial class ComputeStopOperation : Azure.Operation
    {
        protected ComputeStopOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeType : System.IEquatable<Azure.ResourceManager.MachineLearningServices.ComputeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.ComputeType AKS { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.ComputeType AmlCompute { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.ComputeType ComputeInstance { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.ComputeType Databricks { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.ComputeType DataFactory { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.ComputeType DataLakeAnalytics { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.ComputeType HDInsight { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.ComputeType SynapseSpark { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.ComputeType VirtualMachine { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.ComputeType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.ComputeType left, Azure.ResourceManager.MachineLearningServices.ComputeType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.ComputeType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.ComputeType left, Azure.ResourceManager.MachineLearningServices.ComputeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ComputeUpdateOperation : Azure.Operation<Azure.ResourceManager.MachineLearningServices.ComputeResource>
    {
        protected ComputeUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.MachineLearningServices.ComputeResource Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.ComputeResource>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.ComputeResource>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ContainerResourceRequirements
    {
        public ContainerResourceRequirements() { }
        public double? Cpu { get { throw null; } set { } }
        public double? CpuLimit { get { throw null; } set { } }
        public int? Fpga { get { throw null; } set { } }
        public int? Gpu { get { throw null; } set { } }
        public double? MemoryInGB { get { throw null; } set { } }
        public double? MemoryInGBLimit { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerType : System.IEquatable<Azure.ResourceManager.MachineLearningServices.ContainerType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.ContainerType InferenceServer { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.ContainerType StorageInitializer { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.ContainerType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.ContainerType left, Azure.ResourceManager.MachineLearningServices.ContainerType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.ContainerType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.ContainerType left, Azure.ResourceManager.MachineLearningServices.ContainerType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContentsType : System.IEquatable<Azure.ResourceManager.MachineLearningServices.ContentsType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContentsType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.ContentsType AzureBlob { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.ContentsType AzureDataLakeGen1 { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.ContentsType AzureDataLakeGen2 { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.ContentsType AzureFile { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.ContentsType AzureMySql { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.ContentsType AzurePostgreSql { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.ContentsType AzureSqlDatabase { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.ContentsType GlusterFs { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.ContentsType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.ContentsType left, Azure.ResourceManager.MachineLearningServices.ContentsType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.ContentsType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.ContentsType left, Azure.ResourceManager.MachineLearningServices.ContentsType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CosmosDbSettings
    {
        public CosmosDbSettings() { }
        public int? CollectionsThroughput { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CreatedByType : System.IEquatable<Azure.ResourceManager.MachineLearningServices.CreatedByType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CreatedByType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.CreatedByType Application { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.CreatedByType Key { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.CreatedByType ManagedIdentity { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.CreatedByType User { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.CreatedByType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.CreatedByType left, Azure.ResourceManager.MachineLearningServices.CreatedByType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.CreatedByType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.CreatedByType left, Azure.ResourceManager.MachineLearningServices.CreatedByType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CredentialsType : System.IEquatable<Azure.ResourceManager.MachineLearningServices.CredentialsType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CredentialsType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.CredentialsType AccountKey { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.CredentialsType Certificate { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.CredentialsType None { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.CredentialsType Sas { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.CredentialsType ServicePrincipal { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.CredentialsType SqlAdmin { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.CredentialsType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.CredentialsType left, Azure.ResourceManager.MachineLearningServices.CredentialsType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.CredentialsType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.CredentialsType left, Azure.ResourceManager.MachineLearningServices.CredentialsType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Cron
    {
        public Cron() { }
        public string Expression { get { throw null; } set { } }
        public string StartTime { get { throw null; } set { } }
        public string TimeZone { get { throw null; } set { } }
    }
    public partial class CsvExportSummary : Azure.ResourceManager.MachineLearningServices.ExportSummary
    {
        public CsvExportSummary() { }
        public string ContainerName { get { throw null; } }
        public string SnapshotPath { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataBindingMode : System.IEquatable<Azure.ResourceManager.MachineLearningServices.DataBindingMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataBindingMode(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.DataBindingMode Download { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.DataBindingMode Mount { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.DataBindingMode Upload { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.DataBindingMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.DataBindingMode left, Azure.ResourceManager.MachineLearningServices.DataBindingMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.DataBindingMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.DataBindingMode left, Azure.ResourceManager.MachineLearningServices.DataBindingMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Databricks : Azure.ResourceManager.MachineLearningServices.Compute
    {
        public Databricks() { }
        public Azure.ResourceManager.MachineLearningServices.DatabricksProperties Properties { get { throw null; } set { } }
    }
    public partial class DatabricksComputeSecrets : Azure.ResourceManager.MachineLearningServices.ComputeSecrets
    {
        internal DatabricksComputeSecrets() { }
        public string DatabricksAccessToken { get { throw null; } }
    }
    public partial class DatabricksProperties
    {
        public DatabricksProperties() { }
        public string DatabricksAccessToken { get { throw null; } set { } }
        public string WorkspaceUrl { get { throw null; } set { } }
    }
    public partial class DataContainer
    {
        public DataContainer() { }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Properties { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class DataContainerResource : Azure.ResourceManager.MachineLearningServices.DataContainerResourceOperations
    {
        internal DataContainerResource() { }
        public Azure.ResourceManager.MachineLearningServices.DataContainerResourceData Data { get { throw null; } }
        protected override Azure.ResourceManager.MachineLearningServices.DataContainerResource GetResource(System.Threading.CancellationToken cancellation = default(System.Threading.CancellationToken)) { throw null; }
        protected override System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.DataContainerResource> GetResourceAsync(System.Threading.CancellationToken cancellation = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataContainerResourceContainer : Azure.ResourceManager.Core.ResourceContainerBase<Azure.ResourceManager.Core.ResourceGroupResourceIdentifier, Azure.ResourceManager.MachineLearningServices.DataContainerResource, Azure.ResourceManager.MachineLearningServices.DataContainerResourceData>
    {
        protected DataContainerResourceContainer() { }
        public new Azure.ResourceManager.Core.ResourceGroupResourceIdentifier Id { get { throw null; } }
        protected override Azure.ResourceManager.Core.ResourceType ValidResourceType { get { throw null; } }
        public Azure.Response<Azure.ResourceManager.MachineLearningServices.DataContainerResource> CreateOrUpdate(string workspaceName, Azure.ResourceManager.MachineLearningServices.DataContainer properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.DataContainerResource>> CreateOrUpdateAsync(string workspaceName, Azure.ResourceManager.MachineLearningServices.DataContainer properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Response<Azure.ResourceManager.MachineLearningServices.DataContainerResource> Get(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.DataContainerResource>> GetAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Pageable<Azure.ResourceManager.MachineLearningServices.DataContainerResource> List(string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Pageable<Azure.ResourceManager.Core.GenericResourceExpanded> ListAsGenericResource(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.AsyncPageable<Azure.ResourceManager.Core.GenericResourceExpanded> ListAsGenericResourceAsync(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.DataContainerResource> ListAsync(string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.ResourceManager.MachineLearningServices.DataContainersCreateOrUpdateOperation StartCreateOrUpdate(string workspaceName, Azure.ResourceManager.MachineLearningServices.DataContainer properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.DataContainersCreateOrUpdateOperation> StartCreateOrUpdateAsync(string workspaceName, Azure.ResourceManager.MachineLearningServices.DataContainer properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataContainerResourceData : Azure.ResourceManager.Core.Resource<Azure.ResourceManager.Core.ResourceGroupResourceIdentifier>
    {
        public DataContainerResourceData(Azure.ResourceManager.MachineLearningServices.DataContainer properties) { }
        public Azure.ResourceManager.MachineLearningServices.DataContainer Properties { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.SystemData SystemData { get { throw null; } }
    }
    public partial class DataContainerResourceOperations : Azure.ResourceManager.Core.ResourceOperationsBase<Azure.ResourceManager.Core.ResourceGroupResourceIdentifier, Azure.ResourceManager.MachineLearningServices.DataContainerResource>
    {
        public static readonly Azure.ResourceManager.Core.ResourceType ResourceType;
        protected DataContainerResourceOperations() { }
        protected internal DataContainerResourceOperations(Azure.ResourceManager.Core.ResourceOperationsBase options, Azure.ResourceManager.Core.ResourceGroupResourceIdentifier id) { }
        protected override Azure.ResourceManager.Core.ResourceType ValidResourceType { get { throw null; } }
        public Azure.Response Delete(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Response> DeleteAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response<Azure.ResourceManager.MachineLearningServices.DataContainerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.DataContainerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.ResourceManager.MachineLearningServices.DataVersionResourceContainer GetDataVersionResources() { throw null; }
        public System.Collections.Generic.IEnumerable<Azure.ResourceManager.Core.LocationData> ListAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Core.LocationData>> ListAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Operation StartDelete(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Operation> StartDeleteAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataContainersCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.MachineLearningServices.DataContainerResource>
    {
        protected DataContainersCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.MachineLearningServices.DataContainerResource Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.DataContainerResource>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.DataContainerResource>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataContainersDeleteOperation : Azure.Operation
    {
        protected DataContainersDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataFactory : Azure.ResourceManager.MachineLearningServices.Compute
    {
        public DataFactory() { }
    }
    public partial class DataLakeAnalytics : Azure.ResourceManager.MachineLearningServices.Compute
    {
        public DataLakeAnalytics() { }
        public Azure.ResourceManager.MachineLearningServices.DataLakeAnalyticsProperties Properties { get { throw null; } set { } }
    }
    public partial class DataLakeAnalyticsProperties
    {
        public DataLakeAnalyticsProperties() { }
        public string DataLakeStoreAccountName { get { throw null; } set { } }
    }
    public partial class DataPathAssetReference : Azure.ResourceManager.MachineLearningServices.AssetReferenceBase
    {
        public DataPathAssetReference() { }
        public string DatastoreId { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
    }
    public partial class DatasetExportSummary : Azure.ResourceManager.MachineLearningServices.ExportSummary
    {
        public DatasetExportSummary() { }
        public string LabeledAssetName { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DatasetType : System.IEquatable<Azure.ResourceManager.MachineLearningServices.DatasetType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DatasetType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.DatasetType Dataflow { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.DatasetType Simple { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.DatasetType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.DatasetType left, Azure.ResourceManager.MachineLearningServices.DatasetType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.DatasetType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.DatasetType left, Azure.ResourceManager.MachineLearningServices.DatasetType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DatastoreContents
    {
        public DatastoreContents() { }
    }
    public partial class DatastoreCredentials
    {
        public DatastoreCredentials() { }
    }
    public partial class DatastoreProperties
    {
        public DatastoreProperties(Azure.ResourceManager.MachineLearningServices.DatastoreContents contents) { }
        public Azure.ResourceManager.MachineLearningServices.DatastoreContents Contents { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public bool? HasBeenValidated { get { throw null; } }
        public bool? IsDefault { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.LinkedInfo LinkedInfo { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Properties { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class DatastorePropertiesResource : Azure.ResourceManager.MachineLearningServices.DatastorePropertiesResourceOperations
    {
        internal DatastorePropertiesResource() { }
        public Azure.ResourceManager.MachineLearningServices.DatastorePropertiesResourceData Data { get { throw null; } }
        protected override Azure.ResourceManager.MachineLearningServices.DatastorePropertiesResource GetResource(System.Threading.CancellationToken cancellation = default(System.Threading.CancellationToken)) { throw null; }
        protected override System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.DatastorePropertiesResource> GetResourceAsync(System.Threading.CancellationToken cancellation = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatastorePropertiesResourceContainer : Azure.ResourceManager.Core.ResourceContainerBase<Azure.ResourceManager.Core.ResourceGroupResourceIdentifier, Azure.ResourceManager.MachineLearningServices.DatastorePropertiesResource, Azure.ResourceManager.MachineLearningServices.DatastorePropertiesResourceData>
    {
        protected DatastorePropertiesResourceContainer() { }
        public new Azure.ResourceManager.Core.ResourceGroupResourceIdentifier Id { get { throw null; } }
        protected override Azure.ResourceManager.Core.ResourceType ValidResourceType { get { throw null; } }
        public Azure.Response<Azure.ResourceManager.MachineLearningServices.DatastorePropertiesResource> CreateOrUpdate(string workspaceName, Azure.ResourceManager.MachineLearningServices.DatastoreProperties properties, bool? skipValidation = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.DatastorePropertiesResource>> CreateOrUpdateAsync(string workspaceName, Azure.ResourceManager.MachineLearningServices.DatastoreProperties properties, bool? skipValidation = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Response<Azure.ResourceManager.MachineLearningServices.DatastorePropertiesResource> Get(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.DatastorePropertiesResource>> GetAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Pageable<Azure.ResourceManager.MachineLearningServices.DatastorePropertiesResource> List(string skip = null, int? count = default(int?), bool? isDefault = default(bool?), System.Collections.Generic.IEnumerable<string> names = null, string searchText = null, string orderBy = null, bool? orderByAsc = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Pageable<Azure.ResourceManager.Core.GenericResourceExpanded> ListAsGenericResource(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.AsyncPageable<Azure.ResourceManager.Core.GenericResourceExpanded> ListAsGenericResourceAsync(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.DatastorePropertiesResource> ListAsync(string skip = null, int? count = default(int?), bool? isDefault = default(bool?), System.Collections.Generic.IEnumerable<string> names = null, string searchText = null, string orderBy = null, bool? orderByAsc = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.DatastoreSecrets> ListSecrets(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.DatastoreSecrets>> ListSecretsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.ResourceManager.MachineLearningServices.DatastoresCreateOrUpdateOperation StartCreateOrUpdate(string workspaceName, Azure.ResourceManager.MachineLearningServices.DatastoreProperties properties, bool? skipValidation = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.DatastoresCreateOrUpdateOperation> StartCreateOrUpdateAsync(string workspaceName, Azure.ResourceManager.MachineLearningServices.DatastoreProperties properties, bool? skipValidation = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatastorePropertiesResourceData : Azure.ResourceManager.Core.Resource<Azure.ResourceManager.Core.ResourceGroupResourceIdentifier>
    {
        public DatastorePropertiesResourceData(Azure.ResourceManager.MachineLearningServices.DatastoreProperties properties) { }
        public Azure.ResourceManager.MachineLearningServices.DatastoreProperties Properties { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.SystemData SystemData { get { throw null; } }
    }
    public partial class DatastorePropertiesResourceOperations : Azure.ResourceManager.Core.ResourceOperationsBase<Azure.ResourceManager.Core.ResourceGroupResourceIdentifier, Azure.ResourceManager.MachineLearningServices.DatastorePropertiesResource>
    {
        public static readonly Azure.ResourceManager.Core.ResourceType ResourceType;
        protected DatastorePropertiesResourceOperations() { }
        protected internal DatastorePropertiesResourceOperations(Azure.ResourceManager.Core.ResourceOperationsBase options, Azure.ResourceManager.Core.ResourceGroupResourceIdentifier id) { }
        protected override Azure.ResourceManager.Core.ResourceType ValidResourceType { get { throw null; } }
        public Azure.Response Delete(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Response> DeleteAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response<Azure.ResourceManager.MachineLearningServices.DatastorePropertiesResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.DatastorePropertiesResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Collections.Generic.IEnumerable<Azure.ResourceManager.Core.LocationData> ListAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Core.LocationData>> ListAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Operation StartDelete(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Operation> StartDeleteAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatastoresCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.MachineLearningServices.DatastorePropertiesResource>
    {
        protected DatastoresCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.MachineLearningServices.DatastorePropertiesResource Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.DatastorePropertiesResource>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.DatastorePropertiesResource>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatastoresDeleteOperation : Azure.Operation
    {
        protected DatastoresDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatastoreSecrets
    {
        public DatastoreSecrets() { }
    }
    public partial class DataVersion
    {
        public DataVersion(string path) { }
        public Azure.ResourceManager.MachineLearningServices.DatasetType? DatasetType { get { throw null; } set { } }
        public string DatastoreId { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public bool? IsAnonymous { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Properties { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class DataVersionResource : Azure.ResourceManager.MachineLearningServices.DataVersionResourceOperations
    {
        internal DataVersionResource() { }
        public Azure.ResourceManager.MachineLearningServices.DataVersionResourceData Data { get { throw null; } }
        protected override Azure.ResourceManager.MachineLearningServices.DataVersionResource GetResource(System.Threading.CancellationToken cancellation = default(System.Threading.CancellationToken)) { throw null; }
        protected override System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.DataVersionResource> GetResourceAsync(System.Threading.CancellationToken cancellation = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataVersionResourceContainer : Azure.ResourceManager.Core.ResourceContainerBase<Azure.ResourceManager.Core.ResourceGroupResourceIdentifier, Azure.ResourceManager.MachineLearningServices.DataVersionResource, Azure.ResourceManager.MachineLearningServices.DataVersionResourceData>
    {
        protected DataVersionResourceContainer() { }
        public new Azure.ResourceManager.Core.ResourceGroupResourceIdentifier Id { get { throw null; } }
        protected override Azure.ResourceManager.Core.ResourceType ValidResourceType { get { throw null; } }
        public Azure.Response<Azure.ResourceManager.MachineLearningServices.DataVersionResource> CreateOrUpdate(string workspaceName, Azure.ResourceManager.MachineLearningServices.DataVersion properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.DataVersionResource>> CreateOrUpdateAsync(string workspaceName, Azure.ResourceManager.MachineLearningServices.DataVersion properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Response<Azure.ResourceManager.MachineLearningServices.DataVersionResource> Get(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.DataVersionResource>> GetAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Pageable<Azure.ResourceManager.MachineLearningServices.DataVersionResource> List(string orderBy = null, int? top = default(int?), string skip = null, string tags = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Pageable<Azure.ResourceManager.Core.GenericResourceExpanded> ListAsGenericResource(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.AsyncPageable<Azure.ResourceManager.Core.GenericResourceExpanded> ListAsGenericResourceAsync(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.DataVersionResource> ListAsync(string orderBy = null, int? top = default(int?), string skip = null, string tags = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.ResourceManager.MachineLearningServices.DataVersionsCreateOrUpdateOperation StartCreateOrUpdate(string workspaceName, Azure.ResourceManager.MachineLearningServices.DataVersion properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.DataVersionsCreateOrUpdateOperation> StartCreateOrUpdateAsync(string workspaceName, Azure.ResourceManager.MachineLearningServices.DataVersion properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataVersionResourceData : Azure.ResourceManager.Core.Resource<Azure.ResourceManager.Core.ResourceGroupResourceIdentifier>
    {
        public DataVersionResourceData(Azure.ResourceManager.MachineLearningServices.DataVersion properties) { }
        public Azure.ResourceManager.MachineLearningServices.DataVersion Properties { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.SystemData SystemData { get { throw null; } }
    }
    public partial class DataVersionResourceOperations : Azure.ResourceManager.Core.ResourceOperationsBase<Azure.ResourceManager.Core.ResourceGroupResourceIdentifier, Azure.ResourceManager.MachineLearningServices.DataVersionResource>
    {
        public static readonly Azure.ResourceManager.Core.ResourceType ResourceType;
        protected DataVersionResourceOperations() { }
        protected internal DataVersionResourceOperations(Azure.ResourceManager.Core.ResourceOperationsBase options, Azure.ResourceManager.Core.ResourceGroupResourceIdentifier id) { }
        protected override Azure.ResourceManager.Core.ResourceType ValidResourceType { get { throw null; } }
        public Azure.Response Delete(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Response> DeleteAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response<Azure.ResourceManager.MachineLearningServices.DataVersionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.DataVersionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Collections.Generic.IEnumerable<Azure.ResourceManager.Core.LocationData> ListAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Core.LocationData>> ListAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Operation StartDelete(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Operation> StartDeleteAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataVersionsCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.MachineLearningServices.DataVersionResource>
    {
        protected DataVersionsCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.MachineLearningServices.DataVersionResource Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.DataVersionResource>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.DataVersionResource>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataVersionsDeleteOperation : Azure.Operation
    {
        protected DataVersionsDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public enum DaysOfWeek
    {
        Sunday = 0,
        Monday = 1,
        Tuesday = 2,
        Wednesday = 3,
        Thursday = 4,
        Friday = 5,
        Saturday = 6,
    }
    public partial class DeploymentLogs
    {
        internal DeploymentLogs() { }
        public string Content { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeploymentProvisioningState : System.IEquatable<Azure.ResourceManager.MachineLearningServices.DeploymentProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeploymentProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.DeploymentProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.DeploymentProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.DeploymentProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.DeploymentProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.DeploymentProvisioningState Scaling { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.DeploymentProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.DeploymentProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.DeploymentProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.DeploymentProvisioningState left, Azure.ResourceManager.MachineLearningServices.DeploymentProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.DeploymentProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.DeploymentProvisioningState left, Azure.ResourceManager.MachineLearningServices.DeploymentProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DistributionConfiguration
    {
        public DistributionConfiguration() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DistributionType : System.IEquatable<Azure.ResourceManager.MachineLearningServices.DistributionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DistributionType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.DistributionType Mpi { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.DistributionType PyTorch { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.DistributionType TensorFlow { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.DistributionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.DistributionType left, Azure.ResourceManager.MachineLearningServices.DistributionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.DistributionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.DistributionType left, Azure.ResourceManager.MachineLearningServices.DistributionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DockerBuild : Azure.ResourceManager.MachineLearningServices.DockerSpecification
    {
        public DockerBuild(string dockerfile) { }
        public string Context { get { throw null; } set { } }
        public string Dockerfile { get { throw null; } set { } }
    }
    public partial class DockerImage : Azure.ResourceManager.MachineLearningServices.DockerSpecification
    {
        public DockerImage(string dockerImageUri) { }
        public string DockerImageUri { get { throw null; } set { } }
    }
    public partial class DockerImagePlatform
    {
        public DockerImagePlatform() { }
        public Azure.ResourceManager.MachineLearningServices.OperatingSystemType? OperatingSystemType { get { throw null; } set { } }
    }
    public partial class DockerSpecification
    {
        public DockerSpecification() { }
        public Azure.ResourceManager.MachineLearningServices.DockerImagePlatform Platform { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DockerSpecificationType : System.IEquatable<Azure.ResourceManager.MachineLearningServices.DockerSpecificationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DockerSpecificationType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.DockerSpecificationType Build { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.DockerSpecificationType Image { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.DockerSpecificationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.DockerSpecificationType left, Azure.ResourceManager.MachineLearningServices.DockerSpecificationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.DockerSpecificationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.DockerSpecificationType left, Azure.ResourceManager.MachineLearningServices.DockerSpecificationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EarlyTerminationPolicy
    {
        public EarlyTerminationPolicy() { }
        public int? DelayEvaluation { get { throw null; } set { } }
        public int? EvaluationInterval { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EarlyTerminationPolicyType : System.IEquatable<Azure.ResourceManager.MachineLearningServices.EarlyTerminationPolicyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EarlyTerminationPolicyType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.EarlyTerminationPolicyType Bandit { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.EarlyTerminationPolicyType MedianStopping { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.EarlyTerminationPolicyType TruncationSelection { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.EarlyTerminationPolicyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.EarlyTerminationPolicyType left, Azure.ResourceManager.MachineLearningServices.EarlyTerminationPolicyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.EarlyTerminationPolicyType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.EarlyTerminationPolicyType left, Azure.ResourceManager.MachineLearningServices.EarlyTerminationPolicyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EncryptionProperty
    {
        public EncryptionProperty(Azure.ResourceManager.MachineLearningServices.EncryptionStatus status, Azure.ResourceManager.MachineLearningServices.KeyVaultProperties keyVaultProperties) { }
        public Azure.ResourceManager.MachineLearningServices.IdentityForCmk Identity { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.KeyVaultProperties KeyVaultProperties { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.EncryptionStatus Status { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EncryptionStatus : System.IEquatable<Azure.ResourceManager.MachineLearningServices.EncryptionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EncryptionStatus(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.EncryptionStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.EncryptionStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.EncryptionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.EncryptionStatus left, Azure.ResourceManager.MachineLearningServices.EncryptionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.EncryptionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.EncryptionStatus left, Azure.ResourceManager.MachineLearningServices.EncryptionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EndpointAuthKeys
    {
        public EndpointAuthKeys() { }
        public string PrimaryKey { get { throw null; } set { } }
        public string SecondaryKey { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EndpointAuthMode : System.IEquatable<Azure.ResourceManager.MachineLearningServices.EndpointAuthMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EndpointAuthMode(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.EndpointAuthMode AADToken { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.EndpointAuthMode AMLToken { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.EndpointAuthMode Key { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.EndpointAuthMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.EndpointAuthMode left, Azure.ResourceManager.MachineLearningServices.EndpointAuthMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.EndpointAuthMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.EndpointAuthMode left, Azure.ResourceManager.MachineLearningServices.EndpointAuthMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EndpointAuthToken
    {
        internal EndpointAuthToken() { }
        public string AccessToken { get { throw null; } }
        public long? ExpiryTimeUtc { get { throw null; } }
        public long? RefreshAfterTimeUtc { get { throw null; } }
        public string TokenType { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EndpointComputeType : System.IEquatable<Azure.ResourceManager.MachineLearningServices.EndpointComputeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EndpointComputeType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.EndpointComputeType AzureMLCompute { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.EndpointComputeType K8S { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.EndpointComputeType Managed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.EndpointComputeType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.EndpointComputeType left, Azure.ResourceManager.MachineLearningServices.EndpointComputeType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.EndpointComputeType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.EndpointComputeType left, Azure.ResourceManager.MachineLearningServices.EndpointComputeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EndpointProvisioningState : System.IEquatable<Azure.ResourceManager.MachineLearningServices.EndpointProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EndpointProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.EndpointProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.EndpointProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.EndpointProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.EndpointProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.EndpointProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.EndpointProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.EndpointProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.EndpointProvisioningState left, Azure.ResourceManager.MachineLearningServices.EndpointProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.EndpointProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.EndpointProvisioningState left, Azure.ResourceManager.MachineLearningServices.EndpointProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EnvironmentContainer
    {
        public EnvironmentContainer() { }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Properties { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class EnvironmentContainerResource : Azure.ResourceManager.MachineLearningServices.EnvironmentContainerResourceOperations
    {
        internal EnvironmentContainerResource() { }
        public Azure.ResourceManager.MachineLearningServices.EnvironmentContainerResourceData Data { get { throw null; } }
        protected override Azure.ResourceManager.MachineLearningServices.EnvironmentContainerResource GetResource(System.Threading.CancellationToken cancellation = default(System.Threading.CancellationToken)) { throw null; }
        protected override System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.EnvironmentContainerResource> GetResourceAsync(System.Threading.CancellationToken cancellation = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EnvironmentContainerResourceContainer : Azure.ResourceManager.Core.ResourceContainerBase<Azure.ResourceManager.Core.ResourceGroupResourceIdentifier, Azure.ResourceManager.MachineLearningServices.EnvironmentContainerResource, Azure.ResourceManager.MachineLearningServices.EnvironmentContainerResourceData>
    {
        protected EnvironmentContainerResourceContainer() { }
        public new Azure.ResourceManager.Core.ResourceGroupResourceIdentifier Id { get { throw null; } }
        protected override Azure.ResourceManager.Core.ResourceType ValidResourceType { get { throw null; } }
        public Azure.Response<Azure.ResourceManager.MachineLearningServices.EnvironmentContainerResource> CreateOrUpdate(string workspaceName, Azure.ResourceManager.MachineLearningServices.EnvironmentContainer properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.EnvironmentContainerResource>> CreateOrUpdateAsync(string workspaceName, Azure.ResourceManager.MachineLearningServices.EnvironmentContainer properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Response<Azure.ResourceManager.MachineLearningServices.EnvironmentContainerResource> Get(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.EnvironmentContainerResource>> GetAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Pageable<Azure.ResourceManager.MachineLearningServices.EnvironmentContainerResource> List(string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Pageable<Azure.ResourceManager.Core.GenericResourceExpanded> ListAsGenericResource(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.AsyncPageable<Azure.ResourceManager.Core.GenericResourceExpanded> ListAsGenericResourceAsync(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.EnvironmentContainerResource> ListAsync(string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.ResourceManager.MachineLearningServices.EnvironmentContainersCreateOrUpdateOperation StartCreateOrUpdate(string workspaceName, Azure.ResourceManager.MachineLearningServices.EnvironmentContainer properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.EnvironmentContainersCreateOrUpdateOperation> StartCreateOrUpdateAsync(string workspaceName, Azure.ResourceManager.MachineLearningServices.EnvironmentContainer properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EnvironmentContainerResourceData : Azure.ResourceManager.Core.Resource<Azure.ResourceManager.Core.ResourceGroupResourceIdentifier>
    {
        public EnvironmentContainerResourceData(Azure.ResourceManager.MachineLearningServices.EnvironmentContainer properties) { }
        public Azure.ResourceManager.MachineLearningServices.EnvironmentContainer Properties { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.SystemData SystemData { get { throw null; } }
    }
    public partial class EnvironmentContainerResourceOperations : Azure.ResourceManager.Core.ResourceOperationsBase<Azure.ResourceManager.Core.ResourceGroupResourceIdentifier, Azure.ResourceManager.MachineLearningServices.EnvironmentContainerResource>
    {
        public static readonly Azure.ResourceManager.Core.ResourceType ResourceType;
        protected EnvironmentContainerResourceOperations() { }
        protected internal EnvironmentContainerResourceOperations(Azure.ResourceManager.Core.ResourceOperationsBase options, Azure.ResourceManager.Core.ResourceGroupResourceIdentifier id) { }
        protected override Azure.ResourceManager.Core.ResourceType ValidResourceType { get { throw null; } }
        public Azure.Response Delete(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Response> DeleteAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response<Azure.ResourceManager.MachineLearningServices.EnvironmentContainerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.EnvironmentContainerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.ResourceManager.MachineLearningServices.EnvironmentSpecificationVersionResourceContainer GetEnvironmentSpecificationVersionResources() { throw null; }
        public System.Collections.Generic.IEnumerable<Azure.ResourceManager.Core.LocationData> ListAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Core.LocationData>> ListAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Operation StartDelete(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Operation> StartDeleteAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EnvironmentContainersCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.MachineLearningServices.EnvironmentContainerResource>
    {
        protected EnvironmentContainersCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.MachineLearningServices.EnvironmentContainerResource Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.EnvironmentContainerResource>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.EnvironmentContainerResource>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EnvironmentContainersDeleteOperation : Azure.Operation
    {
        protected EnvironmentContainersDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EnvironmentSpecificationType : System.IEquatable<Azure.ResourceManager.MachineLearningServices.EnvironmentSpecificationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EnvironmentSpecificationType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.EnvironmentSpecificationType Curated { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.EnvironmentSpecificationType UserCreated { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.EnvironmentSpecificationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.EnvironmentSpecificationType left, Azure.ResourceManager.MachineLearningServices.EnvironmentSpecificationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.EnvironmentSpecificationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.EnvironmentSpecificationType left, Azure.ResourceManager.MachineLearningServices.EnvironmentSpecificationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EnvironmentSpecificationVersion
    {
        public EnvironmentSpecificationVersion() { }
        public string CondaFile { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.DockerSpecification Docker { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.EnvironmentSpecificationType? EnvironmentSpecificationType { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.InferenceContainerProperties InferenceContainerProperties { get { throw null; } set { } }
        public bool? IsAnonymous { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Properties { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class EnvironmentSpecificationVersionResource : Azure.ResourceManager.MachineLearningServices.EnvironmentSpecificationVersionResourceOperations
    {
        internal EnvironmentSpecificationVersionResource() { }
        public Azure.ResourceManager.MachineLearningServices.EnvironmentSpecificationVersionResourceData Data { get { throw null; } }
        protected override Azure.ResourceManager.MachineLearningServices.EnvironmentSpecificationVersionResource GetResource(System.Threading.CancellationToken cancellation = default(System.Threading.CancellationToken)) { throw null; }
        protected override System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.EnvironmentSpecificationVersionResource> GetResourceAsync(System.Threading.CancellationToken cancellation = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EnvironmentSpecificationVersionResourceContainer : Azure.ResourceManager.Core.ResourceContainerBase<Azure.ResourceManager.Core.ResourceGroupResourceIdentifier, Azure.ResourceManager.MachineLearningServices.EnvironmentSpecificationVersionResource, Azure.ResourceManager.MachineLearningServices.EnvironmentSpecificationVersionResourceData>
    {
        protected EnvironmentSpecificationVersionResourceContainer() { }
        public new Azure.ResourceManager.Core.ResourceGroupResourceIdentifier Id { get { throw null; } }
        protected override Azure.ResourceManager.Core.ResourceType ValidResourceType { get { throw null; } }
        public Azure.Response<Azure.ResourceManager.MachineLearningServices.EnvironmentSpecificationVersionResource> CreateOrUpdate(string workspaceName, Azure.ResourceManager.MachineLearningServices.EnvironmentSpecificationVersion properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.EnvironmentSpecificationVersionResource>> CreateOrUpdateAsync(string workspaceName, Azure.ResourceManager.MachineLearningServices.EnvironmentSpecificationVersion properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Response<Azure.ResourceManager.MachineLearningServices.EnvironmentSpecificationVersionResource> Get(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.EnvironmentSpecificationVersionResource>> GetAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Pageable<Azure.ResourceManager.MachineLearningServices.EnvironmentSpecificationVersionResource> List(string orderBy = null, int? top = default(int?), string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Pageable<Azure.ResourceManager.Core.GenericResourceExpanded> ListAsGenericResource(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.AsyncPageable<Azure.ResourceManager.Core.GenericResourceExpanded> ListAsGenericResourceAsync(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.EnvironmentSpecificationVersionResource> ListAsync(string orderBy = null, int? top = default(int?), string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.ResourceManager.MachineLearningServices.EnvironmentSpecificationVersionsCreateOrUpdateOperation StartCreateOrUpdate(string workspaceName, Azure.ResourceManager.MachineLearningServices.EnvironmentSpecificationVersion properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.EnvironmentSpecificationVersionsCreateOrUpdateOperation> StartCreateOrUpdateAsync(string workspaceName, Azure.ResourceManager.MachineLearningServices.EnvironmentSpecificationVersion properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EnvironmentSpecificationVersionResourceData : Azure.ResourceManager.Core.Resource<Azure.ResourceManager.Core.ResourceGroupResourceIdentifier>
    {
        public EnvironmentSpecificationVersionResourceData(Azure.ResourceManager.MachineLearningServices.EnvironmentSpecificationVersion properties) { }
        public Azure.ResourceManager.MachineLearningServices.EnvironmentSpecificationVersion Properties { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.SystemData SystemData { get { throw null; } }
    }
    public partial class EnvironmentSpecificationVersionResourceOperations : Azure.ResourceManager.Core.ResourceOperationsBase<Azure.ResourceManager.Core.ResourceGroupResourceIdentifier, Azure.ResourceManager.MachineLearningServices.EnvironmentSpecificationVersionResource>
    {
        public static readonly Azure.ResourceManager.Core.ResourceType ResourceType;
        protected EnvironmentSpecificationVersionResourceOperations() { }
        protected internal EnvironmentSpecificationVersionResourceOperations(Azure.ResourceManager.Core.ResourceOperationsBase options, Azure.ResourceManager.Core.ResourceGroupResourceIdentifier id) { }
        protected override Azure.ResourceManager.Core.ResourceType ValidResourceType { get { throw null; } }
        public Azure.Response Delete(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Response> DeleteAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response<Azure.ResourceManager.MachineLearningServices.EnvironmentSpecificationVersionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.EnvironmentSpecificationVersionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Collections.Generic.IEnumerable<Azure.ResourceManager.Core.LocationData> ListAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Core.LocationData>> ListAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Operation StartDelete(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Operation> StartDeleteAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EnvironmentSpecificationVersionsCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.MachineLearningServices.EnvironmentSpecificationVersionResource>
    {
        protected EnvironmentSpecificationVersionsCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.MachineLearningServices.EnvironmentSpecificationVersionResource Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.EnvironmentSpecificationVersionResource>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.EnvironmentSpecificationVersionResource>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EnvironmentSpecificationVersionsDeleteOperation : Azure.Operation
    {
        protected EnvironmentSpecificationVersionsDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ErrorAdditionalInfo
    {
        internal ErrorAdditionalInfo() { }
        public object Info { get { throw null; } }
        public string Type { get { throw null; } }
    }
    public partial class ErrorDetail
    {
        internal ErrorDetail() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearningServices.ErrorAdditionalInfo> AdditionalInfo { get { throw null; } }
        public string Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearningServices.ErrorDetail> Details { get { throw null; } }
        public string Message { get { throw null; } }
        public string Target { get { throw null; } }
    }
    public partial class ErrorResponse
    {
        internal ErrorResponse() { }
        public Azure.ResourceManager.MachineLearningServices.ErrorDetail Error { get { throw null; } }
    }
    public partial class EstimatedVMPrice
    {
        internal EstimatedVMPrice() { }
        public Azure.ResourceManager.MachineLearningServices.VMPriceOSType OsType { get { throw null; } }
        public double RetailPrice { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.VMTier VmTier { get { throw null; } }
    }
    public partial class EstimatedVMPrices
    {
        internal EstimatedVMPrices() { }
        public Azure.ResourceManager.MachineLearningServices.BillingCurrency BillingCurrency { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.UnitOfMeasure UnitOfMeasure { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearningServices.EstimatedVMPrice> Values { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExportFormatType : System.IEquatable<Azure.ResourceManager.MachineLearningServices.ExportFormatType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExportFormatType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.ExportFormatType Coco { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.ExportFormatType CSV { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.ExportFormatType Dataset { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.ExportFormatType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.ExportFormatType left, Azure.ResourceManager.MachineLearningServices.ExportFormatType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.ExportFormatType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.ExportFormatType left, Azure.ResourceManager.MachineLearningServices.ExportFormatType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ExportSummary
    {
        public ExportSummary() { }
        public System.DateTimeOffset? EndTimeUtc { get { throw null; } }
        public long? ExportedRowCount { get { throw null; } }
        public string LabelingJobId { get { throw null; } }
        public System.DateTimeOffset? StartTimeUtc { get { throw null; } }
    }
    public partial class FlavorData
    {
        public FlavorData() { }
        public System.Collections.Generic.IDictionary<string, string> Data { get { throw null; } }
    }
    public partial class GlusterFsContents : Azure.ResourceManager.MachineLearningServices.DatastoreContents
    {
        public GlusterFsContents(string serverAddress, string volumeName) { }
        public string ServerAddress { get { throw null; } set { } }
        public string VolumeName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Goal : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Goal>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Goal(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Goal Maximize { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Goal Minimize { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Goal other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Goal left, Azure.ResourceManager.MachineLearningServices.Goal right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Goal (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Goal left, Azure.ResourceManager.MachineLearningServices.Goal right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HDInsight : Azure.ResourceManager.MachineLearningServices.Compute
    {
        public HDInsight() { }
        public Azure.ResourceManager.MachineLearningServices.HDInsightProperties Properties { get { throw null; } set { } }
    }
    public partial class HDInsightProperties
    {
        public HDInsightProperties() { }
        public string Address { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.VirtualMachineSshCredentials AdministratorAccount { get { throw null; } set { } }
        public int? SshPort { get { throw null; } set { } }
    }
    public partial class IdAssetReference : Azure.ResourceManager.MachineLearningServices.AssetReferenceBase
    {
        public IdAssetReference(string assetId) { }
        public string AssetId { get { throw null; } set { } }
    }
    public partial class Identity
    {
        public Identity() { }
        public string PrincipalId { get { throw null; } }
        public string TenantId { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.ResourceIdentityType? Type { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.MachineLearningServices.UserAssignedIdentity> UserAssignedIdentities { get { throw null; } }
    }
    public partial class IdentityConfiguration
    {
        public IdentityConfiguration() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IdentityConfigurationType : System.IEquatable<Azure.ResourceManager.MachineLearningServices.IdentityConfigurationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IdentityConfigurationType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.IdentityConfigurationType AMLToken { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.IdentityConfigurationType Managed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.IdentityConfigurationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.IdentityConfigurationType left, Azure.ResourceManager.MachineLearningServices.IdentityConfigurationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.IdentityConfigurationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.IdentityConfigurationType left, Azure.ResourceManager.MachineLearningServices.IdentityConfigurationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IdentityForCmk
    {
        public IdentityForCmk() { }
        public string UserAssignedIdentity { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ImageAnnotationType : System.IEquatable<Azure.ResourceManager.MachineLearningServices.ImageAnnotationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ImageAnnotationType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.ImageAnnotationType BoundingBox { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.ImageAnnotationType Classification { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.ImageAnnotationType InstanceSegmentation { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.ImageAnnotationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.ImageAnnotationType left, Azure.ResourceManager.MachineLearningServices.ImageAnnotationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.ImageAnnotationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.ImageAnnotationType left, Azure.ResourceManager.MachineLearningServices.ImageAnnotationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class InferenceContainerProperties
    {
        public InferenceContainerProperties() { }
        public Azure.ResourceManager.MachineLearningServices.Route LivenessRoute { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Route ReadinessRoute { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Route ScoringRoute { get { throw null; } set { } }
    }
    public partial class InputDataBinding
    {
        public InputDataBinding() { }
        public string DataId { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.DataBindingMode? Mode { get { throw null; } set { } }
        public string PathOnCompute { get { throw null; } set { } }
    }
    public partial class JobBase
    {
        public JobBase() { }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.MachineLearningServices.JobEndpoint> InteractionEndpoints { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Properties { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.JobProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class JobBaseResource : Azure.ResourceManager.MachineLearningServices.JobBaseResourceOperations
    {
        internal JobBaseResource() { }
        public Azure.ResourceManager.MachineLearningServices.JobBaseResourceData Data { get { throw null; } }
        protected override Azure.ResourceManager.MachineLearningServices.JobBaseResource GetResource(System.Threading.CancellationToken cancellation = default(System.Threading.CancellationToken)) { throw null; }
        protected override System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.JobBaseResource> GetResourceAsync(System.Threading.CancellationToken cancellation = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class JobBaseResourceContainer : Azure.ResourceManager.Core.ResourceContainerBase<Azure.ResourceManager.Core.ResourceGroupResourceIdentifier, Azure.ResourceManager.MachineLearningServices.JobBaseResource, Azure.ResourceManager.MachineLearningServices.JobBaseResourceData>
    {
        protected JobBaseResourceContainer() { }
        public new Azure.ResourceManager.Core.ResourceGroupResourceIdentifier Id { get { throw null; } }
        protected override Azure.ResourceManager.Core.ResourceType ValidResourceType { get { throw null; } }
        public Azure.Response<Azure.ResourceManager.MachineLearningServices.JobBaseResource> CreateOrUpdate(string workspaceName, Azure.ResourceManager.MachineLearningServices.JobBase properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.JobBaseResource>> CreateOrUpdateAsync(string workspaceName, Azure.ResourceManager.MachineLearningServices.JobBase properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Response<Azure.ResourceManager.MachineLearningServices.JobBaseResource> Get(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.JobBaseResource>> GetAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Pageable<Azure.ResourceManager.MachineLearningServices.JobBaseResource> List(string skip = null, string jobType = null, string tags = null, string tag = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Pageable<Azure.ResourceManager.Core.GenericResourceExpanded> ListAsGenericResource(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.AsyncPageable<Azure.ResourceManager.Core.GenericResourceExpanded> ListAsGenericResourceAsync(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.JobBaseResource> ListAsync(string skip = null, string jobType = null, string tags = null, string tag = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.ResourceManager.MachineLearningServices.JobsCreateOrUpdateOperation StartCreateOrUpdate(string workspaceName, Azure.ResourceManager.MachineLearningServices.JobBase properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.JobsCreateOrUpdateOperation> StartCreateOrUpdateAsync(string workspaceName, Azure.ResourceManager.MachineLearningServices.JobBase properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class JobBaseResourceData : Azure.ResourceManager.Core.Resource<Azure.ResourceManager.Core.ResourceGroupResourceIdentifier>
    {
        public JobBaseResourceData(Azure.ResourceManager.MachineLearningServices.JobBase properties) { }
        public Azure.ResourceManager.MachineLearningServices.JobBase Properties { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.SystemData SystemData { get { throw null; } }
    }
    public partial class JobBaseResourceOperations : Azure.ResourceManager.Core.ResourceOperationsBase<Azure.ResourceManager.Core.ResourceGroupResourceIdentifier, Azure.ResourceManager.MachineLearningServices.JobBaseResource>
    {
        public static readonly Azure.ResourceManager.Core.ResourceType ResourceType;
        protected JobBaseResourceOperations() { }
        protected internal JobBaseResourceOperations(Azure.ResourceManager.Core.ResourceOperationsBase options, Azure.ResourceManager.Core.ResourceGroupResourceIdentifier id) { }
        protected override Azure.ResourceManager.Core.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response Cancel(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Response Delete(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Response> DeleteAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response<Azure.ResourceManager.MachineLearningServices.JobBaseResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.JobBaseResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Collections.Generic.IEnumerable<Azure.ResourceManager.Core.LocationData> ListAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Core.LocationData>> ListAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Operation StartDelete(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Operation> StartDeleteAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class JobEndpoint
    {
        internal JobEndpoint() { }
        public string Endpoint { get { throw null; } }
        public string JobEndpointType { get { throw null; } }
        public int? Port { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Properties { get { throw null; } }
    }
    public partial class JobOutput
    {
        internal JobOutput() { }
        public string DatastoreId { get { throw null; } }
        public string Path { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct JobProvisioningState : System.IEquatable<Azure.ResourceManager.MachineLearningServices.JobProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public JobProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.JobProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.JobProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.JobProvisioningState InProgress { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.JobProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.JobProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.JobProvisioningState left, Azure.ResourceManager.MachineLearningServices.JobProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.JobProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.JobProvisioningState left, Azure.ResourceManager.MachineLearningServices.JobProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class JobsCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.MachineLearningServices.JobBaseResource>
    {
        protected JobsCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.MachineLearningServices.JobBaseResource Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.JobBaseResource>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.JobBaseResource>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class JobsDeleteOperation : Azure.Operation
    {
        protected JobsDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct JobStatus : System.IEquatable<Azure.ResourceManager.MachineLearningServices.JobStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public JobStatus(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.JobStatus Canceled { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.JobStatus CancelRequested { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.JobStatus Completed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.JobStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.JobStatus Finalizing { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.JobStatus NotResponding { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.JobStatus NotStarted { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.JobStatus Paused { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.JobStatus Preparing { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.JobStatus Provisioning { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.JobStatus Queued { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.JobStatus Running { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.JobStatus Starting { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.JobStatus Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.JobStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.JobStatus left, Azure.ResourceManager.MachineLearningServices.JobStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.JobStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.JobStatus left, Azure.ResourceManager.MachineLearningServices.JobStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct JobType : System.IEquatable<Azure.ResourceManager.MachineLearningServices.JobType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public JobType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.JobType Command { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.JobType Labeling { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.JobType Sweep { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.JobType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.JobType left, Azure.ResourceManager.MachineLearningServices.JobType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.JobType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.JobType left, Azure.ResourceManager.MachineLearningServices.JobType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class K8SOnlineDeployment : Azure.ResourceManager.MachineLearningServices.OnlineDeployment
    {
        public K8SOnlineDeployment() { }
        public Azure.ResourceManager.MachineLearningServices.ContainerResourceRequirements ContainerResourceRequirements { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KeyType : System.IEquatable<Azure.ResourceManager.MachineLearningServices.KeyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KeyType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.KeyType Primary { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.KeyType Secondary { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.KeyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.KeyType left, Azure.ResourceManager.MachineLearningServices.KeyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.KeyType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.KeyType left, Azure.ResourceManager.MachineLearningServices.KeyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KeyVaultProperties
    {
        public KeyVaultProperties(string keyVaultArmId, string keyIdentifier) { }
        public string IdentityClientId { get { throw null; } set { } }
        public string KeyIdentifier { get { throw null; } set { } }
        public string KeyVaultArmId { get { throw null; } set { } }
    }
    public partial class LabelCategory
    {
        public LabelCategory() { }
        public bool? AllowMultiSelect { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.MachineLearningServices.LabelClass> Classes { get { throw null; } }
        public string DisplayName { get { throw null; } set { } }
    }
    public partial class LabelClass
    {
        public LabelClass() { }
        public string DisplayName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.MachineLearningServices.LabelClass> Subclasses { get { throw null; } }
    }
    public partial class LabelingDatasetConfiguration
    {
        public LabelingDatasetConfiguration() { }
        public string AssetName { get { throw null; } set { } }
        public string DatasetVersion { get { throw null; } set { } }
        public bool? IncrementalDatasetRefreshEnabled { get { throw null; } set { } }
    }
    public partial class LabelingJob
    {
        public LabelingJob(Azure.ResourceManager.MachineLearningServices.JobType jobType) { }
        public System.DateTimeOffset? CreatedTimeUtc { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.LabelingDatasetConfiguration DatasetConfiguration { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.MachineLearningServices.JobEndpoint> InteractionEndpoints { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.LabelingJobInstructions JobInstructions { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.JobType JobType { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.MachineLearningServices.LabelCategory> LabelCategories { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.LabelingJobMediaProperties LabelingJobMediaProperties { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.MLAssistConfiguration MlAssistConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.ProgressMetrics ProgressMetrics { get { throw null; } }
        public System.Guid? ProjectId { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Properties { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.JobProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.JobStatus? Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearningServices.StatusMessage> StatusMessages { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class LabelingJobImageProperties : Azure.ResourceManager.MachineLearningServices.LabelingJobMediaProperties
    {
        public LabelingJobImageProperties() { }
        public Azure.ResourceManager.MachineLearningServices.ImageAnnotationType? AnnotationType { get { throw null; } set { } }
    }
    public partial class LabelingJobInstructions
    {
        public LabelingJobInstructions() { }
        public string Uri { get { throw null; } set { } }
    }
    public partial class LabelingJobMediaProperties
    {
        public LabelingJobMediaProperties() { }
    }
    public partial class LabelingJobResource : Azure.ResourceManager.MachineLearningServices.LabelingJobResourceOperations
    {
        internal LabelingJobResource() { }
        public Azure.ResourceManager.MachineLearningServices.LabelingJobResourceData Data { get { throw null; } }
        protected override Azure.ResourceManager.MachineLearningServices.LabelingJobResource GetResource(System.Threading.CancellationToken cancellation = default(System.Threading.CancellationToken)) { throw null; }
        protected override System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.LabelingJobResource> GetResourceAsync(System.Threading.CancellationToken cancellation = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LabelingJobResourceContainer : Azure.ResourceManager.Core.ResourceContainerBase<Azure.ResourceManager.Core.ResourceGroupResourceIdentifier, Azure.ResourceManager.MachineLearningServices.LabelingJobResource, Azure.ResourceManager.MachineLearningServices.LabelingJobResourceData>
    {
        protected LabelingJobResourceContainer() { }
        public new Azure.ResourceManager.Core.ResourceGroupResourceIdentifier Id { get { throw null; } }
        protected override Azure.ResourceManager.Core.ResourceType ValidResourceType { get { throw null; } }
        public Azure.Response<Azure.ResourceManager.MachineLearningServices.LabelingJobResource> CreateOrUpdate(string workspaceName, Azure.ResourceManager.MachineLearningServices.LabelingJob properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.LabelingJobResource>> CreateOrUpdateAsync(string workspaceName, Azure.ResourceManager.MachineLearningServices.LabelingJob properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Response<Azure.ResourceManager.MachineLearningServices.LabelingJobResource> Get(string workspaceName, bool? includeJobInstructions = default(bool?), bool? includeLabelCategories = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.LabelingJobResource>> GetAsync(string workspaceName, bool? includeJobInstructions = default(bool?), bool? includeLabelCategories = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Pageable<Azure.ResourceManager.MachineLearningServices.LabelingJobResource> List(string skip = null, int? count = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Pageable<Azure.ResourceManager.Core.GenericResourceExpanded> ListAsGenericResource(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.AsyncPageable<Azure.ResourceManager.Core.GenericResourceExpanded> ListAsGenericResourceAsync(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.LabelingJobResource> ListAsync(string skip = null, int? count = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.ResourceManager.MachineLearningServices.LabelingJobsCreateOrUpdateOperation StartCreateOrUpdate(string workspaceName, Azure.ResourceManager.MachineLearningServices.LabelingJob properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.LabelingJobsCreateOrUpdateOperation> StartCreateOrUpdateAsync(string workspaceName, Azure.ResourceManager.MachineLearningServices.LabelingJob properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LabelingJobResourceData : Azure.ResourceManager.Core.Resource<Azure.ResourceManager.Core.ResourceGroupResourceIdentifier>
    {
        public LabelingJobResourceData(Azure.ResourceManager.MachineLearningServices.LabelingJob properties) { }
        public Azure.ResourceManager.MachineLearningServices.LabelingJob Properties { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.SystemData SystemData { get { throw null; } }
    }
    public partial class LabelingJobResourceOperations : Azure.ResourceManager.Core.ResourceOperationsBase<Azure.ResourceManager.Core.ResourceGroupResourceIdentifier, Azure.ResourceManager.MachineLearningServices.LabelingJobResource>
    {
        public static readonly Azure.ResourceManager.Core.ResourceType ResourceType;
        protected LabelingJobResourceOperations() { }
        protected internal LabelingJobResourceOperations(Azure.ResourceManager.Core.ResourceOperationsBase options, Azure.ResourceManager.Core.ResourceGroupResourceIdentifier id) { }
        protected override Azure.ResourceManager.Core.ResourceType ValidResourceType { get { throw null; } }
        public Azure.Response Delete(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Response> DeleteAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Response<Azure.ResourceManager.MachineLearningServices.ExportSummary> ExportLabels(Azure.ResourceManager.MachineLearningServices.ExportSummary body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.ExportSummary>> ExportLabelsAsync(Azure.ResourceManager.MachineLearningServices.ExportSummary body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Response<Azure.ResourceManager.MachineLearningServices.LabelingJobResource> Get(bool? includeJobInstructions, bool? includeLabelCategories, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response<Azure.ResourceManager.MachineLearningServices.LabelingJobResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.LabelingJobResource>> GetAsync(bool? includeJobInstructions, bool? includeLabelCategories, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.LabelingJobResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Collections.Generic.IEnumerable<Azure.ResourceManager.Core.LocationData> ListAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Core.LocationData>> ListAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Pause(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> PauseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Response Resume(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Response> ResumeAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Operation StartDelete(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Operation> StartDeleteAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.ResourceManager.MachineLearningServices.LabelingJobsExportLabelsOperation StartExportLabels(Azure.ResourceManager.MachineLearningServices.ExportSummary body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.LabelingJobsExportLabelsOperation> StartExportLabelsAsync(Azure.ResourceManager.MachineLearningServices.ExportSummary body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Operation StartResume(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Operation> StartResumeAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LabelingJobsCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.MachineLearningServices.LabelingJobResource>
    {
        protected LabelingJobsCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.MachineLearningServices.LabelingJobResource Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.LabelingJobResource>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.LabelingJobResource>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LabelingJobsDeleteOperation : Azure.Operation
    {
        protected LabelingJobsDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LabelingJobsExportLabelsOperation : Azure.Operation<Azure.ResourceManager.MachineLearningServices.ExportSummary>
    {
        protected LabelingJobsExportLabelsOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.MachineLearningServices.ExportSummary Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.ExportSummary>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.ExportSummary>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LabelingJobsResumeOperation : Azure.Operation
    {
        protected LabelingJobsResumeOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LabelingJobTextProperties : Azure.ResourceManager.MachineLearningServices.LabelingJobMediaProperties
    {
        public LabelingJobTextProperties() { }
        public Azure.ResourceManager.MachineLearningServices.TextAnnotationType? AnnotationType { get { throw null; } set { } }
    }
    public partial class LinkedInfo
    {
        public LinkedInfo() { }
        public string LinkedId { get { throw null; } set { } }
        public string LinkedResourceName { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.OriginType? Origin { get { throw null; } set { } }
    }
    public partial class ListNotebookKeysResult
    {
        internal ListNotebookKeysResult() { }
        public string PrimaryAccessKey { get { throw null; } }
        public string SecondaryAccessKey { get { throw null; } }
    }
    public partial class ListStorageAccountKeysResult
    {
        internal ListStorageAccountKeysResult() { }
        public string UserStorageKey { get { throw null; } }
    }
    public partial class ListWorkspaceKeysResult
    {
        internal ListWorkspaceKeysResult() { }
        public string AppInsightsInstrumentationKey { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.RegistryListCredentialsResult ContainerRegistryCredentials { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.ListNotebookKeysResult NotebookAccessKeys { get { throw null; } }
        public string UserStorageKey { get { throw null; } }
        public string UserStorageResourceId { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LoadBalancerType : System.IEquatable<Azure.ResourceManager.MachineLearningServices.LoadBalancerType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LoadBalancerType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.LoadBalancerType InternalLoadBalancer { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.LoadBalancerType PublicIp { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.LoadBalancerType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.LoadBalancerType left, Azure.ResourceManager.MachineLearningServices.LoadBalancerType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.LoadBalancerType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.LoadBalancerType left, Azure.ResourceManager.MachineLearningServices.LoadBalancerType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ManagedIdentity : Azure.ResourceManager.MachineLearningServices.IdentityConfiguration
    {
        public ManagedIdentity() { }
        public System.Guid? ClientId { get { throw null; } set { } }
        public System.Guid? ObjectId { get { throw null; } set { } }
        public string ResourceId { get { throw null; } set { } }
    }
    public partial class ManagedOnlineDeployment : Azure.ResourceManager.MachineLearningServices.OnlineDeployment
    {
        public ManagedOnlineDeployment() { }
        public string InstanceType { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.ProbeSettings ReadinessProbe { get { throw null; } set { } }
    }
    public partial class ManualScaleSettings : Azure.ResourceManager.MachineLearningServices.OnlineScaleSettings
    {
        public ManualScaleSettings() { }
        public int? InstanceCount { get { throw null; } set { } }
    }
    public partial class MedianStoppingPolicy : Azure.ResourceManager.MachineLearningServices.EarlyTerminationPolicy
    {
        public MedianStoppingPolicy() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MediaType : System.IEquatable<Azure.ResourceManager.MachineLearningServices.MediaType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MediaType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.MediaType Image { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.MediaType Text { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.MediaType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.MediaType left, Azure.ResourceManager.MachineLearningServices.MediaType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.MediaType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.MediaType left, Azure.ResourceManager.MachineLearningServices.MediaType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MLAssistConfiguration
    {
        public MLAssistConfiguration() { }
        public Azure.ResourceManager.MachineLearningServices.ComputeConfiguration InferencingComputeBinding { get { throw null; } set { } }
        public bool? MlAssistEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.ComputeConfiguration TrainingComputeBinding { get { throw null; } set { } }
    }
    public partial class ModelContainer
    {
        public ModelContainer() { }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Properties { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class ModelContainerResource : Azure.ResourceManager.MachineLearningServices.ModelContainerResourceOperations
    {
        internal ModelContainerResource() { }
        public Azure.ResourceManager.MachineLearningServices.ModelContainerResourceData Data { get { throw null; } }
        protected override Azure.ResourceManager.MachineLearningServices.ModelContainerResource GetResource(System.Threading.CancellationToken cancellation = default(System.Threading.CancellationToken)) { throw null; }
        protected override System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.ModelContainerResource> GetResourceAsync(System.Threading.CancellationToken cancellation = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ModelContainerResourceContainer : Azure.ResourceManager.Core.ResourceContainerBase<Azure.ResourceManager.Core.ResourceGroupResourceIdentifier, Azure.ResourceManager.MachineLearningServices.ModelContainerResource, Azure.ResourceManager.MachineLearningServices.ModelContainerResourceData>
    {
        protected ModelContainerResourceContainer() { }
        public new Azure.ResourceManager.Core.ResourceGroupResourceIdentifier Id { get { throw null; } }
        protected override Azure.ResourceManager.Core.ResourceType ValidResourceType { get { throw null; } }
        public Azure.Response<Azure.ResourceManager.MachineLearningServices.ModelContainerResource> CreateOrUpdate(string workspaceName, Azure.ResourceManager.MachineLearningServices.ModelContainer properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.ModelContainerResource>> CreateOrUpdateAsync(string workspaceName, Azure.ResourceManager.MachineLearningServices.ModelContainer properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Response<Azure.ResourceManager.MachineLearningServices.ModelContainerResource> Get(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.ModelContainerResource>> GetAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Pageable<Azure.ResourceManager.MachineLearningServices.ModelContainerResource> List(string skip = null, int? count = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Pageable<Azure.ResourceManager.Core.GenericResourceExpanded> ListAsGenericResource(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.AsyncPageable<Azure.ResourceManager.Core.GenericResourceExpanded> ListAsGenericResourceAsync(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.ModelContainerResource> ListAsync(string skip = null, int? count = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.ResourceManager.MachineLearningServices.ModelContainersCreateOrUpdateOperation StartCreateOrUpdate(string workspaceName, Azure.ResourceManager.MachineLearningServices.ModelContainer properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.ModelContainersCreateOrUpdateOperation> StartCreateOrUpdateAsync(string workspaceName, Azure.ResourceManager.MachineLearningServices.ModelContainer properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ModelContainerResourceData : Azure.ResourceManager.Core.Resource<Azure.ResourceManager.Core.ResourceGroupResourceIdentifier>
    {
        public ModelContainerResourceData(Azure.ResourceManager.MachineLearningServices.ModelContainer properties) { }
        public Azure.ResourceManager.MachineLearningServices.ModelContainer Properties { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.SystemData SystemData { get { throw null; } }
    }
    public partial class ModelContainerResourceOperations : Azure.ResourceManager.Core.ResourceOperationsBase<Azure.ResourceManager.Core.ResourceGroupResourceIdentifier, Azure.ResourceManager.MachineLearningServices.ModelContainerResource>
    {
        public static readonly Azure.ResourceManager.Core.ResourceType ResourceType;
        protected ModelContainerResourceOperations() { }
        protected internal ModelContainerResourceOperations(Azure.ResourceManager.Core.ResourceOperationsBase options, Azure.ResourceManager.Core.ResourceGroupResourceIdentifier id) { }
        protected override Azure.ResourceManager.Core.ResourceType ValidResourceType { get { throw null; } }
        public Azure.Response Delete(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Response> DeleteAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response<Azure.ResourceManager.MachineLearningServices.ModelContainerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.ModelContainerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.ResourceManager.MachineLearningServices.ModelVersionResourceContainer GetModelVersionResources() { throw null; }
        public System.Collections.Generic.IEnumerable<Azure.ResourceManager.Core.LocationData> ListAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Core.LocationData>> ListAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Operation StartDelete(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Operation> StartDeleteAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ModelContainersCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.MachineLearningServices.ModelContainerResource>
    {
        protected ModelContainersCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.MachineLearningServices.ModelContainerResource Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.ModelContainerResource>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.ModelContainerResource>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ModelContainersDeleteOperation : Azure.Operation
    {
        protected ModelContainersDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ModelVersion
    {
        public ModelVersion(string path) { }
        public string DatastoreId { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.MachineLearningServices.FlavorData> Flavors { get { throw null; } }
        public bool? IsAnonymous { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Properties { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class ModelVersionResource : Azure.ResourceManager.MachineLearningServices.ModelVersionResourceOperations
    {
        internal ModelVersionResource() { }
        public Azure.ResourceManager.MachineLearningServices.ModelVersionResourceData Data { get { throw null; } }
        protected override Azure.ResourceManager.MachineLearningServices.ModelVersionResource GetResource(System.Threading.CancellationToken cancellation = default(System.Threading.CancellationToken)) { throw null; }
        protected override System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.ModelVersionResource> GetResourceAsync(System.Threading.CancellationToken cancellation = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ModelVersionResourceContainer : Azure.ResourceManager.Core.ResourceContainerBase<Azure.ResourceManager.Core.ResourceGroupResourceIdentifier, Azure.ResourceManager.MachineLearningServices.ModelVersionResource, Azure.ResourceManager.MachineLearningServices.ModelVersionResourceData>
    {
        protected ModelVersionResourceContainer() { }
        public new Azure.ResourceManager.Core.ResourceGroupResourceIdentifier Id { get { throw null; } }
        protected override Azure.ResourceManager.Core.ResourceType ValidResourceType { get { throw null; } }
        public Azure.Response<Azure.ResourceManager.MachineLearningServices.ModelVersionResource> CreateOrUpdate(string workspaceName, Azure.ResourceManager.MachineLearningServices.ModelVersion properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.ModelVersionResource>> CreateOrUpdateAsync(string workspaceName, Azure.ResourceManager.MachineLearningServices.ModelVersion properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Response<Azure.ResourceManager.MachineLearningServices.ModelVersionResource> Get(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.ModelVersionResource>> GetAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Pageable<Azure.ResourceManager.MachineLearningServices.ModelVersionResource> List(string skip = null, string orderBy = null, int? top = default(int?), string version = null, string description = null, int? offset = default(int?), string tags = null, string properties = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Pageable<Azure.ResourceManager.Core.GenericResourceExpanded> ListAsGenericResource(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.AsyncPageable<Azure.ResourceManager.Core.GenericResourceExpanded> ListAsGenericResourceAsync(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.ModelVersionResource> ListAsync(string skip = null, string orderBy = null, int? top = default(int?), string version = null, string description = null, int? offset = default(int?), string tags = null, string properties = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.ResourceManager.MachineLearningServices.ModelVersionsCreateOrUpdateOperation StartCreateOrUpdate(string workspaceName, Azure.ResourceManager.MachineLearningServices.ModelVersion properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.ModelVersionsCreateOrUpdateOperation> StartCreateOrUpdateAsync(string workspaceName, Azure.ResourceManager.MachineLearningServices.ModelVersion properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ModelVersionResourceData : Azure.ResourceManager.Core.Resource<Azure.ResourceManager.Core.ResourceGroupResourceIdentifier>
    {
        public ModelVersionResourceData(Azure.ResourceManager.MachineLearningServices.ModelVersion properties) { }
        public Azure.ResourceManager.MachineLearningServices.ModelVersion Properties { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.SystemData SystemData { get { throw null; } }
    }
    public partial class ModelVersionResourceOperations : Azure.ResourceManager.Core.ResourceOperationsBase<Azure.ResourceManager.Core.ResourceGroupResourceIdentifier, Azure.ResourceManager.MachineLearningServices.ModelVersionResource>
    {
        public static readonly Azure.ResourceManager.Core.ResourceType ResourceType;
        protected ModelVersionResourceOperations() { }
        protected internal ModelVersionResourceOperations(Azure.ResourceManager.Core.ResourceOperationsBase options, Azure.ResourceManager.Core.ResourceGroupResourceIdentifier id) { }
        protected override Azure.ResourceManager.Core.ResourceType ValidResourceType { get { throw null; } }
        public Azure.Response Delete(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Response> DeleteAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response<Azure.ResourceManager.MachineLearningServices.ModelVersionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.ModelVersionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Collections.Generic.IEnumerable<Azure.ResourceManager.Core.LocationData> ListAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Core.LocationData>> ListAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Operation StartDelete(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Operation> StartDeleteAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ModelVersionsCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.MachineLearningServices.ModelVersionResource>
    {
        protected ModelVersionsCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.MachineLearningServices.ModelVersionResource Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.ModelVersionResource>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.ModelVersionResource>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ModelVersionsDeleteOperation : Azure.Operation
    {
        protected ModelVersionsDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class Mpi : Azure.ResourceManager.MachineLearningServices.DistributionConfiguration
    {
        public Mpi() { }
        public int? ProcessCountPerInstance { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NodeState : System.IEquatable<Azure.ResourceManager.MachineLearningServices.NodeState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NodeState(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.NodeState Idle { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.NodeState Leaving { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.NodeState Preempted { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.NodeState Preparing { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.NodeState Running { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.NodeState Unusable { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.NodeState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.NodeState left, Azure.ResourceManager.MachineLearningServices.NodeState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.NodeState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.NodeState left, Azure.ResourceManager.MachineLearningServices.NodeState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NodeStateCounts
    {
        internal NodeStateCounts() { }
        public int? IdleNodeCount { get { throw null; } }
        public int? LeavingNodeCount { get { throw null; } }
        public int? PreemptedNodeCount { get { throw null; } }
        public int? PreparingNodeCount { get { throw null; } }
        public int? RunningNodeCount { get { throw null; } }
        public int? UnusableNodeCount { get { throw null; } }
    }
    public partial class NoneDatastoreCredentials : Azure.ResourceManager.MachineLearningServices.DatastoreCredentials
    {
        public NoneDatastoreCredentials() { }
        public Azure.ResourceManager.MachineLearningServices.NoneDatastoreSecrets Secrets { get { throw null; } set { } }
    }
    public partial class NoneDatastoreSecrets : Azure.ResourceManager.MachineLearningServices.DatastoreSecrets
    {
        public NoneDatastoreSecrets() { }
    }
    public partial class NotebookAccessTokenResult
    {
        internal NotebookAccessTokenResult() { }
        public string AccessToken { get { throw null; } }
        public int? ExpiresIn { get { throw null; } }
        public string HostName { get { throw null; } }
        public string NotebookResourceId { get { throw null; } }
        public string PublicDns { get { throw null; } }
        public string RefreshToken { get { throw null; } }
        public string Scope { get { throw null; } }
        public string TokenType { get { throw null; } }
    }
    public partial class NotebookPreparationError
    {
        internal NotebookPreparationError() { }
        public string ErrorMessage { get { throw null; } }
        public int? StatusCode { get { throw null; } }
    }
    public partial class NotebookResourceInfo
    {
        internal NotebookResourceInfo() { }
        public string Fqdn { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.NotebookPreparationError NotebookPreparationError { get { throw null; } }
        public string ResourceId { get { throw null; } }
    }
    public partial class Objective
    {
        public Objective(Azure.ResourceManager.MachineLearningServices.Goal goal, string primaryMetric) { }
        public Azure.ResourceManager.MachineLearningServices.Goal Goal { get { throw null; } set { } }
        public string PrimaryMetric { get { throw null; } set { } }
    }
    public partial class OnlineDeployment
    {
        public OnlineDeployment() { }
        public bool? AppInsightsEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.CodeConfiguration CodeConfiguration { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string EnvironmentId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> EnvironmentVariables { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.ProbeSettings LivenessProbe { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.AssetReferenceBase Model { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Properties { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.DeploymentProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.OnlineRequestSettings RequestSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.OnlineScaleSettings ScaleSettings { get { throw null; } set { } }
    }
    public partial class OnlineDeploymentsCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.MachineLearningServices.OnlineDeploymentTrackedResource>
    {
        protected OnlineDeploymentsCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.MachineLearningServices.OnlineDeploymentTrackedResource Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.OnlineDeploymentTrackedResource>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.OnlineDeploymentTrackedResource>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OnlineDeploymentsDeleteOperation : Azure.Operation
    {
        protected OnlineDeploymentsDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OnlineDeploymentsUpdateOperation : Azure.Operation<Azure.ResourceManager.MachineLearningServices.OnlineDeploymentTrackedResource>
    {
        protected OnlineDeploymentsUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.MachineLearningServices.OnlineDeploymentTrackedResource Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.OnlineDeploymentTrackedResource>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.OnlineDeploymentTrackedResource>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OnlineDeploymentTrackedResource : Azure.ResourceManager.MachineLearningServices.OnlineDeploymentTrackedResourceOperations
    {
        internal OnlineDeploymentTrackedResource() { }
        public Azure.ResourceManager.MachineLearningServices.OnlineDeploymentTrackedResourceData Data { get { throw null; } }
        protected override Azure.ResourceManager.MachineLearningServices.OnlineDeploymentTrackedResource GetResource(System.Threading.CancellationToken cancellation = default(System.Threading.CancellationToken)) { throw null; }
        protected override System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.OnlineDeploymentTrackedResource> GetResourceAsync(System.Threading.CancellationToken cancellation = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OnlineDeploymentTrackedResourceContainer : Azure.ResourceManager.Core.ResourceContainerBase<Azure.ResourceManager.Core.ResourceGroupResourceIdentifier, Azure.ResourceManager.MachineLearningServices.OnlineDeploymentTrackedResource, Azure.ResourceManager.MachineLearningServices.OnlineDeploymentTrackedResourceData>
    {
        protected OnlineDeploymentTrackedResourceContainer() { }
        public new Azure.ResourceManager.Core.ResourceGroupResourceIdentifier Id { get { throw null; } }
        protected override Azure.ResourceManager.Core.ResourceType ValidResourceType { get { throw null; } }
        public Azure.Response<Azure.ResourceManager.MachineLearningServices.OnlineDeploymentTrackedResource> CreateOrUpdate(string workspaceName, Azure.ResourceManager.MachineLearningServices.OnlineDeploymentTrackedResourceData body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.OnlineDeploymentTrackedResource>> CreateOrUpdateAsync(string workspaceName, Azure.ResourceManager.MachineLearningServices.OnlineDeploymentTrackedResourceData body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Response<Azure.ResourceManager.MachineLearningServices.OnlineDeploymentTrackedResource> Get(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.OnlineDeploymentTrackedResource>> GetAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Pageable<Azure.ResourceManager.MachineLearningServices.OnlineDeploymentTrackedResource> List(string orderBy = null, int? top = default(int?), string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Pageable<Azure.ResourceManager.Core.GenericResourceExpanded> ListAsGenericResource(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.AsyncPageable<Azure.ResourceManager.Core.GenericResourceExpanded> ListAsGenericResourceAsync(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.OnlineDeploymentTrackedResource> ListAsync(string orderBy = null, int? top = default(int?), string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.ResourceManager.MachineLearningServices.OnlineDeploymentsCreateOrUpdateOperation StartCreateOrUpdate(string workspaceName, Azure.ResourceManager.MachineLearningServices.OnlineDeploymentTrackedResourceData body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.OnlineDeploymentsCreateOrUpdateOperation> StartCreateOrUpdateAsync(string workspaceName, Azure.ResourceManager.MachineLearningServices.OnlineDeploymentTrackedResourceData body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OnlineDeploymentTrackedResourceData : Azure.ResourceManager.Core.TrackedResource<Azure.ResourceManager.Core.ResourceGroupResourceIdentifier>
    {
        public OnlineDeploymentTrackedResourceData(Azure.ResourceManager.Core.LocationData location, Azure.ResourceManager.MachineLearningServices.OnlineDeployment properties) { }
        public Azure.ResourceManager.MachineLearningServices.ResourceIdentity Identity { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.OnlineDeployment Properties { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.SystemData SystemData { get { throw null; } }
    }
    public partial class OnlineDeploymentTrackedResourceOperations : Azure.ResourceManager.Core.ResourceOperationsBase<Azure.ResourceManager.Core.ResourceGroupResourceIdentifier, Azure.ResourceManager.MachineLearningServices.OnlineDeploymentTrackedResource>
    {
        public static readonly Azure.ResourceManager.Core.ResourceType ResourceType;
        protected OnlineDeploymentTrackedResourceOperations() { }
        protected internal OnlineDeploymentTrackedResourceOperations(Azure.ResourceManager.Core.ResourceOperationsBase options, Azure.ResourceManager.Core.ResourceGroupResourceIdentifier id) { }
        protected override Azure.ResourceManager.Core.ResourceType ValidResourceType { get { throw null; } }
        public Azure.Response<Azure.ResourceManager.MachineLearningServices.OnlineDeploymentTrackedResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.OnlineDeploymentTrackedResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Response Delete(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Response> DeleteAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response<Azure.ResourceManager.MachineLearningServices.OnlineDeploymentTrackedResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.OnlineDeploymentTrackedResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.DeploymentLogs> GetLogs(Azure.ResourceManager.MachineLearningServices.ContainerType? containerType = default(Azure.ResourceManager.MachineLearningServices.ContainerType?), int? tail = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.DeploymentLogs>> GetLogsAsync(Azure.ResourceManager.MachineLearningServices.ContainerType? containerType = default(Azure.ResourceManager.MachineLearningServices.ContainerType?), int? tail = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Collections.Generic.IEnumerable<Azure.ResourceManager.Core.LocationData> ListAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Core.LocationData>> ListAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Response<Azure.ResourceManager.MachineLearningServices.OnlineDeploymentTrackedResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.OnlineDeploymentTrackedResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Response<Azure.ResourceManager.MachineLearningServices.OnlineDeploymentTrackedResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.OnlineDeploymentTrackedResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.ResourceManager.MachineLearningServices.OnlineDeploymentsUpdateOperation StartAddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.OnlineDeploymentsUpdateOperation> StartAddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Operation StartDelete(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Operation> StartDeleteAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.ResourceManager.MachineLearningServices.OnlineDeploymentsUpdateOperation StartRemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.OnlineDeploymentsUpdateOperation> StartRemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.ResourceManager.MachineLearningServices.OnlineDeploymentsUpdateOperation StartSetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.OnlineDeploymentsUpdateOperation> StartSetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OnlineEndpoint
    {
        public OnlineEndpoint(Azure.ResourceManager.MachineLearningServices.EndpointAuthMode authMode) { }
        public Azure.ResourceManager.MachineLearningServices.EndpointAuthMode AuthMode { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.EndpointAuthKeys Keys { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Properties { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.EndpointProvisioningState? ProvisioningState { get { throw null; } }
        public string ScoringUri { get { throw null; } }
        public string SwaggerUri { get { throw null; } }
        public string Target { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, int> Traffic { get { throw null; } }
    }
    public partial class OnlineEndpointsCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.MachineLearningServices.OnlineEndpointTrackedResource>
    {
        protected OnlineEndpointsCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.MachineLearningServices.OnlineEndpointTrackedResource Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.OnlineEndpointTrackedResource>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.OnlineEndpointTrackedResource>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OnlineEndpointsDeleteOperation : Azure.Operation
    {
        protected OnlineEndpointsDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OnlineEndpointsRegenerateKeysOperation : Azure.Operation
    {
        protected OnlineEndpointsRegenerateKeysOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OnlineEndpointsUpdateOperation : Azure.Operation<Azure.ResourceManager.MachineLearningServices.OnlineEndpointTrackedResource>
    {
        protected OnlineEndpointsUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.MachineLearningServices.OnlineEndpointTrackedResource Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.OnlineEndpointTrackedResource>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.OnlineEndpointTrackedResource>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OnlineEndpointTrackedResource : Azure.ResourceManager.MachineLearningServices.OnlineEndpointTrackedResourceOperations
    {
        internal OnlineEndpointTrackedResource() { }
        public Azure.ResourceManager.MachineLearningServices.OnlineEndpointTrackedResourceData Data { get { throw null; } }
        protected override Azure.ResourceManager.MachineLearningServices.OnlineEndpointTrackedResource GetResource(System.Threading.CancellationToken cancellation = default(System.Threading.CancellationToken)) { throw null; }
        protected override System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.OnlineEndpointTrackedResource> GetResourceAsync(System.Threading.CancellationToken cancellation = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OnlineEndpointTrackedResourceContainer : Azure.ResourceManager.Core.ResourceContainerBase<Azure.ResourceManager.Core.ResourceGroupResourceIdentifier, Azure.ResourceManager.MachineLearningServices.OnlineEndpointTrackedResource, Azure.ResourceManager.MachineLearningServices.OnlineEndpointTrackedResourceData>
    {
        protected OnlineEndpointTrackedResourceContainer() { }
        public new Azure.ResourceManager.Core.ResourceGroupResourceIdentifier Id { get { throw null; } }
        protected override Azure.ResourceManager.Core.ResourceType ValidResourceType { get { throw null; } }
        public Azure.Response<Azure.ResourceManager.MachineLearningServices.OnlineEndpointTrackedResource> CreateOrUpdate(string workspaceName, Azure.ResourceManager.MachineLearningServices.OnlineEndpointTrackedResourceData body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.OnlineEndpointTrackedResource>> CreateOrUpdateAsync(string workspaceName, Azure.ResourceManager.MachineLearningServices.OnlineEndpointTrackedResourceData body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Response<Azure.ResourceManager.MachineLearningServices.OnlineEndpointTrackedResource> Get(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.OnlineEndpointTrackedResource>> GetAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Pageable<Azure.ResourceManager.MachineLearningServices.OnlineEndpointTrackedResource> List(string name = null, int? count = default(int?), Azure.ResourceManager.MachineLearningServices.EndpointComputeType? computeType = default(Azure.ResourceManager.MachineLearningServices.EndpointComputeType?), string skip = null, string tags = null, string properties = null, Azure.ResourceManager.MachineLearningServices.OrderString? orderBy = default(Azure.ResourceManager.MachineLearningServices.OrderString?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Pageable<Azure.ResourceManager.Core.GenericResourceExpanded> ListAsGenericResource(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.AsyncPageable<Azure.ResourceManager.Core.GenericResourceExpanded> ListAsGenericResourceAsync(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.OnlineEndpointTrackedResource> ListAsync(string name = null, int? count = default(int?), Azure.ResourceManager.MachineLearningServices.EndpointComputeType? computeType = default(Azure.ResourceManager.MachineLearningServices.EndpointComputeType?), string skip = null, string tags = null, string properties = null, Azure.ResourceManager.MachineLearningServices.OrderString? orderBy = default(Azure.ResourceManager.MachineLearningServices.OrderString?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.EndpointAuthKeys> ListKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.EndpointAuthKeys>> ListKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.ResourceManager.MachineLearningServices.OnlineEndpointsCreateOrUpdateOperation StartCreateOrUpdate(string workspaceName, Azure.ResourceManager.MachineLearningServices.OnlineEndpointTrackedResourceData body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.OnlineEndpointsCreateOrUpdateOperation> StartCreateOrUpdateAsync(string workspaceName, Azure.ResourceManager.MachineLearningServices.OnlineEndpointTrackedResourceData body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OnlineEndpointTrackedResourceData : Azure.ResourceManager.Core.TrackedResource<Azure.ResourceManager.Core.ResourceGroupResourceIdentifier>
    {
        public OnlineEndpointTrackedResourceData(Azure.ResourceManager.Core.LocationData location, Azure.ResourceManager.MachineLearningServices.OnlineEndpoint properties) { }
        public Azure.ResourceManager.MachineLearningServices.ResourceIdentity Identity { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.OnlineEndpoint Properties { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.SystemData SystemData { get { throw null; } }
    }
    public partial class OnlineEndpointTrackedResourceOperations : Azure.ResourceManager.Core.ResourceOperationsBase<Azure.ResourceManager.Core.ResourceGroupResourceIdentifier, Azure.ResourceManager.MachineLearningServices.OnlineEndpointTrackedResource>
    {
        public static readonly Azure.ResourceManager.Core.ResourceType ResourceType;
        protected OnlineEndpointTrackedResourceOperations() { }
        protected internal OnlineEndpointTrackedResourceOperations(Azure.ResourceManager.Core.ResourceOperationsBase options, Azure.ResourceManager.Core.ResourceGroupResourceIdentifier id) { }
        protected override Azure.ResourceManager.Core.ResourceType ValidResourceType { get { throw null; } }
        public Azure.Response<Azure.ResourceManager.MachineLearningServices.OnlineEndpointTrackedResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.OnlineEndpointTrackedResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Response Delete(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Response> DeleteAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response<Azure.ResourceManager.MachineLearningServices.OnlineEndpointTrackedResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.OnlineEndpointTrackedResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.ResourceManager.MachineLearningServices.OnlineDeploymentTrackedResourceContainer GetOnlineDeploymentTrackedResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.EndpointAuthToken> GetToken(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.EndpointAuthToken>> GetTokenAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Collections.Generic.IEnumerable<Azure.ResourceManager.Core.LocationData> ListAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Core.LocationData>> ListAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Response RegenerateKeys(Azure.ResourceManager.MachineLearningServices.KeyType keyType, string keyValue = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Response> RegenerateKeysAsync(Azure.ResourceManager.MachineLearningServices.KeyType keyType, string keyValue = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Response<Azure.ResourceManager.MachineLearningServices.OnlineEndpointTrackedResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.OnlineEndpointTrackedResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Response<Azure.ResourceManager.MachineLearningServices.OnlineEndpointTrackedResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.OnlineEndpointTrackedResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.ResourceManager.MachineLearningServices.OnlineEndpointsUpdateOperation StartAddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.OnlineEndpointsUpdateOperation> StartAddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Operation StartDelete(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Operation> StartDeleteAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Operation StartRegenerateKeys(Azure.ResourceManager.MachineLearningServices.KeyType keyType, string keyValue = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Operation> StartRegenerateKeysAsync(Azure.ResourceManager.MachineLearningServices.KeyType keyType, string keyValue = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.ResourceManager.MachineLearningServices.OnlineEndpointsUpdateOperation StartRemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.OnlineEndpointsUpdateOperation> StartRemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.ResourceManager.MachineLearningServices.OnlineEndpointsUpdateOperation StartSetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.OnlineEndpointsUpdateOperation> StartSetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OnlineRequestSettings
    {
        public OnlineRequestSettings() { }
        public int? MaxConcurrentRequestsPerInstance { get { throw null; } set { } }
        public System.TimeSpan? MaxQueueWait { get { throw null; } set { } }
        public System.TimeSpan? RequestTimeout { get { throw null; } set { } }
    }
    public partial class OnlineScaleSettings
    {
        public OnlineScaleSettings() { }
        public int? MaxInstances { get { throw null; } set { } }
        public int? MinInstances { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperatingSystemType : System.IEquatable<Azure.ResourceManager.MachineLearningServices.OperatingSystemType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperatingSystemType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.OperatingSystemType Linux { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.OperatingSystemType Windows { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.OperatingSystemType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.OperatingSystemType left, Azure.ResourceManager.MachineLearningServices.OperatingSystemType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.OperatingSystemType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.OperatingSystemType left, Azure.ResourceManager.MachineLearningServices.OperatingSystemType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperationName : System.IEquatable<Azure.ResourceManager.MachineLearningServices.OperationName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperationName(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.OperationName Create { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.OperationName Delete { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.OperationName Reimage { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.OperationName Restart { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.OperationName Start { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.OperationName Stop { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.OperationName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.OperationName left, Azure.ResourceManager.MachineLearningServices.OperationName right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.OperationName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.OperationName left, Azure.ResourceManager.MachineLearningServices.OperationName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperationStatus : System.IEquatable<Azure.ResourceManager.MachineLearningServices.OperationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperationStatus(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.OperationStatus CreateFailed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.OperationStatus DeleteFailed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.OperationStatus InProgress { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.OperationStatus ReimageFailed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.OperationStatus RestartFailed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.OperationStatus StartFailed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.OperationStatus StopFailed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.OperationStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.OperationStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.OperationStatus left, Azure.ResourceManager.MachineLearningServices.OperationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.OperationStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.OperationStatus left, Azure.ResourceManager.MachineLearningServices.OperationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OrderString : System.IEquatable<Azure.ResourceManager.MachineLearningServices.OrderString>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OrderString(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.OrderString CreatedAtAsc { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.OrderString CreatedAtDesc { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.OrderString UpdatedAtAsc { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.OrderString UpdatedAtDesc { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.OrderString other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.OrderString left, Azure.ResourceManager.MachineLearningServices.OrderString right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.OrderString (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.OrderString left, Azure.ResourceManager.MachineLearningServices.OrderString right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OriginType : System.IEquatable<Azure.ResourceManager.MachineLearningServices.OriginType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OriginType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.OriginType Synapse { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.OriginType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.OriginType left, Azure.ResourceManager.MachineLearningServices.OriginType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.OriginType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.OriginType left, Azure.ResourceManager.MachineLearningServices.OriginType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OsType : System.IEquatable<Azure.ResourceManager.MachineLearningServices.OsType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OsType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.OsType Linux { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.OsType Windows { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.OsType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.OsType left, Azure.ResourceManager.MachineLearningServices.OsType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.OsType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.OsType left, Azure.ResourceManager.MachineLearningServices.OsType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OutputDataBinding
    {
        public OutputDataBinding() { }
        public string DatastoreId { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.DataBindingMode? Mode { get { throw null; } set { } }
        public string PathOnCompute { get { throw null; } set { } }
        public string PathOnDatastore { get { throw null; } set { } }
    }
    public partial class OutputPathAssetReference : Azure.ResourceManager.MachineLearningServices.AssetReferenceBase
    {
        public OutputPathAssetReference() { }
        public string JobId { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
    }
    public partial class PartialAksOnlineDeployment : Azure.ResourceManager.MachineLearningServices.PartialOnlineDeployment
    {
        public PartialAksOnlineDeployment() { }
        public Azure.ResourceManager.MachineLearningServices.ContainerResourceRequirements ContainerResourceRequirements { get { throw null; } set { } }
    }
    public partial class PartialBatchDeployment
    {
        public PartialBatchDeployment() { }
        public string Description { get { throw null; } set { } }
    }
    public partial class PartialBatchDeploymentPartialTrackedResource
    {
        public PartialBatchDeploymentPartialTrackedResource() { }
        public Azure.ResourceManager.MachineLearningServices.ResourceIdentity Identity { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public string Location { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.PartialBatchDeployment Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class PartialBatchEndpoint
    {
        public PartialBatchEndpoint() { }
        public System.Collections.Generic.IDictionary<string, int> Traffic { get { throw null; } }
    }
    public partial class PartialBatchEndpointPartialTrackedResource
    {
        public PartialBatchEndpointPartialTrackedResource() { }
        public Azure.ResourceManager.MachineLearningServices.ResourceIdentity Identity { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public string Location { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.PartialBatchEndpoint Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class PartialManagedOnlineDeployment : Azure.ResourceManager.MachineLearningServices.PartialOnlineDeployment
    {
        public PartialManagedOnlineDeployment() { }
        public Azure.ResourceManager.MachineLearningServices.ProbeSettings ReadinessProbe { get { throw null; } set { } }
    }
    public partial class PartialOnlineDeployment
    {
        public PartialOnlineDeployment() { }
        public bool? AppInsightsEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.ProbeSettings LivenessProbe { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.OnlineRequestSettings RequestSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.OnlineScaleSettings ScaleSettings { get { throw null; } set { } }
    }
    public partial class PartialOnlineDeploymentPartialTrackedResource
    {
        public PartialOnlineDeploymentPartialTrackedResource() { }
        public Azure.ResourceManager.MachineLearningServices.ResourceIdentity Identity { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public string Location { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.PartialOnlineDeployment Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class PartialOnlineEndpoint
    {
        public PartialOnlineEndpoint() { }
        public System.Collections.Generic.IDictionary<string, int> Traffic { get { throw null; } }
    }
    public partial class PartialOnlineEndpointPartialTrackedResource
    {
        public PartialOnlineEndpointPartialTrackedResource() { }
        public Azure.ResourceManager.MachineLearningServices.ResourceIdentity Identity { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public string Location { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.PartialOnlineEndpoint Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class Password
    {
        internal Password() { }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class PersonalComputeInstanceSettings
    {
        public PersonalComputeInstanceSettings() { }
        public Azure.ResourceManager.MachineLearningServices.AssignedUser AssignedUser { get { throw null; } set { } }
    }
    public partial class PrivateEndpoint : Azure.ResourceManager.Core.SubResource<Azure.ResourceManager.Core.ResourceIdentifier>
    {
        public PrivateEndpoint() { }
        public string SubnetArmId { get { throw null; } }
    }
    public partial class PrivateEndpointConnection : Azure.ResourceManager.MachineLearningServices.PrivateEndpointConnectionOperations
    {
        internal PrivateEndpointConnection() { }
        public Azure.ResourceManager.MachineLearningServices.PrivateEndpointConnectionData Data { get { throw null; } }
        protected override Azure.ResourceManager.MachineLearningServices.PrivateEndpointConnection GetResource(System.Threading.CancellationToken cancellation = default(System.Threading.CancellationToken)) { throw null; }
        protected override System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.PrivateEndpointConnection> GetResourceAsync(System.Threading.CancellationToken cancellation = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateEndpointConnectionContainer : Azure.ResourceManager.Core.ResourceContainerBase<Azure.ResourceManager.Core.ResourceGroupResourceIdentifier, Azure.ResourceManager.MachineLearningServices.PrivateEndpointConnection, Azure.ResourceManager.MachineLearningServices.PrivateEndpointConnectionData>
    {
        protected PrivateEndpointConnectionContainer() { }
        public new Azure.ResourceManager.Core.ResourceGroupResourceIdentifier Id { get { throw null; } }
        protected override Azure.ResourceManager.Core.ResourceType ValidResourceType { get { throw null; } }
        public Azure.Response<Azure.ResourceManager.MachineLearningServices.PrivateEndpointConnection> CreateOrUpdate(string privateEndpointConnectionName, Azure.ResourceManager.MachineLearningServices.PrivateEndpointConnectionData properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.PrivateEndpointConnection>> CreateOrUpdateAsync(string privateEndpointConnectionName, Azure.ResourceManager.MachineLearningServices.PrivateEndpointConnectionData properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Response<Azure.ResourceManager.MachineLearningServices.PrivateEndpointConnection> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.PrivateEndpointConnection>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Pageable<Azure.ResourceManager.MachineLearningServices.PrivateEndpointConnection> List(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Pageable<Azure.ResourceManager.Core.GenericResourceExpanded> ListAsGenericResource(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.AsyncPageable<Azure.ResourceManager.Core.GenericResourceExpanded> ListAsGenericResourceAsync(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.PrivateEndpointConnection> ListAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.ResourceManager.MachineLearningServices.PrivateEndpointConnectionsCreateOrUpdateOperation StartCreateOrUpdate(string privateEndpointConnectionName, Azure.ResourceManager.MachineLearningServices.PrivateEndpointConnectionData properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.PrivateEndpointConnectionsCreateOrUpdateOperation> StartCreateOrUpdateAsync(string privateEndpointConnectionName, Azure.ResourceManager.MachineLearningServices.PrivateEndpointConnectionData properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateEndpointConnectionData : Azure.ResourceManager.Core.Resource<Azure.ResourceManager.Core.ResourceGroupResourceIdentifier>
    {
        public PrivateEndpointConnectionData() { }
        public Azure.ResourceManager.MachineLearningServices.Identity Identity { get { throw null; } set { } }
        public string Location { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.PrivateEndpoint PrivateEndpoint { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.PrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.PrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Sku Sku { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.SystemData SystemData { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class PrivateEndpointConnectionOperations : Azure.ResourceManager.Core.ResourceOperationsBase<Azure.ResourceManager.Core.ResourceGroupResourceIdentifier, Azure.ResourceManager.MachineLearningServices.PrivateEndpointConnection>
    {
        public static readonly Azure.ResourceManager.Core.ResourceType ResourceType;
        protected PrivateEndpointConnectionOperations() { }
        protected internal PrivateEndpointConnectionOperations(Azure.ResourceManager.Core.ResourceOperationsBase options, Azure.ResourceManager.Core.ResourceGroupResourceIdentifier id) { }
        protected override Azure.ResourceManager.Core.ResourceType ValidResourceType { get { throw null; } }
        public Azure.Response Delete(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Response> DeleteAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response<Azure.ResourceManager.MachineLearningServices.PrivateEndpointConnection> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.PrivateEndpointConnection>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Collections.Generic.IEnumerable<Azure.ResourceManager.Core.LocationData> ListAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Core.LocationData>> ListAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Operation StartDelete(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Operation> StartDeleteAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PrivateEndpointConnectionProvisioningState : System.IEquatable<Azure.ResourceManager.MachineLearningServices.PrivateEndpointConnectionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PrivateEndpointConnectionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.PrivateEndpointConnectionProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.PrivateEndpointConnectionProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.PrivateEndpointConnectionProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.PrivateEndpointConnectionProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.PrivateEndpointConnectionProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.PrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.MachineLearningServices.PrivateEndpointConnectionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.PrivateEndpointConnectionProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.PrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.MachineLearningServices.PrivateEndpointConnectionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PrivateEndpointConnectionsCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.MachineLearningServices.PrivateEndpointConnection>
    {
        protected PrivateEndpointConnectionsCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.MachineLearningServices.PrivateEndpointConnection Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.PrivateEndpointConnection>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.PrivateEndpointConnection>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateEndpointConnectionsDeleteOperation : Azure.Operation
    {
        protected PrivateEndpointConnectionsDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PrivateEndpointServiceConnectionStatus : System.IEquatable<Azure.ResourceManager.MachineLearningServices.PrivateEndpointServiceConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PrivateEndpointServiceConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.PrivateEndpointServiceConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.PrivateEndpointServiceConnectionStatus Disconnected { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.PrivateEndpointServiceConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.PrivateEndpointServiceConnectionStatus Rejected { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.PrivateEndpointServiceConnectionStatus Timeout { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.PrivateEndpointServiceConnectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.PrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.MachineLearningServices.PrivateEndpointServiceConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.PrivateEndpointServiceConnectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.PrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.MachineLearningServices.PrivateEndpointServiceConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PrivateLinkResource : Azure.ResourceManager.Core.Resource<Azure.ResourceManager.Core.TenantResourceIdentifier>
    {
        public PrivateLinkResource() { }
        public string GroupId { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Identity Identity { get { throw null; } set { } }
        public string Location { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredZoneNames { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Sku Sku { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.SystemData SystemData { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class PrivateLinkResourceListResult
    {
        internal PrivateLinkResourceListResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearningServices.PrivateLinkResource> Value { get { throw null; } }
    }
    public partial class PrivateLinkServiceConnectionState
    {
        public PrivateLinkServiceConnectionState() { }
        public string ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.PrivateEndpointServiceConnectionStatus? Status { get { throw null; } set { } }
    }
    public partial class ProbeSettings
    {
        public ProbeSettings() { }
        public int? FailureThreshold { get { throw null; } set { } }
        public System.TimeSpan? InitialDelay { get { throw null; } set { } }
        public System.TimeSpan? Period { get { throw null; } set { } }
        public int? SuccessThreshold { get { throw null; } set { } }
        public System.TimeSpan? Timeout { get { throw null; } set { } }
    }
    public partial class ProgressMetrics
    {
        internal ProgressMetrics() { }
        public long? CompletedDatapointCount { get { throw null; } }
        public System.DateTimeOffset? IncrementalDatasetLastRefreshTime { get { throw null; } }
        public long? SkippedDatapointCount { get { throw null; } }
        public long? TotalDatapointCount { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.MachineLearningServices.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.ProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.ProvisioningState Unknown { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.ProvisioningState left, Azure.ResourceManager.MachineLearningServices.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.ProvisioningState left, Azure.ResourceManager.MachineLearningServices.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningStatus : System.IEquatable<Azure.ResourceManager.MachineLearningServices.ProvisioningStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningStatus(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.ProvisioningStatus Completed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.ProvisioningStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.ProvisioningStatus Provisioning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.ProvisioningStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.ProvisioningStatus left, Azure.ResourceManager.MachineLearningServices.ProvisioningStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.ProvisioningStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.ProvisioningStatus left, Azure.ResourceManager.MachineLearningServices.ProvisioningStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PyTorch : Azure.ResourceManager.MachineLearningServices.DistributionConfiguration
    {
        public PyTorch() { }
        public int? ProcessCount { get { throw null; } set { } }
    }
    public partial class QuotaBaseProperties : Azure.ResourceManager.Core.WritableSubResource<Azure.ResourceManager.Core.ResourceIdentifier>
    {
        public QuotaBaseProperties() { }
        public long? Limit { get { throw null; } set { } }
        public string Type { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.QuotaUnit? Unit { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct QuotaUnit : System.IEquatable<Azure.ResourceManager.MachineLearningServices.QuotaUnit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public QuotaUnit(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.QuotaUnit Count { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.QuotaUnit other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.QuotaUnit left, Azure.ResourceManager.MachineLearningServices.QuotaUnit right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.QuotaUnit (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.QuotaUnit left, Azure.ResourceManager.MachineLearningServices.QuotaUnit right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ReasonCode : System.IEquatable<Azure.ResourceManager.MachineLearningServices.ReasonCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ReasonCode(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.ReasonCode NotAvailableForRegion { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.ReasonCode NotAvailableForSubscription { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.ReasonCode NotSpecified { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.ReasonCode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.ReasonCode left, Azure.ResourceManager.MachineLearningServices.ReasonCode right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.ReasonCode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.ReasonCode left, Azure.ResourceManager.MachineLearningServices.ReasonCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Recurrence
    {
        public Recurrence() { }
        public Azure.ResourceManager.MachineLearningServices.RecurrenceFrequency? Frequency { get { throw null; } set { } }
        public int? Interval { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.RecurrenceSchedule Schedule { get { throw null; } set { } }
        public string StartTime { get { throw null; } set { } }
        public string TimeZone { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RecurrenceFrequency : System.IEquatable<Azure.ResourceManager.MachineLearningServices.RecurrenceFrequency>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecurrenceFrequency(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.RecurrenceFrequency Day { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.RecurrenceFrequency Hour { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.RecurrenceFrequency Minute { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.RecurrenceFrequency Month { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.RecurrenceFrequency NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.RecurrenceFrequency Second { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.RecurrenceFrequency Week { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.RecurrenceFrequency Year { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.RecurrenceFrequency other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.RecurrenceFrequency left, Azure.ResourceManager.MachineLearningServices.RecurrenceFrequency right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.RecurrenceFrequency (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.RecurrenceFrequency left, Azure.ResourceManager.MachineLearningServices.RecurrenceFrequency right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RecurrenceSchedule
    {
        public RecurrenceSchedule() { }
        public System.Collections.Generic.IList<int> Hours { get { throw null; } }
        public System.Collections.Generic.IList<int> Minutes { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.MachineLearningServices.DaysOfWeek> WeekDays { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ReferenceType : System.IEquatable<Azure.ResourceManager.MachineLearningServices.ReferenceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ReferenceType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.ReferenceType DataPath { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.ReferenceType Id { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.ReferenceType OutputPath { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.ReferenceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.ReferenceType left, Azure.ResourceManager.MachineLearningServices.ReferenceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.ReferenceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.ReferenceType left, Azure.ResourceManager.MachineLearningServices.ReferenceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RegistryListCredentialsResult
    {
        internal RegistryListCredentialsResult() { }
        public string Location { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearningServices.Password> Passwords { get { throw null; } }
        public string Username { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RemoteLoginPortPublicAccess : System.IEquatable<Azure.ResourceManager.MachineLearningServices.RemoteLoginPortPublicAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RemoteLoginPortPublicAccess(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.RemoteLoginPortPublicAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.RemoteLoginPortPublicAccess Enabled { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.RemoteLoginPortPublicAccess NotSpecified { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.RemoteLoginPortPublicAccess other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.RemoteLoginPortPublicAccess left, Azure.ResourceManager.MachineLearningServices.RemoteLoginPortPublicAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.RemoteLoginPortPublicAccess (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.RemoteLoginPortPublicAccess left, Azure.ResourceManager.MachineLearningServices.RemoteLoginPortPublicAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Resource : Azure.ResourceManager.Core.SubResource<Azure.ResourceManager.Core.ResourceGroupResourceIdentifier>
    {
        public Resource() { }
        public string Name { get { throw null; } }
        public string Type { get { throw null; } }
    }
    public static partial class ResourceGroupExtensions
    {
        public static Azure.ResourceManager.MachineLearningServices.WorkspaceContainer GetWorkspaces(this Azure.ResourceManager.Core.ResourceGroupOperations resourceGroup) { throw null; }
    }
    public partial class ResourceId
    {
        public ResourceId(string id) { }
        public string Id { get { throw null; } set { } }
    }
    public partial class ResourceIdentity
    {
        public ResourceIdentity() { }
        public string PrincipalId { get { throw null; } }
        public string TenantId { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.ResourceIdentityAssignment? Type { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.MachineLearningServices.UserAssignedIdentityMeta> UserAssignedIdentities { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceIdentityAssignment : System.IEquatable<Azure.ResourceManager.MachineLearningServices.ResourceIdentityAssignment>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceIdentityAssignment(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.ResourceIdentityAssignment None { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.ResourceIdentityAssignment SystemAssigned { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.ResourceIdentityAssignment SystemAssignedUserAssigned { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.ResourceIdentityAssignment UserAssigned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.ResourceIdentityAssignment other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.ResourceIdentityAssignment left, Azure.ResourceManager.MachineLearningServices.ResourceIdentityAssignment right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.ResourceIdentityAssignment (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.ResourceIdentityAssignment left, Azure.ResourceManager.MachineLearningServices.ResourceIdentityAssignment right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum ResourceIdentityType
    {
        SystemAssigned = 0,
        SystemAssignedUserAssigned = 1,
        UserAssigned = 2,
        None = 3,
    }
    public partial class ResourceName
    {
        internal ResourceName() { }
        public string LocalizedValue { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class ResourceQuota : Azure.ResourceManager.Core.SubResource<Azure.ResourceManager.Core.ResourceIdentifier>
    {
        internal ResourceQuota() { }
        public string AmlWorkspaceLocation { get { throw null; } }
        public long? Limit { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.ResourceName Name { get { throw null; } }
        public string Type { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.QuotaUnit? Unit { get { throw null; } }
    }
    public partial class ResourceSkuLocationInfo
    {
        internal ResourceSkuLocationInfo() { }
        public string Location { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearningServices.ResourceSkuZoneDetails> ZoneDetails { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Zones { get { throw null; } }
    }
    public partial class ResourceSkuZoneDetails
    {
        internal ResourceSkuZoneDetails() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearningServices.SKUCapability> Capabilities { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Name { get { throw null; } }
    }
    public partial class RestApi
    {
        internal RestApi() { }
        public Azure.ResourceManager.MachineLearningServices.RestApiDisplay Display { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class RestApiContainer : Azure.ResourceManager.Core.ContainerBase
    {
        protected RestApiContainer() { }
        protected override Azure.ResourceManager.Core.ResourceType ValidResourceType { get { throw null; } }
        public Azure.Pageable<Azure.ResourceManager.MachineLearningServices.RestApi> List(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.RestApi> ListAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RestApiDisplay
    {
        internal RestApiDisplay() { }
        public string Description { get { throw null; } }
        public string Operation { get { throw null; } }
        public string Provider { get { throw null; } }
        public string Resource { get { throw null; } }
    }
    public partial class Restriction
    {
        internal Restriction() { }
        public Azure.ResourceManager.MachineLearningServices.ReasonCode? ReasonCode { get { throw null; } }
        public string Type { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Values { get { throw null; } }
    }
    public partial class Route
    {
        public Route(string path, int port) { }
        public string Path { get { throw null; } set { } }
        public int Port { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SamplingAlgorithm : System.IEquatable<Azure.ResourceManager.MachineLearningServices.SamplingAlgorithm>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SamplingAlgorithm(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.SamplingAlgorithm Bayesian { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.SamplingAlgorithm Grid { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.SamplingAlgorithm Random { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.SamplingAlgorithm other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.SamplingAlgorithm left, Azure.ResourceManager.MachineLearningServices.SamplingAlgorithm right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.SamplingAlgorithm (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.SamplingAlgorithm left, Azure.ResourceManager.MachineLearningServices.SamplingAlgorithm right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SasDatastoreCredentials : Azure.ResourceManager.MachineLearningServices.DatastoreCredentials
    {
        public SasDatastoreCredentials() { }
        public Azure.ResourceManager.MachineLearningServices.SasDatastoreSecrets Secrets { get { throw null; } set { } }
    }
    public partial class SasDatastoreSecrets : Azure.ResourceManager.MachineLearningServices.DatastoreSecrets
    {
        public SasDatastoreSecrets() { }
        public string SasToken { get { throw null; } set { } }
    }
    public partial class ScaleSettings
    {
        public ScaleSettings(int maxNodeCount) { }
        public int MaxNodeCount { get { throw null; } set { } }
        public int? MinNodeCount { get { throw null; } set { } }
        public System.TimeSpan? NodeIdleTimeBeforeScaleDown { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScaleType : System.IEquatable<Azure.ResourceManager.MachineLearningServices.ScaleType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScaleType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.ScaleType Auto { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.ScaleType Manual { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.ScaleType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.ScaleType left, Azure.ResourceManager.MachineLearningServices.ScaleType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.ScaleType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.ScaleType left, Azure.ResourceManager.MachineLearningServices.ScaleType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScheduleStatus : System.IEquatable<Azure.ResourceManager.MachineLearningServices.ScheduleStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScheduleStatus(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.ScheduleStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.ScheduleStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.ScheduleStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.ScheduleStatus left, Azure.ResourceManager.MachineLearningServices.ScheduleStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.ScheduleStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.ScheduleStatus left, Azure.ResourceManager.MachineLearningServices.ScheduleStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ScriptReference
    {
        public ScriptReference() { }
        public string ScriptArguments { get { throw null; } set { } }
        public string ScriptData { get { throw null; } set { } }
        public string ScriptSource { get { throw null; } set { } }
        public string Timeout { get { throw null; } set { } }
    }
    public partial class ScriptsToExecute
    {
        public ScriptsToExecute() { }
        public Azure.ResourceManager.MachineLearningServices.ScriptReference CreationScript { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.ScriptReference StartupScript { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecretsType : System.IEquatable<Azure.ResourceManager.MachineLearningServices.SecretsType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecretsType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.SecretsType AccountKey { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.SecretsType Certificate { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.SecretsType None { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.SecretsType Sas { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.SecretsType ServicePrincipal { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.SecretsType SqlAdmin { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.SecretsType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.SecretsType left, Azure.ResourceManager.MachineLearningServices.SecretsType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.SecretsType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.SecretsType left, Azure.ResourceManager.MachineLearningServices.SecretsType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ServiceManagedResourcesSettings
    {
        public ServiceManagedResourcesSettings() { }
        public Azure.ResourceManager.MachineLearningServices.CosmosDbSettings CosmosDb { get { throw null; } set { } }
    }
    public partial class ServicePrincipalDatastoreCredentials : Azure.ResourceManager.MachineLearningServices.DatastoreCredentials
    {
        public ServicePrincipalDatastoreCredentials(System.Guid clientId, System.Guid tenantId) { }
        public string AuthorityUrl { get { throw null; } set { } }
        public System.Guid ClientId { get { throw null; } set { } }
        public string ResourceUri { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.ServicePrincipalDatastoreSecrets Secrets { get { throw null; } set { } }
        public System.Guid TenantId { get { throw null; } set { } }
    }
    public partial class ServicePrincipalDatastoreSecrets : Azure.ResourceManager.MachineLearningServices.DatastoreSecrets
    {
        public ServicePrincipalDatastoreSecrets() { }
        public string ClientSecret { get { throw null; } set { } }
    }
    public partial class SetupScripts
    {
        public SetupScripts() { }
        public Azure.ResourceManager.MachineLearningServices.ScriptsToExecute Scripts { get { throw null; } set { } }
    }
    public partial class SharedPrivateLinkResource
    {
        public SharedPrivateLinkResource() { }
        public string GroupId { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string PrivateLinkResourceId { get { throw null; } set { } }
        public string RequestMessage { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.PrivateEndpointServiceConnectionStatus? Status { get { throw null; } set { } }
    }
    public partial class Sku
    {
        public Sku() { }
        public string Name { get { throw null; } set { } }
        public string Tier { get { throw null; } set { } }
    }
    public partial class SKUCapability
    {
        internal SKUCapability() { }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class SqlAdminDatastoreCredentials : Azure.ResourceManager.MachineLearningServices.DatastoreCredentials
    {
        public SqlAdminDatastoreCredentials(string userId) { }
        public Azure.ResourceManager.MachineLearningServices.SqlAdminDatastoreSecrets Secrets { get { throw null; } set { } }
        public string UserId { get { throw null; } set { } }
    }
    public partial class SqlAdminDatastoreSecrets : Azure.ResourceManager.MachineLearningServices.DatastoreSecrets
    {
        public SqlAdminDatastoreSecrets() { }
        public string Password { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SshPublicAccess : System.IEquatable<Azure.ResourceManager.MachineLearningServices.SshPublicAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SshPublicAccess(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.SshPublicAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.SshPublicAccess Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.SshPublicAccess other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.SshPublicAccess left, Azure.ResourceManager.MachineLearningServices.SshPublicAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.SshPublicAccess (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.SshPublicAccess left, Azure.ResourceManager.MachineLearningServices.SshPublicAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SslConfiguration
    {
        public SslConfiguration() { }
        public string Cert { get { throw null; } set { } }
        public string Cname { get { throw null; } set { } }
        public string Key { get { throw null; } set { } }
        public string LeafDomainLabel { get { throw null; } set { } }
        public bool? OverwriteExistingDomain { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.SslConfigurationStatus? Status { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SslConfigurationStatus : System.IEquatable<Azure.ResourceManager.MachineLearningServices.SslConfigurationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SslConfigurationStatus(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.SslConfigurationStatus Auto { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.SslConfigurationStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.SslConfigurationStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.SslConfigurationStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.SslConfigurationStatus left, Azure.ResourceManager.MachineLearningServices.SslConfigurationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.SslConfigurationStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.SslConfigurationStatus left, Azure.ResourceManager.MachineLearningServices.SslConfigurationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Status : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Status>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Status(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Status Failure { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Status InvalidQuotaBelowClusterMinimum { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Status InvalidQuotaExceedsSubscriptionLimit { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Status InvalidVMFamilyName { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Status OperationNotEnabledForRegion { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Status OperationNotSupportedForSku { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Status Success { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Status Undefined { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Status other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Status left, Azure.ResourceManager.MachineLearningServices.Status right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Status (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Status left, Azure.ResourceManager.MachineLearningServices.Status right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StatusMessage
    {
        internal StatusMessage() { }
        public string Code { get { throw null; } }
        public System.DateTimeOffset? CreatedTimeUtc { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.StatusMessageLevel? Level { get { throw null; } }
        public string Message { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StatusMessageLevel : System.IEquatable<Azure.ResourceManager.MachineLearningServices.StatusMessageLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StatusMessageLevel(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.StatusMessageLevel Error { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.StatusMessageLevel Information { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.StatusMessageLevel Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.StatusMessageLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.StatusMessageLevel left, Azure.ResourceManager.MachineLearningServices.StatusMessageLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.StatusMessageLevel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.StatusMessageLevel left, Azure.ResourceManager.MachineLearningServices.StatusMessageLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public static partial class SubscriptionExtensions
    {
        public static Azure.Pageable<Azure.ResourceManager.MachineLearningServices.ResourceQuota> ListQuotas(this Azure.ResourceManager.Core.SubscriptionOperations subscription, string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.ResourceQuota> ListQuotasAsync(this Azure.ResourceManager.Core.SubscriptionOperations subscription, string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Core.GenericResourceExpanded> ListWorkspaceByName(this Azure.ResourceManager.Core.SubscriptionOperations subscription, string filter, string expand, int? top, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Core.GenericResourceExpanded> ListWorkspaceByNameAsync(this Azure.ResourceManager.Core.SubscriptionOperations subscription, string filter, string expand, int? top, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.MachineLearningServices.Workspace> ListWorkspaces(this Azure.ResourceManager.Core.SubscriptionOperations subscription, string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.Workspace> ListWorkspacesAsync(this Azure.ResourceManager.Core.SubscriptionOperations subscription, string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.MachineLearningServices.WorkspaceSku> ListWorkspaceSkus(this Azure.ResourceManager.Core.SubscriptionOperations subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.WorkspaceSku> ListWorkspaceSkusAsync(this Azure.ResourceManager.Core.SubscriptionOperations subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearningServices.UpdateWorkspaceQuotas>> UpdateQuotas(this Azure.ResourceManager.Core.SubscriptionOperations subscription, string location, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearningServices.QuotaBaseProperties> value = null, string quotaUpdateParametersLocation = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearningServices.UpdateWorkspaceQuotas>>> UpdateQuotasAsync(this Azure.ResourceManager.Core.SubscriptionOperations subscription, string location, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearningServices.QuotaBaseProperties> value = null, string quotaUpdateParametersLocation = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SweepJob : Azure.ResourceManager.MachineLearningServices.JobBase
    {
        public SweepJob(Azure.ResourceManager.MachineLearningServices.SamplingAlgorithm algorithm, Azure.ResourceManager.MachineLearningServices.ComputeConfiguration compute, Azure.ResourceManager.MachineLearningServices.Objective objective, System.Collections.Generic.IDictionary<string, object> searchSpace) { }
        public Azure.ResourceManager.MachineLearningServices.SamplingAlgorithm Algorithm { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.ComputeConfiguration Compute { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.EarlyTerminationPolicy EarlyTermination { get { throw null; } set { } }
        public string ExperimentName { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.IdentityConfiguration Identity { get { throw null; } set { } }
        public int? MaxConcurrentTrials { get { throw null; } set { } }
        public int? MaxTotalTrials { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Objective Objective { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.JobOutput Output { get { throw null; } }
        public int? Priority { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, object> SearchSpace { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.JobStatus? Status { get { throw null; } }
        public System.TimeSpan? Timeout { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.TrialComponent Trial { get { throw null; } set { } }
    }
    public partial class SynapseSpark : Azure.ResourceManager.MachineLearningServices.Compute
    {
        public SynapseSpark() { }
        public Azure.ResourceManager.MachineLearningServices.SynapseSparkPoolPropertiesAutoGenerated Properties { get { throw null; } set { } }
    }
    public partial class SynapseSparkPoolProperties
    {
        public SynapseSparkPoolProperties() { }
        public Azure.ResourceManager.MachineLearningServices.SynapseSparkPoolPropertiesAutoGenerated Properties { get { throw null; } set { } }
    }
    public partial class SynapseSparkPoolPropertiesAutoGenerated
    {
        public SynapseSparkPoolPropertiesAutoGenerated() { }
        public Azure.ResourceManager.MachineLearningServices.AutoPauseProperties AutoPauseProperties { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.AutoScaleProperties AutoScaleProperties { get { throw null; } set { } }
        public int? NodeCount { get { throw null; } set { } }
        public string NodeSize { get { throw null; } set { } }
        public string NodeSizeFamily { get { throw null; } set { } }
        public string PoolName { get { throw null; } set { } }
        public string ResourceGroup { get { throw null; } set { } }
        public string SparkVersion { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
        public string WorkspaceName { get { throw null; } set { } }
    }
    public partial class SystemData
    {
        internal SystemData() { }
        public System.DateTimeOffset? CreatedAt { get { throw null; } }
        public string CreatedBy { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.CreatedByType? CreatedByType { get { throw null; } }
        public System.DateTimeOffset? LastModifiedAt { get { throw null; } }
        public string LastModifiedBy { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.CreatedByType? LastModifiedByType { get { throw null; } }
    }
    public partial class SystemService
    {
        internal SystemService() { }
        public string PublicIpAddress { get { throw null; } }
        public string SystemServiceType { get { throw null; } }
        public string Version { get { throw null; } }
    }
    public partial class TensorFlow : Azure.ResourceManager.MachineLearningServices.DistributionConfiguration
    {
        public TensorFlow() { }
        public int? ParameterServerCount { get { throw null; } set { } }
        public int? WorkerCount { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TextAnnotationType : System.IEquatable<Azure.ResourceManager.MachineLearningServices.TextAnnotationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TextAnnotationType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.TextAnnotationType Classification { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.TextAnnotationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.TextAnnotationType left, Azure.ResourceManager.MachineLearningServices.TextAnnotationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.TextAnnotationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.TextAnnotationType left, Azure.ResourceManager.MachineLearningServices.TextAnnotationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TrackedResource : Azure.ResourceManager.Core.Resource<Azure.ResourceManager.Core.ResourceGroupResourceIdentifier>
    {
        public TrackedResource(string location) { }
        public string Location { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class TrialComponent
    {
        public TrialComponent(string command) { }
        public string CodeId { get { throw null; } set { } }
        public string Command { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.DistributionConfiguration Distribution { get { throw null; } set { } }
        public string EnvironmentId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> EnvironmentVariables { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.MachineLearningServices.InputDataBinding> InputDataBindings { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.MachineLearningServices.OutputDataBinding> OutputDataBindings { get { throw null; } }
        public System.TimeSpan? Timeout { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TriggerType : System.IEquatable<Azure.ResourceManager.MachineLearningServices.TriggerType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TriggerType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.TriggerType Cron { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.TriggerType Recurrence { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.TriggerType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.TriggerType left, Azure.ResourceManager.MachineLearningServices.TriggerType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.TriggerType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.TriggerType left, Azure.ResourceManager.MachineLearningServices.TriggerType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TruncationSelectionPolicy : Azure.ResourceManager.MachineLearningServices.EarlyTerminationPolicy
    {
        public TruncationSelectionPolicy() { }
        public int? TruncationPercentage { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UnderlyingResourceAction : System.IEquatable<Azure.ResourceManager.MachineLearningServices.UnderlyingResourceAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UnderlyingResourceAction(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.UnderlyingResourceAction Delete { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.UnderlyingResourceAction Detach { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.UnderlyingResourceAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.UnderlyingResourceAction left, Azure.ResourceManager.MachineLearningServices.UnderlyingResourceAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.UnderlyingResourceAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.UnderlyingResourceAction left, Azure.ResourceManager.MachineLearningServices.UnderlyingResourceAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UnitOfMeasure : System.IEquatable<Azure.ResourceManager.MachineLearningServices.UnitOfMeasure>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UnitOfMeasure(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.UnitOfMeasure OneHour { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.UnitOfMeasure other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.UnitOfMeasure left, Azure.ResourceManager.MachineLearningServices.UnitOfMeasure right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.UnitOfMeasure (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.UnitOfMeasure left, Azure.ResourceManager.MachineLearningServices.UnitOfMeasure right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UpdateWorkspaceQuotas : Azure.ResourceManager.Core.SubResource<Azure.ResourceManager.Core.ResourceIdentifier>
    {
        internal UpdateWorkspaceQuotas() { }
        public long? Limit { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Status? Status { get { throw null; } }
        public string Type { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.QuotaUnit? Unit { get { throw null; } }
    }
    public partial class UpdateWorkspaceQuotasResult
    {
        internal UpdateWorkspaceQuotasResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearningServices.UpdateWorkspaceQuotas> Value { get { throw null; } }
    }
    public partial class Usage : Azure.ResourceManager.Core.SubResource<Azure.ResourceManager.Core.ResourceIdentifier>
    {
        internal Usage() { }
        public string AmlWorkspaceLocation { get { throw null; } }
        public long? CurrentValue { get { throw null; } }
        public long? Limit { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.UsageName Name { get { throw null; } }
        public string Type { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.UsageUnit? Unit { get { throw null; } }
    }
    public partial class UsageName
    {
        internal UsageName() { }
        public string LocalizedValue { get { throw null; } }
        public string Value { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UsageUnit : System.IEquatable<Azure.ResourceManager.MachineLearningServices.UsageUnit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UsageUnit(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.UsageUnit Count { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.UsageUnit other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.UsageUnit left, Azure.ResourceManager.MachineLearningServices.UsageUnit right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.UsageUnit (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.UsageUnit left, Azure.ResourceManager.MachineLearningServices.UsageUnit right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UserAccountCredentials
    {
        public UserAccountCredentials(string adminUserName) { }
        public string AdminUserName { get { throw null; } set { } }
        public string AdminUserPassword { get { throw null; } set { } }
        public string AdminUserSshPublicKey { get { throw null; } set { } }
    }
    public partial class UserAssignedIdentity
    {
        public UserAssignedIdentity() { }
        public string ClientId { get { throw null; } }
        public string PrincipalId { get { throw null; } }
        public string TenantId { get { throw null; } }
    }
    public partial class UserAssignedIdentityMeta
    {
        public UserAssignedIdentityMeta() { }
        public string ClientId { get { throw null; } set { } }
        public string PrincipalId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ValueFormat : System.IEquatable<Azure.ResourceManager.MachineLearningServices.ValueFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ValueFormat(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.ValueFormat Json { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.ValueFormat other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.ValueFormat left, Azure.ResourceManager.MachineLearningServices.ValueFormat right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.ValueFormat (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.ValueFormat left, Azure.ResourceManager.MachineLearningServices.ValueFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VirtualMachine : Azure.ResourceManager.MachineLearningServices.Compute
    {
        public VirtualMachine() { }
        public Azure.ResourceManager.MachineLearningServices.VirtualMachineProperties Properties { get { throw null; } set { } }
    }
    public partial class VirtualMachineImage
    {
        public VirtualMachineImage(string id) { }
        public string Id { get { throw null; } set { } }
    }
    public partial class VirtualMachineProperties
    {
        public VirtualMachineProperties() { }
        public string Address { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.VirtualMachineSshCredentials AdministratorAccount { get { throw null; } set { } }
        public bool? IsNotebookInstanceCompute { get { throw null; } set { } }
        public int? SshPort { get { throw null; } set { } }
        public string VirtualMachineSize { get { throw null; } set { } }
    }
    public partial class VirtualMachineSecrets : Azure.ResourceManager.MachineLearningServices.ComputeSecrets
    {
        internal VirtualMachineSecrets() { }
        public Azure.ResourceManager.MachineLearningServices.VirtualMachineSshCredentials AdministratorAccount { get { throw null; } }
    }
    public partial class VirtualMachineSize
    {
        internal VirtualMachineSize() { }
        public Azure.ResourceManager.MachineLearningServices.EstimatedVMPrices EstimatedVMPrices { get { throw null; } }
        public string Family { get { throw null; } }
        public int? Gpus { get { throw null; } }
        public bool? LowPriorityCapable { get { throw null; } }
        public int? MaxResourceVolumeMB { get { throw null; } }
        public double? MemoryGB { get { throw null; } }
        public string Name { get { throw null; } }
        public int? OsVhdSizeMB { get { throw null; } }
        public bool? PremiumIO { get { throw null; } }
        public int? VCPUs { get { throw null; } }
    }
    public partial class VirtualMachineSizeListResult
    {
        internal VirtualMachineSizeListResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearningServices.VirtualMachineSize> Value { get { throw null; } }
    }
    public partial class VirtualMachineSshCredentials
    {
        public VirtualMachineSshCredentials() { }
        public string Password { get { throw null; } set { } }
        public string PrivateKeyData { get { throw null; } set { } }
        public string PublicKeyData { get { throw null; } set { } }
        public string Username { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VMPriceOSType : System.IEquatable<Azure.ResourceManager.MachineLearningServices.VMPriceOSType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VMPriceOSType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.VMPriceOSType Linux { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.VMPriceOSType Windows { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.VMPriceOSType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.VMPriceOSType left, Azure.ResourceManager.MachineLearningServices.VMPriceOSType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.VMPriceOSType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.VMPriceOSType left, Azure.ResourceManager.MachineLearningServices.VMPriceOSType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VmPriority : System.IEquatable<Azure.ResourceManager.MachineLearningServices.VmPriority>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VmPriority(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.VmPriority Dedicated { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.VmPriority LowPriority { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.VmPriority other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.VmPriority left, Azure.ResourceManager.MachineLearningServices.VmPriority right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.VmPriority (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.VmPriority left, Azure.ResourceManager.MachineLearningServices.VmPriority right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VMTier : System.IEquatable<Azure.ResourceManager.MachineLearningServices.VMTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VMTier(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.VMTier LowPriority { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.VMTier Spot { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.VMTier Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.VMTier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.VMTier left, Azure.ResourceManager.MachineLearningServices.VMTier right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.VMTier (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.VMTier left, Azure.ResourceManager.MachineLearningServices.VMTier right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Workspace : Azure.ResourceManager.MachineLearningServices.WorkspaceOperations
    {
        internal Workspace() { }
        public Azure.ResourceManager.MachineLearningServices.WorkspaceData Data { get { throw null; } }
        protected override Azure.ResourceManager.MachineLearningServices.Workspace GetResource(System.Threading.CancellationToken cancellation = default(System.Threading.CancellationToken)) { throw null; }
        protected override System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.Workspace> GetResourceAsync(System.Threading.CancellationToken cancellation = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WorkspaceConnection : Azure.ResourceManager.MachineLearningServices.WorkspaceConnectionOperations
    {
        internal WorkspaceConnection() { }
        public Azure.ResourceManager.MachineLearningServices.WorkspaceConnectionData Data { get { throw null; } }
        protected override Azure.ResourceManager.MachineLearningServices.WorkspaceConnection GetResource(System.Threading.CancellationToken cancellation = default(System.Threading.CancellationToken)) { throw null; }
        protected override System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.WorkspaceConnection> GetResourceAsync(System.Threading.CancellationToken cancellation = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WorkspaceConnectionContainer : Azure.ResourceManager.Core.ResourceContainerBase<Azure.ResourceManager.Core.ResourceGroupResourceIdentifier, Azure.ResourceManager.MachineLearningServices.WorkspaceConnection, Azure.ResourceManager.MachineLearningServices.WorkspaceConnectionData>
    {
        protected WorkspaceConnectionContainer() { }
        public new Azure.ResourceManager.Core.ResourceGroupResourceIdentifier Id { get { throw null; } }
        protected override Azure.ResourceManager.Core.ResourceType ValidResourceType { get { throw null; } }
        public Azure.Response<Azure.ResourceManager.MachineLearningServices.WorkspaceConnection> CreateOrUpdate(string connectionName, Azure.ResourceManager.MachineLearningServices.WorkspaceConnectionData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.WorkspaceConnection>> CreateOrUpdateAsync(string connectionName, Azure.ResourceManager.MachineLearningServices.WorkspaceConnectionData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Response<Azure.ResourceManager.MachineLearningServices.WorkspaceConnection> Get(string connectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.WorkspaceConnection>> GetAsync(string connectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Pageable<Azure.ResourceManager.MachineLearningServices.WorkspaceConnection> List(string target = null, string category = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Pageable<Azure.ResourceManager.Core.GenericResourceExpanded> ListAsGenericResource(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.AsyncPageable<Azure.ResourceManager.Core.GenericResourceExpanded> ListAsGenericResourceAsync(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.WorkspaceConnection> ListAsync(string target = null, string category = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.ResourceManager.MachineLearningServices.WorkspaceConnectionsCreateOperation StartCreateOrUpdate(string connectionName, Azure.ResourceManager.MachineLearningServices.WorkspaceConnectionData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.WorkspaceConnectionsCreateOperation> StartCreateOrUpdateAsync(string connectionName, Azure.ResourceManager.MachineLearningServices.WorkspaceConnectionData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WorkspaceConnectionData : Azure.ResourceManager.Core.Resource<Azure.ResourceManager.Core.ResourceGroupResourceIdentifier>
    {
        public WorkspaceConnectionData() { }
        public string AuthType { get { throw null; } set { } }
        public string Category { get { throw null; } set { } }
        public string Target { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.ValueFormat? ValueFormat { get { throw null; } set { } }
    }
    public partial class WorkspaceConnectionOperations : Azure.ResourceManager.Core.ResourceOperationsBase<Azure.ResourceManager.Core.ResourceGroupResourceIdentifier, Azure.ResourceManager.MachineLearningServices.WorkspaceConnection>
    {
        public static readonly Azure.ResourceManager.Core.ResourceType ResourceType;
        protected WorkspaceConnectionOperations() { }
        protected internal WorkspaceConnectionOperations(Azure.ResourceManager.Core.ResourceOperationsBase options, Azure.ResourceManager.Core.ResourceGroupResourceIdentifier id) { }
        protected override Azure.ResourceManager.Core.ResourceType ValidResourceType { get { throw null; } }
        public Azure.Response Delete(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Response> DeleteAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response<Azure.ResourceManager.MachineLearningServices.WorkspaceConnection> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.WorkspaceConnection>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Collections.Generic.IEnumerable<Azure.ResourceManager.Core.LocationData> ListAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Core.LocationData>> ListAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Operation StartDelete(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Operation> StartDeleteAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WorkspaceConnectionsCreateOperation : Azure.Operation<Azure.ResourceManager.MachineLearningServices.WorkspaceConnection>
    {
        protected WorkspaceConnectionsCreateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.MachineLearningServices.WorkspaceConnection Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.WorkspaceConnection>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.WorkspaceConnection>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WorkspaceConnectionsDeleteOperation : Azure.Operation
    {
        protected WorkspaceConnectionsDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WorkspaceContainer : Azure.ResourceManager.Core.ResourceContainerBase<Azure.ResourceManager.Core.ResourceGroupResourceIdentifier, Azure.ResourceManager.MachineLearningServices.Workspace, Azure.ResourceManager.MachineLearningServices.WorkspaceData>
    {
        protected WorkspaceContainer() { }
        public new Azure.ResourceManager.Core.ResourceGroupResourceIdentifier Id { get { throw null; } }
        protected override Azure.ResourceManager.Core.ResourceType ValidResourceType { get { throw null; } }
        public Azure.Response<Azure.ResourceManager.MachineLearningServices.Workspace> CreateOrUpdate(string workspaceName, Azure.ResourceManager.MachineLearningServices.WorkspaceData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.Workspace>> CreateOrUpdateAsync(string workspaceName, Azure.ResourceManager.MachineLearningServices.WorkspaceData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Response<Azure.ResourceManager.MachineLearningServices.Workspace> Get(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.Workspace>> GetAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Pageable<Azure.ResourceManager.MachineLearningServices.Workspace> List(string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Pageable<Azure.ResourceManager.Core.GenericResourceExpanded> ListAsGenericResource(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.AsyncPageable<Azure.ResourceManager.Core.GenericResourceExpanded> ListAsGenericResourceAsync(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.Workspace> ListAsync(string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.ListWorkspaceKeysResult> ListKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.ListWorkspaceKeysResult>> ListKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.NotebookAccessTokenResult> ListNotebookAccessToken(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.NotebookAccessTokenResult>> ListNotebookAccessTokenAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.ListNotebookKeysResult> ListNotebookKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.ListNotebookKeysResult>> ListNotebookKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.ListStorageAccountKeysResult> ListStorageAccountKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.ListStorageAccountKeysResult>> ListStorageAccountKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.ResourceManager.MachineLearningServices.WorkspacesCreateOrUpdateOperation StartCreateOrUpdate(string workspaceName, Azure.ResourceManager.MachineLearningServices.WorkspaceData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.WorkspacesCreateOrUpdateOperation> StartCreateOrUpdateAsync(string workspaceName, Azure.ResourceManager.MachineLearningServices.WorkspaceData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WorkspaceData : Azure.ResourceManager.Core.Resource<Azure.ResourceManager.Core.ResourceGroupResourceIdentifier>
    {
        public WorkspaceData() { }
        public bool? AllowPublicAccessWhenBehindVnet { get { throw null; } set { } }
        public string ApplicationInsights { get { throw null; } set { } }
        public string ContainerRegistry { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DiscoveryUrl { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.EncryptionProperty Encryption { get { throw null; } set { } }
        public string FriendlyName { get { throw null; } set { } }
        public bool? HbiWorkspace { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Identity Identity { get { throw null; } set { } }
        public string ImageBuildCompute { get { throw null; } set { } }
        public string KeyVault { get { throw null; } set { } }
        public string Location { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.NotebookResourceInfo NotebookInfo { get { throw null; } }
        public string PrimaryUserAssignedIdentity { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearningServices.PrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public int? PrivateLinkCount { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.ServiceManagedResourcesSettings ServiceManagedResourcesSettings { get { throw null; } set { } }
        public string ServiceProvisionedResourceGroup { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.MachineLearningServices.SharedPrivateLinkResource> SharedPrivateLinkResources { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Sku Sku { get { throw null; } set { } }
        public string StorageAccount { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.SystemData SystemData { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public string TenantId { get { throw null; } }
        public string WorkspaceId { get { throw null; } }
    }
    public partial class WorkspaceOperations : Azure.ResourceManager.Core.ResourceOperationsBase<Azure.ResourceManager.Core.ResourceGroupResourceIdentifier, Azure.ResourceManager.MachineLearningServices.Workspace>
    {
        public static readonly Azure.ResourceManager.Core.ResourceType ResourceType;
        protected WorkspaceOperations() { }
        protected internal WorkspaceOperations(Azure.ResourceManager.Core.ResourceOperationsBase options, Azure.ResourceManager.Core.ResourceGroupResourceIdentifier id) { }
        protected override Azure.ResourceManager.Core.ResourceType ValidResourceType { get { throw null; } }
        public Azure.Response Delete(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Response> DeleteAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response<Azure.ResourceManager.MachineLearningServices.Workspace> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.Workspace>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.ResourceManager.MachineLearningServices.BatchEndpointTrackedResourceContainer GetBatchEndpointTrackedResources() { throw null; }
        public Azure.ResourceManager.MachineLearningServices.CodeContainerResourceContainer GetCodeContainerResources() { throw null; }
        public Azure.ResourceManager.MachineLearningServices.ComputeResourceContainer GetComputeResources() { throw null; }
        public Azure.ResourceManager.MachineLearningServices.DataContainerResourceContainer GetDataContainerResources() { throw null; }
        public Azure.ResourceManager.MachineLearningServices.DatastorePropertiesResourceContainer GetDatastorePropertiesResources() { throw null; }
        public Azure.ResourceManager.MachineLearningServices.EnvironmentContainerResourceContainer GetEnvironmentContainerResources() { throw null; }
        public Azure.ResourceManager.MachineLearningServices.JobBaseResourceContainer GetJobBaseResources() { throw null; }
        public Azure.ResourceManager.MachineLearningServices.LabelingJobResourceContainer GetLabelingJobResources() { throw null; }
        public Azure.ResourceManager.MachineLearningServices.ModelContainerResourceContainer GetModelContainerResources() { throw null; }
        public Azure.ResourceManager.MachineLearningServices.OnlineEndpointTrackedResourceContainer GetOnlineEndpointTrackedResources() { throw null; }
        public Azure.ResourceManager.MachineLearningServices.PrivateEndpointConnectionContainer GetPrivateEndpointConnections() { throw null; }
        public Azure.ResourceManager.MachineLearningServices.WorkspaceConnectionContainer GetWorkspaceConnections() { throw null; }
        public System.Collections.Generic.IEnumerable<Azure.ResourceManager.Core.LocationData> ListAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Core.LocationData>> ListAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearningServices.PrivateLinkResource>> ListPrivateLinkResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearningServices.PrivateLinkResource>>> ListPrivateLinkResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Pageable<Azure.ResourceManager.MachineLearningServices.AmlUserFeature> ListWorkspaceFeatures(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.AmlUserFeature> ListWorkspaceFeaturesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Response<Azure.ResourceManager.MachineLearningServices.NotebookResourceInfo> PrepareNotebook(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.NotebookResourceInfo>> PrepareNotebookAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Response ResyncKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Response> ResyncKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Operation StartDelete(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Operation> StartDeleteAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.ResourceManager.MachineLearningServices.WorkspacesPrepareNotebookOperation StartPrepareNotebook(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.WorkspacesPrepareNotebookOperation> StartPrepareNotebookAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Operation StartResyncKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Operation> StartResyncKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.WorkspaceData> Update(Azure.ResourceManager.MachineLearningServices.WorkspaceUpdateParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.WorkspaceData>> UpdateAsync(Azure.ResourceManager.MachineLearningServices.WorkspaceUpdateParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WorkspacesCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.MachineLearningServices.Workspace>
    {
        protected WorkspacesCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.MachineLearningServices.Workspace Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.Workspace>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.Workspace>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WorkspacesDeleteOperation : Azure.Operation
    {
        protected WorkspacesDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WorkspaceSku
    {
        internal WorkspaceSku() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearningServices.SKUCapability> Capabilities { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearningServices.ResourceSkuLocationInfo> LocationInfo { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Locations { get { throw null; } }
        public string Name { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearningServices.Restriction> Restrictions { get { throw null; } }
        public string Tier { get { throw null; } }
    }
    public partial class WorkspacesPrepareNotebookOperation : Azure.Operation<Azure.ResourceManager.MachineLearningServices.NotebookResourceInfo>
    {
        protected WorkspacesPrepareNotebookOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.MachineLearningServices.NotebookResourceInfo Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.NotebookResourceInfo>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.NotebookResourceInfo>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WorkspacesResyncKeysOperation : Azure.Operation
    {
        protected WorkspacesResyncKeysOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WorkspacesUpdateOperation : Azure.Operation<Azure.ResourceManager.MachineLearningServices.Workspace>
    {
        protected WorkspacesUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.MachineLearningServices.Workspace Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.Workspace>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.Workspace>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WorkspaceUpdateParameters
    {
        public WorkspaceUpdateParameters() { }
        public string Description { get { throw null; } set { } }
        public string FriendlyName { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Identity Identity { get { throw null; } set { } }
        public string ImageBuildCompute { get { throw null; } set { } }
        public string PrimaryUserAssignedIdentity { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.ServiceManagedResourcesSettings ServiceManagedResourcesSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Sku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
}
