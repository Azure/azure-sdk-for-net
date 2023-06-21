namespace Azure.ResourceManager.Sphere
{
    public partial class CatalogCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sphere.CatalogResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sphere.CatalogResource>, System.Collections.IEnumerable
    {
        protected CatalogCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sphere.CatalogResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string catalogName, Azure.ResourceManager.Sphere.CatalogData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sphere.CatalogResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string catalogName, Azure.ResourceManager.Sphere.CatalogData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string catalogName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string catalogName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sphere.CatalogResource> Get(string catalogName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sphere.CatalogResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sphere.CatalogResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sphere.CatalogResource>> GetAsync(string catalogName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sphere.CatalogResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sphere.CatalogResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sphere.CatalogResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sphere.CatalogResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CatalogData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public CatalogData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Sphere.Models.ProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class CatalogResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CatalogResource() { }
        public virtual Azure.ResourceManager.Sphere.CatalogData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Sphere.CatalogResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sphere.CatalogResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sphere.Models.CountDeviceResponse> CountDevices(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sphere.Models.CountDeviceResponse>> CountDevicesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string catalogName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sphere.CatalogResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sphere.CatalogResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sphere.CertificateResource> GetCertificate(string serialNumber, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sphere.CertificateResource>> GetCertificateAsync(string serialNumber, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sphere.CertificateCollection GetCertificates() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sphere.DeploymentResource> GetDeployments(string filter = null, int? top = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sphere.DeploymentResource> GetDeploymentsAsync(string filter = null, int? top = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sphere.DeviceGroupResource> GetDeviceGroups(Azure.ResourceManager.Sphere.Models.ListDeviceGroupsContent content, string filter = null, int? top = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sphere.DeviceGroupResource> GetDeviceGroupsAsync(Azure.ResourceManager.Sphere.Models.ListDeviceGroupsContent content, string filter = null, int? top = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sphere.Models.DeviceInsight> GetDeviceInsights(string filter = null, int? top = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sphere.Models.DeviceInsight> GetDeviceInsightsAsync(string filter = null, int? top = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sphere.DeviceResource> GetDevices(string filter = null, int? top = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sphere.DeviceResource> GetDevicesAsync(string filter = null, int? top = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sphere.ImageResource> GetImage(string imageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sphere.ImageResource>> GetImageAsync(string imageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sphere.ImageCollection GetImages() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sphere.ProductResource> GetProduct(string productName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sphere.ProductResource>> GetProductAsync(string productName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sphere.ProductCollection GetProducts() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sphere.CatalogResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sphere.CatalogResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sphere.CatalogResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sphere.CatalogResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sphere.CatalogResource> Update(Azure.ResourceManager.Sphere.Models.CatalogPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sphere.CatalogResource>> UpdateAsync(Azure.ResourceManager.Sphere.Models.CatalogPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CertificateCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sphere.CertificateResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sphere.CertificateResource>, System.Collections.IEnumerable
    {
        protected CertificateCollection() { }
        public virtual Azure.Response<bool> Exists(string serialNumber, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string serialNumber, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sphere.CertificateResource> Get(string serialNumber, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sphere.CertificateResource> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sphere.CertificateResource> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sphere.CertificateResource>> GetAsync(string serialNumber, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sphere.CertificateResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sphere.CertificateResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sphere.CertificateResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sphere.CertificateResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CertificateData : Azure.ResourceManager.Models.ResourceData
    {
        public CertificateData() { }
        public string Certificate { get { throw null; } }
        public System.DateTimeOffset? ExpiryUtc { get { throw null; } }
        public System.DateTimeOffset? NotBeforeUtc { get { throw null; } }
        public Azure.ResourceManager.Sphere.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Sphere.Models.CertificateStatus? Status { get { throw null; } }
        public string Subject { get { throw null; } }
        public string Thumbprint { get { throw null; } }
    }
    public partial class CertificateResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CertificateResource() { }
        public virtual Azure.ResourceManager.Sphere.CertificateData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string catalogName, string serialNumber) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sphere.CertificateResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sphere.CertificateResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sphere.Models.CertificateChainResponse> RetrieveCertChain(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sphere.Models.CertificateChainResponse>> RetrieveCertChainAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sphere.Models.ProofOfPossessionNonceResponse> RetrieveProofOfPossessionNonce(Azure.ResourceManager.Sphere.Models.ProofOfPossessionNonceContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sphere.Models.ProofOfPossessionNonceResponse>> RetrieveProofOfPossessionNonceAsync(Azure.ResourceManager.Sphere.Models.ProofOfPossessionNonceContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeploymentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sphere.DeploymentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sphere.DeploymentResource>, System.Collections.IEnumerable
    {
        protected DeploymentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sphere.DeploymentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string deploymentName, Azure.ResourceManager.Sphere.DeploymentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sphere.DeploymentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string deploymentName, Azure.ResourceManager.Sphere.DeploymentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sphere.DeploymentResource> Get(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sphere.DeploymentResource> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sphere.DeploymentResource> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sphere.DeploymentResource>> GetAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sphere.DeploymentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sphere.DeploymentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sphere.DeploymentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sphere.DeploymentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DeploymentData : Azure.ResourceManager.Models.ResourceData
    {
        public DeploymentData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Sphere.ImageData> DeployedImages { get { throw null; } }
        public System.DateTimeOffset? DeploymentDateUtc { get { throw null; } }
        public string DeploymentId { get { throw null; } set { } }
        public Azure.ResourceManager.Sphere.Models.ProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class DeploymentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DeploymentResource() { }
        public virtual Azure.ResourceManager.Sphere.DeploymentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string catalogName, string productName, string deviceGroupName, string deploymentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sphere.DeploymentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sphere.DeploymentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sphere.DeploymentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sphere.DeploymentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sphere.DeploymentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sphere.DeploymentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeviceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sphere.DeviceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sphere.DeviceResource>, System.Collections.IEnumerable
    {
        protected DeviceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sphere.DeviceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string deviceName, Azure.ResourceManager.Sphere.DeviceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sphere.DeviceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string deviceName, Azure.ResourceManager.Sphere.DeviceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string deviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string deviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sphere.DeviceResource> Get(string deviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sphere.DeviceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sphere.DeviceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sphere.DeviceResource>> GetAsync(string deviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sphere.DeviceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sphere.DeviceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sphere.DeviceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sphere.DeviceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DeviceData : Azure.ResourceManager.Models.ResourceData
    {
        public DeviceData() { }
        public string ChipSku { get { throw null; } }
        public string DeviceId { get { throw null; } set { } }
        public string LastAvailableOSVersion { get { throw null; } }
        public string LastInstalledOSVersion { get { throw null; } }
        public System.DateTimeOffset? LastOSUpdateUtc { get { throw null; } }
        public System.DateTimeOffset? LastUpdateRequestUtc { get { throw null; } }
        public Azure.ResourceManager.Sphere.Models.ProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class DeviceGroupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sphere.DeviceGroupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sphere.DeviceGroupResource>, System.Collections.IEnumerable
    {
        protected DeviceGroupCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sphere.DeviceGroupResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string deviceGroupName, Azure.ResourceManager.Sphere.DeviceGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sphere.DeviceGroupResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string deviceGroupName, Azure.ResourceManager.Sphere.DeviceGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string deviceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string deviceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sphere.DeviceGroupResource> Get(string deviceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sphere.DeviceGroupResource> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sphere.DeviceGroupResource> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sphere.DeviceGroupResource>> GetAsync(string deviceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sphere.DeviceGroupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sphere.DeviceGroupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sphere.DeviceGroupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sphere.DeviceGroupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DeviceGroupData : Azure.ResourceManager.Models.ResourceData
    {
        public DeviceGroupData() { }
        public Azure.ResourceManager.Sphere.Models.AllowCrashDumpCollection? AllowCrashDumpsCollection { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public bool? HasDeployment { get { throw null; } }
        public Azure.ResourceManager.Sphere.Models.OSFeedType? OSFeedType { get { throw null; } set { } }
        public Azure.ResourceManager.Sphere.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Sphere.Models.RegionalDataBoundary? RegionalDataBoundary { get { throw null; } set { } }
        public Azure.ResourceManager.Sphere.Models.UpdatePolicy? UpdatePolicy { get { throw null; } set { } }
    }
    public partial class DeviceGroupResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DeviceGroupResource() { }
        public virtual Azure.ResourceManager.Sphere.DeviceGroupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation ClaimDevices(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sphere.Models.ClaimDevicesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ClaimDevicesAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sphere.Models.ClaimDevicesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sphere.Models.CountDeviceResponse> CountDevices(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sphere.Models.CountDeviceResponse>> CountDevicesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string catalogName, string productName, string deviceGroupName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sphere.DeviceGroupResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sphere.DeviceGroupResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sphere.DeploymentResource> GetDeployment(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sphere.DeploymentResource>> GetDeploymentAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sphere.DeploymentCollection GetDeployments() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sphere.DeviceResource> GetDevice(string deviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sphere.DeviceResource>> GetDeviceAsync(string deviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sphere.DeviceCollection GetDevices() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sphere.DeviceGroupResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sphere.Models.DeviceGroupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sphere.DeviceGroupResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sphere.Models.DeviceGroupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeviceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DeviceResource() { }
        public virtual Azure.ResourceManager.Sphere.DeviceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string catalogName, string productName, string deviceGroupName, string deviceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sphere.Models.SignedCapabilityImageResponse> GenerateCapabilityImage(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sphere.Models.GenerateCapabilityImageContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sphere.Models.SignedCapabilityImageResponse>> GenerateCapabilityImageAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sphere.Models.GenerateCapabilityImageContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sphere.DeviceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sphere.DeviceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sphere.DeviceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sphere.Models.DevicePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sphere.DeviceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sphere.Models.DevicePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ImageCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sphere.ImageResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sphere.ImageResource>, System.Collections.IEnumerable
    {
        protected ImageCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sphere.ImageResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string imageName, Azure.ResourceManager.Sphere.ImageData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sphere.ImageResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string imageName, Azure.ResourceManager.Sphere.ImageData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string imageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string imageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sphere.ImageResource> Get(string imageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sphere.ImageResource> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sphere.ImageResource> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sphere.ImageResource>> GetAsync(string imageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sphere.ImageResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sphere.ImageResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sphere.ImageResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sphere.ImageResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ImageData : Azure.ResourceManager.Models.ResourceData
    {
        public ImageData() { }
        public string ComponentId { get { throw null; } }
        public string Description { get { throw null; } }
        public string Image { get { throw null; } set { } }
        public string ImageId { get { throw null; } set { } }
        public string ImageName { get { throw null; } }
        public Azure.ResourceManager.Sphere.Models.ImageType? ImageType { get { throw null; } }
        public Azure.ResourceManager.Sphere.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Sphere.Models.RegionalDataBoundary? RegionalDataBoundary { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } }
    }
    public partial class ImageResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ImageResource() { }
        public virtual Azure.ResourceManager.Sphere.ImageData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string catalogName, string imageName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sphere.ImageResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sphere.ImageResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sphere.ImageResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sphere.ImageData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sphere.ImageResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sphere.ImageData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ProductCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sphere.ProductResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sphere.ProductResource>, System.Collections.IEnumerable
    {
        protected ProductCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sphere.ProductResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string productName, Azure.ResourceManager.Sphere.ProductData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sphere.ProductResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string productName, Azure.ResourceManager.Sphere.ProductData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string productName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string productName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sphere.ProductResource> Get(string productName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sphere.ProductResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sphere.ProductResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sphere.ProductResource>> GetAsync(string productName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sphere.ProductResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sphere.ProductResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sphere.ProductResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sphere.ProductResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ProductData : Azure.ResourceManager.Models.ResourceData
    {
        public ProductData() { }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.Sphere.Models.ProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class ProductResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ProductResource() { }
        public virtual Azure.ResourceManager.Sphere.ProductData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Sphere.Models.CountDeviceResponse> CountDevices(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sphere.Models.CountDeviceResponse>> CountDevicesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string catalogName, string productName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sphere.DeviceGroupResource> GenerateDefaultDeviceGroups(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sphere.DeviceGroupResource> GenerateDefaultDeviceGroupsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sphere.ProductResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sphere.ProductResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sphere.DeviceGroupResource> GetDeviceGroup(string deviceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sphere.DeviceGroupResource>> GetDeviceGroupAsync(string deviceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sphere.DeviceGroupCollection GetDeviceGroups() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sphere.ProductResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sphere.Models.ProductPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sphere.ProductResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sphere.Models.ProductPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class SphereExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Sphere.CatalogResource> GetCatalog(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string catalogName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sphere.CatalogResource>> GetCatalogAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string catalogName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Sphere.CatalogResource GetCatalogResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sphere.CatalogCollection GetCatalogs(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Sphere.CatalogResource> GetCatalogs(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Sphere.CatalogResource> GetCatalogsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Sphere.CertificateResource GetCertificateResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sphere.DeploymentResource GetDeploymentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sphere.DeviceGroupResource GetDeviceGroupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sphere.DeviceResource GetDeviceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sphere.ImageResource GetImageResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sphere.ProductResource GetProductResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
}
namespace Azure.ResourceManager.Sphere.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AllowCrashDumpCollection : System.IEquatable<Azure.ResourceManager.Sphere.Models.AllowCrashDumpCollection>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AllowCrashDumpCollection(string value) { throw null; }
        public static Azure.ResourceManager.Sphere.Models.AllowCrashDumpCollection Disabled { get { throw null; } }
        public static Azure.ResourceManager.Sphere.Models.AllowCrashDumpCollection Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sphere.Models.AllowCrashDumpCollection other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sphere.Models.AllowCrashDumpCollection left, Azure.ResourceManager.Sphere.Models.AllowCrashDumpCollection right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sphere.Models.AllowCrashDumpCollection (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sphere.Models.AllowCrashDumpCollection left, Azure.ResourceManager.Sphere.Models.AllowCrashDumpCollection right) { throw null; }
        public override string ToString() { throw null; }
    }
    public static partial class ArmSphereModelFactory
    {
        public static Azure.ResourceManager.Sphere.CatalogData CatalogData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Sphere.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.Sphere.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Sphere.Models.CertificateChainResponse CertificateChainResponse(string certificateChain = null) { throw null; }
        public static Azure.ResourceManager.Sphere.CertificateData CertificateData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string certificate = null, Azure.ResourceManager.Sphere.Models.CertificateStatus? status = default(Azure.ResourceManager.Sphere.Models.CertificateStatus?), string subject = null, string thumbprint = null, System.DateTimeOffset? expiryUtc = default(System.DateTimeOffset?), System.DateTimeOffset? notBeforeUtc = default(System.DateTimeOffset?), Azure.ResourceManager.Sphere.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.Sphere.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Sphere.Models.CertificateProperties CertificateProperties(string certificate = null, Azure.ResourceManager.Sphere.Models.CertificateStatus? status = default(Azure.ResourceManager.Sphere.Models.CertificateStatus?), string subject = null, string thumbprint = null, System.DateTimeOffset? expiryUtc = default(System.DateTimeOffset?), System.DateTimeOffset? notBeforeUtc = default(System.DateTimeOffset?), Azure.ResourceManager.Sphere.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.Sphere.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Sphere.Models.CountDeviceResponse CountDeviceResponse(int value = 0) { throw null; }
        public static Azure.ResourceManager.Sphere.Models.CountElementsResponse CountElementsResponse(int value = 0) { throw null; }
        public static Azure.ResourceManager.Sphere.DeploymentData DeploymentData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string deploymentId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sphere.ImageData> deployedImages = null, System.DateTimeOffset? deploymentDateUtc = default(System.DateTimeOffset?), Azure.ResourceManager.Sphere.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.Sphere.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Sphere.DeviceData DeviceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string deviceId = null, string chipSku = null, string lastAvailableOSVersion = null, string lastInstalledOSVersion = null, System.DateTimeOffset? lastOSUpdateUtc = default(System.DateTimeOffset?), System.DateTimeOffset? lastUpdateRequestUtc = default(System.DateTimeOffset?), Azure.ResourceManager.Sphere.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.Sphere.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Sphere.DeviceGroupData DeviceGroupData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string description = null, Azure.ResourceManager.Sphere.Models.OSFeedType? osFeedType = default(Azure.ResourceManager.Sphere.Models.OSFeedType?), Azure.ResourceManager.Sphere.Models.UpdatePolicy? updatePolicy = default(Azure.ResourceManager.Sphere.Models.UpdatePolicy?), Azure.ResourceManager.Sphere.Models.AllowCrashDumpCollection? allowCrashDumpsCollection = default(Azure.ResourceManager.Sphere.Models.AllowCrashDumpCollection?), Azure.ResourceManager.Sphere.Models.RegionalDataBoundary? regionalDataBoundary = default(Azure.ResourceManager.Sphere.Models.RegionalDataBoundary?), bool? hasDeployment = default(bool?), Azure.ResourceManager.Sphere.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.Sphere.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Sphere.Models.DeviceInsight DeviceInsight(string deviceId = null, string description = null, System.DateTimeOffset startTimestampUtc = default(System.DateTimeOffset), System.DateTimeOffset endTimestampUtc = default(System.DateTimeOffset), string eventCategory = null, string eventClass = null, string eventType = null, int eventCount = 0) { throw null; }
        public static Azure.ResourceManager.Sphere.ImageData ImageData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string image = null, string imageId = null, string imageName = null, Azure.ResourceManager.Sphere.Models.RegionalDataBoundary? regionalDataBoundary = default(Azure.ResourceManager.Sphere.Models.RegionalDataBoundary?), System.Uri uri = null, string description = null, string componentId = null, Azure.ResourceManager.Sphere.Models.ImageType? imageType = default(Azure.ResourceManager.Sphere.Models.ImageType?), Azure.ResourceManager.Sphere.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.Sphere.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Sphere.ProductData ProductData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string description = null, Azure.ResourceManager.Sphere.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.Sphere.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Sphere.Models.ProofOfPossessionNonceResponse ProofOfPossessionNonceResponse(string certificate = null, Azure.ResourceManager.Sphere.Models.CertificateStatus? status = default(Azure.ResourceManager.Sphere.Models.CertificateStatus?), string subject = null, string thumbprint = null, System.DateTimeOffset? expiryUtc = default(System.DateTimeOffset?), System.DateTimeOffset? notBeforeUtc = default(System.DateTimeOffset?), Azure.ResourceManager.Sphere.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.Sphere.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Sphere.Models.SignedCapabilityImageResponse SignedCapabilityImageResponse(string image = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CapabilityType : System.IEquatable<Azure.ResourceManager.Sphere.Models.CapabilityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CapabilityType(string value) { throw null; }
        public static Azure.ResourceManager.Sphere.Models.CapabilityType ApplicationDevelopment { get { throw null; } }
        public static Azure.ResourceManager.Sphere.Models.CapabilityType FieldServicing { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sphere.Models.CapabilityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sphere.Models.CapabilityType left, Azure.ResourceManager.Sphere.Models.CapabilityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sphere.Models.CapabilityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sphere.Models.CapabilityType left, Azure.ResourceManager.Sphere.Models.CapabilityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CatalogPatch
    {
        public CatalogPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class CertificateChainResponse
    {
        internal CertificateChainResponse() { }
        public string CertificateChain { get { throw null; } }
    }
    public partial class CertificateProperties
    {
        internal CertificateProperties() { }
        public string Certificate { get { throw null; } }
        public System.DateTimeOffset? ExpiryUtc { get { throw null; } }
        public System.DateTimeOffset? NotBeforeUtc { get { throw null; } }
        public Azure.ResourceManager.Sphere.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Sphere.Models.CertificateStatus? Status { get { throw null; } }
        public string Subject { get { throw null; } }
        public string Thumbprint { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CertificateStatus : System.IEquatable<Azure.ResourceManager.Sphere.Models.CertificateStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CertificateStatus(string value) { throw null; }
        public static Azure.ResourceManager.Sphere.Models.CertificateStatus Active { get { throw null; } }
        public static Azure.ResourceManager.Sphere.Models.CertificateStatus Expired { get { throw null; } }
        public static Azure.ResourceManager.Sphere.Models.CertificateStatus Inactive { get { throw null; } }
        public static Azure.ResourceManager.Sphere.Models.CertificateStatus Revoked { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sphere.Models.CertificateStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sphere.Models.CertificateStatus left, Azure.ResourceManager.Sphere.Models.CertificateStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sphere.Models.CertificateStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sphere.Models.CertificateStatus left, Azure.ResourceManager.Sphere.Models.CertificateStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ClaimDevicesContent
    {
        public ClaimDevicesContent(System.Collections.Generic.IEnumerable<string> deviceIdentifiers) { }
        public System.Collections.Generic.IList<string> DeviceIdentifiers { get { throw null; } }
    }
    public partial class CountDeviceResponse : Azure.ResourceManager.Sphere.Models.CountElementsResponse
    {
        internal CountDeviceResponse() { }
    }
    public partial class CountElementsResponse
    {
        internal CountElementsResponse() { }
        public int Value { get { throw null; } }
    }
    public partial class DeviceGroupPatch
    {
        public DeviceGroupPatch() { }
        public Azure.ResourceManager.Sphere.Models.AllowCrashDumpCollection? AllowCrashDumpsCollection { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.Sphere.Models.OSFeedType? OSFeedType { get { throw null; } set { } }
        public Azure.ResourceManager.Sphere.Models.RegionalDataBoundary? RegionalDataBoundary { get { throw null; } set { } }
        public Azure.ResourceManager.Sphere.Models.UpdatePolicy? UpdatePolicy { get { throw null; } set { } }
    }
    public partial class DeviceInsight
    {
        internal DeviceInsight() { }
        public string Description { get { throw null; } }
        public string DeviceId { get { throw null; } }
        public System.DateTimeOffset EndTimestampUtc { get { throw null; } }
        public string EventCategory { get { throw null; } }
        public string EventClass { get { throw null; } }
        public int EventCount { get { throw null; } }
        public string EventType { get { throw null; } }
        public System.DateTimeOffset StartTimestampUtc { get { throw null; } }
    }
    public partial class DevicePatch
    {
        public DevicePatch() { }
        public string DeviceGroupId { get { throw null; } set { } }
    }
    public partial class GenerateCapabilityImageContent
    {
        public GenerateCapabilityImageContent(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sphere.Models.CapabilityType> capabilities) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Sphere.Models.CapabilityType> Capabilities { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ImageType : System.IEquatable<Azure.ResourceManager.Sphere.Models.ImageType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ImageType(string value) { throw null; }
        public static Azure.ResourceManager.Sphere.Models.ImageType Applications { get { throw null; } }
        public static Azure.ResourceManager.Sphere.Models.ImageType BaseSystemUpdateManifest { get { throw null; } }
        public static Azure.ResourceManager.Sphere.Models.ImageType BootManifest { get { throw null; } }
        public static Azure.ResourceManager.Sphere.Models.ImageType CustomerBoardConfig { get { throw null; } }
        public static Azure.ResourceManager.Sphere.Models.ImageType CustomerUpdateManifest { get { throw null; } }
        public static Azure.ResourceManager.Sphere.Models.ImageType FirmwareUpdateManifest { get { throw null; } }
        public static Azure.ResourceManager.Sphere.Models.ImageType FwConfig { get { throw null; } }
        public static Azure.ResourceManager.Sphere.Models.ImageType InvalidImageType { get { throw null; } }
        public static Azure.ResourceManager.Sphere.Models.ImageType ManifestSet { get { throw null; } }
        public static Azure.ResourceManager.Sphere.Models.ImageType NormalWorldDtb { get { throw null; } }
        public static Azure.ResourceManager.Sphere.Models.ImageType NormalWorldKernel { get { throw null; } }
        public static Azure.ResourceManager.Sphere.Models.ImageType NormalWorldLoader { get { throw null; } }
        public static Azure.ResourceManager.Sphere.Models.ImageType Nwfs { get { throw null; } }
        public static Azure.ResourceManager.Sphere.Models.ImageType OneBl { get { throw null; } }
        public static Azure.ResourceManager.Sphere.Models.ImageType Other { get { throw null; } }
        public static Azure.ResourceManager.Sphere.Models.ImageType PlutonRuntime { get { throw null; } }
        public static Azure.ResourceManager.Sphere.Models.ImageType Policy { get { throw null; } }
        public static Azure.ResourceManager.Sphere.Models.ImageType RecoveryManifest { get { throw null; } }
        public static Azure.ResourceManager.Sphere.Models.ImageType RootFs { get { throw null; } }
        public static Azure.ResourceManager.Sphere.Models.ImageType SecurityMonitor { get { throw null; } }
        public static Azure.ResourceManager.Sphere.Models.ImageType Services { get { throw null; } }
        public static Azure.ResourceManager.Sphere.Models.ImageType TrustedKeystore { get { throw null; } }
        public static Azure.ResourceManager.Sphere.Models.ImageType UpdateCertStore { get { throw null; } }
        public static Azure.ResourceManager.Sphere.Models.ImageType WifiFirmware { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sphere.Models.ImageType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sphere.Models.ImageType left, Azure.ResourceManager.Sphere.Models.ImageType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sphere.Models.ImageType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sphere.Models.ImageType left, Azure.ResourceManager.Sphere.Models.ImageType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ListDeviceGroupsContent
    {
        public ListDeviceGroupsContent() { }
        public string DeviceGroupName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OSFeedType : System.IEquatable<Azure.ResourceManager.Sphere.Models.OSFeedType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OSFeedType(string value) { throw null; }
        public static Azure.ResourceManager.Sphere.Models.OSFeedType Retail { get { throw null; } }
        public static Azure.ResourceManager.Sphere.Models.OSFeedType RetailEval { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sphere.Models.OSFeedType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sphere.Models.OSFeedType left, Azure.ResourceManager.Sphere.Models.OSFeedType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sphere.Models.OSFeedType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sphere.Models.OSFeedType left, Azure.ResourceManager.Sphere.Models.OSFeedType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ProductPatch
    {
        public ProductPatch() { }
        public string Description { get { throw null; } set { } }
    }
    public partial class ProofOfPossessionNonceContent
    {
        public ProofOfPossessionNonceContent(string proofOfPossessionNonce) { }
        public string ProofOfPossessionNonce { get { throw null; } }
    }
    public partial class ProofOfPossessionNonceResponse : Azure.ResourceManager.Sphere.Models.CertificateProperties
    {
        internal ProofOfPossessionNonceResponse() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.Sphere.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Sphere.Models.ProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.Sphere.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Sphere.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Sphere.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Sphere.Models.ProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.Sphere.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Sphere.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sphere.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sphere.Models.ProvisioningState left, Azure.ResourceManager.Sphere.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sphere.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sphere.Models.ProvisioningState left, Azure.ResourceManager.Sphere.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RegionalDataBoundary : System.IEquatable<Azure.ResourceManager.Sphere.Models.RegionalDataBoundary>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RegionalDataBoundary(string value) { throw null; }
        public static Azure.ResourceManager.Sphere.Models.RegionalDataBoundary EU { get { throw null; } }
        public static Azure.ResourceManager.Sphere.Models.RegionalDataBoundary None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sphere.Models.RegionalDataBoundary other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sphere.Models.RegionalDataBoundary left, Azure.ResourceManager.Sphere.Models.RegionalDataBoundary right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sphere.Models.RegionalDataBoundary (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sphere.Models.RegionalDataBoundary left, Azure.ResourceManager.Sphere.Models.RegionalDataBoundary right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SignedCapabilityImageResponse
    {
        internal SignedCapabilityImageResponse() { }
        public string Image { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UpdatePolicy : System.IEquatable<Azure.ResourceManager.Sphere.Models.UpdatePolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UpdatePolicy(string value) { throw null; }
        public static Azure.ResourceManager.Sphere.Models.UpdatePolicy No3RdPartyAppUpdates { get { throw null; } }
        public static Azure.ResourceManager.Sphere.Models.UpdatePolicy UpdateAll { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sphere.Models.UpdatePolicy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sphere.Models.UpdatePolicy left, Azure.ResourceManager.Sphere.Models.UpdatePolicy right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sphere.Models.UpdatePolicy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sphere.Models.UpdatePolicy left, Azure.ResourceManager.Sphere.Models.UpdatePolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
}
