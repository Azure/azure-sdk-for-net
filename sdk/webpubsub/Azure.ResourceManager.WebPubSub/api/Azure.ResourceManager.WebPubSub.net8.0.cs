namespace Azure.ResourceManager.WebPubSub
{
    public partial class AzureResourceManagerWebPubSubContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerWebPubSubContext() { }
        public static Azure.ResourceManager.WebPubSub.AzureResourceManagerWebPubSubContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class CustomCertificateCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WebPubSub.CustomCertificateResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WebPubSub.CustomCertificateResource>, System.Collections.IEnumerable
    {
        protected CustomCertificateCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WebPubSub.CustomCertificateResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string certificateName, Azure.ResourceManager.WebPubSub.CustomCertificateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WebPubSub.CustomCertificateResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string certificateName, Azure.ResourceManager.WebPubSub.CustomCertificateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.CustomCertificateResource> Get(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WebPubSub.CustomCertificateResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WebPubSub.CustomCertificateResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.CustomCertificateResource>> GetAsync(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.WebPubSub.CustomCertificateResource> GetIfExists(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.WebPubSub.CustomCertificateResource>> GetIfExistsAsync(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.WebPubSub.CustomCertificateResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WebPubSub.CustomCertificateResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.WebPubSub.CustomCertificateResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.WebPubSub.CustomCertificateResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CustomCertificateData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.CustomCertificateData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.CustomCertificateData>
    {
        public CustomCertificateData(string keyVaultBaseUri, string keyVaultSecretName) { }
        public string KeyVaultBaseUri { get { throw null; } set { } }
        public string KeyVaultSecretName { get { throw null; } set { } }
        public string KeyVaultSecretVersion { get { throw null; } set { } }
        public Azure.ResourceManager.WebPubSub.Models.WebPubSubProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.WebPubSub.CustomCertificateData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.CustomCertificateData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.CustomCertificateData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.CustomCertificateData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.CustomCertificateData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.CustomCertificateData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.CustomCertificateData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomCertificateResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.CustomCertificateData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.CustomCertificateData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CustomCertificateResource() { }
        public virtual Azure.ResourceManager.WebPubSub.CustomCertificateData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string certificateName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.CustomCertificateResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.CustomCertificateResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.WebPubSub.CustomCertificateData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.CustomCertificateData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.CustomCertificateData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.CustomCertificateData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.CustomCertificateData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.CustomCertificateData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.CustomCertificateData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WebPubSub.CustomCertificateResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.WebPubSub.CustomCertificateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WebPubSub.CustomCertificateResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.WebPubSub.CustomCertificateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CustomDomainCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WebPubSub.CustomDomainResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WebPubSub.CustomDomainResource>, System.Collections.IEnumerable
    {
        protected CustomDomainCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WebPubSub.CustomDomainResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.WebPubSub.CustomDomainData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WebPubSub.CustomDomainResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.WebPubSub.CustomDomainData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.CustomDomainResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WebPubSub.CustomDomainResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WebPubSub.CustomDomainResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.CustomDomainResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.WebPubSub.CustomDomainResource> GetIfExists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.WebPubSub.CustomDomainResource>> GetIfExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.WebPubSub.CustomDomainResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WebPubSub.CustomDomainResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.WebPubSub.CustomDomainResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.WebPubSub.CustomDomainResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CustomDomainData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.CustomDomainData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.CustomDomainData>
    {
        public CustomDomainData(string domainName) { }
        public string CustomCertificateId { get { throw null; } set { } }
        public string DomainName { get { throw null; } set { } }
        public Azure.ResourceManager.WebPubSub.Models.WebPubSubProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.WebPubSub.CustomDomainData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.CustomDomainData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.CustomDomainData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.CustomDomainData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.CustomDomainData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.CustomDomainData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.CustomDomainData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomDomainResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.CustomDomainData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.CustomDomainData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CustomDomainResource() { }
        public virtual Azure.ResourceManager.WebPubSub.CustomDomainData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.CustomDomainResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.CustomDomainResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.WebPubSub.CustomDomainData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.CustomDomainData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.CustomDomainData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.CustomDomainData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.CustomDomainData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.CustomDomainData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.CustomDomainData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WebPubSub.CustomDomainResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.WebPubSub.CustomDomainData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WebPubSub.CustomDomainResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.WebPubSub.CustomDomainData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WebPubSub.PrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WebPubSub.PrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected PrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WebPubSub.PrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.WebPubSub.WebPubSubPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WebPubSub.PrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.WebPubSub.WebPubSubPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.PrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WebPubSub.PrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WebPubSub.PrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.PrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.WebPubSub.PrivateEndpointConnectionResource> GetIfExists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.WebPubSub.PrivateEndpointConnectionResource>> GetIfExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.WebPubSub.PrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WebPubSub.PrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.WebPubSub.PrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.WebPubSub.PrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.WebPubSubPrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.WebPubSubPrivateEndpointConnectionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.WebPubSub.WebPubSubPrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.PrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.PrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.WebPubSub.WebPubSubPrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.WebPubSubPrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.WebPubSubPrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.WebPubSubPrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.WebPubSubPrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.WebPubSubPrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.WebPubSubPrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WebPubSub.PrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.WebPubSub.WebPubSubPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WebPubSub.PrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.WebPubSub.WebPubSubPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ReplicaCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WebPubSub.ReplicaResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WebPubSub.ReplicaResource>, System.Collections.IEnumerable
    {
        protected ReplicaCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WebPubSub.ReplicaResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string replicaName, Azure.ResourceManager.WebPubSub.ReplicaData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WebPubSub.ReplicaResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string replicaName, Azure.ResourceManager.WebPubSub.ReplicaData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string replicaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string replicaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.ReplicaResource> Get(string replicaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WebPubSub.ReplicaResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WebPubSub.ReplicaResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.ReplicaResource>> GetAsync(string replicaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.WebPubSub.ReplicaResource> GetIfExists(string replicaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.WebPubSub.ReplicaResource>> GetIfExistsAsync(string replicaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.WebPubSub.ReplicaResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WebPubSub.ReplicaResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.WebPubSub.ReplicaResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.WebPubSub.ReplicaResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ReplicaData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.ReplicaData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.ReplicaData>
    {
        public ReplicaData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.WebPubSub.Models.WebPubSubProvisioningState? ProvisioningState { get { throw null; } }
        public string RegionEndpointEnabled { get { throw null; } set { } }
        public string ResourceStopped { get { throw null; } set { } }
        public Azure.ResourceManager.WebPubSub.Models.BillingInfoSku Sku { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.WebPubSub.ReplicaData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.ReplicaData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.ReplicaData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.ReplicaData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.ReplicaData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.ReplicaData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.ReplicaData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ReplicaResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.ReplicaData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.ReplicaData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ReplicaResource() { }
        public virtual Azure.ResourceManager.WebPubSub.ReplicaData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.ReplicaResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.ReplicaResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string replicaName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.ReplicaResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.ReplicaResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.Models.SkuList> GetReplicaSkus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.Models.SkuList>> GetReplicaSkusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubReplicaSharedPrivateLinkResource> GetWebPubSubReplicaSharedPrivateLinkResource(string sharedPrivateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubReplicaSharedPrivateLinkResource>> GetWebPubSubReplicaSharedPrivateLinkResourceAsync(string sharedPrivateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.WebPubSub.WebPubSubReplicaSharedPrivateLinkResourceCollection GetWebPubSubReplicaSharedPrivateLinkResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.ReplicaResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.ReplicaResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Restart(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RestartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.ReplicaResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.ReplicaResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.WebPubSub.ReplicaData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.ReplicaData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.ReplicaData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.ReplicaData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.ReplicaData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.ReplicaData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.ReplicaData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WebPubSub.ReplicaResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.WebPubSub.ReplicaData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WebPubSub.ReplicaResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.WebPubSub.ReplicaData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class WebPubSubData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.WebPubSubData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.WebPubSubData>
    {
        public WebPubSubData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.WebPubSub.Models.ApplicationFirewallSettings ApplicationFirewall { get { throw null; } set { } }
        public string ExternalIP { get { throw null; } }
        public string HostName { get { throw null; } }
        public string HostNamePrefix { get { throw null; } }
        public Azure.ResourceManager.WebPubSub.Models.ManagedIdentity Identity { get { throw null; } set { } }
        public bool? IsAadAuthDisabled { get { throw null; } set { } }
        public bool? IsClientCertEnabled { get { throw null; } set { } }
        public bool? IsLocalAuthDisabled { get { throw null; } set { } }
        public Azure.ResourceManager.WebPubSub.Models.ServiceKind? Kind { get { throw null; } set { } }
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
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.WebPubSub.WebPubSubData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.WebPubSubData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.WebPubSubData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.WebPubSubData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.WebPubSubData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.WebPubSubData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.WebPubSubData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class WebPubSubExtensions
    {
        public static Azure.Response<Azure.ResourceManager.WebPubSub.Models.WebPubSubNameAvailability> CheckNameAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, Azure.ResourceManager.WebPubSub.Models.WebPubSubNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.Models.WebPubSubNameAvailability>> CheckNameAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, Azure.ResourceManager.WebPubSub.Models.WebPubSubNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.WebPubSub.Models.SignalRServiceUsage> GetAll(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.WebPubSub.Models.WebPubSubOperationDetail> GetAll(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.WebPubSub.Models.SignalRServiceUsage> GetAllAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.WebPubSub.Models.WebPubSubOperationDetail> GetAllAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.WebPubSub.CustomCertificateResource GetCustomCertificateResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.WebPubSub.CustomDomainResource GetCustomDomainResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.WebPubSub.PrivateEndpointConnectionResource GetPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.WebPubSub.ReplicaResource GetReplicaResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubResource> GetWebPubSub(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubResource>> GetWebPubSubAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.WebPubSub.WebPubSubHubResource GetWebPubSubHubResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
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
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class WebPubSubPrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.WebPubSubPrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.WebPubSubPrivateEndpointConnectionData>
    {
        public WebPubSubPrivateEndpointConnectionData() { }
        public Azure.ResourceManager.WebPubSub.Models.WebPubSubPrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> GroupIds { get { throw null; } }
        public string PrivateEndpointId { get { throw null; } set { } }
        public Azure.ResourceManager.WebPubSub.Models.WebPubSubProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.WebPubSub.WebPubSubPrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.WebPubSubPrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.WebPubSubPrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.WebPubSubPrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.WebPubSubPrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.WebPubSubPrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.WebPubSubPrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.Pageable<Azure.ResourceManager.WebPubSub.Models.WebPubSubPrivateLink> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WebPubSub.Models.WebPubSubPrivateLink> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.CustomCertificateResource> GetCustomCertificate(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.CustomCertificateResource>> GetCustomCertificateAsync(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.WebPubSub.CustomCertificateCollection GetCustomCertificates() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.CustomDomainResource> GetCustomDomain(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.CustomDomainResource>> GetCustomDomainAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.WebPubSub.CustomDomainCollection GetCustomDomains() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.Models.WebPubSubKeys> GetKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.Models.WebPubSubKeys>> GetKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.PrivateEndpointConnectionResource> GetPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.PrivateEndpointConnectionResource>> GetPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.WebPubSub.PrivateEndpointConnectionCollection GetPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.ReplicaResource> GetReplica(string replicaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.ReplicaResource>> GetReplicaAsync(string replicaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.WebPubSub.ReplicaCollection GetReplicas() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.Models.SkuList> GetSkus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.Models.SkuList>> GetSkusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubHubResource> GetWebPubSubHub(string hubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubHubResource>> GetWebPubSubHubAsync(string hubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.WebPubSub.WebPubSubHubCollection GetWebPubSubHubs() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubSharedPrivateLinkResource> GetWebPubSubSharedPrivateLinkResource(string sharedPrivateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubSharedPrivateLinkResource>> GetWebPubSubSharedPrivateLinkResourceAsync(string sharedPrivateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.WebPubSub.WebPubSubSharedPrivateLinkResourceCollection GetWebPubSubSharedPrivateLinkResources() { throw null; }
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
    public partial class WebPubSubSharedPrivateLinkData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.WebPubSubSharedPrivateLinkData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.WebPubSubSharedPrivateLinkData>
    {
        public WebPubSubSharedPrivateLinkData() { }
        public System.Collections.Generic.IList<string> Fqdns { get { throw null; } }
        public string GroupId { get { throw null; } set { } }
        public string PrivateLinkResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.WebPubSub.Models.WebPubSubProvisioningState? ProvisioningState { get { throw null; } }
        public string RequestMessage { get { throw null; } set { } }
        public Azure.ResourceManager.WebPubSub.Models.WebPubSubSharedPrivateLinkStatus? Status { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class WebPubSubSharedPrivateLinkResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WebPubSub.WebPubSubSharedPrivateLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WebPubSub.WebPubSubSharedPrivateLinkResource>, System.Collections.IEnumerable
    {
        protected WebPubSubSharedPrivateLinkResourceCollection() { }
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
}
namespace Azure.ResourceManager.WebPubSub.Mocking
{
    public partial class MockableWebPubSubArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableWebPubSubArmClient() { }
        public virtual Azure.ResourceManager.WebPubSub.CustomCertificateResource GetCustomCertificateResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.WebPubSub.CustomDomainResource GetCustomDomainResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.WebPubSub.PrivateEndpointConnectionResource GetPrivateEndpointConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.WebPubSub.ReplicaResource GetReplicaResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.WebPubSub.WebPubSubHubResource GetWebPubSubHubResource(Azure.Core.ResourceIdentifier id) { throw null; }
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
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.Models.WebPubSubNameAvailability> CheckNameAvailability(string location, Azure.ResourceManager.WebPubSub.Models.WebPubSubNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.Models.WebPubSubNameAvailability>> CheckNameAvailabilityAsync(string location, Azure.ResourceManager.WebPubSub.Models.WebPubSubNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WebPubSub.Models.SignalRServiceUsage> GetAll(string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WebPubSub.Models.SignalRServiceUsage> GetAllAsync(string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WebPubSub.WebPubSubResource> GetWebPubSubs(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WebPubSub.WebPubSubResource> GetWebPubSubsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableWebPubSubTenantResource : Azure.ResourceManager.ArmResource
    {
        protected MockableWebPubSubTenantResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.WebPubSub.Models.WebPubSubOperationDetail> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WebPubSub.Models.WebPubSubOperationDetail> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WebPubSub.Models.AclAction left, Azure.ResourceManager.WebPubSub.Models.AclAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.WebPubSub.Models.AclAction (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.WebPubSub.Models.AclAction? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WebPubSub.Models.AclAction left, Azure.ResourceManager.WebPubSub.Models.AclAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ApplicationFirewallSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.ApplicationFirewallSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.ApplicationFirewallSettings>
    {
        public ApplicationFirewallSettings() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.WebPubSub.Models.ClientConnectionCountRule> ClientConnectionCountRules { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.WebPubSub.Models.ClientTrafficControlRule> ClientTrafficControlRules { get { throw null; } }
        public long? MaxClientConnectionLifetimeInSeconds { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.WebPubSub.Models.ApplicationFirewallSettings JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.WebPubSub.Models.ApplicationFirewallSettings PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.WebPubSub.Models.ApplicationFirewallSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.ApplicationFirewallSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.ApplicationFirewallSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.ApplicationFirewallSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.ApplicationFirewallSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.ApplicationFirewallSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.ApplicationFirewallSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ArmWebPubSubModelFactory
    {
        public static Azure.ResourceManager.WebPubSub.Models.ApplicationFirewallSettings ApplicationFirewallSettings(System.Collections.Generic.IEnumerable<Azure.ResourceManager.WebPubSub.Models.ClientConnectionCountRule> clientConnectionCountRules = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WebPubSub.Models.ClientTrafficControlRule> clientTrafficControlRules = null, long? maxClientConnectionLifetimeInSeconds = default(long?)) { throw null; }
        public static Azure.ResourceManager.WebPubSub.Models.BillingInfoSku BillingInfoSku(string name = null, Azure.ResourceManager.WebPubSub.Models.WebPubSubSkuTier? tier = default(Azure.ResourceManager.WebPubSub.Models.WebPubSubSkuTier?), string size = null, string family = null, int? capacity = default(int?)) { throw null; }
        public static Azure.ResourceManager.WebPubSub.CustomCertificateData CustomCertificateData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.WebPubSub.Models.WebPubSubProvisioningState? provisioningState = default(Azure.ResourceManager.WebPubSub.Models.WebPubSubProvisioningState?), string keyVaultBaseUri = null, string keyVaultSecretName = null, string keyVaultSecretVersion = null) { throw null; }
        public static Azure.ResourceManager.WebPubSub.CustomDomainData CustomDomainData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.WebPubSub.Models.WebPubSubProvisioningState? provisioningState = default(Azure.ResourceManager.WebPubSub.Models.WebPubSubProvisioningState?), string domainName = null, string customCertificateId = null) { throw null; }
        public static Azure.ResourceManager.WebPubSub.Models.Dimension Dimension(string name = null, string displayName = null, string internalName = null, bool? toBeExportedForShoebox = default(bool?)) { throw null; }
        public static Azure.ResourceManager.WebPubSub.Models.EventNameFilter EventNameFilter(System.Collections.Generic.IEnumerable<string> systemEvents = null, string userEventPattern = null) { throw null; }
        public static Azure.ResourceManager.WebPubSub.Models.GroupPresenceEventFilters GroupPresenceEventFilters(System.Collections.Generic.IEnumerable<Azure.ResourceManager.WebPubSub.Models.GroupPresenceEventName> eventNames = null, System.Collections.Generic.IEnumerable<string> groupFilters = null) { throw null; }
        public static Azure.ResourceManager.WebPubSub.Models.LogSpecification LogSpecification(string name = null, string displayName = null) { throw null; }
        public static Azure.ResourceManager.WebPubSub.Models.ManagedIdentity ManagedIdentity(Azure.ResourceManager.WebPubSub.Models.ManagedIdentityType? type = default(Azure.ResourceManager.WebPubSub.Models.ManagedIdentityType?), System.Collections.Generic.IDictionary<string, Azure.ResourceManager.WebPubSub.Models.UserAssignedIdentityProperty> userAssignedIdentities = null, string principalId = null, string tenantId = null) { throw null; }
        public static Azure.ResourceManager.WebPubSub.Models.MetricSpecification MetricSpecification(string name = null, string displayName = null, string displayDescription = null, string unit = null, string aggregationType = null, string fillGapWithZero = null, string category = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WebPubSub.Models.Dimension> dimensions = null) { throw null; }
        public static Azure.ResourceManager.WebPubSub.Models.OperationDisplay OperationDisplay(string provider = null, string resource = null, string operation = null, string description = null) { throw null; }
        public static Azure.ResourceManager.WebPubSub.Models.PrivateEndpointAcl PrivateEndpointAcl(System.Collections.Generic.IEnumerable<Azure.ResourceManager.WebPubSub.Models.WebPubSubRequestType> allow = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WebPubSub.Models.WebPubSubRequestType> deny = null, string name = null) { throw null; }
        public static Azure.ResourceManager.WebPubSub.Models.PublicNetworkAcls PublicNetworkAcls(System.Collections.Generic.IEnumerable<Azure.ResourceManager.WebPubSub.Models.WebPubSubRequestType> allow = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WebPubSub.Models.WebPubSubRequestType> deny = null) { throw null; }
        public static Azure.ResourceManager.WebPubSub.ReplicaData ReplicaData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.WebPubSub.Models.WebPubSubProvisioningState? provisioningState = default(Azure.ResourceManager.WebPubSub.Models.WebPubSubProvisioningState?), string regionEndpointEnabled = null, string resourceStopped = null, Azure.ResourceManager.WebPubSub.Models.BillingInfoSku sku = null) { throw null; }
        public static Azure.ResourceManager.WebPubSub.Models.ServiceSpecification ServiceSpecification(System.Collections.Generic.IEnumerable<Azure.ResourceManager.WebPubSub.Models.MetricSpecification> metricSpecifications = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WebPubSub.Models.LogSpecification> logSpecifications = null) { throw null; }
        public static Azure.ResourceManager.WebPubSub.Models.ShareablePrivateLinkProperties ShareablePrivateLinkProperties(string description = null, string groupId = null, string type = null) { throw null; }
        public static Azure.ResourceManager.WebPubSub.Models.ShareablePrivateLinkType ShareablePrivateLinkType(string name = null, Azure.ResourceManager.WebPubSub.Models.ShareablePrivateLinkProperties properties = null) { throw null; }
        public static Azure.ResourceManager.WebPubSub.Models.SignalRServiceUsage SignalRServiceUsage(string id = null, long? currentValue = default(long?), long? limit = default(long?), Azure.ResourceManager.WebPubSub.Models.SignalRServiceUsageName name = null, string unit = null) { throw null; }
        public static Azure.ResourceManager.WebPubSub.Models.SignalRServiceUsageName SignalRServiceUsageName(string value = null, string localizedValue = null) { throw null; }
        public static Azure.ResourceManager.WebPubSub.Models.SkuList SkuList(System.Collections.Generic.IEnumerable<Azure.ResourceManager.WebPubSub.Models.WebPubSubSku> value = null, string nextLink = null) { throw null; }
        public static Azure.ResourceManager.WebPubSub.Models.UserAssignedIdentityProperty UserAssignedIdentityProperty(string principalId = null, string clientId = null) { throw null; }
        public static Azure.ResourceManager.WebPubSub.WebPubSubData WebPubSubData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ResourceManager.WebPubSub.Models.BillingInfoSku sku, Azure.ResourceManager.Models.ManagedServiceIdentity identity, Azure.ResourceManager.WebPubSub.Models.WebPubSubProvisioningState? provisioningState, string externalIP, string hostName, int? publicPort, int? serverPort, string version, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WebPubSub.WebPubSubPrivateEndpointConnectionData> privateEndpointConnections, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WebPubSub.WebPubSubSharedPrivateLinkData> sharedPrivateLinkResources, bool? isClientCertEnabled, string hostNamePrefix, Azure.ResourceManager.WebPubSub.Models.LiveTraceConfiguration liveTraceConfiguration, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WebPubSub.Models.ResourceLogCategory> resourceLogCategories, Azure.ResourceManager.WebPubSub.Models.WebPubSubNetworkAcls networkAcls, string publicNetworkAccess, bool? isLocalAuthDisabled, bool? isAadAuthDisabled) { throw null; }
        public static Azure.ResourceManager.WebPubSub.WebPubSubData WebPubSubData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.WebPubSub.Models.WebPubSubProvisioningState? provisioningState = default(Azure.ResourceManager.WebPubSub.Models.WebPubSubProvisioningState?), string externalIP = null, string hostName = null, int? publicPort = default(int?), int? serverPort = default(int?), string version = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WebPubSub.WebPubSubPrivateEndpointConnectionData> privateEndpointConnections = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WebPubSub.WebPubSubSharedPrivateLinkData> sharedPrivateLinkResources = null, string hostNamePrefix = null, Azure.ResourceManager.WebPubSub.Models.LiveTraceConfiguration liveTraceConfiguration = null, Azure.ResourceManager.WebPubSub.Models.WebPubSubNetworkAcls networkAcls = null, Azure.ResourceManager.WebPubSub.Models.ApplicationFirewallSettings applicationFirewall = null, string publicNetworkAccess = null, bool? isLocalAuthDisabled = default(bool?), bool? isAadAuthDisabled = default(bool?), string regionEndpointEnabled = null, string resourceStopped = null, bool? isClientCertEnabled = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.WebPubSub.Models.ResourceLogCategory> resourceLogCategories = null, string socketIOServiceMode = null, Azure.ResourceManager.WebPubSub.Models.BillingInfoSku sku = null, Azure.ResourceManager.WebPubSub.Models.ServiceKind? kind = default(Azure.ResourceManager.WebPubSub.Models.ServiceKind?), Azure.ResourceManager.WebPubSub.Models.ManagedIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.WebPubSub.Models.WebPubSubEventHandler WebPubSubEventHandler(string urlTemplate = null, string userEventPattern = null, System.Collections.Generic.IEnumerable<string> systemEvents = null, Azure.ResourceManager.WebPubSub.Models.UpstreamAuthSettings auth = null, Azure.ResourceManager.WebPubSub.Models.GroupPresenceEventFilters groupPresenceEvents = null) { throw null; }
        public static Azure.ResourceManager.WebPubSub.WebPubSubHubData WebPubSubHubData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.WebPubSub.Models.WebPubSubHubProperties properties = null) { throw null; }
        public static Azure.ResourceManager.WebPubSub.Models.WebPubSubHubProperties WebPubSubHubProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.WebPubSub.Models.WebPubSubEventHandler> eventHandlers = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WebPubSub.Models.EventListener> eventListeners = null, string anonymousConnectPolicy = null, int? webSocketKeepAliveIntervalInSeconds = default(int?)) { throw null; }
        public static Azure.ResourceManager.WebPubSub.Models.WebPubSubKeys WebPubSubKeys(string primaryKey = null, string secondaryKey = null, string primaryConnectionString = null, string secondaryConnectionString = null) { throw null; }
        public static Azure.ResourceManager.WebPubSub.Models.WebPubSubNameAvailability WebPubSubNameAvailability(bool? nameAvailable = default(bool?), string reason = null, string message = null) { throw null; }
        public static Azure.ResourceManager.WebPubSub.Models.WebPubSubNameAvailabilityContent WebPubSubNameAvailabilityContent(string type = null, string name = null) { throw null; }
        public static Azure.ResourceManager.WebPubSub.Models.WebPubSubNetworkAcls WebPubSubNetworkAcls(Azure.ResourceManager.WebPubSub.Models.AclAction? defaultAction = default(Azure.ResourceManager.WebPubSub.Models.AclAction?), Azure.ResourceManager.WebPubSub.Models.PublicNetworkAcls publicNetwork = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WebPubSub.Models.PrivateEndpointAcl> privateEndpoints = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WebPubSub.Models.IPRule> ipRules = null) { throw null; }
        public static Azure.ResourceManager.WebPubSub.Models.WebPubSubOperationDetail WebPubSubOperationDetail(string name = null, bool? isDataAction = default(bool?), Azure.ResourceManager.WebPubSub.Models.OperationDisplay display = null, string origin = null, Azure.ResourceManager.WebPubSub.Models.ServiceSpecification operationServiceSpecification = null) { throw null; }
        public static Azure.ResourceManager.WebPubSub.WebPubSubPrivateEndpointConnectionData WebPubSubPrivateEndpointConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.WebPubSub.Models.WebPubSubProvisioningState? provisioningState = default(Azure.ResourceManager.WebPubSub.Models.WebPubSubProvisioningState?), System.Collections.Generic.IEnumerable<string> groupIds = null, Azure.ResourceManager.WebPubSub.Models.WebPubSubPrivateLinkServiceConnectionState connectionState = null, string privateEndpointId = null) { throw null; }
        public static Azure.ResourceManager.WebPubSub.Models.WebPubSubPrivateLink WebPubSubPrivateLink(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string groupId = null, System.Collections.Generic.IEnumerable<string> requiredMembers = null, System.Collections.Generic.IEnumerable<string> requiredZoneNames = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WebPubSub.Models.ShareablePrivateLinkType> shareablePrivateLinkResourceTypes = null) { throw null; }
        public static Azure.ResourceManager.WebPubSub.WebPubSubSharedPrivateLinkData WebPubSubSharedPrivateLinkData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string groupId = null, string privateLinkResourceId = null, Azure.ResourceManager.WebPubSub.Models.WebPubSubProvisioningState? provisioningState = default(Azure.ResourceManager.WebPubSub.Models.WebPubSubProvisioningState?), string requestMessage = null, System.Collections.Generic.IEnumerable<string> fqdns = null, Azure.ResourceManager.WebPubSub.Models.WebPubSubSharedPrivateLinkStatus? status = default(Azure.ResourceManager.WebPubSub.Models.WebPubSubSharedPrivateLinkStatus?)) { throw null; }
        public static Azure.ResourceManager.WebPubSub.Models.WebPubSubSku WebPubSubSku(string resourceType = null, Azure.ResourceManager.WebPubSub.Models.BillingInfoSku sku = null, Azure.ResourceManager.WebPubSub.Models.WebPubSubSkuCapacity capacity = null) { throw null; }
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
        protected virtual Azure.ResourceManager.WebPubSub.Models.BillingInfoSku JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.WebPubSub.Models.BillingInfoSku PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.WebPubSub.Models.BillingInfoSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.BillingInfoSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.BillingInfoSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.BillingInfoSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.BillingInfoSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.BillingInfoSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.BillingInfoSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ClientConnectionCountRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.ClientConnectionCountRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.ClientConnectionCountRule>
    {
        internal ClientConnectionCountRule() { }
        protected virtual Azure.ResourceManager.WebPubSub.Models.ClientConnectionCountRule JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.WebPubSub.Models.ClientConnectionCountRule PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.WebPubSub.Models.ClientConnectionCountRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.ClientConnectionCountRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.ClientConnectionCountRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.ClientConnectionCountRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.ClientConnectionCountRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.ClientConnectionCountRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.ClientConnectionCountRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ClientTrafficControlRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.ClientTrafficControlRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.ClientTrafficControlRule>
    {
        internal ClientTrafficControlRule() { }
        protected virtual Azure.ResourceManager.WebPubSub.Models.ClientTrafficControlRule JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.WebPubSub.Models.ClientTrafficControlRule PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.WebPubSub.Models.ClientTrafficControlRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.ClientTrafficControlRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.ClientTrafficControlRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.ClientTrafficControlRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.ClientTrafficControlRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.ClientTrafficControlRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.ClientTrafficControlRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class Dimension : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.Dimension>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.Dimension>
    {
        internal Dimension() { }
        public string DisplayName { get { throw null; } }
        public string InternalName { get { throw null; } }
        public string Name { get { throw null; } }
        public bool? ToBeExportedForShoebox { get { throw null; } }
        protected virtual Azure.ResourceManager.WebPubSub.Models.Dimension JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.WebPubSub.Models.Dimension PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.WebPubSub.Models.Dimension System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.Dimension>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.Dimension>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.Dimension System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.Dimension>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.Dimension>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.Dimension>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EventHubEndpoint : Azure.ResourceManager.WebPubSub.Models.EventListenerEndpoint, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.EventHubEndpoint>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.EventHubEndpoint>
    {
        public EventHubEndpoint(string fullyQualifiedNamespace, string eventHubName) { }
        public string EventHubName { get { throw null; } set { } }
        public string FullyQualifiedNamespace { get { throw null; } set { } }
        protected override Azure.ResourceManager.WebPubSub.Models.EventListenerEndpoint JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.WebPubSub.Models.EventListenerEndpoint PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.WebPubSub.Models.EventHubEndpoint System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.EventHubEndpoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.EventHubEndpoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.EventHubEndpoint System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.EventHubEndpoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.EventHubEndpoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.EventHubEndpoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EventListener : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.EventListener>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.EventListener>
    {
        public EventListener(Azure.ResourceManager.WebPubSub.Models.EventListenerFilter filter, Azure.ResourceManager.WebPubSub.Models.EventListenerEndpoint endpoint) { }
        public Azure.ResourceManager.WebPubSub.Models.EventListenerEndpoint Endpoint { get { throw null; } set { } }
        public Azure.ResourceManager.WebPubSub.Models.EventListenerFilter Filter { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.WebPubSub.Models.EventListener JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.WebPubSub.Models.EventListener PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.WebPubSub.Models.EventListener System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.EventListener>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.EventListener>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.EventListener System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.EventListener>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.EventListener>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.EventListener>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class EventListenerEndpoint : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.EventListenerEndpoint>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.EventListenerEndpoint>
    {
        internal EventListenerEndpoint() { }
        protected virtual Azure.ResourceManager.WebPubSub.Models.EventListenerEndpoint JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.WebPubSub.Models.EventListenerEndpoint PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.WebPubSub.Models.EventListenerEndpoint System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.EventListenerEndpoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.EventListenerEndpoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.EventListenerEndpoint System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.EventListenerEndpoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.EventListenerEndpoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.EventListenerEndpoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class EventListenerFilter : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.EventListenerFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.EventListenerFilter>
    {
        internal EventListenerFilter() { }
        protected virtual Azure.ResourceManager.WebPubSub.Models.EventListenerFilter JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.WebPubSub.Models.EventListenerFilter PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected override Azure.ResourceManager.WebPubSub.Models.EventListenerFilter JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.WebPubSub.Models.EventListenerFilter PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.WebPubSub.Models.EventNameFilter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.EventNameFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.EventNameFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.EventNameFilter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.EventNameFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.EventNameFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.EventNameFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GroupPresenceEventFilters : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.GroupPresenceEventFilters>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.GroupPresenceEventFilters>
    {
        public GroupPresenceEventFilters(System.Collections.Generic.IEnumerable<Azure.ResourceManager.WebPubSub.Models.GroupPresenceEventName> eventNames) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.WebPubSub.Models.GroupPresenceEventName> EventNames { get { throw null; } }
        public System.Collections.Generic.IList<string> GroupFilters { get { throw null; } }
        protected virtual Azure.ResourceManager.WebPubSub.Models.GroupPresenceEventFilters JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.WebPubSub.Models.GroupPresenceEventFilters PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.WebPubSub.Models.GroupPresenceEventFilters System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.GroupPresenceEventFilters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.GroupPresenceEventFilters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.GroupPresenceEventFilters System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.GroupPresenceEventFilters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.GroupPresenceEventFilters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.GroupPresenceEventFilters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GroupPresenceEventName : System.IEquatable<Azure.ResourceManager.WebPubSub.Models.GroupPresenceEventName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GroupPresenceEventName(string value) { throw null; }
        public static Azure.ResourceManager.WebPubSub.Models.GroupPresenceEventName Joined { get { throw null; } }
        public static Azure.ResourceManager.WebPubSub.Models.GroupPresenceEventName Left { get { throw null; } }
        public bool Equals(Azure.ResourceManager.WebPubSub.Models.GroupPresenceEventName other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WebPubSub.Models.GroupPresenceEventName left, Azure.ResourceManager.WebPubSub.Models.GroupPresenceEventName right) { throw null; }
        public static implicit operator Azure.ResourceManager.WebPubSub.Models.GroupPresenceEventName (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.WebPubSub.Models.GroupPresenceEventName? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WebPubSub.Models.GroupPresenceEventName left, Azure.ResourceManager.WebPubSub.Models.GroupPresenceEventName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IPRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.IPRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.IPRule>
    {
        public IPRule() { }
        public Azure.ResourceManager.WebPubSub.Models.AclAction? Action { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.WebPubSub.Models.IPRule JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.WebPubSub.Models.IPRule PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.WebPubSub.Models.IPRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.IPRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.IPRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.IPRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.IPRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.IPRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.IPRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LiveTraceCategory : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.LiveTraceCategory>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.LiveTraceCategory>
    {
        public LiveTraceCategory() { }
        public bool? IsEnabled { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.WebPubSub.Models.LiveTraceCategory JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.WebPubSub.Models.LiveTraceCategory PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.WebPubSub.Models.LiveTraceConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.WebPubSub.Models.LiveTraceConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.WebPubSub.Models.LiveTraceConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.LiveTraceConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.LiveTraceConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.LiveTraceConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.LiveTraceConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.LiveTraceConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.LiveTraceConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LogSpecification : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.LogSpecification>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.LogSpecification>
    {
        internal LogSpecification() { }
        public string DisplayName { get { throw null; } }
        public string Name { get { throw null; } }
        protected virtual Azure.ResourceManager.WebPubSub.Models.LogSpecification JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.WebPubSub.Models.LogSpecification PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.WebPubSub.Models.LogSpecification System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.LogSpecification>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.LogSpecification>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.LogSpecification System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.LogSpecification>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.LogSpecification>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.LogSpecification>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ManagedIdentity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.ManagedIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.ManagedIdentity>
    {
        public ManagedIdentity() { }
        public string PrincipalId { get { throw null; } }
        public string TenantId { get { throw null; } }
        public Azure.ResourceManager.WebPubSub.Models.ManagedIdentityType? Type { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.WebPubSub.Models.UserAssignedIdentityProperty> UserAssignedIdentities { get { throw null; } }
        protected virtual Azure.ResourceManager.WebPubSub.Models.ManagedIdentity JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.WebPubSub.Models.ManagedIdentity PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.WebPubSub.Models.ManagedIdentity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.ManagedIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.ManagedIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.ManagedIdentity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.ManagedIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.ManagedIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.ManagedIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedIdentityType : System.IEquatable<Azure.ResourceManager.WebPubSub.Models.ManagedIdentityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedIdentityType(string value) { throw null; }
        public static Azure.ResourceManager.WebPubSub.Models.ManagedIdentityType None { get { throw null; } }
        public static Azure.ResourceManager.WebPubSub.Models.ManagedIdentityType SystemAssigned { get { throw null; } }
        public static Azure.ResourceManager.WebPubSub.Models.ManagedIdentityType UserAssigned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.WebPubSub.Models.ManagedIdentityType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WebPubSub.Models.ManagedIdentityType left, Azure.ResourceManager.WebPubSub.Models.ManagedIdentityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.WebPubSub.Models.ManagedIdentityType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.WebPubSub.Models.ManagedIdentityType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WebPubSub.Models.ManagedIdentityType left, Azure.ResourceManager.WebPubSub.Models.ManagedIdentityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MetricSpecification : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.MetricSpecification>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.MetricSpecification>
    {
        internal MetricSpecification() { }
        public string AggregationType { get { throw null; } }
        public string Category { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.WebPubSub.Models.Dimension> Dimensions { get { throw null; } }
        public string DisplayDescription { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public string FillGapWithZero { get { throw null; } }
        public string Name { get { throw null; } }
        public string Unit { get { throw null; } }
        protected virtual Azure.ResourceManager.WebPubSub.Models.MetricSpecification JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.WebPubSub.Models.MetricSpecification PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.WebPubSub.Models.MetricSpecification System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.MetricSpecification>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.MetricSpecification>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.MetricSpecification System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.MetricSpecification>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.MetricSpecification>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.MetricSpecification>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OperationDisplay : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.OperationDisplay>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.OperationDisplay>
    {
        internal OperationDisplay() { }
        public string Description { get { throw null; } }
        public string Operation { get { throw null; } }
        public string Provider { get { throw null; } }
        public string Resource { get { throw null; } }
        protected virtual Azure.ResourceManager.WebPubSub.Models.OperationDisplay JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.WebPubSub.Models.OperationDisplay PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.WebPubSub.Models.OperationDisplay System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.OperationDisplay>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.OperationDisplay>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.OperationDisplay System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.OperationDisplay>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.OperationDisplay>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.OperationDisplay>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PrivateEndpointAcl : Azure.ResourceManager.WebPubSub.Models.PublicNetworkAcls, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.PrivateEndpointAcl>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.PrivateEndpointAcl>
    {
        public PrivateEndpointAcl(string name) { }
        public string Name { get { throw null; } set { } }
        protected override Azure.ResourceManager.WebPubSub.Models.PublicNetworkAcls JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.WebPubSub.Models.PublicNetworkAcls PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.WebPubSub.Models.PublicNetworkAcls JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.WebPubSub.Models.PublicNetworkAcls PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.WebPubSub.Models.PublicNetworkAcls System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.PublicNetworkAcls>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.PublicNetworkAcls>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.PublicNetworkAcls System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.PublicNetworkAcls>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.PublicNetworkAcls>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.PublicNetworkAcls>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceLogCategory : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.ResourceLogCategory>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.ResourceLogCategory>
    {
        public ResourceLogCategory() { }
        public string Enabled { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.WebPubSub.Models.ResourceLogCategory JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.WebPubSub.Models.ResourceLogCategory PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.WebPubSub.Models.ResourceLogCategory System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.ResourceLogCategory>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.ResourceLogCategory>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.ResourceLogCategory System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.ResourceLogCategory>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.ResourceLogCategory>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.ResourceLogCategory>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServiceKind : System.IEquatable<Azure.ResourceManager.WebPubSub.Models.ServiceKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServiceKind(string value) { throw null; }
        public static Azure.ResourceManager.WebPubSub.Models.ServiceKind SocketIO { get { throw null; } }
        public static Azure.ResourceManager.WebPubSub.Models.ServiceKind WebPubSub { get { throw null; } }
        public bool Equals(Azure.ResourceManager.WebPubSub.Models.ServiceKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WebPubSub.Models.ServiceKind left, Azure.ResourceManager.WebPubSub.Models.ServiceKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.WebPubSub.Models.ServiceKind (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.WebPubSub.Models.ServiceKind? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WebPubSub.Models.ServiceKind left, Azure.ResourceManager.WebPubSub.Models.ServiceKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ServiceSpecification : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.ServiceSpecification>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.ServiceSpecification>
    {
        internal ServiceSpecification() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.WebPubSub.Models.LogSpecification> LogSpecifications { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.WebPubSub.Models.MetricSpecification> MetricSpecifications { get { throw null; } }
        protected virtual Azure.ResourceManager.WebPubSub.Models.ServiceSpecification JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.WebPubSub.Models.ServiceSpecification PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.WebPubSub.Models.ServiceSpecification System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.ServiceSpecification>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.ServiceSpecification>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.ServiceSpecification System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.ServiceSpecification>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.ServiceSpecification>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.ServiceSpecification>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ShareablePrivateLinkProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.ShareablePrivateLinkProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.ShareablePrivateLinkProperties>
    {
        internal ShareablePrivateLinkProperties() { }
        public string Description { get { throw null; } }
        public string GroupId { get { throw null; } }
        public string Type { get { throw null; } }
        protected virtual Azure.ResourceManager.WebPubSub.Models.ShareablePrivateLinkProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.WebPubSub.Models.ShareablePrivateLinkProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.WebPubSub.Models.ShareablePrivateLinkProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.ShareablePrivateLinkProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.ShareablePrivateLinkProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.ShareablePrivateLinkProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.ShareablePrivateLinkProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.ShareablePrivateLinkProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.ShareablePrivateLinkProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ShareablePrivateLinkType : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.ShareablePrivateLinkType>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.ShareablePrivateLinkType>
    {
        internal ShareablePrivateLinkType() { }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.WebPubSub.Models.ShareablePrivateLinkProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.WebPubSub.Models.ShareablePrivateLinkType JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.WebPubSub.Models.ShareablePrivateLinkType PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public string Id { get { throw null; } }
        public long? Limit { get { throw null; } }
        public Azure.ResourceManager.WebPubSub.Models.SignalRServiceUsageName Name { get { throw null; } }
        public string Unit { get { throw null; } }
        protected virtual Azure.ResourceManager.WebPubSub.Models.SignalRServiceUsage JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.WebPubSub.Models.SignalRServiceUsage PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.WebPubSub.Models.SignalRServiceUsageName JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.WebPubSub.Models.SignalRServiceUsageName PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.WebPubSub.Models.SignalRServiceUsageName System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.SignalRServiceUsageName>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.SignalRServiceUsageName>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.SignalRServiceUsageName System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.SignalRServiceUsageName>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.SignalRServiceUsageName>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.SignalRServiceUsageName>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SkuList : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.SkuList>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.SkuList>
    {
        internal SkuList() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.WebPubSub.Models.WebPubSubSku> Value { get { throw null; } }
        protected virtual Azure.ResourceManager.WebPubSub.Models.SkuList JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.WebPubSub.Models.SkuList PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.WebPubSub.Models.SkuList System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.SkuList>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.SkuList>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.SkuList System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.SkuList>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.SkuList>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.SkuList>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ThrottleByJwtCustomClaimRule : Azure.ResourceManager.WebPubSub.Models.ClientConnectionCountRule, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.ThrottleByJwtCustomClaimRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.ThrottleByJwtCustomClaimRule>
    {
        public ThrottleByJwtCustomClaimRule(string claimName) { }
        public string ClaimName { get { throw null; } set { } }
        public int? MaxCount { get { throw null; } set { } }
        protected override Azure.ResourceManager.WebPubSub.Models.ClientConnectionCountRule JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.WebPubSub.Models.ClientConnectionCountRule PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected override Azure.ResourceManager.WebPubSub.Models.ClientConnectionCountRule JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.WebPubSub.Models.ClientConnectionCountRule PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected override Azure.ResourceManager.WebPubSub.Models.ClientConnectionCountRule JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.WebPubSub.Models.ClientConnectionCountRule PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected override Azure.ResourceManager.WebPubSub.Models.ClientTrafficControlRule JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.WebPubSub.Models.ClientTrafficControlRule PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected override Azure.ResourceManager.WebPubSub.Models.ClientTrafficControlRule JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.WebPubSub.Models.ClientTrafficControlRule PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected override Azure.ResourceManager.WebPubSub.Models.ClientTrafficControlRule JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.WebPubSub.Models.ClientTrafficControlRule PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.WebPubSub.Models.TrafficThrottleByUserIdRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.TrafficThrottleByUserIdRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.TrafficThrottleByUserIdRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.TrafficThrottleByUserIdRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.TrafficThrottleByUserIdRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.TrafficThrottleByUserIdRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.TrafficThrottleByUserIdRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UpstreamAuthSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.UpstreamAuthSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.UpstreamAuthSettings>
    {
        public UpstreamAuthSettings() { }
        public string ManagedIdentityResource { get { throw null; } set { } }
        public Azure.ResourceManager.WebPubSub.Models.UpstreamAuthType? Type { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.WebPubSub.Models.UpstreamAuthSettings JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.WebPubSub.Models.UpstreamAuthSettings PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WebPubSub.Models.UpstreamAuthType left, Azure.ResourceManager.WebPubSub.Models.UpstreamAuthType right) { throw null; }
        public static implicit operator Azure.ResourceManager.WebPubSub.Models.UpstreamAuthType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.WebPubSub.Models.UpstreamAuthType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WebPubSub.Models.UpstreamAuthType left, Azure.ResourceManager.WebPubSub.Models.UpstreamAuthType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UserAssignedIdentityProperty : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.UserAssignedIdentityProperty>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.UserAssignedIdentityProperty>
    {
        public UserAssignedIdentityProperty() { }
        public string ClientId { get { throw null; } }
        public string PrincipalId { get { throw null; } }
        protected virtual Azure.ResourceManager.WebPubSub.Models.UserAssignedIdentityProperty JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.WebPubSub.Models.UserAssignedIdentityProperty PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.WebPubSub.Models.UserAssignedIdentityProperty System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.UserAssignedIdentityProperty>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.UserAssignedIdentityProperty>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.UserAssignedIdentityProperty System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.UserAssignedIdentityProperty>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.UserAssignedIdentityProperty>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.UserAssignedIdentityProperty>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WebPubSubEventHandler : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubEventHandler>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubEventHandler>
    {
        public WebPubSubEventHandler(string urlTemplate) { }
        public Azure.ResourceManager.WebPubSub.Models.UpstreamAuthSettings Auth { get { throw null; } set { } }
        public Azure.ResourceManager.WebPubSub.Models.GroupPresenceEventFilters GroupPresenceEvents { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SystemEvents { get { throw null; } }
        public string UrlTemplate { get { throw null; } set { } }
        public string UserEventPattern { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.WebPubSub.Models.WebPubSubEventHandler JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.WebPubSub.Models.WebPubSubEventHandler PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.WebPubSub.Models.WebPubSubEventHandler System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubEventHandler>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubEventHandler>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.WebPubSubEventHandler System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubEventHandler>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubEventHandler>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubEventHandler>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WebPubSubHubProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubHubProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubHubProperties>
    {
        public WebPubSubHubProperties() { }
        public string AnonymousConnectPolicy { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.WebPubSub.Models.WebPubSubEventHandler> EventHandlers { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.WebPubSub.Models.EventListener> EventListeners { get { throw null; } }
        public int? WebSocketKeepAliveIntervalInSeconds { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.WebPubSub.Models.WebPubSubHubProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.WebPubSub.Models.WebPubSubHubProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.WebPubSub.Models.WebPubSubKeys JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.WebPubSub.Models.WebPubSubKeys PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WebPubSub.Models.WebPubSubKeyType left, Azure.ResourceManager.WebPubSub.Models.WebPubSubKeyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.WebPubSub.Models.WebPubSubKeyType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.WebPubSub.Models.WebPubSubKeyType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WebPubSub.Models.WebPubSubKeyType left, Azure.ResourceManager.WebPubSub.Models.WebPubSubKeyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WebPubSubNameAvailability : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubNameAvailability>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubNameAvailability>
    {
        internal WebPubSubNameAvailability() { }
        public string Message { get { throw null; } }
        public bool? NameAvailable { get { throw null; } }
        public string Reason { get { throw null; } }
        protected virtual Azure.ResourceManager.WebPubSub.Models.WebPubSubNameAvailability JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.WebPubSub.Models.WebPubSubNameAvailability PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.WebPubSub.Models.WebPubSubNameAvailability System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubNameAvailability>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubNameAvailability>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.WebPubSubNameAvailability System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubNameAvailability>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubNameAvailability>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubNameAvailability>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WebPubSubNameAvailabilityContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubNameAvailabilityContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubNameAvailabilityContent>
    {
        public WebPubSubNameAvailabilityContent(string type, string name) { }
        public string Name { get { throw null; } }
        public string Type { get { throw null; } }
        protected virtual Azure.ResourceManager.WebPubSub.Models.WebPubSubNameAvailabilityContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.WebPubSub.Models.WebPubSubNameAvailabilityContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public System.Collections.Generic.IList<Azure.ResourceManager.WebPubSub.Models.IPRule> IpRules { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.WebPubSub.Models.PrivateEndpointAcl> PrivateEndpoints { get { throw null; } }
        public Azure.ResourceManager.WebPubSub.Models.PublicNetworkAcls PublicNetwork { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.WebPubSub.Models.WebPubSubNetworkAcls JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.WebPubSub.Models.WebPubSubNetworkAcls PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.WebPubSub.Models.WebPubSubNetworkAcls System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubNetworkAcls>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubNetworkAcls>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.WebPubSubNetworkAcls System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubNetworkAcls>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubNetworkAcls>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubNetworkAcls>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WebPubSubOperationDetail : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubOperationDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubOperationDetail>
    {
        internal WebPubSubOperationDetail() { }
        public Azure.ResourceManager.WebPubSub.Models.OperationDisplay Display { get { throw null; } }
        public bool? IsDataAction { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.WebPubSub.Models.ServiceSpecification OperationServiceSpecification { get { throw null; } }
        public string Origin { get { throw null; } }
        protected virtual Azure.ResourceManager.WebPubSub.Models.WebPubSubOperationDetail JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.WebPubSub.Models.WebPubSubOperationDetail PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.WebPubSub.Models.WebPubSubOperationDetail System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubOperationDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubOperationDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WebPubSub.Models.WebPubSubOperationDetail System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubOperationDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubOperationDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubOperationDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WebPubSubPrivateLink : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubPrivateLink>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubPrivateLink>
    {
        internal WebPubSubPrivateLink() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredZoneNames { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.WebPubSub.Models.ShareablePrivateLinkType> ShareablePrivateLinkResourceTypes { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.WebPubSub.Models.WebPubSubPrivateLinkServiceConnectionState JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.WebPubSub.Models.WebPubSubPrivateLinkServiceConnectionState PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WebPubSub.Models.WebPubSubPrivateLinkServiceConnectionStatus left, Azure.ResourceManager.WebPubSub.Models.WebPubSubPrivateLinkServiceConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.WebPubSub.Models.WebPubSubPrivateLinkServiceConnectionStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.WebPubSub.Models.WebPubSubPrivateLinkServiceConnectionStatus? (string value) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WebPubSub.Models.WebPubSubProvisioningState left, Azure.ResourceManager.WebPubSub.Models.WebPubSubProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.WebPubSub.Models.WebPubSubProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.WebPubSub.Models.WebPubSubProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WebPubSub.Models.WebPubSubProvisioningState left, Azure.ResourceManager.WebPubSub.Models.WebPubSubProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WebPubSubRegenerateKeyContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubRegenerateKeyContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubRegenerateKeyContent>
    {
        public WebPubSubRegenerateKeyContent() { }
        public Azure.ResourceManager.WebPubSub.Models.WebPubSubKeyType? KeyType { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.WebPubSub.Models.WebPubSubRegenerateKeyContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.WebPubSub.Models.WebPubSubRegenerateKeyContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WebPubSub.Models.WebPubSubRequestType left, Azure.ResourceManager.WebPubSub.Models.WebPubSubRequestType right) { throw null; }
        public static implicit operator Azure.ResourceManager.WebPubSub.Models.WebPubSubRequestType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.WebPubSub.Models.WebPubSubRequestType? (string value) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WebPubSub.Models.WebPubSubScaleType left, Azure.ResourceManager.WebPubSub.Models.WebPubSubScaleType right) { throw null; }
        public static implicit operator Azure.ResourceManager.WebPubSub.Models.WebPubSubScaleType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.WebPubSub.Models.WebPubSubScaleType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WebPubSub.Models.WebPubSubScaleType left, Azure.ResourceManager.WebPubSub.Models.WebPubSubScaleType right) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WebPubSub.Models.WebPubSubSharedPrivateLinkStatus left, Azure.ResourceManager.WebPubSub.Models.WebPubSubSharedPrivateLinkStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.WebPubSub.Models.WebPubSubSharedPrivateLinkStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.WebPubSub.Models.WebPubSubSharedPrivateLinkStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WebPubSub.Models.WebPubSubSharedPrivateLinkStatus left, Azure.ResourceManager.WebPubSub.Models.WebPubSubSharedPrivateLinkStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WebPubSubSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WebPubSub.Models.WebPubSubSku>
    {
        internal WebPubSubSku() { }
        public Azure.ResourceManager.WebPubSub.Models.WebPubSubSkuCapacity Capacity { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public Azure.ResourceManager.WebPubSub.Models.BillingInfoSku Sku { get { throw null; } }
        protected virtual Azure.ResourceManager.WebPubSub.Models.WebPubSubSku JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.WebPubSub.Models.WebPubSubSku PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.WebPubSub.Models.WebPubSubSkuCapacity JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.WebPubSub.Models.WebPubSubSkuCapacity PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WebPubSub.Models.WebPubSubSkuTier left, Azure.ResourceManager.WebPubSub.Models.WebPubSubSkuTier right) { throw null; }
        public static implicit operator Azure.ResourceManager.WebPubSub.Models.WebPubSubSkuTier (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.WebPubSub.Models.WebPubSubSkuTier? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WebPubSub.Models.WebPubSubSkuTier left, Azure.ResourceManager.WebPubSub.Models.WebPubSubSkuTier right) { throw null; }
        public override string ToString() { throw null; }
    }
}
