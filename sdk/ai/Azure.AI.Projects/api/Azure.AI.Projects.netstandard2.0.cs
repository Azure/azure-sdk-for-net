namespace Azure.AI.Projects
{
    public partial class AIProjectBlobReference : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AIProjectBlobReference>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIProjectBlobReference>
    {
        internal AIProjectBlobReference() { }
        public System.Uri BlobUri { get { throw null; } }
        public Azure.AI.Projects.BlobReferenceSasCredential Credential { get { throw null; } }
        public string StorageAccountArmId { get { throw null; } }
        protected virtual Azure.AI.Projects.AIProjectBlobReference JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.AIProjectBlobReference PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.AIProjectBlobReference System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AIProjectBlobReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AIProjectBlobReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AIProjectBlobReference System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIProjectBlobReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIProjectBlobReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIProjectBlobReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AIProjectClient : System.ClientModel.Primitives.ClientConnectionProvider
    {
        protected AIProjectClient() : base (default(int)) { }
        public AIProjectClient(System.Uri endpoint, Azure.Core.TokenCredential credential = null) : base (default(int)) { }
        public AIProjectClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.AI.Projects.AIProjectClientOptions options) : base (default(int)) { }
        public AIProjectClient(System.Uri endpoint, System.ClientModel.AuthenticationTokenProvider tokenProvider) : base (default(int)) { }
        public AIProjectClient(System.Uri endpoint, System.ClientModel.AuthenticationTokenProvider tokenProvider, Azure.AI.Projects.AIProjectClientOptions options) : base (default(int)) { }
        public virtual Azure.AI.Projects.AIProjectConnectionsOperations Connections { get { throw null; } }
        public virtual Azure.AI.Projects.AIProjectDatasetsOperations Datasets { get { throw null; } }
        public virtual Azure.AI.Projects.AIProjectDeploymentsOperations Deployments { get { throw null; } }
        public virtual Azure.AI.Projects.AIProjectIndexesOperations Indexes { get { throw null; } }
        public System.ClientModel.Primitives.ClientPipeline Pipeline { get { throw null; } }
        public virtual Azure.AI.Projects.AIProjectTelemetry Telemetry { get { throw null; } }
        public virtual Azure.AI.Projects.AIProjectConnectionsOperations GetAIProjectConnectionsOperationsClient() { throw null; }
        public virtual Azure.AI.Projects.AIProjectDatasetsOperations GetAIProjectDatasetsOperationsClient() { throw null; }
        public virtual Azure.AI.Projects.AIProjectDeploymentsOperations GetAIProjectDeploymentsOperationsClient() { throw null; }
        public virtual Azure.AI.Projects.AIProjectIndexesOperations GetAIProjectIndexesOperationsClient() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override System.Collections.Generic.IEnumerable<System.ClientModel.Primitives.ClientConnection> GetAllConnections() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override System.ClientModel.Primitives.ClientConnection GetConnection(string connectionId) { throw null; }
        public virtual OpenAI.OpenAIClient GetOpenAIClient(string? connectionName = null, string? apiVersion = null) { throw null; }
    }
    public partial class AIProjectClientOptions : System.ClientModel.Primitives.ClientPipelineOptions
    {
        public AIProjectClientOptions(Azure.AI.Projects.AIProjectClientOptions.ServiceVersion version = Azure.AI.Projects.AIProjectClientOptions.ServiceVersion.V1) { }
        public int ClientCacheSize { get { throw null; } set { } }
        public enum ServiceVersion
        {
            V2025_05_01 = 1,
            V1 = 2,
        }
    }
    public partial class AIProjectConnection : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AIProjectConnection>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIProjectConnection>
    {
        internal AIProjectConnection() { }
        public Azure.AI.Projects.AIProjectConnectionBaseCredential Credentials { get { throw null; } }
        public string Id { get { throw null; } }
        public bool IsDefault { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Metadata { get { throw null; } }
        public string Name { get { throw null; } }
        public string Target { get { throw null; } }
        public Azure.AI.Projects.ConnectionType Type { get { throw null; } }
        protected virtual Azure.AI.Projects.AIProjectConnection JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Projects.AIProjectConnection (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.Projects.AIProjectConnection PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.AIProjectConnection System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AIProjectConnection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AIProjectConnection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AIProjectConnection System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIProjectConnection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIProjectConnection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIProjectConnection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AIProjectConnectionApiKeyCredential : Azure.AI.Projects.AIProjectConnectionBaseCredential, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AIProjectConnectionApiKeyCredential>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIProjectConnectionApiKeyCredential>
    {
        internal AIProjectConnectionApiKeyCredential() { }
        public string ApiKey { get { throw null; } }
        protected override Azure.AI.Projects.AIProjectConnectionBaseCredential JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.AIProjectConnectionBaseCredential PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.AIProjectConnectionApiKeyCredential System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AIProjectConnectionApiKeyCredential>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AIProjectConnectionApiKeyCredential>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AIProjectConnectionApiKeyCredential System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIProjectConnectionApiKeyCredential>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIProjectConnectionApiKeyCredential>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIProjectConnectionApiKeyCredential>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class AIProjectConnectionBaseCredential : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AIProjectConnectionBaseCredential>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIProjectConnectionBaseCredential>
    {
        internal AIProjectConnectionBaseCredential() { }
        protected virtual Azure.AI.Projects.AIProjectConnectionBaseCredential JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.AIProjectConnectionBaseCredential PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.AIProjectConnectionBaseCredential System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AIProjectConnectionBaseCredential>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AIProjectConnectionBaseCredential>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AIProjectConnectionBaseCredential System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIProjectConnectionBaseCredential>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIProjectConnectionBaseCredential>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIProjectConnectionBaseCredential>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AIProjectConnectionCustomCredential : Azure.AI.Projects.AIProjectConnectionBaseCredential, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AIProjectConnectionCustomCredential>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIProjectConnectionCustomCredential>
    {
        internal AIProjectConnectionCustomCredential() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Keys { get { throw null; } }
        protected override Azure.AI.Projects.AIProjectConnectionBaseCredential JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.AIProjectConnectionBaseCredential PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.AIProjectConnectionCustomCredential System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AIProjectConnectionCustomCredential>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AIProjectConnectionCustomCredential>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AIProjectConnectionCustomCredential System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIProjectConnectionCustomCredential>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIProjectConnectionCustomCredential>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIProjectConnectionCustomCredential>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AIProjectConnectionEntraIDCredential : Azure.AI.Projects.AIProjectConnectionBaseCredential, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AIProjectConnectionEntraIDCredential>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIProjectConnectionEntraIDCredential>
    {
        internal AIProjectConnectionEntraIDCredential() { }
        protected override Azure.AI.Projects.AIProjectConnectionBaseCredential JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.AIProjectConnectionBaseCredential PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.AIProjectConnectionEntraIDCredential System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AIProjectConnectionEntraIDCredential>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AIProjectConnectionEntraIDCredential>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AIProjectConnectionEntraIDCredential System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIProjectConnectionEntraIDCredential>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIProjectConnectionEntraIDCredential>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIProjectConnectionEntraIDCredential>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AIProjectConnectionSasCredential : Azure.AI.Projects.AIProjectConnectionBaseCredential, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AIProjectConnectionSasCredential>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIProjectConnectionSasCredential>
    {
        internal AIProjectConnectionSasCredential() { }
        public string SasToken { get { throw null; } }
        protected override Azure.AI.Projects.AIProjectConnectionBaseCredential JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.AIProjectConnectionBaseCredential PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.AIProjectConnectionSasCredential System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AIProjectConnectionSasCredential>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AIProjectConnectionSasCredential>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AIProjectConnectionSasCredential System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIProjectConnectionSasCredential>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIProjectConnectionSasCredential>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIProjectConnectionSasCredential>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AIProjectConnectionsOperations
    {
        protected AIProjectConnectionsOperations() { }
        public System.ClientModel.Primitives.ClientPipeline Pipeline { get { throw null; } }
        public Azure.AI.Projects.ConnectionProperties GetConnection(string connectionName, bool includeCredentials = false, string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.ConnectionProperties>> GetConnectionAsync(string connectionName, bool includeCredentials = false, string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Projects.AIProjectConnection> GetConnections(Azure.AI.Projects.ConnectionType? connectionType = default(Azure.AI.Projects.ConnectionType?), bool? defaultConnection = default(bool?), string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.CollectionResult GetConnections(string connectionType, bool? defaultConnection, string clientRequestId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Projects.AIProjectConnection> GetConnectionsAsync(Azure.AI.Projects.ConnectionType? connectionType = default(Azure.AI.Projects.ConnectionType?), bool? defaultConnection = default(bool?), string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.AsyncCollectionResult GetConnectionsAsync(string connectionType, bool? defaultConnection, string clientRequestId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public Azure.AI.Projects.ConnectionProperties GetDefaultConnection(Azure.AI.Projects.ConnectionType? connectionType = default(Azure.AI.Projects.ConnectionType?), bool includeCredentials = false) { throw null; }
        public System.Threading.Tasks.Task<Azure.AI.Projects.ConnectionProperties> GetDefaultConnectionAsync(Azure.AI.Projects.ConnectionType? connectionType = default(Azure.AI.Projects.ConnectionType?), bool includeCredentials = false) { throw null; }
    }
    public partial class AIProjectDatasetsOperations
    {
        protected AIProjectDatasetsOperations() { }
        public System.ClientModel.Primitives.ClientPipeline Pipeline { get { throw null; } }
        public virtual System.ClientModel.ClientResult CreateOrUpdate(string name, string version, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> CreateOrUpdateAsync(string name, string version, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult Delete(string name, string version, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult Delete(string name, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> DeleteAsync(string name, string version, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> DeleteAsync(string name, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult GetCredentials(string name, string version, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.DatasetCredential> GetCredentials(string name, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> GetCredentialsAsync(string name, string version, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.DatasetCredential>> GetCredentialsAsync(string name, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult GetDataset(string name, string version, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.DatasetVersion> GetDataset(string name, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> GetDatasetAsync(string name, string version, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.DatasetVersion>> GetDatasetAsync(string name, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.CollectionResult GetDatasets(System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Projects.DatasetVersion> GetDatasets(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.AsyncCollectionResult GetDatasetsAsync(System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Projects.DatasetVersion> GetDatasetsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.CollectionResult GetDatasetVersions(string name, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Projects.DatasetVersion> GetDatasetVersions(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.AsyncCollectionResult GetDatasetVersionsAsync(string name, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Projects.DatasetVersion> GetDatasetVersionsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.PendingUploadResult> PendingUpload(string name, string version, Azure.AI.Projects.PendingUploadConfiguration configuration, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult PendingUpload(string name, string version, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.PendingUploadResult>> PendingUploadAsync(string name, string version, Azure.AI.Projects.PendingUploadConfiguration configuration, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> PendingUploadAsync(string name, string version, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public System.ClientModel.ClientResult<Azure.AI.Projects.FileDatasetVersion> UploadFile(string name, string version, string filePath, string? connectionName = null) { throw null; }
        public System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.FileDatasetVersion>> UploadFileAsync(string name, string version, string filePath, string? connectionName = null) { throw null; }
        public System.ClientModel.ClientResult<Azure.AI.Projects.FolderDatasetVersion> UploadFolder(string name, string version, string folderPath, string? connectionName = null, System.Text.RegularExpressions.Regex? filePattern = null) { throw null; }
        public System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.FolderDatasetVersion>> UploadFolderAsync(string name, string version, string folderPath, string? connectionName = null, System.Text.RegularExpressions.Regex? filePattern = null) { throw null; }
    }
    public abstract partial class AIProjectDeployment : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AIProjectDeployment>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIProjectDeployment>
    {
        internal AIProjectDeployment() { }
        public string Name { get { throw null; } }
        protected virtual Azure.AI.Projects.AIProjectDeployment JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Projects.AIProjectDeployment (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.Projects.AIProjectDeployment PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.AIProjectDeployment System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AIProjectDeployment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AIProjectDeployment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AIProjectDeployment System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIProjectDeployment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIProjectDeployment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIProjectDeployment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AIProjectDeploymentsOperations
    {
        protected AIProjectDeploymentsOperations() { }
        public System.ClientModel.Primitives.ClientPipeline Pipeline { get { throw null; } }
        public virtual System.ClientModel.ClientResult GetDeployment(string name, string clientRequestId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.AIProjectDeployment> GetDeployment(string name, string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> GetDeploymentAsync(string name, string clientRequestId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.AIProjectDeployment>> GetDeploymentAsync(string name, string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Projects.AIProjectDeployment> GetDeployments(string modelPublisher = null, string modelName = null, Azure.AI.Projects.AIProjectDeploymentType? deploymentType = default(Azure.AI.Projects.AIProjectDeploymentType?), string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.CollectionResult GetDeployments(string modelPublisher, string modelName, string deploymentType, string clientRequestId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Projects.AIProjectDeployment> GetDeploymentsAsync(string modelPublisher = null, string modelName = null, Azure.AI.Projects.AIProjectDeploymentType? deploymentType = default(Azure.AI.Projects.AIProjectDeploymentType?), string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.AsyncCollectionResult GetDeploymentsAsync(string modelPublisher, string modelName, string deploymentType, string clientRequestId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AIProjectDeploymentType : System.IEquatable<Azure.AI.Projects.AIProjectDeploymentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AIProjectDeploymentType(string value) { throw null; }
        public static Azure.AI.Projects.AIProjectDeploymentType ModelDeployment { get { throw null; } }
        public bool Equals(Azure.AI.Projects.AIProjectDeploymentType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.AIProjectDeploymentType left, Azure.AI.Projects.AIProjectDeploymentType right) { throw null; }
        public static implicit operator Azure.AI.Projects.AIProjectDeploymentType (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.AIProjectDeploymentType? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.AIProjectDeploymentType left, Azure.AI.Projects.AIProjectDeploymentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class AIProjectIndex : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AIProjectIndex>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIProjectIndex>
    {
        internal AIProjectIndex() { }
        public string Description { get { throw null; } set { } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual Azure.AI.Projects.AIProjectIndex JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Projects.AIProjectIndex (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.Projects.AIProjectIndex PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.AIProjectIndex System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AIProjectIndex>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AIProjectIndex>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AIProjectIndex System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIProjectIndex>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIProjectIndex>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIProjectIndex>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AIProjectIndexesOperations
    {
        protected AIProjectIndexesOperations() { }
        public System.ClientModel.Primitives.ClientPipeline Pipeline { get { throw null; } }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.AIProjectIndex> CreateOrUpdate(string name, string version, Azure.AI.Projects.AIProjectIndex index, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult CreateOrUpdate(string name, string version, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.AIProjectIndex>> CreateOrUpdateAsync(string name, string version, Azure.AI.Projects.AIProjectIndex index, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> CreateOrUpdateAsync(string name, string version, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult Delete(string name, string version, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult Delete(string name, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> DeleteAsync(string name, string version, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> DeleteAsync(string name, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult GetIndex(string name, string version, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.AIProjectIndex> GetIndex(string name, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> GetIndexAsync(string name, string version, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.AIProjectIndex>> GetIndexAsync(string name, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.CollectionResult GetIndexes(System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Projects.AIProjectIndex> GetIndexes(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.AsyncCollectionResult GetIndexesAsync(System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Projects.AIProjectIndex> GetIndexesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.CollectionResult GetIndexVersions(string name, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Projects.AIProjectIndex> GetIndexVersions(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.AsyncCollectionResult GetIndexVersionsAsync(string name, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Projects.AIProjectIndex> GetIndexVersionsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AIProjectIndexFieldMapping : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AIProjectIndexFieldMapping>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIProjectIndexFieldMapping>
    {
        public AIProjectIndexFieldMapping(System.Collections.Generic.IEnumerable<string> contentFields) { }
        public System.Collections.Generic.IList<string> ContentFields { get { throw null; } }
        public string FilepathField { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> MetadataFields { get { throw null; } }
        public string TitleField { get { throw null; } set { } }
        public string UrlField { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> VectorFields { get { throw null; } }
        protected virtual Azure.AI.Projects.AIProjectIndexFieldMapping JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.AIProjectIndexFieldMapping PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.AIProjectIndexFieldMapping System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AIProjectIndexFieldMapping>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AIProjectIndexFieldMapping>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AIProjectIndexFieldMapping System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIProjectIndexFieldMapping>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIProjectIndexFieldMapping>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIProjectIndexFieldMapping>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AIProjectTelemetry
    {
        public AIProjectTelemetry(Azure.AI.Projects.AIProjectClient outerInstance) { }
        public string GetApplicationInsightsConnectionString() { throw null; }
        public System.Threading.Tasks.Task<string> GetApplicationInsightsConnectionStringAsync() { throw null; }
    }
    public partial class AzureAIProjectsContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureAIProjectsContext() { }
        public static Azure.AI.Projects.AzureAIProjectsContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public static partial class AzureAIProjectsModelFactory
    {
        public static Azure.AI.Projects.AIProjectBlobReference AIProjectBlobReference(System.Uri blobUri = null, string storageAccountArmId = null, Azure.AI.Projects.BlobReferenceSasCredential credential = null) { throw null; }
        public static Azure.AI.Projects.AIProjectConnection AIProjectConnection(string name = null, string id = null, Azure.AI.Projects.ConnectionType type = default(Azure.AI.Projects.ConnectionType), string target = null, bool isDefault = false, Azure.AI.Projects.AIProjectConnectionBaseCredential credentials = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null) { throw null; }
        public static Azure.AI.Projects.AIProjectConnectionApiKeyCredential AIProjectConnectionApiKeyCredential(string apiKey = null) { throw null; }
        public static Azure.AI.Projects.AIProjectConnectionBaseCredential AIProjectConnectionBaseCredential(string type = null) { throw null; }
        public static Azure.AI.Projects.AIProjectConnectionCustomCredential AIProjectConnectionCustomCredential(System.Collections.Generic.IReadOnlyDictionary<string, string> keys = null) { throw null; }
        public static Azure.AI.Projects.AIProjectConnectionEntraIDCredential AIProjectConnectionEntraIDCredential() { throw null; }
        public static Azure.AI.Projects.AIProjectConnectionSasCredential AIProjectConnectionSasCredential(string sasToken = null) { throw null; }
        public static Azure.AI.Projects.AIProjectDeployment AIProjectDeployment(string type = null, string name = null) { throw null; }
        public static Azure.AI.Projects.AIProjectIndex AIProjectIndex(string type = null, string id = null, string name = null, string version = null, string description = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.AI.Projects.AIProjectIndexFieldMapping AIProjectIndexFieldMapping(System.Collections.Generic.IEnumerable<string> contentFields = null, string filepathField = null, string titleField = null, string urlField = null, System.Collections.Generic.IEnumerable<string> vectorFields = null, System.Collections.Generic.IEnumerable<string> metadataFields = null) { throw null; }
        public static Azure.AI.Projects.AzureAISearchIndex AzureAISearchIndex(string id = null, string name = null, string version = null, string description = null, System.Collections.Generic.IDictionary<string, string> tags = null, string connectionName = null, string indexName = null, Azure.AI.Projects.AIProjectIndexFieldMapping fieldMapping = null) { throw null; }
        public static Azure.AI.Projects.BlobReferenceSasCredential BlobReferenceSasCredential(System.Uri sasUri = null, string type = null) { throw null; }
        public static Azure.AI.Projects.CosmosDBIndex CosmosDBIndex(string id = null, string name = null, string version = null, string description = null, System.Collections.Generic.IDictionary<string, string> tags = null, string connectionName = null, string databaseName = null, string containerName = null, Azure.AI.Projects.EmbeddingConfiguration embeddingConfiguration = null, Azure.AI.Projects.AIProjectIndexFieldMapping fieldMapping = null) { throw null; }
        public static Azure.AI.Projects.DatasetCredential DatasetCredential(Azure.AI.Projects.AIProjectBlobReference blobReference = null) { throw null; }
        public static Azure.AI.Projects.DatasetVersion DatasetVersion(System.Uri dataUri = null, string type = null, bool? isReference = default(bool?), string connectionName = null, string id = null, string name = null, string version = null, string description = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.AI.Projects.EmbeddingConfiguration EmbeddingConfiguration(string modelDeploymentName = null, string embeddingField = null) { throw null; }
        public static Azure.AI.Projects.FileDatasetVersion FileDatasetVersion(System.Uri dataUri = null, bool? isReference = default(bool?), string connectionName = null, string id = null, string name = null, string version = null, string description = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.AI.Projects.FolderDatasetVersion FolderDatasetVersion(System.Uri dataUri = null, bool? isReference = default(bool?), string connectionName = null, string id = null, string name = null, string version = null, string description = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.AI.Projects.ManagedAzureAISearchIndex ManagedAzureAISearchIndex(string id = null, string name = null, string version = null, string description = null, System.Collections.Generic.IDictionary<string, string> tags = null, string vectorStoreId = null) { throw null; }
        public static Azure.AI.Projects.ModelDeployment ModelDeployment(string name = null, string modelName = null, string modelVersion = null, string modelPublisher = null, System.Collections.Generic.IReadOnlyDictionary<string, string> capabilities = null, Azure.AI.Projects.ModelDeploymentSku sku = null, string connectionName = null) { throw null; }
        public static Azure.AI.Projects.ModelDeploymentSku ModelDeploymentSku(long capacity = (long)0, string family = null, string name = null, string size = null, string tier = null) { throw null; }
        public static Azure.AI.Projects.NoAuthenticationCredentials NoAuthenticationCredentials() { throw null; }
        public static Azure.AI.Projects.PendingUploadConfiguration PendingUploadConfiguration(string pendingUploadId = null, string connectionName = null, Azure.AI.Projects.PendingUploadType pendingUploadType = default(Azure.AI.Projects.PendingUploadType)) { throw null; }
        public static Azure.AI.Projects.PendingUploadResult PendingUploadResult(Azure.AI.Projects.AIProjectBlobReference blobReference = null, string pendingUploadId = null, string version = null, Azure.AI.Projects.PendingUploadType pendingUploadType = default(Azure.AI.Projects.PendingUploadType)) { throw null; }
    }
    public partial class AzureAISearchIndex : Azure.AI.Projects.AIProjectIndex, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AzureAISearchIndex>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AzureAISearchIndex>
    {
        public AzureAISearchIndex(string connectionName, string indexName) { }
        public string ConnectionName { get { throw null; } set { } }
        public Azure.AI.Projects.AIProjectIndexFieldMapping FieldMapping { get { throw null; } set { } }
        public string IndexName { get { throw null; } set { } }
        protected override Azure.AI.Projects.AIProjectIndex JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.AIProjectIndex PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.AzureAISearchIndex System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AzureAISearchIndex>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AzureAISearchIndex>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AzureAISearchIndex System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AzureAISearchIndex>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AzureAISearchIndex>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AzureAISearchIndex>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BlobReferenceSasCredential : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.BlobReferenceSasCredential>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.BlobReferenceSasCredential>
    {
        internal BlobReferenceSasCredential() { }
        public System.Uri SasUri { get { throw null; } }
        public string Type { get { throw null; } }
        protected virtual Azure.AI.Projects.BlobReferenceSasCredential JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.BlobReferenceSasCredential PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.BlobReferenceSasCredential System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.BlobReferenceSasCredential>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.BlobReferenceSasCredential>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.BlobReferenceSasCredential System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.BlobReferenceSasCredential>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.BlobReferenceSasCredential>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.BlobReferenceSasCredential>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConnectionType : System.IEquatable<Azure.AI.Projects.ConnectionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConnectionType(string value) { throw null; }
        public static Azure.AI.Projects.ConnectionType APIKey { get { throw null; } }
        public static Azure.AI.Projects.ConnectionType ApplicationConfiguration { get { throw null; } }
        public static Azure.AI.Projects.ConnectionType ApplicationInsights { get { throw null; } }
        public static Azure.AI.Projects.ConnectionType AzureAISearch { get { throw null; } }
        public static Azure.AI.Projects.ConnectionType AzureBlobStorage { get { throw null; } }
        public static Azure.AI.Projects.ConnectionType AzureOpenAI { get { throw null; } }
        public static Azure.AI.Projects.ConnectionType AzureStorageAccount { get { throw null; } }
        public static Azure.AI.Projects.ConnectionType CosmosDB { get { throw null; } }
        public static Azure.AI.Projects.ConnectionType Custom { get { throw null; } }
        public bool Equals(Azure.AI.Projects.ConnectionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.ConnectionType left, Azure.AI.Projects.ConnectionType right) { throw null; }
        public static implicit operator Azure.AI.Projects.ConnectionType (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.ConnectionType? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.ConnectionType left, Azure.AI.Projects.ConnectionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CosmosDBIndex : Azure.AI.Projects.AIProjectIndex, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.CosmosDBIndex>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.CosmosDBIndex>
    {
        public CosmosDBIndex(string connectionName, string databaseName, string containerName, Azure.AI.Projects.EmbeddingConfiguration embeddingConfiguration, Azure.AI.Projects.AIProjectIndexFieldMapping fieldMapping) { }
        public string ConnectionName { get { throw null; } set { } }
        public string ContainerName { get { throw null; } set { } }
        public string DatabaseName { get { throw null; } set { } }
        public Azure.AI.Projects.EmbeddingConfiguration EmbeddingConfiguration { get { throw null; } set { } }
        public Azure.AI.Projects.AIProjectIndexFieldMapping FieldMapping { get { throw null; } set { } }
        protected override Azure.AI.Projects.AIProjectIndex JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.AIProjectIndex PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.CosmosDBIndex System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.CosmosDBIndex>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.CosmosDBIndex>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.CosmosDBIndex System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.CosmosDBIndex>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.CosmosDBIndex>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.CosmosDBIndex>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DatasetCredential : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.DatasetCredential>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.DatasetCredential>
    {
        internal DatasetCredential() { }
        public Azure.AI.Projects.AIProjectBlobReference BlobReference { get { throw null; } }
        protected virtual Azure.AI.Projects.DatasetCredential JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Projects.DatasetCredential (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.Projects.DatasetCredential PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.DatasetCredential System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.DatasetCredential>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.DatasetCredential>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.DatasetCredential System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.DatasetCredential>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.DatasetCredential>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.DatasetCredential>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class DatasetVersion : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.DatasetVersion>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.DatasetVersion>
    {
        internal DatasetVersion() { }
        public string ConnectionName { get { throw null; } set { } }
        public System.Uri DataUri { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string Id { get { throw null; } }
        public bool? IsReference { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual Azure.AI.Projects.DatasetVersion JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Projects.DatasetVersion (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.Projects.DatasetVersion PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.DatasetVersion System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.DatasetVersion>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.DatasetVersion>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.DatasetVersion System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.DatasetVersion>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.DatasetVersion>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.DatasetVersion>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EmbeddingConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.EmbeddingConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EmbeddingConfiguration>
    {
        public EmbeddingConfiguration(string modelDeploymentName, string embeddingField) { }
        public string EmbeddingField { get { throw null; } set { } }
        public string ModelDeploymentName { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.EmbeddingConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.EmbeddingConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.EmbeddingConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.EmbeddingConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.EmbeddingConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.EmbeddingConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EmbeddingConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EmbeddingConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EmbeddingConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FileDatasetVersion : Azure.AI.Projects.DatasetVersion, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.FileDatasetVersion>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.FileDatasetVersion>
    {
        public FileDatasetVersion(System.Uri dataUri) { }
        protected override Azure.AI.Projects.DatasetVersion JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.DatasetVersion PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.FileDatasetVersion System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.FileDatasetVersion>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.FileDatasetVersion>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.FileDatasetVersion System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.FileDatasetVersion>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.FileDatasetVersion>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.FileDatasetVersion>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FolderDatasetVersion : Azure.AI.Projects.DatasetVersion, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.FolderDatasetVersion>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.FolderDatasetVersion>
    {
        public FolderDatasetVersion(System.Uri dataUri) { }
        protected override Azure.AI.Projects.DatasetVersion JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.DatasetVersion PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.FolderDatasetVersion System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.FolderDatasetVersion>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.FolderDatasetVersion>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.FolderDatasetVersion System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.FolderDatasetVersion>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.FolderDatasetVersion>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.FolderDatasetVersion>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ManagedAzureAISearchIndex : Azure.AI.Projects.AIProjectIndex, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ManagedAzureAISearchIndex>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ManagedAzureAISearchIndex>
    {
        public ManagedAzureAISearchIndex(string vectorStoreId) { }
        public string VectorStoreId { get { throw null; } set { } }
        protected override Azure.AI.Projects.AIProjectIndex JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.AIProjectIndex PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.ManagedAzureAISearchIndex System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ManagedAzureAISearchIndex>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ManagedAzureAISearchIndex>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.ManagedAzureAISearchIndex System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ManagedAzureAISearchIndex>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ManagedAzureAISearchIndex>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ManagedAzureAISearchIndex>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ModelDeployment : Azure.AI.Projects.AIProjectDeployment, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ModelDeployment>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ModelDeployment>
    {
        internal ModelDeployment() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Capabilities { get { throw null; } }
        public string ConnectionName { get { throw null; } }
        public string ModelName { get { throw null; } }
        public string ModelPublisher { get { throw null; } }
        public string ModelVersion { get { throw null; } }
        public Azure.AI.Projects.ModelDeploymentSku Sku { get { throw null; } }
        protected override Azure.AI.Projects.AIProjectDeployment JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.AIProjectDeployment PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.ModelDeployment System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ModelDeployment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ModelDeployment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.ModelDeployment System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ModelDeployment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ModelDeployment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ModelDeployment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ModelDeploymentSku : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ModelDeploymentSku>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ModelDeploymentSku>
    {
        internal ModelDeploymentSku() { }
        public long Capacity { get { throw null; } }
        public string Family { get { throw null; } }
        public string Name { get { throw null; } }
        public string Size { get { throw null; } }
        public string Tier { get { throw null; } }
        protected virtual Azure.AI.Projects.ModelDeploymentSku JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.ModelDeploymentSku PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.ModelDeploymentSku System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ModelDeploymentSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ModelDeploymentSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.ModelDeploymentSku System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ModelDeploymentSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ModelDeploymentSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ModelDeploymentSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NoAuthenticationCredentials : Azure.AI.Projects.AIProjectConnectionBaseCredential, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.NoAuthenticationCredentials>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.NoAuthenticationCredentials>
    {
        internal NoAuthenticationCredentials() { }
        protected override Azure.AI.Projects.AIProjectConnectionBaseCredential JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.AIProjectConnectionBaseCredential PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.NoAuthenticationCredentials System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.NoAuthenticationCredentials>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.NoAuthenticationCredentials>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.NoAuthenticationCredentials System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.NoAuthenticationCredentials>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.NoAuthenticationCredentials>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.NoAuthenticationCredentials>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PendingUploadConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.PendingUploadConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.PendingUploadConfiguration>
    {
        public PendingUploadConfiguration() { }
        public string ConnectionName { get { throw null; } set { } }
        public string PendingUploadId { get { throw null; } set { } }
        public Azure.AI.Projects.PendingUploadType PendingUploadType { get { throw null; } }
        protected virtual Azure.AI.Projects.PendingUploadConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator System.ClientModel.BinaryContent (Azure.AI.Projects.PendingUploadConfiguration pendingUploadConfiguration) { throw null; }
        protected virtual Azure.AI.Projects.PendingUploadConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.PendingUploadConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.PendingUploadConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.PendingUploadConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.PendingUploadConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.PendingUploadConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.PendingUploadConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.PendingUploadConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PendingUploadResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.PendingUploadResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.PendingUploadResult>
    {
        internal PendingUploadResult() { }
        public Azure.AI.Projects.AIProjectBlobReference BlobReference { get { throw null; } }
        public string PendingUploadId { get { throw null; } }
        public Azure.AI.Projects.PendingUploadType PendingUploadType { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual Azure.AI.Projects.PendingUploadResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Projects.PendingUploadResult (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.Projects.PendingUploadResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.PendingUploadResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.PendingUploadResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.PendingUploadResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.PendingUploadResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.PendingUploadResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.PendingUploadResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.PendingUploadResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PendingUploadType : System.IEquatable<Azure.AI.Projects.PendingUploadType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PendingUploadType(string value) { throw null; }
        public static Azure.AI.Projects.PendingUploadType BlobReference { get { throw null; } }
        public static Azure.AI.Projects.PendingUploadType None { get { throw null; } }
        public bool Equals(Azure.AI.Projects.PendingUploadType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.PendingUploadType left, Azure.AI.Projects.PendingUploadType right) { throw null; }
        public static implicit operator Azure.AI.Projects.PendingUploadType (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.PendingUploadType? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.PendingUploadType left, Azure.AI.Projects.PendingUploadType right) { throw null; }
        public override string ToString() { throw null; }
    }
}
