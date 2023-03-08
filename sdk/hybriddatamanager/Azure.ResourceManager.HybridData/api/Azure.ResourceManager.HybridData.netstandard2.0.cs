namespace Azure.ResourceManager.HybridData
{
    public static partial class HybridDataExtensions
    {
        public static Azure.ResourceManager.HybridData.HybridDataJobDefinitionResource GetHybridDataJobDefinitionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HybridData.HybridDataJobResource GetHybridDataJobResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.HybridData.HybridDataManagerResource> GetHybridDataManager(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string dataManagerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridData.HybridDataManagerResource>> GetHybridDataManagerAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string dataManagerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.HybridData.HybridDataManagerResource GetHybridDataManagerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HybridData.HybridDataManagerCollection GetHybridDataManagers(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.HybridData.HybridDataManagerResource> GetHybridDataManagers(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.HybridData.HybridDataManagerResource> GetHybridDataManagersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.HybridData.HybridDataPublicKeyResource GetHybridDataPublicKeyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HybridData.HybridDataServiceResource GetHybridDataServiceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HybridData.HybridDataStoreResource GetHybridDataStoreResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HybridData.HybridDataStoreTypeResource GetHybridDataStoreTypeResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class HybridDataJobCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridData.HybridDataJobResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridData.HybridDataJobResource>, System.Collections.IEnumerable
    {
        protected HybridDataJobCollection() { }
        public virtual Azure.Response<bool> Exists(string jobId, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string jobId, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridData.HybridDataJobResource> Get(string jobId, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HybridData.HybridDataJobResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HybridData.HybridDataJobResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridData.HybridDataJobResource>> GetAsync(string jobId, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HybridData.HybridDataJobResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridData.HybridDataJobResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HybridData.HybridDataJobResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridData.HybridDataJobResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HybridDataJobData : Azure.ResourceManager.Models.ResourceData
    {
        public HybridDataJobData(Azure.ResourceManager.HybridData.Models.HybridDataJobStatus status, System.DateTimeOffset startOn, Azure.ResourceManager.HybridData.Models.JobCancellationSetting isCancellable) { }
        public long? BytesProcessed { get { throw null; } set { } }
        public string DataSinkName { get { throw null; } set { } }
        public string DataSourceName { get { throw null; } set { } }
        public Azure.ResourceManager.HybridData.Models.HybridDataJobDetails Details { get { throw null; } set { } }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public Azure.ResourceManager.HybridData.Models.HybridDataJobTopLevelError Error { get { throw null; } set { } }
        public Azure.ResourceManager.HybridData.Models.JobCancellationSetting IsCancellable { get { throw null; } set { } }
        public long? ItemsProcessed { get { throw null; } set { } }
        public System.DateTimeOffset StartOn { get { throw null; } set { } }
        public Azure.ResourceManager.HybridData.Models.HybridDataJobStatus Status { get { throw null; } set { } }
        public long? TotalBytesToProcess { get { throw null; } set { } }
        public long? TotalItemsToProcess { get { throw null; } set { } }
    }
    public partial class HybridDataJobDefinitionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridData.HybridDataJobDefinitionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridData.HybridDataJobDefinitionResource>, System.Collections.IEnumerable
    {
        protected HybridDataJobDefinitionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridData.HybridDataJobDefinitionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string jobDefinitionName, Azure.ResourceManager.HybridData.HybridDataJobDefinitionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridData.HybridDataJobDefinitionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string jobDefinitionName, Azure.ResourceManager.HybridData.HybridDataJobDefinitionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string jobDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string jobDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridData.HybridDataJobDefinitionResource> Get(string jobDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HybridData.HybridDataJobDefinitionResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HybridData.HybridDataJobDefinitionResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridData.HybridDataJobDefinitionResource>> GetAsync(string jobDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HybridData.HybridDataJobDefinitionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridData.HybridDataJobDefinitionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HybridData.HybridDataJobDefinitionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridData.HybridDataJobDefinitionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HybridDataJobDefinitionData : Azure.ResourceManager.Models.ResourceData
    {
        public HybridDataJobDefinitionData(string dataSourceId, string dataSinkId, Azure.ResourceManager.HybridData.Models.HybridDataState state) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.HybridData.Models.HybridDataCustomerSecret> CustomerSecrets { get { throw null; } }
        public System.BinaryData DataServiceInput { get { throw null; } set { } }
        public string DataSinkId { get { throw null; } set { } }
        public string DataSourceId { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } set { } }
        public Azure.ResourceManager.HybridData.Models.HybridDataJobRunLocation? RunLocation { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HybridData.Models.HybridDataJobRunSchedule> Schedules { get { throw null; } }
        public Azure.ResourceManager.HybridData.Models.HybridDataState State { get { throw null; } set { } }
        public Azure.ResourceManager.HybridData.Models.UserConfirmationSetting? UserConfirmation { get { throw null; } set { } }
    }
    public partial class HybridDataJobDefinitionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HybridDataJobDefinitionResource() { }
        public virtual Azure.ResourceManager.HybridData.HybridDataJobDefinitionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string dataManagerName, string dataServiceName, string jobDefinitionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridData.HybridDataJobDefinitionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridData.HybridDataJobDefinitionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridData.HybridDataJobResource> GetHybridDataJob(string jobId, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridData.HybridDataJobResource>> GetHybridDataJobAsync(string jobId, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HybridData.HybridDataJobCollection GetHybridDataJobs() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Run(Azure.WaitUntil waitUntil, Azure.ResourceManager.HybridData.Models.HybridDataJobRunContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RunAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HybridData.Models.HybridDataJobRunContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridData.HybridDataJobDefinitionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.HybridData.HybridDataJobDefinitionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridData.HybridDataJobDefinitionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HybridData.HybridDataJobDefinitionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HybridDataJobResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HybridDataJobResource() { }
        public virtual Azure.ResourceManager.HybridData.HybridDataJobData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation Cancel(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> CancelAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string dataManagerName, string dataServiceName, string jobDefinitionName, string jobId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridData.HybridDataJobResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridData.HybridDataJobResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Resume(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ResumeAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HybridDataManagerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridData.HybridDataManagerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridData.HybridDataManagerResource>, System.Collections.IEnumerable
    {
        protected HybridDataManagerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridData.HybridDataManagerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string dataManagerName, Azure.ResourceManager.HybridData.HybridDataManagerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridData.HybridDataManagerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string dataManagerName, Azure.ResourceManager.HybridData.HybridDataManagerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string dataManagerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string dataManagerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridData.HybridDataManagerResource> Get(string dataManagerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HybridData.HybridDataManagerResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HybridData.HybridDataManagerResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridData.HybridDataManagerResource>> GetAsync(string dataManagerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HybridData.HybridDataManagerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridData.HybridDataManagerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HybridData.HybridDataManagerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridData.HybridDataManagerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HybridDataManagerData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public HybridDataManagerData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.HybridData.Models.HybridDataSku Sku { get { throw null; } set { } }
    }
    public partial class HybridDataManagerResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HybridDataManagerResource() { }
        public virtual Azure.ResourceManager.HybridData.HybridDataManagerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.HybridData.HybridDataManagerResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridData.HybridDataManagerResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string dataManagerName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridData.HybridDataManagerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridData.HybridDataManagerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridData.HybridDataPublicKeyResource> GetHybridDataPublicKey(string publicKeyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridData.HybridDataPublicKeyResource>> GetHybridDataPublicKeyAsync(string publicKeyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HybridData.HybridDataPublicKeyCollection GetHybridDataPublicKeys() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridData.HybridDataServiceResource> GetHybridDataService(string dataServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridData.HybridDataServiceResource>> GetHybridDataServiceAsync(string dataServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HybridData.HybridDataServiceCollection GetHybridDataServices() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridData.HybridDataStoreResource> GetHybridDataStore(string dataStoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridData.HybridDataStoreResource>> GetHybridDataStoreAsync(string dataStoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HybridData.HybridDataStoreCollection GetHybridDataStores() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridData.HybridDataStoreTypeResource> GetHybridDataStoreType(string dataStoreTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridData.HybridDataStoreTypeResource>> GetHybridDataStoreTypeAsync(string dataStoreTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HybridData.HybridDataStoreTypeCollection GetHybridDataStoreTypes() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HybridData.HybridDataJobDefinitionResource> GetJobDefinitions(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HybridData.HybridDataJobDefinitionResource> GetJobDefinitionsAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HybridData.HybridDataJobResource> GetJobs(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HybridData.HybridDataJobResource> GetJobsAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridData.HybridDataManagerResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridData.HybridDataManagerResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridData.HybridDataManagerResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridData.HybridDataManagerResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridData.HybridDataManagerResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.HybridData.Models.HybridDataManagerPatch patch, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridData.HybridDataManagerResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HybridData.Models.HybridDataManagerPatch patch, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HybridDataPublicKeyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridData.HybridDataPublicKeyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridData.HybridDataPublicKeyResource>, System.Collections.IEnumerable
    {
        protected HybridDataPublicKeyCollection() { }
        public virtual Azure.Response<bool> Exists(string publicKeyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string publicKeyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridData.HybridDataPublicKeyResource> Get(string publicKeyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HybridData.HybridDataPublicKeyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HybridData.HybridDataPublicKeyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridData.HybridDataPublicKeyResource>> GetAsync(string publicKeyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HybridData.HybridDataPublicKeyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridData.HybridDataPublicKeyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HybridData.HybridDataPublicKeyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridData.HybridDataPublicKeyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HybridDataPublicKeyData : Azure.ResourceManager.Models.ResourceData
    {
        public HybridDataPublicKeyData(Azure.ResourceManager.HybridData.Models.HybridDataEncryptionKey dataServiceLevel1Key, Azure.ResourceManager.HybridData.Models.HybridDataEncryptionKey dataServiceLevel2Key) { }
        public Azure.ResourceManager.HybridData.Models.HybridDataEncryptionKey DataServiceLevel1Key { get { throw null; } set { } }
        public Azure.ResourceManager.HybridData.Models.HybridDataEncryptionKey DataServiceLevel2Key { get { throw null; } set { } }
    }
    public partial class HybridDataPublicKeyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HybridDataPublicKeyResource() { }
        public virtual Azure.ResourceManager.HybridData.HybridDataPublicKeyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string dataManagerName, string publicKeyName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridData.HybridDataPublicKeyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridData.HybridDataPublicKeyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HybridDataServiceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridData.HybridDataServiceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridData.HybridDataServiceResource>, System.Collections.IEnumerable
    {
        protected HybridDataServiceCollection() { }
        public virtual Azure.Response<bool> Exists(string dataServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string dataServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridData.HybridDataServiceResource> Get(string dataServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HybridData.HybridDataServiceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HybridData.HybridDataServiceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridData.HybridDataServiceResource>> GetAsync(string dataServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HybridData.HybridDataServiceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridData.HybridDataServiceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HybridData.HybridDataServiceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridData.HybridDataServiceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HybridDataServiceData : Azure.ResourceManager.Models.ResourceData
    {
        public HybridDataServiceData(Azure.ResourceManager.HybridData.Models.HybridDataState state) { }
        public Azure.ResourceManager.HybridData.Models.HybridDataState State { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SupportedDataSinkTypes { get { throw null; } }
        public System.Collections.Generic.IList<string> SupportedDataSourceTypes { get { throw null; } }
    }
    public partial class HybridDataServiceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HybridDataServiceResource() { }
        public virtual Azure.ResourceManager.HybridData.HybridDataServiceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string dataManagerName, string dataServiceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridData.HybridDataServiceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridData.HybridDataServiceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridData.HybridDataJobDefinitionResource> GetHybridDataJobDefinition(string jobDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridData.HybridDataJobDefinitionResource>> GetHybridDataJobDefinitionAsync(string jobDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HybridData.HybridDataJobDefinitionCollection GetHybridDataJobDefinitions() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HybridData.HybridDataJobResource> GetJobs(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HybridData.HybridDataJobResource> GetJobsAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HybridDataStoreCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridData.HybridDataStoreResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridData.HybridDataStoreResource>, System.Collections.IEnumerable
    {
        protected HybridDataStoreCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridData.HybridDataStoreResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string dataStoreName, Azure.ResourceManager.HybridData.HybridDataStoreData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridData.HybridDataStoreResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string dataStoreName, Azure.ResourceManager.HybridData.HybridDataStoreData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string dataStoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string dataStoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridData.HybridDataStoreResource> Get(string dataStoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HybridData.HybridDataStoreResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HybridData.HybridDataStoreResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridData.HybridDataStoreResource>> GetAsync(string dataStoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HybridData.HybridDataStoreResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridData.HybridDataStoreResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HybridData.HybridDataStoreResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridData.HybridDataStoreResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HybridDataStoreData : Azure.ResourceManager.Models.ResourceData
    {
        public HybridDataStoreData(Azure.ResourceManager.HybridData.Models.HybridDataState state, Azure.Core.ResourceIdentifier dataStoreTypeId) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.HybridData.Models.HybridDataCustomerSecret> CustomerSecrets { get { throw null; } }
        public Azure.Core.ResourceIdentifier DataStoreTypeId { get { throw null; } set { } }
        public System.BinaryData ExtendedProperties { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier RepositoryId { get { throw null; } set { } }
        public Azure.ResourceManager.HybridData.Models.HybridDataState State { get { throw null; } set { } }
    }
    public partial class HybridDataStoreResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HybridDataStoreResource() { }
        public virtual Azure.ResourceManager.HybridData.HybridDataStoreData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string dataManagerName, string dataStoreName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridData.HybridDataStoreResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridData.HybridDataStoreResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridData.HybridDataStoreResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.HybridData.HybridDataStoreData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridData.HybridDataStoreResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HybridData.HybridDataStoreData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HybridDataStoreTypeCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridData.HybridDataStoreTypeResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridData.HybridDataStoreTypeResource>, System.Collections.IEnumerable
    {
        protected HybridDataStoreTypeCollection() { }
        public virtual Azure.Response<bool> Exists(string dataStoreTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string dataStoreTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridData.HybridDataStoreTypeResource> Get(string dataStoreTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HybridData.HybridDataStoreTypeResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HybridData.HybridDataStoreTypeResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridData.HybridDataStoreTypeResource>> GetAsync(string dataStoreTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HybridData.HybridDataStoreTypeResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridData.HybridDataStoreTypeResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HybridData.HybridDataStoreTypeResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridData.HybridDataStoreTypeResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HybridDataStoreTypeData : Azure.ResourceManager.Models.ResourceData
    {
        public HybridDataStoreTypeData(Azure.ResourceManager.HybridData.Models.HybridDataState state) { }
        public Azure.Core.ResourceType? RepositoryType { get { throw null; } set { } }
        public Azure.ResourceManager.HybridData.Models.HybridDataState State { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SupportedDataServicesAsSink { get { throw null; } }
        public System.Collections.Generic.IList<string> SupportedDataServicesAsSource { get { throw null; } }
    }
    public partial class HybridDataStoreTypeResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HybridDataStoreTypeResource() { }
        public virtual Azure.ResourceManager.HybridData.HybridDataStoreTypeData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string dataManagerName, string dataStoreTypeName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridData.HybridDataStoreTypeResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridData.HybridDataStoreTypeResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.HybridData.Mock
{
    public partial class HybridDataManagerResourceExtensionClient : Azure.ResourceManager.ArmResource
    {
        protected HybridDataManagerResourceExtensionClient() { }
        public virtual Azure.Pageable<Azure.ResourceManager.HybridData.HybridDataManagerResource> GetHybridDataManagers(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HybridData.HybridDataManagerResource> GetHybridDataManagersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ResourceGroupResourceExtensionClient : Azure.ResourceManager.ArmResource
    {
        protected ResourceGroupResourceExtensionClient() { }
        public virtual Azure.ResourceManager.HybridData.HybridDataManagerCollection GetHybridDataManagers() { throw null; }
    }
}
namespace Azure.ResourceManager.HybridData.Models
{
    public partial class HybridDataCustomerSecret
    {
        public HybridDataCustomerSecret(string keyIdentifier, string keyValue, Azure.ResourceManager.HybridData.Models.SupportedEncryptionAlgorithm algorithm) { }
        public Azure.ResourceManager.HybridData.Models.SupportedEncryptionAlgorithm Algorithm { get { throw null; } set { } }
        public string KeyIdentifier { get { throw null; } set { } }
        public string KeyValue { get { throw null; } set { } }
    }
    public partial class HybridDataEncryptionKey
    {
        public HybridDataEncryptionKey(string keyModulus, string keyExponent, int encryptionChunkSizeInBytes) { }
        public int EncryptionChunkSizeInBytes { get { throw null; } set { } }
        public string KeyExponent { get { throw null; } set { } }
        public string KeyModulus { get { throw null; } set { } }
    }
    public partial class HybridDataJobDetails
    {
        public HybridDataJobDetails() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.HybridData.Models.HybridDataJobErrorDetails> ErrorDetails { get { throw null; } }
        public string ItemDetailsLink { get { throw null; } set { } }
        public Azure.ResourceManager.HybridData.HybridDataJobDefinitionData JobDefinition { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HybridData.Models.HybridDataJobStage> JobStages { get { throw null; } }
    }
    public partial class HybridDataJobErrorDetails
    {
        public HybridDataJobErrorDetails() { }
        public int? ErrorCode { get { throw null; } set { } }
        public string ErrorMessage { get { throw null; } set { } }
        public string ExceptionMessage { get { throw null; } set { } }
        public string RecommendedAction { get { throw null; } set { } }
    }
    public partial class HybridDataJobRunContent
    {
        public HybridDataJobRunContent() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.HybridData.Models.HybridDataCustomerSecret> CustomerSecrets { get { throw null; } }
        public System.BinaryData DataServiceInput { get { throw null; } set { } }
        public Azure.ResourceManager.HybridData.Models.UserConfirmationSetting? UserConfirmation { get { throw null; } set { } }
    }
    public enum HybridDataJobRunLocation
    {
        None = 0,
        AustraliaEast = 1,
        AustraliaSoutheast = 2,
        BrazilSouth = 3,
        CanadaCentral = 4,
        CanadaEast = 5,
        CentralIndia = 6,
        CentralUS = 7,
        EastAsia = 8,
        EastUS = 9,
        EastUS2 = 10,
        JapanEast = 11,
        JapanWest = 12,
        KoreaCentral = 13,
        KoreaSouth = 14,
        SoutheastAsia = 15,
        SouthCentralUS = 16,
        SouthIndia = 17,
        NorthCentralUS = 18,
        NorthEurope = 19,
        UKSouth = 20,
        UKWest = 21,
        WestCentralUS = 22,
        WestEurope = 23,
        WestIndia = 24,
        WestUS = 25,
        WestUS2 = 26,
    }
    public partial class HybridDataJobRunSchedule
    {
        public HybridDataJobRunSchedule() { }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> PolicyList { get { throw null; } }
    }
    public partial class HybridDataJobStage
    {
        public HybridDataJobStage(Azure.ResourceManager.HybridData.Models.HybridDataJobStatus stageStatus) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.HybridData.Models.HybridDataJobErrorDetails> ErrorDetails { get { throw null; } }
        public System.BinaryData JobStageDetails { get { throw null; } set { } }
        public string StageName { get { throw null; } set { } }
        public Azure.ResourceManager.HybridData.Models.HybridDataJobStatus StageStatus { get { throw null; } set { } }
    }
    public enum HybridDataJobStatus
    {
        None = 0,
        InProgress = 1,
        Succeeded = 2,
        WaitingForAction = 3,
        Failed = 4,
        Cancelled = 5,
        Cancelling = 6,
        PartiallySucceeded = 7,
    }
    public partial class HybridDataJobTopLevelError
    {
        public HybridDataJobTopLevelError(string code) { }
        public string Code { get { throw null; } set { } }
        public string Message { get { throw null; } set { } }
    }
    public partial class HybridDataManagerPatch
    {
        public HybridDataManagerPatch() { }
        public Azure.ResourceManager.HybridData.Models.HybridDataSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class HybridDataSku
    {
        public HybridDataSku() { }
        public string Name { get { throw null; } set { } }
        public string Tier { get { throw null; } set { } }
    }
    public enum HybridDataState
    {
        Disabled = 0,
        Enabled = 1,
        Supported = 2,
    }
    public enum JobCancellationSetting
    {
        NotCancellable = 0,
        Cancellable = 1,
    }
    public enum SupportedEncryptionAlgorithm
    {
        None = 0,
        Rsa1_5 = 1,
        Rsa_Oaep = 2,
        PlainText = 3,
    }
    public enum UserConfirmationSetting
    {
        NotRequired = 0,
        Required = 1,
    }
}
