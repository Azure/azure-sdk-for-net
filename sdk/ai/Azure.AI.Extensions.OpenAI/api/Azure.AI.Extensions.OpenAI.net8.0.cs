namespace Azure.AI.Extensions.OpenAI
{
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class A2APreviewTool : OpenAI.Responses.ResponseTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.A2APreviewTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.A2APreviewTool>
    {
        public A2APreviewTool() : base (default(OpenAI.Responses.ResponseToolKind)) { }
        public string AgentCardPath { get { throw null; } set { } }
        public System.Uri BaseUri { get { throw null; } set { } }
        public string ProjectConnectionId { get { throw null; } set { } }
        public bool? SendCredentialsForAgentCard { get { throw null; } set { } }
        protected override OpenAI.Responses.ResponseTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override OpenAI.Responses.ResponseTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.A2APreviewTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.A2APreviewTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.A2APreviewTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.A2APreviewTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.A2APreviewTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.A2APreviewTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.A2APreviewTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class A2AToolCall : OpenAI.Responses.ResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.A2AToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.A2AToolCall>
    {
        public A2AToolCall(string callId, string name, string arguments, Azure.AI.Extensions.OpenAI.ToolCallStatus status) : base (default(OpenAI.Responses.ResponseItemKind)) { }
        public string Arguments { get { throw null; } set { } }
        public string CallId { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.AI.Extensions.OpenAI.ToolCallStatus Status { get { throw null; } set { } }
        protected override OpenAI.Responses.ResponseItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override OpenAI.Responses.ResponseItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.A2AToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.A2AToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.A2AToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.A2AToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.A2AToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.A2AToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.A2AToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class A2AToolCallOutput : OpenAI.Responses.ResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.A2AToolCallOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.A2AToolCallOutput>
    {
        public A2AToolCallOutput(string callId, string name, Azure.AI.Extensions.OpenAI.ToolCallStatus status) : base (default(OpenAI.Responses.ResponseItemKind)) { }
        public string CallId { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.BinaryData Output { get { throw null; } set { } }
        public Azure.AI.Extensions.OpenAI.ToolCallStatus Status { get { throw null; } set { } }
        protected override OpenAI.Responses.ResponseItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override OpenAI.Responses.ResponseItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.A2AToolCallOutput System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.A2AToolCallOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.A2AToolCallOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.A2AToolCallOutput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.A2AToolCallOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.A2AToolCallOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.A2AToolCallOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentReference : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.AgentReference>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AgentReference>
    {
        public AgentReference(string name, string version = null) { }
        public string Name { get { throw null; } set { } }
        public string Type { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual Azure.AI.Extensions.OpenAI.AgentReference JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.AI.Extensions.OpenAI.AgentReference (string agentName) { throw null; }
        protected virtual Azure.AI.Extensions.OpenAI.AgentReference PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.AgentReference System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.AgentReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.AgentReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.AgentReference System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AgentReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AgentReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AgentReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP002")]
    public partial class AgentStructuredOutputsResponseItem : OpenAI.Responses.ResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.AgentStructuredOutputsResponseItem>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AgentStructuredOutputsResponseItem>
    {
        public AgentStructuredOutputsResponseItem(System.BinaryData output) : base (default(OpenAI.Responses.ResponseItemKind)) { }
        public System.BinaryData Output { get { throw null; } set { } }
        protected override OpenAI.Responses.ResponseItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override OpenAI.Responses.ResponseItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.AgentStructuredOutputsResponseItem System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.AgentStructuredOutputsResponseItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.AgentStructuredOutputsResponseItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.AgentStructuredOutputsResponseItem System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AgentStructuredOutputsResponseItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AgentStructuredOutputsResponseItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AgentStructuredOutputsResponseItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP002")]
    public partial class AgentWorkflowPreviewActionResponseItem : OpenAI.Responses.ResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.AgentWorkflowPreviewActionResponseItem>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AgentWorkflowPreviewActionResponseItem>
    {
        public AgentWorkflowPreviewActionResponseItem(string kind, string actionId, Azure.AI.Extensions.OpenAI.AgentWorkflowPreviewActionStatus? status) : base (default(OpenAI.Responses.ResponseItemKind)) { }
        public string ActionId { get { throw null; } set { } }
        public string CSDLActionKind { get { throw null; } set { } }
        public string ParentActionId { get { throw null; } set { } }
        public string PreviousActionId { get { throw null; } set { } }
        public Azure.AI.Extensions.OpenAI.AgentWorkflowPreviewActionStatus? Status { get { throw null; } }
        protected override OpenAI.Responses.ResponseItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override OpenAI.Responses.ResponseItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.AgentWorkflowPreviewActionResponseItem System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.AgentWorkflowPreviewActionResponseItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.AgentWorkflowPreviewActionResponseItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.AgentWorkflowPreviewActionResponseItem System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AgentWorkflowPreviewActionResponseItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AgentWorkflowPreviewActionResponseItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AgentWorkflowPreviewActionResponseItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AgentWorkflowPreviewActionStatus : System.IEquatable<Azure.AI.Extensions.OpenAI.AgentWorkflowPreviewActionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AgentWorkflowPreviewActionStatus(string value) { throw null; }
        public static Azure.AI.Extensions.OpenAI.AgentWorkflowPreviewActionStatus Cancelled { get { throw null; } }
        public static Azure.AI.Extensions.OpenAI.AgentWorkflowPreviewActionStatus Completed { get { throw null; } }
        public static Azure.AI.Extensions.OpenAI.AgentWorkflowPreviewActionStatus Failed { get { throw null; } }
        public static Azure.AI.Extensions.OpenAI.AgentWorkflowPreviewActionStatus InProgress { get { throw null; } }
        public bool Equals(Azure.AI.Extensions.OpenAI.AgentWorkflowPreviewActionStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Extensions.OpenAI.AgentWorkflowPreviewActionStatus left, Azure.AI.Extensions.OpenAI.AgentWorkflowPreviewActionStatus right) { throw null; }
        public static implicit operator Azure.AI.Extensions.OpenAI.AgentWorkflowPreviewActionStatus (string value) { throw null; }
        public static implicit operator Azure.AI.Extensions.OpenAI.AgentWorkflowPreviewActionStatus? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Extensions.OpenAI.AgentWorkflowPreviewActionStatus left, Azure.AI.Extensions.OpenAI.AgentWorkflowPreviewActionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public static partial class AzureAIExtensions
    {
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static System.ClientModel.ClientResult<OpenAI.Responses.ResponseResult> CreateResponse(this OpenAI.Responses.ResponsesClient responseClient, OpenAI.Conversations.ConversationResource conversation, Azure.AI.Extensions.OpenAI.AgentReference agentRef, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        [System.Diagnostics.DebuggerStepThroughAttribute]
        public static System.Threading.Tasks.Task<System.ClientModel.ClientResult<OpenAI.Responses.ResponseResult>> CreateResponseAsync(this OpenAI.Responses.ResponsesClient responseClient, OpenAI.Conversations.ConversationResource conversation, Azure.AI.Extensions.OpenAI.AgentReference agentRef, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static string GetAzureFileStatus(this OpenAI.Files.OpenAIFile file) { throw null; }
    }
    public partial class AzureAIExtensionsOpenAIContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureAIExtensionsOpenAIContext() { }
        public static Azure.AI.Extensions.OpenAI.AzureAIExtensionsOpenAIContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureAISearchQueryKind : System.IEquatable<Azure.AI.Extensions.OpenAI.AzureAISearchQueryKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureAISearchQueryKind(string value) { throw null; }
        public static Azure.AI.Extensions.OpenAI.AzureAISearchQueryKind Semantic { get { throw null; } }
        public static Azure.AI.Extensions.OpenAI.AzureAISearchQueryKind Simple { get { throw null; } }
        public static Azure.AI.Extensions.OpenAI.AzureAISearchQueryKind Vector { get { throw null; } }
        public static Azure.AI.Extensions.OpenAI.AzureAISearchQueryKind VectorSemanticHybrid { get { throw null; } }
        public static Azure.AI.Extensions.OpenAI.AzureAISearchQueryKind VectorSimpleHybrid { get { throw null; } }
        public bool Equals(Azure.AI.Extensions.OpenAI.AzureAISearchQueryKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Extensions.OpenAI.AzureAISearchQueryKind left, Azure.AI.Extensions.OpenAI.AzureAISearchQueryKind right) { throw null; }
        public static implicit operator Azure.AI.Extensions.OpenAI.AzureAISearchQueryKind (string value) { throw null; }
        public static implicit operator Azure.AI.Extensions.OpenAI.AzureAISearchQueryKind? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Extensions.OpenAI.AzureAISearchQueryKind left, Azure.AI.Extensions.OpenAI.AzureAISearchQueryKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP002")]
    public partial class AzureAISearchTool : OpenAI.Responses.ResponseTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.AzureAISearchTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AzureAISearchTool>
    {
        public AzureAISearchTool(Azure.AI.Extensions.OpenAI.AzureAISearchToolOptions azureAISearch) : base (default(OpenAI.Responses.ResponseToolKind)) { }
        public Azure.AI.Extensions.OpenAI.AzureAISearchToolOptions AzureAISearch { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.AI.Extensions.OpenAI.ToolConfig> ToolConfigs { get { throw null; } }
        protected override OpenAI.Responses.ResponseTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override OpenAI.Responses.ResponseTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.AzureAISearchTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.AzureAISearchTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.AzureAISearchTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.AzureAISearchTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AzureAISearchTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AzureAISearchTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AzureAISearchTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP002")]
    public partial class AzureAISearchToolCall : OpenAI.Responses.ResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.AzureAISearchToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AzureAISearchToolCall>
    {
        public AzureAISearchToolCall(string callId, string arguments, Azure.AI.Extensions.OpenAI.ToolCallStatus status) : base (default(OpenAI.Responses.ResponseItemKind)) { }
        public string Arguments { get { throw null; } set { } }
        public string CallId { get { throw null; } set { } }
        public Azure.AI.Extensions.OpenAI.ToolCallStatus Status { get { throw null; } set { } }
        protected override OpenAI.Responses.ResponseItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override OpenAI.Responses.ResponseItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.AzureAISearchToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.AzureAISearchToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.AzureAISearchToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.AzureAISearchToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AzureAISearchToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AzureAISearchToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AzureAISearchToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP002")]
    public partial class AzureAISearchToolCallOutput : OpenAI.Responses.ResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.AzureAISearchToolCallOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AzureAISearchToolCallOutput>
    {
        public AzureAISearchToolCallOutput(string callId, Azure.AI.Extensions.OpenAI.ToolCallStatus status) : base (default(OpenAI.Responses.ResponseItemKind)) { }
        public string CallId { get { throw null; } set { } }
        public System.BinaryData Output { get { throw null; } set { } }
        public Azure.AI.Extensions.OpenAI.ToolCallStatus Status { get { throw null; } set { } }
        protected override OpenAI.Responses.ResponseItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override OpenAI.Responses.ResponseItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.AzureAISearchToolCallOutput System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.AzureAISearchToolCallOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.AzureAISearchToolCallOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.AzureAISearchToolCallOutput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AzureAISearchToolCallOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AzureAISearchToolCallOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AzureAISearchToolCallOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureAISearchToolIndex : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.AzureAISearchToolIndex>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AzureAISearchToolIndex>
    {
        public AzureAISearchToolIndex() { }
        public string Filter { get { throw null; } set { } }
        public string IndexAssetId { get { throw null; } set { } }
        public string IndexName { get { throw null; } set { } }
        public string ProjectConnectionId { get { throw null; } set { } }
        public Azure.AI.Extensions.OpenAI.AzureAISearchQueryKind? QueryType { get { throw null; } set { } }
        public int? TopK { get { throw null; } set { } }
        protected virtual Azure.AI.Extensions.OpenAI.AzureAISearchToolIndex JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Extensions.OpenAI.AzureAISearchToolIndex PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.AzureAISearchToolIndex System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.AzureAISearchToolIndex>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.AzureAISearchToolIndex>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.AzureAISearchToolIndex System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AzureAISearchToolIndex>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AzureAISearchToolIndex>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AzureAISearchToolIndex>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureAISearchToolOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.AzureAISearchToolOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AzureAISearchToolOptions>
    {
        public AzureAISearchToolOptions(System.Collections.Generic.IEnumerable<Azure.AI.Extensions.OpenAI.AzureAISearchToolIndex> indexes) { }
        public System.Collections.Generic.IList<Azure.AI.Extensions.OpenAI.AzureAISearchToolIndex> Indexes { get { throw null; } }
        protected virtual Azure.AI.Extensions.OpenAI.AzureAISearchToolOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Extensions.OpenAI.AzureAISearchToolOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.AzureAISearchToolOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.AzureAISearchToolOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.AzureAISearchToolOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.AzureAISearchToolOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AzureAISearchToolOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AzureAISearchToolOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AzureAISearchToolOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureFunctionBinding : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.AzureFunctionBinding>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AzureFunctionBinding>
    {
        public AzureFunctionBinding(Azure.AI.Extensions.OpenAI.AzureFunctionStorageQueue storageQueue) { }
        public string Kind { get { throw null; } }
        public Azure.AI.Extensions.OpenAI.AzureFunctionStorageQueue StorageQueue { get { throw null; } set { } }
        protected virtual Azure.AI.Extensions.OpenAI.AzureFunctionBinding JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Extensions.OpenAI.AzureFunctionBinding PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.AzureFunctionBinding System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.AzureFunctionBinding>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.AzureFunctionBinding>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.AzureFunctionBinding System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AzureFunctionBinding>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AzureFunctionBinding>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AzureFunctionBinding>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureFunctionDefinition : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.AzureFunctionDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AzureFunctionDefinition>
    {
        public AzureFunctionDefinition(Azure.AI.Extensions.OpenAI.AzureFunctionDefinitionFunction function, Azure.AI.Extensions.OpenAI.AzureFunctionBinding inputBinding, Azure.AI.Extensions.OpenAI.AzureFunctionBinding outputBinding) { }
        public Azure.AI.Extensions.OpenAI.AzureFunctionDefinitionFunction Function { get { throw null; } set { } }
        public Azure.AI.Extensions.OpenAI.AzureFunctionBinding InputBinding { get { throw null; } set { } }
        public Azure.AI.Extensions.OpenAI.AzureFunctionBinding OutputBinding { get { throw null; } set { } }
        protected virtual Azure.AI.Extensions.OpenAI.AzureFunctionDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Extensions.OpenAI.AzureFunctionDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.AzureFunctionDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.AzureFunctionDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.AzureFunctionDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.AzureFunctionDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AzureFunctionDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AzureFunctionDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AzureFunctionDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureFunctionDefinitionFunction : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.AzureFunctionDefinitionFunction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AzureFunctionDefinitionFunction>
    {
        public AzureFunctionDefinitionFunction(string name, System.BinaryData parameters) { }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.BinaryData Parameters { get { throw null; } set { } }
        protected virtual Azure.AI.Extensions.OpenAI.AzureFunctionDefinitionFunction JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Extensions.OpenAI.AzureFunctionDefinitionFunction PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.AzureFunctionDefinitionFunction System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.AzureFunctionDefinitionFunction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.AzureFunctionDefinitionFunction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.AzureFunctionDefinitionFunction System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AzureFunctionDefinitionFunction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AzureFunctionDefinitionFunction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AzureFunctionDefinitionFunction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureFunctionStorageQueue : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.AzureFunctionStorageQueue>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AzureFunctionStorageQueue>
    {
        public AzureFunctionStorageQueue(string queueServiceEndpoint, string queueName) { }
        public string QueueName { get { throw null; } set { } }
        public string QueueServiceEndpoint { get { throw null; } set { } }
        protected virtual Azure.AI.Extensions.OpenAI.AzureFunctionStorageQueue JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Extensions.OpenAI.AzureFunctionStorageQueue PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.AzureFunctionStorageQueue System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.AzureFunctionStorageQueue>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.AzureFunctionStorageQueue>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.AzureFunctionStorageQueue System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AzureFunctionStorageQueue>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AzureFunctionStorageQueue>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AzureFunctionStorageQueue>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP002")]
    public partial class AzureFunctionTool : OpenAI.Responses.ResponseTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.AzureFunctionTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AzureFunctionTool>
    {
        public AzureFunctionTool(Azure.AI.Extensions.OpenAI.AzureFunctionDefinition azureFunction) : base (default(OpenAI.Responses.ResponseToolKind)) { }
        public Azure.AI.Extensions.OpenAI.AzureFunctionDefinition AzureFunction { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.AI.Extensions.OpenAI.ToolConfig> ToolConfigs { get { throw null; } }
        protected override OpenAI.Responses.ResponseTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override OpenAI.Responses.ResponseTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.AzureFunctionTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.AzureFunctionTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.AzureFunctionTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.AzureFunctionTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AzureFunctionTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AzureFunctionTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AzureFunctionTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class AzureFunctionToolCall : OpenAI.Responses.ResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.AzureFunctionToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AzureFunctionToolCall>
    {
        public AzureFunctionToolCall(string callId, string name, string arguments, Azure.AI.Extensions.OpenAI.ToolCallStatus status) : base (default(OpenAI.Responses.ResponseItemKind)) { }
        public string Arguments { get { throw null; } set { } }
        public string CallId { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.AI.Extensions.OpenAI.ToolCallStatus Status { get { throw null; } set { } }
        protected override OpenAI.Responses.ResponseItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override OpenAI.Responses.ResponseItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.AzureFunctionToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.AzureFunctionToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.AzureFunctionToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.AzureFunctionToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AzureFunctionToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AzureFunctionToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AzureFunctionToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP002")]
    public partial class AzureFunctionToolCallOutput : OpenAI.Responses.ResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.AzureFunctionToolCallOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AzureFunctionToolCallOutput>
    {
        public AzureFunctionToolCallOutput(string callId, string name, Azure.AI.Extensions.OpenAI.ToolCallStatus status) : base (default(OpenAI.Responses.ResponseItemKind)) { }
        public string CallId { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.BinaryData Output { get { throw null; } set { } }
        public Azure.AI.Extensions.OpenAI.ToolCallStatus Status { get { throw null; } set { } }
        protected override OpenAI.Responses.ResponseItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override OpenAI.Responses.ResponseItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.AzureFunctionToolCallOutput System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.AzureFunctionToolCallOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.AzureFunctionToolCallOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.AzureFunctionToolCallOutput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AzureFunctionToolCallOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AzureFunctionToolCallOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AzureFunctionToolCallOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class BingCustomSearchConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.BingCustomSearchConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BingCustomSearchConfiguration>
    {
        public BingCustomSearchConfiguration(string projectConnectionId, string instanceName) { }
        public long? Count { get { throw null; } set { } }
        public string Freshness { get { throw null; } set { } }
        public string InstanceName { get { throw null; } set { } }
        public string Market { get { throw null; } set { } }
        public string ProjectConnectionId { get { throw null; } set { } }
        public string SetLang { get { throw null; } set { } }
        protected virtual Azure.AI.Extensions.OpenAI.BingCustomSearchConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Extensions.OpenAI.BingCustomSearchConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.BingCustomSearchConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.BingCustomSearchConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.BingCustomSearchConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.BingCustomSearchConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BingCustomSearchConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BingCustomSearchConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BingCustomSearchConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class BingCustomSearchPreviewTool : OpenAI.Responses.ResponseTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.BingCustomSearchPreviewTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BingCustomSearchPreviewTool>
    {
        public BingCustomSearchPreviewTool(Azure.AI.Extensions.OpenAI.BingCustomSearchToolOptions bingCustomSearchPreview) : base (default(OpenAI.Responses.ResponseToolKind)) { }
        public Azure.AI.Extensions.OpenAI.BingCustomSearchToolOptions BingCustomSearchPreview { get { throw null; } set { } }
        protected override OpenAI.Responses.ResponseTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override OpenAI.Responses.ResponseTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.BingCustomSearchPreviewTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.BingCustomSearchPreviewTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.BingCustomSearchPreviewTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.BingCustomSearchPreviewTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BingCustomSearchPreviewTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BingCustomSearchPreviewTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BingCustomSearchPreviewTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class BingCustomSearchToolCall : OpenAI.Responses.ResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.BingCustomSearchToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BingCustomSearchToolCall>
    {
        public BingCustomSearchToolCall(string callId, string arguments, Azure.AI.Extensions.OpenAI.ToolCallStatus status) : base (default(OpenAI.Responses.ResponseItemKind)) { }
        public string Arguments { get { throw null; } set { } }
        public string CallId { get { throw null; } set { } }
        public Azure.AI.Extensions.OpenAI.ToolCallStatus Status { get { throw null; } set { } }
        protected override OpenAI.Responses.ResponseItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override OpenAI.Responses.ResponseItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.BingCustomSearchToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.BingCustomSearchToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.BingCustomSearchToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.BingCustomSearchToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BingCustomSearchToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BingCustomSearchToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BingCustomSearchToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class BingCustomSearchToolCallOutput : OpenAI.Responses.ResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.BingCustomSearchToolCallOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BingCustomSearchToolCallOutput>
    {
        public BingCustomSearchToolCallOutput(string callId, Azure.AI.Extensions.OpenAI.ToolCallStatus status) : base (default(OpenAI.Responses.ResponseItemKind)) { }
        public string CallId { get { throw null; } set { } }
        public System.BinaryData Output { get { throw null; } set { } }
        public Azure.AI.Extensions.OpenAI.ToolCallStatus Status { get { throw null; } set { } }
        protected override OpenAI.Responses.ResponseItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override OpenAI.Responses.ResponseItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.BingCustomSearchToolCallOutput System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.BingCustomSearchToolCallOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.BingCustomSearchToolCallOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.BingCustomSearchToolCallOutput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BingCustomSearchToolCallOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BingCustomSearchToolCallOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BingCustomSearchToolCallOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class BingCustomSearchToolOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.BingCustomSearchToolOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BingCustomSearchToolOptions>
    {
        public BingCustomSearchToolOptions(System.Collections.Generic.IEnumerable<Azure.AI.Extensions.OpenAI.BingCustomSearchConfiguration> searchConfigurations) { }
        public System.Collections.Generic.IList<Azure.AI.Extensions.OpenAI.BingCustomSearchConfiguration> SearchConfigurations { get { throw null; } }
        protected virtual Azure.AI.Extensions.OpenAI.BingCustomSearchToolOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Extensions.OpenAI.BingCustomSearchToolOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.BingCustomSearchToolOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.BingCustomSearchToolOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.BingCustomSearchToolOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.BingCustomSearchToolOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BingCustomSearchToolOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BingCustomSearchToolOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BingCustomSearchToolOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BingGroundingSearchConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.BingGroundingSearchConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BingGroundingSearchConfiguration>
    {
        public BingGroundingSearchConfiguration(string projectConnectionId) { }
        public long? Count { get { throw null; } set { } }
        public string Freshness { get { throw null; } set { } }
        public string Language { get { throw null; } set { } }
        public string Market { get { throw null; } set { } }
        public string ProjectConnectionId { get { throw null; } set { } }
        protected virtual Azure.AI.Extensions.OpenAI.BingGroundingSearchConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Extensions.OpenAI.BingGroundingSearchConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.BingGroundingSearchConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.BingGroundingSearchConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.BingGroundingSearchConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.BingGroundingSearchConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BingGroundingSearchConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BingGroundingSearchConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BingGroundingSearchConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BingGroundingSearchToolOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.BingGroundingSearchToolOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BingGroundingSearchToolOptions>
    {
        public BingGroundingSearchToolOptions(System.Collections.Generic.IEnumerable<Azure.AI.Extensions.OpenAI.BingGroundingSearchConfiguration> searchConfigurations) { }
        public System.Collections.Generic.IList<Azure.AI.Extensions.OpenAI.BingGroundingSearchConfiguration> SearchConfigurations { get { throw null; } }
        protected virtual Azure.AI.Extensions.OpenAI.BingGroundingSearchToolOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Extensions.OpenAI.BingGroundingSearchToolOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.BingGroundingSearchToolOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.BingGroundingSearchToolOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.BingGroundingSearchToolOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.BingGroundingSearchToolOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BingGroundingSearchToolOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BingGroundingSearchToolOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BingGroundingSearchToolOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP002")]
    public partial class BingGroundingTool : OpenAI.Responses.ResponseTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.BingGroundingTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BingGroundingTool>
    {
        public BingGroundingTool(Azure.AI.Extensions.OpenAI.BingGroundingSearchToolOptions bingGrounding) : base (default(OpenAI.Responses.ResponseToolKind)) { }
        public Azure.AI.Extensions.OpenAI.BingGroundingSearchToolOptions BingGrounding { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.AI.Extensions.OpenAI.ToolConfig> ToolConfigs { get { throw null; } }
        protected override OpenAI.Responses.ResponseTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override OpenAI.Responses.ResponseTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.BingGroundingTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.BingGroundingTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.BingGroundingTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.BingGroundingTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BingGroundingTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BingGroundingTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BingGroundingTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP002")]
    public partial class BingGroundingToolCall : OpenAI.Responses.ResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.BingGroundingToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BingGroundingToolCall>
    {
        public BingGroundingToolCall(string callId, string arguments, Azure.AI.Extensions.OpenAI.ToolCallStatus status) : base (default(OpenAI.Responses.ResponseItemKind)) { }
        public string Arguments { get { throw null; } set { } }
        public string CallId { get { throw null; } set { } }
        public Azure.AI.Extensions.OpenAI.ToolCallStatus Status { get { throw null; } set { } }
        protected override OpenAI.Responses.ResponseItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override OpenAI.Responses.ResponseItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.BingGroundingToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.BingGroundingToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.BingGroundingToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.BingGroundingToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BingGroundingToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BingGroundingToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BingGroundingToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP002")]
    public partial class BingGroundingToolCallOutput : OpenAI.Responses.ResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.BingGroundingToolCallOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BingGroundingToolCallOutput>
    {
        public BingGroundingToolCallOutput(string callId, Azure.AI.Extensions.OpenAI.ToolCallStatus status) : base (default(OpenAI.Responses.ResponseItemKind)) { }
        public string CallId { get { throw null; } set { } }
        public System.BinaryData Output { get { throw null; } set { } }
        public Azure.AI.Extensions.OpenAI.ToolCallStatus Status { get { throw null; } set { } }
        protected override OpenAI.Responses.ResponseItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override OpenAI.Responses.ResponseItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.BingGroundingToolCallOutput System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.BingGroundingToolCallOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.BingGroundingToolCallOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.BingGroundingToolCallOutput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BingGroundingToolCallOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BingGroundingToolCallOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BingGroundingToolCallOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class BrowserAutomationPreviewTool : OpenAI.Responses.ResponseTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.BrowserAutomationPreviewTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BrowserAutomationPreviewTool>
    {
        public BrowserAutomationPreviewTool(Azure.AI.Extensions.OpenAI.BrowserAutomationToolOptions browserAutomationPreview) : base (default(OpenAI.Responses.ResponseToolKind)) { }
        public Azure.AI.Extensions.OpenAI.BrowserAutomationToolOptions BrowserAutomationPreview { get { throw null; } set { } }
        protected override OpenAI.Responses.ResponseTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override OpenAI.Responses.ResponseTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.BrowserAutomationPreviewTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.BrowserAutomationPreviewTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.BrowserAutomationPreviewTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.BrowserAutomationPreviewTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BrowserAutomationPreviewTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BrowserAutomationPreviewTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BrowserAutomationPreviewTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class BrowserAutomationToolCall : OpenAI.Responses.ResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.BrowserAutomationToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BrowserAutomationToolCall>
    {
        public BrowserAutomationToolCall(string callId, string arguments, Azure.AI.Extensions.OpenAI.ToolCallStatus status) : base (default(OpenAI.Responses.ResponseItemKind)) { }
        public string Arguments { get { throw null; } set { } }
        public string CallId { get { throw null; } set { } }
        public Azure.AI.Extensions.OpenAI.ToolCallStatus Status { get { throw null; } set { } }
        protected override OpenAI.Responses.ResponseItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override OpenAI.Responses.ResponseItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.BrowserAutomationToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.BrowserAutomationToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.BrowserAutomationToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.BrowserAutomationToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BrowserAutomationToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BrowserAutomationToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BrowserAutomationToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class BrowserAutomationToolCallOutput : OpenAI.Responses.ResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.BrowserAutomationToolCallOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BrowserAutomationToolCallOutput>
    {
        public BrowserAutomationToolCallOutput(string callId, Azure.AI.Extensions.OpenAI.ToolCallStatus status) : base (default(OpenAI.Responses.ResponseItemKind)) { }
        public string CallId { get { throw null; } set { } }
        public System.BinaryData Output { get { throw null; } set { } }
        public Azure.AI.Extensions.OpenAI.ToolCallStatus Status { get { throw null; } set { } }
        protected override OpenAI.Responses.ResponseItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override OpenAI.Responses.ResponseItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.BrowserAutomationToolCallOutput System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.BrowserAutomationToolCallOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.BrowserAutomationToolCallOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.BrowserAutomationToolCallOutput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BrowserAutomationToolCallOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BrowserAutomationToolCallOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BrowserAutomationToolCallOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class BrowserAutomationToolConnectionParameters : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.BrowserAutomationToolConnectionParameters>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BrowserAutomationToolConnectionParameters>
    {
        public BrowserAutomationToolConnectionParameters(string projectConnectionId) { }
        public string ProjectConnectionId { get { throw null; } set { } }
        protected virtual Azure.AI.Extensions.OpenAI.BrowserAutomationToolConnectionParameters JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Extensions.OpenAI.BrowserAutomationToolConnectionParameters PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.BrowserAutomationToolConnectionParameters System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.BrowserAutomationToolConnectionParameters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.BrowserAutomationToolConnectionParameters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.BrowserAutomationToolConnectionParameters System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BrowserAutomationToolConnectionParameters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BrowserAutomationToolConnectionParameters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BrowserAutomationToolConnectionParameters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class BrowserAutomationToolOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.BrowserAutomationToolOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BrowserAutomationToolOptions>
    {
        public BrowserAutomationToolOptions(Azure.AI.Extensions.OpenAI.BrowserAutomationToolConnectionParameters connection) { }
        public Azure.AI.Extensions.OpenAI.BrowserAutomationToolConnectionParameters Connection { get { throw null; } set { } }
        protected virtual Azure.AI.Extensions.OpenAI.BrowserAutomationToolOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Extensions.OpenAI.BrowserAutomationToolOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.BrowserAutomationToolOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.BrowserAutomationToolOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.BrowserAutomationToolOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.BrowserAutomationToolOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BrowserAutomationToolOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BrowserAutomationToolOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BrowserAutomationToolOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP002")]
    public partial class CaptureStructuredOutputsTool : OpenAI.Responses.ResponseTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.CaptureStructuredOutputsTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.CaptureStructuredOutputsTool>
    {
        public CaptureStructuredOutputsTool(Azure.AI.Extensions.OpenAI.StructuredOutputDefinition outputDefinition) : base (default(OpenAI.Responses.ResponseToolKind)) { }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.AI.Extensions.OpenAI.StructuredOutputDefinition OutputDefinition { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.AI.Extensions.OpenAI.ToolConfig> ToolConfigs { get { throw null; } }
        protected override OpenAI.Responses.ResponseTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override OpenAI.Responses.ResponseTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.CaptureStructuredOutputsTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.CaptureStructuredOutputsTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.CaptureStructuredOutputsTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.CaptureStructuredOutputsTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.CaptureStructuredOutputsTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.CaptureStructuredOutputsTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.CaptureStructuredOutputsTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class ChatSummaryMemoryItem : Azure.AI.Extensions.OpenAI.MemoryOutputItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ChatSummaryMemoryItem>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ChatSummaryMemoryItem>
    {
        public ChatSummaryMemoryItem(string memoryId, System.DateTimeOffset updatedAt, string scope, string content) { }
        protected override Azure.AI.Extensions.OpenAI.MemoryOutputItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Extensions.OpenAI.MemoryOutputItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.ChatSummaryMemoryItem System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ChatSummaryMemoryItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ChatSummaryMemoryItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.ChatSummaryMemoryItem System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ChatSummaryMemoryItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ChatSummaryMemoryItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ChatSummaryMemoryItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContentFilterConfiguration
    {
        public ContentFilterConfiguration(string policyName) { }
        public string PolicyName { get { throw null; } set { } }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("OPENAI001")]
    public static partial class CreateResponseOptionsExtensions
    {
        public static Azure.AI.Extensions.OpenAI.AgentReference get_Agent(OpenAI.Responses.CreateResponseOptions options) { throw null; }
        public static string get_AgentConversationId(OpenAI.Responses.CreateResponseOptions options) { throw null; }
        public static void set_Agent(OpenAI.Responses.CreateResponseOptions options, Azure.AI.Extensions.OpenAI.AgentReference value) { }
        public static void set_AgentConversationId(OpenAI.Responses.CreateResponseOptions options, string value) { }
        public sealed partial class <G>$9441C364D6D7BED1E759B10623E362FD
        {
            internal <G>$9441C364D6D7BED1E759B10623E362FD() { }
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("SCME0001")]
            public Azure.AI.Extensions.OpenAI.AgentReference Agent { get { throw null; } set { } }
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("SCME0001")]
            public string AgentConversationId { get { throw null; } set { } }
            public static partial class <M>$CF4B939802E692FD9BEF27F36FABED87
            {
                public static void <Extension>$(OpenAI.Responses.CreateResponseOptions options) { }
            }
        }
    }
    public static partial class ExtensionsOpenAIModelFactory
    {
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Extensions.OpenAI.A2APreviewTool A2APreviewTool(System.Uri baseUri = null, string agentCardPath = null, string projectConnectionId = null, bool? sendCredentialsForAgentCard = default(bool?)) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Extensions.OpenAI.A2AToolCall A2AToolCall(OpenAI.Responses.ResponseItemKind type = default(OpenAI.Responses.ResponseItemKind), string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, string name = null, string arguments = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Extensions.OpenAI.A2AToolCallOutput A2AToolCallOutput(OpenAI.Responses.ResponseItemKind type = default(OpenAI.Responses.ResponseItemKind), string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, string name = null, System.BinaryData output = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        public static Azure.AI.Extensions.OpenAI.AgentReference AgentReference(string name = null, string version = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP002")]
        public static Azure.AI.Extensions.OpenAI.AgentStructuredOutputsResponseItem AgentStructuredOutputsResponseItem(OpenAI.Responses.ResponseItemKind type = default(OpenAI.Responses.ResponseItemKind), string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, System.BinaryData output = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP002")]
        public static Azure.AI.Extensions.OpenAI.AgentWorkflowPreviewActionResponseItem AgentWorkflowPreviewActionResponseItem(OpenAI.Responses.ResponseItemKind type = default(OpenAI.Responses.ResponseItemKind), string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string csdlActionKind = null, string actionId = null, string parentActionId = null, string previousActionId = null, Azure.AI.Extensions.OpenAI.AgentWorkflowPreviewActionStatus? status = default(Azure.AI.Extensions.OpenAI.AgentWorkflowPreviewActionStatus?)) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP002")]
        public static Azure.AI.Extensions.OpenAI.AzureAISearchTool AzureAISearchTool(string name = null, string description = null, System.Collections.Generic.IDictionary<string, Azure.AI.Extensions.OpenAI.ToolConfig> toolConfigs = null, Azure.AI.Extensions.OpenAI.AzureAISearchToolOptions azureAISearch = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP002")]
        public static Azure.AI.Extensions.OpenAI.AzureAISearchToolCall AzureAISearchToolCall(OpenAI.Responses.ResponseItemKind type = default(OpenAI.Responses.ResponseItemKind), string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, string arguments = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP002")]
        public static Azure.AI.Extensions.OpenAI.AzureAISearchToolCallOutput AzureAISearchToolCallOutput(OpenAI.Responses.ResponseItemKind type = default(OpenAI.Responses.ResponseItemKind), string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, System.BinaryData output = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        public static Azure.AI.Extensions.OpenAI.AzureAISearchToolIndex AzureAISearchToolIndex(string projectConnectionId = null, string indexName = null, Azure.AI.Extensions.OpenAI.AzureAISearchQueryKind? queryType = default(Azure.AI.Extensions.OpenAI.AzureAISearchQueryKind?), int? topK = default(int?), string filter = null, string indexAssetId = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.AzureAISearchToolOptions AzureAISearchToolOptions(System.Collections.Generic.IEnumerable<Azure.AI.Extensions.OpenAI.AzureAISearchToolIndex> indexes = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.AzureFunctionBinding AzureFunctionBinding(Azure.AI.Extensions.OpenAI.AzureFunctionStorageQueue storageQueue = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.AzureFunctionDefinition AzureFunctionDefinition(Azure.AI.Extensions.OpenAI.AzureFunctionDefinitionFunction function = null, Azure.AI.Extensions.OpenAI.AzureFunctionBinding inputBinding = null, Azure.AI.Extensions.OpenAI.AzureFunctionBinding outputBinding = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.AzureFunctionDefinitionFunction AzureFunctionDefinitionFunction(string name = null, string description = null, System.BinaryData parameters = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.AzureFunctionStorageQueue AzureFunctionStorageQueue(string queueServiceEndpoint = null, string queueName = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP002")]
        public static Azure.AI.Extensions.OpenAI.AzureFunctionTool AzureFunctionTool(System.Collections.Generic.IDictionary<string, Azure.AI.Extensions.OpenAI.ToolConfig> toolConfigs = null, Azure.AI.Extensions.OpenAI.AzureFunctionDefinition azureFunction = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Extensions.OpenAI.AzureFunctionToolCall AzureFunctionToolCall(OpenAI.Responses.ResponseItemKind type = default(OpenAI.Responses.ResponseItemKind), string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, string name = null, string arguments = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP002")]
        public static Azure.AI.Extensions.OpenAI.AzureFunctionToolCallOutput AzureFunctionToolCallOutput(OpenAI.Responses.ResponseItemKind type = default(OpenAI.Responses.ResponseItemKind), string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, string name = null, System.BinaryData output = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Extensions.OpenAI.BingCustomSearchConfiguration BingCustomSearchConfiguration(string projectConnectionId = null, string instanceName = null, string market = null, string setLang = null, long? count = default(long?), string freshness = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Extensions.OpenAI.BingCustomSearchPreviewTool BingCustomSearchPreviewTool(Azure.AI.Extensions.OpenAI.BingCustomSearchToolOptions bingCustomSearchPreview = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Extensions.OpenAI.BingCustomSearchToolCall BingCustomSearchToolCall(OpenAI.Responses.ResponseItemKind type = default(OpenAI.Responses.ResponseItemKind), string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, string arguments = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Extensions.OpenAI.BingCustomSearchToolCallOutput BingCustomSearchToolCallOutput(OpenAI.Responses.ResponseItemKind type = default(OpenAI.Responses.ResponseItemKind), string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, System.BinaryData output = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Extensions.OpenAI.BingCustomSearchToolOptions BingCustomSearchToolOptions(System.Collections.Generic.IEnumerable<Azure.AI.Extensions.OpenAI.BingCustomSearchConfiguration> searchConfigurations = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.BingGroundingSearchConfiguration BingGroundingSearchConfiguration(string projectConnectionId = null, string market = null, string language = null, long? count = default(long?), string freshness = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.BingGroundingSearchToolOptions BingGroundingSearchToolOptions(System.Collections.Generic.IEnumerable<Azure.AI.Extensions.OpenAI.BingGroundingSearchConfiguration> searchConfigurations = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP002")]
        public static Azure.AI.Extensions.OpenAI.BingGroundingTool BingGroundingTool(string name = null, string description = null, System.Collections.Generic.IDictionary<string, Azure.AI.Extensions.OpenAI.ToolConfig> toolConfigs = null, Azure.AI.Extensions.OpenAI.BingGroundingSearchToolOptions bingGrounding = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP002")]
        public static Azure.AI.Extensions.OpenAI.BingGroundingToolCall BingGroundingToolCall(OpenAI.Responses.ResponseItemKind type = default(OpenAI.Responses.ResponseItemKind), string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, string arguments = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP002")]
        public static Azure.AI.Extensions.OpenAI.BingGroundingToolCallOutput BingGroundingToolCallOutput(OpenAI.Responses.ResponseItemKind type = default(OpenAI.Responses.ResponseItemKind), string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, System.BinaryData output = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Extensions.OpenAI.BrowserAutomationPreviewTool BrowserAutomationPreviewTool(Azure.AI.Extensions.OpenAI.BrowserAutomationToolOptions browserAutomationPreview = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Extensions.OpenAI.BrowserAutomationToolCall BrowserAutomationToolCall(OpenAI.Responses.ResponseItemKind type = default(OpenAI.Responses.ResponseItemKind), string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, string arguments = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Extensions.OpenAI.BrowserAutomationToolCallOutput BrowserAutomationToolCallOutput(OpenAI.Responses.ResponseItemKind type = default(OpenAI.Responses.ResponseItemKind), string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, System.BinaryData output = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Extensions.OpenAI.BrowserAutomationToolConnectionParameters BrowserAutomationToolConnectionParameters(string projectConnectionId = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Extensions.OpenAI.BrowserAutomationToolOptions BrowserAutomationToolOptions(Azure.AI.Extensions.OpenAI.BrowserAutomationToolConnectionParameters connection = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP002")]
        public static Azure.AI.Extensions.OpenAI.CaptureStructuredOutputsTool CaptureStructuredOutputsTool(string name = null, string description = null, System.Collections.Generic.IDictionary<string, Azure.AI.Extensions.OpenAI.ToolConfig> toolConfigs = null, Azure.AI.Extensions.OpenAI.StructuredOutputDefinition outputDefinition = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Extensions.OpenAI.ChatSummaryMemoryItem ChatSummaryMemoryItem(string memoryId = null, System.DateTimeOffset updatedAt = default(System.DateTimeOffset), string scope = null, string content = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Extensions.OpenAI.FabricDataAgentToolCall FabricDataAgentToolCall(OpenAI.Responses.ResponseItemKind type = default(OpenAI.Responses.ResponseItemKind), string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, string arguments = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Extensions.OpenAI.FabricDataAgentToolCallOutput FabricDataAgentToolCallOutput(OpenAI.Responses.ResponseItemKind type = default(OpenAI.Responses.ResponseItemKind), string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, System.BinaryData output = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Extensions.OpenAI.FabricDataAgentToolOptions FabricDataAgentToolOptions(System.Collections.Generic.IEnumerable<Azure.AI.Extensions.OpenAI.ToolProjectConnection> projectConnections = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Extensions.OpenAI.FabricIQPreviewTool FabricIQPreviewTool(string projectConnectionId = null, string serverLabel = null, System.Uri serverUri = null, Azure.AI.Extensions.OpenAI.FabricIQPreviewToolRequireApprovalChoice requireApproval = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Extensions.OpenAI.MemoryCommandToolCall MemoryCommandToolCall(OpenAI.Responses.ResponseItemKind type = default(OpenAI.Responses.ResponseItemKind), string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, string arguments = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Extensions.OpenAI.MemoryCommandToolCallOutput MemoryCommandToolCallOutput(OpenAI.Responses.ResponseItemKind type = default(OpenAI.Responses.ResponseItemKind), string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Extensions.OpenAI.MemoryOutputItem MemoryOutputItem(string memoryId = null, System.DateTimeOffset updatedAt = default(System.DateTimeOffset), string scope = null, string content = null, string kind = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Extensions.OpenAI.MemorySearchOptions MemorySearchOptions(int? maxMemories = default(int?)) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Extensions.OpenAI.MemorySearchPreviewTool MemorySearchPreviewTool(string memoryStoreName = null, string scope = null, Azure.AI.Extensions.OpenAI.MemorySearchOptions searchOptions = null, int? updateDelayInSeconds = default(int?)) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Extensions.OpenAI.MemorySearchToolCall MemorySearchToolCall(OpenAI.Responses.ResponseItemKind type = default(OpenAI.Responses.ResponseItemKind), string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress, System.Collections.Generic.IEnumerable<Azure.AI.Extensions.OpenAI.MemoryOutputItem> memories = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Extensions.OpenAI.MicrosoftFabricPreviewTool MicrosoftFabricPreviewTool(Azure.AI.Extensions.OpenAI.FabricDataAgentToolOptions toolOptions = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP002")]
        public static Azure.AI.Extensions.OpenAI.OAuthConsentRequestResponseItem OAuthConsentRequestResponseItem(OpenAI.Responses.ResponseItemKind type = default(OpenAI.Responses.ResponseItemKind), string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string id0 = null, string internalConsentLink = null, string serverLabel = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.OpenAPIAnonymousAuthenticationDetails OpenAPIAnonymousAuthenticationDetails() { throw null; }
        public static Azure.AI.Extensions.OpenAI.OpenApiAuthenticationDetails OpenApiAuthenticationDetails(string type = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.OpenApiFunctionDefinition OpenApiFunctionDefinition(string name = null, string description = null, System.Collections.Generic.IDictionary<string, System.BinaryData> specification = null, Azure.AI.Extensions.OpenAI.OpenApiAuthenticationDetails auth = null, System.Collections.Generic.IEnumerable<string> defaultParams = null, System.Collections.Generic.IEnumerable<Azure.AI.Extensions.OpenAI.OpenApiFunctionDefinitionFunction> functions = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.OpenApiFunctionDefinitionFunction OpenApiFunctionDefinitionFunction(string name = null, string description = null, System.Collections.Generic.IDictionary<string, System.BinaryData> parameters = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.OpenApiManagedAuthDetails OpenApiManagedAuthDetails(Azure.AI.Extensions.OpenAI.OpenApiManagedSecurityScheme securityScheme = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.OpenApiManagedSecurityScheme OpenApiManagedSecurityScheme(string audience = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.OpenApiProjectConnectionAuthenticationDetails OpenApiProjectConnectionAuthenticationDetails(Azure.AI.Extensions.OpenAI.OpenApiProjectConnectionSecurityScheme securityScheme = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.OpenApiProjectConnectionSecurityScheme OpenApiProjectConnectionSecurityScheme(string projectConnectionId = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP002")]
        public static Azure.AI.Extensions.OpenAI.OpenAPITool OpenAPITool(System.Collections.Generic.IDictionary<string, Azure.AI.Extensions.OpenAI.ToolConfig> toolConfigs = null, Azure.AI.Extensions.OpenAI.OpenApiFunctionDefinition functionDefinition = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP002")]
        public static Azure.AI.Extensions.OpenAI.OpenApiToolCall OpenApiToolCall(OpenAI.Responses.ResponseItemKind type = default(OpenAI.Responses.ResponseItemKind), string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, string name = null, string arguments = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP002")]
        public static Azure.AI.Extensions.OpenAI.OpenApiToolCallOutput OpenApiToolCallOutput(OpenAI.Responses.ResponseItemKind type = default(OpenAI.Responses.ResponseItemKind), string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, string name = null, System.BinaryData output = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Extensions.OpenAI.ProceduralMemoryItem ProceduralMemoryItem(string memoryId = null, System.DateTimeOffset updatedAt = default(System.DateTimeOffset), string scope = null, string content = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Extensions.OpenAI.SharepointGroundingToolCall SharepointGroundingToolCall(OpenAI.Responses.ResponseItemKind type = default(OpenAI.Responses.ResponseItemKind), string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, string arguments = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Extensions.OpenAI.SharepointGroundingToolCallOutput SharepointGroundingToolCallOutput(OpenAI.Responses.ResponseItemKind type = default(OpenAI.Responses.ResponseItemKind), string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, System.BinaryData output = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        public static Azure.AI.Extensions.OpenAI.SharePointGroundingToolOptions SharePointGroundingToolOptions(System.Collections.Generic.IEnumerable<Azure.AI.Extensions.OpenAI.ToolProjectConnection> projectConnections = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
<<<<<<< HEAD
        public static Azure.AI.Extensions.OpenAI.SharepointPreviewTool SharepointPreviewTool(Azure.AI.Extensions.OpenAI.SharePointGroundingToolOptions toolOptions = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.StructuredOutputDefinition StructuredOutputDefinition(string name = null, string description = null, System.Collections.Generic.IDictionary<string, System.BinaryData> schema = null, bool? isStrict = default(bool?)) { throw null; }
=======
        public static Azure.AI.Extensions.OpenAI.ResponsesBingCustomSearchPreviewTool ResponsesBingCustomSearchPreviewTool(Azure.AI.Extensions.OpenAI.ResponsesBingCustomSearchToolParameters bingCustomSearchPreview = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Extensions.OpenAI.ResponsesBingCustomSearchToolParameters ResponsesBingCustomSearchToolParameters(System.Collections.Generic.IEnumerable<Azure.AI.Extensions.OpenAI.ResponsesBingCustomSearchConfiguration> searchConfigurations = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesBingGroundingSearchConfiguration ResponsesBingGroundingSearchConfiguration(string projectConnectionId = null, string market = null, string language = null, long? count = default(long?), string freshness = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesBingGroundingSearchToolParameters ResponsesBingGroundingSearchToolParameters(System.Collections.Generic.IEnumerable<Azure.AI.Extensions.OpenAI.ResponsesBingGroundingSearchConfiguration> searchConfigurations = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesBingGroundingTool ResponsesBingGroundingTool(string name = null, string description = null, System.Collections.Generic.IDictionary<string, Azure.AI.Extensions.OpenAI.ToolConfig> toolConfigs = null, Azure.AI.Extensions.OpenAI.ResponsesBingGroundingSearchToolParameters bingGrounding = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Extensions.OpenAI.ResponsesBrowserAutomationPreviewTool ResponsesBrowserAutomationPreviewTool(Azure.AI.Extensions.OpenAI.ResponsesBrowserAutomationToolParameters browserAutomationPreview = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Extensions.OpenAI.ResponsesBrowserAutomationToolConnectionParameters ResponsesBrowserAutomationToolConnectionParameters(string projectConnectionId = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Extensions.OpenAI.ResponsesBrowserAutomationToolParameters ResponsesBrowserAutomationToolParameters(Azure.AI.Extensions.OpenAI.ResponsesBrowserAutomationToolConnectionParameters connection = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesCaptureStructuredOutputsTool ResponsesCaptureStructuredOutputsTool(string name = null, string description = null, System.Collections.Generic.IDictionary<string, Azure.AI.Extensions.OpenAI.ToolConfig> toolConfigs = null, Azure.AI.Extensions.OpenAI.ResponsesStructuredOutputDefinition outputDefinition = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesComputerTool ResponsesComputerTool() { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesContainerAutoParam ResponsesContainerAutoParam(System.Collections.Generic.IEnumerable<string> fileIds = null, Azure.AI.Extensions.OpenAI.ResponsesContainerMemoryLimit? memoryLimit = default(Azure.AI.Extensions.OpenAI.ResponsesContainerMemoryLimit?), System.Collections.Generic.IEnumerable<Azure.AI.Extensions.OpenAI.ContainerSkill> skills = null, Azure.AI.Extensions.OpenAI.ResponsesContainerNetworkPolicyParam networkPolicy = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesContainerNetworkPolicyAllowlistParam ResponsesContainerNetworkPolicyAllowlistParam(System.Collections.Generic.IEnumerable<string> allowedDomains = null, System.Collections.Generic.IEnumerable<Azure.AI.Extensions.OpenAI.ResponsesContainerNetworkPolicyDomainSecretParam> domainSecrets = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesContainerNetworkPolicyDisabledParam ResponsesContainerNetworkPolicyDisabledParam() { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesContainerNetworkPolicyDomainSecretParam ResponsesContainerNetworkPolicyDomainSecretParam(string domain = null, string name = null, string value = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesContainerNetworkPolicyParam ResponsesContainerNetworkPolicyParam(string type = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesCustomTextFormatParam ResponsesCustomTextFormatParam() { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesCustomToolParam ResponsesCustomToolParam(string name = null, string description = null, Azure.AI.Extensions.OpenAI.ResponsesCustomToolParamFormat format = null, bool? shouldDeferLoading = default(bool?)) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesCustomToolParamFormat ResponsesCustomToolParamFormat(string type = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesEmptyModelParam ResponsesEmptyModelParam() { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Extensions.OpenAI.ResponsesFabricDataAgentToolOptions ResponsesFabricDataAgentToolOptions(System.Collections.Generic.IEnumerable<Azure.AI.Extensions.OpenAI.ResponsesToolProjectConnection> projectConnections = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Extensions.OpenAI.ResponsesFabricIQPreviewTool ResponsesFabricIQPreviewTool(string projectConnectionId = null, string serverLabel = null, System.Uri serverUri = null, System.BinaryData requireApproval = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesFunctionShellToolParam ResponsesFunctionShellToolParam(Azure.AI.Extensions.OpenAI.ResponsesFunctionShellToolParamEnvironment environment = null, string name = null, string description = null, System.Collections.Generic.IDictionary<string, Azure.AI.Extensions.OpenAI.ToolConfig> toolConfigs = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesFunctionShellToolParamEnvironment ResponsesFunctionShellToolParamEnvironment(string type = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesFunctionShellToolParamEnvironmentContainerReferenceParam ResponsesFunctionShellToolParamEnvironmentContainerReferenceParam(string containerId = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesFunctionShellToolParamEnvironmentLocalEnvironmentParam ResponsesFunctionShellToolParamEnvironmentLocalEnvironmentParam(System.Collections.Generic.IEnumerable<Azure.AI.Extensions.OpenAI.LocalSkillParam> skills = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesFunctionToolParam ResponsesFunctionToolParam(string name = null, string description = null, Azure.AI.Extensions.OpenAI.ResponsesEmptyModelParam parameters = null, bool? isStrict = default(bool?), bool? shouldDeferLoading = default(bool?)) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesInlineSkillParam ResponsesInlineSkillParam(string name = null, string description = null, Azure.AI.Extensions.OpenAI.ResponsesInlineSkillSourceParam source = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesInlineSkillSourceParam ResponsesInlineSkillSourceParam(string data = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesLocalShellToolParam ResponsesLocalShellToolParam(string name = null, string description = null, System.Collections.Generic.IDictionary<string, Azure.AI.Extensions.OpenAI.ToolConfig> toolConfigs = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesMCPToolFilter ResponsesMCPToolFilter(System.Collections.Generic.IEnumerable<string> toolNames = null, bool? isReadOnly = default(bool?)) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesMCPToolRequireApproval ResponsesMCPToolRequireApproval(Azure.AI.Extensions.OpenAI.ResponsesMCPToolFilter always = null, Azure.AI.Extensions.OpenAI.ResponsesMCPToolFilter never = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Extensions.OpenAI.ResponsesMemorySearchOptions ResponsesMemorySearchOptions(int? maxMemories = default(int?)) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Extensions.OpenAI.ResponsesMemorySearchPreviewTool ResponsesMemorySearchPreviewTool(string memoryStoreName = null, string scope = null, Azure.AI.Extensions.OpenAI.ResponsesMemorySearchOptions searchOptions = null, int? updateDelayInSeconds = default(int?)) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Extensions.OpenAI.ResponsesMicrosoftFabricPreviewTool ResponsesMicrosoftFabricPreviewTool(Azure.AI.Extensions.OpenAI.ResponsesFabricDataAgentToolOptions fabricDataagentPreview = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesNamespaceToolParam ResponsesNamespaceToolParam(string name = null, string description = null, System.Collections.Generic.IEnumerable<System.BinaryData> tools = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesOpenApiAnonymousAuthDetails ResponsesOpenApiAnonymousAuthDetails() { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesOpenApiAuthDetails ResponsesOpenApiAuthDetails(string type = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesOpenApiFunctionDefinition ResponsesOpenApiFunctionDefinition(string name = null, string description = null, System.Collections.Generic.IDictionary<string, System.BinaryData> specification = null, Azure.AI.Extensions.OpenAI.ResponsesOpenApiAuthDetails auth = null, System.Collections.Generic.IEnumerable<string> defaultParams = null, System.Collections.Generic.IEnumerable<Azure.AI.Extensions.OpenAI.ResponsesOpenApiFunctionDefinitionFunction> functions = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesOpenApiFunctionDefinitionFunction ResponsesOpenApiFunctionDefinitionFunction(string name = null, string description = null, System.Collections.Generic.IDictionary<string, System.BinaryData> parameters = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesOpenApiManagedAuthDetails ResponsesOpenApiManagedAuthDetails(Azure.AI.Extensions.OpenAI.ResponsesOpenApiManagedSecurityScheme securityScheme = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesOpenApiManagedSecurityScheme ResponsesOpenApiManagedSecurityScheme(string audience = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesOpenApiProjectConnectionAuthDetails ResponsesOpenApiProjectConnectionAuthDetails(Azure.AI.Extensions.OpenAI.ResponsesOpenApiProjectConnectionSecurityScheme securityScheme = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesOpenApiProjectConnectionSecurityScheme ResponsesOpenApiProjectConnectionSecurityScheme(string projectConnectionId = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesOpenApiTool ResponsesOpenApiTool(System.Collections.Generic.IDictionary<string, Azure.AI.Extensions.OpenAI.ToolConfig> toolConfigs = null, Azure.AI.Extensions.OpenAI.ResponsesOpenApiFunctionDefinition openApi = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Extensions.OpenAI.ResponsesSharepointGroundingToolParameters ResponsesSharepointGroundingToolParameters(System.Collections.Generic.IEnumerable<Azure.AI.Extensions.OpenAI.ResponsesToolProjectConnection> projectConnections = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Extensions.OpenAI.ResponsesSharepointPreviewTool ResponsesSharepointPreviewTool(Azure.AI.Extensions.OpenAI.ResponsesSharepointGroundingToolParameters sharepointGroundingPreview = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesSkillReferenceParam ResponsesSkillReferenceParam(string skillId = null, string version = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesStructuredOutputDefinition ResponsesStructuredOutputDefinition(string name = null, string description = null, System.Collections.Generic.IDictionary<string, System.BinaryData> schema = null, bool? isStrict = default(bool?)) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesTool ResponsesTool(string type = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesToolProjectConnection ResponsesToolProjectConnection(string projectConnectionId = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesToolSearchToolParam ResponsesToolSearchToolParam(Azure.AI.Extensions.OpenAI.ResponsesToolSearchExecutionType? execution = default(Azure.AI.Extensions.OpenAI.ResponsesToolSearchExecutionType?), string description = null, Azure.AI.Extensions.OpenAI.ResponsesEmptyModelParam parameters = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesWebSearchApproximateLocation ResponsesWebSearchApproximateLocation(string country = null, string region = null, string city = null, string timezone = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesWebSearchConfiguration ResponsesWebSearchConfiguration(string projectConnectionId = null, string instanceName = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesWebSearchTool ResponsesWebSearchTool(Azure.AI.Extensions.OpenAI.WebSearchToolFilters filters = null, Azure.AI.Extensions.OpenAI.ResponsesWebSearchApproximateLocation userLocation = null, Azure.AI.Extensions.OpenAI.ResponsesWebSearchToolSearchContextSize? searchContextSize = default(Azure.AI.Extensions.OpenAI.ResponsesWebSearchToolSearchContextSize?), string name = null, string description = null, System.Collections.Generic.IDictionary<string, Azure.AI.Extensions.OpenAI.ToolConfig> toolConfigs = null, Azure.AI.Extensions.OpenAI.ResponsesWebSearchConfiguration customSearchConfiguration = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Extensions.OpenAI.ResponsesWorkIQPreviewTool ResponsesWorkIQPreviewTool(string projectConnectionId = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Extensions.OpenAI.SharepointGroundingToolCall SharepointGroundingToolCall(string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, string arguments = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Extensions.OpenAI.SharepointGroundingToolCallOutput SharepointGroundingToolCallOutput(string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, System.BinaryData output = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
>>>>>>> origin/main
        public static Azure.AI.Extensions.OpenAI.ToolConfig ToolConfig(bool? pin = default(bool?), string additionalSearchText = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ToolProjectConnection ToolProjectConnection(string projectConnectionId = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Extensions.OpenAI.UserProfileMemoryItem UserProfileMemoryItem(string memoryId = null, System.DateTimeOffset updatedAt = default(System.DateTimeOffset), string scope = null, string content = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.WebSearchConfiguration WebSearchConfiguration(string projectConnectionId = null, string instanceName = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Extensions.OpenAI.WorkIQPreviewTool WorkIQPreviewTool(string projectConnectionId = null) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class FabricDataAgentToolCall : OpenAI.Responses.ResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.FabricDataAgentToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.FabricDataAgentToolCall>
    {
        public FabricDataAgentToolCall(string callId, string arguments, Azure.AI.Extensions.OpenAI.ToolCallStatus status) : base (default(OpenAI.Responses.ResponseItemKind)) { }
        public string Arguments { get { throw null; } set { } }
        public string CallId { get { throw null; } set { } }
        public Azure.AI.Extensions.OpenAI.ToolCallStatus Status { get { throw null; } set { } }
        protected override OpenAI.Responses.ResponseItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override OpenAI.Responses.ResponseItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.FabricDataAgentToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.FabricDataAgentToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.FabricDataAgentToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.FabricDataAgentToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.FabricDataAgentToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.FabricDataAgentToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.FabricDataAgentToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class FabricDataAgentToolCallOutput : OpenAI.Responses.ResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.FabricDataAgentToolCallOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.FabricDataAgentToolCallOutput>
    {
        public FabricDataAgentToolCallOutput(string callId, Azure.AI.Extensions.OpenAI.ToolCallStatus status) : base (default(OpenAI.Responses.ResponseItemKind)) { }
        public string CallId { get { throw null; } set { } }
        public System.BinaryData Output { get { throw null; } set { } }
        public Azure.AI.Extensions.OpenAI.ToolCallStatus Status { get { throw null; } set { } }
        protected override OpenAI.Responses.ResponseItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override OpenAI.Responses.ResponseItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.FabricDataAgentToolCallOutput System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.FabricDataAgentToolCallOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.FabricDataAgentToolCallOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.FabricDataAgentToolCallOutput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.FabricDataAgentToolCallOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.FabricDataAgentToolCallOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.FabricDataAgentToolCallOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class FabricDataAgentToolOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.FabricDataAgentToolOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.FabricDataAgentToolOptions>
    {
        public FabricDataAgentToolOptions() { }
        public System.Collections.Generic.IList<Azure.AI.Extensions.OpenAI.ToolProjectConnection> ProjectConnections { get { throw null; } }
        protected virtual Azure.AI.Extensions.OpenAI.FabricDataAgentToolOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Extensions.OpenAI.FabricDataAgentToolOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.FabricDataAgentToolOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.FabricDataAgentToolOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.FabricDataAgentToolOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.FabricDataAgentToolOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.FabricDataAgentToolOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.FabricDataAgentToolOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.FabricDataAgentToolOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class FabricIQPreviewTool : OpenAI.Responses.ResponseTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.FabricIQPreviewTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.FabricIQPreviewTool>
    {
        public FabricIQPreviewTool(string projectConnectionId) : base (default(OpenAI.Responses.ResponseToolKind)) { }
        public string ProjectConnectionId { get { throw null; } set { } }
        public Azure.AI.Extensions.OpenAI.FabricIQPreviewToolRequireApprovalChoice RequireApproval { get { throw null; } set { } }
        public string ServerLabel { get { throw null; } set { } }
        public System.Uri ServerUri { get { throw null; } set { } }
        protected override OpenAI.Responses.ResponseTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override OpenAI.Responses.ResponseTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.FabricIQPreviewTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.FabricIQPreviewTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.FabricIQPreviewTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.FabricIQPreviewTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.FabricIQPreviewTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.FabricIQPreviewTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.FabricIQPreviewTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FabricIQPreviewToolRequireApprovalChoice : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.FabricIQPreviewToolRequireApprovalChoice>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.FabricIQPreviewToolRequireApprovalChoice>
    {
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("OPENAI001")]
        public FabricIQPreviewToolRequireApprovalChoice(OpenAI.Responses.McpToolCallApprovalPolicy approvalPolicy) { }
        public FabricIQPreviewToolRequireApprovalChoice(string approvalChoice) { }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("OPENAI001")]
        public OpenAI.Responses.McpToolCallApprovalPolicy ApprovalPolicy { get { throw null; } }
        public string ApprovalString { get { throw null; } }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("OPENAI001")]
        public static implicit operator Azure.AI.Extensions.OpenAI.FabricIQPreviewToolRequireApprovalChoice (OpenAI.Responses.McpToolCallApprovalPolicy approvalPolicy) { throw null; }
        public static implicit operator Azure.AI.Extensions.OpenAI.FabricIQPreviewToolRequireApprovalChoice (string approvalChoice) { throw null; }
        Azure.AI.Extensions.OpenAI.FabricIQPreviewToolRequireApprovalChoice System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.FabricIQPreviewToolRequireApprovalChoice>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.FabricIQPreviewToolRequireApprovalChoice>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.FabricIQPreviewToolRequireApprovalChoice System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.FabricIQPreviewToolRequireApprovalChoice>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.FabricIQPreviewToolRequireApprovalChoice>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.FabricIQPreviewToolRequireApprovalChoice>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class MemoryCommandToolCall : OpenAI.Responses.ResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.MemoryCommandToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.MemoryCommandToolCall>
    {
        public MemoryCommandToolCall(string callId, string arguments, Azure.AI.Extensions.OpenAI.ToolCallStatus status) : base (default(OpenAI.Responses.ResponseItemKind)) { }
        public string Arguments { get { throw null; } set { } }
        public string CallId { get { throw null; } set { } }
        public Azure.AI.Extensions.OpenAI.ToolCallStatus Status { get { throw null; } set { } }
        protected override OpenAI.Responses.ResponseItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override OpenAI.Responses.ResponseItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.MemoryCommandToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.MemoryCommandToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.MemoryCommandToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.MemoryCommandToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.MemoryCommandToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.MemoryCommandToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.MemoryCommandToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class MemoryCommandToolCallOutput : OpenAI.Responses.ResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.MemoryCommandToolCallOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.MemoryCommandToolCallOutput>
    {
        public MemoryCommandToolCallOutput(string callId, Azure.AI.Extensions.OpenAI.ToolCallStatus status) : base (default(OpenAI.Responses.ResponseItemKind)) { }
        public string CallId { get { throw null; } set { } }
        public Azure.AI.Extensions.OpenAI.ToolCallStatus Status { get { throw null; } set { } }
        protected override OpenAI.Responses.ResponseItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override OpenAI.Responses.ResponseItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.MemoryCommandToolCallOutput System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.MemoryCommandToolCallOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.MemoryCommandToolCallOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.MemoryCommandToolCallOutput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.MemoryCommandToolCallOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.MemoryCommandToolCallOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.MemoryCommandToolCallOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public abstract partial class MemoryOutputItem : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.MemoryOutputItem>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.MemoryOutputItem>
    {
        internal MemoryOutputItem() { }
        public string Content { get { throw null; } set { } }
        public string MemoryId { get { throw null; } set { } }
        public string Scope { get { throw null; } set { } }
        public System.DateTimeOffset UpdatedAt { get { throw null; } set { } }
        protected virtual Azure.AI.Extensions.OpenAI.MemoryOutputItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Extensions.OpenAI.MemoryOutputItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.MemoryOutputItem System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.MemoryOutputItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.MemoryOutputItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.MemoryOutputItem System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.MemoryOutputItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.MemoryOutputItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.MemoryOutputItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class MemorySearchOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.MemorySearchOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.MemorySearchOptions>
    {
        public MemorySearchOptions() { }
        public int? MaxMemories { get { throw null; } set { } }
        protected virtual Azure.AI.Extensions.OpenAI.MemorySearchOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Extensions.OpenAI.MemorySearchOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.MemorySearchOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.MemorySearchOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.MemorySearchOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.MemorySearchOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.MemorySearchOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.MemorySearchOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.MemorySearchOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class MemorySearchPreviewTool : OpenAI.Responses.ResponseTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.MemorySearchPreviewTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.MemorySearchPreviewTool>
    {
        public MemorySearchPreviewTool(string memoryStoreName, string scope) : base (default(OpenAI.Responses.ResponseToolKind)) { }
        public string MemoryStoreName { get { throw null; } set { } }
        public string Scope { get { throw null; } set { } }
        public Azure.AI.Extensions.OpenAI.MemorySearchOptions SearchOptions { get { throw null; } set { } }
        public int? UpdateDelayInSeconds { get { throw null; } set { } }
        protected override OpenAI.Responses.ResponseTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override OpenAI.Responses.ResponseTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.MemorySearchPreviewTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.MemorySearchPreviewTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.MemorySearchPreviewTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.MemorySearchPreviewTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.MemorySearchPreviewTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.MemorySearchPreviewTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.MemorySearchPreviewTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class MemorySearchToolCall : OpenAI.Responses.ResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.MemorySearchToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.MemorySearchToolCall>
    {
        public MemorySearchToolCall(Azure.AI.Extensions.OpenAI.ToolCallStatus status) : base (default(OpenAI.Responses.ResponseItemKind)) { }
        public System.Collections.Generic.IList<Azure.AI.Extensions.OpenAI.MemoryOutputItem> Memories { get { throw null; } set { } }
        public Azure.AI.Extensions.OpenAI.ToolCallStatus Status { get { throw null; } set { } }
        protected override OpenAI.Responses.ResponseItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override OpenAI.Responses.ResponseItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.MemorySearchToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.MemorySearchToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.MemorySearchToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.MemorySearchToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.MemorySearchToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.MemorySearchToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.MemorySearchToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class MicrosoftFabricPreviewTool : OpenAI.Responses.ResponseTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.MicrosoftFabricPreviewTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.MicrosoftFabricPreviewTool>
    {
        public MicrosoftFabricPreviewTool(Azure.AI.Extensions.OpenAI.FabricDataAgentToolOptions toolOptions) : base (default(OpenAI.Responses.ResponseToolKind)) { }
        public Azure.AI.Extensions.OpenAI.FabricDataAgentToolOptions ToolOptions { get { throw null; } set { } }
        protected override OpenAI.Responses.ResponseTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override OpenAI.Responses.ResponseTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.MicrosoftFabricPreviewTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.MicrosoftFabricPreviewTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.MicrosoftFabricPreviewTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.MicrosoftFabricPreviewTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.MicrosoftFabricPreviewTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.MicrosoftFabricPreviewTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.MicrosoftFabricPreviewTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP002")]
    public partial class OAuthConsentRequestResponseItem : OpenAI.Responses.ResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.OAuthConsentRequestResponseItem>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.OAuthConsentRequestResponseItem>
    {
        public OAuthConsentRequestResponseItem(string consentLink, string serverLabel) : base (default(OpenAI.Responses.ResponseItemKind)) { }
        public OAuthConsentRequestResponseItem(string id, string internalConsentLink, string serverLabel) : base (default(OpenAI.Responses.ResponseItemKind)) { }
        public OAuthConsentRequestResponseItem(System.Uri consentLink, string serverLabel) : base (default(OpenAI.Responses.ResponseItemKind)) { }
        public System.Uri ConsentLink { get { throw null; } }
        public new string Id { get { throw null; } set { } }
        public string ServerLabel { get { throw null; } set { } }
        protected override OpenAI.Responses.ResponseItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override OpenAI.Responses.ResponseItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.OAuthConsentRequestResponseItem System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.OAuthConsentRequestResponseItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.OAuthConsentRequestResponseItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.OAuthConsentRequestResponseItem System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.OAuthConsentRequestResponseItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.OAuthConsentRequestResponseItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.OAuthConsentRequestResponseItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OpenAPIAnonymousAuthenticationDetails : Azure.AI.Extensions.OpenAI.OpenApiAuthenticationDetails, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.OpenAPIAnonymousAuthenticationDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.OpenAPIAnonymousAuthenticationDetails>
    {
        public OpenAPIAnonymousAuthenticationDetails() { }
        protected override Azure.AI.Extensions.OpenAI.OpenApiAuthenticationDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Extensions.OpenAI.OpenApiAuthenticationDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.OpenAPIAnonymousAuthenticationDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.OpenAPIAnonymousAuthenticationDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.OpenAPIAnonymousAuthenticationDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.OpenAPIAnonymousAuthenticationDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.OpenAPIAnonymousAuthenticationDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.OpenAPIAnonymousAuthenticationDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.OpenAPIAnonymousAuthenticationDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class OpenApiAuthenticationDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.OpenApiAuthenticationDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.OpenApiAuthenticationDetails>
    {
        internal OpenApiAuthenticationDetails() { }
        protected virtual Azure.AI.Extensions.OpenAI.OpenApiAuthenticationDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Extensions.OpenAI.OpenApiAuthenticationDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.OpenApiAuthenticationDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.OpenApiAuthenticationDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.OpenApiAuthenticationDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.OpenApiAuthenticationDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.OpenApiAuthenticationDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.OpenApiAuthenticationDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.OpenApiAuthenticationDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OpenApiFunctionDefinition : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.OpenApiFunctionDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.OpenApiFunctionDefinition>
    {
        public OpenApiFunctionDefinition(string name, System.BinaryData specificationBytes, Azure.AI.Extensions.OpenAI.OpenApiAuthenticationDetails authentication) { }
        public OpenApiFunctionDefinition(string name, System.Collections.Generic.IDictionary<string, System.BinaryData> specification, Azure.AI.Extensions.OpenAI.OpenApiAuthenticationDetails auth) { }
        public Azure.AI.Extensions.OpenAI.OpenApiAuthenticationDetails Auth { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> DefaultParams { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Extensions.OpenAI.OpenApiFunctionDefinitionFunction> Functions { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Specification { get { throw null; } }
        protected virtual Azure.AI.Extensions.OpenAI.OpenApiFunctionDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Extensions.OpenAI.OpenApiFunctionDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.OpenApiFunctionDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.OpenApiFunctionDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.OpenApiFunctionDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.OpenApiFunctionDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.OpenApiFunctionDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.OpenApiFunctionDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.OpenApiFunctionDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OpenApiFunctionDefinitionFunction : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.OpenApiFunctionDefinitionFunction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.OpenApiFunctionDefinitionFunction>
    {
        internal OpenApiFunctionDefinitionFunction() { }
        public string Description { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Parameters { get { throw null; } }
        protected virtual Azure.AI.Extensions.OpenAI.OpenApiFunctionDefinitionFunction JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Extensions.OpenAI.OpenApiFunctionDefinitionFunction PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.OpenApiFunctionDefinitionFunction System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.OpenApiFunctionDefinitionFunction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.OpenApiFunctionDefinitionFunction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.OpenApiFunctionDefinitionFunction System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.OpenApiFunctionDefinitionFunction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.OpenApiFunctionDefinitionFunction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.OpenApiFunctionDefinitionFunction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OpenApiManagedAuthDetails : Azure.AI.Extensions.OpenAI.OpenApiAuthenticationDetails, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.OpenApiManagedAuthDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.OpenApiManagedAuthDetails>
    {
        public OpenApiManagedAuthDetails(Azure.AI.Extensions.OpenAI.OpenApiManagedSecurityScheme securityScheme) { }
        public Azure.AI.Extensions.OpenAI.OpenApiManagedSecurityScheme SecurityScheme { get { throw null; } set { } }
        protected override Azure.AI.Extensions.OpenAI.OpenApiAuthenticationDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Extensions.OpenAI.OpenApiAuthenticationDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.OpenApiManagedAuthDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.OpenApiManagedAuthDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.OpenApiManagedAuthDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.OpenApiManagedAuthDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.OpenApiManagedAuthDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.OpenApiManagedAuthDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.OpenApiManagedAuthDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OpenApiManagedSecurityScheme : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.OpenApiManagedSecurityScheme>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.OpenApiManagedSecurityScheme>
    {
        public OpenApiManagedSecurityScheme(string audience) { }
        public string Audience { get { throw null; } set { } }
        protected virtual Azure.AI.Extensions.OpenAI.OpenApiManagedSecurityScheme JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Extensions.OpenAI.OpenApiManagedSecurityScheme PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.OpenApiManagedSecurityScheme System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.OpenApiManagedSecurityScheme>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.OpenApiManagedSecurityScheme>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.OpenApiManagedSecurityScheme System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.OpenApiManagedSecurityScheme>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.OpenApiManagedSecurityScheme>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.OpenApiManagedSecurityScheme>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OpenApiProjectConnectionAuthenticationDetails : Azure.AI.Extensions.OpenAI.OpenApiAuthenticationDetails, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.OpenApiProjectConnectionAuthenticationDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.OpenApiProjectConnectionAuthenticationDetails>
    {
        public OpenApiProjectConnectionAuthenticationDetails(Azure.AI.Extensions.OpenAI.OpenApiProjectConnectionSecurityScheme securityScheme) { }
        public Azure.AI.Extensions.OpenAI.OpenApiProjectConnectionSecurityScheme SecurityScheme { get { throw null; } set { } }
        protected override Azure.AI.Extensions.OpenAI.OpenApiAuthenticationDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Extensions.OpenAI.OpenApiAuthenticationDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.OpenApiProjectConnectionAuthenticationDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.OpenApiProjectConnectionAuthenticationDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.OpenApiProjectConnectionAuthenticationDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.OpenApiProjectConnectionAuthenticationDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.OpenApiProjectConnectionAuthenticationDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.OpenApiProjectConnectionAuthenticationDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.OpenApiProjectConnectionAuthenticationDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OpenApiProjectConnectionSecurityScheme : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.OpenApiProjectConnectionSecurityScheme>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.OpenApiProjectConnectionSecurityScheme>
    {
        public OpenApiProjectConnectionSecurityScheme(string projectConnectionId) { }
        public string ProjectConnectionId { get { throw null; } set { } }
        protected virtual Azure.AI.Extensions.OpenAI.OpenApiProjectConnectionSecurityScheme JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Extensions.OpenAI.OpenApiProjectConnectionSecurityScheme PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.OpenApiProjectConnectionSecurityScheme System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.OpenApiProjectConnectionSecurityScheme>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.OpenApiProjectConnectionSecurityScheme>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.OpenApiProjectConnectionSecurityScheme System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.OpenApiProjectConnectionSecurityScheme>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.OpenApiProjectConnectionSecurityScheme>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.OpenApiProjectConnectionSecurityScheme>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP002")]
    public partial class OpenAPITool : OpenAI.Responses.ResponseTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.OpenAPITool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.OpenAPITool>
    {
        public OpenAPITool(Azure.AI.Extensions.OpenAI.OpenApiFunctionDefinition functionDefinition) : base (default(OpenAI.Responses.ResponseToolKind)) { }
        public Azure.AI.Extensions.OpenAI.OpenApiFunctionDefinition FunctionDefinition { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.AI.Extensions.OpenAI.ToolConfig> ToolConfigs { get { throw null; } }
        protected override OpenAI.Responses.ResponseTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override OpenAI.Responses.ResponseTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.OpenAPITool System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.OpenAPITool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.OpenAPITool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.OpenAPITool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.OpenAPITool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.OpenAPITool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.OpenAPITool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP002")]
    public partial class OpenApiToolCall : OpenAI.Responses.ResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.OpenApiToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.OpenApiToolCall>
    {
        public OpenApiToolCall(string callId, string name, string arguments, Azure.AI.Extensions.OpenAI.ToolCallStatus status) : base (default(OpenAI.Responses.ResponseItemKind)) { }
        public string Arguments { get { throw null; } set { } }
        public string CallId { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.AI.Extensions.OpenAI.ToolCallStatus Status { get { throw null; } set { } }
        protected override OpenAI.Responses.ResponseItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override OpenAI.Responses.ResponseItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.OpenApiToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.OpenApiToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.OpenApiToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.OpenApiToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.OpenApiToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.OpenApiToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.OpenApiToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP002")]
    public partial class OpenApiToolCallOutput : OpenAI.Responses.ResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.OpenApiToolCallOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.OpenApiToolCallOutput>
    {
        public OpenApiToolCallOutput(string callId, string name, Azure.AI.Extensions.OpenAI.ToolCallStatus status) : base (default(OpenAI.Responses.ResponseItemKind)) { }
        public string CallId { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.BinaryData Output { get { throw null; } set { } }
        public Azure.AI.Extensions.OpenAI.ToolCallStatus Status { get { throw null; } set { } }
        protected override OpenAI.Responses.ResponseItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override OpenAI.Responses.ResponseItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.OpenApiToolCallOutput System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.OpenApiToolCallOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.OpenApiToolCallOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.OpenApiToolCallOutput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.OpenApiToolCallOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.OpenApiToolCallOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.OpenApiToolCallOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class ProceduralMemoryItem : Azure.AI.Extensions.OpenAI.MemoryOutputItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ProceduralMemoryItem>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ProceduralMemoryItem>
    {
        public ProceduralMemoryItem(string memoryId, System.DateTimeOffset updatedAt, string scope, string content) { }
        protected override Azure.AI.Extensions.OpenAI.MemoryOutputItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Extensions.OpenAI.MemoryOutputItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.ProceduralMemoryItem System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ProceduralMemoryItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ProceduralMemoryItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.ProceduralMemoryItem System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ProceduralMemoryItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ProceduralMemoryItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ProceduralMemoryItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("OPENAI001")]
    public partial class ProjectConversationsClient : OpenAI.Conversations.ConversationClient
    {
        protected ProjectConversationsClient() { }
        public ProjectConversationsClient(System.ClientModel.Primitives.ClientPipeline pipeline, OpenAI.OpenAIClientOptions options) { }
        public virtual System.ClientModel.ClientResult<OpenAI.Conversations.ConversationResource> CreateProjectConversation(OpenAI.Conversations.ConversationCreationOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.Diagnostics.DebuggerStepThroughAttribute]
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<OpenAI.Conversations.ConversationResource>> CreateProjectConversationAsync(OpenAI.Conversations.ConversationCreationOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult<System.Collections.ObjectModel.ReadOnlyCollection<OpenAI.Responses.ResponseItem>> CreateProjectConversationItems(string conversationId, System.Collections.Generic.IEnumerable<OpenAI.Responses.ResponseItem> items, System.Collections.Generic.IEnumerable<OpenAI.Conversations.IncludedConversationItemProperty> include = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.Diagnostics.DebuggerStepThroughAttribute]
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<System.Collections.ObjectModel.ReadOnlyCollection<OpenAI.Responses.ResponseItem>>> CreateProjectConversationItemsAsync(string conversationId, System.Collections.Generic.IEnumerable<OpenAI.Responses.ResponseItem> items, System.Collections.Generic.IEnumerable<OpenAI.Conversations.IncludedConversationItemProperty> include = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult<OpenAI.Conversations.ConversationResource> GetProjectConversation(string conversationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.Diagnostics.DebuggerStepThroughAttribute]
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<OpenAI.Conversations.ConversationResource>> GetProjectConversationAsync(string conversationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult<OpenAI.Responses.ResponseItem> GetProjectConversationItem(string conversationId, string itemId, System.Collections.Generic.IEnumerable<OpenAI.Conversations.IncludedConversationItemProperty> include = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.Diagnostics.DebuggerStepThroughAttribute]
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<OpenAI.Responses.ResponseItem>> GetProjectConversationItemAsync(string conversationId, string itemId, System.Collections.Generic.IEnumerable<OpenAI.Conversations.IncludedConversationItemProperty> include = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.CollectionResult<OpenAI.Responses.ResponseItem> GetProjectConversationItems(string conversationId, OpenAI.Responses.ResponseItemKind? itemKind = default(OpenAI.Responses.ResponseItemKind?), int? limit = default(int?), string order = null, string after = null, string before = null, System.Collections.Generic.IEnumerable<OpenAI.Conversations.IncludedConversationItemProperty> include = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<OpenAI.Responses.ResponseItem> GetProjectConversationItemsAsync(string conversationId, OpenAI.Responses.ResponseItemKind? itemKind = default(OpenAI.Responses.ResponseItemKind?), int? limit = default(int?), string order = null, string after = null, string before = null, System.Collections.Generic.IEnumerable<OpenAI.Conversations.IncludedConversationItemProperty> include = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.CollectionResult<OpenAI.Conversations.ConversationResource> GetProjectConversations(Azure.AI.Extensions.OpenAI.AgentReference agent = null, int? limit = default(int?), string order = null, string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<OpenAI.Conversations.ConversationResource> GetProjectConversationsAsync(Azure.AI.Extensions.OpenAI.AgentReference agent = null, int? limit = default(int?), string order = null, string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult<OpenAI.Conversations.ConversationResource> UpdateProjectConversation(string conversationId, OpenAI.Conversations.ConversationUpdateOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.Diagnostics.DebuggerStepThroughAttribute]
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<OpenAI.Conversations.ConversationResource>> UpdateProjectConversationAsync(string conversationId, OpenAI.Conversations.ConversationUpdateOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ProjectFilesClient : OpenAI.Files.OpenAIFileClient
    {
        protected ProjectFilesClient() { }
    }
    public partial class ProjectOpenAIClient : OpenAI.OpenAIClient
    {
        protected ProjectOpenAIClient() { }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("SCME0002")]
        public ProjectOpenAIClient(Azure.AI.Extensions.OpenAI.ProjectOpenAIClientSettings settings) { }
        public ProjectOpenAIClient(System.ClientModel.Primitives.AuthenticationPolicy authenticationPolicy, Azure.AI.Extensions.OpenAI.ProjectOpenAIClientOptions options) { }
        protected internal ProjectOpenAIClient(System.ClientModel.Primitives.ClientPipeline pipeline, Azure.AI.Extensions.OpenAI.ProjectOpenAIClientOptions options) { }
        public ProjectOpenAIClient(System.Uri projectEndpoint, System.ClientModel.AuthenticationTokenProvider tokenProvider, Azure.AI.Extensions.OpenAI.ProjectOpenAIClientOptions options = null) { }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("OPENAI001")]
        public override OpenAI.Conversations.ConversationClient GetConversationClient() { throw null; }
        public override OpenAI.Files.OpenAIFileClient GetOpenAIFileClient() { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("OPENAI001")]
        public virtual Azure.AI.Extensions.OpenAI.ProjectConversationsClient GetProjectConversationsClient() { throw null; }
        public virtual Azure.AI.Extensions.OpenAI.ProjectFilesClient GetProjectFilesClient() { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("OPENAI001")]
        public virtual Azure.AI.Extensions.OpenAI.ProjectResponsesClient GetProjectResponsesClient() { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("OPENAI001")]
        public virtual Azure.AI.Extensions.OpenAI.ProjectResponsesClient GetProjectResponsesClientForAgent(Azure.AI.Extensions.OpenAI.AgentReference defaultAgent, string defaultConversationId = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("OPENAI001")]
        public virtual Azure.AI.Extensions.OpenAI.ProjectResponsesClient GetProjectResponsesClientForAgentEndpoint(string agentName, string defaultConversationId = null, Azure.AI.Extensions.OpenAI.ProjectOpenAIClientOptions options = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("OPENAI001")]
        public virtual Azure.AI.Extensions.OpenAI.ProjectResponsesClient GetProjectResponsesClientForModel(string defaultModel, string defaultConversationId = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("OPENAI001")]
        public virtual Azure.AI.Extensions.OpenAI.ProjectVectorStoresClient GetProjectVectorStoresClient() { throw null; }
    }
    public partial class ProjectOpenAIClientOptions : OpenAI.OpenAIClientOptions
    {
        public ProjectOpenAIClientOptions() { }
        public string AgentName { get { throw null; } set { } }
        public string ApiVersion { get { throw null; } set { } }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("SCME0002")]
    public partial class ProjectOpenAIClientSettings : System.ClientModel.Primitives.ClientSettings
    {
        public ProjectOpenAIClientSettings() { }
        public System.Uri Endpoint { get { throw null; } set { } }
        public Azure.AI.Extensions.OpenAI.ProjectOpenAIClientOptions Options { get { throw null; } set { } }
        protected override void BindCore(Microsoft.Extensions.Configuration.IConfigurationSection section) { }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("OPENAI001")]
    public partial class ProjectResponsesClient : OpenAI.Responses.ResponsesClient
    {
        protected ProjectResponsesClient() { }
        public ProjectResponsesClient(System.ClientModel.AuthenticationTokenProvider tokenProvider) { }
        public ProjectResponsesClient(System.ClientModel.AuthenticationTokenProvider tokenProvider, Azure.AI.Extensions.OpenAI.AgentReference defaultAgent, string defaultConversationId = null) { }
        public ProjectResponsesClient(System.ClientModel.AuthenticationTokenProvider tokenProvider, Azure.AI.Extensions.OpenAI.ProjectResponsesClientOptions options) { }
        public ProjectResponsesClient(System.ClientModel.AuthenticationTokenProvider tokenProvider, Azure.AI.Extensions.OpenAI.ProjectResponsesClientOptions options, Azure.AI.Extensions.OpenAI.AgentReference defaultAgent = null, string defaultConversationId = null) { }
        public ProjectResponsesClient(System.Uri projectEndpoint, System.ClientModel.AuthenticationTokenProvider tokenProvider) { }
        public ProjectResponsesClient(System.Uri projectEndpoint, System.ClientModel.AuthenticationTokenProvider tokenProvider, Azure.AI.Extensions.OpenAI.AgentReference defaultAgent, string defaultConversationId = null) { }
        public ProjectResponsesClient(System.Uri projectEndpoint, System.ClientModel.AuthenticationTokenProvider tokenProvider, Azure.AI.Extensions.OpenAI.AgentReference defaultAgent, string defaultConversationId, Azure.AI.Extensions.OpenAI.ProjectResponsesClientOptions options) { }
        public ProjectResponsesClient(System.Uri projectEndpoint, System.ClientModel.AuthenticationTokenProvider tokenProvider, Azure.AI.Extensions.OpenAI.ProjectResponsesClientOptions options) { }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public override System.ClientModel.ClientResult<OpenAI.Responses.ResponseResult> CreateResponse(OpenAI.Responses.CreateResponseOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult<OpenAI.Responses.ResponseResult> CreateResponse(System.Collections.Generic.IEnumerable<OpenAI.Responses.ResponseItem> inputItems, string previousResponseId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public override System.ClientModel.ClientResult<OpenAI.Responses.ResponseResult> CreateResponse(string model, System.Collections.Generic.IEnumerable<OpenAI.Responses.ResponseItem> inputItems, string previousResponseId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public override System.ClientModel.ClientResult<OpenAI.Responses.ResponseResult> CreateResponse(string model, string userInputText, string previousResponseId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult<OpenAI.Responses.ResponseResult> CreateResponse(string userInputText, string previousResponseId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        [System.Diagnostics.DebuggerStepThroughAttribute]
        public override System.Threading.Tasks.Task<System.ClientModel.ClientResult<OpenAI.Responses.ResponseResult>> CreateResponseAsync(OpenAI.Responses.CreateResponseOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.Diagnostics.DebuggerStepThroughAttribute]
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<OpenAI.Responses.ResponseResult>> CreateResponseAsync(System.Collections.Generic.IEnumerable<OpenAI.Responses.ResponseItem> inputItems, string previousResponseId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        [System.Diagnostics.DebuggerStepThroughAttribute]
        public override System.Threading.Tasks.Task<System.ClientModel.ClientResult<OpenAI.Responses.ResponseResult>> CreateResponseAsync(string model, System.Collections.Generic.IEnumerable<OpenAI.Responses.ResponseItem> inputItems, string previousResponseId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        [System.Diagnostics.DebuggerStepThroughAttribute]
        public override System.Threading.Tasks.Task<System.ClientModel.ClientResult<OpenAI.Responses.ResponseResult>> CreateResponseAsync(string model, string userInputText, string previousResponseId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.Diagnostics.DebuggerStepThroughAttribute]
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<OpenAI.Responses.ResponseResult>> CreateResponseAsync(string userInputText, string previousResponseId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.ClientModel.CollectionResult<OpenAI.Responses.StreamingResponseUpdate> CreateResponseStreaming(OpenAI.Responses.CreateResponseOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.CollectionResult<OpenAI.Responses.StreamingResponseUpdate> CreateResponseStreaming(System.Collections.Generic.IEnumerable<OpenAI.Responses.ResponseItem> inputItems, string previousResponseId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.ClientModel.CollectionResult<OpenAI.Responses.StreamingResponseUpdate> CreateResponseStreaming(string model, System.Collections.Generic.IEnumerable<OpenAI.Responses.ResponseItem> inputItems, string previousResponseId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.ClientModel.CollectionResult<OpenAI.Responses.StreamingResponseUpdate> CreateResponseStreaming(string model, string userInputText, string previousResponseId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.CollectionResult<OpenAI.Responses.StreamingResponseUpdate> CreateResponseStreaming(string userInputText, string previousResponseId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.ClientModel.AsyncCollectionResult<OpenAI.Responses.StreamingResponseUpdate> CreateResponseStreamingAsync(OpenAI.Responses.CreateResponseOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<OpenAI.Responses.StreamingResponseUpdate> CreateResponseStreamingAsync(System.Collections.Generic.IEnumerable<OpenAI.Responses.ResponseItem> inputItems, string previousResponseId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.ClientModel.AsyncCollectionResult<OpenAI.Responses.StreamingResponseUpdate> CreateResponseStreamingAsync(string model, System.Collections.Generic.IEnumerable<OpenAI.Responses.ResponseItem> inputItems, string previousResponseId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.ClientModel.AsyncCollectionResult<OpenAI.Responses.StreamingResponseUpdate> CreateResponseStreamingAsync(string model, string userInputText, string previousResponseId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<OpenAI.Responses.StreamingResponseUpdate> CreateResponseStreamingAsync(string userInputText, string previousResponseId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public virtual System.ClientModel.CollectionResult<OpenAI.Responses.ResponseResult> GetProjectResponses(Azure.AI.Extensions.OpenAI.AgentReference agent = null, string conversationId = null, int? limit = default(int?), string order = null, string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public virtual System.ClientModel.AsyncCollectionResult<OpenAI.Responses.ResponseResult> GetProjectResponsesAsync(Azure.AI.Extensions.OpenAI.AgentReference agent = null, string conversationId = null, int? limit = default(int?), string order = null, string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public override System.ClientModel.ClientResult<OpenAI.Responses.ResponseResult> GetResponse(OpenAI.Responses.GetResponseOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public override System.ClientModel.ClientResult<OpenAI.Responses.ResponseResult> GetResponse(string responseId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        [System.Diagnostics.DebuggerStepThroughAttribute]
        public override System.Threading.Tasks.Task<System.ClientModel.ClientResult<OpenAI.Responses.ResponseResult>> GetResponseAsync(OpenAI.Responses.GetResponseOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        [System.Diagnostics.DebuggerStepThroughAttribute]
        public override System.Threading.Tasks.Task<System.ClientModel.ClientResult<OpenAI.Responses.ResponseResult>> GetResponseAsync(string responseId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("OPENAI001")]
    public partial class ProjectResponsesClientOptions : OpenAI.Responses.ResponsesClientOptions
    {
        public ProjectResponsesClientOptions() { }
        public string AgentName { get { throw null; } set { } }
        public string ApiVersion { get { throw null; } set { } }
        public static implicit operator Azure.AI.Extensions.OpenAI.ProjectResponsesClientOptions (Azure.AI.Extensions.OpenAI.ProjectOpenAIClientOptions source) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("OPENAI001")]
    public partial class ProjectVectorStoresClient : OpenAI.VectorStores.VectorStoreClient
    {
        protected ProjectVectorStoresClient() { }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("OPENAI001")]
    public static partial class ResponseItemExtensions
    {
        public static Azure.AI.Extensions.OpenAI.AgentReference get_AgentReference(OpenAI.Responses.ResponseItem response) { throw null; }
        public static string get_ResponseId(OpenAI.Responses.ResponseItem response) { throw null; }
        public sealed partial class <G>$F3F0025ADD8FA456F8E93354548ADC99
        {
            internal <G>$F3F0025ADD8FA456F8E93354548ADC99() { }
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("SCME0001")]
            public Azure.AI.Extensions.OpenAI.AgentReference AgentReference { get { throw null; } }
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("SCME0001")]
            public string ResponseId { get { throw null; } }
            public static partial class <M>$A0346CDE72874621013C10377E404D94
            {
                public static void <Extension>$(OpenAI.Responses.ResponseItem response) { }
            }
        }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("OPENAI001")]
    public static partial class ResponseItemKindExtensions
    {
        public static OpenAI.Responses.ResponseItemKind get_A2APreviewCall() { throw null; }
        public static OpenAI.Responses.ResponseItemKind get_A2APreviewCallOutput() { throw null; }
        public static OpenAI.Responses.ResponseItemKind get_AzureAISearchCall() { throw null; }
        public static OpenAI.Responses.ResponseItemKind get_AzureAISearchCallOutput() { throw null; }
        public static OpenAI.Responses.ResponseItemKind get_AzureFunctionCall() { throw null; }
        public static OpenAI.Responses.ResponseItemKind get_AzureFunctionCallOutput() { throw null; }
        public static OpenAI.Responses.ResponseItemKind get_BingCustomSearchPreviewCall() { throw null; }
        public static OpenAI.Responses.ResponseItemKind get_BingCustomSearchPreviewCallOutput() { throw null; }
        public static OpenAI.Responses.ResponseItemKind get_BingGroundingCall() { throw null; }
        public static OpenAI.Responses.ResponseItemKind get_BingGroundingCallOutput() { throw null; }
        public static OpenAI.Responses.ResponseItemKind get_BrowserAutomationPreviewCall() { throw null; }
        public static OpenAI.Responses.ResponseItemKind get_BrowserAutomationPreviewCallOutput() { throw null; }
        public static OpenAI.Responses.ResponseItemKind get_FabricDataAgentPreviewCall() { throw null; }
        public static OpenAI.Responses.ResponseItemKind get_FabricDataAgentPreviewCallOutput() { throw null; }
        public static OpenAI.Responses.ResponseItemKind get_MemoryCommandPreviewCall() { throw null; }
        public static OpenAI.Responses.ResponseItemKind get_MemoryCommandPreviewCallOutput() { throw null; }
        public static OpenAI.Responses.ResponseItemKind get_MemorySearchCall() { throw null; }
        public static OpenAI.Responses.ResponseItemKind get_OAuthConsentRequest() { throw null; }
        public static OpenAI.Responses.ResponseItemKind get_OpenApiCall() { throw null; }
        public static OpenAI.Responses.ResponseItemKind get_OpenApiCallOutput() { throw null; }
        public static OpenAI.Responses.ResponseItemKind get_SharepointGroundingPreviewCall() { throw null; }
        public static OpenAI.Responses.ResponseItemKind get_SharepointGroundingPreviewCallOutput() { throw null; }
        public static OpenAI.Responses.ResponseItemKind get_StructuredOutputs() { throw null; }
        public static OpenAI.Responses.ResponseItemKind get_WorkflowAction() { throw null; }
        public sealed partial class <G>$85D7243A15CC11DE156F995836A4C406
        {
            internal <G>$85D7243A15CC11DE156F995836A4C406() { }
            public static OpenAI.Responses.ResponseItemKind A2APreviewCall { get { throw null; } }
            public static OpenAI.Responses.ResponseItemKind A2APreviewCallOutput { get { throw null; } }
            public static OpenAI.Responses.ResponseItemKind AzureAISearchCall { get { throw null; } }
            public static OpenAI.Responses.ResponseItemKind AzureAISearchCallOutput { get { throw null; } }
            public static OpenAI.Responses.ResponseItemKind AzureFunctionCall { get { throw null; } }
            public static OpenAI.Responses.ResponseItemKind AzureFunctionCallOutput { get { throw null; } }
            public static OpenAI.Responses.ResponseItemKind BingCustomSearchPreviewCall { get { throw null; } }
            public static OpenAI.Responses.ResponseItemKind BingCustomSearchPreviewCallOutput { get { throw null; } }
            public static OpenAI.Responses.ResponseItemKind BingGroundingCall { get { throw null; } }
            public static OpenAI.Responses.ResponseItemKind BingGroundingCallOutput { get { throw null; } }
            public static OpenAI.Responses.ResponseItemKind BrowserAutomationPreviewCall { get { throw null; } }
            public static OpenAI.Responses.ResponseItemKind BrowserAutomationPreviewCallOutput { get { throw null; } }
            public static OpenAI.Responses.ResponseItemKind FabricDataAgentPreviewCall { get { throw null; } }
            public static OpenAI.Responses.ResponseItemKind FabricDataAgentPreviewCallOutput { get { throw null; } }
            public static OpenAI.Responses.ResponseItemKind MemoryCommandPreviewCall { get { throw null; } }
            public static OpenAI.Responses.ResponseItemKind MemoryCommandPreviewCallOutput { get { throw null; } }
            public static OpenAI.Responses.ResponseItemKind MemorySearchCall { get { throw null; } }
            public static OpenAI.Responses.ResponseItemKind OAuthConsentRequest { get { throw null; } }
            public static OpenAI.Responses.ResponseItemKind OpenApiCall { get { throw null; } }
            public static OpenAI.Responses.ResponseItemKind OpenApiCallOutput { get { throw null; } }
            public static OpenAI.Responses.ResponseItemKind SharepointGroundingPreviewCall { get { throw null; } }
            public static OpenAI.Responses.ResponseItemKind SharepointGroundingPreviewCallOutput { get { throw null; } }
            public static OpenAI.Responses.ResponseItemKind StructuredOutputs { get { throw null; } }
            public static OpenAI.Responses.ResponseItemKind WorkflowAction { get { throw null; } }
            public static partial class <M>$85D7243A15CC11DE156F995836A4C406
            {
                public static void <Extension>$(OpenAI.Responses.ResponseItemKind ) { }
            }
        }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("OPENAI001")]
    public static partial class ResponseResultExtensions
    {
        public static Azure.AI.Extensions.OpenAI.AgentReference get_Agent(OpenAI.Responses.ResponseResult response) { throw null; }
        public static string get_AgentConversationId(OpenAI.Responses.ResponseResult response) { throw null; }
        public sealed partial class <G>$D7C08262BAEC712802F8752B389F8208
        {
            internal <G>$D7C08262BAEC712802F8752B389F8208() { }
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("SCME0001")]
            public Azure.AI.Extensions.OpenAI.AgentReference Agent { get { throw null; } }
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("SCME0001")]
            public string AgentConversationId { get { throw null; } }
            public static partial class <M>$9CB7C4485EAB7B97A3544F52CBDBA0F9
            {
                public static void <Extension>$(OpenAI.Responses.ResponseResult response) { }
            }
        }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("OPENAI001")]
    public static partial class ResponseToolKindExtensions
    {
        public static OpenAI.Responses.ResponseToolKind get_A2APreview() { throw null; }
        public static OpenAI.Responses.ResponseToolKind get_AzureAISearch() { throw null; }
        public static OpenAI.Responses.ResponseToolKind get_AzureFunction() { throw null; }
        public static OpenAI.Responses.ResponseToolKind get_BingCustomSearchPreview() { throw null; }
        public static OpenAI.Responses.ResponseToolKind get_BingGrounding() { throw null; }
        public static OpenAI.Responses.ResponseToolKind get_BrowserAutomationPreview() { throw null; }
        public static OpenAI.Responses.ResponseToolKind get_CaptureStructuredOutputs() { throw null; }
        public static OpenAI.Responses.ResponseToolKind get_Custom() { throw null; }
        public static OpenAI.Responses.ResponseToolKind get_FabricDataAgentPreview() { throw null; }
        public static OpenAI.Responses.ResponseToolKind get_FabricIQPreview() { throw null; }
        public static OpenAI.Responses.ResponseToolKind get_MemorySearchPreview() { throw null; }
        public static OpenAI.Responses.ResponseToolKind get_Namespace() { throw null; }
        public static OpenAI.Responses.ResponseToolKind get_OpenAPI() { throw null; }
        public static OpenAI.Responses.ResponseToolKind get_SharePointGroundingPreview() { throw null; }
        public static OpenAI.Responses.ResponseToolKind get_ToolboxSearchPreview() { throw null; }
        public static OpenAI.Responses.ResponseToolKind get_WorkIQPreview() { throw null; }
        public sealed partial class <G>$E0CE0E82775707DA8AF18B421221DEF9
        {
            internal <G>$E0CE0E82775707DA8AF18B421221DEF9() { }
            public static OpenAI.Responses.ResponseToolKind A2APreview { get { throw null; } }
            public static OpenAI.Responses.ResponseToolKind AzureAISearch { get { throw null; } }
            public static OpenAI.Responses.ResponseToolKind AzureFunction { get { throw null; } }
            public static OpenAI.Responses.ResponseToolKind BingCustomSearchPreview { get { throw null; } }
            public static OpenAI.Responses.ResponseToolKind BingGrounding { get { throw null; } }
            public static OpenAI.Responses.ResponseToolKind BrowserAutomationPreview { get { throw null; } }
            public static OpenAI.Responses.ResponseToolKind CaptureStructuredOutputs { get { throw null; } }
            public static OpenAI.Responses.ResponseToolKind Custom { get { throw null; } }
            public static OpenAI.Responses.ResponseToolKind FabricDataAgentPreview { get { throw null; } }
            public static OpenAI.Responses.ResponseToolKind FabricIQPreview { get { throw null; } }
            public static OpenAI.Responses.ResponseToolKind MemorySearchPreview { get { throw null; } }
            public static OpenAI.Responses.ResponseToolKind Namespace { get { throw null; } }
            public static OpenAI.Responses.ResponseToolKind OpenAPI { get { throw null; } }
            public static OpenAI.Responses.ResponseToolKind SharePointGroundingPreview { get { throw null; } }
            public static OpenAI.Responses.ResponseToolKind ToolboxSearchPreview { get { throw null; } }
            public static OpenAI.Responses.ResponseToolKind WorkIQPreview { get { throw null; } }
            public static partial class <M>$E0CE0E82775707DA8AF18B421221DEF9
            {
                public static void <Extension>$(OpenAI.Responses.ResponseToolKind ) { }
            }
        }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class SharepointGroundingToolCall : OpenAI.Responses.ResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.SharepointGroundingToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.SharepointGroundingToolCall>
    {
<<<<<<< HEAD
        public SharepointGroundingToolCall(string callId, string arguments, Azure.AI.Extensions.OpenAI.ToolCallStatus status) : base (default(OpenAI.Responses.ResponseItemKind)) { }
=======
        public ResponsesBingCustomSearchConfiguration(string projectConnectionId, string instanceName) { }
        public long? Count { get { throw null; } set { } }
        public string Freshness { get { throw null; } set { } }
        public string InstanceName { get { throw null; } set { } }
        public string Market { get { throw null; } set { } }
        public string ProjectConnectionId { get { throw null; } set { } }
        public string SetLang { get { throw null; } set { } }
        protected virtual Azure.AI.Extensions.OpenAI.ResponsesBingCustomSearchConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Extensions.OpenAI.ResponsesBingCustomSearchConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.ResponsesBingCustomSearchConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesBingCustomSearchConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesBingCustomSearchConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.ResponsesBingCustomSearchConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesBingCustomSearchConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesBingCustomSearchConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesBingCustomSearchConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class ResponsesBingCustomSearchPreviewTool : Azure.AI.Extensions.OpenAI.ResponsesTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesBingCustomSearchPreviewTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesBingCustomSearchPreviewTool>
    {
        public ResponsesBingCustomSearchPreviewTool(Azure.AI.Extensions.OpenAI.ResponsesBingCustomSearchToolParameters bingCustomSearchPreview) { }
        public Azure.AI.Extensions.OpenAI.ResponsesBingCustomSearchToolParameters BingCustomSearchPreview { get { throw null; } set { } }
        protected override Azure.AI.Extensions.OpenAI.ResponsesTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Extensions.OpenAI.ResponsesTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.ResponsesBingCustomSearchPreviewTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesBingCustomSearchPreviewTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesBingCustomSearchPreviewTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.ResponsesBingCustomSearchPreviewTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesBingCustomSearchPreviewTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesBingCustomSearchPreviewTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesBingCustomSearchPreviewTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class ResponsesBingCustomSearchToolParameters : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesBingCustomSearchToolParameters>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesBingCustomSearchToolParameters>
    {
        public ResponsesBingCustomSearchToolParameters(System.Collections.Generic.IEnumerable<Azure.AI.Extensions.OpenAI.ResponsesBingCustomSearchConfiguration> searchConfigurations) { }
        public System.Collections.Generic.IList<Azure.AI.Extensions.OpenAI.ResponsesBingCustomSearchConfiguration> SearchConfigurations { get { throw null; } }
        protected virtual Azure.AI.Extensions.OpenAI.ResponsesBingCustomSearchToolParameters JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Extensions.OpenAI.ResponsesBingCustomSearchToolParameters PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.ResponsesBingCustomSearchToolParameters System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesBingCustomSearchToolParameters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesBingCustomSearchToolParameters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.ResponsesBingCustomSearchToolParameters System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesBingCustomSearchToolParameters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesBingCustomSearchToolParameters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesBingCustomSearchToolParameters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResponsesBingGroundingSearchConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesBingGroundingSearchConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesBingGroundingSearchConfiguration>
    {
        public ResponsesBingGroundingSearchConfiguration(string projectConnectionId) { }
        public long? Count { get { throw null; } set { } }
        public string Freshness { get { throw null; } set { } }
        public string Language { get { throw null; } set { } }
        public string Market { get { throw null; } set { } }
        public string ProjectConnectionId { get { throw null; } set { } }
        protected virtual Azure.AI.Extensions.OpenAI.ResponsesBingGroundingSearchConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Extensions.OpenAI.ResponsesBingGroundingSearchConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.ResponsesBingGroundingSearchConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesBingGroundingSearchConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesBingGroundingSearchConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.ResponsesBingGroundingSearchConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesBingGroundingSearchConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesBingGroundingSearchConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesBingGroundingSearchConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResponsesBingGroundingSearchToolParameters : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesBingGroundingSearchToolParameters>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesBingGroundingSearchToolParameters>
    {
        public ResponsesBingGroundingSearchToolParameters(System.Collections.Generic.IEnumerable<Azure.AI.Extensions.OpenAI.ResponsesBingGroundingSearchConfiguration> searchConfigurations) { }
        public System.Collections.Generic.IList<Azure.AI.Extensions.OpenAI.ResponsesBingGroundingSearchConfiguration> SearchConfigurations { get { throw null; } }
        protected virtual Azure.AI.Extensions.OpenAI.ResponsesBingGroundingSearchToolParameters JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Extensions.OpenAI.ResponsesBingGroundingSearchToolParameters PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.ResponsesBingGroundingSearchToolParameters System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesBingGroundingSearchToolParameters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesBingGroundingSearchToolParameters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.ResponsesBingGroundingSearchToolParameters System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesBingGroundingSearchToolParameters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesBingGroundingSearchToolParameters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesBingGroundingSearchToolParameters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResponsesBingGroundingTool : Azure.AI.Extensions.OpenAI.ResponsesTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesBingGroundingTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesBingGroundingTool>
    {
        public ResponsesBingGroundingTool(Azure.AI.Extensions.OpenAI.ResponsesBingGroundingSearchToolParameters bingGrounding) { }
        public Azure.AI.Extensions.OpenAI.ResponsesBingGroundingSearchToolParameters BingGrounding { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.AI.Extensions.OpenAI.ToolConfig> ToolConfigs { get { throw null; } }
        protected override Azure.AI.Extensions.OpenAI.ResponsesTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Extensions.OpenAI.ResponsesTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.ResponsesBingGroundingTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesBingGroundingTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesBingGroundingTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.ResponsesBingGroundingTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesBingGroundingTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesBingGroundingTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesBingGroundingTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class ResponsesBrowserAutomationPreviewTool : Azure.AI.Extensions.OpenAI.ResponsesTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesBrowserAutomationPreviewTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesBrowserAutomationPreviewTool>
    {
        public ResponsesBrowserAutomationPreviewTool(Azure.AI.Extensions.OpenAI.ResponsesBrowserAutomationToolParameters browserAutomationPreview) { }
        public Azure.AI.Extensions.OpenAI.ResponsesBrowserAutomationToolParameters BrowserAutomationPreview { get { throw null; } set { } }
        protected override Azure.AI.Extensions.OpenAI.ResponsesTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Extensions.OpenAI.ResponsesTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.ResponsesBrowserAutomationPreviewTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesBrowserAutomationPreviewTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesBrowserAutomationPreviewTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.ResponsesBrowserAutomationPreviewTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesBrowserAutomationPreviewTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesBrowserAutomationPreviewTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesBrowserAutomationPreviewTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class ResponsesBrowserAutomationToolConnectionParameters : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesBrowserAutomationToolConnectionParameters>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesBrowserAutomationToolConnectionParameters>
    {
        public ResponsesBrowserAutomationToolConnectionParameters(string projectConnectionId) { }
        public string ProjectConnectionId { get { throw null; } set { } }
        protected virtual Azure.AI.Extensions.OpenAI.ResponsesBrowserAutomationToolConnectionParameters JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Extensions.OpenAI.ResponsesBrowserAutomationToolConnectionParameters PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.ResponsesBrowserAutomationToolConnectionParameters System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesBrowserAutomationToolConnectionParameters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesBrowserAutomationToolConnectionParameters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.ResponsesBrowserAutomationToolConnectionParameters System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesBrowserAutomationToolConnectionParameters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesBrowserAutomationToolConnectionParameters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesBrowserAutomationToolConnectionParameters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class ResponsesBrowserAutomationToolParameters : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesBrowserAutomationToolParameters>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesBrowserAutomationToolParameters>
    {
        public ResponsesBrowserAutomationToolParameters(Azure.AI.Extensions.OpenAI.ResponsesBrowserAutomationToolConnectionParameters connection) { }
        public Azure.AI.Extensions.OpenAI.ResponsesBrowserAutomationToolConnectionParameters Connection { get { throw null; } set { } }
        protected virtual Azure.AI.Extensions.OpenAI.ResponsesBrowserAutomationToolParameters JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Extensions.OpenAI.ResponsesBrowserAutomationToolParameters PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.ResponsesBrowserAutomationToolParameters System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesBrowserAutomationToolParameters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesBrowserAutomationToolParameters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.ResponsesBrowserAutomationToolParameters System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesBrowserAutomationToolParameters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesBrowserAutomationToolParameters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesBrowserAutomationToolParameters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResponsesCaptureStructuredOutputsTool : Azure.AI.Extensions.OpenAI.ResponsesTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesCaptureStructuredOutputsTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesCaptureStructuredOutputsTool>
    {
        public ResponsesCaptureStructuredOutputsTool(Azure.AI.Extensions.OpenAI.ResponsesStructuredOutputDefinition outputDefinition) { }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.AI.Extensions.OpenAI.ResponsesStructuredOutputDefinition OutputDefinition { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.AI.Extensions.OpenAI.ToolConfig> ToolConfigs { get { throw null; } }
        protected override Azure.AI.Extensions.OpenAI.ResponsesTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Extensions.OpenAI.ResponsesTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.ResponsesCaptureStructuredOutputsTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesCaptureStructuredOutputsTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesCaptureStructuredOutputsTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.ResponsesCaptureStructuredOutputsTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesCaptureStructuredOutputsTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesCaptureStructuredOutputsTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesCaptureStructuredOutputsTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResponsesComputerTool : Azure.AI.Extensions.OpenAI.ResponsesTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesComputerTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesComputerTool>
    {
        public ResponsesComputerTool() { }
        protected override Azure.AI.Extensions.OpenAI.ResponsesTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Extensions.OpenAI.ResponsesTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.ResponsesComputerTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesComputerTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesComputerTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.ResponsesComputerTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesComputerTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesComputerTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesComputerTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResponsesContainerAutoParam : Azure.AI.Extensions.OpenAI.ResponsesFunctionShellToolParamEnvironment, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesContainerAutoParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesContainerAutoParam>
    {
        public ResponsesContainerAutoParam() { }
        public System.Collections.Generic.IList<string> FileIds { get { throw null; } }
        public Azure.AI.Extensions.OpenAI.ResponsesContainerMemoryLimit? MemoryLimit { get { throw null; } set { } }
        public Azure.AI.Extensions.OpenAI.ResponsesContainerNetworkPolicyParam NetworkPolicy { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Extensions.OpenAI.ContainerSkill> Skills { get { throw null; } }
        protected override Azure.AI.Extensions.OpenAI.ResponsesFunctionShellToolParamEnvironment JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Extensions.OpenAI.ResponsesFunctionShellToolParamEnvironment PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.ResponsesContainerAutoParam System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesContainerAutoParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesContainerAutoParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.ResponsesContainerAutoParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesContainerAutoParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesContainerAutoParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesContainerAutoParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResponsesContainerMemoryLimit : System.IEquatable<Azure.AI.Extensions.OpenAI.ResponsesContainerMemoryLimit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResponsesContainerMemoryLimit(string value) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesContainerMemoryLimit _16g { get { throw null; } }
        public static Azure.AI.Extensions.OpenAI.ResponsesContainerMemoryLimit _1g { get { throw null; } }
        public static Azure.AI.Extensions.OpenAI.ResponsesContainerMemoryLimit _4g { get { throw null; } }
        public static Azure.AI.Extensions.OpenAI.ResponsesContainerMemoryLimit _64g { get { throw null; } }
        public bool Equals(Azure.AI.Extensions.OpenAI.ResponsesContainerMemoryLimit other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Extensions.OpenAI.ResponsesContainerMemoryLimit left, Azure.AI.Extensions.OpenAI.ResponsesContainerMemoryLimit right) { throw null; }
        public static implicit operator Azure.AI.Extensions.OpenAI.ResponsesContainerMemoryLimit (string value) { throw null; }
        public static implicit operator Azure.AI.Extensions.OpenAI.ResponsesContainerMemoryLimit? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Extensions.OpenAI.ResponsesContainerMemoryLimit left, Azure.AI.Extensions.OpenAI.ResponsesContainerMemoryLimit right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResponsesContainerNetworkPolicyAllowlistParam : Azure.AI.Extensions.OpenAI.ResponsesContainerNetworkPolicyParam, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesContainerNetworkPolicyAllowlistParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesContainerNetworkPolicyAllowlistParam>
    {
        public ResponsesContainerNetworkPolicyAllowlistParam(System.Collections.Generic.IEnumerable<string> allowedDomains) { }
        public System.Collections.Generic.IList<string> AllowedDomains { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Extensions.OpenAI.ResponsesContainerNetworkPolicyDomainSecretParam> DomainSecrets { get { throw null; } }
        protected override Azure.AI.Extensions.OpenAI.ResponsesContainerNetworkPolicyParam JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Extensions.OpenAI.ResponsesContainerNetworkPolicyParam PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.ResponsesContainerNetworkPolicyAllowlistParam System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesContainerNetworkPolicyAllowlistParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesContainerNetworkPolicyAllowlistParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.ResponsesContainerNetworkPolicyAllowlistParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesContainerNetworkPolicyAllowlistParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesContainerNetworkPolicyAllowlistParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesContainerNetworkPolicyAllowlistParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResponsesContainerNetworkPolicyDisabledParam : Azure.AI.Extensions.OpenAI.ResponsesContainerNetworkPolicyParam, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesContainerNetworkPolicyDisabledParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesContainerNetworkPolicyDisabledParam>
    {
        public ResponsesContainerNetworkPolicyDisabledParam() { }
        protected override Azure.AI.Extensions.OpenAI.ResponsesContainerNetworkPolicyParam JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Extensions.OpenAI.ResponsesContainerNetworkPolicyParam PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.ResponsesContainerNetworkPolicyDisabledParam System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesContainerNetworkPolicyDisabledParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesContainerNetworkPolicyDisabledParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.ResponsesContainerNetworkPolicyDisabledParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesContainerNetworkPolicyDisabledParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesContainerNetworkPolicyDisabledParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesContainerNetworkPolicyDisabledParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResponsesContainerNetworkPolicyDomainSecretParam : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesContainerNetworkPolicyDomainSecretParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesContainerNetworkPolicyDomainSecretParam>
    {
        public ResponsesContainerNetworkPolicyDomainSecretParam(string domain, string name, string value) { }
        public string Domain { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual Azure.AI.Extensions.OpenAI.ResponsesContainerNetworkPolicyDomainSecretParam JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Extensions.OpenAI.ResponsesContainerNetworkPolicyDomainSecretParam PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.ResponsesContainerNetworkPolicyDomainSecretParam System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesContainerNetworkPolicyDomainSecretParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesContainerNetworkPolicyDomainSecretParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.ResponsesContainerNetworkPolicyDomainSecretParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesContainerNetworkPolicyDomainSecretParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesContainerNetworkPolicyDomainSecretParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesContainerNetworkPolicyDomainSecretParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ResponsesContainerNetworkPolicyParam : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesContainerNetworkPolicyParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesContainerNetworkPolicyParam>
    {
        internal ResponsesContainerNetworkPolicyParam() { }
        protected virtual Azure.AI.Extensions.OpenAI.ResponsesContainerNetworkPolicyParam JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Extensions.OpenAI.ResponsesContainerNetworkPolicyParam PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.ResponsesContainerNetworkPolicyParam System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesContainerNetworkPolicyParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesContainerNetworkPolicyParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.ResponsesContainerNetworkPolicyParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesContainerNetworkPolicyParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesContainerNetworkPolicyParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesContainerNetworkPolicyParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResponsesCustomTextFormatParam : Azure.AI.Extensions.OpenAI.ResponsesCustomToolParamFormat, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesCustomTextFormatParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesCustomTextFormatParam>
    {
        public ResponsesCustomTextFormatParam() { }
        protected override Azure.AI.Extensions.OpenAI.ResponsesCustomToolParamFormat JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Extensions.OpenAI.ResponsesCustomToolParamFormat PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.ResponsesCustomTextFormatParam System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesCustomTextFormatParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesCustomTextFormatParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.ResponsesCustomTextFormatParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesCustomTextFormatParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesCustomTextFormatParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesCustomTextFormatParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResponsesCustomToolParam : Azure.AI.Extensions.OpenAI.ResponsesTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesCustomToolParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesCustomToolParam>
    {
        public ResponsesCustomToolParam(string name) { }
        public string Description { get { throw null; } set { } }
        public Azure.AI.Extensions.OpenAI.ResponsesCustomToolParamFormat Format { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public bool? ShouldDeferLoading { get { throw null; } set { } }
        protected override Azure.AI.Extensions.OpenAI.ResponsesTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Extensions.OpenAI.ResponsesTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.ResponsesCustomToolParam System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesCustomToolParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesCustomToolParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.ResponsesCustomToolParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesCustomToolParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesCustomToolParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesCustomToolParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ResponsesCustomToolParamFormat : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesCustomToolParamFormat>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesCustomToolParamFormat>
    {
        internal ResponsesCustomToolParamFormat() { }
        protected virtual Azure.AI.Extensions.OpenAI.ResponsesCustomToolParamFormat JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Extensions.OpenAI.ResponsesCustomToolParamFormat PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.ResponsesCustomToolParamFormat System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesCustomToolParamFormat>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesCustomToolParamFormat>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.ResponsesCustomToolParamFormat System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesCustomToolParamFormat>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesCustomToolParamFormat>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesCustomToolParamFormat>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResponsesEmptyModelParam : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesEmptyModelParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesEmptyModelParam>
    {
        public ResponsesEmptyModelParam() { }
        protected virtual Azure.AI.Extensions.OpenAI.ResponsesEmptyModelParam JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Extensions.OpenAI.ResponsesEmptyModelParam PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.ResponsesEmptyModelParam System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesEmptyModelParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesEmptyModelParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.ResponsesEmptyModelParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesEmptyModelParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesEmptyModelParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesEmptyModelParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class ResponsesFabricDataAgentToolOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesFabricDataAgentToolOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesFabricDataAgentToolOptions>
    {
        public ResponsesFabricDataAgentToolOptions() { }
        public System.Collections.Generic.IList<Azure.AI.Extensions.OpenAI.ResponsesToolProjectConnection> ProjectConnections { get { throw null; } }
        protected virtual Azure.AI.Extensions.OpenAI.ResponsesFabricDataAgentToolOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Extensions.OpenAI.ResponsesFabricDataAgentToolOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.ResponsesFabricDataAgentToolOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesFabricDataAgentToolOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesFabricDataAgentToolOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.ResponsesFabricDataAgentToolOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesFabricDataAgentToolOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesFabricDataAgentToolOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesFabricDataAgentToolOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class ResponsesFabricIQPreviewTool : Azure.AI.Extensions.OpenAI.ResponsesTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesFabricIQPreviewTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesFabricIQPreviewTool>
    {
        public ResponsesFabricIQPreviewTool(string projectConnectionId) { }
        public string ProjectConnectionId { get { throw null; } set { } }
        public System.BinaryData RequireApproval { get { throw null; } set { } }
        public string ServerLabel { get { throw null; } set { } }
        public System.Uri ServerUri { get { throw null; } set { } }
        protected override Azure.AI.Extensions.OpenAI.ResponsesTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Extensions.OpenAI.ResponsesTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.ResponsesFabricIQPreviewTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesFabricIQPreviewTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesFabricIQPreviewTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.ResponsesFabricIQPreviewTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesFabricIQPreviewTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesFabricIQPreviewTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesFabricIQPreviewTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResponsesFunctionCallOutputStatus : System.IEquatable<Azure.AI.Extensions.OpenAI.ResponsesFunctionCallOutputStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResponsesFunctionCallOutputStatus(string value) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesFunctionCallOutputStatus Completed { get { throw null; } }
        public static Azure.AI.Extensions.OpenAI.ResponsesFunctionCallOutputStatus Incomplete { get { throw null; } }
        public static Azure.AI.Extensions.OpenAI.ResponsesFunctionCallOutputStatus InProgress { get { throw null; } }
        public bool Equals(Azure.AI.Extensions.OpenAI.ResponsesFunctionCallOutputStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Extensions.OpenAI.ResponsesFunctionCallOutputStatus left, Azure.AI.Extensions.OpenAI.ResponsesFunctionCallOutputStatus right) { throw null; }
        public static implicit operator Azure.AI.Extensions.OpenAI.ResponsesFunctionCallOutputStatus (string value) { throw null; }
        public static implicit operator Azure.AI.Extensions.OpenAI.ResponsesFunctionCallOutputStatus? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Extensions.OpenAI.ResponsesFunctionCallOutputStatus left, Azure.AI.Extensions.OpenAI.ResponsesFunctionCallOutputStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResponsesFunctionCallStatus : System.IEquatable<Azure.AI.Extensions.OpenAI.ResponsesFunctionCallStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResponsesFunctionCallStatus(string value) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesFunctionCallStatus Completed { get { throw null; } }
        public static Azure.AI.Extensions.OpenAI.ResponsesFunctionCallStatus Incomplete { get { throw null; } }
        public static Azure.AI.Extensions.OpenAI.ResponsesFunctionCallStatus InProgress { get { throw null; } }
        public bool Equals(Azure.AI.Extensions.OpenAI.ResponsesFunctionCallStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Extensions.OpenAI.ResponsesFunctionCallStatus left, Azure.AI.Extensions.OpenAI.ResponsesFunctionCallStatus right) { throw null; }
        public static implicit operator Azure.AI.Extensions.OpenAI.ResponsesFunctionCallStatus (string value) { throw null; }
        public static implicit operator Azure.AI.Extensions.OpenAI.ResponsesFunctionCallStatus? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Extensions.OpenAI.ResponsesFunctionCallStatus left, Azure.AI.Extensions.OpenAI.ResponsesFunctionCallStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResponsesFunctionShellToolParam : Azure.AI.Extensions.OpenAI.ResponsesTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesFunctionShellToolParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesFunctionShellToolParam>
    {
        public ResponsesFunctionShellToolParam() { }
        public string Description { get { throw null; } set { } }
        public Azure.AI.Extensions.OpenAI.ResponsesFunctionShellToolParamEnvironment Environment { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.AI.Extensions.OpenAI.ToolConfig> ToolConfigs { get { throw null; } }
        protected override Azure.AI.Extensions.OpenAI.ResponsesTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Extensions.OpenAI.ResponsesTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.ResponsesFunctionShellToolParam System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesFunctionShellToolParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesFunctionShellToolParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.ResponsesFunctionShellToolParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesFunctionShellToolParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesFunctionShellToolParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesFunctionShellToolParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ResponsesFunctionShellToolParamEnvironment : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesFunctionShellToolParamEnvironment>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesFunctionShellToolParamEnvironment>
    {
        internal ResponsesFunctionShellToolParamEnvironment() { }
        protected virtual Azure.AI.Extensions.OpenAI.ResponsesFunctionShellToolParamEnvironment JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Extensions.OpenAI.ResponsesFunctionShellToolParamEnvironment PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.ResponsesFunctionShellToolParamEnvironment System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesFunctionShellToolParamEnvironment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesFunctionShellToolParamEnvironment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.ResponsesFunctionShellToolParamEnvironment System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesFunctionShellToolParamEnvironment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesFunctionShellToolParamEnvironment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesFunctionShellToolParamEnvironment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResponsesFunctionShellToolParamEnvironmentContainerReferenceParam : Azure.AI.Extensions.OpenAI.ResponsesFunctionShellToolParamEnvironment, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesFunctionShellToolParamEnvironmentContainerReferenceParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesFunctionShellToolParamEnvironmentContainerReferenceParam>
    {
        public ResponsesFunctionShellToolParamEnvironmentContainerReferenceParam(string containerId) { }
        public string ContainerId { get { throw null; } set { } }
        protected override Azure.AI.Extensions.OpenAI.ResponsesFunctionShellToolParamEnvironment JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Extensions.OpenAI.ResponsesFunctionShellToolParamEnvironment PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.ResponsesFunctionShellToolParamEnvironmentContainerReferenceParam System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesFunctionShellToolParamEnvironmentContainerReferenceParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesFunctionShellToolParamEnvironmentContainerReferenceParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.ResponsesFunctionShellToolParamEnvironmentContainerReferenceParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesFunctionShellToolParamEnvironmentContainerReferenceParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesFunctionShellToolParamEnvironmentContainerReferenceParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesFunctionShellToolParamEnvironmentContainerReferenceParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResponsesFunctionShellToolParamEnvironmentLocalEnvironmentParam : Azure.AI.Extensions.OpenAI.ResponsesFunctionShellToolParamEnvironment, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesFunctionShellToolParamEnvironmentLocalEnvironmentParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesFunctionShellToolParamEnvironmentLocalEnvironmentParam>
    {
        public ResponsesFunctionShellToolParamEnvironmentLocalEnvironmentParam() { }
        public System.Collections.Generic.IList<Azure.AI.Extensions.OpenAI.LocalSkillParam> Skills { get { throw null; } }
        protected override Azure.AI.Extensions.OpenAI.ResponsesFunctionShellToolParamEnvironment JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Extensions.OpenAI.ResponsesFunctionShellToolParamEnvironment PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.ResponsesFunctionShellToolParamEnvironmentLocalEnvironmentParam System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesFunctionShellToolParamEnvironmentLocalEnvironmentParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesFunctionShellToolParamEnvironmentLocalEnvironmentParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.ResponsesFunctionShellToolParamEnvironmentLocalEnvironmentParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesFunctionShellToolParamEnvironmentLocalEnvironmentParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesFunctionShellToolParamEnvironmentLocalEnvironmentParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesFunctionShellToolParamEnvironmentLocalEnvironmentParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResponsesFunctionToolParam : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesFunctionToolParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesFunctionToolParam>
    {
        public ResponsesFunctionToolParam(string name) { }
        public string Description { get { throw null; } set { } }
        public bool? IsStrict { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.AI.Extensions.OpenAI.ResponsesEmptyModelParam Parameters { get { throw null; } set { } }
        public bool? ShouldDeferLoading { get { throw null; } set { } }
        public string Type { get { throw null; } }
        protected virtual Azure.AI.Extensions.OpenAI.ResponsesFunctionToolParam JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Extensions.OpenAI.ResponsesFunctionToolParam PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.ResponsesFunctionToolParam System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesFunctionToolParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesFunctionToolParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.ResponsesFunctionToolParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesFunctionToolParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesFunctionToolParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesFunctionToolParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResponsesGrammarSyntax : System.IEquatable<Azure.AI.Extensions.OpenAI.ResponsesGrammarSyntax>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResponsesGrammarSyntax(string value) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesGrammarSyntax Lark { get { throw null; } }
        public static Azure.AI.Extensions.OpenAI.ResponsesGrammarSyntax Regex { get { throw null; } }
        public bool Equals(Azure.AI.Extensions.OpenAI.ResponsesGrammarSyntax other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Extensions.OpenAI.ResponsesGrammarSyntax left, Azure.AI.Extensions.OpenAI.ResponsesGrammarSyntax right) { throw null; }
        public static implicit operator Azure.AI.Extensions.OpenAI.ResponsesGrammarSyntax (string value) { throw null; }
        public static implicit operator Azure.AI.Extensions.OpenAI.ResponsesGrammarSyntax? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Extensions.OpenAI.ResponsesGrammarSyntax left, Azure.AI.Extensions.OpenAI.ResponsesGrammarSyntax right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResponsesInlineSkillParam : Azure.AI.Extensions.OpenAI.ContainerSkill, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesInlineSkillParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesInlineSkillParam>
    {
        public ResponsesInlineSkillParam(string name, string description, Azure.AI.Extensions.OpenAI.ResponsesInlineSkillSourceParam source) { }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.AI.Extensions.OpenAI.ResponsesInlineSkillSourceParam Source { get { throw null; } set { } }
        protected override Azure.AI.Extensions.OpenAI.ContainerSkill JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Extensions.OpenAI.ContainerSkill PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.ResponsesInlineSkillParam System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesInlineSkillParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesInlineSkillParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.ResponsesInlineSkillParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesInlineSkillParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesInlineSkillParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesInlineSkillParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResponsesInlineSkillSourceParam : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesInlineSkillSourceParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesInlineSkillSourceParam>
    {
        public ResponsesInlineSkillSourceParam(string data) { }
        public string Data { get { throw null; } set { } }
        public string MediaType { get { throw null; } }
        public string Type { get { throw null; } }
        protected virtual Azure.AI.Extensions.OpenAI.ResponsesInlineSkillSourceParam JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Extensions.OpenAI.ResponsesInlineSkillSourceParam PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.ResponsesInlineSkillSourceParam System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesInlineSkillSourceParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesInlineSkillSourceParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.ResponsesInlineSkillSourceParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesInlineSkillSourceParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesInlineSkillSourceParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesInlineSkillSourceParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResponsesLocalShellToolParam : Azure.AI.Extensions.OpenAI.ResponsesTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesLocalShellToolParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesLocalShellToolParam>
    {
        public ResponsesLocalShellToolParam() { }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.AI.Extensions.OpenAI.ToolConfig> ToolConfigs { get { throw null; } }
        protected override Azure.AI.Extensions.OpenAI.ResponsesTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Extensions.OpenAI.ResponsesTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.ResponsesLocalShellToolParam System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesLocalShellToolParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesLocalShellToolParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.ResponsesLocalShellToolParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesLocalShellToolParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesLocalShellToolParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesLocalShellToolParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResponsesMCPToolFilter : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesMCPToolFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesMCPToolFilter>
    {
        public ResponsesMCPToolFilter() { }
        public bool? IsReadOnly { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ToolNames { get { throw null; } }
        protected virtual Azure.AI.Extensions.OpenAI.ResponsesMCPToolFilter JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Extensions.OpenAI.ResponsesMCPToolFilter PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.ResponsesMCPToolFilter System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesMCPToolFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesMCPToolFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.ResponsesMCPToolFilter System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesMCPToolFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesMCPToolFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesMCPToolFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResponsesMCPToolRequireApproval : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesMCPToolRequireApproval>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesMCPToolRequireApproval>
    {
        public ResponsesMCPToolRequireApproval() { }
        public Azure.AI.Extensions.OpenAI.ResponsesMCPToolFilter Always { get { throw null; } set { } }
        public Azure.AI.Extensions.OpenAI.ResponsesMCPToolFilter Never { get { throw null; } set { } }
        protected virtual Azure.AI.Extensions.OpenAI.ResponsesMCPToolRequireApproval JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Extensions.OpenAI.ResponsesMCPToolRequireApproval PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.ResponsesMCPToolRequireApproval System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesMCPToolRequireApproval>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesMCPToolRequireApproval>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.ResponsesMCPToolRequireApproval System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesMCPToolRequireApproval>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesMCPToolRequireApproval>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesMCPToolRequireApproval>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class ResponsesMemorySearchOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesMemorySearchOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesMemorySearchOptions>
    {
        public ResponsesMemorySearchOptions() { }
        public int? MaxMemories { get { throw null; } set { } }
        protected virtual Azure.AI.Extensions.OpenAI.ResponsesMemorySearchOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Extensions.OpenAI.ResponsesMemorySearchOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.ResponsesMemorySearchOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesMemorySearchOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesMemorySearchOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.ResponsesMemorySearchOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesMemorySearchOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesMemorySearchOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesMemorySearchOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class ResponsesMemorySearchPreviewTool : Azure.AI.Extensions.OpenAI.ResponsesTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesMemorySearchPreviewTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesMemorySearchPreviewTool>
    {
        public ResponsesMemorySearchPreviewTool(string memoryStoreName, string scope) { }
        public string MemoryStoreName { get { throw null; } set { } }
        public string Scope { get { throw null; } set { } }
        public Azure.AI.Extensions.OpenAI.ResponsesMemorySearchOptions SearchOptions { get { throw null; } set { } }
        public int? UpdateDelayInSeconds { get { throw null; } set { } }
        protected override Azure.AI.Extensions.OpenAI.ResponsesTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Extensions.OpenAI.ResponsesTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.ResponsesMemorySearchPreviewTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesMemorySearchPreviewTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesMemorySearchPreviewTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.ResponsesMemorySearchPreviewTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesMemorySearchPreviewTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesMemorySearchPreviewTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesMemorySearchPreviewTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class ResponsesMicrosoftFabricPreviewTool : Azure.AI.Extensions.OpenAI.ResponsesTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesMicrosoftFabricPreviewTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesMicrosoftFabricPreviewTool>
    {
        public ResponsesMicrosoftFabricPreviewTool(Azure.AI.Extensions.OpenAI.ResponsesFabricDataAgentToolOptions fabricDataagentPreview) { }
        public Azure.AI.Extensions.OpenAI.ResponsesFabricDataAgentToolOptions FabricDataagentPreview { get { throw null; } set { } }
        protected override Azure.AI.Extensions.OpenAI.ResponsesTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Extensions.OpenAI.ResponsesTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.ResponsesMicrosoftFabricPreviewTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesMicrosoftFabricPreviewTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesMicrosoftFabricPreviewTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.ResponsesMicrosoftFabricPreviewTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesMicrosoftFabricPreviewTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesMicrosoftFabricPreviewTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesMicrosoftFabricPreviewTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResponsesNamespaceToolParam : Azure.AI.Extensions.OpenAI.ResponsesTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesNamespaceToolParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesNamespaceToolParam>
    {
        public ResponsesNamespaceToolParam(string name, string description, System.Collections.Generic.IEnumerable<System.BinaryData> tools) { }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.BinaryData> Tools { get { throw null; } }
        protected override Azure.AI.Extensions.OpenAI.ResponsesTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Extensions.OpenAI.ResponsesTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.ResponsesNamespaceToolParam System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesNamespaceToolParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesNamespaceToolParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.ResponsesNamespaceToolParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesNamespaceToolParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesNamespaceToolParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesNamespaceToolParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResponsesOpenApiAnonymousAuthDetails : Azure.AI.Extensions.OpenAI.ResponsesOpenApiAuthDetails, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesOpenApiAnonymousAuthDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesOpenApiAnonymousAuthDetails>
    {
        public ResponsesOpenApiAnonymousAuthDetails() { }
        protected override Azure.AI.Extensions.OpenAI.ResponsesOpenApiAuthDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Extensions.OpenAI.ResponsesOpenApiAuthDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.ResponsesOpenApiAnonymousAuthDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesOpenApiAnonymousAuthDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesOpenApiAnonymousAuthDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.ResponsesOpenApiAnonymousAuthDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesOpenApiAnonymousAuthDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesOpenApiAnonymousAuthDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesOpenApiAnonymousAuthDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ResponsesOpenApiAuthDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesOpenApiAuthDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesOpenApiAuthDetails>
    {
        internal ResponsesOpenApiAuthDetails() { }
        protected virtual Azure.AI.Extensions.OpenAI.ResponsesOpenApiAuthDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Extensions.OpenAI.ResponsesOpenApiAuthDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.ResponsesOpenApiAuthDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesOpenApiAuthDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesOpenApiAuthDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.ResponsesOpenApiAuthDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesOpenApiAuthDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesOpenApiAuthDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesOpenApiAuthDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResponsesOpenApiFunctionDefinition : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesOpenApiFunctionDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesOpenApiFunctionDefinition>
    {
        public ResponsesOpenApiFunctionDefinition(string name, System.Collections.Generic.IDictionary<string, System.BinaryData> specification, Azure.AI.Extensions.OpenAI.ResponsesOpenApiAuthDetails auth) { }
        public Azure.AI.Extensions.OpenAI.ResponsesOpenApiAuthDetails Auth { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> DefaultParams { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Extensions.OpenAI.ResponsesOpenApiFunctionDefinitionFunction> Functions { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Specification { get { throw null; } }
        protected virtual Azure.AI.Extensions.OpenAI.ResponsesOpenApiFunctionDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Extensions.OpenAI.ResponsesOpenApiFunctionDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.ResponsesOpenApiFunctionDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesOpenApiFunctionDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesOpenApiFunctionDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.ResponsesOpenApiFunctionDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesOpenApiFunctionDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesOpenApiFunctionDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesOpenApiFunctionDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResponsesOpenApiFunctionDefinitionFunction : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesOpenApiFunctionDefinitionFunction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesOpenApiFunctionDefinitionFunction>
    {
        internal ResponsesOpenApiFunctionDefinitionFunction() { }
        public string Description { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Parameters { get { throw null; } }
        protected virtual Azure.AI.Extensions.OpenAI.ResponsesOpenApiFunctionDefinitionFunction JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Extensions.OpenAI.ResponsesOpenApiFunctionDefinitionFunction PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.ResponsesOpenApiFunctionDefinitionFunction System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesOpenApiFunctionDefinitionFunction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesOpenApiFunctionDefinitionFunction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.ResponsesOpenApiFunctionDefinitionFunction System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesOpenApiFunctionDefinitionFunction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesOpenApiFunctionDefinitionFunction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesOpenApiFunctionDefinitionFunction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResponsesOpenApiManagedAuthDetails : Azure.AI.Extensions.OpenAI.ResponsesOpenApiAuthDetails, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesOpenApiManagedAuthDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesOpenApiManagedAuthDetails>
    {
        public ResponsesOpenApiManagedAuthDetails(Azure.AI.Extensions.OpenAI.ResponsesOpenApiManagedSecurityScheme securityScheme) { }
        public Azure.AI.Extensions.OpenAI.ResponsesOpenApiManagedSecurityScheme SecurityScheme { get { throw null; } set { } }
        protected override Azure.AI.Extensions.OpenAI.ResponsesOpenApiAuthDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Extensions.OpenAI.ResponsesOpenApiAuthDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.ResponsesOpenApiManagedAuthDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesOpenApiManagedAuthDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesOpenApiManagedAuthDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.ResponsesOpenApiManagedAuthDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesOpenApiManagedAuthDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesOpenApiManagedAuthDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesOpenApiManagedAuthDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResponsesOpenApiManagedSecurityScheme : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesOpenApiManagedSecurityScheme>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesOpenApiManagedSecurityScheme>
    {
        public ResponsesOpenApiManagedSecurityScheme(string audience) { }
        public string Audience { get { throw null; } set { } }
        protected virtual Azure.AI.Extensions.OpenAI.ResponsesOpenApiManagedSecurityScheme JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Extensions.OpenAI.ResponsesOpenApiManagedSecurityScheme PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.ResponsesOpenApiManagedSecurityScheme System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesOpenApiManagedSecurityScheme>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesOpenApiManagedSecurityScheme>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.ResponsesOpenApiManagedSecurityScheme System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesOpenApiManagedSecurityScheme>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesOpenApiManagedSecurityScheme>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesOpenApiManagedSecurityScheme>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResponsesOpenApiProjectConnectionAuthDetails : Azure.AI.Extensions.OpenAI.ResponsesOpenApiAuthDetails, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesOpenApiProjectConnectionAuthDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesOpenApiProjectConnectionAuthDetails>
    {
        public ResponsesOpenApiProjectConnectionAuthDetails(Azure.AI.Extensions.OpenAI.ResponsesOpenApiProjectConnectionSecurityScheme securityScheme) { }
        public Azure.AI.Extensions.OpenAI.ResponsesOpenApiProjectConnectionSecurityScheme SecurityScheme { get { throw null; } set { } }
        protected override Azure.AI.Extensions.OpenAI.ResponsesOpenApiAuthDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Extensions.OpenAI.ResponsesOpenApiAuthDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.ResponsesOpenApiProjectConnectionAuthDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesOpenApiProjectConnectionAuthDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesOpenApiProjectConnectionAuthDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.ResponsesOpenApiProjectConnectionAuthDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesOpenApiProjectConnectionAuthDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesOpenApiProjectConnectionAuthDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesOpenApiProjectConnectionAuthDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResponsesOpenApiProjectConnectionSecurityScheme : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesOpenApiProjectConnectionSecurityScheme>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesOpenApiProjectConnectionSecurityScheme>
    {
        public ResponsesOpenApiProjectConnectionSecurityScheme(string projectConnectionId) { }
        public string ProjectConnectionId { get { throw null; } set { } }
        protected virtual Azure.AI.Extensions.OpenAI.ResponsesOpenApiProjectConnectionSecurityScheme JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Extensions.OpenAI.ResponsesOpenApiProjectConnectionSecurityScheme PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.ResponsesOpenApiProjectConnectionSecurityScheme System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesOpenApiProjectConnectionSecurityScheme>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesOpenApiProjectConnectionSecurityScheme>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.ResponsesOpenApiProjectConnectionSecurityScheme System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesOpenApiProjectConnectionSecurityScheme>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesOpenApiProjectConnectionSecurityScheme>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesOpenApiProjectConnectionSecurityScheme>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResponsesOpenApiTool : Azure.AI.Extensions.OpenAI.ResponsesTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesOpenApiTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesOpenApiTool>
    {
        public ResponsesOpenApiTool(Azure.AI.Extensions.OpenAI.ResponsesOpenApiFunctionDefinition openApi) { }
        public Azure.AI.Extensions.OpenAI.ResponsesOpenApiFunctionDefinition OpenApi { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.AI.Extensions.OpenAI.ToolConfig> ToolConfigs { get { throw null; } }
        protected override Azure.AI.Extensions.OpenAI.ResponsesTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Extensions.OpenAI.ResponsesTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.ResponsesOpenApiTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesOpenApiTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesOpenApiTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.ResponsesOpenApiTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesOpenApiTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesOpenApiTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesOpenApiTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class ResponsesSharepointGroundingToolParameters : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesSharepointGroundingToolParameters>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesSharepointGroundingToolParameters>
    {
        public ResponsesSharepointGroundingToolParameters() { }
        public System.Collections.Generic.IList<Azure.AI.Extensions.OpenAI.ResponsesToolProjectConnection> ProjectConnections { get { throw null; } }
        protected virtual Azure.AI.Extensions.OpenAI.ResponsesSharepointGroundingToolParameters JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Extensions.OpenAI.ResponsesSharepointGroundingToolParameters PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.ResponsesSharepointGroundingToolParameters System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesSharepointGroundingToolParameters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesSharepointGroundingToolParameters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.ResponsesSharepointGroundingToolParameters System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesSharepointGroundingToolParameters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesSharepointGroundingToolParameters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesSharepointGroundingToolParameters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class ResponsesSharepointPreviewTool : Azure.AI.Extensions.OpenAI.ResponsesTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesSharepointPreviewTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesSharepointPreviewTool>
    {
        public ResponsesSharepointPreviewTool(Azure.AI.Extensions.OpenAI.ResponsesSharepointGroundingToolParameters sharepointGroundingPreview) { }
        public Azure.AI.Extensions.OpenAI.ResponsesSharepointGroundingToolParameters SharepointGroundingPreview { get { throw null; } set { } }
        protected override Azure.AI.Extensions.OpenAI.ResponsesTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Extensions.OpenAI.ResponsesTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.ResponsesSharepointPreviewTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesSharepointPreviewTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesSharepointPreviewTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.ResponsesSharepointPreviewTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesSharepointPreviewTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesSharepointPreviewTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesSharepointPreviewTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResponsesSkillReferenceParam : Azure.AI.Extensions.OpenAI.ContainerSkill, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesSkillReferenceParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesSkillReferenceParam>
    {
        public ResponsesSkillReferenceParam(string skillId) { }
        public string SkillId { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        protected override Azure.AI.Extensions.OpenAI.ContainerSkill JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Extensions.OpenAI.ContainerSkill PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.ResponsesSkillReferenceParam System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesSkillReferenceParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesSkillReferenceParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.ResponsesSkillReferenceParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesSkillReferenceParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesSkillReferenceParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesSkillReferenceParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResponsesStructuredOutputDefinition : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesStructuredOutputDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesStructuredOutputDefinition>
    {
        public ResponsesStructuredOutputDefinition(string name, string description, System.Collections.Generic.IDictionary<string, System.BinaryData> schema, bool? isStrict) { }
        public string Description { get { throw null; } set { } }
        public bool? IsStrict { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Schema { get { throw null; } }
        protected virtual Azure.AI.Extensions.OpenAI.ResponsesStructuredOutputDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Extensions.OpenAI.ResponsesStructuredOutputDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.ResponsesStructuredOutputDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesStructuredOutputDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesStructuredOutputDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.ResponsesStructuredOutputDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesStructuredOutputDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesStructuredOutputDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesStructuredOutputDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ResponsesTool : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesTool>
    {
        internal ResponsesTool() { }
        protected virtual Azure.AI.Extensions.OpenAI.ResponsesTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Extensions.OpenAI.ResponsesTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.ResponsesTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.ResponsesTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResponsesToolProjectConnection : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesToolProjectConnection>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesToolProjectConnection>
    {
        public ResponsesToolProjectConnection(string projectConnectionId) { }
        public string ProjectConnectionId { get { throw null; } set { } }
        protected virtual Azure.AI.Extensions.OpenAI.ResponsesToolProjectConnection JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Extensions.OpenAI.ResponsesToolProjectConnection PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.ResponsesToolProjectConnection System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesToolProjectConnection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesToolProjectConnection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.ResponsesToolProjectConnection System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesToolProjectConnection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesToolProjectConnection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesToolProjectConnection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResponsesToolSearchExecutionType : System.IEquatable<Azure.AI.Extensions.OpenAI.ResponsesToolSearchExecutionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResponsesToolSearchExecutionType(string value) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesToolSearchExecutionType Client { get { throw null; } }
        public static Azure.AI.Extensions.OpenAI.ResponsesToolSearchExecutionType Server { get { throw null; } }
        public bool Equals(Azure.AI.Extensions.OpenAI.ResponsesToolSearchExecutionType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Extensions.OpenAI.ResponsesToolSearchExecutionType left, Azure.AI.Extensions.OpenAI.ResponsesToolSearchExecutionType right) { throw null; }
        public static implicit operator Azure.AI.Extensions.OpenAI.ResponsesToolSearchExecutionType (string value) { throw null; }
        public static implicit operator Azure.AI.Extensions.OpenAI.ResponsesToolSearchExecutionType? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Extensions.OpenAI.ResponsesToolSearchExecutionType left, Azure.AI.Extensions.OpenAI.ResponsesToolSearchExecutionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResponsesToolSearchToolParam : Azure.AI.Extensions.OpenAI.ResponsesTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesToolSearchToolParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesToolSearchToolParam>
    {
        public ResponsesToolSearchToolParam() { }
        public string Description { get { throw null; } set { } }
        public Azure.AI.Extensions.OpenAI.ResponsesToolSearchExecutionType? Execution { get { throw null; } set { } }
        public Azure.AI.Extensions.OpenAI.ResponsesEmptyModelParam Parameters { get { throw null; } set { } }
        protected override Azure.AI.Extensions.OpenAI.ResponsesTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Extensions.OpenAI.ResponsesTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.ResponsesToolSearchToolParam System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesToolSearchToolParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesToolSearchToolParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.ResponsesToolSearchToolParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesToolSearchToolParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesToolSearchToolParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesToolSearchToolParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResponsesWebSearchApproximateLocation : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesWebSearchApproximateLocation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesWebSearchApproximateLocation>
    {
        public ResponsesWebSearchApproximateLocation() { }
        public string City { get { throw null; } set { } }
        public string Country { get { throw null; } set { } }
        public string Kind { get { throw null; } }
        public string Region { get { throw null; } set { } }
        public string Timezone { get { throw null; } set { } }
        protected virtual Azure.AI.Extensions.OpenAI.ResponsesWebSearchApproximateLocation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Extensions.OpenAI.ResponsesWebSearchApproximateLocation PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.ResponsesWebSearchApproximateLocation System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesWebSearchApproximateLocation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesWebSearchApproximateLocation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.ResponsesWebSearchApproximateLocation System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesWebSearchApproximateLocation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesWebSearchApproximateLocation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesWebSearchApproximateLocation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResponsesWebSearchConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesWebSearchConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesWebSearchConfiguration>
    {
        public ResponsesWebSearchConfiguration(string projectConnectionId, string instanceName) { }
        public string InstanceName { get { throw null; } set { } }
        public string ProjectConnectionId { get { throw null; } set { } }
        protected virtual Azure.AI.Extensions.OpenAI.ResponsesWebSearchConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Extensions.OpenAI.ResponsesWebSearchConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.ResponsesWebSearchConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesWebSearchConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesWebSearchConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.ResponsesWebSearchConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesWebSearchConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesWebSearchConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesWebSearchConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResponsesWebSearchTool : Azure.AI.Extensions.OpenAI.ResponsesTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesWebSearchTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesWebSearchTool>
    {
        public ResponsesWebSearchTool() { }
        public Azure.AI.Extensions.OpenAI.ResponsesWebSearchConfiguration CustomSearchConfiguration { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.AI.Extensions.OpenAI.WebSearchToolFilters Filters { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.AI.Extensions.OpenAI.ResponsesWebSearchToolSearchContextSize? SearchContextSize { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.AI.Extensions.OpenAI.ToolConfig> ToolConfigs { get { throw null; } }
        public Azure.AI.Extensions.OpenAI.ResponsesWebSearchApproximateLocation UserLocation { get { throw null; } set { } }
        protected override Azure.AI.Extensions.OpenAI.ResponsesTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Extensions.OpenAI.ResponsesTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.ResponsesWebSearchTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesWebSearchTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesWebSearchTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.ResponsesWebSearchTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesWebSearchTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesWebSearchTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesWebSearchTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResponsesWebSearchToolSearchContextSize : System.IEquatable<Azure.AI.Extensions.OpenAI.ResponsesWebSearchToolSearchContextSize>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResponsesWebSearchToolSearchContextSize(string value) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesWebSearchToolSearchContextSize High { get { throw null; } }
        public static Azure.AI.Extensions.OpenAI.ResponsesWebSearchToolSearchContextSize Low { get { throw null; } }
        public static Azure.AI.Extensions.OpenAI.ResponsesWebSearchToolSearchContextSize Medium { get { throw null; } }
        public bool Equals(Azure.AI.Extensions.OpenAI.ResponsesWebSearchToolSearchContextSize other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Extensions.OpenAI.ResponsesWebSearchToolSearchContextSize left, Azure.AI.Extensions.OpenAI.ResponsesWebSearchToolSearchContextSize right) { throw null; }
        public static implicit operator Azure.AI.Extensions.OpenAI.ResponsesWebSearchToolSearchContextSize (string value) { throw null; }
        public static implicit operator Azure.AI.Extensions.OpenAI.ResponsesWebSearchToolSearchContextSize? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Extensions.OpenAI.ResponsesWebSearchToolSearchContextSize left, Azure.AI.Extensions.OpenAI.ResponsesWebSearchToolSearchContextSize right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class ResponsesWorkIQPreviewTool : Azure.AI.Extensions.OpenAI.ResponsesTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesWorkIQPreviewTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesWorkIQPreviewTool>
    {
        public ResponsesWorkIQPreviewTool(string projectConnectionId) { }
        public string ProjectConnectionId { get { throw null; } set { } }
        protected override Azure.AI.Extensions.OpenAI.ResponsesTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Extensions.OpenAI.ResponsesTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.ResponsesWorkIQPreviewTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesWorkIQPreviewTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesWorkIQPreviewTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.ResponsesWorkIQPreviewTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesWorkIQPreviewTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesWorkIQPreviewTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesWorkIQPreviewTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class SharepointGroundingToolCall : Azure.AI.Extensions.OpenAI.AgentResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.SharepointGroundingToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.SharepointGroundingToolCall>
    {
        public SharepointGroundingToolCall(string callId, string arguments, Azure.AI.Extensions.OpenAI.ToolCallStatus status) { }
>>>>>>> origin/main
        public string Arguments { get { throw null; } set { } }
        public string CallId { get { throw null; } set { } }
        public Azure.AI.Extensions.OpenAI.ToolCallStatus Status { get { throw null; } set { } }
        protected override OpenAI.Responses.ResponseItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override OpenAI.Responses.ResponseItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.SharepointGroundingToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.SharepointGroundingToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.SharepointGroundingToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.SharepointGroundingToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.SharepointGroundingToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.SharepointGroundingToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.SharepointGroundingToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class SharepointGroundingToolCallOutput : OpenAI.Responses.ResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.SharepointGroundingToolCallOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.SharepointGroundingToolCallOutput>
    {
        public SharepointGroundingToolCallOutput(string callId, Azure.AI.Extensions.OpenAI.ToolCallStatus status) : base (default(OpenAI.Responses.ResponseItemKind)) { }
        public string CallId { get { throw null; } set { } }
        public System.BinaryData Output { get { throw null; } set { } }
        public Azure.AI.Extensions.OpenAI.ToolCallStatus Status { get { throw null; } set { } }
        protected override OpenAI.Responses.ResponseItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override OpenAI.Responses.ResponseItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.SharepointGroundingToolCallOutput System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.SharepointGroundingToolCallOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.SharepointGroundingToolCallOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.SharepointGroundingToolCallOutput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.SharepointGroundingToolCallOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.SharepointGroundingToolCallOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.SharepointGroundingToolCallOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SharePointGroundingToolOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.SharePointGroundingToolOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.SharePointGroundingToolOptions>
    {
        public SharePointGroundingToolOptions() { }
        public System.Collections.Generic.IList<Azure.AI.Extensions.OpenAI.ToolProjectConnection> ProjectConnections { get { throw null; } }
        protected virtual Azure.AI.Extensions.OpenAI.SharePointGroundingToolOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Extensions.OpenAI.SharePointGroundingToolOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.SharePointGroundingToolOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.SharePointGroundingToolOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.SharePointGroundingToolOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.SharePointGroundingToolOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.SharePointGroundingToolOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.SharePointGroundingToolOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.SharePointGroundingToolOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class SharepointPreviewTool : OpenAI.Responses.ResponseTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.SharepointPreviewTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.SharepointPreviewTool>
    {
        public SharepointPreviewTool(Azure.AI.Extensions.OpenAI.SharePointGroundingToolOptions toolOptions) : base (default(OpenAI.Responses.ResponseToolKind)) { }
        public Azure.AI.Extensions.OpenAI.SharePointGroundingToolOptions ToolOptions { get { throw null; } set { } }
        protected override OpenAI.Responses.ResponseTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override OpenAI.Responses.ResponseTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.SharepointPreviewTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.SharepointPreviewTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.SharepointPreviewTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.SharepointPreviewTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.SharepointPreviewTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.SharepointPreviewTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.SharepointPreviewTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StructuredOutputDefinition : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.StructuredOutputDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.StructuredOutputDefinition>
    {
        public StructuredOutputDefinition(string name, string description, System.Collections.Generic.IDictionary<string, System.BinaryData> schema, bool? isStrict) { }
        public string Description { get { throw null; } set { } }
        public bool? IsStrict { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Schema { get { throw null; } }
        protected virtual Azure.AI.Extensions.OpenAI.StructuredOutputDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Extensions.OpenAI.StructuredOutputDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.StructuredOutputDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.StructuredOutputDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.StructuredOutputDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.StructuredOutputDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.StructuredOutputDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.StructuredOutputDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.StructuredOutputDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum ToolCallStatus
    {
        InProgress = 0,
        Completed = 1,
        Incomplete = 2,
        Failed = 3,
    }
    public partial class ToolConfig : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ToolConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ToolConfig>
    {
        public ToolConfig() { }
        public string AdditionalSearchText { get { throw null; } set { } }
        public bool? Pin { get { throw null; } set { } }
        protected virtual Azure.AI.Extensions.OpenAI.ToolConfig JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Extensions.OpenAI.ToolConfig PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.ToolConfig System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ToolConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ToolConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.ToolConfig System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ToolConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ToolConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ToolConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ToolProjectConnection : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ToolProjectConnection>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ToolProjectConnection>
    {
        public ToolProjectConnection(string projectConnectionId) { }
        public string ProjectConnectionId { get { throw null; } set { } }
        protected virtual Azure.AI.Extensions.OpenAI.ToolProjectConnection JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Extensions.OpenAI.ToolProjectConnection PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.ToolProjectConnection System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ToolProjectConnection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ToolProjectConnection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.ToolProjectConnection System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ToolProjectConnection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ToolProjectConnection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ToolProjectConnection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class UserProfileMemoryItem : Azure.AI.Extensions.OpenAI.MemoryOutputItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.UserProfileMemoryItem>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.UserProfileMemoryItem>
    {
        public UserProfileMemoryItem(string memoryId, System.DateTimeOffset updatedAt, string scope, string content) { }
        protected override Azure.AI.Extensions.OpenAI.MemoryOutputItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Extensions.OpenAI.MemoryOutputItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.UserProfileMemoryItem System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.UserProfileMemoryItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.UserProfileMemoryItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.UserProfileMemoryItem System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.UserProfileMemoryItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.UserProfileMemoryItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.UserProfileMemoryItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WebSearchConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.WebSearchConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.WebSearchConfiguration>
    {
        public WebSearchConfiguration(string projectConnectionId, string instanceName) { }
        public string InstanceName { get { throw null; } set { } }
        public string ProjectConnectionId { get { throw null; } set { } }
        protected virtual Azure.AI.Extensions.OpenAI.WebSearchConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Extensions.OpenAI.WebSearchConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.WebSearchConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.WebSearchConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.WebSearchConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.WebSearchConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.WebSearchConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.WebSearchConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.WebSearchConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class WorkIQPreviewTool : OpenAI.Responses.ResponseTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.WorkIQPreviewTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.WorkIQPreviewTool>
    {
        public WorkIQPreviewTool(string projectConnectionId) : base (default(OpenAI.Responses.ResponseToolKind)) { }
        public string ProjectConnectionId { get { throw null; } set { } }
        protected override OpenAI.Responses.ResponseTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override OpenAI.Responses.ResponseTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.WorkIQPreviewTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.WorkIQPreviewTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.WorkIQPreviewTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.WorkIQPreviewTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.WorkIQPreviewTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.WorkIQPreviewTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.WorkIQPreviewTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Azure.AI.Projects
{
    public static partial class ClientConnectionProviderExtensions
    {
        public static Azure.AI.Extensions.OpenAI.ProjectOpenAIClient GetProjectOpenAIClient(this System.ClientModel.Primitives.ClientConnectionProvider connectionProvider, Azure.AI.Extensions.OpenAI.ProjectOpenAIClientOptions options = null) { throw null; }
        public sealed partial class <G>$EE9D7A1C67932FB454531401B8375DE4
        {
            internal <G>$EE9D7A1C67932FB454531401B8375DE4() { }
            public Azure.AI.Extensions.OpenAI.ProjectOpenAIClient GetProjectOpenAIClient(Azure.AI.Extensions.OpenAI.ProjectOpenAIClientOptions options = null) { throw null; }
            public static partial class <M>$781747A4149937EE6CD40CB5B8268DAD
            {
                public static void <Extension>$(System.ClientModel.Primitives.ClientConnectionProvider connectionProvider) { }
            }
        }
    }
}
