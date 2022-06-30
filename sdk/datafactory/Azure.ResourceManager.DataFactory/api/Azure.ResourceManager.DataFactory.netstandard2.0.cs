namespace Azure.ResourceManager.DataFactory
{
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
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataFactory.DataFactoryResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataFactory.DataFactoryResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataFactory.DataFactoryResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataFactory.DataFactoryResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataFactoryData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public DataFactoryData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public System.DateTimeOffset? CreateOn { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.EncryptionConfiguration Encryption { get { throw null; } set { } }
        public string ETag { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DataFactory.Models.GlobalParameterSpecification> GlobalParameters { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.FactoryIdentity Identity { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.PublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PurviewResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactoryRepoConfiguration RepoConfiguration { get { throw null; } set { } }
        public string Version { get { throw null; } }
    }
    public static partial class DataFactoryExtensions
    {
        public static Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryResource> ConfigureFactoryRepo(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationId, Azure.ResourceManager.DataFactory.Models.FactoryRepoUpdate factoryRepoUpdate, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryResource>> ConfigureFactoryRepoAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationId, Azure.ResourceManager.DataFactory.Models.FactoryRepoUpdate factoryRepoUpdate, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DataFactory.DataFactoryCollection GetDataFactories(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DataFactory.DataFactoryResource> GetDataFactories(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DataFactory.DataFactoryResource> GetDataFactoriesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryResource> GetDataFactory(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string factoryName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryResource>> GetDataFactoryAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string factoryName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DataFactory.DataFactoryGlobalParameterResource GetDataFactoryGlobalParameterResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataFactory.DataFactoryPipelineResource GetDataFactoryPipelineResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataFactory.DataFactoryPrivateEndpointConnectionResource GetDataFactoryPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataFactory.DataFactoryResource GetDataFactoryResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataFactory.DataFactoryTriggerResource GetDataFactoryTriggerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataFactory.DataFlowResource GetDataFlowResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataFactory.DatasetResource GetDatasetResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DataFactory.Models.ExposureControlResult> GetFeatureValueExposureControl(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationId, Azure.ResourceManager.DataFactory.Models.ExposureControlContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.Models.ExposureControlResult>> GetFeatureValueExposureControlAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationId, Azure.ResourceManager.DataFactory.Models.ExposureControlContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DataFactory.IntegrationRuntimeResource GetIntegrationRuntimeResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataFactory.LinkedServiceResource GetLinkedServiceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataFactory.ManagedPrivateEndpointResource GetManagedPrivateEndpointResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataFactory.ManagedVirtualNetworkResource GetManagedVirtualNetworkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
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
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataFactory.DataFactoryGlobalParameterResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataFactory.DataFactoryGlobalParameterResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataFactory.DataFactoryGlobalParameterResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataFactory.DataFactoryGlobalParameterResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataFactoryGlobalParameterData : Azure.ResourceManager.Models.ResourceData
    {
        public DataFactoryGlobalParameterData(System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DataFactory.Models.GlobalParameterSpecification> properties) { }
        public Azure.ETag? Etag { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DataFactory.Models.GlobalParameterSpecification> Properties { get { throw null; } }
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
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataFactory.DataFactoryPipelineResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataFactory.DataFactoryPipelineResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataFactory.DataFactoryPipelineResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataFactory.DataFactoryPipelineResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataFactoryPipelineData : Azure.ResourceManager.Models.ResourceData
    {
        public DataFactoryPipelineData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.DataFactoryPipelineActivity> Activities { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public System.Collections.Generic.IList<System.BinaryData> Annotations { get { throw null; } }
        public int? Concurrency { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public System.BinaryData ElapsedTimeMetricDuration { get { throw null; } set { } }
        public Azure.ETag? Etag { get { throw null; } }
        public string FolderName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DataFactory.Models.ParameterSpecification> Parameters { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> RunDimensions { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DataFactory.Models.VariableSpecification> Variables { get { throw null; } }
    }
    public partial class DataFactoryPipelineResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataFactoryPipelineResource() { }
        public virtual Azure.ResourceManager.DataFactory.DataFactoryPipelineData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string factoryName, string pipelineName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.Models.CreateRunResult> CreateRun(System.Collections.Generic.IDictionary<string, System.BinaryData> parameterValueSpecification = null, string referencePipelineRunId = null, bool? isRecovery = default(bool?), string startActivityName = null, bool? startFromFailure = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.Models.CreateRunResult>> CreateRunAsync(System.Collections.Generic.IDictionary<string, System.BinaryData> parameterValueSpecification = null, string referencePipelineRunId = null, bool? isRecovery = default(bool?), string startActivityName = null, bool? startFromFailure = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryPipelineResource> Get(string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryPipelineResource>> GetAsync(string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.DataFactoryPipelineResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataFactory.DataFactoryPipelineData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.DataFactoryPipelineResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataFactory.DataFactoryPipelineData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataFactory.DataFactoryPrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataFactory.DataFactoryPrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataFactory.DataFactoryPrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataFactory.DataFactoryPrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataFactoryPrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData
    {
        public DataFactoryPrivateEndpointConnectionData() { }
        public Azure.ETag? Etag { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.RemotePrivateEndpointConnection Properties { get { throw null; } set { } }
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
    public partial class DataFactoryResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataFactoryResource() { }
        public virtual Azure.ResourceManager.DataFactory.DataFactoryData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.Models.AddDataFlowToDebugSessionResult> AddDataFlowDataFlowDebugSession(Azure.ResourceManager.DataFactory.Models.DataFlowDebugPackage content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.Models.AddDataFlowToDebugSessionResult>> AddDataFlowDataFlowDebugSessionAsync(Azure.ResourceManager.DataFactory.Models.DataFlowDebugPackage content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CancelPipelineRun(string runId, bool? isRecursive = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelPipelineRunAsync(string runId, bool? isRecursive = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.Models.CreateDataFlowDebugSessionResult> CreateDataFlowDebugSession(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataFactory.Models.CreateDataFlowDebugSessionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.Models.CreateDataFlowDebugSessionResult>> CreateDataFlowDebugSessionAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataFactory.Models.CreateDataFlowDebugSessionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string factoryName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteDataFlowDebugSession(Azure.ResourceManager.DataFactory.Models.DeleteDataFlowDebugSessionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteDataFlowDebugSessionAsync(Azure.ResourceManager.DataFactory.Models.DeleteDataFlowDebugSessionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.Models.DataFlowDebugCommandResult> ExecuteCommandDataFlowDebugSession(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataFactory.Models.DataFlowDebugCommandContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.Models.DataFlowDebugCommandResult>> ExecuteCommandDataFlowDebugSessionAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataFactory.Models.DataFlowDebugCommandContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryResource> Get(string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataFactory.Models.ActivityRun> GetActivityRunsByPipelineRun(string runId, Azure.ResourceManager.DataFactory.Models.RunFilterContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataFactory.Models.ActivityRun> GetActivityRunsByPipelineRunAsync(string runId, Azure.ResourceManager.DataFactory.Models.RunFilterContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryResource>> GetAsync(string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryGlobalParameterResource> GetDataFactoryGlobalParameter(string globalParameterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryGlobalParameterResource>> GetDataFactoryGlobalParameterAsync(string globalParameterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataFactory.DataFactoryGlobalParameterCollection GetDataFactoryGlobalParameters() { throw null; }
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
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.DataFlowResource> GetDataFlowResource(string dataFlowName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.DataFlowResource>> GetDataFlowResourceAsync(string dataFlowName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataFactory.DataFlowResourceCollection GetDataFlowResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.Models.AccessPolicyResult> GetDataPlaneAccess(Azure.ResourceManager.DataFactory.Models.UserAccessPolicy policy, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.Models.AccessPolicyResult>> GetDataPlaneAccessAsync(Azure.ResourceManager.DataFactory.Models.UserAccessPolicy policy, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.DatasetResource> GetDatasetResource(string datasetName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.DatasetResource>> GetDatasetResourceAsync(string datasetName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataFactory.DatasetResourceCollection GetDatasetResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.Models.ExposureControlBatchResult> GetExposureControlFeatureValues(Azure.ResourceManager.DataFactory.Models.ExposureControlBatchContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.Models.ExposureControlBatchResult>> GetExposureControlFeatureValuesAsync(Azure.ResourceManager.DataFactory.Models.ExposureControlBatchContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.Models.ExposureControlResult> GetFeatureValueByFactoryExposureControl(Azure.ResourceManager.DataFactory.Models.ExposureControlContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.Models.ExposureControlResult>> GetFeatureValueByFactoryExposureControlAsync(Azure.ResourceManager.DataFactory.Models.ExposureControlContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.Models.GitHubAccessTokenResult> GetGitHubAccessToken(Azure.ResourceManager.DataFactory.Models.GitHubAccessTokenContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.Models.GitHubAccessTokenResult>> GetGitHubAccessTokenAsync(Azure.ResourceManager.DataFactory.Models.GitHubAccessTokenContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.IntegrationRuntimeResource> GetIntegrationRuntimeResource(string integrationRuntimeName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.IntegrationRuntimeResource>> GetIntegrationRuntimeResourceAsync(string integrationRuntimeName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataFactory.IntegrationRuntimeResourceCollection GetIntegrationRuntimeResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.LinkedServiceResource> GetLinkedServiceResource(string linkedServiceName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.LinkedServiceResource>> GetLinkedServiceResourceAsync(string linkedServiceName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataFactory.LinkedServiceResourceCollection GetLinkedServiceResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.ManagedVirtualNetworkResource> GetManagedVirtualNetworkResource(string managedVirtualNetworkName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.ManagedVirtualNetworkResource>> GetManagedVirtualNetworkResourceAsync(string managedVirtualNetworkName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataFactory.ManagedVirtualNetworkResourceCollection GetManagedVirtualNetworkResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.Models.PipelineRun> GetPipelineRun(string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.Models.PipelineRun>> GetPipelineRunAsync(string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataFactory.Models.PipelineRun> GetPipelineRuns(Azure.ResourceManager.DataFactory.Models.RunFilterContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataFactory.Models.PipelineRun> GetPipelineRunsAsync(Azure.ResourceManager.DataFactory.Models.RunFilterContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataFactory.Models.DataFactoryPrivateLinkResource> GetprivateLinkResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataFactory.Models.DataFactoryPrivateLinkResource> GetprivateLinkResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataFactory.Models.TriggerRun> GetTriggerRuns(Azure.ResourceManager.DataFactory.Models.RunFilterContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataFactory.Models.TriggerRun> GetTriggerRunsAsync(Azure.ResourceManager.DataFactory.Models.RunFilterContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataFactory.DataFactoryTriggerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataFactory.DataFactoryTriggerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataFactory.DataFactoryTriggerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataFactory.DataFactoryTriggerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataFactoryTriggerData : Azure.ResourceManager.Models.ResourceData
    {
        public DataFactoryTriggerData(Azure.ResourceManager.DataFactory.Models.DataFactoryTriggerProperties properties) { }
        public Azure.ETag? Etag { get { throw null; } }
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
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.Models.TriggerSubscriptionOperationStatus> GetEventSubscriptionStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.Models.TriggerSubscriptionOperationStatus>> GetEventSubscriptionStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RerunTriggerRun(string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RerunTriggerRunAsync(string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Start(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Stop(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StopAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.Models.TriggerSubscriptionOperationStatus> SubscribeToEvents(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.Models.TriggerSubscriptionOperationStatus>> SubscribeToEventsAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.Models.TriggerSubscriptionOperationStatus> UnsubscribeFromEvents(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.Models.TriggerSubscriptionOperationStatus>> UnsubscribeFromEventsAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.DataFactoryTriggerResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataFactory.DataFactoryTriggerData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.DataFactoryTriggerResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataFactory.DataFactoryTriggerData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataFlowResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataFlowResource() { }
        public virtual Azure.ResourceManager.DataFactory.DataFlowResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string factoryName, string dataFlowName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.DataFlowResource> Get(string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.DataFlowResource>> GetAsync(string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.DataFlowResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataFactory.DataFlowResourceData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.DataFlowResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataFactory.DataFlowResourceData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataFlowResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataFactory.DataFlowResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataFactory.DataFlowResource>, System.Collections.IEnumerable
    {
        protected DataFlowResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.DataFlowResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string dataFlowName, Azure.ResourceManager.DataFactory.DataFlowResourceData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.DataFlowResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string dataFlowName, Azure.ResourceManager.DataFactory.DataFlowResourceData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string dataFlowName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string dataFlowName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.DataFlowResource> Get(string dataFlowName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataFactory.DataFlowResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataFactory.DataFlowResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.DataFlowResource>> GetAsync(string dataFlowName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataFactory.DataFlowResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataFactory.DataFlowResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataFactory.DataFlowResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataFactory.DataFlowResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataFlowResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public DataFlowResourceData(Azure.ResourceManager.DataFactory.Models.DataFlow properties) { }
        public Azure.ETag? Etag { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.DataFlow Properties { get { throw null; } set { } }
    }
    public partial class DatasetResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DatasetResource() { }
        public virtual Azure.ResourceManager.DataFactory.DatasetResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string factoryName, string datasetName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.DatasetResource> Get(string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.DatasetResource>> GetAsync(string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.DatasetResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataFactory.DatasetResourceData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.DatasetResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataFactory.DatasetResourceData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatasetResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataFactory.DatasetResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataFactory.DatasetResource>, System.Collections.IEnumerable
    {
        protected DatasetResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.DatasetResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string datasetName, Azure.ResourceManager.DataFactory.DatasetResourceData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.DatasetResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string datasetName, Azure.ResourceManager.DataFactory.DatasetResourceData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string datasetName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string datasetName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.DatasetResource> Get(string datasetName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataFactory.DatasetResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataFactory.DatasetResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.DatasetResource>> GetAsync(string datasetName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataFactory.DatasetResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataFactory.DatasetResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataFactory.DatasetResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataFactory.DatasetResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DatasetResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public DatasetResourceData(Azure.ResourceManager.DataFactory.Models.Dataset properties) { }
        public Azure.ETag? Etag { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.Dataset Properties { get { throw null; } set { } }
    }
    public partial class IntegrationRuntimeResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected IntegrationRuntimeResource() { }
        public virtual Azure.ResourceManager.DataFactory.IntegrationRuntimeResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeStatusResult> CreateLinkedIntegrationRuntime(Azure.ResourceManager.DataFactory.Models.CreateLinkedIntegrationRuntimeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeStatusResult>> CreateLinkedIntegrationRuntimeAsync(Azure.ResourceManager.DataFactory.Models.CreateLinkedIntegrationRuntimeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string factoryName, string integrationRuntimeName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteIntegrationRuntimeNode(string nodeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteIntegrationRuntimeNodeAsync(string nodeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.IntegrationRuntimeResource> Get(string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataFactory.Models.SsisObjectMetadata> GetAllIntegrationRuntimeObjectMetadata(Azure.ResourceManager.DataFactory.Models.GetSsisObjectMetadataContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataFactory.Models.SsisObjectMetadata> GetAllIntegrationRuntimeObjectMetadataAsync(Azure.ResourceManager.DataFactory.Models.GetSsisObjectMetadataContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.IntegrationRuntimeResource>> GetAsync(string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Pageable<Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeOutboundNetworkDependenciesCategoryEndpoint> GetOutboundNetworkDependenciesEndpoints(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeOutboundNetworkDependenciesCategoryEndpoint> GetOutboundNetworkDependenciesEndpointsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeStatusResult> GetStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeStatusResult>> GetStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.Models.SsisObjectMetadataStatusResult> RefreshIntegrationRuntimeObjectMetadata(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.Models.SsisObjectMetadataStatusResult>> RefreshIntegrationRuntimeObjectMetadataAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeAuthKeys> RegenerateAuthKey(Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeRegenerateKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeAuthKeys>> RegenerateAuthKeyAsync(Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeRegenerateKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RemoveLinks(Azure.ResourceManager.DataFactory.Models.LinkedIntegrationRuntimeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RemoveLinksAsync(Azure.ResourceManager.DataFactory.Models.LinkedIntegrationRuntimeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeStatusResult> Start(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeStatusResult>> StartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Stop(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StopAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SyncCredentials(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SyncCredentialsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.IntegrationRuntimeResource> Update(Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.IntegrationRuntimeResource>> UpdateAsync(Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.Models.SelfHostedIntegrationRuntimeNode> UpdateIntegrationRuntimeNode(string nodeName, Azure.ResourceManager.DataFactory.Models.UpdateIntegrationRuntimeNodeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.Models.SelfHostedIntegrationRuntimeNode>> UpdateIntegrationRuntimeNodeAsync(string nodeName, Azure.ResourceManager.DataFactory.Models.UpdateIntegrationRuntimeNodeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Upgrade(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpgradeAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class IntegrationRuntimeResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataFactory.IntegrationRuntimeResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataFactory.IntegrationRuntimeResource>, System.Collections.IEnumerable
    {
        protected IntegrationRuntimeResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.IntegrationRuntimeResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string integrationRuntimeName, Azure.ResourceManager.DataFactory.IntegrationRuntimeResourceData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.IntegrationRuntimeResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string integrationRuntimeName, Azure.ResourceManager.DataFactory.IntegrationRuntimeResourceData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string integrationRuntimeName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string integrationRuntimeName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.IntegrationRuntimeResource> Get(string integrationRuntimeName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataFactory.IntegrationRuntimeResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataFactory.IntegrationRuntimeResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.IntegrationRuntimeResource>> GetAsync(string integrationRuntimeName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataFactory.IntegrationRuntimeResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataFactory.IntegrationRuntimeResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataFactory.IntegrationRuntimeResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataFactory.IntegrationRuntimeResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class IntegrationRuntimeResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public IntegrationRuntimeResourceData(Azure.ResourceManager.DataFactory.Models.IntegrationRuntime properties) { }
        public Azure.ETag? Etag { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.IntegrationRuntime Properties { get { throw null; } set { } }
    }
    public partial class LinkedServiceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LinkedServiceResource() { }
        public virtual Azure.ResourceManager.DataFactory.LinkedServiceResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string factoryName, string linkedServiceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.LinkedServiceResource> Get(string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.LinkedServiceResource>> GetAsync(string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.LinkedServiceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataFactory.LinkedServiceResourceData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.LinkedServiceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataFactory.LinkedServiceResourceData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LinkedServiceResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataFactory.LinkedServiceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataFactory.LinkedServiceResource>, System.Collections.IEnumerable
    {
        protected LinkedServiceResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.LinkedServiceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string linkedServiceName, Azure.ResourceManager.DataFactory.LinkedServiceResourceData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.LinkedServiceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string linkedServiceName, Azure.ResourceManager.DataFactory.LinkedServiceResourceData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string linkedServiceName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string linkedServiceName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.LinkedServiceResource> Get(string linkedServiceName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataFactory.LinkedServiceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataFactory.LinkedServiceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.LinkedServiceResource>> GetAsync(string linkedServiceName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataFactory.LinkedServiceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataFactory.LinkedServiceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataFactory.LinkedServiceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataFactory.LinkedServiceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LinkedServiceResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public LinkedServiceResourceData(Azure.ResourceManager.DataFactory.Models.LinkedService properties) { }
        public Azure.ETag? Etag { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.LinkedService Properties { get { throw null; } set { } }
    }
    public partial class ManagedPrivateEndpointResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ManagedPrivateEndpointResource() { }
        public virtual Azure.ResourceManager.DataFactory.ManagedPrivateEndpointResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string factoryName, string managedVirtualNetworkName, string managedPrivateEndpointName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.ManagedPrivateEndpointResource> Get(string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.ManagedPrivateEndpointResource>> GetAsync(string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.ManagedPrivateEndpointResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataFactory.ManagedPrivateEndpointResourceData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.ManagedPrivateEndpointResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataFactory.ManagedPrivateEndpointResourceData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedPrivateEndpointResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataFactory.ManagedPrivateEndpointResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataFactory.ManagedPrivateEndpointResource>, System.Collections.IEnumerable
    {
        protected ManagedPrivateEndpointResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.ManagedPrivateEndpointResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string managedPrivateEndpointName, Azure.ResourceManager.DataFactory.ManagedPrivateEndpointResourceData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.ManagedPrivateEndpointResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string managedPrivateEndpointName, Azure.ResourceManager.DataFactory.ManagedPrivateEndpointResourceData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string managedPrivateEndpointName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string managedPrivateEndpointName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.ManagedPrivateEndpointResource> Get(string managedPrivateEndpointName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataFactory.ManagedPrivateEndpointResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataFactory.ManagedPrivateEndpointResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.ManagedPrivateEndpointResource>> GetAsync(string managedPrivateEndpointName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataFactory.ManagedPrivateEndpointResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataFactory.ManagedPrivateEndpointResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataFactory.ManagedPrivateEndpointResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataFactory.ManagedPrivateEndpointResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ManagedPrivateEndpointResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public ManagedPrivateEndpointResourceData(Azure.ResourceManager.DataFactory.Models.ManagedPrivateEndpoint properties) { }
        public Azure.ETag? Etag { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.ManagedPrivateEndpoint Properties { get { throw null; } set { } }
    }
    public partial class ManagedVirtualNetworkResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ManagedVirtualNetworkResource() { }
        public virtual Azure.ResourceManager.DataFactory.ManagedVirtualNetworkResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string factoryName, string managedVirtualNetworkName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.ManagedVirtualNetworkResource> Get(string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.ManagedVirtualNetworkResource>> GetAsync(string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.ManagedPrivateEndpointResource> GetManagedPrivateEndpointResource(string managedPrivateEndpointName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.ManagedPrivateEndpointResource>> GetManagedPrivateEndpointResourceAsync(string managedPrivateEndpointName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataFactory.ManagedPrivateEndpointResourceCollection GetManagedPrivateEndpointResources() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.ManagedVirtualNetworkResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataFactory.ManagedVirtualNetworkResourceData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.ManagedVirtualNetworkResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataFactory.ManagedVirtualNetworkResourceData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedVirtualNetworkResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataFactory.ManagedVirtualNetworkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataFactory.ManagedVirtualNetworkResource>, System.Collections.IEnumerable
    {
        protected ManagedVirtualNetworkResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.ManagedVirtualNetworkResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string managedVirtualNetworkName, Azure.ResourceManager.DataFactory.ManagedVirtualNetworkResourceData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.ManagedVirtualNetworkResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string managedVirtualNetworkName, Azure.ResourceManager.DataFactory.ManagedVirtualNetworkResourceData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string managedVirtualNetworkName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string managedVirtualNetworkName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.ManagedVirtualNetworkResource> Get(string managedVirtualNetworkName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataFactory.ManagedVirtualNetworkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataFactory.ManagedVirtualNetworkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.ManagedVirtualNetworkResource>> GetAsync(string managedVirtualNetworkName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataFactory.ManagedVirtualNetworkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataFactory.ManagedVirtualNetworkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataFactory.ManagedVirtualNetworkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataFactory.ManagedVirtualNetworkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ManagedVirtualNetworkResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public ManagedVirtualNetworkResourceData(Azure.ResourceManager.DataFactory.Models.ManagedVirtualNetwork properties) { }
        public Azure.ETag? Etag { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.ManagedVirtualNetwork Properties { get { throw null; } set { } }
    }
}
namespace Azure.ResourceManager.DataFactory.Models
{
    public partial class AccessPolicyResult
    {
        internal AccessPolicyResult() { }
        public string AccessToken { get { throw null; } }
        public System.Uri DataPlaneUri { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.UserAccessPolicy Policy { get { throw null; } }
    }
    public partial class ActivityDependency
    {
        public ActivityDependency(string activity, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataFactory.Models.DependencyCondition> dependencyConditions) { }
        public string Activity { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.DependencyCondition> DependencyConditions { get { throw null; } }
    }
    public partial class ActivityPolicy
    {
        public ActivityPolicy() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public System.BinaryData Retry { get { throw null; } set { } }
        public int? RetryIntervalInSeconds { get { throw null; } set { } }
        public bool? SecureInput { get { throw null; } set { } }
        public bool? SecureOutput { get { throw null; } set { } }
        public System.BinaryData Timeout { get { throw null; } set { } }
    }
    public partial class ActivityRun
    {
        internal ActivityRun() { }
        public string ActivityName { get { throw null; } }
        public System.DateTimeOffset? ActivityRunEnd { get { throw null; } }
        public string ActivityRunId { get { throw null; } }
        public System.DateTimeOffset? ActivityRunStart { get { throw null; } }
        public string ActivityType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public int? DurationInMs { get { throw null; } }
        public System.BinaryData Error { get { throw null; } }
        public System.BinaryData Input { get { throw null; } }
        public string LinkedServiceName { get { throw null; } }
        public System.BinaryData Output { get { throw null; } }
        public string PipelineName { get { throw null; } }
        public string PipelineRunId { get { throw null; } }
        public string Status { get { throw null; } }
    }
    public partial class AddDataFlowToDebugSessionResult
    {
        internal AddDataFlowToDebugSessionResult() { }
        public string JobVersion { get { throw null; } }
    }
    public partial class AmazonMwsLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public AmazonMwsLinkedService(System.BinaryData endpoint, System.BinaryData marketplaceId, System.BinaryData sellerId, System.BinaryData accessKeyId) { }
        public System.BinaryData AccessKeyId { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData Endpoint { get { throw null; } set { } }
        public System.BinaryData MarketplaceId { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase MwsAuthToken { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase SecretKey { get { throw null; } set { } }
        public System.BinaryData SellerId { get { throw null; } set { } }
        public System.BinaryData UseEncryptedEndpoints { get { throw null; } set { } }
        public System.BinaryData UseHostVerification { get { throw null; } set { } }
        public System.BinaryData UsePeerVerification { get { throw null; } set { } }
    }
    public partial class AmazonMwsObjectDataset : Azure.ResourceManager.DataFactory.Models.Dataset
    {
        public AmazonMwsObjectDataset(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference)) { }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class AmazonMwsSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public AmazonMwsSource() { }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    public partial class AmazonRdsForOracleLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public AmazonRdsForOracleLinkedService(System.BinaryData connectionString) { }
        public System.BinaryData ConnectionString { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase Password { get { throw null; } set { } }
    }
    public partial class AmazonRdsForOraclePartitionSettings
    {
        public AmazonRdsForOraclePartitionSettings() { }
        public System.BinaryData PartitionColumnName { get { throw null; } set { } }
        public System.BinaryData PartitionLowerBound { get { throw null; } set { } }
        public System.BinaryData PartitionNames { get { throw null; } set { } }
        public System.BinaryData PartitionUpperBound { get { throw null; } set { } }
    }
    public partial class AmazonRdsForOracleSource : Azure.ResourceManager.DataFactory.Models.CopySource
    {
        public AmazonRdsForOracleSource() { }
        public System.BinaryData AdditionalColumns { get { throw null; } set { } }
        public System.BinaryData OracleReaderQuery { get { throw null; } set { } }
        public System.BinaryData PartitionOption { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.AmazonRdsForOraclePartitionSettings PartitionSettings { get { throw null; } set { } }
        public System.BinaryData QueryTimeout { get { throw null; } set { } }
    }
    public partial class AmazonRdsForOracleTableDataset : Azure.ResourceManager.DataFactory.Models.Dataset
    {
        public AmazonRdsForOracleTableDataset(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference)) { }
        public System.BinaryData SchemaTypePropertiesSchema { get { throw null; } set { } }
        public System.BinaryData Table { get { throw null; } set { } }
    }
    public partial class AmazonRdsForSqlServerLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public AmazonRdsForSqlServerLinkedService(System.BinaryData connectionString) { }
        public Azure.ResourceManager.DataFactory.Models.SqlAlwaysEncryptedProperties AlwaysEncryptedSettings { get { throw null; } set { } }
        public System.BinaryData ConnectionString { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase Password { get { throw null; } set { } }
        public System.BinaryData UserName { get { throw null; } set { } }
    }
    public partial class AmazonRdsForSqlServerSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public AmazonRdsForSqlServerSource() { }
        public System.BinaryData PartitionOption { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SqlPartitionSettings PartitionSettings { get { throw null; } set { } }
        public System.BinaryData ProduceAdditionalTypes { get { throw null; } set { } }
        public System.BinaryData SqlReaderQuery { get { throw null; } set { } }
        public System.BinaryData SqlReaderStoredProcedureName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DataFactory.Models.StoredProcedureParameter> StoredProcedureParameters { get { throw null; } }
    }
    public partial class AmazonRdsForSqlServerTableDataset : Azure.ResourceManager.DataFactory.Models.Dataset
    {
        public AmazonRdsForSqlServerTableDataset(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference)) { }
        public System.BinaryData SchemaTypePropertiesSchema { get { throw null; } set { } }
        public System.BinaryData Table { get { throw null; } set { } }
    }
    public partial class AmazonRedshiftLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public AmazonRedshiftLinkedService(System.BinaryData server, System.BinaryData database) { }
        public System.BinaryData Database { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase Password { get { throw null; } set { } }
        public System.BinaryData Port { get { throw null; } set { } }
        public System.BinaryData Server { get { throw null; } set { } }
        public System.BinaryData Username { get { throw null; } set { } }
    }
    public partial class AmazonRedshiftSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public AmazonRedshiftSource() { }
        public System.BinaryData Query { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.RedshiftUnloadSettings RedshiftUnloadSettings { get { throw null; } set { } }
    }
    public partial class AmazonRedshiftTableDataset : Azure.ResourceManager.DataFactory.Models.Dataset
    {
        public AmazonRedshiftTableDataset(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference)) { }
        public System.BinaryData SchemaTypePropertiesSchema { get { throw null; } set { } }
        public System.BinaryData Table { get { throw null; } set { } }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class AmazonS3CompatibleLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public AmazonS3CompatibleLinkedService() { }
        public System.BinaryData AccessKeyId { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData ForcePathStyle { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase SecretAccessKey { get { throw null; } set { } }
        public System.BinaryData ServiceUri { get { throw null; } set { } }
    }
    public partial class AmazonS3CompatibleLocation : Azure.ResourceManager.DataFactory.Models.DatasetLocation
    {
        public AmazonS3CompatibleLocation() { }
        public System.BinaryData BucketName { get { throw null; } set { } }
        public System.BinaryData Version { get { throw null; } set { } }
    }
    public partial class AmazonS3CompatibleReadSettings : Azure.ResourceManager.DataFactory.Models.StoreReadSettings
    {
        public AmazonS3CompatibleReadSettings() { }
        public System.BinaryData DeleteFilesAfterCompletion { get { throw null; } set { } }
        public bool? EnablePartitionDiscovery { get { throw null; } set { } }
        public System.BinaryData FileListPath { get { throw null; } set { } }
        public System.BinaryData ModifiedDatetimeEnd { get { throw null; } set { } }
        public System.BinaryData ModifiedDatetimeStart { get { throw null; } set { } }
        public System.BinaryData PartitionRootPath { get { throw null; } set { } }
        public System.BinaryData Prefix { get { throw null; } set { } }
        public System.BinaryData Recursive { get { throw null; } set { } }
        public System.BinaryData WildcardFileName { get { throw null; } set { } }
        public System.BinaryData WildcardFolderPath { get { throw null; } set { } }
    }
    public partial class AmazonS3Dataset : Azure.ResourceManager.DataFactory.Models.Dataset
    {
        public AmazonS3Dataset(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName, System.BinaryData bucketName) : base (default(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference)) { }
        public System.BinaryData BucketName { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DatasetCompression Compression { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DatasetStorageFormat Format { get { throw null; } set { } }
        public System.BinaryData Key { get { throw null; } set { } }
        public System.BinaryData ModifiedDatetimeEnd { get { throw null; } set { } }
        public System.BinaryData ModifiedDatetimeStart { get { throw null; } set { } }
        public System.BinaryData Prefix { get { throw null; } set { } }
        public System.BinaryData Version { get { throw null; } set { } }
    }
    public partial class AmazonS3LinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public AmazonS3LinkedService() { }
        public System.BinaryData AccessKeyId { get { throw null; } set { } }
        public System.BinaryData AuthenticationType { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase SecretAccessKey { get { throw null; } set { } }
        public System.BinaryData ServiceUri { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase SessionToken { get { throw null; } set { } }
    }
    public partial class AmazonS3Location : Azure.ResourceManager.DataFactory.Models.DatasetLocation
    {
        public AmazonS3Location() { }
        public System.BinaryData BucketName { get { throw null; } set { } }
        public System.BinaryData Version { get { throw null; } set { } }
    }
    public partial class AmazonS3ReadSettings : Azure.ResourceManager.DataFactory.Models.StoreReadSettings
    {
        public AmazonS3ReadSettings() { }
        public System.BinaryData DeleteFilesAfterCompletion { get { throw null; } set { } }
        public bool? EnablePartitionDiscovery { get { throw null; } set { } }
        public System.BinaryData FileListPath { get { throw null; } set { } }
        public System.BinaryData ModifiedDatetimeEnd { get { throw null; } set { } }
        public System.BinaryData ModifiedDatetimeStart { get { throw null; } set { } }
        public System.BinaryData PartitionRootPath { get { throw null; } set { } }
        public System.BinaryData Prefix { get { throw null; } set { } }
        public System.BinaryData Recursive { get { throw null; } set { } }
        public System.BinaryData WildcardFileName { get { throw null; } set { } }
        public System.BinaryData WildcardFolderPath { get { throw null; } set { } }
    }
    public partial class AppendVariableActivity : Azure.ResourceManager.DataFactory.Models.ControlActivity
    {
        public AppendVariableActivity(string name) : base (default(string)) { }
        public System.BinaryData Value { get { throw null; } set { } }
        public string VariableName { get { throw null; } set { } }
    }
    public partial class AppFiguresLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public AppFiguresLinkedService(System.BinaryData userName, Azure.ResourceManager.DataFactory.Models.SecretBase password, Azure.ResourceManager.DataFactory.Models.SecretBase clientKey) { }
        public Azure.ResourceManager.DataFactory.Models.SecretBase ClientKey { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase Password { get { throw null; } set { } }
        public System.BinaryData UserName { get { throw null; } set { } }
    }
    public partial class AsanaLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public AsanaLinkedService(Azure.ResourceManager.DataFactory.Models.SecretBase apiToken) { }
        public Azure.ResourceManager.DataFactory.Models.SecretBase ApiToken { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
    }
    public partial class AvroDataset : Azure.ResourceManager.DataFactory.Models.Dataset
    {
        public AvroDataset(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference)) { }
        public System.BinaryData AvroCompressionCodec { get { throw null; } set { } }
        public int? AvroCompressionLevel { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DatasetLocation Location { get { throw null; } set { } }
    }
    public partial class AvroFormat : Azure.ResourceManager.DataFactory.Models.DatasetStorageFormat
    {
        public AvroFormat() { }
    }
    public partial class AvroSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public AvroSink() { }
        public Azure.ResourceManager.DataFactory.Models.AvroWriteSettings FormatSettings { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.StoreWriteSettings StoreSettings { get { throw null; } set { } }
    }
    public partial class AvroSource : Azure.ResourceManager.DataFactory.Models.CopySource
    {
        public AvroSource() { }
        public System.BinaryData AdditionalColumns { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.StoreReadSettings StoreSettings { get { throw null; } set { } }
    }
    public partial class AvroWriteSettings : Azure.ResourceManager.DataFactory.Models.FormatWriteSettings
    {
        public AvroWriteSettings() { }
        public System.BinaryData FileNamePrefix { get { throw null; } set { } }
        public System.BinaryData MaxRowsPerFile { get { throw null; } set { } }
        public string RecordName { get { throw null; } set { } }
        public string RecordNamespace { get { throw null; } set { } }
    }
    public partial class AzPowerShellSetup : Azure.ResourceManager.DataFactory.Models.CustomSetupBase
    {
        public AzPowerShellSetup(string version) { }
        public string Version { get { throw null; } set { } }
    }
    public partial class AzureBatchLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public AzureBatchLinkedService(System.BinaryData accountName, System.BinaryData batchUri, System.BinaryData poolName, Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName) { }
        public Azure.ResourceManager.DataFactory.Models.SecretBase AccessKey { get { throw null; } set { } }
        public System.BinaryData AccountName { get { throw null; } set { } }
        public System.BinaryData BatchUri { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.CredentialReference Credential { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.LinkedServiceReference LinkedServiceName { get { throw null; } set { } }
        public System.BinaryData PoolName { get { throw null; } set { } }
    }
    public partial class AzureBlobDataset : Azure.ResourceManager.DataFactory.Models.Dataset
    {
        public AzureBlobDataset(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference)) { }
        public Azure.ResourceManager.DataFactory.Models.DatasetCompression Compression { get { throw null; } set { } }
        public System.BinaryData FileName { get { throw null; } set { } }
        public System.BinaryData FolderPath { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DatasetStorageFormat Format { get { throw null; } set { } }
        public System.BinaryData ModifiedDatetimeEnd { get { throw null; } set { } }
        public System.BinaryData ModifiedDatetimeStart { get { throw null; } set { } }
        public System.BinaryData TableRootLocation { get { throw null; } set { } }
    }
    public partial class AzureBlobFSDataset : Azure.ResourceManager.DataFactory.Models.Dataset
    {
        public AzureBlobFSDataset(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference)) { }
        public Azure.ResourceManager.DataFactory.Models.DatasetCompression Compression { get { throw null; } set { } }
        public System.BinaryData FileName { get { throw null; } set { } }
        public System.BinaryData FolderPath { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DatasetStorageFormat Format { get { throw null; } set { } }
    }
    public partial class AzureBlobFSLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public AzureBlobFSLinkedService(System.BinaryData uri) { }
        public System.BinaryData AccountKey { get { throw null; } set { } }
        public System.BinaryData AzureCloudType { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.CredentialReference Credential { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase ServicePrincipalCredential { get { throw null; } set { } }
        public System.BinaryData ServicePrincipalCredentialType { get { throw null; } set { } }
        public System.BinaryData ServicePrincipalId { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase ServicePrincipalKey { get { throw null; } set { } }
        public System.BinaryData Tenant { get { throw null; } set { } }
        public System.BinaryData Uri { get { throw null; } set { } }
    }
    public partial class AzureBlobFSLocation : Azure.ResourceManager.DataFactory.Models.DatasetLocation
    {
        public AzureBlobFSLocation() { }
        public System.BinaryData FileSystem { get { throw null; } set { } }
    }
    public partial class AzureBlobFSReadSettings : Azure.ResourceManager.DataFactory.Models.StoreReadSettings
    {
        public AzureBlobFSReadSettings() { }
        public System.BinaryData DeleteFilesAfterCompletion { get { throw null; } set { } }
        public bool? EnablePartitionDiscovery { get { throw null; } set { } }
        public System.BinaryData FileListPath { get { throw null; } set { } }
        public System.BinaryData ModifiedDatetimeEnd { get { throw null; } set { } }
        public System.BinaryData ModifiedDatetimeStart { get { throw null; } set { } }
        public System.BinaryData PartitionRootPath { get { throw null; } set { } }
        public System.BinaryData Recursive { get { throw null; } set { } }
        public System.BinaryData WildcardFileName { get { throw null; } set { } }
        public System.BinaryData WildcardFolderPath { get { throw null; } set { } }
    }
    public partial class AzureBlobFSSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public AzureBlobFSSink() { }
        public System.BinaryData CopyBehavior { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.MetadataItem> Metadata { get { throw null; } }
    }
    public partial class AzureBlobFSSource : Azure.ResourceManager.DataFactory.Models.CopySource
    {
        public AzureBlobFSSource() { }
        public System.BinaryData Recursive { get { throw null; } set { } }
        public System.BinaryData SkipHeaderLineCount { get { throw null; } set { } }
        public System.BinaryData TreatEmptyAsNull { get { throw null; } set { } }
    }
    public partial class AzureBlobFSWriteSettings : Azure.ResourceManager.DataFactory.Models.StoreWriteSettings
    {
        public AzureBlobFSWriteSettings() { }
        public System.BinaryData BlockSizeInMB { get { throw null; } set { } }
    }
    public partial class AzureBlobStorageLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public AzureBlobStorageLinkedService() { }
        public Azure.ResourceManager.DataFactory.Models.AzureKeyVaultSecretReference AccountKey { get { throw null; } set { } }
        public string AccountKind { get { throw null; } set { } }
        public System.BinaryData AzureCloudType { get { throw null; } set { } }
        public System.BinaryData ConnectionString { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.CredentialReference Credential { get { throw null; } set { } }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.AzureKeyVaultSecretReference SasToken { get { throw null; } set { } }
        public System.BinaryData SasUri { get { throw null; } set { } }
        public string ServiceEndpoint { get { throw null; } set { } }
        public System.BinaryData ServicePrincipalId { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase ServicePrincipalKey { get { throw null; } set { } }
        public System.BinaryData Tenant { get { throw null; } set { } }
    }
    public partial class AzureBlobStorageLocation : Azure.ResourceManager.DataFactory.Models.DatasetLocation
    {
        public AzureBlobStorageLocation() { }
        public System.BinaryData Container { get { throw null; } set { } }
    }
    public partial class AzureBlobStorageReadSettings : Azure.ResourceManager.DataFactory.Models.StoreReadSettings
    {
        public AzureBlobStorageReadSettings() { }
        public System.BinaryData DeleteFilesAfterCompletion { get { throw null; } set { } }
        public bool? EnablePartitionDiscovery { get { throw null; } set { } }
        public System.BinaryData FileListPath { get { throw null; } set { } }
        public System.BinaryData ModifiedDatetimeEnd { get { throw null; } set { } }
        public System.BinaryData ModifiedDatetimeStart { get { throw null; } set { } }
        public System.BinaryData PartitionRootPath { get { throw null; } set { } }
        public System.BinaryData Prefix { get { throw null; } set { } }
        public System.BinaryData Recursive { get { throw null; } set { } }
        public System.BinaryData WildcardFileName { get { throw null; } set { } }
        public System.BinaryData WildcardFolderPath { get { throw null; } set { } }
    }
    public partial class AzureBlobStorageWriteSettings : Azure.ResourceManager.DataFactory.Models.StoreWriteSettings
    {
        public AzureBlobStorageWriteSettings() { }
        public System.BinaryData BlockSizeInMB { get { throw null; } set { } }
    }
    public partial class AzureDatabricksDeltaLakeDataset : Azure.ResourceManager.DataFactory.Models.Dataset
    {
        public AzureDatabricksDeltaLakeDataset(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference)) { }
        public System.BinaryData Database { get { throw null; } set { } }
        public System.BinaryData Table { get { throw null; } set { } }
    }
    public partial class AzureDatabricksDeltaLakeExportCommand : Azure.ResourceManager.DataFactory.Models.ExportSettings
    {
        public AzureDatabricksDeltaLakeExportCommand() { }
        public System.BinaryData DateFormat { get { throw null; } set { } }
        public System.BinaryData TimestampFormat { get { throw null; } set { } }
    }
    public partial class AzureDatabricksDeltaLakeImportCommand : Azure.ResourceManager.DataFactory.Models.ImportSettings
    {
        public AzureDatabricksDeltaLakeImportCommand() { }
        public System.BinaryData DateFormat { get { throw null; } set { } }
        public System.BinaryData TimestampFormat { get { throw null; } set { } }
    }
    public partial class AzureDatabricksDeltaLakeLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public AzureDatabricksDeltaLakeLinkedService(System.BinaryData domain) { }
        public Azure.ResourceManager.DataFactory.Models.SecretBase AccessToken { get { throw null; } set { } }
        public System.BinaryData ClusterId { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.CredentialReference Credential { get { throw null; } set { } }
        public System.BinaryData Domain { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData WorkspaceResourceId { get { throw null; } set { } }
    }
    public partial class AzureDatabricksDeltaLakeSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public AzureDatabricksDeltaLakeSink() { }
        public Azure.ResourceManager.DataFactory.Models.AzureDatabricksDeltaLakeImportCommand ImportSettings { get { throw null; } set { } }
        public System.BinaryData PreCopyScript { get { throw null; } set { } }
    }
    public partial class AzureDatabricksDeltaLakeSource : Azure.ResourceManager.DataFactory.Models.CopySource
    {
        public AzureDatabricksDeltaLakeSource() { }
        public Azure.ResourceManager.DataFactory.Models.AzureDatabricksDeltaLakeExportCommand ExportSettings { get { throw null; } set { } }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    public partial class AzureDatabricksLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public AzureDatabricksLinkedService(System.BinaryData domain) { }
        public Azure.ResourceManager.DataFactory.Models.SecretBase AccessToken { get { throw null; } set { } }
        public System.BinaryData Authentication { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.CredentialReference Credential { get { throw null; } set { } }
        public System.BinaryData Domain { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData ExistingClusterId { get { throw null; } set { } }
        public System.BinaryData InstancePoolId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> NewClusterCustomTags { get { throw null; } }
        public System.BinaryData NewClusterDriverNodeType { get { throw null; } set { } }
        public System.BinaryData NewClusterEnableElasticDisk { get { throw null; } set { } }
        public System.BinaryData NewClusterInitScripts { get { throw null; } set { } }
        public System.BinaryData NewClusterLogDestination { get { throw null; } set { } }
        public System.BinaryData NewClusterNodeType { get { throw null; } set { } }
        public System.BinaryData NewClusterNumOfWorker { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> NewClusterSparkConf { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> NewClusterSparkEnvVars { get { throw null; } }
        public System.BinaryData NewClusterVersion { get { throw null; } set { } }
        public System.BinaryData PolicyId { get { throw null; } set { } }
        public System.BinaryData WorkspaceResourceId { get { throw null; } set { } }
    }
    public partial class AzureDataExplorerCommandActivity : Azure.ResourceManager.DataFactory.Models.ExecutionActivity
    {
        public AzureDataExplorerCommandActivity(string name, System.BinaryData command) : base (default(string)) { }
        public System.BinaryData Command { get { throw null; } set { } }
        public System.BinaryData CommandTimeout { get { throw null; } set { } }
    }
    public partial class AzureDataExplorerLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public AzureDataExplorerLinkedService(System.BinaryData endpoint, System.BinaryData database) { }
        public Azure.ResourceManager.DataFactory.Models.CredentialReference Credential { get { throw null; } set { } }
        public System.BinaryData Database { get { throw null; } set { } }
        public System.BinaryData Endpoint { get { throw null; } set { } }
        public System.BinaryData ServicePrincipalId { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase ServicePrincipalKey { get { throw null; } set { } }
        public System.BinaryData Tenant { get { throw null; } set { } }
    }
    public partial class AzureDataExplorerSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public AzureDataExplorerSink() { }
        public System.BinaryData FlushImmediately { get { throw null; } set { } }
        public System.BinaryData IngestionMappingAsJson { get { throw null; } set { } }
        public System.BinaryData IngestionMappingName { get { throw null; } set { } }
    }
    public partial class AzureDataExplorerSource : Azure.ResourceManager.DataFactory.Models.CopySource
    {
        public AzureDataExplorerSource(System.BinaryData query) { }
        public System.BinaryData AdditionalColumns { get { throw null; } set { } }
        public System.BinaryData NoTruncation { get { throw null; } set { } }
        public System.BinaryData Query { get { throw null; } set { } }
        public System.BinaryData QueryTimeout { get { throw null; } set { } }
    }
    public partial class AzureDataExplorerTableDataset : Azure.ResourceManager.DataFactory.Models.Dataset
    {
        public AzureDataExplorerTableDataset(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference)) { }
        public System.BinaryData Table { get { throw null; } set { } }
    }
    public partial class AzureDataLakeAnalyticsLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public AzureDataLakeAnalyticsLinkedService(System.BinaryData accountName, System.BinaryData tenant) { }
        public System.BinaryData AccountName { get { throw null; } set { } }
        public System.BinaryData DataLakeAnalyticsUri { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData ResourceGroupName { get { throw null; } set { } }
        public System.BinaryData ServicePrincipalId { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase ServicePrincipalKey { get { throw null; } set { } }
        public System.BinaryData SubscriptionId { get { throw null; } set { } }
        public System.BinaryData Tenant { get { throw null; } set { } }
    }
    public partial class AzureDataLakeStoreDataset : Azure.ResourceManager.DataFactory.Models.Dataset
    {
        public AzureDataLakeStoreDataset(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference)) { }
        public Azure.ResourceManager.DataFactory.Models.DatasetCompression Compression { get { throw null; } set { } }
        public System.BinaryData FileName { get { throw null; } set { } }
        public System.BinaryData FolderPath { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DatasetStorageFormat Format { get { throw null; } set { } }
    }
    public partial class AzureDataLakeStoreLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public AzureDataLakeStoreLinkedService(System.BinaryData dataLakeStoreUri) { }
        public System.BinaryData AccountName { get { throw null; } set { } }
        public System.BinaryData AzureCloudType { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.CredentialReference Credential { get { throw null; } set { } }
        public System.BinaryData DataLakeStoreUri { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData ResourceGroupName { get { throw null; } set { } }
        public System.BinaryData ServicePrincipalId { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase ServicePrincipalKey { get { throw null; } set { } }
        public System.BinaryData SubscriptionId { get { throw null; } set { } }
        public System.BinaryData Tenant { get { throw null; } set { } }
    }
    public partial class AzureDataLakeStoreLocation : Azure.ResourceManager.DataFactory.Models.DatasetLocation
    {
        public AzureDataLakeStoreLocation() { }
    }
    public partial class AzureDataLakeStoreReadSettings : Azure.ResourceManager.DataFactory.Models.StoreReadSettings
    {
        public AzureDataLakeStoreReadSettings() { }
        public System.BinaryData DeleteFilesAfterCompletion { get { throw null; } set { } }
        public bool? EnablePartitionDiscovery { get { throw null; } set { } }
        public System.BinaryData FileListPath { get { throw null; } set { } }
        public System.BinaryData ListAfter { get { throw null; } set { } }
        public System.BinaryData ListBefore { get { throw null; } set { } }
        public System.BinaryData ModifiedDatetimeEnd { get { throw null; } set { } }
        public System.BinaryData ModifiedDatetimeStart { get { throw null; } set { } }
        public System.BinaryData PartitionRootPath { get { throw null; } set { } }
        public System.BinaryData Recursive { get { throw null; } set { } }
        public System.BinaryData WildcardFileName { get { throw null; } set { } }
        public System.BinaryData WildcardFolderPath { get { throw null; } set { } }
    }
    public partial class AzureDataLakeStoreSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public AzureDataLakeStoreSink() { }
        public System.BinaryData CopyBehavior { get { throw null; } set { } }
        public System.BinaryData EnableAdlsSingleFileParallel { get { throw null; } set { } }
    }
    public partial class AzureDataLakeStoreSource : Azure.ResourceManager.DataFactory.Models.CopySource
    {
        public AzureDataLakeStoreSource() { }
        public System.BinaryData Recursive { get { throw null; } set { } }
    }
    public partial class AzureDataLakeStoreWriteSettings : Azure.ResourceManager.DataFactory.Models.StoreWriteSettings
    {
        public AzureDataLakeStoreWriteSettings() { }
        public System.BinaryData ExpiryDateTime { get { throw null; } set { } }
    }
    public partial class AzureFileStorageLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public AzureFileStorageLinkedService() { }
        public Azure.ResourceManager.DataFactory.Models.AzureKeyVaultSecretReference AccountKey { get { throw null; } set { } }
        public System.BinaryData ConnectionString { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData FileShare { get { throw null; } set { } }
        public System.BinaryData Host { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase Password { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.AzureKeyVaultSecretReference SasToken { get { throw null; } set { } }
        public System.BinaryData SasUri { get { throw null; } set { } }
        public System.BinaryData Snapshot { get { throw null; } set { } }
        public System.BinaryData UserId { get { throw null; } set { } }
    }
    public partial class AzureFileStorageLocation : Azure.ResourceManager.DataFactory.Models.DatasetLocation
    {
        public AzureFileStorageLocation() { }
    }
    public partial class AzureFileStorageReadSettings : Azure.ResourceManager.DataFactory.Models.StoreReadSettings
    {
        public AzureFileStorageReadSettings() { }
        public System.BinaryData DeleteFilesAfterCompletion { get { throw null; } set { } }
        public bool? EnablePartitionDiscovery { get { throw null; } set { } }
        public System.BinaryData FileListPath { get { throw null; } set { } }
        public System.BinaryData ModifiedDatetimeEnd { get { throw null; } set { } }
        public System.BinaryData ModifiedDatetimeStart { get { throw null; } set { } }
        public System.BinaryData PartitionRootPath { get { throw null; } set { } }
        public System.BinaryData Prefix { get { throw null; } set { } }
        public System.BinaryData Recursive { get { throw null; } set { } }
        public System.BinaryData WildcardFileName { get { throw null; } set { } }
        public System.BinaryData WildcardFolderPath { get { throw null; } set { } }
    }
    public partial class AzureFileStorageWriteSettings : Azure.ResourceManager.DataFactory.Models.StoreWriteSettings
    {
        public AzureFileStorageWriteSettings() { }
    }
    public partial class AzureFunctionActivity : Azure.ResourceManager.DataFactory.Models.ExecutionActivity
    {
        public AzureFunctionActivity(string name, Azure.ResourceManager.DataFactory.Models.AzureFunctionActivityMethod method, System.BinaryData functionName) : base (default(string)) { }
        public System.BinaryData Body { get { throw null; } set { } }
        public System.BinaryData FunctionName { get { throw null; } set { } }
        public System.BinaryData Headers { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.AzureFunctionActivityMethod Method { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureFunctionActivityMethod : System.IEquatable<Azure.ResourceManager.DataFactory.Models.AzureFunctionActivityMethod>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureFunctionActivityMethod(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.AzureFunctionActivityMethod Delete { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.AzureFunctionActivityMethod GET { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.AzureFunctionActivityMethod Head { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.AzureFunctionActivityMethod Options { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.AzureFunctionActivityMethod Post { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.AzureFunctionActivityMethod PUT { get { throw null; } }
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
    public partial class AzureFunctionLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public AzureFunctionLinkedService(System.BinaryData functionAppUri) { }
        public System.BinaryData Authentication { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.CredentialReference Credential { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData FunctionAppUri { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase FunctionKey { get { throw null; } set { } }
        public System.BinaryData ResourceId { get { throw null; } set { } }
    }
    public partial class AzureKeyVaultLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public AzureKeyVaultLinkedService(System.BinaryData baseUri) { }
        public System.BinaryData BaseUri { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.CredentialReference Credential { get { throw null; } set { } }
    }
    public partial class AzureKeyVaultSecretReference : Azure.ResourceManager.DataFactory.Models.SecretBase
    {
        public AzureKeyVaultSecretReference(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference store, System.BinaryData secretName) { }
        public System.BinaryData SecretName { get { throw null; } set { } }
        public System.BinaryData SecretVersion { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.LinkedServiceReference Store { get { throw null; } set { } }
    }
    public partial class AzureMariaDBLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public AzureMariaDBLinkedService() { }
        public System.BinaryData ConnectionString { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.AzureKeyVaultSecretReference Pwd { get { throw null; } set { } }
    }
    public partial class AzureMariaDBSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public AzureMariaDBSource() { }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    public partial class AzureMariaDBTableDataset : Azure.ResourceManager.DataFactory.Models.Dataset
    {
        public AzureMariaDBTableDataset(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference)) { }
        public System.BinaryData TableName { get { throw null; } set { } }
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
        public System.BinaryData ContinueOnStepFailure { get { throw null; } set { } }
        public System.BinaryData DataPathAssignments { get { throw null; } set { } }
        public System.BinaryData ExperimentName { get { throw null; } set { } }
        public System.BinaryData MlParentRunId { get { throw null; } set { } }
        public System.BinaryData MlPipelineEndpointId { get { throw null; } set { } }
        public System.BinaryData MlPipelineId { get { throw null; } set { } }
        public System.BinaryData MlPipelineParameters { get { throw null; } set { } }
        public System.BinaryData Version { get { throw null; } set { } }
    }
    public partial class AzureMLLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public AzureMLLinkedService(System.BinaryData mlEndpoint, Azure.ResourceManager.DataFactory.Models.SecretBase apiKey) { }
        public Azure.ResourceManager.DataFactory.Models.SecretBase ApiKey { get { throw null; } set { } }
        public System.BinaryData Authentication { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData MlEndpoint { get { throw null; } set { } }
        public System.BinaryData ServicePrincipalId { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase ServicePrincipalKey { get { throw null; } set { } }
        public System.BinaryData Tenant { get { throw null; } set { } }
        public System.BinaryData UpdateResourceEndpoint { get { throw null; } set { } }
    }
    public partial class AzureMLServiceLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public AzureMLServiceLinkedService(System.BinaryData subscriptionId, System.BinaryData resourceGroupName, System.BinaryData mlWorkspaceName) { }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData MlWorkspaceName { get { throw null; } set { } }
        public System.BinaryData ResourceGroupName { get { throw null; } set { } }
        public System.BinaryData ServicePrincipalId { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase ServicePrincipalKey { get { throw null; } set { } }
        public System.BinaryData SubscriptionId { get { throw null; } set { } }
        public System.BinaryData Tenant { get { throw null; } set { } }
    }
    public partial class AzureMLUpdateResourceActivity : Azure.ResourceManager.DataFactory.Models.ExecutionActivity
    {
        public AzureMLUpdateResourceActivity(string name, System.BinaryData trainedModelName, Azure.ResourceManager.DataFactory.Models.LinkedServiceReference trainedModelLinkedServiceName, System.BinaryData trainedModelFilePath) : base (default(string)) { }
        public System.BinaryData TrainedModelFilePath { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.LinkedServiceReference TrainedModelLinkedServiceName { get { throw null; } set { } }
        public System.BinaryData TrainedModelName { get { throw null; } set { } }
    }
    public partial class AzureMLWebServiceFile
    {
        public AzureMLWebServiceFile(System.BinaryData filePath, Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName) { }
        public System.BinaryData FilePath { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.LinkedServiceReference LinkedServiceName { get { throw null; } set { } }
    }
    public partial class AzureMySqlLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public AzureMySqlLinkedService(System.BinaryData connectionString) { }
        public System.BinaryData ConnectionString { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.AzureKeyVaultSecretReference Password { get { throw null; } set { } }
    }
    public partial class AzureMySqlSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public AzureMySqlSink() { }
        public System.BinaryData PreCopyScript { get { throw null; } set { } }
    }
    public partial class AzureMySqlSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public AzureMySqlSource() { }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    public partial class AzureMySqlTableDataset : Azure.ResourceManager.DataFactory.Models.Dataset
    {
        public AzureMySqlTableDataset(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference)) { }
        public System.BinaryData Table { get { throw null; } set { } }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class AzurePostgreSqlLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public AzurePostgreSqlLinkedService() { }
        public System.BinaryData ConnectionString { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.AzureKeyVaultSecretReference Password { get { throw null; } set { } }
    }
    public partial class AzurePostgreSqlSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public AzurePostgreSqlSink() { }
        public System.BinaryData PreCopyScript { get { throw null; } set { } }
    }
    public partial class AzurePostgreSqlSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public AzurePostgreSqlSource() { }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    public partial class AzurePostgreSqlTableDataset : Azure.ResourceManager.DataFactory.Models.Dataset
    {
        public AzurePostgreSqlTableDataset(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference)) { }
        public System.BinaryData SchemaTypePropertiesSchema { get { throw null; } set { } }
        public System.BinaryData Table { get { throw null; } set { } }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class AzureQueueSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public AzureQueueSink() { }
    }
    public partial class AzureSearchIndexDataset : Azure.ResourceManager.DataFactory.Models.Dataset
    {
        public AzureSearchIndexDataset(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName, System.BinaryData indexName) : base (default(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference)) { }
        public System.BinaryData IndexName { get { throw null; } set { } }
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
    public partial class AzureSearchLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public AzureSearchLinkedService(System.BinaryData uri) { }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase Key { get { throw null; } set { } }
        public System.BinaryData Uri { get { throw null; } set { } }
    }
    public partial class AzureSqlDatabaseLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public AzureSqlDatabaseLinkedService(System.BinaryData connectionString) { }
        public Azure.ResourceManager.DataFactory.Models.SqlAlwaysEncryptedProperties AlwaysEncryptedSettings { get { throw null; } set { } }
        public System.BinaryData AzureCloudType { get { throw null; } set { } }
        public System.BinaryData ConnectionString { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.CredentialReference Credential { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.AzureKeyVaultSecretReference Password { get { throw null; } set { } }
        public System.BinaryData ServicePrincipalId { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase ServicePrincipalKey { get { throw null; } set { } }
        public System.BinaryData Tenant { get { throw null; } set { } }
    }
    public partial class AzureSqlDWLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public AzureSqlDWLinkedService(System.BinaryData connectionString) { }
        public System.BinaryData AzureCloudType { get { throw null; } set { } }
        public System.BinaryData ConnectionString { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.CredentialReference Credential { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.AzureKeyVaultSecretReference Password { get { throw null; } set { } }
        public System.BinaryData ServicePrincipalId { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase ServicePrincipalKey { get { throw null; } set { } }
        public System.BinaryData Tenant { get { throw null; } set { } }
    }
    public partial class AzureSqlDWTableDataset : Azure.ResourceManager.DataFactory.Models.Dataset
    {
        public AzureSqlDWTableDataset(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference)) { }
        public System.BinaryData SchemaTypePropertiesSchema { get { throw null; } set { } }
        public System.BinaryData Table { get { throw null; } set { } }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class AzureSqlMILinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public AzureSqlMILinkedService(System.BinaryData connectionString) { }
        public Azure.ResourceManager.DataFactory.Models.SqlAlwaysEncryptedProperties AlwaysEncryptedSettings { get { throw null; } set { } }
        public System.BinaryData AzureCloudType { get { throw null; } set { } }
        public System.BinaryData ConnectionString { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.CredentialReference Credential { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.AzureKeyVaultSecretReference Password { get { throw null; } set { } }
        public System.BinaryData ServicePrincipalId { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase ServicePrincipalKey { get { throw null; } set { } }
        public System.BinaryData Tenant { get { throw null; } set { } }
    }
    public partial class AzureSqlMITableDataset : Azure.ResourceManager.DataFactory.Models.Dataset
    {
        public AzureSqlMITableDataset(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference)) { }
        public System.BinaryData SchemaTypePropertiesSchema { get { throw null; } set { } }
        public System.BinaryData Table { get { throw null; } set { } }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class AzureSqlSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public AzureSqlSink() { }
        public System.BinaryData PreCopyScript { get { throw null; } set { } }
        public System.BinaryData SqlWriterStoredProcedureName { get { throw null; } set { } }
        public System.BinaryData SqlWriterTableType { get { throw null; } set { } }
        public System.BinaryData SqlWriterUseTableLock { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DataFactory.Models.StoredProcedureParameter> StoredProcedureParameters { get { throw null; } }
        public System.BinaryData StoredProcedureTableTypeParameterName { get { throw null; } set { } }
        public System.BinaryData TableOption { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SqlUpsertSettings UpsertSettings { get { throw null; } set { } }
        public System.BinaryData WriteBehavior { get { throw null; } set { } }
    }
    public partial class AzureSqlSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public AzureSqlSource() { }
        public System.BinaryData PartitionOption { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SqlPartitionSettings PartitionSettings { get { throw null; } set { } }
        public System.BinaryData ProduceAdditionalTypes { get { throw null; } set { } }
        public System.BinaryData SqlReaderQuery { get { throw null; } set { } }
        public System.BinaryData SqlReaderStoredProcedureName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DataFactory.Models.StoredProcedureParameter> StoredProcedureParameters { get { throw null; } }
    }
    public partial class AzureSqlTableDataset : Azure.ResourceManager.DataFactory.Models.Dataset
    {
        public AzureSqlTableDataset(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference)) { }
        public System.BinaryData SchemaTypePropertiesSchema { get { throw null; } set { } }
        public System.BinaryData Table { get { throw null; } set { } }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class AzureStorageLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public AzureStorageLinkedService() { }
        public Azure.ResourceManager.DataFactory.Models.AzureKeyVaultSecretReference AccountKey { get { throw null; } set { } }
        public System.BinaryData ConnectionString { get { throw null; } set { } }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.AzureKeyVaultSecretReference SasToken { get { throw null; } set { } }
        public System.BinaryData SasUri { get { throw null; } set { } }
    }
    public partial class AzureTableDataset : Azure.ResourceManager.DataFactory.Models.Dataset
    {
        public AzureTableDataset(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName, System.BinaryData tableName) : base (default(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference)) { }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class AzureTableSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public AzureTableSink() { }
        public System.BinaryData AzureTableDefaultPartitionKeyValue { get { throw null; } set { } }
        public System.BinaryData AzureTableInsertType { get { throw null; } set { } }
        public System.BinaryData AzureTablePartitionKeyName { get { throw null; } set { } }
        public System.BinaryData AzureTableRowKeyName { get { throw null; } set { } }
    }
    public partial class AzureTableSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public AzureTableSource() { }
        public System.BinaryData AzureTableSourceIgnoreTableNotFound { get { throw null; } set { } }
        public System.BinaryData AzureTableSourceQuery { get { throw null; } set { } }
    }
    public partial class AzureTableStorageLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public AzureTableStorageLinkedService() { }
        public Azure.ResourceManager.DataFactory.Models.AzureKeyVaultSecretReference AccountKey { get { throw null; } set { } }
        public System.BinaryData ConnectionString { get { throw null; } set { } }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.AzureKeyVaultSecretReference SasToken { get { throw null; } set { } }
        public System.BinaryData SasUri { get { throw null; } set { } }
    }
    public partial class BinaryDataset : Azure.ResourceManager.DataFactory.Models.Dataset
    {
        public BinaryDataset(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference)) { }
        public Azure.ResourceManager.DataFactory.Models.DatasetCompression Compression { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DatasetLocation Location { get { throw null; } set { } }
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
    public partial class BinarySource : Azure.ResourceManager.DataFactory.Models.CopySource
    {
        public BinarySource() { }
        public Azure.ResourceManager.DataFactory.Models.BinaryReadSettings FormatSettings { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.StoreReadSettings StoreSettings { get { throw null; } set { } }
    }
    public partial class BlobEventsTrigger : Azure.ResourceManager.DataFactory.Models.MultiplePipelineTrigger
    {
        public BlobEventsTrigger(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataFactory.Models.BlobEventType> events, string scope) { }
        public string BlobPathBeginsWith { get { throw null; } set { } }
        public string BlobPathEndsWith { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.BlobEventType> Events { get { throw null; } }
        public bool? IgnoreEmptyBlobs { get { throw null; } set { } }
        public string Scope { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BlobEventType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.BlobEventType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BlobEventType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.BlobEventType MicrosoftStorageBlobCreated { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.BlobEventType MicrosoftStorageBlobDeleted { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.BlobEventType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.BlobEventType left, Azure.ResourceManager.DataFactory.Models.BlobEventType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.BlobEventType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.BlobEventType left, Azure.ResourceManager.DataFactory.Models.BlobEventType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BlobSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public BlobSink() { }
        public System.BinaryData BlobWriterAddHeader { get { throw null; } set { } }
        public System.BinaryData BlobWriterDateTimeFormat { get { throw null; } set { } }
        public System.BinaryData BlobWriterOverwriteFiles { get { throw null; } set { } }
        public System.BinaryData CopyBehavior { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.MetadataItem> Metadata { get { throw null; } }
    }
    public partial class BlobSource : Azure.ResourceManager.DataFactory.Models.CopySource
    {
        public BlobSource() { }
        public System.BinaryData Recursive { get { throw null; } set { } }
        public System.BinaryData SkipHeaderLineCount { get { throw null; } set { } }
        public System.BinaryData TreatEmptyAsNull { get { throw null; } set { } }
    }
    public partial class BlobTrigger : Azure.ResourceManager.DataFactory.Models.MultiplePipelineTrigger
    {
        public BlobTrigger(string folderPath, int maxConcurrency, Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedService) { }
        public string FolderPath { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.LinkedServiceReference LinkedService { get { throw null; } set { } }
        public int MaxConcurrency { get { throw null; } set { } }
    }
    public partial class CassandraLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public CassandraLinkedService(System.BinaryData host) { }
        public System.BinaryData AuthenticationType { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData Host { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase Password { get { throw null; } set { } }
        public System.BinaryData Port { get { throw null; } set { } }
        public System.BinaryData Username { get { throw null; } set { } }
    }
    public partial class CassandraSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public CassandraSource() { }
        public Azure.ResourceManager.DataFactory.Models.CassandraSourceReadConsistencyLevel? ConsistencyLevel { get { throw null; } set { } }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CassandraSourceReadConsistencyLevel : System.IEquatable<Azure.ResourceManager.DataFactory.Models.CassandraSourceReadConsistencyLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CassandraSourceReadConsistencyLevel(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.CassandraSourceReadConsistencyLevel ALL { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.CassandraSourceReadConsistencyLevel EachQuorum { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.CassandraSourceReadConsistencyLevel LocalONE { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.CassandraSourceReadConsistencyLevel LocalQuorum { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.CassandraSourceReadConsistencyLevel LocalSerial { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.CassandraSourceReadConsistencyLevel ONE { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.CassandraSourceReadConsistencyLevel Quorum { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.CassandraSourceReadConsistencyLevel Serial { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.CassandraSourceReadConsistencyLevel Three { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.CassandraSourceReadConsistencyLevel TWO { get { throw null; } }
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
    public partial class CassandraTableDataset : Azure.ResourceManager.DataFactory.Models.Dataset
    {
        public CassandraTableDataset(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference)) { }
        public System.BinaryData Keyspace { get { throw null; } set { } }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class ChainingTrigger : Azure.ResourceManager.DataFactory.Models.DataFactoryTriggerProperties
    {
        public ChainingTrigger(Azure.ResourceManager.DataFactory.Models.TriggerPipelineReference pipeline, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataFactory.Models.PipelineReference> dependsOn, string runDimension) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.PipelineReference> DependsOn { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.TriggerPipelineReference Pipeline { get { throw null; } set { } }
        public string RunDimension { get { throw null; } set { } }
    }
    public partial class CmdkeySetup : Azure.ResourceManager.DataFactory.Models.CustomSetupBase
    {
        public CmdkeySetup(System.BinaryData targetName, System.BinaryData userName, Azure.ResourceManager.DataFactory.Models.SecretBase password) { }
        public Azure.ResourceManager.DataFactory.Models.SecretBase Password { get { throw null; } set { } }
        public System.BinaryData TargetName { get { throw null; } set { } }
        public System.BinaryData UserName { get { throw null; } set { } }
    }
    public partial class CommonDataServiceForAppsEntityDataset : Azure.ResourceManager.DataFactory.Models.Dataset
    {
        public CommonDataServiceForAppsEntityDataset(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference)) { }
        public System.BinaryData EntityName { get { throw null; } set { } }
    }
    public partial class CommonDataServiceForAppsLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public CommonDataServiceForAppsLinkedService(System.BinaryData deploymentType, System.BinaryData authenticationType) { }
        public System.BinaryData AuthenticationType { get { throw null; } set { } }
        public System.BinaryData DeploymentType { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData HostName { get { throw null; } set { } }
        public System.BinaryData OrganizationName { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase Password { get { throw null; } set { } }
        public System.BinaryData Port { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase ServicePrincipalCredential { get { throw null; } set { } }
        public System.BinaryData ServicePrincipalCredentialType { get { throw null; } set { } }
        public System.BinaryData ServicePrincipalId { get { throw null; } set { } }
        public System.BinaryData ServiceUri { get { throw null; } set { } }
        public System.BinaryData Username { get { throw null; } set { } }
    }
    public partial class CommonDataServiceForAppsSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public CommonDataServiceForAppsSink(Azure.ResourceManager.DataFactory.Models.DynamicsSinkWriteBehavior writeBehavior) { }
        public System.BinaryData AlternateKeyName { get { throw null; } set { } }
        public System.BinaryData IgnoreNullValues { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DynamicsSinkWriteBehavior WriteBehavior { get { throw null; } set { } }
    }
    public partial class CommonDataServiceForAppsSource : Azure.ResourceManager.DataFactory.Models.CopySource
    {
        public CommonDataServiceForAppsSource() { }
        public System.BinaryData AdditionalColumns { get { throw null; } set { } }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    public partial class ComponentSetup : Azure.ResourceManager.DataFactory.Models.CustomSetupBase
    {
        public ComponentSetup(string componentName) { }
        public string ComponentName { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase LicenseKey { get { throw null; } set { } }
    }
    public partial class CompressionReadSettings
    {
        public CompressionReadSettings() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
    }
    public partial class ConcurLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public ConcurLinkedService(System.BinaryData clientId, System.BinaryData username) { }
        public System.BinaryData ClientId { get { throw null; } set { } }
        public System.BinaryData ConnectionProperties { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase Password { get { throw null; } set { } }
        public System.BinaryData UseEncryptedEndpoints { get { throw null; } set { } }
        public System.BinaryData UseHostVerification { get { throw null; } set { } }
        public System.BinaryData UsePeerVerification { get { throw null; } set { } }
        public System.BinaryData Username { get { throw null; } set { } }
    }
    public partial class ConcurObjectDataset : Azure.ResourceManager.DataFactory.Models.Dataset
    {
        public ConcurObjectDataset(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference)) { }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class ConcurSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public ConcurSource() { }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    public partial class ConnectionStateProperties
    {
        public ConnectionStateProperties() { }
        public string ActionsRequired { get { throw null; } }
        public string Description { get { throw null; } }
        public string Status { get { throw null; } }
    }
    public partial class ControlActivity : Azure.ResourceManager.DataFactory.Models.DataFactoryPipelineActivity
    {
        public ControlActivity(string name) : base (default(string)) { }
    }
    public partial class CopyActivity : Azure.ResourceManager.DataFactory.Models.ExecutionActivity
    {
        public CopyActivity(string name, Azure.ResourceManager.DataFactory.Models.CopySource source, Azure.ResourceManager.DataFactory.Models.CopySink sink) : base (default(string)) { }
        public System.BinaryData DataIntegrationUnits { get { throw null; } set { } }
        public System.BinaryData EnableSkipIncompatibleRow { get { throw null; } set { } }
        public System.BinaryData EnableStaging { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.DatasetReference> Inputs { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.LogSettings LogSettings { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.LogStorageSettings LogStorageSettings { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.DatasetReference> Outputs { get { throw null; } }
        public System.BinaryData ParallelCopies { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.BinaryData> Preserve { get { throw null; } }
        public System.Collections.Generic.IList<System.BinaryData> PreserveRules { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.RedirectIncompatibleRowSettings RedirectIncompatibleRowSettings { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.CopySink Sink { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SkipErrorFile SkipErrorFile { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.CopySource Source { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.StagingSettings StagingSettings { get { throw null; } set { } }
        public System.BinaryData Translator { get { throw null; } set { } }
        public System.BinaryData ValidateDataConsistency { get { throw null; } set { } }
    }
    public partial class CopyActivityLogSettings
    {
        public CopyActivityLogSettings() { }
        public System.BinaryData EnableReliableLogging { get { throw null; } set { } }
        public System.BinaryData LogLevel { get { throw null; } set { } }
    }
    public partial class CopySink
    {
        public CopySink() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public System.BinaryData DisableMetricsCollection { get { throw null; } set { } }
        public System.BinaryData MaxConcurrentConnections { get { throw null; } set { } }
        public System.BinaryData SinkRetryCount { get { throw null; } set { } }
        public System.BinaryData SinkRetryWait { get { throw null; } set { } }
        public System.BinaryData WriteBatchSize { get { throw null; } set { } }
        public System.BinaryData WriteBatchTimeout { get { throw null; } set { } }
    }
    public partial class CopySource
    {
        public CopySource() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public System.BinaryData DisableMetricsCollection { get { throw null; } set { } }
        public System.BinaryData MaxConcurrentConnections { get { throw null; } set { } }
        public System.BinaryData SourceRetryCount { get { throw null; } set { } }
        public System.BinaryData SourceRetryWait { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CosmosDbConnectionMode : System.IEquatable<Azure.ResourceManager.DataFactory.Models.CosmosDbConnectionMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CosmosDbConnectionMode(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.CosmosDbConnectionMode Direct { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.CosmosDbConnectionMode Gateway { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.CosmosDbConnectionMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.CosmosDbConnectionMode left, Azure.ResourceManager.DataFactory.Models.CosmosDbConnectionMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.CosmosDbConnectionMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.CosmosDbConnectionMode left, Azure.ResourceManager.DataFactory.Models.CosmosDbConnectionMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CosmosDbLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public CosmosDbLinkedService() { }
        public System.BinaryData AccountEndpoint { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase AccountKey { get { throw null; } set { } }
        public System.BinaryData AzureCloudType { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.CosmosDbConnectionMode? ConnectionMode { get { throw null; } set { } }
        public System.BinaryData ConnectionString { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.CredentialReference Credential { get { throw null; } set { } }
        public System.BinaryData Database { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase ServicePrincipalCredential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.CosmosDbServicePrincipalCredentialType? ServicePrincipalCredentialType { get { throw null; } set { } }
        public System.BinaryData ServicePrincipalId { get { throw null; } set { } }
        public System.BinaryData Tenant { get { throw null; } set { } }
    }
    public partial class CosmosDbMongoDbApiCollectionDataset : Azure.ResourceManager.DataFactory.Models.Dataset
    {
        public CosmosDbMongoDbApiCollectionDataset(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName, System.BinaryData collection) : base (default(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference)) { }
        public System.BinaryData Collection { get { throw null; } set { } }
    }
    public partial class CosmosDbMongoDbApiLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public CosmosDbMongoDbApiLinkedService(System.BinaryData connectionString, System.BinaryData database) { }
        public System.BinaryData ConnectionString { get { throw null; } set { } }
        public System.BinaryData Database { get { throw null; } set { } }
        public System.BinaryData IsServerVersionAbove32 { get { throw null; } set { } }
    }
    public partial class CosmosDbMongoDbApiSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public CosmosDbMongoDbApiSink() { }
        public System.BinaryData WriteBehavior { get { throw null; } set { } }
    }
    public partial class CosmosDbMongoDbApiSource : Azure.ResourceManager.DataFactory.Models.CopySource
    {
        public CosmosDbMongoDbApiSource() { }
        public System.BinaryData AdditionalColumns { get { throw null; } set { } }
        public System.BinaryData BatchSize { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.MongoDbCursorMethodsProperties CursorMethods { get { throw null; } set { } }
        public System.BinaryData Filter { get { throw null; } set { } }
        public System.BinaryData QueryTimeout { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CosmosDbServicePrincipalCredentialType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.CosmosDbServicePrincipalCredentialType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CosmosDbServicePrincipalCredentialType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.CosmosDbServicePrincipalCredentialType ServicePrincipalCert { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.CosmosDbServicePrincipalCredentialType ServicePrincipalKey { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.CosmosDbServicePrincipalCredentialType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.CosmosDbServicePrincipalCredentialType left, Azure.ResourceManager.DataFactory.Models.CosmosDbServicePrincipalCredentialType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.CosmosDbServicePrincipalCredentialType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.CosmosDbServicePrincipalCredentialType left, Azure.ResourceManager.DataFactory.Models.CosmosDbServicePrincipalCredentialType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CosmosDbSqlApiCollectionDataset : Azure.ResourceManager.DataFactory.Models.Dataset
    {
        public CosmosDbSqlApiCollectionDataset(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName, System.BinaryData collectionName) : base (default(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference)) { }
        public System.BinaryData CollectionName { get { throw null; } set { } }
    }
    public partial class CosmosDbSqlApiSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public CosmosDbSqlApiSink() { }
        public System.BinaryData WriteBehavior { get { throw null; } set { } }
    }
    public partial class CosmosDbSqlApiSource : Azure.ResourceManager.DataFactory.Models.CopySource
    {
        public CosmosDbSqlApiSource() { }
        public System.BinaryData AdditionalColumns { get { throw null; } set { } }
        public System.BinaryData DetectDatetime { get { throw null; } set { } }
        public System.BinaryData PageSize { get { throw null; } set { } }
        public System.BinaryData PreferredRegions { get { throw null; } set { } }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    public partial class CouchbaseLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public CouchbaseLinkedService() { }
        public System.BinaryData ConnectionString { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.AzureKeyVaultSecretReference CredString { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
    }
    public partial class CouchbaseSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public CouchbaseSource() { }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    public partial class CouchbaseTableDataset : Azure.ResourceManager.DataFactory.Models.Dataset
    {
        public CouchbaseTableDataset(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference)) { }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class CreateDataFlowDebugSessionContent
    {
        public CreateDataFlowDebugSessionContent() { }
        public string ComputeType { get { throw null; } set { } }
        public int? CoreCount { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeDebugResource IntegrationRuntime { get { throw null; } set { } }
        public int? TimeToLive { get { throw null; } set { } }
    }
    public partial class CreateDataFlowDebugSessionResult
    {
        internal CreateDataFlowDebugSessionResult() { }
        public string SessionId { get { throw null; } }
        public string Status { get { throw null; } }
    }
    public partial class CreateLinkedIntegrationRuntimeContent
    {
        public CreateLinkedIntegrationRuntimeContent() { }
        public string DataFactoryLocation { get { throw null; } set { } }
        public string DataFactoryName { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
    }
    public partial class CreateRunResult
    {
        internal CreateRunResult() { }
        public string RunId { get { throw null; } }
    }
    public partial class CredentialReference
    {
        public CredentialReference(Azure.ResourceManager.DataFactory.Models.CredentialReferenceType referenceType, string referenceName) { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public string ReferenceName { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.CredentialReferenceType ReferenceType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CredentialReferenceType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.CredentialReferenceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CredentialReferenceType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.CredentialReferenceType CredentialReference { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.CredentialReferenceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.CredentialReferenceType left, Azure.ResourceManager.DataFactory.Models.CredentialReferenceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.CredentialReferenceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.CredentialReferenceType left, Azure.ResourceManager.DataFactory.Models.CredentialReferenceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CustomActivity : Azure.ResourceManager.DataFactory.Models.ExecutionActivity
    {
        public CustomActivity(string name, System.BinaryData command) : base (default(string)) { }
        public System.BinaryData AutoUserSpecification { get { throw null; } set { } }
        public System.BinaryData Command { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> ExtendedProperties { get { throw null; } }
        public System.BinaryData FolderPath { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.CustomActivityReferenceObject ReferenceObjects { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.LinkedServiceReference ResourceLinkedService { get { throw null; } set { } }
        public System.BinaryData RetentionTimeInDays { get { throw null; } set { } }
    }
    public partial class CustomActivityReferenceObject
    {
        public CustomActivityReferenceObject() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.DatasetReference> Datasets { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.LinkedServiceReference> LinkedServices { get { throw null; } }
    }
    public partial class CustomDataset : Azure.ResourceManager.DataFactory.Models.Dataset
    {
        public CustomDataset(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference)) { }
        public System.BinaryData TypeProperties { get { throw null; } set { } }
    }
    public partial class CustomDataSourceLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
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
    public partial class CustomSetupBase
    {
        public CustomSetupBase() { }
    }
    public partial class DatabricksNotebookActivity : Azure.ResourceManager.DataFactory.Models.ExecutionActivity
    {
        public DatabricksNotebookActivity(string name, System.BinaryData notebookPath) : base (default(string)) { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> BaseParameters { get { throw null; } }
        public System.Collections.Generic.IList<System.Collections.Generic.IDictionary<string, System.BinaryData>> Libraries { get { throw null; } }
        public System.BinaryData NotebookPath { get { throw null; } set { } }
    }
    public partial class DatabricksSparkJarActivity : Azure.ResourceManager.DataFactory.Models.ExecutionActivity
    {
        public DatabricksSparkJarActivity(string name, System.BinaryData mainClassName) : base (default(string)) { }
        public System.Collections.Generic.IList<System.Collections.Generic.IDictionary<string, System.BinaryData>> Libraries { get { throw null; } }
        public System.BinaryData MainClassName { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.BinaryData> Parameters { get { throw null; } }
    }
    public partial class DatabricksSparkPythonActivity : Azure.ResourceManager.DataFactory.Models.ExecutionActivity
    {
        public DatabricksSparkPythonActivity(string name, System.BinaryData pythonFile) : base (default(string)) { }
        public System.Collections.Generic.IList<System.Collections.Generic.IDictionary<string, System.BinaryData>> Libraries { get { throw null; } }
        public System.Collections.Generic.IList<System.BinaryData> Parameters { get { throw null; } }
        public System.BinaryData PythonFile { get { throw null; } set { } }
    }
    public partial class DataFactoryPatch
    {
        public DataFactoryPatch() { }
        public Azure.ResourceManager.DataFactory.Models.FactoryIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.PublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class DataFactoryPipelineActivity
    {
        public DataFactoryPipelineActivity(string name) { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.ActivityDependency> DependsOn { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.UserProperty> UserProperties { get { throw null; } }
    }
    public partial class DataFactoryPrivateEndpointConnectionCreateOrUpdateContent : Azure.ResourceManager.Models.ResourceData
    {
        public DataFactoryPrivateEndpointConnectionCreateOrUpdateContent() { }
        public Azure.ETag? Etag { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.PrivateLinkConnectionApprovalRequest Properties { get { throw null; } set { } }
    }
    public partial class DataFactoryPrivateLinkResource : Azure.ResourceManager.Models.ResourceData
    {
        public DataFactoryPrivateLinkResource() { }
        public Azure.ETag? Etag { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.DataFactoryPrivateLinkResourceProperties Properties { get { throw null; } set { } }
    }
    public partial class DataFactoryPrivateLinkResourceProperties
    {
        public DataFactoryPrivateLinkResourceProperties() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredZoneNames { get { throw null; } }
    }
    public partial class DataFactoryTriggerProperties
    {
        public DataFactoryTriggerProperties() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public System.Collections.Generic.IList<System.BinaryData> Annotations { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.TriggerRuntimeState? RuntimeState { get { throw null; } }
    }
    public partial class DataFlow
    {
        public DataFlow() { }
        public System.Collections.Generic.IList<System.BinaryData> Annotations { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string FolderName { get { throw null; } set { } }
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
        public string SessionId { get { throw null; } set { } }
    }
    public partial class DataFlowDebugCommandPayload
    {
        public DataFlowDebugCommandPayload(string streamName) { }
        public System.Collections.Generic.IList<string> Columns { get { throw null; } }
        public string Expression { get { throw null; } set { } }
        public int? RowLimits { get { throw null; } set { } }
        public string StreamName { get { throw null; } }
    }
    public partial class DataFlowDebugCommandResult
    {
        internal DataFlowDebugCommandResult() { }
        public string Data { get { throw null; } }
        public string Status { get { throw null; } }
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
    public partial class DataFlowDebugPackage
    {
        public DataFlowDebugPackage() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.DataFlowDebugResource DataFlow { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.DataFlowDebugResource> DataFlows { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.DatasetDebugResource> Datasets { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.DataFlowDebugPackageDebugSettings DebugSettings { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.LinkedServiceDebugResource> LinkedServices { get { throw null; } }
        public string SessionId { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DataFlowStagingInfo Staging { get { throw null; } set { } }
    }
    public partial class DataFlowDebugPackageDebugSettings
    {
        public DataFlowDebugPackageDebugSettings() { }
        public System.BinaryData DatasetParameters { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Parameters { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.DataFlowSourceSetting> SourceSettings { get { throw null; } }
    }
    public partial class DataFlowDebugResource : Azure.ResourceManager.DataFactory.Models.SubResourceDebugResource
    {
        public DataFlowDebugResource(Azure.ResourceManager.DataFactory.Models.DataFlow properties) { }
        public Azure.ResourceManager.DataFactory.Models.DataFlow Properties { get { throw null; } }
    }
    public partial class DataFlowDebugSessionInfo
    {
        internal DataFlowDebugSessionInfo() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public string ComputeType { get { throw null; } }
        public int? CoreCount { get { throw null; } }
        public string DataFlowName { get { throw null; } }
        public string IntegrationRuntimeName { get { throw null; } }
        public string LastActivityTime { get { throw null; } }
        public int? NodeCount { get { throw null; } }
        public string SessionId { get { throw null; } }
        public string StartTime { get { throw null; } }
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
    public partial class DataFlowSink : Azure.ResourceManager.DataFactory.Models.Transformation
    {
        public DataFlowSink(string name) : base (default(string)) { }
        public Azure.ResourceManager.DataFactory.Models.LinkedServiceReference RejectedDataLinkedService { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.LinkedServiceReference SchemaLinkedService { get { throw null; } set { } }
    }
    public partial class DataFlowSource : Azure.ResourceManager.DataFactory.Models.Transformation
    {
        public DataFlowSource(string name) : base (default(string)) { }
        public Azure.ResourceManager.DataFactory.Models.LinkedServiceReference SchemaLinkedService { get { throw null; } set { } }
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
        public System.BinaryData FolderPath { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.LinkedServiceReference LinkedService { get { throw null; } set { } }
    }
    public partial class DataLakeAnalyticsUsqlActivity : Azure.ResourceManager.DataFactory.Models.ExecutionActivity
    {
        public DataLakeAnalyticsUsqlActivity(string name, System.BinaryData scriptPath, Azure.ResourceManager.DataFactory.Models.LinkedServiceReference scriptLinkedService) : base (default(string)) { }
        public System.BinaryData CompilationMode { get { throw null; } set { } }
        public System.BinaryData DegreeOfParallelism { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Parameters { get { throw null; } }
        public System.BinaryData Priority { get { throw null; } set { } }
        public System.BinaryData RuntimeVersion { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.LinkedServiceReference ScriptLinkedService { get { throw null; } set { } }
        public System.BinaryData ScriptPath { get { throw null; } set { } }
    }
    public partial class Dataset
    {
        public Dataset(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName) { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public System.Collections.Generic.IList<System.BinaryData> Annotations { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string FolderName { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.LinkedServiceReference LinkedServiceName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DataFactory.Models.ParameterSpecification> Parameters { get { throw null; } }
        public System.BinaryData Schema { get { throw null; } set { } }
        public System.BinaryData Structure { get { throw null; } set { } }
    }
    public partial class DatasetCompression
    {
        public DatasetCompression(System.BinaryData datasetCompressionType) { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public System.BinaryData DatasetCompressionType { get { throw null; } set { } }
        public System.BinaryData Level { get { throw null; } set { } }
    }
    public partial class DatasetDebugResource : Azure.ResourceManager.DataFactory.Models.SubResourceDebugResource
    {
        public DatasetDebugResource(Azure.ResourceManager.DataFactory.Models.Dataset properties) { }
        public Azure.ResourceManager.DataFactory.Models.Dataset Properties { get { throw null; } }
    }
    public partial class DatasetLocation
    {
        public DatasetLocation() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public System.BinaryData FileName { get { throw null; } set { } }
        public System.BinaryData FolderPath { get { throw null; } set { } }
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
    public partial class DatasetStorageFormat
    {
        public DatasetStorageFormat() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public System.BinaryData Deserializer { get { throw null; } set { } }
        public System.BinaryData Serializer { get { throw null; } set { } }
    }
    public partial class DataworldLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public DataworldLinkedService(Azure.ResourceManager.DataFactory.Models.SecretBase apiToken) { }
        public Azure.ResourceManager.DataFactory.Models.SecretBase ApiToken { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
    }
    public enum DayOfWeek
    {
        Sunday = 0,
        Monday = 1,
        Tuesday = 2,
        Wednesday = 3,
        Thursday = 4,
        Friday = 5,
        Saturday = 6,
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
    public partial class Db2LinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public Db2LinkedService() { }
        public Azure.ResourceManager.DataFactory.Models.Db2AuthenticationType? AuthenticationType { get { throw null; } set { } }
        public System.BinaryData CertificateCommonName { get { throw null; } set { } }
        public System.BinaryData ConnectionString { get { throw null; } set { } }
        public System.BinaryData Database { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData PackageCollection { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase Password { get { throw null; } set { } }
        public System.BinaryData Server { get { throw null; } set { } }
        public System.BinaryData Username { get { throw null; } set { } }
    }
    public partial class Db2Source : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public Db2Source() { }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    public partial class Db2TableDataset : Azure.ResourceManager.DataFactory.Models.Dataset
    {
        public Db2TableDataset(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference)) { }
        public System.BinaryData SchemaTypePropertiesSchema { get { throw null; } set { } }
        public System.BinaryData Table { get { throw null; } set { } }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class DeleteActivity : Azure.ResourceManager.DataFactory.Models.ExecutionActivity
    {
        public DeleteActivity(string name, Azure.ResourceManager.DataFactory.Models.DatasetReference dataset) : base (default(string)) { }
        public Azure.ResourceManager.DataFactory.Models.DatasetReference Dataset { get { throw null; } set { } }
        public System.BinaryData EnableLogging { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.LogStorageSettings LogStorageSettings { get { throw null; } set { } }
        public int? MaxConcurrentConnections { get { throw null; } set { } }
        public System.BinaryData Recursive { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.StoreReadSettings StoreSettings { get { throw null; } set { } }
    }
    public partial class DeleteDataFlowDebugSessionContent
    {
        public DeleteDataFlowDebugSessionContent() { }
        public string SessionId { get { throw null; } set { } }
    }
    public partial class DelimitedTextDataset : Azure.ResourceManager.DataFactory.Models.Dataset
    {
        public DelimitedTextDataset(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference)) { }
        public System.BinaryData ColumnDelimiter { get { throw null; } set { } }
        public System.BinaryData CompressionCodec { get { throw null; } set { } }
        public System.BinaryData CompressionLevel { get { throw null; } set { } }
        public System.BinaryData EncodingName { get { throw null; } set { } }
        public System.BinaryData EscapeChar { get { throw null; } set { } }
        public System.BinaryData FirstRowAsHeader { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DatasetLocation Location { get { throw null; } set { } }
        public System.BinaryData NullValue { get { throw null; } set { } }
        public System.BinaryData QuoteChar { get { throw null; } set { } }
        public System.BinaryData RowDelimiter { get { throw null; } set { } }
    }
    public partial class DelimitedTextReadSettings : Azure.ResourceManager.DataFactory.Models.FormatReadSettings
    {
        public DelimitedTextReadSettings() { }
        public Azure.ResourceManager.DataFactory.Models.CompressionReadSettings CompressionProperties { get { throw null; } set { } }
        public System.BinaryData SkipLineCount { get { throw null; } set { } }
    }
    public partial class DelimitedTextSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public DelimitedTextSink() { }
        public Azure.ResourceManager.DataFactory.Models.DelimitedTextWriteSettings FormatSettings { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.StoreWriteSettings StoreSettings { get { throw null; } set { } }
    }
    public partial class DelimitedTextSource : Azure.ResourceManager.DataFactory.Models.CopySource
    {
        public DelimitedTextSource() { }
        public System.BinaryData AdditionalColumns { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DelimitedTextReadSettings FormatSettings { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.StoreReadSettings StoreSettings { get { throw null; } set { } }
    }
    public partial class DelimitedTextWriteSettings : Azure.ResourceManager.DataFactory.Models.FormatWriteSettings
    {
        public DelimitedTextWriteSettings(System.BinaryData fileExtension) { }
        public System.BinaryData FileExtension { get { throw null; } set { } }
        public System.BinaryData FileNamePrefix { get { throw null; } set { } }
        public System.BinaryData MaxRowsPerFile { get { throw null; } set { } }
        public System.BinaryData QuoteAllText { get { throw null; } set { } }
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
    public partial class DependencyReference
    {
        public DependencyReference() { }
    }
    public partial class DistcpSettings
    {
        public DistcpSettings(System.BinaryData resourceManagerEndpoint, System.BinaryData tempScriptPath) { }
        public System.BinaryData DistcpOptions { get { throw null; } set { } }
        public System.BinaryData ResourceManagerEndpoint { get { throw null; } set { } }
        public System.BinaryData TempScriptPath { get { throw null; } set { } }
    }
    public partial class DocumentDbCollectionDataset : Azure.ResourceManager.DataFactory.Models.Dataset
    {
        public DocumentDbCollectionDataset(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName, System.BinaryData collectionName) : base (default(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference)) { }
        public System.BinaryData CollectionName { get { throw null; } set { } }
    }
    public partial class DocumentDbCollectionSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public DocumentDbCollectionSink() { }
        public System.BinaryData NestingSeparator { get { throw null; } set { } }
        public System.BinaryData WriteBehavior { get { throw null; } set { } }
    }
    public partial class DocumentDbCollectionSource : Azure.ResourceManager.DataFactory.Models.CopySource
    {
        public DocumentDbCollectionSource() { }
        public System.BinaryData AdditionalColumns { get { throw null; } set { } }
        public System.BinaryData NestingSeparator { get { throw null; } set { } }
        public System.BinaryData Query { get { throw null; } set { } }
        public System.BinaryData QueryTimeout { get { throw null; } set { } }
    }
    public partial class DrillLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public DrillLinkedService() { }
        public System.BinaryData ConnectionString { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.AzureKeyVaultSecretReference Pwd { get { throw null; } set { } }
    }
    public partial class DrillSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public DrillSource() { }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    public partial class DrillTableDataset : Azure.ResourceManager.DataFactory.Models.Dataset
    {
        public DrillTableDataset(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference)) { }
        public System.BinaryData SchemaTypePropertiesSchema { get { throw null; } set { } }
        public System.BinaryData Table { get { throw null; } set { } }
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
    public partial class DynamicsAXLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public DynamicsAXLinkedService(System.BinaryData uri, System.BinaryData servicePrincipalId, Azure.ResourceManager.DataFactory.Models.SecretBase servicePrincipalKey, System.BinaryData tenant, System.BinaryData aadResourceId) { }
        public System.BinaryData AadResourceId { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData ServicePrincipalId { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase ServicePrincipalKey { get { throw null; } set { } }
        public System.BinaryData Tenant { get { throw null; } set { } }
        public System.BinaryData Uri { get { throw null; } set { } }
    }
    public partial class DynamicsAXResourceDataset : Azure.ResourceManager.DataFactory.Models.Dataset
    {
        public DynamicsAXResourceDataset(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName, System.BinaryData path) : base (default(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference)) { }
        public System.BinaryData Path { get { throw null; } set { } }
    }
    public partial class DynamicsAXSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public DynamicsAXSource() { }
        public System.BinaryData HttpRequestTimeout { get { throw null; } set { } }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    public partial class DynamicsCrmEntityDataset : Azure.ResourceManager.DataFactory.Models.Dataset
    {
        public DynamicsCrmEntityDataset(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference)) { }
        public System.BinaryData EntityName { get { throw null; } set { } }
    }
    public partial class DynamicsCrmLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public DynamicsCrmLinkedService(System.BinaryData deploymentType, System.BinaryData authenticationType) { }
        public System.BinaryData AuthenticationType { get { throw null; } set { } }
        public System.BinaryData DeploymentType { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData HostName { get { throw null; } set { } }
        public System.BinaryData OrganizationName { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase Password { get { throw null; } set { } }
        public System.BinaryData Port { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase ServicePrincipalCredential { get { throw null; } set { } }
        public System.BinaryData ServicePrincipalCredentialType { get { throw null; } set { } }
        public System.BinaryData ServicePrincipalId { get { throw null; } set { } }
        public System.BinaryData ServiceUri { get { throw null; } set { } }
        public System.BinaryData Username { get { throw null; } set { } }
    }
    public partial class DynamicsCrmSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public DynamicsCrmSink(Azure.ResourceManager.DataFactory.Models.DynamicsSinkWriteBehavior writeBehavior) { }
        public System.BinaryData AlternateKeyName { get { throw null; } set { } }
        public System.BinaryData IgnoreNullValues { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DynamicsSinkWriteBehavior WriteBehavior { get { throw null; } set { } }
    }
    public partial class DynamicsCrmSource : Azure.ResourceManager.DataFactory.Models.CopySource
    {
        public DynamicsCrmSource() { }
        public System.BinaryData AdditionalColumns { get { throw null; } set { } }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    public partial class DynamicsEntityDataset : Azure.ResourceManager.DataFactory.Models.Dataset
    {
        public DynamicsEntityDataset(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference)) { }
        public System.BinaryData EntityName { get { throw null; } set { } }
    }
    public partial class DynamicsLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public DynamicsLinkedService(System.BinaryData deploymentType, System.BinaryData authenticationType) { }
        public System.BinaryData AuthenticationType { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.CredentialReference Credential { get { throw null; } set { } }
        public System.BinaryData DeploymentType { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData HostName { get { throw null; } set { } }
        public System.BinaryData OrganizationName { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase Password { get { throw null; } set { } }
        public System.BinaryData Port { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase ServicePrincipalCredential { get { throw null; } set { } }
        public System.BinaryData ServicePrincipalCredentialType { get { throw null; } set { } }
        public System.BinaryData ServicePrincipalId { get { throw null; } set { } }
        public System.BinaryData ServiceUri { get { throw null; } set { } }
        public System.BinaryData Username { get { throw null; } set { } }
    }
    public partial class DynamicsSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public DynamicsSink(Azure.ResourceManager.DataFactory.Models.DynamicsSinkWriteBehavior writeBehavior) { }
        public System.BinaryData AlternateKeyName { get { throw null; } set { } }
        public System.BinaryData IgnoreNullValues { get { throw null; } set { } }
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
    public partial class DynamicsSource : Azure.ResourceManager.DataFactory.Models.CopySource
    {
        public DynamicsSource() { }
        public System.BinaryData AdditionalColumns { get { throw null; } set { } }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    public partial class EloquaLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public EloquaLinkedService(System.BinaryData endpoint, System.BinaryData username) { }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData Endpoint { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase Password { get { throw null; } set { } }
        public System.BinaryData UseEncryptedEndpoints { get { throw null; } set { } }
        public System.BinaryData UseHostVerification { get { throw null; } set { } }
        public System.BinaryData UsePeerVerification { get { throw null; } set { } }
        public System.BinaryData Username { get { throw null; } set { } }
    }
    public partial class EloquaObjectDataset : Azure.ResourceManager.DataFactory.Models.Dataset
    {
        public EloquaObjectDataset(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference)) { }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class EloquaSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public EloquaSource() { }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    public partial class EncryptionConfiguration
    {
        public EncryptionConfiguration(string keyName, System.Uri vaultBaseUri) { }
        public string KeyName { get { throw null; } set { } }
        public string KeyVersion { get { throw null; } set { } }
        public string UserAssignedIdentity { get { throw null; } set { } }
        public System.Uri VaultBaseUri { get { throw null; } set { } }
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
    public partial class ExcelDataset : Azure.ResourceManager.DataFactory.Models.Dataset
    {
        public ExcelDataset(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference)) { }
        public Azure.ResourceManager.DataFactory.Models.DatasetCompression Compression { get { throw null; } set { } }
        public System.BinaryData FirstRowAsHeader { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DatasetLocation Location { get { throw null; } set { } }
        public System.BinaryData NullValue { get { throw null; } set { } }
        public System.BinaryData Range { get { throw null; } set { } }
        public System.BinaryData SheetIndex { get { throw null; } set { } }
        public System.BinaryData SheetName { get { throw null; } set { } }
    }
    public partial class ExcelSource : Azure.ResourceManager.DataFactory.Models.CopySource
    {
        public ExcelSource() { }
        public System.BinaryData AdditionalColumns { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.StoreReadSettings StoreSettings { get { throw null; } set { } }
    }
    public partial class ExecuteDataFlowActivity : Azure.ResourceManager.DataFactory.Models.ExecutionActivity
    {
        public ExecuteDataFlowActivity(string name, Azure.ResourceManager.DataFactory.Models.DataFlowReference dataFlow) : base (default(string)) { }
        public Azure.ResourceManager.DataFactory.Models.ExecuteDataFlowActivityTypePropertiesCompute Compute { get { throw null; } set { } }
        public System.BinaryData ContinueOnError { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DataFlowReference DataFlow { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeReference IntegrationRuntime { get { throw null; } set { } }
        public System.BinaryData RunConcurrently { get { throw null; } set { } }
        public System.BinaryData SourceStagingConcurrency { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DataFlowStagingInfo Staging { get { throw null; } set { } }
        public System.BinaryData TraceLevel { get { throw null; } set { } }
    }
    public partial class ExecuteDataFlowActivityTypePropertiesCompute
    {
        public ExecuteDataFlowActivityTypePropertiesCompute() { }
        public System.BinaryData ComputeType { get { throw null; } set { } }
        public System.BinaryData CoreCount { get { throw null; } set { } }
    }
    public partial class ExecutePipelineActivity : Azure.ResourceManager.DataFactory.Models.ControlActivity
    {
        public ExecutePipelineActivity(string name, Azure.ResourceManager.DataFactory.Models.PipelineReference pipeline) : base (default(string)) { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Parameters { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.PipelineReference Pipeline { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.ExecutePipelineActivityPolicy Policy { get { throw null; } set { } }
        public bool? WaitOnCompletion { get { throw null; } set { } }
    }
    public partial class ExecutePipelineActivityPolicy
    {
        public ExecutePipelineActivityPolicy() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public bool? SecureInput { get { throw null; } set { } }
    }
    public partial class ExecuteSsisPackageActivity : Azure.ResourceManager.DataFactory.Models.ExecutionActivity
    {
        public ExecuteSsisPackageActivity(string name, Azure.ResourceManager.DataFactory.Models.SsisPackageLocation packageLocation, Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeReference connectVia) : base (default(string)) { }
        public Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeReference ConnectVia { get { throw null; } set { } }
        public System.BinaryData EnvironmentPath { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SsisExecutionCredential ExecutionCredential { get { throw null; } set { } }
        public System.BinaryData LoggingLevel { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SsisLogLocation LogLocation { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DataFactory.Models.SsisExecutionParameter>> PackageConnectionManagers { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.SsisPackageLocation PackageLocation { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DataFactory.Models.SsisExecutionParameter> PackageParameters { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DataFactory.Models.SsisExecutionParameter>> ProjectConnectionManagers { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DataFactory.Models.SsisExecutionParameter> ProjectParameters { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DataFactory.Models.SsisPropertyOverride> PropertyOverrides { get { throw null; } }
        public System.BinaryData Runtime { get { throw null; } set { } }
    }
    public partial class ExecuteWranglingDataflowActivity : Azure.ResourceManager.DataFactory.Models.DataFactoryPipelineActivity
    {
        public ExecuteWranglingDataflowActivity(string name, Azure.ResourceManager.DataFactory.Models.DataFlowReference dataFlow) : base (default(string)) { }
        public Azure.ResourceManager.DataFactory.Models.ExecuteDataFlowActivityTypePropertiesCompute Compute { get { throw null; } set { } }
        public System.BinaryData ContinueOnError { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DataFlowReference DataFlow { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeReference IntegrationRuntime { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.ActivityPolicy Policy { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.PowerQuerySinkMapping> Queries { get { throw null; } }
        public System.BinaryData RunConcurrently { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DataFactory.Models.PowerQuerySink> Sinks { get { throw null; } }
        public System.BinaryData SourceStagingConcurrency { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DataFlowStagingInfo Staging { get { throw null; } set { } }
        public System.BinaryData TraceLevel { get { throw null; } set { } }
    }
    public partial class ExecutionActivity : Azure.ResourceManager.DataFactory.Models.DataFactoryPipelineActivity
    {
        public ExecutionActivity(string name) : base (default(string)) { }
        public Azure.ResourceManager.DataFactory.Models.LinkedServiceReference LinkedServiceName { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.ActivityPolicy Policy { get { throw null; } set { } }
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
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataFactory.Models.ExposureControlResult> ExposureControlResponses { get { throw null; } }
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
    public partial class Expression
    {
        public Expression(Azure.ResourceManager.DataFactory.Models.ExpressionType expressionType, string value) { }
        public Azure.ResourceManager.DataFactory.Models.ExpressionType ExpressionType { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExpressionType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.ExpressionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExpressionType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.ExpressionType Expression { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.ExpressionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.ExpressionType left, Azure.ResourceManager.DataFactory.Models.ExpressionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.ExpressionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.ExpressionType left, Azure.ResourceManager.DataFactory.Models.ExpressionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FactoryGitHubConfiguration : Azure.ResourceManager.DataFactory.Models.FactoryRepoConfiguration
    {
        public FactoryGitHubConfiguration(string accountName, string repositoryName, string collaborationBranch, string rootFolder) : base (default(string), default(string), default(string), default(string)) { }
        public string ClientId { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.GitHubClientSecret ClientSecret { get { throw null; } set { } }
        public string HostName { get { throw null; } set { } }
    }
    public partial class FactoryIdentity
    {
        public FactoryIdentity(Azure.ResourceManager.DataFactory.Models.FactoryIdentityType identityType) { }
        public Azure.ResourceManager.DataFactory.Models.FactoryIdentityType IdentityType { get { throw null; } set { } }
        public System.Guid? PrincipalId { get { throw null; } }
        public System.Guid? TenantId { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> UserAssignedIdentities { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FactoryIdentityType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.FactoryIdentityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FactoryIdentityType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.FactoryIdentityType SystemAssigned { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.FactoryIdentityType SystemAssignedUserAssigned { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.FactoryIdentityType UserAssigned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.FactoryIdentityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.FactoryIdentityType left, Azure.ResourceManager.DataFactory.Models.FactoryIdentityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.FactoryIdentityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.FactoryIdentityType left, Azure.ResourceManager.DataFactory.Models.FactoryIdentityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FactoryRepoConfiguration
    {
        public FactoryRepoConfiguration(string accountName, string repositoryName, string collaborationBranch, string rootFolder) { }
        public string AccountName { get { throw null; } set { } }
        public string CollaborationBranch { get { throw null; } set { } }
        public string LastCommitId { get { throw null; } set { } }
        public string RepositoryName { get { throw null; } set { } }
        public string RootFolder { get { throw null; } set { } }
    }
    public partial class FactoryRepoUpdate
    {
        public FactoryRepoUpdate() { }
        public string FactoryResourceId { get { throw null; } set { } }
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
        public FailActivity(string name, System.BinaryData message, System.BinaryData errorCode) : base (default(string)) { }
        public System.BinaryData ErrorCode { get { throw null; } set { } }
        public System.BinaryData Message { get { throw null; } set { } }
    }
    public partial class FileServerLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public FileServerLinkedService(System.BinaryData host) { }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData Host { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase Password { get { throw null; } set { } }
        public System.BinaryData UserId { get { throw null; } set { } }
    }
    public partial class FileServerLocation : Azure.ResourceManager.DataFactory.Models.DatasetLocation
    {
        public FileServerLocation() { }
    }
    public partial class FileServerReadSettings : Azure.ResourceManager.DataFactory.Models.StoreReadSettings
    {
        public FileServerReadSettings() { }
        public System.BinaryData DeleteFilesAfterCompletion { get { throw null; } set { } }
        public bool? EnablePartitionDiscovery { get { throw null; } set { } }
        public System.BinaryData FileFilter { get { throw null; } set { } }
        public System.BinaryData FileListPath { get { throw null; } set { } }
        public System.BinaryData ModifiedDatetimeEnd { get { throw null; } set { } }
        public System.BinaryData ModifiedDatetimeStart { get { throw null; } set { } }
        public System.BinaryData PartitionRootPath { get { throw null; } set { } }
        public System.BinaryData Recursive { get { throw null; } set { } }
        public System.BinaryData WildcardFileName { get { throw null; } set { } }
        public System.BinaryData WildcardFolderPath { get { throw null; } set { } }
    }
    public partial class FileServerWriteSettings : Azure.ResourceManager.DataFactory.Models.StoreWriteSettings
    {
        public FileServerWriteSettings() { }
    }
    public partial class FileShareDataset : Azure.ResourceManager.DataFactory.Models.Dataset
    {
        public FileShareDataset(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference)) { }
        public Azure.ResourceManager.DataFactory.Models.DatasetCompression Compression { get { throw null; } set { } }
        public System.BinaryData FileFilter { get { throw null; } set { } }
        public System.BinaryData FileName { get { throw null; } set { } }
        public System.BinaryData FolderPath { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DatasetStorageFormat Format { get { throw null; } set { } }
        public System.BinaryData ModifiedDatetimeEnd { get { throw null; } set { } }
        public System.BinaryData ModifiedDatetimeStart { get { throw null; } set { } }
    }
    public partial class FileSystemSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public FileSystemSink() { }
        public System.BinaryData CopyBehavior { get { throw null; } set { } }
    }
    public partial class FileSystemSource : Azure.ResourceManager.DataFactory.Models.CopySource
    {
        public FileSystemSource() { }
        public System.BinaryData AdditionalColumns { get { throw null; } set { } }
        public System.BinaryData Recursive { get { throw null; } set { } }
    }
    public partial class FilterActivity : Azure.ResourceManager.DataFactory.Models.ControlActivity
    {
        public FilterActivity(string name, Azure.ResourceManager.DataFactory.Models.Expression items, Azure.ResourceManager.DataFactory.Models.Expression condition) : base (default(string)) { }
        public Azure.ResourceManager.DataFactory.Models.Expression Condition { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.Expression Items { get { throw null; } set { } }
    }
    public partial class Flowlet : Azure.ResourceManager.DataFactory.Models.DataFlow
    {
        public Flowlet() { }
        public string Script { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ScriptLines { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.DataFlowSink> Sinks { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.DataFlowSource> Sources { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.Transformation> Transformations { get { throw null; } }
    }
    public partial class ForEachActivity : Azure.ResourceManager.DataFactory.Models.ControlActivity
    {
        public ForEachActivity(string name, Azure.ResourceManager.DataFactory.Models.Expression items, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataFactory.Models.DataFactoryPipelineActivity> activities) : base (default(string)) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.DataFactoryPipelineActivity> Activities { get { throw null; } }
        public int? BatchCount { get { throw null; } set { } }
        public bool? IsSequential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.Expression Items { get { throw null; } set { } }
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
        public System.BinaryData DeleteFilesAfterCompletion { get { throw null; } set { } }
        public System.BinaryData DisableChunking { get { throw null; } set { } }
        public bool? EnablePartitionDiscovery { get { throw null; } set { } }
        public System.BinaryData FileListPath { get { throw null; } set { } }
        public System.BinaryData PartitionRootPath { get { throw null; } set { } }
        public System.BinaryData Recursive { get { throw null; } set { } }
        public bool? UseBinaryTransfer { get { throw null; } set { } }
        public System.BinaryData WildcardFileName { get { throw null; } set { } }
        public System.BinaryData WildcardFolderPath { get { throw null; } set { } }
    }
    public partial class FtpServerLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public FtpServerLinkedService(System.BinaryData host) { }
        public Azure.ResourceManager.DataFactory.Models.FtpAuthenticationType? AuthenticationType { get { throw null; } set { } }
        public System.BinaryData EnableServerCertificateValidation { get { throw null; } set { } }
        public System.BinaryData EnableSsl { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData Host { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase Password { get { throw null; } set { } }
        public System.BinaryData Port { get { throw null; } set { } }
        public System.BinaryData UserName { get { throw null; } set { } }
    }
    public partial class FtpServerLocation : Azure.ResourceManager.DataFactory.Models.DatasetLocation
    {
        public FtpServerLocation() { }
    }
    public partial class GetMetadataActivity : Azure.ResourceManager.DataFactory.Models.ExecutionActivity
    {
        public GetMetadataActivity(string name, Azure.ResourceManager.DataFactory.Models.DatasetReference dataset) : base (default(string)) { }
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
        public Azure.ResourceManager.DataFactory.Models.GitHubClientSecret GitHubClientSecret { get { throw null; } set { } }
    }
    public partial class GitHubAccessTokenResult
    {
        internal GitHubAccessTokenResult() { }
        public string GitHubAccessToken { get { throw null; } }
    }
    public partial class GitHubClientSecret
    {
        public GitHubClientSecret() { }
        public System.Uri ByoaSecretAkvUri { get { throw null; } set { } }
        public string ByoaSecretName { get { throw null; } set { } }
    }
    public partial class GlobalParameterSpecification
    {
        public GlobalParameterSpecification(Azure.ResourceManager.DataFactory.Models.GlobalParameterType parameterType, System.BinaryData value) { }
        public Azure.ResourceManager.DataFactory.Models.GlobalParameterType ParameterType { get { throw null; } set { } }
        public System.BinaryData Value { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GlobalParameterType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.GlobalParameterType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GlobalParameterType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.GlobalParameterType Array { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.GlobalParameterType Bool { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.GlobalParameterType Float { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.GlobalParameterType Int { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.GlobalParameterType Object { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.GlobalParameterType String { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.GlobalParameterType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.GlobalParameterType left, Azure.ResourceManager.DataFactory.Models.GlobalParameterType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.GlobalParameterType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.GlobalParameterType left, Azure.ResourceManager.DataFactory.Models.GlobalParameterType right) { throw null; }
        public override string ToString() { throw null; }
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
    public partial class GoogleAdWordsLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public GoogleAdWordsLinkedService() { }
        public Azure.ResourceManager.DataFactory.Models.GoogleAdWordsAuthenticationType? AuthenticationType { get { throw null; } set { } }
        public System.BinaryData ClientCustomerId { get { throw null; } set { } }
        public System.BinaryData ClientId { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase ClientSecret { get { throw null; } set { } }
        public System.BinaryData ConnectionProperties { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase DeveloperToken { get { throw null; } set { } }
        public System.BinaryData Email { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData KeyFilePath { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase RefreshToken { get { throw null; } set { } }
        public System.BinaryData TrustedCertPath { get { throw null; } set { } }
        public System.BinaryData UseSystemTrustStore { get { throw null; } set { } }
    }
    public partial class GoogleAdWordsObjectDataset : Azure.ResourceManager.DataFactory.Models.Dataset
    {
        public GoogleAdWordsObjectDataset(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference)) { }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class GoogleAdWordsSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public GoogleAdWordsSource() { }
        public System.BinaryData Query { get { throw null; } set { } }
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
    public partial class GoogleBigQueryLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public GoogleBigQueryLinkedService(System.BinaryData project, Azure.ResourceManager.DataFactory.Models.GoogleBigQueryAuthenticationType authenticationType) { }
        public System.BinaryData AdditionalProjects { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.GoogleBigQueryAuthenticationType AuthenticationType { get { throw null; } set { } }
        public System.BinaryData ClientId { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase ClientSecret { get { throw null; } set { } }
        public System.BinaryData Email { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData KeyFilePath { get { throw null; } set { } }
        public System.BinaryData Project { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase RefreshToken { get { throw null; } set { } }
        public System.BinaryData RequestGoogleDriveScope { get { throw null; } set { } }
        public System.BinaryData TrustedCertPath { get { throw null; } set { } }
        public System.BinaryData UseSystemTrustStore { get { throw null; } set { } }
    }
    public partial class GoogleBigQueryObjectDataset : Azure.ResourceManager.DataFactory.Models.Dataset
    {
        public GoogleBigQueryObjectDataset(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference)) { }
        public System.BinaryData Dataset { get { throw null; } set { } }
        public System.BinaryData Table { get { throw null; } set { } }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class GoogleBigQuerySource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public GoogleBigQuerySource() { }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    public partial class GoogleCloudStorageLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public GoogleCloudStorageLinkedService() { }
        public System.BinaryData AccessKeyId { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase SecretAccessKey { get { throw null; } set { } }
        public System.BinaryData ServiceUri { get { throw null; } set { } }
    }
    public partial class GoogleCloudStorageLocation : Azure.ResourceManager.DataFactory.Models.DatasetLocation
    {
        public GoogleCloudStorageLocation() { }
        public System.BinaryData BucketName { get { throw null; } set { } }
        public System.BinaryData Version { get { throw null; } set { } }
    }
    public partial class GoogleCloudStorageReadSettings : Azure.ResourceManager.DataFactory.Models.StoreReadSettings
    {
        public GoogleCloudStorageReadSettings() { }
        public System.BinaryData DeleteFilesAfterCompletion { get { throw null; } set { } }
        public bool? EnablePartitionDiscovery { get { throw null; } set { } }
        public System.BinaryData FileListPath { get { throw null; } set { } }
        public System.BinaryData ModifiedDatetimeEnd { get { throw null; } set { } }
        public System.BinaryData ModifiedDatetimeStart { get { throw null; } set { } }
        public System.BinaryData PartitionRootPath { get { throw null; } set { } }
        public System.BinaryData Prefix { get { throw null; } set { } }
        public System.BinaryData Recursive { get { throw null; } set { } }
        public System.BinaryData WildcardFileName { get { throw null; } set { } }
        public System.BinaryData WildcardFolderPath { get { throw null; } set { } }
    }
    public partial class GreenplumLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public GreenplumLinkedService() { }
        public System.BinaryData ConnectionString { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.AzureKeyVaultSecretReference Pwd { get { throw null; } set { } }
    }
    public partial class GreenplumSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public GreenplumSource() { }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    public partial class GreenplumTableDataset : Azure.ResourceManager.DataFactory.Models.Dataset
    {
        public GreenplumTableDataset(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference)) { }
        public System.BinaryData SchemaTypePropertiesSchema { get { throw null; } set { } }
        public System.BinaryData Table { get { throw null; } set { } }
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
    public partial class HBaseLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public HBaseLinkedService(System.BinaryData host, Azure.ResourceManager.DataFactory.Models.HBaseAuthenticationType authenticationType) { }
        public System.BinaryData AllowHostNameCNMismatch { get { throw null; } set { } }
        public System.BinaryData AllowSelfSignedServerCert { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.HBaseAuthenticationType AuthenticationType { get { throw null; } set { } }
        public System.BinaryData EnableSsl { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData Host { get { throw null; } set { } }
        public System.BinaryData HttpPath { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase Password { get { throw null; } set { } }
        public System.BinaryData Port { get { throw null; } set { } }
        public System.BinaryData TrustedCertPath { get { throw null; } set { } }
        public System.BinaryData Username { get { throw null; } set { } }
    }
    public partial class HBaseObjectDataset : Azure.ResourceManager.DataFactory.Models.Dataset
    {
        public HBaseObjectDataset(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference)) { }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class HBaseSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public HBaseSource() { }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    public partial class HdfsLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public HdfsLinkedService(System.BinaryData uri) { }
        public System.BinaryData AuthenticationType { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase Password { get { throw null; } set { } }
        public System.BinaryData Uri { get { throw null; } set { } }
        public System.BinaryData UserName { get { throw null; } set { } }
    }
    public partial class HdfsLocation : Azure.ResourceManager.DataFactory.Models.DatasetLocation
    {
        public HdfsLocation() { }
    }
    public partial class HdfsReadSettings : Azure.ResourceManager.DataFactory.Models.StoreReadSettings
    {
        public HdfsReadSettings() { }
        public System.BinaryData DeleteFilesAfterCompletion { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DistcpSettings DistcpSettings { get { throw null; } set { } }
        public bool? EnablePartitionDiscovery { get { throw null; } set { } }
        public System.BinaryData FileListPath { get { throw null; } set { } }
        public System.BinaryData ModifiedDatetimeEnd { get { throw null; } set { } }
        public System.BinaryData ModifiedDatetimeStart { get { throw null; } set { } }
        public System.BinaryData PartitionRootPath { get { throw null; } set { } }
        public System.BinaryData Recursive { get { throw null; } set { } }
        public System.BinaryData WildcardFileName { get { throw null; } set { } }
        public System.BinaryData WildcardFolderPath { get { throw null; } set { } }
    }
    public partial class HdfsSource : Azure.ResourceManager.DataFactory.Models.CopySource
    {
        public HdfsSource() { }
        public Azure.ResourceManager.DataFactory.Models.DistcpSettings DistcpSettings { get { throw null; } set { } }
        public System.BinaryData Recursive { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HDInsightActivityDebugInfoOption : System.IEquatable<Azure.ResourceManager.DataFactory.Models.HDInsightActivityDebugInfoOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HDInsightActivityDebugInfoOption(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.HDInsightActivityDebugInfoOption Always { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.HDInsightActivityDebugInfoOption Failure { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.HDInsightActivityDebugInfoOption None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.HDInsightActivityDebugInfoOption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.HDInsightActivityDebugInfoOption left, Azure.ResourceManager.DataFactory.Models.HDInsightActivityDebugInfoOption right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.HDInsightActivityDebugInfoOption (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.HDInsightActivityDebugInfoOption left, Azure.ResourceManager.DataFactory.Models.HDInsightActivityDebugInfoOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HDInsightHiveActivity : Azure.ResourceManager.DataFactory.Models.ExecutionActivity
    {
        public HDInsightHiveActivity(string name) : base (default(string)) { }
        public System.Collections.Generic.IList<System.BinaryData> Arguments { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Defines { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.HDInsightActivityDebugInfoOption? GetDebugInfo { get { throw null; } set { } }
        public int? QueryTimeout { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.LinkedServiceReference ScriptLinkedService { get { throw null; } set { } }
        public System.BinaryData ScriptPath { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.LinkedServiceReference> StorageLinkedServices { get { throw null; } }
        public System.Collections.Generic.IList<System.BinaryData> Variables { get { throw null; } }
    }
    public partial class HDInsightLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public HDInsightLinkedService(System.BinaryData clusterUri) { }
        public System.BinaryData ClusterUri { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData FileSystem { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.LinkedServiceReference HcatalogLinkedServiceName { get { throw null; } set { } }
        public System.BinaryData IsEspEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.LinkedServiceReference LinkedServiceName { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase Password { get { throw null; } set { } }
        public System.BinaryData UserName { get { throw null; } set { } }
    }
    public partial class HDInsightMapReduceActivity : Azure.ResourceManager.DataFactory.Models.ExecutionActivity
    {
        public HDInsightMapReduceActivity(string name, System.BinaryData className, System.BinaryData jarFilePath) : base (default(string)) { }
        public System.Collections.Generic.IList<System.BinaryData> Arguments { get { throw null; } }
        public System.BinaryData ClassName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Defines { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.HDInsightActivityDebugInfoOption? GetDebugInfo { get { throw null; } set { } }
        public System.BinaryData JarFilePath { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.BinaryData> JarLibs { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.LinkedServiceReference JarLinkedService { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.LinkedServiceReference> StorageLinkedServices { get { throw null; } }
    }
    public partial class HDInsightOnDemandLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public HDInsightOnDemandLinkedService(System.BinaryData clusterSize, System.BinaryData timeToLive, System.BinaryData version, Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName, System.BinaryData hostSubscriptionId, System.BinaryData tenant, System.BinaryData clusterResourceGroup) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.LinkedServiceReference> AdditionalLinkedServiceNames { get { throw null; } }
        public System.BinaryData ClusterNamePrefix { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase ClusterPassword { get { throw null; } set { } }
        public System.BinaryData ClusterResourceGroup { get { throw null; } set { } }
        public System.BinaryData ClusterSize { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase ClusterSshPassword { get { throw null; } set { } }
        public System.BinaryData ClusterSshUserName { get { throw null; } set { } }
        public System.BinaryData ClusterType { get { throw null; } set { } }
        public System.BinaryData ClusterUserName { get { throw null; } set { } }
        public System.BinaryData CoreConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.CredentialReference Credential { get { throw null; } set { } }
        public System.BinaryData DataNodeSize { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData HBaseConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.LinkedServiceReference HcatalogLinkedServiceName { get { throw null; } set { } }
        public System.BinaryData HdfsConfiguration { get { throw null; } set { } }
        public System.BinaryData HeadNodeSize { get { throw null; } set { } }
        public System.BinaryData HiveConfiguration { get { throw null; } set { } }
        public System.BinaryData HostSubscriptionId { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.LinkedServiceReference LinkedServiceName { get { throw null; } set { } }
        public System.BinaryData MapReduceConfiguration { get { throw null; } set { } }
        public System.BinaryData OozieConfiguration { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.ScriptAction> ScriptActions { get { throw null; } }
        public System.BinaryData ServicePrincipalId { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase ServicePrincipalKey { get { throw null; } set { } }
        public System.BinaryData SparkVersion { get { throw null; } set { } }
        public System.BinaryData StormConfiguration { get { throw null; } set { } }
        public System.BinaryData SubnetName { get { throw null; } set { } }
        public System.BinaryData Tenant { get { throw null; } set { } }
        public System.BinaryData TimeToLive { get { throw null; } set { } }
        public System.BinaryData Version { get { throw null; } set { } }
        public System.BinaryData VirtualNetworkId { get { throw null; } set { } }
        public System.BinaryData YarnConfiguration { get { throw null; } set { } }
        public System.BinaryData ZookeeperNodeSize { get { throw null; } set { } }
    }
    public partial class HDInsightPigActivity : Azure.ResourceManager.DataFactory.Models.ExecutionActivity
    {
        public HDInsightPigActivity(string name) : base (default(string)) { }
        public System.BinaryData Arguments { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Defines { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.HDInsightActivityDebugInfoOption? GetDebugInfo { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.LinkedServiceReference ScriptLinkedService { get { throw null; } set { } }
        public System.BinaryData ScriptPath { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.LinkedServiceReference> StorageLinkedServices { get { throw null; } }
    }
    public partial class HDInsightSparkActivity : Azure.ResourceManager.DataFactory.Models.ExecutionActivity
    {
        public HDInsightSparkActivity(string name, System.BinaryData rootPath, System.BinaryData entryFilePath) : base (default(string)) { }
        public System.Collections.Generic.IList<System.BinaryData> Arguments { get { throw null; } }
        public string ClassName { get { throw null; } set { } }
        public System.BinaryData EntryFilePath { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.HDInsightActivityDebugInfoOption? GetDebugInfo { get { throw null; } set { } }
        public System.BinaryData ProxyUser { get { throw null; } set { } }
        public System.BinaryData RootPath { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> SparkConfig { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.LinkedServiceReference SparkJobLinkedService { get { throw null; } set { } }
    }
    public partial class HDInsightStreamingActivity : Azure.ResourceManager.DataFactory.Models.ExecutionActivity
    {
        public HDInsightStreamingActivity(string name, System.BinaryData mapper, System.BinaryData reducer, System.BinaryData input, System.BinaryData output, System.Collections.Generic.IEnumerable<System.BinaryData> filePaths) : base (default(string)) { }
        public System.Collections.Generic.IList<System.BinaryData> Arguments { get { throw null; } }
        public System.BinaryData Combiner { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.BinaryData> CommandEnvironment { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Defines { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.LinkedServiceReference FileLinkedService { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.BinaryData> FilePaths { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.HDInsightActivityDebugInfoOption? GetDebugInfo { get { throw null; } set { } }
        public System.BinaryData Input { get { throw null; } set { } }
        public System.BinaryData Mapper { get { throw null; } set { } }
        public System.BinaryData Output { get { throw null; } set { } }
        public System.BinaryData Reducer { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.LinkedServiceReference> StorageLinkedServices { get { throw null; } }
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
    public partial class HiveLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public HiveLinkedService(System.BinaryData host, Azure.ResourceManager.DataFactory.Models.HiveAuthenticationType authenticationType) { }
        public System.BinaryData AllowHostNameCNMismatch { get { throw null; } set { } }
        public System.BinaryData AllowSelfSignedServerCert { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.HiveAuthenticationType AuthenticationType { get { throw null; } set { } }
        public System.BinaryData EnableSsl { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData Host { get { throw null; } set { } }
        public System.BinaryData HttpPath { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase Password { get { throw null; } set { } }
        public System.BinaryData Port { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.HiveServerType? ServerType { get { throw null; } set { } }
        public System.BinaryData ServiceDiscoveryMode { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.HiveThriftTransportProtocol? ThriftTransportProtocol { get { throw null; } set { } }
        public System.BinaryData TrustedCertPath { get { throw null; } set { } }
        public System.BinaryData UseNativeQuery { get { throw null; } set { } }
        public System.BinaryData Username { get { throw null; } set { } }
        public System.BinaryData UseSystemTrustStore { get { throw null; } set { } }
        public System.BinaryData ZooKeeperNameSpace { get { throw null; } set { } }
    }
    public partial class HiveObjectDataset : Azure.ResourceManager.DataFactory.Models.Dataset
    {
        public HiveObjectDataset(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference)) { }
        public System.BinaryData SchemaTypePropertiesSchema { get { throw null; } set { } }
        public System.BinaryData Table { get { throw null; } set { } }
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
        public System.BinaryData Query { get { throw null; } set { } }
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
    public partial class HttpDataset : Azure.ResourceManager.DataFactory.Models.Dataset
    {
        public HttpDataset(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference)) { }
        public System.BinaryData AdditionalHeaders { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DatasetCompression Compression { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DatasetStorageFormat Format { get { throw null; } set { } }
        public System.BinaryData RelativeUri { get { throw null; } set { } }
        public System.BinaryData RequestBody { get { throw null; } set { } }
        public System.BinaryData RequestMethod { get { throw null; } set { } }
    }
    public partial class HttpLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public HttpLinkedService(System.BinaryData uri) { }
        public Azure.ResourceManager.DataFactory.Models.HttpAuthenticationType? AuthenticationType { get { throw null; } set { } }
        public System.BinaryData AuthHeaders { get { throw null; } set { } }
        public System.BinaryData CertThumbprint { get { throw null; } set { } }
        public System.BinaryData EmbeddedCertData { get { throw null; } set { } }
        public System.BinaryData EnableServerCertificateValidation { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase Password { get { throw null; } set { } }
        public System.BinaryData Uri { get { throw null; } set { } }
        public System.BinaryData UserName { get { throw null; } set { } }
    }
    public partial class HttpReadSettings : Azure.ResourceManager.DataFactory.Models.StoreReadSettings
    {
        public HttpReadSettings() { }
        public System.BinaryData AdditionalHeaders { get { throw null; } set { } }
        public bool? EnablePartitionDiscovery { get { throw null; } set { } }
        public System.BinaryData PartitionRootPath { get { throw null; } set { } }
        public System.BinaryData RequestBody { get { throw null; } set { } }
        public System.BinaryData RequestMethod { get { throw null; } set { } }
        public System.BinaryData RequestTimeout { get { throw null; } set { } }
    }
    public partial class HttpServerLocation : Azure.ResourceManager.DataFactory.Models.DatasetLocation
    {
        public HttpServerLocation() { }
        public System.BinaryData RelativeUri { get { throw null; } set { } }
    }
    public partial class HttpSource : Azure.ResourceManager.DataFactory.Models.CopySource
    {
        public HttpSource() { }
        public System.BinaryData HttpRequestTimeout { get { throw null; } set { } }
    }
    public partial class HubspotLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public HubspotLinkedService(System.BinaryData clientId) { }
        public Azure.ResourceManager.DataFactory.Models.SecretBase AccessToken { get { throw null; } set { } }
        public System.BinaryData ClientId { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase ClientSecret { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase RefreshToken { get { throw null; } set { } }
        public System.BinaryData UseEncryptedEndpoints { get { throw null; } set { } }
        public System.BinaryData UseHostVerification { get { throw null; } set { } }
        public System.BinaryData UsePeerVerification { get { throw null; } set { } }
    }
    public partial class HubspotObjectDataset : Azure.ResourceManager.DataFactory.Models.Dataset
    {
        public HubspotObjectDataset(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference)) { }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class HubspotSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public HubspotSource() { }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    public partial class IfConditionActivity : Azure.ResourceManager.DataFactory.Models.ControlActivity
    {
        public IfConditionActivity(string name, Azure.ResourceManager.DataFactory.Models.Expression expression) : base (default(string)) { }
        public Azure.ResourceManager.DataFactory.Models.Expression Expression { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.DataFactoryPipelineActivity> IfFalseActivities { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.DataFactoryPipelineActivity> IfTrueActivities { get { throw null; } }
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
    public partial class ImpalaLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public ImpalaLinkedService(System.BinaryData host, Azure.ResourceManager.DataFactory.Models.ImpalaAuthenticationType authenticationType) { }
        public System.BinaryData AllowHostNameCNMismatch { get { throw null; } set { } }
        public System.BinaryData AllowSelfSignedServerCert { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.ImpalaAuthenticationType AuthenticationType { get { throw null; } set { } }
        public System.BinaryData EnableSsl { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData Host { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase Password { get { throw null; } set { } }
        public System.BinaryData Port { get { throw null; } set { } }
        public System.BinaryData TrustedCertPath { get { throw null; } set { } }
        public System.BinaryData Username { get { throw null; } set { } }
        public System.BinaryData UseSystemTrustStore { get { throw null; } set { } }
    }
    public partial class ImpalaObjectDataset : Azure.ResourceManager.DataFactory.Models.Dataset
    {
        public ImpalaObjectDataset(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference)) { }
        public System.BinaryData SchemaTypePropertiesSchema { get { throw null; } set { } }
        public System.BinaryData Table { get { throw null; } set { } }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class ImpalaSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public ImpalaSource() { }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    public partial class ImportSettings
    {
        public ImportSettings() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
    }
    public partial class InformixLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public InformixLinkedService(System.BinaryData connectionString) { }
        public System.BinaryData AuthenticationType { get { throw null; } set { } }
        public System.BinaryData ConnectionString { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase Credential { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase Password { get { throw null; } set { } }
        public System.BinaryData UserName { get { throw null; } set { } }
    }
    public partial class InformixSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public InformixSink() { }
        public System.BinaryData PreCopyScript { get { throw null; } set { } }
    }
    public partial class InformixSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public InformixSource() { }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    public partial class InformixTableDataset : Azure.ResourceManager.DataFactory.Models.Dataset
    {
        public InformixTableDataset(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference)) { }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class IntegrationRuntime
    {
        public IntegrationRuntime() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public string Description { get { throw null; } set { } }
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
    public readonly partial struct IntegrationRuntimeAutoUpdate : System.IEquatable<Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeAutoUpdate>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IntegrationRuntimeAutoUpdate(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeAutoUpdate Off { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeAutoUpdate On { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeAutoUpdate other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeAutoUpdate left, Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeAutoUpdate right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeAutoUpdate (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeAutoUpdate left, Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeAutoUpdate right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IntegrationRuntimeComputeProperties
    {
        public IntegrationRuntimeComputeProperties() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeDataFlowProperties DataFlowProperties { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public int? MaxParallelExecutionsPerNode { get { throw null; } set { } }
        public string NodeSize { get { throw null; } set { } }
        public int? NumberOfNodes { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeVNetProperties VNetProperties { get { throw null; } set { } }
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
        public Azure.ResourceManager.DataFactory.Models.SecureString SasToken { get { throw null; } set { } }
    }
    public partial class IntegrationRuntimeDataFlowProperties
    {
        public IntegrationRuntimeDataFlowProperties() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public bool? Cleanup { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DataFlowComputeType? ComputeType { get { throw null; } set { } }
        public int? CoreCount { get { throw null; } set { } }
        public int? TimeToLive { get { throw null; } set { } }
    }
    public partial class IntegrationRuntimeDataProxyProperties
    {
        public IntegrationRuntimeDataProxyProperties() { }
        public Azure.ResourceManager.DataFactory.Models.EntityReference ConnectVia { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.EntityReference StagingLinkedService { get { throw null; } set { } }
    }
    public partial class IntegrationRuntimeDebugResource : Azure.ResourceManager.DataFactory.Models.SubResourceDebugResource
    {
        public IntegrationRuntimeDebugResource(Azure.ResourceManager.DataFactory.Models.IntegrationRuntime properties) { }
        public Azure.ResourceManager.DataFactory.Models.IntegrationRuntime Properties { get { throw null; } }
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
        public string IPAddress { get { throw null; } }
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
    public partial class IntegrationRuntimeResourcePatch
    {
        public IntegrationRuntimeResourcePatch() { }
        public Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeAutoUpdate? AutoUpdate { get { throw null; } set { } }
        public string UpdateDelayOffset { get { throw null; } set { } }
    }
    public partial class IntegrationRuntimeSsisCatalogInfo
    {
        public IntegrationRuntimeSsisCatalogInfo() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.SecureString CatalogAdminPassword { get { throw null; } set { } }
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
        public Azure.ResourceManager.DataFactory.Models.CredentialReference Credential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeCustomSetupScriptProperties CustomSetupScriptProperties { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeDataProxyProperties DataProxyProperties { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeEdition? Edition { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.CustomSetupBase> ExpressCustomSetupProperties { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeLicenseType? LicenseType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.PackageStore> PackageStores { get { throw null; } }
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
    public partial class IntegrationRuntimeStatusResult
    {
        internal IntegrationRuntimeStatusResult() { }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeStatus Properties { get { throw null; } }
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
    public partial class IntegrationRuntimeVNetProperties
    {
        public IntegrationRuntimeVNetProperties() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public System.Collections.Generic.IList<string> PublicIPs { get { throw null; } }
        public string Subnet { get { throw null; } set { } }
        public string SubnetId { get { throw null; } set { } }
        public string VNetId { get { throw null; } set { } }
    }
    public partial class JiraLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public JiraLinkedService(System.BinaryData host, System.BinaryData username) { }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData Host { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase Password { get { throw null; } set { } }
        public System.BinaryData Port { get { throw null; } set { } }
        public System.BinaryData UseEncryptedEndpoints { get { throw null; } set { } }
        public System.BinaryData UseHostVerification { get { throw null; } set { } }
        public System.BinaryData UsePeerVerification { get { throw null; } set { } }
        public System.BinaryData Username { get { throw null; } set { } }
    }
    public partial class JiraObjectDataset : Azure.ResourceManager.DataFactory.Models.Dataset
    {
        public JiraObjectDataset(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference)) { }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class JiraSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public JiraSource() { }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    public partial class JsonDataset : Azure.ResourceManager.DataFactory.Models.Dataset
    {
        public JsonDataset(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference)) { }
        public Azure.ResourceManager.DataFactory.Models.DatasetCompression Compression { get { throw null; } set { } }
        public System.BinaryData EncodingName { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DatasetLocation Location { get { throw null; } set { } }
    }
    public partial class JsonFormat : Azure.ResourceManager.DataFactory.Models.DatasetStorageFormat
    {
        public JsonFormat() { }
        public System.BinaryData EncodingName { get { throw null; } set { } }
        public System.BinaryData FilePattern { get { throw null; } set { } }
        public System.BinaryData JsonNodeReference { get { throw null; } set { } }
        public System.BinaryData JsonPathDefinition { get { throw null; } set { } }
        public System.BinaryData NestingSeparator { get { throw null; } set { } }
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
    public partial class JsonSource : Azure.ResourceManager.DataFactory.Models.CopySource
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
        public System.DateTimeOffset? CreateOn { get { throw null; } }
        public string DataFactoryLocation { get { throw null; } }
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
        public LinkedIntegrationRuntimeKeyAuthorization(Azure.ResourceManager.DataFactory.Models.SecureString key) { }
        public Azure.ResourceManager.DataFactory.Models.SecureString Key { get { throw null; } set { } }
    }
    public partial class LinkedIntegrationRuntimeRbacAuthorization : Azure.ResourceManager.DataFactory.Models.LinkedIntegrationRuntimeType
    {
        public LinkedIntegrationRuntimeRbacAuthorization(string resourceId) { }
        public Azure.ResourceManager.DataFactory.Models.CredentialReference Credential { get { throw null; } set { } }
        public string ResourceId { get { throw null; } set { } }
    }
    public partial class LinkedIntegrationRuntimeType
    {
        public LinkedIntegrationRuntimeType() { }
    }
    public partial class LinkedService
    {
        public LinkedService() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public System.Collections.Generic.IList<System.BinaryData> Annotations { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeReference ConnectVia { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DataFactory.Models.ParameterSpecification> Parameters { get { throw null; } }
    }
    public partial class LinkedServiceDebugResource : Azure.ResourceManager.DataFactory.Models.SubResourceDebugResource
    {
        public LinkedServiceDebugResource(Azure.ResourceManager.DataFactory.Models.LinkedService properties) { }
        public Azure.ResourceManager.DataFactory.Models.LinkedService Properties { get { throw null; } }
    }
    public partial class LinkedServiceReference
    {
        public LinkedServiceReference(Azure.ResourceManager.DataFactory.Models.LinkedServiceReferenceType referenceType, string referenceName) { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Parameters { get { throw null; } }
        public string ReferenceName { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.LinkedServiceReferenceType ReferenceType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LinkedServiceReferenceType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.LinkedServiceReferenceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LinkedServiceReferenceType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.LinkedServiceReferenceType LinkedServiceReference { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.LinkedServiceReferenceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.LinkedServiceReferenceType left, Azure.ResourceManager.DataFactory.Models.LinkedServiceReferenceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.LinkedServiceReferenceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.LinkedServiceReferenceType left, Azure.ResourceManager.DataFactory.Models.LinkedServiceReferenceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LogLocationSettings
    {
        public LogLocationSettings(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName) { }
        public Azure.ResourceManager.DataFactory.Models.LinkedServiceReference LinkedServiceName { get { throw null; } set { } }
        public System.BinaryData Path { get { throw null; } set { } }
    }
    public partial class LogSettings
    {
        public LogSettings(Azure.ResourceManager.DataFactory.Models.LogLocationSettings logLocationSettings) { }
        public Azure.ResourceManager.DataFactory.Models.CopyActivityLogSettings CopyActivityLogSettings { get { throw null; } set { } }
        public System.BinaryData EnableCopyActivityLog { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.LogLocationSettings LogLocationSettings { get { throw null; } set { } }
    }
    public partial class LogStorageSettings
    {
        public LogStorageSettings(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName) { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public System.BinaryData EnableReliableLogging { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.LinkedServiceReference LinkedServiceName { get { throw null; } set { } }
        public System.BinaryData LogLevel { get { throw null; } set { } }
        public System.BinaryData Path { get { throw null; } set { } }
    }
    public partial class LookupActivity : Azure.ResourceManager.DataFactory.Models.ExecutionActivity
    {
        public LookupActivity(string name, Azure.ResourceManager.DataFactory.Models.CopySource source, Azure.ResourceManager.DataFactory.Models.DatasetReference dataset) : base (default(string)) { }
        public Azure.ResourceManager.DataFactory.Models.DatasetReference Dataset { get { throw null; } set { } }
        public System.BinaryData FirstRowOnly { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.CopySource Source { get { throw null; } set { } }
    }
    public partial class MagentoLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public MagentoLinkedService(System.BinaryData host) { }
        public Azure.ResourceManager.DataFactory.Models.SecretBase AccessToken { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData Host { get { throw null; } set { } }
        public System.BinaryData UseEncryptedEndpoints { get { throw null; } set { } }
        public System.BinaryData UseHostVerification { get { throw null; } set { } }
        public System.BinaryData UsePeerVerification { get { throw null; } set { } }
    }
    public partial class MagentoObjectDataset : Azure.ResourceManager.DataFactory.Models.Dataset
    {
        public MagentoObjectDataset(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference)) { }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class MagentoSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public MagentoSource() { }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    public partial class ManagedIntegrationRuntime : Azure.ResourceManager.DataFactory.Models.IntegrationRuntime
    {
        public ManagedIntegrationRuntime() { }
        public Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeComputeProperties ComputeProperties { get { throw null; } set { } }
        public string CustomerVirtualNetworkSubnetId { get { throw null; } set { } }
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
        public System.DateTimeOffset? CreateOn { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.ManagedIntegrationRuntimeOperationResult LastOperation { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataFactory.Models.ManagedIntegrationRuntimeNode> Nodes { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataFactory.Models.ManagedIntegrationRuntimeError> OtherErrors { get { throw null; } }
    }
    public partial class ManagedPrivateEndpoint
    {
        public ManagedPrivateEndpoint() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.ConnectionStateProperties ConnectionState { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Fqdns { get { throw null; } }
        public string GroupId { get { throw null; } set { } }
        public bool? IsReserved { get { throw null; } }
        public string PrivateLinkResourceId { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
    }
    public partial class ManagedVirtualNetwork
    {
        public ManagedVirtualNetwork() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public string Alias { get { throw null; } }
        public string VNetId { get { throw null; } }
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
    public partial class MappingDataFlow : Azure.ResourceManager.DataFactory.Models.DataFlow
    {
        public MappingDataFlow() { }
        public string Script { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ScriptLines { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.DataFlowSink> Sinks { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.DataFlowSource> Sources { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.Transformation> Transformations { get { throw null; } }
    }
    public partial class MariaDBLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public MariaDBLinkedService() { }
        public System.BinaryData ConnectionString { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.AzureKeyVaultSecretReference Pwd { get { throw null; } set { } }
    }
    public partial class MariaDBSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public MariaDBSource() { }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    public partial class MariaDBTableDataset : Azure.ResourceManager.DataFactory.Models.Dataset
    {
        public MariaDBTableDataset(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference)) { }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class MarketoLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public MarketoLinkedService(System.BinaryData endpoint, System.BinaryData clientId) { }
        public System.BinaryData ClientId { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase ClientSecret { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData Endpoint { get { throw null; } set { } }
        public System.BinaryData UseEncryptedEndpoints { get { throw null; } set { } }
        public System.BinaryData UseHostVerification { get { throw null; } set { } }
        public System.BinaryData UsePeerVerification { get { throw null; } set { } }
    }
    public partial class MarketoObjectDataset : Azure.ResourceManager.DataFactory.Models.Dataset
    {
        public MarketoObjectDataset(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference)) { }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class MarketoSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public MarketoSource() { }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    public partial class MetadataItem
    {
        public MetadataItem() { }
        public System.BinaryData Name { get { throw null; } set { } }
        public System.BinaryData Value { get { throw null; } set { } }
    }
    public partial class MicrosoftAccessLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public MicrosoftAccessLinkedService(System.BinaryData connectionString) { }
        public System.BinaryData AuthenticationType { get { throw null; } set { } }
        public System.BinaryData ConnectionString { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase Credential { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase Password { get { throw null; } set { } }
        public System.BinaryData UserName { get { throw null; } set { } }
    }
    public partial class MicrosoftAccessSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public MicrosoftAccessSink() { }
        public System.BinaryData PreCopyScript { get { throw null; } set { } }
    }
    public partial class MicrosoftAccessSource : Azure.ResourceManager.DataFactory.Models.CopySource
    {
        public MicrosoftAccessSource() { }
        public System.BinaryData AdditionalColumns { get { throw null; } set { } }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    public partial class MicrosoftAccessTableDataset : Azure.ResourceManager.DataFactory.Models.Dataset
    {
        public MicrosoftAccessTableDataset(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference)) { }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class MongoDbAtlasCollectionDataset : Azure.ResourceManager.DataFactory.Models.Dataset
    {
        public MongoDbAtlasCollectionDataset(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName, System.BinaryData collection) : base (default(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference)) { }
        public System.BinaryData Collection { get { throw null; } set { } }
    }
    public partial class MongoDbAtlasLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public MongoDbAtlasLinkedService(System.BinaryData connectionString, System.BinaryData database) { }
        public System.BinaryData ConnectionString { get { throw null; } set { } }
        public System.BinaryData Database { get { throw null; } set { } }
    }
    public partial class MongoDbAtlasSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public MongoDbAtlasSink() { }
        public System.BinaryData WriteBehavior { get { throw null; } set { } }
    }
    public partial class MongoDbAtlasSource : Azure.ResourceManager.DataFactory.Models.CopySource
    {
        public MongoDbAtlasSource() { }
        public System.BinaryData AdditionalColumns { get { throw null; } set { } }
        public System.BinaryData BatchSize { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.MongoDbCursorMethodsProperties CursorMethods { get { throw null; } set { } }
        public System.BinaryData Filter { get { throw null; } set { } }
        public System.BinaryData QueryTimeout { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MongoDbAuthenticationType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.MongoDbAuthenticationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MongoDbAuthenticationType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.MongoDbAuthenticationType Anonymous { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.MongoDbAuthenticationType Basic { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.MongoDbAuthenticationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.MongoDbAuthenticationType left, Azure.ResourceManager.DataFactory.Models.MongoDbAuthenticationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.MongoDbAuthenticationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.MongoDbAuthenticationType left, Azure.ResourceManager.DataFactory.Models.MongoDbAuthenticationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MongoDbCollectionDataset : Azure.ResourceManager.DataFactory.Models.Dataset
    {
        public MongoDbCollectionDataset(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName, System.BinaryData collectionName) : base (default(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference)) { }
        public System.BinaryData CollectionName { get { throw null; } set { } }
    }
    public partial class MongoDbCursorMethodsProperties
    {
        public MongoDbCursorMethodsProperties() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public System.BinaryData Limit { get { throw null; } set { } }
        public System.BinaryData Project { get { throw null; } set { } }
        public System.BinaryData Skip { get { throw null; } set { } }
        public System.BinaryData Sort { get { throw null; } set { } }
    }
    public partial class MongoDbLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public MongoDbLinkedService(System.BinaryData server, System.BinaryData databaseName) { }
        public System.BinaryData AllowSelfSignedServerCert { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.MongoDbAuthenticationType? AuthenticationType { get { throw null; } set { } }
        public System.BinaryData AuthSource { get { throw null; } set { } }
        public System.BinaryData DatabaseName { get { throw null; } set { } }
        public System.BinaryData EnableSsl { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase Password { get { throw null; } set { } }
        public System.BinaryData Port { get { throw null; } set { } }
        public System.BinaryData Server { get { throw null; } set { } }
        public System.BinaryData Username { get { throw null; } set { } }
    }
    public partial class MongoDbSource : Azure.ResourceManager.DataFactory.Models.CopySource
    {
        public MongoDbSource() { }
        public System.BinaryData AdditionalColumns { get { throw null; } set { } }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    public partial class MongoDbV2CollectionDataset : Azure.ResourceManager.DataFactory.Models.Dataset
    {
        public MongoDbV2CollectionDataset(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName, System.BinaryData collection) : base (default(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference)) { }
        public System.BinaryData Collection { get { throw null; } set { } }
    }
    public partial class MongoDbV2LinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public MongoDbV2LinkedService(System.BinaryData connectionString, System.BinaryData database) { }
        public System.BinaryData ConnectionString { get { throw null; } set { } }
        public System.BinaryData Database { get { throw null; } set { } }
    }
    public partial class MongoDbV2Sink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public MongoDbV2Sink() { }
        public System.BinaryData WriteBehavior { get { throw null; } set { } }
    }
    public partial class MongoDbV2Source : Azure.ResourceManager.DataFactory.Models.CopySource
    {
        public MongoDbV2Source() { }
        public System.BinaryData AdditionalColumns { get { throw null; } set { } }
        public System.BinaryData BatchSize { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.MongoDbCursorMethodsProperties CursorMethods { get { throw null; } set { } }
        public System.BinaryData Filter { get { throw null; } set { } }
        public System.BinaryData QueryTimeout { get { throw null; } set { } }
    }
    public partial class MultiplePipelineTrigger : Azure.ResourceManager.DataFactory.Models.DataFactoryTriggerProperties
    {
        public MultiplePipelineTrigger() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.TriggerPipelineReference> Pipelines { get { throw null; } }
    }
    public partial class MySqlLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public MySqlLinkedService(System.BinaryData connectionString) { }
        public System.BinaryData ConnectionString { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.AzureKeyVaultSecretReference Password { get { throw null; } set { } }
    }
    public partial class MySqlSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public MySqlSource() { }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    public partial class MySqlTableDataset : Azure.ResourceManager.DataFactory.Models.Dataset
    {
        public MySqlTableDataset(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference)) { }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class NetezzaLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public NetezzaLinkedService() { }
        public System.BinaryData ConnectionString { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.AzureKeyVaultSecretReference Pwd { get { throw null; } set { } }
    }
    public partial class NetezzaPartitionSettings
    {
        public NetezzaPartitionSettings() { }
        public System.BinaryData PartitionColumnName { get { throw null; } set { } }
        public System.BinaryData PartitionLowerBound { get { throw null; } set { } }
        public System.BinaryData PartitionUpperBound { get { throw null; } set { } }
    }
    public partial class NetezzaSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public NetezzaSource() { }
        public System.BinaryData PartitionOption { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.NetezzaPartitionSettings PartitionSettings { get { throw null; } set { } }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    public partial class NetezzaTableDataset : Azure.ResourceManager.DataFactory.Models.Dataset
    {
        public NetezzaTableDataset(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference)) { }
        public System.BinaryData SchemaTypePropertiesSchema { get { throw null; } set { } }
        public System.BinaryData Table { get { throw null; } set { } }
        public System.BinaryData TableName { get { throw null; } set { } }
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
    public partial class ODataLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public ODataLinkedService(System.BinaryData uri) { }
        public System.BinaryData AadResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.ODataAadServicePrincipalCredentialType? AadServicePrincipalCredentialType { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.ODataAuthenticationType? AuthenticationType { get { throw null; } set { } }
        public System.BinaryData AuthHeaders { get { throw null; } set { } }
        public System.BinaryData AzureCloudType { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase Password { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase ServicePrincipalEmbeddedCert { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase ServicePrincipalEmbeddedCertPassword { get { throw null; } set { } }
        public System.BinaryData ServicePrincipalId { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase ServicePrincipalKey { get { throw null; } set { } }
        public System.BinaryData Tenant { get { throw null; } set { } }
        public System.BinaryData Uri { get { throw null; } set { } }
        public System.BinaryData UserName { get { throw null; } set { } }
    }
    public partial class ODataResourceDataset : Azure.ResourceManager.DataFactory.Models.Dataset
    {
        public ODataResourceDataset(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference)) { }
        public System.BinaryData Path { get { throw null; } set { } }
    }
    public partial class ODataSource : Azure.ResourceManager.DataFactory.Models.CopySource
    {
        public ODataSource() { }
        public System.BinaryData AdditionalColumns { get { throw null; } set { } }
        public System.BinaryData HttpRequestTimeout { get { throw null; } set { } }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    public partial class OdbcLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public OdbcLinkedService(System.BinaryData connectionString) { }
        public System.BinaryData AuthenticationType { get { throw null; } set { } }
        public System.BinaryData ConnectionString { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase Credential { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase Password { get { throw null; } set { } }
        public System.BinaryData UserName { get { throw null; } set { } }
    }
    public partial class OdbcSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public OdbcSink() { }
        public System.BinaryData PreCopyScript { get { throw null; } set { } }
    }
    public partial class OdbcSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public OdbcSource() { }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    public partial class OdbcTableDataset : Azure.ResourceManager.DataFactory.Models.Dataset
    {
        public OdbcTableDataset(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference)) { }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class Office365Dataset : Azure.ResourceManager.DataFactory.Models.Dataset
    {
        public Office365Dataset(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName, System.BinaryData tableName) : base (default(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference)) { }
        public System.BinaryData Predicate { get { throw null; } set { } }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class Office365LinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public Office365LinkedService(System.BinaryData office365TenantId, System.BinaryData servicePrincipalTenantId, System.BinaryData servicePrincipalId, Azure.ResourceManager.DataFactory.Models.SecretBase servicePrincipalKey) { }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData Office365TenantId { get { throw null; } set { } }
        public System.BinaryData ServicePrincipalId { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase ServicePrincipalKey { get { throw null; } set { } }
        public System.BinaryData ServicePrincipalTenantId { get { throw null; } set { } }
    }
    public partial class Office365Source : Azure.ResourceManager.DataFactory.Models.CopySource
    {
        public Office365Source() { }
        public System.BinaryData AllowedGroups { get { throw null; } set { } }
        public System.BinaryData DateFilterColumn { get { throw null; } set { } }
        public System.BinaryData EndTime { get { throw null; } set { } }
        public System.BinaryData OutputColumns { get { throw null; } set { } }
        public System.BinaryData StartTime { get { throw null; } set { } }
        public System.BinaryData UserScopeFilterUri { get { throw null; } set { } }
    }
    public partial class OracleCloudStorageLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public OracleCloudStorageLinkedService() { }
        public System.BinaryData AccessKeyId { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase SecretAccessKey { get { throw null; } set { } }
        public System.BinaryData ServiceUri { get { throw null; } set { } }
    }
    public partial class OracleCloudStorageLocation : Azure.ResourceManager.DataFactory.Models.DatasetLocation
    {
        public OracleCloudStorageLocation() { }
        public System.BinaryData BucketName { get { throw null; } set { } }
        public System.BinaryData Version { get { throw null; } set { } }
    }
    public partial class OracleCloudStorageReadSettings : Azure.ResourceManager.DataFactory.Models.StoreReadSettings
    {
        public OracleCloudStorageReadSettings() { }
        public System.BinaryData DeleteFilesAfterCompletion { get { throw null; } set { } }
        public bool? EnablePartitionDiscovery { get { throw null; } set { } }
        public System.BinaryData FileListPath { get { throw null; } set { } }
        public System.BinaryData ModifiedDatetimeEnd { get { throw null; } set { } }
        public System.BinaryData ModifiedDatetimeStart { get { throw null; } set { } }
        public System.BinaryData PartitionRootPath { get { throw null; } set { } }
        public System.BinaryData Prefix { get { throw null; } set { } }
        public System.BinaryData Recursive { get { throw null; } set { } }
        public System.BinaryData WildcardFileName { get { throw null; } set { } }
        public System.BinaryData WildcardFolderPath { get { throw null; } set { } }
    }
    public partial class OracleLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public OracleLinkedService(System.BinaryData connectionString) { }
        public System.BinaryData ConnectionString { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.AzureKeyVaultSecretReference Password { get { throw null; } set { } }
    }
    public partial class OraclePartitionSettings
    {
        public OraclePartitionSettings() { }
        public System.BinaryData PartitionColumnName { get { throw null; } set { } }
        public System.BinaryData PartitionLowerBound { get { throw null; } set { } }
        public System.BinaryData PartitionNames { get { throw null; } set { } }
        public System.BinaryData PartitionUpperBound { get { throw null; } set { } }
    }
    public partial class OracleServiceCloudLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public OracleServiceCloudLinkedService(System.BinaryData host, System.BinaryData username, Azure.ResourceManager.DataFactory.Models.SecretBase password) { }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData Host { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase Password { get { throw null; } set { } }
        public System.BinaryData UseEncryptedEndpoints { get { throw null; } set { } }
        public System.BinaryData UseHostVerification { get { throw null; } set { } }
        public System.BinaryData UsePeerVerification { get { throw null; } set { } }
        public System.BinaryData Username { get { throw null; } set { } }
    }
    public partial class OracleServiceCloudObjectDataset : Azure.ResourceManager.DataFactory.Models.Dataset
    {
        public OracleServiceCloudObjectDataset(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference)) { }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class OracleServiceCloudSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public OracleServiceCloudSource() { }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    public partial class OracleSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public OracleSink() { }
        public System.BinaryData PreCopyScript { get { throw null; } set { } }
    }
    public partial class OracleSource : Azure.ResourceManager.DataFactory.Models.CopySource
    {
        public OracleSource() { }
        public System.BinaryData AdditionalColumns { get { throw null; } set { } }
        public System.BinaryData OracleReaderQuery { get { throw null; } set { } }
        public System.BinaryData PartitionOption { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.OraclePartitionSettings PartitionSettings { get { throw null; } set { } }
        public System.BinaryData QueryTimeout { get { throw null; } set { } }
    }
    public partial class OracleTableDataset : Azure.ResourceManager.DataFactory.Models.Dataset
    {
        public OracleTableDataset(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference)) { }
        public System.BinaryData SchemaTypePropertiesSchema { get { throw null; } set { } }
        public System.BinaryData Table { get { throw null; } set { } }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class OrcDataset : Azure.ResourceManager.DataFactory.Models.Dataset
    {
        public OrcDataset(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference)) { }
        public Azure.ResourceManager.DataFactory.Models.DatasetLocation Location { get { throw null; } set { } }
        public System.BinaryData OrcCompressionCodec { get { throw null; } set { } }
    }
    public partial class OrcFormat : Azure.ResourceManager.DataFactory.Models.DatasetStorageFormat
    {
        public OrcFormat() { }
    }
    public partial class OrcSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public OrcSink() { }
        public Azure.ResourceManager.DataFactory.Models.OrcWriteSettings FormatSettings { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.StoreWriteSettings StoreSettings { get { throw null; } set { } }
    }
    public partial class OrcSource : Azure.ResourceManager.DataFactory.Models.CopySource
    {
        public OrcSource() { }
        public System.BinaryData AdditionalColumns { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.StoreReadSettings StoreSettings { get { throw null; } set { } }
    }
    public partial class OrcWriteSettings : Azure.ResourceManager.DataFactory.Models.FormatWriteSettings
    {
        public OrcWriteSettings() { }
        public System.BinaryData FileNamePrefix { get { throw null; } set { } }
        public System.BinaryData MaxRowsPerFile { get { throw null; } set { } }
    }
    public partial class PackageStore
    {
        public PackageStore(string name, Azure.ResourceManager.DataFactory.Models.EntityReference packageStoreLinkedService) { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.EntityReference PackageStoreLinkedService { get { throw null; } set { } }
    }
    public partial class ParameterSpecification
    {
        public ParameterSpecification(Azure.ResourceManager.DataFactory.Models.ParameterType parameterType) { }
        public System.BinaryData DefaultValue { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.ParameterType ParameterType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ParameterType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.ParameterType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ParameterType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.ParameterType Array { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.ParameterType Bool { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.ParameterType Float { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.ParameterType Int { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.ParameterType Object { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.ParameterType SecureString { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.ParameterType String { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.ParameterType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.ParameterType left, Azure.ResourceManager.DataFactory.Models.ParameterType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.ParameterType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.ParameterType left, Azure.ResourceManager.DataFactory.Models.ParameterType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ParquetDataset : Azure.ResourceManager.DataFactory.Models.Dataset
    {
        public ParquetDataset(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference)) { }
        public System.BinaryData CompressionCodec { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DatasetLocation Location { get { throw null; } set { } }
    }
    public partial class ParquetFormat : Azure.ResourceManager.DataFactory.Models.DatasetStorageFormat
    {
        public ParquetFormat() { }
    }
    public partial class ParquetSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public ParquetSink() { }
        public Azure.ResourceManager.DataFactory.Models.ParquetWriteSettings FormatSettings { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.StoreWriteSettings StoreSettings { get { throw null; } set { } }
    }
    public partial class ParquetSource : Azure.ResourceManager.DataFactory.Models.CopySource
    {
        public ParquetSource() { }
        public System.BinaryData AdditionalColumns { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.StoreReadSettings StoreSettings { get { throw null; } set { } }
    }
    public partial class ParquetWriteSettings : Azure.ResourceManager.DataFactory.Models.FormatWriteSettings
    {
        public ParquetWriteSettings() { }
        public System.BinaryData FileNamePrefix { get { throw null; } set { } }
        public System.BinaryData MaxRowsPerFile { get { throw null; } set { } }
    }
    public partial class PaypalLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public PaypalLinkedService(System.BinaryData host, System.BinaryData clientId) { }
        public System.BinaryData ClientId { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase ClientSecret { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData Host { get { throw null; } set { } }
        public System.BinaryData UseEncryptedEndpoints { get { throw null; } set { } }
        public System.BinaryData UseHostVerification { get { throw null; } set { } }
        public System.BinaryData UsePeerVerification { get { throw null; } set { } }
    }
    public partial class PaypalObjectDataset : Azure.ResourceManager.DataFactory.Models.Dataset
    {
        public PaypalObjectDataset(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference)) { }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class PaypalSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public PaypalSource() { }
        public System.BinaryData Query { get { throw null; } set { } }
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
    public partial class PhoenixLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public PhoenixLinkedService(System.BinaryData host, Azure.ResourceManager.DataFactory.Models.PhoenixAuthenticationType authenticationType) { }
        public System.BinaryData AllowHostNameCNMismatch { get { throw null; } set { } }
        public System.BinaryData AllowSelfSignedServerCert { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.PhoenixAuthenticationType AuthenticationType { get { throw null; } set { } }
        public System.BinaryData EnableSsl { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData Host { get { throw null; } set { } }
        public System.BinaryData HttpPath { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase Password { get { throw null; } set { } }
        public System.BinaryData Port { get { throw null; } set { } }
        public System.BinaryData TrustedCertPath { get { throw null; } set { } }
        public System.BinaryData Username { get { throw null; } set { } }
        public System.BinaryData UseSystemTrustStore { get { throw null; } set { } }
    }
    public partial class PhoenixObjectDataset : Azure.ResourceManager.DataFactory.Models.Dataset
    {
        public PhoenixObjectDataset(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference)) { }
        public System.BinaryData SchemaTypePropertiesSchema { get { throw null; } set { } }
        public System.BinaryData Table { get { throw null; } set { } }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class PhoenixSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public PhoenixSource() { }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    public partial class PipelineReference
    {
        public PipelineReference(Azure.ResourceManager.DataFactory.Models.PipelineReferenceType referenceType, string referenceName) { }
        public string Name { get { throw null; } set { } }
        public string ReferenceName { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.PipelineReferenceType ReferenceType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PipelineReferenceType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.PipelineReferenceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PipelineReferenceType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.PipelineReferenceType PipelineReference { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.PipelineReferenceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.PipelineReferenceType left, Azure.ResourceManager.DataFactory.Models.PipelineReferenceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.PipelineReferenceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.PipelineReferenceType left, Azure.ResourceManager.DataFactory.Models.PipelineReferenceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PipelineRun
    {
        internal PipelineRun() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public int? DurationInMs { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.PipelineRunInvokedBy InvokedBy { get { throw null; } }
        public bool? IsLatest { get { throw null; } }
        public System.DateTimeOffset? LastUpdated { get { throw null; } }
        public string Message { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Parameters { get { throw null; } }
        public string PipelineName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> RunDimensions { get { throw null; } }
        public System.DateTimeOffset? RunEnd { get { throw null; } }
        public string RunGroupId { get { throw null; } }
        public string RunId { get { throw null; } }
        public System.DateTimeOffset? RunStart { get { throw null; } }
        public string Status { get { throw null; } }
    }
    public partial class PipelineRunInvokedBy
    {
        internal PipelineRunInvokedBy() { }
        public string Id { get { throw null; } }
        public string InvokedByType { get { throw null; } }
        public string Name { get { throw null; } }
        public string PipelineName { get { throw null; } }
        public string PipelineRunId { get { throw null; } }
    }
    public partial class PolybaseSettings
    {
        public PolybaseSettings() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public System.BinaryData RejectSampleValue { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.PolybaseSettingsRejectType? RejectType { get { throw null; } set { } }
        public System.BinaryData RejectValue { get { throw null; } set { } }
        public System.BinaryData UseTypeDefault { get { throw null; } set { } }
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
    public partial class PostgreSqlLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public PostgreSqlLinkedService(System.BinaryData connectionString) { }
        public System.BinaryData ConnectionString { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.AzureKeyVaultSecretReference Password { get { throw null; } set { } }
    }
    public partial class PostgreSqlSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public PostgreSqlSource() { }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    public partial class PostgreSqlTableDataset : Azure.ResourceManager.DataFactory.Models.Dataset
    {
        public PostgreSqlTableDataset(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference)) { }
        public System.BinaryData SchemaTypePropertiesSchema { get { throw null; } set { } }
        public System.BinaryData Table { get { throw null; } set { } }
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
    public partial class PrestoLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public PrestoLinkedService(System.BinaryData host, System.BinaryData serverVersion, System.BinaryData catalog, Azure.ResourceManager.DataFactory.Models.PrestoAuthenticationType authenticationType) { }
        public System.BinaryData AllowHostNameCNMismatch { get { throw null; } set { } }
        public System.BinaryData AllowSelfSignedServerCert { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.PrestoAuthenticationType AuthenticationType { get { throw null; } set { } }
        public System.BinaryData Catalog { get { throw null; } set { } }
        public System.BinaryData EnableSsl { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData Host { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase Password { get { throw null; } set { } }
        public System.BinaryData Port { get { throw null; } set { } }
        public System.BinaryData ServerVersion { get { throw null; } set { } }
        public System.BinaryData TimeZoneId { get { throw null; } set { } }
        public System.BinaryData TrustedCertPath { get { throw null; } set { } }
        public System.BinaryData Username { get { throw null; } set { } }
        public System.BinaryData UseSystemTrustStore { get { throw null; } set { } }
    }
    public partial class PrestoObjectDataset : Azure.ResourceManager.DataFactory.Models.Dataset
    {
        public PrestoObjectDataset(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference)) { }
        public System.BinaryData SchemaTypePropertiesSchema { get { throw null; } set { } }
        public System.BinaryData Table { get { throw null; } set { } }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class PrestoSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public PrestoSource() { }
        public System.BinaryData Query { get { throw null; } set { } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PublicNetworkAccess : System.IEquatable<Azure.ResourceManager.DataFactory.Models.PublicNetworkAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PublicNetworkAccess(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.PublicNetworkAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.PublicNetworkAccess Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.PublicNetworkAccess other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.PublicNetworkAccess left, Azure.ResourceManager.DataFactory.Models.PublicNetworkAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.PublicNetworkAccess (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.PublicNetworkAccess left, Azure.ResourceManager.DataFactory.Models.PublicNetworkAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class QuickbaseLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public QuickbaseLinkedService(System.BinaryData uri, Azure.ResourceManager.DataFactory.Models.SecretBase userToken) { }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData Uri { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase UserToken { get { throw null; } set { } }
    }
    public partial class QuickBooksLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public QuickBooksLinkedService() { }
        public Azure.ResourceManager.DataFactory.Models.SecretBase AccessToken { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase AccessTokenSecret { get { throw null; } set { } }
        public System.BinaryData CompanyId { get { throw null; } set { } }
        public System.BinaryData ConnectionProperties { get { throw null; } set { } }
        public System.BinaryData ConsumerKey { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase ConsumerSecret { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData Endpoint { get { throw null; } set { } }
        public System.BinaryData UseEncryptedEndpoints { get { throw null; } set { } }
    }
    public partial class QuickBooksObjectDataset : Azure.ResourceManager.DataFactory.Models.Dataset
    {
        public QuickBooksObjectDataset(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference)) { }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class QuickBooksSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public QuickBooksSource() { }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RecurrenceFrequency : System.IEquatable<Azure.ResourceManager.DataFactory.Models.RecurrenceFrequency>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecurrenceFrequency(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.RecurrenceFrequency Day { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.RecurrenceFrequency Hour { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.RecurrenceFrequency Minute { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.RecurrenceFrequency Month { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.RecurrenceFrequency NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.RecurrenceFrequency Week { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.RecurrenceFrequency Year { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.RecurrenceFrequency other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.RecurrenceFrequency left, Azure.ResourceManager.DataFactory.Models.RecurrenceFrequency right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.RecurrenceFrequency (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.RecurrenceFrequency left, Azure.ResourceManager.DataFactory.Models.RecurrenceFrequency right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RecurrenceSchedule
    {
        public RecurrenceSchedule() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public System.Collections.Generic.IList<int> Hours { get { throw null; } }
        public System.Collections.Generic.IList<int> Minutes { get { throw null; } }
        public System.Collections.Generic.IList<int> MonthDays { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.RecurrenceScheduleOccurrence> MonthlyOccurrences { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.DaysOfWeek> WeekDays { get { throw null; } }
    }
    public partial class RecurrenceScheduleOccurrence
    {
        public RecurrenceScheduleOccurrence() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.DayOfWeek? Day { get { throw null; } set { } }
        public int? Occurrence { get { throw null; } set { } }
    }
    public partial class RedirectIncompatibleRowSettings
    {
        public RedirectIncompatibleRowSettings(System.BinaryData linkedServiceName) { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public System.BinaryData LinkedServiceName { get { throw null; } set { } }
        public System.BinaryData Path { get { throw null; } set { } }
    }
    public partial class RedshiftUnloadSettings
    {
        public RedshiftUnloadSettings(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference s3LinkedServiceName, System.BinaryData bucketName) { }
        public System.BinaryData BucketName { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.LinkedServiceReference S3LinkedServiceName { get { throw null; } set { } }
    }
    public partial class RelationalSource : Azure.ResourceManager.DataFactory.Models.CopySource
    {
        public RelationalSource() { }
        public System.BinaryData AdditionalColumns { get { throw null; } set { } }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    public partial class RelationalTableDataset : Azure.ResourceManager.DataFactory.Models.Dataset
    {
        public RelationalTableDataset(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference)) { }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class RemotePrivateEndpointConnection
    {
        public RemotePrivateEndpointConnection() { }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.PrivateLinkConnectionState PrivateLinkServiceConnectionState { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
    }
    public partial class RerunTumblingWindowTrigger : Azure.ResourceManager.DataFactory.Models.DataFactoryTriggerProperties
    {
        public RerunTumblingWindowTrigger(System.BinaryData parentTrigger, System.DateTimeOffset requestedStartOn, System.DateTimeOffset requestedEndOn, int rerunConcurrency) { }
        public System.BinaryData ParentTrigger { get { throw null; } set { } }
        public System.DateTimeOffset RequestedEndOn { get { throw null; } set { } }
        public System.DateTimeOffset RequestedStartOn { get { throw null; } set { } }
        public int RerunConcurrency { get { throw null; } set { } }
    }
    public partial class ResponsysLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public ResponsysLinkedService(System.BinaryData endpoint, System.BinaryData clientId) { }
        public System.BinaryData ClientId { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase ClientSecret { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData Endpoint { get { throw null; } set { } }
        public System.BinaryData UseEncryptedEndpoints { get { throw null; } set { } }
        public System.BinaryData UseHostVerification { get { throw null; } set { } }
        public System.BinaryData UsePeerVerification { get { throw null; } set { } }
    }
    public partial class ResponsysObjectDataset : Azure.ResourceManager.DataFactory.Models.Dataset
    {
        public ResponsysObjectDataset(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference)) { }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class ResponsysSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public ResponsysSource() { }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    public partial class RestResourceDataset : Azure.ResourceManager.DataFactory.Models.Dataset
    {
        public RestResourceDataset(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference)) { }
        public System.BinaryData AdditionalHeaders { get { throw null; } set { } }
        public System.BinaryData PaginationRules { get { throw null; } set { } }
        public System.BinaryData RelativeUri { get { throw null; } set { } }
        public System.BinaryData RequestBody { get { throw null; } set { } }
        public System.BinaryData RequestMethod { get { throw null; } set { } }
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
    public partial class RestServiceLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public RestServiceLinkedService(System.BinaryData uri, Azure.ResourceManager.DataFactory.Models.RestServiceAuthenticationType authenticationType) { }
        public System.BinaryData AadResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.RestServiceAuthenticationType AuthenticationType { get { throw null; } set { } }
        public System.BinaryData AuthHeaders { get { throw null; } set { } }
        public System.BinaryData AzureCloudType { get { throw null; } set { } }
        public System.BinaryData ClientId { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase ClientSecret { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.CredentialReference Credential { get { throw null; } set { } }
        public System.BinaryData EnableServerCertificateValidation { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase Password { get { throw null; } set { } }
        public System.BinaryData Resource { get { throw null; } set { } }
        public System.BinaryData Scope { get { throw null; } set { } }
        public System.BinaryData ServicePrincipalId { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase ServicePrincipalKey { get { throw null; } set { } }
        public System.BinaryData Tenant { get { throw null; } set { } }
        public System.BinaryData TokenEndpoint { get { throw null; } set { } }
        public System.BinaryData Uri { get { throw null; } set { } }
        public System.BinaryData UserName { get { throw null; } set { } }
    }
    public partial class RestSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public RestSink() { }
        public System.BinaryData AdditionalHeaders { get { throw null; } set { } }
        public System.BinaryData HttpCompressionType { get { throw null; } set { } }
        public System.BinaryData HttpRequestTimeout { get { throw null; } set { } }
        public System.BinaryData RequestInterval { get { throw null; } set { } }
        public System.BinaryData RequestMethod { get { throw null; } set { } }
    }
    public partial class RestSource : Azure.ResourceManager.DataFactory.Models.CopySource
    {
        public RestSource() { }
        public System.BinaryData AdditionalColumns { get { throw null; } set { } }
        public System.BinaryData AdditionalHeaders { get { throw null; } set { } }
        public System.BinaryData HttpRequestTimeout { get { throw null; } set { } }
        public System.BinaryData PaginationRules { get { throw null; } set { } }
        public System.BinaryData RequestBody { get { throw null; } set { } }
        public System.BinaryData RequestInterval { get { throw null; } set { } }
        public System.BinaryData RequestMethod { get { throw null; } set { } }
    }
    public partial class RetryPolicy
    {
        public RetryPolicy() { }
        public System.BinaryData Count { get { throw null; } set { } }
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
        public static Azure.ResourceManager.DataFactory.Models.RunQueryOrder ASC { get { throw null; } }
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
    public partial class SalesforceLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public SalesforceLinkedService() { }
        public System.BinaryData ApiVersion { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData EnvironmentUri { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase Password { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase SecurityToken { get { throw null; } set { } }
        public System.BinaryData Username { get { throw null; } set { } }
    }
    public partial class SalesforceMarketingCloudLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public SalesforceMarketingCloudLinkedService() { }
        public System.BinaryData ClientId { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase ClientSecret { get { throw null; } set { } }
        public System.BinaryData ConnectionProperties { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData UseEncryptedEndpoints { get { throw null; } set { } }
        public System.BinaryData UseHostVerification { get { throw null; } set { } }
        public System.BinaryData UsePeerVerification { get { throw null; } set { } }
    }
    public partial class SalesforceMarketingCloudObjectDataset : Azure.ResourceManager.DataFactory.Models.Dataset
    {
        public SalesforceMarketingCloudObjectDataset(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference)) { }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class SalesforceMarketingCloudSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public SalesforceMarketingCloudSource() { }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    public partial class SalesforceObjectDataset : Azure.ResourceManager.DataFactory.Models.Dataset
    {
        public SalesforceObjectDataset(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference)) { }
        public System.BinaryData ObjectApiName { get { throw null; } set { } }
    }
    public partial class SalesforceServiceCloudLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public SalesforceServiceCloudLinkedService() { }
        public System.BinaryData ApiVersion { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData EnvironmentUri { get { throw null; } set { } }
        public System.BinaryData ExtendedProperties { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase Password { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase SecurityToken { get { throw null; } set { } }
        public System.BinaryData Username { get { throw null; } set { } }
    }
    public partial class SalesforceServiceCloudObjectDataset : Azure.ResourceManager.DataFactory.Models.Dataset
    {
        public SalesforceServiceCloudObjectDataset(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference)) { }
        public System.BinaryData ObjectApiName { get { throw null; } set { } }
    }
    public partial class SalesforceServiceCloudSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public SalesforceServiceCloudSink() { }
        public System.BinaryData ExternalIdFieldName { get { throw null; } set { } }
        public System.BinaryData IgnoreNullValues { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SalesforceSinkWriteBehavior? WriteBehavior { get { throw null; } set { } }
    }
    public partial class SalesforceServiceCloudSource : Azure.ResourceManager.DataFactory.Models.CopySource
    {
        public SalesforceServiceCloudSource() { }
        public System.BinaryData AdditionalColumns { get { throw null; } set { } }
        public System.BinaryData Query { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SalesforceSourceReadBehavior? ReadBehavior { get { throw null; } set { } }
    }
    public partial class SalesforceSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public SalesforceSink() { }
        public System.BinaryData ExternalIdFieldName { get { throw null; } set { } }
        public System.BinaryData IgnoreNullValues { get { throw null; } set { } }
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
        public System.BinaryData Query { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SalesforceSourceReadBehavior? ReadBehavior { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SalesforceSourceReadBehavior : System.IEquatable<Azure.ResourceManager.DataFactory.Models.SalesforceSourceReadBehavior>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SalesforceSourceReadBehavior(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.SalesforceSourceReadBehavior Query { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.SalesforceSourceReadBehavior QueryAll { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.SalesforceSourceReadBehavior other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.SalesforceSourceReadBehavior left, Azure.ResourceManager.DataFactory.Models.SalesforceSourceReadBehavior right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.SalesforceSourceReadBehavior (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.SalesforceSourceReadBehavior left, Azure.ResourceManager.DataFactory.Models.SalesforceSourceReadBehavior right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SapBwCubeDataset : Azure.ResourceManager.DataFactory.Models.Dataset
    {
        public SapBwCubeDataset(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference)) { }
    }
    public partial class SapBWLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public SapBWLinkedService(System.BinaryData server, System.BinaryData systemNumber, System.BinaryData clientId) { }
        public System.BinaryData ClientId { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase Password { get { throw null; } set { } }
        public System.BinaryData Server { get { throw null; } set { } }
        public System.BinaryData SystemNumber { get { throw null; } set { } }
        public System.BinaryData UserName { get { throw null; } set { } }
    }
    public partial class SapBwSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public SapBwSource() { }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    public partial class SapCloudForCustomerLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public SapCloudForCustomerLinkedService(System.BinaryData uri) { }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase Password { get { throw null; } set { } }
        public System.BinaryData Uri { get { throw null; } set { } }
        public System.BinaryData Username { get { throw null; } set { } }
    }
    public partial class SapCloudForCustomerResourceDataset : Azure.ResourceManager.DataFactory.Models.Dataset
    {
        public SapCloudForCustomerResourceDataset(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName, System.BinaryData path) : base (default(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference)) { }
        public System.BinaryData Path { get { throw null; } set { } }
    }
    public partial class SapCloudForCustomerSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public SapCloudForCustomerSink() { }
        public System.BinaryData HttpRequestTimeout { get { throw null; } set { } }
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
        public System.BinaryData HttpRequestTimeout { get { throw null; } set { } }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    public partial class SapEccLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public SapEccLinkedService(System.Uri uri) { }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase Password { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
        public string Username { get { throw null; } set { } }
    }
    public partial class SapEccResourceDataset : Azure.ResourceManager.DataFactory.Models.Dataset
    {
        public SapEccResourceDataset(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName, System.BinaryData path) : base (default(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference)) { }
        public System.BinaryData Path { get { throw null; } set { } }
    }
    public partial class SapEccSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public SapEccSource() { }
        public System.BinaryData HttpRequestTimeout { get { throw null; } set { } }
        public System.BinaryData Query { get { throw null; } set { } }
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
    public partial class SapHanaLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public SapHanaLinkedService() { }
        public Azure.ResourceManager.DataFactory.Models.SapHanaAuthenticationType? AuthenticationType { get { throw null; } set { } }
        public System.BinaryData ConnectionString { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase Password { get { throw null; } set { } }
        public System.BinaryData Server { get { throw null; } set { } }
        public System.BinaryData UserName { get { throw null; } set { } }
    }
    public partial class SapHanaSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public SapHanaSource() { }
        public System.BinaryData PacketSize { get { throw null; } set { } }
        public System.BinaryData PartitionColumnName { get { throw null; } set { } }
        public System.BinaryData PartitionOption { get { throw null; } set { } }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    public partial class SapHanaTableDataset : Azure.ResourceManager.DataFactory.Models.Dataset
    {
        public SapHanaTableDataset(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference)) { }
        public System.BinaryData SchemaTypePropertiesSchema { get { throw null; } set { } }
        public System.BinaryData Table { get { throw null; } set { } }
    }
    public partial class SapOdpLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public SapOdpLinkedService() { }
        public System.BinaryData ClientId { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData Language { get { throw null; } set { } }
        public System.BinaryData LogonGroup { get { throw null; } set { } }
        public System.BinaryData MessageServer { get { throw null; } set { } }
        public System.BinaryData MessageServerService { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase Password { get { throw null; } set { } }
        public System.BinaryData Server { get { throw null; } set { } }
        public System.BinaryData SncLibraryPath { get { throw null; } set { } }
        public System.BinaryData SncMode { get { throw null; } set { } }
        public System.BinaryData SncMyName { get { throw null; } set { } }
        public System.BinaryData SncPartnerName { get { throw null; } set { } }
        public System.BinaryData SncQop { get { throw null; } set { } }
        public System.BinaryData SubscriberName { get { throw null; } set { } }
        public System.BinaryData SystemId { get { throw null; } set { } }
        public System.BinaryData SystemNumber { get { throw null; } set { } }
        public System.BinaryData UserName { get { throw null; } set { } }
        public System.BinaryData X509CertificatePath { get { throw null; } set { } }
    }
    public partial class SapOdpResourceDataset : Azure.ResourceManager.DataFactory.Models.Dataset
    {
        public SapOdpResourceDataset(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName, System.BinaryData context, System.BinaryData objectName) : base (default(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference)) { }
        public System.BinaryData Context { get { throw null; } set { } }
        public System.BinaryData ObjectName { get { throw null; } set { } }
    }
    public partial class SapOdpSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public SapOdpSource() { }
        public System.BinaryData ExtractionMode { get { throw null; } set { } }
        public System.BinaryData Projection { get { throw null; } set { } }
        public System.BinaryData Selection { get { throw null; } set { } }
        public System.BinaryData SubscriberProcess { get { throw null; } set { } }
    }
    public partial class SapOpenHubLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public SapOpenHubLinkedService() { }
        public System.BinaryData ClientId { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData Language { get { throw null; } set { } }
        public System.BinaryData LogonGroup { get { throw null; } set { } }
        public System.BinaryData MessageServer { get { throw null; } set { } }
        public System.BinaryData MessageServerService { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase Password { get { throw null; } set { } }
        public System.BinaryData Server { get { throw null; } set { } }
        public System.BinaryData SystemId { get { throw null; } set { } }
        public System.BinaryData SystemNumber { get { throw null; } set { } }
        public System.BinaryData UserName { get { throw null; } set { } }
    }
    public partial class SapOpenHubSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public SapOpenHubSource() { }
        public System.BinaryData BaseRequestId { get { throw null; } set { } }
        public System.BinaryData CustomRfcReadTableFunctionModule { get { throw null; } set { } }
        public System.BinaryData ExcludeLastRequest { get { throw null; } set { } }
        public System.BinaryData SapDataColumnDelimiter { get { throw null; } set { } }
    }
    public partial class SapOpenHubTableDataset : Azure.ResourceManager.DataFactory.Models.Dataset
    {
        public SapOpenHubTableDataset(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName, System.BinaryData openHubDestinationName) : base (default(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference)) { }
        public System.BinaryData BaseRequestId { get { throw null; } set { } }
        public System.BinaryData ExcludeLastRequest { get { throw null; } set { } }
        public System.BinaryData OpenHubDestinationName { get { throw null; } set { } }
    }
    public partial class SapTableLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public SapTableLinkedService() { }
        public System.BinaryData ClientId { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData Language { get { throw null; } set { } }
        public System.BinaryData LogonGroup { get { throw null; } set { } }
        public System.BinaryData MessageServer { get { throw null; } set { } }
        public System.BinaryData MessageServerService { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase Password { get { throw null; } set { } }
        public System.BinaryData Server { get { throw null; } set { } }
        public System.BinaryData SncLibraryPath { get { throw null; } set { } }
        public System.BinaryData SncMode { get { throw null; } set { } }
        public System.BinaryData SncMyName { get { throw null; } set { } }
        public System.BinaryData SncPartnerName { get { throw null; } set { } }
        public System.BinaryData SncQop { get { throw null; } set { } }
        public System.BinaryData SystemId { get { throw null; } set { } }
        public System.BinaryData SystemNumber { get { throw null; } set { } }
        public System.BinaryData UserName { get { throw null; } set { } }
    }
    public partial class SapTablePartitionSettings
    {
        public SapTablePartitionSettings() { }
        public System.BinaryData MaxPartitionsNumber { get { throw null; } set { } }
        public System.BinaryData PartitionColumnName { get { throw null; } set { } }
        public System.BinaryData PartitionLowerBound { get { throw null; } set { } }
        public System.BinaryData PartitionUpperBound { get { throw null; } set { } }
    }
    public partial class SapTableResourceDataset : Azure.ResourceManager.DataFactory.Models.Dataset
    {
        public SapTableResourceDataset(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName, System.BinaryData tableName) : base (default(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference)) { }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class SapTableSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public SapTableSource() { }
        public System.BinaryData BatchSize { get { throw null; } set { } }
        public System.BinaryData CustomRfcReadTableFunctionModule { get { throw null; } set { } }
        public System.BinaryData PartitionOption { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SapTablePartitionSettings PartitionSettings { get { throw null; } set { } }
        public System.BinaryData RfcTableFields { get { throw null; } set { } }
        public System.BinaryData RfcTableOptions { get { throw null; } set { } }
        public System.BinaryData RowCount { get { throw null; } set { } }
        public System.BinaryData RowSkips { get { throw null; } set { } }
        public System.BinaryData SapDataColumnDelimiter { get { throw null; } set { } }
    }
    public partial class ScheduleTrigger : Azure.ResourceManager.DataFactory.Models.MultiplePipelineTrigger
    {
        public ScheduleTrigger(Azure.ResourceManager.DataFactory.Models.ScheduleTriggerRecurrence recurrence) { }
        public Azure.ResourceManager.DataFactory.Models.ScheduleTriggerRecurrence Recurrence { get { throw null; } set { } }
    }
    public partial class ScheduleTriggerRecurrence
    {
        public ScheduleTriggerRecurrence() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.RecurrenceFrequency? Frequency { get { throw null; } set { } }
        public int? Interval { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.RecurrenceSchedule Schedule { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        public string TimeZone { get { throw null; } set { } }
    }
    public partial class ScriptAction
    {
        public ScriptAction(string name, System.Uri uri, System.BinaryData roles) { }
        public string Name { get { throw null; } set { } }
        public string Parameters { get { throw null; } set { } }
        public System.BinaryData Roles { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    public partial class ScriptActivity : Azure.ResourceManager.DataFactory.Models.ExecutionActivity
    {
        public ScriptActivity(string name) : base (default(string)) { }
        public Azure.ResourceManager.DataFactory.Models.ScriptActivityTypePropertiesLogSettings LogSettings { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.ScriptActivityScriptBlock> Scripts { get { throw null; } }
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
        public System.BinaryData Name { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.ScriptActivityParameterType? ParameterType { get { throw null; } set { } }
        public int? Size { get { throw null; } set { } }
        public System.BinaryData Value { get { throw null; } set { } }
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
        public static Azure.ResourceManager.DataFactory.Models.ScriptActivityParameterType Timespan { get { throw null; } }
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
        public ScriptActivityScriptBlock(System.BinaryData text, Azure.ResourceManager.DataFactory.Models.ScriptType scriptType) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.ScriptActivityParameter> Parameters { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.ScriptType ScriptType { get { throw null; } set { } }
        public System.BinaryData Text { get { throw null; } set { } }
    }
    public partial class ScriptActivityTypePropertiesLogSettings
    {
        public ScriptActivityTypePropertiesLogSettings(Azure.ResourceManager.DataFactory.Models.ScriptActivityLogDestination logDestination) { }
        public Azure.ResourceManager.DataFactory.Models.ScriptActivityLogDestination LogDestination { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.LogLocationSettings LogLocationSettings { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScriptType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.ScriptType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScriptType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.ScriptType NonQuery { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.ScriptType Query { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.ScriptType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.ScriptType left, Azure.ResourceManager.DataFactory.Models.ScriptType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.ScriptType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.ScriptType left, Azure.ResourceManager.DataFactory.Models.ScriptType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SecretBase
    {
        public SecretBase() { }
    }
    public partial class SecureString : Azure.ResourceManager.DataFactory.Models.SecretBase
    {
        public SecureString(string value) { }
        public string Value { get { throw null; } set { } }
    }
    public partial class SelfDependencyTumblingWindowTriggerReference : Azure.ResourceManager.DataFactory.Models.DependencyReference
    {
        public SelfDependencyTumblingWindowTriggerReference(string offset) { }
        public string Offset { get { throw null; } set { } }
        public string Size { get { throw null; } set { } }
    }
    public partial class SelfHostedIntegrationRuntime : Azure.ResourceManager.DataFactory.Models.IntegrationRuntime
    {
        public SelfHostedIntegrationRuntime() { }
        public Azure.ResourceManager.DataFactory.Models.LinkedIntegrationRuntimeType LinkedInfo { get { throw null; } set { } }
    }
    public partial class SelfHostedIntegrationRuntimeNode
    {
        internal SelfHostedIntegrationRuntimeNode() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Capabilities { get { throw null; } }
        public int? ConcurrentJobsLimit { get { throw null; } }
        public System.DateTimeOffset? ExpiryOn { get { throw null; } }
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
        public Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeAutoUpdate? AutoUpdate { get { throw null; } }
        public System.DateTimeOffset? AutoUpdateETA { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Capabilities { get { throw null; } }
        public System.DateTimeOffset? CreateOn { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeInternalChannelEncryptionMode? InternalChannelEncryption { get { throw null; } }
        public string LatestVersion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataFactory.Models.LinkedIntegrationRuntime> Links { get { throw null; } }
        public string LocalTimeZoneOffset { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataFactory.Models.SelfHostedIntegrationRuntimeNode> Nodes { get { throw null; } }
        public string PushedVersion { get { throw null; } }
        public System.DateTimeOffset? ScheduledUpdateOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ServiceUrls { get { throw null; } }
        public string TaskQueueId { get { throw null; } }
        public string UpdateDelayOffset { get { throw null; } }
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
    public partial class ServiceNowLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public ServiceNowLinkedService(System.BinaryData endpoint, Azure.ResourceManager.DataFactory.Models.ServiceNowAuthenticationType authenticationType) { }
        public Azure.ResourceManager.DataFactory.Models.ServiceNowAuthenticationType AuthenticationType { get { throw null; } set { } }
        public System.BinaryData ClientId { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase ClientSecret { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData Endpoint { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase Password { get { throw null; } set { } }
        public System.BinaryData UseEncryptedEndpoints { get { throw null; } set { } }
        public System.BinaryData UseHostVerification { get { throw null; } set { } }
        public System.BinaryData UsePeerVerification { get { throw null; } set { } }
        public System.BinaryData Username { get { throw null; } set { } }
    }
    public partial class ServiceNowObjectDataset : Azure.ResourceManager.DataFactory.Models.Dataset
    {
        public ServiceNowObjectDataset(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference)) { }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class ServiceNowSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public ServiceNowSource() { }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    public partial class SetVariableActivity : Azure.ResourceManager.DataFactory.Models.ControlActivity
    {
        public SetVariableActivity(string name) : base (default(string)) { }
        public System.BinaryData Value { get { throw null; } set { } }
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
        public System.BinaryData DeleteFilesAfterCompletion { get { throw null; } set { } }
        public System.BinaryData DisableChunking { get { throw null; } set { } }
        public bool? EnablePartitionDiscovery { get { throw null; } set { } }
        public System.BinaryData FileListPath { get { throw null; } set { } }
        public System.BinaryData ModifiedDatetimeEnd { get { throw null; } set { } }
        public System.BinaryData ModifiedDatetimeStart { get { throw null; } set { } }
        public System.BinaryData PartitionRootPath { get { throw null; } set { } }
        public System.BinaryData Recursive { get { throw null; } set { } }
        public System.BinaryData WildcardFileName { get { throw null; } set { } }
        public System.BinaryData WildcardFolderPath { get { throw null; } set { } }
    }
    public partial class SftpServerLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public SftpServerLinkedService(System.BinaryData host) { }
        public Azure.ResourceManager.DataFactory.Models.SftpAuthenticationType? AuthenticationType { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData Host { get { throw null; } set { } }
        public System.BinaryData HostKeyFingerprint { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase PassPhrase { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase Password { get { throw null; } set { } }
        public System.BinaryData Port { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase PrivateKeyContent { get { throw null; } set { } }
        public System.BinaryData PrivateKeyPath { get { throw null; } set { } }
        public System.BinaryData SkipHostKeyValidation { get { throw null; } set { } }
        public System.BinaryData UserName { get { throw null; } set { } }
    }
    public partial class SftpWriteSettings : Azure.ResourceManager.DataFactory.Models.StoreWriteSettings
    {
        public SftpWriteSettings() { }
        public System.BinaryData OperationTimeout { get { throw null; } set { } }
        public System.BinaryData UseTempFileRename { get { throw null; } set { } }
    }
    public partial class SharePointOnlineListLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public SharePointOnlineListLinkedService(System.BinaryData siteUri, System.BinaryData tenantId, System.BinaryData servicePrincipalId, Azure.ResourceManager.DataFactory.Models.SecretBase servicePrincipalKey) { }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData ServicePrincipalId { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase ServicePrincipalKey { get { throw null; } set { } }
        public System.BinaryData SiteUri { get { throw null; } set { } }
        public System.BinaryData TenantId { get { throw null; } set { } }
    }
    public partial class SharePointOnlineListResourceDataset : Azure.ResourceManager.DataFactory.Models.Dataset
    {
        public SharePointOnlineListResourceDataset(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference)) { }
        public System.BinaryData ListName { get { throw null; } set { } }
    }
    public partial class SharePointOnlineListSource : Azure.ResourceManager.DataFactory.Models.CopySource
    {
        public SharePointOnlineListSource() { }
        public System.BinaryData HttpRequestTimeout { get { throw null; } set { } }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    public partial class ShopifyLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public ShopifyLinkedService(System.BinaryData host) { }
        public Azure.ResourceManager.DataFactory.Models.SecretBase AccessToken { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData Host { get { throw null; } set { } }
        public System.BinaryData UseEncryptedEndpoints { get { throw null; } set { } }
        public System.BinaryData UseHostVerification { get { throw null; } set { } }
        public System.BinaryData UsePeerVerification { get { throw null; } set { } }
    }
    public partial class ShopifyObjectDataset : Azure.ResourceManager.DataFactory.Models.Dataset
    {
        public ShopifyObjectDataset(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference)) { }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class ShopifySource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public ShopifySource() { }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    public partial class SkipErrorFile
    {
        public SkipErrorFile() { }
        public System.BinaryData DataInconsistency { get { throw null; } set { } }
        public System.BinaryData FileMissing { get { throw null; } set { } }
    }
    public partial class SmartsheetLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public SmartsheetLinkedService(Azure.ResourceManager.DataFactory.Models.SecretBase apiToken) { }
        public Azure.ResourceManager.DataFactory.Models.SecretBase ApiToken { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
    }
    public partial class SnowflakeDataset : Azure.ResourceManager.DataFactory.Models.Dataset
    {
        public SnowflakeDataset(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference)) { }
        public System.BinaryData SchemaTypePropertiesSchema { get { throw null; } set { } }
        public System.BinaryData Table { get { throw null; } set { } }
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
    public partial class SnowflakeLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public SnowflakeLinkedService(System.BinaryData connectionString) { }
        public System.BinaryData ConnectionString { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.AzureKeyVaultSecretReference Password { get { throw null; } set { } }
    }
    public partial class SnowflakeSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public SnowflakeSink() { }
        public Azure.ResourceManager.DataFactory.Models.SnowflakeImportCopyCommand ImportSettings { get { throw null; } set { } }
        public System.BinaryData PreCopyScript { get { throw null; } set { } }
    }
    public partial class SnowflakeSource : Azure.ResourceManager.DataFactory.Models.CopySource
    {
        public SnowflakeSource() { }
        public Azure.ResourceManager.DataFactory.Models.SnowflakeExportCopyCommand ExportSettings { get { throw null; } set { } }
        public System.BinaryData Query { get { throw null; } set { } }
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
    public partial class SparkLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public SparkLinkedService(System.BinaryData host, System.BinaryData port, Azure.ResourceManager.DataFactory.Models.SparkAuthenticationType authenticationType) { }
        public System.BinaryData AllowHostNameCNMismatch { get { throw null; } set { } }
        public System.BinaryData AllowSelfSignedServerCert { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SparkAuthenticationType AuthenticationType { get { throw null; } set { } }
        public System.BinaryData EnableSsl { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData Host { get { throw null; } set { } }
        public System.BinaryData HttpPath { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase Password { get { throw null; } set { } }
        public System.BinaryData Port { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SparkServerType? ServerType { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SparkThriftTransportProtocol? ThriftTransportProtocol { get { throw null; } set { } }
        public System.BinaryData TrustedCertPath { get { throw null; } set { } }
        public System.BinaryData Username { get { throw null; } set { } }
        public System.BinaryData UseSystemTrustStore { get { throw null; } set { } }
    }
    public partial class SparkObjectDataset : Azure.ResourceManager.DataFactory.Models.Dataset
    {
        public SparkObjectDataset(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference)) { }
        public System.BinaryData SchemaTypePropertiesSchema { get { throw null; } set { } }
        public System.BinaryData Table { get { throw null; } set { } }
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
        public System.BinaryData Query { get { throw null; } set { } }
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
        public Azure.ResourceManager.DataFactory.Models.CredentialReference Credential { get { throw null; } set { } }
        public System.BinaryData ServicePrincipalId { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase ServicePrincipalKey { get { throw null; } set { } }
    }
    public partial class SqlDWSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public SqlDWSink() { }
        public System.BinaryData AllowCopyCommand { get { throw null; } set { } }
        public System.BinaryData AllowPolyBase { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DWCopyCommandSettings CopyCommandSettings { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.PolybaseSettings PolyBaseSettings { get { throw null; } set { } }
        public System.BinaryData PreCopyScript { get { throw null; } set { } }
        public System.BinaryData SqlWriterUseTableLock { get { throw null; } set { } }
        public System.BinaryData TableOption { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SqlDWUpsertSettings UpsertSettings { get { throw null; } set { } }
        public System.BinaryData WriteBehavior { get { throw null; } set { } }
    }
    public partial class SqlDWSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public SqlDWSource() { }
        public System.BinaryData PartitionOption { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SqlPartitionSettings PartitionSettings { get { throw null; } set { } }
        public System.BinaryData SqlReaderQuery { get { throw null; } set { } }
        public System.BinaryData SqlReaderStoredProcedureName { get { throw null; } set { } }
        public System.BinaryData StoredProcedureParameters { get { throw null; } set { } }
    }
    public partial class SqlDWUpsertSettings
    {
        public SqlDWUpsertSettings() { }
        public System.BinaryData InterimSchemaName { get { throw null; } set { } }
        public System.BinaryData Keys { get { throw null; } set { } }
    }
    public partial class SqlMISink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public SqlMISink() { }
        public System.BinaryData PreCopyScript { get { throw null; } set { } }
        public System.BinaryData SqlWriterStoredProcedureName { get { throw null; } set { } }
        public System.BinaryData SqlWriterTableType { get { throw null; } set { } }
        public System.BinaryData SqlWriterUseTableLock { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DataFactory.Models.StoredProcedureParameter> StoredProcedureParameters { get { throw null; } }
        public System.BinaryData StoredProcedureTableTypeParameterName { get { throw null; } set { } }
        public System.BinaryData TableOption { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SqlUpsertSettings UpsertSettings { get { throw null; } set { } }
        public System.BinaryData WriteBehavior { get { throw null; } set { } }
    }
    public partial class SqlMISource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public SqlMISource() { }
        public System.BinaryData PartitionOption { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SqlPartitionSettings PartitionSettings { get { throw null; } set { } }
        public System.BinaryData ProduceAdditionalTypes { get { throw null; } set { } }
        public System.BinaryData SqlReaderQuery { get { throw null; } set { } }
        public System.BinaryData SqlReaderStoredProcedureName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DataFactory.Models.StoredProcedureParameter> StoredProcedureParameters { get { throw null; } }
    }
    public partial class SqlPartitionSettings
    {
        public SqlPartitionSettings() { }
        public System.BinaryData PartitionColumnName { get { throw null; } set { } }
        public System.BinaryData PartitionLowerBound { get { throw null; } set { } }
        public System.BinaryData PartitionUpperBound { get { throw null; } set { } }
    }
    public partial class SqlServerLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public SqlServerLinkedService(System.BinaryData connectionString) { }
        public Azure.ResourceManager.DataFactory.Models.SqlAlwaysEncryptedProperties AlwaysEncryptedSettings { get { throw null; } set { } }
        public System.BinaryData ConnectionString { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase Password { get { throw null; } set { } }
        public System.BinaryData UserName { get { throw null; } set { } }
    }
    public partial class SqlServerSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public SqlServerSink() { }
        public System.BinaryData PreCopyScript { get { throw null; } set { } }
        public System.BinaryData SqlWriterStoredProcedureName { get { throw null; } set { } }
        public System.BinaryData SqlWriterTableType { get { throw null; } set { } }
        public System.BinaryData SqlWriterUseTableLock { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DataFactory.Models.StoredProcedureParameter> StoredProcedureParameters { get { throw null; } }
        public System.BinaryData StoredProcedureTableTypeParameterName { get { throw null; } set { } }
        public System.BinaryData TableOption { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SqlUpsertSettings UpsertSettings { get { throw null; } set { } }
        public System.BinaryData WriteBehavior { get { throw null; } set { } }
    }
    public partial class SqlServerSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public SqlServerSource() { }
        public System.BinaryData PartitionOption { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SqlPartitionSettings PartitionSettings { get { throw null; } set { } }
        public System.BinaryData ProduceAdditionalTypes { get { throw null; } set { } }
        public System.BinaryData SqlReaderQuery { get { throw null; } set { } }
        public System.BinaryData SqlReaderStoredProcedureName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DataFactory.Models.StoredProcedureParameter> StoredProcedureParameters { get { throw null; } }
    }
    public partial class SqlServerStoredProcedureActivity : Azure.ResourceManager.DataFactory.Models.ExecutionActivity
    {
        public SqlServerStoredProcedureActivity(string name, System.BinaryData storedProcedureName) : base (default(string)) { }
        public System.BinaryData StoredProcedureName { get { throw null; } set { } }
        public System.BinaryData StoredProcedureParameters { get { throw null; } set { } }
    }
    public partial class SqlServerTableDataset : Azure.ResourceManager.DataFactory.Models.Dataset
    {
        public SqlServerTableDataset(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference)) { }
        public System.BinaryData SchemaTypePropertiesSchema { get { throw null; } set { } }
        public System.BinaryData Table { get { throw null; } set { } }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class SqlSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public SqlSink() { }
        public System.BinaryData PreCopyScript { get { throw null; } set { } }
        public System.BinaryData SqlWriterStoredProcedureName { get { throw null; } set { } }
        public System.BinaryData SqlWriterTableType { get { throw null; } set { } }
        public System.BinaryData SqlWriterUseTableLock { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DataFactory.Models.StoredProcedureParameter> StoredProcedureParameters { get { throw null; } }
        public System.BinaryData StoredProcedureTableTypeParameterName { get { throw null; } set { } }
        public System.BinaryData TableOption { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SqlUpsertSettings UpsertSettings { get { throw null; } set { } }
        public System.BinaryData WriteBehavior { get { throw null; } set { } }
    }
    public partial class SqlSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public SqlSource() { }
        public System.BinaryData IsolationLevel { get { throw null; } set { } }
        public System.BinaryData PartitionOption { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SqlPartitionSettings PartitionSettings { get { throw null; } set { } }
        public System.BinaryData SqlReaderQuery { get { throw null; } set { } }
        public System.BinaryData SqlReaderStoredProcedureName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DataFactory.Models.StoredProcedureParameter> StoredProcedureParameters { get { throw null; } }
    }
    public partial class SqlUpsertSettings
    {
        public SqlUpsertSettings() { }
        public System.BinaryData InterimSchemaName { get { throw null; } set { } }
        public System.BinaryData Keys { get { throw null; } set { } }
        public System.BinaryData UseTempDB { get { throw null; } set { } }
    }
    public partial class SquareLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public SquareLinkedService() { }
        public System.BinaryData ClientId { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase ClientSecret { get { throw null; } set { } }
        public System.BinaryData ConnectionProperties { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData Host { get { throw null; } set { } }
        public System.BinaryData RedirectUri { get { throw null; } set { } }
        public System.BinaryData UseEncryptedEndpoints { get { throw null; } set { } }
        public System.BinaryData UseHostVerification { get { throw null; } set { } }
        public System.BinaryData UsePeerVerification { get { throw null; } set { } }
    }
    public partial class SquareObjectDataset : Azure.ResourceManager.DataFactory.Models.Dataset
    {
        public SquareObjectDataset(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference)) { }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class SquareSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public SquareSource() { }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    public partial class SsisAccessCredential
    {
        public SsisAccessCredential(System.BinaryData domain, System.BinaryData userName, Azure.ResourceManager.DataFactory.Models.SecretBase password) { }
        public System.BinaryData Domain { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase Password { get { throw null; } set { } }
        public System.BinaryData UserName { get { throw null; } set { } }
    }
    public partial class SsisChildPackage
    {
        public SsisChildPackage(System.BinaryData packagePath, System.BinaryData packageContent) { }
        public System.BinaryData PackageContent { get { throw null; } set { } }
        public string PackageLastModifiedDate { get { throw null; } set { } }
        public string PackageName { get { throw null; } set { } }
        public System.BinaryData PackagePath { get { throw null; } set { } }
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
        public SsisExecutionCredential(System.BinaryData domain, System.BinaryData userName, Azure.ResourceManager.DataFactory.Models.SecureString password) { }
        public System.BinaryData Domain { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecureString Password { get { throw null; } set { } }
        public System.BinaryData UserName { get { throw null; } set { } }
    }
    public partial class SsisExecutionParameter
    {
        public SsisExecutionParameter(System.BinaryData value) { }
        public System.BinaryData Value { get { throw null; } set { } }
    }
    public partial class SsisFolder : Azure.ResourceManager.DataFactory.Models.SsisObjectMetadata
    {
        internal SsisFolder() { }
    }
    public partial class SsisLogLocation
    {
        public SsisLogLocation(System.BinaryData logPath, Azure.ResourceManager.DataFactory.Models.SsisLogLocationType locationType) { }
        public Azure.ResourceManager.DataFactory.Models.SsisAccessCredential AccessCredential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SsisLogLocationType LocationType { get { throw null; } set { } }
        public System.BinaryData LogPath { get { throw null; } set { } }
        public System.BinaryData LogRefreshInterval { get { throw null; } set { } }
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
    public partial class SsisObjectMetadata
    {
        internal SsisObjectMetadata() { }
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
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataFactory.Models.SsisParameter> Parameters { get { throw null; } }
        public long? ProjectId { get { throw null; } }
        public long? ProjectVersion { get { throw null; } }
    }
    public partial class SsisPackageLocation
    {
        public SsisPackageLocation() { }
        public Azure.ResourceManager.DataFactory.Models.SsisAccessCredential AccessCredential { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.SsisChildPackage> ChildPackages { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.SsisAccessCredential ConfigurationAccessCredential { get { throw null; } set { } }
        public System.BinaryData ConfigurationPath { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SsisPackageLocationType? LocationType { get { throw null; } set { } }
        public System.BinaryData PackageContent { get { throw null; } set { } }
        public string PackageLastModifiedDate { get { throw null; } set { } }
        public string PackageName { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase PackagePassword { get { throw null; } set { } }
        public System.BinaryData PackagePath { get { throw null; } set { } }
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
        public static Azure.ResourceManager.DataFactory.Models.SsisPackageLocationType Ssisdb { get { throw null; } }
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
    public partial class SsisParameter
    {
        internal SsisParameter() { }
        public string DataType { get { throw null; } }
        public string DefaultValue { get { throw null; } }
        public string Description { get { throw null; } }
        public string DesignDefaultValue { get { throw null; } }
        public long? Id { get { throw null; } }
        public string Name { get { throw null; } }
        public bool? Required { get { throw null; } }
        public bool? Sensitive { get { throw null; } }
        public string SensitiveDefaultValue { get { throw null; } }
        public bool? ValueSet { get { throw null; } }
        public string ValueType { get { throw null; } }
        public string Variable { get { throw null; } }
    }
    public partial class SsisProject : Azure.ResourceManager.DataFactory.Models.SsisObjectMetadata
    {
        internal SsisProject() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataFactory.Models.SsisEnvironmentReference> EnvironmentRefs { get { throw null; } }
        public long? FolderId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataFactory.Models.SsisParameter> Parameters { get { throw null; } }
        public long? Version { get { throw null; } }
    }
    public partial class SsisPropertyOverride
    {
        public SsisPropertyOverride(System.BinaryData value) { }
        public bool? IsSensitive { get { throw null; } set { } }
        public System.BinaryData Value { get { throw null; } set { } }
    }
    public partial class SsisVariable
    {
        internal SsisVariable() { }
        public string DataType { get { throw null; } }
        public string Description { get { throw null; } }
        public long? Id { get { throw null; } }
        public string Name { get { throw null; } }
        public bool? Sensitive { get { throw null; } }
        public string SensitiveValue { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class StagingSettings
    {
        public StagingSettings(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName) { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public System.BinaryData EnableCompression { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.LinkedServiceReference LinkedServiceName { get { throw null; } set { } }
        public System.BinaryData Path { get { throw null; } set { } }
    }
    public partial class StoredProcedureParameter
    {
        public StoredProcedureParameter() { }
        public Azure.ResourceManager.DataFactory.Models.StoredProcedureParameterType? ParameterType { get { throw null; } set { } }
        public System.BinaryData Value { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StoredProcedureParameterType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.StoredProcedureParameterType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StoredProcedureParameterType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.StoredProcedureParameterType Boolean { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.StoredProcedureParameterType Date { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.StoredProcedureParameterType Decimal { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.StoredProcedureParameterType Guid { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.StoredProcedureParameterType Int { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.StoredProcedureParameterType Int64 { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.StoredProcedureParameterType String { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.StoredProcedureParameterType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.StoredProcedureParameterType left, Azure.ResourceManager.DataFactory.Models.StoredProcedureParameterType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.StoredProcedureParameterType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.StoredProcedureParameterType left, Azure.ResourceManager.DataFactory.Models.StoredProcedureParameterType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StoreReadSettings
    {
        public StoreReadSettings() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public System.BinaryData DisableMetricsCollection { get { throw null; } set { } }
        public System.BinaryData MaxConcurrentConnections { get { throw null; } set { } }
    }
    public partial class StoreWriteSettings
    {
        public StoreWriteSettings() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public System.BinaryData CopyBehavior { get { throw null; } set { } }
        public System.BinaryData DisableMetricsCollection { get { throw null; } set { } }
        public System.BinaryData MaxConcurrentConnections { get { throw null; } set { } }
    }
    public partial class SubResourceDebugResource
    {
        public SubResourceDebugResource() { }
        public string Name { get { throw null; } set { } }
    }
    public partial class SwitchActivity : Azure.ResourceManager.DataFactory.Models.ControlActivity
    {
        public SwitchActivity(string name, Azure.ResourceManager.DataFactory.Models.Expression on) : base (default(string)) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.SwitchCase> Cases { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.DataFactoryPipelineActivity> DefaultActivities { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.Expression On { get { throw null; } set { } }
    }
    public partial class SwitchCase
    {
        public SwitchCase() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.DataFactoryPipelineActivity> Activities { get { throw null; } }
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
    public partial class SybaseLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public SybaseLinkedService(System.BinaryData server, System.BinaryData database) { }
        public Azure.ResourceManager.DataFactory.Models.SybaseAuthenticationType? AuthenticationType { get { throw null; } set { } }
        public System.BinaryData Database { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase Password { get { throw null; } set { } }
        public System.BinaryData Schema { get { throw null; } set { } }
        public System.BinaryData Server { get { throw null; } set { } }
        public System.BinaryData Username { get { throw null; } set { } }
    }
    public partial class SybaseSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public SybaseSource() { }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    public partial class SybaseTableDataset : Azure.ResourceManager.DataFactory.Models.Dataset
    {
        public SybaseTableDataset(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference)) { }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class TabularSource : Azure.ResourceManager.DataFactory.Models.CopySource
    {
        public TabularSource() { }
        public System.BinaryData AdditionalColumns { get { throw null; } set { } }
        public System.BinaryData QueryTimeout { get { throw null; } set { } }
    }
    public partial class TarGZipReadSettings : Azure.ResourceManager.DataFactory.Models.CompressionReadSettings
    {
        public TarGZipReadSettings() { }
        public System.BinaryData PreserveCompressionFileNameAsFolder { get { throw null; } set { } }
    }
    public partial class TarReadSettings : Azure.ResourceManager.DataFactory.Models.CompressionReadSettings
    {
        public TarReadSettings() { }
        public System.BinaryData PreserveCompressionFileNameAsFolder { get { throw null; } set { } }
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
    public partial class TeamDeskLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public TeamDeskLinkedService(Azure.ResourceManager.DataFactory.Models.TeamDeskAuthenticationType authenticationType, System.BinaryData uri) { }
        public Azure.ResourceManager.DataFactory.Models.SecretBase ApiToken { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.TeamDeskAuthenticationType AuthenticationType { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase Password { get { throw null; } set { } }
        public System.BinaryData Uri { get { throw null; } set { } }
        public System.BinaryData UserName { get { throw null; } set { } }
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
    public partial class TeradataLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public TeradataLinkedService() { }
        public Azure.ResourceManager.DataFactory.Models.TeradataAuthenticationType? AuthenticationType { get { throw null; } set { } }
        public System.BinaryData ConnectionString { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase Password { get { throw null; } set { } }
        public System.BinaryData Server { get { throw null; } set { } }
        public System.BinaryData Username { get { throw null; } set { } }
    }
    public partial class TeradataPartitionSettings
    {
        public TeradataPartitionSettings() { }
        public System.BinaryData PartitionColumnName { get { throw null; } set { } }
        public System.BinaryData PartitionLowerBound { get { throw null; } set { } }
        public System.BinaryData PartitionUpperBound { get { throw null; } set { } }
    }
    public partial class TeradataSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public TeradataSource() { }
        public System.BinaryData PartitionOption { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.TeradataPartitionSettings PartitionSettings { get { throw null; } set { } }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    public partial class TeradataTableDataset : Azure.ResourceManager.DataFactory.Models.Dataset
    {
        public TeradataTableDataset(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference)) { }
        public System.BinaryData Database { get { throw null; } set { } }
        public System.BinaryData Table { get { throw null; } set { } }
    }
    public partial class TextFormat : Azure.ResourceManager.DataFactory.Models.DatasetStorageFormat
    {
        public TextFormat() { }
        public System.BinaryData ColumnDelimiter { get { throw null; } set { } }
        public System.BinaryData EncodingName { get { throw null; } set { } }
        public System.BinaryData EscapeChar { get { throw null; } set { } }
        public System.BinaryData FirstRowAsHeader { get { throw null; } set { } }
        public System.BinaryData NullValue { get { throw null; } set { } }
        public System.BinaryData QuoteChar { get { throw null; } set { } }
        public System.BinaryData RowDelimiter { get { throw null; } set { } }
        public System.BinaryData SkipLineCount { get { throw null; } set { } }
        public System.BinaryData TreatEmptyAsNull { get { throw null; } set { } }
    }
    public partial class Transformation
    {
        public Transformation(string name) { }
        public Azure.ResourceManager.DataFactory.Models.DatasetReference Dataset { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DataFlowReference Flowlet { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.LinkedServiceReference LinkedService { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    public partial class TriggerDependencyReference : Azure.ResourceManager.DataFactory.Models.DependencyReference
    {
        public TriggerDependencyReference(Azure.ResourceManager.DataFactory.Models.TriggerReference referenceTrigger) { }
        public Azure.ResourceManager.DataFactory.Models.TriggerReference ReferenceTrigger { get { throw null; } set { } }
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
        public Azure.ResourceManager.DataFactory.Models.PipelineReference PipelineReference { get { throw null; } set { } }
    }
    public partial class TriggerReference
    {
        public TriggerReference(Azure.ResourceManager.DataFactory.Models.TriggerReferenceType referenceType, string referenceName) { }
        public string ReferenceName { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.TriggerReferenceType ReferenceType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TriggerReferenceType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.TriggerReferenceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TriggerReferenceType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.TriggerReferenceType TriggerReference { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.TriggerReferenceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.TriggerReferenceType left, Azure.ResourceManager.DataFactory.Models.TriggerReferenceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.TriggerReferenceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.TriggerReferenceType left, Azure.ResourceManager.DataFactory.Models.TriggerReferenceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TriggerRun
    {
        internal TriggerRun() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> DependencyStatus { get { throw null; } }
        public string Message { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Properties { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> RunDimension { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.TriggerRunStatus? Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> TriggeredPipelines { get { throw null; } }
        public string TriggerName { get { throw null; } }
        public string TriggerRunId { get { throw null; } }
        public System.DateTimeOffset? TriggerRunTimestamp { get { throw null; } }
        public string TriggerType { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TriggerRunStatus : System.IEquatable<Azure.ResourceManager.DataFactory.Models.TriggerRunStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TriggerRunStatus(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.TriggerRunStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.TriggerRunStatus Inprogress { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.TriggerRunStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.TriggerRunStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.TriggerRunStatus left, Azure.ResourceManager.DataFactory.Models.TriggerRunStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.TriggerRunStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.TriggerRunStatus left, Azure.ResourceManager.DataFactory.Models.TriggerRunStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TriggerRuntimeState : System.IEquatable<Azure.ResourceManager.DataFactory.Models.TriggerRuntimeState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TriggerRuntimeState(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.TriggerRuntimeState Disabled { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.TriggerRuntimeState Started { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.TriggerRuntimeState Stopped { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.TriggerRuntimeState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.TriggerRuntimeState left, Azure.ResourceManager.DataFactory.Models.TriggerRuntimeState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.TriggerRuntimeState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.TriggerRuntimeState left, Azure.ResourceManager.DataFactory.Models.TriggerRuntimeState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TriggerSubscriptionOperationStatus
    {
        internal TriggerSubscriptionOperationStatus() { }
        public Azure.ResourceManager.DataFactory.Models.EventSubscriptionStatus? Status { get { throw null; } }
        public string TriggerName { get { throw null; } }
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
        public System.BinaryData Delay { get { throw null; } set { } }
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
        public TumblingWindowTriggerDependencyReference(Azure.ResourceManager.DataFactory.Models.TriggerReference referenceTrigger) : base (default(Azure.ResourceManager.DataFactory.Models.TriggerReference)) { }
        public string Offset { get { throw null; } set { } }
        public string Size { get { throw null; } set { } }
    }
    public partial class TwilioLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public TwilioLinkedService(System.BinaryData userName, Azure.ResourceManager.DataFactory.Models.SecretBase password) { }
        public Azure.ResourceManager.DataFactory.Models.SecretBase Password { get { throw null; } set { } }
        public System.BinaryData UserName { get { throw null; } set { } }
    }
    public partial class UntilActivity : Azure.ResourceManager.DataFactory.Models.ControlActivity
    {
        public UntilActivity(string name, Azure.ResourceManager.DataFactory.Models.Expression expression, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataFactory.Models.DataFactoryPipelineActivity> activities) : base (default(string)) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.DataFactoryPipelineActivity> Activities { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.Expression Expression { get { throw null; } set { } }
        public System.BinaryData Timeout { get { throw null; } set { } }
    }
    public partial class UpdateIntegrationRuntimeNodeContent
    {
        public UpdateIntegrationRuntimeNodeContent() { }
        public int? ConcurrentJobsLimit { get { throw null; } set { } }
    }
    public partial class UserAccessPolicy
    {
        public UserAccessPolicy() { }
        public string AccessResourcePath { get { throw null; } set { } }
        public string ExpireTime { get { throw null; } set { } }
        public string Permissions { get { throw null; } set { } }
        public string ProfileName { get { throw null; } set { } }
        public string StartTime { get { throw null; } set { } }
    }
    public partial class UserProperty
    {
        public UserProperty(string name, System.BinaryData value) { }
        public string Name { get { throw null; } set { } }
        public System.BinaryData Value { get { throw null; } set { } }
    }
    public partial class ValidationActivity : Azure.ResourceManager.DataFactory.Models.ControlActivity
    {
        public ValidationActivity(string name, Azure.ResourceManager.DataFactory.Models.DatasetReference dataset) : base (default(string)) { }
        public System.BinaryData ChildItems { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DatasetReference Dataset { get { throw null; } set { } }
        public System.BinaryData MinimumSize { get { throw null; } set { } }
        public System.BinaryData Sleep { get { throw null; } set { } }
        public System.BinaryData Timeout { get { throw null; } set { } }
    }
    public partial class VariableSpecification
    {
        public VariableSpecification(Azure.ResourceManager.DataFactory.Models.VariableType variableType) { }
        public System.BinaryData DefaultValue { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.VariableType VariableType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VariableType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.VariableType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VariableType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.VariableType Array { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.VariableType Bool { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.VariableType String { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.VariableType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.VariableType left, Azure.ResourceManager.DataFactory.Models.VariableType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.VariableType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.VariableType left, Azure.ResourceManager.DataFactory.Models.VariableType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VerticaLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public VerticaLinkedService() { }
        public System.BinaryData ConnectionString { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.AzureKeyVaultSecretReference Pwd { get { throw null; } set { } }
    }
    public partial class VerticaSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public VerticaSource() { }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    public partial class VerticaTableDataset : Azure.ResourceManager.DataFactory.Models.Dataset
    {
        public VerticaTableDataset(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference)) { }
        public System.BinaryData SchemaTypePropertiesSchema { get { throw null; } set { } }
        public System.BinaryData Table { get { throw null; } set { } }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class WaitActivity : Azure.ResourceManager.DataFactory.Models.ControlActivity
    {
        public WaitActivity(string name, System.BinaryData waitTimeInSeconds) : base (default(string)) { }
        public System.BinaryData WaitTimeInSeconds { get { throw null; } set { } }
    }
    public partial class WebActivity : Azure.ResourceManager.DataFactory.Models.ExecutionActivity
    {
        public WebActivity(string name, Azure.ResourceManager.DataFactory.Models.WebActivityMethod method, System.BinaryData uri) : base (default(string)) { }
        public Azure.ResourceManager.DataFactory.Models.WebActivityAuthentication Authentication { get { throw null; } set { } }
        public System.BinaryData Body { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeReference ConnectVia { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.DatasetReference> Datasets { get { throw null; } }
        public bool? DisableCertValidation { get { throw null; } set { } }
        public System.BinaryData Headers { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.LinkedServiceReference> LinkedServices { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.WebActivityMethod Method { get { throw null; } set { } }
        public System.BinaryData Uri { get { throw null; } set { } }
    }
    public partial class WebActivityAuthentication
    {
        public WebActivityAuthentication() { }
        public Azure.ResourceManager.DataFactory.Models.CredentialReference Credential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase Password { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase Pfx { get { throw null; } set { } }
        public System.BinaryData Resource { get { throw null; } set { } }
        public System.BinaryData Username { get { throw null; } set { } }
        public System.BinaryData UserTenant { get { throw null; } set { } }
        public string WebActivityAuthenticationType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WebActivityMethod : System.IEquatable<Azure.ResourceManager.DataFactory.Models.WebActivityMethod>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WebActivityMethod(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.WebActivityMethod Delete { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.WebActivityMethod GET { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.WebActivityMethod Post { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.WebActivityMethod PUT { get { throw null; } }
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
        public WebAnonymousAuthentication(System.BinaryData uri) : base (default(System.BinaryData)) { }
    }
    public partial class WebBasicAuthentication : Azure.ResourceManager.DataFactory.Models.WebLinkedServiceTypeProperties
    {
        public WebBasicAuthentication(System.BinaryData uri, System.BinaryData username, Azure.ResourceManager.DataFactory.Models.SecretBase password) : base (default(System.BinaryData)) { }
        public Azure.ResourceManager.DataFactory.Models.SecretBase Password { get { throw null; } set { } }
        public System.BinaryData Username { get { throw null; } set { } }
    }
    public partial class WebClientCertificateAuthentication : Azure.ResourceManager.DataFactory.Models.WebLinkedServiceTypeProperties
    {
        public WebClientCertificateAuthentication(System.BinaryData uri, Azure.ResourceManager.DataFactory.Models.SecretBase pfx, Azure.ResourceManager.DataFactory.Models.SecretBase password) : base (default(System.BinaryData)) { }
        public Azure.ResourceManager.DataFactory.Models.SecretBase Password { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase Pfx { get { throw null; } set { } }
    }
    public partial class WebHookActivity : Azure.ResourceManager.DataFactory.Models.ControlActivity
    {
        public WebHookActivity(string name, Azure.ResourceManager.DataFactory.Models.WebHookActivityMethod method, System.BinaryData uri) : base (default(string)) { }
        public Azure.ResourceManager.DataFactory.Models.WebActivityAuthentication Authentication { get { throw null; } set { } }
        public System.BinaryData Body { get { throw null; } set { } }
        public System.BinaryData Headers { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.WebHookActivityMethod Method { get { throw null; } set { } }
        public System.BinaryData ReportStatusOnCallBack { get { throw null; } set { } }
        public string Timeout { get { throw null; } set { } }
        public System.BinaryData Uri { get { throw null; } set { } }
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
    public partial class WebLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public WebLinkedService(Azure.ResourceManager.DataFactory.Models.WebLinkedServiceTypeProperties typeProperties) { }
        public Azure.ResourceManager.DataFactory.Models.WebLinkedServiceTypeProperties TypeProperties { get { throw null; } set { } }
    }
    public partial class WebLinkedServiceTypeProperties
    {
        public WebLinkedServiceTypeProperties(System.BinaryData uri) { }
        public System.BinaryData Uri { get { throw null; } set { } }
    }
    public partial class WebSource : Azure.ResourceManager.DataFactory.Models.CopySource
    {
        public WebSource() { }
        public System.BinaryData AdditionalColumns { get { throw null; } set { } }
    }
    public partial class WebTableDataset : Azure.ResourceManager.DataFactory.Models.Dataset
    {
        public WebTableDataset(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName, System.BinaryData index) : base (default(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference)) { }
        public System.BinaryData Index { get { throw null; } set { } }
        public System.BinaryData Path { get { throw null; } set { } }
    }
    public partial class WranglingDataFlow : Azure.ResourceManager.DataFactory.Models.DataFlow
    {
        public WranglingDataFlow() { }
        public string DocumentLocale { get { throw null; } set { } }
        public string Script { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.PowerQuerySource> Sources { get { throw null; } }
    }
    public partial class XeroLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public XeroLinkedService() { }
        public System.BinaryData ConnectionProperties { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase ConsumerKey { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData Host { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase PrivateKey { get { throw null; } set { } }
        public System.BinaryData UseEncryptedEndpoints { get { throw null; } set { } }
        public System.BinaryData UseHostVerification { get { throw null; } set { } }
        public System.BinaryData UsePeerVerification { get { throw null; } set { } }
    }
    public partial class XeroObjectDataset : Azure.ResourceManager.DataFactory.Models.Dataset
    {
        public XeroObjectDataset(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference)) { }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class XeroSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public XeroSource() { }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    public partial class XmlDataset : Azure.ResourceManager.DataFactory.Models.Dataset
    {
        public XmlDataset(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference)) { }
        public Azure.ResourceManager.DataFactory.Models.DatasetCompression Compression { get { throw null; } set { } }
        public System.BinaryData EncodingName { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DatasetLocation Location { get { throw null; } set { } }
        public System.BinaryData NullValue { get { throw null; } set { } }
    }
    public partial class XmlReadSettings : Azure.ResourceManager.DataFactory.Models.FormatReadSettings
    {
        public XmlReadSettings() { }
        public Azure.ResourceManager.DataFactory.Models.CompressionReadSettings CompressionProperties { get { throw null; } set { } }
        public System.BinaryData DetectDataType { get { throw null; } set { } }
        public System.BinaryData NamespacePrefixes { get { throw null; } set { } }
        public System.BinaryData Namespaces { get { throw null; } set { } }
        public System.BinaryData ValidationMode { get { throw null; } set { } }
    }
    public partial class XmlSource : Azure.ResourceManager.DataFactory.Models.CopySource
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
    public partial class ZendeskLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public ZendeskLinkedService(Azure.ResourceManager.DataFactory.Models.ZendeskAuthenticationType authenticationType, System.BinaryData uri) { }
        public Azure.ResourceManager.DataFactory.Models.SecretBase ApiToken { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.ZendeskAuthenticationType AuthenticationType { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SecretBase Password { get { throw null; } set { } }
        public System.BinaryData Uri { get { throw null; } set { } }
        public System.BinaryData UserName { get { throw null; } set { } }
    }
    public partial class ZipDeflateReadSettings : Azure.ResourceManager.DataFactory.Models.CompressionReadSettings
    {
        public ZipDeflateReadSettings() { }
        public System.BinaryData PreserveZipFileNameAsFolder { get { throw null; } set { } }
    }
    public partial class ZohoLinkedService : Azure.ResourceManager.DataFactory.Models.LinkedService
    {
        public ZohoLinkedService() { }
        public Azure.ResourceManager.DataFactory.Models.SecretBase AccessToken { get { throw null; } set { } }
        public System.BinaryData ConnectionProperties { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData Endpoint { get { throw null; } set { } }
        public System.BinaryData UseEncryptedEndpoints { get { throw null; } set { } }
        public System.BinaryData UseHostVerification { get { throw null; } set { } }
        public System.BinaryData UsePeerVerification { get { throw null; } set { } }
    }
    public partial class ZohoObjectDataset : Azure.ResourceManager.DataFactory.Models.Dataset
    {
        public ZohoObjectDataset(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.LinkedServiceReference)) { }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class ZohoSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public ZohoSource() { }
        public System.BinaryData Query { get { throw null; } set { } }
    }
}
