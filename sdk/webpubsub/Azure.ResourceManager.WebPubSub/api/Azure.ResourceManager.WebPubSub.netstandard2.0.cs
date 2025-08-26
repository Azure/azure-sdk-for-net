namespace Azure.ResourceManager.WebPubSub
{
    public partial class AzureResourceManagerWebPubSubContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerWebPubSubContext() { }
        public static Azure.ResourceManager.WebPubSub.AzureResourceManagerWebPubSubContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class WebPubSubCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WebPubSub.WebPubSubResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WebPubSub.WebPubSubResource>, System.Collections.IEnumerable
    {
        protected WebPubSubCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WebPubSub.WebPubSubResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string resourceName, Azure.ResourceManager.WebPubSub.WebPubSubData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WebPubSub.WebPubSubResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string resourceName, Azure.ResourceManager.WebPubSub.WebPubSubData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubResource> Get(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WebPubSub.WebPubSubResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WebPubSub.WebPubSubResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubResource>> GetAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.WebPubSub.WebPubSubResource> GetIfExists(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.WebPubSub.WebPubSubResource>> GetIfExistsAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.WebPubSub.WebPubSubResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WebPubSub.WebPubSubResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.WebPubSub.WebPubSubResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.WebPubSub.WebPubSubResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WebPubSubCustomCertificateCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WebPubSub.WebPubSubCustomCertificateResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WebPubSub.WebPubSubCustomCertificateResource>, System.Collections.IEnumerable
    {
        protected WebPubSubCustomCertificateCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WebPubSub.WebPubSubCustomCertificateResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string certificateName, Azure.ResourceManager.WebPubSub.WebPubSubCustomCertificateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WebPubSub.WebPubSubCustomCertificateResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string certificateName, Azure.ResourceManager.WebPubSub.WebPubSubCustomCertificateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubCustomCertificateResource> Get(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WebPubSub.WebPubSubCustomCertificateResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WebPubSub.WebPubSubCustomCertificateResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubCustomCertificateResource>> GetAsync(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.WebPubSub.WebPubSubCustomCertificateResource> GetIfExists(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.WebPubSub.WebPubSubCustomCertificateResource>> GetIfExistsAsync(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.WebPubSub.WebPubSubCustomCertificateResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WebPubSub.WebPubSubCustomCertificateResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.WebPubSub.WebPubSubCustomCertificateResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.WebPubSub.WebPubSubCustomCertificateResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WebPubSubCustomCertificateData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.WebPubSubCustomCertificateData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.WebPubSubCustomCertificateData>
    {
        public WebPubSubCustomCertificateData(System.Uri keyVaultBaseUri, string keyVaultSecretName) { }
        public System.Uri KeyVaultBaseUri { get { throw null; } set { } }
        public string KeyVaultSecretName { get { throw null; } set { } }
        public string KeyVaultSecretVersion { get { throw null; } set { } }
        public Azure.ResourceManager.WebPubSub.Models.WebPubSubProvisioningState? ProvisioningState { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.WebPubSubCustomCertificateData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.WebPubSubCustomCertificateData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.WebPubSubCustomCertificateData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.WebPubSubCustomCertificateData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.WebPubSubCustomCertificateData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.WebPubSubCustomCertificateData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.WebPubSubCustomCertificateData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WebPubSubCustomCertificateResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.WebPubSubCustomCertificateData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.WebPubSubCustomCertificateData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WebPubSubCustomCertificateResource() { }
        public virtual Azure.ResourceManager.WebPubSub.WebPubSubCustomCertificateData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string certificateName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubCustomCertificateResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubCustomCertificateResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.WebPubSub.WebPubSubCustomCertificateData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.WebPubSubCustomCertificateData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.WebPubSubCustomCertificateData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.WebPubSubCustomCertificateData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.WebPubSubCustomCertificateData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.WebPubSubCustomCertificateData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.WebPubSubCustomCertificateData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WebPubSub.WebPubSubCustomCertificateResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.WebPubSub.WebPubSubCustomCertificateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WebPubSub.WebPubSubCustomCertificateResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.WebPubSub.WebPubSubCustomCertificateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WebPubSubCustomDomainCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WebPubSub.WebPubSubCustomDomainResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WebPubSub.WebPubSubCustomDomainResource>, System.Collections.IEnumerable
    {
        protected WebPubSubCustomDomainCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WebPubSub.WebPubSubCustomDomainResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.WebPubSub.WebPubSubCustomDomainData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WebPubSub.WebPubSubCustomDomainResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.WebPubSub.WebPubSubCustomDomainData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubCustomDomainResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WebPubSub.WebPubSubCustomDomainResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WebPubSub.WebPubSubCustomDomainResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubCustomDomainResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.WebPubSub.WebPubSubCustomDomainResource> GetIfExists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.WebPubSub.WebPubSubCustomDomainResource>> GetIfExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.WebPubSub.WebPubSubCustomDomainResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WebPubSub.WebPubSubCustomDomainResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.WebPubSub.WebPubSubCustomDomainResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.WebPubSub.WebPubSubCustomDomainResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WebPubSubCustomDomainData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.WebPubSubCustomDomainData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.WebPubSubCustomDomainData>
    {
        public WebPubSubCustomDomainData(string domainName, Azure.ResourceManager.Resources.Models.WritableSubResource customCertificate) { }
        public Azure.Core.ResourceIdentifier CustomCertificateId { get { throw null; } set { } }
        public string DomainName { get { throw null; } set { } }
        public Azure.ResourceManager.WebPubSub.Models.WebPubSubProvisioningState? ProvisioningState { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.WebPubSubCustomDomainData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.WebPubSubCustomDomainData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.WebPubSubCustomDomainData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.WebPubSubCustomDomainData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.WebPubSubCustomDomainData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.WebPubSubCustomDomainData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.WebPubSubCustomDomainData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WebPubSubCustomDomainResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.WebPubSubCustomDomainData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.WebPubSubCustomDomainData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WebPubSubCustomDomainResource() { }
        public virtual Azure.ResourceManager.WebPubSub.WebPubSubCustomDomainData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubCustomDomainResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubCustomDomainResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.WebPubSub.WebPubSubCustomDomainData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.WebPubSubCustomDomainData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.WebPubSubCustomDomainData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.WebPubSubCustomDomainData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.WebPubSubCustomDomainData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.WebPubSubCustomDomainData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.WebPubSubCustomDomainData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WebPubSub.WebPubSubCustomDomainResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.WebPubSub.WebPubSubCustomDomainData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WebPubSub.WebPubSubCustomDomainResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.WebPubSub.WebPubSubCustomDomainData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WebPubSubData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.WebPubSubData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.WebPubSubData>
    {
        public WebPubSubData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.WebPubSub.Models.ApplicationFirewallSettings ApplicationFirewall { get { throw null; } set { } }
        public string ExternalIP { get { throw null; } }
        public string HostName { get { throw null; } }
        public string HostNamePrefix { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public bool? IsAadAuthDisabled { get { throw null; } set { } }
        public bool? IsClientCertEnabled { get { throw null; } set { } }
        public bool? IsLocalAuthDisabled { get { throw null; } set { } }
        public Azure.ResourceManager.WebPubSub.Models.WebPubSubServiceKind? Kind { get { throw null; } set { } }
        public Azure.ResourceManager.WebPubSub.Models.LiveTraceConfiguration LiveTraceConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.WebPubSub.Models.WebPubSubNetworkAcls NetworkAcls { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.WebPubSub.WebPubSubPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.WebPubSub.Models.WebPubSubProvisioningState? ProvisioningState { get { throw null; } }
        public string PublicNetworkAccess { get { throw null; } set { } }
        public int? PublicPort { get { throw null; } }
        public string RegionEndpointEnabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.WebPubSub.Models.ResourceLogCategory> ResourceLogCategories { get { throw null; } }
        public string ResourceStopped { get { throw null; } set { } }
        public int? ServerPort { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.WebPubSub.WebPubSubSharedPrivateLinkData> SharedPrivateLinkResources { get { throw null; } }
        public Azure.ResourceManager.WebPubSub.Models.BillingInfoSku Sku { get { throw null; } set { } }
        public string SocketIOServiceMode { get { throw null; } set { } }
        public string Version { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.WebPubSubData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.WebPubSubData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.WebPubSubData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.WebPubSubData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.WebPubSubData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.WebPubSubData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.WebPubSubData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class WebPubSubExtensions
    {
        public static Azure.Response<Azure.ResourceManager.WebPubSub.Models.WebPubSubNameAvailability> CheckWebPubSubNameAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.WebPubSub.Models.WebPubSubNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.Models.WebPubSubNameAvailability>> CheckWebPubSubNameAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.WebPubSub.Models.WebPubSubNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.WebPubSub.Models.SignalRServiceUsage> GetUsages(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.WebPubSub.Models.SignalRServiceUsage> GetUsagesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubResource> GetWebPubSub(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubResource>> GetWebPubSubAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.WebPubSub.WebPubSubCustomCertificateResource GetWebPubSubCustomCertificateResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.WebPubSub.WebPubSubCustomDomainResource GetWebPubSubCustomDomainResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.WebPubSub.WebPubSubHubResource GetWebPubSubHubResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.WebPubSub.WebPubSubPrivateEndpointConnectionResource GetWebPubSubPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.WebPubSub.WebPubSubReplicaResource GetWebPubSubReplicaResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.WebPubSub.WebPubSubReplicaSharedPrivateLinkResource GetWebPubSubReplicaSharedPrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.WebPubSub.WebPubSubResource GetWebPubSubResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.WebPubSub.WebPubSubCollection GetWebPubSubs(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.WebPubSub.WebPubSubResource> GetWebPubSubs(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.WebPubSub.WebPubSubResource> GetWebPubSubsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.WebPubSub.WebPubSubSharedPrivateLinkResource GetWebPubSubSharedPrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class WebPubSubHubCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WebPubSub.WebPubSubHubResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WebPubSub.WebPubSubHubResource>, System.Collections.IEnumerable
    {
        protected WebPubSubHubCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WebPubSub.WebPubSubHubResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string hubName, Azure.ResourceManager.WebPubSub.WebPubSubHubData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WebPubSub.WebPubSubHubResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string hubName, Azure.ResourceManager.WebPubSub.WebPubSubHubData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string hubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string hubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubHubResource> Get(string hubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WebPubSub.WebPubSubHubResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WebPubSub.WebPubSubHubResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubHubResource>> GetAsync(string hubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.WebPubSub.WebPubSubHubResource> GetIfExists(string hubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.WebPubSub.WebPubSubHubResource>> GetIfExistsAsync(string hubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.WebPubSub.WebPubSubHubResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WebPubSub.WebPubSubHubResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.WebPubSub.WebPubSubHubResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.WebPubSub.WebPubSubHubResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WebPubSubHubData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.WebPubSubHubData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.WebPubSubHubData>
    {
        public WebPubSubHubData(Azure.ResourceManager.WebPubSub.Models.WebPubSubHubProperties properties) { }
        public Azure.ResourceManager.WebPubSub.Models.WebPubSubHubProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.WebPubSubHubData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.WebPubSubHubData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.WebPubSubHubData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.WebPubSubHubData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.WebPubSubHubData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.WebPubSubHubData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.WebPubSubHubData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WebPubSubHubResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.WebPubSubHubData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.WebPubSubHubData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WebPubSubHubResource() { }
        public virtual Azure.ResourceManager.WebPubSub.WebPubSubHubData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string hubName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubHubResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubHubResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.WebPubSub.WebPubSubHubData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.WebPubSubHubData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.WebPubSubHubData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.WebPubSubHubData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.WebPubSubHubData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.WebPubSubHubData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.WebPubSubHubData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WebPubSub.WebPubSubHubResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.WebPubSub.WebPubSubHubData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WebPubSub.WebPubSubHubResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.WebPubSub.WebPubSubHubData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WebPubSubPrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WebPubSub.WebPubSubPrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WebPubSub.WebPubSubPrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected WebPubSubPrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WebPubSub.WebPubSubPrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.WebPubSub.WebPubSubPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WebPubSub.WebPubSubPrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.WebPubSub.WebPubSubPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubPrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WebPubSub.WebPubSubPrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WebPubSub.WebPubSubPrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubPrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.WebPubSub.WebPubSubPrivateEndpointConnectionResource> GetIfExists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.WebPubSub.WebPubSubPrivateEndpointConnectionResource>> GetIfExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.WebPubSub.WebPubSubPrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WebPubSub.WebPubSubPrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.WebPubSub.WebPubSubPrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.WebPubSub.WebPubSubPrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WebPubSubPrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.WebPubSubPrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.WebPubSubPrivateEndpointConnectionData>
    {
        public WebPubSubPrivateEndpointConnectionData() { }
        public Azure.ResourceManager.WebPubSub.Models.WebPubSubPrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> GroupIds { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } set { } }
        public Azure.ResourceManager.WebPubSub.Models.WebPubSubProvisioningState? ProvisioningState { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.WebPubSubPrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.WebPubSubPrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.WebPubSubPrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.WebPubSubPrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.WebPubSubPrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.WebPubSubPrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.WebPubSubPrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WebPubSubPrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.WebPubSubPrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.WebPubSubPrivateEndpointConnectionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WebPubSubPrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.WebPubSub.WebPubSubPrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubPrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubPrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.WebPubSub.WebPubSubPrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.WebPubSubPrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.WebPubSubPrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.WebPubSubPrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.WebPubSubPrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.WebPubSubPrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.WebPubSubPrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WebPubSub.WebPubSubPrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.WebPubSub.WebPubSubPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WebPubSub.WebPubSubPrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.WebPubSub.WebPubSubPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WebPubSubReplicaCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WebPubSub.WebPubSubReplicaResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WebPubSub.WebPubSubReplicaResource>, System.Collections.IEnumerable
    {
        protected WebPubSubReplicaCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WebPubSub.WebPubSubReplicaResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string replicaName, Azure.ResourceManager.WebPubSub.WebPubSubReplicaData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WebPubSub.WebPubSubReplicaResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string replicaName, Azure.ResourceManager.WebPubSub.WebPubSubReplicaData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string replicaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string replicaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubReplicaResource> Get(string replicaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WebPubSub.WebPubSubReplicaResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WebPubSub.WebPubSubReplicaResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubReplicaResource>> GetAsync(string replicaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.WebPubSub.WebPubSubReplicaResource> GetIfExists(string replicaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.WebPubSub.WebPubSubReplicaResource>> GetIfExistsAsync(string replicaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.WebPubSub.WebPubSubReplicaResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WebPubSub.WebPubSubReplicaResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.WebPubSub.WebPubSubReplicaResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.WebPubSub.WebPubSubReplicaResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WebPubSubReplicaData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.WebPubSubReplicaData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.WebPubSubReplicaData>
    {
        public WebPubSubReplicaData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.WebPubSub.Models.WebPubSubProvisioningState? ProvisioningState { get { throw null; } }
        public string RegionEndpointEnabled { get { throw null; } set { } }
        public string ResourceStopped { get { throw null; } set { } }
        public Azure.ResourceManager.WebPubSub.Models.BillingInfoSku Sku { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.WebPubSubReplicaData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.WebPubSubReplicaData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.WebPubSubReplicaData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.WebPubSubReplicaData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.WebPubSubReplicaData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.WebPubSubReplicaData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.WebPubSubReplicaData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WebPubSubReplicaResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.WebPubSubReplicaData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.WebPubSubReplicaData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WebPubSubReplicaResource() { }
        public virtual Azure.ResourceManager.WebPubSub.WebPubSubReplicaData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubReplicaResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubReplicaResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string replicaName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubReplicaResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubReplicaResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WebPubSub.Models.WebPubSubSku> GetReplicaSkusWebPubSubs(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WebPubSub.Models.WebPubSubSku> GetReplicaSkusWebPubSubsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubReplicaSharedPrivateLinkResource> GetWebPubSubReplicaSharedPrivateLinkResource(string sharedPrivateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubReplicaSharedPrivateLinkResource>> GetWebPubSubReplicaSharedPrivateLinkResourceAsync(string sharedPrivateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.WebPubSub.WebPubSubReplicaSharedPrivateLinkResourceCollection GetWebPubSubReplicaSharedPrivateLinkResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubReplicaResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubReplicaResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Restart(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RestartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubReplicaResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubReplicaResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.WebPubSub.WebPubSubReplicaData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.WebPubSubReplicaData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.WebPubSubReplicaData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.WebPubSubReplicaData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.WebPubSubReplicaData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.WebPubSubReplicaData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.WebPubSubReplicaData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WebPubSub.WebPubSubReplicaResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.WebPubSub.WebPubSubReplicaData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WebPubSub.WebPubSubReplicaResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.WebPubSub.WebPubSubReplicaData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WebPubSubReplicaSharedPrivateLinkResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.WebPubSubSharedPrivateLinkData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.WebPubSubSharedPrivateLinkData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WebPubSubReplicaSharedPrivateLinkResource() { }
        public virtual Azure.ResourceManager.WebPubSub.WebPubSubSharedPrivateLinkData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string replicaName, string sharedPrivateLinkResourceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubReplicaSharedPrivateLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubReplicaSharedPrivateLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.WebPubSub.WebPubSubSharedPrivateLinkData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.WebPubSubSharedPrivateLinkData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.WebPubSubSharedPrivateLinkData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.WebPubSubSharedPrivateLinkData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.WebPubSubSharedPrivateLinkData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.WebPubSubSharedPrivateLinkData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.WebPubSubSharedPrivateLinkData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WebPubSub.WebPubSubReplicaSharedPrivateLinkResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.WebPubSub.WebPubSubSharedPrivateLinkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WebPubSub.WebPubSubReplicaSharedPrivateLinkResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.WebPubSub.WebPubSubSharedPrivateLinkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WebPubSubReplicaSharedPrivateLinkResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WebPubSub.WebPubSubReplicaSharedPrivateLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WebPubSub.WebPubSubReplicaSharedPrivateLinkResource>, System.Collections.IEnumerable
    {
        protected WebPubSubReplicaSharedPrivateLinkResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WebPubSub.WebPubSubReplicaSharedPrivateLinkResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string sharedPrivateLinkResourceName, Azure.ResourceManager.WebPubSub.WebPubSubSharedPrivateLinkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WebPubSub.WebPubSubReplicaSharedPrivateLinkResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string sharedPrivateLinkResourceName, Azure.ResourceManager.WebPubSub.WebPubSubSharedPrivateLinkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string sharedPrivateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string sharedPrivateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubReplicaSharedPrivateLinkResource> Get(string sharedPrivateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WebPubSub.WebPubSubReplicaSharedPrivateLinkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WebPubSub.WebPubSubReplicaSharedPrivateLinkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubReplicaSharedPrivateLinkResource>> GetAsync(string sharedPrivateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.WebPubSub.WebPubSubReplicaSharedPrivateLinkResource> GetIfExists(string sharedPrivateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.WebPubSub.WebPubSubReplicaSharedPrivateLinkResource>> GetIfExistsAsync(string sharedPrivateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.WebPubSub.WebPubSubReplicaSharedPrivateLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WebPubSub.WebPubSubReplicaSharedPrivateLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.WebPubSub.WebPubSubReplicaSharedPrivateLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.WebPubSub.WebPubSubReplicaSharedPrivateLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WebPubSubResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.WebPubSubData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.WebPubSubData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WebPubSubResource() { }
        public virtual Azure.ResourceManager.WebPubSub.WebPubSubData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.Models.WebPubSubKeys> GetKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.Models.WebPubSubKeys>> GetKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WebPubSub.Models.WebPubSubSku> GetSkus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WebPubSub.Models.WebPubSubSku> GetSkusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubCustomCertificateResource> GetWebPubSubCustomCertificate(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubCustomCertificateResource>> GetWebPubSubCustomCertificateAsync(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.WebPubSub.WebPubSubCustomCertificateCollection GetWebPubSubCustomCertificates() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubCustomDomainResource> GetWebPubSubCustomDomain(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubCustomDomainResource>> GetWebPubSubCustomDomainAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.WebPubSub.WebPubSubCustomDomainCollection GetWebPubSubCustomDomains() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubHubResource> GetWebPubSubHub(string hubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubHubResource>> GetWebPubSubHubAsync(string hubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.WebPubSub.WebPubSubHubCollection GetWebPubSubHubs() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubPrivateEndpointConnectionResource> GetWebPubSubPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubPrivateEndpointConnectionResource>> GetWebPubSubPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.WebPubSub.WebPubSubPrivateEndpointConnectionCollection GetWebPubSubPrivateEndpointConnections() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WebPubSub.Models.WebPubSubPrivateLink> GetWebPubSubPrivateLinkResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WebPubSub.Models.WebPubSubPrivateLink> GetWebPubSubPrivateLinkResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubReplicaResource> GetWebPubSubReplica(string replicaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubReplicaResource>> GetWebPubSubReplicaAsync(string replicaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.WebPubSub.WebPubSubReplicaCollection GetWebPubSubReplicas() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubSharedPrivateLinkResource> GetWebPubSubSharedPrivateLink(string sharedPrivateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubSharedPrivateLinkResource>> GetWebPubSubSharedPrivateLinkAsync(string sharedPrivateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.WebPubSub.WebPubSubSharedPrivateLinkCollection GetWebPubSubSharedPrivateLinks() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WebPubSub.Models.WebPubSubKeys> RegenerateKey(Azure.WaitUntil waitUntil, Azure.ResourceManager.WebPubSub.Models.WebPubSubRegenerateKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WebPubSub.Models.WebPubSubKeys>> RegenerateKeyAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.WebPubSub.Models.WebPubSubRegenerateKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Restart(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RestartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.WebPubSub.WebPubSubData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.WebPubSubData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.WebPubSubData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.WebPubSubData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.WebPubSubData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.WebPubSubData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.WebPubSubData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WebPubSub.WebPubSubResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.WebPubSub.WebPubSubData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WebPubSub.WebPubSubResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.WebPubSub.WebPubSubData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WebPubSubSharedPrivateLinkCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WebPubSub.WebPubSubSharedPrivateLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WebPubSub.WebPubSubSharedPrivateLinkResource>, System.Collections.IEnumerable
    {
        protected WebPubSubSharedPrivateLinkCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WebPubSub.WebPubSubSharedPrivateLinkResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string sharedPrivateLinkResourceName, Azure.ResourceManager.WebPubSub.WebPubSubSharedPrivateLinkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WebPubSub.WebPubSubSharedPrivateLinkResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string sharedPrivateLinkResourceName, Azure.ResourceManager.WebPubSub.WebPubSubSharedPrivateLinkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string sharedPrivateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string sharedPrivateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubSharedPrivateLinkResource> Get(string sharedPrivateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WebPubSub.WebPubSubSharedPrivateLinkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WebPubSub.WebPubSubSharedPrivateLinkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubSharedPrivateLinkResource>> GetAsync(string sharedPrivateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.WebPubSub.WebPubSubSharedPrivateLinkResource> GetIfExists(string sharedPrivateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.WebPubSub.WebPubSubSharedPrivateLinkResource>> GetIfExistsAsync(string sharedPrivateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.WebPubSub.WebPubSubSharedPrivateLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WebPubSub.WebPubSubSharedPrivateLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.WebPubSub.WebPubSubSharedPrivateLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.WebPubSub.WebPubSubSharedPrivateLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WebPubSubSharedPrivateLinkData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.WebPubSubSharedPrivateLinkData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.WebPubSubSharedPrivateLinkData>
    {
        public WebPubSubSharedPrivateLinkData() { }
        public System.Collections.Generic.IList<string> Fqdns { get { throw null; } }
        public string GroupId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrivateLinkResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.WebPubSub.Models.WebPubSubProvisioningState? ProvisioningState { get { throw null; } }
        public string RequestMessage { get { throw null; } set { } }
        public Azure.ResourceManager.WebPubSub.Models.WebPubSubSharedPrivateLinkStatus? Status { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.WebPubSubSharedPrivateLinkData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.WebPubSubSharedPrivateLinkData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.WebPubSubSharedPrivateLinkData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.WebPubSubSharedPrivateLinkData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.WebPubSubSharedPrivateLinkData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.WebPubSubSharedPrivateLinkData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.WebPubSubSharedPrivateLinkData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WebPubSubSharedPrivateLinkResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.WebPubSubSharedPrivateLinkData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.WebPubSubSharedPrivateLinkData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WebPubSubSharedPrivateLinkResource() { }
        public virtual Azure.ResourceManager.WebPubSub.WebPubSubSharedPrivateLinkData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string sharedPrivateLinkResourceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubSharedPrivateLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubSharedPrivateLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.WebPubSub.WebPubSubSharedPrivateLinkData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.WebPubSubSharedPrivateLinkData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.WebPubSubSharedPrivateLinkData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.WebPubSubSharedPrivateLinkData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.WebPubSubSharedPrivateLinkData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.WebPubSubSharedPrivateLinkData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.WebPubSubSharedPrivateLinkData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WebPubSub.WebPubSubSharedPrivateLinkResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.WebPubSub.WebPubSubSharedPrivateLinkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WebPubSub.WebPubSubSharedPrivateLinkResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.WebPubSub.WebPubSubSharedPrivateLinkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.WebPubSub.Mocking
{
    public partial class MockableWebPubSubArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableWebPubSubArmClient() { }
        public virtual Azure.ResourceManager.WebPubSub.WebPubSubCustomCertificateResource GetWebPubSubCustomCertificateResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.WebPubSub.WebPubSubCustomDomainResource GetWebPubSubCustomDomainResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.WebPubSub.WebPubSubHubResource GetWebPubSubHubResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.WebPubSub.WebPubSubPrivateEndpointConnectionResource GetWebPubSubPrivateEndpointConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.WebPubSub.WebPubSubReplicaResource GetWebPubSubReplicaResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.WebPubSub.WebPubSubReplicaSharedPrivateLinkResource GetWebPubSubReplicaSharedPrivateLinkResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.WebPubSub.WebPubSubResource GetWebPubSubResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.WebPubSub.WebPubSubSharedPrivateLinkResource GetWebPubSubSharedPrivateLinkResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableWebPubSubResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableWebPubSubResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubResource> GetWebPubSub(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubResource>> GetWebPubSubAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.WebPubSub.WebPubSubCollection GetWebPubSubs() { throw null; }
    }
    public partial class MockableWebPubSubSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableWebPubSubSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.Models.WebPubSubNameAvailability> CheckWebPubSubNameAvailability(Azure.Core.AzureLocation location, Azure.ResourceManager.WebPubSub.Models.WebPubSubNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.Models.WebPubSubNameAvailability>> CheckWebPubSubNameAvailabilityAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.WebPubSub.Models.WebPubSubNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WebPubSub.Models.SignalRServiceUsage> GetUsages(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WebPubSub.Models.SignalRServiceUsage> GetUsagesAsync(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WebPubSub.WebPubSubResource> GetWebPubSubs(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WebPubSub.WebPubSubResource> GetWebPubSubsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.WebPubSub.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AclAction : System.IEquatable<Azure.ResourceManager.WebPubSub.Models.AclAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AclAction(string value) { throw null; }
        public static Azure.ResourceManager.WebPubSub.Models.AclAction Allow { get { throw null; } }
        public static Azure.ResourceManager.WebPubSub.Models.AclAction Deny { get { throw null; } }
        public bool Equals(Azure.ResourceManager.WebPubSub.Models.AclAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WebPubSub.Models.AclAction left, Azure.ResourceManager.WebPubSub.Models.AclAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.WebPubSub.Models.AclAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WebPubSub.Models.AclAction left, Azure.ResourceManager.WebPubSub.Models.AclAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ApplicationFirewallSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.ApplicationFirewallSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.ApplicationFirewallSettings>
    {
        public ApplicationFirewallSettings() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.WebPubSub.Models.ClientConnectionCountRule> ClientConnectionCountRules { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.WebPubSub.Models.ClientTrafficControlRule> ClientTrafficControlRules { get { throw null; } }
        public long? MaxClientConnectionLifetimeInSeconds { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.ApplicationFirewallSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.ApplicationFirewallSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.ApplicationFirewallSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.ApplicationFirewallSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.ApplicationFirewallSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.ApplicationFirewallSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.ApplicationFirewallSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ArmWebPubSubModelFactory
    {
        public static Azure.ResourceManager.WebPubSub.Models.BillingInfoSku BillingInfoSku(string name = null, Azure.ResourceManager.WebPubSub.Models.WebPubSubSkuTier? tier = default(Azure.ResourceManager.WebPubSub.Models.WebPubSubSkuTier?), string size = null, string family = null, int? capacity = default(int?)) { throw null; }
        public static Azure.ResourceManager.WebPubSub.Models.SignalRServiceUsage SignalRServiceUsage(Azure.Core.ResourceIdentifier id = null, long? currentValue = default(long?), long? limit = default(long?), Azure.ResourceManager.WebPubSub.Models.SignalRServiceUsageName name = null, string unit = null) { throw null; }
        public static Azure.ResourceManager.WebPubSub.Models.SignalRServiceUsageName SignalRServiceUsageName(string value = null, string localizedValue = null) { throw null; }
        public static Azure.ResourceManager.WebPubSub.WebPubSubCustomCertificateData WebPubSubCustomCertificateData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.WebPubSub.Models.WebPubSubProvisioningState? provisioningState = default(Azure.ResourceManager.WebPubSub.Models.WebPubSubProvisioningState?), System.Uri keyVaultBaseUri = null, string keyVaultSecretName = null, string keyVaultSecretVersion = null) { throw null; }
        public static Azure.ResourceManager.WebPubSub.WebPubSubCustomDomainData WebPubSubCustomDomainData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.WebPubSub.Models.WebPubSubProvisioningState? provisioningState = default(Azure.ResourceManager.WebPubSub.Models.WebPubSubProvisioningState?), string domainName = null, Azure.Core.ResourceIdentifier customCertificateId = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.WebPubSub.WebPubSubData WebPubSubData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ResourceManager.WebPubSub.Models.BillingInfoSku sku, Azure.ResourceManager.Models.ManagedServiceIdentity identity, Azure.ResourceManager.WebPubSub.Models.WebPubSubProvisioningState? provisioningState, string externalIP, string hostName, int? publicPort, int? serverPort, string version, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WebPubSub.WebPubSubPrivateEndpointConnectionData> privateEndpointConnections, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WebPubSub.WebPubSubSharedPrivateLinkData> sharedPrivateLinkResources, bool? isClientCertEnabled, string hostNamePrefix, Azure.ResourceManager.WebPubSub.Models.LiveTraceConfiguration liveTraceConfiguration, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WebPubSub.Models.ResourceLogCategory> resourceLogCategories, Azure.ResourceManager.WebPubSub.Models.WebPubSubNetworkAcls networkAcls, string publicNetworkAccess, bool? isLocalAuthDisabled, bool? isAadAuthDisabled) { throw null; }
        public static Azure.ResourceManager.WebPubSub.WebPubSubData WebPubSubData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.WebPubSub.Models.BillingInfoSku sku = null, Azure.ResourceManager.WebPubSub.Models.WebPubSubServiceKind? kind = default(Azure.ResourceManager.WebPubSub.Models.WebPubSubServiceKind?), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.WebPubSub.Models.WebPubSubProvisioningState? provisioningState = default(Azure.ResourceManager.WebPubSub.Models.WebPubSubProvisioningState?), string externalIP = null, string hostName = null, int? publicPort = default(int?), int? serverPort = default(int?), string version = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WebPubSub.WebPubSubPrivateEndpointConnectionData> privateEndpointConnections = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WebPubSub.WebPubSubSharedPrivateLinkData> sharedPrivateLinkResources = null, bool? isClientCertEnabled = default(bool?), string hostNamePrefix = null, Azure.ResourceManager.WebPubSub.Models.LiveTraceConfiguration liveTraceConfiguration = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WebPubSub.Models.ResourceLogCategory> resourceLogCategories = null, Azure.ResourceManager.WebPubSub.Models.WebPubSubNetworkAcls networkAcls = null, Azure.ResourceManager.WebPubSub.Models.ApplicationFirewallSettings applicationFirewall = null, string publicNetworkAccess = null, bool? isLocalAuthDisabled = default(bool?), bool? isAadAuthDisabled = default(bool?), string regionEndpointEnabled = null, string resourceStopped = null, string socketIOServiceMode = null) { throw null; }
        public static Azure.ResourceManager.WebPubSub.WebPubSubHubData WebPubSubHubData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.WebPubSub.Models.WebPubSubHubProperties properties = null) { throw null; }
        public static Azure.ResourceManager.WebPubSub.Models.WebPubSubKeys WebPubSubKeys(string primaryKey = null, string secondaryKey = null, string primaryConnectionString = null, string secondaryConnectionString = null) { throw null; }
        public static Azure.ResourceManager.WebPubSub.Models.WebPubSubNameAvailability WebPubSubNameAvailability(bool? nameAvailable = default(bool?), string reason = null, string message = null) { throw null; }
        public static Azure.ResourceManager.WebPubSub.WebPubSubPrivateEndpointConnectionData WebPubSubPrivateEndpointConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.WebPubSub.Models.WebPubSubProvisioningState? provisioningState = default(Azure.ResourceManager.WebPubSub.Models.WebPubSubProvisioningState?), Azure.Core.ResourceIdentifier privateEndpointId = null, System.Collections.Generic.IEnumerable<string> groupIds = null, Azure.ResourceManager.WebPubSub.Models.WebPubSubPrivateLinkServiceConnectionState connectionState = null) { throw null; }
        public static Azure.ResourceManager.WebPubSub.Models.WebPubSubPrivateLink WebPubSubPrivateLink(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string groupId = null, System.Collections.Generic.IEnumerable<string> requiredMembers = null, System.Collections.Generic.IEnumerable<string> requiredZoneNames = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WebPubSub.Models.ShareablePrivateLinkType> shareablePrivateLinkTypes = null) { throw null; }
        public static Azure.ResourceManager.WebPubSub.WebPubSubReplicaData WebPubSubReplicaData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.WebPubSub.Models.BillingInfoSku sku = null, Azure.ResourceManager.WebPubSub.Models.WebPubSubProvisioningState? provisioningState = default(Azure.ResourceManager.WebPubSub.Models.WebPubSubProvisioningState?), string regionEndpointEnabled = null, string resourceStopped = null) { throw null; }
        public static Azure.ResourceManager.WebPubSub.WebPubSubSharedPrivateLinkData WebPubSubSharedPrivateLinkData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string groupId = null, Azure.Core.ResourceIdentifier privateLinkResourceId = null, Azure.ResourceManager.WebPubSub.Models.WebPubSubProvisioningState? provisioningState = default(Azure.ResourceManager.WebPubSub.Models.WebPubSubProvisioningState?), string requestMessage = null, System.Collections.Generic.IEnumerable<string> fqdns = null, Azure.ResourceManager.WebPubSub.Models.WebPubSubSharedPrivateLinkStatus? status = default(Azure.ResourceManager.WebPubSub.Models.WebPubSubSharedPrivateLinkStatus?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.WebPubSub.WebPubSubSharedPrivateLinkData WebPubSubSharedPrivateLinkData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, string groupId, Azure.Core.ResourceIdentifier privateLinkResourceId, Azure.ResourceManager.WebPubSub.Models.WebPubSubProvisioningState? provisioningState, string requestMessage, Azure.ResourceManager.WebPubSub.Models.WebPubSubSharedPrivateLinkStatus? status) { throw null; }
        public static Azure.ResourceManager.WebPubSub.Models.WebPubSubSku WebPubSubSku(Azure.Core.ResourceType? resourceType = default(Azure.Core.ResourceType?), Azure.ResourceManager.WebPubSub.Models.BillingInfoSku sku = null, Azure.ResourceManager.WebPubSub.Models.WebPubSubSkuCapacity capacity = null) { throw null; }
        public static Azure.ResourceManager.WebPubSub.Models.WebPubSubSkuCapacity WebPubSubSkuCapacity(int? minimum = default(int?), int? maximum = default(int?), int? @default = default(int?), System.Collections.Generic.IEnumerable<int> allowedValues = null, Azure.ResourceManager.WebPubSub.Models.WebPubSubScaleType? scaleType = default(Azure.ResourceManager.WebPubSub.Models.WebPubSubScaleType?)) { throw null; }
    }
    public partial class BillingInfoSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.BillingInfoSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.BillingInfoSku>
    {
        public BillingInfoSku(string name) { }
        public int? Capacity { get { throw null; } set { } }
        public string Family { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public string Size { get { throw null; } }
        public Azure.ResourceManager.WebPubSub.Models.WebPubSubSkuTier? Tier { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.BillingInfoSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.BillingInfoSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.BillingInfoSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.BillingInfoSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.BillingInfoSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.BillingInfoSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.BillingInfoSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ClientConnectionCountRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.ClientConnectionCountRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.ClientConnectionCountRule>
    {
        protected ClientConnectionCountRule() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.ClientConnectionCountRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.ClientConnectionCountRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.ClientConnectionCountRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.ClientConnectionCountRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.ClientConnectionCountRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.ClientConnectionCountRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.ClientConnectionCountRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ClientTrafficControlRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.ClientTrafficControlRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.ClientTrafficControlRule>
    {
        protected ClientTrafficControlRule() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.ClientTrafficControlRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.ClientTrafficControlRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.ClientTrafficControlRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.ClientTrafficControlRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.ClientTrafficControlRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.ClientTrafficControlRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.ClientTrafficControlRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class EventListenerEndpoint : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.EventListenerEndpoint>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.EventListenerEndpoint>
    {
        protected EventListenerEndpoint() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.EventListenerEndpoint System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.EventListenerEndpoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.EventListenerEndpoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.EventListenerEndpoint System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.EventListenerEndpoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.EventListenerEndpoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.EventListenerEndpoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class EventListenerFilter : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.EventListenerFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.EventListenerFilter>
    {
        protected EventListenerFilter() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.EventListenerFilter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.EventListenerFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.EventListenerFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.EventListenerFilter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.EventListenerFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.EventListenerFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.EventListenerFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EventNameFilter : Azure.ResourceManager.WebPubSub.Models.EventListenerFilter, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.EventNameFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.EventNameFilter>
    {
        public EventNameFilter() { }
        public System.Collections.Generic.IList<string> SystemEvents { get { throw null; } }
        public string UserEventPattern { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.EventNameFilter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.EventNameFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.EventNameFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.EventNameFilter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.EventNameFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.EventNameFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.EventNameFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LiveTraceCategory : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.LiveTraceCategory>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.LiveTraceCategory>
    {
        public LiveTraceCategory() { }
        public bool? IsEnabled { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.LiveTraceCategory System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.LiveTraceCategory>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.LiveTraceCategory>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.LiveTraceCategory System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.LiveTraceCategory>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.LiveTraceCategory>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.LiveTraceCategory>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LiveTraceConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.LiveTraceConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.LiveTraceConfiguration>
    {
        public LiveTraceConfiguration() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.WebPubSub.Models.LiveTraceCategory> Categories { get { throw null; } }
        public bool? IsEnabled { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.LiveTraceConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.LiveTraceConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.LiveTraceConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.LiveTraceConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.LiveTraceConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.LiveTraceConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.LiveTraceConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PrivateEndpointAcl : Azure.ResourceManager.WebPubSub.Models.PublicNetworkAcls, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.PrivateEndpointAcl>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.PrivateEndpointAcl>
    {
        public PrivateEndpointAcl(string name) { }
        public string Name { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.PrivateEndpointAcl System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.PrivateEndpointAcl>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.PrivateEndpointAcl>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.PrivateEndpointAcl System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.PrivateEndpointAcl>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.PrivateEndpointAcl>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.PrivateEndpointAcl>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PublicNetworkAcls : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.PublicNetworkAcls>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.PublicNetworkAcls>
    {
        public PublicNetworkAcls() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.WebPubSub.Models.WebPubSubRequestType> Allow { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.WebPubSub.Models.WebPubSubRequestType> Deny { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.PublicNetworkAcls System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.PublicNetworkAcls>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.PublicNetworkAcls>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.PublicNetworkAcls System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.PublicNetworkAcls>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.PublicNetworkAcls>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.PublicNetworkAcls>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PublicTrafficIPRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.PublicTrafficIPRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.PublicTrafficIPRule>
    {
        public PublicTrafficIPRule() { }
        public Azure.ResourceManager.WebPubSub.Models.AclAction? Action { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.PublicTrafficIPRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.PublicTrafficIPRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.PublicTrafficIPRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.PublicTrafficIPRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.PublicTrafficIPRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.PublicTrafficIPRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.PublicTrafficIPRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceLogCategory : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.ResourceLogCategory>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.ResourceLogCategory>
    {
        public ResourceLogCategory() { }
        public string Enabled { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.ResourceLogCategory System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.ResourceLogCategory>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.ResourceLogCategory>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.ResourceLogCategory System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.ResourceLogCategory>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.ResourceLogCategory>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.ResourceLogCategory>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ShareablePrivateLinkProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.ShareablePrivateLinkProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.ShareablePrivateLinkProperties>
    {
        public ShareablePrivateLinkProperties() { }
        public string Description { get { throw null; } set { } }
        public string GroupId { get { throw null; } set { } }
        public string ShareablePrivateLinkPropertiesType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.ShareablePrivateLinkProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.ShareablePrivateLinkProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.ShareablePrivateLinkProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.ShareablePrivateLinkProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.ShareablePrivateLinkProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.ShareablePrivateLinkProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.ShareablePrivateLinkProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ShareablePrivateLinkType : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.ShareablePrivateLinkType>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.ShareablePrivateLinkType>
    {
        public ShareablePrivateLinkType() { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.WebPubSub.Models.ShareablePrivateLinkProperties Properties { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.ShareablePrivateLinkType System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.ShareablePrivateLinkType>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.ShareablePrivateLinkType>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.ShareablePrivateLinkType System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.ShareablePrivateLinkType>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.ShareablePrivateLinkType>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.ShareablePrivateLinkType>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SignalRServiceUsage : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.SignalRServiceUsage>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.SignalRServiceUsage>
    {
        internal SignalRServiceUsage() { }
        public long? CurrentValue { get { throw null; } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public long? Limit { get { throw null; } }
        public Azure.ResourceManager.WebPubSub.Models.SignalRServiceUsageName Name { get { throw null; } }
        public string Unit { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.SignalRServiceUsage System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.SignalRServiceUsage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.SignalRServiceUsage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.SignalRServiceUsage System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.SignalRServiceUsage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.SignalRServiceUsage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.SignalRServiceUsage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SignalRServiceUsageName : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.SignalRServiceUsageName>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.SignalRServiceUsageName>
    {
        internal SignalRServiceUsageName() { }
        public string LocalizedValue { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.SignalRServiceUsageName System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.SignalRServiceUsageName>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.SignalRServiceUsageName>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.SignalRServiceUsageName System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.SignalRServiceUsageName>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.SignalRServiceUsageName>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.SignalRServiceUsageName>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ThrottleByJwtCustomClaimRule : Azure.ResourceManager.WebPubSub.Models.ClientConnectionCountRule, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.ThrottleByJwtCustomClaimRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.ThrottleByJwtCustomClaimRule>
    {
        public ThrottleByJwtCustomClaimRule(string claimName) { }
        public string ClaimName { get { throw null; } set { } }
        public int? MaxCount { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.ThrottleByJwtCustomClaimRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.ThrottleByJwtCustomClaimRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.ThrottleByJwtCustomClaimRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.ThrottleByJwtCustomClaimRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.ThrottleByJwtCustomClaimRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.ThrottleByJwtCustomClaimRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.ThrottleByJwtCustomClaimRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ThrottleByJwtSignatureRule : Azure.ResourceManager.WebPubSub.Models.ClientConnectionCountRule, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.ThrottleByJwtSignatureRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.ThrottleByJwtSignatureRule>
    {
        public ThrottleByJwtSignatureRule() { }
        public int? MaxCount { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.ThrottleByJwtSignatureRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.ThrottleByJwtSignatureRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.ThrottleByJwtSignatureRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.ThrottleByJwtSignatureRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.ThrottleByJwtSignatureRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.ThrottleByJwtSignatureRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.ThrottleByJwtSignatureRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ThrottleByUserIdRule : Azure.ResourceManager.WebPubSub.Models.ClientConnectionCountRule, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.ThrottleByUserIdRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.ThrottleByUserIdRule>
    {
        public ThrottleByUserIdRule() { }
        public int? MaxCount { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.ThrottleByUserIdRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.ThrottleByUserIdRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.ThrottleByUserIdRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.ThrottleByUserIdRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.ThrottleByUserIdRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.ThrottleByUserIdRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.ThrottleByUserIdRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TrafficThrottleByJwtCustomClaimRule : Azure.ResourceManager.WebPubSub.Models.ClientTrafficControlRule, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.TrafficThrottleByJwtCustomClaimRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.TrafficThrottleByJwtCustomClaimRule>
    {
        public TrafficThrottleByJwtCustomClaimRule(string claimName) { }
        public int? AggregationWindowInSeconds { get { throw null; } set { } }
        public string ClaimName { get { throw null; } set { } }
        public long? MaxInboundMessageBytes { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.TrafficThrottleByJwtCustomClaimRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.TrafficThrottleByJwtCustomClaimRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.TrafficThrottleByJwtCustomClaimRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.TrafficThrottleByJwtCustomClaimRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.TrafficThrottleByJwtCustomClaimRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.TrafficThrottleByJwtCustomClaimRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.TrafficThrottleByJwtCustomClaimRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TrafficThrottleByJwtSignatureRule : Azure.ResourceManager.WebPubSub.Models.ClientTrafficControlRule, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.TrafficThrottleByJwtSignatureRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.TrafficThrottleByJwtSignatureRule>
    {
        public TrafficThrottleByJwtSignatureRule() { }
        public int? AggregationWindowInSeconds { get { throw null; } set { } }
        public long? MaxInboundMessageBytes { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.TrafficThrottleByJwtSignatureRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.TrafficThrottleByJwtSignatureRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.TrafficThrottleByJwtSignatureRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.TrafficThrottleByJwtSignatureRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.TrafficThrottleByJwtSignatureRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.TrafficThrottleByJwtSignatureRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.TrafficThrottleByJwtSignatureRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TrafficThrottleByUserIdRule : Azure.ResourceManager.WebPubSub.Models.ClientTrafficControlRule, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.TrafficThrottleByUserIdRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.TrafficThrottleByUserIdRule>
    {
        public TrafficThrottleByUserIdRule() { }
        public int? AggregationWindowInSeconds { get { throw null; } set { } }
        public long? MaxInboundMessageBytes { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.TrafficThrottleByUserIdRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.TrafficThrottleByUserIdRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.TrafficThrottleByUserIdRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.TrafficThrottleByUserIdRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.TrafficThrottleByUserIdRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.TrafficThrottleByUserIdRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.TrafficThrottleByUserIdRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UpstreamAuthSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.UpstreamAuthSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.UpstreamAuthSettings>
    {
        public UpstreamAuthSettings() { }
        public Azure.ResourceManager.WebPubSub.Models.UpstreamAuthType? AuthType { get { throw null; } set { } }
        public string ManagedIdentityResource { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.UpstreamAuthSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.UpstreamAuthSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.UpstreamAuthSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.UpstreamAuthSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.UpstreamAuthSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.UpstreamAuthSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.UpstreamAuthSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UpstreamAuthType : System.IEquatable<Azure.ResourceManager.WebPubSub.Models.UpstreamAuthType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UpstreamAuthType(string value) { throw null; }
        public static Azure.ResourceManager.WebPubSub.Models.UpstreamAuthType ManagedIdentity { get { throw null; } }
        public static Azure.ResourceManager.WebPubSub.Models.UpstreamAuthType None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.WebPubSub.Models.UpstreamAuthType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WebPubSub.Models.UpstreamAuthType left, Azure.ResourceManager.WebPubSub.Models.UpstreamAuthType right) { throw null; }
        public static implicit operator Azure.ResourceManager.WebPubSub.Models.UpstreamAuthType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WebPubSub.Models.UpstreamAuthType left, Azure.ResourceManager.WebPubSub.Models.UpstreamAuthType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WebPubSubEventHandler : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubEventHandler>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubEventHandler>
    {
        public WebPubSubEventHandler(string urlTemplate) { }
        public Azure.ResourceManager.WebPubSub.Models.UpstreamAuthSettings Auth { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SystemEvents { get { throw null; } }
        public string UrlTemplate { get { throw null; } set { } }
        public string UserEventPattern { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.WebPubSubEventHandler System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubEventHandler>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubEventHandler>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.WebPubSubEventHandler System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubEventHandler>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubEventHandler>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubEventHandler>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WebPubSubEventHubEndpoint : Azure.ResourceManager.WebPubSub.Models.EventListenerEndpoint, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubEventHubEndpoint>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubEventHubEndpoint>
    {
        public WebPubSubEventHubEndpoint(string fullyQualifiedNamespace, string eventHubName) { }
        public string EventHubName { get { throw null; } set { } }
        public string FullyQualifiedNamespace { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.WebPubSubEventHubEndpoint System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubEventHubEndpoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubEventHubEndpoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.WebPubSubEventHubEndpoint System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubEventHubEndpoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubEventHubEndpoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubEventHubEndpoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WebPubSubEventListener : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubEventListener>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubEventListener>
    {
        public WebPubSubEventListener(Azure.ResourceManager.WebPubSub.Models.EventListenerFilter filter, Azure.ResourceManager.WebPubSub.Models.EventListenerEndpoint endpoint) { }
        public Azure.ResourceManager.WebPubSub.Models.EventListenerEndpoint Endpoint { get { throw null; } set { } }
        public Azure.ResourceManager.WebPubSub.Models.EventListenerFilter Filter { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.WebPubSubEventListener System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubEventListener>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubEventListener>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.WebPubSubEventListener System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubEventListener>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubEventListener>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubEventListener>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WebPubSubHubProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubHubProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubHubProperties>
    {
        public WebPubSubHubProperties() { }
        public string AnonymousConnectPolicy { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.WebPubSub.Models.WebPubSubEventHandler> EventHandlers { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.WebPubSub.Models.WebPubSubEventListener> EventListeners { get { throw null; } }
        public int? WebSocketKeepAliveIntervalInSeconds { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.WebPubSubHubProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubHubProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubHubProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.WebPubSubHubProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubHubProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubHubProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubHubProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WebPubSubKeys : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubKeys>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubKeys>
    {
        internal WebPubSubKeys() { }
        public string PrimaryConnectionString { get { throw null; } }
        public string PrimaryKey { get { throw null; } }
        public string SecondaryConnectionString { get { throw null; } }
        public string SecondaryKey { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.WebPubSubKeys System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubKeys>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubKeys>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.WebPubSubKeys System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubKeys>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubKeys>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubKeys>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WebPubSubKeyType : System.IEquatable<Azure.ResourceManager.WebPubSub.Models.WebPubSubKeyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WebPubSubKeyType(string value) { throw null; }
        public static Azure.ResourceManager.WebPubSub.Models.WebPubSubKeyType Primary { get { throw null; } }
        public static Azure.ResourceManager.WebPubSub.Models.WebPubSubKeyType Salt { get { throw null; } }
        public static Azure.ResourceManager.WebPubSub.Models.WebPubSubKeyType Secondary { get { throw null; } }
        public bool Equals(Azure.ResourceManager.WebPubSub.Models.WebPubSubKeyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WebPubSub.Models.WebPubSubKeyType left, Azure.ResourceManager.WebPubSub.Models.WebPubSubKeyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.WebPubSub.Models.WebPubSubKeyType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WebPubSub.Models.WebPubSubKeyType left, Azure.ResourceManager.WebPubSub.Models.WebPubSubKeyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WebPubSubNameAvailability : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubNameAvailability>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubNameAvailability>
    {
        internal WebPubSubNameAvailability() { }
        public string Message { get { throw null; } }
        public bool? NameAvailable { get { throw null; } }
        public string Reason { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.WebPubSubNameAvailability System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubNameAvailability>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubNameAvailability>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.WebPubSubNameAvailability System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubNameAvailability>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubNameAvailability>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubNameAvailability>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WebPubSubNameAvailabilityContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubNameAvailabilityContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubNameAvailabilityContent>
    {
        public WebPubSubNameAvailabilityContent(string resourceType, string name) { }
        public string Name { get { throw null; } }
        public string ResourceType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.WebPubSubNameAvailabilityContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubNameAvailabilityContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubNameAvailabilityContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.WebPubSubNameAvailabilityContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubNameAvailabilityContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubNameAvailabilityContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubNameAvailabilityContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WebPubSubNetworkAcls : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubNetworkAcls>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubNetworkAcls>
    {
        public WebPubSubNetworkAcls() { }
        public Azure.ResourceManager.WebPubSub.Models.AclAction? DefaultAction { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.WebPubSub.Models.PublicTrafficIPRule> IPRules { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.WebPubSub.Models.PrivateEndpointAcl> PrivateEndpoints { get { throw null; } }
        public Azure.ResourceManager.WebPubSub.Models.PublicNetworkAcls PublicNetwork { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.WebPubSubNetworkAcls System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubNetworkAcls>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubNetworkAcls>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.WebPubSubNetworkAcls System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubNetworkAcls>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubNetworkAcls>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubNetworkAcls>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WebPubSubPrivateLink : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubPrivateLink>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubPrivateLink>
    {
        public WebPubSubPrivateLink() { }
        public string GroupId { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredZoneNames { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.WebPubSub.Models.ShareablePrivateLinkType> ShareablePrivateLinkTypes { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.WebPubSubPrivateLink System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubPrivateLink>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubPrivateLink>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.WebPubSubPrivateLink System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubPrivateLink>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubPrivateLink>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubPrivateLink>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WebPubSubPrivateLinkServiceConnectionState : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubPrivateLinkServiceConnectionState>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubPrivateLinkServiceConnectionState>
    {
        public WebPubSubPrivateLinkServiceConnectionState() { }
        public string ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.WebPubSub.Models.WebPubSubPrivateLinkServiceConnectionStatus? Status { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.WebPubSubPrivateLinkServiceConnectionState System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubPrivateLinkServiceConnectionState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubPrivateLinkServiceConnectionState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.WebPubSubPrivateLinkServiceConnectionState System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubPrivateLinkServiceConnectionState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubPrivateLinkServiceConnectionState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubPrivateLinkServiceConnectionState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WebPubSubPrivateLinkServiceConnectionStatus : System.IEquatable<Azure.ResourceManager.WebPubSub.Models.WebPubSubPrivateLinkServiceConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WebPubSubPrivateLinkServiceConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.WebPubSub.Models.WebPubSubPrivateLinkServiceConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.WebPubSub.Models.WebPubSubPrivateLinkServiceConnectionStatus Disconnected { get { throw null; } }
        public static Azure.ResourceManager.WebPubSub.Models.WebPubSubPrivateLinkServiceConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.WebPubSub.Models.WebPubSubPrivateLinkServiceConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.WebPubSub.Models.WebPubSubPrivateLinkServiceConnectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WebPubSub.Models.WebPubSubPrivateLinkServiceConnectionStatus left, Azure.ResourceManager.WebPubSub.Models.WebPubSubPrivateLinkServiceConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.WebPubSub.Models.WebPubSubPrivateLinkServiceConnectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WebPubSub.Models.WebPubSubPrivateLinkServiceConnectionStatus left, Azure.ResourceManager.WebPubSub.Models.WebPubSubPrivateLinkServiceConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WebPubSubProvisioningState : System.IEquatable<Azure.ResourceManager.WebPubSub.Models.WebPubSubProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WebPubSubProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.WebPubSub.Models.WebPubSubProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.WebPubSub.Models.WebPubSubProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.WebPubSub.Models.WebPubSubProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.WebPubSub.Models.WebPubSubProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.WebPubSub.Models.WebPubSubProvisioningState Moving { get { throw null; } }
        public static Azure.ResourceManager.WebPubSub.Models.WebPubSubProvisioningState Running { get { throw null; } }
        public static Azure.ResourceManager.WebPubSub.Models.WebPubSubProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.WebPubSub.Models.WebPubSubProvisioningState Unknown { get { throw null; } }
        public static Azure.ResourceManager.WebPubSub.Models.WebPubSubProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.WebPubSub.Models.WebPubSubProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WebPubSub.Models.WebPubSubProvisioningState left, Azure.ResourceManager.WebPubSub.Models.WebPubSubProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.WebPubSub.Models.WebPubSubProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WebPubSub.Models.WebPubSubProvisioningState left, Azure.ResourceManager.WebPubSub.Models.WebPubSubProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WebPubSubRegenerateKeyContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubRegenerateKeyContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubRegenerateKeyContent>
    {
        public WebPubSubRegenerateKeyContent() { }
        public Azure.ResourceManager.WebPubSub.Models.WebPubSubKeyType? KeyType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.WebPubSubRegenerateKeyContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubRegenerateKeyContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubRegenerateKeyContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.WebPubSubRegenerateKeyContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubRegenerateKeyContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubRegenerateKeyContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubRegenerateKeyContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WebPubSubRequestType : System.IEquatable<Azure.ResourceManager.WebPubSub.Models.WebPubSubRequestType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WebPubSubRequestType(string value) { throw null; }
        public static Azure.ResourceManager.WebPubSub.Models.WebPubSubRequestType ClientConnection { get { throw null; } }
        public static Azure.ResourceManager.WebPubSub.Models.WebPubSubRequestType RestApi { get { throw null; } }
        public static Azure.ResourceManager.WebPubSub.Models.WebPubSubRequestType ServerConnection { get { throw null; } }
        public static Azure.ResourceManager.WebPubSub.Models.WebPubSubRequestType Trace { get { throw null; } }
        public bool Equals(Azure.ResourceManager.WebPubSub.Models.WebPubSubRequestType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WebPubSub.Models.WebPubSubRequestType left, Azure.ResourceManager.WebPubSub.Models.WebPubSubRequestType right) { throw null; }
        public static implicit operator Azure.ResourceManager.WebPubSub.Models.WebPubSubRequestType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WebPubSub.Models.WebPubSubRequestType left, Azure.ResourceManager.WebPubSub.Models.WebPubSubRequestType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WebPubSubScaleType : System.IEquatable<Azure.ResourceManager.WebPubSub.Models.WebPubSubScaleType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WebPubSubScaleType(string value) { throw null; }
        public static Azure.ResourceManager.WebPubSub.Models.WebPubSubScaleType Automatic { get { throw null; } }
        public static Azure.ResourceManager.WebPubSub.Models.WebPubSubScaleType Manual { get { throw null; } }
        public static Azure.ResourceManager.WebPubSub.Models.WebPubSubScaleType None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.WebPubSub.Models.WebPubSubScaleType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WebPubSub.Models.WebPubSubScaleType left, Azure.ResourceManager.WebPubSub.Models.WebPubSubScaleType right) { throw null; }
        public static implicit operator Azure.ResourceManager.WebPubSub.Models.WebPubSubScaleType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WebPubSub.Models.WebPubSubScaleType left, Azure.ResourceManager.WebPubSub.Models.WebPubSubScaleType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WebPubSubServiceKind : System.IEquatable<Azure.ResourceManager.WebPubSub.Models.WebPubSubServiceKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WebPubSubServiceKind(string value) { throw null; }
        public static Azure.ResourceManager.WebPubSub.Models.WebPubSubServiceKind SocketIO { get { throw null; } }
        public static Azure.ResourceManager.WebPubSub.Models.WebPubSubServiceKind WebPubSub { get { throw null; } }
        public bool Equals(Azure.ResourceManager.WebPubSub.Models.WebPubSubServiceKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WebPubSub.Models.WebPubSubServiceKind left, Azure.ResourceManager.WebPubSub.Models.WebPubSubServiceKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.WebPubSub.Models.WebPubSubServiceKind (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WebPubSub.Models.WebPubSubServiceKind left, Azure.ResourceManager.WebPubSub.Models.WebPubSubServiceKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WebPubSubSharedPrivateLinkStatus : System.IEquatable<Azure.ResourceManager.WebPubSub.Models.WebPubSubSharedPrivateLinkStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WebPubSubSharedPrivateLinkStatus(string value) { throw null; }
        public static Azure.ResourceManager.WebPubSub.Models.WebPubSubSharedPrivateLinkStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.WebPubSub.Models.WebPubSubSharedPrivateLinkStatus Disconnected { get { throw null; } }
        public static Azure.ResourceManager.WebPubSub.Models.WebPubSubSharedPrivateLinkStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.WebPubSub.Models.WebPubSubSharedPrivateLinkStatus Rejected { get { throw null; } }
        public static Azure.ResourceManager.WebPubSub.Models.WebPubSubSharedPrivateLinkStatus Timeout { get { throw null; } }
        public bool Equals(Azure.ResourceManager.WebPubSub.Models.WebPubSubSharedPrivateLinkStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WebPubSub.Models.WebPubSubSharedPrivateLinkStatus left, Azure.ResourceManager.WebPubSub.Models.WebPubSubSharedPrivateLinkStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.WebPubSub.Models.WebPubSubSharedPrivateLinkStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WebPubSub.Models.WebPubSubSharedPrivateLinkStatus left, Azure.ResourceManager.WebPubSub.Models.WebPubSubSharedPrivateLinkStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WebPubSubSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubSku>
    {
        internal WebPubSubSku() { }
        public Azure.ResourceManager.WebPubSub.Models.WebPubSubSkuCapacity Capacity { get { throw null; } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } }
        public Azure.ResourceManager.WebPubSub.Models.BillingInfoSku Sku { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.WebPubSubSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.WebPubSubSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WebPubSubSkuCapacity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubSkuCapacity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubSkuCapacity>
    {
        internal WebPubSubSkuCapacity() { }
        public System.Collections.Generic.IReadOnlyList<int> AllowedValues { get { throw null; } }
        public int? Default { get { throw null; } }
        public int? Maximum { get { throw null; } }
        public int? Minimum { get { throw null; } }
        public Azure.ResourceManager.WebPubSub.Models.WebPubSubScaleType? ScaleType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.WebPubSubSkuCapacity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubSkuCapacity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubSkuCapacity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.WebPubSubSkuCapacity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubSkuCapacity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubSkuCapacity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubSkuCapacity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WebPubSubSkuTier : System.IEquatable<Azure.ResourceManager.WebPubSub.Models.WebPubSubSkuTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WebPubSubSkuTier(string value) { throw null; }
        public static Azure.ResourceManager.WebPubSub.Models.WebPubSubSkuTier Basic { get { throw null; } }
        public static Azure.ResourceManager.WebPubSub.Models.WebPubSubSkuTier Free { get { throw null; } }
        public static Azure.ResourceManager.WebPubSub.Models.WebPubSubSkuTier Premium { get { throw null; } }
        public static Azure.ResourceManager.WebPubSub.Models.WebPubSubSkuTier Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.WebPubSub.Models.WebPubSubSkuTier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WebPubSub.Models.WebPubSubSkuTier left, Azure.ResourceManager.WebPubSub.Models.WebPubSubSkuTier right) { throw null; }
        public static implicit operator Azure.ResourceManager.WebPubSub.Models.WebPubSubSkuTier (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WebPubSub.Models.WebPubSubSkuTier left, Azure.ResourceManager.WebPubSub.Models.WebPubSubSkuTier right) { throw null; }
        public override string ToString() { throw null; }
    }
}
