namespace Azure.AI.Projects.Agents
{
    public partial class A2APreviewTool : Azure.AI.Projects.Agents.AgentTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.A2APreviewTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.A2APreviewTool>
    {
        public A2APreviewTool() { }
        public A2APreviewTool(System.Uri baseUri) { }
        public string AgentCardPath { get { throw null; } set { } }
        public System.Uri BaseUri { get { throw null; } set { } }
        public string ProjectConnectionId { get { throw null; } set { } }
        protected override Azure.AI.Projects.Agents.AgentTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.AgentTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.A2APreviewTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.A2APreviewTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.A2APreviewTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.A2APreviewTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.A2APreviewTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.A2APreviewTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.A2APreviewTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AgentCommunicationMethod : System.IEquatable<Azure.AI.Projects.Agents.AgentCommunicationMethod>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AgentCommunicationMethod(string value) { throw null; }
        public static Azure.AI.Projects.Agents.AgentCommunicationMethod ActivityProtocol { get { throw null; } }
        public static Azure.AI.Projects.Agents.AgentCommunicationMethod Responses { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Agents.AgentCommunicationMethod other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Agents.AgentCommunicationMethod left, Azure.AI.Projects.Agents.AgentCommunicationMethod right) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.AgentCommunicationMethod (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.AgentCommunicationMethod? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Agents.AgentCommunicationMethod left, Azure.AI.Projects.Agents.AgentCommunicationMethod right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class AgentDefinition : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentDefinition>
    {
        internal AgentDefinition() { }
        public Azure.AI.Projects.Agents.ContentFilterConfiguration ContentFilterConfiguration { get { throw null; } set { } }
        public static Azure.AI.Projects.Agents.HostedAgentDefinition CreateHostedAgentDefinition(System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.ProtocolVersionRecord> containerProtocolVersions, string cpuConfiguration, string memoryConfiguration) { throw null; }
        public static Azure.AI.Projects.Agents.PromptAgentDefinition CreatePromptAgentDefinition(string model) { throw null; }
        public static Azure.AI.Projects.Agents.WorkflowAgentDefinition CreateWorkflowAgentDefinitionFromYaml(string workflowYamlDocument) { throw null; }
        protected virtual Azure.AI.Projects.Agents.AgentDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.AgentDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.AgentDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.AgentDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AgentKind : System.IEquatable<Azure.AI.Projects.Agents.AgentKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AgentKind(string value) { throw null; }
        public static Azure.AI.Projects.Agents.AgentKind Hosted { get { throw null; } }
        public static Azure.AI.Projects.Agents.AgentKind Prompt { get { throw null; } }
        public static Azure.AI.Projects.Agents.AgentKind Workflow { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Agents.AgentKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Agents.AgentKind left, Azure.AI.Projects.Agents.AgentKind right) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.AgentKind (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.AgentKind? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Agents.AgentKind left, Azure.AI.Projects.Agents.AgentKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AgentListOrder : System.IEquatable<Azure.AI.Projects.Agents.AgentListOrder>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AgentListOrder(string value) { throw null; }
        public static Azure.AI.Projects.Agents.AgentListOrder Ascending { get { throw null; } }
        public static Azure.AI.Projects.Agents.AgentListOrder Descending { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Agents.AgentListOrder other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Agents.AgentListOrder left, Azure.AI.Projects.Agents.AgentListOrder right) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.AgentListOrder (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.AgentListOrder? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Agents.AgentListOrder left, Azure.AI.Projects.Agents.AgentListOrder right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AgentManifestOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentManifestOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentManifestOptions>
    {
        internal AgentManifestOptions() { }
        public string Description { get { throw null; } }
        public string ManifestId { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> ParameterValues { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.AgentManifestOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator System.ClientModel.BinaryContent (Azure.AI.Projects.Agents.AgentManifestOptions agentManifestOptions) { throw null; }
        protected virtual Azure.AI.Projects.Agents.AgentManifestOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.AgentManifestOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentManifestOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentManifestOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.AgentManifestOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentManifestOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentManifestOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentManifestOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentObjectVersions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentObjectVersions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentObjectVersions>
    {
        internal AgentObjectVersions() { }
        public Azure.AI.Projects.Agents.AgentVersion Latest { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.AgentObjectVersions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.AgentObjectVersions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.AgentObjectVersions System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentObjectVersions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentObjectVersions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.AgentObjectVersions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentObjectVersions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentObjectVersions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentObjectVersions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentRecord : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentRecord>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentRecord>
    {
        internal AgentRecord() { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.AI.Projects.Agents.AgentObjectVersions Versions { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.AgentRecord JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Projects.Agents.AgentRecord (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.Projects.Agents.AgentRecord PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.AgentRecord System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentRecord>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentRecord>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.AgentRecord System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentRecord>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentRecord>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentRecord>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class AgentReference
    {
    }
    public partial class AgentsClient
    {
        protected AgentsClient() { }
        public AgentsClient(System.ClientModel.AuthenticationTokenProvider tokenProvider, Azure.AI.Projects.Agents.AgentsClientOptions options) { }
        public System.ClientModel.Primitives.ClientPipeline Pipeline { get { throw null; } }
        public virtual System.ClientModel.ClientResult CreateAgent(System.ClientModel.BinaryContent content, string foundryFeatures = null, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> CreateAgentAsync(System.ClientModel.BinaryContent content, string foundryFeatures = null, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult CreateAgentFromManifest(System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> CreateAgentFromManifestAsync(System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Agents.AgentVersion> CreateAgentVersion(string agentName, Azure.AI.Projects.Agents.AgentVersionCreationOptions options, string foundryFeatures = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult CreateAgentVersion(string agentName, System.ClientModel.BinaryContent content, string foundryFeatures = null, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Agents.AgentVersion>> CreateAgentVersionAsync(string agentName, Azure.AI.Projects.Agents.AgentVersionCreationOptions options = null, string foundryFeatures = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> CreateAgentVersionAsync(string agentName, System.ClientModel.BinaryContent content, string foundryFeatures = null, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult CreateAgentVersionFromManifest(string agentName, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Agents.AgentVersion> CreateAgentVersionFromManifest(string agentName, string manifestId, Azure.AI.Projects.Agents.AgentManifestOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> CreateAgentVersionFromManifestAsync(string agentName, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Agents.AgentVersion>> CreateAgentVersionFromManifestAsync(string agentName, string manifestId, Azure.AI.Projects.Agents.AgentManifestOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult DeleteAgent(string agentName, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult DeleteAgent(string agentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> DeleteAgentAsync(string agentName, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> DeleteAgentAsync(string agentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult DeleteAgentVersion(string agentName, string agentVersion, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult DeleteAgentVersion(string agentName, string agentVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> DeleteAgentVersionAsync(string agentName, string agentVersion, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> DeleteAgentVersionAsync(string agentName, string agentVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult GetAgent(string agentName, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Agents.AgentRecord> GetAgent(string agentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> GetAgentAsync(string agentName, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Agents.AgentRecord>> GetAgentAsync(string agentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Projects.Agents.AgentRecord> GetAgents(Azure.AI.Projects.Agents.AgentKind? kind = default(Azure.AI.Projects.Agents.AgentKind?), int? limit = default(int?), Azure.AI.Projects.Agents.AgentListOrder? order = default(Azure.AI.Projects.Agents.AgentListOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Projects.Agents.AgentRecord> GetAgentsAsync(Azure.AI.Projects.Agents.AgentKind? kind = default(Azure.AI.Projects.Agents.AgentKind?), int? limit = default(int?), Azure.AI.Projects.Agents.AgentListOrder? order = default(Azure.AI.Projects.Agents.AgentListOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult GetAgentVersion(string agentName, string agentVersion, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Agents.AgentVersion> GetAgentVersion(string agentName, string agentVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> GetAgentVersionAsync(string agentName, string agentVersion, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Agents.AgentVersion>> GetAgentVersionAsync(string agentName, string agentVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Projects.Agents.AgentVersion> GetAgentVersions(string agentName, int? limit = default(int?), Azure.AI.Projects.Agents.AgentListOrder? order = default(Azure.AI.Projects.Agents.AgentListOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Projects.Agents.AgentVersion> GetAgentVersionsAsync(string agentName, int? limit = default(int?), Azure.AI.Projects.Agents.AgentListOrder? order = default(Azure.AI.Projects.Agents.AgentListOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult UpdateAgent(string agentName, System.ClientModel.BinaryContent content, string foundryFeatures = null, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> UpdateAgentAsync(string agentName, System.ClientModel.BinaryContent content, string foundryFeatures = null, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult UpdateAgentFromManifest(string agentName, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> UpdateAgentFromManifestAsync(string agentName, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
    }
    public partial class AgentsClientOptions : OpenAI.OpenAIClientOptions
    {
        public AgentsClientOptions() { }
        public string ApiVersion { get { throw null; } set { } }
    }
    public abstract partial class AgentTool : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentTool>
    {
        internal AgentTool() { }
        public static OpenAI.Responses.ResponseTool CreateA2ATool(System.Uri baseUri, string agentCardPath = null) { throw null; }
        public static Azure.AI.Projects.Agents.AzureAISearchTool CreateAzureAISearchTool(Azure.AI.Projects.Agents.AzureAISearchToolOptions options = null) { throw null; }
        public static Azure.AI.Projects.Agents.BingCustomSearchPreviewTool CreateBingCustomSearchTool(Azure.AI.Projects.Agents.BingCustomSearchToolParameters parameters) { throw null; }
        public static Azure.AI.Projects.Agents.BingGroundingTool CreateBingGroundingTool(Azure.AI.Projects.Agents.BingGroundingSearchToolOptions options) { throw null; }
        public static Azure.AI.Projects.Agents.BrowserAutomationPreviewTool CreateBrowserAutomationTool(Azure.AI.Projects.Agents.BrowserAutomationToolParameters parameters) { throw null; }
        public static Azure.AI.Projects.Agents.MicrosoftFabricPreviewTool CreateMicrosoftFabricTool(Azure.AI.Projects.Agents.FabricDataAgentToolOptions options) { throw null; }
        public static Azure.AI.Projects.Agents.OpenAPITool CreateOpenApiTool(Azure.AI.Projects.Agents.OpenAPIFunctionDefinition definition) { throw null; }
        public static Azure.AI.Projects.Agents.SharepointPreviewTool CreateSharepointTool(Azure.AI.Projects.Agents.SharePointGroundingToolOptions options) { throw null; }
        public static Azure.AI.Projects.Agents.CaptureStructuredOutputsTool CreateStructuredOutputsTool(Azure.AI.Projects.Agents.StructuredOutputDefinition outputs) { throw null; }
        protected virtual Azure.AI.Projects.Agents.AgentTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator OpenAI.Responses.ResponseTool (Azure.AI.Projects.Agents.AgentTool agentTool) { throw null; }
        protected virtual Azure.AI.Projects.Agents.AgentTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.AgentTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.AgentTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentVersion : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentVersion>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentVersion>
    {
        internal AgentVersion() { }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public Azure.AI.Projects.Agents.AgentDefinition Definition { get { throw null; } }
        public string Description { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public string Name { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.AgentVersion JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Projects.Agents.AgentVersion (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.Projects.Agents.AgentVersion PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.AgentVersion System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentVersion>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentVersion>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.AgentVersion System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentVersion>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentVersion>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentVersion>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentVersionCreationOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentVersionCreationOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentVersionCreationOptions>
    {
        public AgentVersionCreationOptions(Azure.AI.Projects.Agents.AgentDefinition definition) { }
        public Azure.AI.Projects.Agents.AgentDefinition Definition { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.AgentVersionCreationOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.AgentVersionCreationOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.AgentVersionCreationOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentVersionCreationOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentVersionCreationOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.AgentVersionCreationOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentVersionCreationOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentVersionCreationOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentVersionCreationOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureAIProjectsAgentsContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureAIProjectsAgentsContext() { }
        public static Azure.AI.Projects.Agents.AzureAIProjectsAgentsContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureAISearchQueryType : System.IEquatable<Azure.AI.Projects.Agents.AzureAISearchQueryType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureAISearchQueryType(string value) { throw null; }
        public static Azure.AI.Projects.Agents.AzureAISearchQueryType Semantic { get { throw null; } }
        public static Azure.AI.Projects.Agents.AzureAISearchQueryType Simple { get { throw null; } }
        public static Azure.AI.Projects.Agents.AzureAISearchQueryType Vector { get { throw null; } }
        public static Azure.AI.Projects.Agents.AzureAISearchQueryType VectorSemanticHybrid { get { throw null; } }
        public static Azure.AI.Projects.Agents.AzureAISearchQueryType VectorSimpleHybrid { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Agents.AzureAISearchQueryType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Agents.AzureAISearchQueryType left, Azure.AI.Projects.Agents.AzureAISearchQueryType right) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.AzureAISearchQueryType (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.AzureAISearchQueryType? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Agents.AzureAISearchQueryType left, Azure.AI.Projects.Agents.AzureAISearchQueryType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AzureAISearchTool : Azure.AI.Projects.Agents.AgentTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AzureAISearchTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AzureAISearchTool>
    {
        public AzureAISearchTool(Azure.AI.Projects.Agents.AzureAISearchToolOptions options) { }
        public Azure.AI.Projects.Agents.AzureAISearchToolOptions Options { get { throw null; } set { } }
        protected override Azure.AI.Projects.Agents.AgentTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.AgentTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.AzureAISearchTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AzureAISearchTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AzureAISearchTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.AzureAISearchTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AzureAISearchTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AzureAISearchTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AzureAISearchTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureAISearchToolIndex : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AzureAISearchToolIndex>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AzureAISearchToolIndex>
    {
        public AzureAISearchToolIndex() { }
        public string Filter { get { throw null; } set { } }
        public string IndexAssetId { get { throw null; } set { } }
        public string IndexName { get { throw null; } set { } }
        public string ProjectConnectionId { get { throw null; } set { } }
        public Azure.AI.Projects.Agents.AzureAISearchQueryType? QueryType { get { throw null; } set { } }
        public int? TopK { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Agents.AzureAISearchToolIndex JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.AzureAISearchToolIndex PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.AzureAISearchToolIndex System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AzureAISearchToolIndex>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AzureAISearchToolIndex>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.AzureAISearchToolIndex System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AzureAISearchToolIndex>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AzureAISearchToolIndex>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AzureAISearchToolIndex>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureAISearchToolOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AzureAISearchToolOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AzureAISearchToolOptions>
    {
        public AzureAISearchToolOptions(System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.AzureAISearchToolIndex> indexes) { }
        public System.Collections.Generic.IList<Azure.AI.Projects.Agents.AzureAISearchToolIndex> Indexes { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.AzureAISearchToolOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.AzureAISearchToolOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.AzureAISearchToolOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AzureAISearchToolOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AzureAISearchToolOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.AzureAISearchToolOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AzureAISearchToolOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AzureAISearchToolOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AzureAISearchToolOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureFunctionBinding : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AzureFunctionBinding>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AzureFunctionBinding>
    {
        public AzureFunctionBinding(Azure.AI.Projects.Agents.AzureFunctionStorageQueue storageQueue) { }
        public Azure.AI.Projects.Agents.AzureFunctionStorageQueue StorageQueue { get { throw null; } set { } }
        public string Type { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.AzureFunctionBinding JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.AzureFunctionBinding PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.AzureFunctionBinding System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AzureFunctionBinding>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AzureFunctionBinding>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.AzureFunctionBinding System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AzureFunctionBinding>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AzureFunctionBinding>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AzureFunctionBinding>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureFunctionDefinition : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AzureFunctionDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AzureFunctionDefinition>
    {
        public AzureFunctionDefinition(Azure.AI.Projects.Agents.AzureFunctionDefinitionFunction function, Azure.AI.Projects.Agents.AzureFunctionBinding inputBinding, Azure.AI.Projects.Agents.AzureFunctionBinding outputBinding) { }
        public Azure.AI.Projects.Agents.AzureFunctionDefinitionFunction Function { get { throw null; } set { } }
        public Azure.AI.Projects.Agents.AzureFunctionBinding InputBinding { get { throw null; } set { } }
        public Azure.AI.Projects.Agents.AzureFunctionBinding OutputBinding { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Agents.AzureFunctionDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.AzureFunctionDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.AzureFunctionDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AzureFunctionDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AzureFunctionDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.AzureFunctionDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AzureFunctionDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AzureFunctionDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AzureFunctionDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureFunctionDefinitionFunction : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AzureFunctionDefinitionFunction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AzureFunctionDefinitionFunction>
    {
        public AzureFunctionDefinitionFunction(string name, System.BinaryData parameters) { }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.BinaryData Parameters { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Agents.AzureFunctionDefinitionFunction JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.AzureFunctionDefinitionFunction PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.AzureFunctionDefinitionFunction System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AzureFunctionDefinitionFunction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AzureFunctionDefinitionFunction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.AzureFunctionDefinitionFunction System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AzureFunctionDefinitionFunction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AzureFunctionDefinitionFunction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AzureFunctionDefinitionFunction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureFunctionStorageQueue : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AzureFunctionStorageQueue>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AzureFunctionStorageQueue>
    {
        public AzureFunctionStorageQueue(string queueServiceEndpoint, string queueName) { }
        public string QueueName { get { throw null; } set { } }
        public string QueueServiceEndpoint { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Agents.AzureFunctionStorageQueue JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.AzureFunctionStorageQueue PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.AzureFunctionStorageQueue System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AzureFunctionStorageQueue>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AzureFunctionStorageQueue>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.AzureFunctionStorageQueue System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AzureFunctionStorageQueue>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AzureFunctionStorageQueue>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AzureFunctionStorageQueue>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureFunctionTool : Azure.AI.Projects.Agents.AgentTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AzureFunctionTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AzureFunctionTool>
    {
        public AzureFunctionTool(Azure.AI.Projects.Agents.AzureFunctionDefinition azureFunction) { }
        public Azure.AI.Projects.Agents.AzureFunctionDefinition AzureFunction { get { throw null; } set { } }
        protected override Azure.AI.Projects.Agents.AgentTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.AgentTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.AzureFunctionTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AzureFunctionTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AzureFunctionTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.AzureFunctionTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AzureFunctionTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AzureFunctionTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AzureFunctionTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BingCustomSearchConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.BingCustomSearchConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.BingCustomSearchConfiguration>
    {
        public BingCustomSearchConfiguration(string projectConnectionId, string instanceName) { }
        public long? Count { get { throw null; } set { } }
        public string Freshness { get { throw null; } set { } }
        public string InstanceName { get { throw null; } set { } }
        public string Market { get { throw null; } set { } }
        public string ProjectConnectionId { get { throw null; } set { } }
        public string SetLang { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Agents.BingCustomSearchConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.BingCustomSearchConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.BingCustomSearchConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.BingCustomSearchConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.BingCustomSearchConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.BingCustomSearchConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.BingCustomSearchConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.BingCustomSearchConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.BingCustomSearchConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BingCustomSearchPreviewTool : Azure.AI.Projects.Agents.AgentTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.BingCustomSearchPreviewTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.BingCustomSearchPreviewTool>
    {
        public BingCustomSearchPreviewTool(Azure.AI.Projects.Agents.BingCustomSearchToolParameters bingCustomSearchPreview) { }
        public Azure.AI.Projects.Agents.BingCustomSearchToolParameters BingCustomSearchPreview { get { throw null; } set { } }
        protected override Azure.AI.Projects.Agents.AgentTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.AgentTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.BingCustomSearchPreviewTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.BingCustomSearchPreviewTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.BingCustomSearchPreviewTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.BingCustomSearchPreviewTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.BingCustomSearchPreviewTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.BingCustomSearchPreviewTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.BingCustomSearchPreviewTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BingCustomSearchToolParameters : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.BingCustomSearchToolParameters>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.BingCustomSearchToolParameters>
    {
        public BingCustomSearchToolParameters(System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.BingCustomSearchConfiguration> searchConfigurations) { }
        public System.Collections.Generic.IList<Azure.AI.Projects.Agents.BingCustomSearchConfiguration> SearchConfigurations { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.BingCustomSearchToolParameters JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.BingCustomSearchToolParameters PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.BingCustomSearchToolParameters System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.BingCustomSearchToolParameters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.BingCustomSearchToolParameters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.BingCustomSearchToolParameters System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.BingCustomSearchToolParameters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.BingCustomSearchToolParameters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.BingCustomSearchToolParameters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BingGroundingSearchConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.BingGroundingSearchConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.BingGroundingSearchConfiguration>
    {
        public BingGroundingSearchConfiguration(string projectConnectionId) { }
        public long? Count { get { throw null; } set { } }
        public string Freshness { get { throw null; } set { } }
        public string Market { get { throw null; } set { } }
        public string ProjectConnectionId { get { throw null; } set { } }
        public string SetLang { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Agents.BingGroundingSearchConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.BingGroundingSearchConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.BingGroundingSearchConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.BingGroundingSearchConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.BingGroundingSearchConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.BingGroundingSearchConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.BingGroundingSearchConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.BingGroundingSearchConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.BingGroundingSearchConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BingGroundingSearchToolOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.BingGroundingSearchToolOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.BingGroundingSearchToolOptions>
    {
        public BingGroundingSearchToolOptions(System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.BingGroundingSearchConfiguration> searchConfigurations) { }
        public System.Collections.Generic.IList<Azure.AI.Projects.Agents.BingGroundingSearchConfiguration> SearchConfigurations { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.BingGroundingSearchToolOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.BingGroundingSearchToolOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.BingGroundingSearchToolOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.BingGroundingSearchToolOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.BingGroundingSearchToolOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.BingGroundingSearchToolOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.BingGroundingSearchToolOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.BingGroundingSearchToolOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.BingGroundingSearchToolOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BingGroundingTool : Azure.AI.Projects.Agents.AgentTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.BingGroundingTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.BingGroundingTool>
    {
        public BingGroundingTool(Azure.AI.Projects.Agents.BingGroundingSearchToolOptions bingGrounding) { }
        public Azure.AI.Projects.Agents.BingGroundingSearchToolOptions BingGrounding { get { throw null; } set { } }
        protected override Azure.AI.Projects.Agents.AgentTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.AgentTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.BingGroundingTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.BingGroundingTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.BingGroundingTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.BingGroundingTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.BingGroundingTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.BingGroundingTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.BingGroundingTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BrowserAutomationPreviewTool : Azure.AI.Projects.Agents.AgentTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.BrowserAutomationPreviewTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.BrowserAutomationPreviewTool>
    {
        public BrowserAutomationPreviewTool(Azure.AI.Projects.Agents.BrowserAutomationToolParameters browserAutomationPreview) { }
        public Azure.AI.Projects.Agents.BrowserAutomationToolParameters BrowserAutomationPreview { get { throw null; } set { } }
        protected override Azure.AI.Projects.Agents.AgentTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.AgentTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.BrowserAutomationPreviewTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.BrowserAutomationPreviewTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.BrowserAutomationPreviewTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.BrowserAutomationPreviewTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.BrowserAutomationPreviewTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.BrowserAutomationPreviewTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.BrowserAutomationPreviewTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BrowserAutomationToolConnectionParameters : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.BrowserAutomationToolConnectionParameters>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.BrowserAutomationToolConnectionParameters>
    {
        public BrowserAutomationToolConnectionParameters(string projectConnectionId) { }
        public string ProjectConnectionId { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Agents.BrowserAutomationToolConnectionParameters JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.BrowserAutomationToolConnectionParameters PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.BrowserAutomationToolConnectionParameters System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.BrowserAutomationToolConnectionParameters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.BrowserAutomationToolConnectionParameters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.BrowserAutomationToolConnectionParameters System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.BrowserAutomationToolConnectionParameters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.BrowserAutomationToolConnectionParameters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.BrowserAutomationToolConnectionParameters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BrowserAutomationToolParameters : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.BrowserAutomationToolParameters>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.BrowserAutomationToolParameters>
    {
        public BrowserAutomationToolParameters(Azure.AI.Projects.Agents.BrowserAutomationToolConnectionParameters connection) { }
        public Azure.AI.Projects.Agents.BrowserAutomationToolConnectionParameters Connection { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Agents.BrowserAutomationToolParameters JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.BrowserAutomationToolParameters PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.BrowserAutomationToolParameters System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.BrowserAutomationToolParameters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.BrowserAutomationToolParameters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.BrowserAutomationToolParameters System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.BrowserAutomationToolParameters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.BrowserAutomationToolParameters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.BrowserAutomationToolParameters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CaptureStructuredOutputsTool : Azure.AI.Projects.Agents.AgentTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.CaptureStructuredOutputsTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.CaptureStructuredOutputsTool>
    {
        public CaptureStructuredOutputsTool(Azure.AI.Projects.Agents.StructuredOutputDefinition outputs) { }
        public Azure.AI.Projects.Agents.StructuredOutputDefinition Outputs { get { throw null; } set { } }
        protected override Azure.AI.Projects.Agents.AgentTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.AgentTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.CaptureStructuredOutputsTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.CaptureStructuredOutputsTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.CaptureStructuredOutputsTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.CaptureStructuredOutputsTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.CaptureStructuredOutputsTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.CaptureStructuredOutputsTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.CaptureStructuredOutputsTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ClientConnectionProviderExtensions
    {
        public static Azure.AI.Projects.Agents.AgentsClient GetProjectAgentsClient(this System.ClientModel.Primitives.ClientConnectionProvider connectionProvider, Azure.AI.Projects.Agents.AgentsClientOptions options = null) { throw null; }
        public sealed partial class <G>$EE9D7A1C67932FB454531401B8375DE4
        {
            internal <G>$EE9D7A1C67932FB454531401B8375DE4() { }
            public Azure.AI.Projects.Agents.AgentsClient GetProjectAgentsClient(Azure.AI.Projects.Agents.AgentsClientOptions options = null) { throw null; }
            public static partial class <M>$781747A4149937EE6CD40CB5B8268DAD
            {
                public static void <Extension>$(System.ClientModel.Primitives.ClientConnectionProvider connectionProvider) { }
            }
        }
    }
    public partial class ContentFilterConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ContentFilterConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ContentFilterConfiguration>
    {
        public ContentFilterConfiguration(string raiPolicyName) { }
        public string RaiPolicyName { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Agents.ContentFilterConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.ContentFilterConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.ContentFilterConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ContentFilterConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ContentFilterConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.ContentFilterConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ContentFilterConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ContentFilterConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ContentFilterConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CreateAgentVersionFromManifestRequest : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.CreateAgentVersionFromManifestRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.CreateAgentVersionFromManifestRequest>
    {
        public CreateAgentVersionFromManifestRequest(string manifestId, System.Collections.Generic.IDictionary<string, System.BinaryData> parameterValues) { }
        public string Description { get { throw null; } set { } }
        public string ManifestId { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> ParameterValues { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.CreateAgentVersionFromManifestRequest JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.CreateAgentVersionFromManifestRequest PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.CreateAgentVersionFromManifestRequest System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.CreateAgentVersionFromManifestRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.CreateAgentVersionFromManifestRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.CreateAgentVersionFromManifestRequest System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.CreateAgentVersionFromManifestRequest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.CreateAgentVersionFromManifestRequest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.CreateAgentVersionFromManifestRequest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FabricDataAgentToolOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.FabricDataAgentToolOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.FabricDataAgentToolOptions>
    {
        public FabricDataAgentToolOptions() { }
        public System.Collections.Generic.IList<Azure.AI.Projects.Agents.ToolProjectConnection> ProjectConnections { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.FabricDataAgentToolOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.FabricDataAgentToolOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.FabricDataAgentToolOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.FabricDataAgentToolOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.FabricDataAgentToolOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.FabricDataAgentToolOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.FabricDataAgentToolOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.FabricDataAgentToolOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.FabricDataAgentToolOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HeaderTelemetryEndpointAuth : Azure.AI.Projects.Agents.TelemetryEndpointAuth, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.HeaderTelemetryEndpointAuth>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.HeaderTelemetryEndpointAuth>
    {
        public HeaderTelemetryEndpointAuth(string headerName, string secretId, string secretKey) { }
        public string HeaderName { get { throw null; } set { } }
        public string SecretId { get { throw null; } set { } }
        public string SecretKey { get { throw null; } set { } }
        protected override Azure.AI.Projects.Agents.TelemetryEndpointAuth JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.TelemetryEndpointAuth PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.HeaderTelemetryEndpointAuth System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.HeaderTelemetryEndpointAuth>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.HeaderTelemetryEndpointAuth>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.HeaderTelemetryEndpointAuth System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.HeaderTelemetryEndpointAuth>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.HeaderTelemetryEndpointAuth>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.HeaderTelemetryEndpointAuth>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class HostedAgentDefinition : Azure.AI.Projects.Agents.AgentDefinition, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.HostedAgentDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.HostedAgentDefinition>
    {
        public HostedAgentDefinition(System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.ProtocolVersionRecord> containerProtocolVersions, string cpu, string memory) { }
        public System.Collections.Generic.IList<Azure.AI.Projects.Agents.ProtocolVersionRecord> ContainerProtocolVersions { get { throw null; } }
        public string Cpu { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> EnvironmentVariables { get { throw null; } }
        public string Image { get { throw null; } set { } }
        public string Memory { get { throw null; } set { } }
        public Azure.AI.Projects.Agents.TelemetryConfig TelemetryConfig { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Projects.Agents.AgentTool> Tools { get { throw null; } }
        protected override Azure.AI.Projects.Agents.AgentDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.AgentDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.HostedAgentDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.HostedAgentDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.HostedAgentDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.HostedAgentDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.HostedAgentDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.HostedAgentDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.HostedAgentDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class McpToolExtensions
    {
        public static string get_ProjectConnectionId(OpenAI.Responses.McpTool mcpTool) { throw null; }
        public static void set_ProjectConnectionId(OpenAI.Responses.McpTool mcpTool, string value) { }
        public sealed partial class <G>$35DCA4819B43CF3F6CAB343048615A7E
        {
            internal <G>$35DCA4819B43CF3F6CAB343048615A7E() { }
            public string ProjectConnectionId { get { throw null; } set { } }
            public static partial class <M>$057BAEB40536DD92FB57E20F2D1CDCDE
            {
                public static void <Extension>$(OpenAI.Responses.McpTool mcpTool) { }
            }
        }
    }
    public partial class MemorySearchPreviewTool : Azure.AI.Projects.Agents.AgentTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.MemorySearchPreviewTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.MemorySearchPreviewTool>
    {
        public MemorySearchPreviewTool(string memoryStoreName, string scope) { }
        public string MemoryStoreName { get { throw null; } set { } }
        public string Scope { get { throw null; } set { } }
        public Azure.AI.Projects.Agents.MemorySearchToolOptions SearchOptions { get { throw null; } set { } }
        public int? UpdateDelay { get { throw null; } set { } }
        protected override Azure.AI.Projects.Agents.AgentTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.AgentTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.MemorySearchPreviewTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.MemorySearchPreviewTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.MemorySearchPreviewTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.MemorySearchPreviewTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.MemorySearchPreviewTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.MemorySearchPreviewTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.MemorySearchPreviewTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MemorySearchToolOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.MemorySearchToolOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.MemorySearchToolOptions>
    {
        public MemorySearchToolOptions() { }
        public int? MaxMemories { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Agents.MemorySearchToolOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.MemorySearchToolOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.MemorySearchToolOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.MemorySearchToolOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.MemorySearchToolOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.MemorySearchToolOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.MemorySearchToolOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.MemorySearchToolOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.MemorySearchToolOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MicrosoftFabricPreviewTool : Azure.AI.Projects.Agents.AgentTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.MicrosoftFabricPreviewTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.MicrosoftFabricPreviewTool>
    {
        public MicrosoftFabricPreviewTool(Azure.AI.Projects.Agents.FabricDataAgentToolOptions fabricDataagentPreview) { }
        public Azure.AI.Projects.Agents.FabricDataAgentToolOptions FabricDataagentPreview { get { throw null; } set { } }
        protected override Azure.AI.Projects.Agents.AgentTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.AgentTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.MicrosoftFabricPreviewTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.MicrosoftFabricPreviewTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.MicrosoftFabricPreviewTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.MicrosoftFabricPreviewTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.MicrosoftFabricPreviewTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.MicrosoftFabricPreviewTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.MicrosoftFabricPreviewTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OpenAPIAnonymousAuthenticationDetails : Azure.AI.Projects.Agents.OpenAPIAuthenticationDetails, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.OpenAPIAnonymousAuthenticationDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OpenAPIAnonymousAuthenticationDetails>
    {
        public OpenAPIAnonymousAuthenticationDetails() { }
        protected override Azure.AI.Projects.Agents.OpenAPIAuthenticationDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.OpenAPIAuthenticationDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.OpenAPIAnonymousAuthenticationDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.OpenAPIAnonymousAuthenticationDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.OpenAPIAnonymousAuthenticationDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.OpenAPIAnonymousAuthenticationDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OpenAPIAnonymousAuthenticationDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OpenAPIAnonymousAuthenticationDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OpenAPIAnonymousAuthenticationDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class OpenAPIAuthenticationDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.OpenAPIAuthenticationDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OpenAPIAuthenticationDetails>
    {
        internal OpenAPIAuthenticationDetails() { }
        protected virtual Azure.AI.Projects.Agents.OpenAPIAuthenticationDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.OpenAPIAuthenticationDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.OpenAPIAuthenticationDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.OpenAPIAuthenticationDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.OpenAPIAuthenticationDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.OpenAPIAuthenticationDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OpenAPIAuthenticationDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OpenAPIAuthenticationDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OpenAPIAuthenticationDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OpenAPIFunctionDefinition : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.OpenAPIFunctionDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OpenAPIFunctionDefinition>
    {
        public OpenAPIFunctionDefinition(string name, System.BinaryData specificationBytes, Azure.AI.Projects.Agents.OpenAPIAuthenticationDetails authentication) { }
        public OpenAPIFunctionDefinition(string name, System.Collections.Generic.IDictionary<string, System.BinaryData> spec, Azure.AI.Projects.Agents.OpenAPIAuthenticationDetails auth) { }
        public Azure.AI.Projects.Agents.OpenAPIAuthenticationDetails Auth { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> DefaultParams { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Projects.Agents.OpenAPIFunctionEntry> Functions { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Spec { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.OpenAPIFunctionDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.OpenAPIFunctionDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.OpenAPIFunctionDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.OpenAPIFunctionDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.OpenAPIFunctionDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.OpenAPIFunctionDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OpenAPIFunctionDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OpenAPIFunctionDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OpenAPIFunctionDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OpenAPIFunctionEntry : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.OpenAPIFunctionEntry>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OpenAPIFunctionEntry>
    {
        public OpenAPIFunctionEntry(string name, System.Collections.Generic.IDictionary<string, System.BinaryData> parameters) { }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Parameters { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.OpenAPIFunctionEntry JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.OpenAPIFunctionEntry PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.OpenAPIFunctionEntry System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.OpenAPIFunctionEntry>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.OpenAPIFunctionEntry>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.OpenAPIFunctionEntry System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OpenAPIFunctionEntry>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OpenAPIFunctionEntry>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OpenAPIFunctionEntry>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OpenAPIManagedAuthenticationDetails : Azure.AI.Projects.Agents.OpenAPIAuthenticationDetails, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.OpenAPIManagedAuthenticationDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OpenAPIManagedAuthenticationDetails>
    {
        public OpenAPIManagedAuthenticationDetails(Azure.AI.Projects.Agents.OpenAPIManagedSecurityScheme securityScheme) { }
        public Azure.AI.Projects.Agents.OpenAPIManagedSecurityScheme SecurityScheme { get { throw null; } set { } }
        protected override Azure.AI.Projects.Agents.OpenAPIAuthenticationDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.OpenAPIAuthenticationDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.OpenAPIManagedAuthenticationDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.OpenAPIManagedAuthenticationDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.OpenAPIManagedAuthenticationDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.OpenAPIManagedAuthenticationDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OpenAPIManagedAuthenticationDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OpenAPIManagedAuthenticationDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OpenAPIManagedAuthenticationDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OpenAPIManagedSecurityScheme : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.OpenAPIManagedSecurityScheme>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OpenAPIManagedSecurityScheme>
    {
        public OpenAPIManagedSecurityScheme(string audience) { }
        public string Audience { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Agents.OpenAPIManagedSecurityScheme JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.OpenAPIManagedSecurityScheme PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.OpenAPIManagedSecurityScheme System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.OpenAPIManagedSecurityScheme>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.OpenAPIManagedSecurityScheme>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.OpenAPIManagedSecurityScheme System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OpenAPIManagedSecurityScheme>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OpenAPIManagedSecurityScheme>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OpenAPIManagedSecurityScheme>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OpenAPIProjectConnectionAuthenticationDetails : Azure.AI.Projects.Agents.OpenAPIAuthenticationDetails, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.OpenAPIProjectConnectionAuthenticationDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OpenAPIProjectConnectionAuthenticationDetails>
    {
        public OpenAPIProjectConnectionAuthenticationDetails(Azure.AI.Projects.Agents.OpenAPIProjectConnectionSecurityScheme securityScheme) { }
        public Azure.AI.Projects.Agents.OpenAPIProjectConnectionSecurityScheme SecurityScheme { get { throw null; } set { } }
        protected override Azure.AI.Projects.Agents.OpenAPIAuthenticationDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.OpenAPIAuthenticationDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.OpenAPIProjectConnectionAuthenticationDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.OpenAPIProjectConnectionAuthenticationDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.OpenAPIProjectConnectionAuthenticationDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.OpenAPIProjectConnectionAuthenticationDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OpenAPIProjectConnectionAuthenticationDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OpenAPIProjectConnectionAuthenticationDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OpenAPIProjectConnectionAuthenticationDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OpenAPIProjectConnectionSecurityScheme : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.OpenAPIProjectConnectionSecurityScheme>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OpenAPIProjectConnectionSecurityScheme>
    {
        public OpenAPIProjectConnectionSecurityScheme(string projectConnectionId) { }
        public string ProjectConnectionId { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Agents.OpenAPIProjectConnectionSecurityScheme JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.OpenAPIProjectConnectionSecurityScheme PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.OpenAPIProjectConnectionSecurityScheme System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.OpenAPIProjectConnectionSecurityScheme>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.OpenAPIProjectConnectionSecurityScheme>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.OpenAPIProjectConnectionSecurityScheme System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OpenAPIProjectConnectionSecurityScheme>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OpenAPIProjectConnectionSecurityScheme>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OpenAPIProjectConnectionSecurityScheme>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OpenAPITool : Azure.AI.Projects.Agents.AgentTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.OpenAPITool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OpenAPITool>
    {
        public OpenAPITool(Azure.AI.Projects.Agents.OpenAPIFunctionDefinition openapi) { }
        public Azure.AI.Projects.Agents.OpenAPIFunctionDefinition Openapi { get { throw null; } set { } }
        protected override Azure.AI.Projects.Agents.AgentTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.AgentTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.OpenAPITool System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.OpenAPITool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.OpenAPITool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.OpenAPITool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OpenAPITool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OpenAPITool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OpenAPITool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OtlpTelemetryEndpoint : Azure.AI.Projects.Agents.TelemetryEndpoint, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.OtlpTelemetryEndpoint>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OtlpTelemetryEndpoint>
    {
        public OtlpTelemetryEndpoint(System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.TelemetryDataKind> data, string endpoint, Azure.AI.Projects.Agents.TelemetryTransportProtocol protocol) { }
        public string Endpoint { get { throw null; } set { } }
        public Azure.AI.Projects.Agents.TelemetryTransportProtocol Protocol { get { throw null; } set { } }
        protected override Azure.AI.Projects.Agents.TelemetryEndpoint JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.TelemetryEndpoint PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.OtlpTelemetryEndpoint System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.OtlpTelemetryEndpoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.OtlpTelemetryEndpoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.OtlpTelemetryEndpoint System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OtlpTelemetryEndpoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OtlpTelemetryEndpoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OtlpTelemetryEndpoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ProjectsAgentsModelFactory
    {
        public static Azure.AI.Projects.Agents.A2APreviewTool A2APreviewTool(System.Uri baseUri = null, string agentCardPath = null, string projectConnectionId = null) { throw null; }
        public static Azure.AI.Projects.Agents.AgentDefinition AgentDefinition(string kind = null, Azure.AI.Projects.Agents.ContentFilterConfiguration contentFilterConfiguration = null) { throw null; }
        public static Azure.AI.Projects.Agents.AgentManifestOptions AgentManifestOptions(System.Collections.Generic.IDictionary<string, string> metadata = null, string description = null, string manifestId = null, System.Collections.Generic.IDictionary<string, System.BinaryData> parameterValues = null) { throw null; }
        public static Azure.AI.Projects.Agents.AgentObjectVersions AgentObjectVersions(Azure.AI.Projects.Agents.AgentVersion latest = null) { throw null; }
        public static Azure.AI.Projects.Agents.AgentRecord AgentRecord(string id = null, string name = null, Azure.AI.Projects.Agents.AgentObjectVersions versions = null) { throw null; }
        public static Azure.AI.Projects.Agents.AgentTool AgentTool(string type = null) { throw null; }
        public static Azure.AI.Projects.Agents.AgentVersion AgentVersion(System.Collections.Generic.IDictionary<string, string> metadata = null, string id = null, string name = null, string version = null, string description = null, System.DateTimeOffset createdAt = default(System.DateTimeOffset), Azure.AI.Projects.Agents.AgentDefinition definition = null) { throw null; }
        public static Azure.AI.Projects.Agents.AgentVersionCreationOptions AgentVersionCreationOptions(System.Collections.Generic.IDictionary<string, string> metadata = null, string description = null, Azure.AI.Projects.Agents.AgentDefinition definition = null) { throw null; }
        public static Azure.AI.Projects.Agents.AzureAISearchTool AzureAISearchTool(Azure.AI.Projects.Agents.AzureAISearchToolOptions options = null) { throw null; }
        public static Azure.AI.Projects.Agents.AzureAISearchToolIndex AzureAISearchToolIndex(string projectConnectionId = null, string indexName = null, Azure.AI.Projects.Agents.AzureAISearchQueryType? queryType = default(Azure.AI.Projects.Agents.AzureAISearchQueryType?), int? topK = default(int?), string filter = null, string indexAssetId = null) { throw null; }
        public static Azure.AI.Projects.Agents.AzureAISearchToolOptions AzureAISearchToolOptions(System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.AzureAISearchToolIndex> indexes = null) { throw null; }
        public static Azure.AI.Projects.Agents.AzureFunctionBinding AzureFunctionBinding(Azure.AI.Projects.Agents.AzureFunctionStorageQueue storageQueue = null) { throw null; }
        public static Azure.AI.Projects.Agents.AzureFunctionDefinition AzureFunctionDefinition(Azure.AI.Projects.Agents.AzureFunctionDefinitionFunction function = null, Azure.AI.Projects.Agents.AzureFunctionBinding inputBinding = null, Azure.AI.Projects.Agents.AzureFunctionBinding outputBinding = null) { throw null; }
        public static Azure.AI.Projects.Agents.AzureFunctionDefinitionFunction AzureFunctionDefinitionFunction(string name = null, string description = null, System.BinaryData parameters = null) { throw null; }
        public static Azure.AI.Projects.Agents.AzureFunctionStorageQueue AzureFunctionStorageQueue(string queueServiceEndpoint = null, string queueName = null) { throw null; }
        public static Azure.AI.Projects.Agents.AzureFunctionTool AzureFunctionTool(Azure.AI.Projects.Agents.AzureFunctionDefinition azureFunction = null) { throw null; }
        public static Azure.AI.Projects.Agents.BingCustomSearchConfiguration BingCustomSearchConfiguration(string projectConnectionId = null, string instanceName = null, string market = null, string setLang = null, long? count = default(long?), string freshness = null) { throw null; }
        public static Azure.AI.Projects.Agents.BingCustomSearchPreviewTool BingCustomSearchPreviewTool(Azure.AI.Projects.Agents.BingCustomSearchToolParameters bingCustomSearchPreview = null) { throw null; }
        public static Azure.AI.Projects.Agents.BingCustomSearchToolParameters BingCustomSearchToolParameters(System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.BingCustomSearchConfiguration> searchConfigurations = null) { throw null; }
        public static Azure.AI.Projects.Agents.BingGroundingSearchConfiguration BingGroundingSearchConfiguration(string projectConnectionId = null, string market = null, string setLang = null, long? count = default(long?), string freshness = null) { throw null; }
        public static Azure.AI.Projects.Agents.BingGroundingSearchToolOptions BingGroundingSearchToolOptions(System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.BingGroundingSearchConfiguration> searchConfigurations = null) { throw null; }
        public static Azure.AI.Projects.Agents.BingGroundingTool BingGroundingTool(Azure.AI.Projects.Agents.BingGroundingSearchToolOptions bingGrounding = null) { throw null; }
        public static Azure.AI.Projects.Agents.BrowserAutomationPreviewTool BrowserAutomationPreviewTool(Azure.AI.Projects.Agents.BrowserAutomationToolParameters browserAutomationPreview = null) { throw null; }
        public static Azure.AI.Projects.Agents.BrowserAutomationToolConnectionParameters BrowserAutomationToolConnectionParameters(string projectConnectionId = null) { throw null; }
        public static Azure.AI.Projects.Agents.BrowserAutomationToolParameters BrowserAutomationToolParameters(Azure.AI.Projects.Agents.BrowserAutomationToolConnectionParameters connection = null) { throw null; }
        public static Azure.AI.Projects.Agents.CaptureStructuredOutputsTool CaptureStructuredOutputsTool(Azure.AI.Projects.Agents.StructuredOutputDefinition outputs = null) { throw null; }
        public static Azure.AI.Projects.Agents.ContentFilterConfiguration ContentFilterConfiguration(string raiPolicyName = null) { throw null; }
        public static Azure.AI.Projects.Agents.CreateAgentVersionFromManifestRequest CreateAgentVersionFromManifestRequest(System.Collections.Generic.IDictionary<string, string> metadata = null, string description = null, string manifestId = null, System.Collections.Generic.IDictionary<string, System.BinaryData> parameterValues = null) { throw null; }
        public static Azure.AI.Projects.Agents.FabricDataAgentToolOptions FabricDataAgentToolOptions(System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.ToolProjectConnection> projectConnections = null) { throw null; }
        public static Azure.AI.Projects.Agents.HeaderTelemetryEndpointAuth HeaderTelemetryEndpointAuth(string headerName = null, string secretId = null, string secretKey = null) { throw null; }
        public static Azure.AI.Projects.Agents.HostedAgentDefinition HostedAgentDefinition(Azure.AI.Projects.Agents.ContentFilterConfiguration contentFilterConfiguration = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.AgentTool> tools = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.ProtocolVersionRecord> containerProtocolVersions = null, string cpu = null, string memory = null, System.Collections.Generic.IDictionary<string, string> environmentVariables = null, string image = null, Azure.AI.Projects.Agents.TelemetryConfig telemetryConfig = null) { throw null; }
        public static Azure.AI.Projects.Agents.MemorySearchPreviewTool MemorySearchPreviewTool(string memoryStoreName = null, string scope = null, Azure.AI.Projects.Agents.MemorySearchToolOptions searchOptions = null, int? updateDelay = default(int?)) { throw null; }
        public static Azure.AI.Projects.Agents.MemorySearchToolOptions MemorySearchToolOptions(int? maxMemories = default(int?)) { throw null; }
        public static Azure.AI.Projects.Agents.MicrosoftFabricPreviewTool MicrosoftFabricPreviewTool(Azure.AI.Projects.Agents.FabricDataAgentToolOptions fabricDataagentPreview = null) { throw null; }
        public static Azure.AI.Projects.Agents.OpenAPIAnonymousAuthenticationDetails OpenAPIAnonymousAuthenticationDetails() { throw null; }
        public static Azure.AI.Projects.Agents.OpenAPIAuthenticationDetails OpenAPIAuthenticationDetails(string type = null) { throw null; }
        public static Azure.AI.Projects.Agents.OpenAPIFunctionDefinition OpenAPIFunctionDefinition(string name = null, string description = null, System.Collections.Generic.IDictionary<string, System.BinaryData> spec = null, Azure.AI.Projects.Agents.OpenAPIAuthenticationDetails auth = null, System.Collections.Generic.IEnumerable<string> defaultParams = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.OpenAPIFunctionEntry> functions = null) { throw null; }
        public static Azure.AI.Projects.Agents.OpenAPIFunctionEntry OpenAPIFunctionEntry(string name = null, string description = null, System.Collections.Generic.IDictionary<string, System.BinaryData> parameters = null) { throw null; }
        public static Azure.AI.Projects.Agents.OpenAPIManagedAuthenticationDetails OpenAPIManagedAuthenticationDetails(Azure.AI.Projects.Agents.OpenAPIManagedSecurityScheme securityScheme = null) { throw null; }
        public static Azure.AI.Projects.Agents.OpenAPIManagedSecurityScheme OpenAPIManagedSecurityScheme(string audience = null) { throw null; }
        public static Azure.AI.Projects.Agents.OpenAPIProjectConnectionAuthenticationDetails OpenAPIProjectConnectionAuthenticationDetails(Azure.AI.Projects.Agents.OpenAPIProjectConnectionSecurityScheme securityScheme = null) { throw null; }
        public static Azure.AI.Projects.Agents.OpenAPIProjectConnectionSecurityScheme OpenAPIProjectConnectionSecurityScheme(string projectConnectionId = null) { throw null; }
        public static Azure.AI.Projects.Agents.OpenAPITool OpenAPITool(Azure.AI.Projects.Agents.OpenAPIFunctionDefinition openapi = null) { throw null; }
        public static Azure.AI.Projects.Agents.OtlpTelemetryEndpoint OtlpTelemetryEndpoint(System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.TelemetryDataKind> data = null, Azure.AI.Projects.Agents.TelemetryEndpointAuth auth = null, string endpoint = null, Azure.AI.Projects.Agents.TelemetryTransportProtocol protocol = default(Azure.AI.Projects.Agents.TelemetryTransportProtocol)) { throw null; }
        public static Azure.AI.Projects.Agents.ProjectWebSearchConfiguration ProjectWebSearchConfiguration(string projectConnectionId = null, string instanceName = null) { throw null; }
        public static Azure.AI.Projects.Agents.ProtocolVersionRecord ProtocolVersionRecord(Azure.AI.Projects.Agents.AgentCommunicationMethod protocol = default(Azure.AI.Projects.Agents.AgentCommunicationMethod), string version = null) { throw null; }
        public static Azure.AI.Projects.Agents.SharePointGroundingToolOptions SharePointGroundingToolOptions(System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.ToolProjectConnection> projectConnections = null) { throw null; }
        public static Azure.AI.Projects.Agents.SharepointPreviewTool SharepointPreviewTool(Azure.AI.Projects.Agents.SharePointGroundingToolOptions sharepointGroundingPreview = null) { throw null; }
        public static Azure.AI.Projects.Agents.StructuredInputDefinition StructuredInputDefinition(string description = null, System.BinaryData defaultValue = null, System.Collections.Generic.IDictionary<string, System.BinaryData> schema = null, bool? isRequired = default(bool?)) { throw null; }
        public static Azure.AI.Projects.Agents.StructuredOutputDefinition StructuredOutputDefinition(string name = null, string description = null, System.Collections.Generic.IDictionary<string, System.BinaryData> schema = null, bool? strict = default(bool?)) { throw null; }
        public static Azure.AI.Projects.Agents.TelemetryConfig TelemetryConfig(System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.TelemetryEndpoint> endpoints = null) { throw null; }
        public static Azure.AI.Projects.Agents.TelemetryEndpoint TelemetryEndpoint(string kind = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.TelemetryDataKind> data = null, Azure.AI.Projects.Agents.TelemetryEndpointAuth auth = null) { throw null; }
        public static Azure.AI.Projects.Agents.TelemetryEndpointAuth TelemetryEndpointAuth(string type = null) { throw null; }
        public static Azure.AI.Projects.Agents.ToolProjectConnection ToolProjectConnection(string projectConnectionId = null) { throw null; }
        public static Azure.AI.Projects.Agents.WorkflowAgentDefinition WorkflowAgentDefinition(Azure.AI.Projects.Agents.ContentFilterConfiguration contentFilterConfiguration = null, string workflowYaml = null) { throw null; }
    }
    public partial class ProjectWebSearchConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ProjectWebSearchConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ProjectWebSearchConfiguration>
    {
        public ProjectWebSearchConfiguration(string projectConnectionId, string instanceName) { }
        public string InstanceName { get { throw null; } set { } }
        public string ProjectConnectionId { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Agents.ProjectWebSearchConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.ProjectWebSearchConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.ProjectWebSearchConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ProjectWebSearchConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ProjectWebSearchConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.ProjectWebSearchConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ProjectWebSearchConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ProjectWebSearchConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ProjectWebSearchConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PromptAgentDefinition : Azure.AI.Projects.Agents.AgentDefinition, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.PromptAgentDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.PromptAgentDefinition>
    {
        public PromptAgentDefinition(string model) { }
        public string Instructions { get { throw null; } set { } }
        public string Model { get { throw null; } set { } }
        public OpenAI.Responses.ResponseReasoningOptions ReasoningOptions { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.AI.Projects.Agents.StructuredInputDefinition> StructuredInputs { get { throw null; } }
        public float? Temperature { get { throw null; } set { } }
        public OpenAI.Responses.ResponseTextOptions TextOptions { get { throw null; } set { } }
        public System.BinaryData ToolChoice { get { throw null; } set { } }
        public System.Collections.Generic.IList<OpenAI.Responses.ResponseTool> Tools { get { throw null; } }
        public float? TopP { get { throw null; } set { } }
        protected override Azure.AI.Projects.Agents.AgentDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.AgentDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.PromptAgentDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.PromptAgentDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.PromptAgentDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.PromptAgentDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.PromptAgentDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.PromptAgentDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.PromptAgentDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProtocolVersionRecord : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ProtocolVersionRecord>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ProtocolVersionRecord>
    {
        public ProtocolVersionRecord(Azure.AI.Projects.Agents.AgentCommunicationMethod protocol, string version) { }
        public Azure.AI.Projects.Agents.AgentCommunicationMethod Protocol { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Agents.ProtocolVersionRecord JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.ProtocolVersionRecord PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.ProtocolVersionRecord System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ProtocolVersionRecord>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ProtocolVersionRecord>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.ProtocolVersionRecord System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ProtocolVersionRecord>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ProtocolVersionRecord>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ProtocolVersionRecord>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ResponseToolExtensions
    {
        public static Azure.AI.Projects.Agents.AgentTool AsAgentTool(this OpenAI.Responses.ResponseTool responseTool) { throw null; }
    }
    public partial class SharePointGroundingToolOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.SharePointGroundingToolOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.SharePointGroundingToolOptions>
    {
        public SharePointGroundingToolOptions() { }
        public System.Collections.Generic.IList<Azure.AI.Projects.Agents.ToolProjectConnection> ProjectConnections { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.SharePointGroundingToolOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.SharePointGroundingToolOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.SharePointGroundingToolOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.SharePointGroundingToolOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.SharePointGroundingToolOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.SharePointGroundingToolOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.SharePointGroundingToolOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.SharePointGroundingToolOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.SharePointGroundingToolOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SharepointPreviewTool : Azure.AI.Projects.Agents.AgentTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.SharepointPreviewTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.SharepointPreviewTool>
    {
        public SharepointPreviewTool(Azure.AI.Projects.Agents.SharePointGroundingToolOptions sharepointGroundingPreview) { }
        public Azure.AI.Projects.Agents.SharePointGroundingToolOptions SharepointGroundingPreview { get { throw null; } set { } }
        protected override Azure.AI.Projects.Agents.AgentTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.AgentTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.SharepointPreviewTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.SharepointPreviewTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.SharepointPreviewTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.SharepointPreviewTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.SharepointPreviewTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.SharepointPreviewTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.SharepointPreviewTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StructuredInputDefinition : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.StructuredInputDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.StructuredInputDefinition>
    {
        public StructuredInputDefinition() { }
        public System.BinaryData DefaultValue { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public bool? IsRequired { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Schema { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.StructuredInputDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.StructuredInputDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.StructuredInputDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.StructuredInputDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.StructuredInputDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.StructuredInputDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.StructuredInputDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.StructuredInputDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.StructuredInputDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StructuredOutputDefinition : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.StructuredOutputDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.StructuredOutputDefinition>
    {
        public StructuredOutputDefinition(string name, string description, System.Collections.Generic.IDictionary<string, System.BinaryData> schema, bool? strict) { }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Schema { get { throw null; } }
        public bool? Strict { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Agents.StructuredOutputDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.StructuredOutputDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.StructuredOutputDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.StructuredOutputDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.StructuredOutputDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.StructuredOutputDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.StructuredOutputDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.StructuredOutputDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.StructuredOutputDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TelemetryConfig : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.TelemetryConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TelemetryConfig>
    {
        public TelemetryConfig(System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.TelemetryEndpoint> endpoints) { }
        public System.Collections.Generic.IList<Azure.AI.Projects.Agents.TelemetryEndpoint> Endpoints { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.TelemetryConfig JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.TelemetryConfig PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.TelemetryConfig System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.TelemetryConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.TelemetryConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.TelemetryConfig System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TelemetryConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TelemetryConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TelemetryConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TelemetryDataKind : System.IEquatable<Azure.AI.Projects.Agents.TelemetryDataKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TelemetryDataKind(string value) { throw null; }
        public static Azure.AI.Projects.Agents.TelemetryDataKind ContainerOtel { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelemetryDataKind ContainerStdoutStderr { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelemetryDataKind Metrics { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Agents.TelemetryDataKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Agents.TelemetryDataKind left, Azure.AI.Projects.Agents.TelemetryDataKind right) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.TelemetryDataKind (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.TelemetryDataKind? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Agents.TelemetryDataKind left, Azure.AI.Projects.Agents.TelemetryDataKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class TelemetryEndpoint : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.TelemetryEndpoint>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TelemetryEndpoint>
    {
        internal TelemetryEndpoint() { }
        public Azure.AI.Projects.Agents.TelemetryEndpointAuth Auth { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Projects.Agents.TelemetryDataKind> Data { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.TelemetryEndpoint JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.TelemetryEndpoint PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.TelemetryEndpoint System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.TelemetryEndpoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.TelemetryEndpoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.TelemetryEndpoint System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TelemetryEndpoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TelemetryEndpoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TelemetryEndpoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class TelemetryEndpointAuth : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.TelemetryEndpointAuth>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TelemetryEndpointAuth>
    {
        internal TelemetryEndpointAuth() { }
        protected virtual Azure.AI.Projects.Agents.TelemetryEndpointAuth JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.TelemetryEndpointAuth PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.TelemetryEndpointAuth System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.TelemetryEndpointAuth>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.TelemetryEndpointAuth>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.TelemetryEndpointAuth System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TelemetryEndpointAuth>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TelemetryEndpointAuth>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TelemetryEndpointAuth>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TelemetryTransportProtocol : System.IEquatable<Azure.AI.Projects.Agents.TelemetryTransportProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TelemetryTransportProtocol(string value) { throw null; }
        public static Azure.AI.Projects.Agents.TelemetryTransportProtocol Grpc { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelemetryTransportProtocol Http { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Agents.TelemetryTransportProtocol other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Agents.TelemetryTransportProtocol left, Azure.AI.Projects.Agents.TelemetryTransportProtocol right) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.TelemetryTransportProtocol (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.TelemetryTransportProtocol? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Agents.TelemetryTransportProtocol left, Azure.AI.Projects.Agents.TelemetryTransportProtocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ToolProjectConnection : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ToolProjectConnection>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ToolProjectConnection>
    {
        public ToolProjectConnection(string projectConnectionId) { }
        public string ProjectConnectionId { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Agents.ToolProjectConnection JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.ToolProjectConnection PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.ToolProjectConnection System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ToolProjectConnection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ToolProjectConnection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.ToolProjectConnection System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ToolProjectConnection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ToolProjectConnection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ToolProjectConnection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class WebSearchToolExtensions
    {
        public static Azure.AI.Projects.Agents.ProjectWebSearchConfiguration get_CustomSearchConfiguration(OpenAI.Responses.WebSearchTool webSearchTool) { throw null; }
        public static void set_CustomSearchConfiguration(OpenAI.Responses.WebSearchTool webSearchTool, Azure.AI.Projects.Agents.ProjectWebSearchConfiguration value) { }
        public sealed partial class <G>$133B1A79670A0C05D9616EBAA22781D3
        {
            internal <G>$133B1A79670A0C05D9616EBAA22781D3() { }
            public Azure.AI.Projects.Agents.ProjectWebSearchConfiguration CustomSearchConfiguration { get { throw null; } set { } }
            public static partial class <M>$153F3998C7DD501BEF8CB71B5BD98F98
            {
                public static void <Extension>$(OpenAI.Responses.WebSearchTool webSearchTool) { }
            }
        }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class WorkflowAgentDefinition : Azure.AI.Projects.Agents.AgentDefinition, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.WorkflowAgentDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.WorkflowAgentDefinition>
    {
        internal WorkflowAgentDefinition() { }
        public static Azure.AI.Projects.Agents.WorkflowAgentDefinition FromYaml(string workflowYamlDocument) { throw null; }
        protected override Azure.AI.Projects.Agents.AgentDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.AgentDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.WorkflowAgentDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.WorkflowAgentDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.WorkflowAgentDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.WorkflowAgentDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.WorkflowAgentDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.WorkflowAgentDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.WorkflowAgentDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
