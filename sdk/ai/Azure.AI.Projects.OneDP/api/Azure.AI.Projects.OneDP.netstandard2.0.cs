namespace Azure.AI.Projects
{
    public enum AuthenticationType
    {
        ApiKey = 0,
        EntraId = 1,
        SAS = 2,
        Custom = 3,
        None = 4,
    }
}
namespace Azure.AI.Projects.OneDP
{
    public partial class AIProjectClient : System.ClientModel.Primitives.ConnectionProvider
    {
        protected AIProjectClient() { }
        public AIProjectClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public AIProjectClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.AI.Projects.OneDP.AIProjectClientOptions options) { }
        public AIProjectClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public AIProjectClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.AI.Projects.OneDP.AIProjectClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public override System.Collections.Generic.IEnumerable<System.ClientModel.Primitives.ClientConnection> GetAllConnections() { throw null; }
        public override System.ClientModel.Primitives.ClientConnection GetConnection(string connectionId) { throw null; }
        public virtual Azure.AI.Projects.OneDP.Connections GetConnectionsClient(string apiVersion = "2025-05-15-preview") { throw null; }
        public virtual Azure.AI.Projects.OneDP.Datasets GetDatasetsClient(string apiVersion = "2025-05-15-preview") { throw null; }
        public virtual Azure.AI.Projects.OneDP.Deployments GetDeploymentsClient(string apiVersion = "2025-05-15-preview") { throw null; }
        public virtual Azure.AI.Projects.OneDP.Evaluations GetEvaluationsClient(string apiVersion = "2025-05-15-preview") { throw null; }
        public virtual Azure.AI.Projects.OneDP.Indexes GetIndexesClient(string apiVersion = "2025-05-15-preview") { throw null; }
        public virtual Azure.AI.Projects.OneDP.Internal GetInternalClient() { throw null; }
        public virtual Azure.AI.Projects.OneDP.RedTeams GetRedTeamsClient(string apiVersion = "2025-05-15-preview") { throw null; }
        public virtual Azure.AI.Projects.OneDP.ServicePatterns GetServicePatternsClient() { throw null; }
    }
    public partial class AIProjectClientOptions : Azure.Core.ClientOptions
    {
        public AIProjectClientOptions(Azure.AI.Projects.OneDP.AIProjectClientOptions.ServiceVersion version = Azure.AI.Projects.OneDP.AIProjectClientOptions.ServiceVersion.V2025_05_15_Preview) { }
        public enum ServiceVersion
        {
            V2025_05_01 = 1,
            V2025_05_15_Preview = 2,
        }
    }
    public static partial class AIProjectsOneDPModelFactory
    {
        public static Azure.AI.Projects.OneDP.ApiKeyCredentials ApiKeyCredentials(string apiKey = null) { throw null; }
        public static Azure.AI.Projects.OneDP.AssetCredentialResponse AssetCredentialResponse(Azure.AI.Projects.OneDP.BlobReferenceForConsumption blobReferenceForConsumption = null) { throw null; }
        public static Azure.AI.Projects.OneDP.AzureAISearchIndex AzureAISearchIndex(string stage = null, string id = null, string name = null, string version = null, string description = null, System.Collections.Generic.IDictionary<string, string> tags = null, string connectionName = null, string indexName = null) { throw null; }
        public static Azure.AI.Projects.OneDP.BlobReferenceForConsumption BlobReferenceForConsumption(string blobUri = null, string storageAccountArmId = null, Azure.AI.Projects.OneDP.SasCredential credential = null) { throw null; }
        public static Azure.AI.Projects.OneDP.Connection Connection(string authType = null, string name = null, Azure.AI.Projects.OneDP.ConnectionType type = default(Azure.AI.Projects.OneDP.ConnectionType), string target = null, bool isDefault = false, Azure.AI.Projects.OneDP.BaseCredentials credentials = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null) { throw null; }
        public static Azure.AI.Projects.OneDP.CosmosDBIndex CosmosDBIndex(string stage = null, string id = null, string name = null, string version = null, string description = null, System.Collections.Generic.IDictionary<string, string> tags = null, string connectionName = null, string databaseName = null, string containerName = null, Azure.AI.Projects.OneDP.EmbeddingConfiguration embeddingConfiguration = null) { throw null; }
        public static Azure.AI.Projects.OneDP.DatasetVersion DatasetVersion(string datasetUri = null, string type = null, bool? isReference = default(bool?), string stage = null, string id = null, string name = null, string version = null, string description = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.AI.Projects.OneDP.Deployment Deployment(string type = null, string name = null) { throw null; }
        public static Azure.AI.Projects.OneDP.Evaluation Evaluation(string id = null, Azure.AI.Projects.OneDP.InputData data = null, string displayName = null, string description = null, string status = null, System.Collections.Generic.IDictionary<string, string> tags = null, System.Collections.Generic.IDictionary<string, string> properties = null, System.Collections.Generic.IDictionary<string, Azure.AI.Projects.OneDP.EvaluatorConfiguration> evaluators = null) { throw null; }
        public static Azure.AI.Projects.OneDP.FileDatasetVersion FileDatasetVersion(string datasetUri = null, bool? isReference = default(bool?), string stage = null, string id = null, string name = null, string version = null, string description = null, System.Collections.Generic.IDictionary<string, string> tags = null, string openAIPurpose = null) { throw null; }
        public static Azure.AI.Projects.OneDP.FolderDatasetVersion FolderDatasetVersion(string datasetUri = null, bool? isReference = default(bool?), string stage = null, string id = null, string name = null, string version = null, string description = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.AI.Projects.OneDP.Index Index(string type = null, string stage = null, string id = null, string name = null, string version = null, string description = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.AI.Projects.OneDP.ManagedAzureAISearchIndex ManagedAzureAISearchIndex(string stage = null, string id = null, string name = null, string version = null, string description = null, System.Collections.Generic.IDictionary<string, string> tags = null, string vectorStoreId = null) { throw null; }
        public static Azure.AI.Projects.OneDP.ModelDeployment ModelDeployment(string name = null, string modelName = null, string modelVersion = null, string modelPublisher = null, System.Collections.Generic.IReadOnlyDictionary<string, string> capabilities = null, Azure.AI.Projects.OneDP.Sku sku = null, string connectionName = null) { throw null; }
        public static Azure.AI.Projects.OneDP.PendingUploadRequest PendingUploadRequest(string pendingUploadId = null, string connectionName = null, Azure.AI.Projects.OneDP.PendingUploadType pendingUploadType = default(Azure.AI.Projects.OneDP.PendingUploadType)) { throw null; }
        public static Azure.AI.Projects.OneDP.PendingUploadResponse PendingUploadResponse(Azure.AI.Projects.OneDP.BlobReferenceForConsumption blobReferenceForConsumption = null, string pendingUploadId = null, string datasetVersion = null, Azure.AI.Projects.OneDP.PendingUploadType pendingUploadType = default(Azure.AI.Projects.OneDP.PendingUploadType)) { throw null; }
        public static Azure.AI.Projects.OneDP.RedTeam RedTeam(string id = null, string scanName = null, int numTurns = 0, System.Collections.Generic.IEnumerable<Azure.AI.Projects.OneDP.AttackStrategy> attackStrategies = null, bool simulationOnly = false, System.Collections.Generic.IEnumerable<Azure.AI.Projects.OneDP.RiskCategory> riskCategories = null, string applicationScenario = null, System.Collections.Generic.IDictionary<string, string> tags = null, System.Collections.Generic.IDictionary<string, string> properties = null, string status = null) { throw null; }
        public static Azure.AI.Projects.OneDP.SasCredential SasCredential(string sasUri = null, Azure.AI.Projects.OneDP.SasCredentialType type = default(Azure.AI.Projects.OneDP.SasCredentialType)) { throw null; }
        public static Azure.AI.Projects.OneDP.SASCredentials SASCredentials(string sasToken = null) { throw null; }
        public static Azure.AI.Projects.OneDP.Sku Sku(long capacity = (long)0, string family = null, string name = null, string size = null, string tier = null) { throw null; }
    }
    public partial class ApiKeyCredentials : Azure.AI.Projects.OneDP.BaseCredentials, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OneDP.ApiKeyCredentials>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.ApiKeyCredentials>
    {
        internal ApiKeyCredentials() { }
        public string ApiKey { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OneDP.ApiKeyCredentials System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OneDP.ApiKeyCredentials>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OneDP.ApiKeyCredentials>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OneDP.ApiKeyCredentials System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.ApiKeyCredentials>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.ApiKeyCredentials>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.ApiKeyCredentials>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AssetCredentialResponse : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OneDP.AssetCredentialResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.AssetCredentialResponse>
    {
        internal AssetCredentialResponse() { }
        public Azure.AI.Projects.OneDP.BlobReferenceForConsumption BlobReferenceForConsumption { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OneDP.AssetCredentialResponse System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OneDP.AssetCredentialResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OneDP.AssetCredentialResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OneDP.AssetCredentialResponse System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.AssetCredentialResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.AssetCredentialResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.AssetCredentialResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AttackStrategy : System.IEquatable<Azure.AI.Projects.OneDP.AttackStrategy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AttackStrategy(string value) { throw null; }
        public static Azure.AI.Projects.OneDP.AttackStrategy AnsiiAttack { get { throw null; } }
        public static Azure.AI.Projects.OneDP.AttackStrategy AsciiArt { get { throw null; } }
        public static Azure.AI.Projects.OneDP.AttackStrategy AsciiSmuggler { get { throw null; } }
        public static Azure.AI.Projects.OneDP.AttackStrategy Atbash { get { throw null; } }
        public static Azure.AI.Projects.OneDP.AttackStrategy Base64 { get { throw null; } }
        public static Azure.AI.Projects.OneDP.AttackStrategy Baseline { get { throw null; } }
        public static Azure.AI.Projects.OneDP.AttackStrategy Binary { get { throw null; } }
        public static Azure.AI.Projects.OneDP.AttackStrategy Caesar { get { throw null; } }
        public static Azure.AI.Projects.OneDP.AttackStrategy CharacterSpace { get { throw null; } }
        public static Azure.AI.Projects.OneDP.AttackStrategy CharacterSwap { get { throw null; } }
        public static Azure.AI.Projects.OneDP.AttackStrategy Diacritic { get { throw null; } }
        public static Azure.AI.Projects.OneDP.AttackStrategy Difficult { get { throw null; } }
        public static Azure.AI.Projects.OneDP.AttackStrategy Easy { get { throw null; } }
        public static Azure.AI.Projects.OneDP.AttackStrategy Flip { get { throw null; } }
        public static Azure.AI.Projects.OneDP.AttackStrategy Jailbreak { get { throw null; } }
        public static Azure.AI.Projects.OneDP.AttackStrategy Leetspeak { get { throw null; } }
        public static Azure.AI.Projects.OneDP.AttackStrategy Moderate { get { throw null; } }
        public static Azure.AI.Projects.OneDP.AttackStrategy Morse { get { throw null; } }
        public static Azure.AI.Projects.OneDP.AttackStrategy ROT13 { get { throw null; } }
        public static Azure.AI.Projects.OneDP.AttackStrategy StringJoin { get { throw null; } }
        public static Azure.AI.Projects.OneDP.AttackStrategy SuffixAppend { get { throw null; } }
        public static Azure.AI.Projects.OneDP.AttackStrategy UnicodeConfusable { get { throw null; } }
        public static Azure.AI.Projects.OneDP.AttackStrategy UnicodeSubstitution { get { throw null; } }
        public static Azure.AI.Projects.OneDP.AttackStrategy Url { get { throw null; } }
        public bool Equals(Azure.AI.Projects.OneDP.AttackStrategy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.OneDP.AttackStrategy left, Azure.AI.Projects.OneDP.AttackStrategy right) { throw null; }
        public static implicit operator Azure.AI.Projects.OneDP.AttackStrategy (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.OneDP.AttackStrategy left, Azure.AI.Projects.OneDP.AttackStrategy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AzureAISearchIndex : Azure.AI.Projects.OneDP.Index, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OneDP.AzureAISearchIndex>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.AzureAISearchIndex>
    {
        public AzureAISearchIndex(string connectionName, string indexName) { }
        public string ConnectionName { get { throw null; } set { } }
        public string IndexName { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OneDP.AzureAISearchIndex System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OneDP.AzureAISearchIndex>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OneDP.AzureAISearchIndex>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OneDP.AzureAISearchIndex System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.AzureAISearchIndex>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.AzureAISearchIndex>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.AzureAISearchIndex>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class BaseCredentials : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OneDP.BaseCredentials>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.BaseCredentials>
    {
        protected BaseCredentials() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OneDP.BaseCredentials System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OneDP.BaseCredentials>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OneDP.BaseCredentials>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OneDP.BaseCredentials System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.BaseCredentials>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.BaseCredentials>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.BaseCredentials>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BlobReferenceForConsumption : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OneDP.BlobReferenceForConsumption>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.BlobReferenceForConsumption>
    {
        internal BlobReferenceForConsumption() { }
        public string BlobUri { get { throw null; } }
        public Azure.AI.Projects.OneDP.SasCredential Credential { get { throw null; } }
        public string StorageAccountArmId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OneDP.BlobReferenceForConsumption System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OneDP.BlobReferenceForConsumption>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OneDP.BlobReferenceForConsumption>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OneDP.BlobReferenceForConsumption System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.BlobReferenceForConsumption>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.BlobReferenceForConsumption>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.BlobReferenceForConsumption>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class Connection : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OneDP.Connection>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.Connection>
    {
        protected Connection() { }
        public Azure.AI.Projects.OneDP.BaseCredentials Credentials { get { throw null; } }
        public bool IsDefault { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Metadata { get { throw null; } }
        public string Name { get { throw null; } }
        public string Target { get { throw null; } }
        public Azure.AI.Projects.OneDP.ConnectionType Type { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OneDP.Connection System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OneDP.Connection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OneDP.Connection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OneDP.Connection System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.Connection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.Connection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.Connection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class Connections
    {
        protected Connections() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response GetConnection(string name, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Projects.OneDP.Connection> GetConnection(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetConnectionAsync(string name, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Projects.OneDP.Connection>> GetConnectionAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Projects.OneDP.Connection> GetConnections(Azure.AI.Projects.OneDP.ConnectionType? connectionType = default(Azure.AI.Projects.OneDP.ConnectionType?), bool? defaultConnection = default(bool?), int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetConnections(string connectionType, bool? defaultConnection, int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Projects.OneDP.Connection> GetConnectionsAsync(Azure.AI.Projects.OneDP.ConnectionType? connectionType = default(Azure.AI.Projects.OneDP.ConnectionType?), bool? defaultConnection = default(bool?), int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetConnectionsAsync(string connectionType, bool? defaultConnection, int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Projects.OneDP.Connection> GetDefaultConnection(Azure.AI.Projects.OneDP.ConnectionType category) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Projects.OneDP.Connection> GetWithCredentials(Azure.AI.Projects.OneDP.ConnectionType? connectionType = default(Azure.AI.Projects.OneDP.ConnectionType?), bool? defaultConnection = default(bool?), int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetWithCredentials(string name, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetWithCredentials(string connectionType, bool? defaultConnection, int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Projects.OneDP.Connection> GetWithCredentials(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Projects.OneDP.Connection> GetWithCredentialsAsync(Azure.AI.Projects.OneDP.ConnectionType? connectionType = default(Azure.AI.Projects.OneDP.ConnectionType?), bool? defaultConnection = default(bool?), int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetWithCredentialsAsync(string name, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetWithCredentialsAsync(string connectionType, bool? defaultConnection, int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Projects.OneDP.Connection>> GetWithCredentialsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConnectionType : System.IEquatable<Azure.AI.Projects.OneDP.ConnectionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConnectionType(string value) { throw null; }
        public static Azure.AI.Projects.OneDP.ConnectionType APIKey { get { throw null; } }
        public static Azure.AI.Projects.OneDP.ConnectionType ApplicationConfiguration { get { throw null; } }
        public static Azure.AI.Projects.OneDP.ConnectionType ApplicationInsights { get { throw null; } }
        public static Azure.AI.Projects.OneDP.ConnectionType AzureAISearch { get { throw null; } }
        public static Azure.AI.Projects.OneDP.ConnectionType AzureBlobStorage { get { throw null; } }
        public static Azure.AI.Projects.OneDP.ConnectionType AzureOpenAI { get { throw null; } }
        public static Azure.AI.Projects.OneDP.ConnectionType AzureStorageAccount { get { throw null; } }
        public static Azure.AI.Projects.OneDP.ConnectionType CosmosDB { get { throw null; } }
        public static Azure.AI.Projects.OneDP.ConnectionType Custom { get { throw null; } }
        public bool Equals(Azure.AI.Projects.OneDP.ConnectionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.OneDP.ConnectionType left, Azure.AI.Projects.OneDP.ConnectionType right) { throw null; }
        public static implicit operator Azure.AI.Projects.OneDP.ConnectionType (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.OneDP.ConnectionType left, Azure.AI.Projects.OneDP.ConnectionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CosmosDBIndex : Azure.AI.Projects.OneDP.Index, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OneDP.CosmosDBIndex>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.CosmosDBIndex>
    {
        public CosmosDBIndex(string connectionName, string databaseName, string containerName, Azure.AI.Projects.OneDP.EmbeddingConfiguration embeddingConfiguration) { }
        public string ConnectionName { get { throw null; } set { } }
        public string ContainerName { get { throw null; } set { } }
        public string DatabaseName { get { throw null; } set { } }
        public Azure.AI.Projects.OneDP.EmbeddingConfiguration EmbeddingConfiguration { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OneDP.CosmosDBIndex System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OneDP.CosmosDBIndex>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OneDP.CosmosDBIndex>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OneDP.CosmosDBIndex System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.CosmosDBIndex>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.CosmosDBIndex>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.CosmosDBIndex>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomCredential : Azure.AI.Projects.OneDP.BaseCredentials, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OneDP.CustomCredential>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.CustomCredential>
    {
        internal CustomCredential() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OneDP.CustomCredential System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OneDP.CustomCredential>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OneDP.CustomCredential>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OneDP.CustomCredential System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.CustomCredential>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.CustomCredential>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.CustomCredential>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class Datasets
    {
        protected Datasets() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response CreateOrUpdateVersion(string name, string version, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrUpdateVersionAsync(string name, string version, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Projects.OneDP.DatasetVersion> CreateVersion(string name, string version, Azure.AI.Projects.OneDP.DatasetVersion body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateVersion(string name, string version, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Projects.OneDP.DatasetVersion>> CreateVersionAsync(string name, string version, Azure.AI.Projects.OneDP.DatasetVersion body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateVersionAsync(string name, string version, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteVersion(string name, string version, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteVersionAsync(string name, string version, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Projects.OneDP.AssetCredentialResponse> GetCredentials(string name, string version, Azure.AI.Projects.OneDP.GetCredentialsRequest body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetCredentials(string name, string version, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Projects.OneDP.AssetCredentialResponse>> GetCredentialsAsync(string name, string version, Azure.AI.Projects.OneDP.GetCredentialsRequest body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetCredentialsAsync(string name, string version, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Projects.OneDP.DatasetVersion> GetLatests(int? maxCount = default(int?), string skip = null, string tags = null, Azure.AI.Projects.OneDP.ListViewType? listViewType = default(Azure.AI.Projects.OneDP.ListViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetLatests(int? maxCount, string skip, string tags, string listViewType, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Projects.OneDP.DatasetVersion> GetLatestsAsync(int? maxCount = default(int?), string skip = null, string tags = null, Azure.AI.Projects.OneDP.ListViewType? listViewType = default(Azure.AI.Projects.OneDP.ListViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetLatestsAsync(int? maxCount, string skip, string tags, string listViewType, Azure.RequestContext context) { throw null; }
        public static string GetRelativePath(string folderPath, string filePath) { throw null; }
        public virtual Azure.Response GetVersion(string name, string version, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Projects.OneDP.DatasetVersion> GetVersion(string name, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetVersionAsync(string name, string version, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Projects.OneDP.DatasetVersion>> GetVersionAsync(string name, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Projects.OneDP.DatasetVersion> GetVersions(string name, int? maxCount = default(int?), string skip = null, string tags = null, Azure.AI.Projects.OneDP.ListViewType? listViewType = default(Azure.AI.Projects.OneDP.ListViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetVersions(string name, int? maxCount, string skip, string tags, string listViewType, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Projects.OneDP.DatasetVersion> GetVersionsAsync(string name, int? maxCount = default(int?), string skip = null, string tags = null, Azure.AI.Projects.OneDP.ListViewType? listViewType = default(Azure.AI.Projects.OneDP.ListViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetVersionsAsync(string name, int? maxCount, string skip, string tags, string listViewType, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Projects.OneDP.PendingUploadResponse> StartPendingUploadVersion(string name, string version, Azure.AI.Projects.OneDP.PendingUploadRequest body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response StartPendingUploadVersion(string name, string version, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Projects.OneDP.PendingUploadResponse>> StartPendingUploadVersionAsync(string name, string version, Azure.AI.Projects.OneDP.PendingUploadRequest body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> StartPendingUploadVersionAsync(string name, string version, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public Azure.AI.Projects.OneDP.DatasetVersion UploadFileAndCreate(string name, string version, string filePath) { throw null; }
        public Azure.AI.Projects.OneDP.DatasetVersion UploadFolderAndCreate(string name, string version, string folderPath) { throw null; }
    }
    public abstract partial class DatasetVersion : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OneDP.DatasetVersion>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.DatasetVersion>
    {
        protected DatasetVersion(string datasetUri) { }
        public string DatasetUri { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string Id { get { throw null; } }
        public bool? IsReference { get { throw null; } }
        public string Name { get { throw null; } }
        public string Stage { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OneDP.DatasetVersion System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OneDP.DatasetVersion>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OneDP.DatasetVersion>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OneDP.DatasetVersion System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.DatasetVersion>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.DatasetVersion>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.DatasetVersion>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class Deployment : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OneDP.Deployment>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.Deployment>
    {
        protected Deployment() { }
        public string Name { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OneDP.Deployment System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OneDP.Deployment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OneDP.Deployment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OneDP.Deployment System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.Deployment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.Deployment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.Deployment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class Deployments
    {
        protected Deployments() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response GetDeployment(string name, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Projects.OneDP.Deployment> GetDeployment(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetDeploymentAsync(string name, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Projects.OneDP.Deployment>> GetDeploymentAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetDeployments(string modelPublisher, string modelName, int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Projects.OneDP.Deployment> GetDeployments(string modelPublisher = null, string modelName = null, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetDeploymentsAsync(string modelPublisher, string modelName, int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Projects.OneDP.Deployment> GetDeploymentsAsync(string modelPublisher = null, string modelName = null, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EmbeddingConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OneDP.EmbeddingConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.EmbeddingConfiguration>
    {
        public EmbeddingConfiguration(string modelDeploymentName, string embeddingField) { }
        public string EmbeddingField { get { throw null; } set { } }
        public string ModelDeploymentName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OneDP.EmbeddingConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OneDP.EmbeddingConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OneDP.EmbeddingConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OneDP.EmbeddingConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.EmbeddingConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.EmbeddingConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.EmbeddingConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EntraIDCredentials : Azure.AI.Projects.OneDP.BaseCredentials, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OneDP.EntraIDCredentials>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.EntraIDCredentials>
    {
        internal EntraIDCredentials() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OneDP.EntraIDCredentials System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OneDP.EntraIDCredentials>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OneDP.EntraIDCredentials>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OneDP.EntraIDCredentials System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.EntraIDCredentials>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.EntraIDCredentials>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.EntraIDCredentials>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class Evaluation : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OneDP.Evaluation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.Evaluation>
    {
        public Evaluation(Azure.AI.Projects.OneDP.InputData data, System.Collections.Generic.IDictionary<string, Azure.AI.Projects.OneDP.EvaluatorConfiguration> evaluators) { }
        public Azure.AI.Projects.OneDP.InputData Data { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.AI.Projects.OneDP.EvaluatorConfiguration> Evaluators { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Properties { get { throw null; } }
        public string Status { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OneDP.Evaluation System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OneDP.Evaluation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OneDP.Evaluation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OneDP.Evaluation System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.Evaluation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.Evaluation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.Evaluation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class Evaluations
    {
        protected Evaluations() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response<Azure.AI.Projects.OneDP.Evaluation> CreateRun(Azure.AI.Projects.OneDP.Evaluation evaluation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateRun(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Projects.OneDP.Evaluation>> CreateRunAsync(Azure.AI.Projects.OneDP.Evaluation evaluation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateRunAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetEvaluation(string name, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Projects.OneDP.Evaluation> GetEvaluation(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetEvaluationAsync(string name, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Projects.OneDP.Evaluation>> GetEvaluationAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetEvaluations(int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Projects.OneDP.Evaluation> GetEvaluations(int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetEvaluationsAsync(int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Projects.OneDP.Evaluation> GetEvaluationsAsync(int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EvaluatorConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OneDP.EvaluatorConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.EvaluatorConfiguration>
    {
        public EvaluatorConfiguration(string id) { }
        public System.Collections.Generic.IDictionary<string, string> DataMapping { get { throw null; } }
        public string Id { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> InitParams { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OneDP.EvaluatorConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OneDP.EvaluatorConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OneDP.EvaluatorConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OneDP.EvaluatorConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.EvaluatorConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.EvaluatorConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.EvaluatorConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FileDatasetVersion : Azure.AI.Projects.OneDP.DatasetVersion, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OneDP.FileDatasetVersion>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.FileDatasetVersion>
    {
        public FileDatasetVersion(string datasetUri, string openAIPurpose) : base (default(string)) { }
        public string OpenAIPurpose { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OneDP.FileDatasetVersion System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OneDP.FileDatasetVersion>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OneDP.FileDatasetVersion>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OneDP.FileDatasetVersion System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.FileDatasetVersion>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.FileDatasetVersion>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.FileDatasetVersion>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FolderDatasetVersion : Azure.AI.Projects.OneDP.DatasetVersion, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OneDP.FolderDatasetVersion>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.FolderDatasetVersion>
    {
        public FolderDatasetVersion(string datasetUri) : base (default(string)) { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OneDP.FolderDatasetVersion System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OneDP.FolderDatasetVersion>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OneDP.FolderDatasetVersion>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OneDP.FolderDatasetVersion System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.FolderDatasetVersion>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.FolderDatasetVersion>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.FolderDatasetVersion>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetCredentialsRequest : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OneDP.GetCredentialsRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.GetCredentialsRequest>
    {
        public GetCredentialsRequest() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OneDP.GetCredentialsRequest System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OneDP.GetCredentialsRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OneDP.GetCredentialsRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OneDP.GetCredentialsRequest System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.GetCredentialsRequest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.GetCredentialsRequest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.GetCredentialsRequest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class Index : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OneDP.Index>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.Index>
    {
        protected Index() { }
        public string Description { get { throw null; } set { } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public string Stage { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OneDP.Index System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OneDP.Index>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OneDP.Index>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OneDP.Index System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.Index>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.Index>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.Index>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class Indexes
    {
        protected Indexes() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response CreateOrUpdateVersion(string name, string version, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrUpdateVersionAsync(string name, string version, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Projects.OneDP.Index> CreateVersion(string name, string version, Azure.AI.Projects.OneDP.Index body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateVersion(string name, string version, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Projects.OneDP.Index>> CreateVersionAsync(string name, string version, Azure.AI.Projects.OneDP.Index body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateVersionAsync(string name, string version, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteVersion(string name, string version, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteVersionAsync(string name, string version, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Projects.OneDP.Index> GetLatests(int? maxCount = default(int?), string skip = null, string tags = null, Azure.AI.Projects.OneDP.ListViewType? listViewType = default(Azure.AI.Projects.OneDP.ListViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetLatests(int? maxCount, string skip, string tags, string listViewType, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Projects.OneDP.Index> GetLatestsAsync(int? maxCount = default(int?), string skip = null, string tags = null, Azure.AI.Projects.OneDP.ListViewType? listViewType = default(Azure.AI.Projects.OneDP.ListViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetLatestsAsync(int? maxCount, string skip, string tags, string listViewType, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response GetVersion(string name, string version, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Projects.OneDP.Index> GetVersion(string name, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetVersionAsync(string name, string version, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Projects.OneDP.Index>> GetVersionAsync(string name, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Projects.OneDP.Index> GetVersions(string name, int? maxCount = default(int?), string skip = null, string tags = null, Azure.AI.Projects.OneDP.ListViewType? listViewType = default(Azure.AI.Projects.OneDP.ListViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetVersions(string name, int? maxCount, string skip, string tags, string listViewType, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Projects.OneDP.Index> GetVersionsAsync(string name, int? maxCount = default(int?), string skip = null, string tags = null, Azure.AI.Projects.OneDP.ListViewType? listViewType = default(Azure.AI.Projects.OneDP.ListViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetVersionsAsync(string name, int? maxCount, string skip, string tags, string listViewType, Azure.RequestContext context) { throw null; }
    }
    public abstract partial class InputData : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OneDP.InputData>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.InputData>
    {
        protected InputData() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OneDP.InputData System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OneDP.InputData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OneDP.InputData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OneDP.InputData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.InputData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.InputData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.InputData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InputDataset : Azure.AI.Projects.OneDP.InputData, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OneDP.InputDataset>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.InputDataset>
    {
        public InputDataset(string id) { }
        public string Id { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OneDP.InputDataset System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OneDP.InputDataset>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OneDP.InputDataset>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OneDP.InputDataset System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.InputDataset>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.InputDataset>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.InputDataset>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class Internal
    {
        protected Internal() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ListViewType : System.IEquatable<Azure.AI.Projects.OneDP.ListViewType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ListViewType(string value) { throw null; }
        public static Azure.AI.Projects.OneDP.ListViewType ActiveOnly { get { throw null; } }
        public static Azure.AI.Projects.OneDP.ListViewType All { get { throw null; } }
        public static Azure.AI.Projects.OneDP.ListViewType ArchivedOnly { get { throw null; } }
        public bool Equals(Azure.AI.Projects.OneDP.ListViewType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.OneDP.ListViewType left, Azure.AI.Projects.OneDP.ListViewType right) { throw null; }
        public static implicit operator Azure.AI.Projects.OneDP.ListViewType (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.OneDP.ListViewType left, Azure.AI.Projects.OneDP.ListViewType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ManagedAzureAISearchIndex : Azure.AI.Projects.OneDP.Index, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OneDP.ManagedAzureAISearchIndex>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.ManagedAzureAISearchIndex>
    {
        public ManagedAzureAISearchIndex(string vectorStoreId) { }
        public string VectorStoreId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OneDP.ManagedAzureAISearchIndex System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OneDP.ManagedAzureAISearchIndex>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OneDP.ManagedAzureAISearchIndex>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OneDP.ManagedAzureAISearchIndex System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.ManagedAzureAISearchIndex>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.ManagedAzureAISearchIndex>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.ManagedAzureAISearchIndex>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ModelDeployment : Azure.AI.Projects.OneDP.Deployment, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OneDP.ModelDeployment>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.ModelDeployment>
    {
        internal ModelDeployment() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Capabilities { get { throw null; } }
        public string ConnectionName { get { throw null; } }
        public string ModelName { get { throw null; } }
        public string ModelPublisher { get { throw null; } }
        public string ModelVersion { get { throw null; } }
        public Azure.AI.Projects.OneDP.Sku Sku { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OneDP.ModelDeployment System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OneDP.ModelDeployment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OneDP.ModelDeployment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OneDP.ModelDeployment System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.ModelDeployment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.ModelDeployment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.ModelDeployment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NoAuthenticationCredentials : Azure.AI.Projects.OneDP.BaseCredentials, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OneDP.NoAuthenticationCredentials>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.NoAuthenticationCredentials>
    {
        internal NoAuthenticationCredentials() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OneDP.NoAuthenticationCredentials System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OneDP.NoAuthenticationCredentials>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OneDP.NoAuthenticationCredentials>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OneDP.NoAuthenticationCredentials System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.NoAuthenticationCredentials>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.NoAuthenticationCredentials>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.NoAuthenticationCredentials>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PendingUploadRequest : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OneDP.PendingUploadRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.PendingUploadRequest>
    {
        public PendingUploadRequest() { }
        public string ConnectionName { get { throw null; } set { } }
        public string PendingUploadId { get { throw null; } set { } }
        public Azure.AI.Projects.OneDP.PendingUploadType PendingUploadType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OneDP.PendingUploadRequest System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OneDP.PendingUploadRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OneDP.PendingUploadRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OneDP.PendingUploadRequest System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.PendingUploadRequest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.PendingUploadRequest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.PendingUploadRequest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PendingUploadResponse : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OneDP.PendingUploadResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.PendingUploadResponse>
    {
        internal PendingUploadResponse() { }
        public Azure.AI.Projects.OneDP.BlobReferenceForConsumption BlobReferenceForConsumption { get { throw null; } }
        public string DatasetVersion { get { throw null; } }
        public string PendingUploadId { get { throw null; } }
        public Azure.AI.Projects.OneDP.PendingUploadType PendingUploadType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OneDP.PendingUploadResponse System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OneDP.PendingUploadResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OneDP.PendingUploadResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OneDP.PendingUploadResponse System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.PendingUploadResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.PendingUploadResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.PendingUploadResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PendingUploadType : System.IEquatable<Azure.AI.Projects.OneDP.PendingUploadType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PendingUploadType(string value) { throw null; }
        public static Azure.AI.Projects.OneDP.PendingUploadType None { get { throw null; } }
        public static Azure.AI.Projects.OneDP.PendingUploadType TemporaryBlobReference { get { throw null; } }
        public bool Equals(Azure.AI.Projects.OneDP.PendingUploadType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.OneDP.PendingUploadType left, Azure.AI.Projects.OneDP.PendingUploadType right) { throw null; }
        public static implicit operator Azure.AI.Projects.OneDP.PendingUploadType (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.OneDP.PendingUploadType left, Azure.AI.Projects.OneDP.PendingUploadType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RedTeam : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OneDP.RedTeam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.RedTeam>
    {
        public RedTeam(int numTurns, System.Collections.Generic.IEnumerable<Azure.AI.Projects.OneDP.AttackStrategy> attackStrategies, bool simulationOnly, System.Collections.Generic.IEnumerable<Azure.AI.Projects.OneDP.RiskCategory> riskCategories) { }
        public string ApplicationScenario { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Projects.OneDP.AttackStrategy> AttackStrategies { get { throw null; } }
        public string Id { get { throw null; } }
        public int NumTurns { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Properties { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Projects.OneDP.RiskCategory> RiskCategories { get { throw null; } }
        public string ScanName { get { throw null; } set { } }
        public bool SimulationOnly { get { throw null; } set { } }
        public string Status { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OneDP.RedTeam System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OneDP.RedTeam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OneDP.RedTeam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OneDP.RedTeam System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.RedTeam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.RedTeam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.RedTeam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RedTeams
    {
        protected RedTeams() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response<Azure.AI.Projects.OneDP.RedTeam> CreateRun(Azure.AI.Projects.OneDP.RedTeam redTeam, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateRun(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Projects.OneDP.RedTeam>> CreateRunAsync(Azure.AI.Projects.OneDP.RedTeam redTeam, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateRunAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetRedTeam(string name, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Projects.OneDP.RedTeam> GetRedTeam(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetRedTeamAsync(string name, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Projects.OneDP.RedTeam>> GetRedTeamAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetRedTeams(int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Projects.OneDP.RedTeam> GetRedTeams(int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetRedTeamsAsync(int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Projects.OneDP.RedTeam> GetRedTeamsAsync(int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RiskCategory : System.IEquatable<Azure.AI.Projects.OneDP.RiskCategory>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RiskCategory(string value) { throw null; }
        public static Azure.AI.Projects.OneDP.RiskCategory CodeVulnerability { get { throw null; } }
        public static Azure.AI.Projects.OneDP.RiskCategory HateUnfairness { get { throw null; } }
        public static Azure.AI.Projects.OneDP.RiskCategory ProtectedMaterial { get { throw null; } }
        public static Azure.AI.Projects.OneDP.RiskCategory SelfHarm { get { throw null; } }
        public static Azure.AI.Projects.OneDP.RiskCategory Sexual { get { throw null; } }
        public static Azure.AI.Projects.OneDP.RiskCategory UngroundedAttributes { get { throw null; } }
        public static Azure.AI.Projects.OneDP.RiskCategory Violence { get { throw null; } }
        public bool Equals(Azure.AI.Projects.OneDP.RiskCategory other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.OneDP.RiskCategory left, Azure.AI.Projects.OneDP.RiskCategory right) { throw null; }
        public static implicit operator Azure.AI.Projects.OneDP.RiskCategory (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.OneDP.RiskCategory left, Azure.AI.Projects.OneDP.RiskCategory right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SasCredential : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OneDP.SasCredential>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.SasCredential>
    {
        internal SasCredential() { }
        public string SasUri { get { throw null; } }
        public Azure.AI.Projects.OneDP.SasCredentialType Type { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OneDP.SasCredential System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OneDP.SasCredential>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OneDP.SasCredential>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OneDP.SasCredential System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.SasCredential>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.SasCredential>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.SasCredential>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SASCredentials : Azure.AI.Projects.OneDP.BaseCredentials, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OneDP.SASCredentials>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.SASCredentials>
    {
        internal SASCredentials() { }
        public string SasToken { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OneDP.SASCredentials System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OneDP.SASCredentials>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OneDP.SASCredentials>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OneDP.SASCredentials System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.SASCredentials>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.SASCredentials>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.SASCredentials>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SasCredentialType : System.IEquatable<Azure.AI.Projects.OneDP.SasCredentialType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SasCredentialType(string value) { throw null; }
        public static Azure.AI.Projects.OneDP.SasCredentialType SAS { get { throw null; } }
        public bool Equals(Azure.AI.Projects.OneDP.SasCredentialType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.OneDP.SasCredentialType left, Azure.AI.Projects.OneDP.SasCredentialType right) { throw null; }
        public static implicit operator Azure.AI.Projects.OneDP.SasCredentialType (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.OneDP.SasCredentialType left, Azure.AI.Projects.OneDP.SasCredentialType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ServicePatterns
    {
        protected ServicePatterns() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.AI.Projects.OneDP.ServicePatternsBuildingBlocks GetServicePatternsBuildingBlocksClient() { throw null; }
    }
    public partial class ServicePatternsBuildingBlocks
    {
        protected ServicePatternsBuildingBlocks() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
    }
    public partial class Sku : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OneDP.Sku>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.Sku>
    {
        internal Sku() { }
        public long Capacity { get { throw null; } }
        public string Family { get { throw null; } }
        public string Name { get { throw null; } }
        public string Size { get { throw null; } }
        public string Tier { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OneDP.Sku System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OneDP.Sku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OneDP.Sku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OneDP.Sku System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.Sku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.Sku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OneDP.Sku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class AIProjectsOneDPClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Projects.OneDP.AIProjectClient, Azure.AI.Projects.OneDP.AIProjectClientOptions> AddAIProjectClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Projects.OneDP.AIProjectClient, Azure.AI.Projects.OneDP.AIProjectClientOptions> AddAIProjectClient<TBuilder>(this TBuilder builder, System.Uri endpoint, Azure.AzureKeyCredential credential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Projects.OneDP.AIProjectClient, Azure.AI.Projects.OneDP.AIProjectClientOptions> AddAIProjectClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
