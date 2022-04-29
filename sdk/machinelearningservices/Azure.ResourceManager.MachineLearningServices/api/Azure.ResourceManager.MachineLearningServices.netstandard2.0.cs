namespace Azure.ResourceManager.MachineLearningServices
{
    public partial class BatchDeploymentDataCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearningServices.BatchDeploymentDataResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearningServices.BatchDeploymentDataResource>, System.Collections.IEnumerable
    {
        protected BatchDeploymentDataCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearningServices.BatchDeploymentDataResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string deploymentName, Azure.ResourceManager.MachineLearningServices.BatchDeploymentDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearningServices.BatchDeploymentDataResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string deploymentName, Azure.ResourceManager.MachineLearningServices.BatchDeploymentDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.BatchDeploymentDataResource> Get(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearningServices.BatchDeploymentDataResource> GetAll(string orderBy = null, int? top = default(int?), string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.BatchDeploymentDataResource> GetAllAsync(string orderBy = null, int? top = default(int?), string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.BatchDeploymentDataResource>> GetAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MachineLearningServices.BatchDeploymentDataResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearningServices.BatchDeploymentDataResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MachineLearningServices.BatchDeploymentDataResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearningServices.BatchDeploymentDataResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class BatchDeploymentDataData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public BatchDeploymentDataData(Azure.Core.AzureLocation location, Azure.ResourceManager.MachineLearningServices.Models.BatchDeploymentDetails properties) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.BatchDeploymentDetails Properties { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.MachineLearningServicesSku Sku { get { throw null; } set { } }
    }
    public partial class BatchDeploymentDataResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BatchDeploymentDataResource() { }
        public virtual Azure.ResourceManager.MachineLearningServices.BatchDeploymentDataData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.BatchDeploymentDataResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.BatchDeploymentDataResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string endpointName, string deploymentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.BatchDeploymentDataResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.BatchDeploymentDataResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.BatchDeploymentDataResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.BatchDeploymentDataResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.BatchDeploymentDataResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.BatchDeploymentDataResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearningServices.BatchDeploymentDataResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearningServices.Models.BatchDeploymentDataPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearningServices.BatchDeploymentDataResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearningServices.Models.BatchDeploymentDataPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BatchEndpointDataCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearningServices.BatchEndpointDataResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearningServices.BatchEndpointDataResource>, System.Collections.IEnumerable
    {
        protected BatchEndpointDataCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearningServices.BatchEndpointDataResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string endpointName, Azure.ResourceManager.MachineLearningServices.BatchEndpointDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearningServices.BatchEndpointDataResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string endpointName, Azure.ResourceManager.MachineLearningServices.BatchEndpointDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.BatchEndpointDataResource> Get(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearningServices.BatchEndpointDataResource> GetAll(int? count = default(int?), string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.BatchEndpointDataResource> GetAllAsync(int? count = default(int?), string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.BatchEndpointDataResource>> GetAsync(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MachineLearningServices.BatchEndpointDataResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearningServices.BatchEndpointDataResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MachineLearningServices.BatchEndpointDataResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearningServices.BatchEndpointDataResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class BatchEndpointDataData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public BatchEndpointDataData(Azure.Core.AzureLocation location, Azure.ResourceManager.MachineLearningServices.Models.BatchEndpointDetails properties) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.BatchEndpointDetails Properties { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.MachineLearningServicesSku Sku { get { throw null; } set { } }
    }
    public partial class BatchEndpointDataResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BatchEndpointDataResource() { }
        public virtual Azure.ResourceManager.MachineLearningServices.BatchEndpointDataData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.BatchEndpointDataResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.BatchEndpointDataResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string endpointName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.BatchEndpointDataResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearningServices.BatchDeploymentDataCollection GetAllBatchDeploymentData() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.BatchEndpointDataResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.BatchDeploymentDataResource> GetBatchDeploymentData(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.BatchDeploymentDataResource>> GetBatchDeploymentDataAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.EndpointAuthKeys> GetKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.EndpointAuthKeys>> GetKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.BatchEndpointDataResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.BatchEndpointDataResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.BatchEndpointDataResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.BatchEndpointDataResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearningServices.BatchEndpointDataResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearningServices.Models.BatchEndpointDataPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearningServices.BatchEndpointDataResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearningServices.Models.BatchEndpointDataPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CodeContainerDataCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearningServices.CodeContainerDataResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearningServices.CodeContainerDataResource>, System.Collections.IEnumerable
    {
        protected CodeContainerDataCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearningServices.CodeContainerDataResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.MachineLearningServices.CodeContainerDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearningServices.CodeContainerDataResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.MachineLearningServices.CodeContainerDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.CodeContainerDataResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearningServices.CodeContainerDataResource> GetAll(string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.CodeContainerDataResource> GetAllAsync(string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.CodeContainerDataResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MachineLearningServices.CodeContainerDataResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearningServices.CodeContainerDataResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MachineLearningServices.CodeContainerDataResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearningServices.CodeContainerDataResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CodeContainerDataData : Azure.ResourceManager.Models.ResourceData
    {
        public CodeContainerDataData(Azure.ResourceManager.MachineLearningServices.Models.CodeContainerDetails properties) { }
        public Azure.ResourceManager.MachineLearningServices.Models.CodeContainerDetails Properties { get { throw null; } set { } }
    }
    public partial class CodeContainerDataResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CodeContainerDataResource() { }
        public virtual Azure.ResourceManager.MachineLearningServices.CodeContainerDataData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.CodeContainerDataResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearningServices.CodeVersionDataCollection GetAllCodeVersionData() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.CodeContainerDataResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.CodeVersionDataResource> GetCodeVersionData(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.CodeVersionDataResource>> GetCodeVersionDataAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearningServices.CodeContainerDataResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearningServices.CodeContainerDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearningServices.CodeContainerDataResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearningServices.CodeContainerDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CodeVersionDataCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearningServices.CodeVersionDataResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearningServices.CodeVersionDataResource>, System.Collections.IEnumerable
    {
        protected CodeVersionDataCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearningServices.CodeVersionDataResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string version, Azure.ResourceManager.MachineLearningServices.CodeVersionDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearningServices.CodeVersionDataResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string version, Azure.ResourceManager.MachineLearningServices.CodeVersionDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.CodeVersionDataResource> Get(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearningServices.CodeVersionDataResource> GetAll(string orderBy = null, int? top = default(int?), string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.CodeVersionDataResource> GetAllAsync(string orderBy = null, int? top = default(int?), string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.CodeVersionDataResource>> GetAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MachineLearningServices.CodeVersionDataResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearningServices.CodeVersionDataResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MachineLearningServices.CodeVersionDataResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearningServices.CodeVersionDataResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CodeVersionDataData : Azure.ResourceManager.Models.ResourceData
    {
        public CodeVersionDataData(Azure.ResourceManager.MachineLearningServices.Models.CodeVersionDetails properties) { }
        public Azure.ResourceManager.MachineLearningServices.Models.CodeVersionDetails Properties { get { throw null; } set { } }
    }
    public partial class CodeVersionDataResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CodeVersionDataResource() { }
        public virtual Azure.ResourceManager.MachineLearningServices.CodeVersionDataData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string name, string version) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.CodeVersionDataResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.CodeVersionDataResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearningServices.CodeVersionDataResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearningServices.CodeVersionDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearningServices.CodeVersionDataResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearningServices.CodeVersionDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ComponentContainerDataCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearningServices.ComponentContainerDataResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearningServices.ComponentContainerDataResource>, System.Collections.IEnumerable
    {
        protected ComponentContainerDataCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearningServices.ComponentContainerDataResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.MachineLearningServices.ComponentContainerDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearningServices.ComponentContainerDataResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.MachineLearningServices.ComponentContainerDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.ComponentContainerDataResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearningServices.ComponentContainerDataResource> GetAll(string skip = null, Azure.ResourceManager.MachineLearningServices.Models.ListViewType? listViewType = default(Azure.ResourceManager.MachineLearningServices.Models.ListViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.ComponentContainerDataResource> GetAllAsync(string skip = null, Azure.ResourceManager.MachineLearningServices.Models.ListViewType? listViewType = default(Azure.ResourceManager.MachineLearningServices.Models.ListViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.ComponentContainerDataResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MachineLearningServices.ComponentContainerDataResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearningServices.ComponentContainerDataResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MachineLearningServices.ComponentContainerDataResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearningServices.ComponentContainerDataResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ComponentContainerDataData : Azure.ResourceManager.Models.ResourceData
    {
        public ComponentContainerDataData(Azure.ResourceManager.MachineLearningServices.Models.ComponentContainerDetails properties) { }
        public Azure.ResourceManager.MachineLearningServices.Models.ComponentContainerDetails Properties { get { throw null; } set { } }
    }
    public partial class ComponentContainerDataResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ComponentContainerDataResource() { }
        public virtual Azure.ResourceManager.MachineLearningServices.ComponentContainerDataData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.ComponentContainerDataResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearningServices.ComponentVersionDataCollection GetAllComponentVersionData() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.ComponentContainerDataResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.ComponentVersionDataResource> GetComponentVersionData(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.ComponentVersionDataResource>> GetComponentVersionDataAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearningServices.ComponentContainerDataResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearningServices.ComponentContainerDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearningServices.ComponentContainerDataResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearningServices.ComponentContainerDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ComponentVersionDataCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearningServices.ComponentVersionDataResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearningServices.ComponentVersionDataResource>, System.Collections.IEnumerable
    {
        protected ComponentVersionDataCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearningServices.ComponentVersionDataResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string version, Azure.ResourceManager.MachineLearningServices.ComponentVersionDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearningServices.ComponentVersionDataResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string version, Azure.ResourceManager.MachineLearningServices.ComponentVersionDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.ComponentVersionDataResource> Get(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearningServices.ComponentVersionDataResource> GetAll(string orderBy = null, int? top = default(int?), string skip = null, Azure.ResourceManager.MachineLearningServices.Models.ListViewType? listViewType = default(Azure.ResourceManager.MachineLearningServices.Models.ListViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.ComponentVersionDataResource> GetAllAsync(string orderBy = null, int? top = default(int?), string skip = null, Azure.ResourceManager.MachineLearningServices.Models.ListViewType? listViewType = default(Azure.ResourceManager.MachineLearningServices.Models.ListViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.ComponentVersionDataResource>> GetAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MachineLearningServices.ComponentVersionDataResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearningServices.ComponentVersionDataResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MachineLearningServices.ComponentVersionDataResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearningServices.ComponentVersionDataResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ComponentVersionDataData : Azure.ResourceManager.Models.ResourceData
    {
        public ComponentVersionDataData(Azure.ResourceManager.MachineLearningServices.Models.ComponentVersionDetails properties) { }
        public Azure.ResourceManager.MachineLearningServices.Models.ComponentVersionDetails Properties { get { throw null; } set { } }
    }
    public partial class ComponentVersionDataResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ComponentVersionDataResource() { }
        public virtual Azure.ResourceManager.MachineLearningServices.ComponentVersionDataData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string name, string version) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.ComponentVersionDataResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.ComponentVersionDataResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearningServices.ComponentVersionDataResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearningServices.ComponentVersionDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearningServices.ComponentVersionDataResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearningServices.ComponentVersionDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ComputeResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ComputeResource() { }
        public virtual Azure.ResourceManager.MachineLearningServices.ComputeResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.ComputeResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.ComputeResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string computeName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearningServices.Models.UnderlyingResourceAction underlyingResourceAction, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearningServices.Models.UnderlyingResourceAction underlyingResourceAction, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.ComputeResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.ComputeResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.ComputeSecrets> GetKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.ComputeSecrets>> GetKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearningServices.Models.AmlComputeNodeInformation> GetNodes(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.Models.AmlComputeNodeInformation> GetNodesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.ComputeResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.ComputeResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Restart(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RestartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.ComputeResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.ComputeResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Start(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Stop(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StopAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearningServices.ComputeResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearningServices.Models.ComputeResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearningServices.ComputeResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearningServices.Models.ComputeResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ComputeResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearningServices.ComputeResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearningServices.ComputeResource>, System.Collections.IEnumerable
    {
        protected ComputeResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearningServices.ComputeResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string computeName, Azure.ResourceManager.MachineLearningServices.ComputeResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearningServices.ComputeResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string computeName, Azure.ResourceManager.MachineLearningServices.ComputeResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string computeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string computeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.ComputeResource> Get(string computeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearningServices.ComputeResource> GetAll(string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.ComputeResource> GetAllAsync(string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.ComputeResource>> GetAsync(string computeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MachineLearningServices.ComputeResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearningServices.ComputeResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MachineLearningServices.ComputeResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearningServices.ComputeResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ComputeResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public ComputeResourceData() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public string Location { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.Compute Properties { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.MachineLearningServicesSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class DataContainerDataCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearningServices.DataContainerDataResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearningServices.DataContainerDataResource>, System.Collections.IEnumerable
    {
        protected DataContainerDataCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearningServices.DataContainerDataResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.MachineLearningServices.DataContainerDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearningServices.DataContainerDataResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.MachineLearningServices.DataContainerDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.DataContainerDataResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearningServices.DataContainerDataResource> GetAll(string skip = null, Azure.ResourceManager.MachineLearningServices.Models.ListViewType? listViewType = default(Azure.ResourceManager.MachineLearningServices.Models.ListViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.DataContainerDataResource> GetAllAsync(string skip = null, Azure.ResourceManager.MachineLearningServices.Models.ListViewType? listViewType = default(Azure.ResourceManager.MachineLearningServices.Models.ListViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.DataContainerDataResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MachineLearningServices.DataContainerDataResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearningServices.DataContainerDataResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MachineLearningServices.DataContainerDataResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearningServices.DataContainerDataResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataContainerDataData : Azure.ResourceManager.Models.ResourceData
    {
        public DataContainerDataData(Azure.ResourceManager.MachineLearningServices.Models.DataContainerDetails properties) { }
        public Azure.ResourceManager.MachineLearningServices.Models.DataContainerDetails Properties { get { throw null; } set { } }
    }
    public partial class DataContainerDataResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataContainerDataResource() { }
        public virtual Azure.ResourceManager.MachineLearningServices.DataContainerDataData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.DataContainerDataResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearningServices.DataVersionBaseDataCollection GetAllDataVersionBaseData() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.DataContainerDataResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.DataVersionBaseDataResource> GetDataVersionBaseData(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.DataVersionBaseDataResource>> GetDataVersionBaseDataAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearningServices.DataContainerDataResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearningServices.DataContainerDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearningServices.DataContainerDataResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearningServices.DataContainerDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatastoreDataCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearningServices.DatastoreDataResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearningServices.DatastoreDataResource>, System.Collections.IEnumerable
    {
        protected DatastoreDataCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearningServices.DatastoreDataResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.MachineLearningServices.DatastoreDataData data, bool? skipValidation = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearningServices.DatastoreDataResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.MachineLearningServices.DatastoreDataData data, bool? skipValidation = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.DatastoreDataResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearningServices.DatastoreDataResource> GetAll(string skip = null, int? count = default(int?), bool? isDefault = default(bool?), System.Collections.Generic.IEnumerable<string> names = null, string searchText = null, string orderBy = null, bool? orderByAsc = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.DatastoreDataResource> GetAllAsync(string skip = null, int? count = default(int?), bool? isDefault = default(bool?), System.Collections.Generic.IEnumerable<string> names = null, string searchText = null, string orderBy = null, bool? orderByAsc = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.DatastoreDataResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MachineLearningServices.DatastoreDataResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearningServices.DatastoreDataResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MachineLearningServices.DatastoreDataResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearningServices.DatastoreDataResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DatastoreDataData : Azure.ResourceManager.Models.ResourceData
    {
        public DatastoreDataData(Azure.ResourceManager.MachineLearningServices.Models.DatastoreDetails properties) { }
        public Azure.ResourceManager.MachineLearningServices.Models.DatastoreDetails Properties { get { throw null; } set { } }
    }
    public partial class DatastoreDataResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DatastoreDataResource() { }
        public virtual Azure.ResourceManager.MachineLearningServices.DatastoreDataData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.DatastoreDataResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.DatastoreDataResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.DatastoreSecrets> GetSecrets(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.DatastoreSecrets>> GetSecretsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearningServices.DatastoreDataResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearningServices.DatastoreDataData data, bool? skipValidation = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearningServices.DatastoreDataResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearningServices.DatastoreDataData data, bool? skipValidation = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataVersionBaseDataCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearningServices.DataVersionBaseDataResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearningServices.DataVersionBaseDataResource>, System.Collections.IEnumerable
    {
        protected DataVersionBaseDataCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearningServices.DataVersionBaseDataResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string version, Azure.ResourceManager.MachineLearningServices.DataVersionBaseDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearningServices.DataVersionBaseDataResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string version, Azure.ResourceManager.MachineLearningServices.DataVersionBaseDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.DataVersionBaseDataResource> Get(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearningServices.DataVersionBaseDataResource> GetAll(string orderBy = null, int? top = default(int?), string skip = null, string tags = null, Azure.ResourceManager.MachineLearningServices.Models.ListViewType? listViewType = default(Azure.ResourceManager.MachineLearningServices.Models.ListViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.DataVersionBaseDataResource> GetAllAsync(string orderBy = null, int? top = default(int?), string skip = null, string tags = null, Azure.ResourceManager.MachineLearningServices.Models.ListViewType? listViewType = default(Azure.ResourceManager.MachineLearningServices.Models.ListViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.DataVersionBaseDataResource>> GetAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MachineLearningServices.DataVersionBaseDataResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearningServices.DataVersionBaseDataResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MachineLearningServices.DataVersionBaseDataResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearningServices.DataVersionBaseDataResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataVersionBaseDataData : Azure.ResourceManager.Models.ResourceData
    {
        public DataVersionBaseDataData(Azure.ResourceManager.MachineLearningServices.Models.DataVersionBaseDetails properties) { }
        public Azure.ResourceManager.MachineLearningServices.Models.DataVersionBaseDetails Properties { get { throw null; } set { } }
    }
    public partial class DataVersionBaseDataResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataVersionBaseDataResource() { }
        public virtual Azure.ResourceManager.MachineLearningServices.DataVersionBaseDataData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string name, string version) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.DataVersionBaseDataResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.DataVersionBaseDataResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearningServices.DataVersionBaseDataResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearningServices.DataVersionBaseDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearningServices.DataVersionBaseDataResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearningServices.DataVersionBaseDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EnvironmentContainerDataCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearningServices.EnvironmentContainerDataResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearningServices.EnvironmentContainerDataResource>, System.Collections.IEnumerable
    {
        protected EnvironmentContainerDataCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearningServices.EnvironmentContainerDataResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.MachineLearningServices.EnvironmentContainerDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearningServices.EnvironmentContainerDataResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.MachineLearningServices.EnvironmentContainerDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.EnvironmentContainerDataResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearningServices.EnvironmentContainerDataResource> GetAll(string skip = null, Azure.ResourceManager.MachineLearningServices.Models.ListViewType? listViewType = default(Azure.ResourceManager.MachineLearningServices.Models.ListViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.EnvironmentContainerDataResource> GetAllAsync(string skip = null, Azure.ResourceManager.MachineLearningServices.Models.ListViewType? listViewType = default(Azure.ResourceManager.MachineLearningServices.Models.ListViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.EnvironmentContainerDataResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MachineLearningServices.EnvironmentContainerDataResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearningServices.EnvironmentContainerDataResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MachineLearningServices.EnvironmentContainerDataResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearningServices.EnvironmentContainerDataResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EnvironmentContainerDataData : Azure.ResourceManager.Models.ResourceData
    {
        public EnvironmentContainerDataData(Azure.ResourceManager.MachineLearningServices.Models.EnvironmentContainerDetails properties) { }
        public Azure.ResourceManager.MachineLearningServices.Models.EnvironmentContainerDetails Properties { get { throw null; } set { } }
    }
    public partial class EnvironmentContainerDataResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EnvironmentContainerDataResource() { }
        public virtual Azure.ResourceManager.MachineLearningServices.EnvironmentContainerDataData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.EnvironmentContainerDataResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearningServices.EnvironmentVersionDataCollection GetAllEnvironmentVersionData() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.EnvironmentContainerDataResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.EnvironmentVersionDataResource> GetEnvironmentVersionData(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.EnvironmentVersionDataResource>> GetEnvironmentVersionDataAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearningServices.EnvironmentContainerDataResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearningServices.EnvironmentContainerDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearningServices.EnvironmentContainerDataResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearningServices.EnvironmentContainerDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EnvironmentVersionDataCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearningServices.EnvironmentVersionDataResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearningServices.EnvironmentVersionDataResource>, System.Collections.IEnumerable
    {
        protected EnvironmentVersionDataCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearningServices.EnvironmentVersionDataResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string version, Azure.ResourceManager.MachineLearningServices.EnvironmentVersionDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearningServices.EnvironmentVersionDataResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string version, Azure.ResourceManager.MachineLearningServices.EnvironmentVersionDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.EnvironmentVersionDataResource> Get(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearningServices.EnvironmentVersionDataResource> GetAll(string orderBy = null, int? top = default(int?), string skip = null, Azure.ResourceManager.MachineLearningServices.Models.ListViewType? listViewType = default(Azure.ResourceManager.MachineLearningServices.Models.ListViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.EnvironmentVersionDataResource> GetAllAsync(string orderBy = null, int? top = default(int?), string skip = null, Azure.ResourceManager.MachineLearningServices.Models.ListViewType? listViewType = default(Azure.ResourceManager.MachineLearningServices.Models.ListViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.EnvironmentVersionDataResource>> GetAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MachineLearningServices.EnvironmentVersionDataResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearningServices.EnvironmentVersionDataResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MachineLearningServices.EnvironmentVersionDataResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearningServices.EnvironmentVersionDataResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EnvironmentVersionDataData : Azure.ResourceManager.Models.ResourceData
    {
        public EnvironmentVersionDataData(Azure.ResourceManager.MachineLearningServices.Models.EnvironmentVersionDetails properties) { }
        public Azure.ResourceManager.MachineLearningServices.Models.EnvironmentVersionDetails Properties { get { throw null; } set { } }
    }
    public partial class EnvironmentVersionDataResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EnvironmentVersionDataResource() { }
        public virtual Azure.ResourceManager.MachineLearningServices.EnvironmentVersionDataData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string name, string version) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.EnvironmentVersionDataResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.EnvironmentVersionDataResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearningServices.EnvironmentVersionDataResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearningServices.EnvironmentVersionDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearningServices.EnvironmentVersionDataResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearningServices.EnvironmentVersionDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class JobBaseDataCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearningServices.JobBaseDataResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearningServices.JobBaseDataResource>, System.Collections.IEnumerable
    {
        protected JobBaseDataCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearningServices.JobBaseDataResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string id, Azure.ResourceManager.MachineLearningServices.JobBaseDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearningServices.JobBaseDataResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string id, Azure.ResourceManager.MachineLearningServices.JobBaseDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.JobBaseDataResource> Get(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearningServices.JobBaseDataResource> GetAll(string skip = null, string jobType = null, string tag = null, Azure.ResourceManager.MachineLearningServices.Models.ListViewType? listViewType = default(Azure.ResourceManager.MachineLearningServices.Models.ListViewType?), bool? scheduled = default(bool?), string scheduleId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.JobBaseDataResource> GetAllAsync(string skip = null, string jobType = null, string tag = null, Azure.ResourceManager.MachineLearningServices.Models.ListViewType? listViewType = default(Azure.ResourceManager.MachineLearningServices.Models.ListViewType?), bool? scheduled = default(bool?), string scheduleId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.JobBaseDataResource>> GetAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MachineLearningServices.JobBaseDataResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearningServices.JobBaseDataResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MachineLearningServices.JobBaseDataResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearningServices.JobBaseDataResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class JobBaseDataData : Azure.ResourceManager.Models.ResourceData
    {
        public JobBaseDataData(Azure.ResourceManager.MachineLearningServices.Models.JobBaseDetails properties) { }
        public Azure.ResourceManager.MachineLearningServices.Models.JobBaseDetails Properties { get { throw null; } set { } }
    }
    public partial class JobBaseDataResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected JobBaseDataResource() { }
        public virtual Azure.ResourceManager.MachineLearningServices.JobBaseDataData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response Cancel(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string id) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.JobBaseDataResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.JobBaseDataResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearningServices.JobBaseDataResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearningServices.JobBaseDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearningServices.JobBaseDataResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearningServices.JobBaseDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class MachineLearningServicesExtensions
    {
        public static Azure.ResourceManager.MachineLearningServices.BatchDeploymentDataResource GetBatchDeploymentDataResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.BatchEndpointDataResource GetBatchEndpointDataResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.CodeContainerDataResource GetCodeContainerDataResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.CodeVersionDataResource GetCodeVersionDataResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.ComponentContainerDataResource GetComponentContainerDataResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.ComponentVersionDataResource GetComponentVersionDataResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.ComputeResource GetComputeResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.DataContainerDataResource GetDataContainerDataResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.DatastoreDataResource GetDatastoreDataResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.DataVersionBaseDataResource GetDataVersionBaseDataResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.EnvironmentContainerDataResource GetEnvironmentContainerDataResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.EnvironmentVersionDataResource GetEnvironmentVersionDataResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.JobBaseDataResource GetJobBaseDataResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.ModelContainerDataResource GetModelContainerDataResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.ModelVersionDataResource GetModelVersionDataResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.OnlineDeploymentDataResource GetOnlineDeploymentDataResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.OnlineEndpointDataResource GetOnlineEndpointDataResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.PrivateEndpointConnectionResource GetPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.MachineLearningServices.Models.ResourceQuota> GetQuotas(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.Models.ResourceQuota> GetQuotasAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.MachineLearningServices.Models.MachineLearningServicesUsage> GetUsages(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.Models.MachineLearningServicesUsage> GetUsagesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.MachineLearningServices.Models.VirtualMachineSize> GetVirtualMachineSizes(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.Models.VirtualMachineSize> GetVirtualMachineSizesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.MachineLearningServices.WorkspaceResource> GetWorkspace(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.WorkspaceResource>> GetWorkspaceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.WorkspaceConnectionResource GetWorkspaceConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.WorkspaceResource GetWorkspaceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.WorkspaceCollection GetWorkspaces(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.MachineLearningServices.WorkspaceResource> GetWorkspaces(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.WorkspaceResource> GetWorkspacesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.MachineLearningServices.Models.UpdateWorkspaceQuotas> UpdateQuotas(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, Azure.ResourceManager.MachineLearningServices.Models.QuotaUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.Models.UpdateWorkspaceQuotas> UpdateQuotasAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, Azure.ResourceManager.MachineLearningServices.Models.QuotaUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ModelContainerDataCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearningServices.ModelContainerDataResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearningServices.ModelContainerDataResource>, System.Collections.IEnumerable
    {
        protected ModelContainerDataCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearningServices.ModelContainerDataResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.MachineLearningServices.ModelContainerDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearningServices.ModelContainerDataResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.MachineLearningServices.ModelContainerDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.ModelContainerDataResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearningServices.ModelContainerDataResource> GetAll(string skip = null, int? count = default(int?), Azure.ResourceManager.MachineLearningServices.Models.ListViewType? listViewType = default(Azure.ResourceManager.MachineLearningServices.Models.ListViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.ModelContainerDataResource> GetAllAsync(string skip = null, int? count = default(int?), Azure.ResourceManager.MachineLearningServices.Models.ListViewType? listViewType = default(Azure.ResourceManager.MachineLearningServices.Models.ListViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.ModelContainerDataResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MachineLearningServices.ModelContainerDataResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearningServices.ModelContainerDataResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MachineLearningServices.ModelContainerDataResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearningServices.ModelContainerDataResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ModelContainerDataData : Azure.ResourceManager.Models.ResourceData
    {
        public ModelContainerDataData(Azure.ResourceManager.MachineLearningServices.Models.ModelContainerDetails properties) { }
        public Azure.ResourceManager.MachineLearningServices.Models.ModelContainerDetails Properties { get { throw null; } set { } }
    }
    public partial class ModelContainerDataResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ModelContainerDataResource() { }
        public virtual Azure.ResourceManager.MachineLearningServices.ModelContainerDataData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.ModelContainerDataResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearningServices.ModelVersionDataCollection GetAllModelVersionData() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.ModelContainerDataResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.ModelVersionDataResource> GetModelVersionData(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.ModelVersionDataResource>> GetModelVersionDataAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearningServices.ModelContainerDataResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearningServices.ModelContainerDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearningServices.ModelContainerDataResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearningServices.ModelContainerDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ModelVersionDataCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearningServices.ModelVersionDataResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearningServices.ModelVersionDataResource>, System.Collections.IEnumerable
    {
        protected ModelVersionDataCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearningServices.ModelVersionDataResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string version, Azure.ResourceManager.MachineLearningServices.ModelVersionDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearningServices.ModelVersionDataResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string version, Azure.ResourceManager.MachineLearningServices.ModelVersionDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.ModelVersionDataResource> Get(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearningServices.ModelVersionDataResource> GetAll(string skip = null, string orderBy = null, int? top = default(int?), string version = null, string description = null, int? offset = default(int?), string tags = null, string properties = null, string feed = null, Azure.ResourceManager.MachineLearningServices.Models.ListViewType? listViewType = default(Azure.ResourceManager.MachineLearningServices.Models.ListViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.ModelVersionDataResource> GetAllAsync(string skip = null, string orderBy = null, int? top = default(int?), string version = null, string description = null, int? offset = default(int?), string tags = null, string properties = null, string feed = null, Azure.ResourceManager.MachineLearningServices.Models.ListViewType? listViewType = default(Azure.ResourceManager.MachineLearningServices.Models.ListViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.ModelVersionDataResource>> GetAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MachineLearningServices.ModelVersionDataResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearningServices.ModelVersionDataResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MachineLearningServices.ModelVersionDataResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearningServices.ModelVersionDataResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ModelVersionDataData : Azure.ResourceManager.Models.ResourceData
    {
        public ModelVersionDataData(Azure.ResourceManager.MachineLearningServices.Models.ModelVersionDetails properties) { }
        public Azure.ResourceManager.MachineLearningServices.Models.ModelVersionDetails Properties { get { throw null; } set { } }
    }
    public partial class ModelVersionDataResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ModelVersionDataResource() { }
        public virtual Azure.ResourceManager.MachineLearningServices.ModelVersionDataData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string name, string version) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.ModelVersionDataResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.ModelVersionDataResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearningServices.ModelVersionDataResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearningServices.ModelVersionDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearningServices.ModelVersionDataResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearningServices.ModelVersionDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OnlineDeploymentDataCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearningServices.OnlineDeploymentDataResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearningServices.OnlineDeploymentDataResource>, System.Collections.IEnumerable
    {
        protected OnlineDeploymentDataCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearningServices.OnlineDeploymentDataResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string deploymentName, Azure.ResourceManager.MachineLearningServices.OnlineDeploymentDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearningServices.OnlineDeploymentDataResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string deploymentName, Azure.ResourceManager.MachineLearningServices.OnlineDeploymentDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.OnlineDeploymentDataResource> Get(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearningServices.OnlineDeploymentDataResource> GetAll(string orderBy = null, int? top = default(int?), string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.OnlineDeploymentDataResource> GetAllAsync(string orderBy = null, int? top = default(int?), string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.OnlineDeploymentDataResource>> GetAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MachineLearningServices.OnlineDeploymentDataResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearningServices.OnlineDeploymentDataResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MachineLearningServices.OnlineDeploymentDataResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearningServices.OnlineDeploymentDataResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class OnlineDeploymentDataData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public OnlineDeploymentDataData(Azure.Core.AzureLocation location, Azure.ResourceManager.MachineLearningServices.Models.OnlineDeploymentDetails properties) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.OnlineDeploymentDetails Properties { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.MachineLearningServicesSku Sku { get { throw null; } set { } }
    }
    public partial class OnlineDeploymentDataResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected OnlineDeploymentDataResource() { }
        public virtual Azure.ResourceManager.MachineLearningServices.OnlineDeploymentDataData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.OnlineDeploymentDataResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.OnlineDeploymentDataResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string endpointName, string deploymentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.OnlineDeploymentDataResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.OnlineDeploymentDataResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.DeploymentLogs> GetLogs(Azure.ResourceManager.MachineLearningServices.Models.DeploymentLogsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.DeploymentLogs>> GetLogsAsync(Azure.ResourceManager.MachineLearningServices.Models.DeploymentLogsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearningServices.Models.SkuResource> GetSkus(int? count = default(int?), string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.Models.SkuResource> GetSkusAsync(int? count = default(int?), string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.OnlineDeploymentDataResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.OnlineDeploymentDataResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.OnlineDeploymentDataResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.OnlineDeploymentDataResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearningServices.OnlineDeploymentDataResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearningServices.Models.OnlineDeploymentDataPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearningServices.OnlineDeploymentDataResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearningServices.Models.OnlineDeploymentDataPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OnlineEndpointDataCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearningServices.OnlineEndpointDataResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearningServices.OnlineEndpointDataResource>, System.Collections.IEnumerable
    {
        protected OnlineEndpointDataCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearningServices.OnlineEndpointDataResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string endpointName, Azure.ResourceManager.MachineLearningServices.OnlineEndpointDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearningServices.OnlineEndpointDataResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string endpointName, Azure.ResourceManager.MachineLearningServices.OnlineEndpointDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.OnlineEndpointDataResource> Get(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearningServices.OnlineEndpointDataResource> GetAll(string name = null, int? count = default(int?), Azure.ResourceManager.MachineLearningServices.Models.EndpointComputeType? computeType = default(Azure.ResourceManager.MachineLearningServices.Models.EndpointComputeType?), string skip = null, string tags = null, string properties = null, Azure.ResourceManager.MachineLearningServices.Models.OrderString? orderBy = default(Azure.ResourceManager.MachineLearningServices.Models.OrderString?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.OnlineEndpointDataResource> GetAllAsync(string name = null, int? count = default(int?), Azure.ResourceManager.MachineLearningServices.Models.EndpointComputeType? computeType = default(Azure.ResourceManager.MachineLearningServices.Models.EndpointComputeType?), string skip = null, string tags = null, string properties = null, Azure.ResourceManager.MachineLearningServices.Models.OrderString? orderBy = default(Azure.ResourceManager.MachineLearningServices.Models.OrderString?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.OnlineEndpointDataResource>> GetAsync(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MachineLearningServices.OnlineEndpointDataResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearningServices.OnlineEndpointDataResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MachineLearningServices.OnlineEndpointDataResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearningServices.OnlineEndpointDataResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class OnlineEndpointDataData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public OnlineEndpointDataData(Azure.Core.AzureLocation location, Azure.ResourceManager.MachineLearningServices.Models.OnlineEndpointDetails properties) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.OnlineEndpointDetails Properties { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.MachineLearningServicesSku Sku { get { throw null; } set { } }
    }
    public partial class OnlineEndpointDataResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected OnlineEndpointDataResource() { }
        public virtual Azure.ResourceManager.MachineLearningServices.OnlineEndpointDataData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.OnlineEndpointDataResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.OnlineEndpointDataResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string endpointName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.OnlineEndpointDataResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearningServices.OnlineDeploymentDataCollection GetAllOnlineDeploymentData() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.OnlineEndpointDataResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.EndpointAuthKeys> GetKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.EndpointAuthKeys>> GetKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.OnlineDeploymentDataResource> GetOnlineDeploymentData(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.OnlineDeploymentDataResource>> GetOnlineDeploymentDataAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.EndpointAuthToken> GetToken(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.EndpointAuthToken>> GetTokenAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RegenerateKeys(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearningServices.Models.RegenerateEndpointKeysContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RegenerateKeysAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearningServices.Models.RegenerateEndpointKeysContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.OnlineEndpointDataResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.OnlineEndpointDataResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.OnlineEndpointDataResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.OnlineEndpointDataResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearningServices.OnlineEndpointDataResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearningServices.Models.OnlineEndpointDataPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearningServices.OnlineEndpointDataResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearningServices.Models.OnlineEndpointDataPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearningServices.PrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearningServices.PrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected PrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearningServices.PrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.MachineLearningServices.PrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearningServices.PrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.MachineLearningServices.PrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.PrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearningServices.PrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.PrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.PrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MachineLearningServices.PrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearningServices.PrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MachineLearningServices.PrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearningServices.PrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData
    {
        public PrivateEndpointConnectionData() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public string Location { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.PrivateEndpoint PrivateEndpoint { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.PrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.PrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.MachineLearningServicesSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class PrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.MachineLearningServices.PrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.PrivateEndpointConnectionResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.PrivateEndpointConnectionResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.PrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.PrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.PrivateEndpointConnectionResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.PrivateEndpointConnectionResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.PrivateEndpointConnectionResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.PrivateEndpointConnectionResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearningServices.PrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearningServices.PrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearningServices.PrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearningServices.PrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WorkspaceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearningServices.WorkspaceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearningServices.WorkspaceResource>, System.Collections.IEnumerable
    {
        protected WorkspaceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearningServices.WorkspaceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string workspaceName, Azure.ResourceManager.MachineLearningServices.WorkspaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearningServices.WorkspaceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string workspaceName, Azure.ResourceManager.MachineLearningServices.WorkspaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.WorkspaceResource> Get(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearningServices.WorkspaceResource> GetAll(string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.WorkspaceResource> GetAllAsync(string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.WorkspaceResource>> GetAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MachineLearningServices.WorkspaceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearningServices.WorkspaceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MachineLearningServices.WorkspaceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearningServices.WorkspaceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WorkspaceConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearningServices.WorkspaceConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearningServices.WorkspaceConnectionResource>, System.Collections.IEnumerable
    {
        protected WorkspaceConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearningServices.WorkspaceConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string connectionName, Azure.ResourceManager.MachineLearningServices.WorkspaceConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearningServices.WorkspaceConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string connectionName, Azure.ResourceManager.MachineLearningServices.WorkspaceConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string connectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string connectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.WorkspaceConnectionResource> Get(string connectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearningServices.WorkspaceConnectionResource> GetAll(string target = null, string category = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.WorkspaceConnectionResource> GetAllAsync(string target = null, string category = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.WorkspaceConnectionResource>> GetAsync(string connectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MachineLearningServices.WorkspaceConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearningServices.WorkspaceConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MachineLearningServices.WorkspaceConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearningServices.WorkspaceConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WorkspaceConnectionData : Azure.ResourceManager.Models.ResourceData
    {
        public WorkspaceConnectionData() { }
        public string AuthType { get { throw null; } set { } }
        public string Category { get { throw null; } set { } }
        public string Target { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.ValueFormat? ValueFormat { get { throw null; } set { } }
    }
    public partial class WorkspaceConnectionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WorkspaceConnectionResource() { }
        public virtual Azure.ResourceManager.MachineLearningServices.WorkspaceConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string connectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.WorkspaceConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.WorkspaceConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearningServices.WorkspaceConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearningServices.WorkspaceConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearningServices.WorkspaceConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearningServices.WorkspaceConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WorkspaceData : Azure.ResourceManager.Models.ResourceData
    {
        public WorkspaceData() { }
        public bool? AllowPublicAccessWhenBehindVnet { get { throw null; } set { } }
        public string ApplicationInsights { get { throw null; } set { } }
        public string ContainerRegistry { get { throw null; } set { } }
        public int? CosmosDbCollectionsThroughput { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public System.Uri DiscoveryUri { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.EncryptionProperty Encryption { get { throw null; } set { } }
        public string FriendlyName { get { throw null; } set { } }
        public bool? HbiWorkspace { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public string ImageBuildCompute { get { throw null; } set { } }
        public string KeyVault { get { throw null; } set { } }
        public string Location { get { throw null; } set { } }
        public System.Uri MlFlowTrackingUri { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.NotebookResourceInfo NotebookInfo { get { throw null; } }
        public string PrimaryUserAssignedIdentity { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearningServices.PrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public int? PrivateLinkCount { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.PublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public string ServiceProvisionedResourceGroup { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.MachineLearningServices.Models.SharedPrivateLinkResource> SharedPrivateLinkResources { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.MachineLearningServicesSku Sku { get { throw null; } set { } }
        public string StorageAccount { get { throw null; } set { } }
        public bool? StorageHnsEnabled { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public string TenantId { get { throw null; } }
        public string WorkspaceId { get { throw null; } }
    }
    public partial class WorkspaceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WorkspaceResource() { }
        public virtual Azure.ResourceManager.MachineLearningServices.WorkspaceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.WorkspaceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.WorkspaceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearningServices.Models.DiagnoseResponseResult> Diagnose(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearningServices.Models.DiagnoseWorkspaceContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearningServices.Models.DiagnoseResponseResult>> DiagnoseAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearningServices.Models.DiagnoseWorkspaceContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.WorkspaceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearningServices.BatchEndpointDataCollection GetAllBatchEndpointData() { throw null; }
        public virtual Azure.ResourceManager.MachineLearningServices.CodeContainerDataCollection GetAllCodeContainerData() { throw null; }
        public virtual Azure.ResourceManager.MachineLearningServices.ComponentContainerDataCollection GetAllComponentContainerData() { throw null; }
        public virtual Azure.ResourceManager.MachineLearningServices.DataContainerDataCollection GetAllDataContainerData() { throw null; }
        public virtual Azure.ResourceManager.MachineLearningServices.DatastoreDataCollection GetAllDatastoreData() { throw null; }
        public virtual Azure.ResourceManager.MachineLearningServices.EnvironmentContainerDataCollection GetAllEnvironmentContainerData() { throw null; }
        public virtual Azure.ResourceManager.MachineLearningServices.JobBaseDataCollection GetAllJobBaseData() { throw null; }
        public virtual Azure.ResourceManager.MachineLearningServices.ModelContainerDataCollection GetAllModelContainerData() { throw null; }
        public virtual Azure.ResourceManager.MachineLearningServices.OnlineEndpointDataCollection GetAllOnlineEndpointData() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.WorkspaceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.BatchEndpointDataResource> GetBatchEndpointData(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.BatchEndpointDataResource>> GetBatchEndpointDataAsync(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.CodeContainerDataResource> GetCodeContainerData(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.CodeContainerDataResource>> GetCodeContainerDataAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.ComponentContainerDataResource> GetComponentContainerData(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.ComponentContainerDataResource>> GetComponentContainerDataAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.ComputeResource> GetComputeResource(string computeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.ComputeResource>> GetComputeResourceAsync(string computeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearningServices.ComputeResourceCollection GetComputeResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.DataContainerDataResource> GetDataContainerData(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.DataContainerDataResource>> GetDataContainerDataAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.DatastoreDataResource> GetDatastoreData(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.DatastoreDataResource>> GetDatastoreDataAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.EnvironmentContainerDataResource> GetEnvironmentContainerData(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.EnvironmentContainerDataResource>> GetEnvironmentContainerDataAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.JobBaseDataResource> GetJobBaseData(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.JobBaseDataResource>> GetJobBaseDataAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.ListWorkspaceKeysResult> GetKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.ListWorkspaceKeysResult>> GetKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.ModelContainerDataResource> GetModelContainerData(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.ModelContainerDataResource>> GetModelContainerDataAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.NotebookAccessTokenResult> GetNotebookAccessToken(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.NotebookAccessTokenResult>> GetNotebookAccessTokenAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.ListNotebookKeysResult> GetNotebookKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.ListNotebookKeysResult>> GetNotebookKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.OnlineEndpointDataResource> GetOnlineEndpointData(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.OnlineEndpointDataResource>> GetOnlineEndpointDataAsync(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearningServices.Models.FqdnEndpoints> GetOutboundNetworkDependenciesEndpoints(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.Models.FqdnEndpoints> GetOutboundNetworkDependenciesEndpointsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.PrivateEndpointConnectionResource> GetPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.PrivateEndpointConnectionResource>> GetPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearningServices.PrivateEndpointConnectionCollection GetPrivateEndpointConnections() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearningServices.Models.PrivateLinkResource> GetPrivateLinkResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.Models.PrivateLinkResource> GetPrivateLinkResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.ListStorageAccountKeysResult> GetStorageAccountKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.ListStorageAccountKeysResult>> GetStorageAccountKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.WorkspaceConnectionResource> GetWorkspaceConnection(string connectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.WorkspaceConnectionResource>> GetWorkspaceConnectionAsync(string connectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearningServices.WorkspaceConnectionCollection GetWorkspaceConnections() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearningServices.Models.AmlUserFeature> GetWorkspaceFeatures(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.Models.AmlUserFeature> GetWorkspaceFeaturesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearningServices.Models.NotebookResourceInfo> PrepareNotebook(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearningServices.Models.NotebookResourceInfo>> PrepareNotebookAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.WorkspaceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.WorkspaceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ResyncKeys(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ResyncKeysAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.WorkspaceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.WorkspaceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearningServices.WorkspaceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearningServices.Models.WorkspacePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearningServices.WorkspaceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearningServices.Models.WorkspacePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.MachineLearningServices.Models
{
    public partial class AccountKeyDatastoreCredentials : Azure.ResourceManager.MachineLearningServices.Models.DatastoreCredentials
    {
        public AccountKeyDatastoreCredentials(Azure.ResourceManager.MachineLearningServices.Models.AccountKeyDatastoreSecrets secrets) { }
        public Azure.ResourceManager.MachineLearningServices.Models.AccountKeyDatastoreSecrets Secrets { get { throw null; } set { } }
    }
    public partial class AccountKeyDatastoreSecrets : Azure.ResourceManager.MachineLearningServices.Models.DatastoreSecrets
    {
        public AccountKeyDatastoreSecrets() { }
        public string Key { get { throw null; } set { } }
    }
    public partial class AKS : Azure.ResourceManager.MachineLearningServices.Models.Compute
    {
        public AKS() { }
        public Azure.ResourceManager.MachineLearningServices.Models.AKSSchemaProperties Properties { get { throw null; } set { } }
    }
    public partial class AksComputeSecrets : Azure.ResourceManager.MachineLearningServices.Models.ComputeSecrets
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
    public partial class AKSSchemaProperties
    {
        public AKSSchemaProperties() { }
        public int? AgentCount { get { throw null; } set { } }
        public string AgentVmSize { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.AksNetworkingConfiguration AksNetworkingConfiguration { get { throw null; } set { } }
        public string ClusterFqdn { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.ClusterPurpose? ClusterPurpose { get { throw null; } set { } }
        public string LoadBalancerSubnet { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.LoadBalancerType? LoadBalancerType { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.SslConfiguration SslConfiguration { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearningServices.Models.SystemService> SystemServices { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AllocationState : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.AllocationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AllocationState(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.AllocationState Resizing { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.AllocationState Steady { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.AllocationState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.AllocationState left, Azure.ResourceManager.MachineLearningServices.Models.AllocationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.AllocationState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.AllocationState left, Azure.ResourceManager.MachineLearningServices.Models.AllocationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AmlCompute : Azure.ResourceManager.MachineLearningServices.Models.Compute
    {
        public AmlCompute() { }
        public Azure.ResourceManager.MachineLearningServices.Models.AmlComputeProperties Properties { get { throw null; } set { } }
    }
    public partial class AmlComputeNodeInformation
    {
        internal AmlComputeNodeInformation() { }
        public string NodeId { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.NodeState? NodeState { get { throw null; } }
        public int? Port { get { throw null; } }
        public string PrivateIpAddress { get { throw null; } }
        public string PublicIpAddress { get { throw null; } }
        public string RunId { get { throw null; } }
    }
    public partial class AmlComputeProperties
    {
        public AmlComputeProperties() { }
        public Azure.ResourceManager.MachineLearningServices.Models.AllocationState? AllocationState { get { throw null; } }
        public System.DateTimeOffset? AllocationStateTransitionOn { get { throw null; } }
        public int? CurrentNodeCount { get { throw null; } }
        public bool? EnableNodePublicIp { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearningServices.Models.ErrorResponse> Errors { get { throw null; } }
        public bool? IsolatedNetwork { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.NodeStateCounts NodeStateCounts { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.OsType? OsType { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> PropertyBag { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.RemoteLoginPortPublicAccess? RemoteLoginPortPublicAccess { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.ScaleSettings ScaleSettings { get { throw null; } set { } }
        public string SubnetId { get { throw null; } set { } }
        public int? TargetNodeCount { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.UserAccountCredentials UserAccountCredentials { get { throw null; } set { } }
        public string VirtualMachineImageId { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.VmPriority? VmPriority { get { throw null; } set { } }
        public string VmSize { get { throw null; } set { } }
    }
    public partial class AmlUserFeature
    {
        internal AmlUserFeature() { }
        public string Description { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public string Id { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ApplicationSharingPolicy : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.ApplicationSharingPolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ApplicationSharingPolicy(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.ApplicationSharingPolicy Personal { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ApplicationSharingPolicy Shared { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.ApplicationSharingPolicy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.ApplicationSharingPolicy left, Azure.ResourceManager.MachineLearningServices.Models.ApplicationSharingPolicy right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.ApplicationSharingPolicy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.ApplicationSharingPolicy left, Azure.ResourceManager.MachineLearningServices.Models.ApplicationSharingPolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AssetBase : Azure.ResourceManager.MachineLearningServices.Models.ResourceBase
    {
        public AssetBase() { }
        public bool? IsAnonymous { get { throw null; } set { } }
        public bool? IsArchived { get { throw null; } set { } }
    }
    public partial class AssetContainer : Azure.ResourceManager.MachineLearningServices.Models.ResourceBase
    {
        public AssetContainer() { }
        public bool? IsArchived { get { throw null; } set { } }
        public string LatestVersion { get { throw null; } }
        public string NextVersion { get { throw null; } }
    }
    public partial class AssetReferenceBase
    {
        public AssetReferenceBase() { }
        public string Foo { get { throw null; } set { } }
    }
    public partial class AssignedUser
    {
        public AssignedUser(string objectId, string tenantId) { }
        public string ObjectId { get { throw null; } set { } }
        public string TenantId { get { throw null; } set { } }
    }
    public partial class AutoMLJob : Azure.ResourceManager.MachineLearningServices.Models.JobBaseDetails
    {
        public AutoMLJob(Azure.ResourceManager.MachineLearningServices.Models.AutoMLVertical taskDetails) { }
        public string EnvironmentId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> EnvironmentVariables { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.MachineLearningServices.Models.JobOutput> Outputs { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.ResourceConfiguration Resources { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.AutoMLVertical TaskDetails { get { throw null; } set { } }
    }
    public partial class AutoMLVertical
    {
        public AutoMLVertical() { }
        public Azure.ResourceManager.MachineLearningServices.Models.LogVerbosity? LogVerbosity { get { throw null; } set { } }
    }
    public partial class AutoPauseProperties
    {
        public AutoPauseProperties() { }
        public int? DelayInMinutes { get { throw null; } set { } }
        public bool? Enabled { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Autosave : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.Autosave>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Autosave(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.Autosave Local { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.Autosave None { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.Autosave Remote { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.Autosave other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.Autosave left, Azure.ResourceManager.MachineLearningServices.Models.Autosave right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.Autosave (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.Autosave left, Azure.ResourceManager.MachineLearningServices.Models.Autosave right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AutoScaleProperties
    {
        public AutoScaleProperties() { }
        public bool? Enabled { get { throw null; } set { } }
        public int? MaxNodeCount { get { throw null; } set { } }
        public int? MinNodeCount { get { throw null; } set { } }
    }
    public partial class AzureBlobDatastore : Azure.ResourceManager.MachineLearningServices.Models.DatastoreDetails
    {
        public AzureBlobDatastore(Azure.ResourceManager.MachineLearningServices.Models.DatastoreCredentials credentials) : base (default(Azure.ResourceManager.MachineLearningServices.Models.DatastoreCredentials)) { }
        public string AccountName { get { throw null; } set { } }
        public string ContainerName { get { throw null; } set { } }
        public string Endpoint { get { throw null; } set { } }
        public string Protocol { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.ServiceDataAccessAuthIdentity? ServiceDataAccessAuthIdentity { get { throw null; } set { } }
    }
    public partial class AzureDataLakeGen1Datastore : Azure.ResourceManager.MachineLearningServices.Models.DatastoreDetails
    {
        public AzureDataLakeGen1Datastore(Azure.ResourceManager.MachineLearningServices.Models.DatastoreCredentials credentials, string storeName) : base (default(Azure.ResourceManager.MachineLearningServices.Models.DatastoreCredentials)) { }
        public Azure.ResourceManager.MachineLearningServices.Models.ServiceDataAccessAuthIdentity? ServiceDataAccessAuthIdentity { get { throw null; } set { } }
        public string StoreName { get { throw null; } set { } }
    }
    public partial class AzureDataLakeGen2Datastore : Azure.ResourceManager.MachineLearningServices.Models.DatastoreDetails
    {
        public AzureDataLakeGen2Datastore(Azure.ResourceManager.MachineLearningServices.Models.DatastoreCredentials credentials, string accountName, string filesystem) : base (default(Azure.ResourceManager.MachineLearningServices.Models.DatastoreCredentials)) { }
        public string AccountName { get { throw null; } set { } }
        public string Endpoint { get { throw null; } set { } }
        public string Filesystem { get { throw null; } set { } }
        public string Protocol { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.ServiceDataAccessAuthIdentity? ServiceDataAccessAuthIdentity { get { throw null; } set { } }
    }
    public partial class AzureFileDatastore : Azure.ResourceManager.MachineLearningServices.Models.DatastoreDetails
    {
        public AzureFileDatastore(Azure.ResourceManager.MachineLearningServices.Models.DatastoreCredentials credentials, string accountName, string fileShareName) : base (default(Azure.ResourceManager.MachineLearningServices.Models.DatastoreCredentials)) { }
        public string AccountName { get { throw null; } set { } }
        public string Endpoint { get { throw null; } set { } }
        public string FileShareName { get { throw null; } set { } }
        public string Protocol { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.ServiceDataAccessAuthIdentity? ServiceDataAccessAuthIdentity { get { throw null; } set { } }
    }
    public partial class BanditPolicy : Azure.ResourceManager.MachineLearningServices.Models.EarlyTerminationPolicy
    {
        public BanditPolicy() { }
        public float? SlackAmount { get { throw null; } set { } }
        public float? SlackFactor { get { throw null; } set { } }
    }
    public partial class BatchDeploymentDataPatch
    {
        public BatchDeploymentDataPatch() { }
        public Azure.ResourceManager.MachineLearningServices.Models.PartialManagedServiceIdentity Identity { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public string Location { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.PartialBatchDeployment Properties { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.PartialSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class BatchDeploymentDetails : Azure.ResourceManager.MachineLearningServices.Models.EndpointDeploymentPropertiesBase
    {
        public BatchDeploymentDetails() { }
        public string Compute { get { throw null; } set { } }
        public int? ErrorThreshold { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.BatchLoggingLevel? LoggingLevel { get { throw null; } set { } }
        public int? MaxConcurrencyPerInstance { get { throw null; } set { } }
        public long? MiniBatchSize { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.AssetReferenceBase Model { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.BatchOutputAction? OutputAction { get { throw null; } set { } }
        public string OutputFileName { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.DeploymentProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.ResourceConfiguration Resources { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.BatchRetrySettings RetrySettings { get { throw null; } set { } }
    }
    public partial class BatchEndpointDataPatch
    {
        public BatchEndpointDataPatch() { }
        public string DefaultsDeploymentName { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.PartialManagedServiceIdentity Identity { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public string Location { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.PartialSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class BatchEndpointDetails : Azure.ResourceManager.MachineLearningServices.Models.EndpointPropertiesBase
    {
        public BatchEndpointDetails(Azure.ResourceManager.MachineLearningServices.Models.EndpointAuthMode authMode) : base (default(Azure.ResourceManager.MachineLearningServices.Models.EndpointAuthMode)) { }
        public string DefaultsDeploymentName { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.EndpointProvisioningState? ProvisioningState { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BatchLoggingLevel : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.BatchLoggingLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BatchLoggingLevel(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.BatchLoggingLevel Debug { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.BatchLoggingLevel Info { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.BatchLoggingLevel Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.BatchLoggingLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.BatchLoggingLevel left, Azure.ResourceManager.MachineLearningServices.Models.BatchLoggingLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.BatchLoggingLevel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.BatchLoggingLevel left, Azure.ResourceManager.MachineLearningServices.Models.BatchLoggingLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BatchOutputAction : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.BatchOutputAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BatchOutputAction(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.BatchOutputAction AppendRow { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.BatchOutputAction SummaryOnly { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.BatchOutputAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.BatchOutputAction left, Azure.ResourceManager.MachineLearningServices.Models.BatchOutputAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.BatchOutputAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.BatchOutputAction left, Azure.ResourceManager.MachineLearningServices.Models.BatchOutputAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BatchRetrySettings
    {
        public BatchRetrySettings() { }
        public int? MaxRetries { get { throw null; } set { } }
        public System.TimeSpan? Timeout { get { throw null; } set { } }
    }
    public partial class BayesianSamplingAlgorithm : Azure.ResourceManager.MachineLearningServices.Models.SamplingAlgorithm
    {
        public BayesianSamplingAlgorithm() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BillingCurrency : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.BillingCurrency>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BillingCurrency(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.BillingCurrency USD { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.BillingCurrency other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.BillingCurrency left, Azure.ResourceManager.MachineLearningServices.Models.BillingCurrency right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.BillingCurrency (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.BillingCurrency left, Azure.ResourceManager.MachineLearningServices.Models.BillingCurrency right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BuildContext
    {
        public BuildContext(System.Uri contextUri) { }
        public System.Uri ContextUri { get { throw null; } set { } }
        public string DockerfilePath { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Caching : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.Caching>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Caching(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.Caching None { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.Caching ReadOnly { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.Caching ReadWrite { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.Caching other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.Caching left, Azure.ResourceManager.MachineLearningServices.Models.Caching right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.Caching (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.Caching left, Azure.ResourceManager.MachineLearningServices.Models.Caching right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CertificateDatastoreCredentials : Azure.ResourceManager.MachineLearningServices.Models.DatastoreCredentials
    {
        public CertificateDatastoreCredentials(System.Guid clientId, Azure.ResourceManager.MachineLearningServices.Models.CertificateDatastoreSecrets secrets, System.Guid tenantId, string thumbprint) { }
        public System.Uri AuthorityUri { get { throw null; } set { } }
        public System.Guid ClientId { get { throw null; } set { } }
        public System.Uri ResourceUri { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.CertificateDatastoreSecrets Secrets { get { throw null; } set { } }
        public System.Guid TenantId { get { throw null; } set { } }
        public string Thumbprint { get { throw null; } set { } }
    }
    public partial class CertificateDatastoreSecrets : Azure.ResourceManager.MachineLearningServices.Models.DatastoreSecrets
    {
        public CertificateDatastoreSecrets() { }
        public string Certificate { get { throw null; } set { } }
    }
    public partial class Classification : Azure.ResourceManager.MachineLearningServices.Models.AutoMLVertical
    {
        public Classification() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.MachineLearningServices.Models.ClassificationModels> AllowedModels { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.MachineLearningServices.Models.ClassificationModels> BlockedModels { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.TableVerticalDataSettings DataSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.TableVerticalFeaturizationSettings FeaturizationSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.TableVerticalLimitSettings LimitSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.ClassificationPrimaryMetrics? PrimaryMetric { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.TrainingSettings TrainingSettings { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClassificationModels : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.ClassificationModels>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClassificationModels(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.ClassificationModels BernoulliNaiveBayes { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ClassificationModels DecisionTree { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ClassificationModels ExtremeRandomTrees { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ClassificationModels GradientBoosting { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ClassificationModels KNN { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ClassificationModels LightGBM { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ClassificationModels LinearSVM { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ClassificationModels LogisticRegression { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ClassificationModels MultinomialNaiveBayes { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ClassificationModels RandomForest { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ClassificationModels SGD { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ClassificationModels SVM { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ClassificationModels XGBoostClassifier { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.ClassificationModels other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.ClassificationModels left, Azure.ResourceManager.MachineLearningServices.Models.ClassificationModels right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.ClassificationModels (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.ClassificationModels left, Azure.ResourceManager.MachineLearningServices.Models.ClassificationModels right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClassificationMultilabelPrimaryMetrics : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.ClassificationMultilabelPrimaryMetrics>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClassificationMultilabelPrimaryMetrics(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.ClassificationMultilabelPrimaryMetrics Accuracy { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ClassificationMultilabelPrimaryMetrics AUCWeighted { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ClassificationMultilabelPrimaryMetrics AveragePrecisionScoreWeighted { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ClassificationMultilabelPrimaryMetrics IOU { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ClassificationMultilabelPrimaryMetrics NormMacroRecall { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ClassificationMultilabelPrimaryMetrics PrecisionScoreWeighted { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.ClassificationMultilabelPrimaryMetrics other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.ClassificationMultilabelPrimaryMetrics left, Azure.ResourceManager.MachineLearningServices.Models.ClassificationMultilabelPrimaryMetrics right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.ClassificationMultilabelPrimaryMetrics (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.ClassificationMultilabelPrimaryMetrics left, Azure.ResourceManager.MachineLearningServices.Models.ClassificationMultilabelPrimaryMetrics right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClassificationPrimaryMetrics : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.ClassificationPrimaryMetrics>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClassificationPrimaryMetrics(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.ClassificationPrimaryMetrics Accuracy { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ClassificationPrimaryMetrics AUCWeighted { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ClassificationPrimaryMetrics AveragePrecisionScoreWeighted { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ClassificationPrimaryMetrics NormMacroRecall { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ClassificationPrimaryMetrics PrecisionScoreWeighted { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.ClassificationPrimaryMetrics other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.ClassificationPrimaryMetrics left, Azure.ResourceManager.MachineLearningServices.Models.ClassificationPrimaryMetrics right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.ClassificationPrimaryMetrics (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.ClassificationPrimaryMetrics left, Azure.ResourceManager.MachineLearningServices.Models.ClassificationPrimaryMetrics right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClusterPurpose : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.ClusterPurpose>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClusterPurpose(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.ClusterPurpose DenseProd { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ClusterPurpose DevTest { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ClusterPurpose FastProd { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.ClusterPurpose other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.ClusterPurpose left, Azure.ResourceManager.MachineLearningServices.Models.ClusterPurpose right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.ClusterPurpose (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.ClusterPurpose left, Azure.ResourceManager.MachineLearningServices.Models.ClusterPurpose right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CodeConfiguration
    {
        public CodeConfiguration(string scoringScript) { }
        public string CodeId { get { throw null; } set { } }
        public string ScoringScript { get { throw null; } set { } }
    }
    public partial class CodeContainerDetails : Azure.ResourceManager.MachineLearningServices.Models.AssetContainer
    {
        public CodeContainerDetails() { }
    }
    public partial class CodeVersionDetails : Azure.ResourceManager.MachineLearningServices.Models.AssetBase
    {
        public CodeVersionDetails() { }
        public System.Uri CodeUri { get { throw null; } set { } }
    }
    public partial class ColumnTransformer
    {
        public ColumnTransformer() { }
        public System.Collections.Generic.IList<string> Fields { get { throw null; } set { } }
        public System.BinaryData Parameters { get { throw null; } set { } }
    }
    public partial class CommandJob : Azure.ResourceManager.MachineLearningServices.Models.JobBaseDetails
    {
        public CommandJob(string command, string environmentId) { }
        public string CodeId { get { throw null; } set { } }
        public string Command { get { throw null; } set { } }
        public string EnvironmentId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> EnvironmentVariables { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.MachineLearningServices.Models.JobInput> Inputs { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.CommandJobLimits Limits { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.MachineLearningServices.Models.JobOutput> Outputs { get { throw null; } set { } }
        public System.BinaryData Parameters { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.ResourceConfiguration Resources { get { throw null; } set { } }
    }
    public partial class CommandJobLimits : Azure.ResourceManager.MachineLearningServices.Models.JobLimits
    {
        public CommandJobLimits() { }
    }
    public partial class ComponentContainerDetails : Azure.ResourceManager.MachineLearningServices.Models.AssetContainer
    {
        public ComponentContainerDetails() { }
    }
    public partial class ComponentVersionDetails : Azure.ResourceManager.MachineLearningServices.Models.AssetBase
    {
        public ComponentVersionDetails() { }
        public System.BinaryData ComponentSpec { get { throw null; } set { } }
    }
    public partial class Compute
    {
        public Compute() { }
        public string ComputeLocation { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public bool? DisableLocalAuth { get { throw null; } set { } }
        public bool? IsAttachedCompute { get { throw null; } }
        public System.DateTimeOffset? ModifiedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearningServices.Models.ErrorResponse> ProvisioningErrors { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string ResourceId { get { throw null; } set { } }
    }
    public partial class ComputeInstance : Azure.ResourceManager.MachineLearningServices.Models.Compute
    {
        public ComputeInstance() { }
        public Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceProperties Properties { get { throw null; } set { } }
    }
    public partial class ComputeInstanceApplication
    {
        internal ComputeInstanceApplication() { }
        public string DisplayName { get { throw null; } }
        public System.Uri EndpointUri { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeInstanceAuthorizationType : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceAuthorizationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeInstanceAuthorizationType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceAuthorizationType Personal { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceAuthorizationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceAuthorizationType left, Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceAuthorizationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceAuthorizationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceAuthorizationType left, Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceAuthorizationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ComputeInstanceConnectivityEndpoints
    {
        internal ComputeInstanceConnectivityEndpoints() { }
        public string PrivateIpAddress { get { throw null; } }
        public string PublicIpAddress { get { throw null; } }
    }
    public partial class ComputeInstanceContainer
    {
        internal ComputeInstanceContainer() { }
        public Azure.ResourceManager.MachineLearningServices.Models.Autosave? Autosave { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceEnvironmentInfo Environment { get { throw null; } }
        public string Gpu { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.Network? Network { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<System.BinaryData> Services { get { throw null; } }
    }
    public partial class ComputeInstanceCreatedBy
    {
        internal ComputeInstanceCreatedBy() { }
        public string UserId { get { throw null; } }
        public string UserName { get { throw null; } }
        public string UserOrgId { get { throw null; } }
    }
    public partial class ComputeInstanceDataDisk
    {
        internal ComputeInstanceDataDisk() { }
        public Azure.ResourceManager.MachineLearningServices.Models.Caching? Caching { get { throw null; } }
        public int? DiskSizeGB { get { throw null; } }
        public int? Lun { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.StorageAccountType? StorageAccountType { get { throw null; } }
    }
    public partial class ComputeInstanceDataMount
    {
        internal ComputeInstanceDataMount() { }
        public string CreatedBy { get { throw null; } }
        public string Error { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.MountAction? MountAction { get { throw null; } }
        public System.DateTimeOffset? MountedOn { get { throw null; } }
        public string MountName { get { throw null; } }
        public string MountPath { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.MountState? MountState { get { throw null; } }
        public string Source { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.SourceType? SourceType { get { throw null; } }
    }
    public partial class ComputeInstanceEnvironmentInfo
    {
        internal ComputeInstanceEnvironmentInfo() { }
        public string Name { get { throw null; } }
        public string Version { get { throw null; } }
    }
    public partial class ComputeInstanceLastOperation
    {
        internal ComputeInstanceLastOperation() { }
        public Azure.ResourceManager.MachineLearningServices.Models.OperationName? OperationName { get { throw null; } }
        public System.DateTimeOffset? OperationOn { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.OperationStatus? OperationStatus { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.OperationTrigger? OperationTrigger { get { throw null; } }
    }
    public partial class ComputeInstanceProperties
    {
        public ComputeInstanceProperties() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceApplication> Applications { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.ApplicationSharingPolicy? ApplicationSharingPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceAuthorizationType? ComputeInstanceAuthorizationType { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceConnectivityEndpoints ConnectivityEndpoints { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceContainer> Containers { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceCreatedBy CreatedBy { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceDataDisk> DataDisks { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceDataMount> DataMounts { get { throw null; } }
        public bool? EnableNodePublicIp { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearningServices.Models.ErrorResponse> Errors { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceLastOperation LastOperation { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.AssignedUser PersonalComputeInstanceAssignedUser { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearningServices.Models.ComputeStartStopSchedule> SchedulesComputeStartStop { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.ScriptsToExecute Scripts { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceSshSettings SshSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceState? State { get { throw null; } }
        public string SubnetId { get { throw null; } set { } }
        public string VersionsRuntime { get { throw null; } }
        public string VmSize { get { throw null; } set { } }
    }
    public partial class ComputeInstanceSshSettings
    {
        public ComputeInstanceSshSettings() { }
        public string AdminPublicKey { get { throw null; } set { } }
        public string AdminUserName { get { throw null; } }
        public int? SshPort { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.SshPublicAccess? SshPublicAccess { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeInstanceState : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeInstanceState(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceState CreateFailed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceState Creating { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceState Deleting { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceState JobRunning { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceState Restarting { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceState Running { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceState SettingUp { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceState SetupFailed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceState Starting { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceState Stopped { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceState Stopping { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceState Unknown { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceState Unusable { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceState UserSettingUp { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceState UserSetupFailed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceState left, Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceState left, Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputePowerAction : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.ComputePowerAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputePowerAction(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.ComputePowerAction Start { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ComputePowerAction Stop { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.ComputePowerAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.ComputePowerAction left, Azure.ResourceManager.MachineLearningServices.Models.ComputePowerAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.ComputePowerAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.ComputePowerAction left, Azure.ResourceManager.MachineLearningServices.Models.ComputePowerAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ComputeResourcePatch
    {
        public ComputeResourcePatch() { }
        public Azure.ResourceManager.MachineLearningServices.Models.ScaleSettings ScaleSettings { get { throw null; } set { } }
    }
    public partial class ComputeSecrets
    {
        internal ComputeSecrets() { }
    }
    public partial class ComputeStartStopSchedule
    {
        internal ComputeStartStopSchedule() { }
        public Azure.ResourceManager.MachineLearningServices.Models.ComputePowerAction? Action { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.ProvisioningStatus? ProvisioningStatus { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.ScheduleBase Schedule { get { throw null; } }
    }
    public partial class ContainerResourceRequirements
    {
        public ContainerResourceRequirements() { }
        public Azure.ResourceManager.MachineLearningServices.Models.ContainerResourceSettings ContainerResourceLimits { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.ContainerResourceSettings ContainerResourceRequests { get { throw null; } set { } }
    }
    public partial class ContainerResourceSettings
    {
        public ContainerResourceSettings() { }
        public string Cpu { get { throw null; } set { } }
        public string Gpu { get { throw null; } set { } }
        public string Memory { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerType : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.ContainerType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.ContainerType InferenceServer { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ContainerType StorageInitializer { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.ContainerType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.ContainerType left, Azure.ResourceManager.MachineLearningServices.Models.ContainerType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.ContainerType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.ContainerType left, Azure.ResourceManager.MachineLearningServices.Models.ContainerType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CronSchedule : Azure.ResourceManager.MachineLearningServices.Models.ScheduleBase
    {
        public CronSchedule(string expression) { }
        public string Expression { get { throw null; } set { } }
    }
    public partial class CustomModelJobInput : Azure.ResourceManager.MachineLearningServices.Models.JobInput
    {
        public CustomModelJobInput(System.Uri uri) { }
        public Azure.ResourceManager.MachineLearningServices.Models.InputDeliveryMode? Mode { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    public partial class CustomModelJobOutput : Azure.ResourceManager.MachineLearningServices.Models.JobOutput
    {
        public CustomModelJobOutput() { }
        public Azure.ResourceManager.MachineLearningServices.Models.OutputDeliveryMode? Mode { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    public partial class Databricks : Azure.ResourceManager.MachineLearningServices.Models.Compute
    {
        public Databricks() { }
        public Azure.ResourceManager.MachineLearningServices.Models.DatabricksProperties Properties { get { throw null; } set { } }
    }
    public partial class DatabricksComputeSecrets : Azure.ResourceManager.MachineLearningServices.Models.ComputeSecrets
    {
        internal DatabricksComputeSecrets() { }
        public string DatabricksAccessToken { get { throw null; } }
    }
    public partial class DatabricksProperties
    {
        public DatabricksProperties() { }
        public string DatabricksAccessToken { get { throw null; } set { } }
        public System.Uri WorkspaceUri { get { throw null; } set { } }
    }
    public partial class DataContainerDetails : Azure.ResourceManager.MachineLearningServices.Models.AssetContainer
    {
        public DataContainerDetails(Azure.ResourceManager.MachineLearningServices.Models.DataType dataType) { }
        public Azure.ResourceManager.MachineLearningServices.Models.DataType DataType { get { throw null; } set { } }
    }
    public partial class DataFactory : Azure.ResourceManager.MachineLearningServices.Models.Compute
    {
        public DataFactory() { }
    }
    public partial class DataLakeAnalytics : Azure.ResourceManager.MachineLearningServices.Models.Compute
    {
        public DataLakeAnalytics() { }
        public string DataLakeStoreAccountName { get { throw null; } set { } }
    }
    public partial class DataPathAssetReference : Azure.ResourceManager.MachineLearningServices.Models.AssetReferenceBase
    {
        public DataPathAssetReference() { }
        public string DatastoreId { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
    }
    public partial class DataSettings
    {
        public DataSettings(string targetColumnName, Azure.ResourceManager.MachineLearningServices.Models.TrainingDataSettings trainingDataSettings) { }
        public Azure.ResourceManager.MachineLearningServices.Models.MLTableJobInput Data { get { throw null; } set { } }
        public string TargetColumnName { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.TestDataSettings TestData { get { throw null; } set { } }
    }
    public partial class DatastoreCredentials
    {
        public DatastoreCredentials() { }
    }
    public partial class DatastoreDetails : Azure.ResourceManager.MachineLearningServices.Models.ResourceBase
    {
        public DatastoreDetails(Azure.ResourceManager.MachineLearningServices.Models.DatastoreCredentials credentials) { }
        public bool? IsDefault { get { throw null; } }
    }
    public partial class DatastoreSecrets
    {
        public DatastoreSecrets() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataType : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.DataType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.DataType MLTable { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.DataType UriFile { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.DataType UriFolder { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.DataType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.DataType left, Azure.ResourceManager.MachineLearningServices.Models.DataType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.DataType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.DataType left, Azure.ResourceManager.MachineLearningServices.Models.DataType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataVersionBaseDetails : Azure.ResourceManager.MachineLearningServices.Models.AssetBase
    {
        public DataVersionBaseDetails(System.Uri dataUri) { }
        public System.Uri DataUri { get { throw null; } set { } }
    }
    public partial class DeploymentLogs
    {
        internal DeploymentLogs() { }
        public string Content { get { throw null; } }
    }
    public partial class DeploymentLogsContent
    {
        public DeploymentLogsContent() { }
        public Azure.ResourceManager.MachineLearningServices.Models.ContainerType? ContainerType { get { throw null; } set { } }
        public int? Tail { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeploymentProvisioningState : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.DeploymentProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeploymentProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.DeploymentProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.DeploymentProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.DeploymentProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.DeploymentProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.DeploymentProvisioningState Scaling { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.DeploymentProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.DeploymentProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.DeploymentProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.DeploymentProvisioningState left, Azure.ResourceManager.MachineLearningServices.Models.DeploymentProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.DeploymentProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.DeploymentProvisioningState left, Azure.ResourceManager.MachineLearningServices.Models.DeploymentProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DiagnoseRequestProperties
    {
        public DiagnoseRequestProperties() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> ApplicationInsights { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> ContainerRegistry { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> DnsResolution { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> KeyVault { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Nsg { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Others { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> ResourceLock { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> StorageAccount { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Udr { get { throw null; } }
    }
    public partial class DiagnoseResponseResult
    {
        internal DiagnoseResponseResult() { }
        public Azure.ResourceManager.MachineLearningServices.Models.DiagnoseResponseResultValue Value { get { throw null; } }
    }
    public partial class DiagnoseResponseResultValue
    {
        internal DiagnoseResponseResultValue() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearningServices.Models.DiagnoseResult> ApplicationInsightsResults { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearningServices.Models.DiagnoseResult> ContainerRegistryResults { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearningServices.Models.DiagnoseResult> DnsResolutionResults { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearningServices.Models.DiagnoseResult> KeyVaultResults { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearningServices.Models.DiagnoseResult> NetworkSecurityRuleResults { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearningServices.Models.DiagnoseResult> OtherResults { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearningServices.Models.DiagnoseResult> ResourceLockResults { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearningServices.Models.DiagnoseResult> StorageAccountResults { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearningServices.Models.DiagnoseResult> UserDefinedRouteResults { get { throw null; } }
    }
    public partial class DiagnoseResult
    {
        internal DiagnoseResult() { }
        public string Code { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.DiagnoseResultLevel? Level { get { throw null; } }
        public string Message { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiagnoseResultLevel : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.DiagnoseResultLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiagnoseResultLevel(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.DiagnoseResultLevel Error { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.DiagnoseResultLevel Information { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.DiagnoseResultLevel Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.DiagnoseResultLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.DiagnoseResultLevel left, Azure.ResourceManager.MachineLearningServices.Models.DiagnoseResultLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.DiagnoseResultLevel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.DiagnoseResultLevel left, Azure.ResourceManager.MachineLearningServices.Models.DiagnoseResultLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DiagnoseWorkspaceContent
    {
        public DiagnoseWorkspaceContent() { }
        public Azure.ResourceManager.MachineLearningServices.Models.DiagnoseRequestProperties Value { get { throw null; } set { } }
    }
    public partial class EarlyTerminationPolicy
    {
        public EarlyTerminationPolicy() { }
        public int? DelayEvaluation { get { throw null; } set { } }
        public int? EvaluationInterval { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EgressPublicNetworkAccessType : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.EgressPublicNetworkAccessType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EgressPublicNetworkAccessType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.EgressPublicNetworkAccessType Disabled { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.EgressPublicNetworkAccessType Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.EgressPublicNetworkAccessType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.EgressPublicNetworkAccessType left, Azure.ResourceManager.MachineLearningServices.Models.EgressPublicNetworkAccessType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.EgressPublicNetworkAccessType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.EgressPublicNetworkAccessType left, Azure.ResourceManager.MachineLearningServices.Models.EgressPublicNetworkAccessType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EncryptionKeyVaultProperties
    {
        public EncryptionKeyVaultProperties(string keyVaultArmId, string keyIdentifier) { }
        public string IdentityClientId { get { throw null; } set { } }
        public string KeyIdentifier { get { throw null; } set { } }
        public string KeyVaultArmId { get { throw null; } set { } }
    }
    public partial class EncryptionProperty
    {
        public EncryptionProperty(Azure.ResourceManager.MachineLearningServices.Models.EncryptionStatus status, Azure.ResourceManager.MachineLearningServices.Models.EncryptionKeyVaultProperties keyVaultProperties) { }
        public Azure.ResourceManager.MachineLearningServices.Models.EncryptionKeyVaultProperties KeyVaultProperties { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.EncryptionStatus Status { get { throw null; } set { } }
        public string UserAssignedIdentity { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EncryptionStatus : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.EncryptionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EncryptionStatus(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.EncryptionStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.EncryptionStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.EncryptionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.EncryptionStatus left, Azure.ResourceManager.MachineLearningServices.Models.EncryptionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.EncryptionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.EncryptionStatus left, Azure.ResourceManager.MachineLearningServices.Models.EncryptionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EndpointAuthKeys
    {
        public EndpointAuthKeys() { }
        public string PrimaryKey { get { throw null; } set { } }
        public string SecondaryKey { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EndpointAuthMode : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.EndpointAuthMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EndpointAuthMode(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.EndpointAuthMode AADToken { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.EndpointAuthMode AMLToken { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.EndpointAuthMode Key { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.EndpointAuthMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.EndpointAuthMode left, Azure.ResourceManager.MachineLearningServices.Models.EndpointAuthMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.EndpointAuthMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.EndpointAuthMode left, Azure.ResourceManager.MachineLearningServices.Models.EndpointAuthMode right) { throw null; }
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
    public readonly partial struct EndpointComputeType : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.EndpointComputeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EndpointComputeType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.EndpointComputeType AzureMLCompute { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.EndpointComputeType Kubernetes { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.EndpointComputeType Managed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.EndpointComputeType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.EndpointComputeType left, Azure.ResourceManager.MachineLearningServices.Models.EndpointComputeType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.EndpointComputeType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.EndpointComputeType left, Azure.ResourceManager.MachineLearningServices.Models.EndpointComputeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EndpointDeploymentPropertiesBase
    {
        public EndpointDeploymentPropertiesBase() { }
        public Azure.ResourceManager.MachineLearningServices.Models.CodeConfiguration CodeConfiguration { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string EnvironmentId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> EnvironmentVariables { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Properties { get { throw null; } set { } }
    }
    public partial class EndpointPropertiesBase
    {
        public EndpointPropertiesBase(Azure.ResourceManager.MachineLearningServices.Models.EndpointAuthMode authMode) { }
        public Azure.ResourceManager.MachineLearningServices.Models.EndpointAuthMode AuthMode { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.EndpointAuthKeys Keys { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Properties { get { throw null; } set { } }
        public System.Uri ScoringUri { get { throw null; } }
        public System.Uri SwaggerUri { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EndpointProvisioningState : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.EndpointProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EndpointProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.EndpointProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.EndpointProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.EndpointProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.EndpointProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.EndpointProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.EndpointProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.EndpointProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.EndpointProvisioningState left, Azure.ResourceManager.MachineLearningServices.Models.EndpointProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.EndpointProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.EndpointProvisioningState left, Azure.ResourceManager.MachineLearningServices.Models.EndpointProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EnvironmentContainerDetails : Azure.ResourceManager.MachineLearningServices.Models.AssetContainer
    {
        public EnvironmentContainerDetails() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EnvironmentType : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.EnvironmentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EnvironmentType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.EnvironmentType Curated { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.EnvironmentType UserCreated { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.EnvironmentType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.EnvironmentType left, Azure.ResourceManager.MachineLearningServices.Models.EnvironmentType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.EnvironmentType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.EnvironmentType left, Azure.ResourceManager.MachineLearningServices.Models.EnvironmentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EnvironmentVersionDetails : Azure.ResourceManager.MachineLearningServices.Models.AssetBase
    {
        public EnvironmentVersionDetails() { }
        public Azure.ResourceManager.MachineLearningServices.Models.BuildContext Build { get { throw null; } set { } }
        public string CondaFile { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.EnvironmentType? EnvironmentType { get { throw null; } }
        public string Image { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.InferenceContainerProperties InferenceConfig { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.OperatingSystemType? OsType { get { throw null; } set { } }
    }
    public partial class ErrorResponse
    {
        internal ErrorResponse() { }
        public Azure.ResponseError Error { get { throw null; } }
    }
    public partial class EstimatedVMPrice
    {
        internal EstimatedVMPrice() { }
        public Azure.ResourceManager.MachineLearningServices.Models.VMPriceOSType OsType { get { throw null; } }
        public double RetailPrice { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.VMTier VmTier { get { throw null; } }
    }
    public partial class EstimatedVMPrices
    {
        internal EstimatedVMPrices() { }
        public Azure.ResourceManager.MachineLearningServices.Models.BillingCurrency BillingCurrency { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.UnitOfMeasure UnitOfMeasure { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearningServices.Models.EstimatedVMPrice> Values { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FeatureLags : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.FeatureLags>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FeatureLags(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.FeatureLags Auto { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.FeatureLags None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.FeatureLags other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.FeatureLags left, Azure.ResourceManager.MachineLearningServices.Models.FeatureLags right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.FeatureLags (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.FeatureLags left, Azure.ResourceManager.MachineLearningServices.Models.FeatureLags right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FeaturizationMode : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.FeaturizationMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FeaturizationMode(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.FeaturizationMode Auto { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.FeaturizationMode Custom { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.FeaturizationMode Off { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.FeaturizationMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.FeaturizationMode left, Azure.ResourceManager.MachineLearningServices.Models.FeaturizationMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.FeaturizationMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.FeaturizationMode left, Azure.ResourceManager.MachineLearningServices.Models.FeaturizationMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FeaturizationSettings
    {
        public FeaturizationSettings() { }
        public string DatasetLanguage { get { throw null; } set { } }
    }
    public partial class FlavorData
    {
        public FlavorData() { }
        public System.Collections.Generic.IDictionary<string, string> Data { get { throw null; } set { } }
    }
    public partial class Forecasting : Azure.ResourceManager.MachineLearningServices.Models.AutoMLVertical
    {
        public Forecasting() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.MachineLearningServices.Models.ForecastingModels> AllowedModels { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.MachineLearningServices.Models.ForecastingModels> BlockedModels { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.TableVerticalDataSettings DataSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.TableVerticalFeaturizationSettings FeaturizationSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.ForecastingSettings ForecastingSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.TableVerticalLimitSettings LimitSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.ForecastingPrimaryMetrics? PrimaryMetric { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.TrainingSettings TrainingSettings { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ForecastingModels : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.ForecastingModels>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ForecastingModels(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.ForecastingModels Arimax { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ForecastingModels AutoArima { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ForecastingModels Average { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ForecastingModels DecisionTree { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ForecastingModels ElasticNet { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ForecastingModels ExponentialSmoothing { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ForecastingModels ExtremeRandomTrees { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ForecastingModels GradientBoosting { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ForecastingModels KNN { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ForecastingModels LassoLars { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ForecastingModels LightGBM { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ForecastingModels Naive { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ForecastingModels Prophet { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ForecastingModels RandomForest { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ForecastingModels SeasonalAverage { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ForecastingModels SeasonalNaive { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ForecastingModels SGD { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ForecastingModels TCNForecaster { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ForecastingModels XGBoostRegressor { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.ForecastingModels other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.ForecastingModels left, Azure.ResourceManager.MachineLearningServices.Models.ForecastingModels right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.ForecastingModels (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.ForecastingModels left, Azure.ResourceManager.MachineLearningServices.Models.ForecastingModels right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ForecastingPrimaryMetrics : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.ForecastingPrimaryMetrics>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ForecastingPrimaryMetrics(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.ForecastingPrimaryMetrics NormalizedMeanAbsoluteError { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ForecastingPrimaryMetrics NormalizedRootMeanSquaredError { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ForecastingPrimaryMetrics R2Score { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ForecastingPrimaryMetrics SpearmanCorrelation { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.ForecastingPrimaryMetrics other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.ForecastingPrimaryMetrics left, Azure.ResourceManager.MachineLearningServices.Models.ForecastingPrimaryMetrics right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.ForecastingPrimaryMetrics (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.ForecastingPrimaryMetrics left, Azure.ResourceManager.MachineLearningServices.Models.ForecastingPrimaryMetrics right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ForecastingSettings
    {
        public ForecastingSettings() { }
        public string CountryOrRegionForHolidays { get { throw null; } set { } }
        public int? CvStepSize { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.FeatureLags? FeatureLags { get { throw null; } set { } }
        public string Frequency { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.ShortSeriesHandlingConfiguration? ShortSeriesHandlingConfig { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.TargetAggregationFunction? TargetAggregateFunction { get { throw null; } set { } }
        public string TimeColumnName { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> TimeSeriesIdColumnNames { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.UseStl? UseStl { get { throw null; } set { } }
    }
    public partial class FqdnEndpoint
    {
        internal FqdnEndpoint() { }
        public string DomainName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearningServices.Models.FqdnEndpointDetail> EndpointDetails { get { throw null; } }
    }
    public partial class FqdnEndpointDetail
    {
        internal FqdnEndpointDetail() { }
        public int? Port { get { throw null; } }
    }
    public partial class FqdnEndpoints
    {
        internal FqdnEndpoints() { }
        public Azure.ResourceManager.MachineLearningServices.Models.FqdnEndpointsProperties Properties { get { throw null; } }
    }
    public partial class FqdnEndpointsProperties
    {
        internal FqdnEndpointsProperties() { }
        public string Category { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearningServices.Models.FqdnEndpoint> Endpoints { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Goal : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.Goal>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Goal(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.Goal Maximize { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.Goal Minimize { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.Goal other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.Goal left, Azure.ResourceManager.MachineLearningServices.Models.Goal right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.Goal (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.Goal left, Azure.ResourceManager.MachineLearningServices.Models.Goal right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class GridSamplingAlgorithm : Azure.ResourceManager.MachineLearningServices.Models.SamplingAlgorithm
    {
        public GridSamplingAlgorithm() { }
    }
    public partial class HdfsDatastore : Azure.ResourceManager.MachineLearningServices.Models.DatastoreDetails
    {
        public HdfsDatastore(Azure.ResourceManager.MachineLearningServices.Models.DatastoreCredentials credentials, string nameNodeAddress) : base (default(Azure.ResourceManager.MachineLearningServices.Models.DatastoreCredentials)) { }
        public string HdfsServerCertificate { get { throw null; } set { } }
        public string NameNodeAddress { get { throw null; } set { } }
        public string Protocol { get { throw null; } set { } }
    }
    public partial class HDInsight : Azure.ResourceManager.MachineLearningServices.Models.Compute
    {
        public HDInsight() { }
        public Azure.ResourceManager.MachineLearningServices.Models.HDInsightProperties Properties { get { throw null; } set { } }
    }
    public partial class HDInsightProperties
    {
        public HDInsightProperties() { }
        public string Address { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.VirtualMachineSshCredentials AdministratorAccount { get { throw null; } set { } }
        public int? SshPort { get { throw null; } set { } }
    }
    public partial class IdAssetReference : Azure.ResourceManager.MachineLearningServices.Models.AssetReferenceBase
    {
        public IdAssetReference(string assetId) { }
        public string AssetId { get { throw null; } set { } }
    }
    public partial class ImageClassification : Azure.ResourceManager.MachineLearningServices.Models.AutoMLVertical
    {
        public ImageClassification(Azure.ResourceManager.MachineLearningServices.Models.ImageVerticalDataSettings dataSettings, Azure.ResourceManager.MachineLearningServices.Models.ImageLimitSettings limitSettings) { }
        public Azure.ResourceManager.MachineLearningServices.Models.ImageVerticalDataSettings DataSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.ImageLimitSettings LimitSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.ImageModelSettingsClassification ModelSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.ClassificationPrimaryMetrics? PrimaryMetric { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.MachineLearningServices.Models.ImageModelDistributionSettingsClassification> SearchSpace { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.ImageSweepSettings SweepSettings { get { throw null; } set { } }
    }
    public partial class ImageClassificationMultilabel : Azure.ResourceManager.MachineLearningServices.Models.AutoMLVertical
    {
        public ImageClassificationMultilabel(Azure.ResourceManager.MachineLearningServices.Models.ImageVerticalDataSettings dataSettings, Azure.ResourceManager.MachineLearningServices.Models.ImageLimitSettings limitSettings) { }
        public Azure.ResourceManager.MachineLearningServices.Models.ImageVerticalDataSettings DataSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.ImageLimitSettings LimitSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.ImageModelSettingsClassification ModelSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.ClassificationMultilabelPrimaryMetrics? PrimaryMetric { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.MachineLearningServices.Models.ImageModelDistributionSettingsClassification> SearchSpace { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.ImageSweepSettings SweepSettings { get { throw null; } set { } }
    }
    public partial class ImageInstanceSegmentation : Azure.ResourceManager.MachineLearningServices.Models.AutoMLVertical
    {
        public ImageInstanceSegmentation(Azure.ResourceManager.MachineLearningServices.Models.ImageVerticalDataSettings dataSettings, Azure.ResourceManager.MachineLearningServices.Models.ImageLimitSettings limitSettings) { }
        public Azure.ResourceManager.MachineLearningServices.Models.ImageVerticalDataSettings DataSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.ImageLimitSettings LimitSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.ImageModelSettingsObjectDetection ModelSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.InstanceSegmentationPrimaryMetrics? PrimaryMetric { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.MachineLearningServices.Models.ImageModelDistributionSettingsObjectDetection> SearchSpace { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.ImageSweepSettings SweepSettings { get { throw null; } set { } }
    }
    public partial class ImageLimitSettings
    {
        public ImageLimitSettings() { }
        public int? MaxConcurrentTrials { get { throw null; } set { } }
        public int? MaxTrials { get { throw null; } set { } }
        public System.TimeSpan? Timeout { get { throw null; } set { } }
    }
    public partial class ImageModelDistributionSettings
    {
        public ImageModelDistributionSettings() { }
        public string AmsGradient { get { throw null; } set { } }
        public string Augmentations { get { throw null; } set { } }
        public string Beta1 { get { throw null; } set { } }
        public string Beta2 { get { throw null; } set { } }
        public string Distributed { get { throw null; } set { } }
        public string EarlyStopping { get { throw null; } set { } }
        public string EarlyStoppingDelay { get { throw null; } set { } }
        public string EarlyStoppingPatience { get { throw null; } set { } }
        public string EnableOnnxNormalization { get { throw null; } set { } }
        public string EvaluationFrequency { get { throw null; } set { } }
        public string GradientAccumulationStep { get { throw null; } set { } }
        public string LayersToFreeze { get { throw null; } set { } }
        public string LearningRate { get { throw null; } set { } }
        public string LearningRateScheduler { get { throw null; } set { } }
        public string ModelName { get { throw null; } set { } }
        public string Momentum { get { throw null; } set { } }
        public string Nesterov { get { throw null; } set { } }
        public string NumberOfEpochs { get { throw null; } set { } }
        public string NumberOfWorkers { get { throw null; } set { } }
        public string Optimizer { get { throw null; } set { } }
        public string RandomSeed { get { throw null; } set { } }
        public string SplitRatio { get { throw null; } set { } }
        public string StepLRGamma { get { throw null; } set { } }
        public string StepLRStepSize { get { throw null; } set { } }
        public string TrainingBatchSize { get { throw null; } set { } }
        public string ValidationBatchSize { get { throw null; } set { } }
        public string WarmupCosineLRCycles { get { throw null; } set { } }
        public string WarmupCosineLRWarmupEpochs { get { throw null; } set { } }
        public string WeightDecay { get { throw null; } set { } }
    }
    public partial class ImageModelDistributionSettingsClassification : Azure.ResourceManager.MachineLearningServices.Models.ImageModelDistributionSettings
    {
        public ImageModelDistributionSettingsClassification() { }
        public string TrainingCropSize { get { throw null; } set { } }
        public string ValidationCropSize { get { throw null; } set { } }
        public string ValidationResizeSize { get { throw null; } set { } }
        public string WeightedLoss { get { throw null; } set { } }
    }
    public partial class ImageModelDistributionSettingsObjectDetection : Azure.ResourceManager.MachineLearningServices.Models.ImageModelDistributionSettings
    {
        public ImageModelDistributionSettingsObjectDetection() { }
        public string BoxDetectionsPerImage { get { throw null; } set { } }
        public string BoxScoreThreshold { get { throw null; } set { } }
        public string ImageSize { get { throw null; } set { } }
        public string MaxSize { get { throw null; } set { } }
        public string MinSize { get { throw null; } set { } }
        public string ModelSize { get { throw null; } set { } }
        public string MultiScale { get { throw null; } set { } }
        public string NmsIouThreshold { get { throw null; } set { } }
        public string TileGridSize { get { throw null; } set { } }
        public string TileOverlapRatio { get { throw null; } set { } }
        public string TilePredictionsNmsThreshold { get { throw null; } set { } }
        public string ValidationIouThreshold { get { throw null; } set { } }
        public string ValidationMetricType { get { throw null; } set { } }
    }
    public partial class ImageModelSettings
    {
        public ImageModelSettings() { }
        public string AdvancedSettings { get { throw null; } set { } }
        public bool? AmsGradient { get { throw null; } set { } }
        public string Augmentations { get { throw null; } set { } }
        public float? Beta1 { get { throw null; } set { } }
        public float? Beta2 { get { throw null; } set { } }
        public string CheckpointDatasetId { get { throw null; } set { } }
        public string CheckpointFilename { get { throw null; } set { } }
        public int? CheckpointFrequency { get { throw null; } set { } }
        public string CheckpointRunId { get { throw null; } set { } }
        public bool? Distributed { get { throw null; } set { } }
        public bool? EarlyStopping { get { throw null; } set { } }
        public int? EarlyStoppingDelay { get { throw null; } set { } }
        public int? EarlyStoppingPatience { get { throw null; } set { } }
        public bool? EnableOnnxNormalization { get { throw null; } set { } }
        public int? EvaluationFrequency { get { throw null; } set { } }
        public int? GradientAccumulationStep { get { throw null; } set { } }
        public int? LayersToFreeze { get { throw null; } set { } }
        public float? LearningRate { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.LearningRateScheduler? LearningRateScheduler { get { throw null; } set { } }
        public string ModelName { get { throw null; } set { } }
        public float? Momentum { get { throw null; } set { } }
        public bool? Nesterov { get { throw null; } set { } }
        public int? NumberOfEpochs { get { throw null; } set { } }
        public int? NumberOfWorkers { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.StochasticOptimizer? Optimizer { get { throw null; } set { } }
        public int? RandomSeed { get { throw null; } set { } }
        public float? SplitRatio { get { throw null; } set { } }
        public float? StepLRGamma { get { throw null; } set { } }
        public int? StepLRStepSize { get { throw null; } set { } }
        public int? TrainingBatchSize { get { throw null; } set { } }
        public int? ValidationBatchSize { get { throw null; } set { } }
        public float? WarmupCosineLRCycles { get { throw null; } set { } }
        public int? WarmupCosineLRWarmupEpochs { get { throw null; } set { } }
        public float? WeightDecay { get { throw null; } set { } }
    }
    public partial class ImageModelSettingsClassification : Azure.ResourceManager.MachineLearningServices.Models.ImageModelSettings
    {
        public ImageModelSettingsClassification() { }
        public int? TrainingCropSize { get { throw null; } set { } }
        public int? ValidationCropSize { get { throw null; } set { } }
        public int? ValidationResizeSize { get { throw null; } set { } }
        public int? WeightedLoss { get { throw null; } set { } }
    }
    public partial class ImageModelSettingsObjectDetection : Azure.ResourceManager.MachineLearningServices.Models.ImageModelSettings
    {
        public ImageModelSettingsObjectDetection() { }
        public int? BoxDetectionsPerImage { get { throw null; } set { } }
        public float? BoxScoreThreshold { get { throw null; } set { } }
        public int? ImageSize { get { throw null; } set { } }
        public int? MaxSize { get { throw null; } set { } }
        public int? MinSize { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.ModelSize? ModelSize { get { throw null; } set { } }
        public bool? MultiScale { get { throw null; } set { } }
        public float? NmsIouThreshold { get { throw null; } set { } }
        public string TileGridSize { get { throw null; } set { } }
        public float? TileOverlapRatio { get { throw null; } set { } }
        public float? TilePredictionsNmsThreshold { get { throw null; } set { } }
        public float? ValidationIouThreshold { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.ValidationMetricType? ValidationMetricType { get { throw null; } set { } }
    }
    public partial class ImageObjectDetection : Azure.ResourceManager.MachineLearningServices.Models.AutoMLVertical
    {
        public ImageObjectDetection(Azure.ResourceManager.MachineLearningServices.Models.ImageVerticalDataSettings dataSettings, Azure.ResourceManager.MachineLearningServices.Models.ImageLimitSettings limitSettings) { }
        public Azure.ResourceManager.MachineLearningServices.Models.ImageVerticalDataSettings DataSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.ImageLimitSettings LimitSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.ImageModelSettingsObjectDetection ModelSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.ObjectDetectionPrimaryMetrics? PrimaryMetric { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.MachineLearningServices.Models.ImageModelDistributionSettingsObjectDetection> SearchSpace { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.ImageSweepSettings SweepSettings { get { throw null; } set { } }
    }
    public partial class ImageSweepLimitSettings
    {
        public ImageSweepLimitSettings() { }
        public int? MaxConcurrentTrials { get { throw null; } set { } }
        public int? MaxTrials { get { throw null; } set { } }
    }
    public partial class ImageSweepSettings
    {
        public ImageSweepSettings(Azure.ResourceManager.MachineLearningServices.Models.ImageSweepLimitSettings limits, Azure.ResourceManager.MachineLearningServices.Models.SamplingAlgorithmType samplingAlgorithm) { }
        public Azure.ResourceManager.MachineLearningServices.Models.EarlyTerminationPolicy EarlyTermination { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.ImageSweepLimitSettings Limits { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.SamplingAlgorithmType SamplingAlgorithm { get { throw null; } set { } }
    }
    public partial class ImageVerticalDataSettings : Azure.ResourceManager.MachineLearningServices.Models.DataSettings
    {
        public ImageVerticalDataSettings(string targetColumnName, Azure.ResourceManager.MachineLearningServices.Models.TrainingDataSettings trainingDataSettings) : base (default(string), default(Azure.ResourceManager.MachineLearningServices.Models.TrainingDataSettings)) { }
        public Azure.ResourceManager.MachineLearningServices.Models.ImageVerticalValidationDataSettings ValidationData { get { throw null; } set { } }
    }
    public partial class ImageVerticalValidationDataSettings : Azure.ResourceManager.MachineLearningServices.Models.ValidationDataSettings
    {
        public ImageVerticalValidationDataSettings() { }
    }
    public partial class InferenceContainerProperties
    {
        public InferenceContainerProperties() { }
        public Azure.ResourceManager.MachineLearningServices.Models.Route LivenessRoute { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.Route ReadinessRoute { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.Route ScoringRoute { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct InputDeliveryMode : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.InputDeliveryMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public InputDeliveryMode(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.InputDeliveryMode Direct { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.InputDeliveryMode Download { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.InputDeliveryMode EvalDownload { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.InputDeliveryMode EvalMount { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.InputDeliveryMode ReadOnlyMount { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.InputDeliveryMode ReadWriteMount { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.InputDeliveryMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.InputDeliveryMode left, Azure.ResourceManager.MachineLearningServices.Models.InputDeliveryMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.InputDeliveryMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.InputDeliveryMode left, Azure.ResourceManager.MachineLearningServices.Models.InputDeliveryMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct InstanceSegmentationPrimaryMetrics : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.InstanceSegmentationPrimaryMetrics>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public InstanceSegmentationPrimaryMetrics(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.InstanceSegmentationPrimaryMetrics MeanAveragePrecision { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.InstanceSegmentationPrimaryMetrics other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.InstanceSegmentationPrimaryMetrics left, Azure.ResourceManager.MachineLearningServices.Models.InstanceSegmentationPrimaryMetrics right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.InstanceSegmentationPrimaryMetrics (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.InstanceSegmentationPrimaryMetrics left, Azure.ResourceManager.MachineLearningServices.Models.InstanceSegmentationPrimaryMetrics right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class InstanceTypeSchema
    {
        public InstanceTypeSchema() { }
        public System.Collections.Generic.IDictionary<string, string> NodeSelector { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.InstanceTypeSchemaResources Resources { get { throw null; } set { } }
    }
    public partial class InstanceTypeSchemaResources
    {
        public InstanceTypeSchemaResources() { }
        public System.Collections.Generic.IDictionary<string, string> Limits { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Requests { get { throw null; } }
    }
    public partial class JobBaseDetails : Azure.ResourceManager.MachineLearningServices.Models.ResourceBase
    {
        public JobBaseDetails() { }
        public string ComputeId { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string ExperimentName { get { throw null; } set { } }
        public bool? IsArchived { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.ScheduleBase Schedule { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.MachineLearningServices.Models.JobService> Services { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.JobStatus? Status { get { throw null; } }
    }
    public partial class JobInput
    {
        public JobInput() { }
        public string Description { get { throw null; } set { } }
    }
    public partial class JobLimits
    {
        public JobLimits() { }
        public System.TimeSpan? Timeout { get { throw null; } set { } }
    }
    public partial class JobOutput
    {
        public JobOutput() { }
        public string Description { get { throw null; } set { } }
    }
    public partial class JobService
    {
        public JobService() { }
        public string Endpoint { get { throw null; } set { } }
        public string ErrorMessage { get { throw null; } }
        public string JobServiceType { get { throw null; } set { } }
        public int? Port { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Properties { get { throw null; } set { } }
        public string Status { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct JobStatus : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.JobStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public JobStatus(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.JobStatus Canceled { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.JobStatus CancelRequested { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.JobStatus Completed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.JobStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.JobStatus Finalizing { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.JobStatus NotResponding { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.JobStatus NotStarted { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.JobStatus Paused { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.JobStatus Preparing { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.JobStatus Provisioning { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.JobStatus Queued { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.JobStatus Running { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.JobStatus Scheduled { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.JobStatus Starting { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.JobStatus Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.JobStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.JobStatus left, Azure.ResourceManager.MachineLearningServices.Models.JobStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.JobStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.JobStatus left, Azure.ResourceManager.MachineLearningServices.Models.JobStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KerberosKeytabCredentials : Azure.ResourceManager.MachineLearningServices.Models.DatastoreCredentials
    {
        public KerberosKeytabCredentials(Azure.ResourceManager.MachineLearningServices.Models.KerberosKeytabSecrets secrets, string kerberosKdcAddress, string kerberosPrincipal, string kerberosRealm) { }
        public string KerberosKdcAddress { get { throw null; } set { } }
        public string KerberosPrincipal { get { throw null; } set { } }
        public string KerberosRealm { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.KerberosKeytabSecrets Secrets { get { throw null; } set { } }
    }
    public partial class KerberosKeytabSecrets : Azure.ResourceManager.MachineLearningServices.Models.DatastoreSecrets
    {
        public KerberosKeytabSecrets() { }
        public string KerberosKeytab { get { throw null; } set { } }
    }
    public partial class KerberosPasswordCredentials : Azure.ResourceManager.MachineLearningServices.Models.DatastoreCredentials
    {
        public KerberosPasswordCredentials(Azure.ResourceManager.MachineLearningServices.Models.KerberosPasswordSecrets secrets, string kerberosKdcAddress, string kerberosPrincipal, string kerberosRealm) { }
        public string KerberosKdcAddress { get { throw null; } set { } }
        public string KerberosPrincipal { get { throw null; } set { } }
        public string KerberosRealm { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.KerberosPasswordSecrets Secrets { get { throw null; } set { } }
    }
    public partial class KerberosPasswordSecrets : Azure.ResourceManager.MachineLearningServices.Models.DatastoreSecrets
    {
        public KerberosPasswordSecrets() { }
        public string KerberosPassword { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KeyType : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.KeyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KeyType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.KeyType Primary { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.KeyType Secondary { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.KeyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.KeyType left, Azure.ResourceManager.MachineLearningServices.Models.KeyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.KeyType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.KeyType left, Azure.ResourceManager.MachineLearningServices.Models.KeyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Kubernetes : Azure.ResourceManager.MachineLearningServices.Models.Compute
    {
        public Kubernetes() { }
        public Azure.ResourceManager.MachineLearningServices.Models.KubernetesProperties Properties { get { throw null; } set { } }
    }
    public partial class KubernetesOnlineDeployment : Azure.ResourceManager.MachineLearningServices.Models.OnlineDeploymentDetails
    {
        public KubernetesOnlineDeployment() { }
        public Azure.ResourceManager.MachineLearningServices.Models.ContainerResourceRequirements ContainerResourceRequirements { get { throw null; } set { } }
    }
    public partial class KubernetesProperties
    {
        public KubernetesProperties() { }
        public string DefaultInstanceType { get { throw null; } set { } }
        public string ExtensionInstanceReleaseTrain { get { throw null; } set { } }
        public string ExtensionPrincipalId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.MachineLearningServices.Models.InstanceTypeSchema> InstanceTypes { get { throw null; } }
        public string Namespace { get { throw null; } set { } }
        public string RelayConnectionString { get { throw null; } set { } }
        public string ServiceBusConnectionString { get { throw null; } set { } }
        public string VcName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LearningRateScheduler : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.LearningRateScheduler>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LearningRateScheduler(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.LearningRateScheduler None { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.LearningRateScheduler Step { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.LearningRateScheduler WarmupCosine { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.LearningRateScheduler other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.LearningRateScheduler left, Azure.ResourceManager.MachineLearningServices.Models.LearningRateScheduler right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.LearningRateScheduler (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.LearningRateScheduler left, Azure.ResourceManager.MachineLearningServices.Models.LearningRateScheduler right) { throw null; }
        public override string ToString() { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ListViewType : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.ListViewType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ListViewType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.ListViewType ActiveOnly { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ListViewType All { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ListViewType ArchivedOnly { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.ListViewType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.ListViewType left, Azure.ResourceManager.MachineLearningServices.Models.ListViewType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.ListViewType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.ListViewType left, Azure.ResourceManager.MachineLearningServices.Models.ListViewType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ListWorkspaceKeysResult
    {
        internal ListWorkspaceKeysResult() { }
        public string AppInsightsInstrumentationKey { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.RegistryListCredentialsResult ContainerRegistryCredentials { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.ListNotebookKeysResult NotebookAccessKeys { get { throw null; } }
        public string UserStorageKey { get { throw null; } }
        public string UserStorageResourceId { get { throw null; } }
    }
    public partial class LiteralJobInput : Azure.ResourceManager.MachineLearningServices.Models.JobInput
    {
        public LiteralJobInput(string value) { }
        public string Value { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LoadBalancerType : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.LoadBalancerType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LoadBalancerType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.LoadBalancerType InternalLoadBalancer { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.LoadBalancerType PublicIp { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.LoadBalancerType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.LoadBalancerType left, Azure.ResourceManager.MachineLearningServices.Models.LoadBalancerType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.LoadBalancerType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.LoadBalancerType left, Azure.ResourceManager.MachineLearningServices.Models.LoadBalancerType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LogVerbosity : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.LogVerbosity>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LogVerbosity(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.LogVerbosity Critical { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.LogVerbosity Debug { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.LogVerbosity Error { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.LogVerbosity Info { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.LogVerbosity NotSet { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.LogVerbosity Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.LogVerbosity other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.LogVerbosity left, Azure.ResourceManager.MachineLearningServices.Models.LogVerbosity right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.LogVerbosity (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.LogVerbosity left, Azure.ResourceManager.MachineLearningServices.Models.LogVerbosity right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MachineLearningServicesSku
    {
        public MachineLearningServicesSku(string name) { }
        public int? Capacity { get { throw null; } set { } }
        public string Family { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Size { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.MachineLearningServicesSkuTier? Tier { get { throw null; } set { } }
    }
    public enum MachineLearningServicesSkuTier
    {
        Free = 0,
        Basic = 1,
        Standard = 2,
        Premium = 3,
    }
    public partial class MachineLearningServicesUsage
    {
        internal MachineLearningServicesUsage() { }
        public string AmlWorkspaceLocation { get { throw null; } }
        public long? CurrentValue { get { throw null; } }
        public string Id { get { throw null; } }
        public long? Limit { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.UsageName Name { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.UsageUnit? Unit { get { throw null; } }
        public string UsageType { get { throw null; } }
    }
    public partial class ManagedOnlineDeployment : Azure.ResourceManager.MachineLearningServices.Models.OnlineDeploymentDetails
    {
        public ManagedOnlineDeployment() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedServiceIdentityType : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.ManagedServiceIdentityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedServiceIdentityType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.ManagedServiceIdentityType None { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ManagedServiceIdentityType SystemAssigned { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ManagedServiceIdentityType SystemAssignedUserAssigned { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ManagedServiceIdentityType UserAssigned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.ManagedServiceIdentityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.ManagedServiceIdentityType left, Azure.ResourceManager.MachineLearningServices.Models.ManagedServiceIdentityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.ManagedServiceIdentityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.ManagedServiceIdentityType left, Azure.ResourceManager.MachineLearningServices.Models.ManagedServiceIdentityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MedianStoppingPolicy : Azure.ResourceManager.MachineLearningServices.Models.EarlyTerminationPolicy
    {
        public MedianStoppingPolicy() { }
    }
    public partial class MLFlowModelJobInput : Azure.ResourceManager.MachineLearningServices.Models.JobInput
    {
        public MLFlowModelJobInput(System.Uri uri) { }
        public Azure.ResourceManager.MachineLearningServices.Models.InputDeliveryMode? Mode { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    public partial class MLFlowModelJobOutput : Azure.ResourceManager.MachineLearningServices.Models.JobOutput
    {
        public MLFlowModelJobOutput() { }
        public Azure.ResourceManager.MachineLearningServices.Models.OutputDeliveryMode? Mode { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    public partial class MLTableData : Azure.ResourceManager.MachineLearningServices.Models.DataVersionBaseDetails
    {
        public MLTableData(System.Uri dataUri) : base (default(System.Uri)) { }
        public System.Collections.Generic.IList<System.Uri> ReferencedUris { get { throw null; } set { } }
    }
    public partial class MLTableJobInput : Azure.ResourceManager.MachineLearningServices.Models.JobInput
    {
        public MLTableJobInput(System.Uri uri) { }
        public Azure.ResourceManager.MachineLearningServices.Models.InputDeliveryMode? Mode { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    public partial class MLTableJobOutput : Azure.ResourceManager.MachineLearningServices.Models.JobOutput
    {
        public MLTableJobOutput() { }
        public Azure.ResourceManager.MachineLearningServices.Models.OutputDeliveryMode? Mode { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    public partial class ModelContainerDetails : Azure.ResourceManager.MachineLearningServices.Models.AssetContainer
    {
        public ModelContainerDetails() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ModelSize : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.ModelSize>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ModelSize(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.ModelSize ExtraLarge { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ModelSize Large { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ModelSize Medium { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ModelSize None { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ModelSize Small { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.ModelSize other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.ModelSize left, Azure.ResourceManager.MachineLearningServices.Models.ModelSize right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.ModelSize (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.ModelSize left, Azure.ResourceManager.MachineLearningServices.Models.ModelSize right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ModelType : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.ModelType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ModelType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.ModelType CustomModel { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ModelType MLFlowModel { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ModelType TritonModel { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.ModelType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.ModelType left, Azure.ResourceManager.MachineLearningServices.Models.ModelType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.ModelType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.ModelType left, Azure.ResourceManager.MachineLearningServices.Models.ModelType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ModelVersionDetails : Azure.ResourceManager.MachineLearningServices.Models.AssetBase
    {
        public ModelVersionDetails() { }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.MachineLearningServices.Models.FlavorData> Flavors { get { throw null; } set { } }
        public string JobName { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.ModelType? ModelType { get { throw null; } set { } }
        public System.Uri ModelUri { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MountAction : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.MountAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MountAction(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.MountAction Mount { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.MountAction Unmount { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.MountAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.MountAction left, Azure.ResourceManager.MachineLearningServices.Models.MountAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.MountAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.MountAction left, Azure.ResourceManager.MachineLearningServices.Models.MountAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MountState : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.MountState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MountState(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.MountState Mounted { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.MountState MountFailed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.MountState MountRequested { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.MountState Unmounted { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.MountState UnmountFailed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.MountState UnmountRequested { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.MountState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.MountState left, Azure.ResourceManager.MachineLearningServices.Models.MountState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.MountState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.MountState left, Azure.ResourceManager.MachineLearningServices.Models.MountState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Network : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.Network>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Network(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.Network Bridge { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.Network Host { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.Network other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.Network left, Azure.ResourceManager.MachineLearningServices.Models.Network right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.Network (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.Network left, Azure.ResourceManager.MachineLearningServices.Models.Network right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NlpVerticalDataSettings : Azure.ResourceManager.MachineLearningServices.Models.DataSettings
    {
        public NlpVerticalDataSettings(string targetColumnName, Azure.ResourceManager.MachineLearningServices.Models.TrainingDataSettings trainingDataSettings) : base (default(string), default(Azure.ResourceManager.MachineLearningServices.Models.TrainingDataSettings)) { }
        public Azure.ResourceManager.MachineLearningServices.Models.NlpVerticalValidationDataSettings ValidationData { get { throw null; } set { } }
    }
    public partial class NlpVerticalLimitSettings
    {
        public NlpVerticalLimitSettings() { }
        public int? MaxConcurrentTrials { get { throw null; } set { } }
        public int? MaxTrials { get { throw null; } set { } }
        public System.TimeSpan? Timeout { get { throw null; } set { } }
    }
    public partial class NlpVerticalValidationDataSettings : Azure.ResourceManager.MachineLearningServices.Models.ValidationDataSettings
    {
        public NlpVerticalValidationDataSettings() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NodeState : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.NodeState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NodeState(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.NodeState Idle { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.NodeState Leaving { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.NodeState Preempted { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.NodeState Preparing { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.NodeState Running { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.NodeState Unusable { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.NodeState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.NodeState left, Azure.ResourceManager.MachineLearningServices.Models.NodeState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.NodeState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.NodeState left, Azure.ResourceManager.MachineLearningServices.Models.NodeState right) { throw null; }
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
    public partial class NoneDatastoreCredentials : Azure.ResourceManager.MachineLearningServices.Models.DatastoreCredentials
    {
        public NoneDatastoreCredentials() { }
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
        public Azure.ResourceManager.MachineLearningServices.Models.NotebookPreparationError NotebookPreparationError { get { throw null; } }
        public string ResourceId { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ObjectDetectionPrimaryMetrics : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.ObjectDetectionPrimaryMetrics>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ObjectDetectionPrimaryMetrics(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.ObjectDetectionPrimaryMetrics MeanAveragePrecision { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.ObjectDetectionPrimaryMetrics other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.ObjectDetectionPrimaryMetrics left, Azure.ResourceManager.MachineLearningServices.Models.ObjectDetectionPrimaryMetrics right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.ObjectDetectionPrimaryMetrics (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.ObjectDetectionPrimaryMetrics left, Azure.ResourceManager.MachineLearningServices.Models.ObjectDetectionPrimaryMetrics right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Objective
    {
        public Objective(Azure.ResourceManager.MachineLearningServices.Models.Goal goal, string primaryMetric) { }
        public Azure.ResourceManager.MachineLearningServices.Models.Goal Goal { get { throw null; } set { } }
        public string PrimaryMetric { get { throw null; } set { } }
    }
    public partial class OnlineDeploymentDataPatch
    {
        public OnlineDeploymentDataPatch() { }
        public Azure.ResourceManager.MachineLearningServices.Models.PartialManagedServiceIdentity Identity { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public string Location { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.PartialSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class OnlineDeploymentDetails : Azure.ResourceManager.MachineLearningServices.Models.EndpointDeploymentPropertiesBase
    {
        public OnlineDeploymentDetails() { }
        public bool? AppInsightsEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.EgressPublicNetworkAccessType? EgressPublicNetworkAccess { get { throw null; } set { } }
        public string InstanceType { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.ProbeSettings LivenessProbe { get { throw null; } set { } }
        public string Model { get { throw null; } set { } }
        public string ModelMountPath { get { throw null; } set { } }
        public bool? PrivateNetworkConnection { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.DeploymentProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.ProbeSettings ReadinessProbe { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.OnlineRequestSettings RequestSettings { get { throw null; } set { } }
    }
    public partial class OnlineEndpointDataPatch
    {
        public OnlineEndpointDataPatch() { }
        public Azure.ResourceManager.MachineLearningServices.Models.PartialManagedServiceIdentity Identity { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public string Location { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.PartialOnlineEndpoint Properties { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.PartialSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class OnlineEndpointDetails : Azure.ResourceManager.MachineLearningServices.Models.EndpointPropertiesBase
    {
        public OnlineEndpointDetails(Azure.ResourceManager.MachineLearningServices.Models.EndpointAuthMode authMode) : base (default(Azure.ResourceManager.MachineLearningServices.Models.EndpointAuthMode)) { }
        public string Compute { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, int> MirrorTraffic { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.EndpointProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.PublicNetworkAccessType? PublicNetworkAccess { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, int> Traffic { get { throw null; } set { } }
    }
    public partial class OnlineRequestSettings
    {
        public OnlineRequestSettings() { }
        public int? MaxConcurrentRequestsPerInstance { get { throw null; } set { } }
        public System.TimeSpan? MaxQueueWait { get { throw null; } set { } }
        public System.TimeSpan? RequestTimeout { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperatingSystemType : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.OperatingSystemType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperatingSystemType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.OperatingSystemType Linux { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.OperatingSystemType Windows { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.OperatingSystemType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.OperatingSystemType left, Azure.ResourceManager.MachineLearningServices.Models.OperatingSystemType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.OperatingSystemType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.OperatingSystemType left, Azure.ResourceManager.MachineLearningServices.Models.OperatingSystemType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperationName : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.OperationName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperationName(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.OperationName Create { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.OperationName Delete { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.OperationName Reimage { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.OperationName Restart { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.OperationName Start { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.OperationName Stop { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.OperationName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.OperationName left, Azure.ResourceManager.MachineLearningServices.Models.OperationName right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.OperationName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.OperationName left, Azure.ResourceManager.MachineLearningServices.Models.OperationName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperationStatus : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.OperationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperationStatus(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.OperationStatus CreateFailed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.OperationStatus DeleteFailed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.OperationStatus InProgress { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.OperationStatus ReimageFailed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.OperationStatus RestartFailed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.OperationStatus StartFailed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.OperationStatus StopFailed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.OperationStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.OperationStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.OperationStatus left, Azure.ResourceManager.MachineLearningServices.Models.OperationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.OperationStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.OperationStatus left, Azure.ResourceManager.MachineLearningServices.Models.OperationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperationTrigger : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.OperationTrigger>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperationTrigger(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.OperationTrigger IdleShutdown { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.OperationTrigger Schedule { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.OperationTrigger User { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.OperationTrigger other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.OperationTrigger left, Azure.ResourceManager.MachineLearningServices.Models.OperationTrigger right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.OperationTrigger (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.OperationTrigger left, Azure.ResourceManager.MachineLearningServices.Models.OperationTrigger right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OrderString : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.OrderString>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OrderString(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.OrderString CreatedAtAsc { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.OrderString CreatedAtDesc { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.OrderString UpdatedAtAsc { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.OrderString UpdatedAtDesc { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.OrderString other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.OrderString left, Azure.ResourceManager.MachineLearningServices.Models.OrderString right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.OrderString (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.OrderString left, Azure.ResourceManager.MachineLearningServices.Models.OrderString right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OsType : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.OsType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OsType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.OsType Linux { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.OsType Windows { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.OsType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.OsType left, Azure.ResourceManager.MachineLearningServices.Models.OsType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.OsType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.OsType left, Azure.ResourceManager.MachineLearningServices.Models.OsType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OutputDeliveryMode : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.OutputDeliveryMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OutputDeliveryMode(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.OutputDeliveryMode ReadWriteMount { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.OutputDeliveryMode Upload { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.OutputDeliveryMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.OutputDeliveryMode left, Azure.ResourceManager.MachineLearningServices.Models.OutputDeliveryMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.OutputDeliveryMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.OutputDeliveryMode left, Azure.ResourceManager.MachineLearningServices.Models.OutputDeliveryMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OutputPathAssetReference : Azure.ResourceManager.MachineLearningServices.Models.AssetReferenceBase
    {
        public OutputPathAssetReference() { }
        public string JobId { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
    }
    public partial class PartialBatchDeployment
    {
        public PartialBatchDeployment() { }
        public Azure.ResourceManager.MachineLearningServices.Models.PartialCodeConfiguration CodeConfiguration { get { throw null; } set { } }
        public string Compute { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string EnvironmentId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> EnvironmentVariables { get { throw null; } set { } }
        public int? ErrorThreshold { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.BatchLoggingLevel? LoggingLevel { get { throw null; } set { } }
        public int? MaxConcurrencyPerInstance { get { throw null; } set { } }
        public long? MiniBatchSize { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.BatchOutputAction? OutputAction { get { throw null; } set { } }
        public string OutputFileName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Properties { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.PartialBatchRetrySettings RetrySettings { get { throw null; } set { } }
    }
    public partial class PartialBatchRetrySettings
    {
        public PartialBatchRetrySettings() { }
        public int? MaxRetries { get { throw null; } set { } }
        public System.TimeSpan? Timeout { get { throw null; } set { } }
    }
    public partial class PartialCodeConfiguration
    {
        public PartialCodeConfiguration() { }
        public string CodeId { get { throw null; } set { } }
        public string ScoringScript { get { throw null; } set { } }
    }
    public partial class PartialManagedServiceIdentity
    {
        public PartialManagedServiceIdentity() { }
        public Azure.ResourceManager.MachineLearningServices.Models.ManagedServiceIdentityType? ManagedServiceIdentityType { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> UserAssignedIdentities { get { throw null; } }
    }
    public partial class PartialOnlineEndpoint
    {
        public PartialOnlineEndpoint() { }
        public System.Collections.Generic.IDictionary<string, int> MirrorTraffic { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.PublicNetworkAccessType? PublicNetworkAccess { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, int> Traffic { get { throw null; } set { } }
    }
    public partial class PartialSku
    {
        public PartialSku() { }
        public int? Capacity { get { throw null; } set { } }
        public string Family { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Size { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.MachineLearningServicesSkuTier? Tier { get { throw null; } set { } }
    }
    public partial class Password
    {
        internal Password() { }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class PipelineJob : Azure.ResourceManager.MachineLearningServices.Models.JobBaseDetails
    {
        public PipelineJob() { }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.MachineLearningServices.Models.JobInput> Inputs { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Jobs { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.MachineLearningServices.Models.JobOutput> Outputs { get { throw null; } set { } }
        public System.BinaryData Settings { get { throw null; } set { } }
    }
    public partial class PrivateEndpoint
    {
        public PrivateEndpoint() { }
        public string Id { get { throw null; } }
        public string SubnetArmId { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PrivateEndpointConnectionProvisioningState : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.PrivateEndpointConnectionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PrivateEndpointConnectionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.PrivateEndpointConnectionProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.PrivateEndpointConnectionProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.PrivateEndpointConnectionProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.PrivateEndpointConnectionProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.PrivateEndpointConnectionProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.PrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.MachineLearningServices.Models.PrivateEndpointConnectionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.PrivateEndpointConnectionProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.PrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.MachineLearningServices.Models.PrivateEndpointConnectionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PrivateEndpointServiceConnectionStatus : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.PrivateEndpointServiceConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PrivateEndpointServiceConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.PrivateEndpointServiceConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.PrivateEndpointServiceConnectionStatus Disconnected { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.PrivateEndpointServiceConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.PrivateEndpointServiceConnectionStatus Rejected { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.PrivateEndpointServiceConnectionStatus Timeout { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.PrivateEndpointServiceConnectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.PrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.MachineLearningServices.Models.PrivateEndpointServiceConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.PrivateEndpointServiceConnectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.PrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.MachineLearningServices.Models.PrivateEndpointServiceConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PrivateLinkResource : Azure.ResourceManager.Models.ResourceData
    {
        public PrivateLinkResource() { }
        public string GroupId { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public string Location { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredZoneNames { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.MachineLearningServicesSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class PrivateLinkServiceConnectionState
    {
        public PrivateLinkServiceConnectionState() { }
        public string ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.PrivateEndpointServiceConnectionStatus? Status { get { throw null; } set { } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ProvisioningState Unknown { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.ProvisioningState left, Azure.ResourceManager.MachineLearningServices.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.ProvisioningState left, Azure.ResourceManager.MachineLearningServices.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningStatus : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.ProvisioningStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningStatus(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.ProvisioningStatus Completed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ProvisioningStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ProvisioningStatus Provisioning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.ProvisioningStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.ProvisioningStatus left, Azure.ResourceManager.MachineLearningServices.Models.ProvisioningStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.ProvisioningStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.ProvisioningStatus left, Azure.ResourceManager.MachineLearningServices.Models.ProvisioningStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PublicNetworkAccess : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.PublicNetworkAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PublicNetworkAccess(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.PublicNetworkAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.PublicNetworkAccess Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.PublicNetworkAccess other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.PublicNetworkAccess left, Azure.ResourceManager.MachineLearningServices.Models.PublicNetworkAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.PublicNetworkAccess (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.PublicNetworkAccess left, Azure.ResourceManager.MachineLearningServices.Models.PublicNetworkAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PublicNetworkAccessType : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.PublicNetworkAccessType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PublicNetworkAccessType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.PublicNetworkAccessType Disabled { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.PublicNetworkAccessType Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.PublicNetworkAccessType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.PublicNetworkAccessType left, Azure.ResourceManager.MachineLearningServices.Models.PublicNetworkAccessType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.PublicNetworkAccessType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.PublicNetworkAccessType left, Azure.ResourceManager.MachineLearningServices.Models.PublicNetworkAccessType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class QuotaBaseProperties
    {
        public QuotaBaseProperties() { }
        public string Id { get { throw null; } set { } }
        public long? Limit { get { throw null; } set { } }
        public string QuotaBasePropertiesType { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.QuotaUnit? Unit { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct QuotaUnit : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.QuotaUnit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public QuotaUnit(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.QuotaUnit Count { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.QuotaUnit other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.QuotaUnit left, Azure.ResourceManager.MachineLearningServices.Models.QuotaUnit right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.QuotaUnit (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.QuotaUnit left, Azure.ResourceManager.MachineLearningServices.Models.QuotaUnit right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class QuotaUpdateContent
    {
        public QuotaUpdateContent() { }
        public string Location { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.MachineLearningServices.Models.QuotaBaseProperties> Value { get { throw null; } }
    }
    public partial class RandomSamplingAlgorithm : Azure.ResourceManager.MachineLearningServices.Models.SamplingAlgorithm
    {
        public RandomSamplingAlgorithm() { }
        public Azure.ResourceManager.MachineLearningServices.Models.RandomSamplingAlgorithmRule? Rule { get { throw null; } set { } }
        public int? Seed { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RandomSamplingAlgorithmRule : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.RandomSamplingAlgorithmRule>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RandomSamplingAlgorithmRule(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.RandomSamplingAlgorithmRule Random { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.RandomSamplingAlgorithmRule Sobol { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.RandomSamplingAlgorithmRule other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.RandomSamplingAlgorithmRule left, Azure.ResourceManager.MachineLearningServices.Models.RandomSamplingAlgorithmRule right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.RandomSamplingAlgorithmRule (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.RandomSamplingAlgorithmRule left, Azure.ResourceManager.MachineLearningServices.Models.RandomSamplingAlgorithmRule right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RecurrenceFrequency : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.RecurrenceFrequency>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecurrenceFrequency(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.RecurrenceFrequency Day { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.RecurrenceFrequency Hour { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.RecurrenceFrequency Minute { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.RecurrenceFrequency Month { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.RecurrenceFrequency Week { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.RecurrenceFrequency other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.RecurrenceFrequency left, Azure.ResourceManager.MachineLearningServices.Models.RecurrenceFrequency right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.RecurrenceFrequency (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.RecurrenceFrequency left, Azure.ResourceManager.MachineLearningServices.Models.RecurrenceFrequency right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RecurrencePattern
    {
        public RecurrencePattern(System.Collections.Generic.IEnumerable<int> hours, System.Collections.Generic.IEnumerable<int> minutes) { }
        public System.Collections.Generic.IList<int> Hours { get { throw null; } }
        public System.Collections.Generic.IList<int> Minutes { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.MachineLearningServices.Models.Weekday> Weekdays { get { throw null; } set { } }
    }
    public partial class RecurrenceSchedule : Azure.ResourceManager.MachineLearningServices.Models.ScheduleBase
    {
        public RecurrenceSchedule(Azure.ResourceManager.MachineLearningServices.Models.RecurrenceFrequency frequency, int interval) { }
        public Azure.ResourceManager.MachineLearningServices.Models.RecurrenceFrequency Frequency { get { throw null; } set { } }
        public int Interval { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.RecurrencePattern Pattern { get { throw null; } set { } }
    }
    public partial class RegenerateEndpointKeysContent
    {
        public RegenerateEndpointKeysContent(Azure.ResourceManager.MachineLearningServices.Models.KeyType keyType) { }
        public Azure.ResourceManager.MachineLearningServices.Models.KeyType KeyType { get { throw null; } }
        public string KeyValue { get { throw null; } set { } }
    }
    public partial class RegistryListCredentialsResult
    {
        internal RegistryListCredentialsResult() { }
        public string Location { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearningServices.Models.Password> Passwords { get { throw null; } }
        public string Username { get { throw null; } }
    }
    public partial class Regression : Azure.ResourceManager.MachineLearningServices.Models.AutoMLVertical
    {
        public Regression() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.MachineLearningServices.Models.RegressionModels> AllowedModels { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.MachineLearningServices.Models.RegressionModels> BlockedModels { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.TableVerticalDataSettings DataSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.TableVerticalFeaturizationSettings FeaturizationSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.TableVerticalLimitSettings LimitSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.RegressionPrimaryMetrics? PrimaryMetric { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.TrainingSettings TrainingSettings { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RegressionModels : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.RegressionModels>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RegressionModels(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.RegressionModels DecisionTree { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.RegressionModels ElasticNet { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.RegressionModels ExtremeRandomTrees { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.RegressionModels GradientBoosting { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.RegressionModels KNN { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.RegressionModels LassoLars { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.RegressionModels LightGBM { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.RegressionModels RandomForest { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.RegressionModels SGD { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.RegressionModels XGBoostRegressor { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.RegressionModels other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.RegressionModels left, Azure.ResourceManager.MachineLearningServices.Models.RegressionModels right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.RegressionModels (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.RegressionModels left, Azure.ResourceManager.MachineLearningServices.Models.RegressionModels right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RegressionPrimaryMetrics : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.RegressionPrimaryMetrics>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RegressionPrimaryMetrics(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.RegressionPrimaryMetrics NormalizedMeanAbsoluteError { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.RegressionPrimaryMetrics NormalizedRootMeanSquaredError { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.RegressionPrimaryMetrics R2Score { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.RegressionPrimaryMetrics SpearmanCorrelation { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.RegressionPrimaryMetrics other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.RegressionPrimaryMetrics left, Azure.ResourceManager.MachineLearningServices.Models.RegressionPrimaryMetrics right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.RegressionPrimaryMetrics (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.RegressionPrimaryMetrics left, Azure.ResourceManager.MachineLearningServices.Models.RegressionPrimaryMetrics right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RemoteLoginPortPublicAccess : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.RemoteLoginPortPublicAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RemoteLoginPortPublicAccess(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.RemoteLoginPortPublicAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.RemoteLoginPortPublicAccess Enabled { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.RemoteLoginPortPublicAccess NotSpecified { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.RemoteLoginPortPublicAccess other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.RemoteLoginPortPublicAccess left, Azure.ResourceManager.MachineLearningServices.Models.RemoteLoginPortPublicAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.RemoteLoginPortPublicAccess (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.RemoteLoginPortPublicAccess left, Azure.ResourceManager.MachineLearningServices.Models.RemoteLoginPortPublicAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResourceBase
    {
        public ResourceBase() { }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } set { } }
    }
    public partial class ResourceConfiguration
    {
        public ResourceConfiguration() { }
        public int? InstanceCount { get { throw null; } set { } }
        public string InstanceType { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Properties { get { throw null; } set { } }
    }
    public partial class ResourceName
    {
        internal ResourceName() { }
        public string LocalizedValue { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class ResourceQuota
    {
        internal ResourceQuota() { }
        public string AmlWorkspaceLocation { get { throw null; } }
        public string Id { get { throw null; } }
        public long? Limit { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.ResourceName Name { get { throw null; } }
        public string ResourceQuotaType { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.QuotaUnit? Unit { get { throw null; } }
    }
    public partial class Route
    {
        public Route(string path, int port) { }
        public string Path { get { throw null; } set { } }
        public int Port { get { throw null; } set { } }
    }
    public partial class SamplingAlgorithm
    {
        public SamplingAlgorithm() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SamplingAlgorithmType : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.SamplingAlgorithmType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SamplingAlgorithmType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.SamplingAlgorithmType Bayesian { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.SamplingAlgorithmType Grid { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.SamplingAlgorithmType Random { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.SamplingAlgorithmType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.SamplingAlgorithmType left, Azure.ResourceManager.MachineLearningServices.Models.SamplingAlgorithmType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.SamplingAlgorithmType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.SamplingAlgorithmType left, Azure.ResourceManager.MachineLearningServices.Models.SamplingAlgorithmType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SasDatastoreCredentials : Azure.ResourceManager.MachineLearningServices.Models.DatastoreCredentials
    {
        public SasDatastoreCredentials(Azure.ResourceManager.MachineLearningServices.Models.SasDatastoreSecrets secrets) { }
        public Azure.ResourceManager.MachineLearningServices.Models.SasDatastoreSecrets Secrets { get { throw null; } set { } }
    }
    public partial class SasDatastoreSecrets : Azure.ResourceManager.MachineLearningServices.Models.DatastoreSecrets
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
    public partial class ScheduleBase
    {
        public ScheduleBase() { }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.ScheduleStatus? ScheduleStatus { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        public string TimeZone { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScheduleStatus : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.ScheduleStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScheduleStatus(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.ScheduleStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ScheduleStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.ScheduleStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.ScheduleStatus left, Azure.ResourceManager.MachineLearningServices.Models.ScheduleStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.ScheduleStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.ScheduleStatus left, Azure.ResourceManager.MachineLearningServices.Models.ScheduleStatus right) { throw null; }
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
        public Azure.ResourceManager.MachineLearningServices.Models.ScriptReference CreationScript { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.ScriptReference StartupScript { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServiceDataAccessAuthIdentity : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.ServiceDataAccessAuthIdentity>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServiceDataAccessAuthIdentity(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.ServiceDataAccessAuthIdentity None { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ServiceDataAccessAuthIdentity WorkspaceSystemAssignedIdentity { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ServiceDataAccessAuthIdentity WorkspaceUserAssignedIdentity { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.ServiceDataAccessAuthIdentity other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.ServiceDataAccessAuthIdentity left, Azure.ResourceManager.MachineLearningServices.Models.ServiceDataAccessAuthIdentity right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.ServiceDataAccessAuthIdentity (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.ServiceDataAccessAuthIdentity left, Azure.ResourceManager.MachineLearningServices.Models.ServiceDataAccessAuthIdentity right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ServicePrincipalDatastoreCredentials : Azure.ResourceManager.MachineLearningServices.Models.DatastoreCredentials
    {
        public ServicePrincipalDatastoreCredentials(System.Guid clientId, Azure.ResourceManager.MachineLearningServices.Models.ServicePrincipalDatastoreSecrets secrets, System.Guid tenantId) { }
        public System.Uri AuthorityUri { get { throw null; } set { } }
        public System.Guid ClientId { get { throw null; } set { } }
        public System.Uri ResourceUri { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.ServicePrincipalDatastoreSecrets Secrets { get { throw null; } set { } }
        public System.Guid TenantId { get { throw null; } set { } }
    }
    public partial class ServicePrincipalDatastoreSecrets : Azure.ResourceManager.MachineLearningServices.Models.DatastoreSecrets
    {
        public ServicePrincipalDatastoreSecrets() { }
        public string ClientSecret { get { throw null; } set { } }
    }
    public partial class SharedPrivateLinkResource
    {
        public SharedPrivateLinkResource() { }
        public string GroupId { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string PrivateLinkResourceId { get { throw null; } set { } }
        public string RequestMessage { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.PrivateEndpointServiceConnectionStatus? Status { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ShortSeriesHandlingConfiguration : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.ShortSeriesHandlingConfiguration>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ShortSeriesHandlingConfiguration(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.ShortSeriesHandlingConfiguration Auto { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ShortSeriesHandlingConfiguration Drop { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ShortSeriesHandlingConfiguration None { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ShortSeriesHandlingConfiguration Pad { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.ShortSeriesHandlingConfiguration other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.ShortSeriesHandlingConfiguration left, Azure.ResourceManager.MachineLearningServices.Models.ShortSeriesHandlingConfiguration right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.ShortSeriesHandlingConfiguration (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.ShortSeriesHandlingConfiguration left, Azure.ResourceManager.MachineLearningServices.Models.ShortSeriesHandlingConfiguration right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SkuCapacity
    {
        internal SkuCapacity() { }
        public int? Default { get { throw null; } }
        public int? Maximum { get { throw null; } }
        public int? Minimum { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.SkuScaleType? ScaleType { get { throw null; } }
    }
    public partial class SkuResource
    {
        internal SkuResource() { }
        public Azure.ResourceManager.MachineLearningServices.Models.SkuCapacity Capacity { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.SkuSetting Sku { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SkuScaleType : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.SkuScaleType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SkuScaleType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.SkuScaleType Automatic { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.SkuScaleType Manual { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.SkuScaleType None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.SkuScaleType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.SkuScaleType left, Azure.ResourceManager.MachineLearningServices.Models.SkuScaleType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.SkuScaleType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.SkuScaleType left, Azure.ResourceManager.MachineLearningServices.Models.SkuScaleType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SkuSetting
    {
        internal SkuSetting() { }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.MachineLearningServicesSkuTier? Tier { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SourceType : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.SourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SourceType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.SourceType Dataset { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.SourceType Datastore { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.SourceType URI { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.SourceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.SourceType left, Azure.ResourceManager.MachineLearningServices.Models.SourceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.SourceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.SourceType left, Azure.ResourceManager.MachineLearningServices.Models.SourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SshPublicAccess : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.SshPublicAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SshPublicAccess(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.SshPublicAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.SshPublicAccess Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.SshPublicAccess other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.SshPublicAccess left, Azure.ResourceManager.MachineLearningServices.Models.SshPublicAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.SshPublicAccess (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.SshPublicAccess left, Azure.ResourceManager.MachineLearningServices.Models.SshPublicAccess right) { throw null; }
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
        public Azure.ResourceManager.MachineLearningServices.Models.SslConfigurationStatus? Status { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SslConfigurationStatus : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.SslConfigurationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SslConfigurationStatus(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.SslConfigurationStatus Auto { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.SslConfigurationStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.SslConfigurationStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.SslConfigurationStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.SslConfigurationStatus left, Azure.ResourceManager.MachineLearningServices.Models.SslConfigurationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.SslConfigurationStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.SslConfigurationStatus left, Azure.ResourceManager.MachineLearningServices.Models.SslConfigurationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StackEnsembleSettings
    {
        public StackEnsembleSettings() { }
        public System.BinaryData StackMetaLearnerKWargs { get { throw null; } set { } }
        public double? StackMetaLearnerTrainPercentage { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.StackMetaLearnerType? StackMetaLearnerType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StackMetaLearnerType : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.StackMetaLearnerType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StackMetaLearnerType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.StackMetaLearnerType ElasticNet { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.StackMetaLearnerType ElasticNetCV { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.StackMetaLearnerType LightGBMClassifier { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.StackMetaLearnerType LightGBMRegressor { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.StackMetaLearnerType LinearRegression { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.StackMetaLearnerType LogisticRegression { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.StackMetaLearnerType LogisticRegressionCV { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.StackMetaLearnerType None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.StackMetaLearnerType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.StackMetaLearnerType left, Azure.ResourceManager.MachineLearningServices.Models.StackMetaLearnerType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.StackMetaLearnerType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.StackMetaLearnerType left, Azure.ResourceManager.MachineLearningServices.Models.StackMetaLearnerType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Status : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.Status>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Status(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.Status Failure { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.Status InvalidQuotaBelowClusterMinimum { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.Status InvalidQuotaExceedsSubscriptionLimit { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.Status InvalidVMFamilyName { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.Status OperationNotEnabledForRegion { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.Status OperationNotSupportedForSku { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.Status Success { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.Status Undefined { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.Status other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.Status left, Azure.ResourceManager.MachineLearningServices.Models.Status right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.Status (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.Status left, Azure.ResourceManager.MachineLearningServices.Models.Status right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StochasticOptimizer : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.StochasticOptimizer>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StochasticOptimizer(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.StochasticOptimizer Adam { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.StochasticOptimizer Adamw { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.StochasticOptimizer None { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.StochasticOptimizer Sgd { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.StochasticOptimizer other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.StochasticOptimizer left, Azure.ResourceManager.MachineLearningServices.Models.StochasticOptimizer right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.StochasticOptimizer (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.StochasticOptimizer left, Azure.ResourceManager.MachineLearningServices.Models.StochasticOptimizer right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageAccountType : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.StorageAccountType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageAccountType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.StorageAccountType PremiumLRS { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.StorageAccountType StandardLRS { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.StorageAccountType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.StorageAccountType left, Azure.ResourceManager.MachineLearningServices.Models.StorageAccountType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.StorageAccountType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.StorageAccountType left, Azure.ResourceManager.MachineLearningServices.Models.StorageAccountType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SweepJob : Azure.ResourceManager.MachineLearningServices.Models.JobBaseDetails
    {
        public SweepJob(Azure.ResourceManager.MachineLearningServices.Models.Objective objective, Azure.ResourceManager.MachineLearningServices.Models.SamplingAlgorithm samplingAlgorithm, System.BinaryData searchSpace, Azure.ResourceManager.MachineLearningServices.Models.TrialComponent trial) { }
        public Azure.ResourceManager.MachineLearningServices.Models.EarlyTerminationPolicy EarlyTermination { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.MachineLearningServices.Models.JobInput> Inputs { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.SweepJobLimits Limits { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.Objective Objective { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.MachineLearningServices.Models.JobOutput> Outputs { get { throw null; } set { } }
        public System.BinaryData SearchSpace { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.TrialComponent Trial { get { throw null; } set { } }
    }
    public partial class SweepJobLimits : Azure.ResourceManager.MachineLearningServices.Models.JobLimits
    {
        public SweepJobLimits() { }
        public int? MaxConcurrentTrials { get { throw null; } set { } }
        public int? MaxTotalTrials { get { throw null; } set { } }
        public System.TimeSpan? TrialTimeout { get { throw null; } set { } }
    }
    public partial class SynapseSpark : Azure.ResourceManager.MachineLearningServices.Models.Compute
    {
        public SynapseSpark() { }
        public Azure.ResourceManager.MachineLearningServices.Models.SynapseSparkProperties Properties { get { throw null; } set { } }
    }
    public partial class SynapseSparkProperties
    {
        public SynapseSparkProperties() { }
        public Azure.ResourceManager.MachineLearningServices.Models.AutoPauseProperties AutoPauseProperties { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.AutoScaleProperties AutoScaleProperties { get { throw null; } set { } }
        public int? NodeCount { get { throw null; } set { } }
        public string NodeSize { get { throw null; } set { } }
        public string NodeSizeFamily { get { throw null; } set { } }
        public string PoolName { get { throw null; } set { } }
        public string ResourceGroup { get { throw null; } set { } }
        public string SparkVersion { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
        public string WorkspaceName { get { throw null; } set { } }
    }
    public partial class SystemService
    {
        internal SystemService() { }
        public string PublicIpAddress { get { throw null; } }
        public string SystemServiceType { get { throw null; } }
        public string Version { get { throw null; } }
    }
    public partial class TableVerticalDataSettings : Azure.ResourceManager.MachineLearningServices.Models.DataSettings
    {
        public TableVerticalDataSettings(string targetColumnName, Azure.ResourceManager.MachineLearningServices.Models.TrainingDataSettings trainingDataSettings) : base (default(string), default(Azure.ResourceManager.MachineLearningServices.Models.TrainingDataSettings)) { }
        public Azure.ResourceManager.MachineLearningServices.Models.TableVerticalValidationDataSettings ValidationData { get { throw null; } set { } }
        public string WeightColumnName { get { throw null; } set { } }
    }
    public partial class TableVerticalFeaturizationSettings : Azure.ResourceManager.MachineLearningServices.Models.FeaturizationSettings
    {
        public TableVerticalFeaturizationSettings() { }
        public System.Collections.Generic.IList<string> BlockedTransformers { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> ColumnNameAndTypes { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> DropColumns { get { throw null; } set { } }
        public bool? EnableDnnFeaturization { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.FeaturizationMode? Mode { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.Collections.Generic.IList<Azure.ResourceManager.MachineLearningServices.Models.ColumnTransformer>> TransformerParams { get { throw null; } set { } }
    }
    public partial class TableVerticalLimitSettings
    {
        public TableVerticalLimitSettings() { }
        public bool? EnableEarlyTermination { get { throw null; } set { } }
        public double? ExitScore { get { throw null; } set { } }
        public int? MaxConcurrentTrials { get { throw null; } set { } }
        public int? MaxCoresPerTrial { get { throw null; } set { } }
        public int? MaxTrials { get { throw null; } set { } }
        public System.TimeSpan? Timeout { get { throw null; } set { } }
        public System.TimeSpan? TrialTimeout { get { throw null; } set { } }
    }
    public partial class TableVerticalValidationDataSettings : Azure.ResourceManager.MachineLearningServices.Models.ValidationDataSettings
    {
        public TableVerticalValidationDataSettings() { }
        public System.Collections.Generic.IList<string> CvSplitColumnNames { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TargetAggregationFunction : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.TargetAggregationFunction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TargetAggregationFunction(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.TargetAggregationFunction Max { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.TargetAggregationFunction Mean { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.TargetAggregationFunction Min { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.TargetAggregationFunction None { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.TargetAggregationFunction Sum { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.TargetAggregationFunction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.TargetAggregationFunction left, Azure.ResourceManager.MachineLearningServices.Models.TargetAggregationFunction right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.TargetAggregationFunction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.TargetAggregationFunction left, Azure.ResourceManager.MachineLearningServices.Models.TargetAggregationFunction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TestDataSettings
    {
        public TestDataSettings() { }
        public Azure.ResourceManager.MachineLearningServices.Models.MLTableJobInput Data { get { throw null; } set { } }
        public double? TestDataSize { get { throw null; } set { } }
    }
    public partial class TextClassification : Azure.ResourceManager.MachineLearningServices.Models.AutoMLVertical
    {
        public TextClassification() { }
        public Azure.ResourceManager.MachineLearningServices.Models.NlpVerticalDataSettings DataSettings { get { throw null; } set { } }
        public string FeaturizationDatasetLanguage { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.NlpVerticalLimitSettings LimitSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.ClassificationPrimaryMetrics? PrimaryMetric { get { throw null; } set { } }
    }
    public partial class TextClassificationMultilabel : Azure.ResourceManager.MachineLearningServices.Models.AutoMLVertical
    {
        public TextClassificationMultilabel() { }
        public Azure.ResourceManager.MachineLearningServices.Models.NlpVerticalDataSettings DataSettings { get { throw null; } set { } }
        public string FeaturizationDatasetLanguage { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.NlpVerticalLimitSettings LimitSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.ClassificationMultilabelPrimaryMetrics? PrimaryMetric { get { throw null; } }
    }
    public partial class TextNer : Azure.ResourceManager.MachineLearningServices.Models.AutoMLVertical
    {
        public TextNer() { }
        public Azure.ResourceManager.MachineLearningServices.Models.NlpVerticalDataSettings DataSettings { get { throw null; } set { } }
        public string FeaturizationDatasetLanguage { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.NlpVerticalLimitSettings LimitSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.ClassificationPrimaryMetrics? PrimaryMetric { get { throw null; } }
    }
    public partial class TrainingDataSettings
    {
        public TrainingDataSettings(Azure.ResourceManager.MachineLearningServices.Models.MLTableJobInput data) { }
        public Azure.ResourceManager.MachineLearningServices.Models.MLTableJobInput Data { get { throw null; } set { } }
    }
    public partial class TrainingSettings
    {
        public TrainingSettings() { }
        public bool? EnableDnnTraining { get { throw null; } set { } }
        public bool? EnableModelExplainability { get { throw null; } set { } }
        public bool? EnableOnnxCompatibleModels { get { throw null; } set { } }
        public bool? EnableStackEnsemble { get { throw null; } set { } }
        public bool? EnableVoteEnsemble { get { throw null; } set { } }
        public System.TimeSpan? EnsembleModelDownloadTimeout { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.StackEnsembleSettings StackEnsembleSettings { get { throw null; } set { } }
    }
    public partial class TrialComponent
    {
        public TrialComponent(string command, string environmentId) { }
        public string CodeId { get { throw null; } set { } }
        public string Command { get { throw null; } set { } }
        public string EnvironmentId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> EnvironmentVariables { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.ResourceConfiguration Resources { get { throw null; } set { } }
    }
    public partial class TritonModelJobInput : Azure.ResourceManager.MachineLearningServices.Models.JobInput
    {
        public TritonModelJobInput(System.Uri uri) { }
        public Azure.ResourceManager.MachineLearningServices.Models.InputDeliveryMode? Mode { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    public partial class TritonModelJobOutput : Azure.ResourceManager.MachineLearningServices.Models.JobOutput
    {
        public TritonModelJobOutput() { }
        public Azure.ResourceManager.MachineLearningServices.Models.OutputDeliveryMode? Mode { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    public partial class TruncationSelectionPolicy : Azure.ResourceManager.MachineLearningServices.Models.EarlyTerminationPolicy
    {
        public TruncationSelectionPolicy() { }
        public int? TruncationPercentage { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UnderlyingResourceAction : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.UnderlyingResourceAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UnderlyingResourceAction(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.UnderlyingResourceAction Delete { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.UnderlyingResourceAction Detach { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.UnderlyingResourceAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.UnderlyingResourceAction left, Azure.ResourceManager.MachineLearningServices.Models.UnderlyingResourceAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.UnderlyingResourceAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.UnderlyingResourceAction left, Azure.ResourceManager.MachineLearningServices.Models.UnderlyingResourceAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UnitOfMeasure : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.UnitOfMeasure>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UnitOfMeasure(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.UnitOfMeasure OneHour { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.UnitOfMeasure other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.UnitOfMeasure left, Azure.ResourceManager.MachineLearningServices.Models.UnitOfMeasure right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.UnitOfMeasure (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.UnitOfMeasure left, Azure.ResourceManager.MachineLearningServices.Models.UnitOfMeasure right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UpdateWorkspaceQuotas
    {
        internal UpdateWorkspaceQuotas() { }
        public string Id { get { throw null; } }
        public long? Limit { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.Status? Status { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.QuotaUnit? Unit { get { throw null; } }
        public string UpdateWorkspaceQuotasType { get { throw null; } }
    }
    public partial class UriFileDataVersion : Azure.ResourceManager.MachineLearningServices.Models.DataVersionBaseDetails
    {
        public UriFileDataVersion(System.Uri dataUri) : base (default(System.Uri)) { }
    }
    public partial class UriFileJobInput : Azure.ResourceManager.MachineLearningServices.Models.JobInput
    {
        public UriFileJobInput(System.Uri uri) { }
        public Azure.ResourceManager.MachineLearningServices.Models.InputDeliveryMode? Mode { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    public partial class UriFileJobOutput : Azure.ResourceManager.MachineLearningServices.Models.JobOutput
    {
        public UriFileJobOutput() { }
        public Azure.ResourceManager.MachineLearningServices.Models.OutputDeliveryMode? Mode { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    public partial class UriFolderDataVersion : Azure.ResourceManager.MachineLearningServices.Models.DataVersionBaseDetails
    {
        public UriFolderDataVersion(System.Uri dataUri) : base (default(System.Uri)) { }
    }
    public partial class UriFolderJobInput : Azure.ResourceManager.MachineLearningServices.Models.JobInput
    {
        public UriFolderJobInput(System.Uri uri) { }
        public Azure.ResourceManager.MachineLearningServices.Models.InputDeliveryMode? Mode { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    public partial class UriFolderJobOutput : Azure.ResourceManager.MachineLearningServices.Models.JobOutput
    {
        public UriFolderJobOutput() { }
        public Azure.ResourceManager.MachineLearningServices.Models.OutputDeliveryMode? Mode { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    public partial class UsageName
    {
        internal UsageName() { }
        public string LocalizedValue { get { throw null; } }
        public string Value { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UsageUnit : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.UsageUnit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UsageUnit(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.UsageUnit Count { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.UsageUnit other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.UsageUnit left, Azure.ResourceManager.MachineLearningServices.Models.UsageUnit right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.UsageUnit (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.UsageUnit left, Azure.ResourceManager.MachineLearningServices.Models.UsageUnit right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UserAccountCredentials
    {
        public UserAccountCredentials(string adminUserName) { }
        public string AdminUserName { get { throw null; } set { } }
        public string AdminUserPassword { get { throw null; } set { } }
        public string AdminUserSshPublicKey { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UseStl : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.UseStl>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UseStl(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.UseStl None { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.UseStl Season { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.UseStl SeasonTrend { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.UseStl other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.UseStl left, Azure.ResourceManager.MachineLearningServices.Models.UseStl right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.UseStl (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.UseStl left, Azure.ResourceManager.MachineLearningServices.Models.UseStl right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ValidationDataSettings
    {
        public ValidationDataSettings() { }
        public Azure.ResourceManager.MachineLearningServices.Models.MLTableJobInput Data { get { throw null; } set { } }
        public double? ValidationDataSize { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ValidationMetricType : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.ValidationMetricType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ValidationMetricType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.ValidationMetricType Coco { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ValidationMetricType CocoVoc { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ValidationMetricType None { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ValidationMetricType Voc { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.ValidationMetricType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.ValidationMetricType left, Azure.ResourceManager.MachineLearningServices.Models.ValidationMetricType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.ValidationMetricType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.ValidationMetricType left, Azure.ResourceManager.MachineLearningServices.Models.ValidationMetricType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ValueFormat : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.ValueFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ValueFormat(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.ValueFormat Json { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.ValueFormat other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.ValueFormat left, Azure.ResourceManager.MachineLearningServices.Models.ValueFormat right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.ValueFormat (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.ValueFormat left, Azure.ResourceManager.MachineLearningServices.Models.ValueFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VirtualMachine : Azure.ResourceManager.MachineLearningServices.Models.Compute
    {
        public VirtualMachine() { }
        public Azure.ResourceManager.MachineLearningServices.Models.VirtualMachineSchemaProperties Properties { get { throw null; } set { } }
    }
    public partial class VirtualMachineSchemaProperties
    {
        public VirtualMachineSchemaProperties() { }
        public string Address { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.VirtualMachineSshCredentials AdministratorAccount { get { throw null; } set { } }
        public bool? IsNotebookInstanceCompute { get { throw null; } set { } }
        public int? NotebookServerPort { get { throw null; } set { } }
        public int? SshPort { get { throw null; } set { } }
        public string VirtualMachineSize { get { throw null; } set { } }
    }
    public partial class VirtualMachineSecrets : Azure.ResourceManager.MachineLearningServices.Models.ComputeSecrets
    {
        internal VirtualMachineSecrets() { }
        public Azure.ResourceManager.MachineLearningServices.Models.VirtualMachineSshCredentials AdministratorAccount { get { throw null; } }
    }
    public partial class VirtualMachineSize
    {
        internal VirtualMachineSize() { }
        public Azure.ResourceManager.MachineLearningServices.Models.EstimatedVMPrices EstimatedVMPrices { get { throw null; } }
        public string Family { get { throw null; } }
        public int? Gpus { get { throw null; } }
        public bool? LowPriorityCapable { get { throw null; } }
        public int? MaxResourceVolumeMB { get { throw null; } }
        public double? MemoryGB { get { throw null; } }
        public string Name { get { throw null; } }
        public int? OsVhdSizeMB { get { throw null; } }
        public bool? PremiumIO { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SupportedComputeTypes { get { throw null; } }
        public int? VCPUs { get { throw null; } }
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
    public readonly partial struct VMPriceOSType : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.VMPriceOSType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VMPriceOSType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.VMPriceOSType Linux { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.VMPriceOSType Windows { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.VMPriceOSType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.VMPriceOSType left, Azure.ResourceManager.MachineLearningServices.Models.VMPriceOSType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.VMPriceOSType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.VMPriceOSType left, Azure.ResourceManager.MachineLearningServices.Models.VMPriceOSType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VmPriority : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.VmPriority>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VmPriority(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.VmPriority Dedicated { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.VmPriority LowPriority { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.VmPriority other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.VmPriority left, Azure.ResourceManager.MachineLearningServices.Models.VmPriority right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.VmPriority (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.VmPriority left, Azure.ResourceManager.MachineLearningServices.Models.VmPriority right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VMTier : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.VMTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VMTier(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.VMTier LowPriority { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.VMTier Spot { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.VMTier Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.VMTier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.VMTier left, Azure.ResourceManager.MachineLearningServices.Models.VMTier right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.VMTier (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.VMTier left, Azure.ResourceManager.MachineLearningServices.Models.VMTier right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Weekday : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.Weekday>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Weekday(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.Weekday Friday { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.Weekday Monday { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.Weekday Saturday { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.Weekday Sunday { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.Weekday Thursday { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.Weekday Tuesday { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.Weekday Wednesday { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.Weekday other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.Weekday left, Azure.ResourceManager.MachineLearningServices.Models.Weekday right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.Weekday (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.Weekday left, Azure.ResourceManager.MachineLearningServices.Models.Weekday right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WorkspacePatch
    {
        public WorkspacePatch() { }
        public string ApplicationInsights { get { throw null; } set { } }
        public string ContainerRegistry { get { throw null; } set { } }
        public int? CosmosDbCollectionsThroughput { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string FriendlyName { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public string ImageBuildCompute { get { throw null; } set { } }
        public string PrimaryUserAssignedIdentity { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.PublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.MachineLearningServicesSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
}
