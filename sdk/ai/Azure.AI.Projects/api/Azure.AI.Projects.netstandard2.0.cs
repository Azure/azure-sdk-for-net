namespace Azure.AI.Projects
{
    public partial class AgentEvaluation : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentEvaluation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentEvaluation>
    {
        internal AgentEvaluation() { }
        public string Error { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Projects.AgentEvaluationResult> Result { get { throw null; } }
        public string Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AgentEvaluation System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentEvaluation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentEvaluation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AgentEvaluation System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentEvaluation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentEvaluation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentEvaluation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentEvaluationRedactionConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentEvaluationRedactionConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentEvaluationRedactionConfiguration>
    {
        public AgentEvaluationRedactionConfiguration() { }
        public bool? RedactScoreProperties { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AgentEvaluationRedactionConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentEvaluationRedactionConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentEvaluationRedactionConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AgentEvaluationRedactionConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentEvaluationRedactionConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentEvaluationRedactionConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentEvaluationRedactionConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentEvaluationRequest : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentEvaluationRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentEvaluationRequest>
    {
        public AgentEvaluationRequest(string runId, System.Collections.Generic.IDictionary<string, Azure.AI.Projects.EvaluatorConfiguration> evaluators, string appInsightsConnectionString) { }
        public string AppInsightsConnectionString { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.AI.Projects.EvaluatorConfiguration> Evaluators { get { throw null; } }
        public Azure.AI.Projects.AgentEvaluationRedactionConfiguration RedactionConfiguration { get { throw null; } set { } }
        public string RunId { get { throw null; } }
        public Azure.AI.Projects.AgentEvaluationSamplingConfiguration SamplingConfiguration { get { throw null; } set { } }
        public string ThreadId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AgentEvaluationRequest System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentEvaluationRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentEvaluationRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AgentEvaluationRequest System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentEvaluationRequest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentEvaluationRequest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentEvaluationRequest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentEvaluationResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentEvaluationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentEvaluationResult>
    {
        internal AgentEvaluationResult() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> AdditionalDetails { get { throw null; } }
        public string Error { get { throw null; } }
        public string Evaluator { get { throw null; } }
        public string EvaluatorId { get { throw null; } }
        public string Reason { get { throw null; } }
        public string RunId { get { throw null; } }
        public float Score { get { throw null; } }
        public string Status { get { throw null; } }
        public string ThreadId { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AgentEvaluationResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentEvaluationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentEvaluationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AgentEvaluationResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentEvaluationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentEvaluationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentEvaluationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentEvaluationSamplingConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentEvaluationSamplingConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentEvaluationSamplingConfiguration>
    {
        public AgentEvaluationSamplingConfiguration(string name, float samplingPercent, float maxRequestRate) { }
        public float MaxRequestRate { get { throw null; } }
        public string Name { get { throw null; } }
        public float SamplingPercent { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AgentEvaluationSamplingConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentEvaluationSamplingConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentEvaluationSamplingConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AgentEvaluationSamplingConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentEvaluationSamplingConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentEvaluationSamplingConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentEvaluationSamplingConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AIProjectClient : System.ClientModel.Primitives.ClientConnectionProvider
    {
        protected AIProjectClient() : base (default(int)) { }
        public AIProjectClient(System.Uri endpoint, Azure.Core.TokenCredential credential = null) : base (default(int)) { }
        public AIProjectClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.AI.Projects.AIProjectClientOptions options) : base (default(int)) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public Azure.AI.Projects.Telemetry Telemetry { get { throw null; } }
        public override System.Collections.Generic.IEnumerable<System.ClientModel.Primitives.ClientConnection> GetAllConnections() { throw null; }
        public OpenAI.Chat.ChatClient GetAzureOpenAIChatClient(string? connectionName = null, string? apiVersion = null, string? deploymentName = null) { throw null; }
        public Azure.AI.Inference.ChatCompletionsClient GetChatCompletionsClient() { throw null; }
        public override System.ClientModel.Primitives.ClientConnection GetConnection(string connectionId) { throw null; }
        public virtual Azure.AI.Projects.Connections GetConnectionsClient(string apiVersion = "2025-05-15-preview") { throw null; }
        public virtual Azure.AI.Projects.Datasets GetDatasetsClient(string apiVersion = "2025-05-15-preview") { throw null; }
        public virtual Azure.AI.Projects.Deployments GetDeploymentsClient(string apiVersion = "2025-05-15-preview") { throw null; }
        public Azure.AI.Inference.EmbeddingsClient GetEmbeddingsClient() { throw null; }
        public virtual Azure.AI.Projects.Evaluations GetEvaluationsClient(string apiVersion = "2025-05-15-preview") { throw null; }
        public Azure.AI.Inference.ImageEmbeddingsClient GetImageEmbeddingsClient() { throw null; }
        public virtual Azure.AI.Projects.Indexes GetIndexesClient(string apiVersion = "2025-05-15-preview") { throw null; }
        public virtual Azure.AI.Projects.RedTeams GetRedTeamsClient(string apiVersion = "2025-05-15-preview") { throw null; }
        public virtual Azure.AI.Projects.ServicePatterns GetServicePatternsClient() { throw null; }
    }
    public partial class AIProjectClientOptions : Azure.Core.ClientOptions
    {
        public AIProjectClientOptions(Azure.AI.Projects.AIProjectClientOptions.ServiceVersion version = Azure.AI.Projects.AIProjectClientOptions.ServiceVersion.V2025_05_15_Preview) { }
        public int ClientCacheSize { get { throw null; } set { } }
        public enum ServiceVersion
        {
            V2025_05_01 = 1,
            V2025_05_15_Preview = 2,
        }
    }
    public static partial class AIProjectsModelFactory
    {
        public static Azure.AI.Projects.AgentEvaluation AgentEvaluation(string id = null, string status = null, string error = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.AgentEvaluationResult> result = null) { throw null; }
        public static Azure.AI.Projects.AgentEvaluationRequest AgentEvaluationRequest(string runId = null, string threadId = null, System.Collections.Generic.IDictionary<string, Azure.AI.Projects.EvaluatorConfiguration> evaluators = null, Azure.AI.Projects.AgentEvaluationSamplingConfiguration samplingConfiguration = null, Azure.AI.Projects.AgentEvaluationRedactionConfiguration redactionConfiguration = null, string appInsightsConnectionString = null) { throw null; }
        public static Azure.AI.Projects.AgentEvaluationResult AgentEvaluationResult(string evaluator = null, string evaluatorId = null, float score = 0f, string status = null, string reason = null, string version = null, string threadId = null, string runId = null, string error = null, System.Collections.Generic.IReadOnlyDictionary<string, string> additionalDetails = null) { throw null; }
        public static Azure.AI.Projects.ApiKeyCredentials ApiKeyCredentials(string apiKey = null) { throw null; }
        public static Azure.AI.Projects.AssetCredentialResponse AssetCredentialResponse(Azure.AI.Projects.BlobReference blobReference = null) { throw null; }
        public static Azure.AI.Projects.AzureAISearchIndex AzureAISearchIndex(string id = null, string name = null, string version = null, string description = null, System.Collections.Generic.IDictionary<string, string> tags = null, string connectionName = null, string indexName = null, Azure.AI.Projects.FieldMapping fieldMapping = null) { throw null; }
        public static Azure.AI.Projects.BlobReference BlobReference(string blobUri = null, string storageAccountArmId = null, Azure.AI.Projects.SasCredential credential = null) { throw null; }
        public static Azure.AI.Projects.Connection Connection(string name = null, string id = null, Azure.AI.Projects.ConnectionType type = default(Azure.AI.Projects.ConnectionType), string target = null, bool isDefault = false, Azure.AI.Projects.BaseCredentials credentials = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null) { throw null; }
        public static Azure.AI.Projects.CosmosDBIndex CosmosDBIndex(string id = null, string name = null, string version = null, string description = null, System.Collections.Generic.IDictionary<string, string> tags = null, string connectionName = null, string databaseName = null, string containerName = null, Azure.AI.Projects.EmbeddingConfiguration embeddingConfiguration = null, Azure.AI.Projects.FieldMapping fieldMapping = null) { throw null; }
        public static Azure.AI.Projects.CustomCredential CustomCredential(System.Collections.Generic.IReadOnlyDictionary<string, string> keys = null) { throw null; }
        public static Azure.AI.Projects.DatasetVersion DatasetVersion(string dataUri = null, string type = null, bool? isReference = default(bool?), string connectionName = null, string id = null, string name = null, string version = null, string description = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.AI.Projects.Deployment Deployment(string type = null, string name = null) { throw null; }
        public static Azure.AI.Projects.Evaluation Evaluation(string name = null, Azure.AI.Projects.InputData data = null, string displayName = null, string description = null, string status = null, System.Collections.Generic.IDictionary<string, string> tags = null, System.Collections.Generic.IDictionary<string, string> properties = null, System.Collections.Generic.IDictionary<string, Azure.AI.Projects.EvaluatorConfiguration> evaluators = null) { throw null; }
        public static Azure.AI.Projects.FileDatasetVersion FileDatasetVersion(string dataUri = null, bool? isReference = default(bool?), string connectionName = null, string id = null, string name = null, string version = null, string description = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.AI.Projects.FolderDatasetVersion FolderDatasetVersion(string dataUri = null, bool? isReference = default(bool?), string connectionName = null, string id = null, string name = null, string version = null, string description = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.AI.Projects.Index Index(string type = null, string id = null, string name = null, string version = null, string description = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.AI.Projects.ManagedAzureAISearchIndex ManagedAzureAISearchIndex(string id = null, string name = null, string version = null, string description = null, System.Collections.Generic.IDictionary<string, string> tags = null, string vectorStoreId = null) { throw null; }
        public static Azure.AI.Projects.ModelDeployment ModelDeployment(string name = null, string modelName = null, string modelVersion = null, string modelPublisher = null, System.Collections.Generic.IReadOnlyDictionary<string, string> capabilities = null, Azure.AI.Projects.Sku sku = null, string connectionName = null) { throw null; }
        public static Azure.AI.Projects.PendingUploadRequest PendingUploadRequest(string pendingUploadId = null, string connectionName = null, Azure.AI.Projects.PendingUploadType pendingUploadType = default(Azure.AI.Projects.PendingUploadType)) { throw null; }
        public static Azure.AI.Projects.PendingUploadResponse PendingUploadResponse(Azure.AI.Projects.BlobReference blobReference = null, string pendingUploadId = null, string version = null, Azure.AI.Projects.PendingUploadType pendingUploadType = default(Azure.AI.Projects.PendingUploadType)) { throw null; }
        public static Azure.AI.Projects.RedTeam RedTeam(string name = null, string displayName = null, int? numTurns = default(int?), System.Collections.Generic.IEnumerable<Azure.AI.Projects.AttackStrategy> attackStrategies = null, bool? simulationOnly = default(bool?), System.Collections.Generic.IEnumerable<Azure.AI.Projects.RiskCategory> riskCategories = null, string applicationScenario = null, System.Collections.Generic.IDictionary<string, string> tags = null, System.Collections.Generic.IDictionary<string, string> properties = null, string status = null, Azure.AI.Projects.TargetConfig target = null) { throw null; }
        public static Azure.AI.Projects.SasCredential SasCredential(string sasUri = null, Azure.AI.Projects.SasCredentialType type = default(Azure.AI.Projects.SasCredentialType)) { throw null; }
        public static Azure.AI.Projects.SASCredentials SASCredentials(string sasToken = null) { throw null; }
        public static Azure.AI.Projects.Sku Sku(long capacity = (long)0, string family = null, string name = null, string size = null, string tier = null) { throw null; }
    }
    public partial class ApiKeyCredentials : Azure.AI.Projects.BaseCredentials, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ApiKeyCredentials>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ApiKeyCredentials>
    {
        internal ApiKeyCredentials() { }
        public string ApiKey { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AssetCredentialResponse System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AssetCredentialResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AssetCredentialResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AssetCredentialResponse System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AssetCredentialResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AssetCredentialResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AssetCredentialResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AttackStrategy : System.IEquatable<Azure.AI.Projects.AttackStrategy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AttackStrategy(string value) { throw null; }
        public static Azure.AI.Projects.AttackStrategy AnsiiAttack { get { throw null; } }
        public static Azure.AI.Projects.AttackStrategy AsciiArt { get { throw null; } }
        public static Azure.AI.Projects.AttackStrategy AsciiSmuggler { get { throw null; } }
        public static Azure.AI.Projects.AttackStrategy Atbash { get { throw null; } }
        public static Azure.AI.Projects.AttackStrategy Base64 { get { throw null; } }
        public static Azure.AI.Projects.AttackStrategy Baseline { get { throw null; } }
        public static Azure.AI.Projects.AttackStrategy Binary { get { throw null; } }
        public static Azure.AI.Projects.AttackStrategy Caesar { get { throw null; } }
        public static Azure.AI.Projects.AttackStrategy CharacterSpace { get { throw null; } }
        public static Azure.AI.Projects.AttackStrategy CharacterSwap { get { throw null; } }
        public static Azure.AI.Projects.AttackStrategy Diacritic { get { throw null; } }
        public static Azure.AI.Projects.AttackStrategy Difficult { get { throw null; } }
        public static Azure.AI.Projects.AttackStrategy Easy { get { throw null; } }
        public static Azure.AI.Projects.AttackStrategy Flip { get { throw null; } }
        public static Azure.AI.Projects.AttackStrategy Jailbreak { get { throw null; } }
        public static Azure.AI.Projects.AttackStrategy Leetspeak { get { throw null; } }
        public static Azure.AI.Projects.AttackStrategy Moderate { get { throw null; } }
        public static Azure.AI.Projects.AttackStrategy Morse { get { throw null; } }
        public static Azure.AI.Projects.AttackStrategy ROT13 { get { throw null; } }
        public static Azure.AI.Projects.AttackStrategy StringJoin { get { throw null; } }
        public static Azure.AI.Projects.AttackStrategy SuffixAppend { get { throw null; } }
        public static Azure.AI.Projects.AttackStrategy UnicodeConfusable { get { throw null; } }
        public static Azure.AI.Projects.AttackStrategy UnicodeSubstitution { get { throw null; } }
        public static Azure.AI.Projects.AttackStrategy Url { get { throw null; } }
        public bool Equals(Azure.AI.Projects.AttackStrategy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.AttackStrategy left, Azure.AI.Projects.AttackStrategy right) { throw null; }
        public static implicit operator Azure.AI.Projects.AttackStrategy (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.AttackStrategy left, Azure.AI.Projects.AttackStrategy right) { throw null; }
        public override string ToString() { throw null; }
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
    public partial class AzureAISearchIndex : Azure.AI.Projects.Index, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AzureAISearchIndex>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AzureAISearchIndex>
    {
        public AzureAISearchIndex(string connectionName, string indexName) { }
        public string ConnectionName { get { throw null; } set { } }
        public Azure.AI.Projects.FieldMapping FieldMapping { get { throw null; } set { } }
        public string IndexName { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AzureAISearchIndex System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AzureAISearchIndex>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AzureAISearchIndex>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AzureAISearchIndex System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AzureAISearchIndex>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AzureAISearchIndex>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AzureAISearchIndex>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureOpenAIModelConfiguration : Azure.AI.Projects.TargetConfig, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AzureOpenAIModelConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AzureOpenAIModelConfiguration>
    {
        public AzureOpenAIModelConfiguration(string modelDeploymentName) { }
        public string ModelDeploymentName { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AzureOpenAIModelConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AzureOpenAIModelConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AzureOpenAIModelConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AzureOpenAIModelConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AzureOpenAIModelConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AzureOpenAIModelConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AzureOpenAIModelConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class BaseCredentials : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.BaseCredentials>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.BaseCredentials>
    {
        protected BaseCredentials() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.BaseCredentials System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.BaseCredentials>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.BaseCredentials>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.BaseCredentials System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.BaseCredentials>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.BaseCredentials>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.BaseCredentials>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BlobReference : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.BlobReference>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.BlobReference>
    {
        internal BlobReference() { }
        public string BlobUri { get { throw null; } }
        public Azure.AI.Projects.SasCredential Credential { get { throw null; } }
        public string StorageAccountArmId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.BlobReference System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.BlobReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.BlobReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.BlobReference System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.BlobReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.BlobReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.BlobReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class Connection : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Connection>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Connection>
    {
        internal Connection() { }
        public Azure.AI.Projects.BaseCredentials Credentials { get { throw null; } }
        public string Id { get { throw null; } }
        public bool IsDefault { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Metadata { get { throw null; } }
        public string Name { get { throw null; } }
        public string Target { get { throw null; } }
        public Azure.AI.Projects.ConnectionType Type { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Connection System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Connection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Connection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Connection System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Connection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Connection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Connection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class Connections
    {
        protected Connections() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public Azure.AI.Projects.Connection Get(string connectionName, bool includeCredentials = false) { throw null; }
        public System.Threading.Tasks.Task<Azure.Response<Azure.AI.Projects.Connection>> GetAsync(string connectionName, bool includeCredentials = false) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Projects.Connection> GetConnections(Azure.AI.Projects.ConnectionType? connectionType = default(Azure.AI.Projects.ConnectionType?), bool? defaultConnection = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetConnections(string connectionType, bool? defaultConnection, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Projects.Connection> GetConnectionsAsync(Azure.AI.Projects.ConnectionType? connectionType = default(Azure.AI.Projects.ConnectionType?), bool? defaultConnection = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetConnectionsAsync(string connectionType, bool? defaultConnection, Azure.RequestContext context) { throw null; }
        public Azure.AI.Projects.Connection GetDefault(Azure.AI.Projects.ConnectionType? connectionType = default(Azure.AI.Projects.ConnectionType?), bool includeCredentials = false) { throw null; }
        public System.Threading.Tasks.Task<Azure.AI.Projects.Connection> GetDefaultAsync(Azure.AI.Projects.ConnectionType? connectionType = default(Azure.AI.Projects.ConnectionType?), bool includeCredentials = false) { throw null; }
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
    public partial class CosmosDBIndex : Azure.AI.Projects.Index, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.CosmosDBIndex>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.CosmosDBIndex>
    {
        public CosmosDBIndex(string connectionName, string databaseName, string containerName, Azure.AI.Projects.EmbeddingConfiguration embeddingConfiguration, Azure.AI.Projects.FieldMapping fieldMapping) { }
        public string ConnectionName { get { throw null; } set { } }
        public string ContainerName { get { throw null; } set { } }
        public string DatabaseName { get { throw null; } set { } }
        public Azure.AI.Projects.EmbeddingConfiguration EmbeddingConfiguration { get { throw null; } set { } }
        public Azure.AI.Projects.FieldMapping FieldMapping { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.CustomCredential System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.CustomCredential>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.CustomCredential>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.CustomCredential System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.CustomCredential>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.CustomCredential>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.CustomCredential>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class Datasets
    {
        protected Datasets() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response CreateOrUpdate(string name, string version, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrUpdateAsync(string name, string version, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response Delete(string name, string version, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string name, string version, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetCredentials(string name, string version, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Projects.AssetCredentialResponse> GetCredentials(string name, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetCredentialsAsync(string name, string version, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Projects.AssetCredentialResponse>> GetCredentialsAsync(string name, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetDataset(string name, string version, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Projects.DatasetVersion> GetDataset(string name, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetDatasetAsync(string name, string version, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Projects.DatasetVersion>> GetDatasetAsync(string name, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetDatasetVersions(Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Projects.DatasetVersion> GetDatasetVersions(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetDatasetVersionsAsync(Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Projects.DatasetVersion> GetDatasetVersionsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static string GetRelativePath(string folderPath, string filePath) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetVersions(string name, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Projects.DatasetVersion> GetVersions(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetVersionsAsync(string name, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Projects.DatasetVersion> GetVersionsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Projects.PendingUploadResponse> PendingUpload(string name, string version, Azure.AI.Projects.PendingUploadRequest body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response PendingUpload(string name, string version, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Projects.PendingUploadResponse>> PendingUploadAsync(string name, string version, Azure.AI.Projects.PendingUploadRequest body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> PendingUploadAsync(string name, string version, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public Azure.Response UploadFile(string name, string version, string filePath) { throw null; }
        public Azure.Response UploadFolder(string name, string version, string folderPath) { throw null; }
    }
    public abstract partial class DatasetVersion : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.DatasetVersion>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.DatasetVersion>
    {
        protected DatasetVersion(string dataUri) { }
        public string ConnectionName { get { throw null; } set { } }
        public string DataUri { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string Id { get { throw null; } }
        public bool? IsReference { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.DatasetVersion System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.DatasetVersion>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.DatasetVersion>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.DatasetVersion System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.DatasetVersion>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.DatasetVersion>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.DatasetVersion>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class Deployment : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Deployment>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Deployment>
    {
        protected Deployment() { }
        public string Name { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Deployment System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Deployment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Deployment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Deployment System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Deployment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Deployment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Deployment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class Deployments
    {
        protected Deployments() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response GetDeployment(string name, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Projects.Deployment> GetDeployment(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetDeploymentAsync(string name, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Projects.Deployment>> GetDeploymentAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Projects.Deployment> GetDeployments(string modelPublisher = null, string modelName = null, Azure.AI.Projects.DeploymentType? deploymentType = default(Azure.AI.Projects.DeploymentType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetDeployments(string modelPublisher, string modelName, string deploymentType, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Projects.Deployment> GetDeploymentsAsync(string modelPublisher = null, string modelName = null, Azure.AI.Projects.DeploymentType? deploymentType = default(Azure.AI.Projects.DeploymentType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetDeploymentsAsync(string modelPublisher, string modelName, string deploymentType, Azure.RequestContext context) { throw null; }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.EmbeddingConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.EmbeddingConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.EmbeddingConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.EmbeddingConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EmbeddingConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EmbeddingConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EmbeddingConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EntraIDCredentials : Azure.AI.Projects.BaseCredentials, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.EntraIDCredentials>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EntraIDCredentials>
    {
        internal EntraIDCredentials() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.EntraIDCredentials System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.EntraIDCredentials>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.EntraIDCredentials>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.EntraIDCredentials System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EntraIDCredentials>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EntraIDCredentials>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EntraIDCredentials>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class Evaluation : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation>
    {
        public Evaluation(Azure.AI.Projects.InputData data, System.Collections.Generic.IDictionary<string, Azure.AI.Projects.EvaluatorConfiguration> evaluators) { }
        public Azure.AI.Projects.InputData Data { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.AI.Projects.EvaluatorConfiguration> Evaluators { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Properties { get { throw null; } }
        public string Status { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class Evaluations
    {
        protected Evaluations() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response<Azure.AI.Projects.Evaluation> Create(Azure.AI.Projects.Evaluation evaluation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Create(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Projects.AgentEvaluation> CreateAgentEvaluation(Azure.AI.Projects.AgentEvaluationRequest evaluation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateAgentEvaluation(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Projects.AgentEvaluation>> CreateAgentEvaluationAsync(Azure.AI.Projects.AgentEvaluationRequest evaluation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateAgentEvaluationAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Projects.Evaluation>> CreateAsync(Azure.AI.Projects.Evaluation evaluation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetEvaluation(string name, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Projects.Evaluation> GetEvaluation(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetEvaluationAsync(string name, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Projects.Evaluation>> GetEvaluationAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetEvaluations(Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Projects.Evaluation> GetEvaluations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetEvaluationsAsync(Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Projects.Evaluation> GetEvaluationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EvaluatorConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.EvaluatorConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EvaluatorConfiguration>
    {
        public EvaluatorConfiguration(string id) { }
        public System.Collections.Generic.IDictionary<string, string> DataMapping { get { throw null; } }
        public string Id { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> InitParams { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.EvaluatorConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.EvaluatorConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.EvaluatorConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.EvaluatorConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EvaluatorConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EvaluatorConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EvaluatorConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.FieldMapping System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.FieldMapping>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.FieldMapping>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.FieldMapping System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.FieldMapping>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.FieldMapping>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.FieldMapping>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FileDatasetVersion : Azure.AI.Projects.DatasetVersion, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.FileDatasetVersion>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.FileDatasetVersion>
    {
        public FileDatasetVersion(string dataUri) : base (default(string)) { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.FileDatasetVersion System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.FileDatasetVersion>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.FileDatasetVersion>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.FileDatasetVersion System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.FileDatasetVersion>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.FileDatasetVersion>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.FileDatasetVersion>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FolderDatasetVersion : Azure.AI.Projects.DatasetVersion, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.FolderDatasetVersion>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.FolderDatasetVersion>
    {
        public FolderDatasetVersion(string dataUri) : base (default(string)) { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.FolderDatasetVersion System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.FolderDatasetVersion>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.FolderDatasetVersion>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.FolderDatasetVersion System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.FolderDatasetVersion>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.FolderDatasetVersion>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.FolderDatasetVersion>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class Index : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Index>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Index>
    {
        protected Index() { }
        public string Description { get { throw null; } set { } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Index System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Index>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Index>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Index System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Index>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Index>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Index>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class Indexes
    {
        protected Indexes() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response CreateOrUpdate(string name, string version, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrUpdateAsync(string name, string version, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response Delete(string name, string version, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string name, string version, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetIndex(string name, string version, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Projects.Index> GetIndex(string name, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetIndexAsync(string name, string version, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Projects.Index>> GetIndexAsync(string name, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetIndices(Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Projects.Index> GetIndices(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetIndicesAsync(Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Projects.Index> GetIndicesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetVersions(string name, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Projects.Index> GetVersions(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetVersionsAsync(string name, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Projects.Index> GetVersionsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public abstract partial class InputData : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.InputData>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.InputData>
    {
        protected InputData() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.InputData System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.InputData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.InputData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.InputData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.InputData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.InputData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.InputData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InputDataset : Azure.AI.Projects.InputData, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.InputDataset>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.InputDataset>
    {
        public InputDataset(string id) { }
        public string Id { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.InputDataset System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.InputDataset>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.InputDataset>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.InputDataset System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.InputDataset>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.InputDataset>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.InputDataset>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ManagedAzureAISearchIndex : Azure.AI.Projects.Index, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ManagedAzureAISearchIndex>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ManagedAzureAISearchIndex>
    {
        public ManagedAzureAISearchIndex(string vectorStoreId) { }
        public string VectorStoreId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.ManagedAzureAISearchIndex System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ManagedAzureAISearchIndex>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ManagedAzureAISearchIndex>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.ManagedAzureAISearchIndex System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ManagedAzureAISearchIndex>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ManagedAzureAISearchIndex>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ManagedAzureAISearchIndex>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ModelDeployment : Azure.AI.Projects.Deployment, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ModelDeployment>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ModelDeployment>
    {
        internal ModelDeployment() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Capabilities { get { throw null; } }
        public string ConnectionName { get { throw null; } }
        public string ModelName { get { throw null; } }
        public string ModelPublisher { get { throw null; } }
        public string ModelVersion { get { throw null; } }
        public Azure.AI.Projects.Sku Sku { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.ModelDeployment System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ModelDeployment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ModelDeployment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.ModelDeployment System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ModelDeployment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ModelDeployment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ModelDeployment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NoAuthenticationCredentials : Azure.AI.Projects.BaseCredentials, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.NoAuthenticationCredentials>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.NoAuthenticationCredentials>
    {
        internal NoAuthenticationCredentials() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
    public partial class RedTeam : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RedTeam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RedTeam>
    {
        public RedTeam(Azure.AI.Projects.TargetConfig target) { }
        public string ApplicationScenario { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Projects.AttackStrategy> AttackStrategies { get { throw null; } }
        public string DisplayName { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public int? NumTurns { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Properties { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Projects.RiskCategory> RiskCategories { get { throw null; } }
        public bool? SimulationOnly { get { throw null; } set { } }
        public string Status { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public Azure.AI.Projects.TargetConfig Target { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RedTeam System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RedTeam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RedTeam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RedTeam System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RedTeam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RedTeam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RedTeam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RedTeams
    {
        protected RedTeams() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response<Azure.AI.Projects.RedTeam> Create(Azure.AI.Projects.RedTeam redTeam, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Create(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Projects.RedTeam>> CreateAsync(Azure.AI.Projects.RedTeam redTeam, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetRedTeam(string name, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Projects.RedTeam> GetRedTeam(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetRedTeamAsync(string name, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Projects.RedTeam>> GetRedTeamAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetRedTeams(Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Projects.RedTeam> GetRedTeams(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetRedTeamsAsync(Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Projects.RedTeam> GetRedTeamsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RiskCategory : System.IEquatable<Azure.AI.Projects.RiskCategory>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RiskCategory(string value) { throw null; }
        public static Azure.AI.Projects.RiskCategory HateUnfairness { get { throw null; } }
        public static Azure.AI.Projects.RiskCategory SelfHarm { get { throw null; } }
        public static Azure.AI.Projects.RiskCategory Sexual { get { throw null; } }
        public static Azure.AI.Projects.RiskCategory Violence { get { throw null; } }
        public bool Equals(Azure.AI.Projects.RiskCategory other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.RiskCategory left, Azure.AI.Projects.RiskCategory right) { throw null; }
        public static implicit operator Azure.AI.Projects.RiskCategory (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.RiskCategory left, Azure.AI.Projects.RiskCategory right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SasCredential : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.SasCredential>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.SasCredential>
    {
        internal SasCredential() { }
        public string SasUri { get { throw null; } }
        public Azure.AI.Projects.SasCredentialType Type { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.SasCredential System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.SasCredential>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.SasCredential>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.SasCredential System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.SasCredential>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.SasCredential>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.SasCredential>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SASCredentials : Azure.AI.Projects.BaseCredentials, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.SASCredentials>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.SASCredentials>
    {
        internal SASCredentials() { }
        public string SasToken { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.SASCredentials System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.SASCredentials>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.SASCredentials>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.SASCredentials System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.SASCredentials>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.SASCredentials>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.SASCredentials>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SasCredentialType : System.IEquatable<Azure.AI.Projects.SasCredentialType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SasCredentialType(string value) { throw null; }
        public static Azure.AI.Projects.SasCredentialType SAS { get { throw null; } }
        public bool Equals(Azure.AI.Projects.SasCredentialType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.SasCredentialType left, Azure.AI.Projects.SasCredentialType right) { throw null; }
        public static implicit operator Azure.AI.Projects.SasCredentialType (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.SasCredentialType left, Azure.AI.Projects.SasCredentialType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ServicePatterns
    {
        protected ServicePatterns() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
    }
    public partial class Sku : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Sku>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Sku>
    {
        internal Sku() { }
        public long Capacity { get { throw null; } }
        public string Family { get { throw null; } }
        public string Name { get { throw null; } }
        public string Size { get { throw null; } }
        public string Tier { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Sku System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Sku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Sku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Sku System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Sku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Sku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Sku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class TargetConfig : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.TargetConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.TargetConfig>
    {
        protected TargetConfig() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.TargetConfig System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.TargetConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.TargetConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.TargetConfig System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.TargetConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.TargetConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.TargetConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class Telemetry
    {
        public Telemetry(Azure.AI.Projects.AIProjectClient outerInstance) { }
        public string GetConnectionString() { throw null; }
        public System.Threading.Tasks.Task<string> GetConnectionStringAsync() { throw null; }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class AIProjectsClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Projects.AIProjectClient, Azure.AI.Projects.AIProjectClientOptions> AddAIProjectClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Projects.AIProjectClient, Azure.AI.Projects.AIProjectClientOptions> AddAIProjectClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
