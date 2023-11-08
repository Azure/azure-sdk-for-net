namespace Azure.ResourceManager.DataFactory
{
    public partial class DataFactoryChangeDataCaptureCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataFactory.DataFactoryChangeDataCaptureResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataFactory.DataFactoryChangeDataCaptureResource>, System.Collections.IEnumerable
    {
        protected DataFactoryChangeDataCaptureCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.DataFactoryChangeDataCaptureResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string changeDataCaptureName, Azure.ResourceManager.DataFactory.DataFactoryChangeDataCaptureData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.DataFactoryChangeDataCaptureResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string changeDataCaptureName, Azure.ResourceManager.DataFactory.DataFactoryChangeDataCaptureData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string changeDataCaptureName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string changeDataCaptureName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryChangeDataCaptureResource> Get(string changeDataCaptureName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataFactory.DataFactoryChangeDataCaptureResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataFactory.DataFactoryChangeDataCaptureResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryChangeDataCaptureResource>> GetAsync(string changeDataCaptureName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DataFactory.DataFactoryChangeDataCaptureResource> GetIfExists(string changeDataCaptureName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DataFactory.DataFactoryChangeDataCaptureResource>> GetIfExistsAsync(string changeDataCaptureName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataFactory.DataFactoryChangeDataCaptureResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataFactory.DataFactoryChangeDataCaptureResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataFactory.DataFactoryChangeDataCaptureResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataFactory.DataFactoryChangeDataCaptureResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataFactoryChangeDataCaptureData : Azure.ResourceManager.Models.ResourceData
    {
        public DataFactoryChangeDataCaptureData(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataFactory.Models.MapperSourceConnectionsInfo> sourceConnectionsInfo, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataFactory.Models.MapperTargetConnectionsInfo> targetConnectionsInfo, Azure.ResourceManager.DataFactory.Models.MapperPolicy policy) { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public bool? AllowVnetOverride { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } }
        public string FolderName { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.MapperPolicy Policy { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.MapperSourceConnectionsInfo> SourceConnectionsInfo { get { throw null; } }
        public string Status { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.MapperTargetConnectionsInfo> TargetConnectionsInfo { get { throw null; } }
    }
    public partial class DataFactoryChangeDataCaptureResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataFactoryChangeDataCaptureResource() { }
        public virtual Azure.ResourceManager.DataFactory.DataFactoryChangeDataCaptureData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string factoryName, string changeDataCaptureName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryChangeDataCaptureResource> Get(string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryChangeDataCaptureResource>> GetAsync(string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Start(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> StartAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<string> Status(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<string>> StatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Stop(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> StopAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.DataFactoryChangeDataCaptureResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataFactory.DataFactoryChangeDataCaptureData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.DataFactoryChangeDataCaptureResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataFactory.DataFactoryChangeDataCaptureData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataFactoryCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataFactory.DataFactoryResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataFactory.DataFactoryResource>, System.Collections.IEnumerable
    {
        protected DataFactoryCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.DataFactoryResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string factoryName, Azure.ResourceManager.DataFactory.DataFactoryData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.DataFactoryResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string factoryName, Azure.ResourceManager.DataFactory.DataFactoryData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string factoryName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string factoryName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryResource> Get(string factoryName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataFactory.DataFactoryResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataFactory.DataFactoryResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryResource>> GetAsync(string factoryName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DataFactory.DataFactoryResource> GetIfExists(string factoryName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DataFactory.DataFactoryResource>> GetIfExistsAsync(string factoryName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataFactory.DataFactoryResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataFactory.DataFactoryResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataFactory.DataFactoryResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataFactory.DataFactoryResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataFactoryData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public DataFactoryData(Azure.Core.AzureLocation location) { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.DataFactoryEncryptionConfiguration Encryption { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DataFactory.Models.DataFactoryGlobalParameterProperties> GlobalParameters { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.DataFactoryPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PurviewResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactoryRepoConfiguration RepoConfiguration { get { throw null; } set { } }
        public string Version { get { throw null; } }
    }
    public partial class DataFactoryDataFlowCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataFactory.DataFactoryDataFlowResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataFactory.DataFactoryDataFlowResource>, System.Collections.IEnumerable
    {
        protected DataFactoryDataFlowCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.DataFactoryDataFlowResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string dataFlowName, Azure.ResourceManager.DataFactory.DataFactoryDataFlowData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.DataFactoryDataFlowResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string dataFlowName, Azure.ResourceManager.DataFactory.DataFactoryDataFlowData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string dataFlowName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string dataFlowName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryDataFlowResource> Get(string dataFlowName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataFactory.DataFactoryDataFlowResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataFactory.DataFactoryDataFlowResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryDataFlowResource>> GetAsync(string dataFlowName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DataFactory.DataFactoryDataFlowResource> GetIfExists(string dataFlowName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DataFactory.DataFactoryDataFlowResource>> GetIfExistsAsync(string dataFlowName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataFactory.DataFactoryDataFlowResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataFactory.DataFactoryDataFlowResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataFactory.DataFactoryDataFlowResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataFactory.DataFactoryDataFlowResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataFactoryDataFlowData : Azure.ResourceManager.Models.ResourceData
    {
        public DataFactoryDataFlowData(Azure.ResourceManager.DataFactory.Models.DataFactoryDataFlowProperties properties) { }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.DataFactoryDataFlowProperties Properties { get { throw null; } set { } }
    }
    public partial class DataFactoryDataFlowResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataFactoryDataFlowResource() { }
        public virtual Azure.ResourceManager.DataFactory.DataFactoryDataFlowData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string factoryName, string dataFlowName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryDataFlowResource> Get(string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryDataFlowResource>> GetAsync(string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.DataFactoryDataFlowResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataFactory.DataFactoryDataFlowData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.DataFactoryDataFlowResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataFactory.DataFactoryDataFlowData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataFactoryDatasetCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataFactory.DataFactoryDatasetResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataFactory.DataFactoryDatasetResource>, System.Collections.IEnumerable
    {
        protected DataFactoryDatasetCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.DataFactoryDatasetResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string datasetName, Azure.ResourceManager.DataFactory.DataFactoryDatasetData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.DataFactoryDatasetResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string datasetName, Azure.ResourceManager.DataFactory.DataFactoryDatasetData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string datasetName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string datasetName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryDatasetResource> Get(string datasetName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataFactory.DataFactoryDatasetResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataFactory.DataFactoryDatasetResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryDatasetResource>> GetAsync(string datasetName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DataFactory.DataFactoryDatasetResource> GetIfExists(string datasetName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DataFactory.DataFactoryDatasetResource>> GetIfExistsAsync(string datasetName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataFactory.DataFactoryDatasetResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataFactory.DataFactoryDatasetResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataFactory.DataFactoryDatasetResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataFactory.DataFactoryDatasetResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataFactoryDatasetData : Azure.ResourceManager.Models.ResourceData
    {
        public DataFactoryDatasetData(Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetProperties properties) { }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetProperties Properties { get { throw null; } set { } }
    }
    public partial class DataFactoryDatasetResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataFactoryDatasetResource() { }
        public virtual Azure.ResourceManager.DataFactory.DataFactoryDatasetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string factoryName, string datasetName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryDatasetResource> Get(string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryDatasetResource>> GetAsync(string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.DataFactoryDatasetResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataFactory.DataFactoryDatasetData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.DataFactoryDatasetResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataFactory.DataFactoryDatasetData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class DataFactoryExtensions
    {
        public static Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryResource> ConfigureFactoryRepoInformation(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationId, Azure.ResourceManager.DataFactory.Models.FactoryRepoContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryResource>> ConfigureFactoryRepoInformationAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationId, Azure.ResourceManager.DataFactory.Models.FactoryRepoContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DataFactory.DataFactoryCollection GetDataFactories(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DataFactory.DataFactoryResource> GetDataFactories(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DataFactory.DataFactoryResource> GetDataFactoriesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryResource> GetDataFactory(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string factoryName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryResource>> GetDataFactoryAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string factoryName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DataFactory.DataFactoryChangeDataCaptureResource GetDataFactoryChangeDataCaptureResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataFactory.DataFactoryDataFlowResource GetDataFactoryDataFlowResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataFactory.DataFactoryDatasetResource GetDataFactoryDatasetResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataFactory.DataFactoryGlobalParameterResource GetDataFactoryGlobalParameterResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataFactory.DataFactoryIntegrationRuntimeResource GetDataFactoryIntegrationRuntimeResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataFactory.DataFactoryLinkedServiceResource GetDataFactoryLinkedServiceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataFactory.DataFactoryManagedIdentityCredentialResource GetDataFactoryManagedIdentityCredentialResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataFactory.DataFactoryManagedVirtualNetworkResource GetDataFactoryManagedVirtualNetworkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataFactory.DataFactoryPipelineResource GetDataFactoryPipelineResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataFactory.DataFactoryPrivateEndpointConnectionResource GetDataFactoryPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataFactory.DataFactoryPrivateEndpointResource GetDataFactoryPrivateEndpointResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataFactory.DataFactoryResource GetDataFactoryResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataFactory.DataFactoryTriggerResource GetDataFactoryTriggerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DataFactory.Models.ExposureControlResult> GetFeatureValueExposureControl(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationId, Azure.ResourceManager.DataFactory.Models.ExposureControlContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.Models.ExposureControlResult>> GetFeatureValueExposureControlAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationId, Azure.ResourceManager.DataFactory.Models.ExposureControlContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataFactoryGlobalParameterCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataFactory.DataFactoryGlobalParameterResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataFactory.DataFactoryGlobalParameterResource>, System.Collections.IEnumerable
    {
        protected DataFactoryGlobalParameterCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.DataFactoryGlobalParameterResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string globalParameterName, Azure.ResourceManager.DataFactory.DataFactoryGlobalParameterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.DataFactoryGlobalParameterResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string globalParameterName, Azure.ResourceManager.DataFactory.DataFactoryGlobalParameterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string globalParameterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string globalParameterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryGlobalParameterResource> Get(string globalParameterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataFactory.DataFactoryGlobalParameterResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataFactory.DataFactoryGlobalParameterResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryGlobalParameterResource>> GetAsync(string globalParameterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DataFactory.DataFactoryGlobalParameterResource> GetIfExists(string globalParameterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DataFactory.DataFactoryGlobalParameterResource>> GetIfExistsAsync(string globalParameterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataFactory.DataFactoryGlobalParameterResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataFactory.DataFactoryGlobalParameterResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataFactory.DataFactoryGlobalParameterResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataFactory.DataFactoryGlobalParameterResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataFactoryGlobalParameterData : Azure.ResourceManager.Models.ResourceData
    {
        public DataFactoryGlobalParameterData(System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DataFactory.Models.DataFactoryGlobalParameterProperties> properties) { }
        public Azure.ETag? ETag { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DataFactory.Models.DataFactoryGlobalParameterProperties> Properties { get { throw null; } }
    }
    public partial class DataFactoryGlobalParameterResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataFactoryGlobalParameterResource() { }
        public virtual Azure.ResourceManager.DataFactory.DataFactoryGlobalParameterData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string factoryName, string globalParameterName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryGlobalParameterResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryGlobalParameterResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.DataFactoryGlobalParameterResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataFactory.DataFactoryGlobalParameterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.DataFactoryGlobalParameterResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataFactory.DataFactoryGlobalParameterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataFactoryIntegrationRuntimeCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataFactory.DataFactoryIntegrationRuntimeResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataFactory.DataFactoryIntegrationRuntimeResource>, System.Collections.IEnumerable
    {
        protected DataFactoryIntegrationRuntimeCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.DataFactoryIntegrationRuntimeResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string integrationRuntimeName, Azure.ResourceManager.DataFactory.DataFactoryIntegrationRuntimeData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.DataFactoryIntegrationRuntimeResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string integrationRuntimeName, Azure.ResourceManager.DataFactory.DataFactoryIntegrationRuntimeData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string integrationRuntimeName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string integrationRuntimeName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryIntegrationRuntimeResource> Get(string integrationRuntimeName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataFactory.DataFactoryIntegrationRuntimeResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataFactory.DataFactoryIntegrationRuntimeResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryIntegrationRuntimeResource>> GetAsync(string integrationRuntimeName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DataFactory.DataFactoryIntegrationRuntimeResource> GetIfExists(string integrationRuntimeName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DataFactory.DataFactoryIntegrationRuntimeResource>> GetIfExistsAsync(string integrationRuntimeName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataFactory.DataFactoryIntegrationRuntimeResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataFactory.DataFactoryIntegrationRuntimeResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataFactory.DataFactoryIntegrationRuntimeResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataFactory.DataFactoryIntegrationRuntimeResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataFactoryIntegrationRuntimeData : Azure.ResourceManager.Models.ResourceData
    {
        public DataFactoryIntegrationRuntimeData(Azure.ResourceManager.DataFactory.Models.DataFactoryIntegrationRuntimeProperties properties) { }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.DataFactoryIntegrationRuntimeProperties Properties { get { throw null; } set { } }
    }
    public partial class DataFactoryIntegrationRuntimeResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataFactoryIntegrationRuntimeResource() { }
        public virtual Azure.ResourceManager.DataFactory.DataFactoryIntegrationRuntimeData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.Models.DataFactoryIntegrationRuntimeStatusResult> CreateLinkedIntegrationRuntime(Azure.ResourceManager.DataFactory.Models.CreateLinkedIntegrationRuntimeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.Models.DataFactoryIntegrationRuntimeStatusResult>> CreateLinkedIntegrationRuntimeAsync(Azure.ResourceManager.DataFactory.Models.CreateLinkedIntegrationRuntimeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string factoryName, string integrationRuntimeName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteIntegrationRuntimeNode(string nodeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteIntegrationRuntimeNodeAsync(string nodeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryIntegrationRuntimeResource> Get(string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataFactory.Models.SsisObjectMetadata> GetAllIntegrationRuntimeObjectMetadata(Azure.ResourceManager.DataFactory.Models.GetSsisObjectMetadataContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataFactory.Models.SsisObjectMetadata> GetAllIntegrationRuntimeObjectMetadataAsync(Azure.ResourceManager.DataFactory.Models.GetSsisObjectMetadataContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryIntegrationRuntimeResource>> GetAsync(string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeAuthKeys> GetAuthKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeAuthKeys>> GetAuthKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeConnectionInfo> GetConnectionInfo(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeConnectionInfo>> GetConnectionInfoAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.Models.SelfHostedIntegrationRuntimeNode> GetIntegrationRuntimeNode(string nodeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.Models.SelfHostedIntegrationRuntimeNode>> GetIntegrationRuntimeNodeAsync(string nodeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeNodeIPAddress> GetIPAddressIntegrationRuntimeNode(string nodeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeNodeIPAddress>> GetIPAddressIntegrationRuntimeNodeAsync(string nodeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeMonitoringData> GetMonitoringData(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeMonitoringData>> GetMonitoringDataAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeOutboundNetworkDependenciesCategoryEndpoint> GetOutboundNetworkDependencies(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeOutboundNetworkDependenciesCategoryEndpoint> GetOutboundNetworkDependenciesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.Models.DataFactoryIntegrationRuntimeStatusResult> GetStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.Models.DataFactoryIntegrationRuntimeStatusResult>> GetStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.Models.SsisObjectMetadataStatusResult> RefreshIntegrationRuntimeObjectMetadata(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.Models.SsisObjectMetadataStatusResult>> RefreshIntegrationRuntimeObjectMetadataAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeAuthKeys> RegenerateAuthKey(Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeRegenerateKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeAuthKeys>> RegenerateAuthKeyAsync(Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeRegenerateKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RemoveLinks(Azure.ResourceManager.DataFactory.Models.LinkedIntegrationRuntimeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RemoveLinksAsync(Azure.ResourceManager.DataFactory.Models.LinkedIntegrationRuntimeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.Models.DataFactoryIntegrationRuntimeStatusResult> Start(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.Models.DataFactoryIntegrationRuntimeStatusResult>> StartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Stop(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StopAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SyncCredentials(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SyncCredentialsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryIntegrationRuntimeResource> Update(Azure.ResourceManager.DataFactory.Models.DataFactoryIntegrationRuntimePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryIntegrationRuntimeResource>> UpdateAsync(Azure.ResourceManager.DataFactory.Models.DataFactoryIntegrationRuntimePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.Models.SelfHostedIntegrationRuntimeNode> UpdateIntegrationRuntimeNode(string nodeName, Azure.ResourceManager.DataFactory.Models.UpdateIntegrationRuntimeNodeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.Models.SelfHostedIntegrationRuntimeNode>> UpdateIntegrationRuntimeNodeAsync(string nodeName, Azure.ResourceManager.DataFactory.Models.UpdateIntegrationRuntimeNodeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Upgrade(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpgradeAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataFactoryLinkedServiceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataFactory.DataFactoryLinkedServiceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataFactory.DataFactoryLinkedServiceResource>, System.Collections.IEnumerable
    {
        protected DataFactoryLinkedServiceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.DataFactoryLinkedServiceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string linkedServiceName, Azure.ResourceManager.DataFactory.DataFactoryLinkedServiceData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.DataFactoryLinkedServiceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string linkedServiceName, Azure.ResourceManager.DataFactory.DataFactoryLinkedServiceData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string linkedServiceName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string linkedServiceName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryLinkedServiceResource> Get(string linkedServiceName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataFactory.DataFactoryLinkedServiceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataFactory.DataFactoryLinkedServiceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryLinkedServiceResource>> GetAsync(string linkedServiceName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DataFactory.DataFactoryLinkedServiceResource> GetIfExists(string linkedServiceName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DataFactory.DataFactoryLinkedServiceResource>> GetIfExistsAsync(string linkedServiceName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataFactory.DataFactoryLinkedServiceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataFactory.DataFactoryLinkedServiceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataFactory.DataFactoryLinkedServiceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataFactory.DataFactoryLinkedServiceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataFactoryLinkedServiceData : Azure.ResourceManager.Models.ResourceData
    {
        public DataFactoryLinkedServiceData(Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties properties) { }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties Properties { get { throw null; } set { } }
    }
    public partial class DataFactoryLinkedServiceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataFactoryLinkedServiceResource() { }
        public virtual Azure.ResourceManager.DataFactory.DataFactoryLinkedServiceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string factoryName, string linkedServiceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryLinkedServiceResource> Get(string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryLinkedServiceResource>> GetAsync(string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.DataFactoryLinkedServiceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataFactory.DataFactoryLinkedServiceData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.DataFactoryLinkedServiceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataFactory.DataFactoryLinkedServiceData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataFactoryManagedIdentityCredentialCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataFactory.DataFactoryManagedIdentityCredentialResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataFactory.DataFactoryManagedIdentityCredentialResource>, System.Collections.IEnumerable
    {
        protected DataFactoryManagedIdentityCredentialCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.DataFactoryManagedIdentityCredentialResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string credentialName, Azure.ResourceManager.DataFactory.DataFactoryManagedIdentityCredentialData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.DataFactoryManagedIdentityCredentialResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string credentialName, Azure.ResourceManager.DataFactory.DataFactoryManagedIdentityCredentialData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string credentialName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string credentialName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryManagedIdentityCredentialResource> Get(string credentialName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataFactory.DataFactoryManagedIdentityCredentialResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataFactory.DataFactoryManagedIdentityCredentialResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryManagedIdentityCredentialResource>> GetAsync(string credentialName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DataFactory.DataFactoryManagedIdentityCredentialResource> GetIfExists(string credentialName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DataFactory.DataFactoryManagedIdentityCredentialResource>> GetIfExistsAsync(string credentialName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataFactory.DataFactoryManagedIdentityCredentialResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataFactory.DataFactoryManagedIdentityCredentialResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataFactory.DataFactoryManagedIdentityCredentialResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataFactory.DataFactoryManagedIdentityCredentialResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataFactoryManagedIdentityCredentialData : Azure.ResourceManager.Models.ResourceData
    {
        public DataFactoryManagedIdentityCredentialData(Azure.ResourceManager.DataFactory.Models.DataFactoryManagedIdentityCredentialProperties properties) { }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.DataFactoryManagedIdentityCredentialProperties Properties { get { throw null; } set { } }
    }
    public partial class DataFactoryManagedIdentityCredentialResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataFactoryManagedIdentityCredentialResource() { }
        public virtual Azure.ResourceManager.DataFactory.DataFactoryManagedIdentityCredentialData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string factoryName, string credentialName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryManagedIdentityCredentialResource> Get(string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryManagedIdentityCredentialResource>> GetAsync(string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.DataFactoryManagedIdentityCredentialResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataFactory.DataFactoryManagedIdentityCredentialData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.DataFactoryManagedIdentityCredentialResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataFactory.DataFactoryManagedIdentityCredentialData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataFactoryManagedVirtualNetworkCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataFactory.DataFactoryManagedVirtualNetworkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataFactory.DataFactoryManagedVirtualNetworkResource>, System.Collections.IEnumerable
    {
        protected DataFactoryManagedVirtualNetworkCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.DataFactoryManagedVirtualNetworkResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string managedVirtualNetworkName, Azure.ResourceManager.DataFactory.DataFactoryManagedVirtualNetworkData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.DataFactoryManagedVirtualNetworkResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string managedVirtualNetworkName, Azure.ResourceManager.DataFactory.DataFactoryManagedVirtualNetworkData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string managedVirtualNetworkName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string managedVirtualNetworkName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryManagedVirtualNetworkResource> Get(string managedVirtualNetworkName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataFactory.DataFactoryManagedVirtualNetworkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataFactory.DataFactoryManagedVirtualNetworkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryManagedVirtualNetworkResource>> GetAsync(string managedVirtualNetworkName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DataFactory.DataFactoryManagedVirtualNetworkResource> GetIfExists(string managedVirtualNetworkName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DataFactory.DataFactoryManagedVirtualNetworkResource>> GetIfExistsAsync(string managedVirtualNetworkName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataFactory.DataFactoryManagedVirtualNetworkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataFactory.DataFactoryManagedVirtualNetworkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataFactory.DataFactoryManagedVirtualNetworkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataFactory.DataFactoryManagedVirtualNetworkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataFactoryManagedVirtualNetworkData : Azure.ResourceManager.Models.ResourceData
    {
        public DataFactoryManagedVirtualNetworkData(Azure.ResourceManager.DataFactory.Models.DataFactoryManagedVirtualNetworkProperties properties) { }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.DataFactoryManagedVirtualNetworkProperties Properties { get { throw null; } set { } }
    }
    public partial class DataFactoryManagedVirtualNetworkResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataFactoryManagedVirtualNetworkResource() { }
        public virtual Azure.ResourceManager.DataFactory.DataFactoryManagedVirtualNetworkData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string factoryName, string managedVirtualNetworkName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryManagedVirtualNetworkResource> Get(string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryManagedVirtualNetworkResource>> GetAsync(string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryPrivateEndpointResource> GetDataFactoryPrivateEndpoint(string managedPrivateEndpointName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryPrivateEndpointResource>> GetDataFactoryPrivateEndpointAsync(string managedPrivateEndpointName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataFactory.DataFactoryPrivateEndpointCollection GetDataFactoryPrivateEndpoints() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.DataFactoryManagedVirtualNetworkResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataFactory.DataFactoryManagedVirtualNetworkData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.DataFactoryManagedVirtualNetworkResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataFactory.DataFactoryManagedVirtualNetworkData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataFactoryPipelineCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataFactory.DataFactoryPipelineResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataFactory.DataFactoryPipelineResource>, System.Collections.IEnumerable
    {
        protected DataFactoryPipelineCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.DataFactoryPipelineResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string pipelineName, Azure.ResourceManager.DataFactory.DataFactoryPipelineData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.DataFactoryPipelineResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string pipelineName, Azure.ResourceManager.DataFactory.DataFactoryPipelineData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string pipelineName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string pipelineName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryPipelineResource> Get(string pipelineName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataFactory.DataFactoryPipelineResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataFactory.DataFactoryPipelineResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryPipelineResource>> GetAsync(string pipelineName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DataFactory.DataFactoryPipelineResource> GetIfExists(string pipelineName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DataFactory.DataFactoryPipelineResource>> GetIfExistsAsync(string pipelineName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataFactory.DataFactoryPipelineResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataFactory.DataFactoryPipelineResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataFactory.DataFactoryPipelineResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataFactory.DataFactoryPipelineResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataFactoryPipelineData : Azure.ResourceManager.Models.ResourceData
    {
        public DataFactoryPipelineData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.PipelineActivity> Activities { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public System.Collections.Generic.IList<System.BinaryData> Annotations { get { throw null; } }
        public int? Concurrency { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public System.BinaryData ElapsedTimeMetricDuration { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } }
        public string FolderName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DataFactory.Models.EntityParameterSpecification> Parameters { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> RunDimensions { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DataFactory.Models.PipelineVariableSpecification> Variables { get { throw null; } }
    }
    public partial class DataFactoryPipelineResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataFactoryPipelineResource() { }
        public virtual Azure.ResourceManager.DataFactory.DataFactoryPipelineData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string factoryName, string pipelineName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.Models.PipelineCreateRunResult> CreateRun(System.Collections.Generic.IDictionary<string, System.BinaryData> parameterValueSpecification = null, string referencePipelineRunId = null, bool? isRecovery = default(bool?), string startActivityName = null, bool? startFromFailure = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.Models.PipelineCreateRunResult>> CreateRunAsync(System.Collections.Generic.IDictionary<string, System.BinaryData> parameterValueSpecification = null, string referencePipelineRunId = null, bool? isRecovery = default(bool?), string startActivityName = null, bool? startFromFailure = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryPipelineResource> Get(string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryPipelineResource>> GetAsync(string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.DataFactoryPipelineResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataFactory.DataFactoryPipelineData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.DataFactoryPipelineResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataFactory.DataFactoryPipelineData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataFactoryPrivateEndpointCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataFactory.DataFactoryPrivateEndpointResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataFactory.DataFactoryPrivateEndpointResource>, System.Collections.IEnumerable
    {
        protected DataFactoryPrivateEndpointCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.DataFactoryPrivateEndpointResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string managedPrivateEndpointName, Azure.ResourceManager.DataFactory.DataFactoryPrivateEndpointData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.DataFactoryPrivateEndpointResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string managedPrivateEndpointName, Azure.ResourceManager.DataFactory.DataFactoryPrivateEndpointData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string managedPrivateEndpointName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string managedPrivateEndpointName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryPrivateEndpointResource> Get(string managedPrivateEndpointName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataFactory.DataFactoryPrivateEndpointResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataFactory.DataFactoryPrivateEndpointResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryPrivateEndpointResource>> GetAsync(string managedPrivateEndpointName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DataFactory.DataFactoryPrivateEndpointResource> GetIfExists(string managedPrivateEndpointName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DataFactory.DataFactoryPrivateEndpointResource>> GetIfExistsAsync(string managedPrivateEndpointName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataFactory.DataFactoryPrivateEndpointResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataFactory.DataFactoryPrivateEndpointResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataFactory.DataFactoryPrivateEndpointResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataFactory.DataFactoryPrivateEndpointResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataFactoryPrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataFactory.DataFactoryPrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataFactory.DataFactoryPrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected DataFactoryPrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.DataFactoryPrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.DataFactory.Models.DataFactoryPrivateEndpointConnectionCreateOrUpdateContent content, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.DataFactoryPrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.DataFactory.Models.DataFactoryPrivateEndpointConnectionCreateOrUpdateContent content, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryPrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataFactory.DataFactoryPrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataFactory.DataFactoryPrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryPrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DataFactory.DataFactoryPrivateEndpointConnectionResource> GetIfExists(string privateEndpointConnectionName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DataFactory.DataFactoryPrivateEndpointConnectionResource>> GetIfExistsAsync(string privateEndpointConnectionName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataFactory.DataFactoryPrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataFactory.DataFactoryPrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataFactory.DataFactoryPrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataFactory.DataFactoryPrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataFactoryPrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData
    {
        public DataFactoryPrivateEndpointConnectionData() { }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.DataFactoryPrivateEndpointConnectionProperties Properties { get { throw null; } set { } }
    }
    public partial class DataFactoryPrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataFactoryPrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.DataFactory.DataFactoryPrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string factoryName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryPrivateEndpointConnectionResource> Get(string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryPrivateEndpointConnectionResource>> GetAsync(string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.DataFactoryPrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataFactory.Models.DataFactoryPrivateEndpointConnectionCreateOrUpdateContent content, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.DataFactoryPrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataFactory.Models.DataFactoryPrivateEndpointConnectionCreateOrUpdateContent content, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataFactoryPrivateEndpointData : Azure.ResourceManager.Models.ResourceData
    {
        public DataFactoryPrivateEndpointData(Azure.ResourceManager.DataFactory.Models.DataFactoryPrivateEndpointProperties properties) { }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.DataFactoryPrivateEndpointProperties Properties { get { throw null; } set { } }
    }
    public partial class DataFactoryPrivateEndpointResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataFactoryPrivateEndpointResource() { }
        public virtual Azure.ResourceManager.DataFactory.DataFactoryPrivateEndpointData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string factoryName, string managedVirtualNetworkName, string managedPrivateEndpointName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryPrivateEndpointResource> Get(string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryPrivateEndpointResource>> GetAsync(string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.DataFactoryPrivateEndpointResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataFactory.DataFactoryPrivateEndpointData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.DataFactoryPrivateEndpointResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataFactory.DataFactoryPrivateEndpointData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataFactoryResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataFactoryResource() { }
        public virtual Azure.ResourceManager.DataFactory.DataFactoryData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.Models.DataFactoryDataFlowStartDebugSessionResult> AddDataFlowToDebugSession(Azure.ResourceManager.DataFactory.Models.DataFactoryDataFlowDebugPackageContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.Models.DataFactoryDataFlowStartDebugSessionResult>> AddDataFlowToDebugSessionAsync(Azure.ResourceManager.DataFactory.Models.DataFactoryDataFlowDebugPackageContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CancelPipelineRun(string runId, bool? isRecursive = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelPipelineRunAsync(string runId, bool? isRecursive = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.Models.DataFactoryDataFlowCreateDebugSessionResult> CreateDataFlowDebugSession(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataFactory.Models.DataFactoryDataFlowDebugSessionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.Models.DataFactoryDataFlowCreateDebugSessionResult>> CreateDataFlowDebugSessionAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataFactory.Models.DataFactoryDataFlowDebugSessionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string factoryName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteDataFlowDebugSession(Azure.ResourceManager.DataFactory.Models.DeleteDataFlowDebugSessionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteDataFlowDebugSessionAsync(Azure.ResourceManager.DataFactory.Models.DeleteDataFlowDebugSessionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.Models.DataFactoryDataFlowDebugCommandResult> ExecuteDataFlowDebugSessionCommand(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataFactory.Models.DataFlowDebugCommandContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.Models.DataFactoryDataFlowDebugCommandResult>> ExecuteDataFlowDebugSessionCommandAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataFactory.Models.DataFlowDebugCommandContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryResource> Get(string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataFactory.Models.PipelineActivityRunInformation> GetActivityRun(string runId, Azure.ResourceManager.DataFactory.Models.RunFilterContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataFactory.Models.PipelineActivityRunInformation> GetActivityRunAsync(string runId, Azure.ResourceManager.DataFactory.Models.RunFilterContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryResource>> GetAsync(string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryChangeDataCaptureResource> GetDataFactoryChangeDataCapture(string changeDataCaptureName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryChangeDataCaptureResource>> GetDataFactoryChangeDataCaptureAsync(string changeDataCaptureName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataFactory.DataFactoryChangeDataCaptureCollection GetDataFactoryChangeDataCaptures() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryDataFlowResource> GetDataFactoryDataFlow(string dataFlowName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryDataFlowResource>> GetDataFactoryDataFlowAsync(string dataFlowName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataFactory.DataFactoryDataFlowCollection GetDataFactoryDataFlows() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryDatasetResource> GetDataFactoryDataset(string datasetName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryDatasetResource>> GetDataFactoryDatasetAsync(string datasetName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataFactory.DataFactoryDatasetCollection GetDataFactoryDatasets() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryGlobalParameterResource> GetDataFactoryGlobalParameter(string globalParameterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryGlobalParameterResource>> GetDataFactoryGlobalParameterAsync(string globalParameterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataFactory.DataFactoryGlobalParameterCollection GetDataFactoryGlobalParameters() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryIntegrationRuntimeResource> GetDataFactoryIntegrationRuntime(string integrationRuntimeName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryIntegrationRuntimeResource>> GetDataFactoryIntegrationRuntimeAsync(string integrationRuntimeName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataFactory.DataFactoryIntegrationRuntimeCollection GetDataFactoryIntegrationRuntimes() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryLinkedServiceResource> GetDataFactoryLinkedService(string linkedServiceName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryLinkedServiceResource>> GetDataFactoryLinkedServiceAsync(string linkedServiceName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataFactory.DataFactoryLinkedServiceCollection GetDataFactoryLinkedServices() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryManagedIdentityCredentialResource> GetDataFactoryManagedIdentityCredential(string credentialName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryManagedIdentityCredentialResource>> GetDataFactoryManagedIdentityCredentialAsync(string credentialName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataFactory.DataFactoryManagedIdentityCredentialCollection GetDataFactoryManagedIdentityCredentials() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryManagedVirtualNetworkResource> GetDataFactoryManagedVirtualNetwork(string managedVirtualNetworkName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryManagedVirtualNetworkResource>> GetDataFactoryManagedVirtualNetworkAsync(string managedVirtualNetworkName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataFactory.DataFactoryManagedVirtualNetworkCollection GetDataFactoryManagedVirtualNetworks() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryPipelineResource> GetDataFactoryPipeline(string pipelineName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryPipelineResource>> GetDataFactoryPipelineAsync(string pipelineName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataFactory.DataFactoryPipelineCollection GetDataFactoryPipelines() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryPrivateEndpointConnectionResource> GetDataFactoryPrivateEndpointConnection(string privateEndpointConnectionName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryPrivateEndpointConnectionResource>> GetDataFactoryPrivateEndpointConnectionAsync(string privateEndpointConnectionName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataFactory.DataFactoryPrivateEndpointConnectionCollection GetDataFactoryPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryTriggerResource> GetDataFactoryTrigger(string triggerName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryTriggerResource>> GetDataFactoryTriggerAsync(string triggerName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataFactory.DataFactoryTriggerCollection GetDataFactoryTriggers() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataFactory.Models.DataFlowDebugSessionInfo> GetDataFlowDebugSessions(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataFactory.Models.DataFlowDebugSessionInfo> GetDataFlowDebugSessionsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.Models.DataFactoryDataPlaneAccessPolicyResult> GetDataPlaneAccess(Azure.ResourceManager.DataFactory.Models.DataFactoryDataPlaneUserAccessPolicy policy, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.Models.DataFactoryDataPlaneAccessPolicyResult>> GetDataPlaneAccessAsync(Azure.ResourceManager.DataFactory.Models.DataFactoryDataPlaneUserAccessPolicy policy, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.Models.ExposureControlResult> GetExposureControlFeature(Azure.ResourceManager.DataFactory.Models.ExposureControlContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.Models.ExposureControlResult>> GetExposureControlFeatureAsync(Azure.ResourceManager.DataFactory.Models.ExposureControlContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.Models.ExposureControlBatchResult> GetExposureControlFeatures(Azure.ResourceManager.DataFactory.Models.ExposureControlBatchContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.Models.ExposureControlBatchResult>> GetExposureControlFeaturesAsync(Azure.ResourceManager.DataFactory.Models.ExposureControlBatchContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.Models.GitHubAccessTokenResult> GetGitHubAccessToken(Azure.ResourceManager.DataFactory.Models.GitHubAccessTokenContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.Models.GitHubAccessTokenResult>> GetGitHubAccessTokenAsync(Azure.ResourceManager.DataFactory.Models.GitHubAccessTokenContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.Models.DataFactoryPipelineRunInfo> GetPipelineRun(string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.Models.DataFactoryPipelineRunInfo>> GetPipelineRunAsync(string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataFactory.Models.DataFactoryPipelineRunInfo> GetPipelineRuns(Azure.ResourceManager.DataFactory.Models.RunFilterContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataFactory.Models.DataFactoryPipelineRunInfo> GetPipelineRunsAsync(Azure.ResourceManager.DataFactory.Models.RunFilterContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataFactory.Models.DataFactoryPrivateLinkResource> GetPrivateLinkResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataFactory.Models.DataFactoryPrivateLinkResource> GetPrivateLinkResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataFactory.Models.DataFactoryTriggerRun> GetTriggerRuns(Azure.ResourceManager.DataFactory.Models.RunFilterContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataFactory.Models.DataFactoryTriggerRun> GetTriggerRunsAsync(Azure.ResourceManager.DataFactory.Models.RunFilterContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataFactory.DataFactoryTriggerResource> GetTriggers(Azure.ResourceManager.DataFactory.Models.TriggerFilterContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataFactory.DataFactoryTriggerResource> GetTriggersAsync(Azure.ResourceManager.DataFactory.Models.TriggerFilterContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryResource> Update(Azure.ResourceManager.DataFactory.Models.DataFactoryPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryResource>> UpdateAsync(Azure.ResourceManager.DataFactory.Models.DataFactoryPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataFactoryTriggerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataFactory.DataFactoryTriggerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataFactory.DataFactoryTriggerResource>, System.Collections.IEnumerable
    {
        protected DataFactoryTriggerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.DataFactoryTriggerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string triggerName, Azure.ResourceManager.DataFactory.DataFactoryTriggerData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.DataFactoryTriggerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string triggerName, Azure.ResourceManager.DataFactory.DataFactoryTriggerData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string triggerName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string triggerName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryTriggerResource> Get(string triggerName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataFactory.DataFactoryTriggerResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataFactory.DataFactoryTriggerResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryTriggerResource>> GetAsync(string triggerName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DataFactory.DataFactoryTriggerResource> GetIfExists(string triggerName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DataFactory.DataFactoryTriggerResource>> GetIfExistsAsync(string triggerName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataFactory.DataFactoryTriggerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataFactory.DataFactoryTriggerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataFactory.DataFactoryTriggerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataFactory.DataFactoryTriggerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataFactoryTriggerData : Azure.ResourceManager.Models.ResourceData
    {
        public DataFactoryTriggerData(Azure.ResourceManager.DataFactory.Models.DataFactoryTriggerProperties properties) { }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.DataFactoryTriggerProperties Properties { get { throw null; } set { } }
    }
    public partial class DataFactoryTriggerResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataFactoryTriggerResource() { }
        public virtual Azure.ResourceManager.DataFactory.DataFactoryTriggerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response CancelTriggerRun(string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelTriggerRunAsync(string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string factoryName, string triggerName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryTriggerResource> Get(string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryTriggerResource>> GetAsync(string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.Models.DataFactoryTriggerSubscriptionOperationResult> GetEventSubscriptionStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.Models.DataFactoryTriggerSubscriptionOperationResult>> GetEventSubscriptionStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RerunTriggerRun(string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RerunTriggerRunAsync(string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Start(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Stop(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StopAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.Models.DataFactoryTriggerSubscriptionOperationResult> SubscribeToEvents(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.Models.DataFactoryTriggerSubscriptionOperationResult>> SubscribeToEventsAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.Models.DataFactoryTriggerSubscriptionOperationResult> UnsubscribeFromEvents(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.Models.DataFactoryTriggerSubscriptionOperationResult>> UnsubscribeFromEventsAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.DataFactoryTriggerResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataFactory.DataFactoryTriggerData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.DataFactoryTriggerResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataFactory.DataFactoryTriggerData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.DataFactory.Mocking
{
    public partial class MockableDataFactoryArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableDataFactoryArmClient() { }
        public virtual Azure.ResourceManager.DataFactory.DataFactoryChangeDataCaptureResource GetDataFactoryChangeDataCaptureResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DataFactory.DataFactoryDataFlowResource GetDataFactoryDataFlowResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DataFactory.DataFactoryDatasetResource GetDataFactoryDatasetResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DataFactory.DataFactoryGlobalParameterResource GetDataFactoryGlobalParameterResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DataFactory.DataFactoryIntegrationRuntimeResource GetDataFactoryIntegrationRuntimeResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DataFactory.DataFactoryLinkedServiceResource GetDataFactoryLinkedServiceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DataFactory.DataFactoryManagedIdentityCredentialResource GetDataFactoryManagedIdentityCredentialResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DataFactory.DataFactoryManagedVirtualNetworkResource GetDataFactoryManagedVirtualNetworkResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DataFactory.DataFactoryPipelineResource GetDataFactoryPipelineResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DataFactory.DataFactoryPrivateEndpointConnectionResource GetDataFactoryPrivateEndpointConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DataFactory.DataFactoryPrivateEndpointResource GetDataFactoryPrivateEndpointResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DataFactory.DataFactoryResource GetDataFactoryResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DataFactory.DataFactoryTriggerResource GetDataFactoryTriggerResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableDataFactoryResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableDataFactoryResourceGroupResource() { }
        public virtual Azure.ResourceManager.DataFactory.DataFactoryCollection GetDataFactories() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryResource> GetDataFactory(string factoryName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryResource>> GetDataFactoryAsync(string factoryName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableDataFactorySubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableDataFactorySubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryResource> ConfigureFactoryRepoInformation(Azure.Core.AzureLocation locationId, Azure.ResourceManager.DataFactory.Models.FactoryRepoContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryResource>> ConfigureFactoryRepoInformationAsync(Azure.Core.AzureLocation locationId, Azure.ResourceManager.DataFactory.Models.FactoryRepoContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataFactory.DataFactoryResource> GetDataFactories(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataFactory.DataFactoryResource> GetDataFactoriesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.Models.ExposureControlResult> GetFeatureValueExposureControl(Azure.Core.AzureLocation locationId, Azure.ResourceManager.DataFactory.Models.ExposureControlContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.Models.ExposureControlResult>> GetFeatureValueExposureControlAsync(Azure.Core.AzureLocation locationId, Azure.ResourceManager.DataFactory.Models.ExposureControlContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.DataFactory.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ActivityOnInactiveMarkAs : System.IEquatable<Azure.ResourceManager.DataFactory.Models.ActivityOnInactiveMarkAs>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ActivityOnInactiveMarkAs(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.ActivityOnInactiveMarkAs Failed { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.ActivityOnInactiveMarkAs Skipped { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.ActivityOnInactiveMarkAs Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.ActivityOnInactiveMarkAs other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.ActivityOnInactiveMarkAs left, Azure.ResourceManager.DataFactory.Models.ActivityOnInactiveMarkAs right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.ActivityOnInactiveMarkAs (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.ActivityOnInactiveMarkAs left, Azure.ResourceManager.DataFactory.Models.ActivityOnInactiveMarkAs right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AmazonMwsLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public AmazonMwsLinkedService(Azure.Core.Expressions.DataFactory.DataFactoryElement<string> endpoint, Azure.Core.Expressions.DataFactory.DataFactoryElement<string> marketplaceId, Azure.Core.Expressions.DataFactory.DataFactoryElement<string> sellerId, Azure.Core.Expressions.DataFactory.DataFactoryElement<string> accessKeyId) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> AccessKeyId { get { throw null; } set { } }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Endpoint { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> MarketplaceId { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition MwsAuthToken { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition SecretKey { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> SellerId { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> UseEncryptedEndpoints { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> UseHostVerification { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> UsePeerVerification { get { throw null; } set { } }
    }
    public partial class AmazonMwsObjectDataset : Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetProperties
    {
        public AmazonMwsObjectDataset(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName) : base (default(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference)) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> TableName { get { throw null; } set { } }
    }
    public partial class AmazonMwsSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public AmazonMwsSource() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Query { get { throw null; } set { } }
    }
    public partial class AmazonRdsForOracleLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public AmazonRdsForOracleLinkedService(Azure.Core.Expressions.DataFactory.DataFactoryElement<string> connectionString) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ConnectionString { get { throw null; } set { } }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition Password { get { throw null; } set { } }
    }
    public partial class AmazonRdsForOraclePartitionSettings
    {
        public AmazonRdsForOraclePartitionSettings() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> PartitionColumnName { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> PartitionLowerBound { get { throw null; } set { } }
        public System.BinaryData PartitionNames { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> PartitionUpperBound { get { throw null; } set { } }
    }
    public partial class AmazonRdsForOracleSource : Azure.ResourceManager.DataFactory.Models.CopyActivitySource
    {
        public AmazonRdsForOracleSource() { }
        public System.BinaryData AdditionalColumns { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> OracleReaderQuery { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> PartitionOption { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.AmazonRdsForOraclePartitionSettings PartitionSettings { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> QueryTimeout { get { throw null; } set { } }
    }
    public partial class AmazonRdsForOracleTableDataset : Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetProperties
    {
        public AmazonRdsForOracleTableDataset(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName) : base (default(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference)) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> SchemaTypePropertiesSchema { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Table { get { throw null; } set { } }
    }
    public partial class AmazonRdsForSqlServerLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public AmazonRdsForSqlServerLinkedService(Azure.Core.Expressions.DataFactory.DataFactoryElement<string> connectionString) { }
        public Azure.ResourceManager.DataFactory.Models.SqlAlwaysEncryptedProperties AlwaysEncryptedSettings { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ConnectionString { get { throw null; } set { } }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition Password { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> UserName { get { throw null; } set { } }
    }
    public partial class AmazonRdsForSqlServerSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public AmazonRdsForSqlServerSource() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> IsolationLevel { get { throw null; } set { } }
        public System.BinaryData PartitionOption { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SqlPartitionSettings PartitionSettings { get { throw null; } set { } }
        public System.BinaryData ProduceAdditionalTypes { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> SqlReaderQuery { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> SqlReaderStoredProcedureName { get { throw null; } set { } }
        public System.BinaryData StoredProcedureParameters { get { throw null; } set { } }
    }
    public partial class AmazonRdsForSqlServerTableDataset : Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetProperties
    {
        public AmazonRdsForSqlServerTableDataset(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName) : base (default(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference)) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> SchemaTypePropertiesSchema { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Table { get { throw null; } set { } }
    }
    public partial class AmazonRedshiftLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public AmazonRedshiftLinkedService(Azure.Core.Expressions.DataFactory.DataFactoryElement<string> server, Azure.Core.Expressions.DataFactory.DataFactoryElement<string> database) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Database { get { throw null; } set { } }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition Password { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<int> Port { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Server { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Username { get { throw null; } set { } }
    }
    public partial class AmazonRedshiftSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public AmazonRedshiftSource() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Query { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.RedshiftUnloadSettings RedshiftUnloadSettings { get { throw null; } set { } }
    }
    public partial class AmazonRedshiftTableDataset : Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetProperties
    {
        public AmazonRedshiftTableDataset(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName) : base (default(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference)) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> SchemaTypePropertiesSchema { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Table { get { throw null; } set { } }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class AmazonS3CompatibleLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public AmazonS3CompatibleLinkedService() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> AccessKeyId { get { throw null; } set { } }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> ForcePathStyle { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition SecretAccessKey { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ServiceUri { get { throw null; } set { } }
    }
    public partial class AmazonS3CompatibleLocation : Azure.ResourceManager.DataFactory.Models.DatasetLocation
    {
        public AmazonS3CompatibleLocation() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> BucketName { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Version { get { throw null; } set { } }
    }
    public partial class AmazonS3CompatibleReadSettings : Azure.ResourceManager.DataFactory.Models.StoreReadSettings
    {
        public AmazonS3CompatibleReadSettings() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> DeleteFilesAfterCompletion { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> EnablePartitionDiscovery { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> FileListPath { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ModifiedDatetimeEnd { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ModifiedDatetimeStart { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> PartitionRootPath { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Prefix { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> Recursive { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> WildcardFileName { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> WildcardFolderPath { get { throw null; } set { } }
    }
    public partial class AmazonS3Dataset : Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetProperties
    {
        public AmazonS3Dataset(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName, Azure.Core.Expressions.DataFactory.DataFactoryElement<string> bucketName) : base (default(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference)) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> BucketName { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DatasetCompression Compression { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DatasetStorageFormat Format { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Key { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ModifiedDatetimeEnd { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ModifiedDatetimeStart { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Prefix { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Version { get { throw null; } set { } }
    }
    public partial class AmazonS3LinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public AmazonS3LinkedService() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> AccessKeyId { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> AuthenticationType { get { throw null; } set { } }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition SecretAccessKey { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ServiceUri { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition SessionToken { get { throw null; } set { } }
    }
    public partial class AmazonS3Location : Azure.ResourceManager.DataFactory.Models.DatasetLocation
    {
        public AmazonS3Location() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> BucketName { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Version { get { throw null; } set { } }
    }
    public partial class AmazonS3ReadSettings : Azure.ResourceManager.DataFactory.Models.StoreReadSettings
    {
        public AmazonS3ReadSettings() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> DeleteFilesAfterCompletion { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> EnablePartitionDiscovery { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> FileListPath { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ModifiedDatetimeEnd { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ModifiedDatetimeStart { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> PartitionRootPath { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Prefix { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> Recursive { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> WildcardFileName { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> WildcardFolderPath { get { throw null; } set { } }
    }
    public partial class AppendVariableActivity : Azure.ResourceManager.DataFactory.Models.ControlActivity
    {
        public AppendVariableActivity(string name) : base (default(string)) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<System.BinaryData> Value { get { throw null; } set { } }
        public string VariableName { get { throw null; } set { } }
    }
    public partial class AppFiguresLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public AppFiguresLinkedService(Azure.Core.Expressions.DataFactory.DataFactoryElement<string> userName, Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition password, Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition clientKey) { }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition ClientKey { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition Password { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> UserName { get { throw null; } set { } }
    }
    public partial class AsanaLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public AsanaLinkedService(Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition apiToken) { }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition ApiToken { get { throw null; } set { } }
        public string EncryptedCredential { get { throw null; } set { } }
    }
    public partial class AvroDataset : Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetProperties
    {
        public AvroDataset(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName) : base (default(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference)) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> AvroCompressionCodec { get { throw null; } set { } }
        public int? AvroCompressionLevel { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DatasetLocation DataLocation { get { throw null; } set { } }
    }
    public partial class AvroSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public AvroSink() { }
        public Azure.ResourceManager.DataFactory.Models.AvroWriteSettings FormatSettings { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.StoreWriteSettings StoreSettings { get { throw null; } set { } }
    }
    public partial class AvroSource : Azure.ResourceManager.DataFactory.Models.CopyActivitySource
    {
        public AvroSource() { }
        public System.BinaryData AdditionalColumns { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.StoreReadSettings StoreSettings { get { throw null; } set { } }
    }
    public partial class AvroWriteSettings : Azure.ResourceManager.DataFactory.Models.FormatWriteSettings
    {
        public AvroWriteSettings() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> FileNamePrefix { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<int> MaxRowsPerFile { get { throw null; } set { } }
        public string RecordName { get { throw null; } set { } }
        public string RecordNamespace { get { throw null; } set { } }
    }
    public partial class AzPowerShellSetup : Azure.ResourceManager.DataFactory.Models.CustomSetupBase
    {
        public AzPowerShellSetup(string version) { }
        public string Version { get { throw null; } set { } }
    }
    public partial class AzureBatchLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public AzureBatchLinkedService(Azure.Core.Expressions.DataFactory.DataFactoryElement<string> accountName, Azure.Core.Expressions.DataFactory.DataFactoryElement<string> batchUri, Azure.Core.Expressions.DataFactory.DataFactoryElement<string> poolName, Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName) { }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition AccessKey { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> AccountName { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> BatchUri { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DataFactoryCredentialReference Credential { get { throw null; } set { } }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference LinkedServiceName { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> PoolName { get { throw null; } set { } }
    }
    public partial class AzureBlobDataset : Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetProperties
    {
        public AzureBlobDataset(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName) : base (default(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference)) { }
        public Azure.ResourceManager.DataFactory.Models.DatasetCompression Compression { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> FileName { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> FolderPath { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DatasetStorageFormat Format { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ModifiedDatetimeEnd { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ModifiedDatetimeStart { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> TableRootLocation { get { throw null; } set { } }
    }
    public partial class AzureBlobFSDataset : Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetProperties
    {
        public AzureBlobFSDataset(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName) : base (default(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference)) { }
        public Azure.ResourceManager.DataFactory.Models.DatasetCompression Compression { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> FileName { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> FolderPath { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DatasetStorageFormat Format { get { throw null; } set { } }
    }
    public partial class AzureBlobFSLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public AzureBlobFSLinkedService() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> AccountKey { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> AzureCloudType { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DataFactoryCredentialReference Credential { get { throw null; } set { } }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition SasToken { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> SasUri { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition ServicePrincipalCredential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ServicePrincipalCredentialType { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ServicePrincipalId { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition ServicePrincipalKey { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Tenant { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Uri { get { throw null; } set { } }
    }
    public partial class AzureBlobFSLocation : Azure.ResourceManager.DataFactory.Models.DatasetLocation
    {
        public AzureBlobFSLocation() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> FileSystem { get { throw null; } set { } }
    }
    public partial class AzureBlobFSReadSettings : Azure.ResourceManager.DataFactory.Models.StoreReadSettings
    {
        public AzureBlobFSReadSettings() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> DeleteFilesAfterCompletion { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> EnablePartitionDiscovery { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> FileListPath { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ModifiedDatetimeEnd { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ModifiedDatetimeStart { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> PartitionRootPath { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> Recursive { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> WildcardFileName { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> WildcardFolderPath { get { throw null; } set { } }
    }
    public partial class AzureBlobFSSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public AzureBlobFSSink() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> CopyBehavior { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.DataFactoryMetadataItemInfo> Metadata { get { throw null; } }
    }
    public partial class AzureBlobFSSource : Azure.ResourceManager.DataFactory.Models.CopyActivitySource
    {
        public AzureBlobFSSource() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> Recursive { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<int> SkipHeaderLineCount { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> TreatEmptyAsNull { get { throw null; } set { } }
    }
    public partial class AzureBlobFSWriteSettings : Azure.ResourceManager.DataFactory.Models.StoreWriteSettings
    {
        public AzureBlobFSWriteSettings() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<int> BlockSizeInMB { get { throw null; } set { } }
    }
    public partial class AzureBlobStorageLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public AzureBlobStorageLinkedService() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryKeyVaultSecretReference AccountKey { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> AccountKind { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.AzureStorageAuthenticationType? AuthenticationType { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> AzureCloudType { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ConnectionString { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ContainerUri { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DataFactoryCredentialReference Credential { get { throw null; } set { } }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryKeyVaultSecretReference SasToken { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> SasUri { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ServiceEndpoint { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ServicePrincipalId { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition ServicePrincipalKey { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Tenant { get { throw null; } set { } }
    }
    public partial class AzureBlobStorageLocation : Azure.ResourceManager.DataFactory.Models.DatasetLocation
    {
        public AzureBlobStorageLocation() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Container { get { throw null; } set { } }
    }
    public partial class AzureBlobStorageReadSettings : Azure.ResourceManager.DataFactory.Models.StoreReadSettings
    {
        public AzureBlobStorageReadSettings() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> DeleteFilesAfterCompletion { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> EnablePartitionDiscovery { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> FileListPath { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ModifiedDatetimeEnd { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ModifiedDatetimeStart { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> PartitionRootPath { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Prefix { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> Recursive { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> WildcardFileName { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> WildcardFolderPath { get { throw null; } set { } }
    }
    public partial class AzureBlobStorageWriteSettings : Azure.ResourceManager.DataFactory.Models.StoreWriteSettings
    {
        public AzureBlobStorageWriteSettings() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<int> BlockSizeInMB { get { throw null; } set { } }
    }
    public partial class AzureDatabricksDeltaLakeDataset : Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetProperties
    {
        public AzureDatabricksDeltaLakeDataset(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName) : base (default(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference)) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Database { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Table { get { throw null; } set { } }
    }
    public partial class AzureDatabricksDeltaLakeExportCommand : Azure.ResourceManager.DataFactory.Models.ExportSettings
    {
        public AzureDatabricksDeltaLakeExportCommand() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> DateFormat { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> TimestampFormat { get { throw null; } set { } }
    }
    public partial class AzureDatabricksDeltaLakeImportCommand : Azure.ResourceManager.DataFactory.Models.ImportSettings
    {
        public AzureDatabricksDeltaLakeImportCommand() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> DateFormat { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> TimestampFormat { get { throw null; } set { } }
    }
    public partial class AzureDatabricksDeltaLakeLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public AzureDatabricksDeltaLakeLinkedService(Azure.Core.Expressions.DataFactory.DataFactoryElement<string> domain) { }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition AccessToken { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ClusterId { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DataFactoryCredentialReference Credential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Domain { get { throw null; } set { } }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> WorkspaceResourceId { get { throw null; } set { } }
    }
    public partial class AzureDatabricksDeltaLakeSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public AzureDatabricksDeltaLakeSink() { }
        public Azure.ResourceManager.DataFactory.Models.AzureDatabricksDeltaLakeImportCommand ImportSettings { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> PreCopyScript { get { throw null; } set { } }
    }
    public partial class AzureDatabricksDeltaLakeSource : Azure.ResourceManager.DataFactory.Models.CopyActivitySource
    {
        public AzureDatabricksDeltaLakeSource() { }
        public Azure.ResourceManager.DataFactory.Models.AzureDatabricksDeltaLakeExportCommand ExportSettings { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Query { get { throw null; } set { } }
    }
    public partial class AzureDatabricksLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public AzureDatabricksLinkedService(Azure.Core.Expressions.DataFactory.DataFactoryElement<string> domain) { }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition AccessToken { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Authentication { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DataFactoryCredentialReference Credential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Domain { get { throw null; } set { } }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ExistingClusterId { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> InstancePoolId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> NewClusterCustomTags { get { throw null; } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> NewClusterDriverNodeType { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> NewClusterEnableElasticDisk { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<System.Collections.Generic.IList<string>> NewClusterInitScripts { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> NewClusterLogDestination { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> NewClusterNodeType { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> NewClusterNumOfWorker { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> NewClusterSparkConf { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> NewClusterSparkEnvVars { get { throw null; } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> NewClusterVersion { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> PolicyId { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> WorkspaceResourceId { get { throw null; } set { } }
    }
    public partial class AzureDataExplorerCommandActivity : Azure.ResourceManager.DataFactory.Models.ExecutionActivity
    {
        public AzureDataExplorerCommandActivity(string name, Azure.Core.Expressions.DataFactory.DataFactoryElement<string> command) : base (default(string)) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Command { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> CommandTimeout { get { throw null; } set { } }
    }
    public partial class AzureDataExplorerLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public AzureDataExplorerLinkedService(Azure.Core.Expressions.DataFactory.DataFactoryElement<string> endpoint, Azure.Core.Expressions.DataFactory.DataFactoryElement<string> database) { }
        public Azure.ResourceManager.DataFactory.Models.DataFactoryCredentialReference Credential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Database { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Endpoint { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ServicePrincipalId { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition ServicePrincipalKey { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Tenant { get { throw null; } set { } }
    }
    public partial class AzureDataExplorerSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public AzureDataExplorerSink() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> FlushImmediately { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> IngestionMappingAsJson { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> IngestionMappingName { get { throw null; } set { } }
    }
    public partial class AzureDataExplorerSource : Azure.ResourceManager.DataFactory.Models.CopyActivitySource
    {
        public AzureDataExplorerSource(Azure.Core.Expressions.DataFactory.DataFactoryElement<string> query) { }
        public System.BinaryData AdditionalColumns { get { throw null; } set { } }
        public System.BinaryData NoTruncation { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Query { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> QueryTimeout { get { throw null; } set { } }
    }
    public partial class AzureDataExplorerTableDataset : Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetProperties
    {
        public AzureDataExplorerTableDataset(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName) : base (default(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference)) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Table { get { throw null; } set { } }
    }
    public partial class AzureDataLakeAnalyticsLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public AzureDataLakeAnalyticsLinkedService(Azure.Core.Expressions.DataFactory.DataFactoryElement<string> accountName, Azure.Core.Expressions.DataFactory.DataFactoryElement<string> tenant) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> AccountName { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> DataLakeAnalyticsUri { get { throw null; } set { } }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ResourceGroupName { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ServicePrincipalId { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition ServicePrincipalKey { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> SubscriptionId { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Tenant { get { throw null; } set { } }
    }
    public partial class AzureDataLakeStoreDataset : Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetProperties
    {
        public AzureDataLakeStoreDataset(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName) : base (default(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference)) { }
        public Azure.ResourceManager.DataFactory.Models.DatasetCompression Compression { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> FileName { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> FolderPath { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DatasetStorageFormat Format { get { throw null; } set { } }
    }
    public partial class AzureDataLakeStoreLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public AzureDataLakeStoreLinkedService(Azure.Core.Expressions.DataFactory.DataFactoryElement<string> dataLakeStoreUri) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> AccountName { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> AzureCloudType { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DataFactoryCredentialReference Credential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> DataLakeStoreUri { get { throw null; } set { } }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ResourceGroupName { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ServicePrincipalId { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition ServicePrincipalKey { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> SubscriptionId { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Tenant { get { throw null; } set { } }
    }
    public partial class AzureDataLakeStoreLocation : Azure.ResourceManager.DataFactory.Models.DatasetLocation
    {
        public AzureDataLakeStoreLocation() { }
    }
    public partial class AzureDataLakeStoreReadSettings : Azure.ResourceManager.DataFactory.Models.StoreReadSettings
    {
        public AzureDataLakeStoreReadSettings() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> DeleteFilesAfterCompletion { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> EnablePartitionDiscovery { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> FileListPath { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ListAfter { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ListBefore { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ModifiedDatetimeEnd { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ModifiedDatetimeStart { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> PartitionRootPath { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> Recursive { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> WildcardFileName { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> WildcardFolderPath { get { throw null; } set { } }
    }
    public partial class AzureDataLakeStoreSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public AzureDataLakeStoreSink() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> CopyBehavior { get { throw null; } set { } }
        public System.BinaryData EnableAdlsSingleFileParallel { get { throw null; } set { } }
    }
    public partial class AzureDataLakeStoreSource : Azure.ResourceManager.DataFactory.Models.CopyActivitySource
    {
        public AzureDataLakeStoreSource() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> Recursive { get { throw null; } set { } }
    }
    public partial class AzureDataLakeStoreWriteSettings : Azure.ResourceManager.DataFactory.Models.StoreWriteSettings
    {
        public AzureDataLakeStoreWriteSettings() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ExpiryDateTime { get { throw null; } set { } }
    }
    public partial class AzureFileStorageLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public AzureFileStorageLinkedService() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryKeyVaultSecretReference AccountKey { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ConnectionString { get { throw null; } set { } }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> FileShare { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Host { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition Password { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryKeyVaultSecretReference SasToken { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> SasUri { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Snapshot { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> UserId { get { throw null; } set { } }
    }
    public partial class AzureFileStorageLocation : Azure.ResourceManager.DataFactory.Models.DatasetLocation
    {
        public AzureFileStorageLocation() { }
    }
    public partial class AzureFileStorageReadSettings : Azure.ResourceManager.DataFactory.Models.StoreReadSettings
    {
        public AzureFileStorageReadSettings() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> DeleteFilesAfterCompletion { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> EnablePartitionDiscovery { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> FileListPath { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ModifiedDatetimeEnd { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ModifiedDatetimeStart { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> PartitionRootPath { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Prefix { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> Recursive { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> WildcardFileName { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> WildcardFolderPath { get { throw null; } set { } }
    }
    public partial class AzureFileStorageWriteSettings : Azure.ResourceManager.DataFactory.Models.StoreWriteSettings
    {
        public AzureFileStorageWriteSettings() { }
    }
    public partial class AzureFunctionActivity : Azure.ResourceManager.DataFactory.Models.ExecutionActivity
    {
        public AzureFunctionActivity(string name, Azure.ResourceManager.DataFactory.Models.AzureFunctionActivityMethod method, Azure.Core.Expressions.DataFactory.DataFactoryElement<string> functionName) : base (default(string)) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Body { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> FunctionName { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Headers { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.AzureFunctionActivityMethod Method { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureFunctionActivityMethod : System.IEquatable<Azure.ResourceManager.DataFactory.Models.AzureFunctionActivityMethod>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureFunctionActivityMethod(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.AzureFunctionActivityMethod Delete { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.AzureFunctionActivityMethod Get { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.AzureFunctionActivityMethod Head { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.AzureFunctionActivityMethod Options { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.AzureFunctionActivityMethod Post { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.AzureFunctionActivityMethod Put { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.AzureFunctionActivityMethod Trace { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.AzureFunctionActivityMethod other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.AzureFunctionActivityMethod left, Azure.ResourceManager.DataFactory.Models.AzureFunctionActivityMethod right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.AzureFunctionActivityMethod (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.AzureFunctionActivityMethod left, Azure.ResourceManager.DataFactory.Models.AzureFunctionActivityMethod right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AzureFunctionLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public AzureFunctionLinkedService(System.BinaryData functionAppUri) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Authentication { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DataFactoryCredentialReference Credential { get { throw null; } set { } }
        public string EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData FunctionAppUri { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition FunctionKey { get { throw null; } set { } }
        public System.BinaryData ResourceId { get { throw null; } set { } }
    }
    public partial class AzureKeyVaultLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public AzureKeyVaultLinkedService(Azure.Core.Expressions.DataFactory.DataFactoryElement<string> baseUri) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> BaseUri { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DataFactoryCredentialReference Credential { get { throw null; } set { } }
    }
    public partial class AzureMariaDBLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public AzureMariaDBLinkedService() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ConnectionString { get { throw null; } set { } }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryKeyVaultSecretReference Password { get { throw null; } set { } }
    }
    public partial class AzureMariaDBSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public AzureMariaDBSource() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Query { get { throw null; } set { } }
    }
    public partial class AzureMariaDBTableDataset : Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetProperties
    {
        public AzureMariaDBTableDataset(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName) : base (default(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference)) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> TableName { get { throw null; } set { } }
    }
    public partial class AzureMLBatchExecutionActivity : Azure.ResourceManager.DataFactory.Models.ExecutionActivity
    {
        public AzureMLBatchExecutionActivity(string name) : base (default(string)) { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> GlobalParameters { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DataFactory.Models.AzureMLWebServiceFile> WebServiceInputs { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DataFactory.Models.AzureMLWebServiceFile> WebServiceOutputs { get { throw null; } }
    }
    public partial class AzureMLExecutePipelineActivity : Azure.ResourceManager.DataFactory.Models.ExecutionActivity
    {
        public AzureMLExecutePipelineActivity(string name) : base (default(string)) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> ContinueOnStepFailure { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<System.Collections.Generic.IDictionary<string, string>> DataPathAssignments { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ExperimentName { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> MLParentRunId { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> MLPipelineEndpointId { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> MLPipelineId { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<System.Collections.Generic.IDictionary<string, string>> MLPipelineParameters { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Version { get { throw null; } set { } }
    }
    public partial class AzureMLLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public AzureMLLinkedService(Azure.Core.Expressions.DataFactory.DataFactoryElement<string> mlEndpoint, Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition apiKey) { }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition ApiKey { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Authentication { get { throw null; } set { } }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> MLEndpoint { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ServicePrincipalId { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition ServicePrincipalKey { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Tenant { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> UpdateResourceEndpoint { get { throw null; } set { } }
    }
    public partial class AzureMLServiceLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public AzureMLServiceLinkedService(Azure.Core.Expressions.DataFactory.DataFactoryElement<string> subscriptionId, Azure.Core.Expressions.DataFactory.DataFactoryElement<string> resourceGroupName, Azure.Core.Expressions.DataFactory.DataFactoryElement<string> mlWorkspaceName) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Authentication { get { throw null; } set { } }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> MLWorkspaceName { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ResourceGroupName { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ServicePrincipalId { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition ServicePrincipalKey { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> SubscriptionId { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Tenant { get { throw null; } set { } }
    }
    public partial class AzureMLUpdateResourceActivity : Azure.ResourceManager.DataFactory.Models.ExecutionActivity
    {
        public AzureMLUpdateResourceActivity(string name, Azure.Core.Expressions.DataFactory.DataFactoryElement<string> trainedModelName, Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference trainedModelLinkedServiceName, Azure.Core.Expressions.DataFactory.DataFactoryElement<string> trainedModelFilePath) : base (default(string)) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> TrainedModelFilePath { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference TrainedModelLinkedServiceName { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> TrainedModelName { get { throw null; } set { } }
    }
    public partial class AzureMLWebServiceFile
    {
        public AzureMLWebServiceFile(Azure.Core.Expressions.DataFactory.DataFactoryElement<string> filePath, Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> FilePath { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference LinkedServiceName { get { throw null; } set { } }
    }
    public partial class AzureMySqlLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public AzureMySqlLinkedService(Azure.Core.Expressions.DataFactory.DataFactoryElement<string> connectionString) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ConnectionString { get { throw null; } set { } }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryKeyVaultSecretReference Password { get { throw null; } set { } }
    }
    public partial class AzureMySqlSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public AzureMySqlSink() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> PreCopyScript { get { throw null; } set { } }
    }
    public partial class AzureMySqlSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public AzureMySqlSource() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Query { get { throw null; } set { } }
    }
    public partial class AzureMySqlTableDataset : Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetProperties
    {
        public AzureMySqlTableDataset(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName) : base (default(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference)) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Table { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> TableName { get { throw null; } set { } }
    }
    public partial class AzurePostgreSqlLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public AzurePostgreSqlLinkedService() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ConnectionString { get { throw null; } set { } }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryKeyVaultSecretReference Password { get { throw null; } set { } }
    }
    public partial class AzurePostgreSqlSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public AzurePostgreSqlSink() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> PreCopyScript { get { throw null; } set { } }
    }
    public partial class AzurePostgreSqlSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public AzurePostgreSqlSource() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Query { get { throw null; } set { } }
    }
    public partial class AzurePostgreSqlTableDataset : Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetProperties
    {
        public AzurePostgreSqlTableDataset(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName) : base (default(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference)) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> SchemaTypePropertiesSchema { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Table { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> TableName { get { throw null; } set { } }
    }
    public partial class AzureQueueSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public AzureQueueSink() { }
    }
    public partial class AzureSearchIndexDataset : Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetProperties
    {
        public AzureSearchIndexDataset(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName, Azure.Core.Expressions.DataFactory.DataFactoryElement<string> indexName) : base (default(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference)) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> IndexName { get { throw null; } set { } }
    }
    public partial class AzureSearchIndexSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public AzureSearchIndexSink() { }
        public Azure.ResourceManager.DataFactory.Models.AzureSearchIndexWriteBehaviorType? WriteBehavior { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureSearchIndexWriteBehaviorType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.AzureSearchIndexWriteBehaviorType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureSearchIndexWriteBehaviorType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.AzureSearchIndexWriteBehaviorType Merge { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.AzureSearchIndexWriteBehaviorType Upload { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.AzureSearchIndexWriteBehaviorType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.AzureSearchIndexWriteBehaviorType left, Azure.ResourceManager.DataFactory.Models.AzureSearchIndexWriteBehaviorType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.AzureSearchIndexWriteBehaviorType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.AzureSearchIndexWriteBehaviorType left, Azure.ResourceManager.DataFactory.Models.AzureSearchIndexWriteBehaviorType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AzureSearchLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public AzureSearchLinkedService(Azure.Core.Expressions.DataFactory.DataFactoryElement<string> uri) { }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition Key { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Uri { get { throw null; } set { } }
    }
    public partial class AzureSqlDatabaseLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public AzureSqlDatabaseLinkedService(Azure.Core.Expressions.DataFactory.DataFactoryElement<string> connectionString) { }
        public Azure.ResourceManager.DataFactory.Models.SqlAlwaysEncryptedProperties AlwaysEncryptedSettings { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> AzureCloudType { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ConnectionString { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DataFactoryCredentialReference Credential { get { throw null; } set { } }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryKeyVaultSecretReference Password { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ServicePrincipalId { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition ServicePrincipalKey { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Tenant { get { throw null; } set { } }
    }
    public partial class AzureSqlDWLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public AzureSqlDWLinkedService(Azure.Core.Expressions.DataFactory.DataFactoryElement<string> connectionString) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> AzureCloudType { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ConnectionString { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DataFactoryCredentialReference Credential { get { throw null; } set { } }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryKeyVaultSecretReference Password { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ServicePrincipalId { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition ServicePrincipalKey { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Tenant { get { throw null; } set { } }
    }
    public partial class AzureSqlDWTableDataset : Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetProperties
    {
        public AzureSqlDWTableDataset(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName) : base (default(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference)) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> SchemaTypePropertiesSchema { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Table { get { throw null; } set { } }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class AzureSqlMILinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public AzureSqlMILinkedService(Azure.Core.Expressions.DataFactory.DataFactoryElement<string> connectionString) { }
        public Azure.ResourceManager.DataFactory.Models.SqlAlwaysEncryptedProperties AlwaysEncryptedSettings { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> AzureCloudType { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ConnectionString { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DataFactoryCredentialReference Credential { get { throw null; } set { } }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryKeyVaultSecretReference Password { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ServicePrincipalId { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition ServicePrincipalKey { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Tenant { get { throw null; } set { } }
    }
    public partial class AzureSqlMITableDataset : Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetProperties
    {
        public AzureSqlMITableDataset(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName) : base (default(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference)) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> SchemaTypePropertiesSchema { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Table { get { throw null; } set { } }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class AzureSqlSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public AzureSqlSink() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> PreCopyScript { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> SqlWriterStoredProcedureName { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> SqlWriterTableType { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> SqlWriterUseTableLock { get { throw null; } set { } }
        public System.BinaryData StoredProcedureParameters { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> StoredProcedureTableTypeParameterName { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> TableOption { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SqlUpsertSettings UpsertSettings { get { throw null; } set { } }
        public System.BinaryData WriteBehavior { get { throw null; } set { } }
    }
    public partial class AzureSqlSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public AzureSqlSource() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> IsolationLevel { get { throw null; } set { } }
        public System.BinaryData PartitionOption { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SqlPartitionSettings PartitionSettings { get { throw null; } set { } }
        public System.BinaryData ProduceAdditionalTypes { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> SqlReaderQuery { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> SqlReaderStoredProcedureName { get { throw null; } set { } }
        public System.BinaryData StoredProcedureParameters { get { throw null; } set { } }
    }
    public partial class AzureSqlTableDataset : Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetProperties
    {
        public AzureSqlTableDataset(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName) : base (default(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference)) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> SchemaTypePropertiesSchema { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Table { get { throw null; } set { } }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureStorageAuthenticationType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.AzureStorageAuthenticationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureStorageAuthenticationType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.AzureStorageAuthenticationType AccountKey { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.AzureStorageAuthenticationType Anonymous { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.AzureStorageAuthenticationType Msi { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.AzureStorageAuthenticationType SasUri { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.AzureStorageAuthenticationType ServicePrincipal { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.AzureStorageAuthenticationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.AzureStorageAuthenticationType left, Azure.ResourceManager.DataFactory.Models.AzureStorageAuthenticationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.AzureStorageAuthenticationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.AzureStorageAuthenticationType left, Azure.ResourceManager.DataFactory.Models.AzureStorageAuthenticationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AzureStorageLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public AzureStorageLinkedService() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryKeyVaultSecretReference AccountKey { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ConnectionString { get { throw null; } set { } }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryKeyVaultSecretReference SasToken { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> SasUri { get { throw null; } set { } }
    }
    public partial class AzureSynapseArtifactsLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public AzureSynapseArtifactsLinkedService(Azure.Core.Expressions.DataFactory.DataFactoryElement<string> endpoint) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Authentication { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Endpoint { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> WorkspaceResourceId { get { throw null; } set { } }
    }
    public partial class AzureTableDataset : Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetProperties
    {
        public AzureTableDataset(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName, Azure.Core.Expressions.DataFactory.DataFactoryElement<string> tableName) : base (default(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference)) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> TableName { get { throw null; } set { } }
    }
    public partial class AzureTableSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public AzureTableSink() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> AzureTableDefaultPartitionKeyValue { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> AzureTableInsertType { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> AzureTablePartitionKeyName { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> AzureTableRowKeyName { get { throw null; } set { } }
    }
    public partial class AzureTableSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public AzureTableSource() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> AzureTableSourceIgnoreTableNotFound { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> AzureTableSourceQuery { get { throw null; } set { } }
    }
    public partial class AzureTableStorageLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public AzureTableStorageLinkedService() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryKeyVaultSecretReference AccountKey { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ConnectionString { get { throw null; } set { } }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryKeyVaultSecretReference SasToken { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> SasUri { get { throw null; } set { } }
    }
    public partial class BigDataPoolParametrizationReference
    {
        public BigDataPoolParametrizationReference(Azure.ResourceManager.DataFactory.Models.BigDataPoolReferenceType referenceType, Azure.Core.Expressions.DataFactory.DataFactoryElement<string> referenceName) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ReferenceName { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.BigDataPoolReferenceType ReferenceType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BigDataPoolReferenceType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.BigDataPoolReferenceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BigDataPoolReferenceType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.BigDataPoolReferenceType BigDataPoolReference { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.BigDataPoolReferenceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.BigDataPoolReferenceType left, Azure.ResourceManager.DataFactory.Models.BigDataPoolReferenceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.BigDataPoolReferenceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.BigDataPoolReferenceType left, Azure.ResourceManager.DataFactory.Models.BigDataPoolReferenceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BinaryDataset : Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetProperties
    {
        public BinaryDataset(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName) : base (default(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference)) { }
        public Azure.ResourceManager.DataFactory.Models.DatasetCompression Compression { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DatasetLocation DataLocation { get { throw null; } set { } }
    }
    public partial class BinaryReadSettings : Azure.ResourceManager.DataFactory.Models.FormatReadSettings
    {
        public BinaryReadSettings() { }
        public Azure.ResourceManager.DataFactory.Models.CompressionReadSettings CompressionProperties { get { throw null; } set { } }
    }
    public partial class BinarySink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public BinarySink() { }
        public Azure.ResourceManager.DataFactory.Models.StoreWriteSettings StoreSettings { get { throw null; } set { } }
    }
    public partial class BinarySource : Azure.ResourceManager.DataFactory.Models.CopyActivitySource
    {
        public BinarySource() { }
        public Azure.ResourceManager.DataFactory.Models.BinaryReadSettings FormatSettings { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.StoreReadSettings StoreSettings { get { throw null; } set { } }
    }
    public partial class CassandraLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public CassandraLinkedService(Azure.Core.Expressions.DataFactory.DataFactoryElement<string> host) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> AuthenticationType { get { throw null; } set { } }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Host { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition Password { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<int> Port { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Username { get { throw null; } set { } }
    }
    public partial class CassandraSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public CassandraSource() { }
        public Azure.ResourceManager.DataFactory.Models.CassandraSourceReadConsistencyLevel? ConsistencyLevel { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Query { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CassandraSourceReadConsistencyLevel : System.IEquatable<Azure.ResourceManager.DataFactory.Models.CassandraSourceReadConsistencyLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CassandraSourceReadConsistencyLevel(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.CassandraSourceReadConsistencyLevel All { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.CassandraSourceReadConsistencyLevel EachQuorum { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.CassandraSourceReadConsistencyLevel LocalOne { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.CassandraSourceReadConsistencyLevel LocalQuorum { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.CassandraSourceReadConsistencyLevel LocalSerial { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.CassandraSourceReadConsistencyLevel One { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.CassandraSourceReadConsistencyLevel Quorum { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.CassandraSourceReadConsistencyLevel Serial { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.CassandraSourceReadConsistencyLevel Three { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.CassandraSourceReadConsistencyLevel Two { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.CassandraSourceReadConsistencyLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.CassandraSourceReadConsistencyLevel left, Azure.ResourceManager.DataFactory.Models.CassandraSourceReadConsistencyLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.CassandraSourceReadConsistencyLevel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.CassandraSourceReadConsistencyLevel left, Azure.ResourceManager.DataFactory.Models.CassandraSourceReadConsistencyLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CassandraTableDataset : Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetProperties
    {
        public CassandraTableDataset(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName) : base (default(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference)) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Keyspace { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> TableName { get { throw null; } set { } }
    }
    public partial class ChainingTrigger : Azure.ResourceManager.DataFactory.Models.DataFactoryTriggerProperties
    {
        public ChainingTrigger(Azure.ResourceManager.DataFactory.Models.TriggerPipelineReference pipeline, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataFactory.Models.DataFactoryPipelineReference> dependsOn, string runDimension) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.DataFactoryPipelineReference> DependsOn { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.TriggerPipelineReference Pipeline { get { throw null; } set { } }
        public string RunDimension { get { throw null; } set { } }
    }
    public partial class CmdkeySetup : Azure.ResourceManager.DataFactory.Models.CustomSetupBase
    {
        public CmdkeySetup(System.BinaryData targetName, System.BinaryData userName, Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition password) { }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition Password { get { throw null; } set { } }
        public System.BinaryData TargetName { get { throw null; } set { } }
        public System.BinaryData UserName { get { throw null; } set { } }
    }
    public partial class CommonDataServiceForAppsEntityDataset : Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetProperties
    {
        public CommonDataServiceForAppsEntityDataset(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName) : base (default(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference)) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> EntityName { get { throw null; } set { } }
    }
    public partial class CommonDataServiceForAppsLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public CommonDataServiceForAppsLinkedService(Azure.Core.Expressions.DataFactory.DataFactoryElement<string> deploymentType, Azure.Core.Expressions.DataFactory.DataFactoryElement<string> authenticationType) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> AuthenticationType { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> DeploymentType { get { throw null; } set { } }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> HostName { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> OrganizationName { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition Password { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<int> Port { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition ServicePrincipalCredential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ServicePrincipalCredentialType { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ServicePrincipalId { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ServiceUri { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Username { get { throw null; } set { } }
    }
    public partial class CommonDataServiceForAppsSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public CommonDataServiceForAppsSink(Azure.ResourceManager.DataFactory.Models.DynamicsSinkWriteBehavior writeBehavior) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> AlternateKeyName { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> IgnoreNullValues { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DynamicsSinkWriteBehavior WriteBehavior { get { throw null; } set { } }
    }
    public partial class CommonDataServiceForAppsSource : Azure.ResourceManager.DataFactory.Models.CopyActivitySource
    {
        public CommonDataServiceForAppsSource() { }
        public System.BinaryData AdditionalColumns { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Query { get { throw null; } set { } }
    }
    public partial class ComponentSetup : Azure.ResourceManager.DataFactory.Models.CustomSetupBase
    {
        public ComponentSetup(string componentName) { }
        public string ComponentName { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition LicenseKey { get { throw null; } set { } }
    }
    public partial class CompressionReadSettings
    {
        public CompressionReadSettings() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
    }
    public partial class ConcurLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public ConcurLinkedService(Azure.Core.Expressions.DataFactory.DataFactoryElement<string> clientId, Azure.Core.Expressions.DataFactory.DataFactoryElement<string> username) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ClientId { get { throw null; } set { } }
        public System.BinaryData ConnectionProperties { get { throw null; } set { } }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition Password { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> UseEncryptedEndpoints { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> UseHostVerification { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> UsePeerVerification { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Username { get { throw null; } set { } }
    }
    public partial class ConcurObjectDataset : Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetProperties
    {
        public ConcurObjectDataset(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName) : base (default(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference)) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> TableName { get { throw null; } set { } }
    }
    public partial class ConcurSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public ConcurSource() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Query { get { throw null; } set { } }
    }
    public partial class ConnectionStateProperties
    {
        public ConnectionStateProperties() { }
        public string ActionsRequired { get { throw null; } }
        public string Description { get { throw null; } }
        public string Status { get { throw null; } }
    }
    public partial class ControlActivity : Azure.ResourceManager.DataFactory.Models.PipelineActivity
    {
        public ControlActivity(string name) : base (default(string)) { }
    }
    public partial class CopyActivity : Azure.ResourceManager.DataFactory.Models.ExecutionActivity
    {
        public CopyActivity(string name, Azure.ResourceManager.DataFactory.Models.CopyActivitySource source, Azure.ResourceManager.DataFactory.Models.CopySink sink) : base (default(string)) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<int> DataIntegrationUnits { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> EnableSkipIncompatibleRow { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> EnableStaging { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.DatasetReference> Inputs { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.DataFactoryLogSettings LogSettings { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.LogStorageSettings LogStorageSettings { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.DatasetReference> Outputs { get { throw null; } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<int> ParallelCopies { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.BinaryData> Preserve { get { throw null; } }
        public System.Collections.Generic.IList<System.BinaryData> PreserveRules { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.RedirectIncompatibleRowSettings RedirectIncompatibleRowSettings { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.CopySink Sink { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SkipErrorFile SkipErrorFile { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.CopyActivitySource Source { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.StagingSettings StagingSettings { get { throw null; } set { } }
        public System.BinaryData Translator { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> ValidateDataConsistency { get { throw null; } set { } }
    }
    public partial class CopyActivityLogSettings
    {
        public CopyActivityLogSettings() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> EnableReliableLogging { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> LogLevel { get { throw null; } set { } }
    }
    public partial class CopyActivitySource
    {
        public CopyActivitySource() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> DisableMetricsCollection { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<int> MaxConcurrentConnections { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<int> SourceRetryCount { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> SourceRetryWait { get { throw null; } set { } }
    }
    public partial class CopyComputeScaleProperties
    {
        public CopyComputeScaleProperties() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public int? DataIntegrationUnit { get { throw null; } set { } }
        public int? TimeToLive { get { throw null; } set { } }
    }
    public partial class CopySink
    {
        public CopySink() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> DisableMetricsCollection { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<int> MaxConcurrentConnections { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<int> SinkRetryCount { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> SinkRetryWait { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<int> WriteBatchSize { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> WriteBatchTimeout { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CosmosDBConnectionMode : System.IEquatable<Azure.ResourceManager.DataFactory.Models.CosmosDBConnectionMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CosmosDBConnectionMode(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.CosmosDBConnectionMode Direct { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.CosmosDBConnectionMode Gateway { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.CosmosDBConnectionMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.CosmosDBConnectionMode left, Azure.ResourceManager.DataFactory.Models.CosmosDBConnectionMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.CosmosDBConnectionMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.CosmosDBConnectionMode left, Azure.ResourceManager.DataFactory.Models.CosmosDBConnectionMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CosmosDBLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public CosmosDBLinkedService() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> AccountEndpoint { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition AccountKey { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> AzureCloudType { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.CosmosDBConnectionMode? ConnectionMode { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ConnectionString { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DataFactoryCredentialReference Credential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Database { get { throw null; } set { } }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition ServicePrincipalCredential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ServicePrincipalCredentialType { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ServicePrincipalId { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Tenant { get { throw null; } set { } }
    }
    public partial class CosmosDBMongoDBApiCollectionDataset : Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetProperties
    {
        public CosmosDBMongoDBApiCollectionDataset(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName, Azure.Core.Expressions.DataFactory.DataFactoryElement<string> collection) : base (default(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference)) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Collection { get { throw null; } set { } }
    }
    public partial class CosmosDBMongoDBApiLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public CosmosDBMongoDBApiLinkedService(Azure.Core.Expressions.DataFactory.DataFactoryElement<string> connectionString, Azure.Core.Expressions.DataFactory.DataFactoryElement<string> database) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ConnectionString { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Database { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> IsServerVersionAbove32 { get { throw null; } set { } }
    }
    public partial class CosmosDBMongoDBApiSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public CosmosDBMongoDBApiSink() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> WriteBehavior { get { throw null; } set { } }
    }
    public partial class CosmosDBMongoDBApiSource : Azure.ResourceManager.DataFactory.Models.CopyActivitySource
    {
        public CosmosDBMongoDBApiSource() { }
        public System.BinaryData AdditionalColumns { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<int> BatchSize { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.MongoDBCursorMethodsProperties CursorMethods { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Filter { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> QueryTimeout { get { throw null; } set { } }
    }
    public partial class CosmosDBSqlApiCollectionDataset : Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetProperties
    {
        public CosmosDBSqlApiCollectionDataset(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName, Azure.Core.Expressions.DataFactory.DataFactoryElement<string> collectionName) : base (default(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference)) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> CollectionName { get { throw null; } set { } }
    }
    public partial class CosmosDBSqlApiSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public CosmosDBSqlApiSink() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> WriteBehavior { get { throw null; } set { } }
    }
    public partial class CosmosDBSqlApiSource : Azure.ResourceManager.DataFactory.Models.CopyActivitySource
    {
        public CosmosDBSqlApiSource() { }
        public System.BinaryData AdditionalColumns { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> DetectDatetime { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<int> PageSize { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<System.Collections.Generic.IList<string>> PreferredRegions { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Query { get { throw null; } set { } }
    }
    public partial class CouchbaseLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public CouchbaseLinkedService() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ConnectionString { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryKeyVaultSecretReference CredString { get { throw null; } set { } }
        public string EncryptedCredential { get { throw null; } set { } }
    }
    public partial class CouchbaseSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public CouchbaseSource() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Query { get { throw null; } set { } }
    }
    public partial class CouchbaseTableDataset : Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetProperties
    {
        public CouchbaseTableDataset(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName) : base (default(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference)) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> TableName { get { throw null; } set { } }
    }
    public partial class CreateLinkedIntegrationRuntimeContent
    {
        public CreateLinkedIntegrationRuntimeContent() { }
        public Azure.Core.AzureLocation? DataFactoryLocation { get { throw null; } set { } }
        public string DataFactoryName { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
    }
    public partial class CustomActivity : Azure.ResourceManager.DataFactory.Models.ExecutionActivity
    {
        public CustomActivity(string name, Azure.Core.Expressions.DataFactory.DataFactoryElement<string> command) : base (default(string)) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> AutoUserSpecification { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Command { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> ExtendedProperties { get { throw null; } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> FolderPath { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.CustomActivityReferenceObject ReferenceObjects { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference ResourceLinkedService { get { throw null; } set { } }
        public System.BinaryData RetentionTimeInDays { get { throw null; } set { } }
    }
    public partial class CustomActivityReferenceObject
    {
        public CustomActivityReferenceObject() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.DatasetReference> Datasets { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference> LinkedServices { get { throw null; } }
    }
    public partial class CustomDataset : Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetProperties
    {
        public CustomDataset(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName) : base (default(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference)) { }
        public System.BinaryData TypeProperties { get { throw null; } set { } }
    }
    public partial class CustomDataSourceLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public CustomDataSourceLinkedService(System.BinaryData typeProperties) { }
        public System.BinaryData TypeProperties { get { throw null; } set { } }
    }
    public partial class CustomEventsTrigger : Azure.ResourceManager.DataFactory.Models.MultiplePipelineTrigger
    {
        public CustomEventsTrigger(System.Collections.Generic.IEnumerable<System.BinaryData> events, string scope) { }
        public System.Collections.Generic.IList<System.BinaryData> Events { get { throw null; } }
        public string Scope { get { throw null; } set { } }
        public string SubjectBeginsWith { get { throw null; } set { } }
        public string SubjectEndsWith { get { throw null; } set { } }
    }
    public abstract partial class CustomSetupBase
    {
        protected CustomSetupBase() { }
    }
    public partial class DatabricksNotebookActivity : Azure.ResourceManager.DataFactory.Models.ExecutionActivity
    {
        public DatabricksNotebookActivity(string name, Azure.Core.Expressions.DataFactory.DataFactoryElement<string> notebookPath) : base (default(string)) { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> BaseParameters { get { throw null; } }
        public System.Collections.Generic.IList<System.Collections.Generic.IDictionary<string, System.BinaryData>> Libraries { get { throw null; } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> NotebookPath { get { throw null; } set { } }
    }
    public partial class DatabricksSparkJarActivity : Azure.ResourceManager.DataFactory.Models.ExecutionActivity
    {
        public DatabricksSparkJarActivity(string name, Azure.Core.Expressions.DataFactory.DataFactoryElement<string> mainClassName) : base (default(string)) { }
        public System.Collections.Generic.IList<System.Collections.Generic.IDictionary<string, System.BinaryData>> Libraries { get { throw null; } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> MainClassName { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.BinaryData> Parameters { get { throw null; } }
    }
    public partial class DatabricksSparkPythonActivity : Azure.ResourceManager.DataFactory.Models.ExecutionActivity
    {
        public DatabricksSparkPythonActivity(string name, Azure.Core.Expressions.DataFactory.DataFactoryElement<string> pythonFile) : base (default(string)) { }
        public System.Collections.Generic.IList<System.Collections.Generic.IDictionary<string, System.BinaryData>> Libraries { get { throw null; } }
        public System.Collections.Generic.IList<System.BinaryData> Parameters { get { throw null; } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> PythonFile { get { throw null; } set { } }
    }
    public partial class DataFactoryBlobEventsTrigger : Azure.ResourceManager.DataFactory.Models.MultiplePipelineTrigger
    {
        public DataFactoryBlobEventsTrigger(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataFactory.Models.DataFactoryBlobEventType> events, string scope) { }
        public string BlobPathBeginsWith { get { throw null; } set { } }
        public string BlobPathEndsWith { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.DataFactoryBlobEventType> Events { get { throw null; } }
        public bool? IgnoreEmptyBlobs { get { throw null; } set { } }
        public string Scope { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataFactoryBlobEventType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.DataFactoryBlobEventType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataFactoryBlobEventType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.DataFactoryBlobEventType MicrosoftStorageBlobCreated { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.DataFactoryBlobEventType MicrosoftStorageBlobDeleted { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.DataFactoryBlobEventType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.DataFactoryBlobEventType left, Azure.ResourceManager.DataFactory.Models.DataFactoryBlobEventType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.DataFactoryBlobEventType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.DataFactoryBlobEventType left, Azure.ResourceManager.DataFactory.Models.DataFactoryBlobEventType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataFactoryBlobSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public DataFactoryBlobSink() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> BlobWriterAddHeader { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> BlobWriterDateTimeFormat { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> BlobWriterOverwriteFiles { get { throw null; } set { } }
        public System.BinaryData CopyBehavior { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.DataFactoryMetadataItemInfo> Metadata { get { throw null; } }
    }
    public partial class DataFactoryBlobSource : Azure.ResourceManager.DataFactory.Models.CopyActivitySource
    {
        public DataFactoryBlobSource() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> Recursive { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<int> SkipHeaderLineCount { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> TreatEmptyAsNull { get { throw null; } set { } }
    }
    public partial class DataFactoryBlobTrigger : Azure.ResourceManager.DataFactory.Models.MultiplePipelineTrigger
    {
        public DataFactoryBlobTrigger(string folderPath, int maxConcurrency, Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedService) { }
        public string FolderPath { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference LinkedService { get { throw null; } set { } }
        public int MaxConcurrency { get { throw null; } set { } }
    }
    public partial class DataFactoryCredential
    {
        public DataFactoryCredential() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public System.Collections.Generic.IList<System.BinaryData> Annotations { get { throw null; } }
        public string Description { get { throw null; } set { } }
    }
    public partial class DataFactoryCredentialReference
    {
        public DataFactoryCredentialReference(Azure.ResourceManager.DataFactory.Models.DataFactoryCredentialReferenceType referenceType, string referenceName) { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public string ReferenceName { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DataFactoryCredentialReferenceType ReferenceType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataFactoryCredentialReferenceType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.DataFactoryCredentialReferenceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataFactoryCredentialReferenceType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.DataFactoryCredentialReferenceType CredentialReference { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.DataFactoryCredentialReferenceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.DataFactoryCredentialReferenceType left, Azure.ResourceManager.DataFactory.Models.DataFactoryCredentialReferenceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.DataFactoryCredentialReferenceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.DataFactoryCredentialReferenceType left, Azure.ResourceManager.DataFactory.Models.DataFactoryCredentialReferenceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataFactoryDataFlowCreateDebugSessionResult
    {
        internal DataFactoryDataFlowCreateDebugSessionResult() { }
        public System.Guid? SessionId { get { throw null; } }
        public string Status { get { throw null; } }
    }
    public partial class DataFactoryDataFlowDebugCommandResult
    {
        internal DataFactoryDataFlowDebugCommandResult() { }
        public string Data { get { throw null; } }
        public string Status { get { throw null; } }
    }
    public partial class DataFactoryDataFlowDebugInfo : Azure.ResourceManager.DataFactory.Models.DataFactoryDebugInfo
    {
        public DataFactoryDataFlowDebugInfo(Azure.ResourceManager.DataFactory.Models.DataFactoryDataFlowProperties properties) { }
        public Azure.ResourceManager.DataFactory.Models.DataFactoryDataFlowProperties Properties { get { throw null; } }
    }
    public partial class DataFactoryDataFlowDebugPackageContent
    {
        public DataFactoryDataFlowDebugPackageContent() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.DataFactoryDataFlowDebugInfo DataFlow { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.DataFactoryDataFlowDebugInfo> DataFlows { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetDebugInfo> Datasets { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.DataFlowDebugPackageDebugSettings DebugSettings { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceDebugInfo> LinkedServices { get { throw null; } }
        public System.Guid? SessionId { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DataFlowStagingInfo Staging { get { throw null; } set { } }
    }
    public partial class DataFactoryDataFlowDebugSessionContent
    {
        public DataFactoryDataFlowDebugSessionContent() { }
        public string ComputeType { get { throw null; } set { } }
        public int? CoreCount { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DataFactoryIntegrationRuntimeDebugInfo IntegrationRuntime { get { throw null; } set { } }
        public int? TimeToLiveInMinutes { get { throw null; } set { } }
    }
    public abstract partial class DataFactoryDataFlowProperties
    {
        protected DataFactoryDataFlowProperties() { }
        public System.Collections.Generic.IList<System.BinaryData> Annotations { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string FolderName { get { throw null; } set { } }
    }
    public partial class DataFactoryDataFlowStartDebugSessionResult
    {
        internal DataFactoryDataFlowStartDebugSessionResult() { }
        public string JobVersion { get { throw null; } }
    }
    public partial class DataFactoryDataPlaneAccessPolicyResult
    {
        internal DataFactoryDataPlaneAccessPolicyResult() { }
        public string AccessToken { get { throw null; } }
        public System.Uri DataPlaneUri { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.DataFactoryDataPlaneUserAccessPolicy Policy { get { throw null; } }
    }
    public partial class DataFactoryDataPlaneUserAccessPolicy
    {
        public DataFactoryDataPlaneUserAccessPolicy() { }
        public string AccessResourcePath { get { throw null; } set { } }
        public System.DateTimeOffset? ExpireOn { get { throw null; } set { } }
        public string Permissions { get { throw null; } set { } }
        public string ProfileName { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
    }
    public partial class DataFactoryDatasetDebugInfo : Azure.ResourceManager.DataFactory.Models.DataFactoryDebugInfo
    {
        public DataFactoryDatasetDebugInfo(Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetProperties properties) { }
        public Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetProperties Properties { get { throw null; } }
    }
    public partial class DataFactoryDatasetProperties
    {
        public DataFactoryDatasetProperties(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName) { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public System.Collections.Generic.IList<System.BinaryData> Annotations { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string FolderName { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference LinkedServiceName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DataFactory.Models.EntityParameterSpecification> Parameters { get { throw null; } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.DatasetSchemaDataElement>> Schema { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.DatasetDataElement>> Structure { get { throw null; } set { } }
    }
    public enum DataFactoryDayOfWeek
    {
        Sunday = 0,
        Monday = 1,
        Tuesday = 2,
        Wednesday = 3,
        Thursday = 4,
        Friday = 5,
        Saturday = 6,
    }
    public partial class DataFactoryDebugInfo
    {
        public DataFactoryDebugInfo() { }
        public string Name { get { throw null; } set { } }
    }
    public partial class DataFactoryEncryptionConfiguration
    {
        public DataFactoryEncryptionConfiguration(string keyName, System.Uri vaultBaseUri) { }
        public string KeyName { get { throw null; } set { } }
        public string KeyVersion { get { throw null; } set { } }
        public string UserAssignedIdentity { get { throw null; } set { } }
        public System.Uri VaultBaseUri { get { throw null; } set { } }
    }
    public partial class DataFactoryExpression
    {
        public DataFactoryExpression(Azure.ResourceManager.DataFactory.Models.DataFactoryExpressionType expressionType, string value) { }
        public Azure.ResourceManager.DataFactory.Models.DataFactoryExpressionType ExpressionType { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataFactoryExpressionType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.DataFactoryExpressionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataFactoryExpressionType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.DataFactoryExpressionType Expression { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.DataFactoryExpressionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.DataFactoryExpressionType left, Azure.ResourceManager.DataFactory.Models.DataFactoryExpressionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.DataFactoryExpressionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.DataFactoryExpressionType left, Azure.ResourceManager.DataFactory.Models.DataFactoryExpressionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataFactoryFlowletProperties : Azure.ResourceManager.DataFactory.Models.DataFactoryDataFlowProperties
    {
        public DataFactoryFlowletProperties() { }
        public string Script { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ScriptLines { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.DataFlowSink> Sinks { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.DataFlowSource> Sources { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.DataFlowTransformation> Transformations { get { throw null; } }
    }
    public partial class DataFactoryGlobalParameterProperties
    {
        public DataFactoryGlobalParameterProperties(Azure.ResourceManager.DataFactory.Models.DataFactoryGlobalParameterType globalParameterType, System.BinaryData value) { }
        public Azure.ResourceManager.DataFactory.Models.DataFactoryGlobalParameterType GlobalParameterType { get { throw null; } set { } }
        public System.BinaryData Value { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataFactoryGlobalParameterType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.DataFactoryGlobalParameterType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataFactoryGlobalParameterType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.DataFactoryGlobalParameterType Array { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.DataFactoryGlobalParameterType Bool { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.DataFactoryGlobalParameterType Float { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.DataFactoryGlobalParameterType Int { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.DataFactoryGlobalParameterType Object { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.DataFactoryGlobalParameterType String { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.DataFactoryGlobalParameterType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.DataFactoryGlobalParameterType left, Azure.ResourceManager.DataFactory.Models.DataFactoryGlobalParameterType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.DataFactoryGlobalParameterType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.DataFactoryGlobalParameterType left, Azure.ResourceManager.DataFactory.Models.DataFactoryGlobalParameterType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataFactoryHttpDataset : Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetProperties
    {
        public DataFactoryHttpDataset(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName) : base (default(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference)) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> AdditionalHeaders { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DatasetCompression Compression { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DatasetStorageFormat Format { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> RelativeUri { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> RequestBody { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> RequestMethod { get { throw null; } set { } }
    }
    public partial class DataFactoryHttpFileSource : Azure.ResourceManager.DataFactory.Models.CopyActivitySource
    {
        public DataFactoryHttpFileSource() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> HttpRequestTimeout { get { throw null; } set { } }
    }
    public partial class DataFactoryIntegrationRuntimeDebugInfo : Azure.ResourceManager.DataFactory.Models.DataFactoryDebugInfo
    {
        public DataFactoryIntegrationRuntimeDebugInfo(Azure.ResourceManager.DataFactory.Models.DataFactoryIntegrationRuntimeProperties properties) { }
        public Azure.ResourceManager.DataFactory.Models.DataFactoryIntegrationRuntimeProperties Properties { get { throw null; } }
    }
    public partial class DataFactoryIntegrationRuntimePatch
    {
        public DataFactoryIntegrationRuntimePatch() { }
        public Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeAutoUpdateState? AutoUpdate { get { throw null; } set { } }
        public System.TimeSpan? UpdateDelayOffset { get { throw null; } set { } }
    }
    public partial class DataFactoryIntegrationRuntimeProperties
    {
        public DataFactoryIntegrationRuntimeProperties() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public string Description { get { throw null; } set { } }
    }
    public partial class DataFactoryIntegrationRuntimeStatusResult
    {
        internal DataFactoryIntegrationRuntimeStatusResult() { }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeStatus Properties { get { throw null; } }
    }
    public partial class DataFactoryLinkedServiceDebugInfo : Azure.ResourceManager.DataFactory.Models.DataFactoryDebugInfo
    {
        public DataFactoryLinkedServiceDebugInfo(Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties properties) { }
        public Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties Properties { get { throw null; } }
    }
    public partial class DataFactoryLinkedServiceProperties
    {
        public DataFactoryLinkedServiceProperties() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public System.Collections.Generic.IList<System.BinaryData> Annotations { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeReference ConnectVia { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DataFactory.Models.EntityParameterSpecification> Parameters { get { throw null; } }
    }
    public partial class DataFactoryLogSettings
    {
        public DataFactoryLogSettings(Azure.ResourceManager.DataFactory.Models.LogLocationSettings logLocationSettings) { }
        public Azure.ResourceManager.DataFactory.Models.CopyActivityLogSettings CopyActivityLogSettings { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> EnableCopyActivityLog { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.LogLocationSettings LogLocationSettings { get { throw null; } set { } }
    }
    public partial class DataFactoryManagedIdentityCredentialProperties : Azure.ResourceManager.DataFactory.Models.DataFactoryCredential
    {
        public DataFactoryManagedIdentityCredentialProperties() { }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
    }
    public partial class DataFactoryManagedVirtualNetworkProperties
    {
        public DataFactoryManagedVirtualNetworkProperties() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public string Alias { get { throw null; } }
        public System.Guid? VnetId { get { throw null; } }
    }
    public partial class DataFactoryMappingDataFlowProperties : Azure.ResourceManager.DataFactory.Models.DataFactoryDataFlowProperties
    {
        public DataFactoryMappingDataFlowProperties() { }
        public string Script { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ScriptLines { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.DataFlowSink> Sinks { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.DataFlowSource> Sources { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.DataFlowTransformation> Transformations { get { throw null; } }
    }
    public partial class DataFactoryMetadataItemInfo
    {
        public DataFactoryMetadataItemInfo() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Name { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Value { get { throw null; } set { } }
    }
    public partial class DataFactoryPackageStore
    {
        public DataFactoryPackageStore(string name, Azure.ResourceManager.DataFactory.Models.EntityReference packageStoreLinkedService) { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.EntityReference PackageStoreLinkedService { get { throw null; } set { } }
    }
    public partial class DataFactoryPatch
    {
        public DataFactoryPatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DataFactoryPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class DataFactoryPipelineReference
    {
        public DataFactoryPipelineReference(Azure.ResourceManager.DataFactory.Models.DataFactoryPipelineReferenceType referenceType, string referenceName) { }
        public string Name { get { throw null; } set { } }
        public string ReferenceName { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DataFactoryPipelineReferenceType ReferenceType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataFactoryPipelineReferenceType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.DataFactoryPipelineReferenceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataFactoryPipelineReferenceType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.DataFactoryPipelineReferenceType PipelineReference { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.DataFactoryPipelineReferenceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.DataFactoryPipelineReferenceType left, Azure.ResourceManager.DataFactory.Models.DataFactoryPipelineReferenceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.DataFactoryPipelineReferenceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.DataFactoryPipelineReferenceType left, Azure.ResourceManager.DataFactory.Models.DataFactoryPipelineReferenceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataFactoryPipelineRunEntityInfo
    {
        internal DataFactoryPipelineRunEntityInfo() { }
        public string Id { get { throw null; } }
        public string InvokedByType { get { throw null; } }
        public string Name { get { throw null; } }
        public string PipelineName { get { throw null; } }
        public System.Guid? PipelineRunId { get { throw null; } }
    }
    public partial class DataFactoryPipelineRunInfo
    {
        internal DataFactoryPipelineRunInfo() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public int? DurationInMs { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.DataFactoryPipelineRunEntityInfo InvokedBy { get { throw null; } }
        public bool? IsLatest { get { throw null; } }
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } }
        public string Message { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Parameters { get { throw null; } }
        public string PipelineName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> RunDimensions { get { throw null; } }
        public System.DateTimeOffset? RunEndOn { get { throw null; } }
        public string RunGroupId { get { throw null; } }
        public System.Guid? RunId { get { throw null; } }
        public System.DateTimeOffset? RunStartOn { get { throw null; } }
        public string Status { get { throw null; } }
    }
    public partial class DataFactoryPrivateEndpointConnectionCreateOrUpdateContent : Azure.ResourceManager.Models.ResourceData
    {
        public DataFactoryPrivateEndpointConnectionCreateOrUpdateContent() { }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.PrivateLinkConnectionApprovalRequest Properties { get { throw null; } set { } }
    }
    public partial class DataFactoryPrivateEndpointConnectionProperties
    {
        public DataFactoryPrivateEndpointConnectionProperties() { }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.PrivateLinkConnectionState PrivateLinkServiceConnectionState { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
    }
    public partial class DataFactoryPrivateEndpointProperties
    {
        public DataFactoryPrivateEndpointProperties() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.ConnectionStateProperties ConnectionState { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Fqdns { get { throw null; } }
        public string GroupId { get { throw null; } set { } }
        public bool? IsReserved { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrivateLinkResourceId { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
    }
    public partial class DataFactoryPrivateLinkResource : Azure.ResourceManager.Models.ResourceData
    {
        public DataFactoryPrivateLinkResource() { }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.DataFactoryPrivateLinkResourceProperties Properties { get { throw null; } set { } }
    }
    public partial class DataFactoryPrivateLinkResourceProperties
    {
        public DataFactoryPrivateLinkResourceProperties() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredZoneNames { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataFactoryPublicNetworkAccess : System.IEquatable<Azure.ResourceManager.DataFactory.Models.DataFactoryPublicNetworkAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataFactoryPublicNetworkAccess(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.DataFactoryPublicNetworkAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.DataFactoryPublicNetworkAccess Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.DataFactoryPublicNetworkAccess other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.DataFactoryPublicNetworkAccess left, Azure.ResourceManager.DataFactory.Models.DataFactoryPublicNetworkAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.DataFactoryPublicNetworkAccess (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.DataFactoryPublicNetworkAccess left, Azure.ResourceManager.DataFactory.Models.DataFactoryPublicNetworkAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataFactoryRecurrenceFrequency : System.IEquatable<Azure.ResourceManager.DataFactory.Models.DataFactoryRecurrenceFrequency>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataFactoryRecurrenceFrequency(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.DataFactoryRecurrenceFrequency Day { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.DataFactoryRecurrenceFrequency Hour { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.DataFactoryRecurrenceFrequency Minute { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.DataFactoryRecurrenceFrequency Month { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.DataFactoryRecurrenceFrequency NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.DataFactoryRecurrenceFrequency Week { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.DataFactoryRecurrenceFrequency Year { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.DataFactoryRecurrenceFrequency other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.DataFactoryRecurrenceFrequency left, Azure.ResourceManager.DataFactory.Models.DataFactoryRecurrenceFrequency right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.DataFactoryRecurrenceFrequency (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.DataFactoryRecurrenceFrequency left, Azure.ResourceManager.DataFactory.Models.DataFactoryRecurrenceFrequency right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataFactoryRecurrenceSchedule
    {
        public DataFactoryRecurrenceSchedule() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public System.Collections.Generic.IList<int> Hours { get { throw null; } }
        public System.Collections.Generic.IList<int> Minutes { get { throw null; } }
        public System.Collections.Generic.IList<int> MonthDays { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.DataFactoryRecurrenceScheduleOccurrence> MonthlyOccurrences { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.DataFactoryDayOfWeek> WeekDays { get { throw null; } }
    }
    public partial class DataFactoryRecurrenceScheduleOccurrence
    {
        public DataFactoryRecurrenceScheduleOccurrence() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.DataFactoryDayOfWeek? Day { get { throw null; } set { } }
        public int? Occurrence { get { throw null; } set { } }
    }
    public partial class DataFactoryScheduleTrigger : Azure.ResourceManager.DataFactory.Models.MultiplePipelineTrigger
    {
        public DataFactoryScheduleTrigger(Azure.ResourceManager.DataFactory.Models.ScheduleTriggerRecurrence recurrence) { }
        public Azure.ResourceManager.DataFactory.Models.ScheduleTriggerRecurrence Recurrence { get { throw null; } set { } }
    }
    public partial class DataFactoryScriptAction
    {
        public DataFactoryScriptAction(string name, System.Uri uri, System.BinaryData roles) { }
        public string Name { get { throw null; } set { } }
        public string Parameters { get { throw null; } set { } }
        public System.BinaryData Roles { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    public partial class DataFactoryScriptActivity : Azure.ResourceManager.DataFactory.Models.ExecutionActivity
    {
        public DataFactoryScriptActivity(string name) : base (default(string)) { }
        public Azure.ResourceManager.DataFactory.Models.ScriptActivityTypeLogSettings LogSettings { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ScriptBlockExecutionTimeout { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.ScriptActivityScriptBlock> Scripts { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataFactoryScriptType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.DataFactoryScriptType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataFactoryScriptType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.DataFactoryScriptType NonQuery { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.DataFactoryScriptType Query { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.DataFactoryScriptType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.DataFactoryScriptType left, Azure.ResourceManager.DataFactory.Models.DataFactoryScriptType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.DataFactoryScriptType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.DataFactoryScriptType left, Azure.ResourceManager.DataFactory.Models.DataFactoryScriptType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataFactorySparkConfigurationType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.DataFactorySparkConfigurationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataFactorySparkConfigurationType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.DataFactorySparkConfigurationType Artifact { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.DataFactorySparkConfigurationType Customized { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.DataFactorySparkConfigurationType Default { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.DataFactorySparkConfigurationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.DataFactorySparkConfigurationType left, Azure.ResourceManager.DataFactory.Models.DataFactorySparkConfigurationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.DataFactorySparkConfigurationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.DataFactorySparkConfigurationType left, Azure.ResourceManager.DataFactory.Models.DataFactorySparkConfigurationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataFactoryTriggerProperties
    {
        public DataFactoryTriggerProperties() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public System.Collections.Generic.IList<System.BinaryData> Annotations { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DataFactoryTriggerRuntimeState? RuntimeState { get { throw null; } }
    }
    public partial class DataFactoryTriggerReference
    {
        public DataFactoryTriggerReference(Azure.ResourceManager.DataFactory.Models.DataFactoryTriggerReferenceType referenceType, string referenceName) { }
        public string ReferenceName { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DataFactoryTriggerReferenceType ReferenceType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataFactoryTriggerReferenceType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.DataFactoryTriggerReferenceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataFactoryTriggerReferenceType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.DataFactoryTriggerReferenceType TriggerReference { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.DataFactoryTriggerReferenceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.DataFactoryTriggerReferenceType left, Azure.ResourceManager.DataFactory.Models.DataFactoryTriggerReferenceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.DataFactoryTriggerReferenceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.DataFactoryTriggerReferenceType left, Azure.ResourceManager.DataFactory.Models.DataFactoryTriggerReferenceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataFactoryTriggerRun
    {
        internal DataFactoryTriggerRun() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> DependencyStatus { get { throw null; } }
        public string Message { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Properties { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> RunDimension { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.DataFactoryTriggerRunStatus? Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> TriggeredPipelines { get { throw null; } }
        public string TriggerName { get { throw null; } }
        public string TriggerRunId { get { throw null; } }
        public System.DateTimeOffset? TriggerRunTimestamp { get { throw null; } }
        public string TriggerType { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataFactoryTriggerRunStatus : System.IEquatable<Azure.ResourceManager.DataFactory.Models.DataFactoryTriggerRunStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataFactoryTriggerRunStatus(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.DataFactoryTriggerRunStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.DataFactoryTriggerRunStatus Inprogress { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.DataFactoryTriggerRunStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.DataFactoryTriggerRunStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.DataFactoryTriggerRunStatus left, Azure.ResourceManager.DataFactory.Models.DataFactoryTriggerRunStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.DataFactoryTriggerRunStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.DataFactoryTriggerRunStatus left, Azure.ResourceManager.DataFactory.Models.DataFactoryTriggerRunStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataFactoryTriggerRuntimeState : System.IEquatable<Azure.ResourceManager.DataFactory.Models.DataFactoryTriggerRuntimeState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataFactoryTriggerRuntimeState(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.DataFactoryTriggerRuntimeState Disabled { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.DataFactoryTriggerRuntimeState Started { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.DataFactoryTriggerRuntimeState Stopped { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.DataFactoryTriggerRuntimeState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.DataFactoryTriggerRuntimeState left, Azure.ResourceManager.DataFactory.Models.DataFactoryTriggerRuntimeState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.DataFactoryTriggerRuntimeState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.DataFactoryTriggerRuntimeState left, Azure.ResourceManager.DataFactory.Models.DataFactoryTriggerRuntimeState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataFactoryTriggerSubscriptionOperationResult
    {
        internal DataFactoryTriggerSubscriptionOperationResult() { }
        public Azure.ResourceManager.DataFactory.Models.EventSubscriptionStatus? Status { get { throw null; } }
        public string TriggerName { get { throw null; } }
    }
    public partial class DataFactoryWranglingDataFlowProperties : Azure.ResourceManager.DataFactory.Models.DataFactoryDataFlowProperties
    {
        public DataFactoryWranglingDataFlowProperties() { }
        public string DocumentLocale { get { throw null; } set { } }
        public string Script { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.PowerQuerySource> Sources { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataFlowComputeType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.DataFlowComputeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataFlowComputeType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.DataFlowComputeType ComputeOptimized { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.DataFlowComputeType General { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.DataFlowComputeType MemoryOptimized { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.DataFlowComputeType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.DataFlowComputeType left, Azure.ResourceManager.DataFactory.Models.DataFlowComputeType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.DataFlowComputeType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.DataFlowComputeType left, Azure.ResourceManager.DataFactory.Models.DataFlowComputeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataFlowDebugCommandContent
    {
        public DataFlowDebugCommandContent() { }
        public Azure.ResourceManager.DataFactory.Models.DataFlowDebugCommandType? Command { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DataFlowDebugCommandPayload CommandPayload { get { throw null; } set { } }
        public System.Guid? SessionId { get { throw null; } set { } }
    }
    public partial class DataFlowDebugCommandPayload
    {
        public DataFlowDebugCommandPayload(string streamName) { }
        public System.Collections.Generic.IList<string> Columns { get { throw null; } }
        public string Expression { get { throw null; } set { } }
        public int? RowLimits { get { throw null; } set { } }
        public string StreamName { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataFlowDebugCommandType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.DataFlowDebugCommandType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataFlowDebugCommandType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.DataFlowDebugCommandType ExecuteExpressionQuery { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.DataFlowDebugCommandType ExecutePreviewQuery { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.DataFlowDebugCommandType ExecuteStatisticsQuery { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.DataFlowDebugCommandType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.DataFlowDebugCommandType left, Azure.ResourceManager.DataFactory.Models.DataFlowDebugCommandType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.DataFlowDebugCommandType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.DataFlowDebugCommandType left, Azure.ResourceManager.DataFactory.Models.DataFlowDebugCommandType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataFlowDebugPackageDebugSettings
    {
        public DataFlowDebugPackageDebugSettings() { }
        public System.BinaryData DatasetParameters { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Parameters { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.DataFlowSourceSetting> SourceSettings { get { throw null; } }
    }
    public partial class DataFlowDebugSessionInfo
    {
        internal DataFlowDebugSessionInfo() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public string ComputeType { get { throw null; } }
        public int? CoreCount { get { throw null; } }
        public string DataFlowName { get { throw null; } }
        public string IntegrationRuntimeName { get { throw null; } }
        public System.DateTimeOffset? LastActivityOn { get { throw null; } }
        public int? NodeCount { get { throw null; } }
        public System.Guid? SessionId { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public int? TimeToLiveInMinutes { get { throw null; } }
    }
    public partial class DataFlowReference
    {
        public DataFlowReference(Azure.ResourceManager.DataFactory.Models.DataFlowReferenceType referenceType, string referenceName) { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public System.BinaryData DatasetParameters { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Parameters { get { throw null; } }
        public string ReferenceName { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DataFlowReferenceType ReferenceType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataFlowReferenceType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.DataFlowReferenceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataFlowReferenceType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.DataFlowReferenceType DataFlowReference { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.DataFlowReferenceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.DataFlowReferenceType left, Azure.ResourceManager.DataFactory.Models.DataFlowReferenceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.DataFlowReferenceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.DataFlowReferenceType left, Azure.ResourceManager.DataFactory.Models.DataFlowReferenceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataFlowSink : Azure.ResourceManager.DataFactory.Models.DataFlowTransformation
    {
        public DataFlowSink(string name) : base (default(string)) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference RejectedDataLinkedService { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference SchemaLinkedService { get { throw null; } set { } }
    }
    public partial class DataFlowSource : Azure.ResourceManager.DataFactory.Models.DataFlowTransformation
    {
        public DataFlowSource(string name) : base (default(string)) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference SchemaLinkedService { get { throw null; } set { } }
    }
    public partial class DataFlowSourceSetting
    {
        public DataFlowSourceSetting() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public int? RowLimit { get { throw null; } set { } }
        public string SourceName { get { throw null; } set { } }
    }
    public partial class DataFlowStagingInfo
    {
        public DataFlowStagingInfo() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> FolderPath { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference LinkedService { get { throw null; } set { } }
    }
    public partial class DataFlowTransformation
    {
        public DataFlowTransformation(string name) { }
        public Azure.ResourceManager.DataFactory.Models.DatasetReference Dataset { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DataFlowReference Flowlet { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference LinkedService { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    public partial class DataLakeAnalyticsUsqlActivity : Azure.ResourceManager.DataFactory.Models.ExecutionActivity
    {
        public DataLakeAnalyticsUsqlActivity(string name, Azure.Core.Expressions.DataFactory.DataFactoryElement<string> scriptPath, Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference scriptLinkedService) : base (default(string)) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> CompilationMode { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<int> DegreeOfParallelism { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Parameters { get { throw null; } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<int> Priority { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> RuntimeVersion { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference ScriptLinkedService { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ScriptPath { get { throw null; } set { } }
    }
    public partial class DataMapperMapping
    {
        public DataMapperMapping() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.MapperAttributeMapping> AttributeMappings { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.MapperConnectionReference SourceConnectionReference { get { throw null; } set { } }
        public System.BinaryData SourceDenormalizeInfo { get { throw null; } set { } }
        public string SourceEntityName { get { throw null; } set { } }
        public string TargetEntityName { get { throw null; } set { } }
    }
    public partial class DatasetAvroFormat : Azure.ResourceManager.DataFactory.Models.DatasetStorageFormat
    {
        public DatasetAvroFormat() { }
    }
    public partial class DatasetCompression
    {
        public DatasetCompression(Azure.Core.Expressions.DataFactory.DataFactoryElement<string> datasetCompressionType) { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> DatasetCompressionType { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Level { get { throw null; } set { } }
    }
    public partial class DatasetDataElement
    {
        public DatasetDataElement() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ColumnName { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ColumnType { get { throw null; } set { } }
    }
    public partial class DatasetJsonFormat : Azure.ResourceManager.DataFactory.Models.DatasetStorageFormat
    {
        public DatasetJsonFormat() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> EncodingName { get { throw null; } set { } }
        public System.BinaryData FilePattern { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> JsonNodeReference { get { throw null; } set { } }
        public System.BinaryData JsonPathDefinition { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> NestingSeparator { get { throw null; } set { } }
    }
    public partial class DatasetLocation
    {
        public DatasetLocation() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> FileName { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> FolderPath { get { throw null; } set { } }
    }
    public partial class DatasetOrcFormat : Azure.ResourceManager.DataFactory.Models.DatasetStorageFormat
    {
        public DatasetOrcFormat() { }
    }
    public partial class DatasetParquetFormat : Azure.ResourceManager.DataFactory.Models.DatasetStorageFormat
    {
        public DatasetParquetFormat() { }
    }
    public partial class DatasetReference
    {
        public DatasetReference(Azure.ResourceManager.DataFactory.Models.DatasetReferenceType referenceType, string referenceName) { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Parameters { get { throw null; } }
        public string ReferenceName { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DatasetReferenceType ReferenceType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DatasetReferenceType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.DatasetReferenceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DatasetReferenceType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.DatasetReferenceType DatasetReference { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.DatasetReferenceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.DatasetReferenceType left, Azure.ResourceManager.DataFactory.Models.DatasetReferenceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.DatasetReferenceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.DatasetReferenceType left, Azure.ResourceManager.DataFactory.Models.DatasetReferenceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DatasetSchemaDataElement
    {
        public DatasetSchemaDataElement() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> SchemaColumnName { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> SchemaColumnType { get { throw null; } set { } }
    }
    public partial class DatasetStorageFormat
    {
        public DatasetStorageFormat() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Deserializer { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Serializer { get { throw null; } set { } }
    }
    public partial class DatasetTextFormat : Azure.ResourceManager.DataFactory.Models.DatasetStorageFormat
    {
        public DatasetTextFormat() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ColumnDelimiter { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> EncodingName { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> EscapeChar { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> FirstRowAsHeader { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> NullValue { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> QuoteChar { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> RowDelimiter { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<int> SkipLineCount { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> TreatEmptyAsNull { get { throw null; } set { } }
    }
    public partial class DataworldLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public DataworldLinkedService(Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition apiToken) { }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition ApiToken { get { throw null; } set { } }
        public string EncryptedCredential { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Db2AuthenticationType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.Db2AuthenticationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Db2AuthenticationType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.Db2AuthenticationType Basic { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.Db2AuthenticationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.Db2AuthenticationType left, Azure.ResourceManager.DataFactory.Models.Db2AuthenticationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.Db2AuthenticationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.Db2AuthenticationType left, Azure.ResourceManager.DataFactory.Models.Db2AuthenticationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Db2LinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public Db2LinkedService() { }
        public Azure.ResourceManager.DataFactory.Models.Db2AuthenticationType? AuthenticationType { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> CertificateCommonName { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ConnectionString { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Database { get { throw null; } set { } }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> PackageCollection { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition Password { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Server { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Username { get { throw null; } set { } }
    }
    public partial class Db2Source : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public Db2Source() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Query { get { throw null; } set { } }
    }
    public partial class Db2TableDataset : Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetProperties
    {
        public Db2TableDataset(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName) : base (default(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference)) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> SchemaTypePropertiesSchema { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Table { get { throw null; } set { } }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class DeleteActivity : Azure.ResourceManager.DataFactory.Models.ExecutionActivity
    {
        public DeleteActivity(string name, Azure.ResourceManager.DataFactory.Models.DatasetReference dataset) : base (default(string)) { }
        public Azure.ResourceManager.DataFactory.Models.DatasetReference Dataset { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> EnableLogging { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.LogStorageSettings LogStorageSettings { get { throw null; } set { } }
        public int? MaxConcurrentConnections { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> Recursive { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.StoreReadSettings StoreSettings { get { throw null; } set { } }
    }
    public partial class DeleteDataFlowDebugSessionContent
    {
        public DeleteDataFlowDebugSessionContent() { }
        public System.Guid? SessionId { get { throw null; } set { } }
    }
    public partial class DelimitedTextDataset : Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetProperties
    {
        public DelimitedTextDataset(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName) : base (default(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference)) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ColumnDelimiter { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> CompressionCodec { get { throw null; } set { } }
        public System.BinaryData CompressionLevel { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DatasetLocation DataLocation { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> EncodingName { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> EscapeChar { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> FirstRowAsHeader { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> NullValue { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> QuoteChar { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> RowDelimiter { get { throw null; } set { } }
    }
    public partial class DelimitedTextReadSettings : Azure.ResourceManager.DataFactory.Models.FormatReadSettings
    {
        public DelimitedTextReadSettings() { }
        public Azure.ResourceManager.DataFactory.Models.CompressionReadSettings CompressionProperties { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<int> SkipLineCount { get { throw null; } set { } }
    }
    public partial class DelimitedTextSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public DelimitedTextSink() { }
        public Azure.ResourceManager.DataFactory.Models.DelimitedTextWriteSettings FormatSettings { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.StoreWriteSettings StoreSettings { get { throw null; } set { } }
    }
    public partial class DelimitedTextSource : Azure.ResourceManager.DataFactory.Models.CopyActivitySource
    {
        public DelimitedTextSource() { }
        public System.BinaryData AdditionalColumns { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DelimitedTextReadSettings FormatSettings { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.StoreReadSettings StoreSettings { get { throw null; } set { } }
    }
    public partial class DelimitedTextWriteSettings : Azure.ResourceManager.DataFactory.Models.FormatWriteSettings
    {
        public DelimitedTextWriteSettings(Azure.Core.Expressions.DataFactory.DataFactoryElement<string> fileExtension) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> FileExtension { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> FileNamePrefix { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<int> MaxRowsPerFile { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> QuoteAllText { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DependencyCondition : System.IEquatable<Azure.ResourceManager.DataFactory.Models.DependencyCondition>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DependencyCondition(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.DependencyCondition Completed { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.DependencyCondition Failed { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.DependencyCondition Skipped { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.DependencyCondition Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.DependencyCondition other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.DependencyCondition left, Azure.ResourceManager.DataFactory.Models.DependencyCondition right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.DependencyCondition (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.DependencyCondition left, Azure.ResourceManager.DataFactory.Models.DependencyCondition right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class DependencyReference
    {
        protected DependencyReference() { }
    }
    public partial class DistcpSettings
    {
        public DistcpSettings(Azure.Core.Expressions.DataFactory.DataFactoryElement<string> resourceManagerEndpoint, Azure.Core.Expressions.DataFactory.DataFactoryElement<string> tempScriptPath) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> DistcpOptions { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ResourceManagerEndpoint { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> TempScriptPath { get { throw null; } set { } }
    }
    public partial class DocumentDBCollectionDataset : Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetProperties
    {
        public DocumentDBCollectionDataset(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName, Azure.Core.Expressions.DataFactory.DataFactoryElement<string> collectionName) : base (default(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference)) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> CollectionName { get { throw null; } set { } }
    }
    public partial class DocumentDBCollectionSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public DocumentDBCollectionSink() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> NestingSeparator { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> WriteBehavior { get { throw null; } set { } }
    }
    public partial class DocumentDBCollectionSource : Azure.ResourceManager.DataFactory.Models.CopyActivitySource
    {
        public DocumentDBCollectionSource() { }
        public System.BinaryData AdditionalColumns { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> NestingSeparator { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Query { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> QueryTimeout { get { throw null; } set { } }
    }
    public partial class DrillLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public DrillLinkedService() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ConnectionString { get { throw null; } set { } }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryKeyVaultSecretReference Password { get { throw null; } set { } }
    }
    public partial class DrillSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public DrillSource() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Query { get { throw null; } set { } }
    }
    public partial class DrillTableDataset : Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetProperties
    {
        public DrillTableDataset(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName) : base (default(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference)) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> SchemaTypePropertiesSchema { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Table { get { throw null; } set { } }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class DWCopyCommandDefaultValue
    {
        public DWCopyCommandDefaultValue() { }
        public System.BinaryData ColumnName { get { throw null; } set { } }
        public System.BinaryData DefaultValue { get { throw null; } set { } }
    }
    public partial class DWCopyCommandSettings
    {
        public DWCopyCommandSettings() { }
        public System.Collections.Generic.IDictionary<string, string> AdditionalOptions { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.DWCopyCommandDefaultValue> DefaultValues { get { throw null; } }
    }
    public partial class DynamicsAXLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public DynamicsAXLinkedService(System.BinaryData uri, Azure.Core.Expressions.DataFactory.DataFactoryElement<string> servicePrincipalId, Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition servicePrincipalKey, Azure.Core.Expressions.DataFactory.DataFactoryElement<string> tenant, Azure.Core.Expressions.DataFactory.DataFactoryElement<string> aadResourceId) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> AadResourceId { get { throw null; } set { } }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ServicePrincipalId { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition ServicePrincipalKey { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Tenant { get { throw null; } set { } }
        public System.BinaryData Uri { get { throw null; } set { } }
    }
    public partial class DynamicsAXResourceDataset : Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetProperties
    {
        public DynamicsAXResourceDataset(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName, Azure.Core.Expressions.DataFactory.DataFactoryElement<string> path) : base (default(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference)) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Path { get { throw null; } set { } }
    }
    public partial class DynamicsAXSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public DynamicsAXSource() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> HttpRequestTimeout { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Query { get { throw null; } set { } }
    }
    public partial class DynamicsCrmEntityDataset : Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetProperties
    {
        public DynamicsCrmEntityDataset(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName) : base (default(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference)) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> EntityName { get { throw null; } set { } }
    }
    public partial class DynamicsCrmLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public DynamicsCrmLinkedService(Azure.Core.Expressions.DataFactory.DataFactoryElement<string> deploymentType, Azure.Core.Expressions.DataFactory.DataFactoryElement<string> authenticationType) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> AuthenticationType { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> DeploymentType { get { throw null; } set { } }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> HostName { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> OrganizationName { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition Password { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<int> Port { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition ServicePrincipalCredential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ServicePrincipalCredentialType { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ServicePrincipalId { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ServiceUri { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Username { get { throw null; } set { } }
    }
    public partial class DynamicsCrmSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public DynamicsCrmSink(Azure.ResourceManager.DataFactory.Models.DynamicsSinkWriteBehavior writeBehavior) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> AlternateKeyName { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> IgnoreNullValues { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DynamicsSinkWriteBehavior WriteBehavior { get { throw null; } set { } }
    }
    public partial class DynamicsCrmSource : Azure.ResourceManager.DataFactory.Models.CopyActivitySource
    {
        public DynamicsCrmSource() { }
        public System.BinaryData AdditionalColumns { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Query { get { throw null; } set { } }
    }
    public partial class DynamicsEntityDataset : Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetProperties
    {
        public DynamicsEntityDataset(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName) : base (default(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference)) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> EntityName { get { throw null; } set { } }
    }
    public partial class DynamicsLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public DynamicsLinkedService(Azure.Core.Expressions.DataFactory.DataFactoryElement<string> deploymentType, Azure.Core.Expressions.DataFactory.DataFactoryElement<string> authenticationType) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> AuthenticationType { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DataFactoryCredentialReference Credential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> DeploymentType { get { throw null; } set { } }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> HostName { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> OrganizationName { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition Password { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<int> Port { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition ServicePrincipalCredential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ServicePrincipalCredentialType { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ServicePrincipalId { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ServiceUri { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Username { get { throw null; } set { } }
    }
    public partial class DynamicsSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public DynamicsSink(Azure.ResourceManager.DataFactory.Models.DynamicsSinkWriteBehavior writeBehavior) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> AlternateKeyName { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> IgnoreNullValues { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DynamicsSinkWriteBehavior WriteBehavior { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DynamicsSinkWriteBehavior : System.IEquatable<Azure.ResourceManager.DataFactory.Models.DynamicsSinkWriteBehavior>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DynamicsSinkWriteBehavior(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.DynamicsSinkWriteBehavior Upsert { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.DynamicsSinkWriteBehavior other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.DynamicsSinkWriteBehavior left, Azure.ResourceManager.DataFactory.Models.DynamicsSinkWriteBehavior right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.DynamicsSinkWriteBehavior (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.DynamicsSinkWriteBehavior left, Azure.ResourceManager.DataFactory.Models.DynamicsSinkWriteBehavior right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DynamicsSource : Azure.ResourceManager.DataFactory.Models.CopyActivitySource
    {
        public DynamicsSource() { }
        public System.BinaryData AdditionalColumns { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Query { get { throw null; } set { } }
    }
    public partial class EloquaLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public EloquaLinkedService(Azure.Core.Expressions.DataFactory.DataFactoryElement<string> endpoint, Azure.Core.Expressions.DataFactory.DataFactoryElement<string> username) { }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Endpoint { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition Password { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> UseEncryptedEndpoints { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> UseHostVerification { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> UsePeerVerification { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Username { get { throw null; } set { } }
    }
    public partial class EloquaObjectDataset : Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetProperties
    {
        public EloquaObjectDataset(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName) : base (default(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference)) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> TableName { get { throw null; } set { } }
    }
    public partial class EloquaSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public EloquaSource() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Query { get { throw null; } set { } }
    }
    public partial class EntityParameterSpecification
    {
        public EntityParameterSpecification(Azure.ResourceManager.DataFactory.Models.EntityParameterType parameterType) { }
        public System.BinaryData DefaultValue { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.EntityParameterType ParameterType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EntityParameterType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.EntityParameterType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EntityParameterType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.EntityParameterType Array { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.EntityParameterType Bool { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.EntityParameterType Float { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.EntityParameterType Int { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.EntityParameterType Object { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.EntityParameterType SecureString { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.EntityParameterType String { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.EntityParameterType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.EntityParameterType left, Azure.ResourceManager.DataFactory.Models.EntityParameterType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.EntityParameterType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.EntityParameterType left, Azure.ResourceManager.DataFactory.Models.EntityParameterType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EntityReference
    {
        public EntityReference() { }
        public Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeEntityReferenceType? IntegrationRuntimeEntityReferenceType { get { throw null; } set { } }
        public string ReferenceName { get { throw null; } set { } }
    }
    public partial class EnvironmentVariableSetup : Azure.ResourceManager.DataFactory.Models.CustomSetupBase
    {
        public EnvironmentVariableSetup(string variableName, string variableValue) { }
        public string VariableName { get { throw null; } set { } }
        public string VariableValue { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EventSubscriptionStatus : System.IEquatable<Azure.ResourceManager.DataFactory.Models.EventSubscriptionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EventSubscriptionStatus(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.EventSubscriptionStatus Deprovisioning { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.EventSubscriptionStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.EventSubscriptionStatus Enabled { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.EventSubscriptionStatus Provisioning { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.EventSubscriptionStatus Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.EventSubscriptionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.EventSubscriptionStatus left, Azure.ResourceManager.DataFactory.Models.EventSubscriptionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.EventSubscriptionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.EventSubscriptionStatus left, Azure.ResourceManager.DataFactory.Models.EventSubscriptionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ExcelDataset : Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetProperties
    {
        public ExcelDataset(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName) : base (default(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference)) { }
        public Azure.ResourceManager.DataFactory.Models.DatasetCompression Compression { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DatasetLocation DataLocation { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> FirstRowAsHeader { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> NullValue { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Range { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<int> SheetIndex { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> SheetName { get { throw null; } set { } }
    }
    public partial class ExcelSource : Azure.ResourceManager.DataFactory.Models.CopyActivitySource
    {
        public ExcelSource() { }
        public System.BinaryData AdditionalColumns { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.StoreReadSettings StoreSettings { get { throw null; } set { } }
    }
    public partial class ExecuteDataFlowActivity : Azure.ResourceManager.DataFactory.Models.ExecutionActivity
    {
        public ExecuteDataFlowActivity(string name, Azure.ResourceManager.DataFactory.Models.DataFlowReference dataFlow) : base (default(string)) { }
        public Azure.ResourceManager.DataFactory.Models.ExecuteDataFlowActivityComputeType Compute { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> ContinueOnError { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DataFlowReference DataFlow { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeReference IntegrationRuntime { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> RunConcurrently { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<int> SourceStagingConcurrency { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DataFlowStagingInfo Staging { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> TraceLevel { get { throw null; } set { } }
    }
    public partial class ExecuteDataFlowActivityComputeType
    {
        public ExecuteDataFlowActivityComputeType() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ComputeType { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<int> CoreCount { get { throw null; } set { } }
    }
    public partial class ExecutePipelineActivity : Azure.ResourceManager.DataFactory.Models.ControlActivity
    {
        public ExecutePipelineActivity(string name, Azure.ResourceManager.DataFactory.Models.DataFactoryPipelineReference pipeline) : base (default(string)) { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Parameters { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.DataFactoryPipelineReference Pipeline { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.ExecutePipelineActivityPolicy Policy { get { throw null; } set { } }
        public bool? WaitOnCompletion { get { throw null; } set { } }
    }
    public partial class ExecutePipelineActivityPolicy
    {
        public ExecutePipelineActivityPolicy() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public bool? IsSecureInputEnabled { get { throw null; } set { } }
    }
    public partial class ExecuteSsisPackageActivity : Azure.ResourceManager.DataFactory.Models.ExecutionActivity
    {
        public ExecuteSsisPackageActivity(string name, Azure.ResourceManager.DataFactory.Models.SsisPackageLocation packageLocation, Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeReference connectVia) : base (default(string)) { }
        public Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeReference ConnectVia { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> EnvironmentPath { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SsisExecutionCredential ExecutionCredential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> LoggingLevel { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SsisLogLocation LogLocation { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DataFactory.Models.SsisExecutionParameter>> PackageConnectionManagers { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.SsisPackageLocation PackageLocation { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DataFactory.Models.SsisExecutionParameter> PackageParameters { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DataFactory.Models.SsisExecutionParameter>> ProjectConnectionManagers { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DataFactory.Models.SsisExecutionParameter> ProjectParameters { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DataFactory.Models.SsisPropertyOverride> PropertyOverrides { get { throw null; } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Runtime { get { throw null; } set { } }
    }
    public partial class ExecuteWranglingDataflowActivity : Azure.ResourceManager.DataFactory.Models.PipelineActivity
    {
        public ExecuteWranglingDataflowActivity(string name, Azure.ResourceManager.DataFactory.Models.DataFlowReference dataFlow) : base (default(string)) { }
        public Azure.ResourceManager.DataFactory.Models.ExecuteDataFlowActivityComputeType Compute { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> ContinueOnError { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DataFlowReference DataFlow { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeReference IntegrationRuntime { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.PipelineActivityPolicy Policy { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.PowerQuerySinkMapping> Queries { get { throw null; } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> RunConcurrently { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DataFactory.Models.PowerQuerySink> Sinks { get { throw null; } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<int> SourceStagingConcurrency { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DataFlowStagingInfo Staging { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> TraceLevel { get { throw null; } set { } }
    }
    public partial class ExecutionActivity : Azure.ResourceManager.DataFactory.Models.PipelineActivity
    {
        public ExecutionActivity(string name) : base (default(string)) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference LinkedServiceName { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.PipelineActivityPolicy Policy { get { throw null; } set { } }
    }
    public partial class ExportSettings
    {
        public ExportSettings() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
    }
    public partial class ExposureControlBatchContent
    {
        public ExposureControlBatchContent(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataFactory.Models.ExposureControlContent> exposureControlRequests) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.ExposureControlContent> ExposureControlRequests { get { throw null; } }
    }
    public partial class ExposureControlBatchResult
    {
        internal ExposureControlBatchResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataFactory.Models.ExposureControlResult> ExposureControlResults { get { throw null; } }
    }
    public partial class ExposureControlContent
    {
        public ExposureControlContent() { }
        public string FeatureName { get { throw null; } set { } }
        public string FeatureType { get { throw null; } set { } }
    }
    public partial class ExposureControlResult
    {
        internal ExposureControlResult() { }
        public string FeatureName { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class FactoryGitHubClientSecret
    {
        public FactoryGitHubClientSecret() { }
        public System.Uri ByoaSecretAkvUri { get { throw null; } set { } }
        public string ByoaSecretName { get { throw null; } set { } }
    }
    public partial class FactoryGitHubConfiguration : Azure.ResourceManager.DataFactory.Models.FactoryRepoConfiguration
    {
        public FactoryGitHubConfiguration(string accountName, string repositoryName, string collaborationBranch, string rootFolder) : base (default(string), default(string), default(string), default(string)) { }
        public string ClientId { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactoryGitHubClientSecret ClientSecret { get { throw null; } set { } }
        public string HostName { get { throw null; } set { } }
    }
    public abstract partial class FactoryRepoConfiguration
    {
        protected FactoryRepoConfiguration(string accountName, string repositoryName, string collaborationBranch, string rootFolder) { }
        public string AccountName { get { throw null; } set { } }
        public string CollaborationBranch { get { throw null; } set { } }
        public bool? DisablePublish { get { throw null; } set { } }
        public string LastCommitId { get { throw null; } set { } }
        public string RepositoryName { get { throw null; } set { } }
        public string RootFolder { get { throw null; } set { } }
    }
    public partial class FactoryRepoContent
    {
        public FactoryRepoContent() { }
        public Azure.Core.ResourceIdentifier FactoryResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactoryRepoConfiguration RepoConfiguration { get { throw null; } set { } }
    }
    public partial class FactoryVstsConfiguration : Azure.ResourceManager.DataFactory.Models.FactoryRepoConfiguration
    {
        public FactoryVstsConfiguration(string accountName, string repositoryName, string collaborationBranch, string rootFolder, string projectName) : base (default(string), default(string), default(string), default(string)) { }
        public string ProjectName { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
    }
    public partial class FailActivity : Azure.ResourceManager.DataFactory.Models.ControlActivity
    {
        public FailActivity(string name, Azure.Core.Expressions.DataFactory.DataFactoryElement<string> message, Azure.Core.Expressions.DataFactory.DataFactoryElement<string> errorCode) : base (default(string)) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ErrorCode { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Message { get { throw null; } set { } }
    }
    public partial class FileServerLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public FileServerLinkedService(Azure.Core.Expressions.DataFactory.DataFactoryElement<string> host) { }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Host { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition Password { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> UserId { get { throw null; } set { } }
    }
    public partial class FileServerLocation : Azure.ResourceManager.DataFactory.Models.DatasetLocation
    {
        public FileServerLocation() { }
    }
    public partial class FileServerReadSettings : Azure.ResourceManager.DataFactory.Models.StoreReadSettings
    {
        public FileServerReadSettings() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> DeleteFilesAfterCompletion { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> EnablePartitionDiscovery { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> FileFilter { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> FileListPath { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ModifiedDatetimeEnd { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ModifiedDatetimeStart { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> PartitionRootPath { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> Recursive { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> WildcardFileName { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> WildcardFolderPath { get { throw null; } set { } }
    }
    public partial class FileServerWriteSettings : Azure.ResourceManager.DataFactory.Models.StoreWriteSettings
    {
        public FileServerWriteSettings() { }
    }
    public partial class FileShareDataset : Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetProperties
    {
        public FileShareDataset(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName) : base (default(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference)) { }
        public Azure.ResourceManager.DataFactory.Models.DatasetCompression Compression { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> FileFilter { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> FileName { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> FolderPath { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DatasetStorageFormat Format { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ModifiedDatetimeEnd { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ModifiedDatetimeStart { get { throw null; } set { } }
    }
    public partial class FileSystemSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public FileSystemSink() { }
        public System.BinaryData CopyBehavior { get { throw null; } set { } }
    }
    public partial class FileSystemSource : Azure.ResourceManager.DataFactory.Models.CopyActivitySource
    {
        public FileSystemSource() { }
        public System.BinaryData AdditionalColumns { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> Recursive { get { throw null; } set { } }
    }
    public partial class FilterActivity : Azure.ResourceManager.DataFactory.Models.ControlActivity
    {
        public FilterActivity(string name, Azure.ResourceManager.DataFactory.Models.DataFactoryExpression items, Azure.ResourceManager.DataFactory.Models.DataFactoryExpression condition) : base (default(string)) { }
        public Azure.ResourceManager.DataFactory.Models.DataFactoryExpression Condition { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DataFactoryExpression Items { get { throw null; } set { } }
    }
    public partial class ForEachActivity : Azure.ResourceManager.DataFactory.Models.ControlActivity
    {
        public ForEachActivity(string name, Azure.ResourceManager.DataFactory.Models.DataFactoryExpression items, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataFactory.Models.PipelineActivity> activities) : base (default(string)) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.PipelineActivity> Activities { get { throw null; } }
        public int? BatchCount { get { throw null; } set { } }
        public bool? IsSequential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DataFactoryExpression Items { get { throw null; } set { } }
    }
    public partial class FormatReadSettings
    {
        public FormatReadSettings() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
    }
    public partial class FormatWriteSettings
    {
        public FormatWriteSettings() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FtpAuthenticationType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.FtpAuthenticationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FtpAuthenticationType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.FtpAuthenticationType Anonymous { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.FtpAuthenticationType Basic { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.FtpAuthenticationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.FtpAuthenticationType left, Azure.ResourceManager.DataFactory.Models.FtpAuthenticationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.FtpAuthenticationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.FtpAuthenticationType left, Azure.ResourceManager.DataFactory.Models.FtpAuthenticationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FtpReadSettings : Azure.ResourceManager.DataFactory.Models.StoreReadSettings
    {
        public FtpReadSettings() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> DeleteFilesAfterCompletion { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> DisableChunking { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> EnablePartitionDiscovery { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> FileListPath { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> PartitionRootPath { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> Recursive { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> UseBinaryTransfer { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> WildcardFileName { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> WildcardFolderPath { get { throw null; } set { } }
    }
    public partial class FtpServerLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public FtpServerLinkedService(Azure.Core.Expressions.DataFactory.DataFactoryElement<string> host) { }
        public Azure.ResourceManager.DataFactory.Models.FtpAuthenticationType? AuthenticationType { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> EnableServerCertificateValidation { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> EnableSsl { get { throw null; } set { } }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Host { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition Password { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<int> Port { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> UserName { get { throw null; } set { } }
    }
    public partial class FtpServerLocation : Azure.ResourceManager.DataFactory.Models.DatasetLocation
    {
        public FtpServerLocation() { }
    }
    public partial class GetDatasetMetadataActivity : Azure.ResourceManager.DataFactory.Models.ExecutionActivity
    {
        public GetDatasetMetadataActivity(string name, Azure.ResourceManager.DataFactory.Models.DatasetReference dataset) : base (default(string)) { }
        public Azure.ResourceManager.DataFactory.Models.DatasetReference Dataset { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.BinaryData> FieldList { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.FormatReadSettings FormatSettings { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.StoreReadSettings StoreSettings { get { throw null; } set { } }
    }
    public partial class GetSsisObjectMetadataContent
    {
        public GetSsisObjectMetadataContent() { }
        public string MetadataPath { get { throw null; } set { } }
    }
    public partial class GitHubAccessTokenContent
    {
        public GitHubAccessTokenContent(string gitHubAccessCode, System.Uri gitHubAccessTokenBaseUri) { }
        public string GitHubAccessCode { get { throw null; } }
        public System.Uri GitHubAccessTokenBaseUri { get { throw null; } }
        public string GitHubClientId { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactoryGitHubClientSecret GitHubClientSecret { get { throw null; } set { } }
    }
    public partial class GitHubAccessTokenResult
    {
        internal GitHubAccessTokenResult() { }
        public string GitHubAccessToken { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GoogleAdWordsAuthenticationType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.GoogleAdWordsAuthenticationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GoogleAdWordsAuthenticationType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.GoogleAdWordsAuthenticationType ServiceAuthentication { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.GoogleAdWordsAuthenticationType UserAuthentication { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.GoogleAdWordsAuthenticationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.GoogleAdWordsAuthenticationType left, Azure.ResourceManager.DataFactory.Models.GoogleAdWordsAuthenticationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.GoogleAdWordsAuthenticationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.GoogleAdWordsAuthenticationType left, Azure.ResourceManager.DataFactory.Models.GoogleAdWordsAuthenticationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class GoogleAdWordsLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public GoogleAdWordsLinkedService() { }
        public Azure.ResourceManager.DataFactory.Models.GoogleAdWordsAuthenticationType? AuthenticationType { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ClientCustomerId { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ClientId { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition ClientSecret { get { throw null; } set { } }
        public System.BinaryData ConnectionProperties { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition DeveloperToken { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Email { get { throw null; } set { } }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> KeyFilePath { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition RefreshToken { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> TrustedCertPath { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> UseSystemTrustStore { get { throw null; } set { } }
    }
    public partial class GoogleAdWordsObjectDataset : Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetProperties
    {
        public GoogleAdWordsObjectDataset(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName) : base (default(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference)) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> TableName { get { throw null; } set { } }
    }
    public partial class GoogleAdWordsSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public GoogleAdWordsSource() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Query { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GoogleBigQueryAuthenticationType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.GoogleBigQueryAuthenticationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GoogleBigQueryAuthenticationType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.GoogleBigQueryAuthenticationType ServiceAuthentication { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.GoogleBigQueryAuthenticationType UserAuthentication { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.GoogleBigQueryAuthenticationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.GoogleBigQueryAuthenticationType left, Azure.ResourceManager.DataFactory.Models.GoogleBigQueryAuthenticationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.GoogleBigQueryAuthenticationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.GoogleBigQueryAuthenticationType left, Azure.ResourceManager.DataFactory.Models.GoogleBigQueryAuthenticationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class GoogleBigQueryLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public GoogleBigQueryLinkedService(Azure.Core.Expressions.DataFactory.DataFactoryElement<string> project, Azure.ResourceManager.DataFactory.Models.GoogleBigQueryAuthenticationType authenticationType) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> AdditionalProjects { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.GoogleBigQueryAuthenticationType AuthenticationType { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ClientId { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition ClientSecret { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Email { get { throw null; } set { } }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> KeyFilePath { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Project { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition RefreshToken { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> RequestGoogleDriveScope { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> TrustedCertPath { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> UseSystemTrustStore { get { throw null; } set { } }
    }
    public partial class GoogleBigQueryObjectDataset : Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetProperties
    {
        public GoogleBigQueryObjectDataset(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName) : base (default(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference)) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Dataset { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Table { get { throw null; } set { } }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class GoogleBigQuerySource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public GoogleBigQuerySource() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Query { get { throw null; } set { } }
    }
    public partial class GoogleCloudStorageLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public GoogleCloudStorageLinkedService() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> AccessKeyId { get { throw null; } set { } }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition SecretAccessKey { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ServiceUri { get { throw null; } set { } }
    }
    public partial class GoogleCloudStorageLocation : Azure.ResourceManager.DataFactory.Models.DatasetLocation
    {
        public GoogleCloudStorageLocation() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> BucketName { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Version { get { throw null; } set { } }
    }
    public partial class GoogleCloudStorageReadSettings : Azure.ResourceManager.DataFactory.Models.StoreReadSettings
    {
        public GoogleCloudStorageReadSettings() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> DeleteFilesAfterCompletion { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> EnablePartitionDiscovery { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> FileListPath { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ModifiedDatetimeEnd { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ModifiedDatetimeStart { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> PartitionRootPath { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Prefix { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> Recursive { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> WildcardFileName { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> WildcardFolderPath { get { throw null; } set { } }
    }
    public partial class GoogleSheetsLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public GoogleSheetsLinkedService(Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition apiToken) { }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition ApiToken { get { throw null; } set { } }
        public string EncryptedCredential { get { throw null; } set { } }
    }
    public partial class GreenplumLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public GreenplumLinkedService() { }
        public System.BinaryData ConnectionString { get { throw null; } set { } }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryKeyVaultSecretReference Password { get { throw null; } set { } }
    }
    public partial class GreenplumSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public GreenplumSource() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Query { get { throw null; } set { } }
    }
    public partial class GreenplumTableDataset : Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetProperties
    {
        public GreenplumTableDataset(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName) : base (default(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference)) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> SchemaTypePropertiesSchema { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Table { get { throw null; } set { } }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HBaseAuthenticationType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.HBaseAuthenticationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HBaseAuthenticationType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.HBaseAuthenticationType Anonymous { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.HBaseAuthenticationType Basic { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.HBaseAuthenticationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.HBaseAuthenticationType left, Azure.ResourceManager.DataFactory.Models.HBaseAuthenticationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.HBaseAuthenticationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.HBaseAuthenticationType left, Azure.ResourceManager.DataFactory.Models.HBaseAuthenticationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HBaseLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public HBaseLinkedService(Azure.Core.Expressions.DataFactory.DataFactoryElement<string> host, Azure.ResourceManager.DataFactory.Models.HBaseAuthenticationType authenticationType) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> AllowHostNameCNMismatch { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> AllowSelfSignedServerCert { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.HBaseAuthenticationType AuthenticationType { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> EnableSsl { get { throw null; } set { } }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Host { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> HttpPath { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition Password { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<int> Port { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> TrustedCertPath { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Username { get { throw null; } set { } }
    }
    public partial class HBaseObjectDataset : Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetProperties
    {
        public HBaseObjectDataset(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName) : base (default(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference)) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> TableName { get { throw null; } set { } }
    }
    public partial class HBaseSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public HBaseSource() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Query { get { throw null; } set { } }
    }
    public partial class HdfsLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public HdfsLinkedService(Azure.Core.Expressions.DataFactory.DataFactoryElement<string> uri) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> AuthenticationType { get { throw null; } set { } }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition Password { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Uri { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> UserName { get { throw null; } set { } }
    }
    public partial class HdfsLocation : Azure.ResourceManager.DataFactory.Models.DatasetLocation
    {
        public HdfsLocation() { }
    }
    public partial class HdfsReadSettings : Azure.ResourceManager.DataFactory.Models.StoreReadSettings
    {
        public HdfsReadSettings() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> DeleteFilesAfterCompletion { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DistcpSettings DistcpSettings { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> EnablePartitionDiscovery { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> FileListPath { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ModifiedDatetimeEnd { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ModifiedDatetimeStart { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> PartitionRootPath { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> Recursive { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> WildcardFileName { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> WildcardFolderPath { get { throw null; } set { } }
    }
    public partial class HdfsSource : Azure.ResourceManager.DataFactory.Models.CopyActivitySource
    {
        public HdfsSource() { }
        public Azure.ResourceManager.DataFactory.Models.DistcpSettings DistcpSettings { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> Recursive { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HDInsightActivityDebugInfoOptionSetting : System.IEquatable<Azure.ResourceManager.DataFactory.Models.HDInsightActivityDebugInfoOptionSetting>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HDInsightActivityDebugInfoOptionSetting(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.HDInsightActivityDebugInfoOptionSetting Always { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.HDInsightActivityDebugInfoOptionSetting Failure { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.HDInsightActivityDebugInfoOptionSetting None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.HDInsightActivityDebugInfoOptionSetting other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.HDInsightActivityDebugInfoOptionSetting left, Azure.ResourceManager.DataFactory.Models.HDInsightActivityDebugInfoOptionSetting right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.HDInsightActivityDebugInfoOptionSetting (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.HDInsightActivityDebugInfoOptionSetting left, Azure.ResourceManager.DataFactory.Models.HDInsightActivityDebugInfoOptionSetting right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HDInsightHiveActivity : Azure.ResourceManager.DataFactory.Models.ExecutionActivity
    {
        public HDInsightHiveActivity(string name) : base (default(string)) { }
        public System.Collections.Generic.IList<System.BinaryData> Arguments { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Defines { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.HDInsightActivityDebugInfoOptionSetting? GetDebugInfo { get { throw null; } set { } }
        public int? QueryTimeout { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference ScriptLinkedService { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ScriptPath { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference> StorageLinkedServices { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Variables { get { throw null; } }
    }
    public partial class HDInsightLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public HDInsightLinkedService(Azure.Core.Expressions.DataFactory.DataFactoryElement<string> clusterUri) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ClusterUri { get { throw null; } set { } }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> FileSystem { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference HcatalogLinkedServiceName { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> IsEspEnabled { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference LinkedServiceName { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition Password { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> UserName { get { throw null; } set { } }
    }
    public partial class HDInsightMapReduceActivity : Azure.ResourceManager.DataFactory.Models.ExecutionActivity
    {
        public HDInsightMapReduceActivity(string name, Azure.Core.Expressions.DataFactory.DataFactoryElement<string> className, Azure.Core.Expressions.DataFactory.DataFactoryElement<string> jarFilePath) : base (default(string)) { }
        public System.Collections.Generic.IList<System.BinaryData> Arguments { get { throw null; } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ClassName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Defines { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.HDInsightActivityDebugInfoOptionSetting? GetDebugInfo { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> JarFilePath { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.BinaryData> JarLibs { get { throw null; } }
        public Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference JarLinkedService { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference> StorageLinkedServices { get { throw null; } }
    }
    public partial class HDInsightOnDemandLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public HDInsightOnDemandLinkedService(Azure.Core.Expressions.DataFactory.DataFactoryElement<string> clusterSize, Azure.Core.Expressions.DataFactory.DataFactoryElement<string> timeToLiveExpression, Azure.Core.Expressions.DataFactory.DataFactoryElement<string> version, Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName, Azure.Core.Expressions.DataFactory.DataFactoryElement<string> hostSubscriptionId, Azure.Core.Expressions.DataFactory.DataFactoryElement<string> tenant, Azure.Core.Expressions.DataFactory.DataFactoryElement<string> clusterResourceGroup) { }
        public System.Collections.Generic.IList<Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference> AdditionalLinkedServiceNames { get { throw null; } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ClusterNamePrefix { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition ClusterPassword { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ClusterResourceGroup { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ClusterSize { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition ClusterSshPassword { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ClusterSshUserName { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ClusterType { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ClusterUserName { get { throw null; } set { } }
        public System.BinaryData CoreConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DataFactoryCredentialReference Credential { get { throw null; } set { } }
        public System.BinaryData DataNodeSize { get { throw null; } set { } }
        public string EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData HBaseConfiguration { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference HcatalogLinkedServiceName { get { throw null; } set { } }
        public System.BinaryData HdfsConfiguration { get { throw null; } set { } }
        public System.BinaryData HeadNodeSize { get { throw null; } set { } }
        public System.BinaryData HiveConfiguration { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> HostSubscriptionId { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference LinkedServiceName { get { throw null; } set { } }
        public System.BinaryData MapReduceConfiguration { get { throw null; } set { } }
        public System.BinaryData OozieConfiguration { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.DataFactoryScriptAction> ScriptActions { get { throw null; } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ServicePrincipalId { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition ServicePrincipalKey { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> SparkVersion { get { throw null; } set { } }
        public System.BinaryData StormConfiguration { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> SubnetName { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Tenant { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> TimeToLiveExpression { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Version { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> VirtualNetworkId { get { throw null; } set { } }
        public System.BinaryData YarnConfiguration { get { throw null; } set { } }
        public System.BinaryData ZookeeperNodeSize { get { throw null; } set { } }
    }
    public partial class HDInsightPigActivity : Azure.ResourceManager.DataFactory.Models.ExecutionActivity
    {
        public HDInsightPigActivity(string name) : base (default(string)) { }
        public System.BinaryData Arguments { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Defines { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.HDInsightActivityDebugInfoOptionSetting? GetDebugInfo { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference ScriptLinkedService { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ScriptPath { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference> StorageLinkedServices { get { throw null; } }
    }
    public partial class HDInsightSparkActivity : Azure.ResourceManager.DataFactory.Models.ExecutionActivity
    {
        public HDInsightSparkActivity(string name, Azure.Core.Expressions.DataFactory.DataFactoryElement<string> rootPath, Azure.Core.Expressions.DataFactory.DataFactoryElement<string> entryFilePath) : base (default(string)) { }
        public System.Collections.Generic.IList<System.BinaryData> Arguments { get { throw null; } }
        public string ClassName { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> EntryFilePath { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.HDInsightActivityDebugInfoOptionSetting? GetDebugInfo { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ProxyUser { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> RootPath { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> SparkConfig { get { throw null; } }
        public Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference SparkJobLinkedService { get { throw null; } set { } }
    }
    public partial class HDInsightStreamingActivity : Azure.ResourceManager.DataFactory.Models.ExecutionActivity
    {
        public HDInsightStreamingActivity(string name, Azure.Core.Expressions.DataFactory.DataFactoryElement<string> mapper, Azure.Core.Expressions.DataFactory.DataFactoryElement<string> reducer, Azure.Core.Expressions.DataFactory.DataFactoryElement<string> input, Azure.Core.Expressions.DataFactory.DataFactoryElement<string> output, System.Collections.Generic.IEnumerable<System.BinaryData> filePaths) : base (default(string)) { }
        public System.Collections.Generic.IList<System.BinaryData> Arguments { get { throw null; } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Combiner { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.BinaryData> CommandEnvironment { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Defines { get { throw null; } }
        public Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference FileLinkedService { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.BinaryData> FilePaths { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.HDInsightActivityDebugInfoOptionSetting? GetDebugInfo { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Input { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Mapper { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Output { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Reducer { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference> StorageLinkedServices { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HiveAuthenticationType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.HiveAuthenticationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HiveAuthenticationType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.HiveAuthenticationType Anonymous { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.HiveAuthenticationType Username { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.HiveAuthenticationType UsernameAndPassword { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.HiveAuthenticationType WindowsAzureHDInsightService { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.HiveAuthenticationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.HiveAuthenticationType left, Azure.ResourceManager.DataFactory.Models.HiveAuthenticationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.HiveAuthenticationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.HiveAuthenticationType left, Azure.ResourceManager.DataFactory.Models.HiveAuthenticationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HiveLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public HiveLinkedService(Azure.Core.Expressions.DataFactory.DataFactoryElement<string> host, Azure.ResourceManager.DataFactory.Models.HiveAuthenticationType authenticationType) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> AllowHostNameCNMismatch { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> AllowSelfSignedServerCert { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.HiveAuthenticationType AuthenticationType { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> EnableSsl { get { throw null; } set { } }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Host { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> HttpPath { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition Password { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<int> Port { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.HiveServerType? ServerType { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> ServiceDiscoveryMode { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.HiveThriftTransportProtocol? ThriftTransportProtocol { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> TrustedCertPath { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> UseNativeQuery { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Username { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> UseSystemTrustStore { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ZooKeeperNameSpace { get { throw null; } set { } }
    }
    public partial class HiveObjectDataset : Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetProperties
    {
        public HiveObjectDataset(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName) : base (default(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference)) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> SchemaTypePropertiesSchema { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Table { get { throw null; } set { } }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HiveServerType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.HiveServerType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HiveServerType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.HiveServerType HiveServer1 { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.HiveServerType HiveServer2 { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.HiveServerType HiveThriftServer { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.HiveServerType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.HiveServerType left, Azure.ResourceManager.DataFactory.Models.HiveServerType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.HiveServerType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.HiveServerType left, Azure.ResourceManager.DataFactory.Models.HiveServerType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HiveSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public HiveSource() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Query { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HiveThriftTransportProtocol : System.IEquatable<Azure.ResourceManager.DataFactory.Models.HiveThriftTransportProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HiveThriftTransportProtocol(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.HiveThriftTransportProtocol Binary { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.HiveThriftTransportProtocol Http { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.HiveThriftTransportProtocol Sasl { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.HiveThriftTransportProtocol other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.HiveThriftTransportProtocol left, Azure.ResourceManager.DataFactory.Models.HiveThriftTransportProtocol right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.HiveThriftTransportProtocol (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.HiveThriftTransportProtocol left, Azure.ResourceManager.DataFactory.Models.HiveThriftTransportProtocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HttpAuthenticationType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.HttpAuthenticationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HttpAuthenticationType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.HttpAuthenticationType Anonymous { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.HttpAuthenticationType Basic { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.HttpAuthenticationType ClientCertificate { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.HttpAuthenticationType Digest { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.HttpAuthenticationType Windows { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.HttpAuthenticationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.HttpAuthenticationType left, Azure.ResourceManager.DataFactory.Models.HttpAuthenticationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.HttpAuthenticationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.HttpAuthenticationType left, Azure.ResourceManager.DataFactory.Models.HttpAuthenticationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HttpLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public HttpLinkedService(Azure.Core.Expressions.DataFactory.DataFactoryElement<string> uri) { }
        public Azure.ResourceManager.DataFactory.Models.HttpAuthenticationType? AuthenticationType { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<System.BinaryData> AuthHeaders { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> CertThumbprint { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> EmbeddedCertData { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> EnableServerCertificateValidation { get { throw null; } set { } }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition Password { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Uri { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> UserName { get { throw null; } set { } }
    }
    public partial class HttpReadSettings : Azure.ResourceManager.DataFactory.Models.StoreReadSettings
    {
        public HttpReadSettings() { }
        public System.BinaryData AdditionalColumns { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> AdditionalHeaders { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> RequestBody { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> RequestMethod { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> RequestTimeout { get { throw null; } set { } }
    }
    public partial class HttpServerLocation : Azure.ResourceManager.DataFactory.Models.DatasetLocation
    {
        public HttpServerLocation() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> RelativeUri { get { throw null; } set { } }
    }
    public partial class HubspotLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public HubspotLinkedService(Azure.Core.Expressions.DataFactory.DataFactoryElement<string> clientId) { }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition AccessToken { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ClientId { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition ClientSecret { get { throw null; } set { } }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition RefreshToken { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> UseEncryptedEndpoints { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> UseHostVerification { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> UsePeerVerification { get { throw null; } set { } }
    }
    public partial class HubspotObjectDataset : Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetProperties
    {
        public HubspotObjectDataset(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName) : base (default(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference)) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> TableName { get { throw null; } set { } }
    }
    public partial class HubspotSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public HubspotSource() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Query { get { throw null; } set { } }
    }
    public partial class IfConditionActivity : Azure.ResourceManager.DataFactory.Models.ControlActivity
    {
        public IfConditionActivity(string name, Azure.ResourceManager.DataFactory.Models.DataFactoryExpression expression) : base (default(string)) { }
        public Azure.ResourceManager.DataFactory.Models.DataFactoryExpression Expression { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.PipelineActivity> IfFalseActivities { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.PipelineActivity> IfTrueActivities { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ImpalaAuthenticationType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.ImpalaAuthenticationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ImpalaAuthenticationType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.ImpalaAuthenticationType Anonymous { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.ImpalaAuthenticationType SaslUsername { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.ImpalaAuthenticationType UsernameAndPassword { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.ImpalaAuthenticationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.ImpalaAuthenticationType left, Azure.ResourceManager.DataFactory.Models.ImpalaAuthenticationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.ImpalaAuthenticationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.ImpalaAuthenticationType left, Azure.ResourceManager.DataFactory.Models.ImpalaAuthenticationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ImpalaLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public ImpalaLinkedService(Azure.Core.Expressions.DataFactory.DataFactoryElement<string> host, Azure.ResourceManager.DataFactory.Models.ImpalaAuthenticationType authenticationType) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> AllowHostNameCNMismatch { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> AllowSelfSignedServerCert { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.ImpalaAuthenticationType AuthenticationType { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> EnableSsl { get { throw null; } set { } }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Host { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition Password { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<int> Port { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> TrustedCertPath { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Username { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> UseSystemTrustStore { get { throw null; } set { } }
    }
    public partial class ImpalaObjectDataset : Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetProperties
    {
        public ImpalaObjectDataset(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName) : base (default(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference)) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> SchemaTypePropertiesSchema { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Table { get { throw null; } set { } }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class ImpalaSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public ImpalaSource() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Query { get { throw null; } set { } }
    }
    public partial class ImportSettings
    {
        public ImportSettings() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
    }
    public partial class InformixLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public InformixLinkedService(Azure.Core.Expressions.DataFactory.DataFactoryElement<string> connectionString) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> AuthenticationType { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ConnectionString { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition Credential { get { throw null; } set { } }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition Password { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> UserName { get { throw null; } set { } }
    }
    public partial class InformixSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public InformixSink() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> PreCopyScript { get { throw null; } set { } }
    }
    public partial class InformixSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public InformixSource() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Query { get { throw null; } set { } }
    }
    public partial class InformixTableDataset : Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetProperties
    {
        public InformixTableDataset(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName) : base (default(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference)) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> TableName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IntegrationRuntimeAuthKeyName : System.IEquatable<Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeAuthKeyName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IntegrationRuntimeAuthKeyName(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeAuthKeyName AuthKey1 { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeAuthKeyName AuthKey2 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeAuthKeyName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeAuthKeyName left, Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeAuthKeyName right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeAuthKeyName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeAuthKeyName left, Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeAuthKeyName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IntegrationRuntimeAuthKeys
    {
        internal IntegrationRuntimeAuthKeys() { }
        public string AuthKey1 { get { throw null; } }
        public string AuthKey2 { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IntegrationRuntimeAutoUpdateState : System.IEquatable<Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeAutoUpdateState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IntegrationRuntimeAutoUpdateState(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeAutoUpdateState Off { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeAutoUpdateState On { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeAutoUpdateState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeAutoUpdateState left, Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeAutoUpdateState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeAutoUpdateState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeAutoUpdateState left, Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeAutoUpdateState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IntegrationRuntimeComputeProperties
    {
        public IntegrationRuntimeComputeProperties() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.CopyComputeScaleProperties CopyComputeScaleProperties { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeDataFlowProperties DataFlowProperties { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public int? MaxParallelExecutionsPerNode { get { throw null; } set { } }
        public string NodeSize { get { throw null; } set { } }
        public int? NumberOfNodes { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.PipelineExternalComputeScaleProperties PipelineExternalComputeScaleProperties { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeVnetProperties VnetProperties { get { throw null; } set { } }
    }
    public partial class IntegrationRuntimeConnectionInfo
    {
        internal IntegrationRuntimeConnectionInfo() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public System.Uri HostServiceUri { get { throw null; } }
        public string IdentityCertThumbprint { get { throw null; } }
        public bool? IsIdentityCertExprired { get { throw null; } }
        public string PublicKey { get { throw null; } }
        public string ServiceToken { get { throw null; } }
        public string Version { get { throw null; } }
    }
    public partial class IntegrationRuntimeCustomSetupScriptProperties
    {
        public IntegrationRuntimeCustomSetupScriptProperties() { }
        public System.Uri BlobContainerUri { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretString SasToken { get { throw null; } set { } }
    }
    public partial class IntegrationRuntimeDataFlowCustomItem
    {
        public IntegrationRuntimeDataFlowCustomItem() { }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class IntegrationRuntimeDataFlowProperties
    {
        public IntegrationRuntimeDataFlowProperties() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.DataFlowComputeType? ComputeType { get { throw null; } set { } }
        public int? CoreCount { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeDataFlowCustomItem> CustomProperties { get { throw null; } }
        public bool? ShouldCleanupAfterTtl { get { throw null; } set { } }
        public int? TimeToLiveInMinutes { get { throw null; } set { } }
    }
    public partial class IntegrationRuntimeDataProxyProperties
    {
        public IntegrationRuntimeDataProxyProperties() { }
        public Azure.ResourceManager.DataFactory.Models.EntityReference ConnectVia { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.EntityReference StagingLinkedService { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IntegrationRuntimeEdition : System.IEquatable<Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeEdition>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IntegrationRuntimeEdition(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeEdition Enterprise { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeEdition Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeEdition other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeEdition left, Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeEdition right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeEdition (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeEdition left, Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeEdition right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IntegrationRuntimeEntityReferenceType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeEntityReferenceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IntegrationRuntimeEntityReferenceType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeEntityReferenceType IntegrationRuntimeReference { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeEntityReferenceType LinkedServiceReference { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeEntityReferenceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeEntityReferenceType left, Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeEntityReferenceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeEntityReferenceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeEntityReferenceType left, Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeEntityReferenceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IntegrationRuntimeInternalChannelEncryptionMode : System.IEquatable<Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeInternalChannelEncryptionMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IntegrationRuntimeInternalChannelEncryptionMode(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeInternalChannelEncryptionMode NotEncrypted { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeInternalChannelEncryptionMode NotSet { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeInternalChannelEncryptionMode SslEncrypted { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeInternalChannelEncryptionMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeInternalChannelEncryptionMode left, Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeInternalChannelEncryptionMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeInternalChannelEncryptionMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeInternalChannelEncryptionMode left, Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeInternalChannelEncryptionMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IntegrationRuntimeLicenseType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeLicenseType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IntegrationRuntimeLicenseType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeLicenseType BasePrice { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeLicenseType LicenseIncluded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeLicenseType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeLicenseType left, Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeLicenseType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeLicenseType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeLicenseType left, Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeLicenseType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IntegrationRuntimeMonitoringData
    {
        internal IntegrationRuntimeMonitoringData() { }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeNodeMonitoringData> Nodes { get { throw null; } }
    }
    public partial class IntegrationRuntimeNodeIPAddress
    {
        internal IntegrationRuntimeNodeIPAddress() { }
        public System.Net.IPAddress IPAddress { get { throw null; } }
    }
    public partial class IntegrationRuntimeNodeMonitoringData
    {
        internal IntegrationRuntimeNodeMonitoringData() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public int? AvailableMemoryInMB { get { throw null; } }
        public int? ConcurrentJobsLimit { get { throw null; } }
        public int? ConcurrentJobsRunning { get { throw null; } }
        public int? CpuUtilization { get { throw null; } }
        public int? MaxConcurrentJobs { get { throw null; } }
        public string NodeName { get { throw null; } }
        public float? ReceivedBytes { get { throw null; } }
        public float? SentBytes { get { throw null; } }
    }
    public partial class IntegrationRuntimeOutboundNetworkDependenciesCategoryEndpoint
    {
        internal IntegrationRuntimeOutboundNetworkDependenciesCategoryEndpoint() { }
        public string Category { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeOutboundNetworkDependenciesEndpoint> Endpoints { get { throw null; } }
    }
    public partial class IntegrationRuntimeOutboundNetworkDependenciesEndpoint
    {
        internal IntegrationRuntimeOutboundNetworkDependenciesEndpoint() { }
        public string DomainName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeOutboundNetworkDependenciesEndpointDetails> EndpointDetails { get { throw null; } }
    }
    public partial class IntegrationRuntimeOutboundNetworkDependenciesEndpointDetails
    {
        internal IntegrationRuntimeOutboundNetworkDependenciesEndpointDetails() { }
        public int? Port { get { throw null; } }
    }
    public partial class IntegrationRuntimeReference
    {
        public IntegrationRuntimeReference(Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeReferenceType referenceType, string referenceName) { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Parameters { get { throw null; } }
        public string ReferenceName { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeReferenceType ReferenceType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IntegrationRuntimeReferenceType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeReferenceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IntegrationRuntimeReferenceType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeReferenceType IntegrationRuntimeReference { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeReferenceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeReferenceType left, Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeReferenceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeReferenceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeReferenceType left, Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeReferenceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IntegrationRuntimeRegenerateKeyContent
    {
        public IntegrationRuntimeRegenerateKeyContent() { }
        public Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeAuthKeyName? KeyName { get { throw null; } set { } }
    }
    public partial class IntegrationRuntimeSsisCatalogInfo
    {
        public IntegrationRuntimeSsisCatalogInfo() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretString CatalogAdminPassword { get { throw null; } set { } }
        public string CatalogAdminUserName { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeSsisCatalogPricingTier? CatalogPricingTier { get { throw null; } set { } }
        public string CatalogServerEndpoint { get { throw null; } set { } }
        public string DualStandbyPairName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IntegrationRuntimeSsisCatalogPricingTier : System.IEquatable<Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeSsisCatalogPricingTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IntegrationRuntimeSsisCatalogPricingTier(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeSsisCatalogPricingTier Basic { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeSsisCatalogPricingTier Premium { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeSsisCatalogPricingTier PremiumRS { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeSsisCatalogPricingTier Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeSsisCatalogPricingTier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeSsisCatalogPricingTier left, Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeSsisCatalogPricingTier right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeSsisCatalogPricingTier (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeSsisCatalogPricingTier left, Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeSsisCatalogPricingTier right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IntegrationRuntimeSsisProperties
    {
        public IntegrationRuntimeSsisProperties() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeSsisCatalogInfo CatalogInfo { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DataFactoryCredentialReference Credential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeCustomSetupScriptProperties CustomSetupScriptProperties { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeDataProxyProperties DataProxyProperties { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeEdition? Edition { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.CustomSetupBase> ExpressCustomSetupProperties { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeLicenseType? LicenseType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.DataFactoryPackageStore> PackageStores { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IntegrationRuntimeState : System.IEquatable<Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IntegrationRuntimeState(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeState AccessDenied { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeState Initial { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeState Limited { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeState NeedRegistration { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeState Offline { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeState Online { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeState Started { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeState Starting { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeState Stopped { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeState Stopping { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeState left, Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeState left, Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IntegrationRuntimeStatus
    {
        internal IntegrationRuntimeStatus() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public string DataFactoryName { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeState? State { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IntegrationRuntimeUpdateResult : System.IEquatable<Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeUpdateResult>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IntegrationRuntimeUpdateResult(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeUpdateResult Fail { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeUpdateResult None { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeUpdateResult Succeed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeUpdateResult other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeUpdateResult left, Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeUpdateResult right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeUpdateResult (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeUpdateResult left, Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeUpdateResult right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IntegrationRuntimeVnetProperties
    {
        public IntegrationRuntimeVnetProperties() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public System.Collections.Generic.IList<string> PublicIPs { get { throw null; } }
        public string Subnet { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
        public System.Guid? VnetId { get { throw null; } set { } }
    }
    public partial class JiraLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public JiraLinkedService(Azure.Core.Expressions.DataFactory.DataFactoryElement<string> host, Azure.Core.Expressions.DataFactory.DataFactoryElement<string> username) { }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Host { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition Password { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<int> Port { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> UseEncryptedEndpoints { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> UseHostVerification { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> UsePeerVerification { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Username { get { throw null; } set { } }
    }
    public partial class JiraObjectDataset : Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetProperties
    {
        public JiraObjectDataset(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName) : base (default(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference)) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> TableName { get { throw null; } set { } }
    }
    public partial class JiraSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public JiraSource() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Query { get { throw null; } set { } }
    }
    public partial class JsonDataset : Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetProperties
    {
        public JsonDataset(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName) : base (default(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference)) { }
        public Azure.ResourceManager.DataFactory.Models.DatasetCompression Compression { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DatasetLocation DataLocation { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> EncodingName { get { throw null; } set { } }
    }
    public partial class JsonReadSettings : Azure.ResourceManager.DataFactory.Models.FormatReadSettings
    {
        public JsonReadSettings() { }
        public Azure.ResourceManager.DataFactory.Models.CompressionReadSettings CompressionProperties { get { throw null; } set { } }
    }
    public partial class JsonSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public JsonSink() { }
        public Azure.ResourceManager.DataFactory.Models.JsonWriteSettings FormatSettings { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.StoreWriteSettings StoreSettings { get { throw null; } set { } }
    }
    public partial class JsonSource : Azure.ResourceManager.DataFactory.Models.CopyActivitySource
    {
        public JsonSource() { }
        public System.BinaryData AdditionalColumns { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.JsonReadSettings FormatSettings { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.StoreReadSettings StoreSettings { get { throw null; } set { } }
    }
    public partial class JsonWriteSettings : Azure.ResourceManager.DataFactory.Models.FormatWriteSettings
    {
        public JsonWriteSettings() { }
        public System.BinaryData FilePattern { get { throw null; } set { } }
    }
    public partial class LinkedIntegrationRuntime
    {
        internal LinkedIntegrationRuntime() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.Core.AzureLocation? DataFactoryLocation { get { throw null; } }
        public string DataFactoryName { get { throw null; } }
        public string Name { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
    }
    public partial class LinkedIntegrationRuntimeContent
    {
        public LinkedIntegrationRuntimeContent(string linkedFactoryName) { }
        public string LinkedFactoryName { get { throw null; } }
    }
    public partial class LinkedIntegrationRuntimeKeyAuthorization : Azure.ResourceManager.DataFactory.Models.LinkedIntegrationRuntimeType
    {
        public LinkedIntegrationRuntimeKeyAuthorization(Azure.Core.Expressions.DataFactory.DataFactorySecretString key) { }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretString Key { get { throw null; } set { } }
    }
    public partial class LinkedIntegrationRuntimeRbacAuthorization : Azure.ResourceManager.DataFactory.Models.LinkedIntegrationRuntimeType
    {
        public LinkedIntegrationRuntimeRbacAuthorization(Azure.Core.ResourceIdentifier resourceId) { }
        public Azure.ResourceManager.DataFactory.Models.DataFactoryCredentialReference Credential { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
    }
    public abstract partial class LinkedIntegrationRuntimeType
    {
        protected LinkedIntegrationRuntimeType() { }
    }
    public partial class LogLocationSettings
    {
        public LogLocationSettings(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference LinkedServiceName { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Path { get { throw null; } set { } }
    }
    public partial class LogStorageSettings
    {
        public LogStorageSettings(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName) { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> EnableReliableLogging { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference LinkedServiceName { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> LogLevel { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Path { get { throw null; } set { } }
    }
    public partial class LookupActivity : Azure.ResourceManager.DataFactory.Models.ExecutionActivity
    {
        public LookupActivity(string name, Azure.ResourceManager.DataFactory.Models.CopyActivitySource source, Azure.ResourceManager.DataFactory.Models.DatasetReference dataset) : base (default(string)) { }
        public Azure.ResourceManager.DataFactory.Models.DatasetReference Dataset { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> FirstRowOnly { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.CopyActivitySource Source { get { throw null; } set { } }
    }
    public partial class MagentoLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public MagentoLinkedService(Azure.Core.Expressions.DataFactory.DataFactoryElement<string> host) { }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition AccessToken { get { throw null; } set { } }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Host { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> UseEncryptedEndpoints { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> UseHostVerification { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> UsePeerVerification { get { throw null; } set { } }
    }
    public partial class MagentoObjectDataset : Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetProperties
    {
        public MagentoObjectDataset(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName) : base (default(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference)) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> TableName { get { throw null; } set { } }
    }
    public partial class MagentoSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public MagentoSource() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Query { get { throw null; } set { } }
    }
    public partial class ManagedIntegrationRuntime : Azure.ResourceManager.DataFactory.Models.DataFactoryIntegrationRuntimeProperties
    {
        public ManagedIntegrationRuntime() { }
        public Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeComputeProperties ComputeProperties { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier CustomerVirtualNetworkSubnetId { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.ManagedVirtualNetworkReference ManagedVirtualNetwork { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeSsisProperties SsisProperties { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeState? State { get { throw null; } }
    }
    public partial class ManagedIntegrationRuntimeError
    {
        internal ManagedIntegrationRuntimeError() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Parameters { get { throw null; } }
        public System.DateTimeOffset? Time { get { throw null; } }
    }
    public partial class ManagedIntegrationRuntimeNode
    {
        internal ManagedIntegrationRuntimeNode() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataFactory.Models.ManagedIntegrationRuntimeError> Errors { get { throw null; } }
        public string NodeId { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.ManagedIntegrationRuntimeNodeStatus? Status { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedIntegrationRuntimeNodeStatus : System.IEquatable<Azure.ResourceManager.DataFactory.Models.ManagedIntegrationRuntimeNodeStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedIntegrationRuntimeNodeStatus(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.ManagedIntegrationRuntimeNodeStatus Available { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.ManagedIntegrationRuntimeNodeStatus Recycling { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.ManagedIntegrationRuntimeNodeStatus Starting { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.ManagedIntegrationRuntimeNodeStatus Unavailable { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.ManagedIntegrationRuntimeNodeStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.ManagedIntegrationRuntimeNodeStatus left, Azure.ResourceManager.DataFactory.Models.ManagedIntegrationRuntimeNodeStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.ManagedIntegrationRuntimeNodeStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.ManagedIntegrationRuntimeNodeStatus left, Azure.ResourceManager.DataFactory.Models.ManagedIntegrationRuntimeNodeStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ManagedIntegrationRuntimeOperationResult
    {
        internal ManagedIntegrationRuntimeOperationResult() { }
        public string ActivityId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public string ErrorCode { get { throw null; } }
        public string ManagedIntegrationRuntimeOperationResultType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Parameters { get { throw null; } }
        public string Result { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
    }
    public partial class ManagedIntegrationRuntimeStatus : Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeStatus
    {
        internal ManagedIntegrationRuntimeStatus() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.ManagedIntegrationRuntimeOperationResult LastOperation { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataFactory.Models.ManagedIntegrationRuntimeNode> Nodes { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataFactory.Models.ManagedIntegrationRuntimeError> OtherErrors { get { throw null; } }
    }
    public partial class ManagedVirtualNetworkReference
    {
        public ManagedVirtualNetworkReference(Azure.ResourceManager.DataFactory.Models.ManagedVirtualNetworkReferenceType referenceType, string referenceName) { }
        public string ReferenceName { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.ManagedVirtualNetworkReferenceType ReferenceType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedVirtualNetworkReferenceType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.ManagedVirtualNetworkReferenceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedVirtualNetworkReferenceType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.ManagedVirtualNetworkReferenceType ManagedVirtualNetworkReference { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.ManagedVirtualNetworkReferenceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.ManagedVirtualNetworkReferenceType left, Azure.ResourceManager.DataFactory.Models.ManagedVirtualNetworkReferenceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.ManagedVirtualNetworkReferenceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.ManagedVirtualNetworkReferenceType left, Azure.ResourceManager.DataFactory.Models.ManagedVirtualNetworkReferenceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MapperAttributeMapping
    {
        public MapperAttributeMapping() { }
        public Azure.ResourceManager.DataFactory.Models.MapperAttributeReference AttributeReference { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.MapperAttributeReference> AttributeReferences { get { throw null; } }
        public string Expression { get { throw null; } set { } }
        public string FunctionName { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.MappingType? MappingType { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    public partial class MapperAttributeReference
    {
        public MapperAttributeReference() { }
        public string Entity { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.MapperConnectionReference EntityConnectionReference { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    public partial class MapperConnection
    {
        public MapperConnection(Azure.ResourceManager.DataFactory.Models.MapperConnectionType connectionType) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.MapperDslConnectorProperties> CommonDslConnectorProperties { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.MapperConnectionType ConnectionType { get { throw null; } set { } }
        public bool? IsInlineDataset { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference LinkedService { get { throw null; } set { } }
        public string LinkedServiceType { get { throw null; } set { } }
    }
    public partial class MapperConnectionReference
    {
        public MapperConnectionReference() { }
        public string ConnectionName { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.MapperConnectionType? ConnectionType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MapperConnectionType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.MapperConnectionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MapperConnectionType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.MapperConnectionType Linkedservicetype { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.MapperConnectionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.MapperConnectionType left, Azure.ResourceManager.DataFactory.Models.MapperConnectionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.MapperConnectionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.MapperConnectionType left, Azure.ResourceManager.DataFactory.Models.MapperConnectionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MapperDslConnectorProperties
    {
        public MapperDslConnectorProperties() { }
        public string Name { get { throw null; } set { } }
        public System.BinaryData Value { get { throw null; } set { } }
    }
    public partial class MapperPolicy
    {
        public MapperPolicy() { }
        public string Mode { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.MapperPolicyRecurrence Recurrence { get { throw null; } set { } }
    }
    public partial class MapperPolicyRecurrence
    {
        public MapperPolicyRecurrence() { }
        public Azure.ResourceManager.DataFactory.Models.MapperPolicyRecurrenceFrequencyType? Frequency { get { throw null; } set { } }
        public int? Interval { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MapperPolicyRecurrenceFrequencyType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.MapperPolicyRecurrenceFrequencyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MapperPolicyRecurrenceFrequencyType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.MapperPolicyRecurrenceFrequencyType Hour { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.MapperPolicyRecurrenceFrequencyType Minute { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.MapperPolicyRecurrenceFrequencyType Second { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.MapperPolicyRecurrenceFrequencyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.MapperPolicyRecurrenceFrequencyType left, Azure.ResourceManager.DataFactory.Models.MapperPolicyRecurrenceFrequencyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.MapperPolicyRecurrenceFrequencyType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.MapperPolicyRecurrenceFrequencyType left, Azure.ResourceManager.DataFactory.Models.MapperPolicyRecurrenceFrequencyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MapperSourceConnectionsInfo
    {
        public MapperSourceConnectionsInfo() { }
        public Azure.ResourceManager.DataFactory.Models.MapperConnection Connection { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.MapperTable> SourceEntities { get { throw null; } }
    }
    public partial class MapperTable
    {
        public MapperTable() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.MapperDslConnectorProperties> DslConnectorProperties { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.MapperTableSchema> Schema { get { throw null; } }
    }
    public partial class MapperTableSchema
    {
        public MapperTableSchema() { }
        public string DataType { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    public partial class MapperTargetConnectionsInfo
    {
        public MapperTargetConnectionsInfo() { }
        public Azure.ResourceManager.DataFactory.Models.MapperConnection Connection { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.DataMapperMapping> DataMapperMappings { get { throw null; } }
        public System.Collections.Generic.IList<System.BinaryData> Relationships { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.MapperTable> TargetEntities { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MappingType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.MappingType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MappingType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.MappingType Aggregate { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.MappingType Derived { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.MappingType Direct { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.MappingType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.MappingType left, Azure.ResourceManager.DataFactory.Models.MappingType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.MappingType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.MappingType left, Azure.ResourceManager.DataFactory.Models.MappingType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MariaDBLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public MariaDBLinkedService() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ConnectionString { get { throw null; } set { } }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryKeyVaultSecretReference Password { get { throw null; } set { } }
    }
    public partial class MariaDBSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public MariaDBSource() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Query { get { throw null; } set { } }
    }
    public partial class MariaDBTableDataset : Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetProperties
    {
        public MariaDBTableDataset(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName) : base (default(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference)) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> TableName { get { throw null; } set { } }
    }
    public partial class MarketoLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public MarketoLinkedService(Azure.Core.Expressions.DataFactory.DataFactoryElement<string> endpoint, Azure.Core.Expressions.DataFactory.DataFactoryElement<string> clientId) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ClientId { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition ClientSecret { get { throw null; } set { } }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Endpoint { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> UseEncryptedEndpoints { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> UseHostVerification { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> UsePeerVerification { get { throw null; } set { } }
    }
    public partial class MarketoObjectDataset : Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetProperties
    {
        public MarketoObjectDataset(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName) : base (default(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference)) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> TableName { get { throw null; } set { } }
    }
    public partial class MarketoSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public MarketoSource() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Query { get { throw null; } set { } }
    }
    public partial class MicrosoftAccessLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public MicrosoftAccessLinkedService(Azure.Core.Expressions.DataFactory.DataFactoryElement<string> connectionString) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> AuthenticationType { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ConnectionString { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition Credential { get { throw null; } set { } }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition Password { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> UserName { get { throw null; } set { } }
    }
    public partial class MicrosoftAccessSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public MicrosoftAccessSink() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> PreCopyScript { get { throw null; } set { } }
    }
    public partial class MicrosoftAccessSource : Azure.ResourceManager.DataFactory.Models.CopyActivitySource
    {
        public MicrosoftAccessSource() { }
        public System.BinaryData AdditionalColumns { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Query { get { throw null; } set { } }
    }
    public partial class MicrosoftAccessTableDataset : Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetProperties
    {
        public MicrosoftAccessTableDataset(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName) : base (default(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference)) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> TableName { get { throw null; } set { } }
    }
    public partial class MongoDBAtlasCollectionDataset : Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetProperties
    {
        public MongoDBAtlasCollectionDataset(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName, Azure.Core.Expressions.DataFactory.DataFactoryElement<string> collection) : base (default(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference)) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Collection { get { throw null; } set { } }
    }
    public partial class MongoDBAtlasLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public MongoDBAtlasLinkedService(Azure.Core.Expressions.DataFactory.DataFactoryElement<string> connectionString, Azure.Core.Expressions.DataFactory.DataFactoryElement<string> database) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ConnectionString { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Database { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> DriverVersion { get { throw null; } set { } }
    }
    public partial class MongoDBAtlasSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public MongoDBAtlasSink() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> WriteBehavior { get { throw null; } set { } }
    }
    public partial class MongoDBAtlasSource : Azure.ResourceManager.DataFactory.Models.CopyActivitySource
    {
        public MongoDBAtlasSource() { }
        public System.BinaryData AdditionalColumns { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<int> BatchSize { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.MongoDBCursorMethodsProperties CursorMethods { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Filter { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> QueryTimeout { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MongoDBAuthenticationType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.MongoDBAuthenticationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MongoDBAuthenticationType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.MongoDBAuthenticationType Anonymous { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.MongoDBAuthenticationType Basic { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.MongoDBAuthenticationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.MongoDBAuthenticationType left, Azure.ResourceManager.DataFactory.Models.MongoDBAuthenticationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.MongoDBAuthenticationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.MongoDBAuthenticationType left, Azure.ResourceManager.DataFactory.Models.MongoDBAuthenticationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MongoDBCollectionDataset : Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetProperties
    {
        public MongoDBCollectionDataset(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName, Azure.Core.Expressions.DataFactory.DataFactoryElement<string> collectionName) : base (default(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference)) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> CollectionName { get { throw null; } set { } }
    }
    public partial class MongoDBCursorMethodsProperties
    {
        public MongoDBCursorMethodsProperties() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<int> Limit { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Project { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<int> Skip { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Sort { get { throw null; } set { } }
    }
    public partial class MongoDBLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public MongoDBLinkedService(Azure.Core.Expressions.DataFactory.DataFactoryElement<string> server, Azure.Core.Expressions.DataFactory.DataFactoryElement<string> databaseName) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> AllowSelfSignedServerCert { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.MongoDBAuthenticationType? AuthenticationType { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> AuthSource { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> DatabaseName { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> EnableSsl { get { throw null; } set { } }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition Password { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<int> Port { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Server { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Username { get { throw null; } set { } }
    }
    public partial class MongoDBSource : Azure.ResourceManager.DataFactory.Models.CopyActivitySource
    {
        public MongoDBSource() { }
        public System.BinaryData AdditionalColumns { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Query { get { throw null; } set { } }
    }
    public partial class MongoDBV2CollectionDataset : Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetProperties
    {
        public MongoDBV2CollectionDataset(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName, Azure.Core.Expressions.DataFactory.DataFactoryElement<string> collection) : base (default(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference)) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Collection { get { throw null; } set { } }
    }
    public partial class MongoDBV2LinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public MongoDBV2LinkedService(Azure.Core.Expressions.DataFactory.DataFactoryElement<string> connectionString, Azure.Core.Expressions.DataFactory.DataFactoryElement<string> database) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ConnectionString { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Database { get { throw null; } set { } }
    }
    public partial class MongoDBV2Sink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public MongoDBV2Sink() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> WriteBehavior { get { throw null; } set { } }
    }
    public partial class MongoDBV2Source : Azure.ResourceManager.DataFactory.Models.CopyActivitySource
    {
        public MongoDBV2Source() { }
        public System.BinaryData AdditionalColumns { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<int> BatchSize { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.MongoDBCursorMethodsProperties CursorMethods { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Filter { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> QueryTimeout { get { throw null; } set { } }
    }
    public partial class MultiplePipelineTrigger : Azure.ResourceManager.DataFactory.Models.DataFactoryTriggerProperties
    {
        public MultiplePipelineTrigger() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.TriggerPipelineReference> Pipelines { get { throw null; } }
    }
    public partial class MySqlLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public MySqlLinkedService(Azure.Core.Expressions.DataFactory.DataFactoryElement<string> connectionString) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ConnectionString { get { throw null; } set { } }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryKeyVaultSecretReference Password { get { throw null; } set { } }
    }
    public partial class MySqlSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public MySqlSource() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Query { get { throw null; } set { } }
    }
    public partial class MySqlTableDataset : Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetProperties
    {
        public MySqlTableDataset(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName) : base (default(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference)) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> TableName { get { throw null; } set { } }
    }
    public partial class NetezzaLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public NetezzaLinkedService() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ConnectionString { get { throw null; } set { } }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryKeyVaultSecretReference Password { get { throw null; } set { } }
    }
    public partial class NetezzaPartitionSettings
    {
        public NetezzaPartitionSettings() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> PartitionColumnName { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> PartitionLowerBound { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> PartitionUpperBound { get { throw null; } set { } }
    }
    public partial class NetezzaSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public NetezzaSource() { }
        public System.BinaryData PartitionOption { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.NetezzaPartitionSettings PartitionSettings { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Query { get { throw null; } set { } }
    }
    public partial class NetezzaTableDataset : Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetProperties
    {
        public NetezzaTableDataset(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName) : base (default(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference)) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> SchemaTypePropertiesSchema { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Table { get { throw null; } set { } }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class NotebookParameter
    {
        public NotebookParameter() { }
        public Azure.ResourceManager.DataFactory.Models.NotebookParameterType? ParameterType { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Value { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NotebookParameterType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.NotebookParameterType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NotebookParameterType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.NotebookParameterType Bool { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.NotebookParameterType Float { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.NotebookParameterType Int { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.NotebookParameterType String { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.NotebookParameterType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.NotebookParameterType left, Azure.ResourceManager.DataFactory.Models.NotebookParameterType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.NotebookParameterType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.NotebookParameterType left, Azure.ResourceManager.DataFactory.Models.NotebookParameterType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NotebookReferenceType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.NotebookReferenceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NotebookReferenceType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.NotebookReferenceType NotebookReference { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.NotebookReferenceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.NotebookReferenceType left, Azure.ResourceManager.DataFactory.Models.NotebookReferenceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.NotebookReferenceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.NotebookReferenceType left, Azure.ResourceManager.DataFactory.Models.NotebookReferenceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ODataAadServicePrincipalCredentialType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.ODataAadServicePrincipalCredentialType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ODataAadServicePrincipalCredentialType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.ODataAadServicePrincipalCredentialType ServicePrincipalCert { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.ODataAadServicePrincipalCredentialType ServicePrincipalKey { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.ODataAadServicePrincipalCredentialType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.ODataAadServicePrincipalCredentialType left, Azure.ResourceManager.DataFactory.Models.ODataAadServicePrincipalCredentialType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.ODataAadServicePrincipalCredentialType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.ODataAadServicePrincipalCredentialType left, Azure.ResourceManager.DataFactory.Models.ODataAadServicePrincipalCredentialType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ODataAuthenticationType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.ODataAuthenticationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ODataAuthenticationType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.ODataAuthenticationType AadServicePrincipal { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.ODataAuthenticationType Anonymous { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.ODataAuthenticationType Basic { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.ODataAuthenticationType ManagedServiceIdentity { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.ODataAuthenticationType Windows { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.ODataAuthenticationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.ODataAuthenticationType left, Azure.ResourceManager.DataFactory.Models.ODataAuthenticationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.ODataAuthenticationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.ODataAuthenticationType left, Azure.ResourceManager.DataFactory.Models.ODataAuthenticationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ODataLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public ODataLinkedService(Azure.Core.Expressions.DataFactory.DataFactoryElement<string> uri) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> AadResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.ODataAadServicePrincipalCredentialType? AadServicePrincipalCredentialType { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.ODataAuthenticationType? AuthenticationType { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<System.BinaryData> AuthHeaders { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> AzureCloudType { get { throw null; } set { } }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition Password { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition ServicePrincipalEmbeddedCert { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition ServicePrincipalEmbeddedCertPassword { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ServicePrincipalId { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition ServicePrincipalKey { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Tenant { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Uri { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> UserName { get { throw null; } set { } }
    }
    public partial class ODataResourceDataset : Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetProperties
    {
        public ODataResourceDataset(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName) : base (default(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference)) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Path { get { throw null; } set { } }
    }
    public partial class ODataSource : Azure.ResourceManager.DataFactory.Models.CopyActivitySource
    {
        public ODataSource() { }
        public System.BinaryData AdditionalColumns { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> HttpRequestTimeout { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Query { get { throw null; } set { } }
    }
    public partial class OdbcLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public OdbcLinkedService(Azure.Core.Expressions.DataFactory.DataFactoryElement<string> connectionString) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> AuthenticationType { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ConnectionString { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition Credential { get { throw null; } set { } }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition Password { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> UserName { get { throw null; } set { } }
    }
    public partial class OdbcSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public OdbcSink() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> PreCopyScript { get { throw null; } set { } }
    }
    public partial class OdbcSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public OdbcSource() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Query { get { throw null; } set { } }
    }
    public partial class OdbcTableDataset : Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetProperties
    {
        public OdbcTableDataset(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName) : base (default(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference)) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> TableName { get { throw null; } set { } }
    }
    public partial class Office365Dataset : Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetProperties
    {
        public Office365Dataset(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName, Azure.Core.Expressions.DataFactory.DataFactoryElement<string> tableName) : base (default(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference)) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Predicate { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> TableName { get { throw null; } set { } }
    }
    public partial class Office365LinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public Office365LinkedService(Azure.Core.Expressions.DataFactory.DataFactoryElement<string> office365TenantId, Azure.Core.Expressions.DataFactory.DataFactoryElement<string> servicePrincipalTenantId, Azure.Core.Expressions.DataFactory.DataFactoryElement<string> servicePrincipalId, Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition servicePrincipalKey) { }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Office365TenantId { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ServicePrincipalId { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition ServicePrincipalKey { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ServicePrincipalTenantId { get { throw null; } set { } }
    }
    public partial class Office365Source : Azure.ResourceManager.DataFactory.Models.CopyActivitySource
    {
        public Office365Source() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<System.Collections.Generic.IList<string>> AllowedGroups { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> DateFilterColumn { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> EndOn { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.Office365TableOutputColumn>> OutputColumns { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> StartOn { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> UserScopeFilterUri { get { throw null; } set { } }
    }
    public partial class Office365TableOutputColumn
    {
        public Office365TableOutputColumn() { }
        public string Name { get { throw null; } set { } }
    }
    public partial class OracleCloudStorageLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public OracleCloudStorageLinkedService() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> AccessKeyId { get { throw null; } set { } }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition SecretAccessKey { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ServiceUri { get { throw null; } set { } }
    }
    public partial class OracleCloudStorageLocation : Azure.ResourceManager.DataFactory.Models.DatasetLocation
    {
        public OracleCloudStorageLocation() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> BucketName { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Version { get { throw null; } set { } }
    }
    public partial class OracleCloudStorageReadSettings : Azure.ResourceManager.DataFactory.Models.StoreReadSettings
    {
        public OracleCloudStorageReadSettings() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> DeleteFilesAfterCompletion { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> EnablePartitionDiscovery { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> FileListPath { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ModifiedDatetimeEnd { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ModifiedDatetimeStart { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> PartitionRootPath { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Prefix { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> Recursive { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> WildcardFileName { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> WildcardFolderPath { get { throw null; } set { } }
    }
    public partial class OracleLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public OracleLinkedService(Azure.Core.Expressions.DataFactory.DataFactoryElement<string> connectionString) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ConnectionString { get { throw null; } set { } }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryKeyVaultSecretReference Password { get { throw null; } set { } }
    }
    public partial class OraclePartitionSettings
    {
        public OraclePartitionSettings() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> PartitionColumnName { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> PartitionLowerBound { get { throw null; } set { } }
        public System.BinaryData PartitionNames { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> PartitionUpperBound { get { throw null; } set { } }
    }
    public partial class OracleServiceCloudLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public OracleServiceCloudLinkedService(System.BinaryData host, System.BinaryData username, Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition password) { }
        public string EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData Host { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition Password { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> UseEncryptedEndpoints { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> UseHostVerification { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> UsePeerVerification { get { throw null; } set { } }
        public System.BinaryData Username { get { throw null; } set { } }
    }
    public partial class OracleServiceCloudObjectDataset : Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetProperties
    {
        public OracleServiceCloudObjectDataset(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName) : base (default(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference)) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> TableName { get { throw null; } set { } }
    }
    public partial class OracleServiceCloudSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public OracleServiceCloudSource() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Query { get { throw null; } set { } }
    }
    public partial class OracleSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public OracleSink() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> PreCopyScript { get { throw null; } set { } }
    }
    public partial class OracleSource : Azure.ResourceManager.DataFactory.Models.CopyActivitySource
    {
        public OracleSource() { }
        public System.BinaryData AdditionalColumns { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> OracleReaderQuery { get { throw null; } set { } }
        public System.BinaryData PartitionOption { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.OraclePartitionSettings PartitionSettings { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> QueryTimeout { get { throw null; } set { } }
    }
    public partial class OracleTableDataset : Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetProperties
    {
        public OracleTableDataset(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName) : base (default(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference)) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> SchemaTypePropertiesSchema { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Table { get { throw null; } set { } }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class OrcDataset : Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetProperties
    {
        public OrcDataset(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName) : base (default(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference)) { }
        public Azure.ResourceManager.DataFactory.Models.DatasetLocation DataLocation { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> OrcCompressionCodec { get { throw null; } set { } }
    }
    public partial class OrcSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public OrcSink() { }
        public Azure.ResourceManager.DataFactory.Models.OrcWriteSettings FormatSettings { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.StoreWriteSettings StoreSettings { get { throw null; } set { } }
    }
    public partial class OrcSource : Azure.ResourceManager.DataFactory.Models.CopyActivitySource
    {
        public OrcSource() { }
        public System.BinaryData AdditionalColumns { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.StoreReadSettings StoreSettings { get { throw null; } set { } }
    }
    public partial class OrcWriteSettings : Azure.ResourceManager.DataFactory.Models.FormatWriteSettings
    {
        public OrcWriteSettings() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> FileNamePrefix { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<int> MaxRowsPerFile { get { throw null; } set { } }
    }
    public partial class ParquetDataset : Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetProperties
    {
        public ParquetDataset(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName) : base (default(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference)) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> CompressionCodec { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DatasetLocation DataLocation { get { throw null; } set { } }
    }
    public partial class ParquetSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public ParquetSink() { }
        public Azure.ResourceManager.DataFactory.Models.ParquetWriteSettings FormatSettings { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.StoreWriteSettings StoreSettings { get { throw null; } set { } }
    }
    public partial class ParquetSource : Azure.ResourceManager.DataFactory.Models.CopyActivitySource
    {
        public ParquetSource() { }
        public System.BinaryData AdditionalColumns { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.StoreReadSettings StoreSettings { get { throw null; } set { } }
    }
    public partial class ParquetWriteSettings : Azure.ResourceManager.DataFactory.Models.FormatWriteSettings
    {
        public ParquetWriteSettings() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> FileNamePrefix { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<int> MaxRowsPerFile { get { throw null; } set { } }
    }
    public partial class PaypalLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public PaypalLinkedService(Azure.Core.Expressions.DataFactory.DataFactoryElement<string> host, Azure.Core.Expressions.DataFactory.DataFactoryElement<string> clientId) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ClientId { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition ClientSecret { get { throw null; } set { } }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Host { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> UseEncryptedEndpoints { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> UseHostVerification { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> UsePeerVerification { get { throw null; } set { } }
    }
    public partial class PaypalObjectDataset : Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetProperties
    {
        public PaypalObjectDataset(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName) : base (default(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference)) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> TableName { get { throw null; } set { } }
    }
    public partial class PaypalSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public PaypalSource() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Query { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PhoenixAuthenticationType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.PhoenixAuthenticationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PhoenixAuthenticationType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.PhoenixAuthenticationType Anonymous { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.PhoenixAuthenticationType UsernameAndPassword { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.PhoenixAuthenticationType WindowsAzureHDInsightService { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.PhoenixAuthenticationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.PhoenixAuthenticationType left, Azure.ResourceManager.DataFactory.Models.PhoenixAuthenticationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.PhoenixAuthenticationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.PhoenixAuthenticationType left, Azure.ResourceManager.DataFactory.Models.PhoenixAuthenticationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PhoenixLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public PhoenixLinkedService(Azure.Core.Expressions.DataFactory.DataFactoryElement<string> host, Azure.ResourceManager.DataFactory.Models.PhoenixAuthenticationType authenticationType) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> AllowHostNameCNMismatch { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> AllowSelfSignedServerCert { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.PhoenixAuthenticationType AuthenticationType { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> EnableSsl { get { throw null; } set { } }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Host { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> HttpPath { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition Password { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<int> Port { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> TrustedCertPath { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Username { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> UseSystemTrustStore { get { throw null; } set { } }
    }
    public partial class PhoenixObjectDataset : Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetProperties
    {
        public PhoenixObjectDataset(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName) : base (default(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference)) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> SchemaTypePropertiesSchema { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Table { get { throw null; } set { } }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class PhoenixSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public PhoenixSource() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Query { get { throw null; } set { } }
    }
    public partial class PipelineActivity
    {
        public PipelineActivity(string name) { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.PipelineActivityDependency> DependsOn { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.ActivityOnInactiveMarkAs? OnInactiveMarkAs { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.PipelineActivityState? State { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.PipelineActivityUserProperty> UserProperties { get { throw null; } }
    }
    public partial class PipelineActivityDependency
    {
        public PipelineActivityDependency(string activity, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataFactory.Models.DependencyCondition> dependencyConditions) { }
        public string Activity { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.DependencyCondition> DependencyConditions { get { throw null; } }
    }
    public partial class PipelineActivityPolicy
    {
        public PipelineActivityPolicy() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public bool? IsSecureInputEnabled { get { throw null; } set { } }
        public bool? IsSecureOutputEnabled { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<int> Retry { get { throw null; } set { } }
        public int? RetryIntervalInSeconds { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Timeout { get { throw null; } set { } }
    }
    public partial class PipelineActivityRunInformation
    {
        internal PipelineActivityRunInformation() { }
        public string ActivityName { get { throw null; } }
        public System.Guid? ActivityRunId { get { throw null; } }
        public string ActivityType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public int? DurationInMs { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public System.BinaryData Error { get { throw null; } }
        public System.BinaryData Input { get { throw null; } }
        public string LinkedServiceName { get { throw null; } }
        public System.BinaryData Output { get { throw null; } }
        public string PipelineName { get { throw null; } }
        public System.Guid? PipelineRunId { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public string Status { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PipelineActivityState : System.IEquatable<Azure.ResourceManager.DataFactory.Models.PipelineActivityState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PipelineActivityState(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.PipelineActivityState Active { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.PipelineActivityState Inactive { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.PipelineActivityState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.PipelineActivityState left, Azure.ResourceManager.DataFactory.Models.PipelineActivityState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.PipelineActivityState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.PipelineActivityState left, Azure.ResourceManager.DataFactory.Models.PipelineActivityState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PipelineActivityUserProperty
    {
        public PipelineActivityUserProperty(string name, Azure.Core.Expressions.DataFactory.DataFactoryElement<string> value) { }
        public string Name { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Value { get { throw null; } set { } }
    }
    public partial class PipelineCreateRunResult
    {
        internal PipelineCreateRunResult() { }
        public System.Guid RunId { get { throw null; } }
    }
    public partial class PipelineExternalComputeScaleProperties
    {
        public PipelineExternalComputeScaleProperties() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public int? NumberOfExternalNodes { get { throw null; } set { } }
        public int? NumberOfPipelineNodes { get { throw null; } set { } }
        public int? TimeToLive { get { throw null; } set { } }
    }
    public partial class PipelineVariableSpecification
    {
        public PipelineVariableSpecification(Azure.ResourceManager.DataFactory.Models.PipelineVariableType variableType) { }
        public System.BinaryData DefaultValue { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.PipelineVariableType VariableType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PipelineVariableType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.PipelineVariableType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PipelineVariableType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.PipelineVariableType Array { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.PipelineVariableType Bool { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.PipelineVariableType String { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.PipelineVariableType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.PipelineVariableType left, Azure.ResourceManager.DataFactory.Models.PipelineVariableType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.PipelineVariableType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.PipelineVariableType left, Azure.ResourceManager.DataFactory.Models.PipelineVariableType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PolybaseSettings
    {
        public PolybaseSettings() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<int> RejectSampleValue { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.PolybaseSettingsRejectType? RejectType { get { throw null; } set { } }
        public System.BinaryData RejectValue { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> UseTypeDefault { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PolybaseSettingsRejectType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.PolybaseSettingsRejectType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PolybaseSettingsRejectType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.PolybaseSettingsRejectType Percentage { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.PolybaseSettingsRejectType Value { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.PolybaseSettingsRejectType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.PolybaseSettingsRejectType left, Azure.ResourceManager.DataFactory.Models.PolybaseSettingsRejectType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.PolybaseSettingsRejectType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.PolybaseSettingsRejectType left, Azure.ResourceManager.DataFactory.Models.PolybaseSettingsRejectType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PostgreSqlLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public PostgreSqlLinkedService(Azure.Core.Expressions.DataFactory.DataFactoryElement<string> connectionString) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ConnectionString { get { throw null; } set { } }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryKeyVaultSecretReference Password { get { throw null; } set { } }
    }
    public partial class PostgreSqlSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public PostgreSqlSource() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Query { get { throw null; } set { } }
    }
    public partial class PostgreSqlTableDataset : Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetProperties
    {
        public PostgreSqlTableDataset(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName) : base (default(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference)) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> SchemaTypePropertiesSchema { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Table { get { throw null; } set { } }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class PowerQuerySink : Azure.ResourceManager.DataFactory.Models.DataFlowSink
    {
        public PowerQuerySink(string name) : base (default(string)) { }
        public string Script { get { throw null; } set { } }
    }
    public partial class PowerQuerySinkMapping
    {
        public PowerQuerySinkMapping() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.PowerQuerySink> DataflowSinks { get { throw null; } }
        public string QueryName { get { throw null; } set { } }
    }
    public partial class PowerQuerySource : Azure.ResourceManager.DataFactory.Models.DataFlowSource
    {
        public PowerQuerySource(string name) : base (default(string)) { }
        public string Script { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PrestoAuthenticationType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.PrestoAuthenticationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PrestoAuthenticationType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.PrestoAuthenticationType Anonymous { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.PrestoAuthenticationType Ldap { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.PrestoAuthenticationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.PrestoAuthenticationType left, Azure.ResourceManager.DataFactory.Models.PrestoAuthenticationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.PrestoAuthenticationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.PrestoAuthenticationType left, Azure.ResourceManager.DataFactory.Models.PrestoAuthenticationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PrestoLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public PrestoLinkedService(Azure.Core.Expressions.DataFactory.DataFactoryElement<string> host, Azure.Core.Expressions.DataFactory.DataFactoryElement<string> serverVersion, Azure.Core.Expressions.DataFactory.DataFactoryElement<string> catalog, Azure.ResourceManager.DataFactory.Models.PrestoAuthenticationType authenticationType) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> AllowHostNameCNMismatch { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> AllowSelfSignedServerCert { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.PrestoAuthenticationType AuthenticationType { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Catalog { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> EnableSsl { get { throw null; } set { } }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Host { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition Password { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<int> Port { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ServerVersion { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> TimeZoneId { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> TrustedCertPath { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Username { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> UseSystemTrustStore { get { throw null; } set { } }
    }
    public partial class PrestoObjectDataset : Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetProperties
    {
        public PrestoObjectDataset(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName) : base (default(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference)) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> SchemaTypePropertiesSchema { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Table { get { throw null; } set { } }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class PrestoSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public PrestoSource() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Query { get { throw null; } set { } }
    }
    public partial class PrivateLinkConnectionApprovalRequest
    {
        public PrivateLinkConnectionApprovalRequest() { }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.PrivateLinkConnectionState PrivateLinkServiceConnectionState { get { throw null; } set { } }
    }
    public partial class PrivateLinkConnectionState
    {
        public PrivateLinkConnectionState() { }
        public string ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string Status { get { throw null; } set { } }
    }
    public partial class QuickbaseLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public QuickbaseLinkedService(Azure.Core.Expressions.DataFactory.DataFactoryElement<string> uri, Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition userToken) { }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Uri { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition UserToken { get { throw null; } set { } }
    }
    public partial class QuickBooksLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public QuickBooksLinkedService() { }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition AccessToken { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition AccessTokenSecret { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> CompanyId { get { throw null; } set { } }
        public System.BinaryData ConnectionProperties { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ConsumerKey { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition ConsumerSecret { get { throw null; } set { } }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Endpoint { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> UseEncryptedEndpoints { get { throw null; } set { } }
    }
    public partial class QuickBooksObjectDataset : Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetProperties
    {
        public QuickBooksObjectDataset(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName) : base (default(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference)) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> TableName { get { throw null; } set { } }
    }
    public partial class QuickBooksSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public QuickBooksSource() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Query { get { throw null; } set { } }
    }
    public partial class RedirectIncompatibleRowSettings
    {
        public RedirectIncompatibleRowSettings(Azure.Core.Expressions.DataFactory.DataFactoryElement<string> linkedServiceName) { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> LinkedServiceName { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Path { get { throw null; } set { } }
    }
    public partial class RedshiftUnloadSettings
    {
        public RedshiftUnloadSettings(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference s3LinkedServiceName, Azure.Core.Expressions.DataFactory.DataFactoryElement<string> bucketName) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> BucketName { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference S3LinkedServiceName { get { throw null; } set { } }
    }
    public partial class RelationalSource : Azure.ResourceManager.DataFactory.Models.CopyActivitySource
    {
        public RelationalSource() { }
        public System.BinaryData AdditionalColumns { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Query { get { throw null; } set { } }
    }
    public partial class RelationalTableDataset : Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetProperties
    {
        public RelationalTableDataset(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName) : base (default(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference)) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> TableName { get { throw null; } set { } }
    }
    public partial class RerunTumblingWindowTrigger : Azure.ResourceManager.DataFactory.Models.DataFactoryTriggerProperties
    {
        public RerunTumblingWindowTrigger(System.BinaryData parentTrigger, System.DateTimeOffset requestedStartOn, System.DateTimeOffset requestedEndOn, int rerunConcurrency) { }
        public System.BinaryData ParentTrigger { get { throw null; } set { } }
        public System.DateTimeOffset RequestedEndOn { get { throw null; } set { } }
        public System.DateTimeOffset RequestedStartOn { get { throw null; } set { } }
        public int RerunConcurrency { get { throw null; } set { } }
    }
    public partial class ResponsysLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public ResponsysLinkedService(System.BinaryData endpoint, Azure.Core.Expressions.DataFactory.DataFactoryElement<string> clientId) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ClientId { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition ClientSecret { get { throw null; } set { } }
        public string EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData Endpoint { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> UseEncryptedEndpoints { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> UseHostVerification { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> UsePeerVerification { get { throw null; } set { } }
    }
    public partial class ResponsysObjectDataset : Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetProperties
    {
        public ResponsysObjectDataset(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName) : base (default(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference)) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> TableName { get { throw null; } set { } }
    }
    public partial class ResponsysSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public ResponsysSource() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Query { get { throw null; } set { } }
    }
    public partial class RestResourceDataset : Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetProperties
    {
        public RestResourceDataset(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName) : base (default(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference)) { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalHeaders { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> PaginationRules { get { throw null; } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> RelativeUri { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> RequestBody { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> RequestMethod { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RestServiceAuthenticationType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.RestServiceAuthenticationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RestServiceAuthenticationType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.RestServiceAuthenticationType AadServicePrincipal { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.RestServiceAuthenticationType Anonymous { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.RestServiceAuthenticationType Basic { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.RestServiceAuthenticationType ManagedServiceIdentity { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.RestServiceAuthenticationType OAuth2ClientCredential { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.RestServiceAuthenticationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.RestServiceAuthenticationType left, Azure.ResourceManager.DataFactory.Models.RestServiceAuthenticationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.RestServiceAuthenticationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.RestServiceAuthenticationType left, Azure.ResourceManager.DataFactory.Models.RestServiceAuthenticationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RestServiceLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public RestServiceLinkedService(Azure.Core.Expressions.DataFactory.DataFactoryElement<string> uri, Azure.ResourceManager.DataFactory.Models.RestServiceAuthenticationType authenticationType) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> AadResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.RestServiceAuthenticationType AuthenticationType { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<System.BinaryData> AuthHeaders { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> AzureCloudType { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ClientId { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition ClientSecret { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DataFactoryCredentialReference Credential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> EnableServerCertificateValidation { get { throw null; } set { } }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition Password { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Resource { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Scope { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ServicePrincipalId { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition ServicePrincipalKey { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Tenant { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> TokenEndpoint { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Uri { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> UserName { get { throw null; } set { } }
    }
    public partial class RestSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public RestSink() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> AdditionalHeaders { get { throw null; } set { } }
        public System.BinaryData HttpCompressionType { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> HttpRequestTimeout { get { throw null; } set { } }
        public System.BinaryData RequestInterval { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> RequestMethod { get { throw null; } set { } }
    }
    public partial class RestSource : Azure.ResourceManager.DataFactory.Models.CopyActivitySource
    {
        public RestSource() { }
        public System.BinaryData AdditionalColumns { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> AdditionalHeaders { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> HttpRequestTimeout { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> PaginationRules { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> RequestBody { get { throw null; } set { } }
        public System.BinaryData RequestInterval { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> RequestMethod { get { throw null; } set { } }
    }
    public partial class RetryPolicy
    {
        public RetryPolicy() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<int> Count { get { throw null; } set { } }
        public int? IntervalInSeconds { get { throw null; } set { } }
    }
    public partial class RunFilterContent
    {
        public RunFilterContent(System.DateTimeOffset lastUpdatedAfter, System.DateTimeOffset lastUpdatedBefore) { }
        public string ContinuationToken { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.RunQueryFilter> Filters { get { throw null; } }
        public System.DateTimeOffset LastUpdatedAfter { get { throw null; } }
        public System.DateTimeOffset LastUpdatedBefore { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.RunQueryOrderBy> OrderBy { get { throw null; } }
    }
    public partial class RunQueryFilter
    {
        public RunQueryFilter(Azure.ResourceManager.DataFactory.Models.RunQueryFilterOperand operand, Azure.ResourceManager.DataFactory.Models.RunQueryFilterOperator @operator, System.Collections.Generic.IEnumerable<string> values) { }
        public Azure.ResourceManager.DataFactory.Models.RunQueryFilterOperand Operand { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.RunQueryFilterOperator Operator { get { throw null; } }
        public System.Collections.Generic.IList<string> Values { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RunQueryFilterOperand : System.IEquatable<Azure.ResourceManager.DataFactory.Models.RunQueryFilterOperand>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RunQueryFilterOperand(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.RunQueryFilterOperand ActivityName { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.RunQueryFilterOperand ActivityRunEnd { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.RunQueryFilterOperand ActivityRunStart { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.RunQueryFilterOperand ActivityType { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.RunQueryFilterOperand LatestOnly { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.RunQueryFilterOperand PipelineName { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.RunQueryFilterOperand RunEnd { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.RunQueryFilterOperand RunGroupId { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.RunQueryFilterOperand RunStart { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.RunQueryFilterOperand Status { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.RunQueryFilterOperand TriggerName { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.RunQueryFilterOperand TriggerRunTimestamp { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.RunQueryFilterOperand other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.RunQueryFilterOperand left, Azure.ResourceManager.DataFactory.Models.RunQueryFilterOperand right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.RunQueryFilterOperand (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.RunQueryFilterOperand left, Azure.ResourceManager.DataFactory.Models.RunQueryFilterOperand right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RunQueryFilterOperator : System.IEquatable<Azure.ResourceManager.DataFactory.Models.RunQueryFilterOperator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RunQueryFilterOperator(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.RunQueryFilterOperator EqualsValue { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.RunQueryFilterOperator In { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.RunQueryFilterOperator NotEquals { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.RunQueryFilterOperator NotIn { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.RunQueryFilterOperator other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.RunQueryFilterOperator left, Azure.ResourceManager.DataFactory.Models.RunQueryFilterOperator right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.RunQueryFilterOperator (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.RunQueryFilterOperator left, Azure.ResourceManager.DataFactory.Models.RunQueryFilterOperator right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RunQueryOrder : System.IEquatable<Azure.ResourceManager.DataFactory.Models.RunQueryOrder>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RunQueryOrder(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.RunQueryOrder Asc { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.RunQueryOrder Desc { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.RunQueryOrder other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.RunQueryOrder left, Azure.ResourceManager.DataFactory.Models.RunQueryOrder right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.RunQueryOrder (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.RunQueryOrder left, Azure.ResourceManager.DataFactory.Models.RunQueryOrder right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RunQueryOrderBy
    {
        public RunQueryOrderBy(Azure.ResourceManager.DataFactory.Models.RunQueryOrderByField orderBy, Azure.ResourceManager.DataFactory.Models.RunQueryOrder order) { }
        public Azure.ResourceManager.DataFactory.Models.RunQueryOrder Order { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.RunQueryOrderByField OrderBy { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RunQueryOrderByField : System.IEquatable<Azure.ResourceManager.DataFactory.Models.RunQueryOrderByField>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RunQueryOrderByField(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.RunQueryOrderByField ActivityName { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.RunQueryOrderByField ActivityRunEnd { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.RunQueryOrderByField ActivityRunStart { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.RunQueryOrderByField PipelineName { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.RunQueryOrderByField RunEnd { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.RunQueryOrderByField RunStart { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.RunQueryOrderByField Status { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.RunQueryOrderByField TriggerName { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.RunQueryOrderByField TriggerRunTimestamp { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.RunQueryOrderByField other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.RunQueryOrderByField left, Azure.ResourceManager.DataFactory.Models.RunQueryOrderByField right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.RunQueryOrderByField (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.RunQueryOrderByField left, Azure.ResourceManager.DataFactory.Models.RunQueryOrderByField right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SalesforceLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public SalesforceLinkedService() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ApiVersion { get { throw null; } set { } }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> EnvironmentUri { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition Password { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition SecurityToken { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Username { get { throw null; } set { } }
    }
    public partial class SalesforceMarketingCloudLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public SalesforceMarketingCloudLinkedService() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ClientId { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition ClientSecret { get { throw null; } set { } }
        public System.BinaryData ConnectionProperties { get { throw null; } set { } }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> UseEncryptedEndpoints { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> UseHostVerification { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> UsePeerVerification { get { throw null; } set { } }
    }
    public partial class SalesforceMarketingCloudObjectDataset : Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetProperties
    {
        public SalesforceMarketingCloudObjectDataset(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName) : base (default(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference)) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> TableName { get { throw null; } set { } }
    }
    public partial class SalesforceMarketingCloudSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public SalesforceMarketingCloudSource() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Query { get { throw null; } set { } }
    }
    public partial class SalesforceObjectDataset : Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetProperties
    {
        public SalesforceObjectDataset(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName) : base (default(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference)) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ObjectApiName { get { throw null; } set { } }
    }
    public partial class SalesforceServiceCloudLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public SalesforceServiceCloudLinkedService() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ApiVersion { get { throw null; } set { } }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> EnvironmentUri { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ExtendedProperties { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition Password { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition SecurityToken { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Username { get { throw null; } set { } }
    }
    public partial class SalesforceServiceCloudObjectDataset : Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetProperties
    {
        public SalesforceServiceCloudObjectDataset(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName) : base (default(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference)) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ObjectApiName { get { throw null; } set { } }
    }
    public partial class SalesforceServiceCloudSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public SalesforceServiceCloudSink() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ExternalIdFieldName { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> IgnoreNullValues { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SalesforceSinkWriteBehavior? WriteBehavior { get { throw null; } set { } }
    }
    public partial class SalesforceServiceCloudSource : Azure.ResourceManager.DataFactory.Models.CopyActivitySource
    {
        public SalesforceServiceCloudSource() { }
        public System.BinaryData AdditionalColumns { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Query { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ReadBehavior { get { throw null; } set { } }
    }
    public partial class SalesforceSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public SalesforceSink() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ExternalIdFieldName { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> IgnoreNullValues { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SalesforceSinkWriteBehavior? WriteBehavior { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SalesforceSinkWriteBehavior : System.IEquatable<Azure.ResourceManager.DataFactory.Models.SalesforceSinkWriteBehavior>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SalesforceSinkWriteBehavior(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.SalesforceSinkWriteBehavior Insert { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.SalesforceSinkWriteBehavior Upsert { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.SalesforceSinkWriteBehavior other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.SalesforceSinkWriteBehavior left, Azure.ResourceManager.DataFactory.Models.SalesforceSinkWriteBehavior right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.SalesforceSinkWriteBehavior (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.SalesforceSinkWriteBehavior left, Azure.ResourceManager.DataFactory.Models.SalesforceSinkWriteBehavior right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SalesforceSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public SalesforceSource() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Query { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ReadBehavior { get { throw null; } set { } }
    }
    public partial class SapBWCubeDataset : Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetProperties
    {
        public SapBWCubeDataset(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName) : base (default(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference)) { }
    }
    public partial class SapBWLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public SapBWLinkedService(Azure.Core.Expressions.DataFactory.DataFactoryElement<string> server, Azure.Core.Expressions.DataFactory.DataFactoryElement<string> systemNumber, Azure.Core.Expressions.DataFactory.DataFactoryElement<string> clientId) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ClientId { get { throw null; } set { } }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition Password { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Server { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> SystemNumber { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> UserName { get { throw null; } set { } }
    }
    public partial class SapBWSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public SapBWSource() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Query { get { throw null; } set { } }
    }
    public partial class SapCloudForCustomerLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public SapCloudForCustomerLinkedService(Azure.Core.Expressions.DataFactory.DataFactoryElement<string> uri) { }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition Password { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Uri { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Username { get { throw null; } set { } }
    }
    public partial class SapCloudForCustomerResourceDataset : Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetProperties
    {
        public SapCloudForCustomerResourceDataset(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName, Azure.Core.Expressions.DataFactory.DataFactoryElement<string> path) : base (default(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference)) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Path { get { throw null; } set { } }
    }
    public partial class SapCloudForCustomerSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public SapCloudForCustomerSink() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> HttpRequestTimeout { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SapCloudForCustomerSinkWriteBehavior? WriteBehavior { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SapCloudForCustomerSinkWriteBehavior : System.IEquatable<Azure.ResourceManager.DataFactory.Models.SapCloudForCustomerSinkWriteBehavior>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SapCloudForCustomerSinkWriteBehavior(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.SapCloudForCustomerSinkWriteBehavior Insert { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.SapCloudForCustomerSinkWriteBehavior Update { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.SapCloudForCustomerSinkWriteBehavior other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.SapCloudForCustomerSinkWriteBehavior left, Azure.ResourceManager.DataFactory.Models.SapCloudForCustomerSinkWriteBehavior right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.SapCloudForCustomerSinkWriteBehavior (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.SapCloudForCustomerSinkWriteBehavior left, Azure.ResourceManager.DataFactory.Models.SapCloudForCustomerSinkWriteBehavior right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SapCloudForCustomerSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public SapCloudForCustomerSource() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> HttpRequestTimeout { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Query { get { throw null; } set { } }
    }
    public partial class SapEccLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public SapEccLinkedService(Azure.Core.Expressions.DataFactory.DataFactoryElement<string> uri) { }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition Password { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Uri { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Username { get { throw null; } set { } }
    }
    public partial class SapEccResourceDataset : Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetProperties
    {
        public SapEccResourceDataset(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName, Azure.Core.Expressions.DataFactory.DataFactoryElement<string> path) : base (default(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference)) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Path { get { throw null; } set { } }
    }
    public partial class SapEccSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public SapEccSource() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> HttpRequestTimeout { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Query { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SapHanaAuthenticationType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.SapHanaAuthenticationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SapHanaAuthenticationType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.SapHanaAuthenticationType Basic { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.SapHanaAuthenticationType Windows { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.SapHanaAuthenticationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.SapHanaAuthenticationType left, Azure.ResourceManager.DataFactory.Models.SapHanaAuthenticationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.SapHanaAuthenticationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.SapHanaAuthenticationType left, Azure.ResourceManager.DataFactory.Models.SapHanaAuthenticationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SapHanaLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public SapHanaLinkedService() { }
        public Azure.ResourceManager.DataFactory.Models.SapHanaAuthenticationType? AuthenticationType { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ConnectionString { get { throw null; } set { } }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition Password { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Server { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> UserName { get { throw null; } set { } }
    }
    public partial class SapHanaSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public SapHanaSource() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<int> PacketSize { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> PartitionColumnName { get { throw null; } set { } }
        public System.BinaryData PartitionOption { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Query { get { throw null; } set { } }
    }
    public partial class SapHanaTableDataset : Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetProperties
    {
        public SapHanaTableDataset(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName) : base (default(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference)) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> SchemaTypePropertiesSchema { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Table { get { throw null; } set { } }
    }
    public partial class SapOdpLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public SapOdpLinkedService() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ClientId { get { throw null; } set { } }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Language { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> LogonGroup { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> MessageServer { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> MessageServerService { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition Password { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Server { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> SncLibraryPath { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> SncMode { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> SncMyName { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> SncPartnerName { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> SncQop { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> SubscriberName { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> SystemId { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> SystemNumber { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> UserName { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> X509CertificatePath { get { throw null; } set { } }
    }
    public partial class SapOdpResourceDataset : Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetProperties
    {
        public SapOdpResourceDataset(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName, Azure.Core.Expressions.DataFactory.DataFactoryElement<string> context, Azure.Core.Expressions.DataFactory.DataFactoryElement<string> objectName) : base (default(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference)) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Context { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ObjectName { get { throw null; } set { } }
    }
    public partial class SapOdpSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public SapOdpSource() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ExtractionMode { get { throw null; } set { } }
        public System.BinaryData Projection { get { throw null; } set { } }
        public System.BinaryData Selection { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> SubscriberProcess { get { throw null; } set { } }
    }
    public partial class SapOpenHubLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public SapOpenHubLinkedService() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ClientId { get { throw null; } set { } }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Language { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> LogonGroup { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> MessageServer { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> MessageServerService { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition Password { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Server { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> SystemId { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> SystemNumber { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> UserName { get { throw null; } set { } }
    }
    public partial class SapOpenHubSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public SapOpenHubSource() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<int> BaseRequestId { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> CustomRfcReadTableFunctionModule { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> ExcludeLastRequest { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> SapDataColumnDelimiter { get { throw null; } set { } }
    }
    public partial class SapOpenHubTableDataset : Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetProperties
    {
        public SapOpenHubTableDataset(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName, Azure.Core.Expressions.DataFactory.DataFactoryElement<string> openHubDestinationName) : base (default(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference)) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<int> BaseRequestId { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> ExcludeLastRequest { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> OpenHubDestinationName { get { throw null; } set { } }
    }
    public partial class SapTableLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public SapTableLinkedService() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ClientId { get { throw null; } set { } }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Language { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> LogonGroup { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> MessageServer { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> MessageServerService { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition Password { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Server { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> SncLibraryPath { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> SncMode { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> SncMyName { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> SncPartnerName { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> SncQop { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> SystemId { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> SystemNumber { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> UserName { get { throw null; } set { } }
    }
    public partial class SapTablePartitionSettings
    {
        public SapTablePartitionSettings() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<int> MaxPartitionsNumber { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> PartitionColumnName { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> PartitionLowerBound { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> PartitionUpperBound { get { throw null; } set { } }
    }
    public partial class SapTableResourceDataset : Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetProperties
    {
        public SapTableResourceDataset(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName, Azure.Core.Expressions.DataFactory.DataFactoryElement<string> tableName) : base (default(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference)) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> TableName { get { throw null; } set { } }
    }
    public partial class SapTableSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public SapTableSource() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<int> BatchSize { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> CustomRfcReadTableFunctionModule { get { throw null; } set { } }
        public System.BinaryData PartitionOption { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SapTablePartitionSettings PartitionSettings { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> RfcTableFields { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> RfcTableOptions { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<int> RowCount { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<int> RowSkips { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> SapDataColumnDelimiter { get { throw null; } set { } }
    }
    public partial class ScheduleTriggerRecurrence
    {
        public ScheduleTriggerRecurrence() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DataFactoryRecurrenceFrequency? Frequency { get { throw null; } set { } }
        public int? Interval { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DataFactoryRecurrenceSchedule Schedule { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        public string TimeZone { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScriptActivityLogDestination : System.IEquatable<Azure.ResourceManager.DataFactory.Models.ScriptActivityLogDestination>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScriptActivityLogDestination(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.ScriptActivityLogDestination ActivityOutput { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.ScriptActivityLogDestination ExternalStore { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.ScriptActivityLogDestination other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.ScriptActivityLogDestination left, Azure.ResourceManager.DataFactory.Models.ScriptActivityLogDestination right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.ScriptActivityLogDestination (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.ScriptActivityLogDestination left, Azure.ResourceManager.DataFactory.Models.ScriptActivityLogDestination right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ScriptActivityParameter
    {
        public ScriptActivityParameter() { }
        public Azure.ResourceManager.DataFactory.Models.ScriptActivityParameterDirection? Direction { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Name { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.ScriptActivityParameterType? ParameterType { get { throw null; } set { } }
        public int? Size { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Value { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScriptActivityParameterDirection : System.IEquatable<Azure.ResourceManager.DataFactory.Models.ScriptActivityParameterDirection>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScriptActivityParameterDirection(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.ScriptActivityParameterDirection Input { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.ScriptActivityParameterDirection InputOutput { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.ScriptActivityParameterDirection Output { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.ScriptActivityParameterDirection other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.ScriptActivityParameterDirection left, Azure.ResourceManager.DataFactory.Models.ScriptActivityParameterDirection right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.ScriptActivityParameterDirection (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.ScriptActivityParameterDirection left, Azure.ResourceManager.DataFactory.Models.ScriptActivityParameterDirection right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScriptActivityParameterType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.ScriptActivityParameterType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScriptActivityParameterType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.ScriptActivityParameterType Boolean { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.ScriptActivityParameterType DateTime { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.ScriptActivityParameterType DateTimeOffset { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.ScriptActivityParameterType Decimal { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.ScriptActivityParameterType Double { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.ScriptActivityParameterType Guid { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.ScriptActivityParameterType Int16 { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.ScriptActivityParameterType Int32 { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.ScriptActivityParameterType Int64 { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.ScriptActivityParameterType Single { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.ScriptActivityParameterType String { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.ScriptActivityParameterType TimeSpan { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.ScriptActivityParameterType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.ScriptActivityParameterType left, Azure.ResourceManager.DataFactory.Models.ScriptActivityParameterType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.ScriptActivityParameterType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.ScriptActivityParameterType left, Azure.ResourceManager.DataFactory.Models.ScriptActivityParameterType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ScriptActivityScriptBlock
    {
        public ScriptActivityScriptBlock(Azure.Core.Expressions.DataFactory.DataFactoryElement<string> text, Azure.ResourceManager.DataFactory.Models.DataFactoryScriptType scriptType) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.ScriptActivityParameter> Parameters { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.DataFactoryScriptType ScriptType { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Text { get { throw null; } set { } }
    }
    public partial class ScriptActivityTypeLogSettings
    {
        public ScriptActivityTypeLogSettings(Azure.ResourceManager.DataFactory.Models.ScriptActivityLogDestination logDestination) { }
        public Azure.ResourceManager.DataFactory.Models.ScriptActivityLogDestination LogDestination { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.LogLocationSettings LogLocationSettings { get { throw null; } set { } }
    }
    public partial class SecureInputOutputPolicy
    {
        public SecureInputOutputPolicy() { }
        public bool? IsSecureInputEnabled { get { throw null; } set { } }
        public bool? IsSecureOutputEnabled { get { throw null; } set { } }
    }
    public partial class SelfDependencyTumblingWindowTriggerReference : Azure.ResourceManager.DataFactory.Models.DependencyReference
    {
        public SelfDependencyTumblingWindowTriggerReference(string offset) { }
        public string Offset { get { throw null; } set { } }
        public string Size { get { throw null; } set { } }
    }
    public partial class SelfHostedIntegrationRuntime : Azure.ResourceManager.DataFactory.Models.DataFactoryIntegrationRuntimeProperties
    {
        public SelfHostedIntegrationRuntime() { }
        public bool? IsSelfContainedInteractiveAuthoringEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.LinkedIntegrationRuntimeType LinkedInfo { get { throw null; } set { } }
    }
    public partial class SelfHostedIntegrationRuntimeNode
    {
        internal SelfHostedIntegrationRuntimeNode() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Capabilities { get { throw null; } }
        public int? ConcurrentJobsLimit { get { throw null; } }
        public System.DateTimeOffset? ExpireOn { get { throw null; } }
        public System.Uri HostServiceUri { get { throw null; } }
        public bool? IsActiveDispatcher { get { throw null; } }
        public System.DateTimeOffset? LastConnectOn { get { throw null; } }
        public System.DateTimeOffset? LastEndUpdateOn { get { throw null; } }
        public System.DateTimeOffset? LastStartOn { get { throw null; } }
        public System.DateTimeOffset? LastStartUpdateOn { get { throw null; } }
        public System.DateTimeOffset? LastStopOn { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeUpdateResult? LastUpdateResult { get { throw null; } }
        public string MachineName { get { throw null; } }
        public int? MaxConcurrentJobs { get { throw null; } }
        public string NodeName { get { throw null; } }
        public System.DateTimeOffset? RegisterOn { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.SelfHostedIntegrationRuntimeNodeStatus? Status { get { throw null; } }
        public string Version { get { throw null; } }
        public string VersionStatus { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SelfHostedIntegrationRuntimeNodeStatus : System.IEquatable<Azure.ResourceManager.DataFactory.Models.SelfHostedIntegrationRuntimeNodeStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SelfHostedIntegrationRuntimeNodeStatus(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.SelfHostedIntegrationRuntimeNodeStatus InitializeFailed { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.SelfHostedIntegrationRuntimeNodeStatus Initializing { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.SelfHostedIntegrationRuntimeNodeStatus Limited { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.SelfHostedIntegrationRuntimeNodeStatus NeedRegistration { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.SelfHostedIntegrationRuntimeNodeStatus Offline { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.SelfHostedIntegrationRuntimeNodeStatus Online { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.SelfHostedIntegrationRuntimeNodeStatus Upgrading { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.SelfHostedIntegrationRuntimeNodeStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.SelfHostedIntegrationRuntimeNodeStatus left, Azure.ResourceManager.DataFactory.Models.SelfHostedIntegrationRuntimeNodeStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.SelfHostedIntegrationRuntimeNodeStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.SelfHostedIntegrationRuntimeNodeStatus left, Azure.ResourceManager.DataFactory.Models.SelfHostedIntegrationRuntimeNodeStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SelfHostedIntegrationRuntimeStatus : Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeStatus
    {
        internal SelfHostedIntegrationRuntimeStatus() { }
        public Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeAutoUpdateState? AutoUpdate { get { throw null; } }
        public System.DateTimeOffset? AutoUpdateEta { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Capabilities { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeInternalChannelEncryptionMode? InternalChannelEncryption { get { throw null; } }
        public bool? IsSelfContainedInteractiveAuthoringEnabled { get { throw null; } }
        public string LatestVersion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataFactory.Models.LinkedIntegrationRuntime> Links { get { throw null; } }
        public System.TimeSpan? LocalTimeZoneOffset { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataFactory.Models.SelfHostedIntegrationRuntimeNode> Nodes { get { throw null; } }
        public string PushedVersion { get { throw null; } }
        public System.DateTimeOffset? ScheduledUpdateOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ServiceUriStringList { get { throw null; } }
        public System.Guid? TaskQueueId { get { throw null; } }
        public System.TimeSpan? UpdateDelayOffset { get { throw null; } }
        public string Version { get { throw null; } }
        public string VersionStatus { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServiceNowAuthenticationType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.ServiceNowAuthenticationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServiceNowAuthenticationType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.ServiceNowAuthenticationType Basic { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.ServiceNowAuthenticationType OAuth2 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.ServiceNowAuthenticationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.ServiceNowAuthenticationType left, Azure.ResourceManager.DataFactory.Models.ServiceNowAuthenticationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.ServiceNowAuthenticationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.ServiceNowAuthenticationType left, Azure.ResourceManager.DataFactory.Models.ServiceNowAuthenticationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ServiceNowLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public ServiceNowLinkedService(System.BinaryData endpoint, Azure.ResourceManager.DataFactory.Models.ServiceNowAuthenticationType authenticationType) { }
        public Azure.ResourceManager.DataFactory.Models.ServiceNowAuthenticationType AuthenticationType { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ClientId { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition ClientSecret { get { throw null; } set { } }
        public string EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData Endpoint { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition Password { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> UseEncryptedEndpoints { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> UseHostVerification { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> UsePeerVerification { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Username { get { throw null; } set { } }
    }
    public partial class ServiceNowObjectDataset : Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetProperties
    {
        public ServiceNowObjectDataset(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName) : base (default(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference)) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> TableName { get { throw null; } set { } }
    }
    public partial class ServiceNowSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public ServiceNowSource() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Query { get { throw null; } set { } }
    }
    public partial class ServicePrincipalCredential : Azure.ResourceManager.DataFactory.Models.DataFactoryCredential
    {
        public ServicePrincipalCredential() { }
        public System.BinaryData ServicePrincipalId { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryKeyVaultSecretReference ServicePrincipalKey { get { throw null; } set { } }
        public System.BinaryData Tenant { get { throw null; } set { } }
    }
    public partial class SetVariableActivity : Azure.ResourceManager.DataFactory.Models.ControlActivity
    {
        public SetVariableActivity(string name) : base (default(string)) { }
        public Azure.ResourceManager.DataFactory.Models.SecureInputOutputPolicy Policy { get { throw null; } set { } }
        public bool? SetSystemVariable { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<System.BinaryData> Value { get { throw null; } set { } }
        public string VariableName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SftpAuthenticationType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.SftpAuthenticationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SftpAuthenticationType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.SftpAuthenticationType Basic { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.SftpAuthenticationType MultiFactor { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.SftpAuthenticationType SshPublicKey { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.SftpAuthenticationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.SftpAuthenticationType left, Azure.ResourceManager.DataFactory.Models.SftpAuthenticationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.SftpAuthenticationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.SftpAuthenticationType left, Azure.ResourceManager.DataFactory.Models.SftpAuthenticationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SftpLocation : Azure.ResourceManager.DataFactory.Models.DatasetLocation
    {
        public SftpLocation() { }
    }
    public partial class SftpReadSettings : Azure.ResourceManager.DataFactory.Models.StoreReadSettings
    {
        public SftpReadSettings() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> DeleteFilesAfterCompletion { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> DisableChunking { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> EnablePartitionDiscovery { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> FileListPath { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ModifiedDatetimeEnd { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ModifiedDatetimeStart { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> PartitionRootPath { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> Recursive { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> WildcardFileName { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> WildcardFolderPath { get { throw null; } set { } }
    }
    public partial class SftpServerLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public SftpServerLinkedService(Azure.Core.Expressions.DataFactory.DataFactoryElement<string> host) { }
        public Azure.ResourceManager.DataFactory.Models.SftpAuthenticationType? AuthenticationType { get { throw null; } set { } }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Host { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> HostKeyFingerprint { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition PassPhrase { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition Password { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<int> Port { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition PrivateKeyContent { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> PrivateKeyPath { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> SkipHostKeyValidation { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> UserName { get { throw null; } set { } }
    }
    public partial class SftpWriteSettings : Azure.ResourceManager.DataFactory.Models.StoreWriteSettings
    {
        public SftpWriteSettings() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> OperationTimeout { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> UseTempFileRename { get { throw null; } set { } }
    }
    public partial class SharePointOnlineListLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public SharePointOnlineListLinkedService(Azure.Core.Expressions.DataFactory.DataFactoryElement<string> siteUri, Azure.Core.Expressions.DataFactory.DataFactoryElement<string> tenantId, Azure.Core.Expressions.DataFactory.DataFactoryElement<string> servicePrincipalId, Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition servicePrincipalKey) { }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ServicePrincipalId { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition ServicePrincipalKey { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> SiteUri { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> TenantId { get { throw null; } set { } }
    }
    public partial class SharePointOnlineListResourceDataset : Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetProperties
    {
        public SharePointOnlineListResourceDataset(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName) : base (default(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference)) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ListName { get { throw null; } set { } }
    }
    public partial class SharePointOnlineListSource : Azure.ResourceManager.DataFactory.Models.CopyActivitySource
    {
        public SharePointOnlineListSource() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> HttpRequestTimeout { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Query { get { throw null; } set { } }
    }
    public partial class ShopifyLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public ShopifyLinkedService(Azure.Core.Expressions.DataFactory.DataFactoryElement<string> host) { }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition AccessToken { get { throw null; } set { } }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Host { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> UseEncryptedEndpoints { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> UseHostVerification { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> UsePeerVerification { get { throw null; } set { } }
    }
    public partial class ShopifyObjectDataset : Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetProperties
    {
        public ShopifyObjectDataset(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName) : base (default(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference)) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> TableName { get { throw null; } set { } }
    }
    public partial class ShopifySource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public ShopifySource() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Query { get { throw null; } set { } }
    }
    public partial class SkipErrorFile
    {
        public SkipErrorFile() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> DataInconsistency { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> FileMissing { get { throw null; } set { } }
    }
    public partial class SmartsheetLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public SmartsheetLinkedService(Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition apiToken) { }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition ApiToken { get { throw null; } set { } }
        public string EncryptedCredential { get { throw null; } set { } }
    }
    public partial class SnowflakeDataset : Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetProperties
    {
        public SnowflakeDataset(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName) : base (default(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference)) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> SchemaTypePropertiesSchema { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Table { get { throw null; } set { } }
    }
    public partial class SnowflakeExportCopyCommand : Azure.ResourceManager.DataFactory.Models.ExportSettings
    {
        public SnowflakeExportCopyCommand() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalCopyOptions { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalFormatOptions { get { throw null; } }
    }
    public partial class SnowflakeImportCopyCommand : Azure.ResourceManager.DataFactory.Models.ImportSettings
    {
        public SnowflakeImportCopyCommand() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalCopyOptions { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalFormatOptions { get { throw null; } }
    }
    public partial class SnowflakeLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public SnowflakeLinkedService(System.BinaryData connectionString) { }
        public System.BinaryData ConnectionString { get { throw null; } set { } }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryKeyVaultSecretReference Password { get { throw null; } set { } }
    }
    public partial class SnowflakeSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public SnowflakeSink() { }
        public Azure.ResourceManager.DataFactory.Models.SnowflakeImportCopyCommand ImportSettings { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> PreCopyScript { get { throw null; } set { } }
    }
    public partial class SnowflakeSource : Azure.ResourceManager.DataFactory.Models.CopyActivitySource
    {
        public SnowflakeSource(Azure.ResourceManager.DataFactory.Models.SnowflakeExportCopyCommand exportSettings) { }
        public Azure.ResourceManager.DataFactory.Models.SnowflakeExportCopyCommand ExportSettings { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Query { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SparkAuthenticationType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.SparkAuthenticationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SparkAuthenticationType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.SparkAuthenticationType Anonymous { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.SparkAuthenticationType Username { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.SparkAuthenticationType UsernameAndPassword { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.SparkAuthenticationType WindowsAzureHDInsightService { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.SparkAuthenticationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.SparkAuthenticationType left, Azure.ResourceManager.DataFactory.Models.SparkAuthenticationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.SparkAuthenticationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.SparkAuthenticationType left, Azure.ResourceManager.DataFactory.Models.SparkAuthenticationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SparkConfigurationParametrizationReference
    {
        public SparkConfigurationParametrizationReference(Azure.ResourceManager.DataFactory.Models.SparkConfigurationReferenceType referenceType, Azure.Core.Expressions.DataFactory.DataFactoryElement<string> referenceName) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ReferenceName { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SparkConfigurationReferenceType ReferenceType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SparkConfigurationReferenceType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.SparkConfigurationReferenceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SparkConfigurationReferenceType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.SparkConfigurationReferenceType SparkConfigurationReference { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.SparkConfigurationReferenceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.SparkConfigurationReferenceType left, Azure.ResourceManager.DataFactory.Models.SparkConfigurationReferenceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.SparkConfigurationReferenceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.SparkConfigurationReferenceType left, Azure.ResourceManager.DataFactory.Models.SparkConfigurationReferenceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SparkJobReferenceType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.SparkJobReferenceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SparkJobReferenceType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.SparkJobReferenceType SparkJobDefinitionReference { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.SparkJobReferenceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.SparkJobReferenceType left, Azure.ResourceManager.DataFactory.Models.SparkJobReferenceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.SparkJobReferenceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.SparkJobReferenceType left, Azure.ResourceManager.DataFactory.Models.SparkJobReferenceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SparkLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public SparkLinkedService(Azure.Core.Expressions.DataFactory.DataFactoryElement<string> host, Azure.Core.Expressions.DataFactory.DataFactoryElement<int> port, Azure.ResourceManager.DataFactory.Models.SparkAuthenticationType authenticationType) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> AllowHostNameCNMismatch { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> AllowSelfSignedServerCert { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SparkAuthenticationType AuthenticationType { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> EnableSsl { get { throw null; } set { } }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Host { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> HttpPath { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition Password { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<int> Port { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SparkServerType? ServerType { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SparkThriftTransportProtocol? ThriftTransportProtocol { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> TrustedCertPath { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Username { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> UseSystemTrustStore { get { throw null; } set { } }
    }
    public partial class SparkObjectDataset : Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetProperties
    {
        public SparkObjectDataset(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName) : base (default(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference)) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> SchemaTypePropertiesSchema { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Table { get { throw null; } set { } }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SparkServerType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.SparkServerType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SparkServerType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.SparkServerType SharkServer { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.SparkServerType SharkServer2 { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.SparkServerType SparkThriftServer { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.SparkServerType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.SparkServerType left, Azure.ResourceManager.DataFactory.Models.SparkServerType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.SparkServerType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.SparkServerType left, Azure.ResourceManager.DataFactory.Models.SparkServerType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SparkSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public SparkSource() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Query { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SparkThriftTransportProtocol : System.IEquatable<Azure.ResourceManager.DataFactory.Models.SparkThriftTransportProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SparkThriftTransportProtocol(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.SparkThriftTransportProtocol Binary { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.SparkThriftTransportProtocol Http { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.SparkThriftTransportProtocol Sasl { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.SparkThriftTransportProtocol other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.SparkThriftTransportProtocol left, Azure.ResourceManager.DataFactory.Models.SparkThriftTransportProtocol right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.SparkThriftTransportProtocol (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.SparkThriftTransportProtocol left, Azure.ResourceManager.DataFactory.Models.SparkThriftTransportProtocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SqlAlwaysEncryptedAkvAuthType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.SqlAlwaysEncryptedAkvAuthType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SqlAlwaysEncryptedAkvAuthType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.SqlAlwaysEncryptedAkvAuthType ManagedIdentity { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.SqlAlwaysEncryptedAkvAuthType ServicePrincipal { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.SqlAlwaysEncryptedAkvAuthType UserAssignedManagedIdentity { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.SqlAlwaysEncryptedAkvAuthType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.SqlAlwaysEncryptedAkvAuthType left, Azure.ResourceManager.DataFactory.Models.SqlAlwaysEncryptedAkvAuthType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.SqlAlwaysEncryptedAkvAuthType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.SqlAlwaysEncryptedAkvAuthType left, Azure.ResourceManager.DataFactory.Models.SqlAlwaysEncryptedAkvAuthType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SqlAlwaysEncryptedProperties
    {
        public SqlAlwaysEncryptedProperties(Azure.ResourceManager.DataFactory.Models.SqlAlwaysEncryptedAkvAuthType alwaysEncryptedAkvAuthType) { }
        public Azure.ResourceManager.DataFactory.Models.SqlAlwaysEncryptedAkvAuthType AlwaysEncryptedAkvAuthType { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DataFactoryCredentialReference Credential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ServicePrincipalId { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition ServicePrincipalKey { get { throw null; } set { } }
    }
    public partial class SqlDWSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public SqlDWSink() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> AllowCopyCommand { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> AllowPolyBase { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DWCopyCommandSettings CopyCommandSettings { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.PolybaseSettings PolyBaseSettings { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> PreCopyScript { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> SqlWriterUseTableLock { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> TableOption { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SqlDWUpsertSettings UpsertSettings { get { throw null; } set { } }
        public System.BinaryData WriteBehavior { get { throw null; } set { } }
    }
    public partial class SqlDWSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public SqlDWSource() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> IsolationLevel { get { throw null; } set { } }
        public System.BinaryData PartitionOption { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SqlPartitionSettings PartitionSettings { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> SqlReaderQuery { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> SqlReaderStoredProcedureName { get { throw null; } set { } }
        public System.BinaryData StoredProcedureParameters { get { throw null; } set { } }
    }
    public partial class SqlDWUpsertSettings
    {
        public SqlDWUpsertSettings() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> InterimSchemaName { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<System.Collections.Generic.IList<string>> Keys { get { throw null; } set { } }
    }
    public partial class SqlMISink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public SqlMISink() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> PreCopyScript { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> SqlWriterStoredProcedureName { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> SqlWriterTableType { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> SqlWriterUseTableLock { get { throw null; } set { } }
        public System.BinaryData StoredProcedureParameters { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> StoredProcedureTableTypeParameterName { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> TableOption { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SqlUpsertSettings UpsertSettings { get { throw null; } set { } }
        public System.BinaryData WriteBehavior { get { throw null; } set { } }
    }
    public partial class SqlMISource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public SqlMISource() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> IsolationLevel { get { throw null; } set { } }
        public System.BinaryData PartitionOption { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SqlPartitionSettings PartitionSettings { get { throw null; } set { } }
        public System.BinaryData ProduceAdditionalTypes { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> SqlReaderQuery { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> SqlReaderStoredProcedureName { get { throw null; } set { } }
        public System.BinaryData StoredProcedureParameters { get { throw null; } set { } }
    }
    public partial class SqlPartitionSettings
    {
        public SqlPartitionSettings() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> PartitionColumnName { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> PartitionLowerBound { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> PartitionUpperBound { get { throw null; } set { } }
    }
    public partial class SqlServerLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public SqlServerLinkedService(Azure.Core.Expressions.DataFactory.DataFactoryElement<string> connectionString) { }
        public Azure.ResourceManager.DataFactory.Models.SqlAlwaysEncryptedProperties AlwaysEncryptedSettings { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ConnectionString { get { throw null; } set { } }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition Password { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> UserName { get { throw null; } set { } }
    }
    public partial class SqlServerSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public SqlServerSink() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> PreCopyScript { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> SqlWriterStoredProcedureName { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> SqlWriterTableType { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> SqlWriterUseTableLock { get { throw null; } set { } }
        public System.BinaryData StoredProcedureParameters { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> StoredProcedureTableTypeParameterName { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> TableOption { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SqlUpsertSettings UpsertSettings { get { throw null; } set { } }
        public System.BinaryData WriteBehavior { get { throw null; } set { } }
    }
    public partial class SqlServerSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public SqlServerSource() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> IsolationLevel { get { throw null; } set { } }
        public System.BinaryData PartitionOption { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SqlPartitionSettings PartitionSettings { get { throw null; } set { } }
        public System.BinaryData ProduceAdditionalTypes { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> SqlReaderQuery { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> SqlReaderStoredProcedureName { get { throw null; } set { } }
        public System.BinaryData StoredProcedureParameters { get { throw null; } set { } }
    }
    public partial class SqlServerStoredProcedureActivity : Azure.ResourceManager.DataFactory.Models.ExecutionActivity
    {
        public SqlServerStoredProcedureActivity(string name, Azure.Core.Expressions.DataFactory.DataFactoryElement<string> storedProcedureName) : base (default(string)) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> StoredProcedureName { get { throw null; } set { } }
        public System.BinaryData StoredProcedureParameters { get { throw null; } set { } }
    }
    public partial class SqlServerTableDataset : Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetProperties
    {
        public SqlServerTableDataset(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName) : base (default(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference)) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> SchemaTypePropertiesSchema { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Table { get { throw null; } set { } }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class SqlSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public SqlSink() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> PreCopyScript { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> SqlWriterStoredProcedureName { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> SqlWriterTableType { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> SqlWriterUseTableLock { get { throw null; } set { } }
        public System.BinaryData StoredProcedureParameters { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> StoredProcedureTableTypeParameterName { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> TableOption { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SqlUpsertSettings UpsertSettings { get { throw null; } set { } }
        public System.BinaryData WriteBehavior { get { throw null; } set { } }
    }
    public partial class SqlSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public SqlSource() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> IsolationLevel { get { throw null; } set { } }
        public System.BinaryData PartitionOption { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SqlPartitionSettings PartitionSettings { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> SqlReaderQuery { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> SqlReaderStoredProcedureName { get { throw null; } set { } }
        public System.BinaryData StoredProcedureParameters { get { throw null; } set { } }
    }
    public partial class SqlUpsertSettings
    {
        public SqlUpsertSettings() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> InterimSchemaName { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<System.Collections.Generic.IList<string>> Keys { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> UseTempDB { get { throw null; } set { } }
    }
    public partial class SquareLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public SquareLinkedService() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ClientId { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition ClientSecret { get { throw null; } set { } }
        public System.BinaryData ConnectionProperties { get { throw null; } set { } }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Host { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> RedirectUri { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> UseEncryptedEndpoints { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> UseHostVerification { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> UsePeerVerification { get { throw null; } set { } }
    }
    public partial class SquareObjectDataset : Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetProperties
    {
        public SquareObjectDataset(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName) : base (default(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference)) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> TableName { get { throw null; } set { } }
    }
    public partial class SquareSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public SquareSource() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Query { get { throw null; } set { } }
    }
    public partial class SsisAccessCredential
    {
        public SsisAccessCredential(Azure.Core.Expressions.DataFactory.DataFactoryElement<string> domain, Azure.Core.Expressions.DataFactory.DataFactoryElement<string> userName, Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition password) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Domain { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition Password { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> UserName { get { throw null; } set { } }
    }
    public partial class SsisChildPackage
    {
        public SsisChildPackage(Azure.Core.Expressions.DataFactory.DataFactoryElement<string> packagePath, Azure.Core.Expressions.DataFactory.DataFactoryElement<string> packageContent) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> PackageContent { get { throw null; } set { } }
        public string PackageLastModifiedDate { get { throw null; } set { } }
        public string PackageName { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> PackagePath { get { throw null; } set { } }
    }
    public partial class SsisEnvironment : Azure.ResourceManager.DataFactory.Models.SsisObjectMetadata
    {
        internal SsisEnvironment() { }
        public long? FolderId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataFactory.Models.SsisVariable> Variables { get { throw null; } }
    }
    public partial class SsisEnvironmentReference
    {
        internal SsisEnvironmentReference() { }
        public string EnvironmentFolderName { get { throw null; } }
        public string EnvironmentName { get { throw null; } }
        public long? Id { get { throw null; } }
        public string ReferenceType { get { throw null; } }
    }
    public partial class SsisExecutionCredential
    {
        public SsisExecutionCredential(Azure.Core.Expressions.DataFactory.DataFactoryElement<string> domain, Azure.Core.Expressions.DataFactory.DataFactoryElement<string> userName, Azure.Core.Expressions.DataFactory.DataFactorySecretString password) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Domain { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretString Password { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> UserName { get { throw null; } set { } }
    }
    public partial class SsisExecutionParameter
    {
        public SsisExecutionParameter(Azure.Core.Expressions.DataFactory.DataFactoryElement<string> value) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Value { get { throw null; } set { } }
    }
    public partial class SsisFolder : Azure.ResourceManager.DataFactory.Models.SsisObjectMetadata
    {
        internal SsisFolder() { }
    }
    public partial class SsisLogLocation
    {
        public SsisLogLocation(Azure.Core.Expressions.DataFactory.DataFactoryElement<string> logPath, Azure.ResourceManager.DataFactory.Models.SsisLogLocationType locationType) { }
        public Azure.ResourceManager.DataFactory.Models.SsisAccessCredential AccessCredential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SsisLogLocationType LocationType { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> LogPath { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> LogRefreshInterval { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SsisLogLocationType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.SsisLogLocationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SsisLogLocationType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.SsisLogLocationType File { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.SsisLogLocationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.SsisLogLocationType left, Azure.ResourceManager.DataFactory.Models.SsisLogLocationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.SsisLogLocationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.SsisLogLocationType left, Azure.ResourceManager.DataFactory.Models.SsisLogLocationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class SsisObjectMetadata
    {
        protected SsisObjectMetadata() { }
        public string Description { get { throw null; } }
        public long? Id { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class SsisObjectMetadataStatusResult
    {
        internal SsisObjectMetadataStatusResult() { }
        public string Error { get { throw null; } }
        public string Name { get { throw null; } }
        public string Properties { get { throw null; } }
        public string Status { get { throw null; } }
    }
    public partial class SsisPackage : Azure.ResourceManager.DataFactory.Models.SsisObjectMetadata
    {
        internal SsisPackage() { }
        public long? FolderId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataFactory.Models.SsisParameterInfo> Parameters { get { throw null; } }
        public long? ProjectId { get { throw null; } }
        public long? ProjectVersion { get { throw null; } }
    }
    public partial class SsisPackageLocation
    {
        public SsisPackageLocation() { }
        public Azure.ResourceManager.DataFactory.Models.SsisAccessCredential AccessCredential { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.SsisChildPackage> ChildPackages { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.SsisAccessCredential ConfigurationAccessCredential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ConfigurationPath { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SsisPackageLocationType? LocationType { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> PackageContent { get { throw null; } set { } }
        public string PackageLastModifiedDate { get { throw null; } set { } }
        public string PackageName { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition PackagePassword { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> PackagePath { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SsisPackageLocationType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.SsisPackageLocationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SsisPackageLocationType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.SsisPackageLocationType File { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.SsisPackageLocationType InlinePackage { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.SsisPackageLocationType PackageStore { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.SsisPackageLocationType SsisDB { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.SsisPackageLocationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.SsisPackageLocationType left, Azure.ResourceManager.DataFactory.Models.SsisPackageLocationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.SsisPackageLocationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.SsisPackageLocationType left, Azure.ResourceManager.DataFactory.Models.SsisPackageLocationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SsisParameterInfo
    {
        internal SsisParameterInfo() { }
        public string DataType { get { throw null; } }
        public string DefaultValue { get { throw null; } }
        public string Description { get { throw null; } }
        public string DesignDefaultValue { get { throw null; } }
        public bool? HasValueSet { get { throw null; } }
        public long? Id { get { throw null; } }
        public bool? IsRequired { get { throw null; } }
        public bool? IsSensitive { get { throw null; } }
        public string Name { get { throw null; } }
        public string SensitiveDefaultValue { get { throw null; } }
        public string ValueType { get { throw null; } }
        public string Variable { get { throw null; } }
    }
    public partial class SsisProject : Azure.ResourceManager.DataFactory.Models.SsisObjectMetadata
    {
        internal SsisProject() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataFactory.Models.SsisEnvironmentReference> EnvironmentRefs { get { throw null; } }
        public long? FolderId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataFactory.Models.SsisParameterInfo> Parameters { get { throw null; } }
        public long? Version { get { throw null; } }
    }
    public partial class SsisPropertyOverride
    {
        public SsisPropertyOverride(Azure.Core.Expressions.DataFactory.DataFactoryElement<string> value) { }
        public bool? IsSensitive { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Value { get { throw null; } set { } }
    }
    public partial class SsisVariable
    {
        internal SsisVariable() { }
        public string DataType { get { throw null; } }
        public string Description { get { throw null; } }
        public long? Id { get { throw null; } }
        public bool? IsSensitive { get { throw null; } }
        public string Name { get { throw null; } }
        public string SensitiveValue { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class StagingSettings
    {
        public StagingSettings(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName) { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> EnableCompression { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference LinkedServiceName { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Path { get { throw null; } set { } }
    }
    public partial class StoreReadSettings
    {
        public StoreReadSettings() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> DisableMetricsCollection { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<int> MaxConcurrentConnections { get { throw null; } set { } }
    }
    public partial class StoreWriteSettings
    {
        public StoreWriteSettings() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public System.BinaryData CopyBehavior { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> DisableMetricsCollection { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<int> MaxConcurrentConnections { get { throw null; } set { } }
    }
    public partial class SwitchActivity : Azure.ResourceManager.DataFactory.Models.ControlActivity
    {
        public SwitchActivity(string name, Azure.ResourceManager.DataFactory.Models.DataFactoryExpression on) : base (default(string)) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.SwitchCaseActivity> Cases { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.PipelineActivity> DefaultActivities { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.DataFactoryExpression On { get { throw null; } set { } }
    }
    public partial class SwitchCaseActivity
    {
        public SwitchCaseActivity() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.PipelineActivity> Activities { get { throw null; } }
        public string Value { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SybaseAuthenticationType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.SybaseAuthenticationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SybaseAuthenticationType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.SybaseAuthenticationType Basic { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.SybaseAuthenticationType Windows { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.SybaseAuthenticationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.SybaseAuthenticationType left, Azure.ResourceManager.DataFactory.Models.SybaseAuthenticationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.SybaseAuthenticationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.SybaseAuthenticationType left, Azure.ResourceManager.DataFactory.Models.SybaseAuthenticationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SybaseLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public SybaseLinkedService(Azure.Core.Expressions.DataFactory.DataFactoryElement<string> server, Azure.Core.Expressions.DataFactory.DataFactoryElement<string> database) { }
        public Azure.ResourceManager.DataFactory.Models.SybaseAuthenticationType? AuthenticationType { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Database { get { throw null; } set { } }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition Password { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Schema { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Server { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Username { get { throw null; } set { } }
    }
    public partial class SybaseSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public SybaseSource() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Query { get { throw null; } set { } }
    }
    public partial class SybaseTableDataset : Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetProperties
    {
        public SybaseTableDataset(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName) : base (default(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference)) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> TableName { get { throw null; } set { } }
    }
    public partial class SynapseNotebookActivity : Azure.ResourceManager.DataFactory.Models.ExecutionActivity
    {
        public SynapseNotebookActivity(string name, Azure.ResourceManager.DataFactory.Models.SynapseNotebookReference notebook) : base (default(string)) { }
        public System.BinaryData Conf { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DataFactorySparkConfigurationType? ConfigurationType { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> DriverSize { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ExecutorSize { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SynapseNotebookReference Notebook { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<int> NumExecutors { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DataFactory.Models.NotebookParameter> Parameters { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> SparkConfig { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.BigDataPoolParametrizationReference SparkPool { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SparkConfigurationParametrizationReference TargetSparkConfiguration { get { throw null; } set { } }
    }
    public partial class SynapseNotebookReference
    {
        public SynapseNotebookReference(Azure.ResourceManager.DataFactory.Models.NotebookReferenceType notebookReferenceType, Azure.Core.Expressions.DataFactory.DataFactoryElement<string> referenceName) { }
        public Azure.ResourceManager.DataFactory.Models.NotebookReferenceType NotebookReferenceType { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ReferenceName { get { throw null; } set { } }
    }
    public partial class SynapseSparkJobDefinitionActivity : Azure.ResourceManager.DataFactory.Models.ExecutionActivity
    {
        public SynapseSparkJobDefinitionActivity(string name, Azure.ResourceManager.DataFactory.Models.SynapseSparkJobReference sparkJob) : base (default(string)) { }
        public System.Collections.Generic.IList<System.BinaryData> Arguments { get { throw null; } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ClassName { get { throw null; } set { } }
        public System.BinaryData Conf { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DataFactorySparkConfigurationType? ConfigurationType { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> DriverSize { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ExecutorSize { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> File { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.BinaryData> Files { get { throw null; } }
        public System.Collections.Generic.IList<System.BinaryData> FilesV2 { get { throw null; } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<int> NumExecutors { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.BinaryData> PythonCodeReference { get { throw null; } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> ScanFolder { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> SparkConfig { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.SynapseSparkJobReference SparkJob { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.BigDataPoolParametrizationReference TargetBigDataPool { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SparkConfigurationParametrizationReference TargetSparkConfiguration { get { throw null; } set { } }
    }
    public partial class SynapseSparkJobReference
    {
        public SynapseSparkJobReference(Azure.ResourceManager.DataFactory.Models.SparkJobReferenceType sparkJobReferenceType, System.BinaryData referenceName) { }
        public System.BinaryData ReferenceName { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SparkJobReferenceType SparkJobReferenceType { get { throw null; } set { } }
    }
    public partial class TabularSource : Azure.ResourceManager.DataFactory.Models.CopyActivitySource
    {
        public TabularSource() { }
        public System.BinaryData AdditionalColumns { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> QueryTimeout { get { throw null; } set { } }
    }
    public partial class TarGzipReadSettings : Azure.ResourceManager.DataFactory.Models.CompressionReadSettings
    {
        public TarGzipReadSettings() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> PreserveCompressionFileNameAsFolder { get { throw null; } set { } }
    }
    public partial class TarReadSettings : Azure.ResourceManager.DataFactory.Models.CompressionReadSettings
    {
        public TarReadSettings() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> PreserveCompressionFileNameAsFolder { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TeamDeskAuthenticationType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.TeamDeskAuthenticationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TeamDeskAuthenticationType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.TeamDeskAuthenticationType Basic { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.TeamDeskAuthenticationType Token { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.TeamDeskAuthenticationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.TeamDeskAuthenticationType left, Azure.ResourceManager.DataFactory.Models.TeamDeskAuthenticationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.TeamDeskAuthenticationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.TeamDeskAuthenticationType left, Azure.ResourceManager.DataFactory.Models.TeamDeskAuthenticationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TeamDeskLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public TeamDeskLinkedService(Azure.ResourceManager.DataFactory.Models.TeamDeskAuthenticationType authenticationType, Azure.Core.Expressions.DataFactory.DataFactoryElement<string> uri) { }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition ApiToken { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.TeamDeskAuthenticationType AuthenticationType { get { throw null; } set { } }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition Password { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Uri { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> UserName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TeradataAuthenticationType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.TeradataAuthenticationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TeradataAuthenticationType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.TeradataAuthenticationType Basic { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.TeradataAuthenticationType Windows { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.TeradataAuthenticationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.TeradataAuthenticationType left, Azure.ResourceManager.DataFactory.Models.TeradataAuthenticationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.TeradataAuthenticationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.TeradataAuthenticationType left, Azure.ResourceManager.DataFactory.Models.TeradataAuthenticationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TeradataLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public TeradataLinkedService() { }
        public Azure.ResourceManager.DataFactory.Models.TeradataAuthenticationType? AuthenticationType { get { throw null; } set { } }
        public System.BinaryData ConnectionString { get { throw null; } set { } }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition Password { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Server { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Username { get { throw null; } set { } }
    }
    public partial class TeradataPartitionSettings
    {
        public TeradataPartitionSettings() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> PartitionColumnName { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> PartitionLowerBound { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> PartitionUpperBound { get { throw null; } set { } }
    }
    public partial class TeradataSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public TeradataSource() { }
        public System.BinaryData PartitionOption { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.TeradataPartitionSettings PartitionSettings { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Query { get { throw null; } set { } }
    }
    public partial class TeradataTableDataset : Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetProperties
    {
        public TeradataTableDataset(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName) : base (default(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference)) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Database { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Table { get { throw null; } set { } }
    }
    public partial class TriggerDependencyReference : Azure.ResourceManager.DataFactory.Models.DependencyReference
    {
        public TriggerDependencyReference(Azure.ResourceManager.DataFactory.Models.DataFactoryTriggerReference referenceTrigger) { }
        public Azure.ResourceManager.DataFactory.Models.DataFactoryTriggerReference ReferenceTrigger { get { throw null; } set { } }
    }
    public partial class TriggerFilterContent
    {
        public TriggerFilterContent() { }
        public string ContinuationToken { get { throw null; } set { } }
        public string ParentTriggerName { get { throw null; } set { } }
    }
    public partial class TriggerPipelineReference
    {
        public TriggerPipelineReference() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Parameters { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.DataFactoryPipelineReference PipelineReference { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TumblingWindowFrequency : System.IEquatable<Azure.ResourceManager.DataFactory.Models.TumblingWindowFrequency>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TumblingWindowFrequency(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.TumblingWindowFrequency Hour { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.TumblingWindowFrequency Minute { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.TumblingWindowFrequency Month { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.TumblingWindowFrequency other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.TumblingWindowFrequency left, Azure.ResourceManager.DataFactory.Models.TumblingWindowFrequency right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.TumblingWindowFrequency (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.TumblingWindowFrequency left, Azure.ResourceManager.DataFactory.Models.TumblingWindowFrequency right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TumblingWindowTrigger : Azure.ResourceManager.DataFactory.Models.DataFactoryTriggerProperties
    {
        public TumblingWindowTrigger(Azure.ResourceManager.DataFactory.Models.TriggerPipelineReference pipeline, Azure.ResourceManager.DataFactory.Models.TumblingWindowFrequency frequency, int interval, System.DateTimeOffset startOn, int maxConcurrency) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Delay { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.DependencyReference> DependsOn { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.TumblingWindowFrequency Frequency { get { throw null; } set { } }
        public int Interval { get { throw null; } set { } }
        public int MaxConcurrency { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.TriggerPipelineReference Pipeline { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.RetryPolicy RetryPolicy { get { throw null; } set { } }
        public System.DateTimeOffset StartOn { get { throw null; } set { } }
    }
    public partial class TumblingWindowTriggerDependencyReference : Azure.ResourceManager.DataFactory.Models.TriggerDependencyReference
    {
        public TumblingWindowTriggerDependencyReference(Azure.ResourceManager.DataFactory.Models.DataFactoryTriggerReference referenceTrigger) : base (default(Azure.ResourceManager.DataFactory.Models.DataFactoryTriggerReference)) { }
        public string Offset { get { throw null; } set { } }
        public string Size { get { throw null; } set { } }
    }
    public partial class TwilioLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public TwilioLinkedService(Azure.Core.Expressions.DataFactory.DataFactoryElement<string> userName, Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition password) { }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition Password { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> UserName { get { throw null; } set { } }
    }
    public partial class UntilActivity : Azure.ResourceManager.DataFactory.Models.ControlActivity
    {
        public UntilActivity(string name, Azure.ResourceManager.DataFactory.Models.DataFactoryExpression expression, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataFactory.Models.PipelineActivity> activities) : base (default(string)) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.PipelineActivity> Activities { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.DataFactoryExpression Expression { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Timeout { get { throw null; } set { } }
    }
    public partial class UpdateIntegrationRuntimeNodeContent
    {
        public UpdateIntegrationRuntimeNodeContent() { }
        public int? ConcurrentJobsLimit { get { throw null; } set { } }
    }
    public partial class ValidationActivity : Azure.ResourceManager.DataFactory.Models.ControlActivity
    {
        public ValidationActivity(string name, Azure.ResourceManager.DataFactory.Models.DatasetReference dataset) : base (default(string)) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> ChildItems { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DatasetReference Dataset { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<int> MinimumSize { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<int> Sleep { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Timeout { get { throw null; } set { } }
    }
    public partial class VerticaLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public VerticaLinkedService() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ConnectionString { get { throw null; } set { } }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryKeyVaultSecretReference Password { get { throw null; } set { } }
    }
    public partial class VerticaSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public VerticaSource() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Query { get { throw null; } set { } }
    }
    public partial class VerticaTableDataset : Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetProperties
    {
        public VerticaTableDataset(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName) : base (default(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference)) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> SchemaTypePropertiesSchema { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Table { get { throw null; } set { } }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class WaitActivity : Azure.ResourceManager.DataFactory.Models.ControlActivity
    {
        public WaitActivity(string name, Azure.Core.Expressions.DataFactory.DataFactoryElement<int> waitTimeInSeconds) : base (default(string)) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<int> WaitTimeInSeconds { get { throw null; } set { } }
    }
    public partial class WebActivity : Azure.ResourceManager.DataFactory.Models.ExecutionActivity
    {
        public WebActivity(string name, Azure.ResourceManager.DataFactory.Models.WebActivityMethod method, Azure.Core.Expressions.DataFactory.DataFactoryElement<string> uri) : base (default(string)) { }
        public Azure.ResourceManager.DataFactory.Models.WebActivityAuthentication Authentication { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Body { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeReference ConnectVia { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.DatasetReference> Datasets { get { throw null; } }
        public bool? DisableCertValidation { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Headers { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference> LinkedServices { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.WebActivityMethod Method { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Uri { get { throw null; } set { } }
    }
    public partial class WebActivityAuthentication
    {
        public WebActivityAuthentication() { }
        public Azure.ResourceManager.DataFactory.Models.DataFactoryCredentialReference Credential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition Password { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition Pfx { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Resource { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Username { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> UserTenant { get { throw null; } set { } }
        public string WebActivityAuthenticationType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WebActivityMethod : System.IEquatable<Azure.ResourceManager.DataFactory.Models.WebActivityMethod>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WebActivityMethod(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.WebActivityMethod Delete { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.WebActivityMethod Get { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.WebActivityMethod Post { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.WebActivityMethod Put { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.WebActivityMethod other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.WebActivityMethod left, Azure.ResourceManager.DataFactory.Models.WebActivityMethod right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.WebActivityMethod (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.WebActivityMethod left, Azure.ResourceManager.DataFactory.Models.WebActivityMethod right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WebAnonymousAuthentication : Azure.ResourceManager.DataFactory.Models.WebLinkedServiceTypeProperties
    {
        public WebAnonymousAuthentication(Azure.Core.Expressions.DataFactory.DataFactoryElement<string> uri) : base (default(Azure.Core.Expressions.DataFactory.DataFactoryElement<string>)) { }
    }
    public partial class WebBasicAuthentication : Azure.ResourceManager.DataFactory.Models.WebLinkedServiceTypeProperties
    {
        public WebBasicAuthentication(Azure.Core.Expressions.DataFactory.DataFactoryElement<string> uri, Azure.Core.Expressions.DataFactory.DataFactoryElement<string> username, Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition password) : base (default(Azure.Core.Expressions.DataFactory.DataFactoryElement<string>)) { }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition Password { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Username { get { throw null; } set { } }
    }
    public partial class WebClientCertificateAuthentication : Azure.ResourceManager.DataFactory.Models.WebLinkedServiceTypeProperties
    {
        public WebClientCertificateAuthentication(Azure.Core.Expressions.DataFactory.DataFactoryElement<string> uri, Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition pfx, Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition password) : base (default(Azure.Core.Expressions.DataFactory.DataFactoryElement<string>)) { }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition Password { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition Pfx { get { throw null; } set { } }
    }
    public partial class WebHookActivity : Azure.ResourceManager.DataFactory.Models.ControlActivity
    {
        public WebHookActivity(string name, Azure.ResourceManager.DataFactory.Models.WebHookActivityMethod method, Azure.Core.Expressions.DataFactory.DataFactoryElement<string> uri) : base (default(string)) { }
        public Azure.ResourceManager.DataFactory.Models.WebActivityAuthentication Authentication { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Body { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Headers { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.WebHookActivityMethod Method { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> ReportStatusOnCallBack { get { throw null; } set { } }
        public string Timeout { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Uri { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WebHookActivityMethod : System.IEquatable<Azure.ResourceManager.DataFactory.Models.WebHookActivityMethod>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WebHookActivityMethod(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.WebHookActivityMethod Post { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.WebHookActivityMethod other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.WebHookActivityMethod left, Azure.ResourceManager.DataFactory.Models.WebHookActivityMethod right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.WebHookActivityMethod (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.WebHookActivityMethod left, Azure.ResourceManager.DataFactory.Models.WebHookActivityMethod right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WebLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public WebLinkedService(Azure.ResourceManager.DataFactory.Models.WebLinkedServiceTypeProperties typeProperties) { }
        public Azure.ResourceManager.DataFactory.Models.WebLinkedServiceTypeProperties TypeProperties { get { throw null; } set { } }
    }
    public abstract partial class WebLinkedServiceTypeProperties
    {
        protected WebLinkedServiceTypeProperties(Azure.Core.Expressions.DataFactory.DataFactoryElement<string> uri) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Uri { get { throw null; } set { } }
    }
    public partial class WebSource : Azure.ResourceManager.DataFactory.Models.CopyActivitySource
    {
        public WebSource() { }
        public System.BinaryData AdditionalColumns { get { throw null; } set { } }
    }
    public partial class WebTableDataset : Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetProperties
    {
        public WebTableDataset(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName, Azure.Core.Expressions.DataFactory.DataFactoryElement<int> index) : base (default(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference)) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<int> Index { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Path { get { throw null; } set { } }
    }
    public partial class XeroLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public XeroLinkedService() { }
        public System.BinaryData ConnectionProperties { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition ConsumerKey { get { throw null; } set { } }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Host { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition PrivateKey { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> UseEncryptedEndpoints { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> UseHostVerification { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> UsePeerVerification { get { throw null; } set { } }
    }
    public partial class XeroObjectDataset : Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetProperties
    {
        public XeroObjectDataset(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName) : base (default(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference)) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> TableName { get { throw null; } set { } }
    }
    public partial class XeroSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public XeroSource() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Query { get { throw null; } set { } }
    }
    public partial class XmlDataset : Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetProperties
    {
        public XmlDataset(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName) : base (default(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference)) { }
        public Azure.ResourceManager.DataFactory.Models.DatasetCompression Compression { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DatasetLocation DataLocation { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> EncodingName { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> NullValue { get { throw null; } set { } }
    }
    public partial class XmlReadSettings : Azure.ResourceManager.DataFactory.Models.FormatReadSettings
    {
        public XmlReadSettings() { }
        public Azure.ResourceManager.DataFactory.Models.CompressionReadSettings CompressionProperties { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> DetectDataType { get { throw null; } set { } }
        public System.BinaryData NamespacePrefixes { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> Namespaces { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> ValidationMode { get { throw null; } set { } }
    }
    public partial class XmlSource : Azure.ResourceManager.DataFactory.Models.CopyActivitySource
    {
        public XmlSource() { }
        public System.BinaryData AdditionalColumns { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.XmlReadSettings FormatSettings { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.StoreReadSettings StoreSettings { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ZendeskAuthenticationType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.ZendeskAuthenticationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ZendeskAuthenticationType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.ZendeskAuthenticationType Basic { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.ZendeskAuthenticationType Token { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.ZendeskAuthenticationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.ZendeskAuthenticationType left, Azure.ResourceManager.DataFactory.Models.ZendeskAuthenticationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.ZendeskAuthenticationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.ZendeskAuthenticationType left, Azure.ResourceManager.DataFactory.Models.ZendeskAuthenticationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ZendeskLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public ZendeskLinkedService(Azure.ResourceManager.DataFactory.Models.ZendeskAuthenticationType authenticationType, Azure.Core.Expressions.DataFactory.DataFactoryElement<string> uri) { }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition ApiToken { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.ZendeskAuthenticationType AuthenticationType { get { throw null; } set { } }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition Password { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Uri { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> UserName { get { throw null; } set { } }
    }
    public partial class ZipDeflateReadSettings : Azure.ResourceManager.DataFactory.Models.CompressionReadSettings
    {
        public ZipDeflateReadSettings() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> PreserveZipFileNameAsFolder { get { throw null; } set { } }
    }
    public partial class ZohoLinkedService : Azure.ResourceManager.DataFactory.Models.DataFactoryLinkedServiceProperties
    {
        public ZohoLinkedService() { }
        public Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition AccessToken { get { throw null; } set { } }
        public System.BinaryData ConnectionProperties { get { throw null; } set { } }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Endpoint { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> UseEncryptedEndpoints { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> UseHostVerification { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<bool> UsePeerVerification { get { throw null; } set { } }
    }
    public partial class ZohoObjectDataset : Azure.ResourceManager.DataFactory.Models.DataFactoryDatasetProperties
    {
        public ZohoObjectDataset(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference linkedServiceName) : base (default(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference)) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> TableName { get { throw null; } set { } }
    }
    public partial class ZohoSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public ZohoSource() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> Query { get { throw null; } set { } }
    }
}
