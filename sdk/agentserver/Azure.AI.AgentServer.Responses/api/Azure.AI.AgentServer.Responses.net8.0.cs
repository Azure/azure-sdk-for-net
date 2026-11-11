namespace Azure.AI.AgentServer.Responses
{
    public partial class AzureAIAgentServerResponsesContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureAIAgentServerResponsesContext() { }
        public static Azure.AI.AgentServer.Responses.AzureAIAgentServerResponsesContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class BadRequestException : System.Exception
    {
        public BadRequestException(string message) { }
        public BadRequestException(string message, System.Exception innerException) { }
        public BadRequestException(string message, string? paramName) { }
        public BadRequestException(string message, string? code, string? paramName) { }
        public string? Code { get { throw null; } }
        public string? ParamName { get { throw null; } }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("OPENAI001")]
    public sealed partial class CreateResponsePersistRequest
    {
        public CreateResponsePersistRequest(OpenAI.Responses.ResponseResult response, System.Collections.Generic.IEnumerable<OpenAI.Responses.ResponseItem>? inputItems, System.Collections.Generic.IEnumerable<string>? historyItemIds) { }
        public System.Collections.Generic.IEnumerable<string> HistoryItemIds { get { throw null; } }
        public System.Collections.Generic.IEnumerable<OpenAI.Responses.ResponseItem> InputItems { get { throw null; } }
        public OpenAI.Responses.ResponseResult Response { get { throw null; } }
    }
    public static partial class DataUrl
    {
        public static byte[] DecodeBytes(string dataUrl) { throw null; }
        public static byte[] DecodeBytes(System.Uri uri) { throw null; }
        public static string? GetMediaType(string? dataUrl) { throw null; }
        public static string? GetMediaType(System.Uri? uri) { throw null; }
        public static bool IsDataUrl(string? value) { throw null; }
        public static bool IsDataUrl(System.Uri? uri) { throw null; }
        public static bool TryDecodeBytes(string? dataUrl, out byte[] bytes) { throw null; }
        public static bool TryDecodeBytes(System.Uri? uri, out byte[] bytes) { throw null; }
    }
    public partial class InMemoryProviderOptions
    {
        public InMemoryProviderOptions() { }
        public System.TimeSpan EventStreamTtl { get { throw null; } set { } }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("OPENAI001")]
    public partial class OutputItemBuilder<T> where T : OpenAI.Responses.ResponseItem
    {
        protected OutputItemBuilder() { }
        public string ItemId { get { throw null; } }
        public long OutputIndex { get { throw null; } }
        public virtual OpenAI.Responses.StreamingResponseOutputItemAddedUpdate EmitAdded(T item) { throw null; }
        public virtual OpenAI.Responses.StreamingResponseOutputItemDoneUpdate EmitDone(T item) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("OPENAI001")]
    public partial class OutputItemCodeInterpreterCallBuilder : Azure.AI.AgentServer.Responses.OutputItemBuilder<OpenAI.Responses.CodeInterpreterCallResponseItem>
    {
        protected OutputItemCodeInterpreterCallBuilder() { }
        public virtual System.Collections.Generic.IAsyncEnumerable<OpenAI.Responses.StreamingResponseUpdate> Code(System.Collections.Generic.IAsyncEnumerable<string> chunks, [System.Runtime.CompilerServices.EnumeratorCancellationAttribute] System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<OpenAI.Responses.StreamingResponseUpdate> Code(string code) { throw null; }
        public virtual OpenAI.Responses.StreamingResponseOutputItemAddedUpdate EmitAdded() { throw null; }
        public virtual OpenAI.Responses.StreamingResponseCodeInterpreterCallCodeDeltaUpdate EmitCodeDelta(string delta) { throw null; }
        public virtual OpenAI.Responses.StreamingResponseCodeInterpreterCallCodeDoneUpdate EmitCodeDone(string code) { throw null; }
        public virtual OpenAI.Responses.StreamingResponseCodeInterpreterCallCompletedUpdate EmitCompleted() { throw null; }
        public virtual OpenAI.Responses.StreamingResponseOutputItemDoneUpdate EmitDone() { throw null; }
        public virtual OpenAI.Responses.StreamingResponseCodeInterpreterCallInProgressUpdate EmitInProgress() { throw null; }
        public virtual OpenAI.Responses.StreamingResponseCodeInterpreterCallInterpretingUpdate EmitInterpreting() { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("OPENAI001")]
    public partial class OutputItemCustomToolCallBuilder : Azure.AI.AgentServer.Responses.OutputItemBuilder<Azure.AI.AgentServer.Responses.Models.OutputItemCustomToolCall>
    {
        protected OutputItemCustomToolCallBuilder() { }
        public string CallId { get { throw null; } }
        public string Name { get { throw null; } }
        public virtual OpenAI.Responses.StreamingResponseOutputItemAddedUpdate EmitAdded() { throw null; }
        public virtual OpenAI.Responses.StreamingResponseOutputItemDoneUpdate EmitDone() { throw null; }
        public virtual OpenAI.Responses.StreamingResponseCustomToolCallInputDeltaUpdate EmitInputDelta(string delta) { throw null; }
        public virtual OpenAI.Responses.StreamingResponseCustomToolCallInputDoneUpdate EmitInputDone(string input) { throw null; }
        public System.Collections.Generic.IAsyncEnumerable<OpenAI.Responses.StreamingResponseUpdate> Input(System.Collections.Generic.IAsyncEnumerable<string> chunks, [System.Runtime.CompilerServices.EnumeratorCancellationAttribute] System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Collections.Generic.IEnumerable<OpenAI.Responses.StreamingResponseUpdate> Input(string input) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("OPENAI001")]
    public partial class OutputItemFileSearchCallBuilder : Azure.AI.AgentServer.Responses.OutputItemBuilder<OpenAI.Responses.FileSearchCallResponseItem>
    {
        protected OutputItemFileSearchCallBuilder() { }
        public virtual OpenAI.Responses.StreamingResponseOutputItemAddedUpdate EmitAdded() { throw null; }
        public virtual OpenAI.Responses.StreamingResponseFileSearchCallCompletedUpdate EmitCompleted() { throw null; }
        public virtual OpenAI.Responses.StreamingResponseOutputItemDoneUpdate EmitDone() { throw null; }
        public virtual OpenAI.Responses.StreamingResponseFileSearchCallInProgressUpdate EmitInProgress() { throw null; }
        public virtual OpenAI.Responses.StreamingResponseFileSearchCallSearchingUpdate EmitSearching() { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("OPENAI001")]
    public partial class OutputItemFunctionCallBuilder : Azure.AI.AgentServer.Responses.OutputItemBuilder<OpenAI.Responses.FunctionCallResponseItem>
    {
        protected OutputItemFunctionCallBuilder() { }
        public string CallId { get { throw null; } }
        public string Name { get { throw null; } }
        public virtual System.Collections.Generic.IAsyncEnumerable<OpenAI.Responses.StreamingResponseUpdate> Arguments(System.Collections.Generic.IAsyncEnumerable<string> chunks, [System.Runtime.CompilerServices.EnumeratorCancellationAttribute] System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<OpenAI.Responses.StreamingResponseUpdate> Arguments(string arguments) { throw null; }
        public virtual OpenAI.Responses.StreamingResponseOutputItemAddedUpdate EmitAdded() { throw null; }
        public virtual OpenAI.Responses.StreamingResponseFunctionCallArgumentsDeltaUpdate EmitArgumentsDelta(string delta) { throw null; }
        public virtual OpenAI.Responses.StreamingResponseFunctionCallArgumentsDoneUpdate EmitArgumentsDone(string arguments) { throw null; }
        public virtual OpenAI.Responses.StreamingResponseOutputItemDoneUpdate EmitDone() { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("OPENAI001")]
    public partial class OutputItemImageGenCallBuilder : Azure.AI.AgentServer.Responses.OutputItemBuilder<OpenAI.Responses.ImageGenerationCallResponseItem>
    {
        protected OutputItemImageGenCallBuilder() { }
        public virtual OpenAI.Responses.StreamingResponseOutputItemAddedUpdate EmitAdded() { throw null; }
        public virtual OpenAI.Responses.StreamingResponseImageGenerationCallCompletedUpdate EmitCompleted() { throw null; }
        public virtual OpenAI.Responses.StreamingResponseOutputItemDoneUpdate EmitDone(string result) { throw null; }
        public virtual OpenAI.Responses.StreamingResponseImageGenerationCallGeneratingUpdate EmitGenerating() { throw null; }
        public virtual OpenAI.Responses.StreamingResponseImageGenerationCallInProgressUpdate EmitInProgress() { throw null; }
        public virtual OpenAI.Responses.StreamingResponseImageGenerationCallPartialImageUpdate EmitPartialImage(string partialImageB64) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("OPENAI001")]
    public partial class OutputItemMcpCallBuilder : Azure.AI.AgentServer.Responses.OutputItemBuilder<OpenAI.Responses.McpToolCallItem>
    {
        protected OutputItemMcpCallBuilder() { }
        public string Name { get { throw null; } }
        public string ServerLabel { get { throw null; } }
        public virtual System.Collections.Generic.IAsyncEnumerable<OpenAI.Responses.StreamingResponseUpdate> Arguments(System.Collections.Generic.IAsyncEnumerable<string> chunks, [System.Runtime.CompilerServices.EnumeratorCancellationAttribute] System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<OpenAI.Responses.StreamingResponseUpdate> Arguments(string arguments) { throw null; }
        public virtual OpenAI.Responses.StreamingResponseOutputItemAddedUpdate EmitAdded() { throw null; }
        public virtual OpenAI.Responses.StreamingResponseMcpCallArgumentsDeltaUpdate EmitArgumentsDelta(string delta) { throw null; }
        public virtual OpenAI.Responses.StreamingResponseMcpCallArgumentsDoneUpdate EmitArgumentsDone(string arguments) { throw null; }
        public virtual OpenAI.Responses.StreamingResponseMcpCallCompletedUpdate EmitCompleted() { throw null; }
        public virtual OpenAI.Responses.StreamingResponseOutputItemDoneUpdate EmitDone() { throw null; }
        public virtual OpenAI.Responses.StreamingResponseMcpCallFailedUpdate EmitFailed() { throw null; }
        public virtual OpenAI.Responses.StreamingResponseMcpCallInProgressUpdate EmitInProgress() { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("OPENAI001")]
    public partial class OutputItemMcpListToolsBuilder : Azure.AI.AgentServer.Responses.OutputItemBuilder<OpenAI.Responses.McpToolDefinitionListItem>
    {
        protected OutputItemMcpListToolsBuilder() { }
        public string ServerLabel { get { throw null; } }
        public virtual OpenAI.Responses.StreamingResponseOutputItemAddedUpdate EmitAdded() { throw null; }
        public virtual OpenAI.Responses.StreamingResponseMcpListToolsCompletedUpdate EmitCompleted() { throw null; }
        public virtual OpenAI.Responses.StreamingResponseOutputItemDoneUpdate EmitDone() { throw null; }
        public virtual OpenAI.Responses.StreamingResponseMcpListToolsFailedUpdate EmitFailed() { throw null; }
        public virtual OpenAI.Responses.StreamingResponseMcpListToolsInProgressUpdate EmitInProgress() { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("OPENAI001")]
    public partial class OutputItemMessageBuilder : Azure.AI.AgentServer.Responses.OutputItemBuilder<OpenAI.Responses.MessageResponseItem>
    {
        protected OutputItemMessageBuilder() { }
        public virtual Azure.AI.AgentServer.Responses.RefusalContentBuilder AddRefusalContent() { throw null; }
        public virtual Azure.AI.AgentServer.Responses.TextContentBuilder AddTextContent() { throw null; }
        public virtual OpenAI.Responses.StreamingResponseOutputItemAddedUpdate EmitAdded() { throw null; }
        public virtual OpenAI.Responses.StreamingResponseOutputItemDoneUpdate EmitDone() { throw null; }
        public virtual System.Collections.Generic.IAsyncEnumerable<OpenAI.Responses.StreamingResponseUpdate> RefusalContent(System.Collections.Generic.IAsyncEnumerable<string> chunks, [System.Runtime.CompilerServices.EnumeratorCancellationAttribute] System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<OpenAI.Responses.StreamingResponseUpdate> RefusalContent(string text) { throw null; }
        public virtual System.Collections.Generic.IAsyncEnumerable<OpenAI.Responses.StreamingResponseUpdate> TextContent(System.Collections.Generic.IAsyncEnumerable<string> chunks, [System.Runtime.CompilerServices.EnumeratorCancellationAttribute] System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<OpenAI.Responses.StreamingResponseUpdate> TextContent(string text) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<OpenAI.Responses.StreamingResponseUpdate> TextContent(string text, System.Collections.Generic.IEnumerable<OpenAI.Responses.ResponseMessageAnnotation> annotations) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("OPENAI001")]
    public partial class OutputItemReasoningItemBuilder : Azure.AI.AgentServer.Responses.OutputItemBuilder<OpenAI.Responses.ReasoningResponseItem>
    {
        protected OutputItemReasoningItemBuilder() { }
        public virtual Azure.AI.AgentServer.Responses.ReasoningSummaryPartBuilder AddSummaryPart() { throw null; }
        public virtual OpenAI.Responses.StreamingResponseOutputItemAddedUpdate EmitAdded() { throw null; }
        public virtual OpenAI.Responses.StreamingResponseOutputItemDoneUpdate EmitDone() { throw null; }
        public virtual System.Collections.Generic.IAsyncEnumerable<OpenAI.Responses.StreamingResponseUpdate> SummaryPart(System.Collections.Generic.IAsyncEnumerable<string> chunks, [System.Runtime.CompilerServices.EnumeratorCancellationAttribute] System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<OpenAI.Responses.StreamingResponseUpdate> SummaryPart(string text) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("OPENAI001")]
    public partial class OutputItemWebSearchCallBuilder : Azure.AI.AgentServer.Responses.OutputItemBuilder<OpenAI.Responses.WebSearchCallResponseItem>
    {
        protected OutputItemWebSearchCallBuilder() { }
        public virtual OpenAI.Responses.StreamingResponseOutputItemAddedUpdate EmitAdded() { throw null; }
        public virtual OpenAI.Responses.StreamingResponseWebSearchCallCompletedUpdate EmitCompleted() { throw null; }
        public virtual OpenAI.Responses.StreamingResponseOutputItemDoneUpdate EmitDone() { throw null; }
        public virtual OpenAI.Responses.StreamingResponseWebSearchCallInProgressUpdate EmitInProgress() { throw null; }
        public virtual OpenAI.Responses.StreamingResponseWebSearchCallSearchingUpdate EmitSearching() { throw null; }
    }
    public sealed partial class PayloadValidationException : Azure.AI.AgentServer.Responses.BadRequestException
    {
        public PayloadValidationException(System.Collections.Generic.IReadOnlyList<Azure.AI.AgentServer.Responses.ValidationError> errors) : base (default(string)) { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.AgentServer.Responses.ValidationError> Errors { get { throw null; } }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("OPENAI001")]
    public partial class ReasoningSummaryPartBuilder
    {
        protected ReasoningSummaryPartBuilder() { }
        public string? FinalText { get { throw null; } }
        public long SummaryIndex { get { throw null; } }
        public virtual OpenAI.Responses.StreamingResponseReasoningSummaryPartAddedUpdate EmitAdded() { throw null; }
        public virtual OpenAI.Responses.StreamingResponseReasoningSummaryPartDoneUpdate EmitDone() { throw null; }
        public virtual OpenAI.Responses.StreamingResponseReasoningSummaryTextDeltaUpdate EmitTextDelta(string text) { throw null; }
        public virtual OpenAI.Responses.StreamingResponseReasoningSummaryTextDoneUpdate EmitTextDone(string finalText) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("OPENAI001")]
    public partial class RefusalContentBuilder
    {
        protected RefusalContentBuilder() { }
        public long ContentIndex { get { throw null; } }
        public string? FinalRefusal { get { throw null; } }
        public virtual OpenAI.Responses.StreamingResponseContentPartAddedUpdate EmitAdded() { throw null; }
        public virtual OpenAI.Responses.StreamingResponseRefusalDeltaUpdate EmitDelta(string text) { throw null; }
        public virtual OpenAI.Responses.StreamingResponseContentPartDoneUpdate EmitDone() { throw null; }
        public virtual OpenAI.Responses.StreamingResponseRefusalDoneUpdate EmitRefusalDone(string finalRefusal) { throw null; }
    }
    public partial class ResourceNotFoundException : System.Exception
    {
        public ResourceNotFoundException(string message) { }
        public ResourceNotFoundException(string message, System.Exception innerException) { }
        public ResourceNotFoundException(string message, string? code, string? param) { }
        public string? Code { get { throw null; } }
        public string? Param { get { throw null; } }
    }
    public partial class ResponseContext
    {
        public ResponseContext(string responseId) { }
        public virtual System.Threading.CancellationToken ClientCancellation { get { throw null; } }
        public virtual System.Collections.Generic.IReadOnlyDictionary<string, string> ClientHeaders { get { throw null; } }
        public virtual string ConversationChainId { get { throw null; } }
        public virtual bool IsClientCancelled { get { throw null; } }
        public virtual bool IsRecovery { get { throw null; } }
        public virtual bool IsShutdownRequested { get { throw null; } }
        public virtual bool IsSteeredTurn { get { throw null; } }
        public virtual int PendingInputCount { get { throw null; } }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("OPENAI001")]
        public virtual OpenAI.Responses.ResponseResult? PersistedResponse { get { throw null; } }
        public virtual Azure.AI.AgentServer.Core.PlatformContext PlatformContext { get { throw null; } }
        public virtual System.Collections.Generic.IReadOnlyDictionary<string, Microsoft.Extensions.Primitives.StringValues> QueryParameters { get { throw null; } }
        public virtual System.BinaryData? RawBody { get { throw null; } }
        public string ResponseId { get { throw null; } }
        public virtual System.Threading.CancellationToken Shutdown { get { throw null; } }
        public virtual System.Threading.Tasks.Task ExitForRecoveryAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("OPENAI001")]
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IReadOnlyList<OpenAI.Responses.ResponseItem>> GetHistoryAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("OPENAI001")]
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IReadOnlyList<OpenAI.Responses.ResponseItem>> GetInputItemsAsync(bool resolveReferences = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<string> GetInputTextAsync(bool resolveReferences = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class ResponseContextExtensions
    {
        public static string NewApplyPatchCallItemId(this Azure.AI.AgentServer.Responses.ResponseContext context) { throw null; }
        public static string NewApplyPatchCallOutputItemId(this Azure.AI.AgentServer.Responses.ResponseContext context) { throw null; }
        public static string NewCodeInterpreterCallItemId(this Azure.AI.AgentServer.Responses.ResponseContext context) { throw null; }
        public static string NewCompactionItemId(this Azure.AI.AgentServer.Responses.ResponseContext context) { throw null; }
        public static string NewComputerCallItemId(this Azure.AI.AgentServer.Responses.ResponseContext context) { throw null; }
        public static string NewComputerCallOutputItemId(this Azure.AI.AgentServer.Responses.ResponseContext context) { throw null; }
        public static string NewCustomToolCallItemId(this Azure.AI.AgentServer.Responses.ResponseContext context) { throw null; }
        public static string NewCustomToolCallOutputItemId(this Azure.AI.AgentServer.Responses.ResponseContext context) { throw null; }
        public static string NewFileSearchCallItemId(this Azure.AI.AgentServer.Responses.ResponseContext context) { throw null; }
        public static string NewFunctionCallItemId(this Azure.AI.AgentServer.Responses.ResponseContext context) { throw null; }
        public static string NewFunctionCallOutputItemId(this Azure.AI.AgentServer.Responses.ResponseContext context) { throw null; }
        public static string NewFunctionShellCallItemId(this Azure.AI.AgentServer.Responses.ResponseContext context) { throw null; }
        public static string NewFunctionShellCallOutputItemId(this Azure.AI.AgentServer.Responses.ResponseContext context) { throw null; }
        public static string NewImageGenCallItemId(this Azure.AI.AgentServer.Responses.ResponseContext context) { throw null; }
        public static string NewItemId(this Azure.AI.AgentServer.Responses.ResponseContext context) { throw null; }
        public static string NewLocalShellCallItemId(this Azure.AI.AgentServer.Responses.ResponseContext context) { throw null; }
        public static string NewLocalShellCallOutputItemId(this Azure.AI.AgentServer.Responses.ResponseContext context) { throw null; }
        public static string NewMcpApprovalRequestItemId(this Azure.AI.AgentServer.Responses.ResponseContext context) { throw null; }
        public static string NewMcpApprovalResponseItemId(this Azure.AI.AgentServer.Responses.ResponseContext context) { throw null; }
        public static string NewMcpCallItemId(this Azure.AI.AgentServer.Responses.ResponseContext context) { throw null; }
        public static string NewMcpListToolsItemId(this Azure.AI.AgentServer.Responses.ResponseContext context) { throw null; }
        public static string NewMessageItemId(this Azure.AI.AgentServer.Responses.ResponseContext context) { throw null; }
        public static string NewOutputMessageItemId(this Azure.AI.AgentServer.Responses.ResponseContext context) { throw null; }
        public static string NewReasoningItemId(this Azure.AI.AgentServer.Responses.ResponseContext context) { throw null; }
        public static string NewStructuredOutputItemId(this Azure.AI.AgentServer.Responses.ResponseContext context) { throw null; }
        public static string NewWebSearchCallItemId(this Azure.AI.AgentServer.Responses.ResponseContext context) { throw null; }
        public static string NewWorkflowActionItemId(this Azure.AI.AgentServer.Responses.ResponseContext context) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("OPENAI001")]
    public partial class ResponseEventStream
    {
        protected ResponseEventStream() { }
        public ResponseEventStream(Azure.AI.AgentServer.Responses.ResponseContext context, OpenAI.Responses.CreateResponseOptions request) { }
        public ResponseEventStream(Azure.AI.AgentServer.Responses.ResponseContext context, OpenAI.Responses.ResponseResult persistedResponse) { }
        public virtual System.Collections.Generic.IDictionary<string, string> PersistedMetadata { get { throw null; } }
        public OpenAI.Responses.ResponseResult Response { get { throw null; } }
        public virtual Azure.AI.AgentServer.Responses.OutputItemBuilder<OpenAI.Responses.ApplyPatchCallItem> AddOutputItemApplyPatchCall() { throw null; }
        public virtual Azure.AI.AgentServer.Responses.OutputItemBuilder<OpenAI.Responses.ApplyPatchCallOutputItem> AddOutputItemApplyPatchCallOutput() { throw null; }
        public virtual Azure.AI.AgentServer.Responses.OutputItemCodeInterpreterCallBuilder AddOutputItemCodeInterpreterCall() { throw null; }
        public virtual Azure.AI.AgentServer.Responses.OutputItemBuilder<OpenAI.Responses.ComputerCallResponseItem> AddOutputItemComputerCall() { throw null; }
        public virtual Azure.AI.AgentServer.Responses.OutputItemBuilder<OpenAI.Responses.ComputerCallOutputResponseItem> AddOutputItemComputerCallOutput() { throw null; }
        public virtual Azure.AI.AgentServer.Responses.OutputItemCustomToolCallBuilder AddOutputItemCustomToolCall(string callId, string name) { throw null; }
        public virtual Azure.AI.AgentServer.Responses.OutputItemBuilder<Azure.AI.AgentServer.Responses.Models.OutputItemCustomToolCallOutput> AddOutputItemCustomToolCallOutput() { throw null; }
        public virtual Azure.AI.AgentServer.Responses.OutputItemFileSearchCallBuilder AddOutputItemFileSearchCall() { throw null; }
        public virtual Azure.AI.AgentServer.Responses.OutputItemFunctionCallBuilder AddOutputItemFunctionCall(string name, string callId) { throw null; }
        public virtual Azure.AI.AgentServer.Responses.OutputItemImageGenCallBuilder AddOutputItemImageGenCall() { throw null; }
        public virtual Azure.AI.AgentServer.Responses.OutputItemBuilder<OpenAI.Responses.McpToolCallApprovalRequestItem> AddOutputItemMcpApprovalRequest() { throw null; }
        public virtual Azure.AI.AgentServer.Responses.OutputItemBuilder<OpenAI.Responses.McpToolCallApprovalResponseItem> AddOutputItemMcpApprovalResponse() { throw null; }
        public virtual Azure.AI.AgentServer.Responses.OutputItemMcpCallBuilder AddOutputItemMcpCall(string serverLabel, string name) { throw null; }
        public virtual Azure.AI.AgentServer.Responses.OutputItemMcpListToolsBuilder AddOutputItemMcpListTools(string serverLabel) { throw null; }
        public virtual Azure.AI.AgentServer.Responses.OutputItemMessageBuilder AddOutputItemMessage() { throw null; }
        public virtual Azure.AI.AgentServer.Responses.OutputItemReasoningItemBuilder AddOutputItemReasoningItem() { throw null; }
        public virtual Azure.AI.AgentServer.Responses.OutputItemBuilder<Azure.AI.Extensions.OpenAI.AgentStructuredOutputsResponseItem> AddOutputItemStructuredOutputs() { throw null; }
        public virtual Azure.AI.AgentServer.Responses.OutputItemWebSearchCallBuilder AddOutputItemWebSearchCall() { throw null; }
        public virtual Azure.AI.AgentServer.Responses.OutputItemBuilder<T> AddOutputItem<T>(string itemId) where T : OpenAI.Responses.ResponseItem { throw null; }
        public virtual OpenAI.Responses.StreamingResponseUpdate CreateCheckpointEvent() { throw null; }
        public virtual OpenAI.Responses.StreamingResponseCompletedUpdate EmitCompleted(OpenAI.Responses.ResponseTokenUsage? usage = null) { throw null; }
        public virtual OpenAI.Responses.StreamingResponseCreatedUpdate EmitCreated(OpenAI.Responses.ResponseStatus status = OpenAI.Responses.ResponseStatus.InProgress) { throw null; }
        public virtual OpenAI.Responses.StreamingResponseFailedUpdate EmitFailed(OpenAI.Responses.ResponseErrorCode code, string message = "An internal server error occurred.", OpenAI.Responses.ResponseTokenUsage? usage = null) { throw null; }
        public virtual OpenAI.Responses.StreamingResponseFailedUpdate EmitFailed(string message = "An internal server error occurred.", OpenAI.Responses.ResponseTokenUsage? usage = null) { throw null; }
        public virtual OpenAI.Responses.StreamingResponseIncompleteUpdate EmitIncomplete(OpenAI.Responses.ResponseIncompleteStatusReason? reason = default(OpenAI.Responses.ResponseIncompleteStatusReason?), OpenAI.Responses.ResponseTokenUsage? usage = null) { throw null; }
        public virtual OpenAI.Responses.StreamingResponseInProgressUpdate EmitInProgress() { throw null; }
        public virtual OpenAI.Responses.StreamingResponseQueuedUpdate EmitQueued() { throw null; }
        public virtual long NextSequenceNumber() { throw null; }
        public System.Collections.Generic.IEnumerable<OpenAI.Responses.StreamingResponseUpdate> OutputItemApplyPatchCall(string callId, OpenAI.Responses.ApplyPatchCallStatus status, OpenAI.Responses.ApplyPatchOperation operation) { throw null; }
        public System.Collections.Generic.IEnumerable<OpenAI.Responses.StreamingResponseUpdate> OutputItemApplyPatchCallOutput(string callId, OpenAI.Responses.ApplyPatchCallOutputStatus status) { throw null; }
        public System.Collections.Generic.IEnumerable<OpenAI.Responses.StreamingResponseUpdate> OutputItemComputerCall(string callId, OpenAI.Responses.ComputerCallAction action, System.Collections.Generic.IEnumerable<OpenAI.Responses.ComputerCallSafetyCheck> pendingSafetyChecks, OpenAI.Responses.ComputerCallStatus status) { throw null; }
        public System.Collections.Generic.IEnumerable<OpenAI.Responses.StreamingResponseUpdate> OutputItemComputerCallOutput(string callId, OpenAI.Responses.ComputerCallOutput output) { throw null; }
        public System.Collections.Generic.IEnumerable<OpenAI.Responses.StreamingResponseUpdate> OutputItemCustomToolCallOutput(string callId, System.BinaryData output) { throw null; }
        public System.Collections.Generic.IAsyncEnumerable<OpenAI.Responses.StreamingResponseUpdate> OutputItemFunctionCall(string name, string callId, System.Collections.Generic.IAsyncEnumerable<string> chunks, [System.Runtime.CompilerServices.EnumeratorCancellationAttribute] System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Collections.Generic.IEnumerable<OpenAI.Responses.StreamingResponseUpdate> OutputItemFunctionCall(string name, string callId, string arguments) { throw null; }
        public System.Collections.Generic.IEnumerable<OpenAI.Responses.StreamingResponseUpdate> OutputItemFunctionCallOutput(string callId, System.BinaryData output) { throw null; }
        public System.Collections.Generic.IEnumerable<OpenAI.Responses.StreamingResponseUpdate> OutputItemImageGenCall(string resultBase64) { throw null; }
        public System.Collections.Generic.IEnumerable<OpenAI.Responses.StreamingResponseUpdate> OutputItemMcpApprovalRequest(string serverLabel, string name, string arguments) { throw null; }
        public System.Collections.Generic.IEnumerable<OpenAI.Responses.StreamingResponseUpdate> OutputItemMcpApprovalResponse(string approvalRequestId, bool approve) { throw null; }
        public System.Collections.Generic.IAsyncEnumerable<OpenAI.Responses.StreamingResponseUpdate> OutputItemMessage(System.Collections.Generic.IAsyncEnumerable<string> chunks, [System.Runtime.CompilerServices.EnumeratorCancellationAttribute] System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Collections.Generic.IEnumerable<OpenAI.Responses.StreamingResponseUpdate> OutputItemMessage(string text) { throw null; }
        public System.Collections.Generic.IEnumerable<OpenAI.Responses.StreamingResponseUpdate> OutputItemMessage(string text, System.Collections.Generic.IEnumerable<OpenAI.Responses.ResponseMessageAnnotation> annotations) { throw null; }
        public System.Collections.Generic.IAsyncEnumerable<OpenAI.Responses.StreamingResponseUpdate> OutputItemReasoningItem(System.Collections.Generic.IAsyncEnumerable<string> chunks, [System.Runtime.CompilerServices.EnumeratorCancellationAttribute] System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Collections.Generic.IEnumerable<OpenAI.Responses.StreamingResponseUpdate> OutputItemReasoningItem(string summaryText) { throw null; }
        public System.Collections.Generic.IEnumerable<OpenAI.Responses.StreamingResponseUpdate> OutputItemStructuredOutputs(System.BinaryData output) { throw null; }
    }
    public abstract partial class ResponseHandler
    {
        protected ResponseHandler() { }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("OPENAI001")]
        public abstract System.Collections.Generic.IAsyncEnumerable<OpenAI.Responses.StreamingResponseUpdate> CreateAsync(OpenAI.Responses.CreateResponseOptions request, Azure.AI.AgentServer.Responses.ResponseContext context, System.Threading.CancellationToken cancellationToken);
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("OPENAI001")]
    public static partial class ResponseItemAttributionExtensions
    {
        public static Azure.AI.Extensions.OpenAI.AgentReference? get_AgentReference(OpenAI.Responses.CreateResponseOptions options) { throw null; }
        public static Azure.AI.Extensions.OpenAI.AgentReference? get_AgentReference(OpenAI.Responses.ResponseResult response) { throw null; }
        public static string? get_AgentSessionId(OpenAI.Responses.CreateResponseOptions options) { throw null; }
        public static string? get_AgentSessionId(OpenAI.Responses.ResponseResult response) { throw null; }
        public static string? get_ApprovalRequestId(OpenAI.Responses.McpToolCallItem mcpCall) { throw null; }
        public static System.DateTimeOffset? get_CompletedAt(OpenAI.Responses.ResponseResult response) { throw null; }
        public static System.BinaryData? get_CreatedBy(OpenAI.Responses.ResponseItem item) { throw null; }
        public static string? get_Delta(OpenAI.Responses.StreamingResponseUpdate update) { throw null; }
        public static string? get_Input(OpenAI.Responses.StreamingResponseUpdate update) { throw null; }
        public static string? get_ItemId(OpenAI.Responses.StreamingResponseUpdate update) { throw null; }
        public static int? get_OutputIndex(OpenAI.Responses.StreamingResponseUpdate update) { throw null; }
        public static string? get_OutputText(OpenAI.Responses.ResponseResult response) { throw null; }
        public static Azure.AI.AgentServer.Responses.Models.MCPToolCallStatus? get_Status(OpenAI.Responses.McpToolCallItem mcpCall) { throw null; }
        public static string? get_Text(OpenAI.Responses.ReasoningSummaryPart part) { throw null; }
        public static void set_AgentReference(OpenAI.Responses.CreateResponseOptions options, Azure.AI.Extensions.OpenAI.AgentReference? value) { }
        public static void set_AgentReference(OpenAI.Responses.ResponseResult response, Azure.AI.Extensions.OpenAI.AgentReference? value) { }
        public static void set_AgentSessionId(OpenAI.Responses.CreateResponseOptions options, string? value) { }
        public static void set_AgentSessionId(OpenAI.Responses.ResponseResult response, string? value) { }
        public static void set_ApprovalRequestId(OpenAI.Responses.McpToolCallItem mcpCall, string? value) { }
        public static void set_CompletedAt(OpenAI.Responses.ResponseResult response, System.DateTimeOffset? value) { }
        public static void set_CreatedBy(OpenAI.Responses.ResponseItem item, System.BinaryData? value) { }
        public static void set_Delta(OpenAI.Responses.StreamingResponseUpdate update, string? value) { }
        public static void set_Input(OpenAI.Responses.StreamingResponseUpdate update, string? value) { }
        public static void set_ItemId(OpenAI.Responses.StreamingResponseUpdate update, string? value) { }
        public static void set_OutputIndex(OpenAI.Responses.StreamingResponseUpdate update, int? value) { }
        public static void set_Status(OpenAI.Responses.McpToolCallItem mcpCall, Azure.AI.AgentServer.Responses.Models.MCPToolCallStatus? value) { }
        public sealed partial class <G>$18D35430E41928A72CE2C2B20C1EB7D6
        {
            internal <G>$18D35430E41928A72CE2C2B20C1EB7D6() { }
            public string? ApprovalRequestId { get { throw null; } set { } }
            public Azure.AI.AgentServer.Responses.Models.MCPToolCallStatus? Status { get { throw null; } set { } }
            public static partial class <M>$466DE5BA2CFD4B1CD21E5552E78A4323
            {
                public static void <Extension>$(OpenAI.Responses.McpToolCallItem mcpCall) { }
            }
        }
        public sealed partial class <G>$70FBCD44F28E7E26DFAD68FC496C4C09
        {
            internal <G>$70FBCD44F28E7E26DFAD68FC496C4C09() { }
            public string? Text { get { throw null; } }
            public static partial class <M>$C289646E3F041202A61C3FF992062108
            {
                public static void <Extension>$(OpenAI.Responses.ReasoningSummaryPart part) { }
            }
        }
        public sealed partial class <G>$9441C364D6D7BED1E759B10623E362FD
        {
            internal <G>$9441C364D6D7BED1E759B10623E362FD() { }
            public Azure.AI.Extensions.OpenAI.AgentReference? AgentReference { get { throw null; } set { } }
            public string? AgentSessionId { get { throw null; } set { } }
            public static partial class <M>$73D78DE0E08E12A20252D1F424C77608
            {
                public static void <Extension>$(OpenAI.Responses.CreateResponseOptions options) { }
            }
        }
        public sealed partial class <G>$D7C08262BAEC712802F8752B389F8208
        {
            internal <G>$D7C08262BAEC712802F8752B389F8208() { }
            public Azure.AI.Extensions.OpenAI.AgentReference? AgentReference { get { throw null; } set { } }
            public string? AgentSessionId { get { throw null; } set { } }
            public System.DateTimeOffset? CompletedAt { get { throw null; } set { } }
            public string? OutputText { get { throw null; } }
            public static partial class <M>$6084A2049E9FE8FAF79BB266A0023B34
            {
                public static void <Extension>$(OpenAI.Responses.ResponseResult response) { }
            }
        }
        public sealed partial class <G>$DA6A72140F97C1C5F77D9E2D365E6B73
        {
            internal <G>$DA6A72140F97C1C5F77D9E2D365E6B73() { }
            public string? Delta { get { throw null; } set { } }
            public string? Input { get { throw null; } set { } }
            public string? ItemId { get { throw null; } set { } }
            public int? OutputIndex { get { throw null; } set { } }
            public static partial class <M>$89F88CE85944EB7F58B3316EF3164959
            {
                public static void <Extension>$(OpenAI.Responses.StreamingResponseUpdate update) { }
            }
        }
        public sealed partial class <G>$F3F0025ADD8FA456F8E93354548ADC99
        {
            internal <G>$F3F0025ADD8FA456F8E93354548ADC99() { }
            public System.BinaryData? CreatedBy { get { throw null; } set { } }
            public static partial class <M>$C05C9E0FD38D230C68A8F70214143831
            {
                public static void <Extension>$(OpenAI.Responses.ResponseItem item) { }
            }
        }
    }
    public partial class ResponsesApiException : System.Exception
    {
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("OPENAI001")]
        public ResponsesApiException(OpenAI.Responses.ResponseError error, int statusCode) { }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("OPENAI001")]
        public ResponsesApiException(OpenAI.Responses.ResponseError error, int statusCode, System.Exception innerException) { }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("OPENAI001")]
        public OpenAI.Responses.ResponseError Error { get { throw null; } }
        public int StatusCode { get { throw null; } }
    }
    public static partial class ResponsesBuilderExtensions
    {
        public static Azure.AI.AgentServer.Core.AgentHostBuilder AddResponses(this Azure.AI.AgentServer.Core.AgentHostBuilder builder, Azure.AI.AgentServer.Responses.ResponseHandler handler, System.Action<Azure.AI.AgentServer.Responses.ResponsesServerOptions>? configure = null) { throw null; }
        public static Azure.AI.AgentServer.Core.AgentHostBuilder AddResponses(this Azure.AI.AgentServer.Core.AgentHostBuilder builder, System.Func<System.IServiceProvider, Azure.AI.AgentServer.Responses.ResponseHandler> factory, System.Action<Azure.AI.AgentServer.Responses.ResponsesServerOptions>? configure = null) { throw null; }
        public static Azure.AI.AgentServer.Core.AgentHostBuilder AddResponses<THandler>(this Azure.AI.AgentServer.Core.AgentHostBuilder builder, System.Action<Azure.AI.AgentServer.Responses.ResponsesServerOptions>? configure = null) where THandler : Azure.AI.AgentServer.Responses.ResponseHandler { throw null; }
    }
    public abstract partial class ResponsesCancellationSignalProvider
    {
        protected ResponsesCancellationSignalProvider() { }
        public abstract System.Threading.Tasks.Task CancelResponseAsync(string responseId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        public abstract System.Threading.Tasks.Task<System.Threading.CancellationToken> GetResponseCancellationTokenAsync(string responseId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
    }
    public abstract partial class ResponsesProvider
    {
        protected ResponsesProvider() { }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("OPENAI001")]
        public abstract System.Threading.Tasks.Task CreateResponseAsync(Azure.AI.AgentServer.Responses.CreateResponsePersistRequest request, Azure.AI.AgentServer.Core.PlatformContext context, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        public abstract System.Threading.Tasks.Task DeleteResponseAsync(string responseId, Azure.AI.AgentServer.Core.PlatformContext context, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        public abstract System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<string>> GetHistoryItemIdsAsync(string? previousResponseId, string? conversationId, int limit, Azure.AI.AgentServer.Core.PlatformContext context, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("OPENAI001")]
        public abstract System.Threading.Tasks.Task<OpenAI.Responses.ResponseItemCollectionPage> GetInputItemsAsync(string responseId, Azure.AI.AgentServer.Core.PlatformContext context, int limit = 20, bool ascending = false, string? after = null, string? before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("OPENAI001")]
        public abstract System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<OpenAI.Responses.ResponseItem?>> GetItemsAsync(System.Collections.Generic.IEnumerable<string> itemIds, Azure.AI.AgentServer.Core.PlatformContext context, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("OPENAI001")]
        public abstract System.Threading.Tasks.Task<OpenAI.Responses.ResponseResult> GetResponseAsync(string responseId, Azure.AI.AgentServer.Core.PlatformContext context, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("OPENAI001")]
        public abstract System.Threading.Tasks.Task UpdateResponseAsync(OpenAI.Responses.ResponseResult response, Azure.AI.AgentServer.Core.PlatformContext context, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
    }
    public static partial class ResponsesServer
    {
        public static void Run(System.Func<System.IServiceProvider, Azure.AI.AgentServer.Responses.ResponseHandler> factory, string[]? args = null, System.Action<Azure.AI.AgentServer.Core.AgentHostBuilder>? configure = null) { }
        public static void Run<THandler>(string[]? args = null, System.Action<Azure.AI.AgentServer.Core.AgentHostBuilder>? configure = null) where THandler : Azure.AI.AgentServer.Responses.ResponseHandler { }
    }
    public static partial class ResponsesServerEndpointRouteBuilderExtensions
    {
        public static Microsoft.AspNetCore.Routing.RouteGroupBuilder MapResponsesServer(this Microsoft.AspNetCore.Routing.IEndpointRouteBuilder endpoints, string? prefix = null) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("SCME0002")]
    public static partial class ResponsesServerHostExtensions
    {
        public static Microsoft.Extensions.Hosting.IHostApplicationBuilder AddResponsesServer(this Microsoft.Extensions.Hosting.IHostApplicationBuilder host, string sectionName) { throw null; }
        public static Microsoft.Extensions.Hosting.IHostApplicationBuilder AddResponsesServer(this Microsoft.Extensions.Hosting.IHostApplicationBuilder host, string sectionName, System.Action<Azure.AI.AgentServer.Responses.ResponsesServerSettings>? configureSettings) { throw null; }
    }
    public partial class ResponsesServerOptions
    {
        public ResponsesServerOptions() { }
        public int DefaultFetchHistoryCount { get { throw null; } set { } }
        public string? DefaultModel { get { throw null; } set { } }
        public bool ResilientBackground { get { throw null; } set { } }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("OPENAI001")]
        public System.Func<OpenAI.Responses.CreateResponseOptions, Azure.AI.AgentServer.Responses.ResponseContext, OpenAI.Responses.ResponseResult>? ResponseAcceptor { get { throw null; } set { } }
        public bool SteerableConversations { get { throw null; } set { } }
    }
    public static partial class ResponsesServerServiceCollectionExtensions
    {
        public static Microsoft.Extensions.DependencyInjection.IServiceCollection AddResponsesServer(this Microsoft.Extensions.DependencyInjection.IServiceCollection services, System.Action<Azure.AI.AgentServer.Responses.ResponsesServerOptions>? configure = null) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("SCME0002")]
    public partial class ResponsesServerSettings : System.ClientModel.Primitives.ClientSettings
    {
        public ResponsesServerSettings() { }
        public int DefaultFetchHistoryCount { get { throw null; } set { } }
        public string? DefaultModel { get { throw null; } set { } }
        public System.Uri? Endpoint { get { throw null; } set { } }
        public bool ResilientBackground { get { throw null; } set { } }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("OPENAI001")]
        public System.Func<OpenAI.Responses.CreateResponseOptions, Azure.AI.AgentServer.Responses.ResponseContext, OpenAI.Responses.ResponseResult>? ResponseAcceptor { get { throw null; } set { } }
        public bool SteerableConversations { get { throw null; } set { } }
        protected override void BindCore(Microsoft.Extensions.Configuration.IConfigurationSection section) { }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("OPENAI001")]
    public partial class TextContentBuilder
    {
        protected TextContentBuilder() { }
        public System.Collections.Generic.IReadOnlyList<OpenAI.Responses.ResponseMessageAnnotation> Annotations { get { throw null; } }
        public long ContentIndex { get { throw null; } }
        public string? FinalText { get { throw null; } }
        public virtual OpenAI.Responses.StreamingResponseContentPartAddedUpdate EmitAdded() { throw null; }
        public virtual OpenAI.Responses.StreamingResponseOutputTextAnnotationAddedUpdate EmitAnnotationAdded(OpenAI.Responses.ResponseMessageAnnotation annotation) { throw null; }
        public virtual OpenAI.Responses.StreamingResponseOutputTextDeltaUpdate EmitDelta(string text) { throw null; }
        public virtual OpenAI.Responses.StreamingResponseContentPartDoneUpdate EmitDone() { throw null; }
        public virtual OpenAI.Responses.StreamingResponseOutputTextDoneUpdate EmitTextDone(string? finalText = null) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("OPENAI001")]
    public partial class TextResponse : System.Collections.Generic.IAsyncEnumerable<OpenAI.Responses.StreamingResponseUpdate>
    {
        public TextResponse(Azure.AI.AgentServer.Responses.ResponseContext context, OpenAI.Responses.CreateResponseOptions request, System.Func<System.Threading.CancellationToken, System.Collections.Generic.IAsyncEnumerable<string>> createTextStream, System.Action<OpenAI.Responses.ResponseResult>? configure = null) { }
        public TextResponse(Azure.AI.AgentServer.Responses.ResponseContext context, OpenAI.Responses.CreateResponseOptions request, System.Func<System.Threading.CancellationToken, System.Threading.Tasks.Task<string>> createText, System.Action<OpenAI.Responses.ResponseResult>? configure = null) { }
        public System.Collections.Generic.IAsyncEnumerator<OpenAI.Responses.StreamingResponseUpdate> GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public sealed partial class ValidationError
    {
        public ValidationError(string path, string message) { }
        public string Message { get { throw null; } }
        public string Path { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WireFormatData
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public T To<T>() where T : System.ClientModel.Primitives.IPersistableModel<T> { throw null; }
    }
    public static partial class WireFormatExtensions
    {
        public static Azure.AI.AgentServer.Responses.WireFormatData Translate<T>(this T model) where T : System.ClientModel.Primitives.IPersistableModel<T> { throw null; }
    }
}
namespace Azure.AI.AgentServer.Responses.Models
{
    public partial class ComputerScreenshotContent : Azure.AI.AgentServer.Responses.Models.MessageContent, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ComputerScreenshotContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ComputerScreenshotContent>
    {
        public ComputerScreenshotContent(System.Uri imageUrl, string fileId, Azure.AI.AgentServer.Responses.Models.ImageDetail detail) { }
        public Azure.AI.AgentServer.Responses.Models.ImageDetail Detail { get { throw null; } set { } }
        public string FileId { get { throw null; } set { } }
        public System.Uri ImageUrl { get { throw null; } set { } }
        public Azure.AI.AgentServer.Responses.Models.PromptCacheBreakpointConfig PromptCacheBreakpoint { get { throw null; } set { } }
        protected override Azure.AI.AgentServer.Responses.Models.MessageContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.AgentServer.Responses.Models.MessageContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.ComputerScreenshotContent System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ComputerScreenshotContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ComputerScreenshotContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.ComputerScreenshotContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ComputerScreenshotContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ComputerScreenshotContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ComputerScreenshotContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConversationParam : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ConversationParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ConversationParam>
    {
        internal ConversationParam() { }
        public string Id { get { throw null; } }
        protected virtual Azure.AI.AgentServer.Responses.Models.ConversationParam JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.ConversationParam PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.ConversationParam System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ConversationParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ConversationParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.ConversationParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ConversationParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ConversationParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ConversationParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("OPENAI001")]
    public static partial class CreateResponseExtensions
    {
        public static Azure.AI.AgentServer.Responses.Models.ConversationParam? GetConversationExpanded(this OpenAI.Responses.CreateResponseOptions request) { throw null; }
        public static string? GetConversationId(this OpenAI.Responses.CreateResponseOptions request) { throw null; }
        public static System.Collections.Generic.List<OpenAI.Responses.ResponseItem> GetInputExpanded(this OpenAI.Responses.CreateResponseOptions request) { throw null; }
        public static System.BinaryData? GetInstructionsBinaryData(this OpenAI.Responses.CreateResponseOptions request) { throw null; }
        public static Azure.AI.AgentServer.Responses.Models.ToolChoiceParam? GetToolChoiceExpanded(this OpenAI.Responses.CreateResponseOptions request) { throw null; }
    }
    public partial class DirectToolCallCaller : Azure.AI.AgentServer.Responses.Models.ToolCallCaller, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.DirectToolCallCaller>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.DirectToolCallCaller>
    {
        public DirectToolCallCaller() { }
        protected override Azure.AI.AgentServer.Responses.Models.ToolCallCaller JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.AgentServer.Responses.Models.ToolCallCaller PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.DirectToolCallCaller System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.DirectToolCallCaller>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.DirectToolCallCaller>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.DirectToolCallCaller System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.DirectToolCallCaller>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.DirectToolCallCaller>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.DirectToolCallCaller>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DirectToolCallCallerParam : Azure.AI.AgentServer.Responses.Models.ToolCallCallerParam, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.DirectToolCallCallerParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.DirectToolCallCallerParam>
    {
        public DirectToolCallCallerParam() { }
        protected override Azure.AI.AgentServer.Responses.Models.ToolCallCallerParam JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.AgentServer.Responses.Models.ToolCallCallerParam PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.DirectToolCallCallerParam System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.DirectToolCallCallerParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.DirectToolCallCallerParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.DirectToolCallCallerParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.DirectToolCallCallerParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.DirectToolCallCallerParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.DirectToolCallCallerParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum FileInputDetail
    {
        Auto = 0,
        Low = 1,
        High = 2,
    }
    public enum FunctionCallOutputStatusEnum
    {
        InProgress = 0,
        Completed = 1,
        Incomplete = 2,
    }
    public enum FunctionCallStatus
    {
        InProgress = 0,
        Completed = 1,
        Incomplete = 2,
    }
    public enum ImageDetail
    {
        Low = 0,
        High = 1,
        Auto = 2,
        Original = 3,
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("OPENAI001")]
    public static partial class ItemExtensions
    {
        public static string GetInputText(this System.Collections.Generic.IEnumerable<OpenAI.Responses.ResponseItem> items) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("OPENAI001")]
    public static partial class ItemMessageExtensions
    {
        public static System.Collections.Generic.List<Azure.AI.AgentServer.Responses.Models.MessageContent> GetContentExpanded(this OpenAI.Responses.MessageResponseItem message) { throw null; }
    }
    public partial class LogProb : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.LogProb>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.LogProb>
    {
        public LogProb(string token, double logprob, System.Collections.Generic.IEnumerable<long> bytes, System.Collections.Generic.IEnumerable<Azure.AI.AgentServer.Responses.Models.TopLogProb> topLogprobs) { }
        public System.Collections.Generic.IList<long> Bytes { get { throw null; } }
        public double Logprob { get { throw null; } set { } }
        public string Token { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.AgentServer.Responses.Models.TopLogProb> TopLogprobs { get { throw null; } }
        protected virtual Azure.AI.AgentServer.Responses.Models.LogProb JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.LogProb PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.LogProb System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.LogProb>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.LogProb>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.LogProb System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.LogProb>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.LogProb>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.LogProb>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum MCPToolCallStatus
    {
        InProgress = 0,
        Completed = 1,
        Incomplete = 2,
        Calling = 3,
        Failed = 4,
    }
    public abstract partial class MessageContent : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.MessageContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.MessageContent>
    {
        internal MessageContent() { }
        protected virtual Azure.AI.AgentServer.Responses.Models.MessageContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.MessageContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.MessageContent System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.MessageContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.MessageContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.MessageContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.MessageContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.MessageContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.MessageContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageContentInputFileContent : Azure.AI.AgentServer.Responses.Models.MessageContent, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.MessageContentInputFileContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.MessageContentInputFileContent>
    {
        public MessageContentInputFileContent() { }
        public Azure.AI.AgentServer.Responses.Models.FileInputDetail? Detail { get { throw null; } set { } }
        public string FileData { get { throw null; } set { } }
        public string FileId { get { throw null; } set { } }
        public string Filename { get { throw null; } set { } }
        public System.Uri FileUrl { get { throw null; } set { } }
        public Azure.AI.AgentServer.Responses.Models.PromptCacheBreakpointConfig PromptCacheBreakpoint { get { throw null; } set { } }
        protected override Azure.AI.AgentServer.Responses.Models.MessageContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.AgentServer.Responses.Models.MessageContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.MessageContentInputFileContent System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.MessageContentInputFileContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.MessageContentInputFileContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.MessageContentInputFileContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.MessageContentInputFileContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.MessageContentInputFileContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.MessageContentInputFileContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageContentInputImageContent : Azure.AI.AgentServer.Responses.Models.MessageContent, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.MessageContentInputImageContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.MessageContentInputImageContent>
    {
        public MessageContentInputImageContent(Azure.AI.AgentServer.Responses.Models.ImageDetail detail) { }
        public Azure.AI.AgentServer.Responses.Models.ImageDetail Detail { get { throw null; } set { } }
        public string FileId { get { throw null; } set { } }
        public System.Uri ImageUrl { get { throw null; } set { } }
        public Azure.AI.AgentServer.Responses.Models.PromptCacheBreakpointConfig PromptCacheBreakpoint { get { throw null; } set { } }
        protected override Azure.AI.AgentServer.Responses.Models.MessageContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.AgentServer.Responses.Models.MessageContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.MessageContentInputImageContent System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.MessageContentInputImageContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.MessageContentInputImageContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.MessageContentInputImageContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.MessageContentInputImageContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.MessageContentInputImageContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.MessageContentInputImageContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageContentInputTextContent : Azure.AI.AgentServer.Responses.Models.MessageContent, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.MessageContentInputTextContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.MessageContentInputTextContent>
    {
        public MessageContentInputTextContent(string text) { }
        public Azure.AI.AgentServer.Responses.Models.PromptCacheBreakpointConfig PromptCacheBreakpoint { get { throw null; } set { } }
        public string Text { get { throw null; } set { } }
        protected override Azure.AI.AgentServer.Responses.Models.MessageContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.AgentServer.Responses.Models.MessageContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.MessageContentInputTextContent System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.MessageContentInputTextContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.MessageContentInputTextContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.MessageContentInputTextContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.MessageContentInputTextContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.MessageContentInputTextContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.MessageContentInputTextContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("OPENAI001")]
    public partial class MessageContentOutputTextContent : Azure.AI.AgentServer.Responses.Models.MessageContent, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.MessageContentOutputTextContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.MessageContentOutputTextContent>
    {
        public MessageContentOutputTextContent(string text) { }
        public System.Collections.Generic.IList<OpenAI.Responses.ResponseMessageAnnotation> Annotations { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.AgentServer.Responses.Models.LogProb> Logprobs { get { throw null; } }
        public string Text { get { throw null; } set { } }
        protected override Azure.AI.AgentServer.Responses.Models.MessageContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.AgentServer.Responses.Models.MessageContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.MessageContentOutputTextContent System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.MessageContentOutputTextContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.MessageContentOutputTextContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.MessageContentOutputTextContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.MessageContentOutputTextContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.MessageContentOutputTextContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.MessageContentOutputTextContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageContentReasoningTextContent : Azure.AI.AgentServer.Responses.Models.MessageContent, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.MessageContentReasoningTextContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.MessageContentReasoningTextContent>
    {
        public MessageContentReasoningTextContent(string text) { }
        public string Text { get { throw null; } set { } }
        protected override Azure.AI.AgentServer.Responses.Models.MessageContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.AgentServer.Responses.Models.MessageContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.MessageContentReasoningTextContent System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.MessageContentReasoningTextContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.MessageContentReasoningTextContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.MessageContentReasoningTextContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.MessageContentReasoningTextContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.MessageContentReasoningTextContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.MessageContentReasoningTextContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageContentRefusalContent : Azure.AI.AgentServer.Responses.Models.MessageContent, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.MessageContentRefusalContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.MessageContentRefusalContent>
    {
        public MessageContentRefusalContent(string refusal) { }
        public string Refusal { get { throw null; } set { } }
        protected override Azure.AI.AgentServer.Responses.Models.MessageContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.AgentServer.Responses.Models.MessageContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.MessageContentRefusalContent System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.MessageContentRefusalContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.MessageContentRefusalContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.MessageContentRefusalContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.MessageContentRefusalContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.MessageContentRefusalContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.MessageContentRefusalContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("OPENAI001")]
    public partial class OutputItemCustomToolCall : OpenAI.Responses.ResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.OutputItemCustomToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.OutputItemCustomToolCall>
    {
        public OutputItemCustomToolCall(string callId, string name, string input, Azure.AI.AgentServer.Responses.Models.FunctionCallStatus status) : base (default(OpenAI.Responses.ResponseItemKind)) { }
        public bool? Async { get { throw null; } set { } }
        public Azure.AI.AgentServer.Responses.Models.ToolCallCaller Caller { get { throw null; } set { } }
        public string CallId { get { throw null; } set { } }
        public string Input { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Namespace { get { throw null; } set { } }
        public Azure.AI.AgentServer.Responses.Models.FunctionCallStatus Status { get { throw null; } set { } }
        protected override OpenAI.Responses.ResponseItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override OpenAI.Responses.ResponseItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.OutputItemCustomToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.OutputItemCustomToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.OutputItemCustomToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.OutputItemCustomToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.OutputItemCustomToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.OutputItemCustomToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.OutputItemCustomToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("OPENAI001")]
    public partial class OutputItemCustomToolCallOutput : OpenAI.Responses.ResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.OutputItemCustomToolCallOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.OutputItemCustomToolCallOutput>
    {
        public OutputItemCustomToolCallOutput(string callId, System.BinaryData output, Azure.AI.AgentServer.Responses.Models.FunctionCallOutputStatusEnum status) : base (default(OpenAI.Responses.ResponseItemKind)) { }
        public Azure.AI.AgentServer.Responses.Models.ToolCallCallerParam Caller { get { throw null; } set { } }
        public string CallId { get { throw null; } set { } }
        public System.BinaryData Output { get { throw null; } set { } }
        public Azure.AI.AgentServer.Responses.Models.FunctionCallOutputStatusEnum Status { get { throw null; } set { } }
        protected override OpenAI.Responses.ResponseItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override OpenAI.Responses.ResponseItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.OutputItemCustomToolCallOutput System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.OutputItemCustomToolCallOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.OutputItemCustomToolCallOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.OutputItemCustomToolCallOutput System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.OutputItemCustomToolCallOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.OutputItemCustomToolCallOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.OutputItemCustomToolCallOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProgramToolCallCaller : Azure.AI.AgentServer.Responses.Models.ToolCallCaller, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ProgramToolCallCaller>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ProgramToolCallCaller>
    {
        public ProgramToolCallCaller(string callerId) { }
        public string CallerId { get { throw null; } set { } }
        protected override Azure.AI.AgentServer.Responses.Models.ToolCallCaller JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.AgentServer.Responses.Models.ToolCallCaller PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.ProgramToolCallCaller System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ProgramToolCallCaller>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ProgramToolCallCaller>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.ProgramToolCallCaller System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ProgramToolCallCaller>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ProgramToolCallCaller>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ProgramToolCallCaller>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProgramToolCallCallerParam : Azure.AI.AgentServer.Responses.Models.ToolCallCallerParam, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ProgramToolCallCallerParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ProgramToolCallCallerParam>
    {
        public ProgramToolCallCallerParam(string callerId) { }
        public string CallerId { get { throw null; } set { } }
        protected override Azure.AI.AgentServer.Responses.Models.ToolCallCallerParam JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.AgentServer.Responses.Models.ToolCallCallerParam PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.ProgramToolCallCallerParam System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ProgramToolCallCallerParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ProgramToolCallCallerParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.ProgramToolCallCallerParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ProgramToolCallCallerParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ProgramToolCallCallerParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ProgramToolCallCallerParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PromptCacheBreakpointConfig : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.PromptCacheBreakpointConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.PromptCacheBreakpointConfig>
    {
        public PromptCacheBreakpointConfig() { }
        public string Mode { get { throw null; } }
        protected virtual Azure.AI.AgentServer.Responses.Models.PromptCacheBreakpointConfig JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.PromptCacheBreakpointConfig PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.PromptCacheBreakpointConfig System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.PromptCacheBreakpointConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.PromptCacheBreakpointConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.PromptCacheBreakpointConfig System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.PromptCacheBreakpointConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.PromptCacheBreakpointConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.PromptCacheBreakpointConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("OPENAI001")]
    public static partial class ResponseExtensions
    {
        public static System.Collections.Generic.List<OpenAI.Responses.ResponseItem> GetInstructionItems(this OpenAI.Responses.ResponseResult response) { throw null; }
        public static Azure.AI.AgentServer.Responses.Models.ToolChoiceParam? GetToolChoiceExpanded(this OpenAI.Responses.ResponseResult response) { throw null; }
        public static void SetInstructions(this OpenAI.Responses.ResponseResult response, System.Collections.Generic.IList<OpenAI.Responses.ResponseItem> items) { }
        public static void SetInstructions(this OpenAI.Responses.ResponseResult response, string instructions) { }
        public static void SetToolChoice(this OpenAI.Responses.ResponseResult response, Azure.AI.AgentServer.Responses.Models.ToolChoiceOptions toolChoice) { }
        public static void SetToolChoice(this OpenAI.Responses.ResponseResult response, Azure.AI.AgentServer.Responses.Models.ToolChoiceParam toolChoice) { }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("OPENAI001")]
    public static partial class ResponsesModelFactory
    {
        public static OpenAI.Responses.StreamingResponseCreatedUpdate ResponseCreatedEvent(OpenAI.Responses.ResponseResult response = null, long sequenceNumber = (long)0) { throw null; }
        public static OpenAI.Responses.ResponseError ResponseErrorInfo(OpenAI.Responses.ResponseErrorCode code = default(OpenAI.Responses.ResponseErrorCode), string message = null) { throw null; }
        public static OpenAI.Responses.ResponseResult ResponseObject(string id = null, string model = null, OpenAI.Responses.ResponseStatus? status = default(OpenAI.Responses.ResponseStatus?), System.DateTimeOffset createdAt = default(System.DateTimeOffset), OpenAI.Responses.ResponseError error = null, System.Collections.Generic.IEnumerable<OpenAI.Responses.ResponseItem> output = null) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("OPENAI001")]
    public static partial class ResponseSnapshotExtensions
    {
        public static OpenAI.Responses.ResponseResult Snapshot(this OpenAI.Responses.ResponseResult response) { throw null; }
        public static void SnapshotEmbeddedResponse(this OpenAI.Responses.StreamingResponseUpdate evt, OpenAI.Responses.ResponseResult accumulator) { }
    }
    public partial class SpecificApplyPatchParam : Azure.AI.AgentServer.Responses.Models.ToolChoiceParam, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.SpecificApplyPatchParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.SpecificApplyPatchParam>
    {
        public SpecificApplyPatchParam() { }
        protected override Azure.AI.AgentServer.Responses.Models.ToolChoiceParam JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.AgentServer.Responses.Models.ToolChoiceParam PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.SpecificApplyPatchParam System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.SpecificApplyPatchParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.SpecificApplyPatchParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.SpecificApplyPatchParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.SpecificApplyPatchParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.SpecificApplyPatchParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.SpecificApplyPatchParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SpecificFunctionShellParam : Azure.AI.AgentServer.Responses.Models.ToolChoiceParam, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.SpecificFunctionShellParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.SpecificFunctionShellParam>
    {
        public SpecificFunctionShellParam() { }
        protected override Azure.AI.AgentServer.Responses.Models.ToolChoiceParam JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.AgentServer.Responses.Models.ToolChoiceParam PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.SpecificFunctionShellParam System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.SpecificFunctionShellParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.SpecificFunctionShellParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.SpecificFunctionShellParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.SpecificFunctionShellParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.SpecificFunctionShellParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.SpecificFunctionShellParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SpecificProgrammaticToolCallingParam : Azure.AI.AgentServer.Responses.Models.ToolChoiceParam, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.SpecificProgrammaticToolCallingParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.SpecificProgrammaticToolCallingParam>
    {
        public SpecificProgrammaticToolCallingParam() { }
        protected override Azure.AI.AgentServer.Responses.Models.ToolChoiceParam JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.AgentServer.Responses.Models.ToolChoiceParam PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.SpecificProgrammaticToolCallingParam System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.SpecificProgrammaticToolCallingParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.SpecificProgrammaticToolCallingParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.SpecificProgrammaticToolCallingParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.SpecificProgrammaticToolCallingParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.SpecificProgrammaticToolCallingParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.SpecificProgrammaticToolCallingParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SummaryTextContent : Azure.AI.AgentServer.Responses.Models.MessageContent, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.SummaryTextContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.SummaryTextContent>
    {
        public SummaryTextContent(string text) { }
        public string Text { get { throw null; } set { } }
        protected override Azure.AI.AgentServer.Responses.Models.MessageContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.AgentServer.Responses.Models.MessageContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.SummaryTextContent System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.SummaryTextContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.SummaryTextContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.SummaryTextContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.SummaryTextContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.SummaryTextContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.SummaryTextContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TextContent : Azure.AI.AgentServer.Responses.Models.MessageContent, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.TextContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.TextContent>
    {
        public TextContent(string text) { }
        public string Text { get { throw null; } set { } }
        protected override Azure.AI.AgentServer.Responses.Models.MessageContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.AgentServer.Responses.Models.MessageContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.TextContent System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.TextContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.TextContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.TextContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.TextContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.TextContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.TextContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ToolCallCaller : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ToolCallCaller>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ToolCallCaller>
    {
        internal ToolCallCaller() { }
        protected virtual Azure.AI.AgentServer.Responses.Models.ToolCallCaller JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.ToolCallCaller PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.ToolCallCaller System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ToolCallCaller>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ToolCallCaller>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.ToolCallCaller System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ToolCallCaller>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ToolCallCaller>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ToolCallCaller>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ToolCallCallerParam : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ToolCallCallerParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ToolCallCallerParam>
    {
        internal ToolCallCallerParam() { }
        protected virtual Azure.AI.AgentServer.Responses.Models.ToolCallCallerParam JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.ToolCallCallerParam PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.ToolCallCallerParam System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ToolCallCallerParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ToolCallCallerParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.ToolCallCallerParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ToolCallCallerParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ToolCallCallerParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ToolCallCallerParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ToolChoiceAllowed : Azure.AI.AgentServer.Responses.Models.ToolChoiceParam, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ToolChoiceAllowed>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ToolChoiceAllowed>
    {
        public ToolChoiceAllowed(Azure.AI.AgentServer.Responses.Models.ToolChoiceAllowedMode mode, System.Collections.Generic.IEnumerable<System.Collections.Generic.IDictionary<string, System.BinaryData>> tools) { }
        public Azure.AI.AgentServer.Responses.Models.ToolChoiceAllowedMode Mode { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.Collections.Generic.IDictionary<string, System.BinaryData>> Tools { get { throw null; } }
        protected override Azure.AI.AgentServer.Responses.Models.ToolChoiceParam JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.AgentServer.Responses.Models.ToolChoiceParam PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.ToolChoiceAllowed System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ToolChoiceAllowed>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ToolChoiceAllowed>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.ToolChoiceAllowed System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ToolChoiceAllowed>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ToolChoiceAllowed>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ToolChoiceAllowed>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum ToolChoiceAllowedMode
    {
        Auto = 0,
        Required = 1,
    }
    public partial class ToolChoiceCodeInterpreter : Azure.AI.AgentServer.Responses.Models.ToolChoiceParam, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ToolChoiceCodeInterpreter>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ToolChoiceCodeInterpreter>
    {
        public ToolChoiceCodeInterpreter() { }
        protected override Azure.AI.AgentServer.Responses.Models.ToolChoiceParam JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.AgentServer.Responses.Models.ToolChoiceParam PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.ToolChoiceCodeInterpreter System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ToolChoiceCodeInterpreter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ToolChoiceCodeInterpreter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.ToolChoiceCodeInterpreter System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ToolChoiceCodeInterpreter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ToolChoiceCodeInterpreter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ToolChoiceCodeInterpreter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ToolChoiceComputer : Azure.AI.AgentServer.Responses.Models.ToolChoiceParam, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ToolChoiceComputer>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ToolChoiceComputer>
    {
        public ToolChoiceComputer() { }
        protected override Azure.AI.AgentServer.Responses.Models.ToolChoiceParam JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.AgentServer.Responses.Models.ToolChoiceParam PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.ToolChoiceComputer System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ToolChoiceComputer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ToolChoiceComputer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.ToolChoiceComputer System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ToolChoiceComputer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ToolChoiceComputer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ToolChoiceComputer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ToolChoiceComputerUse : Azure.AI.AgentServer.Responses.Models.ToolChoiceParam, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ToolChoiceComputerUse>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ToolChoiceComputerUse>
    {
        public ToolChoiceComputerUse() { }
        protected override Azure.AI.AgentServer.Responses.Models.ToolChoiceParam JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.AgentServer.Responses.Models.ToolChoiceParam PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.ToolChoiceComputerUse System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ToolChoiceComputerUse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ToolChoiceComputerUse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.ToolChoiceComputerUse System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ToolChoiceComputerUse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ToolChoiceComputerUse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ToolChoiceComputerUse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ToolChoiceComputerUsePreview : Azure.AI.AgentServer.Responses.Models.ToolChoiceParam, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ToolChoiceComputerUsePreview>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ToolChoiceComputerUsePreview>
    {
        public ToolChoiceComputerUsePreview() { }
        protected override Azure.AI.AgentServer.Responses.Models.ToolChoiceParam JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.AgentServer.Responses.Models.ToolChoiceParam PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.ToolChoiceComputerUsePreview System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ToolChoiceComputerUsePreview>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ToolChoiceComputerUsePreview>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.ToolChoiceComputerUsePreview System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ToolChoiceComputerUsePreview>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ToolChoiceComputerUsePreview>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ToolChoiceComputerUsePreview>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ToolChoiceCustom : Azure.AI.AgentServer.Responses.Models.ToolChoiceParam, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ToolChoiceCustom>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ToolChoiceCustom>
    {
        public ToolChoiceCustom(string name) { }
        public string Name { get { throw null; } set { } }
        protected override Azure.AI.AgentServer.Responses.Models.ToolChoiceParam JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.AgentServer.Responses.Models.ToolChoiceParam PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.ToolChoiceCustom System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ToolChoiceCustom>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ToolChoiceCustom>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.ToolChoiceCustom System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ToolChoiceCustom>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ToolChoiceCustom>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ToolChoiceCustom>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ToolChoiceFileSearch : Azure.AI.AgentServer.Responses.Models.ToolChoiceParam, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ToolChoiceFileSearch>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ToolChoiceFileSearch>
    {
        public ToolChoiceFileSearch() { }
        protected override Azure.AI.AgentServer.Responses.Models.ToolChoiceParam JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.AgentServer.Responses.Models.ToolChoiceParam PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.ToolChoiceFileSearch System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ToolChoiceFileSearch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ToolChoiceFileSearch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.ToolChoiceFileSearch System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ToolChoiceFileSearch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ToolChoiceFileSearch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ToolChoiceFileSearch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ToolChoiceFunction : Azure.AI.AgentServer.Responses.Models.ToolChoiceParam, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ToolChoiceFunction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ToolChoiceFunction>
    {
        public ToolChoiceFunction(string name) { }
        public string Name { get { throw null; } set { } }
        protected override Azure.AI.AgentServer.Responses.Models.ToolChoiceParam JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.AgentServer.Responses.Models.ToolChoiceParam PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.ToolChoiceFunction System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ToolChoiceFunction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ToolChoiceFunction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.ToolChoiceFunction System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ToolChoiceFunction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ToolChoiceFunction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ToolChoiceFunction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ToolChoiceImageGeneration : Azure.AI.AgentServer.Responses.Models.ToolChoiceParam, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ToolChoiceImageGeneration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ToolChoiceImageGeneration>
    {
        public ToolChoiceImageGeneration() { }
        protected override Azure.AI.AgentServer.Responses.Models.ToolChoiceParam JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.AgentServer.Responses.Models.ToolChoiceParam PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.ToolChoiceImageGeneration System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ToolChoiceImageGeneration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ToolChoiceImageGeneration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.ToolChoiceImageGeneration System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ToolChoiceImageGeneration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ToolChoiceImageGeneration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ToolChoiceImageGeneration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ToolChoiceMCP : Azure.AI.AgentServer.Responses.Models.ToolChoiceParam, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ToolChoiceMCP>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ToolChoiceMCP>
    {
        public ToolChoiceMCP(string serverLabel) { }
        public string Name { get { throw null; } set { } }
        public string ServerLabel { get { throw null; } set { } }
        protected override Azure.AI.AgentServer.Responses.Models.ToolChoiceParam JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.AgentServer.Responses.Models.ToolChoiceParam PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.ToolChoiceMCP System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ToolChoiceMCP>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ToolChoiceMCP>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.ToolChoiceMCP System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ToolChoiceMCP>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ToolChoiceMCP>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ToolChoiceMCP>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum ToolChoiceOptions
    {
        None = 0,
        Auto = 1,
        Required = 2,
    }
    public abstract partial class ToolChoiceParam : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ToolChoiceParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ToolChoiceParam>
    {
        internal ToolChoiceParam() { }
        protected virtual Azure.AI.AgentServer.Responses.Models.ToolChoiceParam JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.ToolChoiceParam PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.ToolChoiceParam System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ToolChoiceParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ToolChoiceParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.ToolChoiceParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ToolChoiceParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ToolChoiceParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ToolChoiceParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ToolChoiceWebSearchPreview : Azure.AI.AgentServer.Responses.Models.ToolChoiceParam, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ToolChoiceWebSearchPreview>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ToolChoiceWebSearchPreview>
    {
        public ToolChoiceWebSearchPreview() { }
        protected override Azure.AI.AgentServer.Responses.Models.ToolChoiceParam JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.AgentServer.Responses.Models.ToolChoiceParam PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.ToolChoiceWebSearchPreview System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ToolChoiceWebSearchPreview>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ToolChoiceWebSearchPreview>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.ToolChoiceWebSearchPreview System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ToolChoiceWebSearchPreview>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ToolChoiceWebSearchPreview>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ToolChoiceWebSearchPreview>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ToolChoiceWebSearchPreview20250311 : Azure.AI.AgentServer.Responses.Models.ToolChoiceParam, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ToolChoiceWebSearchPreview20250311>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ToolChoiceWebSearchPreview20250311>
    {
        public ToolChoiceWebSearchPreview20250311() { }
        protected override Azure.AI.AgentServer.Responses.Models.ToolChoiceParam JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.AgentServer.Responses.Models.ToolChoiceParam PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.ToolChoiceWebSearchPreview20250311 System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ToolChoiceWebSearchPreview20250311>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ToolChoiceWebSearchPreview20250311>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.ToolChoiceWebSearchPreview20250311 System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ToolChoiceWebSearchPreview20250311>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ToolChoiceWebSearchPreview20250311>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ToolChoiceWebSearchPreview20250311>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TopLogProb : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.TopLogProb>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.TopLogProb>
    {
        public TopLogProb(string token, double logprob, System.Collections.Generic.IEnumerable<long> bytes) { }
        public System.Collections.Generic.IList<long> Bytes { get { throw null; } }
        public double Logprob { get { throw null; } set { } }
        public string Token { get { throw null; } set { } }
        protected virtual Azure.AI.AgentServer.Responses.Models.TopLogProb JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.TopLogProb PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.TopLogProb System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.TopLogProb>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.TopLogProb>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.TopLogProb System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.TopLogProb>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.TopLogProb>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.TopLogProb>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
