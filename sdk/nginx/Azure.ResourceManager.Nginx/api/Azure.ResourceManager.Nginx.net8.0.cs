namespace Azure.ResourceManager.Nginx
{
    public partial class AzureResourceManagerNginxContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerNginxContext() { }
        public static Azure.ResourceManager.Nginx.AzureResourceManagerNginxContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class NginxCertificateCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Nginx.NginxCertificateResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Nginx.NginxCertificateResource>, System.Collections.IEnumerable
    {
        protected NginxCertificateCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Nginx.NginxCertificateResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string certificateName, Azure.ResourceManager.Nginx.NginxCertificateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Nginx.NginxCertificateResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string certificateName, Azure.ResourceManager.Nginx.NginxCertificateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Nginx.NginxCertificateResource> Get(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Nginx.NginxCertificateResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Nginx.NginxCertificateResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Nginx.NginxCertificateResource>> GetAsync(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Nginx.NginxCertificateResource> GetIfExists(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Nginx.NginxCertificateResource>> GetIfExistsAsync(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Nginx.NginxCertificateResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Nginx.NginxCertificateResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Nginx.NginxCertificateResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Nginx.NginxCertificateResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NginxCertificateData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.NginxCertificateData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.NginxCertificateData>
    {
        public NginxCertificateData() { }
        public string Location { get { throw null; } set { } }
        public Azure.ResourceManager.Nginx.Models.NginxCertificateProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.NginxCertificateData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.NginxCertificateData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.NginxCertificateData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.NginxCertificateData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.NginxCertificateData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.NginxCertificateData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.NginxCertificateData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NginxCertificateResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.NginxCertificateData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.NginxCertificateData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NginxCertificateResource() { }
        public virtual Azure.ResourceManager.Nginx.NginxCertificateData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string deploymentName, string certificateName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Nginx.NginxCertificateResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Nginx.NginxCertificateResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Nginx.NginxCertificateData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.NginxCertificateData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.NginxCertificateData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.NginxCertificateData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.NginxCertificateData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.NginxCertificateData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.NginxCertificateData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Nginx.NginxCertificateResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Nginx.NginxCertificateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Nginx.NginxCertificateResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Nginx.NginxCertificateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NginxConfigurationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Nginx.NginxConfigurationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Nginx.NginxConfigurationResource>, System.Collections.IEnumerable
    {
        protected NginxConfigurationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Nginx.NginxConfigurationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string configurationName, Azure.ResourceManager.Nginx.Models.NginxConfigurationCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Nginx.NginxConfigurationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string configurationName, Azure.ResourceManager.Nginx.Models.NginxConfigurationCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Nginx.NginxConfigurationResource> Get(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Nginx.NginxConfigurationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Nginx.NginxConfigurationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Nginx.NginxConfigurationResource>> GetAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Nginx.NginxConfigurationResource> GetIfExists(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Nginx.NginxConfigurationResource>> GetIfExistsAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Nginx.NginxConfigurationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Nginx.NginxConfigurationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Nginx.NginxConfigurationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Nginx.NginxConfigurationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NginxConfigurationData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.NginxConfigurationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.NginxConfigurationData>
    {
        internal NginxConfigurationData() { }
        public Azure.ResourceManager.Nginx.Models.NginxConfigurationProperties Properties { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.NginxConfigurationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.NginxConfigurationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.NginxConfigurationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.NginxConfigurationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.NginxConfigurationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.NginxConfigurationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.NginxConfigurationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NginxConfigurationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.NginxConfigurationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.NginxConfigurationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NginxConfigurationResource() { }
        public virtual Azure.ResourceManager.Nginx.NginxConfigurationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Nginx.Models.NginxAnalysisResult> Analysis(Azure.ResourceManager.Nginx.Models.NginxAnalysisContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Nginx.Models.NginxAnalysisResult>> AnalysisAsync(Azure.ResourceManager.Nginx.Models.NginxAnalysisContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string deploymentName, string configurationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Nginx.NginxConfigurationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Nginx.NginxConfigurationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Nginx.NginxConfigurationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.NginxConfigurationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.NginxConfigurationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.NginxConfigurationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.NginxConfigurationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.NginxConfigurationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.NginxConfigurationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Nginx.NginxConfigurationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Nginx.Models.NginxConfigurationCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Nginx.NginxConfigurationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Nginx.Models.NginxConfigurationCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NginxDeploymentApiKeyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Nginx.NginxDeploymentApiKeyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Nginx.NginxDeploymentApiKeyResource>, System.Collections.IEnumerable
    {
        protected NginxDeploymentApiKeyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Nginx.NginxDeploymentApiKeyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string apiKeyName, Azure.ResourceManager.Nginx.Models.NginxDeploymentApiKeyCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Nginx.NginxDeploymentApiKeyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string apiKeyName, Azure.ResourceManager.Nginx.Models.NginxDeploymentApiKeyCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string apiKeyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string apiKeyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Nginx.NginxDeploymentApiKeyResource> Get(string apiKeyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Nginx.NginxDeploymentApiKeyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Nginx.NginxDeploymentApiKeyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Nginx.NginxDeploymentApiKeyResource>> GetAsync(string apiKeyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Nginx.NginxDeploymentApiKeyResource> GetIfExists(string apiKeyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Nginx.NginxDeploymentApiKeyResource>> GetIfExistsAsync(string apiKeyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Nginx.NginxDeploymentApiKeyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Nginx.NginxDeploymentApiKeyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Nginx.NginxDeploymentApiKeyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Nginx.NginxDeploymentApiKeyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NginxDeploymentApiKeyData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.NginxDeploymentApiKeyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.NginxDeploymentApiKeyData>
    {
        internal NginxDeploymentApiKeyData() { }
        public Azure.ResourceManager.Nginx.Models.NginxDeploymentApiKeyProperties Properties { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.NginxDeploymentApiKeyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.NginxDeploymentApiKeyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.NginxDeploymentApiKeyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.NginxDeploymentApiKeyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.NginxDeploymentApiKeyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.NginxDeploymentApiKeyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.NginxDeploymentApiKeyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NginxDeploymentApiKeyResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.NginxDeploymentApiKeyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.NginxDeploymentApiKeyData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NginxDeploymentApiKeyResource() { }
        public virtual Azure.ResourceManager.Nginx.NginxDeploymentApiKeyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string deploymentName, string apiKeyName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Nginx.NginxDeploymentApiKeyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Nginx.NginxDeploymentApiKeyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Nginx.NginxDeploymentApiKeyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.NginxDeploymentApiKeyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.NginxDeploymentApiKeyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.NginxDeploymentApiKeyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.NginxDeploymentApiKeyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.NginxDeploymentApiKeyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.NginxDeploymentApiKeyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Nginx.NginxDeploymentApiKeyResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Nginx.Models.NginxDeploymentApiKeyCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Nginx.NginxDeploymentApiKeyResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Nginx.Models.NginxDeploymentApiKeyCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NginxDeploymentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Nginx.NginxDeploymentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Nginx.NginxDeploymentResource>, System.Collections.IEnumerable
    {
        protected NginxDeploymentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Nginx.NginxDeploymentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string deploymentName, Azure.ResourceManager.Nginx.NginxDeploymentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Nginx.NginxDeploymentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string deploymentName, Azure.ResourceManager.Nginx.NginxDeploymentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Nginx.NginxDeploymentResource> Get(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Nginx.NginxDeploymentResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Nginx.NginxDeploymentResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Nginx.NginxDeploymentResource>> GetAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Nginx.NginxDeploymentResource> GetIfExists(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Nginx.NginxDeploymentResource>> GetIfExistsAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Nginx.NginxDeploymentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Nginx.NginxDeploymentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Nginx.NginxDeploymentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Nginx.NginxDeploymentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NginxDeploymentData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.NginxDeploymentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.NginxDeploymentData>
    {
        public NginxDeploymentData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Nginx.Models.NginxDeploymentProperties Properties { get { throw null; } set { } }
        public string SkuName { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.NginxDeploymentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.NginxDeploymentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.NginxDeploymentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.NginxDeploymentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.NginxDeploymentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.NginxDeploymentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.NginxDeploymentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NginxDeploymentResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.NginxDeploymentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.NginxDeploymentData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NginxDeploymentResource() { }
        public virtual Azure.ResourceManager.Nginx.NginxDeploymentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Nginx.NginxDeploymentResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Nginx.NginxDeploymentResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string deploymentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Nginx.NginxDeploymentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Nginx.NginxDeploymentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Nginx.Models.NginxDeploymentDefaultWafPolicyProperties> GetDefaultWafPolicies(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Nginx.Models.NginxDeploymentDefaultWafPolicyProperties> GetDefaultWafPoliciesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Nginx.NginxCertificateResource> GetNginxCertificate(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Nginx.NginxCertificateResource>> GetNginxCertificateAsync(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Nginx.NginxCertificateCollection GetNginxCertificates() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Nginx.NginxConfigurationResource> GetNginxConfiguration(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Nginx.NginxConfigurationResource>> GetNginxConfigurationAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Nginx.NginxConfigurationCollection GetNginxConfigurations() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Nginx.NginxDeploymentApiKeyResource> GetNginxDeploymentApiKey(string apiKeyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Nginx.NginxDeploymentApiKeyResource>> GetNginxDeploymentApiKeyAsync(string apiKeyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Nginx.NginxDeploymentApiKeyCollection GetNginxDeploymentApiKeys() { throw null; }
        public virtual Azure.ResourceManager.Nginx.NginxDeploymentWafPolicyCollection GetNginxDeploymentWafPolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Nginx.NginxDeploymentWafPolicyResource> GetNginxDeploymentWafPolicy(string wafPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Nginx.NginxDeploymentWafPolicyResource>> GetNginxDeploymentWafPolicyAsync(string wafPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Nginx.Models.NginxDeploymentWafPolicyMetadata> GetWafPolicies(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Nginx.Models.NginxDeploymentWafPolicyMetadata> GetWafPoliciesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Nginx.NginxDeploymentResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Nginx.NginxDeploymentResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Nginx.NginxDeploymentResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Nginx.NginxDeploymentResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Nginx.NginxDeploymentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.NginxDeploymentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.NginxDeploymentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.NginxDeploymentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.NginxDeploymentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.NginxDeploymentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.NginxDeploymentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Nginx.NginxDeploymentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Nginx.Models.NginxDeploymentPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Nginx.NginxDeploymentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Nginx.Models.NginxDeploymentPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NginxDeploymentWafPolicyCollection : Azure.ResourceManager.ArmCollection
    {
        protected NginxDeploymentWafPolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Nginx.NginxDeploymentWafPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string wafPolicyName, Azure.ResourceManager.Nginx.NginxDeploymentWafPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Nginx.NginxDeploymentWafPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string wafPolicyName, Azure.ResourceManager.Nginx.NginxDeploymentWafPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string wafPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string wafPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Nginx.NginxDeploymentWafPolicyResource> Get(string wafPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Nginx.NginxDeploymentWafPolicyResource>> GetAsync(string wafPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Nginx.NginxDeploymentWafPolicyResource> GetIfExists(string wafPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Nginx.NginxDeploymentWafPolicyResource>> GetIfExistsAsync(string wafPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NginxDeploymentWafPolicyData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.NginxDeploymentWafPolicyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.NginxDeploymentWafPolicyData>
    {
        public NginxDeploymentWafPolicyData() { }
        public Azure.ResourceManager.Nginx.Models.NginxDeploymentWafPolicyProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.NginxDeploymentWafPolicyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.NginxDeploymentWafPolicyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.NginxDeploymentWafPolicyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.NginxDeploymentWafPolicyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.NginxDeploymentWafPolicyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.NginxDeploymentWafPolicyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.NginxDeploymentWafPolicyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NginxDeploymentWafPolicyResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.NginxDeploymentWafPolicyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.NginxDeploymentWafPolicyData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NginxDeploymentWafPolicyResource() { }
        public virtual Azure.ResourceManager.Nginx.NginxDeploymentWafPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string deploymentName, string wafPolicyName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Nginx.NginxDeploymentWafPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Nginx.NginxDeploymentWafPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Nginx.NginxDeploymentWafPolicyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.NginxDeploymentWafPolicyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.NginxDeploymentWafPolicyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.NginxDeploymentWafPolicyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.NginxDeploymentWafPolicyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.NginxDeploymentWafPolicyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.NginxDeploymentWafPolicyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Nginx.NginxDeploymentWafPolicyResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Nginx.NginxDeploymentWafPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Nginx.NginxDeploymentWafPolicyResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Nginx.NginxDeploymentWafPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class NginxExtensions
    {
        public static Azure.ResourceManager.Nginx.NginxCertificateResource GetNginxCertificateResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Nginx.NginxConfigurationResource GetNginxConfigurationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Nginx.NginxDeploymentResource> GetNginxDeployment(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Nginx.NginxDeploymentApiKeyResource GetNginxDeploymentApiKeyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Nginx.NginxDeploymentResource>> GetNginxDeploymentAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Nginx.NginxDeploymentResource GetNginxDeploymentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Nginx.NginxDeploymentCollection GetNginxDeployments(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Nginx.NginxDeploymentResource> GetNginxDeployments(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Nginx.NginxDeploymentResource> GetNginxDeploymentsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Nginx.NginxDeploymentWafPolicyResource GetNginxDeploymentWafPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
}
namespace Azure.ResourceManager.Nginx.Mocking
{
    public partial class MockableNginxArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableNginxArmClient() { }
        public virtual Azure.ResourceManager.Nginx.NginxCertificateResource GetNginxCertificateResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Nginx.NginxConfigurationResource GetNginxConfigurationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Nginx.NginxDeploymentApiKeyResource GetNginxDeploymentApiKeyResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Nginx.NginxDeploymentResource GetNginxDeploymentResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Nginx.NginxDeploymentWafPolicyResource GetNginxDeploymentWafPolicyResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableNginxResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableNginxResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Nginx.NginxDeploymentResource> GetNginxDeployment(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Nginx.NginxDeploymentResource>> GetNginxDeploymentAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Nginx.NginxDeploymentCollection GetNginxDeployments() { throw null; }
    }
    public partial class MockableNginxSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableNginxSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Nginx.NginxDeploymentResource> GetNginxDeployments(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Nginx.NginxDeploymentResource> GetNginxDeploymentsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Nginx.Models
{
    public static partial class ArmNginxModelFactory
    {
        public static Azure.ResourceManager.Nginx.Models.NginxAnalysisDiagnostic NginxAnalysisDiagnostic(string id = null, string directive = null, string description = null, string file = null, float line = 0f, string message = null, string rule = null) { throw null; }
        public static Azure.ResourceManager.Nginx.Models.NginxAnalysisResult NginxAnalysisResult(string status = null, Azure.ResourceManager.Nginx.Models.NginxAnalysisResultDetails data = null) { throw null; }
        public static Azure.ResourceManager.Nginx.Models.NginxAnalysisResultDetails NginxAnalysisResultDetails(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Nginx.Models.NginxAnalysisDiagnostic> errors = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Nginx.Models.NginxDiagnosticItem> diagnostics = null) { throw null; }
        public static Azure.ResourceManager.Nginx.NginxCertificateData NginxCertificateData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Nginx.Models.NginxCertificateProperties properties = null, string location = null) { throw null; }
        public static Azure.ResourceManager.Nginx.Models.NginxCertificateProperties NginxCertificateProperties(Azure.ResourceManager.Nginx.Models.NginxProvisioningState? provisioningState = default(Azure.ResourceManager.Nginx.Models.NginxProvisioningState?), string keyVirtualPath = null, string certificateVirtualPath = null, string keyVaultSecretId = null, string sha1Thumbprint = null, string keyVaultSecretVersion = null, System.DateTimeOffset? keyVaultSecretCreated = default(System.DateTimeOffset?), Azure.ResourceManager.Nginx.Models.NginxCertificateError certificateError = null) { throw null; }
        public static Azure.ResourceManager.Nginx.Models.NginxConfigurationCreateOrUpdateContent NginxConfigurationCreateOrUpdateContent(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Nginx.Models.NginxConfigurationCreateOrUpdateProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Nginx.Models.NginxConfigurationCreateOrUpdateProperties NginxConfigurationCreateOrUpdateProperties(Azure.ResourceManager.Nginx.Models.NginxProvisioningState? provisioningState = default(Azure.ResourceManager.Nginx.Models.NginxProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Nginx.Models.NginxConfigurationFile> files = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Nginx.Models.NginxConfigurationProtectedFileContent> protectedFiles = null, Azure.ResourceManager.Nginx.Models.NginxConfigurationPackage package = null, string rootFile = null) { throw null; }
        public static Azure.ResourceManager.Nginx.NginxConfigurationData NginxConfigurationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Nginx.Models.NginxConfigurationProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Nginx.Models.NginxConfigurationProperties NginxConfigurationProperties(Azure.ResourceManager.Nginx.Models.NginxProvisioningState? provisioningState = default(Azure.ResourceManager.Nginx.Models.NginxProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Nginx.Models.NginxConfigurationFile> files = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Nginx.Models.NginxConfigurationProtectedFileResult> protectedFiles = null, Azure.ResourceManager.Nginx.Models.NginxConfigurationPackage package = null, string rootFile = null) { throw null; }
        public static Azure.ResourceManager.Nginx.Models.NginxConfigurationProtectedFileResult NginxConfigurationProtectedFileResult(string virtualPath = null, string contentHash = null) { throw null; }
        public static Azure.ResourceManager.Nginx.Models.NginxDeploymentApiKeyCreateOrUpdateContent NginxDeploymentApiKeyCreateOrUpdateContent(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Nginx.Models.NginxDeploymentApiKeyRequestProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Nginx.NginxDeploymentApiKeyData NginxDeploymentApiKeyData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Nginx.Models.NginxDeploymentApiKeyProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Nginx.Models.NginxDeploymentApiKeyProperties NginxDeploymentApiKeyProperties(string hint = null, System.DateTimeOffset? endOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Nginx.NginxDeploymentData NginxDeploymentData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Nginx.Models.NginxDeploymentProperties properties = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, string skuName = null) { throw null; }
        public static Azure.ResourceManager.Nginx.Models.NginxDeploymentDefaultWafPolicyProperties NginxDeploymentDefaultWafPolicyProperties(byte[] content = null, string filepath = null) { throw null; }
        public static Azure.ResourceManager.Nginx.Models.NginxDeploymentProperties NginxDeploymentProperties(Azure.ResourceManager.Nginx.Models.NginxProvisioningState? provisioningState = default(Azure.ResourceManager.Nginx.Models.NginxProvisioningState?), string nginxVersion = null, Azure.ResourceManager.Nginx.Models.NginxNetworkProfile networkProfile = null, string ipAddress = null, bool? enableDiagnosticsSupport = default(bool?), Azure.ResourceManager.Nginx.Models.NginxStorageAccount loggingStorageAccount = null, Azure.ResourceManager.Nginx.Models.NginxDeploymentScalingProperties scalingProperties = null, string upgradeChannel = null, string userPreferredEmail = null, Azure.ResourceManager.Nginx.Models.NginxDeploymentPropertiesNginxAppProtect nginxAppProtect = null, string dataplaneApiEndpoint = null) { throw null; }
        public static Azure.ResourceManager.Nginx.Models.NginxDeploymentPropertiesNginxAppProtect NginxDeploymentPropertiesNginxAppProtect(Azure.ResourceManager.Nginx.Models.WebApplicationFirewallActivationState? webApplicationFirewallActivationState = default(Azure.ResourceManager.Nginx.Models.WebApplicationFirewallActivationState?), Azure.ResourceManager.Nginx.Models.WebApplicationFirewallStatus webApplicationFirewallStatus = null) { throw null; }
        public static Azure.ResourceManager.Nginx.Models.NginxDeploymentWafPolicyApplyingStatus NginxDeploymentWafPolicyApplyingStatus(Azure.ResourceManager.Nginx.Models.NginxDeploymentWafPolicyApplyingStatusCode? code = default(Azure.ResourceManager.Nginx.Models.NginxDeploymentWafPolicyApplyingStatusCode?), string displayStatus = null, string time = null) { throw null; }
        public static Azure.ResourceManager.Nginx.Models.NginxDeploymentWafPolicyCompilingStatus NginxDeploymentWafPolicyCompilingStatus(Azure.ResourceManager.Nginx.Models.NginxDeploymentWafPolicyCompilingStatusCode? code = default(Azure.ResourceManager.Nginx.Models.NginxDeploymentWafPolicyCompilingStatusCode?), string displayStatus = null, string time = null) { throw null; }
        public static Azure.ResourceManager.Nginx.NginxDeploymentWafPolicyData NginxDeploymentWafPolicyData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Nginx.Models.NginxDeploymentWafPolicyProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Nginx.Models.NginxDeploymentWafPolicyMetadata NginxDeploymentWafPolicyMetadata(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Nginx.Models.NginxDeploymentWafPolicyMetadataProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Nginx.Models.NginxDeploymentWafPolicyMetadataProperties NginxDeploymentWafPolicyMetadataProperties(string filepath = null, Azure.ResourceManager.Nginx.Models.NginxProvisioningState? provisioningState = default(Azure.ResourceManager.Nginx.Models.NginxProvisioningState?), Azure.ResourceManager.Nginx.Models.NginxDeploymentWafPolicyCompilingStatus compilingState = null, Azure.ResourceManager.Nginx.Models.NginxDeploymentWafPolicyApplyingStatus applyingState = null) { throw null; }
        public static Azure.ResourceManager.Nginx.Models.NginxDeploymentWafPolicyProperties NginxDeploymentWafPolicyProperties(Azure.ResourceManager.Nginx.Models.NginxProvisioningState? provisioningState = default(Azure.ResourceManager.Nginx.Models.NginxProvisioningState?), byte[] content = null, string filepath = null, Azure.ResourceManager.Nginx.Models.NginxDeploymentWafPolicyCompilingStatus compilingState = null, Azure.ResourceManager.Nginx.Models.NginxDeploymentWafPolicyApplyingStatus applyingState = null) { throw null; }
        public static Azure.ResourceManager.Nginx.Models.NginxDiagnosticItem NginxDiagnosticItem(string id = null, string directive = null, string description = null, string file = null, float line = 0f, string message = null, string rule = null, Azure.ResourceManager.Nginx.Models.NginxDiagnosticLevel level = default(Azure.ResourceManager.Nginx.Models.NginxDiagnosticLevel), string category = null) { throw null; }
        public static Azure.ResourceManager.Nginx.Models.WebApplicationFirewallComponentVersions WebApplicationFirewallComponentVersions(string wafEngineVersion = null, string wafNginxVersion = null) { throw null; }
        public static Azure.ResourceManager.Nginx.Models.WebApplicationFirewallPackage WebApplicationFirewallPackage(string version = null, System.DateTimeOffset revisionDatetime = default(System.DateTimeOffset)) { throw null; }
        public static Azure.ResourceManager.Nginx.Models.WebApplicationFirewallStatus WebApplicationFirewallStatus(string wafRelease = null, Azure.ResourceManager.Nginx.Models.WebApplicationFirewallPackage attackSignaturesPackage = null, Azure.ResourceManager.Nginx.Models.WebApplicationFirewallPackage botSignaturesPackage = null, Azure.ResourceManager.Nginx.Models.WebApplicationFirewallPackage threatCampaignsPackage = null, Azure.ResourceManager.Nginx.Models.WebApplicationFirewallComponentVersions componentVersions = null) { throw null; }
    }
    public partial class NginxAnalysisConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxAnalysisConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxAnalysisConfig>
    {
        public NginxAnalysisConfig() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Nginx.Models.NginxConfigurationFile> Files { get { throw null; } }
        public Azure.ResourceManager.Nginx.Models.NginxConfigurationPackage Package { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Nginx.Models.NginxConfigurationProtectedFileContent> ProtectedFiles { get { throw null; } }
        public string RootFile { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.Models.NginxAnalysisConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxAnalysisConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxAnalysisConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.Models.NginxAnalysisConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxAnalysisConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxAnalysisConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxAnalysisConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NginxAnalysisContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxAnalysisContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxAnalysisContent>
    {
        public NginxAnalysisContent(Azure.ResourceManager.Nginx.Models.NginxAnalysisConfig config) { }
        public Azure.ResourceManager.Nginx.Models.NginxAnalysisConfig Config { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.Models.NginxAnalysisContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxAnalysisContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxAnalysisContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.Models.NginxAnalysisContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxAnalysisContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxAnalysisContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxAnalysisContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NginxAnalysisDiagnostic : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxAnalysisDiagnostic>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxAnalysisDiagnostic>
    {
        internal NginxAnalysisDiagnostic() { }
        public string Description { get { throw null; } }
        public string Directive { get { throw null; } }
        public string File { get { throw null; } }
        public string Id { get { throw null; } }
        public float Line { get { throw null; } }
        public string Message { get { throw null; } }
        public string Rule { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.Models.NginxAnalysisDiagnostic System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxAnalysisDiagnostic>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxAnalysisDiagnostic>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.Models.NginxAnalysisDiagnostic System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxAnalysisDiagnostic>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxAnalysisDiagnostic>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxAnalysisDiagnostic>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NginxAnalysisResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxAnalysisResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxAnalysisResult>
    {
        internal NginxAnalysisResult() { }
        public Azure.ResourceManager.Nginx.Models.NginxAnalysisResultDetails Data { get { throw null; } }
        public string Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.Models.NginxAnalysisResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxAnalysisResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxAnalysisResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.Models.NginxAnalysisResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxAnalysisResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxAnalysisResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxAnalysisResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NginxAnalysisResultDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxAnalysisResultDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxAnalysisResultDetails>
    {
        internal NginxAnalysisResultDetails() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Nginx.Models.NginxDiagnosticItem> Diagnostics { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Nginx.Models.NginxAnalysisDiagnostic> Errors { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.Models.NginxAnalysisResultDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxAnalysisResultDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxAnalysisResultDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.Models.NginxAnalysisResultDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxAnalysisResultDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxAnalysisResultDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxAnalysisResultDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NginxCertificateError : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxCertificateError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxCertificateError>
    {
        public NginxCertificateError() { }
        public string Code { get { throw null; } set { } }
        public string Message { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.Models.NginxCertificateError System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxCertificateError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxCertificateError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.Models.NginxCertificateError System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxCertificateError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxCertificateError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxCertificateError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NginxCertificateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxCertificateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxCertificateProperties>
    {
        public NginxCertificateProperties() { }
        public Azure.ResourceManager.Nginx.Models.NginxCertificateError CertificateError { get { throw null; } set { } }
        public string CertificateVirtualPath { get { throw null; } set { } }
        public System.DateTimeOffset? KeyVaultSecretCreated { get { throw null; } }
        public string KeyVaultSecretId { get { throw null; } set { } }
        public string KeyVaultSecretVersion { get { throw null; } }
        public string KeyVirtualPath { get { throw null; } set { } }
        public Azure.ResourceManager.Nginx.Models.NginxProvisioningState? ProvisioningState { get { throw null; } }
        public string Sha1Thumbprint { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.Models.NginxCertificateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxCertificateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxCertificateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.Models.NginxCertificateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxCertificateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxCertificateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxCertificateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NginxConfigurationCreateOrUpdateContent : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxConfigurationCreateOrUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxConfigurationCreateOrUpdateContent>
    {
        public NginxConfigurationCreateOrUpdateContent() { }
        public Azure.ResourceManager.Nginx.Models.NginxConfigurationCreateOrUpdateProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.Models.NginxConfigurationCreateOrUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxConfigurationCreateOrUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxConfigurationCreateOrUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.Models.NginxConfigurationCreateOrUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxConfigurationCreateOrUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxConfigurationCreateOrUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxConfigurationCreateOrUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NginxConfigurationCreateOrUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxConfigurationCreateOrUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxConfigurationCreateOrUpdateProperties>
    {
        public NginxConfigurationCreateOrUpdateProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Nginx.Models.NginxConfigurationFile> Files { get { throw null; } }
        public Azure.ResourceManager.Nginx.Models.NginxConfigurationPackage Package { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Nginx.Models.NginxConfigurationProtectedFileContent> ProtectedFiles { get { throw null; } }
        public Azure.ResourceManager.Nginx.Models.NginxProvisioningState? ProvisioningState { get { throw null; } }
        public string RootFile { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.Models.NginxConfigurationCreateOrUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxConfigurationCreateOrUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxConfigurationCreateOrUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.Models.NginxConfigurationCreateOrUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxConfigurationCreateOrUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxConfigurationCreateOrUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxConfigurationCreateOrUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NginxConfigurationFile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxConfigurationFile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxConfigurationFile>
    {
        public NginxConfigurationFile() { }
        public string Content { get { throw null; } set { } }
        public string VirtualPath { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.Models.NginxConfigurationFile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxConfigurationFile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxConfigurationFile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.Models.NginxConfigurationFile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxConfigurationFile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxConfigurationFile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxConfigurationFile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NginxConfigurationPackage : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxConfigurationPackage>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxConfigurationPackage>
    {
        public NginxConfigurationPackage() { }
        public string Data { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ProtectedFiles { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.Models.NginxConfigurationPackage System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxConfigurationPackage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxConfigurationPackage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.Models.NginxConfigurationPackage System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxConfigurationPackage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxConfigurationPackage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxConfigurationPackage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NginxConfigurationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxConfigurationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxConfigurationProperties>
    {
        internal NginxConfigurationProperties() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Nginx.Models.NginxConfigurationFile> Files { get { throw null; } }
        public Azure.ResourceManager.Nginx.Models.NginxConfigurationPackage Package { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Nginx.Models.NginxConfigurationProtectedFileResult> ProtectedFiles { get { throw null; } }
        public Azure.ResourceManager.Nginx.Models.NginxProvisioningState? ProvisioningState { get { throw null; } }
        public string RootFile { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.Models.NginxConfigurationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxConfigurationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxConfigurationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.Models.NginxConfigurationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxConfigurationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxConfigurationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxConfigurationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NginxConfigurationProtectedFileContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxConfigurationProtectedFileContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxConfigurationProtectedFileContent>
    {
        public NginxConfigurationProtectedFileContent() { }
        public string Content { get { throw null; } set { } }
        public string ContentHash { get { throw null; } set { } }
        public string VirtualPath { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.Models.NginxConfigurationProtectedFileContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxConfigurationProtectedFileContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxConfigurationProtectedFileContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.Models.NginxConfigurationProtectedFileContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxConfigurationProtectedFileContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxConfigurationProtectedFileContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxConfigurationProtectedFileContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NginxConfigurationProtectedFileResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxConfigurationProtectedFileResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxConfigurationProtectedFileResult>
    {
        internal NginxConfigurationProtectedFileResult() { }
        public string ContentHash { get { throw null; } }
        public string VirtualPath { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.Models.NginxConfigurationProtectedFileResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxConfigurationProtectedFileResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxConfigurationProtectedFileResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.Models.NginxConfigurationProtectedFileResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxConfigurationProtectedFileResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxConfigurationProtectedFileResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxConfigurationProtectedFileResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NginxDeploymentApiKeyCreateOrUpdateContent : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentApiKeyCreateOrUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentApiKeyCreateOrUpdateContent>
    {
        public NginxDeploymentApiKeyCreateOrUpdateContent() { }
        public Azure.ResourceManager.Nginx.Models.NginxDeploymentApiKeyRequestProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.Models.NginxDeploymentApiKeyCreateOrUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentApiKeyCreateOrUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentApiKeyCreateOrUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.Models.NginxDeploymentApiKeyCreateOrUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentApiKeyCreateOrUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentApiKeyCreateOrUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentApiKeyCreateOrUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NginxDeploymentApiKeyProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentApiKeyProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentApiKeyProperties>
    {
        internal NginxDeploymentApiKeyProperties() { }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public string Hint { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.Models.NginxDeploymentApiKeyProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentApiKeyProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentApiKeyProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.Models.NginxDeploymentApiKeyProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentApiKeyProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentApiKeyProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentApiKeyProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NginxDeploymentApiKeyRequestProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentApiKeyRequestProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentApiKeyRequestProperties>
    {
        public NginxDeploymentApiKeyRequestProperties() { }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public string SecretText { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.Models.NginxDeploymentApiKeyRequestProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentApiKeyRequestProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentApiKeyRequestProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.Models.NginxDeploymentApiKeyRequestProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentApiKeyRequestProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentApiKeyRequestProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentApiKeyRequestProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NginxDeploymentDefaultWafPolicyProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentDefaultWafPolicyProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentDefaultWafPolicyProperties>
    {
        internal NginxDeploymentDefaultWafPolicyProperties() { }
        public byte[] Content { get { throw null; } }
        public string Filepath { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.Models.NginxDeploymentDefaultWafPolicyProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentDefaultWafPolicyProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentDefaultWafPolicyProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.Models.NginxDeploymentDefaultWafPolicyProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentDefaultWafPolicyProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentDefaultWafPolicyProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentDefaultWafPolicyProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NginxDeploymentPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentPatch>
    {
        public NginxDeploymentPatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public Azure.ResourceManager.Nginx.Models.NginxDeploymentUpdateProperties Properties { get { throw null; } set { } }
        public string SkuName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.Models.NginxDeploymentPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.Models.NginxDeploymentPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NginxDeploymentProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentProperties>
    {
        public NginxDeploymentProperties() { }
        public string DataplaneApiEndpoint { get { throw null; } }
        public bool? EnableDiagnosticsSupport { get { throw null; } set { } }
        public string IPAddress { get { throw null; } }
        public Azure.ResourceManager.Nginx.Models.NginxStorageAccount LoggingStorageAccount { get { throw null; } set { } }
        public Azure.ResourceManager.Nginx.Models.NginxNetworkProfile NetworkProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Nginx.Models.NginxDeploymentPropertiesNginxAppProtect NginxAppProtect { get { throw null; } set { } }
        public string NginxVersion { get { throw null; } }
        public Azure.ResourceManager.Nginx.Models.NginxProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Nginx.Models.NginxDeploymentScalingProperties ScalingProperties { get { throw null; } set { } }
        public string UpgradeChannel { get { throw null; } set { } }
        public string UserPreferredEmail { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.Models.NginxDeploymentProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.Models.NginxDeploymentProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NginxDeploymentPropertiesNginxAppProtect : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentPropertiesNginxAppProtect>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentPropertiesNginxAppProtect>
    {
        public NginxDeploymentPropertiesNginxAppProtect(Azure.ResourceManager.Nginx.Models.WebApplicationFirewallSettings webApplicationFirewallSettings) { }
        public Azure.ResourceManager.Nginx.Models.WebApplicationFirewallActivationState? WebApplicationFirewallActivationState { get { throw null; } set { } }
        public Azure.ResourceManager.Nginx.Models.WebApplicationFirewallStatus WebApplicationFirewallStatus { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.Models.NginxDeploymentPropertiesNginxAppProtect System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentPropertiesNginxAppProtect>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentPropertiesNginxAppProtect>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.Models.NginxDeploymentPropertiesNginxAppProtect System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentPropertiesNginxAppProtect>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentPropertiesNginxAppProtect>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentPropertiesNginxAppProtect>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NginxDeploymentScalingProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentScalingProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentScalingProperties>
    {
        public NginxDeploymentScalingProperties() { }
        public int? Capacity { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Nginx.Models.NginxScaleProfile> Profiles { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.Models.NginxDeploymentScalingProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentScalingProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentScalingProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.Models.NginxDeploymentScalingProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentScalingProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentScalingProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentScalingProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NginxDeploymentUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentUpdateProperties>
    {
        public NginxDeploymentUpdateProperties() { }
        public bool? EnableDiagnosticsSupport { get { throw null; } set { } }
        public Azure.ResourceManager.Nginx.Models.NginxStorageAccount LoggingStorageAccount { get { throw null; } set { } }
        public Azure.ResourceManager.Nginx.Models.NginxNetworkProfile NetworkProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Nginx.Models.NginxDeploymentScalingProperties ScalingProperties { get { throw null; } set { } }
        public string UpgradeChannel { get { throw null; } set { } }
        public string UserPreferredEmail { get { throw null; } set { } }
        public Azure.ResourceManager.Nginx.Models.WebApplicationFirewallActivationState? WebApplicationFirewallActivationState { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.Models.NginxDeploymentUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.Models.NginxDeploymentUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NginxDeploymentWafPolicyApplyingStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentWafPolicyApplyingStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentWafPolicyApplyingStatus>
    {
        internal NginxDeploymentWafPolicyApplyingStatus() { }
        public Azure.ResourceManager.Nginx.Models.NginxDeploymentWafPolicyApplyingStatusCode? Code { get { throw null; } }
        public string DisplayStatus { get { throw null; } }
        public string Time { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.Models.NginxDeploymentWafPolicyApplyingStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentWafPolicyApplyingStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentWafPolicyApplyingStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.Models.NginxDeploymentWafPolicyApplyingStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentWafPolicyApplyingStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentWafPolicyApplyingStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentWafPolicyApplyingStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NginxDeploymentWafPolicyApplyingStatusCode : System.IEquatable<Azure.ResourceManager.Nginx.Models.NginxDeploymentWafPolicyApplyingStatusCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NginxDeploymentWafPolicyApplyingStatusCode(string value) { throw null; }
        public static Azure.ResourceManager.Nginx.Models.NginxDeploymentWafPolicyApplyingStatusCode Applying { get { throw null; } }
        public static Azure.ResourceManager.Nginx.Models.NginxDeploymentWafPolicyApplyingStatusCode Failed { get { throw null; } }
        public static Azure.ResourceManager.Nginx.Models.NginxDeploymentWafPolicyApplyingStatusCode NotApplied { get { throw null; } }
        public static Azure.ResourceManager.Nginx.Models.NginxDeploymentWafPolicyApplyingStatusCode Removing { get { throw null; } }
        public static Azure.ResourceManager.Nginx.Models.NginxDeploymentWafPolicyApplyingStatusCode Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Nginx.Models.NginxDeploymentWafPolicyApplyingStatusCode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Nginx.Models.NginxDeploymentWafPolicyApplyingStatusCode left, Azure.ResourceManager.Nginx.Models.NginxDeploymentWafPolicyApplyingStatusCode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Nginx.Models.NginxDeploymentWafPolicyApplyingStatusCode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Nginx.Models.NginxDeploymentWafPolicyApplyingStatusCode left, Azure.ResourceManager.Nginx.Models.NginxDeploymentWafPolicyApplyingStatusCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NginxDeploymentWafPolicyCompilingStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentWafPolicyCompilingStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentWafPolicyCompilingStatus>
    {
        internal NginxDeploymentWafPolicyCompilingStatus() { }
        public Azure.ResourceManager.Nginx.Models.NginxDeploymentWafPolicyCompilingStatusCode? Code { get { throw null; } }
        public string DisplayStatus { get { throw null; } }
        public string Time { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.Models.NginxDeploymentWafPolicyCompilingStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentWafPolicyCompilingStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentWafPolicyCompilingStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.Models.NginxDeploymentWafPolicyCompilingStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentWafPolicyCompilingStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentWafPolicyCompilingStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentWafPolicyCompilingStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NginxDeploymentWafPolicyCompilingStatusCode : System.IEquatable<Azure.ResourceManager.Nginx.Models.NginxDeploymentWafPolicyCompilingStatusCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NginxDeploymentWafPolicyCompilingStatusCode(string value) { throw null; }
        public static Azure.ResourceManager.Nginx.Models.NginxDeploymentWafPolicyCompilingStatusCode Failed { get { throw null; } }
        public static Azure.ResourceManager.Nginx.Models.NginxDeploymentWafPolicyCompilingStatusCode InProgress { get { throw null; } }
        public static Azure.ResourceManager.Nginx.Models.NginxDeploymentWafPolicyCompilingStatusCode NotStarted { get { throw null; } }
        public static Azure.ResourceManager.Nginx.Models.NginxDeploymentWafPolicyCompilingStatusCode Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Nginx.Models.NginxDeploymentWafPolicyCompilingStatusCode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Nginx.Models.NginxDeploymentWafPolicyCompilingStatusCode left, Azure.ResourceManager.Nginx.Models.NginxDeploymentWafPolicyCompilingStatusCode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Nginx.Models.NginxDeploymentWafPolicyCompilingStatusCode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Nginx.Models.NginxDeploymentWafPolicyCompilingStatusCode left, Azure.ResourceManager.Nginx.Models.NginxDeploymentWafPolicyCompilingStatusCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NginxDeploymentWafPolicyMetadata : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentWafPolicyMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentWafPolicyMetadata>
    {
        internal NginxDeploymentWafPolicyMetadata() { }
        public Azure.ResourceManager.Nginx.Models.NginxDeploymentWafPolicyMetadataProperties Properties { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.Models.NginxDeploymentWafPolicyMetadata System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentWafPolicyMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentWafPolicyMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.Models.NginxDeploymentWafPolicyMetadata System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentWafPolicyMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentWafPolicyMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentWafPolicyMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NginxDeploymentWafPolicyMetadataProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentWafPolicyMetadataProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentWafPolicyMetadataProperties>
    {
        internal NginxDeploymentWafPolicyMetadataProperties() { }
        public Azure.ResourceManager.Nginx.Models.NginxDeploymentWafPolicyApplyingStatus ApplyingState { get { throw null; } }
        public Azure.ResourceManager.Nginx.Models.NginxDeploymentWafPolicyCompilingStatus CompilingState { get { throw null; } }
        public string Filepath { get { throw null; } }
        public Azure.ResourceManager.Nginx.Models.NginxProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.Models.NginxDeploymentWafPolicyMetadataProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentWafPolicyMetadataProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentWafPolicyMetadataProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.Models.NginxDeploymentWafPolicyMetadataProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentWafPolicyMetadataProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentWafPolicyMetadataProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentWafPolicyMetadataProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NginxDeploymentWafPolicyProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentWafPolicyProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentWafPolicyProperties>
    {
        public NginxDeploymentWafPolicyProperties() { }
        public Azure.ResourceManager.Nginx.Models.NginxDeploymentWafPolicyApplyingStatus ApplyingState { get { throw null; } }
        public Azure.ResourceManager.Nginx.Models.NginxDeploymentWafPolicyCompilingStatus CompilingState { get { throw null; } }
        public byte[] Content { get { throw null; } set { } }
        public string Filepath { get { throw null; } set { } }
        public Azure.ResourceManager.Nginx.Models.NginxProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.Models.NginxDeploymentWafPolicyProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentWafPolicyProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentWafPolicyProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.Models.NginxDeploymentWafPolicyProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentWafPolicyProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentWafPolicyProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentWafPolicyProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NginxDiagnosticItem : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxDiagnosticItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxDiagnosticItem>
    {
        internal NginxDiagnosticItem() { }
        public string Category { get { throw null; } }
        public string Description { get { throw null; } }
        public string Directive { get { throw null; } }
        public string File { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.ResourceManager.Nginx.Models.NginxDiagnosticLevel Level { get { throw null; } }
        public float Line { get { throw null; } }
        public string Message { get { throw null; } }
        public string Rule { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.Models.NginxDiagnosticItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxDiagnosticItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxDiagnosticItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.Models.NginxDiagnosticItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxDiagnosticItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxDiagnosticItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxDiagnosticItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NginxDiagnosticLevel : System.IEquatable<Azure.ResourceManager.Nginx.Models.NginxDiagnosticLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NginxDiagnosticLevel(string value) { throw null; }
        public static Azure.ResourceManager.Nginx.Models.NginxDiagnosticLevel Info { get { throw null; } }
        public static Azure.ResourceManager.Nginx.Models.NginxDiagnosticLevel Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Nginx.Models.NginxDiagnosticLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Nginx.Models.NginxDiagnosticLevel left, Azure.ResourceManager.Nginx.Models.NginxDiagnosticLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.Nginx.Models.NginxDiagnosticLevel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Nginx.Models.NginxDiagnosticLevel left, Azure.ResourceManager.Nginx.Models.NginxDiagnosticLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NginxFrontendIPConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxFrontendIPConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxFrontendIPConfiguration>
    {
        public NginxFrontendIPConfiguration() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Nginx.Models.NginxPrivateIPAddress> PrivateIPAddresses { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> PublicIPAddresses { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.Models.NginxFrontendIPConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxFrontendIPConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxFrontendIPConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.Models.NginxFrontendIPConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxFrontendIPConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxFrontendIPConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxFrontendIPConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NginxNetworkProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxNetworkProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxNetworkProfile>
    {
        public NginxNetworkProfile() { }
        public Azure.ResourceManager.Nginx.Models.NginxFrontendIPConfiguration FrontEndIPConfiguration { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier NetworkInterfaceSubnetId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.Models.NginxNetworkProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxNetworkProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxNetworkProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.Models.NginxNetworkProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxNetworkProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxNetworkProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxNetworkProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NginxPrivateIPAddress : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxPrivateIPAddress>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxPrivateIPAddress>
    {
        public NginxPrivateIPAddress() { }
        public System.Net.IPAddress PrivateIPAddress { get { throw null; } set { } }
        public Azure.ResourceManager.Nginx.Models.NginxPrivateIPAllocationMethod? PrivateIPAllocationMethod { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.Models.NginxPrivateIPAddress System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxPrivateIPAddress>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxPrivateIPAddress>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.Models.NginxPrivateIPAddress System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxPrivateIPAddress>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxPrivateIPAddress>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxPrivateIPAddress>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NginxPrivateIPAllocationMethod : System.IEquatable<Azure.ResourceManager.Nginx.Models.NginxPrivateIPAllocationMethod>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NginxPrivateIPAllocationMethod(string value) { throw null; }
        public static Azure.ResourceManager.Nginx.Models.NginxPrivateIPAllocationMethod Dynamic { get { throw null; } }
        public static Azure.ResourceManager.Nginx.Models.NginxPrivateIPAllocationMethod Static { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Nginx.Models.NginxPrivateIPAllocationMethod other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Nginx.Models.NginxPrivateIPAllocationMethod left, Azure.ResourceManager.Nginx.Models.NginxPrivateIPAllocationMethod right) { throw null; }
        public static implicit operator Azure.ResourceManager.Nginx.Models.NginxPrivateIPAllocationMethod (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Nginx.Models.NginxPrivateIPAllocationMethod left, Azure.ResourceManager.Nginx.Models.NginxPrivateIPAllocationMethod right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NginxProvisioningState : System.IEquatable<Azure.ResourceManager.Nginx.Models.NginxProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NginxProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Nginx.Models.NginxProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.Nginx.Models.NginxProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Nginx.Models.NginxProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Nginx.Models.NginxProvisioningState Deleted { get { throw null; } }
        public static Azure.ResourceManager.Nginx.Models.NginxProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Nginx.Models.NginxProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Nginx.Models.NginxProvisioningState NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Nginx.Models.NginxProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Nginx.Models.NginxProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Nginx.Models.NginxProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Nginx.Models.NginxProvisioningState left, Azure.ResourceManager.Nginx.Models.NginxProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Nginx.Models.NginxProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Nginx.Models.NginxProvisioningState left, Azure.ResourceManager.Nginx.Models.NginxProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NginxScaleProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxScaleProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxScaleProfile>
    {
        public NginxScaleProfile(string name, Azure.ResourceManager.Nginx.Models.NginxScaleProfileCapacity capacity) { }
        public Azure.ResourceManager.Nginx.Models.NginxScaleProfileCapacity Capacity { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.Models.NginxScaleProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxScaleProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxScaleProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.Models.NginxScaleProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxScaleProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxScaleProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxScaleProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NginxScaleProfileCapacity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxScaleProfileCapacity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxScaleProfileCapacity>
    {
        public NginxScaleProfileCapacity(int min, int max) { }
        public int Max { get { throw null; } set { } }
        public int Min { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.Models.NginxScaleProfileCapacity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxScaleProfileCapacity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxScaleProfileCapacity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.Models.NginxScaleProfileCapacity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxScaleProfileCapacity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxScaleProfileCapacity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxScaleProfileCapacity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NginxStorageAccount : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxStorageAccount>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxStorageAccount>
    {
        public NginxStorageAccount() { }
        public string AccountName { get { throw null; } set { } }
        public string ContainerName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.Models.NginxStorageAccount System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxStorageAccount>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxStorageAccount>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.Models.NginxStorageAccount System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxStorageAccount>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxStorageAccount>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxStorageAccount>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WebApplicationFirewallActivationState : System.IEquatable<Azure.ResourceManager.Nginx.Models.WebApplicationFirewallActivationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WebApplicationFirewallActivationState(string value) { throw null; }
        public static Azure.ResourceManager.Nginx.Models.WebApplicationFirewallActivationState Disabled { get { throw null; } }
        public static Azure.ResourceManager.Nginx.Models.WebApplicationFirewallActivationState Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Nginx.Models.WebApplicationFirewallActivationState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Nginx.Models.WebApplicationFirewallActivationState left, Azure.ResourceManager.Nginx.Models.WebApplicationFirewallActivationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Nginx.Models.WebApplicationFirewallActivationState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Nginx.Models.WebApplicationFirewallActivationState left, Azure.ResourceManager.Nginx.Models.WebApplicationFirewallActivationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WebApplicationFirewallComponentVersions : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.WebApplicationFirewallComponentVersions>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.WebApplicationFirewallComponentVersions>
    {
        internal WebApplicationFirewallComponentVersions() { }
        public string WafEngineVersion { get { throw null; } }
        public string WafNginxVersion { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.Models.WebApplicationFirewallComponentVersions System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.WebApplicationFirewallComponentVersions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.WebApplicationFirewallComponentVersions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.Models.WebApplicationFirewallComponentVersions System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.WebApplicationFirewallComponentVersions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.WebApplicationFirewallComponentVersions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.WebApplicationFirewallComponentVersions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WebApplicationFirewallPackage : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.WebApplicationFirewallPackage>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.WebApplicationFirewallPackage>
    {
        internal WebApplicationFirewallPackage() { }
        public System.DateTimeOffset RevisionDatetime { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.Models.WebApplicationFirewallPackage System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.WebApplicationFirewallPackage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.WebApplicationFirewallPackage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.Models.WebApplicationFirewallPackage System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.WebApplicationFirewallPackage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.WebApplicationFirewallPackage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.WebApplicationFirewallPackage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WebApplicationFirewallSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.WebApplicationFirewallSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.WebApplicationFirewallSettings>
    {
        public WebApplicationFirewallSettings() { }
        public Azure.ResourceManager.Nginx.Models.WebApplicationFirewallActivationState? ActivationState { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.Models.WebApplicationFirewallSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.WebApplicationFirewallSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.WebApplicationFirewallSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.Models.WebApplicationFirewallSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.WebApplicationFirewallSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.WebApplicationFirewallSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.WebApplicationFirewallSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WebApplicationFirewallStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.WebApplicationFirewallStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.WebApplicationFirewallStatus>
    {
        internal WebApplicationFirewallStatus() { }
        public Azure.ResourceManager.Nginx.Models.WebApplicationFirewallPackage AttackSignaturesPackage { get { throw null; } }
        public Azure.ResourceManager.Nginx.Models.WebApplicationFirewallPackage BotSignaturesPackage { get { throw null; } }
        public Azure.ResourceManager.Nginx.Models.WebApplicationFirewallComponentVersions ComponentVersions { get { throw null; } }
        public Azure.ResourceManager.Nginx.Models.WebApplicationFirewallPackage ThreatCampaignsPackage { get { throw null; } }
        public string WafRelease { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.Models.WebApplicationFirewallStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.WebApplicationFirewallStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.WebApplicationFirewallStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.Models.WebApplicationFirewallStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.WebApplicationFirewallStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.WebApplicationFirewallStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.WebApplicationFirewallStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
