namespace Azure.ResourceManager.ServiceFabricManagedClusters
{
    public partial class ApplicationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ApplicationResource() { }
        public virtual Azure.ResourceManager.ServiceFabricManagedClusters.ApplicationResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ApplicationResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ApplicationResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string applicationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ApplicationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ApplicationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceResource> GetServiceResource(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceResource>> GetServiceResourceAsync(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ServiceFabricManagedClusters.ServiceResourceCollection GetServiceResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ApplicationResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ApplicationResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ApplicationResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ApplicationResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ApplicationResource> Update(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ApplicationResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ApplicationResource>> UpdateAsync(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ApplicationResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApplicationResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.ApplicationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.ApplicationResource>, System.Collections.IEnumerable
    {
        protected ApplicationResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceFabricManagedClusters.ApplicationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string applicationName, Azure.ResourceManager.ServiceFabricManagedClusters.ApplicationResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceFabricManagedClusters.ApplicationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string applicationName, Azure.ResourceManager.ServiceFabricManagedClusters.ApplicationResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ApplicationResource> Get(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ServiceFabricManagedClusters.ApplicationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ServiceFabricManagedClusters.ApplicationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ApplicationResource>> GetAsync(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ServiceFabricManagedClusters.ApplicationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.ApplicationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ServiceFabricManagedClusters.ApplicationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.ApplicationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ApplicationResourceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ApplicationResourceData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ApplicationUserAssignedIdentity> ManagedIdentities { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Parameters { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.ApplicationUpgradePolicy UpgradePolicy { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
    }
    public partial class ApplicationTypeResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ApplicationTypeResource() { }
        public virtual Azure.ResourceManager.ServiceFabricManagedClusters.ApplicationTypeResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ApplicationTypeResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ApplicationTypeResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string applicationTypeName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ApplicationTypeResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ApplicationTypeVersionResource> GetApplicationTypeVersionResource(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ApplicationTypeVersionResource>> GetApplicationTypeVersionResourceAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ServiceFabricManagedClusters.ApplicationTypeVersionResourceCollection GetApplicationTypeVersionResources() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ApplicationTypeResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ApplicationTypeResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ApplicationTypeResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ApplicationTypeResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ApplicationTypeResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ApplicationTypeResource> Update(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ApplicationTypeResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ApplicationTypeResource>> UpdateAsync(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ApplicationTypeResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApplicationTypeResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.ApplicationTypeResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.ApplicationTypeResource>, System.Collections.IEnumerable
    {
        protected ApplicationTypeResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceFabricManagedClusters.ApplicationTypeResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string applicationTypeName, Azure.ResourceManager.ServiceFabricManagedClusters.ApplicationTypeResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceFabricManagedClusters.ApplicationTypeResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string applicationTypeName, Azure.ResourceManager.ServiceFabricManagedClusters.ApplicationTypeResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string applicationTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string applicationTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ApplicationTypeResource> Get(string applicationTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ServiceFabricManagedClusters.ApplicationTypeResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ServiceFabricManagedClusters.ApplicationTypeResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ApplicationTypeResource>> GetAsync(string applicationTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ServiceFabricManagedClusters.ApplicationTypeResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.ApplicationTypeResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ServiceFabricManagedClusters.ApplicationTypeResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.ApplicationTypeResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ApplicationTypeResourceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ApplicationTypeResourceData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string ProvisioningState { get { throw null; } }
    }
    public partial class ApplicationTypeVersionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ApplicationTypeVersionResource() { }
        public virtual Azure.ResourceManager.ServiceFabricManagedClusters.ApplicationTypeVersionResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ApplicationTypeVersionResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ApplicationTypeVersionResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string applicationTypeName, string version) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ApplicationTypeVersionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ApplicationTypeVersionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ApplicationTypeVersionResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ApplicationTypeVersionResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ApplicationTypeVersionResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ApplicationTypeVersionResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ApplicationTypeVersionResource> Update(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ApplicationTypeVersionResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ApplicationTypeVersionResource>> UpdateAsync(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ApplicationTypeVersionResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApplicationTypeVersionResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.ApplicationTypeVersionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.ApplicationTypeVersionResource>, System.Collections.IEnumerable
    {
        protected ApplicationTypeVersionResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceFabricManagedClusters.ApplicationTypeVersionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string version, Azure.ResourceManager.ServiceFabricManagedClusters.ApplicationTypeVersionResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceFabricManagedClusters.ApplicationTypeVersionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string version, Azure.ResourceManager.ServiceFabricManagedClusters.ApplicationTypeVersionResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ApplicationTypeVersionResource> Get(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ServiceFabricManagedClusters.ApplicationTypeVersionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ServiceFabricManagedClusters.ApplicationTypeVersionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ApplicationTypeVersionResource>> GetAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ServiceFabricManagedClusters.ApplicationTypeVersionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.ApplicationTypeVersionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ServiceFabricManagedClusters.ApplicationTypeVersionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.ApplicationTypeVersionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ApplicationTypeVersionResourceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ApplicationTypeVersionResourceData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.Uri AppPackageUri { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
    }
    public partial class LocationEnvironmentManagedClusterVersionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.LocationEnvironmentManagedClusterVersionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.LocationEnvironmentManagedClusterVersionResource>, System.Collections.IEnumerable
    {
        protected LocationEnvironmentManagedClusterVersionCollection() { }
        public virtual Azure.Response<bool> Exists(string clusterVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string clusterVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.LocationEnvironmentManagedClusterVersionResource> Get(string clusterVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ServiceFabricManagedClusters.LocationEnvironmentManagedClusterVersionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ServiceFabricManagedClusters.LocationEnvironmentManagedClusterVersionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.LocationEnvironmentManagedClusterVersionResource>> GetAsync(string clusterVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ServiceFabricManagedClusters.LocationEnvironmentManagedClusterVersionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.LocationEnvironmentManagedClusterVersionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ServiceFabricManagedClusters.LocationEnvironmentManagedClusterVersionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.LocationEnvironmentManagedClusterVersionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LocationEnvironmentManagedClusterVersionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LocationEnvironmentManagedClusterVersionResource() { }
        public virtual Azure.ResourceManager.ServiceFabricManagedClusters.ManagedClusterCodeVersionResultData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation location, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterVersionEnvironment environment, string clusterVersion) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.LocationEnvironmentManagedClusterVersionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.LocationEnvironmentManagedClusterVersionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LocationManagedClusterVersionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.LocationManagedClusterVersionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.LocationManagedClusterVersionResource>, System.Collections.IEnumerable
    {
        protected LocationManagedClusterVersionCollection() { }
        public virtual Azure.Response<bool> Exists(string clusterVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string clusterVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.LocationManagedClusterVersionResource> Get(string clusterVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ServiceFabricManagedClusters.LocationManagedClusterVersionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ServiceFabricManagedClusters.LocationManagedClusterVersionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.LocationManagedClusterVersionResource>> GetAsync(string clusterVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ServiceFabricManagedClusters.LocationManagedClusterVersionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.LocationManagedClusterVersionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ServiceFabricManagedClusters.LocationManagedClusterVersionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.LocationManagedClusterVersionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LocationManagedClusterVersionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LocationManagedClusterVersionResource() { }
        public virtual Azure.ResourceManager.ServiceFabricManagedClusters.ManagedClusterCodeVersionResultData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation location, string clusterVersion) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.LocationManagedClusterVersionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.LocationManagedClusterVersionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedClusterCodeVersionResultData : Azure.ResourceManager.Models.ResourceData
    {
        internal ManagedClusterCodeVersionResultData() { }
        public string ClusterCodeVersion { get { throw null; } }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.OSType? OSType { get { throw null; } }
        public string SupportExpiryUtc { get { throw null; } }
    }
    public partial class ManagedClusterCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.ManagedClusterResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.ManagedClusterResource>, System.Collections.IEnumerable
    {
        protected ManagedClusterCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceFabricManagedClusters.ManagedClusterResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string clusterName, Azure.ResourceManager.ServiceFabricManagedClusters.ManagedClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceFabricManagedClusters.ManagedClusterResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string clusterName, Azure.ResourceManager.ServiceFabricManagedClusters.ManagedClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ManagedClusterResource> Get(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ServiceFabricManagedClusters.ManagedClusterResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ServiceFabricManagedClusters.ManagedClusterResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ManagedClusterResource>> GetAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ServiceFabricManagedClusters.ManagedClusterResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.ManagedClusterResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ServiceFabricManagedClusters.ManagedClusterResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.ManagedClusterResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ManagedClusterData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ManagedClusterData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterAddOnFeature> AddonFeatures { get { throw null; } }
        public string AdminPassword { get { throw null; } set { } }
        public string AdminUserName { get { throw null; } set { } }
        public bool? AllowRdpAccess { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabricManagedClusters.Models.Subnet> AuxiliarySubnets { get { throw null; } }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.AzureActiveDirectory AzureActiveDirectory { get { throw null; } set { } }
        public int? ClientConnectionPort { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ClientCertificate> Clients { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ClusterCertificateThumbprints { get { throw null; } }
        public string ClusterCodeVersion { get { throw null; } set { } }
        public string ClusterId { get { throw null; } }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.ClusterState? ClusterState { get { throw null; } }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.ClusterUpgradeCadence? ClusterUpgradeCadence { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.ClusterUpgradeMode? ClusterUpgradeMode { get { throw null; } set { } }
        public string DnsName { get { throw null; } set { } }
        public bool? EnableAutoOSUpgrade { get { throw null; } set { } }
        public bool? EnableIPv6 { get { throw null; } set { } }
        public bool? EnableServicePublicIP { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabricManagedClusters.Models.SettingsSectionDescription> FabricSettings { get { throw null; } }
        public string Fqdn { get { throw null; } }
        public int? HttpGatewayConnectionPort { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabricManagedClusters.Models.IPTag> IPTags { get { throw null; } }
        public string IPv4Address { get { throw null; } }
        public string IPv6Address { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabricManagedClusters.Models.LoadBalancingRule> LoadBalancingRules { get { throw null; } }
        public int? MaxUnusedVersionsToKeep { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NetworkSecurityRule> NetworkSecurityRules { get { throw null; } }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedResourceProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceEndpoint> ServiceEndpoints { get { throw null; } }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClustersSkuName? SkuName { get { throw null; } set { } }
        public string SubnetId { get { throw null; } set { } }
        public bool? ZonalResiliency { get { throw null; } set { } }
    }
    public partial class ManagedClusterResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ManagedClusterResource() { }
        public virtual Azure.ResourceManager.ServiceFabricManagedClusters.ManagedClusterData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ManagedClusterResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ManagedClusterResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ManagedClusterResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ApplicationResource> GetApplicationResource(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ApplicationResource>> GetApplicationResourceAsync(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ServiceFabricManagedClusters.ApplicationResourceCollection GetApplicationResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ApplicationTypeResource> GetApplicationTypeResource(string applicationTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ApplicationTypeResource>> GetApplicationTypeResourceAsync(string applicationTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ServiceFabricManagedClusters.ApplicationTypeResourceCollection GetApplicationTypeResources() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ManagedClusterResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedAzResiliencyStatus> GetManagedAzResiliencyStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedAzResiliencyStatus>> GetManagedAzResiliencyStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.NodeTypeResource> GetNodeType(string nodeTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.NodeTypeResource>> GetNodeTypeAsync(string nodeTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ServiceFabricManagedClusters.NodeTypeCollection GetNodeTypes() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ManagedClusterResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ManagedClusterResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ManagedClusterResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ManagedClusterResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ManagedClusterResource> Update(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ManagedClusterResource>> UpdateAsync(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedVmSizeCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.ManagedVmSizeResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.ManagedVmSizeResource>, System.Collections.IEnumerable
    {
        protected ManagedVmSizeCollection() { }
        public virtual Azure.Response<bool> Exists(string vmSize, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string vmSize, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ManagedVmSizeResource> Get(string vmSize, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ServiceFabricManagedClusters.ManagedVmSizeResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ServiceFabricManagedClusters.ManagedVmSizeResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ManagedVmSizeResource>> GetAsync(string vmSize, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ServiceFabricManagedClusters.ManagedVmSizeResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.ManagedVmSizeResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ServiceFabricManagedClusters.ManagedVmSizeResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.ManagedVmSizeResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ManagedVmSizeData : Azure.ResourceManager.Models.ResourceData
    {
        internal ManagedVmSizeData() { }
        public string VmSize { get { throw null; } }
    }
    public partial class ManagedVmSizeResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ManagedVmSizeResource() { }
        public virtual Azure.ResourceManager.ServiceFabricManagedClusters.ManagedVmSizeData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation location, string vmSize) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ManagedVmSizeResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ManagedVmSizeResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NodeTypeCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.NodeTypeResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.NodeTypeResource>, System.Collections.IEnumerable
    {
        protected NodeTypeCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceFabricManagedClusters.NodeTypeResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string nodeTypeName, Azure.ResourceManager.ServiceFabricManagedClusters.NodeTypeData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceFabricManagedClusters.NodeTypeResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string nodeTypeName, Azure.ResourceManager.ServiceFabricManagedClusters.NodeTypeData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string nodeTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string nodeTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.NodeTypeResource> Get(string nodeTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ServiceFabricManagedClusters.NodeTypeResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ServiceFabricManagedClusters.NodeTypeResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.NodeTypeResource>> GetAsync(string nodeTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ServiceFabricManagedClusters.NodeTypeResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.NodeTypeResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ServiceFabricManagedClusters.NodeTypeResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.NodeTypeResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NodeTypeData : Azure.ResourceManager.Models.ResourceData
    {
        public NodeTypeData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabricManagedClusters.Models.VmssDataDisk> AdditionalDataDisks { get { throw null; } }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.EndpointRangeDescription ApplicationPorts { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Capacities { get { throw null; } }
        public string DataDiskLetter { get { throw null; } set { } }
        public int? DataDiskSizeGB { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.DiskType? DataDiskType { get { throw null; } set { } }
        public bool? EnableAcceleratedNetworking { get { throw null; } set { } }
        public bool? EnableEncryptionAtHost { get { throw null; } set { } }
        public bool? EnableOverProvisioning { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.EndpointRangeDescription EphemeralPorts { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.EvictionPolicyType? EvictionPolicy { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabricManagedClusters.Models.FrontendConfiguration> FrontendConfigurations { get { throw null; } }
        public string HostGroupId { get { throw null; } set { } }
        public bool? IsPrimary { get { throw null; } set { } }
        public bool? IsSpotVm { get { throw null; } set { } }
        public bool? IsStateless { get { throw null; } set { } }
        public bool? MultiplePlacementGroups { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NetworkSecurityRule> NetworkSecurityRules { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> PlacementProperties { get { throw null; } }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedResourceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeSku Sku { get { throw null; } set { } }
        public string SpotRestoreTimeout { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public bool? UseDefaultPublicLoadBalancer { get { throw null; } set { } }
        public bool? UseEphemeralOSDisk { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> UserAssignedIdentities { get { throw null; } }
        public bool? UseTempDataDisk { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabricManagedClusters.Models.VmssExtension> VmExtensions { get { throw null; } }
        public string VmImageOffer { get { throw null; } set { } }
        public string VmImagePublisher { get { throw null; } set { } }
        public string VmImageSku { get { throw null; } set { } }
        public string VmImageVersion { get { throw null; } set { } }
        public int? VmInstanceCount { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabricManagedClusters.Models.VaultSecretGroup> VmSecrets { get { throw null; } }
        public string VmSize { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
    }
    public partial class NodeTypeResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NodeTypeResource() { }
        public virtual Azure.ResourceManager.ServiceFabricManagedClusters.NodeTypeData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.NodeTypeResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.NodeTypeResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string nodeTypeName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation DeleteNode(Azure.WaitUntil waitUntil, Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeActionParameters nodeTypeActionParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteNodeAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeActionParameters nodeTypeActionParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.NodeTypeResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.NodeTypeResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeAvailableSku> GetNodeTypeSkus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeAvailableSku> GetNodeTypeSkusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Reimage(Azure.WaitUntil waitUntil, Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeActionParameters nodeTypeActionParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ReimageAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeActionParameters nodeTypeActionParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.NodeTypeResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.NodeTypeResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Restart(Azure.WaitUntil waitUntil, Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeActionParameters nodeTypeActionParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RestartAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeActionParameters nodeTypeActionParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.NodeTypeResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.NodeTypeResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.NodeTypeResource> Update(Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.NodeTypeResource>> UpdateAsync(Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class ServiceFabricManagedClustersExtensions
    {
        public static Azure.ResourceManager.ServiceFabricManagedClusters.ApplicationResource GetApplicationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.ApplicationTypeResource GetApplicationTypeResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.ApplicationTypeVersionResource GetApplicationTypeVersionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.LocationEnvironmentManagedClusterVersionResource> GetLocationEnvironmentManagedClusterVersion(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterVersionEnvironment environment, string clusterVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.LocationEnvironmentManagedClusterVersionResource>> GetLocationEnvironmentManagedClusterVersionAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterVersionEnvironment environment, string clusterVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.LocationEnvironmentManagedClusterVersionResource GetLocationEnvironmentManagedClusterVersionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.LocationEnvironmentManagedClusterVersionCollection GetLocationEnvironmentManagedClusterVersions(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterVersionEnvironment environment) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.LocationManagedClusterVersionResource> GetLocationManagedClusterVersion(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string clusterVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.LocationManagedClusterVersionResource>> GetLocationManagedClusterVersionAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string clusterVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.LocationManagedClusterVersionResource GetLocationManagedClusterVersionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.LocationManagedClusterVersionCollection GetLocationManagedClusterVersions(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ManagedClusterResource> GetManagedCluster(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ManagedClusterResource>> GetManagedClusterAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.ManagedClusterResource GetManagedClusterResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.ManagedClusterCollection GetManagedClusters(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ServiceFabricManagedClusters.ManagedClusterResource> GetManagedClusters(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ServiceFabricManagedClusters.ManagedClusterResource> GetManagedClustersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ManagedVmSizeResource> GetManagedVmSize(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string vmSize, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ManagedVmSizeResource>> GetManagedVmSizeAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string vmSize, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.ManagedVmSizeResource GetManagedVmSizeResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.ManagedVmSizeCollection GetManagedVmSizes(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.NodeTypeResource GetNodeTypeResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response GetOperationResult(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response> GetOperationResultAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.ServiceResource GetServiceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class ServiceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServiceResource() { }
        public virtual Azure.ResourceManager.ServiceFabricManagedClusters.ServiceResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string applicationName, string serviceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceResource> Update(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceResource>> UpdateAsync(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServiceResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceResource>, System.Collections.IEnumerable
    {
        protected ServiceResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string serviceName, Azure.ResourceManager.ServiceFabricManagedClusters.ServiceResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string serviceName, Azure.ResourceManager.ServiceFabricManagedClusters.ServiceResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceResource> Get(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceResource>> GetAsync(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServiceResourceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ServiceResourceData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceResourceProperties Properties { get { throw null; } set { } }
    }
}
namespace Azure.ResourceManager.ServiceFabricManagedClusters.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Access : System.IEquatable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.Access>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Access(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.Access Allow { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.Access Deny { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabricManagedClusters.Models.Access other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabricManagedClusters.Models.Access left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.Access right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabricManagedClusters.Models.Access (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabricManagedClusters.Models.Access left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.Access right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AddRemoveIncrementalNamedPartitionScalingMechanism : Azure.ResourceManager.ServiceFabricManagedClusters.Models.ScalingMechanism
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
    public partial class ApplicationResourcePatch
    {
        public ApplicationResourcePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class ApplicationTypeResourcePatch
    {
        public ApplicationTypeResourcePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class ApplicationTypeVersionResourcePatch
    {
        public ApplicationTypeVersionResourcePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class ApplicationUpgradePolicy
    {
        public ApplicationUpgradePolicy() { }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.ApplicationHealthPolicy ApplicationHealthPolicy { get { throw null; } set { } }
        public bool? ForceRestart { get { throw null; } set { } }
        public long? InstanceCloseDelayDuration { get { throw null; } set { } }
        public bool? RecreateApplication { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.RollingUpgradeMonitoringPolicy RollingUpgradeMonitoringPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.RollingUpgradeMode? UpgradeMode { get { throw null; } set { } }
        public long? UpgradeReplicaSetCheckTimeout { get { throw null; } set { } }
    }
    public partial class ApplicationUserAssignedIdentity
    {
        public ApplicationUserAssignedIdentity(string name, string principalId) { }
        public string Name { get { throw null; } set { } }
        public string PrincipalId { get { throw null; } set { } }
    }
    public partial class AveragePartitionLoadScalingTrigger : Azure.ResourceManager.ServiceFabricManagedClusters.Models.ScalingTrigger
    {
        public AveragePartitionLoadScalingTrigger(string metricName, double lowerLoadThreshold, double upperLoadThreshold, string scaleInterval) { }
        public double LowerLoadThreshold { get { throw null; } set { } }
        public string MetricName { get { throw null; } set { } }
        public string ScaleInterval { get { throw null; } set { } }
        public double UpperLoadThreshold { get { throw null; } set { } }
    }
    public partial class AverageServiceLoadScalingTrigger : Azure.ResourceManager.ServiceFabricManagedClusters.Models.ScalingTrigger
    {
        public AverageServiceLoadScalingTrigger(string metricName, double lowerLoadThreshold, double upperLoadThreshold, string scaleInterval, bool useOnlyPrimaryLoad) { }
        public double LowerLoadThreshold { get { throw null; } set { } }
        public string MetricName { get { throw null; } set { } }
        public string ScaleInterval { get { throw null; } set { } }
        public double UpperLoadThreshold { get { throw null; } set { } }
        public bool UseOnlyPrimaryLoad { get { throw null; } set { } }
    }
    public partial class AzureActiveDirectory
    {
        public AzureActiveDirectory() { }
        public string ClientApplication { get { throw null; } set { } }
        public string ClusterApplication { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
    }
    public partial class ClientCertificate
    {
        public ClientCertificate(bool isAdmin) { }
        public string CommonName { get { throw null; } set { } }
        public bool IsAdmin { get { throw null; } set { } }
        public string IssuerThumbprint { get { throw null; } set { } }
        public string Thumbprint { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClusterState : System.IEquatable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ClusterState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClusterState(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ClusterState BaselineUpgrade { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ClusterState Deploying { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ClusterState Ready { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ClusterState UpgradeFailed { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ClusterState Upgrading { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ClusterState WaitingForNodes { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ClusterState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ClusterState left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ClusterState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabricManagedClusters.Models.ClusterState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ClusterState left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ClusterState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClusterUpgradeCadence : System.IEquatable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ClusterUpgradeCadence>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClusterUpgradeCadence(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ClusterUpgradeCadence Wave0 { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ClusterUpgradeCadence Wave1 { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ClusterUpgradeCadence Wave2 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ClusterUpgradeCadence other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ClusterUpgradeCadence left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ClusterUpgradeCadence right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabricManagedClusters.Models.ClusterUpgradeCadence (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ClusterUpgradeCadence left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ClusterUpgradeCadence right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClusterUpgradeMode : System.IEquatable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ClusterUpgradeMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClusterUpgradeMode(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ClusterUpgradeMode Automatic { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ClusterUpgradeMode Manual { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ClusterUpgradeMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ClusterUpgradeMode left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ClusterUpgradeMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabricManagedClusters.Models.ClusterUpgradeMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ClusterUpgradeMode left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ClusterUpgradeMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Direction : System.IEquatable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.Direction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Direction(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.Direction Inbound { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.Direction Outbound { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabricManagedClusters.Models.Direction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabricManagedClusters.Models.Direction left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.Direction right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabricManagedClusters.Models.Direction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabricManagedClusters.Models.Direction left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.Direction right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiskType : System.IEquatable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.DiskType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiskType(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.DiskType PremiumLRS { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.DiskType StandardLRS { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.DiskType StandardSSDLRS { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabricManagedClusters.Models.DiskType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabricManagedClusters.Models.DiskType left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.DiskType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabricManagedClusters.Models.DiskType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabricManagedClusters.Models.DiskType left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.DiskType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EndpointRangeDescription
    {
        public EndpointRangeDescription(int startPort, int endPort) { }
        public int EndPort { get { throw null; } set { } }
        public int StartPort { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EvictionPolicyType : System.IEquatable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.EvictionPolicyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EvictionPolicyType(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.EvictionPolicyType Deallocate { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.EvictionPolicyType Delete { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabricManagedClusters.Models.EvictionPolicyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabricManagedClusters.Models.EvictionPolicyType left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.EvictionPolicyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabricManagedClusters.Models.EvictionPolicyType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabricManagedClusters.Models.EvictionPolicyType left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.EvictionPolicyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FailureAction : System.IEquatable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.FailureAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FailureAction(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.FailureAction Manual { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.FailureAction Rollback { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabricManagedClusters.Models.FailureAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabricManagedClusters.Models.FailureAction left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.FailureAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabricManagedClusters.Models.FailureAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabricManagedClusters.Models.FailureAction left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.FailureAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FrontendConfiguration
    {
        public FrontendConfiguration() { }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.IPAddressType? IPAddressType { get { throw null; } set { } }
        public string LoadBalancerBackendAddressPoolId { get { throw null; } set { } }
        public string LoadBalancerInboundNatPoolId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IPAddressType : System.IEquatable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.IPAddressType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IPAddressType(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.IPAddressType IPv4 { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.IPAddressType IPv6 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabricManagedClusters.Models.IPAddressType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabricManagedClusters.Models.IPAddressType left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.IPAddressType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabricManagedClusters.Models.IPAddressType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabricManagedClusters.Models.IPAddressType left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.IPAddressType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IPTag
    {
        public IPTag(string ipTagType, string tag) { }
        public string IPTagType { get { throw null; } set { } }
        public string Tag { get { throw null; } set { } }
    }
    public partial class LoadBalancingRule
    {
        public LoadBalancingRule(int frontendPort, int backendPort, Azure.ResourceManager.ServiceFabricManagedClusters.Models.Protocol protocol, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ProbeProtocol probeProtocol) { }
        public int BackendPort { get { throw null; } set { } }
        public int FrontendPort { get { throw null; } set { } }
        public string LoadDistribution { get { throw null; } set { } }
        public int? ProbePort { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.ProbeProtocol ProbeProtocol { get { throw null; } set { } }
        public string ProbeRequestPath { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.Protocol Protocol { get { throw null; } set { } }
    }
    public partial class ManagedAzResiliencyStatus
    {
        internal ManagedAzResiliencyStatus() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ResourceAzStatus> BaseResourceStatus { get { throw null; } }
        public bool? IsClusterZoneResilient { get { throw null; } }
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
    public partial class ManagedClusterPatch
    {
        public ManagedClusterPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedResourceProvisioningState : System.IEquatable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedResourceProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedResourceProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedResourceProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedResourceProvisioningState Created { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedResourceProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedResourceProvisioningState Deleted { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedResourceProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedResourceProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedResourceProvisioningState None { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedResourceProvisioningState Other { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedResourceProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedResourceProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedResourceProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedResourceProvisioningState left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedResourceProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedResourceProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedResourceProvisioningState left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedResourceProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MoveCost : System.IEquatable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.MoveCost>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MoveCost(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.MoveCost High { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.MoveCost Low { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.MoveCost Medium { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.MoveCost Zero { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabricManagedClusters.Models.MoveCost other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabricManagedClusters.Models.MoveCost left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.MoveCost right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabricManagedClusters.Models.MoveCost (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabricManagedClusters.Models.MoveCost left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.MoveCost right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NamedPartitionScheme : Azure.ResourceManager.ServiceFabricManagedClusters.Models.Partition
    {
        public NamedPartitionScheme(System.Collections.Generic.IEnumerable<string> names) { }
        public System.Collections.Generic.IList<string> Names { get { throw null; } }
    }
    public partial class NetworkSecurityRule
    {
        public NetworkSecurityRule(string name, Azure.ResourceManager.ServiceFabricManagedClusters.Models.NsgProtocol protocol, Azure.ResourceManager.ServiceFabricManagedClusters.Models.Access access, int priority, Azure.ResourceManager.ServiceFabricManagedClusters.Models.Direction direction) { }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.Access Access { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DestinationAddressPrefix { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> DestinationAddressPrefixes { get { throw null; } }
        public string DestinationPortRange { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> DestinationPortRanges { get { throw null; } }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.Direction Direction { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public int Priority { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.NsgProtocol Protocol { get { throw null; } set { } }
        public string SourceAddressPrefix { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SourceAddressPrefixes { get { throw null; } }
        public string SourcePortRange { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SourcePortRanges { get { throw null; } }
    }
    public partial class NodeTypeActionParameters
    {
        public NodeTypeActionParameters(System.Collections.Generic.IEnumerable<string> nodes) { }
        public bool? Force { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Nodes { get { throw null; } }
    }
    public partial class NodeTypeAvailableSku
    {
        internal NodeTypeAvailableSku() { }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeSkuCapacity Capacity { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeSupportedSku Sku { get { throw null; } }
    }
    public partial class NodeTypePatch
    {
        public NodeTypePatch() { }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NsgProtocol : System.IEquatable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NsgProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NsgProtocol(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.NsgProtocol Ah { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.NsgProtocol Esp { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.NsgProtocol Http { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.NsgProtocol Https { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.NsgProtocol Icmp { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.NsgProtocol Tcp { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.NsgProtocol Udp { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabricManagedClusters.Models.NsgProtocol other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabricManagedClusters.Models.NsgProtocol left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.NsgProtocol right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabricManagedClusters.Models.NsgProtocol (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabricManagedClusters.Models.NsgProtocol left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.NsgProtocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OSType : System.IEquatable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.OSType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OSType(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.OSType Windows { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabricManagedClusters.Models.OSType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabricManagedClusters.Models.OSType left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.OSType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabricManagedClusters.Models.OSType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabricManagedClusters.Models.OSType left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.OSType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class Partition
    {
        protected Partition() { }
    }
    public partial class PartitionInstanceCountScaleMechanism : Azure.ResourceManager.ServiceFabricManagedClusters.Models.ScalingMechanism
    {
        public PartitionInstanceCountScaleMechanism(int minInstanceCount, int maxInstanceCount, int scaleIncrement) { }
        public int MaxInstanceCount { get { throw null; } set { } }
        public int MinInstanceCount { get { throw null; } set { } }
        public int ScaleIncrement { get { throw null; } set { } }
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
    public readonly partial struct ProbeProtocol : System.IEquatable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ProbeProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProbeProtocol(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ProbeProtocol Http { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ProbeProtocol Https { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ProbeProtocol Tcp { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ProbeProtocol other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ProbeProtocol left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ProbeProtocol right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabricManagedClusters.Models.ProbeProtocol (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ProbeProtocol left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ProbeProtocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Protocol : System.IEquatable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.Protocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Protocol(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.Protocol Tcp { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.Protocol Udp { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabricManagedClusters.Models.Protocol other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabricManagedClusters.Models.Protocol left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.Protocol right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabricManagedClusters.Models.Protocol (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabricManagedClusters.Models.Protocol left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.Protocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResourceAzStatus
    {
        internal ResourceAzStatus() { }
        public bool? IsZoneResilient { get { throw null; } }
        public string ResourceName { get { throw null; } }
        public string ResourceType { get { throw null; } }
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
        public RollingUpgradeMonitoringPolicy(Azure.ResourceManager.ServiceFabricManagedClusters.Models.FailureAction failureAction, System.TimeSpan healthCheckWaitDuration, System.TimeSpan healthCheckStableDuration, string healthCheckRetryTimeout, string upgradeTimeout, string upgradeDomainTimeout) { }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.FailureAction FailureAction { get { throw null; } set { } }
        public string HealthCheckRetryTimeout { get { throw null; } set { } }
        public System.TimeSpan HealthCheckStableDuration { get { throw null; } set { } }
        public System.TimeSpan HealthCheckWaitDuration { get { throw null; } set { } }
        public string UpgradeDomainTimeout { get { throw null; } set { } }
        public string UpgradeTimeout { get { throw null; } set { } }
    }
    public abstract partial class ScalingMechanism
    {
        protected ScalingMechanism() { }
    }
    public partial class ScalingPolicy
    {
        public ScalingPolicy(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ScalingMechanism scalingMechanism, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ScalingTrigger scalingTrigger) { }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.ScalingMechanism ScalingMechanism { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.ScalingTrigger ScalingTrigger { get { throw null; } set { } }
    }
    public abstract partial class ScalingTrigger
    {
        protected ScalingTrigger() { }
    }
    public partial class ServiceCorrelation
    {
        public ServiceCorrelation(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceCorrelationScheme scheme, string serviceName) { }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceCorrelationScheme Scheme { get { throw null; } set { } }
        public string ServiceName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServiceCorrelationScheme : System.IEquatable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceCorrelationScheme>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServiceCorrelationScheme(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceCorrelationScheme AlignedAffinity { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceCorrelationScheme NonAlignedAffinity { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceCorrelationScheme other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceCorrelationScheme left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceCorrelationScheme right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceCorrelationScheme (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceCorrelationScheme left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceCorrelationScheme right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ServiceEndpoint
    {
        public ServiceEndpoint(string service) { }
        public System.Collections.Generic.IList<string> Locations { get { throw null; } }
        public string Service { get { throw null; } set { } }
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
    public partial class ServiceLoadMetric
    {
        public ServiceLoadMetric(string name) { }
        public int? DefaultLoad { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public int? PrimaryDefaultLoad { get { throw null; } set { } }
        public int? SecondaryDefaultLoad { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceLoadMetricWeight? Weight { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServiceLoadMetricWeight : System.IEquatable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceLoadMetricWeight>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServiceLoadMetricWeight(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceLoadMetricWeight High { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceLoadMetricWeight Low { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceLoadMetricWeight Medium { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceLoadMetricWeight Zero { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceLoadMetricWeight other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceLoadMetricWeight left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceLoadMetricWeight right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceLoadMetricWeight (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceLoadMetricWeight left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceLoadMetricWeight right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServicePackageActivationMode : System.IEquatable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServicePackageActivationMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServicePackageActivationMode(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServicePackageActivationMode ExclusiveProcess { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServicePackageActivationMode SharedProcess { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServicePackageActivationMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServicePackageActivationMode left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServicePackageActivationMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServicePackageActivationMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServicePackageActivationMode left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServicePackageActivationMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ServicePlacementInvalidDomainPolicy : Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServicePlacementPolicy
    {
        public ServicePlacementInvalidDomainPolicy(string domainName) { }
        public string DomainName { get { throw null; } set { } }
    }
    public partial class ServicePlacementNonPartiallyPlaceServicePolicy : Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServicePlacementPolicy
    {
        public ServicePlacementNonPartiallyPlaceServicePolicy() { }
    }
    public abstract partial class ServicePlacementPolicy
    {
        protected ServicePlacementPolicy() { }
    }
    public partial class ServicePlacementPreferPrimaryDomainPolicy : Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServicePlacementPolicy
    {
        public ServicePlacementPreferPrimaryDomainPolicy(string domainName) { }
        public string DomainName { get { throw null; } set { } }
    }
    public partial class ServicePlacementRequiredDomainPolicy : Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServicePlacementPolicy
    {
        public ServicePlacementRequiredDomainPolicy(string domainName) { }
        public string DomainName { get { throw null; } set { } }
    }
    public partial class ServicePlacementRequireDomainDistributionPolicy : Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServicePlacementPolicy
    {
        public ServicePlacementRequireDomainDistributionPolicy(string domainName) { }
        public string DomainName { get { throw null; } set { } }
    }
    public partial class ServiceResourcePatch
    {
        public ServiceResourcePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class ServiceResourceProperties : Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceResourcePropertiesBase
    {
        public ServiceResourceProperties(string serviceTypeName, Azure.ResourceManager.ServiceFabricManagedClusters.Models.Partition partitionDescription) { }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.Partition PartitionDescription { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServicePackageActivationMode? ServicePackageActivationMode { get { throw null; } set { } }
        public string ServiceTypeName { get { throw null; } set { } }
    }
    public partial class ServiceResourcePropertiesBase
    {
        public ServiceResourcePropertiesBase() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceCorrelation> CorrelationScheme { get { throw null; } }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.MoveCost? DefaultMoveCost { get { throw null; } set { } }
        public string PlacementConstraints { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ScalingPolicy> ScalingPolicies { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceLoadMetric> ServiceLoadMetrics { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServicePlacementPolicy> ServicePlacementPolicies { get { throw null; } }
    }
    public partial class ServiceTypeHealthPolicy
    {
        public ServiceTypeHealthPolicy(int maxPercentUnhealthyServices, int maxPercentUnhealthyPartitionsPerService, int maxPercentUnhealthyReplicasPerPartition) { }
        public int MaxPercentUnhealthyPartitionsPerService { get { throw null; } set { } }
        public int MaxPercentUnhealthyReplicasPerPartition { get { throw null; } set { } }
        public int MaxPercentUnhealthyServices { get { throw null; } set { } }
    }
    public partial class SettingsParameterDescription
    {
        public SettingsParameterDescription(string name, string value) { }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class SettingsSectionDescription
    {
        public SettingsSectionDescription(string name, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.SettingsParameterDescription> parameters) { }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabricManagedClusters.Models.SettingsParameterDescription> Parameters { get { throw null; } }
    }
    public partial class SingletonPartitionScheme : Azure.ResourceManager.ServiceFabricManagedClusters.Models.Partition
    {
        public SingletonPartitionScheme() { }
    }
    public partial class StatefulServiceProperties : Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceResourceProperties
    {
        public StatefulServiceProperties(string serviceTypeName, Azure.ResourceManager.ServiceFabricManagedClusters.Models.Partition partitionDescription) : base (default(string), default(Azure.ResourceManager.ServiceFabricManagedClusters.Models.Partition)) { }
        public bool? HasPersistedState { get { throw null; } set { } }
        public int? MinReplicaSetSize { get { throw null; } set { } }
        public System.TimeSpan? QuorumLossWaitDuration { get { throw null; } set { } }
        public System.TimeSpan? ReplicaRestartWaitDuration { get { throw null; } set { } }
        public System.TimeSpan? ServicePlacementTimeLimit { get { throw null; } set { } }
        public System.TimeSpan? StandByReplicaKeepDuration { get { throw null; } set { } }
        public int? TargetReplicaSetSize { get { throw null; } set { } }
    }
    public partial class StatelessServiceProperties : Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceResourceProperties
    {
        public StatelessServiceProperties(string serviceTypeName, Azure.ResourceManager.ServiceFabricManagedClusters.Models.Partition partitionDescription, int instanceCount) : base (default(string), default(Azure.ResourceManager.ServiceFabricManagedClusters.Models.Partition)) { }
        public int InstanceCount { get { throw null; } set { } }
        public int? MinInstanceCount { get { throw null; } set { } }
        public int? MinInstancePercentage { get { throw null; } set { } }
    }
    public partial class Subnet
    {
        public Subnet(string name) { }
        public bool? EnableIPv6 { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string NetworkSecurityGroupId { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.PrivateEndpointNetworkPolicy? PrivateEndpointNetworkPolicies { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.PrivateLinkServiceNetworkPolicy? PrivateLinkServiceNetworkPolicies { get { throw null; } set { } }
    }
    public partial class UniformInt64RangePartitionScheme : Azure.ResourceManager.ServiceFabricManagedClusters.Models.Partition
    {
        public UniformInt64RangePartitionScheme(int count, long lowKey, long highKey) { }
        public int Count { get { throw null; } set { } }
        public long HighKey { get { throw null; } set { } }
        public long LowKey { get { throw null; } set { } }
    }
    public partial class VaultCertificate
    {
        public VaultCertificate(System.Uri certificateUri, string certificateStore) { }
        public string CertificateStore { get { throw null; } set { } }
        public System.Uri CertificateUri { get { throw null; } set { } }
    }
    public partial class VaultSecretGroup
    {
        public VaultSecretGroup(Azure.ResourceManager.Resources.Models.WritableSubResource sourceVault, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.VaultCertificate> vaultCertificates) { }
        public Azure.Core.ResourceIdentifier SourceVaultId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabricManagedClusters.Models.VaultCertificate> VaultCertificates { get { throw null; } }
    }
    public partial class VmssDataDisk
    {
        public VmssDataDisk(int lun, int diskSizeGB, Azure.ResourceManager.ServiceFabricManagedClusters.Models.DiskType diskType, string diskLetter) { }
        public string DiskLetter { get { throw null; } set { } }
        public int DiskSizeGB { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.DiskType DiskType { get { throw null; } set { } }
        public int Lun { get { throw null; } set { } }
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
