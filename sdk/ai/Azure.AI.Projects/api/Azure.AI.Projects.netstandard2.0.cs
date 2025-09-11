namespace Azure.AI.Projects
{
    public partial class AgentEvaluation : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentEvaluation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentEvaluation>
    {
        internal AgentEvaluation() { }
        public string Error { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Projects.AgentEvaluationResult> Result { get { throw null; } }
        public string Status { get { throw null; } }
        protected virtual Azure.AI.Projects.AgentEvaluation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Projects.AgentEvaluation (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.Projects.AgentEvaluation PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.AI.Projects.AgentEvaluationRedactionConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.AgentEvaluationRedactionConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.AI.Projects.AgentEvaluationRequest JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator System.ClientModel.BinaryContent (Azure.AI.Projects.AgentEvaluationRequest agentEvaluationRequest) { throw null; }
        protected virtual Azure.AI.Projects.AgentEvaluationRequest PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.AgentEvaluationRequest System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentEvaluationRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentEvaluationRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AgentEvaluationRequest System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentEvaluationRequest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentEvaluationRequest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentEvaluationRequest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentEvaluationResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentEvaluationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentEvaluationResult>
    {
        internal AgentEvaluationResult() { }
        public System.Collections.Generic.IDictionary<string, string> AdditionalDetails { get { throw null; } }
        public string Error { get { throw null; } }
        public string Evaluator { get { throw null; } }
        public string EvaluatorId { get { throw null; } }
        public string Reason { get { throw null; } }
        public string RunId { get { throw null; } }
        public float Score { get { throw null; } }
        public string Status { get { throw null; } }
        public string ThreadId { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual Azure.AI.Projects.AgentEvaluationResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.AgentEvaluationResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.AI.Projects.AgentEvaluationSamplingConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.AgentEvaluationSamplingConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public AIProjectClient(System.Uri endpoint, System.ClientModel.AuthenticationTokenProvider tokenProvider) : base (default(int)) { }
        public AIProjectClient(System.Uri endpoint, System.ClientModel.AuthenticationTokenProvider tokenProvider, Azure.AI.Projects.AIProjectClientOptions options) : base (default(int)) { }
        public virtual Azure.AI.Projects.ConnectionsOperations Connections { get { throw null; } }
        public virtual Azure.AI.Projects.DatasetsOperations Datasets { get { throw null; } }
        public virtual Azure.AI.Projects.DeploymentsOperations Deployments { get { throw null; } }
        public virtual Azure.AI.Projects.Evaluations Evaluations { get { throw null; } }
        public virtual Azure.AI.Projects.IndexesOperations Indexes { get { throw null; } }
        public System.ClientModel.Primitives.ClientPipeline Pipeline { get { throw null; } }
        public virtual Azure.AI.Projects.Telemetry Telemetry { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override System.Collections.Generic.IEnumerable<System.ClientModel.Primitives.ClientConnection> GetAllConnections() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override System.ClientModel.Primitives.ClientConnection GetConnection(string connectionId) { throw null; }
        public virtual Azure.AI.Projects.ConnectionsOperations GetConnectionsOperationsClient() { throw null; }
        public virtual Azure.AI.Projects.DatasetsOperations GetDatasetsOperationsClient() { throw null; }
        public virtual Azure.AI.Projects.DeploymentsOperations GetDeploymentsOperationsClient() { throw null; }
        public virtual Azure.AI.Projects.Evaluations GetEvaluationsClient() { throw null; }
        public virtual Azure.AI.Projects.IndexesOperations GetIndexesOperationsClient() { throw null; }
        public virtual OpenAI.OpenAIClient GetOpenAIClient(string? connectionName = null, string? apiVersion = null) { throw null; }
        public virtual Azure.AI.Projects.RedTeams GetRedTeamsClient() { throw null; }
    }
    public partial class AIProjectClientOptions : System.ClientModel.Primitives.ClientPipelineOptions
    {
        public AIProjectClientOptions(Azure.AI.Projects.AIProjectClientOptions.ServiceVersion version = Azure.AI.Projects.AIProjectClientOptions.ServiceVersion.V2025_05_15_Preview) { }
        public int ClientCacheSize { get { throw null; } set { } }
        public enum ServiceVersion
        {
            V2025_05_01 = 1,
            V2025_05_15_Preview = 2,
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
    public abstract partial class AssetDeployment : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AssetDeployment>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AssetDeployment>
    {
        internal AssetDeployment() { }
        public string Name { get { throw null; } }
        protected virtual Azure.AI.Projects.AssetDeployment JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Projects.AssetDeployment (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.Projects.AssetDeployment PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.AssetDeployment System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AssetDeployment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AssetDeployment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AssetDeployment System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AssetDeployment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AssetDeployment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AssetDeployment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AssistantMessage : Azure.AI.Projects.Message, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AssistantMessage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AssistantMessage>
    {
        public AssistantMessage(string content) { }
        public string Content { get { throw null; } set { } }
        protected override Azure.AI.Projects.Message JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Message PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.AssistantMessage System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AssistantMessage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AssistantMessage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AssistantMessage System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AssistantMessage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AssistantMessage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AssistantMessage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public static implicit operator Azure.AI.Projects.AttackStrategy? (string value) { throw null; }
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
    public static partial class AzureAIProjectsModelFactory
    {
        public static Azure.AI.Projects.AgentEvaluation AgentEvaluation(string id = null, string status = null, string error = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.AgentEvaluationResult> result = null) { throw null; }
        public static Azure.AI.Projects.AgentEvaluationRedactionConfiguration AgentEvaluationRedactionConfiguration(bool? redactScoreProperties = default(bool?)) { throw null; }
        public static Azure.AI.Projects.AgentEvaluationRequest AgentEvaluationRequest(string runId = null, string threadId = null, System.Collections.Generic.IDictionary<string, Azure.AI.Projects.EvaluatorConfiguration> evaluators = null, Azure.AI.Projects.AgentEvaluationSamplingConfiguration samplingConfiguration = null, Azure.AI.Projects.AgentEvaluationRedactionConfiguration redactionConfiguration = null, string appInsightsConnectionString = null) { throw null; }
        public static Azure.AI.Projects.AgentEvaluationResult AgentEvaluationResult(string evaluator = null, string evaluatorId = null, float score = 0f, string status = null, string reason = null, string version = null, string threadId = null, string runId = null, string error = null, System.Collections.Generic.IDictionary<string, string> additionalDetails = null) { throw null; }
        public static Azure.AI.Projects.AgentEvaluationSamplingConfiguration AgentEvaluationSamplingConfiguration(string name = null, float samplingPercent = 0f, float maxRequestRate = 0f) { throw null; }
        public static Azure.AI.Projects.ApiKeyCredentials ApiKeyCredentials(string apiKey = null) { throw null; }
        public static Azure.AI.Projects.AssetDeployment AssetDeployment(string type = null, string name = null) { throw null; }
        public static Azure.AI.Projects.AssistantMessage AssistantMessage(string content = null) { throw null; }
        public static Azure.AI.Projects.AzureAISearchIndex AzureAISearchIndex(string id = null, string name = null, string version = null, string description = null, System.Collections.Generic.IDictionary<string, string> tags = null, string connectionName = null, string indexName = null, Azure.AI.Projects.FieldMapping fieldMapping = null) { throw null; }
        public static Azure.AI.Projects.AzureOpenAIModelConfiguration AzureOpenAIModelConfiguration(string modelDeploymentName = null) { throw null; }
        public static Azure.AI.Projects.BaseCredentials BaseCredentials(string type = null) { throw null; }
        public static Azure.AI.Projects.BlobReference BlobReference(System.Uri blobUri = null, string storageAccountArmId = null, Azure.AI.Projects.BlobReferenceSasCredential credential = null) { throw null; }
        public static Azure.AI.Projects.BlobReferenceSasCredential BlobReferenceSasCredential(System.Uri sasUri = null, string type = null) { throw null; }
        public static Azure.AI.Projects.ConnectionProperties ConnectionProperties(string name = null, string id = null, Azure.AI.Projects.ConnectionType type = default(Azure.AI.Projects.ConnectionType), string target = null, bool isDefault = false, Azure.AI.Projects.BaseCredentials credentials = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null) { throw null; }
        public static Azure.AI.Projects.CosmosDBIndex CosmosDBIndex(string id = null, string name = null, string version = null, string description = null, System.Collections.Generic.IDictionary<string, string> tags = null, string connectionName = null, string databaseName = null, string containerName = null, Azure.AI.Projects.EmbeddingConfiguration embeddingConfiguration = null, Azure.AI.Projects.FieldMapping fieldMapping = null) { throw null; }
        public static Azure.AI.Projects.CustomCredential CustomCredential(System.Collections.Generic.IReadOnlyDictionary<string, string> keys = null) { throw null; }
        public static Azure.AI.Projects.DatasetCredential DatasetCredential(Azure.AI.Projects.BlobReference blobReference = null) { throw null; }
        public static Azure.AI.Projects.DatasetVersion DatasetVersion(System.Uri dataUri = null, string type = null, bool? isReference = default(bool?), string connectionName = null, string id = null, string name = null, string version = null, string description = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.AI.Projects.DeveloperMessage DeveloperMessage(string content = null) { throw null; }
        public static Azure.AI.Projects.EmbeddingConfiguration EmbeddingConfiguration(string modelDeploymentName = null, string embeddingField = null) { throw null; }
        public static Azure.AI.Projects.EntraIDCredentials EntraIDCredentials() { throw null; }
        public static Azure.AI.Projects.Evaluation Evaluation(string name = null, Azure.AI.Projects.InputData data = null, string displayName = null, string description = null, string status = null, System.Collections.Generic.IDictionary<string, string> tags = null, System.Collections.Generic.IDictionary<string, string> properties = null, System.Collections.Generic.IDictionary<string, Azure.AI.Projects.EvaluatorConfiguration> evaluators = null, Azure.AI.Projects.EvaluationTarget target = null) { throw null; }
        public static Azure.AI.Projects.EvaluationTarget EvaluationTarget(string type = null) { throw null; }
        public static Azure.AI.Projects.EvaluatorConfiguration EvaluatorConfiguration(string id = null, System.Collections.Generic.IDictionary<string, System.BinaryData> initParams = null, System.Collections.Generic.IDictionary<string, string> dataMapping = null) { throw null; }
        public static Azure.AI.Projects.FieldMapping FieldMapping(System.Collections.Generic.IEnumerable<string> contentFields = null, string filepathField = null, string titleField = null, string urlField = null, System.Collections.Generic.IEnumerable<string> vectorFields = null, System.Collections.Generic.IEnumerable<string> metadataFields = null) { throw null; }
        public static Azure.AI.Projects.FileDatasetVersion FileDatasetVersion(System.Uri dataUri = null, bool? isReference = default(bool?), string connectionName = null, string id = null, string name = null, string version = null, string description = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.AI.Projects.FolderDatasetVersion FolderDatasetVersion(System.Uri dataUri = null, bool? isReference = default(bool?), string connectionName = null, string id = null, string name = null, string version = null, string description = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.AI.Projects.InputData InputData(string type = null) { throw null; }
        public static Azure.AI.Projects.InputDataset InputDataset(string id = null) { throw null; }
        public static Azure.AI.Projects.ManagedAzureAISearchIndex ManagedAzureAISearchIndex(string id = null, string name = null, string version = null, string description = null, System.Collections.Generic.IDictionary<string, string> tags = null, string vectorStoreId = null) { throw null; }
        public static Azure.AI.Projects.Message Message(string role = null) { throw null; }
        public static Azure.AI.Projects.ModelDeployment ModelDeployment(string name = null, string modelName = null, string modelVersion = null, string modelPublisher = null, System.Collections.Generic.IReadOnlyDictionary<string, string> capabilities = null, Azure.AI.Projects.ModelDeploymentSku sku = null, string connectionName = null) { throw null; }
        public static Azure.AI.Projects.ModelDeploymentSku ModelDeploymentSku(long capacity = (long)0, string family = null, string name = null, string size = null, string tier = null) { throw null; }
        public static Azure.AI.Projects.ModelResponseGenerationTarget ModelResponseGenerationTarget(System.Collections.Generic.IEnumerable<Azure.AI.Projects.Message> baseMessages = null, string modelDeploymentName = null, System.Collections.Generic.IDictionary<string, System.BinaryData> modelParams = null) { throw null; }
        public static Azure.AI.Projects.NoAuthenticationCredentials NoAuthenticationCredentials() { throw null; }
        public static Azure.AI.Projects.PendingUploadConfiguration PendingUploadConfiguration(string pendingUploadId = null, string connectionName = null, Azure.AI.Projects.PendingUploadType pendingUploadType = default(Azure.AI.Projects.PendingUploadType)) { throw null; }
        public static Azure.AI.Projects.PendingUploadResult PendingUploadResult(Azure.AI.Projects.BlobReference blobReference = null, string pendingUploadId = null, string version = null, Azure.AI.Projects.PendingUploadType pendingUploadType = default(Azure.AI.Projects.PendingUploadType)) { throw null; }
        public static Azure.AI.Projects.RedTeam RedTeam(string name = null, string displayName = null, int? numTurns = default(int?), System.Collections.Generic.IEnumerable<Azure.AI.Projects.AttackStrategy> attackStrategies = null, bool? simulationOnly = default(bool?), System.Collections.Generic.IEnumerable<Azure.AI.Projects.RiskCategory> riskCategories = null, string applicationScenario = null, System.Collections.Generic.IDictionary<string, string> tags = null, System.Collections.Generic.IDictionary<string, string> properties = null, string status = null, Azure.AI.Projects.TargetConfig target = null) { throw null; }
        public static Azure.AI.Projects.SASCredentials SASCredentials(string sasToken = null) { throw null; }
        public static Azure.AI.Projects.SearchIndex SearchIndex(string type = null, string id = null, string name = null, string version = null, string description = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.AI.Projects.SystemMessage SystemMessage(string content = null) { throw null; }
        public static Azure.AI.Projects.TargetConfig TargetConfig(string type = null) { throw null; }
        public static Azure.AI.Projects.UserMessage UserMessage(string content = null) { throw null; }
    }
    public partial class AzureAISearchIndex : Azure.AI.Projects.SearchIndex, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AzureAISearchIndex>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AzureAISearchIndex>
    {
        public AzureAISearchIndex(string connectionName, string indexName) { }
        public string ConnectionName { get { throw null; } set { } }
        public Azure.AI.Projects.FieldMapping FieldMapping { get { throw null; } set { } }
        public string IndexName { get { throw null; } set { } }
        protected override Azure.AI.Projects.SearchIndex JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.SearchIndex PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected override Azure.AI.Projects.TargetConfig JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.TargetConfig PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.AzureOpenAIModelConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AzureOpenAIModelConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AzureOpenAIModelConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AzureOpenAIModelConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AzureOpenAIModelConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AzureOpenAIModelConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AzureOpenAIModelConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class ConnectionsOperations
    {
        protected ConnectionsOperations() { }
        public System.ClientModel.Primitives.ClientPipeline Pipeline { get { throw null; } }
        public virtual Azure.AI.Projects.ConnectionProperties GetConnection(string connectionName, bool includeCredentials = false, string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.ConnectionProperties>> GetConnectionAsync(string connectionName, bool includeCredentials = false, string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Projects.ConnectionProperties> GetConnections(Azure.AI.Projects.ConnectionType? connectionType = default(Azure.AI.Projects.ConnectionType?), bool? defaultConnection = default(bool?), string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.CollectionResult GetConnections(string connectionType, bool? defaultConnection, string clientRequestId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Projects.ConnectionProperties> GetConnectionsAsync(Azure.AI.Projects.ConnectionType? connectionType = default(Azure.AI.Projects.ConnectionType?), bool? defaultConnection = default(bool?), string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.AsyncCollectionResult GetConnectionsAsync(string connectionType, bool? defaultConnection, string clientRequestId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual Azure.AI.Projects.ConnectionProperties GetDefaultConnection(Azure.AI.Projects.ConnectionType? connectionType = default(Azure.AI.Projects.ConnectionType?), bool includeCredentials = false) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.Projects.ConnectionProperties> GetDefaultConnectionAsync(Azure.AI.Projects.ConnectionType? connectionType = default(Azure.AI.Projects.ConnectionType?), bool includeCredentials = false) { throw null; }
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
    public partial class CosmosDBIndex : Azure.AI.Projects.SearchIndex, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.CosmosDBIndex>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.CosmosDBIndex>
    {
        public CosmosDBIndex(string connectionName, string databaseName, string containerName, Azure.AI.Projects.EmbeddingConfiguration embeddingConfiguration, Azure.AI.Projects.FieldMapping fieldMapping) { }
        public string ConnectionName { get { throw null; } set { } }
        public string ContainerName { get { throw null; } set { } }
        public string DatabaseName { get { throw null; } set { } }
        public Azure.AI.Projects.EmbeddingConfiguration EmbeddingConfiguration { get { throw null; } set { } }
        public Azure.AI.Projects.FieldMapping FieldMapping { get { throw null; } set { } }
        protected override Azure.AI.Projects.SearchIndex JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.SearchIndex PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class DatasetCredential : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.DatasetCredential>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.DatasetCredential>
    {
        internal DatasetCredential() { }
        public Azure.AI.Projects.BlobReference BlobReference { get { throw null; } }
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
    public partial class DatasetsOperations
    {
        protected DatasetsOperations() { }
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
    public partial class DeploymentsOperations
    {
        protected DeploymentsOperations() { }
        public System.ClientModel.Primitives.ClientPipeline Pipeline { get { throw null; } }
        public virtual System.ClientModel.ClientResult GetDeployment(string name, string clientRequestId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.AssetDeployment> GetDeployment(string name, string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> GetDeploymentAsync(string name, string clientRequestId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.AssetDeployment>> GetDeploymentAsync(string name, string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Projects.AssetDeployment> GetDeployments(string modelPublisher = null, string modelName = null, Azure.AI.Projects.DeploymentType? deploymentType = default(Azure.AI.Projects.DeploymentType?), string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.CollectionResult GetDeployments(string modelPublisher, string modelName, string deploymentType, string clientRequestId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Projects.AssetDeployment> GetDeploymentsAsync(string modelPublisher = null, string modelName = null, Azure.AI.Projects.DeploymentType? deploymentType = default(Azure.AI.Projects.DeploymentType?), string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.AsyncCollectionResult GetDeploymentsAsync(string modelPublisher, string modelName, string deploymentType, string clientRequestId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
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
        public static implicit operator Azure.AI.Projects.DeploymentType? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.DeploymentType left, Azure.AI.Projects.DeploymentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DeveloperMessage : Azure.AI.Projects.Message, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.DeveloperMessage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.DeveloperMessage>
    {
        public DeveloperMessage(string content) { }
        public string Content { get { throw null; } set { } }
        protected override Azure.AI.Projects.Message JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Message PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.DeveloperMessage System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.DeveloperMessage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.DeveloperMessage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.DeveloperMessage System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.DeveloperMessage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.DeveloperMessage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.DeveloperMessage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public Azure.AI.Projects.EvaluationTarget Target { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Evaluation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Projects.Evaluation (System.ClientModel.ClientResult result) { throw null; }
        public static implicit operator System.ClientModel.BinaryContent (Azure.AI.Projects.Evaluation evaluation) { throw null; }
        protected virtual Azure.AI.Projects.Evaluation PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class Evaluations
    {
        protected Evaluations() { }
        public System.ClientModel.Primitives.ClientPipeline Pipeline { get { throw null; } }
        public virtual System.ClientModel.ClientResult Cancel(string name, string clientRequestId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult Cancel(string name, string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> CancelAsync(string name, string clientRequestId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> CancelAsync(string name, string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Evaluation> Create(Azure.AI.Projects.Evaluation evaluation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult Create(System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.AgentEvaluation> CreateAgentEvaluation(Azure.AI.Projects.AgentEvaluationRequest evaluation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult CreateAgentEvaluation(System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.AgentEvaluation>> CreateAgentEvaluationAsync(Azure.AI.Projects.AgentEvaluationRequest evaluation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> CreateAgentEvaluationAsync(System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Evaluation>> CreateAsync(Azure.AI.Projects.Evaluation evaluation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> CreateAsync(System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult Delete(string name, string clientRequestId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult Delete(string name, string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> DeleteAsync(string name, string clientRequestId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> DeleteAsync(string name, string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult Get(string name, string clientRequestId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Evaluation> Get(string name, string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.CollectionResult GetAll(string clientRequestId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Projects.Evaluation> GetAll(string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.AsyncCollectionResult GetAllAsync(string clientRequestId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Projects.Evaluation> GetAllAsync(string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> GetAsync(string name, string clientRequestId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Evaluation>> GetAsync(string name, string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public abstract partial class EvaluationTarget : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.EvaluationTarget>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EvaluationTarget>
    {
        internal EvaluationTarget() { }
        protected virtual Azure.AI.Projects.EvaluationTarget JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.EvaluationTarget PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.EvaluationTarget System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.EvaluationTarget>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.EvaluationTarget>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.EvaluationTarget System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EvaluationTarget>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EvaluationTarget>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EvaluationTarget>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EvaluatorConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.EvaluatorConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EvaluatorConfiguration>
    {
        public EvaluatorConfiguration(string id) { }
        public System.Collections.Generic.IDictionary<string, string> DataMapping { get { throw null; } }
        public string Id { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> InitParams { get { throw null; } }
        protected virtual Azure.AI.Projects.EvaluatorConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.EvaluatorConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class IndexesOperations
    {
        protected IndexesOperations() { }
        public System.ClientModel.Primitives.ClientPipeline Pipeline { get { throw null; } }
        public virtual System.ClientModel.ClientResult CreateOrUpdate(string name, string version, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> CreateOrUpdateAsync(string name, string version, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult Delete(string name, string version, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult Delete(string name, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> DeleteAsync(string name, string version, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> DeleteAsync(string name, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult GetIndex(string name, string version, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.SearchIndex> GetIndex(string name, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> GetIndexAsync(string name, string version, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.SearchIndex>> GetIndexAsync(string name, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.CollectionResult GetIndexes(System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Projects.SearchIndex> GetIndexes(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.AsyncCollectionResult GetIndexesAsync(System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Projects.SearchIndex> GetIndexesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.CollectionResult GetIndexVersions(string name, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Projects.SearchIndex> GetIndexVersions(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.AsyncCollectionResult GetIndexVersionsAsync(string name, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Projects.SearchIndex> GetIndexVersionsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public abstract partial class InputData : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.InputData>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.InputData>
    {
        internal InputData() { }
        protected virtual Azure.AI.Projects.InputData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.InputData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected override Azure.AI.Projects.InputData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.InputData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.InputDataset System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.InputDataset>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.InputDataset>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.InputDataset System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.InputDataset>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.InputDataset>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.InputDataset>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ManagedAzureAISearchIndex : Azure.AI.Projects.SearchIndex, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ManagedAzureAISearchIndex>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ManagedAzureAISearchIndex>
    {
        public ManagedAzureAISearchIndex(string vectorStoreId) { }
        public string VectorStoreId { get { throw null; } set { } }
        protected override Azure.AI.Projects.SearchIndex JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.SearchIndex PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.ManagedAzureAISearchIndex System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ManagedAzureAISearchIndex>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ManagedAzureAISearchIndex>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.ManagedAzureAISearchIndex System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ManagedAzureAISearchIndex>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ManagedAzureAISearchIndex>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ManagedAzureAISearchIndex>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class Message : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Message>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Message>
    {
        internal Message() { }
        protected virtual Azure.AI.Projects.Message JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Message PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Message System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Message>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Message>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Message System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Message>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Message>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Message>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ModelDeployment : Azure.AI.Projects.AssetDeployment, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ModelDeployment>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ModelDeployment>
    {
        internal ModelDeployment() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Capabilities { get { throw null; } }
        public string ConnectionName { get { throw null; } }
        public string ModelName { get { throw null; } }
        public string ModelPublisher { get { throw null; } }
        public string ModelVersion { get { throw null; } }
        public Azure.AI.Projects.ModelDeploymentSku Sku { get { throw null; } }
        protected override Azure.AI.Projects.AssetDeployment JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.AssetDeployment PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class ModelResponseGenerationTarget : Azure.AI.Projects.EvaluationTarget, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ModelResponseGenerationTarget>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ModelResponseGenerationTarget>
    {
        public ModelResponseGenerationTarget(System.Collections.Generic.IEnumerable<Azure.AI.Projects.Message> baseMessages, string modelDeploymentName, System.Collections.Generic.IDictionary<string, System.BinaryData> modelParams) { }
        public System.Collections.Generic.IList<Azure.AI.Projects.Message> BaseMessages { get { throw null; } }
        public string ModelDeploymentName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> ModelParams { get { throw null; } }
        protected override Azure.AI.Projects.EvaluationTarget JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.EvaluationTarget PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.ModelResponseGenerationTarget System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ModelResponseGenerationTarget>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ModelResponseGenerationTarget>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.ModelResponseGenerationTarget System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ModelResponseGenerationTarget>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ModelResponseGenerationTarget>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ModelResponseGenerationTarget>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public Azure.AI.Projects.BlobReference BlobReference { get { throw null; } }
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
        protected virtual Azure.AI.Projects.RedTeam JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Projects.RedTeam (System.ClientModel.ClientResult result) { throw null; }
        public static implicit operator System.ClientModel.BinaryContent (Azure.AI.Projects.RedTeam redTeam) { throw null; }
        protected virtual Azure.AI.Projects.RedTeam PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.RedTeam System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RedTeam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RedTeam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RedTeam System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RedTeam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RedTeam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RedTeam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RedTeams
    {
        protected RedTeams() { }
        public System.ClientModel.Primitives.ClientPipeline Pipeline { get { throw null; } }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.RedTeam> Create(Azure.AI.Projects.RedTeam redTeam, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult Create(System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.RedTeam>> CreateAsync(Azure.AI.Projects.RedTeam redTeam, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> CreateAsync(System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult Get(string name, string clientRequestId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.RedTeam> Get(string name, string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.CollectionResult GetAll(string clientRequestId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Projects.RedTeam> GetAll(string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.AsyncCollectionResult GetAllAsync(string clientRequestId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Projects.RedTeam> GetAllAsync(string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> GetAsync(string name, string clientRequestId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.RedTeam>> GetAsync(string name, string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public static implicit operator Azure.AI.Projects.RiskCategory? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.RiskCategory left, Azure.AI.Projects.RiskCategory right) { throw null; }
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
    public abstract partial class SearchIndex : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.SearchIndex>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.SearchIndex>
    {
        internal SearchIndex() { }
        public string Description { get { throw null; } set { } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual Azure.AI.Projects.SearchIndex JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Projects.SearchIndex (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.Projects.SearchIndex PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.SearchIndex System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.SearchIndex>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.SearchIndex>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.SearchIndex System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.SearchIndex>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.SearchIndex>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.SearchIndex>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SystemMessage : Azure.AI.Projects.Message, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.SystemMessage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.SystemMessage>
    {
        public SystemMessage(string content) { }
        public string Content { get { throw null; } set { } }
        protected override Azure.AI.Projects.Message JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Message PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.SystemMessage System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.SystemMessage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.SystemMessage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.SystemMessage System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.SystemMessage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.SystemMessage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.SystemMessage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class TargetConfig : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.TargetConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.TargetConfig>
    {
        internal TargetConfig() { }
        protected virtual Azure.AI.Projects.TargetConfig JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.TargetConfig PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.TargetConfig System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.TargetConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.TargetConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.TargetConfig System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.TargetConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.TargetConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.TargetConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class Telemetry
    {
        public Telemetry(Azure.AI.Projects.AIProjectClient outerInstance) { }
        public string GetApplicationInsightsConnectionString() { throw null; }
        public System.Threading.Tasks.Task<string> GetApplicationInsightsConnectionStringAsync() { throw null; }
    }
    public partial class UserMessage : Azure.AI.Projects.Message, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.UserMessage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.UserMessage>
    {
        public UserMessage(string content) { }
        public string Content { get { throw null; } set { } }
        protected override Azure.AI.Projects.Message JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Message PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.UserMessage System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.UserMessage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.UserMessage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.UserMessage System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.UserMessage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.UserMessage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.UserMessage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
