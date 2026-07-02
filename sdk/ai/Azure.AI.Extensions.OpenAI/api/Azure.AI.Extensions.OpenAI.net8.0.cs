namespace Azure.AI.Extensions.OpenAI
{
    public partial class A2APreviewTool : OpenAI.Responses.ResponseTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.A2APreviewTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.A2APreviewTool>
    {
        internal A2APreviewTool() : base (default(OpenAI.Responses.ResponseToolKind)) { }
        public string AgentCardPath { get { throw null; } }
        public System.Uri BaseUri { get { throw null; } }
        public string ProjectConnectionId { get { throw null; } }
        public bool? SendCredentialsForAgentCard { get { throw null; } }
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
    public partial class A2AToolCall : OpenAI.Responses.ResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.A2AToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.A2AToolCall>
    {
        public A2AToolCall(string callId, string name, string arguments, Azure.AI.Extensions.OpenAI.ToolCallStatus status) : base (default(OpenAI.Responses.ResponseItemKind)) { }
        public string Arguments { get { throw null; } }
        public string CallId { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.AI.Extensions.OpenAI.ToolCallStatus Status { get { throw null; } }
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
    public partial class A2AToolCallOutput : OpenAI.Responses.ResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.A2AToolCallOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.A2AToolCallOutput>
    {
        public A2AToolCallOutput(string callId, string name, Azure.AI.Extensions.OpenAI.ToolCallStatus status) : base (default(OpenAI.Responses.ResponseItemKind)) { }
        public string CallId { get { throw null; } }
        public string Name { get { throw null; } }
        public System.BinaryData Output { get { throw null; } set { } }
        public Azure.AI.Extensions.OpenAI.ToolCallStatus Status { get { throw null; } }
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
        public string Name { get { throw null; } }
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
    public partial class AgentWorkflowPreviewActionResponseItem : OpenAI.Responses.ResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.AgentWorkflowPreviewActionResponseItem>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AgentWorkflowPreviewActionResponseItem>
    {
        public AgentWorkflowPreviewActionResponseItem(string kind, string actionId, Azure.AI.Extensions.OpenAI.AgentWorkflowPreviewActionStatus? status) : base (default(OpenAI.Responses.ResponseItemKind)) { }
        public string ActionId { get { throw null; } }
        public string CSDLActionKind { get { throw null; } }
        public string ParentActionId { get { throw null; } }
        public string PreviousActionId { get { throw null; } }
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
    public partial class AISearchIndexResource : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.AISearchIndexResource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AISearchIndexResource>
    {
        internal AISearchIndexResource() { }
        public string Filter { get { throw null; } }
        public string IndexAssetId { get { throw null; } }
        public string IndexName { get { throw null; } }
        public string ProjectConnectionId { get { throw null; } }
        public Azure.AI.Extensions.OpenAI.AzureAISearchQueryKind? QueryType { get { throw null; } }
        public int? TopK { get { throw null; } }
        protected virtual Azure.AI.Extensions.OpenAI.AISearchIndexResource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Extensions.OpenAI.AISearchIndexResource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.AISearchIndexResource System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.AISearchIndexResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.AISearchIndexResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.AISearchIndexResource System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AISearchIndexResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AISearchIndexResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AISearchIndexResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AutoCodeInterpreterToolParam : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.AutoCodeInterpreterToolParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AutoCodeInterpreterToolParam>
    {
        internal AutoCodeInterpreterToolParam() { }
        public System.Collections.Generic.IList<string> FileIds { get { throw null; } }
        public Azure.AI.Extensions.OpenAI.ContainerMemoryLimit? MemoryLimit { get { throw null; } }
        public Azure.AI.Extensions.OpenAI.ContainerNetworkPolicyParam NetworkPolicy { get { throw null; } }
        protected virtual Azure.AI.Extensions.OpenAI.AutoCodeInterpreterToolParam JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Extensions.OpenAI.AutoCodeInterpreterToolParam PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.AutoCodeInterpreterToolParam System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.AutoCodeInterpreterToolParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.AutoCodeInterpreterToolParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.AutoCodeInterpreterToolParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AutoCodeInterpreterToolParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AutoCodeInterpreterToolParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AutoCodeInterpreterToolParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class AzureAIExtensions
    {
        public static OpenAI.Responses.ResponseItem AsAgentResponseItem(this OpenAI.Responses.ResponseItem responseItem) { throw null; }
        public static System.ClientModel.ClientResult<OpenAI.Responses.ResponseResult> CreateResponse(this OpenAI.Responses.ResponsesClient responseClient, Azure.AI.Extensions.OpenAI.ProjectConversation conversation, Azure.AI.Extensions.OpenAI.AgentReference agentRef, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.Diagnostics.DebuggerStepThroughAttribute]
        public static System.Threading.Tasks.Task<System.ClientModel.ClientResult<OpenAI.Responses.ResponseResult>> CreateResponseAsync(this OpenAI.Responses.ResponsesClient responseClient, Azure.AI.Extensions.OpenAI.ProjectConversation conversation, Azure.AI.Extensions.OpenAI.AgentReference agentRef, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static string GetAzureFileStatus(this OpenAI.Files.OpenAIFile file) { throw null; }
        public static Azure.AI.Extensions.OpenAI.AgentReference get_Agent(OpenAI.Responses.CreateResponseOptions options) { throw null; }
        public static Azure.AI.Extensions.OpenAI.AgentReference get_Agent(OpenAI.Responses.ResponseResult response) { throw null; }
        public static string get_AgentConversationId(OpenAI.Responses.CreateResponseOptions options) { throw null; }
        public static string get_AgentConversationId(OpenAI.Responses.ResponseResult response) { throw null; }
        public static void set_Agent(OpenAI.Responses.CreateResponseOptions options, Azure.AI.Extensions.OpenAI.AgentReference value) { }
        public static void set_AgentConversationId(OpenAI.Responses.CreateResponseOptions options, string value) { }
        public sealed partial class <G>$9441C364D6D7BED1E759B10623E362FD
        {
            internal <G>$9441C364D6D7BED1E759B10623E362FD() { }
            public Azure.AI.Extensions.OpenAI.AgentReference Agent { get { throw null; } set { } }
            public string AgentConversationId { get { throw null; } set { } }
            public static partial class <M>$CF4B939802E692FD9BEF27F36FABED87
            {
                public static void <Extension>$(OpenAI.Responses.CreateResponseOptions options) { }
            }
        }
        public sealed partial class <G>$D7C08262BAEC712802F8752B389F8208
        {
            internal <G>$D7C08262BAEC712802F8752B389F8208() { }
            public Azure.AI.Extensions.OpenAI.AgentReference Agent { get { throw null; } }
            public string AgentConversationId { get { throw null; } }
            public static partial class <M>$9CB7C4485EAB7B97A3544F52CBDBA0F9
            {
                public static void <Extension>$(OpenAI.Responses.ResponseResult response) { }
            }
        }
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
    public partial class AzureAISearchTool : OpenAI.Responses.ResponseTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.AzureAISearchTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AzureAISearchTool>
    {
        internal AzureAISearchTool() : base (default(OpenAI.Responses.ResponseToolKind)) { }
        public Azure.AI.Extensions.OpenAI.AzureAISearchToolResource AzureAISearch { get { throw null; } }
        public string Description { get { throw null; } }
        public string Name { get { throw null; } }
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
    public partial class AzureAISearchToolCall : OpenAI.Responses.ResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.AzureAISearchToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AzureAISearchToolCall>
    {
        public AzureAISearchToolCall(string callId, string arguments, Azure.AI.Extensions.OpenAI.ToolCallStatus status) : base (default(OpenAI.Responses.ResponseItemKind)) { }
        public string Arguments { get { throw null; } }
        public string CallId { get { throw null; } }
        public Azure.AI.Extensions.OpenAI.ToolCallStatus Status { get { throw null; } }
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
    public partial class AzureAISearchToolCallOutput : OpenAI.Responses.ResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.AzureAISearchToolCallOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AzureAISearchToolCallOutput>
    {
        public AzureAISearchToolCallOutput(string callId, Azure.AI.Extensions.OpenAI.ToolCallStatus status) : base (default(OpenAI.Responses.ResponseItemKind)) { }
        public string CallId { get { throw null; } }
        public System.BinaryData Output { get { throw null; } set { } }
        public Azure.AI.Extensions.OpenAI.ToolCallStatus Status { get { throw null; } }
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
    public partial class AzureAISearchToolResource : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.AzureAISearchToolResource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AzureAISearchToolResource>
    {
        internal AzureAISearchToolResource() { }
        public System.Collections.Generic.IList<Azure.AI.Extensions.OpenAI.AISearchIndexResource> Indexes { get { throw null; } }
        protected virtual Azure.AI.Extensions.OpenAI.AzureAISearchToolResource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Extensions.OpenAI.AzureAISearchToolResource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.AzureAISearchToolResource System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.AzureAISearchToolResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.AzureAISearchToolResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.AzureAISearchToolResource System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AzureAISearchToolResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AzureAISearchToolResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AzureAISearchToolResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureFunctionBinding : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.AzureFunctionBinding>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AzureFunctionBinding>
    {
        internal AzureFunctionBinding() { }
        public Azure.AI.Extensions.OpenAI.AzureFunctionStorageQueue StorageQueue { get { throw null; } }
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
        internal AzureFunctionDefinition() { }
        public Azure.AI.Extensions.OpenAI.AzureFunctionDefinitionFunction Function { get { throw null; } }
        public Azure.AI.Extensions.OpenAI.AzureFunctionBinding InputBinding { get { throw null; } }
        public Azure.AI.Extensions.OpenAI.AzureFunctionBinding OutputBinding { get { throw null; } }
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
        internal AzureFunctionDefinitionFunction() { }
        public string Description { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Parameters { get { throw null; } }
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
        internal AzureFunctionStorageQueue() { }
        public string QueueName { get { throw null; } }
        public string QueueServiceEndpoint { get { throw null; } }
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
    public partial class AzureFunctionTool : OpenAI.Responses.ResponseTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.AzureFunctionTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AzureFunctionTool>
    {
        internal AzureFunctionTool() : base (default(OpenAI.Responses.ResponseToolKind)) { }
        public Azure.AI.Extensions.OpenAI.AzureFunctionDefinition AzureFunction { get { throw null; } }
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
    public partial class AzureFunctionToolCall : OpenAI.Responses.ResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.AzureFunctionToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AzureFunctionToolCall>
    {
        public AzureFunctionToolCall(string callId, string name, string arguments, Azure.AI.Extensions.OpenAI.ToolCallStatus status) : base (default(OpenAI.Responses.ResponseItemKind)) { }
        public string Arguments { get { throw null; } }
        public string CallId { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.AI.Extensions.OpenAI.ToolCallStatus Status { get { throw null; } }
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
    public partial class AzureFunctionToolCallOutput : OpenAI.Responses.ResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.AzureFunctionToolCallOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AzureFunctionToolCallOutput>
    {
        public AzureFunctionToolCallOutput(string callId, string name, Azure.AI.Extensions.OpenAI.ToolCallStatus status) : base (default(OpenAI.Responses.ResponseItemKind)) { }
        public string CallId { get { throw null; } }
        public string Name { get { throw null; } }
        public System.BinaryData Output { get { throw null; } set { } }
        public Azure.AI.Extensions.OpenAI.ToolCallStatus Status { get { throw null; } }
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
    public partial class BingCustomSearchConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.BingCustomSearchConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BingCustomSearchConfiguration>
    {
        internal BingCustomSearchConfiguration() { }
        public long? Count { get { throw null; } }
        public string Freshness { get { throw null; } }
        public string InstanceName { get { throw null; } }
        public string Market { get { throw null; } }
        public string ProjectConnectionId { get { throw null; } }
        public string SetLang { get { throw null; } }
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
    public partial class BingCustomSearchPreviewTool : OpenAI.Responses.ResponseTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.BingCustomSearchPreviewTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BingCustomSearchPreviewTool>
    {
        internal BingCustomSearchPreviewTool() : base (default(OpenAI.Responses.ResponseToolKind)) { }
        public Azure.AI.Extensions.OpenAI.BingCustomSearchToolParameters BingCustomSearchPreview { get { throw null; } }
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
    public partial class BingCustomSearchToolCall : OpenAI.Responses.ResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.BingCustomSearchToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BingCustomSearchToolCall>
    {
        public BingCustomSearchToolCall(string callId, string arguments, Azure.AI.Extensions.OpenAI.ToolCallStatus status) : base (default(OpenAI.Responses.ResponseItemKind)) { }
        public string Arguments { get { throw null; } }
        public string CallId { get { throw null; } }
        public Azure.AI.Extensions.OpenAI.ToolCallStatus Status { get { throw null; } }
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
    public partial class BingCustomSearchToolCallOutput : OpenAI.Responses.ResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.BingCustomSearchToolCallOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BingCustomSearchToolCallOutput>
    {
        public BingCustomSearchToolCallOutput(string callId, Azure.AI.Extensions.OpenAI.ToolCallStatus status) : base (default(OpenAI.Responses.ResponseItemKind)) { }
        public string CallId { get { throw null; } }
        public System.BinaryData Output { get { throw null; } set { } }
        public Azure.AI.Extensions.OpenAI.ToolCallStatus Status { get { throw null; } }
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
    public partial class BingCustomSearchToolParameters : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.BingCustomSearchToolParameters>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BingCustomSearchToolParameters>
    {
        internal BingCustomSearchToolParameters() { }
        public System.Collections.Generic.IList<Azure.AI.Extensions.OpenAI.BingCustomSearchConfiguration> SearchConfigurations { get { throw null; } }
        protected virtual Azure.AI.Extensions.OpenAI.BingCustomSearchToolParameters JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Extensions.OpenAI.BingCustomSearchToolParameters PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.BingCustomSearchToolParameters System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.BingCustomSearchToolParameters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.BingCustomSearchToolParameters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.BingCustomSearchToolParameters System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BingCustomSearchToolParameters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BingCustomSearchToolParameters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BingCustomSearchToolParameters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BingGroundingSearchConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.BingGroundingSearchConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BingGroundingSearchConfiguration>
    {
        internal BingGroundingSearchConfiguration() { }
        public long? Count { get { throw null; } }
        public string Freshness { get { throw null; } }
        public string Language { get { throw null; } }
        public string Market { get { throw null; } }
        public string ProjectConnectionId { get { throw null; } }
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
    public partial class BingGroundingSearchToolParameters : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.BingGroundingSearchToolParameters>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BingGroundingSearchToolParameters>
    {
        internal BingGroundingSearchToolParameters() { }
        public System.Collections.Generic.IList<Azure.AI.Extensions.OpenAI.BingGroundingSearchConfiguration> SearchConfigurations { get { throw null; } }
        protected virtual Azure.AI.Extensions.OpenAI.BingGroundingSearchToolParameters JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Extensions.OpenAI.BingGroundingSearchToolParameters PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.BingGroundingSearchToolParameters System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.BingGroundingSearchToolParameters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.BingGroundingSearchToolParameters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.BingGroundingSearchToolParameters System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BingGroundingSearchToolParameters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BingGroundingSearchToolParameters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BingGroundingSearchToolParameters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BingGroundingTool : OpenAI.Responses.ResponseTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.BingGroundingTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BingGroundingTool>
    {
        internal BingGroundingTool() : base (default(OpenAI.Responses.ResponseToolKind)) { }
        public Azure.AI.Extensions.OpenAI.BingGroundingSearchToolParameters BingGrounding { get { throw null; } }
        public string Description { get { throw null; } }
        public string Name { get { throw null; } }
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
    public partial class BingGroundingToolCall : OpenAI.Responses.ResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.BingGroundingToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BingGroundingToolCall>
    {
        public BingGroundingToolCall(string callId, string arguments, Azure.AI.Extensions.OpenAI.ToolCallStatus status) : base (default(OpenAI.Responses.ResponseItemKind)) { }
        public string Arguments { get { throw null; } }
        public string CallId { get { throw null; } }
        public Azure.AI.Extensions.OpenAI.ToolCallStatus Status { get { throw null; } }
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
    public partial class BingGroundingToolCallOutput : OpenAI.Responses.ResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.BingGroundingToolCallOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BingGroundingToolCallOutput>
    {
        public BingGroundingToolCallOutput(string callId, Azure.AI.Extensions.OpenAI.ToolCallStatus status) : base (default(OpenAI.Responses.ResponseItemKind)) { }
        public string CallId { get { throw null; } }
        public System.BinaryData Output { get { throw null; } set { } }
        public Azure.AI.Extensions.OpenAI.ToolCallStatus Status { get { throw null; } }
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
    public partial class BrowserAutomationPreviewTool : OpenAI.Responses.ResponseTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.BrowserAutomationPreviewTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BrowserAutomationPreviewTool>
    {
        internal BrowserAutomationPreviewTool() : base (default(OpenAI.Responses.ResponseToolKind)) { }
        public Azure.AI.Extensions.OpenAI.BrowserAutomationToolParameters BrowserAutomationPreview { get { throw null; } }
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
    public partial class BrowserAutomationToolCall : OpenAI.Responses.ResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.BrowserAutomationToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BrowserAutomationToolCall>
    {
        public BrowserAutomationToolCall(string callId, string arguments, Azure.AI.Extensions.OpenAI.ToolCallStatus status) : base (default(OpenAI.Responses.ResponseItemKind)) { }
        public string Arguments { get { throw null; } }
        public string CallId { get { throw null; } }
        public Azure.AI.Extensions.OpenAI.ToolCallStatus Status { get { throw null; } }
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
    public partial class BrowserAutomationToolCallOutput : OpenAI.Responses.ResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.BrowserAutomationToolCallOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BrowserAutomationToolCallOutput>
    {
        public BrowserAutomationToolCallOutput(string callId, Azure.AI.Extensions.OpenAI.ToolCallStatus status) : base (default(OpenAI.Responses.ResponseItemKind)) { }
        public string CallId { get { throw null; } }
        public System.BinaryData Output { get { throw null; } set { } }
        public Azure.AI.Extensions.OpenAI.ToolCallStatus Status { get { throw null; } }
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
    public partial class BrowserAutomationToolConnectionParameters : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.BrowserAutomationToolConnectionParameters>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BrowserAutomationToolConnectionParameters>
    {
        internal BrowserAutomationToolConnectionParameters() { }
        public string ProjectConnectionId { get { throw null; } }
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
    public partial class BrowserAutomationToolParameters : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.BrowserAutomationToolParameters>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BrowserAutomationToolParameters>
    {
        internal BrowserAutomationToolParameters() { }
        public Azure.AI.Extensions.OpenAI.BrowserAutomationToolConnectionParameters Connection { get { throw null; } }
        protected virtual Azure.AI.Extensions.OpenAI.BrowserAutomationToolParameters JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Extensions.OpenAI.BrowserAutomationToolParameters PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.BrowserAutomationToolParameters System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.BrowserAutomationToolParameters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.BrowserAutomationToolParameters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.BrowserAutomationToolParameters System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BrowserAutomationToolParameters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BrowserAutomationToolParameters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BrowserAutomationToolParameters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CaptureStructuredOutputsTool : OpenAI.Responses.ResponseTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.CaptureStructuredOutputsTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.CaptureStructuredOutputsTool>
    {
        internal CaptureStructuredOutputsTool() : base (default(OpenAI.Responses.ResponseToolKind)) { }
        public string Description { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.AI.Extensions.OpenAI.StructuredOutputDefinition OutputDefinition { get { throw null; } }
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
    public partial class ContainerAutoParam : Azure.AI.Extensions.OpenAI.FunctionShellToolParamEnvironment, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ContainerAutoParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ContainerAutoParam>
    {
        public ContainerAutoParam() { }
        public System.Collections.Generic.IList<string> FileIds { get { throw null; } }
        public Azure.AI.Extensions.OpenAI.ContainerMemoryLimit? MemoryLimit { get { throw null; } set { } }
        public Azure.AI.Extensions.OpenAI.ContainerNetworkPolicyParam NetworkPolicy { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Extensions.OpenAI.ContainerSkill> Skills { get { throw null; } }
        protected override Azure.AI.Extensions.OpenAI.FunctionShellToolParamEnvironment JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Extensions.OpenAI.FunctionShellToolParamEnvironment PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.ContainerAutoParam System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ContainerAutoParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ContainerAutoParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.ContainerAutoParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ContainerAutoParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ContainerAutoParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ContainerAutoParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerMemoryLimit : System.IEquatable<Azure.AI.Extensions.OpenAI.ContainerMemoryLimit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerMemoryLimit(string value) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ContainerMemoryLimit _16g { get { throw null; } }
        public static Azure.AI.Extensions.OpenAI.ContainerMemoryLimit _1g { get { throw null; } }
        public static Azure.AI.Extensions.OpenAI.ContainerMemoryLimit _4g { get { throw null; } }
        public static Azure.AI.Extensions.OpenAI.ContainerMemoryLimit _64g { get { throw null; } }
        public bool Equals(Azure.AI.Extensions.OpenAI.ContainerMemoryLimit other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Extensions.OpenAI.ContainerMemoryLimit left, Azure.AI.Extensions.OpenAI.ContainerMemoryLimit right) { throw null; }
        public static implicit operator Azure.AI.Extensions.OpenAI.ContainerMemoryLimit (string value) { throw null; }
        public static implicit operator Azure.AI.Extensions.OpenAI.ContainerMemoryLimit? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Extensions.OpenAI.ContainerMemoryLimit left, Azure.AI.Extensions.OpenAI.ContainerMemoryLimit right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerNetworkPolicyAllowlistParam : Azure.AI.Extensions.OpenAI.ContainerNetworkPolicyParam, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ContainerNetworkPolicyAllowlistParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ContainerNetworkPolicyAllowlistParam>
    {
        public ContainerNetworkPolicyAllowlistParam(System.Collections.Generic.IEnumerable<string> allowedDomains) { }
        public System.Collections.Generic.IList<string> AllowedDomains { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Extensions.OpenAI.ContainerNetworkPolicyDomainSecretParam> DomainSecrets { get { throw null; } }
        protected override Azure.AI.Extensions.OpenAI.ContainerNetworkPolicyParam JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Extensions.OpenAI.ContainerNetworkPolicyParam PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.ContainerNetworkPolicyAllowlistParam System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ContainerNetworkPolicyAllowlistParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ContainerNetworkPolicyAllowlistParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.ContainerNetworkPolicyAllowlistParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ContainerNetworkPolicyAllowlistParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ContainerNetworkPolicyAllowlistParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ContainerNetworkPolicyAllowlistParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerNetworkPolicyDisabledParam : Azure.AI.Extensions.OpenAI.ContainerNetworkPolicyParam, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ContainerNetworkPolicyDisabledParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ContainerNetworkPolicyDisabledParam>
    {
        public ContainerNetworkPolicyDisabledParam() { }
        protected override Azure.AI.Extensions.OpenAI.ContainerNetworkPolicyParam JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Extensions.OpenAI.ContainerNetworkPolicyParam PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.ContainerNetworkPolicyDisabledParam System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ContainerNetworkPolicyDisabledParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ContainerNetworkPolicyDisabledParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.ContainerNetworkPolicyDisabledParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ContainerNetworkPolicyDisabledParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ContainerNetworkPolicyDisabledParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ContainerNetworkPolicyDisabledParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerNetworkPolicyDomainSecretParam : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ContainerNetworkPolicyDomainSecretParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ContainerNetworkPolicyDomainSecretParam>
    {
        public ContainerNetworkPolicyDomainSecretParam(string domain, string name, string value) { }
        public string Domain { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual Azure.AI.Extensions.OpenAI.ContainerNetworkPolicyDomainSecretParam JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Extensions.OpenAI.ContainerNetworkPolicyDomainSecretParam PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.ContainerNetworkPolicyDomainSecretParam System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ContainerNetworkPolicyDomainSecretParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ContainerNetworkPolicyDomainSecretParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.ContainerNetworkPolicyDomainSecretParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ContainerNetworkPolicyDomainSecretParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ContainerNetworkPolicyDomainSecretParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ContainerNetworkPolicyDomainSecretParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ContainerNetworkPolicyParam : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ContainerNetworkPolicyParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ContainerNetworkPolicyParam>
    {
        internal ContainerNetworkPolicyParam() { }
        protected virtual Azure.AI.Extensions.OpenAI.ContainerNetworkPolicyParam JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Extensions.OpenAI.ContainerNetworkPolicyParam PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.ContainerNetworkPolicyParam System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ContainerNetworkPolicyParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ContainerNetworkPolicyParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.ContainerNetworkPolicyParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ContainerNetworkPolicyParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ContainerNetworkPolicyParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ContainerNetworkPolicyParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ContainerSkill : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ContainerSkill>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ContainerSkill>
    {
        internal ContainerSkill() { }
        protected virtual Azure.AI.Extensions.OpenAI.ContainerSkill JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Extensions.OpenAI.ContainerSkill PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.ContainerSkill System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ContainerSkill>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ContainerSkill>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.ContainerSkill System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ContainerSkill>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ContainerSkill>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ContainerSkill>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContentFilterConfiguration
    {
        public ContentFilterConfiguration(string policyName) { }
        public string PolicyName { get { throw null; } set { } }
    }
    public partial class CustomGrammarFormatParam : Azure.AI.Extensions.OpenAI.CustomToolParamFormat, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.CustomGrammarFormatParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.CustomGrammarFormatParam>
    {
        public CustomGrammarFormatParam(Azure.AI.Extensions.OpenAI.ResponsesGrammarSyntax syntax, string definition) { }
        public string Definition { get { throw null; } set { } }
        public Azure.AI.Extensions.OpenAI.ResponsesGrammarSyntax Syntax { get { throw null; } set { } }
        protected override Azure.AI.Extensions.OpenAI.CustomToolParamFormat JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Extensions.OpenAI.CustomToolParamFormat PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.CustomGrammarFormatParam System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.CustomGrammarFormatParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.CustomGrammarFormatParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.CustomGrammarFormatParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.CustomGrammarFormatParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.CustomGrammarFormatParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.CustomGrammarFormatParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomTextFormatParam : Azure.AI.Extensions.OpenAI.CustomToolParamFormat, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.CustomTextFormatParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.CustomTextFormatParam>
    {
        public CustomTextFormatParam() { }
        protected override Azure.AI.Extensions.OpenAI.CustomToolParamFormat JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Extensions.OpenAI.CustomToolParamFormat PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.CustomTextFormatParam System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.CustomTextFormatParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.CustomTextFormatParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.CustomTextFormatParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.CustomTextFormatParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.CustomTextFormatParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.CustomTextFormatParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomToolParam : OpenAI.Responses.ResponseTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.CustomToolParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.CustomToolParam>
    {
        public CustomToolParam(string name) : base (default(OpenAI.Responses.ResponseToolKind)) { }
        public string Description { get { throw null; } set { } }
        public Azure.AI.Extensions.OpenAI.CustomToolParamFormat Format { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public bool? ShouldDeferLoading { get { throw null; } set { } }
        protected override OpenAI.Responses.ResponseTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override OpenAI.Responses.ResponseTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.CustomToolParam System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.CustomToolParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.CustomToolParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.CustomToolParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.CustomToolParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.CustomToolParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.CustomToolParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class CustomToolParamFormat : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.CustomToolParamFormat>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.CustomToolParamFormat>
    {
        internal CustomToolParamFormat() { }
        protected virtual Azure.AI.Extensions.OpenAI.CustomToolParamFormat JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Extensions.OpenAI.CustomToolParamFormat PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.CustomToolParamFormat System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.CustomToolParamFormat>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.CustomToolParamFormat>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.CustomToolParamFormat System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.CustomToolParamFormat>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.CustomToolParamFormat>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.CustomToolParamFormat>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EmptyModelParam : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.EmptyModelParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.EmptyModelParam>
    {
        internal EmptyModelParam() { }
        protected virtual Azure.AI.Extensions.OpenAI.EmptyModelParam JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Extensions.OpenAI.EmptyModelParam PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.EmptyModelParam System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.EmptyModelParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.EmptyModelParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.EmptyModelParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.EmptyModelParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.EmptyModelParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.EmptyModelParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ExtensionsOpenAIModelFactory
    {
        public static Azure.AI.Extensions.OpenAI.A2APreviewTool A2APreviewTool(System.Uri baseUri = null, string agentCardPath = null, string projectConnectionId = null, bool? sendCredentialsForAgentCard = default(bool?)) { throw null; }
        public static Azure.AI.Extensions.OpenAI.A2AToolCall A2AToolCall(OpenAI.Responses.ResponseItemKind type = default(OpenAI.Responses.ResponseItemKind), string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, string name = null, string arguments = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        public static Azure.AI.Extensions.OpenAI.A2AToolCallOutput A2AToolCallOutput(OpenAI.Responses.ResponseItemKind type = default(OpenAI.Responses.ResponseItemKind), string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, string name = null, System.BinaryData output = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        public static Azure.AI.Extensions.OpenAI.AgentReference AgentReference(string name = null, string version = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.AgentStructuredOutputsResponseItem AgentStructuredOutputsResponseItem(OpenAI.Responses.ResponseItemKind type = default(OpenAI.Responses.ResponseItemKind), string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, System.BinaryData output = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.AgentWorkflowPreviewActionResponseItem AgentWorkflowPreviewActionResponseItem(OpenAI.Responses.ResponseItemKind type = default(OpenAI.Responses.ResponseItemKind), string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string csdlActionKind = null, string actionId = null, string parentActionId = null, string previousActionId = null, Azure.AI.Extensions.OpenAI.AgentWorkflowPreviewActionStatus? status = default(Azure.AI.Extensions.OpenAI.AgentWorkflowPreviewActionStatus?)) { throw null; }
        public static Azure.AI.Extensions.OpenAI.AISearchIndexResource AISearchIndexResource(string projectConnectionId = null, string indexName = null, Azure.AI.Extensions.OpenAI.AzureAISearchQueryKind? queryType = default(Azure.AI.Extensions.OpenAI.AzureAISearchQueryKind?), int? topK = default(int?), string filter = null, string indexAssetId = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.AutoCodeInterpreterToolParam AutoCodeInterpreterToolParam(System.Collections.Generic.IEnumerable<string> fileIds = null, Azure.AI.Extensions.OpenAI.ContainerMemoryLimit? memoryLimit = default(Azure.AI.Extensions.OpenAI.ContainerMemoryLimit?), Azure.AI.Extensions.OpenAI.ContainerNetworkPolicyParam networkPolicy = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.AzureAISearchTool AzureAISearchTool(string name = null, string description = null, System.Collections.Generic.IDictionary<string, Azure.AI.Extensions.OpenAI.ToolConfig> toolConfigs = null, Azure.AI.Extensions.OpenAI.AzureAISearchToolResource azureAISearch = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.AzureAISearchToolCall AzureAISearchToolCall(OpenAI.Responses.ResponseItemKind type = default(OpenAI.Responses.ResponseItemKind), string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, string arguments = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        public static Azure.AI.Extensions.OpenAI.AzureAISearchToolCallOutput AzureAISearchToolCallOutput(OpenAI.Responses.ResponseItemKind type = default(OpenAI.Responses.ResponseItemKind), string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, System.BinaryData output = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        public static Azure.AI.Extensions.OpenAI.AzureAISearchToolResource AzureAISearchToolResource(System.Collections.Generic.IEnumerable<Azure.AI.Extensions.OpenAI.AISearchIndexResource> indexes = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.AzureFunctionBinding AzureFunctionBinding(Azure.AI.Extensions.OpenAI.AzureFunctionStorageQueue storageQueue = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.AzureFunctionDefinition AzureFunctionDefinition(Azure.AI.Extensions.OpenAI.AzureFunctionDefinitionFunction function = null, Azure.AI.Extensions.OpenAI.AzureFunctionBinding inputBinding = null, Azure.AI.Extensions.OpenAI.AzureFunctionBinding outputBinding = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.AzureFunctionDefinitionFunction AzureFunctionDefinitionFunction(string name = null, string description = null, System.Collections.Generic.IDictionary<string, System.BinaryData> parameters = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.AzureFunctionStorageQueue AzureFunctionStorageQueue(string queueServiceEndpoint = null, string queueName = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.AzureFunctionTool AzureFunctionTool(System.Collections.Generic.IDictionary<string, Azure.AI.Extensions.OpenAI.ToolConfig> toolConfigs = null, Azure.AI.Extensions.OpenAI.AzureFunctionDefinition azureFunction = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.AzureFunctionToolCall AzureFunctionToolCall(OpenAI.Responses.ResponseItemKind type = default(OpenAI.Responses.ResponseItemKind), string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, string name = null, string arguments = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        public static Azure.AI.Extensions.OpenAI.AzureFunctionToolCallOutput AzureFunctionToolCallOutput(OpenAI.Responses.ResponseItemKind type = default(OpenAI.Responses.ResponseItemKind), string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, string name = null, System.BinaryData output = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        public static Azure.AI.Extensions.OpenAI.BingCustomSearchConfiguration BingCustomSearchConfiguration(string projectConnectionId = null, string instanceName = null, string market = null, string setLang = null, long? count = default(long?), string freshness = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.BingCustomSearchPreviewTool BingCustomSearchPreviewTool(Azure.AI.Extensions.OpenAI.BingCustomSearchToolParameters bingCustomSearchPreview = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.BingCustomSearchToolCall BingCustomSearchToolCall(OpenAI.Responses.ResponseItemKind type = default(OpenAI.Responses.ResponseItemKind), string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, string arguments = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        public static Azure.AI.Extensions.OpenAI.BingCustomSearchToolCallOutput BingCustomSearchToolCallOutput(OpenAI.Responses.ResponseItemKind type = default(OpenAI.Responses.ResponseItemKind), string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, System.BinaryData output = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        public static Azure.AI.Extensions.OpenAI.BingCustomSearchToolParameters BingCustomSearchToolParameters(System.Collections.Generic.IEnumerable<Azure.AI.Extensions.OpenAI.BingCustomSearchConfiguration> searchConfigurations = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.BingGroundingSearchConfiguration BingGroundingSearchConfiguration(string projectConnectionId = null, string market = null, string language = null, long? count = default(long?), string freshness = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.BingGroundingSearchToolParameters BingGroundingSearchToolParameters(System.Collections.Generic.IEnumerable<Azure.AI.Extensions.OpenAI.BingGroundingSearchConfiguration> searchConfigurations = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.BingGroundingTool BingGroundingTool(string name = null, string description = null, System.Collections.Generic.IDictionary<string, Azure.AI.Extensions.OpenAI.ToolConfig> toolConfigs = null, Azure.AI.Extensions.OpenAI.BingGroundingSearchToolParameters bingGrounding = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.BingGroundingToolCall BingGroundingToolCall(OpenAI.Responses.ResponseItemKind type = default(OpenAI.Responses.ResponseItemKind), string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, string arguments = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        public static Azure.AI.Extensions.OpenAI.BingGroundingToolCallOutput BingGroundingToolCallOutput(OpenAI.Responses.ResponseItemKind type = default(OpenAI.Responses.ResponseItemKind), string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, System.BinaryData output = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        public static Azure.AI.Extensions.OpenAI.BrowserAutomationPreviewTool BrowserAutomationPreviewTool(Azure.AI.Extensions.OpenAI.BrowserAutomationToolParameters browserAutomationPreview = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.BrowserAutomationToolCall BrowserAutomationToolCall(OpenAI.Responses.ResponseItemKind type = default(OpenAI.Responses.ResponseItemKind), string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, string arguments = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        public static Azure.AI.Extensions.OpenAI.BrowserAutomationToolCallOutput BrowserAutomationToolCallOutput(OpenAI.Responses.ResponseItemKind type = default(OpenAI.Responses.ResponseItemKind), string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, System.BinaryData output = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        public static Azure.AI.Extensions.OpenAI.BrowserAutomationToolConnectionParameters BrowserAutomationToolConnectionParameters(string projectConnectionId = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.BrowserAutomationToolParameters BrowserAutomationToolParameters(Azure.AI.Extensions.OpenAI.BrowserAutomationToolConnectionParameters connection = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.CaptureStructuredOutputsTool CaptureStructuredOutputsTool(string name = null, string description = null, System.Collections.Generic.IDictionary<string, Azure.AI.Extensions.OpenAI.ToolConfig> toolConfigs = null, Azure.AI.Extensions.OpenAI.StructuredOutputDefinition outputDefinition = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ChatSummaryMemoryItem ChatSummaryMemoryItem(string memoryId = null, System.DateTimeOffset updatedAt = default(System.DateTimeOffset), string scope = null, string content = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ContainerAutoParam ContainerAutoParam(System.Collections.Generic.IEnumerable<string> fileIds = null, Azure.AI.Extensions.OpenAI.ContainerMemoryLimit? memoryLimit = default(Azure.AI.Extensions.OpenAI.ContainerMemoryLimit?), System.Collections.Generic.IEnumerable<Azure.AI.Extensions.OpenAI.ContainerSkill> skills = null, Azure.AI.Extensions.OpenAI.ContainerNetworkPolicyParam networkPolicy = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ContainerNetworkPolicyAllowlistParam ContainerNetworkPolicyAllowlistParam(System.Collections.Generic.IEnumerable<string> allowedDomains = null, System.Collections.Generic.IEnumerable<Azure.AI.Extensions.OpenAI.ContainerNetworkPolicyDomainSecretParam> domainSecrets = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ContainerNetworkPolicyDisabledParam ContainerNetworkPolicyDisabledParam() { throw null; }
        public static Azure.AI.Extensions.OpenAI.ContainerNetworkPolicyDomainSecretParam ContainerNetworkPolicyDomainSecretParam(string domain = null, string name = null, string value = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ContainerNetworkPolicyParam ContainerNetworkPolicyParam(string type = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ContainerSkill ContainerSkill(string type = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.CustomGrammarFormatParam CustomGrammarFormatParam(Azure.AI.Extensions.OpenAI.ResponsesGrammarSyntax syntax = Azure.AI.Extensions.OpenAI.ResponsesGrammarSyntax.Lark, string definition = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.CustomTextFormatParam CustomTextFormatParam() { throw null; }
        public static Azure.AI.Extensions.OpenAI.CustomToolParam CustomToolParam(string name = null, string description = null, Azure.AI.Extensions.OpenAI.CustomToolParamFormat format = null, bool? shouldDeferLoading = default(bool?)) { throw null; }
        public static Azure.AI.Extensions.OpenAI.CustomToolParamFormat CustomToolParamFormat(string type = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.EmptyModelParam EmptyModelParam() { throw null; }
        public static Azure.AI.Extensions.OpenAI.FabricDataAgentToolCall FabricDataAgentToolCall(OpenAI.Responses.ResponseItemKind type = default(OpenAI.Responses.ResponseItemKind), string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, string arguments = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        public static Azure.AI.Extensions.OpenAI.FabricDataAgentToolCallOutput FabricDataAgentToolCallOutput(OpenAI.Responses.ResponseItemKind type = default(OpenAI.Responses.ResponseItemKind), string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, System.BinaryData output = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        public static Azure.AI.Extensions.OpenAI.FabricDataAgentToolOptions FabricDataAgentToolOptions(System.Collections.Generic.IEnumerable<Azure.AI.Extensions.OpenAI.ToolProjectConnection> projectConnections = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.FabricIQPreviewTool FabricIQPreviewTool(string projectConnectionId = null, string serverLabel = null, System.Uri serverUri = null, System.BinaryData requireApproval = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.FunctionShellToolParam FunctionShellToolParam(Azure.AI.Extensions.OpenAI.FunctionShellToolParamEnvironment environment = null, string name = null, string description = null, System.Collections.Generic.IDictionary<string, Azure.AI.Extensions.OpenAI.ToolConfig> toolConfigs = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.FunctionShellToolParamEnvironment FunctionShellToolParamEnvironment(string type = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.FunctionShellToolParamEnvironmentContainerReferenceParam FunctionShellToolParamEnvironmentContainerReferenceParam(string containerId = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.FunctionShellToolParamEnvironmentLocalEnvironmentParam FunctionShellToolParamEnvironmentLocalEnvironmentParam(System.Collections.Generic.IEnumerable<Azure.AI.Extensions.OpenAI.LocalSkillParam> skills = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.FunctionToolParam FunctionToolParam(string name = null, string description = null, Azure.AI.Extensions.OpenAI.EmptyModelParam parameters = null, bool? isStrict = default(bool?), bool? shouldDeferLoading = default(bool?)) { throw null; }
        public static Azure.AI.Extensions.OpenAI.InlineSkillParam InlineSkillParam(string name = null, string description = null, Azure.AI.Extensions.OpenAI.InlineSkillSourceParam source = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.InlineSkillSourceParam InlineSkillSourceParam(string data = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.Internal.InputFileContentParam InputFileContentParam(string fileId = null, string filename = null, string fileData = null, System.Uri fileUrl = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.LocalShellToolParam LocalShellToolParam(string name = null, string description = null, System.Collections.Generic.IDictionary<string, Azure.AI.Extensions.OpenAI.ToolConfig> toolConfigs = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.LocalSkillParam LocalSkillParam(string name = null, string description = null, string path = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.MCPToolFilter MCPToolFilter(System.Collections.Generic.IEnumerable<string> toolNames = null, bool? isReadOnly = default(bool?)) { throw null; }
        public static Azure.AI.Extensions.OpenAI.MCPToolRequireApproval MCPToolRequireApproval(Azure.AI.Extensions.OpenAI.MCPToolFilter always = null, Azure.AI.Extensions.OpenAI.MCPToolFilter never = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.MemoryCommandToolCall MemoryCommandToolCall(OpenAI.Responses.ResponseItemKind type = default(OpenAI.Responses.ResponseItemKind), string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, string arguments = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        public static Azure.AI.Extensions.OpenAI.MemoryCommandToolCallOutput MemoryCommandToolCallOutput(OpenAI.Responses.ResponseItemKind type = default(OpenAI.Responses.ResponseItemKind), string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        public static Azure.AI.Extensions.OpenAI.MemoryOutputItem MemoryOutputItem(string memoryId = null, System.DateTimeOffset updatedAt = default(System.DateTimeOffset), string scope = null, string content = null, string kind = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.MemorySearchOptions MemorySearchOptions(int? maxMemories = default(int?)) { throw null; }
        public static Azure.AI.Extensions.OpenAI.MemorySearchPreviewTool MemorySearchPreviewTool(string memoryStoreName = null, string scope = null, Azure.AI.Extensions.OpenAI.MemorySearchOptions searchOptions = null, int? updateDelayInSeconds = default(int?)) { throw null; }
        public static Azure.AI.Extensions.OpenAI.MemorySearchToolCall MemorySearchToolCall(OpenAI.Responses.ResponseItemKind type = default(OpenAI.Responses.ResponseItemKind), string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress, System.Collections.Generic.IEnumerable<Azure.AI.Extensions.OpenAI.MemoryOutputItem> memories = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.MicrosoftFabricPreviewTool MicrosoftFabricPreviewTool(Azure.AI.Extensions.OpenAI.FabricDataAgentToolOptions fabricDataagentPreview = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.NamespaceToolParam NamespaceToolParam(string name = null, string description = null, System.Collections.Generic.IEnumerable<System.BinaryData> tools = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.OAuthConsentRequestResponseItem OAuthConsentRequestResponseItem(OpenAI.Responses.ResponseItemKind type = default(OpenAI.Responses.ResponseItemKind), string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string internalConsentLink = null, string serverLabel = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.OpenApiAnonymousAuthDetails OpenApiAnonymousAuthDetails() { throw null; }
        public static Azure.AI.Extensions.OpenAI.OpenApiAuthDetails OpenApiAuthDetails(string type = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.OpenApiFunctionDefinition OpenApiFunctionDefinition(string name = null, string description = null, System.Collections.Generic.IDictionary<string, System.BinaryData> specification = null, Azure.AI.Extensions.OpenAI.OpenApiAuthDetails auth = null, System.Collections.Generic.IEnumerable<string> defaultParams = null, System.Collections.Generic.IEnumerable<Azure.AI.Extensions.OpenAI.OpenApiFunctionDefinitionFunction> functions = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.OpenApiFunctionDefinitionFunction OpenApiFunctionDefinitionFunction(string name = null, string description = null, System.Collections.Generic.IDictionary<string, System.BinaryData> parameters = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.OpenApiManagedAuthDetails OpenApiManagedAuthDetails(Azure.AI.Extensions.OpenAI.OpenApiManagedSecurityScheme securityScheme = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.OpenApiManagedSecurityScheme OpenApiManagedSecurityScheme(string audience = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.OpenApiProjectConnectionAuthDetails OpenApiProjectConnectionAuthDetails(Azure.AI.Extensions.OpenAI.OpenApiProjectConnectionSecurityScheme securityScheme = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.OpenApiProjectConnectionSecurityScheme OpenApiProjectConnectionSecurityScheme(string projectConnectionId = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.OpenApiTool OpenApiTool(System.Collections.Generic.IDictionary<string, Azure.AI.Extensions.OpenAI.ToolConfig> toolConfigs = null, Azure.AI.Extensions.OpenAI.OpenApiFunctionDefinition openApi = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.OpenApiToolCall OpenApiToolCall(OpenAI.Responses.ResponseItemKind type = default(OpenAI.Responses.ResponseItemKind), string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, string name = null, string arguments = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        public static Azure.AI.Extensions.OpenAI.OpenApiToolCallOutput OpenApiToolCallOutput(OpenAI.Responses.ResponseItemKind type = default(OpenAI.Responses.ResponseItemKind), string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, string name = null, System.BinaryData output = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ProceduralMemoryItem ProceduralMemoryItem(string memoryId = null, System.DateTimeOffset updatedAt = default(System.DateTimeOffset), string scope = null, string content = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ProjectConversation ProjectConversation(string id = null, System.Collections.Generic.IDictionary<string, string> metadata = null, System.DateTimeOffset createdAt = default(System.DateTimeOffset)) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ReminderPreviewTool ReminderPreviewTool(string name = null, string description = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.SharepointGroundingToolCall SharepointGroundingToolCall(OpenAI.Responses.ResponseItemKind type = default(OpenAI.Responses.ResponseItemKind), string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, string arguments = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        public static Azure.AI.Extensions.OpenAI.SharepointGroundingToolCallOutput SharepointGroundingToolCallOutput(OpenAI.Responses.ResponseItemKind type = default(OpenAI.Responses.ResponseItemKind), string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, System.BinaryData output = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        public static Azure.AI.Extensions.OpenAI.SharepointGroundingToolParameters SharepointGroundingToolParameters(System.Collections.Generic.IEnumerable<Azure.AI.Extensions.OpenAI.ToolProjectConnection> projectConnections = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.SharepointPreviewTool SharepointPreviewTool(Azure.AI.Extensions.OpenAI.SharepointGroundingToolParameters sharepointGroundingPreview = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.SkillReferenceParam SkillReferenceParam(string skillId = null, string version = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.StructuredOutputDefinition StructuredOutputDefinition(string name = null, string description = null, System.Collections.Generic.IDictionary<string, System.BinaryData> schema = null, bool? isStrict = default(bool?)) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ToolConfig ToolConfig(bool? pin = default(bool?), string additionalSearchText = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ToolProjectConnection ToolProjectConnection(string projectConnectionId = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ToolSearchToolParam ToolSearchToolParam(Azure.AI.Extensions.OpenAI.ToolSearchExecutionType? execution = default(Azure.AI.Extensions.OpenAI.ToolSearchExecutionType?), string description = null, Azure.AI.Extensions.OpenAI.EmptyModelParam parameters = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.UserProfileMemoryItem UserProfileMemoryItem(string memoryId = null, System.DateTimeOffset updatedAt = default(System.DateTimeOffset), string scope = null, string content = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.WebSearchApproximateLocation WebSearchApproximateLocation(string country = null, string region = null, string city = null, string timezone = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.WebSearchConfiguration WebSearchConfiguration(string projectConnectionId = null, string instanceName = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.WorkIQPreviewTool WorkIQPreviewTool(string projectConnectionId = null) { throw null; }
    }
    public partial class FabricDataAgentToolCall : OpenAI.Responses.ResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.FabricDataAgentToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.FabricDataAgentToolCall>
    {
        public FabricDataAgentToolCall(string callId, string arguments, Azure.AI.Extensions.OpenAI.ToolCallStatus status) : base (default(OpenAI.Responses.ResponseItemKind)) { }
        public string Arguments { get { throw null; } }
        public string CallId { get { throw null; } }
        public Azure.AI.Extensions.OpenAI.ToolCallStatus Status { get { throw null; } }
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
    public partial class FabricDataAgentToolCallOutput : OpenAI.Responses.ResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.FabricDataAgentToolCallOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.FabricDataAgentToolCallOutput>
    {
        public FabricDataAgentToolCallOutput(string callId, Azure.AI.Extensions.OpenAI.ToolCallStatus status) : base (default(OpenAI.Responses.ResponseItemKind)) { }
        public string CallId { get { throw null; } }
        public System.BinaryData Output { get { throw null; } set { } }
        public Azure.AI.Extensions.OpenAI.ToolCallStatus Status { get { throw null; } }
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
    public partial class FabricDataAgentToolOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.FabricDataAgentToolOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.FabricDataAgentToolOptions>
    {
        internal FabricDataAgentToolOptions() { }
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
    public partial class FabricIQPreviewTool : OpenAI.Responses.ResponseTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.FabricIQPreviewTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.FabricIQPreviewTool>
    {
        internal FabricIQPreviewTool() : base (default(OpenAI.Responses.ResponseToolKind)) { }
        public string ProjectConnectionId { get { throw null; } }
        public System.BinaryData RequireApproval { get { throw null; } }
        public string ServerLabel { get { throw null; } }
        public System.Uri ServerUri { get { throw null; } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential, Size=1)]
    public readonly partial struct FunctionCallOutputStatus
    {
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential, Size=1)]
    public readonly partial struct FunctionCallStatus
    {
    }
    public partial class FunctionShellToolParam : OpenAI.Responses.ResponseTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.FunctionShellToolParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.FunctionShellToolParam>
    {
        internal FunctionShellToolParam() : base (default(OpenAI.Responses.ResponseToolKind)) { }
        public string Description { get { throw null; } }
        public Azure.AI.Extensions.OpenAI.FunctionShellToolParamEnvironment Environment { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.AI.Extensions.OpenAI.ToolConfig> ToolConfigs { get { throw null; } }
        protected override OpenAI.Responses.ResponseTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override OpenAI.Responses.ResponseTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.FunctionShellToolParam System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.FunctionShellToolParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.FunctionShellToolParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.FunctionShellToolParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.FunctionShellToolParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.FunctionShellToolParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.FunctionShellToolParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class FunctionShellToolParamEnvironment : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.FunctionShellToolParamEnvironment>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.FunctionShellToolParamEnvironment>
    {
        internal FunctionShellToolParamEnvironment() { }
        protected virtual Azure.AI.Extensions.OpenAI.FunctionShellToolParamEnvironment JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Extensions.OpenAI.FunctionShellToolParamEnvironment PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.FunctionShellToolParamEnvironment System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.FunctionShellToolParamEnvironment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.FunctionShellToolParamEnvironment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.FunctionShellToolParamEnvironment System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.FunctionShellToolParamEnvironment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.FunctionShellToolParamEnvironment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.FunctionShellToolParamEnvironment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FunctionShellToolParamEnvironmentContainerReferenceParam : Azure.AI.Extensions.OpenAI.FunctionShellToolParamEnvironment, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.FunctionShellToolParamEnvironmentContainerReferenceParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.FunctionShellToolParamEnvironmentContainerReferenceParam>
    {
        public FunctionShellToolParamEnvironmentContainerReferenceParam(string containerId) { }
        public string ContainerId { get { throw null; } set { } }
        protected override Azure.AI.Extensions.OpenAI.FunctionShellToolParamEnvironment JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Extensions.OpenAI.FunctionShellToolParamEnvironment PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.FunctionShellToolParamEnvironmentContainerReferenceParam System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.FunctionShellToolParamEnvironmentContainerReferenceParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.FunctionShellToolParamEnvironmentContainerReferenceParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.FunctionShellToolParamEnvironmentContainerReferenceParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.FunctionShellToolParamEnvironmentContainerReferenceParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.FunctionShellToolParamEnvironmentContainerReferenceParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.FunctionShellToolParamEnvironmentContainerReferenceParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FunctionShellToolParamEnvironmentLocalEnvironmentParam : Azure.AI.Extensions.OpenAI.FunctionShellToolParamEnvironment, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.FunctionShellToolParamEnvironmentLocalEnvironmentParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.FunctionShellToolParamEnvironmentLocalEnvironmentParam>
    {
        public FunctionShellToolParamEnvironmentLocalEnvironmentParam() { }
        public System.Collections.Generic.IList<Azure.AI.Extensions.OpenAI.LocalSkillParam> Skills { get { throw null; } }
        protected override Azure.AI.Extensions.OpenAI.FunctionShellToolParamEnvironment JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Extensions.OpenAI.FunctionShellToolParamEnvironment PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.FunctionShellToolParamEnvironmentLocalEnvironmentParam System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.FunctionShellToolParamEnvironmentLocalEnvironmentParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.FunctionShellToolParamEnvironmentLocalEnvironmentParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.FunctionShellToolParamEnvironmentLocalEnvironmentParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.FunctionShellToolParamEnvironmentLocalEnvironmentParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.FunctionShellToolParamEnvironmentLocalEnvironmentParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.FunctionShellToolParamEnvironmentLocalEnvironmentParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FunctionToolParam : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.FunctionToolParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.FunctionToolParam>
    {
        internal FunctionToolParam() { }
        public string Description { get { throw null; } }
        public bool? IsStrict { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.AI.Extensions.OpenAI.EmptyModelParam Parameters { get { throw null; } }
        public bool? ShouldDeferLoading { get { throw null; } }
        protected virtual Azure.AI.Extensions.OpenAI.FunctionToolParam JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Extensions.OpenAI.FunctionToolParam PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.FunctionToolParam System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.FunctionToolParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.FunctionToolParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.FunctionToolParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.FunctionToolParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.FunctionToolParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.FunctionToolParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InlineSkillParam : Azure.AI.Extensions.OpenAI.ContainerSkill, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.InlineSkillParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.InlineSkillParam>
    {
        public InlineSkillParam(string name, string description, Azure.AI.Extensions.OpenAI.InlineSkillSourceParam source) { }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.AI.Extensions.OpenAI.InlineSkillSourceParam Source { get { throw null; } set { } }
        protected override Azure.AI.Extensions.OpenAI.ContainerSkill JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Extensions.OpenAI.ContainerSkill PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.InlineSkillParam System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.InlineSkillParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.InlineSkillParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.InlineSkillParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.InlineSkillParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.InlineSkillParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.InlineSkillParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InlineSkillSourceParam : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.InlineSkillSourceParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.InlineSkillSourceParam>
    {
        public InlineSkillSourceParam(string data) { }
        public string Data { get { throw null; } set { } }
        public string MediaType { get { throw null; } }
        public string Type { get { throw null; } }
        protected virtual Azure.AI.Extensions.OpenAI.InlineSkillSourceParam JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Extensions.OpenAI.InlineSkillSourceParam PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.InlineSkillSourceParam System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.InlineSkillSourceParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.InlineSkillSourceParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.InlineSkillSourceParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.InlineSkillSourceParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.InlineSkillSourceParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.InlineSkillSourceParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LocalShellToolParam : OpenAI.Responses.ResponseTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.LocalShellToolParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.LocalShellToolParam>
    {
        internal LocalShellToolParam() : base (default(OpenAI.Responses.ResponseToolKind)) { }
        public string Description { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.AI.Extensions.OpenAI.ToolConfig> ToolConfigs { get { throw null; } }
        protected override OpenAI.Responses.ResponseTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override OpenAI.Responses.ResponseTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.LocalShellToolParam System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.LocalShellToolParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.LocalShellToolParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.LocalShellToolParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.LocalShellToolParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.LocalShellToolParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.LocalShellToolParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LocalSkillParam : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.LocalSkillParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.LocalSkillParam>
    {
        public LocalSkillParam(string name, string description, string path) { }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        protected virtual Azure.AI.Extensions.OpenAI.LocalSkillParam JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Extensions.OpenAI.LocalSkillParam PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.LocalSkillParam System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.LocalSkillParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.LocalSkillParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.LocalSkillParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.LocalSkillParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.LocalSkillParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.LocalSkillParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MCPToolFilter : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.MCPToolFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.MCPToolFilter>
    {
        internal MCPToolFilter() { }
        public bool? IsReadOnly { get { throw null; } }
        public System.Collections.Generic.IList<string> ToolNames { get { throw null; } }
        protected virtual Azure.AI.Extensions.OpenAI.MCPToolFilter JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Extensions.OpenAI.MCPToolFilter PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.MCPToolFilter System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.MCPToolFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.MCPToolFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.MCPToolFilter System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.MCPToolFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.MCPToolFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.MCPToolFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MCPToolRequireApproval : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.MCPToolRequireApproval>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.MCPToolRequireApproval>
    {
        internal MCPToolRequireApproval() { }
        public Azure.AI.Extensions.OpenAI.MCPToolFilter Always { get { throw null; } }
        public Azure.AI.Extensions.OpenAI.MCPToolFilter Never { get { throw null; } }
        protected virtual Azure.AI.Extensions.OpenAI.MCPToolRequireApproval JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Extensions.OpenAI.MCPToolRequireApproval PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.MCPToolRequireApproval System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.MCPToolRequireApproval>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.MCPToolRequireApproval>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.MCPToolRequireApproval System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.MCPToolRequireApproval>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.MCPToolRequireApproval>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.MCPToolRequireApproval>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MemoryCommandToolCall : OpenAI.Responses.ResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.MemoryCommandToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.MemoryCommandToolCall>
    {
        public MemoryCommandToolCall(string callId, string arguments, Azure.AI.Extensions.OpenAI.ToolCallStatus status) : base (default(OpenAI.Responses.ResponseItemKind)) { }
        public string Arguments { get { throw null; } }
        public string CallId { get { throw null; } }
        public Azure.AI.Extensions.OpenAI.ToolCallStatus Status { get { throw null; } }
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
    public partial class MemoryCommandToolCallOutput : OpenAI.Responses.ResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.MemoryCommandToolCallOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.MemoryCommandToolCallOutput>
    {
        public MemoryCommandToolCallOutput(string callId, Azure.AI.Extensions.OpenAI.ToolCallStatus status) : base (default(OpenAI.Responses.ResponseItemKind)) { }
        public string CallId { get { throw null; } }
        public Azure.AI.Extensions.OpenAI.ToolCallStatus Status { get { throw null; } }
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
    public abstract partial class MemoryOutputItem : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.MemoryOutputItem>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.MemoryOutputItem>
    {
        internal MemoryOutputItem() { }
        public string Content { get { throw null; } }
        public string MemoryId { get { throw null; } }
        public string Scope { get { throw null; } }
        public System.DateTimeOffset UpdatedAt { get { throw null; } }
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
    public partial class MemorySearchOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.MemorySearchOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.MemorySearchOptions>
    {
        internal MemorySearchOptions() { }
        public int? MaxMemories { get { throw null; } }
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
    public partial class MemorySearchPreviewTool : OpenAI.Responses.ResponseTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.MemorySearchPreviewTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.MemorySearchPreviewTool>
    {
        internal MemorySearchPreviewTool() : base (default(OpenAI.Responses.ResponseToolKind)) { }
        public string MemoryStoreName { get { throw null; } }
        public string Scope { get { throw null; } }
        public Azure.AI.Extensions.OpenAI.MemorySearchOptions SearchOptions { get { throw null; } }
        public int? UpdateDelayInSeconds { get { throw null; } }
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
    public partial class MemorySearchToolCall : OpenAI.Responses.ResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.MemorySearchToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.MemorySearchToolCall>
    {
        public MemorySearchToolCall(Azure.AI.Extensions.OpenAI.ToolCallStatus status) : base (default(OpenAI.Responses.ResponseItemKind)) { }
        public System.Collections.Generic.IList<Azure.AI.Extensions.OpenAI.MemoryOutputItem> Memories { get { throw null; } set { } }
        public Azure.AI.Extensions.OpenAI.ToolCallStatus Status { get { throw null; } }
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
    public partial class MicrosoftFabricPreviewTool : OpenAI.Responses.ResponseTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.MicrosoftFabricPreviewTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.MicrosoftFabricPreviewTool>
    {
        internal MicrosoftFabricPreviewTool() : base (default(OpenAI.Responses.ResponseToolKind)) { }
        public Azure.AI.Extensions.OpenAI.FabricDataAgentToolOptions FabricDataagentPreview { get { throw null; } }
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
    public partial class NamespaceToolParam : OpenAI.Responses.ResponseTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.NamespaceToolParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.NamespaceToolParam>
    {
        internal NamespaceToolParam() : base (default(OpenAI.Responses.ResponseToolKind)) { }
        public string Description { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IList<System.BinaryData> Tools { get { throw null; } }
        protected override OpenAI.Responses.ResponseTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override OpenAI.Responses.ResponseTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.NamespaceToolParam System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.NamespaceToolParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.NamespaceToolParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.NamespaceToolParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.NamespaceToolParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.NamespaceToolParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.NamespaceToolParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OAuthConsentRequestResponseItem : OpenAI.Responses.ResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.OAuthConsentRequestResponseItem>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.OAuthConsentRequestResponseItem>
    {
        public OAuthConsentRequestResponseItem(string consentLink, string serverLabel) : base (default(OpenAI.Responses.ResponseItemKind)) { }
        public OAuthConsentRequestResponseItem(System.Uri consentLink, string serverLabel) : base (default(OpenAI.Responses.ResponseItemKind)) { }
        public System.Uri ConsentLink { get { throw null; } }
        public string ServerLabel { get { throw null; } }
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
    public partial class OpenApiAnonymousAuthDetails : Azure.AI.Extensions.OpenAI.OpenApiAuthDetails, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.OpenApiAnonymousAuthDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.OpenApiAnonymousAuthDetails>
    {
        public OpenApiAnonymousAuthDetails() { }
        protected override Azure.AI.Extensions.OpenAI.OpenApiAuthDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Extensions.OpenAI.OpenApiAuthDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.OpenApiAnonymousAuthDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.OpenApiAnonymousAuthDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.OpenApiAnonymousAuthDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.OpenApiAnonymousAuthDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.OpenApiAnonymousAuthDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.OpenApiAnonymousAuthDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.OpenApiAnonymousAuthDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class OpenApiAuthDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.OpenApiAuthDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.OpenApiAuthDetails>
    {
        internal OpenApiAuthDetails() { }
        protected virtual Azure.AI.Extensions.OpenAI.OpenApiAuthDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Extensions.OpenAI.OpenApiAuthDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.OpenApiAuthDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.OpenApiAuthDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.OpenApiAuthDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.OpenApiAuthDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.OpenApiAuthDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.OpenApiAuthDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.OpenApiAuthDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OpenApiFunctionDefinition : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.OpenApiFunctionDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.OpenApiFunctionDefinition>
    {
        internal OpenApiFunctionDefinition() { }
        public Azure.AI.Extensions.OpenAI.OpenApiAuthDetails Auth { get { throw null; } }
        public System.Collections.Generic.IList<string> DefaultParams { get { throw null; } }
        public string Description { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Extensions.OpenAI.OpenApiFunctionDefinitionFunction> Functions { get { throw null; } }
        public string Name { get { throw null; } }
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
    public partial class OpenApiManagedAuthDetails : Azure.AI.Extensions.OpenAI.OpenApiAuthDetails, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.OpenApiManagedAuthDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.OpenApiManagedAuthDetails>
    {
        public OpenApiManagedAuthDetails(Azure.AI.Extensions.OpenAI.OpenApiManagedSecurityScheme securityScheme) { }
        public Azure.AI.Extensions.OpenAI.OpenApiManagedSecurityScheme SecurityScheme { get { throw null; } }
        protected override Azure.AI.Extensions.OpenAI.OpenApiAuthDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Extensions.OpenAI.OpenApiAuthDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public string Audience { get { throw null; } }
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
    public partial class OpenApiProjectConnectionAuthDetails : Azure.AI.Extensions.OpenAI.OpenApiAuthDetails, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.OpenApiProjectConnectionAuthDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.OpenApiProjectConnectionAuthDetails>
    {
        public OpenApiProjectConnectionAuthDetails(Azure.AI.Extensions.OpenAI.OpenApiProjectConnectionSecurityScheme securityScheme) { }
        public Azure.AI.Extensions.OpenAI.OpenApiProjectConnectionSecurityScheme SecurityScheme { get { throw null; } }
        protected override Azure.AI.Extensions.OpenAI.OpenApiAuthDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Extensions.OpenAI.OpenApiAuthDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.OpenApiProjectConnectionAuthDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.OpenApiProjectConnectionAuthDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.OpenApiProjectConnectionAuthDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.OpenApiProjectConnectionAuthDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.OpenApiProjectConnectionAuthDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.OpenApiProjectConnectionAuthDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.OpenApiProjectConnectionAuthDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OpenApiProjectConnectionSecurityScheme : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.OpenApiProjectConnectionSecurityScheme>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.OpenApiProjectConnectionSecurityScheme>
    {
        public OpenApiProjectConnectionSecurityScheme(string projectConnectionId) { }
        public string ProjectConnectionId { get { throw null; } }
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
    public partial class OpenApiTool : OpenAI.Responses.ResponseTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.OpenApiTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.OpenApiTool>
    {
        internal OpenApiTool() : base (default(OpenAI.Responses.ResponseToolKind)) { }
        public Azure.AI.Extensions.OpenAI.OpenApiFunctionDefinition OpenApi { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.AI.Extensions.OpenAI.ToolConfig> ToolConfigs { get { throw null; } }
        protected override OpenAI.Responses.ResponseTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override OpenAI.Responses.ResponseTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.OpenApiTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.OpenApiTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.OpenApiTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.OpenApiTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.OpenApiTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.OpenApiTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.OpenApiTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OpenApiToolCall : OpenAI.Responses.ResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.OpenApiToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.OpenApiToolCall>
    {
        public OpenApiToolCall(string callId, string name, string arguments, Azure.AI.Extensions.OpenAI.ToolCallStatus status) : base (default(OpenAI.Responses.ResponseItemKind)) { }
        public string Arguments { get { throw null; } }
        public string CallId { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.AI.Extensions.OpenAI.ToolCallStatus Status { get { throw null; } }
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
    public partial class OpenApiToolCallOutput : OpenAI.Responses.ResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.OpenApiToolCallOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.OpenApiToolCallOutput>
    {
        public OpenApiToolCallOutput(string callId, string name, Azure.AI.Extensions.OpenAI.ToolCallStatus status) : base (default(OpenAI.Responses.ResponseItemKind)) { }
        public string CallId { get { throw null; } }
        public string Name { get { throw null; } }
        public System.BinaryData Output { get { throw null; } set { } }
        public Azure.AI.Extensions.OpenAI.ToolCallStatus Status { get { throw null; } }
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
    public partial class ProjectConversation : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ProjectConversation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ProjectConversation>
    {
        internal ProjectConversation() { }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        protected virtual Azure.AI.Extensions.OpenAI.ProjectConversation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator string (Azure.AI.Extensions.OpenAI.ProjectConversation conversation) { throw null; }
        protected virtual Azure.AI.Extensions.OpenAI.ProjectConversation PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.ProjectConversation System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ProjectConversation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ProjectConversation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.ProjectConversation System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ProjectConversation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ProjectConversation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ProjectConversation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProjectConversationCreationOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ProjectConversationCreationOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ProjectConversationCreationOptions>
    {
        public ProjectConversationCreationOptions() { }
        public System.Collections.Generic.IList<OpenAI.Responses.ResponseItem> Items { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        protected virtual Azure.AI.Extensions.OpenAI.ProjectConversationCreationOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator System.ClientModel.BinaryContent (Azure.AI.Extensions.OpenAI.ProjectConversationCreationOptions projectConversationCreationOptions) { throw null; }
        protected virtual Azure.AI.Extensions.OpenAI.ProjectConversationCreationOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.ProjectConversationCreationOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ProjectConversationCreationOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ProjectConversationCreationOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.ProjectConversationCreationOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ProjectConversationCreationOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ProjectConversationCreationOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ProjectConversationCreationOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProjectConversationsClient : OpenAI.Conversations.ConversationClient
    {
        protected ProjectConversationsClient() { }
        public ProjectConversationsClient(System.ClientModel.Primitives.ClientPipeline pipeline, OpenAI.OpenAIClientOptions options) { }
        public virtual System.ClientModel.ClientResult<Azure.AI.Extensions.OpenAI.ProjectConversation> CreateProjectConversation(Azure.AI.Extensions.OpenAI.ProjectConversationCreationOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.Diagnostics.DebuggerStepThroughAttribute]
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Extensions.OpenAI.ProjectConversation>> CreateProjectConversationAsync(Azure.AI.Extensions.OpenAI.ProjectConversationCreationOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult<System.Collections.ObjectModel.ReadOnlyCollection<OpenAI.Responses.ResponseItem>> CreateProjectConversationItems(string conversationId, System.Collections.Generic.IEnumerable<OpenAI.Responses.ResponseItem> items, System.Collections.Generic.IEnumerable<OpenAI.Conversations.IncludedConversationItemProperty> include = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.Diagnostics.DebuggerStepThroughAttribute]
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<System.Collections.ObjectModel.ReadOnlyCollection<OpenAI.Responses.ResponseItem>>> CreateProjectConversationItemsAsync(string conversationId, System.Collections.Generic.IEnumerable<OpenAI.Responses.ResponseItem> items, System.Collections.Generic.IEnumerable<OpenAI.Conversations.IncludedConversationItemProperty> include = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Extensions.OpenAI.ProjectConversation> GetProjectConversation(string conversationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.Diagnostics.DebuggerStepThroughAttribute]
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Extensions.OpenAI.ProjectConversation>> GetProjectConversationAsync(string conversationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult<OpenAI.Responses.ResponseItem> GetProjectConversationItem(string conversationId, string itemId, System.Collections.Generic.IEnumerable<OpenAI.Conversations.IncludedConversationItemProperty> include = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.Diagnostics.DebuggerStepThroughAttribute]
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<OpenAI.Responses.ResponseItem>> GetProjectConversationItemAsync(string conversationId, string itemId, System.Collections.Generic.IEnumerable<OpenAI.Conversations.IncludedConversationItemProperty> include = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.CollectionResult<OpenAI.Responses.ResponseItem> GetProjectConversationItems(string conversationId, OpenAI.Responses.ResponseItemKind? itemKind = default(OpenAI.Responses.ResponseItemKind?), int? limit = default(int?), string order = null, string after = null, string before = null, System.Collections.Generic.IEnumerable<OpenAI.Conversations.IncludedConversationItemProperty> include = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<OpenAI.Responses.ResponseItem> GetProjectConversationItemsAsync(string conversationId, OpenAI.Responses.ResponseItemKind? itemKind = default(OpenAI.Responses.ResponseItemKind?), int? limit = default(int?), string order = null, string after = null, string before = null, System.Collections.Generic.IEnumerable<OpenAI.Conversations.IncludedConversationItemProperty> include = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Extensions.OpenAI.ProjectConversation> GetProjectConversations(Azure.AI.Extensions.OpenAI.AgentReference agent = null, int? limit = default(int?), string order = null, string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Extensions.OpenAI.ProjectConversation> GetProjectConversationsAsync(Azure.AI.Extensions.OpenAI.AgentReference agent = null, int? limit = default(int?), string order = null, string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Extensions.OpenAI.ProjectConversation> UpdateProjectConversation(string conversationId, Azure.AI.Extensions.OpenAI.ProjectConversationUpdateOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.Diagnostics.DebuggerStepThroughAttribute]
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Extensions.OpenAI.ProjectConversation>> UpdateProjectConversationAsync(string conversationId, Azure.AI.Extensions.OpenAI.ProjectConversationUpdateOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ProjectConversationUpdateOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ProjectConversationUpdateOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ProjectConversationUpdateOptions>
    {
        public ProjectConversationUpdateOptions() { }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        protected virtual Azure.AI.Extensions.OpenAI.ProjectConversationUpdateOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator System.ClientModel.BinaryContent (Azure.AI.Extensions.OpenAI.ProjectConversationUpdateOptions ProjectConversationUpdateOptions) { throw null; }
        protected virtual Azure.AI.Extensions.OpenAI.ProjectConversationUpdateOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.ProjectConversationUpdateOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ProjectConversationUpdateOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ProjectConversationUpdateOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.ProjectConversationUpdateOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ProjectConversationUpdateOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ProjectConversationUpdateOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ProjectConversationUpdateOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProjectFilesClient : OpenAI.Files.OpenAIFileClient
    {
        protected ProjectFilesClient() { }
    }
    public partial class ProjectOAIResponsesClientOptions : OpenAI.Responses.ResponsesClientOptions
    {
        public ProjectOAIResponsesClientOptions() { }
        public string AgentName { get { throw null; } set { } }
        public string ApiVersion { get { throw null; } set { } }
        public static implicit operator Azure.AI.Extensions.OpenAI.ProjectOAIResponsesClientOptions (Azure.AI.Extensions.OpenAI.ProjectOpenAIClientOptions source) { throw null; }
    }
    public partial class ProjectOpenAIClient : OpenAI.OpenAIClient
    {
        protected ProjectOpenAIClient() { }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("SCME0002")]
        public ProjectOpenAIClient(Azure.AI.Extensions.OpenAI.ProjectOpenAIClientSettings settings) { }
        public ProjectOpenAIClient(System.ClientModel.Primitives.AuthenticationPolicy authenticationPolicy, Azure.AI.Extensions.OpenAI.ProjectOpenAIClientOptions options) { }
        protected internal ProjectOpenAIClient(System.ClientModel.Primitives.ClientPipeline pipeline, Azure.AI.Extensions.OpenAI.ProjectOpenAIClientOptions options) { }
        public ProjectOpenAIClient(System.Uri projectEndpoint, System.ClientModel.AuthenticationTokenProvider tokenProvider, Azure.AI.Extensions.OpenAI.ProjectOpenAIClientOptions options = null) { }
        public override OpenAI.Conversations.ConversationClient GetConversationClient() { throw null; }
        public override OpenAI.Files.OpenAIFileClient GetOpenAIFileClient() { throw null; }
        public virtual Azure.AI.Extensions.OpenAI.ProjectConversationsClient GetProjectConversationsClient() { throw null; }
        public virtual Azure.AI.Extensions.OpenAI.ProjectFilesClient GetProjectFilesClient() { throw null; }
        public virtual Azure.AI.Extensions.OpenAI.ProjectResponsesClient GetProjectResponsesClient() { throw null; }
        public virtual Azure.AI.Extensions.OpenAI.ProjectResponsesClient GetProjectResponsesClientForAgent(Azure.AI.Extensions.OpenAI.AgentReference defaultAgent, string defaultConversationId = null) { throw null; }
        public virtual Azure.AI.Extensions.OpenAI.ProjectResponsesClient GetProjectResponsesClientForAgentEndpoint(string agentName, string defaultConversationId = null, Azure.AI.Extensions.OpenAI.ProjectOpenAIClientOptions options = null) { throw null; }
        public virtual Azure.AI.Extensions.OpenAI.ProjectResponsesClient GetProjectResponsesClientForModel(string defaultModel, string defaultConversationId = null) { throw null; }
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
    public partial class ProjectResponsesClient : OpenAI.Responses.ResponsesClient
    {
        protected ProjectResponsesClient() { }
        public ProjectResponsesClient(System.ClientModel.AuthenticationTokenProvider tokenProvider) { }
        public ProjectResponsesClient(System.ClientModel.AuthenticationTokenProvider tokenProvider, Azure.AI.Extensions.OpenAI.AgentReference defaultAgent, string defaultConversationId = null) { }
        public ProjectResponsesClient(System.ClientModel.AuthenticationTokenProvider tokenProvider, Azure.AI.Extensions.OpenAI.ProjectOAIResponsesClientOptions options) { }
        public ProjectResponsesClient(System.ClientModel.AuthenticationTokenProvider tokenProvider, Azure.AI.Extensions.OpenAI.ProjectOAIResponsesClientOptions options, Azure.AI.Extensions.OpenAI.AgentReference defaultAgent = null, string defaultConversationId = null) { }
        public ProjectResponsesClient(System.ClientModel.AuthenticationTokenProvider tokenProvider, Azure.AI.Extensions.OpenAI.ProjectResponsesClientOptions options) { }
        public ProjectResponsesClient(System.ClientModel.AuthenticationTokenProvider tokenProvider, Azure.AI.Extensions.OpenAI.ProjectResponsesClientOptions options = null, Azure.AI.Extensions.OpenAI.AgentReference defaultAgent = null, string defaultConversationId = null) { }
        public ProjectResponsesClient(System.Uri projectEndpoint, System.ClientModel.AuthenticationTokenProvider tokenProvider) { }
        public ProjectResponsesClient(System.Uri projectEndpoint, System.ClientModel.AuthenticationTokenProvider tokenProvider, Azure.AI.Extensions.OpenAI.AgentReference defaultAgent, string defaultConversationId = null) { }
        public ProjectResponsesClient(System.Uri projectEndpoint, System.ClientModel.AuthenticationTokenProvider tokenProvider, Azure.AI.Extensions.OpenAI.AgentReference defaultAgent, string defaultConversationId, Azure.AI.Extensions.OpenAI.ProjectOAIResponsesClientOptions options) { }
        public ProjectResponsesClient(System.Uri projectEndpoint, System.ClientModel.AuthenticationTokenProvider tokenProvider, Azure.AI.Extensions.OpenAI.AgentReference defaultAgent, string defaultConversationId = null, Azure.AI.Extensions.OpenAI.ProjectResponsesClientOptions options = null) { }
        public ProjectResponsesClient(System.Uri projectEndpoint, System.ClientModel.AuthenticationTokenProvider tokenProvider, Azure.AI.Extensions.OpenAI.ProjectOAIResponsesClientOptions options) { }
        public ProjectResponsesClient(System.Uri projectEndpoint, System.ClientModel.AuthenticationTokenProvider tokenProvider, Azure.AI.Extensions.OpenAI.ProjectResponsesClientOptions options = null) { }
        public override System.ClientModel.ClientResult<OpenAI.Responses.ResponseResult> CreateResponse(OpenAI.Responses.CreateResponseOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult<OpenAI.Responses.ResponseResult> CreateResponse(System.Collections.Generic.IEnumerable<OpenAI.Responses.ResponseItem> inputItems, string previousResponseId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.ClientModel.ClientResult<OpenAI.Responses.ResponseResult> CreateResponse(string model, System.Collections.Generic.IEnumerable<OpenAI.Responses.ResponseItem> inputItems, string previousResponseId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.ClientModel.ClientResult<OpenAI.Responses.ResponseResult> CreateResponse(string model, string userInputText, string previousResponseId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult<OpenAI.Responses.ResponseResult> CreateResponse(string userInputText, string previousResponseId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.Diagnostics.DebuggerStepThroughAttribute]
        public override System.Threading.Tasks.Task<System.ClientModel.ClientResult<OpenAI.Responses.ResponseResult>> CreateResponseAsync(OpenAI.Responses.CreateResponseOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.Diagnostics.DebuggerStepThroughAttribute]
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<OpenAI.Responses.ResponseResult>> CreateResponseAsync(System.Collections.Generic.IEnumerable<OpenAI.Responses.ResponseItem> inputItems, string previousResponseId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.Diagnostics.DebuggerStepThroughAttribute]
        public override System.Threading.Tasks.Task<System.ClientModel.ClientResult<OpenAI.Responses.ResponseResult>> CreateResponseAsync(string model, System.Collections.Generic.IEnumerable<OpenAI.Responses.ResponseItem> inputItems, string previousResponseId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual System.ClientModel.CollectionResult<OpenAI.Responses.ResponseResult> GetProjectResponses(Azure.AI.Extensions.OpenAI.AgentReference agent = null, string conversationId = null, int? limit = default(int?), string order = null, string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<OpenAI.Responses.ResponseResult> GetProjectResponsesAsync(Azure.AI.Extensions.OpenAI.AgentReference agent = null, string conversationId = null, int? limit = default(int?), string order = null, string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ProjectResponsesClientOptions : Azure.AI.Extensions.OpenAI.ProjectOpenAIClientOptions
    {
        public ProjectResponsesClientOptions() { }
    }
    public partial class ProjectVectorStoresClient : OpenAI.VectorStores.VectorStoreClient
    {
        protected ProjectVectorStoresClient() { }
    }
    public partial class ReminderPreviewTool : OpenAI.Responses.ResponseTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ReminderPreviewTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ReminderPreviewTool>
    {
        internal ReminderPreviewTool() : base (default(OpenAI.Responses.ResponseToolKind)) { }
        public string Description { get { throw null; } }
        public string Name { get { throw null; } }
        protected override OpenAI.Responses.ResponseTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override OpenAI.Responses.ResponseTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.ReminderPreviewTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ReminderPreviewTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ReminderPreviewTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.ReminderPreviewTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ReminderPreviewTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ReminderPreviewTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ReminderPreviewTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ResponseItemKindExtensions
    {
        public static OpenAI.Responses.ResponseItemKind get_A2APreviewCall() { throw null; }
        public static OpenAI.Responses.ResponseItemKind get_A2APreviewCallOutput() { throw null; }
        public static OpenAI.Responses.ResponseItemKind get_AzureAiSearchCall() { throw null; }
        public static OpenAI.Responses.ResponseItemKind get_AzureAiSearchCallOutput() { throw null; }
        public static OpenAI.Responses.ResponseItemKind get_AzureFunctionCall() { throw null; }
        public static OpenAI.Responses.ResponseItemKind get_AzureFunctionCallOutput() { throw null; }
        public static OpenAI.Responses.ResponseItemKind get_BingCustomSearchPreviewCall() { throw null; }
        public static OpenAI.Responses.ResponseItemKind get_BingCustomSearchPreviewCallOutput() { throw null; }
        public static OpenAI.Responses.ResponseItemKind get_BingGroundingCall() { throw null; }
        public static OpenAI.Responses.ResponseItemKind get_BingGroundingCallOutput() { throw null; }
        public static OpenAI.Responses.ResponseItemKind get_BrowserAutomationPreviewCall() { throw null; }
        public static OpenAI.Responses.ResponseItemKind get_BrowserAutomationPreviewCallOutput() { throw null; }
        public static OpenAI.Responses.ResponseItemKind get_FabricDataagentPreviewCall() { throw null; }
        public static OpenAI.Responses.ResponseItemKind get_FabricDataagentPreviewCallOutput() { throw null; }
        public static OpenAI.Responses.ResponseItemKind get_MemoryCommandPreviewCall() { throw null; }
        public static OpenAI.Responses.ResponseItemKind get_MemoryCommandPreviewCallOutput() { throw null; }
        public static OpenAI.Responses.ResponseItemKind get_MemorySearchCall() { throw null; }
        public static OpenAI.Responses.ResponseItemKind get_OauthConsentRequest() { throw null; }
        public static OpenAI.Responses.ResponseItemKind get_OpenapiCall() { throw null; }
        public static OpenAI.Responses.ResponseItemKind get_OpenapiCallOutput() { throw null; }
        public static OpenAI.Responses.ResponseItemKind get_SharepointGroundingPreviewCall() { throw null; }
        public static OpenAI.Responses.ResponseItemKind get_SharepointGroundingPreviewCallOutput() { throw null; }
        public static OpenAI.Responses.ResponseItemKind get_StructuredOutputs() { throw null; }
        public static OpenAI.Responses.ResponseItemKind get_WorkflowAction() { throw null; }
        public sealed partial class <G>$85D7243A15CC11DE156F995836A4C406
        {
            internal <G>$85D7243A15CC11DE156F995836A4C406() { }
            public static OpenAI.Responses.ResponseItemKind A2APreviewCall { get { throw null; } }
            public static OpenAI.Responses.ResponseItemKind A2APreviewCallOutput { get { throw null; } }
            public static OpenAI.Responses.ResponseItemKind AzureAiSearchCall { get { throw null; } }
            public static OpenAI.Responses.ResponseItemKind AzureAiSearchCallOutput { get { throw null; } }
            public static OpenAI.Responses.ResponseItemKind AzureFunctionCall { get { throw null; } }
            public static OpenAI.Responses.ResponseItemKind AzureFunctionCallOutput { get { throw null; } }
            public static OpenAI.Responses.ResponseItemKind BingCustomSearchPreviewCall { get { throw null; } }
            public static OpenAI.Responses.ResponseItemKind BingCustomSearchPreviewCallOutput { get { throw null; } }
            public static OpenAI.Responses.ResponseItemKind BingGroundingCall { get { throw null; } }
            public static OpenAI.Responses.ResponseItemKind BingGroundingCallOutput { get { throw null; } }
            public static OpenAI.Responses.ResponseItemKind BrowserAutomationPreviewCall { get { throw null; } }
            public static OpenAI.Responses.ResponseItemKind BrowserAutomationPreviewCallOutput { get { throw null; } }
            public static OpenAI.Responses.ResponseItemKind FabricDataagentPreviewCall { get { throw null; } }
            public static OpenAI.Responses.ResponseItemKind FabricDataagentPreviewCallOutput { get { throw null; } }
            public static OpenAI.Responses.ResponseItemKind MemoryCommandPreviewCall { get { throw null; } }
            public static OpenAI.Responses.ResponseItemKind MemoryCommandPreviewCallOutput { get { throw null; } }
            public static OpenAI.Responses.ResponseItemKind MemorySearchCall { get { throw null; } }
            public static OpenAI.Responses.ResponseItemKind OauthConsentRequest { get { throw null; } }
            public static OpenAI.Responses.ResponseItemKind OpenapiCall { get { throw null; } }
            public static OpenAI.Responses.ResponseItemKind OpenapiCallOutput { get { throw null; } }
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
    public enum ResponsesGrammarSyntax
    {
        Lark = 0,
        Regex = 1,
    }
    public enum ResponsesWebSearchToolSearchContextSize
    {
        Low = 0,
        Medium = 1,
        High = 2,
    }
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
    public partial class SharepointGroundingToolCall : OpenAI.Responses.ResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.SharepointGroundingToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.SharepointGroundingToolCall>
    {
        public SharepointGroundingToolCall(string callId, string arguments, Azure.AI.Extensions.OpenAI.ToolCallStatus status) : base (default(OpenAI.Responses.ResponseItemKind)) { }
        public string Arguments { get { throw null; } }
        public string CallId { get { throw null; } }
        public Azure.AI.Extensions.OpenAI.ToolCallStatus Status { get { throw null; } }
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
    public partial class SharepointGroundingToolCallOutput : OpenAI.Responses.ResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.SharepointGroundingToolCallOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.SharepointGroundingToolCallOutput>
    {
        public SharepointGroundingToolCallOutput(string callId, Azure.AI.Extensions.OpenAI.ToolCallStatus status) : base (default(OpenAI.Responses.ResponseItemKind)) { }
        public string CallId { get { throw null; } }
        public System.BinaryData Output { get { throw null; } set { } }
        public Azure.AI.Extensions.OpenAI.ToolCallStatus Status { get { throw null; } }
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
    public partial class SharepointGroundingToolParameters : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.SharepointGroundingToolParameters>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.SharepointGroundingToolParameters>
    {
        internal SharepointGroundingToolParameters() { }
        public System.Collections.Generic.IList<Azure.AI.Extensions.OpenAI.ToolProjectConnection> ProjectConnections { get { throw null; } }
        protected virtual Azure.AI.Extensions.OpenAI.SharepointGroundingToolParameters JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Extensions.OpenAI.SharepointGroundingToolParameters PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.SharepointGroundingToolParameters System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.SharepointGroundingToolParameters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.SharepointGroundingToolParameters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.SharepointGroundingToolParameters System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.SharepointGroundingToolParameters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.SharepointGroundingToolParameters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.SharepointGroundingToolParameters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SharepointPreviewTool : OpenAI.Responses.ResponseTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.SharepointPreviewTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.SharepointPreviewTool>
    {
        internal SharepointPreviewTool() : base (default(OpenAI.Responses.ResponseToolKind)) { }
        public Azure.AI.Extensions.OpenAI.SharepointGroundingToolParameters SharepointGroundingPreview { get { throw null; } }
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
    public partial class SkillReferenceParam : Azure.AI.Extensions.OpenAI.ContainerSkill, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.SkillReferenceParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.SkillReferenceParam>
    {
        public SkillReferenceParam(string skillId) { }
        public string SkillId { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        protected override Azure.AI.Extensions.OpenAI.ContainerSkill JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Extensions.OpenAI.ContainerSkill PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.SkillReferenceParam System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.SkillReferenceParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.SkillReferenceParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.SkillReferenceParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.SkillReferenceParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.SkillReferenceParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.SkillReferenceParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StructuredOutputDefinition : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.StructuredOutputDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.StructuredOutputDefinition>
    {
        internal StructuredOutputDefinition() { }
        public string Description { get { throw null; } }
        public bool? IsStrict { get { throw null; } }
        public string Name { get { throw null; } }
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
        internal ToolConfig() { }
        public string AdditionalSearchText { get { throw null; } }
        public bool? Pin { get { throw null; } }
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
        internal ToolProjectConnection() { }
        public string ProjectConnectionId { get { throw null; } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ToolSearchExecutionType : System.IEquatable<Azure.AI.Extensions.OpenAI.ToolSearchExecutionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ToolSearchExecutionType(string value) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ToolSearchExecutionType Client { get { throw null; } }
        public static Azure.AI.Extensions.OpenAI.ToolSearchExecutionType Server { get { throw null; } }
        public bool Equals(Azure.AI.Extensions.OpenAI.ToolSearchExecutionType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Extensions.OpenAI.ToolSearchExecutionType left, Azure.AI.Extensions.OpenAI.ToolSearchExecutionType right) { throw null; }
        public static implicit operator Azure.AI.Extensions.OpenAI.ToolSearchExecutionType (string value) { throw null; }
        public static implicit operator Azure.AI.Extensions.OpenAI.ToolSearchExecutionType? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Extensions.OpenAI.ToolSearchExecutionType left, Azure.AI.Extensions.OpenAI.ToolSearchExecutionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ToolSearchToolParam : OpenAI.Responses.ResponseTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ToolSearchToolParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ToolSearchToolParam>
    {
        internal ToolSearchToolParam() : base (default(OpenAI.Responses.ResponseToolKind)) { }
        public string Description { get { throw null; } }
        public Azure.AI.Extensions.OpenAI.ToolSearchExecutionType? Execution { get { throw null; } }
        public Azure.AI.Extensions.OpenAI.EmptyModelParam Parameters { get { throw null; } }
        protected override OpenAI.Responses.ResponseTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override OpenAI.Responses.ResponseTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.ToolSearchToolParam System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ToolSearchToolParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ToolSearchToolParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.ToolSearchToolParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ToolSearchToolParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ToolSearchToolParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ToolSearchToolParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
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
    public partial class WebSearchApproximateLocation : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.WebSearchApproximateLocation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.WebSearchApproximateLocation>
    {
        internal WebSearchApproximateLocation() { }
        public string City { get { throw null; } }
        public string Country { get { throw null; } }
        public string Region { get { throw null; } }
        public string Timezone { get { throw null; } }
        protected virtual Azure.AI.Extensions.OpenAI.WebSearchApproximateLocation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Extensions.OpenAI.WebSearchApproximateLocation PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.WebSearchApproximateLocation System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.WebSearchApproximateLocation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.WebSearchApproximateLocation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.WebSearchApproximateLocation System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.WebSearchApproximateLocation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.WebSearchApproximateLocation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.WebSearchApproximateLocation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WebSearchConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.WebSearchConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.WebSearchConfiguration>
    {
        internal WebSearchConfiguration() { }
        public string InstanceName { get { throw null; } }
        public string ProjectConnectionId { get { throw null; } }
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
    public partial class WorkIQPreviewTool : OpenAI.Responses.ResponseTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.WorkIQPreviewTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.WorkIQPreviewTool>
    {
        internal WorkIQPreviewTool() : base (default(OpenAI.Responses.ResponseToolKind)) { }
        public string ProjectConnectionId { get { throw null; } }
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
namespace Azure.AI.Extensions.OpenAI.Internal
{
    public partial class InputFileContentParam : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.Internal.InputFileContentParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.Internal.InputFileContentParam>
    {
        internal InputFileContentParam() { }
        public string FileData { get { throw null; } }
        public string FileId { get { throw null; } }
        public string Filename { get { throw null; } }
        public System.Uri FileUrl { get { throw null; } }
        protected virtual Azure.AI.Extensions.OpenAI.Internal.InputFileContentParam JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Extensions.OpenAI.Internal.InputFileContentParam PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.Internal.InputFileContentParam System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.Internal.InputFileContentParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.Internal.InputFileContentParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.Internal.InputFileContentParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.Internal.InputFileContentParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.Internal.InputFileContentParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.Internal.InputFileContentParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
