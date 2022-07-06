namespace Azure.ResourceManager.ServiceFabric
{
    public partial class ApplicationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ApplicationResource() { }
        public virtual Azure.ResourceManager.ServiceFabric.ApplicationResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabric.ApplicationResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabric.ApplicationResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string applicationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabric.ApplicationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabric.ApplicationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabric.ServiceResource> GetServiceResource(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabric.ServiceResource>> GetServiceResourceAsync(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ServiceFabric.ServiceResourceCollection GetServiceResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabric.ApplicationResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabric.ApplicationResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabric.ApplicationResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabric.ApplicationResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceFabric.ApplicationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ServiceFabric.Models.ApplicationResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceFabric.ApplicationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ServiceFabric.Models.ApplicationResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApplicationResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceFabric.ApplicationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabric.ApplicationResource>, System.Collections.IEnumerable
    {
        protected ApplicationResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceFabric.ApplicationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string applicationName, Azure.ResourceManager.ServiceFabric.ApplicationResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceFabric.ApplicationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string applicationName, Azure.ResourceManager.ServiceFabric.ApplicationResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabric.ApplicationResource> Get(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ServiceFabric.ApplicationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ServiceFabric.ApplicationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabric.ApplicationResource>> GetAsync(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ServiceFabric.ApplicationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceFabric.ApplicationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ServiceFabric.ApplicationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabric.ApplicationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ApplicationResourceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ApplicationResourceData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
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
    public partial class ApplicationTypeResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ApplicationTypeResource() { }
        public virtual Azure.ResourceManager.ServiceFabric.ApplicationTypeResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabric.ApplicationTypeResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabric.ApplicationTypeResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string applicationTypeName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabric.ApplicationTypeResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabric.ApplicationTypeVersionResource> GetApplicationTypeVersionResource(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabric.ApplicationTypeVersionResource>> GetApplicationTypeVersionResourceAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ServiceFabric.ApplicationTypeVersionResourceCollection GetApplicationTypeVersionResources() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabric.ApplicationTypeResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabric.ApplicationTypeResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabric.ApplicationTypeResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabric.ApplicationTypeResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabric.ApplicationTypeResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceFabric.ApplicationTypeResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ServiceFabric.ApplicationTypeResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceFabric.ApplicationTypeResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ServiceFabric.ApplicationTypeResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApplicationTypeResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceFabric.ApplicationTypeResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabric.ApplicationTypeResource>, System.Collections.IEnumerable
    {
        protected ApplicationTypeResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceFabric.ApplicationTypeResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string applicationTypeName, Azure.ResourceManager.ServiceFabric.ApplicationTypeResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceFabric.ApplicationTypeResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string applicationTypeName, Azure.ResourceManager.ServiceFabric.ApplicationTypeResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string applicationTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string applicationTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabric.ApplicationTypeResource> Get(string applicationTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ServiceFabric.ApplicationTypeResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ServiceFabric.ApplicationTypeResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabric.ApplicationTypeResource>> GetAsync(string applicationTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ServiceFabric.ApplicationTypeResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceFabric.ApplicationTypeResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ServiceFabric.ApplicationTypeResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabric.ApplicationTypeResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ApplicationTypeResourceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ApplicationTypeResourceData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ETag? ETag { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
    }
    public partial class ApplicationTypeVersionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ApplicationTypeVersionResource() { }
        public virtual Azure.ResourceManager.ServiceFabric.ApplicationTypeVersionResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabric.ApplicationTypeVersionResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabric.ApplicationTypeVersionResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string applicationTypeName, string version) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabric.ApplicationTypeVersionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabric.ApplicationTypeVersionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabric.ApplicationTypeVersionResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabric.ApplicationTypeVersionResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabric.ApplicationTypeVersionResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabric.ApplicationTypeVersionResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceFabric.ApplicationTypeVersionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ServiceFabric.ApplicationTypeVersionResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceFabric.ApplicationTypeVersionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ServiceFabric.ApplicationTypeVersionResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApplicationTypeVersionResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceFabric.ApplicationTypeVersionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabric.ApplicationTypeVersionResource>, System.Collections.IEnumerable
    {
        protected ApplicationTypeVersionResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceFabric.ApplicationTypeVersionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string version, Azure.ResourceManager.ServiceFabric.ApplicationTypeVersionResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceFabric.ApplicationTypeVersionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string version, Azure.ResourceManager.ServiceFabric.ApplicationTypeVersionResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabric.ApplicationTypeVersionResource> Get(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ServiceFabric.ApplicationTypeVersionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ServiceFabric.ApplicationTypeVersionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabric.ApplicationTypeVersionResource>> GetAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ServiceFabric.ApplicationTypeVersionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceFabric.ApplicationTypeVersionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ServiceFabric.ApplicationTypeVersionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabric.ApplicationTypeVersionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ApplicationTypeVersionResourceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ApplicationTypeVersionResourceData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.Uri AppPackageUri { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> DefaultParameterList { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
    }
    public partial class ClusterCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceFabric.ClusterResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabric.ClusterResource>, System.Collections.IEnumerable
    {
        protected ClusterCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceFabric.ClusterResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string clusterName, Azure.ResourceManager.ServiceFabric.ClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceFabric.ClusterResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string clusterName, Azure.ResourceManager.ServiceFabric.ClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabric.ClusterResource> Get(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ServiceFabric.ClusterResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ServiceFabric.ClusterResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabric.ClusterResource>> GetAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ServiceFabric.ClusterResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceFabric.ClusterResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ServiceFabric.ClusterResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabric.ClusterResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ClusterData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ClusterData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabric.Models.AddOnFeature> AddOnFeatures { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ServiceFabric.Models.ClusterVersionDetails> AvailableClusterVersions { get { throw null; } }
        public Azure.ResourceManager.ServiceFabric.Models.AzureActiveDirectory AzureActiveDirectory { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabric.Models.CertificateDescription Certificate { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabric.Models.ServerCertificateCommonNames CertificateCommonNames { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabric.Models.ClientCertificateCommonName> ClientCertificateCommonNames { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabric.Models.ClientCertificateThumbprint> ClientCertificateThumbprints { get { throw null; } }
        public string ClusterCodeVersion { get { throw null; } set { } }
        public string ClusterEndpoint { get { throw null; } }
        public string ClusterId { get { throw null; } }
        public Azure.ResourceManager.ServiceFabric.Models.ClusterState? ClusterState { get { throw null; } }
        public Azure.ResourceManager.ServiceFabric.Models.DiagnosticsStorageAccountConfig DiagnosticsStorageAccountConfig { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } }
        public bool? EventStoreServiceEnabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabric.Models.SettingsSectionDescription> FabricSettings { get { throw null; } }
        public bool? InfrastructureServiceManager { get { throw null; } set { } }
        public string ManagementEndpoint { get { throw null; } set { } }
        public long? MaxUnusedVersionsToKeep { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabric.Models.NodeTypeDescription> NodeTypes { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabric.Models.Notification> Notifications { get { throw null; } }
        public Azure.ResourceManager.ServiceFabric.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ServiceFabric.Models.ReliabilityLevel? ReliabilityLevel { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabric.Models.CertificateDescription ReverseProxyCertificate { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabric.Models.ServerCertificateCommonNames ReverseProxyCertificateCommonNames { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabric.Models.SfZonalUpgradeMode? SfZonalUpgradeMode { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabric.Models.ClusterUpgradePolicy UpgradeDescription { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabric.Models.UpgradeMode? UpgradeMode { get { throw null; } set { } }
        public System.DateTimeOffset? UpgradePauseEndTimestampUtc { get { throw null; } set { } }
        public System.DateTimeOffset? UpgradePauseStartTimestampUtc { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabric.Models.ClusterUpgradeCadence? UpgradeWave { get { throw null; } set { } }
        public string VmImage { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabric.Models.VmssZonalUpgradeMode? VmssZonalUpgradeMode { get { throw null; } set { } }
        public bool? WaveUpgradePaused { get { throw null; } set { } }
    }
    public partial class ClusterResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ClusterResource() { }
        public virtual Azure.ResourceManager.ServiceFabric.ClusterData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabric.ClusterResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabric.ClusterResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabric.ClusterResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabric.ApplicationResource> GetApplicationResource(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabric.ApplicationResource>> GetApplicationResourceAsync(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ServiceFabric.ApplicationResourceCollection GetApplicationResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabric.ApplicationTypeResource> GetApplicationTypeResource(string applicationTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabric.ApplicationTypeResource>> GetApplicationTypeResourceAsync(string applicationTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ServiceFabric.ApplicationTypeResourceCollection GetApplicationTypeResources() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabric.ClusterResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabric.Models.UpgradableVersionPathResult> GetUpgradableVersions(Azure.ResourceManager.ServiceFabric.Models.UpgradableVersionsDescription versionsDescription = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabric.Models.UpgradableVersionPathResult>> GetUpgradableVersionsAsync(Azure.ResourceManager.ServiceFabric.Models.UpgradableVersionsDescription versionsDescription = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabric.ClusterResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabric.ClusterResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabric.ClusterResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabric.ClusterResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceFabric.ClusterResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ServiceFabric.Models.ClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceFabric.ClusterResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ServiceFabric.Models.ClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class ServiceFabricExtensions
    {
        public static Azure.ResourceManager.ServiceFabric.ApplicationResource GetApplicationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ServiceFabric.ApplicationTypeResource GetApplicationTypeResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ServiceFabric.ApplicationTypeVersionResource GetApplicationTypeVersionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ServiceFabric.ClusterResource> GetCluster(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabric.ClusterResource>> GetClusterAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ServiceFabric.ClusterResource GetClusterResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ServiceFabric.ClusterCollection GetClusters(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ServiceFabric.ClusterResource> GetClusters(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ServiceFabric.ClusterResource> GetClustersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ServiceFabric.Models.ClusterCodeVersionsResult> GetClusterVersions(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string clusterVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ServiceFabric.Models.ClusterCodeVersionsResult> GetClusterVersions(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ServiceFabric.Models.ClusterCodeVersionsResult> GetClusterVersionsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string clusterVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ServiceFabric.Models.ClusterCodeVersionsResult> GetClusterVersionsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ServiceFabric.Models.ClusterCodeVersionsResult> GetClusterVersionsByEnvironment(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.ServiceFabric.Models.ClusterVersionsEnvironment environment, string clusterVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ServiceFabric.Models.ClusterCodeVersionsResult> GetClusterVersionsByEnvironment(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.ServiceFabric.Models.ClusterVersionsEnvironment environment, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ServiceFabric.Models.ClusterCodeVersionsResult> GetClusterVersionsByEnvironmentAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.ServiceFabric.Models.ClusterVersionsEnvironment environment, string clusterVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ServiceFabric.Models.ClusterCodeVersionsResult> GetClusterVersionsByEnvironmentAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.ServiceFabric.Models.ClusterVersionsEnvironment environment, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ServiceFabric.ServiceResource GetServiceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class ServiceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServiceResource() { }
        public virtual Azure.ResourceManager.ServiceFabric.ServiceResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabric.ServiceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabric.ServiceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string applicationName, string serviceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabric.ServiceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabric.ServiceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabric.ServiceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabric.ServiceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabric.ServiceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabric.ServiceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceFabric.ServiceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ServiceFabric.Models.ServiceResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceFabric.ServiceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ServiceFabric.Models.ServiceResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServiceResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceFabric.ServiceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabric.ServiceResource>, System.Collections.IEnumerable
    {
        protected ServiceResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceFabric.ServiceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string serviceName, Azure.ResourceManager.ServiceFabric.ServiceResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceFabric.ServiceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string serviceName, Azure.ResourceManager.ServiceFabric.ServiceResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabric.ServiceResource> Get(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ServiceFabric.ServiceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ServiceFabric.ServiceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabric.ServiceResource>> GetAsync(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ServiceFabric.ServiceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceFabric.ServiceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ServiceFabric.ServiceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabric.ServiceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServiceResourceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ServiceResourceData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabric.Models.ServiceCorrelationDescription> CorrelationScheme { get { throw null; } }
        public Azure.ResourceManager.ServiceFabric.Models.MoveCost? DefaultMoveCost { get { throw null; } set { } }
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
}
namespace Azure.ResourceManager.ServiceFabric.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AddOnFeature : System.IEquatable<Azure.ResourceManager.ServiceFabric.Models.AddOnFeature>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AddOnFeature(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabric.Models.AddOnFeature BackupRestoreService { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabric.Models.AddOnFeature DnsService { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabric.Models.AddOnFeature RepairManager { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabric.Models.AddOnFeature ResourceMonitorService { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabric.Models.AddOnFeature other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabric.Models.AddOnFeature left, Azure.ResourceManager.ServiceFabric.Models.AddOnFeature right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabric.Models.AddOnFeature (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabric.Models.AddOnFeature left, Azure.ResourceManager.ServiceFabric.Models.AddOnFeature right) { throw null; }
        public override string ToString() { throw null; }
    }
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
    public partial class ApplicationResourcePatch : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ApplicationResourcePatch(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
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
    public partial class ApplicationUpgradePolicy
    {
        public ApplicationUpgradePolicy() { }
        public Azure.ResourceManager.ServiceFabric.Models.ArmApplicationHealthPolicy ApplicationHealthPolicy { get { throw null; } set { } }
        public bool? ForceRestart { get { throw null; } set { } }
        public bool? RecreateApplication { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabric.Models.ArmRollingUpgradeMonitoringPolicy RollingUpgradeMonitoringPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabric.Models.RollingUpgradeMode? UpgradeMode { get { throw null; } set { } }
        public string UpgradeReplicaSetCheckTimeout { get { throw null; } set { } }
    }
    public partial class ApplicationUserAssignedIdentity
    {
        public ApplicationUserAssignedIdentity(string name, string principalId) { }
        public string Name { get { throw null; } set { } }
        public string PrincipalId { get { throw null; } set { } }
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
        public string HealthCheckRetryTimeout { get { throw null; } set { } }
        public System.TimeSpan? HealthCheckStableDuration { get { throw null; } set { } }
        public System.TimeSpan? HealthCheckWaitDuration { get { throw null; } set { } }
        public string UpgradeDomainTimeout { get { throw null; } set { } }
        public string UpgradeTimeout { get { throw null; } set { } }
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
    public partial class AzureActiveDirectory
    {
        public AzureActiveDirectory() { }
        public string ClientApplication { get { throw null; } set { } }
        public string ClusterApplication { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
    }
    public partial class CertificateDescription
    {
        public CertificateDescription(string thumbprint) { }
        public string Thumbprint { get { throw null; } set { } }
        public string ThumbprintSecondary { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabric.Models.StoreName? X509StoreName { get { throw null; } set { } }
    }
    public partial class ClientCertificateCommonName
    {
        public ClientCertificateCommonName(bool isAdmin, string certificateCommonName, string certificateIssuerThumbprint) { }
        public string CertificateCommonName { get { throw null; } set { } }
        public string CertificateIssuerThumbprint { get { throw null; } set { } }
        public bool IsAdmin { get { throw null; } set { } }
    }
    public partial class ClientCertificateThumbprint
    {
        public ClientCertificateThumbprint(bool isAdmin, string certificateThumbprint) { }
        public string CertificateThumbprint { get { throw null; } set { } }
        public bool IsAdmin { get { throw null; } set { } }
    }
    public partial class ClusterCodeVersionsResult : Azure.ResourceManager.Models.ResourceData
    {
        internal ClusterCodeVersionsResult() { }
        public string CodeVersion { get { throw null; } }
        public Azure.ResourceManager.ServiceFabric.Models.ClusterEnvironment? Environment { get { throw null; } }
        public string SupportExpiryUtc { get { throw null; } }
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
    public partial class ClusterPatch
    {
        public ClusterPatch() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabric.Models.AddOnFeature> AddOnFeatures { get { throw null; } }
        public Azure.ResourceManager.ServiceFabric.Models.CertificateDescription Certificate { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabric.Models.ServerCertificateCommonNames CertificateCommonNames { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabric.Models.ClientCertificateCommonName> ClientCertificateCommonNames { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabric.Models.ClientCertificateThumbprint> ClientCertificateThumbprints { get { throw null; } }
        public string ClusterCodeVersion { get { throw null; } set { } }
        public bool? EventStoreServiceEnabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabric.Models.SettingsSectionDescription> FabricSettings { get { throw null; } }
        public bool? InfrastructureServiceManager { get { throw null; } set { } }
        public long? MaxUnusedVersionsToKeep { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabric.Models.NodeTypeDescription> NodeTypes { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabric.Models.Notification> Notifications { get { throw null; } }
        public Azure.ResourceManager.ServiceFabric.Models.ReliabilityLevel? ReliabilityLevel { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabric.Models.CertificateDescription ReverseProxyCertificate { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabric.Models.SfZonalUpgradeMode? SfZonalUpgradeMode { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public Azure.ResourceManager.ServiceFabric.Models.ClusterUpgradePolicy UpgradeDescription { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabric.Models.UpgradeMode? UpgradeMode { get { throw null; } set { } }
        public System.DateTimeOffset? UpgradePauseEndTimestampUtc { get { throw null; } set { } }
        public System.DateTimeOffset? UpgradePauseStartTimestampUtc { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabric.Models.ClusterUpgradeCadence? UpgradeWave { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabric.Models.VmssZonalUpgradeMode? VmssZonalUpgradeMode { get { throw null; } set { } }
        public bool? WaveUpgradePaused { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClusterState : System.IEquatable<Azure.ResourceManager.ServiceFabric.Models.ClusterState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClusterState(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabric.Models.ClusterState AutoScale { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabric.Models.ClusterState BaselineUpgrade { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabric.Models.ClusterState Deploying { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabric.Models.ClusterState EnforcingClusterVersion { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabric.Models.ClusterState Ready { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabric.Models.ClusterState UpdatingInfrastructure { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabric.Models.ClusterState UpdatingUserCertificate { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabric.Models.ClusterState UpdatingUserConfiguration { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabric.Models.ClusterState UpgradeServiceUnreachable { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabric.Models.ClusterState WaitingForNodes { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabric.Models.ClusterState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabric.Models.ClusterState left, Azure.ResourceManager.ServiceFabric.Models.ClusterState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabric.Models.ClusterState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabric.Models.ClusterState left, Azure.ResourceManager.ServiceFabric.Models.ClusterState right) { throw null; }
        public override string ToString() { throw null; }
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
    public partial class ClusterUpgradePolicy
    {
        public ClusterUpgradePolicy(string upgradeReplicaSetCheckTimeout, System.TimeSpan healthCheckWaitDuration, System.TimeSpan healthCheckStableDuration, string healthCheckRetryTimeout, string upgradeTimeout, string upgradeDomainTimeout, Azure.ResourceManager.ServiceFabric.Models.ClusterHealthPolicy healthPolicy) { }
        public Azure.ResourceManager.ServiceFabric.Models.ClusterUpgradeDeltaHealthPolicy DeltaHealthPolicy { get { throw null; } set { } }
        public bool? ForceRestart { get { throw null; } set { } }
        public string HealthCheckRetryTimeout { get { throw null; } set { } }
        public System.TimeSpan HealthCheckStableDuration { get { throw null; } set { } }
        public System.TimeSpan HealthCheckWaitDuration { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabric.Models.ClusterHealthPolicy HealthPolicy { get { throw null; } set { } }
        public string UpgradeDomainTimeout { get { throw null; } set { } }
        public string UpgradeReplicaSetCheckTimeout { get { throw null; } set { } }
        public string UpgradeTimeout { get { throw null; } set { } }
    }
    public partial class ClusterVersionDetails
    {
        internal ClusterVersionDetails() { }
        public string CodeVersion { get { throw null; } }
        public Azure.ResourceManager.ServiceFabric.Models.ClusterEnvironment? Environment { get { throw null; } }
        public string SupportExpiryUtc { get { throw null; } }
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
        public DiagnosticsStorageAccountConfig(string storageAccountName, string protectedAccountKeyName, string blobEndpoint, string queueEndpoint, string tableEndpoint) { }
        public string BlobEndpoint { get { throw null; } set { } }
        public string ProtectedAccountKeyName { get { throw null; } set { } }
        public string ProtectedAccountKeyName2 { get { throw null; } set { } }
        public string QueueEndpoint { get { throw null; } set { } }
        public string StorageAccountName { get { throw null; } set { } }
        public string TableEndpoint { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DurabilityLevel : System.IEquatable<Azure.ResourceManager.ServiceFabric.Models.DurabilityLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DurabilityLevel(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabric.Models.DurabilityLevel Bronze { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabric.Models.DurabilityLevel Gold { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabric.Models.DurabilityLevel Silver { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabric.Models.DurabilityLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabric.Models.DurabilityLevel left, Azure.ResourceManager.ServiceFabric.Models.DurabilityLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabric.Models.DurabilityLevel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabric.Models.DurabilityLevel left, Azure.ResourceManager.ServiceFabric.Models.DurabilityLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EndpointRangeDescription
    {
        public EndpointRangeDescription(int startPort, int endPort) { }
        public int EndPort { get { throw null; } set { } }
        public int StartPort { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MoveCost : System.IEquatable<Azure.ResourceManager.ServiceFabric.Models.MoveCost>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MoveCost(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabric.Models.MoveCost High { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabric.Models.MoveCost Low { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabric.Models.MoveCost Medium { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabric.Models.MoveCost Zero { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabric.Models.MoveCost other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabric.Models.MoveCost left, Azure.ResourceManager.ServiceFabric.Models.MoveCost right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabric.Models.MoveCost (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabric.Models.MoveCost left, Azure.ResourceManager.ServiceFabric.Models.MoveCost right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NamedPartitionSchemeDescription : Azure.ResourceManager.ServiceFabric.Models.PartitionSchemeDescription
    {
        public NamedPartitionSchemeDescription(int count, System.Collections.Generic.IEnumerable<string> names) { }
        public int Count { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Names { get { throw null; } }
    }
    public partial class NodeTypeDescription
    {
        public NodeTypeDescription(string name, int clientConnectionEndpointPort, int httpGatewayEndpointPort, bool isPrimary, int vmInstanceCount) { }
        public Azure.ResourceManager.ServiceFabric.Models.EndpointRangeDescription ApplicationPorts { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Capacities { get { throw null; } }
        public int ClientConnectionEndpointPort { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabric.Models.DurabilityLevel? DurabilityLevel { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabric.Models.EndpointRangeDescription EphemeralPorts { get { throw null; } set { } }
        public int HttpGatewayEndpointPort { get { throw null; } set { } }
        public bool IsPrimary { get { throw null; } set { } }
        public bool? IsStateless { get { throw null; } set { } }
        public bool? MultipleAvailabilityZones { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> PlacementProperties { get { throw null; } }
        public int? ReverseProxyEndpointPort { get { throw null; } set { } }
        public int VmInstanceCount { get { throw null; } set { } }
    }
    public partial class Notification
    {
        public Notification(bool isEnabled, Azure.ResourceManager.ServiceFabric.Models.NotificationCategory notificationCategory, Azure.ResourceManager.ServiceFabric.Models.NotificationLevel notificationLevel, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabric.Models.NotificationTarget> notificationTargets) { }
        public bool IsEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabric.Models.NotificationCategory NotificationCategory { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabric.Models.NotificationLevel NotificationLevel { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabric.Models.NotificationTarget> NotificationTargets { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NotificationCategory : System.IEquatable<Azure.ResourceManager.ServiceFabric.Models.NotificationCategory>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NotificationCategory(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabric.Models.NotificationCategory WaveProgress { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabric.Models.NotificationCategory other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabric.Models.NotificationCategory left, Azure.ResourceManager.ServiceFabric.Models.NotificationCategory right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabric.Models.NotificationCategory (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabric.Models.NotificationCategory left, Azure.ResourceManager.ServiceFabric.Models.NotificationCategory right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NotificationChannel : System.IEquatable<Azure.ResourceManager.ServiceFabric.Models.NotificationChannel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NotificationChannel(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabric.Models.NotificationChannel EmailSubscription { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabric.Models.NotificationChannel EmailUser { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabric.Models.NotificationChannel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabric.Models.NotificationChannel left, Azure.ResourceManager.ServiceFabric.Models.NotificationChannel right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabric.Models.NotificationChannel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabric.Models.NotificationChannel left, Azure.ResourceManager.ServiceFabric.Models.NotificationChannel right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NotificationLevel : System.IEquatable<Azure.ResourceManager.ServiceFabric.Models.NotificationLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NotificationLevel(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabric.Models.NotificationLevel All { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabric.Models.NotificationLevel Critical { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabric.Models.NotificationLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabric.Models.NotificationLevel left, Azure.ResourceManager.ServiceFabric.Models.NotificationLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabric.Models.NotificationLevel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabric.Models.NotificationLevel left, Azure.ResourceManager.ServiceFabric.Models.NotificationLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NotificationTarget
    {
        public NotificationTarget(Azure.ResourceManager.ServiceFabric.Models.NotificationChannel notificationChannel, System.Collections.Generic.IEnumerable<string> receivers) { }
        public Azure.ResourceManager.ServiceFabric.Models.NotificationChannel NotificationChannel { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Receivers { get { throw null; } }
    }
    public partial class PartitionSchemeDescription
    {
        public PartitionSchemeDescription() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.ServiceFabric.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabric.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabric.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabric.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabric.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabric.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabric.Models.ProvisioningState left, Azure.ResourceManager.ServiceFabric.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabric.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabric.Models.ProvisioningState left, Azure.ResourceManager.ServiceFabric.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ReliabilityLevel : System.IEquatable<Azure.ResourceManager.ServiceFabric.Models.ReliabilityLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ReliabilityLevel(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabric.Models.ReliabilityLevel Bronze { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabric.Models.ReliabilityLevel Gold { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabric.Models.ReliabilityLevel None { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabric.Models.ReliabilityLevel Platinum { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabric.Models.ReliabilityLevel Silver { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabric.Models.ReliabilityLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabric.Models.ReliabilityLevel left, Azure.ResourceManager.ServiceFabric.Models.ReliabilityLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabric.Models.ReliabilityLevel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabric.Models.ReliabilityLevel left, Azure.ResourceManager.ServiceFabric.Models.ReliabilityLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RollingUpgradeMode : System.IEquatable<Azure.ResourceManager.ServiceFabric.Models.RollingUpgradeMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RollingUpgradeMode(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabric.Models.RollingUpgradeMode Invalid { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabric.Models.RollingUpgradeMode Monitored { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabric.Models.RollingUpgradeMode UnmonitoredAuto { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabric.Models.RollingUpgradeMode UnmonitoredManual { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabric.Models.RollingUpgradeMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabric.Models.RollingUpgradeMode left, Azure.ResourceManager.ServiceFabric.Models.RollingUpgradeMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabric.Models.RollingUpgradeMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabric.Models.RollingUpgradeMode left, Azure.ResourceManager.ServiceFabric.Models.RollingUpgradeMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ServerCertificateCommonName
    {
        public ServerCertificateCommonName(string certificateCommonName, string certificateIssuerThumbprint) { }
        public string CertificateCommonName { get { throw null; } set { } }
        public string CertificateIssuerThumbprint { get { throw null; } set { } }
    }
    public partial class ServerCertificateCommonNames
    {
        public ServerCertificateCommonNames() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabric.Models.ServerCertificateCommonName> CommonNames { get { throw null; } }
        public Azure.ResourceManager.ServiceFabric.Models.StoreName? X509StoreName { get { throw null; } set { } }
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
    public partial class ServicePlacementPolicyDescription
    {
        public ServicePlacementPolicyDescription() { }
    }
    public partial class ServiceResourcePatch : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ServiceResourcePatch(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabric.Models.ServiceCorrelationDescription> CorrelationScheme { get { throw null; } }
        public Azure.ResourceManager.ServiceFabric.Models.MoveCost? DefaultMoveCost { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } }
        public string PlacementConstraints { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabric.Models.ServiceLoadMetricDescription> ServiceLoadMetrics { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabric.Models.ServicePlacementPolicyDescription> ServicePlacementPolicies { get { throw null; } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StoreName : System.IEquatable<Azure.ResourceManager.ServiceFabric.Models.StoreName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StoreName(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabric.Models.StoreName AddressBook { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabric.Models.StoreName AuthRoot { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabric.Models.StoreName CertificateAuthority { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabric.Models.StoreName Disallowed { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabric.Models.StoreName My { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabric.Models.StoreName Root { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabric.Models.StoreName TrustedPeople { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabric.Models.StoreName TrustedPublisher { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabric.Models.StoreName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabric.Models.StoreName left, Azure.ResourceManager.ServiceFabric.Models.StoreName right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabric.Models.StoreName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabric.Models.StoreName left, Azure.ResourceManager.ServiceFabric.Models.StoreName right) { throw null; }
        public override string ToString() { throw null; }
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
    public readonly partial struct UpgradeMode : System.IEquatable<Azure.ResourceManager.ServiceFabric.Models.UpgradeMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UpgradeMode(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabric.Models.UpgradeMode Automatic { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabric.Models.UpgradeMode Manual { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabric.Models.UpgradeMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabric.Models.UpgradeMode left, Azure.ResourceManager.ServiceFabric.Models.UpgradeMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabric.Models.UpgradeMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabric.Models.UpgradeMode left, Azure.ResourceManager.ServiceFabric.Models.UpgradeMode right) { throw null; }
        public override string ToString() { throw null; }
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
