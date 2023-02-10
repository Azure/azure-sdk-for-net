namespace Azure.ResourceManager.ServiceFabric
{
    public partial class ServiceFabricApplicationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceFabric.ServiceFabricApplicationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabric.ServiceFabricApplicationResource>, System.Collections.IEnumerable
    {
        protected ServiceFabricApplicationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceFabric.ServiceFabricApplicationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string applicationName, Azure.ResourceManager.ServiceFabric.ServiceFabricApplicationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceFabric.ServiceFabricApplicationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string applicationName, Azure.ResourceManager.ServiceFabric.ServiceFabricApplicationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabric.ServiceFabricApplicationResource> Get(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ServiceFabric.ServiceFabricApplicationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ServiceFabric.ServiceFabricApplicationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabric.ServiceFabricApplicationResource>> GetAsync(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ServiceFabric.ServiceFabricApplicationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceFabric.ServiceFabricApplicationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ServiceFabric.ServiceFabricApplicationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabric.ServiceFabricApplicationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServiceFabricApplicationData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ServiceFabricApplicationData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabric.Models.ApplicationUserAssignedIdentity> ManagedIdentities { get { throw null; } }
        public long? MaximumNodes { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabric.Models.ApplicationMetricDescription> Metrics { get { throw null; } }
        public long? MinimumNodes { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Parameters { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public bool? RemoveApplicationCapacity { get { throw null; } set { } }
        public string TypeName { get { throw null; } set { } }
        public string TypeVersion { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabric.Models.ApplicationUpgradePolicy UpgradePolicy { get { throw null; } set { } }
    }
    public partial class ServiceFabricApplicationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServiceFabricApplicationResource() { }
        public virtual Azure.ResourceManager.ServiceFabric.ServiceFabricApplicationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabric.ServiceFabricApplicationResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabric.ServiceFabricApplicationResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string applicationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabric.ServiceFabricApplicationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabric.ServiceFabricApplicationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabric.ServiceFabricServiceResource> GetServiceFabricService(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabric.ServiceFabricServiceResource>> GetServiceFabricServiceAsync(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ServiceFabric.ServiceFabricServiceCollection GetServiceFabricServices() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabric.ServiceFabricApplicationResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabric.ServiceFabricApplicationResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabric.ServiceFabricApplicationResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabric.ServiceFabricApplicationResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceFabric.ServiceFabricApplicationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ServiceFabric.Models.ServiceFabricApplicationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceFabric.ServiceFabricApplicationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ServiceFabric.Models.ServiceFabricApplicationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServiceFabricApplicationTypeCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceFabric.ServiceFabricApplicationTypeResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabric.ServiceFabricApplicationTypeResource>, System.Collections.IEnumerable
    {
        protected ServiceFabricApplicationTypeCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceFabric.ServiceFabricApplicationTypeResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string applicationTypeName, Azure.ResourceManager.ServiceFabric.ServiceFabricApplicationTypeData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceFabric.ServiceFabricApplicationTypeResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string applicationTypeName, Azure.ResourceManager.ServiceFabric.ServiceFabricApplicationTypeData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string applicationTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string applicationTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabric.ServiceFabricApplicationTypeResource> Get(string applicationTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ServiceFabric.ServiceFabricApplicationTypeResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ServiceFabric.ServiceFabricApplicationTypeResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabric.ServiceFabricApplicationTypeResource>> GetAsync(string applicationTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ServiceFabric.ServiceFabricApplicationTypeResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceFabric.ServiceFabricApplicationTypeResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ServiceFabric.ServiceFabricApplicationTypeResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabric.ServiceFabricApplicationTypeResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServiceFabricApplicationTypeData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ServiceFabricApplicationTypeData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ETag? ETag { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
    }
    public partial class ServiceFabricApplicationTypeResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServiceFabricApplicationTypeResource() { }
        public virtual Azure.ResourceManager.ServiceFabric.ServiceFabricApplicationTypeData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabric.ServiceFabricApplicationTypeResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabric.ServiceFabricApplicationTypeResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string applicationTypeName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabric.ServiceFabricApplicationTypeResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabric.ServiceFabricApplicationTypeResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabric.ServiceFabricApplicationTypeVersionResource> GetServiceFabricApplicationTypeVersion(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabric.ServiceFabricApplicationTypeVersionResource>> GetServiceFabricApplicationTypeVersionAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ServiceFabric.ServiceFabricApplicationTypeVersionCollection GetServiceFabricApplicationTypeVersions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabric.ServiceFabricApplicationTypeResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabric.ServiceFabricApplicationTypeResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabric.ServiceFabricApplicationTypeResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabric.ServiceFabricApplicationTypeResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceFabric.ServiceFabricApplicationTypeResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ServiceFabric.ServiceFabricApplicationTypeData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceFabric.ServiceFabricApplicationTypeResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ServiceFabric.ServiceFabricApplicationTypeData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServiceFabricApplicationTypeVersionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceFabric.ServiceFabricApplicationTypeVersionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabric.ServiceFabricApplicationTypeVersionResource>, System.Collections.IEnumerable
    {
        protected ServiceFabricApplicationTypeVersionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceFabric.ServiceFabricApplicationTypeVersionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string version, Azure.ResourceManager.ServiceFabric.ServiceFabricApplicationTypeVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceFabric.ServiceFabricApplicationTypeVersionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string version, Azure.ResourceManager.ServiceFabric.ServiceFabricApplicationTypeVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabric.ServiceFabricApplicationTypeVersionResource> Get(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ServiceFabric.ServiceFabricApplicationTypeVersionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ServiceFabric.ServiceFabricApplicationTypeVersionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabric.ServiceFabricApplicationTypeVersionResource>> GetAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ServiceFabric.ServiceFabricApplicationTypeVersionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceFabric.ServiceFabricApplicationTypeVersionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ServiceFabric.ServiceFabricApplicationTypeVersionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabric.ServiceFabricApplicationTypeVersionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServiceFabricApplicationTypeVersionData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ServiceFabricApplicationTypeVersionData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.Uri AppPackageUri { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> DefaultParameterList { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
    }
    public partial class ServiceFabricApplicationTypeVersionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServiceFabricApplicationTypeVersionResource() { }
        public virtual Azure.ResourceManager.ServiceFabric.ServiceFabricApplicationTypeVersionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabric.ServiceFabricApplicationTypeVersionResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabric.ServiceFabricApplicationTypeVersionResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string applicationTypeName, string version) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabric.ServiceFabricApplicationTypeVersionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabric.ServiceFabricApplicationTypeVersionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabric.ServiceFabricApplicationTypeVersionResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabric.ServiceFabricApplicationTypeVersionResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabric.ServiceFabricApplicationTypeVersionResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabric.ServiceFabricApplicationTypeVersionResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceFabric.ServiceFabricApplicationTypeVersionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ServiceFabric.ServiceFabricApplicationTypeVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceFabric.ServiceFabricApplicationTypeVersionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ServiceFabric.ServiceFabricApplicationTypeVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServiceFabricClusterCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceFabric.ServiceFabricClusterResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabric.ServiceFabricClusterResource>, System.Collections.IEnumerable
    {
        protected ServiceFabricClusterCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceFabric.ServiceFabricClusterResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string clusterName, Azure.ResourceManager.ServiceFabric.ServiceFabricClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceFabric.ServiceFabricClusterResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string clusterName, Azure.ResourceManager.ServiceFabric.ServiceFabricClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabric.ServiceFabricClusterResource> Get(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ServiceFabric.ServiceFabricClusterResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ServiceFabric.ServiceFabricClusterResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabric.ServiceFabricClusterResource>> GetAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ServiceFabric.ServiceFabricClusterResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceFabric.ServiceFabricClusterResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ServiceFabric.ServiceFabricClusterResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabric.ServiceFabricClusterResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServiceFabricClusterData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ServiceFabricClusterData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabric.Models.ClusterAddOnFeature> AddOnFeatures { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ServiceFabric.Models.ClusterVersionDetails> AvailableClusterVersions { get { throw null; } }
        public Azure.ResourceManager.ServiceFabric.Models.ClusterAadSetting AzureActiveDirectory { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabric.Models.ClusterCertificateDescription Certificate { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabric.Models.ClusterServerCertificateCommonNames CertificateCommonNames { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabric.Models.ClusterClientCertificateCommonName> ClientCertificateCommonNames { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabric.Models.ClusterClientCertificateThumbprint> ClientCertificateThumbprints { get { throw null; } }
        public string ClusterCodeVersion { get { throw null; } set { } }
        public System.Uri ClusterEndpoint { get { throw null; } }
        public System.Guid? ClusterId { get { throw null; } }
        public Azure.ResourceManager.ServiceFabric.Models.ServiceFabricClusterState? ClusterState { get { throw null; } }
        public Azure.ResourceManager.ServiceFabric.Models.DiagnosticsStorageAccountConfig DiagnosticsStorageAccountConfig { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabric.Models.SettingsSectionDescription> FabricSettings { get { throw null; } }
        public bool? IsEventStoreServiceEnabled { get { throw null; } set { } }
        public bool? IsInfrastructureServiceManagerEnabled { get { throw null; } set { } }
        public bool? IsWaveUpgradePaused { get { throw null; } set { } }
        public System.Uri ManagementEndpoint { get { throw null; } set { } }
        public long? MaxUnusedVersionsToKeep { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabric.Models.ClusterNodeTypeDescription> NodeTypes { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabric.Models.ClusterNotification> Notifications { get { throw null; } }
        public Azure.ResourceManager.ServiceFabric.Models.ServiceFabricProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ServiceFabric.Models.ClusterReliabilityLevel? ReliabilityLevel { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabric.Models.ClusterCertificateDescription ReverseProxyCertificate { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabric.Models.ClusterServerCertificateCommonNames ReverseProxyCertificateCommonNames { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabric.Models.SfZonalUpgradeMode? ServiceFabricZonalUpgradeMode { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabric.Models.ClusterUpgradePolicy UpgradeDescription { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabric.Models.ClusterUpgradeMode? UpgradeMode { get { throw null; } set { } }
        public System.DateTimeOffset? UpgradePauseEndOn { get { throw null; } set { } }
        public System.DateTimeOffset? UpgradePauseStartOn { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabric.Models.ClusterUpgradeCadence? UpgradeWave { get { throw null; } set { } }
        public string VmImage { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabric.Models.VmssZonalUpgradeMode? VmssZonalUpgradeMode { get { throw null; } set { } }
    }
    public partial class ServiceFabricClusterResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServiceFabricClusterResource() { }
        public virtual Azure.ResourceManager.ServiceFabric.ServiceFabricClusterData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabric.ServiceFabricClusterResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabric.ServiceFabricClusterResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabric.ServiceFabricClusterResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabric.ServiceFabricClusterResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabric.ServiceFabricApplicationResource> GetServiceFabricApplication(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabric.ServiceFabricApplicationResource>> GetServiceFabricApplicationAsync(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ServiceFabric.ServiceFabricApplicationCollection GetServiceFabricApplications() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabric.ServiceFabricApplicationTypeResource> GetServiceFabricApplicationType(string applicationTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabric.ServiceFabricApplicationTypeResource>> GetServiceFabricApplicationTypeAsync(string applicationTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ServiceFabric.ServiceFabricApplicationTypeCollection GetServiceFabricApplicationTypes() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabric.Models.UpgradableVersionPathResult> GetUpgradableVersions(Azure.ResourceManager.ServiceFabric.Models.UpgradableVersionsDescription versionsDescription = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabric.Models.UpgradableVersionPathResult>> GetUpgradableVersionsAsync(Azure.ResourceManager.ServiceFabric.Models.UpgradableVersionsDescription versionsDescription = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabric.ServiceFabricClusterResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabric.ServiceFabricClusterResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabric.ServiceFabricClusterResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabric.ServiceFabricClusterResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceFabric.ServiceFabricClusterResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ServiceFabric.Models.ServiceFabricClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceFabric.ServiceFabricClusterResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ServiceFabric.Models.ServiceFabricClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class ServiceFabricExtensions
    {
        public static Azure.Pageable<Azure.ResourceManager.ServiceFabric.Models.ClusterCodeVersionsResult> GetClusterVersions(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string clusterVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ServiceFabric.Models.ClusterCodeVersionsResult> GetClusterVersions(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ServiceFabric.Models.ClusterCodeVersionsResult> GetClusterVersionsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string clusterVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ServiceFabric.Models.ClusterCodeVersionsResult> GetClusterVersionsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ServiceFabric.Models.ClusterCodeVersionsResult> GetClusterVersionsByEnvironment(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.ServiceFabric.Models.ClusterVersionsEnvironment environment, string clusterVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ServiceFabric.Models.ClusterCodeVersionsResult> GetClusterVersionsByEnvironment(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.ServiceFabric.Models.ClusterVersionsEnvironment environment, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ServiceFabric.Models.ClusterCodeVersionsResult> GetClusterVersionsByEnvironmentAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.ServiceFabric.Models.ClusterVersionsEnvironment environment, string clusterVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ServiceFabric.Models.ClusterCodeVersionsResult> GetClusterVersionsByEnvironmentAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.ServiceFabric.Models.ClusterVersionsEnvironment environment, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ServiceFabric.ServiceFabricApplicationResource GetServiceFabricApplicationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ServiceFabric.ServiceFabricApplicationTypeResource GetServiceFabricApplicationTypeResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ServiceFabric.ServiceFabricApplicationTypeVersionResource GetServiceFabricApplicationTypeVersionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ServiceFabric.ServiceFabricClusterResource> GetServiceFabricCluster(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabric.ServiceFabricClusterResource>> GetServiceFabricClusterAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ServiceFabric.ServiceFabricClusterResource GetServiceFabricClusterResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ServiceFabric.ServiceFabricClusterCollection GetServiceFabricClusters(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ServiceFabric.ServiceFabricClusterResource> GetServiceFabricClusters(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ServiceFabric.ServiceFabricClusterResource> GetServiceFabricClustersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ServiceFabric.ServiceFabricServiceResource GetServiceFabricServiceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class ServiceFabricServiceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceFabric.ServiceFabricServiceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabric.ServiceFabricServiceResource>, System.Collections.IEnumerable
    {
        protected ServiceFabricServiceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceFabric.ServiceFabricServiceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string serviceName, Azure.ResourceManager.ServiceFabric.ServiceFabricServiceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceFabric.ServiceFabricServiceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string serviceName, Azure.ResourceManager.ServiceFabric.ServiceFabricServiceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabric.ServiceFabricServiceResource> Get(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ServiceFabric.ServiceFabricServiceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ServiceFabric.ServiceFabricServiceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabric.ServiceFabricServiceResource>> GetAsync(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ServiceFabric.ServiceFabricServiceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceFabric.ServiceFabricServiceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ServiceFabric.ServiceFabricServiceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabric.ServiceFabricServiceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServiceFabricServiceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ServiceFabricServiceData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabric.Models.ServiceCorrelationDescription> CorrelationScheme { get { throw null; } }
        public Azure.ResourceManager.ServiceFabric.Models.ApplicationMoveCost? DefaultMoveCost { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.ServiceFabric.Models.PartitionSchemeDescription PartitionDescription { get { throw null; } set { } }
        public string PlacementConstraints { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public string ServiceDnsName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabric.Models.ServiceLoadMetricDescription> ServiceLoadMetrics { get { throw null; } }
        public Azure.ResourceManager.ServiceFabric.Models.ArmServicePackageActivationMode? ServicePackageActivationMode { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabric.Models.ServicePlacementPolicyDescription> ServicePlacementPolicies { get { throw null; } }
        public string ServiceTypeName { get { throw null; } set { } }
    }
    public partial class ServiceFabricServiceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServiceFabricServiceResource() { }
        public virtual Azure.ResourceManager.ServiceFabric.ServiceFabricServiceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabric.ServiceFabricServiceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabric.ServiceFabricServiceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string applicationName, string serviceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabric.ServiceFabricServiceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabric.ServiceFabricServiceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabric.ServiceFabricServiceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabric.ServiceFabricServiceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabric.ServiceFabricServiceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabric.ServiceFabricServiceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceFabric.ServiceFabricServiceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ServiceFabric.Models.ServiceFabricServicePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceFabric.ServiceFabricServiceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ServiceFabric.Models.ServiceFabricServicePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ServiceFabric.Models
{
    public partial class ApplicationDeltaHealthPolicy
    {
        public ApplicationDeltaHealthPolicy() { }
        public int? MaxPercentDeltaUnhealthyServices { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.ServiceFabric.Models.ServiceTypeDeltaHealthPolicy> ServiceTypeDeltaHealthPolicies { get { throw null; } }
    }
    public partial class ApplicationHealthPolicy
    {
        public ApplicationHealthPolicy() { }
        public int? MaxPercentUnhealthyServices { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.ServiceFabric.Models.ServiceTypeHealthPolicy> ServiceTypeHealthPolicies { get { throw null; } }
    }
    public partial class ApplicationMetricDescription
    {
        public ApplicationMetricDescription() { }
        public long? MaximumCapacity { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public long? ReservationCapacity { get { throw null; } set { } }
        public long? TotalApplicationCapacity { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ApplicationMoveCost : System.IEquatable<Azure.ResourceManager.ServiceFabric.Models.ApplicationMoveCost>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ApplicationMoveCost(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabric.Models.ApplicationMoveCost High { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabric.Models.ApplicationMoveCost Low { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabric.Models.ApplicationMoveCost Medium { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabric.Models.ApplicationMoveCost Zero { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabric.Models.ApplicationMoveCost other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabric.Models.ApplicationMoveCost left, Azure.ResourceManager.ServiceFabric.Models.ApplicationMoveCost right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabric.Models.ApplicationMoveCost (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabric.Models.ApplicationMoveCost left, Azure.ResourceManager.ServiceFabric.Models.ApplicationMoveCost right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ApplicationRollingUpgradeMode : System.IEquatable<Azure.ResourceManager.ServiceFabric.Models.ApplicationRollingUpgradeMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ApplicationRollingUpgradeMode(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabric.Models.ApplicationRollingUpgradeMode Invalid { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabric.Models.ApplicationRollingUpgradeMode Monitored { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabric.Models.ApplicationRollingUpgradeMode UnmonitoredAuto { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabric.Models.ApplicationRollingUpgradeMode UnmonitoredManual { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabric.Models.ApplicationRollingUpgradeMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabric.Models.ApplicationRollingUpgradeMode left, Azure.ResourceManager.ServiceFabric.Models.ApplicationRollingUpgradeMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabric.Models.ApplicationRollingUpgradeMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabric.Models.ApplicationRollingUpgradeMode left, Azure.ResourceManager.ServiceFabric.Models.ApplicationRollingUpgradeMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ApplicationUpgradePolicy
    {
        public ApplicationUpgradePolicy() { }
        public Azure.ResourceManager.ServiceFabric.Models.ArmApplicationHealthPolicy ApplicationHealthPolicy { get { throw null; } set { } }
        public bool? ForceRestart { get { throw null; } set { } }
        public bool? RecreateApplication { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabric.Models.ArmRollingUpgradeMonitoringPolicy RollingUpgradeMonitoringPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabric.Models.ApplicationRollingUpgradeMode? UpgradeMode { get { throw null; } set { } }
        public System.TimeSpan? UpgradeReplicaSetCheckTimeout { get { throw null; } set { } }
    }
    public partial class ApplicationUserAssignedIdentity
    {
        public ApplicationUserAssignedIdentity(string name, System.Guid principalId) { }
        public string Name { get { throw null; } set { } }
        public System.Guid PrincipalId { get { throw null; } set { } }
    }
    public partial class ArmApplicationHealthPolicy
    {
        public ArmApplicationHealthPolicy() { }
        public bool? ConsiderWarningAsError { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabric.Models.ArmServiceTypeHealthPolicy DefaultServiceTypeHealthPolicy { get { throw null; } set { } }
        public int? MaxPercentUnhealthyDeployedApplications { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.ServiceFabric.Models.ArmServiceTypeHealthPolicy> ServiceTypeHealthPolicyMap { get { throw null; } }
    }
    public partial class ArmRollingUpgradeMonitoringPolicy
    {
        public ArmRollingUpgradeMonitoringPolicy() { }
        public Azure.ResourceManager.ServiceFabric.Models.ArmUpgradeFailureAction? FailureAction { get { throw null; } set { } }
        public System.TimeSpan? HealthCheckRetryTimeout { get { throw null; } set { } }
        public System.TimeSpan? HealthCheckStableDuration { get { throw null; } set { } }
        public System.TimeSpan? HealthCheckWaitDuration { get { throw null; } set { } }
        public System.TimeSpan? UpgradeDomainTimeout { get { throw null; } set { } }
        public System.TimeSpan? UpgradeTimeout { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ArmServicePackageActivationMode : System.IEquatable<Azure.ResourceManager.ServiceFabric.Models.ArmServicePackageActivationMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ArmServicePackageActivationMode(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabric.Models.ArmServicePackageActivationMode ExclusiveProcess { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabric.Models.ArmServicePackageActivationMode SharedProcess { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabric.Models.ArmServicePackageActivationMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabric.Models.ArmServicePackageActivationMode left, Azure.ResourceManager.ServiceFabric.Models.ArmServicePackageActivationMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabric.Models.ArmServicePackageActivationMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabric.Models.ArmServicePackageActivationMode left, Azure.ResourceManager.ServiceFabric.Models.ArmServicePackageActivationMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ArmServiceTypeHealthPolicy
    {
        public ArmServiceTypeHealthPolicy() { }
        public int? MaxPercentUnhealthyPartitionsPerService { get { throw null; } set { } }
        public int? MaxPercentUnhealthyReplicasPerPartition { get { throw null; } set { } }
        public int? MaxPercentUnhealthyServices { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ArmUpgradeFailureAction : System.IEquatable<Azure.ResourceManager.ServiceFabric.Models.ArmUpgradeFailureAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ArmUpgradeFailureAction(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabric.Models.ArmUpgradeFailureAction Manual { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabric.Models.ArmUpgradeFailureAction Rollback { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabric.Models.ArmUpgradeFailureAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabric.Models.ArmUpgradeFailureAction left, Azure.ResourceManager.ServiceFabric.Models.ArmUpgradeFailureAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabric.Models.ArmUpgradeFailureAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabric.Models.ArmUpgradeFailureAction left, Azure.ResourceManager.ServiceFabric.Models.ArmUpgradeFailureAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ClusterAadSetting
    {
        public ClusterAadSetting() { }
        public string ClientApplication { get { throw null; } set { } }
        public string ClusterApplication { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClusterAddOnFeature : System.IEquatable<Azure.ResourceManager.ServiceFabric.Models.ClusterAddOnFeature>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClusterAddOnFeature(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabric.Models.ClusterAddOnFeature BackupRestoreService { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabric.Models.ClusterAddOnFeature DnsService { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabric.Models.ClusterAddOnFeature RepairManager { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabric.Models.ClusterAddOnFeature ResourceMonitorService { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabric.Models.ClusterAddOnFeature other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabric.Models.ClusterAddOnFeature left, Azure.ResourceManager.ServiceFabric.Models.ClusterAddOnFeature right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabric.Models.ClusterAddOnFeature (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabric.Models.ClusterAddOnFeature left, Azure.ResourceManager.ServiceFabric.Models.ClusterAddOnFeature right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ClusterCertificateDescription
    {
        public ClusterCertificateDescription(System.BinaryData thumbprint) { }
        public System.BinaryData Thumbprint { get { throw null; } set { } }
        public string ThumbprintSecondary { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabric.Models.ClusterCertificateStoreName? X509StoreName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClusterCertificateStoreName : System.IEquatable<Azure.ResourceManager.ServiceFabric.Models.ClusterCertificateStoreName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClusterCertificateStoreName(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabric.Models.ClusterCertificateStoreName AddressBook { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabric.Models.ClusterCertificateStoreName AuthRoot { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabric.Models.ClusterCertificateStoreName CertificateAuthority { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabric.Models.ClusterCertificateStoreName Disallowed { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabric.Models.ClusterCertificateStoreName My { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabric.Models.ClusterCertificateStoreName Root { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabric.Models.ClusterCertificateStoreName TrustedPeople { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabric.Models.ClusterCertificateStoreName TrustedPublisher { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabric.Models.ClusterCertificateStoreName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabric.Models.ClusterCertificateStoreName left, Azure.ResourceManager.ServiceFabric.Models.ClusterCertificateStoreName right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabric.Models.ClusterCertificateStoreName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabric.Models.ClusterCertificateStoreName left, Azure.ResourceManager.ServiceFabric.Models.ClusterCertificateStoreName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ClusterClientCertificateCommonName
    {
        public ClusterClientCertificateCommonName(bool isAdmin, string certificateCommonName, System.BinaryData certificateIssuerThumbprint) { }
        public string CertificateCommonName { get { throw null; } set { } }
        public System.BinaryData CertificateIssuerThumbprint { get { throw null; } set { } }
        public bool IsAdmin { get { throw null; } set { } }
    }
    public partial class ClusterClientCertificateThumbprint
    {
        public ClusterClientCertificateThumbprint(bool isAdmin, System.BinaryData certificateThumbprint) { }
        public System.BinaryData CertificateThumbprint { get { throw null; } set { } }
        public bool IsAdmin { get { throw null; } set { } }
    }
    public partial class ClusterCodeVersionsResult : Azure.ResourceManager.Models.ResourceData
    {
        internal ClusterCodeVersionsResult() { }
        public string CodeVersion { get { throw null; } }
        public Azure.ResourceManager.ServiceFabric.Models.ClusterEnvironment? Environment { get { throw null; } }
        public System.DateTimeOffset? SupportExpireOn { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClusterDurabilityLevel : System.IEquatable<Azure.ResourceManager.ServiceFabric.Models.ClusterDurabilityLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClusterDurabilityLevel(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabric.Models.ClusterDurabilityLevel Bronze { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabric.Models.ClusterDurabilityLevel Gold { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabric.Models.ClusterDurabilityLevel Silver { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabric.Models.ClusterDurabilityLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabric.Models.ClusterDurabilityLevel left, Azure.ResourceManager.ServiceFabric.Models.ClusterDurabilityLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabric.Models.ClusterDurabilityLevel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabric.Models.ClusterDurabilityLevel left, Azure.ResourceManager.ServiceFabric.Models.ClusterDurabilityLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ClusterEndpointRangeDescription
    {
        public ClusterEndpointRangeDescription(int startPort, int endPort) { }
        public int EndPort { get { throw null; } set { } }
        public int StartPort { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClusterEnvironment : System.IEquatable<Azure.ResourceManager.ServiceFabric.Models.ClusterEnvironment>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClusterEnvironment(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabric.Models.ClusterEnvironment Linux { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabric.Models.ClusterEnvironment Windows { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabric.Models.ClusterEnvironment other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabric.Models.ClusterEnvironment left, Azure.ResourceManager.ServiceFabric.Models.ClusterEnvironment right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabric.Models.ClusterEnvironment (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabric.Models.ClusterEnvironment left, Azure.ResourceManager.ServiceFabric.Models.ClusterEnvironment right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ClusterHealthPolicy
    {
        public ClusterHealthPolicy() { }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.ServiceFabric.Models.ApplicationHealthPolicy> ApplicationHealthPolicies { get { throw null; } }
        public int? MaxPercentUnhealthyApplications { get { throw null; } set { } }
        public int? MaxPercentUnhealthyNodes { get { throw null; } set { } }
    }
    public partial class ClusterNodeTypeDescription
    {
        public ClusterNodeTypeDescription(string name, int clientConnectionEndpointPort, int httpGatewayEndpointPort, bool isPrimary, int vmInstanceCount) { }
        public Azure.ResourceManager.ServiceFabric.Models.ClusterEndpointRangeDescription ApplicationPorts { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Capacities { get { throw null; } }
        public int ClientConnectionEndpointPort { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabric.Models.ClusterDurabilityLevel? DurabilityLevel { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabric.Models.ClusterEndpointRangeDescription EphemeralPorts { get { throw null; } set { } }
        public int HttpGatewayEndpointPort { get { throw null; } set { } }
        public bool? IsMultipleAvailabilityZonesSupported { get { throw null; } set { } }
        public bool IsPrimary { get { throw null; } set { } }
        public bool? IsStateless { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> PlacementProperties { get { throw null; } }
        public int? ReverseProxyEndpointPort { get { throw null; } set { } }
        public int VmInstanceCount { get { throw null; } set { } }
    }
    public partial class ClusterNotification
    {
        public ClusterNotification(bool isEnabled, Azure.ResourceManager.ServiceFabric.Models.ClusterNotificationCategory notificationCategory, Azure.ResourceManager.ServiceFabric.Models.ClusterNotificationLevel notificationLevel, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabric.Models.ClusterNotificationTarget> notificationTargets) { }
        public bool IsEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabric.Models.ClusterNotificationCategory NotificationCategory { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabric.Models.ClusterNotificationLevel NotificationLevel { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabric.Models.ClusterNotificationTarget> NotificationTargets { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClusterNotificationCategory : System.IEquatable<Azure.ResourceManager.ServiceFabric.Models.ClusterNotificationCategory>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClusterNotificationCategory(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabric.Models.ClusterNotificationCategory WaveProgress { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabric.Models.ClusterNotificationCategory other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabric.Models.ClusterNotificationCategory left, Azure.ResourceManager.ServiceFabric.Models.ClusterNotificationCategory right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabric.Models.ClusterNotificationCategory (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabric.Models.ClusterNotificationCategory left, Azure.ResourceManager.ServiceFabric.Models.ClusterNotificationCategory right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClusterNotificationChannel : System.IEquatable<Azure.ResourceManager.ServiceFabric.Models.ClusterNotificationChannel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClusterNotificationChannel(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabric.Models.ClusterNotificationChannel EmailSubscription { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabric.Models.ClusterNotificationChannel EmailUser { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabric.Models.ClusterNotificationChannel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabric.Models.ClusterNotificationChannel left, Azure.ResourceManager.ServiceFabric.Models.ClusterNotificationChannel right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabric.Models.ClusterNotificationChannel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabric.Models.ClusterNotificationChannel left, Azure.ResourceManager.ServiceFabric.Models.ClusterNotificationChannel right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClusterNotificationLevel : System.IEquatable<Azure.ResourceManager.ServiceFabric.Models.ClusterNotificationLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClusterNotificationLevel(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabric.Models.ClusterNotificationLevel All { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabric.Models.ClusterNotificationLevel Critical { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabric.Models.ClusterNotificationLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabric.Models.ClusterNotificationLevel left, Azure.ResourceManager.ServiceFabric.Models.ClusterNotificationLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabric.Models.ClusterNotificationLevel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabric.Models.ClusterNotificationLevel left, Azure.ResourceManager.ServiceFabric.Models.ClusterNotificationLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ClusterNotificationTarget
    {
        public ClusterNotificationTarget(Azure.ResourceManager.ServiceFabric.Models.ClusterNotificationChannel notificationChannel, System.Collections.Generic.IEnumerable<string> receivers) { }
        public Azure.ResourceManager.ServiceFabric.Models.ClusterNotificationChannel NotificationChannel { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Receivers { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClusterReliabilityLevel : System.IEquatable<Azure.ResourceManager.ServiceFabric.Models.ClusterReliabilityLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClusterReliabilityLevel(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabric.Models.ClusterReliabilityLevel Bronze { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabric.Models.ClusterReliabilityLevel Gold { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabric.Models.ClusterReliabilityLevel None { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabric.Models.ClusterReliabilityLevel Platinum { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabric.Models.ClusterReliabilityLevel Silver { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabric.Models.ClusterReliabilityLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabric.Models.ClusterReliabilityLevel left, Azure.ResourceManager.ServiceFabric.Models.ClusterReliabilityLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabric.Models.ClusterReliabilityLevel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabric.Models.ClusterReliabilityLevel left, Azure.ResourceManager.ServiceFabric.Models.ClusterReliabilityLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ClusterServerCertificateCommonName
    {
        public ClusterServerCertificateCommonName(string certificateCommonName, System.BinaryData certificateIssuerThumbprint) { }
        public string CertificateCommonName { get { throw null; } set { } }
        public System.BinaryData CertificateIssuerThumbprint { get { throw null; } set { } }
    }
    public partial class ClusterServerCertificateCommonNames
    {
        public ClusterServerCertificateCommonNames() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabric.Models.ClusterServerCertificateCommonName> CommonNames { get { throw null; } }
        public Azure.ResourceManager.ServiceFabric.Models.ClusterCertificateStoreName? X509StoreName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClusterUpgradeCadence : System.IEquatable<Azure.ResourceManager.ServiceFabric.Models.ClusterUpgradeCadence>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClusterUpgradeCadence(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabric.Models.ClusterUpgradeCadence Wave0 { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabric.Models.ClusterUpgradeCadence Wave1 { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabric.Models.ClusterUpgradeCadence Wave2 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabric.Models.ClusterUpgradeCadence other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabric.Models.ClusterUpgradeCadence left, Azure.ResourceManager.ServiceFabric.Models.ClusterUpgradeCadence right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabric.Models.ClusterUpgradeCadence (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabric.Models.ClusterUpgradeCadence left, Azure.ResourceManager.ServiceFabric.Models.ClusterUpgradeCadence right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ClusterUpgradeDeltaHealthPolicy
    {
        public ClusterUpgradeDeltaHealthPolicy(int maxPercentDeltaUnhealthyNodes, int maxPercentUpgradeDomainDeltaUnhealthyNodes, int maxPercentDeltaUnhealthyApplications) { }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.ServiceFabric.Models.ApplicationDeltaHealthPolicy> ApplicationDeltaHealthPolicies { get { throw null; } }
        public int MaxPercentDeltaUnhealthyApplications { get { throw null; } set { } }
        public int MaxPercentDeltaUnhealthyNodes { get { throw null; } set { } }
        public int MaxPercentUpgradeDomainDeltaUnhealthyNodes { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClusterUpgradeMode : System.IEquatable<Azure.ResourceManager.ServiceFabric.Models.ClusterUpgradeMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClusterUpgradeMode(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabric.Models.ClusterUpgradeMode Automatic { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabric.Models.ClusterUpgradeMode Manual { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabric.Models.ClusterUpgradeMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabric.Models.ClusterUpgradeMode left, Azure.ResourceManager.ServiceFabric.Models.ClusterUpgradeMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabric.Models.ClusterUpgradeMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabric.Models.ClusterUpgradeMode left, Azure.ResourceManager.ServiceFabric.Models.ClusterUpgradeMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ClusterUpgradePolicy
    {
        public ClusterUpgradePolicy(System.TimeSpan upgradeReplicaSetCheckTimeout, System.TimeSpan healthCheckWaitDuration, System.TimeSpan healthCheckStableDuration, System.TimeSpan healthCheckRetryTimeout, System.TimeSpan upgradeTimeout, System.TimeSpan upgradeDomainTimeout, Azure.ResourceManager.ServiceFabric.Models.ClusterHealthPolicy healthPolicy) { }
        public Azure.ResourceManager.ServiceFabric.Models.ClusterUpgradeDeltaHealthPolicy DeltaHealthPolicy { get { throw null; } set { } }
        public bool? ForceRestart { get { throw null; } set { } }
        public System.TimeSpan HealthCheckRetryTimeout { get { throw null; } set { } }
        public System.TimeSpan HealthCheckStableDuration { get { throw null; } set { } }
        public System.TimeSpan HealthCheckWaitDuration { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabric.Models.ClusterHealthPolicy HealthPolicy { get { throw null; } set { } }
        public System.TimeSpan UpgradeDomainTimeout { get { throw null; } set { } }
        public System.TimeSpan UpgradeReplicaSetCheckTimeout { get { throw null; } set { } }
        public System.TimeSpan UpgradeTimeout { get { throw null; } set { } }
    }
    public partial class ClusterVersionDetails
    {
        internal ClusterVersionDetails() { }
        public string CodeVersion { get { throw null; } }
        public Azure.ResourceManager.ServiceFabric.Models.ClusterEnvironment? Environment { get { throw null; } }
        public System.DateTimeOffset? SupportExpireOn { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClusterVersionsEnvironment : System.IEquatable<Azure.ResourceManager.ServiceFabric.Models.ClusterVersionsEnvironment>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClusterVersionsEnvironment(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabric.Models.ClusterVersionsEnvironment Linux { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabric.Models.ClusterVersionsEnvironment Windows { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabric.Models.ClusterVersionsEnvironment other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabric.Models.ClusterVersionsEnvironment left, Azure.ResourceManager.ServiceFabric.Models.ClusterVersionsEnvironment right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabric.Models.ClusterVersionsEnvironment (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabric.Models.ClusterVersionsEnvironment left, Azure.ResourceManager.ServiceFabric.Models.ClusterVersionsEnvironment right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DiagnosticsStorageAccountConfig
    {
        public DiagnosticsStorageAccountConfig(string storageAccountName, string protectedAccountKeyName, System.Uri blobEndpoint, System.Uri queueEndpoint, System.Uri tableEndpoint) { }
        public System.Uri BlobEndpoint { get { throw null; } set { } }
        public string ProtectedAccountKeyName { get { throw null; } set { } }
        public string ProtectedAccountKeyName2 { get { throw null; } set { } }
        public System.Uri QueueEndpoint { get { throw null; } set { } }
        public string StorageAccountName { get { throw null; } set { } }
        public System.Uri TableEndpoint { get { throw null; } set { } }
    }
    public partial class NamedPartitionSchemeDescription : Azure.ResourceManager.ServiceFabric.Models.PartitionSchemeDescription
    {
        public NamedPartitionSchemeDescription(int count, System.Collections.Generic.IEnumerable<string> names) { }
        public int Count { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Names { get { throw null; } }
    }
    public abstract partial class PartitionSchemeDescription
    {
        protected PartitionSchemeDescription() { }
    }
    public partial class ServiceCorrelationDescription
    {
        public ServiceCorrelationDescription(Azure.ResourceManager.ServiceFabric.Models.ServiceCorrelationScheme scheme, string serviceName) { }
        public Azure.ResourceManager.ServiceFabric.Models.ServiceCorrelationScheme Scheme { get { throw null; } set { } }
        public string ServiceName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServiceCorrelationScheme : System.IEquatable<Azure.ResourceManager.ServiceFabric.Models.ServiceCorrelationScheme>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServiceCorrelationScheme(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabric.Models.ServiceCorrelationScheme Affinity { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabric.Models.ServiceCorrelationScheme AlignedAffinity { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabric.Models.ServiceCorrelationScheme Invalid { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabric.Models.ServiceCorrelationScheme NonAlignedAffinity { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabric.Models.ServiceCorrelationScheme other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabric.Models.ServiceCorrelationScheme left, Azure.ResourceManager.ServiceFabric.Models.ServiceCorrelationScheme right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabric.Models.ServiceCorrelationScheme (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabric.Models.ServiceCorrelationScheme left, Azure.ResourceManager.ServiceFabric.Models.ServiceCorrelationScheme right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ServiceFabricApplicationPatch : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ServiceFabricApplicationPatch(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ETag? ETag { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabric.Models.ApplicationUserAssignedIdentity> ManagedIdentities { get { throw null; } }
        public long? MaximumNodes { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabric.Models.ApplicationMetricDescription> Metrics { get { throw null; } }
        public long? MinimumNodes { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Parameters { get { throw null; } }
        public bool? RemoveApplicationCapacity { get { throw null; } set { } }
        public string TypeVersion { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabric.Models.ApplicationUpgradePolicy UpgradePolicy { get { throw null; } set { } }
    }
    public partial class ServiceFabricClusterPatch
    {
        public ServiceFabricClusterPatch() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabric.Models.ClusterAddOnFeature> AddOnFeatures { get { throw null; } }
        public Azure.ResourceManager.ServiceFabric.Models.ClusterCertificateDescription Certificate { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabric.Models.ClusterServerCertificateCommonNames CertificateCommonNames { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabric.Models.ClusterClientCertificateCommonName> ClientCertificateCommonNames { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabric.Models.ClusterClientCertificateThumbprint> ClientCertificateThumbprints { get { throw null; } }
        public string ClusterCodeVersion { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabric.Models.SettingsSectionDescription> FabricSettings { get { throw null; } }
        public bool? IsEventStoreServiceEnabled { get { throw null; } set { } }
        public bool? IsInfrastructureServiceManagerEnabled { get { throw null; } set { } }
        public bool? IsWaveUpgradePaused { get { throw null; } set { } }
        public long? MaxUnusedVersionsToKeep { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabric.Models.ClusterNodeTypeDescription> NodeTypes { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabric.Models.ClusterNotification> Notifications { get { throw null; } }
        public Azure.ResourceManager.ServiceFabric.Models.ClusterReliabilityLevel? ReliabilityLevel { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabric.Models.ClusterCertificateDescription ReverseProxyCertificate { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabric.Models.SfZonalUpgradeMode? SfZonalUpgradeMode { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public Azure.ResourceManager.ServiceFabric.Models.ClusterUpgradePolicy UpgradeDescription { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabric.Models.ClusterUpgradeMode? UpgradeMode { get { throw null; } set { } }
        public System.DateTimeOffset? UpgradePauseEndOn { get { throw null; } set { } }
        public System.DateTimeOffset? UpgradePauseStartOn { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabric.Models.ClusterUpgradeCadence? UpgradeWave { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabric.Models.VmssZonalUpgradeMode? VmssZonalUpgradeMode { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServiceFabricClusterState : System.IEquatable<Azure.ResourceManager.ServiceFabric.Models.ServiceFabricClusterState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServiceFabricClusterState(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabric.Models.ServiceFabricClusterState AutoScale { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabric.Models.ServiceFabricClusterState BaselineUpgrade { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabric.Models.ServiceFabricClusterState Deploying { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabric.Models.ServiceFabricClusterState EnforcingClusterVersion { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabric.Models.ServiceFabricClusterState Ready { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabric.Models.ServiceFabricClusterState UpdatingInfrastructure { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabric.Models.ServiceFabricClusterState UpdatingUserCertificate { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabric.Models.ServiceFabricClusterState UpdatingUserConfiguration { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabric.Models.ServiceFabricClusterState UpgradeServiceUnreachable { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabric.Models.ServiceFabricClusterState WaitingForNodes { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabric.Models.ServiceFabricClusterState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabric.Models.ServiceFabricClusterState left, Azure.ResourceManager.ServiceFabric.Models.ServiceFabricClusterState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabric.Models.ServiceFabricClusterState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabric.Models.ServiceFabricClusterState left, Azure.ResourceManager.ServiceFabric.Models.ServiceFabricClusterState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServiceFabricProvisioningState : System.IEquatable<Azure.ResourceManager.ServiceFabric.Models.ServiceFabricProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServiceFabricProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabric.Models.ServiceFabricProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabric.Models.ServiceFabricProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabric.Models.ServiceFabricProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabric.Models.ServiceFabricProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabric.Models.ServiceFabricProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabric.Models.ServiceFabricProvisioningState left, Azure.ResourceManager.ServiceFabric.Models.ServiceFabricProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabric.Models.ServiceFabricProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabric.Models.ServiceFabricProvisioningState left, Azure.ResourceManager.ServiceFabric.Models.ServiceFabricProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ServiceFabricServicePatch : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ServiceFabricServicePatch(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabric.Models.ServiceCorrelationDescription> CorrelationScheme { get { throw null; } }
        public Azure.ResourceManager.ServiceFabric.Models.ApplicationMoveCost? DefaultMoveCost { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } }
        public string PlacementConstraints { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabric.Models.ServiceLoadMetricDescription> ServiceLoadMetrics { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabric.Models.ServicePlacementPolicyDescription> ServicePlacementPolicies { get { throw null; } }
    }
    public partial class ServiceLoadMetricDescription
    {
        public ServiceLoadMetricDescription(string name) { }
        public int? DefaultLoad { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public int? PrimaryDefaultLoad { get { throw null; } set { } }
        public int? SecondaryDefaultLoad { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabric.Models.ServiceLoadMetricWeight? Weight { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServiceLoadMetricWeight : System.IEquatable<Azure.ResourceManager.ServiceFabric.Models.ServiceLoadMetricWeight>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServiceLoadMetricWeight(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabric.Models.ServiceLoadMetricWeight High { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabric.Models.ServiceLoadMetricWeight Low { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabric.Models.ServiceLoadMetricWeight Medium { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabric.Models.ServiceLoadMetricWeight Zero { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabric.Models.ServiceLoadMetricWeight other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabric.Models.ServiceLoadMetricWeight left, Azure.ResourceManager.ServiceFabric.Models.ServiceLoadMetricWeight right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabric.Models.ServiceLoadMetricWeight (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabric.Models.ServiceLoadMetricWeight left, Azure.ResourceManager.ServiceFabric.Models.ServiceLoadMetricWeight right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class ServicePlacementPolicyDescription
    {
        protected ServicePlacementPolicyDescription() { }
    }
    public partial class ServiceTypeDeltaHealthPolicy
    {
        public ServiceTypeDeltaHealthPolicy() { }
        public int? MaxPercentDeltaUnhealthyServices { get { throw null; } set { } }
    }
    public partial class ServiceTypeHealthPolicy
    {
        public ServiceTypeHealthPolicy() { }
        public int? MaxPercentUnhealthyServices { get { throw null; } set { } }
    }
    public partial class SettingsParameterDescription
    {
        public SettingsParameterDescription(string name, string value) { }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class SettingsSectionDescription
    {
        public SettingsSectionDescription(string name, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabric.Models.SettingsParameterDescription> parameters) { }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabric.Models.SettingsParameterDescription> Parameters { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SfZonalUpgradeMode : System.IEquatable<Azure.ResourceManager.ServiceFabric.Models.SfZonalUpgradeMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SfZonalUpgradeMode(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabric.Models.SfZonalUpgradeMode Hierarchical { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabric.Models.SfZonalUpgradeMode Parallel { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabric.Models.SfZonalUpgradeMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabric.Models.SfZonalUpgradeMode left, Azure.ResourceManager.ServiceFabric.Models.SfZonalUpgradeMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabric.Models.SfZonalUpgradeMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabric.Models.SfZonalUpgradeMode left, Azure.ResourceManager.ServiceFabric.Models.SfZonalUpgradeMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SingletonPartitionSchemeDescription : Azure.ResourceManager.ServiceFabric.Models.PartitionSchemeDescription
    {
        public SingletonPartitionSchemeDescription() { }
    }
    public partial class UniformInt64RangePartitionSchemeDescription : Azure.ResourceManager.ServiceFabric.Models.PartitionSchemeDescription
    {
        public UniformInt64RangePartitionSchemeDescription(int count, string lowKey, string highKey) { }
        public int Count { get { throw null; } set { } }
        public string HighKey { get { throw null; } set { } }
        public string LowKey { get { throw null; } set { } }
    }
    public partial class UpgradableVersionPathResult
    {
        internal UpgradableVersionPathResult() { }
        public System.Collections.Generic.IReadOnlyList<string> SupportedPath { get { throw null; } }
    }
    public partial class UpgradableVersionsDescription
    {
        public UpgradableVersionsDescription(string targetVersion) { }
        public string TargetVersion { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VmssZonalUpgradeMode : System.IEquatable<Azure.ResourceManager.ServiceFabric.Models.VmssZonalUpgradeMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VmssZonalUpgradeMode(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabric.Models.VmssZonalUpgradeMode Hierarchical { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabric.Models.VmssZonalUpgradeMode Parallel { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabric.Models.VmssZonalUpgradeMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabric.Models.VmssZonalUpgradeMode left, Azure.ResourceManager.ServiceFabric.Models.VmssZonalUpgradeMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabric.Models.VmssZonalUpgradeMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabric.Models.VmssZonalUpgradeMode left, Azure.ResourceManager.ServiceFabric.Models.VmssZonalUpgradeMode right) { throw null; }
        public override string ToString() { throw null; }
    }
}
