namespace Azure.AI.Extensions.OpenAI
{
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class A2AToolCall : Azure.AI.Extensions.OpenAI.AgentResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.A2AToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.A2AToolCall>
    {
        public A2AToolCall(string callId, string name, string arguments, Azure.AI.Extensions.OpenAI.ToolCallStatus status) { }
        public string Arguments { get { throw null; } set { } }
        public string CallId { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.AI.Extensions.OpenAI.ToolCallStatus Status { get { throw null; } set { } }
        protected override Azure.AI.Extensions.OpenAI.AgentResponseItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Extensions.OpenAI.AgentResponseItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.A2AToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.A2AToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.A2AToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.A2AToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.A2AToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.A2AToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.A2AToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class A2AToolCallOutput : Azure.AI.Extensions.OpenAI.AgentResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.A2AToolCallOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.A2AToolCallOutput>
    {
        public A2AToolCallOutput(string callId, string name, Azure.AI.Extensions.OpenAI.ToolCallStatus status) { }
        public string CallId { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.BinaryData Output { get { throw null; } set { } }
        public Azure.AI.Extensions.OpenAI.ToolCallStatus Status { get { throw null; } set { } }
        protected override Azure.AI.Extensions.OpenAI.AgentResponseItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Extensions.OpenAI.AgentResponseItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public abstract partial class AgentResponseItem : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.AgentResponseItem>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AgentResponseItem>
    {
        internal AgentResponseItem() { }
        public Azure.AI.Extensions.OpenAI.AgentReference AgentReference { get { throw null; } set { } }
        public string Id { get { throw null; } }
        public string ResponseId { get { throw null; } set { } }
        public OpenAI.Responses.ResponseItem AsResponseResultItem() { throw null; }
        public static Azure.AI.Extensions.OpenAI.AgentResponseItem CreateStructuredOutputsItem(System.BinaryData output = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.AgentResponseItem CreateWorkflowPreviewActionItem(string actionKind, string actionId) { throw null; }
        protected virtual Azure.AI.Extensions.OpenAI.AgentResponseItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator OpenAI.Responses.ResponseItem (Azure.AI.Extensions.OpenAI.AgentResponseItem agentResponseItem) { throw null; }
        public static implicit operator Azure.AI.Extensions.OpenAI.AgentResponseItem (OpenAI.Responses.ResponseItem responseItem) { throw null; }
        protected virtual Azure.AI.Extensions.OpenAI.AgentResponseItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.AgentResponseItem System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.AgentResponseItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.AgentResponseItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.AgentResponseItem System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AgentResponseItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AgentResponseItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AgentResponseItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AgentResponseItemKind : System.IEquatable<Azure.AI.Extensions.OpenAI.AgentResponseItemKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AgentResponseItemKind(string value) { throw null; }
        public static Azure.AI.Extensions.OpenAI.AgentResponseItemKind A2APreviewCall { get { throw null; } }
        public static Azure.AI.Extensions.OpenAI.AgentResponseItemKind A2APreviewCallOutput { get { throw null; } }
        public static Azure.AI.Extensions.OpenAI.AgentResponseItemKind ApplyPatchCall { get { throw null; } }
        public static Azure.AI.Extensions.OpenAI.AgentResponseItemKind ApplyPatchCallOutput { get { throw null; } }
        public static Azure.AI.Extensions.OpenAI.AgentResponseItemKind AzureAiSearchCall { get { throw null; } }
        public static Azure.AI.Extensions.OpenAI.AgentResponseItemKind AzureAiSearchCallOutput { get { throw null; } }
        public static Azure.AI.Extensions.OpenAI.AgentResponseItemKind AzureFunctionCall { get { throw null; } }
        public static Azure.AI.Extensions.OpenAI.AgentResponseItemKind AzureFunctionCallOutput { get { throw null; } }
        public static Azure.AI.Extensions.OpenAI.AgentResponseItemKind BingCustomSearchPreviewCall { get { throw null; } }
        public static Azure.AI.Extensions.OpenAI.AgentResponseItemKind BingCustomSearchPreviewCallOutput { get { throw null; } }
        public static Azure.AI.Extensions.OpenAI.AgentResponseItemKind BingGroundingCall { get { throw null; } }
        public static Azure.AI.Extensions.OpenAI.AgentResponseItemKind BingGroundingCallOutput { get { throw null; } }
        public static Azure.AI.Extensions.OpenAI.AgentResponseItemKind BrowserAutomationPreviewCall { get { throw null; } }
        public static Azure.AI.Extensions.OpenAI.AgentResponseItemKind BrowserAutomationPreviewCallOutput { get { throw null; } }
        public static Azure.AI.Extensions.OpenAI.AgentResponseItemKind CodeInterpreterCall { get { throw null; } }
        public static Azure.AI.Extensions.OpenAI.AgentResponseItemKind Compaction { get { throw null; } }
        public static Azure.AI.Extensions.OpenAI.AgentResponseItemKind ComputerCall { get { throw null; } }
        public static Azure.AI.Extensions.OpenAI.AgentResponseItemKind ComputerCallOutput { get { throw null; } }
        public static Azure.AI.Extensions.OpenAI.AgentResponseItemKind CustomToolCall { get { throw null; } }
        public static Azure.AI.Extensions.OpenAI.AgentResponseItemKind CustomToolCallOutput { get { throw null; } }
        public static Azure.AI.Extensions.OpenAI.AgentResponseItemKind FabricDataagentPreviewCall { get { throw null; } }
        public static Azure.AI.Extensions.OpenAI.AgentResponseItemKind FabricDataagentPreviewCallOutput { get { throw null; } }
        public static Azure.AI.Extensions.OpenAI.AgentResponseItemKind FileSearchCall { get { throw null; } }
        public static Azure.AI.Extensions.OpenAI.AgentResponseItemKind FunctionCall { get { throw null; } }
        public static Azure.AI.Extensions.OpenAI.AgentResponseItemKind FunctionCallOutput { get { throw null; } }
        public static Azure.AI.Extensions.OpenAI.AgentResponseItemKind ImageGenerationCall { get { throw null; } }
        public static Azure.AI.Extensions.OpenAI.AgentResponseItemKind LocalShellCall { get { throw null; } }
        public static Azure.AI.Extensions.OpenAI.AgentResponseItemKind LocalShellCallOutput { get { throw null; } }
        public static Azure.AI.Extensions.OpenAI.AgentResponseItemKind McpApprovalRequest { get { throw null; } }
        public static Azure.AI.Extensions.OpenAI.AgentResponseItemKind McpApprovalResponse { get { throw null; } }
        public static Azure.AI.Extensions.OpenAI.AgentResponseItemKind McpCall { get { throw null; } }
        public static Azure.AI.Extensions.OpenAI.AgentResponseItemKind McpListTools { get { throw null; } }
        public static Azure.AI.Extensions.OpenAI.AgentResponseItemKind MemoryCommandPreviewCall { get { throw null; } }
        public static Azure.AI.Extensions.OpenAI.AgentResponseItemKind MemoryCommandPreviewCallOutput { get { throw null; } }
        public static Azure.AI.Extensions.OpenAI.AgentResponseItemKind MemorySearchCall { get { throw null; } }
        public static Azure.AI.Extensions.OpenAI.AgentResponseItemKind Message { get { throw null; } }
        public static Azure.AI.Extensions.OpenAI.AgentResponseItemKind OauthConsentRequest { get { throw null; } }
        public static Azure.AI.Extensions.OpenAI.AgentResponseItemKind OpenapiCall { get { throw null; } }
        public static Azure.AI.Extensions.OpenAI.AgentResponseItemKind OpenapiCallOutput { get { throw null; } }
        public static Azure.AI.Extensions.OpenAI.AgentResponseItemKind OutputMessage { get { throw null; } }
        public static Azure.AI.Extensions.OpenAI.AgentResponseItemKind Reasoning { get { throw null; } }
        public static Azure.AI.Extensions.OpenAI.AgentResponseItemKind SharepointGroundingPreviewCall { get { throw null; } }
        public static Azure.AI.Extensions.OpenAI.AgentResponseItemKind SharepointGroundingPreviewCallOutput { get { throw null; } }
        public static Azure.AI.Extensions.OpenAI.AgentResponseItemKind ShellCall { get { throw null; } }
        public static Azure.AI.Extensions.OpenAI.AgentResponseItemKind ShellCallOutput { get { throw null; } }
        public static Azure.AI.Extensions.OpenAI.AgentResponseItemKind StructuredOutputs { get { throw null; } }
        public static Azure.AI.Extensions.OpenAI.AgentResponseItemKind ToolSearchCall { get { throw null; } }
        public static Azure.AI.Extensions.OpenAI.AgentResponseItemKind ToolSearchOutput { get { throw null; } }
        public static Azure.AI.Extensions.OpenAI.AgentResponseItemKind WebSearchCall { get { throw null; } }
        public static Azure.AI.Extensions.OpenAI.AgentResponseItemKind WorkflowAction { get { throw null; } }
        public bool Equals(Azure.AI.Extensions.OpenAI.AgentResponseItemKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Extensions.OpenAI.AgentResponseItemKind left, Azure.AI.Extensions.OpenAI.AgentResponseItemKind right) { throw null; }
        public static implicit operator OpenAI.Responses.ResponseItemKind (Azure.AI.Extensions.OpenAI.AgentResponseItemKind value) { throw null; }
        public static implicit operator Azure.AI.Extensions.OpenAI.AgentResponseItemKind (string value) { throw null; }
        public static implicit operator Azure.AI.Extensions.OpenAI.AgentResponseItemKind? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Extensions.OpenAI.AgentResponseItemKind left, Azure.AI.Extensions.OpenAI.AgentResponseItemKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AgentStructuredOutputsResponseItem : Azure.AI.Extensions.OpenAI.AgentResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.AgentStructuredOutputsResponseItem>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AgentStructuredOutputsResponseItem>
    {
        public AgentStructuredOutputsResponseItem(System.BinaryData output) { }
        public System.BinaryData Output { get { throw null; } set { } }
        protected override Azure.AI.Extensions.OpenAI.AgentResponseItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Extensions.OpenAI.AgentResponseItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.AgentStructuredOutputsResponseItem System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.AgentStructuredOutputsResponseItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.AgentStructuredOutputsResponseItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.AgentStructuredOutputsResponseItem System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AgentStructuredOutputsResponseItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AgentStructuredOutputsResponseItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AgentStructuredOutputsResponseItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentWorkflowPreviewActionResponseItem : Azure.AI.Extensions.OpenAI.AgentResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.AgentWorkflowPreviewActionResponseItem>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AgentWorkflowPreviewActionResponseItem>
    {
        public AgentWorkflowPreviewActionResponseItem(string kind, string actionId, Azure.AI.Extensions.OpenAI.AgentWorkflowPreviewActionStatus? status) { }
        public string ActionId { get { throw null; } set { } }
        public string CSDLActionKind { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public string ParentActionId { get { throw null; } set { } }
        public string PreviousActionId { get { throw null; } set { } }
        public Azure.AI.Extensions.OpenAI.AgentWorkflowPreviewActionStatus? Status { get { throw null; } }
        protected override Azure.AI.Extensions.OpenAI.AgentResponseItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Extensions.OpenAI.AgentResponseItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public static Azure.AI.Extensions.OpenAI.AgentResponseItem AsAgentResponseItem(this OpenAI.Responses.ResponseItem responseItem) { throw null; }
        public static System.ClientModel.ClientResult<OpenAI.Responses.ResponseResult> CreateResponse(this OpenAI.Responses.ResponsesClient responseClient, Azure.AI.Extensions.OpenAI.ProjectConversation conversation, Azure.AI.Extensions.OpenAI.AgentReference agentRef, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<System.ClientModel.ClientResult<OpenAI.Responses.ResponseResult>> CreateResponseAsync(this OpenAI.Responses.ResponsesClient responseClient, Azure.AI.Extensions.OpenAI.ProjectConversation conversation, Azure.AI.Extensions.OpenAI.AgentReference agentRef, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static string GetAzureFileStatus(this OpenAI.Files.OpenAIFile file) { throw null; }
        public static Azure.AI.Extensions.OpenAI.AgentReference get_Agent(OpenAI.Responses.CreateResponseOptions options) { throw null; }
        public static Azure.AI.Extensions.OpenAI.AgentReference get_Agent(OpenAI.Responses.ResponseResult response) { throw null; }
        public static string get_AgentConversationId(OpenAI.Responses.CreateResponseOptions options) { throw null; }
        public static string get_AgentConversationId(OpenAI.Responses.ResponseResult response) { throw null; }
        public static string get_SessionId(OpenAI.Responses.CreateResponseOptions options) { throw null; }
        public static void set_Agent(OpenAI.Responses.CreateResponseOptions options, Azure.AI.Extensions.OpenAI.AgentReference value) { }
        public static void set_AgentConversationId(OpenAI.Responses.CreateResponseOptions options, string value) { }
        public static void set_SessionId(OpenAI.Responses.CreateResponseOptions options, string value) { }
        public sealed partial class <G>$9441C364D6D7BED1E759B10623E362FD
        {
            internal <G>$9441C364D6D7BED1E759B10623E362FD() { }
            [System.Runtime.CompilerServices.ExtensionMarkerAttribute("<M>$CF4B939802E692FD9BEF27F36FABED87")]
            public Azure.AI.Extensions.OpenAI.AgentReference Agent { [System.Runtime.CompilerServices.ExtensionMarkerAttribute("<M>$CF4B939802E692FD9BEF27F36FABED87")] get { throw null; } [System.Runtime.CompilerServices.ExtensionMarkerAttribute("<M>$CF4B939802E692FD9BEF27F36FABED87")] set { } }
            [System.Runtime.CompilerServices.ExtensionMarkerAttribute("<M>$CF4B939802E692FD9BEF27F36FABED87")]
            public string AgentConversationId { [System.Runtime.CompilerServices.ExtensionMarkerAttribute("<M>$CF4B939802E692FD9BEF27F36FABED87")] get { throw null; } [System.Runtime.CompilerServices.ExtensionMarkerAttribute("<M>$CF4B939802E692FD9BEF27F36FABED87")] set { } }
            [System.Runtime.CompilerServices.ExtensionMarkerAttribute("<M>$CF4B939802E692FD9BEF27F36FABED87")]
            public string SessionId { [System.Runtime.CompilerServices.ExtensionMarkerAttribute("<M>$CF4B939802E692FD9BEF27F36FABED87")] get { throw null; } [System.Runtime.CompilerServices.ExtensionMarkerAttribute("<M>$CF4B939802E692FD9BEF27F36FABED87")] set { } }
            public static partial class <M>$CF4B939802E692FD9BEF27F36FABED87
            {
                public static void <Extension>$(OpenAI.Responses.CreateResponseOptions options) { }
            }
        }
        public sealed partial class <G>$D7C08262BAEC712802F8752B389F8208
        {
            internal <G>$D7C08262BAEC712802F8752B389F8208() { }
            [System.Runtime.CompilerServices.ExtensionMarkerAttribute("<M>$9CB7C4485EAB7B97A3544F52CBDBA0F9")]
            public Azure.AI.Extensions.OpenAI.AgentReference Agent { [System.Runtime.CompilerServices.ExtensionMarkerAttribute("<M>$9CB7C4485EAB7B97A3544F52CBDBA0F9")] get { throw null; } }
            [System.Runtime.CompilerServices.ExtensionMarkerAttribute("<M>$9CB7C4485EAB7B97A3544F52CBDBA0F9")]
            public string AgentConversationId { [System.Runtime.CompilerServices.ExtensionMarkerAttribute("<M>$9CB7C4485EAB7B97A3544F52CBDBA0F9")] get { throw null; } }
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
    public partial class AzureAISearchToolCall : Azure.AI.Extensions.OpenAI.AgentResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.AzureAISearchToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AzureAISearchToolCall>
    {
        public AzureAISearchToolCall(string callId, string arguments, Azure.AI.Extensions.OpenAI.ToolCallStatus status) { }
        public string Arguments { get { throw null; } set { } }
        public string CallId { get { throw null; } set { } }
        public Azure.AI.Extensions.OpenAI.ToolCallStatus Status { get { throw null; } set { } }
        protected override Azure.AI.Extensions.OpenAI.AgentResponseItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Extensions.OpenAI.AgentResponseItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.AzureAISearchToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.AzureAISearchToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.AzureAISearchToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.AzureAISearchToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AzureAISearchToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AzureAISearchToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AzureAISearchToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureAISearchToolCallOutput : Azure.AI.Extensions.OpenAI.AgentResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.AzureAISearchToolCallOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AzureAISearchToolCallOutput>
    {
        public AzureAISearchToolCallOutput(string callId, Azure.AI.Extensions.OpenAI.ToolCallStatus status) { }
        public string CallId { get { throw null; } set { } }
        public System.BinaryData Output { get { throw null; } set { } }
        public Azure.AI.Extensions.OpenAI.ToolCallStatus Status { get { throw null; } set { } }
        protected override Azure.AI.Extensions.OpenAI.AgentResponseItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Extensions.OpenAI.AgentResponseItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public Azure.AI.Extensions.OpenAI.ResponsesAzureAISearchQueryKind? QueryType { get { throw null; } set { } }
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
    public partial class AzureFunctionToolCall : Azure.AI.Extensions.OpenAI.AgentResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.AzureFunctionToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AzureFunctionToolCall>
    {
        public AzureFunctionToolCall(string callId, string name, string arguments, Azure.AI.Extensions.OpenAI.ToolCallStatus status) { }
        public string Arguments { get { throw null; } set { } }
        public string CallId { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.AI.Extensions.OpenAI.ToolCallStatus Status { get { throw null; } set { } }
        protected override Azure.AI.Extensions.OpenAI.AgentResponseItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Extensions.OpenAI.AgentResponseItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.AzureFunctionToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.AzureFunctionToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.AzureFunctionToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.AzureFunctionToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AzureFunctionToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AzureFunctionToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AzureFunctionToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureFunctionToolCallOutput : Azure.AI.Extensions.OpenAI.AgentResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.AzureFunctionToolCallOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AzureFunctionToolCallOutput>
    {
        public AzureFunctionToolCallOutput(string callId, string name, Azure.AI.Extensions.OpenAI.ToolCallStatus status) { }
        public string CallId { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.BinaryData Output { get { throw null; } set { } }
        public Azure.AI.Extensions.OpenAI.ToolCallStatus Status { get { throw null; } set { } }
        protected override Azure.AI.Extensions.OpenAI.AgentResponseItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Extensions.OpenAI.AgentResponseItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.AzureFunctionToolCallOutput System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.AzureFunctionToolCallOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.AzureFunctionToolCallOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.AzureFunctionToolCallOutput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AzureFunctionToolCallOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AzureFunctionToolCallOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.AzureFunctionToolCallOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class BingCustomSearchOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.BingCustomSearchOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BingCustomSearchOptions>
    {
        public BingCustomSearchOptions(string projectConnectionId, string instanceName) { }
        public long? Count { get { throw null; } set { } }
        public string Freshness { get { throw null; } set { } }
        public string InstanceName { get { throw null; } set { } }
        public string Market { get { throw null; } set { } }
        public string ProjectConnectionId { get { throw null; } set { } }
        public string SetLang { get { throw null; } set { } }
        protected virtual Azure.AI.Extensions.OpenAI.BingCustomSearchOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Extensions.OpenAI.BingCustomSearchOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.BingCustomSearchOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.BingCustomSearchOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.BingCustomSearchOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.BingCustomSearchOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BingCustomSearchOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BingCustomSearchOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BingCustomSearchOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class BingCustomSearchToolCall : Azure.AI.Extensions.OpenAI.AgentResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.BingCustomSearchToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BingCustomSearchToolCall>
    {
        public BingCustomSearchToolCall(string callId, string arguments, Azure.AI.Extensions.OpenAI.ToolCallStatus status) { }
        public string Arguments { get { throw null; } set { } }
        public string CallId { get { throw null; } set { } }
        public Azure.AI.Extensions.OpenAI.ToolCallStatus Status { get { throw null; } set { } }
        protected override Azure.AI.Extensions.OpenAI.AgentResponseItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Extensions.OpenAI.AgentResponseItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.BingCustomSearchToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.BingCustomSearchToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.BingCustomSearchToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.BingCustomSearchToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BingCustomSearchToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BingCustomSearchToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BingCustomSearchToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class BingCustomSearchToolCallOutput : Azure.AI.Extensions.OpenAI.AgentResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.BingCustomSearchToolCallOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BingCustomSearchToolCallOutput>
    {
        public BingCustomSearchToolCallOutput(string callId, Azure.AI.Extensions.OpenAI.ToolCallStatus status) { }
        public string CallId { get { throw null; } set { } }
        public System.BinaryData Output { get { throw null; } set { } }
        public Azure.AI.Extensions.OpenAI.ToolCallStatus Status { get { throw null; } set { } }
        protected override Azure.AI.Extensions.OpenAI.AgentResponseItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Extensions.OpenAI.AgentResponseItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public BingCustomSearchToolOptions(System.Collections.Generic.IEnumerable<Azure.AI.Extensions.OpenAI.BingCustomSearchOptions> searchConfigurations) { }
        public System.Collections.Generic.IList<Azure.AI.Extensions.OpenAI.BingCustomSearchOptions> SearchConfigurations { get { throw null; } }
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
    public partial class BingGroundingSearchOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.BingGroundingSearchOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BingGroundingSearchOptions>
    {
        public BingGroundingSearchOptions(string projectConnectionId) { }
        public long? Count { get { throw null; } set { } }
        public string Freshness { get { throw null; } set { } }
        public string Language { get { throw null; } set { } }
        public string Market { get { throw null; } set { } }
        public string ProjectConnectionId { get { throw null; } set { } }
        protected virtual Azure.AI.Extensions.OpenAI.BingGroundingSearchOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Extensions.OpenAI.BingGroundingSearchOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.BingGroundingSearchOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.BingGroundingSearchOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.BingGroundingSearchOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.BingGroundingSearchOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BingGroundingSearchOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BingGroundingSearchOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BingGroundingSearchOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BingGroundingSearchToolOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.BingGroundingSearchToolOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BingGroundingSearchToolOptions>
    {
        public BingGroundingSearchToolOptions(System.Collections.Generic.IEnumerable<Azure.AI.Extensions.OpenAI.BingGroundingSearchOptions> searchConfigurations) { }
        public System.Collections.Generic.IList<Azure.AI.Extensions.OpenAI.BingGroundingSearchOptions> SearchConfigurations { get { throw null; } }
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
    public partial class BingGroundingToolCall : Azure.AI.Extensions.OpenAI.AgentResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.BingGroundingToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BingGroundingToolCall>
    {
        public BingGroundingToolCall(string callId, string arguments, Azure.AI.Extensions.OpenAI.ToolCallStatus status) { }
        public string Arguments { get { throw null; } set { } }
        public string CallId { get { throw null; } set { } }
        public Azure.AI.Extensions.OpenAI.ToolCallStatus Status { get { throw null; } set { } }
        protected override Azure.AI.Extensions.OpenAI.AgentResponseItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Extensions.OpenAI.AgentResponseItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.BingGroundingToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.BingGroundingToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.BingGroundingToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.BingGroundingToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BingGroundingToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BingGroundingToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BingGroundingToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BingGroundingToolCallOutput : Azure.AI.Extensions.OpenAI.AgentResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.BingGroundingToolCallOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BingGroundingToolCallOutput>
    {
        public BingGroundingToolCallOutput(string callId, Azure.AI.Extensions.OpenAI.ToolCallStatus status) { }
        public string CallId { get { throw null; } set { } }
        public System.BinaryData Output { get { throw null; } set { } }
        public Azure.AI.Extensions.OpenAI.ToolCallStatus Status { get { throw null; } set { } }
        protected override Azure.AI.Extensions.OpenAI.AgentResponseItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Extensions.OpenAI.AgentResponseItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.BingGroundingToolCallOutput System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.BingGroundingToolCallOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.BingGroundingToolCallOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.BingGroundingToolCallOutput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BingGroundingToolCallOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BingGroundingToolCallOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BingGroundingToolCallOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class BrowserAutomationToolCall : Azure.AI.Extensions.OpenAI.AgentResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.BrowserAutomationToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BrowserAutomationToolCall>
    {
        public BrowserAutomationToolCall(string callId, string arguments, Azure.AI.Extensions.OpenAI.ToolCallStatus status) { }
        public string Arguments { get { throw null; } set { } }
        public string CallId { get { throw null; } set { } }
        public Azure.AI.Extensions.OpenAI.ToolCallStatus Status { get { throw null; } set { } }
        protected override Azure.AI.Extensions.OpenAI.AgentResponseItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Extensions.OpenAI.AgentResponseItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.BrowserAutomationToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.BrowserAutomationToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.BrowserAutomationToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.BrowserAutomationToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BrowserAutomationToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BrowserAutomationToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BrowserAutomationToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class BrowserAutomationToolCallOutput : Azure.AI.Extensions.OpenAI.AgentResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.BrowserAutomationToolCallOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BrowserAutomationToolCallOutput>
    {
        public BrowserAutomationToolCallOutput(string callId, Azure.AI.Extensions.OpenAI.ToolCallStatus status) { }
        public string CallId { get { throw null; } set { } }
        public System.BinaryData Output { get { throw null; } set { } }
        public Azure.AI.Extensions.OpenAI.ToolCallStatus Status { get { throw null; } set { } }
        protected override Azure.AI.Extensions.OpenAI.AgentResponseItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Extensions.OpenAI.AgentResponseItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.BrowserAutomationToolCallOutput System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.BrowserAutomationToolCallOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.BrowserAutomationToolCallOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.BrowserAutomationToolCallOutput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BrowserAutomationToolCallOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BrowserAutomationToolCallOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BrowserAutomationToolCallOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class BrowserAutomationToolOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.BrowserAutomationToolOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.BrowserAutomationToolOptions>
    {
        public BrowserAutomationToolOptions(Azure.AI.Extensions.OpenAI.ResponsesBrowserAutomationToolConnectionParameters connection) { }
        public Azure.AI.Extensions.OpenAI.ResponsesBrowserAutomationToolConnectionParameters Connection { get { throw null; } set { } }
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
    public static partial class ExtensionsOpenAIModelFactory
    {
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Extensions.OpenAI.A2AToolCall A2AToolCall(string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, string name = null, string arguments = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Extensions.OpenAI.A2AToolCallOutput A2AToolCallOutput(string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, string name = null, System.BinaryData output = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        public static Azure.AI.Extensions.OpenAI.AgentReference AgentReference(string name = null, string version = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.AgentResponseItem AgentResponseItem(string type = null, string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.AgentStructuredOutputsResponseItem AgentStructuredOutputsResponseItem(string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, System.BinaryData output = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.AgentWorkflowPreviewActionResponseItem AgentWorkflowPreviewActionResponseItem(string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string kind = null, string actionId = null, string parentActionId = null, string previousActionId = null, Azure.AI.Extensions.OpenAI.AgentWorkflowPreviewActionStatus? status = default(Azure.AI.Extensions.OpenAI.AgentWorkflowPreviewActionStatus?)) { throw null; }
        public static Azure.AI.Extensions.OpenAI.AzureAISearchToolCall AzureAISearchToolCall(string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, string arguments = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        public static Azure.AI.Extensions.OpenAI.AzureAISearchToolCallOutput AzureAISearchToolCallOutput(string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, System.BinaryData output = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        public static Azure.AI.Extensions.OpenAI.AzureAISearchToolIndex AzureAISearchToolIndex(string projectConnectionId = null, string indexName = null, Azure.AI.Extensions.OpenAI.ResponsesAzureAISearchQueryKind? queryType = default(Azure.AI.Extensions.OpenAI.ResponsesAzureAISearchQueryKind?), int? topK = default(int?), string filter = null, string indexAssetId = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.AzureAISearchToolOptions AzureAISearchToolOptions(System.Collections.Generic.IEnumerable<Azure.AI.Extensions.OpenAI.AzureAISearchToolIndex> indexes = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.AzureFunctionToolCall AzureFunctionToolCall(string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, string name = null, string arguments = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        public static Azure.AI.Extensions.OpenAI.AzureFunctionToolCallOutput AzureFunctionToolCallOutput(string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, string name = null, System.BinaryData output = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Extensions.OpenAI.BingCustomSearchOptions BingCustomSearchOptions(string projectConnectionId = null, string instanceName = null, string market = null, string setLang = null, long? count = default(long?), string freshness = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Extensions.OpenAI.BingCustomSearchToolCall BingCustomSearchToolCall(string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, string arguments = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Extensions.OpenAI.BingCustomSearchToolCallOutput BingCustomSearchToolCallOutput(string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, System.BinaryData output = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Extensions.OpenAI.BingCustomSearchToolOptions BingCustomSearchToolOptions(System.Collections.Generic.IEnumerable<Azure.AI.Extensions.OpenAI.BingCustomSearchOptions> searchConfigurations = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.BingGroundingSearchOptions BingGroundingSearchOptions(string projectConnectionId = null, string market = null, string language = null, long? count = default(long?), string freshness = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.BingGroundingSearchToolOptions BingGroundingSearchToolOptions(System.Collections.Generic.IEnumerable<Azure.AI.Extensions.OpenAI.BingGroundingSearchOptions> searchConfigurations = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.BingGroundingToolCall BingGroundingToolCall(string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, string arguments = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        public static Azure.AI.Extensions.OpenAI.BingGroundingToolCallOutput BingGroundingToolCallOutput(string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, System.BinaryData output = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Extensions.OpenAI.BrowserAutomationToolCall BrowserAutomationToolCall(string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, string arguments = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Extensions.OpenAI.BrowserAutomationToolCallOutput BrowserAutomationToolCallOutput(string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, System.BinaryData output = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Extensions.OpenAI.BrowserAutomationToolOptions BrowserAutomationToolOptions(Azure.AI.Extensions.OpenAI.ResponsesBrowserAutomationToolConnectionParameters connection = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Extensions.OpenAI.ChatSummaryMemoryItem ChatSummaryMemoryItem(string memoryId = null, System.DateTimeOffset updatedAt = default(System.DateTimeOffset), string scope = null, string content = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.Internal.ContainerSkill ContainerSkill(string type = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.Internal.CustomGrammarFormatParam CustomGrammarFormatParam(Azure.AI.Extensions.OpenAI.ResponsesGrammarSyntax syntax = default(Azure.AI.Extensions.OpenAI.ResponsesGrammarSyntax), string definition = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Extensions.OpenAI.FabricDataAgentToolCall FabricDataAgentToolCall(string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, string arguments = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Extensions.OpenAI.FabricDataAgentToolCallOutput FabricDataAgentToolCallOutput(string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, System.BinaryData output = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        public static Azure.AI.Extensions.OpenAI.Internal.LocalSkillParam LocalSkillParam(string name = null, string description = null, string path = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Extensions.OpenAI.MemoryCommandToolCall MemoryCommandToolCall(string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, string arguments = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Extensions.OpenAI.MemoryCommandToolCallOutput MemoryCommandToolCallOutput(string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Extensions.OpenAI.MemoryOutputItem MemoryOutputItem(string memoryId = null, System.DateTimeOffset updatedAt = default(System.DateTimeOffset), string scope = null, string content = null, string kind = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Extensions.OpenAI.MemorySearchToolCall MemorySearchToolCall(string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress, System.Collections.Generic.IEnumerable<Azure.AI.Extensions.OpenAI.MemoryOutputItem> memories = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.OAuthConsentRequestResponseItem OAuthConsentRequestResponseItem(string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string internalConsentLink = null, string serverLabel = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.OpenApiAnonymousAuthenticationDetails OpenApiAnonymousAuthenticationDetails() { throw null; }
        public static Azure.AI.Extensions.OpenAI.OpenApiAuthenticationDetails OpenApiAuthenticationDetails(string kind = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.OpenApiManagedAuthenticationDetails OpenApiManagedAuthenticationDetails(Azure.AI.Extensions.OpenAI.ResponsesOpenApiManagedSecurityScheme securityScheme = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.OpenApiProjectConnectionAuthenticationDetails OpenApiProjectConnectionAuthenticationDetails(Azure.AI.Extensions.OpenAI.ResponsesOpenApiProjectConnectionSecurityScheme securityScheme = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.OpenApiToolCall OpenApiToolCall(string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, string name = null, string arguments = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        public static Azure.AI.Extensions.OpenAI.OpenApiToolCallOutput OpenApiToolCallOutput(string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, string name = null, System.BinaryData output = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Extensions.OpenAI.ProceduralMemoryItem ProceduralMemoryItem(string memoryId = null, System.DateTimeOffset updatedAt = default(System.DateTimeOffset), string scope = null, string content = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ProjectConversation ProjectConversation(string id = null, System.Collections.Generic.IDictionary<string, string> metadata = null, System.DateTimeOffset createdAt = default(System.DateTimeOffset)) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Extensions.OpenAI.ResponsesA2APreviewTool ResponsesA2APreviewTool(System.Uri baseUri = null, string agentCardPath = null, string projectConnectionId = null, bool? sendCredentialsForAgentCard = default(bool?)) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesAzureAISearchTool ResponsesAzureAISearchTool(string name = null, string description = null, System.Collections.Generic.IDictionary<string, Azure.AI.Extensions.OpenAI.ToolConfig> toolConfigs = null, Azure.AI.Extensions.OpenAI.AzureAISearchToolOptions azureAISearch = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesAzureFunctionBinding ResponsesAzureFunctionBinding(Azure.AI.Extensions.OpenAI.ResponsesAzureFunctionStorageQueue storageQueue = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesAzureFunctionDefinition ResponsesAzureFunctionDefinition(Azure.AI.Extensions.OpenAI.ResponsesAzureFunctionDefinitionFunction function = null, Azure.AI.Extensions.OpenAI.ResponsesAzureFunctionBinding inputBinding = null, Azure.AI.Extensions.OpenAI.ResponsesAzureFunctionBinding outputBinding = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesAzureFunctionDefinitionFunction ResponsesAzureFunctionDefinitionFunction(string name = null, string description = null, System.Collections.Generic.IDictionary<string, System.BinaryData> parameters = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesAzureFunctionStorageQueue ResponsesAzureFunctionStorageQueue(string queueServiceEndpoint = null, string queueName = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesAzureFunctionTool ResponsesAzureFunctionTool(System.Collections.Generic.IDictionary<string, Azure.AI.Extensions.OpenAI.ToolConfig> toolConfigs = null, Azure.AI.Extensions.OpenAI.ResponsesAzureFunctionDefinition azureFunction = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Extensions.OpenAI.ResponsesBingCustomSearchPreviewTool ResponsesBingCustomSearchPreviewTool(Azure.AI.Extensions.OpenAI.BingCustomSearchToolOptions bingCustomSearchPreview = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesBingGroundingTool ResponsesBingGroundingTool(string name = null, string description = null, System.Collections.Generic.IDictionary<string, Azure.AI.Extensions.OpenAI.ToolConfig> toolConfigs = null, Azure.AI.Extensions.OpenAI.BingGroundingSearchToolOptions bingGrounding = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Extensions.OpenAI.ResponsesBrowserAutomationPreviewTool ResponsesBrowserAutomationPreviewTool(Azure.AI.Extensions.OpenAI.BrowserAutomationToolOptions browserAutomationPreview = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Extensions.OpenAI.ResponsesBrowserAutomationToolConnectionParameters ResponsesBrowserAutomationToolConnectionParameters(string projectConnectionId = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesCaptureStructuredOutputsTool ResponsesCaptureStructuredOutputsTool(string name = null, string description = null, System.Collections.Generic.IDictionary<string, Azure.AI.Extensions.OpenAI.ToolConfig> toolConfigs = null, Azure.AI.Extensions.OpenAI.ResponsesStructuredOutputDefinition outputDefinition = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesContainerAutoParam ResponsesContainerAutoParam(System.Collections.Generic.IEnumerable<string> fileIds = null, Azure.AI.Extensions.OpenAI.ResponsesContainerMemoryLimit? memoryLimit = default(Azure.AI.Extensions.OpenAI.ResponsesContainerMemoryLimit?), System.Collections.Generic.IEnumerable<Azure.AI.Extensions.OpenAI.Internal.ContainerSkill> skills = null, Azure.AI.Extensions.OpenAI.ResponsesContainerNetworkPolicyParam networkPolicy = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesContainerNetworkPolicyAllowlistParam ResponsesContainerNetworkPolicyAllowlistParam(System.Collections.Generic.IEnumerable<string> allowedDomains = null, System.Collections.Generic.IEnumerable<Azure.AI.Extensions.OpenAI.ResponsesContainerNetworkPolicyDomainSecretParam> domainSecrets = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesContainerNetworkPolicyDisabledParam ResponsesContainerNetworkPolicyDisabledParam() { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesContainerNetworkPolicyDomainSecretParam ResponsesContainerNetworkPolicyDomainSecretParam(string domain = null, string name = null, string value = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesContainerNetworkPolicyParam ResponsesContainerNetworkPolicyParam(string type = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesCustomTextFormatParam ResponsesCustomTextFormatParam() { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesCustomToolParamFormat ResponsesCustomToolParamFormat(string type = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesEmptyModelParam ResponsesEmptyModelParam() { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Extensions.OpenAI.ResponsesFabricDataAgentToolOptions ResponsesFabricDataAgentToolOptions(System.Collections.Generic.IEnumerable<Azure.AI.Extensions.OpenAI.ResponsesToolProjectConnection> projectConnections = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Extensions.OpenAI.ResponsesFabricIQPreviewTool ResponsesFabricIQPreviewTool(string projectConnectionId = null, string serverLabel = null, System.Uri serverUri = null, System.BinaryData requireApproval = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesFunctionShellToolParamEnvironment ResponsesFunctionShellToolParamEnvironment(string type = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesFunctionShellToolParamEnvironmentContainerReferenceParam ResponsesFunctionShellToolParamEnvironmentContainerReferenceParam(string containerId = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesFunctionShellToolParamEnvironmentLocalEnvironmentParam ResponsesFunctionShellToolParamEnvironmentLocalEnvironmentParam(System.Collections.Generic.IEnumerable<Azure.AI.Extensions.OpenAI.Internal.LocalSkillParam> skills = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesFunctionToolParam ResponsesFunctionToolParam(string name = null, string description = null, Azure.AI.Extensions.OpenAI.ResponsesEmptyModelParam parameters = null, bool? strict = default(bool?), bool? deferLoading = default(bool?)) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesInlineSkillParam ResponsesInlineSkillParam(string name = null, string description = null, Azure.AI.Extensions.OpenAI.ResponsesInlineSkillSourceParam source = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesInlineSkillSourceParam ResponsesInlineSkillSourceParam(string data = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Extensions.OpenAI.ResponsesMemorySearchOptions ResponsesMemorySearchOptions(int? maxMemories = default(int?)) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Extensions.OpenAI.ResponsesMemorySearchPreviewTool ResponsesMemorySearchPreviewTool(string memoryStoreName = null, string scope = null, Azure.AI.Extensions.OpenAI.ResponsesMemorySearchOptions searchOptions = null, int? updateDelayInSeconds = default(int?)) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Extensions.OpenAI.ResponsesMicrosoftFabricPreviewTool ResponsesMicrosoftFabricPreviewTool(Azure.AI.Extensions.OpenAI.ResponsesFabricDataAgentToolOptions toolOptions = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesOpenApiFunctionDefinition ResponsesOpenApiFunctionDefinition(string name = null, string description = null, System.Collections.Generic.IDictionary<string, System.BinaryData> specification = null, Azure.AI.Extensions.OpenAI.OpenApiAuthenticationDetails authentication = null, System.Collections.Generic.IEnumerable<string> defaultParameters = null, System.Collections.Generic.IEnumerable<Azure.AI.Extensions.OpenAI.ResponsesOpenApiFunctionDefinitionFunction> functions = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesOpenApiFunctionDefinitionFunction ResponsesOpenApiFunctionDefinitionFunction(string name = null, string description = null, System.Collections.Generic.IDictionary<string, System.BinaryData> parameters = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesOpenApiManagedSecurityScheme ResponsesOpenApiManagedSecurityScheme(string audience = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesOpenApiProjectConnectionSecurityScheme ResponsesOpenApiProjectConnectionSecurityScheme(string projectConnectionId = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesOpenApiTool ResponsesOpenApiTool(System.Collections.Generic.IDictionary<string, Azure.AI.Extensions.OpenAI.ToolConfig> toolConfigs = null, Azure.AI.Extensions.OpenAI.ResponsesOpenApiFunctionDefinition functionDefinition = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Extensions.OpenAI.ResponsesSharepointPreviewTool ResponsesSharepointPreviewTool(Azure.AI.Extensions.OpenAI.SharePointGroundingToolOptions toolOptions = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesSkillReferenceParam ResponsesSkillReferenceParam(string skillId = null, string version = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesStructuredOutputDefinition ResponsesStructuredOutputDefinition(string name = null, string description = null, System.Collections.Generic.IDictionary<string, System.BinaryData> schema = null, bool? isStrict = default(bool?)) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesToolProjectConnection ResponsesToolProjectConnection(string projectConnectionId = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesWebSearchApproximateLocation ResponsesWebSearchApproximateLocation(string country = null, string region = null, string city = null, string timezone = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ResponsesWebSearchConfiguration ResponsesWebSearchConfiguration(string projectConnectionId = null, string instanceName = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Extensions.OpenAI.ResponsesWorkIQPreviewTool ResponsesWorkIQPreviewTool(string projectConnectionId = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Extensions.OpenAI.SharePointGroundingToolCall SharePointGroundingToolCall(string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, string arguments = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        public static Azure.AI.Extensions.OpenAI.SharepointGroundingToolCall SharepointGroundingToolCall(string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, string arguments = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Extensions.OpenAI.SharePointGroundingToolCallOutput SharePointGroundingToolCallOutput(string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, System.BinaryData output = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        public static Azure.AI.Extensions.OpenAI.SharepointGroundingToolCallOutput SharepointGroundingToolCallOutput(string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, System.BinaryData output = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Extensions.OpenAI.SharePointGroundingToolOptions SharePointGroundingToolOptions(System.Collections.Generic.IEnumerable<Azure.AI.Extensions.OpenAI.ResponsesToolProjectConnection> projectConnections = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ToolConfig ToolConfig(bool? pin = default(bool?), string additionalSearchText = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Extensions.OpenAI.UserProfileMemoryItem UserProfileMemoryItem(string memoryId = null, System.DateTimeOffset updatedAt = default(System.DateTimeOffset), string scope = null, string content = null) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class FabricDataAgentToolCall : Azure.AI.Extensions.OpenAI.AgentResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.FabricDataAgentToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.FabricDataAgentToolCall>
    {
        public FabricDataAgentToolCall(string callId, string arguments, Azure.AI.Extensions.OpenAI.ToolCallStatus status) { }
        public string Arguments { get { throw null; } set { } }
        public string CallId { get { throw null; } set { } }
        public Azure.AI.Extensions.OpenAI.ToolCallStatus Status { get { throw null; } set { } }
        protected override Azure.AI.Extensions.OpenAI.AgentResponseItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Extensions.OpenAI.AgentResponseItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.FabricDataAgentToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.FabricDataAgentToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.FabricDataAgentToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.FabricDataAgentToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.FabricDataAgentToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.FabricDataAgentToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.FabricDataAgentToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class FabricDataAgentToolCallOutput : Azure.AI.Extensions.OpenAI.AgentResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.FabricDataAgentToolCallOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.FabricDataAgentToolCallOutput>
    {
        public FabricDataAgentToolCallOutput(string callId, Azure.AI.Extensions.OpenAI.ToolCallStatus status) { }
        public string CallId { get { throw null; } set { } }
        public System.BinaryData Output { get { throw null; } set { } }
        public Azure.AI.Extensions.OpenAI.ToolCallStatus Status { get { throw null; } set { } }
        protected override Azure.AI.Extensions.OpenAI.AgentResponseItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Extensions.OpenAI.AgentResponseItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential, Size=1)]
    public readonly partial struct ItemLocalShellToolCallOutputStatus
    {
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class MemoryCommandToolCall : Azure.AI.Extensions.OpenAI.AgentResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.MemoryCommandToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.MemoryCommandToolCall>
    {
        public MemoryCommandToolCall(string callId, string arguments, Azure.AI.Extensions.OpenAI.ToolCallStatus status) { }
        public string Arguments { get { throw null; } set { } }
        public string CallId { get { throw null; } set { } }
        public Azure.AI.Extensions.OpenAI.ToolCallStatus Status { get { throw null; } set { } }
        protected override Azure.AI.Extensions.OpenAI.AgentResponseItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Extensions.OpenAI.AgentResponseItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.MemoryCommandToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.MemoryCommandToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.MemoryCommandToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.MemoryCommandToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.MemoryCommandToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.MemoryCommandToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.MemoryCommandToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class MemoryCommandToolCallOutput : Azure.AI.Extensions.OpenAI.AgentResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.MemoryCommandToolCallOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.MemoryCommandToolCallOutput>
    {
        public MemoryCommandToolCallOutput(string callId, Azure.AI.Extensions.OpenAI.ToolCallStatus status) { }
        public string CallId { get { throw null; } set { } }
        public Azure.AI.Extensions.OpenAI.ToolCallStatus Status { get { throw null; } set { } }
        protected override Azure.AI.Extensions.OpenAI.AgentResponseItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Extensions.OpenAI.AgentResponseItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class MemorySearchToolCall : Azure.AI.Extensions.OpenAI.AgentResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.MemorySearchToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.MemorySearchToolCall>
    {
        public MemorySearchToolCall(Azure.AI.Extensions.OpenAI.ToolCallStatus status) { }
        public System.Collections.Generic.IList<Azure.AI.Extensions.OpenAI.MemoryOutputItem> Memories { get { throw null; } set { } }
        public Azure.AI.Extensions.OpenAI.ToolCallStatus Status { get { throw null; } set { } }
        protected override Azure.AI.Extensions.OpenAI.AgentResponseItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Extensions.OpenAI.AgentResponseItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.MemorySearchToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.MemorySearchToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.MemorySearchToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.MemorySearchToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.MemorySearchToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.MemorySearchToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.MemorySearchToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OAuthConsentRequestResponseItem : Azure.AI.Extensions.OpenAI.AgentResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.OAuthConsentRequestResponseItem>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.OAuthConsentRequestResponseItem>
    {
        public OAuthConsentRequestResponseItem(string consentLink, string serverLabel) { }
        public OAuthConsentRequestResponseItem(System.Uri consentLink, string serverLabel) { }
        public System.Uri ConsentLink { get { throw null; } }
        public string ServerLabel { get { throw null; } set { } }
        protected override Azure.AI.Extensions.OpenAI.AgentResponseItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Extensions.OpenAI.AgentResponseItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.OAuthConsentRequestResponseItem System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.OAuthConsentRequestResponseItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.OAuthConsentRequestResponseItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.OAuthConsentRequestResponseItem System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.OAuthConsentRequestResponseItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.OAuthConsentRequestResponseItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.OAuthConsentRequestResponseItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OpenApiAnonymousAuthenticationDetails : Azure.AI.Extensions.OpenAI.OpenApiAuthenticationDetails, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.OpenApiAnonymousAuthenticationDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.OpenApiAnonymousAuthenticationDetails>
    {
        public OpenApiAnonymousAuthenticationDetails() { }
        protected override Azure.AI.Extensions.OpenAI.OpenApiAuthenticationDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Extensions.OpenAI.OpenApiAuthenticationDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.OpenApiAnonymousAuthenticationDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.OpenApiAnonymousAuthenticationDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.OpenApiAnonymousAuthenticationDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.OpenApiAnonymousAuthenticationDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.OpenApiAnonymousAuthenticationDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.OpenApiAnonymousAuthenticationDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.OpenApiAnonymousAuthenticationDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class OpenApiManagedAuthenticationDetails : Azure.AI.Extensions.OpenAI.OpenApiAuthenticationDetails, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.OpenApiManagedAuthenticationDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.OpenApiManagedAuthenticationDetails>
    {
        public OpenApiManagedAuthenticationDetails(Azure.AI.Extensions.OpenAI.ResponsesOpenApiManagedSecurityScheme securityScheme) { }
        public Azure.AI.Extensions.OpenAI.ResponsesOpenApiManagedSecurityScheme SecurityScheme { get { throw null; } set { } }
        protected override Azure.AI.Extensions.OpenAI.OpenApiAuthenticationDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Extensions.OpenAI.OpenApiAuthenticationDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.OpenApiManagedAuthenticationDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.OpenApiManagedAuthenticationDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.OpenApiManagedAuthenticationDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.OpenApiManagedAuthenticationDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.OpenApiManagedAuthenticationDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.OpenApiManagedAuthenticationDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.OpenApiManagedAuthenticationDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OpenApiProjectConnectionAuthenticationDetails : Azure.AI.Extensions.OpenAI.OpenApiAuthenticationDetails, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.OpenApiProjectConnectionAuthenticationDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.OpenApiProjectConnectionAuthenticationDetails>
    {
        public OpenApiProjectConnectionAuthenticationDetails(Azure.AI.Extensions.OpenAI.ResponsesOpenApiProjectConnectionSecurityScheme securityScheme) { }
        public Azure.AI.Extensions.OpenAI.ResponsesOpenApiProjectConnectionSecurityScheme SecurityScheme { get { throw null; } set { } }
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
    public partial class OpenApiToolCall : Azure.AI.Extensions.OpenAI.AgentResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.OpenApiToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.OpenApiToolCall>
    {
        public OpenApiToolCall(string callId, string name, string arguments, Azure.AI.Extensions.OpenAI.ToolCallStatus status) { }
        public string Arguments { get { throw null; } set { } }
        public string CallId { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.AI.Extensions.OpenAI.ToolCallStatus Status { get { throw null; } set { } }
        protected override Azure.AI.Extensions.OpenAI.AgentResponseItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Extensions.OpenAI.AgentResponseItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.OpenApiToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.OpenApiToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.OpenApiToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.OpenApiToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.OpenApiToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.OpenApiToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.OpenApiToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OpenApiToolCallOutput : Azure.AI.Extensions.OpenAI.AgentResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.OpenApiToolCallOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.OpenApiToolCallOutput>
    {
        public OpenApiToolCallOutput(string callId, string name, Azure.AI.Extensions.OpenAI.ToolCallStatus status) { }
        public string CallId { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.BinaryData Output { get { throw null; } set { } }
        public Azure.AI.Extensions.OpenAI.ToolCallStatus Status { get { throw null; } set { } }
        protected override Azure.AI.Extensions.OpenAI.AgentResponseItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Extensions.OpenAI.AgentResponseItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class ProjectConversation : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ProjectConversation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ProjectConversation>
    {
        internal ProjectConversation() { }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        protected virtual Azure.AI.Extensions.OpenAI.ProjectConversation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Extensions.OpenAI.ProjectConversation (System.ClientModel.ClientResult result) { throw null; }
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
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Extensions.OpenAI.ProjectConversation>> CreateProjectConversationAsync(Azure.AI.Extensions.OpenAI.ProjectConversationCreationOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult<System.Collections.ObjectModel.ReadOnlyCollection<OpenAI.Responses.ResponseItem>> CreateProjectConversationItems(string conversationId, System.Collections.Generic.IEnumerable<OpenAI.Responses.ResponseItem> items, System.Collections.Generic.IEnumerable<OpenAI.Conversations.IncludedConversationItemProperty> include = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<System.Collections.ObjectModel.ReadOnlyCollection<OpenAI.Responses.ResponseItem>>> CreateProjectConversationItemsAsync(string conversationId, System.Collections.Generic.IEnumerable<OpenAI.Responses.ResponseItem> items, System.Collections.Generic.IEnumerable<OpenAI.Conversations.IncludedConversationItemProperty> include = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Extensions.OpenAI.ProjectConversation> GetProjectConversation(string conversationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Extensions.OpenAI.ProjectConversation>> GetProjectConversationAsync(string conversationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Extensions.OpenAI.AgentResponseItem> GetProjectConversationItem(string conversationId, string itemId, System.Collections.Generic.IEnumerable<OpenAI.Conversations.IncludedConversationItemProperty> include = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Extensions.OpenAI.AgentResponseItem>> GetProjectConversationItemAsync(string conversationId, string itemId, System.Collections.Generic.IEnumerable<OpenAI.Conversations.IncludedConversationItemProperty> include = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Extensions.OpenAI.AgentResponseItem> GetProjectConversationItems(string conversationId, Azure.AI.Extensions.OpenAI.AgentResponseItemKind? itemKind = default(Azure.AI.Extensions.OpenAI.AgentResponseItemKind?), int? limit = default(int?), string order = null, string after = null, string before = null, System.Collections.Generic.IEnumerable<OpenAI.Conversations.IncludedConversationItemProperty> include = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Extensions.OpenAI.AgentResponseItem> GetProjectConversationItemsAsync(string conversationId, Azure.AI.Extensions.OpenAI.AgentResponseItemKind? itemKind = default(Azure.AI.Extensions.OpenAI.AgentResponseItemKind?), int? limit = default(int?), string order = null, string after = null, string before = null, System.Collections.Generic.IEnumerable<OpenAI.Conversations.IncludedConversationItemProperty> include = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Extensions.OpenAI.ProjectConversation> GetProjectConversations(Azure.AI.Extensions.OpenAI.AgentReference agent = null, int? limit = default(int?), string order = null, string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Extensions.OpenAI.ProjectConversation> GetProjectConversationsAsync(Azure.AI.Extensions.OpenAI.AgentReference agent = null, int? limit = default(int?), string order = null, string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Extensions.OpenAI.ProjectConversation> UpdateProjectConversation(string conversationId, Azure.AI.Extensions.OpenAI.ProjectConversationUpdateOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public ProjectResponsesClient(System.ClientModel.AuthenticationTokenProvider tokenProvider, Azure.AI.Extensions.OpenAI.ProjectResponsesClientOptions options) { }
        public ProjectResponsesClient(System.ClientModel.AuthenticationTokenProvider tokenProvider, Azure.AI.Extensions.OpenAI.ProjectResponsesClientOptions options = null, Azure.AI.Extensions.OpenAI.AgentReference defaultAgent = null, string defaultConversationId = null) { }
        public ProjectResponsesClient(System.Uri projectEndpoint, System.ClientModel.AuthenticationTokenProvider tokenProvider, Azure.AI.Extensions.OpenAI.AgentReference defaultAgent, string defaultConversationId = null, Azure.AI.Extensions.OpenAI.ProjectResponsesClientOptions options = null) { }
        public ProjectResponsesClient(System.Uri projectEndpoint, System.ClientModel.AuthenticationTokenProvider tokenProvider, Azure.AI.Extensions.OpenAI.ProjectResponsesClientOptions options = null) { }
        public override System.ClientModel.ClientResult<OpenAI.Responses.ResponseResult> CreateResponse(OpenAI.Responses.CreateResponseOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult<OpenAI.Responses.ResponseResult> CreateResponse(System.Collections.Generic.IEnumerable<OpenAI.Responses.ResponseItem> inputItems, string previousResponseId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.ClientModel.ClientResult<OpenAI.Responses.ResponseResult> CreateResponse(string model, System.Collections.Generic.IEnumerable<OpenAI.Responses.ResponseItem> inputItems, string previousResponseId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.ClientModel.ClientResult<OpenAI.Responses.ResponseResult> CreateResponse(string model, string userInputText, string previousResponseId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult<OpenAI.Responses.ResponseResult> CreateResponse(string userInputText, string previousResponseId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.Task<System.ClientModel.ClientResult<OpenAI.Responses.ResponseResult>> CreateResponseAsync(OpenAI.Responses.CreateResponseOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<OpenAI.Responses.ResponseResult>> CreateResponseAsync(System.Collections.Generic.IEnumerable<OpenAI.Responses.ResponseItem> inputItems, string previousResponseId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.Task<System.ClientModel.ClientResult<OpenAI.Responses.ResponseResult>> CreateResponseAsync(string model, System.Collections.Generic.IEnumerable<OpenAI.Responses.ResponseItem> inputItems, string previousResponseId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.Task<System.ClientModel.ClientResult<OpenAI.Responses.ResponseResult>> CreateResponseAsync(string model, string userInputText, string previousResponseId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class ResponsesA2APreviewTool : Azure.AI.Extensions.OpenAI.ResponsesTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesA2APreviewTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesA2APreviewTool>
    {
        public ResponsesA2APreviewTool() { }
        public string AgentCardPath { get { throw null; } set { } }
        public System.Uri BaseUri { get { throw null; } set { } }
        public string ProjectConnectionId { get { throw null; } set { } }
        public bool? SendCredentialsForAgentCard { get { throw null; } set { } }
        protected override Azure.AI.Extensions.OpenAI.ResponsesTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Extensions.OpenAI.ResponsesTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.ResponsesA2APreviewTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesA2APreviewTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesA2APreviewTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.ResponsesA2APreviewTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesA2APreviewTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesA2APreviewTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesA2APreviewTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResponsesAISearchIndexResource
    {
        public ResponsesAISearchIndexResource() { }
    }
    public partial class ResponsesAutoCodeInterpreterToolParam
    {
        public ResponsesAutoCodeInterpreterToolParam() { }
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
    public partial class ResponsesAzureAISearchTool : Azure.AI.Extensions.OpenAI.ResponsesTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesAzureAISearchTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesAzureAISearchTool>
    {
        public ResponsesAzureAISearchTool(Azure.AI.Extensions.OpenAI.AzureAISearchToolOptions azureAISearch) { }
        public Azure.AI.Extensions.OpenAI.AzureAISearchToolOptions AzureAISearch { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.AI.Extensions.OpenAI.ToolConfig> ToolConfigs { get { throw null; } }
        protected override Azure.AI.Extensions.OpenAI.ResponsesTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Extensions.OpenAI.ResponsesTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.ResponsesAzureAISearchTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesAzureAISearchTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesAzureAISearchTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.ResponsesAzureAISearchTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesAzureAISearchTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesAzureAISearchTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesAzureAISearchTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResponsesAzureAISearchToolResource
    {
        public ResponsesAzureAISearchToolResource() { }
    }
    public partial class ResponsesAzureFunctionBinding : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesAzureFunctionBinding>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesAzureFunctionBinding>
    {
        public ResponsesAzureFunctionBinding(Azure.AI.Extensions.OpenAI.ResponsesAzureFunctionStorageQueue storageQueue) { }
        public string Kind { get { throw null; } }
        public Azure.AI.Extensions.OpenAI.ResponsesAzureFunctionStorageQueue StorageQueue { get { throw null; } set { } }
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
        public ResponsesAzureFunctionDefinition(Azure.AI.Extensions.OpenAI.ResponsesAzureFunctionDefinitionFunction function, Azure.AI.Extensions.OpenAI.ResponsesAzureFunctionBinding inputBinding, Azure.AI.Extensions.OpenAI.ResponsesAzureFunctionBinding outputBinding) { }
        public Azure.AI.Extensions.OpenAI.ResponsesAzureFunctionDefinitionFunction Function { get { throw null; } set { } }
        public Azure.AI.Extensions.OpenAI.ResponsesAzureFunctionBinding InputBinding { get { throw null; } set { } }
        public Azure.AI.Extensions.OpenAI.ResponsesAzureFunctionBinding OutputBinding { get { throw null; } set { } }
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
        public ResponsesAzureFunctionDefinitionFunction(string name, System.Collections.Generic.IDictionary<string, System.BinaryData> parameters) { }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
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
        public ResponsesAzureFunctionStorageQueue(string queueServiceEndpoint, string queueName) { }
        public string QueueName { get { throw null; } set { } }
        public string QueueServiceEndpoint { get { throw null; } set { } }
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
    public partial class ResponsesAzureFunctionTool : Azure.AI.Extensions.OpenAI.ResponsesTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesAzureFunctionTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesAzureFunctionTool>
    {
        public ResponsesAzureFunctionTool(Azure.AI.Extensions.OpenAI.ResponsesAzureFunctionDefinition azureFunction) { }
        public Azure.AI.Extensions.OpenAI.ResponsesAzureFunctionDefinition AzureFunction { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.AI.Extensions.OpenAI.ToolConfig> ToolConfigs { get { throw null; } }
        protected override Azure.AI.Extensions.OpenAI.ResponsesTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Extensions.OpenAI.ResponsesTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.ResponsesAzureFunctionTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesAzureFunctionTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesAzureFunctionTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.ResponsesAzureFunctionTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesAzureFunctionTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesAzureFunctionTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesAzureFunctionTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResponsesBingCustomSearchConfiguration
    {
        public ResponsesBingCustomSearchConfiguration() { }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class ResponsesBingCustomSearchPreviewTool : Azure.AI.Extensions.OpenAI.ResponsesTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesBingCustomSearchPreviewTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesBingCustomSearchPreviewTool>
    {
        public ResponsesBingCustomSearchPreviewTool(Azure.AI.Extensions.OpenAI.BingCustomSearchToolOptions bingCustomSearchPreview) { }
        public Azure.AI.Extensions.OpenAI.BingCustomSearchToolOptions BingCustomSearchPreview { get { throw null; } set { } }
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
    public partial class ResponsesBingCustomSearchToolParameters
    {
        public ResponsesBingCustomSearchToolParameters() { }
    }
    public partial class ResponsesBingGroundingSearchConfiguration
    {
        public ResponsesBingGroundingSearchConfiguration() { }
    }
    public partial class ResponsesBingGroundingSearchToolParameters
    {
        public ResponsesBingGroundingSearchToolParameters() { }
    }
    public partial class ResponsesBingGroundingTool : Azure.AI.Extensions.OpenAI.ResponsesTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesBingGroundingTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesBingGroundingTool>
    {
        public ResponsesBingGroundingTool(Azure.AI.Extensions.OpenAI.BingGroundingSearchToolOptions bingGrounding) { }
        public Azure.AI.Extensions.OpenAI.BingGroundingSearchToolOptions BingGrounding { get { throw null; } set { } }
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
        public ResponsesBrowserAutomationPreviewTool(Azure.AI.Extensions.OpenAI.BrowserAutomationToolOptions browserAutomationPreview) { }
        public Azure.AI.Extensions.OpenAI.BrowserAutomationToolOptions BrowserAutomationPreview { get { throw null; } set { } }
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
    public partial class ResponsesBrowserAutomationToolParameters
    {
        public ResponsesBrowserAutomationToolParameters() { }
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
    public partial class ResponsesComputerTool
    {
        public ResponsesComputerTool() { }
    }
    public partial class ResponsesContainerAutoParam : Azure.AI.Extensions.OpenAI.ResponsesFunctionShellToolParamEnvironment, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesContainerAutoParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesContainerAutoParam>
    {
        internal ResponsesContainerAutoParam() { }
        public System.Collections.Generic.IList<string> FileIds { get { throw null; } }
        public Azure.AI.Extensions.OpenAI.ResponsesContainerMemoryLimit? MemoryLimit { get { throw null; } }
        public Azure.AI.Extensions.OpenAI.ResponsesContainerNetworkPolicyParam NetworkPolicy { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Extensions.OpenAI.Internal.ContainerSkill> Skills { get { throw null; } }
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
        internal ResponsesContainerNetworkPolicyAllowlistParam() { }
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
        internal ResponsesContainerNetworkPolicyDisabledParam() { }
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
        internal ResponsesContainerNetworkPolicyDomainSecretParam() { }
        public string Domain { get { throw null; } }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } }
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
    public partial class ResponsesContainerNetworkPolicyParam : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesContainerNetworkPolicyParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesContainerNetworkPolicyParam>
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
        internal ResponsesCustomTextFormatParam() { }
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
    public partial class ResponsesCustomToolParam
    {
        public ResponsesCustomToolParam() { }
    }
    public partial class ResponsesCustomToolParamFormat : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesCustomToolParamFormat>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesCustomToolParamFormat>
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
    public partial class ResponsesFunctionShellToolParam
    {
        public ResponsesFunctionShellToolParam() { }
    }
    public partial class ResponsesFunctionShellToolParamEnvironment : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesFunctionShellToolParamEnvironment>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesFunctionShellToolParamEnvironment>
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
        internal ResponsesFunctionShellToolParamEnvironmentContainerReferenceParam() { }
        public string ContainerId { get { throw null; } }
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
        internal ResponsesFunctionShellToolParamEnvironmentLocalEnvironmentParam() { }
        public System.Collections.Generic.IList<Azure.AI.Extensions.OpenAI.Internal.LocalSkillParam> Skills { get { throw null; } }
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
        public bool? DeferLoading { get { throw null; } }
        public string Description { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.AI.Extensions.OpenAI.ResponsesEmptyModelParam Parameters { get { throw null; } }
        public bool? Strict { get { throw null; } }
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
    public partial class ResponsesInlineSkillParam : Azure.AI.Extensions.OpenAI.Internal.ContainerSkill, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesInlineSkillParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesInlineSkillParam>
    {
        internal ResponsesInlineSkillParam() { }
        public string Description { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.AI.Extensions.OpenAI.ResponsesInlineSkillSourceParam Source { get { throw null; } }
        protected override Azure.AI.Extensions.OpenAI.Internal.ContainerSkill JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Extensions.OpenAI.Internal.ContainerSkill PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.ResponsesInlineSkillParam System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesInlineSkillParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesInlineSkillParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.ResponsesInlineSkillParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesInlineSkillParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesInlineSkillParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesInlineSkillParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResponsesInlineSkillSourceParam : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesInlineSkillSourceParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesInlineSkillSourceParam>
    {
        internal ResponsesInlineSkillSourceParam() { }
        public string Data { get { throw null; } }
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
    public partial class ResponsesLocalShellToolParam
    {
        public ResponsesLocalShellToolParam() { }
    }
    public partial class ResponsesMCPToolFilter
    {
        public ResponsesMCPToolFilter() { }
    }
    public partial class ResponsesMCPToolRequireApproval
    {
        public ResponsesMCPToolRequireApproval() { }
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
        public ResponsesMicrosoftFabricPreviewTool(Azure.AI.Extensions.OpenAI.ResponsesFabricDataAgentToolOptions toolOptions) { }
        public Azure.AI.Extensions.OpenAI.ResponsesFabricDataAgentToolOptions ToolOptions { get { throw null; } set { } }
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
    public partial class ResponsesNamespaceToolParam
    {
        public ResponsesNamespaceToolParam() { }
    }
    public partial class ResponsesOpenApiAnonymousAuthDetails
    {
        public ResponsesOpenApiAnonymousAuthDetails() { }
    }
    public abstract partial class ResponsesOpenApiAuthDetails
    {
        protected ResponsesOpenApiAuthDetails() { }
    }
    public partial class ResponsesOpenApiFunctionDefinition : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesOpenApiFunctionDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesOpenApiFunctionDefinition>
    {
        public ResponsesOpenApiFunctionDefinition(string name, System.Collections.Generic.IDictionary<string, System.BinaryData> specification, Azure.AI.Extensions.OpenAI.OpenApiAuthenticationDetails authentication) { }
        public Azure.AI.Extensions.OpenAI.OpenApiAuthenticationDetails Authentication { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> DefaultParameters { get { throw null; } }
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
    public partial class ResponsesOpenApiManagedAuthDetails
    {
        public ResponsesOpenApiManagedAuthDetails() { }
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
    public partial class ResponsesOpenApiProjectConnectionAuthDetails
    {
        public ResponsesOpenApiProjectConnectionAuthDetails() { }
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
        public ResponsesOpenApiTool(Azure.AI.Extensions.OpenAI.ResponsesOpenApiFunctionDefinition functionDefinition) { }
        public Azure.AI.Extensions.OpenAI.ResponsesOpenApiFunctionDefinition FunctionDefinition { get { throw null; } set { } }
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
    public partial class ResponsesSharepointGroundingToolParameters
    {
        public ResponsesSharepointGroundingToolParameters() { }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class ResponsesSharepointPreviewTool : Azure.AI.Extensions.OpenAI.ResponsesTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesSharepointPreviewTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesSharepointPreviewTool>
    {
        public ResponsesSharepointPreviewTool(Azure.AI.Extensions.OpenAI.SharePointGroundingToolOptions toolOptions) { }
        public Azure.AI.Extensions.OpenAI.SharePointGroundingToolOptions ToolOptions { get { throw null; } set { } }
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
    public partial class ResponsesSkillReferenceParam : Azure.AI.Extensions.OpenAI.Internal.ContainerSkill, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.ResponsesSkillReferenceParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.ResponsesSkillReferenceParam>
    {
        internal ResponsesSkillReferenceParam() { }
        public string SkillId { get { throw null; } }
        public string Version { get { throw null; } }
        protected override Azure.AI.Extensions.OpenAI.Internal.ContainerSkill JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Extensions.OpenAI.Internal.ContainerSkill PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public OpenAI.Responses.ResponseTool AsResponseTool() { throw null; }
        protected virtual Azure.AI.Extensions.OpenAI.ResponsesTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator OpenAI.Responses.ResponseTool (Azure.AI.Extensions.OpenAI.ResponsesTool tool) { throw null; }
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
    public partial class ResponsesToolSearchToolParam
    {
        public ResponsesToolSearchToolParam() { }
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
    public partial class ResponsesWebSearchTool
    {
        public ResponsesWebSearchTool() { }
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
        public string Arguments { get { throw null; } set { } }
        public string CallId { get { throw null; } set { } }
        public Azure.AI.Extensions.OpenAI.ToolCallStatus Status { get { throw null; } set { } }
        protected override Azure.AI.Extensions.OpenAI.AgentResponseItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Extensions.OpenAI.AgentResponseItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.SharepointGroundingToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.SharepointGroundingToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.SharepointGroundingToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.SharepointGroundingToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.SharepointGroundingToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.SharepointGroundingToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.SharepointGroundingToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class SharePointGroundingToolCall : Azure.AI.Extensions.OpenAI.AgentResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.SharePointGroundingToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.SharePointGroundingToolCall>
    {
        public SharePointGroundingToolCall(string callId, string arguments, Azure.AI.Extensions.OpenAI.ToolCallStatus status) { }
        public string Arguments { get { throw null; } set { } }
        public string CallId { get { throw null; } set { } }
        public Azure.AI.Extensions.OpenAI.ToolCallStatus Status { get { throw null; } set { } }
        protected override Azure.AI.Extensions.OpenAI.AgentResponseItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Extensions.OpenAI.AgentResponseItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.SharePointGroundingToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.SharePointGroundingToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.SharePointGroundingToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.SharePointGroundingToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.SharePointGroundingToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.SharePointGroundingToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.SharePointGroundingToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class SharePointGroundingToolCallOutput : Azure.AI.Extensions.OpenAI.AgentResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.SharePointGroundingToolCallOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.SharePointGroundingToolCallOutput>
    {
        public SharePointGroundingToolCallOutput(string callId, Azure.AI.Extensions.OpenAI.ToolCallStatus status) { }
        public string CallId { get { throw null; } set { } }
        public System.BinaryData Output { get { throw null; } set { } }
        public Azure.AI.Extensions.OpenAI.ToolCallStatus Status { get { throw null; } set { } }
        protected override Azure.AI.Extensions.OpenAI.AgentResponseItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Extensions.OpenAI.AgentResponseItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.SharePointGroundingToolCallOutput System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.SharePointGroundingToolCallOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.SharePointGroundingToolCallOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.SharePointGroundingToolCallOutput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.SharePointGroundingToolCallOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.SharePointGroundingToolCallOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.SharePointGroundingToolCallOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class SharepointGroundingToolCallOutput : Azure.AI.Extensions.OpenAI.AgentResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.SharepointGroundingToolCallOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.SharepointGroundingToolCallOutput>
    {
        public SharepointGroundingToolCallOutput(string callId, Azure.AI.Extensions.OpenAI.ToolCallStatus status) { }
        public string CallId { get { throw null; } set { } }
        public System.BinaryData Output { get { throw null; } set { } }
        public Azure.AI.Extensions.OpenAI.ToolCallStatus Status { get { throw null; } set { } }
        protected override Azure.AI.Extensions.OpenAI.AgentResponseItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Extensions.OpenAI.AgentResponseItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.SharepointGroundingToolCallOutput System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.SharepointGroundingToolCallOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.SharepointGroundingToolCallOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.SharepointGroundingToolCallOutput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.SharepointGroundingToolCallOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.SharepointGroundingToolCallOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.SharepointGroundingToolCallOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class SharePointGroundingToolOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.SharePointGroundingToolOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.SharePointGroundingToolOptions>
    {
        public SharePointGroundingToolOptions() { }
        public System.Collections.Generic.IList<Azure.AI.Extensions.OpenAI.ResponsesToolProjectConnection> ProjectConnections { get { throw null; } }
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
}
namespace Azure.AI.Extensions.OpenAI.Internal
{
    public partial class ContainerSkill : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.Internal.ContainerSkill>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.Internal.ContainerSkill>
    {
        internal ContainerSkill() { }
        protected virtual Azure.AI.Extensions.OpenAI.Internal.ContainerSkill JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Extensions.OpenAI.Internal.ContainerSkill PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.Internal.ContainerSkill System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.Internal.ContainerSkill>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.Internal.ContainerSkill>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.Internal.ContainerSkill System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.Internal.ContainerSkill>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.Internal.ContainerSkill>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.Internal.ContainerSkill>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomGrammarFormatParam : Azure.AI.Extensions.OpenAI.ResponsesCustomToolParamFormat, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.Internal.CustomGrammarFormatParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.Internal.CustomGrammarFormatParam>
    {
        internal CustomGrammarFormatParam() { }
        public string Definition { get { throw null; } }
        public Azure.AI.Extensions.OpenAI.ResponsesGrammarSyntax Syntax { get { throw null; } }
        protected override Azure.AI.Extensions.OpenAI.ResponsesCustomToolParamFormat JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Extensions.OpenAI.ResponsesCustomToolParamFormat PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.Internal.CustomGrammarFormatParam System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.Internal.CustomGrammarFormatParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.Internal.CustomGrammarFormatParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.Internal.CustomGrammarFormatParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.Internal.CustomGrammarFormatParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.Internal.CustomGrammarFormatParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.Internal.CustomGrammarFormatParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LocalSkillParam : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.Internal.LocalSkillParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.Internal.LocalSkillParam>
    {
        internal LocalSkillParam() { }
        public string Description { get { throw null; } }
        public string Name { get { throw null; } }
        public string Path { get { throw null; } }
        protected virtual Azure.AI.Extensions.OpenAI.Internal.LocalSkillParam JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Extensions.OpenAI.Internal.LocalSkillParam PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.Internal.LocalSkillParam System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.Internal.LocalSkillParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.Internal.LocalSkillParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.Internal.LocalSkillParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.Internal.LocalSkillParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.Internal.LocalSkillParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.Internal.LocalSkillParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
            [System.Runtime.CompilerServices.ExtensionMarkerAttribute("<M>$781747A4149937EE6CD40CB5B8268DAD")]
            public Azure.AI.Extensions.OpenAI.ProjectOpenAIClient GetProjectOpenAIClient(Azure.AI.Extensions.OpenAI.ProjectOpenAIClientOptions options = null) { throw null; }
            public static partial class <M>$781747A4149937EE6CD40CB5B8268DAD
            {
                public static void <Extension>$(System.ClientModel.Primitives.ClientConnectionProvider connectionProvider) { }
            }
        }
    }
}
