namespace Azure.AI.Extensions.OpenAI
{
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
    public partial class BrowserAutomationToolCall : OpenAI.Responses.ResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.BrowserAutomationToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BrowserAutomationToolCall>
    {
        internal BrowserAutomationToolCall() : base (default(OpenAI.Responses.ResponseItemKind)) { }
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
    public partial class BrowserAutomationToolCallOutput : OpenAI.Responses.ResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.BrowserAutomationToolCallOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BrowserAutomationToolCallOutput>
    {
        internal BrowserAutomationToolCallOutput() : base (default(OpenAI.Responses.ResponseItemKind)) { }
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
    public partial class CustomGrammarFormatParam : Azure.AI.Extensions.OpenAI.ResponsesCustomToolParamFormat, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.CustomGrammarFormatParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.CustomGrammarFormatParam>
    {
        public CustomGrammarFormatParam(Azure.AI.Extensions.OpenAI.ResponsesGrammarSyntax syntax, string definition) { }
        public string Definition { get { throw null; } set { } }
        public Azure.AI.Extensions.OpenAI.ResponsesGrammarSyntax Syntax { get { throw null; } set { } }
        protected override Azure.AI.Extensions.OpenAI.ResponsesCustomToolParamFormat JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Extensions.OpenAI.ResponsesCustomToolParamFormat PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.CustomGrammarFormatParam System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.CustomGrammarFormatParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.CustomGrammarFormatParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.CustomGrammarFormatParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.CustomGrammarFormatParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.CustomGrammarFormatParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.CustomGrammarFormatParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ExtensionsOpenAIModelFactory
    {
        public static Azure.AI.Extensions.OpenAI.A2AToolCall A2AToolCall(OpenAI.Responses.ResponseItemKind type = default(OpenAI.Responses.ResponseItemKind), string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, string name = null, string arguments = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        public static Azure.AI.Extensions.OpenAI.A2AToolCallOutput A2AToolCallOutput(OpenAI.Responses.ResponseItemKind type = default(OpenAI.Responses.ResponseItemKind), string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, string name = null, System.BinaryData output = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        public static Azure.AI.Extensions.OpenAI.AgentReference AgentReference(string name = null, string version = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.AgentStructuredOutputsResponseItem AgentStructuredOutputsResponseItem(OpenAI.Responses.ResponseItemKind type = default(OpenAI.Responses.ResponseItemKind), string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, System.BinaryData output = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.AgentWorkflowPreviewActionResponseItem AgentWorkflowPreviewActionResponseItem(OpenAI.Responses.ResponseItemKind type = default(OpenAI.Responses.ResponseItemKind), string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string csdlActionKind = null, string actionId = null, string parentActionId = null, string previousActionId = null, Azure.AI.Extensions.OpenAI.AgentWorkflowPreviewActionStatus? status = default(Azure.AI.Extensions.OpenAI.AgentWorkflowPreviewActionStatus?)) { throw null; }
        public static Azure.AI.Extensions.OpenAI.AzureAISearchToolCall AzureAISearchToolCall(OpenAI.Responses.ResponseItemKind type = default(OpenAI.Responses.ResponseItemKind), string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, string arguments = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        public static Azure.AI.Extensions.OpenAI.AzureAISearchToolCallOutput AzureAISearchToolCallOutput(OpenAI.Responses.ResponseItemKind type = default(OpenAI.Responses.ResponseItemKind), string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, System.BinaryData output = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        public static Azure.AI.Extensions.OpenAI.AzureFunctionToolCall AzureFunctionToolCall(OpenAI.Responses.ResponseItemKind type = default(OpenAI.Responses.ResponseItemKind), string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, string name = null, string arguments = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        public static Azure.AI.Extensions.OpenAI.AzureFunctionToolCallOutput AzureFunctionToolCallOutput(OpenAI.Responses.ResponseItemKind type = default(OpenAI.Responses.ResponseItemKind), string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, string name = null, System.BinaryData output = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        public static Azure.AI.Extensions.OpenAI.BingCustomSearchToolCall BingCustomSearchToolCall(OpenAI.Responses.ResponseItemKind type = default(OpenAI.Responses.ResponseItemKind), string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, string arguments = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        public static Azure.AI.Extensions.OpenAI.BingCustomSearchToolCallOutput BingCustomSearchToolCallOutput(OpenAI.Responses.ResponseItemKind type = default(OpenAI.Responses.ResponseItemKind), string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, System.BinaryData output = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        public static Azure.AI.Extensions.OpenAI.BingGroundingToolCall BingGroundingToolCall(OpenAI.Responses.ResponseItemKind type = default(OpenAI.Responses.ResponseItemKind), string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, string arguments = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        public static Azure.AI.Extensions.OpenAI.BingGroundingToolCallOutput BingGroundingToolCallOutput(OpenAI.Responses.ResponseItemKind type = default(OpenAI.Responses.ResponseItemKind), string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, System.BinaryData output = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        public static Azure.AI.Extensions.OpenAI.BrowserAutomationToolCall BrowserAutomationToolCall(OpenAI.Responses.ResponseItemKind type = default(OpenAI.Responses.ResponseItemKind), string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, string arguments = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        public static Azure.AI.Extensions.OpenAI.BrowserAutomationToolCallOutput BrowserAutomationToolCallOutput(OpenAI.Responses.ResponseItemKind type = default(OpenAI.Responses.ResponseItemKind), string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, System.BinaryData output = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ChatSummaryMemoryItem ChatSummaryMemoryItem(string memoryId = null, System.DateTimeOffset updatedAt = default(System.DateTimeOffset), string scope = null, string content = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ContainerSkill ContainerSkill(string type = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.CustomGrammarFormatParam CustomGrammarFormatParam(Azure.AI.Extensions.OpenAI.ResponsesGrammarSyntax syntax = Azure.AI.Extensions.OpenAI.ResponsesGrammarSyntax.Lark, string definition = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.FabricDataAgentToolCall FabricDataAgentToolCall(OpenAI.Responses.ResponseItemKind type = default(OpenAI.Responses.ResponseItemKind), string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, string arguments = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        public static Azure.AI.Extensions.OpenAI.FabricDataAgentToolCallOutput FabricDataAgentToolCallOutput(OpenAI.Responses.ResponseItemKind type = default(OpenAI.Responses.ResponseItemKind), string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, System.BinaryData output = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        public static Azure.AI.Extensions.OpenAI.Internal.InputFileContentParam InputFileContentParam(string fileId = null, string filename = null, string fileData = null, System.Uri fileUrl = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.LocalSkillParam LocalSkillParam(string name = null, string description = null, string path = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.MemoryCommandToolCall MemoryCommandToolCall(OpenAI.Responses.ResponseItemKind type = default(OpenAI.Responses.ResponseItemKind), string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, string arguments = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        public static Azure.AI.Extensions.OpenAI.MemoryCommandToolCallOutput MemoryCommandToolCallOutput(OpenAI.Responses.ResponseItemKind type = default(OpenAI.Responses.ResponseItemKind), string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        public static Azure.AI.Extensions.OpenAI.MemoryOutputItem MemoryOutputItem(string memoryId = null, System.DateTimeOffset updatedAt = default(System.DateTimeOffset), string scope = null, string content = null, string kind = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.MemorySearchToolCall MemorySearchToolCall(OpenAI.Responses.ResponseItemKind type = default(OpenAI.Responses.ResponseItemKind), string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress, System.Collections.Generic.IEnumerable<Azure.AI.Extensions.OpenAI.MemoryOutputItem> memories = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.OAuthConsentRequestResponseItem OAuthConsentRequestResponseItem(OpenAI.Responses.ResponseItemKind type = default(OpenAI.Responses.ResponseItemKind), string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string internalConsentLink = null, string serverLabel = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.OpenApiToolCall OpenApiToolCall(OpenAI.Responses.ResponseItemKind type = default(OpenAI.Responses.ResponseItemKind), string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, string name = null, string arguments = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        public static Azure.AI.Extensions.OpenAI.OpenApiToolCallOutput OpenApiToolCallOutput(OpenAI.Responses.ResponseItemKind type = default(OpenAI.Responses.ResponseItemKind), string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, string name = null, System.BinaryData output = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ProceduralMemoryItem ProceduralMemoryItem(string memoryId = null, System.DateTimeOffset updatedAt = default(System.DateTimeOffset), string scope = null, string content = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ProjectConversation ProjectConversation(string id = null, System.Collections.Generic.IDictionary<string, string> metadata = null, System.DateTimeOffset createdAt = default(System.DateTimeOffset)) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesA2APreviewTool ResponsesA2APreviewTool(System.Uri baseUri = null, string agentCardPath = null, string projectConnectionId = null, bool? sendCredentialsForAgentCard = default(bool?)) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesAISearchIndexResource ResponsesAISearchIndexResource(string projectConnectionId = null, string indexName = null, Azure.AI.Extensions.OpenAI.ResponsesAzureAISearchQueryKind? queryType = default(Azure.AI.Extensions.OpenAI.ResponsesAzureAISearchQueryKind?), int? topK = default(int?), string filter = null, string indexAssetId = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesAutoCodeInterpreterToolParam ResponsesAutoCodeInterpreterToolParam(System.Collections.Generic.IEnumerable<string> fileIds = null, Azure.AI.Extensions.OpenAI.ResponsesContainerMemoryLimit? memoryLimit = default(Azure.AI.Extensions.OpenAI.ResponsesContainerMemoryLimit?), Azure.AI.Extensions.OpenAI.ResponsesContainerNetworkPolicyParam networkPolicy = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesAzureAISearchTool ResponsesAzureAISearchTool(string name = null, string description = null, System.Collections.Generic.IDictionary<string, Azure.AI.Extensions.OpenAI.ToolConfig> toolConfigs = null, Azure.AI.Extensions.OpenAI.ResponsesAzureAISearchToolResource azureAISearch = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesAzureAISearchToolResource ResponsesAzureAISearchToolResource(System.Collections.Generic.IEnumerable<Azure.AI.Extensions.OpenAI.ResponsesAISearchIndexResource> indexes = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesAzureFunctionBinding ResponsesAzureFunctionBinding(Azure.AI.Extensions.OpenAI.ResponsesAzureFunctionStorageQueue storageQueue = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesAzureFunctionDefinition ResponsesAzureFunctionDefinition(Azure.AI.Extensions.OpenAI.ResponsesAzureFunctionDefinitionFunction function = null, Azure.AI.Extensions.OpenAI.ResponsesAzureFunctionBinding inputBinding = null, Azure.AI.Extensions.OpenAI.ResponsesAzureFunctionBinding outputBinding = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesAzureFunctionDefinitionFunction ResponsesAzureFunctionDefinitionFunction(string name = null, string description = null, System.Collections.Generic.IDictionary<string, System.BinaryData> parameters = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesAzureFunctionStorageQueue ResponsesAzureFunctionStorageQueue(string queueServiceEndpoint = null, string queueName = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesAzureFunctionTool ResponsesAzureFunctionTool(System.Collections.Generic.IDictionary<string, Azure.AI.Extensions.OpenAI.ToolConfig> toolConfigs = null, Azure.AI.Extensions.OpenAI.ResponsesAzureFunctionDefinition azureFunction = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesBingCustomSearchConfiguration ResponsesBingCustomSearchConfiguration(string projectConnectionId = null, string instanceName = null, string market = null, string setLang = null, long? count = default(long?), string freshness = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesBingCustomSearchPreviewTool ResponsesBingCustomSearchPreviewTool(Azure.AI.Extensions.OpenAI.ResponsesBingCustomSearchToolParameters bingCustomSearchPreview = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesBingCustomSearchToolParameters ResponsesBingCustomSearchToolParameters(System.Collections.Generic.IEnumerable<Azure.AI.Extensions.OpenAI.ResponsesBingCustomSearchConfiguration> searchConfigurations = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesBingGroundingSearchConfiguration ResponsesBingGroundingSearchConfiguration(string projectConnectionId = null, string market = null, string language = null, long? count = default(long?), string freshness = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesBingGroundingSearchToolParameters ResponsesBingGroundingSearchToolParameters(System.Collections.Generic.IEnumerable<Azure.AI.Extensions.OpenAI.ResponsesBingGroundingSearchConfiguration> searchConfigurations = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesBingGroundingTool ResponsesBingGroundingTool(string name = null, string description = null, System.Collections.Generic.IDictionary<string, Azure.AI.Extensions.OpenAI.ToolConfig> toolConfigs = null, Azure.AI.Extensions.OpenAI.ResponsesBingGroundingSearchToolParameters bingGrounding = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesBrowserAutomationPreviewTool ResponsesBrowserAutomationPreviewTool(Azure.AI.Extensions.OpenAI.ResponsesBrowserAutomationToolParameters browserAutomationPreview = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesBrowserAutomationToolConnectionParameters ResponsesBrowserAutomationToolConnectionParameters(string projectConnectionId = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesBrowserAutomationToolParameters ResponsesBrowserAutomationToolParameters(Azure.AI.Extensions.OpenAI.ResponsesBrowserAutomationToolConnectionParameters connection = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesCaptureStructuredOutputsTool ResponsesCaptureStructuredOutputsTool(string name = null, string description = null, System.Collections.Generic.IDictionary<string, Azure.AI.Extensions.OpenAI.ToolConfig> toolConfigs = null, Azure.AI.Extensions.OpenAI.ResponsesStructuredOutputDefinition outputDefinition = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesContainerAutoParam ResponsesContainerAutoParam(System.Collections.Generic.IEnumerable<string> fileIds = null, Azure.AI.Extensions.OpenAI.ResponsesContainerMemoryLimit? memoryLimit = default(Azure.AI.Extensions.OpenAI.ResponsesContainerMemoryLimit?), System.Collections.Generic.IEnumerable<Azure.AI.Extensions.OpenAI.ContainerSkill> skills = null, Azure.AI.Extensions.OpenAI.ResponsesContainerNetworkPolicyParam networkPolicy = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesContainerNetworkPolicyAllowlistParam ResponsesContainerNetworkPolicyAllowlistParam(System.Collections.Generic.IEnumerable<string> allowedDomains = null, System.Collections.Generic.IEnumerable<Azure.AI.Extensions.OpenAI.ResponsesContainerNetworkPolicyDomainSecretParam> domainSecrets = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesContainerNetworkPolicyDisabledParam ResponsesContainerNetworkPolicyDisabledParam() { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesContainerNetworkPolicyDomainSecretParam ResponsesContainerNetworkPolicyDomainSecretParam(string domain = null, string name = null, string value = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesContainerNetworkPolicyParam ResponsesContainerNetworkPolicyParam(string type = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesCustomTextFormatParam ResponsesCustomTextFormatParam() { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesCustomToolParam ResponsesCustomToolParam(string name = null, string description = null, Azure.AI.Extensions.OpenAI.ResponsesCustomToolParamFormat format = null, bool? shouldDeferLoading = default(bool?)) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesCustomToolParamFormat ResponsesCustomToolParamFormat(string type = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesEmptyModelParam ResponsesEmptyModelParam() { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesFabricDataAgentToolOptions ResponsesFabricDataAgentToolOptions(System.Collections.Generic.IEnumerable<Azure.AI.Extensions.OpenAI.ResponsesToolProjectConnection> projectConnections = null) { throw null; }
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
        public static Azure.AI.Extensions.OpenAI.ResponsesMemorySearchOptions ResponsesMemorySearchOptions(int? maxMemories = default(int?)) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesMemorySearchPreviewTool ResponsesMemorySearchPreviewTool(string memoryStoreName = null, string scope = null, Azure.AI.Extensions.OpenAI.ResponsesMemorySearchOptions searchOptions = null, int? updateDelayInSeconds = default(int?)) { throw null; }
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
        public static Azure.AI.Extensions.OpenAI.ResponsesReminderPreviewTool ResponsesReminderPreviewTool(string name = null, string description = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesSharepointGroundingToolParameters ResponsesSharepointGroundingToolParameters(System.Collections.Generic.IEnumerable<Azure.AI.Extensions.OpenAI.ResponsesToolProjectConnection> projectConnections = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesSharepointPreviewTool ResponsesSharepointPreviewTool(Azure.AI.Extensions.OpenAI.ResponsesSharepointGroundingToolParameters sharepointGroundingPreview = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesSkillReferenceParam ResponsesSkillReferenceParam(string skillId = null, string version = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesStructuredOutputDefinition ResponsesStructuredOutputDefinition(string name = null, string description = null, System.Collections.Generic.IDictionary<string, System.BinaryData> schema = null, bool? isStrict = default(bool?)) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesToolProjectConnection ResponsesToolProjectConnection(string projectConnectionId = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesToolSearchToolParam ResponsesToolSearchToolParam(Azure.AI.Extensions.OpenAI.ResponsesToolSearchExecutionType? execution = default(Azure.AI.Extensions.OpenAI.ResponsesToolSearchExecutionType?), string description = null, Azure.AI.Extensions.OpenAI.ResponsesEmptyModelParam parameters = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesWebSearchApproximateLocation ResponsesWebSearchApproximateLocation(string country = null, string region = null, string city = null, string timezone = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesWebSearchConfiguration ResponsesWebSearchConfiguration(string projectConnectionId = null, string instanceName = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesWorkIQPreviewTool ResponsesWorkIQPreviewTool(string projectConnectionId = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.SharepointGroundingToolCall SharepointGroundingToolCall(OpenAI.Responses.ResponseItemKind type = default(OpenAI.Responses.ResponseItemKind), string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, string arguments = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        public static Azure.AI.Extensions.OpenAI.SharepointGroundingToolCallOutput SharepointGroundingToolCallOutput(OpenAI.Responses.ResponseItemKind type = default(OpenAI.Responses.ResponseItemKind), string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, System.BinaryData output = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ToolConfig ToolConfig(bool? pin = default(bool?), string additionalSearchText = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.UserProfileMemoryItem UserProfileMemoryItem(string memoryId = null, System.DateTimeOffset updatedAt = default(System.DateTimeOffset), string scope = null, string content = null) { throw null; }
    }
    public partial class FabricDataAgentToolCall : OpenAI.Responses.ResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.FabricDataAgentToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.FabricDataAgentToolCall>
    {
        internal FabricDataAgentToolCall() : base (default(OpenAI.Responses.ResponseItemKind)) { }
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
    public partial class FabricDataAgentToolCallOutput : OpenAI.Responses.ResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.FabricDataAgentToolCallOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.FabricDataAgentToolCallOutput>
    {
        internal FabricDataAgentToolCallOutput() : base (default(OpenAI.Responses.ResponseItemKind)) { }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ItemFieldComputerToolCallOutputStatus : System.IEquatable<Azure.AI.Extensions.OpenAI.ItemFieldComputerToolCallOutputStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ItemFieldComputerToolCallOutputStatus(string value) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ItemFieldComputerToolCallOutputStatus Completed { get { throw null; } }
        public static Azure.AI.Extensions.OpenAI.ItemFieldComputerToolCallOutputStatus Incomplete { get { throw null; } }
        public static Azure.AI.Extensions.OpenAI.ItemFieldComputerToolCallOutputStatus InProgress { get { throw null; } }
        public bool Equals(Azure.AI.Extensions.OpenAI.ItemFieldComputerToolCallOutputStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Extensions.OpenAI.ItemFieldComputerToolCallOutputStatus left, Azure.AI.Extensions.OpenAI.ItemFieldComputerToolCallOutputStatus right) { throw null; }
        public static implicit operator Azure.AI.Extensions.OpenAI.ItemFieldComputerToolCallOutputStatus (string value) { throw null; }
        public static implicit operator Azure.AI.Extensions.OpenAI.ItemFieldComputerToolCallOutputStatus? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Extensions.OpenAI.ItemFieldComputerToolCallOutputStatus left, Azure.AI.Extensions.OpenAI.ItemFieldComputerToolCallOutputStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ItemFieldFunctionToolCallOutputStatus : System.IEquatable<Azure.AI.Extensions.OpenAI.ItemFieldFunctionToolCallOutputStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ItemFieldFunctionToolCallOutputStatus(string value) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ItemFieldFunctionToolCallOutputStatus Completed { get { throw null; } }
        public static Azure.AI.Extensions.OpenAI.ItemFieldFunctionToolCallOutputStatus Incomplete { get { throw null; } }
        public static Azure.AI.Extensions.OpenAI.ItemFieldFunctionToolCallOutputStatus InProgress { get { throw null; } }
        public bool Equals(Azure.AI.Extensions.OpenAI.ItemFieldFunctionToolCallOutputStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Extensions.OpenAI.ItemFieldFunctionToolCallOutputStatus left, Azure.AI.Extensions.OpenAI.ItemFieldFunctionToolCallOutputStatus right) { throw null; }
        public static implicit operator Azure.AI.Extensions.OpenAI.ItemFieldFunctionToolCallOutputStatus (string value) { throw null; }
        public static implicit operator Azure.AI.Extensions.OpenAI.ItemFieldFunctionToolCallOutputStatus? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Extensions.OpenAI.ItemFieldFunctionToolCallOutputStatus left, Azure.AI.Extensions.OpenAI.ItemFieldFunctionToolCallOutputStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ItemLocalShellToolCallOutputStatus : System.IEquatable<Azure.AI.Extensions.OpenAI.ItemLocalShellToolCallOutputStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ItemLocalShellToolCallOutputStatus(string value) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ItemLocalShellToolCallOutputStatus Completed { get { throw null; } }
        public static Azure.AI.Extensions.OpenAI.ItemLocalShellToolCallOutputStatus Incomplete { get { throw null; } }
        public static Azure.AI.Extensions.OpenAI.ItemLocalShellToolCallOutputStatus InProgress { get { throw null; } }
        public bool Equals(Azure.AI.Extensions.OpenAI.ItemLocalShellToolCallOutputStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Extensions.OpenAI.ItemLocalShellToolCallOutputStatus left, Azure.AI.Extensions.OpenAI.ItemLocalShellToolCallOutputStatus right) { throw null; }
        public static implicit operator Azure.AI.Extensions.OpenAI.ItemLocalShellToolCallOutputStatus (string value) { throw null; }
        public static implicit operator Azure.AI.Extensions.OpenAI.ItemLocalShellToolCallOutputStatus? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Extensions.OpenAI.ItemLocalShellToolCallOutputStatus left, Azure.AI.Extensions.OpenAI.ItemLocalShellToolCallOutputStatus right) { throw null; }
        public override string ToString() { throw null; }
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
    public partial class MemoryCommandToolCall : OpenAI.Responses.ResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.MemoryCommandToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.MemoryCommandToolCall>
    {
        internal MemoryCommandToolCall() : base (default(OpenAI.Responses.ResponseItemKind)) { }
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
    public partial class MemoryCommandToolCallOutput : OpenAI.Responses.ResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.MemoryCommandToolCallOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.MemoryCommandToolCallOutput>
    {
        internal MemoryCommandToolCallOutput() : base (default(OpenAI.Responses.ResponseItemKind)) { }
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
    public partial class MemorySearchToolCall : OpenAI.Responses.ResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.MemorySearchToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.MemorySearchToolCall>
    {
        internal MemorySearchToolCall() : base (default(OpenAI.Responses.ResponseItemKind)) { }
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
    public partial class OAuthConsentRequestResponseItem : OpenAI.Responses.ResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.OAuthConsentRequestResponseItem>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.OAuthConsentRequestResponseItem>
    {
        public OAuthConsentRequestResponseItem(string consentLink, string serverLabel) : base (default(OpenAI.Responses.ResponseItemKind)) { }
        public OAuthConsentRequestResponseItem(System.Uri consentLink, string serverLabel) : base (default(OpenAI.Responses.ResponseItemKind)) { }
        public System.Uri ConsentLink { get { throw null; } }
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
    public partial class OpenApiToolCall : OpenAI.Responses.ResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.OpenApiToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.OpenApiToolCall>
    {
        internal OpenApiToolCall() : base (default(OpenAI.Responses.ResponseItemKind)) { }
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
    public partial class OpenApiToolCallOutput : OpenAI.Responses.ResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.OpenApiToolCallOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.OpenApiToolCallOutput>
    {
        internal OpenApiToolCallOutput() : base (default(OpenAI.Responses.ResponseItemKind)) { }
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
    public partial class ResponsesA2APreviewTool : OpenAI.Responses.ResponseTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesA2APreviewTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesA2APreviewTool>
    {
        public ResponsesA2APreviewTool() : base (default(OpenAI.Responses.ResponseToolKind)) { }
        public string AgentCardPath { get { throw null; } set { } }
        public System.Uri BaseUri { get { throw null; } set { } }
        public string ProjectConnectionId { get { throw null; } set { } }
        public bool? SendCredentialsForAgentCard { get { throw null; } set { } }
        protected override OpenAI.Responses.ResponseTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override OpenAI.Responses.ResponseTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.ResponsesA2APreviewTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesA2APreviewTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesA2APreviewTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.ResponsesA2APreviewTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesA2APreviewTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesA2APreviewTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesA2APreviewTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResponsesAISearchIndexResource : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesAISearchIndexResource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesAISearchIndexResource>
    {
        public ResponsesAISearchIndexResource() { }
        public string Filter { get { throw null; } set { } }
        public string IndexAssetId { get { throw null; } set { } }
        public string IndexName { get { throw null; } set { } }
        public string ProjectConnectionId { get { throw null; } set { } }
        public Azure.AI.Extensions.OpenAI.ResponsesAzureAISearchQueryKind? QueryType { get { throw null; } set { } }
        public int? TopK { get { throw null; } set { } }
        protected virtual Azure.AI.Extensions.OpenAI.ResponsesAISearchIndexResource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Extensions.OpenAI.ResponsesAISearchIndexResource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.ResponsesAISearchIndexResource System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesAISearchIndexResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesAISearchIndexResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.ResponsesAISearchIndexResource System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesAISearchIndexResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesAISearchIndexResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesAISearchIndexResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResponsesAutoCodeInterpreterToolParam : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesAutoCodeInterpreterToolParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesAutoCodeInterpreterToolParam>
    {
        internal ResponsesAutoCodeInterpreterToolParam() { }
        public System.Collections.Generic.IList<string> FileIds { get { throw null; } }
        public Azure.AI.Extensions.OpenAI.ResponsesContainerMemoryLimit? MemoryLimit { get { throw null; } }
        public Azure.AI.Extensions.OpenAI.ResponsesContainerNetworkPolicyParam NetworkPolicy { get { throw null; } }
        protected virtual Azure.AI.Extensions.OpenAI.ResponsesAutoCodeInterpreterToolParam JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Extensions.OpenAI.ResponsesAutoCodeInterpreterToolParam PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.ResponsesAutoCodeInterpreterToolParam System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesAutoCodeInterpreterToolParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesAutoCodeInterpreterToolParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.ResponsesAutoCodeInterpreterToolParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesAutoCodeInterpreterToolParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesAutoCodeInterpreterToolParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesAutoCodeInterpreterToolParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResponsesAzureAISearchQueryKind : System.IEquatable<Azure.AI.Extensions.OpenAI.ResponsesAzureAISearchQueryKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResponsesAzureAISearchQueryKind(string value) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesAzureAISearchQueryKind Semantic { get { throw null; } }
        public static Azure.AI.Extensions.OpenAI.ResponsesAzureAISearchQueryKind Simple { get { throw null; } }
        public static Azure.AI.Extensions.OpenAI.ResponsesAzureAISearchQueryKind Vector { get { throw null; } }
        public static Azure.AI.Extensions.OpenAI.ResponsesAzureAISearchQueryKind VectorSemanticHybrid { get { throw null; } }
        public static Azure.AI.Extensions.OpenAI.ResponsesAzureAISearchQueryKind VectorSimpleHybrid { get { throw null; } }
        public bool Equals(Azure.AI.Extensions.OpenAI.ResponsesAzureAISearchQueryKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Extensions.OpenAI.ResponsesAzureAISearchQueryKind left, Azure.AI.Extensions.OpenAI.ResponsesAzureAISearchQueryKind right) { throw null; }
        public static implicit operator Azure.AI.Extensions.OpenAI.ResponsesAzureAISearchQueryKind (string value) { throw null; }
        public static implicit operator Azure.AI.Extensions.OpenAI.ResponsesAzureAISearchQueryKind? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Extensions.OpenAI.ResponsesAzureAISearchQueryKind left, Azure.AI.Extensions.OpenAI.ResponsesAzureAISearchQueryKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResponsesAzureAISearchTool : OpenAI.Responses.ResponseTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesAzureAISearchTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesAzureAISearchTool>
    {
        internal ResponsesAzureAISearchTool() : base (default(OpenAI.Responses.ResponseToolKind)) { }
        public Azure.AI.Extensions.OpenAI.ResponsesAzureAISearchToolResource AzureAISearch { get { throw null; } }
        public string Description { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.AI.Extensions.OpenAI.ToolConfig> ToolConfigs { get { throw null; } }
        protected override OpenAI.Responses.ResponseTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override OpenAI.Responses.ResponseTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.ResponsesAzureAISearchTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesAzureAISearchTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesAzureAISearchTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.ResponsesAzureAISearchTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesAzureAISearchTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesAzureAISearchTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesAzureAISearchTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResponsesAzureAISearchToolResource : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesAzureAISearchToolResource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesAzureAISearchToolResource>
    {
        internal ResponsesAzureAISearchToolResource() { }
        public System.Collections.Generic.IList<Azure.AI.Extensions.OpenAI.ResponsesAISearchIndexResource> Indexes { get { throw null; } }
        protected virtual Azure.AI.Extensions.OpenAI.ResponsesAzureAISearchToolResource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Extensions.OpenAI.ResponsesAzureAISearchToolResource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.ResponsesAzureAISearchToolResource System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesAzureAISearchToolResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesAzureAISearchToolResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.ResponsesAzureAISearchToolResource System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesAzureAISearchToolResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesAzureAISearchToolResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesAzureAISearchToolResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResponsesAzureFunctionBinding : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesAzureFunctionBinding>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesAzureFunctionBinding>
    {
        internal ResponsesAzureFunctionBinding() { }
        public Azure.AI.Extensions.OpenAI.ResponsesAzureFunctionStorageQueue StorageQueue { get { throw null; } }
        protected virtual Azure.AI.Extensions.OpenAI.ResponsesAzureFunctionBinding JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Extensions.OpenAI.ResponsesAzureFunctionBinding PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.ResponsesAzureFunctionBinding System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesAzureFunctionBinding>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesAzureFunctionBinding>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.ResponsesAzureFunctionBinding System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesAzureFunctionBinding>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesAzureFunctionBinding>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesAzureFunctionBinding>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResponsesAzureFunctionDefinition : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesAzureFunctionDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesAzureFunctionDefinition>
    {
        internal ResponsesAzureFunctionDefinition() { }
        public Azure.AI.Extensions.OpenAI.ResponsesAzureFunctionDefinitionFunction Function { get { throw null; } }
        public Azure.AI.Extensions.OpenAI.ResponsesAzureFunctionBinding InputBinding { get { throw null; } }
        public Azure.AI.Extensions.OpenAI.ResponsesAzureFunctionBinding OutputBinding { get { throw null; } }
        protected virtual Azure.AI.Extensions.OpenAI.ResponsesAzureFunctionDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Extensions.OpenAI.ResponsesAzureFunctionDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.ResponsesAzureFunctionDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesAzureFunctionDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesAzureFunctionDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.ResponsesAzureFunctionDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesAzureFunctionDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesAzureFunctionDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesAzureFunctionDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResponsesAzureFunctionDefinitionFunction : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesAzureFunctionDefinitionFunction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesAzureFunctionDefinitionFunction>
    {
        internal ResponsesAzureFunctionDefinitionFunction() { }
        public string Description { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Parameters { get { throw null; } }
        protected virtual Azure.AI.Extensions.OpenAI.ResponsesAzureFunctionDefinitionFunction JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Extensions.OpenAI.ResponsesAzureFunctionDefinitionFunction PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.ResponsesAzureFunctionDefinitionFunction System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesAzureFunctionDefinitionFunction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesAzureFunctionDefinitionFunction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.ResponsesAzureFunctionDefinitionFunction System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesAzureFunctionDefinitionFunction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesAzureFunctionDefinitionFunction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesAzureFunctionDefinitionFunction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResponsesAzureFunctionStorageQueue : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesAzureFunctionStorageQueue>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesAzureFunctionStorageQueue>
    {
        internal ResponsesAzureFunctionStorageQueue() { }
        public string QueueName { get { throw null; } }
        public string QueueServiceEndpoint { get { throw null; } }
        protected virtual Azure.AI.Extensions.OpenAI.ResponsesAzureFunctionStorageQueue JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Extensions.OpenAI.ResponsesAzureFunctionStorageQueue PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.ResponsesAzureFunctionStorageQueue System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesAzureFunctionStorageQueue>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesAzureFunctionStorageQueue>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.ResponsesAzureFunctionStorageQueue System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesAzureFunctionStorageQueue>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesAzureFunctionStorageQueue>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesAzureFunctionStorageQueue>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResponsesAzureFunctionTool : OpenAI.Responses.ResponseTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesAzureFunctionTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesAzureFunctionTool>
    {
        internal ResponsesAzureFunctionTool() : base (default(OpenAI.Responses.ResponseToolKind)) { }
        public Azure.AI.Extensions.OpenAI.ResponsesAzureFunctionDefinition AzureFunction { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.AI.Extensions.OpenAI.ToolConfig> ToolConfigs { get { throw null; } }
        protected override OpenAI.Responses.ResponseTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override OpenAI.Responses.ResponseTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.ResponsesAzureFunctionTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesAzureFunctionTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesAzureFunctionTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.ResponsesAzureFunctionTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesAzureFunctionTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesAzureFunctionTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesAzureFunctionTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResponsesBingCustomSearchConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesBingCustomSearchConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesBingCustomSearchConfiguration>
    {
        internal ResponsesBingCustomSearchConfiguration() { }
        public long? Count { get { throw null; } }
        public string Freshness { get { throw null; } }
        public string InstanceName { get { throw null; } }
        public string Market { get { throw null; } }
        public string ProjectConnectionId { get { throw null; } }
        public string SetLang { get { throw null; } }
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
    public partial class ResponsesBingCustomSearchPreviewTool : OpenAI.Responses.ResponseTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesBingCustomSearchPreviewTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesBingCustomSearchPreviewTool>
    {
        internal ResponsesBingCustomSearchPreviewTool() : base (default(OpenAI.Responses.ResponseToolKind)) { }
        public Azure.AI.Extensions.OpenAI.ResponsesBingCustomSearchToolParameters BingCustomSearchPreview { get { throw null; } }
        protected override OpenAI.Responses.ResponseTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override OpenAI.Responses.ResponseTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.ResponsesBingCustomSearchPreviewTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesBingCustomSearchPreviewTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesBingCustomSearchPreviewTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.ResponsesBingCustomSearchPreviewTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesBingCustomSearchPreviewTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesBingCustomSearchPreviewTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesBingCustomSearchPreviewTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResponsesBingCustomSearchToolParameters : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesBingCustomSearchToolParameters>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesBingCustomSearchToolParameters>
    {
        internal ResponsesBingCustomSearchToolParameters() { }
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
        internal ResponsesBingGroundingSearchConfiguration() { }
        public long? Count { get { throw null; } }
        public string Freshness { get { throw null; } }
        public string Language { get { throw null; } }
        public string Market { get { throw null; } }
        public string ProjectConnectionId { get { throw null; } }
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
        internal ResponsesBingGroundingSearchToolParameters() { }
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
    public partial class ResponsesBingGroundingTool : OpenAI.Responses.ResponseTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesBingGroundingTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesBingGroundingTool>
    {
        internal ResponsesBingGroundingTool() : base (default(OpenAI.Responses.ResponseToolKind)) { }
        public Azure.AI.Extensions.OpenAI.ResponsesBingGroundingSearchToolParameters BingGrounding { get { throw null; } }
        public string Description { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.AI.Extensions.OpenAI.ToolConfig> ToolConfigs { get { throw null; } }
        protected override OpenAI.Responses.ResponseTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override OpenAI.Responses.ResponseTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.ResponsesBingGroundingTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesBingGroundingTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesBingGroundingTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.ResponsesBingGroundingTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesBingGroundingTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesBingGroundingTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesBingGroundingTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResponsesBrowserAutomationPreviewTool : OpenAI.Responses.ResponseTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesBrowserAutomationPreviewTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesBrowserAutomationPreviewTool>
    {
        internal ResponsesBrowserAutomationPreviewTool() : base (default(OpenAI.Responses.ResponseToolKind)) { }
        public Azure.AI.Extensions.OpenAI.ResponsesBrowserAutomationToolParameters BrowserAutomationPreview { get { throw null; } }
        protected override OpenAI.Responses.ResponseTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override OpenAI.Responses.ResponseTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.ResponsesBrowserAutomationPreviewTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesBrowserAutomationPreviewTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesBrowserAutomationPreviewTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.ResponsesBrowserAutomationPreviewTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesBrowserAutomationPreviewTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesBrowserAutomationPreviewTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesBrowserAutomationPreviewTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResponsesBrowserAutomationToolConnectionParameters : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesBrowserAutomationToolConnectionParameters>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesBrowserAutomationToolConnectionParameters>
    {
        internal ResponsesBrowserAutomationToolConnectionParameters() { }
        public string ProjectConnectionId { get { throw null; } }
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
    public partial class ResponsesBrowserAutomationToolParameters : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesBrowserAutomationToolParameters>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesBrowserAutomationToolParameters>
    {
        internal ResponsesBrowserAutomationToolParameters() { }
        public Azure.AI.Extensions.OpenAI.ResponsesBrowserAutomationToolConnectionParameters Connection { get { throw null; } }
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
    public partial class ResponsesCaptureStructuredOutputsTool : OpenAI.Responses.ResponseTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesCaptureStructuredOutputsTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesCaptureStructuredOutputsTool>
    {
        internal ResponsesCaptureStructuredOutputsTool() : base (default(OpenAI.Responses.ResponseToolKind)) { }
        public string Description { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.AI.Extensions.OpenAI.ResponsesStructuredOutputDefinition OutputDefinition { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.AI.Extensions.OpenAI.ToolConfig> ToolConfigs { get { throw null; } }
        protected override OpenAI.Responses.ResponseTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override OpenAI.Responses.ResponseTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.ResponsesCaptureStructuredOutputsTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesCaptureStructuredOutputsTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesCaptureStructuredOutputsTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.ResponsesCaptureStructuredOutputsTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesCaptureStructuredOutputsTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesCaptureStructuredOutputsTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesCaptureStructuredOutputsTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class ResponsesCustomToolParam : OpenAI.Responses.ResponseTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesCustomToolParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesCustomToolParam>
    {
        public ResponsesCustomToolParam(string name) : base (default(OpenAI.Responses.ResponseToolKind)) { }
        public string Description { get { throw null; } set { } }
        public Azure.AI.Extensions.OpenAI.ResponsesCustomToolParamFormat Format { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public bool? ShouldDeferLoading { get { throw null; } set { } }
        protected override OpenAI.Responses.ResponseTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override OpenAI.Responses.ResponseTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        internal ResponsesEmptyModelParam() { }
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
    public partial class ResponsesFabricDataAgentToolOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesFabricDataAgentToolOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesFabricDataAgentToolOptions>
    {
        internal ResponsesFabricDataAgentToolOptions() { }
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
    public partial class ResponsesFabricIQPreviewTool : OpenAI.Responses.ResponseTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesFabricIQPreviewTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesFabricIQPreviewTool>
    {
        internal ResponsesFabricIQPreviewTool() : base (default(OpenAI.Responses.ResponseToolKind)) { }
        public string ProjectConnectionId { get { throw null; } }
        public System.BinaryData RequireApproval { get { throw null; } }
        public string ServerLabel { get { throw null; } }
        public System.Uri ServerUri { get { throw null; } }
        protected override OpenAI.Responses.ResponseTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override OpenAI.Responses.ResponseTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.ResponsesFabricIQPreviewTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesFabricIQPreviewTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesFabricIQPreviewTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.ResponsesFabricIQPreviewTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesFabricIQPreviewTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesFabricIQPreviewTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesFabricIQPreviewTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential, Size=1)]
    public readonly partial struct ResponsesFunctionCallOutputStatus
    {
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential, Size=1)]
    public readonly partial struct ResponsesFunctionCallStatus
    {
    }
    public partial class ResponsesFunctionShellToolParam : OpenAI.Responses.ResponseTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesFunctionShellToolParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesFunctionShellToolParam>
    {
        internal ResponsesFunctionShellToolParam() : base (default(OpenAI.Responses.ResponseToolKind)) { }
        public string Description { get { throw null; } }
        public Azure.AI.Extensions.OpenAI.ResponsesFunctionShellToolParamEnvironment Environment { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.AI.Extensions.OpenAI.ToolConfig> ToolConfigs { get { throw null; } }
        protected override OpenAI.Responses.ResponseTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override OpenAI.Responses.ResponseTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        internal ResponsesFunctionToolParam() { }
        public string Description { get { throw null; } }
        public bool? IsStrict { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.AI.Extensions.OpenAI.ResponsesEmptyModelParam Parameters { get { throw null; } }
        public bool? ShouldDeferLoading { get { throw null; } }
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
    public enum ResponsesGrammarSyntax
    {
        Lark = 0,
        Regex = 1,
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
    public partial class ResponsesLocalShellToolParam : OpenAI.Responses.ResponseTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesLocalShellToolParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesLocalShellToolParam>
    {
        internal ResponsesLocalShellToolParam() : base (default(OpenAI.Responses.ResponseToolKind)) { }
        public string Description { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.AI.Extensions.OpenAI.ToolConfig> ToolConfigs { get { throw null; } }
        protected override OpenAI.Responses.ResponseTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override OpenAI.Responses.ResponseTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.ResponsesLocalShellToolParam System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesLocalShellToolParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesLocalShellToolParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.ResponsesLocalShellToolParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesLocalShellToolParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesLocalShellToolParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesLocalShellToolParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResponsesMCPToolFilter : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesMCPToolFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesMCPToolFilter>
    {
        internal ResponsesMCPToolFilter() { }
        public bool? IsReadOnly { get { throw null; } }
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
        internal ResponsesMCPToolRequireApproval() { }
        public Azure.AI.Extensions.OpenAI.ResponsesMCPToolFilter Always { get { throw null; } }
        public Azure.AI.Extensions.OpenAI.ResponsesMCPToolFilter Never { get { throw null; } }
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
    public partial class ResponsesMemorySearchOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesMemorySearchOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesMemorySearchOptions>
    {
        internal ResponsesMemorySearchOptions() { }
        public int? MaxMemories { get { throw null; } }
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
    public partial class ResponsesMemorySearchPreviewTool : OpenAI.Responses.ResponseTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesMemorySearchPreviewTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesMemorySearchPreviewTool>
    {
        internal ResponsesMemorySearchPreviewTool() : base (default(OpenAI.Responses.ResponseToolKind)) { }
        public string MemoryStoreName { get { throw null; } }
        public string Scope { get { throw null; } }
        public Azure.AI.Extensions.OpenAI.ResponsesMemorySearchOptions SearchOptions { get { throw null; } }
        public int? UpdateDelayInSeconds { get { throw null; } }
        protected override OpenAI.Responses.ResponseTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override OpenAI.Responses.ResponseTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.ResponsesMemorySearchPreviewTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesMemorySearchPreviewTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesMemorySearchPreviewTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.ResponsesMemorySearchPreviewTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesMemorySearchPreviewTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesMemorySearchPreviewTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesMemorySearchPreviewTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResponsesMicrosoftFabricPreviewTool : OpenAI.Responses.ResponseTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesMicrosoftFabricPreviewTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesMicrosoftFabricPreviewTool>
    {
        internal ResponsesMicrosoftFabricPreviewTool() : base (default(OpenAI.Responses.ResponseToolKind)) { }
        public Azure.AI.Extensions.OpenAI.ResponsesFabricDataAgentToolOptions FabricDataagentPreview { get { throw null; } }
        protected override OpenAI.Responses.ResponseTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override OpenAI.Responses.ResponseTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.ResponsesMicrosoftFabricPreviewTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesMicrosoftFabricPreviewTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesMicrosoftFabricPreviewTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.ResponsesMicrosoftFabricPreviewTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesMicrosoftFabricPreviewTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesMicrosoftFabricPreviewTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesMicrosoftFabricPreviewTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResponsesNamespaceToolParam : OpenAI.Responses.ResponseTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesNamespaceToolParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesNamespaceToolParam>
    {
        internal ResponsesNamespaceToolParam() : base (default(OpenAI.Responses.ResponseToolKind)) { }
        public string Description { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IList<System.BinaryData> Tools { get { throw null; } }
        protected override OpenAI.Responses.ResponseTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override OpenAI.Responses.ResponseTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        internal ResponsesOpenApiFunctionDefinition() { }
        public Azure.AI.Extensions.OpenAI.ResponsesOpenApiAuthDetails Auth { get { throw null; } }
        public System.Collections.Generic.IList<string> DefaultParams { get { throw null; } }
        public string Description { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Extensions.OpenAI.ResponsesOpenApiFunctionDefinitionFunction> Functions { get { throw null; } }
        public string Name { get { throw null; } }
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
        public Azure.AI.Extensions.OpenAI.ResponsesOpenApiManagedSecurityScheme SecurityScheme { get { throw null; } }
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
        public string Audience { get { throw null; } }
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
        public Azure.AI.Extensions.OpenAI.ResponsesOpenApiProjectConnectionSecurityScheme SecurityScheme { get { throw null; } }
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
        public string ProjectConnectionId { get { throw null; } }
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
    public partial class ResponsesOpenApiTool : OpenAI.Responses.ResponseTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesOpenApiTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesOpenApiTool>
    {
        internal ResponsesOpenApiTool() : base (default(OpenAI.Responses.ResponseToolKind)) { }
        public Azure.AI.Extensions.OpenAI.ResponsesOpenApiFunctionDefinition OpenApi { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.AI.Extensions.OpenAI.ToolConfig> ToolConfigs { get { throw null; } }
        protected override OpenAI.Responses.ResponseTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override OpenAI.Responses.ResponseTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.ResponsesOpenApiTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesOpenApiTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesOpenApiTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.ResponsesOpenApiTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesOpenApiTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesOpenApiTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesOpenApiTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResponsesReminderPreviewTool : OpenAI.Responses.ResponseTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesReminderPreviewTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesReminderPreviewTool>
    {
        internal ResponsesReminderPreviewTool() : base (default(OpenAI.Responses.ResponseToolKind)) { }
        public string Description { get { throw null; } }
        public string Name { get { throw null; } }
        protected override OpenAI.Responses.ResponseTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override OpenAI.Responses.ResponseTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.ResponsesReminderPreviewTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesReminderPreviewTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesReminderPreviewTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.ResponsesReminderPreviewTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesReminderPreviewTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesReminderPreviewTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesReminderPreviewTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResponsesSharepointGroundingToolParameters : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesSharepointGroundingToolParameters>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesSharepointGroundingToolParameters>
    {
        internal ResponsesSharepointGroundingToolParameters() { }
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
    public partial class ResponsesSharepointPreviewTool : OpenAI.Responses.ResponseTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesSharepointPreviewTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesSharepointPreviewTool>
    {
        internal ResponsesSharepointPreviewTool() : base (default(OpenAI.Responses.ResponseToolKind)) { }
        public Azure.AI.Extensions.OpenAI.ResponsesSharepointGroundingToolParameters SharepointGroundingPreview { get { throw null; } }
        protected override OpenAI.Responses.ResponseTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override OpenAI.Responses.ResponseTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        internal ResponsesStructuredOutputDefinition() { }
        public string Description { get { throw null; } }
        public bool? IsStrict { get { throw null; } }
        public string Name { get { throw null; } }
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
    public partial class ResponsesToolProjectConnection : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesToolProjectConnection>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesToolProjectConnection>
    {
        internal ResponsesToolProjectConnection() { }
        public string ProjectConnectionId { get { throw null; } }
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
    public partial class ResponsesToolSearchToolParam : OpenAI.Responses.ResponseTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesToolSearchToolParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesToolSearchToolParam>
    {
        internal ResponsesToolSearchToolParam() : base (default(OpenAI.Responses.ResponseToolKind)) { }
        public string Description { get { throw null; } }
        public Azure.AI.Extensions.OpenAI.ResponsesToolSearchExecutionType? Execution { get { throw null; } }
        public Azure.AI.Extensions.OpenAI.ResponsesEmptyModelParam Parameters { get { throw null; } }
        protected override OpenAI.Responses.ResponseTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override OpenAI.Responses.ResponseTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.ResponsesToolSearchToolParam System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesToolSearchToolParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesToolSearchToolParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.ResponsesToolSearchToolParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesToolSearchToolParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesToolSearchToolParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesToolSearchToolParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResponsesWebSearchApproximateLocation : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesWebSearchApproximateLocation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesWebSearchApproximateLocation>
    {
        internal ResponsesWebSearchApproximateLocation() { }
        public string City { get { throw null; } }
        public string Country { get { throw null; } }
        public string Region { get { throw null; } }
        public string Timezone { get { throw null; } }
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
        internal ResponsesWebSearchConfiguration() { }
        public string InstanceName { get { throw null; } }
        public string ProjectConnectionId { get { throw null; } }
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
    public partial class ResponsesWebSearchTool
    {
        public ResponsesWebSearchTool() { }
    }
    public enum ResponsesWebSearchToolSearchContextSize
    {
        Low = 0,
        Medium = 1,
        High = 2,
    }
    public partial class ResponsesWorkIQPreviewTool : OpenAI.Responses.ResponseTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesWorkIQPreviewTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesWorkIQPreviewTool>
    {
        internal ResponsesWorkIQPreviewTool() : base (default(OpenAI.Responses.ResponseToolKind)) { }
        public string ProjectConnectionId { get { throw null; } }
        protected override OpenAI.Responses.ResponseTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override OpenAI.Responses.ResponseTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.ResponsesWorkIQPreviewTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesWorkIQPreviewTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesWorkIQPreviewTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.ResponsesWorkIQPreviewTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesWorkIQPreviewTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesWorkIQPreviewTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesWorkIQPreviewTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        internal SharepointGroundingToolCall() : base (default(OpenAI.Responses.ResponseItemKind)) { }
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
    public partial class SharepointGroundingToolCallOutput : OpenAI.Responses.ResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.SharepointGroundingToolCallOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.SharepointGroundingToolCallOutput>
    {
        internal SharepointGroundingToolCallOutput() : base (default(OpenAI.Responses.ResponseItemKind)) { }
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
