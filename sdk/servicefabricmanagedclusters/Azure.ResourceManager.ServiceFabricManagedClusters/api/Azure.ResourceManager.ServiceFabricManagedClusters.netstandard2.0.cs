namespace Azure.ResourceManager.ServiceFabricManagedClusters
{
    public partial class ServiceFabricManagedClusterApplicationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterApplicationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterApplicationResource>, System.Collections.IEnumerable
    {
        protected ServiceFabricManagedClusterApplicationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterApplicationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string applicationName, Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterApplicationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterApplicationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string applicationName, Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterApplicationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterApplicationResource> Get(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterApplicationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterApplicationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterApplicationResource>> GetAsync(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterApplicationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterApplicationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterApplicationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterApplicationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServiceFabricManagedClusterApplicationData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ServiceFabricManagedClusterApplicationData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ApplicationUserAssignedIdentityInfo> ManagedIdentities { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Parameters { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.ApplicationUpgradePolicy UpgradePolicy { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
    }
    public partial class ServiceFabricManagedClusterApplicationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServiceFabricManagedClusterApplicationResource() { }
        public virtual Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterApplicationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterApplicationResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterApplicationResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string applicationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterApplicationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterApplicationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterServiceResource> GetServiceFabricManagedClusterService(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterServiceResource>> GetServiceFabricManagedClusterServiceAsync(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterServiceCollection GetServiceFabricManagedClusterServices() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterApplicationResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterApplicationResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterApplicationResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterApplicationResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterApplicationResource> Update(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterApplicationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterApplicationResource>> UpdateAsync(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterApplicationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServiceFabricManagedClusterApplicationTypeCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterApplicationTypeResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterApplicationTypeResource>, System.Collections.IEnumerable
    {
        protected ServiceFabricManagedClusterApplicationTypeCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterApplicationTypeResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string applicationTypeName, Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterApplicationTypeData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterApplicationTypeResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string applicationTypeName, Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterApplicationTypeData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string applicationTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string applicationTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterApplicationTypeResource> Get(string applicationTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterApplicationTypeResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterApplicationTypeResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterApplicationTypeResource>> GetAsync(string applicationTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterApplicationTypeResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterApplicationTypeResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterApplicationTypeResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterApplicationTypeResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServiceFabricManagedClusterApplicationTypeData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ServiceFabricManagedClusterApplicationTypeData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string ProvisioningState { get { throw null; } }
    }
    public partial class ServiceFabricManagedClusterApplicationTypeResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServiceFabricManagedClusterApplicationTypeResource() { }
        public virtual Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterApplicationTypeData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterApplicationTypeResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterApplicationTypeResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string applicationTypeName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterApplicationTypeResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterApplicationTypeResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterApplicationTypeVersionResource> GetServiceFabricManagedClusterApplicationTypeVersion(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterApplicationTypeVersionResource>> GetServiceFabricManagedClusterApplicationTypeVersionAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterApplicationTypeVersionCollection GetServiceFabricManagedClusterApplicationTypeVersions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterApplicationTypeResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterApplicationTypeResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterApplicationTypeResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterApplicationTypeResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterApplicationTypeResource> Update(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterApplicationTypePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterApplicationTypeResource>> UpdateAsync(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterApplicationTypePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServiceFabricManagedClusterApplicationTypeVersionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterApplicationTypeVersionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterApplicationTypeVersionResource>, System.Collections.IEnumerable
    {
        protected ServiceFabricManagedClusterApplicationTypeVersionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterApplicationTypeVersionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string version, Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterApplicationTypeVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterApplicationTypeVersionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string version, Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterApplicationTypeVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterApplicationTypeVersionResource> Get(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterApplicationTypeVersionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterApplicationTypeVersionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterApplicationTypeVersionResource>> GetAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterApplicationTypeVersionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterApplicationTypeVersionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterApplicationTypeVersionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterApplicationTypeVersionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServiceFabricManagedClusterApplicationTypeVersionData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ServiceFabricManagedClusterApplicationTypeVersionData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.Uri AppPackageUri { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
    }
    public partial class ServiceFabricManagedClusterApplicationTypeVersionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServiceFabricManagedClusterApplicationTypeVersionResource() { }
        public virtual Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterApplicationTypeVersionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterApplicationTypeVersionResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterApplicationTypeVersionResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string applicationTypeName, string version) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterApplicationTypeVersionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterApplicationTypeVersionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterApplicationTypeVersionResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterApplicationTypeVersionResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterApplicationTypeVersionResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterApplicationTypeVersionResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterApplicationTypeVersionResource> Update(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterApplicationTypeVersionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterApplicationTypeVersionResource>> UpdateAsync(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterApplicationTypeVersionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServiceFabricManagedClusterCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterResource>, System.Collections.IEnumerable
    {
        protected ServiceFabricManagedClusterCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string clusterName, Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string clusterName, Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterResource> Get(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterResource>> GetAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServiceFabricManagedClusterData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ServiceFabricManagedClusterData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterAddOnFeature> AddOnFeatures { get { throw null; } }
        public string AdminPassword { get { throw null; } set { } }
        public string AdminUserName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterSubnet> AuxiliarySubnets { get { throw null; } }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterAzureActiveDirectory AzureActiveDirectory { get { throw null; } set { } }
        public int? ClientConnectionPort { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterClientCertificate> Clients { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<System.BinaryData> ClusterCertificateThumbprints { get { throw null; } }
        public string ClusterCodeVersion { get { throw null; } set { } }
        public System.Guid? ClusterId { get { throw null; } }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterState? ClusterState { get { throw null; } }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterUpgradeCadence? ClusterUpgradeCadence { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterUpgradeMode? ClusterUpgradeMode { get { throw null; } set { } }
        public string DnsName { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ClusterFabricSettingsSection> FabricSettings { get { throw null; } }
        public string Fqdn { get { throw null; } }
        public bool? HasZoneResiliency { get { throw null; } set { } }
        public int? HttpGatewayConnectionPort { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterIPTag> IPTags { get { throw null; } }
        public System.Net.IPAddress IPv4Address { get { throw null; } }
        public System.Net.IPAddress IPv6Address { get { throw null; } }
        public bool? IsAutoOSUpgradeEnabled { get { throw null; } set { } }
        public bool? IsIPv6Enabled { get { throw null; } set { } }
        public bool? IsRdpAccessAllowed { get { throw null; } set { } }
        public bool? IsServicePublicIPEnabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterLoadBalancingRule> LoadBalancingRules { get { throw null; } }
        public int? MaxUnusedVersionsToKeep { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClustersNetworkSecurityRule> NetworkSecurityRules { get { throw null; } }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedResourceProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterServiceEndpoint> ServiceEndpoints { get { throw null; } }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClustersSkuName? SkuName { get { throw null; } set { } }
        public string SubnetId { get { throw null; } set { } }
    }
    public partial class ServiceFabricManagedClusterNodeTypeCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterNodeTypeResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterNodeTypeResource>, System.Collections.IEnumerable
    {
        protected ServiceFabricManagedClusterNodeTypeCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterNodeTypeResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string nodeTypeName, Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterNodeTypeData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterNodeTypeResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string nodeTypeName, Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterNodeTypeData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string nodeTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string nodeTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterNodeTypeResource> Get(string nodeTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterNodeTypeResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterNodeTypeResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterNodeTypeResource>> GetAsync(string nodeTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterNodeTypeResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterNodeTypeResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterNodeTypeResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterNodeTypeResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServiceFabricManagedClusterNodeTypeData : Azure.ResourceManager.Models.ResourceData
    {
        public ServiceFabricManagedClusterNodeTypeData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeVmssDataDisk> AdditionalDataDisks { get { throw null; } }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.EndpointRangeDescription ApplicationPorts { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Capacities { get { throw null; } }
        public string DataDiskLetter { get { throw null; } set { } }
        public int? DataDiskSizeInGB { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedDataDiskType? DataDiskType { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.EndpointRangeDescription EphemeralPorts { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeFrontendConfiguration> FrontendConfigurations { get { throw null; } }
        public bool? HasMultiplePlacementGroups { get { throw null; } set { } }
        public bool? IsAcceleratedNetworkingEnabled { get { throw null; } set { } }
        public bool? IsEncryptionAtHostEnabled { get { throw null; } set { } }
        public bool? IsOverProvisioningEnabled { get { throw null; } set { } }
        public bool? IsPrimary { get { throw null; } set { } }
        public bool? IsStateless { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClustersNetworkSecurityRule> NetworkSecurityRules { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> PlacementProperties { get { throw null; } }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedResourceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public bool? UseDefaultPublicLoadBalancer { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> UserAssignedIdentities { get { throw null; } }
        public bool? UseTempDataDisk { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabricManagedClusters.Models.VmssExtension> VmExtensions { get { throw null; } }
        public string VmImageOffer { get { throw null; } set { } }
        public string VmImagePublisher { get { throw null; } set { } }
        public string VmImageSku { get { throw null; } set { } }
        public string VmImageVersion { get { throw null; } set { } }
        public int? VmInstanceCount { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeVaultSecretGroup> VmSecrets { get { throw null; } }
        public string VmSize { get { throw null; } set { } }
    }
    public partial class ServiceFabricManagedClusterNodeTypeResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServiceFabricManagedClusterNodeTypeResource() { }
        public virtual Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterNodeTypeData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterNodeTypeResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterNodeTypeResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string nodeTypeName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation DeleteNode(Azure.WaitUntil waitUntil, Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeActionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteNodeAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeActionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterNodeTypeResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterNodeTypeResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeAvailableSku> GetAvailableSkus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeAvailableSku> GetAvailableSkusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Reimage(Azure.WaitUntil waitUntil, Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeActionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ReimageAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeActionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterNodeTypeResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterNodeTypeResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Restart(Azure.WaitUntil waitUntil, Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeActionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RestartAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeActionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterNodeTypeResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterNodeTypeResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterNodeTypeResource> Update(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterNodeTypePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterNodeTypeResource>> UpdateAsync(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterNodeTypePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServiceFabricManagedClusterResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServiceFabricManagedClusterResource() { }
        public virtual Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterApplicationResource> GetServiceFabricManagedClusterApplication(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterApplicationResource>> GetServiceFabricManagedClusterApplicationAsync(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterApplicationCollection GetServiceFabricManagedClusterApplications() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterApplicationTypeResource> GetServiceFabricManagedClusterApplicationType(string applicationTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterApplicationTypeResource>> GetServiceFabricManagedClusterApplicationTypeAsync(string applicationTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterApplicationTypeCollection GetServiceFabricManagedClusterApplicationTypes() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterNodeTypeResource> GetServiceFabricManagedClusterNodeType(string nodeTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterNodeTypeResource>> GetServiceFabricManagedClusterNodeTypeAsync(string nodeTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterNodeTypeCollection GetServiceFabricManagedClusterNodeTypes() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterResource> Update(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterResource>> UpdateAsync(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServiceFabricManagedClusterServiceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterServiceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterServiceResource>, System.Collections.IEnumerable
    {
        protected ServiceFabricManagedClusterServiceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterServiceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string serviceName, Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterServiceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterServiceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string serviceName, Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterServiceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterServiceResource> Get(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterServiceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterServiceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterServiceResource>> GetAsync(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterServiceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterServiceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterServiceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterServiceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServiceFabricManagedClusterServiceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ServiceFabricManagedClusterServiceData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterServiceProperties Properties { get { throw null; } set { } }
    }
    public partial class ServiceFabricManagedClusterServiceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServiceFabricManagedClusterServiceResource() { }
        public virtual Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterServiceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterServiceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterServiceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string applicationName, string serviceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterServiceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterServiceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterServiceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterServiceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterServiceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterServiceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterServiceResource> Update(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterServicePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterServiceResource>> UpdateAsync(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterServicePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class ServiceFabricManagedClustersExtensions
    {
        public static Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterVersion> GetManagedClusterVersion(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string clusterVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterVersion>> GetManagedClusterVersionAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string clusterVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterVersion> GetManagedClusterVersionByEnvironment(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterVersionEnvironment environment, string clusterVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterVersion>> GetManagedClusterVersionByEnvironmentAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterVersionEnvironment environment, string clusterVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterVersion> GetManagedClusterVersions(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterVersion> GetManagedClusterVersionsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterVersion> GetManagedClusterVersionsByEnvironment(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterVersionEnvironment environment, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterVersion> GetManagedClusterVersionsByEnvironmentAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterVersionEnvironment environment, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClustersVmSize> GetManagedUnsupportedVmSize(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string vmSize, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClustersVmSize>> GetManagedUnsupportedVmSizeAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string vmSize, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClustersVmSize> GetManagedUnsupportedVmSizes(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClustersVmSize> GetManagedUnsupportedVmSizesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterResource> GetServiceFabricManagedCluster(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterApplicationResource GetServiceFabricManagedClusterApplicationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterApplicationTypeResource GetServiceFabricManagedClusterApplicationTypeResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterApplicationTypeVersionResource GetServiceFabricManagedClusterApplicationTypeVersionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterResource>> GetServiceFabricManagedClusterAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterNodeTypeResource GetServiceFabricManagedClusterNodeTypeResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterResource GetServiceFabricManagedClusterResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterCollection GetServiceFabricManagedClusters(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterResource> GetServiceFabricManagedClusters(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterResource> GetServiceFabricManagedClustersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterServiceResource GetServiceFabricManagedClusterServiceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
}
namespace Azure.ResourceManager.ServiceFabricManagedClusters.Models
{
    public partial class AddRemoveIncrementalNamedPartitionScalingMechanism : Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterServiceScalingMechanism
    {
        public AddRemoveIncrementalNamedPartitionScalingMechanism(int minPartitionCount, int maxPartitionCount, int scaleIncrement) { }
        public int MaxPartitionCount { get { throw null; } set { } }
        public int MinPartitionCount { get { throw null; } set { } }
        public int ScaleIncrement { get { throw null; } set { } }
    }
    public partial class ApplicationHealthPolicy
    {
        public ApplicationHealthPolicy(bool considerWarningAsError, int maxPercentUnhealthyDeployedApplications) { }
        public bool ConsiderWarningAsError { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceTypeHealthPolicy DefaultServiceTypeHealthPolicy { get { throw null; } set { } }
        public int MaxPercentUnhealthyDeployedApplications { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceTypeHealthPolicy> ServiceTypeHealthPolicyMap { get { throw null; } }
    }
    public partial class ApplicationUpgradePolicy
    {
        public ApplicationUpgradePolicy() { }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.ApplicationHealthPolicy ApplicationHealthPolicy { get { throw null; } set { } }
        public bool? ForceRestart { get { throw null; } set { } }
        public long? InstanceCloseDelayDurationInSeconds { get { throw null; } set { } }
        public bool? RecreateApplication { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.RollingUpgradeMonitoringPolicy RollingUpgradeMonitoringPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.RollingUpgradeMode? UpgradeMode { get { throw null; } set { } }
        public long? UpgradeReplicaSetCheckTimeout { get { throw null; } set { } }
    }
    public partial class ApplicationUserAssignedIdentityInfo
    {
        public ApplicationUserAssignedIdentityInfo(string name, string principalId) { }
        public string Name { get { throw null; } set { } }
        public string PrincipalId { get { throw null; } set { } }
    }
    public partial class AveragePartitionLoadScalingTrigger : Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterServiceScalingTrigger
    {
        public AveragePartitionLoadScalingTrigger(string metricName, double lowerLoadThreshold, double upperLoadThreshold, string scaleInterval) { }
        public double LowerLoadThreshold { get { throw null; } set { } }
        public string MetricName { get { throw null; } set { } }
        public string ScaleInterval { get { throw null; } set { } }
        public double UpperLoadThreshold { get { throw null; } set { } }
    }
    public partial class AverageServiceLoadScalingTrigger : Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterServiceScalingTrigger
    {
        public AverageServiceLoadScalingTrigger(string metricName, double lowerLoadThreshold, double upperLoadThreshold, string scaleInterval, bool useOnlyPrimaryLoad) { }
        public double LowerLoadThreshold { get { throw null; } set { } }
        public string MetricName { get { throw null; } set { } }
        public string ScaleInterval { get { throw null; } set { } }
        public double UpperLoadThreshold { get { throw null; } set { } }
        public bool UseOnlyPrimaryLoad { get { throw null; } set { } }
    }
    public partial class ClusterFabricSettingsParameterDescription
    {
        public ClusterFabricSettingsParameterDescription(string name, string value) { }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class ClusterFabricSettingsSection
    {
        public ClusterFabricSettingsSection(string name, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ClusterFabricSettingsParameterDescription> parameters) { }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ClusterFabricSettingsParameterDescription> Parameters { get { throw null; } }
    }
    public partial class EndpointRangeDescription
    {
        public EndpointRangeDescription(int startPort, int endPort) { }
        public int EndPort { get { throw null; } set { } }
        public int StartPort { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedClusterAddOnFeature : System.IEquatable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterAddOnFeature>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedClusterAddOnFeature(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterAddOnFeature BackupRestoreService { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterAddOnFeature DnsService { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterAddOnFeature ResourceMonitorService { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterAddOnFeature other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterAddOnFeature left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterAddOnFeature right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterAddOnFeature (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterAddOnFeature left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterAddOnFeature right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ManagedClusterAzureActiveDirectory
    {
        public ManagedClusterAzureActiveDirectory() { }
        public string ClientApplication { get { throw null; } set { } }
        public string ClusterApplication { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
    }
    public partial class ManagedClusterClientCertificate
    {
        public ManagedClusterClientCertificate(bool isAdmin) { }
        public string CommonName { get { throw null; } set { } }
        public bool IsAdmin { get { throw null; } set { } }
        public System.BinaryData IssuerThumbprint { get { throw null; } set { } }
        public System.BinaryData Thumbprint { get { throw null; } set { } }
    }
    public partial class ManagedClusterIPTag
    {
        public ManagedClusterIPTag(string ipTagType, string tag) { }
        public string IPTagType { get { throw null; } set { } }
        public string Tag { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedClusterLoadBalanceProbeProtocol : System.IEquatable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterLoadBalanceProbeProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedClusterLoadBalanceProbeProtocol(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterLoadBalanceProbeProtocol Http { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterLoadBalanceProbeProtocol Https { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterLoadBalanceProbeProtocol Tcp { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterLoadBalanceProbeProtocol other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterLoadBalanceProbeProtocol left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterLoadBalanceProbeProtocol right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterLoadBalanceProbeProtocol (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterLoadBalanceProbeProtocol left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterLoadBalanceProbeProtocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ManagedClusterLoadBalancingRule
    {
        public ManagedClusterLoadBalancingRule(int frontendPort, int backendPort, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterLoadBalancingRuleTransportProtocol protocol, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterLoadBalanceProbeProtocol probeProtocol) { }
        public int BackendPort { get { throw null; } set { } }
        public int FrontendPort { get { throw null; } set { } }
        public string LoadDistribution { get { throw null; } set { } }
        public int? ProbePort { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterLoadBalanceProbeProtocol ProbeProtocol { get { throw null; } set { } }
        public string ProbeRequestPath { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterLoadBalancingRuleTransportProtocol Protocol { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedClusterLoadBalancingRuleTransportProtocol : System.IEquatable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterLoadBalancingRuleTransportProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedClusterLoadBalancingRuleTransportProtocol(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterLoadBalancingRuleTransportProtocol Tcp { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterLoadBalancingRuleTransportProtocol Udp { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterLoadBalancingRuleTransportProtocol other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterLoadBalancingRuleTransportProtocol left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterLoadBalancingRuleTransportProtocol right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterLoadBalancingRuleTransportProtocol (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterLoadBalancingRuleTransportProtocol left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterLoadBalancingRuleTransportProtocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ManagedClusterServiceBaseProperties
    {
        public ManagedClusterServiceBaseProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterServiceCorrelation> CorrelationScheme { get { throw null; } }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterServiceMoveCost? DefaultMoveCost { get { throw null; } set { } }
        public string PlacementConstraints { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterServiceScalingPolicy> ScalingPolicies { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterServiceLoadMetric> ServiceLoadMetrics { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterServicePlacementPolicy> ServicePlacementPolicies { get { throw null; } }
    }
    public partial class ManagedClusterServiceCorrelation
    {
        public ManagedClusterServiceCorrelation(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterServiceCorrelationScheme scheme, string serviceName) { }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterServiceCorrelationScheme Scheme { get { throw null; } set { } }
        public string ServiceName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedClusterServiceCorrelationScheme : System.IEquatable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterServiceCorrelationScheme>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedClusterServiceCorrelationScheme(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterServiceCorrelationScheme AlignedAffinity { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterServiceCorrelationScheme NonAlignedAffinity { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterServiceCorrelationScheme other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterServiceCorrelationScheme left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterServiceCorrelationScheme right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterServiceCorrelationScheme (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterServiceCorrelationScheme left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterServiceCorrelationScheme right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ManagedClusterServiceEndpoint
    {
        public ManagedClusterServiceEndpoint(string service) { }
        public System.Collections.Generic.IList<Azure.Core.AzureLocation> Locations { get { throw null; } }
        public string Service { get { throw null; } set { } }
    }
    public partial class ManagedClusterServiceLoadMetric
    {
        public ManagedClusterServiceLoadMetric(string name) { }
        public int? DefaultLoad { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public int? PrimaryDefaultLoad { get { throw null; } set { } }
        public int? SecondaryDefaultLoad { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterServiceLoadMetricWeight? Weight { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedClusterServiceLoadMetricWeight : System.IEquatable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterServiceLoadMetricWeight>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedClusterServiceLoadMetricWeight(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterServiceLoadMetricWeight High { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterServiceLoadMetricWeight Low { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterServiceLoadMetricWeight Medium { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterServiceLoadMetricWeight Zero { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterServiceLoadMetricWeight other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterServiceLoadMetricWeight left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterServiceLoadMetricWeight right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterServiceLoadMetricWeight (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterServiceLoadMetricWeight left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterServiceLoadMetricWeight right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedClusterServicePackageActivationMode : System.IEquatable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterServicePackageActivationMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedClusterServicePackageActivationMode(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterServicePackageActivationMode ExclusiveProcess { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterServicePackageActivationMode SharedProcess { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterServicePackageActivationMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterServicePackageActivationMode left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterServicePackageActivationMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterServicePackageActivationMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterServicePackageActivationMode left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterServicePackageActivationMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class ManagedClusterServicePartitionScheme
    {
        protected ManagedClusterServicePartitionScheme() { }
    }
    public abstract partial class ManagedClusterServicePlacementPolicy
    {
        protected ManagedClusterServicePlacementPolicy() { }
    }
    public partial class ManagedClusterServiceProperties : Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterServiceBaseProperties
    {
        public ManagedClusterServiceProperties(string serviceTypeName, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterServicePartitionScheme partitionDescription) { }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterServicePartitionScheme PartitionDescription { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterServicePackageActivationMode? ServicePackageActivationMode { get { throw null; } set { } }
        public string ServiceTypeName { get { throw null; } set { } }
    }
    public abstract partial class ManagedClusterServiceScalingMechanism
    {
        protected ManagedClusterServiceScalingMechanism() { }
    }
    public partial class ManagedClusterServiceScalingPolicy
    {
        public ManagedClusterServiceScalingPolicy(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterServiceScalingMechanism scalingMechanism, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterServiceScalingTrigger scalingTrigger) { }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterServiceScalingMechanism ScalingMechanism { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterServiceScalingTrigger ScalingTrigger { get { throw null; } set { } }
    }
    public abstract partial class ManagedClusterServiceScalingTrigger
    {
        protected ManagedClusterServiceScalingTrigger() { }
    }
    public partial class ManagedClusterSubnet
    {
        public ManagedClusterSubnet(string name) { }
        public bool? IsIPv6Enabled { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier NetworkSecurityGroupId { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.PrivateEndpointNetworkPolicy? PrivateEndpointNetworkPolicies { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.PrivateLinkServiceNetworkPolicy? PrivateLinkServiceNetworkPolicies { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedClusterUpgradeCadence : System.IEquatable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterUpgradeCadence>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedClusterUpgradeCadence(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterUpgradeCadence Wave0 { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterUpgradeCadence Wave1 { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterUpgradeCadence Wave2 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterUpgradeCadence other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterUpgradeCadence left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterUpgradeCadence right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterUpgradeCadence (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterUpgradeCadence left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterUpgradeCadence right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedClusterUpgradeMode : System.IEquatable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterUpgradeMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedClusterUpgradeMode(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterUpgradeMode Automatic { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterUpgradeMode Manual { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterUpgradeMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterUpgradeMode left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterUpgradeMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterUpgradeMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterUpgradeMode left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterUpgradeMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedClusterVersionEnvironment : System.IEquatable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterVersionEnvironment>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedClusterVersionEnvironment(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterVersionEnvironment Windows { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterVersionEnvironment other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterVersionEnvironment left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterVersionEnvironment right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterVersionEnvironment (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterVersionEnvironment left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterVersionEnvironment right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NamedPartitionScheme : Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterServicePartitionScheme
    {
        public NamedPartitionScheme(System.Collections.Generic.IEnumerable<string> names) { }
        public System.Collections.Generic.IList<string> Names { get { throw null; } }
    }
    public partial class NodeTypeActionContent
    {
        public NodeTypeActionContent(System.Collections.Generic.IEnumerable<string> nodes) { }
        public bool? IsForced { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Nodes { get { throw null; } }
    }
    public partial class NodeTypeAvailableSku
    {
        internal NodeTypeAvailableSku() { }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeSkuCapacity Capacity { get { throw null; } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeSupportedSku Sku { get { throw null; } }
    }
    public partial class NodeTypeFrontendConfiguration
    {
        public NodeTypeFrontendConfiguration() { }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeFrontendConfigurationIPAddressType? IPAddressType { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier LoadBalancerBackendAddressPoolId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier LoadBalancerInboundNatPoolId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NodeTypeFrontendConfigurationIPAddressType : System.IEquatable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeFrontendConfigurationIPAddressType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NodeTypeFrontendConfigurationIPAddressType(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeFrontendConfigurationIPAddressType IPv4 { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeFrontendConfigurationIPAddressType IPv6 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeFrontendConfigurationIPAddressType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeFrontendConfigurationIPAddressType left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeFrontendConfigurationIPAddressType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeFrontendConfigurationIPAddressType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeFrontendConfigurationIPAddressType left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeFrontendConfigurationIPAddressType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NodeTypeSku
    {
        public NodeTypeSku(int capacity) { }
        public int Capacity { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Tier { get { throw null; } set { } }
    }
    public partial class NodeTypeSkuCapacity
    {
        internal NodeTypeSkuCapacity() { }
        public int? Default { get { throw null; } }
        public int? Maximum { get { throw null; } }
        public int? Minimum { get { throw null; } }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeSkuScaleType? ScaleType { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NodeTypeSkuScaleType : System.IEquatable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeSkuScaleType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NodeTypeSkuScaleType(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeSkuScaleType Automatic { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeSkuScaleType Manual { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeSkuScaleType None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeSkuScaleType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeSkuScaleType left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeSkuScaleType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeSkuScaleType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeSkuScaleType left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeSkuScaleType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NodeTypeSupportedSku
    {
        internal NodeTypeSupportedSku() { }
        public string Name { get { throw null; } }
        public string Tier { get { throw null; } }
    }
    public partial class NodeTypeVaultCertificate
    {
        public NodeTypeVaultCertificate(System.Uri certificateUri, string certificateStore) { }
        public string CertificateStore { get { throw null; } set { } }
        public System.Uri CertificateUri { get { throw null; } set { } }
    }
    public partial class NodeTypeVaultSecretGroup
    {
        public NodeTypeVaultSecretGroup(Azure.ResourceManager.Resources.Models.WritableSubResource sourceVault, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeVaultCertificate> vaultCertificates) { }
        public Azure.Core.ResourceIdentifier SourceVaultId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeVaultCertificate> VaultCertificates { get { throw null; } }
    }
    public partial class NodeTypeVmssDataDisk
    {
        public NodeTypeVmssDataDisk(int lun, int diskSizeInGB, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedDataDiskType diskType, string diskLetter) { }
        public string DiskLetter { get { throw null; } set { } }
        public int DiskSizeInGB { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedDataDiskType DiskType { get { throw null; } set { } }
        public int Lun { get { throw null; } set { } }
    }
    public partial class PartitionInstanceCountScalingMechanism : Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterServiceScalingMechanism
    {
        public PartitionInstanceCountScalingMechanism(int minInstanceCount, int maxInstanceCount, int scaleIncrement) { }
        public int MaxInstanceCount { get { throw null; } set { } }
        public int MinInstanceCount { get { throw null; } set { } }
        public int ScaleIncrement { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PolicyViolationCompensationAction : System.IEquatable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.PolicyViolationCompensationAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PolicyViolationCompensationAction(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.PolicyViolationCompensationAction Manual { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.PolicyViolationCompensationAction Rollback { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabricManagedClusters.Models.PolicyViolationCompensationAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabricManagedClusters.Models.PolicyViolationCompensationAction left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.PolicyViolationCompensationAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabricManagedClusters.Models.PolicyViolationCompensationAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabricManagedClusters.Models.PolicyViolationCompensationAction left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.PolicyViolationCompensationAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PrivateEndpointNetworkPolicy : System.IEquatable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.PrivateEndpointNetworkPolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PrivateEndpointNetworkPolicy(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.PrivateEndpointNetworkPolicy Disabled { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.PrivateEndpointNetworkPolicy Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabricManagedClusters.Models.PrivateEndpointNetworkPolicy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabricManagedClusters.Models.PrivateEndpointNetworkPolicy left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.PrivateEndpointNetworkPolicy right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabricManagedClusters.Models.PrivateEndpointNetworkPolicy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabricManagedClusters.Models.PrivateEndpointNetworkPolicy left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.PrivateEndpointNetworkPolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PrivateLinkServiceNetworkPolicy : System.IEquatable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.PrivateLinkServiceNetworkPolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PrivateLinkServiceNetworkPolicy(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.PrivateLinkServiceNetworkPolicy Disabled { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.PrivateLinkServiceNetworkPolicy Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabricManagedClusters.Models.PrivateLinkServiceNetworkPolicy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabricManagedClusters.Models.PrivateLinkServiceNetworkPolicy left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.PrivateLinkServiceNetworkPolicy right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabricManagedClusters.Models.PrivateLinkServiceNetworkPolicy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabricManagedClusters.Models.PrivateLinkServiceNetworkPolicy left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.PrivateLinkServiceNetworkPolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RollingUpgradeMode : System.IEquatable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.RollingUpgradeMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RollingUpgradeMode(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.RollingUpgradeMode Monitored { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.RollingUpgradeMode UnmonitoredAuto { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabricManagedClusters.Models.RollingUpgradeMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabricManagedClusters.Models.RollingUpgradeMode left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.RollingUpgradeMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabricManagedClusters.Models.RollingUpgradeMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabricManagedClusters.Models.RollingUpgradeMode left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.RollingUpgradeMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RollingUpgradeMonitoringPolicy
    {
        public RollingUpgradeMonitoringPolicy(Azure.ResourceManager.ServiceFabricManagedClusters.Models.PolicyViolationCompensationAction failureAction, System.TimeSpan healthCheckWaitDuration, System.TimeSpan healthCheckStableDuration, System.TimeSpan healthCheckRetryTimeout, System.TimeSpan upgradeTimeout, System.TimeSpan upgradeDomainTimeout) { }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.PolicyViolationCompensationAction FailureAction { get { throw null; } set { } }
        public System.TimeSpan HealthCheckRetryTimeout { get { throw null; } set { } }
        public System.TimeSpan HealthCheckStableDuration { get { throw null; } set { } }
        public System.TimeSpan HealthCheckWaitDuration { get { throw null; } set { } }
        public System.TimeSpan UpgradeDomainTimeout { get { throw null; } set { } }
        public System.TimeSpan UpgradeTimeout { get { throw null; } set { } }
    }
    public partial class ServiceFabricManagedClusterApplicationPatch
    {
        public ServiceFabricManagedClusterApplicationPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class ServiceFabricManagedClusterApplicationTypePatch
    {
        public ServiceFabricManagedClusterApplicationTypePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class ServiceFabricManagedClusterApplicationTypeVersionPatch
    {
        public ServiceFabricManagedClusterApplicationTypeVersionPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class ServiceFabricManagedClusterNodeTypePatch
    {
        public ServiceFabricManagedClusterNodeTypePatch() { }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServiceFabricManagedClusterOSType : System.IEquatable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterOSType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServiceFabricManagedClusterOSType(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterOSType Windows { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterOSType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterOSType left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterOSType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterOSType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterOSType left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterOSType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ServiceFabricManagedClusterPatch
    {
        public ServiceFabricManagedClusterPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServiceFabricManagedClusterServiceMoveCost : System.IEquatable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterServiceMoveCost>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServiceFabricManagedClusterServiceMoveCost(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterServiceMoveCost High { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterServiceMoveCost Low { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterServiceMoveCost Medium { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterServiceMoveCost Zero { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterServiceMoveCost other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterServiceMoveCost left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterServiceMoveCost right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterServiceMoveCost (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterServiceMoveCost left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterServiceMoveCost right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ServiceFabricManagedClusterServicePatch
    {
        public ServiceFabricManagedClusterServicePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class ServiceFabricManagedClustersNetworkSecurityRule
    {
        public ServiceFabricManagedClustersNetworkSecurityRule(string name, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClustersNsgProtocol protocol, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClustersNetworkTrafficAccess access, int priority, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClustersNetworkSecurityRuleDirection direction) { }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClustersNetworkTrafficAccess Access { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DestinationAddressPrefix { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> DestinationAddressPrefixes { get { throw null; } }
        public string DestinationPortRange { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> DestinationPortRanges { get { throw null; } }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClustersNetworkSecurityRuleDirection Direction { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public int Priority { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClustersNsgProtocol Protocol { get { throw null; } set { } }
        public string SourceAddressPrefix { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SourceAddressPrefixes { get { throw null; } }
        public string SourcePortRange { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SourcePortRanges { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServiceFabricManagedClustersNetworkSecurityRuleDirection : System.IEquatable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClustersNetworkSecurityRuleDirection>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServiceFabricManagedClustersNetworkSecurityRuleDirection(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClustersNetworkSecurityRuleDirection Inbound { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClustersNetworkSecurityRuleDirection Outbound { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClustersNetworkSecurityRuleDirection other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClustersNetworkSecurityRuleDirection left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClustersNetworkSecurityRuleDirection right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClustersNetworkSecurityRuleDirection (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClustersNetworkSecurityRuleDirection left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClustersNetworkSecurityRuleDirection right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServiceFabricManagedClustersNetworkTrafficAccess : System.IEquatable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClustersNetworkTrafficAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServiceFabricManagedClustersNetworkTrafficAccess(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClustersNetworkTrafficAccess Allow { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClustersNetworkTrafficAccess Deny { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClustersNetworkTrafficAccess other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClustersNetworkTrafficAccess left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClustersNetworkTrafficAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClustersNetworkTrafficAccess (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClustersNetworkTrafficAccess left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClustersNetworkTrafficAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServiceFabricManagedClustersNsgProtocol : System.IEquatable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClustersNsgProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServiceFabricManagedClustersNsgProtocol(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClustersNsgProtocol AH { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClustersNsgProtocol Esp { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClustersNsgProtocol Http { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClustersNsgProtocol Https { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClustersNsgProtocol Icmp { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClustersNsgProtocol Tcp { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClustersNsgProtocol Udp { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClustersNsgProtocol other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClustersNsgProtocol left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClustersNsgProtocol right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClustersNsgProtocol (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClustersNsgProtocol left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClustersNsgProtocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServiceFabricManagedClustersSkuName : System.IEquatable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClustersSkuName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServiceFabricManagedClustersSkuName(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClustersSkuName Basic { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClustersSkuName Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClustersSkuName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClustersSkuName left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClustersSkuName right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClustersSkuName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClustersSkuName left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClustersSkuName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServiceFabricManagedClusterState : System.IEquatable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServiceFabricManagedClusterState(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterState BaselineUpgrade { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterState Deploying { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterState Ready { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterState UpgradeFailed { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterState Upgrading { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterState WaitingForNodes { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterState left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterState left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ServiceFabricManagedClustersVmSize : Azure.ResourceManager.Models.ResourceData
    {
        internal ServiceFabricManagedClustersVmSize() { }
        public string VmSize { get { throw null; } }
    }
    public partial class ServiceFabricManagedClusterVersion : Azure.ResourceManager.Models.ResourceData
    {
        internal ServiceFabricManagedClusterVersion() { }
        public string ClusterCodeVersion { get { throw null; } }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterOSType? OSType { get { throw null; } }
        public System.DateTimeOffset? VersionSupportExpireOn { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServiceFabricManagedDataDiskType : System.IEquatable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedDataDiskType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServiceFabricManagedDataDiskType(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedDataDiskType PremiumLrs { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedDataDiskType StandardLrs { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedDataDiskType StandardSsdLrs { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedDataDiskType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedDataDiskType left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedDataDiskType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedDataDiskType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedDataDiskType left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedDataDiskType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServiceFabricManagedResourceProvisioningState : System.IEquatable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedResourceProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServiceFabricManagedResourceProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedResourceProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedResourceProvisioningState Created { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedResourceProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedResourceProvisioningState Deleted { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedResourceProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedResourceProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedResourceProvisioningState None { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedResourceProvisioningState Other { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedResourceProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedResourceProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedResourceProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedResourceProvisioningState left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedResourceProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedResourceProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedResourceProvisioningState left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedResourceProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ServicePlacementInvalidDomainPolicy : Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterServicePlacementPolicy
    {
        public ServicePlacementInvalidDomainPolicy(string domainName) { }
        public string DomainName { get { throw null; } set { } }
    }
    public partial class ServicePlacementNonPartiallyPlaceServicePolicy : Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterServicePlacementPolicy
    {
        public ServicePlacementNonPartiallyPlaceServicePolicy() { }
    }
    public partial class ServicePlacementPreferPrimaryDomainPolicy : Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterServicePlacementPolicy
    {
        public ServicePlacementPreferPrimaryDomainPolicy(string domainName) { }
        public string DomainName { get { throw null; } set { } }
    }
    public partial class ServicePlacementRequiredDomainPolicy : Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterServicePlacementPolicy
    {
        public ServicePlacementRequiredDomainPolicy(string domainName) { }
        public string DomainName { get { throw null; } set { } }
    }
    public partial class ServicePlacementRequireDomainDistributionPolicy : Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterServicePlacementPolicy
    {
        public ServicePlacementRequireDomainDistributionPolicy(string domainName) { }
        public string DomainName { get { throw null; } set { } }
    }
    public partial class ServiceTypeHealthPolicy
    {
        public ServiceTypeHealthPolicy(int maxPercentUnhealthyServices, int maxPercentUnhealthyPartitionsPerService, int maxPercentUnhealthyReplicasPerPartition) { }
        public int MaxPercentUnhealthyPartitionsPerService { get { throw null; } set { } }
        public int MaxPercentUnhealthyReplicasPerPartition { get { throw null; } set { } }
        public int MaxPercentUnhealthyServices { get { throw null; } set { } }
    }
    public partial class SingletonPartitionScheme : Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterServicePartitionScheme
    {
        public SingletonPartitionScheme() { }
    }
    public partial class StatefulServiceProperties : Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterServiceProperties
    {
        public StatefulServiceProperties(string serviceTypeName, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterServicePartitionScheme partitionDescription) : base (default(string), default(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterServicePartitionScheme)) { }
        public bool? HasPersistedState { get { throw null; } set { } }
        public int? MinReplicaSetSize { get { throw null; } set { } }
        public System.TimeSpan? QuorumLossWaitDuration { get { throw null; } set { } }
        public System.TimeSpan? ReplicaRestartWaitDuration { get { throw null; } set { } }
        public System.TimeSpan? ServicePlacementTimeLimit { get { throw null; } set { } }
        public System.TimeSpan? StandByReplicaKeepDuration { get { throw null; } set { } }
        public int? TargetReplicaSetSize { get { throw null; } set { } }
    }
    public partial class StatelessServiceProperties : Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterServiceProperties
    {
        public StatelessServiceProperties(string serviceTypeName, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterServicePartitionScheme partitionDescription, int instanceCount) : base (default(string), default(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterServicePartitionScheme)) { }
        public int InstanceCount { get { throw null; } set { } }
        public int? MinInstanceCount { get { throw null; } set { } }
        public int? MinInstancePercentage { get { throw null; } set { } }
    }
    public partial class UniformInt64RangePartitionScheme : Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterServicePartitionScheme
    {
        public UniformInt64RangePartitionScheme(int count, long lowKey, long highKey) { }
        public int Count { get { throw null; } set { } }
        public long HighKey { get { throw null; } set { } }
        public long LowKey { get { throw null; } set { } }
    }
    public partial class VmssExtension
    {
        public VmssExtension(string name, string publisher, string vmssExtensionPropertiesType, string typeHandlerVersion) { }
        public bool? AutoUpgradeMinorVersion { get { throw null; } set { } }
        public bool? EnableAutomaticUpgrade { get { throw null; } set { } }
        public string ForceUpdateTag { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.BinaryData ProtectedSettings { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ProvisionAfterExtensions { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public string Publisher { get { throw null; } set { } }
        public System.BinaryData Settings { get { throw null; } set { } }
        public string TypeHandlerVersion { get { throw null; } set { } }
        public string VmssExtensionPropertiesType { get { throw null; } set { } }
    }
}
