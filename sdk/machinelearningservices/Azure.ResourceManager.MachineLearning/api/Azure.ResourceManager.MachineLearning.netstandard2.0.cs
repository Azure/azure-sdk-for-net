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
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.Models.MachineLearningEndpointAuthKeys> GetKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.Models.MachineLearningEndpointAuthKeys>> GetKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearning.MachineLearningComponentContainerResource> GetAll(string skip = null, Azure.ResourceManager.MachineLearning.Models.MachineLearningListViewType? listViewType = default(Azure.ResourceManager.MachineLearning.Models.MachineLearningListViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearning.MachineLearningComponentContainerResource> GetAllAsync(string skip = null, Azure.ResourceManager.MachineLearning.Models.MachineLearningListViewType? listViewType = default(Azure.ResourceManager.MachineLearning.Models.MachineLearningListViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearning.MachineLearningComponentVersionResource> GetAll(string orderBy = null, int? top = default(int?), string skip = null, Azure.ResourceManager.MachineLearning.Models.MachineLearningListViewType? listViewType = default(Azure.ResourceManager.MachineLearning.Models.MachineLearningListViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearning.MachineLearningComponentVersionResource> GetAllAsync(string orderBy = null, int? top = default(int?), string skip = null, Azure.ResourceManager.MachineLearning.Models.MachineLearningListViewType? listViewType = default(Azure.ResourceManager.MachineLearning.Models.MachineLearningListViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.Models.MachineLearningUnderlyingResourceAction underlyingResourceAction, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.Models.MachineLearningUnderlyingResourceAction underlyingResourceAction, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearning.MachineLearningDataContainerResource> GetAll(string skip = null, Azure.ResourceManager.MachineLearning.Models.MachineLearningListViewType? listViewType = default(Azure.ResourceManager.MachineLearning.Models.MachineLearningListViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearning.MachineLearningDataContainerResource> GetAllAsync(string skip = null, Azure.ResourceManager.MachineLearning.Models.MachineLearningListViewType? listViewType = default(Azure.ResourceManager.MachineLearning.Models.MachineLearningListViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearning.MachineLearningDatastoreResource> GetAll(Azure.ResourceManager.MachineLearning.Models.MachineLearningDatastoreCollectionGetAllOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearning.MachineLearningDatastoreResource> GetAll(string skip = null, int? count = default(int?), bool? isDefault = default(bool?), System.Collections.Generic.IEnumerable<string> names = null, string searchText = null, string orderBy = null, bool? orderByAsc = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearning.MachineLearningDatastoreResource> GetAllAsync(Azure.ResourceManager.MachineLearning.Models.MachineLearningDatastoreCollectionGetAllOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearning.MachineLearningDataVersionResource> GetAll(string orderBy = null, int? top = default(int?), string skip = null, string tags = null, Azure.ResourceManager.MachineLearning.Models.MachineLearningListViewType? listViewType = default(Azure.ResourceManager.MachineLearning.Models.MachineLearningListViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearning.MachineLearningDataVersionResource> GetAllAsync(string orderBy = null, int? top = default(int?), string skip = null, string tags = null, Azure.ResourceManager.MachineLearning.Models.MachineLearningListViewType? listViewType = default(Azure.ResourceManager.MachineLearning.Models.MachineLearningListViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearning.MachineLearningEnvironmentContainerResource> GetAll(string skip = null, Azure.ResourceManager.MachineLearning.Models.MachineLearningListViewType? listViewType = default(Azure.ResourceManager.MachineLearning.Models.MachineLearningListViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearning.MachineLearningEnvironmentContainerResource> GetAllAsync(string skip = null, Azure.ResourceManager.MachineLearning.Models.MachineLearningListViewType? listViewType = default(Azure.ResourceManager.MachineLearning.Models.MachineLearningListViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearning.MachineLearningEnvironmentVersionResource> GetAll(string orderBy = null, int? top = default(int?), string skip = null, Azure.ResourceManager.MachineLearning.Models.MachineLearningListViewType? listViewType = default(Azure.ResourceManager.MachineLearning.Models.MachineLearningListViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearning.MachineLearningEnvironmentVersionResource> GetAllAsync(string orderBy = null, int? top = default(int?), string skip = null, Azure.ResourceManager.MachineLearning.Models.MachineLearningListViewType? listViewType = default(Azure.ResourceManager.MachineLearning.Models.MachineLearningListViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearning.MachineLearningJobResource> GetAll(string skip = null, string jobType = null, string tag = null, Azure.ResourceManager.MachineLearning.Models.MachineLearningListViewType? listViewType = default(Azure.ResourceManager.MachineLearning.Models.MachineLearningListViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearning.MachineLearningJobResource> GetAllAsync(string skip = null, string jobType = null, string tag = null, Azure.ResourceManager.MachineLearning.Models.MachineLearningListViewType? listViewType = default(Azure.ResourceManager.MachineLearning.Models.MachineLearningListViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearning.MachineLearningModelContainerResource> GetAll(string skip = null, int? count = default(int?), Azure.ResourceManager.MachineLearning.Models.MachineLearningListViewType? listViewType = default(Azure.ResourceManager.MachineLearning.Models.MachineLearningListViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearning.MachineLearningModelContainerResource> GetAllAsync(string skip = null, int? count = default(int?), Azure.ResourceManager.MachineLearning.Models.MachineLearningListViewType? listViewType = default(Azure.ResourceManager.MachineLearning.Models.MachineLearningListViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearning.MachineLearningModelVersionResource> GetAll(Azure.ResourceManager.MachineLearning.Models.MachineLearningModelVersionCollectionGetAllOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearning.MachineLearningModelVersionResource> GetAll(string skip = null, string orderBy = null, int? top = default(int?), string version = null, string description = null, int? offset = default(int?), string tags = null, string properties = null, string feed = null, Azure.ResourceManager.MachineLearning.Models.MachineLearningListViewType? listViewType = default(Azure.ResourceManager.MachineLearning.Models.MachineLearningListViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearning.MachineLearningModelVersionResource> GetAllAsync(Azure.ResourceManager.MachineLearning.Models.MachineLearningModelVersionCollectionGetAllOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearning.MachineLearningModelVersionResource> GetAllAsync(string skip = null, string orderBy = null, int? top = default(int?), string version = null, string description = null, int? offset = default(int?), string tags = null, string properties = null, string feed = null, Azure.ResourceManager.MachineLearning.Models.MachineLearningListViewType? listViewType = default(Azure.ResourceManager.MachineLearning.Models.MachineLearningListViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearning.Models.MachineLearningSkuDetail> GetSkus(int? count = default(int?), string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearning.Models.MachineLearningSkuDetail> GetSkusAsync(int? count = default(int?), string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearning.MachineLearningOnlineEndpointResource> GetAll(Azure.ResourceManager.MachineLearning.Models.MachineLearningOnlineEndpointCollectionGetAllOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearning.MachineLearningOnlineEndpointResource> GetAll(string name = null, int? count = default(int?), Azure.ResourceManager.MachineLearning.Models.MachineLearningEndpointComputeType? computeType = default(Azure.ResourceManager.MachineLearning.Models.MachineLearningEndpointComputeType?), string skip = null, string tags = null, string properties = null, Azure.ResourceManager.MachineLearning.Models.MachineLearningOrderString? orderBy = default(Azure.ResourceManager.MachineLearning.Models.MachineLearningOrderString?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearning.MachineLearningOnlineEndpointResource> GetAllAsync(Azure.ResourceManager.MachineLearning.Models.MachineLearningOnlineEndpointCollectionGetAllOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearning.MachineLearningOnlineEndpointResource> GetAllAsync(string name = null, int? count = default(int?), Azure.ResourceManager.MachineLearning.Models.MachineLearningEndpointComputeType? computeType = default(Azure.ResourceManager.MachineLearning.Models.MachineLearningEndpointComputeType?), string skip = null, string tags = null, string properties = null, Azure.ResourceManager.MachineLearning.Models.MachineLearningOrderString? orderBy = default(Azure.ResourceManager.MachineLearning.Models.MachineLearningOrderString?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.Models.MachineLearningEndpointAuthKeys> GetKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.Models.MachineLearningEndpointAuthKeys>> GetKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningOnlineDeploymentResource> GetMachineLearningOnlineDeployment(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.MachineLearningOnlineDeploymentResource>> GetMachineLearningOnlineDeploymentAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearning.MachineLearningOnlineDeploymentCollection GetMachineLearningOnlineDeployments() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearning.Models.MachineLearningEndpointAuthToken> GetToken(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearning.Models.MachineLearningEndpointAuthToken>> GetTokenAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RegenerateKeys(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.Models.MachineLearningEndpointKeyRegenerateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RegenerateKeysAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MachineLearning.Models.MachineLearningEndpointKeyRegenerateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningPrivateEndpoint PrivateEndpoint { get { throw null; } set { } }
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
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearning.MachineLearningScheduleResource> GetAll(string skip = null, Azure.ResourceManager.MachineLearning.Models.MachineLearningScheduleListViewType? listViewType = default(Azure.ResourceManager.MachineLearning.Models.MachineLearningScheduleListViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearning.MachineLearningScheduleResource> GetAllAsync(string skip = null, Azure.ResourceManager.MachineLearning.Models.MachineLearningScheduleListViewType? listViewType = default(Azure.ResourceManager.MachineLearning.Models.MachineLearningScheduleListViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public string ImageBuildCompute { get { throw null; } set { } }
        public bool? IsHbiWorkspace { get { throw null; } set { } }
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
    public partial class AmlCompute : Azure.ResourceManager.MachineLearning.Models.MachineLearningComputeProperties
    {
        public AmlCompute() { }
        public Azure.ResourceManager.MachineLearning.Models.AmlComputeProperties Properties { get { throw null; } set { } }
    }
    public partial class AmlComputeNodeInformation
    {
        internal AmlComputeNodeInformation() { }
        public string NodeId { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningNodeState? NodeState { get { throw null; } }
        public int? Port { get { throw null; } }
        public System.Net.IPAddress PrivateIPAddress { get { throw null; } }
        public System.Net.IPAddress PublicIPAddress { get { throw null; } }
        public string RunId { get { throw null; } }
    }
    public partial class AmlComputeProperties
    {
        public AmlComputeProperties() { }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningAllocationState? AllocationState { get { throw null; } }
        public System.DateTimeOffset? AllocationStateTransitionOn { get { throw null; } }
        public int? CurrentNodeCount { get { throw null; } }
        public bool? EnableNodePublicIP { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearning.Models.MachineLearningError> Errors { get { throw null; } }
        public bool? IsolatedNetwork { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningNodeStateCounts NodeStateCounts { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningOSType? OSType { get { throw null; } set { } }
        public System.BinaryData PropertyBag { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningRemoteLoginPortPublicAccess? RemoteLoginPortPublicAccess { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.AmlComputeScaleSettings ScaleSettings { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
        public int? TargetNodeCount { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningUserAccountCredentials UserAccountCredentials { get { throw null; } set { } }
        public string VirtualMachineImageId { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningVmPriority? VmPriority { get { throw null; } set { } }
        public string VmSize { get { throw null; } set { } }
    }
    public partial class AmlComputeScaleSettings
    {
        public AmlComputeScaleSettings(int maxNodeCount) { }
        public int MaxNodeCount { get { throw null; } set { } }
        public int? MinNodeCount { get { throw null; } set { } }
        public System.TimeSpan? NodeIdleTimeBeforeScaleDown { get { throw null; } set { } }
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
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.MachineLearning.Models.MachineLearningJobOutput> Outputs { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningJobResourceConfiguration Resources { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.AutoMLVertical TaskDetails { get { throw null; } set { } }
    }
    public abstract partial class AutoMLVertical
    {
        protected AutoMLVertical(Azure.ResourceManager.MachineLearning.Models.MachineLearningTableJobInput trainingData) { }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningLogVerbosity? LogVerbosity { get { throw null; } set { } }
        public string TargetColumnName { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningTableJobInput TrainingData { get { throw null; } set { } }
    }
    public partial class AutoMLVerticalRegression : Azure.ResourceManager.MachineLearning.Models.AutoMLVertical
    {
        public AutoMLVerticalRegression(Azure.ResourceManager.MachineLearning.Models.MachineLearningTableJobInput trainingData) : base (default(Azure.ResourceManager.MachineLearning.Models.MachineLearningTableJobInput)) { }
        public System.Collections.Generic.IList<string> CvSplitColumnNames { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.TableVerticalFeaturizationSettings FeaturizationSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.TableVerticalLimitSettings LimitSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.NCrossValidations NCrossValidations { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.AutoMLVerticalRegressionPrimaryMetric? PrimaryMetric { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningTableJobInput TestData { get { throw null; } set { } }
        public double? TestDataSize { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.RegressionTrainingSettings TrainingSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningTableJobInput ValidationData { get { throw null; } set { } }
        public double? ValidationDataSize { get { throw null; } set { } }
        public string WeightColumnName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AutoMLVerticalRegressionModel : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.AutoMLVerticalRegressionModel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AutoMLVerticalRegressionModel(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.AutoMLVerticalRegressionModel DecisionTree { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.AutoMLVerticalRegressionModel ElasticNet { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.AutoMLVerticalRegressionModel ExtremeRandomTrees { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.AutoMLVerticalRegressionModel GradientBoosting { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.AutoMLVerticalRegressionModel KNN { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.AutoMLVerticalRegressionModel LassoLars { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.AutoMLVerticalRegressionModel LightGBM { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.AutoMLVerticalRegressionModel RandomForest { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.AutoMLVerticalRegressionModel SGD { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.AutoMLVerticalRegressionModel XGBoostRegressor { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.AutoMLVerticalRegressionModel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.AutoMLVerticalRegressionModel left, Azure.ResourceManager.MachineLearning.Models.AutoMLVerticalRegressionModel right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.AutoMLVerticalRegressionModel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.AutoMLVerticalRegressionModel left, Azure.ResourceManager.MachineLearning.Models.AutoMLVerticalRegressionModel right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AutoMLVerticalRegressionPrimaryMetric : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.AutoMLVerticalRegressionPrimaryMetric>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AutoMLVerticalRegressionPrimaryMetric(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.AutoMLVerticalRegressionPrimaryMetric NormalizedMeanAbsoluteError { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.AutoMLVerticalRegressionPrimaryMetric NormalizedRootMeanSquaredError { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.AutoMLVerticalRegressionPrimaryMetric R2Score { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.AutoMLVerticalRegressionPrimaryMetric SpearmanCorrelation { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.AutoMLVerticalRegressionPrimaryMetric other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.AutoMLVerticalRegressionPrimaryMetric left, Azure.ResourceManager.MachineLearning.Models.AutoMLVerticalRegressionPrimaryMetric right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.AutoMLVerticalRegressionPrimaryMetric (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.AutoMLVerticalRegressionPrimaryMetric left, Azure.ResourceManager.MachineLearning.Models.AutoMLVerticalRegressionPrimaryMetric right) { throw null; }
        public override string ToString() { throw null; }
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
    public partial class AutoSeasonality : Azure.ResourceManager.MachineLearning.Models.ForecastingSeasonality
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
    public partial class BanditPolicy : Azure.ResourceManager.MachineLearning.Models.MachineLearningEarlyTerminationPolicy
    {
        public BanditPolicy() { }
        public float? SlackAmount { get { throw null; } set { } }
        public float? SlackFactor { get { throw null; } set { } }
    }
    public partial class BayesianSamplingAlgorithm : Azure.ResourceManager.MachineLearning.Models.SamplingAlgorithm
    {
        public BayesianSamplingAlgorithm() { }
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
    public partial class ClassificationTask : Azure.ResourceManager.MachineLearning.Models.AutoMLVertical
    {
        public ClassificationTask(Azure.ResourceManager.MachineLearning.Models.MachineLearningTableJobInput trainingData) : base (default(Azure.ResourceManager.MachineLearning.Models.MachineLearningTableJobInput)) { }
        public System.Collections.Generic.IList<string> CvSplitColumnNames { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.TableVerticalFeaturizationSettings FeaturizationSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.TableVerticalLimitSettings LimitSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.NCrossValidations NCrossValidations { get { throw null; } set { } }
        public string PositiveLabel { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ClassificationPrimaryMetric? PrimaryMetric { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningTableJobInput TestData { get { throw null; } set { } }
        public double? TestDataSize { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ClassificationTrainingSettings TrainingSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningTableJobInput ValidationData { get { throw null; } set { } }
        public double? ValidationDataSize { get { throw null; } set { } }
        public string WeightColumnName { get { throw null; } set { } }
    }
    public partial class ClassificationTrainingSettings : Azure.ResourceManager.MachineLearning.Models.MachineLearningTrainingSettings
    {
        public ClassificationTrainingSettings() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.MachineLearning.Models.ClassificationModel> AllowedTrainingAlgorithms { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.MachineLearning.Models.ClassificationModel> BlockedTrainingAlgorithms { get { throw null; } set { } }
    }
    public partial class ColumnTransformer
    {
        public ColumnTransformer() { }
        public System.Collections.Generic.IList<string> Fields { get { throw null; } set { } }
        public System.BinaryData Parameters { get { throw null; } set { } }
    }
    public partial class CronTrigger : Azure.ResourceManager.MachineLearning.Models.MachineLearningTriggerBase
    {
        public CronTrigger(string expression) { }
        public string Expression { get { throw null; } set { } }
    }
    public partial class CustomForecastHorizon : Azure.ResourceManager.MachineLearning.Models.ForecastHorizon
    {
        public CustomForecastHorizon(int value) { }
        public int Value { get { throw null; } set { } }
    }
    public partial class CustomNCrossValidations : Azure.ResourceManager.MachineLearning.Models.NCrossValidations
    {
        public CustomNCrossValidations(int value) { }
        public int Value { get { throw null; } set { } }
    }
    public partial class CustomSeasonality : Azure.ResourceManager.MachineLearning.Models.ForecastingSeasonality
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
    public abstract partial class ForecastHorizon
    {
        protected ForecastHorizon() { }
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
    public abstract partial class ForecastingSeasonality
    {
        protected ForecastingSeasonality() { }
    }
    public partial class ForecastingSettings
    {
        public ForecastingSettings() { }
        public string CountryOrRegionForHolidays { get { throw null; } set { } }
        public int? CvStepSize { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningFeatureLag? FeatureLags { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ForecastHorizon ForecastHorizon { get { throw null; } set { } }
        public string Frequency { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ForecastingSeasonality Seasonality { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningShortSeriesHandlingConfiguration? ShortSeriesHandlingConfig { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.TargetAggregationFunction? TargetAggregateFunction { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.TargetLags TargetLags { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.TargetRollingWindowSize TargetRollingWindowSize { get { throw null; } set { } }
        public string TimeColumnName { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> TimeSeriesIdColumnNames { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningUseStl? UseStl { get { throw null; } set { } }
    }
    public partial class ForecastingTrainingSettings : Azure.ResourceManager.MachineLearning.Models.MachineLearningTrainingSettings
    {
        public ForecastingTrainingSettings() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.MachineLearning.Models.ForecastingModel> AllowedTrainingAlgorithms { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.MachineLearning.Models.ForecastingModel> BlockedTrainingAlgorithms { get { throw null; } set { } }
    }
    public partial class GridSamplingAlgorithm : Azure.ResourceManager.MachineLearning.Models.SamplingAlgorithm
    {
        public GridSamplingAlgorithm() { }
    }
    public partial class ImageClassification : Azure.ResourceManager.MachineLearning.Models.AutoMLVertical
    {
        public ImageClassification(Azure.ResourceManager.MachineLearning.Models.MachineLearningTableJobInput trainingData, Azure.ResourceManager.MachineLearning.Models.ImageLimitSettings limitSettings) : base (default(Azure.ResourceManager.MachineLearning.Models.MachineLearningTableJobInput)) { }
        public Azure.ResourceManager.MachineLearning.Models.ImageLimitSettings LimitSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ImageModelSettingsClassification ModelSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ClassificationPrimaryMetric? PrimaryMetric { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.MachineLearning.Models.ImageModelDistributionSettingsClassification> SearchSpace { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ImageSweepSettings SweepSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningTableJobInput ValidationData { get { throw null; } set { } }
        public double? ValidationDataSize { get { throw null; } set { } }
    }
    public partial class ImageClassificationMultilabel : Azure.ResourceManager.MachineLearning.Models.AutoMLVertical
    {
        public ImageClassificationMultilabel(Azure.ResourceManager.MachineLearning.Models.MachineLearningTableJobInput trainingData, Azure.ResourceManager.MachineLearning.Models.ImageLimitSettings limitSettings) : base (default(Azure.ResourceManager.MachineLearning.Models.MachineLearningTableJobInput)) { }
        public Azure.ResourceManager.MachineLearning.Models.ImageLimitSettings LimitSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ImageModelSettingsClassification ModelSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ClassificationMultilabelPrimaryMetric? PrimaryMetric { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.MachineLearning.Models.ImageModelDistributionSettingsClassification> SearchSpace { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ImageSweepSettings SweepSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningTableJobInput ValidationData { get { throw null; } set { } }
        public double? ValidationDataSize { get { throw null; } set { } }
    }
    public partial class ImageInstanceSegmentation : Azure.ResourceManager.MachineLearning.Models.AutoMLVertical
    {
        public ImageInstanceSegmentation(Azure.ResourceManager.MachineLearning.Models.MachineLearningTableJobInput trainingData, Azure.ResourceManager.MachineLearning.Models.ImageLimitSettings limitSettings) : base (default(Azure.ResourceManager.MachineLearning.Models.MachineLearningTableJobInput)) { }
        public Azure.ResourceManager.MachineLearning.Models.ImageLimitSettings LimitSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ImageModelSettingsObjectDetection ModelSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.InstanceSegmentationPrimaryMetric? PrimaryMetric { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.MachineLearning.Models.ImageModelDistributionSettingsObjectDetection> SearchSpace { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ImageSweepSettings SweepSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningTableJobInput ValidationData { get { throw null; } set { } }
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
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningFlowModelJobInput CheckpointModel { get { throw null; } set { } }
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
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningModelSize? ModelSize { get { throw null; } set { } }
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
        public ImageObjectDetection(Azure.ResourceManager.MachineLearning.Models.MachineLearningTableJobInput trainingData, Azure.ResourceManager.MachineLearning.Models.ImageLimitSettings limitSettings) : base (default(Azure.ResourceManager.MachineLearning.Models.MachineLearningTableJobInput)) { }
        public Azure.ResourceManager.MachineLearning.Models.ImageLimitSettings LimitSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ImageModelSettingsObjectDetection ModelSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ObjectDetectionPrimaryMetric? PrimaryMetric { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.MachineLearning.Models.ImageModelDistributionSettingsObjectDetection> SearchSpace { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ImageSweepSettings SweepSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningTableJobInput ValidationData { get { throw null; } set { } }
        public double? ValidationDataSize { get { throw null; } set { } }
    }
    public partial class ImageSweepSettings
    {
        public ImageSweepSettings(Azure.ResourceManager.MachineLearning.Models.SamplingAlgorithmType samplingAlgorithm) { }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningEarlyTerminationPolicy EarlyTermination { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.SamplingAlgorithmType SamplingAlgorithm { get { throw null; } set { } }
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
    public readonly partial struct MachineLearningAllocationState : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.MachineLearningAllocationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MachineLearningAllocationState(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningAllocationState Resizing { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningAllocationState Steady { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.MachineLearningAllocationState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.MachineLearningAllocationState left, Azure.ResourceManager.MachineLearning.Models.MachineLearningAllocationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.MachineLearningAllocationState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.MachineLearningAllocationState left, Azure.ResourceManager.MachineLearning.Models.MachineLearningAllocationState right) { throw null; }
        public override string ToString() { throw null; }
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
    public partial class MachineLearningAutoScaleProperties
    {
        public MachineLearningAutoScaleProperties() { }
        public bool? IsEnabled { get { throw null; } set { } }
        public int? MaxNodeCount { get { throw null; } set { } }
        public int? MinNodeCount { get { throw null; } set { } }
    }
    public partial class MachineLearningAzureBlobDatastore : Azure.ResourceManager.MachineLearning.Models.MachineLearningDatastoreProperties
    {
        public MachineLearningAzureBlobDatastore(Azure.ResourceManager.MachineLearning.Models.MachineLearningDatastoreCredentials credentials) : base (default(Azure.ResourceManager.MachineLearning.Models.MachineLearningDatastoreCredentials)) { }
        public string AccountName { get { throw null; } set { } }
        public string ContainerName { get { throw null; } set { } }
        public string Endpoint { get { throw null; } set { } }
        public string Protocol { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningServiceDataAccessAuthIdentity? ServiceDataAccessAuthIdentity { get { throw null; } set { } }
    }
    public partial class MachineLearningAzureDataLakeGen1Datastore : Azure.ResourceManager.MachineLearning.Models.MachineLearningDatastoreProperties
    {
        public MachineLearningAzureDataLakeGen1Datastore(Azure.ResourceManager.MachineLearning.Models.MachineLearningDatastoreCredentials credentials, string storeName) : base (default(Azure.ResourceManager.MachineLearning.Models.MachineLearningDatastoreCredentials)) { }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningServiceDataAccessAuthIdentity? ServiceDataAccessAuthIdentity { get { throw null; } set { } }
        public string StoreName { get { throw null; } set { } }
    }
    public partial class MachineLearningAzureDataLakeGen2Datastore : Azure.ResourceManager.MachineLearning.Models.MachineLearningDatastoreProperties
    {
        public MachineLearningAzureDataLakeGen2Datastore(Azure.ResourceManager.MachineLearning.Models.MachineLearningDatastoreCredentials credentials, string accountName, string filesystem) : base (default(Azure.ResourceManager.MachineLearning.Models.MachineLearningDatastoreCredentials)) { }
        public string AccountName { get { throw null; } set { } }
        public string Endpoint { get { throw null; } set { } }
        public string Filesystem { get { throw null; } set { } }
        public string Protocol { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningServiceDataAccessAuthIdentity? ServiceDataAccessAuthIdentity { get { throw null; } set { } }
    }
    public partial class MachineLearningAzureFileDatastore : Azure.ResourceManager.MachineLearning.Models.MachineLearningDatastoreProperties
    {
        public MachineLearningAzureFileDatastore(Azure.ResourceManager.MachineLearning.Models.MachineLearningDatastoreCredentials credentials, string accountName, string fileShareName) : base (default(Azure.ResourceManager.MachineLearning.Models.MachineLearningDatastoreCredentials)) { }
        public string AccountName { get { throw null; } set { } }
        public string Endpoint { get { throw null; } set { } }
        public string FileShareName { get { throw null; } set { } }
        public string Protocol { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningServiceDataAccessAuthIdentity? ServiceDataAccessAuthIdentity { get { throw null; } set { } }
    }
    public partial class MachineLearningBatchDeploymentPatch
    {
        public MachineLearningBatchDeploymentPatch() { }
        public string PartialBatchDeploymentDescription { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class MachineLearningBatchDeploymentProperties : Azure.ResourceManager.MachineLearning.Models.MachineLearningEndpointDeploymentProperties
    {
        public MachineLearningBatchDeploymentProperties() { }
        public string Compute { get { throw null; } set { } }
        public int? ErrorThreshold { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningBatchLoggingLevel? LoggingLevel { get { throw null; } set { } }
        public int? MaxConcurrencyPerInstance { get { throw null; } set { } }
        public long? MiniBatchSize { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningAssetReferenceBase Model { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningBatchOutputAction? OutputAction { get { throw null; } set { } }
        public string OutputFileName { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningDeploymentProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningDeploymentResourceConfiguration Resources { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningBatchRetrySettings RetrySettings { get { throw null; } set { } }
    }
    public partial class MachineLearningBatchEndpointProperties : Azure.ResourceManager.MachineLearning.Models.MachineLearningEndpointProperties
    {
        public MachineLearningBatchEndpointProperties(Azure.ResourceManager.MachineLearning.Models.MachineLearningEndpointAuthMode authMode) : base (default(Azure.ResourceManager.MachineLearning.Models.MachineLearningEndpointAuthMode)) { }
        public string DefaultsDeploymentName { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningEndpointProvisioningState? ProvisioningState { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MachineLearningBatchLoggingLevel : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.MachineLearningBatchLoggingLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MachineLearningBatchLoggingLevel(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningBatchLoggingLevel Debug { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningBatchLoggingLevel Info { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningBatchLoggingLevel Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.MachineLearningBatchLoggingLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.MachineLearningBatchLoggingLevel left, Azure.ResourceManager.MachineLearning.Models.MachineLearningBatchLoggingLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.MachineLearningBatchLoggingLevel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.MachineLearningBatchLoggingLevel left, Azure.ResourceManager.MachineLearning.Models.MachineLearningBatchLoggingLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MachineLearningBatchOutputAction : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.MachineLearningBatchOutputAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MachineLearningBatchOutputAction(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningBatchOutputAction AppendRow { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningBatchOutputAction SummaryOnly { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.MachineLearningBatchOutputAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.MachineLearningBatchOutputAction left, Azure.ResourceManager.MachineLearning.Models.MachineLearningBatchOutputAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.MachineLearningBatchOutputAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.MachineLearningBatchOutputAction left, Azure.ResourceManager.MachineLearning.Models.MachineLearningBatchOutputAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MachineLearningBatchRetrySettings
    {
        public MachineLearningBatchRetrySettings() { }
        public int? MaxRetries { get { throw null; } set { } }
        public System.TimeSpan? Timeout { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MachineLearningBillingCurrency : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.MachineLearningBillingCurrency>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MachineLearningBillingCurrency(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningBillingCurrency Usd { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.MachineLearningBillingCurrency other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.MachineLearningBillingCurrency left, Azure.ResourceManager.MachineLearning.Models.MachineLearningBillingCurrency right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.MachineLearningBillingCurrency (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.MachineLearningBillingCurrency left, Azure.ResourceManager.MachineLearning.Models.MachineLearningBillingCurrency right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MachineLearningBuildContext
    {
        public MachineLearningBuildContext(System.Uri contextUri) { }
        public System.Uri ContextUri { get { throw null; } set { } }
        public string DockerfilePath { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MachineLearningCachingType : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.MachineLearningCachingType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MachineLearningCachingType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningCachingType None { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningCachingType ReadOnly { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningCachingType ReadWrite { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.MachineLearningCachingType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.MachineLearningCachingType left, Azure.ResourceManager.MachineLearning.Models.MachineLearningCachingType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.MachineLearningCachingType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.MachineLearningCachingType left, Azure.ResourceManager.MachineLearning.Models.MachineLearningCachingType right) { throw null; }
        public override string ToString() { throw null; }
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
    public partial class MachineLearningCodeConfiguration
    {
        public MachineLearningCodeConfiguration(string scoringScript) { }
        public Azure.Core.ResourceIdentifier CodeId { get { throw null; } set { } }
        public string ScoringScript { get { throw null; } set { } }
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
        public MachineLearningCommandJob(string command, Azure.Core.ResourceIdentifier environmentId) { }
        public Azure.Core.ResourceIdentifier CodeId { get { throw null; } set { } }
        public string Command { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningDistributionConfiguration Distribution { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier EnvironmentId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> EnvironmentVariables { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.MachineLearning.Models.MachineLearningJobInput> Inputs { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningCommandJobLimits Limits { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.MachineLearning.Models.MachineLearningJobOutput> Outputs { get { throw null; } set { } }
        public System.BinaryData Parameters { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningJobResourceConfiguration Resources { get { throw null; } set { } }
    }
    public partial class MachineLearningCommandJobLimits : Azure.ResourceManager.MachineLearning.Models.MachineLearningJobLimits
    {
        public MachineLearningCommandJobLimits() { }
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
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningCachingType? Caching { get { throw null; } }
        public int? DiskSizeGB { get { throw null; } }
        public int? Lun { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningStorageAccountType? StorageAccountType { get { throw null; } }
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
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearning.Models.MachineLearningError> Errors { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningComputeInstanceLastOperation LastOperation { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningComputeInstanceAssignedUser PersonalComputeInstanceAssignedUser { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearning.Models.MachineLearningComputeStartStopSchedule> SchedulesComputeStartStop { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningScriptsToExecute Scripts { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningComputeInstanceSshSettings SshSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningComputeInstanceState? State { get { throw null; } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
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
        public Azure.ResourceManager.MachineLearning.Models.AmlComputeScaleSettings ScaleSettings { get { throw null; } set { } }
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
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearning.Models.MachineLearningError> ProvisioningErrors { get { throw null; } }
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
    public partial class MachineLearningContainerResourceRequirements
    {
        public MachineLearningContainerResourceRequirements() { }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningContainerResourceSettings ContainerResourceLimits { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningContainerResourceSettings ContainerResourceRequests { get { throw null; } set { } }
    }
    public partial class MachineLearningContainerResourceSettings
    {
        public MachineLearningContainerResourceSettings() { }
        public string Cpu { get { throw null; } set { } }
        public string Gpu { get { throw null; } set { } }
        public string Memory { get { throw null; } set { } }
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
    public partial class MachineLearningCustomModelJobInput : Azure.ResourceManager.MachineLearning.Models.MachineLearningJobInput
    {
        public MachineLearningCustomModelJobInput(System.Uri uri) { }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningInputDeliveryMode? Mode { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    public partial class MachineLearningCustomModelJobOutput : Azure.ResourceManager.MachineLearning.Models.MachineLearningJobOutput
    {
        public MachineLearningCustomModelJobOutput() { }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningOutputDeliveryMode? Mode { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
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
        public MachineLearningDataContainerProperties(Azure.ResourceManager.MachineLearning.Models.MachineLearningDataType dataType) { }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningDataType DataType { get { throw null; } set { } }
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
    public partial class MachineLearningDatastoreCollectionGetAllOptions
    {
        public MachineLearningDatastoreCollectionGetAllOptions() { }
        public int? Count { get { throw null; } set { } }
        public bool? IsDefault { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Names { get { throw null; } }
        public string OrderBy { get { throw null; } set { } }
        public bool? OrderByAsc { get { throw null; } set { } }
        public string SearchText { get { throw null; } set { } }
        public string Skip { get { throw null; } set { } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MachineLearningDataType : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.MachineLearningDataType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MachineLearningDataType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningDataType Mltable { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningDataType UriFile { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningDataType UriFolder { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.MachineLearningDataType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.MachineLearningDataType left, Azure.ResourceManager.MachineLearning.Models.MachineLearningDataType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.MachineLearningDataType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.MachineLearningDataType left, Azure.ResourceManager.MachineLearning.Models.MachineLearningDataType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MachineLearningDataVersionProperties : Azure.ResourceManager.MachineLearning.Models.MachineLearningAssetBase
    {
        public MachineLearningDataVersionProperties(System.Uri dataUri) { }
        public System.Uri DataUri { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MachineLearningDayOfWeek : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.MachineLearningDayOfWeek>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MachineLearningDayOfWeek(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningDayOfWeek Friday { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningDayOfWeek Monday { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningDayOfWeek Saturday { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningDayOfWeek Sunday { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningDayOfWeek Thursday { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningDayOfWeek Tuesday { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningDayOfWeek Wednesday { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.MachineLearningDayOfWeek other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.MachineLearningDayOfWeek left, Azure.ResourceManager.MachineLearning.Models.MachineLearningDayOfWeek right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.MachineLearningDayOfWeek (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.MachineLearningDayOfWeek left, Azure.ResourceManager.MachineLearning.Models.MachineLearningDayOfWeek right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MachineLearningDefaultScaleSettings : Azure.ResourceManager.MachineLearning.Models.MachineLearningOnlineScaleSettings
    {
        public MachineLearningDefaultScaleSettings() { }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MachineLearningDeploymentProvisioningState : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.MachineLearningDeploymentProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MachineLearningDeploymentProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningDeploymentProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningDeploymentProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningDeploymentProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningDeploymentProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningDeploymentProvisioningState Scaling { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningDeploymentProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningDeploymentProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.MachineLearningDeploymentProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.MachineLearningDeploymentProvisioningState left, Azure.ResourceManager.MachineLearning.Models.MachineLearningDeploymentProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.MachineLearningDeploymentProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.MachineLearningDeploymentProvisioningState left, Azure.ResourceManager.MachineLearning.Models.MachineLearningDeploymentProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MachineLearningDeploymentResourceConfiguration : Azure.ResourceManager.MachineLearning.Models.MachineLearningResourceConfiguration
    {
        public MachineLearningDeploymentResourceConfiguration() { }
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
    public abstract partial class MachineLearningDistributionConfiguration
    {
        protected MachineLearningDistributionConfiguration() { }
    }
    public abstract partial class MachineLearningEarlyTerminationPolicy
    {
        protected MachineLearningEarlyTerminationPolicy() { }
        public int? DelayEvaluation { get { throw null; } set { } }
        public int? EvaluationInterval { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MachineLearningEgressPublicNetworkAccessType : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.MachineLearningEgressPublicNetworkAccessType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MachineLearningEgressPublicNetworkAccessType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningEgressPublicNetworkAccessType Disabled { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningEgressPublicNetworkAccessType Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.MachineLearningEgressPublicNetworkAccessType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.MachineLearningEgressPublicNetworkAccessType left, Azure.ResourceManager.MachineLearning.Models.MachineLearningEgressPublicNetworkAccessType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.MachineLearningEgressPublicNetworkAccessType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.MachineLearningEgressPublicNetworkAccessType left, Azure.ResourceManager.MachineLearning.Models.MachineLearningEgressPublicNetworkAccessType right) { throw null; }
        public override string ToString() { throw null; }
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
    public partial class MachineLearningEndpointAuthKeys
    {
        public MachineLearningEndpointAuthKeys() { }
        public string PrimaryKey { get { throw null; } set { } }
        public string SecondaryKey { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MachineLearningEndpointAuthMode : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.MachineLearningEndpointAuthMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MachineLearningEndpointAuthMode(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningEndpointAuthMode AadToken { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningEndpointAuthMode AmlToken { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningEndpointAuthMode Key { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.MachineLearningEndpointAuthMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.MachineLearningEndpointAuthMode left, Azure.ResourceManager.MachineLearning.Models.MachineLearningEndpointAuthMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.MachineLearningEndpointAuthMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.MachineLearningEndpointAuthMode left, Azure.ResourceManager.MachineLearning.Models.MachineLearningEndpointAuthMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MachineLearningEndpointAuthToken
    {
        internal MachineLearningEndpointAuthToken() { }
        public string AccessToken { get { throw null; } }
        public System.DateTimeOffset? ExpireOn { get { throw null; } }
        public System.DateTimeOffset? RefreshOn { get { throw null; } }
        public string TokenType { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MachineLearningEndpointComputeType : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.MachineLearningEndpointComputeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MachineLearningEndpointComputeType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningEndpointComputeType AmlCompute { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningEndpointComputeType Kubernetes { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningEndpointComputeType Managed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.MachineLearningEndpointComputeType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.MachineLearningEndpointComputeType left, Azure.ResourceManager.MachineLearning.Models.MachineLearningEndpointComputeType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.MachineLearningEndpointComputeType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.MachineLearningEndpointComputeType left, Azure.ResourceManager.MachineLearning.Models.MachineLearningEndpointComputeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MachineLearningEndpointDeploymentProperties
    {
        public MachineLearningEndpointDeploymentProperties() { }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningCodeConfiguration CodeConfiguration { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string EnvironmentId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> EnvironmentVariables { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Properties { get { throw null; } set { } }
    }
    public partial class MachineLearningEndpointKeyRegenerateContent
    {
        public MachineLearningEndpointKeyRegenerateContent(Azure.ResourceManager.MachineLearning.Models.MachineLearningKeyType keyType) { }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningKeyType KeyType { get { throw null; } }
        public string KeyValue { get { throw null; } set { } }
    }
    public partial class MachineLearningEndpointProperties
    {
        public MachineLearningEndpointProperties(Azure.ResourceManager.MachineLearning.Models.MachineLearningEndpointAuthMode authMode) { }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningEndpointAuthMode AuthMode { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningEndpointAuthKeys Keys { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Properties { get { throw null; } set { } }
        public System.Uri ScoringUri { get { throw null; } }
        public System.Uri SwaggerUri { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MachineLearningEndpointProvisioningState : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.MachineLearningEndpointProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MachineLearningEndpointProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningEndpointProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningEndpointProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningEndpointProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningEndpointProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningEndpointProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningEndpointProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.MachineLearningEndpointProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.MachineLearningEndpointProvisioningState left, Azure.ResourceManager.MachineLearning.Models.MachineLearningEndpointProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.MachineLearningEndpointProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.MachineLearningEndpointProvisioningState left, Azure.ResourceManager.MachineLearning.Models.MachineLearningEndpointProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MachineLearningEndpointScheduleAction : Azure.ResourceManager.MachineLearning.Models.MachineLearningScheduleAction
    {
        public MachineLearningEndpointScheduleAction(System.BinaryData endpointInvocationDefinition) { }
        public System.BinaryData EndpointInvocationDefinition { get { throw null; } set { } }
    }
    public partial class MachineLearningEnvironmentContainerProperties : Azure.ResourceManager.MachineLearning.Models.MachineLearningAssetContainer
    {
        public MachineLearningEnvironmentContainerProperties() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MachineLearningEnvironmentType : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.MachineLearningEnvironmentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MachineLearningEnvironmentType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningEnvironmentType Curated { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningEnvironmentType UserCreated { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.MachineLearningEnvironmentType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.MachineLearningEnvironmentType left, Azure.ResourceManager.MachineLearning.Models.MachineLearningEnvironmentType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.MachineLearningEnvironmentType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.MachineLearningEnvironmentType left, Azure.ResourceManager.MachineLearning.Models.MachineLearningEnvironmentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MachineLearningEnvironmentVersionProperties : Azure.ResourceManager.MachineLearning.Models.MachineLearningAssetBase
    {
        public MachineLearningEnvironmentVersionProperties() { }
        public Azure.ResourceManager.MachineLearning.Models.AutoRebuildSetting? AutoRebuild { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningBuildContext Build { get { throw null; } set { } }
        public string CondaFile { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningEnvironmentType? EnvironmentType { get { throw null; } }
        public string Image { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningInferenceContainerProperties InferenceConfig { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningOperatingSystemType? OSType { get { throw null; } set { } }
    }
    public partial class MachineLearningError
    {
        internal MachineLearningError() { }
        public Azure.ResponseError Error { get { throw null; } }
    }
    public partial class MachineLearningEstimatedVmPrice
    {
        internal MachineLearningEstimatedVmPrice() { }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningVmPriceOSType OSType { get { throw null; } }
        public double RetailPrice { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningVmTier VmTier { get { throw null; } }
    }
    public partial class MachineLearningEstimatedVmPrices
    {
        internal MachineLearningEstimatedVmPrices() { }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningBillingCurrency BillingCurrency { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningUnitOfMeasure UnitOfMeasure { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearning.Models.MachineLearningEstimatedVmPrice> Values { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MachineLearningFeatureLag : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.MachineLearningFeatureLag>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MachineLearningFeatureLag(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningFeatureLag Auto { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningFeatureLag None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.MachineLearningFeatureLag other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.MachineLearningFeatureLag left, Azure.ResourceManager.MachineLearning.Models.MachineLearningFeatureLag right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.MachineLearningFeatureLag (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.MachineLearningFeatureLag left, Azure.ResourceManager.MachineLearning.Models.MachineLearningFeatureLag right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MachineLearningFeaturizationMode : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.MachineLearningFeaturizationMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MachineLearningFeaturizationMode(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningFeaturizationMode Auto { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningFeaturizationMode Custom { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningFeaturizationMode Off { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.MachineLearningFeaturizationMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.MachineLearningFeaturizationMode left, Azure.ResourceManager.MachineLearning.Models.MachineLearningFeaturizationMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.MachineLearningFeaturizationMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.MachineLearningFeaturizationMode left, Azure.ResourceManager.MachineLearning.Models.MachineLearningFeaturizationMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MachineLearningFeaturizationSettings
    {
        public MachineLearningFeaturizationSettings() { }
        public string DatasetLanguage { get { throw null; } set { } }
    }
    public partial class MachineLearningFlavorData
    {
        public MachineLearningFlavorData() { }
        public System.Collections.Generic.IDictionary<string, string> Data { get { throw null; } set { } }
    }
    public partial class MachineLearningFlowModelJobInput : Azure.ResourceManager.MachineLearning.Models.MachineLearningJobInput
    {
        public MachineLearningFlowModelJobInput(System.Uri uri) { }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningInputDeliveryMode? Mode { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    public partial class MachineLearningFlowModelJobOutput : Azure.ResourceManager.MachineLearning.Models.MachineLearningJobOutput
    {
        public MachineLearningFlowModelJobOutput() { }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningOutputDeliveryMode? Mode { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    public partial class MachineLearningForecasting : Azure.ResourceManager.MachineLearning.Models.AutoMLVertical
    {
        public MachineLearningForecasting(Azure.ResourceManager.MachineLearning.Models.MachineLearningTableJobInput trainingData) : base (default(Azure.ResourceManager.MachineLearning.Models.MachineLearningTableJobInput)) { }
        public System.Collections.Generic.IList<string> CvSplitColumnNames { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.TableVerticalFeaturizationSettings FeaturizationSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ForecastingSettings ForecastingSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.TableVerticalLimitSettings LimitSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.NCrossValidations NCrossValidations { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ForecastingPrimaryMetric? PrimaryMetric { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningTableJobInput TestData { get { throw null; } set { } }
        public double? TestDataSize { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ForecastingTrainingSettings TrainingSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningTableJobInput ValidationData { get { throw null; } set { } }
        public double? ValidationDataSize { get { throw null; } set { } }
        public string WeightColumnName { get { throw null; } set { } }
    }
    public partial class MachineLearningFqdnEndpoint
    {
        internal MachineLearningFqdnEndpoint() { }
        public string DomainName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearning.Models.MachineLearningFqdnEndpointDetail> EndpointDetails { get { throw null; } }
    }
    public partial class MachineLearningFqdnEndpointDetail
    {
        internal MachineLearningFqdnEndpointDetail() { }
        public int? Port { get { throw null; } }
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
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearning.Models.MachineLearningFqdnEndpoint> Endpoints { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MachineLearningGoal : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.MachineLearningGoal>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MachineLearningGoal(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningGoal Maximize { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningGoal Minimize { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.MachineLearningGoal other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.MachineLearningGoal left, Azure.ResourceManager.MachineLearning.Models.MachineLearningGoal right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.MachineLearningGoal (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.MachineLearningGoal left, Azure.ResourceManager.MachineLearning.Models.MachineLearningGoal right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MachineLearningHDInsightCompute : Azure.ResourceManager.MachineLearning.Models.MachineLearningComputeProperties
    {
        public MachineLearningHDInsightCompute() { }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningHDInsightProperties Properties { get { throw null; } set { } }
    }
    public partial class MachineLearningHDInsightProperties
    {
        public MachineLearningHDInsightProperties() { }
        public System.Net.IPAddress Address { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningVmSshCredentials AdministratorAccount { get { throw null; } set { } }
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
    public partial class MachineLearningInferenceContainerProperties
    {
        public MachineLearningInferenceContainerProperties() { }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningInferenceContainerRoute LivenessRoute { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningInferenceContainerRoute ReadinessRoute { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningInferenceContainerRoute ScoringRoute { get { throw null; } set { } }
    }
    public partial class MachineLearningInferenceContainerRoute
    {
        public MachineLearningInferenceContainerRoute(string path, int port) { }
        public string Path { get { throw null; } set { } }
        public int Port { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MachineLearningInputDeliveryMode : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.MachineLearningInputDeliveryMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MachineLearningInputDeliveryMode(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningInputDeliveryMode Direct { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningInputDeliveryMode Download { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningInputDeliveryMode EvalDownload { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningInputDeliveryMode EvalMount { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningInputDeliveryMode ReadOnlyMount { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningInputDeliveryMode ReadWriteMount { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.MachineLearningInputDeliveryMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.MachineLearningInputDeliveryMode left, Azure.ResourceManager.MachineLearning.Models.MachineLearningInputDeliveryMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.MachineLearningInputDeliveryMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.MachineLearningInputDeliveryMode left, Azure.ResourceManager.MachineLearning.Models.MachineLearningInputDeliveryMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MachineLearningInstanceTypeSchema
    {
        public MachineLearningInstanceTypeSchema() { }
        public System.Collections.Generic.IDictionary<string, string> NodeSelector { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningInstanceTypeSchemaResources Resources { get { throw null; } set { } }
    }
    public partial class MachineLearningInstanceTypeSchemaResources
    {
        public MachineLearningInstanceTypeSchemaResources() { }
        public System.Collections.Generic.IDictionary<string, string> Limits { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Requests { get { throw null; } }
    }
    public abstract partial class MachineLearningJobInput
    {
        protected MachineLearningJobInput() { }
        public string Description { get { throw null; } set { } }
    }
    public abstract partial class MachineLearningJobLimits
    {
        protected MachineLearningJobLimits() { }
        public System.TimeSpan? Timeout { get { throw null; } set { } }
    }
    public abstract partial class MachineLearningJobOutput
    {
        protected MachineLearningJobOutput() { }
        public string Description { get { throw null; } set { } }
    }
    public partial class MachineLearningJobProperties : Azure.ResourceManager.MachineLearning.Models.MachineLearningResourceBase
    {
        public MachineLearningJobProperties() { }
        public Azure.Core.ResourceIdentifier ComponentId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ComputeId { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string ExperimentName { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningIdentityConfiguration Identity { get { throw null; } set { } }
        public bool? IsArchived { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.MachineLearning.Models.MachineLearningJobService> Services { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningJobStatus? Status { get { throw null; } }
    }
    public partial class MachineLearningJobResourceConfiguration : Azure.ResourceManager.MachineLearning.Models.MachineLearningResourceConfiguration
    {
        public MachineLearningJobResourceConfiguration() { }
        public string DockerArgs { get { throw null; } set { } }
        public string ShmSize { get { throw null; } set { } }
    }
    public partial class MachineLearningJobScheduleAction : Azure.ResourceManager.MachineLearning.Models.MachineLearningScheduleAction
    {
        public MachineLearningJobScheduleAction(Azure.ResourceManager.MachineLearning.Models.MachineLearningJobProperties jobDefinition) { }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningJobProperties JobDefinition { get { throw null; } set { } }
    }
    public partial class MachineLearningJobService
    {
        public MachineLearningJobService() { }
        public string Endpoint { get { throw null; } set { } }
        public string ErrorMessage { get { throw null; } }
        public string JobServiceType { get { throw null; } set { } }
        public int? Port { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Properties { get { throw null; } set { } }
        public string Status { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MachineLearningJobStatus : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.MachineLearningJobStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MachineLearningJobStatus(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningJobStatus Canceled { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningJobStatus CancelRequested { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningJobStatus Completed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningJobStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningJobStatus Finalizing { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningJobStatus NotResponding { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningJobStatus NotStarted { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningJobStatus Paused { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningJobStatus Preparing { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningJobStatus Provisioning { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningJobStatus Queued { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningJobStatus Running { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningJobStatus Starting { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningJobStatus Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.MachineLearningJobStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.MachineLearningJobStatus left, Azure.ResourceManager.MachineLearning.Models.MachineLearningJobStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.MachineLearningJobStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.MachineLearningJobStatus left, Azure.ResourceManager.MachineLearning.Models.MachineLearningJobStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MachineLearningKeyType : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.MachineLearningKeyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MachineLearningKeyType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningKeyType Primary { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningKeyType Secondary { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.MachineLearningKeyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.MachineLearningKeyType left, Azure.ResourceManager.MachineLearning.Models.MachineLearningKeyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.MachineLearningKeyType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.MachineLearningKeyType left, Azure.ResourceManager.MachineLearning.Models.MachineLearningKeyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MachineLearningKubernetesCompute : Azure.ResourceManager.MachineLearning.Models.MachineLearningComputeProperties
    {
        public MachineLearningKubernetesCompute() { }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningKubernetesProperties Properties { get { throw null; } set { } }
    }
    public partial class MachineLearningKubernetesOnlineDeployment : Azure.ResourceManager.MachineLearning.Models.MachineLearningOnlineDeploymentProperties
    {
        public MachineLearningKubernetesOnlineDeployment() { }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningContainerResourceRequirements ContainerResourceRequirements { get { throw null; } set { } }
    }
    public partial class MachineLearningKubernetesProperties
    {
        public MachineLearningKubernetesProperties() { }
        public string DefaultInstanceType { get { throw null; } set { } }
        public string ExtensionInstanceReleaseTrain { get { throw null; } set { } }
        public string ExtensionPrincipalId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.MachineLearning.Models.MachineLearningInstanceTypeSchema> InstanceTypes { get { throw null; } }
        public string Namespace { get { throw null; } set { } }
        public string RelayConnectionString { get { throw null; } set { } }
        public string ServiceBusConnectionString { get { throw null; } set { } }
        public string VcName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MachineLearningListViewType : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.MachineLearningListViewType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MachineLearningListViewType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningListViewType ActiveOnly { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningListViewType All { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningListViewType ArchivedOnly { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.MachineLearningListViewType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.MachineLearningListViewType left, Azure.ResourceManager.MachineLearning.Models.MachineLearningListViewType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.MachineLearningListViewType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.MachineLearningListViewType left, Azure.ResourceManager.MachineLearning.Models.MachineLearningListViewType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MachineLearningLiteralJobInput : Azure.ResourceManager.MachineLearning.Models.MachineLearningJobInput
    {
        public MachineLearningLiteralJobInput(string value) { }
        public string Value { get { throw null; } set { } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MachineLearningLogVerbosity : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.MachineLearningLogVerbosity>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MachineLearningLogVerbosity(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningLogVerbosity Critical { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningLogVerbosity Debug { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningLogVerbosity Error { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningLogVerbosity Info { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningLogVerbosity NotSet { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningLogVerbosity Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.MachineLearningLogVerbosity other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.MachineLearningLogVerbosity left, Azure.ResourceManager.MachineLearning.Models.MachineLearningLogVerbosity right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.MachineLearningLogVerbosity (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.MachineLearningLogVerbosity left, Azure.ResourceManager.MachineLearning.Models.MachineLearningLogVerbosity right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MachineLearningManagedIdentity : Azure.ResourceManager.MachineLearning.Models.MachineLearningIdentityConfiguration
    {
        public MachineLearningManagedIdentity() { }
        public System.Guid? ClientId { get { throw null; } set { } }
        public System.Guid? ObjectId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
    }
    public partial class MachineLearningManagedIdentityAuthTypeWorkspaceConnection : Azure.ResourceManager.MachineLearning.Models.MachineLearningWorkspaceConnectionProperties
    {
        public MachineLearningManagedIdentityAuthTypeWorkspaceConnection() { }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningWorkspaceConnectionManagedIdentity Credentials { get { throw null; } set { } }
    }
    public partial class MachineLearningManagedOnlineDeployment : Azure.ResourceManager.MachineLearning.Models.MachineLearningOnlineDeploymentProperties
    {
        public MachineLearningManagedOnlineDeployment() { }
    }
    public partial class MachineLearningModelContainerProperties : Azure.ResourceManager.MachineLearning.Models.MachineLearningAssetContainer
    {
        public MachineLearningModelContainerProperties() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MachineLearningModelSize : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.MachineLearningModelSize>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MachineLearningModelSize(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningModelSize ExtraLarge { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningModelSize Large { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningModelSize Medium { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningModelSize None { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningModelSize Small { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.MachineLearningModelSize other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.MachineLearningModelSize left, Azure.ResourceManager.MachineLearning.Models.MachineLearningModelSize right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.MachineLearningModelSize (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.MachineLearningModelSize left, Azure.ResourceManager.MachineLearning.Models.MachineLearningModelSize right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MachineLearningModelVersionCollectionGetAllOptions
    {
        public MachineLearningModelVersionCollectionGetAllOptions() { }
        public string Description { get { throw null; } set { } }
        public string Feed { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningListViewType? ListViewType { get { throw null; } set { } }
        public int? Offset { get { throw null; } set { } }
        public string OrderBy { get { throw null; } set { } }
        public string Properties { get { throw null; } set { } }
        public string Skip { get { throw null; } set { } }
        public string Tags { get { throw null; } set { } }
        public int? Top { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
    }
    public partial class MachineLearningModelVersionProperties : Azure.ResourceManager.MachineLearning.Models.MachineLearningAssetBase
    {
        public MachineLearningModelVersionProperties() { }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.MachineLearning.Models.MachineLearningFlavorData> Flavors { get { throw null; } set { } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MachineLearningNodeState : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.MachineLearningNodeState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MachineLearningNodeState(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningNodeState Idle { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningNodeState Leaving { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningNodeState Preempted { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningNodeState Preparing { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningNodeState Running { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningNodeState Unusable { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.MachineLearningNodeState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.MachineLearningNodeState left, Azure.ResourceManager.MachineLearning.Models.MachineLearningNodeState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.MachineLearningNodeState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.MachineLearningNodeState left, Azure.ResourceManager.MachineLearning.Models.MachineLearningNodeState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MachineLearningNodeStateCounts
    {
        internal MachineLearningNodeStateCounts() { }
        public int? IdleNodeCount { get { throw null; } }
        public int? LeavingNodeCount { get { throw null; } }
        public int? PreemptedNodeCount { get { throw null; } }
        public int? PreparingNodeCount { get { throw null; } }
        public int? RunningNodeCount { get { throw null; } }
        public int? UnusableNodeCount { get { throw null; } }
    }
    public partial class MachineLearningNoneAuthTypeWorkspaceConnection : Azure.ResourceManager.MachineLearning.Models.MachineLearningWorkspaceConnectionProperties
    {
        public MachineLearningNoneAuthTypeWorkspaceConnection() { }
    }
    public partial class MachineLearningNoneDatastoreCredentials : Azure.ResourceManager.MachineLearning.Models.MachineLearningDatastoreCredentials
    {
        public MachineLearningNoneDatastoreCredentials() { }
    }
    public partial class MachineLearningNotebookPreparationError
    {
        internal MachineLearningNotebookPreparationError() { }
        public string ErrorMessage { get { throw null; } }
        public int? StatusCode { get { throw null; } }
    }
    public partial class MachineLearningNotebookResourceInfo
    {
        internal MachineLearningNotebookResourceInfo() { }
        public string Fqdn { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningNotebookPreparationError NotebookPreparationError { get { throw null; } }
        public string ResourceId { get { throw null; } }
    }
    public partial class MachineLearningObjective
    {
        public MachineLearningObjective(Azure.ResourceManager.MachineLearning.Models.MachineLearningGoal goal, string primaryMetric) { }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningGoal Goal { get { throw null; } set { } }
        public string PrimaryMetric { get { throw null; } set { } }
    }
    public partial class MachineLearningOnlineDeploymentPatch : Azure.ResourceManager.MachineLearning.Models.MachineLearningResourcePatch
    {
        public MachineLearningOnlineDeploymentPatch() { }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningSkuPatch Sku { get { throw null; } set { } }
    }
    public partial class MachineLearningOnlineDeploymentProperties : Azure.ResourceManager.MachineLearning.Models.MachineLearningEndpointDeploymentProperties
    {
        public MachineLearningOnlineDeploymentProperties() { }
        public bool? AppInsightsEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningEgressPublicNetworkAccessType? EgressPublicNetworkAccess { get { throw null; } set { } }
        public string InstanceType { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningProbeSettings LivenessProbe { get { throw null; } set { } }
        public string Model { get { throw null; } set { } }
        public string ModelMountPath { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningDeploymentProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningProbeSettings ReadinessProbe { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningOnlineRequestSettings RequestSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningOnlineScaleSettings ScaleSettings { get { throw null; } set { } }
    }
    public partial class MachineLearningOnlineEndpointCollectionGetAllOptions
    {
        public MachineLearningOnlineEndpointCollectionGetAllOptions() { }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningEndpointComputeType? ComputeType { get { throw null; } set { } }
        public int? Count { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningOrderString? OrderBy { get { throw null; } set { } }
        public string Properties { get { throw null; } set { } }
        public string Skip { get { throw null; } set { } }
        public string Tags { get { throw null; } set { } }
    }
    public partial class MachineLearningOnlineEndpointProperties : Azure.ResourceManager.MachineLearning.Models.MachineLearningEndpointProperties
    {
        public MachineLearningOnlineEndpointProperties(Azure.ResourceManager.MachineLearning.Models.MachineLearningEndpointAuthMode authMode) : base (default(Azure.ResourceManager.MachineLearning.Models.MachineLearningEndpointAuthMode)) { }
        public string Compute { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningEndpointProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningPublicNetworkAccessType? PublicNetworkAccess { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, int> Traffic { get { throw null; } set { } }
    }
    public partial class MachineLearningOnlineRequestSettings
    {
        public MachineLearningOnlineRequestSettings() { }
        public int? MaxConcurrentRequestsPerInstance { get { throw null; } set { } }
        public System.TimeSpan? MaxQueueWait { get { throw null; } set { } }
        public System.TimeSpan? RequestTimeout { get { throw null; } set { } }
    }
    public abstract partial class MachineLearningOnlineScaleSettings
    {
        protected MachineLearningOnlineScaleSettings() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MachineLearningOperatingSystemType : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.MachineLearningOperatingSystemType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MachineLearningOperatingSystemType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningOperatingSystemType Linux { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningOperatingSystemType Windows { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.MachineLearningOperatingSystemType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.MachineLearningOperatingSystemType left, Azure.ResourceManager.MachineLearning.Models.MachineLearningOperatingSystemType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.MachineLearningOperatingSystemType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.MachineLearningOperatingSystemType left, Azure.ResourceManager.MachineLearning.Models.MachineLearningOperatingSystemType right) { throw null; }
        public override string ToString() { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MachineLearningOrderString : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.MachineLearningOrderString>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MachineLearningOrderString(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningOrderString CreatedAtAsc { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningOrderString CreatedAtDesc { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningOrderString UpdatedAtAsc { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningOrderString UpdatedAtDesc { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.MachineLearningOrderString other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.MachineLearningOrderString left, Azure.ResourceManager.MachineLearning.Models.MachineLearningOrderString right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.MachineLearningOrderString (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.MachineLearningOrderString left, Azure.ResourceManager.MachineLearning.Models.MachineLearningOrderString right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MachineLearningOSType : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.MachineLearningOSType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MachineLearningOSType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningOSType Linux { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningOSType Windows { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.MachineLearningOSType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.MachineLearningOSType left, Azure.ResourceManager.MachineLearning.Models.MachineLearningOSType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.MachineLearningOSType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.MachineLearningOSType left, Azure.ResourceManager.MachineLearning.Models.MachineLearningOSType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MachineLearningOutputDeliveryMode : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.MachineLearningOutputDeliveryMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MachineLearningOutputDeliveryMode(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningOutputDeliveryMode ReadWriteMount { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningOutputDeliveryMode Upload { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.MachineLearningOutputDeliveryMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.MachineLearningOutputDeliveryMode left, Azure.ResourceManager.MachineLearning.Models.MachineLearningOutputDeliveryMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.MachineLearningOutputDeliveryMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.MachineLearningOutputDeliveryMode left, Azure.ResourceManager.MachineLearning.Models.MachineLearningOutputDeliveryMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MachineLearningOutputPathAssetReference : Azure.ResourceManager.MachineLearning.Models.MachineLearningAssetReferenceBase
    {
        public MachineLearningOutputPathAssetReference() { }
        public Azure.Core.ResourceIdentifier JobId { get { throw null; } set { } }
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
    public partial class MachineLearningPatAuthTypeWorkspaceConnection : Azure.ResourceManager.MachineLearning.Models.MachineLearningWorkspaceConnectionProperties
    {
        public MachineLearningPatAuthTypeWorkspaceConnection() { }
        public string CredentialsPat { get { throw null; } set { } }
    }
    public partial class MachineLearningPipelineJob : Azure.ResourceManager.MachineLearning.Models.MachineLearningJobProperties
    {
        public MachineLearningPipelineJob() { }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.MachineLearning.Models.MachineLearningJobInput> Inputs { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Jobs { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.MachineLearning.Models.MachineLearningJobOutput> Outputs { get { throw null; } set { } }
        public System.BinaryData Settings { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SourceJobId { get { throw null; } set { } }
    }
    public partial class MachineLearningPrivateEndpoint
    {
        public MachineLearningPrivateEndpoint() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public Azure.Core.ResourceIdentifier SubnetArmId { get { throw null; } }
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
    public partial class MachineLearningProbeSettings
    {
        public MachineLearningProbeSettings() { }
        public int? FailureThreshold { get { throw null; } set { } }
        public System.TimeSpan? InitialDelay { get { throw null; } set { } }
        public System.TimeSpan? Period { get { throw null; } set { } }
        public int? SuccessThreshold { get { throw null; } set { } }
        public System.TimeSpan? Timeout { get { throw null; } set { } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MachineLearningPublicNetworkAccessType : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.MachineLearningPublicNetworkAccessType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MachineLearningPublicNetworkAccessType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningPublicNetworkAccessType Disabled { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningPublicNetworkAccessType Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.MachineLearningPublicNetworkAccessType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.MachineLearningPublicNetworkAccessType left, Azure.ResourceManager.MachineLearning.Models.MachineLearningPublicNetworkAccessType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.MachineLearningPublicNetworkAccessType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.MachineLearningPublicNetworkAccessType left, Azure.ResourceManager.MachineLearning.Models.MachineLearningPublicNetworkAccessType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MachineLearningQuotaProperties
    {
        public MachineLearningQuotaProperties() { }
        public string Id { get { throw null; } set { } }
        public long? Limit { get { throw null; } set { } }
        public string QuotaBasePropertiesType { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningQuotaUnit? Unit { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MachineLearningQuotaUnit : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.MachineLearningQuotaUnit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MachineLearningQuotaUnit(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningQuotaUnit Count { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.MachineLearningQuotaUnit other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.MachineLearningQuotaUnit left, Azure.ResourceManager.MachineLearning.Models.MachineLearningQuotaUnit right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.MachineLearningQuotaUnit (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.MachineLearningQuotaUnit left, Azure.ResourceManager.MachineLearning.Models.MachineLearningQuotaUnit right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MachineLearningQuotaUpdateContent
    {
        public MachineLearningQuotaUpdateContent() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.MachineLearning.Models.MachineLearningQuotaProperties> Value { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MachineLearningRecurrenceFrequency : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.MachineLearningRecurrenceFrequency>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MachineLearningRecurrenceFrequency(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningRecurrenceFrequency Day { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningRecurrenceFrequency Hour { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningRecurrenceFrequency Minute { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningRecurrenceFrequency Month { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningRecurrenceFrequency Week { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.MachineLearningRecurrenceFrequency other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.MachineLearningRecurrenceFrequency left, Azure.ResourceManager.MachineLearning.Models.MachineLearningRecurrenceFrequency right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.MachineLearningRecurrenceFrequency (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.MachineLearningRecurrenceFrequency left, Azure.ResourceManager.MachineLearning.Models.MachineLearningRecurrenceFrequency right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MachineLearningRecurrenceSchedule
    {
        public MachineLearningRecurrenceSchedule(System.Collections.Generic.IEnumerable<int> hours, System.Collections.Generic.IEnumerable<int> minutes) { }
        public System.Collections.Generic.IList<int> Hours { get { throw null; } }
        public System.Collections.Generic.IList<int> Minutes { get { throw null; } }
        public System.Collections.Generic.IList<int> MonthDays { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.MachineLearning.Models.MachineLearningDayOfWeek> WeekDays { get { throw null; } set { } }
    }
    public partial class MachineLearningRecurrenceTrigger : Azure.ResourceManager.MachineLearning.Models.MachineLearningTriggerBase
    {
        public MachineLearningRecurrenceTrigger(Azure.ResourceManager.MachineLearning.Models.MachineLearningRecurrenceFrequency frequency, int interval) { }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningRecurrenceFrequency Frequency { get { throw null; } set { } }
        public int Interval { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningRecurrenceSchedule Schedule { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MachineLearningRemoteLoginPortPublicAccess : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.MachineLearningRemoteLoginPortPublicAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MachineLearningRemoteLoginPortPublicAccess(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningRemoteLoginPortPublicAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningRemoteLoginPortPublicAccess Enabled { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningRemoteLoginPortPublicAccess NotSpecified { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.MachineLearningRemoteLoginPortPublicAccess other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.MachineLearningRemoteLoginPortPublicAccess left, Azure.ResourceManager.MachineLearning.Models.MachineLearningRemoteLoginPortPublicAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.MachineLearningRemoteLoginPortPublicAccess (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.MachineLearningRemoteLoginPortPublicAccess left, Azure.ResourceManager.MachineLearning.Models.MachineLearningRemoteLoginPortPublicAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MachineLearningResourceBase
    {
        public MachineLearningResourceBase() { }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } set { } }
    }
    public partial class MachineLearningResourceConfiguration
    {
        public MachineLearningResourceConfiguration() { }
        public int? InstanceCount { get { throw null; } set { } }
        public string InstanceType { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Properties { get { throw null; } set { } }
    }
    public partial class MachineLearningResourceName
    {
        internal MachineLearningResourceName() { }
        public string LocalizedValue { get { throw null; } }
        public string Value { get { throw null; } }
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
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningResourceName Name { get { throw null; } }
        public string ResourceQuotaType { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningQuotaUnit? Unit { get { throw null; } }
    }
    public partial class MachineLearningSasAuthTypeWorkspaceConnection : Azure.ResourceManager.MachineLearning.Models.MachineLearningWorkspaceConnectionProperties
    {
        public MachineLearningSasAuthTypeWorkspaceConnection() { }
        public string CredentialsSas { get { throw null; } set { } }
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
    public abstract partial class MachineLearningScheduleAction
    {
        protected MachineLearningScheduleAction() { }
    }
    public partial class MachineLearningScheduleBase
    {
        internal MachineLearningScheduleBase() { }
        public string Id { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningScheduleProvisioningState? ProvisioningStatus { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningScheduleStatus? Status { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MachineLearningScheduleListViewType : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.MachineLearningScheduleListViewType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MachineLearningScheduleListViewType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningScheduleListViewType All { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningScheduleListViewType DisabledOnly { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningScheduleListViewType EnabledOnly { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.MachineLearningScheduleListViewType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.MachineLearningScheduleListViewType left, Azure.ResourceManager.MachineLearning.Models.MachineLearningScheduleListViewType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.MachineLearningScheduleListViewType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.MachineLearningScheduleListViewType left, Azure.ResourceManager.MachineLearning.Models.MachineLearningScheduleListViewType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MachineLearningScheduleProperties : Azure.ResourceManager.MachineLearning.Models.MachineLearningResourceBase
    {
        public MachineLearningScheduleProperties(Azure.ResourceManager.MachineLearning.Models.MachineLearningScheduleAction action, Azure.ResourceManager.MachineLearning.Models.MachineLearningTriggerBase trigger) { }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningScheduleAction Action { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningScheduleProvisioningStatus? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningTriggerBase Trigger { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MachineLearningScheduleProvisioningState : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.MachineLearningScheduleProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MachineLearningScheduleProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningScheduleProvisioningState Completed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningScheduleProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningScheduleProvisioningState Provisioning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.MachineLearningScheduleProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.MachineLearningScheduleProvisioningState left, Azure.ResourceManager.MachineLearning.Models.MachineLearningScheduleProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.MachineLearningScheduleProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.MachineLearningScheduleProvisioningState left, Azure.ResourceManager.MachineLearning.Models.MachineLearningScheduleProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MachineLearningScheduleProvisioningStatus : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.MachineLearningScheduleProvisioningStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MachineLearningScheduleProvisioningStatus(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningScheduleProvisioningStatus Canceled { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningScheduleProvisioningStatus Creating { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningScheduleProvisioningStatus Deleting { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningScheduleProvisioningStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningScheduleProvisioningStatus Succeeded { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningScheduleProvisioningStatus Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.MachineLearningScheduleProvisioningStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.MachineLearningScheduleProvisioningStatus left, Azure.ResourceManager.MachineLearning.Models.MachineLearningScheduleProvisioningStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.MachineLearningScheduleProvisioningStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.MachineLearningScheduleProvisioningStatus left, Azure.ResourceManager.MachineLearning.Models.MachineLearningScheduleProvisioningStatus right) { throw null; }
        public override string ToString() { throw null; }
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
    public partial class MachineLearningScriptReference
    {
        public MachineLearningScriptReference() { }
        public string ScriptArguments { get { throw null; } set { } }
        public string ScriptData { get { throw null; } set { } }
        public string ScriptSource { get { throw null; } set { } }
        public string Timeout { get { throw null; } set { } }
    }
    public partial class MachineLearningScriptsToExecute
    {
        public MachineLearningScriptsToExecute() { }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningScriptReference CreationScript { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningScriptReference StartupScript { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MachineLearningServiceDataAccessAuthIdentity : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.MachineLearningServiceDataAccessAuthIdentity>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MachineLearningServiceDataAccessAuthIdentity(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningServiceDataAccessAuthIdentity None { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningServiceDataAccessAuthIdentity WorkspaceSystemAssignedIdentity { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningServiceDataAccessAuthIdentity WorkspaceUserAssignedIdentity { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.MachineLearningServiceDataAccessAuthIdentity other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.MachineLearningServiceDataAccessAuthIdentity left, Azure.ResourceManager.MachineLearning.Models.MachineLearningServiceDataAccessAuthIdentity right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.MachineLearningServiceDataAccessAuthIdentity (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.MachineLearningServiceDataAccessAuthIdentity left, Azure.ResourceManager.MachineLearning.Models.MachineLearningServiceDataAccessAuthIdentity right) { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MachineLearningShortSeriesHandlingConfiguration : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.MachineLearningShortSeriesHandlingConfiguration>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MachineLearningShortSeriesHandlingConfiguration(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningShortSeriesHandlingConfiguration Auto { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningShortSeriesHandlingConfiguration Drop { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningShortSeriesHandlingConfiguration None { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningShortSeriesHandlingConfiguration Pad { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.MachineLearningShortSeriesHandlingConfiguration other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.MachineLearningShortSeriesHandlingConfiguration left, Azure.ResourceManager.MachineLearning.Models.MachineLearningShortSeriesHandlingConfiguration right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.MachineLearningShortSeriesHandlingConfiguration (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.MachineLearningShortSeriesHandlingConfiguration left, Azure.ResourceManager.MachineLearning.Models.MachineLearningShortSeriesHandlingConfiguration right) { throw null; }
        public override string ToString() { throw null; }
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
    public partial class MachineLearningSkuCapacity
    {
        internal MachineLearningSkuCapacity() { }
        public int? Default { get { throw null; } }
        public int? Maximum { get { throw null; } }
        public int? Minimum { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningSkuScaleType? ScaleType { get { throw null; } }
    }
    public partial class MachineLearningSkuDetail
    {
        internal MachineLearningSkuDetail() { }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningSkuCapacity Capacity { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningSkuSetting Sku { get { throw null; } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MachineLearningSkuScaleType : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.MachineLearningSkuScaleType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MachineLearningSkuScaleType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningSkuScaleType Automatic { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningSkuScaleType Manual { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningSkuScaleType None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.MachineLearningSkuScaleType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.MachineLearningSkuScaleType left, Azure.ResourceManager.MachineLearning.Models.MachineLearningSkuScaleType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.MachineLearningSkuScaleType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.MachineLearningSkuScaleType left, Azure.ResourceManager.MachineLearning.Models.MachineLearningSkuScaleType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MachineLearningSkuSetting
    {
        internal MachineLearningSkuSetting() { }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningSkuTier? Tier { get { throw null; } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MachineLearningSslConfigStatus : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.MachineLearningSslConfigStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MachineLearningSslConfigStatus(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningSslConfigStatus Auto { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningSslConfigStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningSslConfigStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.MachineLearningSslConfigStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.MachineLearningSslConfigStatus left, Azure.ResourceManager.MachineLearning.Models.MachineLearningSslConfigStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.MachineLearningSslConfigStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.MachineLearningSslConfigStatus left, Azure.ResourceManager.MachineLearning.Models.MachineLearningSslConfigStatus right) { throw null; }
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
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningSslConfigStatus? Status { get { throw null; } set { } }
    }
    public partial class MachineLearningStackEnsembleSettings
    {
        public MachineLearningStackEnsembleSettings() { }
        public System.BinaryData StackMetaLearnerKWargs { get { throw null; } set { } }
        public double? StackMetaLearnerTrainPercentage { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningStackMetaLearnerType? StackMetaLearnerType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MachineLearningStackMetaLearnerType : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.MachineLearningStackMetaLearnerType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MachineLearningStackMetaLearnerType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningStackMetaLearnerType ElasticNet { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningStackMetaLearnerType ElasticNetCV { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningStackMetaLearnerType LightGBMClassifier { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningStackMetaLearnerType LightGBMRegressor { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningStackMetaLearnerType LinearRegression { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningStackMetaLearnerType LogisticRegression { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningStackMetaLearnerType LogisticRegressionCV { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningStackMetaLearnerType None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.MachineLearningStackMetaLearnerType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.MachineLearningStackMetaLearnerType left, Azure.ResourceManager.MachineLearning.Models.MachineLearningStackMetaLearnerType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.MachineLearningStackMetaLearnerType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.MachineLearningStackMetaLearnerType left, Azure.ResourceManager.MachineLearning.Models.MachineLearningStackMetaLearnerType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MachineLearningStorageAccountType : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.MachineLearningStorageAccountType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MachineLearningStorageAccountType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningStorageAccountType PremiumLrs { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningStorageAccountType StandardLrs { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.MachineLearningStorageAccountType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.MachineLearningStorageAccountType left, Azure.ResourceManager.MachineLearning.Models.MachineLearningStorageAccountType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.MachineLearningStorageAccountType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.MachineLearningStorageAccountType left, Azure.ResourceManager.MachineLearning.Models.MachineLearningStorageAccountType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MachineLearningSweepJob : Azure.ResourceManager.MachineLearning.Models.MachineLearningJobProperties
    {
        public MachineLearningSweepJob(Azure.ResourceManager.MachineLearning.Models.MachineLearningObjective objective, Azure.ResourceManager.MachineLearning.Models.SamplingAlgorithm samplingAlgorithm, System.BinaryData searchSpace, Azure.ResourceManager.MachineLearning.Models.MachineLearningTrialComponent trial) { }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningEarlyTerminationPolicy EarlyTermination { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.MachineLearning.Models.MachineLearningJobInput> Inputs { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningSweepJobLimits Limits { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningObjective Objective { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.MachineLearning.Models.MachineLearningJobOutput> Outputs { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.SamplingAlgorithm SamplingAlgorithm { get { throw null; } set { } }
        public System.BinaryData SearchSpace { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningTrialComponent Trial { get { throw null; } set { } }
    }
    public partial class MachineLearningSweepJobLimits : Azure.ResourceManager.MachineLearning.Models.MachineLearningJobLimits
    {
        public MachineLearningSweepJobLimits() { }
        public int? MaxConcurrentTrials { get { throw null; } set { } }
        public int? MaxTotalTrials { get { throw null; } set { } }
        public System.TimeSpan? TrialTimeout { get { throw null; } set { } }
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
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningAutoScaleProperties AutoScaleProperties { get { throw null; } set { } }
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
    public partial class MachineLearningTableJobInput : Azure.ResourceManager.MachineLearning.Models.MachineLearningJobInput
    {
        public MachineLearningTableJobInput(System.Uri uri) { }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningInputDeliveryMode? Mode { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    public partial class MachineLearningTableJobOutput : Azure.ResourceManager.MachineLearning.Models.MachineLearningJobOutput
    {
        public MachineLearningTableJobOutput() { }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningOutputDeliveryMode? Mode { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    public partial class MachineLearningTargetUtilizationScaleSettings : Azure.ResourceManager.MachineLearning.Models.MachineLearningOnlineScaleSettings
    {
        public MachineLearningTargetUtilizationScaleSettings() { }
        public int? MaxInstances { get { throw null; } set { } }
        public int? MinInstances { get { throw null; } set { } }
        public System.TimeSpan? PollingInterval { get { throw null; } set { } }
        public int? TargetUtilizationPercentage { get { throw null; } set { } }
    }
    public partial class MachineLearningTrainingSettings
    {
        public MachineLearningTrainingSettings() { }
        public System.TimeSpan? EnsembleModelDownloadTimeout { get { throw null; } set { } }
        public bool? IsDnnTrainingEnabled { get { throw null; } set { } }
        public bool? IsModelExplainabilityEnabled { get { throw null; } set { } }
        public bool? IsOnnxCompatibleModelsEnabled { get { throw null; } set { } }
        public bool? IsStackEnsembleEnabled { get { throw null; } set { } }
        public bool? IsVoteEnsembleEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningStackEnsembleSettings StackEnsembleSettings { get { throw null; } set { } }
    }
    public partial class MachineLearningTrialComponent
    {
        public MachineLearningTrialComponent(string command, Azure.Core.ResourceIdentifier environmentId) { }
        public Azure.Core.ResourceIdentifier CodeId { get { throw null; } set { } }
        public string Command { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningDistributionConfiguration Distribution { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier EnvironmentId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> EnvironmentVariables { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningJobResourceConfiguration Resources { get { throw null; } set { } }
    }
    public abstract partial class MachineLearningTriggerBase
    {
        protected MachineLearningTriggerBase() { }
        public string EndTime { get { throw null; } set { } }
        public string StartTime { get { throw null; } set { } }
        public string TimeZone { get { throw null; } set { } }
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
    public partial class MachineLearningTritonModelJobInput : Azure.ResourceManager.MachineLearning.Models.MachineLearningJobInput
    {
        public MachineLearningTritonModelJobInput(System.Uri uri) { }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningInputDeliveryMode? Mode { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    public partial class MachineLearningTritonModelJobOutput : Azure.ResourceManager.MachineLearning.Models.MachineLearningJobOutput
    {
        public MachineLearningTritonModelJobOutput() { }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningOutputDeliveryMode? Mode { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MachineLearningUnderlyingResourceAction : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.MachineLearningUnderlyingResourceAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MachineLearningUnderlyingResourceAction(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningUnderlyingResourceAction Delete { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningUnderlyingResourceAction Detach { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.MachineLearningUnderlyingResourceAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.MachineLearningUnderlyingResourceAction left, Azure.ResourceManager.MachineLearning.Models.MachineLearningUnderlyingResourceAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.MachineLearningUnderlyingResourceAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.MachineLearningUnderlyingResourceAction left, Azure.ResourceManager.MachineLearning.Models.MachineLearningUnderlyingResourceAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MachineLearningUnitOfMeasure : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.MachineLearningUnitOfMeasure>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MachineLearningUnitOfMeasure(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningUnitOfMeasure OneHour { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.MachineLearningUnitOfMeasure other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.MachineLearningUnitOfMeasure left, Azure.ResourceManager.MachineLearning.Models.MachineLearningUnitOfMeasure right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.MachineLearningUnitOfMeasure (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.MachineLearningUnitOfMeasure left, Azure.ResourceManager.MachineLearning.Models.MachineLearningUnitOfMeasure right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MachineLearningUriFileDataVersion : Azure.ResourceManager.MachineLearning.Models.MachineLearningDataVersionProperties
    {
        public MachineLearningUriFileDataVersion(System.Uri dataUri) : base (default(System.Uri)) { }
    }
    public partial class MachineLearningUriFileJobInput : Azure.ResourceManager.MachineLearning.Models.MachineLearningJobInput
    {
        public MachineLearningUriFileJobInput(System.Uri uri) { }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningInputDeliveryMode? Mode { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    public partial class MachineLearningUriFileJobOutput : Azure.ResourceManager.MachineLearning.Models.MachineLearningJobOutput
    {
        public MachineLearningUriFileJobOutput() { }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningOutputDeliveryMode? Mode { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    public partial class MachineLearningUriFolderDataVersion : Azure.ResourceManager.MachineLearning.Models.MachineLearningDataVersionProperties
    {
        public MachineLearningUriFolderDataVersion(System.Uri dataUri) : base (default(System.Uri)) { }
    }
    public partial class MachineLearningUriFolderJobInput : Azure.ResourceManager.MachineLearning.Models.MachineLearningJobInput
    {
        public MachineLearningUriFolderJobInput(System.Uri uri) { }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningInputDeliveryMode? Mode { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    public partial class MachineLearningUriFolderJobOutput : Azure.ResourceManager.MachineLearning.Models.MachineLearningJobOutput
    {
        public MachineLearningUriFolderJobOutput() { }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningOutputDeliveryMode? Mode { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    public partial class MachineLearningUsage
    {
        internal MachineLearningUsage() { }
        public string AmlWorkspaceLocation { get { throw null; } }
        public long? CurrentValue { get { throw null; } }
        public string Id { get { throw null; } }
        public long? Limit { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningUsageName Name { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningUsageUnit? Unit { get { throw null; } }
        public string UsageType { get { throw null; } }
    }
    public partial class MachineLearningUsageName
    {
        internal MachineLearningUsageName() { }
        public string LocalizedValue { get { throw null; } }
        public string Value { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MachineLearningUsageUnit : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.MachineLearningUsageUnit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MachineLearningUsageUnit(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningUsageUnit Count { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.MachineLearningUsageUnit other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.MachineLearningUsageUnit left, Azure.ResourceManager.MachineLearning.Models.MachineLearningUsageUnit right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.MachineLearningUsageUnit (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.MachineLearningUsageUnit left, Azure.ResourceManager.MachineLearning.Models.MachineLearningUsageUnit right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MachineLearningUserAccountCredentials
    {
        public MachineLearningUserAccountCredentials(string adminUserName) { }
        public string AdminUserName { get { throw null; } set { } }
        public string AdminUserPassword { get { throw null; } set { } }
        public string AdminUserSshPublicKey { get { throw null; } set { } }
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
    public partial class MachineLearningUsernamePasswordAuthTypeWorkspaceConnection : Azure.ResourceManager.MachineLearning.Models.MachineLearningWorkspaceConnectionProperties
    {
        public MachineLearningUsernamePasswordAuthTypeWorkspaceConnection() { }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningWorkspaceConnectionUsernamePassword Credentials { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MachineLearningUseStl : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.MachineLearningUseStl>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MachineLearningUseStl(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningUseStl None { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningUseStl Season { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningUseStl SeasonTrend { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.MachineLearningUseStl other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.MachineLearningUseStl left, Azure.ResourceManager.MachineLearning.Models.MachineLearningUseStl right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.MachineLearningUseStl (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.MachineLearningUseStl left, Azure.ResourceManager.MachineLearning.Models.MachineLearningUseStl right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MachineLearningValueFormat : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.MachineLearningValueFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MachineLearningValueFormat(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningValueFormat Json { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.MachineLearningValueFormat other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.MachineLearningValueFormat left, Azure.ResourceManager.MachineLearning.Models.MachineLearningValueFormat right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.MachineLearningValueFormat (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.MachineLearningValueFormat left, Azure.ResourceManager.MachineLearning.Models.MachineLearningValueFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MachineLearningVirtualMachineCompute : Azure.ResourceManager.MachineLearning.Models.MachineLearningComputeProperties
    {
        public MachineLearningVirtualMachineCompute() { }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningVirtualMachineProperties Properties { get { throw null; } set { } }
    }
    public partial class MachineLearningVirtualMachineProperties
    {
        public MachineLearningVirtualMachineProperties() { }
        public System.Net.IPAddress Address { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningVmSshCredentials AdministratorAccount { get { throw null; } set { } }
        public bool? IsNotebookInstanceCompute { get { throw null; } set { } }
        public int? NotebookServerPort { get { throw null; } set { } }
        public int? SshPort { get { throw null; } set { } }
        public string VirtualMachineSize { get { throw null; } set { } }
    }
    public partial class MachineLearningVirtualMachineSecrets : Azure.ResourceManager.MachineLearning.Models.MachineLearningComputeSecrets
    {
        internal MachineLearningVirtualMachineSecrets() { }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningVmSshCredentials AdministratorAccount { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MachineLearningVmPriceOSType : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.MachineLearningVmPriceOSType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MachineLearningVmPriceOSType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningVmPriceOSType Linux { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningVmPriceOSType Windows { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.MachineLearningVmPriceOSType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.MachineLearningVmPriceOSType left, Azure.ResourceManager.MachineLearning.Models.MachineLearningVmPriceOSType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.MachineLearningVmPriceOSType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.MachineLearningVmPriceOSType left, Azure.ResourceManager.MachineLearning.Models.MachineLearningVmPriceOSType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MachineLearningVmPriority : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.MachineLearningVmPriority>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MachineLearningVmPriority(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningVmPriority Dedicated { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningVmPriority LowPriority { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.MachineLearningVmPriority other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.MachineLearningVmPriority left, Azure.ResourceManager.MachineLearning.Models.MachineLearningVmPriority right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.MachineLearningVmPriority (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.MachineLearningVmPriority left, Azure.ResourceManager.MachineLearning.Models.MachineLearningVmPriority right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MachineLearningVmSize
    {
        internal MachineLearningVmSize() { }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningEstimatedVmPrices EstimatedVmPrices { get { throw null; } }
        public string Family { get { throw null; } }
        public int? Gpus { get { throw null; } }
        public bool? IsPremiumIOSupported { get { throw null; } }
        public bool? LowPriorityCapable { get { throw null; } }
        public int? MaxResourceVolumeMB { get { throw null; } }
        public double? MemoryGB { get { throw null; } }
        public string Name { get { throw null; } }
        public int? OSVhdSizeMB { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SupportedComputeTypes { get { throw null; } }
        public int? VCpus { get { throw null; } }
    }
    public partial class MachineLearningVmSshCredentials
    {
        public MachineLearningVmSshCredentials() { }
        public string Password { get { throw null; } set { } }
        public string PrivateKeyData { get { throw null; } set { } }
        public string PublicKeyData { get { throw null; } set { } }
        public string Username { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MachineLearningVmTier : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.MachineLearningVmTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MachineLearningVmTier(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningVmTier LowPriority { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningVmTier Spot { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningVmTier Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.MachineLearningVmTier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.MachineLearningVmTier left, Azure.ResourceManager.MachineLearning.Models.MachineLearningVmTier right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.MachineLearningVmTier (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.MachineLearningVmTier left, Azure.ResourceManager.MachineLearning.Models.MachineLearningVmTier right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MachineLearningWorkspaceConnectionManagedIdentity
    {
        public MachineLearningWorkspaceConnectionManagedIdentity() { }
        public string ClientId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
    }
    public abstract partial class MachineLearningWorkspaceConnectionProperties
    {
        protected MachineLearningWorkspaceConnectionProperties() { }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningConnectionCategory? Category { get { throw null; } set { } }
        public string Target { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningValueFormat? ValueFormat { get { throw null; } set { } }
    }
    public partial class MachineLearningWorkspaceConnectionUsernamePassword
    {
        public MachineLearningWorkspaceConnectionUsernamePassword() { }
        public string Password { get { throw null; } set { } }
        public string Username { get { throw null; } set { } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MachineLearningWorkspaceQuotaStatus : System.IEquatable<Azure.ResourceManager.MachineLearning.Models.MachineLearningWorkspaceQuotaStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MachineLearningWorkspaceQuotaStatus(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningWorkspaceQuotaStatus Failure { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningWorkspaceQuotaStatus InvalidQuotaBelowClusterMinimum { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningWorkspaceQuotaStatus InvalidQuotaExceedsSubscriptionLimit { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningWorkspaceQuotaStatus InvalidVmFamilyName { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningWorkspaceQuotaStatus OperationNotEnabledForRegion { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningWorkspaceQuotaStatus OperationNotSupportedForSku { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningWorkspaceQuotaStatus Success { get { throw null; } }
        public static Azure.ResourceManager.MachineLearning.Models.MachineLearningWorkspaceQuotaStatus Undefined { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearning.Models.MachineLearningWorkspaceQuotaStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearning.Models.MachineLearningWorkspaceQuotaStatus left, Azure.ResourceManager.MachineLearning.Models.MachineLearningWorkspaceQuotaStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearning.Models.MachineLearningWorkspaceQuotaStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearning.Models.MachineLearningWorkspaceQuotaStatus left, Azure.ResourceManager.MachineLearning.Models.MachineLearningWorkspaceQuotaStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MachineLearningWorkspaceQuotaUpdate
    {
        internal MachineLearningWorkspaceQuotaUpdate() { }
        public string Id { get { throw null; } }
        public long? Limit { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningWorkspaceQuotaStatus? Status { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningQuotaUnit? Unit { get { throw null; } }
        public string UpdateWorkspaceQuotasType { get { throw null; } }
    }
    public partial class MedianStoppingPolicy : Azure.ResourceManager.MachineLearning.Models.MachineLearningEarlyTerminationPolicy
    {
        public MedianStoppingPolicy() { }
    }
    public partial class MpiDistributionConfiguration : Azure.ResourceManager.MachineLearning.Models.MachineLearningDistributionConfiguration
    {
        public MpiDistributionConfiguration() { }
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
    public partial class PyTorchDistributionConfiguration : Azure.ResourceManager.MachineLearning.Models.MachineLearningDistributionConfiguration
    {
        public PyTorchDistributionConfiguration() { }
        public int? ProcessCountPerInstance { get { throw null; } set { } }
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
    public partial class RegressionTrainingSettings : Azure.ResourceManager.MachineLearning.Models.MachineLearningTrainingSettings
    {
        public RegressionTrainingSettings() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.MachineLearning.Models.AutoMLVerticalRegressionModel> AllowedTrainingAlgorithms { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.MachineLearning.Models.AutoMLVerticalRegressionModel> BlockedTrainingAlgorithms { get { throw null; } set { } }
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
    public partial class TableVerticalFeaturizationSettings : Azure.ResourceManager.MachineLearning.Models.MachineLearningFeaturizationSettings
    {
        public TableVerticalFeaturizationSettings() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.MachineLearning.Models.BlockedTransformer> BlockedTransformers { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> ColumnNameAndTypes { get { throw null; } set { } }
        public bool? EnableDnnFeaturization { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningFeaturizationMode? Mode { get { throw null; } set { } }
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
    public partial class TensorFlowDistributionConfiguration : Azure.ResourceManager.MachineLearning.Models.MachineLearningDistributionConfiguration
    {
        public TensorFlowDistributionConfiguration() { }
        public int? ParameterServerCount { get { throw null; } set { } }
        public int? WorkerCount { get { throw null; } set { } }
    }
    public partial class TextClassification : Azure.ResourceManager.MachineLearning.Models.AutoMLVertical
    {
        public TextClassification(Azure.ResourceManager.MachineLearning.Models.MachineLearningTableJobInput trainingData) : base (default(Azure.ResourceManager.MachineLearning.Models.MachineLearningTableJobInput)) { }
        public string FeaturizationDatasetLanguage { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.NlpVerticalLimitSettings LimitSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ClassificationPrimaryMetric? PrimaryMetric { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningTableJobInput ValidationData { get { throw null; } set { } }
    }
    public partial class TextClassificationMultilabel : Azure.ResourceManager.MachineLearning.Models.AutoMLVertical
    {
        public TextClassificationMultilabel(Azure.ResourceManager.MachineLearning.Models.MachineLearningTableJobInput trainingData) : base (default(Azure.ResourceManager.MachineLearning.Models.MachineLearningTableJobInput)) { }
        public string FeaturizationDatasetLanguage { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.NlpVerticalLimitSettings LimitSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ClassificationMultilabelPrimaryMetric? PrimaryMetric { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningTableJobInput ValidationData { get { throw null; } set { } }
    }
    public partial class TextNer : Azure.ResourceManager.MachineLearning.Models.AutoMLVertical
    {
        public TextNer(Azure.ResourceManager.MachineLearning.Models.MachineLearningTableJobInput trainingData) : base (default(Azure.ResourceManager.MachineLearning.Models.MachineLearningTableJobInput)) { }
        public string FeaturizationDatasetLanguage { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.NlpVerticalLimitSettings LimitSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearning.Models.ClassificationPrimaryMetric? PrimaryMetric { get { throw null; } }
        public Azure.ResourceManager.MachineLearning.Models.MachineLearningTableJobInput ValidationData { get { throw null; } set { } }
    }
    public partial class TruncationSelectionPolicy : Azure.ResourceManager.MachineLearning.Models.MachineLearningEarlyTerminationPolicy
    {
        public TruncationSelectionPolicy() { }
        public int? TruncationPercentage { get { throw null; } set { } }
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
}
