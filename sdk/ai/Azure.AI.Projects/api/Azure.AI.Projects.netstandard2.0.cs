namespace Azure.AI.Projects
{
    public partial class AIProjectClient
    {
        protected AIProjectClient() { }
        public AIProjectClient(string connectionString, Azure.Core.TokenCredential credential) { }
        public AIProjectClient(string connectionString, Azure.Core.TokenCredential credential, Azure.AI.Projects.AIProjectClientOptions options) { }
        public AIProjectClient(System.Uri endpoint, string subscriptionId, string resourceGroupName, string projectName, Azure.Core.TokenCredential credential) { }
        public AIProjectClient(System.Uri endpoint, string subscriptionId, string resourceGroupName, string projectName, Azure.Core.TokenCredential credential, Azure.AI.Projects.AIProjectClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.AI.Agents.AgentsClient GetAgentsClient() { throw null; }
        public virtual Azure.AI.Inference.ChatCompletionsClient GetChatCompletionsClient() { throw null; }
        public virtual Azure.AI.Projects.ConnectionsClient GetConnectionsClient(string apiVersion = "2024-07-01-preview") { throw null; }
        public virtual Azure.AI.Inference.EmbeddingsClient GetEmbeddingsClient() { throw null; }
        public virtual Azure.AI.Projects.EvaluationsClient GetEvaluationsClient(string apiVersion = "2024-07-01-preview") { throw null; }
        public virtual Azure.AI.Projects.TelemetryClient GetTelemetryClient(string apiVersion = "2024-07-01-preview") { throw null; }
    }
    public partial class AIProjectClientOptions : Azure.Core.ClientOptions
    {
        public AIProjectClientOptions(Azure.AI.Projects.AIProjectClientOptions.ServiceVersion version = Azure.AI.Projects.AIProjectClientOptions.ServiceVersion.V2024_07_01_Preview) { }
        public enum ServiceVersion
        {
            V2024_07_01_Preview = 1,
        }
    }
    public static partial class AIProjectsModelFactory
    {
        public static Azure.AI.Projects.ConnectionProperties ConnectionProperties(Azure.AI.Projects.ConnectionType category = Azure.AI.Projects.ConnectionType.AzureOpenAI, string target = null) { throw null; }
        public static Azure.AI.Projects.ConnectionPropertiesApiKeyAuth ConnectionPropertiesApiKeyAuth(Azure.AI.Projects.ConnectionType category = Azure.AI.Projects.ConnectionType.AzureOpenAI, string target = null, Azure.AI.Projects.CredentialsApiKeyAuth credentials = null) { throw null; }
        public static Azure.AI.Projects.ConnectionResponse ConnectionResponse(string id = null, string name = null, Azure.AI.Projects.ConnectionProperties properties = null) { throw null; }
        public static Azure.AI.Projects.CredentialsApiKeyAuth CredentialsApiKeyAuth(string key = null) { throw null; }
        public static Azure.AI.Projects.Evaluation Evaluation(string id = null, Azure.AI.Projects.InputData data = null, string displayName = null, string description = null, Azure.AI.Projects.SystemData systemData = null, string status = null, System.Collections.Generic.IDictionary<string, string> tags = null, System.Collections.Generic.IDictionary<string, string> properties = null, System.Collections.Generic.IDictionary<string, Azure.AI.Projects.EvaluatorConfiguration> evaluators = null) { throw null; }
        public static Azure.AI.Projects.EvaluationSchedule EvaluationSchedule(string name = null, Azure.AI.Projects.ApplicationInsightsConfiguration data = null, string description = null, Azure.AI.Projects.SystemData systemData = null, string provisioningState = null, System.Collections.Generic.IDictionary<string, string> tags = null, System.Collections.Generic.IDictionary<string, string> properties = null, string isEnabled = null, System.Collections.Generic.IDictionary<string, Azure.AI.Projects.EvaluatorConfiguration> evaluators = null, Azure.AI.Projects.Trigger trigger = null) { throw null; }
        public static Azure.AI.Projects.GetWorkspaceResponse GetWorkspaceResponse(string id = null, string name = null, Azure.AI.Projects.WorkspaceProperties properties = null) { throw null; }
        public static Azure.AI.Projects.InternalConnectionPropertiesNoAuth InternalConnectionPropertiesNoAuth(Azure.AI.Projects.ConnectionType category = Azure.AI.Projects.ConnectionType.AzureOpenAI, string target = null) { throw null; }
        public static Azure.AI.Projects.ListConnectionsResponse ListConnectionsResponse(System.Collections.Generic.IEnumerable<Azure.AI.Projects.ConnectionResponse> value = null) { throw null; }
        public static Azure.AI.Projects.SystemData SystemData(System.DateTimeOffset? createdAt = default(System.DateTimeOffset?), string createdBy = null, string createdByType = null, System.DateTimeOffset? lastModifiedAt = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.AI.Projects.WorkspaceProperties WorkspaceProperties(string applicationInsights = null) { throw null; }
    }
    public partial class ApplicationInsightsConfiguration : Azure.AI.Projects.InputData, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ApplicationInsightsConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ApplicationInsightsConfiguration>
    {
        public ApplicationInsightsConfiguration(string resourceId, string query) { }
        public string ConnectionString { get { throw null; } set { } }
        public string Query { get { throw null; } set { } }
        public string ResourceId { get { throw null; } set { } }
        public string ServiceName { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.ApplicationInsightsConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ApplicationInsightsConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ApplicationInsightsConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.ApplicationInsightsConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ApplicationInsightsConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ApplicationInsightsConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ApplicationInsightsConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum AuthenticationType
    {
        ApiKey = 0,
        EntraId = 1,
        SAS = 2,
        None = 3,
    }
    public abstract partial class ConnectionProperties : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ConnectionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ConnectionProperties>
    {
        protected ConnectionProperties(Azure.AI.Projects.ConnectionType category, string target) { }
        public Azure.AI.Projects.AuthenticationType AuthType { get { throw null; } set { } }
        public Azure.AI.Projects.ConnectionType Category { get { throw null; } }
        public string Target { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.ConnectionProperties System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ConnectionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ConnectionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.ConnectionProperties System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ConnectionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ConnectionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ConnectionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectionPropertiesApiKeyAuth : Azure.AI.Projects.ConnectionProperties, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ConnectionPropertiesApiKeyAuth>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ConnectionPropertiesApiKeyAuth>
    {
        internal ConnectionPropertiesApiKeyAuth() : base (default(Azure.AI.Projects.ConnectionType), default(string)) { }
        public Azure.AI.Projects.CredentialsApiKeyAuth Credentials { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.ConnectionPropertiesApiKeyAuth System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ConnectionPropertiesApiKeyAuth>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ConnectionPropertiesApiKeyAuth>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.ConnectionPropertiesApiKeyAuth System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ConnectionPropertiesApiKeyAuth>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ConnectionPropertiesApiKeyAuth>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ConnectionPropertiesApiKeyAuth>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectionResponse : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ConnectionResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ConnectionResponse>
    {
        internal ConnectionResponse() { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.AI.Projects.ConnectionProperties Properties { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.ConnectionResponse System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ConnectionResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ConnectionResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.ConnectionResponse System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ConnectionResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ConnectionResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ConnectionResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectionsClient
    {
        protected ConnectionsClient() { }
        public ConnectionsClient(string connectionString, Azure.Core.TokenCredential credential) { }
        public ConnectionsClient(string connectionString, Azure.Core.TokenCredential credential, Azure.AI.Projects.AIProjectClientOptions options) { }
        public ConnectionsClient(System.Uri endpoint, string subscriptionId, string resourceGroupName, string projectName, Azure.Core.TokenCredential credential) { }
        public ConnectionsClient(System.Uri endpoint, string subscriptionId, string resourceGroupName, string projectName, Azure.Core.TokenCredential credential, Azure.AI.Projects.AIProjectClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response GetConnection(string connectionName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Projects.ConnectionResponse> GetConnection(string connectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetConnectionAsync(string connectionName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Projects.ConnectionResponse>> GetConnectionAsync(string connectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Projects.ListConnectionsResponse> GetConnections(Azure.AI.Projects.ConnectionType? category = default(Azure.AI.Projects.ConnectionType?), bool? includeAll = default(bool?), string target = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetConnections(string category, bool? includeAll, string target, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Projects.ListConnectionsResponse>> GetConnectionsAsync(Azure.AI.Projects.ConnectionType? category = default(Azure.AI.Projects.ConnectionType?), bool? includeAll = default(bool?), string target = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetConnectionsAsync(string category, bool? includeAll, string target, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response GetConnectionWithSecrets(string connectionName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Projects.ConnectionResponse> GetConnectionWithSecrets(string connectionName, string ignored, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetConnectionWithSecretsAsync(string connectionName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Projects.ConnectionResponse>> GetConnectionWithSecretsAsync(string connectionName, string ignored, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Projects.ConnectionResponse> GetDefaultConnection(Azure.AI.Projects.ConnectionType category, bool? withCredential = default(bool?), bool? includeAll = default(bool?), string target = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Projects.ConnectionResponse>> GetDefaultConnectionAsync(Azure.AI.Projects.ConnectionType category, bool? withCredential = default(bool?), bool? includeAll = default(bool?), string target = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetWorkspace(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Projects.GetWorkspaceResponse> GetWorkspace(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetWorkspaceAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Projects.GetWorkspaceResponse>> GetWorkspaceAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public enum ConnectionType
    {
        AzureOpenAI = 0,
        Serverless = 1,
        AzureBlobStorage = 2,
        AzureAIServices = 3,
        AzureAISearch = 4,
        ApiKey = 5,
    }
    public partial class CredentialsApiKeyAuth : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.CredentialsApiKeyAuth>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.CredentialsApiKeyAuth>
    {
        internal CredentialsApiKeyAuth() { }
        public string Key { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.CredentialsApiKeyAuth System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.CredentialsApiKeyAuth>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.CredentialsApiKeyAuth>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.CredentialsApiKeyAuth System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.CredentialsApiKeyAuth>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.CredentialsApiKeyAuth>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.CredentialsApiKeyAuth>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CronTrigger : Azure.AI.Projects.Trigger, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.CronTrigger>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.CronTrigger>
    {
        public CronTrigger(string expression) { }
        public string Expression { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.CronTrigger System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.CronTrigger>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.CronTrigger>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.CronTrigger System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.CronTrigger>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.CronTrigger>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.CronTrigger>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class Dataset : Azure.AI.Projects.InputData, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Dataset>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Dataset>
    {
        public Dataset(string id) { }
        public string Id { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Dataset System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Dataset>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Dataset>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Dataset System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Dataset>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Dataset>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Dataset>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class Evaluation : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation>
    {
        public Evaluation(Azure.AI.Projects.InputData data, System.Collections.Generic.IDictionary<string, Azure.AI.Projects.EvaluatorConfiguration> evaluators) { }
        public Azure.AI.Projects.InputData Data { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.AI.Projects.EvaluatorConfiguration> Evaluators { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Properties { get { throw null; } }
        public string Status { get { throw null; } }
        public Azure.AI.Projects.SystemData SystemData { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EvaluationSchedule : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.EvaluationSchedule>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EvaluationSchedule>
    {
        public EvaluationSchedule(Azure.AI.Projects.ApplicationInsightsConfiguration data, System.Collections.Generic.IDictionary<string, Azure.AI.Projects.EvaluatorConfiguration> evaluators, Azure.AI.Projects.Trigger trigger) { }
        public Azure.AI.Projects.ApplicationInsightsConfiguration Data { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.AI.Projects.EvaluatorConfiguration> Evaluators { get { throw null; } }
        public string IsEnabled { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Properties { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.AI.Projects.SystemData SystemData { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public Azure.AI.Projects.Trigger Trigger { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.EvaluationSchedule System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.EvaluationSchedule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.EvaluationSchedule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.EvaluationSchedule System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EvaluationSchedule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EvaluationSchedule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EvaluationSchedule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EvaluationsClient
    {
        protected EvaluationsClient() { }
        public EvaluationsClient(string connectionString, Azure.Core.TokenCredential credential) { }
        public EvaluationsClient(string connectionString, Azure.Core.TokenCredential credential, Azure.AI.Projects.AIProjectClientOptions options) { }
        public EvaluationsClient(System.Uri endpoint, string subscriptionId, string resourceGroupName, string projectName, Azure.Core.TokenCredential credential) { }
        public EvaluationsClient(System.Uri endpoint, string subscriptionId, string resourceGroupName, string projectName, Azure.Core.TokenCredential credential, Azure.AI.Projects.AIProjectClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response<Azure.AI.Projects.Evaluation> Create(Azure.AI.Projects.Evaluation evaluation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Create(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Projects.Evaluation>> CreateAsync(Azure.AI.Projects.Evaluation evaluation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Projects.EvaluationSchedule> CreateOrReplaceSchedule(string name, Azure.AI.Projects.EvaluationSchedule resource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateOrReplaceSchedule(string name, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Projects.EvaluationSchedule>> CreateOrReplaceScheduleAsync(string name, Azure.AI.Projects.EvaluationSchedule resource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrReplaceScheduleAsync(string name, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DisableSchedule(string name, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DisableScheduleAsync(string name, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetEvaluation(string id, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Projects.Evaluation> GetEvaluation(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetEvaluationAsync(string id, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Projects.Evaluation>> GetEvaluationAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetEvaluations(int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Projects.Evaluation> GetEvaluations(int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetEvaluationsAsync(int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Projects.Evaluation> GetEvaluationsAsync(int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetSchedule(string name, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Projects.EvaluationSchedule> GetSchedule(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetScheduleAsync(string name, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Projects.EvaluationSchedule>> GetScheduleAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetSchedules(int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Projects.EvaluationSchedule> GetSchedules(int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetSchedulesAsync(int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Projects.EvaluationSchedule> GetSchedulesAsync(int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Update(string id, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateAsync(string id, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Frequency : System.IEquatable<Azure.AI.Projects.Frequency>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Frequency(string value) { throw null; }
        public static Azure.AI.Projects.Frequency Day { get { throw null; } }
        public static Azure.AI.Projects.Frequency Hour { get { throw null; } }
        public static Azure.AI.Projects.Frequency Minute { get { throw null; } }
        public static Azure.AI.Projects.Frequency Month { get { throw null; } }
        public static Azure.AI.Projects.Frequency Week { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Frequency other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Frequency left, Azure.AI.Projects.Frequency right) { throw null; }
        public static implicit operator Azure.AI.Projects.Frequency (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Frequency left, Azure.AI.Projects.Frequency right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class GetWorkspaceResponse : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.GetWorkspaceResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.GetWorkspaceResponse>
    {
        internal GetWorkspaceResponse() { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.AI.Projects.WorkspaceProperties Properties { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.GetWorkspaceResponse System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.GetWorkspaceResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.GetWorkspaceResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.GetWorkspaceResponse System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.GetWorkspaceResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.GetWorkspaceResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.GetWorkspaceResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class InternalConnectionPropertiesNoAuth : Azure.AI.Projects.ConnectionProperties, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.InternalConnectionPropertiesNoAuth>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.InternalConnectionPropertiesNoAuth>
    {
        internal InternalConnectionPropertiesNoAuth() : base (default(Azure.AI.Projects.ConnectionType), default(string)) { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.InternalConnectionPropertiesNoAuth System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.InternalConnectionPropertiesNoAuth>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.InternalConnectionPropertiesNoAuth>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.InternalConnectionPropertiesNoAuth System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.InternalConnectionPropertiesNoAuth>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.InternalConnectionPropertiesNoAuth>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.InternalConnectionPropertiesNoAuth>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ListConnectionsResponse : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ListConnectionsResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ListConnectionsResponse>
    {
        internal ListConnectionsResponse() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Projects.ConnectionResponse> Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.ListConnectionsResponse System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ListConnectionsResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ListConnectionsResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.ListConnectionsResponse System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ListConnectionsResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ListConnectionsResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ListConnectionsResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RecurrenceSchedule : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RecurrenceSchedule>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RecurrenceSchedule>
    {
        public RecurrenceSchedule(System.Collections.Generic.IEnumerable<int> hours, System.Collections.Generic.IEnumerable<int> minutes) { }
        public System.Collections.Generic.IList<int> Hours { get { throw null; } }
        public System.Collections.Generic.IList<int> Minutes { get { throw null; } }
        public System.Collections.Generic.IList<int> MonthDays { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Projects.WeekDays> WeekDays { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RecurrenceSchedule System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RecurrenceSchedule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RecurrenceSchedule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RecurrenceSchedule System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RecurrenceSchedule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RecurrenceSchedule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RecurrenceSchedule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RecurrenceTrigger : Azure.AI.Projects.Trigger, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RecurrenceTrigger>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RecurrenceTrigger>
    {
        public RecurrenceTrigger(Azure.AI.Projects.Frequency frequency, int interval) { }
        public Azure.AI.Projects.Frequency Frequency { get { throw null; } set { } }
        public int Interval { get { throw null; } set { } }
        public Azure.AI.Projects.RecurrenceSchedule Schedule { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RecurrenceTrigger System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RecurrenceTrigger>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RecurrenceTrigger>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RecurrenceTrigger System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RecurrenceTrigger>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RecurrenceTrigger>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RecurrenceTrigger>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SystemData : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.SystemData>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.SystemData>
    {
        internal SystemData() { }
        public System.DateTimeOffset? CreatedAt { get { throw null; } }
        public string CreatedBy { get { throw null; } }
        public string CreatedByType { get { throw null; } }
        public System.DateTimeOffset? LastModifiedAt { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.SystemData System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.SystemData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.SystemData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.SystemData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.SystemData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.SystemData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.SystemData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TelemetryClient
    {
        protected TelemetryClient() { }
        public TelemetryClient(string connectionString, Azure.Core.TokenCredential credential) { }
        public TelemetryClient(string connectionString, Azure.Core.TokenCredential credential, Azure.AI.Projects.AIProjectClientOptions options) { }
        public TelemetryClient(System.Uri endpoint, string subscriptionId, string resourceGroupName, string projectName, Azure.Core.TokenCredential credential) { }
        public TelemetryClient(System.Uri endpoint, string subscriptionId, string resourceGroupName, string projectName, Azure.Core.TokenCredential credential, Azure.AI.Projects.AIProjectClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
    }
    public abstract partial class Trigger : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Trigger>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Trigger>
    {
        protected Trigger() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Trigger System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Trigger>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Trigger>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Trigger System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Trigger>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Trigger>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Trigger>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WeekDays : System.IEquatable<Azure.AI.Projects.WeekDays>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WeekDays(string value) { throw null; }
        public static Azure.AI.Projects.WeekDays Friday { get { throw null; } }
        public static Azure.AI.Projects.WeekDays Monday { get { throw null; } }
        public static Azure.AI.Projects.WeekDays Saturday { get { throw null; } }
        public static Azure.AI.Projects.WeekDays Sunday { get { throw null; } }
        public static Azure.AI.Projects.WeekDays Thursday { get { throw null; } }
        public static Azure.AI.Projects.WeekDays Tuesday { get { throw null; } }
        public static Azure.AI.Projects.WeekDays Wednesday { get { throw null; } }
        public bool Equals(Azure.AI.Projects.WeekDays other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.WeekDays left, Azure.AI.Projects.WeekDays right) { throw null; }
        public static implicit operator Azure.AI.Projects.WeekDays (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.WeekDays left, Azure.AI.Projects.WeekDays right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WorkspaceProperties : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.WorkspaceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.WorkspaceProperties>
    {
        internal WorkspaceProperties() { }
        public string ApplicationInsights { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.WorkspaceProperties System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.WorkspaceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.WorkspaceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.WorkspaceProperties System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.WorkspaceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.WorkspaceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.WorkspaceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class AIProjectsClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Projects.AIProjectClient, Azure.AI.Projects.AIProjectClientOptions> AddAIProjectClient<TBuilder>(this TBuilder builder, System.Uri endpoint, string subscriptionId, string resourceGroupName, string projectName) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Projects.AIProjectClient, Azure.AI.Projects.AIProjectClientOptions> AddAIProjectClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
