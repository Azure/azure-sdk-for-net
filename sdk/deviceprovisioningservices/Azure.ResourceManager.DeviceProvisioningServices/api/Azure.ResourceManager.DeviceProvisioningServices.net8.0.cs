namespace Azure.ResourceManager.DeviceProvisioningServices
{
    public partial class AzureResourceManagerDeviceProvisioningServicesContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerDeviceProvisioningServicesContext() { }
        public static Azure.ResourceManager.DeviceProvisioningServices.AzureResourceManagerDeviceProvisioningServicesContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class DeviceProvisioningServiceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServiceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServiceResource>, System.Collections.IEnumerable
    {
        protected DeviceProvisioningServiceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServiceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string provisioningServiceName, Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServiceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServiceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string provisioningServiceName, Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServiceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string provisioningServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string provisioningServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServiceResource> Get(string provisioningServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServiceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServiceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServiceResource>> GetAsync(string provisioningServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServiceResource> GetIfExists(string provisioningServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServiceResource>> GetIfExistsAsync(string provisioningServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServiceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServiceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServiceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServiceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DeviceProvisioningServiceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServiceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServiceData>
    {
        public DeviceProvisioningServiceData(Azure.Core.AzureLocation location, Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServiceProperties properties, Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesSkuInfo sku) { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServiceProperties Properties { get { throw null; } set { } }
        public string ResourceGroup { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesSkuInfo Sku { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServiceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServiceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServiceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServiceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServiceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServiceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServiceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceProvisioningServiceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServiceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServiceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DeviceProvisioningServiceResource() { }
        public virtual Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServiceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServiceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServiceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string provisioningServiceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServiceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServiceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesCertificateResource> GetDeviceProvisioningServicesCertificate(string certificateName, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesCertificateResource>> GetDeviceProvisioningServicesCertificateAsync(string certificateName, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesCertificateCollection GetDeviceProvisioningServicesCertificates() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateEndpointConnectionResource> GetDeviceProvisioningServicesPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateEndpointConnectionResource>> GetDeviceProvisioningServicesPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateEndpointConnectionCollection GetDeviceProvisioningServicesPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateLinkResource> GetDeviceProvisioningServicesPrivateLinkResource(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateLinkResource>> GetDeviceProvisioningServicesPrivateLinkResourceAsync(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateLinkResourceCollection GetDeviceProvisioningServicesPrivateLinkResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesSharedAccessKey> GetKey(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesSharedAccessKey>> GetKeyAsync(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesSharedAccessKey> GetKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesSharedAccessKey> GetKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesSkuDefinition> GetValidSkus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesSkuDefinition> GetValidSkusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServiceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServiceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServiceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServiceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServiceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServiceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServiceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServiceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServiceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServiceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServiceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServiceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServiceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeviceProvisioningServicesCertificateCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesCertificateResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesCertificateResource>, System.Collections.IEnumerable
    {
        protected DeviceProvisioningServicesCertificateCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesCertificateResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string certificateName, Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesCertificateData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesCertificateResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string certificateName, Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesCertificateData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string certificateName, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string certificateName, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesCertificateResource> Get(string certificateName, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesCertificateResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesCertificateResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesCertificateResource>> GetAsync(string certificateName, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesCertificateResource> GetIfExists(string certificateName, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesCertificateResource>> GetIfExistsAsync(string certificateName, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesCertificateResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesCertificateResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesCertificateResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesCertificateResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DeviceProvisioningServicesCertificateData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesCertificateData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesCertificateData>
    {
        public DeviceProvisioningServicesCertificateData() { }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesCertificateProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesCertificateData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesCertificateData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesCertificateData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesCertificateData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesCertificateData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesCertificateData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesCertificateData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceProvisioningServicesCertificateResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesCertificateData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesCertificateData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DeviceProvisioningServicesCertificateResource() { }
        public virtual Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesCertificateData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string provisioningServiceName, string certificateName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesCertificateResourceDeleteOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string ifMatch, string certificateCommonName = null, byte[] certificateRawBytes = null, bool? certificateIsVerified = default(bool?), Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesCertificatePurpose? certificatePurpose = default(Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesCertificatePurpose?), System.DateTimeOffset? certificateCreatedOn = default(System.DateTimeOffset?), System.DateTimeOffset? certificateLastUpdatedOn = default(System.DateTimeOffset?), bool? certificateHasPrivateKey = default(bool?), string certificateNonce = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesCertificateResourceDeleteOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch, string certificateCommonName = null, byte[] certificateRawBytes = null, bool? certificateIsVerified = default(bool?), Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesCertificatePurpose? certificatePurpose = default(Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesCertificatePurpose?), System.DateTimeOffset? certificateCreatedOn = default(System.DateTimeOffset?), System.DateTimeOffset? certificateLastUpdatedOn = default(System.DateTimeOffset?), bool? certificateHasPrivateKey = default(bool?), string certificateNonce = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceProvisioningServices.Models.CertificateVerificationCodeResult> GenerateVerificationCode(Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesCertificateResourceGenerateVerificationCodeOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceProvisioningServices.Models.CertificateVerificationCodeResult> GenerateVerificationCode(string ifMatch, string certificateCommonName = null, byte[] certificateRawBytes = null, bool? certificateIsVerified = default(bool?), Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesCertificatePurpose? certificatePurpose = default(Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesCertificatePurpose?), System.DateTimeOffset? certificateCreatedOn = default(System.DateTimeOffset?), System.DateTimeOffset? certificateLastUpdatedOn = default(System.DateTimeOffset?), bool? certificateHasPrivateKey = default(bool?), string certificateNonce = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceProvisioningServices.Models.CertificateVerificationCodeResult>> GenerateVerificationCodeAsync(Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesCertificateResourceGenerateVerificationCodeOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceProvisioningServices.Models.CertificateVerificationCodeResult>> GenerateVerificationCodeAsync(string ifMatch, string certificateCommonName = null, byte[] certificateRawBytes = null, bool? certificateIsVerified = default(bool?), Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesCertificatePurpose? certificatePurpose = default(Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesCertificatePurpose?), System.DateTimeOffset? certificateCreatedOn = default(System.DateTimeOffset?), System.DateTimeOffset? certificateLastUpdatedOn = default(System.DateTimeOffset?), bool? certificateHasPrivateKey = default(bool?), string certificateNonce = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesCertificateResource> Get(string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesCertificateResource>> GetAsync(string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesCertificateData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesCertificateData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesCertificateData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesCertificateData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesCertificateData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesCertificateData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesCertificateData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesCertificateResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesCertificateData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesCertificateResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesCertificateData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesCertificateResource> VerifyCertificate(Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesCertificateResourceVerifyCertificateOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesCertificateResource> VerifyCertificate(string ifMatch, Azure.ResourceManager.DeviceProvisioningServices.Models.CertificateVerificationCodeContent content, string certificateCommonName = null, byte[] certificateRawBytes = null, bool? certificateIsVerified = default(bool?), Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesCertificatePurpose? certificatePurpose = default(Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesCertificatePurpose?), System.DateTimeOffset? certificateCreatedOn = default(System.DateTimeOffset?), System.DateTimeOffset? certificateLastUpdatedOn = default(System.DateTimeOffset?), bool? certificateHasPrivateKey = default(bool?), string certificateNonce = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesCertificateResource>> VerifyCertificateAsync(Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesCertificateResourceVerifyCertificateOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesCertificateResource>> VerifyCertificateAsync(string ifMatch, Azure.ResourceManager.DeviceProvisioningServices.Models.CertificateVerificationCodeContent content, string certificateCommonName = null, byte[] certificateRawBytes = null, bool? certificateIsVerified = default(bool?), Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesCertificatePurpose? certificatePurpose = default(Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesCertificatePurpose?), System.DateTimeOffset? certificateCreatedOn = default(System.DateTimeOffset?), System.DateTimeOffset? certificateLastUpdatedOn = default(System.DateTimeOffset?), bool? certificateHasPrivateKey = default(bool?), string certificateNonce = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class DeviceProvisioningServicesExtensions
    {
        public static Azure.Response<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesNameAvailabilityResult> CheckDeviceProvisioningServicesNameAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesNameAvailabilityResult>> CheckDeviceProvisioningServicesNameAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServiceResource> GetDeviceProvisioningService(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string provisioningServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServiceResource>> GetDeviceProvisioningServiceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string provisioningServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServiceResource GetDeviceProvisioningServiceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServiceCollection GetDeviceProvisioningServices(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServiceResource> GetDeviceProvisioningServices(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServiceResource> GetDeviceProvisioningServicesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesCertificateResource GetDeviceProvisioningServicesCertificateResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateEndpointConnectionResource GetDeviceProvisioningServicesPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateLinkResource GetDeviceProvisioningServicesPrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class DeviceProvisioningServicesPrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected DeviceProvisioningServicesPrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateEndpointConnectionResource> GetIfExists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateEndpointConnectionResource>> GetIfExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DeviceProvisioningServicesPrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateEndpointConnectionData>
    {
        public DeviceProvisioningServicesPrivateEndpointConnectionData(Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesPrivateEndpointConnectionProperties properties) { }
        public Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesPrivateEndpointConnectionProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceProvisioningServicesPrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateEndpointConnectionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DeviceProvisioningServicesPrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateEndpointConnectionResource> Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateEndpointConnectionResource>> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeviceProvisioningServicesPrivateLinkResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateLinkResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateLinkResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DeviceProvisioningServicesPrivateLinkResource() { }
        public virtual Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateLinkResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string groupId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateLinkResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateLinkResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateLinkResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateLinkResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateLinkResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateLinkResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateLinkResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceProvisioningServicesPrivateLinkResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateLinkResource>, System.Collections.IEnumerable
    {
        protected DeviceProvisioningServicesPrivateLinkResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateLinkResource> Get(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateLinkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateLinkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateLinkResource>> GetAsync(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateLinkResource> GetIfExists(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateLinkResource>> GetIfExistsAsync(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DeviceProvisioningServicesPrivateLinkResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateLinkResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateLinkResourceData>
    {
        internal DeviceProvisioningServicesPrivateLinkResourceData() { }
        public Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesPrivateLinkResourceProperties Properties { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateLinkResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateLinkResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateLinkResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateLinkResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateLinkResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateLinkResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateLinkResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Azure.ResourceManager.DeviceProvisioningServices.Mocking
{
    public partial class MockableDeviceProvisioningServicesArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableDeviceProvisioningServicesArmClient() { }
        public virtual Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServiceResource GetDeviceProvisioningServiceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesCertificateResource GetDeviceProvisioningServicesCertificateResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateEndpointConnectionResource GetDeviceProvisioningServicesPrivateEndpointConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateLinkResource GetDeviceProvisioningServicesPrivateLinkResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableDeviceProvisioningServicesResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableDeviceProvisioningServicesResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServiceResource> GetDeviceProvisioningService(string provisioningServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServiceResource>> GetDeviceProvisioningServiceAsync(string provisioningServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServiceCollection GetDeviceProvisioningServices() { throw null; }
    }
    public partial class MockableDeviceProvisioningServicesSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableDeviceProvisioningServicesSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesNameAvailabilityResult> CheckDeviceProvisioningServicesNameAvailability(Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesNameAvailabilityResult>> CheckDeviceProvisioningServicesNameAvailabilityAsync(Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServiceResource> GetDeviceProvisioningServices(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServiceResource> GetDeviceProvisioningServicesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.DeviceProvisioningServices.Models
{
    public static partial class ArmDeviceProvisioningServicesModelFactory
    {
        public static Azure.ResourceManager.DeviceProvisioningServices.Models.CertificateVerificationCodeProperties CertificateVerificationCodeProperties(string verificationCode = null, string subject = null, System.DateTimeOffset? expireOn = default(System.DateTimeOffset?), System.BinaryData thumbprint = null, bool? isVerified = default(bool?), System.BinaryData certificate = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.DeviceProvisioningServices.Models.CertificateVerificationCodeResult CertificateVerificationCodeResult(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ETag? etag = default(Azure.ETag?), Azure.ResourceManager.DeviceProvisioningServices.Models.CertificateVerificationCodeProperties properties = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServiceData DeviceProvisioningServiceData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ETag? etag, Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServiceProperties properties, Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesSkuInfo sku) { throw null; }
        public static Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServiceData DeviceProvisioningServiceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ETag? etag = default(Azure.ETag?), string resourceGroup = null, string subscriptionId = null, Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServiceProperties properties = null, Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesSkuInfo sku = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServiceProperties DeviceProvisioningServiceProperties(Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesState? state = default(Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesState?), Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesPublicNetworkAccess? publicNetworkAccess = default(Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesPublicNetworkAccess?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesIPFilterRule> ipFilterRules = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateEndpointConnectionData> privateEndpointConnections = null, string provisioningState = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceProvisioningServices.Models.IotHubDefinitionDescription> iotHubs = null, Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceRegistryNamespaceDescription deviceRegistryNamespace = null, Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesAllocationPolicy? allocationPolicy = default(Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesAllocationPolicy?), string serviceOperationsHostName = null, string deviceProvisioningHostName = null, string idScope = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesSharedAccessKey> authorizationPolicies = null, bool? isDataResidencyEnabled = default(bool?), string portalOperationsHostName = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServiceProperties DeviceProvisioningServiceProperties(Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesState? state, Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesPublicNetworkAccess? publicNetworkAccess, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesIPFilterRule> ipFilterRules, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateEndpointConnectionData> privateEndpointConnections, string provisioningState, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceProvisioningServices.Models.IotHubDefinitionDescription> iotHubs, Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesAllocationPolicy? allocationPolicy, string serviceOperationsHostName, string deviceProvisioningHostName, string idScope, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesSharedAccessKey> authorizationPolicies, bool? isDataResidencyEnabled) { throw null; }
        public static Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesCertificateData DeviceProvisioningServicesCertificateData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesCertificateProperties properties = null, Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesCertificateProperties DeviceProvisioningServicesCertificateProperties(string subject = null, System.DateTimeOffset? expireOn = default(System.DateTimeOffset?), System.BinaryData thumbprint = null, bool? isVerified = default(bool?), System.BinaryData certificate = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesNameAvailabilityResult DeviceProvisioningServicesNameAvailabilityResult(bool? isNameAvailable = default(bool?), Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesNameUnavailableReason? reason = default(Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesNameUnavailableReason?), string message = null) { throw null; }
        public static Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateEndpointConnectionData DeviceProvisioningServicesPrivateEndpointConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesPrivateEndpointConnectionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateLinkResourceData DeviceProvisioningServicesPrivateLinkResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesPrivateLinkResourceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesPrivateLinkResourceProperties DeviceProvisioningServicesPrivateLinkResourceProperties(string groupId = null, System.Collections.Generic.IEnumerable<string> requiredMembers = null, System.Collections.Generic.IEnumerable<string> requiredZoneNames = null) { throw null; }
        public static Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesSkuDefinition DeviceProvisioningServicesSkuDefinition(Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesSku? name = default(Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesSku?)) { throw null; }
        public static Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesSkuInfo DeviceProvisioningServicesSkuInfo(Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesSku? name = default(Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesSku?), string tier = null, long? capacity = default(long?)) { throw null; }
        public static Azure.ResourceManager.DeviceProvisioningServices.Models.IotHubDefinitionDescription IotHubDefinitionDescription(bool? applyAllocationPolicy = default(bool?), int? allocationWeight = default(int?), string name = null, string connectionString = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation)) { throw null; }
    }
    public partial class CertificateVerificationCodeContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceProvisioningServices.Models.CertificateVerificationCodeContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceProvisioningServices.Models.CertificateVerificationCodeContent>
    {
        public CertificateVerificationCodeContent() { }
        public string Certificate { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceProvisioningServices.Models.CertificateVerificationCodeContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceProvisioningServices.Models.CertificateVerificationCodeContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceProvisioningServices.Models.CertificateVerificationCodeContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceProvisioningServices.Models.CertificateVerificationCodeContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceProvisioningServices.Models.CertificateVerificationCodeContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceProvisioningServices.Models.CertificateVerificationCodeContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceProvisioningServices.Models.CertificateVerificationCodeContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CertificateVerificationCodeProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceProvisioningServices.Models.CertificateVerificationCodeProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceProvisioningServices.Models.CertificateVerificationCodeProperties>
    {
        internal CertificateVerificationCodeProperties() { }
        public System.BinaryData Certificate { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.DateTimeOffset? ExpireOn { get { throw null; } }
        public bool? IsVerified { get { throw null; } }
        public string Subject { get { throw null; } }
        public System.BinaryData Thumbprint { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
        public string VerificationCode { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceProvisioningServices.Models.CertificateVerificationCodeProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceProvisioningServices.Models.CertificateVerificationCodeProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceProvisioningServices.Models.CertificateVerificationCodeProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceProvisioningServices.Models.CertificateVerificationCodeProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceProvisioningServices.Models.CertificateVerificationCodeProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceProvisioningServices.Models.CertificateVerificationCodeProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceProvisioningServices.Models.CertificateVerificationCodeProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CertificateVerificationCodeResult : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceProvisioningServices.Models.CertificateVerificationCodeResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceProvisioningServices.Models.CertificateVerificationCodeResult>
    {
        internal CertificateVerificationCodeResult() { }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.DeviceProvisioningServices.Models.CertificateVerificationCodeProperties Properties { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceProvisioningServices.Models.CertificateVerificationCodeResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceProvisioningServices.Models.CertificateVerificationCodeResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceProvisioningServices.Models.CertificateVerificationCodeResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceProvisioningServices.Models.CertificateVerificationCodeResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceProvisioningServices.Models.CertificateVerificationCodeResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceProvisioningServices.Models.CertificateVerificationCodeResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceProvisioningServices.Models.CertificateVerificationCodeResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceProvisioningServicePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicePatch>
    {
        public DeviceProvisioningServicePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceProvisioningServiceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServiceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServiceProperties>
    {
        public DeviceProvisioningServiceProperties() { }
        public Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesAllocationPolicy? AllocationPolicy { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesSharedAccessKey> AuthorizationPolicies { get { throw null; } }
        public string DeviceProvisioningHostName { get { throw null; } }
        public Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceRegistryNamespaceDescription DeviceRegistryNamespace { get { throw null; } set { } }
        public string IdScope { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DeviceProvisioningServices.Models.IotHubDefinitionDescription> IotHubs { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesIPFilterRule> IPFilterRules { get { throw null; } }
        public bool? IsDataResidencyEnabled { get { throw null; } set { } }
        public string PortalOperationsHostName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public string ProvisioningState { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public string ServiceOperationsHostName { get { throw null; } }
        public Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesState? State { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServiceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServiceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServiceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServiceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServiceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServiceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServiceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeviceProvisioningServicesAccessKeyRight : System.IEquatable<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesAccessKeyRight>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeviceProvisioningServicesAccessKeyRight(string value) { throw null; }
        public static Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesAccessKeyRight DeviceConnect { get { throw null; } }
        public static Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesAccessKeyRight EnrollmentRead { get { throw null; } }
        public static Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesAccessKeyRight EnrollmentWrite { get { throw null; } }
        public static Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesAccessKeyRight RegistrationStatusRead { get { throw null; } }
        public static Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesAccessKeyRight RegistrationStatusWrite { get { throw null; } }
        public static Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesAccessKeyRight ServiceConfig { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesAccessKeyRight other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesAccessKeyRight left, Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesAccessKeyRight right) { throw null; }
        public static implicit operator Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesAccessKeyRight (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesAccessKeyRight left, Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesAccessKeyRight right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeviceProvisioningServicesAllocationPolicy : System.IEquatable<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesAllocationPolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeviceProvisioningServicesAllocationPolicy(string value) { throw null; }
        public static Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesAllocationPolicy GeoLatency { get { throw null; } }
        public static Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesAllocationPolicy Hashed { get { throw null; } }
        public static Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesAllocationPolicy Static { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesAllocationPolicy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesAllocationPolicy left, Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesAllocationPolicy right) { throw null; }
        public static implicit operator Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesAllocationPolicy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesAllocationPolicy left, Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesAllocationPolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DeviceProvisioningServicesCertificateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesCertificateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesCertificateProperties>
    {
        public DeviceProvisioningServicesCertificateProperties() { }
        public System.BinaryData Certificate { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.DateTimeOffset? ExpireOn { get { throw null; } }
        public bool? IsVerified { get { throw null; } set { } }
        public string Subject { get { throw null; } }
        public System.BinaryData Thumbprint { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesCertificateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesCertificateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesCertificateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesCertificateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesCertificateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesCertificateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesCertificateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeviceProvisioningServicesCertificatePurpose : System.IEquatable<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesCertificatePurpose>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeviceProvisioningServicesCertificatePurpose(string value) { throw null; }
        public static Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesCertificatePurpose ClientAuthentication { get { throw null; } }
        public static Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesCertificatePurpose ServerAuthentication { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesCertificatePurpose other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesCertificatePurpose left, Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesCertificatePurpose right) { throw null; }
        public static implicit operator Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesCertificatePurpose (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesCertificatePurpose left, Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesCertificatePurpose right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DeviceProvisioningServicesCertificateResourceDeleteOptions
    {
        public DeviceProvisioningServicesCertificateResourceDeleteOptions(string ifMatch) { }
        public string CertificateCommonName { get { throw null; } set { } }
        public System.DateTimeOffset? CertificateCreatedOn { get { throw null; } set { } }
        public bool? CertificateHasPrivateKey { get { throw null; } set { } }
        public bool? CertificateIsVerified { get { throw null; } set { } }
        public System.DateTimeOffset? CertificateLastUpdatedOn { get { throw null; } set { } }
        public string CertificateNonce { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesCertificatePurpose? CertificatePurpose { get { throw null; } set { } }
        public byte[] CertificateRawBytes { get { throw null; } set { } }
        public string IfMatch { get { throw null; } }
    }
    public partial class DeviceProvisioningServicesCertificateResourceGenerateVerificationCodeOptions
    {
        public DeviceProvisioningServicesCertificateResourceGenerateVerificationCodeOptions(string ifMatch) { }
        public string CertificateCommonName { get { throw null; } set { } }
        public System.DateTimeOffset? CertificateCreatedOn { get { throw null; } set { } }
        public bool? CertificateHasPrivateKey { get { throw null; } set { } }
        public bool? CertificateIsVerified { get { throw null; } set { } }
        public System.DateTimeOffset? CertificateLastUpdatedOn { get { throw null; } set { } }
        public string CertificateNonce { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesCertificatePurpose? CertificatePurpose { get { throw null; } set { } }
        public byte[] CertificateRawBytes { get { throw null; } set { } }
        public string IfMatch { get { throw null; } }
    }
    public partial class DeviceProvisioningServicesCertificateResourceVerifyCertificateOptions
    {
        public DeviceProvisioningServicesCertificateResourceVerifyCertificateOptions(string ifMatch, Azure.ResourceManager.DeviceProvisioningServices.Models.CertificateVerificationCodeContent content) { }
        public string CertificateCommonName { get { throw null; } set { } }
        public System.DateTimeOffset? CertificateCreatedOn { get { throw null; } set { } }
        public bool? CertificateHasPrivateKey { get { throw null; } set { } }
        public bool? CertificateIsVerified { get { throw null; } set { } }
        public System.DateTimeOffset? CertificateLastUpdatedOn { get { throw null; } set { } }
        public string CertificateNonce { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesCertificatePurpose? CertificatePurpose { get { throw null; } set { } }
        public byte[] CertificateRawBytes { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceProvisioningServices.Models.CertificateVerificationCodeContent Content { get { throw null; } }
        public string IfMatch { get { throw null; } }
    }
    public enum DeviceProvisioningServicesIPFilterActionType
    {
        Accept = 0,
        Reject = 1,
    }
    public partial class DeviceProvisioningServicesIPFilterRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesIPFilterRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesIPFilterRule>
    {
        public DeviceProvisioningServicesIPFilterRule(string filterName, Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesIPFilterActionType action, string ipMask) { }
        public Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesIPFilterActionType Action { get { throw null; } set { } }
        public string FilterName { get { throw null; } set { } }
        public string IPMask { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesIPFilterTargetType? Target { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesIPFilterRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesIPFilterRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesIPFilterRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesIPFilterRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesIPFilterRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesIPFilterRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesIPFilterRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum DeviceProvisioningServicesIPFilterTargetType
    {
        All = 0,
        ServiceApi = 1,
        DeviceApi = 2,
    }
    public partial class DeviceProvisioningServicesNameAvailabilityContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesNameAvailabilityContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesNameAvailabilityContent>
    {
        public DeviceProvisioningServicesNameAvailabilityContent(string name) { }
        public string Name { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesNameAvailabilityContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesNameAvailabilityContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesNameAvailabilityContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesNameAvailabilityContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesNameAvailabilityContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesNameAvailabilityContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesNameAvailabilityContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceProvisioningServicesNameAvailabilityResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesNameAvailabilityResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesNameAvailabilityResult>
    {
        internal DeviceProvisioningServicesNameAvailabilityResult() { }
        public bool? IsNameAvailable { get { throw null; } }
        public string Message { get { throw null; } }
        public Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesNameUnavailableReason? Reason { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesNameAvailabilityResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesNameAvailabilityResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesNameAvailabilityResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesNameAvailabilityResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesNameAvailabilityResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesNameAvailabilityResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesNameAvailabilityResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeviceProvisioningServicesNameUnavailableReason : System.IEquatable<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesNameUnavailableReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeviceProvisioningServicesNameUnavailableReason(string value) { throw null; }
        public static Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesNameUnavailableReason AlreadyExists { get { throw null; } }
        public static Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesNameUnavailableReason Invalid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesNameUnavailableReason other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesNameUnavailableReason left, Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesNameUnavailableReason right) { throw null; }
        public static implicit operator Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesNameUnavailableReason (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesNameUnavailableReason left, Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesNameUnavailableReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DeviceProvisioningServicesPrivateEndpointConnectionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesPrivateEndpointConnectionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesPrivateEndpointConnectionProperties>
    {
        public DeviceProvisioningServicesPrivateEndpointConnectionProperties(Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesPrivateLinkServiceConnectionState connectionState) { }
        public Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesPrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesPrivateEndpointConnectionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesPrivateEndpointConnectionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesPrivateEndpointConnectionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesPrivateEndpointConnectionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesPrivateEndpointConnectionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesPrivateEndpointConnectionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesPrivateEndpointConnectionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceProvisioningServicesPrivateLinkResourceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesPrivateLinkResourceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesPrivateLinkResourceProperties>
    {
        internal DeviceProvisioningServicesPrivateLinkResourceProperties() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredZoneNames { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesPrivateLinkResourceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesPrivateLinkResourceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesPrivateLinkResourceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesPrivateLinkResourceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesPrivateLinkResourceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesPrivateLinkResourceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesPrivateLinkResourceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceProvisioningServicesPrivateLinkServiceConnectionState : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesPrivateLinkServiceConnectionState>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesPrivateLinkServiceConnectionState>
    {
        public DeviceProvisioningServicesPrivateLinkServiceConnectionState(Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesPrivateLinkServiceConnectionStatus status, string description) { }
        public string ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesPrivateLinkServiceConnectionStatus Status { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesPrivateLinkServiceConnectionState System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesPrivateLinkServiceConnectionState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesPrivateLinkServiceConnectionState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesPrivateLinkServiceConnectionState System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesPrivateLinkServiceConnectionState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesPrivateLinkServiceConnectionState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesPrivateLinkServiceConnectionState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeviceProvisioningServicesPrivateLinkServiceConnectionStatus : System.IEquatable<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesPrivateLinkServiceConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeviceProvisioningServicesPrivateLinkServiceConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesPrivateLinkServiceConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesPrivateLinkServiceConnectionStatus Disconnected { get { throw null; } }
        public static Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesPrivateLinkServiceConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesPrivateLinkServiceConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesPrivateLinkServiceConnectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesPrivateLinkServiceConnectionStatus left, Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesPrivateLinkServiceConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesPrivateLinkServiceConnectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesPrivateLinkServiceConnectionStatus left, Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesPrivateLinkServiceConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeviceProvisioningServicesPublicNetworkAccess : System.IEquatable<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesPublicNetworkAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeviceProvisioningServicesPublicNetworkAccess(string value) { throw null; }
        public static Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesPublicNetworkAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesPublicNetworkAccess Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesPublicNetworkAccess other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesPublicNetworkAccess left, Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesPublicNetworkAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesPublicNetworkAccess (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesPublicNetworkAccess left, Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesPublicNetworkAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DeviceProvisioningServicesSharedAccessKey : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesSharedAccessKey>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesSharedAccessKey>
    {
        public DeviceProvisioningServicesSharedAccessKey(string keyName, Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesAccessKeyRight rights) { }
        public string KeyName { get { throw null; } set { } }
        public string PrimaryKey { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesAccessKeyRight Rights { get { throw null; } set { } }
        public string SecondaryKey { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesSharedAccessKey System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesSharedAccessKey>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesSharedAccessKey>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesSharedAccessKey System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesSharedAccessKey>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesSharedAccessKey>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesSharedAccessKey>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeviceProvisioningServicesSku : System.IEquatable<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesSku>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeviceProvisioningServicesSku(string value) { throw null; }
        public static Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesSku S1 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesSku other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesSku left, Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesSku right) { throw null; }
        public static implicit operator Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesSku (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesSku left, Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesSku right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DeviceProvisioningServicesSkuDefinition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesSkuDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesSkuDefinition>
    {
        internal DeviceProvisioningServicesSkuDefinition() { }
        public Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesSku? Name { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesSkuDefinition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesSkuDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesSkuDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesSkuDefinition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesSkuDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesSkuDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesSkuDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceProvisioningServicesSkuInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesSkuInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesSkuInfo>
    {
        public DeviceProvisioningServicesSkuInfo() { }
        public long? Capacity { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesSku? Name { get { throw null; } set { } }
        public string Tier { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesSkuInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesSkuInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesSkuInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesSkuInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesSkuInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesSkuInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesSkuInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeviceProvisioningServicesState : System.IEquatable<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeviceProvisioningServicesState(string value) { throw null; }
        public static Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesState Activating { get { throw null; } }
        public static Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesState ActivationFailed { get { throw null; } }
        public static Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesState Active { get { throw null; } }
        public static Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesState Deleted { get { throw null; } }
        public static Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesState Deleting { get { throw null; } }
        public static Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesState DeletionFailed { get { throw null; } }
        public static Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesState FailingOver { get { throw null; } }
        public static Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesState FailoverFailed { get { throw null; } }
        public static Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesState Resuming { get { throw null; } }
        public static Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesState Suspended { get { throw null; } }
        public static Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesState Suspending { get { throw null; } }
        public static Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesState Transitioning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesState left, Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesState left, Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeviceRegistryNamespaceAuthenticationType : System.IEquatable<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceRegistryNamespaceAuthenticationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeviceRegistryNamespaceAuthenticationType(string value) { throw null; }
        public static Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceRegistryNamespaceAuthenticationType SystemAssigned { get { throw null; } }
        public static Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceRegistryNamespaceAuthenticationType UserAssigned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceRegistryNamespaceAuthenticationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceRegistryNamespaceAuthenticationType left, Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceRegistryNamespaceAuthenticationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceRegistryNamespaceAuthenticationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceRegistryNamespaceAuthenticationType left, Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceRegistryNamespaceAuthenticationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DeviceRegistryNamespaceDescription : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceRegistryNamespaceDescription>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceRegistryNamespaceDescription>
    {
        public DeviceRegistryNamespaceDescription(Azure.Core.ResourceIdentifier resourceId, Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceRegistryNamespaceAuthenticationType authenticationType) { }
        public Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceRegistryNamespaceAuthenticationType AuthenticationType { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SelectedUserAssignedIdentityResourceId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceRegistryNamespaceDescription System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceRegistryNamespaceDescription>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceRegistryNamespaceDescription>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceRegistryNamespaceDescription System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceRegistryNamespaceDescription>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceRegistryNamespaceDescription>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceRegistryNamespaceDescription>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IotHubDefinitionDescription : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceProvisioningServices.Models.IotHubDefinitionDescription>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceProvisioningServices.Models.IotHubDefinitionDescription>
    {
        public IotHubDefinitionDescription(Azure.Core.AzureLocation location) { }
        public IotHubDefinitionDescription(string connectionString, Azure.Core.AzureLocation location) { }
        public int? AllocationWeight { get { throw null; } set { } }
        public bool? ApplyAllocationPolicy { get { throw null; } set { } }
        public string ConnectionString { get { throw null; } set { } }
        public Azure.Core.AzureLocation Location { get { throw null; } set { } }
        public string Name { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceProvisioningServices.Models.IotHubDefinitionDescription System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceProvisioningServices.Models.IotHubDefinitionDescription>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceProvisioningServices.Models.IotHubDefinitionDescription>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceProvisioningServices.Models.IotHubDefinitionDescription System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceProvisioningServices.Models.IotHubDefinitionDescription>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceProvisioningServices.Models.IotHubDefinitionDescription>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceProvisioningServices.Models.IotHubDefinitionDescription>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
