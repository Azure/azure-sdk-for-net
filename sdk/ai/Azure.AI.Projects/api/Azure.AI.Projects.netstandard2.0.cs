namespace Azure.AI.Projects
{
    public abstract partial class AIDeployment : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AIDeployment>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIDeployment>
    {
        internal AIDeployment() { }
        public string Name { get { throw null; } }
        protected virtual Azure.AI.Projects.AIDeployment JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Projects.AIDeployment (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.Projects.AIDeployment PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.AIDeployment System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AIDeployment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AIDeployment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AIDeployment System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIDeployment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIDeployment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIDeployment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AIProjectClient : System.ClientModel.Primitives.ClientConnectionProvider
    {
        protected AIProjectClient() : base (default(int)) { }
        public AIProjectClient(System.Uri endpoint, Azure.Core.TokenCredential credential = null) : base (default(int)) { }
        public AIProjectClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.AI.Projects.AIProjectClientOptions options) : base (default(int)) { }
        public Azure.AI.Projects.Connections Connections { get { throw null; } }
        public Azure.AI.Projects.Datasets Datasets { get { throw null; } }
        public Azure.AI.Projects.Deployments Deployments { get { throw null; } }
        public Azure.AI.Projects.Indexes Indexes { get { throw null; } }
        public System.ClientModel.Primitives.ClientPipeline Pipeline { get { throw null; } }
        public Azure.AI.Projects.Telemetry Telemetry { get { throw null; } }
        public override System.Collections.Generic.IEnumerable<System.ClientModel.Primitives.ClientConnection> GetAllConnections() { throw null; }
        public OpenAI.Chat.ChatClient GetAzureOpenAIChatClient(string? connectionName = null, string? apiVersion = null, string? deploymentName = null) { throw null; }
        public OpenAI.Embeddings.EmbeddingClient GetAzureOpenAIEmbeddingClient(string? connectionName = null, string? apiVersion = null, string? deploymentName = null) { throw null; }
        public override System.ClientModel.Primitives.ClientConnection GetConnection(string connectionId) { throw null; }
        public virtual Azure.AI.Projects.Connections GetConnectionsClient() { throw null; }
        public virtual Azure.AI.Projects.Datasets GetDatasetsClient() { throw null; }
        public virtual Azure.AI.Projects.Deployments GetDeploymentsClient() { throw null; }
        public virtual Azure.AI.Projects.Indexes GetIndexesClient() { throw null; }
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
    public partial class ApiKeyCredentials : Azure.AI.Projects.BaseCredentials, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ApiKeyCredentials>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ApiKeyCredentials>
    {
        internal ApiKeyCredentials() { }
        public string ApiKey { get { throw null; } }
        protected override Azure.AI.Projects.BaseCredentials JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.BaseCredentials PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.ApiKeyCredentials System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ApiKeyCredentials>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ApiKeyCredentials>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.ApiKeyCredentials System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ApiKeyCredentials>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ApiKeyCredentials>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ApiKeyCredentials>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AssetCredentialResponse : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AssetCredentialResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AssetCredentialResponse>
    {
        internal AssetCredentialResponse() { }
        public Azure.AI.Projects.BlobReference BlobReference { get { throw null; } }
        protected virtual Azure.AI.Projects.AssetCredentialResponse JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Projects.AssetCredentialResponse (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.Projects.AssetCredentialResponse PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.AssetCredentialResponse System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AssetCredentialResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AssetCredentialResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AssetCredentialResponse System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AssetCredentialResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AssetCredentialResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AssetCredentialResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum AuthenticationType
    {
        ApiKey = 0,
        EntraId = 1,
        SAS = 2,
        Custom = 3,
        None = 4,
    }
    public partial class AzureAIProjectsContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureAIProjectsContext() { }
        public static Azure.AI.Projects.AzureAIProjectsContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public static partial class AzureAIProjectsModelFactory
    {
        public static Azure.AI.Projects.AIDeployment AIDeployment(string type = null, string name = null) { throw null; }
        public static Azure.AI.Projects.ApiKeyCredentials ApiKeyCredentials(string apiKey = null) { throw null; }
        public static Azure.AI.Projects.AssetCredentialResponse AssetCredentialResponse(Azure.AI.Projects.BlobReference blobReference = null) { throw null; }
        public static Azure.AI.Projects.AzureAISearchIndex AzureAISearchIndex(string id = null, string name = null, string version = null, string description = null, System.Collections.Generic.IDictionary<string, string> tags = null, string connectionName = null, string indexName = null, Azure.AI.Projects.FieldMapping fieldMapping = null) { throw null; }
        public static Azure.AI.Projects.BaseCredentials BaseCredentials(string type = null) { throw null; }
        public static Azure.AI.Projects.BlobReference BlobReference(string storageAccountArmId = null, Azure.AI.Projects.BlobReferenceSasCredential credential = null, System.Uri blobUri = null) { throw null; }
        public static Azure.AI.Projects.BlobReferenceSasCredential BlobReferenceSasCredential(string type = null, System.Uri sasUri = null) { throw null; }
        public static Azure.AI.Projects.ConnectionProperties ConnectionProperties(string name = null, string id = null, Azure.AI.Projects.ConnectionType type = default(Azure.AI.Projects.ConnectionType), string target = null, bool isDefault = false, Azure.AI.Projects.BaseCredentials credentials = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null) { throw null; }
        public static Azure.AI.Projects.CosmosDBIndex CosmosDBIndex(string id = null, string name = null, string version = null, string description = null, System.Collections.Generic.IDictionary<string, string> tags = null, string connectionName = null, string databaseName = null, string containerName = null, Azure.AI.Projects.EmbeddingConfiguration embeddingConfiguration = null, Azure.AI.Projects.FieldMapping fieldMapping = null) { throw null; }
        public static Azure.AI.Projects.CustomCredential CustomCredential(System.Collections.Generic.IReadOnlyDictionary<string, string> keys = null) { throw null; }
        public static Azure.AI.Projects.DatasetIndex DatasetIndex(string type = null, string id = null, string name = null, string version = null, string description = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.AI.Projects.DatasetVersion DatasetVersion(string type = null, bool? isReference = default(bool?), string connectionName = null, string id = null, string name = null, string version = null, string description = null, System.Collections.Generic.IDictionary<string, string> tags = null, System.Uri dataUri = null) { throw null; }
        public static Azure.AI.Projects.EmbeddingConfiguration EmbeddingConfiguration(string modelDeploymentName = null, string embeddingField = null) { throw null; }
        public static Azure.AI.Projects.EntraIDCredentials EntraIDCredentials() { throw null; }
        public static Azure.AI.Projects.FieldMapping FieldMapping(System.Collections.Generic.IEnumerable<string> contentFields = null, string filepathField = null, string titleField = null, string urlField = null, System.Collections.Generic.IEnumerable<string> vectorFields = null, System.Collections.Generic.IEnumerable<string> metadataFields = null) { throw null; }
        public static Azure.AI.Projects.FileDatasetVersion FileDatasetVersion(bool? isReference = default(bool?), string connectionName = null, string id = null, string name = null, string version = null, string description = null, System.Collections.Generic.IDictionary<string, string> tags = null, System.Uri dataUri = null) { throw null; }
        public static Azure.AI.Projects.FolderDatasetVersion FolderDatasetVersion(bool? isReference = default(bool?), string connectionName = null, string id = null, string name = null, string version = null, string description = null, System.Collections.Generic.IDictionary<string, string> tags = null, System.Uri dataUri = null) { throw null; }
        public static Azure.AI.Projects.ManagedAzureAISearchIndex ManagedAzureAISearchIndex(string id = null, string name = null, string version = null, string description = null, System.Collections.Generic.IDictionary<string, string> tags = null, string vectorStoreId = null) { throw null; }
        public static Azure.AI.Projects.ModelDeployment ModelDeployment(string name = null, string modelName = null, string modelVersion = null, string modelPublisher = null, System.Collections.Generic.IReadOnlyDictionary<string, string> capabilities = null, Azure.AI.Projects.ModelDeploymentSku sku = null, string connectionName = null) { throw null; }
        public static Azure.AI.Projects.ModelDeploymentSku ModelDeploymentSku(long capacity = (long)0, string family = null, string name = null, string size = null, string tier = null) { throw null; }
        public static Azure.AI.Projects.NoAuthenticationCredentials NoAuthenticationCredentials() { throw null; }
        public static Azure.AI.Projects.PendingUploadRequest PendingUploadRequest(string pendingUploadId = null, string connectionName = null, Azure.AI.Projects.PendingUploadType pendingUploadType = default(Azure.AI.Projects.PendingUploadType)) { throw null; }
        public static Azure.AI.Projects.PendingUploadResponse PendingUploadResponse(Azure.AI.Projects.BlobReference blobReference = null, string pendingUploadId = null, string version = null, Azure.AI.Projects.PendingUploadType pendingUploadType = default(Azure.AI.Projects.PendingUploadType)) { throw null; }
        public static Azure.AI.Projects.SASCredentials SASCredentials(string sasToken = null) { throw null; }
    }
    public partial class AzureAISearchIndex : Azure.AI.Projects.DatasetIndex, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AzureAISearchIndex>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AzureAISearchIndex>
    {
        public AzureAISearchIndex(string connectionName, string indexName) { }
        public string ConnectionName { get { throw null; } set { } }
        public Azure.AI.Projects.FieldMapping FieldMapping { get { throw null; } set { } }
        public string IndexName { get { throw null; } set { } }
        protected override Azure.AI.Projects.DatasetIndex JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.DatasetIndex PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.AzureAISearchIndex System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AzureAISearchIndex>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AzureAISearchIndex>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AzureAISearchIndex System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AzureAISearchIndex>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AzureAISearchIndex>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AzureAISearchIndex>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class BaseCredentials : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.BaseCredentials>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.BaseCredentials>
    {
        internal BaseCredentials() { }
        protected virtual Azure.AI.Projects.BaseCredentials JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.BaseCredentials PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.BaseCredentials System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.BaseCredentials>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.BaseCredentials>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.BaseCredentials System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.BaseCredentials>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.BaseCredentials>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.BaseCredentials>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BlobReference : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.BlobReference>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.BlobReference>
    {
        internal BlobReference() { }
        public System.Uri BlobUri { get { throw null; } }
        public Azure.AI.Projects.BlobReferenceSasCredential Credential { get { throw null; } }
        public string StorageAccountArmId { get { throw null; } }
        protected virtual Azure.AI.Projects.BlobReference JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.BlobReference PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.BlobReference System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.BlobReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.BlobReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.BlobReference System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.BlobReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.BlobReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.BlobReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class ConnectionProperties : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ConnectionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ConnectionProperties>
    {
        internal ConnectionProperties() { }
        public Azure.AI.Projects.BaseCredentials Credentials { get { throw null; } }
        public string Id { get { throw null; } }
        public bool IsDefault { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Metadata { get { throw null; } }
        public string Name { get { throw null; } }
        public string Target { get { throw null; } }
        public Azure.AI.Projects.ConnectionType Type { get { throw null; } }
        protected virtual Azure.AI.Projects.ConnectionProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Projects.ConnectionProperties (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.Projects.ConnectionProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.ConnectionProperties System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ConnectionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ConnectionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.ConnectionProperties System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ConnectionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ConnectionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ConnectionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class Connections
    {
        protected Connections() { }
        public System.ClientModel.Primitives.ClientPipeline Pipeline { get { throw null; } }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Projects.ConnectionProperties> Get(Azure.AI.Projects.ConnectionType? connectionType = default(Azure.AI.Projects.ConnectionType?), bool? defaultConnection = default(bool?), string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.CollectionResult Get(string connectionType, bool? defaultConnection, string clientRequestId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Projects.ConnectionProperties> GetAsync(Azure.AI.Projects.ConnectionType? connectionType = default(Azure.AI.Projects.ConnectionType?), bool? defaultConnection = default(bool?), string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.AsyncCollectionResult GetAsync(string connectionType, bool? defaultConnection, string clientRequestId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public Azure.AI.Projects.ConnectionProperties GetConnection(string connectionName, bool includeCredentials = false) { throw null; }
        public System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.ConnectionProperties>> GetConnectionAsync(string connectionName, bool includeCredentials = false) { throw null; }
        public System.ClientModel.CollectionResult<Azure.AI.Projects.ConnectionProperties> GetConnections(Azure.AI.Projects.ConnectionType? connectionType = default(Azure.AI.Projects.ConnectionType?)) { throw null; }
        public System.ClientModel.AsyncCollectionResult<Azure.AI.Projects.ConnectionProperties> GetConnectionsAsync(Azure.AI.Projects.ConnectionType? connectionType = default(Azure.AI.Projects.ConnectionType?)) { throw null; }
        public Azure.AI.Projects.ConnectionProperties GetDefault(Azure.AI.Projects.ConnectionType? connectionType = default(Azure.AI.Projects.ConnectionType?), bool includeCredentials = false) { throw null; }
        public System.Threading.Tasks.Task<Azure.AI.Projects.ConnectionProperties> GetDefaultAsync(Azure.AI.Projects.ConnectionType? connectionType = default(Azure.AI.Projects.ConnectionType?), bool includeCredentials = false) { throw null; }
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
        public static bool operator !=(Azure.AI.Projects.ConnectionType left, Azure.AI.Projects.ConnectionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CosmosDBIndex : Azure.AI.Projects.DatasetIndex, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.CosmosDBIndex>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.CosmosDBIndex>
    {
        public CosmosDBIndex(string connectionName, string databaseName, string containerName, Azure.AI.Projects.EmbeddingConfiguration embeddingConfiguration, Azure.AI.Projects.FieldMapping fieldMapping) { }
        public string ConnectionName { get { throw null; } set { } }
        public string ContainerName { get { throw null; } set { } }
        public string DatabaseName { get { throw null; } set { } }
        public Azure.AI.Projects.EmbeddingConfiguration EmbeddingConfiguration { get { throw null; } set { } }
        public Azure.AI.Projects.FieldMapping FieldMapping { get { throw null; } set { } }
        protected override Azure.AI.Projects.DatasetIndex JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.DatasetIndex PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.CosmosDBIndex System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.CosmosDBIndex>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.CosmosDBIndex>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.CosmosDBIndex System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.CosmosDBIndex>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.CosmosDBIndex>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.CosmosDBIndex>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomCredential : Azure.AI.Projects.BaseCredentials, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.CustomCredential>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.CustomCredential>
    {
        internal CustomCredential() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Keys { get { throw null; } }
        protected override Azure.AI.Projects.BaseCredentials JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.BaseCredentials PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.CustomCredential System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.CustomCredential>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.CustomCredential>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.CustomCredential System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.CustomCredential>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.CustomCredential>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.CustomCredential>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class DatasetIndex : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.DatasetIndex>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.DatasetIndex>
    {
        internal DatasetIndex() { }
        public string Description { get { throw null; } set { } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual Azure.AI.Projects.DatasetIndex JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Projects.DatasetIndex (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.Projects.DatasetIndex PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.DatasetIndex System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.DatasetIndex>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.DatasetIndex>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.DatasetIndex System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.DatasetIndex>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.DatasetIndex>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.DatasetIndex>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class Datasets
    {
        protected Datasets() { }
        public System.ClientModel.Primitives.ClientPipeline Pipeline { get { throw null; } }
        public virtual System.ClientModel.ClientResult CreateOrUpdate(string name, string version, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> CreateOrUpdateAsync(string name, string version, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult Delete(string name, string version, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult Delete(string name, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> DeleteAsync(string name, string version, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> DeleteAsync(string name, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.CollectionResult Get(System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult Get(string name, string version, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.DatasetVersion> Get(string name, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Projects.DatasetVersion> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.AsyncCollectionResult GetAsync(System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> GetAsync(string name, string version, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.DatasetVersion>> GetAsync(string name, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Projects.DatasetVersion> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult GetCredentials(string name, string version, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.AssetCredentialResponse> GetCredentials(string name, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> GetCredentialsAsync(string name, string version, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.AssetCredentialResponse>> GetCredentialsAsync(string name, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.CollectionResult GetVersions(string name, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Projects.DatasetVersion> GetVersions(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.AsyncCollectionResult GetVersionsAsync(string name, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Projects.DatasetVersion> GetVersionsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.PendingUploadResponse> PendingUpload(string name, string version, Azure.AI.Projects.PendingUploadRequest pendingUploadRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult PendingUpload(string name, string version, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.PendingUploadResponse>> PendingUploadAsync(string name, string version, Azure.AI.Projects.PendingUploadRequest pendingUploadRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> PendingUploadAsync(string name, string version, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public System.ClientModel.ClientResult<Azure.AI.Projects.FileDatasetVersion> UploadFile(string name, string version, string filePath, string? connectionName = null) { throw null; }
        public System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.FileDatasetVersion>> UploadFileAsync(string name, string version, string filePath, string? connectionName = null) { throw null; }
        public System.ClientModel.ClientResult<Azure.AI.Projects.FolderDatasetVersion> UploadFolder(string name, string version, string folderPath, string? connectionName = null, System.Text.RegularExpressions.Regex? filePattern = null) { throw null; }
        public System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.FolderDatasetVersion>> UploadFolderAsync(string name, string version, string folderPath, string? connectionName = null, System.Text.RegularExpressions.Regex? filePattern = null) { throw null; }
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
    public partial class Deployments
    {
        protected Deployments() { }
        public System.ClientModel.Primitives.ClientPipeline Pipeline { get { throw null; } }
        public virtual System.ClientModel.ClientResult Get(string name, string clientRequestId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Projects.AIDeployment> Get(string modelPublisher = null, string modelName = null, Azure.AI.Projects.DeploymentType? deploymentType = default(Azure.AI.Projects.DeploymentType?), string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.CollectionResult Get(string modelPublisher, string modelName, string deploymentType, string clientRequestId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.AIDeployment> Get(string name, string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> GetAsync(string name, string clientRequestId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Projects.AIDeployment> GetAsync(string modelPublisher = null, string modelName = null, Azure.AI.Projects.DeploymentType? deploymentType = default(Azure.AI.Projects.DeploymentType?), string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.AsyncCollectionResult GetAsync(string modelPublisher, string modelName, string deploymentType, string clientRequestId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.AIDeployment>> GetAsync(string name, string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.Projects.ModelDeployment GetModelDeployment(string name, string clientRequestId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual Azure.AI.Projects.ModelDeployment GetModelDeployment(string name, string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.Projects.ModelDeployment> GetModelDeploymentAsync(string name, string clientRequestId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.Projects.ModelDeployment> GetModelDeploymentAsync(string name, string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeploymentType : System.IEquatable<Azure.AI.Projects.DeploymentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeploymentType(string value) { throw null; }
        public static Azure.AI.Projects.DeploymentType ModelDeployment { get { throw null; } }
        public bool Equals(Azure.AI.Projects.DeploymentType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.DeploymentType left, Azure.AI.Projects.DeploymentType right) { throw null; }
        public static implicit operator Azure.AI.Projects.DeploymentType (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.DeploymentType left, Azure.AI.Projects.DeploymentType right) { throw null; }
        public override string ToString() { throw null; }
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
    public partial class EntraIDCredentials : Azure.AI.Projects.BaseCredentials, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.EntraIDCredentials>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EntraIDCredentials>
    {
        internal EntraIDCredentials() { }
        protected override Azure.AI.Projects.BaseCredentials JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.BaseCredentials PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.EntraIDCredentials System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.EntraIDCredentials>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.EntraIDCredentials>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.EntraIDCredentials System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EntraIDCredentials>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EntraIDCredentials>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EntraIDCredentials>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class EvaluatorIDs
    {
        public const string BleuScore = "azureai://built-in/evaluators/bleu_score";
        public const string CodeVulnerability = "azureai://built-in/evaluators/code_vulnerability";
        public const string Coherence = "azureai://built-in/evaluators/coherence";
        public const string ContentSafety = "azureai://built-in/evaluators/content_safety";
        public const string DocumentRetrieval = "azureai://built-in/evaluators/document_retrieval";
        public const string F1Score = "azureai://built-in/evaluators/f1_score";
        public const string Fluency = "azureai://built-in/evaluators/fluency";
        public const string GleuScore = "azureai://built-in/evaluators/gleu_score";
        public const string Groundedness = "azureai://built-in/evaluators/groundedness";
        public const string GroundednessPro = "azureai://built-in/evaluators/groundedness_pro";
        public const string HateUnfairness = "azureai://built-in/evaluators/hate_unfairness";
        public const string IndirectAttack = "azureai://built-in/evaluators/indirect_attack";
        public const string IntentResolution = "azureai://built-in/evaluators/intent_resolution";
        public const string LabelGrader = "azureai://built-in/evaluators/label_grader";
        public const string MeteorScore = "azureai://built-in/evaluators/meteor_score";
        public const string ProtectedMaterial = "azureai://built-in/evaluators/protected_material";
        public const string QA = "azureai://built-in/evaluators/qa";
        public const string Relevance = "azureai://built-in/evaluators/relevance";
        public const string ResponseCompleteness = "azureai://built-in/evaluators/response_completeness";
        public const string Retrieval = "azureai://built-in/evaluators/retrieval";
        public const string RougeScore = "azureai://built-in/evaluators/rouge_score";
        public const string SelfHarm = "azureai://built-in/evaluators/self_harm";
        public const string Sexual = "azureai://built-in/evaluators/sexual";
        public const string SimilarityScore = "azureai://built-in/evaluators/similarity_score";
        public const string StringCheckGrader = "azureai://built-in/evaluators/string_check_grader";
        public const string TaskAdherence = "azureai://built-in/evaluators/task_adherence";
        public const string TextSimilarityGrader = "azureai://built-in/evaluators/text_similarity_grader";
        public const string ToolCallAccuracy = "azureai://built-in/evaluators/tool_call_accuracy";
        public const string UngroundedAttributes = "azureai://built-in/evaluators/ungrounded_attributes";
        public const string Violence = "azureai://built-in/evaluators/violence";
    }
    public partial class FieldMapping : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.FieldMapping>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.FieldMapping>
    {
        public FieldMapping(System.Collections.Generic.IEnumerable<string> contentFields) { }
        public System.Collections.Generic.IList<string> ContentFields { get { throw null; } }
        public string FilepathField { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> MetadataFields { get { throw null; } }
        public string TitleField { get { throw null; } set { } }
        public string UrlField { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> VectorFields { get { throw null; } }
        protected virtual Azure.AI.Projects.FieldMapping JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.FieldMapping PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.FieldMapping System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.FieldMapping>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.FieldMapping>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.FieldMapping System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.FieldMapping>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.FieldMapping>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.FieldMapping>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class Indexes
    {
        protected Indexes() { }
        public System.ClientModel.Primitives.ClientPipeline Pipeline { get { throw null; } }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.DatasetIndex> CreateOrUpdate(string name, string version, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.DatasetIndex>> CreateOrUpdateAsync(string name, string version, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult Delete(string name, string version, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult Delete(string name, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> DeleteAsync(string name, string version, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> DeleteAsync(string name, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.CollectionResult Get(System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult Get(string name, string version, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.DatasetIndex> Get(string name, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Projects.DatasetIndex> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.AsyncCollectionResult GetAsync(System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> GetAsync(string name, string version, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.DatasetIndex>> GetAsync(string name, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Projects.DatasetIndex> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.CollectionResult GetVersions(string name, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Projects.DatasetIndex> GetVersions(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.AsyncCollectionResult GetVersionsAsync(string name, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Projects.DatasetIndex> GetVersionsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedAzureAISearchIndex : Azure.AI.Projects.DatasetIndex, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ManagedAzureAISearchIndex>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ManagedAzureAISearchIndex>
    {
        public ManagedAzureAISearchIndex(string vectorStoreId) { }
        public string VectorStoreId { get { throw null; } set { } }
        protected override Azure.AI.Projects.DatasetIndex JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.DatasetIndex PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.ManagedAzureAISearchIndex System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ManagedAzureAISearchIndex>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ManagedAzureAISearchIndex>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.ManagedAzureAISearchIndex System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ManagedAzureAISearchIndex>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ManagedAzureAISearchIndex>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ManagedAzureAISearchIndex>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ModelDeployment : Azure.AI.Projects.AIDeployment, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ModelDeployment>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ModelDeployment>
    {
        internal ModelDeployment() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Capabilities { get { throw null; } }
        public string ConnectionName { get { throw null; } }
        public string ModelName { get { throw null; } }
        public string ModelPublisher { get { throw null; } }
        public string ModelVersion { get { throw null; } }
        public Azure.AI.Projects.ModelDeploymentSku Sku { get { throw null; } }
        protected override Azure.AI.Projects.AIDeployment JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.AIDeployment PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class NoAuthenticationCredentials : Azure.AI.Projects.BaseCredentials, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.NoAuthenticationCredentials>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.NoAuthenticationCredentials>
    {
        internal NoAuthenticationCredentials() { }
        protected override Azure.AI.Projects.BaseCredentials JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.BaseCredentials PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.NoAuthenticationCredentials System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.NoAuthenticationCredentials>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.NoAuthenticationCredentials>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.NoAuthenticationCredentials System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.NoAuthenticationCredentials>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.NoAuthenticationCredentials>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.NoAuthenticationCredentials>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PendingUploadRequest : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.PendingUploadRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.PendingUploadRequest>
    {
        public PendingUploadRequest() { }
        public string ConnectionName { get { throw null; } set { } }
        public string PendingUploadId { get { throw null; } set { } }
        public Azure.AI.Projects.PendingUploadType PendingUploadType { get { throw null; } }
        protected virtual Azure.AI.Projects.PendingUploadRequest JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator System.ClientModel.BinaryContent (Azure.AI.Projects.PendingUploadRequest pendingUploadRequest) { throw null; }
        protected virtual Azure.AI.Projects.PendingUploadRequest PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.PendingUploadRequest System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.PendingUploadRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.PendingUploadRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.PendingUploadRequest System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.PendingUploadRequest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.PendingUploadRequest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.PendingUploadRequest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PendingUploadResponse : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.PendingUploadResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.PendingUploadResponse>
    {
        internal PendingUploadResponse() { }
        public Azure.AI.Projects.BlobReference BlobReference { get { throw null; } }
        public string PendingUploadId { get { throw null; } }
        public Azure.AI.Projects.PendingUploadType PendingUploadType { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual Azure.AI.Projects.PendingUploadResponse JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Projects.PendingUploadResponse (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.Projects.PendingUploadResponse PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.PendingUploadResponse System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.PendingUploadResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.PendingUploadResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.PendingUploadResponse System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.PendingUploadResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.PendingUploadResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.PendingUploadResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public static bool operator !=(Azure.AI.Projects.PendingUploadType left, Azure.AI.Projects.PendingUploadType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SASCredentials : Azure.AI.Projects.BaseCredentials, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.SASCredentials>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.SASCredentials>
    {
        internal SASCredentials() { }
        public string SasToken { get { throw null; } }
        protected override Azure.AI.Projects.BaseCredentials JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.BaseCredentials PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.SASCredentials System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.SASCredentials>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.SASCredentials>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.SASCredentials System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.SASCredentials>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.SASCredentials>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.SASCredentials>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class Telemetry
    {
        public Telemetry(Azure.AI.Projects.AIProjectClient outerInstance) { }
        public string GetConnectionString() { throw null; }
        public System.Threading.Tasks.Task<string> GetConnectionStringAsync() { throw null; }
    }
}
