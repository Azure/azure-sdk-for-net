namespace Azure.ResourceManager.DeviceProvisioningServices
{
    public partial class CertificateResponseCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeviceProvisioningServices.CertificateResponseResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceProvisioningServices.CertificateResponseResource>, System.Collections.IEnumerable
    {
        protected CertificateResponseCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceProvisioningServices.CertificateResponseResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string certificateName, Azure.ResourceManager.DeviceProvisioningServices.CertificateResponseData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceProvisioningServices.CertificateResponseResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string certificateName, Azure.ResourceManager.DeviceProvisioningServices.CertificateResponseData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string certificateName, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string certificateName, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceProvisioningServices.CertificateResponseResource> Get(string certificateName, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DeviceProvisioningServices.CertificateResponseResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DeviceProvisioningServices.CertificateResponseResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceProvisioningServices.CertificateResponseResource>> GetAsync(string certificateName, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DeviceProvisioningServices.CertificateResponseResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeviceProvisioningServices.CertificateResponseResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DeviceProvisioningServices.CertificateResponseResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceProvisioningServices.CertificateResponseResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CertificateResponseData : Azure.ResourceManager.Models.ResourceData
    {
        public CertificateResponseData() { }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.DeviceProvisioningServices.Models.CertificateProperties Properties { get { throw null; } set { } }
    }
    public partial class CertificateResponseResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CertificateResponseResource() { }
        public virtual Azure.ResourceManager.DeviceProvisioningServices.CertificateResponseData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string provisioningServiceName, string certificateName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string ifMatch, string certificateName1 = null, byte[] certificateRawBytes = null, bool? certificateIsVerified = default(bool?), Azure.ResourceManager.DeviceProvisioningServices.Models.CertificatePurpose? certificatePurpose = default(Azure.ResourceManager.DeviceProvisioningServices.Models.CertificatePurpose?), System.DateTimeOffset? certificateCreated = default(System.DateTimeOffset?), System.DateTimeOffset? certificateLastUpdated = default(System.DateTimeOffset?), bool? certificateHasPrivateKey = default(bool?), string certificateNonce = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch, string certificateName1 = null, byte[] certificateRawBytes = null, bool? certificateIsVerified = default(bool?), Azure.ResourceManager.DeviceProvisioningServices.Models.CertificatePurpose? certificatePurpose = default(Azure.ResourceManager.DeviceProvisioningServices.Models.CertificatePurpose?), System.DateTimeOffset? certificateCreated = default(System.DateTimeOffset?), System.DateTimeOffset? certificateLastUpdated = default(System.DateTimeOffset?), bool? certificateHasPrivateKey = default(bool?), string certificateNonce = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceProvisioningServices.Models.VerificationCodeResponse> GenerateVerificationCode(string ifMatch, string certificateName1 = null, byte[] certificateRawBytes = null, bool? certificateIsVerified = default(bool?), Azure.ResourceManager.DeviceProvisioningServices.Models.CertificatePurpose? certificatePurpose = default(Azure.ResourceManager.DeviceProvisioningServices.Models.CertificatePurpose?), System.DateTimeOffset? certificateCreated = default(System.DateTimeOffset?), System.DateTimeOffset? certificateLastUpdated = default(System.DateTimeOffset?), bool? certificateHasPrivateKey = default(bool?), string certificateNonce = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceProvisioningServices.Models.VerificationCodeResponse>> GenerateVerificationCodeAsync(string ifMatch, string certificateName1 = null, byte[] certificateRawBytes = null, bool? certificateIsVerified = default(bool?), Azure.ResourceManager.DeviceProvisioningServices.Models.CertificatePurpose? certificatePurpose = default(Azure.ResourceManager.DeviceProvisioningServices.Models.CertificatePurpose?), System.DateTimeOffset? certificateCreated = default(System.DateTimeOffset?), System.DateTimeOffset? certificateLastUpdated = default(System.DateTimeOffset?), bool? certificateHasPrivateKey = default(bool?), string certificateNonce = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceProvisioningServices.CertificateResponseResource> Get(string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceProvisioningServices.CertificateResponseResource>> GetAsync(string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceProvisioningServices.CertificateResponseResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DeviceProvisioningServices.CertificateResponseData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceProvisioningServices.CertificateResponseResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DeviceProvisioningServices.CertificateResponseData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceProvisioningServices.CertificateResponseResource> VerifyCertificate(string ifMatch, Azure.ResourceManager.DeviceProvisioningServices.Models.VerificationCodeContent content, string certificateName1 = null, byte[] certificateRawBytes = null, bool? certificateIsVerified = default(bool?), Azure.ResourceManager.DeviceProvisioningServices.Models.CertificatePurpose? certificatePurpose = default(Azure.ResourceManager.DeviceProvisioningServices.Models.CertificatePurpose?), System.DateTimeOffset? certificateCreated = default(System.DateTimeOffset?), System.DateTimeOffset? certificateLastUpdated = default(System.DateTimeOffset?), bool? certificateHasPrivateKey = default(bool?), string certificateNonce = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceProvisioningServices.CertificateResponseResource>> VerifyCertificateAsync(string ifMatch, Azure.ResourceManager.DeviceProvisioningServices.Models.VerificationCodeContent content, string certificateName1 = null, byte[] certificateRawBytes = null, bool? certificateIsVerified = default(bool?), Azure.ResourceManager.DeviceProvisioningServices.Models.CertificatePurpose? certificatePurpose = default(Azure.ResourceManager.DeviceProvisioningServices.Models.CertificatePurpose?), System.DateTimeOffset? certificateCreated = default(System.DateTimeOffset?), System.DateTimeOffset? certificateLastUpdated = default(System.DateTimeOffset?), bool? certificateHasPrivateKey = default(bool?), string certificateNonce = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class DeviceProvisioningServicesExtensions
    {
        public static Azure.Response<Azure.ResourceManager.DeviceProvisioningServices.Models.NameAvailabilityInfo> CheckProvisioningServiceNameAvailabilityIotDpsResource(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.DeviceProvisioningServices.Models.OperationInputs arguments, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceProvisioningServices.Models.NameAvailabilityInfo>> CheckProvisioningServiceNameAvailabilityIotDpsResourceAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.DeviceProvisioningServices.Models.OperationInputs arguments, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DeviceProvisioningServices.CertificateResponseResource GetCertificateResponseResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateEndpointConnectionResource GetDeviceProvisioningServicesPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DeviceProvisioningServices.GroupIdInformationResource GetGroupIdInformationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DeviceProvisioningServices.ProvisioningServiceDescriptionResource> GetProvisioningServiceDescription(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string provisioningServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceProvisioningServices.ProvisioningServiceDescriptionResource>> GetProvisioningServiceDescriptionAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string provisioningServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DeviceProvisioningServices.ProvisioningServiceDescriptionResource GetProvisioningServiceDescriptionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DeviceProvisioningServices.ProvisioningServiceDescriptionCollection GetProvisioningServiceDescriptions(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DeviceProvisioningServices.ProvisioningServiceDescriptionResource> GetProvisioningServiceDescriptions(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DeviceProvisioningServices.ProvisioningServiceDescriptionResource> GetProvisioningServiceDescriptionsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public DeviceProvisioningServicesPrivateEndpointConnectionData(Azure.ResourceManager.DeviceProvisioningServices.Models.PrivateEndpointConnectionProperties properties) { }
        public Azure.ResourceManager.DeviceProvisioningServices.Models.PrivateEndpointConnectionProperties Properties { get { throw null; } set { } }
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
    public partial class GroupIdInformationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeviceProvisioningServices.GroupIdInformationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceProvisioningServices.GroupIdInformationResource>, System.Collections.IEnumerable
    {
        protected GroupIdInformationCollection() { }
        public virtual Azure.Response<bool> Exists(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceProvisioningServices.GroupIdInformationResource> Get(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DeviceProvisioningServices.GroupIdInformationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DeviceProvisioningServices.GroupIdInformationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceProvisioningServices.GroupIdInformationResource>> GetAsync(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DeviceProvisioningServices.GroupIdInformationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeviceProvisioningServices.GroupIdInformationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DeviceProvisioningServices.GroupIdInformationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceProvisioningServices.GroupIdInformationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class GroupIdInformationData : Azure.ResourceManager.Models.ResourceData
    {
        internal GroupIdInformationData() { }
        public Azure.ResourceManager.DeviceProvisioningServices.Models.GroupIdInformationProperties Properties { get { throw null; } }
    }
    public partial class GroupIdInformationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected GroupIdInformationResource() { }
        public virtual Azure.ResourceManager.DeviceProvisioningServices.GroupIdInformationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string groupId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceProvisioningServices.GroupIdInformationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceProvisioningServices.GroupIdInformationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ProvisioningServiceDescriptionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeviceProvisioningServices.ProvisioningServiceDescriptionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceProvisioningServices.ProvisioningServiceDescriptionResource>, System.Collections.IEnumerable
    {
        protected ProvisioningServiceDescriptionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceProvisioningServices.ProvisioningServiceDescriptionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string provisioningServiceName, Azure.ResourceManager.DeviceProvisioningServices.ProvisioningServiceDescriptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceProvisioningServices.ProvisioningServiceDescriptionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string provisioningServiceName, Azure.ResourceManager.DeviceProvisioningServices.ProvisioningServiceDescriptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string provisioningServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string provisioningServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceProvisioningServices.ProvisioningServiceDescriptionResource> Get(string provisioningServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DeviceProvisioningServices.ProvisioningServiceDescriptionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DeviceProvisioningServices.ProvisioningServiceDescriptionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceProvisioningServices.ProvisioningServiceDescriptionResource>> GetAsync(string provisioningServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DeviceProvisioningServices.ProvisioningServiceDescriptionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeviceProvisioningServices.ProvisioningServiceDescriptionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DeviceProvisioningServices.ProvisioningServiceDescriptionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceProvisioningServices.ProvisioningServiceDescriptionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ProvisioningServiceDescriptionData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ProvisioningServiceDescriptionData(Azure.Core.AzureLocation location, Azure.ResourceManager.DeviceProvisioningServices.Models.IotDpsPropertiesDescription properties, Azure.ResourceManager.DeviceProvisioningServices.Models.IotDpsSkuInfo sku) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceProvisioningServices.Models.IotDpsPropertiesDescription Properties { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceProvisioningServices.Models.IotDpsSkuInfo Sku { get { throw null; } set { } }
    }
    public partial class ProvisioningServiceDescriptionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ProvisioningServiceDescriptionResource() { }
        public virtual Azure.ResourceManager.DeviceProvisioningServices.ProvisioningServiceDescriptionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DeviceProvisioningServices.ProvisioningServiceDescriptionResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceProvisioningServices.ProvisioningServiceDescriptionResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string provisioningServiceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceProvisioningServices.ProvisioningServiceDescriptionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DeviceProvisioningServices.GroupIdInformationCollection GetAllGroupIdInformation() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceProvisioningServices.ProvisioningServiceDescriptionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceProvisioningServices.CertificateResponseResource> GetCertificateResponse(string certificateName, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceProvisioningServices.CertificateResponseResource>> GetCertificateResponseAsync(string certificateName, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DeviceProvisioningServices.CertificateResponseCollection GetCertificateResponses() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateEndpointConnectionResource> GetDeviceProvisioningServicesPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateEndpointConnectionResource>> GetDeviceProvisioningServicesPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateEndpointConnectionCollection GetDeviceProvisioningServicesPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceProvisioningServices.GroupIdInformationResource> GetGroupIdInformation(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceProvisioningServices.GroupIdInformationResource>> GetGroupIdInformationAsync(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DeviceProvisioningServices.Models.SharedAccessSignatureAuthorizationRuleAccessRightsDescription> GetKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DeviceProvisioningServices.Models.SharedAccessSignatureAuthorizationRuleAccessRightsDescription> GetKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceProvisioningServices.Models.SharedAccessSignatureAuthorizationRuleAccessRightsDescription> GetKeysForKeyName(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceProvisioningServices.Models.SharedAccessSignatureAuthorizationRuleAccessRightsDescription>> GetKeysForKeyNameAsync(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceProvisioningServices.Models.AsyncOperationResult> GetOperationResult(string operationId, string asyncinfo, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceProvisioningServices.Models.AsyncOperationResult>> GetOperationResultAsync(string operationId, string asyncinfo, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DeviceProvisioningServices.Models.IotDpsSkuDefinition> GetValidSkus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DeviceProvisioningServices.Models.IotDpsSkuDefinition> GetValidSkusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceProvisioningServices.ProvisioningServiceDescriptionResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceProvisioningServices.ProvisioningServiceDescriptionResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceProvisioningServices.ProvisioningServiceDescriptionResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceProvisioningServices.ProvisioningServiceDescriptionResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceProvisioningServices.ProvisioningServiceDescriptionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DeviceProvisioningServices.Models.ProvisioningServiceDescriptionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceProvisioningServices.ProvisioningServiceDescriptionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DeviceProvisioningServices.Models.ProvisioningServiceDescriptionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.DeviceProvisioningServices.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AccessRightsDescription : System.IEquatable<Azure.ResourceManager.DeviceProvisioningServices.Models.AccessRightsDescription>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AccessRightsDescription(string value) { throw null; }
        public static Azure.ResourceManager.DeviceProvisioningServices.Models.AccessRightsDescription DeviceConnect { get { throw null; } }
        public static Azure.ResourceManager.DeviceProvisioningServices.Models.AccessRightsDescription EnrollmentRead { get { throw null; } }
        public static Azure.ResourceManager.DeviceProvisioningServices.Models.AccessRightsDescription EnrollmentWrite { get { throw null; } }
        public static Azure.ResourceManager.DeviceProvisioningServices.Models.AccessRightsDescription RegistrationStatusRead { get { throw null; } }
        public static Azure.ResourceManager.DeviceProvisioningServices.Models.AccessRightsDescription RegistrationStatusWrite { get { throw null; } }
        public static Azure.ResourceManager.DeviceProvisioningServices.Models.AccessRightsDescription ServiceConfig { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DeviceProvisioningServices.Models.AccessRightsDescription other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DeviceProvisioningServices.Models.AccessRightsDescription left, Azure.ResourceManager.DeviceProvisioningServices.Models.AccessRightsDescription right) { throw null; }
        public static implicit operator Azure.ResourceManager.DeviceProvisioningServices.Models.AccessRightsDescription (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DeviceProvisioningServices.Models.AccessRightsDescription left, Azure.ResourceManager.DeviceProvisioningServices.Models.AccessRightsDescription right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AllocationPolicy : System.IEquatable<Azure.ResourceManager.DeviceProvisioningServices.Models.AllocationPolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AllocationPolicy(string value) { throw null; }
        public static Azure.ResourceManager.DeviceProvisioningServices.Models.AllocationPolicy GeoLatency { get { throw null; } }
        public static Azure.ResourceManager.DeviceProvisioningServices.Models.AllocationPolicy Hashed { get { throw null; } }
        public static Azure.ResourceManager.DeviceProvisioningServices.Models.AllocationPolicy Static { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DeviceProvisioningServices.Models.AllocationPolicy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DeviceProvisioningServices.Models.AllocationPolicy left, Azure.ResourceManager.DeviceProvisioningServices.Models.AllocationPolicy right) { throw null; }
        public static implicit operator Azure.ResourceManager.DeviceProvisioningServices.Models.AllocationPolicy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DeviceProvisioningServices.Models.AllocationPolicy left, Azure.ResourceManager.DeviceProvisioningServices.Models.AllocationPolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AsyncOperationResult
    {
        internal AsyncOperationResult() { }
        public Azure.ResourceManager.DeviceProvisioningServices.Models.ErrorMessage Error { get { throw null; } }
        public string Status { get { throw null; } }
    }
    public partial class CertificateProperties
    {
        public CertificateProperties() { }
        public byte[] Certificate { get { throw null; } set { } }
        public System.DateTimeOffset? Created { get { throw null; } }
        public System.DateTimeOffset? Expiry { get { throw null; } }
        public bool? IsVerified { get { throw null; } set { } }
        public string Subject { get { throw null; } }
        public string Thumbprint { get { throw null; } }
        public System.DateTimeOffset? Updated { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CertificatePurpose : System.IEquatable<Azure.ResourceManager.DeviceProvisioningServices.Models.CertificatePurpose>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CertificatePurpose(string value) { throw null; }
        public static Azure.ResourceManager.DeviceProvisioningServices.Models.CertificatePurpose ClientAuthentication { get { throw null; } }
        public static Azure.ResourceManager.DeviceProvisioningServices.Models.CertificatePurpose ServerAuthentication { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DeviceProvisioningServices.Models.CertificatePurpose other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DeviceProvisioningServices.Models.CertificatePurpose left, Azure.ResourceManager.DeviceProvisioningServices.Models.CertificatePurpose right) { throw null; }
        public static implicit operator Azure.ResourceManager.DeviceProvisioningServices.Models.CertificatePurpose (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DeviceProvisioningServices.Models.CertificatePurpose left, Azure.ResourceManager.DeviceProvisioningServices.Models.CertificatePurpose right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DeviceProvisioningServicesPrivateLinkServiceConnectionState
    {
        public DeviceProvisioningServicesPrivateLinkServiceConnectionState(Azure.ResourceManager.DeviceProvisioningServices.Models.PrivateLinkServiceConnectionStatus status, string description) { }
        public string ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceProvisioningServices.Models.PrivateLinkServiceConnectionStatus Status { get { throw null; } set { } }
    }
    public partial class ErrorMessage
    {
        internal ErrorMessage() { }
        public string Code { get { throw null; } }
        public string Details { get { throw null; } }
        public string Message { get { throw null; } }
    }
    public partial class GroupIdInformationProperties
    {
        internal GroupIdInformationProperties() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredZoneNames { get { throw null; } }
    }
    public partial class IotDpsPropertiesDescription
    {
        public IotDpsPropertiesDescription() { }
        public Azure.ResourceManager.DeviceProvisioningServices.Models.AllocationPolicy? AllocationPolicy { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DeviceProvisioningServices.Models.SharedAccessSignatureAuthorizationRuleAccessRightsDescription> AuthorizationPolicies { get { throw null; } }
        public string DeviceProvisioningHostName { get { throw null; } }
        public bool? EnableDataResidency { get { throw null; } set { } }
        public string IdScope { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DeviceProvisioningServices.Models.IotHubDefinitionDescription> IotHubs { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DeviceProvisioningServices.Models.IPFilterRule> IPFilterRules { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DeviceProvisioningServices.DeviceProvisioningServicesPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public string ProvisioningState { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceProvisioningServices.Models.PublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public string ServiceOperationsHostName { get { throw null; } }
        public Azure.ResourceManager.DeviceProvisioningServices.Models.State? State { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IotDpsSku : System.IEquatable<Azure.ResourceManager.DeviceProvisioningServices.Models.IotDpsSku>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IotDpsSku(string value) { throw null; }
        public static Azure.ResourceManager.DeviceProvisioningServices.Models.IotDpsSku S1 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DeviceProvisioningServices.Models.IotDpsSku other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DeviceProvisioningServices.Models.IotDpsSku left, Azure.ResourceManager.DeviceProvisioningServices.Models.IotDpsSku right) { throw null; }
        public static implicit operator Azure.ResourceManager.DeviceProvisioningServices.Models.IotDpsSku (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DeviceProvisioningServices.Models.IotDpsSku left, Azure.ResourceManager.DeviceProvisioningServices.Models.IotDpsSku right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IotDpsSkuDefinition
    {
        internal IotDpsSkuDefinition() { }
        public Azure.ResourceManager.DeviceProvisioningServices.Models.IotDpsSku? Name { get { throw null; } }
    }
    public partial class IotDpsSkuInfo
    {
        public IotDpsSkuInfo() { }
        public long? Capacity { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceProvisioningServices.Models.IotDpsSku? Name { get { throw null; } set { } }
        public string Tier { get { throw null; } }
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
    public enum IPFilterActionType
    {
        Accept = 0,
        Reject = 1,
    }
    public partial class IPFilterRule
    {
        public IPFilterRule(string filterName, Azure.ResourceManager.DeviceProvisioningServices.Models.IPFilterActionType action, string ipMask) { }
        public Azure.ResourceManager.DeviceProvisioningServices.Models.IPFilterActionType Action { get { throw null; } set { } }
        public string FilterName { get { throw null; } set { } }
        public string IPMask { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceProvisioningServices.Models.IPFilterTargetType? Target { get { throw null; } set { } }
    }
    public enum IPFilterTargetType
    {
        All = 0,
        ServiceApi = 1,
        DeviceApi = 2,
    }
    public partial class NameAvailabilityInfo
    {
        internal NameAvailabilityInfo() { }
        public string Message { get { throw null; } }
        public bool? NameAvailable { get { throw null; } }
        public Azure.ResourceManager.DeviceProvisioningServices.Models.NameUnavailabilityReason? Reason { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NameUnavailabilityReason : System.IEquatable<Azure.ResourceManager.DeviceProvisioningServices.Models.NameUnavailabilityReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NameUnavailabilityReason(string value) { throw null; }
        public static Azure.ResourceManager.DeviceProvisioningServices.Models.NameUnavailabilityReason AlreadyExists { get { throw null; } }
        public static Azure.ResourceManager.DeviceProvisioningServices.Models.NameUnavailabilityReason Invalid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DeviceProvisioningServices.Models.NameUnavailabilityReason other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DeviceProvisioningServices.Models.NameUnavailabilityReason left, Azure.ResourceManager.DeviceProvisioningServices.Models.NameUnavailabilityReason right) { throw null; }
        public static implicit operator Azure.ResourceManager.DeviceProvisioningServices.Models.NameUnavailabilityReason (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DeviceProvisioningServices.Models.NameUnavailabilityReason left, Azure.ResourceManager.DeviceProvisioningServices.Models.NameUnavailabilityReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OperationInputs
    {
        public OperationInputs(string name) { }
        public string Name { get { throw null; } }
    }
    public partial class PrivateEndpointConnectionProperties
    {
        public PrivateEndpointConnectionProperties(Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesPrivateLinkServiceConnectionState connectionState) { }
        public Azure.ResourceManager.DeviceProvisioningServices.Models.DeviceProvisioningServicesPrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PrivateLinkServiceConnectionStatus : System.IEquatable<Azure.ResourceManager.DeviceProvisioningServices.Models.PrivateLinkServiceConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PrivateLinkServiceConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.DeviceProvisioningServices.Models.PrivateLinkServiceConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.DeviceProvisioningServices.Models.PrivateLinkServiceConnectionStatus Disconnected { get { throw null; } }
        public static Azure.ResourceManager.DeviceProvisioningServices.Models.PrivateLinkServiceConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.DeviceProvisioningServices.Models.PrivateLinkServiceConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DeviceProvisioningServices.Models.PrivateLinkServiceConnectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DeviceProvisioningServices.Models.PrivateLinkServiceConnectionStatus left, Azure.ResourceManager.DeviceProvisioningServices.Models.PrivateLinkServiceConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DeviceProvisioningServices.Models.PrivateLinkServiceConnectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DeviceProvisioningServices.Models.PrivateLinkServiceConnectionStatus left, Azure.ResourceManager.DeviceProvisioningServices.Models.PrivateLinkServiceConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ProvisioningServiceDescriptionPatch
    {
        public ProvisioningServiceDescriptionPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PublicNetworkAccess : System.IEquatable<Azure.ResourceManager.DeviceProvisioningServices.Models.PublicNetworkAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PublicNetworkAccess(string value) { throw null; }
        public static Azure.ResourceManager.DeviceProvisioningServices.Models.PublicNetworkAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.DeviceProvisioningServices.Models.PublicNetworkAccess Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DeviceProvisioningServices.Models.PublicNetworkAccess other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DeviceProvisioningServices.Models.PublicNetworkAccess left, Azure.ResourceManager.DeviceProvisioningServices.Models.PublicNetworkAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.DeviceProvisioningServices.Models.PublicNetworkAccess (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DeviceProvisioningServices.Models.PublicNetworkAccess left, Azure.ResourceManager.DeviceProvisioningServices.Models.PublicNetworkAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SharedAccessSignatureAuthorizationRuleAccessRightsDescription
    {
        public SharedAccessSignatureAuthorizationRuleAccessRightsDescription(string keyName, Azure.ResourceManager.DeviceProvisioningServices.Models.AccessRightsDescription rights) { }
        public string KeyName { get { throw null; } set { } }
        public string PrimaryKey { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceProvisioningServices.Models.AccessRightsDescription Rights { get { throw null; } set { } }
        public string SecondaryKey { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct State : System.IEquatable<Azure.ResourceManager.DeviceProvisioningServices.Models.State>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public State(string value) { throw null; }
        public static Azure.ResourceManager.DeviceProvisioningServices.Models.State Activating { get { throw null; } }
        public static Azure.ResourceManager.DeviceProvisioningServices.Models.State ActivationFailed { get { throw null; } }
        public static Azure.ResourceManager.DeviceProvisioningServices.Models.State Active { get { throw null; } }
        public static Azure.ResourceManager.DeviceProvisioningServices.Models.State Deleted { get { throw null; } }
        public static Azure.ResourceManager.DeviceProvisioningServices.Models.State Deleting { get { throw null; } }
        public static Azure.ResourceManager.DeviceProvisioningServices.Models.State DeletionFailed { get { throw null; } }
        public static Azure.ResourceManager.DeviceProvisioningServices.Models.State FailingOver { get { throw null; } }
        public static Azure.ResourceManager.DeviceProvisioningServices.Models.State FailoverFailed { get { throw null; } }
        public static Azure.ResourceManager.DeviceProvisioningServices.Models.State Resuming { get { throw null; } }
        public static Azure.ResourceManager.DeviceProvisioningServices.Models.State Suspended { get { throw null; } }
        public static Azure.ResourceManager.DeviceProvisioningServices.Models.State Suspending { get { throw null; } }
        public static Azure.ResourceManager.DeviceProvisioningServices.Models.State Transitioning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DeviceProvisioningServices.Models.State other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DeviceProvisioningServices.Models.State left, Azure.ResourceManager.DeviceProvisioningServices.Models.State right) { throw null; }
        public static implicit operator Azure.ResourceManager.DeviceProvisioningServices.Models.State (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DeviceProvisioningServices.Models.State left, Azure.ResourceManager.DeviceProvisioningServices.Models.State right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VerificationCodeContent
    {
        public VerificationCodeContent() { }
        public string Certificate { get { throw null; } set { } }
    }
    public partial class VerificationCodeResponse : Azure.ResourceManager.Models.ResourceData
    {
        internal VerificationCodeResponse() { }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.DeviceProvisioningServices.Models.VerificationCodeResponseProperties Properties { get { throw null; } }
    }
    public partial class VerificationCodeResponseProperties
    {
        internal VerificationCodeResponseProperties() { }
        public byte[] Certificate { get { throw null; } }
        public string Created { get { throw null; } }
        public string Expiry { get { throw null; } }
        public bool? IsVerified { get { throw null; } }
        public string Subject { get { throw null; } }
        public string Thumbprint { get { throw null; } }
        public string Updated { get { throw null; } }
        public string VerificationCode { get { throw null; } }
    }
}
