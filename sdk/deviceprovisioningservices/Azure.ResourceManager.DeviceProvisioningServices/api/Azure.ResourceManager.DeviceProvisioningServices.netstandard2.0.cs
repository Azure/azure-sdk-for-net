namespace Azure.ResourceManager.DeviceProvisioningServices
{
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
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServiceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServiceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServiceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServiceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DeviceProvisioningServiceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public DeviceProvisioningServiceData(Azure.Core.AzureLocation location, Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServiceProperties properties, Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesSkuInfo sku) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServiceProperties Properties { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesSkuInfo Sku { get { throw null; } set { } }
    }
    public partial class DeviceProvisioningServiceResource : Azure.ResourceManager.ArmResource
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
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesCertificateResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesCertificateResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesCertificateResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesCertificateResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DeviceProvisioningServicesCertificateData : Azure.ResourceManager.Models.ResourceData
    {
        public DeviceProvisioningServicesCertificateData() { }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesCertificateProperties Properties { get { throw null; } set { } }
    }
    public partial class DeviceProvisioningServicesCertificateResource : Azure.ResourceManager.ArmResource
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
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DeviceProvisioningServicesPrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData
    {
        public DeviceProvisioningServicesPrivateEndpointConnectionData(Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesPrivateEndpointConnectionProperties properties) { }
        public Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesPrivateEndpointConnectionProperties Properties { get { throw null; } set { } }
    }
    public partial class DeviceProvisioningServicesPrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource
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
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeviceProvisioningServicesPrivateLinkResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DeviceProvisioningServicesPrivateLinkResource() { }
        public virtual Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateLinkResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string groupId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DeviceProvisioningServicesPrivateLinkResourceData : Azure.ResourceManager.Models.ResourceData
    {
        internal DeviceProvisioningServicesPrivateLinkResourceData() { }
        public Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesPrivateLinkResourceProperties Properties { get { throw null; } }
    }
}
namespace Azure.ResourceManager.DeviceProvisioningServices.Models
{
    public partial class CertificateVerificationCodeContent
    {
        public CertificateVerificationCodeContent() { }
        public string Certificate { get { throw null; } set { } }
    }
    public partial class CertificateVerificationCodeProperties
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
    }
    public partial class CertificateVerificationCodeResult : Azure.ResourceManager.Models.ResourceData
    {
        internal CertificateVerificationCodeResult() { }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.DeviceProvisioningServices.Models.CertificateVerificationCodeProperties Properties { get { throw null; } }
    }
    public partial class DeviceProvisioningServicePatch
    {
        public DeviceProvisioningServicePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class DeviceProvisioningServiceProperties
    {
        public DeviceProvisioningServiceProperties() { }
        public Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesAllocationPolicy? AllocationPolicy { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesSharedAccessKey> AuthorizationPolicies { get { throw null; } }
        public string DeviceProvisioningHostName { get { throw null; } }
        public string IdScope { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DeviceProvisioningServices.Models.IotHubDefinitionDescription> IotHubs { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesIPFilterRule> IPFilterRules { get { throw null; } }
        public bool? IsDataResidencyEnabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public string ProvisioningState { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public string ServiceOperationsHostName { get { throw null; } }
        public Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesState? State { get { throw null; } set { } }
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
    public partial class DeviceProvisioningServicesCertificateProperties
    {
        public DeviceProvisioningServicesCertificateProperties() { }
        public System.BinaryData Certificate { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.DateTimeOffset? ExpireOn { get { throw null; } }
        public bool? IsVerified { get { throw null; } set { } }
        public string Subject { get { throw null; } }
        public System.BinaryData Thumbprint { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
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
    public partial class DeviceProvisioningServicesIPFilterRule
    {
        public DeviceProvisioningServicesIPFilterRule(string filterName, Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesIPFilterActionType action, string ipMask) { }
        public Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesIPFilterActionType Action { get { throw null; } set { } }
        public string FilterName { get { throw null; } set { } }
        public string IPMask { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesIPFilterTargetType? Target { get { throw null; } set { } }
    }
    public enum DeviceProvisioningServicesIPFilterTargetType
    {
        All = 0,
        ServiceApi = 1,
        DeviceApi = 2,
    }
    public partial class DeviceProvisioningServicesNameAvailabilityContent
    {
        public DeviceProvisioningServicesNameAvailabilityContent(string name) { }
        public string Name { get { throw null; } }
    }
    public partial class DeviceProvisioningServicesNameAvailabilityResult
    {
        internal DeviceProvisioningServicesNameAvailabilityResult() { }
        public bool? IsNameAvailable { get { throw null; } }
        public string Message { get { throw null; } }
        public Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesNameUnavailableReason? Reason { get { throw null; } }
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
    public partial class DeviceProvisioningServicesPrivateEndpointConnectionProperties
    {
        public DeviceProvisioningServicesPrivateEndpointConnectionProperties(Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesPrivateLinkServiceConnectionState connectionState) { }
        public Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesPrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
    }
    public partial class DeviceProvisioningServicesPrivateLinkResourceProperties
    {
        internal DeviceProvisioningServicesPrivateLinkResourceProperties() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredZoneNames { get { throw null; } }
    }
    public partial class DeviceProvisioningServicesPrivateLinkServiceConnectionState
    {
        public DeviceProvisioningServicesPrivateLinkServiceConnectionState(Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesPrivateLinkServiceConnectionStatus status, string description) { }
        public string ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesPrivateLinkServiceConnectionStatus Status { get { throw null; } set { } }
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
    public partial class DeviceProvisioningServicesSharedAccessKey
    {
        public DeviceProvisioningServicesSharedAccessKey(string keyName, Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesAccessKeyRight rights) { }
        public string KeyName { get { throw null; } set { } }
        public string PrimaryKey { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesAccessKeyRight Rights { get { throw null; } set { } }
        public string SecondaryKey { get { throw null; } set { } }
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
    public partial class DeviceProvisioningServicesSkuDefinition
    {
        internal DeviceProvisioningServicesSkuDefinition() { }
        public Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesSku? Name { get { throw null; } }
    }
    public partial class DeviceProvisioningServicesSkuInfo
    {
        public DeviceProvisioningServicesSkuInfo() { }
        public long? Capacity { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesSku? Name { get { throw null; } set { } }
        public string Tier { get { throw null; } }
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
    public partial class IotHubDefinitionDescription
    {
        public IotHubDefinitionDescription(string connectionString, Azure.Core.AzureLocation location) { }
        public int? AllocationWeight { get { throw null; } set { } }
        public bool? ApplyAllocationPolicy { get { throw null; } set { } }
        public string ConnectionString { get { throw null; } set { } }
        public Azure.Core.AzureLocation Location { get { throw null; } set { } }
        public string Name { get { throw null; } }
    }
}
