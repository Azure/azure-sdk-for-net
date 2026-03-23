namespace Azure.AI.Extensions.OpenAI
{
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
        public static Azure.AI.Extensions.OpenAI.AgentResponseItemKind CustomToolCall { get { throw null; } }
        public static Azure.AI.Extensions.OpenAI.AgentResponseItemKind FabricDataagentPreviewCall { get { throw null; } }
        public static Azure.AI.Extensions.OpenAI.AgentResponseItemKind FabricDataagentPreviewCallOutput { get { throw null; } }
        public static Azure.AI.Extensions.OpenAI.AgentResponseItemKind FileSearchCall { get { throw null; } }
        public static Azure.AI.Extensions.OpenAI.AgentResponseItemKind FunctionCall { get { throw null; } }
        public static Azure.AI.Extensions.OpenAI.AgentResponseItemKind ImageGenerationCall { get { throw null; } }
        public static Azure.AI.Extensions.OpenAI.AgentResponseItemKind LocalShellCall { get { throw null; } }
        public static Azure.AI.Extensions.OpenAI.AgentResponseItemKind McpApprovalRequest { get { throw null; } }
        public static Azure.AI.Extensions.OpenAI.AgentResponseItemKind McpCall { get { throw null; } }
        public static Azure.AI.Extensions.OpenAI.AgentResponseItemKind McpListTools { get { throw null; } }
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
        public static Azure.AI.Extensions.OpenAI.AgentResponseItemKind WebSearchCall { get { throw null; } }
        public static Azure.AI.Extensions.OpenAI.AgentResponseItemKind WorkflowAction { get { throw null; } }
        public bool Equals(Azure.AI.Extensions.OpenAI.AgentResponseItemKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Extensions.OpenAI.AgentResponseItemKind left, Azure.AI.Extensions.OpenAI.AgentResponseItemKind right) { throw null; }
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
        public static Azure.AI.Extensions.OpenAI.ExtraDataDictionary get_StructuredInputs(OpenAI.Responses.CreateResponseOptions options) { throw null; }
        public static void set_Agent(OpenAI.Responses.CreateResponseOptions options, Azure.AI.Extensions.OpenAI.AgentReference value) { }
        public static void set_AgentConversationId(OpenAI.Responses.CreateResponseOptions options, string value) { }
        public sealed partial class <G>$9441C364D6D7BED1E759B10623E362FD
        {
            internal <G>$9441C364D6D7BED1E759B10623E362FD() { }
            public Azure.AI.Extensions.OpenAI.AgentReference Agent { get { throw null; } set { } }
            public string AgentConversationId { get { throw null; } set { } }
            public Azure.AI.Extensions.OpenAI.ExtraDataDictionary StructuredInputs { get { throw null; } }
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
        public static Azure.AI.Extensions.OpenAI.A2AToolCall A2AToolCall(string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, string name = null, string arguments = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        public static Azure.AI.Extensions.OpenAI.A2AToolCallOutput A2AToolCallOutput(string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, string name = null, System.BinaryData output = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        public static Azure.AI.Extensions.OpenAI.AgentReference AgentReference(string name = null, string version = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.AgentResponseItem AgentResponseItem(string type = null, string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.AgentStructuredOutputsResponseItem AgentStructuredOutputsResponseItem(string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, System.BinaryData output = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.AgentWorkflowPreviewActionResponseItem AgentWorkflowPreviewActionResponseItem(string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string kind = null, string actionId = null, string parentActionId = null, string previousActionId = null, Azure.AI.Extensions.OpenAI.AgentWorkflowPreviewActionStatus? status = default(Azure.AI.Extensions.OpenAI.AgentWorkflowPreviewActionStatus?)) { throw null; }
        public static Azure.AI.Extensions.OpenAI.AzureAISearchToolCall AzureAISearchToolCall(string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, string arguments = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        public static Azure.AI.Extensions.OpenAI.AzureAISearchToolCallOutput AzureAISearchToolCallOutput(string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, System.BinaryData output = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        public static Azure.AI.Extensions.OpenAI.AzureFunctionToolCall AzureFunctionToolCall(string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, string name = null, string arguments = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        public static Azure.AI.Extensions.OpenAI.AzureFunctionToolCallOutput AzureFunctionToolCallOutput(string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, string name = null, System.BinaryData output = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        public static Azure.AI.Extensions.OpenAI.BingCustomSearchToolCall BingCustomSearchToolCall(string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, string arguments = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        public static Azure.AI.Extensions.OpenAI.BingCustomSearchToolCallOutput BingCustomSearchToolCallOutput(string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, System.BinaryData output = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        public static Azure.AI.Extensions.OpenAI.BingGroundingToolCall BingGroundingToolCall(string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, string arguments = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        public static Azure.AI.Extensions.OpenAI.BingGroundingToolCallOutput BingGroundingToolCallOutput(string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, System.BinaryData output = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        public static Azure.AI.Extensions.OpenAI.BrowserAutomationToolCall BrowserAutomationToolCall(string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, string arguments = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        public static Azure.AI.Extensions.OpenAI.BrowserAutomationToolCallOutput BrowserAutomationToolCallOutput(string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, System.BinaryData output = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ChatSummaryMemoryItem ChatSummaryMemoryItem(string memoryId = null, System.DateTimeOffset updatedAt = default(System.DateTimeOffset), string scope = null, string content = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.FabricDataAgentToolCall FabricDataAgentToolCall(string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, string arguments = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        public static Azure.AI.Extensions.OpenAI.FabricDataAgentToolCallOutput FabricDataAgentToolCallOutput(string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, System.BinaryData output = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        public static Azure.AI.Extensions.OpenAI.MemoryOutputItem MemoryOutputItem(string memoryId = null, System.DateTimeOffset updatedAt = default(System.DateTimeOffset), string scope = null, string content = null, string kind = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.MemorySearchItem MemorySearchItem(Azure.AI.Extensions.OpenAI.MemoryOutputItem memoryItem = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.MemorySearchToolCallResponseItem MemorySearchToolCallResponseItem(string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, Azure.AI.Extensions.OpenAI.MemorySearchToolCallStatus status = default(Azure.AI.Extensions.OpenAI.MemorySearchToolCallStatus), System.Collections.Generic.IEnumerable<Azure.AI.Extensions.OpenAI.MemorySearchItem> results = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.OAuthConsentRequestResponseItem OAuthConsentRequestResponseItem(string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string internalConsentLink = null, string serverLabel = null) { throw null; }
        public static Azure.AI.Extensions.OpenAI.OpenApiToolCall OpenApiToolCall(string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, string name = null, string arguments = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        public static Azure.AI.Extensions.OpenAI.OpenApiToolCallOutput OpenApiToolCallOutput(string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, string name = null, System.BinaryData output = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        public static Azure.AI.Extensions.OpenAI.ProjectConversation ProjectConversation(string id = null, System.Collections.Generic.IDictionary<string, string> metadata = null, System.DateTimeOffset createdAt = default(System.DateTimeOffset)) { throw null; }
        public static Azure.AI.Extensions.OpenAI.SharepointGroundingToolCall SharepointGroundingToolCall(string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, string arguments = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        public static Azure.AI.Extensions.OpenAI.SharepointGroundingToolCallOutput SharepointGroundingToolCallOutput(string id = null, Azure.AI.Extensions.OpenAI.AgentReference agentReference = null, string responseId = null, string callId = null, System.BinaryData output = null, Azure.AI.Extensions.OpenAI.ToolCallStatus status = Azure.AI.Extensions.OpenAI.ToolCallStatus.InProgress) { throw null; }
        public static Azure.AI.Extensions.OpenAI.UserProfileMemoryItem UserProfileMemoryItem(string memoryId = null, System.DateTimeOffset updatedAt = default(System.DateTimeOffset), string scope = null, string content = null) { throw null; }
    }
    public partial class ExtraDataDictionary : System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<string, System.BinaryData>>, System.Collections.Generic.IDictionary<string, System.BinaryData>, System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string, System.BinaryData>>, System.Collections.IEnumerable
    {
        internal ExtraDataDictionary() { }
        public int Count { get { throw null; } }
        public bool IsReadOnly { get { throw null; } }
        public System.BinaryData this[System.ReadOnlySpan<byte> key] { get { throw null; } set { } }
        public System.BinaryData this[string key] { get { throw null; } set { } }
        public System.Collections.Generic.ICollection<string> Keys { get { throw null; } }
        public System.Collections.Generic.ICollection<System.BinaryData> Values { get { throw null; } }
        public void Add(System.Collections.Generic.KeyValuePair<string, System.BinaryData> item) { }
        public void Add(string key, System.BinaryData value) { }
        public void Add(string key, bool value) { }
        public void Add(string key, int value) { }
        public void Add(string key, string value) { }
        public void Clear() { }
        public bool Contains(System.Collections.Generic.KeyValuePair<string, System.BinaryData> item) { throw null; }
        public bool ContainsKey(string key) { throw null; }
        public void CopyTo(System.Collections.Generic.KeyValuePair<string, System.BinaryData>[] array, int arrayIndex) { }
        public bool Remove(System.Collections.Generic.KeyValuePair<string, System.BinaryData> item) { throw null; }
        public bool Remove(string key) { throw null; }
        public void SetData(System.BinaryData dictionaryJsonBytes) { }
        System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<string, System.BinaryData>> System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<System.String,System.BinaryData>>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
        public bool TryGetValue(System.ReadOnlySpan<byte> key, out System.BinaryData value) { throw null; }
        public bool TryGetValue(string key, out System.BinaryData value) { throw null; }
    }
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
    public partial class MemorySearchItem : System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.MemorySearchItem>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.MemorySearchItem>
    {
        public MemorySearchItem(Azure.AI.Extensions.OpenAI.MemoryOutputItem memoryItem) { }
        public Azure.AI.Extensions.OpenAI.MemoryOutputItem MemoryItem { get { throw null; } set { } }
        protected virtual Azure.AI.Extensions.OpenAI.MemorySearchItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Extensions.OpenAI.MemorySearchItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.MemorySearchItem System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.MemorySearchItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.MemorySearchItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.MemorySearchItem System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.MemorySearchItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.MemorySearchItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.MemorySearchItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MemorySearchToolCallResponseItem : Azure.AI.Extensions.OpenAI.AgentResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.MemorySearchToolCallResponseItem>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.MemorySearchToolCallResponseItem>
    {
        public MemorySearchToolCallResponseItem(Azure.AI.Extensions.OpenAI.MemorySearchToolCallStatus status) { }
        public System.Collections.Generic.IList<Azure.AI.Extensions.OpenAI.MemorySearchItem> Results { get { throw null; } set { } }
        public Azure.AI.Extensions.OpenAI.MemorySearchToolCallStatus Status { get { throw null; } set { } }
        protected override Azure.AI.Extensions.OpenAI.AgentResponseItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Extensions.OpenAI.AgentResponseItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Extensions.OpenAI.MemorySearchToolCallResponseItem System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.MemorySearchToolCallResponseItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Extensions.OpenAI.MemorySearchToolCallResponseItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Extensions.OpenAI.MemorySearchToolCallResponseItem System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.MemorySearchToolCallResponseItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.MemorySearchToolCallResponseItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Extensions.OpenAI.MemorySearchToolCallResponseItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MemorySearchToolCallStatus : System.IEquatable<Azure.AI.Extensions.OpenAI.MemorySearchToolCallStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MemorySearchToolCallStatus(string value) { throw null; }
        public static Azure.AI.Extensions.OpenAI.MemorySearchToolCallStatus Completed { get { throw null; } }
        public static Azure.AI.Extensions.OpenAI.MemorySearchToolCallStatus Failed { get { throw null; } }
        public static Azure.AI.Extensions.OpenAI.MemorySearchToolCallStatus Incomplete { get { throw null; } }
        public static Azure.AI.Extensions.OpenAI.MemorySearchToolCallStatus InProgress { get { throw null; } }
        public static Azure.AI.Extensions.OpenAI.MemorySearchToolCallStatus Searching { get { throw null; } }
        public bool Equals(Azure.AI.Extensions.OpenAI.MemorySearchToolCallStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Extensions.OpenAI.MemorySearchToolCallStatus left, Azure.AI.Extensions.OpenAI.MemorySearchToolCallStatus right) { throw null; }
        public static implicit operator Azure.AI.Extensions.OpenAI.MemorySearchToolCallStatus (string value) { throw null; }
        public static implicit operator Azure.AI.Extensions.OpenAI.MemorySearchToolCallStatus? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Extensions.OpenAI.MemorySearchToolCallStatus left, Azure.AI.Extensions.OpenAI.MemorySearchToolCallStatus right) { throw null; }
        public override string ToString() { throw null; }
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
        public virtual Azure.AI.Extensions.OpenAI.ProjectConversationsClient Conversations { get { throw null; } }
        public virtual Azure.AI.Extensions.OpenAI.ProjectFilesClient Files { get { throw null; } }
        public virtual Azure.AI.Extensions.OpenAI.ProjectResponsesClient Responses { get { throw null; } }
        public virtual Azure.AI.Extensions.OpenAI.ProjectVectorStoresClient VectorStores { get { throw null; } }
        public override OpenAI.Conversations.ConversationClient GetConversationClient() { throw null; }
        public override OpenAI.Files.OpenAIFileClient GetOpenAIFileClient() { throw null; }
        public virtual Azure.AI.Extensions.OpenAI.ProjectConversationsClient GetProjectConversationsClient() { throw null; }
        public virtual Azure.AI.Extensions.OpenAI.ProjectFilesClient GetProjectFilesClient() { throw null; }
        public virtual Azure.AI.Extensions.OpenAI.ProjectResponsesClient GetProjectResponsesClient() { throw null; }
        public virtual Azure.AI.Extensions.OpenAI.ProjectResponsesClient GetProjectResponsesClientForAgent(Azure.AI.Extensions.OpenAI.AgentReference defaultAgent, string defaultConversationId = null) { throw null; }
        public virtual Azure.AI.Extensions.OpenAI.ProjectResponsesClient GetProjectResponsesClientForModel(string defaultModel, string defaultConversationId = null) { throw null; }
        public virtual Azure.AI.Extensions.OpenAI.ProjectVectorStoresClient GetProjectVectorStoresClient() { throw null; }
    }
    public partial class ProjectOpenAIClientOptions : OpenAI.OpenAIClientOptions
    {
        public ProjectOpenAIClientOptions() { }
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
    public enum ToolCallStatus
    {
        InProgress = 0,
        Completed = 1,
        Incomplete = 2,
        Failed = 3,
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
