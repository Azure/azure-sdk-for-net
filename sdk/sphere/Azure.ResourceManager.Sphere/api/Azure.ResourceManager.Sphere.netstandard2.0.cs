namespace Azure.ResourceManager.Sphere
{
    public partial class SphereCatalogCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sphere.SphereCatalogResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sphere.SphereCatalogResource>, System.Collections.IEnumerable
    {
        protected SphereCatalogCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sphere.SphereCatalogResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string catalogName, Azure.ResourceManager.Sphere.SphereCatalogData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sphere.SphereCatalogResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string catalogName, Azure.ResourceManager.Sphere.SphereCatalogData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string catalogName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string catalogName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sphere.SphereCatalogResource> Get(string catalogName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sphere.SphereCatalogResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sphere.SphereCatalogResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sphere.SphereCatalogResource>> GetAsync(string catalogName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Sphere.SphereCatalogResource> GetIfExists(string catalogName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Sphere.SphereCatalogResource>> GetIfExistsAsync(string catalogName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sphere.SphereCatalogResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sphere.SphereCatalogResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sphere.SphereCatalogResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sphere.SphereCatalogResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SphereCatalogData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sphere.SphereCatalogData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sphere.SphereCatalogData>
    {
        public SphereCatalogData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Sphere.Models.SphereProvisioningState? ProvisioningState { get { throw null; } }
        Azure.ResourceManager.Sphere.SphereCatalogData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sphere.SphereCatalogData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sphere.SphereCatalogData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Sphere.SphereCatalogData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sphere.SphereCatalogData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sphere.SphereCatalogData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sphere.SphereCatalogData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SphereCatalogResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SphereCatalogResource() { }
        public virtual Azure.ResourceManager.Sphere.SphereCatalogData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Sphere.SphereCatalogResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sphere.SphereCatalogResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sphere.Models.CountDeviceResult> CountDevices(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sphere.Models.CountDeviceResult>> CountDevicesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string catalogName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sphere.SphereCatalogResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sphere.SphereCatalogResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sphere.SphereDeploymentResource> GetDeployments(string filter = null, int? top = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sphere.SphereDeploymentResource> GetDeploymentsAsync(string filter = null, int? top = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sphere.SphereDeviceGroupResource> GetDeviceGroups(Azure.ResourceManager.Sphere.Models.ListSphereDeviceGroupsContent content, string filter = null, int? top = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sphere.SphereDeviceGroupResource> GetDeviceGroupsAsync(Azure.ResourceManager.Sphere.Models.ListSphereDeviceGroupsContent content, string filter = null, int? top = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sphere.Models.SphereDeviceInsight> GetDeviceInsights(string filter = null, int? top = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sphere.Models.SphereDeviceInsight> GetDeviceInsightsAsync(string filter = null, int? top = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sphere.SphereDeviceResource> GetDevices(string filter = null, int? top = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sphere.SphereDeviceResource> GetDevicesAsync(string filter = null, int? top = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sphere.SphereCertificateResource> GetSphereCertificate(string serialNumber, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sphere.SphereCertificateResource>> GetSphereCertificateAsync(string serialNumber, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sphere.SphereCertificateCollection GetSphereCertificates() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sphere.SphereImageResource> GetSphereImage(string imageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sphere.SphereImageResource>> GetSphereImageAsync(string imageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sphere.SphereImageCollection GetSphereImages() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sphere.SphereProductResource> GetSphereProduct(string productName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sphere.SphereProductResource>> GetSphereProductAsync(string productName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sphere.SphereProductCollection GetSphereProducts() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sphere.SphereCatalogResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sphere.SphereCatalogResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sphere.SphereCatalogResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sphere.SphereCatalogResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sphere.SphereCatalogResource> Update(Azure.ResourceManager.Sphere.Models.SphereCatalogPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sphere.SphereCatalogResource>> UpdateAsync(Azure.ResourceManager.Sphere.Models.SphereCatalogPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SphereCertificateCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sphere.SphereCertificateResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sphere.SphereCertificateResource>, System.Collections.IEnumerable
    {
        protected SphereCertificateCollection() { }
        public virtual Azure.Response<bool> Exists(string serialNumber, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string serialNumber, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sphere.SphereCertificateResource> Get(string serialNumber, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sphere.SphereCertificateResource> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sphere.SphereCertificateResource> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sphere.SphereCertificateResource>> GetAsync(string serialNumber, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Sphere.SphereCertificateResource> GetIfExists(string serialNumber, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Sphere.SphereCertificateResource>> GetIfExistsAsync(string serialNumber, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sphere.SphereCertificateResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sphere.SphereCertificateResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sphere.SphereCertificateResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sphere.SphereCertificateResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SphereCertificateData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sphere.SphereCertificateData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sphere.SphereCertificateData>
    {
        public SphereCertificateData() { }
        public string Certificate { get { throw null; } }
        public System.DateTimeOffset? ExpiryUtc { get { throw null; } }
        public System.DateTimeOffset? NotBeforeUtc { get { throw null; } }
        public Azure.ResourceManager.Sphere.Models.SphereProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Sphere.Models.SphereCertificateStatus? Status { get { throw null; } }
        public string Subject { get { throw null; } }
        public string Thumbprint { get { throw null; } }
        Azure.ResourceManager.Sphere.SphereCertificateData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sphere.SphereCertificateData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sphere.SphereCertificateData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Sphere.SphereCertificateData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sphere.SphereCertificateData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sphere.SphereCertificateData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sphere.SphereCertificateData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SphereCertificateResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SphereCertificateResource() { }
        public virtual Azure.ResourceManager.Sphere.SphereCertificateData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string catalogName, string serialNumber) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sphere.SphereCertificateResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sphere.SphereCertificateResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sphere.Models.SphereCertificateChainResult> RetrieveCertChain(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sphere.Models.SphereCertificateChainResult>> RetrieveCertChainAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sphere.Models.ProofOfPossessionNonceResponse> RetrieveProofOfPossessionNonce(Azure.ResourceManager.Sphere.Models.ProofOfPossessionNonceContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sphere.Models.ProofOfPossessionNonceResponse>> RetrieveProofOfPossessionNonceAsync(Azure.ResourceManager.Sphere.Models.ProofOfPossessionNonceContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SphereDeploymentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sphere.SphereDeploymentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sphere.SphereDeploymentResource>, System.Collections.IEnumerable
    {
        protected SphereDeploymentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sphere.SphereDeploymentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string deploymentName, Azure.ResourceManager.Sphere.SphereDeploymentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sphere.SphereDeploymentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string deploymentName, Azure.ResourceManager.Sphere.SphereDeploymentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sphere.SphereDeploymentResource> Get(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sphere.SphereDeploymentResource> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sphere.SphereDeploymentResource> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sphere.SphereDeploymentResource>> GetAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Sphere.SphereDeploymentResource> GetIfExists(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Sphere.SphereDeploymentResource>> GetIfExistsAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sphere.SphereDeploymentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sphere.SphereDeploymentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sphere.SphereDeploymentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sphere.SphereDeploymentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SphereDeploymentData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sphere.SphereDeploymentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sphere.SphereDeploymentData>
    {
        public SphereDeploymentData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Sphere.SphereImageData> DeployedImages { get { throw null; } }
        public System.DateTimeOffset? DeploymentDateUtc { get { throw null; } }
        public string DeploymentId { get { throw null; } set { } }
        public Azure.ResourceManager.Sphere.Models.SphereProvisioningState? ProvisioningState { get { throw null; } }
        Azure.ResourceManager.Sphere.SphereDeploymentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sphere.SphereDeploymentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sphere.SphereDeploymentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Sphere.SphereDeploymentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sphere.SphereDeploymentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sphere.SphereDeploymentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sphere.SphereDeploymentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SphereDeploymentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SphereDeploymentResource() { }
        public virtual Azure.ResourceManager.Sphere.SphereDeploymentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string catalogName, string productName, string deviceGroupName, string deploymentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sphere.SphereDeploymentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sphere.SphereDeploymentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sphere.SphereDeploymentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sphere.SphereDeploymentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sphere.SphereDeploymentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sphere.SphereDeploymentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SphereDeviceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sphere.SphereDeviceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sphere.SphereDeviceResource>, System.Collections.IEnumerable
    {
        protected SphereDeviceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sphere.SphereDeviceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string deviceName, Azure.ResourceManager.Sphere.SphereDeviceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sphere.SphereDeviceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string deviceName, Azure.ResourceManager.Sphere.SphereDeviceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string deviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string deviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sphere.SphereDeviceResource> Get(string deviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sphere.SphereDeviceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sphere.SphereDeviceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sphere.SphereDeviceResource>> GetAsync(string deviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Sphere.SphereDeviceResource> GetIfExists(string deviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Sphere.SphereDeviceResource>> GetIfExistsAsync(string deviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sphere.SphereDeviceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sphere.SphereDeviceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sphere.SphereDeviceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sphere.SphereDeviceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SphereDeviceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sphere.SphereDeviceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sphere.SphereDeviceData>
    {
        public SphereDeviceData() { }
        public string ChipSku { get { throw null; } }
        public string DeviceId { get { throw null; } set { } }
        public string LastAvailableOSVersion { get { throw null; } }
        public string LastInstalledOSVersion { get { throw null; } }
        public System.DateTimeOffset? LastOSUpdateUtc { get { throw null; } }
        public System.DateTimeOffset? LastUpdateRequestUtc { get { throw null; } }
        public Azure.ResourceManager.Sphere.Models.SphereProvisioningState? ProvisioningState { get { throw null; } }
        Azure.ResourceManager.Sphere.SphereDeviceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sphere.SphereDeviceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sphere.SphereDeviceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Sphere.SphereDeviceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sphere.SphereDeviceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sphere.SphereDeviceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sphere.SphereDeviceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SphereDeviceGroupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sphere.SphereDeviceGroupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sphere.SphereDeviceGroupResource>, System.Collections.IEnumerable
    {
        protected SphereDeviceGroupCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sphere.SphereDeviceGroupResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string deviceGroupName, Azure.ResourceManager.Sphere.SphereDeviceGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sphere.SphereDeviceGroupResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string deviceGroupName, Azure.ResourceManager.Sphere.SphereDeviceGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string deviceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string deviceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sphere.SphereDeviceGroupResource> Get(string deviceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sphere.SphereDeviceGroupResource> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sphere.SphereDeviceGroupResource> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sphere.SphereDeviceGroupResource>> GetAsync(string deviceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Sphere.SphereDeviceGroupResource> GetIfExists(string deviceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Sphere.SphereDeviceGroupResource>> GetIfExistsAsync(string deviceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sphere.SphereDeviceGroupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sphere.SphereDeviceGroupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sphere.SphereDeviceGroupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sphere.SphereDeviceGroupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SphereDeviceGroupData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sphere.SphereDeviceGroupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sphere.SphereDeviceGroupData>
    {
        public SphereDeviceGroupData() { }
        public Azure.ResourceManager.Sphere.Models.SphereAllowCrashDumpCollectionStatus? AllowCrashDumpsCollection { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public bool? HasDeployment { get { throw null; } }
        public Azure.ResourceManager.Sphere.Models.SphereOSFeedType? OSFeedType { get { throw null; } set { } }
        public Azure.ResourceManager.Sphere.Models.SphereProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Sphere.Models.RegionalDataBoundary? RegionalDataBoundary { get { throw null; } set { } }
        public Azure.ResourceManager.Sphere.Models.SphereUpdatePolicy? UpdatePolicy { get { throw null; } set { } }
        Azure.ResourceManager.Sphere.SphereDeviceGroupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sphere.SphereDeviceGroupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sphere.SphereDeviceGroupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Sphere.SphereDeviceGroupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sphere.SphereDeviceGroupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sphere.SphereDeviceGroupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sphere.SphereDeviceGroupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SphereDeviceGroupResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SphereDeviceGroupResource() { }
        public virtual Azure.ResourceManager.Sphere.SphereDeviceGroupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation ClaimDevices(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sphere.Models.ClaimSphereDevicesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ClaimDevicesAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sphere.Models.ClaimSphereDevicesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sphere.Models.CountDeviceResult> CountDevices(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sphere.Models.CountDeviceResult>> CountDevicesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string catalogName, string productName, string deviceGroupName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sphere.SphereDeviceGroupResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sphere.SphereDeviceGroupResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sphere.SphereDeploymentResource> GetSphereDeployment(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sphere.SphereDeploymentResource>> GetSphereDeploymentAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sphere.SphereDeploymentCollection GetSphereDeployments() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sphere.SphereDeviceResource> GetSphereDevice(string deviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sphere.SphereDeviceResource>> GetSphereDeviceAsync(string deviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sphere.SphereDeviceCollection GetSphereDevices() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sphere.SphereDeviceGroupResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sphere.Models.SphereDeviceGroupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sphere.SphereDeviceGroupResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sphere.Models.SphereDeviceGroupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SphereDeviceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SphereDeviceResource() { }
        public virtual Azure.ResourceManager.Sphere.SphereDeviceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string catalogName, string productName, string deviceGroupName, string deviceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sphere.Models.SignedCapabilityImageResponse> GenerateCapabilityImage(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sphere.Models.GenerateCapabilityImageContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sphere.Models.SignedCapabilityImageResponse>> GenerateCapabilityImageAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sphere.Models.GenerateCapabilityImageContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sphere.SphereDeviceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sphere.SphereDeviceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sphere.SphereDeviceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sphere.Models.SphereDevicePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sphere.SphereDeviceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sphere.Models.SphereDevicePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class SphereExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Sphere.SphereCatalogResource> GetSphereCatalog(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string catalogName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sphere.SphereCatalogResource>> GetSphereCatalogAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string catalogName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Sphere.SphereCatalogResource GetSphereCatalogResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sphere.SphereCatalogCollection GetSphereCatalogs(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Sphere.SphereCatalogResource> GetSphereCatalogs(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Sphere.SphereCatalogResource> GetSphereCatalogsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Sphere.SphereCertificateResource GetSphereCertificateResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sphere.SphereDeploymentResource GetSphereDeploymentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sphere.SphereDeviceGroupResource GetSphereDeviceGroupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sphere.SphereDeviceResource GetSphereDeviceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sphere.SphereImageResource GetSphereImageResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sphere.SphereProductResource GetSphereProductResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class SphereImageCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sphere.SphereImageResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sphere.SphereImageResource>, System.Collections.IEnumerable
    {
        protected SphereImageCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sphere.SphereImageResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string imageName, Azure.ResourceManager.Sphere.SphereImageData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sphere.SphereImageResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string imageName, Azure.ResourceManager.Sphere.SphereImageData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string imageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string imageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sphere.SphereImageResource> Get(string imageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sphere.SphereImageResource> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sphere.SphereImageResource> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sphere.SphereImageResource>> GetAsync(string imageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Sphere.SphereImageResource> GetIfExists(string imageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Sphere.SphereImageResource>> GetIfExistsAsync(string imageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sphere.SphereImageResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sphere.SphereImageResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sphere.SphereImageResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sphere.SphereImageResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SphereImageData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sphere.SphereImageData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sphere.SphereImageData>
    {
        public SphereImageData() { }
        public string ComponentId { get { throw null; } }
        public string Description { get { throw null; } }
        public string Image { get { throw null; } set { } }
        public string ImageId { get { throw null; } set { } }
        public string ImageName { get { throw null; } }
        public Azure.ResourceManager.Sphere.Models.SphereImageType? ImageType { get { throw null; } }
        public Azure.ResourceManager.Sphere.Models.SphereProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Sphere.Models.RegionalDataBoundary? RegionalDataBoundary { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } }
        Azure.ResourceManager.Sphere.SphereImageData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sphere.SphereImageData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sphere.SphereImageData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Sphere.SphereImageData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sphere.SphereImageData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sphere.SphereImageData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sphere.SphereImageData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SphereImageResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SphereImageResource() { }
        public virtual Azure.ResourceManager.Sphere.SphereImageData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string catalogName, string imageName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sphere.SphereImageResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sphere.SphereImageResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sphere.SphereImageResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sphere.SphereImageData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sphere.SphereImageResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sphere.SphereImageData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SphereProductCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sphere.SphereProductResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sphere.SphereProductResource>, System.Collections.IEnumerable
    {
        protected SphereProductCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sphere.SphereProductResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string productName, Azure.ResourceManager.Sphere.SphereProductData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sphere.SphereProductResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string productName, Azure.ResourceManager.Sphere.SphereProductData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string productName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string productName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sphere.SphereProductResource> Get(string productName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sphere.SphereProductResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sphere.SphereProductResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sphere.SphereProductResource>> GetAsync(string productName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Sphere.SphereProductResource> GetIfExists(string productName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Sphere.SphereProductResource>> GetIfExistsAsync(string productName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sphere.SphereProductResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sphere.SphereProductResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sphere.SphereProductResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sphere.SphereProductResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SphereProductData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sphere.SphereProductData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sphere.SphereProductData>
    {
        public SphereProductData() { }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.Sphere.Models.SphereProvisioningState? ProvisioningState { get { throw null; } }
        Azure.ResourceManager.Sphere.SphereProductData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sphere.SphereProductData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sphere.SphereProductData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Sphere.SphereProductData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sphere.SphereProductData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sphere.SphereProductData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sphere.SphereProductData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SphereProductResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SphereProductResource() { }
        public virtual Azure.ResourceManager.Sphere.SphereProductData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Sphere.Models.CountDeviceResult> CountDevices(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sphere.Models.CountDeviceResult>> CountDevicesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string catalogName, string productName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sphere.SphereDeviceGroupResource> GenerateDefaultDeviceGroups(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sphere.SphereDeviceGroupResource> GenerateDefaultDeviceGroupsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sphere.SphereProductResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sphere.SphereProductResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sphere.SphereDeviceGroupResource> GetSphereDeviceGroup(string deviceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sphere.SphereDeviceGroupResource>> GetSphereDeviceGroupAsync(string deviceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sphere.SphereDeviceGroupCollection GetSphereDeviceGroups() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sphere.SphereProductResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sphere.Models.SphereProductPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sphere.SphereProductResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sphere.Models.SphereProductPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Sphere.Mocking
{
    public partial class MockableSphereArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableSphereArmClient() { }
        public virtual Azure.ResourceManager.Sphere.SphereCatalogResource GetSphereCatalogResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Sphere.SphereCertificateResource GetSphereCertificateResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Sphere.SphereDeploymentResource GetSphereDeploymentResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Sphere.SphereDeviceGroupResource GetSphereDeviceGroupResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Sphere.SphereDeviceResource GetSphereDeviceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Sphere.SphereImageResource GetSphereImageResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Sphere.SphereProductResource GetSphereProductResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableSphereResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableSphereResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Sphere.SphereCatalogResource> GetSphereCatalog(string catalogName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sphere.SphereCatalogResource>> GetSphereCatalogAsync(string catalogName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sphere.SphereCatalogCollection GetSphereCatalogs() { throw null; }
    }
    public partial class MockableSphereSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableSphereSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Sphere.SphereCatalogResource> GetSphereCatalogs(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sphere.SphereCatalogResource> GetSphereCatalogsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Sphere.Models
{
    public static partial class ArmSphereModelFactory
    {
        public static Azure.ResourceManager.Sphere.Models.CountDeviceResult CountDeviceResult(int value = 0) { throw null; }
        public static Azure.ResourceManager.Sphere.Models.CountElementsResult CountElementsResult(int value = 0) { throw null; }
        public static Azure.ResourceManager.Sphere.Models.ProofOfPossessionNonceResponse ProofOfPossessionNonceResponse(string certificate = null, Azure.ResourceManager.Sphere.Models.SphereCertificateStatus? status = default(Azure.ResourceManager.Sphere.Models.SphereCertificateStatus?), string subject = null, string thumbprint = null, System.DateTimeOffset? expiryUtc = default(System.DateTimeOffset?), System.DateTimeOffset? notBeforeUtc = default(System.DateTimeOffset?), Azure.ResourceManager.Sphere.Models.SphereProvisioningState? provisioningState = default(Azure.ResourceManager.Sphere.Models.SphereProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Sphere.Models.SignedCapabilityImageResponse SignedCapabilityImageResponse(string image = null) { throw null; }
        public static Azure.ResourceManager.Sphere.SphereCatalogData SphereCatalogData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Sphere.Models.SphereProvisioningState? provisioningState = default(Azure.ResourceManager.Sphere.Models.SphereProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Sphere.Models.SphereCertificateChainResult SphereCertificateChainResult(string certificateChain = null) { throw null; }
        public static Azure.ResourceManager.Sphere.SphereCertificateData SphereCertificateData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string certificate = null, Azure.ResourceManager.Sphere.Models.SphereCertificateStatus? status = default(Azure.ResourceManager.Sphere.Models.SphereCertificateStatus?), string subject = null, string thumbprint = null, System.DateTimeOffset? expiryUtc = default(System.DateTimeOffset?), System.DateTimeOffset? notBeforeUtc = default(System.DateTimeOffset?), Azure.ResourceManager.Sphere.Models.SphereProvisioningState? provisioningState = default(Azure.ResourceManager.Sphere.Models.SphereProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Sphere.Models.SphereCertificateProperties SphereCertificateProperties(string certificate = null, Azure.ResourceManager.Sphere.Models.SphereCertificateStatus? status = default(Azure.ResourceManager.Sphere.Models.SphereCertificateStatus?), string subject = null, string thumbprint = null, System.DateTimeOffset? expiryUtc = default(System.DateTimeOffset?), System.DateTimeOffset? notBeforeUtc = default(System.DateTimeOffset?), Azure.ResourceManager.Sphere.Models.SphereProvisioningState? provisioningState = default(Azure.ResourceManager.Sphere.Models.SphereProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Sphere.SphereDeploymentData SphereDeploymentData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string deploymentId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sphere.SphereImageData> deployedImages = null, System.DateTimeOffset? deploymentDateUtc = default(System.DateTimeOffset?), Azure.ResourceManager.Sphere.Models.SphereProvisioningState? provisioningState = default(Azure.ResourceManager.Sphere.Models.SphereProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Sphere.SphereDeviceData SphereDeviceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string deviceId = null, string chipSku = null, string lastAvailableOSVersion = null, string lastInstalledOSVersion = null, System.DateTimeOffset? lastOSUpdateUtc = default(System.DateTimeOffset?), System.DateTimeOffset? lastUpdateRequestUtc = default(System.DateTimeOffset?), Azure.ResourceManager.Sphere.Models.SphereProvisioningState? provisioningState = default(Azure.ResourceManager.Sphere.Models.SphereProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Sphere.SphereDeviceGroupData SphereDeviceGroupData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string description = null, Azure.ResourceManager.Sphere.Models.SphereOSFeedType? osFeedType = default(Azure.ResourceManager.Sphere.Models.SphereOSFeedType?), Azure.ResourceManager.Sphere.Models.SphereUpdatePolicy? updatePolicy = default(Azure.ResourceManager.Sphere.Models.SphereUpdatePolicy?), Azure.ResourceManager.Sphere.Models.SphereAllowCrashDumpCollectionStatus? allowCrashDumpsCollection = default(Azure.ResourceManager.Sphere.Models.SphereAllowCrashDumpCollectionStatus?), Azure.ResourceManager.Sphere.Models.RegionalDataBoundary? regionalDataBoundary = default(Azure.ResourceManager.Sphere.Models.RegionalDataBoundary?), bool? hasDeployment = default(bool?), Azure.ResourceManager.Sphere.Models.SphereProvisioningState? provisioningState = default(Azure.ResourceManager.Sphere.Models.SphereProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Sphere.Models.SphereDeviceInsight SphereDeviceInsight(string deviceId = null, string description = null, System.DateTimeOffset startTimestampUtc = default(System.DateTimeOffset), System.DateTimeOffset endTimestampUtc = default(System.DateTimeOffset), string eventCategory = null, string eventClass = null, string eventType = null, int eventCount = 0) { throw null; }
        public static Azure.ResourceManager.Sphere.SphereImageData SphereImageData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string image = null, string imageId = null, string imageName = null, Azure.ResourceManager.Sphere.Models.RegionalDataBoundary? regionalDataBoundary = default(Azure.ResourceManager.Sphere.Models.RegionalDataBoundary?), System.Uri uri = null, string description = null, string componentId = null, Azure.ResourceManager.Sphere.Models.SphereImageType? imageType = default(Azure.ResourceManager.Sphere.Models.SphereImageType?), Azure.ResourceManager.Sphere.Models.SphereProvisioningState? provisioningState = default(Azure.ResourceManager.Sphere.Models.SphereProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Sphere.SphereProductData SphereProductData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string description = null, Azure.ResourceManager.Sphere.Models.SphereProvisioningState? provisioningState = default(Azure.ResourceManager.Sphere.Models.SphereProvisioningState?)) { throw null; }
    }
    public partial class ClaimSphereDevicesContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sphere.Models.ClaimSphereDevicesContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sphere.Models.ClaimSphereDevicesContent>
    {
        public ClaimSphereDevicesContent(System.Collections.Generic.IEnumerable<string> deviceIdentifiers) { }
        public System.Collections.Generic.IList<string> DeviceIdentifiers { get { throw null; } }
        Azure.ResourceManager.Sphere.Models.ClaimSphereDevicesContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sphere.Models.ClaimSphereDevicesContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sphere.Models.ClaimSphereDevicesContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Sphere.Models.ClaimSphereDevicesContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sphere.Models.ClaimSphereDevicesContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sphere.Models.ClaimSphereDevicesContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sphere.Models.ClaimSphereDevicesContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CountDeviceResult : Azure.ResourceManager.Sphere.Models.CountElementsResult, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sphere.Models.CountDeviceResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sphere.Models.CountDeviceResult>
    {
        internal CountDeviceResult() { }
        Azure.ResourceManager.Sphere.Models.CountDeviceResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sphere.Models.CountDeviceResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sphere.Models.CountDeviceResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Sphere.Models.CountDeviceResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sphere.Models.CountDeviceResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sphere.Models.CountDeviceResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sphere.Models.CountDeviceResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CountElementsResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sphere.Models.CountElementsResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sphere.Models.CountElementsResult>
    {
        internal CountElementsResult() { }
        public int Value { get { throw null; } }
        Azure.ResourceManager.Sphere.Models.CountElementsResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sphere.Models.CountElementsResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sphere.Models.CountElementsResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Sphere.Models.CountElementsResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sphere.Models.CountElementsResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sphere.Models.CountElementsResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sphere.Models.CountElementsResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GenerateCapabilityImageContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sphere.Models.GenerateCapabilityImageContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sphere.Models.GenerateCapabilityImageContent>
    {
        public GenerateCapabilityImageContent(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sphere.Models.SphereCapabilityType> capabilities) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Sphere.Models.SphereCapabilityType> Capabilities { get { throw null; } }
        Azure.ResourceManager.Sphere.Models.GenerateCapabilityImageContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sphere.Models.GenerateCapabilityImageContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sphere.Models.GenerateCapabilityImageContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Sphere.Models.GenerateCapabilityImageContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sphere.Models.GenerateCapabilityImageContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sphere.Models.GenerateCapabilityImageContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sphere.Models.GenerateCapabilityImageContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ListSphereDeviceGroupsContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sphere.Models.ListSphereDeviceGroupsContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sphere.Models.ListSphereDeviceGroupsContent>
    {
        public ListSphereDeviceGroupsContent() { }
        public string DeviceGroupName { get { throw null; } set { } }
        Azure.ResourceManager.Sphere.Models.ListSphereDeviceGroupsContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sphere.Models.ListSphereDeviceGroupsContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sphere.Models.ListSphereDeviceGroupsContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Sphere.Models.ListSphereDeviceGroupsContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sphere.Models.ListSphereDeviceGroupsContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sphere.Models.ListSphereDeviceGroupsContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sphere.Models.ListSphereDeviceGroupsContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProofOfPossessionNonceContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sphere.Models.ProofOfPossessionNonceContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sphere.Models.ProofOfPossessionNonceContent>
    {
        public ProofOfPossessionNonceContent(string proofOfPossessionNonce) { }
        public string ProofOfPossessionNonce { get { throw null; } }
        Azure.ResourceManager.Sphere.Models.ProofOfPossessionNonceContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sphere.Models.ProofOfPossessionNonceContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sphere.Models.ProofOfPossessionNonceContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Sphere.Models.ProofOfPossessionNonceContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sphere.Models.ProofOfPossessionNonceContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sphere.Models.ProofOfPossessionNonceContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sphere.Models.ProofOfPossessionNonceContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProofOfPossessionNonceResponse : Azure.ResourceManager.Sphere.Models.SphereCertificateProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sphere.Models.ProofOfPossessionNonceResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sphere.Models.ProofOfPossessionNonceResponse>
    {
        internal ProofOfPossessionNonceResponse() { }
        Azure.ResourceManager.Sphere.Models.ProofOfPossessionNonceResponse System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sphere.Models.ProofOfPossessionNonceResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sphere.Models.ProofOfPossessionNonceResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Sphere.Models.ProofOfPossessionNonceResponse System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sphere.Models.ProofOfPossessionNonceResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sphere.Models.ProofOfPossessionNonceResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sphere.Models.ProofOfPossessionNonceResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class SignedCapabilityImageResponse : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sphere.Models.SignedCapabilityImageResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sphere.Models.SignedCapabilityImageResponse>
    {
        internal SignedCapabilityImageResponse() { }
        public string Image { get { throw null; } }
        Azure.ResourceManager.Sphere.Models.SignedCapabilityImageResponse System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sphere.Models.SignedCapabilityImageResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sphere.Models.SignedCapabilityImageResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Sphere.Models.SignedCapabilityImageResponse System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sphere.Models.SignedCapabilityImageResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sphere.Models.SignedCapabilityImageResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sphere.Models.SignedCapabilityImageResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SphereAllowCrashDumpCollectionStatus : System.IEquatable<Azure.ResourceManager.Sphere.Models.SphereAllowCrashDumpCollectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SphereAllowCrashDumpCollectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.Sphere.Models.SphereAllowCrashDumpCollectionStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.Sphere.Models.SphereAllowCrashDumpCollectionStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sphere.Models.SphereAllowCrashDumpCollectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sphere.Models.SphereAllowCrashDumpCollectionStatus left, Azure.ResourceManager.Sphere.Models.SphereAllowCrashDumpCollectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sphere.Models.SphereAllowCrashDumpCollectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sphere.Models.SphereAllowCrashDumpCollectionStatus left, Azure.ResourceManager.Sphere.Models.SphereAllowCrashDumpCollectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SphereCapabilityType : System.IEquatable<Azure.ResourceManager.Sphere.Models.SphereCapabilityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SphereCapabilityType(string value) { throw null; }
        public static Azure.ResourceManager.Sphere.Models.SphereCapabilityType ApplicationDevelopment { get { throw null; } }
        public static Azure.ResourceManager.Sphere.Models.SphereCapabilityType FieldServicing { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sphere.Models.SphereCapabilityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sphere.Models.SphereCapabilityType left, Azure.ResourceManager.Sphere.Models.SphereCapabilityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sphere.Models.SphereCapabilityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sphere.Models.SphereCapabilityType left, Azure.ResourceManager.Sphere.Models.SphereCapabilityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SphereCatalogPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sphere.Models.SphereCatalogPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sphere.Models.SphereCatalogPatch>
    {
        public SphereCatalogPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.Sphere.Models.SphereCatalogPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sphere.Models.SphereCatalogPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sphere.Models.SphereCatalogPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Sphere.Models.SphereCatalogPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sphere.Models.SphereCatalogPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sphere.Models.SphereCatalogPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sphere.Models.SphereCatalogPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SphereCertificateChainResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sphere.Models.SphereCertificateChainResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sphere.Models.SphereCertificateChainResult>
    {
        internal SphereCertificateChainResult() { }
        public string CertificateChain { get { throw null; } }
        Azure.ResourceManager.Sphere.Models.SphereCertificateChainResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sphere.Models.SphereCertificateChainResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sphere.Models.SphereCertificateChainResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Sphere.Models.SphereCertificateChainResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sphere.Models.SphereCertificateChainResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sphere.Models.SphereCertificateChainResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sphere.Models.SphereCertificateChainResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SphereCertificateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sphere.Models.SphereCertificateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sphere.Models.SphereCertificateProperties>
    {
        internal SphereCertificateProperties() { }
        public string Certificate { get { throw null; } }
        public System.DateTimeOffset? ExpiryUtc { get { throw null; } }
        public System.DateTimeOffset? NotBeforeUtc { get { throw null; } }
        public Azure.ResourceManager.Sphere.Models.SphereProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Sphere.Models.SphereCertificateStatus? Status { get { throw null; } }
        public string Subject { get { throw null; } }
        public string Thumbprint { get { throw null; } }
        Azure.ResourceManager.Sphere.Models.SphereCertificateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sphere.Models.SphereCertificateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sphere.Models.SphereCertificateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Sphere.Models.SphereCertificateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sphere.Models.SphereCertificateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sphere.Models.SphereCertificateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sphere.Models.SphereCertificateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SphereCertificateStatus : System.IEquatable<Azure.ResourceManager.Sphere.Models.SphereCertificateStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SphereCertificateStatus(string value) { throw null; }
        public static Azure.ResourceManager.Sphere.Models.SphereCertificateStatus Active { get { throw null; } }
        public static Azure.ResourceManager.Sphere.Models.SphereCertificateStatus Expired { get { throw null; } }
        public static Azure.ResourceManager.Sphere.Models.SphereCertificateStatus Inactive { get { throw null; } }
        public static Azure.ResourceManager.Sphere.Models.SphereCertificateStatus Revoked { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sphere.Models.SphereCertificateStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sphere.Models.SphereCertificateStatus left, Azure.ResourceManager.Sphere.Models.SphereCertificateStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sphere.Models.SphereCertificateStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sphere.Models.SphereCertificateStatus left, Azure.ResourceManager.Sphere.Models.SphereCertificateStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SphereDeviceGroupPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sphere.Models.SphereDeviceGroupPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sphere.Models.SphereDeviceGroupPatch>
    {
        public SphereDeviceGroupPatch() { }
        public Azure.ResourceManager.Sphere.Models.SphereAllowCrashDumpCollectionStatus? AllowCrashDumpsCollection { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.Sphere.Models.SphereOSFeedType? OSFeedType { get { throw null; } set { } }
        public Azure.ResourceManager.Sphere.Models.RegionalDataBoundary? RegionalDataBoundary { get { throw null; } set { } }
        public Azure.ResourceManager.Sphere.Models.SphereUpdatePolicy? UpdatePolicy { get { throw null; } set { } }
        Azure.ResourceManager.Sphere.Models.SphereDeviceGroupPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sphere.Models.SphereDeviceGroupPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sphere.Models.SphereDeviceGroupPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Sphere.Models.SphereDeviceGroupPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sphere.Models.SphereDeviceGroupPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sphere.Models.SphereDeviceGroupPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sphere.Models.SphereDeviceGroupPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SphereDeviceInsight : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sphere.Models.SphereDeviceInsight>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sphere.Models.SphereDeviceInsight>
    {
        internal SphereDeviceInsight() { }
        public string Description { get { throw null; } }
        public string DeviceId { get { throw null; } }
        public System.DateTimeOffset EndTimestampUtc { get { throw null; } }
        public string EventCategory { get { throw null; } }
        public string EventClass { get { throw null; } }
        public int EventCount { get { throw null; } }
        public string EventType { get { throw null; } }
        public System.DateTimeOffset StartTimestampUtc { get { throw null; } }
        Azure.ResourceManager.Sphere.Models.SphereDeviceInsight System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sphere.Models.SphereDeviceInsight>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sphere.Models.SphereDeviceInsight>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Sphere.Models.SphereDeviceInsight System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sphere.Models.SphereDeviceInsight>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sphere.Models.SphereDeviceInsight>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sphere.Models.SphereDeviceInsight>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SphereDevicePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sphere.Models.SphereDevicePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sphere.Models.SphereDevicePatch>
    {
        public SphereDevicePatch() { }
        public string DeviceGroupId { get { throw null; } set { } }
        Azure.ResourceManager.Sphere.Models.SphereDevicePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sphere.Models.SphereDevicePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sphere.Models.SphereDevicePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Sphere.Models.SphereDevicePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sphere.Models.SphereDevicePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sphere.Models.SphereDevicePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sphere.Models.SphereDevicePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SphereImageType : System.IEquatable<Azure.ResourceManager.Sphere.Models.SphereImageType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SphereImageType(string value) { throw null; }
        public static Azure.ResourceManager.Sphere.Models.SphereImageType Applications { get { throw null; } }
        public static Azure.ResourceManager.Sphere.Models.SphereImageType BaseSystemUpdateManifest { get { throw null; } }
        public static Azure.ResourceManager.Sphere.Models.SphereImageType BootManifest { get { throw null; } }
        public static Azure.ResourceManager.Sphere.Models.SphereImageType CustomerBoardConfig { get { throw null; } }
        public static Azure.ResourceManager.Sphere.Models.SphereImageType CustomerUpdateManifest { get { throw null; } }
        public static Azure.ResourceManager.Sphere.Models.SphereImageType FirmwareUpdateManifest { get { throw null; } }
        public static Azure.ResourceManager.Sphere.Models.SphereImageType FwConfig { get { throw null; } }
        public static Azure.ResourceManager.Sphere.Models.SphereImageType InvalidImageType { get { throw null; } }
        public static Azure.ResourceManager.Sphere.Models.SphereImageType ManifestSet { get { throw null; } }
        public static Azure.ResourceManager.Sphere.Models.SphereImageType NormalWorldDtb { get { throw null; } }
        public static Azure.ResourceManager.Sphere.Models.SphereImageType NormalWorldKernel { get { throw null; } }
        public static Azure.ResourceManager.Sphere.Models.SphereImageType NormalWorldLoader { get { throw null; } }
        public static Azure.ResourceManager.Sphere.Models.SphereImageType Nwfs { get { throw null; } }
        public static Azure.ResourceManager.Sphere.Models.SphereImageType OneBl { get { throw null; } }
        public static Azure.ResourceManager.Sphere.Models.SphereImageType Other { get { throw null; } }
        public static Azure.ResourceManager.Sphere.Models.SphereImageType PlutonRuntime { get { throw null; } }
        public static Azure.ResourceManager.Sphere.Models.SphereImageType Policy { get { throw null; } }
        public static Azure.ResourceManager.Sphere.Models.SphereImageType RecoveryManifest { get { throw null; } }
        public static Azure.ResourceManager.Sphere.Models.SphereImageType RootFs { get { throw null; } }
        public static Azure.ResourceManager.Sphere.Models.SphereImageType SecurityMonitor { get { throw null; } }
        public static Azure.ResourceManager.Sphere.Models.SphereImageType Services { get { throw null; } }
        public static Azure.ResourceManager.Sphere.Models.SphereImageType TrustedKeystore { get { throw null; } }
        public static Azure.ResourceManager.Sphere.Models.SphereImageType UpdateCertStore { get { throw null; } }
        public static Azure.ResourceManager.Sphere.Models.SphereImageType WifiFirmware { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sphere.Models.SphereImageType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sphere.Models.SphereImageType left, Azure.ResourceManager.Sphere.Models.SphereImageType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sphere.Models.SphereImageType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sphere.Models.SphereImageType left, Azure.ResourceManager.Sphere.Models.SphereImageType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SphereOSFeedType : System.IEquatable<Azure.ResourceManager.Sphere.Models.SphereOSFeedType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SphereOSFeedType(string value) { throw null; }
        public static Azure.ResourceManager.Sphere.Models.SphereOSFeedType Retail { get { throw null; } }
        public static Azure.ResourceManager.Sphere.Models.SphereOSFeedType RetailEval { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sphere.Models.SphereOSFeedType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sphere.Models.SphereOSFeedType left, Azure.ResourceManager.Sphere.Models.SphereOSFeedType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sphere.Models.SphereOSFeedType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sphere.Models.SphereOSFeedType left, Azure.ResourceManager.Sphere.Models.SphereOSFeedType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SphereProductPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sphere.Models.SphereProductPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sphere.Models.SphereProductPatch>
    {
        public SphereProductPatch() { }
        public string Description { get { throw null; } set { } }
        Azure.ResourceManager.Sphere.Models.SphereProductPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sphere.Models.SphereProductPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sphere.Models.SphereProductPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Sphere.Models.SphereProductPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sphere.Models.SphereProductPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sphere.Models.SphereProductPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sphere.Models.SphereProductPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SphereProvisioningState : System.IEquatable<Azure.ResourceManager.Sphere.Models.SphereProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SphereProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Sphere.Models.SphereProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.Sphere.Models.SphereProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Sphere.Models.SphereProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Sphere.Models.SphereProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Sphere.Models.SphereProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.Sphere.Models.SphereProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Sphere.Models.SphereProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sphere.Models.SphereProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sphere.Models.SphereProvisioningState left, Azure.ResourceManager.Sphere.Models.SphereProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sphere.Models.SphereProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sphere.Models.SphereProvisioningState left, Azure.ResourceManager.Sphere.Models.SphereProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SphereUpdatePolicy : System.IEquatable<Azure.ResourceManager.Sphere.Models.SphereUpdatePolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SphereUpdatePolicy(string value) { throw null; }
        public static Azure.ResourceManager.Sphere.Models.SphereUpdatePolicy No3RdPartyAppUpdates { get { throw null; } }
        public static Azure.ResourceManager.Sphere.Models.SphereUpdatePolicy UpdateAll { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sphere.Models.SphereUpdatePolicy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sphere.Models.SphereUpdatePolicy left, Azure.ResourceManager.Sphere.Models.SphereUpdatePolicy right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sphere.Models.SphereUpdatePolicy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sphere.Models.SphereUpdatePolicy left, Azure.ResourceManager.Sphere.Models.SphereUpdatePolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
}
