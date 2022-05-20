namespace Azure.ResourceManager.MachineLearning
{
    public partial class BatchDeploymentDataCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.BatchDeploymentDataResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.BatchDeploymentDataResource>, System.Collections.IEnumerable
    {
        protected BatchDeploymentDataCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.BatchDeploymentDataResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string deploymentName, Azure.ResourceManager.MachineLearning.BatchDeploymentDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.BatchDeploymentDataResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string deploymentName, Azure.ResourceManager.MachineLearning.BatchDeploymentDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.BatchDeploymentDataResource> Get(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearning.BatchDeploymentDataResource> GetAll(string orderBy = null, int? top = default(int?), string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearning.BatchDeploymentDataResource> GetAllAsync(string orderBy = null, int? top = default(int?), string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.BatchDeploymentDataResource>> GetAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MachineLearning.BatchDeploymentDataResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.BatchDeploymentDataResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MachineLearning.BatchDeploymentDataResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.BatchDeploymentDataResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class BatchDeploymentDataData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public BatchDeploymentDataData(Azure.Core.AzureLocation location, Azure.ResourceManager.MachineLearning.Models.BatchDeploymentDetails properties) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.BatchDeploymentDetails Properties { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningSku Sku { get { throw null; } set { } }
    }
    public partial class BatchDeploymentDataResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BatchDeploymentDataResource() { }
        public virtual Azure.ResourceManager.MachineLearning.BatchDeploymentDataData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.BatchDeploymentDataResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.BatchDeploymentDataResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string endpointName, string deploymentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.BatchDeploymentDataResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.BatchDeploymentDataResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.BatchDeploymentDataResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.BatchDeploymentDataResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.BatchDeploymentDataResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.BatchDeploymentDataResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.BatchDeploymentDataResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.Models.BatchDeploymentDataPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.BatchDeploymentDataResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.Models.BatchDeploymentDataPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BatchEndpointDataCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.BatchEndpointDataResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.BatchEndpointDataResource>, System.Collections.IEnumerable
    {
        protected BatchEndpointDataCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.BatchEndpointDataResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string endpointName, Azure.ResourceManager.MachineLearning.BatchEndpointDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.BatchEndpointDataResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string endpointName, Azure.ResourceManager.MachineLearning.BatchEndpointDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.BatchEndpointDataResource> Get(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearning.BatchEndpointDataResource> GetAll(int? count = default(int?), string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearning.BatchEndpointDataResource> GetAllAsync(int? count = default(int?), string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.BatchEndpointDataResource>> GetAsync(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MachineLearning.BatchEndpointDataResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.BatchEndpointDataResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MachineLearning.BatchEndpointDataResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.BatchEndpointDataResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class BatchEndpointDataData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public BatchEndpointDataData(Azure.Core.AzureLocation location, Azure.ResourceManager.MachineLearning.Models.BatchEndpointDetails properties) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.BatchEndpointDetails Properties { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningSku Sku { get { throw null; } set { } }
    }
    public partial class BatchEndpointDataResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BatchEndpointDataResource() { }
        public virtual Azure.ResourceManager.MachineLearning.BatchEndpointDataData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.BatchEndpointDataResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.BatchEndpointDataResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string endpointName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.BatchEndpointDataResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearning.BatchDeploymentDataCollection GetAllBatchDeploymentData() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.BatchEndpointDataResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.BatchDeploymentDataResource> GetBatchDeploymentData(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.BatchDeploymentDataResource>> GetBatchDeploymentDataAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.Models.EndpointAuthKeys> GetKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.Models.EndpointAuthKeys>> GetKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.BatchEndpointDataResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.BatchEndpointDataResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.BatchEndpointDataResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.BatchEndpointDataResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.BatchEndpointDataResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.Models.BatchEndpointDataPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.BatchEndpointDataResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.Models.BatchEndpointDataPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CodeContainerDataCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.CodeContainerDataResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.CodeContainerDataResource>, System.Collections.IEnumerable
    {
        protected CodeContainerDataCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.CodeContainerDataResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.MachineLearning.CodeContainerDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.CodeContainerDataResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.MachineLearning.CodeContainerDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.CodeContainerDataResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearning.CodeContainerDataResource> GetAll(string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearning.CodeContainerDataResource> GetAllAsync(string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.CodeContainerDataResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MachineLearning.CodeContainerDataResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.CodeContainerDataResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MachineLearning.CodeContainerDataResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.CodeContainerDataResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CodeContainerDataData : Azure.ResourceManager.Models.ResourceData
    {
        public CodeContainerDataData(Azure.ResourceManager.MachineLearning.Models.CodeContainerDetails properties) { }
        public Azure.ResourceManager.MachineLearning.Models.CodeContainerDetails Properties { get { throw null; } set { } }
    }
    public partial class CodeContainerDataResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CodeContainerDataResource() { }
        public virtual Azure.ResourceManager.MachineLearning.CodeContainerDataData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.CodeContainerDataResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearning.CodeVersionDataCollection GetAllCodeVersionData() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.CodeContainerDataResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.CodeVersionDataResource> GetCodeVersionData(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.CodeVersionDataResource>> GetCodeVersionDataAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.CodeContainerDataResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.CodeContainerDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.CodeContainerDataResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.CodeContainerDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CodeVersionDataCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.CodeVersionDataResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.CodeVersionDataResource>, System.Collections.IEnumerable
    {
        protected CodeVersionDataCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.CodeVersionDataResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string version, Azure.ResourceManager.MachineLearning.CodeVersionDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.CodeVersionDataResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string version, Azure.ResourceManager.MachineLearning.CodeVersionDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.CodeVersionDataResource> Get(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearning.CodeVersionDataResource> GetAll(string orderBy = null, int? top = default(int?), string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearning.CodeVersionDataResource> GetAllAsync(string orderBy = null, int? top = default(int?), string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.CodeVersionDataResource>> GetAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MachineLearning.CodeVersionDataResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.CodeVersionDataResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MachineLearning.CodeVersionDataResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.CodeVersionDataResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CodeVersionDataData : Azure.ResourceManager.Models.ResourceData
    {
        public CodeVersionDataData(Azure.ResourceManager.MachineLearning.Models.CodeVersionDetails properties) { }
        public Azure.ResourceManager.MachineLearning.Models.CodeVersionDetails Properties { get { throw null; } set { } }
    }
    public partial class CodeVersionDataResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CodeVersionDataResource() { }
        public virtual Azure.ResourceManager.MachineLearning.CodeVersionDataData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string name, string version) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.CodeVersionDataResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.CodeVersionDataResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.CodeVersionDataResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.CodeVersionDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.CodeVersionDataResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.CodeVersionDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ComponentContainerDataCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.ComponentContainerDataResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.ComponentContainerDataResource>, System.Collections.IEnumerable
    {
        protected ComponentContainerDataCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.ComponentContainerDataResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.MachineLearning.ComponentContainerDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.ComponentContainerDataResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.MachineLearning.ComponentContainerDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.ComponentContainerDataResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearning.ComponentContainerDataResource> GetAll(string skip = null, Azure.ResourceManager.MachineLearning.Models.ListViewType? listViewType = default(Azure.ResourceManager.MachineLearning.Models.ListViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearning.ComponentContainerDataResource> GetAllAsync(string skip = null, Azure.ResourceManager.MachineLearning.Models.ListViewType? listViewType = default(Azure.ResourceManager.MachineLearning.Models.ListViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.ComponentContainerDataResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MachineLearning.ComponentContainerDataResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.ComponentContainerDataResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MachineLearning.ComponentContainerDataResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.ComponentContainerDataResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ComponentContainerDataData : Azure.ResourceManager.Models.ResourceData
    {
        public ComponentContainerDataData(Azure.ResourceManager.MachineLearning.Models.ComponentContainerDetails properties) { }
        public Azure.ResourceManager.MachineLearning.Models.ComponentContainerDetails Properties { get { throw null; } set { } }
    }
    public partial class ComponentContainerDataResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ComponentContainerDataResource() { }
        public virtual Azure.ResourceManager.MachineLearning.ComponentContainerDataData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.ComponentContainerDataResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearning.ComponentVersionDataCollection GetAllComponentVersionData() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.ComponentContainerDataResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.ComponentVersionDataResource> GetComponentVersionData(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.ComponentVersionDataResource>> GetComponentVersionDataAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.ComponentContainerDataResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.ComponentContainerDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.ComponentContainerDataResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.ComponentContainerDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ComponentVersionDataCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.ComponentVersionDataResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.ComponentVersionDataResource>, System.Collections.IEnumerable
    {
        protected ComponentVersionDataCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.ComponentVersionDataResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string version, Azure.ResourceManager.MachineLearning.ComponentVersionDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.ComponentVersionDataResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string version, Azure.ResourceManager.MachineLearning.ComponentVersionDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.ComponentVersionDataResource> Get(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearning.ComponentVersionDataResource> GetAll(string orderBy = null, int? top = default(int?), string skip = null, Azure.ResourceManager.MachineLearning.Models.ListViewType? listViewType = default(Azure.ResourceManager.MachineLearning.Models.ListViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearning.ComponentVersionDataResource> GetAllAsync(string orderBy = null, int? top = default(int?), string skip = null, Azure.ResourceManager.MachineLearning.Models.ListViewType? listViewType = default(Azure.ResourceManager.MachineLearning.Models.ListViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.ComponentVersionDataResource>> GetAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MachineLearning.ComponentVersionDataResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.ComponentVersionDataResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MachineLearning.ComponentVersionDataResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.ComponentVersionDataResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ComponentVersionDataData : Azure.ResourceManager.Models.ResourceData
    {
        public ComponentVersionDataData(Azure.ResourceManager.MachineLearning.Models.ComponentVersionDetails properties) { }
        public Azure.ResourceManager.MachineLearning.Models.ComponentVersionDetails Properties { get { throw null; } set { } }
    }
    public partial class ComponentVersionDataResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ComponentVersionDataResource() { }
        public virtual Azure.ResourceManager.MachineLearning.ComponentVersionDataData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string name, string version) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.ComponentVersionDataResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.ComponentVersionDataResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.ComponentVersionDataResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.ComponentVersionDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.ComponentVersionDataResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.ComponentVersionDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ComputeResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ComputeResource() { }
        public virtual Azure.ResourceManager.MachineLearning.ComputeResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.ComputeResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.ComputeResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string computeName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.Models.UnderlyingResourceAction underlyingResourceAction, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.Models.UnderlyingResourceAction underlyingResourceAction, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.ComputeResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.ComputeResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.Models.ComputeSecrets> GetKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.Models.ComputeSecrets>> GetKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearning.Models.AmlComputeNodeInformation> GetNodes(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearning.Models.AmlComputeNodeInformation> GetNodesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.ComputeResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.ComputeResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Restart(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RestartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.ComputeResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.ComputeResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Start(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Stop(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StopAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.ComputeResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.Models.ComputeResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.ComputeResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.Models.ComputeResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ComputeResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.ComputeResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.ComputeResource>, System.Collections.IEnumerable
    {
        protected ComputeResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.ComputeResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string computeName, Azure.ResourceManager.MachineLearning.ComputeResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.ComputeResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string computeName, Azure.ResourceManager.MachineLearning.ComputeResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string computeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string computeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.ComputeResource> Get(string computeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearning.ComputeResource> GetAll(string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearning.ComputeResource> GetAllAsync(string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.ComputeResource>> GetAsync(string computeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MachineLearning.ComputeResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.ComputeResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MachineLearning.ComputeResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.ComputeResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ComputeResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public ComputeResourceData() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public string Location { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.Compute Properties { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class DataContainerDataCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.DataContainerDataResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.DataContainerDataResource>, System.Collections.IEnumerable
    {
        protected DataContainerDataCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.DataContainerDataResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.MachineLearning.DataContainerDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.DataContainerDataResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.MachineLearning.DataContainerDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.DataContainerDataResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearning.DataContainerDataResource> GetAll(string skip = null, Azure.ResourceManager.MachineLearning.Models.ListViewType? listViewType = default(Azure.ResourceManager.MachineLearning.Models.ListViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearning.DataContainerDataResource> GetAllAsync(string skip = null, Azure.ResourceManager.MachineLearning.Models.ListViewType? listViewType = default(Azure.ResourceManager.MachineLearning.Models.ListViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.DataContainerDataResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MachineLearning.DataContainerDataResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.DataContainerDataResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MachineLearning.DataContainerDataResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.DataContainerDataResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataContainerDataData : Azure.ResourceManager.Models.ResourceData
    {
        public DataContainerDataData(Azure.ResourceManager.MachineLearning.Models.DataContainerDetails properties) { }
        public Azure.ResourceManager.MachineLearning.Models.DataContainerDetails Properties { get { throw null; } set { } }
    }
    public partial class DataContainerDataResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataContainerDataResource() { }
        public virtual Azure.ResourceManager.MachineLearning.DataContainerDataData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.DataContainerDataResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearning.DataVersionBaseDataCollection GetAllDataVersionBaseData() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.DataContainerDataResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.DataVersionBaseDataResource> GetDataVersionBaseData(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.DataVersionBaseDataResource>> GetDataVersionBaseDataAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.DataContainerDataResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.DataContainerDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.DataContainerDataResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.DataContainerDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatastoreDataCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.DatastoreDataResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.DatastoreDataResource>, System.Collections.IEnumerable
    {
        protected DatastoreDataCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.DatastoreDataResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.MachineLearning.DatastoreDataData data, bool? skipValidation = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.DatastoreDataResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.MachineLearning.DatastoreDataData data, bool? skipValidation = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.DatastoreDataResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearning.DatastoreDataResource> GetAll(string skip = null, int? count = default(int?), bool? isDefault = default(bool?), System.Collections.Generic.IEnumerable<string> names = null, string searchText = null, string orderBy = null, bool? orderByAsc = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearning.DatastoreDataResource> GetAllAsync(string skip = null, int? count = default(int?), bool? isDefault = default(bool?), System.Collections.Generic.IEnumerable<string> names = null, string searchText = null, string orderBy = null, bool? orderByAsc = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.DatastoreDataResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MachineLearning.DatastoreDataResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.DatastoreDataResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MachineLearning.DatastoreDataResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.DatastoreDataResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DatastoreDataData : Azure.ResourceManager.Models.ResourceData
    {
        public DatastoreDataData(Azure.ResourceManager.MachineLearning.Models.DatastoreDetails properties) { }
        public Azure.ResourceManager.MachineLearning.Models.DatastoreDetails Properties { get { throw null; } set { } }
    }
    public partial class DatastoreDataResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DatastoreDataResource() { }
        public virtual Azure.ResourceManager.MachineLearning.DatastoreDataData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.DatastoreDataResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.DatastoreDataResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.Models.DatastoreSecrets> GetSecrets(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.Models.DatastoreSecrets>> GetSecretsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.DatastoreDataResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.DatastoreDataData data, bool? skipValidation = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.DatastoreDataResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.DatastoreDataData data, bool? skipValidation = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataVersionBaseDataCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.DataVersionBaseDataResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.DataVersionBaseDataResource>, System.Collections.IEnumerable
    {
        protected DataVersionBaseDataCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.DataVersionBaseDataResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string version, Azure.ResourceManager.MachineLearning.DataVersionBaseDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.DataVersionBaseDataResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string version, Azure.ResourceManager.MachineLearning.DataVersionBaseDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.DataVersionBaseDataResource> Get(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearning.DataVersionBaseDataResource> GetAll(string orderBy = null, int? top = default(int?), string skip = null, string tags = null, Azure.ResourceManager.MachineLearning.Models.ListViewType? listViewType = default(Azure.ResourceManager.MachineLearning.Models.ListViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearning.DataVersionBaseDataResource> GetAllAsync(string orderBy = null, int? top = default(int?), string skip = null, string tags = null, Azure.ResourceManager.MachineLearning.Models.ListViewType? listViewType = default(Azure.ResourceManager.MachineLearning.Models.ListViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.DataVersionBaseDataResource>> GetAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MachineLearning.DataVersionBaseDataResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.DataVersionBaseDataResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MachineLearning.DataVersionBaseDataResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.DataVersionBaseDataResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataVersionBaseDataData : Azure.ResourceManager.Models.ResourceData
    {
        public DataVersionBaseDataData(Azure.ResourceManager.MachineLearning.Models.DataVersionBaseDetails properties) { }
        public Azure.ResourceManager.MachineLearning.Models.DataVersionBaseDetails Properties { get { throw null; } set { } }
    }
    public partial class DataVersionBaseDataResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataVersionBaseDataResource() { }
        public virtual Azure.ResourceManager.MachineLearning.DataVersionBaseDataData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string name, string version) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.DataVersionBaseDataResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.DataVersionBaseDataResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.DataVersionBaseDataResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.DataVersionBaseDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.DataVersionBaseDataResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.DataVersionBaseDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EnvironmentContainerDataCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.EnvironmentContainerDataResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.EnvironmentContainerDataResource>, System.Collections.IEnumerable
    {
        protected EnvironmentContainerDataCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.EnvironmentContainerDataResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.MachineLearning.EnvironmentContainerDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.EnvironmentContainerDataResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.MachineLearning.EnvironmentContainerDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.EnvironmentContainerDataResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearning.EnvironmentContainerDataResource> GetAll(string skip = null, Azure.ResourceManager.MachineLearning.Models.ListViewType? listViewType = default(Azure.ResourceManager.MachineLearning.Models.ListViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearning.EnvironmentContainerDataResource> GetAllAsync(string skip = null, Azure.ResourceManager.MachineLearning.Models.ListViewType? listViewType = default(Azure.ResourceManager.MachineLearning.Models.ListViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.EnvironmentContainerDataResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MachineLearning.EnvironmentContainerDataResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.EnvironmentContainerDataResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MachineLearning.EnvironmentContainerDataResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.EnvironmentContainerDataResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EnvironmentContainerDataData : Azure.ResourceManager.Models.ResourceData
    {
        public EnvironmentContainerDataData(Azure.ResourceManager.MachineLearning.Models.EnvironmentContainerDetails properties) { }
        public Azure.ResourceManager.MachineLearning.Models.EnvironmentContainerDetails Properties { get { throw null; } set { } }
    }
    public partial class EnvironmentContainerDataResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EnvironmentContainerDataResource() { }
        public virtual Azure.ResourceManager.MachineLearning.EnvironmentContainerDataData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.EnvironmentContainerDataResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearning.EnvironmentVersionDataCollection GetAllEnvironmentVersionData() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.EnvironmentContainerDataResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.EnvironmentVersionDataResource> GetEnvironmentVersionData(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.EnvironmentVersionDataResource>> GetEnvironmentVersionDataAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.EnvironmentContainerDataResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.EnvironmentContainerDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.EnvironmentContainerDataResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.EnvironmentContainerDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EnvironmentVersionDataCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.EnvironmentVersionDataResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.EnvironmentVersionDataResource>, System.Collections.IEnumerable
    {
        protected EnvironmentVersionDataCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.EnvironmentVersionDataResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string version, Azure.ResourceManager.MachineLearning.EnvironmentVersionDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.EnvironmentVersionDataResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string version, Azure.ResourceManager.MachineLearning.EnvironmentVersionDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.EnvironmentVersionDataResource> Get(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearning.EnvironmentVersionDataResource> GetAll(string orderBy = null, int? top = default(int?), string skip = null, Azure.ResourceManager.MachineLearning.Models.ListViewType? listViewType = default(Azure.ResourceManager.MachineLearning.Models.ListViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearning.EnvironmentVersionDataResource> GetAllAsync(string orderBy = null, int? top = default(int?), string skip = null, Azure.ResourceManager.MachineLearning.Models.ListViewType? listViewType = default(Azure.ResourceManager.MachineLearning.Models.ListViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.EnvironmentVersionDataResource>> GetAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MachineLearning.EnvironmentVersionDataResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.EnvironmentVersionDataResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MachineLearning.EnvironmentVersionDataResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.EnvironmentVersionDataResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EnvironmentVersionDataData : Azure.ResourceManager.Models.ResourceData
    {
        public EnvironmentVersionDataData(Azure.ResourceManager.MachineLearning.Models.EnvironmentVersionDetails properties) { }
        public Azure.ResourceManager.MachineLearning.Models.EnvironmentVersionDetails Properties { get { throw null; } set { } }
    }
    public partial class EnvironmentVersionDataResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EnvironmentVersionDataResource() { }
        public virtual Azure.ResourceManager.MachineLearning.EnvironmentVersionDataData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string name, string version) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.EnvironmentVersionDataResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.EnvironmentVersionDataResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.EnvironmentVersionDataResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.EnvironmentVersionDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.EnvironmentVersionDataResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.EnvironmentVersionDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class JobBaseDataCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.JobBaseDataResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.JobBaseDataResource>, System.Collections.IEnumerable
    {
        protected JobBaseDataCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.JobBaseDataResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string id, Azure.ResourceManager.MachineLearning.JobBaseDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.JobBaseDataResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string id, Azure.ResourceManager.MachineLearning.JobBaseDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.JobBaseDataResource> Get(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearning.JobBaseDataResource> GetAll(string skip = null, string jobType = null, string tag = null, Azure.ResourceManager.MachineLearning.Models.ListViewType? listViewType = default(Azure.ResourceManager.MachineLearning.Models.ListViewType?), bool? scheduled = default(bool?), string scheduleId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearning.JobBaseDataResource> GetAllAsync(string skip = null, string jobType = null, string tag = null, Azure.ResourceManager.MachineLearning.Models.ListViewType? listViewType = default(Azure.ResourceManager.MachineLearning.Models.ListViewType?), bool? scheduled = default(bool?), string scheduleId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.JobBaseDataResource>> GetAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MachineLearning.JobBaseDataResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.JobBaseDataResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MachineLearning.JobBaseDataResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.JobBaseDataResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class JobBaseDataData : Azure.ResourceManager.Models.ResourceData
    {
        public JobBaseDataData(Azure.ResourceManager.MachineLearning.Models.JobBaseDetails properties) { }
        public Azure.ResourceManager.MachineLearning.Models.JobBaseDetails Properties { get { throw null; } set { } }
    }
    public partial class JobBaseDataResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected JobBaseDataResource() { }
        public virtual Azure.ResourceManager.MachineLearning.JobBaseDataData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response Cancel(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string id) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.JobBaseDataResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.JobBaseDataResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.JobBaseDataResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.JobBaseDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.JobBaseDataResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.JobBaseDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class MachineLearningExtensions
    {
        public static Azure.ResourceManager.MachineLearning.BatchDeploymentDataResource GetBatchDeploymentDataResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MachineLearning.BatchEndpointDataResource GetBatchEndpointDataResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MachineLearning.CodeContainerDataResource GetCodeContainerDataResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MachineLearning.CodeVersionDataResource GetCodeVersionDataResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MachineLearning.ComponentContainerDataResource GetComponentContainerDataResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MachineLearning.ComponentVersionDataResource GetComponentVersionDataResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MachineLearning.ComputeResource GetComputeResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MachineLearning.DataContainerDataResource GetDataContainerDataResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MachineLearning.DatastoreDataResource GetDatastoreDataResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MachineLearning.DataVersionBaseDataResource GetDataVersionBaseDataResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MachineLearning.EnvironmentContainerDataResource GetEnvironmentContainerDataResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MachineLearning.EnvironmentVersionDataResource GetEnvironmentVersionDataResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MachineLearning.JobBaseDataResource GetJobBaseDataResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MachineLearning.MachineLearningPrivateEndpointConnectionResource GetMachineLearningPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MachineLearning.ModelContainerDataResource GetModelContainerDataResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MachineLearning.ModelVersionDataResource GetModelVersionDataResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MachineLearning.OnlineDeploymentDataResource GetOnlineDeploymentDataResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MachineLearning.OnlineEndpointDataResource GetOnlineEndpointDataResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.MachineLearning.Models.ResourceQuota> GetQuotas(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.MachineLearning.Models.ResourceQuota> GetQuotasAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.MachineLearning.Models.MachineLearningUsage> GetUsages(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.MachineLearning.Models.MachineLearningUsage> GetUsagesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.MachineLearning.Models.VirtualMachineSize> GetVirtualMachineSizes(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.MachineLearning.Models.VirtualMachineSize> GetVirtualMachineSizesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.MachineLearning.WorkspaceResource> GetWorkspace(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.WorkspaceResource>> GetWorkspaceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.MachineLearning.WorkspaceConnectionResource GetWorkspaceConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MachineLearning.WorkspaceResource GetWorkspaceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MachineLearning.WorkspaceCollection GetWorkspaces(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.MachineLearning.WorkspaceResource> GetWorkspaces(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.MachineLearning.WorkspaceResource> GetWorkspacesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.MachineLearning.Models.UpdateWorkspaceQuotas> UpdateQuotas(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, Azure.ResourceManager.MachineLearning.Models.QuotaUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.MachineLearning.Models.UpdateWorkspaceQuotas> UpdateQuotasAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, Azure.ResourceManager.MachineLearning.Models.QuotaUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MachineLearningPrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.MachineLearningPrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.MachineLearningPrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected MachineLearningPrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.MachineLearningPrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.MachineLearning.MachineLearningPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.MachineLearningPrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.MachineLearning.MachineLearningPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningPrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearning.MachineLearningPrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearning.MachineLearningPrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningPrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MachineLearning.MachineLearningPrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.MachineLearningPrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MachineLearning.MachineLearningPrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.MachineLearningPrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MachineLearningPrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData
    {
        public MachineLearningPrivateEndpointConnectionData() { }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningPrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public string Location { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.PrivateEndpoint PrivateEndpoint { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningPrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class MachineLearningPrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MachineLearningPrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.MachineLearning.MachineLearningPrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningPrivateEndpointConnectionResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningPrivateEndpointConnectionResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningPrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningPrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningPrivateEndpointConnectionResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningPrivateEndpointConnectionResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningPrivateEndpointConnectionResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningPrivateEndpointConnectionResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.MachineLearningPrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.MachineLearningPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.MachineLearningPrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.MachineLearningPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ModelContainerDataCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.ModelContainerDataResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.ModelContainerDataResource>, System.Collections.IEnumerable
    {
        protected ModelContainerDataCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.ModelContainerDataResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.MachineLearning.ModelContainerDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.ModelContainerDataResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.MachineLearning.ModelContainerDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.ModelContainerDataResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearning.ModelContainerDataResource> GetAll(string skip = null, int? count = default(int?), Azure.ResourceManager.MachineLearning.Models.ListViewType? listViewType = default(Azure.ResourceManager.MachineLearning.Models.ListViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearning.ModelContainerDataResource> GetAllAsync(string skip = null, int? count = default(int?), Azure.ResourceManager.MachineLearning.Models.ListViewType? listViewType = default(Azure.ResourceManager.MachineLearning.Models.ListViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.ModelContainerDataResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MachineLearning.ModelContainerDataResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.ModelContainerDataResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MachineLearning.ModelContainerDataResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.ModelContainerDataResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ModelContainerDataData : Azure.ResourceManager.Models.ResourceData
    {
        public ModelContainerDataData(Azure.ResourceManager.MachineLearning.Models.ModelContainerDetails properties) { }
        public Azure.ResourceManager.MachineLearning.Models.ModelContainerDetails Properties { get { throw null; } set { } }
    }
    public partial class ModelContainerDataResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ModelContainerDataResource() { }
        public virtual Azure.ResourceManager.MachineLearning.ModelContainerDataData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.ModelContainerDataResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearning.ModelVersionDataCollection GetAllModelVersionData() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.ModelContainerDataResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.ModelVersionDataResource> GetModelVersionData(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.ModelVersionDataResource>> GetModelVersionDataAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.ModelContainerDataResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.ModelContainerDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.ModelContainerDataResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.ModelContainerDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ModelVersionDataCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.ModelVersionDataResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.ModelVersionDataResource>, System.Collections.IEnumerable
    {
        protected ModelVersionDataCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.ModelVersionDataResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string version, Azure.ResourceManager.MachineLearning.ModelVersionDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.ModelVersionDataResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string version, Azure.ResourceManager.MachineLearning.ModelVersionDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.ModelVersionDataResource> Get(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearning.ModelVersionDataResource> GetAll(string skip = null, string orderBy = null, int? top = default(int?), string version = null, string description = null, int? offset = default(int?), string tags = null, string properties = null, string feed = null, Azure.ResourceManager.MachineLearning.Models.ListViewType? listViewType = default(Azure.ResourceManager.MachineLearning.Models.ListViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearning.ModelVersionDataResource> GetAllAsync(string skip = null, string orderBy = null, int? top = default(int?), string version = null, string description = null, int? offset = default(int?), string tags = null, string properties = null, string feed = null, Azure.ResourceManager.MachineLearning.Models.ListViewType? listViewType = default(Azure.ResourceManager.MachineLearning.Models.ListViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.ModelVersionDataResource>> GetAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MachineLearning.ModelVersionDataResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.ModelVersionDataResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MachineLearning.ModelVersionDataResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.ModelVersionDataResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ModelVersionDataData : Azure.ResourceManager.Models.ResourceData
    {
        public ModelVersionDataData(Azure.ResourceManager.MachineLearning.Models.ModelVersionDetails properties) { }
        public Azure.ResourceManager.MachineLearning.Models.ModelVersionDetails Properties { get { throw null; } set { } }
    }
    public partial class ModelVersionDataResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ModelVersionDataResource() { }
        public virtual Azure.ResourceManager.MachineLearning.ModelVersionDataData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string name, string version) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.ModelVersionDataResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.ModelVersionDataResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.ModelVersionDataResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.ModelVersionDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.ModelVersionDataResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.ModelVersionDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OnlineDeploymentDataCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.OnlineDeploymentDataResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.OnlineDeploymentDataResource>, System.Collections.IEnumerable
    {
        protected OnlineDeploymentDataCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.OnlineDeploymentDataResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string deploymentName, Azure.ResourceManager.MachineLearning.OnlineDeploymentDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.OnlineDeploymentDataResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string deploymentName, Azure.ResourceManager.MachineLearning.OnlineDeploymentDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.OnlineDeploymentDataResource> Get(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearning.OnlineDeploymentDataResource> GetAll(string orderBy = null, int? top = default(int?), string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearning.OnlineDeploymentDataResource> GetAllAsync(string orderBy = null, int? top = default(int?), string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.OnlineDeploymentDataResource>> GetAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MachineLearning.OnlineDeploymentDataResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.OnlineDeploymentDataResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MachineLearning.OnlineDeploymentDataResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.OnlineDeploymentDataResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class OnlineDeploymentDataData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public OnlineDeploymentDataData(Azure.Core.AzureLocation location, Azure.ResourceManager.MachineLearning.Models.OnlineDeploymentDetails properties) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.OnlineDeploymentDetails Properties { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningSku Sku { get { throw null; } set { } }
    }
    public partial class OnlineDeploymentDataResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected OnlineDeploymentDataResource() { }
        public virtual Azure.ResourceManager.MachineLearning.OnlineDeploymentDataData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.OnlineDeploymentDataResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.OnlineDeploymentDataResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string endpointName, string deploymentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.OnlineDeploymentDataResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.OnlineDeploymentDataResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.Models.DeploymentLogs> GetLogs(Azure.ResourceManager.MachineLearning.Models.DeploymentLogsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.Models.DeploymentLogs>> GetLogsAsync(Azure.ResourceManager.MachineLearning.Models.DeploymentLogsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearning.Models.SkuResource> GetSkus(int? count = default(int?), string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearning.Models.SkuResource> GetSkusAsync(int? count = default(int?), string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.OnlineDeploymentDataResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.OnlineDeploymentDataResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.OnlineDeploymentDataResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.OnlineDeploymentDataResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.OnlineDeploymentDataResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.Models.OnlineDeploymentDataPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.OnlineDeploymentDataResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.Models.OnlineDeploymentDataPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OnlineEndpointDataCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.OnlineEndpointDataResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.OnlineEndpointDataResource>, System.Collections.IEnumerable
    {
        protected OnlineEndpointDataCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.OnlineEndpointDataResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string endpointName, Azure.ResourceManager.MachineLearning.OnlineEndpointDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.OnlineEndpointDataResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string endpointName, Azure.ResourceManager.MachineLearning.OnlineEndpointDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.OnlineEndpointDataResource> Get(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearning.OnlineEndpointDataResource> GetAll(string name = null, int? count = default(int?), Azure.ResourceManager.MachineLearning.Models.EndpointComputeType? computeType = default(Azure.ResourceManager.MachineLearning.Models.EndpointComputeType?), string skip = null, string tags = null, string properties = null, Azure.ResourceManager.MachineLearning.Models.OrderString? orderBy = default(Azure.ResourceManager.MachineLearning.Models.OrderString?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearning.OnlineEndpointDataResource> GetAllAsync(string name = null, int? count = default(int?), Azure.ResourceManager.MachineLearning.Models.EndpointComputeType? computeType = default(Azure.ResourceManager.MachineLearning.Models.EndpointComputeType?), string skip = null, string tags = null, string properties = null, Azure.ResourceManager.MachineLearning.Models.OrderString? orderBy = default(Azure.ResourceManager.MachineLearning.Models.OrderString?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.OnlineEndpointDataResource>> GetAsync(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MachineLearning.OnlineEndpointDataResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.OnlineEndpointDataResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MachineLearning.OnlineEndpointDataResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.OnlineEndpointDataResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class OnlineEndpointDataData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public OnlineEndpointDataData(Azure.Core.AzureLocation location, Azure.ResourceManager.MachineLearning.Models.OnlineEndpointDetails properties) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.OnlineEndpointDetails Properties { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningSku Sku { get { throw null; } set { } }
    }
    public partial class OnlineEndpointDataResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected OnlineEndpointDataResource() { }
        public virtual Azure.ResourceManager.MachineLearning.OnlineEndpointDataData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.OnlineEndpointDataResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.OnlineEndpointDataResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string endpointName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.OnlineEndpointDataResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearning.OnlineDeploymentDataCollection GetAllOnlineDeploymentData() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.OnlineEndpointDataResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.Models.EndpointAuthKeys> GetKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.Models.EndpointAuthKeys>> GetKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.OnlineDeploymentDataResource> GetOnlineDeploymentData(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.OnlineDeploymentDataResource>> GetOnlineDeploymentDataAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.Models.EndpointAuthToken> GetToken(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.Models.EndpointAuthToken>> GetTokenAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RegenerateKeys(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.Models.RegenerateEndpointKeysContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RegenerateKeysAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.Models.RegenerateEndpointKeysContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.OnlineEndpointDataResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.OnlineEndpointDataResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.OnlineEndpointDataResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.OnlineEndpointDataResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.OnlineEndpointDataResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.Models.OnlineEndpointDataPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.OnlineEndpointDataResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.Models.OnlineEndpointDataPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WorkspaceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.WorkspaceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.WorkspaceResource>, System.Collections.IEnumerable
    {
        protected WorkspaceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.WorkspaceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string workspaceName, Azure.ResourceManager.MachineLearning.WorkspaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.WorkspaceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string workspaceName, Azure.ResourceManager.MachineLearning.WorkspaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.WorkspaceResource> Get(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearning.WorkspaceResource> GetAll(string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearning.WorkspaceResource> GetAllAsync(string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.WorkspaceResource>> GetAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MachineLearning.WorkspaceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.WorkspaceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MachineLearning.WorkspaceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.WorkspaceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WorkspaceConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.WorkspaceConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.WorkspaceConnectionResource>, System.Collections.IEnumerable
    {
        protected WorkspaceConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.WorkspaceConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string connectionName, Azure.ResourceManager.MachineLearning.WorkspaceConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.WorkspaceConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string connectionName, Azure.ResourceManager.MachineLearning.WorkspaceConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string connectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string connectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.WorkspaceConnectionResource> Get(string connectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearning.WorkspaceConnectionResource> GetAll(string target = null, string category = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearning.WorkspaceConnectionResource> GetAllAsync(string target = null, string category = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.WorkspaceConnectionResource>> GetAsync(string connectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MachineLearning.WorkspaceConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.WorkspaceConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MachineLearning.WorkspaceConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.WorkspaceConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WorkspaceConnectionData : Azure.ResourceManager.Models.ResourceData
    {
        public WorkspaceConnectionData() { }
        public string AuthType { get { throw null; } set { } }
        public string Category { get { throw null; } set { } }
        public string Target { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ValueFormat? ValueFormat { get { throw null; } set { } }
    }
    public partial class WorkspaceConnectionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WorkspaceConnectionResource() { }
        public virtual Azure.ResourceManager.MachineLearning.WorkspaceConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string connectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.WorkspaceConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.WorkspaceConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.WorkspaceConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.WorkspaceConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.WorkspaceConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.WorkspaceConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public Azure.ResourceManager.MachineLearning.Models.EncryptionProperty Encryption { get { throw null; } set { } }
        public string FriendlyName { get { throw null; } set { } }
        public bool? HbiWorkspace { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public string ImageBuildCompute { get { throw null; } set { } }
        public string KeyVault { get { throw null; } set { } }
        public string Location { get { throw null; } set { } }
        public System.Uri MlFlowTrackingUri { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.NotebookResourceInfo NotebookInfo { get { throw null; } }
        public string PrimaryUserAssignedIdentity { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearning.MachineLearningPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public int? PrivateLinkCount { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.PublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public string ServiceProvisionedResourceGroup { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.MachineLearning.Models.SharedPrivateLinkResource> SharedPrivateLinkResources { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningSku Sku { get { throw null; } set { } }
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
        public virtual Azure.ResourceManager.MachineLearning.WorkspaceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.WorkspaceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.WorkspaceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.Models.DiagnoseResponseResult> Diagnose(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.Models.DiagnoseWorkspaceContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.Models.DiagnoseResponseResult>> DiagnoseAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.Models.DiagnoseWorkspaceContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.WorkspaceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearning.BatchEndpointDataCollection GetAllBatchEndpointData() { throw null; }
        public virtual Azure.ResourceManager.MachineLearning.CodeContainerDataCollection GetAllCodeContainerData() { throw null; }
        public virtual Azure.ResourceManager.MachineLearning.ComponentContainerDataCollection GetAllComponentContainerData() { throw null; }
        public virtual Azure.ResourceManager.MachineLearning.DataContainerDataCollection GetAllDataContainerData() { throw null; }
        public virtual Azure.ResourceManager.MachineLearning.DatastoreDataCollection GetAllDatastoreData() { throw null; }
        public virtual Azure.ResourceManager.MachineLearning.EnvironmentContainerDataCollection GetAllEnvironmentContainerData() { throw null; }
        public virtual Azure.ResourceManager.MachineLearning.JobBaseDataCollection GetAllJobBaseData() { throw null; }
        public virtual Azure.ResourceManager.MachineLearning.ModelContainerDataCollection GetAllModelContainerData() { throw null; }
        public virtual Azure.ResourceManager.MachineLearning.OnlineEndpointDataCollection GetAllOnlineEndpointData() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.WorkspaceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.BatchEndpointDataResource> GetBatchEndpointData(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.BatchEndpointDataResource>> GetBatchEndpointDataAsync(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.CodeContainerDataResource> GetCodeContainerData(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.CodeContainerDataResource>> GetCodeContainerDataAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.ComponentContainerDataResource> GetComponentContainerData(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.ComponentContainerDataResource>> GetComponentContainerDataAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.ComputeResource> GetComputeResource(string computeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.ComputeResource>> GetComputeResourceAsync(string computeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearning.ComputeResourceCollection GetComputeResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.DataContainerDataResource> GetDataContainerData(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.DataContainerDataResource>> GetDataContainerDataAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.DatastoreDataResource> GetDatastoreData(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.DatastoreDataResource>> GetDatastoreDataAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.EnvironmentContainerDataResource> GetEnvironmentContainerData(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.EnvironmentContainerDataResource>> GetEnvironmentContainerDataAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.JobBaseDataResource> GetJobBaseData(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.JobBaseDataResource>> GetJobBaseDataAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.Models.ListWorkspaceKeysResult> GetKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.Models.ListWorkspaceKeysResult>> GetKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningPrivateEndpointConnectionResource> GetMachineLearningPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningPrivateEndpointConnectionResource>> GetMachineLearningPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearning.MachineLearningPrivateEndpointConnectionCollection GetMachineLearningPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.ModelContainerDataResource> GetModelContainerData(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.ModelContainerDataResource>> GetModelContainerDataAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.Models.NotebookAccessTokenResult> GetNotebookAccessToken(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.Models.NotebookAccessTokenResult>> GetNotebookAccessTokenAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.Models.ListNotebookKeysResult> GetNotebookKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.Models.ListNotebookKeysResult>> GetNotebookKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.OnlineEndpointDataResource> GetOnlineEndpointData(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.OnlineEndpointDataResource>> GetOnlineEndpointDataAsync(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearning.Models.FqdnEndpoints> GetOutboundNetworkDependenciesEndpoints(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearning.Models.FqdnEndpoints> GetOutboundNetworkDependenciesEndpointsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearning.Models.MachineLearningPrivateLinkResource> GetPrivateLinkResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearning.Models.MachineLearningPrivateLinkResource> GetPrivateLinkResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.Models.ListStorageAccountKeysResult> GetStorageAccountKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.Models.ListStorageAccountKeysResult>> GetStorageAccountKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.WorkspaceConnectionResource> GetWorkspaceConnection(string connectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.WorkspaceConnectionResource>> GetWorkspaceConnectionAsync(string connectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearning.WorkspaceConnectionCollection GetWorkspaceConnections() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearning.Models.AmlUserFeature> GetWorkspaceFeatures(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearning.Models.AmlUserFeature> GetWorkspaceFeaturesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.Models.NotebookResourceInfo> PrepareNotebook(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.Models.NotebookResourceInfo>> PrepareNotebookAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.WorkspaceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.WorkspaceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ResyncKeys(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ResyncKeysAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.WorkspaceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.WorkspaceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.WorkspaceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.Models.WorkspacePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.WorkspaceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.Models.WorkspacePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.MachineLearning.Models
{
    public partial class AccountKeyDatastoreCredentials : Azure.ResourceManager.MachineLearning.Models.DatastoreCredentials
    {
        public AccountKeyDatastoreCredentials(Azure.ResourceManager.MachineLearning.Models.AccountKeyDatastoreSecrets secrets) { }
        public Azure.ResourceManager.MachineLearning.Models.AccountKeyDatastoreSecrets Secrets { get { throw null; } set { } }
    }
    public partial class AccountKeyDatastoreSecrets : Azure.ResourceManager.MachineLearning.Models.DatastoreSecrets
    {
        public AccountKeyDatastoreSecrets() { }
        public string Key { get { throw null; } set { } }
    }
    public partial class AKS : Azure.ResourceManager.MachineLearning.Models.Compute
    {
        public AKS() { }
        public Azure.ResourceManager.MachineLearning.Models.AKSSchemaProperties Properties { get { throw null; } set { } }
    }
    public partial class AksComputeSecrets : Azure.ResourceManager.MachineLearning.Models.ComputeSecrets
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
        public Azure.ResourceManager.MachineLearning.Models.AksNetworkingConfiguration AksNetworkingConfiguration { get { throw null; } set { } }
        public string ClusterFqdn { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ClusterPurpose? ClusterPurpose { get { throw null; } set { } }
        public string LoadBalancerSubnet { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.LoadBalancerType? LoadBalancerType { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.SslConfiguration SslConfiguration { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearning.Models.SystemService> SystemServices { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AllocationState : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.AllocationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AllocationState(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.AllocationState Resizing { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.AllocationState Steady { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.AllocationState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.AllocationState left, Azure.ResourceManager.MachineLearning.Models.AllocationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.AllocationState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.AllocationState left, Azure.ResourceManager.MachineLearning.Models.AllocationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AmlCompute : Azure.ResourceManager.MachineLearning.Models.Compute
    {
        public AmlCompute() { }
        public Azure.ResourceManager.MachineLearning.Models.AmlComputeProperties Properties { get { throw null; } set { } }
    }
    public partial class AmlComputeNodeInformation
    {
        internal AmlComputeNodeInformation() { }
        public string NodeId { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.NodeState? NodeState { get { throw null; } }
        public int? Port { get { throw null; } }
        public string PrivateIpAddress { get { throw null; } }
        public string PublicIpAddress { get { throw null; } }
        public string RunId { get { throw null; } }
    }
    public partial class AmlComputeProperties
    {
        public AmlComputeProperties() { }
        public Azure.ResourceManager.MachineLearning.Models.AllocationState? AllocationState { get { throw null; } }
        public System.DateTimeOffset? AllocationStateTransitionOn { get { throw null; } }
        public int? CurrentNodeCount { get { throw null; } }
        public bool? EnableNodePublicIp { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearning.Models.ErrorResponse> Errors { get { throw null; } }
        public bool? IsolatedNetwork { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.NodeStateCounts NodeStateCounts { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.OsType? OsType { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> PropertyBag { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.RemoteLoginPortPublicAccess? RemoteLoginPortPublicAccess { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ScaleSettings ScaleSettings { get { throw null; } set { } }
        public string SubnetId { get { throw null; } set { } }
        public int? TargetNodeCount { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.UserAccountCredentials UserAccountCredentials { get { throw null; } set { } }
        public string VirtualMachineImageId { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.VmPriority? VmPriority { get { throw null; } set { } }
        public string VmSize { get { throw null; } set { } }
    }
    public partial class AmlToken : Azure.ResourceManager.MachineLearning.Models.IdentityConfiguration
    {
        public AmlToken() { }
    }
    public partial class AmlUserFeature
    {
        internal AmlUserFeature() { }
        public string Description { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public string Id { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ApplicationSharingPolicy : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.ApplicationSharingPolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ApplicationSharingPolicy(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.ApplicationSharingPolicy Personal { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ApplicationSharingPolicy Shared { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.ApplicationSharingPolicy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.ApplicationSharingPolicy left, Azure.ResourceManager.MachineLearning.Models.ApplicationSharingPolicy right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.ApplicationSharingPolicy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.ApplicationSharingPolicy left, Azure.ResourceManager.MachineLearning.Models.ApplicationSharingPolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AssetBase : Azure.ResourceManager.MachineLearning.Models.ResourceBase
    {
        public AssetBase() { }
        public bool? IsAnonymous { get { throw null; } set { } }
        public bool? IsArchived { get { throw null; } set { } }
    }
    public partial class AssetContainer : Azure.ResourceManager.MachineLearning.Models.ResourceBase
    {
        public AssetContainer() { }
        public bool? IsArchived { get { throw null; } set { } }
        public string LatestVersion { get { throw null; } }
        public string NextVersion { get { throw null; } }
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
    public partial class AutoForecastHorizon : Azure.ResourceManager.MachineLearning.Models.ForecastHorizon
    {
        public AutoForecastHorizon() { }
    }
    public partial class AutoMLJob : Azure.ResourceManager.MachineLearning.Models.JobBaseDetails
    {
        public AutoMLJob(Azure.ResourceManager.MachineLearning.Models.AutoMLVertical taskDetails) { }
        public string EnvironmentId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> EnvironmentVariables { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.MachineLearning.Models.JobOutput> Outputs { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ResourceConfiguration Resources { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.AutoMLVertical TaskDetails { get { throw null; } set { } }
    }
    public partial class AutoMLVertical
    {
        public AutoMLVertical() { }
        public Azure.ResourceManager.MachineLearning.Models.LogVerbosity? LogVerbosity { get { throw null; } set { } }
    }
    public partial class AutoNCrossValidations : Azure.ResourceManager.MachineLearning.Models.NCrossValidations
    {
        public AutoNCrossValidations() { }
    }
    public partial class AutoPauseProperties
    {
        public AutoPauseProperties() { }
        public int? DelayInMinutes { get { throw null; } set { } }
        public bool? Enabled { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Autosave : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.Autosave>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Autosave(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.Autosave Local { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.Autosave None { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.Autosave Remote { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.Autosave other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.Autosave left, Azure.ResourceManager.MachineLearning.Models.Autosave right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.Autosave (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.Autosave left, Azure.ResourceManager.MachineLearning.Models.Autosave right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AutoScaleProperties
    {
        public AutoScaleProperties() { }
        public bool? Enabled { get { throw null; } set { } }
        public int? MaxNodeCount { get { throw null; } set { } }
        public int? MinNodeCount { get { throw null; } set { } }
    }
    public partial class AutoSeasonality : Azure.ResourceManager.MachineLearning.Models.Seasonality
    {
        public AutoSeasonality() { }
    }
    public partial class AutoTargetLags : Azure.ResourceManager.MachineLearning.Models.TargetLags
    {
        public AutoTargetLags() { }
    }
    public partial class AutoTargetRollingWindowSize : Azure.ResourceManager.MachineLearning.Models.TargetRollingWindowSize
    {
        public AutoTargetRollingWindowSize() { }
    }
    public partial class AzureBlobDatastore : Azure.ResourceManager.MachineLearning.Models.DatastoreDetails
    {
        public AzureBlobDatastore(Azure.ResourceManager.MachineLearning.Models.DatastoreCredentials credentials) : base (default(Azure.ResourceManager.MachineLearning.Models.DatastoreCredentials)) { }
        public string AccountName { get { throw null; } set { } }
        public string ContainerName { get { throw null; } set { } }
        public string Endpoint { get { throw null; } set { } }
        public string Protocol { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ServiceDataAccessAuthIdentity? ServiceDataAccessAuthIdentity { get { throw null; } set { } }
    }
    public partial class AzureDataLakeGen1Datastore : Azure.ResourceManager.MachineLearning.Models.DatastoreDetails
    {
        public AzureDataLakeGen1Datastore(Azure.ResourceManager.MachineLearning.Models.DatastoreCredentials credentials, string storeName) : base (default(Azure.ResourceManager.MachineLearning.Models.DatastoreCredentials)) { }
        public Azure.ResourceManager.MachineLearning.Models.ServiceDataAccessAuthIdentity? ServiceDataAccessAuthIdentity { get { throw null; } set { } }
        public string StoreName { get { throw null; } set { } }
    }
    public partial class AzureDataLakeGen2Datastore : Azure.ResourceManager.MachineLearning.Models.DatastoreDetails
    {
        public AzureDataLakeGen2Datastore(Azure.ResourceManager.MachineLearning.Models.DatastoreCredentials credentials, string accountName, string filesystem) : base (default(Azure.ResourceManager.MachineLearning.Models.DatastoreCredentials)) { }
        public string AccountName { get { throw null; } set { } }
        public string Endpoint { get { throw null; } set { } }
        public string Filesystem { get { throw null; } set { } }
        public string Protocol { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ServiceDataAccessAuthIdentity? ServiceDataAccessAuthIdentity { get { throw null; } set { } }
    }
    public partial class AzureFileDatastore : Azure.ResourceManager.MachineLearning.Models.DatastoreDetails
    {
        public AzureFileDatastore(Azure.ResourceManager.MachineLearning.Models.DatastoreCredentials credentials, string accountName, string fileShareName) : base (default(Azure.ResourceManager.MachineLearning.Models.DatastoreCredentials)) { }
        public string AccountName { get { throw null; } set { } }
        public string Endpoint { get { throw null; } set { } }
        public string FileShareName { get { throw null; } set { } }
        public string Protocol { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ServiceDataAccessAuthIdentity? ServiceDataAccessAuthIdentity { get { throw null; } set { } }
    }
    public partial class BanditPolicy : Azure.ResourceManager.MachineLearning.Models.EarlyTerminationPolicy
    {
        public BanditPolicy() { }
        public float? SlackAmount { get { throw null; } set { } }
        public float? SlackFactor { get { throw null; } set { } }
    }
    public partial class BatchDeploymentDataPatch
    {
        public BatchDeploymentDataPatch() { }
        public Azure.ResourceManager.MachineLearning.Models.PartialManagedServiceIdentity Identity { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public string Location { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.PartialBatchDeployment Properties { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.PartialSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class BatchDeploymentDetails : Azure.ResourceManager.MachineLearning.Models.EndpointDeploymentPropertiesBase
    {
        public BatchDeploymentDetails() { }
        public string Compute { get { throw null; } set { } }
        public int? ErrorThreshold { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.BatchLoggingLevel? LoggingLevel { get { throw null; } set { } }
        public int? MaxConcurrencyPerInstance { get { throw null; } set { } }
        public long? MiniBatchSize { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.AssetReferenceBase Model { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.BatchOutputAction? OutputAction { get { throw null; } set { } }
        public string OutputFileName { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.DeploymentProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.ResourceConfiguration Resources { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.BatchRetrySettings RetrySettings { get { throw null; } set { } }
    }
    public partial class BatchEndpointDataPatch
    {
        public BatchEndpointDataPatch() { }
        public string DefaultsDeploymentName { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.PartialManagedServiceIdentity Identity { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public string Location { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.PartialSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class BatchEndpointDetails : Azure.ResourceManager.MachineLearning.Models.EndpointPropertiesBase
    {
        public BatchEndpointDetails(Azure.ResourceManager.MachineLearning.Models.EndpointAuthMode authMode) : base (default(Azure.ResourceManager.MachineLearning.Models.EndpointAuthMode)) { }
        public string DefaultsDeploymentName { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.EndpointProvisioningState? ProvisioningState { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BatchLoggingLevel : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.BatchLoggingLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BatchLoggingLevel(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.BatchLoggingLevel Debug { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.BatchLoggingLevel Info { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.BatchLoggingLevel Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.BatchLoggingLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.BatchLoggingLevel left, Azure.ResourceManager.MachineLearning.Models.BatchLoggingLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.BatchLoggingLevel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.BatchLoggingLevel left, Azure.ResourceManager.MachineLearning.Models.BatchLoggingLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BatchOutputAction : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.BatchOutputAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BatchOutputAction(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.BatchOutputAction AppendRow { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.BatchOutputAction SummaryOnly { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.BatchOutputAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.BatchOutputAction left, Azure.ResourceManager.MachineLearning.Models.BatchOutputAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.BatchOutputAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.BatchOutputAction left, Azure.ResourceManager.MachineLearning.Models.BatchOutputAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BatchRetrySettings
    {
        public BatchRetrySettings() { }
        public int? MaxRetries { get { throw null; } set { } }
        public System.TimeSpan? Timeout { get { throw null; } set { } }
    }
    public partial class BayesianSamplingAlgorithm : Azure.ResourceManager.MachineLearning.Models.SamplingAlgorithm
    {
        public BayesianSamplingAlgorithm() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BillingCurrency : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.BillingCurrency>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BillingCurrency(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.BillingCurrency USD { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.BillingCurrency other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.BillingCurrency left, Azure.ResourceManager.MachineLearning.Models.BillingCurrency right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.BillingCurrency (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.BillingCurrency left, Azure.ResourceManager.MachineLearning.Models.BillingCurrency right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BuildContext
    {
        public BuildContext(System.Uri contextUri) { }
        public System.Uri ContextUri { get { throw null; } set { } }
        public string DockerfilePath { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Caching : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.Caching>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Caching(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.Caching None { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.Caching ReadOnly { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.Caching ReadWrite { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.Caching other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.Caching left, Azure.ResourceManager.MachineLearning.Models.Caching right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.Caching (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.Caching left, Azure.ResourceManager.MachineLearning.Models.Caching right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CertificateDatastoreCredentials : Azure.ResourceManager.MachineLearning.Models.DatastoreCredentials
    {
        public CertificateDatastoreCredentials(System.Guid clientId, Azure.ResourceManager.MachineLearning.Models.CertificateDatastoreSecrets secrets, System.Guid tenantId, string thumbprint) { }
        public System.Uri AuthorityUri { get { throw null; } set { } }
        public System.Guid ClientId { get { throw null; } set { } }
        public System.Uri ResourceUri { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.CertificateDatastoreSecrets Secrets { get { throw null; } set { } }
        public System.Guid TenantId { get { throw null; } set { } }
        public string Thumbprint { get { throw null; } set { } }
    }
    public partial class CertificateDatastoreSecrets : Azure.ResourceManager.MachineLearning.Models.DatastoreSecrets
    {
        public CertificateDatastoreSecrets() { }
        public string Certificate { get { throw null; } set { } }
    }
    public partial class Classification : Azure.ResourceManager.MachineLearning.Models.AutoMLVertical
    {
        public Classification() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.MachineLearning.Models.ClassificationModels> AllowedModels { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.MachineLearning.Models.ClassificationModels> BlockedModels { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.TableVerticalDataSettings DataSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.TableVerticalFeaturizationSettings FeaturizationSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.TableVerticalLimitSettings LimitSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ClassificationPrimaryMetrics? PrimaryMetric { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.TrainingSettings TrainingSettings { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClassificationModels : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.ClassificationModels>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClassificationModels(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.ClassificationModels BernoulliNaiveBayes { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ClassificationModels DecisionTree { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ClassificationModels ExtremeRandomTrees { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ClassificationModels GradientBoosting { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ClassificationModels KNN { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ClassificationModels LightGBM { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ClassificationModels LinearSVM { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ClassificationModels LogisticRegression { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ClassificationModels MultinomialNaiveBayes { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ClassificationModels RandomForest { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ClassificationModels SGD { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ClassificationModels SVM { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ClassificationModels XGBoostClassifier { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.ClassificationModels other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.ClassificationModels left, Azure.ResourceManager.MachineLearning.Models.ClassificationModels right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.ClassificationModels (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.ClassificationModels left, Azure.ResourceManager.MachineLearning.Models.ClassificationModels right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClassificationMultilabelPrimaryMetrics : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.ClassificationMultilabelPrimaryMetrics>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClassificationMultilabelPrimaryMetrics(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.ClassificationMultilabelPrimaryMetrics Accuracy { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ClassificationMultilabelPrimaryMetrics AUCWeighted { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ClassificationMultilabelPrimaryMetrics AveragePrecisionScoreWeighted { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ClassificationMultilabelPrimaryMetrics IOU { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ClassificationMultilabelPrimaryMetrics NormMacroRecall { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ClassificationMultilabelPrimaryMetrics PrecisionScoreWeighted { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.ClassificationMultilabelPrimaryMetrics other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.ClassificationMultilabelPrimaryMetrics left, Azure.ResourceManager.MachineLearning.Models.ClassificationMultilabelPrimaryMetrics right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.ClassificationMultilabelPrimaryMetrics (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.ClassificationMultilabelPrimaryMetrics left, Azure.ResourceManager.MachineLearning.Models.ClassificationMultilabelPrimaryMetrics right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClassificationPrimaryMetrics : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.ClassificationPrimaryMetrics>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClassificationPrimaryMetrics(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.ClassificationPrimaryMetrics Accuracy { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ClassificationPrimaryMetrics AUCWeighted { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ClassificationPrimaryMetrics AveragePrecisionScoreWeighted { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ClassificationPrimaryMetrics NormMacroRecall { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ClassificationPrimaryMetrics PrecisionScoreWeighted { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.ClassificationPrimaryMetrics other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.ClassificationPrimaryMetrics left, Azure.ResourceManager.MachineLearning.Models.ClassificationPrimaryMetrics right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.ClassificationPrimaryMetrics (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.ClassificationPrimaryMetrics left, Azure.ResourceManager.MachineLearning.Models.ClassificationPrimaryMetrics right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClusterPurpose : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.ClusterPurpose>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClusterPurpose(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.ClusterPurpose DenseProd { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ClusterPurpose DevTest { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ClusterPurpose FastProd { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.ClusterPurpose other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.ClusterPurpose left, Azure.ResourceManager.MachineLearning.Models.ClusterPurpose right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.ClusterPurpose (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.ClusterPurpose left, Azure.ResourceManager.MachineLearning.Models.ClusterPurpose right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CodeConfiguration
    {
        public CodeConfiguration(string scoringScript) { }
        public string CodeId { get { throw null; } set { } }
        public string ScoringScript { get { throw null; } set { } }
    }
    public partial class CodeContainerDetails : Azure.ResourceManager.MachineLearning.Models.AssetContainer
    {
        public CodeContainerDetails() { }
    }
    public partial class CodeVersionDetails : Azure.ResourceManager.MachineLearning.Models.AssetBase
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
    public partial class CommandJob : Azure.ResourceManager.MachineLearning.Models.JobBaseDetails
    {
        public CommandJob(string command, string environmentId) { }
        public string CodeId { get { throw null; } set { } }
        public string Command { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.DistributionConfiguration Distribution { get { throw null; } set { } }
        public string EnvironmentId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> EnvironmentVariables { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.MachineLearning.Models.JobInput> Inputs { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.CommandJobLimits Limits { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.MachineLearning.Models.JobOutput> Outputs { get { throw null; } set { } }
        public System.BinaryData Parameters { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.ResourceConfiguration Resources { get { throw null; } set { } }
    }
    public partial class CommandJobLimits : Azure.ResourceManager.MachineLearning.Models.JobLimits
    {
        public CommandJobLimits() { }
    }
    public partial class ComponentContainerDetails : Azure.ResourceManager.MachineLearning.Models.AssetContainer
    {
        public ComponentContainerDetails() { }
    }
    public partial class ComponentVersionDetails : Azure.ResourceManager.MachineLearning.Models.AssetBase
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
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearning.Models.ErrorResponse> ProvisioningErrors { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string ResourceId { get { throw null; } set { } }
    }
    public partial class ComputeInstance : Azure.ResourceManager.MachineLearning.Models.Compute
    {
        public ComputeInstance() { }
        public Azure.ResourceManager.MachineLearning.Models.ComputeInstanceProperties Properties { get { throw null; } set { } }
    }
    public partial class ComputeInstanceApplication
    {
        internal ComputeInstanceApplication() { }
        public string DisplayName { get { throw null; } }
        public System.Uri EndpointUri { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeInstanceAuthorizationType : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.ComputeInstanceAuthorizationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeInstanceAuthorizationType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.ComputeInstanceAuthorizationType Personal { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.ComputeInstanceAuthorizationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.ComputeInstanceAuthorizationType left, Azure.ResourceManager.MachineLearning.Models.ComputeInstanceAuthorizationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.ComputeInstanceAuthorizationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.ComputeInstanceAuthorizationType left, Azure.ResourceManager.MachineLearning.Models.ComputeInstanceAuthorizationType right) { throw null; }
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
        public Azure.ResourceManager.MachineLearning.Models.Autosave? Autosave { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.ComputeInstanceEnvironmentInfo Environment { get { throw null; } }
        public string Gpu { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.Network? Network { get { throw null; } }
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
        public Azure.ResourceManager.MachineLearning.Models.Caching? Caching { get { throw null; } }
        public int? DiskSizeGB { get { throw null; } }
        public int? Lun { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.StorageAccountType? StorageAccountType { get { throw null; } }
    }
    public partial class ComputeInstanceDataMount
    {
        internal ComputeInstanceDataMount() { }
        public string CreatedBy { get { throw null; } }
        public string Error { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.MountAction? MountAction { get { throw null; } }
        public System.DateTimeOffset? MountedOn { get { throw null; } }
        public string MountName { get { throw null; } }
        public string MountPath { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.MountState? MountState { get { throw null; } }
        public string Source { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.SourceType? SourceType { get { throw null; } }
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
        public Azure.ResourceManager.MachineLearning.Models.OperationName? OperationName { get { throw null; } }
        public System.DateTimeOffset? OperationOn { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.OperationStatus? OperationStatus { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.OperationTrigger? OperationTrigger { get { throw null; } }
    }
    public partial class ComputeInstanceProperties
    {
        public ComputeInstanceProperties() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearning.Models.ComputeInstanceApplication> Applications { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.ApplicationSharingPolicy? ApplicationSharingPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ComputeInstanceAuthorizationType? ComputeInstanceAuthorizationType { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ComputeInstanceConnectivityEndpoints ConnectivityEndpoints { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearning.Models.ComputeInstanceContainer> Containers { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.ComputeInstanceCreatedBy CreatedBy { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearning.Models.ComputeInstanceDataDisk> DataDisks { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearning.Models.ComputeInstanceDataMount> DataMounts { get { throw null; } }
        public bool? EnableNodePublicIp { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearning.Models.ErrorResponse> Errors { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.ComputeInstanceLastOperation LastOperation { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.AssignedUser PersonalComputeInstanceAssignedUser { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearning.Models.ComputeStartStopSchedule> SchedulesComputeStartStop { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.ScriptsToExecute Scripts { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ComputeInstanceSshSettings SshSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ComputeInstanceState? State { get { throw null; } }
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
        public Azure.ResourceManager.MachineLearning.Models.SshPublicAccess? SshPublicAccess { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeInstanceState : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.ComputeInstanceState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeInstanceState(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.ComputeInstanceState CreateFailed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ComputeInstanceState Creating { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ComputeInstanceState Deleting { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ComputeInstanceState JobRunning { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ComputeInstanceState Restarting { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ComputeInstanceState Running { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ComputeInstanceState SettingUp { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ComputeInstanceState SetupFailed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ComputeInstanceState Starting { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ComputeInstanceState Stopped { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ComputeInstanceState Stopping { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ComputeInstanceState Unknown { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ComputeInstanceState Unusable { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ComputeInstanceState UserSettingUp { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ComputeInstanceState UserSetupFailed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.ComputeInstanceState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.ComputeInstanceState left, Azure.ResourceManager.MachineLearning.Models.ComputeInstanceState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.ComputeInstanceState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.ComputeInstanceState left, Azure.ResourceManager.MachineLearning.Models.ComputeInstanceState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputePowerAction : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.ComputePowerAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputePowerAction(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.ComputePowerAction Start { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ComputePowerAction Stop { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.ComputePowerAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.ComputePowerAction left, Azure.ResourceManager.MachineLearning.Models.ComputePowerAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.ComputePowerAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.ComputePowerAction left, Azure.ResourceManager.MachineLearning.Models.ComputePowerAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ComputeResourcePatch
    {
        public ComputeResourcePatch() { }
        public Azure.ResourceManager.MachineLearning.Models.ScaleSettings ScaleSettings { get { throw null; } set { } }
    }
    public partial class ComputeSecrets
    {
        internal ComputeSecrets() { }
    }
    public partial class ComputeStartStopSchedule
    {
        internal ComputeStartStopSchedule() { }
        public Azure.ResourceManager.MachineLearning.Models.ComputePowerAction? Action { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.ProvisioningStatus? ProvisioningStatus { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.ScheduleBase Schedule { get { throw null; } }
    }
    public partial class ContainerResourceRequirements
    {
        public ContainerResourceRequirements() { }
        public Azure.ResourceManager.MachineLearning.Models.ContainerResourceSettings ContainerResourceLimits { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ContainerResourceSettings ContainerResourceRequests { get { throw null; } set { } }
    }
    public partial class ContainerResourceSettings
    {
        public ContainerResourceSettings() { }
        public string Cpu { get { throw null; } set { } }
        public string Gpu { get { throw null; } set { } }
        public string Memory { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerType : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.ContainerType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.ContainerType InferenceServer { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ContainerType StorageInitializer { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.ContainerType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.ContainerType left, Azure.ResourceManager.MachineLearning.Models.ContainerType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.ContainerType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.ContainerType left, Azure.ResourceManager.MachineLearning.Models.ContainerType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CronSchedule : Azure.ResourceManager.MachineLearning.Models.ScheduleBase
    {
        public CronSchedule(string expression) { }
        public string Expression { get { throw null; } set { } }
    }
    public partial class CustomForecastHorizon : Azure.ResourceManager.MachineLearning.Models.ForecastHorizon
    {
        public CustomForecastHorizon(int value) { }
        public int Value { get { throw null; } set { } }
    }
    public partial class CustomModelJobInput : Azure.ResourceManager.MachineLearning.Models.JobInput
    {
        public CustomModelJobInput(System.Uri uri) { }
        public Azure.ResourceManager.MachineLearning.Models.InputDeliveryMode? Mode { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    public partial class CustomModelJobOutput : Azure.ResourceManager.MachineLearning.Models.JobOutput
    {
        public CustomModelJobOutput() { }
        public Azure.ResourceManager.MachineLearning.Models.OutputDeliveryMode? Mode { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    public partial class CustomNCrossValidations : Azure.ResourceManager.MachineLearning.Models.NCrossValidations
    {
        public CustomNCrossValidations(int value) { }
        public int Value { get { throw null; } set { } }
    }
    public partial class CustomSeasonality : Azure.ResourceManager.MachineLearning.Models.Seasonality
    {
        public CustomSeasonality(int value) { }
        public int Value { get { throw null; } set { } }
    }
    public partial class CustomTargetLags : Azure.ResourceManager.MachineLearning.Models.TargetLags
    {
        public CustomTargetLags(System.Collections.Generic.IEnumerable<int> values) { }
        public System.Collections.Generic.IList<int> Values { get { throw null; } }
    }
    public partial class CustomTargetRollingWindowSize : Azure.ResourceManager.MachineLearning.Models.TargetRollingWindowSize
    {
        public CustomTargetRollingWindowSize(int value) { }
        public int Value { get { throw null; } set { } }
    }
    public partial class Databricks : Azure.ResourceManager.MachineLearning.Models.Compute
    {
        public Databricks() { }
        public Azure.ResourceManager.MachineLearning.Models.DatabricksProperties Properties { get { throw null; } set { } }
    }
    public partial class DatabricksComputeSecrets : Azure.ResourceManager.MachineLearning.Models.ComputeSecrets
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
    public partial class DataContainerDetails : Azure.ResourceManager.MachineLearning.Models.AssetContainer
    {
        public DataContainerDetails(Azure.ResourceManager.MachineLearning.Models.DataType dataType) { }
        public Azure.ResourceManager.MachineLearning.Models.DataType DataType { get { throw null; } set { } }
    }
    public partial class DataFactory : Azure.ResourceManager.MachineLearning.Models.Compute
    {
        public DataFactory() { }
    }
    public partial class DataLakeAnalytics : Azure.ResourceManager.MachineLearning.Models.Compute
    {
        public DataLakeAnalytics() { }
        public string DataLakeStoreAccountName { get { throw null; } set { } }
    }
    public partial class DataPathAssetReference : Azure.ResourceManager.MachineLearning.Models.AssetReferenceBase
    {
        public DataPathAssetReference() { }
        public string DatastoreId { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
    }
    public partial class DataSettings
    {
        public DataSettings(string targetColumnName, Azure.ResourceManager.MachineLearning.Models.TrainingDataSettings trainingDataSettings) { }
        public Azure.ResourceManager.MachineLearning.Models.MLTableJobInput Data { get { throw null; } set { } }
        public string TargetColumnName { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.TestDataSettings TestData { get { throw null; } set { } }
    }
    public partial class DatastoreCredentials
    {
        public DatastoreCredentials() { }
    }
    public partial class DatastoreDetails : Azure.ResourceManager.MachineLearning.Models.ResourceBase
    {
        public DatastoreDetails(Azure.ResourceManager.MachineLearning.Models.DatastoreCredentials credentials) { }
        public Azure.ResourceManager.MachineLearning.Models.DatastoreCredentials Credentials { get { throw null; } set { } }
        public bool? IsDefault { get { throw null; } }
    }
    public partial class DatastoreSecrets
    {
        public DatastoreSecrets() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataType : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.DataType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.DataType MLTable { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.DataType UriFile { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.DataType UriFolder { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.DataType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.DataType left, Azure.ResourceManager.MachineLearning.Models.DataType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.DataType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.DataType left, Azure.ResourceManager.MachineLearning.Models.DataType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataVersionBaseDetails : Azure.ResourceManager.MachineLearning.Models.AssetBase
    {
        public DataVersionBaseDetails(System.Uri dataUri) { }
        public System.Uri DataUri { get { throw null; } set { } }
    }
    public partial class DefaultScaleSettings : Azure.ResourceManager.MachineLearning.Models.OnlineScaleSettings
    {
        public DefaultScaleSettings() { }
    }
    public partial class DeploymentLogs
    {
        internal DeploymentLogs() { }
        public string Content { get { throw null; } }
    }
    public partial class DeploymentLogsContent
    {
        public DeploymentLogsContent() { }
        public Azure.ResourceManager.MachineLearning.Models.ContainerType? ContainerType { get { throw null; } set { } }
        public int? Tail { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeploymentProvisioningState : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.DeploymentProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeploymentProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.DeploymentProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.DeploymentProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.DeploymentProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.DeploymentProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.DeploymentProvisioningState Scaling { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.DeploymentProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.DeploymentProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.DeploymentProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.DeploymentProvisioningState left, Azure.ResourceManager.MachineLearning.Models.DeploymentProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.DeploymentProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.DeploymentProvisioningState left, Azure.ResourceManager.MachineLearning.Models.DeploymentProvisioningState right) { throw null; }
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
        public Azure.ResourceManager.MachineLearning.Models.DiagnoseResponseResultValue Value { get { throw null; } }
    }
    public partial class DiagnoseResponseResultValue
    {
        internal DiagnoseResponseResultValue() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearning.Models.DiagnoseResult> ApplicationInsightsResults { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearning.Models.DiagnoseResult> ContainerRegistryResults { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearning.Models.DiagnoseResult> DnsResolutionResults { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearning.Models.DiagnoseResult> KeyVaultResults { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearning.Models.DiagnoseResult> NetworkSecurityRuleResults { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearning.Models.DiagnoseResult> OtherResults { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearning.Models.DiagnoseResult> ResourceLockResults { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearning.Models.DiagnoseResult> StorageAccountResults { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearning.Models.DiagnoseResult> UserDefinedRouteResults { get { throw null; } }
    }
    public partial class DiagnoseResult
    {
        internal DiagnoseResult() { }
        public string Code { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.DiagnoseResultLevel? Level { get { throw null; } }
        public string Message { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiagnoseResultLevel : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.DiagnoseResultLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiagnoseResultLevel(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.DiagnoseResultLevel Error { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.DiagnoseResultLevel Information { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.DiagnoseResultLevel Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.DiagnoseResultLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.DiagnoseResultLevel left, Azure.ResourceManager.MachineLearning.Models.DiagnoseResultLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.DiagnoseResultLevel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.DiagnoseResultLevel left, Azure.ResourceManager.MachineLearning.Models.DiagnoseResultLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DiagnoseWorkspaceContent
    {
        public DiagnoseWorkspaceContent() { }
        public Azure.ResourceManager.MachineLearning.Models.DiagnoseRequestProperties Value { get { throw null; } set { } }
    }
    public partial class DistributionConfiguration
    {
        public DistributionConfiguration() { }
    }
    public partial class EarlyTerminationPolicy
    {
        public EarlyTerminationPolicy() { }
        public int? DelayEvaluation { get { throw null; } set { } }
        public int? EvaluationInterval { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EgressPublicNetworkAccessType : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.EgressPublicNetworkAccessType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EgressPublicNetworkAccessType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.EgressPublicNetworkAccessType Disabled { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.EgressPublicNetworkAccessType Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.EgressPublicNetworkAccessType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.EgressPublicNetworkAccessType left, Azure.ResourceManager.MachineLearning.Models.EgressPublicNetworkAccessType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.EgressPublicNetworkAccessType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.EgressPublicNetworkAccessType left, Azure.ResourceManager.MachineLearning.Models.EgressPublicNetworkAccessType right) { throw null; }
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
        public EncryptionProperty(Azure.ResourceManager.MachineLearning.Models.EncryptionStatus status, Azure.ResourceManager.MachineLearning.Models.EncryptionKeyVaultProperties keyVaultProperties) { }
        public Azure.ResourceManager.MachineLearning.Models.EncryptionKeyVaultProperties KeyVaultProperties { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.EncryptionStatus Status { get { throw null; } set { } }
        public string UserAssignedIdentity { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EncryptionStatus : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.EncryptionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EncryptionStatus(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.EncryptionStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.EncryptionStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.EncryptionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.EncryptionStatus left, Azure.ResourceManager.MachineLearning.Models.EncryptionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.EncryptionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.EncryptionStatus left, Azure.ResourceManager.MachineLearning.Models.EncryptionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EndpointAuthKeys
    {
        public EndpointAuthKeys() { }
        public string PrimaryKey { get { throw null; } set { } }
        public string SecondaryKey { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EndpointAuthMode : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.EndpointAuthMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EndpointAuthMode(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.EndpointAuthMode AADToken { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.EndpointAuthMode AMLToken { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.EndpointAuthMode Key { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.EndpointAuthMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.EndpointAuthMode left, Azure.ResourceManager.MachineLearning.Models.EndpointAuthMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.EndpointAuthMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.EndpointAuthMode left, Azure.ResourceManager.MachineLearning.Models.EndpointAuthMode right) { throw null; }
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
    public readonly partial struct EndpointComputeType : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.EndpointComputeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EndpointComputeType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.EndpointComputeType AzureMLCompute { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.EndpointComputeType Kubernetes { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.EndpointComputeType Managed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.EndpointComputeType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.EndpointComputeType left, Azure.ResourceManager.MachineLearning.Models.EndpointComputeType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.EndpointComputeType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.EndpointComputeType left, Azure.ResourceManager.MachineLearning.Models.EndpointComputeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EndpointDeploymentPropertiesBase
    {
        public EndpointDeploymentPropertiesBase() { }
        public Azure.ResourceManager.MachineLearning.Models.CodeConfiguration CodeConfiguration { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string EnvironmentId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> EnvironmentVariables { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Properties { get { throw null; } set { } }
    }
    public partial class EndpointPropertiesBase
    {
        public EndpointPropertiesBase(Azure.ResourceManager.MachineLearning.Models.EndpointAuthMode authMode) { }
        public Azure.ResourceManager.MachineLearning.Models.EndpointAuthMode AuthMode { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.EndpointAuthKeys Keys { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Properties { get { throw null; } set { } }
        public System.Uri ScoringUri { get { throw null; } }
        public System.Uri SwaggerUri { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EndpointProvisioningState : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.EndpointProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EndpointProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.EndpointProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.EndpointProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.EndpointProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.EndpointProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.EndpointProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.EndpointProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.EndpointProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.EndpointProvisioningState left, Azure.ResourceManager.MachineLearning.Models.EndpointProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.EndpointProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.EndpointProvisioningState left, Azure.ResourceManager.MachineLearning.Models.EndpointProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EnvironmentContainerDetails : Azure.ResourceManager.MachineLearning.Models.AssetContainer
    {
        public EnvironmentContainerDetails() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EnvironmentType : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.EnvironmentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EnvironmentType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.EnvironmentType Curated { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.EnvironmentType UserCreated { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.EnvironmentType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.EnvironmentType left, Azure.ResourceManager.MachineLearning.Models.EnvironmentType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.EnvironmentType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.EnvironmentType left, Azure.ResourceManager.MachineLearning.Models.EnvironmentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EnvironmentVersionDetails : Azure.ResourceManager.MachineLearning.Models.AssetBase
    {
        public EnvironmentVersionDetails() { }
        public Azure.ResourceManager.MachineLearning.Models.BuildContext Build { get { throw null; } set { } }
        public string CondaFile { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.EnvironmentType? EnvironmentType { get { throw null; } }
        public string Image { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.InferenceContainerProperties InferenceConfig { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.OperatingSystemType? OsType { get { throw null; } set { } }
    }
    public partial class ErrorResponse
    {
        internal ErrorResponse() { }
        public Azure.ResponseError Error { get { throw null; } }
    }
    public partial class EstimatedVMPrice
    {
        internal EstimatedVMPrice() { }
        public Azure.ResourceManager.MachineLearning.Models.VMPriceOSType OsType { get { throw null; } }
        public double RetailPrice { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.VMTier VmTier { get { throw null; } }
    }
    public partial class EstimatedVMPrices
    {
        internal EstimatedVMPrices() { }
        public Azure.ResourceManager.MachineLearning.Models.BillingCurrency BillingCurrency { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.UnitOfMeasure UnitOfMeasure { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearning.Models.EstimatedVMPrice> Values { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FeatureLags : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.FeatureLags>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FeatureLags(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.FeatureLags Auto { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.FeatureLags None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.FeatureLags other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.FeatureLags left, Azure.ResourceManager.MachineLearning.Models.FeatureLags right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.FeatureLags (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.FeatureLags left, Azure.ResourceManager.MachineLearning.Models.FeatureLags right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FeaturizationMode : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.FeaturizationMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FeaturizationMode(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.FeaturizationMode Auto { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.FeaturizationMode Custom { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.FeaturizationMode Off { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.FeaturizationMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.FeaturizationMode left, Azure.ResourceManager.MachineLearning.Models.FeaturizationMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.FeaturizationMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.FeaturizationMode left, Azure.ResourceManager.MachineLearning.Models.FeaturizationMode right) { throw null; }
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
    public partial class ForecastHorizon
    {
        public ForecastHorizon() { }
    }
    public partial class Forecasting : Azure.ResourceManager.MachineLearning.Models.AutoMLVertical
    {
        public Forecasting() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.MachineLearning.Models.ForecastingModels> AllowedModels { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.MachineLearning.Models.ForecastingModels> BlockedModels { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.TableVerticalDataSettings DataSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.TableVerticalFeaturizationSettings FeaturizationSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ForecastingSettings ForecastingSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.TableVerticalLimitSettings LimitSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ForecastingPrimaryMetrics? PrimaryMetric { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.TrainingSettings TrainingSettings { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ForecastingModels : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.ForecastingModels>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ForecastingModels(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.ForecastingModels Arimax { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ForecastingModels AutoArima { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ForecastingModels Average { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ForecastingModels DecisionTree { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ForecastingModels ElasticNet { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ForecastingModels ExponentialSmoothing { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ForecastingModels ExtremeRandomTrees { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ForecastingModels GradientBoosting { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ForecastingModels KNN { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ForecastingModels LassoLars { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ForecastingModels LightGBM { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ForecastingModels Naive { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ForecastingModels Prophet { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ForecastingModels RandomForest { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ForecastingModels SeasonalAverage { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ForecastingModels SeasonalNaive { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ForecastingModels SGD { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ForecastingModels TCNForecaster { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ForecastingModels XGBoostRegressor { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.ForecastingModels other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.ForecastingModels left, Azure.ResourceManager.MachineLearning.Models.ForecastingModels right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.ForecastingModels (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.ForecastingModels left, Azure.ResourceManager.MachineLearning.Models.ForecastingModels right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ForecastingPrimaryMetrics : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.ForecastingPrimaryMetrics>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ForecastingPrimaryMetrics(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.ForecastingPrimaryMetrics NormalizedMeanAbsoluteError { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ForecastingPrimaryMetrics NormalizedRootMeanSquaredError { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ForecastingPrimaryMetrics R2Score { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ForecastingPrimaryMetrics SpearmanCorrelation { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.ForecastingPrimaryMetrics other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.ForecastingPrimaryMetrics left, Azure.ResourceManager.MachineLearning.Models.ForecastingPrimaryMetrics right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.ForecastingPrimaryMetrics (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.ForecastingPrimaryMetrics left, Azure.ResourceManager.MachineLearning.Models.ForecastingPrimaryMetrics right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ForecastingSettings
    {
        public ForecastingSettings() { }
        public string CountryOrRegionForHolidays { get { throw null; } set { } }
        public int? CvStepSize { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.FeatureLags? FeatureLags { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ForecastHorizon ForecastHorizon { get { throw null; } set { } }
        public string Frequency { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.Seasonality Seasonality { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ShortSeriesHandlingConfiguration? ShortSeriesHandlingConfig { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.TargetAggregationFunction? TargetAggregateFunction { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.TargetLags TargetLags { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.TargetRollingWindowSize TargetRollingWindowSize { get { throw null; } set { } }
        public string TimeColumnName { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> TimeSeriesIdColumnNames { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.UseStl? UseStl { get { throw null; } set { } }
    }
    public partial class FqdnEndpoint
    {
        internal FqdnEndpoint() { }
        public string DomainName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearning.Models.FqdnEndpointDetail> EndpointDetails { get { throw null; } }
    }
    public partial class FqdnEndpointDetail
    {
        internal FqdnEndpointDetail() { }
        public int? Port { get { throw null; } }
    }
    public partial class FqdnEndpoints
    {
        internal FqdnEndpoints() { }
        public Azure.ResourceManager.MachineLearning.Models.FqdnEndpointsProperties Properties { get { throw null; } }
    }
    public partial class FqdnEndpointsProperties
    {
        internal FqdnEndpointsProperties() { }
        public string Category { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearning.Models.FqdnEndpoint> Endpoints { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Goal : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.Goal>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Goal(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.Goal Maximize { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.Goal Minimize { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.Goal other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.Goal left, Azure.ResourceManager.MachineLearning.Models.Goal right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.Goal (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.Goal left, Azure.ResourceManager.MachineLearning.Models.Goal right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class GridSamplingAlgorithm : Azure.ResourceManager.MachineLearning.Models.SamplingAlgorithm
    {
        public GridSamplingAlgorithm() { }
    }
    public partial class HdfsDatastore : Azure.ResourceManager.MachineLearning.Models.DatastoreDetails
    {
        public HdfsDatastore(Azure.ResourceManager.MachineLearning.Models.DatastoreCredentials credentials, string nameNodeAddress) : base (default(Azure.ResourceManager.MachineLearning.Models.DatastoreCredentials)) { }
        public string HdfsServerCertificate { get { throw null; } set { } }
        public string NameNodeAddress { get { throw null; } set { } }
        public string Protocol { get { throw null; } set { } }
    }
    public partial class HDInsight : Azure.ResourceManager.MachineLearning.Models.Compute
    {
        public HDInsight() { }
        public Azure.ResourceManager.MachineLearning.Models.HDInsightProperties Properties { get { throw null; } set { } }
    }
    public partial class HDInsightProperties
    {
        public HDInsightProperties() { }
        public string Address { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.VirtualMachineSshCredentials AdministratorAccount { get { throw null; } set { } }
        public int? SshPort { get { throw null; } set { } }
    }
    public partial class IdAssetReference : Azure.ResourceManager.MachineLearning.Models.AssetReferenceBase
    {
        public IdAssetReference(string assetId) { }
        public string AssetId { get { throw null; } set { } }
    }
    public partial class IdentityConfiguration
    {
        public IdentityConfiguration() { }
    }
    public partial class ImageClassification : Azure.ResourceManager.MachineLearning.Models.AutoMLVertical
    {
        public ImageClassification(Azure.ResourceManager.MachineLearning.Models.ImageVerticalDataSettings dataSettings, Azure.ResourceManager.MachineLearning.Models.ImageLimitSettings limitSettings) { }
        public Azure.ResourceManager.MachineLearning.Models.ImageVerticalDataSettings DataSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ImageLimitSettings LimitSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ImageModelSettingsClassification ModelSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ClassificationPrimaryMetrics? PrimaryMetric { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.MachineLearning.Models.ImageModelDistributionSettingsClassification> SearchSpace { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ImageSweepSettings SweepSettings { get { throw null; } set { } }
    }
    public partial class ImageClassificationMultilabel : Azure.ResourceManager.MachineLearning.Models.AutoMLVertical
    {
        public ImageClassificationMultilabel(Azure.ResourceManager.MachineLearning.Models.ImageVerticalDataSettings dataSettings, Azure.ResourceManager.MachineLearning.Models.ImageLimitSettings limitSettings) { }
        public Azure.ResourceManager.MachineLearning.Models.ImageVerticalDataSettings DataSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ImageLimitSettings LimitSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ImageModelSettingsClassification ModelSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ClassificationMultilabelPrimaryMetrics? PrimaryMetric { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.MachineLearning.Models.ImageModelDistributionSettingsClassification> SearchSpace { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ImageSweepSettings SweepSettings { get { throw null; } set { } }
    }
    public partial class ImageInstanceSegmentation : Azure.ResourceManager.MachineLearning.Models.AutoMLVertical
    {
        public ImageInstanceSegmentation(Azure.ResourceManager.MachineLearning.Models.ImageVerticalDataSettings dataSettings, Azure.ResourceManager.MachineLearning.Models.ImageLimitSettings limitSettings) { }
        public Azure.ResourceManager.MachineLearning.Models.ImageVerticalDataSettings DataSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ImageLimitSettings LimitSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ImageModelSettingsObjectDetection ModelSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.InstanceSegmentationPrimaryMetrics? PrimaryMetric { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.MachineLearning.Models.ImageModelDistributionSettingsObjectDetection> SearchSpace { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ImageSweepSettings SweepSettings { get { throw null; } set { } }
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
    public partial class ImageModelDistributionSettingsClassification : Azure.ResourceManager.MachineLearning.Models.ImageModelDistributionSettings
    {
        public ImageModelDistributionSettingsClassification() { }
        public string TrainingCropSize { get { throw null; } set { } }
        public string ValidationCropSize { get { throw null; } set { } }
        public string ValidationResizeSize { get { throw null; } set { } }
        public string WeightedLoss { get { throw null; } set { } }
    }
    public partial class ImageModelDistributionSettingsObjectDetection : Azure.ResourceManager.MachineLearning.Models.ImageModelDistributionSettings
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
        public Azure.ResourceManager.MachineLearning.Models.LearningRateScheduler? LearningRateScheduler { get { throw null; } set { } }
        public string ModelName { get { throw null; } set { } }
        public float? Momentum { get { throw null; } set { } }
        public bool? Nesterov { get { throw null; } set { } }
        public int? NumberOfEpochs { get { throw null; } set { } }
        public int? NumberOfWorkers { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.StochasticOptimizer? Optimizer { get { throw null; } set { } }
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
    public partial class ImageModelSettingsClassification : Azure.ResourceManager.MachineLearning.Models.ImageModelSettings
    {
        public ImageModelSettingsClassification() { }
        public int? TrainingCropSize { get { throw null; } set { } }
        public int? ValidationCropSize { get { throw null; } set { } }
        public int? ValidationResizeSize { get { throw null; } set { } }
        public int? WeightedLoss { get { throw null; } set { } }
    }
    public partial class ImageModelSettingsObjectDetection : Azure.ResourceManager.MachineLearning.Models.ImageModelSettings
    {
        public ImageModelSettingsObjectDetection() { }
        public int? BoxDetectionsPerImage { get { throw null; } set { } }
        public float? BoxScoreThreshold { get { throw null; } set { } }
        public int? ImageSize { get { throw null; } set { } }
        public int? MaxSize { get { throw null; } set { } }
        public int? MinSize { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ModelSize? ModelSize { get { throw null; } set { } }
        public bool? MultiScale { get { throw null; } set { } }
        public float? NmsIouThreshold { get { throw null; } set { } }
        public string TileGridSize { get { throw null; } set { } }
        public float? TileOverlapRatio { get { throw null; } set { } }
        public float? TilePredictionsNmsThreshold { get { throw null; } set { } }
        public float? ValidationIouThreshold { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ValidationMetricType? ValidationMetricType { get { throw null; } set { } }
    }
    public partial class ImageObjectDetection : Azure.ResourceManager.MachineLearning.Models.AutoMLVertical
    {
        public ImageObjectDetection(Azure.ResourceManager.MachineLearning.Models.ImageVerticalDataSettings dataSettings, Azure.ResourceManager.MachineLearning.Models.ImageLimitSettings limitSettings) { }
        public Azure.ResourceManager.MachineLearning.Models.ImageVerticalDataSettings DataSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ImageLimitSettings LimitSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ImageModelSettingsObjectDetection ModelSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ObjectDetectionPrimaryMetrics? PrimaryMetric { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.MachineLearning.Models.ImageModelDistributionSettingsObjectDetection> SearchSpace { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ImageSweepSettings SweepSettings { get { throw null; } set { } }
    }
    public partial class ImageSweepLimitSettings
    {
        public ImageSweepLimitSettings() { }
        public int? MaxConcurrentTrials { get { throw null; } set { } }
        public int? MaxTrials { get { throw null; } set { } }
    }
    public partial class ImageSweepSettings
    {
        public ImageSweepSettings(Azure.ResourceManager.MachineLearning.Models.ImageSweepLimitSettings limits, Azure.ResourceManager.MachineLearning.Models.SamplingAlgorithmType samplingAlgorithm) { }
        public Azure.ResourceManager.MachineLearning.Models.EarlyTerminationPolicy EarlyTermination { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ImageSweepLimitSettings Limits { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.SamplingAlgorithmType SamplingAlgorithm { get { throw null; } set { } }
    }
    public partial class ImageVerticalDataSettings : Azure.ResourceManager.MachineLearning.Models.DataSettings
    {
        public ImageVerticalDataSettings(string targetColumnName, Azure.ResourceManager.MachineLearning.Models.TrainingDataSettings trainingDataSettings) : base (default(string), default(Azure.ResourceManager.MachineLearning.Models.TrainingDataSettings)) { }
        public Azure.ResourceManager.MachineLearning.Models.ImageVerticalValidationDataSettings ValidationData { get { throw null; } set { } }
    }
    public partial class ImageVerticalValidationDataSettings : Azure.ResourceManager.MachineLearning.Models.ValidationDataSettings
    {
        public ImageVerticalValidationDataSettings() { }
    }
    public partial class InferenceContainerProperties
    {
        public InferenceContainerProperties() { }
        public Azure.ResourceManager.MachineLearning.Models.Route LivenessRoute { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.Route ReadinessRoute { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.Route ScoringRoute { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct InputDeliveryMode : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.InputDeliveryMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public InputDeliveryMode(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.InputDeliveryMode Direct { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.InputDeliveryMode Download { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.InputDeliveryMode EvalDownload { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.InputDeliveryMode EvalMount { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.InputDeliveryMode ReadOnlyMount { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.InputDeliveryMode ReadWriteMount { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.InputDeliveryMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.InputDeliveryMode left, Azure.ResourceManager.MachineLearning.Models.InputDeliveryMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.InputDeliveryMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.InputDeliveryMode left, Azure.ResourceManager.MachineLearning.Models.InputDeliveryMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct InstanceSegmentationPrimaryMetrics : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.InstanceSegmentationPrimaryMetrics>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public InstanceSegmentationPrimaryMetrics(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.InstanceSegmentationPrimaryMetrics MeanAveragePrecision { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.InstanceSegmentationPrimaryMetrics other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.InstanceSegmentationPrimaryMetrics left, Azure.ResourceManager.MachineLearning.Models.InstanceSegmentationPrimaryMetrics right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.InstanceSegmentationPrimaryMetrics (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.InstanceSegmentationPrimaryMetrics left, Azure.ResourceManager.MachineLearning.Models.InstanceSegmentationPrimaryMetrics right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class InstanceTypeSchema
    {
        public InstanceTypeSchema() { }
        public System.Collections.Generic.IDictionary<string, string> NodeSelector { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.InstanceTypeSchemaResources Resources { get { throw null; } set { } }
    }
    public partial class InstanceTypeSchemaResources
    {
        public InstanceTypeSchemaResources() { }
        public System.Collections.Generic.IDictionary<string, string> Limits { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Requests { get { throw null; } }
    }
    public partial class JobBaseDetails : Azure.ResourceManager.MachineLearning.Models.ResourceBase
    {
        public JobBaseDetails() { }
        public string ComputeId { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string ExperimentName { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.IdentityConfiguration Identity { get { throw null; } set { } }
        public bool? IsArchived { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ScheduleBase Schedule { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.MachineLearning.Models.JobService> Services { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.JobStatus? Status { get { throw null; } }
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
    public readonly partial struct JobStatus : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.JobStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public JobStatus(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.JobStatus Canceled { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.JobStatus CancelRequested { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.JobStatus Completed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.JobStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.JobStatus Finalizing { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.JobStatus NotResponding { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.JobStatus NotStarted { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.JobStatus Paused { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.JobStatus Preparing { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.JobStatus Provisioning { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.JobStatus Queued { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.JobStatus Running { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.JobStatus Scheduled { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.JobStatus Starting { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.JobStatus Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.JobStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.JobStatus left, Azure.ResourceManager.MachineLearning.Models.JobStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.JobStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.JobStatus left, Azure.ResourceManager.MachineLearning.Models.JobStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KerberosKeytabCredentials : Azure.ResourceManager.MachineLearning.Models.DatastoreCredentials
    {
        public KerberosKeytabCredentials(Azure.ResourceManager.MachineLearning.Models.KerberosKeytabSecrets secrets, string kerberosKdcAddress, string kerberosPrincipal, string kerberosRealm) { }
        public string KerberosKdcAddress { get { throw null; } set { } }
        public string KerberosPrincipal { get { throw null; } set { } }
        public string KerberosRealm { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.KerberosKeytabSecrets Secrets { get { throw null; } set { } }
    }
    public partial class KerberosKeytabSecrets : Azure.ResourceManager.MachineLearning.Models.DatastoreSecrets
    {
        public KerberosKeytabSecrets() { }
        public string KerberosKeytab { get { throw null; } set { } }
    }
    public partial class KerberosPasswordCredentials : Azure.ResourceManager.MachineLearning.Models.DatastoreCredentials
    {
        public KerberosPasswordCredentials(Azure.ResourceManager.MachineLearning.Models.KerberosPasswordSecrets secrets, string kerberosKdcAddress, string kerberosPrincipal, string kerberosRealm) { }
        public string KerberosKdcAddress { get { throw null; } set { } }
        public string KerberosPrincipal { get { throw null; } set { } }
        public string KerberosRealm { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.KerberosPasswordSecrets Secrets { get { throw null; } set { } }
    }
    public partial class KerberosPasswordSecrets : Azure.ResourceManager.MachineLearning.Models.DatastoreSecrets
    {
        public KerberosPasswordSecrets() { }
        public string KerberosPassword { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KeyType : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.KeyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KeyType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.KeyType Primary { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.KeyType Secondary { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.KeyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.KeyType left, Azure.ResourceManager.MachineLearning.Models.KeyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.KeyType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.KeyType left, Azure.ResourceManager.MachineLearning.Models.KeyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Kubernetes : Azure.ResourceManager.MachineLearning.Models.Compute
    {
        public Kubernetes() { }
        public Azure.ResourceManager.MachineLearning.Models.KubernetesProperties Properties { get { throw null; } set { } }
    }
    public partial class KubernetesOnlineDeployment : Azure.ResourceManager.MachineLearning.Models.OnlineDeploymentDetails
    {
        public KubernetesOnlineDeployment() { }
        public Azure.ResourceManager.MachineLearning.Models.ContainerResourceRequirements ContainerResourceRequirements { get { throw null; } set { } }
    }
    public partial class KubernetesProperties
    {
        public KubernetesProperties() { }
        public string DefaultInstanceType { get { throw null; } set { } }
        public string ExtensionInstanceReleaseTrain { get { throw null; } set { } }
        public string ExtensionPrincipalId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.MachineLearning.Models.InstanceTypeSchema> InstanceTypes { get { throw null; } }
        public string Namespace { get { throw null; } set { } }
        public string RelayConnectionString { get { throw null; } set { } }
        public string ServiceBusConnectionString { get { throw null; } set { } }
        public string VcName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LearningRateScheduler : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.LearningRateScheduler>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LearningRateScheduler(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.LearningRateScheduler None { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.LearningRateScheduler Step { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.LearningRateScheduler WarmupCosine { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.LearningRateScheduler other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.LearningRateScheduler left, Azure.ResourceManager.MachineLearning.Models.LearningRateScheduler right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.LearningRateScheduler (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.LearningRateScheduler left, Azure.ResourceManager.MachineLearning.Models.LearningRateScheduler right) { throw null; }
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
    public readonly partial struct ListViewType : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.ListViewType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ListViewType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.ListViewType ActiveOnly { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ListViewType All { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ListViewType ArchivedOnly { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.ListViewType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.ListViewType left, Azure.ResourceManager.MachineLearning.Models.ListViewType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.ListViewType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.ListViewType left, Azure.ResourceManager.MachineLearning.Models.ListViewType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ListWorkspaceKeysResult
    {
        internal ListWorkspaceKeysResult() { }
        public string AppInsightsInstrumentationKey { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.RegistryListCredentialsResult ContainerRegistryCredentials { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.ListNotebookKeysResult NotebookAccessKeys { get { throw null; } }
        public string UserStorageKey { get { throw null; } }
        public string UserStorageResourceId { get { throw null; } }
    }
    public partial class LiteralJobInput : Azure.ResourceManager.MachineLearning.Models.JobInput
    {
        public LiteralJobInput(string value) { }
        public string Value { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LoadBalancerType : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.LoadBalancerType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LoadBalancerType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.LoadBalancerType InternalLoadBalancer { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.LoadBalancerType PublicIp { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.LoadBalancerType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.LoadBalancerType left, Azure.ResourceManager.MachineLearning.Models.LoadBalancerType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.LoadBalancerType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.LoadBalancerType left, Azure.ResourceManager.MachineLearning.Models.LoadBalancerType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LogVerbosity : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.LogVerbosity>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LogVerbosity(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.LogVerbosity Critical { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.LogVerbosity Debug { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.LogVerbosity Error { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.LogVerbosity Info { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.LogVerbosity NotSet { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.LogVerbosity Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.LogVerbosity other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.LogVerbosity left, Azure.ResourceManager.MachineLearning.Models.LogVerbosity right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.LogVerbosity (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.LogVerbosity left, Azure.ResourceManager.MachineLearning.Models.LogVerbosity right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MachineLearningPrivateEndpointConnectionProvisioningState : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.MachineLearningPrivateEndpointConnectionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MachineLearningPrivateEndpointConnectionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningPrivateEndpointConnectionProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningPrivateEndpointConnectionProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningPrivateEndpointConnectionProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningPrivateEndpointConnectionProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.MachineLearningPrivateEndpointConnectionProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.MachineLearningPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.MachineLearning.Models.MachineLearningPrivateEndpointConnectionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.MachineLearningPrivateEndpointConnectionProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.MachineLearningPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.MachineLearning.Models.MachineLearningPrivateEndpointConnectionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MachineLearningPrivateEndpointServiceConnectionStatus : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.MachineLearningPrivateEndpointServiceConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MachineLearningPrivateEndpointServiceConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningPrivateEndpointServiceConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningPrivateEndpointServiceConnectionStatus Disconnected { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningPrivateEndpointServiceConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningPrivateEndpointServiceConnectionStatus Rejected { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningPrivateEndpointServiceConnectionStatus Timeout { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.MachineLearningPrivateEndpointServiceConnectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.MachineLearningPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.MachineLearning.Models.MachineLearningPrivateEndpointServiceConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.MachineLearningPrivateEndpointServiceConnectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.MachineLearningPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.MachineLearning.Models.MachineLearningPrivateEndpointServiceConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MachineLearningPrivateLinkResource : Azure.ResourceManager.Models.ResourceData
    {
        public MachineLearningPrivateLinkResource() { }
        public string GroupId { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public string Location { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredZoneNames { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class MachineLearningPrivateLinkServiceConnectionState
    {
        public MachineLearningPrivateLinkServiceConnectionState() { }
        public string ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningPrivateEndpointServiceConnectionStatus? Status { get { throw null; } set { } }
    }
    public partial class MachineLearningSku
    {
        public MachineLearningSku(string name) { }
        public int? Capacity { get { throw null; } set { } }
        public string Family { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Size { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningSkuTier? Tier { get { throw null; } set { } }
    }
    public enum MachineLearningSkuTier
    {
        Free = 0,
        Basic = 1,
        Standard = 2,
        Premium = 3,
    }
    public partial class MachineLearningUsage
    {
        internal MachineLearningUsage() { }
        public string AmlWorkspaceLocation { get { throw null; } }
        public long? CurrentValue { get { throw null; } }
        public string Id { get { throw null; } }
        public long? Limit { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.UsageName Name { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.UsageUnit? Unit { get { throw null; } }
        public string UsageType { get { throw null; } }
    }
    public partial class ManagedIdentity : Azure.ResourceManager.MachineLearning.Models.IdentityConfiguration
    {
        public ManagedIdentity() { }
        public System.Guid? ClientId { get { throw null; } set { } }
        public System.Guid? ObjectId { get { throw null; } set { } }
        public string ResourceId { get { throw null; } set { } }
    }
    public partial class ManagedOnlineDeployment : Azure.ResourceManager.MachineLearning.Models.OnlineDeploymentDetails
    {
        public ManagedOnlineDeployment() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedServiceIdentityType : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.ManagedServiceIdentityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedServiceIdentityType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.ManagedServiceIdentityType None { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ManagedServiceIdentityType SystemAssigned { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ManagedServiceIdentityType SystemAssignedUserAssigned { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ManagedServiceIdentityType UserAssigned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.ManagedServiceIdentityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.ManagedServiceIdentityType left, Azure.ResourceManager.MachineLearning.Models.ManagedServiceIdentityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.ManagedServiceIdentityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.ManagedServiceIdentityType left, Azure.ResourceManager.MachineLearning.Models.ManagedServiceIdentityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MedianStoppingPolicy : Azure.ResourceManager.MachineLearning.Models.EarlyTerminationPolicy
    {
        public MedianStoppingPolicy() { }
    }
    public partial class MLFlowModelJobInput : Azure.ResourceManager.MachineLearning.Models.JobInput
    {
        public MLFlowModelJobInput(System.Uri uri) { }
        public Azure.ResourceManager.MachineLearning.Models.InputDeliveryMode? Mode { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    public partial class MLFlowModelJobOutput : Azure.ResourceManager.MachineLearning.Models.JobOutput
    {
        public MLFlowModelJobOutput() { }
        public Azure.ResourceManager.MachineLearning.Models.OutputDeliveryMode? Mode { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    public partial class MLTableData : Azure.ResourceManager.MachineLearning.Models.DataVersionBaseDetails
    {
        public MLTableData(System.Uri dataUri) : base (default(System.Uri)) { }
        public System.Collections.Generic.IList<System.Uri> ReferencedUris { get { throw null; } set { } }
    }
    public partial class MLTableJobInput : Azure.ResourceManager.MachineLearning.Models.JobInput
    {
        public MLTableJobInput(System.Uri uri) { }
        public Azure.ResourceManager.MachineLearning.Models.InputDeliveryMode? Mode { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    public partial class MLTableJobOutput : Azure.ResourceManager.MachineLearning.Models.JobOutput
    {
        public MLTableJobOutput() { }
        public Azure.ResourceManager.MachineLearning.Models.OutputDeliveryMode? Mode { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    public partial class ModelContainerDetails : Azure.ResourceManager.MachineLearning.Models.AssetContainer
    {
        public ModelContainerDetails() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ModelSize : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.ModelSize>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ModelSize(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.ModelSize ExtraLarge { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ModelSize Large { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ModelSize Medium { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ModelSize None { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ModelSize Small { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.ModelSize other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.ModelSize left, Azure.ResourceManager.MachineLearning.Models.ModelSize right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.ModelSize (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.ModelSize left, Azure.ResourceManager.MachineLearning.Models.ModelSize right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ModelType : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.ModelType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ModelType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.ModelType CustomModel { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ModelType MLFlowModel { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ModelType TritonModel { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.ModelType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.ModelType left, Azure.ResourceManager.MachineLearning.Models.ModelType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.ModelType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.ModelType left, Azure.ResourceManager.MachineLearning.Models.ModelType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ModelVersionDetails : Azure.ResourceManager.MachineLearning.Models.AssetBase
    {
        public ModelVersionDetails() { }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.MachineLearning.Models.FlavorData> Flavors { get { throw null; } set { } }
        public string JobName { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ModelType? ModelType { get { throw null; } set { } }
        public System.Uri ModelUri { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MountAction : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.MountAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MountAction(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.MountAction Mount { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MountAction Unmount { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.MountAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.MountAction left, Azure.ResourceManager.MachineLearning.Models.MountAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.MountAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.MountAction left, Azure.ResourceManager.MachineLearning.Models.MountAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MountState : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.MountState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MountState(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.MountState Mounted { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MountState MountFailed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MountState MountRequested { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MountState Unmounted { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MountState UnmountFailed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MountState UnmountRequested { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.MountState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.MountState left, Azure.ResourceManager.MachineLearning.Models.MountState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.MountState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.MountState left, Azure.ResourceManager.MachineLearning.Models.MountState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Mpi : Azure.ResourceManager.MachineLearning.Models.DistributionConfiguration
    {
        public Mpi() { }
        public int? ProcessCountPerInstance { get { throw null; } set { } }
    }
    public partial class NCrossValidations
    {
        public NCrossValidations() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Network : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.Network>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Network(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.Network Bridge { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.Network Host { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.Network other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.Network left, Azure.ResourceManager.MachineLearning.Models.Network right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.Network (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.Network left, Azure.ResourceManager.MachineLearning.Models.Network right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NlpVerticalDataSettings : Azure.ResourceManager.MachineLearning.Models.DataSettings
    {
        public NlpVerticalDataSettings(string targetColumnName, Azure.ResourceManager.MachineLearning.Models.TrainingDataSettings trainingDataSettings) : base (default(string), default(Azure.ResourceManager.MachineLearning.Models.TrainingDataSettings)) { }
        public Azure.ResourceManager.MachineLearning.Models.NlpVerticalValidationDataSettings ValidationData { get { throw null; } set { } }
    }
    public partial class NlpVerticalLimitSettings
    {
        public NlpVerticalLimitSettings() { }
        public int? MaxConcurrentTrials { get { throw null; } set { } }
        public int? MaxTrials { get { throw null; } set { } }
        public System.TimeSpan? Timeout { get { throw null; } set { } }
    }
    public partial class NlpVerticalValidationDataSettings : Azure.ResourceManager.MachineLearning.Models.ValidationDataSettings
    {
        public NlpVerticalValidationDataSettings() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NodeState : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.NodeState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NodeState(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.NodeState Idle { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.NodeState Leaving { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.NodeState Preempted { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.NodeState Preparing { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.NodeState Running { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.NodeState Unusable { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.NodeState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.NodeState left, Azure.ResourceManager.MachineLearning.Models.NodeState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.NodeState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.NodeState left, Azure.ResourceManager.MachineLearning.Models.NodeState right) { throw null; }
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
    public partial class NoneDatastoreCredentials : Azure.ResourceManager.MachineLearning.Models.DatastoreCredentials
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
        public Azure.ResourceManager.MachineLearning.Models.NotebookPreparationError NotebookPreparationError { get { throw null; } }
        public string ResourceId { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ObjectDetectionPrimaryMetrics : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.ObjectDetectionPrimaryMetrics>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ObjectDetectionPrimaryMetrics(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.ObjectDetectionPrimaryMetrics MeanAveragePrecision { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.ObjectDetectionPrimaryMetrics other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.ObjectDetectionPrimaryMetrics left, Azure.ResourceManager.MachineLearning.Models.ObjectDetectionPrimaryMetrics right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.ObjectDetectionPrimaryMetrics (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.ObjectDetectionPrimaryMetrics left, Azure.ResourceManager.MachineLearning.Models.ObjectDetectionPrimaryMetrics right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Objective
    {
        public Objective(Azure.ResourceManager.MachineLearning.Models.Goal goal, string primaryMetric) { }
        public Azure.ResourceManager.MachineLearning.Models.Goal Goal { get { throw null; } set { } }
        public string PrimaryMetric { get { throw null; } set { } }
    }
    public partial class OnlineDeploymentDataPatch
    {
        public OnlineDeploymentDataPatch() { }
        public Azure.ResourceManager.MachineLearning.Models.PartialManagedServiceIdentity Identity { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public string Location { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.PartialOnlineDeployment Properties { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.PartialSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class OnlineDeploymentDetails : Azure.ResourceManager.MachineLearning.Models.EndpointDeploymentPropertiesBase
    {
        public OnlineDeploymentDetails() { }
        public bool? AppInsightsEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.EgressPublicNetworkAccessType? EgressPublicNetworkAccess { get { throw null; } set { } }
        public string InstanceType { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ProbeSettings LivenessProbe { get { throw null; } set { } }
        public string Model { get { throw null; } set { } }
        public string ModelMountPath { get { throw null; } set { } }
        public bool? PrivateNetworkConnection { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.DeploymentProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.ProbeSettings ReadinessProbe { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.OnlineRequestSettings RequestSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.OnlineScaleSettings ScaleSettings { get { throw null; } set { } }
    }
    public partial class OnlineEndpointDataPatch
    {
        public OnlineEndpointDataPatch() { }
        public Azure.ResourceManager.MachineLearning.Models.PartialManagedServiceIdentity Identity { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public string Location { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.PartialOnlineEndpoint Properties { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.PartialSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class OnlineEndpointDetails : Azure.ResourceManager.MachineLearning.Models.EndpointPropertiesBase
    {
        public OnlineEndpointDetails(Azure.ResourceManager.MachineLearning.Models.EndpointAuthMode authMode) : base (default(Azure.ResourceManager.MachineLearning.Models.EndpointAuthMode)) { }
        public string Compute { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, int> MirrorTraffic { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.EndpointProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.PublicNetworkAccessType? PublicNetworkAccess { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, int> Traffic { get { throw null; } set { } }
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
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperatingSystemType : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.OperatingSystemType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperatingSystemType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.OperatingSystemType Linux { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.OperatingSystemType Windows { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.OperatingSystemType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.OperatingSystemType left, Azure.ResourceManager.MachineLearning.Models.OperatingSystemType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.OperatingSystemType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.OperatingSystemType left, Azure.ResourceManager.MachineLearning.Models.OperatingSystemType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperationName : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.OperationName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperationName(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.OperationName Create { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.OperationName Delete { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.OperationName Reimage { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.OperationName Restart { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.OperationName Start { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.OperationName Stop { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.OperationName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.OperationName left, Azure.ResourceManager.MachineLearning.Models.OperationName right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.OperationName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.OperationName left, Azure.ResourceManager.MachineLearning.Models.OperationName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperationStatus : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.OperationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperationStatus(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.OperationStatus CreateFailed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.OperationStatus DeleteFailed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.OperationStatus InProgress { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.OperationStatus ReimageFailed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.OperationStatus RestartFailed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.OperationStatus StartFailed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.OperationStatus StopFailed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.OperationStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.OperationStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.OperationStatus left, Azure.ResourceManager.MachineLearning.Models.OperationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.OperationStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.OperationStatus left, Azure.ResourceManager.MachineLearning.Models.OperationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperationTrigger : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.OperationTrigger>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperationTrigger(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.OperationTrigger IdleShutdown { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.OperationTrigger Schedule { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.OperationTrigger User { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.OperationTrigger other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.OperationTrigger left, Azure.ResourceManager.MachineLearning.Models.OperationTrigger right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.OperationTrigger (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.OperationTrigger left, Azure.ResourceManager.MachineLearning.Models.OperationTrigger right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OrderString : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.OrderString>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OrderString(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.OrderString CreatedAtAsc { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.OrderString CreatedAtDesc { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.OrderString UpdatedAtAsc { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.OrderString UpdatedAtDesc { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.OrderString other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.OrderString left, Azure.ResourceManager.MachineLearning.Models.OrderString right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.OrderString (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.OrderString left, Azure.ResourceManager.MachineLearning.Models.OrderString right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OsType : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.OsType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OsType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.OsType Linux { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.OsType Windows { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.OsType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.OsType left, Azure.ResourceManager.MachineLearning.Models.OsType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.OsType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.OsType left, Azure.ResourceManager.MachineLearning.Models.OsType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OutputDeliveryMode : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.OutputDeliveryMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OutputDeliveryMode(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.OutputDeliveryMode ReadWriteMount { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.OutputDeliveryMode Upload { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.OutputDeliveryMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.OutputDeliveryMode left, Azure.ResourceManager.MachineLearning.Models.OutputDeliveryMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.OutputDeliveryMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.OutputDeliveryMode left, Azure.ResourceManager.MachineLearning.Models.OutputDeliveryMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OutputPathAssetReference : Azure.ResourceManager.MachineLearning.Models.AssetReferenceBase
    {
        public OutputPathAssetReference() { }
        public string JobId { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
    }
    public partial class PartialAssetReferenceBase
    {
        public PartialAssetReferenceBase() { }
    }
    public partial class PartialBatchDeployment
    {
        public PartialBatchDeployment() { }
        public Azure.ResourceManager.MachineLearning.Models.PartialCodeConfiguration CodeConfiguration { get { throw null; } set { } }
        public string Compute { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string EnvironmentId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> EnvironmentVariables { get { throw null; } set { } }
        public int? ErrorThreshold { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.BatchLoggingLevel? LoggingLevel { get { throw null; } set { } }
        public int? MaxConcurrencyPerInstance { get { throw null; } set { } }
        public long? MiniBatchSize { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.PartialAssetReferenceBase Model { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.BatchOutputAction? OutputAction { get { throw null; } set { } }
        public string OutputFileName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Properties { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.PartialBatchRetrySettings RetrySettings { get { throw null; } set { } }
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
        public Azure.ResourceManager.MachineLearning.Models.ManagedServiceIdentityType? ManagedServiceIdentityType { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> UserAssignedIdentities { get { throw null; } }
    }
    public partial class PartialOnlineDeployment
    {
        public PartialOnlineDeployment() { }
    }
    public partial class PartialOnlineEndpoint
    {
        public PartialOnlineEndpoint() { }
        public System.Collections.Generic.IDictionary<string, int> MirrorTraffic { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.PublicNetworkAccessType? PublicNetworkAccess { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, int> Traffic { get { throw null; } set { } }
    }
    public partial class PartialSku
    {
        public PartialSku() { }
        public int? Capacity { get { throw null; } set { } }
        public string Family { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Size { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningSkuTier? Tier { get { throw null; } set { } }
    }
    public partial class Password
    {
        internal Password() { }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class PipelineJob : Azure.ResourceManager.MachineLearning.Models.JobBaseDetails
    {
        public PipelineJob() { }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.MachineLearning.Models.JobInput> Inputs { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Jobs { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.MachineLearning.Models.JobOutput> Outputs { get { throw null; } set { } }
        public System.BinaryData Settings { get { throw null; } set { } }
    }
    public partial class PrivateEndpoint
    {
        public PrivateEndpoint() { }
        public string Id { get { throw null; } }
        public string SubnetArmId { get { throw null; } }
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
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ProvisioningState Unknown { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.ProvisioningState left, Azure.ResourceManager.MachineLearning.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.ProvisioningState left, Azure.ResourceManager.MachineLearning.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningStatus : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.ProvisioningStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningStatus(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.ProvisioningStatus Completed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ProvisioningStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ProvisioningStatus Provisioning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.ProvisioningStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.ProvisioningStatus left, Azure.ResourceManager.MachineLearning.Models.ProvisioningStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.ProvisioningStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.ProvisioningStatus left, Azure.ResourceManager.MachineLearning.Models.ProvisioningStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PublicNetworkAccess : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.PublicNetworkAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PublicNetworkAccess(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.PublicNetworkAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.PublicNetworkAccess Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.PublicNetworkAccess other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.PublicNetworkAccess left, Azure.ResourceManager.MachineLearning.Models.PublicNetworkAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.PublicNetworkAccess (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.PublicNetworkAccess left, Azure.ResourceManager.MachineLearning.Models.PublicNetworkAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PublicNetworkAccessType : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.PublicNetworkAccessType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PublicNetworkAccessType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.PublicNetworkAccessType Disabled { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.PublicNetworkAccessType Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.PublicNetworkAccessType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.PublicNetworkAccessType left, Azure.ResourceManager.MachineLearning.Models.PublicNetworkAccessType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.PublicNetworkAccessType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.PublicNetworkAccessType left, Azure.ResourceManager.MachineLearning.Models.PublicNetworkAccessType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PyTorch : Azure.ResourceManager.MachineLearning.Models.DistributionConfiguration
    {
        public PyTorch() { }
        public int? ProcessCountPerInstance { get { throw null; } set { } }
    }
    public partial class QuotaBaseProperties
    {
        public QuotaBaseProperties() { }
        public string Id { get { throw null; } set { } }
        public long? Limit { get { throw null; } set { } }
        public string QuotaBasePropertiesType { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.QuotaUnit? Unit { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct QuotaUnit : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.QuotaUnit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public QuotaUnit(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.QuotaUnit Count { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.QuotaUnit other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.QuotaUnit left, Azure.ResourceManager.MachineLearning.Models.QuotaUnit right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.QuotaUnit (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.QuotaUnit left, Azure.ResourceManager.MachineLearning.Models.QuotaUnit right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class QuotaUpdateContent
    {
        public QuotaUpdateContent() { }
        public string Location { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.MachineLearning.Models.QuotaBaseProperties> Value { get { throw null; } }
    }
    public partial class RandomSamplingAlgorithm : Azure.ResourceManager.MachineLearning.Models.SamplingAlgorithm
    {
        public RandomSamplingAlgorithm() { }
        public Azure.ResourceManager.MachineLearning.Models.RandomSamplingAlgorithmRule? Rule { get { throw null; } set { } }
        public int? Seed { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RandomSamplingAlgorithmRule : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.RandomSamplingAlgorithmRule>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RandomSamplingAlgorithmRule(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.RandomSamplingAlgorithmRule Random { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.RandomSamplingAlgorithmRule Sobol { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.RandomSamplingAlgorithmRule other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.RandomSamplingAlgorithmRule left, Azure.ResourceManager.MachineLearning.Models.RandomSamplingAlgorithmRule right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.RandomSamplingAlgorithmRule (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.RandomSamplingAlgorithmRule left, Azure.ResourceManager.MachineLearning.Models.RandomSamplingAlgorithmRule right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RecurrenceFrequency : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.RecurrenceFrequency>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecurrenceFrequency(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.RecurrenceFrequency Day { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.RecurrenceFrequency Hour { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.RecurrenceFrequency Minute { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.RecurrenceFrequency Month { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.RecurrenceFrequency Week { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.RecurrenceFrequency other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.RecurrenceFrequency left, Azure.ResourceManager.MachineLearning.Models.RecurrenceFrequency right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.RecurrenceFrequency (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.RecurrenceFrequency left, Azure.ResourceManager.MachineLearning.Models.RecurrenceFrequency right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RecurrencePattern
    {
        public RecurrencePattern(System.Collections.Generic.IEnumerable<int> hours, System.Collections.Generic.IEnumerable<int> minutes) { }
        public System.Collections.Generic.IList<int> Hours { get { throw null; } }
        public System.Collections.Generic.IList<int> Minutes { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.MachineLearning.Models.Weekday> Weekdays { get { throw null; } set { } }
    }
    public partial class RecurrenceSchedule : Azure.ResourceManager.MachineLearning.Models.ScheduleBase
    {
        public RecurrenceSchedule(Azure.ResourceManager.MachineLearning.Models.RecurrenceFrequency frequency, int interval) { }
        public Azure.ResourceManager.MachineLearning.Models.RecurrenceFrequency Frequency { get { throw null; } set { } }
        public int Interval { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.RecurrencePattern Pattern { get { throw null; } set { } }
    }
    public partial class RegenerateEndpointKeysContent
    {
        public RegenerateEndpointKeysContent(Azure.ResourceManager.MachineLearning.Models.KeyType keyType) { }
        public Azure.ResourceManager.MachineLearning.Models.KeyType KeyType { get { throw null; } }
        public string KeyValue { get { throw null; } set { } }
    }
    public partial class RegistryListCredentialsResult
    {
        internal RegistryListCredentialsResult() { }
        public string Location { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearning.Models.Password> Passwords { get { throw null; } }
        public string Username { get { throw null; } }
    }
    public partial class Regression : Azure.ResourceManager.MachineLearning.Models.AutoMLVertical
    {
        public Regression() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.MachineLearning.Models.RegressionModels> AllowedModels { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.MachineLearning.Models.RegressionModels> BlockedModels { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.TableVerticalDataSettings DataSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.TableVerticalFeaturizationSettings FeaturizationSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.TableVerticalLimitSettings LimitSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.RegressionPrimaryMetrics? PrimaryMetric { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.TrainingSettings TrainingSettings { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RegressionModels : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.RegressionModels>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RegressionModels(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.RegressionModels DecisionTree { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.RegressionModels ElasticNet { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.RegressionModels ExtremeRandomTrees { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.RegressionModels GradientBoosting { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.RegressionModels KNN { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.RegressionModels LassoLars { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.RegressionModels LightGBM { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.RegressionModels RandomForest { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.RegressionModels SGD { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.RegressionModels XGBoostRegressor { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.RegressionModels other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.RegressionModels left, Azure.ResourceManager.MachineLearning.Models.RegressionModels right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.RegressionModels (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.RegressionModels left, Azure.ResourceManager.MachineLearning.Models.RegressionModels right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RegressionPrimaryMetrics : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.RegressionPrimaryMetrics>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RegressionPrimaryMetrics(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.RegressionPrimaryMetrics NormalizedMeanAbsoluteError { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.RegressionPrimaryMetrics NormalizedRootMeanSquaredError { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.RegressionPrimaryMetrics R2Score { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.RegressionPrimaryMetrics SpearmanCorrelation { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.RegressionPrimaryMetrics other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.RegressionPrimaryMetrics left, Azure.ResourceManager.MachineLearning.Models.RegressionPrimaryMetrics right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.RegressionPrimaryMetrics (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.RegressionPrimaryMetrics left, Azure.ResourceManager.MachineLearning.Models.RegressionPrimaryMetrics right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RemoteLoginPortPublicAccess : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.RemoteLoginPortPublicAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RemoteLoginPortPublicAccess(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.RemoteLoginPortPublicAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.RemoteLoginPortPublicAccess Enabled { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.RemoteLoginPortPublicAccess NotSpecified { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.RemoteLoginPortPublicAccess other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.RemoteLoginPortPublicAccess left, Azure.ResourceManager.MachineLearning.Models.RemoteLoginPortPublicAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.RemoteLoginPortPublicAccess (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.RemoteLoginPortPublicAccess left, Azure.ResourceManager.MachineLearning.Models.RemoteLoginPortPublicAccess right) { throw null; }
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
        public Azure.ResourceManager.MachineLearning.Models.ResourceName Name { get { throw null; } }
        public string ResourceQuotaType { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.QuotaUnit? Unit { get { throw null; } }
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
    public readonly partial struct SamplingAlgorithmType : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.SamplingAlgorithmType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SamplingAlgorithmType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.SamplingAlgorithmType Bayesian { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.SamplingAlgorithmType Grid { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.SamplingAlgorithmType Random { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.SamplingAlgorithmType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.SamplingAlgorithmType left, Azure.ResourceManager.MachineLearning.Models.SamplingAlgorithmType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.SamplingAlgorithmType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.SamplingAlgorithmType left, Azure.ResourceManager.MachineLearning.Models.SamplingAlgorithmType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SasDatastoreCredentials : Azure.ResourceManager.MachineLearning.Models.DatastoreCredentials
    {
        public SasDatastoreCredentials(Azure.ResourceManager.MachineLearning.Models.SasDatastoreSecrets secrets) { }
        public Azure.ResourceManager.MachineLearning.Models.SasDatastoreSecrets Secrets { get { throw null; } set { } }
    }
    public partial class SasDatastoreSecrets : Azure.ResourceManager.MachineLearning.Models.DatastoreSecrets
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
        public Azure.ResourceManager.MachineLearning.Models.ScheduleStatus? ScheduleStatus { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        public string TimeZone { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScheduleStatus : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.ScheduleStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScheduleStatus(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.ScheduleStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ScheduleStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.ScheduleStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.ScheduleStatus left, Azure.ResourceManager.MachineLearning.Models.ScheduleStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.ScheduleStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.ScheduleStatus left, Azure.ResourceManager.MachineLearning.Models.ScheduleStatus right) { throw null; }
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
        public Azure.ResourceManager.MachineLearning.Models.ScriptReference CreationScript { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ScriptReference StartupScript { get { throw null; } set { } }
    }
    public partial class Seasonality
    {
        public Seasonality() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServiceDataAccessAuthIdentity : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.ServiceDataAccessAuthIdentity>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServiceDataAccessAuthIdentity(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.ServiceDataAccessAuthIdentity None { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ServiceDataAccessAuthIdentity WorkspaceSystemAssignedIdentity { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ServiceDataAccessAuthIdentity WorkspaceUserAssignedIdentity { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.ServiceDataAccessAuthIdentity other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.ServiceDataAccessAuthIdentity left, Azure.ResourceManager.MachineLearning.Models.ServiceDataAccessAuthIdentity right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.ServiceDataAccessAuthIdentity (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.ServiceDataAccessAuthIdentity left, Azure.ResourceManager.MachineLearning.Models.ServiceDataAccessAuthIdentity right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ServicePrincipalDatastoreCredentials : Azure.ResourceManager.MachineLearning.Models.DatastoreCredentials
    {
        public ServicePrincipalDatastoreCredentials(System.Guid clientId, Azure.ResourceManager.MachineLearning.Models.ServicePrincipalDatastoreSecrets secrets, System.Guid tenantId) { }
        public System.Uri AuthorityUri { get { throw null; } set { } }
        public System.Guid ClientId { get { throw null; } set { } }
        public System.Uri ResourceUri { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ServicePrincipalDatastoreSecrets Secrets { get { throw null; } set { } }
        public System.Guid TenantId { get { throw null; } set { } }
    }
    public partial class ServicePrincipalDatastoreSecrets : Azure.ResourceManager.MachineLearning.Models.DatastoreSecrets
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
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningPrivateEndpointServiceConnectionStatus? Status { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ShortSeriesHandlingConfiguration : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.ShortSeriesHandlingConfiguration>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ShortSeriesHandlingConfiguration(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.ShortSeriesHandlingConfiguration Auto { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ShortSeriesHandlingConfiguration Drop { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ShortSeriesHandlingConfiguration None { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ShortSeriesHandlingConfiguration Pad { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.ShortSeriesHandlingConfiguration other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.ShortSeriesHandlingConfiguration left, Azure.ResourceManager.MachineLearning.Models.ShortSeriesHandlingConfiguration right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.ShortSeriesHandlingConfiguration (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.ShortSeriesHandlingConfiguration left, Azure.ResourceManager.MachineLearning.Models.ShortSeriesHandlingConfiguration right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SkuCapacity
    {
        internal SkuCapacity() { }
        public int? Default { get { throw null; } }
        public int? Maximum { get { throw null; } }
        public int? Minimum { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.SkuScaleType? ScaleType { get { throw null; } }
    }
    public partial class SkuResource
    {
        internal SkuResource() { }
        public Azure.ResourceManager.MachineLearning.Models.SkuCapacity Capacity { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.SkuSetting Sku { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SkuScaleType : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.SkuScaleType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SkuScaleType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.SkuScaleType Automatic { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.SkuScaleType Manual { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.SkuScaleType None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.SkuScaleType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.SkuScaleType left, Azure.ResourceManager.MachineLearning.Models.SkuScaleType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.SkuScaleType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.SkuScaleType left, Azure.ResourceManager.MachineLearning.Models.SkuScaleType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SkuSetting
    {
        internal SkuSetting() { }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningSkuTier? Tier { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SourceType : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.SourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SourceType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.SourceType Dataset { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.SourceType Datastore { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.SourceType URI { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.SourceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.SourceType left, Azure.ResourceManager.MachineLearning.Models.SourceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.SourceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.SourceType left, Azure.ResourceManager.MachineLearning.Models.SourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SshPublicAccess : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.SshPublicAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SshPublicAccess(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.SshPublicAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.SshPublicAccess Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.SshPublicAccess other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.SshPublicAccess left, Azure.ResourceManager.MachineLearning.Models.SshPublicAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.SshPublicAccess (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.SshPublicAccess left, Azure.ResourceManager.MachineLearning.Models.SshPublicAccess right) { throw null; }
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
        public Azure.ResourceManager.MachineLearning.Models.SslConfigurationStatus? Status { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SslConfigurationStatus : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.SslConfigurationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SslConfigurationStatus(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.SslConfigurationStatus Auto { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.SslConfigurationStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.SslConfigurationStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.SslConfigurationStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.SslConfigurationStatus left, Azure.ResourceManager.MachineLearning.Models.SslConfigurationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.SslConfigurationStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.SslConfigurationStatus left, Azure.ResourceManager.MachineLearning.Models.SslConfigurationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StackEnsembleSettings
    {
        public StackEnsembleSettings() { }
        public System.BinaryData StackMetaLearnerKWargs { get { throw null; } set { } }
        public double? StackMetaLearnerTrainPercentage { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.StackMetaLearnerType? StackMetaLearnerType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StackMetaLearnerType : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.StackMetaLearnerType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StackMetaLearnerType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.StackMetaLearnerType ElasticNet { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.StackMetaLearnerType ElasticNetCV { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.StackMetaLearnerType LightGBMClassifier { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.StackMetaLearnerType LightGBMRegressor { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.StackMetaLearnerType LinearRegression { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.StackMetaLearnerType LogisticRegression { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.StackMetaLearnerType LogisticRegressionCV { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.StackMetaLearnerType None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.StackMetaLearnerType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.StackMetaLearnerType left, Azure.ResourceManager.MachineLearning.Models.StackMetaLearnerType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.StackMetaLearnerType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.StackMetaLearnerType left, Azure.ResourceManager.MachineLearning.Models.StackMetaLearnerType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Status : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.Status>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Status(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.Status Failure { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.Status InvalidQuotaBelowClusterMinimum { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.Status InvalidQuotaExceedsSubscriptionLimit { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.Status InvalidVMFamilyName { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.Status OperationNotEnabledForRegion { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.Status OperationNotSupportedForSku { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.Status Success { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.Status Undefined { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.Status other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.Status left, Azure.ResourceManager.MachineLearning.Models.Status right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.Status (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.Status left, Azure.ResourceManager.MachineLearning.Models.Status right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StochasticOptimizer : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.StochasticOptimizer>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StochasticOptimizer(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.StochasticOptimizer Adam { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.StochasticOptimizer Adamw { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.StochasticOptimizer None { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.StochasticOptimizer Sgd { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.StochasticOptimizer other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.StochasticOptimizer left, Azure.ResourceManager.MachineLearning.Models.StochasticOptimizer right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.StochasticOptimizer (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.StochasticOptimizer left, Azure.ResourceManager.MachineLearning.Models.StochasticOptimizer right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageAccountType : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.StorageAccountType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageAccountType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.StorageAccountType PremiumLRS { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.StorageAccountType StandardLRS { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.StorageAccountType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.StorageAccountType left, Azure.ResourceManager.MachineLearning.Models.StorageAccountType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.StorageAccountType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.StorageAccountType left, Azure.ResourceManager.MachineLearning.Models.StorageAccountType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SweepJob : Azure.ResourceManager.MachineLearning.Models.JobBaseDetails
    {
        public SweepJob(Azure.ResourceManager.MachineLearning.Models.Objective objective, Azure.ResourceManager.MachineLearning.Models.SamplingAlgorithm samplingAlgorithm, System.BinaryData searchSpace, Azure.ResourceManager.MachineLearning.Models.TrialComponent trial) { }
        public Azure.ResourceManager.MachineLearning.Models.EarlyTerminationPolicy EarlyTermination { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.MachineLearning.Models.JobInput> Inputs { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.SweepJobLimits Limits { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.Objective Objective { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.MachineLearning.Models.JobOutput> Outputs { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.SamplingAlgorithm SamplingAlgorithm { get { throw null; } set { } }
        public System.BinaryData SearchSpace { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.TrialComponent Trial { get { throw null; } set { } }
    }
    public partial class SweepJobLimits : Azure.ResourceManager.MachineLearning.Models.JobLimits
    {
        public SweepJobLimits() { }
        public int? MaxConcurrentTrials { get { throw null; } set { } }
        public int? MaxTotalTrials { get { throw null; } set { } }
        public System.TimeSpan? TrialTimeout { get { throw null; } set { } }
    }
    public partial class SynapseSpark : Azure.ResourceManager.MachineLearning.Models.Compute
    {
        public SynapseSpark() { }
        public Azure.ResourceManager.MachineLearning.Models.SynapseSparkProperties Properties { get { throw null; } set { } }
    }
    public partial class SynapseSparkProperties
    {
        public SynapseSparkProperties() { }
        public Azure.ResourceManager.MachineLearning.Models.AutoPauseProperties AutoPauseProperties { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.AutoScaleProperties AutoScaleProperties { get { throw null; } set { } }
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
    public partial class TableVerticalDataSettings : Azure.ResourceManager.MachineLearning.Models.DataSettings
    {
        public TableVerticalDataSettings(string targetColumnName, Azure.ResourceManager.MachineLearning.Models.TrainingDataSettings trainingDataSettings) : base (default(string), default(Azure.ResourceManager.MachineLearning.Models.TrainingDataSettings)) { }
        public Azure.ResourceManager.MachineLearning.Models.TableVerticalValidationDataSettings ValidationData { get { throw null; } set { } }
        public string WeightColumnName { get { throw null; } set { } }
    }
    public partial class TableVerticalFeaturizationSettings : Azure.ResourceManager.MachineLearning.Models.FeaturizationSettings
    {
        public TableVerticalFeaturizationSettings() { }
        public System.Collections.Generic.IList<string> BlockedTransformers { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> ColumnNameAndTypes { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> DropColumns { get { throw null; } set { } }
        public bool? EnableDnnFeaturization { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.FeaturizationMode? Mode { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.Collections.Generic.IList<Azure.ResourceManager.MachineLearning.Models.ColumnTransformer>> TransformerParams { get { throw null; } set { } }
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
    public partial class TableVerticalValidationDataSettings : Azure.ResourceManager.MachineLearning.Models.ValidationDataSettings
    {
        public TableVerticalValidationDataSettings() { }
        public System.Collections.Generic.IList<string> CvSplitColumnNames { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.NCrossValidations NCrossValidations { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TargetAggregationFunction : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.TargetAggregationFunction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TargetAggregationFunction(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.TargetAggregationFunction Max { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.TargetAggregationFunction Mean { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.TargetAggregationFunction Min { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.TargetAggregationFunction None { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.TargetAggregationFunction Sum { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.TargetAggregationFunction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.TargetAggregationFunction left, Azure.ResourceManager.MachineLearning.Models.TargetAggregationFunction right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.TargetAggregationFunction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.TargetAggregationFunction left, Azure.ResourceManager.MachineLearning.Models.TargetAggregationFunction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TargetLags
    {
        public TargetLags() { }
    }
    public partial class TargetRollingWindowSize
    {
        public TargetRollingWindowSize() { }
    }
    public partial class TargetUtilizationScaleSettings : Azure.ResourceManager.MachineLearning.Models.OnlineScaleSettings
    {
        public TargetUtilizationScaleSettings() { }
        public int? MaxInstances { get { throw null; } set { } }
        public int? MinInstances { get { throw null; } set { } }
        public System.TimeSpan? PollingInterval { get { throw null; } set { } }
        public int? TargetUtilizationPercentage { get { throw null; } set { } }
    }
    public partial class TensorFlow : Azure.ResourceManager.MachineLearning.Models.DistributionConfiguration
    {
        public TensorFlow() { }
        public int? ParameterServerCount { get { throw null; } set { } }
        public int? WorkerCount { get { throw null; } set { } }
    }
    public partial class TestDataSettings
    {
        public TestDataSettings() { }
        public Azure.ResourceManager.MachineLearning.Models.MLTableJobInput Data { get { throw null; } set { } }
        public double? TestDataSize { get { throw null; } set { } }
    }
    public partial class TextClassification : Azure.ResourceManager.MachineLearning.Models.AutoMLVertical
    {
        public TextClassification() { }
        public Azure.ResourceManager.MachineLearning.Models.NlpVerticalDataSettings DataSettings { get { throw null; } set { } }
        public string FeaturizationDatasetLanguage { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.NlpVerticalLimitSettings LimitSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ClassificationPrimaryMetrics? PrimaryMetric { get { throw null; } set { } }
    }
    public partial class TextClassificationMultilabel : Azure.ResourceManager.MachineLearning.Models.AutoMLVertical
    {
        public TextClassificationMultilabel() { }
        public Azure.ResourceManager.MachineLearning.Models.NlpVerticalDataSettings DataSettings { get { throw null; } set { } }
        public string FeaturizationDatasetLanguage { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.NlpVerticalLimitSettings LimitSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ClassificationMultilabelPrimaryMetrics? PrimaryMetric { get { throw null; } }
    }
    public partial class TextNer : Azure.ResourceManager.MachineLearning.Models.AutoMLVertical
    {
        public TextNer() { }
        public Azure.ResourceManager.MachineLearning.Models.NlpVerticalDataSettings DataSettings { get { throw null; } set { } }
        public string FeaturizationDatasetLanguage { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.NlpVerticalLimitSettings LimitSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ClassificationPrimaryMetrics? PrimaryMetric { get { throw null; } }
    }
    public partial class TrainingDataSettings
    {
        public TrainingDataSettings(Azure.ResourceManager.MachineLearning.Models.MLTableJobInput data) { }
        public Azure.ResourceManager.MachineLearning.Models.MLTableJobInput Data { get { throw null; } set { } }
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
        public Azure.ResourceManager.MachineLearning.Models.StackEnsembleSettings StackEnsembleSettings { get { throw null; } set { } }
    }
    public partial class TrialComponent
    {
        public TrialComponent(string command, string environmentId) { }
        public string CodeId { get { throw null; } set { } }
        public string Command { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.DistributionConfiguration Distribution { get { throw null; } set { } }
        public string EnvironmentId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> EnvironmentVariables { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ResourceConfiguration Resources { get { throw null; } set { } }
    }
    public partial class TritonModelJobInput : Azure.ResourceManager.MachineLearning.Models.JobInput
    {
        public TritonModelJobInput(System.Uri uri) { }
        public Azure.ResourceManager.MachineLearning.Models.InputDeliveryMode? Mode { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    public partial class TritonModelJobOutput : Azure.ResourceManager.MachineLearning.Models.JobOutput
    {
        public TritonModelJobOutput() { }
        public Azure.ResourceManager.MachineLearning.Models.OutputDeliveryMode? Mode { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    public partial class TruncationSelectionPolicy : Azure.ResourceManager.MachineLearning.Models.EarlyTerminationPolicy
    {
        public TruncationSelectionPolicy() { }
        public int? TruncationPercentage { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UnderlyingResourceAction : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.UnderlyingResourceAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UnderlyingResourceAction(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.UnderlyingResourceAction Delete { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.UnderlyingResourceAction Detach { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.UnderlyingResourceAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.UnderlyingResourceAction left, Azure.ResourceManager.MachineLearning.Models.UnderlyingResourceAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.UnderlyingResourceAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.UnderlyingResourceAction left, Azure.ResourceManager.MachineLearning.Models.UnderlyingResourceAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UnitOfMeasure : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.UnitOfMeasure>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UnitOfMeasure(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.UnitOfMeasure OneHour { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.UnitOfMeasure other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.UnitOfMeasure left, Azure.ResourceManager.MachineLearning.Models.UnitOfMeasure right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.UnitOfMeasure (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.UnitOfMeasure left, Azure.ResourceManager.MachineLearning.Models.UnitOfMeasure right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UpdateWorkspaceQuotas
    {
        internal UpdateWorkspaceQuotas() { }
        public string Id { get { throw null; } }
        public long? Limit { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.Status? Status { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.QuotaUnit? Unit { get { throw null; } }
        public string UpdateWorkspaceQuotasType { get { throw null; } }
    }
    public partial class UriFileDataVersion : Azure.ResourceManager.MachineLearning.Models.DataVersionBaseDetails
    {
        public UriFileDataVersion(System.Uri dataUri) : base (default(System.Uri)) { }
    }
    public partial class UriFileJobInput : Azure.ResourceManager.MachineLearning.Models.JobInput
    {
        public UriFileJobInput(System.Uri uri) { }
        public Azure.ResourceManager.MachineLearning.Models.InputDeliveryMode? Mode { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    public partial class UriFileJobOutput : Azure.ResourceManager.MachineLearning.Models.JobOutput
    {
        public UriFileJobOutput() { }
        public Azure.ResourceManager.MachineLearning.Models.OutputDeliveryMode? Mode { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    public partial class UriFolderDataVersion : Azure.ResourceManager.MachineLearning.Models.DataVersionBaseDetails
    {
        public UriFolderDataVersion(System.Uri dataUri) : base (default(System.Uri)) { }
    }
    public partial class UriFolderJobInput : Azure.ResourceManager.MachineLearning.Models.JobInput
    {
        public UriFolderJobInput(System.Uri uri) { }
        public Azure.ResourceManager.MachineLearning.Models.InputDeliveryMode? Mode { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    public partial class UriFolderJobOutput : Azure.ResourceManager.MachineLearning.Models.JobOutput
    {
        public UriFolderJobOutput() { }
        public Azure.ResourceManager.MachineLearning.Models.OutputDeliveryMode? Mode { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    public partial class UsageName
    {
        internal UsageName() { }
        public string LocalizedValue { get { throw null; } }
        public string Value { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UsageUnit : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.UsageUnit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UsageUnit(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.UsageUnit Count { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.UsageUnit other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.UsageUnit left, Azure.ResourceManager.MachineLearning.Models.UsageUnit right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.UsageUnit (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.UsageUnit left, Azure.ResourceManager.MachineLearning.Models.UsageUnit right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UserAccountCredentials
    {
        public UserAccountCredentials(string adminUserName) { }
        public string AdminUserName { get { throw null; } set { } }
        public string AdminUserPassword { get { throw null; } set { } }
        public string AdminUserSshPublicKey { get { throw null; } set { } }
    }
    public partial class UserIdentity : Azure.ResourceManager.MachineLearning.Models.IdentityConfiguration
    {
        public UserIdentity() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UseStl : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.UseStl>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UseStl(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.UseStl None { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.UseStl Season { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.UseStl SeasonTrend { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.UseStl other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.UseStl left, Azure.ResourceManager.MachineLearning.Models.UseStl right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.UseStl (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.UseStl left, Azure.ResourceManager.MachineLearning.Models.UseStl right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ValidationDataSettings
    {
        public ValidationDataSettings() { }
        public Azure.ResourceManager.MachineLearning.Models.MLTableJobInput Data { get { throw null; } set { } }
        public double? ValidationDataSize { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ValidationMetricType : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.ValidationMetricType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ValidationMetricType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.ValidationMetricType Coco { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ValidationMetricType CocoVoc { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ValidationMetricType None { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ValidationMetricType Voc { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.ValidationMetricType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.ValidationMetricType left, Azure.ResourceManager.MachineLearning.Models.ValidationMetricType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.ValidationMetricType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.ValidationMetricType left, Azure.ResourceManager.MachineLearning.Models.ValidationMetricType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ValueFormat : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.ValueFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ValueFormat(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.ValueFormat Json { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.ValueFormat other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.ValueFormat left, Azure.ResourceManager.MachineLearning.Models.ValueFormat right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.ValueFormat (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.ValueFormat left, Azure.ResourceManager.MachineLearning.Models.ValueFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VirtualMachine : Azure.ResourceManager.MachineLearning.Models.Compute
    {
        public VirtualMachine() { }
        public Azure.ResourceManager.MachineLearning.Models.VirtualMachineSchemaProperties Properties { get { throw null; } set { } }
    }
    public partial class VirtualMachineSchemaProperties
    {
        public VirtualMachineSchemaProperties() { }
        public string Address { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.VirtualMachineSshCredentials AdministratorAccount { get { throw null; } set { } }
        public bool? IsNotebookInstanceCompute { get { throw null; } set { } }
        public int? NotebookServerPort { get { throw null; } set { } }
        public int? SshPort { get { throw null; } set { } }
        public string VirtualMachineSize { get { throw null; } set { } }
    }
    public partial class VirtualMachineSecrets : Azure.ResourceManager.MachineLearning.Models.ComputeSecrets
    {
        internal VirtualMachineSecrets() { }
        public Azure.ResourceManager.MachineLearning.Models.VirtualMachineSshCredentials AdministratorAccount { get { throw null; } }
    }
    public partial class VirtualMachineSize
    {
        internal VirtualMachineSize() { }
        public Azure.ResourceManager.MachineLearning.Models.EstimatedVMPrices EstimatedVMPrices { get { throw null; } }
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
    public readonly partial struct VMPriceOSType : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.VMPriceOSType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VMPriceOSType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.VMPriceOSType Linux { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.VMPriceOSType Windows { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.VMPriceOSType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.VMPriceOSType left, Azure.ResourceManager.MachineLearning.Models.VMPriceOSType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.VMPriceOSType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.VMPriceOSType left, Azure.ResourceManager.MachineLearning.Models.VMPriceOSType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VmPriority : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.VmPriority>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VmPriority(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.VmPriority Dedicated { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.VmPriority LowPriority { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.VmPriority other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.VmPriority left, Azure.ResourceManager.MachineLearning.Models.VmPriority right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.VmPriority (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.VmPriority left, Azure.ResourceManager.MachineLearning.Models.VmPriority right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VMTier : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.VMTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VMTier(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.VMTier LowPriority { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.VMTier Spot { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.VMTier Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.VMTier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.VMTier left, Azure.ResourceManager.MachineLearning.Models.VMTier right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.VMTier (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.VMTier left, Azure.ResourceManager.MachineLearning.Models.VMTier right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Weekday : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.Weekday>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Weekday(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.Weekday Friday { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.Weekday Monday { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.Weekday Saturday { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.Weekday Sunday { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.Weekday Thursday { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.Weekday Tuesday { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.Weekday Wednesday { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.Weekday other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.Weekday left, Azure.ResourceManager.MachineLearning.Models.Weekday right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.Weekday (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.Weekday left, Azure.ResourceManager.MachineLearning.Models.Weekday right) { throw null; }
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
        public Azure.ResourceManager.MachineLearning.Models.PublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
}
