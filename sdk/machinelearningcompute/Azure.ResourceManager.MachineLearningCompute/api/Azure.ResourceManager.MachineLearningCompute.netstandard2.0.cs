namespace Azure.ResourceManager.MachineLearningCompute
{
    public partial class AzureResourceManagerMachineLearningComputeContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerMachineLearningComputeContext() { }
        public static Azure.ResourceManager.MachineLearningCompute.AzureResourceManagerMachineLearningComputeContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public static partial class MachineLearningComputeExtensions
    {
        public static Azure.Pageable<Azure.ResourceManager.MachineLearningCompute.Models.ResourceOperation> GetAvailableOperationsMachineLearningComputes(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.MachineLearningCompute.Models.ResourceOperation> GetAvailableOperationsMachineLearningComputesAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.MachineLearningCompute.OperationalizationClusterResource> GetOperationalizationCluster(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningCompute.OperationalizationClusterResource>> GetOperationalizationClusterAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.MachineLearningCompute.OperationalizationClusterResource GetOperationalizationClusterResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MachineLearningCompute.OperationalizationClusterCollection GetOperationalizationClusters(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.MachineLearningCompute.OperationalizationClusterResource> GetOperationalizationClusters(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.MachineLearningCompute.OperationalizationClusterResource> GetOperationalizationClustersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OperationalizationClusterCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearningCompute.OperationalizationClusterResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearningCompute.OperationalizationClusterResource>, System.Collections.IEnumerable
    {
        protected OperationalizationClusterCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearningCompute.OperationalizationClusterResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string clusterName, Azure.ResourceManager.MachineLearningCompute.OperationalizationClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearningCompute.OperationalizationClusterResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string clusterName, Azure.ResourceManager.MachineLearningCompute.OperationalizationClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningCompute.OperationalizationClusterResource> Get(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearningCompute.OperationalizationClusterResource> GetAll(string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearningCompute.OperationalizationClusterResource> GetAllAsync(string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningCompute.OperationalizationClusterResource>> GetAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.MachineLearningCompute.OperationalizationClusterResource> GetIfExists(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.MachineLearningCompute.OperationalizationClusterResource>> GetIfExistsAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MachineLearningCompute.OperationalizationClusterResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearningCompute.OperationalizationClusterResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MachineLearningCompute.OperationalizationClusterResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearningCompute.OperationalizationClusterResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class OperationalizationClusterData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MachineLearningCompute.OperationalizationClusterData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MachineLearningCompute.OperationalizationClusterData>
    {
        public OperationalizationClusterData(Azure.Core.AzureLocation location) { }
        public string AppInsightsResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningCompute.Models.ClusterType? ClusterType { get { throw null; } set { } }
        public string ContainerRegistryResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningCompute.Models.AcsClusterProperties ContainerService { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningCompute.Models.GlobalServiceConfiguration GlobalServiceConfiguration { get { throw null; } set { } }
        public System.DateTimeOffset? ModifiedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearningCompute.Models.ErrorResponseWrapper> ProvisioningErrors { get { throw null; } }
        public Azure.ResourceManager.MachineLearningCompute.Models.OperationStatus? ProvisioningState { get { throw null; } }
        public string StorageAccountResourceId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MachineLearningCompute.OperationalizationClusterData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MachineLearningCompute.OperationalizationClusterData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MachineLearningCompute.OperationalizationClusterData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MachineLearningCompute.OperationalizationClusterData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MachineLearningCompute.OperationalizationClusterData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MachineLearningCompute.OperationalizationClusterData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MachineLearningCompute.OperationalizationClusterData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OperationalizationClusterResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MachineLearningCompute.OperationalizationClusterData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MachineLearningCompute.OperationalizationClusterData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected OperationalizationClusterResource() { }
        public virtual Azure.ResourceManager.MachineLearningCompute.OperationalizationClusterData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningCompute.OperationalizationClusterResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningCompute.OperationalizationClusterResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningCompute.Models.CheckSystemServicesUpdatesAvailableResponse> CheckSystemServicesUpdatesAvailable(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningCompute.Models.CheckSystemServicesUpdatesAvailableResponse>> CheckSystemServicesUpdatesAvailableAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, bool? deleteAll = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, bool? deleteAll = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningCompute.OperationalizationClusterResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningCompute.OperationalizationClusterResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningCompute.Models.OperationalizationClusterCredentials> GetKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningCompute.Models.OperationalizationClusterCredentials>> GetKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningCompute.OperationalizationClusterResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningCompute.OperationalizationClusterResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningCompute.OperationalizationClusterResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningCompute.OperationalizationClusterResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.MachineLearningCompute.OperationalizationClusterData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MachineLearningCompute.OperationalizationClusterData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MachineLearningCompute.OperationalizationClusterData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MachineLearningCompute.OperationalizationClusterData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MachineLearningCompute.OperationalizationClusterData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MachineLearningCompute.OperationalizationClusterData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MachineLearningCompute.OperationalizationClusterData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningCompute.OperationalizationClusterResource> Update(Azure.ResourceManager.MachineLearningCompute.Models.OperationalizationClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningCompute.OperationalizationClusterResource>> UpdateAsync(Azure.ResourceManager.MachineLearningCompute.Models.OperationalizationClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearningCompute.Models.UpdateSystemServicesResponse> UpdateSystemServices(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearningCompute.Models.UpdateSystemServicesResponse>> UpdateSystemServicesAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.MachineLearningCompute.Mocking
{
    public partial class MockableMachineLearningComputeArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableMachineLearningComputeArmClient() { }
        public virtual Azure.ResourceManager.MachineLearningCompute.OperationalizationClusterResource GetOperationalizationClusterResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableMachineLearningComputeResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableMachineLearningComputeResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningCompute.OperationalizationClusterResource> GetOperationalizationCluster(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningCompute.OperationalizationClusterResource>> GetOperationalizationClusterAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearningCompute.OperationalizationClusterCollection GetOperationalizationClusters() { throw null; }
    }
    public partial class MockableMachineLearningComputeSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableMachineLearningComputeSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearningCompute.OperationalizationClusterResource> GetOperationalizationClusters(string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearningCompute.OperationalizationClusterResource> GetOperationalizationClustersAsync(string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableMachineLearningComputeTenantResource : Azure.ResourceManager.ArmResource
    {
        protected MockableMachineLearningComputeTenantResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearningCompute.Models.ResourceOperation> GetAvailableOperationsMachineLearningComputes(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearningCompute.Models.ResourceOperation> GetAvailableOperationsMachineLearningComputesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.MachineLearningCompute.Models
{
    public partial class AcsClusterProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MachineLearningCompute.Models.AcsClusterProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MachineLearningCompute.Models.AcsClusterProperties>
    {
        public AcsClusterProperties(Azure.ResourceManager.MachineLearningCompute.Models.OrchestratorType orchestratorType) { }
        public int? AgentCount { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningCompute.Models.AgentVmSizeType? AgentVmSize { get { throw null; } set { } }
        public string ClusterFqdn { get { throw null; } }
        public int? MasterCount { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningCompute.Models.ServicePrincipalProperties OrchestratorServicePrincipal { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningCompute.Models.OrchestratorType OrchestratorType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.MachineLearningCompute.Models.SystemService> SystemServices { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MachineLearningCompute.Models.AcsClusterProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MachineLearningCompute.Models.AcsClusterProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MachineLearningCompute.Models.AcsClusterProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MachineLearningCompute.Models.AcsClusterProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MachineLearningCompute.Models.AcsClusterProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MachineLearningCompute.Models.AcsClusterProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MachineLearningCompute.Models.AcsClusterProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AgentVmSizeType : System.IEquatable<Azure.ResourceManager.MachineLearningCompute.Models.AgentVmSizeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AgentVmSizeType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningCompute.Models.AgentVmSizeType StandardA0 { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningCompute.Models.AgentVmSizeType StandardA1 { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningCompute.Models.AgentVmSizeType StandardA10 { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningCompute.Models.AgentVmSizeType StandardA11 { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningCompute.Models.AgentVmSizeType StandardA2 { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningCompute.Models.AgentVmSizeType StandardA3 { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningCompute.Models.AgentVmSizeType StandardA4 { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningCompute.Models.AgentVmSizeType StandardA5 { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningCompute.Models.AgentVmSizeType StandardA6 { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningCompute.Models.AgentVmSizeType StandardA7 { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningCompute.Models.AgentVmSizeType StandardA8 { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningCompute.Models.AgentVmSizeType StandardA9 { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningCompute.Models.AgentVmSizeType StandardD1 { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningCompute.Models.AgentVmSizeType StandardD11 { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningCompute.Models.AgentVmSizeType StandardD11V2 { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningCompute.Models.AgentVmSizeType StandardD12 { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningCompute.Models.AgentVmSizeType StandardD12V2 { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningCompute.Models.AgentVmSizeType StandardD13 { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningCompute.Models.AgentVmSizeType StandardD13V2 { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningCompute.Models.AgentVmSizeType StandardD14 { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningCompute.Models.AgentVmSizeType StandardD14V2 { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningCompute.Models.AgentVmSizeType StandardD1V2 { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningCompute.Models.AgentVmSizeType StandardD2 { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningCompute.Models.AgentVmSizeType StandardD2V2 { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningCompute.Models.AgentVmSizeType StandardD3 { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningCompute.Models.AgentVmSizeType StandardD3V2 { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningCompute.Models.AgentVmSizeType StandardD4 { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningCompute.Models.AgentVmSizeType StandardD4V2 { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningCompute.Models.AgentVmSizeType StandardD5V2 { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningCompute.Models.AgentVmSizeType StandardDS1 { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningCompute.Models.AgentVmSizeType StandardDS11 { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningCompute.Models.AgentVmSizeType StandardDS12 { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningCompute.Models.AgentVmSizeType StandardDS13 { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningCompute.Models.AgentVmSizeType StandardDS14 { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningCompute.Models.AgentVmSizeType StandardDS2 { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningCompute.Models.AgentVmSizeType StandardDS3 { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningCompute.Models.AgentVmSizeType StandardDS4 { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningCompute.Models.AgentVmSizeType StandardG1 { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningCompute.Models.AgentVmSizeType StandardG2 { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningCompute.Models.AgentVmSizeType StandardG3 { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningCompute.Models.AgentVmSizeType StandardG4 { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningCompute.Models.AgentVmSizeType StandardG5 { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningCompute.Models.AgentVmSizeType StandardGS1 { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningCompute.Models.AgentVmSizeType StandardGS2 { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningCompute.Models.AgentVmSizeType StandardGS3 { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningCompute.Models.AgentVmSizeType StandardGS4 { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningCompute.Models.AgentVmSizeType StandardGS5 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningCompute.Models.AgentVmSizeType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningCompute.Models.AgentVmSizeType left, Azure.ResourceManager.MachineLearningCompute.Models.AgentVmSizeType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningCompute.Models.AgentVmSizeType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningCompute.Models.AgentVmSizeType left, Azure.ResourceManager.MachineLearningCompute.Models.AgentVmSizeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AppInsightsCredentials : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MachineLearningCompute.Models.AppInsightsCredentials>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MachineLearningCompute.Models.AppInsightsCredentials>
    {
        internal AppInsightsCredentials() { }
        public string AppId { get { throw null; } }
        public string InstrumentationKey { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MachineLearningCompute.Models.AppInsightsCredentials System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MachineLearningCompute.Models.AppInsightsCredentials>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MachineLearningCompute.Models.AppInsightsCredentials>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MachineLearningCompute.Models.AppInsightsCredentials System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MachineLearningCompute.Models.AppInsightsCredentials>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MachineLearningCompute.Models.AppInsightsCredentials>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MachineLearningCompute.Models.AppInsightsCredentials>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ArmMachineLearningComputeModelFactory
    {
        public static Azure.ResourceManager.MachineLearningCompute.Models.AcsClusterProperties AcsClusterProperties(string clusterFqdn = null, Azure.ResourceManager.MachineLearningCompute.Models.OrchestratorType orchestratorType = default(Azure.ResourceManager.MachineLearningCompute.Models.OrchestratorType), Azure.ResourceManager.MachineLearningCompute.Models.ServicePrincipalProperties orchestratorServicePrincipal = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearningCompute.Models.SystemService> systemServices = null, int? masterCount = default(int?), int? agentCount = default(int?), Azure.ResourceManager.MachineLearningCompute.Models.AgentVmSizeType? agentVmSize = default(Azure.ResourceManager.MachineLearningCompute.Models.AgentVmSizeType?)) { throw null; }
        public static Azure.ResourceManager.MachineLearningCompute.Models.AppInsightsCredentials AppInsightsCredentials(string appId = null, string instrumentationKey = null) { throw null; }
        public static Azure.ResourceManager.MachineLearningCompute.Models.CheckSystemServicesUpdatesAvailableResponse CheckSystemServicesUpdatesAvailableResponse(Azure.ResourceManager.MachineLearningCompute.Models.UpdatesAvailable? updatesAvailable = default(Azure.ResourceManager.MachineLearningCompute.Models.UpdatesAvailable?)) { throw null; }
        public static Azure.ResourceManager.MachineLearningCompute.Models.ContainerRegistryCredentials ContainerRegistryCredentials(string loginServer = null, string password = null, string password2 = null, string username = null) { throw null; }
        public static Azure.ResourceManager.MachineLearningCompute.Models.ContainerServiceCredentials ContainerServiceCredentials(string acsKubeConfig = null, Azure.ResourceManager.MachineLearningCompute.Models.ServicePrincipalProperties servicePrincipalConfiguration = null, string imagePullSecretName = null) { throw null; }
        public static Azure.ResourceManager.MachineLearningCompute.Models.ErrorDetail ErrorDetail(string code = null, string message = null) { throw null; }
        public static Azure.ResourceManager.MachineLearningCompute.Models.ErrorResponse ErrorResponse(string code = null, string message = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearningCompute.Models.ErrorDetail> details = null) { throw null; }
        public static Azure.ResourceManager.MachineLearningCompute.Models.ErrorResponseWrapper ErrorResponseWrapper(Azure.ResourceManager.MachineLearningCompute.Models.ErrorResponse error = null) { throw null; }
        public static Azure.ResourceManager.MachineLearningCompute.Models.OperationalizationClusterCredentials OperationalizationClusterCredentials(Azure.ResourceManager.MachineLearningCompute.Models.StorageAccountCredentials storageAccount = null, Azure.ResourceManager.MachineLearningCompute.Models.ContainerRegistryCredentials containerRegistry = null, Azure.ResourceManager.MachineLearningCompute.Models.ContainerServiceCredentials containerService = null, Azure.ResourceManager.MachineLearningCompute.Models.AppInsightsCredentials appInsights = null, Azure.ResourceManager.MachineLearningCompute.Models.ServiceAuthConfiguration serviceAuthConfiguration = null, Azure.ResourceManager.MachineLearningCompute.Models.SslConfiguration sslConfiguration = null) { throw null; }
        public static Azure.ResourceManager.MachineLearningCompute.OperationalizationClusterData OperationalizationClusterData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string description = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? modifiedOn = default(System.DateTimeOffset?), Azure.ResourceManager.MachineLearningCompute.Models.OperationStatus? provisioningState = default(Azure.ResourceManager.MachineLearningCompute.Models.OperationStatus?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearningCompute.Models.ErrorResponseWrapper> provisioningErrors = null, Azure.ResourceManager.MachineLearningCompute.Models.ClusterType? clusterType = default(Azure.ResourceManager.MachineLearningCompute.Models.ClusterType?), string storageAccountResourceId = null, string containerRegistryResourceId = null, Azure.ResourceManager.MachineLearningCompute.Models.AcsClusterProperties containerService = null, string appInsightsResourceId = null, Azure.ResourceManager.MachineLearningCompute.Models.GlobalServiceConfiguration globalServiceConfiguration = null) { throw null; }
        public static Azure.ResourceManager.MachineLearningCompute.Models.ResourceOperation ResourceOperation(string name = null, Azure.ResourceManager.MachineLearningCompute.Models.ResourceOperationDisplay display = null, string origin = null) { throw null; }
        public static Azure.ResourceManager.MachineLearningCompute.Models.ResourceOperationDisplay ResourceOperationDisplay(string provider = null, string resource = null, string operation = null, string description = null) { throw null; }
        public static Azure.ResourceManager.MachineLearningCompute.Models.StorageAccountCredentials StorageAccountCredentials(string resourceId = null, string primaryKey = null, string secondaryKey = null) { throw null; }
        public static Azure.ResourceManager.MachineLearningCompute.Models.SystemService SystemService(Azure.ResourceManager.MachineLearningCompute.Models.SystemServiceType systemServiceType = default(Azure.ResourceManager.MachineLearningCompute.Models.SystemServiceType), string publicIPAddress = null, string version = null) { throw null; }
        public static Azure.ResourceManager.MachineLearningCompute.Models.UpdateSystemServicesResponse UpdateSystemServicesResponse(Azure.ResourceManager.MachineLearningCompute.Models.OperationStatus? updateStatus = default(Azure.ResourceManager.MachineLearningCompute.Models.OperationStatus?), System.DateTimeOffset? updateStartedOn = default(System.DateTimeOffset?), System.DateTimeOffset? updateCompletedOn = default(System.DateTimeOffset?)) { throw null; }
    }
    public partial class AutoScaleConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MachineLearningCompute.Models.AutoScaleConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MachineLearningCompute.Models.AutoScaleConfiguration>
    {
        public AutoScaleConfiguration() { }
        public int? MaxReplicas { get { throw null; } set { } }
        public int? MinReplicas { get { throw null; } set { } }
        public int? RefreshPeriodInSeconds { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningCompute.Models.Status? Status { get { throw null; } set { } }
        public float? TargetUtilization { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MachineLearningCompute.Models.AutoScaleConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MachineLearningCompute.Models.AutoScaleConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MachineLearningCompute.Models.AutoScaleConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MachineLearningCompute.Models.AutoScaleConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MachineLearningCompute.Models.AutoScaleConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MachineLearningCompute.Models.AutoScaleConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MachineLearningCompute.Models.AutoScaleConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CheckSystemServicesUpdatesAvailableResponse : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MachineLearningCompute.Models.CheckSystemServicesUpdatesAvailableResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MachineLearningCompute.Models.CheckSystemServicesUpdatesAvailableResponse>
    {
        internal CheckSystemServicesUpdatesAvailableResponse() { }
        public Azure.ResourceManager.MachineLearningCompute.Models.UpdatesAvailable? UpdatesAvailable { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MachineLearningCompute.Models.CheckSystemServicesUpdatesAvailableResponse System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MachineLearningCompute.Models.CheckSystemServicesUpdatesAvailableResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MachineLearningCompute.Models.CheckSystemServicesUpdatesAvailableResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MachineLearningCompute.Models.CheckSystemServicesUpdatesAvailableResponse System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MachineLearningCompute.Models.CheckSystemServicesUpdatesAvailableResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MachineLearningCompute.Models.CheckSystemServicesUpdatesAvailableResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MachineLearningCompute.Models.CheckSystemServicesUpdatesAvailableResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClusterType : System.IEquatable<Azure.ResourceManager.MachineLearningCompute.Models.ClusterType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClusterType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningCompute.Models.ClusterType ACS { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningCompute.Models.ClusterType Local { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningCompute.Models.ClusterType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningCompute.Models.ClusterType left, Azure.ResourceManager.MachineLearningCompute.Models.ClusterType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningCompute.Models.ClusterType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningCompute.Models.ClusterType left, Azure.ResourceManager.MachineLearningCompute.Models.ClusterType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerRegistryCredentials : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MachineLearningCompute.Models.ContainerRegistryCredentials>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MachineLearningCompute.Models.ContainerRegistryCredentials>
    {
        internal ContainerRegistryCredentials() { }
        public string LoginServer { get { throw null; } }
        public string Password { get { throw null; } }
        public string Password2 { get { throw null; } }
        public string Username { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MachineLearningCompute.Models.ContainerRegistryCredentials System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MachineLearningCompute.Models.ContainerRegistryCredentials>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MachineLearningCompute.Models.ContainerRegistryCredentials>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MachineLearningCompute.Models.ContainerRegistryCredentials System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MachineLearningCompute.Models.ContainerRegistryCredentials>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MachineLearningCompute.Models.ContainerRegistryCredentials>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MachineLearningCompute.Models.ContainerRegistryCredentials>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerServiceCredentials : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MachineLearningCompute.Models.ContainerServiceCredentials>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MachineLearningCompute.Models.ContainerServiceCredentials>
    {
        internal ContainerServiceCredentials() { }
        public string AcsKubeConfig { get { throw null; } }
        public string ImagePullSecretName { get { throw null; } }
        public Azure.ResourceManager.MachineLearningCompute.Models.ServicePrincipalProperties ServicePrincipalConfiguration { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MachineLearningCompute.Models.ContainerServiceCredentials System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MachineLearningCompute.Models.ContainerServiceCredentials>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MachineLearningCompute.Models.ContainerServiceCredentials>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MachineLearningCompute.Models.ContainerServiceCredentials System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MachineLearningCompute.Models.ContainerServiceCredentials>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MachineLearningCompute.Models.ContainerServiceCredentials>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MachineLearningCompute.Models.ContainerServiceCredentials>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ErrorDetail : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MachineLearningCompute.Models.ErrorDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MachineLearningCompute.Models.ErrorDetail>
    {
        internal ErrorDetail() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MachineLearningCompute.Models.ErrorDetail System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MachineLearningCompute.Models.ErrorDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MachineLearningCompute.Models.ErrorDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MachineLearningCompute.Models.ErrorDetail System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MachineLearningCompute.Models.ErrorDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MachineLearningCompute.Models.ErrorDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MachineLearningCompute.Models.ErrorDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ErrorResponse : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MachineLearningCompute.Models.ErrorResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MachineLearningCompute.Models.ErrorResponse>
    {
        internal ErrorResponse() { }
        public string Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearningCompute.Models.ErrorDetail> Details { get { throw null; } }
        public string Message { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MachineLearningCompute.Models.ErrorResponse System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MachineLearningCompute.Models.ErrorResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MachineLearningCompute.Models.ErrorResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MachineLearningCompute.Models.ErrorResponse System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MachineLearningCompute.Models.ErrorResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MachineLearningCompute.Models.ErrorResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MachineLearningCompute.Models.ErrorResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ErrorResponseWrapper : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MachineLearningCompute.Models.ErrorResponseWrapper>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MachineLearningCompute.Models.ErrorResponseWrapper>
    {
        internal ErrorResponseWrapper() { }
        public Azure.ResourceManager.MachineLearningCompute.Models.ErrorResponse Error { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MachineLearningCompute.Models.ErrorResponseWrapper System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MachineLearningCompute.Models.ErrorResponseWrapper>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MachineLearningCompute.Models.ErrorResponseWrapper>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MachineLearningCompute.Models.ErrorResponseWrapper System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MachineLearningCompute.Models.ErrorResponseWrapper>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MachineLearningCompute.Models.ErrorResponseWrapper>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MachineLearningCompute.Models.ErrorResponseWrapper>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GlobalServiceConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MachineLearningCompute.Models.GlobalServiceConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MachineLearningCompute.Models.GlobalServiceConfiguration>
    {
        public GlobalServiceConfiguration() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public Azure.ResourceManager.MachineLearningCompute.Models.AutoScaleConfiguration AutoScale { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningCompute.Models.ServiceAuthConfiguration ServiceAuth { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningCompute.Models.SslConfiguration Ssl { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MachineLearningCompute.Models.GlobalServiceConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MachineLearningCompute.Models.GlobalServiceConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MachineLearningCompute.Models.GlobalServiceConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MachineLearningCompute.Models.GlobalServiceConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MachineLearningCompute.Models.GlobalServiceConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MachineLearningCompute.Models.GlobalServiceConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MachineLearningCompute.Models.GlobalServiceConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OperationalizationClusterCredentials : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MachineLearningCompute.Models.OperationalizationClusterCredentials>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MachineLearningCompute.Models.OperationalizationClusterCredentials>
    {
        internal OperationalizationClusterCredentials() { }
        public Azure.ResourceManager.MachineLearningCompute.Models.AppInsightsCredentials AppInsights { get { throw null; } }
        public Azure.ResourceManager.MachineLearningCompute.Models.ContainerRegistryCredentials ContainerRegistry { get { throw null; } }
        public Azure.ResourceManager.MachineLearningCompute.Models.ContainerServiceCredentials ContainerService { get { throw null; } }
        public Azure.ResourceManager.MachineLearningCompute.Models.ServiceAuthConfiguration ServiceAuthConfiguration { get { throw null; } }
        public Azure.ResourceManager.MachineLearningCompute.Models.SslConfiguration SslConfiguration { get { throw null; } }
        public Azure.ResourceManager.MachineLearningCompute.Models.StorageAccountCredentials StorageAccount { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MachineLearningCompute.Models.OperationalizationClusterCredentials System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MachineLearningCompute.Models.OperationalizationClusterCredentials>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MachineLearningCompute.Models.OperationalizationClusterCredentials>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MachineLearningCompute.Models.OperationalizationClusterCredentials System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MachineLearningCompute.Models.OperationalizationClusterCredentials>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MachineLearningCompute.Models.OperationalizationClusterCredentials>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MachineLearningCompute.Models.OperationalizationClusterCredentials>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OperationalizationClusterPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MachineLearningCompute.Models.OperationalizationClusterPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MachineLearningCompute.Models.OperationalizationClusterPatch>
    {
        public OperationalizationClusterPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MachineLearningCompute.Models.OperationalizationClusterPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MachineLearningCompute.Models.OperationalizationClusterPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MachineLearningCompute.Models.OperationalizationClusterPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MachineLearningCompute.Models.OperationalizationClusterPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MachineLearningCompute.Models.OperationalizationClusterPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MachineLearningCompute.Models.OperationalizationClusterPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MachineLearningCompute.Models.OperationalizationClusterPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperationStatus : System.IEquatable<Azure.ResourceManager.MachineLearningCompute.Models.OperationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperationStatus(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningCompute.Models.OperationStatus Canceled { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningCompute.Models.OperationStatus Creating { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningCompute.Models.OperationStatus Deleting { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningCompute.Models.OperationStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningCompute.Models.OperationStatus Succeeded { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningCompute.Models.OperationStatus Unknown { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningCompute.Models.OperationStatus Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningCompute.Models.OperationStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningCompute.Models.OperationStatus left, Azure.ResourceManager.MachineLearningCompute.Models.OperationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningCompute.Models.OperationStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningCompute.Models.OperationStatus left, Azure.ResourceManager.MachineLearningCompute.Models.OperationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OrchestratorType : System.IEquatable<Azure.ResourceManager.MachineLearningCompute.Models.OrchestratorType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OrchestratorType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningCompute.Models.OrchestratorType Kubernetes { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningCompute.Models.OrchestratorType None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningCompute.Models.OrchestratorType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningCompute.Models.OrchestratorType left, Azure.ResourceManager.MachineLearningCompute.Models.OrchestratorType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningCompute.Models.OrchestratorType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningCompute.Models.OrchestratorType left, Azure.ResourceManager.MachineLearningCompute.Models.OrchestratorType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResourceOperation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MachineLearningCompute.Models.ResourceOperation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MachineLearningCompute.Models.ResourceOperation>
    {
        internal ResourceOperation() { }
        public Azure.ResourceManager.MachineLearningCompute.Models.ResourceOperationDisplay Display { get { throw null; } }
        public string Name { get { throw null; } }
        public string Origin { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MachineLearningCompute.Models.ResourceOperation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MachineLearningCompute.Models.ResourceOperation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MachineLearningCompute.Models.ResourceOperation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MachineLearningCompute.Models.ResourceOperation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MachineLearningCompute.Models.ResourceOperation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MachineLearningCompute.Models.ResourceOperation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MachineLearningCompute.Models.ResourceOperation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceOperationDisplay : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MachineLearningCompute.Models.ResourceOperationDisplay>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MachineLearningCompute.Models.ResourceOperationDisplay>
    {
        internal ResourceOperationDisplay() { }
        public string Description { get { throw null; } }
        public string Operation { get { throw null; } }
        public string Provider { get { throw null; } }
        public string Resource { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MachineLearningCompute.Models.ResourceOperationDisplay System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MachineLearningCompute.Models.ResourceOperationDisplay>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MachineLearningCompute.Models.ResourceOperationDisplay>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MachineLearningCompute.Models.ResourceOperationDisplay System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MachineLearningCompute.Models.ResourceOperationDisplay>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MachineLearningCompute.Models.ResourceOperationDisplay>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MachineLearningCompute.Models.ResourceOperationDisplay>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServiceAuthConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MachineLearningCompute.Models.ServiceAuthConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MachineLearningCompute.Models.ServiceAuthConfiguration>
    {
        public ServiceAuthConfiguration(string primaryAuthKeyHash, string secondaryAuthKeyHash) { }
        public string PrimaryAuthKeyHash { get { throw null; } set { } }
        public string SecondaryAuthKeyHash { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MachineLearningCompute.Models.ServiceAuthConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MachineLearningCompute.Models.ServiceAuthConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MachineLearningCompute.Models.ServiceAuthConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MachineLearningCompute.Models.ServiceAuthConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MachineLearningCompute.Models.ServiceAuthConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MachineLearningCompute.Models.ServiceAuthConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MachineLearningCompute.Models.ServiceAuthConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServicePrincipalProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MachineLearningCompute.Models.ServicePrincipalProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MachineLearningCompute.Models.ServicePrincipalProperties>
    {
        public ServicePrincipalProperties(string clientId, string secret) { }
        public string ClientId { get { throw null; } set { } }
        public string Secret { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MachineLearningCompute.Models.ServicePrincipalProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MachineLearningCompute.Models.ServicePrincipalProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MachineLearningCompute.Models.ServicePrincipalProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MachineLearningCompute.Models.ServicePrincipalProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MachineLearningCompute.Models.ServicePrincipalProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MachineLearningCompute.Models.ServicePrincipalProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MachineLearningCompute.Models.ServicePrincipalProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SslConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MachineLearningCompute.Models.SslConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MachineLearningCompute.Models.SslConfiguration>
    {
        public SslConfiguration() { }
        public string Cert { get { throw null; } set { } }
        public string Cname { get { throw null; } set { } }
        public string Key { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningCompute.Models.Status? Status { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MachineLearningCompute.Models.SslConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MachineLearningCompute.Models.SslConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MachineLearningCompute.Models.SslConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MachineLearningCompute.Models.SslConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MachineLearningCompute.Models.SslConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MachineLearningCompute.Models.SslConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MachineLearningCompute.Models.SslConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Status : System.IEquatable<Azure.ResourceManager.MachineLearningCompute.Models.Status>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Status(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningCompute.Models.Status Disabled { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningCompute.Models.Status Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningCompute.Models.Status other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningCompute.Models.Status left, Azure.ResourceManager.MachineLearningCompute.Models.Status right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningCompute.Models.Status (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningCompute.Models.Status left, Azure.ResourceManager.MachineLearningCompute.Models.Status right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StorageAccountCredentials : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MachineLearningCompute.Models.StorageAccountCredentials>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MachineLearningCompute.Models.StorageAccountCredentials>
    {
        internal StorageAccountCredentials() { }
        public string PrimaryKey { get { throw null; } }
        public string ResourceId { get { throw null; } }
        public string SecondaryKey { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MachineLearningCompute.Models.StorageAccountCredentials System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MachineLearningCompute.Models.StorageAccountCredentials>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MachineLearningCompute.Models.StorageAccountCredentials>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MachineLearningCompute.Models.StorageAccountCredentials System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MachineLearningCompute.Models.StorageAccountCredentials>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MachineLearningCompute.Models.StorageAccountCredentials>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MachineLearningCompute.Models.StorageAccountCredentials>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SystemService : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MachineLearningCompute.Models.SystemService>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MachineLearningCompute.Models.SystemService>
    {
        public SystemService(Azure.ResourceManager.MachineLearningCompute.Models.SystemServiceType systemServiceType) { }
        public string PublicIPAddress { get { throw null; } }
        public Azure.ResourceManager.MachineLearningCompute.Models.SystemServiceType SystemServiceType { get { throw null; } set { } }
        public string Version { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MachineLearningCompute.Models.SystemService System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MachineLearningCompute.Models.SystemService>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MachineLearningCompute.Models.SystemService>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MachineLearningCompute.Models.SystemService System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MachineLearningCompute.Models.SystemService>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MachineLearningCompute.Models.SystemService>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MachineLearningCompute.Models.SystemService>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SystemServiceType : System.IEquatable<Azure.ResourceManager.MachineLearningCompute.Models.SystemServiceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SystemServiceType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningCompute.Models.SystemServiceType BatchFrontEnd { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningCompute.Models.SystemServiceType None { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningCompute.Models.SystemServiceType ScoringFrontEnd { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningCompute.Models.SystemServiceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningCompute.Models.SystemServiceType left, Azure.ResourceManager.MachineLearningCompute.Models.SystemServiceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningCompute.Models.SystemServiceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningCompute.Models.SystemServiceType left, Azure.ResourceManager.MachineLearningCompute.Models.SystemServiceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UpdatesAvailable : System.IEquatable<Azure.ResourceManager.MachineLearningCompute.Models.UpdatesAvailable>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UpdatesAvailable(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningCompute.Models.UpdatesAvailable No { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningCompute.Models.UpdatesAvailable Yes { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningCompute.Models.UpdatesAvailable other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningCompute.Models.UpdatesAvailable left, Azure.ResourceManager.MachineLearningCompute.Models.UpdatesAvailable right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningCompute.Models.UpdatesAvailable (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningCompute.Models.UpdatesAvailable left, Azure.ResourceManager.MachineLearningCompute.Models.UpdatesAvailable right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UpdateSystemServicesResponse : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MachineLearningCompute.Models.UpdateSystemServicesResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MachineLearningCompute.Models.UpdateSystemServicesResponse>
    {
        internal UpdateSystemServicesResponse() { }
        public System.DateTimeOffset? UpdateCompletedOn { get { throw null; } }
        public System.DateTimeOffset? UpdateStartedOn { get { throw null; } }
        public Azure.ResourceManager.MachineLearningCompute.Models.OperationStatus? UpdateStatus { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MachineLearningCompute.Models.UpdateSystemServicesResponse System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MachineLearningCompute.Models.UpdateSystemServicesResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MachineLearningCompute.Models.UpdateSystemServicesResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MachineLearningCompute.Models.UpdateSystemServicesResponse System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MachineLearningCompute.Models.UpdateSystemServicesResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MachineLearningCompute.Models.UpdateSystemServicesResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MachineLearningCompute.Models.UpdateSystemServicesResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
