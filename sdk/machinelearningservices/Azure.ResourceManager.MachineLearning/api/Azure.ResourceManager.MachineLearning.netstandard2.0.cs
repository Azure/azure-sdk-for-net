namespace Azure.ResourceManager.MachineLearning
{
    public partial class MachineLearningBatchDeploymentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.MachineLearningBatchDeploymentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.MachineLearningBatchDeploymentResource>, System.Collections.IEnumerable
    {
        protected MachineLearningBatchDeploymentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.MachineLearningBatchDeploymentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string deploymentName, Azure.ResourceManager.MachineLearning.MachineLearningBatchDeploymentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.MachineLearningBatchDeploymentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string deploymentName, Azure.ResourceManager.MachineLearning.MachineLearningBatchDeploymentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningBatchDeploymentResource> Get(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearning.MachineLearningBatchDeploymentResource> GetAll(string orderBy = null, int? top = default(int?), string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearning.MachineLearningBatchDeploymentResource> GetAllAsync(string orderBy = null, int? top = default(int?), string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningBatchDeploymentResource>> GetAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MachineLearning.MachineLearningBatchDeploymentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.MachineLearningBatchDeploymentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MachineLearning.MachineLearningBatchDeploymentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.MachineLearningBatchDeploymentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MachineLearningBatchDeploymentData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public MachineLearningBatchDeploymentData(Azure.Core.AzureLocation location, Azure.ResourceManager.MachineLearning.Models.MachineLearningBatchDeploymentProperties properties) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningBatchDeploymentProperties Properties { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningSku Sku { get { throw null; } set { } }
    }
    public partial class MachineLearningBatchDeploymentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MachineLearningBatchDeploymentResource() { }
        public virtual Azure.ResourceManager.MachineLearning.MachineLearningBatchDeploymentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningBatchDeploymentResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningBatchDeploymentResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string endpointName, string deploymentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningBatchDeploymentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningBatchDeploymentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningBatchDeploymentResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningBatchDeploymentResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningBatchDeploymentResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningBatchDeploymentResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.MachineLearningBatchDeploymentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.Models.MachineLearningBatchDeploymentPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.MachineLearningBatchDeploymentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.Models.MachineLearningBatchDeploymentPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MachineLearningBatchEndpointCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.MachineLearningBatchEndpointResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.MachineLearningBatchEndpointResource>, System.Collections.IEnumerable
    {
        protected MachineLearningBatchEndpointCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.MachineLearningBatchEndpointResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string endpointName, Azure.ResourceManager.MachineLearning.MachineLearningBatchEndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.MachineLearningBatchEndpointResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string endpointName, Azure.ResourceManager.MachineLearning.MachineLearningBatchEndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningBatchEndpointResource> Get(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearning.MachineLearningBatchEndpointResource> GetAll(int? count = default(int?), string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearning.MachineLearningBatchEndpointResource> GetAllAsync(int? count = default(int?), string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningBatchEndpointResource>> GetAsync(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MachineLearning.MachineLearningBatchEndpointResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.MachineLearningBatchEndpointResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MachineLearning.MachineLearningBatchEndpointResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.MachineLearningBatchEndpointResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MachineLearningBatchEndpointData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public MachineLearningBatchEndpointData(Azure.Core.AzureLocation location, Azure.ResourceManager.MachineLearning.Models.MachineLearningBatchEndpointProperties properties) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningBatchEndpointProperties Properties { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningSku Sku { get { throw null; } set { } }
    }
    public partial class MachineLearningBatchEndpointResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MachineLearningBatchEndpointResource() { }
        public virtual Azure.ResourceManager.MachineLearning.MachineLearningBatchEndpointData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningBatchEndpointResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningBatchEndpointResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string endpointName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningBatchEndpointResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningBatchEndpointResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.Models.EndpointAuthKeys> GetKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.Models.EndpointAuthKeys>> GetKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningBatchDeploymentResource> GetMachineLearningBatchDeployment(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningBatchDeploymentResource>> GetMachineLearningBatchDeploymentAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearning.MachineLearningBatchDeploymentCollection GetMachineLearningBatchDeployments() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningBatchEndpointResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningBatchEndpointResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningBatchEndpointResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningBatchEndpointResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.MachineLearningBatchEndpointResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.Models.MachineLearningResourcePatchWithIdentity body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.MachineLearningBatchEndpointResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.Models.MachineLearningResourcePatchWithIdentity body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MachineLearningCodeContainerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.MachineLearningCodeContainerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.MachineLearningCodeContainerResource>, System.Collections.IEnumerable
    {
        protected MachineLearningCodeContainerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.MachineLearningCodeContainerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.MachineLearning.MachineLearningCodeContainerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.MachineLearningCodeContainerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.MachineLearning.MachineLearningCodeContainerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningCodeContainerResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearning.MachineLearningCodeContainerResource> GetAll(string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearning.MachineLearningCodeContainerResource> GetAllAsync(string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningCodeContainerResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MachineLearning.MachineLearningCodeContainerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.MachineLearningCodeContainerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MachineLearning.MachineLearningCodeContainerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.MachineLearningCodeContainerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MachineLearningCodeContainerData : Azure.ResourceManager.Models.ResourceData
    {
        public MachineLearningCodeContainerData(Azure.ResourceManager.MachineLearning.Models.MachineLearningCodeContainerProperties properties) { }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningCodeContainerProperties Properties { get { throw null; } set { } }
    }
    public partial class MachineLearningCodeContainerResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MachineLearningCodeContainerResource() { }
        public virtual Azure.ResourceManager.MachineLearning.MachineLearningCodeContainerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningCodeContainerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningCodeContainerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningCodeVersionResource> GetMachineLearningCodeVersion(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningCodeVersionResource>> GetMachineLearningCodeVersionAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearning.MachineLearningCodeVersionCollection GetMachineLearningCodeVersions() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.MachineLearningCodeContainerResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.MachineLearningCodeContainerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.MachineLearningCodeContainerResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.MachineLearningCodeContainerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MachineLearningCodeVersionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.MachineLearningCodeVersionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.MachineLearningCodeVersionResource>, System.Collections.IEnumerable
    {
        protected MachineLearningCodeVersionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.MachineLearningCodeVersionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string version, Azure.ResourceManager.MachineLearning.MachineLearningCodeVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.MachineLearningCodeVersionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string version, Azure.ResourceManager.MachineLearning.MachineLearningCodeVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningCodeVersionResource> Get(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearning.MachineLearningCodeVersionResource> GetAll(string orderBy = null, int? top = default(int?), string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearning.MachineLearningCodeVersionResource> GetAllAsync(string orderBy = null, int? top = default(int?), string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningCodeVersionResource>> GetAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MachineLearning.MachineLearningCodeVersionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.MachineLearningCodeVersionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MachineLearning.MachineLearningCodeVersionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.MachineLearningCodeVersionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MachineLearningCodeVersionData : Azure.ResourceManager.Models.ResourceData
    {
        public MachineLearningCodeVersionData(Azure.ResourceManager.MachineLearning.Models.MachineLearningCodeVersionProperties properties) { }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningCodeVersionProperties Properties { get { throw null; } set { } }
    }
    public partial class MachineLearningCodeVersionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MachineLearningCodeVersionResource() { }
        public virtual Azure.ResourceManager.MachineLearning.MachineLearningCodeVersionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string name, string version) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningCodeVersionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningCodeVersionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.MachineLearningCodeVersionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.MachineLearningCodeVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.MachineLearningCodeVersionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.MachineLearningCodeVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MachineLearningComponentContainerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.MachineLearningComponentContainerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.MachineLearningComponentContainerResource>, System.Collections.IEnumerable
    {
        protected MachineLearningComponentContainerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.MachineLearningComponentContainerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.MachineLearning.MachineLearningComponentContainerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.MachineLearningComponentContainerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.MachineLearning.MachineLearningComponentContainerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningComponentContainerResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearning.MachineLearningComponentContainerResource> GetAll(string skip = null, Azure.ResourceManager.MachineLearning.Models.ListViewType? listViewType = default(Azure.ResourceManager.MachineLearning.Models.ListViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearning.MachineLearningComponentContainerResource> GetAllAsync(string skip = null, Azure.ResourceManager.MachineLearning.Models.ListViewType? listViewType = default(Azure.ResourceManager.MachineLearning.Models.ListViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningComponentContainerResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MachineLearning.MachineLearningComponentContainerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.MachineLearningComponentContainerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MachineLearning.MachineLearningComponentContainerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.MachineLearningComponentContainerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MachineLearningComponentContainerData : Azure.ResourceManager.Models.ResourceData
    {
        public MachineLearningComponentContainerData(Azure.ResourceManager.MachineLearning.Models.MachineLearningComponentContainerProperties properties) { }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningComponentContainerProperties Properties { get { throw null; } set { } }
    }
    public partial class MachineLearningComponentContainerResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MachineLearningComponentContainerResource() { }
        public virtual Azure.ResourceManager.MachineLearning.MachineLearningComponentContainerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningComponentContainerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningComponentContainerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningComponentVersionResource> GetMachineLearningComponentVersion(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningComponentVersionResource>> GetMachineLearningComponentVersionAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearning.MachineLearningComponentVersionCollection GetMachineLearningComponentVersions() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.MachineLearningComponentContainerResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.MachineLearningComponentContainerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.MachineLearningComponentContainerResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.MachineLearningComponentContainerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MachineLearningComponentVersionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.MachineLearningComponentVersionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.MachineLearningComponentVersionResource>, System.Collections.IEnumerable
    {
        protected MachineLearningComponentVersionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.MachineLearningComponentVersionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string version, Azure.ResourceManager.MachineLearning.MachineLearningComponentVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.MachineLearningComponentVersionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string version, Azure.ResourceManager.MachineLearning.MachineLearningComponentVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningComponentVersionResource> Get(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearning.MachineLearningComponentVersionResource> GetAll(string orderBy = null, int? top = default(int?), string skip = null, Azure.ResourceManager.MachineLearning.Models.ListViewType? listViewType = default(Azure.ResourceManager.MachineLearning.Models.ListViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearning.MachineLearningComponentVersionResource> GetAllAsync(string orderBy = null, int? top = default(int?), string skip = null, Azure.ResourceManager.MachineLearning.Models.ListViewType? listViewType = default(Azure.ResourceManager.MachineLearning.Models.ListViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningComponentVersionResource>> GetAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MachineLearning.MachineLearningComponentVersionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.MachineLearningComponentVersionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MachineLearning.MachineLearningComponentVersionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.MachineLearningComponentVersionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MachineLearningComponentVersionData : Azure.ResourceManager.Models.ResourceData
    {
        public MachineLearningComponentVersionData(Azure.ResourceManager.MachineLearning.Models.MachineLearningComponentVersionProperties properties) { }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningComponentVersionProperties Properties { get { throw null; } set { } }
    }
    public partial class MachineLearningComponentVersionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MachineLearningComponentVersionResource() { }
        public virtual Azure.ResourceManager.MachineLearning.MachineLearningComponentVersionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string name, string version) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningComponentVersionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningComponentVersionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.MachineLearningComponentVersionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.MachineLearningComponentVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.MachineLearningComponentVersionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.MachineLearningComponentVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningComputeProperties Properties { get { throw null; } set { } }
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
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.Models.MachineLearningComputeSecrets> GetKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.Models.MachineLearningComputeSecrets>> GetKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class MachineLearningDataContainerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.MachineLearningDataContainerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.MachineLearningDataContainerResource>, System.Collections.IEnumerable
    {
        protected MachineLearningDataContainerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.MachineLearningDataContainerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.MachineLearning.MachineLearningDataContainerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.MachineLearningDataContainerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.MachineLearning.MachineLearningDataContainerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningDataContainerResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearning.MachineLearningDataContainerResource> GetAll(string skip = null, Azure.ResourceManager.MachineLearning.Models.ListViewType? listViewType = default(Azure.ResourceManager.MachineLearning.Models.ListViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearning.MachineLearningDataContainerResource> GetAllAsync(string skip = null, Azure.ResourceManager.MachineLearning.Models.ListViewType? listViewType = default(Azure.ResourceManager.MachineLearning.Models.ListViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningDataContainerResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MachineLearning.MachineLearningDataContainerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.MachineLearningDataContainerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MachineLearning.MachineLearningDataContainerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.MachineLearningDataContainerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MachineLearningDataContainerData : Azure.ResourceManager.Models.ResourceData
    {
        public MachineLearningDataContainerData(Azure.ResourceManager.MachineLearning.Models.MachineLearningDataContainerProperties properties) { }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningDataContainerProperties Properties { get { throw null; } set { } }
    }
    public partial class MachineLearningDataContainerResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MachineLearningDataContainerResource() { }
        public virtual Azure.ResourceManager.MachineLearning.MachineLearningDataContainerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningDataContainerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningDataContainerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningDataVersionResource> GetMachineLearningDataVersion(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningDataVersionResource>> GetMachineLearningDataVersionAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearning.MachineLearningDataVersionCollection GetMachineLearningDataVersions() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.MachineLearningDataContainerResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.MachineLearningDataContainerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.MachineLearningDataContainerResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.MachineLearningDataContainerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MachineLearningDatastoreCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.MachineLearningDatastoreResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.MachineLearningDatastoreResource>, System.Collections.IEnumerable
    {
        protected MachineLearningDatastoreCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.MachineLearningDatastoreResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.MachineLearning.MachineLearningDatastoreData data, bool? skipValidation = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.MachineLearningDatastoreResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.MachineLearning.MachineLearningDatastoreData data, bool? skipValidation = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningDatastoreResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearning.MachineLearningDatastoreResource> GetAll(string skip = null, int? count = default(int?), bool? isDefault = default(bool?), System.Collections.Generic.IEnumerable<string> names = null, string searchText = null, string orderBy = null, bool? orderByAsc = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearning.MachineLearningDatastoreResource> GetAllAsync(string skip = null, int? count = default(int?), bool? isDefault = default(bool?), System.Collections.Generic.IEnumerable<string> names = null, string searchText = null, string orderBy = null, bool? orderByAsc = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningDatastoreResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MachineLearning.MachineLearningDatastoreResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.MachineLearningDatastoreResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MachineLearning.MachineLearningDatastoreResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.MachineLearningDatastoreResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MachineLearningDatastoreData : Azure.ResourceManager.Models.ResourceData
    {
        public MachineLearningDatastoreData(Azure.ResourceManager.MachineLearning.Models.MachineLearningDatastoreProperties properties) { }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningDatastoreProperties Properties { get { throw null; } set { } }
    }
    public partial class MachineLearningDatastoreResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MachineLearningDatastoreResource() { }
        public virtual Azure.ResourceManager.MachineLearning.MachineLearningDatastoreData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningDatastoreResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningDatastoreResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.Models.MachineLearningDatastoreSecrets> GetSecrets(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.Models.MachineLearningDatastoreSecrets>> GetSecretsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.MachineLearningDatastoreResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.MachineLearningDatastoreData data, bool? skipValidation = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.MachineLearningDatastoreResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.MachineLearningDatastoreData data, bool? skipValidation = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MachineLearningDataVersionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.MachineLearningDataVersionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.MachineLearningDataVersionResource>, System.Collections.IEnumerable
    {
        protected MachineLearningDataVersionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.MachineLearningDataVersionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string version, Azure.ResourceManager.MachineLearning.MachineLearningDataVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.MachineLearningDataVersionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string version, Azure.ResourceManager.MachineLearning.MachineLearningDataVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningDataVersionResource> Get(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearning.MachineLearningDataVersionResource> GetAll(string orderBy = null, int? top = default(int?), string skip = null, string tags = null, Azure.ResourceManager.MachineLearning.Models.ListViewType? listViewType = default(Azure.ResourceManager.MachineLearning.Models.ListViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearning.MachineLearningDataVersionResource> GetAllAsync(string orderBy = null, int? top = default(int?), string skip = null, string tags = null, Azure.ResourceManager.MachineLearning.Models.ListViewType? listViewType = default(Azure.ResourceManager.MachineLearning.Models.ListViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningDataVersionResource>> GetAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MachineLearning.MachineLearningDataVersionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.MachineLearningDataVersionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MachineLearning.MachineLearningDataVersionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.MachineLearningDataVersionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MachineLearningDataVersionData : Azure.ResourceManager.Models.ResourceData
    {
        public MachineLearningDataVersionData(Azure.ResourceManager.MachineLearning.Models.MachineLearningDataVersionProperties properties) { }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningDataVersionProperties Properties { get { throw null; } set { } }
    }
    public partial class MachineLearningDataVersionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MachineLearningDataVersionResource() { }
        public virtual Azure.ResourceManager.MachineLearning.MachineLearningDataVersionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string name, string version) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningDataVersionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningDataVersionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.MachineLearningDataVersionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.MachineLearningDataVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.MachineLearningDataVersionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.MachineLearningDataVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MachineLearningEnvironmentContainerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.MachineLearningEnvironmentContainerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.MachineLearningEnvironmentContainerResource>, System.Collections.IEnumerable
    {
        protected MachineLearningEnvironmentContainerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.MachineLearningEnvironmentContainerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.MachineLearning.MachineLearningEnvironmentContainerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.MachineLearningEnvironmentContainerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.MachineLearning.MachineLearningEnvironmentContainerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningEnvironmentContainerResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearning.MachineLearningEnvironmentContainerResource> GetAll(string skip = null, Azure.ResourceManager.MachineLearning.Models.ListViewType? listViewType = default(Azure.ResourceManager.MachineLearning.Models.ListViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearning.MachineLearningEnvironmentContainerResource> GetAllAsync(string skip = null, Azure.ResourceManager.MachineLearning.Models.ListViewType? listViewType = default(Azure.ResourceManager.MachineLearning.Models.ListViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningEnvironmentContainerResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MachineLearning.MachineLearningEnvironmentContainerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.MachineLearningEnvironmentContainerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MachineLearning.MachineLearningEnvironmentContainerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.MachineLearningEnvironmentContainerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MachineLearningEnvironmentContainerData : Azure.ResourceManager.Models.ResourceData
    {
        public MachineLearningEnvironmentContainerData(Azure.ResourceManager.MachineLearning.Models.MachineLearningEnvironmentContainerProperties properties) { }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningEnvironmentContainerProperties Properties { get { throw null; } set { } }
    }
    public partial class MachineLearningEnvironmentContainerResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MachineLearningEnvironmentContainerResource() { }
        public virtual Azure.ResourceManager.MachineLearning.MachineLearningEnvironmentContainerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningEnvironmentContainerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningEnvironmentContainerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningEnvironmentVersionResource> GetMachineLearningEnvironmentVersion(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningEnvironmentVersionResource>> GetMachineLearningEnvironmentVersionAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearning.MachineLearningEnvironmentVersionCollection GetMachineLearningEnvironmentVersions() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.MachineLearningEnvironmentContainerResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.MachineLearningEnvironmentContainerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.MachineLearningEnvironmentContainerResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.MachineLearningEnvironmentContainerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MachineLearningEnvironmentVersionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.MachineLearningEnvironmentVersionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.MachineLearningEnvironmentVersionResource>, System.Collections.IEnumerable
    {
        protected MachineLearningEnvironmentVersionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.MachineLearningEnvironmentVersionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string version, Azure.ResourceManager.MachineLearning.MachineLearningEnvironmentVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.MachineLearningEnvironmentVersionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string version, Azure.ResourceManager.MachineLearning.MachineLearningEnvironmentVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningEnvironmentVersionResource> Get(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearning.MachineLearningEnvironmentVersionResource> GetAll(string orderBy = null, int? top = default(int?), string skip = null, Azure.ResourceManager.MachineLearning.Models.ListViewType? listViewType = default(Azure.ResourceManager.MachineLearning.Models.ListViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearning.MachineLearningEnvironmentVersionResource> GetAllAsync(string orderBy = null, int? top = default(int?), string skip = null, Azure.ResourceManager.MachineLearning.Models.ListViewType? listViewType = default(Azure.ResourceManager.MachineLearning.Models.ListViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningEnvironmentVersionResource>> GetAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MachineLearning.MachineLearningEnvironmentVersionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.MachineLearningEnvironmentVersionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MachineLearning.MachineLearningEnvironmentVersionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.MachineLearningEnvironmentVersionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MachineLearningEnvironmentVersionData : Azure.ResourceManager.Models.ResourceData
    {
        public MachineLearningEnvironmentVersionData(Azure.ResourceManager.MachineLearning.Models.MachineLearningEnvironmentVersionProperties properties) { }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningEnvironmentVersionProperties Properties { get { throw null; } set { } }
    }
    public partial class MachineLearningEnvironmentVersionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MachineLearningEnvironmentVersionResource() { }
        public virtual Azure.ResourceManager.MachineLearning.MachineLearningEnvironmentVersionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string name, string version) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningEnvironmentVersionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningEnvironmentVersionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.MachineLearningEnvironmentVersionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.MachineLearningEnvironmentVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.MachineLearningEnvironmentVersionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.MachineLearningEnvironmentVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class MachineLearningExtensions
    {
        public static Azure.ResourceManager.MachineLearning.MachineLearningBatchDeploymentResource GetMachineLearningBatchDeploymentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MachineLearning.MachineLearningBatchEndpointResource GetMachineLearningBatchEndpointResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MachineLearning.MachineLearningCodeContainerResource GetMachineLearningCodeContainerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MachineLearning.MachineLearningCodeVersionResource GetMachineLearningCodeVersionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MachineLearning.MachineLearningComponentContainerResource GetMachineLearningComponentContainerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MachineLearning.MachineLearningComponentVersionResource GetMachineLearningComponentVersionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MachineLearning.MachineLearningComputeResource GetMachineLearningComputeResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MachineLearning.MachineLearningDataContainerResource GetMachineLearningDataContainerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MachineLearning.MachineLearningDatastoreResource GetMachineLearningDatastoreResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MachineLearning.MachineLearningDataVersionResource GetMachineLearningDataVersionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MachineLearning.MachineLearningEnvironmentContainerResource GetMachineLearningEnvironmentContainerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MachineLearning.MachineLearningEnvironmentVersionResource GetMachineLearningEnvironmentVersionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MachineLearning.MachineLearningJobResource GetMachineLearningJobResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MachineLearning.MachineLearningModelContainerResource GetMachineLearningModelContainerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MachineLearning.MachineLearningModelVersionResource GetMachineLearningModelVersionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MachineLearning.MachineLearningOnlineDeploymentResource GetMachineLearningOnlineDeploymentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MachineLearning.MachineLearningOnlineEndpointResource GetMachineLearningOnlineEndpointResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MachineLearning.MachineLearningPrivateEndpointConnectionResource GetMachineLearningPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.MachineLearning.Models.MachineLearningResourceQuota> GetMachineLearningQuotas(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.MachineLearning.Models.MachineLearningResourceQuota> GetMachineLearningQuotasAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.MachineLearning.MachineLearningScheduleResource GetMachineLearningScheduleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.MachineLearning.Models.MachineLearningUsage> GetMachineLearningUsages(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.MachineLearning.Models.MachineLearningUsage> GetMachineLearningUsagesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.MachineLearning.Models.MachineLearningVmSize> GetMachineLearningVmSizes(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.MachineLearning.Models.MachineLearningVmSize> GetMachineLearningVmSizesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningWorkspaceResource> GetMachineLearningWorkspace(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningWorkspaceResource>> GetMachineLearningWorkspaceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.MachineLearning.MachineLearningWorkspaceConnectionResource GetMachineLearningWorkspaceConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MachineLearning.MachineLearningWorkspaceResource GetMachineLearningWorkspaceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MachineLearning.MachineLearningWorkspaceCollection GetMachineLearningWorkspaces(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.MachineLearning.MachineLearningWorkspaceResource> GetMachineLearningWorkspaces(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.MachineLearning.MachineLearningWorkspaceResource> GetMachineLearningWorkspacesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.MachineLearning.Models.MachineLearningWorkspaceQuotaUpdate> UpdateMachineLearningQuotas(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.MachineLearning.Models.MachineLearningQuotaUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.MachineLearning.Models.MachineLearningWorkspaceQuotaUpdate> UpdateMachineLearningQuotasAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.MachineLearning.Models.MachineLearningQuotaUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MachineLearningJobCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.MachineLearningJobResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.MachineLearningJobResource>, System.Collections.IEnumerable
    {
        protected MachineLearningJobCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.MachineLearningJobResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string id, Azure.ResourceManager.MachineLearning.MachineLearningJobData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.MachineLearningJobResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string id, Azure.ResourceManager.MachineLearning.MachineLearningJobData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningJobResource> Get(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearning.MachineLearningJobResource> GetAll(string skip = null, string jobType = null, string tag = null, Azure.ResourceManager.MachineLearning.Models.ListViewType? listViewType = default(Azure.ResourceManager.MachineLearning.Models.ListViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearning.MachineLearningJobResource> GetAllAsync(string skip = null, string jobType = null, string tag = null, Azure.ResourceManager.MachineLearning.Models.ListViewType? listViewType = default(Azure.ResourceManager.MachineLearning.Models.ListViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.ResourceManager.ArmOperation Cancel(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> CancelAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string id) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningJobResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningJobResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.MachineLearningJobResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.MachineLearningJobData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.MachineLearningJobResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.MachineLearningJobData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MachineLearningModelContainerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.MachineLearningModelContainerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.MachineLearningModelContainerResource>, System.Collections.IEnumerable
    {
        protected MachineLearningModelContainerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.MachineLearningModelContainerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.MachineLearning.MachineLearningModelContainerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.MachineLearningModelContainerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.MachineLearning.MachineLearningModelContainerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningModelContainerResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearning.MachineLearningModelContainerResource> GetAll(string skip = null, int? count = default(int?), Azure.ResourceManager.MachineLearning.Models.ListViewType? listViewType = default(Azure.ResourceManager.MachineLearning.Models.ListViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearning.MachineLearningModelContainerResource> GetAllAsync(string skip = null, int? count = default(int?), Azure.ResourceManager.MachineLearning.Models.ListViewType? listViewType = default(Azure.ResourceManager.MachineLearning.Models.ListViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningModelContainerResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MachineLearning.MachineLearningModelContainerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.MachineLearningModelContainerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MachineLearning.MachineLearningModelContainerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.MachineLearningModelContainerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MachineLearningModelContainerData : Azure.ResourceManager.Models.ResourceData
    {
        public MachineLearningModelContainerData(Azure.ResourceManager.MachineLearning.Models.MachineLearningModelContainerProperties properties) { }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningModelContainerProperties Properties { get { throw null; } set { } }
    }
    public partial class MachineLearningModelContainerResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MachineLearningModelContainerResource() { }
        public virtual Azure.ResourceManager.MachineLearning.MachineLearningModelContainerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningModelContainerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningModelContainerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningModelVersionResource> GetMachineLearningModelVersion(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningModelVersionResource>> GetMachineLearningModelVersionAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearning.MachineLearningModelVersionCollection GetMachineLearningModelVersions() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.MachineLearningModelContainerResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.MachineLearningModelContainerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.MachineLearningModelContainerResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.MachineLearningModelContainerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MachineLearningModelVersionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.MachineLearningModelVersionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.MachineLearningModelVersionResource>, System.Collections.IEnumerable
    {
        protected MachineLearningModelVersionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.MachineLearningModelVersionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string version, Azure.ResourceManager.MachineLearning.MachineLearningModelVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.MachineLearningModelVersionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string version, Azure.ResourceManager.MachineLearning.MachineLearningModelVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningModelVersionResource> Get(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearning.MachineLearningModelVersionResource> GetAll(string skip = null, string orderBy = null, int? top = default(int?), string version = null, string description = null, int? offset = default(int?), string tags = null, string properties = null, string feed = null, Azure.ResourceManager.MachineLearning.Models.ListViewType? listViewType = default(Azure.ResourceManager.MachineLearning.Models.ListViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearning.MachineLearningModelVersionResource> GetAllAsync(string skip = null, string orderBy = null, int? top = default(int?), string version = null, string description = null, int? offset = default(int?), string tags = null, string properties = null, string feed = null, Azure.ResourceManager.MachineLearning.Models.ListViewType? listViewType = default(Azure.ResourceManager.MachineLearning.Models.ListViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningModelVersionResource>> GetAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MachineLearning.MachineLearningModelVersionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.MachineLearningModelVersionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MachineLearning.MachineLearningModelVersionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.MachineLearningModelVersionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MachineLearningModelVersionData : Azure.ResourceManager.Models.ResourceData
    {
        public MachineLearningModelVersionData(Azure.ResourceManager.MachineLearning.Models.MachineLearningModelVersionProperties properties) { }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningModelVersionProperties Properties { get { throw null; } set { } }
    }
    public partial class MachineLearningModelVersionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MachineLearningModelVersionResource() { }
        public virtual Azure.ResourceManager.MachineLearning.MachineLearningModelVersionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string name, string version) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningModelVersionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningModelVersionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.MachineLearningModelVersionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.MachineLearningModelVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.MachineLearningModelVersionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.MachineLearningModelVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MachineLearningOnlineDeploymentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.MachineLearningOnlineDeploymentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.MachineLearningOnlineDeploymentResource>, System.Collections.IEnumerable
    {
        protected MachineLearningOnlineDeploymentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.MachineLearningOnlineDeploymentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string deploymentName, Azure.ResourceManager.MachineLearning.MachineLearningOnlineDeploymentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.MachineLearningOnlineDeploymentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string deploymentName, Azure.ResourceManager.MachineLearning.MachineLearningOnlineDeploymentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningOnlineDeploymentResource> Get(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearning.MachineLearningOnlineDeploymentResource> GetAll(string orderBy = null, int? top = default(int?), string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearning.MachineLearningOnlineDeploymentResource> GetAllAsync(string orderBy = null, int? top = default(int?), string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningOnlineDeploymentResource>> GetAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MachineLearning.MachineLearningOnlineDeploymentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.MachineLearningOnlineDeploymentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MachineLearning.MachineLearningOnlineDeploymentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.MachineLearningOnlineDeploymentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MachineLearningOnlineDeploymentData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public MachineLearningOnlineDeploymentData(Azure.Core.AzureLocation location, Azure.ResourceManager.MachineLearning.Models.MachineLearningOnlineDeploymentProperties properties) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningOnlineDeploymentProperties Properties { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningSku Sku { get { throw null; } set { } }
    }
    public partial class MachineLearningOnlineDeploymentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MachineLearningOnlineDeploymentResource() { }
        public virtual Azure.ResourceManager.MachineLearning.MachineLearningOnlineDeploymentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningOnlineDeploymentResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningOnlineDeploymentResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string endpointName, string deploymentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningOnlineDeploymentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningOnlineDeploymentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.Models.MachineLearningDeploymentLogs> GetLogs(Azure.ResourceManager.MachineLearning.Models.MachineLearningDeploymentLogsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.Models.MachineLearningDeploymentLogs>> GetLogsAsync(Azure.ResourceManager.MachineLearning.Models.MachineLearningDeploymentLogsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearning.Models.SkuResource> GetSkus(int? count = default(int?), string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearning.Models.SkuResource> GetSkusAsync(int? count = default(int?), string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningOnlineDeploymentResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningOnlineDeploymentResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningOnlineDeploymentResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningOnlineDeploymentResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.MachineLearningOnlineDeploymentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.Models.MachineLearningOnlineDeploymentPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.MachineLearningOnlineDeploymentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.Models.MachineLearningOnlineDeploymentPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MachineLearningOnlineEndpointCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.MachineLearningOnlineEndpointResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.MachineLearningOnlineEndpointResource>, System.Collections.IEnumerable
    {
        protected MachineLearningOnlineEndpointCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.MachineLearningOnlineEndpointResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string endpointName, Azure.ResourceManager.MachineLearning.MachineLearningOnlineEndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.MachineLearningOnlineEndpointResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string endpointName, Azure.ResourceManager.MachineLearning.MachineLearningOnlineEndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningOnlineEndpointResource> Get(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearning.MachineLearningOnlineEndpointResource> GetAll(string name = null, int? count = default(int?), Azure.ResourceManager.MachineLearning.Models.EndpointComputeType? computeType = default(Azure.ResourceManager.MachineLearning.Models.EndpointComputeType?), string skip = null, string tags = null, string properties = null, Azure.ResourceManager.MachineLearning.Models.OrderString? orderBy = default(Azure.ResourceManager.MachineLearning.Models.OrderString?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearning.MachineLearningOnlineEndpointResource> GetAllAsync(string name = null, int? count = default(int?), Azure.ResourceManager.MachineLearning.Models.EndpointComputeType? computeType = default(Azure.ResourceManager.MachineLearning.Models.EndpointComputeType?), string skip = null, string tags = null, string properties = null, Azure.ResourceManager.MachineLearning.Models.OrderString? orderBy = default(Azure.ResourceManager.MachineLearning.Models.OrderString?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningOnlineEndpointResource>> GetAsync(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MachineLearning.MachineLearningOnlineEndpointResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.MachineLearningOnlineEndpointResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MachineLearning.MachineLearningOnlineEndpointResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.MachineLearningOnlineEndpointResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MachineLearningOnlineEndpointData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public MachineLearningOnlineEndpointData(Azure.Core.AzureLocation location, Azure.ResourceManager.MachineLearning.Models.MachineLearningOnlineEndpointProperties properties) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningOnlineEndpointProperties Properties { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningSku Sku { get { throw null; } set { } }
    }
    public partial class MachineLearningOnlineEndpointResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MachineLearningOnlineEndpointResource() { }
        public virtual Azure.ResourceManager.MachineLearning.MachineLearningOnlineEndpointData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningOnlineEndpointResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningOnlineEndpointResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string endpointName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningOnlineEndpointResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningOnlineEndpointResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.Models.EndpointAuthKeys> GetKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.Models.EndpointAuthKeys>> GetKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningOnlineDeploymentResource> GetMachineLearningOnlineDeployment(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningOnlineDeploymentResource>> GetMachineLearningOnlineDeploymentAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearning.MachineLearningOnlineDeploymentCollection GetMachineLearningOnlineDeployments() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.Models.EndpointAuthToken> GetToken(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.Models.EndpointAuthToken>> GetTokenAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RegenerateKeys(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.Models.RegenerateEndpointKeysContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RegenerateKeysAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.Models.RegenerateEndpointKeysContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningOnlineEndpointResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningOnlineEndpointResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningOnlineEndpointResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningOnlineEndpointResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.MachineLearningOnlineEndpointResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.Models.MachineLearningResourcePatchWithIdentity body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.MachineLearningOnlineEndpointResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.Models.MachineLearningResourcePatchWithIdentity body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class MachineLearningScheduleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.MachineLearningScheduleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.MachineLearningScheduleResource>, System.Collections.IEnumerable
    {
        protected MachineLearningScheduleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.MachineLearningScheduleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.MachineLearning.MachineLearningScheduleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.MachineLearningScheduleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.MachineLearning.MachineLearningScheduleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningScheduleResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearning.MachineLearningScheduleResource> GetAll(string skip = null, Azure.ResourceManager.MachineLearning.Models.ScheduleListViewType? listViewType = default(Azure.ResourceManager.MachineLearning.Models.ScheduleListViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearning.MachineLearningScheduleResource> GetAllAsync(string skip = null, Azure.ResourceManager.MachineLearning.Models.ScheduleListViewType? listViewType = default(Azure.ResourceManager.MachineLearning.Models.ScheduleListViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningScheduleResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MachineLearning.MachineLearningScheduleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.MachineLearningScheduleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MachineLearning.MachineLearningScheduleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.MachineLearningScheduleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MachineLearningScheduleData : Azure.ResourceManager.Models.ResourceData
    {
        public MachineLearningScheduleData(Azure.ResourceManager.MachineLearning.Models.MachineLearningScheduleProperties properties) { }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningScheduleProperties Properties { get { throw null; } set { } }
    }
    public partial class MachineLearningScheduleResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MachineLearningScheduleResource() { }
        public virtual Azure.ResourceManager.MachineLearning.MachineLearningScheduleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningScheduleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningScheduleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.MachineLearningScheduleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.MachineLearningScheduleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.MachineLearningScheduleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.MachineLearningScheduleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class MachineLearningWorkspaceConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.MachineLearningWorkspaceConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.MachineLearningWorkspaceConnectionResource>, System.Collections.IEnumerable
    {
        protected MachineLearningWorkspaceConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.MachineLearningWorkspaceConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string connectionName, Azure.ResourceManager.MachineLearning.MachineLearningWorkspaceConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.MachineLearningWorkspaceConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string connectionName, Azure.ResourceManager.MachineLearning.MachineLearningWorkspaceConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string connectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string connectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningWorkspaceConnectionResource> Get(string connectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearning.MachineLearningWorkspaceConnectionResource> GetAll(string target = null, string category = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearning.MachineLearningWorkspaceConnectionResource> GetAllAsync(string target = null, string category = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningWorkspaceConnectionResource>> GetAsync(string connectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MachineLearning.MachineLearningWorkspaceConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearning.MachineLearningWorkspaceConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MachineLearning.MachineLearningWorkspaceConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearning.MachineLearningWorkspaceConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MachineLearningWorkspaceConnectionData : Azure.ResourceManager.Models.ResourceData
    {
        public MachineLearningWorkspaceConnectionData(Azure.ResourceManager.MachineLearning.Models.MachineLearningWorkspaceConnectionProperties properties) { }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningWorkspaceConnectionProperties Properties { get { throw null; } set { } }
    }
    public partial class MachineLearningWorkspaceConnectionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MachineLearningWorkspaceConnectionResource() { }
        public virtual Azure.ResourceManager.MachineLearning.MachineLearningWorkspaceConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string connectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningWorkspaceConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningWorkspaceConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.MachineLearningWorkspaceConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.MachineLearningWorkspaceConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.MachineLearningWorkspaceConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.MachineLearningWorkspaceConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningEncryptionSetting Encryption { get { throw null; } set { } }
        public string FriendlyName { get { throw null; } set { } }
        public bool? HbiWorkspace { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public string ImageBuildCompute { get { throw null; } set { } }
        public bool? IsStorageHnsEnabled { get { throw null; } }
        public bool? IsV1LegacyMode { get { throw null; } set { } }
        public string KeyVault { get { throw null; } set { } }
        public System.Uri MlFlowTrackingUri { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningNotebookResourceInfo NotebookInfo { get { throw null; } }
        public string PrimaryUserAssignedIdentity { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearning.MachineLearningPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public int? PrivateLinkCount { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public string ServiceProvisionedResourceGroup { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.MachineLearning.Models.MachineLearningSharedPrivateLinkResource> SharedPrivateLinkResources { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningSku Sku { get { throw null; } set { } }
        public string StorageAccount { get { throw null; } set { } }
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
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.Models.MachineLearningWorkspaceDiagnoseResult> Diagnose(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.Models.MachineLearningWorkspaceDiagnoseContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.Models.MachineLearningWorkspaceDiagnoseResult>> DiagnoseAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.Models.MachineLearningWorkspaceDiagnoseContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningWorkspaceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningWorkspaceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.Models.MachineLearningWorkspaceGetKeysResult> GetKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.Models.MachineLearningWorkspaceGetKeysResult>> GetKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningBatchEndpointResource> GetMachineLearningBatchEndpoint(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningBatchEndpointResource>> GetMachineLearningBatchEndpointAsync(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearning.MachineLearningBatchEndpointCollection GetMachineLearningBatchEndpoints() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningCodeContainerResource> GetMachineLearningCodeContainer(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningCodeContainerResource>> GetMachineLearningCodeContainerAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearning.MachineLearningCodeContainerCollection GetMachineLearningCodeContainers() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningComponentContainerResource> GetMachineLearningComponentContainer(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningComponentContainerResource>> GetMachineLearningComponentContainerAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearning.MachineLearningComponentContainerCollection GetMachineLearningComponentContainers() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningComputeResource> GetMachineLearningCompute(string computeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningComputeResource>> GetMachineLearningComputeAsync(string computeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearning.MachineLearningComputeCollection GetMachineLearningComputes() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningDataContainerResource> GetMachineLearningDataContainer(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningDataContainerResource>> GetMachineLearningDataContainerAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearning.MachineLearningDataContainerCollection GetMachineLearningDataContainers() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningDatastoreResource> GetMachineLearningDatastore(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningDatastoreResource>> GetMachineLearningDatastoreAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearning.MachineLearningDatastoreCollection GetMachineLearningDatastores() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningEnvironmentContainerResource> GetMachineLearningEnvironmentContainer(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningEnvironmentContainerResource>> GetMachineLearningEnvironmentContainerAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearning.MachineLearningEnvironmentContainerCollection GetMachineLearningEnvironmentContainers() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningJobResource> GetMachineLearningJob(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningJobResource>> GetMachineLearningJobAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearning.MachineLearningJobCollection GetMachineLearningJobs() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningModelContainerResource> GetMachineLearningModelContainer(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningModelContainerResource>> GetMachineLearningModelContainerAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearning.MachineLearningModelContainerCollection GetMachineLearningModelContainers() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningOnlineEndpointResource> GetMachineLearningOnlineEndpoint(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningOnlineEndpointResource>> GetMachineLearningOnlineEndpointAsync(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearning.MachineLearningOnlineEndpointCollection GetMachineLearningOnlineEndpoints() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningPrivateEndpointConnectionResource> GetMachineLearningPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningPrivateEndpointConnectionResource>> GetMachineLearningPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearning.MachineLearningPrivateEndpointConnectionCollection GetMachineLearningPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningScheduleResource> GetMachineLearningSchedule(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningScheduleResource>> GetMachineLearningScheduleAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearning.MachineLearningScheduleCollection GetMachineLearningSchedules() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningWorkspaceConnectionResource> GetMachineLearningWorkspaceConnection(string connectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningWorkspaceConnectionResource>> GetMachineLearningWorkspaceConnectionAsync(string connectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearning.MachineLearningWorkspaceConnectionCollection GetMachineLearningWorkspaceConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.Models.MachineLearningWorkspaceNotebookAccessTokenResult> GetNotebookAccessToken(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.Models.MachineLearningWorkspaceNotebookAccessTokenResult>> GetNotebookAccessTokenAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.Models.MachineLearningWorkspaceGetNotebookKeysResult> GetNotebookKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.Models.MachineLearningWorkspaceGetNotebookKeysResult>> GetNotebookKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearning.Models.MachineLearningFqdnEndpoints> GetOutboundNetworkDependenciesEndpoints(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearning.Models.MachineLearningFqdnEndpoints> GetOutboundNetworkDependenciesEndpointsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearning.Models.MachineLearningPrivateLinkResource> GetPrivateLinkResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearning.Models.MachineLearningPrivateLinkResource> GetPrivateLinkResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.Models.MachineLearningWorkspaceGetStorageAccountKeysResult> GetStorageAccountKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.Models.MachineLearningWorkspaceGetStorageAccountKeysResult>> GetStorageAccountKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearning.Models.MachineLearningUserFeature> GetWorkspaceFeatures(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearning.Models.MachineLearningUserFeature> GetWorkspaceFeaturesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.Models.MachineLearningNotebookResourceInfo> PrepareNotebook(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.Models.MachineLearningNotebookResourceInfo>> PrepareNotebookAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningWorkspaceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningWorkspaceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ResyncKeys(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ResyncKeysAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningWorkspaceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningWorkspaceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.MachineLearningWorkspaceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.Models.MachineLearningWorkspacePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MachineLearning.MachineLearningWorkspaceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.Models.MachineLearningWorkspacePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.MachineLearning.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AmlAllocationState : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.AmlAllocationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AmlAllocationState(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.AmlAllocationState Resizing { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.AmlAllocationState Steady { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.AmlAllocationState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.AmlAllocationState left, Azure.ResourceManager.MachineLearning.Models.AmlAllocationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.AmlAllocationState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.AmlAllocationState left, Azure.ResourceManager.MachineLearning.Models.AmlAllocationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AmlCompute : Azure.ResourceManager.MachineLearning.Models.MachineLearningComputeProperties
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
        public Azure.ResourceManager.MachineLearning.Models.AmlAllocationState? AllocationState { get { throw null; } }
        public System.DateTimeOffset? AllocationStateTransitionOn { get { throw null; } }
        public int? CurrentNodeCount { get { throw null; } }
        public bool? EnableNodePublicIP { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearning.Models.ErrorResponse> Errors { get { throw null; } }
        public bool? IsolatedNetwork { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.NodeStateCounts NodeStateCounts { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.OSType? OSType { get { throw null; } set { } }
        public System.BinaryData PropertyBag { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.RemoteLoginPortPublicAccess? RemoteLoginPortPublicAccess { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ScaleSettings ScaleSettings { get { throw null; } set { } }
        public string SubnetId { get { throw null; } set { } }
        public int? TargetNodeCount { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.UserAccountCredentials UserAccountCredentials { get { throw null; } set { } }
        public string VirtualMachineImageId { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.VmPriority? VmPriority { get { throw null; } set { } }
        public string VmSize { get { throw null; } set { } }
    }
    public partial class AmlToken : Azure.ResourceManager.MachineLearning.Models.MachineLearningIdentityConfiguration
    {
        public AmlToken() { }
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
        public Azure.ResourceManager.MachineLearning.Models.JobResourceConfiguration Resources { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.AutoMLVertical TaskDetails { get { throw null; } set { } }
    }
    public abstract partial class AutoMLVertical
    {
        protected AutoMLVertical(Azure.ResourceManager.MachineLearning.Models.MLTableJobInput trainingData) { }
        public Azure.ResourceManager.MachineLearning.Models.LogVerbosity? LogVerbosity { get { throw null; } set { } }
        public string TargetColumnName { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MLTableJobInput TrainingData { get { throw null; } set { } }
    }
    public partial class AutoNCrossValidations : Azure.ResourceManager.MachineLearning.Models.NCrossValidations
    {
        public AutoNCrossValidations() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AutoRebuildSetting : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.AutoRebuildSetting>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AutoRebuildSetting(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.AutoRebuildSetting Disabled { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.AutoRebuildSetting OnBaseImageUpdate { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.AutoRebuildSetting other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.AutoRebuildSetting left, Azure.ResourceManager.MachineLearning.Models.AutoRebuildSetting right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.AutoRebuildSetting (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.AutoRebuildSetting left, Azure.ResourceManager.MachineLearning.Models.AutoRebuildSetting right) { throw null; }
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
    public partial class AzureBlobDatastore : Azure.ResourceManager.MachineLearning.Models.MachineLearningDatastoreProperties
    {
        public AzureBlobDatastore(Azure.ResourceManager.MachineLearning.Models.MachineLearningDatastoreCredentials credentials) : base (default(Azure.ResourceManager.MachineLearning.Models.MachineLearningDatastoreCredentials)) { }
        public string AccountName { get { throw null; } set { } }
        public string ContainerName { get { throw null; } set { } }
        public string Endpoint { get { throw null; } set { } }
        public string Protocol { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ServiceDataAccessAuthIdentity? ServiceDataAccessAuthIdentity { get { throw null; } set { } }
    }
    public partial class AzureDataLakeGen1Datastore : Azure.ResourceManager.MachineLearning.Models.MachineLearningDatastoreProperties
    {
        public AzureDataLakeGen1Datastore(Azure.ResourceManager.MachineLearning.Models.MachineLearningDatastoreCredentials credentials, string storeName) : base (default(Azure.ResourceManager.MachineLearning.Models.MachineLearningDatastoreCredentials)) { }
        public Azure.ResourceManager.MachineLearning.Models.ServiceDataAccessAuthIdentity? ServiceDataAccessAuthIdentity { get { throw null; } set { } }
        public string StoreName { get { throw null; } set { } }
    }
    public partial class AzureDataLakeGen2Datastore : Azure.ResourceManager.MachineLearning.Models.MachineLearningDatastoreProperties
    {
        public AzureDataLakeGen2Datastore(Azure.ResourceManager.MachineLearning.Models.MachineLearningDatastoreCredentials credentials, string accountName, string filesystem) : base (default(Azure.ResourceManager.MachineLearning.Models.MachineLearningDatastoreCredentials)) { }
        public string AccountName { get { throw null; } set { } }
        public string Endpoint { get { throw null; } set { } }
        public string Filesystem { get { throw null; } set { } }
        public string Protocol { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ServiceDataAccessAuthIdentity? ServiceDataAccessAuthIdentity { get { throw null; } set { } }
    }
    public partial class AzureFileDatastore : Azure.ResourceManager.MachineLearning.Models.MachineLearningDatastoreProperties
    {
        public AzureFileDatastore(Azure.ResourceManager.MachineLearning.Models.MachineLearningDatastoreCredentials credentials, string accountName, string fileShareName) : base (default(Azure.ResourceManager.MachineLearning.Models.MachineLearningDatastoreCredentials)) { }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BlockedTransformer : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.BlockedTransformer>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BlockedTransformer(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.BlockedTransformer CatTargetEncoder { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.BlockedTransformer CountVectorizer { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.BlockedTransformer HashOneHotEncoder { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.BlockedTransformer LabelEncoder { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.BlockedTransformer NaiveBayes { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.BlockedTransformer OneHotEncoder { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.BlockedTransformer TextTargetEncoder { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.BlockedTransformer TfIdf { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.BlockedTransformer WoETargetEncoder { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.BlockedTransformer WordEmbedding { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.BlockedTransformer other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.BlockedTransformer left, Azure.ResourceManager.MachineLearning.Models.BlockedTransformer right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.BlockedTransformer (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.BlockedTransformer left, Azure.ResourceManager.MachineLearning.Models.BlockedTransformer right) { throw null; }
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
    public partial class Classification : Azure.ResourceManager.MachineLearning.Models.AutoMLVertical
    {
        public Classification(Azure.ResourceManager.MachineLearning.Models.MLTableJobInput trainingData) : base (default(Azure.ResourceManager.MachineLearning.Models.MLTableJobInput)) { }
        public System.Collections.Generic.IList<string> CvSplitColumnNames { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.TableVerticalFeaturizationSettings FeaturizationSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.TableVerticalLimitSettings LimitSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.NCrossValidations NCrossValidations { get { throw null; } set { } }
        public string PositiveLabel { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ClassificationPrimaryMetric? PrimaryMetric { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MLTableJobInput TestData { get { throw null; } set { } }
        public double? TestDataSize { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ClassificationTrainingSettings TrainingSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MLTableJobInput ValidationData { get { throw null; } set { } }
        public double? ValidationDataSize { get { throw null; } set { } }
        public string WeightColumnName { get { throw null; } set { } }
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
    public partial class ClassificationTrainingSettings : Azure.ResourceManager.MachineLearning.Models.TrainingSettings
    {
        public ClassificationTrainingSettings() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.MachineLearning.Models.ClassificationModel> AllowedTrainingAlgorithms { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.MachineLearning.Models.ClassificationModel> BlockedTrainingAlgorithms { get { throw null; } set { } }
    }
    public partial class CodeConfiguration
    {
        public CodeConfiguration(string scoringScript) { }
        public string CodeId { get { throw null; } set { } }
        public string ScoringScript { get { throw null; } set { } }
    }
    public partial class ColumnTransformer
    {
        public ColumnTransformer() { }
        public System.Collections.Generic.IList<string> Fields { get { throw null; } set { } }
        public System.BinaryData Parameters { get { throw null; } set { } }
    }
    public partial class CommandJobLimits : Azure.ResourceManager.MachineLearning.Models.JobLimits
    {
        public CommandJobLimits() { }
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
    public partial class CronTrigger : Azure.ResourceManager.MachineLearning.Models.TriggerBase
    {
        public CronTrigger(string expression) { }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataType : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.DataType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.DataType Mltable { get { throw null; } }
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
    public partial class DefaultScaleSettings : Azure.ResourceManager.MachineLearning.Models.OnlineScaleSettings
    {
        public DefaultScaleSettings() { }
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
    public partial class DeploymentResourceConfiguration : Azure.ResourceManager.MachineLearning.Models.ResourceConfiguration
    {
        public DeploymentResourceConfiguration() { }
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
    public partial class EndpointScheduleAction : Azure.ResourceManager.MachineLearning.Models.ScheduleActionBase
    {
        public EndpointScheduleAction(System.BinaryData endpointInvocationDefinition) { }
        public System.BinaryData EndpointInvocationDefinition { get { throw null; } set { } }
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
        public Forecasting(Azure.ResourceManager.MachineLearning.Models.MLTableJobInput trainingData) : base (default(Azure.ResourceManager.MachineLearning.Models.MLTableJobInput)) { }
        public System.Collections.Generic.IList<string> CvSplitColumnNames { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.TableVerticalFeaturizationSettings FeaturizationSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ForecastingSettings ForecastingSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.TableVerticalLimitSettings LimitSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.NCrossValidations NCrossValidations { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ForecastingPrimaryMetric? PrimaryMetric { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MLTableJobInput TestData { get { throw null; } set { } }
        public double? TestDataSize { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ForecastingTrainingSettings TrainingSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MLTableJobInput ValidationData { get { throw null; } set { } }
        public double? ValidationDataSize { get { throw null; } set { } }
        public string WeightColumnName { get { throw null; } set { } }
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
    public partial class ForecastingTrainingSettings : Azure.ResourceManager.MachineLearning.Models.TrainingSettings
    {
        public ForecastingTrainingSettings() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.MachineLearning.Models.ForecastingModel> AllowedTrainingAlgorithms { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.MachineLearning.Models.ForecastingModel> BlockedTrainingAlgorithms { get { throw null; } set { } }
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
    public partial class ImageClassification : Azure.ResourceManager.MachineLearning.Models.AutoMLVertical
    {
        public ImageClassification(Azure.ResourceManager.MachineLearning.Models.MLTableJobInput trainingData, Azure.ResourceManager.MachineLearning.Models.ImageLimitSettings limitSettings) : base (default(Azure.ResourceManager.MachineLearning.Models.MLTableJobInput)) { }
        public Azure.ResourceManager.MachineLearning.Models.ImageLimitSettings LimitSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ImageModelSettingsClassification ModelSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ClassificationPrimaryMetric? PrimaryMetric { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.MachineLearning.Models.ImageModelDistributionSettingsClassification> SearchSpace { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ImageSweepSettings SweepSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MLTableJobInput ValidationData { get { throw null; } set { } }
        public double? ValidationDataSize { get { throw null; } set { } }
    }
    public partial class ImageClassificationMultilabel : Azure.ResourceManager.MachineLearning.Models.AutoMLVertical
    {
        public ImageClassificationMultilabel(Azure.ResourceManager.MachineLearning.Models.MLTableJobInput trainingData, Azure.ResourceManager.MachineLearning.Models.ImageLimitSettings limitSettings) : base (default(Azure.ResourceManager.MachineLearning.Models.MLTableJobInput)) { }
        public Azure.ResourceManager.MachineLearning.Models.ImageLimitSettings LimitSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ImageModelSettingsClassification ModelSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ClassificationMultilabelPrimaryMetric? PrimaryMetric { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.MachineLearning.Models.ImageModelDistributionSettingsClassification> SearchSpace { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ImageSweepSettings SweepSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MLTableJobInput ValidationData { get { throw null; } set { } }
        public double? ValidationDataSize { get { throw null; } set { } }
    }
    public partial class ImageInstanceSegmentation : Azure.ResourceManager.MachineLearning.Models.AutoMLVertical
    {
        public ImageInstanceSegmentation(Azure.ResourceManager.MachineLearning.Models.MLTableJobInput trainingData, Azure.ResourceManager.MachineLearning.Models.ImageLimitSettings limitSettings) : base (default(Azure.ResourceManager.MachineLearning.Models.MLTableJobInput)) { }
        public Azure.ResourceManager.MachineLearning.Models.ImageLimitSettings LimitSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ImageModelSettingsObjectDetection ModelSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.InstanceSegmentationPrimaryMetric? PrimaryMetric { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.MachineLearning.Models.ImageModelDistributionSettingsObjectDetection> SearchSpace { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ImageSweepSettings SweepSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MLTableJobInput ValidationData { get { throw null; } set { } }
        public double? ValidationDataSize { get { throw null; } set { } }
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
        public int? CheckpointFrequency { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MLFlowModelJobInput CheckpointModel { get { throw null; } set { } }
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
        public ImageObjectDetection(Azure.ResourceManager.MachineLearning.Models.MLTableJobInput trainingData, Azure.ResourceManager.MachineLearning.Models.ImageLimitSettings limitSettings) : base (default(Azure.ResourceManager.MachineLearning.Models.MLTableJobInput)) { }
        public Azure.ResourceManager.MachineLearning.Models.ImageLimitSettings LimitSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ImageModelSettingsObjectDetection ModelSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ObjectDetectionPrimaryMetric? PrimaryMetric { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.MachineLearning.Models.ImageModelDistributionSettingsObjectDetection> SearchSpace { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ImageSweepSettings SweepSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MLTableJobInput ValidationData { get { throw null; } set { } }
        public double? ValidationDataSize { get { throw null; } set { } }
    }
    public partial class ImageSweepSettings
    {
        public ImageSweepSettings(Azure.ResourceManager.MachineLearning.Models.SamplingAlgorithmType samplingAlgorithm) { }
        public Azure.ResourceManager.MachineLearning.Models.EarlyTerminationPolicy EarlyTermination { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.SamplingAlgorithmType SamplingAlgorithm { get { throw null; } set { } }
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
        public System.Collections.Generic.IDictionary<string, string> NodeSelector { get { throw null; } set { } }
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
    public partial class JobResourceConfiguration : Azure.ResourceManager.MachineLearning.Models.ResourceConfiguration
    {
        public JobResourceConfiguration() { }
        public string DockerArgs { get { throw null; } set { } }
        public string ShmSize { get { throw null; } set { } }
    }
    public partial class JobScheduleAction : Azure.ResourceManager.MachineLearning.Models.ScheduleActionBase
    {
        public JobScheduleAction(Azure.ResourceManager.MachineLearning.Models.MachineLearningJobProperties jobDefinition) { }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningJobProperties JobDefinition { get { throw null; } set { } }
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
    public partial class KubernetesOnlineDeployment : Azure.ResourceManager.MachineLearning.Models.MachineLearningOnlineDeploymentProperties
    {
        public KubernetesOnlineDeployment() { }
        public Azure.ResourceManager.MachineLearning.Models.ContainerResourceRequirements ContainerResourceRequirements { get { throw null; } set { } }
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
    public partial class LiteralJobInput : Azure.ResourceManager.MachineLearning.Models.JobInput
    {
        public LiteralJobInput(string value) { }
        public string Value { get { throw null; } set { } }
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
    public partial class MachineLearningAccountKeyDatastoreCredentials : Azure.ResourceManager.MachineLearning.Models.MachineLearningDatastoreCredentials
    {
        public MachineLearningAccountKeyDatastoreCredentials(Azure.ResourceManager.MachineLearning.Models.MachineLearningAccountKeyDatastoreSecrets secrets) { }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningAccountKeyDatastoreSecrets Secrets { get { throw null; } set { } }
    }
    public partial class MachineLearningAccountKeyDatastoreSecrets : Azure.ResourceManager.MachineLearning.Models.MachineLearningDatastoreSecrets
    {
        public MachineLearningAccountKeyDatastoreSecrets() { }
        public string Key { get { throw null; } set { } }
    }
    public partial class MachineLearningAksCompute : Azure.ResourceManager.MachineLearning.Models.MachineLearningComputeProperties
    {
        public MachineLearningAksCompute() { }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningAksComputeProperties Properties { get { throw null; } set { } }
    }
    public partial class MachineLearningAksComputeProperties
    {
        public MachineLearningAksComputeProperties() { }
        public int? AgentCount { get { throw null; } set { } }
        public string AgentVmSize { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningAksNetworkingConfiguration AksNetworkingConfiguration { get { throw null; } set { } }
        public string ClusterFqdn { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningClusterPurpose? ClusterPurpose { get { throw null; } set { } }
        public string LoadBalancerSubnet { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningLoadBalancerType? LoadBalancerType { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningSslConfiguration SslConfiguration { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearning.Models.MachineLearningComputeSystemService> SystemServices { get { throw null; } }
    }
    public partial class MachineLearningAksComputeSecrets : Azure.ResourceManager.MachineLearning.Models.MachineLearningComputeSecrets
    {
        internal MachineLearningAksComputeSecrets() { }
        public string AdminKubeConfig { get { throw null; } }
        public string ImagePullSecretName { get { throw null; } }
        public string UserKubeConfig { get { throw null; } }
    }
    public partial class MachineLearningAksNetworkingConfiguration
    {
        public MachineLearningAksNetworkingConfiguration() { }
        public string DnsServiceIP { get { throw null; } set { } }
        public string DockerBridgeCidr { get { throw null; } set { } }
        public string ServiceCidr { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MachineLearningApplicationSharingPolicy : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.MachineLearningApplicationSharingPolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MachineLearningApplicationSharingPolicy(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningApplicationSharingPolicy Personal { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningApplicationSharingPolicy Shared { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.MachineLearningApplicationSharingPolicy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.MachineLearningApplicationSharingPolicy left, Azure.ResourceManager.MachineLearning.Models.MachineLearningApplicationSharingPolicy right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.MachineLearningApplicationSharingPolicy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.MachineLearningApplicationSharingPolicy left, Azure.ResourceManager.MachineLearning.Models.MachineLearningApplicationSharingPolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MachineLearningAssetBase : Azure.ResourceManager.MachineLearning.Models.MachineLearningResourceBase
    {
        public MachineLearningAssetBase() { }
        public bool? IsAnonymous { get { throw null; } set { } }
        public bool? IsArchived { get { throw null; } set { } }
    }
    public partial class MachineLearningAssetContainer : Azure.ResourceManager.MachineLearning.Models.MachineLearningResourceBase
    {
        public MachineLearningAssetContainer() { }
        public bool? IsArchived { get { throw null; } set { } }
        public string LatestVersion { get { throw null; } }
        public string NextVersion { get { throw null; } }
    }
    public abstract partial class MachineLearningAssetReferenceBase
    {
        protected MachineLearningAssetReferenceBase() { }
    }
    public partial class MachineLearningAutoPauseProperties
    {
        public MachineLearningAutoPauseProperties() { }
        public int? DelayInMinutes { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
    }
    public partial class MachineLearningBatchDeploymentPatch
    {
        public MachineLearningBatchDeploymentPatch() { }
        public string PartialBatchDeploymentDescription { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class MachineLearningBatchDeploymentProperties : Azure.ResourceManager.MachineLearning.Models.EndpointDeploymentPropertiesBase
    {
        public MachineLearningBatchDeploymentProperties() { }
        public string Compute { get { throw null; } set { } }
        public int? ErrorThreshold { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.BatchLoggingLevel? LoggingLevel { get { throw null; } set { } }
        public int? MaxConcurrencyPerInstance { get { throw null; } set { } }
        public long? MiniBatchSize { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningAssetReferenceBase Model { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.BatchOutputAction? OutputAction { get { throw null; } set { } }
        public string OutputFileName { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.DeploymentProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.DeploymentResourceConfiguration Resources { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.BatchRetrySettings RetrySettings { get { throw null; } set { } }
    }
    public partial class MachineLearningBatchEndpointProperties : Azure.ResourceManager.MachineLearning.Models.EndpointPropertiesBase
    {
        public MachineLearningBatchEndpointProperties(Azure.ResourceManager.MachineLearning.Models.EndpointAuthMode authMode) : base (default(Azure.ResourceManager.MachineLearning.Models.EndpointAuthMode)) { }
        public string DefaultsDeploymentName { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.EndpointProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class MachineLearningCertificateDatastoreCredentials : Azure.ResourceManager.MachineLearning.Models.MachineLearningDatastoreCredentials
    {
        public MachineLearningCertificateDatastoreCredentials(System.Guid clientId, Azure.ResourceManager.MachineLearning.Models.MachineLearningCertificateDatastoreSecrets secrets, System.Guid tenantId, string thumbprint) { }
        public System.Uri AuthorityUri { get { throw null; } set { } }
        public System.Guid ClientId { get { throw null; } set { } }
        public System.Uri ResourceUri { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningCertificateDatastoreSecrets Secrets { get { throw null; } set { } }
        public System.Guid TenantId { get { throw null; } set { } }
        public string Thumbprint { get { throw null; } set { } }
    }
    public partial class MachineLearningCertificateDatastoreSecrets : Azure.ResourceManager.MachineLearning.Models.MachineLearningDatastoreSecrets
    {
        public MachineLearningCertificateDatastoreSecrets() { }
        public string Certificate { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MachineLearningClusterPurpose : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.MachineLearningClusterPurpose>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MachineLearningClusterPurpose(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningClusterPurpose DenseProd { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningClusterPurpose DevTest { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningClusterPurpose FastProd { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.MachineLearningClusterPurpose other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.MachineLearningClusterPurpose left, Azure.ResourceManager.MachineLearning.Models.MachineLearningClusterPurpose right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.MachineLearningClusterPurpose (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.MachineLearningClusterPurpose left, Azure.ResourceManager.MachineLearning.Models.MachineLearningClusterPurpose right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MachineLearningCodeContainerProperties : Azure.ResourceManager.MachineLearning.Models.MachineLearningAssetContainer
    {
        public MachineLearningCodeContainerProperties() { }
    }
    public partial class MachineLearningCodeVersionProperties : Azure.ResourceManager.MachineLearning.Models.MachineLearningAssetBase
    {
        public MachineLearningCodeVersionProperties() { }
        public System.Uri CodeUri { get { throw null; } set { } }
    }
    public partial class MachineLearningCommandJob : Azure.ResourceManager.MachineLearning.Models.MachineLearningJobProperties
    {
        public MachineLearningCommandJob(string command, string environmentId) { }
        public string CodeId { get { throw null; } set { } }
        public string Command { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.DistributionConfiguration Distribution { get { throw null; } set { } }
        public string EnvironmentId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> EnvironmentVariables { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.MachineLearning.Models.JobInput> Inputs { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.CommandJobLimits Limits { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.MachineLearning.Models.JobOutput> Outputs { get { throw null; } set { } }
        public System.BinaryData Parameters { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.JobResourceConfiguration Resources { get { throw null; } set { } }
    }
    public partial class MachineLearningComponentContainerProperties : Azure.ResourceManager.MachineLearning.Models.MachineLearningAssetContainer
    {
        public MachineLearningComponentContainerProperties() { }
    }
    public partial class MachineLearningComponentVersionProperties : Azure.ResourceManager.MachineLearning.Models.MachineLearningAssetBase
    {
        public MachineLearningComponentVersionProperties() { }
        public System.BinaryData ComponentSpec { get { throw null; } set { } }
    }
    public partial class MachineLearningComputeInstance : Azure.ResourceManager.MachineLearning.Models.MachineLearningComputeProperties
    {
        public MachineLearningComputeInstance() { }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningComputeInstanceProperties Properties { get { throw null; } set { } }
    }
    public partial class MachineLearningComputeInstanceApplication
    {
        internal MachineLearningComputeInstanceApplication() { }
        public string DisplayName { get { throw null; } }
        public System.Uri EndpointUri { get { throw null; } }
    }
    public partial class MachineLearningComputeInstanceAssignedUser
    {
        public MachineLearningComputeInstanceAssignedUser(string objectId, System.Guid tenantId) { }
        public string ObjectId { get { throw null; } set { } }
        public System.Guid TenantId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MachineLearningComputeInstanceAuthorizationType : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.MachineLearningComputeInstanceAuthorizationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MachineLearningComputeInstanceAuthorizationType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningComputeInstanceAuthorizationType Personal { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.MachineLearningComputeInstanceAuthorizationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.MachineLearningComputeInstanceAuthorizationType left, Azure.ResourceManager.MachineLearning.Models.MachineLearningComputeInstanceAuthorizationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.MachineLearningComputeInstanceAuthorizationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.MachineLearningComputeInstanceAuthorizationType left, Azure.ResourceManager.MachineLearning.Models.MachineLearningComputeInstanceAuthorizationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MachineLearningComputeInstanceAutosave : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.MachineLearningComputeInstanceAutosave>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MachineLearningComputeInstanceAutosave(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningComputeInstanceAutosave Local { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningComputeInstanceAutosave None { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningComputeInstanceAutosave Remote { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.MachineLearningComputeInstanceAutosave other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.MachineLearningComputeInstanceAutosave left, Azure.ResourceManager.MachineLearning.Models.MachineLearningComputeInstanceAutosave right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.MachineLearningComputeInstanceAutosave (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.MachineLearningComputeInstanceAutosave left, Azure.ResourceManager.MachineLearning.Models.MachineLearningComputeInstanceAutosave right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MachineLearningComputeInstanceConnectivityEndpoints
    {
        internal MachineLearningComputeInstanceConnectivityEndpoints() { }
        public string PrivateIPAddress { get { throw null; } }
        public string PublicIPAddress { get { throw null; } }
    }
    public partial class MachineLearningComputeInstanceContainer
    {
        internal MachineLearningComputeInstanceContainer() { }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningComputeInstanceAutosave? Autosave { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningComputeInstanceEnvironmentInfo Environment { get { throw null; } }
        public string Gpu { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningNetwork? Network { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<System.BinaryData> Services { get { throw null; } }
    }
    public partial class MachineLearningComputeInstanceCreatedBy
    {
        internal MachineLearningComputeInstanceCreatedBy() { }
        public string UserId { get { throw null; } }
        public string UserName { get { throw null; } }
        public string UserOrgId { get { throw null; } }
    }
    public partial class MachineLearningComputeInstanceDataDisk
    {
        internal MachineLearningComputeInstanceDataDisk() { }
        public Azure.ResourceManager.MachineLearning.Models.Caching? Caching { get { throw null; } }
        public int? DiskSizeGB { get { throw null; } }
        public int? Lun { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.StorageAccountType? StorageAccountType { get { throw null; } }
    }
    public partial class MachineLearningComputeInstanceDataMount
    {
        internal MachineLearningComputeInstanceDataMount() { }
        public string CreatedBy { get { throw null; } }
        public string Error { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningMountAction? MountAction { get { throw null; } }
        public System.DateTimeOffset? MountedOn { get { throw null; } }
        public string MountName { get { throw null; } }
        public string MountPath { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningMountState? MountState { get { throw null; } }
        public string Source { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningSourceType? SourceType { get { throw null; } }
    }
    public partial class MachineLearningComputeInstanceEnvironmentInfo
    {
        internal MachineLearningComputeInstanceEnvironmentInfo() { }
        public string Name { get { throw null; } }
        public string Version { get { throw null; } }
    }
    public partial class MachineLearningComputeInstanceLastOperation
    {
        internal MachineLearningComputeInstanceLastOperation() { }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningOperationName? OperationName { get { throw null; } }
        public System.DateTimeOffset? OperationOn { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningOperationStatus? OperationStatus { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningOperationTrigger? OperationTrigger { get { throw null; } }
    }
    public partial class MachineLearningComputeInstanceProperties
    {
        public MachineLearningComputeInstanceProperties() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearning.Models.MachineLearningComputeInstanceApplication> Applications { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningApplicationSharingPolicy? ApplicationSharingPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningComputeInstanceAuthorizationType? ComputeInstanceAuthorizationType { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningComputeInstanceConnectivityEndpoints ConnectivityEndpoints { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearning.Models.MachineLearningComputeInstanceContainer> Containers { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningComputeInstanceCreatedBy CreatedBy { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearning.Models.MachineLearningComputeInstanceDataDisk> DataDisks { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearning.Models.MachineLearningComputeInstanceDataMount> DataMounts { get { throw null; } }
        public bool? EnableNodePublicIP { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearning.Models.ErrorResponse> Errors { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningComputeInstanceLastOperation LastOperation { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningComputeInstanceAssignedUser PersonalComputeInstanceAssignedUser { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearning.Models.MachineLearningComputeStartStopSchedule> SchedulesComputeStartStop { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.ScriptsToExecute Scripts { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningComputeInstanceSshSettings SshSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningComputeInstanceState? State { get { throw null; } }
        public string SubnetId { get { throw null; } set { } }
        public string VersionsRuntime { get { throw null; } }
        public string VmSize { get { throw null; } set { } }
    }
    public partial class MachineLearningComputeInstanceSshSettings
    {
        public MachineLearningComputeInstanceSshSettings() { }
        public string AdminPublicKey { get { throw null; } set { } }
        public string AdminUserName { get { throw null; } }
        public int? SshPort { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningSshPublicAccess? SshPublicAccess { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MachineLearningComputeInstanceState : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.MachineLearningComputeInstanceState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MachineLearningComputeInstanceState(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningComputeInstanceState CreateFailed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningComputeInstanceState Creating { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningComputeInstanceState Deleting { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningComputeInstanceState JobRunning { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningComputeInstanceState Restarting { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningComputeInstanceState Running { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningComputeInstanceState SettingUp { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningComputeInstanceState SetupFailed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningComputeInstanceState Starting { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningComputeInstanceState Stopped { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningComputeInstanceState Stopping { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningComputeInstanceState Unknown { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningComputeInstanceState Unusable { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningComputeInstanceState UserSettingUp { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningComputeInstanceState UserSetupFailed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.MachineLearningComputeInstanceState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.MachineLearningComputeInstanceState left, Azure.ResourceManager.MachineLearning.Models.MachineLearningComputeInstanceState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.MachineLearningComputeInstanceState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.MachineLearningComputeInstanceState left, Azure.ResourceManager.MachineLearning.Models.MachineLearningComputeInstanceState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MachineLearningComputePatch
    {
        public MachineLearningComputePatch() { }
        public Azure.ResourceManager.MachineLearning.Models.ScaleSettings ScaleSettings { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MachineLearningComputePowerAction : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.MachineLearningComputePowerAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MachineLearningComputePowerAction(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningComputePowerAction Start { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningComputePowerAction Stop { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.MachineLearningComputePowerAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.MachineLearningComputePowerAction left, Azure.ResourceManager.MachineLearning.Models.MachineLearningComputePowerAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.MachineLearningComputePowerAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.MachineLearningComputePowerAction left, Azure.ResourceManager.MachineLearning.Models.MachineLearningComputePowerAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class MachineLearningComputeProperties
    {
        protected MachineLearningComputeProperties() { }
        public string ComputeLocation { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public bool? DisableLocalAuth { get { throw null; } set { } }
        public bool? IsAttachedCompute { get { throw null; } }
        public System.DateTimeOffset? ModifiedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearning.Models.ErrorResponse> ProvisioningErrors { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MachineLearningComputeProvisioningStatus : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.MachineLearningComputeProvisioningStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MachineLearningComputeProvisioningStatus(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningComputeProvisioningStatus Completed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningComputeProvisioningStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningComputeProvisioningStatus Provisioning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.MachineLearningComputeProvisioningStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.MachineLearningComputeProvisioningStatus left, Azure.ResourceManager.MachineLearning.Models.MachineLearningComputeProvisioningStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.MachineLearningComputeProvisioningStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.MachineLearningComputeProvisioningStatus left, Azure.ResourceManager.MachineLearning.Models.MachineLearningComputeProvisioningStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class MachineLearningComputeSecrets
    {
        protected MachineLearningComputeSecrets() { }
    }
    public partial class MachineLearningComputeStartStopSchedule
    {
        internal MachineLearningComputeStartStopSchedule() { }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningComputePowerAction? Action { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.CronTrigger Cron { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningComputeProvisioningStatus? ProvisioningStatus { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningRecurrenceTrigger Recurrence { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningScheduleBase Schedule { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningScheduleStatus? Status { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningTriggerType? TriggerType { get { throw null; } }
    }
    public partial class MachineLearningComputeSystemService
    {
        internal MachineLearningComputeSystemService() { }
        public string PublicIPAddress { get { throw null; } }
        public string SystemServiceType { get { throw null; } }
        public string Version { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MachineLearningConnectionCategory : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.MachineLearningConnectionCategory>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MachineLearningConnectionCategory(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningConnectionCategory ContainerRegistry { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningConnectionCategory Git { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningConnectionCategory PythonFeed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.MachineLearningConnectionCategory other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.MachineLearningConnectionCategory left, Azure.ResourceManager.MachineLearning.Models.MachineLearningConnectionCategory right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.MachineLearningConnectionCategory (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.MachineLearningConnectionCategory left, Azure.ResourceManager.MachineLearning.Models.MachineLearningConnectionCategory right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MachineLearningContainerRegistryCredentials
    {
        internal MachineLearningContainerRegistryCredentials() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearning.Models.MachineLearningPasswordDetail> Passwords { get { throw null; } }
        public string Username { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MachineLearningContainerType : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.MachineLearningContainerType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MachineLearningContainerType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningContainerType InferenceServer { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningContainerType StorageInitializer { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.MachineLearningContainerType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.MachineLearningContainerType left, Azure.ResourceManager.MachineLearning.Models.MachineLearningContainerType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.MachineLearningContainerType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.MachineLearningContainerType left, Azure.ResourceManager.MachineLearning.Models.MachineLearningContainerType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MachineLearningDatabricksCompute : Azure.ResourceManager.MachineLearning.Models.MachineLearningComputeProperties
    {
        public MachineLearningDatabricksCompute() { }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningDatabricksProperties Properties { get { throw null; } set { } }
    }
    public partial class MachineLearningDatabricksComputeSecrets : Azure.ResourceManager.MachineLearning.Models.MachineLearningComputeSecrets
    {
        internal MachineLearningDatabricksComputeSecrets() { }
        public string DatabricksAccessToken { get { throw null; } }
    }
    public partial class MachineLearningDatabricksProperties
    {
        public MachineLearningDatabricksProperties() { }
        public string DatabricksAccessToken { get { throw null; } set { } }
        public System.Uri WorkspaceUri { get { throw null; } set { } }
    }
    public partial class MachineLearningDataContainerProperties : Azure.ResourceManager.MachineLearning.Models.MachineLearningAssetContainer
    {
        public MachineLearningDataContainerProperties(Azure.ResourceManager.MachineLearning.Models.DataType dataType) { }
        public Azure.ResourceManager.MachineLearning.Models.DataType DataType { get { throw null; } set { } }
    }
    public partial class MachineLearningDataFactoryCompute : Azure.ResourceManager.MachineLearning.Models.MachineLearningComputeProperties
    {
        public MachineLearningDataFactoryCompute() { }
    }
    public partial class MachineLearningDataLakeAnalytics : Azure.ResourceManager.MachineLearning.Models.MachineLearningComputeProperties
    {
        public MachineLearningDataLakeAnalytics() { }
        public string DataLakeStoreAccountName { get { throw null; } set { } }
    }
    public partial class MachineLearningDataPathAssetReference : Azure.ResourceManager.MachineLearning.Models.MachineLearningAssetReferenceBase
    {
        public MachineLearningDataPathAssetReference() { }
        public string DatastoreId { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
    }
    public abstract partial class MachineLearningDatastoreCredentials
    {
        protected MachineLearningDatastoreCredentials() { }
    }
    public partial class MachineLearningDatastoreProperties : Azure.ResourceManager.MachineLearning.Models.MachineLearningResourceBase
    {
        public MachineLearningDatastoreProperties(Azure.ResourceManager.MachineLearning.Models.MachineLearningDatastoreCredentials credentials) { }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningDatastoreCredentials Credentials { get { throw null; } set { } }
        public bool? IsDefault { get { throw null; } }
    }
    public abstract partial class MachineLearningDatastoreSecrets
    {
        protected MachineLearningDatastoreSecrets() { }
    }
    public partial class MachineLearningDataVersionProperties : Azure.ResourceManager.MachineLearning.Models.MachineLearningAssetBase
    {
        public MachineLearningDataVersionProperties(System.Uri dataUri) { }
        public System.Uri DataUri { get { throw null; } set { } }
    }
    public partial class MachineLearningDeploymentLogs
    {
        internal MachineLearningDeploymentLogs() { }
        public string Content { get { throw null; } }
    }
    public partial class MachineLearningDeploymentLogsContent
    {
        public MachineLearningDeploymentLogsContent() { }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningContainerType? ContainerType { get { throw null; } set { } }
        public int? Tail { get { throw null; } set { } }
    }
    public partial class MachineLearningDiagnoseResult
    {
        internal MachineLearningDiagnoseResult() { }
        public string Code { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningDiagnoseResultLevel? Level { get { throw null; } }
        public string Message { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MachineLearningDiagnoseResultLevel : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.MachineLearningDiagnoseResultLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MachineLearningDiagnoseResultLevel(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningDiagnoseResultLevel Error { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningDiagnoseResultLevel Information { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningDiagnoseResultLevel Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.MachineLearningDiagnoseResultLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.MachineLearningDiagnoseResultLevel left, Azure.ResourceManager.MachineLearning.Models.MachineLearningDiagnoseResultLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.MachineLearningDiagnoseResultLevel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.MachineLearningDiagnoseResultLevel left, Azure.ResourceManager.MachineLearning.Models.MachineLearningDiagnoseResultLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MachineLearningDiagnoseResultValue
    {
        internal MachineLearningDiagnoseResultValue() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearning.Models.MachineLearningDiagnoseResult> ApplicationInsightsResults { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearning.Models.MachineLearningDiagnoseResult> ContainerRegistryResults { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearning.Models.MachineLearningDiagnoseResult> DnsResolutionResults { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearning.Models.MachineLearningDiagnoseResult> KeyVaultResults { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearning.Models.MachineLearningDiagnoseResult> NetworkSecurityRuleResults { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearning.Models.MachineLearningDiagnoseResult> OtherResults { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearning.Models.MachineLearningDiagnoseResult> ResourceLockResults { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearning.Models.MachineLearningDiagnoseResult> StorageAccountResults { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearning.Models.MachineLearningDiagnoseResult> UserDefinedRouteResults { get { throw null; } }
    }
    public partial class MachineLearningEncryptionKeyVaultProperties
    {
        public MachineLearningEncryptionKeyVaultProperties(Azure.Core.ResourceIdentifier keyVaultArmId, string keyIdentifier) { }
        public string IdentityClientId { get { throw null; } set { } }
        public string KeyIdentifier { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier KeyVaultArmId { get { throw null; } set { } }
    }
    public partial class MachineLearningEncryptionSetting
    {
        public MachineLearningEncryptionSetting(Azure.ResourceManager.MachineLearning.Models.MachineLearningEncryptionStatus status, Azure.ResourceManager.MachineLearning.Models.MachineLearningEncryptionKeyVaultProperties keyVaultProperties) { }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningEncryptionKeyVaultProperties KeyVaultProperties { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningEncryptionStatus Status { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier UserAssignedIdentity { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MachineLearningEncryptionStatus : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.MachineLearningEncryptionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MachineLearningEncryptionStatus(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningEncryptionStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningEncryptionStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.MachineLearningEncryptionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.MachineLearningEncryptionStatus left, Azure.ResourceManager.MachineLearning.Models.MachineLearningEncryptionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.MachineLearningEncryptionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.MachineLearningEncryptionStatus left, Azure.ResourceManager.MachineLearning.Models.MachineLearningEncryptionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MachineLearningEnvironmentContainerProperties : Azure.ResourceManager.MachineLearning.Models.MachineLearningAssetContainer
    {
        public MachineLearningEnvironmentContainerProperties() { }
    }
    public partial class MachineLearningEnvironmentVersionProperties : Azure.ResourceManager.MachineLearning.Models.MachineLearningAssetBase
    {
        public MachineLearningEnvironmentVersionProperties() { }
        public Azure.ResourceManager.MachineLearning.Models.AutoRebuildSetting? AutoRebuild { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.BuildContext Build { get { throw null; } set { } }
        public string CondaFile { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.EnvironmentType? EnvironmentType { get { throw null; } }
        public string Image { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.InferenceContainerProperties InferenceConfig { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.OperatingSystemType? OSType { get { throw null; } set { } }
    }
    public partial class MachineLearningFqdnEndpoints
    {
        internal MachineLearningFqdnEndpoints() { }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningFqdnEndpointsProperties Properties { get { throw null; } }
    }
    public partial class MachineLearningFqdnEndpointsProperties
    {
        internal MachineLearningFqdnEndpointsProperties() { }
        public string Category { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearning.Models.FqdnEndpoint> Endpoints { get { throw null; } }
    }
    public partial class MachineLearningHDInsightCompute : Azure.ResourceManager.MachineLearning.Models.MachineLearningComputeProperties
    {
        public MachineLearningHDInsightCompute() { }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningHDInsightProperties Properties { get { throw null; } set { } }
    }
    public partial class MachineLearningHDInsightProperties
    {
        public MachineLearningHDInsightProperties() { }
        public string Address { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.VirtualMachineSshCredentials AdministratorAccount { get { throw null; } set { } }
        public int? SshPort { get { throw null; } set { } }
    }
    public partial class MachineLearningIdAssetReference : Azure.ResourceManager.MachineLearning.Models.MachineLearningAssetReferenceBase
    {
        public MachineLearningIdAssetReference(Azure.Core.ResourceIdentifier assetId) { }
        public Azure.Core.ResourceIdentifier AssetId { get { throw null; } set { } }
    }
    public abstract partial class MachineLearningIdentityConfiguration
    {
        protected MachineLearningIdentityConfiguration() { }
    }
    public partial class MachineLearningJobProperties : Azure.ResourceManager.MachineLearning.Models.MachineLearningResourceBase
    {
        public MachineLearningJobProperties() { }
        public string ComponentId { get { throw null; } set { } }
        public string ComputeId { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string ExperimentName { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningIdentityConfiguration Identity { get { throw null; } set { } }
        public bool? IsArchived { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.MachineLearning.Models.JobService> Services { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.JobStatus? Status { get { throw null; } }
    }
    public partial class MachineLearningKubernetesCompute : Azure.ResourceManager.MachineLearning.Models.MachineLearningComputeProperties
    {
        public MachineLearningKubernetesCompute() { }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningKubernetesProperties Properties { get { throw null; } set { } }
    }
    public partial class MachineLearningKubernetesProperties
    {
        public MachineLearningKubernetesProperties() { }
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
    public readonly partial struct MachineLearningLoadBalancerType : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.MachineLearningLoadBalancerType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MachineLearningLoadBalancerType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningLoadBalancerType InternalLoadBalancer { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningLoadBalancerType PublicIP { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.MachineLearningLoadBalancerType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.MachineLearningLoadBalancerType left, Azure.ResourceManager.MachineLearning.Models.MachineLearningLoadBalancerType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.MachineLearningLoadBalancerType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.MachineLearningLoadBalancerType left, Azure.ResourceManager.MachineLearning.Models.MachineLearningLoadBalancerType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MachineLearningManagedIdentity : Azure.ResourceManager.MachineLearning.Models.MachineLearningIdentityConfiguration
    {
        public MachineLearningManagedIdentity() { }
        public System.Guid? ClientId { get { throw null; } set { } }
        public System.Guid? ObjectId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
    }
    public partial class MachineLearningModelContainerProperties : Azure.ResourceManager.MachineLearning.Models.MachineLearningAssetContainer
    {
        public MachineLearningModelContainerProperties() { }
    }
    public partial class MachineLearningModelVersionProperties : Azure.ResourceManager.MachineLearning.Models.MachineLearningAssetBase
    {
        public MachineLearningModelVersionProperties() { }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.MachineLearning.Models.FlavorData> Flavors { get { throw null; } set { } }
        public string JobName { get { throw null; } set { } }
        public string ModelType { get { throw null; } set { } }
        public System.Uri ModelUri { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MachineLearningMountAction : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.MachineLearningMountAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MachineLearningMountAction(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningMountAction Mount { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningMountAction Unmount { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.MachineLearningMountAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.MachineLearningMountAction left, Azure.ResourceManager.MachineLearning.Models.MachineLearningMountAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.MachineLearningMountAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.MachineLearningMountAction left, Azure.ResourceManager.MachineLearning.Models.MachineLearningMountAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MachineLearningMountState : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.MachineLearningMountState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MachineLearningMountState(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningMountState Mounted { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningMountState MountFailed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningMountState MountRequested { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningMountState Unmounted { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningMountState UnmountFailed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningMountState UnmountRequested { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.MachineLearningMountState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.MachineLearningMountState left, Azure.ResourceManager.MachineLearning.Models.MachineLearningMountState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.MachineLearningMountState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.MachineLearningMountState left, Azure.ResourceManager.MachineLearning.Models.MachineLearningMountState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MachineLearningNetwork : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.MachineLearningNetwork>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MachineLearningNetwork(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningNetwork Bridge { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningNetwork Host { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.MachineLearningNetwork other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.MachineLearningNetwork left, Azure.ResourceManager.MachineLearning.Models.MachineLearningNetwork right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.MachineLearningNetwork (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.MachineLearningNetwork left, Azure.ResourceManager.MachineLearning.Models.MachineLearningNetwork right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MachineLearningNoneDatastoreCredentials : Azure.ResourceManager.MachineLearning.Models.MachineLearningDatastoreCredentials
    {
        public MachineLearningNoneDatastoreCredentials() { }
    }
    public partial class MachineLearningNotebookResourceInfo
    {
        internal MachineLearningNotebookResourceInfo() { }
        public string Fqdn { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.NotebookPreparationError NotebookPreparationError { get { throw null; } }
        public string ResourceId { get { throw null; } }
    }
    public partial class MachineLearningOnlineDeploymentPatch : Azure.ResourceManager.MachineLearning.Models.MachineLearningResourcePatch
    {
        public MachineLearningOnlineDeploymentPatch() { }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningSkuPatch Sku { get { throw null; } set { } }
    }
    public partial class MachineLearningOnlineDeploymentProperties : Azure.ResourceManager.MachineLearning.Models.EndpointDeploymentPropertiesBase
    {
        public MachineLearningOnlineDeploymentProperties() { }
        public bool? AppInsightsEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.EgressPublicNetworkAccessType? EgressPublicNetworkAccess { get { throw null; } set { } }
        public string InstanceType { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ProbeSettings LivenessProbe { get { throw null; } set { } }
        public string Model { get { throw null; } set { } }
        public string ModelMountPath { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.DeploymentProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.ProbeSettings ReadinessProbe { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.OnlineRequestSettings RequestSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.OnlineScaleSettings ScaleSettings { get { throw null; } set { } }
    }
    public partial class MachineLearningOnlineEndpointProperties : Azure.ResourceManager.MachineLearning.Models.EndpointPropertiesBase
    {
        public MachineLearningOnlineEndpointProperties(Azure.ResourceManager.MachineLearning.Models.EndpointAuthMode authMode) : base (default(Azure.ResourceManager.MachineLearning.Models.EndpointAuthMode)) { }
        public string Compute { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.EndpointProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.PublicNetworkAccessType? PublicNetworkAccess { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, int> Traffic { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MachineLearningOperationName : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.MachineLearningOperationName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MachineLearningOperationName(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningOperationName Create { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningOperationName Delete { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningOperationName Reimage { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningOperationName Restart { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningOperationName Start { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningOperationName Stop { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.MachineLearningOperationName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.MachineLearningOperationName left, Azure.ResourceManager.MachineLearning.Models.MachineLearningOperationName right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.MachineLearningOperationName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.MachineLearningOperationName left, Azure.ResourceManager.MachineLearning.Models.MachineLearningOperationName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MachineLearningOperationStatus : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.MachineLearningOperationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MachineLearningOperationStatus(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningOperationStatus CreateFailed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningOperationStatus DeleteFailed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningOperationStatus InProgress { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningOperationStatus ReimageFailed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningOperationStatus RestartFailed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningOperationStatus StartFailed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningOperationStatus StopFailed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningOperationStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.MachineLearningOperationStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.MachineLearningOperationStatus left, Azure.ResourceManager.MachineLearning.Models.MachineLearningOperationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.MachineLearningOperationStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.MachineLearningOperationStatus left, Azure.ResourceManager.MachineLearning.Models.MachineLearningOperationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MachineLearningOperationTrigger : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.MachineLearningOperationTrigger>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MachineLearningOperationTrigger(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningOperationTrigger IdleShutdown { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningOperationTrigger Schedule { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningOperationTrigger User { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.MachineLearningOperationTrigger other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.MachineLearningOperationTrigger left, Azure.ResourceManager.MachineLearning.Models.MachineLearningOperationTrigger right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.MachineLearningOperationTrigger (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.MachineLearningOperationTrigger left, Azure.ResourceManager.MachineLearning.Models.MachineLearningOperationTrigger right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MachineLearningOutputPathAssetReference : Azure.ResourceManager.MachineLearning.Models.MachineLearningAssetReferenceBase
    {
        public MachineLearningOutputPathAssetReference() { }
        public string JobId { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
    }
    public partial class MachineLearningPartialManagedServiceIdentity
    {
        public MachineLearningPartialManagedServiceIdentity() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentityType? ManagedServiceIdentityType { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> UserAssignedIdentities { get { throw null; } }
    }
    public partial class MachineLearningPasswordDetail
    {
        internal MachineLearningPasswordDetail() { }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MachineLearningProvisioningState : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.MachineLearningProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MachineLearningProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningProvisioningState Unknown { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.MachineLearningProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.MachineLearningProvisioningState left, Azure.ResourceManager.MachineLearning.Models.MachineLearningProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.MachineLearningProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.MachineLearningProvisioningState left, Azure.ResourceManager.MachineLearning.Models.MachineLearningProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MachineLearningPublicNetworkAccess : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.MachineLearningPublicNetworkAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MachineLearningPublicNetworkAccess(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningPublicNetworkAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningPublicNetworkAccess Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.MachineLearningPublicNetworkAccess other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.MachineLearningPublicNetworkAccess left, Azure.ResourceManager.MachineLearning.Models.MachineLearningPublicNetworkAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.MachineLearningPublicNetworkAccess (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.MachineLearningPublicNetworkAccess left, Azure.ResourceManager.MachineLearning.Models.MachineLearningPublicNetworkAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MachineLearningQuotaUpdateContent
    {
        public MachineLearningQuotaUpdateContent() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.MachineLearning.Models.QuotaBaseProperties> Value { get { throw null; } }
    }
    public partial class MachineLearningRecurrenceTrigger : Azure.ResourceManager.MachineLearning.Models.TriggerBase
    {
        public MachineLearningRecurrenceTrigger(Azure.ResourceManager.MachineLearning.Models.RecurrenceFrequency frequency, int interval) { }
        public Azure.ResourceManager.MachineLearning.Models.RecurrenceFrequency Frequency { get { throw null; } set { } }
        public int Interval { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.RecurrenceSchedule Schedule { get { throw null; } set { } }
    }
    public partial class MachineLearningResourceBase
    {
        public MachineLearningResourceBase() { }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } set { } }
    }
    public partial class MachineLearningResourcePatch
    {
        public MachineLearningResourcePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class MachineLearningResourcePatchWithIdentity : Azure.ResourceManager.MachineLearning.Models.MachineLearningResourcePatch
    {
        public MachineLearningResourcePatchWithIdentity() { }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningPartialManagedServiceIdentity Identity { get { throw null; } set { } }
    }
    public partial class MachineLearningResourceQuota
    {
        internal MachineLearningResourceQuota() { }
        public string AmlWorkspaceLocation { get { throw null; } }
        public string Id { get { throw null; } }
        public long? Limit { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.ResourceName Name { get { throw null; } }
        public string ResourceQuotaType { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.QuotaUnit? Unit { get { throw null; } }
    }
    public partial class MachineLearningSasDatastoreCredentials : Azure.ResourceManager.MachineLearning.Models.MachineLearningDatastoreCredentials
    {
        public MachineLearningSasDatastoreCredentials(Azure.ResourceManager.MachineLearning.Models.MachineLearningSasDatastoreSecrets secrets) { }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningSasDatastoreSecrets Secrets { get { throw null; } set { } }
    }
    public partial class MachineLearningSasDatastoreSecrets : Azure.ResourceManager.MachineLearning.Models.MachineLearningDatastoreSecrets
    {
        public MachineLearningSasDatastoreSecrets() { }
        public string SasToken { get { throw null; } set { } }
    }
    public partial class MachineLearningScheduleBase
    {
        internal MachineLearningScheduleBase() { }
        public string Id { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.ScheduleProvisioningState? ProvisioningStatus { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningScheduleStatus? Status { get { throw null; } }
    }
    public partial class MachineLearningScheduleProperties : Azure.ResourceManager.MachineLearning.Models.MachineLearningResourceBase
    {
        public MachineLearningScheduleProperties(Azure.ResourceManager.MachineLearning.Models.ScheduleActionBase action, Azure.ResourceManager.MachineLearning.Models.TriggerBase trigger) { }
        public Azure.ResourceManager.MachineLearning.Models.ScheduleActionBase Action { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ScheduleProvisioningStatus? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.TriggerBase Trigger { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MachineLearningScheduleStatus : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.MachineLearningScheduleStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MachineLearningScheduleStatus(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningScheduleStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningScheduleStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.MachineLearningScheduleStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.MachineLearningScheduleStatus left, Azure.ResourceManager.MachineLearning.Models.MachineLearningScheduleStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.MachineLearningScheduleStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.MachineLearningScheduleStatus left, Azure.ResourceManager.MachineLearning.Models.MachineLearningScheduleStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MachineLearningServicePrincipalDatastoreCredentials : Azure.ResourceManager.MachineLearning.Models.MachineLearningDatastoreCredentials
    {
        public MachineLearningServicePrincipalDatastoreCredentials(System.Guid clientId, Azure.ResourceManager.MachineLearning.Models.MachineLearningServicePrincipalDatastoreSecrets secrets, System.Guid tenantId) { }
        public System.Uri AuthorityUri { get { throw null; } set { } }
        public System.Guid ClientId { get { throw null; } set { } }
        public System.Uri ResourceUri { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningServicePrincipalDatastoreSecrets Secrets { get { throw null; } set { } }
        public System.Guid TenantId { get { throw null; } set { } }
    }
    public partial class MachineLearningServicePrincipalDatastoreSecrets : Azure.ResourceManager.MachineLearning.Models.MachineLearningDatastoreSecrets
    {
        public MachineLearningServicePrincipalDatastoreSecrets() { }
        public string ClientSecret { get { throw null; } set { } }
    }
    public partial class MachineLearningSharedPrivateLinkResource
    {
        public MachineLearningSharedPrivateLinkResource() { }
        public string GroupId { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrivateLinkResourceId { get { throw null; } set { } }
        public string RequestMessage { get { throw null; } set { } }
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
    public partial class MachineLearningSkuPatch
    {
        public MachineLearningSkuPatch() { }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MachineLearningSourceType : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.MachineLearningSourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MachineLearningSourceType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningSourceType Dataset { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningSourceType Datastore { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningSourceType Uri { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.MachineLearningSourceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.MachineLearningSourceType left, Azure.ResourceManager.MachineLearning.Models.MachineLearningSourceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.MachineLearningSourceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.MachineLearningSourceType left, Azure.ResourceManager.MachineLearning.Models.MachineLearningSourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MachineLearningSshPublicAccess : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.MachineLearningSshPublicAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MachineLearningSshPublicAccess(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningSshPublicAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningSshPublicAccess Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.MachineLearningSshPublicAccess other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.MachineLearningSshPublicAccess left, Azure.ResourceManager.MachineLearning.Models.MachineLearningSshPublicAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.MachineLearningSshPublicAccess (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.MachineLearningSshPublicAccess left, Azure.ResourceManager.MachineLearning.Models.MachineLearningSshPublicAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MachineLearningSslConfiguration
    {
        public MachineLearningSslConfiguration() { }
        public string Cert { get { throw null; } set { } }
        public string Cname { get { throw null; } set { } }
        public string Key { get { throw null; } set { } }
        public string LeafDomainLabel { get { throw null; } set { } }
        public bool? OverwriteExistingDomain { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.SslConfigStatus? Status { get { throw null; } set { } }
    }
    public partial class MachineLearningSynapseSpark : Azure.ResourceManager.MachineLearning.Models.MachineLearningComputeProperties
    {
        public MachineLearningSynapseSpark() { }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningSynapseSparkProperties Properties { get { throw null; } set { } }
    }
    public partial class MachineLearningSynapseSparkProperties
    {
        public MachineLearningSynapseSparkProperties() { }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningAutoPauseProperties AutoPauseProperties { get { throw null; } set { } }
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
    public partial class MachineLearningTable : Azure.ResourceManager.MachineLearning.Models.MachineLearningDataVersionProperties
    {
        public MachineLearningTable(System.Uri dataUri) : base (default(System.Uri)) { }
        public System.Collections.Generic.IList<System.Uri> ReferencedUris { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MachineLearningTriggerType : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.MachineLearningTriggerType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MachineLearningTriggerType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningTriggerType Cron { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningTriggerType Recurrence { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.MachineLearningTriggerType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.MachineLearningTriggerType left, Azure.ResourceManager.MachineLearning.Models.MachineLearningTriggerType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.MachineLearningTriggerType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.MachineLearningTriggerType left, Azure.ResourceManager.MachineLearning.Models.MachineLearningTriggerType right) { throw null; }
        public override string ToString() { throw null; }
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
    public partial class MachineLearningUserFeature
    {
        internal MachineLearningUserFeature() { }
        public string Description { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public string Id { get { throw null; } }
    }
    public partial class MachineLearningUserIdentity : Azure.ResourceManager.MachineLearning.Models.MachineLearningIdentityConfiguration
    {
        public MachineLearningUserIdentity() { }
    }
    public partial class MachineLearningVirtualMachineCompute : Azure.ResourceManager.MachineLearning.Models.MachineLearningComputeProperties
    {
        public MachineLearningVirtualMachineCompute() { }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningVirtualMachineProperties Properties { get { throw null; } set { } }
    }
    public partial class MachineLearningVirtualMachineProperties
    {
        public MachineLearningVirtualMachineProperties() { }
        public string Address { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.VirtualMachineSshCredentials AdministratorAccount { get { throw null; } set { } }
        public bool? IsNotebookInstanceCompute { get { throw null; } set { } }
        public int? NotebookServerPort { get { throw null; } set { } }
        public int? SshPort { get { throw null; } set { } }
        public string VirtualMachineSize { get { throw null; } set { } }
    }
    public partial class MachineLearningVirtualMachineSecrets : Azure.ResourceManager.MachineLearning.Models.MachineLearningComputeSecrets
    {
        internal MachineLearningVirtualMachineSecrets() { }
        public Azure.ResourceManager.MachineLearning.Models.VirtualMachineSshCredentials AdministratorAccount { get { throw null; } }
    }
    public partial class MachineLearningVmSize
    {
        internal MachineLearningVmSize() { }
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
    public abstract partial class MachineLearningWorkspaceConnectionProperties
    {
        protected MachineLearningWorkspaceConnectionProperties() { }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningConnectionCategory? Category { get { throw null; } set { } }
        public string Target { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ValueFormat? ValueFormat { get { throw null; } set { } }
    }
    public partial class MachineLearningWorkspaceDiagnoseContent
    {
        public MachineLearningWorkspaceDiagnoseContent() { }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningWorkspaceDiagnoseProperties Value { get { throw null; } set { } }
    }
    public partial class MachineLearningWorkspaceDiagnoseProperties
    {
        public MachineLearningWorkspaceDiagnoseProperties() { }
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
    public partial class MachineLearningWorkspaceDiagnoseResult
    {
        internal MachineLearningWorkspaceDiagnoseResult() { }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningDiagnoseResultValue Value { get { throw null; } }
    }
    public partial class MachineLearningWorkspaceGetKeysResult
    {
        internal MachineLearningWorkspaceGetKeysResult() { }
        public string AppInsightsInstrumentationKey { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningContainerRegistryCredentials ContainerRegistryCredentials { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningWorkspaceGetNotebookKeysResult NotebookAccessKeys { get { throw null; } }
        public string UserStorageKey { get { throw null; } }
        public string UserStorageResourceId { get { throw null; } }
    }
    public partial class MachineLearningWorkspaceGetNotebookKeysResult
    {
        internal MachineLearningWorkspaceGetNotebookKeysResult() { }
        public string PrimaryAccessKey { get { throw null; } }
        public string SecondaryAccessKey { get { throw null; } }
    }
    public partial class MachineLearningWorkspaceGetStorageAccountKeysResult
    {
        internal MachineLearningWorkspaceGetStorageAccountKeysResult() { }
        public string UserStorageKey { get { throw null; } }
    }
    public partial class MachineLearningWorkspaceNotebookAccessTokenResult
    {
        internal MachineLearningWorkspaceNotebookAccessTokenResult() { }
        public string AccessToken { get { throw null; } }
        public int? ExpiresIn { get { throw null; } }
        public string HostName { get { throw null; } }
        public string NotebookResourceId { get { throw null; } }
        public string PublicDns { get { throw null; } }
        public string RefreshToken { get { throw null; } }
        public string Scope { get { throw null; } }
        public string TokenType { get { throw null; } }
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
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class MachineLearningWorkspaceQuotaUpdate
    {
        internal MachineLearningWorkspaceQuotaUpdate() { }
        public string Id { get { throw null; } }
        public long? Limit { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.Status? Status { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.QuotaUnit? Unit { get { throw null; } }
        public string UpdateWorkspaceQuotasType { get { throw null; } }
    }
    public partial class ManagedIdentityAuthTypeWorkspaceConnectionProperties : Azure.ResourceManager.MachineLearning.Models.MachineLearningWorkspaceConnectionProperties
    {
        public ManagedIdentityAuthTypeWorkspaceConnectionProperties() { }
        public Azure.ResourceManager.MachineLearning.Models.WorkspaceConnectionManagedIdentity Credentials { get { throw null; } set { } }
    }
    public partial class ManagedOnlineDeployment : Azure.ResourceManager.MachineLearning.Models.MachineLearningOnlineDeploymentProperties
    {
        public ManagedOnlineDeployment() { }
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
    public partial class Mpi : Azure.ResourceManager.MachineLearning.Models.DistributionConfiguration
    {
        public Mpi() { }
        public int? ProcessCountPerInstance { get { throw null; } set { } }
    }
    public abstract partial class NCrossValidations
    {
        protected NCrossValidations() { }
    }
    public partial class NlpVerticalLimitSettings
    {
        public NlpVerticalLimitSettings() { }
        public int? MaxConcurrentTrials { get { throw null; } set { } }
        public int? MaxTrials { get { throw null; } set { } }
        public System.TimeSpan? Timeout { get { throw null; } set { } }
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
    public partial class NoneAuthTypeWorkspaceConnectionProperties : Azure.ResourceManager.MachineLearning.Models.MachineLearningWorkspaceConnectionProperties
    {
        public NoneAuthTypeWorkspaceConnectionProperties() { }
    }
    public partial class NotebookPreparationError
    {
        internal NotebookPreparationError() { }
        public string ErrorMessage { get { throw null; } }
        public int? StatusCode { get { throw null; } }
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
    public partial class PATAuthTypeWorkspaceConnectionProperties : Azure.ResourceManager.MachineLearning.Models.MachineLearningWorkspaceConnectionProperties
    {
        public PATAuthTypeWorkspaceConnectionProperties() { }
        public string CredentialsPat { get { throw null; } set { } }
    }
    public partial class PipelineJob : Azure.ResourceManager.MachineLearning.Models.MachineLearningJobProperties
    {
        public PipelineJob() { }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.MachineLearning.Models.JobInput> Inputs { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Jobs { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.MachineLearning.Models.JobOutput> Outputs { get { throw null; } set { } }
        public System.BinaryData Settings { get { throw null; } set { } }
        public string SourceJobId { get { throw null; } set { } }
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
    public partial class RecurrenceSchedule
    {
        public RecurrenceSchedule(System.Collections.Generic.IEnumerable<int> hours, System.Collections.Generic.IEnumerable<int> minutes) { }
        public System.Collections.Generic.IList<int> Hours { get { throw null; } }
        public System.Collections.Generic.IList<int> Minutes { get { throw null; } }
        public System.Collections.Generic.IList<int> MonthDays { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.MachineLearning.Models.WeekDay> WeekDays { get { throw null; } set { } }
    }
    public partial class RegenerateEndpointKeysContent
    {
        public RegenerateEndpointKeysContent(Azure.ResourceManager.MachineLearning.Models.KeyType keyType) { }
        public Azure.ResourceManager.MachineLearning.Models.KeyType KeyType { get { throw null; } }
        public string KeyValue { get { throw null; } set { } }
    }
    public partial class Regression : Azure.ResourceManager.MachineLearning.Models.AutoMLVertical
    {
        public Regression(Azure.ResourceManager.MachineLearning.Models.MLTableJobInput trainingData) : base (default(Azure.ResourceManager.MachineLearning.Models.MLTableJobInput)) { }
        public System.Collections.Generic.IList<string> CvSplitColumnNames { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.TableVerticalFeaturizationSettings FeaturizationSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.TableVerticalLimitSettings LimitSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.NCrossValidations NCrossValidations { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.RegressionPrimaryMetric? PrimaryMetric { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MLTableJobInput TestData { get { throw null; } set { } }
        public double? TestDataSize { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.RegressionTrainingSettings TrainingSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MLTableJobInput ValidationData { get { throw null; } set { } }
        public double? ValidationDataSize { get { throw null; } set { } }
        public string WeightColumnName { get { throw null; } set { } }
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
    public partial class RegressionTrainingSettings : Azure.ResourceManager.MachineLearning.Models.TrainingSettings
    {
        public RegressionTrainingSettings() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.MachineLearning.Models.RegressionModel> AllowedTrainingAlgorithms { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.MachineLearning.Models.RegressionModel> BlockedTrainingAlgorithms { get { throw null; } set { } }
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
    public partial class SASAuthTypeWorkspaceConnectionProperties : Azure.ResourceManager.MachineLearning.Models.MachineLearningWorkspaceConnectionProperties
    {
        public SASAuthTypeWorkspaceConnectionProperties() { }
        public string CredentialsSas { get { throw null; } set { } }
    }
    public partial class ScaleSettings
    {
        public ScaleSettings(int maxNodeCount) { }
        public int MaxNodeCount { get { throw null; } set { } }
        public int? MinNodeCount { get { throw null; } set { } }
        public System.TimeSpan? NodeIdleTimeBeforeScaleDown { get { throw null; } set { } }
    }
    public abstract partial class ScheduleActionBase
    {
        protected ScheduleActionBase() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScheduleListViewType : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.ScheduleListViewType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScheduleListViewType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.ScheduleListViewType All { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ScheduleListViewType DisabledOnly { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ScheduleListViewType EnabledOnly { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.ScheduleListViewType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.ScheduleListViewType left, Azure.ResourceManager.MachineLearning.Models.ScheduleListViewType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.ScheduleListViewType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.ScheduleListViewType left, Azure.ResourceManager.MachineLearning.Models.ScheduleListViewType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScheduleProvisioningState : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.ScheduleProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScheduleProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.ScheduleProvisioningState Completed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ScheduleProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ScheduleProvisioningState Provisioning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.ScheduleProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.ScheduleProvisioningState left, Azure.ResourceManager.MachineLearning.Models.ScheduleProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.ScheduleProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.ScheduleProvisioningState left, Azure.ResourceManager.MachineLearning.Models.ScheduleProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScheduleProvisioningStatus : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.ScheduleProvisioningStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScheduleProvisioningStatus(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.ScheduleProvisioningStatus Canceled { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ScheduleProvisioningStatus Creating { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ScheduleProvisioningStatus Deleting { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ScheduleProvisioningStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ScheduleProvisioningStatus Succeeded { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.ScheduleProvisioningStatus Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.ScheduleProvisioningStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.ScheduleProvisioningStatus left, Azure.ResourceManager.MachineLearning.Models.ScheduleProvisioningStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.ScheduleProvisioningStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.ScheduleProvisioningStatus left, Azure.ResourceManager.MachineLearning.Models.ScheduleProvisioningStatus right) { throw null; }
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
    public readonly partial struct SslConfigStatus : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.SslConfigStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SslConfigStatus(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.SslConfigStatus Auto { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.SslConfigStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.SslConfigStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.SslConfigStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.SslConfigStatus left, Azure.ResourceManager.MachineLearning.Models.SslConfigStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.SslConfigStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.SslConfigStatus left, Azure.ResourceManager.MachineLearning.Models.SslConfigStatus right) { throw null; }
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
    public partial class TableVerticalFeaturizationSettings : Azure.ResourceManager.MachineLearning.Models.FeaturizationSettings
    {
        public TableVerticalFeaturizationSettings() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.MachineLearning.Models.BlockedTransformer> BlockedTransformers { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> ColumnNameAndTypes { get { throw null; } set { } }
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
    public partial class TextClassification : Azure.ResourceManager.MachineLearning.Models.AutoMLVertical
    {
        public TextClassification(Azure.ResourceManager.MachineLearning.Models.MLTableJobInput trainingData) : base (default(Azure.ResourceManager.MachineLearning.Models.MLTableJobInput)) { }
        public string FeaturizationDatasetLanguage { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.NlpVerticalLimitSettings LimitSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ClassificationPrimaryMetric? PrimaryMetric { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MLTableJobInput ValidationData { get { throw null; } set { } }
    }
    public partial class TextClassificationMultilabel : Azure.ResourceManager.MachineLearning.Models.AutoMLVertical
    {
        public TextClassificationMultilabel(Azure.ResourceManager.MachineLearning.Models.MLTableJobInput trainingData) : base (default(Azure.ResourceManager.MachineLearning.Models.MLTableJobInput)) { }
        public string FeaturizationDatasetLanguage { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.NlpVerticalLimitSettings LimitSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ClassificationMultilabelPrimaryMetric? PrimaryMetric { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.MLTableJobInput ValidationData { get { throw null; } set { } }
    }
    public partial class TextNer : Azure.ResourceManager.MachineLearning.Models.AutoMLVertical
    {
        public TextNer(Azure.ResourceManager.MachineLearning.Models.MLTableJobInput trainingData) : base (default(Azure.ResourceManager.MachineLearning.Models.MLTableJobInput)) { }
        public string FeaturizationDatasetLanguage { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.NlpVerticalLimitSettings LimitSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ClassificationPrimaryMetric? PrimaryMetric { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.MLTableJobInput ValidationData { get { throw null; } set { } }
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
        public Azure.ResourceManager.MachineLearning.Models.JobResourceConfiguration Resources { get { throw null; } set { } }
    }
    public abstract partial class TriggerBase
    {
        protected TriggerBase() { }
        public string EndTime { get { throw null; } set { } }
        public string StartTime { get { throw null; } set { } }
        public string TimeZone { get { throw null; } set { } }
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
    public partial class UriFileDataVersion : Azure.ResourceManager.MachineLearning.Models.MachineLearningDataVersionProperties
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
    public partial class UriFolderDataVersion : Azure.ResourceManager.MachineLearning.Models.MachineLearningDataVersionProperties
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
    public partial class UsernamePasswordAuthTypeWorkspaceConnectionProperties : Azure.ResourceManager.MachineLearning.Models.MachineLearningWorkspaceConnectionProperties
    {
        public UsernamePasswordAuthTypeWorkspaceConnectionProperties() { }
        public Azure.ResourceManager.MachineLearning.Models.WorkspaceConnectionUsernamePassword Credentials { get { throw null; } set { } }
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
    public readonly partial struct WeekDay : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.WeekDay>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WeekDay(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.WeekDay Friday { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.WeekDay Monday { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.WeekDay Saturday { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.WeekDay Sunday { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.WeekDay Thursday { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.WeekDay Tuesday { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.WeekDay Wednesday { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.WeekDay other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.WeekDay left, Azure.ResourceManager.MachineLearning.Models.WeekDay right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.WeekDay (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.WeekDay left, Azure.ResourceManager.MachineLearning.Models.WeekDay right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WorkspaceConnectionManagedIdentity
    {
        public WorkspaceConnectionManagedIdentity() { }
        public string ClientId { get { throw null; } set { } }
        public string ResourceId { get { throw null; } set { } }
    }
    public partial class WorkspaceConnectionUsernamePassword
    {
        public WorkspaceConnectionUsernamePassword() { }
        public string Password { get { throw null; } set { } }
        public string Username { get { throw null; } set { } }
    }
}
