namespace Azure.ResourceManager.MachineLearning
{
    public partial class BatchDeploymentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.BatchDeploymentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.BatchDeploymentResource>, System.Collections.IEnumerable
    {
        protected BatchDeploymentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.BatchDeploymentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string deploymentName, Azure.ResourceManager.MachineLearning.BatchDeploymentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.BatchDeploymentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string deploymentName, Azure.ResourceManager.MachineLearning.BatchDeploymentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.BatchDeploymentResource> Get(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearning.BatchDeploymentResource> GetAll(string orderBy = null, int? top = default(int?), string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearning.BatchDeploymentResource> GetAllAsync(string orderBy = null, int? top = default(int?), string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.BatchDeploymentResource>> GetAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MachineLearning.BatchDeploymentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.BatchDeploymentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MachineLearning.BatchDeploymentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.BatchDeploymentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class BatchDeploymentData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public BatchDeploymentData(Azure.Core.AzureLocation location, Azure.ResourceManager.MachineLearning.Models.BatchDeploymentProperties properties) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.BatchDeploymentProperties Properties { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningSku Sku { get { throw null; } set { } }
    }
    public partial class BatchDeploymentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BatchDeploymentResource() { }
        public virtual Azure.ResourceManager.MachineLearning.BatchDeploymentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.BatchDeploymentResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.BatchDeploymentResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string endpointName, string deploymentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.BatchDeploymentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.BatchDeploymentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.BatchDeploymentResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.BatchDeploymentResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.BatchDeploymentResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.BatchDeploymentResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.BatchDeploymentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.Models.BatchDeploymentPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.BatchDeploymentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.Models.BatchDeploymentPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BatchEndpointCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.BatchEndpointResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.BatchEndpointResource>, System.Collections.IEnumerable
    {
        protected BatchEndpointCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.BatchEndpointResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string endpointName, Azure.ResourceManager.MachineLearning.BatchEndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.BatchEndpointResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string endpointName, Azure.ResourceManager.MachineLearning.BatchEndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.BatchEndpointResource> Get(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearning.BatchEndpointResource> GetAll(int? count = default(int?), string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearning.BatchEndpointResource> GetAllAsync(int? count = default(int?), string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.BatchEndpointResource>> GetAsync(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MachineLearning.BatchEndpointResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.BatchEndpointResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MachineLearning.BatchEndpointResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.BatchEndpointResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class BatchEndpointData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public BatchEndpointData(Azure.Core.AzureLocation location, Azure.ResourceManager.MachineLearning.Models.BatchEndpointProperties properties) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.BatchEndpointProperties Properties { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningSku Sku { get { throw null; } set { } }
    }
    public partial class BatchEndpointResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BatchEndpointResource() { }
        public virtual Azure.ResourceManager.MachineLearning.BatchEndpointData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.BatchEndpointResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.BatchEndpointResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string endpointName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.BatchEndpointResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.BatchEndpointResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.BatchDeploymentResource> GetBatchDeployment(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.BatchDeploymentResource>> GetBatchDeploymentAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearning.BatchDeploymentCollection GetBatchDeployments() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.Models.EndpointAuthKeys> GetKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.Models.EndpointAuthKeys>> GetKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.BatchEndpointResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.BatchEndpointResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.BatchEndpointResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.BatchEndpointResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.BatchEndpointResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.Models.BatchEndpointPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.BatchEndpointResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.Models.BatchEndpointPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CodeContainerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.CodeContainerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.CodeContainerResource>, System.Collections.IEnumerable
    {
        protected CodeContainerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.CodeContainerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.MachineLearning.CodeContainerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.CodeContainerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.MachineLearning.CodeContainerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.CodeContainerResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearning.CodeContainerResource> GetAll(string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearning.CodeContainerResource> GetAllAsync(string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.CodeContainerResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MachineLearning.CodeContainerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.CodeContainerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MachineLearning.CodeContainerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.CodeContainerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CodeContainerData : Azure.ResourceManager.Models.ResourceData
    {
        public CodeContainerData(Azure.ResourceManager.MachineLearning.Models.CodeContainerProperties properties) { }
        public Azure.ResourceManager.MachineLearning.Models.CodeContainerProperties Properties { get { throw null; } set { } }
    }
    public partial class CodeContainerResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CodeContainerResource() { }
        public virtual Azure.ResourceManager.MachineLearning.CodeContainerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.CodeContainerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.CodeContainerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.CodeVersionResource> GetCodeVersion(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.CodeVersionResource>> GetCodeVersionAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearning.CodeVersionCollection GetCodeVersions() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.CodeContainerResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.CodeContainerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.CodeContainerResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.CodeContainerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CodeVersionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.CodeVersionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.CodeVersionResource>, System.Collections.IEnumerable
    {
        protected CodeVersionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.CodeVersionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string version, Azure.ResourceManager.MachineLearning.CodeVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.CodeVersionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string version, Azure.ResourceManager.MachineLearning.CodeVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.CodeVersionResource> Get(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearning.CodeVersionResource> GetAll(string orderBy = null, int? top = default(int?), string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearning.CodeVersionResource> GetAllAsync(string orderBy = null, int? top = default(int?), string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.CodeVersionResource>> GetAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MachineLearning.CodeVersionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.CodeVersionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MachineLearning.CodeVersionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.CodeVersionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CodeVersionData : Azure.ResourceManager.Models.ResourceData
    {
        public CodeVersionData(Azure.ResourceManager.MachineLearning.Models.CodeVersionProperties properties) { }
        public Azure.ResourceManager.MachineLearning.Models.CodeVersionProperties Properties { get { throw null; } set { } }
    }
    public partial class CodeVersionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CodeVersionResource() { }
        public virtual Azure.ResourceManager.MachineLearning.CodeVersionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string name, string version) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.CodeVersionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.CodeVersionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.CodeVersionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.CodeVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.CodeVersionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.CodeVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ComponentContainerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.ComponentContainerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.ComponentContainerResource>, System.Collections.IEnumerable
    {
        protected ComponentContainerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.ComponentContainerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.MachineLearning.ComponentContainerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.ComponentContainerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.MachineLearning.ComponentContainerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.ComponentContainerResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearning.ComponentContainerResource> GetAll(string skip = null, Azure.ResourceManager.MachineLearning.Models.ListViewType? listViewType = default(Azure.ResourceManager.MachineLearning.Models.ListViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearning.ComponentContainerResource> GetAllAsync(string skip = null, Azure.ResourceManager.MachineLearning.Models.ListViewType? listViewType = default(Azure.ResourceManager.MachineLearning.Models.ListViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.ComponentContainerResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MachineLearning.ComponentContainerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.ComponentContainerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MachineLearning.ComponentContainerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.ComponentContainerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ComponentContainerData : Azure.ResourceManager.Models.ResourceData
    {
        public ComponentContainerData(Azure.ResourceManager.MachineLearning.Models.ComponentContainerProperties properties) { }
        public Azure.ResourceManager.MachineLearning.Models.ComponentContainerProperties Properties { get { throw null; } set { } }
    }
    public partial class ComponentContainerResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ComponentContainerResource() { }
        public virtual Azure.ResourceManager.MachineLearning.ComponentContainerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.ComponentContainerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.ComponentContainerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.ComponentVersionResource> GetComponentVersion(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.ComponentVersionResource>> GetComponentVersionAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearning.ComponentVersionCollection GetComponentVersions() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.ComponentContainerResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.ComponentContainerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.ComponentContainerResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.ComponentContainerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ComponentVersionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.ComponentVersionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.ComponentVersionResource>, System.Collections.IEnumerable
    {
        protected ComponentVersionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.ComponentVersionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string version, Azure.ResourceManager.MachineLearning.ComponentVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.ComponentVersionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string version, Azure.ResourceManager.MachineLearning.ComponentVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.ComponentVersionResource> Get(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearning.ComponentVersionResource> GetAll(string orderBy = null, int? top = default(int?), string skip = null, Azure.ResourceManager.MachineLearning.Models.ListViewType? listViewType = default(Azure.ResourceManager.MachineLearning.Models.ListViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearning.ComponentVersionResource> GetAllAsync(string orderBy = null, int? top = default(int?), string skip = null, Azure.ResourceManager.MachineLearning.Models.ListViewType? listViewType = default(Azure.ResourceManager.MachineLearning.Models.ListViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.ComponentVersionResource>> GetAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MachineLearning.ComponentVersionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.ComponentVersionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MachineLearning.ComponentVersionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.ComponentVersionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ComponentVersionData : Azure.ResourceManager.Models.ResourceData
    {
        public ComponentVersionData(Azure.ResourceManager.MachineLearning.Models.ComponentVersionProperties properties) { }
        public Azure.ResourceManager.MachineLearning.Models.ComponentVersionProperties Properties { get { throw null; } set { } }
    }
    public partial class ComponentVersionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ComponentVersionResource() { }
        public virtual Azure.ResourceManager.MachineLearning.ComponentVersionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string name, string version) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.ComponentVersionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.ComponentVersionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.ComponentVersionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.ComponentVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.ComponentVersionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.ComponentVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataContainerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.DataContainerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.DataContainerResource>, System.Collections.IEnumerable
    {
        protected DataContainerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.DataContainerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.MachineLearning.DataContainerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.DataContainerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.MachineLearning.DataContainerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.DataContainerResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearning.DataContainerResource> GetAll(string skip = null, Azure.ResourceManager.MachineLearning.Models.ListViewType? listViewType = default(Azure.ResourceManager.MachineLearning.Models.ListViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearning.DataContainerResource> GetAllAsync(string skip = null, Azure.ResourceManager.MachineLearning.Models.ListViewType? listViewType = default(Azure.ResourceManager.MachineLearning.Models.ListViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.DataContainerResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MachineLearning.DataContainerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.DataContainerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MachineLearning.DataContainerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.DataContainerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataContainerData : Azure.ResourceManager.Models.ResourceData
    {
        public DataContainerData(Azure.ResourceManager.MachineLearning.Models.DataContainerProperties properties) { }
        public Azure.ResourceManager.MachineLearning.Models.DataContainerProperties Properties { get { throw null; } set { } }
    }
    public partial class DataContainerResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataContainerResource() { }
        public virtual Azure.ResourceManager.MachineLearning.DataContainerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.DataContainerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.DataContainerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.DataVersionResource> GetDataVersion(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.DataVersionResource>> GetDataVersionAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearning.DataVersionCollection GetDataVersions() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.DataContainerResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.DataContainerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.DataContainerResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.DataContainerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatastoreCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.DatastoreResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.DatastoreResource>, System.Collections.IEnumerable
    {
        protected DatastoreCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.DatastoreResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.MachineLearning.DatastoreData data, bool? skipValidation = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.DatastoreResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.MachineLearning.DatastoreData data, bool? skipValidation = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.DatastoreResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearning.DatastoreResource> GetAll(string skip = null, int? count = default(int?), bool? isDefault = default(bool?), System.Collections.Generic.IEnumerable<string> names = null, string searchText = null, string orderBy = null, bool? orderByAsc = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearning.DatastoreResource> GetAllAsync(string skip = null, int? count = default(int?), bool? isDefault = default(bool?), System.Collections.Generic.IEnumerable<string> names = null, string searchText = null, string orderBy = null, bool? orderByAsc = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.DatastoreResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MachineLearning.DatastoreResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.DatastoreResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MachineLearning.DatastoreResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.DatastoreResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DatastoreData : Azure.ResourceManager.Models.ResourceData
    {
        public DatastoreData(Azure.ResourceManager.MachineLearning.Models.DatastoreProperties properties) { }
        public Azure.ResourceManager.MachineLearning.Models.DatastoreProperties Properties { get { throw null; } set { } }
    }
    public partial class DatastoreResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DatastoreResource() { }
        public virtual Azure.ResourceManager.MachineLearning.DatastoreData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.DatastoreResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.DatastoreResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.Models.DatastoreSecrets> GetSecrets(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.Models.DatastoreSecrets>> GetSecretsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.DatastoreResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.DatastoreData data, bool? skipValidation = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.DatastoreResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.DatastoreData data, bool? skipValidation = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataVersionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.DataVersionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.DataVersionResource>, System.Collections.IEnumerable
    {
        protected DataVersionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.DataVersionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string version, Azure.ResourceManager.MachineLearning.DataVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.DataVersionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string version, Azure.ResourceManager.MachineLearning.DataVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.DataVersionResource> Get(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearning.DataVersionResource> GetAll(string orderBy = null, int? top = default(int?), string skip = null, string tags = null, Azure.ResourceManager.MachineLearning.Models.ListViewType? listViewType = default(Azure.ResourceManager.MachineLearning.Models.ListViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearning.DataVersionResource> GetAllAsync(string orderBy = null, int? top = default(int?), string skip = null, string tags = null, Azure.ResourceManager.MachineLearning.Models.ListViewType? listViewType = default(Azure.ResourceManager.MachineLearning.Models.ListViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.DataVersionResource>> GetAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MachineLearning.DataVersionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.DataVersionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MachineLearning.DataVersionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.DataVersionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataVersionData : Azure.ResourceManager.Models.ResourceData
    {
        public DataVersionData(Azure.ResourceManager.MachineLearning.Models.DataVersionProperties properties) { }
        public Azure.ResourceManager.MachineLearning.Models.DataVersionProperties Properties { get { throw null; } set { } }
    }
    public partial class DataVersionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataVersionResource() { }
        public virtual Azure.ResourceManager.MachineLearning.DataVersionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string name, string version) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.DataVersionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.DataVersionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.DataVersionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.DataVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.DataVersionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.DataVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EnvironmentContainerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.EnvironmentContainerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.EnvironmentContainerResource>, System.Collections.IEnumerable
    {
        protected EnvironmentContainerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.EnvironmentContainerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.MachineLearning.EnvironmentContainerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.EnvironmentContainerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.MachineLearning.EnvironmentContainerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.EnvironmentContainerResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearning.EnvironmentContainerResource> GetAll(string skip = null, Azure.ResourceManager.MachineLearning.Models.ListViewType? listViewType = default(Azure.ResourceManager.MachineLearning.Models.ListViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearning.EnvironmentContainerResource> GetAllAsync(string skip = null, Azure.ResourceManager.MachineLearning.Models.ListViewType? listViewType = default(Azure.ResourceManager.MachineLearning.Models.ListViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.EnvironmentContainerResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MachineLearning.EnvironmentContainerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.EnvironmentContainerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MachineLearning.EnvironmentContainerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.EnvironmentContainerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EnvironmentContainerData : Azure.ResourceManager.Models.ResourceData
    {
        public EnvironmentContainerData(Azure.ResourceManager.MachineLearning.Models.EnvironmentContainerProperties properties) { }
        public Azure.ResourceManager.MachineLearning.Models.EnvironmentContainerProperties Properties { get { throw null; } set { } }
    }
    public partial class EnvironmentContainerResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EnvironmentContainerResource() { }
        public virtual Azure.ResourceManager.MachineLearning.EnvironmentContainerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.EnvironmentContainerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.EnvironmentContainerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.EnvironmentVersionResource> GetEnvironmentVersion(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.EnvironmentVersionResource>> GetEnvironmentVersionAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearning.EnvironmentVersionCollection GetEnvironmentVersions() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.EnvironmentContainerResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.EnvironmentContainerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.EnvironmentContainerResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.EnvironmentContainerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EnvironmentVersionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.EnvironmentVersionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.EnvironmentVersionResource>, System.Collections.IEnumerable
    {
        protected EnvironmentVersionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.EnvironmentVersionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string version, Azure.ResourceManager.MachineLearning.EnvironmentVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.EnvironmentVersionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string version, Azure.ResourceManager.MachineLearning.EnvironmentVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.EnvironmentVersionResource> Get(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearning.EnvironmentVersionResource> GetAll(string orderBy = null, int? top = default(int?), string skip = null, Azure.ResourceManager.MachineLearning.Models.ListViewType? listViewType = default(Azure.ResourceManager.MachineLearning.Models.ListViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearning.EnvironmentVersionResource> GetAllAsync(string orderBy = null, int? top = default(int?), string skip = null, Azure.ResourceManager.MachineLearning.Models.ListViewType? listViewType = default(Azure.ResourceManager.MachineLearning.Models.ListViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.EnvironmentVersionResource>> GetAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MachineLearning.EnvironmentVersionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.EnvironmentVersionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MachineLearning.EnvironmentVersionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.EnvironmentVersionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EnvironmentVersionData : Azure.ResourceManager.Models.ResourceData
    {
        public EnvironmentVersionData(Azure.ResourceManager.MachineLearning.Models.EnvironmentVersionProperties properties) { }
        public Azure.ResourceManager.MachineLearning.Models.EnvironmentVersionProperties Properties { get { throw null; } set { } }
    }
    public partial class EnvironmentVersionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EnvironmentVersionResource() { }
        public virtual Azure.ResourceManager.MachineLearning.EnvironmentVersionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string name, string version) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.EnvironmentVersionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.EnvironmentVersionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.EnvironmentVersionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.EnvironmentVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.EnvironmentVersionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.EnvironmentVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MachineLearningComputeCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.MachineLearningComputeResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.MachineLearningComputeResource>, System.Collections.IEnumerable
    {
        protected MachineLearningComputeCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.MachineLearningComputeResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string computeName, Azure.ResourceManager.MachineLearning.MachineLearningComputeData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.MachineLearningComputeResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string computeName, Azure.ResourceManager.MachineLearning.MachineLearningComputeData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string computeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string computeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningComputeResource> Get(string computeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearning.MachineLearningComputeResource> GetAll(string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearning.MachineLearningComputeResource> GetAllAsync(string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningComputeResource>> GetAsync(string computeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MachineLearning.MachineLearningComputeResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.MachineLearningComputeResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MachineLearning.MachineLearningComputeResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.MachineLearningComputeResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MachineLearningComputeData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public MachineLearningComputeData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.Compute Properties { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningSku Sku { get { throw null; } set { } }
    }
    public partial class MachineLearningComputeResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MachineLearningComputeResource() { }
        public virtual Azure.ResourceManager.MachineLearning.MachineLearningComputeData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string computeName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.Models.UnderlyingResourceAction underlyingResourceAction, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.Models.UnderlyingResourceAction underlyingResourceAction, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningComputeResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningComputeResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.Models.ComputeSecrets> GetKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.Models.ComputeSecrets>> GetKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearning.Models.AmlComputeNodeInformation> GetNodes(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearning.Models.AmlComputeNodeInformation> GetNodesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Restart(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RestartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Start(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Stop(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StopAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.MachineLearningComputeResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.Models.MachineLearningComputePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.MachineLearningComputeResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.Models.MachineLearningComputePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class MachineLearningExtensions
    {
        public static Azure.Pageable<Azure.ResourceManager.MachineLearning.Models.ResourceQuota> GetAllQuota(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.MachineLearning.Models.ResourceQuota> GetAllQuotaAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.MachineLearning.BatchDeploymentResource GetBatchDeploymentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MachineLearning.BatchEndpointResource GetBatchEndpointResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MachineLearning.CodeContainerResource GetCodeContainerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MachineLearning.CodeVersionResource GetCodeVersionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MachineLearning.ComponentContainerResource GetComponentContainerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MachineLearning.ComponentVersionResource GetComponentVersionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MachineLearning.DataContainerResource GetDataContainerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MachineLearning.DatastoreResource GetDatastoreResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MachineLearning.DataVersionResource GetDataVersionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MachineLearning.EnvironmentContainerResource GetEnvironmentContainerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MachineLearning.EnvironmentVersionResource GetEnvironmentVersionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MachineLearning.MachineLearningComputeResource GetMachineLearningComputeResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MachineLearning.MachineLearningJobResource GetMachineLearningJobResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MachineLearning.MachineLearningPrivateEndpointConnectionResource GetMachineLearningPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningWorkspaceResource> GetMachineLearningWorkspace(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningWorkspaceResource>> GetMachineLearningWorkspaceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.MachineLearning.MachineLearningWorkspaceResource GetMachineLearningWorkspaceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MachineLearning.MachineLearningWorkspaceCollection GetMachineLearningWorkspaces(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.MachineLearning.MachineLearningWorkspaceResource> GetMachineLearningWorkspaces(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.MachineLearning.MachineLearningWorkspaceResource> GetMachineLearningWorkspacesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.MachineLearning.ModelContainerResource GetModelContainerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MachineLearning.ModelVersionResource GetModelVersionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MachineLearning.OnlineDeploymentResource GetOnlineDeploymentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MachineLearning.OnlineEndpointResource GetOnlineEndpointResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.MachineLearning.Models.MachineLearningUsage> GetUsages(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.MachineLearning.Models.MachineLearningUsage> GetUsagesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.MachineLearning.Models.VirtualMachineSize> GetVirtualMachineSizes(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.MachineLearning.Models.VirtualMachineSize> GetVirtualMachineSizesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.MachineLearning.WorkspaceConnectionResource GetWorkspaceConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.MachineLearning.Models.UpdateWorkspaceQuotas> UpdateAllQuota(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.MachineLearning.Models.QuotaUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.MachineLearning.Models.UpdateWorkspaceQuotas> UpdateAllQuotaAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.MachineLearning.Models.QuotaUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MachineLearningJobCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.MachineLearningJobResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.MachineLearningJobResource>, System.Collections.IEnumerable
    {
        protected MachineLearningJobCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.MachineLearningJobResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string id, Azure.ResourceManager.MachineLearning.MachineLearningJobData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.MachineLearningJobResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string id, Azure.ResourceManager.MachineLearning.MachineLearningJobData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningJobResource> Get(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearning.MachineLearningJobResource> GetAll(string skip = null, string jobType = null, string tag = null, Azure.ResourceManager.MachineLearning.Models.ListViewType? listViewType = default(Azure.ResourceManager.MachineLearning.Models.ListViewType?), bool? scheduled = default(bool?), string scheduleId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearning.MachineLearningJobResource> GetAllAsync(string skip = null, string jobType = null, string tag = null, Azure.ResourceManager.MachineLearning.Models.ListViewType? listViewType = default(Azure.ResourceManager.MachineLearning.Models.ListViewType?), bool? scheduled = default(bool?), string scheduleId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningJobResource>> GetAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MachineLearning.MachineLearningJobResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.MachineLearningJobResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MachineLearning.MachineLearningJobResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.MachineLearningJobResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MachineLearningJobData : Azure.ResourceManager.Models.ResourceData
    {
        public MachineLearningJobData(Azure.ResourceManager.MachineLearning.Models.MachineLearningJobProperties properties) { }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningJobProperties Properties { get { throw null; } set { } }
    }
    public partial class MachineLearningJobResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MachineLearningJobResource() { }
        public virtual Azure.ResourceManager.MachineLearning.MachineLearningJobData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response Cancel(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string id) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningJobResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningJobResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.MachineLearningJobResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.MachineLearningJobData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.MachineLearningJobResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.MachineLearningJobData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class MachineLearningPrivateEndpointConnectionData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public MachineLearningPrivateEndpointConnectionData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningPrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.PrivateEndpoint PrivateEndpoint { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningPrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningSku Sku { get { throw null; } set { } }
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
    public partial class MachineLearningWorkspaceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.MachineLearningWorkspaceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.MachineLearningWorkspaceResource>, System.Collections.IEnumerable
    {
        protected MachineLearningWorkspaceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.MachineLearningWorkspaceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string workspaceName, Azure.ResourceManager.MachineLearning.MachineLearningWorkspaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.MachineLearningWorkspaceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string workspaceName, Azure.ResourceManager.MachineLearning.MachineLearningWorkspaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningWorkspaceResource> Get(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearning.MachineLearningWorkspaceResource> GetAll(string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearning.MachineLearningWorkspaceResource> GetAllAsync(string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningWorkspaceResource>> GetAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MachineLearning.MachineLearningWorkspaceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.MachineLearningWorkspaceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MachineLearning.MachineLearningWorkspaceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.MachineLearningWorkspaceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MachineLearningWorkspaceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public MachineLearningWorkspaceData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
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
        public System.Guid? TenantId { get { throw null; } }
        public string WorkspaceId { get { throw null; } }
    }
    public partial class MachineLearningWorkspaceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MachineLearningWorkspaceResource() { }
        public virtual Azure.ResourceManager.MachineLearning.MachineLearningWorkspaceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningWorkspaceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningWorkspaceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.Models.DiagnoseResponseResult> Diagnose(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.Models.DiagnoseWorkspaceContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.Models.DiagnoseResponseResult>> DiagnoseAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.Models.DiagnoseWorkspaceContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningWorkspaceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningWorkspaceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.BatchEndpointResource> GetBatchEndpoint(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.BatchEndpointResource>> GetBatchEndpointAsync(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearning.BatchEndpointCollection GetBatchEndpoints() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.CodeContainerResource> GetCodeContainer(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.CodeContainerResource>> GetCodeContainerAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearning.CodeContainerCollection GetCodeContainers() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.ComponentContainerResource> GetComponentContainer(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.ComponentContainerResource>> GetComponentContainerAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearning.ComponentContainerCollection GetComponentContainers() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.DataContainerResource> GetDataContainer(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.DataContainerResource>> GetDataContainerAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearning.DataContainerCollection GetDataContainers() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.DatastoreResource> GetDatastore(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.DatastoreResource>> GetDatastoreAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearning.DatastoreCollection GetDatastores() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.EnvironmentContainerResource> GetEnvironmentContainer(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.EnvironmentContainerResource>> GetEnvironmentContainerAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearning.EnvironmentContainerCollection GetEnvironmentContainers() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.Models.ListWorkspaceKeysResult> GetKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.Models.ListWorkspaceKeysResult>> GetKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningComputeResource> GetMachineLearningCompute(string computeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningComputeResource>> GetMachineLearningComputeAsync(string computeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearning.MachineLearningComputeCollection GetMachineLearningComputes() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningJobResource> GetMachineLearningJob(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningJobResource>> GetMachineLearningJobAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearning.MachineLearningJobCollection GetMachineLearningJobs() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningPrivateEndpointConnectionResource> GetMachineLearningPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningPrivateEndpointConnectionResource>> GetMachineLearningPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearning.MachineLearningPrivateEndpointConnectionCollection GetMachineLearningPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.ModelContainerResource> GetModelContainer(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.ModelContainerResource>> GetModelContainerAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearning.ModelContainerCollection GetModelContainers() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.Models.NotebookAccessTokenResult> GetNotebookAccessToken(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.Models.NotebookAccessTokenResult>> GetNotebookAccessTokenAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.Models.ListNotebookKeysResult> GetNotebookKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.Models.ListNotebookKeysResult>> GetNotebookKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.OnlineEndpointResource> GetOnlineEndpoint(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.OnlineEndpointResource>> GetOnlineEndpointAsync(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearning.OnlineEndpointCollection GetOnlineEndpoints() { throw null; }
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
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningWorkspaceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningWorkspaceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ResyncKeys(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ResyncKeysAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningWorkspaceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningWorkspaceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.MachineLearningWorkspaceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.Models.MachineLearningWorkspacePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.MachineLearningWorkspaceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.Models.MachineLearningWorkspacePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ModelContainerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.ModelContainerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.ModelContainerResource>, System.Collections.IEnumerable
    {
        protected ModelContainerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.ModelContainerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.MachineLearning.ModelContainerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.ModelContainerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.MachineLearning.ModelContainerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.ModelContainerResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearning.ModelContainerResource> GetAll(string skip = null, int? count = default(int?), Azure.ResourceManager.MachineLearning.Models.ListViewType? listViewType = default(Azure.ResourceManager.MachineLearning.Models.ListViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearning.ModelContainerResource> GetAllAsync(string skip = null, int? count = default(int?), Azure.ResourceManager.MachineLearning.Models.ListViewType? listViewType = default(Azure.ResourceManager.MachineLearning.Models.ListViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.ModelContainerResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MachineLearning.ModelContainerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.ModelContainerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MachineLearning.ModelContainerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.ModelContainerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ModelContainerData : Azure.ResourceManager.Models.ResourceData
    {
        public ModelContainerData(Azure.ResourceManager.MachineLearning.Models.ModelContainerProperties properties) { }
        public Azure.ResourceManager.MachineLearning.Models.ModelContainerProperties Properties { get { throw null; } set { } }
    }
    public partial class ModelContainerResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ModelContainerResource() { }
        public virtual Azure.ResourceManager.MachineLearning.ModelContainerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.ModelContainerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.ModelContainerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.ModelVersionResource> GetModelVersion(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.ModelVersionResource>> GetModelVersionAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearning.ModelVersionCollection GetModelVersions() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.ModelContainerResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.ModelContainerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.ModelContainerResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.ModelContainerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ModelVersionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.ModelVersionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.ModelVersionResource>, System.Collections.IEnumerable
    {
        protected ModelVersionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.ModelVersionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string version, Azure.ResourceManager.MachineLearning.ModelVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.ModelVersionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string version, Azure.ResourceManager.MachineLearning.ModelVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.ModelVersionResource> Get(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearning.ModelVersionResource> GetAll(string skip = null, string orderBy = null, int? top = default(int?), string version = null, string description = null, int? offset = default(int?), string tags = null, string properties = null, string feed = null, Azure.ResourceManager.MachineLearning.Models.ListViewType? listViewType = default(Azure.ResourceManager.MachineLearning.Models.ListViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearning.ModelVersionResource> GetAllAsync(string skip = null, string orderBy = null, int? top = default(int?), string version = null, string description = null, int? offset = default(int?), string tags = null, string properties = null, string feed = null, Azure.ResourceManager.MachineLearning.Models.ListViewType? listViewType = default(Azure.ResourceManager.MachineLearning.Models.ListViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.ModelVersionResource>> GetAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MachineLearning.ModelVersionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.ModelVersionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MachineLearning.ModelVersionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.ModelVersionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ModelVersionData : Azure.ResourceManager.Models.ResourceData
    {
        public ModelVersionData(Azure.ResourceManager.MachineLearning.Models.ModelVersionProperties properties) { }
        public Azure.ResourceManager.MachineLearning.Models.ModelVersionProperties Properties { get { throw null; } set { } }
    }
    public partial class ModelVersionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ModelVersionResource() { }
        public virtual Azure.ResourceManager.MachineLearning.ModelVersionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string name, string version) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.ModelVersionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.ModelVersionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.ModelVersionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.ModelVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.ModelVersionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.ModelVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OnlineDeploymentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.OnlineDeploymentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.OnlineDeploymentResource>, System.Collections.IEnumerable
    {
        protected OnlineDeploymentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.OnlineDeploymentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string deploymentName, Azure.ResourceManager.MachineLearning.OnlineDeploymentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.OnlineDeploymentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string deploymentName, Azure.ResourceManager.MachineLearning.OnlineDeploymentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.OnlineDeploymentResource> Get(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearning.OnlineDeploymentResource> GetAll(string orderBy = null, int? top = default(int?), string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearning.OnlineDeploymentResource> GetAllAsync(string orderBy = null, int? top = default(int?), string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.OnlineDeploymentResource>> GetAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MachineLearning.OnlineDeploymentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.OnlineDeploymentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MachineLearning.OnlineDeploymentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.OnlineDeploymentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class OnlineDeploymentData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public OnlineDeploymentData(Azure.Core.AzureLocation location, Azure.ResourceManager.MachineLearning.Models.OnlineDeploymentProperties properties) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.OnlineDeploymentProperties Properties { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningSku Sku { get { throw null; } set { } }
    }
    public partial class OnlineDeploymentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected OnlineDeploymentResource() { }
        public virtual Azure.ResourceManager.MachineLearning.OnlineDeploymentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.OnlineDeploymentResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.OnlineDeploymentResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string endpointName, string deploymentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.OnlineDeploymentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.OnlineDeploymentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.Models.DeploymentLogs> GetLogs(Azure.ResourceManager.MachineLearning.Models.DeploymentLogsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.Models.DeploymentLogs>> GetLogsAsync(Azure.ResourceManager.MachineLearning.Models.DeploymentLogsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearning.Models.SkuResource> GetSkus(int? count = default(int?), string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearning.Models.SkuResource> GetSkusAsync(int? count = default(int?), string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.OnlineDeploymentResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.OnlineDeploymentResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.OnlineDeploymentResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.OnlineDeploymentResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.OnlineDeploymentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.Models.OnlineDeploymentPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.OnlineDeploymentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.Models.OnlineDeploymentPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OnlineEndpointCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.OnlineEndpointResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.OnlineEndpointResource>, System.Collections.IEnumerable
    {
        protected OnlineEndpointCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.OnlineEndpointResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string endpointName, Azure.ResourceManager.MachineLearning.OnlineEndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.OnlineEndpointResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string endpointName, Azure.ResourceManager.MachineLearning.OnlineEndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.OnlineEndpointResource> Get(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearning.OnlineEndpointResource> GetAll(string name = null, int? count = default(int?), Azure.ResourceManager.MachineLearning.Models.EndpointComputeType? computeType = default(Azure.ResourceManager.MachineLearning.Models.EndpointComputeType?), string skip = null, string tags = null, string properties = null, Azure.ResourceManager.MachineLearning.Models.OrderString? orderBy = default(Azure.ResourceManager.MachineLearning.Models.OrderString?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearning.OnlineEndpointResource> GetAllAsync(string name = null, int? count = default(int?), Azure.ResourceManager.MachineLearning.Models.EndpointComputeType? computeType = default(Azure.ResourceManager.MachineLearning.Models.EndpointComputeType?), string skip = null, string tags = null, string properties = null, Azure.ResourceManager.MachineLearning.Models.OrderString? orderBy = default(Azure.ResourceManager.MachineLearning.Models.OrderString?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.OnlineEndpointResource>> GetAsync(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MachineLearning.OnlineEndpointResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.OnlineEndpointResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MachineLearning.OnlineEndpointResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.OnlineEndpointResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class OnlineEndpointData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public OnlineEndpointData(Azure.Core.AzureLocation location, Azure.ResourceManager.MachineLearning.Models.OnlineEndpointProperties properties) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.OnlineEndpointProperties Properties { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningSku Sku { get { throw null; } set { } }
    }
    public partial class OnlineEndpointResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected OnlineEndpointResource() { }
        public virtual Azure.ResourceManager.MachineLearning.OnlineEndpointData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.OnlineEndpointResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.OnlineEndpointResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string endpointName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.OnlineEndpointResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.OnlineEndpointResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.Models.EndpointAuthKeys> GetKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.Models.EndpointAuthKeys>> GetKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.OnlineDeploymentResource> GetOnlineDeployment(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.OnlineDeploymentResource>> GetOnlineDeploymentAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearning.OnlineDeploymentCollection GetOnlineDeployments() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.Models.EndpointAuthToken> GetToken(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.Models.EndpointAuthToken>> GetTokenAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RegenerateKeys(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.Models.RegenerateEndpointKeysContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RegenerateKeysAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.Models.RegenerateEndpointKeysContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.OnlineEndpointResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.OnlineEndpointResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.OnlineEndpointResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.OnlineEndpointResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.OnlineEndpointResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.Models.OnlineEndpointPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.OnlineEndpointResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.Models.OnlineEndpointPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class AksCompute : Azure.ResourceManager.MachineLearning.Models.Compute
    {
        public AksCompute() { }
        public Azure.ResourceManager.MachineLearning.Models.AksSchemaProperties Properties { get { throw null; } set { } }
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
    public partial class AksSchemaProperties
    {
        public AksSchemaProperties() { }
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
        public string PrivateIPAddress { get { throw null; } }
        public string PublicIPAddress { get { throw null; } }
        public string RunId { get { throw null; } }
    }
    public partial class AmlComputeProperties
    {
        public AmlComputeProperties() { }
        public Azure.ResourceManager.MachineLearning.Models.AllocationState? AllocationState { get { throw null; } }
        public System.DateTimeOffset? AllocationStateTransitionOn { get { throw null; } }
        public int? CurrentNodeCount { get { throw null; } }
        public bool? EnableNodePublicIP { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearning.Models.ErrorResponse> Errors { get { throw null; } }
        public bool? IsolatedNetwork { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.NodeStateCounts NodeStateCounts { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.OSType? OSType { get { throw null; } set { } }
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
    public abstract partial class AssetReferenceBase
    {
        protected AssetReferenceBase() { }
    }
    public partial class AssignedUser
    {
        public AssignedUser(string objectId, System.Guid tenantId) { }
        public string ObjectId { get { throw null; } set { } }
        public System.Guid TenantId { get { throw null; } set { } }
    }
    public partial class AutoForecastHorizon : Azure.ResourceManager.MachineLearning.Models.ForecastHorizon
    {
        public AutoForecastHorizon() { }
    }
    public partial class AutoMLJob : Azure.ResourceManager.MachineLearning.Models.MachineLearningJobProperties
    {
        public AutoMLJob(Azure.ResourceManager.MachineLearning.Models.AutoMLVertical taskDetails) { }
        public string EnvironmentId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> EnvironmentVariables { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.MachineLearning.Models.JobOutput> Outputs { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ResourceConfiguration Resources { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.AutoMLVertical TaskDetails { get { throw null; } set { } }
    }
    public abstract partial class AutoMLVertical
    {
        protected AutoMLVertical() { }
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
    public partial class AzureBlobDatastore : Azure.ResourceManager.MachineLearning.Models.DatastoreProperties
    {
        public AzureBlobDatastore(Azure.ResourceManager.MachineLearning.Models.DatastoreCredentials credentials) : base (default(Azure.ResourceManager.MachineLearning.Models.DatastoreCredentials)) { }
        public string AccountName { get { throw null; } set { } }
        public string ContainerName { get { throw null; } set { } }
        public string Endpoint { get { throw null; } set { } }
        public string Protocol { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ServiceDataAccessAuthIdentity? ServiceDataAccessAuthIdentity { get { throw null; } set { } }
    }
    public partial class AzureDataLakeGen1Datastore : Azure.ResourceManager.MachineLearning.Models.DatastoreProperties
    {
        public AzureDataLakeGen1Datastore(Azure.ResourceManager.MachineLearning.Models.DatastoreCredentials credentials, string storeName) : base (default(Azure.ResourceManager.MachineLearning.Models.DatastoreCredentials)) { }
        public Azure.ResourceManager.MachineLearning.Models.ServiceDataAccessAuthIdentity? ServiceDataAccessAuthIdentity { get { throw null; } set { } }
        public string StoreName { get { throw null; } set { } }
    }
    public partial class AzureDataLakeGen2Datastore : Azure.ResourceManager.MachineLearning.Models.DatastoreProperties
    {
        public AzureDataLakeGen2Datastore(Azure.ResourceManager.MachineLearning.Models.DatastoreCredentials credentials, string accountName, string filesystem) : base (default(Azure.ResourceManager.MachineLearning.Models.DatastoreCredentials)) { }
        public string AccountName { get { throw null; } set { } }
        public string Endpoint { get { throw null; } set { } }
        public string Filesystem { get { throw null; } set { } }
        public string Protocol { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ServiceDataAccessAuthIdentity? ServiceDataAccessAuthIdentity { get { throw null; } set { } }
    }
    public partial class AzureFileDatastore : Azure.ResourceManager.MachineLearning.Models.DatastoreProperties
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
    public partial class BatchDeploymentPatch
    {
        public BatchDeploymentPatch() { }
        public Azure.ResourceManager.MachineLearning.Models.PartialManagedServiceIdentity Identity { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.PartialBatchDeployment Properties { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.PartialSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class BatchDeploymentProperties : Azure.ResourceManager.MachineLearning.Models.EndpointDeploymentPropertiesBase
    {
        public BatchDeploymentProperties() { }
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
    public partial class BatchEndpointPatch
    {
        public BatchEndpointPatch() { }
        public string DefaultsDeploymentName { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.PartialManagedServiceIdentity Identity { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.PartialSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class BatchEndpointProperties : Azure.ResourceManager.MachineLearning.Models.EndpointPropertiesBase
    {
        public BatchEndpointProperties(Azure.ResourceManager.MachineLearning.Models.EndpointAuthMode authMode) : base (default(Azure.ResourceManager.MachineLearning.Models.EndpointAuthMode)) { }
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
        public static Azure.ResourceManager.MachineLearning.Models.BillingCurrency Usd { get { throw null; } }
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
        public System.Collections.Generic.IList<Azure.ResourceManager.MachineLearning.Models.ClassificationModel> AllowedModels { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.MachineLearning.Models.ClassificationModel> BlockedModels { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.TableVerticalDataSettings DataSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.TableVerticalFeaturizationSettings FeaturizationSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.TableVerticalLimitSettings LimitSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ClassificationPrimaryMetric? PrimaryMetric { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.TrainingSettings TrainingSettings { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClassificationModel : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.ClassificationModel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClassificationModel(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.ClassificationModel BernoulliNaiveBayes { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ClassificationModel DecisionTree { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ClassificationModel ExtremeRandomTrees { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ClassificationModel GradientBoosting { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ClassificationModel KNN { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ClassificationModel LightGBM { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ClassificationModel LinearSVM { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ClassificationModel LogisticRegression { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ClassificationModel MultinomialNaiveBayes { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ClassificationModel RandomForest { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ClassificationModel SGD { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ClassificationModel SVM { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ClassificationModel XGBoostClassifier { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.ClassificationModel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.ClassificationModel left, Azure.ResourceManager.MachineLearning.Models.ClassificationModel right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.ClassificationModel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.ClassificationModel left, Azure.ResourceManager.MachineLearning.Models.ClassificationModel right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClassificationMultilabelPrimaryMetric : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.ClassificationMultilabelPrimaryMetric>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClassificationMultilabelPrimaryMetric(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.ClassificationMultilabelPrimaryMetric Accuracy { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ClassificationMultilabelPrimaryMetric AUCWeighted { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ClassificationMultilabelPrimaryMetric AveragePrecisionScoreWeighted { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ClassificationMultilabelPrimaryMetric IOU { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ClassificationMultilabelPrimaryMetric NormMacroRecall { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ClassificationMultilabelPrimaryMetric PrecisionScoreWeighted { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.ClassificationMultilabelPrimaryMetric other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.ClassificationMultilabelPrimaryMetric left, Azure.ResourceManager.MachineLearning.Models.ClassificationMultilabelPrimaryMetric right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.ClassificationMultilabelPrimaryMetric (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.ClassificationMultilabelPrimaryMetric left, Azure.ResourceManager.MachineLearning.Models.ClassificationMultilabelPrimaryMetric right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClassificationPrimaryMetric : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.ClassificationPrimaryMetric>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClassificationPrimaryMetric(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.ClassificationPrimaryMetric Accuracy { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ClassificationPrimaryMetric AUCWeighted { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ClassificationPrimaryMetric AveragePrecisionScoreWeighted { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ClassificationPrimaryMetric NormMacroRecall { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ClassificationPrimaryMetric PrecisionScoreWeighted { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.ClassificationPrimaryMetric other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.ClassificationPrimaryMetric left, Azure.ResourceManager.MachineLearning.Models.ClassificationPrimaryMetric right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.ClassificationPrimaryMetric (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.ClassificationPrimaryMetric left, Azure.ResourceManager.MachineLearning.Models.ClassificationPrimaryMetric right) { throw null; }
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
    public partial class CodeContainerProperties : Azure.ResourceManager.MachineLearning.Models.AssetContainer
    {
        public CodeContainerProperties() { }
    }
    public partial class CodeVersionProperties : Azure.ResourceManager.MachineLearning.Models.AssetBase
    {
        public CodeVersionProperties() { }
        public System.Uri CodeUri { get { throw null; } set { } }
    }
    public partial class ColumnTransformer
    {
        public ColumnTransformer() { }
        public System.Collections.Generic.IList<string> Fields { get { throw null; } set { } }
        public System.BinaryData Parameters { get { throw null; } set { } }
    }
    public partial class CommandJob : Azure.ResourceManager.MachineLearning.Models.MachineLearningJobProperties
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
    public partial class ComponentContainerProperties : Azure.ResourceManager.MachineLearning.Models.AssetContainer
    {
        public ComponentContainerProperties() { }
    }
    public partial class ComponentVersionProperties : Azure.ResourceManager.MachineLearning.Models.AssetBase
    {
        public ComponentVersionProperties() { }
        public System.BinaryData ComponentSpec { get { throw null; } set { } }
    }
    public abstract partial class Compute
    {
        protected Compute() { }
        public string ComputeLocation { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public bool? DisableLocalAuth { get { throw null; } set { } }
        public bool? IsAttachedCompute { get { throw null; } }
        public System.DateTimeOffset? ModifiedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearning.Models.ErrorResponse> ProvisioningErrors { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
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
        public string PrivateIPAddress { get { throw null; } }
        public string PublicIPAddress { get { throw null; } }
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
        public bool? EnableNodePublicIP { get { throw null; } set { } }
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
    public abstract partial class ComputeSecrets
    {
        protected ComputeSecrets() { }
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
    public partial class DatabricksCompute : Azure.ResourceManager.MachineLearning.Models.Compute
    {
        public DatabricksCompute() { }
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
    public partial class DataContainerProperties : Azure.ResourceManager.MachineLearning.Models.AssetContainer
    {
        public DataContainerProperties(Azure.ResourceManager.MachineLearning.Models.DataType dataType) { }
        public Azure.ResourceManager.MachineLearning.Models.DataType DataType { get { throw null; } set { } }
    }
    public partial class DataFactoryCompute : Azure.ResourceManager.MachineLearning.Models.Compute
    {
        public DataFactoryCompute() { }
    }
    public partial class DataLakeAnalyticsCompute : Azure.ResourceManager.MachineLearning.Models.Compute
    {
        public DataLakeAnalyticsCompute() { }
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
    public abstract partial class DatastoreCredentials
    {
        protected DatastoreCredentials() { }
    }
    public partial class DatastoreProperties : Azure.ResourceManager.MachineLearning.Models.ResourceBase
    {
        public DatastoreProperties(Azure.ResourceManager.MachineLearning.Models.DatastoreCredentials credentials) { }
        public Azure.ResourceManager.MachineLearning.Models.DatastoreCredentials Credentials { get { throw null; } set { } }
        public bool? IsDefault { get { throw null; } }
    }
    public abstract partial class DatastoreSecrets
    {
        protected DatastoreSecrets() { }
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
    public partial class DataVersionProperties : Azure.ResourceManager.MachineLearning.Models.AssetBase
    {
        public DataVersionProperties(System.Uri dataUri) { }
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
    public abstract partial class DistributionConfiguration
    {
        protected DistributionConfiguration() { }
    }
    public abstract partial class EarlyTerminationPolicy
    {
        protected EarlyTerminationPolicy() { }
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
    public partial class EnvironmentContainerProperties : Azure.ResourceManager.MachineLearning.Models.AssetContainer
    {
        public EnvironmentContainerProperties() { }
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
    public partial class EnvironmentVersionProperties : Azure.ResourceManager.MachineLearning.Models.AssetBase
    {
        public EnvironmentVersionProperties() { }
        public Azure.ResourceManager.MachineLearning.Models.BuildContext Build { get { throw null; } set { } }
        public string CondaFile { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.EnvironmentType? EnvironmentType { get { throw null; } }
        public string Image { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.InferenceContainerProperties InferenceConfig { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.OperatingSystemType? OSType { get { throw null; } set { } }
    }
    public partial class ErrorResponse
    {
        internal ErrorResponse() { }
        public Azure.ResponseError Error { get { throw null; } }
    }
    public partial class EstimatedVmPrice
    {
        internal EstimatedVmPrice() { }
        public Azure.ResourceManager.MachineLearning.Models.VmPriceOSType OSType { get { throw null; } }
        public double RetailPrice { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.VmTier VmTier { get { throw null; } }
    }
    public partial class EstimatedVmPrices
    {
        internal EstimatedVmPrices() { }
        public Azure.ResourceManager.MachineLearning.Models.BillingCurrency BillingCurrency { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.UnitOfMeasure UnitOfMeasure { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearning.Models.EstimatedVmPrice> Values { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FeatureLag : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.FeatureLag>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FeatureLag(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.FeatureLag Auto { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.FeatureLag None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.FeatureLag other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.FeatureLag left, Azure.ResourceManager.MachineLearning.Models.FeatureLag right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.FeatureLag (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.FeatureLag left, Azure.ResourceManager.MachineLearning.Models.FeatureLag right) { throw null; }
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
    public abstract partial class ForecastHorizon
    {
        protected ForecastHorizon() { }
    }
    public partial class Forecasting : Azure.ResourceManager.MachineLearning.Models.AutoMLVertical
    {
        public Forecasting() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.MachineLearning.Models.ForecastingModel> AllowedModels { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.MachineLearning.Models.ForecastingModel> BlockedModels { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.TableVerticalDataSettings DataSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.TableVerticalFeaturizationSettings FeaturizationSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ForecastingSettings ForecastingSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.TableVerticalLimitSettings LimitSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ForecastingPrimaryMetric? PrimaryMetric { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.TrainingSettings TrainingSettings { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ForecastingModel : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.ForecastingModel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ForecastingModel(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.ForecastingModel Arimax { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ForecastingModel AutoArima { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ForecastingModel Average { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ForecastingModel DecisionTree { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ForecastingModel ElasticNet { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ForecastingModel ExponentialSmoothing { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ForecastingModel ExtremeRandomTrees { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ForecastingModel GradientBoosting { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ForecastingModel KNN { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ForecastingModel LassoLars { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ForecastingModel LightGBM { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ForecastingModel Naive { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ForecastingModel Prophet { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ForecastingModel RandomForest { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ForecastingModel SeasonalAverage { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ForecastingModel SeasonalNaive { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ForecastingModel SGD { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ForecastingModel TCNForecaster { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ForecastingModel XGBoostRegressor { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.ForecastingModel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.ForecastingModel left, Azure.ResourceManager.MachineLearning.Models.ForecastingModel right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.ForecastingModel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.ForecastingModel left, Azure.ResourceManager.MachineLearning.Models.ForecastingModel right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ForecastingPrimaryMetric : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.ForecastingPrimaryMetric>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ForecastingPrimaryMetric(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.ForecastingPrimaryMetric NormalizedMeanAbsoluteError { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ForecastingPrimaryMetric NormalizedRootMeanSquaredError { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ForecastingPrimaryMetric R2Score { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ForecastingPrimaryMetric SpearmanCorrelation { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.ForecastingPrimaryMetric other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.ForecastingPrimaryMetric left, Azure.ResourceManager.MachineLearning.Models.ForecastingPrimaryMetric right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.ForecastingPrimaryMetric (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.ForecastingPrimaryMetric left, Azure.ResourceManager.MachineLearning.Models.ForecastingPrimaryMetric right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ForecastingSettings
    {
        public ForecastingSettings() { }
        public string CountryOrRegionForHolidays { get { throw null; } set { } }
        public int? CvStepSize { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.FeatureLag? FeatureLags { get { throw null; } set { } }
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
    public partial class HdfsDatastore : Azure.ResourceManager.MachineLearning.Models.DatastoreProperties
    {
        public HdfsDatastore(Azure.ResourceManager.MachineLearning.Models.DatastoreCredentials credentials, string nameNodeAddress) : base (default(Azure.ResourceManager.MachineLearning.Models.DatastoreCredentials)) { }
        public string HdfsServerCertificate { get { throw null; } set { } }
        public string NameNodeAddress { get { throw null; } set { } }
        public string Protocol { get { throw null; } set { } }
    }
    public partial class HDInsightCompute : Azure.ResourceManager.MachineLearning.Models.Compute
    {
        public HDInsightCompute() { }
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
    public abstract partial class IdentityConfiguration
    {
        protected IdentityConfiguration() { }
    }
    public partial class ImageClassification : Azure.ResourceManager.MachineLearning.Models.AutoMLVertical
    {
        public ImageClassification(Azure.ResourceManager.MachineLearning.Models.ImageVerticalDataSettings dataSettings, Azure.ResourceManager.MachineLearning.Models.ImageLimitSettings limitSettings) { }
        public Azure.ResourceManager.MachineLearning.Models.ImageVerticalDataSettings DataSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ImageLimitSettings LimitSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ImageModelSettingsClassification ModelSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ClassificationPrimaryMetric? PrimaryMetric { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.MachineLearning.Models.ImageModelDistributionSettingsClassification> SearchSpace { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ImageSweepSettings SweepSettings { get { throw null; } set { } }
    }
    public partial class ImageClassificationMultilabel : Azure.ResourceManager.MachineLearning.Models.AutoMLVertical
    {
        public ImageClassificationMultilabel(Azure.ResourceManager.MachineLearning.Models.ImageVerticalDataSettings dataSettings, Azure.ResourceManager.MachineLearning.Models.ImageLimitSettings limitSettings) { }
        public Azure.ResourceManager.MachineLearning.Models.ImageVerticalDataSettings DataSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ImageLimitSettings LimitSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ImageModelSettingsClassification ModelSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ClassificationMultilabelPrimaryMetric? PrimaryMetric { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.MachineLearning.Models.ImageModelDistributionSettingsClassification> SearchSpace { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ImageSweepSettings SweepSettings { get { throw null; } set { } }
    }
    public partial class ImageInstanceSegmentation : Azure.ResourceManager.MachineLearning.Models.AutoMLVertical
    {
        public ImageInstanceSegmentation(Azure.ResourceManager.MachineLearning.Models.ImageVerticalDataSettings dataSettings, Azure.ResourceManager.MachineLearning.Models.ImageLimitSettings limitSettings) { }
        public Azure.ResourceManager.MachineLearning.Models.ImageVerticalDataSettings DataSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ImageLimitSettings LimitSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ImageModelSettingsObjectDetection ModelSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.InstanceSegmentationPrimaryMetric? PrimaryMetric { get { throw null; } set { } }
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
        public Azure.ResourceManager.MachineLearning.Models.ObjectDetectionPrimaryMetric? PrimaryMetric { get { throw null; } set { } }
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
    public readonly partial struct InstanceSegmentationPrimaryMetric : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.InstanceSegmentationPrimaryMetric>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public InstanceSegmentationPrimaryMetric(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.InstanceSegmentationPrimaryMetric MeanAveragePrecision { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.InstanceSegmentationPrimaryMetric other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.InstanceSegmentationPrimaryMetric left, Azure.ResourceManager.MachineLearning.Models.InstanceSegmentationPrimaryMetric right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.InstanceSegmentationPrimaryMetric (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.InstanceSegmentationPrimaryMetric left, Azure.ResourceManager.MachineLearning.Models.InstanceSegmentationPrimaryMetric right) { throw null; }
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
    public abstract partial class JobInput
    {
        protected JobInput() { }
        public string Description { get { throw null; } set { } }
    }
    public abstract partial class JobLimits
    {
        protected JobLimits() { }
        public System.TimeSpan? Timeout { get { throw null; } set { } }
    }
    public abstract partial class JobOutput
    {
        protected JobOutput() { }
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
    public partial class KubernetesCompute : Azure.ResourceManager.MachineLearning.Models.Compute
    {
        public KubernetesCompute() { }
        public Azure.ResourceManager.MachineLearning.Models.KubernetesProperties Properties { get { throw null; } set { } }
    }
    public partial class KubernetesOnlineDeployment : Azure.ResourceManager.MachineLearning.Models.OnlineDeploymentProperties
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
        public static Azure.ResourceManager.MachineLearning.Models.LoadBalancerType PublicIP { get { throw null; } }
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
    public partial class MachineLearningComputePatch
    {
        public MachineLearningComputePatch() { }
        public Azure.ResourceManager.MachineLearning.Models.ScaleSettings ScaleSettings { get { throw null; } set { } }
    }
    public partial class MachineLearningJobProperties : Azure.ResourceManager.MachineLearning.Models.ResourceBase
    {
        public MachineLearningJobProperties() { }
        public string ComputeId { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string ExperimentName { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.IdentityConfiguration Identity { get { throw null; } set { } }
        public bool? IsArchived { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ScheduleBase Schedule { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.MachineLearning.Models.JobService> Services { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.JobStatus? Status { get { throw null; } }
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
    public partial class MachineLearningPrivateLinkResource : Azure.ResourceManager.Models.TrackedResourceData
    {
        public MachineLearningPrivateLinkResource(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string GroupId { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredZoneNames { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningSku Sku { get { throw null; } set { } }
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
    public partial class MachineLearningWorkspacePatch
    {
        public MachineLearningWorkspacePatch() { }
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
    public partial class ManagedIdentity : Azure.ResourceManager.MachineLearning.Models.IdentityConfiguration
    {
        public ManagedIdentity() { }
        public System.Guid? ClientId { get { throw null; } set { } }
        public System.Guid? ObjectId { get { throw null; } set { } }
        public string ResourceId { get { throw null; } set { } }
    }
    public partial class ManagedOnlineDeployment : Azure.ResourceManager.MachineLearning.Models.OnlineDeploymentProperties
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
    public partial class MLTableData : Azure.ResourceManager.MachineLearning.Models.DataVersionProperties
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
    public partial class ModelContainerProperties : Azure.ResourceManager.MachineLearning.Models.AssetContainer
    {
        public ModelContainerProperties() { }
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
    public partial class ModelVersionProperties : Azure.ResourceManager.MachineLearning.Models.AssetBase
    {
        public ModelVersionProperties() { }
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
    public abstract partial class NCrossValidations
    {
        protected NCrossValidations() { }
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
    public readonly partial struct ObjectDetectionPrimaryMetric : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.ObjectDetectionPrimaryMetric>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ObjectDetectionPrimaryMetric(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.ObjectDetectionPrimaryMetric MeanAveragePrecision { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.ObjectDetectionPrimaryMetric other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.ObjectDetectionPrimaryMetric left, Azure.ResourceManager.MachineLearning.Models.ObjectDetectionPrimaryMetric right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.ObjectDetectionPrimaryMetric (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.ObjectDetectionPrimaryMetric left, Azure.ResourceManager.MachineLearning.Models.ObjectDetectionPrimaryMetric right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Objective
    {
        public Objective(Azure.ResourceManager.MachineLearning.Models.Goal goal, string primaryMetric) { }
        public Azure.ResourceManager.MachineLearning.Models.Goal Goal { get { throw null; } set { } }
        public string PrimaryMetric { get { throw null; } set { } }
    }
    public partial class OnlineDeploymentPatch
    {
        public OnlineDeploymentPatch() { }
        public Azure.ResourceManager.MachineLearning.Models.PartialManagedServiceIdentity Identity { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.PartialOnlineDeployment Properties { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.PartialSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class OnlineDeploymentProperties : Azure.ResourceManager.MachineLearning.Models.EndpointDeploymentPropertiesBase
    {
        public OnlineDeploymentProperties() { }
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
    public partial class OnlineEndpointPatch
    {
        public OnlineEndpointPatch() { }
        public Azure.ResourceManager.MachineLearning.Models.PartialManagedServiceIdentity Identity { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.PartialOnlineEndpoint Properties { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.PartialSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class OnlineEndpointProperties : Azure.ResourceManager.MachineLearning.Models.EndpointPropertiesBase
    {
        public OnlineEndpointProperties(Azure.ResourceManager.MachineLearning.Models.EndpointAuthMode authMode) : base (default(Azure.ResourceManager.MachineLearning.Models.EndpointAuthMode)) { }
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
    public abstract partial class OnlineScaleSettings
    {
        protected OnlineScaleSettings() { }
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
    public readonly partial struct OSType : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.OSType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OSType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.OSType Linux { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.OSType Windows { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.OSType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.OSType left, Azure.ResourceManager.MachineLearning.Models.OSType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.OSType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.OSType left, Azure.ResourceManager.MachineLearning.Models.OSType right) { throw null; }
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
    public abstract partial class PartialAssetReferenceBase
    {
        protected PartialAssetReferenceBase() { }
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
    public partial class PartialDataPathAssetReference : Azure.ResourceManager.MachineLearning.Models.PartialAssetReferenceBase
    {
        public PartialDataPathAssetReference() { }
        public string DatastoreId { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
    }
    public partial class PartialIdAssetReference : Azure.ResourceManager.MachineLearning.Models.PartialAssetReferenceBase
    {
        public PartialIdAssetReference() { }
        public string AssetId { get { throw null; } set { } }
    }
    public partial class PartialKubernetesOnlineDeployment : Azure.ResourceManager.MachineLearning.Models.PartialOnlineDeployment
    {
        public PartialKubernetesOnlineDeployment() { }
    }
    public partial class PartialManagedOnlineDeployment : Azure.ResourceManager.MachineLearning.Models.PartialOnlineDeployment
    {
        public PartialManagedOnlineDeployment() { }
    }
    public partial class PartialManagedServiceIdentity
    {
        public PartialManagedServiceIdentity() { }
        public Azure.ResourceManager.MachineLearning.Models.ManagedServiceIdentityType? ManagedServiceIdentityType { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> UserAssignedIdentities { get { throw null; } }
    }
    public abstract partial class PartialOnlineDeployment
    {
        protected PartialOnlineDeployment() { }
    }
    public partial class PartialOnlineEndpoint
    {
        public PartialOnlineEndpoint() { }
        public System.Collections.Generic.IDictionary<string, int> MirrorTraffic { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.PublicNetworkAccessType? PublicNetworkAccess { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, int> Traffic { get { throw null; } set { } }
    }
    public partial class PartialOutputPathAssetReference : Azure.ResourceManager.MachineLearning.Models.PartialAssetReferenceBase
    {
        public PartialOutputPathAssetReference() { }
        public string JobId { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
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
    public partial class PasswordDetail
    {
        internal PasswordDetail() { }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class PipelineJob : Azure.ResourceManager.MachineLearning.Models.MachineLearningJobProperties
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
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
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
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearning.Models.PasswordDetail> Passwords { get { throw null; } }
        public string Username { get { throw null; } }
    }
    public partial class Regression : Azure.ResourceManager.MachineLearning.Models.AutoMLVertical
    {
        public Regression() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.MachineLearning.Models.RegressionModel> AllowedModels { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.MachineLearning.Models.RegressionModel> BlockedModels { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.TableVerticalDataSettings DataSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.TableVerticalFeaturizationSettings FeaturizationSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.TableVerticalLimitSettings LimitSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.RegressionPrimaryMetric? PrimaryMetric { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.TrainingSettings TrainingSettings { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RegressionModel : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.RegressionModel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RegressionModel(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.RegressionModel DecisionTree { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.RegressionModel ElasticNet { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.RegressionModel ExtremeRandomTrees { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.RegressionModel GradientBoosting { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.RegressionModel KNN { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.RegressionModel LassoLars { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.RegressionModel LightGBM { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.RegressionModel RandomForest { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.RegressionModel SGD { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.RegressionModel XGBoostRegressor { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.RegressionModel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.RegressionModel left, Azure.ResourceManager.MachineLearning.Models.RegressionModel right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.RegressionModel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.RegressionModel left, Azure.ResourceManager.MachineLearning.Models.RegressionModel right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RegressionPrimaryMetric : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.RegressionPrimaryMetric>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RegressionPrimaryMetric(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.RegressionPrimaryMetric NormalizedMeanAbsoluteError { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.RegressionPrimaryMetric NormalizedRootMeanSquaredError { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.RegressionPrimaryMetric R2Score { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.RegressionPrimaryMetric SpearmanCorrelation { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.RegressionPrimaryMetric other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.RegressionPrimaryMetric left, Azure.ResourceManager.MachineLearning.Models.RegressionPrimaryMetric right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.RegressionPrimaryMetric (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.RegressionPrimaryMetric left, Azure.ResourceManager.MachineLearning.Models.RegressionPrimaryMetric right) { throw null; }
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
    public abstract partial class SamplingAlgorithm
    {
        protected SamplingAlgorithm() { }
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
    public abstract partial class ScheduleBase
    {
        protected ScheduleBase() { }
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
    public abstract partial class Seasonality
    {
        protected Seasonality() { }
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
        public static Azure.ResourceManager.MachineLearning.Models.SourceType Uri { get { throw null; } }
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
        public static Azure.ResourceManager.MachineLearning.Models.Status InvalidVmFamilyName { get { throw null; } }
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
    public partial class SweepJob : Azure.ResourceManager.MachineLearning.Models.MachineLearningJobProperties
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
    public partial class SynapseSparkCompute : Azure.ResourceManager.MachineLearning.Models.Compute
    {
        public SynapseSparkCompute() { }
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
        public string PublicIPAddress { get { throw null; } }
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
    public abstract partial class TargetLags
    {
        protected TargetLags() { }
    }
    public abstract partial class TargetRollingWindowSize
    {
        protected TargetRollingWindowSize() { }
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
        public Azure.ResourceManager.MachineLearning.Models.ClassificationPrimaryMetric? PrimaryMetric { get { throw null; } set { } }
    }
    public partial class TextClassificationMultilabel : Azure.ResourceManager.MachineLearning.Models.AutoMLVertical
    {
        public TextClassificationMultilabel() { }
        public Azure.ResourceManager.MachineLearning.Models.NlpVerticalDataSettings DataSettings { get { throw null; } set { } }
        public string FeaturizationDatasetLanguage { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.NlpVerticalLimitSettings LimitSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ClassificationMultilabelPrimaryMetric? PrimaryMetric { get { throw null; } }
    }
    public partial class TextNer : Azure.ResourceManager.MachineLearning.Models.AutoMLVertical
    {
        public TextNer() { }
        public Azure.ResourceManager.MachineLearning.Models.NlpVerticalDataSettings DataSettings { get { throw null; } set { } }
        public string FeaturizationDatasetLanguage { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.NlpVerticalLimitSettings LimitSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ClassificationPrimaryMetric? PrimaryMetric { get { throw null; } }
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
    public partial class UriFileDataVersion : Azure.ResourceManager.MachineLearning.Models.DataVersionProperties
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
    public partial class UriFolderDataVersion : Azure.ResourceManager.MachineLearning.Models.DataVersionProperties
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
    public partial class VirtualMachineCompute : Azure.ResourceManager.MachineLearning.Models.Compute
    {
        public VirtualMachineCompute() { }
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
        public Azure.ResourceManager.MachineLearning.Models.EstimatedVmPrices EstimatedVmPrices { get { throw null; } }
        public string Family { get { throw null; } }
        public int? Gpus { get { throw null; } }
        public bool? LowPriorityCapable { get { throw null; } }
        public int? MaxResourceVolumeMB { get { throw null; } }
        public double? MemoryGB { get { throw null; } }
        public string Name { get { throw null; } }
        public int? OSVhdSizeMB { get { throw null; } }
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
    public readonly partial struct VmPriceOSType : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.VmPriceOSType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VmPriceOSType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.VmPriceOSType Linux { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.VmPriceOSType Windows { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.VmPriceOSType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.VmPriceOSType left, Azure.ResourceManager.MachineLearning.Models.VmPriceOSType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.VmPriceOSType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.VmPriceOSType left, Azure.ResourceManager.MachineLearning.Models.VmPriceOSType right) { throw null; }
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
    public readonly partial struct VmTier : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.VmTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VmTier(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.VmTier LowPriority { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.VmTier Spot { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.VmTier Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.VmTier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.VmTier left, Azure.ResourceManager.MachineLearning.Models.VmTier right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.VmTier (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.VmTier left, Azure.ResourceManager.MachineLearning.Models.VmTier right) { throw null; }
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
}
