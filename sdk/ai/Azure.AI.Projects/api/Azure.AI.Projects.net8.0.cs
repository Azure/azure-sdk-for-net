namespace Azure.AI.Projects
{
    public partial class AgenticIdentityPreviewCredentials : Azure.AI.Projects.AIProjectConnectionBaseCredential, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgenticIdentityPreviewCredentials>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgenticIdentityPreviewCredentials>
    {
        internal AgenticIdentityPreviewCredentials() { }
        protected override Azure.AI.Projects.AIProjectConnectionBaseCredential JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.AIProjectConnectionBaseCredential PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.AgenticIdentityPreviewCredentials System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgenticIdentityPreviewCredentials>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgenticIdentityPreviewCredentials>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AgenticIdentityPreviewCredentials System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgenticIdentityPreviewCredentials>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgenticIdentityPreviewCredentials>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgenticIdentityPreviewCredentials>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
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
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("SCME0002")]
        public AIProjectClient(Azure.AI.Projects.AIProjectClientSettings settings) : base (default(int)) { }
        public AIProjectClient(System.Uri endpoint, System.ClientModel.AuthenticationTokenProvider tokenProvider) : base (default(int)) { }
        public AIProjectClient(System.Uri endpoint, System.ClientModel.AuthenticationTokenProvider tokenProvider, Azure.AI.Projects.AIProjectClientOptions options) : base (default(int)) { }
        public virtual Azure.AI.Projects.Agents.AgentAdministrationClient AgentAdministrationClient { get { throw null; } }
        public virtual Azure.AI.Projects.AIProjectConnectionsOperations Connections { get { throw null; } }
        public virtual Azure.AI.Projects.AIProjectDatasetsOperations Datasets { get { throw null; } }
        public virtual Azure.AI.Projects.AIProjectDeploymentsOperations Deployments { get { throw null; } }
        public virtual Azure.AI.Projects.Evaluation.EvaluationRules EvaluationRules { get { throw null; } }
        public virtual Azure.AI.Projects.Evaluation.EvaluationTaxonomies EvaluationTaxonomies { get { throw null; } }
        public virtual Azure.AI.Projects.Evaluation.ProjectEvaluators Evaluators { get { throw null; } }
        public virtual Azure.AI.Projects.AIProjectIndexesOperations Indexes { get { throw null; } }
        public virtual Azure.AI.Projects.Evaluation.ProjectInsights Insights { get { throw null; } }
        public virtual Azure.AI.Projects.Memory.AIProjectMemoryStores MemoryStores { get { throw null; } }
        public System.ClientModel.Primitives.ClientPipeline Pipeline { get { throw null; } }
        public virtual Azure.AI.Extensions.OpenAI.ProjectOpenAIClient ProjectOpenAIClient { get { throw null; } }
        public virtual Azure.AI.Projects.Evaluation.RedTeams RedTeams { get { throw null; } }
        public virtual Azure.AI.Projects.ProjectSchedules Schedules { get { throw null; } }
        public virtual Azure.AI.Projects.AIProjectTelemetry Telemetry { get { throw null; } }
        public virtual Azure.AI.Projects.Memory.AIProjectMemoryStores GetAIProjectMemoryStoresClient() { throw null; }
        public override System.Collections.Generic.IEnumerable<System.ClientModel.Primitives.ClientConnection> GetAllConnections() { throw null; }
        public override System.ClientModel.Primitives.ClientConnection GetConnection(string connectionId) { throw null; }
    }
    public partial class AIProjectClientOptions : System.ClientModel.Primitives.ClientPipelineOptions
    {
        public AIProjectClientOptions(Azure.AI.Projects.AIProjectClientOptions.ServiceVersion version = Azure.AI.Projects.AIProjectClientOptions.ServiceVersion.V1) { }
        public string UserAgentApplicationId { get { throw null; } set { } }
        public enum ServiceVersion
        {
            V2025_05_01 = 1,
            V1 = 2,
        }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("SCME0002")]
    public partial class AIProjectClientSettings : System.ClientModel.Primitives.ClientSettings
    {
        public AIProjectClientSettings() { }
        public System.Uri Endpoint { get { throw null; } set { } }
        public Azure.AI.Projects.AIProjectClientOptions Options { get { throw null; } set { } }
        protected override void BindCore(Microsoft.Extensions.Configuration.IConfigurationSection section) { }
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
    public partial class AIProjectConnectionEntraIdCredential : Azure.AI.Projects.AIProjectConnectionBaseCredential, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AIProjectConnectionEntraIdCredential>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIProjectConnectionEntraIdCredential>
    {
        internal AIProjectConnectionEntraIdCredential() { }
        protected override Azure.AI.Projects.AIProjectConnectionBaseCredential JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.AIProjectConnectionBaseCredential PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.AIProjectConnectionEntraIdCredential System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AIProjectConnectionEntraIdCredential>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AIProjectConnectionEntraIdCredential>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AIProjectConnectionEntraIdCredential System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIProjectConnectionEntraIdCredential>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIProjectConnectionEntraIdCredential>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIProjectConnectionEntraIdCredential>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        [System.ObsoleteAttribute("This method is obsolete as the clientRequestId parameter is not used. Please use GetConnection(string connectionName, bool includeCredentials, CancellationToken cancellationToken) instead.")]
        public virtual Azure.AI.Projects.AIProjectConnection GetConnection(string connectionName, bool includeCredentials, string clientRequestId, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.AI.Projects.AIProjectConnection GetConnection(string connectionName, bool includeCredentials = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ObsoleteAttribute("This method is obsolete as the clientRequestId parameter is not used. Please use GetConnectionAsync(string connectionName, bool includeCredentials, CancellationToken cancellationToken) instead.")]
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.AIProjectConnection>> GetConnectionAsync(string connectionName, bool includeCredentials, string clientRequestId, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.AIProjectConnection>> GetConnectionAsync(string connectionName, bool includeCredentials = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ObsoleteAttribute("This method is obsolete as the clientRequestId parameter is not used. Please use GetConnections(ConnectionType? connectionType, bool? defaultConnection, CancellationToken cancellationToken) instead.")]
        public virtual System.ClientModel.CollectionResult<Azure.AI.Projects.AIProjectConnection> GetConnections(Azure.AI.Projects.ConnectionType? connectionType, bool? defaultConnection, string clientRequestId, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Projects.AIProjectConnection> GetConnections(Azure.AI.Projects.ConnectionType? connectionType = default(Azure.AI.Projects.ConnectionType?), bool? defaultConnection = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.CollectionResult GetConnections(string connectionType, bool? defaultConnection, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        [System.ObsoleteAttribute("This method is obsolete as the clientRequestId parameter is not used. Please use GetConnections(string connectionType, bool? defaultConnection, RequestOptions options) instead.")]
        public virtual System.ClientModel.Primitives.CollectionResult GetConnections(string connectionType, bool? defaultConnection, string clientRequestId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        [System.ObsoleteAttribute("This method is obsolete as the clientRequestId parameter is not used. Please use GetConnectionsAsync(ConnectionType? connectionType, bool? defaultConnection, CancellationToken cancellationToken) instead.")]
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Projects.AIProjectConnection> GetConnectionsAsync(Azure.AI.Projects.ConnectionType? connectionType, bool? defaultConnection, string clientRequestId, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Projects.AIProjectConnection> GetConnectionsAsync(Azure.AI.Projects.ConnectionType? connectionType = default(Azure.AI.Projects.ConnectionType?), bool? defaultConnection = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.AsyncCollectionResult GetConnectionsAsync(string connectionType, bool? defaultConnection, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        [System.ObsoleteAttribute("This method is obsolete as the clientRequestId parameter is not used. Please use GetConnectionsAsync(string connectionType, bool? defaultConnection, RequestOptions options) instead.")]
        public virtual System.ClientModel.Primitives.AsyncCollectionResult GetConnectionsAsync(string connectionType, bool? defaultConnection, string clientRequestId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual Azure.AI.Projects.AIProjectConnection GetDefaultConnection(Azure.AI.Projects.ConnectionType? connectionType = default(Azure.AI.Projects.ConnectionType?), bool includeCredentials = false) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.Projects.AIProjectConnection> GetDefaultConnectionAsync(Azure.AI.Projects.ConnectionType? connectionType = default(Azure.AI.Projects.ConnectionType?), bool includeCredentials = false) { throw null; }
    }
    public partial class AIProjectCosmosDBIndex : Azure.AI.Projects.AIProjectIndex, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AIProjectCosmosDBIndex>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIProjectCosmosDBIndex>
    {
        public AIProjectCosmosDBIndex(string connectionName, string databaseName, string containerName, Azure.AI.Projects.EmbeddingConfiguration embeddingConfiguration, Azure.AI.Projects.AIProjectIndexFieldMapping fieldMapping) { }
        public string ConnectionName { get { throw null; } set { } }
        public string ContainerName { get { throw null; } set { } }
        public string DatabaseName { get { throw null; } set { } }
        public Azure.AI.Projects.EmbeddingConfiguration EmbeddingConfiguration { get { throw null; } set { } }
        public Azure.AI.Projects.AIProjectIndexFieldMapping FieldMapping { get { throw null; } set { } }
        protected override Azure.AI.Projects.AIProjectIndex JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.AIProjectIndex PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.AIProjectCosmosDBIndex System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AIProjectCosmosDBIndex>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AIProjectCosmosDBIndex>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AIProjectCosmosDBIndex System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIProjectCosmosDBIndex>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIProjectCosmosDBIndex>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIProjectCosmosDBIndex>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class AIProjectDataset : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AIProjectDataset>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIProjectDataset>
    {
        internal AIProjectDataset() { }
        public string ConnectionName { get { throw null; } set { } }
        public System.Uri DataUri { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string Id { get { throw null; } }
        public bool? IsReference { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual Azure.AI.Projects.AIProjectDataset JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Projects.AIProjectDataset (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.Projects.AIProjectDataset PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.AIProjectDataset System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AIProjectDataset>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AIProjectDataset>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AIProjectDataset System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIProjectDataset>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIProjectDataset>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIProjectDataset>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.AIProjectDataset> GetDataset(string name, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> GetDatasetAsync(string name, string version, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.AIProjectDataset>> GetDatasetAsync(string name, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.CollectionResult GetDatasets(System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Projects.AIProjectDataset> GetDatasets(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.AsyncCollectionResult GetDatasetsAsync(System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Projects.AIProjectDataset> GetDatasetsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.CollectionResult GetDatasetVersions(string name, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Projects.AIProjectDataset> GetDatasetVersions(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.AsyncCollectionResult GetDatasetVersionsAsync(string name, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Projects.AIProjectDataset> GetDatasetVersionsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.PendingUploadResult> PendingUpload(string name, string version, Azure.AI.Projects.PendingUploadConfiguration configuration, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult PendingUpload(string name, string version, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.PendingUploadResult>> PendingUploadAsync(string name, string version, Azure.AI.Projects.PendingUploadConfiguration configuration, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> PendingUploadAsync(string name, string version, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.FileDataset> UploadFile(string name, string version, string filePath, string? connectionName = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.FileDataset>> UploadFileAsync(string name, string version, string filePath, string? connectionName = null) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.FolderDataset> UploadFolder(string name, string version, string folderPath, string? connectionName = null, System.Text.RegularExpressions.Regex? filePattern = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.FolderDataset>> UploadFolderAsync(string name, string version, string folderPath, string? connectionName = null, System.Text.RegularExpressions.Regex? filePattern = null) { throw null; }
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
        public virtual System.ClientModel.ClientResult GetDeployment(string name, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        [System.ObsoleteAttribute("This method is obsolete as the clientRequestId parameter is not used. Please use GetDeployment(string name, RequestOptions options) instead.")]
        public virtual System.ClientModel.ClientResult GetDeployment(string name, string clientRequestId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        [System.ObsoleteAttribute("This method is obsolete as the clientRequestId parameter is not used. Please use GetDeploymentAsync(string name, CancellationToken cancellationToken) instead.")]
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.AIProjectDeployment> GetDeployment(string name, string clientRequestId, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.AIProjectDeployment> GetDeployment(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> GetDeploymentAsync(string name, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        [System.ObsoleteAttribute("This method is obsolete as the clientRequestId parameter is not used. Please use GetDeploymentAsync(string name, RequestOptions options) instead.")]
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> GetDeploymentAsync(string name, string clientRequestId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        [System.ObsoleteAttribute("This method is obsolete as the clientRequestId parameter is not used. Please use GetDeploymentAsync(string name, CancellationToken cancellationToken) instead.")]
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.AIProjectDeployment>> GetDeploymentAsync(string name, string clientRequestId, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.AIProjectDeployment>> GetDeploymentAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ObsoleteAttribute("This method is obsolete as the clientRequestId parameter is not used. Please use GetDeploymentsAsync(string modelPublisher, string modelName, AIProjectDeploymentType? deploymentType, CancellationToken cancellationToken) instead.")]
        public virtual System.ClientModel.CollectionResult<Azure.AI.Projects.AIProjectDeployment> GetDeployments(string modelPublisher, string modelName, Azure.AI.Projects.AIProjectDeploymentType? deploymentType, string clientRequestId, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Projects.AIProjectDeployment> GetDeployments(string modelPublisher = null, string modelName = null, Azure.AI.Projects.AIProjectDeploymentType? deploymentType = default(Azure.AI.Projects.AIProjectDeploymentType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.CollectionResult GetDeployments(string modelPublisher, string modelName, string deploymentType, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        [System.ObsoleteAttribute("This method is obsolete as the clientRequestId parameter is not used. Please use GetDeployments(string modelPublisher, string modelName, string deploymentType, RequestOptions options) instead.")]
        public virtual System.ClientModel.Primitives.CollectionResult GetDeployments(string modelPublisher, string modelName, string deploymentType, string clientRequestId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        [System.ObsoleteAttribute("This method is obsolete as the clientRequestId parameter is not used. Please use GetDeploymentsAsync(string modelPublisher, string modelName, AIProjectDeploymentType? deploymentType, CancellationToken cancellationToken) instead.")]
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Projects.AIProjectDeployment> GetDeploymentsAsync(string modelPublisher, string modelName, Azure.AI.Projects.AIProjectDeploymentType? deploymentType, string clientRequestId, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Projects.AIProjectDeployment> GetDeploymentsAsync(string modelPublisher = null, string modelName = null, Azure.AI.Projects.AIProjectDeploymentType? deploymentType = default(Azure.AI.Projects.AIProjectDeploymentType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.AsyncCollectionResult GetDeploymentsAsync(string modelPublisher, string modelName, string deploymentType, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        [System.ObsoleteAttribute("This method is obsolete as the clientRequestId parameter is not used. Please use GetDeploymentsAsync(string modelPublisher, string modelName, string deploymentType, RequestOptions options) instead.")]
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
        public override bool Equals(object obj) { throw null; }
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
        public static Azure.AI.Projects.Evaluation.AgentClusterInsightRequest AgentClusterInsightRequest(string agentName = null, Azure.AI.Projects.Evaluation.InsightModelConfiguration modelConfiguration = null) { throw null; }
        public static Azure.AI.Projects.Evaluation.AgentClusterInsightResult AgentClusterInsightResult(Azure.AI.Projects.Evaluation.ClusterInsightResult clusterInsight = null) { throw null; }
        public static Azure.AI.Projects.AgenticIdentityPreviewCredentials AgenticIdentityPreviewCredentials() { throw null; }
        public static Azure.AI.Projects.AIProjectBlobReference AIProjectBlobReference(System.Uri blobUri = null, string storageAccountArmId = null, Azure.AI.Projects.BlobReferenceSasCredential credential = null) { throw null; }
        public static Azure.AI.Projects.AIProjectConnection AIProjectConnection(string name = null, string id = null, Azure.AI.Projects.ConnectionType type = default(Azure.AI.Projects.ConnectionType), string target = null, bool isDefault = false, Azure.AI.Projects.AIProjectConnectionBaseCredential credentials = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null) { throw null; }
        public static Azure.AI.Projects.AIProjectConnectionApiKeyCredential AIProjectConnectionApiKeyCredential(string apiKey = null) { throw null; }
        public static Azure.AI.Projects.AIProjectConnectionBaseCredential AIProjectConnectionBaseCredential(string type = null) { throw null; }
        public static Azure.AI.Projects.AIProjectConnectionCustomCredential AIProjectConnectionCustomCredential(System.Collections.Generic.IReadOnlyDictionary<string, string> additionalProperties = null) { throw null; }
        public static Azure.AI.Projects.AIProjectConnectionEntraIdCredential AIProjectConnectionEntraIdCredential() { throw null; }
        public static Azure.AI.Projects.AIProjectConnectionSasCredential AIProjectConnectionSasCredential(string sasToken = null) { throw null; }
        public static Azure.AI.Projects.AIProjectCosmosDBIndex AIProjectCosmosDBIndex(string id = null, string name = null, string version = null, string description = null, System.Collections.Generic.IDictionary<string, string> tags = null, string connectionName = null, string databaseName = null, string containerName = null, Azure.AI.Projects.EmbeddingConfiguration embeddingConfiguration = null, Azure.AI.Projects.AIProjectIndexFieldMapping fieldMapping = null) { throw null; }
        public static Azure.AI.Projects.AIProjectDataset AIProjectDataset(System.Uri dataUri = null, string type = null, bool? isReference = default(bool?), string connectionName = null, string id = null, string name = null, string version = null, string description = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.AI.Projects.AIProjectDeployment AIProjectDeployment(string type = null, string name = null) { throw null; }
        public static Azure.AI.Projects.AIProjectIndex AIProjectIndex(string type = null, string id = null, string name = null, string version = null, string description = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.AI.Projects.AIProjectIndexFieldMapping AIProjectIndexFieldMapping(System.Collections.Generic.IEnumerable<string> contentFields = null, string filepathField = null, string titleField = null, string urlField = null, System.Collections.Generic.IEnumerable<string> vectorFields = null, System.Collections.Generic.IEnumerable<string> metadataFields = null) { throw null; }
        public static Azure.AI.Projects.Evaluation.AzureAIAgentTarget AzureAIAgentTarget(string name = null, string version = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.ToolDescription> toolDescriptions = null) { throw null; }
        public static Azure.AI.Projects.Evaluation.AzureAIModelTarget AzureAIModelTarget(string model = null, Azure.AI.Projects.Evaluation.ModelSamplingParams samplingParams = null) { throw null; }
        public static Azure.AI.Projects.AzureAISearchIndex AzureAISearchIndex(string id = null, string name = null, string version = null, string description = null, System.Collections.Generic.IDictionary<string, string> tags = null, string connectionName = null, string indexName = null, Azure.AI.Projects.AIProjectIndexFieldMapping fieldMapping = null) { throw null; }
        public static Azure.AI.Projects.Evaluation.AzureOpenAIModelConfiguration AzureOpenAIModelConfiguration(string modelDeploymentName = null) { throw null; }
        public static Azure.AI.Projects.BlobReferenceSasCredential BlobReferenceSasCredential(System.Uri sasUri = null) { throw null; }
        public static Azure.AI.Projects.BlobReferenceSasCredential BlobReferenceSasCredential(System.Uri sasUri, string type) { throw null; }
        public static Azure.AI.Projects.Evaluation.ChartCoordinate ChartCoordinate(int x = 0, int y = 0, int size = 0) { throw null; }
        public static Azure.AI.Projects.Evaluation.ClusterInsightResult ClusterInsightResult(Azure.AI.Projects.Evaluation.InsightSummary summary = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.Evaluation.InsightCluster> clusters = null, System.Collections.Generic.IDictionary<string, Azure.AI.Projects.Evaluation.ChartCoordinate> coordinates = null) { throw null; }
        public static Azure.AI.Projects.Evaluation.ClusterTokenUsage ClusterTokenUsage(int inputTokenUsage = 0, int outputTokenUsage = 0, int totalTokenUsage = 0) { throw null; }
        public static Azure.AI.Projects.Evaluation.CodeBasedEvaluatorDefinition CodeBasedEvaluatorDefinition(System.BinaryData initParameters, System.BinaryData dataSchema, System.Collections.Generic.IDictionary<string, Azure.AI.Projects.Evaluation.EvaluatorMetric> metrics, string codeText) { throw null; }
        public static Azure.AI.Projects.Evaluation.CodeBasedEvaluatorDefinition CodeBasedEvaluatorDefinition(System.BinaryData initParameters = null, System.BinaryData dataSchema = null, System.Collections.Generic.IDictionary<string, Azure.AI.Projects.Evaluation.EvaluatorMetric> metrics = null, string codeText = null, string entryPoint = null, string imageTag = null, System.Uri blobUri = null) { throw null; }
        public static Azure.AI.Projects.Evaluation.ContinuousEvaluationRuleAction ContinuousEvaluationRuleAction(string evalId = null, int? maxHourlyRuns = default(int?)) { throw null; }
        public static Azure.AI.Projects.DatasetCredential DatasetCredential(Azure.AI.Projects.AIProjectBlobReference blobReference = null) { throw null; }
        public static Azure.AI.Projects.Memory.DeleteMemoryStoreResponse DeleteMemoryStoreResponse(string name = null, bool isDeleted = false) { throw null; }
        public static Azure.AI.Projects.EmbeddingConfiguration EmbeddingConfiguration(string modelDeploymentName = null, string embeddingField = null) { throw null; }
        public static Azure.AI.Projects.Evaluation.EvalResult EvalResult(string name = null, string type = null, float score = 0f, bool isPassed = false) { throw null; }
        public static Azure.AI.Projects.Evaluation.EvalRunResultCompareItem EvalRunResultCompareItem(string treatmentRunId = null, Azure.AI.Projects.Evaluation.EvalRunResultSummary treatmentRunSummary = null, float deltaEstimate = 0f, float pValue = 0f, Azure.AI.Projects.TreatmentEffectType treatmentEffect = default(Azure.AI.Projects.TreatmentEffectType)) { throw null; }
        public static Azure.AI.Projects.Evaluation.EvalRunResultComparison EvalRunResultComparison(string testingCriteria = null, string metricName = null, string evaluatorName = null, Azure.AI.Projects.Evaluation.EvalRunResultSummary baselineRunSummary = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.Evaluation.EvalRunResultCompareItem> compareItems = null) { throw null; }
        public static Azure.AI.Projects.Evaluation.EvalRunResultSummary EvalRunResultSummary(string runId = null, int sampleCount = 0, float average = 0f, float standardDeviation = 0f) { throw null; }
        public static Azure.AI.Projects.Evaluation.EvaluationComparisonInsightRequest EvaluationComparisonInsightRequest(string evalId = null, string baselineRunId = null, System.Collections.Generic.IEnumerable<string> treatmentRunIds = null) { throw null; }
        public static Azure.AI.Projects.Evaluation.EvaluationComparisonInsightResult EvaluationComparisonInsightResult(System.Collections.Generic.IEnumerable<Azure.AI.Projects.Evaluation.EvalRunResultComparison> comparisons = null, string method = null) { throw null; }
        public static Azure.AI.Projects.Evaluation.EvaluationRule EvaluationRule(string id = null, string displayName = null, string description = null, Azure.AI.Projects.Evaluation.EvaluationRuleAction action = null, Azure.AI.Projects.Evaluation.EvaluationRuleFilter filter = null, Azure.AI.Projects.Evaluation.EvaluationRuleEventType eventType = default(Azure.AI.Projects.Evaluation.EvaluationRuleEventType), bool enabled = false, System.Collections.Generic.IReadOnlyDictionary<string, string> systemData = null) { throw null; }
        public static Azure.AI.Projects.Evaluation.EvaluationRuleAction EvaluationRuleAction(string type = null) { throw null; }
        public static Azure.AI.Projects.Evaluation.EvaluationRuleFilter EvaluationRuleFilter(string agentName = null) { throw null; }
        public static Azure.AI.Projects.Evaluation.EvaluationRunClusterInsightRequest EvaluationRunClusterInsightRequest(string evalId = null, System.Collections.Generic.IEnumerable<string> runIds = null, Azure.AI.Projects.Evaluation.InsightModelConfiguration modelConfiguration = null) { throw null; }
        public static Azure.AI.Projects.Evaluation.EvaluationRunClusterInsightResult EvaluationRunClusterInsightResult(Azure.AI.Projects.Evaluation.ClusterInsightResult clusterInsight = null) { throw null; }
        public static Azure.AI.Projects.Evaluation.EvaluationScheduleTask EvaluationScheduleTask(System.Collections.Generic.IDictionary<string, string> configuration = null, string evalId = null, System.BinaryData evalRun = null) { throw null; }
        public static Azure.AI.Projects.Evaluation.EvaluationTarget EvaluationTarget(string type = null) { throw null; }
        public static Azure.AI.Projects.Evaluation.EvaluationTaxonomy EvaluationTaxonomy(string id = null, string name = null, string version = null, string description = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.AI.Projects.Evaluation.EvaluationTaxonomyInput taxonomyInput = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.Evaluation.TaxonomyCategory> taxonomyCategories = null, System.Collections.Generic.IDictionary<string, string> properties = null) { throw null; }
        public static Azure.AI.Projects.EvaluatorCredentialRequest EvaluatorCredentialRequest(System.Uri blobUri = null) { throw null; }
        public static Azure.AI.Projects.Evaluation.EvaluatorDefinition EvaluatorDefinition(string type = null, System.BinaryData initParameters = null, System.BinaryData dataSchema = null, System.Collections.Generic.IDictionary<string, Azure.AI.Projects.Evaluation.EvaluatorMetric> metrics = null) { throw null; }
        public static Azure.AI.Projects.Evaluation.EvaluatorMetric EvaluatorMetric(Azure.AI.Projects.Evaluation.EvaluatorMetricType? type = default(Azure.AI.Projects.Evaluation.EvaluatorMetricType?), Azure.AI.Projects.Evaluation.EvaluatorMetricDirection? desirableDirection = default(Azure.AI.Projects.Evaluation.EvaluatorMetricDirection?), float? minValue = default(float?), float? maxValue = default(float?), bool? isPrimary = default(bool?)) { throw null; }
        public static Azure.AI.Projects.Evaluation.EvaluatorVersion EvaluatorVersion(string displayName = null, System.Collections.Generic.IDictionary<string, string> metadata = null, Azure.AI.Projects.EvaluatorType evaluatorType = default(Azure.AI.Projects.EvaluatorType), System.Collections.Generic.IEnumerable<Azure.AI.Projects.Evaluation.EvaluatorCategory> categories = null, Azure.AI.Projects.Evaluation.EvaluatorDefinition definition = null, string createdBy = null, string createdAt = null, string modifiedAt = null, string id = null, string name = null, string version = null, string description = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.AI.Projects.FileDataset FileDataset(System.Uri dataUri = null, bool? isReference = default(bool?), string connectionName = null, string id = null, string name = null, string version = null, string description = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.AI.Projects.FolderDataset FolderDataset(System.Uri dataUri = null, bool? isReference = default(bool?), string connectionName = null, string id = null, string name = null, string version = null, string description = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.AI.Projects.Evaluation.HumanEvaluationPreviewRuleAction HumanEvaluationPreviewRuleAction(string templateId = null) { throw null; }
        public static Azure.AI.Projects.InputFileContentParam InputFileContentParam(string fileId = null, string filename = null, string fileData = null, System.Uri fileUri = null) { throw null; }
        public static Azure.AI.Projects.InputTextContentParam InputTextContentParam(string text = null) { throw null; }
        public static Azure.AI.Projects.Evaluation.InsightCluster InsightCluster(string id = null, string label = null, string suggestion = null, string suggestionTitle = null, string description = null, int weight = 0, System.Collections.Generic.IEnumerable<Azure.AI.Projects.Evaluation.InsightCluster> subClusters = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.Evaluation.InsightSample> samples = null) { throw null; }
        public static Azure.AI.Projects.Evaluation.InsightModelConfiguration InsightModelConfiguration(string modelDeploymentName = null) { throw null; }
        public static Azure.AI.Projects.Evaluation.InsightRequest InsightRequest(string type = null) { throw null; }
        public static Azure.AI.Projects.Evaluation.InsightResult InsightResult(string type = null) { throw null; }
        public static Azure.AI.Projects.Evaluation.InsightScheduleTask InsightScheduleTask(System.Collections.Generic.IDictionary<string, string> configuration = null, Azure.AI.Projects.Evaluation.ProjectsInsight insight = null) { throw null; }
        public static Azure.AI.Projects.Evaluation.InsightsMetadata InsightsMetadata(System.DateTimeOffset createdAt = default(System.DateTimeOffset), System.DateTimeOffset? completedAt = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.AI.Projects.Evaluation.InsightSummary InsightSummary(int sampleCount = 0, int uniqueSubclusterCount = 0, int uniqueClusterCount = 0, string methodName = null, Azure.AI.Projects.Evaluation.ClusterTokenUsage usage = null) { throw null; }
        public static Azure.AI.Projects.ManagedAzureAISearchIndex ManagedAzureAISearchIndex(string id = null, string name = null, string version = null, string description = null, System.Collections.Generic.IDictionary<string, string> tags = null, string vectorStoreId = null) { throw null; }
        public static Azure.AI.Projects.Memory.MemoryOperation MemoryOperation(Azure.AI.Projects.Memory.MemoryOperationKind kind = default(Azure.AI.Projects.Memory.MemoryOperationKind), Azure.AI.Projects.Memory.MemoryItem memoryItem = null) { throw null; }
        public static Azure.AI.Projects.Memory.MemorySearchItem MemorySearchItem(Azure.AI.Projects.Memory.MemoryItem memoryItem = null) { throw null; }
        public static Azure.AI.Projects.Memory.MemorySearchResultOptions MemorySearchResultOptions(int? maxMemories = default(int?)) { throw null; }
        public static Azure.AI.Projects.Memory.MemoryStore MemoryStore(string id = null, System.DateTimeOffset createdAt = default(System.DateTimeOffset), System.DateTimeOffset updatedAt = default(System.DateTimeOffset), string name = null, string description = null, System.Collections.Generic.IDictionary<string, string> metadata = null, Azure.AI.Projects.Memory.MemoryStoreDefinition definition = null) { throw null; }
        public static Azure.AI.Projects.Memory.MemoryStoreDefaultOptions MemoryStoreDefaultOptions(bool isUserProfileEnabled = false, string userProfileDetails = null, bool isChatSummaryEnabled = false) { throw null; }
        public static Azure.AI.Projects.Memory.MemoryStoreDeleteScopeResponse MemoryStoreDeleteScopeResponse(string name = null, string scope = null, bool isDeleted = false) { throw null; }
        public static Azure.AI.Projects.Memory.MemoryStoreOperationUsage MemoryStoreOperationUsage(int embeddingTokens = 0, long inputTokens = (long)0, Azure.AI.Projects.ResponseUsageInputTokensDetails inputTokensDetails = null, long outputTokens = (long)0, Azure.AI.Projects.ResponseUsageOutputTokensDetails outputTokensDetails = null, long totalTokens = (long)0) { throw null; }
        public static Azure.AI.Projects.Memory.MemoryStoreSearchResponse MemoryStoreSearchResponse(string searchId = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.Memory.MemorySearchItem> memories = null, Azure.AI.Projects.Memory.MemoryStoreOperationUsage usage = null) { throw null; }
        public static Azure.AI.Projects.Memory.MemoryUpdateResultDetails MemoryUpdateResultDetails(System.Collections.Generic.IEnumerable<Azure.AI.Projects.Memory.MemoryOperation> memoryOperations = null, Azure.AI.Projects.Memory.MemoryStoreOperationUsage usage = null) { throw null; }
        public static Azure.AI.Projects.ModelDeployment ModelDeployment(string name = null, string modelName = null, string modelVersion = null, string modelPublisher = null, System.Collections.Generic.IReadOnlyDictionary<string, string> capabilities = null, Azure.AI.Projects.ModelDeploymentSku sku = null, string connectionName = null) { throw null; }
        public static Azure.AI.Projects.ModelDeploymentSku ModelDeploymentSku(long capacity = (long)0, string family = null, string name = null, string size = null, string tier = null) { throw null; }
        public static Azure.AI.Projects.Evaluation.ModelSamplingParams ModelSamplingParams(float temperature = 0f, float topP = 0f, int seed = 0, int maxCompletionTokens = 0) { throw null; }
        public static Azure.AI.Projects.NoAuthenticationCredentials NoAuthenticationCredentials() { throw null; }
        public static Azure.AI.Projects.PendingUploadConfiguration PendingUploadConfiguration(string pendingUploadId = null, string connectionName = null) { throw null; }
        public static Azure.AI.Projects.PendingUploadConfiguration PendingUploadConfiguration(string pendingUploadId, string connectionName, Azure.AI.Projects.PendingUploadType pendingUploadType) { throw null; }
        public static Azure.AI.Projects.PendingUploadResult PendingUploadResult(Azure.AI.Projects.AIProjectBlobReference blobReference = null, string pendingUploadId = null, string version = null) { throw null; }
        public static Azure.AI.Projects.PendingUploadResult PendingUploadResult(Azure.AI.Projects.AIProjectBlobReference blobReference, string pendingUploadId, string version, Azure.AI.Projects.PendingUploadType pendingUploadType) { throw null; }
        public static Azure.AI.Projects.Evaluation.ProjectsInsight ProjectsInsight(string id = null, Azure.AI.Projects.Evaluation.InsightsMetadata metadata = null, Azure.AI.Projects.Evaluation.OperationStatus state = default(Azure.AI.Projects.Evaluation.OperationStatus), string displayName = null, Azure.AI.Projects.Evaluation.InsightRequest request = null, Azure.AI.Projects.Evaluation.InsightResult result = null) { throw null; }
        public static Azure.AI.Projects.Evaluation.ProjectsSchedule ProjectsSchedule(string id = null, string displayName = null, string description = null, bool enabled = false, Azure.AI.Projects.Evaluation.ScheduleProvisioningStatus? provisioningStatus = default(Azure.AI.Projects.Evaluation.ScheduleProvisioningStatus?), Azure.AI.Projects.Evaluation.ScheduleTrigger trigger = null, Azure.AI.Projects.ProjectsScheduleTask task = null, System.Collections.Generic.IDictionary<string, string> tags = null, System.Collections.Generic.IDictionary<string, string> properties = null, System.Collections.Generic.IReadOnlyDictionary<string, string> systemData = null) { throw null; }
        public static Azure.AI.Projects.ProjectsScheduleTask ProjectsScheduleTask(string type = null, System.Collections.Generic.IDictionary<string, string> configuration = null) { throw null; }
        public static Azure.AI.Projects.Evaluation.PromptBasedEvaluatorDefinition PromptBasedEvaluatorDefinition(System.BinaryData initParameters = null, System.BinaryData dataSchema = null, System.Collections.Generic.IDictionary<string, Azure.AI.Projects.Evaluation.EvaluatorMetric> metrics = null, string promptText = null) { throw null; }
        public static Azure.AI.Projects.Evaluation.RedTeam RedTeam(string name = null, string displayName = null, int? turnCount = default(int?), System.Collections.Generic.IEnumerable<Azure.AI.Projects.Evaluation.AttackStrategy> attackStrategies = null, bool? isSimulationOnly = default(bool?), System.Collections.Generic.IEnumerable<Azure.AI.Projects.Evaluation.RiskCategory> riskCategories = null, string applicationScenario = null, System.Collections.Generic.IDictionary<string, string> tags = null, System.Collections.Generic.IDictionary<string, string> properties = null, string status = null, Azure.AI.Projects.Evaluation.TargetConfig target = null) { throw null; }
        public static Azure.AI.Projects.ResponseUsageInputTokensDetails ResponseUsageInputTokensDetails(long cachedTokens = (long)0) { throw null; }
        public static Azure.AI.Projects.ResponseUsageOutputTokensDetails ResponseUsageOutputTokensDetails(long reasoningTokens = (long)0) { throw null; }
        public static Azure.AI.Projects.Evaluation.ScheduleRun ScheduleRun(string runId = null, string scheduleId = null, bool success = false, System.DateTimeOffset? triggerTime = default(System.DateTimeOffset?), string error = null, System.Collections.Generic.IReadOnlyDictionary<string, string> properties = null) { throw null; }
        public static Azure.AI.Projects.Evaluation.TargetConfig TargetConfig(string type = null) { throw null; }
        public static Azure.AI.Projects.Evaluation.TaxonomyCategory TaxonomyCategory(string id = null, string name = null, string description = null, Azure.AI.Projects.Evaluation.RiskCategory riskCategory = default(Azure.AI.Projects.Evaluation.RiskCategory), System.Collections.Generic.IEnumerable<Azure.AI.Projects.Evaluation.TaxonomySubCategory> subCategories = null, System.Collections.Generic.IDictionary<string, string> properties = null) { throw null; }
        public static Azure.AI.Projects.Evaluation.TaxonomySubCategory TaxonomySubCategory(string id = null, string name = null, string description = null, bool isEnabled = false, System.Collections.Generic.IDictionary<string, string> properties = null) { throw null; }
        public static Azure.AI.Projects.ToolDescription ToolDescription(string name = null, string description = null) { throw null; }
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
        public static Azure.AI.Projects.ConnectionType RemoteTool { get { throw null; } }
        public bool Equals(Azure.AI.Projects.ConnectionType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.ConnectionType left, Azure.AI.Projects.ConnectionType right) { throw null; }
        public static implicit operator Azure.AI.Projects.ConnectionType (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.ConnectionType? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.ConnectionType left, Azure.AI.Projects.ConnectionType right) { throw null; }
        public override string ToString() { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EvaluationRuleActionType : System.IEquatable<Azure.AI.Projects.EvaluationRuleActionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EvaluationRuleActionType(string value) { throw null; }
        public static Azure.AI.Projects.EvaluationRuleActionType ContinuousEvaluation { get { throw null; } }
        public static Azure.AI.Projects.EvaluationRuleActionType HumanEvaluationPreview { get { throw null; } }
        public bool Equals(Azure.AI.Projects.EvaluationRuleActionType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.EvaluationRuleActionType left, Azure.AI.Projects.EvaluationRuleActionType right) { throw null; }
        public static implicit operator Azure.AI.Projects.EvaluationRuleActionType (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.EvaluationRuleActionType? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.EvaluationRuleActionType left, Azure.AI.Projects.EvaluationRuleActionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EvaluatorCredentialRequest : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.EvaluatorCredentialRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EvaluatorCredentialRequest>
    {
        public EvaluatorCredentialRequest(System.Uri blobUri) { }
        public System.Uri BlobUri { get { throw null; } }
        protected virtual Azure.AI.Projects.EvaluatorCredentialRequest JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator System.ClientModel.BinaryContent (Azure.AI.Projects.EvaluatorCredentialRequest evaluatorCredentialRequest) { throw null; }
        protected virtual Azure.AI.Projects.EvaluatorCredentialRequest PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.EvaluatorCredentialRequest System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.EvaluatorCredentialRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.EvaluatorCredentialRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.EvaluatorCredentialRequest System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EvaluatorCredentialRequest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EvaluatorCredentialRequest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EvaluatorCredentialRequest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EvaluatorType : System.IEquatable<Azure.AI.Projects.EvaluatorType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EvaluatorType(string value) { throw null; }
        public static Azure.AI.Projects.EvaluatorType BuiltIn { get { throw null; } }
        public static Azure.AI.Projects.EvaluatorType Custom { get { throw null; } }
        public bool Equals(Azure.AI.Projects.EvaluatorType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.EvaluatorType left, Azure.AI.Projects.EvaluatorType right) { throw null; }
        public static implicit operator Azure.AI.Projects.EvaluatorType (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.EvaluatorType? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.EvaluatorType left, Azure.AI.Projects.EvaluatorType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FileDataset : Azure.AI.Projects.AIProjectDataset, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.FileDataset>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.FileDataset>
    {
        public FileDataset(System.Uri dataUri) { }
        protected override Azure.AI.Projects.AIProjectDataset JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.AIProjectDataset PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.FileDataset System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.FileDataset>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.FileDataset>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.FileDataset System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.FileDataset>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.FileDataset>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.FileDataset>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FolderDataset : Azure.AI.Projects.AIProjectDataset, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.FolderDataset>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.FolderDataset>
    {
        public FolderDataset(System.Uri dataUri) { }
        protected override Azure.AI.Projects.AIProjectDataset JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.AIProjectDataset PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.FolderDataset System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.FolderDataset>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.FolderDataset>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.FolderDataset System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.FolderDataset>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.FolderDataset>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.FolderDataset>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum FoundryFeaturesOptInKeys
    {
        EvaluationsV1Preview = 0,
        SchedulesV1Preview = 1,
        RedTeamsV1Preview = 2,
        InsightsV1Preview = 3,
        MemoryStoresV1Preview = 4,
        SkillsV1Preview = 5,
        ToolboxesV1Preview = 6,
    }
    public partial class InputFileContentParam : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.InputFileContentParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.InputFileContentParam>
    {
        public InputFileContentParam() { }
        public string FileData { get { throw null; } set { } }
        public string FileId { get { throw null; } set { } }
        public string Filename { get { throw null; } set { } }
        public System.Uri FileUri { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.InputFileContentParam JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.InputFileContentParam PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.InputFileContentParam System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.InputFileContentParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.InputFileContentParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.InputFileContentParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.InputFileContentParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.InputFileContentParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.InputFileContentParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InputTextContentParam : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.InputTextContentParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.InputTextContentParam>
    {
        public InputTextContentParam(string text) { }
        public string Text { get { throw null; } }
        protected virtual Azure.AI.Projects.InputTextContentParam JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.InputTextContentParam PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.InputTextContentParam System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.InputTextContentParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.InputTextContentParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.InputTextContentParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.InputTextContentParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.InputTextContentParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.InputTextContentParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.PendingUploadType left, Azure.AI.Projects.PendingUploadType right) { throw null; }
        public static implicit operator Azure.AI.Projects.PendingUploadType (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.PendingUploadType? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.PendingUploadType left, Azure.AI.Projects.PendingUploadType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class ProjectSchedules
    {
        protected ProjectSchedules() { }
        public System.ClientModel.Primitives.ClientPipeline Pipeline { get { throw null; } }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Evaluation.ProjectsSchedule> CreateOrUpdate(string id, Azure.AI.Projects.Evaluation.ProjectsSchedule resource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult CreateOrUpdate(string id, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Evaluation.ProjectsSchedule>> CreateOrUpdateAsync(string id, Azure.AI.Projects.Evaluation.ProjectsSchedule resource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> CreateOrUpdateAsync(string id, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult Delete(string id, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult Delete(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> DeleteAsync(string id, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> DeleteAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult Get(string id, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Evaluation.ProjectsSchedule> Get(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Projects.Evaluation.ProjectsSchedule> GetAll(Azure.AI.Projects.Evaluation.ScheduleTaskType? type = default(Azure.AI.Projects.Evaluation.ScheduleTaskType?), bool? enabled = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.CollectionResult GetAll(string type, bool? enabled, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Projects.Evaluation.ProjectsSchedule> GetAllAsync(Azure.AI.Projects.Evaluation.ScheduleTaskType? type = default(Azure.AI.Projects.Evaluation.ScheduleTaskType?), bool? enabled = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.AsyncCollectionResult GetAllAsync(string type, bool? enabled, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> GetAsync(string id, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Evaluation.ProjectsSchedule>> GetAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult GetRun(string scheduleId, string runId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Evaluation.ScheduleRun> GetRun(string scheduleId, string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> GetRunAsync(string scheduleId, string runId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Evaluation.ScheduleRun>> GetRunAsync(string scheduleId, string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Projects.Evaluation.ScheduleRun> GetRuns(string id, Azure.AI.Projects.Evaluation.ScheduleTaskType? type = default(Azure.AI.Projects.Evaluation.ScheduleTaskType?), bool? enabled = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.CollectionResult GetRuns(string id, string type, bool? enabled, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Projects.Evaluation.ScheduleRun> GetRunsAsync(string id, Azure.AI.Projects.Evaluation.ScheduleTaskType? type = default(Azure.AI.Projects.Evaluation.ScheduleTaskType?), bool? enabled = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.AsyncCollectionResult GetRunsAsync(string id, string type, bool? enabled, System.ClientModel.Primitives.RequestOptions options) { throw null; }
    }
    public abstract partial class ProjectsScheduleTask : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ProjectsScheduleTask>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ProjectsScheduleTask>
    {
        internal ProjectsScheduleTask() { }
        public System.Collections.Generic.IDictionary<string, string> Configuration { get { throw null; } }
        protected virtual Azure.AI.Projects.ProjectsScheduleTask JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.ProjectsScheduleTask PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.ProjectsScheduleTask System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ProjectsScheduleTask>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ProjectsScheduleTask>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.ProjectsScheduleTask System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ProjectsScheduleTask>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ProjectsScheduleTask>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ProjectsScheduleTask>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResponseUsageInputTokensDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ResponseUsageInputTokensDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ResponseUsageInputTokensDetails>
    {
        internal ResponseUsageInputTokensDetails() { }
        public long CachedTokens { get { throw null; } }
        protected virtual Azure.AI.Projects.ResponseUsageInputTokensDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.ResponseUsageInputTokensDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.ResponseUsageInputTokensDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ResponseUsageInputTokensDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ResponseUsageInputTokensDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.ResponseUsageInputTokensDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ResponseUsageInputTokensDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ResponseUsageInputTokensDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ResponseUsageInputTokensDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResponseUsageOutputTokensDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ResponseUsageOutputTokensDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ResponseUsageOutputTokensDetails>
    {
        internal ResponseUsageOutputTokensDetails() { }
        public long ReasoningTokens { get { throw null; } }
        protected virtual Azure.AI.Projects.ResponseUsageOutputTokensDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.ResponseUsageOutputTokensDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.ResponseUsageOutputTokensDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ResponseUsageOutputTokensDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ResponseUsageOutputTokensDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.ResponseUsageOutputTokensDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ResponseUsageOutputTokensDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ResponseUsageOutputTokensDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ResponseUsageOutputTokensDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ToolDescription : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ToolDescription>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ToolDescription>
    {
        public ToolDescription() { }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.ToolDescription JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.ToolDescription PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.ToolDescription System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ToolDescription>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ToolDescription>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.ToolDescription System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ToolDescription>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ToolDescription>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ToolDescription>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TreatmentEffectType : System.IEquatable<Azure.AI.Projects.TreatmentEffectType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TreatmentEffectType(string value) { throw null; }
        public static Azure.AI.Projects.TreatmentEffectType Changed { get { throw null; } }
        public static Azure.AI.Projects.TreatmentEffectType Degraded { get { throw null; } }
        public static Azure.AI.Projects.TreatmentEffectType Improved { get { throw null; } }
        public static Azure.AI.Projects.TreatmentEffectType Inconclusive { get { throw null; } }
        public static Azure.AI.Projects.TreatmentEffectType TooFewSamples { get { throw null; } }
        public bool Equals(Azure.AI.Projects.TreatmentEffectType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.TreatmentEffectType left, Azure.AI.Projects.TreatmentEffectType right) { throw null; }
        public static implicit operator Azure.AI.Projects.TreatmentEffectType (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.TreatmentEffectType? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.TreatmentEffectType left, Azure.AI.Projects.TreatmentEffectType right) { throw null; }
        public override string ToString() { throw null; }
    }
}
namespace Azure.AI.Projects.Evaluation
{
    public partial class AgentClusterInsightRequest : Azure.AI.Projects.Evaluation.InsightRequest, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.AgentClusterInsightRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.AgentClusterInsightRequest>
    {
        public AgentClusterInsightRequest(string agentName) { }
        public string AgentName { get { throw null; } set { } }
        public Azure.AI.Projects.Evaluation.InsightModelConfiguration ModelConfiguration { get { throw null; } set { } }
        protected override Azure.AI.Projects.Evaluation.InsightRequest JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Evaluation.InsightRequest PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.AgentClusterInsightRequest System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.AgentClusterInsightRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.AgentClusterInsightRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.AgentClusterInsightRequest System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.AgentClusterInsightRequest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.AgentClusterInsightRequest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.AgentClusterInsightRequest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentClusterInsightResult : Azure.AI.Projects.Evaluation.InsightResult, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.AgentClusterInsightResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.AgentClusterInsightResult>
    {
        internal AgentClusterInsightResult() { }
        public Azure.AI.Projects.Evaluation.ClusterInsightResult ClusterInsight { get { throw null; } }
        protected override Azure.AI.Projects.Evaluation.InsightResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Evaluation.InsightResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.AgentClusterInsightResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.AgentClusterInsightResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.AgentClusterInsightResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.AgentClusterInsightResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.AgentClusterInsightResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.AgentClusterInsightResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.AgentClusterInsightResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentTaxonomyInput : Azure.AI.Projects.Evaluation.EvaluationTaxonomyInput, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.AgentTaxonomyInput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.AgentTaxonomyInput>
    {
        public AgentTaxonomyInput(Azure.AI.Projects.Evaluation.EvaluationTarget target, System.Collections.Generic.IEnumerable<Azure.AI.Projects.Evaluation.RiskCategory> riskCategories) { }
        public System.Collections.Generic.IList<Azure.AI.Projects.Evaluation.RiskCategory> RiskCategories { get { throw null; } }
        public Azure.AI.Projects.Evaluation.EvaluationTarget Target { get { throw null; } set { } }
        protected override Azure.AI.Projects.Evaluation.EvaluationTaxonomyInput JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Evaluation.EvaluationTaxonomyInput PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.AgentTaxonomyInput System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.AgentTaxonomyInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.AgentTaxonomyInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.AgentTaxonomyInput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.AgentTaxonomyInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.AgentTaxonomyInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.AgentTaxonomyInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AttackStrategy : System.IEquatable<Azure.AI.Projects.Evaluation.AttackStrategy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AttackStrategy(string value) { throw null; }
        public static Azure.AI.Projects.Evaluation.AttackStrategy AnsiAttack { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.AttackStrategy AsciiArt { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.AttackStrategy AsciiSmuggler { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.AttackStrategy Atbash { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.AttackStrategy Base64 { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.AttackStrategy Baseline { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.AttackStrategy Binary { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.AttackStrategy Caesar { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.AttackStrategy CharacterSpace { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.AttackStrategy CharacterSwap { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.AttackStrategy Crescendo { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.AttackStrategy Diacritic { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.AttackStrategy Difficult { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.AttackStrategy Easy { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.AttackStrategy Flip { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.AttackStrategy IndirectJailbreak { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.AttackStrategy Jailbreak { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.AttackStrategy Leetspeak { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.AttackStrategy Moderate { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.AttackStrategy Morse { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.AttackStrategy MultiTurn { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.AttackStrategy Rot13 { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.AttackStrategy StringJoin { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.AttackStrategy SuffixAppend { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.AttackStrategy Tense { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.AttackStrategy UnicodeConfusable { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.AttackStrategy UnicodeSubstitution { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.AttackStrategy Url { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Evaluation.AttackStrategy other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Evaluation.AttackStrategy left, Azure.AI.Projects.Evaluation.AttackStrategy right) { throw null; }
        public static implicit operator Azure.AI.Projects.Evaluation.AttackStrategy (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Evaluation.AttackStrategy? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Evaluation.AttackStrategy left, Azure.AI.Projects.Evaluation.AttackStrategy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AzureAIAgentTarget : Azure.AI.Projects.Evaluation.EvaluationTarget, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.AzureAIAgentTarget>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.AzureAIAgentTarget>
    {
        public AzureAIAgentTarget(string name) { }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Projects.ToolDescription> ToolDescriptions { get { throw null; } }
        public string Version { get { throw null; } set { } }
        protected override Azure.AI.Projects.Evaluation.EvaluationTarget JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Evaluation.EvaluationTarget PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.AzureAIAgentTarget System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.AzureAIAgentTarget>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.AzureAIAgentTarget>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.AzureAIAgentTarget System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.AzureAIAgentTarget>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.AzureAIAgentTarget>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.AzureAIAgentTarget>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureAIModelTarget : Azure.AI.Projects.Evaluation.EvaluationTarget, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.AzureAIModelTarget>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.AzureAIModelTarget>
    {
        public AzureAIModelTarget() { }
        public string Model { get { throw null; } set { } }
        public Azure.AI.Projects.Evaluation.ModelSamplingParams SamplingParams { get { throw null; } set { } }
        protected override Azure.AI.Projects.Evaluation.EvaluationTarget JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Evaluation.EvaluationTarget PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.AzureAIModelTarget System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.AzureAIModelTarget>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.AzureAIModelTarget>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.AzureAIModelTarget System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.AzureAIModelTarget>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.AzureAIModelTarget>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.AzureAIModelTarget>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureOpenAIModelConfiguration : Azure.AI.Projects.Evaluation.TargetConfig, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.AzureOpenAIModelConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.AzureOpenAIModelConfiguration>
    {
        public AzureOpenAIModelConfiguration(string modelDeploymentName) { }
        public string ModelDeploymentName { get { throw null; } set { } }
        protected override Azure.AI.Projects.Evaluation.TargetConfig JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Evaluation.TargetConfig PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.AzureOpenAIModelConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.AzureOpenAIModelConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.AzureOpenAIModelConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.AzureOpenAIModelConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.AzureOpenAIModelConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.AzureOpenAIModelConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.AzureOpenAIModelConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChartCoordinate : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.ChartCoordinate>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.ChartCoordinate>
    {
        internal ChartCoordinate() { }
        public int Size { get { throw null; } }
        public int X { get { throw null; } }
        public int Y { get { throw null; } }
        protected virtual Azure.AI.Projects.Evaluation.ChartCoordinate JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Evaluation.ChartCoordinate PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.ChartCoordinate System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.ChartCoordinate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.ChartCoordinate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.ChartCoordinate System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.ChartCoordinate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.ChartCoordinate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.ChartCoordinate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterInsightResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.ClusterInsightResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.ClusterInsightResult>
    {
        internal ClusterInsightResult() { }
        public System.Collections.Generic.IList<Azure.AI.Projects.Evaluation.InsightCluster> Clusters { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.AI.Projects.Evaluation.ChartCoordinate> Coordinates { get { throw null; } }
        public Azure.AI.Projects.Evaluation.InsightSummary Summary { get { throw null; } }
        protected virtual Azure.AI.Projects.Evaluation.ClusterInsightResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Evaluation.ClusterInsightResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.ClusterInsightResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.ClusterInsightResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.ClusterInsightResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.ClusterInsightResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.ClusterInsightResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.ClusterInsightResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.ClusterInsightResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterTokenUsage : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.ClusterTokenUsage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.ClusterTokenUsage>
    {
        internal ClusterTokenUsage() { }
        public int InputTokenUsage { get { throw null; } }
        public int OutputTokenUsage { get { throw null; } }
        public int TotalTokenUsage { get { throw null; } }
        protected virtual Azure.AI.Projects.Evaluation.ClusterTokenUsage JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Evaluation.ClusterTokenUsage PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.ClusterTokenUsage System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.ClusterTokenUsage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.ClusterTokenUsage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.ClusterTokenUsage System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.ClusterTokenUsage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.ClusterTokenUsage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.ClusterTokenUsage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CodeBasedEvaluatorDefinition : Azure.AI.Projects.Evaluation.EvaluatorDefinition, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.CodeBasedEvaluatorDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.CodeBasedEvaluatorDefinition>
    {
        public CodeBasedEvaluatorDefinition() { }
        public CodeBasedEvaluatorDefinition(System.BinaryData initParameters, System.BinaryData dataSchema, System.Collections.Generic.IDictionary<string, Azure.AI.Projects.Evaluation.EvaluatorMetric> metrics, string codeText) { }
        public CodeBasedEvaluatorDefinition(string codeText) { }
        public System.Uri BlobUri { get { throw null; } set { } }
        public string CodeText { get { throw null; } set { } }
        public string EntryPoint { get { throw null; } set { } }
        public string ImageTag { get { throw null; } set { } }
        protected override Azure.AI.Projects.Evaluation.EvaluatorDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Evaluation.EvaluatorDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.CodeBasedEvaluatorDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.CodeBasedEvaluatorDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.CodeBasedEvaluatorDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.CodeBasedEvaluatorDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.CodeBasedEvaluatorDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.CodeBasedEvaluatorDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.CodeBasedEvaluatorDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContinuousEvaluationRuleAction : Azure.AI.Projects.Evaluation.EvaluationRuleAction, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.ContinuousEvaluationRuleAction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.ContinuousEvaluationRuleAction>
    {
        public ContinuousEvaluationRuleAction(string evalId) { }
        public string EvalId { get { throw null; } set { } }
        public int? MaxHourlyRuns { get { throw null; } set { } }
        protected override Azure.AI.Projects.Evaluation.EvaluationRuleAction JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Evaluation.EvaluationRuleAction PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.ContinuousEvaluationRuleAction System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.ContinuousEvaluationRuleAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.ContinuousEvaluationRuleAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.ContinuousEvaluationRuleAction System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.ContinuousEvaluationRuleAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.ContinuousEvaluationRuleAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.ContinuousEvaluationRuleAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CronTrigger : Azure.AI.Projects.Evaluation.ScheduleTrigger, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.CronTrigger>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.CronTrigger>
    {
        public CronTrigger(string expression) { }
        public System.DateTimeOffset? EndTime { get { throw null; } set { } }
        public string Expression { get { throw null; } set { } }
        public System.DateTimeOffset? StartTime { get { throw null; } set { } }
        public string TimeZone { get { throw null; } set { } }
        protected override Azure.AI.Projects.Evaluation.ScheduleTrigger JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Evaluation.ScheduleTrigger PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.CronTrigger System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.CronTrigger>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.CronTrigger>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.CronTrigger System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.CronTrigger>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.CronTrigger>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.CronTrigger>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DailyRecurrenceSchedule : Azure.AI.Projects.Evaluation.RecurrenceSchedule, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.DailyRecurrenceSchedule>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.DailyRecurrenceSchedule>
    {
        public DailyRecurrenceSchedule(System.Collections.Generic.IEnumerable<int> hours) { }
        public System.Collections.Generic.IList<int> Hours { get { throw null; } }
        protected override Azure.AI.Projects.Evaluation.RecurrenceSchedule JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Evaluation.RecurrenceSchedule PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.DailyRecurrenceSchedule System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.DailyRecurrenceSchedule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.DailyRecurrenceSchedule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.DailyRecurrenceSchedule System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.DailyRecurrenceSchedule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.DailyRecurrenceSchedule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.DailyRecurrenceSchedule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EvalResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvalResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvalResult>
    {
        internal EvalResult() { }
        public bool IsPassed { get { throw null; } }
        public string Name { get { throw null; } }
        public float Score { get { throw null; } }
        public string Type { get { throw null; } }
        protected virtual Azure.AI.Projects.Evaluation.EvalResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Evaluation.EvalResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.EvalResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvalResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvalResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.EvalResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvalResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvalResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvalResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EvalRunResultCompareItem : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvalRunResultCompareItem>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvalRunResultCompareItem>
    {
        internal EvalRunResultCompareItem() { }
        public float DeltaEstimate { get { throw null; } }
        public float PValue { get { throw null; } }
        public Azure.AI.Projects.TreatmentEffectType TreatmentEffect { get { throw null; } }
        public string TreatmentRunId { get { throw null; } }
        public Azure.AI.Projects.Evaluation.EvalRunResultSummary TreatmentRunSummary { get { throw null; } }
        protected virtual Azure.AI.Projects.Evaluation.EvalRunResultCompareItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Evaluation.EvalRunResultCompareItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.EvalRunResultCompareItem System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvalRunResultCompareItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvalRunResultCompareItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.EvalRunResultCompareItem System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvalRunResultCompareItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvalRunResultCompareItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvalRunResultCompareItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EvalRunResultComparison : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvalRunResultComparison>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvalRunResultComparison>
    {
        internal EvalRunResultComparison() { }
        public Azure.AI.Projects.Evaluation.EvalRunResultSummary BaselineRunSummary { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Projects.Evaluation.EvalRunResultCompareItem> CompareItems { get { throw null; } }
        public string EvaluatorName { get { throw null; } }
        public string MetricName { get { throw null; } }
        public string TestingCriteria { get { throw null; } }
        protected virtual Azure.AI.Projects.Evaluation.EvalRunResultComparison JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Evaluation.EvalRunResultComparison PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.EvalRunResultComparison System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvalRunResultComparison>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvalRunResultComparison>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.EvalRunResultComparison System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvalRunResultComparison>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvalRunResultComparison>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvalRunResultComparison>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EvalRunResultSummary : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvalRunResultSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvalRunResultSummary>
    {
        internal EvalRunResultSummary() { }
        public float Average { get { throw null; } }
        public string RunId { get { throw null; } }
        public int SampleCount { get { throw null; } }
        public float StandardDeviation { get { throw null; } }
        protected virtual Azure.AI.Projects.Evaluation.EvalRunResultSummary JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Evaluation.EvalRunResultSummary PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.EvalRunResultSummary System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvalRunResultSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvalRunResultSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.EvalRunResultSummary System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvalRunResultSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvalRunResultSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvalRunResultSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EvaluationComparisonInsightRequest : Azure.AI.Projects.Evaluation.InsightRequest, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluationComparisonInsightRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationComparisonInsightRequest>
    {
        public EvaluationComparisonInsightRequest(string evalId, string baselineRunId, System.Collections.Generic.IEnumerable<string> treatmentRunIds) { }
        public string BaselineRunId { get { throw null; } set { } }
        public string EvalId { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> TreatmentRunIds { get { throw null; } }
        protected override Azure.AI.Projects.Evaluation.InsightRequest JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Evaluation.InsightRequest PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.EvaluationComparisonInsightRequest System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluationComparisonInsightRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluationComparisonInsightRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.EvaluationComparisonInsightRequest System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationComparisonInsightRequest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationComparisonInsightRequest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationComparisonInsightRequest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EvaluationComparisonInsightResult : Azure.AI.Projects.Evaluation.InsightResult, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluationComparisonInsightResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationComparisonInsightResult>
    {
        internal EvaluationComparisonInsightResult() { }
        public System.Collections.Generic.IList<Azure.AI.Projects.Evaluation.EvalRunResultComparison> Comparisons { get { throw null; } }
        public string Method { get { throw null; } }
        protected override Azure.AI.Projects.Evaluation.InsightResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Evaluation.InsightResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.EvaluationComparisonInsightResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluationComparisonInsightResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluationComparisonInsightResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.EvaluationComparisonInsightResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationComparisonInsightResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationComparisonInsightResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationComparisonInsightResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EvaluationResultSample : Azure.AI.Projects.Evaluation.InsightSample, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluationResultSample>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationResultSample>
    {
        internal EvaluationResultSample() { }
        public Azure.AI.Projects.Evaluation.EvalResult EvaluationResult { get { throw null; } }
        protected override Azure.AI.Projects.Evaluation.InsightSample JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Evaluation.InsightSample PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.EvaluationResultSample System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluationResultSample>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluationResultSample>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.EvaluationResultSample System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationResultSample>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationResultSample>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationResultSample>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EvaluationRule : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluationRule>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationRule>
    {
        public EvaluationRule(Azure.AI.Projects.Evaluation.EvaluationRuleAction action, Azure.AI.Projects.Evaluation.EvaluationRuleEventType eventType, bool enabled) { }
        public Azure.AI.Projects.Evaluation.EvaluationRuleAction Action { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public bool Enabled { get { throw null; } set { } }
        public Azure.AI.Projects.Evaluation.EvaluationRuleEventType EventType { get { throw null; } set { } }
        public Azure.AI.Projects.Evaluation.EvaluationRuleFilter Filter { get { throw null; } set { } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> SystemData { get { throw null; } }
        protected virtual Azure.AI.Projects.Evaluation.EvaluationRule JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Projects.Evaluation.EvaluationRule (System.ClientModel.ClientResult result) { throw null; }
        public static implicit operator System.ClientModel.BinaryContent (Azure.AI.Projects.Evaluation.EvaluationRule evaluationRule) { throw null; }
        protected virtual Azure.AI.Projects.Evaluation.EvaluationRule PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.EvaluationRule System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluationRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluationRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.EvaluationRule System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class EvaluationRuleAction : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluationRuleAction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationRuleAction>
    {
        internal EvaluationRuleAction() { }
        protected virtual Azure.AI.Projects.Evaluation.EvaluationRuleAction JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Evaluation.EvaluationRuleAction PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.EvaluationRuleAction System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluationRuleAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluationRuleAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.EvaluationRuleAction System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationRuleAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationRuleAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationRuleAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EvaluationRuleEventType : System.IEquatable<Azure.AI.Projects.Evaluation.EvaluationRuleEventType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EvaluationRuleEventType(string value) { throw null; }
        public static Azure.AI.Projects.Evaluation.EvaluationRuleEventType Manual { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.EvaluationRuleEventType ResponseCompleted { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Evaluation.EvaluationRuleEventType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Evaluation.EvaluationRuleEventType left, Azure.AI.Projects.Evaluation.EvaluationRuleEventType right) { throw null; }
        public static implicit operator Azure.AI.Projects.Evaluation.EvaluationRuleEventType (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Evaluation.EvaluationRuleEventType? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Evaluation.EvaluationRuleEventType left, Azure.AI.Projects.Evaluation.EvaluationRuleEventType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EvaluationRuleFilter : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluationRuleFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationRuleFilter>
    {
        public EvaluationRuleFilter(string agentName) { }
        public string AgentName { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Evaluation.EvaluationRuleFilter JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Evaluation.EvaluationRuleFilter PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.EvaluationRuleFilter System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluationRuleFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluationRuleFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.EvaluationRuleFilter System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationRuleFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationRuleFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationRuleFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EvaluationRules
    {
        protected EvaluationRules() { }
        public System.ClientModel.Primitives.ClientPipeline Pipeline { get { throw null; } }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Evaluation.EvaluationRule> CreateOrUpdate(string id, Azure.AI.Projects.Evaluation.EvaluationRule evaluationRule, Azure.AI.Projects.FoundryFeaturesOptInKeys? foundryFeatures = default(Azure.AI.Projects.FoundryFeaturesOptInKeys?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult CreateOrUpdate(string id, System.ClientModel.BinaryContent content, string foundryFeatures = null, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Evaluation.EvaluationRule>> CreateOrUpdateAsync(string id, Azure.AI.Projects.Evaluation.EvaluationRule evaluationRule, Azure.AI.Projects.FoundryFeaturesOptInKeys? foundryFeatures = default(Azure.AI.Projects.FoundryFeaturesOptInKeys?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> CreateOrUpdateAsync(string id, System.ClientModel.BinaryContent content, string foundryFeatures = null, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult Delete(string id, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult Delete(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> DeleteAsync(string id, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> DeleteAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult Get(string id, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Evaluation.EvaluationRule> Get(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Projects.Evaluation.EvaluationRule> GetAll(Azure.AI.Projects.EvaluationRuleActionType? actionType = default(Azure.AI.Projects.EvaluationRuleActionType?), string agentName = null, bool? enabled = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.CollectionResult GetAll(string actionType, string agentName, bool? enabled, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Projects.Evaluation.EvaluationRule> GetAllAsync(Azure.AI.Projects.EvaluationRuleActionType? actionType = default(Azure.AI.Projects.EvaluationRuleActionType?), string agentName = null, bool? enabled = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.AsyncCollectionResult GetAllAsync(string actionType, string agentName, bool? enabled, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> GetAsync(string id, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Evaluation.EvaluationRule>> GetAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EvaluationRunClusterInsightRequest : Azure.AI.Projects.Evaluation.InsightRequest, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluationRunClusterInsightRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationRunClusterInsightRequest>
    {
        public EvaluationRunClusterInsightRequest(string evalId, System.Collections.Generic.IEnumerable<string> runIds) { }
        public string EvalId { get { throw null; } set { } }
        public Azure.AI.Projects.Evaluation.InsightModelConfiguration ModelConfiguration { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> RunIds { get { throw null; } }
        protected override Azure.AI.Projects.Evaluation.InsightRequest JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Evaluation.InsightRequest PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.EvaluationRunClusterInsightRequest System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluationRunClusterInsightRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluationRunClusterInsightRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.EvaluationRunClusterInsightRequest System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationRunClusterInsightRequest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationRunClusterInsightRequest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationRunClusterInsightRequest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EvaluationRunClusterInsightResult : Azure.AI.Projects.Evaluation.InsightResult, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluationRunClusterInsightResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationRunClusterInsightResult>
    {
        internal EvaluationRunClusterInsightResult() { }
        public Azure.AI.Projects.Evaluation.ClusterInsightResult ClusterInsight { get { throw null; } }
        protected override Azure.AI.Projects.Evaluation.InsightResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Evaluation.InsightResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.EvaluationRunClusterInsightResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluationRunClusterInsightResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluationRunClusterInsightResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.EvaluationRunClusterInsightResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationRunClusterInsightResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationRunClusterInsightResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationRunClusterInsightResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EvaluationScheduleTask : Azure.AI.Projects.ProjectsScheduleTask, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluationScheduleTask>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationScheduleTask>
    {
        public EvaluationScheduleTask(string evalId, System.BinaryData evalRun) { }
        public string EvalId { get { throw null; } set { } }
        public System.BinaryData EvalRun { get { throw null; } set { } }
        protected override Azure.AI.Projects.ProjectsScheduleTask JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.ProjectsScheduleTask PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.EvaluationScheduleTask System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluationScheduleTask>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluationScheduleTask>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.EvaluationScheduleTask System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationScheduleTask>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationScheduleTask>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationScheduleTask>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class EvaluationTarget : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluationTarget>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationTarget>
    {
        internal EvaluationTarget() { }
        protected virtual Azure.AI.Projects.Evaluation.EvaluationTarget JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Evaluation.EvaluationTarget PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.EvaluationTarget System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluationTarget>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluationTarget>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.EvaluationTarget System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationTarget>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationTarget>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationTarget>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EvaluationTaxonomies
    {
        protected EvaluationTaxonomies() { }
        public System.ClientModel.Primitives.ClientPipeline Pipeline { get { throw null; } }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Evaluation.EvaluationTaxonomy> Create(string name, Azure.AI.Projects.Evaluation.EvaluationTaxonomy body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult Create(string name, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Evaluation.EvaluationTaxonomy>> CreateAsync(string name, Azure.AI.Projects.Evaluation.EvaluationTaxonomy body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> CreateAsync(string name, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult Delete(string name, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult Delete(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> DeleteAsync(string name, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> DeleteAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult Get(string name, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Evaluation.EvaluationTaxonomy> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.CollectionResult GetAll(string inputName, string inputType, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Projects.Evaluation.EvaluationTaxonomy> GetAll(string inputName = null, string inputType = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.AsyncCollectionResult GetAllAsync(string inputName, string inputType, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Projects.Evaluation.EvaluationTaxonomy> GetAllAsync(string inputName = null, string inputType = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> GetAsync(string name, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Evaluation.EvaluationTaxonomy>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult Update(string name, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> UpdateAsync(string name, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
    }
    public partial class EvaluationTaxonomy : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluationTaxonomy>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationTaxonomy>
    {
        public EvaluationTaxonomy(Azure.AI.Projects.Evaluation.EvaluationTaxonomyInput taxonomyInput) { }
        public string Description { get { throw null; } set { } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Properties { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Projects.Evaluation.TaxonomyCategory> TaxonomyCategories { get { throw null; } }
        public Azure.AI.Projects.Evaluation.EvaluationTaxonomyInput TaxonomyInput { get { throw null; } set { } }
        public string Version { get { throw null; } }
        protected virtual Azure.AI.Projects.Evaluation.EvaluationTaxonomy JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Projects.Evaluation.EvaluationTaxonomy (System.ClientModel.ClientResult result) { throw null; }
        public static implicit operator System.ClientModel.BinaryContent (Azure.AI.Projects.Evaluation.EvaluationTaxonomy evaluationTaxonomy) { throw null; }
        protected virtual Azure.AI.Projects.Evaluation.EvaluationTaxonomy PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.EvaluationTaxonomy System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluationTaxonomy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluationTaxonomy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.EvaluationTaxonomy System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationTaxonomy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationTaxonomy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationTaxonomy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class EvaluationTaxonomyInput : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluationTaxonomyInput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationTaxonomyInput>
    {
        internal EvaluationTaxonomyInput() { }
        protected virtual Azure.AI.Projects.Evaluation.EvaluationTaxonomyInput JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Evaluation.EvaluationTaxonomyInput PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.EvaluationTaxonomyInput System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluationTaxonomyInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluationTaxonomyInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.EvaluationTaxonomyInput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationTaxonomyInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationTaxonomyInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationTaxonomyInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EvaluatorCategory : System.IEquatable<Azure.AI.Projects.Evaluation.EvaluatorCategory>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EvaluatorCategory(string value) { throw null; }
        public static Azure.AI.Projects.Evaluation.EvaluatorCategory Agents { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.EvaluatorCategory Quality { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.EvaluatorCategory Safety { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Evaluation.EvaluatorCategory other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Evaluation.EvaluatorCategory left, Azure.AI.Projects.Evaluation.EvaluatorCategory right) { throw null; }
        public static implicit operator Azure.AI.Projects.Evaluation.EvaluatorCategory (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Evaluation.EvaluatorCategory? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Evaluation.EvaluatorCategory left, Azure.AI.Projects.Evaluation.EvaluatorCategory right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class EvaluatorDefinition : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluatorDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluatorDefinition>
    {
        internal EvaluatorDefinition() { }
        public System.BinaryData DataSchema { get { throw null; } set { } }
        public System.BinaryData InitParameters { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.AI.Projects.Evaluation.EvaluatorMetric> Metrics { get { throw null; } }
        protected virtual Azure.AI.Projects.Evaluation.EvaluatorDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Evaluation.EvaluatorDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.EvaluatorDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluatorDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluatorDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.EvaluatorDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluatorDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluatorDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluatorDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EvaluatorDefinitionType : System.IEquatable<Azure.AI.Projects.Evaluation.EvaluatorDefinitionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EvaluatorDefinitionType(string value) { throw null; }
        public static Azure.AI.Projects.Evaluation.EvaluatorDefinitionType Code { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.EvaluatorDefinitionType OpenaiGraders { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.EvaluatorDefinitionType Prompt { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.EvaluatorDefinitionType PromptAndCode { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.EvaluatorDefinitionType Service { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Evaluation.EvaluatorDefinitionType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Evaluation.EvaluatorDefinitionType left, Azure.AI.Projects.Evaluation.EvaluatorDefinitionType right) { throw null; }
        public static implicit operator Azure.AI.Projects.Evaluation.EvaluatorDefinitionType (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Evaluation.EvaluatorDefinitionType? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Evaluation.EvaluatorDefinitionType left, Azure.AI.Projects.Evaluation.EvaluatorDefinitionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EvaluatorMetric : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluatorMetric>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluatorMetric>
    {
        public EvaluatorMetric() { }
        public Azure.AI.Projects.Evaluation.EvaluatorMetricDirection? DesirableDirection { get { throw null; } set { } }
        public bool? IsPrimary { get { throw null; } set { } }
        public float? MaxValue { get { throw null; } set { } }
        public float? MinValue { get { throw null; } set { } }
        public Azure.AI.Projects.Evaluation.EvaluatorMetricType? Type { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Evaluation.EvaluatorMetric JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Evaluation.EvaluatorMetric PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.EvaluatorMetric System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluatorMetric>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluatorMetric>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.EvaluatorMetric System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluatorMetric>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluatorMetric>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluatorMetric>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EvaluatorMetricDirection : System.IEquatable<Azure.AI.Projects.Evaluation.EvaluatorMetricDirection>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EvaluatorMetricDirection(string value) { throw null; }
        public static Azure.AI.Projects.Evaluation.EvaluatorMetricDirection Decrease { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.EvaluatorMetricDirection Increase { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.EvaluatorMetricDirection Neutral { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Evaluation.EvaluatorMetricDirection other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Evaluation.EvaluatorMetricDirection left, Azure.AI.Projects.Evaluation.EvaluatorMetricDirection right) { throw null; }
        public static implicit operator Azure.AI.Projects.Evaluation.EvaluatorMetricDirection (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Evaluation.EvaluatorMetricDirection? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Evaluation.EvaluatorMetricDirection left, Azure.AI.Projects.Evaluation.EvaluatorMetricDirection right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EvaluatorMetricType : System.IEquatable<Azure.AI.Projects.Evaluation.EvaluatorMetricType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EvaluatorMetricType(string value) { throw null; }
        public static Azure.AI.Projects.Evaluation.EvaluatorMetricType Boolean { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.EvaluatorMetricType Continuous { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.EvaluatorMetricType Ordinal { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Evaluation.EvaluatorMetricType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Evaluation.EvaluatorMetricType left, Azure.AI.Projects.Evaluation.EvaluatorMetricType right) { throw null; }
        public static implicit operator Azure.AI.Projects.Evaluation.EvaluatorMetricType (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Evaluation.EvaluatorMetricType? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Evaluation.EvaluatorMetricType left, Azure.AI.Projects.Evaluation.EvaluatorMetricType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EvaluatorVersion : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluatorVersion>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluatorVersion>
    {
        public EvaluatorVersion(Azure.AI.Projects.EvaluatorType evaluatorType, System.Collections.Generic.IEnumerable<Azure.AI.Projects.Evaluation.EvaluatorCategory> categories, Azure.AI.Projects.Evaluation.EvaluatorDefinition definition) { }
        public System.Collections.Generic.IList<Azure.AI.Projects.Evaluation.EvaluatorCategory> Categories { get { throw null; } }
        public string CreatedAt { get { throw null; } }
        public string CreatedBy { get { throw null; } }
        public Azure.AI.Projects.Evaluation.EvaluatorDefinition Definition { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.AI.Projects.EvaluatorType EvaluatorType { get { throw null; } set { } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public string ModifiedAt { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual Azure.AI.Projects.Evaluation.EvaluatorVersion JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Projects.Evaluation.EvaluatorVersion (System.ClientModel.ClientResult result) { throw null; }
        public static implicit operator System.ClientModel.BinaryContent (Azure.AI.Projects.Evaluation.EvaluatorVersion evaluatorVersion) { throw null; }
        protected virtual Azure.AI.Projects.Evaluation.EvaluatorVersion PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.EvaluatorVersion System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluatorVersion>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluatorVersion>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.EvaluatorVersion System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluatorVersion>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluatorVersion>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluatorVersion>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HourlyRecurrenceSchedule : Azure.AI.Projects.Evaluation.RecurrenceSchedule, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.HourlyRecurrenceSchedule>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.HourlyRecurrenceSchedule>
    {
        public HourlyRecurrenceSchedule() { }
        protected override Azure.AI.Projects.Evaluation.RecurrenceSchedule JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Evaluation.RecurrenceSchedule PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.HourlyRecurrenceSchedule System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.HourlyRecurrenceSchedule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.HourlyRecurrenceSchedule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.HourlyRecurrenceSchedule System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.HourlyRecurrenceSchedule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.HourlyRecurrenceSchedule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.HourlyRecurrenceSchedule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class HumanEvaluationPreviewRuleAction : Azure.AI.Projects.Evaluation.EvaluationRuleAction, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.HumanEvaluationPreviewRuleAction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.HumanEvaluationPreviewRuleAction>
    {
        public HumanEvaluationPreviewRuleAction(string templateId) { }
        public string TemplateId { get { throw null; } set { } }
        protected override Azure.AI.Projects.Evaluation.EvaluationRuleAction JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Evaluation.EvaluationRuleAction PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.HumanEvaluationPreviewRuleAction System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.HumanEvaluationPreviewRuleAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.HumanEvaluationPreviewRuleAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.HumanEvaluationPreviewRuleAction System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.HumanEvaluationPreviewRuleAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.HumanEvaluationPreviewRuleAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.HumanEvaluationPreviewRuleAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InsightCluster : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.InsightCluster>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.InsightCluster>
    {
        internal InsightCluster() { }
        public string Description { get { throw null; } }
        public string Id { get { throw null; } }
        public string Label { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Projects.Evaluation.InsightSample> Samples { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Projects.Evaluation.InsightCluster> SubClusters { get { throw null; } }
        public string Suggestion { get { throw null; } }
        public string SuggestionTitle { get { throw null; } }
        public int Weight { get { throw null; } }
        protected virtual Azure.AI.Projects.Evaluation.InsightCluster JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Evaluation.InsightCluster PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.InsightCluster System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.InsightCluster>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.InsightCluster>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.InsightCluster System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.InsightCluster>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.InsightCluster>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.InsightCluster>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InsightModelConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.InsightModelConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.InsightModelConfiguration>
    {
        public InsightModelConfiguration(string modelDeploymentName) { }
        public string ModelDeploymentName { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Evaluation.InsightModelConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Evaluation.InsightModelConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.InsightModelConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.InsightModelConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.InsightModelConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.InsightModelConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.InsightModelConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.InsightModelConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.InsightModelConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class InsightRequest : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.InsightRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.InsightRequest>
    {
        internal InsightRequest() { }
        protected virtual Azure.AI.Projects.Evaluation.InsightRequest JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Evaluation.InsightRequest PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.InsightRequest System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.InsightRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.InsightRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.InsightRequest System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.InsightRequest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.InsightRequest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.InsightRequest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class InsightResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.InsightResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.InsightResult>
    {
        internal InsightResult() { }
        protected virtual Azure.AI.Projects.Evaluation.InsightResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Evaluation.InsightResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.InsightResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.InsightResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.InsightResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.InsightResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.InsightResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.InsightResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.InsightResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class InsightSample : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.InsightSample>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.InsightSample>
    {
        internal InsightSample() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> CorrelationInfo { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Features { get { throw null; } }
        public string Id { get { throw null; } }
        protected virtual Azure.AI.Projects.Evaluation.InsightSample JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Evaluation.InsightSample PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.InsightSample System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.InsightSample>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.InsightSample>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.InsightSample System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.InsightSample>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.InsightSample>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.InsightSample>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InsightScheduleTask : Azure.AI.Projects.ProjectsScheduleTask, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.InsightScheduleTask>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.InsightScheduleTask>
    {
        public InsightScheduleTask(Azure.AI.Projects.Evaluation.ProjectsInsight insight) { }
        public Azure.AI.Projects.Evaluation.ProjectsInsight Insight { get { throw null; } set { } }
        protected override Azure.AI.Projects.ProjectsScheduleTask JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.ProjectsScheduleTask PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.InsightScheduleTask System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.InsightScheduleTask>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.InsightScheduleTask>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.InsightScheduleTask System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.InsightScheduleTask>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.InsightScheduleTask>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.InsightScheduleTask>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InsightsMetadata : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.InsightsMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.InsightsMetadata>
    {
        internal InsightsMetadata() { }
        public System.DateTimeOffset? CompletedAt { get { throw null; } }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        protected virtual Azure.AI.Projects.Evaluation.InsightsMetadata JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Evaluation.InsightsMetadata PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.InsightsMetadata System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.InsightsMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.InsightsMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.InsightsMetadata System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.InsightsMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.InsightsMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.InsightsMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InsightSummary : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.InsightSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.InsightSummary>
    {
        internal InsightSummary() { }
        public string MethodName { get { throw null; } }
        public int SampleCount { get { throw null; } }
        public int UniqueClusterCount { get { throw null; } }
        public int UniqueSubclusterCount { get { throw null; } }
        public Azure.AI.Projects.Evaluation.ClusterTokenUsage Usage { get { throw null; } }
        protected virtual Azure.AI.Projects.Evaluation.InsightSummary JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Evaluation.InsightSummary PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.InsightSummary System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.InsightSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.InsightSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.InsightSummary System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.InsightSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.InsightSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.InsightSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct InsightType : System.IEquatable<Azure.AI.Projects.Evaluation.InsightType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public InsightType(string value) { throw null; }
        public static Azure.AI.Projects.Evaluation.InsightType AgentClusterInsight { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.InsightType EvaluationComparison { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.InsightType EvaluationRunClusterInsight { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Evaluation.InsightType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Evaluation.InsightType left, Azure.AI.Projects.Evaluation.InsightType right) { throw null; }
        public static implicit operator Azure.AI.Projects.Evaluation.InsightType (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Evaluation.InsightType? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Evaluation.InsightType left, Azure.AI.Projects.Evaluation.InsightType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ListVersionsRequestType : System.IEquatable<Azure.AI.Projects.Evaluation.ListVersionsRequestType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ListVersionsRequestType(string value) { throw null; }
        public static Azure.AI.Projects.Evaluation.ListVersionsRequestType All { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.ListVersionsRequestType BuiltIn { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.ListVersionsRequestType Custom { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Evaluation.ListVersionsRequestType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Evaluation.ListVersionsRequestType left, Azure.AI.Projects.Evaluation.ListVersionsRequestType right) { throw null; }
        public static implicit operator Azure.AI.Projects.Evaluation.ListVersionsRequestType (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Evaluation.ListVersionsRequestType? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Evaluation.ListVersionsRequestType left, Azure.AI.Projects.Evaluation.ListVersionsRequestType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ModelSamplingParams : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.ModelSamplingParams>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.ModelSamplingParams>
    {
        public ModelSamplingParams(float temperature, float topP, int seed, int maxCompletionTokens) { }
        public int MaxCompletionTokens { get { throw null; } set { } }
        public int Seed { get { throw null; } set { } }
        public float Temperature { get { throw null; } set { } }
        public float TopP { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Evaluation.ModelSamplingParams JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Evaluation.ModelSamplingParams PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.ModelSamplingParams System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.ModelSamplingParams>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.ModelSamplingParams>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.ModelSamplingParams System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.ModelSamplingParams>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.ModelSamplingParams>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.ModelSamplingParams>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MonthlyRecurrenceSchedule : Azure.AI.Projects.Evaluation.RecurrenceSchedule, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.MonthlyRecurrenceSchedule>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.MonthlyRecurrenceSchedule>
    {
        public MonthlyRecurrenceSchedule(System.Collections.Generic.IEnumerable<int> daysOfMonth) { }
        public System.Collections.Generic.IList<int> DaysOfMonth { get { throw null; } }
        protected override Azure.AI.Projects.Evaluation.RecurrenceSchedule JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Evaluation.RecurrenceSchedule PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.MonthlyRecurrenceSchedule System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.MonthlyRecurrenceSchedule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.MonthlyRecurrenceSchedule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.MonthlyRecurrenceSchedule System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.MonthlyRecurrenceSchedule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.MonthlyRecurrenceSchedule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.MonthlyRecurrenceSchedule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OneTimeTrigger : Azure.AI.Projects.Evaluation.ScheduleTrigger, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.OneTimeTrigger>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.OneTimeTrigger>
    {
        public OneTimeTrigger(System.DateTimeOffset triggerAt) { }
        public string TimeZone { get { throw null; } set { } }
        public System.DateTimeOffset TriggerAt { get { throw null; } set { } }
        protected override Azure.AI.Projects.Evaluation.ScheduleTrigger JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Evaluation.ScheduleTrigger PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.OneTimeTrigger System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.OneTimeTrigger>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.OneTimeTrigger>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.OneTimeTrigger System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.OneTimeTrigger>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.OneTimeTrigger>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.OneTimeTrigger>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperationStatus : System.IEquatable<Azure.AI.Projects.Evaluation.OperationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperationStatus(string value) { throw null; }
        public static Azure.AI.Projects.Evaluation.OperationStatus Canceled { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.OperationStatus Failed { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.OperationStatus NotStarted { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.OperationStatus Running { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.OperationStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Evaluation.OperationStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Evaluation.OperationStatus left, Azure.AI.Projects.Evaluation.OperationStatus right) { throw null; }
        public static implicit operator Azure.AI.Projects.Evaluation.OperationStatus (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Evaluation.OperationStatus? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Evaluation.OperationStatus left, Azure.AI.Projects.Evaluation.OperationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class ProjectEvaluators
    {
        protected ProjectEvaluators() { }
        public System.ClientModel.Primitives.ClientPipeline Pipeline { get { throw null; } }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Evaluation.EvaluatorVersion> CreateVersion(string name, Azure.AI.Projects.Evaluation.EvaluatorVersion evaluatorVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult CreateVersion(string name, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Evaluation.EvaluatorVersion>> CreateVersionAsync(string name, Azure.AI.Projects.Evaluation.EvaluatorVersion evaluatorVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> CreateVersionAsync(string name, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult DeleteVersion(string name, string version, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult DeleteVersion(string name, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> DeleteVersionAsync(string name, string version, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> DeleteVersionAsync(string name, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.DatasetCredential> GetCredentials(string name, string version, Azure.AI.Projects.EvaluatorCredentialRequest credentialRequest, Azure.AI.Projects.FoundryFeaturesOptInKeys? foundryFeatures = default(Azure.AI.Projects.FoundryFeaturesOptInKeys?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult GetCredentials(string name, string version, System.ClientModel.BinaryContent content, string foundryFeatures = null, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.DatasetCredential>> GetCredentialsAsync(string name, string version, Azure.AI.Projects.EvaluatorCredentialRequest credentialRequest, Azure.AI.Projects.FoundryFeaturesOptInKeys? foundryFeatures = default(Azure.AI.Projects.FoundryFeaturesOptInKeys?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> GetCredentialsAsync(string name, string version, System.ClientModel.BinaryContent content, string foundryFeatures = null, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Projects.Evaluation.EvaluatorVersion> GetLatestVersions(Azure.AI.Projects.Evaluation.ListVersionsRequestType? type = default(Azure.AI.Projects.Evaluation.ListVersionsRequestType?), int? limit = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.CollectionResult GetLatestVersions(string type, int? limit, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Projects.Evaluation.EvaluatorVersion> GetLatestVersionsAsync(Azure.AI.Projects.Evaluation.ListVersionsRequestType? type = default(Azure.AI.Projects.Evaluation.ListVersionsRequestType?), int? limit = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.AsyncCollectionResult GetLatestVersionsAsync(string type, int? limit, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult GetVersion(string name, string version, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Evaluation.EvaluatorVersion> GetVersion(string name, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> GetVersionAsync(string name, string version, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Evaluation.EvaluatorVersion>> GetVersionAsync(string name, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Projects.Evaluation.EvaluatorVersion> GetVersions(string name, Azure.AI.Projects.Evaluation.ListVersionsRequestType? type = default(Azure.AI.Projects.Evaluation.ListVersionsRequestType?), int? limit = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.CollectionResult GetVersions(string name, string type, int? limit, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Projects.Evaluation.EvaluatorVersion> GetVersionsAsync(string name, Azure.AI.Projects.Evaluation.ListVersionsRequestType? type = default(Azure.AI.Projects.Evaluation.ListVersionsRequestType?), int? limit = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.AsyncCollectionResult GetVersionsAsync(string name, string type, int? limit, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.PendingUploadResult> StartPendingUpload(string name, string version, Azure.AI.Projects.PendingUploadConfiguration pendingUploadRequest, Azure.AI.Projects.FoundryFeaturesOptInKeys? foundryFeatures = default(Azure.AI.Projects.FoundryFeaturesOptInKeys?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult StartPendingUpload(string name, string version, System.ClientModel.BinaryContent content, string foundryFeatures = null, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.PendingUploadResult>> StartPendingUploadAsync(string name, string version, Azure.AI.Projects.PendingUploadConfiguration pendingUploadRequest, Azure.AI.Projects.FoundryFeaturesOptInKeys? foundryFeatures = default(Azure.AI.Projects.FoundryFeaturesOptInKeys?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> StartPendingUploadAsync(string name, string version, System.ClientModel.BinaryContent content, string foundryFeatures = null, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult UpdateVersion(string name, string version, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> UpdateVersionAsync(string name, string version, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
    }
    public partial class ProjectInsight
    {
        public ProjectInsight() { }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class ProjectInsights
    {
        protected ProjectInsights() { }
        public System.ClientModel.Primitives.ClientPipeline Pipeline { get { throw null; } }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Evaluation.ProjectsInsight> Generate(Azure.AI.Projects.Evaluation.ProjectsInsight insight, Azure.AI.Projects.FoundryFeaturesOptInKeys? foundryFeatures = default(Azure.AI.Projects.FoundryFeaturesOptInKeys?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult Generate(System.ClientModel.BinaryContent content, string foundryFeatures = null, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Evaluation.ProjectsInsight>> GenerateAsync(Azure.AI.Projects.Evaluation.ProjectsInsight insight, Azure.AI.Projects.FoundryFeaturesOptInKeys? foundryFeatures = default(Azure.AI.Projects.FoundryFeaturesOptInKeys?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> GenerateAsync(System.ClientModel.BinaryContent content, string foundryFeatures = null, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Evaluation.ProjectsInsight> Get(string id, Azure.AI.Projects.FoundryFeaturesOptInKeys? foundryFeatures = default(Azure.AI.Projects.FoundryFeaturesOptInKeys?), bool? includeCoordinates = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult Get(string id, string foundryFeatures, bool? includeCoordinates, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Projects.Evaluation.ProjectsInsight> GetAll(Azure.AI.Projects.FoundryFeaturesOptInKeys? foundryFeatures = default(Azure.AI.Projects.FoundryFeaturesOptInKeys?), Azure.AI.Projects.Evaluation.InsightType? type = default(Azure.AI.Projects.Evaluation.InsightType?), string evalId = null, string runId = null, string agentName = null, bool? includeCoordinates = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.CollectionResult GetAll(string foundryFeatures, string type, string evalId, string runId, string agentName, bool? includeCoordinates, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Projects.Evaluation.ProjectsInsight> GetAllAsync(Azure.AI.Projects.FoundryFeaturesOptInKeys? foundryFeatures = default(Azure.AI.Projects.FoundryFeaturesOptInKeys?), Azure.AI.Projects.Evaluation.InsightType? type = default(Azure.AI.Projects.Evaluation.InsightType?), string evalId = null, string runId = null, string agentName = null, bool? includeCoordinates = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.AsyncCollectionResult GetAllAsync(string foundryFeatures, string type, string evalId, string runId, string agentName, bool? includeCoordinates, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Evaluation.ProjectsInsight>> GetAsync(string id, Azure.AI.Projects.FoundryFeaturesOptInKeys? foundryFeatures = default(Azure.AI.Projects.FoundryFeaturesOptInKeys?), bool? includeCoordinates = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> GetAsync(string id, string foundryFeatures, bool? includeCoordinates, System.ClientModel.Primitives.RequestOptions options) { throw null; }
    }
    public partial class ProjectsInsight : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.ProjectsInsight>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.ProjectsInsight>
    {
        public ProjectsInsight(string displayName, Azure.AI.Projects.Evaluation.InsightRequest request) { }
        public string DisplayName { get { throw null; } set { } }
        public string Id { get { throw null; } }
        public Azure.AI.Projects.Evaluation.InsightsMetadata Metadata { get { throw null; } }
        public Azure.AI.Projects.Evaluation.InsightRequest Request { get { throw null; } set { } }
        public Azure.AI.Projects.Evaluation.InsightResult Result { get { throw null; } }
        public Azure.AI.Projects.Evaluation.OperationStatus State { get { throw null; } }
        protected virtual Azure.AI.Projects.Evaluation.ProjectsInsight JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Projects.Evaluation.ProjectsInsight (System.ClientModel.ClientResult result) { throw null; }
        public static implicit operator System.ClientModel.BinaryContent (Azure.AI.Projects.Evaluation.ProjectsInsight projectsInsight) { throw null; }
        protected virtual Azure.AI.Projects.Evaluation.ProjectsInsight PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.ProjectsInsight System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.ProjectsInsight>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.ProjectsInsight>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.ProjectsInsight System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.ProjectsInsight>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.ProjectsInsight>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.ProjectsInsight>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProjectsSchedule : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.ProjectsSchedule>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.ProjectsSchedule>
    {
        public ProjectsSchedule(bool enabled, Azure.AI.Projects.Evaluation.ScheduleTrigger trigger, Azure.AI.Projects.ProjectsScheduleTask task) { }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public bool Enabled { get { throw null; } set { } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Properties { get { throw null; } }
        public Azure.AI.Projects.Evaluation.ScheduleProvisioningStatus? ProvisioningStatus { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> SystemData { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public Azure.AI.Projects.ProjectsScheduleTask Task { get { throw null; } set { } }
        public Azure.AI.Projects.Evaluation.ScheduleTrigger Trigger { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Evaluation.ProjectsSchedule JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Projects.Evaluation.ProjectsSchedule (System.ClientModel.ClientResult result) { throw null; }
        public static implicit operator System.ClientModel.BinaryContent (Azure.AI.Projects.Evaluation.ProjectsSchedule projectsSchedule) { throw null; }
        protected virtual Azure.AI.Projects.Evaluation.ProjectsSchedule PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.ProjectsSchedule System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.ProjectsSchedule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.ProjectsSchedule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.ProjectsSchedule System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.ProjectsSchedule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.ProjectsSchedule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.ProjectsSchedule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PromptBasedEvaluatorDefinition : Azure.AI.Projects.Evaluation.EvaluatorDefinition, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.PromptBasedEvaluatorDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.PromptBasedEvaluatorDefinition>
    {
        public PromptBasedEvaluatorDefinition(System.BinaryData initParameters, System.BinaryData dataSchema, System.Collections.Generic.IDictionary<string, Azure.AI.Projects.Evaluation.EvaluatorMetric> metrics, string promptText) { }
        public PromptBasedEvaluatorDefinition(string promptText) { }
        public string PromptText { get { throw null; } set { } }
        protected override Azure.AI.Projects.Evaluation.EvaluatorDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Evaluation.EvaluatorDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.PromptBasedEvaluatorDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.PromptBasedEvaluatorDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.PromptBasedEvaluatorDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.PromptBasedEvaluatorDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.PromptBasedEvaluatorDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.PromptBasedEvaluatorDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.PromptBasedEvaluatorDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class RecurrenceSchedule : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.RecurrenceSchedule>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.RecurrenceSchedule>
    {
        internal RecurrenceSchedule() { }
        protected virtual Azure.AI.Projects.Evaluation.RecurrenceSchedule JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Evaluation.RecurrenceSchedule PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.RecurrenceSchedule System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.RecurrenceSchedule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.RecurrenceSchedule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.RecurrenceSchedule System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.RecurrenceSchedule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.RecurrenceSchedule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.RecurrenceSchedule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RecurrenceTrigger : Azure.AI.Projects.Evaluation.ScheduleTrigger, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.RecurrenceTrigger>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.RecurrenceTrigger>
    {
        public RecurrenceTrigger(int interval, Azure.AI.Projects.Evaluation.RecurrenceSchedule schedule) { }
        public System.DateTimeOffset? EndTime { get { throw null; } set { } }
        public int Interval { get { throw null; } set { } }
        public Azure.AI.Projects.Evaluation.RecurrenceSchedule Schedule { get { throw null; } set { } }
        public System.DateTimeOffset? StartTime { get { throw null; } set { } }
        public string TimeZone { get { throw null; } set { } }
        protected override Azure.AI.Projects.Evaluation.ScheduleTrigger JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Evaluation.ScheduleTrigger PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.RecurrenceTrigger System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.RecurrenceTrigger>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.RecurrenceTrigger>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.RecurrenceTrigger System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.RecurrenceTrigger>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.RecurrenceTrigger>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.RecurrenceTrigger>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RedTeam : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.RedTeam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.RedTeam>
    {
        public RedTeam(Azure.AI.Projects.Evaluation.TargetConfig target) { }
        public string ApplicationScenario { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Projects.Evaluation.AttackStrategy> AttackStrategies { get { throw null; } }
        public string DisplayName { get { throw null; } set { } }
        public bool? IsSimulationOnly { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Properties { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Projects.Evaluation.RiskCategory> RiskCategories { get { throw null; } }
        public string Status { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public Azure.AI.Projects.Evaluation.TargetConfig Target { get { throw null; } set { } }
        public int? TurnCount { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Evaluation.RedTeam JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Projects.Evaluation.RedTeam (System.ClientModel.ClientResult result) { throw null; }
        public static implicit operator System.ClientModel.BinaryContent (Azure.AI.Projects.Evaluation.RedTeam redTeam) { throw null; }
        protected virtual Azure.AI.Projects.Evaluation.RedTeam PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.RedTeam System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.RedTeam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.RedTeam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.RedTeam System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.RedTeam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.RedTeam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.RedTeam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class RedTeams
    {
        protected RedTeams() { }
        public System.ClientModel.Primitives.ClientPipeline Pipeline { get { throw null; } }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Evaluation.RedTeam> Create(Azure.AI.Projects.Evaluation.RedTeam redTeam, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Evaluation.RedTeam> Create(Azure.AI.Projects.Evaluation.RedTeam redTeam, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult Create(System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Evaluation.RedTeam>> CreateAsync(Azure.AI.Projects.Evaluation.RedTeam redTeam, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Evaluation.RedTeam>> CreateAsync(Azure.AI.Projects.Evaluation.RedTeam redTeam, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> CreateAsync(System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult Get(string name, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Evaluation.RedTeam> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.CollectionResult GetAll(System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Projects.Evaluation.RedTeam> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.AsyncCollectionResult GetAllAsync(System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Projects.Evaluation.RedTeam> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> GetAsync(string name, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Evaluation.RedTeam>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RiskCategory : System.IEquatable<Azure.AI.Projects.Evaluation.RiskCategory>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RiskCategory(string value) { throw null; }
        public static Azure.AI.Projects.Evaluation.RiskCategory CodeVulnerability { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.RiskCategory HateUnfairness { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.RiskCategory ProhibitedActions { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.RiskCategory ProtectedMaterial { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.RiskCategory SelfHarm { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.RiskCategory SensitiveDataLeakage { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.RiskCategory Sexual { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.RiskCategory TaskAdherence { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.RiskCategory UngroundedAttributes { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.RiskCategory Violence { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Evaluation.RiskCategory other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Evaluation.RiskCategory left, Azure.AI.Projects.Evaluation.RiskCategory right) { throw null; }
        public static implicit operator Azure.AI.Projects.Evaluation.RiskCategory (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Evaluation.RiskCategory? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Evaluation.RiskCategory left, Azure.AI.Projects.Evaluation.RiskCategory right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScheduleProvisioningStatus : System.IEquatable<Azure.AI.Projects.Evaluation.ScheduleProvisioningStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScheduleProvisioningStatus(string value) { throw null; }
        public static Azure.AI.Projects.Evaluation.ScheduleProvisioningStatus Creating { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.ScheduleProvisioningStatus Deleting { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.ScheduleProvisioningStatus Failed { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.ScheduleProvisioningStatus Succeeded { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.ScheduleProvisioningStatus Updating { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Evaluation.ScheduleProvisioningStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Evaluation.ScheduleProvisioningStatus left, Azure.AI.Projects.Evaluation.ScheduleProvisioningStatus right) { throw null; }
        public static implicit operator Azure.AI.Projects.Evaluation.ScheduleProvisioningStatus (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Evaluation.ScheduleProvisioningStatus? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Evaluation.ScheduleProvisioningStatus left, Azure.AI.Projects.Evaluation.ScheduleProvisioningStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ScheduleRun : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.ScheduleRun>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.ScheduleRun>
    {
        internal ScheduleRun() { }
        public string Error { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Properties { get { throw null; } }
        public string RunId { get { throw null; } }
        public string ScheduleId { get { throw null; } }
        public bool Success { get { throw null; } }
        public System.DateTimeOffset? TriggerTime { get { throw null; } }
        protected virtual Azure.AI.Projects.Evaluation.ScheduleRun JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Projects.Evaluation.ScheduleRun (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.Projects.Evaluation.ScheduleRun PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.ScheduleRun System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.ScheduleRun>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.ScheduleRun>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.ScheduleRun System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.ScheduleRun>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.ScheduleRun>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.ScheduleRun>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScheduleTaskType : System.IEquatable<Azure.AI.Projects.Evaluation.ScheduleTaskType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScheduleTaskType(string value) { throw null; }
        public static Azure.AI.Projects.Evaluation.ScheduleTaskType Evaluation { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.ScheduleTaskType Insight { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Evaluation.ScheduleTaskType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Evaluation.ScheduleTaskType left, Azure.AI.Projects.Evaluation.ScheduleTaskType right) { throw null; }
        public static implicit operator Azure.AI.Projects.Evaluation.ScheduleTaskType (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Evaluation.ScheduleTaskType? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Evaluation.ScheduleTaskType left, Azure.AI.Projects.Evaluation.ScheduleTaskType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class ScheduleTrigger : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.ScheduleTrigger>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.ScheduleTrigger>
    {
        internal ScheduleTrigger() { }
        protected virtual Azure.AI.Projects.Evaluation.ScheduleTrigger JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Evaluation.ScheduleTrigger PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.ScheduleTrigger System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.ScheduleTrigger>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.ScheduleTrigger>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.ScheduleTrigger System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.ScheduleTrigger>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.ScheduleTrigger>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.ScheduleTrigger>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class TargetConfig : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.TargetConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.TargetConfig>
    {
        internal TargetConfig() { }
        protected virtual Azure.AI.Projects.Evaluation.TargetConfig JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Evaluation.TargetConfig PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.TargetConfig System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.TargetConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.TargetConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.TargetConfig System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.TargetConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.TargetConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.TargetConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TaxonomyCategory : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.TaxonomyCategory>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.TaxonomyCategory>
    {
        public TaxonomyCategory(string id, string name, Azure.AI.Projects.Evaluation.RiskCategory riskCategory, System.Collections.Generic.IEnumerable<Azure.AI.Projects.Evaluation.TaxonomySubCategory> subCategories) { }
        public string Description { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Properties { get { throw null; } }
        public Azure.AI.Projects.Evaluation.RiskCategory RiskCategory { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Projects.Evaluation.TaxonomySubCategory> SubCategories { get { throw null; } }
        protected virtual Azure.AI.Projects.Evaluation.TaxonomyCategory JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Evaluation.TaxonomyCategory PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.TaxonomyCategory System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.TaxonomyCategory>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.TaxonomyCategory>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.TaxonomyCategory System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.TaxonomyCategory>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.TaxonomyCategory>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.TaxonomyCategory>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TaxonomySubCategory : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.TaxonomySubCategory>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.TaxonomySubCategory>
    {
        public TaxonomySubCategory(string id, string name, bool isEnabled) { }
        public string Description { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        public bool IsEnabled { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Properties { get { throw null; } }
        protected virtual Azure.AI.Projects.Evaluation.TaxonomySubCategory JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Evaluation.TaxonomySubCategory PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.TaxonomySubCategory System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.TaxonomySubCategory>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.TaxonomySubCategory>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.TaxonomySubCategory System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.TaxonomySubCategory>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.TaxonomySubCategory>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.TaxonomySubCategory>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WeeklyRecurrenceSchedule : Azure.AI.Projects.Evaluation.RecurrenceSchedule, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.WeeklyRecurrenceSchedule>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.WeeklyRecurrenceSchedule>
    {
        public WeeklyRecurrenceSchedule(System.Collections.Generic.IEnumerable<System.DayOfWeek> daysOfWeek) { }
        public System.Collections.Generic.IList<System.DayOfWeek> DaysOfWeek { get { throw null; } }
        protected override Azure.AI.Projects.Evaluation.RecurrenceSchedule JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Evaluation.RecurrenceSchedule PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.WeeklyRecurrenceSchedule System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.WeeklyRecurrenceSchedule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.WeeklyRecurrenceSchedule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.WeeklyRecurrenceSchedule System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.WeeklyRecurrenceSchedule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.WeeklyRecurrenceSchedule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.WeeklyRecurrenceSchedule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Azure.AI.Projects.Memory
{
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class AIProjectMemoryStores
    {
        protected AIProjectMemoryStores() { }
        public System.ClientModel.Primitives.ClientPipeline Pipeline { get { throw null; } }
        public virtual System.ClientModel.ClientResult CreateMemoryStore(System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Memory.MemoryStore> CreateMemoryStore(string name, Azure.AI.Projects.Memory.MemoryStoreDefinition definition, string description = null, System.Collections.Generic.IDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> CreateMemoryStoreAsync(System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Memory.MemoryStore>> CreateMemoryStoreAsync(string name, Azure.AI.Projects.Memory.MemoryStoreDefinition definition, string description = null, System.Collections.Generic.IDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult DeleteMemoryStore(string name, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Memory.DeleteMemoryStoreResponse> DeleteMemoryStore(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> DeleteMemoryStoreAsync(string name, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Memory.DeleteMemoryStoreResponse>> DeleteMemoryStoreAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult DeleteScope(string name, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Memory.MemoryStoreDeleteScopeResponse> DeleteScope(string name, string scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> DeleteScopeAsync(string name, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Memory.MemoryStoreDeleteScopeResponse>> DeleteScopeAsync(string name, string scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult GetMemoryStore(string name, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Memory.MemoryStore> GetMemoryStore(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> GetMemoryStoreAsync(string name, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Memory.MemoryStore>> GetMemoryStoreAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Projects.Memory.MemoryStore> GetMemoryStores(int? limit = default(int?), Azure.AI.Projects.Memory.MemoryStoreListOrder? order = default(Azure.AI.Projects.Memory.MemoryStoreListOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Projects.Memory.MemoryStore> GetMemoryStoresAsync(int? limit = default(int?), Azure.AI.Projects.Memory.MemoryStoreListOrder? order = default(Azure.AI.Projects.Memory.MemoryStoreListOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult GetUpdateResult(string name, string updateId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Memory.MemoryUpdateResult> GetUpdateResult(string name, string updateId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> GetUpdateResultAsync(string name, string updateId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Memory.MemoryUpdateResult>> GetUpdateResultAsync(string name, string updateId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Memory.MemoryStoreSearchResponse> SearchMemories(string memoryStoreName, Azure.AI.Projects.Memory.MemorySearchOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult SearchMemories(string name, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Memory.MemoryStoreSearchResponse>> SearchMemoriesAsync(string memoryStoreName, Azure.AI.Projects.Memory.MemorySearchOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> SearchMemoriesAsync(string name, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Memory.MemoryUpdateResult> UpdateMemories(string memoryStoreName, Azure.AI.Projects.Memory.MemoryUpdateOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult UpdateMemories(string name, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Memory.MemoryUpdateResult>> UpdateMemoriesAsync(string memoryStoreName, Azure.AI.Projects.Memory.MemoryUpdateOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> UpdateMemoriesAsync(string name, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult UpdateMemoryStore(string name, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Memory.MemoryStore> UpdateMemoryStore(string name, string description = null, System.Collections.Generic.IDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> UpdateMemoryStoreAsync(string name, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Memory.MemoryStore>> UpdateMemoryStoreAsync(string name, string description = null, System.Collections.Generic.IDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.Projects.Memory.MemoryUpdateResult WaitForMemoriesUpdate(string memoryStoreName, int pollingInterval, Azure.AI.Projects.Memory.MemoryUpdateOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.Projects.Memory.MemoryUpdateResult> WaitForMemoriesUpdateAsync(string memoryStoreName, int pollingInterval, Azure.AI.Projects.Memory.MemoryUpdateOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ChatSummaryMemoryItem : Azure.AI.Projects.Memory.MemoryItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.ChatSummaryMemoryItem>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.ChatSummaryMemoryItem>
    {
        internal ChatSummaryMemoryItem() { }
        protected override Azure.AI.Projects.Memory.MemoryItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Memory.MemoryItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Memory.ChatSummaryMemoryItem System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.ChatSummaryMemoryItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.ChatSummaryMemoryItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Memory.ChatSummaryMemoryItem System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.ChatSummaryMemoryItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.ChatSummaryMemoryItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.ChatSummaryMemoryItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeleteMemoryStoreResponse : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.DeleteMemoryStoreResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.DeleteMemoryStoreResponse>
    {
        internal DeleteMemoryStoreResponse() { }
        public bool IsDeleted { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.AI.Projects.Memory.MemoryStoreObjectType Object { get { throw null; } }
        protected virtual Azure.AI.Projects.Memory.DeleteMemoryStoreResponse JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Projects.Memory.DeleteMemoryStoreResponse (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.Projects.Memory.DeleteMemoryStoreResponse PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Memory.DeleteMemoryStoreResponse System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.DeleteMemoryStoreResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.DeleteMemoryStoreResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Memory.DeleteMemoryStoreResponse System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.DeleteMemoryStoreResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.DeleteMemoryStoreResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.DeleteMemoryStoreResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class MemoryItem : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.MemoryItem>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemoryItem>
    {
        internal MemoryItem() { }
        public string Content { get { throw null; } }
        public string MemoryId { get { throw null; } }
        public string Scope { get { throw null; } }
        public System.DateTimeOffset UpdatedAt { get { throw null; } }
        protected virtual Azure.AI.Projects.Memory.MemoryItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Memory.MemoryItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Memory.MemoryItem System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.MemoryItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.MemoryItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Memory.MemoryItem System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemoryItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemoryItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemoryItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MemoryOperation : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.MemoryOperation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemoryOperation>
    {
        internal MemoryOperation() { }
        public Azure.AI.Projects.Memory.MemoryOperationKind Kind { get { throw null; } }
        public Azure.AI.Projects.Memory.MemoryItem MemoryItem { get { throw null; } }
        protected virtual Azure.AI.Projects.Memory.MemoryOperation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Memory.MemoryOperation PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Memory.MemoryOperation System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.MemoryOperation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.MemoryOperation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Memory.MemoryOperation System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemoryOperation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemoryOperation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemoryOperation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MemoryOperationKind : System.IEquatable<Azure.AI.Projects.Memory.MemoryOperationKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MemoryOperationKind(string value) { throw null; }
        public static Azure.AI.Projects.Memory.MemoryOperationKind Create { get { throw null; } }
        public static Azure.AI.Projects.Memory.MemoryOperationKind Delete { get { throw null; } }
        public static Azure.AI.Projects.Memory.MemoryOperationKind Update { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Memory.MemoryOperationKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Memory.MemoryOperationKind left, Azure.AI.Projects.Memory.MemoryOperationKind right) { throw null; }
        public static implicit operator Azure.AI.Projects.Memory.MemoryOperationKind (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Memory.MemoryOperationKind? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Memory.MemoryOperationKind left, Azure.AI.Projects.Memory.MemoryOperationKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MemorySearchItem : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.MemorySearchItem>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemorySearchItem>
    {
        internal MemorySearchItem() { }
        public Azure.AI.Projects.Memory.MemoryItem MemoryItem { get { throw null; } }
        protected virtual Azure.AI.Projects.Memory.MemorySearchItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Memory.MemorySearchItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Memory.MemorySearchItem System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.MemorySearchItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.MemorySearchItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Memory.MemorySearchItem System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemorySearchItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemorySearchItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemorySearchItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MemorySearchOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.MemorySearchOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemorySearchOptions>
    {
        public MemorySearchOptions(string scope) { }
        public System.Collections.Generic.IList<OpenAI.Responses.ResponseItem> Items { get { throw null; } }
        public string PreviousSearchId { get { throw null; } set { } }
        public Azure.AI.Projects.Memory.MemorySearchResultOptions ResultOptions { get { throw null; } set { } }
        public string Scope { get { throw null; } }
        Azure.AI.Projects.Memory.MemorySearchOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.MemorySearchOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.MemorySearchOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Memory.MemorySearchOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemorySearchOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemorySearchOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemorySearchOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MemorySearchResultOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.MemorySearchResultOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemorySearchResultOptions>
    {
        public MemorySearchResultOptions() { }
        public int? MaxMemories { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Memory.MemorySearchResultOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Memory.MemorySearchResultOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Memory.MemorySearchResultOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.MemorySearchResultOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.MemorySearchResultOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Memory.MemorySearchResultOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemorySearchResultOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemorySearchResultOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemorySearchResultOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MemoryStore : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.MemoryStore>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemoryStore>
    {
        internal MemoryStore() { }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public Azure.AI.Projects.Memory.MemoryStoreDefinition Definition { get { throw null; } }
        public string Description { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public string Name { get { throw null; } }
        public System.DateTimeOffset UpdatedAt { get { throw null; } }
        protected virtual Azure.AI.Projects.Memory.MemoryStore JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Projects.Memory.MemoryStore (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.Projects.Memory.MemoryStore PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Memory.MemoryStore System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.MemoryStore>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.MemoryStore>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Memory.MemoryStore System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemoryStore>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemoryStore>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemoryStore>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MemoryStoreDefaultDefinition : Azure.AI.Projects.Memory.MemoryStoreDefinition, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.MemoryStoreDefaultDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemoryStoreDefaultDefinition>
    {
        public MemoryStoreDefaultDefinition(string chatModel, string embeddingModel) { }
        public string ChatModel { get { throw null; } set { } }
        public string EmbeddingModel { get { throw null; } set { } }
        public Azure.AI.Projects.Memory.MemoryStoreDefaultOptions Options { get { throw null; } set { } }
        protected override Azure.AI.Projects.Memory.MemoryStoreDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Memory.MemoryStoreDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Memory.MemoryStoreDefaultDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.MemoryStoreDefaultDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.MemoryStoreDefaultDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Memory.MemoryStoreDefaultDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemoryStoreDefaultDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemoryStoreDefaultDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemoryStoreDefaultDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MemoryStoreDefaultOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.MemoryStoreDefaultOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemoryStoreDefaultOptions>
    {
        public MemoryStoreDefaultOptions(bool isUserProfileEnabled, bool isChatSummaryEnabled) { }
        public bool IsChatSummaryEnabled { get { throw null; } set { } }
        public bool IsUserProfileEnabled { get { throw null; } set { } }
        public string UserProfileDetails { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Memory.MemoryStoreDefaultOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Memory.MemoryStoreDefaultOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Memory.MemoryStoreDefaultOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.MemoryStoreDefaultOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.MemoryStoreDefaultOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Memory.MemoryStoreDefaultOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemoryStoreDefaultOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemoryStoreDefaultOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemoryStoreDefaultOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class MemoryStoreDefinition : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.MemoryStoreDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemoryStoreDefinition>
    {
        internal MemoryStoreDefinition() { }
        protected virtual Azure.AI.Projects.Memory.MemoryStoreDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Memory.MemoryStoreDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Memory.MemoryStoreDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.MemoryStoreDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.MemoryStoreDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Memory.MemoryStoreDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemoryStoreDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemoryStoreDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemoryStoreDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MemoryStoreDeleteScopeResponse : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.MemoryStoreDeleteScopeResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemoryStoreDeleteScopeResponse>
    {
        internal MemoryStoreDeleteScopeResponse() { }
        public bool IsDeleted { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.AI.Projects.Memory.MemoryStoreObjectType Object { get { throw null; } }
        public string Scope { get { throw null; } }
        protected virtual Azure.AI.Projects.Memory.MemoryStoreDeleteScopeResponse JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Projects.Memory.MemoryStoreDeleteScopeResponse (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.Projects.Memory.MemoryStoreDeleteScopeResponse PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Memory.MemoryStoreDeleteScopeResponse System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.MemoryStoreDeleteScopeResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.MemoryStoreDeleteScopeResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Memory.MemoryStoreDeleteScopeResponse System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemoryStoreDeleteScopeResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemoryStoreDeleteScopeResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemoryStoreDeleteScopeResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MemoryStoreListOrder : System.IEquatable<Azure.AI.Projects.Memory.MemoryStoreListOrder>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MemoryStoreListOrder(string value) { throw null; }
        public static Azure.AI.Projects.Memory.MemoryStoreListOrder Ascending { get { throw null; } }
        public static Azure.AI.Projects.Memory.MemoryStoreListOrder Descending { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Memory.MemoryStoreListOrder other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Memory.MemoryStoreListOrder left, Azure.AI.Projects.Memory.MemoryStoreListOrder right) { throw null; }
        public static implicit operator Azure.AI.Projects.Memory.MemoryStoreListOrder (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Memory.MemoryStoreListOrder? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Memory.MemoryStoreListOrder left, Azure.AI.Projects.Memory.MemoryStoreListOrder right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MemoryStoreObjectType : System.IEquatable<Azure.AI.Projects.Memory.MemoryStoreObjectType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MemoryStoreObjectType(string value) { throw null; }
        public static Azure.AI.Projects.Memory.MemoryStoreObjectType MemoryStore { get { throw null; } }
        public static Azure.AI.Projects.Memory.MemoryStoreObjectType MemoryStoreDeleted { get { throw null; } }
        public static Azure.AI.Projects.Memory.MemoryStoreObjectType MemoryStoreScopeDeleted { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Memory.MemoryStoreObjectType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Memory.MemoryStoreObjectType left, Azure.AI.Projects.Memory.MemoryStoreObjectType right) { throw null; }
        public static implicit operator Azure.AI.Projects.Memory.MemoryStoreObjectType (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Memory.MemoryStoreObjectType? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Memory.MemoryStoreObjectType left, Azure.AI.Projects.Memory.MemoryStoreObjectType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MemoryStoreOperationUsage : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.MemoryStoreOperationUsage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemoryStoreOperationUsage>
    {
        internal MemoryStoreOperationUsage() { }
        public int EmbeddingTokens { get { throw null; } }
        public long InputTokens { get { throw null; } }
        public Azure.AI.Projects.ResponseUsageInputTokensDetails InputTokensDetails { get { throw null; } }
        public long OutputTokens { get { throw null; } }
        public Azure.AI.Projects.ResponseUsageOutputTokensDetails OutputTokensDetails { get { throw null; } }
        public long TotalTokens { get { throw null; } }
        protected virtual Azure.AI.Projects.Memory.MemoryStoreOperationUsage JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Memory.MemoryStoreOperationUsage PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Memory.MemoryStoreOperationUsage System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.MemoryStoreOperationUsage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.MemoryStoreOperationUsage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Memory.MemoryStoreOperationUsage System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemoryStoreOperationUsage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemoryStoreOperationUsage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemoryStoreOperationUsage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MemoryStoreOperationUsageInputTokensDetails
    {
        public MemoryStoreOperationUsageInputTokensDetails() { }
    }
    public partial class MemoryStoreOperationUsageOutputTokensDetails
    {
        public MemoryStoreOperationUsageOutputTokensDetails() { }
    }
    public partial class MemoryStoreSearchResponse : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.MemoryStoreSearchResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemoryStoreSearchResponse>
    {
        internal MemoryStoreSearchResponse() { }
        public System.Collections.Generic.IList<Azure.AI.Projects.Memory.MemorySearchItem> Memories { get { throw null; } }
        public string SearchId { get { throw null; } }
        public Azure.AI.Projects.Memory.MemoryStoreOperationUsage Usage { get { throw null; } }
        protected virtual Azure.AI.Projects.Memory.MemoryStoreSearchResponse JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Projects.Memory.MemoryStoreSearchResponse (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.Projects.Memory.MemoryStoreSearchResponse PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Memory.MemoryStoreSearchResponse System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.MemoryStoreSearchResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.MemoryStoreSearchResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Memory.MemoryStoreSearchResponse System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemoryStoreSearchResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemoryStoreSearchResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemoryStoreSearchResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum MemoryStoreUpdateStatus
    {
        Queued = 0,
        InProgress = 1,
        Completed = 2,
        Failed = 3,
        Superseded = 4,
    }
    public partial class MemoryUpdateOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.MemoryUpdateOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemoryUpdateOptions>
    {
        public MemoryUpdateOptions(string scope) { }
        public System.Collections.Generic.IList<OpenAI.Responses.ResponseItem> Items { get { throw null; } }
        public string PreviousUpdateId { get { throw null; } set { } }
        public string Scope { get { throw null; } }
        public int? UpdateDelay { get { throw null; } set { } }
        Azure.AI.Projects.Memory.MemoryUpdateOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.MemoryUpdateOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.MemoryUpdateOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Memory.MemoryUpdateOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemoryUpdateOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemoryUpdateOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemoryUpdateOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MemoryUpdateResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.MemoryUpdateResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemoryUpdateResult>
    {
        internal MemoryUpdateResult() { }
        public Azure.AI.Projects.Memory.MemoryUpdateResultDetails Details { get { throw null; } }
        public string ErrorDetails { get { throw null; } }
        public Azure.AI.Projects.Memory.MemoryStoreUpdateStatus Status { get { throw null; } }
        public string SupersededBy { get { throw null; } }
        public string UpdateId { get { throw null; } }
        protected virtual Azure.AI.Projects.Memory.MemoryUpdateResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Projects.Memory.MemoryUpdateResult (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.Projects.Memory.MemoryUpdateResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Memory.MemoryUpdateResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.MemoryUpdateResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.MemoryUpdateResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Memory.MemoryUpdateResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemoryUpdateResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemoryUpdateResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemoryUpdateResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MemoryUpdateResultDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.MemoryUpdateResultDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemoryUpdateResultDetails>
    {
        internal MemoryUpdateResultDetails() { }
        public System.Collections.Generic.IList<Azure.AI.Projects.Memory.MemoryOperation> MemoryOperations { get { throw null; } }
        public Azure.AI.Projects.Memory.MemoryStoreOperationUsage Usage { get { throw null; } }
        protected virtual Azure.AI.Projects.Memory.MemoryUpdateResultDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Projects.Memory.MemoryUpdateResultDetails (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.Projects.Memory.MemoryUpdateResultDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Memory.MemoryUpdateResultDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.MemoryUpdateResultDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.MemoryUpdateResultDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Memory.MemoryUpdateResultDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemoryUpdateResultDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemoryUpdateResultDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemoryUpdateResultDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UserProfileMemoryItem : Azure.AI.Projects.Memory.MemoryItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.UserProfileMemoryItem>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.UserProfileMemoryItem>
    {
        internal UserProfileMemoryItem() { }
        protected override Azure.AI.Projects.Memory.MemoryItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Memory.MemoryItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Memory.UserProfileMemoryItem System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.UserProfileMemoryItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.UserProfileMemoryItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Memory.UserProfileMemoryItem System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.UserProfileMemoryItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.UserProfileMemoryItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.UserProfileMemoryItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace OpenAI
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential, Size=1)]
    public readonly partial struct AgentObjectType
    {
    }
}
