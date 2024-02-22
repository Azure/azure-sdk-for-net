namespace Azure.ResourceManager.SignalR
{
    public partial class SignalRCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SignalR.SignalRResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SignalR.SignalRResource>, System.Collections.IEnumerable
    {
        protected SignalRCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SignalR.SignalRResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string resourceName, Azure.ResourceManager.SignalR.SignalRData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SignalR.SignalRResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string resourceName, Azure.ResourceManager.SignalR.SignalRData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SignalR.SignalRResource> Get(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SignalR.SignalRResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SignalR.SignalRResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SignalR.SignalRResource>> GetAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.SignalR.SignalRResource> GetIfExists(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.SignalR.SignalRResource>> GetIfExistsAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SignalR.SignalRResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SignalR.SignalRResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SignalR.SignalRResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SignalR.SignalRResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SignalRCustomCertificateCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SignalR.SignalRCustomCertificateResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SignalR.SignalRCustomCertificateResource>, System.Collections.IEnumerable
    {
        protected SignalRCustomCertificateCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SignalR.SignalRCustomCertificateResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string certificateName, Azure.ResourceManager.SignalR.SignalRCustomCertificateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SignalR.SignalRCustomCertificateResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string certificateName, Azure.ResourceManager.SignalR.SignalRCustomCertificateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SignalR.SignalRCustomCertificateResource> Get(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SignalR.SignalRCustomCertificateResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SignalR.SignalRCustomCertificateResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SignalR.SignalRCustomCertificateResource>> GetAsync(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.SignalR.SignalRCustomCertificateResource> GetIfExists(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.SignalR.SignalRCustomCertificateResource>> GetIfExistsAsync(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SignalR.SignalRCustomCertificateResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SignalR.SignalRCustomCertificateResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SignalR.SignalRCustomCertificateResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SignalR.SignalRCustomCertificateResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SignalRCustomCertificateData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SignalR.SignalRCustomCertificateData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.SignalRCustomCertificateData>
    {
        public SignalRCustomCertificateData(System.Uri keyVaultBaseUri, string keyVaultSecretName) { }
        public System.Uri KeyVaultBaseUri { get { throw null; } set { } }
        public string KeyVaultSecretName { get { throw null; } set { } }
        public string KeyVaultSecretVersion { get { throw null; } set { } }
        public Azure.ResourceManager.SignalR.Models.SignalRProvisioningState? ProvisioningState { get { throw null; } }
        Azure.ResourceManager.SignalR.SignalRCustomCertificateData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SignalR.SignalRCustomCertificateData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SignalR.SignalRCustomCertificateData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SignalR.SignalRCustomCertificateData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.SignalRCustomCertificateData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.SignalRCustomCertificateData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.SignalRCustomCertificateData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SignalRCustomCertificateResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SignalRCustomCertificateResource() { }
        public virtual Azure.ResourceManager.SignalR.SignalRCustomCertificateData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string certificateName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SignalR.SignalRCustomCertificateResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SignalR.SignalRCustomCertificateResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SignalR.SignalRCustomCertificateResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SignalR.SignalRCustomCertificateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SignalR.SignalRCustomCertificateResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SignalR.SignalRCustomCertificateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SignalRCustomDomainCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SignalR.SignalRCustomDomainResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SignalR.SignalRCustomDomainResource>, System.Collections.IEnumerable
    {
        protected SignalRCustomDomainCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SignalR.SignalRCustomDomainResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.SignalR.SignalRCustomDomainData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SignalR.SignalRCustomDomainResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.SignalR.SignalRCustomDomainData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SignalR.SignalRCustomDomainResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SignalR.SignalRCustomDomainResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SignalR.SignalRCustomDomainResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SignalR.SignalRCustomDomainResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.SignalR.SignalRCustomDomainResource> GetIfExists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.SignalR.SignalRCustomDomainResource>> GetIfExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SignalR.SignalRCustomDomainResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SignalR.SignalRCustomDomainResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SignalR.SignalRCustomDomainResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SignalR.SignalRCustomDomainResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SignalRCustomDomainData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SignalR.SignalRCustomDomainData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.SignalRCustomDomainData>
    {
        public SignalRCustomDomainData(string domainName, Azure.ResourceManager.Resources.Models.WritableSubResource customCertificate) { }
        public Azure.Core.ResourceIdentifier CustomCertificateId { get { throw null; } set { } }
        public string DomainName { get { throw null; } set { } }
        public Azure.ResourceManager.SignalR.Models.SignalRProvisioningState? ProvisioningState { get { throw null; } }
        Azure.ResourceManager.SignalR.SignalRCustomDomainData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SignalR.SignalRCustomDomainData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SignalR.SignalRCustomDomainData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SignalR.SignalRCustomDomainData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.SignalRCustomDomainData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.SignalRCustomDomainData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.SignalRCustomDomainData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SignalRCustomDomainResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SignalRCustomDomainResource() { }
        public virtual Azure.ResourceManager.SignalR.SignalRCustomDomainData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SignalR.SignalRCustomDomainResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SignalR.SignalRCustomDomainResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SignalR.SignalRCustomDomainResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SignalR.SignalRCustomDomainData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SignalR.SignalRCustomDomainResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SignalR.SignalRCustomDomainData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SignalRData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SignalR.SignalRData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.SignalRData>
    {
        public SignalRData(Azure.Core.AzureLocation location) { }
        public System.Collections.Generic.IList<string> CorsAllowedOrigins { get { throw null; } }
        public bool? DisableAadAuth { get { throw null; } set { } }
        public bool? DisableLocalAuth { get { throw null; } set { } }
        public string ExternalIP { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SignalR.Models.SignalRFeature> Features { get { throw null; } }
        public string HostName { get { throw null; } }
        public string HostNamePrefix { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public bool? IsClientCertEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.SignalR.Models.SignalRServiceKind? Kind { get { throw null; } set { } }
        public Azure.ResourceManager.SignalR.Models.SignalRLiveTraceConfiguration LiveTraceConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.SignalR.Models.SignalRNetworkAcls NetworkACLs { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SignalR.SignalRPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.SignalR.Models.SignalRProvisioningState? ProvisioningState { get { throw null; } }
        public string PublicNetworkAccess { get { throw null; } set { } }
        public int? PublicPort { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SignalR.Models.SignalRResourceLogCategory> ResourceLogCategories { get { throw null; } }
        public int? ServerPort { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SignalR.SignalRSharedPrivateLinkResourceData> SharedPrivateLinkResources { get { throw null; } }
        public Azure.ResourceManager.SignalR.Models.SignalRResourceSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SignalR.Models.SignalRUpstreamTemplate> UpstreamTemplates { get { throw null; } }
        public string Version { get { throw null; } }
        Azure.ResourceManager.SignalR.SignalRData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SignalR.SignalRData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SignalR.SignalRData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SignalR.SignalRData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.SignalRData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.SignalRData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.SignalRData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class SignalRExtensions
    {
        public static Azure.Response<Azure.ResourceManager.SignalR.Models.SignalRNameAvailabilityResult> CheckSignalRNameAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.SignalR.Models.SignalRNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SignalR.Models.SignalRNameAvailabilityResult>> CheckSignalRNameAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.SignalR.Models.SignalRNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SignalR.SignalRResource> GetSignalR(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SignalR.SignalRResource>> GetSignalRAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SignalR.SignalRCustomCertificateResource GetSignalRCustomCertificateResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SignalR.SignalRCustomDomainResource GetSignalRCustomDomainResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SignalR.SignalRPrivateEndpointConnectionResource GetSignalRPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SignalR.SignalRResource GetSignalRResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SignalR.SignalRCollection GetSignalRs(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.SignalR.SignalRResource> GetSignalRs(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.SignalR.SignalRResource> GetSignalRsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SignalR.SignalRSharedPrivateLinkResource GetSignalRSharedPrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.SignalR.Models.SignalRUsage> GetUsages(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.SignalR.Models.SignalRUsage> GetUsagesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SignalRPrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SignalR.SignalRPrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SignalR.SignalRPrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected SignalRPrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SignalR.SignalRPrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.SignalR.SignalRPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SignalR.SignalRPrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.SignalR.SignalRPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SignalR.SignalRPrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SignalR.SignalRPrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SignalR.SignalRPrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SignalR.SignalRPrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.SignalR.SignalRPrivateEndpointConnectionResource> GetIfExists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.SignalR.SignalRPrivateEndpointConnectionResource>> GetIfExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SignalR.SignalRPrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SignalR.SignalRPrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SignalR.SignalRPrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SignalR.SignalRPrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SignalRPrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SignalR.SignalRPrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.SignalRPrivateEndpointConnectionData>
    {
        public SignalRPrivateEndpointConnectionData() { }
        public Azure.ResourceManager.SignalR.Models.SignalRPrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> GroupIds { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } set { } }
        public Azure.ResourceManager.SignalR.Models.SignalRProvisioningState? ProvisioningState { get { throw null; } }
        Azure.ResourceManager.SignalR.SignalRPrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SignalR.SignalRPrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SignalR.SignalRPrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SignalR.SignalRPrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.SignalRPrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.SignalRPrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.SignalRPrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SignalRPrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SignalRPrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.SignalR.SignalRPrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SignalR.SignalRPrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SignalR.SignalRPrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SignalR.SignalRPrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SignalR.SignalRPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SignalR.SignalRPrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SignalR.SignalRPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SignalRResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SignalRResource() { }
        public virtual Azure.ResourceManager.SignalR.SignalRData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.SignalR.SignalRResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SignalR.SignalRResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SignalR.SignalRResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SignalR.SignalRResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SignalR.Models.SignalRKeys> GetKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SignalR.Models.SignalRKeys>> GetKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SignalR.SignalRCustomCertificateResource> GetSignalRCustomCertificate(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SignalR.SignalRCustomCertificateResource>> GetSignalRCustomCertificateAsync(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.SignalR.SignalRCustomCertificateCollection GetSignalRCustomCertificates() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SignalR.SignalRCustomDomainResource> GetSignalRCustomDomain(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SignalR.SignalRCustomDomainResource>> GetSignalRCustomDomainAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.SignalR.SignalRCustomDomainCollection GetSignalRCustomDomains() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SignalR.SignalRPrivateEndpointConnectionResource> GetSignalRPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SignalR.SignalRPrivateEndpointConnectionResource>> GetSignalRPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.SignalR.SignalRPrivateEndpointConnectionCollection GetSignalRPrivateEndpointConnections() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SignalR.Models.SignalRPrivateLinkResource> GetSignalRPrivateLinkResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SignalR.Models.SignalRPrivateLinkResource> GetSignalRPrivateLinkResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SignalR.SignalRSharedPrivateLinkResource> GetSignalRSharedPrivateLinkResource(string sharedPrivateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SignalR.SignalRSharedPrivateLinkResource>> GetSignalRSharedPrivateLinkResourceAsync(string sharedPrivateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.SignalR.SignalRSharedPrivateLinkResourceCollection GetSignalRSharedPrivateLinkResources() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SignalR.Models.SignalRSku> GetSkus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SignalR.Models.SignalRSku> GetSkusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SignalR.Models.SignalRKeys> RegenerateKey(Azure.WaitUntil waitUntil, Azure.ResourceManager.SignalR.Models.SignalRRegenerateKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SignalR.Models.SignalRKeys>> RegenerateKeyAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SignalR.Models.SignalRRegenerateKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SignalR.SignalRResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SignalR.SignalRResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Restart(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RestartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SignalR.SignalRResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SignalR.SignalRResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SignalR.SignalRResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SignalR.SignalRData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SignalR.SignalRResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SignalR.SignalRData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SignalRSharedPrivateLinkResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SignalRSharedPrivateLinkResource() { }
        public virtual Azure.ResourceManager.SignalR.SignalRSharedPrivateLinkResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string sharedPrivateLinkResourceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SignalR.SignalRSharedPrivateLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SignalR.SignalRSharedPrivateLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SignalR.SignalRSharedPrivateLinkResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SignalR.SignalRSharedPrivateLinkResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SignalR.SignalRSharedPrivateLinkResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SignalR.SignalRSharedPrivateLinkResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SignalRSharedPrivateLinkResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SignalR.SignalRSharedPrivateLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SignalR.SignalRSharedPrivateLinkResource>, System.Collections.IEnumerable
    {
        protected SignalRSharedPrivateLinkResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SignalR.SignalRSharedPrivateLinkResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string sharedPrivateLinkResourceName, Azure.ResourceManager.SignalR.SignalRSharedPrivateLinkResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SignalR.SignalRSharedPrivateLinkResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string sharedPrivateLinkResourceName, Azure.ResourceManager.SignalR.SignalRSharedPrivateLinkResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string sharedPrivateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string sharedPrivateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SignalR.SignalRSharedPrivateLinkResource> Get(string sharedPrivateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SignalR.SignalRSharedPrivateLinkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SignalR.SignalRSharedPrivateLinkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SignalR.SignalRSharedPrivateLinkResource>> GetAsync(string sharedPrivateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.SignalR.SignalRSharedPrivateLinkResource> GetIfExists(string sharedPrivateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.SignalR.SignalRSharedPrivateLinkResource>> GetIfExistsAsync(string sharedPrivateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SignalR.SignalRSharedPrivateLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SignalR.SignalRSharedPrivateLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SignalR.SignalRSharedPrivateLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SignalR.SignalRSharedPrivateLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SignalRSharedPrivateLinkResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SignalR.SignalRSharedPrivateLinkResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.SignalRSharedPrivateLinkResourceData>
    {
        public SignalRSharedPrivateLinkResourceData() { }
        public string GroupId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrivateLinkResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.SignalR.Models.SignalRProvisioningState? ProvisioningState { get { throw null; } }
        public string RequestMessage { get { throw null; } set { } }
        public Azure.ResourceManager.SignalR.Models.SignalRSharedPrivateLinkResourceStatus? Status { get { throw null; } }
        Azure.ResourceManager.SignalR.SignalRSharedPrivateLinkResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SignalR.SignalRSharedPrivateLinkResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SignalR.SignalRSharedPrivateLinkResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SignalR.SignalRSharedPrivateLinkResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.SignalRSharedPrivateLinkResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.SignalRSharedPrivateLinkResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.SignalRSharedPrivateLinkResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Azure.ResourceManager.SignalR.Mocking
{
    public partial class MockableSignalRArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableSignalRArmClient() { }
        public virtual Azure.ResourceManager.SignalR.SignalRCustomCertificateResource GetSignalRCustomCertificateResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.SignalR.SignalRCustomDomainResource GetSignalRCustomDomainResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.SignalR.SignalRPrivateEndpointConnectionResource GetSignalRPrivateEndpointConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.SignalR.SignalRResource GetSignalRResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.SignalR.SignalRSharedPrivateLinkResource GetSignalRSharedPrivateLinkResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableSignalRResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableSignalRResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.SignalR.SignalRResource> GetSignalR(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SignalR.SignalRResource>> GetSignalRAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.SignalR.SignalRCollection GetSignalRs() { throw null; }
    }
    public partial class MockableSignalRSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableSignalRSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.SignalR.Models.SignalRNameAvailabilityResult> CheckSignalRNameAvailability(Azure.Core.AzureLocation location, Azure.ResourceManager.SignalR.Models.SignalRNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SignalR.Models.SignalRNameAvailabilityResult>> CheckSignalRNameAvailabilityAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.SignalR.Models.SignalRNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SignalR.SignalRResource> GetSignalRs(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SignalR.SignalRResource> GetSignalRsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SignalR.Models.SignalRUsage> GetUsages(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SignalR.Models.SignalRUsage> GetUsagesAsync(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.SignalR.Models
{
    public static partial class ArmSignalRModelFactory
    {
        public static Azure.ResourceManager.SignalR.SignalRCustomCertificateData SignalRCustomCertificateData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.SignalR.Models.SignalRProvisioningState? provisioningState = default(Azure.ResourceManager.SignalR.Models.SignalRProvisioningState?), System.Uri keyVaultBaseUri = null, string keyVaultSecretName = null, string keyVaultSecretVersion = null) { throw null; }
        public static Azure.ResourceManager.SignalR.SignalRCustomDomainData SignalRCustomDomainData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.SignalR.Models.SignalRProvisioningState? provisioningState = default(Azure.ResourceManager.SignalR.Models.SignalRProvisioningState?), string domainName = null, Azure.Core.ResourceIdentifier customCertificateId = null) { throw null; }
        public static Azure.ResourceManager.SignalR.SignalRData SignalRData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.SignalR.Models.SignalRResourceSku sku = null, Azure.ResourceManager.SignalR.Models.SignalRServiceKind? kind = default(Azure.ResourceManager.SignalR.Models.SignalRServiceKind?), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.SignalR.Models.SignalRProvisioningState? provisioningState = default(Azure.ResourceManager.SignalR.Models.SignalRProvisioningState?), string externalIP = null, string hostName = null, int? publicPort = default(int?), int? serverPort = default(int?), string version = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SignalR.SignalRPrivateEndpointConnectionData> privateEndpointConnections = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SignalR.SignalRSharedPrivateLinkResourceData> sharedPrivateLinkResources = null, bool? isClientCertEnabled = default(bool?), string hostNamePrefix = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SignalR.Models.SignalRFeature> features = null, Azure.ResourceManager.SignalR.Models.SignalRLiveTraceConfiguration liveTraceConfiguration = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SignalR.Models.SignalRResourceLogCategory> resourceLogCategories = null, System.Collections.Generic.IEnumerable<string> corsAllowedOrigins = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SignalR.Models.SignalRUpstreamTemplate> upstreamTemplates = null, Azure.ResourceManager.SignalR.Models.SignalRNetworkAcls networkACLs = null, string publicNetworkAccess = null, bool? disableLocalAuth = default(bool?), bool? disableAadAuth = default(bool?)) { throw null; }
        public static Azure.ResourceManager.SignalR.Models.SignalRKeys SignalRKeys(string primaryKey = null, string secondaryKey = null, string primaryConnectionString = null, string secondaryConnectionString = null) { throw null; }
        public static Azure.ResourceManager.SignalR.Models.SignalRNameAvailabilityResult SignalRNameAvailabilityResult(bool? isNameAvailable = default(bool?), string reason = null, string message = null) { throw null; }
        public static Azure.ResourceManager.SignalR.SignalRPrivateEndpointConnectionData SignalRPrivateEndpointConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.SignalR.Models.SignalRProvisioningState? provisioningState = default(Azure.ResourceManager.SignalR.Models.SignalRProvisioningState?), Azure.Core.ResourceIdentifier privateEndpointId = null, System.Collections.Generic.IEnumerable<string> groupIds = null, Azure.ResourceManager.SignalR.Models.SignalRPrivateLinkServiceConnectionState connectionState = null) { throw null; }
        public static Azure.ResourceManager.SignalR.Models.SignalRPrivateLinkResource SignalRPrivateLinkResource(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string groupId = null, System.Collections.Generic.IEnumerable<string> requiredMembers = null, System.Collections.Generic.IEnumerable<string> requiredZoneNames = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SignalR.Models.ShareablePrivateLinkResourceType> shareablePrivateLinkResourceTypes = null) { throw null; }
        public static Azure.ResourceManager.SignalR.Models.SignalRResourceSku SignalRResourceSku(string name = null, Azure.ResourceManager.SignalR.Models.SignalRSkuTier? tier = default(Azure.ResourceManager.SignalR.Models.SignalRSkuTier?), string size = null, string family = null, int? capacity = default(int?)) { throw null; }
        public static Azure.ResourceManager.SignalR.SignalRSharedPrivateLinkResourceData SignalRSharedPrivateLinkResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string groupId = null, Azure.Core.ResourceIdentifier privateLinkResourceId = null, Azure.ResourceManager.SignalR.Models.SignalRProvisioningState? provisioningState = default(Azure.ResourceManager.SignalR.Models.SignalRProvisioningState?), string requestMessage = null, Azure.ResourceManager.SignalR.Models.SignalRSharedPrivateLinkResourceStatus? status = default(Azure.ResourceManager.SignalR.Models.SignalRSharedPrivateLinkResourceStatus?)) { throw null; }
        public static Azure.ResourceManager.SignalR.Models.SignalRSku SignalRSku(Azure.Core.ResourceType? resourceType = default(Azure.Core.ResourceType?), Azure.ResourceManager.SignalR.Models.SignalRResourceSku sku = null, Azure.ResourceManager.SignalR.Models.SignalRSkuCapacity capacity = null) { throw null; }
        public static Azure.ResourceManager.SignalR.Models.SignalRSkuCapacity SignalRSkuCapacity(int? minimum = default(int?), int? maximum = default(int?), int? @default = default(int?), System.Collections.Generic.IEnumerable<int> allowedValues = null, Azure.ResourceManager.SignalR.Models.SignalRScaleType? scaleType = default(Azure.ResourceManager.SignalR.Models.SignalRScaleType?)) { throw null; }
        public static Azure.ResourceManager.SignalR.Models.SignalRUsage SignalRUsage(Azure.Core.ResourceIdentifier id = null, long? currentValue = default(long?), long? limit = default(long?), Azure.ResourceManager.SignalR.Models.SignalRUsageName name = null, string unit = null) { throw null; }
        public static Azure.ResourceManager.SignalR.Models.SignalRUsageName SignalRUsageName(string value = null, string localizedValue = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PrivateLinkServiceConnectionStatus : System.IEquatable<Azure.ResourceManager.SignalR.Models.PrivateLinkServiceConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PrivateLinkServiceConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.SignalR.Models.PrivateLinkServiceConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.SignalR.Models.PrivateLinkServiceConnectionStatus Disconnected { get { throw null; } }
        public static Azure.ResourceManager.SignalR.Models.PrivateLinkServiceConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.SignalR.Models.PrivateLinkServiceConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SignalR.Models.PrivateLinkServiceConnectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SignalR.Models.PrivateLinkServiceConnectionStatus left, Azure.ResourceManager.SignalR.Models.PrivateLinkServiceConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.SignalR.Models.PrivateLinkServiceConnectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SignalR.Models.PrivateLinkServiceConnectionStatus left, Azure.ResourceManager.SignalR.Models.PrivateLinkServiceConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ShareablePrivateLinkResourceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SignalR.Models.ShareablePrivateLinkResourceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.Models.ShareablePrivateLinkResourceProperties>
    {
        public ShareablePrivateLinkResourceProperties() { }
        public string Description { get { throw null; } set { } }
        public string GroupId { get { throw null; } set { } }
        public string ShareablePrivateLinkResourcePropertiesType { get { throw null; } set { } }
        Azure.ResourceManager.SignalR.Models.ShareablePrivateLinkResourceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SignalR.Models.ShareablePrivateLinkResourceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SignalR.Models.ShareablePrivateLinkResourceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SignalR.Models.ShareablePrivateLinkResourceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.Models.ShareablePrivateLinkResourceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.Models.ShareablePrivateLinkResourceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.Models.ShareablePrivateLinkResourceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ShareablePrivateLinkResourceType : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SignalR.Models.ShareablePrivateLinkResourceType>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.Models.ShareablePrivateLinkResourceType>
    {
        public ShareablePrivateLinkResourceType() { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.SignalR.Models.ShareablePrivateLinkResourceProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.SignalR.Models.ShareablePrivateLinkResourceType System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SignalR.Models.ShareablePrivateLinkResourceType>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SignalR.Models.ShareablePrivateLinkResourceType>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SignalR.Models.ShareablePrivateLinkResourceType System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.Models.ShareablePrivateLinkResourceType>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.Models.ShareablePrivateLinkResourceType>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.Models.ShareablePrivateLinkResourceType>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SignalRFeature : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SignalR.Models.SignalRFeature>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.Models.SignalRFeature>
    {
        public SignalRFeature(Azure.ResourceManager.SignalR.Models.SignalRFeatureFlag flag, string value) { }
        public Azure.ResourceManager.SignalR.Models.SignalRFeatureFlag Flag { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Properties { get { throw null; } }
        public string Value { get { throw null; } set { } }
        Azure.ResourceManager.SignalR.Models.SignalRFeature System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SignalR.Models.SignalRFeature>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SignalR.Models.SignalRFeature>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SignalR.Models.SignalRFeature System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.Models.SignalRFeature>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.Models.SignalRFeature>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.Models.SignalRFeature>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SignalRFeatureFlag : System.IEquatable<Azure.ResourceManager.SignalR.Models.SignalRFeatureFlag>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SignalRFeatureFlag(string value) { throw null; }
        public static Azure.ResourceManager.SignalR.Models.SignalRFeatureFlag EnableConnectivityLogs { get { throw null; } }
        public static Azure.ResourceManager.SignalR.Models.SignalRFeatureFlag EnableLiveTrace { get { throw null; } }
        public static Azure.ResourceManager.SignalR.Models.SignalRFeatureFlag EnableMessagingLogs { get { throw null; } }
        public static Azure.ResourceManager.SignalR.Models.SignalRFeatureFlag ServiceMode { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SignalR.Models.SignalRFeatureFlag other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SignalR.Models.SignalRFeatureFlag left, Azure.ResourceManager.SignalR.Models.SignalRFeatureFlag right) { throw null; }
        public static implicit operator Azure.ResourceManager.SignalR.Models.SignalRFeatureFlag (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SignalR.Models.SignalRFeatureFlag left, Azure.ResourceManager.SignalR.Models.SignalRFeatureFlag right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SignalRKeys : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SignalR.Models.SignalRKeys>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.Models.SignalRKeys>
    {
        internal SignalRKeys() { }
        public string PrimaryConnectionString { get { throw null; } }
        public string PrimaryKey { get { throw null; } }
        public string SecondaryConnectionString { get { throw null; } }
        public string SecondaryKey { get { throw null; } }
        Azure.ResourceManager.SignalR.Models.SignalRKeys System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SignalR.Models.SignalRKeys>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SignalR.Models.SignalRKeys>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SignalR.Models.SignalRKeys System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.Models.SignalRKeys>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.Models.SignalRKeys>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.Models.SignalRKeys>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SignalRKeyType : System.IEquatable<Azure.ResourceManager.SignalR.Models.SignalRKeyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SignalRKeyType(string value) { throw null; }
        public static Azure.ResourceManager.SignalR.Models.SignalRKeyType Primary { get { throw null; } }
        public static Azure.ResourceManager.SignalR.Models.SignalRKeyType Salt { get { throw null; } }
        public static Azure.ResourceManager.SignalR.Models.SignalRKeyType Secondary { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SignalR.Models.SignalRKeyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SignalR.Models.SignalRKeyType left, Azure.ResourceManager.SignalR.Models.SignalRKeyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SignalR.Models.SignalRKeyType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SignalR.Models.SignalRKeyType left, Azure.ResourceManager.SignalR.Models.SignalRKeyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SignalRLiveTraceCategory : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SignalR.Models.SignalRLiveTraceCategory>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.Models.SignalRLiveTraceCategory>
    {
        public SignalRLiveTraceCategory() { }
        public string Enabled { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        Azure.ResourceManager.SignalR.Models.SignalRLiveTraceCategory System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SignalR.Models.SignalRLiveTraceCategory>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SignalR.Models.SignalRLiveTraceCategory>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SignalR.Models.SignalRLiveTraceCategory System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.Models.SignalRLiveTraceCategory>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.Models.SignalRLiveTraceCategory>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.Models.SignalRLiveTraceCategory>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SignalRLiveTraceConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SignalR.Models.SignalRLiveTraceConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.Models.SignalRLiveTraceConfiguration>
    {
        public SignalRLiveTraceConfiguration() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.SignalR.Models.SignalRLiveTraceCategory> Categories { get { throw null; } }
        public string Enabled { get { throw null; } set { } }
        Azure.ResourceManager.SignalR.Models.SignalRLiveTraceConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SignalR.Models.SignalRLiveTraceConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SignalR.Models.SignalRLiveTraceConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SignalR.Models.SignalRLiveTraceConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.Models.SignalRLiveTraceConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.Models.SignalRLiveTraceConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.Models.SignalRLiveTraceConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SignalRNameAvailabilityContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SignalR.Models.SignalRNameAvailabilityContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.Models.SignalRNameAvailabilityContent>
    {
        public SignalRNameAvailabilityContent(Azure.Core.ResourceType resourceType, string name) { }
        public string Name { get { throw null; } }
        public Azure.Core.ResourceType ResourceType { get { throw null; } }
        Azure.ResourceManager.SignalR.Models.SignalRNameAvailabilityContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SignalR.Models.SignalRNameAvailabilityContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SignalR.Models.SignalRNameAvailabilityContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SignalR.Models.SignalRNameAvailabilityContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.Models.SignalRNameAvailabilityContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.Models.SignalRNameAvailabilityContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.Models.SignalRNameAvailabilityContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SignalRNameAvailabilityResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SignalR.Models.SignalRNameAvailabilityResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.Models.SignalRNameAvailabilityResult>
    {
        internal SignalRNameAvailabilityResult() { }
        public bool? IsNameAvailable { get { throw null; } }
        public string Message { get { throw null; } }
        public string Reason { get { throw null; } }
        Azure.ResourceManager.SignalR.Models.SignalRNameAvailabilityResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SignalR.Models.SignalRNameAvailabilityResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SignalR.Models.SignalRNameAvailabilityResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SignalR.Models.SignalRNameAvailabilityResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.Models.SignalRNameAvailabilityResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.Models.SignalRNameAvailabilityResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.Models.SignalRNameAvailabilityResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SignalRNetworkAcl : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SignalR.Models.SignalRNetworkAcl>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.Models.SignalRNetworkAcl>
    {
        public SignalRNetworkAcl() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.SignalR.Models.SignalRRequestType> Allow { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SignalR.Models.SignalRRequestType> Deny { get { throw null; } }
        Azure.ResourceManager.SignalR.Models.SignalRNetworkAcl System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SignalR.Models.SignalRNetworkAcl>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SignalR.Models.SignalRNetworkAcl>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SignalR.Models.SignalRNetworkAcl System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.Models.SignalRNetworkAcl>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.Models.SignalRNetworkAcl>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.Models.SignalRNetworkAcl>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SignalRNetworkAclAction : System.IEquatable<Azure.ResourceManager.SignalR.Models.SignalRNetworkAclAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SignalRNetworkAclAction(string value) { throw null; }
        public static Azure.ResourceManager.SignalR.Models.SignalRNetworkAclAction Allow { get { throw null; } }
        public static Azure.ResourceManager.SignalR.Models.SignalRNetworkAclAction Deny { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SignalR.Models.SignalRNetworkAclAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SignalR.Models.SignalRNetworkAclAction left, Azure.ResourceManager.SignalR.Models.SignalRNetworkAclAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.SignalR.Models.SignalRNetworkAclAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SignalR.Models.SignalRNetworkAclAction left, Azure.ResourceManager.SignalR.Models.SignalRNetworkAclAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SignalRNetworkAcls : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SignalR.Models.SignalRNetworkAcls>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.Models.SignalRNetworkAcls>
    {
        public SignalRNetworkAcls() { }
        public Azure.ResourceManager.SignalR.Models.SignalRNetworkAclAction? DefaultAction { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SignalR.Models.SignalRPrivateEndpointAcl> PrivateEndpoints { get { throw null; } }
        public Azure.ResourceManager.SignalR.Models.SignalRNetworkAcl PublicNetwork { get { throw null; } set { } }
        Azure.ResourceManager.SignalR.Models.SignalRNetworkAcls System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SignalR.Models.SignalRNetworkAcls>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SignalR.Models.SignalRNetworkAcls>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SignalR.Models.SignalRNetworkAcls System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.Models.SignalRNetworkAcls>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.Models.SignalRNetworkAcls>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.Models.SignalRNetworkAcls>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SignalRPrivateEndpointAcl : Azure.ResourceManager.SignalR.Models.SignalRNetworkAcl, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SignalR.Models.SignalRPrivateEndpointAcl>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.Models.SignalRPrivateEndpointAcl>
    {
        public SignalRPrivateEndpointAcl(string name) { }
        public string Name { get { throw null; } set { } }
        Azure.ResourceManager.SignalR.Models.SignalRPrivateEndpointAcl System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SignalR.Models.SignalRPrivateEndpointAcl>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SignalR.Models.SignalRPrivateEndpointAcl>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SignalR.Models.SignalRPrivateEndpointAcl System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.Models.SignalRPrivateEndpointAcl>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.Models.SignalRPrivateEndpointAcl>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.Models.SignalRPrivateEndpointAcl>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SignalRPrivateLinkResource : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SignalR.Models.SignalRPrivateLinkResource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.Models.SignalRPrivateLinkResource>
    {
        public SignalRPrivateLinkResource() { }
        public string GroupId { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredZoneNames { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SignalR.Models.ShareablePrivateLinkResourceType> ShareablePrivateLinkResourceTypes { get { throw null; } }
        Azure.ResourceManager.SignalR.Models.SignalRPrivateLinkResource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SignalR.Models.SignalRPrivateLinkResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SignalR.Models.SignalRPrivateLinkResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SignalR.Models.SignalRPrivateLinkResource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.Models.SignalRPrivateLinkResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.Models.SignalRPrivateLinkResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.Models.SignalRPrivateLinkResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SignalRPrivateLinkServiceConnectionState : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SignalR.Models.SignalRPrivateLinkServiceConnectionState>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.Models.SignalRPrivateLinkServiceConnectionState>
    {
        public SignalRPrivateLinkServiceConnectionState() { }
        public string ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.SignalR.Models.PrivateLinkServiceConnectionStatus? Status { get { throw null; } set { } }
        Azure.ResourceManager.SignalR.Models.SignalRPrivateLinkServiceConnectionState System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SignalR.Models.SignalRPrivateLinkServiceConnectionState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SignalR.Models.SignalRPrivateLinkServiceConnectionState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SignalR.Models.SignalRPrivateLinkServiceConnectionState System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.Models.SignalRPrivateLinkServiceConnectionState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.Models.SignalRPrivateLinkServiceConnectionState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.Models.SignalRPrivateLinkServiceConnectionState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SignalRProvisioningState : System.IEquatable<Azure.ResourceManager.SignalR.Models.SignalRProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SignalRProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.SignalR.Models.SignalRProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.SignalR.Models.SignalRProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.SignalR.Models.SignalRProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.SignalR.Models.SignalRProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.SignalR.Models.SignalRProvisioningState Moving { get { throw null; } }
        public static Azure.ResourceManager.SignalR.Models.SignalRProvisioningState Running { get { throw null; } }
        public static Azure.ResourceManager.SignalR.Models.SignalRProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.SignalR.Models.SignalRProvisioningState Unknown { get { throw null; } }
        public static Azure.ResourceManager.SignalR.Models.SignalRProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SignalR.Models.SignalRProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SignalR.Models.SignalRProvisioningState left, Azure.ResourceManager.SignalR.Models.SignalRProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.SignalR.Models.SignalRProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SignalR.Models.SignalRProvisioningState left, Azure.ResourceManager.SignalR.Models.SignalRProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SignalRRegenerateKeyContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SignalR.Models.SignalRRegenerateKeyContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.Models.SignalRRegenerateKeyContent>
    {
        public SignalRRegenerateKeyContent() { }
        public Azure.ResourceManager.SignalR.Models.SignalRKeyType? KeyType { get { throw null; } set { } }
        Azure.ResourceManager.SignalR.Models.SignalRRegenerateKeyContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SignalR.Models.SignalRRegenerateKeyContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SignalR.Models.SignalRRegenerateKeyContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SignalR.Models.SignalRRegenerateKeyContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.Models.SignalRRegenerateKeyContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.Models.SignalRRegenerateKeyContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.Models.SignalRRegenerateKeyContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SignalRRequestType : System.IEquatable<Azure.ResourceManager.SignalR.Models.SignalRRequestType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SignalRRequestType(string value) { throw null; }
        public static Azure.ResourceManager.SignalR.Models.SignalRRequestType ClientConnection { get { throw null; } }
        public static Azure.ResourceManager.SignalR.Models.SignalRRequestType RestApi { get { throw null; } }
        public static Azure.ResourceManager.SignalR.Models.SignalRRequestType ServerConnection { get { throw null; } }
        public static Azure.ResourceManager.SignalR.Models.SignalRRequestType Trace { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SignalR.Models.SignalRRequestType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SignalR.Models.SignalRRequestType left, Azure.ResourceManager.SignalR.Models.SignalRRequestType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SignalR.Models.SignalRRequestType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SignalR.Models.SignalRRequestType left, Azure.ResourceManager.SignalR.Models.SignalRRequestType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SignalRResourceLogCategory : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SignalR.Models.SignalRResourceLogCategory>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.Models.SignalRResourceLogCategory>
    {
        public SignalRResourceLogCategory() { }
        public string Enabled { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        Azure.ResourceManager.SignalR.Models.SignalRResourceLogCategory System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SignalR.Models.SignalRResourceLogCategory>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SignalR.Models.SignalRResourceLogCategory>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SignalR.Models.SignalRResourceLogCategory System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.Models.SignalRResourceLogCategory>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.Models.SignalRResourceLogCategory>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.Models.SignalRResourceLogCategory>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SignalRResourceSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SignalR.Models.SignalRResourceSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.Models.SignalRResourceSku>
    {
        public SignalRResourceSku(string name) { }
        public int? Capacity { get { throw null; } set { } }
        public string Family { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public string Size { get { throw null; } }
        public Azure.ResourceManager.SignalR.Models.SignalRSkuTier? Tier { get { throw null; } set { } }
        Azure.ResourceManager.SignalR.Models.SignalRResourceSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SignalR.Models.SignalRResourceSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SignalR.Models.SignalRResourceSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SignalR.Models.SignalRResourceSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.Models.SignalRResourceSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.Models.SignalRResourceSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.Models.SignalRResourceSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SignalRScaleType : System.IEquatable<Azure.ResourceManager.SignalR.Models.SignalRScaleType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SignalRScaleType(string value) { throw null; }
        public static Azure.ResourceManager.SignalR.Models.SignalRScaleType Automatic { get { throw null; } }
        public static Azure.ResourceManager.SignalR.Models.SignalRScaleType Manual { get { throw null; } }
        public static Azure.ResourceManager.SignalR.Models.SignalRScaleType None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SignalR.Models.SignalRScaleType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SignalR.Models.SignalRScaleType left, Azure.ResourceManager.SignalR.Models.SignalRScaleType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SignalR.Models.SignalRScaleType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SignalR.Models.SignalRScaleType left, Azure.ResourceManager.SignalR.Models.SignalRScaleType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SignalRServiceKind : System.IEquatable<Azure.ResourceManager.SignalR.Models.SignalRServiceKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SignalRServiceKind(string value) { throw null; }
        public static Azure.ResourceManager.SignalR.Models.SignalRServiceKind RawWebSockets { get { throw null; } }
        public static Azure.ResourceManager.SignalR.Models.SignalRServiceKind SignalR { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SignalR.Models.SignalRServiceKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SignalR.Models.SignalRServiceKind left, Azure.ResourceManager.SignalR.Models.SignalRServiceKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.SignalR.Models.SignalRServiceKind (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SignalR.Models.SignalRServiceKind left, Azure.ResourceManager.SignalR.Models.SignalRServiceKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SignalRSharedPrivateLinkResourceStatus : System.IEquatable<Azure.ResourceManager.SignalR.Models.SignalRSharedPrivateLinkResourceStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SignalRSharedPrivateLinkResourceStatus(string value) { throw null; }
        public static Azure.ResourceManager.SignalR.Models.SignalRSharedPrivateLinkResourceStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.SignalR.Models.SignalRSharedPrivateLinkResourceStatus Disconnected { get { throw null; } }
        public static Azure.ResourceManager.SignalR.Models.SignalRSharedPrivateLinkResourceStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.SignalR.Models.SignalRSharedPrivateLinkResourceStatus Rejected { get { throw null; } }
        public static Azure.ResourceManager.SignalR.Models.SignalRSharedPrivateLinkResourceStatus Timeout { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SignalR.Models.SignalRSharedPrivateLinkResourceStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SignalR.Models.SignalRSharedPrivateLinkResourceStatus left, Azure.ResourceManager.SignalR.Models.SignalRSharedPrivateLinkResourceStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.SignalR.Models.SignalRSharedPrivateLinkResourceStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SignalR.Models.SignalRSharedPrivateLinkResourceStatus left, Azure.ResourceManager.SignalR.Models.SignalRSharedPrivateLinkResourceStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SignalRSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SignalR.Models.SignalRSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.Models.SignalRSku>
    {
        internal SignalRSku() { }
        public Azure.ResourceManager.SignalR.Models.SignalRSkuCapacity Capacity { get { throw null; } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } }
        public Azure.ResourceManager.SignalR.Models.SignalRResourceSku Sku { get { throw null; } }
        Azure.ResourceManager.SignalR.Models.SignalRSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SignalR.Models.SignalRSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SignalR.Models.SignalRSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SignalR.Models.SignalRSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.Models.SignalRSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.Models.SignalRSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.Models.SignalRSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SignalRSkuCapacity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SignalR.Models.SignalRSkuCapacity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.Models.SignalRSkuCapacity>
    {
        internal SignalRSkuCapacity() { }
        public System.Collections.Generic.IReadOnlyList<int> AllowedValues { get { throw null; } }
        public int? Default { get { throw null; } }
        public int? Maximum { get { throw null; } }
        public int? Minimum { get { throw null; } }
        public Azure.ResourceManager.SignalR.Models.SignalRScaleType? ScaleType { get { throw null; } }
        Azure.ResourceManager.SignalR.Models.SignalRSkuCapacity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SignalR.Models.SignalRSkuCapacity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SignalR.Models.SignalRSkuCapacity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SignalR.Models.SignalRSkuCapacity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.Models.SignalRSkuCapacity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.Models.SignalRSkuCapacity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.Models.SignalRSkuCapacity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SignalRSkuTier : System.IEquatable<Azure.ResourceManager.SignalR.Models.SignalRSkuTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SignalRSkuTier(string value) { throw null; }
        public static Azure.ResourceManager.SignalR.Models.SignalRSkuTier Basic { get { throw null; } }
        public static Azure.ResourceManager.SignalR.Models.SignalRSkuTier Free { get { throw null; } }
        public static Azure.ResourceManager.SignalR.Models.SignalRSkuTier Premium { get { throw null; } }
        public static Azure.ResourceManager.SignalR.Models.SignalRSkuTier Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SignalR.Models.SignalRSkuTier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SignalR.Models.SignalRSkuTier left, Azure.ResourceManager.SignalR.Models.SignalRSkuTier right) { throw null; }
        public static implicit operator Azure.ResourceManager.SignalR.Models.SignalRSkuTier (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SignalR.Models.SignalRSkuTier left, Azure.ResourceManager.SignalR.Models.SignalRSkuTier right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SignalRUpstreamAuthSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SignalR.Models.SignalRUpstreamAuthSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.Models.SignalRUpstreamAuthSettings>
    {
        public SignalRUpstreamAuthSettings() { }
        public Azure.ResourceManager.SignalR.Models.SignalRUpstreamAuthType? AuthType { get { throw null; } set { } }
        public string ManagedIdentityResource { get { throw null; } set { } }
        Azure.ResourceManager.SignalR.Models.SignalRUpstreamAuthSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SignalR.Models.SignalRUpstreamAuthSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SignalR.Models.SignalRUpstreamAuthSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SignalR.Models.SignalRUpstreamAuthSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.Models.SignalRUpstreamAuthSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.Models.SignalRUpstreamAuthSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.Models.SignalRUpstreamAuthSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SignalRUpstreamAuthType : System.IEquatable<Azure.ResourceManager.SignalR.Models.SignalRUpstreamAuthType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SignalRUpstreamAuthType(string value) { throw null; }
        public static Azure.ResourceManager.SignalR.Models.SignalRUpstreamAuthType ManagedIdentity { get { throw null; } }
        public static Azure.ResourceManager.SignalR.Models.SignalRUpstreamAuthType None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SignalR.Models.SignalRUpstreamAuthType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SignalR.Models.SignalRUpstreamAuthType left, Azure.ResourceManager.SignalR.Models.SignalRUpstreamAuthType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SignalR.Models.SignalRUpstreamAuthType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SignalR.Models.SignalRUpstreamAuthType left, Azure.ResourceManager.SignalR.Models.SignalRUpstreamAuthType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SignalRUpstreamTemplate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SignalR.Models.SignalRUpstreamTemplate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.Models.SignalRUpstreamTemplate>
    {
        public SignalRUpstreamTemplate(string urlTemplate) { }
        public Azure.ResourceManager.SignalR.Models.SignalRUpstreamAuthSettings Auth { get { throw null; } set { } }
        public string CategoryPattern { get { throw null; } set { } }
        public string EventPattern { get { throw null; } set { } }
        public string HubPattern { get { throw null; } set { } }
        public string UrlTemplate { get { throw null; } set { } }
        Azure.ResourceManager.SignalR.Models.SignalRUpstreamTemplate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SignalR.Models.SignalRUpstreamTemplate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SignalR.Models.SignalRUpstreamTemplate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SignalR.Models.SignalRUpstreamTemplate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.Models.SignalRUpstreamTemplate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.Models.SignalRUpstreamTemplate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.Models.SignalRUpstreamTemplate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SignalRUsage : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SignalR.Models.SignalRUsage>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.Models.SignalRUsage>
    {
        internal SignalRUsage() { }
        public long? CurrentValue { get { throw null; } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public long? Limit { get { throw null; } }
        public Azure.ResourceManager.SignalR.Models.SignalRUsageName Name { get { throw null; } }
        public string Unit { get { throw null; } }
        Azure.ResourceManager.SignalR.Models.SignalRUsage System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SignalR.Models.SignalRUsage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SignalR.Models.SignalRUsage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SignalR.Models.SignalRUsage System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.Models.SignalRUsage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.Models.SignalRUsage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.Models.SignalRUsage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SignalRUsageName : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SignalR.Models.SignalRUsageName>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.Models.SignalRUsageName>
    {
        internal SignalRUsageName() { }
        public string LocalizedValue { get { throw null; } }
        public string Value { get { throw null; } }
        Azure.ResourceManager.SignalR.Models.SignalRUsageName System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SignalR.Models.SignalRUsageName>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SignalR.Models.SignalRUsageName>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SignalR.Models.SignalRUsageName System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.Models.SignalRUsageName>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.Models.SignalRUsageName>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SignalR.Models.SignalRUsageName>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
